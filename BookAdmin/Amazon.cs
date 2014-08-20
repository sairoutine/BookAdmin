using System;
using System.Collections;

using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace BookAdmin
{

    class Amazon
    {
        static public Newtonsoft.Json.Linq.JContainer ReadBook(string isbncode)
        {
            /* API詳細 http://blog.livedoor.jp/dankogai/archives/51227901.html
             * 個人サービスなので接続は保障しかねる
             * 楽天APIの方が楽そう
             */
            string url = "http://api.dan.co.jp/asin/" + Amazon.isbn2asin(isbncode) + "/amazon";

            string jsondata = "";
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                System.IO.Stream st = wc.OpenRead(url);

                System.IO.StreamReader sr = new System.IO.StreamReader(st, System.Text.Encoding.GetEncoding("UTF-8"));

                jsondata = sr.ReadToEnd();

                st.Close();
                wc.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("書籍情報取得エラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }

            /* 厳密にはJSONデータではなくJSONPデータなので
             * "amazon(JSONデータ);\n" の形式がjsondata変数に入ってる
             * よって不要な部分をsubstring.
             */
            jsondata = jsondata.Substring(0, jsondata.Length - 3).Substring(7);

            Newtonsoft.Json.Linq.JContainer jobj = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JContainer>(jsondata);

            return jobj;
        }

        static public string isbn2asin(string isbn)
        {

            string code = isbn.Substring(3, 10);		//最初3桁は国識別コードなので不要
            string cd = cd11(code);                     //check digit計算

            return isbn.Substring(3, 9) + cd;
        }


        static public string cd11(string code)
        {
            int cd = 0;

            int n;
            for (int pos = 10; pos >= 2; pos--)
            {
                n = int.Parse(code.Substring(10 - pos, 1));
                cd += n * pos;
            }
            cd = cd % 11;
            cd = 11 - cd;
            if (cd == 10)
            {
                return "X";
            }

            else if (cd == 11)
            {
                return "0";
            }
            
            return cd.ToString();
        }
    }
}
