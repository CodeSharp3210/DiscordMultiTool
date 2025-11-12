
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiscordMultiTool
{
    public partial class Form5 : Form
    {


        public Form5()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            string scriptPath = null;

            // Apro il file dialog per selezionare il file Python
            Thread t = new Thread(() =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Title = "Seleziona il file Python del bot Telegram",
                    Filter = "Python files (*.py)|*.py|All files (*.*)|*.*",
                    CheckFileExists = true,
                    Multiselect = false
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        scriptPath = ofd.FileName;
                    }
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (string.IsNullOrEmpty(scriptPath))
                return;

            // Controllo se sembra un bot Telegram
            bool likelyTelegramBot = false;
            try
            {
                string content = File.ReadAllText(scriptPath, Encoding.UTF8).ToLowerInvariant();
                if (content.Contains("import telegram") ||
                    content.Contains("from telegram") ||
                    content.Contains("telegram.bot") ||
                    content.Contains("telegram.ext") ||
                    content.Contains("updater(") ||
                    content.Contains("application.builder"))
                {
                    likelyTelegramBot = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore leggendo il file: {ex.Message}");
                return;
            }

            if (likelyTelegramBot)
            {
                if (MessageBox.Show("Trovato codice che sembra un bot Telegram. Vuoi avviarlo?",
                                    "Conferma", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
            else
            {
                if (MessageBox.Show("Non sembra un bot Telegram. Vuoi avviare comunque?",
                                    "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            // Controllo Python
            if (!IsPythonInstalled())
            {
                if (MessageBox.Show("Python non trovato. Vuoi installarlo automaticamente?",
                                    "Python mancante", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                if (!TryInstallPython())
                {
                    MessageBox.Show("Installazione Python fallita. Installa manualmente e riprova.");
                    return;
                }
            }

            // Controllo python-telegram-bot
            if (!IsTelegramLibInstalled())
            {
                if (MessageBox.Show("La libreria python-telegram-bot non è installata. Vuoi installarla automaticamente?",
                                    "Libreria mancante", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                if (!TryInstallTelegramLib())
                {
                    MessageBox.Show("Installazione di python-telegram-bot fallita. Installa manualmente (es. pip install -U python-telegram-bot) e riprova.");
                    return;
                }
            }

            // Avvio lo script (background)
            try
            {
                StartPythonScriptBackground(scriptPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore avvio script: {ex.Message}");
            }
        }

        private static bool IsPythonInstalled()
        {
            return RunProcessAndReturnSuccess("python", "--version", 3000) ||
                   RunProcessAndReturnSuccess("py", "--version", 3000);
        }

        private static bool TryInstallPython()
        {
            try
            {
                // prova con winget
                if (RunProcessAndReturnSuccess("winget", "--version", 2000))
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "winget",
                        Arguments = "install --id Python.Python.3 -e --accept-package-agreements --accept-source-agreements",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };
                    using Process p = Process.Start(psi);
                    p.WaitForExit();
                    return p.ExitCode == 0;
                }
            }
            catch { }

            // fallback: scarica installer da python.org
            try
            {
                string temp = Path.Combine(Path.GetTempPath(), "python_installer.exe");
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile("https://www.python.org/ftp/python/3.11.6/python-3.11.6-amd64.exe", temp);
                }

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = temp,
                    Arguments = "/quiet InstallAllUsers=1 PrependPath=1",
                    UseShellExecute = true,
                    Verb = "runas"
                };
                using Process p = Process.Start(psi);
                p.WaitForExit();

                try { File.Delete(temp); } catch { }
                return p.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsTelegramLibInstalled()
        {
            return RunProcessAndReturnSuccess("python", "-m pip show python-telegram-bot", 5000) ||
                   RunProcessAndReturnSuccess("py", "-m pip show python-telegram-bot", 5000);
        }

        private static bool TryInstallTelegramLib()
        {
            if (RunProcessAndReturnSuccess("python", "-m pip install -U python-telegram-bot", 120000))
                return true;
            if (RunProcessAndReturnSuccess("py", "-m pip install -U python-telegram-bot", 120000))
                return true;
            return false;
        }

        private static bool RunProcessAndReturnSuccess(string exe, string args, int timeoutMs)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using Process p = new Process() { StartInfo = psi };
                p.Start();

                if (!p.WaitForExit(timeoutMs))
                {
                    try { p.Kill(); } catch { }
                    return false;
                }

                return p.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        private static void StartPythonScriptBackground(string scriptPath)
        {
            string pythonExe = RunProcessAndReturnSuccess("python", "--version", 2000) ? "python" : "py";
            string logFile = @"C:\Users\" + Environment.UserName + @"\.dmt";

            string contenutoLog = $"bot_{DateTime.Now:yyyyMMdd_HHmmss}.log";

            if (Directory.Exists(logFile))
            {
                if (!File.Exists(logFile + @"\log.txt"))
                {
                    File.WriteAllText(logFile + @"\log.txt", contenutoLog);
                }
            }
            else
            {
                Directory.CreateDirectory(logFile);
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonExe,
                Arguments = $"\"{scriptPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Path.GetDirectoryName(scriptPath) ?? Environment.CurrentDirectory
            };

            Process proc = new Process { StartInfo = psi, EnableRaisingEvents = true };

            StreamWriter logWriter = new StreamWriter(new FileStream(logFile, FileMode.Create, FileAccess.Write, FileShare.Read));

            proc.OutputDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    lock (logWriter)
                    {
                        logWriter.WriteLine($"[OUT {DateTime.Now:HH:mm:ss}] {e.Data}");
                        logWriter.Flush();
                    }
                }
            };

            proc.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    lock (logWriter)
                    {
                        logWriter.WriteLine($"[ERR {DateTime.Now:HH:mm:ss}] {e.Data}");
                        logWriter.Flush();
                    }
                }
            };

            proc.Exited += (s, e) =>
            {
                try
                {
                    int code = proc.ExitCode;
                    if (code != 0)
                    {
                        MessageBox.Show($"Il bot è terminato con codice {code}. Controlla il log: {logFile}",
                            "Errore bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Il bot è terminato correttamente. Log: {logFile}",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch { }
            };

            if (!proc.Start())
            {
                MessageBox.Show("Impossibile avviare il processo Python.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();

            Task.Delay(2500).ContinueWith(_ =>
            {
                try
                {
                    if (proc.HasExited)
                    {
                        string snippet = File.ReadAllText(logFile);
                        snippet = snippet.Length > 4000 ? snippet.Substring(0, 4000) : snippet;
                        MessageBox.Show($"Il bot è terminato immediatamente. Log:\n\n{snippet}",
                            "Errore avvio script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Bot avviato in background (PID {proc.Id}). Log: {logFile}",
                            "Avviato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch { }
            });

            Thread waiter = new Thread(() =>
            {
                try { proc.WaitForExit(); }
                finally
                {
                    lock (logWriter)
                    {
                        logWriter.Flush();
                        logWriter.Close();
                    }
                    try { proc.Dispose(); } catch { }
                }
            })
            { IsBackground = true };
            waiter.Start();
        }

        private GraphicsPath RoundedRectPath(RectangleF bounds, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            float diameter = radius * 2f;
            var arc = new RectangleF(bounds.Location, new SizeF(diameter, diameter));

            // Top-left arc
            path.AddArc(arc, 180, 90);

            // Top-right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom-right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom-left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void ConfigureButtonOutline(System.Windows.Forms.Button btn, Color color, int radius, float thickness = 2.5f)
        {
            if (btn == null) return;

            // Set button to flat style for better rendering
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;

            // Store original Region to avoid conflicts
            btn.Region = null;

            // Ensure we repaint when size changes
            btn.SizeChanged += (s, e) => btn.Invalidate();

            btn.Paint += (s, e) =>
            {
                // Enable highest quality anti-aliasing
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Draw background first
                using (var bgPath = RoundedRectPath(new RectangleF(0, 0, btn.Width, btn.Height), radius))
                {
                    using (var bgBrush = new SolidBrush(btn.BackColor))
                    {
                        e.Graphics.FillPath(bgBrush, bgPath);
                    }
                }

                // Calculate border rectangle with proper inset
                float offset = thickness;
                var rect = new RectangleF(
                    offset,
                    offset,
                    btn.Width - (thickness * 2),
                    btn.Height - (thickness * 2)
                );

                // Draw smooth rounded border
                using (var pen = new Pen(color, thickness))
                {
                    pen.Alignment = PenAlignment.Center;
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                    using (var path = RoundedRectPath(rect, radius - 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                // Draw text centered
                using (var format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    using (var textBrush = new SolidBrush(btn.ForeColor))
                    {
                        e.Graphics.DrawString(btn.Text, btn.Font, textBrush, btn.ClientRectangle, format);
                    }
                }
            };
        }
        

        private void Form5_Load(object sender, EventArgs e)
        {

            var outlineColor = Color.Silver;
            int radiusSmall = 10;
            int radiusLarge = 15;

            ConfigureButtonOutline(loadBotButton, outlineColor, radiusSmall);

            this.BackColor = Color.FromArgb(47, 49, 54);
        }

    }
}


