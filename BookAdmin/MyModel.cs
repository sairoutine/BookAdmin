using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BookAdmin
{
    public class MyModel : IDisposable
    {

        private System.Data.SqlClient.SqlConnection sqlConn;  //SQLコネクション
        private System.Data.SqlClient.SqlTransaction sqlTran; //SQLトランザクション

        private bool disposed = false; //Disposeを何度も呼び出させない


        public MyModel()
        {
            // 接続文字列を生成する

            string connectString =
            "Data Source = " + Settings.DatabaseServer
            + ";Initial Catalog = " + Settings.DatabaseName
            + ";User ID = " + Settings.DatabaseUser
            + ";Password = " + Settings.DatabasePassword;


            try
            {
                this.sqlConn = new System.Data.SqlClient.SqlConnection(connectString);

                sqlConn.Open();

                sqlTran = sqlConn.BeginTransaction();

            }catch(Exception ex){
                MessageBox.Show("データベース接続エラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                sqlConn.Close();

                Application.Exit();
            }
        }

        public DataTable ReadEMPTable()
        {
            ThrowIfDisposed();

            DataTable ds = new DataTable();
            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;


                sqlCom.CommandText = "SELECT * FROM EMP_MASTER left outer join EMP_POST_MASTER on EMP_POST = EMP_POST_ID";
                SqlDataAdapter sqlAda = new SqlDataAdapter();

                sqlAda.SelectCommand = sqlCom;
                sqlAda.Fill(ds);

            }catch(Exception ex){
                MessageBox.Show("データベース読み取りエラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();
            }

            ds.PrimaryKey = new DataColumn[] { ds.Columns["EMP_CODE"] };

            return ds;
        }
        public DataTable ReadEMP_POSTTable()
        {
            ThrowIfDisposed();

            DataTable ds = new DataTable();
            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;


                sqlCom.CommandText = "SELECT * FROM EMP_POST_MASTER;";
                SqlDataAdapter sqlAda = new SqlDataAdapter();

                sqlAda.SelectCommand = sqlCom;
                sqlAda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベース読み取りエラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();

            }

            ds.PrimaryKey = new DataColumn[] { ds.Columns["EMP_POST_ID"] };

            return ds;
        }



        public DataTable ReadAllBOOKTable()
        {
            ThrowIfDisposed();

            DataTable ds = new DataTable();
            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;


                sqlCom.CommandText = "SELECT * FROM BOOK_MASTER";

                SqlDataAdapter sqlAda = new SqlDataAdapter();

                sqlAda.SelectCommand = sqlCom;
                sqlAda.Fill(ds);

            } catch(Exception ex)
            {
                MessageBox.Show("データベース読み取りエラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();

            }
            ds.PrimaryKey = new DataColumn[] { ds.Columns["BOOK_ISBN"] };
            return ds;
        }

        public DataTable ReadArrearTable()
        {
            ThrowIfDisposed();

            DataTable ds = new DataTable();
            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;

                string returndate = DateTime.Today.ToString("yyyy-MM-dd");
                sqlCom.CommandText = "SELECT * from BOOK_MASTER left outer join EMP_MASTER on BOOK_BORROWER = EMP_CODE where  BOOK_RETURNDATE <> '' and convert(datetime,BOOK_RETURNDATE) < '" + returndate + "';";

                SqlDataAdapter sqlAda = new SqlDataAdapter();

                sqlAda.SelectCommand = sqlCom;
                sqlAda.Fill(ds);

            } catch(Exception ex)
            {
                MessageBox.Show("データベース読み取りエラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();

            }
            ds.PrimaryKey = new DataColumn[] { ds.Columns["BOOK_ISBN"] };
            return ds;
        }

        public DataTable SearchBOOKTable(string key, string searchword)
        {
            ThrowIfDisposed();

            DataTable ds = new DataTable();
            try
            {

                string where_q = "";
                if (searchword != "")
                {
                    where_q = " where "+key+" like @SearchWord";
                }

                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;

                sqlCom.CommandText = "SELECT * from BOOK_MASTER left outer join EMP_MASTER on BOOK_BORROWER = EMP_CODE" + where_q;
                sqlCom.Parameters.Add("@SearchWord", SqlDbType.Text).Value = "%"+searchword+"%";


                SqlDataAdapter sqlAda = new SqlDataAdapter();

                sqlAda.SelectCommand = sqlCom;
                sqlAda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベース読み取りエラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();

            }
            ds.PrimaryKey = new DataColumn[] { ds.Columns["BOOK_ISBN"] };
            return ds;
        }

        public void UpdateEMPTable(DataTable ds) {
            ThrowIfDisposed();

            StringBuilder query = new StringBuilder();

            //ToDo
            //・テーブルのカラム追加に対応できるようカラムでループ処理
            foreach(DataRow r in ds.Rows){
                switch (r.RowState)
                {
                    case DataRowState.Added:        // 追加された状態
                        query.Append("insert into EMP_MASTER VALUES(");
                        query.Append("'" + r["EMP_CODE"] + "', ");
                        query.Append("'" + r["EMP_NAME"] + "', ");
                        query.Append("'" + r["EMP_NAME_K"] + "', ");
                        query.Append("'" + r["EMP_MAIL"] + "', ");
                        query.Append("'" + r["EMP_POST"] + "'");
                        query.Append(");");

                        break;

                    case DataRowState.Deleted:      // 削除された状態
                        query.Append("delete from EMP_MASTER where EMP_CODE = '" + r["EMP_CODE", DataRowVersion.Original] + "';");
                        break;

                    case DataRowState.Modified:     // 変更された状態
                        query.Append("update EMP_MASTER set ");
                        query.Append("EMP_CODE = '" + r["EMP_CODE"] + "', ");
                        query.Append("EMP_NAME = '" + r["EMP_NAME"] + "', ");
                        query.Append("EMP_NAME_K = '" + r["EMP_NAME_K"] + "', ");
                        query.Append("EMP_MAIL = '" + r["EMP_MAIL"] + "', ");
                        query.Append("EMP_POST = '" + r["EMP_POST"] + "' ");
                        query.Append("where EMP_CODE = '" + r["EMP_CODE", DataRowVersion.Original] + "';");

                        break;

                    case DataRowState.Unchanged:    // 変更なしの状態
                        break;

                    case DataRowState.Detached:     // 作成直後で、DataTableに追加されていない状態
                        break;
                }
            
            }

            //クエリーのままExecuteNonQueryしないようにする
            if(query.ToString() == ""){ return; }

            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;

                sqlCom.CommandText = query.ToString();
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベース更新エラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();
            }
        }

        public void UpdateBOOKTable(DataTable ds)
        {
            ThrowIfDisposed();

            StringBuilder query = new StringBuilder();

            foreach(DataRow r in ds.Rows){
                switch (r.RowState)
                {
                    //ToDo
                    //Add文のクエリにカラム名も含める
                    case DataRowState.Added:        // 追加された状態
                        query.Append("insert into BOOK_MASTER VALUES(");
                        query.Append("'" + r["BOOK_ISBN"] + "', ");
                        query.Append("'" + r["BOOK_NAME"] + "', ");
                        query.Append("'" + r["BOOK_AUTHOR"] + "', ");
                        query.Append("'" + r["BOOK_ONSALE"] + "', ");
                        query.Append("'" + r["BOOK_PUBLISHER"] + "', ");
                        query.Append("'" + r["BOOK_URL"] + "', ");
                        query.Append("'" + r["BOOK_TAG"] + "', ");
                        query.Append("'" + r["BOOK_LENDINGPERIOD"] + "', "); //int
                        query.Append("'" + r["BOOK_BORROWER"] + "', ");
                        query.Append("'" + r["BOOK_RETURNDATE"] + "'");
                        query.Append(");");

                        break;

                    case DataRowState.Deleted:      // 削除された状態
                        query.Append("delete from BOOK_MASTER where BOOK_ISBN = '" + r["BOOK_ISBN", DataRowVersion.Original] + "';");
                        break;

                    case DataRowState.Modified:     // 変更された状態
                        query.Append("update BOOK_MASTER set ");
                        query.Append("BOOK_ISBN = '" + r["BOOK_ISBN"] + "', ");
                        query.Append("BOOK_NAME = '" + r["BOOK_NAME"] + "', ");
                        query.Append("BOOK_AUTHOR = '" + r["BOOK_AUTHOR"] + "', ");
                        query.Append("BOOK_ONSALE = '" + r["BOOK_ONSALE"] + "', ");
                        query.Append("BOOK_PUBLISHER = '" + r["BOOK_PUBLISHER"] + "', ");
                        query.Append("BOOK_URL = '" + r["BOOK_URL"] + "', ");
                        query.Append("BOOK_TAG = '" + r["BOOK_TAG"] + "', ");
                        query.Append("BOOK_BORROWER = '" + r["BOOK_BORROWER"] + "', ");
                        query.Append("BOOK_RETURNDATE = '" + r["BOOK_RETURNDATE"] + "', ");
                        query.Append("BOOK_LENDINGPERIOD = '" + r["BOOK_LENDINGPERIOD"] + "'");
                        query.Append("where BOOK_ISBN = '" + r["BOOK_ISBN", DataRowVersion.Original] + "';");

                        break;

                    case DataRowState.Unchanged:    // 変更なしの状態
                        break;

                    case DataRowState.Detached:     // 作成直後で、DataTableに追加されていない状態
                        break;
                }
            
            }


            //クエリーが空のままExecuteNonQueryしないようにする
            if (query.ToString() == "") { return; }

            try
            {
                //クエリーの生成
                SqlCommand sqlCom = new SqlCommand();

                //クエリー送信先及びトランザクションの指定
                sqlCom.Connection = this.sqlConn;
                sqlCom.Transaction = this.sqlTran;

                sqlCom.CommandText = query.ToString();
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベース更新エラー " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlTran.Rollback();
                sqlTran.Dispose();

                sqlConn.Close();
                sqlConn.Dispose();
                Application.Exit();
            }
        }

        private void ThrowIfDisposed()
        {
            if (disposed) throw new ObjectDisposedException(GetType().FullName);

        }

        public void Dispose()
        {
            Dispose(true); //マネージリソースも明示的に開放する。
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (this.disposed)
                {
                    //既に呼びだしずみであるならばなんもしない
                    return;
                }

                this.disposed = true;

                if (disposing)
                {
                    //ここにマネージリソースの解放を実装
                }

                //マネージリソースの開放

                if (this.sqlTran.Connection != null)
                {
                    this.sqlTran.Commit();
                    this.sqlTran.Dispose();
                }

                if (this.sqlConn.State != ConnectionState.Closed)
                {
                    this.sqlConn.Close();
                    this.sqlConn.Dispose();
                }
            }
        }

        public void Close()
        {
            this.Dispose();
        }

        ~MyModel() {
            this.Dispose(false); //マネージリソースの開放はGCに任せる
        }
    }
}
