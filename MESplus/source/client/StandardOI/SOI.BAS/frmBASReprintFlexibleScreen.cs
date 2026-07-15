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
using Infragistics.Win.UltraWinGrid;

namespace SOI.BAS
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmBASReprintFlexibleScreen : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        private int i_mat_ver = 0;

        private enum COL_PRINT_HISTORY_LIST
        {
            CHK = 0 ,
            PRINT_ID,
            PRINT_TYPE,
            SCREEN_ID,
            PRINT_COUNT,
            SEQ_NUM,
            MAT_ID,
            MAT_VER,
            FLOW,
            OPER,
            RES_ID,
            RESG_ID,
            CUSTOMER_ID,
            FUNC_NAME,
            ORDER_ID,
            LOT_ID,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmBASReprintFlexibleScreen()
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
        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            dtFrom.SetValueAsDateTime(DateTime.Now.AddMonths(-1));
            dtFrom.SetValueAsString(dtFrom.GetValueAsString(8) + "000000");
            dtTo.SetValueAsDateTime(DateTime.Now);
            dtTo.SetValueAsString(dtTo.GetValueAsString(8) + "235959");

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
        private void frmTempSOIBaseForm03_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// CodeView Material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");

            try
            {
                // In Node Setup
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "MAT_ID", "MAT_DESC", "MAT_VER" };
                string[] header = new string[] { "Mat ID", "Mat Desc", "Version" };
                string[] visibleFalse = new string[] { "MAT_VER" };
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, visibleFalse, "Mat ID");

                // Cancel 
                if (cdvMaterial.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // Clear
                txtMaterial.Text = string.Empty;
                i_mat_ver = 0;
                MPCF.FieldClear(pnlFlow);
                MPCF.FieldClear(pnlOper);

                // Empty
                if (string.IsNullOrEmpty(cdvMaterial.Text) == true)
                {                    
                    return;
                }

                // Description               
                txtMaterial.Text = cdvMaterial.returnDatas[1];
                i_mat_ver = MPCF.ToInt(cdvMaterial.returnDatas[2]);

                // View
                if (ViewPrintHistory() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }                 
        }

        /// <summary>
        /// Flow CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvFlow_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_FLOW_LIST_IN");

            try
            {
                // In Node Setup
                MPCF.SetInMsg(in_node);

                if (string.IsNullOrEmpty(cdvMaterial.Text) == false)
                {
                    in_node.ProcStep = '2';
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                    in_node.AddInt("MAT_VER", i_mat_ver);
                }
                else
                {
                    in_node.ProcStep = '1';
                }
                
                string[] display = new string[] { "FLOW", "FLOW_DESC" };
                string[] header = new string[] { "Flow", "Flow Desc" };
                cdvFlow.Text = cdvFlow.Show(cdvFlow, "View Flow List", "WIP", "WIP_View_Flow_List", in_node, "FLOW_LIST", display, header, "FLOW");

                // Cancel 
                if (cdvFlow.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // Clear
                txtFlow.Text = string.Empty;
                MPCF.FieldClear(pnlOper);

                // Field Clear
                if (string.IsNullOrEmpty(cdvFlow.Text) == true)
                {
                    return;
                }

                // Description               
                txtFlow.Text = cdvFlow.returnDatas[1];

                // View
                if (ViewPrintHistory() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }                 
        }

        /// <summary>
        /// Operation CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");

            try
            {
                // In Node Setup
                MPCF.SetInMsg(in_node);

                // Material이 있는 경우
                if (string.IsNullOrEmpty(cdvMaterial.Text) == false)
                {
                    // Flow가 있는 경우
                    if (string.IsNullOrEmpty(cdvFlow.Text) == false)
                    {
                        in_node.ProcStep = '4';
                        in_node.AddString("MAT_ID", cdvMaterial.Text);
                        in_node.AddInt("MAT_VER", i_mat_ver);
                        in_node.AddString("FLOW", cdvFlow.Text);
                    }
                    // Flow가 없는 경우
                    else
                    {
                        in_node.ProcStep = '1';
                    }                    
                }
                // Material이 없는 경우
                else
                {
                    // Flow가 있는 경우
                    if (string.IsNullOrEmpty(cdvFlow.Text) == false)
                    {
                        in_node.ProcStep = '2';                        
                        in_node.AddString("FLOW", cdvFlow.Text);
                    }
                    // Flow가 없는 경우
                    else
                    {
                        in_node.ProcStep = '1';
                    }              
                }

                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                // Cancel 
                if (cdvOper.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // Clear
                txtOper.Text = string.Empty;

                // Field Clear
                if (string.IsNullOrEmpty(cdvOper.Text) == true)
                {
                    return;
                }

                // Description               
                txtOper.Text = cdvOper.returnDatas[1];

                // View
                if (ViewPrintHistory() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }                 
        }

        /// <summary>
        /// Resource CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResId_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");

            try
            {                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Res ID", "Res Desc" };
                cdvResId.Text = cdvResId.Show(cdvResId, "View Resource List", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

                // Cancel 
                if (cdvResId.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // Clear
                txtResId.Text = string.Empty;

                // Field Clear
                if (string.IsNullOrEmpty(cdvResId.Text) == true)
                {
                    return;
                }

                // Description               
                txtResId.Text = cdvResId.returnDatas[1];

                // View
                if (ViewPrintHistory() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View by Print Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrintedId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (ViewPrintHistory() == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Spread Cell Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdPrintHistory_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // First Column Header Cell
                if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
                {
                    // Select All
                    if (spdPrintHistory.Sheets[0].ColumnHeader.Cells[0, 0].Value == null
                        || ((bool)spdPrintHistory.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                    {
                        spdPrintHistory.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                        for (int i = 0; i < spdPrintHistory.Sheets[0].Rows.Count; i++)
                        {
                            spdPrintHistory.Sheets[0].Cells[i, 0].Value = true;
                        }
                    }
                    // Release All
                    else
                    {
                        spdPrintHistory.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                        for (int i = 0; i < spdPrintHistory.Sheets[0].Rows.Count; i++)
                        {
                            spdPrintHistory.Sheets[0].Cells[i, 0].Value = false;
                        }
                    }
                }
                else if(e.ColumnHeader == false)
                {
                    MPCF.SOISpreadSetCheckBox(spdPrintHistory, (int)COL_PRINT_HISTORY_LIST.CHK, e.Row);
                }

                txtCount.Text = string.Empty;
                int iCount = 0;
                for (int i = 0; i < spdPrintHistory.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.CHK].Value == true)
                    {
                        iCount++;
                    }
                }
                txtCount.Text = MPCF.MakeNumberFormat(Convert.ToString(iCount));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(this);
                i_mat_ver = 0;
                dtFrom.SetValueAsDateTime(DateTime.Now.AddMonths(-1));
                dtFrom.SetValueAsString(dtFrom.GetValueAsString(8) + "000000");
                dtTo.SetValueAsDateTime(DateTime.Now);
                dtTo.SetValueAsString(dtTo.GetValueAsString(8) + "235959");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Print History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewPrintHistory() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Reprint 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // 선택된 데이터가 있는지 체크
                if(IsExistCheckColumn() == false)
                {
                    return;
                }

                // 재발행
                if(Reprint() == false)
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }        
        }

        #endregion

        #region Function

        /// <summary>
        /// View Print History
        /// </summary>
        /// <returns></returns>
        private bool ViewPrintHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_PRINT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_PRINT_HISTORY_OUT");

            try
            {
                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (string.IsNullOrEmpty(cdvMaterial.Text) == false)
                {
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                    in_node.AddInt("MAT_VER", i_mat_ver);                    
                }
                if (string.IsNullOrEmpty(cdvFlow.Text) == false)
                {
                    in_node.AddString("FLOW", cdvFlow.Text);
                }
                if (string.IsNullOrEmpty(cdvOper.Text) == false)
                {
                    in_node.AddString("OPER", cdvOper.Text);
                }
                if (string.IsNullOrEmpty(cdvResId.Text) == false)
                {
                    in_node.AddString("RES_ID", cdvResId.Text);
                }
                if (string.IsNullOrEmpty(dtFrom.GetValueAsString(14)) == false
                    && string.IsNullOrEmpty(dtTo.GetValueAsString(14)) == false)
                {
                    in_node.AddString("FROM_CREATE_TIME", dtFrom.GetValueAsString(14));
                    in_node.AddString("TO_CREATE_TIME", dtTo.GetValueAsString(14));
                }
                if (string.IsNullOrEmpty(txtPrintedId.Text) == false)
                {
                    in_node.AddString("PRINT_ID", txtPrintedId.Text);
                }
                if (MPCF.CallService("BAS", "BAS_View_Screen_Print_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.FieldClear(spdPrintHistory);
                MPCF.FieldClear(txtCount);

                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdPrintHistory.Sheets[0].Rows.Count;
                        spdPrintHistory.Sheets[0].RowCount++;

                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.CHK].Value = false;
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.PRINT_ID].Value = out_node.GetList(0)[i].GetString("PRINT_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.PRINT_TYPE].Value = out_node.GetList(0)[i].GetString("PRINT_TYPE");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.SCREEN_ID].Value = out_node.GetList(0)[i].GetString("SCREEN_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.PRINT_COUNT].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("PRINT_COUNT"));
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.SEQ_NUM].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.FLOW].Value = out_node.GetList(0)[i].GetString("FLOW");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.RESG_ID].Value = out_node.GetList(0)[i].GetString("RESG_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.CUSTOMER_ID].Value = out_node.GetList(0)[i].GetString("CUSTOMER_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.FUNC_NAME].Value = out_node.GetList(0)[i].GetString("FUNC_NAME");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.LOT_ID].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.CREATE_USER_ID].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.UPDATE_USER_ID].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                        spdPrintHistory.Sheets[0].Cells[iRow, (int)COL_PRINT_HISTORY_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                    }
                }

                // Fit
                MPCF.FitColumnHeader(spdPrintHistory);

                // Count
                txtCount.Text = "0";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;                     
            }
        }

        /// <summary>
        /// 체크된 컬럼이 있는지 확인
        /// </summary>
        /// <returns></returns>
        private bool IsExistCheckColumn()
        {
            bool bFound = false;

            try
            {
                // 데이터가 없는 경우
                if(spdPrintHistory.Sheets[0].Rows.Count < 1)
                {
                    return false;
                }

                // 선택된 데이터가 없는 경우
                for(int i= 0 ; i < spdPrintHistory.Sheets[0].Rows.Count; i++)
                {
                    if((bool)spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.CHK].Value == true)
                    {
                        bFound = true;
                        break;
                    }
                }

                return bFound;
            }
            catch(Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 재발행합니다.
        /// </summary>
        /// <returns></returns>
        private bool Reprint()
        {
            TRSNode in_node = new TRSNode("REPRINT_FLEXIBLE_SCREEN_IN");
            TRSNode out_node = new TRSNode("REPRINT_FLEXIBLE_SCREEN_OUT");

            try
            {
                for (int i = 0; i < spdPrintHistory.Sheets[0].Rows.Count; i++)
                {
                    // Check 안된 컬럼은 제외
                    if ((bool)spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.CHK].Value == false)
                    {
                        continue;
                    }

                    // Screen 초기화
                    fsScreen.InitFlexibleScreen();
                    fsScreen.ScreenSpread.Tag = "Change Cell";
                    fsScreen.ProcStep = '1';
                    fsScreen.PrintType = MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.PRINT_TYPE].Value);
                    fsScreen.ScreenID = MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.SCREEN_ID].Value);
                    
                    // Get Screen
                    if (fsScreen.LoadDesignByMfo() == false)
                    {
                        return false;
                    }

                    // Get Params
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("PRINT_ID", MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.PRINT_ID].Value));
                    in_node.AddString("PRINT_TYPE", MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.PRINT_TYPE].Value));
                    in_node.AddInt("SEQ_NUM", MPCF.ToInt(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.SEQ_NUM].Value));
                    if (MPCF.CallService("BAS", "BAS_VIEW_SCREEN_PRINT", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    // Mapping
                    if (fsScreen.SetDataToScreen(out_node.GetString("PRINT_PARAMS")) == false)
                    {
                        return false;
                    }

                    // Print
                    MPCF.PrintFlexibleScreen(this, base.printOption, fsScreen, true);

                    // Reprint Service
                    in_node.Init();
                    out_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.AddString("PRINT_ID", MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.PRINT_ID].Value));
                    in_node.AddString("PRINT_TYPE", MPCF.ToStr(spdPrintHistory.Sheets[0].Cells[i, (int)COL_PRINT_HISTORY_LIST.PRINT_TYPE].Value));
                    if (MPCF.CallService("BAS", "BAS_REPRINT_SCREEN", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    // Count
                    txtCount.Text = MPCF.ToStr(MPCF.ToInt(txtCount.Text) - 1);
                }

                // Re-View
                if (ViewPrintHistory() == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                
                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}

