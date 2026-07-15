/*---------------------------------------------------------------------------------------------------*/
//
//  Program Id      : frmCTMSetup.cs
//  Creator         : JGCHOI.
//  Create Date     : 2019.10.20
//  Description     : CTM 셋업
//  History         : 2019.10.20 - Create
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
    public partial class frmCTMSetup : TranForm02
    {
        public frmCTMSetup()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private enum SPD_COL : int
        {
            COL_CHK = 0,
            LINE_ID,
            WORK_DATE,
            FROM_TIME,
            TO_TIME,
            OFF_SET,
            BASE_CTM,
            AREA_CELL,
            ORDER_ID,
            PROD_MAT_ID,
            HCELL_MAT_ID,
            CREATE_TIME,
            CREATE_USER_ID,
            UPDATE_TIME,
            UPDATE_USER_ID
        }

        private enum SPD_CTM : int
        {
            COL_CHK = 0,
            FROM_TIME,
            TO_TIME
        }

        private const string SPREAD_BTN_STATUS_CODE = "STATUS_CODE";
        
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
        private bool CheckValue(string sType, FarPoint.Win.Spread.FpSpread spread)
        {
            try
            {
                if(tabCTM.SelectedIndex == 1)
                {
                    if (cdvLine2.Text.Trim() == string.Empty)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                        cdvLine2.Focus();
                        return false;
                    }

                    if (cdvItem2.Text.Trim() == string.Empty)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                        cdvItem2.Focus();
                        return false;
                    }
                }

                if (sType == "CREATE" || sType == "UPDATE" || sType == "DELETE")
                {
                    int iCnt = 0;
                    for (int i = 0; i < spread.ActiveSheet.RowCount; i++)
                    {
                        if (spread.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value != null &&
                             Convert.ToBoolean(spread.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value) == true)
                        {
                            iCnt++;
                        }
                    }

                    if (iCnt == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(370));//The selected data does not exist
                        return false;
                    }
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
                percentCellType.MinimumValue = 0;
                percentCellType.MaximumValue = 100;

                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;
                
                spdCTMView.ActiveSheet.ColumnHeader.RowCount = 1;

                //COL_CHK = 0,
                //LINE_ID,
                //WORK_DATE,
                //WORK_TIME,
                //OFF_SET,
                //BASE_CTM,
                //AREA_CELL,
                //ORDER_ID,
                //PROD_MAT_ID,
                //HCELL_MAT_ID,
                //CREATE_TIME,
                //CREATE_USER_ID,
                //UPDATE_TIME,
                //UPDATE_USER_ID
                HQCF.SpreadAddColumn(spdCTMView, "CHK", 40, HQCF.SpreadCellType.CheckBoxCellType, true, false, false, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                
                HQCF.SpreadAddColumn(spdCTMView, "LINE_ID", 60, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "WORK_DATE", 80, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "FROM_TIME", 80, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "TO_TIME", 80, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);

                HQCF.SpreadAddColumn(spdCTMView, "OFF_SET", 80, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                HQCF.SpreadAddColumn(spdCTMView, "BASE_CTM", 110, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdCTMView.ActiveSheet.Columns[(int)SPD_COL.BASE_CTM].CellType = doublecelltype;
                HQCF.SpreadAddColumn(spdCTMView, "AREA_CELL", 110, HQCF.SpreadCellType.NumberCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                spdCTMView.ActiveSheet.Columns[(int)SPD_COL.AREA_CELL].CellType = doublecelltype;

                HQCF.SpreadAddColumn(spdCTMView, "ORDER_ID", 120, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "PROD_MAT_ID", 120, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "HCELL_MAT_ID", 120, HQCF.SpreadCellType.TextCellType, true, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                
                HQCF.SpreadAddColumn(spdCTMView, "CREATE_TIME", 140, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "CREATE_USER_ID", 90, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "UPDATE_TIME", 140, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SpreadAddColumn(spdCTMView, "UPDATE_USER_ID", 90, HQCF.SpreadCellType.TextCellType, true, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);

                //MPCF.FitColumnHeader(spdPlan);
                for (int i = 0; i < spdCTMView.ActiveSheet.Columns.Count; i++)
                {
                    spdCTMView.ActiveSheet.ColumnHeader.Columns[i].BackColor = Color.PaleTurquoise;
                    if(i < (int)SPD_COL.CREATE_TIME)
                    {
                        spdCTMView.ActiveSheet.Columns[i].BackColor = Color.LightYellow;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);                
            }
            
        }

        private void InitCreateSpread()
        {
            try
            {

                #region spdPlan

                FarPoint.Win.Spread.CellType.PercentCellType percentCellType = new FarPoint.Win.Spread.CellType.PercentCellType();
                percentCellType.MinimumValue = 0;
                percentCellType.MaximumValue = 100;
                percentCellType.FixedPoint = true;

                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;

                spdCTM.ActiveSheet.Columns.Count = 0;
                spdCTM.ActiveSheet.ColumnHeader.RowCount = 1;

                HQCF.SpreadAddColumn(spdCTM, "CHK", 40, HQCF.SpreadCellType.CheckBoxCellType, true, false, false, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                spdCTM.ActiveSheet.ColumnHeader.Columns["CHK"].BackColor = Color.PaleTurquoise;
                HQCF.SpreadAddColumn(spdCTM, "FROM_TIME", 70, HQCF.SpreadCellType.TextCellType, true, true, false, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                spdCTM.ActiveSheet.ColumnHeader.Columns["FROM_TIME"].BackColor = Color.PaleTurquoise;
                spdCTM.ActiveSheet.Columns["FROM_TIME"].BackColor = Color.Lavender;

                HQCF.SpreadAddColumn(spdCTM, "TO_TIME", 60, HQCF.SpreadCellType.TextCellType, true, true, false, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                spdCTM.ActiveSheet.ColumnHeader.Columns["TO_TIME"].BackColor = Color.PaleTurquoise;
                spdCTM.ActiveSheet.Columns["TO_TIME"].BackColor = Color.Lavender;

                DataTable dt = GetDateList("SHORT");
                if (dt == null) return;

                //Dynamic Column 생성
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HQCF.SpreadAddColumn(spdCTM, dt.Rows[i][0].ToString(), 80, HQCF.SpreadCellType.TextCellType, true, false, false, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                    int iColCnt = spdCTM.ActiveSheet.Columns.Count;
                    spdCTM.ActiveSheet.ColumnHeader.Columns[iColCnt - 1].BackColor = Color.PaleTurquoise;
                    spdCTM.ActiveSheet.Columns[iColCnt - 1].BackColor = Color.LightYellow;
                    string sItemName = cdvItem2.Text.Trim();

                    if (sItemName == "OFF_SET" || sItemName == "BASE_CTM" || sItemName == "AREA_CELL")
                    {
                        spdCTM.ActiveSheet.Columns[iColCnt - 1].CellType = doublecelltype;
                        spdCTM.ActiveSheet.Columns[iColCnt - 1].Width = 50;
                    }
                }

                //시간설정(00~24시)
                spdCTM.ActiveSheet.RowCount = 24;
                int iToTime = 0;
                for (int i = 0; i < 24; i++)
                {
                    spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.FROM_TIME].Text = i + ":00";
                    iToTime = i + 1;
                    if (i == 23) iToTime = 0;
                    spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.TO_TIME].Text = iToTime + ":00";
                }

                #endregion

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetCellType()
        {
            try
            {

                #region spdCtm

                //FarPoint.Win.Spread.CellType.PercentCellType percentCellType = new FarPoint.Win.Spread.CellType.PercentCellType();
                //percentCellType.MinimumValue = 0;
                //percentCellType.MaximumValue = 100;
                //percentCellType.FixedPoint = true;

                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;

                FarPoint.Win.Spread.CellType.TextCellType textcelltype = new FarPoint.Win.Spread.CellType.TextCellType();
                
                //Dynamic Column CellType 재설정
                int iStartCol = (int)SPD_CTM.TO_TIME + 1;
                for (int i = iStartCol; i < spdCTM.ActiveSheet.Columns.Count; i++)
                {
                    string sItemName = cdvItem2.Text.Trim();

                    if (sItemName == "OFF_SET" || sItemName == "BASE_CTM" || sItemName == "AREA_CELL")
                    {
                        spdCTM.ActiveSheet.Columns[i].CellType = doublecelltype;
                        spdCTM.ActiveSheet.Columns[i].Width = 50; 
                    }
                    else
                    {
                        spdCTM.ActiveSheet.Columns[i].CellType = textcelltype;
                        spdCTM.ActiveSheet.Columns[i].Width = 80; 
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
        private bool ViewCTMList(string sTabType)
        {
            try
            {
                if (sTabType == "CREATE_TAB")
                {
                    if (CheckValue("VIEW", spdCTM) == false) return false;

                    List<string> lstInfo = new List<string>();

                    DataTable dt = GetDateList("LONG");
                    if (dt == null) return false;

                    DataTable _dt = GetDateList("SHORT");
                    if (_dt == null) return false;

                    //Dynamic Select 절
                    // "'20191001'" AS "10/01",  "'20191002'" AS "10/02",  ....
                    string sSelectCol = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sSelectCol += "\"'" + dt.Rows[i][0].ToString() + "'\" AS \"" +  _dt.Rows[i][0].ToString() + "\",";
                    }
                    sSelectCol = sSelectCol.Substring(0, sSelectCol.Length - 1);
                    lstInfo.Add(sSelectCol);
                    lstInfo.Add(cdvItem2.Text);

                    string sCond1 = " AND WORK_DATE LIKE '" + dtpMonth.Value.ToString("yyyyMM") + "%'";
                    lstInfo.Add(sCond1);
                    
                    string sCond2 = " MIN(" + cdvItem2.Text.Trim() + ") FOR WORK_DATE IN ( ";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sCond2 += "'" + dt.Rows[i][0].ToString() + "',";
                    }
                    sCond2 = sCond2.Substring(0, sCond2.Length - 1) + ")";
                    lstInfo.Add(sCond2);

                    _dt = HQCF.MGetData("VIEW_CTM_LIST_MONTH", new string[] { cdvLine2.Text.Trim()}, lstInfo);

                    //InitCreateSpread();
                    spdCTM.ActiveSheet.RowCount = 0;
                    if (_dt == null || _dt.Rows.Count < 1)
                    {
                        //데이터가 존재하지 않습니다.
                        MPCF.ShowMsgBox(MPCF.GetMessage(368));
                        return false;
                    }

                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        spdCTM.ActiveSheet.RowCount += 1;
                        spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value = false;

                        for(int c = 0 ; c < _dt.Columns.Count; c++)
                        {
                            spdCTM.ActiveSheet.Cells[i, c + 1].Text = _dt.Rows[i][c].ToString();
                        }
                    }
                }
                else
                {
                    DataTable _dt = HQCF.MGetData("VIEW_CTM_LIST", new string[] { cdvLineID.Text.Trim(), 
                                                                                  dtpWorkDate.FromDate.ToString().Replace("-",""),
                                                                                  dtpWorkDate.ToDate.ToString().Replace("-","")});

                    //InitCreateSpread();
                    spdCTMView.ActiveSheet.RowCount = 0;
                    if (_dt == null || _dt.Rows.Count < 1)
                    {
                        //데이터가 존재하지 않습니다.
                        MPCF.ShowMsgBox(MPCF.GetMessage(368));
                        return false;
                    }

                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        spdCTMView.ActiveSheet.RowCount += 1;
                        spdCTMView.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value = false;

                        for (int c = 0; c < _dt.Columns.Count; c++)
                        {
                            spdCTMView.ActiveSheet.Cells[i, c + 1].Text = _dt.Rows[i][c].ToString();
                        }
                    }
                }
                
                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateCTM(char cProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");
            TRSNode plan_list;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                if (tabCTM.SelectedIndex == 0) //VIEW TAB
                {
                    for (int i = 0; i < spdCTMView.ActiveSheet.RowCount; i++)
                    {
                        if (spdCTMView.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value != null &&
                             Convert.ToBoolean(spdCTMView.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value) == true)
                        {
                            plan_list = in_node.AddNode("CTM_LIST");

                            plan_list.AddString("WORK_DATE", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.WORK_DATE].Text).Replace("-", ""));
                            plan_list.AddString("LINE_ID", spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.LINE_ID].Text);
                            plan_list.AddString("FROM_TIME", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.FROM_TIME].Text.Replace(":","")));
                            plan_list.AddString("TO_TIME", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.TO_TIME].Text.Replace(":","")));

                            string sValue = spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.OFF_SET].Text.Trim();
                            sValue = sValue == "" ? "0" : sValue;
                            plan_list.AddDouble("OFF_SET", double.Parse(sValue));

                            sValue = spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.AREA_CELL].Text.Trim();
                            sValue = sValue == "" ? "0" : sValue;
                            plan_list.AddDouble("AREA_CELL", double.Parse(sValue));

                            sValue = spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.BASE_CTM].Text.Trim();
                            sValue = sValue == "" ? "0" : sValue;
                            plan_list.AddDouble("BASE_CTM", double.Parse(sValue));

                            plan_list.AddString("PROD_MAT_ID", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.PROD_MAT_ID].Text));
                            plan_list.AddString("ORDER_ID", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.ORDER_ID].Text));
                            plan_list.AddString("HALF_CELL_MAT_ID", spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.HCELL_MAT_ID].Text);
                        }
                    }
                }
                else if (tabCTM.SelectedIndex == 1)
                {
                    for (int i = 0; i < spdCTM.ActiveSheet.RowCount; i++)
                    {
                        if (spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value != null &&
                             Convert.ToBoolean(spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.COL_CHK].Value) == true)
                        {
                            for (int c = (int)SPD_CTM.TO_TIME + 1; c < spdCTM.ActiveSheet.Columns.Count; c++)
                            {
                                plan_list = in_node.AddNode("CTM_LIST");

                                string sWorkMonth = dtpMonth.Value.ToString("yyyyMM").Replace("-", "");
                                string sWorkDay = spdCTM.ActiveSheet.ColumnHeader.Columns[c].Tag.ToString();
                                sWorkDay = sWorkDay.Split('/')[1].PadLeft(2, '0');
                                string sWorkDate = sWorkMonth + sWorkDay;
                                plan_list.AddString("WORK_DATE", sWorkDate);

                                plan_list.AddString("LINE_ID", cdvLine2.Text.Trim());

                                string sFromTime = spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.FROM_TIME].Text.Replace(":", "").PadLeft(4, '0');
                                string sToTime = spdCTM.ActiveSheet.Cells[i, (int)SPD_CTM.TO_TIME].Text.Replace(":", "").PadLeft(4, '0');
                                plan_list.AddString("FROM_TIME", sFromTime);
                                plan_list.AddString("TO_TIME", sToTime);

                                string sItemName = cdvItem2.Text.Trim();
                                plan_list.AddString("ITEM_NAME", sItemName);
                                if (sItemName == "OFF_SET" || sItemName == "AREA_CELL" || sItemName == "BASE_CTM")
                                {
                                    string sValue = spdCTM.ActiveSheet.Cells[i, c].Text.Trim();
                                    sValue = sValue == "" ? "0" : sValue;
                                    plan_list.AddDouble(sItemName, double.Parse(sValue));
                                }
                                else if (sItemName == "HALF_CELL_MAT_ID" || sItemName == "ORDER_ID" || sItemName == "PROD_MAT_ID")
                                {
                                    plan_list.AddString(sItemName, spdCTM.ActiveSheet.Cells[i, c].Text.ToString().Trim());
                                }

                            }
                        }

                    }
                }
               
                if (MPCR.CallService("CWIP", "CWIP_Update_Ctm", in_node, ref out_node) == false)
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

        private bool DeleteCTM()
        {
            TRSNode in_node = new TRSNode("DELETE_IN");
            TRSNode out_node = new TRSNode("DELETE_OUT");
            TRSNode plan_list;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = Convert.ToChar(MPGC.MP_STEP_DELETE);

                for (int i = 0; i < spdCTMView.ActiveSheet.RowCount; i++)
                {
                    if (spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value != null &&
                         Convert.ToBoolean(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.COL_CHK].Value) == true)
                    {
                        plan_list = in_node.AddNode("CTM_LIST");

                        plan_list.AddString("WORK_DATE", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.WORK_DATE].Text).Replace("-", ""));
                        plan_list.AddString("LINE_ID", spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.LINE_ID].Text);
                        plan_list.AddString("FROM_TIME", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.FROM_TIME].Text).Replace(":",""));                        
                        plan_list.AddString("TO_TIME", MPCF.Trim(spdCTMView.ActiveSheet.Cells[i, (int)SPD_COL.TO_TIME].Text).Replace(":",""));
                    }

                }

                if (MPCR.CallService("CWIP", "CWIP_Update_Ctm", in_node, ref out_node) == false)
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

        private DataTable GetDateList(string sFomrmat)
        {
            try
            {
                DataTable dt = HQCF.MGetData("CMN_View_Date_List", new string[] {sFomrmat, dtpMonth.Value.ToString("yyyyMM").Substring(0, 4), dtpMonth.Value.ToString("yyyyMM").Substring(4, 2) });
                if (dt == null || dt.Rows.Count < 1) return null;

                return dt;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
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

                _dt = (DataTable)spdCTMView.DataSource;

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

            cdvItem2.ButtonPress += new System.EventHandler(cdvItem_ButtonPress);
            cdvLineID.ButtonPress += new System.EventHandler(cdvLineID_ButtonPress);
            cdvLine2.ButtonPress += new System.EventHandler(cdvLineID_ButtonPress);
            
            #endregion

            #region [ Spread Event ]
            //this.spdPlan.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(spdData_CellClick);
            //this.spdPlan.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(spdData_ButtonClicked);
            //this.spdPlan.EditModeOff += new System.EventHandler(spdData_EditModeOff);
            //this.spdPlan_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(spdData_Sheet1_CellChanged);
            #endregion

        }

        #endregion

        #region " Event Definition "

        private void frmCTMSetup_Load(object sender, EventArgs e)
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
            DataTable _dtData = (DataTable)spdCTMView.DataSource;
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
            spdCTMView.DataSource = _dtData;

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue("DELETE", spdCTMView) == true)
                {   
                    //체크된 행이 삭제됩니다. 삭제하시겠습니까?
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(367), Application.ProductName, MessageBoxButtons.YesNo, 1) != DialogResult.Yes) return;

                    if (DeleteCTM() == true)
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

        private void cdvItem_ButtonPress(object sender, EventArgs e)
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

                s_sql = "SELECT KEY_1 ITEM, DATA_1 ITEM_DESC FROM MGCMTBLDAT ";
                s_sql += " WHERE FACTORY='" + MPGV.gsFactory + "' AND TABLE_NAME = 'CTM_ITEM'";
                s_sql += " ORDER BY KEY_1 ";

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
            if(tabCTM.SelectedIndex == 0)
            {
                if (ViewCTMList("VIEW_TAB") == false) return;
            }
            else
            {
                if (ViewCTMList("CREATE_TAB") == false) return;
            }
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabCTM.SelectedIndex == 0) //VIEW TAB
            {
                if (CheckValue("UPDATE", spdCTMView) == true)
                {
                    if (UpdateCTM(MPGC.MP_STEP_UPDATE) == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
            else //CREATE TAB
            {
                if (CheckValue("CREATE", spdCTM) == true)
                {

                    if (UpdateCTM(MPGC.MP_STEP_CREATE) == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spread = spdCTMView;

            sCond = "Date : " + MPCF.MakeDateFormat(dtpWorkDate.FromDate.ToString(), DATE_TIME_FORMAT.DATE) + "~" + 
                                MPCF.MakeDateFormat(dtpWorkDate.ToDate.ToString(), DATE_TIME_FORMAT.DATE);
            if (tabCTM.SelectedIndex == 1)
            {
                spread = spdCTM;
                sCond = "Date : " + dtpMonth.Value.ToString("yyyy") + "-" + dtpMonth.Value.ToString("MM");
            }

            if (MPCF.ExportToExcel(spread, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        #endregion 

        private void spdCTMView_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int colidx;

                FarPoint.Win.Spread.SheetView spd = spdCTMView.ActiveSheet;

                colidx = spd.ActiveColumnIndex;

                if (colidx > 1)
                {
                    if (MPCF.Trim(spdCTMView.Sheets[0].Cells[spd.ActiveRowIndex, (int)SPD_COL.COL_CHK].Value).ToUpper() == "FALSE" ||
                          spdCTMView.ActiveSheet.Cells[spd.ActiveRowIndex, (int)SPD_COL.COL_CHK].Value == null)
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

        private void tabCTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCTM.SelectedIndex == 0)
            {
                btnDel.Visible = true;
            }
            else
            {
                btnDel.Visible = false;
                if(spdCTM.ActiveSheet.Rows.Count == 0)
                {
                    InitCreateSpread();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitCreateSpread();
        }

        private void spdCTM_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
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
                                for (int i = 0; i < spdCTM.ActiveSheet.Rows.Count; i++)
                                {
                                    spdCTM.ActiveSheet.Cells[i, 0].Value = "False";
                                }
                                bCheck = false;
                            }
                            else
                            {
                                for (int i = 0; i < spdCTM.ActiveSheet.Rows.Count; i++)
                                {
                                    spdCTM.ActiveSheet.Cells[i, 0].Value = "True";
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

        private void spdCTMView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
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
                                for (int i = 0; i < spdCTMView.ActiveSheet.Rows.Count; i++)
                                {
                                    spdCTMView.ActiveSheet.Cells[i, 0].Value = "False";
                                }
                                bCheck = false;
                            }
                            else
                            {
                                for (int i = 0; i < spdCTMView.ActiveSheet.Rows.Count; i++)
                                {
                                    spdCTMView.ActiveSheet.Cells[i, 0].Value = "True";
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

        private void spdCTM_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int colidx;

                FarPoint.Win.Spread.SheetView spd = spdCTM.ActiveSheet;

                colidx = spd.ActiveColumnIndex;

                if (colidx > 1)
                {
                    if (MPCF.Trim(spdCTM.Sheets[0].Cells[spd.ActiveRowIndex, (int)SPD_CTM.COL_CHK].Value).ToUpper() == "FALSE" ||
                          spdCTM.ActiveSheet.Cells[spd.ActiveRowIndex, (int)SPD_CTM.COL_CHK].Value == null)
                    {
                        spd.Cells[spd.ActiveRowIndex, (int)SPD_CTM.COL_CHK].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            InitCreateSpread();
        }

        private void cdvItem2_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            SetCellType();
        }

        private void spdCTM_ClipboardPasted(object sender, FarPoint.Win.Spread.ClipboardPastedEventArgs e)
        {
            int iCurrRow = spdCTM.ActiveSheet.ActiveRowIndex;
            string sText = Clipboard.GetText();
            int iFindIdx = 0;
            int iFindLastIdx = sText.LastIndexOf("\r\n");
            int iEditRowCnt = 0;
            while(true)
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
                
                if(iFindLastIdx == iFindIdx)
                {
                    break;
                }
            }


            for (int i = 0; i < iEditRowCnt; i++)
            {
                if (iCurrRow < spdCTM.ActiveSheet.Rows.Count)
                {
                    spdCTM.ActiveSheet.Cells[iCurrRow++, (int)SPD_CTM.COL_CHK].Value = true;
                }
            }
        }

    }
}
