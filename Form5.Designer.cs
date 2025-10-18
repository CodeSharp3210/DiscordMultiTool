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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            // Create main container panel for better layout
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.AutoScroll = true;
            
            // Title Label
            var titleLabel = new Label();
            titleLabel.Text = "Telegram Bot Features";
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(0, 0);
            mainPanel.Controls.Add(titleLabel);
            
            // Bot Token Section
            tokenLabel = new Label();
            tokenLabel.AutoSize = true;
            tokenLabel.Location = new Point(0, 50);
            tokenLabel.Size = new Size(100, 20);
            tokenLabel.Text = "Bot Token:";
            tokenLabel.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(tokenLabel);

            tokenTextBox = new TextBox();
            tokenTextBox.Location = new Point(0, 75);
            tokenTextBox.Name = "tokenTextBox";
            tokenTextBox.Size = new Size(500, 27);
            tokenTextBox.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(tokenTextBox);

            // Chat ID Section
            chatIdLabel = new Label();
            chatIdLabel.AutoSize = true;
            chatIdLabel.Location = new Point(0, 115);
            chatIdLabel.Size = new Size(70, 20);
            chatIdLabel.Text = "Chat ID:";
            chatIdLabel.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(chatIdLabel);

            chatIdTextBox = new TextBox();
            chatIdTextBox.Location = new Point(0, 140);
            chatIdTextBox.Name = "chatIdTextBox";
            chatIdTextBox.Size = new Size(500, 27);
            chatIdTextBox.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(chatIdTextBox);

            // Message Section
            messageLabel = new Label();
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(0, 180);
            messageLabel.Size = new Size(75, 20);
            messageLabel.Text = "Message:";
            messageLabel.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(messageLabel);

            messageTextBox = new TextBox();
            messageTextBox.Location = new Point(0, 205);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(500, 100);
            messageTextBox.Multiline = true;
            messageTextBox.ScrollBars = ScrollBars.Vertical;
            messageTextBox.Font = new Font("Segoe UI", 10F);
            mainPanel.Controls.Add(messageTextBox);

            // Buttons Section
            sendButton = new Button();
            sendButton.Location = new Point(0, 320);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(150, 40);
            sendButton.Text = "Send Message";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Font = new Font("Segoe UI", 10F);
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 2;
            mainPanel.Controls.Add(sendButton);

            saveButton = new Button();
            saveButton.Location = new Point(165, 320);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 40);
            saveButton.Text = "Save Settings";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Font = new Font("Segoe UI", 10F);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 2;
            mainPanel.Controls.Add(saveButton);

            var loadBotButton = new Button();
            loadBotButton.Location = new Point(330, 320);
            loadBotButton.Name = "loadBotButton";
            loadBotButton.Size = new Size(170, 40);
            loadBotButton.Text = "Load Python Bot";
            loadBotButton.UseVisualStyleBackColor = true;
            loadBotButton.Font = new Font("Segoe UI", 10F);
            loadBotButton.FlatStyle = FlatStyle.Flat;
            loadBotButton.FlatAppearance.BorderSize = 2;
            loadBotButton.Click += Button1_Click;
            mainPanel.Controls.Add(loadBotButton);

            // Add main panel to form
            this.Controls.Add(mainPanel);
            
            // Form settings
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 400);
            this.Name = "Form5";
            this.Text = "Telegram Features";
            this.MinimumSize = new Size(600, 400);
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
    }
}
