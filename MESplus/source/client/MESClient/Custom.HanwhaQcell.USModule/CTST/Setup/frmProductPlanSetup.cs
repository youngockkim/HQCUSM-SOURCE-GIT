/*---------------------------------------------------------------------------------------------------*/
//
//  Program Id      : frmProductPlanSetup.cs
//  Creator         : JGCHOI.
//  Create Date     : 2019.10.16
//  Description     : 생산계획 입력
//  History         : 2019.10.16 - Create
//
/*---------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmProductPlanSetup : TranForm02
    {
        public frmProductPlanSetup()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private enum SPD_COL : int
        {
            COL_CHK = 0,
            DATE,
            PLANT,
            LINE,
            PRODUCT,
            PRODUCT_DESC,
            EXP_WATT_PER_PC,
            PLN_OUTPUT,
            PLN_YIELD,
            PLN_OUTPUT_GOOD_WATT,
            PLN_FEL_DEFECT_RATE,
            PLN_CELL_LOSS_IN_MODULE,
            PLN_CELL_LOSS_IN_CELL,
            CREATE_TIME,
            CREATE_USER_ID,
            UPDATE_TIME,
            UPDATE_USER_ID
        }

        private const string SPREAD_BTN_STATUS_CODE = "STATUS_CODE";
        private bool bExcelOpen = false;
        private SortedList<int, int> colList = null;
        #endregion

        #region " Variable Definition "
        
        bool bCheck = false;
        #endregion 

        #region " Function Definition "
        /// <summary>
        /// initialze Condition
        /// </summary>
        /// <returns></returns>
       
        /// <summary>
        /// 콘트롤 초기화 함수
        /// </summary>
        /// <param name="s_case"></param>
        /// <returns></returns>
        private bool ClearField(string s_case)
        {
            try
            {
                switch (s_case)
                {
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : ClearField\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 벨리데이션
        /// </summary>
        /// <param name="s_case"></param>
        /// <returns></returns>
        private bool CheckValue()
        {
            try
            {
                int iCnt = 0;
                for (int i = 0; i < spdPlan.ActiveSheet.RowCount; i++)
                {
                    if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value != null &&
                         Convert.ToBoolean(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value) == true)
                    {
                        if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.DATE].Text.Trim() == string.Empty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                            spdPlan.ActiveSheet.SetActiveCell(i, (int)SPD_COL.DATE);
                            spdPlan.EditModePermanent = true;
                            return false;
                        }

                        if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.LINE].Text.Trim() == string.Empty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                            spdPlan.ActiveSheet.SetActiveCell(i, (int)SPD_COL.LINE);
                            spdPlan.EditModePermanent = true;
                            return false;
                        }

                        if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLANT].Text.Trim() == string.Empty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                            spdPlan.ActiveSheet.SetActiveCell(i, (int)SPD_COL.PLANT);
                            spdPlan.EditModePermanent = true;
                            return false;
                        }

                        if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT].Text.Trim() == string.Empty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                            spdPlan.ActiveSheet.SetActiveCell(i, (int)SPD_COL.PRODUCT);
                            spdPlan.EditModePermanent = true;
                            return false;
                        }
                        iCnt++;
                    }
                    
                }

                if (iCnt == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(370));//The selected data does not exist
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : CheckValue()\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레드 초기화
        /// </summary>
        /// <returns></returns>

        private void InitSpread()
        {
            try
            {

                #region spdPlan
                FarPoint.Win.Spread.CellType.PercentCellType percentCellType = new FarPoint.Win.Spread.CellType.PercentCellType();                

                spdPlan.ActiveSheet.ColumnHeader.RowCount = 1;

                HQCF.SpreadAddColumn(spdPlan, "CHK", 40, HQCF.SpreadCellType.CheckBoxCellType, true, false, false, FarPoint.Win.Spread.CellHorizontalAlignment.Left);

                HQCF.SpreadAddColumn(spdPlan, "DATE", 80, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "PLANT", 50, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "LINE", 50, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "PRODUCT", 130, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "PRODUCT_DESC", 200, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "EXP_WATT_PER_PC", 110, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.EXP_WATT_PER_PC].CellType = doublecelltype;

                HQCF.SpreadAddColumn(spdPlan, "OUTPUT", 90, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numberCellType.DecimalPlaces = 0;
                numberCellType.Separator = ",";
                numberCellType.MaximumValue = 999999999999;
                numberCellType.ShowSeparator = true;
                numberCellType.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_OUTPUT].CellType = numberCellType;

                HQCF.SpreadAddColumn(spdPlan, "YIELD", 90, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                percentCellType.MinimumValue = 0;
                percentCellType.MaximumValue = 100;
                //percentCellType.DecimalPlaces = 1;
                //percentCellType.MaximumValue = 99.9;
                percentCellType.FixedPoint = true;
                //percentCellType.ShowSeparator = true;
                //percentCellType.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_YIELD].CellType = percentCellType;

                // 2019.11.06 
                // ISSUE-09-050
                // 공손/원손 Cell 처리 소숫점 0.0270/ 0.0040 4자리고정 처리
                // OUTPUT_GOOD_WATT 도 4자리 고정 처리
                FarPoint.Win.Spread.CellType.NumberCellType double4digitCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                double4digitCellType.DecimalPlaces = 4;
                double4digitCellType.Separator = ",";
                double4digitCellType.MaximumValue = 999999999999.9999;
                double4digitCellType.ShowSeparator = true;

                HQCF.SpreadAddColumn(spdPlan, "OUTPUT_GOOD_WATT", 120, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_OUTPUT_GOOD_WATT].CellType = double4digitCellType;

                HQCF.SpreadAddColumn(spdPlan, "FRONT_END_DEFECT_RATE", 140, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_FEL_DEFECT_RATE].CellType = percentCellType;

                HQCF.SpreadAddColumn(spdPlan, "CELL_LOSS_IN_MODULE", 140, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_CELL_LOSS_IN_MODULE].CellType = double4digitCellType;
                HQCF.SpreadAddColumn(spdPlan, "CELL_LOSS_IN_CELL", 120, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdPlan.ActiveSheet.Columns[(int)SPD_COL.PLN_CELL_LOSS_IN_CELL].CellType = double4digitCellType;

                HQCF.SpreadAddColumn(spdPlan, "CREATE_TIME", 140, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "CREATE_USER_ID", 90, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "UPDATE_TIME", 140, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdPlan, "UPDATE_USER_ID", 90, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);

                //MPCF.FitColumnHeader(spdPlan);
                for (int i = 0; i < spdPlan.ActiveSheet.Columns.Count; i++)
                {
                    spdPlan.ActiveSheet.ColumnHeader.Columns[i].BackColor = Color.PaleTurquoise;
                    if (i > (int)SPD_COL.PRODUCT && i < (int)SPD_COL.CREATE_TIME)
                    {
                        spdPlan.ActiveSheet.Columns[i].BackColor = Color.LightYellow;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);                
            }
            
        }

        /// <summary>
        /// 출하계획 목록 조회
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <returns></returns>5
        private bool ViewProductPlan()
        {
            try
            {
                List<string> lstInfo = new List<string>();
                string sCond = "AND WORK LIKE '" + dtpOptWorkDate.Value.ToString("yyyyMM") + "%'";
                lstInfo.Add(sCond);

                DataTable _dt = HQCF.MGetData("VIEW_PROD_PLAN_LIST", new string[] {cdvLineID.Text.Trim(), cdvMatID.Text.Trim() }, lstInfo);

                spdPlan.ActiveSheet.RowCount = 0;
                if (_dt == null || _dt.Rows.Count < 1)
                {
                    //데이터가 존재하지 않습니다.
                    MPCF.ShowMsgBox(MPCF.GetMessage(368));
                    return false;
                }

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    spdPlan.ActiveSheet.RowCount += 1;

                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value = false;

                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.DATE].Text = _dt.Rows[i]["WORK"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLANT].Text = _dt.Rows[i]["PLANT"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.LINE].Text = _dt.Rows[i]["LINE"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT].Text = _dt.Rows[i]["PRODUCT"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT_DESC].Text = _dt.Rows[i]["PRODUCT_DESC"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.EXP_WATT_PER_PC].Text = _dt.Rows[i]["EXP_WATT_PER_PC"].ToString();

                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_OUTPUT].Text = _dt.Rows[i]["PLN_OUTPUT"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_YIELD].Value = double.Parse(_dt.Rows[i]["PLN_YIELD"].ToString())/100;
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_OUTPUT_GOOD_WATT].Text = _dt.Rows[i]["PLN_OUTPUT_GOOD_WATT"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_FEL_DEFECT_RATE].Value = double.Parse(_dt.Rows[i]["PLN_FEL_DEFECT_RATE"].ToString())/100;
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_CELL_LOSS_IN_MODULE].Value = double.Parse(_dt.Rows[i]["PLN_CELL_LOSS_IN_MODULE"].ToString());
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_CELL_LOSS_IN_CELL].Value = double.Parse(_dt.Rows[i]["PLN_CELL_LOSS_IN_CELL"].ToString());

                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.CREATE_TIME].Text = MPCF.MakeDateFormat(_dt.Rows[i]["CREATE_TIME"].ToString(), DATE_TIME_FORMAT.DATETIME);
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.CREATE_USER_ID].Text = _dt.Rows[i]["CREATE_USER_ID"].ToString();
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.UPDATE_TIME].Text = MPCF.MakeDateFormat(_dt.Rows[i]["UPDATE_TIME"].ToString(), DATE_TIME_FORMAT.DATETIME);
                    spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.UPDATE_USER_ID].Text = _dt.Rows[i]["UPDATE_USER_ID"].ToString();
                }
                
                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipInfoByPeriod()
        {
            try
            {

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateProductPlan(char cProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");
            TRSNode plan_list;
            DataTable _dt;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep; 

                _dt = (DataTable)spdPlan.DataSource;

                for (int i = 0; i < spdPlan.ActiveSheet.RowCount; i++ )
                {
                    if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value != null &&
                         Convert.ToBoolean(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value) == true)
                    {
                        plan_list = in_node.AddNode("PLAN_LIST");

                        plan_list.AddString("WORK", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.DATE].Text).Replace("-", ""));
                        plan_list.AddString("PLANT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLANT].Text));
                        plan_list.AddString("LINE", spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.LINE].Text);
                        plan_list.AddString("PRODUCT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT].Text));
                        plan_list.AddString("PRODUCT_DESC", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT_DESC].Text));
                        plan_list.AddDouble("EXP_WATT_PER_PC", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.EXP_WATT_PER_PC].Value));

                        plan_list.AddDouble("PLN_OUTPUT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_OUTPUT].Value));
                        plan_list.AddDouble("PLN_YIELD", double.Parse(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_YIELD].Value.ToString()) *100);
                        plan_list.AddDouble("PLN_OUTPUT_GOOD_WATT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_OUTPUT_GOOD_WATT].Value));
                        plan_list.AddDouble("PLN_FEL_DEFECT_RATE", double.Parse(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_FEL_DEFECT_RATE].Value.ToString())*100);
                        plan_list.AddDouble("PLN_CELL_LOSS_IN_MODULE", double.Parse(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_CELL_LOSS_IN_MODULE].Value.ToString()));
                        plan_list.AddDouble("PLN_CELL_LOSS_IN_CELL", double.Parse(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLN_CELL_LOSS_IN_CELL].Value.ToString()));
                    }
                    
                }

                if (MPCR.CallService("CWIP", "CWIP_Update_Product_Plan", in_node, ref out_node) == false)
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

        private bool DeleteProductPlan()
        {
            TRSNode in_node = new TRSNode("DELETE_IN");
            TRSNode out_node = new TRSNode("DELETE_OUT");
            TRSNode plan_list;
            DataTable _dt;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = Convert.ToChar(MPGC.MP_STEP_DELETE);

                _dt = (DataTable)spdPlan.DataSource;

                for (int i = 0; i < spdPlan.ActiveSheet.RowCount; i++)
                {
                    if (spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value != null &&
                         Convert.ToBoolean(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value) == true)
                    {
                        plan_list = in_node.AddNode("PLAN_LIST");

                        plan_list.AddString("WORK", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.DATE].Text).Replace("-", ""));
                        plan_list.AddString("PLANT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PLANT].Text));
                        plan_list.AddString("LINE", spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.LINE].Text);
                        plan_list.AddString("PRODUCT", MPCF.Trim(spdPlan.ActiveSheet.Cells[i, (int)SPD_COL.PRODUCT].Text));
                    }

                }

                if (MPCR.CallService("CWIP", "CWIP_Update_Product_Plan", in_node, ref out_node) == false)
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

        /// <summary>
        /// 작업지시 마감
        /// </summary>
        /// <returns></returns>
        private bool CloseOrder()
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");
            TRSNode plan_list;
            DataTable _dt;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                _dt = (DataTable)spdPlan.DataSource;

                DataRow[] _dr = _dt.Select("1=1 AND CHK = 'True'");

                foreach (DataRow _drData in _dr)
                {
                    plan_list = in_node.AddNode("plan_list");

                    //plan_list.AddString("LINE_CODE", MPCF.Trim(_drData[(int)SPD_COL.SHP_PLAN_NO]));
                    //plan_list.AddString("MAT_ID", MPCF.Trim(_drData[(int)SPD_COL.COL_MAT_ID]));
                    //plan_list.AddString("PLAN_DATE", _drData[(int)SPD_COL.COL_PLAN_DATE].ToString().Replace("-", ""));
                    //plan_list.AddString("ORDER_ID", MPCF.Trim(_drData[(int)SPD_COL.COL_ORDER_ID]));
                    //plan_list.AddDouble("PLAN_QTY", MPCF.Trim(_drData[(int)SPD_COL.COL_PLAN_QTY]));
                    //plan_list.AddInt("PRIORITY", MPCF.Trim(_drData[(int)SPD_COL.COL_PRIORITY]));
                    //plan_list.AddChar("STATUS", 'C');
                    //plan_list.AddChar("ORDER_TYPE", MPCF.Trim(_drData[(int)SPD_COL.COL_ORDER_TYPE]));
                    //plan_list.AddDouble("PACK_QTY", MPCF.Trim(_drData[(int)SPD_COL.COL_PACK_QTY]));
                }

                if (MPCR.CallService("CUS_WIP", "CUS_WIP_Update_Order", in_node, ref out_node) == false)
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

        /// <summary>
        /// 선발행
        /// </summary>
        /// <returns></returns>
        private bool CreateLabel()
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");            
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.SetString("ORDER_ID", spdPlan.ActiveSheet.Cells[spdPlan.ActiveSheet.ActiveRowIndex, (int)SPD_COL.COL_ORDER_ID].Value.ToString());

                if (MPCR.CallService("CUS_INV", "CUS_INV_Create_Label", in_node, ref out_node) == false)
                {
                    return false;
                }                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 스프레드 버튼 이벤트 
        /// </summary>
        /// <param name="s_case"></param>
        /// <param name="i_row"></param>
        /// <param name="i_column"></param>
        /// <returns></returns>
        
        /// <summary>
        /// Control Event Handler
        /// </summary>
        private void EventHandler()
        {
            #region Main Button Event Handler
               
            #endregion

            #region [ Control Event ]            
           
            cdvMatID.ButtonPress += new System.EventHandler(cdvMatID_ButtonPress);
            cdvLineID.ButtonPress += new System.EventHandler(cdvLineID_ButtonPress);
            
            #endregion

            #region [ Spread Event ]
            //this.spdPlan.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(spdData_CellClick);
            //this.spdPlan.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(spdData_ButtonClicked);
            //this.spdPlan.EditModeOff += new System.EventHandler(spdData_EditModeOff);
            //this.spdPlan_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(spdData_Sheet1_CellChanged);
            #endregion

        }

        private void setSheetColumn(FarPoint.Win.Spread.FpSpread spread, int iStartColIdx)
        {
            string colText = string.Empty;
            int iHeaderRow = 4;

            try
            {
                colList = new SortedList<int, int>();

                for (int c = iStartColIdx; c < spdXlsData.ActiveSheet.ColumnCount; c++)
                {
                    colText = MPCF.Trim(spdXlsData.ActiveSheet.Cells[iHeaderRow, c].Text);

                    if (colText == string.Empty)
                    {
                        break;
                    }

                    colList.Add(c, c);
                    //idx = GetSpreadCol(spread, colText, 0);

                    //if (idx > -1)
                    //{
                    //    colList.Add(idx, c);
                    //}
                    //else
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(366));//Column name does not exist.
                    //    return;
                    //}
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool setSheetValue(FarPoint.Win.Spread.FpSpread spread,int iStartColIdx)
        {
            try
            {
                int iKeyColIdx = (int)SPD_COL.DATE;
                //int iGoodFlagIdx = (int)TOT_COL_LIST.GOOD_FLAG;
                //int iDownFlagIdx = (int)TOT_COL_LIST.DOWN_FLAG;
                //int iNoRetestFlagIdx = (int)TOT_COL_LIST.NO_RETEST;

                //if (spread == spdHBinList)
                //{
                //    iKeyColIdx = (int)TOT_COL_LIST.HBIN_NO_H;
                //    iGoodFlagIdx = (int)TOT_COL_LIST.GOOD_FLAG_H;
                //    iDownFlagIdx = (int)TOT_COL_LIST.DOWN_FLAG_H;
                //}
                spread.ActiveSheet.RowCount = 0;
                for (int i = 5; i < spdXlsData.ActiveSheet.RowCount; i++)
                {
                    // 데이터 존재 여부
                    if (MPCF.Trim(spdXlsData.ActiveSheet.Cells[i, iStartColIdx].Text) == string.Empty)
                    {
                        return true;
                    }

                    spread.ActiveSheet.RowCount++;
                    int iCol = 1;
                    foreach (int idx in colList.Keys)
                    {
                        if (iCol == 1) spread.ActiveSheet.Cells[spread.ActiveSheet.RowCount - 1, 0].Value = true;
                        spread.ActiveSheet.Cells[spread.ActiveSheet.RowCount - 1, iCol++].Value = spdXlsData.ActiveSheet.Cells[i, idx].Value;
                        
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        #endregion

        #region " Event Definition "

        private void frmProductPlanSetup_Load(object sender, EventArgs e)
        {
            try
            {
                EventHandler();
                InitSpread();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            InitSpread();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable _dtData = (DataTable)spdPlan.DataSource;
            DataRow _dr = _dtData.NewRow();

           // _dr[(int)SPD_COL.COL_CHK] = "True";
           //// _dr[(int)SPD_COL.SHP_PLAN_NO] = cdvLineCode.Text;
           // _dr[(int)SPD_COL.SHP_PLAN_NO_BTN] = "";
           //// _dr[(int)SPD_COL.SHP_PLAN_NO_DESC] = cdvLineCode.DescText;
           // _dr[(int)SPD_COL.COL_MAT_ID] = "";
           // _dr[(int)SPD_COL.COL_MAT_ID_BTN] = "";
           // _dr[(int)SPD_COL.COL_MAT_DESC] = "";
           // _dr[(int)SPD_COL.COL_ORDER_TYPE] = "P";
           // _dr[(int)SPD_COL.COL_ORDER_TYPE_BTN] = "";
           // _dr[(int)SPD_COL.COL_ORDER_TYPE_DESC] = "정상";
           // _dr[(int)SPD_COL.COL_PLAN_DATE] = DateTime.Now.ToString("yyyy-MM-dd");
           // _dr[(int)SPD_COL.COL_ORDER_ID] = " ";
           // _dr[(int)SPD_COL.COL_PLAN_QTY] = 0;
           // _dr[(int)SPD_COL.COL_PROD_QTY] = 0;
           // _dr[(int)SPD_COL.COL_REMAIN_QTY] = 0;
           // _dr[(int)SPD_COL.COL_PACK_QTY] = 0;
           // _dr[(int)SPD_COL.COL_PRIORITY] = "5";
           // _dr[(int)SPD_COL.COL_STATUS] = "A";
           // _dr[(int)SPD_COL.COL_STATUS_DESC] = "확정";

            _dtData.Rows.Add(_dr);
            spdPlan.DataSource = _dtData;

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue() == true)
                {   
                    //체크된 행이 삭제됩니다. 삭제하시겠습니까?
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(367), Application.ProductName, MessageBoxButtons.YesNo, 1) != DialogResult.Yes) return;

                    if (DeleteProductPlan() == true)
                    {
                        btnView.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvMatID_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            string s_sql;

            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Material", 100, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.VisibleColumnHeader = true;
                cdvTemp.SelectedSubItemIndex = 0;
                cdvTemp.SelectedDescIndex = 1;

                s_sql = "SELECT MAT_ID, MAT_SHORT_DESC FROM MWIPMATDEF ";
                s_sql += " WHERE FACTORY='" + MPGV.gsFactory + "' AND MAT_TYPE = 'P'";
                s_sql += " ORDER BY MAT_ID ";

                BASLIST.ViewQueryList(cdvTemp.GetListView, '1', s_sql, (int)SMALLICON_INDEX.IDX_MATERIAL, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLineID_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            string s_sql;

            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Material", 100, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.VisibleColumnHeader = true;
                cdvTemp.SelectedSubItemIndex = 0;
                cdvTemp.SelectedDescIndex = 1;

                s_sql = "SELECT DATA_6 LINE_CODE, DATA_1 LINE_DESC FROM MGCMTBLDAT ";
                s_sql += " WHERE FACTORY='" + MPGV.gsFactory + "' AND TABLE_NAME = '@LINE_CODE' AND DATA_5 = 'MA' ";
                s_sql += " ORDER BY DATA_6 ";

                BASLIST.ViewQueryList(cdvTemp.GetListView, '1', s_sql, (int)SMALLICON_INDEX.IDX_MATERIAL, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }      
        
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void btnView_Click(object sender, EventArgs e)
        {
            if (ViewProductPlan() == false) return;
            bExcelOpen = false;
            btnUpdate.Enabled = true;
            btnDel.Enabled = true;
            
        }

        private void btnExcelOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string _FileTypeHead = string.Empty; string _FileTypeDesc = string.Empty;
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "File Upload";
                open.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                spdPlan.ActiveSheet.RowCount = 0;
                Cursor.Current = Cursors.WaitCursor;
                spdXlsData.OpenExcel(open.FileName);
                spdXlsData.Visible = false;
                Cursor.Current = Cursors.Default;

                setSheetColumn(spdPlan, 3);
                if (!setSheetValue(spdPlan, 3))
                {
                    btnExcelOpen.Focus();
                }

                bExcelOpen = true;
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
      
        private void spdPlan_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column > 0)
            {
                FarPoint.Win.Spread.SheetView spd = spdPlan.ActiveSheet;

                if (MPCF.Trim(spd.Cells[e.Row, (int)SPD_COL.COL_CHK].Value).ToUpper() == "FALSE" ||
                              spd.Cells[e.Row, (int)SPD_COL.COL_CHK].Value == null)
                {
                    spd.Cells[e.Row, (int)SPD_COL.COL_CHK].Value = true;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckValue() == true)
            {
                if (UpdateProductPlan(MPGC.MP_STEP_CREATE) == true)
                {
                    btnView.PerformClick();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpOptWorkDate));

            if (MPCF.ExportToExcel(spdPlan, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckValue() == true)
            {
                if (UpdateProductPlan(MPGC.MP_STEP_UPDATE) == true)
                {
                    btnView.PerformClick();
                }
            }
        }

        private void spdPlan_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader)
                {
                    if ((sender as FarPoint.Win.Spread.FpSpread).ActiveSheet.Columns[e.Column].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                    {
                        if (e.Column == 0)
                        {
                            if (bCheck == true)
                            {
                                for (int i = 0; i < spdPlan.ActiveSheet.Rows.Count; i++)
                                {
                                    spdPlan.ActiveSheet.Cells[i, 0].Value = "False";
                                }
                                bCheck = false;
                            }
                            else
                            {
                                for (int i = 0; i < spdPlan.ActiveSheet.Rows.Count; i++)
                                {
                                    spdPlan.ActiveSheet.Cells[i, 0].Value = "True";
                                }
                                bCheck = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdPlan_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int colidx;

                FarPoint.Win.Spread.SheetView spd = spdPlan.ActiveSheet;

                colidx = spd.ActiveColumnIndex;

                if (colidx > 1)
                {
                    if (MPCF.Trim(spdPlan.Sheets[0].Cells[spd.ActiveRowIndex, (int)SPD_COL.COL_CHK].Value).ToUpper() == "FALSE" ||
                          spdPlan.ActiveSheet.Cells[spd.ActiveRowIndex, (int)SPD_COL.COL_CHK].Value == null)
                    {
                        spd.Cells[spd.ActiveRowIndex, (int)SPD_COL.COL_CHK].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        #endregion 

        private void spdPlan_ClipboardPasted(object sender, FarPoint.Win.Spread.ClipboardPastedEventArgs e)
        {
            int iCurrRow = spdPlan.ActiveSheet.ActiveRowIndex;
            string sText = Clipboard.GetText();
            int iFindIdx = 0;
            int iFindLastIdx = sText.LastIndexOf("\r\n");
            int iEditRowCnt = 0;
            while (true)
            {
                if (iEditRowCnt == 0)
                {
                    iFindIdx = sText.IndexOf("\r\n", iFindIdx);
                }
                else
                {
                    iFindIdx = sText.IndexOf("\r\n", iFindIdx + "\r\n".Length);
                }
                iEditRowCnt++;

                if (iFindLastIdx == iFindIdx)
                {
                    break;
                }
            }


            for (int i = 0; i < iEditRowCnt; i++)
            {
                if (iCurrRow < spdPlan.ActiveSheet.Rows.Count)
                {
                    spdPlan.ActiveSheet.Cells[iCurrRow++, (int)SPD_COL.COL_CHK].Value = true;
                }
            }
        }

        
    }
}
