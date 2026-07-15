//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranEndLot.cs
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
//       - 2017-08-09 : Created by bkwoo
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
    public partial class frmCUSTranCleaningEndLot : BOIBaseForm02
    {
        #region [Property]

        #endregion

		public frmCUSTranCleaningEndLot()
        {
            InitializeComponent();
        }

        #region [Constant Definition]
		private readonly string FLOW_NORMAL= "NORMAL";
		private readonly string OPER_CLEANING = "2410";
		private readonly string OPER_FRONT_FQC = "2420";
		private readonly string RESID_CLEANING = "CLN01";
		private readonly string LOT_STATUS_WAIT = "WAIT";

		private const int LOT_LIST_MAX_COUNT = 20;

		private enum LOT_COL : int
		{
			LAST_TRAN_TIME,
			LOT_ID,
			MAT_ID,
			MAT_DESC,
			QTY_1,
			UNIT_1,
			OPER,
			OPER_DESC,
			ORDER_ID,
			STARTUS,
		}

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

		private void frmCUSTranCleaningEndLot_Load(object sender, EventArgs e)
		{
			InitCtrl();
		}

        #endregion

        #region [Function Definition]

		private void InitCtrl()
		{
			try
			{
				MPCF.FieldClear(txtRefeshLOTID, txtInputLOTID);
				chkRefreshFlag.Checked = true;

				txtRefeshLOTID.Text = "";
				txtRefeshLOTID.ReadOnly = true;
				txtInputLOTID.Text = "";

				trmRefreshLotID.Start();
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
			try
			{
				
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
        }

        private bool CheckCondition(string FuncName)
        {
			try
			{
				switch (FuncName)
				{
					case "VIEW":

						break;

					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return false;
			}

			return true;
        }

        /// <summary>
        /// Tran End Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private void Tran_End_Lot()
        {
			TRSNode in_node = new TRSNode("TRAN_IN");
			TRSNode out_node = new TRSNode("TRAN_OUT");

			try
			{
				MPCF.SetInMsg(in_node);
				in_node.ProcStep = '1';
				in_node.AddString("LOT_ID", MPCF.Trim(txtInputLOTID.Text));
				in_node.AddString("RES_ID", RESID_CLEANING);
				in_node.AddString("OPER", OPER_CLEANING);

				if (MPCF.CallService("CUS", "CWIP_End_lot", in_node, ref out_node) == false)
				{
					return;
				}

				//최신 이력은 20개 까지만 유지
				int spdLotListMaxRowCnt = 20;
				if (spdLotList.ActiveSheet.RowCount > spdLotListMaxRowCnt)
				{
					for (int i = spdLotList.ActiveSheet.RowCount - 1; i >= spdLotListMaxRowCnt; i--)
					{
						spdLotList.ActiveSheet.Rows[i].Remove();
					}
				}

				//종료 진행 LOT 리스트에 추가
				spdLotList.ActiveSheet.AddRows(0, 1);
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME")); 
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = out_node.GetString("LOT_ID");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = out_node.GetString("MAT_ID");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = out_node.GetString("MAT_DESC");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = out_node.GetDouble("QTY_1").ToString();
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = out_node.GetString("UNIT_1");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = out_node.GetString("OPER");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = out_node.GetString("OPER_DESC");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = out_node.GetString("ORDER_ID");
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = out_node.GetString("LOT_STATUS");

				MPCF.FitColumnHeader(spdLotList);
				spdLotList.ActiveSheet.Columns[(int)LOT_COL.MAT_DESC].Width = 100f;

				MPCF.ShowSuccessMessage(out_node, false);
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}
        }


        #endregion        

		private void trmRefreshLotID_Tick(object sender, EventArgs e)
		{
			if(chkRefreshFlag.Checked == true)
			{
				//cleaning 공정 Wait 중인(End가 안된) 모듈 중 가장 최신 Lot 조회
				View_Cleaning_Not_End_Lot();
			}

			//자동 조회 후 커서는 항상 수동 LOTID 입력 창으로 이동
			txtInputLOTID.Text = "";
			MPCF.SetFocusAndSelectAll(txtInputLOTID);
		}

		private void View_Cleaning_Not_End_Lot()
		{
			TRSNode in_node = new TRSNode("TRAN_IN");
			TRSNode out_node = new TRSNode("TRAN_OUT");

			try
			{
			    MPCF.SetInMsg(in_node);
			    in_node.AddString("FLOW", FLOW_NORMAL);
			    in_node.AddString("OPER", OPER_FRONT_FQC);
			    in_node.AddString("LOT_STATUS", LOT_STATUS_WAIT);

				if (MPCF.CallService("CUS", "CUS_View_Front_FQC_Wait_Lot", in_node, ref out_node) == false)
				{
					MPCF.ShowMessage(MPCF.GetMessage(459), MSG_LEVEL.ERROR, false);
					txtRefeshLOTID.Text = "";
					return;
				}

				//Server에서 DB Not Found 이외에는 에러를 내지 않고 LOT_ID를 ""으로 던져줌
				txtRefeshLOTID.Text = out_node.GetString("LOT_ID");
				if (string.IsNullOrEmpty(MPCF.Trim(txtRefeshLOTID.Text)))
				{
					MPCF.ShowMessage(MPCF.GetMessage(459), MSG_LEVEL.ERROR, false);
					return;
				}
				MPCF.SetFocus(txtRefeshLOTID);
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}
		}

		private void chkRefreshFlag_CheckedChanged(object sender, EventArgs e)
		{
			if (chkRefreshFlag.Checked == true)
			{
				 trmRefreshLotID.Start();
			}
			else
			{
				trmRefreshLotID.Stop();
			}
		}

		private void txtInputLOTID_KeyPress(object sender, KeyPressEventArgs e)
		{
			//int i;
			//if (int.TryParse(e.KeyChar.ToString(), out i))
			//{
			chkRefreshFlag.Checked = false;
			trmRefreshLotID.Stop();
			//}
		}

		private void btnProcess_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(MPCF.Trim(txtInputLOTID.Text)) == true)
			{
				return;
			}

			Tran_End_Lot();

			txtInputLOTID.Text = "";
			MPCF.SetFocusAndSelectAll(txtInputLOTID);

			chkRefreshFlag.Checked = true;
			trmRefreshLotID.Start();
		}

		private void txtInputLOTID_KeyDown(object sender, KeyEventArgs e)
		{
			chkRefreshFlag.Checked = false;
			trmRefreshLotID.Stop();
		}

		private void btnLossRegister_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtRefeshLOTID.Text) == false)
				{
					MPGV.gsCurrentLot_ID = txtRefeshLOTID.Text;
				}

				BICF.OpenMenu("SOI2029");
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			}  
		}

		private void frmCUSTranCleaningEndLot_Activated(object sender, EventArgs e)
		{
			chkRefreshFlag.Checked = true;
			trmRefreshLotID.Start();
			txtRefeshLOTID.Text = "";
		}

		private void frmCUSTranCleaningEndLot_Deactivate(object sender, EventArgs e)
		{
			chkRefreshFlag.Checked = false;
			trmRefreshLotID.Stop();
		}
    }
}
