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
using BOI.OIFrx;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPPreprocessingHoldReleaseLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _sOrderId = string.Empty;
        private string _sLotId = string.Empty;
        private string _sOper = string.Empty;
        private string _sOperDesc = string.Empty;
        private string _sMatId = string.Empty;
        private string _sFlow = string.Empty;

        private enum LOT_COL
        {
            LOT_ID,
            OPER,
            LOT_STATUS,
            HOLD_FLAG,
            START_RES_ID,
            START_TIME,
            ORDER_ID
        }

        #endregion

        #region Constructor

        public frmWIPPreprocessingHoldReleaseLot()
        {
            InitializeComponent();
        }

        public frmWIPPreprocessingHoldReleaseLot(string args)
        {
            InitializeComponent();
            if (args.Split(':').Length == 4)
            {
                _sOrderId = args.Split(':')[0];
                _sLotId = args.Split(':')[1];
                _sOperDesc = args.Split(':')[2];
                _sOper = args.Split(':')[3];
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

                MPCF.ClearList(spdLotList);

                boiOrderInfo.Oper = "";

                if(_sOrderId != "")
                {
                    boiOrderInfo.View_Order_Info(_sOrderId);
                }

                if (_sOper != "" && _sOperDesc != "")
                {
                    cdvOper.Text = _sOperDesc;
                    cdvOper.Tag = _sOper;

                    ViewOrderLotList();

                    ChangeButtonCode(0, (int)LOT_COL.HOLD_FLAG);
                }

                //WORK USER 
                cdvWorkUser.Text = MPGV.gsUserID;

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("RES_ID") == false)
                {
                    return;
                }

                BICF.ViewResource(cdvResID, "", boiOrderInfo.WorkOrderLineId, MPCF.Trim(cdvOper.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void boiOrderInfo_WorkOrderButtonClick(object sender, EventArgs e)
        {
            try
            {
                _sOrderId = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.ORDER_ID].Value.ToString();
                _sMatId = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.MAT_ID].Tag.ToString();
                _sFlow = boiOrderInfo.spdOrderInfo.Sheets[0].Cells[0, (int)BIGC.ORDER.FLOW].Tag.ToString();
                
                if (cdvOper.Tag.ToString() != "")
                {
                    if (ViewOrderLotList() == true)
                    {
                        ChangeButtonCode(0, (int)LOT_COL.HOLD_FLAG);
                    }
                }

                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                dvcArgu[2].sCondtion_ID = "FLOW";
                dvcArgu[2].sCondition_Value = boiOrderInfo.Flow;

                dvcArgu[3].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[3].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        cdvOper.Tag = cdvOper.returnDatas[0];
                        ViewOrderLotList();
                    }
                    else
                    {
                        //cdvOper.Tag = "";
                    }
                }
                else
                {
                    cdvOper.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private bool ViewOrderLotList()
        {
            try
            {
                MPCF.ClearList(spdLotList);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "OPER";
                dvcArgu[1].sCondition_Value = cdvOper.Tag.ToString();

                dvcArgu[2].sCondtion_ID = "ORDER_ID";
                dvcArgu[2].sCondition_Value = _sOrderId;

                dvcArgu[3].sCondtion_ID = "LOT_ID";
                dvcArgu[3].sCondition_Value = _sLotId;

                if (TPDR.GetDataOne(s_column, ref dt, "CWIP8070-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList.Sheets[0].RowCount += 1;
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.OPER].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.OPER].Tag = dt.Rows[i]["OPER"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.LOT_STATUS].Value = dt.Rows[i]["LOT_STATUS"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.HOLD_FLAG].Value = dt.Rows[i]["HOLD_FLAG"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_RES_ID].Value = dt.Rows[i]["START_RES_DESC"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_RES_ID].Tag = dt.Rows[i]["START_RES_ID"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.START_TIME].Value = dt.Rows[i]["START_TIME"].ToString();
                    spdLotList.Sheets[0].Cells[i, (int)LOT_COL.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);
                _sLotId = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "HOLD_LOT":
                        if (spdLotList.Sheets[0].Rows.Count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(199), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "RELEASE_LOT":
                        if (spdLotList.Sheets[0].Rows.Count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(199), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "RES_ID":
                        //Oper
                        if (MPCF.Trim(cdvOper.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvOper.Focus();
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

        #endregion

        private void spdLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                ChangeButtonCode(e.Row, (int)LOT_COL.HOLD_FLAG);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sTableName = string.Empty;

            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                if (lblCode.Tag.ToString() == "H")
                {
                    sTableName = "HOLD_CODE";
                }
                else
                {
                    sTableName = "RELEASE_CODE";
                }

                dvcArgu[1].sCondtion_ID = "TABLE_NAME";
                dvcArgu[1].sCondition_Value = sTableName;

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvCode.Text = cdvCode.Show(cdvCode, "Code", "COM0000-001", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvCode.Text) != "")
                {
                    if (cdvCode.returnDatas != null && cdvCode.returnDatas.Count > 0)
                    {
                        cdvCode.Tag = cdvCode.returnDatas[0];
                    }
                    else
                    {
                       // cdvCode.Tag = "";
                    }
                }
                else
                {
                    cdvCode.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnHoldRelease_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnHoldRelease.Tag.ToString() == "H")
                {
                    if (CheckCondition("HOLD_LOT") == true)
                    {
                        if (Hold_Lot('1') == true)
                        {
                            //btnLabelPrint.Enabled = true;
                            ViewOrderLotList();
                        }
                    }
                }
                else
                {
                    if (CheckCondition("RELEASE_LOT") == true)
                    {
                        if (Release_Lot('1') == true)
                        {
                            //btnLabelPrint.Enabled = true;
                            ViewOrderLotList();
                        }
                    }
                }

                ChangeButtonCode(0, (int)LOT_COL.HOLD_FLAG);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        // Hold_Lot()
        //       - Hold Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Hold_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("HOLD_LOT_IN");
            TRSNode out_node = new TRSNode("HOLD_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);
                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());
                in_node.AddString("COMMENT", txtComment.Text);

                in_node.AddString("HOLD_CODE", cdvCode.Tag.ToString());

                in_node.AddString("LOT_ID", MPCF.Trim(spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value));

                if (MPCF.CallService("BWIP", "BWIP_Tran_Hold_Lot", in_node, ref out_node) == false)
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


        // Release_Lot()
        //       - Release Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Release_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("RELEASE_LOT_IN");
            TRSNode out_node = new TRSNode("RELEASE_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", _sOrderId);
                in_node.AddString("MAT_ID", _sMatId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", _sFlow);
                in_node.AddString("OPER", cdvOper.Tag.ToString());
                in_node.AddString("COMMENT", txtComment.Text);

                in_node.AddString("RELEASE_CODE", cdvCode.Tag.ToString());

                in_node.AddString("LOT_ID", MPCF.Trim(spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value));

                if (MPCF.CallService("BWIP", "BWIP_Tran_Release_Lot", in_node, ref out_node) == false)
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

        private void ChangeButtonCode(int iRow, int iCol)
        {
            try
            {
                if (spdLotList.Sheets[0].Cells[iRow, iCol].Value.ToString() == "Y")
                {
                    lblCode.Text = "Release Code";
                    lblCode.Tag = "R";

                    btnHoldRelease.Text = "Release Lot";
                    btnHoldRelease.Tag = "R";
                }
                else
                {
                    lblCode.Text = "Hold Code";
                    lblCode.Tag = "H";

                    btnHoldRelease.Text = "Hold Lot";
                    btnHoldRelease.Tag = "H";
                }

                cdvCode.Text = string.Empty;
                cdvCode.Tag = string.Empty;
                txtComment.Text = string.Empty;

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            string sLotId = string.Empty;

            try
            {
                if (spdLotList.Sheets[0].RowCount < 1)
                {
                    return;
                }

                sLotId = spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, (int)LOT_COL.LOT_ID].Value.ToString();

                BICF.OpenMenu(BIGC.MP_FUNC_NAME_CWIP3001, sLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}
