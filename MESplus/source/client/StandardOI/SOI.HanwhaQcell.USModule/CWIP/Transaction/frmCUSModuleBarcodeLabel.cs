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
    public partial class frmCUSModuleBarcodeLabel : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;
        public string v_module_id = string.Empty;

        #endregion

        #region Variable Definition

        private frmPrintOptionPopup frmOption;

        #endregion

        #region Constructor

        public frmCUSModuleBarcodeLabel()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Constant Definition

        public enum MODULE_LIST
        {
            SEQ,
            ARTICLE_NO,
            GR_BATCHNO,
            POWER_CLASS,
            GRADE,
            MODULE_ID
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
                MPCF.SetFocus(txtLotID);
                txtLotID.SelectAll();

                // (Required) 
                bIsShown = true;
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    v_module_id = txtLotID.Text;
                    
                    if (ModuleListAdd(txtLotID.Text))
                    {
                        UpdatePrintHistory(txtLotID.Text);
                        btnPrint.PerformClick();
                    }

                    txtLotID.SelectAll();
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
            spdList_Flexible.InitFlexibleScreen();
            txtLotID.Text = "";
            MPCF.SetFocus(txtLotID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // close
            this.Close();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print
            try
            {
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == false)
                {   
                    MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // process
            // SerialNoLabel_mod
        }

        #endregion

        #region Function

        private bool ModuleListAdd(string ModuleID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                ProcPrint(out_node);                
                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ProcPrint(TRSNode out_node)
        {
            spdList_Flexible.InitFlexibleScreen();

            try
            {
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "SerialNoLabel_mod";
                spdList_Flexible.ScreenSpread.Tag = "SerialNoLabel_mod";
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = "SerialNoLabel_mod";

                if (spdList_Flexible.LoadDesign("SerialNoLabel_mod") == false)
                {
                    return false;
                }
                
                out_node.SetString("SERIAL_NO", v_module_id);
                
                if (spdList_Flexible.SetDataToScreen(out_node) == false)
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
                in_node.ProcStep = '2'; /* Module Barcode Label */

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


    }
}
