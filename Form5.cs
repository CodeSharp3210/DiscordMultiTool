
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

            string logDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TelegramMultiTool", "logs");
            Directory.CreateDirectory(logDir);
            string logFile = Path.Combine(logDir, $"bot_{DateTime.Now:yyyyMMdd_HHmmss}.log");

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

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string token = tokenTextBox.Text?.Trim() ?? string.Empty;
            string chatId = chatIdTextBox.Text?.Trim() ?? string.Empty;
            string message = messageTextBox.Text ?? string.Empty;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(chatId))
            {
                MessageBox.Show("Please provide both Bot Token and Chat ID.", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string url = $"https://api.telegram.org/bot{Uri.EscapeDataString(token)}/sendMessage";
                    var data = new System.Collections.Specialized.NameValueCollection();
                    data["chat_id"] = chatId;
                    data["text"] = message;

                    byte[] response = await wc.UploadValuesTaskAsync(url, "POST", data);
                    string resp = Encoding.UTF8.GetString(response);
                    MessageBox.Show("Message sent. Response: " + resp, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(47, 49, 54);
        }

    }
}


