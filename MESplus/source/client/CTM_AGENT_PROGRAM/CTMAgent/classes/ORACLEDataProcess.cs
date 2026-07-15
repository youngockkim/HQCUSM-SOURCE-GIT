using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace CTMAgent.classes
{
    class ORACLEDataProcess
    {
        // 오라클 연결 문자열        
        // 운영 DB
        private const string _strConn = @"Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.60.110.51)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = M1MES)));User Id=MESMGR;Password=mesmgr;Integrated Security=no;";
      
        //public static DataTable dt = new DataTable();

        public static DataTable SelectData(string sql)
        {
            try
            {
                DataTable dt = new DataTable();

                using (OracleConnection conn = new OracleConnection(_strConn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (OracleCommand comm = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader rdr = comm.ExecuteReader())
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
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                throw ex;
                return null;
            }

        }

        public static void UpdateData(string sql)
        {
            try
            {
                DataTable dt = new DataTable();

                using (OracleConnection conn = new OracleConnection(_strConn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (OracleCommand comm = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader rdr = comm.ExecuteReader())
                        {
                            comm.CommandText = sql;
                            comm.CommandType = CommandType.Text;
                            comm.ExecuteNonQuery();
                        }
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
