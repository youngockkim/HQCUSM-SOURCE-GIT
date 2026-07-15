
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Drawing;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modSPCListRoutine.vb
//   Description : Client Common List function SPC Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//        -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by HK, Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _SPC = True Then

namespace Miracom.MESCore
{
    public sealed class SPCLIST
    {
        
        #region "Constant Defintion"
        
        //spdCharacter
        private const int CHAR_ID = 0;
        private const int CHAR_DESC = 1;
        private const int UNIT_COUNT = 2;
        private const int VALUE_COUNT_COL = 3;
        private const int OPT_INPUT_FLAG = 4;
        private const int BLANK_REC_SAVE_FLAG = 5;
        private const int DISPLAY_PRECISION = 6;
        private const int DEF_UNIT_FLAG = 7;
        private const int DEF_UNIT_OVR_FLAG = 8;
        private const int DEF_VALUE = 9;
        private const int UNIT_TBL = 10;
        private const int VALUE_TBL = 11;
        private const int SPEC_OUT_UNIT_FLAG = 12;
        private const int SPEC_OUT_COUNT = 13;
        private const int SPEC_TYPE = 14;
        private const int SPEC_USL = 15;
        private const int SPEC_UCL = 16;
        private const int SPEC_CL = 17;
        private const int SPEC_LCL = 18;
        private const int SPEC_LSL = 19;
        private const int R_SPEC_TYPE = 20;
        private const int R_SPEC_UCL = 21;
        private const int R_SPEC_CL = 22;
        private const int R_SPEC_LCL = 23;

        private const int LOTID_COL = 5;
        private const int MATID_COL = 6;
        private const int MATDESC_COL = 7;
        private const int MATVER_COL = 8;
        private const int FLOW_COL = 9;
        private const int OPER_COL = 10;
        private const int PROCOPER_COL = 11;
        private const int RESID_COL = 12;
        private const int SUBRES_COL = 13;
        private const int PROCRES_COL = 14;
        private const int EVENT_COL = 15;
        private const int VALUE_START_COL = 19;
        private const int VALUE_END_COL = 1018;
        private const int UNITUSE_COL = 1037;
        
        #endregion
        
        // ViewChartList()
        //       - View Chart list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú parent ndoe
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        public static bool ViewChartList(Control control, char c_step, string sMatID, int iMatVer, string sOper, string sResID, string sCharID, char sLotResFlag, char sIncludeDeleteChart, string sFilter, string sFlow, int Col, int Row, TreeNode parentNode, string sExt_Factory)
        {
            return ViewChartList(control, c_step, sMatID, iMatVer, sOper, sResID, sCharID, sLotResFlag, sIncludeDeleteChart, sFilter, sFlow, ' ', Col, Row, parentNode, sExt_Factory);
        }
        public static bool ViewChartList(Control control, char c_step, string sMatID, int iMatVer, string sOper, string sResID, string sCharID, char sLotResFlag, char sIncludeDeleteChart, string sFilter, string sFlow, char sNotSyncEDC, int Col, int Row, TreeNode parentNode, string sExt_Factory)
        {
            
            try
            {
                int i;
                ListViewItem itmX;
                TreeNode nodeX;
                string[] strData = null;
                List<string> sList = new List<string>();
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
                ArrayList a_list = new ArrayList();

                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node;
                
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }

                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);
                in_node.AddString("RES_ID", sResID);
                in_node.AddString("CHAR_ID", sCharID);
                in_node.AddChar("LOT_RES_FLAG", sLotResFlag);
                in_node.AddChar("INCLUDE_DELETE_CHART", sIncludeDeleteChart);
                in_node.AddChar("SYNC_EDC_FLAG", sNotSyncEDC);
                in_node.AddString("FILTER", sFilter);
                in_node.AddString("NEXT_CHART_ID", "");
                
                do
                {
                     out_node = new TRSNode("View_Chart_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Chart_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_CHART_ID") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (((ListView)control).Columns.Count == 2)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")));
                            }
                            else if (((ListView)control).Columns.Count > 2)
                            {
                                itmX.SubItems.Add(MPCF.GetGraphType((eGraphType)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetList(0)[i].GetString("GRAPH_TYPE"))), false));
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                            {
                                itmX.ForeColor = Color.Magenta;
                            }

                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")), (int)SMALLICON_INDEX.IDX_CHART_LINE, (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                        }
                        else if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));

                        }

                    }
                }

                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    strData = new string[sList.Count + 1];
                    for (i = 0; i < sList.Count; i++)
                    {
                        strData[i] = sList[i];
                    }
                    strData[i] = "";

                    cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cboCellType.Items = strData;
                    if (Row == - 1 && Col == - 1)
                    {
                        //Do Nothing
                    }
                    else if (Row == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                    }
                    else if (Col == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                    }
                    else
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewChartList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCAlarmHistory()
        //       - View SPC Alarm History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewSPCAlarmHistory(FarPoint.Win.Spread.FpSpread spdData, char c_step, string sChartID, string sFromTime, string sToTime, char sIncDelChart, string sChartSetID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Alarm_History_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();
                FarPoint.Win.Spread.SheetView sheet;
                int i;
                int iRow;
                int iCol;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddChar("INC_DEL_CHART", sIncDelChart);

                in_node.AddString("NEXT_CHART_ID", sChartID);
                in_node.AddString("CHART_SET_ID", sChartSetID);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                                
                MPCF.ClearList(spdData, true);
                sheet = spdData.ActiveSheet;
                do
                {
                     out_node = new TRSNode("View_Alarm_History_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Alarm_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0);


                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        if (out_node.GetList(0)[i].GetChar("CLEAR_FLAG") == 'Y') 
                        {
                            sheet.Rows[iRow].ForeColor = Color.Magenta;
                        }

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHART_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ALARM_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("XR_FLAG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("OOC_TYPE");
                        
                        iCol++;
                        if (out_node.GetList(0)[i].GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_ERROR) 
                        {
                            sheet.Cells[iRow, iCol].Value = "Error";
                            
                            iCol++;
                        }
                        else if (out_node.GetList(0)[i].GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_WARN) 
                        {
                            sheet.Cells[iRow, iCol].Value = "Warning";
                            
                            iCol++;
                        }
                        else
                        {
                            sheet.Cells[iRow, iCol].Value = "Info";
                            
                            iCol++;
                        }
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ALARM_MSG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("ACK_FLAG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ACK_TIME"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ACK_USER_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("CLEAR_FLAG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAR_TIME"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CLEAR_USER_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CLEAR_COMMENT");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_RES_FLAG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");
                    
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_OPER");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_RES_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("EVENT_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHAR_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("UNIT_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ");
                        
                        iCol++;
                    }
                }
                if (in_node.ProcStep == '2') 
                {
                    spdData.ActiveSheet.Columns[0].Visible = false;
                }
                else
                {
                    spdData.ActiveSheet.Columns[0].Visible = true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewSPCAlarmHistory()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewExcludedEDCHistory()
        //       - View Excluded History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewExcludedEDCHistory(FarPoint.Win.Spread.FpSpread spdData, char c_step, string sChartID, string sFromTime, string sToTime, char sTranFlag, string sChartSetID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Exclude_History_List_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();
                FarPoint.Win.Spread.SheetView sheet;
                int i;
                int iRow;
                int iCol;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddChar("TRAN_FLAG", sTranFlag);
                in_node.AddString("CHART_SET_ID", sChartSetID);

                in_node.AddString("NEXT_CHART_ID", sChartID);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddInt("NEXT_UNIT_SEQ", int.MaxValue);

                
                MPCF.ClearList(spdData, true);
                sheet = spdData.ActiveSheet;
                do
                {
                    out_node = new TRSNode("View_Exclude_History_List_Out");

                    if (MessageCaster.CallService("SPC", "SPC_View_Exclude_History_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0);
                
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                      iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        if (out_node.GetList(0)[i].GetChar("TRAN_FLAG") == 'D') 
                        {
                            sheet.Rows[iRow].ForeColor = Color.Magenta;
                        }
                        
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHART_ID");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("TRAN_FLAG");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("TRAN_COMMENT");
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        
                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                        
                        iCol++;
                    }
                }
                    
                if (in_node.ProcStep == '2') 
                {
                    spdData.ActiveSheet.Columns[0].Visible = false;
                }
                else
                {
                    spdData.ActiveSheet.Columns[0].Visible = true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewExcludedEDCHistory()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewChartSetList()
        //       - View Chart Set List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewChartSetList(Control control, char c_step, string sMatID, int iMatVer, string sOper, string sResID, char sLotResFlag, string sFlow, int Col, int Row, string sExt_Factory)
        {
            
            try
            {
                int i;
                ListViewItem itmX;
                string[] strData = null;
                List<string> sList = new List<string>();
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
                ArrayList a_list = new ArrayList();
                TRSNode in_node = new TRSNode("View_Chart_Set_List_In");
                TRSNode out_node;
                
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }

                MPCR.SetInMsg(in_node);
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);
                in_node.AddString("RES_ID", sResID);
                in_node.AddChar("LOT_RES_FLAG", sLotResFlag);
                in_node.AddString("NEXT_CHART_SET_ID", "");

                
                do
                {
                    out_node = new TRSNode("View_Chart_Set_List_Out");

                    if (MessageCaster.CallService("SPC", "SPC_View_Chart_Set_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_SET_ID", out_node.GetString("NEXT_CHART_SET_ID"));

                } while (in_node.GetString("NEXT_CHART_SET_ID") != "");
                   
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_SET_ID")), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_SET_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_SET_ID")));
                        }
                        else if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_SET_ID")));

                        }
                    }
                }

                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    strData = new string[sList.Count + 1];
                    for (i = 0; i < sList.Count; i++)
                    {
                        strData[i] = sList[i];
                    }
                    strData[i] = "";

                    cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cboCellType.Items = strData;
                    if (Row == - 1 && Col == - 1)
                    {
                        //Do Nothing
                    }
                    else if (Row == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                    }
                    else if (Col == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                    }
                    else
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                    }
                    
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewChartSetList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCSpecList()
        //       - View Spec list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú parent ndoe
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewSPCSpecList(Control control, char c_step, string sChartID, TreeNode parentNode, string sExt_Factory)
        {
            
            try
            {
                int i;
                ListViewItem itmX;
                TreeNode nodeX;
                ArrayList a_list = new ArrayList();

                TRSNode in_node = new TRSNode("SPC_View_Spec_List_In");
                TRSNode out_node;
                
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                else if (!(control is TreeView))
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }

                in_node.AddString("CHART_ID", sChartID);
                in_node.AddInt("NEXT_VERSION", int.MaxValue);

                
                do
                {
                    out_node = new TRSNode("SPC_View_Spec_List_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Spec_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetInt("NEXT_VERSION", out_node.GetInt("NEXT_VERSION"));

                } while (in_node.GetInt("NEXT_VERSION") > 0);
                    
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("VERSION")), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("RELEASE_FLAG")));
                            }
                            ((ListView)control).Items.Add(itmX);

                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetInt("VERSION")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetChar("RELEASE_FLAG")), (int)SMALLICON_INDEX.IDX_CHART_LINE, (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("VERSION")));

                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewSpecList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCAttachUserList()
        //       - View attached User list to chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewSPCAttachUserList(Control control, char c_step, string sKey, string sExtFactory)
        {
            
            int i;
            ListViewItem itmX;
            ArrayList a_list = new ArrayList();

            TRSNode in_node = new TRSNode("FMB_View_UDR_Group_List_In");
            TRSNode out_node;
            
            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                
                if (sExtFactory != "")
                {
                    in_node.Factory = sExtFactory;
                }

                in_node.AddString("NEXT_USER_ID", "", true);
                in_node.AddString("NEXT_CHART_ID", "");

                
                if (c_step == '1')
                {
                    in_node.SetString("NEXT_CHART_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.SetString("NEXT_USER_ID", sKey, true);
                }
                
                do
                {
                    out_node = new TRSNode("View_Attach_User_List_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Chart_User_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_USER_ID", out_node.GetString("NEXT_USER_ID"), true);
                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_USER_ID") != "" || in_node.GetString("NEXT_CHART_ID") != "");
                    

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            if (c_step == '1')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("USER_ID")), (int)SMALLICON_INDEX.IDX_USER);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("USER_DESC")));
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SEC_GRP_ID")));
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EMAIL_ID")));
                                }
                            }
                            else if (c_step == '2')
                            {
                                itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                                if (((ListView)control).Columns.Count > 1)
                                {
                                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")));
                                }
                            }
                        }
                    }
                }


                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewAttachUserList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCAttachChartList()
        //       - View Attach Chart Set List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        //
        public static bool ViewSPCAttachChartList(Control control, char c_step, string sChartSetID, string sExt_Factory)
        {
            
            try
            {
                int i;
                ListViewItem itmX;
                ArrayList a_list = new ArrayList();

                TRSNode in_node = new TRSNode("SPC_View_Attach_Chart_Set_List_In");
                TRSNode out_node;

                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                
                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }
                else
                {
                    
                }
                in_node.AddString("CHART_SET_ID", sChartSetID);
                in_node.AddString("NEXT_CHART_ID", "");

                
                do
                {
                    out_node = new TRSNode("SPC_View_Attach_Chart_Set_List_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Attach_Chart_Set_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_CHART_ID") != "");
                   
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (((ListView)control).Columns.Count > 1)
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")));
                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));

                        }
                    }
                }

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewAttachChartList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCEDCData()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewSPCEDCData(FarPoint.Win.Spread.FpSpread spdData, char c_step, string sChartID, string sFromTime, string sToTime, int iPrecision, int iAverageCol, int iUnitCount, char sUseUnit, string sValueType, int iHistSeq, int iUnitSeq, bool bShowTotal, char sShowExcludeData)
        {
            TRSNode in_node = new TRSNode("View_EDC_Data_In");
            TRSNode out_node;
            FarPoint.Win.Spread.SheetView sheet;
            ArrayList a_list = new ArrayList();
            int i;
            int j;
            int k;
            int result;
            int iRow;
            int iCol;
            int iLastCol = 0;
            int iNominalCol = 0;
            double dAverage;
            double dSigma;
            double dRange;
            double dMin;
            double dMax;
            double dValue;
            double dWeightValue = 0.0;
            int iOOCType = 0;
            int iOOCType2 = 0;
            int iCount = 0;
            int iWeightValueCount = 0;
            int iAverageCount = 0;
            int iSigmaCount = 0;
            int iRangeCount = 0;
            int iValueCount = 0;
            int iMaxCol = 0;
            
            try
            {
                FarPoint.Win.BevelBorder BevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                dValue = 0;
                dAverage = 0;
                dSigma = 0;
                dRange = 0;
                dMin = double.MaxValue;
                dMax = 0;

                if (iUnitCount < 1) iUnitCount = 1;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", sChartID);
                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddChar("INCLUDE_FLAG", sShowExcludeData);
                                
                if (iHistSeq == - 1)
                {
                    in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                }
                else
                {
                    in_node.AddInt("NEXT_HIST_SEQ", iHistSeq);
                }
                
                if (iUnitSeq == - 1)
                {
                    in_node.AddInt("NEXT_UNIT_SEQ", int.MaxValue);
                }
                else
                {
                    in_node.AddInt("NEXT_UNIT_SEQ", iUnitSeq); ;
                }

                in_node.AddInt("NEXT_VALUE_SEQ", 0);
                
                MPCF.ClearList(spdData, true);

                sheet = spdData.ActiveSheet;
                do
                {
                    out_node = new TRSNode("View_EDC_Data_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_EDC_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
                    in_node.SetInt("NEXT_VALUE_SEQ", out_node.GetInt("NEXT_VALUE_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0 || in_node.GetInt("NEXT_VALUE_SEQ") > 0);

                 foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        sheet.Cells[iRow, iCol].Value = sChartID;
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ");
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_RES_FLAG");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_DESC");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBRES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("EVENT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));

                        iCol++;
                        iNominalCol = iCol;
                        if (sheet.Columns[iCol].Visible == true)
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("NOMINAL")), iPrecision);
                        }
                        iCol++;

                        if (sheet.Columns[iCol].Visible == true)
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PROCESS_SIGMA")), iPrecision);
                        }
                        iCol++;

                        iValueCount = i + Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                        for (j = i; j <= iValueCount; j++)
                        {
                            for (k = 0; k <= out_node.GetList(0)[j].GetInt("VALUE_COUNT") - 1; k++)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                {
                                    sheet.Cells[iRow, iCol].Value = MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                }

                                iCol++;

                                if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                {
                                    dValue += MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                    iCount++;
                                }

                            }
                        }
                        if (iMaxCol < iCol)
                        {
                            iMaxCol = iCol;
                        }

                        iLastCol = iCol - 1;
                        iCol = iAverageCol - 1;


                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MAX_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MIN_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("USL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"));


                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) != "")
                        {
                            dWeightValue += MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            iWeightValueCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")), iPrecision) != "")
                        {
                            dAverage += MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            iAverageCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), iPrecision) != "")
                        {
                            dSigma += MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            iSigmaCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), iPrecision) != "")
                        {
                            dRange += MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            iRangeCount++;
                        }

                        if (dMin > MPCF.ToDbl(out_node.GetList(0)[i].GetString("MIN_VALUE")))
                        {
                            dMin = MPCF.ToDbl(out_node.GetList(0)[i].GetString("MIN_VALUE"));
                        }
                        if (dMax < MPCF.ToDbl(out_node.GetList(0)[i].GetString("MAX_VALUE")))
                        {
                            dMax = MPCF.ToDbl(out_node.GetList(0)[i].GetString("MAX_VALUE"));
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")) != "")
                        {
                            iOOCType++;
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2")) != "")
                        {
                            iOOCType2++;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("EXCLUDE_FLAG")) == "Y")
                        {
                            sheet.Cells[iRow, 0, iRow, sheet.ColumnCount - 1].ForeColor = Color.Magenta;
                        }

                        i += Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                    }
                }

                if (sUseUnit != 'Y')
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i += iUnitCount)
                    {
                        for (j = iAverageCol - 1; j < iAverageCol + 16; j++)
                        {
                            spdData.ActiveSheet.Cells[i, j].RowSpan = iUnitCount;
                        }
                        spdData.ActiveSheet.Cells[i, iNominalCol].RowSpan = iUnitCount;
                        spdData.ActiveSheet.Cells[i, iNominalCol+ 1].RowSpan = iUnitCount;
                    }
                }

                if (sheet.RowCount > 0)
                {
                    for (i = VALUE_START_COL; i < iMaxCol; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = true;
                    }
                    for (i = iMaxCol; i <= VALUE_END_COL; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = false;
                    }

                    //if (sValueType == "N")
                    //{
                    //    dWeightValue /= iWeightValueCount;
                    //    dAverage /= iAverageCount;
                    //    dSigma /= iSigmaCount;
                    //    dRange /= iRangeCount;

                    //    if (bShowTotal == true)
                    //    {
                    //        if (sheet.RowCount != 0)
                    //        {
                    //            iRow = sheet.RowCount;
                    //            sheet.RowCount++;
                    //            sheet.Cells[iRow, iLastCol].Value = MPCF.SetPrecision(Convert.ToString(dValue / iCount), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol - 1].Value = MPCF.SetPrecision(Convert.ToString(dWeightValue), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol].Value = MPCF.SetPrecision(Convert.ToString(dAverage), iPrecision);

                    //            sheet.Cells[iRow, iAverageCol + 1].Value = MPCF.SetPrecision(Convert.ToString(dSigma), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 2].Value = MPCF.SetPrecision(Convert.ToString(dRange), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 3].Value = MPCF.SetPrecision(Convert.ToString(dMax), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 4].Value = MPCF.SetPrecision(Convert.ToString(dMin), iPrecision);
                    //            if (sUseUnit == 'Y')
                    //            {
                    //                sheet.Cells[iRow, iAverageCol + 13].Value = iOOCType;
                    //                sheet.Cells[iRow, iAverageCol + 14].Value = iOOCType2;
                    //            }
                    //            else
                    //            {
                    //                sheet.Cells[iRow, iAverageCol + 13].Value = iOOCType / iUnitCount;
                    //                sheet.Cells[iRow, iAverageCol + 14].Value = iOOCType2 / iUnitCount;
                    //            }
                    //            sheet.Rows[iRow].BackColor = SystemColors.Control;
                    //            sheet.Rows[iRow].Border = BevelBorder1;

                    //        }
                    //    }
                    //}
                }

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewEDCData()\n" + ex.Message);
                return false;
            }
            
        }
        
        //
        // ViewSPCDefaultUnitList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public static bool ViewSPCDefaultUnitList(FarPoint.Win.Spread.FpSpread spdData, string ProcStep, string sChartID, int Col, int Row, int RowCnt, int iUnitSeq)
        {
            int j;
            
            TRSNode in_node = new TRSNode("View_Default_Unit_List_In");
            TRSNode out_node = new TRSNode("View_Default_Unit_List_Out"); 
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", sChartID);

                if (MessageCaster.CallService("SPC", "SPC_View_Default_Unit_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                for (j = 0; j < out_node.GetList(0).Count; j++)
                {
                    if (RowCnt <= j)
                    {
                        break;
                    }
                    FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;
                    if (iUnitSeq == -1)
                    {
                        with_1.SetValue(Row + j, Col, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                        if (MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")) == "")
                        {
                            with_1.Cells[Row + j, Col].Tag = "NULL";
                        }
                    }
                    else
                    {
                        if (j == iUnitSeq - 1)
                        {
                            with_1.SetValue(Row, Col, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                            if (MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")) == "")
                            {
                                with_1.Cells[Row, Col].Tag = "NULL";
                            }
                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // ViewChartList()
        //       - View Chart list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal parentNode As TreeNode = Nothing    : TreeView ?êÏÑú parent ndoe
        //        - Optional ByVal sExt_Factory As String = "": ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞??Factory
        
        public static bool ViewChartListDetail(Control control, char c_step, string sMatID, int iMatVer, 
            string sFlow, string sOper, string sResID, string sSubResID, string sCharID, char sLotResFlag, string sGraphType, 
            char sUnitUseFlag, char sValueTypeFlag, string sGroup, string sGroupTable, string sChartSetID, 
            string sFilter, char sIncludeDeleteChart, int Col, int Row, TreeNode parentNode, string sExt_Factory)
        {
            
            try
            {
                int i;
                ListViewItem itmX;
                TreeNode nodeX;
                string[] strData = null;
                List<string> sList = new List<string>();
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                int iCount = 0;
                ArrayList a_list = new ArrayList();

                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node;
                
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (sExt_Factory != "")
                {
                    in_node.Factory = sExt_Factory;
                }

                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);
                in_node.AddString("RES_ID", sResID);
                in_node.AddString("SUBRES_ID", sSubResID);
                in_node.AddString("CHAR_ID", sCharID);
                in_node.AddChar("LOT_RES_FLAG", sLotResFlag);
                in_node.AddChar("INCLUDE_DELETE_CHART", sIncludeDeleteChart);
                in_node.AddString("FILTER", sFilter);

                in_node.AddString("GRAPH_TYPE", sGraphType);
                in_node.AddChar("UNIT_USE_FLAG", sUnitUseFlag);
                in_node.AddChar("VALUE_TYPE", sValueTypeFlag);
                in_node.AddString("CHT_GRP_1", sGroup);
                in_node.AddString("TABLE_NAME1", sGroupTable);
                in_node.AddString("CHART_SET_ID", sChartSetID);
                in_node.AddString("NEXT_CHART_ID", "");

                
                do
                {
                    out_node = new TRSNode("View_Chart_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_Chart_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_CHART_ID") != "");

                   
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            iCount = ((ListView)control).Items.Count + 1;
                            itmX = new ListViewItem(iCount.ToString(), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")));
                            //itmX.SubItems.Add(modCommonFunction.GetGraphType(@Enum.Parse(typeof(eGraphType), out_node.GetList(0)[i].GetString("graph_type.ToString()), false")));
                            itmX.SubItems.Add(MPCF.GetGraphType((eGraphType)Enum.Parse(typeof(eGraphType), out_node.GetList(0)[i].GetString("GRAPH_TYPE")), false));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_RES_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("SYNC_EDC_FLAG")));

                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("UNIT_USE_FLAG")));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("UNIT_COUNT").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("SAMPLE_SIZE").ToString());
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CONSTANT_1"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CONSTANT_2"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CONSTANT_3"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CONSTANT_4"));
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("PRECISION_LIMIT").ToString());

                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("SPEC_CHECK_TYPE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("SPEC_OUT_COUNT")));

                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_4")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_5")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_6")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_7")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_8")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_9")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_GRP_10")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_4")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_5")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_6")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_7")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_8")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_9")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHT_CMF_10")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHARGE_ENGR")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_COMMENT")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));
                            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME")));


                            ((ListView)control).Items.Add(itmX);
                            if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                            {
                                itmX.ForeColor = Color.Magenta;
                            }

                        }
                        else if (control is TreeView)
                        {
                            nodeX = new TreeNode(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")) + " : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_DESC")), (int)SMALLICON_INDEX.IDX_CHART_LINE, (int)SMALLICON_INDEX.IDX_CHART_LINE);
                            if (!(parentNode == null))
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            else
                            {
                                ((TreeView)control).Nodes.Add(nodeX);
                            }
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                        }
                        else if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));

                        }
                    }
                }
                
                
                if (control is FarPoint.Win.Spread.FpSpread)
                {
                    strData = new string[sList.Count + 1];
                    for (i = 0; i < sList.Count; i++)
                    {
                        strData[i] = sList[i];
                    }
                    strData[i] = "";

                    cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cboCellType.Items = strData;
                    if (Row == - 1 && Col == - 1)
                    {
                        //Do Nothing
                    }
                    else if (Row == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Columns.Get(Col).CellType = cboCellType;
                    }
                    else if (Col == - 1)
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Rows.Get(Row).CellType = cboCellType;
                    }
                    else
                    {
                        ((FarPoint.Win.Spread.FpSpread) control).ActiveSheet.Cells.Get(Row, Col).CellType = cboCellType;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewChartList()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewSPCEDCData()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewSPCEDCDatabyChartSet(FarPoint.Win.Spread.FpSpread spdData, char c_step, string sChartSetID, string sFromTime, string sToTime, int iAverageCol, int iValueCol, bool bShowTotal, char sShowExcludeData)
        {

            TRSNode in_node = new TRSNode("View_EDC_Data_In");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
             FarPoint.Win.Spread.SheetView sheet;
            int i;
            int j;
            int k;
            int result;
            int iRow;
            int iCol;
            int iLastCol;
            int iNominalCol = 0;
            //double dAverage;
            //double dSigma;
            //double dRange;
            //double dMin;
            //double dMax;
            double dValue = 0.0;
            //double dWeightValue;
            int iValueCount = 0;
            int iPrecision = 0;
            bool bZbarFlag = false;
            bool bDeltaFlag = false;
            int iOldHistSeq = 0;
            int iMaxCol = 0;

            try
            {                
                FarPoint.Win.BevelBorder BevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                //dValue = 0;
                //dAverage = 0;
                //dSigma = 0;
                //dRange = 0;
                //dMin = double.MaxValue;
                //dMax = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_SET_ID", sChartSetID);
                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddChar("INCLUDE_FLAG", sShowExcludeData);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddInt("NEXT_UNIT_SEQ", int.MaxValue);
                in_node.AddInt("NEXT_VALUE_SEQ", 0);
                                
                MPCF.ClearList(spdData, true);

                sheet = spdData.ActiveSheet;
                do
                {
                    out_node = new TRSNode("SPC_View_EDC_Data_ChartSet_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_EDC_Data_ChartSet", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }
                    
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
                    in_node.SetInt("NEXT_VALUE_SEQ", out_node.GetInt("NEXT_VALUE_SEQ"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || 
                         in_node.GetInt("NEXT_HIST_SEQ") > 0 || 
                         in_node.GetInt("NEXT_UNIT_SEQ") > 0 || 
                         in_node.GetInt("NEXT_VALUE_SEQ") > 0);
                     
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        sheet.Cells[iRow, UNITUSE_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("UNIT_USE_FLAG"));

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHART_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_RES_FLAG");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_DESC");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBRES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("EVENT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));

                        iCol++;
                        iNominalCol = iCol;
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("NOMINAL")) != "")
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("NOMINAL")), iPrecision);
                        }

                        iCol++;
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROCESS_SIGMA")) != "")
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PROCESS_SIGMA")), iPrecision);
                        }

                        iCol++;

                        iValueCount = i + Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                        for (j = i; j <= iValueCount; j++)
                        {
                            for (k = 0; k <= out_node.GetList(0)[j].GetInt("VALUE_COUNT") - 1; k++)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                {
                                    sheet.Cells[iRow, iCol].Value = MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                }

                                iCol++;

                                if (MPCF.Trim(out_node.GetList(0)[j].GetChar("VALUE_TYPE")) == "N")
                                {
                                    if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                    {
                                        dValue += MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                    }
                                }
                            }
                        }
                        if (iMaxCol < iCol)
                        {
                            iMaxCol = iCol;
                        }
                        iPrecision = out_node.GetList(0)[i].GetInt("PRECISION_LIMIT");
                        iLastCol = iCol - 1;
                        iCol = iAverageCol - 1;

                        
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MAX_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MIN_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("USL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"));
                        iOldHistSeq = out_node.GetList(0)[i].GetInt("HIST_SEQ");


                        sheet.Cells[iRow, UNITUSE_COL - 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("UNIT_COUNT"));
                        sheet.Cells[iRow, UNITUSE_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("UNIT_USE_FLAG"));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("EXCLUDE_FLAG")) == "Y")
                        {
                            sheet.Cells[iRow, 0, iRow, sheet.ColumnCount - 1].ForeColor = Color.Magenta;
                        }

                        if (out_node.GetList(0)[i].GetString("GRAPH_TYPE") == eGraphType.ZBARS.ToString())
                        {
                            bZbarFlag = true;
                        }
                        if (out_node.GetList(0)[i].GetString("GRAPH_TYPE") == eGraphType.DELTAS.ToString())
                        {
                            bDeltaFlag = true;
                        }

                        i += Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                    }
                }
                    

                if (sheet.RowCount > 0)
                {
                    if (MPCF.Trim(out_node.GetList(0)[0].GetChar("LOT_RES_FLAG")) == "L")
                    {
                        sheet.Columns[LOTID_COL].Visible = true;
                        sheet.Columns[MATID_COL].Visible = true;
                        sheet.Columns[MATID_COL].Visible = true;
                        sheet.Columns[MATDESC_COL].Visible = true;
                        sheet.Columns[MATVER_COL].Visible = true;
                        sheet.Columns[FLOW_COL].Visible = true;
                        sheet.Columns[OPER_COL].Visible = true;
                        sheet.Columns[PROCOPER_COL].Visible = true;
                        sheet.Columns[PROCRES_COL].Visible = true;
                        sheet.Columns[EVENT_COL].Visible = false;
                    }
                    else if (MPCF.Trim(out_node.GetList(0)[0].GetChar("LOT_RES_FLAG")) == "R")
                    {
                        sheet.Columns[LOTID_COL].Visible = false;
                        sheet.Columns[MATID_COL].Visible = false;
                        sheet.Columns[MATDESC_COL].Visible = false;
                        sheet.Columns[MATVER_COL].Visible = false;
                        sheet.Columns[FLOW_COL].Visible = false;
                        sheet.Columns[OPER_COL].Visible = false;
                        sheet.Columns[PROCOPER_COL].Visible = false;
                        sheet.Columns[PROCRES_COL].Visible = false;
                        sheet.Columns[EVENT_COL].Visible = true;
                    }

                    for (i = VALUE_START_COL; i < iMaxCol; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = true;
                        spdData.ActiveSheet.ColumnHeader.Cells[1, i].Value = (i - VALUE_START_COL) + 1;
                    }
                    for (i = iMaxCol; i <= VALUE_END_COL; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = false;
                    }

                    iMaxCol = iMaxCol - VALUE_START_COL;
                    if (iMaxCol == 1)
                    {
                        spdData.ActiveSheet.ColumnHeader.Cells[0, iValueCol].Value = MPCF.FindLanguage("Value", 0);
                    }
                    else
                    {
                        spdData.ActiveSheet.ColumnHeader.Cells[0, iValueCol].Value = MPCF.FindLanguage("Value", 0) + "(1 ~ " + iMaxCol  + ")";
                    }
                    
                    spdData.ActiveSheet.ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                    
                    if (bZbarFlag == true)
                    {
                        spdData.ActiveSheet.Columns[iValueCol - 1].Visible = true;
                        spdData.ActiveSheet.Columns[iValueCol - 2].Visible = true;
                        spdData.ActiveSheet.Columns[iAverageCol - 1].Visible = true;
                    }
                    else if (bZbarFlag == false && bDeltaFlag == true)
                    {
                        spdData.ActiveSheet.Columns[iValueCol - 1].Visible = false;
                        spdData.ActiveSheet.Columns[iValueCol - 2].Visible = true;
                        spdData.ActiveSheet.Columns[iAverageCol - 1].Visible = true;
                    }
                    else
                    {
                        spdData.ActiveSheet.Columns[iValueCol - 1].Visible = false;
                        spdData.ActiveSheet.Columns[iValueCol - 2].Visible = false;
                        spdData.ActiveSheet.Columns[iAverageCol - 1].Visible = false;
                    }

                    i = 0;
                    while (i < spdData.ActiveSheet.RowCount)
                    {
                        if (MPCF.ToChar( sheet.Cells[i, UNITUSE_COL].Value) != 'Y')
                        {
                            for (j = iAverageCol - 1; j < iAverageCol + 16; j++)
                            {
                                spdData.ActiveSheet.Cells[i, j].RowSpan = MPCF.ToInt( sheet.Cells[i, UNITUSE_COL - 1].Value);
                            }
                            spdData.ActiveSheet.Cells[i, iNominalCol].RowSpan = MPCF.ToInt( sheet.Cells[i, UNITUSE_COL - 1].Value);
                            spdData.ActiveSheet.Cells[i, iNominalCol + 1].RowSpan = MPCF.ToInt( sheet.Cells[i, UNITUSE_COL - 1].Value);
                            i += MPCF.ToInt( sheet.Cells[i, UNITUSE_COL - 1].Value);
                        }
                        else
                        {
                            if (MPCF.ToInt(sheet.Cells[i, UNITUSE_COL - 1].Value) <= 0)
                            {
                                i++;
                            }
                            else
                            {
                                i += MPCF.ToInt(sheet.Cells[i, UNITUSE_COL - 1].Value);
                            }
                        }
                    }
                
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewEDCData()\n" + ex.Message);
                return false;
            }
            
        }
    }
    //#End If
}
