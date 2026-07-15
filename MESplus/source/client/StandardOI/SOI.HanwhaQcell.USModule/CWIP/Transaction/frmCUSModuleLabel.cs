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
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSModuleLabel : SOIBaseForm03
    {
        #region Property

        private bool bIsShown = false;
        public string v_lot_id = string.Empty;
        public string lotId = string.Empty;
        public string pmpp = string.Empty;
        public string isc = string.Empty;
        public string voc = string.Empty;
        public string impp = string.Empty;
        public string vmpp = string.Empty;
        public string vsys = string.Empty;
        public string kglbs = string.Empty;
        public string kglbs1 = string.Empty;
        public string kglbs2 = string.Empty;
        public string i_grade = string.Empty;

        #endregion

        #region Variable Definition

        private frmPrintOptionPopup frmOption;

        #endregion

        #region Constructor

        public frmCUSModuleLabel()
        {
            InitializeComponent();
        }

        #endregion

        #region Constant Definition

        public enum MODULE_LIST
        {
            NO,
            PRODUCT,
            GRADE,
            PMPP,
            ISC,
            VOC,
            IMPP,
            VMPP,
            VSYS_UL,
            VSYS_LL,
            KGLBS,
            BSTC_PMPP,
            BSTC_ISC,
            BSTC_VOC,
            BSTC_IMPP,
            BSTC_VMPP,
        }

        #endregion

        #region Event Handler

        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

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

        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    v_lot_id = txtLotId.Text;
                    //ModuleListAdd(txtLotId.Text);
                    if (ModuleListAdd(txtLotId.Text))
                    {
                        UpdatePrintHistory(txtLotId.Text);
                    }

                    MPCF.SetFocus(txtLotId);
                    txtLotId.SelectAll();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear
            MPCF.ClearList(spdList);
            spdList_Flexible.InitFlexibleScreen();
            txtLotId.Text = "";
            MPCF.SetFocus(txtLotId);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // process
            // ModuleLabel
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print
            try
            {
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == false)
                {
                    if (spdList.ActiveSheet.RowCount > 0)
                    {
                        MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                        MPCF.SetFocus(txtLotId);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

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
            //            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion

        #region Function

        private bool ModuleListAdd(string ModuleID)
        {
            try
            {
                MPCF.ClearList(spdList);
                TRSNode grade_in_node = new TRSNode("GRADE_IN");
                TRSNode grade_out_node = new TRSNode("GRADE_OUT");

                MPCF.SetInMsg(grade_in_node);
                grade_in_node.ProcStep = '1';
                grade_in_node.AddString("LOT_ID", ModuleID);
                i_grade = grade_out_node.GetString("GRADE");

                if (MPCF.CallService("CWIP", "CWIP_View_Grade", grade_in_node, ref grade_out_node) == false)
                {
                    MPCF.ShowMsgBox(grade_out_node.Msg);
                    return false;
                }

                spdList.ActiveSheet.AddRows(0, 1);
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.NO].Value = 1;
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.PRODUCT].Value = grade_out_node.GetString("PRODUCT_NM");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.GRADE].Value = grade_out_node.GetString("GRADE");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.PMPP].Value = grade_out_node.GetString("PMPP");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.ISC].Value = grade_out_node.GetString("ISC");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VOC].Value = grade_out_node.GetString("VOC");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.IMPP].Value = grade_out_node.GetString("IMPP");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VMPP].Value = grade_out_node.GetString("VMPP");
                //spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VSYS].Value = grade_out_node.GetString("VSYS");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VSYS_UL].Value = grade_out_node.GetString("VSYS_UL");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VSYS_LL].Value = grade_out_node.GetString("VSYS_LL");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.KGLBS].Value = grade_out_node.GetString("WEIGHT");

                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.BSTC_PMPP].Value = grade_out_node.GetString("BSTC_PMPP");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.BSTC_ISC].Value = grade_out_node.GetString("BSTC_ISC");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.BSTC_VOC].Value = grade_out_node.GetString("BSTC_VOC");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.BSTC_IMPP].Value = grade_out_node.GetString("BSTC_IMPP");
                spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.BSTC_VMPP].Value = grade_out_node.GetString("BSTC_VMPP");

                MPCF.FitColumnHeader(spdList);
                ProcPrint(grade_out_node, ModuleID);
                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ProcPrint(TRSNode out_node, string moduleID)
        {
            try
            {

                spdList_Flexible.InitFlexibleScreen();

                string labelID = string.Empty;
                TRSNode grade_in_node = new TRSNode("GRADE_IN");
                TRSNode grade_out_node = new TRSNode("GRADE_OUT");

                MPCF.SetInMsg(grade_in_node);
                grade_in_node.ProcStep = '1';
                grade_in_node.AddString("LOT_ID", moduleID);
                if (MPCF.CallService("CWIP", "CWIP_View_Grade", grade_in_node, ref grade_out_node) == false)
                {
                    MPCF.ShowMsgBox(grade_out_node.Msg);
                    return false;
                }

                labelID = grade_out_node.GetString("LABEL_ID");
                //labelID = "ModuleLB2_000661200333100007";
                // Assign Label Data to Flexible Screen
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = labelID;
                spdList_Flexible.ScreenSpread.Tag = labelID;
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = labelID;

                //Q.PEAK DUO BLK-G5 290		290		9.61		38.94		9.14		31.71		ModuleLB1_000661200333100007		1000 (UL)		18.7 / 41.2
                //B.LINE PEAK DUO BLK-G5 290		290		9.61		38.94		9.14		31.71		ModuleLB1_000661200333100007		1000 (UL)		18.7 / 41.2		
                //C.LINE PEAK DUO BLK-G5 290		290		9.61		38.94		9.14		31.71		ModuleLB2_000661200333100007		1000		18.7 / 41.2

                //Q.PLUS DUO L-G5.2 350		350		9.78		46.34		9.22		37.96		ModuleLB1_000662100111100007		1500(UL)		23.5 / 51.8
                //B.LINE PLUS DUO L-G5.2 350		350		9.78		46.34		9.22		37.96		ModuleLB1_000662100111100007		1500(UL)		23.5 / 51.8
                //C.LINE PLUS DUO L-G5.2 350		350		9.78		46.34		9.22		37.96		ModuleLB2_000662100111100007		1500		23.5 / 51.8

                if (spdList_Flexible.LoadDesign(labelID) == false)
                {
                    return false;
                }

                out_node.SetString("PRODUCT", grade_out_node.GetString("PRODUCT_NM"));
                out_node.SetString("PMPP", grade_out_node.GetString("PMPP"));
                out_node.SetString("ISC", grade_out_node.GetString("ISC"));
                out_node.SetString("VOC", grade_out_node.GetString("VOC"));
                out_node.SetString("IMPP", grade_out_node.GetString("IMPP"));
                out_node.SetString("VMPP", grade_out_node.GetString("VMPP"));
                out_node.SetString("VSYS_UL", grade_out_node.GetString("VSYS_UL"));
                out_node.SetString("VSYS_LL", grade_out_node.GetString("VSYS_LL"));
                out_node.SetString("KGLBS", grade_out_node.GetString("WEIGHT"));
                out_node.SetString("BARCODE", moduleID);

                //BSTC 값 추가.
                if ("TRUE".Equals(grade_out_node.GetString("BSTC_NOT_NULL")))
                {
                    out_node.SetString("BSTC_PMPP", grade_out_node.GetString("BSTC_PMPP"));
                    out_node.SetString("BSTC_ISC", grade_out_node.GetString("BSTC_ISC"));
                    out_node.SetString("BSTC_VOC", grade_out_node.GetString("BSTC_VOC"));
                    out_node.SetString("BSTC_IMPP", grade_out_node.GetString("BSTC_IMPP"));
                    out_node.SetString("BSTC_VMPP", grade_out_node.GetString("BSTC_VMPP"));
                }

                /*
                out_node.SetString("PRODUCT", "C.LINE PEAK DUO BLK-G5 290");
                out_node.SetString("PMPP", "290");
                out_node.SetString("ISC", "9.61");
                out_node.SetString("VOC", "38.94");
                out_node.SetString("IMPP", "9.14");
                out_node.SetString("VMPP", "31.71");
                out_node.SetString("VSYS_UL", "1000");
                out_node.SetString("VSYS_LL", "");
                out_node.SetString("KGLBS", "18.7 / 41.2");
                out_node.SetString("BARCODE", "203119106500100410");
                */



                if (spdList_Flexible.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == false)
                {
                    if (spdList.ActiveSheet.RowCount > 0)
                    {
                        MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                        MPCF.SetFocus(txtLotId);
                    }
                }
                else
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

        private void UpdatePrintHistory(string ModuleID)
        {
            try
            {
                TRSNode in_node = new TRSNode("PRINT_HISTORY_IN");
                TRSNode out_node = new TRSNode("PRINT_HISTORY_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; /* Power Label */

                in_node.AddString("LOT_ID", ModuleID);

                if (MPCF.CallService("CPOP", "CPOP_Update_Label_Print_History", in_node, ref out_node) == false)
                {
                    return;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            // close
            this.Close();
        }
    }
}