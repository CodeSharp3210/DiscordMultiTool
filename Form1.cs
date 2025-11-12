using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace DiscordMultiTool
{
    public partial class Form1 : Form
    {
        private string currentLanguage = "English";
        private Dictionary<string, Dictionary<string, string>> translations;
        private Timer fadeTimer;
        private Timer highlightTimer;
        private Panel currentPanel;
        private int highlightTargetY = 496;
        private bool isModernTheme = false;
        private bool _telegramDiagnosticsShown = false;

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



        private void Button11_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                highlightPanel.BackColor = colorDialog.Color;
                button1.ForeColor = colorDialog.Color;
                button2.ForeColor = colorDialog.Color;
                button3.ForeColor = colorDialog.Color;
                button4.ForeColor = colorDialog.Color;
                button5.ForeColor = colorDialog.Color;
                button6.ForeColor = Color.Red;
                button7.ForeColor = Color.Red;
                button8.ForeColor = colorDialog.Color;
                btnSettings.ForeColor = colorDialog.Color;
                label1.ForeColor = colorDialog.Color;
                label2.ForeColor = colorDialog.Color;
                label3.ForeColor = colorDialog.Color;
                label4.ForeColor = colorDialog.Color;
                label5.ForeColor = colorDialog.Color;
                lblLanguage.ForeColor = colorDialog.Color;
                checkBox1.ForeColor = colorDialog.Color;
                button10.ForeColor = colorDialog.Color;
                button11.ForeColor = colorDialog.Color;

                var outlineColor = Color.Silver;
                int radiusSmall = 10;
                int radiusLarge = 15;

                ConfigureButtonOutline(button1, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button2, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button3, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button4, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button5, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button8, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(btnSettings, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button10, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(button11, colorDialog.Color, radiusSmall);
                ConfigureButtonOutline(rpcButton1, Color.Silver, radiusSmall);
                ConfigureButtonOutline(botButton1, Color.Silver, radiusSmall);
                ConfigureButtonOutline(dllButton1, Color.Silver, radiusSmall);
            }
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
                    ["button8"] = "Telegram Features",
                    ["btnSettings"] = "⚙ Settings",
                    ["button10"] = "Change Theme",
                    ["button11"] = "Color GUI",
                    ["label3"] = "Discord Account",
                    ["label4"] = "Target Server",
                    ["label5"] = "Save Settings",
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
                    ["button4"] = "Innietta DLL",
                    ["button5"] = "Connessione Discord",
                    ["button6"] = "Esci dall'Applicazione",
                    ["button7"] = "Chiudi Discord",
                    ["button8"] = "Funzionalità Telegram",
                    ["btnSettings"] = "⚙ Impostazioni",
                    ["button10"] = "Cambia Tema",
                    ["button11"] = "Colore GUI",
                    ["label3"] = "Account Discord",
                    ["label4"] = "Server Target",
                    ["label5"] = "Salva Impostazioni",
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
                    ["dllLabel1"] = "Inietta una DLL personalizzata nel processo Discord.\nCiò ti permette di modificare il processo remoto di Discord.",
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

            button10.Text = lang["button10"];
            button11.Text = lang["button11"];
            label3.Text = lang["label3"];
            label4.Text = lang["label4"];
            label5.Text = lang["label5"];
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

            var outlineColor = Color.Silver;
            int radiusSmall = 10;
            int radiusLarge = 15;

            ConfigureButtonOutline(button1, outlineColor, radiusSmall);
            ConfigureButtonOutline(button2, outlineColor, radiusSmall);
            ConfigureButtonOutline(button3, outlineColor, radiusSmall);
            ConfigureButtonOutline(button4, outlineColor, radiusSmall);
            ConfigureButtonOutline(button5, outlineColor, radiusSmall);
            ConfigureButtonOutline(button6, Color.Red, radiusSmall);
            ConfigureButtonOutline(button7, Color.Red, radiusSmall);
            ConfigureButtonOutline(button8, outlineColor, radiusSmall);
            ConfigureButtonOutline(btnSettings, outlineColor, radiusSmall);
            ConfigureButtonOutline(button10, outlineColor, radiusSmall);
            ConfigureButtonOutline(button11, outlineColor, radiusSmall);
            ConfigureButtonOutline(rpcButton1, outlineColor, radiusSmall);
            ConfigureButtonOutline(botButton1, outlineColor, radiusSmall);
            ConfigureButtonOutline(dllButton1, outlineColor, radiusSmall);

            checkBox1.Checked = (Properties.Settings.Default.checkbox == "True");

            if (checkBox1.Checked)
            {
                textBox1.Text = Properties.Settings.Default.textbox1;
                textBox2.Text = Properties.Settings.Default.textbox2;

                if (Properties.Settings.Default.tema == "Modern")
                {
                    isModernTheme = true;
                    button10.Text = translations[currentLanguage]["button10"] + ": Classic";
                    ApplyModernTheme();
                }
                else if (Properties.Settings.Default.tema == "Classic")
                {
                    isModernTheme = false;
                    button10.Text = translations[currentLanguage]["button10"] + ": Modern";
                    ApplyClassicTheme();
                }
            }

            Process processo = Process.GetCurrentProcess();
            string nomeProcesso = processo.ProcessName;

            string cartella = @"C:\Users\" + Environment.UserName + @"\.dmt";
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
            isModernTheme = true;
            this.BackColor = SystemColors.Control;
            leftPanel.BackColor = Color.FromArgb(240, 240, 240);
            contentPanel.BackColor = Color.White;
            settingsPanel.BackColor = Color.White;
            richPresencePanel.BackColor = Color.White;
            botPanel.BackColor = Color.White;
            dllPanel.BackColor = Color.White;
            telegramPanel.BackColor = Color.White;

            Color textColor = Color.Black;
            button1.ForeColor = textColor;
            button2.ForeColor = textColor;
            button3.ForeColor = textColor;
            button4.ForeColor = textColor;
            button5.ForeColor = textColor;
            button8.ForeColor = textColor;
            btnSettings.ForeColor = textColor;
            label1.ForeColor = Color.Gray;
            label2.ForeColor = Color.Silver;
            label3.ForeColor = textColor;
            label4.ForeColor = textColor;
            label5.ForeColor = textColor;
            lblLanguage.ForeColor = textColor;
            checkBox1.ForeColor = textColor;
            // button9 removed
            button10.ForeColor = textColor;
            button11.ForeColor = textColor;
            rpcLabel1.ForeColor = Color.Gray;
            rpcLabel2.ForeColor = Color.Gray;
            rpcLabel3.ForeColor = Color.Gray;
            rpcLabel4.ForeColor = Color.Gray;
            rpcLabel5.ForeColor = Color.Gray;
            botLabel1.ForeColor = textColor;
            dllLabel1.ForeColor = textColor;
            telegramPanel.BackColor = Color.FromArgb(47, 49, 54);
        }

        private void ApplyClassicTheme()
        {
            isModernTheme = false;
            this.BackColor = Color.FromArgb(54, 57, 63);
            leftPanel.BackColor = Color.FromArgb(32, 34, 37);
            contentPanel.BackColor = Color.FromArgb(47, 49, 54);
            settingsPanel.BackColor = Color.FromArgb(47, 49, 54);
            richPresencePanel.BackColor = Color.FromArgb(47, 49, 54);
            botPanel.BackColor = Color.FromArgb(47, 49, 54);
            dllPanel.BackColor = Color.FromArgb(47, 49, 54);
            telegramPanel.BackColor = Color.FromArgb(47, 49, 54);

            Color textColor = Color.White;
            button1.ForeColor = textColor;
            button2.ForeColor = textColor;
            button3.ForeColor = textColor;
            button4.ForeColor = textColor;
            button5.ForeColor = textColor;
            button8.ForeColor = textColor;
            btnSettings.ForeColor = textColor;
            label1.ForeColor = Color.FromArgb(142, 146, 151);
            label2.ForeColor = Color.FromArgb(142, 146, 151);
            label3.ForeColor = textColor;
            label4.ForeColor = textColor;
            label5.ForeColor = textColor;
            lblLanguage.ForeColor = textColor;
            checkBox1.ForeColor = textColor;
            button10.ForeColor = textColor;
            button11.ForeColor = textColor;
            rpcLabel1.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel2.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel3.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel4.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel5.ForeColor = Color.FromArgb(142, 146, 151);
            botLabel1.ForeColor = textColor;
            dllLabel1.ForeColor = textColor;
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

        // Recursively apply theme colors to a control and its children
        private void ApplyThemeToControl(Control root, bool modern)
        {
            Color fg = modern ? Color.Black : Color.White;
            Color tbBack = modern ? Color.White : Color.FromArgb(60, 63, 68);
            Color btnBack = modern ? SystemColors.Control : Color.FromArgb(70, 73, 78);

            void Walk(Control c)
            {
                try
                {
                    c.ForeColor = fg;
                    if (c is TextBox t)
                    {
                        t.BackColor = tbBack;
                        t.ForeColor = fg;
                    }
                    if (c is Button b)
                    {
                        b.BackColor = btnBack;
                        b.ForeColor = fg;
                    }
                }
                catch { }

                foreach (Control child in c.Controls)
                    Walk(child);
            }

            Walk(root);
            try { root.Refresh(); } catch { }
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

        private void AnimateHighlight(int targetY)
        {
            highlightTargetY = targetY;

            if (highlightTimer != null)
            {
                highlightTimer.Stop();
                highlightTimer.Dispose();
            }

            highlightTimer = new Timer();
            highlightTimer.Interval = 10;

            highlightTimer.Tick += (s, e) =>
            {
                int currentY = highlightPanel.Location.Y;
                int distance = highlightTargetY - currentY;

                if (Math.Abs(distance) < 2)
                {
                    highlightPanel.Location = new Point(8, highlightTargetY);
                    highlightTimer.Stop();
                    highlightTimer.Dispose();
                }
                else
                {
                    int newY = currentY + distance / 5;
                    highlightPanel.Location = new Point(8, newY);
                }
            };

            highlightTimer.Start();
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


        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (telegramPanel.Controls.Count == 0)
                {
                    Form f5 = new Form5();
                    f5.TopLevel = false;
                    f5.FormBorderStyle = FormBorderStyle.None;
                    f5.Dock = DockStyle.Fill;

                    telegramPanel.Controls.Add(f5);

                    ApplyThemeToControl(f5, isModernTheme);
                    f5.Show();
                }

                SwitchPanel(telegramPanel);
                AnimateHighlight(300);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Telegram Features: " + ex.Message);
            }
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

        

        private void Button10_Click(object sender, EventArgs e)
        {
            // Toggle theme between Modern and Classic
            if (isModernTheme)
            {
                // currently modern -> switch to classic
                isModernTheme = false;
                button10.Text = translations[currentLanguage]["button10"] + ": Modern";
                ApplyClassicTheme();
                Properties.Settings.Default.tema = "Classic";
            }
            else
            {
                // currently classic -> switch to modern
                isModernTheme = true;
                button10.Text = translations[currentLanguage]["button10"] + ": Classic";
                ApplyModernTheme();
                Properties.Settings.Default.tema = "Modern";
            }
            Properties.Settings.Default.Save();
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
            AnimateHighlight(496);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SwitchPanel(richPresencePanel);
            AnimateHighlight(20);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SwitchPanel(botPanel);
            AnimateHighlight(76);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SwitchPanel(dllPanel);
            AnimateHighlight(132);
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
