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
    public partial class BookCTLForm2 : Form
    {
        public string SelectedBOOK_ISBN;

        //Todo
        //所属や名前検索でコンボボックスを絞り込める

        //コンボボックスの値に対応した社員コード表を作る
        List<string> emp_code = new List<string>();

        public BookCTLForm2()
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

            //EnterとEscの挙動
            this.AcceptButton = this.OKCTLButton;
            this.CancelButton = this.CancelCTLButton;

            #endregion

        }

        private void BookCTLForm2_Load(object sender, EventArgs e)
        {
            BookNameLabel.Text = ((BookCTLForm)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN)["BOOK_NAME"].ToString();

            this.LendingPeriodUpDown.Value = decimal.Parse(((BookCTLForm)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN)["BOOK_LENDINGPERIOD"].ToString());
            this.LendingPeriodUpDown.TextAlign = HorizontalAlignment.Right;
            this.LendingPeriodUpDown.Maximum = this.LendingPeriodUpDown.Value;
            this.LendingPeriodUpDown.Minimum = 1;

            DataTable ds = ((BookCTLForm)this.Owner).sqlConnection.ReadEMPTable();

            if (ds.Rows.Count <= 0) {
                MessageBox.Show("社員を登録してください", "編集", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            foreach (DataRow c in ds.Rows)
            {
                EmpComboBox.Items.Add(c["EMP_NAME"].ToString());

                //コンボボックスの値に対応した社員コード表を作る
                emp_code.Add(c["EMP_CODE"].ToString());
            }

            EmpComboBox.SelectedIndex = 0;

            EmpComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            EmpComboBox.Focus();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ((BookCTLForm)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN)["BOOK_RETURNDATE"] = DateTime.Today.AddDays((int)this.LendingPeriodUpDown.Value).ToString("yyyy-MM-dd");
            ((BookCTLForm)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN)["BOOK_BORROWER"] = emp_code[EmpComboBox.SelectedIndex];
            ((BookCTLForm)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN)["EMP_NAME"] = EmpComboBox.Text;


            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
