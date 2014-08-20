using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BookAdmin
{
    public partial class BarcodeForm : Form
    {
        private bool isReading = false; //読み取りフラグ
        private string strBarcode = "";  //バーコード

        public BarcodeForm()
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

        private void BarcodeForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 2)
            {
                //2がバーコード読み取り開始
                this.isReading = true;
                this.strBarcode = "";    //初期化
            }
            else if (e.KeyChar == 3)
            {
                //3がバーコード読み取り終了
                this.isReading = false;

                if(strBarcode.Length != 13){
                    MessageBox.Show("ISBNコードではないようです。", "新規登録／編集", MessageBoxButtons.OK);
                    return;
                }

                if(strBarcode.Substring(0,2) == "19"){
                    MessageBox.Show("本上段のバーコードを読み取ってください。", "新規登録／編集", MessageBoxButtons.OK);
                    return;
                }

                if (((BookForm1)this.Owner).dataTable.Rows.Find(strBarcode) != null)
                {
                    MessageBox.Show("すでにその本は登録されてます。", "新規登録／編集", MessageBoxButtons.OK);
                    return;
                }

                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show("ネットワークに接続されてないので本情報を取得できません", "新規登録／編集", MessageBoxButtons.OK);
                    return;                
                }

                //Amazon APIに問い合わせ
                Newtonsoft.Json.Linq.JContainer d = Amazon.ReadBook(strBarcode);
          
                if(d["Error"] != null){
                    MessageBox.Show("書籍情報がネットワークから取得できませんでした。", "新規登録／編集", MessageBoxButtons.OK);
                    return;   
                }

                
                string isbn =      d["ItemAttributes"]["EANList"]["EANListElement"].ToString();
                string bookname =  d["ItemAttributes"]["Title"].ToString();
                string onsale =    d["ItemAttributes"]["PublicationDate"].ToString();
                string publisher = d["ItemAttributes"]["Publisher"].ToString();
                string url =       "http://www.amazon.co.jp/dp/" + d["ASIN"].ToString() + "/";
                string tag =       "";
                string author;

                //著者が二人以上なら最初の一人のみ登録
                if (d["ItemAttributes"]["Author"].Count() > 1) {
                    author = d["ItemAttributes"]["Author"][0].ToString();
                }
                else{
                    author = d["ItemAttributes"]["Author"].ToString();
                }

                DataRow workRow = ((BookForm1)this.Owner).dataTable.NewRow();

                workRow["BOOK_ISBN"] = isbn;
                workRow["BOOK_NAME"] = bookname;
                workRow["BOOK_AUTHOR"] = author;
                workRow["BOOK_ONSALE"] = onsale;
                workRow["BOOK_PUBLISHER"] = publisher;
                workRow["BOOK_URL"] = url;
                workRow["BOOK_TAG"] = tag;
                workRow["BOOK_LENDINGPERIOD"] = Settings.LendingPeriod;
                ((BookForm1)this.Owner).dataTable.Rows.Add(workRow);

                ((BookForm1)this.Owner).editFlag = true;
                
                
                //本タイトルがフォームラベルに収まるように15文字以上は省略する
                if (bookname.Length > 15)
                {
                    bookname = bookname.Substring(0, 15) + "...";
                }
                
                this.ResultLabel.Text = "「" + bookname + "」を読み取りました";

                //Amazon APIリクエスト制限を守る
                System.Threading.Thread.Sleep(Settings.AmazonRequestInterval);
            }
            else
            {
                //読み取り途中の場合

                if (this.isReading == true)
                {
                    this.strBarcode += e.KeyChar.ToString();
                    e.Handled = true;
                }
            }
        }

        private void BarcodeForm_Load(object sender, EventArgs e)
        {
            //バーコード読み取り時、まずフォームがKeyPressイベントを受け取るようにする
            //これが無いと、CloseButtonがKeyPressを受け取ることになる。
            this.KeyPreview = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
