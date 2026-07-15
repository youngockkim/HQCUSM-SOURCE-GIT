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
    /// <summary>
    /// 
    /// </summary>
    public partial class frmCUSACModuleRemove : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        public string v_module_id = string.Empty;

        #endregion

        #region Constructor

        public frmCUSACModuleRemove()
        {
            InitializeComponent();
        }

        #endregion

        #region Constant Definition


        public enum FQC_LOT_LIST
        {
            INS_CNT,
            RES_ID,
            INS_TIME,
            INS_VALUE,
            RESULT_TIME,
            RESULT_VALUE,
            DEFECT_CODE,
            GRADE,
            POWER,
            ARTICLE_NO,
            COLOR_CLASS
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
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                
                MPCF.SetFocus(txtModuleId);
                // (Required) 
                bIsShown = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //validation check
                if (!CheckCondition("PROCESS"))
                    return;

                //remove 실행
                if (Tran_Module_Id_Input() == false)
                    return;

                //clear
                MPCF.ClearList(spdList);
                txtModuleId.Text = "";
                txtInverterId.Text = "";
                MPCF.SetFocus(txtModuleId);
                //MPCF.SetFocus(txtInverterId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.INFO, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        private bool FqcLotListAdd(string ModuleID)
        {
            bool bFoundNewMaterialID = false;

            try
            {
                MPCF.ClearList(spdList);
                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode lot_list;
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LOT_ID", ModuleID);
                in_node.AddString("INS_TYPE", "FC");

                if (MPCF.CallService("CWIP", "CWIP_View_Acmodule_History_List", in_node, ref out_node) == false)
                {
                    if (out_node.GetList(0) == null)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }
                /*
                out_node.SetString("INS_CNT", out_node.GetString("INS_CNT"));
                out_node.SetString("RES_ID", out_node.GetString("RES_ID"));
                out_node.SetString("INS_TIME", out_node.GetString("INS_TIME"));
                out_node.SetString("RESULT_TIME", out_node.GetString("RESULT_TIME"));
                out_node.SetString("RESULT_VALUE", out_node.GetString("RESULT_VALUE"));
                out_node.SetString("DEFECT_CODE", out_node.GetString("DEFECT_CODE"));
                out_node.SetString("POWER", out_node.GetString("POWER"));
                out_node.SetString("ARTICLE_NO", out_node.GetString("ARTICLE_NO"));
                out_node.SetString("COLOR_CLASS", out_node.GetString("COLOR_CLASS"));
                */
                spdList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                if (spdList.ActiveSheet.RowCount > 0)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        lot_list = out_node.GetList(0)[i];
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.INS_CNT].Value = lot_list.GetInt("INS_CNT");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.RES_ID].Value = lot_list.GetString("RES_ID");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.INS_TIME].Value = MPCF.ToDate(lot_list.GetString("INS_TIME"));
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.INS_VALUE].Value = lot_list.GetString("INS_VALUE");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.RESULT_TIME].Value = MPCF.ToDate(lot_list.GetString("RESULT_TIME"));
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.RESULT_VALUE].Value = lot_list.GetString("RESULT_VALUE");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.DEFECT_CODE].Value = lot_list.GetString("DEFECT_CODE");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.GRADE].Value = lot_list.GetString("GRADE");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.POWER].Value = lot_list.GetString("POWER");
                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.ARTICLE_NO].Value = lot_list.GetString("ARTICLE_NO");

                        spdList.ActiveSheet.Cells[i, (int)FQC_LOT_LIST.COLOR_CLASS].Value = lot_list.GetString("COLOR_CLASS");

                        //가장 최근의 자재코드를 기준으로 article code 보여주는 부분 결정
                        if (isNewMaterialID(lot_list.GetString("MAT_ID")) == true)
                        {
                            bFoundNewMaterialID = true;
                        }
                    }

                    if (bFoundNewMaterialID == true)
                    {
                        spdList.ActiveSheet.Columns[(int)FQC_LOT_LIST.ARTICLE_NO].Width = 0;
                    }
                    else
                    {
                        spdList.ActiveSheet.Columns[(int)FQC_LOT_LIST.ARTICLE_NO].Width = 120;
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
        #endregion

        #region Function

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtModuleId.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Module ID]"));
                            MPCF.SetFocus(txtModuleId);
                            return false;
                        }

                        break;

                        
                    case "PROCESS":
                      
                        if (string.IsNullOrEmpty(txtModuleId.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Module ID]"));
                            MPCF.SetFocus(txtModuleId);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtInverterId.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Inverter ID]"));
                            MPCF.SetFocus(txtInverterId);
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

        private bool Tran_Module_Id_Input()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtModuleId.Text));              // LOT_ID
                in_node.AddString("PCU_SN", MPCF.Trim(txtInverterId.Text));               // INVERTER_ID

                if (MPCF.CallService("CWIP", "CWIP_Update_Acmodule_Remove", in_node, ref out_node) == false)
                {
                    return false;
                }

               txtModuleId.Text = "";
               txtInverterId.Text = "";
               MPCF.SetFocus(txtModuleId);
               MPCF.ShowSuccessMessage(out_node, false);
               
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            MPCF.ClearList(spdList);
            txtModuleId.Text = "";
            txtInverterId.Text = "";
            MPCF.SetFocus(txtModuleId);
        }

        private void txtModuleId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue== 13)
                {
                    //validation check
                    if (!CheckCondition("VIEW"))
                        return;

                    txtModuleId.Text = MPCF.ToUpper(txtModuleId.Text);
                    FqcLotListAdd(MPCF.ToUpper(txtModuleId.Text));


                    txtModuleId.SelectAll();

                    MPCF.SetFocus(txtInverterId);
                    //if (CheckCondition("VIEW") && CheckCondition("INVERTER_VIEW"))
                    //    btnProcess.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

    }
}
