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

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSModulePackingAuto : SOIBaseForm02
    {

        delegate void SetMessageDelegate(TRSNode node);
        private SetMessageDelegate _SetMessageDelegate;

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string strGrade;
        private string strPower;
        private string strMaterial;

        //Pack H/V Check
        private string packHv;

        //private bool strPermit = false;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private MenuInfoTag menuInfo;

        #endregion

        #region Constructor

        public frmCUSModulePackingAuto()
        {
            InitializeComponent();

            //Load += new EventHandler(frmTempSOIBaseForm02_Load);
            _SetMessageDelegate = new SetMessageDelegate(SetMessage);
        }

        #endregion

        #region [Constant Definition]

        const int ENTER = 13;

        public enum LOT_LIST
        {
            NO,
            MODULE_ID,
            GRADE,
            POWER,
            MAT_ID,
            MAT_DESC,
            RES_ID,
            //WORK_SHIFT,
            PACK_HV
        }

        public enum PRINT_LIST
        {
            SEQ,
            ARTICLE_NO,
            BATCH_NO,
            PRODUCT,
            TYPE,
            BARCODE
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.

            // Menu 정보 로드
            menuInfo = (MenuInfoTag)this.Tag;

            // Print Option 할당
            if (printOption == null)
            {
                printOption = new PrintOptionModel();
            }

            // Print Option 정보 호출
            MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
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

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@LINE_CODE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOperID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperID.Text = cdvOperID.Show(cdvOperID, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperID.Text == null || cdvOperID.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEquipID_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("OPER", cdvOperID.Text);

                // Display and Header Text Setup
                string[] header = new string[] { "Equip ID", "Equip Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show CodeView and Get Return
                cdvEquipID.Text = cdvEquipID.Show(cdvEquipID, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                {
                    MPCF.SetFocus(cdvEquipID);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvMatID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(517));
                    MPCF.SetFocus(cdvMatID);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GRADE_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_POWER_RANGE));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMatID.Text));

                string[] header = new string[] { "MAT ID", "GRADE" };
                string[] display = new string[] { "KEY_1", "KEY_2" };

                cdvGrade.Text = cdvGrade.Show(cdvGrade, "Code List", "CBAS", "CBAS_view_Module_grade_list", in_node, "LIST", display, header, "KEY_2");

                // Clear Packing Info
                MPCF.FieldClear(pnlPackingInfo, cdvGrade);
                txtPackingID.Text = string.Empty;

                // Validation
                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    return;
                }

                MPCF.SetFocus(cdvPower);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvPower_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(517));
                    MPCF.SetFocus(cdvMatID);
                    return;
                }

                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(519));
                    MPCF.SetFocus(cdvGrade);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GRADE_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_POWER_RANGE));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMatID.Text));
                in_node.AddString("KEY_2", MPCF.Trim(cdvGrade.Text));

                string[] header = new string[] { "MAT ID", "POWER" };
                string[] display = new string[] { "KEY_1", "KEY_2" };

                cdvPower.Text = cdvPower.Show(cdvPower, "Code List", "CBAS", "CBAS_view_Module_grade_list", in_node, "LIST", display, header, "KEY_2");

                // Validation
                if (string.IsNullOrEmpty(cdvPower.Text) == true)
                {
                    return;
                }

                if (!ViewArticleInfo())
                    return;

                if (!ViewPackingInfo())
                    return;

                getPalletId();
                MPCF.SetFocus(cdvModuleType);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvModuleType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_PACKING_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_PACKING));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMatID.Text));

                string[] header = new string[] { "Module Type", "Barcode", "MODULE_QTY", "PACK_TYPE" };
                string[] display = new string[] {"KEY_2", "DATA_2", "DATA_9", "DATA_10" };

                cdvModuleType.Text = cdvModuleType.Show(cdvModuleType, "Packing Master List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                // Validation
                if (string.IsNullOrEmpty(cdvModuleType.Text) == true)
                {
                    return;
                }

                if (!ViewPackingInfo())
                    return;

                MPCF.SetFocus(txtPackingID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void txtPackingID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtPackingID.Text) != "")
            {
                txtPackingID.Text = MPCF.ToUpper(txtPackingID.Text); // 일괄 대문자

                if (e.KeyChar == (char)13)
                {
                    if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(517), MSG_LEVEL.ERROR, false);
                        MPCF.SetFocus(txtPackingID);
                        return;
                    }

                    //MPCF.ClearList(spdLotList);

                    txtModuleID.Focus();
                    txtModuleID.SelectAll();

                }

            }
        }

        private void txtModuleID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (!CheckCondition("VIEW"))
                        return;

                    //if (txtCount.Text == txtLimitCount.Text)
                    //{
                    //    MPCF.ShowMessage(MPCF.GetMessage(502), MSG_LEVEL.ERROR, false);
                    //    return;
                    //}

                    if (ViewFQCInfo(txtModuleID.Text))
                    {
                        //if (CheckSpec() == false)
                        //{
                        //    //MPCF.SetFocus(txtModuleID);
                        //    txtModuleID.SelectAll();
                        //    return;
                        //}
                    }
                    else
                    {
                        //MPCF.SetFocus(txtModuleID);
                        txtModuleID.SelectAll();
                        return;
                    }

                    ModuleListAdd(txtModuleID.Text);
                    if (spdLotList.ActiveSheet.ActiveRowIndex == 0)
                    {
                        getPalletId();
                    }

                    /*
                    if (strPermit == true)
                    {
                        ModuleListAdd(txtModuleID.Text);
                        if (spdLotList.ActiveSheet.ActiveRowIndex == 0)
                        {
                            getPalletId();
                        }
                        
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                cdvMatID.Text = cdvMatID.Show(cdvMatID, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");

                if (cdvMatID == null || cdvMatID.Text == string.Empty)
                {
                    return;
                }

                // View Lot
                if (ViewMatInfo(cdvMatID.Text) == false)
                {
                    cdvMatID.SelectAll();
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", "P");  // 완제품

                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                cdvMatID.Text = cdvMatID.Show(cdvMatID, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");

                if (cdvMatID == null || cdvMatID.Text == string.Empty)
                {
                    return;
                }

                // View Lot
                if (ViewMatInfo(cdvMatID.Text) == false)
                {
                    cdvMatID.SelectAll();
                    return;
                }

                if (ViewArticleInfo(cdvMatID.Text) == false)
                {
                    cdvMatID.SelectAll();
                    return;
                }

                SetArticleNoVisible(cdvMatID.Text, "", ""); 

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Pack_Lot_Input() == true)
            {
                MPCF.ClearList(spdLotList);
                procprint_v1(); // 자동프린터 기능
                txtPackingID.Text = string.Empty;
                txtModuleID.Text = string.Empty;
                txtCount.Text = "0";
                txtLimitCount.Text = "0";
                MPCF.SetFocus(txtPackingID);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtPackingID.Text = string.Empty;
            txtModuleID.Text = string.Empty;
            MPCF.SetFocus(txtPackingID);

        }

        private void btnGenLotID_Click(object sender, EventArgs e)
        {
            getPalletId();
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdLotList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowErrorMessage(MPCF.GetMessage(525));
                    return;
                }

                spdLotList.ActiveSheet.Rows.Remove(spdLotList.ActiveSheet.ActiveRowIndex, 1);

                int iRowCount = spdLotList.ActiveSheet.RowCount;

                for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
                    iRowCount--;
                }

                txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        private void cdvWorkShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@SHIFT");

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Shift", "Description" };

                cdvWorkShift.Text = cdvWorkShift.Show(cdvWorkShift, "View Shift", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Shift");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkShift.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        */

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion // End of Event Handler


        #region Function

        // SetMessageEvent()
        //       - Set Message Event
        // Return Value
        //       - 
        // Arguments
        //        -  ByVal in_node As TRSNode : in node
        //
        public void SetMessageEvent(TRSNode in_node)
        {
            try
            {
                IAsyncResult r = BeginInvoke(_SetMessageDelegate, new object[] { in_node });
                EndInvoke(r);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        // SetMessage()
        //       - Set Message
        // Return Value
        //       - 
        // Arguments
        //        -  ByVal in_node As TRSNode : node
        //
        private void SetMessage(TRSNode node)
        {
            try
            {
                ///Publish Line Code와 조회 Line Code가 다른경우 Publish Data를 받지 않는다.
                //if (MPCF.Trim(cdvLine.Text) != node.GetString("LINE_CODE"))
                //{
                //    return;
                //}

                if (MPCF.Trim(node.GetString("IN_SERVICE_NAME")) == "EAPMES_Complete_Packing")
                {

                    //if (MPCF.Trim(node.GetChar("STATUSVALUE").ToString()) != "0")
                    //{
                    //    MPCF.ShowMsgBox(node.Msg);
                    //    return;
                    //}
                    int i;
                    spdLotList.ActiveSheet.RowCount = 0;
                    for (i = 0; i < node.GetList(0).Count; i++)
                    {
                        if (i == 0)
                        {

                            //아티클 번호 숨김처리
                            SetArticleNoVisible(MPCF.Trim(node.GetList(0)[0].GetString("MAT_ID").ToString()),
                            MPCF.Trim(node.GetList(0)[0].GetString("ARTICLE_NO").ToString()),
                            MPCF.Trim(node.GetList(0)[0].GetString("ARTICLE_DESC").ToString()));
                            //아티클 번호 숨김처리

                            cdvLineID.Text = MPCF.Trim(node.GetList(0)[0].GetString("LINE_ID").ToString());
                            cdvOperID.Text = MPCF.Trim(node.GetList(0)[0].GetString("OPER").ToString());
                            cdvEquipID.Text = MPCF.Trim(node.GetList(0)[0].GetString("RES_ID").ToString());
                            cdvMatID.Text = MPCF.Trim(node.GetList(0)[0].GetString("MAT_ID").ToString());
                            txtMatDesc.Text = MPCF.Trim(node.GetList(0)[0].GetString("MAT_DESC").ToString());
                            cdvGrade.Text = MPCF.Trim(node.GetList(0)[0].GetString("GRADE").ToString());
                            cdvPower.Text = MPCF.Trim(node.GetList(0)[0].GetString("POWER").ToString());
                            cdvModuleType.Text = MPCF.Trim(node.GetList(0)[0].GetString("MODULE_TYPE").ToString());
                            txtArticleNo.Text = MPCF.Trim(node.GetList(0)[0].GetString("ARTICLE_NO").ToString());
                            txtArticleDesc.Text = MPCF.Trim(node.GetList(0)[0].GetString("ARTICLE_DESC").ToString());
                            txtBarcode.Text = MPCF.Trim(node.GetList(0)[0].GetString("BARCODE").ToString());

                            //if (isNewMaterialID(MPCF.Trim(node.GetList(0)[0].GetString("MAT_ID").ToString())))
                            //{
                            //    txtPowerClass.Text = MPCF.Trim(node.GetList(0)[0].GetString("POWER_CLASS").ToString()) + " " + MPCF.Trim(node.GetList(0)[0].GetString("POWER").ToString()); 
                            //}
                            //else
                            //{
                            txtPowerClass.Text = MPCF.Trim(node.GetList(0)[0].GetString("POWER_CLASS").ToString());
                            //}

                            spdLotList.ActiveSheet.AddRows(0, 1);
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MODULE_ID].Value = MPCF.Trim(node.GetList(0)[0].GetString("LOT_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.GRADE].Value = MPCF.Trim(node.GetList(0)[0].GetString("GRADE").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.POWER].Value = MPCF.Trim(node.GetList(0)[0].GetString("POWER").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = MPCF.Trim(node.GetList(0)[0].GetString("MAT_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = MPCF.Trim(node.GetList(0)[0].GetString("MAT_DESC").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.RES_ID].Value = MPCF.Trim(node.GetList(0)[0].GetString("RES_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_HV].Value = MPCF.Trim(node.GetList(0)[0].GetString("CMF_5").ToString());

                            packHv = MPCF.Trim(node.GetList(0)[0].GetString("CMF_5").ToString());
                            //spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.WORK_SHIFT].Value = cdvWorkShift.Text;

                            txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();

                            txtLimitCount.Text = MPCF.Trim(node.GetList(0)[0].GetInt("MODUL_QTY").ToString());
                        }
                        else
                        {   //아티클 번호 숨김처리
                            SetArticleNoVisible(MPCF.Trim(node.GetList(0)[i].GetString("MAT_ID").ToString()),
                            MPCF.Trim(node.GetList(0)[i].GetString("ARTICLE_NO").ToString()),
                            MPCF.Trim(node.GetList(0)[i].GetString("ARTICLE_DESC").ToString()));
                            //아티클 번호 숨김처리
                            spdLotList.ActiveSheet.AddRows(0, 1);
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MODULE_ID].Value = MPCF.Trim(node.GetList(0)[i].GetString("LOT_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.GRADE].Value = MPCF.Trim(node.GetList(0)[i].GetString("GRADE").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.POWER].Value = MPCF.Trim(node.GetList(0)[i].GetString("POWER").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = MPCF.Trim(node.GetList(0)[i].GetString("MAT_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = MPCF.Trim(node.GetList(0)[i].GetString("MAT_DESC").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.RES_ID].Value = MPCF.Trim(node.GetList(0)[i].GetString("RES_ID").ToString());
                            spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_HV].Value = MPCF.Trim(node.GetList(0)[i].GetString("CMF_5").ToString());
                            //spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.WORK_SHIFT].Value = cdvWorkShift.Text;

                            txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();
                        }
                    }


                    getPalletId();

                    btnProcess.PerformClick();

                }

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

                        // Check Product ID
                        if (string.IsNullOrEmpty(cdvMatID.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(517)); // Please select a Product.
                            MPCF.SetFocus(cdvMatID);
                            return false;
                        }

                        // Check Grade
                        if (string.IsNullOrEmpty(cdvGrade.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(519)); // Please select a Grade.
                            MPCF.SetFocus(cdvGrade);
                            return false;
                        }

                        // Check Power
                        if (string.IsNullOrEmpty(cdvPower.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(520)); // Please select a Power.
                            MPCF.SetFocus(cdvPower);
                            return false;
                        }

                        // Check whether the module ID was already added to the list or not
                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtModuleID.Text == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MODULE_ID].Text)
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(518), MSG_LEVEL.ERROR, false); // The module ID was already added to the list.

                                //txtModuleID.Text = "";
                                txtModuleID.SelectAll();
                                return false;
                            }
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtPackingID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(526));
                            MPCF.SetFocus(txtPackingID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvModuleType.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(540));
                            MPCF.SetFocus(cdvModuleType);
                            return false;
                        }

                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(527), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtModuleID);
                            return false;
                        }

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
 
        private bool ViewFQCInfo(string sLotID)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_FQC_IN");
                TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

                strGrade = "";
                strPower = "";
                strMaterial = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", "FC");
                in_node.AddString("LOT_ID", sLotID);

                //PACKING VALIDATION 용으로 호출되었다는 표시 
                //서버에서 체크하기 위해 값을 넣음

                in_node.AddString("IN_POWER", cdvPower.Text);
                in_node.AddString("IN_GRADE", cdvGrade.Text);
                in_node.AddString("IN_MAT_ID", cdvMatID.Text);
                in_node.AddString("IN_MODULETYPE", cdvModuleType.Text);
                in_node.AddString("IN_ARTICLE", txtArticleNo.Text);

                in_node.AddChar("PACK_VALIDATE_FLAG", 'Y');
                in_node.AddString("PALLET_ID", txtPackingID.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node, false) == false)
                {
                    MPCF.ShowMsgBox(out_node.Msg);
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                strGrade = out_node.GetString("GRADE");
                strPower = out_node.GetString("POWER");

                //필요한 정보있음..CWIP_View_Fqc_Result 에서 가져오면될듯한데....
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                strMaterial = out_node.GetString("MAT_ID");

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewArticleInfo()
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_FQC_IN");
                TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_ARTICLE));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMatID.Text));
                in_node.AddString("DATA_1", MPCF.Trim(cdvPower.Text));
                in_node.AddString("DATA_2", MPCF.Trim(cdvGrade.Text));

                if (MPCF.CallService("CBAS", "CBAS_view_article_list", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(528), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    return false;
                }

                txtArticleNo.Text = out_node.GetString("KEY_2");
                cdvModuleType.Text = out_node.GetString("DATA_3");
                txtArticleDesc.Text = out_node.GetString("DATA_4");
                txtPowerClass.Text = out_node.GetString("DATA_5");

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewPackingInfo()
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_PACKING_IN");
                TRSNode out_node = new TRSNode("VIEW_PACKING_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_PACKING));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMatID.Text));
                in_node.AddString("KEY_2", MPCF.Trim(cdvModuleType.Text));

                if (MPCF.CallService("CBAS", "CBAS_View_Data", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(529), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    return false;
                }

                txtBarcode.Text = this.SetBarcodeGrade(out_node.GetString("DATA_2"), this.cdvGrade.Value, this.cdvPower.Value);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool CheckSpec()
        {
            try
            {
                if (strGrade == cdvGrade.Text && strPower == cdvPower.Text && strMaterial == cdvMatID.Text)
                {
                    return true;
                }
                else
                {
                    /****
                     * 1)    포장 시 A급, B급, C급, Scrap 등 전 모듈 등급 혼류 불가
                       2)    A급의 경우, 동일 제품(제품군 아님) 동일 PowerClass 만 포장 가능
                       3)    B급의 경우, 동일 제품군(제품 아님) 동일 PowerClass 만 포장 가능
                       4)    C급, Scrap의 경우, 동일 제품군(제품 아님) 중 서로 다른 PowerClass도 포장 가능
                       5)    C급, Scrap의 경우, Pallet No.는 처음 스캔한 모듈의 정보를 바탕으로 채번됨
                   ****/

                    if ((cdvGrade.Text == "C") || (cdvGrade.Text == "G06"))
                    {
                        /** C, SCRAP **/
                        if (strGrade != cdvGrade.Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(521));
                        }
                        else if (strPower != cdvPower.Text)
                        {
                            //MPCF.ShowMsgBox(MPCF.GetMessage(522));
                            //파워는 허용함.
                            return true;
                        }
                        if (strMaterial != cdvMatID.Text)
                        {
                            //품번은 제품군으로 바뀌어야함. 코딩아침에 할것. : 일단 허용함
                            //MPCF.ShowMsgBox(MPCF.GetMessage(523));
                            return true;
                        }
                    }
                    else if (cdvGrade.Text == "B") 
                    {
                        if (strGrade != cdvGrade.Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(521));
                        }
                        else if (strPower != cdvPower.Text)
                        {
                            //MPCF.ShowMsgBox(MPCF.GetMessage(522));
                            return true;
                        }
                        if (strMaterial != cdvMatID.Text)
                        {
                            //품번은 제품군으로 바뀌어야함. 코딩아침에 할것. : 일단 허용안함.
                            //MPCF.ShowMsgBox(MPCF.GetMessage(523));
                            return true;
                            
                        }
                    } else
                    {
                        if (strGrade != cdvGrade.Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(521));
                        }
                        else if (strPower != cdvPower.Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(522));
                        }
                        if (strMaterial != cdvMatID.Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(523));
                        }
                    }
                    

                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ModuleListAdd(string sLotID)
        {
            try
            {
                spdLotList.ActiveSheet.AddRows(0, 1);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MODULE_ID].Value = txtModuleID.Text;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.GRADE].Value = strGrade;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.POWER].Value = strPower;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = cdvMatID.Text;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = txtMatDesc.Text;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.RES_ID].Value = cdvEquipID.Text;
                //spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.WORK_SHIFT].Value = cdvWorkShift.Text;

                txtCount.Text = spdLotList.ActiveSheet.RowCount.ToString();

                txtModuleID.Text = string.Empty;
                MPCF.SetFocus(txtModuleID);

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewMatInfo(string sMatId)
        {
            TRSNode in_node = new TRSNode("VIEW_METERIAL_IN");
            TRSNode out_node1 = new TRSNode("VIEW_METERIAL_OUT");

            try
            {
                // FieldClear

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", MPCF.Trim(sMatId));
                in_node.AddInt("MAT_VER", 1);

                if (MPCF.CallService("WIP", "WIP_View_Material", in_node, ref out_node1) == false)
                {
                    return false;
                }

                txtMatDesc.Text = out_node1.GetString("MAT_DESC");
                if (isNewMaterialID(MPCF.Trim(sMatId)))
                {
                    cdvModuleType.Text = out_node1.GetString("MAT_SHORT_DESC");
                    txtPowerClass.Text = out_node1.GetString("MAT_SHORT_DESC") + " " + strPower;
                }
                
                //txtLimitCount.Text = out_node1.GetInt("PACK_LOT_COUNT").ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewArticleInfo(string sMatId)
        {
            TRSNode in_node = new TRSNode("VIEW_METERIAL_IN");
            TRSNode out_node1 = new TRSNode("VIEW_METERIAL_OUT");

            try
            {
                // FieldClear

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@ARTICLE");
                in_node.AddString("KEY_1", MPCF.Trim(sMatId));

                if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node1) == false)
                {
                    return false;
                }

                txtArticleNo.Text = out_node1.GetString("DATA_1");
                txtArticleDesc.Text = out_node1.GetString("DATA_3"); 
                cdvModuleType.Text = out_node1.GetString("DATA_2");
                cdvPower.Text = out_node1.GetString("DATA_4");
                txtPowerClass.Text = out_node1.GetString("DATA_5");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool Tran_Pack_Lot_Input()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                for (int k = spdLotList.ActiveSheet.RowCount - 1; k > -1; k--)
                {

                    //CIM -> EAP 로 받은 Pack H/V(수평/수직)정보 Validation Check. START.

                    /*
                    if (string.IsNullOrEmpty(MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value)))
                    {
                        MPCF.ShowMsgBox("Pack H / V 값이 없습니다.");
                        //MPCF.ShowMessage(MPCF.GetMessage(515), MSG_LEVEL.INFO, false);
                        return false;
                    }
                    
                    if (k == 0)
                    {
                        packHv = MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value);
                    }
                    else
                    {
                        if(packHv != MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value)){
                            MPCF.ShowMsgBox("Pack H / V 값이 이전 값과 다릅니다.");
                            return false;
                        }
                        packHv = MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value);
                    }
                     */
                    //CIM -> EAP 로 받은 Pack H/V(수평/수직)정보 Validation Check. END.

                    in_node.AddString("OPER", cdvOperID.Text);
                    in_node.AddString("LINE_ID", cdvLineID.Text);
                    in_node.AddString("RES_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.RES_ID].Value));
                    in_node.AddString("MAT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value));
                    in_node.AddString("PALLET_ID", txtPackingID.Text);
                    in_node.AddString("IN_POWER", cdvPower.Text);
                    in_node.AddString("IN_GRADE", cdvGrade.Text);
                    in_node.AddString("IN_MAT_ID", cdvMatID.Text);
                    in_node.AddString("IN_MODULETYPE", cdvModuleType.Text);
                    in_node.AddInt("PACK_QTY", txtLimitCount.Text);

                    list_item = in_node.AddNode("MODULE_PACK_LIST");
                    list_item.AddString("PALLET_ID", txtPackingID.Text);
                    list_item.AddInt("PAK_SEQ", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.NO].Value));
                    list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MODULE_ID].Value));
                    list_item.AddString("PAK_TYPE", cdvModuleType.Text);
                    list_item.AddString("GRADE", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.GRADE].Value));
                    list_item.AddString("POWER", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.POWER].Value));
                    list_item.AddString("CMF_1", txtArticleNo.Text);
                    list_item.AddString("CMF_2", txtPowerClass.Text);
                    list_item.AddString("CMF_3", textRight(txtPackingID.Text, 4).Replace("_", ""));      //VOC-4910 
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Packing_Module_List", in_node, ref out_node) == false)
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

        private string textRight(string Text, int TextLength)
        {
            string ConvertText;
            if (Text.Length < TextLength)
            {
                TextLength = Text.Length;
            }
            ConvertText = Text.Substring(Text.Length - TextLength, TextLength);
            return ConvertText;
        }

        private bool procprint()
        {
            int i;
            int iRowCount;
            int printCount;
            string sArticleNo;
            string sBatchNo;
            string sPowerClass;
            string sGrade;
            string sBarcode;

            try
            {
                MPCF.ClearList(spdList_Flexible);
                spdList_Flexible.InitFlexibleScreen();
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                in_node.AddString("PALLET_ID", txtPackingID.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Packing_Label_Print", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(530), MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }

                out_node.SetString("PALLET_NO", txtPackingID.Text);
                out_node.SetString("LENGTH", out_node.GetString("LENGTH"));
                out_node.SetString("BREADTH", out_node.GetString("BREADTH"));
                out_node.SetString("HEIGHT", out_node.GetString("HEIGHT"));
                out_node.SetString("GROSS_W", out_node.GetString("GROSS_W"));
                out_node.SetString("NET_W", out_node.GetString("NET_W"));
                out_node.SetString("TARE_W", out_node.GetString("TARE_W"));

                if (out_node.GetList(0).Count > 0)
                {
                    spdList_Flexible.InitFlexibleScreen();
                    spdList_Flexible.ScreenID = "PackingPalletLabel_mod";
                    spdList_Flexible.ScreenSpread.Tag = "PackingPalletLabel_mod";
                    spdList_Flexible.ProcStep = '1';
                    spdList_Flexible.LotID = "PackingPalletLabel_mod";

                    iRowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sArticleNo = String.Format("ARTICLE_NO_{0}", i + 1);
                        out_node.SetString(sArticleNo, out_node.GetList(0)[i].GetString("ARTICLE_NO"));

                        sBatchNo = String.Format("BATCH_NO_{0}", i + 1);
                        out_node.SetString(sBatchNo, out_node.GetList(0)[i].GetString("BATCH_NO"));

                        sPowerClass = String.Format("PRODUCT_{0}", i + 1);
                        out_node.SetString(sPowerClass, out_node.GetList(0)[i].GetString("POWER_CLASS"));

                        sGrade = String.Format("TYPE_{0}", i + 1);
                        out_node.SetString(sGrade, out_node.GetList(0)[i].GetChar("GRADE"));

                        sBarcode = String.Format("BARCODE_{0}", i + 1);
                        out_node.SetString(sBarcode, out_node.GetList(0)[i].GetString("MODULE_ID"));
                    }

                    if (spdList_Flexible.SetDataToScreen(out_node) == false)
                    {
                        return false;
                    }
                }
                if (printOption == null)
                {
                    MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);
                }
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(515), MSG_LEVEL.INFO, false);
                    return false;
                }
                else
                {
                    if (packHv == "H")
                    {
                        for (int z = 0; z < 1; z++) // 수평 1장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    }
                    else
                    {
                        for (int z = 0; z < 3; z++) // 수직 3장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        //신규자재코드에 따른 출력양식 변경(2023/04/14, KBC)
        private bool procprint_v1()
        {
            int i;
            int iRowCount;
            int printCount;
            bool isGradeA;
            string sArticleNo;
            string sBatchNo;
            string sPowerClass;
            string sGrade;
            string sBarcode;
            string sBarcodeID;
            string sMatID;
            string grade = cdvGrade.Text;
            string reportID;

            try
            {
                if (cdvGrade.Text == null ||
                    cdvGrade.Text.Length <= 0)
                {
                    MPCF.ShowMessage("There is no material code or grade.", MSG_LEVEL.INFO, false);
                    return false;
                }

                reportID = GetReportID(cdvMatID.Text, cdvGrade.Text);

                MPCF.ClearList(spdList_Flexible);
                spdList_Flexible.InitFlexibleScreen();
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                in_node.AddString("PALLET_ID", txtPackingID.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Packing_Label_Print_V1", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(530), MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }

                out_node.SetString("PALLET_NO", txtPackingID.Text);
                out_node.SetString("LENGTH", out_node.GetString("LENGTH"));
                out_node.SetString("BREADTH", out_node.GetString("BREADTH"));
                out_node.SetString("HEIGHT", out_node.GetString("HEIGHT"));
                out_node.SetString("GROSS_W", out_node.GetString("GROSS_W"));
                out_node.SetString("NET_W", out_node.GetString("NET_W"));
                out_node.SetString("TARE_W", out_node.GetString("TARE_W"));

                out_node.SetString("LENGTH_INCH", out_node.GetString("LENGTH_INCH"));
                out_node.SetString("BREADTH_INCH", out_node.GetString("BREADTH_INCH"));
                out_node.SetString("HEIGHT_INCH", out_node.GetString("HEIGHT_INCH"));
                out_node.SetString("GROSS_WEIGHT_LB", out_node.GetString("GROSS_WEIGHT_LB"));
                out_node.SetString("NET_WEIGHT_LB", out_node.GetString("NET_WEIGHT_LB"));
                out_node.SetString("TARE_WEIGHT_LB", out_node.GetString("TARE_WEIGHT_LB"));

                if (out_node.GetList(0).Count > 0)
                {
                    spdList_Flexible.InitFlexibleScreen();
                    spdList_Flexible.ScreenID = reportID;
                    spdList_Flexible.ScreenSpread.Tag = reportID;
                    spdList_Flexible.ProcStep = '1';
                    spdList_Flexible.LotID = reportID;

                    iRowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sArticleNo = String.Format("ARTICLE_NO_{0}", i + 1);
                        out_node.SetString(sArticleNo, out_node.GetList(0)[i].GetString("ARTICLE_NO"));

                        sBatchNo = String.Format("BATCH_NO_{0}", i + 1);
                        out_node.SetString(sBatchNo, out_node.GetList(0)[i].GetString("BATCH_NO"));

                        sPowerClass = String.Format("PRODUCT_{0}", i + 1);
                        out_node.SetString(sPowerClass, out_node.GetList(0)[i].GetString("POWER_CLASS"));

                        sGrade = String.Format("TYPE_{0}", i + 1);
                        out_node.SetString(sGrade, out_node.GetList(0)[i].GetChar("GRADE"));

                        sBarcodeID = String.Format("BARCODE_ID_{0}", i + 1);
                        out_node.SetString(sBarcodeID, out_node.GetString("BARCODE_ID"));
                    
                        sBarcode = String.Format("BARCODE_{0}", i + 1);
                        out_node.SetString(sBarcode, out_node.GetList(0)[i].GetString("MODULE_ID"));

                        sMatID = String.Format("MAT_ID_{0}", i + 1);
                        out_node.SetString(sMatID, out_node.GetString("MAT_ID"));

                        //06.14일 수정(등급외인경우 처리추가)
                        isGradeA = (grade == "G03" || grade == "G04" || grade == "G01" || grade == "G02" || grade == "A" ? true : false);    //--[G03/G04 로직 추가]


                        sMatID = String.Format("MAT_ID_{0}", i + 1);
                        if (grade == "C")
                        {
                            out_node.SetString(sMatID, out_node.GetList(0)[i].GetString("ZMDL"));
                        }
                        else
                        {
                            out_node.SetString(sMatID, out_node.GetString("MAT_ID"));
                        }
                    }

                    if (spdList_Flexible.SetDataToScreen(out_node) == false)
                    {
                        return false;
                    }
                }
                if (printOption == null)
                {
                    MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);
                }
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(515), MSG_LEVEL.INFO, false);
                    return false;
                }
                else
                {
                    if (packHv == "H")
                    {
                        for (int z = 0; z < 1; z++) // 수평 1장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    }
                    else
                    {
                        for (int z = 0; z < 3; z++) // 수직 3장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool getDbSystime(out string systime)
        {
            systime = string.Empty;
            //DB 시간 가져오기
            TRSNode in_node = new TRSNode("SYSTIME_IN");
            TRSNode out_node = new TRSNode("SYSTIME_OUT");
            if (MPCF.CallService("CWIP", "CWIP_Get_Db_Systime", in_node, ref out_node) == false)
            {
                if (out_node.GetList(0) == null)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(531), MSG_LEVEL.ERROR, false);
                    return false;
                }
                return false;
            }
            systime = out_node.GetString("SYSTIME");
            return true;
        }


        private void getPalletId()
        {
            txtPackingID.Text = "";

            string systime;
            if (false == getDbSystime(out systime))
                return;

            StringBuilder pallet_id = new StringBuilder(systime.Substring(2, 6));
            pallet_id.Append("_E1_");
            if (String.IsNullOrEmpty(txtBarcode.Text))
            {
                MPCF.ShowMessage(MPCF.GetMessage(508), MSG_LEVEL.INFO, false);
                return;
            }

            if (String.IsNullOrEmpty(cdvPower.Text))
            {
                MPCF.ShowMessage(MPCF.GetMessage(509), MSG_LEVEL.INFO, false);
                return;
            }

            if (String.IsNullOrEmpty(cdvGrade.Text))
            {
                MPCF.ShowMessage(MPCF.GetMessage(510), MSG_LEVEL.INFO, false);
                return;
            }

            if (cdvGrade.Text == "G01")
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + "A_");
            }
            else if (cdvGrade.Text == "G02")
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + "A_");
            }
            else if (cdvGrade.Text == "G03")        //--[G03/G04 로직 추가]
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + "A_");
            }
            else if (cdvGrade.Text == "G04")        //--[G03/G04 로직 추가]
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + "A_");
            }
            else if (cdvGrade.Text == "G06")
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + "Z_");
            }
            else
            {
                pallet_id.Append(txtBarcode.Text + "_" + cdvPower.Text + cdvGrade.Text + "_");
            }

            // 금일 MAX채번가져오기
            TRSNode in_node = new TRSNode("VIEW_SEQ_IN");
            TRSNode out_node = new TRSNode("VIEW_SEQ_OUT");

            MPCF.SetInMsg(in_node);
            in_node.AddString("PALLET_ID_SUB", pallet_id);

            if (MPCF.CallService("CWIP", "CWIP_View_Pallet_Current_Seq", in_node, ref out_node) == false)
            {
                if (out_node.GetList(0) == null)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(531), MSG_LEVEL.ERROR, false);
                    return;
                }
                return;
            }

            if (cdvGrade.Text == "G01" || cdvGrade.Text == "B" || cdvGrade.Text == "G02" || cdvGrade.Text == "G03" || cdvGrade.Text == "G04")   //--[G03/G04 로직 추가]
            {
                txtPackingID.Text = out_node.GetString("PALLET_ID");
            }
            else if (cdvGrade.Text == "C" || cdvGrade.Text == "G06")
            {
                //if (strGrade != null && strGrade == cdvGrade.Text)
                //{
                //    txtPackingID.Text = out_node.GetString("PALLET_ID");
                //}
                txtPackingID.Text = out_node.GetString("PALLET_ID");
            }

        }

        private bool isNewMaterialID(String matId)
        {
            double result;

            if (matId.Length > 0 &&
                double.TryParse(matId.TrimStart('0'), out result) == false)
            {

                return true;
            }

            return false;
        }

        private void SetArticleNoVisible(String matID, String articleNo, String articleDesc)
        {
            if (isNewMaterialID(matID) == true)
            {
                soiTableLayoutPanel5.Visible = false;
            }
            else
            {
                soiTableLayoutPanel5.Visible = true;

                txtArticleNo.Text = MPCF.Trim(articleNo);
                txtArticleDesc.Text = MPCF.Trim(articleDesc);
            }
        }

        private String SetBarcodeGrade(String barcode, String grade, String power)
        {
            int i_power;
            char[] barcodeChars = barcode.ToCharArray();
            if (barcode.Length != 6)
            {
                return barcode;
            }

            if (int.TryParse(power, out i_power) == false)
            {
                return barcode;
            }

            if (grade.CompareTo("G01") == 0)
            {
                barcodeChars[4] = '1';
            }
            else if (grade.CompareTo("G02") == 0)
            {
                barcodeChars[4] = '5';
            }
            else if (grade.CompareTo("G03") == 0)   //--[G03/G04 로직 추가]
            {
                barcodeChars[4] = '6';
            }
            else if (grade.CompareTo("G04") == 0)   //--[G03/G04 로직 추가]
            {
                barcodeChars[4] = '0';
            }
            else if (grade.CompareTo("B") == 0)
            {
                if (i_power < 200)
                {
                    barcodeChars[4] = '7';
                }
                else
                {
                    barcodeChars[4] = '2';
                }
            }
            else if (grade.CompareTo("C") == 0)
            {
                if (i_power < 200)
                {
                    barcodeChars[4] = '8';
                }
                else
                {
                    barcodeChars[4] = '3';
                }
            }
            else
            {
                if (i_power < 200)
                {
                    barcodeChars[4] = '9';
                }
                else
                {
                    barcodeChars[4] = '4';
                }
            }

            return new String(barcodeChars);
        }

        private String GetReportID(String matID, String grade)
        {
            string reportID = "";

            bool isGradeA = (grade == "G03" || grade == "G04" || grade == "G01" || grade == "G02" || grade == "A" ? true : false);      //--[G03/G04 로직 추가]


            if (isNewMaterialID(matID) == true)
            {
                reportID = isGradeA ? "PalletNote_V2_2" : "PalletNote_V2_1";
                if (packHv == "H")
                {
                    reportID = isGradeA ? "PalletNote_V2_4" : "PalletNote_V2_3";
                }
            }
            else
            {
                reportID = isGradeA ? "PalletNote_V1_2" : "PalletNote_V1_1";
            }

            return reportID;
        }

        #endregion // End of Function
    }
}
