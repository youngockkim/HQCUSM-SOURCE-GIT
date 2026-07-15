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
using Miracom.CliFrx;
using Miracom.MESCore;

namespace Custom.HanwhaQcell.USModule.CTST.Transaction
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranPackingFullCell : SOIBaseForm03
    {

        #region Variable Definition

        private SOI.CliFrx.MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private bool bIsShown = false;
        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        #region Loading Init

        public frmCUSTranPackingFullCell()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Constructor
        
        public enum LOT_LIST
        {
            CHK,
            NO,
            FG_ID,
            LOT_ID,
            OPER,
            OPER_DESC,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            ORDER_ID,
            RES_ID,
            RES_DESC,
            TRAN_USER_ID,
            TRAN_TIME,
            CREATE_TIME
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
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            //MPCR.ConvertCaption(this);
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewTranPackingFullCellList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // 프린트 구성로직
                if (!CheckCondition("PROCESS"))
                    return;

                ProcPrint();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }

        private void btnCreateBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (Create_Box('3') == true)
                {
                    DisplayMessage("박스 생성이 완료되었습니다.", MSSAG_LEVEL.INFO);
                }
                else
                {
                    DisplayMessage("박스 생성에 오류가 있습니다.", MSSAG_LEVEL.ERROR);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdBoxLotList);
            txtPallet.Text = "";
            txtMagazine.Text = "";
            txtCellBox.Text = "";
            txtPallet.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (spdBoxLotList.ActiveSheet.RowCount == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(192));
                return;
            }

            for (int i = spdBoxLotList.ActiveSheet.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(spdBoxLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHK].Value) == true)
                {
                    spdBoxLotList.ActiveSheet.Rows.Remove(i, 1);
                }
            }

            int iRowCount = spdBoxLotList.ActiveSheet.RowCount;

            for (int i = 0; i < spdBoxLotList.ActiveSheet.RowCount; i++)
            {
                spdBoxLotList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
                iRowCount--;
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
            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion
        
        #region Function

        // 박스 생성
        private bool Create_Box(char c_Step)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_Step;

                if (MPCR.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
                    return false;

                sBoxID = txtCellBox.Text = out_node.GetString("NEW_BOX_ID");
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        // 프린트
        private bool ProcPrint()
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            int iRowCount;
            string sProdID;

            try
            {
                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "ViewPackingList";
                udcPrint.ScreenSpread.Tag = "ViewPackingList";
                udcPrint.ProcStep = '1';
                SOI.CliFrx.MenuInfoTag menuInfo = (SOI.CliFrx.MenuInfoTag)this.Tag;
                udcPrint.OwnerFuncName = menuInfo.s_func_name;
                udcPrint.LotID = "ViewPackingList";

                if (udcPrint.LoadDesign() == false)
                {
                    return false;
                }

                iRowCount = spdBoxLotList.ActiveSheet.RowCount;

                out_node.SetString("CREATE_TIME", MPCF.Trim(spdBoxLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CREATE_TIME].Value));
                out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdBoxLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value));
                out_node.SetString("BOX_ID", txtCellBox.Text);

                for (i = 0; i < spdBoxLotList.ActiveSheet.RowCount; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, MPCF.Trim(spdBoxLotList.ActiveSheet.Cells[i, (int)LOT_LIST.FG_ID].Value));
                }

                if (udcPrint.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrint.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

                for (i = 0; i < MPCF.ToInt(txtPrintCnt.Value); i++)
                {
                    //MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // Validation Check
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtPallet.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            txtPallet.Focus();
                            return false;
                        }

                        for (int k = 0; k < spdBoxLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtPallet.Text == spdBoxLotList.ActiveSheet.Cells[k, (int)LOT_LIST.FG_ID].Text)
                            {
                                MPCF.ShowMsgBox("해당LOT은 스프레드에 추가 되어 있습니다.");
                                txtPallet.Text = "";
                                return false;
                            }
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtCellBox.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Box ID]"));
                            txtCellBox.Focus();                            
                            return false;
                        }

                        if (spdBoxLotList.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMsgBox("Data가 존재하지 않습니다.");
                            txtPallet.Focus();
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

        // View Full Cell List
        private bool ViewTranPackingFullCellList()
        {
            try
            {   
                MPCF.ClearList(spdBoxLotList);
                // 데이터 불러와 spbBoxLotList에 넣어주기
                for (int iRow = 0; iRow < spdBoxLotList.iRowHRowCnt; iRow++)
                {
                    spdBoxLotList.ActiveSheet.RowCount++;                    
                }

                MPCF.FitColumnHeader(spdBoxLotList);
                txtCellBox.Text = "";
                txtMagazine.Text = "";
                txtPallet.Text = "";
                txtPrintCnt.Text = "";
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
            return true;
        }
                
        #endregion

    }
}
