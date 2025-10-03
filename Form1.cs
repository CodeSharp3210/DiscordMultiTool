using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO;

namespace DiscordMultiTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing; // salva tutto alla chiusura
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = (Properties.Settings.Default.checkbox == "True");

            if (checkBox1.Checked)
            {
                // Textbox
                textBox1.Text = Properties.Settings.Default.textbox1;
                textBox2.Text = Properties.Settings.Default.textbox2;

                // Tema
                if (Properties.Settings.Default.tema == "Modern")
                {
                    button10.Text = "Change Theme: Classic";
                    this.BackColor = SystemColors.Control;
                    tabControl1.BackColor = SystemColors.Control;
                    tabPage1.BackColor = Color.White;
                    button1.BackColor = SystemColors.Control;
                    button2.BackColor = SystemColors.Control;
                    button3.BackColor = SystemColors.Control;
                    button4.BackColor = SystemColors.Control;
                    button5.BackColor = SystemColors.Control;
                    button6.BackColor = SystemColors.Control;
                    button7.BackColor = SystemColors.Control;
                    button8.BackColor = SystemColors.Control;
                    button9.BackColor = SystemColors.Control;
                    button10.BackColor = SystemColors.Control;
                    label1.BackColor = SystemColors.Control;
                    label2.BackColor = SystemColors.Control;
                    button11.BackColor = SystemColors.Control;
                }
                else if (Properties.Settings.Default.tema == "Classic")
                {
                    button10.Text = "Change Theme: Modern";
                    this.BackColor = Color.FromArgb(54, 57, 63);
                    tabControl1.BackColor = Color.FromArgb(47, 49, 54);
                    tabPage1.BackColor = Color.FromArgb(47, 49, 54);
                    button1.BackColor = Color.FromArgb(54, 57, 63);
                    button2.BackColor = Color.FromArgb(54, 57, 63);
                    button3.BackColor = Color.FromArgb(54, 57, 63);
                    button4.BackColor = Color.FromArgb(54, 57, 63);
                    button5.BackColor = Color.FromArgb(54, 57, 63);
                    button6.BackColor = Color.FromArgb(54, 57, 63);
                    button7.BackColor = Color.FromArgb(54, 57, 63);
                    button8.BackColor = Color.FromArgb(54, 57, 63);
                    button9.BackColor = Color.FromArgb(54, 57, 63);
                    button10.BackColor = Color.FromArgb(54, 57, 63);
                    label1.BackColor = Color.FromArgb(54, 57, 63);
                    label2.BackColor = Color.FromArgb(54, 57, 63);
                    button11.BackColor = Color.FromArgb(54, 57, 63);
                }
            }
            // Info processo
            Process processo = Process.GetCurrentProcess();
            string nomeProcesso = processo.ProcessName;
            label1.Text = $"Discord Multi Tool V1.0.0\nThis Process: {nomeProcesso}\nDiscordMultiTool/MASTER\nTranslated by itelcan3\nhttps://github.com/CodeSharp3210";

            // Cartella log
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
        }

        // Salvataggio dati quando chiudi l'app
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.checkbox = checkBox1.Checked ? "True" : "False";
            Properties.Settings.Default.textbox1 = textBox1.Text;
            Properties.Settings.Default.textbox2 = textBox2.Text;

            if (button10.Text == "Change Theme: Classic")
                Properties.Settings.Default.tema = "Modern";
            else
                Properties.Settings.Default.tema = "Classic";

            Properties.Settings.Default.Save();
        }

        // GUI & impostazioni programma
        private void Button9_Click(object sender, EventArgs e)
        {
            ColorDialog COLORGUI = new ColorDialog();
            if (COLORGUI.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = COLORGUI.Color;
                label1.ForeColor = COLORGUI.Color;
                label2.ForeColor = COLORGUI.Color;
                button1.ForeColor = COLORGUI.Color;
                button2.ForeColor = COLORGUI.Color;
                button3.ForeColor = COLORGUI.Color;
                button4.ForeColor = COLORGUI.Color;
                button5.ForeColor = COLORGUI.Color;
                button6.ForeColor = COLORGUI.Color;
                button7.ForeColor = COLORGUI.Color;
                button8.ForeColor = COLORGUI.Color;
                tabControl1.ForeColor = COLORGUI.Color;
                tabPage1.ForeColor = COLORGUI.Color;
                button11.ForeColor = COLORGUI.Color;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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
            if (button10.Text == "Change Theme: Classic")
            {
                button10.Text = "Change Theme: Modern";
                this.BackColor = Color.FromArgb(54, 57, 63);
                tabControl1.BackColor = Color.FromArgb(47, 49, 54);
                tabPage1.BackColor = Color.FromArgb(47, 49, 54);
                button1.BackColor = Color.FromArgb(54, 57, 63);
                button2.BackColor = Color.FromArgb(54, 57, 63);
                button3.BackColor = Color.FromArgb(54, 57, 63);
                button4.BackColor = Color.FromArgb(54, 57, 63);
                button5.BackColor = Color.FromArgb(54, 57, 63);
                button6.BackColor = Color.FromArgb(54, 57, 63);
                button7.BackColor = Color.FromArgb(54, 57, 63);
                button8.BackColor = Color.FromArgb(54, 57, 63);
                button9.BackColor = Color.FromArgb(54, 57, 63);
                button10.BackColor = Color.FromArgb(54, 57, 63);
                label1.BackColor = Color.FromArgb(54, 57, 63);
                label2.BackColor = Color.FromArgb(54, 57, 63);
                button11.BackColor = Color.FromArgb(54, 57, 63);
                Properties.Settings.Default.tema = "Modern";
                Properties.Settings.Default.Save();
            }
            else if (button10.Text == "Change Theme: Modern")
            {
                button10.Text = "Change Theme: Classic";
                this.BackColor = SystemColors.Control;
                tabControl1.BackColor = SystemColors.Control;
                tabPage1.BackColor = Color.White;
                button1.BackColor = SystemColors.Control;
                button2.BackColor = SystemColors.Control;
                button3.BackColor = SystemColors.Control;
                button4.BackColor = SystemColors.Control;
                button5.BackColor = SystemColors.Control;
                button6.BackColor = SystemColors.Control;
                button7.BackColor = SystemColors.Control;
                button8.BackColor = SystemColors.Control;
                button9.BackColor = SystemColors.Control;
                button10.BackColor = SystemColors.Control;
                label1.BackColor = SystemColors.Control;
                label2.BackColor = SystemColors.Control;
                button11.BackColor = SystemColors.Control;
                Properties.Settings.Default.tema = "Classic";
                Properties.Settings.Default.Save();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Telegram Features is in currently development.\nPlss follow me on GitHub to have last updates");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Process[] ProcessoDiscord = Process.GetProcessesByName("Discord");
            if (ProcessoDiscord.Length > 0)
            {
                string discordID = ProcessoDiscord[0].Id.ToString();
                MessageBox.Show($"Discord Multi Tool is already connected with your Discord Client\nProcess Name: {ProcessoDiscord[0].ProcessName}\nProcess PID: {discordID}");
            }
            else
            {
                MessageBox.Show("No running Discord process was found.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
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
    }
}
