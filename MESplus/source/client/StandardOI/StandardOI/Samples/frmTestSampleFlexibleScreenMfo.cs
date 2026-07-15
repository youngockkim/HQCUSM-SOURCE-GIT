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

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleFlexibleScreenMfo : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        private enum COL_SCREEN_LIST
        {
            SEQ = 0,
            SCREEN_ID,
            MAT_ID,
            FLOW,
            OPER,
            RES_ID,
            RESG_ID,
            FACTORY,
            PRINT_TYPE,
            FUNC_NAME,
            CUSTOMER            
        }

        #endregion

        #region Constructor

        public frmTestSampleFlexibleScreenMfo()
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
            // Init
            cdvFactory.Text = MPGV.gsFactory;

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
        /// Material List를 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMatId_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "MAT_ID", "MAT_DESC", "MAT_VER" };
                string[] header = new string[] { "Mat ID", "Mat Desc", "Version" };
                string[] visibleFalse = new string[] { "MAT_VER" };
                cdvMatId.Text = cdvMatId.Show(cdvMatId, "Material", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, visibleFalse, "Mat ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }     
        }

        /// <summary>
        /// Flow List를 조회합니다.
        /// 1) Material이 지정된 경우 종속
        /// 2) Material이 지정되지 않은 경우 전체
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvFlow_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_FLOW_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                if (string.IsNullOrEmpty(cdvMatId.Text) == false)
                {
                    in_node.ProcStep = '2';
                    in_node.AddString("MAT_ID", cdvMatId.Text);
                    in_node.AddInt("MAT_VER", cdvMatId.returnDatas[2]);
                }
                else
                {
                    in_node.ProcStep = '1';
                }
                string[] display = new string[] { "FLOW", "FLOW_DESC" };
                string[] header = new string[] { "Flow", "Flow Desc" };
                cdvFlow.Text = cdvFlow.Show(cdvFlow, "Flow", "WIP", "WIP_View_Flow_List", in_node, "FLOW_LIST", display, header, "FLOW");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }            
        }

        /// <summary>
        /// Operation List를 조회합니다.
        /// 1) Material이 지정된 경우,
        ///   1-1) Flow도 지정된 경우, 종속
        ///   1-2) Flow는 지정되지 않은 경우 공장전체
        /// 2) Material이 지정되지 않은 경우,
        ///   2-1) Flow는 지정된 경우, 종속
        ///   2-2) Flow도 지정되지 않은 경우 공장전체
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                if (string.IsNullOrEmpty(cdvMatId.Text) == false)
                {
                    if (string.IsNullOrEmpty(cdvFlow.Text) == false)
                    {
                        in_node.ProcStep = '4';
                        in_node.AddString("MAT_ID", cdvMatId.Text);
                        in_node.AddInt("MAT_VER", cdvMatId.returnDatas[2]);
                        in_node.AddString("FLOW", cdvFlow.Text);
                    }
                    else
                    {
                        in_node.ProcStep = '1';
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(cdvFlow.Text) == false)
                    {
                        in_node.ProcStep = '2';
                        in_node.AddString("FLOW", cdvFlow.Text);
                    }
                    else
                    {
                        in_node.ProcStep = '1';
                    }
                }
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvOper.Text = cdvOper.Show(cdvOper, "Operation", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "OPER");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }      
        }

        /// <summary>
        /// Resource List를 조회합니다.
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
                string[] header = new string[] { "Resource", "Resource Desc" };
                cdvResId.Text = cdvResId.Show(cdvResId, "Resource", "RAS", "RAS_VIEW_RESOURCE_LIST", in_node, "RES_LIST", display, header, "RES_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }      
        }

        /// <summary>
        /// Resource Group List를 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResGrp_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_RES_GROUP_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "RESG_ID", "RESG_DESC" };
                string[] header = new string[] { "Res Group", "Res Group Desc" };
                cdvResGrp.Text = cdvResGrp.Show(cdvResGrp, "Resource Group", "RAS", "RAS_VIEW_RESOURCE_GROUP_LIST", in_node, "RESG_LIST", display, header, "RESG_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }      
        }

        /// <summary>
        /// Factory List를 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvFactory_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_FACTORY_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "FACTORY", "FAC_DESC" };
                string[] header = new string[] { "FACTORY", "Factory Desc" };
                cdvFactory.Text = cdvFactory.Show(cdvFactory, "Factory", "WIP", "WIP_VIEW_FACTORY_LIST", in_node, "FAC_LIST", display, header, "FACTORY");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }      
        }

        /// <summary>
        /// Print Type GCM테이블을 조회합니다.
        /// "SCREEN_PRINT_TYPE"을 고정하여 사용합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvPrtType_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "SCREEN_PRINT_TYPE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Code", "Desc" };
                cdvPrtType.Text = cdvPrtType.Show(cdvPrtType, "Print Type", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");      
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면(Function) List를 조회합니다.
        /// OIClient ADMIN_GROUP에 할당된 화면 목록을 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvFunc_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNC_LIST_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                string[] display = new string[] { "FUNC_NAME", "FUNC_DESC" };
                string[] header = new string[] { "FUNC_NAME", "FUNC_DESC" };
                cdvFunc.Text = cdvFunc.Show(cdvFunc, "Function in OI Client ADMIN Group", "SEC", "SEC_VIEW_FUNCTION_LIST", in_node, "LIST", display, header, "FUNC_NAME");      
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Customer List를 조회합니다.
        /// "INV_CUSTOMER"을 고정하여 사용합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvCust_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "INV_CUSTOMER");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "ID", "Desc" };
                cdvCust.Text = cdvCust.Show(cdvCust, "Customer", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면의 모든 내용을 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);
                cdvFactory.Text = MPGV.gsFactory;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// MFO 관계를 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewFlexibleScreenMfoList() == false)
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
        /// Cell Click 시, 해당 Screen을 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdScreenList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (ViewScreen(MPCF.ToStr(spdScreenList.Sheets[0].Cells[e.Row, (int)COL_SCREEN_LIST.SCREEN_ID].Value)) == false)
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
        /// Lot ID를 조회하고 조회된 데이터를 Screen에 Bind 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (ViewLotAndMapping() == false)
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
        /// Lot ID를 조회하고 조회된 데이터를 Screen에 Bind 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewLotAndMapping() == false)
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
        /// 테스트 프린트 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintLabel() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// MFO 관계를 조회합니다.
        /// </summary>
        /// <returns></returns>
        private bool ViewFlexibleScreenMfoList()
        {
            TRSNode in_node = new TRSNode("VIEW_GET_SCREEN_ID_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_GET_SCREEN_ID_LIST_OUT");

            try
            {
                // Factory는 필수 입니다.
                if (MPCF.CheckValue(cdvFactory, false) == false)
                {
                    return false;
                }
                // Print Type은 필수 입니다.
                if (MPCF.CheckValue(cdvPrtType, false) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(spdScreenList);
                MPCF.FieldClear(txtLotId);
                MPCF.FieldClear(fsScreen);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", cdvMatId.Text);
                in_node.AddString("FLOW", cdvFlow.Text);
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("RES_ID", cdvResId.Text);
                in_node.AddString("RESG_ID", cdvResGrp.Text);
                // Factory는 SetInMsg에서 자동할당.
                in_node.AddString("PRINT_TYPE", cdvPrtType.Text);
                in_node.AddString("FUNC_NAME", cdvFunc.Text);                
                in_node.AddString("CUSTOMER", cdvCust.Text);
                // REL_LEVEL은 지정하지 않는 경우 우선순위에 따라 자동조회
                //in_node.AddString("REL_LEVEL", "1");
                if (MPCF.CallService("BAS", "BAS_GET_SCREEN_ID_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Data Found                
                if (out_node.GetList("LIST") != null)
                {
                    List<TRSNode> list = out_node.GetList("LIST");

                    // List
                    int iRow = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        iRow = spdScreenList.Sheets[0].Rows.Count;
                        spdScreenList.Sheets[0].Rows.Count++;

                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.SEQ].Value = (i + 1);
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.SCREEN_ID].Value = list[i].GetString("SCREEN_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.MAT_ID].Value = list[i].GetString("MAT_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.FLOW].Value = list[i].GetString("FLOW");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.OPER].Value = list[i].GetString("OPER");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.RES_ID].Value = list[i].GetString("RES_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.RESG_ID].Value = list[i].GetString("RESG_ID");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.FACTORY].Value = list[i].GetString("FACTORY");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.PRINT_TYPE].Value = list[i].GetString("PRINT_TYPE");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.FUNC_NAME].Value = list[i].GetString("FUNC_NAME");
                        spdScreenList.Sheets[0].Cells[iRow, (int)COL_SCREEN_LIST.CUSTOMER].Value = list[i].GetString("CUSTOMER_ID");
                    }

                    MPCF.SOISpreadSetSelectionSingleRow(spdScreenList, 0);
                    if (ViewScreen(MPCF.ToStr(spdScreenList.Sheets[0].Cells[0, (int)COL_SCREEN_LIST.SCREEN_ID].Value)) == false)
                    {
                        return false;
                    }
                }
                // No Data Found
                else
                {
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Fleixble Screen을 조회합니다.
        /// </summary>
        /// <param name="screenId"></param>
        /// <returns></returns>
        private bool ViewScreen(string screenId)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(txtLotId);
                MPCF.FieldClear(fsScreen);

                fsScreen.InitFlexibleScreen();
                fsScreen.ScreenSpread.Tag = "Change Cell";
                fsScreen.ProcStep = '1';
                fsScreen.ScreenID = screenId;
                if (fsScreen.LoadDesign() == false)
                {
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

        /// <summary>
        /// Lot 정보를 조회하고 fsscreen에 Bind 합니다.
        /// </summary>
        /// <returns></returns>
        private bool ViewLotAndMapping()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_INFO_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_INFO_OUT");

            try
            {
                // Lot ID는 필수 입니다.
                if (MPCF.CheckValue(txtLotId, false) == false)
                {
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotId.Text);
                if (MPCF.CallService("WIP", "WIP_VIEW_LOT", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (fsScreen.SetDataToScreen(out_node) == false)
                {
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

        /// <summary>
        /// Label을 프린트합니다.
        /// </summary>
        /// <returns></returns>
        private bool PrintLabel()
        {
            try
            {
                // Print
                MPCF.PrintFlexibleScreen(this, base.printOption, fsScreen, true);

                // Setting fsScreen Data                
                fsScreen.ProcStep = '1';
                fsScreen.PrintType = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.PRINT_TYPE].Value);
                //fsScreen.ScreenID = string.Empty;
                fsScreen.MatID = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.MAT_ID].Value);
                //fsScreen.MatVer = ORDER.GetInt("MAT_VER");
                fsScreen.Flow = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.FLOW].Value);
                fsScreen.Oper = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.OPER].Value);
                fsScreen.ResID = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.RES_ID].Value);
                fsScreen.ResGroup = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.RESG_ID].Value);
                fsScreen.CustomerId = MPCF.ToStr(spdScreenList.Sheets[0].Cells[spdScreenList.Sheets[0].ActiveRowIndex, (int)COL_SCREEN_LIST.CUSTOMER].Value);
                fsScreen.OrderId = string.Empty;
                fsScreen.LotID = txtLotId.Text;
                //MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                //fsScreen.OwnerFuncName = menuInfo.s_func_name;

                // Insert History
                if (MPCF.UpdatePrintScreenHistory(fsScreen, txtLotId.Text, "WIP_View_Lot") == false)
                {
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

        #endregion
    }
}
