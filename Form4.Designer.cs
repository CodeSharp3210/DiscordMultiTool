namespace DiscordMultiTool
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            linkLabel1 = new LinkLabel();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F);
            button1.Location = new Point(144, 352);
            button1.Name = "button1";
            button1.Size = new Size(238, 43);
            button1.TabIndex = 2;
            button1.Text = "Load Discord RPC";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(370, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "#Application ID";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 64);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(370, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "#State";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 117);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(370, 23);
            textBox3.TabIndex = 5;
            textBox3.Text = "#Picture Text";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 173);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(370, 23);
            textBox4.TabIndex = 6;
            textBox4.Text = "#Long Text";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F);
            linkLabel1.LinkColor = Color.Blue;
            linkLabel1.Location = new Point(12, 377);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(42, 21);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Help";
            linkLabel1.VisitedLinkColor = Color.Blue;
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(12, 230);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(370, 23);
            textBox5.TabIndex = 8;
            textBox5.Text = "#imagename";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 407);
            Controls.Add(textBox5);
            Controls.Add(linkLabel1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form4";
            Text = "Load Discord Rich Presence";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox5;
    }
}
