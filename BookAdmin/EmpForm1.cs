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
    public partial class EmpForm1 : Form
    {
        public bool editFlag = false; //キャンセル時に確認するために必要

        //接続メンバ
        public MyModel sqlConnection;

        //SQLから読み込んだ社員情報テーブルメンバ
        public DataTable dataTable;

        //SQLから読み込んだ役職情報テーブルメンバ
        public DataTable postTable;

        //社員情報を削除するときに読み込まれる
        public DataTable bookTable;

        public EmpForm1()
        {
            InitializeComponent();

            #region DataGridView設定
            //複数行の選択禁止
            this.EmpGridView.MultiSelect = false;

            //行全体を選択するようにする
            this.EmpGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            //DataGridView独自の行追加を禁じる
            this.EmpGridView.AllowUserToAddRows = false;

            //DataGridView独自の行削除を禁じる
            this.EmpGridView.AllowUserToDeleteRows = false;

            //ユーザーが行の長さを変えるのを禁じる
            this.EmpGridView.AllowUserToResizeRows = false;

            //行ヘッダーを非表示にする
            this.EmpGridView.RowHeadersVisible = false;

            //行をグリッドいっぱいに表示する
            this.EmpGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DataGridViewによるセルの編集を禁止する
            this.EmpGridView.ReadOnly = true;
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

        private void EmpForm1_Load(object sender, EventArgs e)
        {
            //社員情報読み込み
            this.dataTable = this.sqlConnection.ReadEMPTable();

            EmpGridView.DataSource = dataTable;

            //役職読み込み
            this.postTable = this.sqlConnection.ReadEMP_POSTTable();

            //行ヘッダー書き換え
            foreach (DataGridViewColumn c in EmpGridView.Columns)
            {
                if (Settings.PermitEmpColumn.ContainsKey(c.Name) && Settings.PermitEmpColumn[c.Name] > 0)
                {

                    EmpGridView.Columns[c.Name].HeaderText = Settings.ColumnName[c.Name];
                    EmpGridView.Columns[c.Name].Width = Settings.PermitEmpColumn[c.Name];
                }
                else { 
                    EmpGridView.Columns[c.Name].Visible = false;
                }
            }

            //行をダブルクリックすると編集画面が開く
            EmpGridView.CellDoubleClick += OnCellContentDoubleClick;


            //長い本人名も、セルに全て表示されるようにする
            //EmpGridView.Columns["EMP_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void EmpForm1_Closed(object sender, EventArgs e)
        {
            this.sqlConnection.Close();
        }


        protected void OnCellContentDoubleClick(object sender, DataGridViewCellEventArgs args)
        {

            int row = args.RowIndex;

            //rowが-1ならカラムヘッダーがダブルクリックされた
            if (row == -1) { return; }

            EmpForm2 empForm2 = new EmpForm2();

            empForm2.SelectedEMP_CODE = EmpGridView.Rows[row].Cells["EMP_CODE"].Value.ToString();

            empForm2.ShowDialog(this);
            empForm2.Dispose();
        }


        private void AddEmpButton_Click(object sender, EventArgs e)
        {
            EmpForm2 empForm2 = new EmpForm2();
            empForm2.ShowDialog(this);
            empForm2.Dispose();
        }

        private void EditEmpButton_Click(object sender, EventArgs e)
        {
            if(EmpGridView.SelectedRows.Count == 0){
                MessageBox.Show("行を選択してください", "編集", MessageBoxButtons.OK);

                return;
            }

            EmpForm2 empForm2 = new EmpForm2();

            empForm2.SelectedEMP_CODE = EmpGridView.SelectedRows[0].Cells["EMP_CODE"].Value.ToString();

            empForm2.ShowDialog(this);
            empForm2.Dispose();
        }

        private void DelEmpButton_Click(object sender, EventArgs e)
        {
            if (EmpGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("行を選択してください", "編集", MessageBoxButtons.OK);

                return;
            }

            if (MessageBox.Show("選択した社員情報を削除しますが\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            string delete_emp_code = EmpGridView.SelectedRows[0].Cells["EMP_CODE"].Value.ToString();

            if(this.bookTable == null){
                this.bookTable = this.sqlConnection.ReadAllBOOKTable();
            }

            if (this.bookTable.Select("BOOK_BORROWER = '" + delete_emp_code + "'").Length > 0
                && MessageBox.Show("削除する社員は本を借りています。貸し出し記録ごと削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //社員が借りてた本の情報もリセットする
            foreach (DataRow r in this.bookTable.Select("BOOK_BORROWER = '" + delete_emp_code + "'"))
            {
                this.bookTable.Rows.Find(r["BOOK_ISBN"])["BOOK_RETURNDATE"] = null;

                this.bookTable.Rows.Find(r["BOOK_ISBN"])["BOOK_BORROWER"] = null;
            }

            //社員情報削除
            dataTable.Rows.Find(delete_emp_code).Delete();

            editFlag = true;
        }

        private void SubmitEmpButton_Click(object sender, EventArgs e)
        {
            if (editFlag == true)
            {

                if (this.bookTable != null) { this.sqlConnection.UpdateBOOKTable(this.bookTable); }
                this.sqlConnection.UpdateEMPTable(this.dataTable);

                MessageBox.Show("データベースを更新しました。", "更新完了", MessageBoxButtons.OK);

            }
            this.Close();
        }

        private void CancelEmpButton_Click(object sender, EventArgs e)
        {
            if(editFlag == true && MessageBox.Show(
                "編集中のデータがありますが、\n終了してもいいですか？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){
               return;
            }
            this.Close();
          
        }



    }
}
