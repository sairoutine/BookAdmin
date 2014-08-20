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
    public partial class EmpForm2 : Form
    {
        public string SelectedEMP_CODE;

        //Todo
        //継承を用いて
        //新規登録フォームと編集フォームの分離

        public EmpForm2()
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

            //Enter及びEscボタンの挙動
            this.AcceptButton = this.AddEmp2Button;
            this.CancelButton = this.cancelEmp2Button;
            #endregion


            #region テキストボックス設定
            this.EMP_CODE.MaxLength = 4;
            this.EMP_MAIL.MaxLength = 255;
            #endregion

        }

        private void EmpForm2_Load(object sender, EventArgs e)
        {
            //コンボボックスに部署名一覧を表示
            foreach (DataRow r in ((EmpForm1)this.Owner).postTable.Rows)
            {
                EMP_POST.Items.Add(r["EMP_POST_NAME"]);
            }
            //コンボボックスの中を編集禁止する
            EMP_POST.DropDownStyle = ComboBoxStyle.DropDownList;


            if (SelectedEMP_CODE != null)
            {
                this.Text = "編集";

                //選択された行
                DataRow row = ((EmpForm1)this.Owner).dataTable.Rows.Find(SelectedEMP_CODE);

                EMP_CODE.Text   = row["EMP_CODE"].ToString();

                EMP_NAME.Text   = row["EMP_NAME"].ToString();

                EMP_NAME_K.Text = row["EMP_NAME_K"].ToString();
                EMP_MAIL.Text   = row["EMP_MAIL"].ToString();

                EMP_POST.SelectedIndex = int.Parse(row["EMP_POST"].ToString());

                //DataTableに新規追加された行ならEMP_CODEも編集可能にする
                //既存のEMP_CODEは本貸し出し記録と関連してるので、編集させない
                if (row.RowState != DataRowState.Added) { EMP_CODE.ReadOnly = true; }


            }
            else {
                this.Text = "新規登録";

                EMP_POST.SelectedIndex = 0;

            }

        }

        private void AddEmp2Button_Click(object sender, EventArgs e) {
            //入力チェック

            if (SelectedEMP_CODE != EMP_CODE.Text && ((EmpForm1)this.Owner).dataTable.Rows.Find(EMP_CODE.Text) != null)
            {
                MessageBox.Show("すでにその社員コードは存在しています", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }


            Regex regex;
            regex = new Regex(@"^[0-9]{1,4}$");
            if (!regex.IsMatch(EMP_CODE.Text))
            {
                MessageBox.Show("社員コードは1文字以上4文字以内の数字で入力してください", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }
            regex = new Regex(@"^.+$");
            if (!regex.IsMatch(EMP_NAME.Text))
            {
                MessageBox.Show("社員名を入力してください", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }
            regex = new Regex(@"^\p{IsKatakana}+$");
            if (!regex.IsMatch(EMP_NAME_K.Text))
            {
                MessageBox.Show("社員カナは全角カナで入力してください", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }

            if (EMP_MAIL.Text.Length > 255)
            {
                MessageBox.Show("メールアドレスが長すぎます。", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }
            regex = new Regex(@"^([^@\s]+[@]([^.\s]+[.]){1,}[^.\s]+)?$");
            if (!regex.IsMatch(EMP_MAIL.Text))
            {
                MessageBox.Show("メールアドレスを正しい形式で入力してください", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }


            regex = new Regex(@"^[0-9]+$");
            if (!regex.IsMatch(EMP_POST.SelectedIndex.ToString()))
            {
                MessageBox.Show("カテゴリー名が正しくありません", "新規登録／編集", MessageBoxButtons.OK);
                return;
            }



            //更新作業
            if(SelectedEMP_CODE != null){
                DataRow r = ((EmpForm1)this.Owner).dataTable.Rows.Find(SelectedEMP_CODE);
                r["EMP_CODE"] = EMP_CODE.Text;
                r["EMP_NAME"] = EMP_NAME.Text;
                r["EMP_NAME_K"] = EMP_NAME_K.Text;
                r["EMP_MAIL"] = EMP_MAIL.Text;
                r["EMP_POST"] = EMP_POST.SelectedIndex.ToString();

                r["EMP_POST_NAME"] = EMP_POST.Text;

            }
            else{ //新規登録作業

                DataRow r = ((EmpForm1)this.Owner).dataTable.NewRow();
                r["EMP_CODE"] = EMP_CODE.Text;
                r["EMP_NAME"] = EMP_NAME.Text;
                r["EMP_NAME_K"] = EMP_NAME_K.Text;
                r["EMP_MAIL"] = EMP_MAIL.Text;
                r["EMP_POST"] = EMP_POST.SelectedIndex.ToString();

                r["EMP_POST_NAME"] = EMP_POST.Text;

                ((EmpForm1)this.Owner).dataTable.Rows.Add(r);
            }

            ((EmpForm1)this.Owner).editFlag = true;
            this.Close();
        }

        private void cancelEmp2Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
