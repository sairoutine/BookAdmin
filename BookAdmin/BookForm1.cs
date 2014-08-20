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
    public partial class BookForm1 : Form
    {
        public bool editFlag = false; //キャンセル時に確認するために必要
        private MyModel sqlConnection;
        public DataTable dataTable;

        public BookForm1()
        {
            InitializeComponent();

            #region DataGridView設定
            //複数行の選択禁止
            this.BookGridView.MultiSelect = false;

            //行全体を選択するようにする
            this.BookGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            //DataGridView独自の行追加を禁じる
            this.BookGridView.AllowUserToAddRows = false;

            //DataGridView独自の行削除を禁じる
            this.BookGridView.AllowUserToDeleteRows = false;

            //ユーザーが行の長さを変えるのを禁じる
            this.BookGridView.AllowUserToResizeRows = false;


            //行ヘッダーを非表示にする
            this.BookGridView.RowHeadersVisible = false;

            //
            this.BookGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DataGridViewによるセルの編集を禁止する
            this.BookGridView.ReadOnly = true;
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


        private void BookForm1_Load(object sender, EventArgs e)
        {
            this.dataTable = this.sqlConnection.ReadAllBOOKTable();

            BookGridView.DataSource = dataTable;

            //行ヘッダー書き換え
            foreach (DataGridViewColumn c in BookGridView.Columns)
            {
                if (Settings.PermitBookColumn.ContainsKey(c.Name) && Settings.PermitBookColumn[c.Name] > 0)
                {

                    BookGridView.Columns[c.Name].HeaderText = Settings.ColumnName[c.Name];
                    BookGridView.Columns[c.Name].Width = Settings.PermitBookColumn[c.Name];
                }
                else
                {
                    BookGridView.Columns[c.Name].Visible = false;
                }

            }

            //行をダブルクリックすると編集画面が開く
            BookGridView.CellDoubleClick += OnCellContentDoubleClick;


            //
            //BookGridView.Columns["BOOK_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //ISBNは全て表示されるようにする
            //BookGridView.Columns["BOOK_ISBN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //BookGridView.Columns["BOOK_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }

        private void BookForm1_Closed(object sender, EventArgs e)
        {
            this.sqlConnection.Close();
        }

        protected void OnCellContentDoubleClick(object sender, DataGridViewCellEventArgs args)
        {

            int row = args.RowIndex;

            //rowが-1ならカラムヘッダーがダブルクリックされた
            if (row == -1) { return; }

            BookForm2 bookForm2 = new BookForm2();

            bookForm2.SelectedBOOK_ISBN = BookGridView.Rows[row].Cells["BOOK_ISBN"].Value.ToString();

            bookForm2.ShowDialog(this);
            bookForm2.Dispose();
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            BookForm2 f = new BookForm2();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void EditBookButton_Click(object sender, EventArgs e)
        {
            if (BookGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("行を選択してください", "編集", MessageBoxButtons.OK);

                return;
            }

            BookForm2 f = new BookForm2();

            f.SelectedBOOK_ISBN = BookGridView.SelectedRows[0].Cells["BOOK_ISBN"].Value.ToString();

            f.ShowDialog(this);
            f.Dispose();
        }

        private void DelBookButton_Click(object sender, EventArgs e)
        {
            if (BookGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("行を選択してください", "編集", MessageBoxButtons.OK);

                return;
            }

            if (MessageBox.Show("選択した書籍情報を削除しますが\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            string delete_emp_code = BookGridView.SelectedRows[0].Cells["BOOK_ISBN"].Value.ToString();

            if (dataTable.Rows.Find(delete_emp_code)["BOOK_BORROWER"].ToString() != ""
                && MessageBox.Show("借りている人がいますが本当に削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            dataTable.Rows.Find(delete_emp_code).Delete();

            editFlag = true;
        }

        private void BarcodeButton_Click(object sender, EventArgs e)
        {
            BarcodeForm barcodeForm = new BarcodeForm();
            barcodeForm.ShowDialog(this);
            barcodeForm.Dispose();
        }

        private void SubmitBookButton_Click(object sender, EventArgs e)
        {
            if (editFlag == true)
            {
                this.sqlConnection.UpdateBOOKTable(this.dataTable);

                MessageBox.Show("データベースを更新しました。", "更新完了", MessageBoxButtons.OK);
            }
            this.Close();
        }


        private void CancelBookButton_Click(object sender, EventArgs e)
        {
            if (editFlag == true && MessageBox.Show(
                "編集中のデータがありますが、\n終了してもいいですか？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

    }
}
