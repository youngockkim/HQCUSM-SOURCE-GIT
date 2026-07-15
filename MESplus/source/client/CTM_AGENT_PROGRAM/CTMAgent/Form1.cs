using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections;

namespace CTMAgent
{
    public partial class Form1 : Form
    {

        private object lockObject = new object();
        private object lockWork = new object();

        public Form1()
        {
            InitializeComponent();
        }


        #region Function

        private string workingFlag = "N";


        // 아이피 검색
        public static string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = string.Empty;
            foreach (IPAddress ia in host.AddressList)
            {
                if (ia.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip = ia.ToString(); break;
                }
            }

            return myip;
        }


        //로그 쓰기
        private void setWorkFlag(string status)
        {
            // 한번에 한 쓰레드만 lock블럭 실행
            lock (lockWork)
            {
                workingFlag = status;
            }
        }

        //로그 쓰기
        private void FN_Write(string sMessage)
        {
            // 한번에 한 쓰레드만 lock블럭 실행
            lock (lockObject)
            {
                string sPath = @"c:\CTM_LOGS\";
                string sFileName = DateTime.Now.ToString("yyyyMMddHH") + ".txt";

                System.IO.DirectoryInfo diNewfolder = new System.IO.DirectoryInfo(sPath);
                if (diNewfolder.Exists == false)
                { diNewfolder.Create(); }

                using (System.IO.StreamWriter sWriter = new System.IO.StreamWriter(sPath + sFileName, true))
                {
                    sWriter.WriteLine(DateTime.Now.ToLongTimeString() + " : " + sMessage);
                }
            }
        }

        //메인 작업
        private void doWork(object callBack)
        {
            lock (lockWork)
            {
                try
                {

                    string ORA_SYSDATE = getOraSysDate();
                    string MS_SYSDATE = getMsSysDate();
                    //string LAST_INF_TIME = getLastInfTime();

                    clearList();

                    addStatus(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ### " + " 리스트 조회 시작");
                    DataTable result = null;
                    result = CTMAgent.classes.MSSQLDataProcess.SelectData(searchSQL(numSearchCount.Value.ToString(), MS_SYSDATE));

                    int totalRowNum = result.Rows.Count;

                    // 0 이면 작업하지 않음
                    if (totalRowNum == 0)
                    {
                        addStatus(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ### " + result.Rows.Count + " 작업 내용 없음!!!");
                        updateLastInfTime(ORA_SYSDATE);
                        return;
                    }


                    addStatus(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ###### " + result.Rows.Count + " 리스트 조회 종료");

                    // 0이 아니면 작업중으로 친다.

                    Application.DoEvents();

                    string EVENTID = "";
                    string CELLBOXID = "";
                    string LAMAID = "";
                    string MATERIALDEFINITIONID = "";
                    string QUALITYGRADE = "";
                    string COLORCLASS = "";
                    string POWERGRADE = "";
                    string PRODUCTDATE = "";
                    string POSITION = "";
                    string RESULT = "";
                    string NCLASS = "";
                    string NCELL = "";
                    string PRODUCTCLASS = "";
                    string PRODUCTTYPE = "";
                    string ACTIVITY = "";
                    string PREVACTIVITY = "";
                    string CUSTOMACTIVITY = "";
                    string PREVCUSTOMACTIVITY = "";
                    string ISUSABLE = "";
                    string SITEID = "";
                    string DESCRIPTION = "";
                    string REASONCODE = "";
                    string COMMENTS = "";
                    string CREATOR = "";
                    string CREATETIME = "";
                    string MODIFIER = "";
                    string MODIFYTIME = "";
                    string LASTEVENTTIME = "";
                    string TID = "";
                    string MES_FLAG = "";
                    string MES_MSG = "";
                    string MES_TIME = "";


                    addStatus(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ### " + result.Rows.Count + " 전송 시작");
                    Application.DoEvents();

                    //시작 로그를 남긴다.
                    FN_Write("ORACLE TIME : " + ORA_SYSDATE + ", START EVENTID : " + result.Rows[0]["EVENTID"].ToString());


                    //event id를 담을 list 생성
                    ArrayList list = new ArrayList();

                    foreach (DataRow dr in result.Rows)
                    {
                        EVENTID = dr["EVENTID"].ToString();

                        list.Add("'" + EVENTID + "'");

                        CELLBOXID = dr["CELLBOXID"].ToString();
                        LAMAID = dr["LAMAID"].ToString();
                        MATERIALDEFINITIONID = dr["MATERIALDEFINITIONID"].ToString();
                        QUALITYGRADE = dr["QUALITYGRADE"].ToString();
                        COLORCLASS = dr["COLORCLASS"].ToString();
                        POWERGRADE = dr["POWERGRADE"].ToString();
                        PRODUCTDATE = dr["PRODUCTDATE"].ToString();
                        POSITION = dr["POSITION"].ToString();
                        RESULT = dr["RESULT"].ToString();
                        NCLASS = dr["NCLASS"].ToString();
                        NCELL = dr["NCELL"].ToString();
                        PRODUCTCLASS = dr["PRODUCTCLASS"].ToString();
                        PRODUCTTYPE = dr["PRODUCTTYPE"].ToString();
                        ACTIVITY = dr["ACTIVITY"].ToString();
                        PREVACTIVITY = dr["PREVACTIVITY"].ToString();
                        CUSTOMACTIVITY = dr["CUSTOMACTIVITY"].ToString();
                        PREVCUSTOMACTIVITY = dr["PREVCUSTOMACTIVITY"].ToString();
                        ISUSABLE = dr["ISUSABLE"].ToString();
                        SITEID = dr["SITEID"].ToString();
                        DESCRIPTION = dr["DESCRIPTION"].ToString();
                        REASONCODE = dr["REASONCODE"].ToString();
                        COMMENTS = dr["COMMENTS"].ToString();
                        CREATOR = dr["CREATOR"].ToString();
                        CREATETIME = dr["CREATETIME"].ToString();
                        MODIFIER = dr["MODIFIER"].ToString();
                        MODIFYTIME = dr["MODIFYTIME"].ToString();
                        LASTEVENTTIME = dr["LASTEVENTTIME"].ToString();
                        TID = dr["TID"].ToString();
                        MES_FLAG = dr["MES_FLAG"].ToString();
                        MES_MSG = dr["MES_MSG"].ToString();
                        MES_TIME = dr["MES_TIME"].ToString();

                        //oracle db에 merge작업
                        CTMAgent.classes.ORACLEDataProcess.UpdateData(mergeSql(
                                                                                EVENTID,
                                                                                CELLBOXID,
                                                                                LAMAID,
                                                                                MATERIALDEFINITIONID,
                                                                                QUALITYGRADE,
                                                                                COLORCLASS,
                                                                                POWERGRADE,
                                                                                NCLASS,
                                                                                NCELL,
                                                                                SITEID,
                                                                                MODIFYTIME,
                                                                                MES_FLAG,
                                                                                MES_MSG,
                                                                                MES_TIME,
                                                                                ORA_SYSDATE
                                                                                ));

                    }

                    string inClause = String.Join(",", list.ToArray());
                    //MS SQL 서버에 mes 플래그랑 시간 업데이트
                    CTMAgent.classes.MSSQLDataProcess.UpdateData(updateSql3(inClause, MS_SYSDATE));
                    //CTMAgent.classes.MSSQLDataProcess.UpdateData(updateSql(EVENTID, CELLBOXID, SITEID, MODIFYTIME, MS_SYSDATE));
                                
                    //ORACLE GCM 테이블에 마지막 작업시간 업데이트
                    //updateLastInfTime(MS_SYSDATE);
                    updateLastInfTime(ORA_SYSDATE);

                    addStatus(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ###### " + result.Rows.Count + " 전송 종료");
                    Application.DoEvents();


                    //FN_Write("inClause : " + inClause);
                    //종료 로그를 남긴다.
                    FN_Write("ORACLE TIME : " + ORA_SYSDATE + ", END EVENTID : " + result.Rows[result.Rows.Count - 1]["EVENTID"].ToString());

                }

                catch (Exception e)
                {
                    FN_Write(e.StackTrace);
                    FN_Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + e.Message);
                    addStatus(e.Message);

                }
                finally
                {

                }
            }
        }






        //상태창 갱신
        private void addStatus(string msg)
        {
            if (this.lbxStatus.InvokeRequired)
            {
                lbxStatus.Invoke(new Action(() => addStatus(msg)));
            }
            else
            {
                //lbxStatus.Items.Insert(0, msg);
                //lbxStatus.SelectedIndex = 0;
                lbxStatus.Items.Add(msg);

            }
        }


        //상태창 초기화
        private void clearList()
        {
            if (this.lbxStatus.InvokeRequired)
            {
                lbxStatus.Invoke(new Action(() => lbxStatus.Items.Clear()));
            }
            else
            {
                lbxStatus.Items.Clear();

            }
        }


        //입력값 enable
        private void enableControl(bool enable)
        {
            numInterval.Enabled = enable;
            numSearchCount.Enabled = enable;
        }

       



        #endregion






        #region EVENT



        private void btnEdit_Click(object sender, EventArgs e)
        {
            enableControl(true);
            btnOK.Enabled = true;
            btnEdit.Enabled = false;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            enableControl(false);
            btnOK.Enabled = false;
            btnEdit.Enabled = true;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnOK.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            enableControl(false);


            int interval = (int)numInterval.Value;
            if (interval < 1)
            {
                MessageBox.Show("Interval은 0 이상만 가능합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ThreadPool.QueueUserWorkItem(doWork);
            
            timer1.Interval = interval * 1000;
            timer1.Start();
        }



        //타이머 이벤트
        private void timer1_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(doWork);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();


            btnEdit.Enabled = true;
            btnOK.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            enableControl(false);
        }

        #endregion








        #region SQL function

        //조회 sql
        private string searchSQL(string topSize, string endDate)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT TOP {0} [EVENTID]                                 ", topSize);
            sql.Append("      ,[CELLBOXID]                                ");
            sql.Append("      ,[LAMAID]                                   ");
            sql.Append("      ,[MATERIALDEFINITIONID]                     ");
            sql.Append("      ,[QUALITYGRADE]                             ");
            sql.Append("      ,[COLORCLASS]                               ");
            sql.Append("      ,[POWERGRADE]                               ");
            sql.Append("      ,[PRODUCTDATE]                              ");
            sql.Append("      ,[POSITION]                                 ");
            sql.Append("      ,[RESULT]                                   ");
            sql.Append("      ,[NCLASS]                                   ");
            sql.Append("      ,[NCELL]                                    ");
            sql.Append("      ,[PRODUCTCLASS]                             ");
            sql.Append("      ,[PRODUCTTYPE]                              ");
            sql.Append("      ,[ACTIVITY]                                 ");
            sql.Append("      ,[PREVACTIVITY]                             ");
            sql.Append("      ,[CUSTOMACTIVITY]                           ");
            sql.Append("      ,[PREVCUSTOMACTIVITY]                       ");
            sql.Append("      ,[ISUSABLE]                                 ");
            sql.Append("      ,[SITEID]                                   ");
            sql.Append("      ,[DESCRIPTION]                              ");
            sql.Append("      ,[REASONCODE]                               ");
            sql.Append("      ,[COMMENTS]                                 ");
            sql.Append("      ,[CREATOR]                                  ");
            sql.Append("      ,[CREATETIME]                               ");
            sql.Append("      ,[MODIFIER]                                 ");
            sql.Append("      ,CONVERT(VARCHAR(100), [MODIFYTIME]) AS MODIFYTIME");
            sql.Append("      ,[LASTEVENTTIME]                            ");
            sql.Append("      ,[TID]                                      ");
            sql.Append("      ,[MES_FLAG]                                 ");
            sql.Append("      ,[MES_MSG]                                  ");
            sql.Append("      ,[MES_TIME]                                 ");
            sql.Append("  FROM [QCELLS_3001].[dbo].[CELL_LAMA_INFO] WITH(INDEX(IDX01_CELL_LAMA_INFO))       ");
            sql.Append(" WHERE MES_FLAG = 'N'                             ");
            //sql.AppendFormat(" AND MODIFYTIME BETWEEN  CONVERT(DATETIME, STUFF(STUFF(STUFF('{0}', 9, 0, ' '), 12, 0, ':'), 15, 0, ':'))          ", startDate);
            //sql.AppendFormat("                     AND  CONVERT(DATETIME, STUFF(STUFF(STUFF('{0}', 9, 0, ' '), 12, 0, ':'), 15, 0, ':'))     ", endDate);
            sql.AppendFormat(" AND MODIFYTIME < CONVERT(DATETIME, STUFF(STUFF(STUFF('{0}', 9, 0, ' '), 12, 0, ':'), 15, 0, ':'))     ", endDate);
            //sql.AppendFormat(" ORDER BY EVENTID");

            return sql.ToString();
        }


        //건바이건으로 interface mesflag and time 갱신
        private string updateSql(
                                    string EVENTID,
                                    string CELLBOXID,
                                    string SITEID,
                                    string MODIFYTIME,
                                    string SYSDATE
                                )
        {

            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE [QCELLS_3001].[dbo].[CELL_LAMA_INFO]          ");
            sql.Append("    SET MES_FLAG = 'Y'                                         ");
            sql.AppendFormat(", MES_TIME = '{0}' ", SYSDATE);
            sql.AppendFormat("  WHERE EVENTID = '{0}'    ", EVENTID);
            sql.AppendFormat("    AND CELLBOXID = '{0}'  ", CELLBOXID);
            sql.AppendFormat("    AND SITEID = '{0}'     ", SITEID);
            sql.AppendFormat("    AND MODIFYTIME = '{0}' ", MODIFYTIME);

            return sql.ToString();
        }

        //interface mesflag and time 갱신
        private string updateSql2(
                                    string startDate,
                                    string endDate
                                )
        {

            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE [QCELLS_3001].[dbo].[CELL_LAMA_INFO]                   ");
            sql.Append("    SET MES_FLAG = 'Y'                                         ");
            sql.AppendFormat(", MES_TIME = '{0}' ", endDate);
            sql.Append(" WHERE MES_FLAG = 'N'                             ");
            sql.AppendFormat(" AND MODIFYTIME BETWEEN  CONVERT(DATETIME, STUFF(STUFF(STUFF('{0}', 9, 0, ' '), 12, 0, ':'), 15, 0, ':'))          ", startDate);
            sql.AppendFormat("                     AND  CONVERT(DATETIME, STUFF(STUFF(STUFF('{0}', 9, 0, ' '), 12, 0, ':'), 15, 0, ':'))     ", endDate);

            return sql.ToString();
        }


        //event id in 조건으로 mesflag and time 갱신
        private string updateSql3(
                                    string inClause,
                                    string endDate
                                )
        {

            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE [QCELLS_3001].[dbo].[CELL_LAMA_INFO]                 ");
            sql.Append("    SET MES_FLAG = 'Y'                                         ");
            sql.AppendFormat(", MES_TIME = '{0}' ", endDate);
            sql.AppendFormat(" WHERE EVENTID IN ({0})", inClause);
            
            return sql.ToString();
        }


        private string mergeSql(
                                string EVENTID,
                                string CELLBOXID,
                                string LAMAID,
                                string MATERIALDEFINITIONID,
                                string QUALITYGRADE,
                                string COLORCLASS,
                                string POWERGRADE,
                                string NCLASS,
                                string NCELL,
                                string SITEID,
                                string MODIFYTIME,
                                string MES_FLAG,
                                string MES_MSG,
                                string MES_TIME,
                                string SYSDATE
                               )
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" MERGE INTO IWIPCBXLAM A USING ");
            sql.Append("  (SELECT");
            sql.AppendFormat("   NVL('{0}', ' ') AS EVENTID,", EVENTID);
            sql.AppendFormat("   NVL('{0}', ' ') AS CELLBOXID,", CELLBOXID);
            sql.AppendFormat("   NVL('{0}', ' ') AS LAMAID,", LAMAID);
            sql.AppendFormat("   NVL('{0}', ' ') AS MAT_ID,", MATERIALDEFINITIONID);
            sql.AppendFormat("   NVL('{0}', ' ') AS QUALITYGRADE,", QUALITYGRADE);
            sql.AppendFormat("   NVL('{0}', ' ') AS COLORCLASS,", COLORCLASS);
            sql.AppendFormat("   NVL('{0}', ' ') AS POWERGRADE,", POWERGRADE);
            sql.AppendFormat("   NVL('{0}', ' ') AS NCLASS,", NCLASS);
            sql.AppendFormat("   NVL('{0}', ' ') AS NCELL,", NCELL);
            sql.AppendFormat("   NVL('{0}', ' ') AS SITEID,", SITEID);
            sql.AppendFormat("   NVL('{0}', ' ') AS MODIFYTIME,", MODIFYTIME);
            sql.AppendFormat("   NVL('{0}', ' ') AS MES_FLAG,", MES_FLAG);
            sql.AppendFormat("   NVL('{0}', ' ') AS MES_MSG,", MES_MSG);
            sql.AppendFormat("   NVL('{0}', ' ') AS MES_TIME,", MES_TIME);
            sql.AppendFormat("   NVL('{0}', ' ') AS ZIFWORK_TIME", SYSDATE);
            sql.Append("   FROM DUAL) B                                                     ");
            sql.Append(" ON (    A.EVENTID = B.EVENTID");
            sql.Append("     AND A.CELLBOXID = B.CELLBOXID");
            sql.Append(" 	AND A.SITEID = B.SITEID");
            sql.Append(" 	AND A.MODIFYTIME = B.MODIFYTIME)");
            sql.Append(" WHEN NOT MATCHED THEN                                              ");
            sql.Append(" INSERT (                                                           ");
            sql.Append("   EVENTID, CELLBOXID, LAMAID, MAT_ID, QUALITYGRADE,                ");
            sql.Append("   COLORCLASS, POWERGRADE, NCLASS, NCELL, SITEID,                   ");
            sql.Append("   MODIFYTIME, MES_FLAG, MES_MSG, MES_TIME, ZIFWORK_TIME)           ");
            sql.Append(" VALUES (                                                           ");
            sql.Append("   B.EVENTID, B.CELLBOXID, B.LAMAID, B.MAT_ID, B.QUALITYGRADE,      ");
            sql.Append("   B.COLORCLASS, B.POWERGRADE, B.NCLASS, B.NCELL, B.SITEID,         ");
            sql.Append("   B.MODIFYTIME, B.MES_FLAG, B.MES_MSG, B.MES_TIME, B.ZIFWORK_TIME) ");
            sql.Append(" WHEN MATCHED THEN                                                  ");
            sql.Append(" UPDATE SET                                                         ");
            sql.Append("   A.LAMAID = B.LAMAID,                                             ");
            sql.Append("   A.MAT_ID = B.MAT_ID,                                             ");
            sql.Append("   A.QUALITYGRADE = B.QUALITYGRADE,                                 ");
            sql.Append("   A.COLORCLASS = B.COLORCLASS,                                     ");
            sql.Append("   A.POWERGRADE = B.POWERGRADE,                                     ");
            sql.Append("   A.NCLASS = B.NCLASS,                                             ");
            sql.Append("   A.NCELL = B.NCELL,                                               ");
            sql.Append("   A.MES_FLAG = B.MES_FLAG,                                         ");
            sql.Append("   A.MES_MSG = B.MES_MSG,                                           ");
            sql.Append("   A.MES_TIME = B.MES_TIME,                                         ");
            sql.Append("   A.ZIFWORK_TIME = B.ZIFWORK_TIME                                 ");

            return sql.ToString();

        }

        private string getOraSysDate()
        {
            DataTable result = CTMAgent.classes.ORACLEDataProcess.SelectData("SELECT TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS') AS DT FROM DUAL");
            return result.Rows[0]["DT"].ToString();
        }


        private string getMsSysDate()
        {
            DataTable result = CTMAgent.classes.MSSQLDataProcess.SelectData("SELECT FORMAT(GETDATE(),'yyyyMMddHHmmss') AS DT");
            return result.Rows[0]["DT"].ToString();
        }

        private string getLastInfTime()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DATA_1 ");
            sql.Append("  FROM MGCMTBLDAT ");
            sql.Append("   WHERE TABLE_NAME = '@INTERFACE_TIME'");
            sql.Append("    AND KEY_1 = 'CTM'");

            DataTable result = CTMAgent.classes.ORACLEDataProcess.SelectData(sql.ToString());
            return result.Rows[0]["DATA_1"].ToString();
        }


        private void updateLastInfTime(string updateTime)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE MGCMTBLDAT ");
            sql.AppendFormat("   SET DATA_1 = '{0}'  ", updateTime);
            sql.Append("   WHERE TABLE_NAME = '@INTERFACE_TIME'");
            sql.Append("    AND KEY_1 = 'CTM'");

            CTMAgent.classes.ORACLEDataProcess.UpdateData(sql.ToString());
        }

        #endregion


    }
}
