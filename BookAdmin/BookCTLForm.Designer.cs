namespace BookAdmin
{
    partial class BookCTLForm
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
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AddRentalButton = new System.Windows.Forms.Button();
            this.DelRentalButton = new System.Windows.Forms.Button();
            this.BookCTLGridView = new System.Windows.Forms.DataGridView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SearchComboBox = new System.Windows.Forms.ComboBox();
            this.ArrearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookCTLGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(111, 7);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(184, 19);
            this.SearchTextBox.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(301, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(68, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "書籍検索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AddRentalButton
            // 
            this.AddRentalButton.Location = new System.Drawing.Point(703, 5);
            this.AddRentalButton.Name = "AddRentalButton";
            this.AddRentalButton.Size = new System.Drawing.Size(160, 23);
            this.AddRentalButton.TabIndex = 3;
            this.AddRentalButton.Text = "レンタル";
            this.AddRentalButton.UseVisualStyleBackColor = true;
            this.AddRentalButton.Click += new System.EventHandler(this.AddRentalButton_Click);
            // 
            // DelRentalButton
            // 
            this.DelRentalButton.Location = new System.Drawing.Point(869, 5);
            this.DelRentalButton.Name = "DelRentalButton";
            this.DelRentalButton.Size = new System.Drawing.Size(160, 23);
            this.DelRentalButton.TabIndex = 4;
            this.DelRentalButton.Text = "レンタル解除";
            this.DelRentalButton.UseVisualStyleBackColor = true;
            this.DelRentalButton.Click += new System.EventHandler(this.DelRentalButton_Click);
            // 
            // BookCTLGridView
            // 
            this.BookCTLGridView.AllowUserToAddRows = false;
            this.BookCTLGridView.AllowUserToDeleteRows = false;
            this.BookCTLGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookCTLGridView.Location = new System.Drawing.Point(-1, 34);
            this.BookCTLGridView.Name = "BookCTLGridView";
            this.BookCTLGridView.ReadOnly = true;
            this.BookCTLGridView.RowTemplate.Height = 21;
            this.BookCTLGridView.Size = new System.Drawing.Size(1042, 491);
            this.BookCTLGridView.TabIndex = 5;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(954, 531);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "閉じる";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.FormattingEnabled = true;
            this.SearchComboBox.Location = new System.Drawing.Point(12, 7);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(93, 20);
            this.SearchComboBox.TabIndex = 7;
            // 
            // ArrearButton
            // 
            this.ArrearButton.Location = new System.Drawing.Point(537, 5);
            this.ArrearButton.Name = "ArrearButton";
            this.ArrearButton.Size = new System.Drawing.Size(160, 23);
            this.ArrearButton.TabIndex = 8;
            this.ArrearButton.Text = "延滞者一覧";
            this.ArrearButton.UseVisualStyleBackColor = true;
            this.ArrearButton.Click += new System.EventHandler(this.ArrearButton_Click);
            // 
            // BookCTLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 560);
            this.Controls.Add(this.ArrearButton);
            this.Controls.Add(this.SearchComboBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BookCTLGridView);
            this.Controls.Add(this.DelRentalButton);
            this.Controls.Add(this.AddRentalButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Name = "BookCTLForm";
            this.Text = "書籍貸し出し";
            this.Load += new System.EventHandler(this.BookCTLForm_Load);
            this.Closed += new System.EventHandler(this.BookCTLForm_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.BookCTLGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button AddRentalButton;
        private System.Windows.Forms.Button DelRentalButton;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.DataGridView BookCTLGridView;
        private System.Windows.Forms.ComboBox SearchComboBox;
        private System.Windows.Forms.Button ArrearButton;
    }
}