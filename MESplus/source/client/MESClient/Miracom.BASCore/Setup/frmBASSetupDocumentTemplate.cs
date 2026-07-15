using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

using FarPoint.Win.Spread;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using System.IO;
using Miracom.MsgHandler;

namespace Miracom.BASCore
{
    public partial class frmBASSetupDocumentTemplate : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupDocumentTemplate()
        {
            InitializeComponent();
        }

        #region " Constants Definition "

        #endregion // Constants Definition

        #region " Variables Definition "

        private bool b_load_flag;
        private string s_base_path;

        #endregion // Variables Definition

        #region " Functions Definition "

        //
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_TEMPLATE_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_TEMPLATE_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_TEMPLATE_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_TEMPLATE_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_TEMPLATE_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_TEMPLATE_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_TEMPLATE_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_TEMPLATE_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_TEMPLATE_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_TEMPLATE_GRP_10;

            MPCR.SetGRPItem(MPGC.MP_GRP_TEMPLATE, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_TEMPLATE, "lblCMF", "cdvCMF", grpCMF);

        }
        /// <summary>
        /// Check Condition
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>
        private bool CheckCondition()
        {
            Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9_.-]*$");

            if (MPCF.CheckValue(txtDocTemplate, 1) == false)
            {
                return false;
            }
            else
            {
                if (objAlphaPattern.IsMatch(txtDocTemplate.Text) == false)
                {
                    MPCF.ShowMsgBox("Invalid Sheet Template ID");
                    return false;
                }
            }

            if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
            {
                tabScreen.SelectedTab = tbpGroup;
                return false;
            }
            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
            {
                tabScreen.SelectedTab = tbpCustom;
                return false;
            }

            return true;

        }

        /// <summary>
        /// 해당 템플릿을 갱신한다.
        /// </summary>
        /// <param name="c_step">Step</param>        
        /// <returns>true or false</returns>
        private bool Update_Document_Template(char c_step)
        {
            TRSNode in_node = new TRSNode("DOCUMENT_IN");
            TRSNode out_node = new TRSNode("DOCUMENT_OUT");
                
            string sPath = string.Empty;
            string sTemp = string.Empty;

            int i;

            try
            {
                if (in_node.ProcStep == MPGC.MP_STEP_COPY)
                    sTemp = MPCF.Trim(txtDocTemplate.Text);
                else
                    sTemp = MPCF.Trim(txtCopy.Text);

                //변경된 값을 Spread에 적용하지 않은 경우, 적용하고 업데이트한다
                if (spdSpread.ActiveSheet.RowCount != MPCF.ToInt(txtRowCount.Text))
                    spdSpread.ActiveSheet.RowCount = MPCF.ToInt(txtRowCount.Text);
                if (spdSpread.ActiveSheet.ColumnCount != MPCF.ToInt(txtColumnCount.Text))
                    spdSpread.ActiveSheet.ColumnCount = MPCF.ToInt(txtColumnCount.Text);
                if (spdSpread.ActiveSheet.GetRowHeight(0) != MPCF.ToInt(txtRowHeight.Text))
                {
                    for (i = 0; i < spdSpread.ActiveSheet.RowCount; i++)
                        spdSpread.ActiveSheet.SetRowHeight(i, MPCF.ToInt(txtRowHeight.Text));
                }
                if (spdSpread.ActiveSheet.GetColumnWidth(0) != MPCF.ToInt(txtColumnWidth.Text))
                {
                    for (i = 0; i < spdSpread.ActiveSheet.ColumnCount; i++)
                        spdSpread.ActiveSheet.SetColumnWidth(i, MPCF.ToInt(txtColumnWidth.Text));
                }
 
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("DOT_ID", MPCF.Trim(txtDocTemplate.Text));
                in_node.AddString("DOT_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("DOC_TYPE", MPCF.Trim(cdvDocType.Text));                
                in_node.AddInt("ROW_COUNT", MPCF.Trim(txtRowCount.Text));
                in_node.AddInt("ROW_HEIGHT", MPCF.Trim(txtRowHeight.Text));
                in_node.AddInt("COLUMN_COUNT", MPCF.Trim(txtColumnCount.Text));
                in_node.AddInt("COLUMN_WIDTH", MPCF.Trim(txtColumnWidth.Text));
                in_node.AddString("TO_DOT_ID", MPCF.Trim(txtCopy.Text));

                sPath = s_base_path + sTemp;

                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                spdSpread.Save(sPath + ".xml", false);
                MPCR.ZipCompress(sPath);

                // Add Template file
                {
                    FileInfo finfo;
                    BinaryReader br;
                    byte[] file_buffer;

                    finfo = new FileInfo(sPath + ".gzip");
                    if (finfo.Exists == true)
                    {
                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        in_node.AddBlob(MPGC.MP_BIN_DATA_2, file_buffer);
                        br.Close();
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Document_Template", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                btnRefresh.PerformClick();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        /// <summary>
        /// 해당 템플릿을 보여준다.
        /// </summary>
        /// <param name="sDocID">Document Template ID</param>        
        /// <returns>true or false</returns>
        private bool ViewDocTemp(string sDocID)
        {
            TRSNode in_node = new TRSNode("View_Doc_Temp_IN");
            TRSNode out_node = new TRSNode("View_Doc_Temp_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOT_ID", sDocID);

                if (MPCR.CallService("BAS", "BAS_View_Document_Template", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDocTemplate.Text = out_node.GetString("DOT_ID");
                txtDesc.Text = out_node.GetString("DOT_DESC");
                cdvDocType.Text = out_node.GetString("DOC_TYPE");
                txtRowCount.Text = out_node.GetInt("ROW_COUNT").ToString();
                txtRowHeight.Text = out_node.GetInt("ROW_HEIGHT").ToString();
                txtColumnCount.Text = out_node.GetInt("COLUMN_COUNT").ToString();
                txtColumnWidth.Text = out_node.GetInt("COLUMN_WIDTH").ToString();
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레시 시트 XML 파일을 갱신한다.
        /// </summary>
        /// <param name="out_node">out_node of TRSNode</param>        
        /// <returns>true or false</returns>
        private bool UpdateDocTempXML(TRSNode out_node)
        {
            try
            {
                string sPath = s_base_path + txtDocTemplate.Text;
                FileStream fs = File.Open(sPath + ".gzip", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] buffer;
                DateTime dt_create_time;
                
                fs.Flush();
                buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2);
                bw.Write(buffer);

                bw.Close();
                fs.Close();

                dt_create_time = MPCF.ToDate(out_node.GetString("CREATION_TIME"));
                File.SetCreationTime(sPath + ".gzip", dt_create_time);

                MPCR.ZipDecompress(sPath);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 해당 스프레드 XML 파일을 로드 한다.
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>
        private bool ViewTemp()
        {
            string sPathZip;
            string sPathXML;
            string sCreateTime;
            
            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Temp_IN");
            TRSNode out_node = new TRSNode("View_Temp_OUT");
            
            try
            {
                if (lisScreen.Items.Count < 1)
                    return false;

                sPathZip = s_base_path + lisScreen.SelectedItems[0].SubItems[0].Text + ".gzip";
                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                FileInfo fi = new FileInfo(sPathZip);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("DOT_ID", lisScreen.SelectedItems[0].SubItems[0].Text);

                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19001231000000");
                    in_node.AddInt("FILE_SIZE", 0);
                }
                else
                {
                    create_time = fi.CreationTime;
                    sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    iFileSize = fi.Length;

                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }
                

                if (MPCR.CallService("BAS", "BAS_Check_DocTemp", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateDocTempXML(out_node);
                }

                sPathXML = s_base_path + lisScreen.SelectedItems[0].SubItems[0].Text + ".xml";
                spdSpread.Open(sPathXML);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 첫번째 아이템에 포커스
        /// </summary>
        /// <param name></param>        
        /// <returns>control</returns>
        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisScreen;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion // Functions Definition

        #region " Event Definition "

        private void frmBASSetupDocumentTemplate_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                SetGroupCmfItem();
                btnRefresh.PerformClick();

                b_load_flag = true;                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sDocID = "";

            try
            {
                sDocID = MPCF.Trim(txtDocTemplate.Text);
                
                lblDataCount.Text = "";
                MPCF.FieldClear(pnlRight);
                spdSpread.ActiveSheet.RowCount = 0;
                spdSpread.ActiveSheet.ColumnCount = 0;

                if (BASLIST.ViewDocTempList(lisScreen, '1', "", MPGV.gsFactory, null, "", false) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisScreen.Items.Count);
                    if (lisScreen.Items.Count > 0)
                    {
                        if (sDocID == "")
                        {
                            //if (lisScreen.Items.Count > 1)
                                lisScreen.Items[0].Selected = true;
                        }
                        else
                        {
                            if (MPCF.FindListItem(lisScreen, sDocID, false) == false)
                            {
                                lisScreen.Items[0].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisScreen, txtFind.Text, 0, true, false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisScreen, txtFind.Text, true, false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            MPCF.ExportToExcel(lisScreen, this.Text, sCond);
        }


        private void cdvSGrp_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Document_Template(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Document_Template(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (Update_Document_Template(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            spdSpread.ActiveSheet.RowCount = MPCF.ToInt(txtRowCount.Text);
            spdSpread.ActiveSheet.ColumnCount = MPCF.ToInt(txtColumnCount.Text);
            for (int i = 0; i < spdSpread.ActiveSheet.RowCount; i++ )
            {
                spdSpread.ActiveSheet.SetRowHeight(i, MPCF.ToInt(txtRowHeight.Text));
                for (int j = 0; j < spdSpread.ActiveSheet.ColumnCount; j++)
                {
                    spdSpread.ActiveSheet.SetColumnWidth(j, MPCF.ToInt(txtColumnWidth.Text));
                }            
            }            

            FarPoint.Win.Spread.Design.DesignerMain design = new FarPoint.Win.Spread.Design.DesignerMain(spdSpread);
            design.ShowDialog(this);

            txtRowCount.Text = spdSpread.ActiveSheet.RowCount.ToString();
            txtColumnCount.Text = spdSpread.ActiveSheet.ColumnCount.ToString();
            txtRowHeight.Text = spdSpread.ActiveSheet.GetRowHeight(0).ToString();
            txtColumnWidth.Text = spdSpread.ActiveSheet.GetColumnWidth(0).ToString();
        }

        private void lisScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisScreen.SelectedItems.Count < 1)
            {
                return;
            }

            string sDocID;

            sDocID = MPCF.Trim(lisScreen.SelectedItems[0].SubItems[0].Text);
            
            ViewDocTemp(sDocID);

            ViewTemp();
        }

        private void cdvGroupCmf_ButtonPress(object sender, EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvDocType_ButtonPress(object sender, EventArgs e)
        {
            cdvDocType.Init();
            MPCF.InitListView(cdvDocType.GetListView);
            cdvDocType.Columns.Add("Doc Type", 150, HorizontalAlignment.Left);
            cdvDocType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvDocType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDocType.GetListView, '1', MPGC.MP_DOC_TYPE);       
        }

        private void frmBASSetupDocumentTemplate_Load(object sender, EventArgs e)
        {
            s_base_path = Application.StartupPath + "\\DocTemp\\";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Document_Template(MPGC.MP_STEP_COPY) == false)
            {
                return;
            }
        }

        private void txtRowCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && Char.IsDigit(e.KeyChar) == false) e.Handled = true;
        }

        private void txtDocTemplate_TextChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(this, txtDocTemplate);
            MPCF.ClearList(spdSpread);
        }
        #endregion
    }
}