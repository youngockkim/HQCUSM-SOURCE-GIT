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
    public partial class frmBASSetupFlexibleScreen : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupFlexibleScreen()
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

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        //
        private bool CheckCondition()
        {
            Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9_.-]*$");

            if (MPCF.CheckValue(cdvScreenGrp, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(txtScreenID, 1) == false)
            {
                return false;
            }
            else
            {
                if (objAlphaPattern.IsMatch(txtScreenID.Text) == false)
                {
                    MPCF.ShowMsgBox("Invalid Screen ID");
                    return false;
                }
            }

            if (MPCF.CheckValue(cdvModule, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cdvService, 1) == false)
            {
                return false;
            }

            return true;

        }

        //
        // Update_Screen()
        //       - Change Screen Design
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla c_step                : Create/Update/Delete
        //
        private bool Update_Screen(char c_step)
        {
            TRSNode in_node = new TRSNode("SCREEN_IN");
            TRSNode out_node = new TRSNode("SCREEN_OUT");
                
            string sPath = string.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("SCREEN_GROUP", MPCF.Trim(cdvScreenGrp.Text));
                in_node.AddString("SCREEN_ID", MPCF.Trim(txtScreenID.Text));
                in_node.AddString("SCREEN_DESC", MPCF.Trim(txtScreenDesc.Text));
                in_node.AddString("MODULE_NAME", MPCF.Trim(cdvModule.Text));
                in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));

                sPath = s_base_path + txtScreenID.Text;

                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                spdSpread.Save(sPath + ".xml", false);
                MPCR.ZipCompress(sPath);

                // Add Screen file
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

                if (MPCR.CallService("BAS", "BAS_Update_Screen", in_node, ref out_node) == false)
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

        private bool ViewServiceList(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModule.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            return true;
        }

        private bool ViewScreenInfo(string sScreenID)
        {
            TRSNode in_node = new TRSNode("View_Screen_Info_IN");
            TRSNode out_node = new TRSNode("View_Screen_Info_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", sScreenID);

                if (MPCR.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtScreenID.Text = out_node.GetString("SCREEN_ID");
                cdvScreenGrp.Text = out_node.GetString("SCREEN_GROUP");
                txtScreenDesc.Text = out_node.GetString("SCREEN_DESC");
                cdvModule.Text = out_node.GetString("MODULE_NAME");
                cdvService.Text = out_node.GetString("SERVICE_NAME");
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

        private bool UpdateScreenXML(TRSNode out_node)
        {
            try
            {
                string sPath = s_base_path + txtScreenID.Text;
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

        private bool ViewScreen()
        {
            string sPathZip;
            string sPathXML;
            string sCreateTime;
            
            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Screen_IN");
            TRSNode out_node = new TRSNode("View_Screen_OUT");
            
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
                in_node.AddString("SCREEN_ID", lisScreen.SelectedItems[0].SubItems[0].Text);

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
                

                if (MPCR.CallService("BAS", "BAS_Check_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateScreenXML(out_node);
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

        private void frmBASSetupFlexibleScreen_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                btnEdit.Visible = false;
                btnFromExcel.Visible = false;

                btnRefresh.PerformClick();

                b_load_flag = true;
                s_base_path = Application.StartupPath + "\\Screen\\";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sScreenID = "";

            try
            {
                sScreenID = MPCF.Trim(txtScreenID.Text);
                
                lblDataCount.Text = "";
                MPCF.FieldClear(pnlRight);
                spdSpread.ActiveSheet.RowCount = 0;
                spdSpread.ActiveSheet.ColumnCount = 0;

                if (BASLIST.ViewScreenList(lisScreen, '1', cdvSGrp.Text, cdvFactory.Text, null, "", false) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisScreen.Items.Count);
                    if (lisScreen.Items.Count > 0)
                    {
                        if (sScreenID == "")
                        {
                            lisScreen.Items[0].Selected = true;
                        }
                        else
                        {
                            if (MPCF.FindListItem(lisScreen, sScreenID, false) == false)
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

            sCond = "Screen Group : " + cdvSGrp.Text;
            MPCF.ExportToExcel(lisScreen, this.Text, sCond);
        }

        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            cdvModule.Init();
            MPCF.InitListView(cdvModule.GetListView);
            cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModule.SelectedSubItemIndex = 0;

            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = cdvModule.GetListView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Service", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;

            ViewServiceList(cdvService.GetListView);
        }

        private void cdvSGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvSGrp.Init();
            MPCF.InitListView(cdvSGrp.GetListView);
            cdvSGrp.Columns.Add("Screen Group", 150, HorizontalAlignment.Left);
            cdvSGrp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvSGrp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSGrp.GetListView, '1', MPGC.MP_SCREEN_GRP);            
        }

        private void cdvSGrp_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cdvScreenGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvScreenGrp.Init();
            MPCF.InitListView(cdvScreenGrp.GetListView);
            cdvScreenGrp.Columns.Add("Screen Group", 150, HorizontalAlignment.Left);
            cdvScreenGrp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvScreenGrp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvScreenGrp.GetListView, '1', MPGC.MP_SCREEN_GRP);
        }

        // Screen Create - Create Screen to Server
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Screen(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
        }

        // Screen Update - Update Screen to Server
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Screen(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
        }

        // Screen Delete - Delete Screen from Server
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (Update_Screen(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
        }

        // Screen Edit - Load Spread Designer
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.Design.DesignerMain design = new FarPoint.Win.Spread.Design.DesignerMain(spdSpread);
            design.ShowDialog(this);
        }

        private void tabScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabScreen.SelectedTab == tapGeneral)
                {
                    btnEdit.Enabled = false;
                    btnEdit.Visible = false;
                    btnFromExcel.Enabled = false;
                    btnFromExcel.Visible = false;
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnEdit, true);
                    MPCR.ChangeControlEnabled(this, btnFromExcel, true);
                    btnEdit.Visible = true;
                    btnFromExcel.Visible = true;

                    if (lisScreen.SelectedItems.Count > 0)
                    {
                        if (lisScreen.SelectedItems[0].SubItems[0].Text != txtScreenID.Text)
                        {
                            return;
                        }
                    }

                    spdSpread.ActiveSheet.ColumnCount = 0;
                    spdSpread.ActiveSheet.RowCount = 0;

                    ViewScreen();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisScreen.SelectedItems.Count < 1)
            {
                return;
            }

            string sScreenID;

            sScreenID = MPCF.Trim(lisScreen.SelectedItems[0].SubItems[0].Text);

            ViewScreenInfo(sScreenID);

            if (tabScreen.SelectedTab == tapScreen)
            {
                ViewScreen();
            }
        }

        private void cdvFactory_ButtonPress(object sender, EventArgs e)
        {
            cdvFactory.Init();
            MPCF.InitListView(cdvFactory.GetListView);
            cdvFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvFactory.GetListView, '1', null);
        }

        private void cdvFactory_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ofdFile.Filter = "Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx";
                ofdFile.DefaultExt = "xls,xlsx";
                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    spdSpread.OpenExcel(ofdFile.FileName, FarPoint.Excel.ExcelOpenFlags.NoFlagsSet);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        

    }
}