namespace BookAdmin
{
    partial class BookForm1
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
            this.BookGridView = new System.Windows.Forms.DataGridView();
            this.CancelBookButton = new System.Windows.Forms.Button();
            this.SubmitBookButton = new System.Windows.Forms.Button();
            this.DelBookButton = new System.Windows.Forms.Button();
            this.EditBookButton = new System.Windows.Forms.Button();
            this.AddBookButton = new System.Windows.Forms.Button();
            this.BarcodeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BookGridView
            // 
            this.BookGridView.Location = new System.Drawing.Point(12, 40);
            this.BookGridView.Name = "BookGridView";
            this.BookGridView.RowTemplate.Height = 21;
            this.BookGridView.Size = new System.Drawing.Size(1016, 485);
            this.BookGridView.TabIndex = 11;
            // 
            // CancelBookButton
            // 
            this.CancelBookButton.Location = new System.Drawing.Point(953, 531);
            this.CancelBookButton.Name = "CancelBookButton";
            this.CancelBookButton.Size = new System.Drawing.Size(75, 23);
            this.CancelBookButton.TabIndex = 10;
            this.CancelBookButton.Text = "キャンセル";
            this.CancelBookButton.UseVisualStyleBackColor = true;
            this.CancelBookButton.Click += new System.EventHandler(this.CancelBookButton_Click);
            // 
            // SubmitBookButton
            // 
            this.SubmitBookButton.Location = new System.Drawing.Point(872, 531);
            this.SubmitBookButton.Name = "SubmitBookButton";
            this.SubmitBookButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitBookButton.TabIndex = 9;
            this.SubmitBookButton.Text = "確定";
            this.SubmitBookButton.UseVisualStyleBackColor = true;
            this.SubmitBookButton.Click += new System.EventHandler(this.SubmitBookButton_Click);
            // 
            // DelBookButton
            // 
            this.DelBookButton.Location = new System.Drawing.Point(173, 9);
            this.DelBookButton.Name = "DelBookButton";
            this.DelBookButton.Size = new System.Drawing.Size(75, 23);
            this.DelBookButton.TabIndex = 8;
            this.DelBookButton.Text = "削除";
            this.DelBookButton.UseVisualStyleBackColor = true;
            this.DelBookButton.Click += new System.EventHandler(this.DelBookButton_Click);
            // 
            // EditBookButton
            // 
            this.EditBookButton.Location = new System.Drawing.Point(92, 9);
            this.EditBookButton.Name = "EditBookButton";
            this.EditBookButton.Size = new System.Drawing.Size(75, 23);
            this.EditBookButton.TabIndex = 7;
            this.EditBookButton.Text = "編集";
            this.EditBookButton.UseVisualStyleBackColor = true;
            this.EditBookButton.Click += new System.EventHandler(this.EditBookButton_Click);
            // 
            // AddBookButton
            // 
            this.AddBookButton.Location = new System.Drawing.Point(11, 9);
            this.AddBookButton.Name = "AddBookButton";
            this.AddBookButton.Size = new System.Drawing.Size(75, 23);
            this.AddBookButton.TabIndex = 6;
            this.AddBookButton.Text = "新規登録";
            this.AddBookButton.UseVisualStyleBackColor = true;
            this.AddBookButton.Click += new System.EventHandler(this.AddBookButton_Click);
            // 
            // BarcodeButton
            // 
            this.BarcodeButton.Location = new System.Drawing.Point(255, 9);
            this.BarcodeButton.Name = "BarcodeButton";
            this.BarcodeButton.Size = new System.Drawing.Size(164, 23);
            this.BarcodeButton.TabIndex = 12;
            this.BarcodeButton.Text = "バーコードから読み取る";
            this.BarcodeButton.UseVisualStyleBackColor = true;
            this.BarcodeButton.Click += new System.EventHandler(this.BarcodeButton_Click);
            // 
            // BookForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 566);
            this.Controls.Add(this.BarcodeButton);
            this.Controls.Add(this.BookGridView);
            this.Controls.Add(this.CancelBookButton);
            this.Controls.Add(this.SubmitBookButton);
            this.Controls.Add(this.DelBookButton);
            this.Controls.Add(this.EditBookButton);
            this.Controls.Add(this.AddBookButton);
            this.Name = "BookForm1";
            this.Text = "書籍登録";
            this.Load += new System.EventHandler(this.BookForm1_Load);
            this.Closed += new System.EventHandler(this.BookForm1_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.BookGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BookGridView;
        private System.Windows.Forms.Button CancelBookButton;
        private System.Windows.Forms.Button SubmitBookButton;
        private System.Windows.Forms.Button DelBookButton;
        private System.Windows.Forms.Button EditBookButton;
        private System.Windows.Forms.Button AddBookButton;
        private System.Windows.Forms.Button BarcodeButton;
    }
}