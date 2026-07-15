using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

using System.Net;
using System.Threading;
using System.IO;


namespace Miracom.MESCore.Controls
{
    public partial class udcViewAttach : UserControl
    {
        private string s_Source = string.Empty;
        private string s_Target = string.Empty;

        public udcViewAttach()
        {
            InitializeComponent();
        }

        //===============================================================================================//
        #region " Constant Definition "
        // 상수값 지정 변수 선언

        private const int COL_FILE_TYPE = 0;
        private const int COL_FILE_NAME = 1;
        private const int COL_FILE_PATH = 2;
        private const int COL_FILE_VIEW = 3;
        private const int COL_FILE_DOWN = 4;

        #endregion

        //===============================================================================================//
        #region " Variable Definition "
        // 변수 정의 선언

        private string sAttachPath = string.Empty;
        private string sAttachID = string.Empty;
        private string sAttachPWD = string.Empty;

        #endregion

        //===============================================================================================//
        #region " Function Definition "
        // Function 정의

        public void Set_Lot_id(string s_lot_id)
        {
            txtLOTID.Text = MPCF.Trim(s_lot_id);
        }

        public void Set_Doc_Type(string s_doc_type)
        {
            txtDocType.Text = MPCF.Trim(s_doc_type);
        }

        public bool ViewUploadAttach(char ProcStep)
        {

            // LOT에 대한  Attach 파일 정보를 보여준다
            MPCF.ClearList(spdFileAttachList);
            if (ViewAttachList(MPCF.Trim(txtLOTID.Text)) == false)
            {
                MPCF.ShowMsgBox("LOT에 대한 Attach File이 존재하지 않습니다.");
                return false;
            }

            if (Attach_Path('2') == false)
            {
                MPCF.ShowMsgBox("File Upload Attach Path 정보가 존재하지 안습니다.");
                return false;
            }

            return true;
        }


        //파일 다운로드 경로를 가져온다.(파일이 저장되어있는 서버 경로)
        private bool Attach_Path(char ProcStep)
        {
            TRSNode in_node2 = new TRSNode("FILE_PATH_IN");
            TRSNode out_node2 = new TRSNode("CMN_OUT");
            //TRSNode path_node;

            try
            {
                MPCR.SetInMsg(in_node2);
                in_node2.ProcStep = ProcStep;

                in_node2.AddString("LOT_ID", MPCF.Trim(txtLOTID.Text));
                in_node2.AddString("TABLE_NAME", MPGC.MP_GCM_ATTACH_PATH);
                //in_node2.AddString("KEY_1", "ATPATH01");   /* file attach => 네트워크 드라이브 */
                in_node2.AddString("KEY_1", "FTP_PATH");    /* file attach => FTP */

                if (MPCR.CallService("PTS", "PTS_Tran_Upload_Attach_File", in_node2, ref out_node2) == false)
                {
                    return false;
                }

                sAttachPath = MPCF.Trim(out_node2.GetList(0)[0].GetString("DATA_1"));
                sAttachID = MPCF.Trim(out_node2.GetList(0)[0].GetString("DATA_2"));
                sAttachPWD = MPCF.Trim(out_node2.GetList(0)[0].GetString("DATA_3"));

                // 데이터 정상적으로 가져왔는지 확인한다.
                //MessageBox.Show(sAttachPath.ToString() + " " + sAttachID.ToString() + " " + sAttachPWD.ToString());


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        private void Attach_View()
        {
            string sFilePath = string.Empty;

            string strTarget = MPCF.Trim(sAttachPath);
            string strUSR = MPCF.Trim(sAttachID);
            string strPWD = MPCF.Trim(sAttachPWD);

            try
            {
                if (string.IsNullOrEmpty(strTarget)) // || string.IsNullOrEmpty(strUSR)
                {
                    MessageBox.Show("공유정보가 부족합니다.");
                    return;
                }

                // 먼저 네트웍 드라이브가 연결된 것이 있으면 해제한다.
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return;
                }

                // 네트워크 드라이브 연결
                NetConnection.ConnectNetDrive(strTarget, strUSR, strPWD);

                if (spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_NAME).ToString().Length == 0) return;


                sFilePath = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_PATH).ToString());
                sFilePath = sFilePath + "\\" + MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_NAME).ToString());

                System.Diagnostics.Process.Start(sFilePath);

                // 네트웍 드라이브 해제
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return;
            
        }

        private void Attach_Download()
        {
            try
            {

                string strTarget = MPCF.Trim(sAttachPath);
                string strUSR = MPCF.Trim(sAttachID);
                string strPWD = MPCF.Trim(sAttachPWD);

                if (string.IsNullOrEmpty(strTarget)) // || string.IsNullOrEmpty(strUSR)
                {
                    MessageBox.Show("공유정보가 부족합니다.");
                    return;
                }

                // 먼저 네트웍 드라이브가 연결된 것이 있으면 해제한다.
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return;
                }

                // 네트워크 드라이브 연결
                NetConnection.ConnectNetDrive(strTarget, strUSR, strPWD);

                //복사 대상 파일 정보
                s_Source = string.Empty;
                s_Source = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_PATH).ToString());
                s_Source = s_Source + "\\" + MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_NAME).ToString());


                folderBrowserDialog1.SelectedPath = "C\\";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    s_Target = string.Empty;
                    s_Target =  folderBrowserDialog1.SelectedPath.ToString().Trim();
                    s_Target = s_Target + "\\" + MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_NAME).ToString());

                    System.IO.File.Copy(s_Source, s_Target, true);
                }

                // 네트웍 드라이브 해제
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("파일 Download가 완료되었습니다");            

            return;
        }

        private void FTP_Download()
        {
            try
            {

                string strTarget = MPCF.Trim(sAttachPath);
                string strUSR = MPCF.Trim(sAttachID);
                string strPWD = MPCF.Trim(sAttachPWD);
                string remotefilename = "";

                /* Class 생성하여 사용 (clsPTSFTpClient) */
                PTSFTPClient ptsftp = new PTSFTPClient();

                ptsftp.FtpServerIP = MPCF.Trim(strTarget);
                ptsftp.FtpUserID = MPCF.Trim(strUSR);
                ptsftp.FtpPassword = MPCF.Trim(strPWD);

                remotefilename = MPCF.Trim(spdFileAttachList.ActiveSheet.Cells[spdFileAttachList.ActiveSheet.ActiveRowIndex, COL_FILE_NAME].Value);

                folderBrowserDialog1.SelectedPath = "C\\";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    s_Target = string.Empty;
                    s_Target = folderBrowserDialog1.SelectedPath.ToString().Trim();
                    //s_Target = s_Target + "\\" + remotefilename;

                    ptsftp.DownLoadFile(s_Target, remotefilename);
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("파일 Download가 완료되었습니다");

            return;
        }

        // LOT에 대한 Attach File 리스트를 보여준다.
        private bool ViewAttachList(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("View_Attach_In");
            TRSNode out_node = new TRSNode("View_Attach_Out");

            FarPoint.Win.Spread.SheetView sheet;

            int i;
            int iRow = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLOTID.Text.ToString().Trim());
                in_node.AddString("TABLE_NAME", MPGC.MP_GCM_ATTACH_TYPE);
                in_node.AddString("DOC_TYPE", txtDocType.Text.ToString().Trim());

                // 박스에 해당하는 LOT 리스트를 가져오기 위해서.. 신규로 생성하지 않고..아래 서비스(Service) 사용함.
                if (MPCR.CallService("PTS", "PTS_View_Attach_File", in_node, ref out_node) == false)
                {
                    return false;
                }

                //조회한 LOT 정보를 List에 추가한다.
                sheet = spdFileAttachList.ActiveSheet;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    iRow = sheet.RowCount;

                    sheet.RowCount++;

                    sheet.Cells[iRow, COL_FILE_TYPE].Value = out_node.GetList(0)[i].GetString("FILE_TYPE");
                    sheet.Cells[iRow, COL_FILE_NAME].Value = out_node.GetList(0)[i].GetString("FILE_NAME");
                    sheet.Cells[iRow, COL_FILE_PATH].Value = out_node.GetList(0)[i].GetString("FILE_PATH");
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        #endregion
        //===============================================================================================//

        // 파일 타입 (현재 사용 안함/ 나중에 타입별 조회할 경우 사용할 수 있음)
        // 데이터 조회에서는 모든파일 가져오기(%) 처리함.
        private void cdvAttachType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAttachType.Init();
                MPCF.InitListView(cdvAttachType.GetListView);
                cdvAttachType.Columns.Add("Initial ID", 50, HorizontalAlignment.Left);
                cdvAttachType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvAttachType.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvAttachType.GetListView, '1', MPGC.MP_GCM_ATTACH_TYPE) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdFileAttachList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 3)  //View
            {
                Attach_View();
            }
            else if (e.Column == 4) // Download
            {
                //Attach_Download();

                FTP_Download();
            }
        }

    }
}
