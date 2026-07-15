using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
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
    public partial class frmCUSModulePackingLabelHorizontal : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;
        public string v_pallet_id = string.Empty;

        #endregion

        #region Constructor

        public frmCUSModulePackingLabelHorizontal()
        {
            InitializeComponent();
        }

        #endregion

        #region Constant Definition

        public enum LOT_LIST
        {
            SEQ,
            ARTICLE_NO,
            BATCH_NO,
            PRODUCT,
            TYPE,
            BARCODE,
            PACK_HV
        }

        #endregion

        #region Variable Definition

        private frmPrintOptionPopup frmOption;
        private float gArticleCodeColumnWidth = 0;

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
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            gArticleCodeColumnWidth = spdList_Sheet1.Columns[(int)LOT_LIST.ARTICLE_NO].Width;
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
                MPCF.SetFocus(txtModuleId);

                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.LoadDesign("HORIZONTAL_LABEL_PIC");
                // (Required) 
                bIsShown = true;
            }
        }

        private void soiSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // close
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // process
            // print
            try
            {
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == false)
                {
                    if (spdList.ActiveSheet.RowCount > 0)
                    {
                        for (int z = 0; z < 2; z++) // 2장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);

                        MPCF.ClearList(spdList);
                        spdList_Flexible.InitFlexibleScreen();
                        spdList_Flexible.LoadDesign("HORIZONTAL_LABEL_PIC");
                        txtPalletId.Text = "";
                        txtModuleId.Text = "";
                        MPCF.SetFocus(txtModuleId);
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
            }
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
                        for (int z = 0; z < 2; z++) // 2장 출력하기
                            MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);                        
                            MPCF.SetFocus(txtPalletId);
                    }
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear
            MPCF.ClearList(spdList);
            spdList_Flexible.InitFlexibleScreen();
            spdList_Flexible.LoadDesign("HORIZONTAL_LABEL_PIC");
            txtPalletId.Text = "";
            txtModuleId.Text = "";
            MPCF.SetFocus(txtModuleId);

        }

        private void txtPalletId_KeyDown(object sender, KeyEventArgs e)
        {
            // /엔터를 입력하면 처리되는 로직이 들어간다.
            try
            {
                if (e.KeyValue == 13)
                {
                    if (string.IsNullOrEmpty(txtPalletId.Text) == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Pallet ID]"));
                        MPCF.SetFocus(txtPalletId);
                        return;
                    }

                    if (string.IsNullOrEmpty(txtModuleId.Text) == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Module ID]"));
                        MPCF.SetFocus(txtModuleId);
                        return;
                    }

                    MPCF.SetFocus(txtModuleId);

                    v_pallet_id = MPCF.ToUpper(txtPalletId.Text);
                    PackLotListAdd(MPCF.ToUpper(txtPalletId.Text), MPCF.ToUpper(txtModuleId.Text));
                    txtPalletId.SelectAll();

                    btnProcess.PerformClick();

                    //v_pallet_id = MPCF.ToUpper(txtPalletId.Text);
                    //PackLotListAdd(MPCF.ToUpper(txtPalletId.Text));                    
                    //txtPalletId.SelectAll();

                    //btnProcess.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtModuleId_KeyDown(object sender, KeyEventArgs e)
        {
            // /엔터를 입력하면 처리되는 로직이 들어간다.
            try
            {
                if (e.KeyValue == 13)
                {
                    if (string.IsNullOrEmpty(txtModuleId.Text) == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Module ID]"));
                        MPCF.SetFocus(txtModuleId);
                        return;
                    }

                    MPCF.SetFocus(txtPalletId);  

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

        #region Function

        private bool ProcPrint(TRSNode out_node)
        {

            spdList_Flexible.InitFlexibleScreen();

            int i;
            int iRowCount;
            string sArticleNo;
            string sBatchNo;
            string sPowerClass;
            string sGrade;
            string sBarcode;

            try
            {
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = "PackingPalletLabel_mod";
                spdList_Flexible.ScreenSpread.Tag = "PackingPalletLabel_mod";
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = "PackingPalletLabel_mod";

                if (spdList_Flexible.LoadDesign("PackingPalletLabel_mod") == false)
                {
                    return false;
                }

                iRowCount = spdList.ActiveSheet.RowCount;

                for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
                {
                    sArticleNo = String.Format("ARTICLE_NO_{0}", i + 1);
                    out_node.SetString(sArticleNo, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.ARTICLE_NO].Value));

                    sBatchNo = String.Format("BATCH_NO_{0}", i + 1);
                    out_node.SetString(sBatchNo, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.BATCH_NO].Value));

                    sPowerClass = String.Format("PRODUCT_{0}", i + 1);
                    out_node.SetString(sPowerClass, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.PRODUCT].Value));

                    sGrade = String.Format("TYPE_{0}", i + 1);
                    out_node.SetString(sGrade, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.TYPE].Value));

                    sBarcode = String.Format("BARCODE_{0}", i + 1);
                    out_node.SetString(sBarcode, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.BARCODE].Value));
                }

                if (spdList_Flexible.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
                return false;
            }
        }

        private bool ProcPrint_v1(TRSNode out_node)
        {
            
            spdList_Flexible.InitFlexibleScreen();

            int i;
            int iRowCount;
            bool isGradeA;
            string sArticleNo;
            string sBatchNo;
            string sPowerClass;
            string sGrade;
            string sBarcode;
            string sBarcodeID;
            string sMatID;
            string grade = MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)LOT_LIST.TYPE].Value);
            string reportID = GetReportID(out_node.GetString("MAT_ID"), (MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)LOT_LIST.TYPE].Value)));

            try
            {
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = reportID;
                spdList_Flexible.ScreenSpread.Tag = reportID;
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = reportID;

                if (spdList_Flexible.LoadDesign(reportID)==false)
                {
                    return false;
                }
                
                iRowCount = spdList.ActiveSheet.RowCount;

                for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
                {
                    sArticleNo = String.Format("ARTICLE_NO_{0}", i + 1);
                    out_node.SetString(sArticleNo, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.ARTICLE_NO].Value));

                    sBatchNo = String.Format("BATCH_NO_{0}", i + 1);
                    out_node.SetString(sBatchNo, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.BATCH_NO].Value));

                    sPowerClass = String.Format("PRODUCT_{0}", i + 1);
                    out_node.SetString(sPowerClass, out_node.GetList(0)[i].GetString("POWER_CLASS")); 

                    sGrade = String.Format("TYPE_{0}", i + 1);
                    out_node.SetString(sGrade, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.TYPE].Value));

                    sBarcodeID = String.Format("BARCODE_ID_{0}", i + 1);
                    out_node.SetString(sBarcodeID, out_node.GetString("BARCODE_ID"));

                    sBarcode = String.Format("BARCODE_{0}", i + 1);
                    out_node.SetString(sBarcode, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.BARCODE].Value));

                    //06.14일 수정(등급외인경우 처리추가)
                    isGradeA = (grade == "G03" || grade == "G04" || grade == "G01" || grade == "G02" || grade == "A" ? true : false);       //--[G03/G04 로직 추가]


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

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
                return false;
            }
        }

        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

        private bool PackLotListAdd(string PalletID, string ModuleID)
        {
            try
            {
                MPCF.ClearList(spdList);
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                in_node.ProcStep = '1';
                in_node.AddString("PALLET_ID", PalletID);
                in_node.AddString("MODULE_ID", ModuleID);

                if (MPCF.CallService("CWIP", "CWIP_View_Packing_Label_Print_V1", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }

                out_node.SetString("PALLET_NO", v_pallet_id);
                out_node.SetString("LENGTH", out_node.GetString("LENGTH"));
                out_node.SetString("BREADTH", out_node.GetString("BREADTH"));
                out_node.SetString("HEIGHT", out_node.GetString("HEIGHT"));
                out_node.SetString("GROSS_W", out_node.GetString("GROSS_W"));
                out_node.SetString("NET_W", out_node.GetString("NET_W"));
                out_node.SetString("TARE_W", out_node.GetString("TARE_W"));
                out_node.SetString("PACK_HV", out_node.GetString("PACK_HV"));
                out_node.SetString("MAT_ID", out_node.GetString("MAT_ID"));

                out_node.SetString("LENGTH_INCH", out_node.GetString("LENGTH_INCH"));
                out_node.SetString("BREADTH_INCH", out_node.GetString("BREADTH_INCH"));
                out_node.SetString("HEIGHT_INCH", out_node.GetString("HEIGHT_INCH"));
                out_node.SetString("GROSS_WEIGHT_LB", out_node.GetString("GROSS_WEIGHT_LB"));
                out_node.SetString("NET_WEIGHT_LB", out_node.GetString("NET_WEIGHT_LB"));
                out_node.SetString("TARE_WEIGHT_LB", out_node.GetString("TARE_WEIGHT_LB"));
                out_node.SetString("BARCODE_ID", out_node.GetString("BARCODE_ID"));

                if (out_node.GetList(0).Count > 0)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                      /*
                        if(string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("PACK_HV")))
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(557), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                    */
                        if (out_node.GetList(0)[i].GetString("PACK_HV") == "V")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(558), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        
                        spdList.ActiveSheet.AddRows(0, 1);
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.SEQ].Value = out_node.GetList(0).Count - i; //out_node.GetList(0)[i].GetInt("SEQ");
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.ARTICLE_NO].Value = out_node.GetList(0)[i].GetString("ARTICLE_NO");
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.BATCH_NO].Value = out_node.GetList(0)[i].GetString("BATCH_NO");
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.PRODUCT].Value = out_node.GetList(0)[i].GetString("POWER_CLASS"); 
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.TYPE].Value = out_node.GetList(0)[i].GetChar("GRADE");
                        spdList.ActiveSheet.Cells[0, (int)LOT_LIST.BARCODE].Value = out_node.GetList(0)[i].GetString("MODULE_ID");
                        //spdList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_HV].Value = out_node.GetList(0)[i].GetString("PACK_HV");
                    }

                    ProcPrint_v1(out_node);

                    if (isNewMaterialID(out_node.GetString("MAT_ID")) == true)
                    {
                        spdList_Sheet1.Columns[(int)LOT_LIST.ARTICLE_NO].Width = 0;
                    }
                    else
                    {
                        spdList_Sheet1.Columns[(int)LOT_LIST.ARTICLE_NO].Width = gArticleCodeColumnWidth;
                    }
                }
                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
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
         
        private String GetReportID(String matID, String grade)
        {
            string reportID = "";
            bool isGradeA = (grade == "G03" || grade == "G04" || grade == "G01" || grade == "G02" || grade == "A" ? true : false);      //--[G03/G04 로직 추가]

            if (isNewMaterialID(matID) == true)
            {
                reportID = isGradeA ? "PalletNote_V2_2" : "PalletNote_V2_1";
            }
            else
            {
                reportID = isGradeA ? "PalletNote_V1_2" : "PalletNote_V1_1";
            }

            return reportID;
        }
        #endregion

    }
}
