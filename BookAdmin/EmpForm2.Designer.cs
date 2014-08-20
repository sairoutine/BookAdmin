namespace BookAdmin
{
    partial class EmpForm2
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
            this.AddEmp2Button = new System.Windows.Forms.Button();
            this.cancelEmp2Button = new System.Windows.Forms.Button();
            this.EMP_CODE = new System.Windows.Forms.TextBox();
            this.EMP_NAME = new System.Windows.Forms.TextBox();
            this.EMP_NAME_K = new System.Windows.Forms.TextBox();
            this.EMP_MAIL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EMP_POST = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AddEmp2Button
            // 
            this.AddEmp2Button.Location = new System.Drawing.Point(76, 141);
            this.AddEmp2Button.Name = "AddEmp2Button";
            this.AddEmp2Button.Size = new System.Drawing.Size(75, 23);
            this.AddEmp2Button.TabIndex = 0;
            this.AddEmp2Button.Text = "OK";
            this.AddEmp2Button.UseVisualStyleBackColor = true;
            this.AddEmp2Button.Click += new System.EventHandler(this.AddEmp2Button_Click);
            // 
            // cancelEmp2Button
            // 
            this.cancelEmp2Button.Location = new System.Drawing.Point(157, 141);
            this.cancelEmp2Button.Name = "cancelEmp2Button";
            this.cancelEmp2Button.Size = new System.Drawing.Size(75, 23);
            this.cancelEmp2Button.TabIndex = 1;
            this.cancelEmp2Button.Text = "Cancel";
            this.cancelEmp2Button.UseVisualStyleBackColor = true;
            this.cancelEmp2Button.Click += new System.EventHandler(this.cancelEmp2Button_Click);
            // 
            // EMP_CODE
            // 
            this.EMP_CODE.Location = new System.Drawing.Point(88, 12);
            this.EMP_CODE.Name = "EMP_CODE";
            this.EMP_CODE.Size = new System.Drawing.Size(137, 19);
            this.EMP_CODE.TabIndex = 2;
            // 
            // EMP_NAME
            // 
            this.EMP_NAME.Location = new System.Drawing.Point(88, 38);
            this.EMP_NAME.Name = "EMP_NAME";
            this.EMP_NAME.Size = new System.Drawing.Size(137, 19);
            this.EMP_NAME.TabIndex = 3;
            // 
            // EMP_NAME_K
            // 
            this.EMP_NAME_K.Location = new System.Drawing.Point(88, 64);
            this.EMP_NAME_K.Name = "EMP_NAME_K";
            this.EMP_NAME_K.Size = new System.Drawing.Size(137, 19);
            this.EMP_NAME_K.TabIndex = 5;
            // 
            // EMP_MAIL
            // 
            this.EMP_MAIL.Location = new System.Drawing.Point(88, 90);
            this.EMP_MAIL.Name = "EMP_MAIL";
            this.EMP_MAIL.Size = new System.Drawing.Size(137, 19);
            this.EMP_MAIL.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "社員コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "社員名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "社員カナ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "メールアドレス";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "所属";
            // 
            // EMP_POST
            // 
            this.EMP_POST.FormattingEnabled = true;
            this.EMP_POST.Location = new System.Drawing.Point(88, 115);
            this.EMP_POST.Name = "EMP_POST";
            this.EMP_POST.Size = new System.Drawing.Size(137, 20);
            this.EMP_POST.TabIndex = 14;
            // 
            // EmpForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 171);
            this.Controls.Add(this.EMP_POST);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EMP_MAIL);
            this.Controls.Add(this.EMP_NAME_K);
            this.Controls.Add(this.EMP_NAME);
            this.Controls.Add(this.EMP_CODE);
            this.Controls.Add(this.cancelEmp2Button);
            this.Controls.Add(this.AddEmp2Button);
            this.Name = "EmpForm2";
            this.Text = "EmpForm2";
            this.Load += new System.EventHandler(this.EmpForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddEmp2Button;
        private System.Windows.Forms.Button cancelEmp2Button;
        private System.Windows.Forms.TextBox EMP_CODE;
        private System.Windows.Forms.TextBox EMP_NAME;
        private System.Windows.Forms.TextBox EMP_NAME_K;
        private System.Windows.Forms.TextBox EMP_MAIL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox EMP_POST;
    }
}