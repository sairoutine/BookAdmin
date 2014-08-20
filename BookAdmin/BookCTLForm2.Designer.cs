namespace BookAdmin
{
    partial class BookCTLForm2
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
            this.label1 = new System.Windows.Forms.Label();
            this.BookNameLabel = new System.Windows.Forms.Label();
            this.OKCTLButton = new System.Windows.Forms.Button();
            this.CancelCTLButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EmpComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LendingPeriodUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.LendingPeriodUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "タイトル：";
            // 
            // BookNameLabel
            // 
            this.BookNameLabel.Location = new System.Drawing.Point(72, 19);
            this.BookNameLabel.Name = "BookNameLabel";
            this.BookNameLabel.Size = new System.Drawing.Size(470, 12);
            this.BookNameLabel.TabIndex = 1;
            // 
            // OKCTLButton
            // 
            this.OKCTLButton.Location = new System.Drawing.Point(386, 78);
            this.OKCTLButton.Name = "OKCTLButton";
            this.OKCTLButton.Size = new System.Drawing.Size(75, 23);
            this.OKCTLButton.TabIndex = 7;
            this.OKCTLButton.Text = "貸し出し";
            this.OKCTLButton.UseVisualStyleBackColor = true;
            this.OKCTLButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelCTLButton
            // 
            this.CancelCTLButton.Location = new System.Drawing.Point(467, 78);
            this.CancelCTLButton.Name = "CancelCTLButton";
            this.CancelCTLButton.Size = new System.Drawing.Size(75, 23);
            this.CancelCTLButton.TabIndex = 8;
            this.CancelCTLButton.Text = "キャンセル";
            this.CancelCTLButton.UseVisualStyleBackColor = true;
            this.CancelCTLButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "借りる人：";
            // 
            // EmpComboBox
            // 
            this.EmpComboBox.FormattingEnabled = true;
            this.EmpComboBox.Location = new System.Drawing.Point(70, 44);
            this.EmpComboBox.Name = "EmpComboBox";
            this.EmpComboBox.Size = new System.Drawing.Size(232, 20);
            this.EmpComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "貸出期間：";
            // 
            // LendingPeriodUpDown
            // 
            this.LendingPeriodUpDown.Location = new System.Drawing.Point(70, 75);
            this.LendingPeriodUpDown.Name = "LendingPeriodUpDown";
            this.LendingPeriodUpDown.Size = new System.Drawing.Size(46, 19);
            this.LendingPeriodUpDown.TabIndex = 6;
            // 
            // BookCTLForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 113);
            this.Controls.Add(this.LendingPeriodUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EmpComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelCTLButton);
            this.Controls.Add(this.OKCTLButton);
            this.Controls.Add(this.BookNameLabel);
            this.Controls.Add(this.label1);
            this.Name = "BookCTLForm2";
            this.Text = "レンタル登録";
            this.Load += new System.EventHandler(this.BookCTLForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LendingPeriodUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BookNameLabel;
        private System.Windows.Forms.Button OKCTLButton;
        private System.Windows.Forms.Button CancelCTLButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EmpComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown LendingPeriodUpDown;
    }
}