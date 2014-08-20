namespace BookAdmin
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
            this.EmpMainButton = new System.Windows.Forms.Button();
            this.BookMainButton = new System.Windows.Forms.Button();
            this.LendMainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmpMainButton
            // 
            this.EmpMainButton.Location = new System.Drawing.Point(12, 12);
            this.EmpMainButton.Name = "EmpMainButton";
            this.EmpMainButton.Size = new System.Drawing.Size(114, 23);
            this.EmpMainButton.TabIndex = 0;
            this.EmpMainButton.Text = "社員情報管理";
            this.EmpMainButton.UseVisualStyleBackColor = true;
            this.EmpMainButton.Click += new System.EventHandler(this.EmpMainButton_Click);
            // 
            // BookMainButton
            // 
            this.BookMainButton.Location = new System.Drawing.Point(131, 12);
            this.BookMainButton.Name = "BookMainButton";
            this.BookMainButton.Size = new System.Drawing.Size(114, 23);
            this.BookMainButton.TabIndex = 1;
            this.BookMainButton.Text = "社内本管理";
            this.BookMainButton.UseVisualStyleBackColor = true;
            this.BookMainButton.Click += new System.EventHandler(this.BookMainButton_Click);
            // 
            // LendMainButton
            // 
            this.LendMainButton.Location = new System.Drawing.Point(11, 41);
            this.LendMainButton.Name = "LendMainButton";
            this.LendMainButton.Size = new System.Drawing.Size(234, 23);
            this.LendMainButton.TabIndex = 2;
            this.LendMainButton.Text = "書籍貸し出し登録";
            this.LendMainButton.UseVisualStyleBackColor = true;
            this.LendMainButton.Click += new System.EventHandler(this.LendMainButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 76);
            this.Controls.Add(this.LendMainButton);
            this.Controls.Add(this.BookMainButton);
            this.Controls.Add(this.EmpMainButton);
            this.Name = "MainForm";
            this.Text = "社内書籍持ち出し管理システム";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EmpMainButton;
        private System.Windows.Forms.Button BookMainButton;
        private System.Windows.Forms.Button LendMainButton;
    }
}