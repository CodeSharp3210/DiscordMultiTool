using System.Drawing;
using System.Windows.Forms;

namespace DiscordMultiTool
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            titleLabel = new Label();
            loadBotButton = new Button();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(loadBotButton);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(18, 15, 18, 15);
            mainPanel.Size = new Size(904, 681);
            mainPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(332, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(245, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Telegram Bot Features";
            // 
            // loadBotButton
            // 
            loadBotButton.BackColor = Color.White;
            loadBotButton.FlatAppearance.BorderSize = 0;
            loadBotButton.FlatStyle = FlatStyle.Flat;
            loadBotButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadBotButton.Location = new Point(350, 124);
            loadBotButton.Margin = new Padding(3, 2, 3, 2);
            loadBotButton.Name = "loadBotButton";
            loadBotButton.Size = new Size(199, 43);
            loadBotButton.TabIndex = 9;
            loadBotButton.Text = "Load Telegram Bot";
            loadBotButton.UseVisualStyleBackColor = false;
            loadBotButton.Click += Button1_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 681);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(527, 310);
            Name = "Form5";
            Text = "Telegram Features";
            Load += Form5_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel mainPanel;
        public Button loadBotButton;
        public Label titleLabel;
    }
}
