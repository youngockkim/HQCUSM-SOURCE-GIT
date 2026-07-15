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
    public partial class udcUploadAttach : UserControl
    {
        private bool fileUploadCompleted = true;

        public udcUploadAttach()
        {
            InitializeComponent();
        }

        //===============================================================================================//
        #region " Constant Definition "
        // 상수값 지정 변수 선언

        private const int COL_FILE_TYPE = 0;
        private const int COL_FILE_NAME = 1;
        private const int COL_FILE_PATH = 2;

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

        //public void Set_Lot_oper(string s_lot_oper)
        //{
        //    txtOper.Text = MPCF.Trim(s_lot_oper);
        //}

        public bool SetUploadAttach(char ProcStep)
        {

            string sGubun = string.Empty;

            if (Attach_Path('2') == false)
            {
                MPCF.ShowMsgBox("File Upload Attach Path(FTP) 정보가 존재하지 않습니다.");
                return false;
            }

            // 파일을 공유폴더로 업로드(Copy)한다.
            //if (Upload_Attach() == false) return false;
            if (Upload_FTP() == false) return false;

            if (rdoLotID.Checked == true)
            {
                sGubun = "LOT";
            }
            else if (rdoDocNo.Checked == true)
            {
                sGubun = "DOC";
            }

            // 파일 업로드가 완료되면 데이터베이스에 저장한다.
            TRSNode in_node = new TRSNode("FILE_ATTACH_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode Attach_node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", MPCF.Trim(txtLOTID.Text));
                in_node.AddString("TARGET_PATH", MPCF.Trim(sAttachPath));
                //in_node.AddString("OPER", MPCF.Trim(txtOper.Text));

                for (int i = 0; i < spdFileAttachList.ActiveSheet.RowCount; i++)
                {
                    Attach_node = in_node.AddNode("FILE_ATTACH_LIST");
                    Attach_node.AddString("ATTACH_FILE_TYPE", MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_TYPE).ToString()));
                    Attach_node.AddString("ATTACH_FILE_NAME", MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_NAME).ToString()));
                    Attach_node.AddString("ATTACH_FILE_PATH", MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_PATH).ToString()));
                    Attach_node.AddString("ATTACH_DOC_TYPE", MPCF.Trim(sGubun));

                }

                if (MPCR.CallService("PTS", "PTS_Tran_Upload_Attach_File", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //파일 업데이트 경로를 가져온다.
        private bool Attach_Path(char ProcStep)
        {
            TRSNode in_node2 = new TRSNode("FILE_PATH_IN");
            TRSNode out_node2 = new TRSNode("CMN_OUT");
            //TRSNode path_node;

            try
            {
                MPCR.SetInMsg(in_node2);
                in_node2.ProcStep = ProcStep;

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


        // 파일을 업로드한다. (네트웍 드라이브 사용)
        private bool Upload_Attach()
        {
            try
            {

                string strTarget = MPCF.Trim(sAttachPath);
                string strUSR = MPCF.Trim(sAttachID);
                string strPWD = MPCF.Trim(sAttachPWD);

                if (string.IsNullOrEmpty(strTarget)) // || string.IsNullOrEmpty(strUSR)
                {
                    MessageBox.Show("공유정보가 부족합니다.");
                    return false;
                }

                // 먼저 네트웍 드라이브가 연결된 것이 있으면 해제한다.
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return false;
                }

                // 네트워크 드라이브 연결
                NetConnection.ConnectNetDrive(strTarget, strUSR, strPWD);


                // 리스트 순환하면서 데이터 업로드
                for (int i = 0; i < spdFileAttachList.ActiveSheet.RowCount; i++)
                {
                    string sourcePath = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_PATH).ToString());
                    string targetPath = strTarget;
                    string sFILE_NAME = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_NAME).ToString());

                    string sourceFile = sourcePath; //System.IO.Path.Combine(sourcePath, dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FILENM"].Value.ToString().Trim());
                    string destFile = System.IO.Path.Combine(targetPath, sFILE_NAME);

                    if (!System.IO.Directory.Exists(@targetPath))
                    {
                        System.IO.Directory.CreateDirectory(@targetPath);
                    }
                    System.IO.File.Copy(sourceFile, destFile, true);

                    Thread.Sleep(500);
                }

                // 네트웍 드라이브 해제
                try
                {
                    NetConnection.WNetCancelConnection2A(strTarget, 1, 0);
                }
                catch (Exception exer2)
                {
                    MessageBox.Show(exer2.Message.ToString());
                    return false;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
         
            return true;
        }

        // 파일을 업로드한다. (FTP 사용)
        private bool Upload_FTP()
        {
            try
            {

                string strTarget = MPCF.Trim(sAttachPath);
                string strUSR = MPCF.Trim(sAttachID);
                string strPWD = MPCF.Trim(sAttachPWD);

                //string strTarget = "197.200.33.79";
                //string strUSR = "ptsdb";
                //string strPWD = "miracom";

                //=========================================================================
                /* 참조에 있는 Miracom FTPClient 사용(한글 지원 안됨) */
                //// ftp 서버에 접속한다.
                //FTPClient.FTPAsynchronousConnection ftp = new FTPClient.FTPAsynchronousConnection();
                ////FTPClient.FTPConnection ftp = new FTPClient.FTPConnection();
                //ftp.Open(strTarget, strUSR, strPWD,FTPClient.FTPMode.Passive);

                //// 리스트 순환하면서 데이터 업로드
                //for (int i = 0; i < spdFileAttachList.ActiveSheet.RowCount; i++)
                //{
                //    string sourcePath = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_PATH).ToString());
                //    string targetPath = strTarget;
                //    string sFILE_NAME = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_NAME).ToString());

                //    string sourceFile = sourcePath; //System.IO.Path.Combine(sourcePath, dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FILENM"].Value.ToString().Trim());
                //    string destFile = System.IO.Path.Combine(targetPath, sFILE_NAME);

                //    ftp.SendFile(sourceFile, FTPClient.FTPFileTransferType.ASCII);
                //    Thread.Sleep(500);
                //}

                //ftp.Close();
                //=========================================================================


                /* Class 생성하여 사용 (clsPTSFTpClient) */
                PTSFTPClient ptsftp = new PTSFTPClient();

                ptsftp.FtpServerIP = MPCF.Trim(strTarget);
                ptsftp.FtpUserID = MPCF.Trim(strUSR);
                ptsftp.FtpPassword = MPCF.Trim(strPWD);

                // 리스트 순환하면서 데이터 업로드
                for (int i = 0; i < spdFileAttachList.ActiveSheet.RowCount; i++)
                {
                    string sourcePath = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_PATH).ToString());
                    string targetPath = strTarget;
                    string sFILE_NAME = MPCF.Trim(spdFileAttachList.ActiveSheet.GetValue(i, COL_FILE_NAME).ToString());

                    string sourceFile = sourcePath; //System.IO.Path.Combine(sourcePath, dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FILENM"].Value.ToString().Trim());
                    string destFile = System.IO.Path.Combine(targetPath, sFILE_NAME);

                    ptsftp.UpLoadFile(sourceFile);
                    Thread.Sleep(500);
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return true;
        }
        #endregion
        //===============================================================================================//


        //리스트에 파일 추가
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            FarPoint.Win.Spread.SheetView sheet;
            sheet = spdFileAttachList.ActiveSheet;


            if (!this.fileUploadCompleted) { return; }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {

                    iRow = sheet.RowCount;

                    sheet.RowCount++;

                    sheet.Cells[iRow, COL_FILE_TYPE].Value = MPCF.Trim(cdvAttachType.Text);
                    sheet.Cells[iRow, COL_FILE_NAME].Value = MPCF.Trim(file.Substring(file.LastIndexOf("\\") + 1));
                    sheet.Cells[iRow, COL_FILE_PATH].Value = MPCF.Trim(file);
                }
            }
        }

        //리스트에서 파일 제거
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (spdFileAttachList.ActiveSheet.RowCount > 0)
            {
                // 삭제 버튼을 클릭하면 선택한 Row를 리스트에서 제거한다.(만약.. 헤더를 클릭하면??? )
                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, 2) == DialogResult.No)
                {
                    return;
                }

                spdFileAttachList.ActiveSheet.Rows.Remove(spdFileAttachList.ActiveSheet.ActiveRowIndex, 1);
            }
        }

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

    }
}
