namespace SteamMarketBot
{
    partial class MainForm
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
            this.cookiesButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.RefreshItemsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.LogListView = new System.Windows.Forms.ListView();
            this.RunningLabel = new System.Windows.Forms.Label();
            this.BuyTriesListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cookiesButton
            // 
            this.cookiesButton.Location = new System.Drawing.Point(13, 12);
            this.cookiesButton.Name = "cookiesButton";
            this.cookiesButton.Size = new System.Drawing.Size(99, 23);
            this.cookiesButton.TabIndex = 0;
            this.cookiesButton.Text = "Log In";
            this.cookiesButton.UseVisualStyleBackColor = true;
            this.cookiesButton.Click += new System.EventHandler(this.cookiesButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Enabled = false;
            this.NameLabel.Location = new System.Drawing.Point(12, 72);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Enabled = false;
            this.BalanceLabel.Location = new System.Drawing.Point(12, 47);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(46, 13);
            this.BalanceLabel.TabIndex = 2;
            this.BalanceLabel.Text = "Balance";
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.Location = new System.Drawing.Point(13, 299);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(440, 147);
            this.ItemsListBox.TabIndex = 3;
            // 
            // RefreshItemsButton
            // 
            this.RefreshItemsButton.Enabled = false;
            this.RefreshItemsButton.Location = new System.Drawing.Point(556, 427);
            this.RefreshItemsButton.Name = "RefreshItemsButton";
            this.RefreshItemsButton.Size = new System.Drawing.Size(116, 23);
            this.RefreshItemsButton.TabIndex = 4;
            this.RefreshItemsButton.Text = "Refresh Items";
            this.RefreshItemsButton.UseVisualStyleBackColor = true;
            this.RefreshItemsButton.Click += new System.EventHandler(this.RefreshItemsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Lime;
            this.StartButton.Enabled = false;
            this.StartButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StartButton.Location = new System.Drawing.Point(15, 259);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Red;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(112, 259);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LogListView
            // 
            this.LogListView.Location = new System.Drawing.Point(479, 33);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(193, 371);
            this.LogListView.TabIndex = 7;
            this.LogListView.UseCompatibleStateImageBehavior = false;
            this.LogListView.View = System.Windows.Forms.View.List;
            // 
            // RunningLabel
            // 
            this.RunningLabel.AutoSize = true;
            this.RunningLabel.ForeColor = System.Drawing.Color.Red;
            this.RunningLabel.Location = new System.Drawing.Point(12, 233);
            this.RunningLabel.Name = "RunningLabel";
            this.RunningLabel.Size = new System.Drawing.Size(47, 13);
            this.RunningLabel.TabIndex = 8;
            this.RunningLabel.Text = "Stopped";
            // 
            // BuyTriesListView
            // 
            this.BuyTriesListView.Location = new System.Drawing.Point(251, 33);
            this.BuyTriesListView.Name = "BuyTriesListView";
            this.BuyTriesListView.Scrollable = false;
            this.BuyTriesListView.Size = new System.Drawing.Size(202, 236);
            this.BuyTriesListView.TabIndex = 9;
            this.BuyTriesListView.UseCompatibleStateImageBehavior = false;
            this.BuyTriesListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Buy tries";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuyTriesListView);
            this.Controls.Add(this.RunningLabel);
            this.Controls.Add(this.LogListView);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RefreshItemsButton);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.cookiesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Steam Market Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cookiesButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Button RefreshItemsButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListView LogListView;
        private System.Windows.Forms.Label RunningLabel;
        private System.Windows.Forms.ListView BuyTriesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

