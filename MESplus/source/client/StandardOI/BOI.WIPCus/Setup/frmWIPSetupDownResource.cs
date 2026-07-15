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
    public partial class frmWIPSetupDownResource : BOIBaseForm02, IDisposable
    {
        #region Property

        // (Required) 
        private bool disposed = false;
        private bool bIsShown = false;
        private TRSNode _node = null;

        public bool _bSetup = false;
        public bool _bCall = true;

        public enum RES_COL
        {
            LINE_ID,
            RES_ID,
            DOWN_START_TIME,
            DOWN_END_TIME,
            DOWN_TIME,
            CREATE_TIME,
            RES_SEQ,
            WORK_DATE
        }

        #endregion

        #region Constructor

        public frmWIPSetupDownResource()
        {
            InitializeComponent();
        }

        public frmWIPSetupDownResource(TRSNode node)
        {
            InitializeComponent();

            if (_bCall == true)
            {
                _node = node;
            }
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

                InvisibleColumn();

                txtNonmovingType.Tag = "";
                txtCodeL.Tag = "";
                txtCodeM.Tag = "";
                txtCodeS.Tag = "";

                // (Required) 
                bIsShown = true;
            }

            if (_bCall == true)
            {
                ViewResourceList(_node);  
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

        private void btnWorkIdle_Click(object sender, EventArgs e)
        {
            BOI.WIPCus.Popup.frmWIPNonmovingResourcePopup frm = new BOI.WIPCus.Popup.frmWIPNonmovingResourcePopup();

            try
            {
                ClearData();

                if(spdResList.Sheets[0].RowCount < 1)
                {
                    return;
                }

                MenuInfoTag selectedMenuInfo;

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "History Registration";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;


                frm._sLineId = spdResList.Sheets[0].Cells[0, (int)RES_COL.LINE_ID].Tag.ToString();

                if (((SOIButton)sender).Name == "btnWorkIdle")
                {
                    frm._sTypeCode = btnWorkIdle.Tag.ToString();
                    frm._sTypeDesc = btnWorkIdle.Text;
                }
                else if (((SOIButton)sender).Name == "btnPlannedIdle")
                {
                    frm._sTypeCode = btnPlannedIdle.Tag.ToString();
                    frm._sTypeDesc = btnPlannedIdle.Text;
                }
                else if (((SOIButton)sender).Name == "btnSC")
                {
                    frm._sTypeCode = btnSC.Tag.ToString();
                    frm._sTypeDesc = btnSC.Text;
                }
                else if (((SOIButton)sender).Name == "btnTrouble")
                {
                    frm._sTypeCode = btnTrouble.Tag.ToString();
                    frm._sTypeDesc = btnTrouble.Text;
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtNonmovingType.Text = frm._sTypeDesc;
                    txtNonmovingType.Tag = frm._sTypeCode;

                    txtCodeL.Text = frm._sCodeLDesc;
                    txtCodeL.Tag = frm._sCodeLCode;

                    txtCodeM.Text = frm._sCodeMDesc;
                    txtCodeM.Tag = frm._sCodeMCode;

                    txtCodeS.Text = frm._sCodeSDesc;
                    txtCodeS.Tag = frm._sCodeSCode;
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bSetup == false)
                {
                    if (CheckCondition("UPDATE_RES") == true)
                    {
                        if (Update_Resource('U') == true)
                        {
                            //Nothing
                        }
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
             
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

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

        private void ClearData()
        {
            try
            {
                txtNonmovingType.Text = "";
                txtNonmovingType.Tag = "";

                txtCodeL.Text = "";
                txtCodeL.Tag = "";

                txtCodeM.Text = "";
                txtCodeM.Tag = "";

                txtCodeS.Text = "";
                txtCodeS.Tag = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        //private void ViewResourceList()
        //{
        //    ViewResourceList(null);
        //}

        public void ViewResourceList(TRSNode node)
        {
            try
            {
                MPCF.ClearList(spdResList);

                if (_node.GetChar("MES_STATUS") == '1')
                {
                    MPCF.CheckContinueProc(_node, false);
                    return;
                }

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;
             
                dvcArgu[1].sCondtion_ID = "WORK_DATE";
                dvcArgu[1].sCondition_Value = node.GetString("WORK_DATE");

                dvcArgu[2].sCondtion_ID = "LINE_GRP_ID";
                dvcArgu[2].sCondition_Value = node.GetString("LINE_GRP_ID");

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                dvcArgu[3].sCondition_Value = node.GetString("LINE_ID");

                dvcArgu[4].sCondtion_ID = "RES_ID";
                dvcArgu[4].sCondition_Value = node.GetString("RES_ID");

                dvcArgu[5].sCondtion_ID = "AUTO_FLAG";
                dvcArgu[5].sCondition_Value = node.GetChar("AUTO_FLAG").ToString();

                dvcArgu[6].sCondtion_ID = "RES_SEQ";
                dvcArgu[6].sCondition_Value = node.GetInt("RES_SEQ");

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
                    spdResList.Sheets[0].Cells[i, (int)RES_COL.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
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

        private bool CheckCondition(string FuncName)
        {
            int i_row_count = 0;

            try
            {
                switch (FuncName)
                {
                    case "UPDATE_RES":

                        i_row_count = spdResList.Sheets[0].RowCount;

                        if (i_row_count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(464), MSG_LEVEL.WARNING, true);
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

        // Update_Resource()
        //       - Update Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Resource(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_RES_IN");
            TRSNode out_node = new TRSNode("UPDATE_RES_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                for (int i = 0; i < spdResList.Sheets[0].RowCount; i++)
                {
                    list_item = in_node.AddNode("RES_LIST");

                    list_item.AddString("WORK_DATE", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.WORK_DATE].Value));
                    list_item.AddString("RES_ID", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_ID].Tag.ToString()));
                    list_item.AddInt("RES_SEQ", MPCF.Trim(spdResList.Sheets[0].Cells[i, (int)RES_COL.RES_SEQ].Value));

                    list_item.AddString("DOWN_TYPE", txtNonmovingType.Tag.ToString().Trim());
                    list_item.AddString("DOWN_CODE_L", txtCodeL.Tag.ToString().Trim());
                    list_item.AddString("DOWN_CODE_M", txtCodeM.Tag.ToString().Trim());
                    list_item.AddString("DOWN_CODE_S", txtCodeS.Tag.ToString().Trim());
                    list_item.AddString("DOWN_COMMENT", txtComment.Text.Trim());
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

        #endregion

        private void myDispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //UnTune
                    //PublishCUSMsgUnTune();
                }
                this.disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
