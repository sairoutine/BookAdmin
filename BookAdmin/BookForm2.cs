using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BookAdmin
{
    public partial class BookForm2 : Form
    {
        public string SelectedBOOK_ISBN = "";
        public int Mode;



        public BookForm2(params int[] mode)
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

            //Enter及びEscの挙動
            this.AcceptButton = this.AddBook2Button;
            this.CancelButton = this.CancelBook2Button;

            #endregion

            #region テキストボックス設定
            this.BOOK_ISBN.MaxLength = 13;
            this.BOOK_ONSALE.MaxLength = 10;
            this.BOOK_URL.MaxLength = 255;
            this.BOOK_LENDINGPERIOD.TextAlign = HorizontalAlignment.Right;
            this.BOOK_LENDINGPERIOD.Minimum = 1;
            #endregion

        }


        private void BookForm2_Load(object sender, EventArgs e)
        {
            if (SelectedBOOK_ISBN != "")
            {
                this.Text = "編集";
                DataRow row = ((BookForm1)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN);
                BOOK_ISBN.Text = row["BOOK_ISBN"].ToString();
                BOOK_NAME.Text = row["BOOK_NAME"].ToString();
                BOOK_AUTHOR.Text = row["BOOK_AUTHOR"].ToString();
                BOOK_ONSALE.Text = row["BOOK_ONSALE"].ToString();
                BOOK_PUBLISHER.Text = row["BOOK_PUBLISHER"].ToString();
                BOOK_URL.Text = row["BOOK_URL"].ToString();
                BOOK_TAG.Text = row["BOOK_TAG"].ToString();
                BOOK_LENDINGPERIOD.Value = decimal.Parse(row["BOOK_LENDINGPERIOD"].ToString());

                if (row.RowState != DataRowState.Added)
                {
                    BOOK_ISBN.ReadOnly = true;
                    BOOK_NAME.Focus();
                }
                else {
                    BOOK_ISBN.Focus();
                }
            }
            else
            {
                this.Text = "新規登録";
                this.BOOK_LENDINGPERIOD.Value = Settings.LendingPeriod;
                this.BOOK_ISBN.Focus();
            }
        }

        private void AddBook2Button_Click(object sender, EventArgs e)
        {
            //入力チェック


            if (SelectedBOOK_ISBN != BOOK_ISBN.Text && ((BookForm1)this.Owner).dataTable.Rows.Find(BOOK_ISBN.Text) != null)
            {
                MessageBox.Show("すでにその本は存在しています", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }

            Regex regex;
            regex = new Regex(@"^[0-9]{13}$");
            if (!regex.IsMatch(BOOK_ISBN.Text))
            {
                MessageBox.Show("ISBNコードは13桁の数字を入力してください。", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }
            regex = new Regex(@"^[0-9\-]{0,10}$");
            if (!regex.IsMatch(BOOK_ONSALE.Text))
            {
                MessageBox.Show("発売日は2014-06-03のような形式で入力してください。", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }

            if (BOOK_URL.Text.Length > 255)
            {
                MessageBox.Show("正しいURLではありません", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }
            regex = new Regex(@"^(https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+)?$");
            if (!regex.IsMatch(BOOK_URL.Text))
            {
                MessageBox.Show("正しいURLではありません", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }



            //更新作業
            if (SelectedBOOK_ISBN != "")
            {
                DataRow r = ((BookForm1)this.Owner).dataTable.Rows.Find(SelectedBOOK_ISBN);
                r["BOOK_ISBN"] = BOOK_ISBN.Text;
                r["BOOK_NAME"] = BOOK_NAME.Text;

                r["BOOK_AUTHOR"] = BOOK_AUTHOR.Text;
                r["BOOK_ONSALE"] = BOOK_ONSALE.Text;
                r["BOOK_PUBLISHER"] = BOOK_PUBLISHER.Text;
                r["BOOK_URL"] = BOOK_URL.Text;
                r["BOOK_TAG"] = BOOK_TAG.Text;
                r["BOOK_LENDINGPERIOD"] = BOOK_LENDINGPERIOD.Value;
            }
            else
            { //新規登録作業

                DataRow workRow = ((BookForm1)this.Owner).dataTable.NewRow();

                workRow["BOOK_ISBN"] = BOOK_ISBN.Text;
                workRow["BOOK_NAME"] = BOOK_NAME.Text;
                workRow["BOOK_AUTHOR"] = BOOK_AUTHOR.Text;
                workRow["BOOK_ONSALE"] = BOOK_ONSALE.Text;
                workRow["BOOK_PUBLISHER"] = BOOK_PUBLISHER.Text;
                workRow["BOOK_URL"] = BOOK_URL.Text;
                workRow["BOOK_TAG"] = BOOK_TAG.Text;
                workRow["BOOK_LENDINGPERIOD"] = BOOK_LENDINGPERIOD.Value;

                ((BookForm1)this.Owner).dataTable.Rows.Add(workRow);
            }

            ((BookForm1)this.Owner).editFlag = true;
            this.Close();
        }

        private void CancelBook2Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
