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
            tokenLabel = new Label();
            tokenTextBox = new TextBox();
            chatIdLabel = new Label();
            chatIdTextBox = new TextBox();
            messageLabel = new Label();
            messageTextBox = new TextBox();
            sendButton = new Button();
            saveButton = new Button();
            loadBotButton = new Button();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(tokenLabel);
            mainPanel.Controls.Add(tokenTextBox);
            mainPanel.Controls.Add(chatIdLabel);
            mainPanel.Controls.Add(chatIdTextBox);
            mainPanel.Controls.Add(messageLabel);
            mainPanel.Controls.Add(messageTextBox);
            mainPanel.Controls.Add(sendButton);
            mainPanel.Controls.Add(saveButton);
            mainPanel.Controls.Add(loadBotButton);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(18, 15, 18, 15);
            mainPanel.Size = new Size(525, 300);
            mainPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(12, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(245, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Telegram Bot Features";
            // 
            // tokenLabel
            // 
            tokenLabel.AutoSize = true;
            tokenLabel.Font = new Font("Segoe UI", 10F);
            tokenLabel.Location = new Point(12, 35);
            tokenLabel.Name = "tokenLabel";
            tokenLabel.Size = new Size(73, 19);
            tokenLabel.TabIndex = 1;
            tokenLabel.Text = "Bot Token:";
            // 
            // tokenTextBox
            // 
            tokenTextBox.BackColor = Color.White;
            tokenTextBox.BorderStyle = BorderStyle.None;
            tokenTextBox.Font = new Font("Segoe UI", 10F);
            tokenTextBox.Location = new Point(12, 56);
            tokenTextBox.Margin = new Padding(3, 2, 3, 2);
            tokenTextBox.Name = "tokenTextBox";
            tokenTextBox.Size = new Size(438, 18);
            tokenTextBox.TabIndex = 2;
            // 
            // chatIdLabel
            // 
            chatIdLabel.AutoSize = true;
            chatIdLabel.Font = new Font("Segoe UI", 10F);
            chatIdLabel.Location = new Point(12, 83);
            chatIdLabel.Name = "chatIdLabel";
            chatIdLabel.Size = new Size(59, 19);
            chatIdLabel.TabIndex = 3;
            chatIdLabel.Text = "Chat ID:";
            // 
            // chatIdTextBox
            // 
            chatIdTextBox.BackColor = Color.White;
            chatIdTextBox.BorderStyle = BorderStyle.None;
            chatIdTextBox.Font = new Font("Segoe UI", 10F);
            chatIdTextBox.Location = new Point(12, 107);
            chatIdTextBox.Margin = new Padding(3, 2, 3, 2);
            chatIdTextBox.Name = "chatIdTextBox";
            chatIdTextBox.Size = new Size(438, 18);
            chatIdTextBox.TabIndex = 4;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 10F);
            messageLabel.Location = new Point(12, 134);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(66, 19);
            messageLabel.TabIndex = 5;
            messageLabel.Text = "Message:";
            // 
            // messageTextBox
            // 
            messageTextBox.BackColor = Color.White;
            messageTextBox.BorderStyle = BorderStyle.None;
            messageTextBox.Font = new Font("Segoe UI", 10F);
            messageTextBox.Location = new Point(12, 156);
            messageTextBox.Margin = new Padding(3, 2, 3, 2);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.ScrollBars = ScrollBars.Vertical;
            messageTextBox.Size = new Size(438, 76);
            messageTextBox.TabIndex = 6;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.White;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI", 10F);
            sendButton.Location = new Point(12, 240);
            sendButton.Margin = new Padding(3, 2, 3, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(131, 30);
            sendButton.TabIndex = 7;
            sendButton.Text = "Send Message";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.White;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F);
            saveButton.Location = new Point(149, 240);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 30);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save Settings";
            saveButton.UseVisualStyleBackColor = false;
            // 
            // loadBotButton
            // 
            loadBotButton.BackColor = Color.White;
            loadBotButton.FlatAppearance.BorderSize = 0;
            loadBotButton.FlatStyle = FlatStyle.Flat;
            loadBotButton.Font = new Font("Segoe UI", 10F);
            loadBotButton.Location = new Point(286, 240);
            loadBotButton.Margin = new Padding(3, 2, 3, 2);
            loadBotButton.Name = "loadBotButton";
            loadBotButton.Size = new Size(149, 30);
            loadBotButton.TabIndex = 9;
            loadBotButton.Text = "Load Python Bot";
            loadBotButton.UseVisualStyleBackColor = false;
            loadBotButton.Click += Button1_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 300);
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

        private Label tokenLabel;
        private TextBox tokenTextBox;
        private Label chatIdLabel;
        private TextBox chatIdTextBox;
        private Label messageLabel;
        private TextBox messageTextBox;
        private Button sendButton;
        private Button saveButton;
        private Panel mainPanel;
        public Button loadBotButton;
        public Label titleLabel;
    }
}
