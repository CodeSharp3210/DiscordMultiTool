using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordMultiTool
{
    public partial class Form1 : Form
    {
        private string currentLanguage = "English";
        private Dictionary<string, Dictionary<string, string>> translations;
        private Timer fadeTimer;
        private Panel currentPanel;
        
        private static DiscordRPC.DiscordRpcClient rpcClient;
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
            InitializeTranslations();
            this.FormClosing += Form1_FormClosing;
            
            languageComboBox.SelectedIndex = 0;
            currentPanel = settingsPanel;
            settingsPanel.Visible = true;
        }

        private void InitializeTranslations()
        {
            translations = new Dictionary<string, Dictionary<string, string>>
            {
                ["English"] = new Dictionary<string, string>
                {
                    ["button1"] = "Discord Rich Presence",
                    ["button2"] = "Discord Bot (Python)",
                    ["button3"] = "Developer Portal",
                    ["button4"] = "Inject DLL",
                    ["button5"] = "Discord Connection",
                    ["button6"] = "Exit Application",
                    ["button7"] = "Close Discord",
                    ["button8"] = "Misc Tools",
                    ["btnSettings"] = "⚙ Settings",
                    ["button9"] = "Customize Colors",
                    ["button10"] = "Change Theme",
                    ["button11"] = "Apply Discord Patch",
                    ["label3"] = "Discord Account",
                    ["label4"] = "Target Server",
                    ["label5"] = "Save Settings",
                    ["checkBox1"] = "Auto Save Settings",
                    ["lblLanguage"] = "Language",
                    ["rpcButton1"] = "Load Discord RPC",
                    ["rpcLabel1"] = "Application ID",
                    ["rpcLabel2"] = "State",
                    ["rpcLabel3"] = "Image Text",
                    ["rpcLabel4"] = "Details",
                    ["rpcLabel5"] = "Image Name",
                    ["rpcLinkLabel1"] = "Help",
                    ["botButton1"] = "Select Bot File",
                    ["botLabel1"] = "Load your Discord Bot written in Python.\nThis tool will check for Python, install dependencies if needed,\nand run your bot in the background.",
                    ["dllButton1"] = "Select DLL File",
                    ["dllLabel1"] = "Inject a custom DLL into the Discord process.\nThis allows you to modify Discord's behavior.",
                    ["msgConnected"] = "Discord MultiTool is already connected with your Discord Client\nProcess Name: {0}\nProcess PID: {1}",
                    ["msgNoDiscord"] = "No running Discord process was found.",
                    ["msgTelegram"] = "Telegram features are currently in development.\nPlease follow on GitHub for the latest updates!",
                    ["msgRPCRunning"] = "RPC already running.",
                    ["msgEnterAppId"] = "Please enter an Application ID.",
                    ["msgRPCConnected"] = "Discord RPC connected.",
                    ["msgRPCError"] = "RPC Error: {0}",
                    ["msgRPCHelp"] = "---------- RPC INJECTOR GUIDE ----------\n\n1) Create an app on https://discord.com/developers/applications\n2) Upload an image in the Rich Presence Assets section\n3) Copy the APPLICATION ID and customize the status\n4) Enter the image name from the developer portal\n5) Click Load Discord RPC and enjoy!"
                },
                ["Italiano"] = new Dictionary<string, string>
                {
                    ["button1"] = "Discord Rich Presence",
                    ["button2"] = "Bot Discord (Python)",
                    ["button3"] = "Portale Sviluppatori",
                    ["button4"] = "Inietta DLL",
                    ["button5"] = "Connessione Discord",
                    ["button6"] = "Esci dall'Applicazione",
                    ["button7"] = "Chiudi Discord",
                    ["button8"] = "Strumenti Vari",
                    ["btnSettings"] = "⚙ Impostazioni",
                    ["button9"] = "Personalizza Colori",
                    ["button10"] = "Cambia Tema",
                    ["button11"] = "Applica Patch Discord",
                    ["label3"] = "Account Discord",
                    ["label4"] = "Server di Destinazione",
                    ["label5"] = "Salva Impostazioni",
                    ["checkBox1"] = "Salvataggio Automatico",
                    ["lblLanguage"] = "Lingua",
                    ["rpcButton1"] = "Carica Discord RPC",
                    ["rpcLabel1"] = "ID Applicazione",
                    ["rpcLabel2"] = "Stato",
                    ["rpcLabel3"] = "Testo Immagine",
                    ["rpcLabel4"] = "Dettagli",
                    ["rpcLabel5"] = "Nome Immagine",
                    ["rpcLinkLabel1"] = "Aiuto",
                    ["botButton1"] = "Seleziona File Bot",
                    ["botLabel1"] = "Carica il tuo Bot Discord scritto in Python.\nQuesto strumento controllerà Python, installerà le dipendenze se necessario,\ne eseguirà il tuo bot in background.",
                    ["dllButton1"] = "Seleziona File DLL",
                    ["dllLabel1"] = "Inietta una DLL personalizzata nel processo Discord.\nCiò ti permette di modificare il comportamento di Discord.",
                    ["msgConnected"] = "Discord MultiTool è già connesso al tuo Client Discord\nNome Processo: {0}\nPID Processo: {1}",
                    ["msgNoDiscord"] = "Nessun processo Discord in esecuzione trovato.",
                    ["msgTelegram"] = "Le funzionalità Telegram sono attualmente in sviluppo.\nSegui su GitHub per gli ultimi aggiornamenti!",
                    ["msgRPCRunning"] = "RPC già in esecuzione.",
                    ["msgEnterAppId"] = "Inserisci un ID Applicazione.",
                    ["msgRPCConnected"] = "Discord RPC connesso.",
                    ["msgRPCError"] = "Errore RPC: {0}",
                    ["msgRPCHelp"] = "---------- GUIDA RPC INJECTOR ----------\n\n1) Crea un'app su https://discord.com/developers/applications\n2) Carica un'immagine nella sezione Rich Presence Assets\n3) Copia l'ID APPLICAZIONE e personalizza lo stato\n4) Inserisci il nome dell'immagine dal portale sviluppatori\n5) Clicca Carica Discord RPC e goditi il risultato!"
                }
            };
        }

        private void UpdateLanguage()
        {
            var lang = translations[currentLanguage];
            
            button1.Text = lang["button1"];
            button2.Text = lang["button2"];
            button3.Text = lang["button3"];
            button4.Text = lang["button4"];
            button5.Text = lang["button5"];
            button6.Text = lang["button6"];
            button7.Text = lang["button7"];
            button8.Text = lang["button8"];
            btnSettings.Text = lang["btnSettings"];
            
            button9.Text = lang["button9"];
            button10.Text = lang["button10"];
            button11.Text = lang["button11"];
            label3.Text = lang["label3"];
            label4.Text = lang["label4"];
            label5.Text = lang["label5"];
            checkBox1.Text = lang["checkBox1"];
            lblLanguage.Text = lang["lblLanguage"];
            
            rpcButton1.Text = lang["rpcButton1"];
            rpcLabel1.Text = lang["rpcLabel1"];
            rpcLabel2.Text = lang["rpcLabel2"];
            rpcLabel3.Text = lang["rpcLabel3"];
            rpcLabel4.Text = lang["rpcLabel4"];
            rpcLabel5.Text = lang["rpcLabel5"];
            rpcLinkLabel1.Text = lang["rpcLinkLabel1"];
            
            botButton1.Text = lang["botButton1"];
            botLabel1.Text = lang["botLabel1"];
            dllButton1.Text = lang["dllButton1"];
            dllLabel1.Text = lang["dllLabel1"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = (Properties.Settings.Default.checkbox == "True");

            if (checkBox1.Checked)
            {
                textBox1.Text = Properties.Settings.Default.textbox1;
                textBox2.Text = Properties.Settings.Default.textbox2;

                if (Properties.Settings.Default.tema == "Modern")
                {
                    button10.Text = translations[currentLanguage]["button10"] + ": Classic";
                    ApplyModernTheme();
                }
                else if (Properties.Settings.Default.tema == "Classic")
                {
                    button10.Text = translations[currentLanguage]["button10"] + ": Modern";
                    ApplyClassicTheme();
                }
            }

            Process processo = Process.GetCurrentProcess();
            string nomeProcesso = processo.ProcessName;
            label1.Text = $"DiscordMultiTool v1.1.0\nMasterSharp Team LLC.";

            string cartella = @"C:\Users\" + Environment.UserName + @"\DiscordMultiTool";
            string contenutoLog = $"DiscordMultiTool injected.\n{textBox1.Text}\n{textBox2.Text}";

            if (Directory.Exists(cartella))
            {
                if (!File.Exists(cartella + @"\log.txt"))
                {
                    File.WriteAllText(cartella + @"\log.txt", contenutoLog);
                }
            }
            else
            {
                Directory.CreateDirectory(cartella);
            }
            
            UpdateLanguage();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.checkbox = checkBox1.Checked ? "True" : "False";
            Properties.Settings.Default.textbox1 = textBox1.Text;
            Properties.Settings.Default.textbox2 = textBox2.Text;

            if (button10.Text.Contains("Classic"))
                Properties.Settings.Default.tema = "Modern";
            else
                Properties.Settings.Default.tema = "Classic";

            Properties.Settings.Default.Save();
            
            try
            {
                _cts?.Cancel();
                if (rpcClient != null)
                {
                    if (rpcClient.IsInitialized)
                        rpcClient.Deinitialize();
                    rpcClient.Dispose();
                    rpcClient = null;
                }
            }
            catch { }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = SystemColors.Control;
            leftPanel.BackColor = Color.FromArgb(32, 34, 37);
            contentPanel.BackColor = SystemColors.Control;
            settingsPanel.BackColor = SystemColors.Control;
            richPresencePanel.BackColor = SystemColors.Control;
            botPanel.BackColor = SystemColors.Control;
            dllPanel.BackColor = SystemColors.Control;
        }

        private void ApplyClassicTheme()
        {
            this.BackColor = Color.FromArgb(54, 57, 63);
            leftPanel.BackColor = Color.FromArgb(32, 34, 37);
            contentPanel.BackColor = Color.FromArgb(47, 49, 54);
            settingsPanel.BackColor = Color.FromArgb(47, 49, 54);
            richPresencePanel.BackColor = Color.FromArgb(47, 49, 54);
            botPanel.BackColor = Color.FromArgb(47, 49, 54);
            dllPanel.BackColor = Color.FromArgb(47, 49, 54);
        }

        private async void SwitchPanel(Panel newPanel)
        {
            if (currentPanel == newPanel) return;

            await FadeOut(currentPanel);
            currentPanel.Visible = false;
            
            currentPanel = newPanel;
            currentPanel.Visible = true;
            await FadeIn(currentPanel);
        }

        private Task FadeOut(Control control)
        {
            var tcs = new TaskCompletionSource<bool>();
            
            Timer timer = new Timer();
            timer.Interval = 10;
            double opacity = 1.0;
            
            timer.Tick += (s, e) =>
            {
                opacity -= 0.05;
                if (opacity <= 0)
                {
                    timer.Stop();
                    timer.Dispose();
                    tcs.SetResult(true);
                }
            };
            
            timer.Start();
            return tcs.Task;
        }

        private Task FadeIn(Control control)
        {
            var tcs = new TaskCompletionSource<bool>();
            
            Timer timer = new Timer();
            timer.Interval = 10;
            double opacity = 0.0;
            
            timer.Tick += (s, e) =>
            {
                opacity += 0.05;
                if (opacity >= 1)
                {
                    timer.Stop();
                    timer.Dispose();
                    tcs.SetResult(true);
                }
            };
            
            timer.Start();
            return tcs.Task;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(47, 49, 54);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(32, 34, 37);
            }
        }

        private void DangerButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(64, 25, 25);
            }
        }

        private void DangerButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(32, 34, 37);
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ColorDialog COLORGUI = new ColorDialog();
            if (COLORGUI.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = COLORGUI.Color;
                label1.ForeColor = COLORGUI.Color;
                label3.ForeColor = COLORGUI.Color;
                label4.ForeColor = COLORGUI.Color;
                label5.ForeColor = COLORGUI.Color;
                lblLanguage.ForeColor = COLORGUI.Color;
                button1.ForeColor = COLORGUI.Color;
                button2.ForeColor = COLORGUI.Color;
                button3.ForeColor = COLORGUI.Color;
                button4.ForeColor = COLORGUI.Color;
                button5.ForeColor = COLORGUI.Color;
                button8.ForeColor = COLORGUI.Color;
                btnSettings.ForeColor = COLORGUI.Color;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string url = "https://discord.com/developers/applications";
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Process[] ProcessoDiscord = Process.GetProcessesByName("Discord");
            try
            {
                ProcessoDiscord[0].Kill();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Process processo = Process.GetCurrentProcess();
            processo.Kill();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (button10.Text.Contains("Classic"))
            {
                button10.Text = translations[currentLanguage]["button10"] + ": Modern";
                ApplyClassicTheme();
                Properties.Settings.Default.tema = "Classic";
                Properties.Settings.Default.Save();
            }
            else
            {
                button10.Text = translations[currentLanguage]["button10"] + ": Classic";
                ApplyModernTheme();
                Properties.Settings.Default.tema = "Modern";
                Properties.Settings.Default.Save();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(translations[currentLanguage]["msgTelegram"]);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Process[] ProcessoDiscord = Process.GetProcessesByName("Discord");
            if (ProcessoDiscord.Length > 0)
            {
                string discordID = ProcessoDiscord[0].Id.ToString();
                MessageBox.Show(string.Format(translations[currentLanguage]["msgConnected"], 
                    ProcessoDiscord[0].ProcessName, discordID));
            }
            else
            {
                MessageBox.Show(translations[currentLanguage]["msgNoDiscord"]);
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("explorer");
            foreach (Process process in processes)
            {
                process.Kill();
            }
            Thread.Sleep(2000);
            Process.Start("explorer.exe");
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkbox = checkBox1.Checked ? "True" : "False";
            Properties.Settings.Default.textbox1 = textBox1.Text;
            Properties.Settings.Default.textbox2 = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLanguage = languageComboBox.SelectedItem.ToString();
            UpdateLanguage();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SwitchPanel(settingsPanel);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SwitchPanel(richPresencePanel);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SwitchPanel(botPanel);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SwitchPanel(dllPanel);
        }

        private async void RpcButton1_Click(object sender, EventArgs e)
        {
            if (rpcClient != null && rpcClient.IsInitialized)
            {
                MessageBox.Show(translations[currentLanguage]["msgRPCRunning"]);
                return;
            }

            string appId = rpcTextBox1.Text?.Trim();
            if (string.IsNullOrEmpty(appId))
            {
                MessageBox.Show(translations[currentLanguage]["msgEnterAppId"]);
                return;
            }

            try
            {
                rpcClient = new DiscordRPC.DiscordRpcClient(appId);

                rpcClient.OnReady += (s, ea) =>
                {
                    this.BeginInvoke((Action)(() => MessageBox.Show(translations[currentLanguage]["msgRPCConnected"])));
                };

                rpcClient.OnError += (s, ea) =>
                {
                    this.BeginInvoke((Action)(() => MessageBox.Show(
                        string.Format(translations[currentLanguage]["msgRPCError"], ea.Message))));
                };

                rpcClient.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(translations[currentLanguage]["msgRPCError"], ex.Message));
                rpcClient = null;
                return;
            }

            try
            {
                rpcClient.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = rpcTextBox4.Text,
                    State = rpcTextBox2.Text,
                    Assets = new DiscordRPC.Assets()
                    {
                        LargeImageKey = rpcTextBox5.Text,
                        LargeImageText = rpcTextBox3.Text,
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(translations[currentLanguage]["msgRPCError"], ex.Message));
            }

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            await Task.Run(() =>
            {
                try
                {
                    while (!token.IsCancellationRequested && rpcClient != null && rpcClient.IsInitialized)
                    {
                        try
                        {
                            rpcClient.Invoke();
                        }
                        catch
                        {
                        }
                        Thread.Sleep(1000);
                    }
                }
                catch (OperationCanceledException) { }
            }, token);
        }

        private void RpcLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(translations[currentLanguage]["msgRPCHelp"]);
        }

        private void BotButton1_Click(object sender, EventArgs e)
        {
            string scriptPath = null;

            Thread t = new Thread(() =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                {
                    Title = "Select Python bot file",
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

            bool likelyDiscordBot = false;
            try
            {
                string content = File.ReadAllText(scriptPath, System.Text.Encoding.UTF8).ToLowerInvariant();
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
                MessageBox.Show($"Error reading file: {ex.Message}");
                return;
            }

            if (likelyDiscordBot)
            {
                if (MessageBox.Show("Found Discord bot code. Do you want to run it?",
                                    "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
            else
            {
                if (MessageBox.Show("This doesn't appear to be a Discord bot. Run anyway?",
                                    "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            StartPythonScript(scriptPath);
        }

        private void StartPythonScript(string scriptPath)
        {
            string pythonExe = "python";
            
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

            try
            {
                Process proc = Process.Start(psi);
                MessageBox.Show($"Bot started successfully! (PID: {proc.Id})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting bot: {ex.Message}");
            }
        }

        private void DllButton1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a DLL";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    [DllImport("kernel32.dll")]
                    static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

                    [DllImport("kernel32.dll")]
                    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

                    [DllImport("kernel32.dll")]
                    static extern IntPtr GetModuleHandle(string lpModuleName);

                    string dllPath = openFileDialog.FileName;
                    Process targetProcess = Process.GetProcessesByName("Discord")[0];

                    IntPtr hProcess = OpenProcess(0x001F0FFF, false, targetProcess.Id);
                    IntPtr addr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPath.Length + 1, 0x1000 | 0x2000, 0x40);
                    WriteProcessMemory(hProcess, addr, System.Text.Encoding.Default.GetBytes(dllPath), (uint)dllPath.Length + 1, out _);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, addr, 0, out _);
                    
                    MessageBox.Show("DLL injected successfully!");
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
