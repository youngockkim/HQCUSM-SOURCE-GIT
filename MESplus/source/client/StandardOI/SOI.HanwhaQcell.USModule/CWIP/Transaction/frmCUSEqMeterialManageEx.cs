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
    public partial class frmCUSEqMeterialManage2 : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string strOrderNo = "";
        private string strFlow = "";
        private string strMatID = "";
        private string strInvLot = "";
        private double dblQty = 0;

        #endregion

        #region Constructor

        public frmCUSEqMeterialManage2()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        const int ENTER = 13;

        public enum BOM_LIST
        {
            SEQ,
            MAT_ID,
            MAT_DESC,
            QTY
        }


        public enum LOT_LIST
        {
            NO,
            INV_BARCODE_ID,
            INV_MAT_ID,
            MAT_DESC,
            MAT_TYPE,
            INV_LOT_ID,
            ATTACH_QTY,
            USED_QTY,
            REMAIN_QTY,
            UNIT,
            MAT_ID,
            ATTACH_TIME,
            ATTACH_USER_ID

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
                cdvLineID.Code = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                if (!ViewWorkOrder())
                    return;

                //if (!ViewOrderBOMList())
                //    return;

                MPCF.SetFocus(cdvOperID);
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

                cdvOperID.Code = cdvOperID.Show(cdvOperID, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperID.Text == null || cdvOperID.Text == string.Empty)
                {
                    return;
                }

                cdvEquipID.Text = "";
                MPCF.SetFocus(cdvEquipID);

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

                if (!ViewAttachedMatList())
                    return;

                // Focus
                MPCF.SetFocus(cdvMatID);
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
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                // New Version
                frmCORDViewWorkOrderPopup pop = new frmCORDViewWorkOrderPopup(MPCF.Trim(cdvLineID.Text));
                pop.StartPosition = FormStartPosition.CenterParent;
                pop.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
                pop.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //pop.ClientSize = new System.Drawing.Size(1024, 768);
                pop.ShowDialog(this);
                pop.Focus();
                //pop.Owner = MPGV.gfrmMDI;
                //pop.ShowDialog();

                // View Code
                if (string.IsNullOrEmpty(pop.outOrderID))
                {
                    return;
                }

                cdvMatID.Text = pop.outOrderID;
                //[ERP 23.05.28] ORDER DESC 추가
                cdvMatID.Description = pop.outOrderDesc;
                //if (!ViewWorkOrder())
                //    return;

                if (!ViewOrderBOMList())
                    return;

                if (!ViewAttachedMatList())
                    return;

                // Focus
                MPCF.SetFocus(txtBarcord);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtMatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtBarcord.Text) != "")
            {
                txtBarcord.Text = MPCF.ToUpper(txtBarcord.Text); // 일괄 대문자

                if (!CheckCondition("VIEW"))
                    return;

                if (Tran_Mat_Lot_Input() == false)
                    return;

                ViewAttachedMatList();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdMatList);
            txtBarcord.Text = "";
            txtCount.Text = "0";
            MPCF.SetFocus(cdvMatID);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                if (spdMatList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowErrorMessage(MPCF.GetMessage(192));
                    return;
                }

                MPCF.SetInMsg(in_node);

                in_node.ProcStep = 'D';
                in_node.AddString("RES_ID", MPCF.Trim(cdvEquipID.Code));            // EQUIP ID
                in_node.AddInt("SEQ", MPCF.Trim(spdMatList.ActiveSheet.Cells[spdMatList.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.NO].Value));

                if (MPCF.CallService("CRAS", "CRAS_Update_Attached_Material_List", in_node, ref out_node) == false)
                {
                    return;
                }


                spdMatList.ActiveSheet.Rows.Remove(spdMatList.ActiveSheet.ActiveRowIndex, 1);

                txtCount.Text = spdMatList.ActiveSheet.RowCount.ToString();

                MPCF.ShowSuccessMessage(out_node, false);
                return;
            }
            catch (Exception)
            {
                throw;
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

                        //if (string.IsNullOrEmpty(txtLackID.Text) == true)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[PACK ID]"));
                        //    MPCF.SetFocus(txtLackID);
                        //    return false;
                        //}

                        //for (int k = 0; k < spdMatList.ActiveSheet.RowCount; k++)
                        //{
                        //    if (txtLackID.Text == spdMatList.ActiveSheet.Cells[k, (int)LOT_LIST.LACK_ID].Text)
                        //    {
                        //        //MPCF.ShowErrorMessage("해당 Magazine은 스프레드에 추가 되어 있습니다.");
                        //        MPCF.ShowMessage(MPCF.GetMessage(501), MSG_LEVEL.ERROR, false);

                        //        txtLackID.Text = "";
                        //        return false;
                        //    }
                        //}

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Line ID]"));
                            MPCF.SetFocus(cdvLineID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvOperID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[OPER ID]"));
                            MPCF.SetFocus(cdvOperID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[RES ID]"));
                            MPCF.SetFocus(cdvEquipID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MAT ID]"));
                            MPCF.SetFocus(cdvMatID);
                            return false;
                        }

                        if (spdMatList.ActiveSheet.RowCount == 0)
                        {
                            //MPCF.ShowMsgBox("저장 할 Data가 존재하지 않습니다.");
                            MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtBarcord);
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

        private bool Tran_Mat_Lot_Input()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = 'I';
                in_node.AddString("CMF_1", MPCF.Trim(cdvLineID.Code));              // LINE ID
                in_node.AddString("OPER", MPCF.Trim(cdvOperID.Code));               // OPER ID
                in_node.AddString("RES_ID", MPCF.Trim(cdvEquipID.Code));            // EQUIP ID
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Code));              // PRODUCT ID
                in_node.AddString("ORDER_ID", MPCF.Trim(strOrderNo));               // ORDER NO
                in_node.AddString("FLOW", MPCF.Trim(strFlow));                      // Flow                
                in_node.AddString("INV_BARCODE_ID", MPCF.Trim(txtBarcord.Text));     // INV_BARCODE_ID

                if (MPCF.CallService("CRAS", "CRAS_Update_Attached_Material_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBarcord.Text = "";
                MPCF.SetFocus(txtBarcord);
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewWorkOrder()
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_CURRENT_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_CURRENT_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                strOrderNo = "";
                strFlow = "";

                if (MPCF.CallService("CORD", "CORD_View_Current_Order_By_Line", in_node, ref out_node) == false)
                {
                    return false;
                }

                strOrderNo = out_node.GetString("ORDER_ID");
                strFlow = out_node.GetString("FLOW");
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewOrderBOMList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdBomList);

                TRSNode in_node = new TRSNode("VIEW_ORDER_BOM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_BOM_LIST_OUT");
                TRSNode bom_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ORDER_ID", MPCF.Trim(cdvMatID.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Order_BOM_List", in_node, ref out_node) == false)
                {
                    return false;
                }


                spdBomList.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    bom_list = out_node.GetList(0)[i];

                    spdBomList.ActiveSheet.RowCount++;

                    //spdBomList.ActiveSheet.Cells[i, (int)BOM_LIST.SEQ].Value = bom_list.GetInt("SEQ")
                    spdBomList.ActiveSheet.Cells[i, (int)BOM_LIST.SEQ].Value = spdBomList.ActiveSheet.RowCount;
                    spdBomList.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_ID].Value = bom_list.GetString("MAT_ID");
                    spdBomList.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_DESC].Value = bom_list.GetString("MAT_DESC");
                    spdBomList.ActiveSheet.Cells[i, (int)BOM_LIST.QTY].Value = MPCF.MakeNumberFormat(bom_list.GetDouble("QTY"), 2);


                }

                MPCF.FitColumnHeader(spdBomList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewMatInfo(string sMatId)
        {
            TRSNode in_node = new TRSNode("VIEW_METERIAL_IN");
            TRSNode out_node1 = new TRSNode("VIEW_METERIAL_OUT");

            strMatID = "";
            strInvLot = "";
            dblQty = 0;

            try
            {
                // FieldClear

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("VENDOR_BARCD", MPCF.Trim(sMatId));

                if (MPCF.CallService("CWIP", "CWIP_View_Cinvlotsts_List", in_node, ref out_node1) == false)
                {
                    return false;
                }

                strMatID = out_node1.GetString("MAT_ID");
                strInvLot = out_node1.GetString("INV_LOT_ID");
                dblQty = out_node1.GetDouble("QTY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewAttachedMatList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdMatList);

                TRSNode in_node = new TRSNode("VIEW_ATTACH_MAT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ATTACH_MAT_LIST_OUT");
                TRSNode attached_mat_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvEquipID.Code));

                if (MPCF.CallService("CRAS", "CRAS_View_Attached_Material_List_By_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdMatList.ActiveSheet.RowCount = 0;

                if (out_node.GetList(0).Count == 0)
                    return true;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    attached_mat_list = out_node.GetList(0)[i];

                    spdMatList.ActiveSheet.RowCount++;

                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = attached_mat_list.GetInt("SEQ");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.INV_BARCODE_ID].Value = attached_mat_list.GetString("INV_BARCODE_ID");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.INV_MAT_ID].Value = attached_mat_list.GetString("INV_MAT_ID");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_DESC].Value = attached_mat_list.GetString("MAT_DESC");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_TYPE].Value = attached_mat_list.GetString("MAT_TYPE");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.INV_LOT_ID].Value = attached_mat_list.GetString("INV_LOT_ID");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.ATTACH_QTY].Value = MPCF.MakeNumberFormat(attached_mat_list.GetDouble("ATTACH_QTY"), 0);
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.USED_QTY].Value = MPCF.MakeNumberFormat(attached_mat_list.GetDouble("USED_QTY"), 0);
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.REMAIN_QTY].Value = MPCF.MakeNumberFormat(attached_mat_list.GetDouble("REMAIN_QTY"), 0);
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.UNIT].Value = attached_mat_list.GetString("UNIT");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_ID].Value = attached_mat_list.GetString("MAT_ID");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.ATTACH_TIME].Value = attached_mat_list.GetString("ATTACH_TIME");
                    spdMatList.ActiveSheet.Cells[i, (int)LOT_LIST.ATTACH_USER_ID].Value = attached_mat_list.GetString("ATTACH_USER_ID");

                }

                txtCount.Text = spdMatList.ActiveSheet.Rows.Count.ToString();

                MPCF.FitColumnHeader(spdMatList);

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
