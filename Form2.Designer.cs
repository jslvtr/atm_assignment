namespace ATMAssignment
{
    partial class Form2
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
            this.cashButton = new System.Windows.Forms.Button();
            this.balanceButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cashButton
            // 
            this.cashButton.Location = new System.Drawing.Point(0, 114);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(400, 50);
            this.cashButton.TabIndex = 0;
            this.cashButton.Text = "Withdraw cash";
            this.cashButton.UseVisualStyleBackColor = true;
            this.cashButton.Click += new System.EventHandler(this.cashButton_Click);
            // 
            // balanceButton
            // 
            this.balanceButton.Location = new System.Drawing.Point(0, 170);
            this.balanceButton.Name = "balanceButton";
            this.balanceButton.Size = new System.Drawing.Size(400, 50);
            this.balanceButton.TabIndex = 1;
            this.balanceButton.Text = "Check balance";
            this.balanceButton.UseVisualStyleBackColor = true;
            this.balanceButton.Click += new System.EventHandler(this.balanceButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(0, 226);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(400, 50);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Take card";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(49, 42);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(302, 25);
            this.welcomeLabel.TabIndex = 3;
            this.welcomeLabel.Text = "Welcome, <AccountName>";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(76, 70);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(74, 13);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.Text = "Message here";
            this.messageLabel.Visible = false;
            this.messageLabel.Leave += new System.EventHandler(this.messageLabel_Leave);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(400, 311);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.balanceButton);
            this.Controls.Add(this.cashButton);
            this.MinimumSize = new System.Drawing.Size(416, 350);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cashButton;
        private System.Windows.Forms.Button balanceButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label messageLabel;
    }
}