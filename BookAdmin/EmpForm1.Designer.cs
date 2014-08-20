namespace BookAdmin
{
    partial class EmpForm1
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
            this.AddEmpButton = new System.Windows.Forms.Button();
            this.EditEmpButton = new System.Windows.Forms.Button();
            this.DelEmpButton = new System.Windows.Forms.Button();
            this.SubmitEmpButton = new System.Windows.Forms.Button();
            this.CancelEmpButton = new System.Windows.Forms.Button();
            this.EmpGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AddEmpButton
            // 
            this.AddEmpButton.Location = new System.Drawing.Point(12, 12);
            this.AddEmpButton.Name = "AddEmpButton";
            this.AddEmpButton.Size = new System.Drawing.Size(75, 23);
            this.AddEmpButton.TabIndex = 0;
            this.AddEmpButton.Text = "新規登録";
            this.AddEmpButton.UseVisualStyleBackColor = true;
            this.AddEmpButton.Click += new System.EventHandler(this.AddEmpButton_Click);
            // 
            // EditEmpButton
            // 
            this.EditEmpButton.Location = new System.Drawing.Point(93, 12);
            this.EditEmpButton.Name = "EditEmpButton";
            this.EditEmpButton.Size = new System.Drawing.Size(75, 23);
            this.EditEmpButton.TabIndex = 1;
            this.EditEmpButton.Text = "編集";
            this.EditEmpButton.UseVisualStyleBackColor = true;
            this.EditEmpButton.Click += new System.EventHandler(this.EditEmpButton_Click);
            // 
            // DelEmpButton
            // 
            this.DelEmpButton.Location = new System.Drawing.Point(174, 12);
            this.DelEmpButton.Name = "DelEmpButton";
            this.DelEmpButton.Size = new System.Drawing.Size(75, 23);
            this.DelEmpButton.TabIndex = 2;
            this.DelEmpButton.Text = "削除";
            this.DelEmpButton.UseVisualStyleBackColor = true;
            this.DelEmpButton.Click += new System.EventHandler(this.DelEmpButton_Click);
            // 
            // SubmitEmpButton
            // 
            this.SubmitEmpButton.Location = new System.Drawing.Point(874, 531);
            this.SubmitEmpButton.Name = "SubmitEmpButton";
            this.SubmitEmpButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitEmpButton.TabIndex = 3;
            this.SubmitEmpButton.Text = "確定";
            this.SubmitEmpButton.UseVisualStyleBackColor = true;
            this.SubmitEmpButton.Click += new System.EventHandler(this.SubmitEmpButton_Click);
            // 
            // CancelEmpButton
            // 
            this.CancelEmpButton.Location = new System.Drawing.Point(955, 531);
            this.CancelEmpButton.Name = "CancelEmpButton";
            this.CancelEmpButton.Size = new System.Drawing.Size(75, 23);
            this.CancelEmpButton.TabIndex = 4;
            this.CancelEmpButton.Text = "キャンセル";
            this.CancelEmpButton.UseVisualStyleBackColor = true;
            this.CancelEmpButton.Click += new System.EventHandler(this.CancelEmpButton_Click);
            // 
            // EmpGridView
            // 
            this.EmpGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmpGridView.Location = new System.Drawing.Point(13, 43);
            this.EmpGridView.Name = "EmpGridView";
            this.EmpGridView.RowTemplate.Height = 21;
            this.EmpGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmpGridView.Size = new System.Drawing.Size(1017, 482);
            this.EmpGridView.TabIndex = 5;
            // 
            // EmpForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 566);
            this.Controls.Add(this.EmpGridView);
            this.Controls.Add(this.CancelEmpButton);
            this.Controls.Add(this.SubmitEmpButton);
            this.Controls.Add(this.DelEmpButton);
            this.Controls.Add(this.EditEmpButton);
            this.Controls.Add(this.AddEmpButton);
            this.Name = "EmpForm1";
            this.Text = "社員一覧";
            this.Load += new System.EventHandler(this.EmpForm1_Load);
            this.Closed += new System.EventHandler(this.EmpForm1_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddEmpButton;
        private System.Windows.Forms.Button EditEmpButton;
        private System.Windows.Forms.Button DelEmpButton;
        private System.Windows.Forms.Button SubmitEmpButton;
        private System.Windows.Forms.Button CancelEmpButton;
        public System.Windows.Forms.DataGridView EmpGridView;
    }
}