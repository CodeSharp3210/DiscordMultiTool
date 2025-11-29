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
            leftPanel = new Panel();
            pictureBox1 = new PictureBox();
            highlightPanel = new Panel();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            button5 = new Button();
            button3 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            btnSettings = new Button();
            label1 = new Label();
            contentPanel = new Panel();
            settingsPanel = new Panel();
            label7 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            languageComboBox = new ComboBox();
            lblLanguage = new Label();
            checkBox1 = new CheckBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button11 = new Button();
            button10 = new Button();
            richPresencePanel = new Panel();
            rpcLabel1 = new Label();
            rpcLabel2 = new Label();
            rpcLabel3 = new Label();
            rpcLabel4 = new Label();
            rpcLabel5 = new Label();
            rpcTextBox5 = new TextBox();
            rpcLinkLabel1 = new LinkLabel();
            rpcTextBox4 = new TextBox();
            rpcTextBox3 = new TextBox();
            rpcTextBox2 = new TextBox();
            rpcTextBox1 = new TextBox();
            rpcButton1 = new Button();
            telegramPanel = new Panel();
            botPanel = new Panel();
            botLabel1 = new Label();
            botButton1 = new Button();
            dllPanel = new Panel();
            dllLabel1 = new Label();
            dllButton1 = new Button();
            button9 = new Button();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contentPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            richPresencePanel.SuspendLayout();
            botPanel.SuspendLayout();
            dllPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(32, 34, 37);
            leftPanel.Controls.Add(pictureBox1);
            leftPanel.Controls.Add(highlightPanel);
            leftPanel.Controls.Add(button1);
            leftPanel.Controls.Add(button2);
            leftPanel.Controls.Add(button4);
            leftPanel.Controls.Add(button5);
            leftPanel.Controls.Add(button3);
            leftPanel.Controls.Add(button8);
            leftPanel.Controls.Add(button7);
            leftPanel.Controls.Add(button6);
            leftPanel.Controls.Add(btnSettings);
            leftPanel.Controls.Add(label1);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(280, 720);
            leftPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 643);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 65);
            pictureBox1.TabIndex = 101;
            pictureBox1.TabStop = false;
            // 
            // highlightPanel
            // 
            highlightPanel.BackColor = Color.Silver;
            highlightPanel.Location = new Point(8, 496);
            highlightPanel.Name = "highlightPanel";
            highlightPanel.Size = new Size(4, 50);
            highlightPanel.TabIndex = 100;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 20);
            button1.Name = "button1";
            button1.Padding = new Padding(15, 0, 0, 0);
            button1.Size = new Size(256, 50);
            button1.TabIndex = 0;
            button1.Text = "Discord Rich Presence";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 76);
            button2.Name = "button2";
            button2.Padding = new Padding(15, 0, 0, 0);
            button2.Size = new Size(256, 50);
            button2.TabIndex = 1;
            button2.Text = "Discord Bot (Python)";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(12, 132);
            button4.Name = "button4";
            button4.Padding = new Padding(15, 0, 0, 0);
            button4.Size = new Size(256, 50);
            button4.TabIndex = 3;
            button4.Text = "Inject DLL";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 11F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(12, 188);
            button5.Name = "button5";
            button5.Padding = new Padding(15, 0, 0, 0);
            button5.Size = new Size(256, 50);
            button5.TabIndex = 4;
            button5.Text = "Discord Connection";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += Button5_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(12, 244);
            button3.Name = "button3";
            button3.Padding = new Padding(15, 0, 0, 0);
            button3.Size = new Size(256, 50);
            button3.TabIndex = 2;
            button3.Text = "Developer Portal";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // button8
            // 
            button8.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 11F);
            button8.ForeColor = Color.White;
            button8.Location = new Point(12, 300);
            button8.Name = "button8";
            button8.Padding = new Padding(15, 0, 0, 0);
            button8.Size = new Size(256, 50);
            button8.TabIndex = 7;
            button8.Text = "Telegram Features";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = false;
            button8.Click += Button8_Click;
            // 
            // button7
            // 
            button7.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button7.ForeColor = Color.Red;
            button7.Location = new Point(12, 370);
            button7.Name = "button7";
            button7.Padding = new Padding(15, 0, 0, 0);
            button7.Size = new Size(256, 50);
            button7.TabIndex = 6;
            button7.Text = "Security Options";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            button7.Click += Button7_Click;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button6.ForeColor = Color.Red;
            button6.Location = new Point(12, 426);
            button6.Name = "button6";
            button6.Padding = new Padding(15, 0, 0, 0);
            button6.Size = new Size(256, 50);
            button6.TabIndex = 5;
            button6.Text = "Exit Application";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += Button6_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(12, 496);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(256, 50);
            btnSettings.TabIndex = 8;
            btnSettings.Text = "Home and Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(142, 146, 151);
            label1.Location = new Point(83, 648);
            label1.Name = "label1";
            label1.Size = new Size(159, 60);
            label1.TabIndex = 9;
            label1.Text = "DiscordMultiTool V2.5.3\r\nMasterSharp Team LLC.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(47, 49, 54);
            contentPanel.Controls.Add(settingsPanel);
            contentPanel.Controls.Add(richPresencePanel);
            contentPanel.Controls.Add(telegramPanel);
            contentPanel.Controls.Add(botPanel);
            contentPanel.Controls.Add(dllPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(280, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(920, 720);
            contentPanel.TabIndex = 1;
            // 
            // settingsPanel
            // 
            settingsPanel.BackColor = Color.FromArgb(47, 49, 54);
            settingsPanel.Controls.Add(label7);
            settingsPanel.Controls.Add(label6);
            settingsPanel.Controls.Add(label8);
            settingsPanel.Controls.Add(label9);
            settingsPanel.Controls.Add(label10);
            settingsPanel.Controls.Add(label11);
            settingsPanel.Controls.Add(pictureBox2);
            settingsPanel.Controls.Add(label2);
            settingsPanel.Controls.Add(languageComboBox);
            settingsPanel.Controls.Add(lblLanguage);
            settingsPanel.Controls.Add(checkBox1);
            settingsPanel.Controls.Add(label5);
            settingsPanel.Controls.Add(textBox2);
            settingsPanel.Controls.Add(label4);
            settingsPanel.Controls.Add(label3);
            settingsPanel.Controls.Add(textBox1);
            settingsPanel.Controls.Add(button11);
            settingsPanel.Controls.Add(button10);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(0, 0);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(920, 720);
            settingsPanel.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(842, 496);
            label7.Name = "label7";
            label7.Size = new Size(66, 30);
            label7.TabIndex = 19;
            label7.Text = "Client";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(815, 522);
            label6.Name = "label6";
            label6.Size = new Size(96, 30);
            label6.TabIndex = 18;
            label6.Text = "OpenSSL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Silver;
            label8.Location = new Point(774, 643);
            label8.Name = "label8";
            label8.Size = new Size(134, 30);
            label8.TabIndex = 17;
            label8.Text = "Telegram Bot";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(815, 552);
            label9.Name = "label9";
            label9.Size = new Size(93, 30);
            label9.TabIndex = 16;
            label9.Text = "Injection";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(788, 582);
            label10.Name = "label10";
            label10.Size = new Size(120, 30);
            label10.TabIndex = 15;
            label10.Text = "Discord Bot";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Silver;
            label11.Location = new Point(787, 613);
            label11.Name = "label11";
            label11.Size = new Size(121, 30);
            label11.TabIndex = 14;
            label11.Text = "DiscordRPC";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(688, 681);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(726, 681);
            label2.Name = "label2";
            label2.Size = new Size(182, 30);
            label2.TabIndex = 11;
            label2.Text = "DiscordMultiTool";
            // 
            // languageComboBox
            // 
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.Font = new Font("Segoe UI", 11F);
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Items.AddRange(new object[] { "English", "Italiano" });
            languageComboBox.Location = new Point(130, 245);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(200, 28);
            languageComboBox.TabIndex = 10;
            languageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 12F);
            lblLanguage.ForeColor = Color.White;
            lblLanguage.Location = new Point(45, 248);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(78, 21);
            lblLanguage.TabIndex = 9;
            lblLanguage.Text = "Language";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10F);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(560, 255);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 8;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(420, 250);
            label5.Name = "label5";
            label5.Size = new Size(103, 21);
            label5.TabIndex = 7;
            label5.Text = "Save Settings";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Location = new Point(560, 154);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 20);
            textBox2.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(420, 153);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 5;
            label4.Text = "Target Server";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(420, 60);
            label3.Name = "label3";
            label3.Size = new Size(123, 21);
            label3.TabIndex = 4;
            label3.Text = "Discord Account";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(560, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 20);
            textBox1.TabIndex = 3;
            // 
            // button11
            // 
            button11.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI", 11F);
            button11.ForeColor = Color.White;
            button11.Location = new Point(50, 142);
            button11.Name = "button11";
            button11.Size = new Size(280, 45);
            button11.TabIndex = 2;
            button11.Text = "Color GUI";
            button11.UseVisualStyleBackColor = false;
            button11.Click += Button11_Click;
            // 
            // button10
            // 
            button10.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Segoe UI", 11F);
            button10.ForeColor = Color.White;
            button10.Location = new Point(50, 48);
            button10.Name = "button10";
            button10.Size = new Size(280, 45);
            button10.TabIndex = 1;
            button10.Text = "Change Theme";
            button10.UseVisualStyleBackColor = false;
            button10.Click += Button10_Click;
            // 
            // richPresencePanel
            // 
            richPresencePanel.BackColor = Color.FromArgb(47, 49, 54);
            richPresencePanel.Controls.Add(rpcLabel1);
            richPresencePanel.Controls.Add(rpcLabel2);
            richPresencePanel.Controls.Add(rpcLabel3);
            richPresencePanel.Controls.Add(rpcLabel4);
            richPresencePanel.Controls.Add(rpcLabel5);
            richPresencePanel.Controls.Add(rpcTextBox5);
            richPresencePanel.Controls.Add(rpcLinkLabel1);
            richPresencePanel.Controls.Add(rpcTextBox4);
            richPresencePanel.Controls.Add(rpcTextBox3);
            richPresencePanel.Controls.Add(rpcTextBox2);
            richPresencePanel.Controls.Add(rpcTextBox1);
            richPresencePanel.Controls.Add(rpcButton1);
            richPresencePanel.Dock = DockStyle.Fill;
            richPresencePanel.Location = new Point(0, 0);
            richPresencePanel.Name = "richPresencePanel";
            richPresencePanel.Size = new Size(920, 720);
            richPresencePanel.TabIndex = 1;
            richPresencePanel.Visible = false;
            // 
            // rpcLabel1
            // 
            rpcLabel1.AutoSize = true;
            rpcLabel1.Font = new Font("Segoe UI", 11F);
            rpcLabel1.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel1.Location = new Point(80, 80);
            rpcLabel1.Name = "rpcLabel1";
            rpcLabel1.Size = new Size(105, 20);
            rpcLabel1.TabIndex = 11;
            rpcLabel1.Text = "Application ID";
            // 
            // rpcLabel2
            // 
            rpcLabel2.AutoSize = true;
            rpcLabel2.Font = new Font("Segoe UI", 11F);
            rpcLabel2.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel2.Location = new Point(80, 160);
            rpcLabel2.Name = "rpcLabel2";
            rpcLabel2.Size = new Size(43, 20);
            rpcLabel2.TabIndex = 12;
            rpcLabel2.Text = "State";
            // 
            // rpcLabel3
            // 
            rpcLabel3.AutoSize = true;
            rpcLabel3.Font = new Font("Segoe UI", 11F);
            rpcLabel3.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel3.Location = new Point(80, 240);
            rpcLabel3.Name = "rpcLabel3";
            rpcLabel3.Size = new Size(82, 20);
            rpcLabel3.TabIndex = 13;
            rpcLabel3.Text = "Image Text";
            // 
            // rpcLabel4
            // 
            rpcLabel4.AutoSize = true;
            rpcLabel4.Font = new Font("Segoe UI", 11F);
            rpcLabel4.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel4.Location = new Point(80, 320);
            rpcLabel4.Name = "rpcLabel4";
            rpcLabel4.Size = new Size(55, 20);
            rpcLabel4.TabIndex = 14;
            rpcLabel4.Text = "Details";
            // 
            // rpcLabel5
            // 
            rpcLabel5.AutoSize = true;
            rpcLabel5.Font = new Font("Segoe UI", 11F);
            rpcLabel5.ForeColor = Color.FromArgb(142, 146, 151);
            rpcLabel5.Location = new Point(80, 400);
            rpcLabel5.Name = "rpcLabel5";
            rpcLabel5.Size = new Size(95, 20);
            rpcLabel5.TabIndex = 15;
            rpcLabel5.Text = "Image Name";
            // 
            // rpcTextBox5
            // 
            rpcTextBox5.Font = new Font("Segoe UI", 11F);
            rpcTextBox5.Location = new Point(80, 430);
            rpcTextBox5.Name = "rpcTextBox5";
            rpcTextBox5.Size = new Size(760, 27);
            rpcTextBox5.TabIndex = 8;
            // 
            // rpcLinkLabel1
            // 
            rpcLinkLabel1.AutoSize = true;
            rpcLinkLabel1.Font = new Font("Segoe UI", 11F);
            rpcLinkLabel1.LinkColor = Color.FromArgb(114, 137, 218);
            rpcLinkLabel1.Location = new Point(80, 590);
            rpcLinkLabel1.Name = "rpcLinkLabel1";
            rpcLinkLabel1.Size = new Size(41, 20);
            rpcLinkLabel1.TabIndex = 7;
            rpcLinkLabel1.TabStop = true;
            rpcLinkLabel1.Text = "Help";
            rpcLinkLabel1.VisitedLinkColor = Color.FromArgb(114, 137, 218);
            rpcLinkLabel1.LinkClicked += RpcLinkLabel1_LinkClicked;
            // 
            // rpcTextBox4
            // 
            rpcTextBox4.Font = new Font("Segoe UI", 11F);
            rpcTextBox4.Location = new Point(80, 350);
            rpcTextBox4.Name = "rpcTextBox4";
            rpcTextBox4.Size = new Size(760, 27);
            rpcTextBox4.TabIndex = 6;
            // 
            // rpcTextBox3
            // 
            rpcTextBox3.Font = new Font("Segoe UI", 11F);
            rpcTextBox3.Location = new Point(80, 270);
            rpcTextBox3.Name = "rpcTextBox3";
            rpcTextBox3.Size = new Size(760, 27);
            rpcTextBox3.TabIndex = 5;
            // 
            // rpcTextBox2
            // 
            rpcTextBox2.Font = new Font("Segoe UI", 11F);
            rpcTextBox2.Location = new Point(80, 190);
            rpcTextBox2.Name = "rpcTextBox2";
            rpcTextBox2.Size = new Size(760, 27);
            rpcTextBox2.TabIndex = 4;
            // 
            // rpcTextBox1
            // 
            rpcTextBox1.Font = new Font("Segoe UI", 11F);
            rpcTextBox1.Location = new Point(80, 110);
            rpcTextBox1.Name = "rpcTextBox1";
            rpcTextBox1.Size = new Size(760, 27);
            rpcTextBox1.TabIndex = 3;
            // 
            // rpcButton1
            // 
            rpcButton1.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            rpcButton1.FlatAppearance.BorderSize = 0;
            rpcButton1.FlatStyle = FlatStyle.Flat;
            rpcButton1.Font = new Font("Segoe UI", 13F);
            rpcButton1.ForeColor = Color.White;
            rpcButton1.Location = new Point(280, 500);
            rpcButton1.Name = "rpcButton1";
            rpcButton1.Size = new Size(360, 55);
            rpcButton1.TabIndex = 2;
            rpcButton1.Text = "Load Discord RPC";
            rpcButton1.UseVisualStyleBackColor = false;
            rpcButton1.Click += RpcButton1_Click;
            // 
            // telegramPanel
            // 
            telegramPanel.BackColor = Color.FromArgb(47, 49, 54);
            telegramPanel.Dock = DockStyle.Fill;
            telegramPanel.Location = new Point(0, 0);
            telegramPanel.Name = "telegramPanel";
            telegramPanel.Size = new Size(920, 720);
            telegramPanel.TabIndex = 4;
            // 
            // botPanel
            // 
            botPanel.BackColor = Color.FromArgb(47, 49, 54);
            botPanel.Controls.Add(botLabel1);
            botPanel.Controls.Add(botButton1);
            botPanel.Dock = DockStyle.Fill;
            botPanel.Location = new Point(0, 0);
            botPanel.Name = "botPanel";
            botPanel.Size = new Size(920, 720);
            botPanel.TabIndex = 2;
            botPanel.Visible = false;
            // 
            // botLabel1
            // 
            botLabel1.Font = new Font("Segoe UI", 13F);
            botLabel1.ForeColor = Color.White;
            botLabel1.Location = new Point(100, 100);
            botLabel1.Name = "botLabel1";
            botLabel1.Size = new Size(720, 100);
            botLabel1.TabIndex = 1;
            botLabel1.Text = "Load your Discord Bot written in Python.\nThis tool will check for Python, install dependencies if needed,\nand run your bot in the background.";
            botLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // botButton1
            // 
            botButton1.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            botButton1.FlatAppearance.BorderSize = 0;
            botButton1.FlatStyle = FlatStyle.Flat;
            botButton1.Font = new Font("Segoe UI", 13F);
            botButton1.ForeColor = Color.White;
            botButton1.Location = new Point(280, 300);
            botButton1.Name = "botButton1";
            botButton1.Size = new Size(360, 55);
            botButton1.TabIndex = 0;
            botButton1.Text = "Select Bot File";
            botButton1.UseVisualStyleBackColor = false;
            botButton1.Click += BotButton1_Click;
            // 
            // dllPanel
            // 
            dllPanel.BackColor = Color.FromArgb(47, 49, 54);
            dllPanel.Controls.Add(dllLabel1);
            dllPanel.Controls.Add(dllButton1);
            dllPanel.Dock = DockStyle.Fill;
            dllPanel.Location = new Point(0, 0);
            dllPanel.Name = "dllPanel";
            dllPanel.Size = new Size(920, 720);
            dllPanel.TabIndex = 3;
            dllPanel.Visible = false;
            // 
            // dllLabel1
            // 
            dllLabel1.Font = new Font("Segoe UI", 13F);
            dllLabel1.ForeColor = Color.White;
            dllLabel1.Location = new Point(100, 100);
            dllLabel1.Name = "dllLabel1";
            dllLabel1.Size = new Size(720, 100);
            dllLabel1.TabIndex = 1;
            dllLabel1.Text = "Inject a custom DLL into the Discord process.\nThis allows you to modify Discord's behavior.";
            dllLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dllButton1
            // 
            dllButton1.FlatAppearance.BorderColor = Color.FromArgb(114, 137, 218);
            dllButton1.FlatAppearance.BorderSize = 0;
            dllButton1.FlatStyle = FlatStyle.Flat;
            dllButton1.Font = new Font("Segoe UI", 13F);
            dllButton1.ForeColor = Color.White;
            dllButton1.Location = new Point(280, 300);
            dllButton1.Name = "dllButton1";
            dllButton1.Size = new Size(360, 55);
            dllButton1.TabIndex = 0;
            dllButton1.Text = "Select DLL File";
            dllButton1.UseVisualStyleBackColor = false;
            dllButton1.Click += DllButton1_Click;
            // 
            // button9
            // 
            button9.Location = new Point(0, 0);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(1200, 720);
            Controls.Add(contentPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiscordMultiTool";
            Load += Form1_Load;
            leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contentPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            richPresencePanel.ResumeLayout(false);
            richPresencePanel.PerformLayout();
            botPanel.ResumeLayout(false);
            dllPanel.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        
        private System.Windows.Forms.Panel richPresencePanel;
    private System.Windows.Forms.Panel telegramPanel;
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
        public Button button11;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private PictureBox pictureBox2;
    }
}
