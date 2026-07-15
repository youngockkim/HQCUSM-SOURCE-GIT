using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPSetupNonmovingResource : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private bool _bAllCheck = false;

        public string _sLineGrpId = string.Empty;
        public string _sLineGrpDesc = string.Empty;

        public string _sLineId = string.Empty;
        public string _sLineDesc = string.Empty;

        public string _sResId = string.Empty;
        public string _sResDesc = string.Empty;

        public char _cPop = 'N';

        private enum RES_COL
        {
            CHECK,
            LINE_ID,
            RES_ID,
            DOWN_START_TIME,
            DOWN_END_TIME,
            DOWN_TIME,
            DOWN_TYPE,
            DOWN_CODE_L,
            DOWN_CODE_M,
            DOWN_CODE_S,
            AUTO_FLAG,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME,
            RES_SEQ,
            WORK_DATE
        }

        #endregion

        #region Constructor

        public frmWIPSetupNonmovingResource()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                MPCF.ClearList(spdResList);

                InvisibleColumn();

                dtpDate.Value = DateTime.Now.Date;

                txtNonmovingType.Tag = "";
                txtCodeL.Tag = "";
                txtCodeM.Tag = "";
                txtCodeS.Tag = "";

                if (_cPop == 'Y')
                {
                    cdvLineGroup.Tag = _sLineGrpId;
                    cdvLineGroup.Text = _sLineGrpDesc;

                    cdvLine.Tag = _sLineId;
                    cdvLine.Text = _sLineDesc;

                    cdvResource.Tag = _sResId;
                    cdvResource.Text = _sResDesc;
                }

                if (cdvLineGroup.Text != "" && cdvLine.Text != "")
                {
                    btnView.PerformClick();
                }

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLineGroup(cdvLineGroup, "Y");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag.ToString()), "Y");
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLineGroup_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Tag = "";
                cdvLine.Text = "";

                cdvResource.Tag = "";
                cdvResource.Text = "";

                MPCF.ClearList(spdResList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewResource(cdvResource, "", cdvLine.Tag.ToString(), "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("ADD_RES") == true)
                {
                    if (Add_Resource('I') == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("DELETE_RES") == true)
                {
                    if (Delete_Resource('D') == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_RES") == true)
                {
                    ViewResourceList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnSelectCode_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();
            int i_data_count = 0;

            BOI.WIPCus.frmWIPSetupDownResource frm = new BOI.WIPCus.frmWIPSetupDownResource();

            try
            {
                if (CheckCondition("ADD_RES") == false)
                {
                    return;
                }

                MenuInfoTag selectedMenuInfo;

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "History Registration";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Height = 690;
                frm.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
                frm.lblFormTitle.Appearance.ForeColor = Color.FromArgb(255, 255, 255);

                MPCF.ClearList(frm.spdResList);

                frm._bSetup = true;
                frm._bCall = false;

                frm.spdResList.Sheets[0].RowCount += 1;

                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.LINE_ID].Tag = cdvLine.Tag;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.LINE_ID].Value = cdvLine.Text;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.RES_ID].Tag = cdvResource.Tag;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.RES_ID].Value = cdvResource.Text;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.DOWN_START_TIME].Value = ((DateTime)(dtpDate.Value)).ToString("yyyy-MM-dd") + " " + cmbStartHour.Text + ":" + cmbStartMinute.Text + ":00";
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.DOWN_END_TIME].Value = ((DateTime)(dtpDate.Value)).ToString("yyyy-MM-dd") + " " + cmbEndHour.Text + ":" + cmbEndMinute.Text + ":00";
                
                startTime = MPCF.ToDate(((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbStartHour.Text + cmbStartMinute.Text + "00");
                endTime = MPCF.ToDate(((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbEndHour.Text + cmbEndMinute.Text + "00");

                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.DOWN_TIME].Value = (endTime - startTime).TotalMinutes;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.CREATE_TIME].Value = "";
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.RES_SEQ].Value = 0;
                frm.spdResList.Sheets[0].Cells[0, (int)frmWIPSetupDownResource.RES_COL.WORK_DATE].Value = ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd");

                i_data_count++;

                MPCF.FitColumnHeader(frm.spdResList);

                if (i_data_count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(464), MSG_LEVEL.WARNING, true);
                    return;
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtNonmovingType.Tag = frm.txtNonmovingType.Tag;
                    txtNonmovingType.Text = frm.txtNonmovingType.Text;

                    txtCodeL.Tag = frm.txtCodeL.Tag;
                    txtCodeL.Text = frm.txtCodeL.Text;

                    txtCodeM.Tag = frm.txtCodeM.Tag;
                    txtCodeM.Text = frm.txtCodeM.Text;

                    txtCodeS.Tag = frm.txtCodeS.Tag;
                    txtCodeS.Text = frm.txtCodeS.Text;

                    txtComment.Text = frm.txtComment.Text;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                frm.Close();
            }
        }

        private void cdvLine_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvResource.Tag = "";
                cdvResource.Text = "";

                MPCF.ClearList(spdResList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResource_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cdvLine.Text != "")
                {
                    //btnView.PerformClick();
                    if (CheckCondition("VIEW_RES") == true)
                    {
                        ViewResourceList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDate.Text == DateTime.Today.Date.ToString("yyyy-MM-dd"))
                {
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private bool CheckCondition(string FuncName)
        {
            int i_row_count = 0;

            try
            {
                switch (FuncName)
                {
                    case "ADD_RES":
                        //라인그룹
                        if (MPCF.Trim(cdvLineGroup.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLineGroup.Focus();
                            return false;
                        }

                        //라인
                        if (MPCF.Trim(cdvLine.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLine.Focus();
                            return false;
                        }

                        //설비
                        if (MPCF.Trim(cdvResource.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvResource.Focus();
                            return false;
                        }

                        //시작 시
                        if (MPCF.Trim(cmbStartHour.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cmbStartHour.Focus();
                            return false;
                        }

                        //시작 분
                        if (MPCF.Trim(cmbStartMinute.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cmbStartMinute.Focus();
                            return false;
                        }

                        //종료 시
                        if (MPCF.Trim(cmbEndHour.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cmbEndHour.Focus();
                            return false;
                        }

                        //종료 분
                        if (MPCF.Trim(cmbEndMinute.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cmbEndMinute.Focus();
                            return false;
                        }

                        //시작시보다 종료시가 커야됨
                        if (MPCF.ToInt(cmbStartHour.Text) > MPCF.ToInt(cmbEndHour.Text))
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.WARNING, true);
                            cmbEndHour.Focus();
                            return false;
                        }
                        else if (MPCF.ToInt(cmbStartHour.Text) == MPCF.ToInt(cmbEndHour.Text))
                        {
                            if (MPCF.ToInt(cmbStartMinute.Text) >= MPCF.ToInt(cmbEndMinute.Text))
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.WARNING, true);
                                cmbEndMinute.Focus();
                                return false;
                            }
                        }

                        break;

                    case "DELETE_RES":

                        i_row_count = spdResList.Sheets[0].RowCount;

                        if (i_row_count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(464), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                        {
                            return false;
                        }

                        break;

                    case "VIEW_RES":
                        //라인그룹
                        if (MPCF.Trim(cdvLineGroup.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLineGroup.Focus();
                            return false;
                        }

                        //라인
                        if (MPCF.Trim(cdvLine.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLine.Focus();
                            return false;
                        }

                        break;
                     
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Add_Resource()
        //       - Add Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Add_Resource(char ProcStep)
        {
            TRSNode in_node = new TRSNode("ADD_RES_IN");
            TRSNode out_node = new TRSNode("ADD_RES_OUT");

            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("WORK_DATE", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd"));
                in_node.AddString("RES_ID", cdvResource.Tag.ToString().Trim());

                in_node.AddString("LINE_GRP_ID", cdvLineGroup.Tag.ToString().Trim());
                in_node.AddString("LINE_ID", cdvLine.Tag.ToString().Trim());

                in_node.AddString("DOWN_TYPE", txtNonmovingType.Tag.ToString().Trim());
                in_node.AddString("DOWN_CODE_L", txtCodeL.Tag.ToString().Trim());
                in_node.AddString("DOWN_CODE_M", txtCodeM.Tag.ToString().Trim());
                in_node.AddString("DOWN_CODE_S", txtCodeS.Tag.ToString().Trim());

                in_node.AddString("DOWN_START_TIME", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbStartHour.Text + cmbStartMinute.Text + "00");
                in_node.AddString("DOWN_END_TIME", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbEndHour.Text + cmbEndMinute.Text + "00");

                startTime = MPCF.ToDate(((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbStartHour.Text + cmbStartMinute.Text + "00");
                endTime = MPCF.ToDate(((DateTime)(dtpDate.Value)).ToString("yyyyMMdd") + cmbEndHour.Text + cmbEndMinute.Text + "00");


                in_node.AddInt("DOWN_TIME", (endTime - startTime).TotalMinutes);

                in_node.AddString("DOWN_COMMENT", txtComment.Text.Trim());

                in_node.AddChar("AUTO_FLAG", 'N');

                if (MPCF.CallService("BRAS", "BRAS_Update_Nonmoving_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        // Delete_Resource()
        //       - Delete Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Delete_Resource(char ProcStep)
        {
            TRSNode in_node = new TRSNode("DELETE_RES_IN");
            TRSNode out_node = new TRSNode("DELETE_RES_OUT");
            TRSNode list_item;

            int i_data_count = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (int i = 0; i < spdResList.Sheets[0].RowCount; i++)
                {
                    if (spdResList.Sheets[0].Cells[i, (int)RES_COL.CHECK].Value != null
                               && (bool)spdResList.Sheets[0].Cells[i, (int)RES_COL.CHECK].Value == true)
                    {
                        list_item = in_node.AddNode("RES_LIST");

                        list_item.AddString("WORK_DATE", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.WORK_DATE].Value));
                        list_item.AddString("RES_ID", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_ID].Tag.ToString()));
                        list_item.AddInt("RES_SEQ", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_SEQ].Value));

                        i_data_count++;
                    }
                }

                if (i_data_count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(464), MSG_LEVEL.WARNING, true);
                    return false;
                }

                if (MPCF.CallService("BRAS", "BRAS_Update_Nonmoving_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void ViewResourceList()
        {
            try
            {
                MPCF.ClearList(spdResList);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "WORK_DATE";
                dvcArgu[1].sCondition_Value = ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "LINE_GRP_ID";
                dvcArgu[2].sCondition_Value = cdvLineGroup.Tag.ToString().Trim();

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                dvcArgu[3].sCondition_Value = cdvLine.Tag.ToString().Trim();

                dvcArgu[4].sCondtion_ID = "RES_ID";
                dvcArgu[4].sCondition_Value = cdvResource.Tag.ToString().Trim();

                dvcArgu[5].sCondtion_ID = "AUTO_FLAG";
                dvcArgu[5].sCondition_Value = "N";

                dvcArgu[6].sCondtion_ID = "RES_SEQ";
                dvcArgu[6].sCondition_Value = 0;

                if (TPDR.GetDataOne(s_column, ref dt, "CRAS1104-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdResList.Sheets[0].RowCount += 1;
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.LINE_ID].Tag = dt.Rows[i]["LINE_ID"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.LINE_ID].Value = dt.Rows[i]["LINE_DESC"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_ID].Tag = dt.Rows[i]["RES_ID"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_ID].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_START_TIME].Value = dt.Rows[i]["DOWN_START_TIME"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_END_TIME].Value = dt.Rows[i]["DOWN_END_TIME"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_TIME].Value = dt.Rows[i]["DOWN_TIME"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_TYPE].Value = dt.Rows[i]["DOWN_TYPE"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_CODE_L].Value = dt.Rows[i]["DOWN_CODE_L"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_CODE_M].Value = dt.Rows[i]["DOWN_CODE_M"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.DOWN_CODE_S].Value = dt.Rows[i]["DOWN_CODE_S"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.AUTO_FLAG].Value = dt.Rows[i]["AUTO_FLAG"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.CREATE_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.UPDATE_USER_ID].Value = dt.Rows[i]["UPDATE_USER_ID"].ToString();
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.UPDATE_TIME].Value = dt.Rows[i]["UPDATE_TIME"];
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_SEQ].Value = dt.Rows[i]["RES_SEQ"];
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.WORK_DATE].Value = dt.Rows[i]["WORK_DATE"];
                }

                MPCF.FitColumnHeader(spdResList);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void InvisibleColumn()
        {
            try
            {
                spdResList.Sheets[0].Columns[(int)RES_COL.RES_SEQ].Visible = false;
                spdResList.Sheets[0].Columns[(int)RES_COL.WORK_DATE].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void spdResList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader == true && e.Column == (int)RES_COL.CHECK)
                {
                    if (_bAllCheck == false)
                    {
                        for (int i = 0; i < spdResList.Sheets[0].RowCount; i++)
                        {
                            spdResList.Sheets[0].Cells[i, (int)RES_COL.CHECK].Value = true;
                        }

                        _bAllCheck = true;

                    }
                    else
                    {
                        for (int i = 0; i < spdResList.Sheets[0].RowCount; i++)
                        {
                            spdResList.Sheets[0].Cells[i, (int)RES_COL.CHECK].Value = false;
                        }

                        _bAllCheck = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
