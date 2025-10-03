namespace DiscordMultiTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label1 = new Label();
            tabPage1 = new TabPage();
            checkBox1 = new CheckBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            tabControl1 = new TabControl();
            label2 = new Label();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(292, 42);
            button1.TabIndex = 0;
            button1.Text = "Load Discord Rich Presence";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 60);
            button2.Name = "button2";
            button2.Size = new Size(292, 42);
            button2.TabIndex = 1;
            button2.Text = "Load Discord Bot Python";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(12, 204);
            button3.Name = "button3";
            button3.Size = new Size(292, 42);
            button3.TabIndex = 2;
            button3.Text = "Open Discord Developer Portal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(12, 108);
            button4.Name = "button4";
            button4.Size = new Size(292, 42);
            button4.TabIndex = 3;
            button4.Text = "Inject DLL";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(12, 156);
            button5.Name = "button5";
            button5.Size = new Size(292, 42);
            button5.TabIndex = 4;
            button5.Text = "ViaDiscord";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Red;
            button6.Location = new Point(12, 348);
            button6.Name = "button6";
            button6.Size = new Size(292, 42);
            button6.TabIndex = 5;
            button6.Text = "Self Destroy";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.Red;
            button7.Location = new Point(12, 300);
            button7.Name = "button7";
            button7.Size = new Size(292, 42);
            button7.TabIndex = 6;
            button7.Text = "Destroy Discord Client";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Button7_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(12, 252);
            button8.Name = "button8";
            button8.Size = new Size(292, 42);
            button8.TabIndex = 7;
            button8.Text = "Misc";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Button8_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 498);
            label1.Name = "label1";
            label1.Size = new Size(292, 109);
            label1.TabIndex = 8;
            label1.Text = "DiscordMultiTool V1.1.0\n";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(button11);
            tabPage1.Controls.Add(button10);
            tabPage1.Controls.Add(button9);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(744, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(434, 233);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(124, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Auto Save Settings";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(305, 231);
            label5.Name = "label5";
            label5.Size = new Size(103, 21);
            label5.TabIndex = 7;
            label5.Text = "Save Settings";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(434, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(304, 23);
            textBox2.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(305, 132);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 5;
            label4.Text = "Target Server";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(305, 36);
            label3.Name = "label3";
            label3.Size = new Size(123, 21);
            label3.TabIndex = 4;
            label3.Text = "Discord Account";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(434, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 23);
            textBox1.TabIndex = 3;
            // 
            // button11
            // 
            button11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.Location = new Point(30, 225);
            button11.Name = "button11";
            button11.Size = new Size(232, 33);
            button11.TabIndex = 2;
            button11.Text = "Inject Discord Patch";
            button11.UseVisualStyleBackColor = true;
            button11.Click += Button11_Click;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(30, 126);
            button10.Name = "button10";
            button10.Size = new Size(232, 33);
            button10.TabIndex = 1;
            button10.Text = "Change Theme: Classic";
            button10.UseVisualStyleBackColor = true;
            button10.Click += Button10_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(30, 30);
            button9.Name = "button9";
            button9.Size = new Size(232, 33);
            button9.TabIndex = 0;
            button9.Text = "Color GUI";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Button9_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(310, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(752, 595);
            tabControl1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(430, 8);
            label2.Name = "label2";
            label2.Size = new Size(628, 25);
            label2.TabIndex = 10;
            label2.Text = "DiscordMultiTool by MasterSharp and itelcan3 for MasterSharp Team LLC.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 616);
            Controls.Add(label2);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "DiscordMultiTool";
            Load += Form1_Load;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label1;
        private TabPage tabPage1;
        private Button button10;
        private Button button9;
        private TabControl tabControl1;
        private Label label2;
        private Button button11;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Label label5;
    }
}
