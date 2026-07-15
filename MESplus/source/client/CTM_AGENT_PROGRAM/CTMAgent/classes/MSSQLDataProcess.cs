using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CTMAgent.classes
{
    class MSSQLDataProcess
    {
        //private const string _strConn = @"Data Source=172.23.25.101,2433;Initial Catalog=QCELLS_3001;User ID=qcells_3001_reader;Password=0433ECF8-1BCC";
        private const string _strConn = @"Data Source=172.23.25.101,2433;Initial Catalog=QCELLS_3001;User ID=qcells_3001_writer;Password=4B5A-ABE5";
        
       
        //public static DataTable dt = new DataTable();

        public static DataTable SelectData(string sql)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader rdr = comm.ExecuteReader())
                        {
                            //dt.Clear();
                            dt.Load(rdr);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }

        }

        public static void UpdateData(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    conn.Open();
                    
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        //using (SqlDataReader rdr = comm.ExecuteReader())
                       // {
                            comm.CommandText = sql;
                            comm.CommandType = CommandType.Text;
                            comm.ExecuteNonQuery();
                       // }

                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }






        #region FrameWorkTest함수

        //컬럼들을 받아서 데이터테이블을 생성하는 함수
        public static DataTable MakeDataTable(string[] columns)
        {
            //데이터 테이블 생성
            DataTable dataTable = new DataTable();

            //컬럼 추가
            foreach (string column in columns)
            {
                dataTable.Columns.Add(column);
            }

            //리턴
            return dataTable;
        }


        //내용들을 받아서 데이터 테이블에 차례대로 입력
        public static DataTable InsertDataInDataTable(DataTable dataTable, string[] contents)
        {
            DataRow dataRow = dataTable.NewRow();

            int i = 0;

            foreach (string content in contents)
            {
                dataRow[i] = content;
                i++;
            }

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }








        #endregion


    }
}
