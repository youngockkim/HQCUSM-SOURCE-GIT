
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewQAHistoryByLot.cs
//   Description : MES Cient Form View Qa History By Lot
//
//   MES Version : 5.2.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-25 : Created by BS Kwak
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.WIPCore
{
	public partial class frmWIPViewQAHistoryByLot : Miracom.MESCore.ViewForm01
	{

        public frmWIPViewQAHistoryByLot()
		{	
			InitializeComponent();
		}

        #region " Enum Definition"

        private enum QA_HISTORY_COLUMNS
        {
            Seq,
            Lot_ID,
            Hist_Seq,
            QA_Hist_Seq,
            Trans_Time,
            Factory,
            MAT_ID,
            MAT_Ver,
            Flow,
            Flow_Seq_Num,
            Oper,
            QA_Oper,
            RES_ID,
            Carrier_ID,
            Qty1,
            Qty2,
            Qty3,
            Sample_Rule,
            Action_Rule,
            Pass_Flag,
            Sample_Size1,
            Sample_Size2,
            Defect_Qty1,
            Defect_Qty2,
            Yield1,
            Yield2,
            Test_Type,
            Inspector,
            Shift,
            IRR_MRR,
            Comment,
            Alarm_Code,
            Hist_Del_Flag,
            Hist_Del_Time,
            Hist_Del_User,
            Hist_Del_Comment,
            Cmf1,
            Cmf2,
            Cmf3,
            Cmf4,
            Cmf5,
            Cmf6,
            Cmf7,
            Cmf8,
            Cmf9,
            Cmf10,
            Resv_Field1,
            Resv_Field2,
            Resv_Field3,
            Resv_Field4,
            Resv_Field5,
            Resv_Field6,
            Resv_Field7,
            Resv_Field8,
            Resv_Field9,
            Resv_Field10            
        }

        private enum QA_LOT_DEFECT_COLUMNS
        {
            Seq,
            Lot_ID,
            Hist_Seq,
            QA_Hist_Seq,
            Trans_Time,
            Factory,
            Mat_ID,
            Mat_Ver,
            Flow,
            Flow_Seq,
            QA_Oper,
            Resource,
            Carrier,
            Qty1,
            Qty2,
            Qty3,
            Defect_Seq,
            Defect_Qty_Flag,
            Defect_Code,
            Defect_Qty,
            Yield,
            Hist_Del_Flag,
            Hist_Del_Time,
            Hist_Del_User,
            Hist_Del_Comment,
            Resv_Field1,
            Resv_Field2,
            Resv_Field3,
            Resv_Field4,
            Resv_Field5,
            Resv_Field6,
            Resv_Field7,
            Resv_Field8,
            Resv_Field9,
            Resv_Field10        
        }

        private enum QA_SUBLOT_DEFECT_COLUMNS
        {
            Seq,
            Lot_ID,
            Hist_Seq,
            Sub_Lot_ID,
            Sub_Lot_Hist_Seq,
            Slot_No,
            QA_Hist_Seq,
            Trans_Time,
            Factory,
            Mat_ID,
            Mat_Ver,
            Flow,
            Flow_Seq_Num,
            Operation,
            QA_Operation,
            Resource,
            Carrier,
            Qty2,
            Qty3,
            Defect_Qty_Flag,
            Defect_Code,
            Defect_Qty,
            Yield,
            Loc_X,
            Loc_Y,
            Loc_Z,
            Cell_X,
            Cell_Y,
            Cell_Z,
            Hist_Del_Flag,
            Hist_Del_Time,
            Hist_Del_User,
            Hist_Del_Comment,
            Resv_Field1,
            Resv_Field2,
            Resv_Field3,
            Resv_Field4,
            Resv_Field5,
            Resv_Field6,
            Resv_Field7,
            Resv_Field8,
            Resv_Field9,
            Resv_Field10    
        }
        #endregion

		#region " Constant Definition "
		
		#endregion
		
		#region " Variable Definition "
		
		private bool b_load_flag;
        //private bool bIsLeftButton;
		
		private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		
		private FarPoint.Win.Spread.CellType.GeneralCellType increaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		private FarPoint.Win.Spread.CellType.GeneralCellType decreaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
		
		private enum CELL_STATUS
		{
			PLUS = 1,
			MINUS = 2,
			EMPTY = 3,
			CHECK = 4
		}
		
		#endregion
		
		#region " Function Definition "
		//
		// CheckCondition()
		//       - Check the conditions before transaction
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//       - ByVal FuncName As String : Function Name
		//
        private bool CheckCondition(char ProcStep)
		{

            switch (ProcStep)
			{
                case '1':
					
					if (dtpFrom.Value > dtpTo.Value)
					{
						MPCF.ShowMsgBox(MPCF.GetMessage(120));
						dtpFrom.Value = DateTime.Today.AddMonths(- 1);
						return false;
					}
					break;
					
			}
			
			return true;
			
		}
		
		public void ActiveFormNow()
		{
			if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
			{
				txtLotID.Text = MPGV.gsCurrentLot_ID;
				btnView_Click(btnView, null);
			}
		}
		
		public virtual Control GetFisrtFocusItem()
		{
			try
			{
				return this.txtLotID;
				
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return null;
			}
			
	    }

        private bool ViewQAHistoryByLot(char c_step, string sFromTime, string sToTime, char sIncludeDelHistory)
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_QA_HISTORY_BY_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_QA_HISTORY_BY_LOT_OUT");

                int i = 0;
                int iRow = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("FROM_TRAN_TIME", MPCF.Trim(sFromTime));
                in_node.AddString("TO_TRAN_TIME", MPCF.Trim(sToTime));
                in_node.AddChar("HIST_DEL_FLAG", sIncludeDelHistory);

                if (MPCR.CallService("WIP", "WIP_View_Qa_Lot_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("LIST").Count != 0)
                {
                    FarPoint.Win.Spread.SheetView with_3 = spdHistory.Sheets[0];

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        with_3 = spdHistory.Sheets[0];
                        iRow = with_3.RowCount;
                        with_3.RowCount++;

                        if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                        {
                            with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Lot_ID, iRow, with_3.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Lot_ID, iRow, with_3.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Seq].Value = i + 1;
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Lot_ID].Value = out_node.GetList("LIST")[i].GetString("LOT_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Hist_Seq].Value = out_node.GetList("LIST")[i].GetInt("HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.QA_Hist_Seq].Value = out_node.GetList("LIST")[i].GetInt("QA_HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Trans_Time].Value = out_node.GetList("LIST")[i].GetString("TRAN_TIME");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Factory].Value =  out_node.GetList("LIST")[i].GetString("FACTORY");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.MAT_ID].Value = out_node.GetList("LIST")[i].GetString("MAT_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.MAT_Ver].Value = out_node.GetList("LIST")[i].GetInt("MAT_VER");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Flow].Value =out_node.GetList("LIST")[i].GetString("FLOW");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Flow_Seq_Num].Value = out_node.GetList("LIST")[i].GetInt("FLOW_SEQ_NUM");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Oper].Value = out_node.GetList("LIST")[i].GetString("OPER");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.QA_Oper].Value = out_node.GetList("LIST")[i].GetString("QA_OPER");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.RES_ID].Value = out_node.GetList("LIST")[i].GetString("RES_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Carrier_ID].Value = out_node.GetList("LIST")[i].GetString("CRR_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Qty1].Value = out_node.GetList("LIST")[i].GetDouble("QTY_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Qty2].Value = out_node.GetList("LIST")[i].GetDouble("QTY_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Qty3].Value = out_node.GetList("LIST")[i].GetDouble("QTY_3");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Sample_Rule].Value = out_node.GetList("LIST")[i].GetString("SMP_RULE_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Action_Rule].Value = out_node.GetList("LIST")[i].GetString("ACT_RULE_ID");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Pass_Flag].Value = out_node.GetList("LIST")[i].GetString("PASS_FLAG");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Sample_Size1].Value = out_node.GetList("LIST")[i].GetDouble("SMP_SIZE_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Sample_Size2].Value = out_node.GetList("LIST")[i].GetDouble("SMP_SIZE_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Defect_Qty1].Value = out_node.GetList("LIST")[i].GetDouble("DEF_QTY_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Defect_Qty2].Value = out_node.GetList("LIST")[i].GetDouble("DEF_QTY_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Yield1].Value = out_node.GetList("LIST")[i].GetDouble("YIELD_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Yield2].Value = out_node.GetList("LIST")[i].GetDouble("YIELD_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Test_Type].Value = out_node.GetList("LIST")[i].GetChar("TEST_TYPE");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Inspector].Value = out_node.GetList("LIST")[i].GetString("INSPECTOR");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Shift].Value = out_node.GetList("LIST")[i].GetString("SHIFT");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.IRR_MRR].Value = out_node.GetList("LIST")[i].GetString("IRRMRR");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Comment].Value = out_node.GetList("LIST")[i].GetString("QA_COMMENT");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Alarm_Code].Value = out_node.GetList("LIST")[i].GetString("ALARM_CODE");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Hist_Del_Flag].Value = out_node.GetList("LIST")[i].GetChar("HIST_DEL_FLAG");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Hist_Del_Time].Value = out_node.GetList("LIST")[i].GetString("HIST_DEL_TIME");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Hist_Del_User].Value = out_node.GetList("LIST")[i].GetString("HIST_DEL_USER");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Hist_Del_Comment].Value = out_node.GetList("LIST")[i].GetString("HIST_DEL_COMMENT");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf1].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf2].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf3].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_3");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf4].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_4");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf5].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_5");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf6].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_6");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf7].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_7");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf8].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_8");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf9].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_9");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Cmf10].Value = out_node.GetList("LIST")[i].GetString("QA_CMF_10");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field1].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_1");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field2].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_2");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field3].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_3");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field4].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_4");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field5].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_5");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field6].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_6");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field7].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_7");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field8].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_8");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field9].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_9");
                        with_3.Cells[iRow, (int)QA_HISTORY_COLUMNS.Resv_Field10].Value = out_node.GetList("LIST")[i].GetString("RESV_FIELD_10");

                    }
                }
                MPCF.FitColumnHeader(spdHistory);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        private bool ViewQALotDefectByLot(char c_step, string sLot, int iHistSeq, int iQaHistSeq)
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_QA_LOT_DEFECT_BY_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_QA_LOT_DEFECT_BY_LOT_OUT");

                int i = 0;
                int iRow = 0;

                spdDefect.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(sLot));
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(iHistSeq));
                in_node.AddInt("QA_HIST_SEQ", MPCF.ToInt(iQaHistSeq));


                if (MPCR.CallService("WIP", "WIP_View_Qa_Lot_Defect_By_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("DEFECT_LOT_LIST").Count != 0)
                {
                    FarPoint.Win.Spread.SheetView with_3 = spdDefect.Sheets[0];

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        with_3 = spdDefect.Sheets[0];
                        iRow = with_3.RowCount;
                        with_3.RowCount++;

                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Seq].Value = i + 1;
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Lot_ID].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("LOT_ID");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Hist_Seq].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetInt("HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.QA_Hist_Seq].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetInt("QA_HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Trans_Time].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("TRAN_TIME");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Factory].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("FACTORY");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Mat_ID].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("MAT_ID");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Mat_Ver].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetInt("MAT_VER");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Flow].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("FLOW");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Flow_Seq].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetInt("FLOW_SEQ");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.QA_Oper].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("OPER");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resource].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RES_ID");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Carrier].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("CRR_ID");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Qty1].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetDouble("QTY_1");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Qty2].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetDouble("QTY_2");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Qty3].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetDouble("QTY_3");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Defect_Seq].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetInt("DEF_SEQ");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Defect_Qty_Flag].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetChar("DEF_QTY_FLAG");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Defect_Code].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("DEF_CODE");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Defect_Qty].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetDouble("DEF_QTY");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Yield].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetDouble("YIELD");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Hist_Del_Flag].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetChar("HIST_DEL_FLAG");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Hist_Del_Time].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("HIST_DEL_TIME");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Hist_Del_User].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("HIST_DEL_USER");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Hist_Del_Comment].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("HIST_DEL_COMMENT");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field1].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_1");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field2].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_2");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field3].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_3");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field4].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_4");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field5].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_5");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field6].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_6");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field7].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_7");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field8].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_8");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field9].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_9");
                        with_3.Cells[iRow, (int)QA_LOT_DEFECT_COLUMNS.Resv_Field10].Value = out_node.GetList("DEFECT_LOT_LIST")[i].GetString("RESV_FIELD_10");

                    }
                }
                MPCF.FitColumnHeader(spdDefect);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewQASubLotDefectByLot(char c_step, string sLot, int iHistSeq, int iQaHistSeq)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_SUBLOT_QA_DEFECT_BY_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_SUBLOT_QA_DEFECT_BY_LOT_OUT");

                int i = 0;
                int iRow = 0;

                spdSltDefect.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(sLot));
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(iHistSeq));
                in_node.AddInt("QA_HIST_SEQ", MPCF.ToInt(iQaHistSeq));

                if (MPCR.CallService("WIP", "WIP_View_Qa_SubLot_Defect_By_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("DEFECT_SUBLOT_LIST").Count != 0)
                {
                    FarPoint.Win.Spread.SheetView with_3 = spdSltDefect.Sheets[0];

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        with_3 = spdSltDefect.Sheets[0];
                        iRow = with_3.RowCount;
                        with_3.RowCount++;

                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Seq].Value = i + 1;
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Lot_ID].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("LOT_ID");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Hist_Seq].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Sub_Lot_ID].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("SUBLOT_ID");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Sub_Lot_Hist_Seq].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("SUB_LOT_HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Slot_No].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("SLOT_NO");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.QA_Hist_Seq].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("QA_HIST_SEQ");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Trans_Time].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("TRAN_TIME");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Factory].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("FACTORY");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Mat_ID].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("MAT_ID");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Mat_Ver].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("MAT_VER");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Flow].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("FLOW");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Flow_Seq_Num].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetInt("FLOW_SEQ_NUM");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Operation].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("OPER");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.QA_Operation].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("QA_OPER");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resource].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RES_ID");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Carrier].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("CRR_ID");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Qty2].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("QTY_2");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Qty3].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("QTY_3");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Defect_Qty_Flag].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetChar("DEF_QTY_FLAG");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Defect_Code].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("DEF_CODE");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Defect_Qty].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("DEF_QTY");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Yield].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("YIELD");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Loc_X].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("LOC_X");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Loc_Y].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("LOC_Y");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Loc_Z].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("LOC_Z");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Cell_X].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("CELL_X");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Cell_Y].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("CELL_Y");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Cell_Z].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetDouble("CELL_Z");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Hist_Del_Flag].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetChar("HIST_DEL_FLAG");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Hist_Del_Time].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("HIST_DEL_TIME");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Hist_Del_User].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("HIST_DEL_USER");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Hist_Del_Comment].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("HIST_DEL_COMMENT");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field1].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_1");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field2].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_2");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field3].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_3");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field4].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_4");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field5].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_5");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field6].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_6");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field7].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_7");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field8].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_8");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field9].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_9");
                        with_3.Cells[iRow, (int)QA_SUBLOT_DEFECT_COLUMNS.Resv_Field10].Value = out_node.GetList("DEFECT_SUBLOT_LIST")[i].GetString("RESV_FIELD_10");
                    }
                }
                MPCF.FitColumnHeader(spdSltDefect);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
		#endregion


        private void btnView_Click(System.Object sender, System.EventArgs e)
		{
			string sFromTime;
			string sToTime;
            char sIncludeDelHist;

            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdDefect, true);
            MPCF.ClearList(spdSltDefect, true);
			
			if (txtLotID.Text != "")
			{
				if (CheckCondition('1') == false)
				{
					return;
				}
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);
                sIncludeDelHist = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';
                if (ViewQAHistoryByLot('1', sFromTime, sToTime, sIncludeDelHist) == false)
				{
					return;
				}
				
				MPCF.FitColumnHeader(spdHistory);
				
				this.Text = MPCF.FindLanguage("QA History", 0) + " (" + txtLotID.Text + ")";
				this.lblFormTitle.Text = this.Text;
				
			}
		}

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            //string sCond;

            //sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            //if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, false, -1, -1) == false)
            //{
            //    return;
            //}

        }

        private void frmFPDViewQAHistoryByLot_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCF.ClearList(spdDefect, true);
                MPCF.ClearList(spdSltDefect, true);
                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;
                txtLotID.Focus();

                ActiveFormNow();

                b_load_flag = true;
            }
        }

        private void spdHistory_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int HIST_SEQ = 0;
            int QA_HIST_SEQ = 0;

            MPCF.ClearList(spdDefect, true);
            MPCF.ClearList(spdSltDefect, true);

            HIST_SEQ = MPCF.ToInt(spdHistory.ActiveSheet.Cells[e.Row, (int)QA_HISTORY_COLUMNS.Hist_Seq].Value);
            QA_HIST_SEQ = MPCF.ToInt(spdHistory.ActiveSheet.Cells[e.Row, (int)QA_HISTORY_COLUMNS.QA_Hist_Seq].Value);

            ViewQALotDefectByLot('1', txtLotID.Text, HIST_SEQ, QA_HIST_SEQ);
            ViewQASubLotDefectByLot('2', txtLotID.Text, HIST_SEQ, QA_HIST_SEQ);
        }

        private void btnQASheet_Click(object sender, EventArgs e)
        {
           // FPDCR.ViewFile('1', "QA_SHEET", txtLotID.Text + ".xls");
        }
		
	}
	
}
