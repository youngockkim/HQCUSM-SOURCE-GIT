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
    public partial class frmCUSModuleLabelMulti : SOIBaseForm03
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
        private TRSNode m_nodeGradeOut;
        #endregion

        #region Constructor

        public frmCUSModuleLabelMulti()
        {
            InitializeComponent();
        }

        #endregion

        #region Constant Definition

        public enum MODULE_LIST
        {
            NO,
            LOT_ID,
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
            VALIDATION,
            LABEL_ID
        }

        #endregion

        #region Event Handler

        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            m_nodeGradeOut = new TRSNode("GRADE_OUT");
            MPCF.ClearList(spdList);
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
                    //v_lot_id = txtLotId1.Text;
                    ////ModuleListAdd(txtLotId.Text);
                    //if (ModuleListAdd(txtLotId1.Text))
                    //{
                    //    UpdatePrintHistory(txtLotId1.Text);
                    //}

                    //MPCF.SetFocus(txtLotId1);
                    //txtLotId1.SelectAll();
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
            txtLotID.Text = "";
            MPCF.SetFocus(txtLotID);
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
                        //MPCF.SetFocus(txtLotId1);
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
        private bool AddModuleList()
        {
            try
            {
                int i, row = 0;
                bool bValidated = true;

                MPCF.ClearList(spdList);

                TRSNode in_node = new TRSNode("GRADE_IN");
                m_nodeGradeOut = new TRSNode("GRADE_OUT");

                TRSNode lot_list, lot_id_list;

                List<String> list = txtLotID.Text.Replace("\r", "").Trim().Split('\n').Distinct().ToList();
                if (list.Count > 100)
                {
                    MPCF.ShowMsgBox("Only allows to input up to 100 modules and ‘\\n’ is delimiter from module to module");
                    this.txtLotID.Focus();
                    return false;
                };

                list.ForEach(item =>
                {
                    lot_id_list = in_node.AddNode("GRADE");
                    lot_id_list.AddString("LOT_ID", item);
                    lot_id_list.AddString("FACTORY", "USGAM1");
                });

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCF.CallService("CWIP", "CWIP_View_Grade_Multi", in_node, ref m_nodeGradeOut) == false)
                {
                    MPCF.ShowMsgBox(m_nodeGradeOut.Msg);
                    return false;
                }
                spdList.ActiveSheet.RowCount = 0;

                for (i = 0; i < m_nodeGradeOut.GetList(0).Count; i++)
                {
                    lot_list = m_nodeGradeOut.GetList(0)[i];
                    row = spdList.ActiveSheet.RowCount++;

                    if (SetDataToSpread(row, lot_list) == false)
                    {
                        bValidated = false;
                    }
                }
                MPCF.FitColumnHeader(spdList);
                spdList.ActiveSheet.SetColumnWidth((int)MODULE_LIST.LABEL_ID, 90);

                if (bValidated == true)
                {
                    this.btnPrint.Enabled = true;
                    PrintAllLot(m_nodeGradeOut);
                }
                else
                {
                    this.btnPrint.Enabled = false;
                    return false;
                }

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private bool PrintAllLot(TRSNode out_node)
        {
            int i;
            TRSNode lot_list;

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                lot_list = out_node.GetList(0)[i];
                ProcPrint(lot_list, true);
            }

            return true;
        }

        private bool SetDataToSpread(int row, TRSNode out_node)
        {
            String strLotID = out_node.GetString("LOT_ID");
            String labelID = out_node.GetString("LABEL_ID");
            String strValidation = "";

            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.NO].Value = row + 1;
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.LOT_ID].Value = strLotID;
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.PRODUCT].Value = out_node.GetString("PRODUCT_NM");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.GRADE].Value = out_node.GetString("GRADE");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.PMPP].Value = out_node.GetString("PMPP");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.ISC].Value = out_node.GetString("ISC");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VOC].Value = out_node.GetString("VOC");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.IMPP].Value = out_node.GetString("IMPP");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VMPP].Value = out_node.GetString("VMPP");
            //spdList.ActiveSheet.Cells[0, (int)MODULE_LIST.VSYS].Value = grade_out_node.GetString("VSYS");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VSYS_UL].Value = out_node.GetString("VSYS_UL");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VSYS_LL].Value = out_node.GetString("VSYS_LL");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.KGLBS].Value = out_node.GetString("WEIGHT");

            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.BSTC_PMPP].Value = out_node.GetString("BSTC_PMPP");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.BSTC_ISC].Value = out_node.GetString("BSTC_ISC");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.BSTC_VOC].Value = out_node.GetString("BSTC_VOC");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.BSTC_IMPP].Value = out_node.GetString("BSTC_IMPP");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.BSTC_VMPP].Value = out_node.GetString("BSTC_VMPP");
            spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.LABEL_ID].Value = out_node.GetString("LABEL_ID");

            if (labelID.Length <= 0)
            {
                strValidation = "This module does not exist, Please check it.";
                spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.LOT_ID].ForeColor = Color.Red;
                spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VALIDATION].ForeColor = Color.Red;
                spdList.ActiveSheet.Cells[row, (int)MODULE_LIST.VALIDATION].Value = strValidation;
                return false;
            }

            return true;
        }

        private bool ProcPrint(TRSNode out_node, bool bPrint)
        {
            try
            {
                TRSNode grade_out_node = new TRSNode("GRADE_OUT");
                spdList_Flexible.InitFlexibleScreen();

                string labelID = string.Empty;

                labelID = out_node.GetString("LABEL_ID");
                //labelID = "ModuleLB2_000661200333100007";
                // Assign Label Data to Flexible Screen
                spdList_Flexible.InitFlexibleScreen();
                spdList_Flexible.ScreenID = labelID;
                spdList_Flexible.ScreenSpread.Tag = labelID;
                spdList_Flexible.ProcStep = '1';
                spdList_Flexible.LotID = labelID;

                if (spdList_Flexible.LoadDesign(labelID) == false)
                {
                    return false;
                }

                grade_out_node.SetString("LOT_ID", out_node.GetString("LOT_ID"));
                grade_out_node.SetString("PRODUCT", out_node.GetString("PRODUCT_NM"));
                grade_out_node.SetString("PMPP", out_node.GetString("PMPP"));
                grade_out_node.SetString("ISC", out_node.GetString("ISC"));
                grade_out_node.SetString("VOC", out_node.GetString("VOC"));
                grade_out_node.SetString("IMPP", out_node.GetString("IMPP"));
                grade_out_node.SetString("VMPP", out_node.GetString("VMPP"));
                grade_out_node.SetString("VSYS_UL", out_node.GetString("VSYS_UL"));
                grade_out_node.SetString("VSYS_LL", out_node.GetString("VSYS_LL"));
                grade_out_node.SetString("KGLBS", out_node.GetString("WEIGHT"));
                grade_out_node.SetString("BARCODE", out_node.GetString("LOT_ID"));

                //BSTC 값 추가.
                if ("TRUE".Equals(out_node.GetString("BSTC_NOT_NULL")))
                {
                    grade_out_node.SetString("BSTC_PMPP", out_node.GetString("BSTC_PMPP"));
                    grade_out_node.SetString("BSTC_ISC", out_node.GetString("BSTC_ISC"));
                    grade_out_node.SetString("BSTC_VOC", out_node.GetString("BSTC_VOC"));
                    grade_out_node.SetString("BSTC_IMPP", out_node.GetString("BSTC_IMPP"));
                    grade_out_node.SetString("BSTC_VMPP", out_node.GetString("BSTC_VMPP"));
                }
                if (spdList_Flexible.SetDataToScreen(grade_out_node) == false)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == false)
                {
                    if (spdList.ActiveSheet.RowCount > 0 && bPrint == true)
                    {
                        MPCF.PrintFlexibleScreen(this, this.printOption, spdList_Flexible, false);
                        //MPCF.SetFocus(txtLotId1);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                AddModuleList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            TRSNode lot_list;
            String labelID;
            labelID = spdList.Sheets[0].Cells[e.Range.Row, (int)MODULE_LIST.LABEL_ID].Value.ToString();

            if (spdList.Sheets[0].Cells[e.Range.Row, (int)MODULE_LIST.VALIDATION].Value != null)
            {
                return;
            }
            lot_list = m_nodeGradeOut.GetList(0)[e.Range.Row];
            ProcPrint(lot_list, false);

        }
    }
}