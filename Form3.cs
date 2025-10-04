using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string scriptPath = null;

            // Creo un thread STA per aprire il file dialog (evita problemi OLE/debugger)
            Thread t = new Thread(() =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Title = "Seleziona il file Python del bot",
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

            // Controllo se sembra un bot Discord
            bool likelyDiscordBot = false;
            try
            {
                string content = File.ReadAllText(scriptPath, Encoding.UTF8).ToLowerInvariant();
                if (content.Contains("import discord") ||
                    content.Contains("discord.client") ||
                    content.Contains("discord.ext") ||
                    content.Contains("from discord") ||
                    content.Contains("discord.intents") ||
                    content.Contains("bot.run("))
                {
                    likelyDiscordBot = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore leggendo il file: {ex.Message}");
                return;
            }

            if (likelyDiscordBot)
            {
                if (MessageBox.Show("Trovato codice che sembra un bot Discord. Vuoi avviarlo?",
                                    "Conferma", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
            else
            {
                if (MessageBox.Show("Non sembra un bot Discord. Vuoi avviare comunque?",
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

            // Controllo discord.py
            if (!IsDiscordPyInstalled())
            {
                if (MessageBox.Show("La libreria discord.py non è installata. Vuoi installarla automaticamente?",
                                    "Libreria mancante", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                if (!TryInstallDiscordPy())
                {
                    MessageBox.Show("Installazione di discord.py fallita. Installa manualmente (es. pip install -U discord.py) e riprova.");
                    return;
                }
            }

            // Avvio lo script (background) con capture log
            try
            {
                StartPythonScriptBackground(scriptPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore avvio script: {ex.Message}");
            }
        }

        // --------------------------
        // Metodi di supporto
        // --------------------------

        private static bool IsPythonInstalled()
        {
            return RunProcessAndReturnSuccess("python", "--version", 3000) ||
                   RunProcessAndReturnSuccess("py", "--version", 3000);
        }

        private static bool IsDiscordPyInstalled()
        {
            // proviamo sia il nome "discord" che "discord.py"
            return RunProcessAndReturnSuccess("python", "-m pip show discord", 5000) ||
                   RunProcessAndReturnSuccess("py", "-m pip show discord", 5000) ||
                   RunProcessAndReturnSuccess("python", "-m pip show discord.py", 5000) ||
                   RunProcessAndReturnSuccess("py", "-m pip show discord.py", 5000);
        }

        private static bool TryInstallDiscordPy()
        {
            // Proviamo a installare la versione aggiornata
            if (RunProcessAndReturnSuccess("python", "-m pip install -U discord.py", 120000))
                return true;
            if (RunProcessAndReturnSuccess("py", "-m pip install -U discord.py", 120000))
                return true;

            // fallback a "discord" se necessario
            if (RunProcessAndReturnSuccess("python", "-m pip install -U discord", 120000))
                return true;
            if (RunProcessAndReturnSuccess("py", "-m pip install -U discord", 120000))
                return true;

            return false;
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

            // fallback: scarica installer da python.org (versione esempio)
            try
            {
                string temp = Path.Combine(Path.GetTempPath(), "python_installer.exe");
                using (WebClient wc = new WebClient())
                {
                    // NOTA: puoi aggiornare la URL alla versione che preferisci
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

        /// <summary>
        /// Esegue un processo e ritorna true se termina con codice 0 entro timeout (ms).
        /// </summary>
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

        /// <summary>
        /// Avvia lo script Python in background, cattura stdout/stderr in un file di log e notifica l'utente.
        /// </summary>
        private static void StartPythonScriptBackground(string scriptPath)
        {
            string pythonExe = RunProcessAndReturnSuccess("python", "--version", 2000) ? "python" : "py";

            string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DiscordMultiTool", "logs");
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

            // scriviamo output su file man mano
            using (StreamWriter logWriter = new StreamWriter(new FileStream(logFile, FileMode.Create, FileAccess.Write, FileShare.Read)))
            {
                // Handlers
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

                        }
                    }
                };

                proc.Exited += (s, e) =>
                {
                    // se il processo termina subito con codice diverso da zero, notifichiamo l'utente
                    try
                    {
                        int code = proc.ExitCode;
                        if (code != 0)
                        {
                            MessageBox.Show($"Il bot è terminato con codice {code}. Controlla il log: {logFile}", "Errore bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // processo terminato correttamente (es. bot chiuso dall'utente)
                            MessageBox.Show($"Il bot è terminato (exit code 0). Log: {logFile}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        // ignora
                    }
                };

                // Avvio
                bool started = proc.Start();
                if (!started)
                {
                    MessageBox.Show("Impossibile avviare il processo Python.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                // Aspettiamo un breve intervallo per verificare crash immediato (es. manca modulo)
                Task.Delay(2500).ContinueWith(_ =>
                {
                    try
                    {
                        if (proc.HasExited)
                        {
                            // processo già terminato: notificare (il codice Exited handler si occuperà)
                            // ma leggiamo le prime righe del log e le mostriamo in una MessageBox per debugging rapido
                            try
                            {
                                string firstLines = File.ReadAllText(logFile);
                                string snippet = firstLines.Length > 4000 ? firstLines.Substring(0, 4000) : firstLines;
                                MessageBox.Show($"Il processo Python è terminato immediatamente. Primo contenuto del log:\n\n{snippet}\n\nControlla il file di log: {logFile}", "Errore avvio script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch { }
                            return;
                        }
                        else
                        {
                            // processo vivo: notifica all'utente che è stato avviato in background e dove trovare il log
                            MessageBox.Show($"Script avviato in background (PID {proc.Id}). Log: {logFile}", "Avviato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch { }
                });

                // Non fare .WaitForExit() qui: lasciamo il processo in esecuzione e il metodo ritorna.
                // Chiudiamo lo streamWriter quando la funzione esce (usando using) — 
                // ma attenzione: proc continuerà ad usare gli handlers che scrivono sullo stesso file.
                // Per sicurezza, lasciamo il logWriter aperto fintanto che proc è in esecuzione.
                // Per questo motivo non usiamo using sul logWriter a lungo termine.
                //
                // Soluzione pragmatica: rilanciamo un thread separato che attende la terminazione
                // e poi chiude il writer.
                Thread waiter = new Thread(() =>
                {
                    try
                    {
                        MessageBox.Show("Il Bot è ora in esecuzione!");
                    }
                    catch { }
                    finally
                    {
                        try
                        {
                            lock (logWriter)
                            {
                                logWriter.Flush();
                                logWriter.Close();
                            }
                        }
                        catch { }
                        try { proc.Dispose(); } catch { }
                    }
                })
                { IsBackground = true };
                waiter.Start();

                // ritorniamo subito: il bot è in esecuzione in background e scrive su log
                return;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}
