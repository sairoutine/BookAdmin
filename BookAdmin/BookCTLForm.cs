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
    public partial class BookCTLForm : Form
    {
        public MyModel sqlConnection;

        //SQLから読み込んだ本データ
        public DataTable dataTable;


        public BookCTLForm()
        {
            InitializeComponent();

            
            this.AcceptButton = this.SearchButton;
            this.CancelButton = this.CloseButton;

            #region DataGridView設定
            //複数行の選択禁止
            this.BookCTLGridView.MultiSelect = false;

            //行全体を選択するようにする
            this.BookCTLGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            //DataGridView独自の行追加を禁じる
            this.BookCTLGridView.AllowUserToAddRows = false;

            //DataGridView独自の行削除を禁じる
            this.BookCTLGridView.AllowUserToDeleteRows = false;

            //ユーザーが行の長さを変えるのを禁じる
            this.BookCTLGridView.AllowUserToResizeRows = false;

            //行ヘッダーを非表示にする
            this.BookCTLGridView.RowHeadersVisible = false;

            //
            this.BookCTLGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DataGridViewによるセルの編集を禁止する
            this.BookCTLGridView.ReadOnly = true;
            #endregion

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

            this.sqlConnection = new MyModel();
        }

        private void BookCTLForm_Load(object sender, EventArgs e)
        {
            //検索用コンボボックスの設定
            SearchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 0; i < Settings.SearchTarget.Count; i++)
            {
                string searchTargetName = Settings.ColumnName[Settings.SearchTarget[i].ToString()].ToString();

                //社員名ではなく"借りてる人"で表示したい
                if (searchTargetName == Settings.ColumnName["EMP_NAME"]) { searchTargetName = "借りてる人"; }

                SearchComboBox.Items.Add(searchTargetName);
            }

            SearchComboBox.SelectedIndex = 0;

            //GridViewにデータをバインド
            this.dataTable = this.sqlConnection.SearchBOOKTable(Settings.SearchTarget[SearchComboBox.SelectedIndex].ToString(), SearchTextBox.Text);
            BookCTLGridView.DataSource = dataTable;

            //行ヘッダー書き換え
            foreach (DataGridViewColumn c in BookCTLGridView.Columns)
            {
                if (Settings.PermitBookCTLColumn.ContainsKey(c.Name) && Settings.PermitBookCTLColumn[c.Name] > 0)
                {

                    BookCTLGridView.Columns[c.Name].HeaderText = Settings.ColumnName[c.Name];
                    BookCTLGridView.Columns[c.Name].Width = Settings.PermitBookCTLColumn[c.Name];
                }
                else
                {
                    BookCTLGridView.Columns[c.Name].Visible = false;
                }

            }
        }

        private void BookCTLForm_Closed(object sender, EventArgs e)
        {
            this.sqlConnection.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            this.dataTable = this.sqlConnection.SearchBOOKTable(Settings.SearchTarget[SearchComboBox.SelectedIndex].ToString(), SearchTextBox.Text);
            BookCTLGridView.DataSource = dataTable;


            //本の名前は省略せず表示するようにする
            //BookCTLGridView.Columns["BOOK_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void ArrearButton_Click(object sender, EventArgs e)
        {

            this.dataTable = this.sqlConnection.ReadArrearTable();
            BookCTLGridView.DataSource = dataTable;


            //本の名前は省略せず表示するようにする
            //BookCTLGridView.Columns["BOOK_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }


        private void AddRentalButton_Click(object sender, EventArgs e)
        {
            //行が選択されていない
            if (BookCTLGridView.SelectedRows.Count == 0)
            {
                return;
            }

            string bookisbn = BookCTLGridView.SelectedRows[0].Cells["BOOK_ISBN"].Value.ToString();

            if(dataTable.Rows.Find(bookisbn)["BOOK_BORROWER"].ToString() != ""){
                MessageBox.Show("すでに借りている人がいます", "編集", MessageBoxButtons.OK);
                return;
            }

            BookCTLForm2 f = new BookCTLForm2();
            f.SelectedBOOK_ISBN = bookisbn;
            f.ShowDialog(this);
            f.Close();

            sqlConnection.UpdateBOOKTable(dataTable);

        }

        private void DelRentalButton_Click(object sender, EventArgs e)
        {
            //行が選択されていない
            if (BookCTLGridView.SelectedRows.Count == 0)
            {
                return;
            }

            string bookisbn = BookCTLGridView.SelectedRows[0].Cells["BOOK_ISBN"].Value.ToString();

            if (dataTable.Rows.Find(bookisbn)["BOOK_BORROWER"].ToString() == "")
            {
                MessageBox.Show("まだ誰にも借りられていません", "編集", MessageBoxButtons.OK);
                return;
            }

            string booktitle = dataTable.Rows.Find(bookisbn)["BOOK_NAME"].ToString();
            string bookborrower = dataTable.Rows.Find(bookisbn)["BOOK_RETURNDATE"].ToString();

            if (MessageBox.Show("「" + booktitle + "」の返却をします。", "確認",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataTable.Rows.Find(bookisbn)["BOOK_BORROWER"] = "";
                dataTable.Rows.Find(bookisbn)["BOOK_RETURNDATE"] = "";
                dataTable.Rows.Find(bookisbn)["EMP_NAME"] = "";

                this.sqlConnection.UpdateBOOKTable(dataTable);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
