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
    public partial class frmTestSampleFlexibleScreen : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleFlexibleScreen()
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
#if _H101
            tlpUseService.Visible = true;
#endif
#if _Http
            tlpUseService.Visible = false;
#endif

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
        /// Lot ID를 입력하고 버튼을 눌렀을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLot_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option) Validation for TextBox
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // (Option) View Lot Information
                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID를 입력하고 엔터키를 눌렀을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // (Option) Validation for TextBox
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }

                    // (Option) View Lot Information
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

        /// <summary>
        /// (Option) Load Design
        /// MESplus SE의 경우, Flexible Design을 로드하는 로직에 대한 샘플입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoadSampleDesign() == false)
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
        /// (Option) FarPoint Spread Designer Load
        /// Flexible Screen을 직접 수정하기 위한 FarPoint Spread Designer를 로드합니다.
        /// FarPoint.Spread.Win.Design.dll 라이브러리를 필요로 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.Design.DesignerMain design = new FarPoint.Win.Spread.Design.DesignerMain(udcScreenRule.ScreenSpread);
                design.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Call Service and Data Bind
        /// 서비스를 호출하고 조회한 데이터를 Spread에 Bind 합니다.
        /// Flexible Screen Rule에 따라 단일데이터 또는 리스트데이터를 Bind할 수 있습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (BindSampleFunc() == false)
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
        /// (Option) Lock or Unlock
        /// 특정 Row 또는 Column에 대하여 Lock/Unlock 처리 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLock_OnOffStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLock.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    // Lock Cell의 Background Color를 지정합니다.
                    udcScreenRule.ScreenLockBackColor = Color.FromArgb(0, 100, 50);

                    // 특정 Row (여기서는 0)에 대해 Lock 처리 합니다.
                    udcScreenRule.ChangeLockStatus(SOIFlexibleScreen.TableMatrix.ROW, 0, true);

                    // 특정 Column (여기서는 1)에 대해 Lock 처리 합니다.
                    udcScreenRule.ChangeLockStatus(SOIFlexibleScreen.TableMatrix.COLUMN, 1, true);
                }
                else if (chkLock.OnOffState == SOICheckBoxOnOffState.OffState)
                {
                    // 특정 Row (여기서는 0)에 대해 Unlock 처리 합니다.
                    udcScreenRule.ChangeLockStatus(SOIFlexibleScreen.TableMatrix.ROW, 0, false);

                    // 특정 Column (여기서는 1)에 대해 Unlock 처리 합니다.
                    udcScreenRule.ChangeLockStatus(SOIFlexibleScreen.TableMatrix.COLUMN, 1, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Initialize Flexible Screen
        /// Flexible Screen을 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear all Rows and Columns
                udcScreenRule.InitFlexibleScreen();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Add Row with List
        /// List 데이터를 마지막 Row에 추가합니다.
        /// 마지막 Row에 데이터가 있는 경우, 신규 Row를 추가합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                // List Generation
                List<object> data = new List<object>();
                for (int i = 0; i < udcScreenRule.ScreenSpread.ActiveSheet.ColumnCount; i++)
                {
                    data.Add("DATA_" + i.ToString());
                }

                // Add to Row
                udcScreenRule.AddRowInSpread(data);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Remove Active Row
        /// Active Row를 삭제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove Active Row
                udcScreenRule.RemoveLastRow();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Change Column Visible
        /// 특정 Column의 Visible 속성을 변경 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkChangeVisible_OnOffStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkChangeVisible.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    // Set Visible True 0, 1, 2, 3 Column
                    udcScreenRule.ChangeColumnVisible(0, 4, true);
                }
                else if (chkChangeVisible.OnOffState == SOICheckBoxOnOffState.OffState)
                {
                    // Set Visible False 0, 1, 2, 3 Column
                    udcScreenRule.ChangeColumnVisible(0, 4, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Print Flexible Screen with Document Printer
        /// Flexible Screen을 문서로 출력합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintDocu_Click(object sender, EventArgs e)
        {
            try
            {
                // Document Print 합니다.
                MPCF.PrintFlexibleScreen(this, base.printOption, udcScreenRule, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Print Flexible Screen with Label Printer
        /// Flexible Screen을 라벨 프린터로 출력합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            try
            {
                // Label Print 합니다.
                MPCF.PrintFlexibleScreen(this, base.printOption, udcScreenRule, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Lot Info
        /// </summary>
        /// <param name="s_lot_id"></param>
        /// <returns></returns>
        private bool ViewLotInfo(string s_lot_id)
        {
            try
            {
                // (Option) Initialize Flexible Screen 
                // Flexible Screen의 Sheet에 있는 모든 Row를 삭제합니다.
                udcScreen.InitFlexibleScreen();

                // (Required) In Node Setup
                // In Node를 설정합니다.
                // 상황에 따라, 조건을 추가할 수 있습니다.
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                // in_node.AddString("MAT_ID", mat_id);

#if _H101

                // For MESplus EE Server

                // (Required) Use Flexible Screen Setup Service or Not
                // 설정된 서비스를 사용하거나 또는 직접 서비스를 입력합니다.
                if (chkUseFlxService.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    // 설정된 서비스를 사용합니다.

                    // (Required) Convert Caption(Language) Type
                    // Tag에 아래와 같이 입력 시, 다국어 변경을 적용합니다.
                    // Header No Change : 모두 다국어 변경을 하지 않습니다.
                    // Change Cell : 모두 다국어 변경을 합니다.
                    // (입력하지 않은 경우) : Column, Row 헤더만 변경합니다.
                    udcScreen.ScreenSpread.Tag = "Change Cell";

                    // (Required) View Screen ID Service Proc Step
                    // 스크린 ID를 조회하는 서비스(BAS", "BAS_Process_Flexible_Screen)의 Proc Step을 설정합니다.
                    udcScreen.ProcStep = '1';

                    // (Required) View Screen ID Service Lot ID
                    // 스크린 ID를 조회하는 서비스(BAS", "BAS_Process_Flexible_Screen)의 Lot ID를 설정합니다.
                    udcScreen.LotID = s_lot_id;

                    // (Required) Screen ID
                    // 스크린 ID를 직접 입력하면 해당 스크린 ID를 호출하여 사용합니다.
                    // 값을 입력하지 않으면 스크린 ID를 설정에 따라 조회하여 사용합니다.
                    udcScreen.ScreenID = string.Empty;

                    // (Required) Load Flexible Screen to Spread
                    // 스크린 ID를 파라미터로 전달하지 않으면 스크린 ID를 설정에 따라 조회하고 Flexible Screen을 다운로드하여 Spread에 Bind합니다.
                    // 스크린 ID를 전달하면 해당 스크린 ID를 조회하고 Flexible Screen을 다운로드하여 Spread에 Bind 합니다.
                    if (udcScreen.LoadDesign() == false)
                    {
                        return false;
                    }

                    // (Required) Call Service
                    // 설정된 in_node를 기준으로 Flexible Screen Setup에 설정된 서비스를 호출 합니다.
                    // 서비스 호출이 완료된 후 데이터를 맵핑 합니다.
                    if (udcScreen.SetServiceData(in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    // 직접 서비스를 입력합니다.

                    // (Required) Input Service Name
                    // 서비스를 호출하고 out_node를 받습니다.
                    if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    // (Required) Convert Caption(Language) Type
                    // Tag에 아래와 같이 입력 시, 다국어 변경을 적용합니다.
                    // Header No Change : 모두 다국어 변경을 하지 않습니다.
                    // Change Cell : 모두 다국어 변경을 합니다.
                    // (입력하지 않은 경우) : Column, Row 헤더만 변경합니다.
                    udcScreen.ScreenSpread.Tag = "Change Cell";

                    // (Required) View Screen ID Service Proc Step
                    // 스크린 ID를 조회하는 서비스(BAS", "BAS_Process_Flexible_Screen)의 Proc Step을 설정합니다.
                    udcScreen.ProcStep = '1';

                    // (Required) View Screen ID Service Lot ID
                    // 스크린 ID를 조회하는 서비스(BAS", "BAS_Process_Flexible_Screen)의 Lot ID를 설정합니다.
                    udcScreen.LotID = s_lot_id;

                    // (Required) Screen ID
                    // 스크린 ID를 직접 입력하면 해당 스크린 ID를 호출하여 사용합니다.
                    // 값을 입력하지 않으면 스크린 ID를 설정에 따라 조회하여 사용합니다.
                    udcScreen.ScreenID = string.Empty;

                    // (Required) Load Flexible Screen to Spread
                    // 스크린 ID를 파라미터로 전달하지 않으면 스크린 ID를 설정에 따라 조회하고 Flexible Screen을 다운로드하여 Spread에 Bind합니다.
                    // 스크린 ID를 전달하면 해당 스크린 ID를 조회하고 Flexible Screen을 다운로드하여 Spread에 Bind 합니다.
                    if (udcScreen.LoadDesign() == false)
                    {
                        return false;
                    }

                    // (Required) Mapping
                    // out_node의 멤버 명을 기준으로 Flexible Screen과 맵핑 합니다.
                    if (udcScreen.SetDataToScreen(out_node) == false)
                    {
                        return false;
                    }
                }

#endif

#if _Http

                // For MESplus SE Server

                // 직접 서비스를 입력합니다.

                // (Required) Call Service
                // 서비스를 호출하고 out_node를 받습니다.
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // (Required) Convert Caption(Language) Type
                // Tag에 아래와 같이 입력 시, 다국어 변경을 적용합니다.
                // -- Header No Change : 모두 다국어 변경을 하지 않습니다.
                // -- Change Cell : Cell에 대해서만 다국어 변경을 합니다.
                // -- 입력하지 않은 경우 : Column, Row 헤더만 변경합니다.
                udcScreen.ScreenSpread.Tag = "Change Cell";

                // (Required) View Screen ID Service Proc Step
                // MESplus SE의 경우, "SCREEN_REL" GCM 테이블에 Function Name과 Screen ID를 맵핑하여 정보를 저장합니다.
                // GCM Table을 조회하는 서비스("BAS", "BAS_View_Data_List")의 Proc Step을 설정합니다.
                udcScreen.ProcStep = '1';

                // (Required) Screen ID
                // 스크린 ID를 직접 입력하면 해당 스크린 ID를 호출하여 사용합니다.
                // 값을 입력하지 않으면 스크린 ID를 설정에 따라 조회하여 사용합니다.
                udcScreen.ScreenID = string.Empty;

                // (Required) Function Name
                // MESplus SE의 경우, "SCREEN_REL" GCM 테이블에 Function Name과 Screen ID를 맵핑하여 정보를 저장합니다.
                // 따라서 조회하고자 하는 현재 화면의 Function Name을 설정합니다.
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcScreen.OwnerFuncName = menuInfo.s_func_name; // ex) OWIP1001, OATP2002, ...

                // (Required) Load Flexible Screen to Spread
                // 스크린 ID를 파라미터로 전달하지 않으면 스크린 ID를 GCM Table에서 조회하고 Flexible Screen을 다운로드 또는 로드하여 Spread에 Bind합니다.
                // $로 시작하는 예약어가 포함된 Cell을 HashTable에 위치와함께 별도 저장한 뒤, 해당 Cell의 값을 empty로 처리합니다.
                if (udcScreen.LoadDesign() == false)
                {
                    return false;
                }

                // (Required) Mapping
                // out_node의 멤버 명을 기준으로 Flexible Screen과 맵핑 합니다.

                // $ 인 경우 (ex. $LOT_ID, $MAT_ID, ...)
                // -- 단일 Cell에 대해 값을 맵핑하고자 하는 경우에 사용한다.

                // $= 인 경우(ex. $=DATA_LIST.CODE, $=DATA_LIST.DESC , ...)
                // -- 예약어가 정의된 Cell을 기준으로 LIST의 값을 순차적으로 수직으로 입력한다. 
                // -- row수는 값의 개수에 따라 자동 증가된다.
                // -- 하나의 column에 list 값을 맵핑하고자 하는 경우에 사용한다.

                // $> 인 경우(ex. $>DATA_LIST.CODE, $>DATA_LIST.DESC, ...)
                // -- 예약어가 정의된 Cell을 기준으로 LIST의 값을 순차적으로 수평으로 입력한다.
                // -- column수는 자동증가되지 않는다. 설정된 column 수 만큼만 데이터를 맵핑한다.
                // -- 하나의 row에 list 값을 지정된 column수 만큼만 맵핑하고자 하는 경우에 사용한다.

                // $LISTNAME$ 인 경우 (ex. $DATA_LIST$, $RES_LIST$, ...)
                // -- 예약어가 정의된 Cell을 기준으로  LIST의 값을 수직, 수평으로 입력한다.
                // -- row, column 수는 값의 개수에 따라 자동증가된다.
                // -- Column Header를 List Item의 Member 이름으로 변경한다. 
                // -- Sheet의 모든 내용을 LIST로 채우고자 하는 경우에만 사용한다.
                if (udcScreen.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

#endif

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Sample Design Load
        /// For MESplus SE, "SCREEN_REL" GCM Table required.
        /// To do, this function has to be set up in "SCREEN_REL" GCM Table with Screen ID.
        /// </summary>
        /// <returns></returns>
        private bool LoadSampleDesign()
        {
            try
            {
                // 1. Initialize
                udcScreenRule.InitFlexibleScreen();

                // 2. Convert Caption(Language) Type                
                udcScreenRule.ScreenSpread.Tag = "Change Cell";
                //udcScreenRule.ScreenSpread.Tag = "Header No Change";
                //udcScreenRule.ScreenSpread.Tag = null;

                // 3. View Screen ID Service Proc Step                
                udcScreenRule.ProcStep = '1';

                // 4. Screen ID                
                udcScreenRule.ScreenID = string.Empty;

                // 5. Function Name                
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcScreenRule.OwnerFuncName= menuInfo.s_func_name; // ex) OWIP1001, OATP2002, ...

                // 6. Load Flexible Screen to Spread                
                if (udcScreenRule.LoadDesign() == false)
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
        /// 서비스 호출 및 Bind 샘플
        /// </summary>
        /// <returns></returns>
        private bool BindSampleFunc()
        {
            try
            {
                // For MESplus SE Server
                
                // 1. Call Service
                //TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                //TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //if (MPCF.CallService("WIP", "WIP_View_Lot_List", in_node, ref out_node) == false)
                //{
                //    return false;
                //}

                // For Sample Test : Make out_node by logic
                // 샘플 용도로 out_node를 생성합니다.
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                out_node.AddString("LOT_ID", "L16050500001");               
                out_node.AddString("CODE", "Sample Data Code");
                out_node.AddString("NAME", "Lot");
                out_node.AddString("DESC", "Sample Lot");
                out_node.AddInt("SEQ", 1001);
                out_node.AddString("DATE_TIME", "20160101100530");
                TRSNode listNode;
                for (int i = 0; i < 10; i++)
                {
                    listNode = out_node.AddNode("DATA_LIST");

                    listNode.AddString("CODE", "CODE" + i.ToString());
                    listNode.AddDouble("QTY", (i * 1000));
                }
                TRSNode listNode2;
                for (int i = 0; i < 10; i++)
                {
                    listNode2 = out_node.AddNode("DATA_HORIZON_LIST");

                    listNode2.AddString("CODE", "CODE" + i.ToString());
                    listNode2.AddDouble("QTY", (i * 1000));
                }
                TRSNode listNode3;
                for (int i = 0; i < 2; i++)
                {
                    listNode3 = out_node.AddNode("DATA_DTMX_LIST");

                    listNode3.AddString("CODE", "CODE" + i.ToString());
                    listNode3.AddDouble("QTY", (i * 1000));
                }

                // 2. Data Mapping
                if(udcScreenRule.SetDataToScreen(out_node) == false)
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
