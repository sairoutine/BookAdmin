using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace BookAdmin
{
    static class Settings
    {
        //Todo
        //外部ファイルから設定の読み出し

        //本の貸し出し期間デフォルト
        static public int LendingPeriod = 7;

        //データベース設定
        static public string DatabaseServer = "*****";
        static public string DatabaseName = "*****";
        static public string DatabaseUser = "*****";
        static public string DatabasePassword = "*****";

        //SQLのカラムに対応するDataGridView上での表示名
        static public readonly Dictionary<string, string> ColumnName = new Dictionary<string, string>() {
                    { "EMP_CODE", "社員コード"},
                    { "EMP_NAME", "社員名"},
                    { "EMP_NAME_K", "社員カナ"},
                    { "EMP_MAIL", "メール"},
                    { "EMP_POST", ""},

                    //EMP_POST_MASTER
                    { "EMP_POST_ID", ""},
                    { "EMP_POST_NAME", "部署"},


                    //BOOK_MASTER
                    { "BOOK_ISBN", "ISBN"},
                    { "BOOK_NAME", "本タイトル"},
                    { "BOOK_AUTHOR", "著者"},
                    { "BOOK_ONSALE", "発売日"},
                    { "BOOK_PUBLISHER", "出版社"},
                    { "BOOK_URL", "URL"},
                    { "BOOK_TAG", "タグ"},
                    { "BOOK_BORROWER", ""},
                    { "BOOK_RETURNDATE", "返却日"},
                    { "BOOK_LENDINGPERIOD", "貸出期間"}
        };

        //EmpDataGridViewに表示させるカラム //GridViewのサイズ:1017
        static public readonly Dictionary<string, int> PermitEmpColumn = new Dictionary<string, int>() {
                    //EMP_MASTER
                    { "EMP_CODE", 80},
                    { "EMP_NAME", 300},
                    { "EMP_NAME_K", 300},
                    { "EMP_MAIL", 250},

                    //EMP_POST_MASTER
                    { "EMP_POST_NAME", 80}
        };

        //BookDataGridViewに表示させるカラム //1016
        static public readonly Dictionary<string, int> PermitBookColumn = new Dictionary<string, int>() {
                    //BOOK_MASTER
                    { "BOOK_ISBN", 100},
                    { "BOOK_NAME", 350},
                    { "BOOK_AUTHOR", 100},
                    { "BOOK_ONSALE", 80},
                    { "BOOK_PUBLISHER", 120},
                    { "BOOK_URL", 100},
                    { "BOOK_TAG", 50},
                    { "BOOK_LENDINGPERIOD", 80}
        };

        //BookCTLGridViewに表示させるカラム //1042
        static public readonly Dictionary<string, int> PermitBookCTLColumn = new Dictionary<string, int>() {
                    //EMP_MASTER
                    { "EMP_NAME", 200},

                    //BOOK_MASTER
                    { "BOOK_NAME", 500},
                    { "BOOK_AUTHOR", 100},
                    { "BOOK_TAG", 50},
                    { "BOOK_RETURNDATE", 80},
                    { "BOOK_LENDINGPERIOD", 80}
        };

        //BookCTLでの書籍を検索する際に対象とするカラム
        static public readonly ArrayList SearchTarget = new ArrayList() {
                    "BOOK_NAME",
                    "BOOK_AUTHOR",
                    "EMP_NAME",
                    "BOOK_TAG"
        };


        //Amazonに問い合わせる回数の制限(ミリ秒)
        static public int AmazonRequestInterval = 1000;
    }
}
