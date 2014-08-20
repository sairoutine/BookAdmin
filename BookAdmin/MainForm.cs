using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace BookAdmin
{
    public partial class MainForm : Form
    {
        //Todo
        //基本的に全ての処理はtry catchで包む

        public MainForm()
        {
            InitializeComponent();

            #region フォーム設定

            //フォームの最大化ボタンを非表示にする
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンを非表示にする
            this.MinimizeBox = !this.MinimizeBox;

            //フォームの初期位置をデスクトップの真ん中にする
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームのサイズ変更を禁じる
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            #endregion
        }

        private void EmpMainButton_Click(object sender, EventArgs e)
        {
            EmpForm1 empForm1 = new EmpForm1();
            empForm1.ShowDialog();
            empForm1.Dispose();
        }

        private void BookMainButton_Click(object sender, EventArgs e)
        {
            BookForm1 bookForm1 = new BookForm1();
            bookForm1.ShowDialog();
            bookForm1.Dispose();
        }

        private void LendMainButton_Click(object sender, EventArgs e)
        {
            BookCTLForm bookCTLForm = new BookCTLForm();
            bookCTLForm.ShowDialog();
            bookCTLForm.Dispose();
        }

    }
}
