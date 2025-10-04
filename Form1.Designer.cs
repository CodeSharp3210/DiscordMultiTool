namespace DiscordMultiTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            
            this.leftPanel = new System.Windows.Forms.Panel();
            this.highlightPanel = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            
            this.contentPanel = new System.Windows.Forms.Panel();
            
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            
            this.richPresencePanel = new System.Windows.Forms.Panel();
            this.rpcButton1 = new System.Windows.Forms.Button();
            this.rpcTextBox1 = new System.Windows.Forms.TextBox();
            this.rpcTextBox2 = new System.Windows.Forms.TextBox();
            this.rpcTextBox3 = new System.Windows.Forms.TextBox();
            this.rpcTextBox4 = new System.Windows.Forms.TextBox();
            this.rpcTextBox5 = new System.Windows.Forms.TextBox();
            this.rpcLinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.rpcLabel1 = new System.Windows.Forms.Label();
            this.rpcLabel2 = new System.Windows.Forms.Label();
            this.rpcLabel3 = new System.Windows.Forms.Label();
            this.rpcLabel4 = new System.Windows.Forms.Label();
            this.rpcLabel5 = new System.Windows.Forms.Label();
            
            this.botPanel = new System.Windows.Forms.Panel();
            this.botButton1 = new System.Windows.Forms.Button();
            this.botLabel1 = new System.Windows.Forms.Label();
            
            this.dllPanel = new System.Windows.Forms.Panel();
            this.dllButton1 = new System.Windows.Forms.Button();
            this.dllLabel1 = new System.Windows.Forms.Label();
            
            this.leftPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.richPresencePanel.SuspendLayout();
            this.botPanel.SuspendLayout();
            this.dllPanel.SuspendLayout();
            this.SuspendLayout();
            
            // leftPanel
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);
            this.leftPanel.Controls.Add(this.highlightPanel);
            this.leftPanel.Controls.Add(this.button1);
            this.leftPanel.Controls.Add(this.button2);
            this.leftPanel.Controls.Add(this.button4);
            this.leftPanel.Controls.Add(this.button5);
            this.leftPanel.Controls.Add(this.button3);
            this.leftPanel.Controls.Add(this.button8);
            this.leftPanel.Controls.Add(this.button7);
            this.leftPanel.Controls.Add(this.button6);
            this.leftPanel.Controls.Add(this.btnSettings);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(280, 720);
            this.leftPanel.TabIndex = 0;
            
            // highlightPanel
            this.highlightPanel.BackColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.highlightPanel.Location = new System.Drawing.Point(8, 496);
            this.highlightPanel.Name = "highlightPanel";
            this.highlightPanel.Size = new System.Drawing.Size(4, 50);
            this.highlightPanel.TabIndex = 100;
            
            // button1
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Discord Rich Presence";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button2
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Discord Bot (Python)";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            this.button2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button4
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(256, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "Inject DLL";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            this.button4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button5
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 188);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(256, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "Discord Connection";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            this.button5.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button3
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Developer Portal";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            this.button3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button8
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(12, 300);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(256, 50);
            this.button8.TabIndex = 7;
            this.button8.Text = "Misc Tools";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            this.button8.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button7
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.FromArgb(240, 71, 71);
            this.button7.Location = new System.Drawing.Point(12, 370);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(256, 50);
            this.button7.TabIndex = 6;
            this.button7.Text = "Close Discord";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            this.button7.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // button6
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(240, 71, 71);
            this.button6.Location = new System.Drawing.Point(12, 426);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(256, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "Exit Application";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            this.button6.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // btnSettings
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(12, 496);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(256, 50);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "⚙ Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            this.btnSettings.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 256, 50, 10, 10));
            
            // label1
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.label1.Location = new System.Drawing.Point(12, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 60);
            this.label1.TabIndex = 9;
            this.label1.Text = "DiscordMultiTool v1.1.0\nMasterSharp Team LLC.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(47, 49, 54);
            this.contentPanel.Controls.Add(this.settingsPanel);
            this.contentPanel.Controls.Add(this.richPresencePanel);
            this.contentPanel.Controls.Add(this.botPanel);
            this.contentPanel.Controls.Add(this.dllPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(280, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(920, 720);
            this.contentPanel.TabIndex = 1;
            
            // settingsPanel
            this.settingsPanel.BackColor = System.Drawing.Color.FromArgb(47, 49, 54);
            this.settingsPanel.Controls.Add(this.languageComboBox);
            this.settingsPanel.Controls.Add(this.lblLanguage);
            this.settingsPanel.Controls.Add(this.checkBox1);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.textBox2);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.textBox1);
            this.settingsPanel.Controls.Add(this.button11);
            this.settingsPanel.Controls.Add(this.button10);
            this.settingsPanel.Controls.Add(this.button9);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(920, 720);
            this.settingsPanel.TabIndex = 0;
            
            // languageComboBox
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] { "English", "Italiano" });
            this.languageComboBox.Location = new System.Drawing.Point(180, 360);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(200, 28);
            this.languageComboBox.TabIndex = 10;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            
            // lblLanguage
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLanguage.ForeColor = System.Drawing.Color.White;
            this.lblLanguage.Location = new System.Drawing.Point(50, 363);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(80, 21);
            this.lblLanguage.TabIndex = 9;
            this.lblLanguage.Text = "Language";
            
            // checkBox1
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(560, 248);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 23);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Auto Save Settings";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            
            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(420, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Save Settings";
            
            // textBox2
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.Location = new System.Drawing.Point(560, 150);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 27);
            this.textBox2.TabIndex = 6;
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(420, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Target Server";
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(420, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Discord Account";
            
            // textBox1
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.Location = new System.Drawing.Point(560, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 27);
            this.textBox1.TabIndex = 3;
            
            // button11
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.button11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(50, 250);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(280, 45);
            this.button11.TabIndex = 2;
            this.button11.Text = "Apply Discord Patch";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            this.button11.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 280, 45, 10, 10));
            
            // button10
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.button10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(50, 150);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(280, 45);
            this.button10.TabIndex = 1;
            this.button10.Text = "Change Theme";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            this.button10.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 280, 45, 10, 10));
            
            // button9
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.button9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(50, 50);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(280, 45);
            this.button9.TabIndex = 0;
            this.button9.Text = "Customize Colors";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            this.button9.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 280, 45, 10, 10));
            
            // richPresencePanel
            this.richPresencePanel.BackColor = System.Drawing.Color.FromArgb(47, 49, 54);
            this.richPresencePanel.Controls.Add(this.rpcLabel1);
            this.richPresencePanel.Controls.Add(this.rpcLabel2);
            this.richPresencePanel.Controls.Add(this.rpcLabel3);
            this.richPresencePanel.Controls.Add(this.rpcLabel4);
            this.richPresencePanel.Controls.Add(this.rpcLabel5);
            this.richPresencePanel.Controls.Add(this.rpcTextBox5);
            this.richPresencePanel.Controls.Add(this.rpcLinkLabel1);
            this.richPresencePanel.Controls.Add(this.rpcTextBox4);
            this.richPresencePanel.Controls.Add(this.rpcTextBox3);
            this.richPresencePanel.Controls.Add(this.rpcTextBox2);
            this.richPresencePanel.Controls.Add(this.rpcTextBox1);
            this.richPresencePanel.Controls.Add(this.rpcButton1);
            this.richPresencePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richPresencePanel.Location = new System.Drawing.Point(0, 0);
            this.richPresencePanel.Name = "richPresencePanel";
            this.richPresencePanel.Size = new System.Drawing.Size(920, 720);
            this.richPresencePanel.TabIndex = 1;
            this.richPresencePanel.Visible = false;
            
            // rpcLabel1
            this.rpcLabel1.AutoSize = true;
            this.rpcLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLabel1.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.rpcLabel1.Location = new System.Drawing.Point(80, 80);
            this.rpcLabel1.Name = "rpcLabel1";
            this.rpcLabel1.Size = new System.Drawing.Size(105, 20);
            this.rpcLabel1.TabIndex = 11;
            this.rpcLabel1.Text = "Application ID";
            
            // rpcLabel2
            this.rpcLabel2.AutoSize = true;
            this.rpcLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLabel2.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.rpcLabel2.Location = new System.Drawing.Point(80, 160);
            this.rpcLabel2.Name = "rpcLabel2";
            this.rpcLabel2.Size = new System.Drawing.Size(41, 20);
            this.rpcLabel2.TabIndex = 12;
            this.rpcLabel2.Text = "State";
            
            // rpcLabel3
            this.rpcLabel3.AutoSize = true;
            this.rpcLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLabel3.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.rpcLabel3.Location = new System.Drawing.Point(80, 240);
            this.rpcLabel3.Name = "rpcLabel3";
            this.rpcLabel3.Size = new System.Drawing.Size(85, 20);
            this.rpcLabel3.TabIndex = 13;
            this.rpcLabel3.Text = "Image Text";
            
            // rpcLabel4
            this.rpcLabel4.AutoSize = true;
            this.rpcLabel4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLabel4.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.rpcLabel4.Location = new System.Drawing.Point(80, 320);
            this.rpcLabel4.Name = "rpcLabel4";
            this.rpcLabel4.Size = new System.Drawing.Size(58, 20);
            this.rpcLabel4.TabIndex = 14;
            this.rpcLabel4.Text = "Details";
            
            // rpcLabel5
            this.rpcLabel5.AutoSize = true;
            this.rpcLabel5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLabel5.ForeColor = System.Drawing.Color.FromArgb(142, 146, 151);
            this.rpcLabel5.Location = new System.Drawing.Point(80, 400);
            this.rpcLabel5.Name = "rpcLabel5";
            this.rpcLabel5.Size = new System.Drawing.Size(92, 20);
            this.rpcLabel5.TabIndex = 15;
            this.rpcLabel5.Text = "Image Name";
            
            // rpcButton1
            this.rpcButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rpcButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.rpcButton1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.rpcButton1.ForeColor = System.Drawing.Color.White;
            this.rpcButton1.Location = new System.Drawing.Point(280, 500);
            this.rpcButton1.Name = "rpcButton1";
            this.rpcButton1.Size = new System.Drawing.Size(360, 55);
            this.rpcButton1.TabIndex = 2;
            this.rpcButton1.Text = "Load Discord RPC";
            this.rpcButton1.UseVisualStyleBackColor = false;
            this.rpcButton1.Click += new System.EventHandler(this.RpcButton1_Click);
            this.rpcButton1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 360, 55, 15, 15));
            
            // rpcTextBox1
            this.rpcTextBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcTextBox1.Location = new System.Drawing.Point(80, 110);
            this.rpcTextBox1.Name = "rpcTextBox1";
            this.rpcTextBox1.Size = new System.Drawing.Size(760, 27);
            this.rpcTextBox1.TabIndex = 3;
            this.rpcTextBox1.Text = "";
            
            // rpcTextBox2
            this.rpcTextBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcTextBox2.Location = new System.Drawing.Point(80, 190);
            this.rpcTextBox2.Name = "rpcTextBox2";
            this.rpcTextBox2.Size = new System.Drawing.Size(760, 27);
            this.rpcTextBox2.TabIndex = 4;
            this.rpcTextBox2.Text = "";
            
            // rpcTextBox3
            this.rpcTextBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcTextBox3.Location = new System.Drawing.Point(80, 270);
            this.rpcTextBox3.Name = "rpcTextBox3";
            this.rpcTextBox3.Size = new System.Drawing.Size(760, 27);
            this.rpcTextBox3.TabIndex = 5;
            this.rpcTextBox3.Text = "";
            
            // rpcTextBox4
            this.rpcTextBox4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcTextBox4.Location = new System.Drawing.Point(80, 350);
            this.rpcTextBox4.Name = "rpcTextBox4";
            this.rpcTextBox4.Size = new System.Drawing.Size(760, 27);
            this.rpcTextBox4.TabIndex = 6;
            this.rpcTextBox4.Text = "";
            
            // rpcTextBox5
            this.rpcTextBox5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcTextBox5.Location = new System.Drawing.Point(80, 430);
            this.rpcTextBox5.Name = "rpcTextBox5";
            this.rpcTextBox5.Size = new System.Drawing.Size(760, 27);
            this.rpcTextBox5.TabIndex = 8;
            this.rpcTextBox5.Text = "";
            
            // rpcLinkLabel1
            this.rpcLinkLabel1.AutoSize = true;
            this.rpcLinkLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rpcLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.rpcLinkLabel1.Location = new System.Drawing.Point(80, 590);
            this.rpcLinkLabel1.Name = "rpcLinkLabel1";
            this.rpcLinkLabel1.Size = new System.Drawing.Size(40, 20);
            this.rpcLinkLabel1.TabIndex = 7;
            this.rpcLinkLabel1.TabStop = true;
            this.rpcLinkLabel1.Text = "Help";
            this.rpcLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.rpcLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RpcLinkLabel1_LinkClicked);
            
            // botPanel
            this.botPanel.BackColor = System.Drawing.Color.FromArgb(47, 49, 54);
            this.botPanel.Controls.Add(this.botLabel1);
            this.botPanel.Controls.Add(this.botButton1);
            this.botPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botPanel.Location = new System.Drawing.Point(0, 0);
            this.botPanel.Name = "botPanel";
            this.botPanel.Size = new System.Drawing.Size(920, 720);
            this.botPanel.TabIndex = 2;
            this.botPanel.Visible = false;
            
            // botLabel1
            this.botLabel1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.botLabel1.ForeColor = System.Drawing.Color.White;
            this.botLabel1.Location = new System.Drawing.Point(100, 100);
            this.botLabel1.Name = "botLabel1";
            this.botLabel1.Size = new System.Drawing.Size(720, 100);
            this.botLabel1.TabIndex = 1;
            this.botLabel1.Text = "Load your Discord Bot written in Python.\nThis tool will check for Python, install dependencies if needed,\nand run your bot in the background.";
            this.botLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // botButton1
            this.botButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.botButton1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.botButton1.ForeColor = System.Drawing.Color.White;
            this.botButton1.Location = new System.Drawing.Point(280, 300);
            this.botButton1.Name = "botButton1";
            this.botButton1.Size = new System.Drawing.Size(360, 55);
            this.botButton1.TabIndex = 0;
            this.botButton1.Text = "Select Bot File";
            this.botButton1.UseVisualStyleBackColor = false;
            this.botButton1.Click += new System.EventHandler(this.BotButton1_Click);
            this.botButton1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 360, 55, 15, 15));
            
            // dllPanel
            this.dllPanel.BackColor = System.Drawing.Color.FromArgb(47, 49, 54);
            this.dllPanel.Controls.Add(this.dllLabel1);
            this.dllPanel.Controls.Add(this.dllButton1);
            this.dllPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dllPanel.Location = new System.Drawing.Point(0, 0);
            this.dllPanel.Name = "dllPanel";
            this.dllPanel.Size = new System.Drawing.Size(920, 720);
            this.dllPanel.TabIndex = 3;
            this.dllPanel.Visible = false;
            
            // dllLabel1
            this.dllLabel1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.dllLabel1.ForeColor = System.Drawing.Color.White;
            this.dllLabel1.Location = new System.Drawing.Point(100, 100);
            this.dllLabel1.Name = "dllLabel1";
            this.dllLabel1.Size = new System.Drawing.Size(720, 100);
            this.dllLabel1.TabIndex = 1;
            this.dllLabel1.Text = "Inject a custom DLL into the Discord process.\nThis allows you to modify Discord's behavior.";
            this.dllLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // dllButton1
            this.dllButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dllButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(114, 137, 218);
            this.dllButton1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.dllButton1.ForeColor = System.Drawing.Color.White;
            this.dllButton1.Location = new System.Drawing.Point(280, 300);
            this.dllButton1.Name = "dllButton1";
            this.dllButton1.Size = new System.Drawing.Size(360, 55);
            this.dllButton1.TabIndex = 0;
            this.dllButton1.Text = "Select DLL File";
            this.dllButton1.UseVisualStyleBackColor = false;
            this.dllButton1.Click += new System.EventHandler(this.DllButton1_Click);
            this.dllButton1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 360, 55, 15, 15));
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(54, 57, 63);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord MultiTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.leftPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.richPresencePanel.ResumeLayout(false);
            this.richPresencePanel.PerformLayout();
            this.botPanel.ResumeLayout(false);
            this.dllPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel highlightPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        
        private System.Windows.Forms.Panel richPresencePanel;
        private System.Windows.Forms.Button rpcButton1;
        private System.Windows.Forms.TextBox rpcTextBox1;
        private System.Windows.Forms.TextBox rpcTextBox2;
        private System.Windows.Forms.TextBox rpcTextBox3;
        private System.Windows.Forms.TextBox rpcTextBox4;
        private System.Windows.Forms.TextBox rpcTextBox5;
        private System.Windows.Forms.LinkLabel rpcLinkLabel1;
        private System.Windows.Forms.Label rpcLabel1;
        private System.Windows.Forms.Label rpcLabel2;
        private System.Windows.Forms.Label rpcLabel3;
        private System.Windows.Forms.Label rpcLabel4;
        private System.Windows.Forms.Label rpcLabel5;
        
        private System.Windows.Forms.Panel botPanel;
        private System.Windows.Forms.Button botButton1;
        private System.Windows.Forms.Label botLabel1;
        
        private System.Windows.Forms.Panel dllPanel;
        private System.Windows.Forms.Button dllButton1;
        private System.Windows.Forms.Label dllLabel1;
    }
}
