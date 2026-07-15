//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranLossLotByModule.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranLossLotByModule : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        private string gOrderID;
        private string gMatID;
        private int gMatVer;
        private string gOper;

        #endregion

        public frmCUSTranLossLotByModule()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        private enum LOT_LIST : int
        {
            SEQ,
            LOT_ID,
            PROD_LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1
        }

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC
        }

        public string gLotID { private get; set; } // LOT ID

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;

        #endregion

        #region [FormDefinition]

        #endregion

        #region [Function Definition]

        private bool AddRow()
        {
            try
            {
                if (MPCF.Trim(cdvLossCode.Text) == "" || MPCF.Trim(cdvLossCode.Tag) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                    cdvLossCode.Focus();
                    return false;
                }

                if (!Duplication(cdvLossCode.Tag.ToString()))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.WARNING, true);
                    return false;
                }

                spdLossList.Sheets[0].RowCount++;
                spdLossList.Sheets[0].Cells[spdLossList.ActiveSheet.RowCount - 1, (int)LOSS_COL.LOSS_CODE].Value = cdvLossCode.Tag.ToString();
                spdLossList.Sheets[0].Cells[spdLossList.ActiveSheet.RowCount - 1, (int)LOSS_COL.LOSS_DESC].Value = cdvLossCode.Text;

                MPCF.FitColumnHeader(spdLossList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Duplication(string lossCode)
        {
            try
            {
                for(int r = 0; r < spdLossList.ActiveSheet.RowCount; r++)
                {
                    if (lossCode.Equals(spdLossList.ActiveSheet.Cells[r, (int)LOSS_COL.LOSS_CODE].Value.ToString()))
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_Loss_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("OPER", MPCF.Trim(gOper));
                in_node.AddString("ORDER_ID", MPCF.Trim(gOrderID));
                in_node.AddString("MAT_ID", MPCF.Trim(gMatID));
                in_node.AddInt("MAT_VER", MPCF.Trim(gMatVer));
                in_node.AddChar("STEP", MPGC.MP_STEP_UNDELETE);
                in_node.AddString("LOSS_TYPE", "MODULE");
                in_node.AddString("LOSS_DATE", dtFrDate.GetValueAsString(8));

                if(string.IsNullOrEmpty(cdvShift.Text) == false)
                {
                    in_node.AddString("SHIFT_CODE", MPCF.Trim(cdvShift.Text));    
                }

                if (spdLossList.ActiveSheet.RowCount == 0)
                {
                    list_item = in_node.AddNode("LOSS_LIST");
                    list_item.AddString("CODE", MPCF.Trim(cdvLossCode.Tag));
                    list_item.AddString("CODE_DESC", MPCF.Trim(cdvLossCode.Text));
                }
                else
                {
                    for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                    {
                        list_item = in_node.AddNode("LOSS_LIST");
                        list_item.AddString("CODE", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_CODE].Value));
                        list_item.AddString("CODE_DESC", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_DESC].Value));
                    }
                }

                if (MPCF.CallService("CUS", "CUS_Module_Loss_Lot", in_node, ref out_node) == false)
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

        private bool ViewLotInfo(string sLotID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);

                if (MPCF.CallService("CUS", "CUS_View_Lot", in_node, ref out_node) == false)
                {
                    ClearOutNode();
                    return false;
                }

                if (spdLotInfo.SetDataToScreen(out_node) == false)
                {
                    ClearOutNode();
                    return false;
                }

                SetOutNode(out_node);
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetOutNode(TRSNode out_node)
        {
            gOrderID = out_node.GetString("ORDER_ID");
            gMatID = out_node.GetString("MAT_ID");
            gMatVer = out_node.GetInt("MAT_VER");
            gOper = out_node.GetString("OPER");
        }

        private void ClearOutNode()
        {
            gOrderID = string.Empty;
            gMatID = string.Empty;
            gMatVer = 0;
            gOper = string.Empty;
        }

        private void SetLotID()
        {
			if (string.IsNullOrEmpty(MPGV.gsCurrentLot_ID) == false)
			{
				gLotID = MPGV.gsCurrentLot_ID;
			}

            if (string.IsNullOrEmpty(gLotID) == false)
            {
                txtLotID.Text = gLotID;

                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranLossLotByModule_Load(object sender, EventArgs e)
        {
            spdLotInfo.InitFlexibleScreen();
            spdLotInfo.ScreenSpread.Tag = "Change Cell";
            dtFrDate.Value = DateTime.Today;

            if (spdLotInfo.LoadDesign("INV_LOT_INFO") == false)
                return;

            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLossList);

            SetLotID();
        }

        private void frmCUSTranLossLotByModule_Activated(object sender, EventArgs e)
        {
            SetLotID();
        }

        private void frmCUSTranLossLotByModule_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(txtLotID);

                bIsShown = true;
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if(string.IsNullOrEmpty(cdvLossCode.Text) == true && spdLossList.ActiveSheet.RowCount == 0)
            {
                MPCF.ShowMessage("불량코드가 선택후 진행바랍니다.", MSG_LEVEL.ERROR, false);
                cdvLossCode.Focus();
                return;
            }

            DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(377), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
            if (dr != System.Windows.Forms.DialogResult.OK) return;

            if (Tran_Loss_Lot(txtLotID.Text) == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }

            MPCF.ClearList(spdLossList);

            if (ViewLotInfo(txtLotID.Text) == true)
            {
                txtLotID.Text = "";
                cdvShift.Text = "";
                cdvLossCode.Text = "";
                MPCF.SetFocus(txtLotID);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@LOSS_REQUEST";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvLossCode.Text) != "")
                {
                    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                    {
                        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                    }
                }
                else
                {
                    cdvLossCode.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddRow() == true)
            {
                cdvLossCode.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (spdLossList.ActiveSheet.Rows.Count < 1)
                {
                    return;
                }

                spdLossList.Sheets[0].Rows[spdLossList.ActiveSheet.ActiveRowIndex].Remove();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

		private void btnTranCleaningEndLot_Click(object sender, EventArgs e)
		{
			try
			{
				BICF.OpenMenu("SOI2034");
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}  
		}

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "WRGR_CODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_3" };

                // Show
                cdvShift.Text = cdvShift.Show(cdvShift, "Code Desc", "VIEW_SHIFT_CODE", dvcArgu, display, header, "DATA_3", -1);

                if (MPCF.Trim(cdvShift.Text) != "")
                {
                    if (cdvShift.returnDatas != null && cdvShift.returnDatas.Count > 0)
                    {
                        cdvShift.Tag = cdvShift.returnDatas[0];
                    }
                }
                else
                {
                    cdvShift.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
