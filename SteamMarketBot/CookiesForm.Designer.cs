namespace SteamMarketBot
{
    partial class CookiesForm
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
            this.SessionIdLabel = new System.Windows.Forms.Label();
            this.SteamLoginLabel = new System.Windows.Forms.Label();
            this.SteamLoginSecureLabel = new System.Windows.Forms.Label();
            this.SteamMachineAuthLabel = new System.Windows.Forms.Label();
            this.WebTradeEligibilityLabel = new System.Windows.Forms.Label();
            this.SessionIdTextBox = new System.Windows.Forms.TextBox();
            this.SteamLoginTextBox = new System.Windows.Forms.TextBox();
            this.SteamLoginSecureTextBox = new System.Windows.Forms.TextBox();
            this.SteamMachineAuthTextBox = new System.Windows.Forms.TextBox();
            this.WebTradeEligibilityTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SessionIdLabel
            // 
            this.SessionIdLabel.AutoSize = true;
            this.SessionIdLabel.Location = new System.Drawing.Point(12, 23);
            this.SessionIdLabel.Name = "SessionIdLabel";
            this.SessionIdLabel.Size = new System.Drawing.Size(51, 13);
            this.SessionIdLabel.TabIndex = 0;
            this.SessionIdLabel.Text = "sessionId";
            // 
            // SteamLoginLabel
            // 
            this.SteamLoginLabel.AutoSize = true;
            this.SteamLoginLabel.Location = new System.Drawing.Point(12, 62);
            this.SteamLoginLabel.Name = "SteamLoginLabel";
            this.SteamLoginLabel.Size = new System.Drawing.Size(61, 13);
            this.SteamLoginLabel.TabIndex = 1;
            this.SteamLoginLabel.Text = "steamLogin";
            // 
            // SteamLoginSecureLabel
            // 
            this.SteamLoginSecureLabel.AutoSize = true;
            this.SteamLoginSecureLabel.Location = new System.Drawing.Point(12, 101);
            this.SteamLoginSecureLabel.Name = "SteamLoginSecureLabel";
            this.SteamLoginSecureLabel.Size = new System.Drawing.Size(95, 13);
            this.SteamLoginSecureLabel.TabIndex = 2;
            this.SteamLoginSecureLabel.Text = "steamLoginSecure";
            // 
            // SteamMachineAuthLabel
            // 
            this.SteamMachineAuthLabel.AutoSize = true;
            this.SteamMachineAuthLabel.Location = new System.Drawing.Point(12, 139);
            this.SteamMachineAuthLabel.Name = "SteamMachineAuthLabel";
            this.SteamMachineAuthLabel.Size = new System.Drawing.Size(98, 13);
            this.SteamMachineAuthLabel.TabIndex = 3;
            this.SteamMachineAuthLabel.Text = "steamMachineAuth";
            // 
            // WebTradeEligibilityLabel
            // 
            this.WebTradeEligibilityLabel.AutoSize = true;
            this.WebTradeEligibilityLabel.Location = new System.Drawing.Point(12, 174);
            this.WebTradeEligibilityLabel.Name = "WebTradeEligibilityLabel";
            this.WebTradeEligibilityLabel.Size = new System.Drawing.Size(94, 13);
            this.WebTradeEligibilityLabel.TabIndex = 4;
            this.WebTradeEligibilityLabel.Text = "webTradeEligibility";
            // 
            // SessionIdTextBox
            // 
            this.SessionIdTextBox.Location = new System.Drawing.Point(165, 20);
            this.SessionIdTextBox.Name = "SessionIdTextBox";
            this.SessionIdTextBox.Size = new System.Drawing.Size(207, 20);
            this.SessionIdTextBox.TabIndex = 5;
            // 
            // SteamLoginTextBox
            // 
            this.SteamLoginTextBox.Location = new System.Drawing.Point(165, 59);
            this.SteamLoginTextBox.Name = "SteamLoginTextBox";
            this.SteamLoginTextBox.Size = new System.Drawing.Size(207, 20);
            this.SteamLoginTextBox.TabIndex = 6;
            // 
            // SteamLoginSecureTextBox
            // 
            this.SteamLoginSecureTextBox.Location = new System.Drawing.Point(165, 98);
            this.SteamLoginSecureTextBox.Name = "SteamLoginSecureTextBox";
            this.SteamLoginSecureTextBox.Size = new System.Drawing.Size(207, 20);
            this.SteamLoginSecureTextBox.TabIndex = 7;
            // 
            // SteamMachineAuthTextBox
            // 
            this.SteamMachineAuthTextBox.Location = new System.Drawing.Point(165, 136);
            this.SteamMachineAuthTextBox.Name = "SteamMachineAuthTextBox";
            this.SteamMachineAuthTextBox.Size = new System.Drawing.Size(207, 20);
            this.SteamMachineAuthTextBox.TabIndex = 8;
            // 
            // WebTradeEligibilityTextBox
            // 
            this.WebTradeEligibilityTextBox.Location = new System.Drawing.Point(165, 171);
            this.WebTradeEligibilityTextBox.Name = "WebTradeEligibilityTextBox";
            this.WebTradeEligibilityTextBox.Size = new System.Drawing.Size(207, 20);
            this.WebTradeEligibilityTextBox.TabIndex = 9;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(117, 204);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(128, 23);
            this.ImportButton.TabIndex = 10;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // CookiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 239);
            this.ControlBox = false;
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.WebTradeEligibilityTextBox);
            this.Controls.Add(this.SteamMachineAuthTextBox);
            this.Controls.Add(this.SteamLoginSecureTextBox);
            this.Controls.Add(this.SteamLoginTextBox);
            this.Controls.Add(this.SessionIdTextBox);
            this.Controls.Add(this.WebTradeEligibilityLabel);
            this.Controls.Add(this.SteamMachineAuthLabel);
            this.Controls.Add(this.SteamLoginSecureLabel);
            this.Controls.Add(this.SteamLoginLabel);
            this.Controls.Add(this.SessionIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CookiesForm";
            this.Text = "Import Cookies";
            this.Load += new System.EventHandler(this.CookiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SessionIdLabel;
        private System.Windows.Forms.Label SteamLoginLabel;
        private System.Windows.Forms.Label SteamLoginSecureLabel;
        private System.Windows.Forms.Label SteamMachineAuthLabel;
        private System.Windows.Forms.Label WebTradeEligibilityLabel;
        private System.Windows.Forms.TextBox SessionIdTextBox;
        private System.Windows.Forms.TextBox SteamLoginTextBox;
        private System.Windows.Forms.TextBox SteamLoginSecureTextBox;
        private System.Windows.Forms.TextBox SteamMachineAuthTextBox;
        private System.Windows.Forms.TextBox WebTradeEligibilityTextBox;
        private System.Windows.Forms.Button ImportButton;
    }
}