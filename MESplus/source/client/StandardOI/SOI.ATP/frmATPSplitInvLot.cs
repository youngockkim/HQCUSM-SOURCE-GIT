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

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPSplitInvLot : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        private TRSNode _InvLot = new TRSNode("INV_LOT_INFO");

        private enum COL_SPLIT_LIST
        {
            SEQ = 1,
            CHILD_LOT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPSplitInvLot()
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
        /// Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check Value
                    if (MPCF.CheckValue(txtInvLotID, false) == false)
                    {
                        return;
                    }

                    // View Lot
                    if (ViewInvLot(txtInvLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtInvLotID);
                        return;
                    }

                    MPCF.SetFocus(txtSplitQty);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Search Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                // View Lot
                if (ViewInvLot(txtInvLotID.Text) == false)
                {
                    MPCF.SetFocus(txtInvLotID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Split Qty Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSplitQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check Value 
                    if (MPCF.CheckValue(txtInvLotID, false) == false)
                    {
                        return;
                    }

                    if (AddSplitQty() == false)
                    {
                        return;
                    }

                    txtSplitQty.SelectAll();
                    MPCF.SetFocus(txtSplitQty);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value 
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                if (AddSplitQty() == false)
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
        /// Delete Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteChild() == false)
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
        /// CheckBox Select All / Release All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdSplit_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // First Column Header Cell
                if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
                {
                    // Select All
                    if (spdSplit.Sheets[0].ColumnHeader.Cells[0, 0].Value == null
                        || ((bool)spdSplit.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                    {
                        spdSplit.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                        for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                        {
                            spdSplit.Sheets[0].Cells[i, 0].Value = true;
                        }
                    }
                    // Release All
                    else
                    {
                        spdSplit.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                        for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                        {
                            spdSplit.Sheets[0].Cells[i, 0].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                if (spdSplit.Sheets[0].Rows.Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(txtSplitQty);
                    return;
                }

                bool bChecked = false;
                for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdSplit.Sheets[0].Cells[i, 0].Value == true)
                    {
                        bChecked = true;
                        break;
                    }
                }
                if (bChecked == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(spdSplit);
                    return;
                }

                //else
                //{
                //    for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                //    {
                //        if (spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value == null
                //            || string.IsNullOrEmpty(spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value.ToString()) == true)
                //        {
                //            spdSplit.Sheets[0].ActiveRowIndex = i;
                //            spdSplit.Sheets[0].ActiveColumnIndex = (int)COL_SPLIT_LIST.CHILD_LOT_ID;

                //            return;
                //        }
                //    }
                //}

                if (MultiSplitLot() == false)
                {
                    txtInvLotID.SelectAll();
                    MPCF.SetFocus(txtInvLotID);
                    return;
                }

                txtInvLotID.SelectAll();
                MPCF.SetFocus(txtInvLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewInvLot(string invLotId)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(this, txtInvLotID, chkAutoGenID, chkPrintLabel);

                // Data Clear
                _InvLot.Init();

                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", txtInvLotID.Text);

                if (MPCF.CallService("INV", "INV_View_Inv_Lot", in_node, ref _InvLot) == false)
                {
                    return false;
                }

                txtMatCode.Text = _InvLot.GetString("INV_MAT_ID");
                txtMatDesc.Text = _InvLot.GetString("INV_MAT_DESC");
                txtOperCode.Text = _InvLot.GetString("STORE_ID");
                txtOperDesc.Text = _InvLot.GetString("STORE_DESC");
                txtLotQty.Text = MPCF.MakeNumberFormat(_InvLot.GetDouble("QTY_1"));
                lblSplitQty.Text = "0";
                lblRemainQty.Text = MPCF.MakeNumberFormat(_InvLot.GetDouble("QTY_1"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Split Qty
        /// </summary>
        /// <returns></returns>
        private bool AddSplitQty()
        {
            try
            {
                // Clear Message
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                if (MPCF.CheckValue(txtSplitQty, 0.0005, Convert.ToDouble(lblRemainQty.Text), false) == false)
                {
                    MPCF.SetFocus(txtSplitQty);
                    txtSplitQty.SelectAll();
                    return false;
                }

                // Get Split Qty
                double dSplitQty = Convert.ToDouble(txtSplitQty.Value);

                // Get Child Lot ID
                string sChildLotId = "";
                if (chkAutoGenID.Checked == true)
                {
                    if (GenChildLotID(ref sChildLotId) == false)
                    {
                        return false;
                    }
                }

                // Add Data
                int iRow = spdSplit.Sheets[0].Rows.Count;
                spdSplit.Sheets[0].RowCount++;

                spdSplit.Sheets[0].Cells[iRow, 0].Value = true;
                spdSplit.Sheets[0].Cells[iRow, (int)COL_SPLIT_LIST.SEQ].Value = spdSplit.Sheets[0].RowCount;
                spdSplit.Sheets[0].Cells[iRow, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value = sChildLotId;
                spdSplit.Sheets[0].Cells[iRow, (int)COL_SPLIT_LIST.QTY].Value = MPCF.MakeNumberFormat(dSplitQty);

                lblRemainQty.Text = MPCF.MakeNumberFormat((Convert.ToInt32(lblRemainQty.Text.Replace(",", "")) - Convert.ToInt32(dSplitQty.ToString())));
                lblSplitQty.Text = MPCF.MakeNumberFormat((Convert.ToInt32(lblSplitQty.Text.Replace(",", "")) + Convert.ToInt32(dSplitQty.ToString())));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Generate Child Lot ID
        /// </summary>
        /// <param name="sChildLotId"></param>
        /// <returns></returns>
        private bool GenChildLotID(ref string sChildLotId)
        {
            try
            {
                string sRuleID = string.Empty;

                TRSNode in_node = new TRSNode("VIEW_GCM_MES_OPTIONS_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_MES_OPTIONS_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "ATP_MES_OPTIONS");
                in_node.AddString("KEY_1", "INV_SPLIT_GEN_RULE");

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // No Data
                if (out_node.GetList(0) == null || out_node.GetList(0).Count < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(79), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // Get Rule ID
                List<TRSNode> labelIDList = out_node.GetList(0);
                foreach (TRSNode node in labelIDList)
                {
                    sRuleID = node.GetString("DATA_2");
                    break;
                }

                // No Label ID String
                if (sRuleID == string.Empty)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(79), MSG_LEVEL.ERROR, false);
                    return false;
                }

                in_node = new TRSNode("GENERATE_IN");
                out_node = new TRSNode("GENERATE_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RULE_ID", sRuleID);
                in_node.AddString("LOT_ID", _InvLot.GetString("INV_LOT_ID"));
                in_node.AddString("MAT_ID", _InvLot.GetString("INV_MAT_ID"));
                in_node.AddInt("MAT_VER", _InvLot.GetInt("INV_MAT_VER"));
                in_node.AddString("SEQ_KEY_1", _InvLot.GetString("INV_LOT_ID"));
                if (MPCF.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                sChildLotId = out_node.GetString("GEN_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Delete Child ID
        /// </summary>
        /// <returns></returns>
        private bool DeleteChild()
        {
            try
            {
                if (spdSplit.Sheets[0].Rows.Count > 0)
                {
                    for (int i = spdSplit.Sheets[0].Rows.Count - 1; i >= 0; i--)
                    {
                        if (((bool)spdSplit.Sheets[0].Cells[i, 0].Value) == true)
                        {
                            lblRemainQty.Text = MPCF.MakeNumberFormat((Convert.ToInt32(lblRemainQty.Text.Replace(",", "")) + Convert.ToInt32(spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.QTY].Value.ToString().Replace(",", ""))));
                            lblSplitQty.Text = MPCF.MakeNumberFormat((Convert.ToInt32(lblSplitQty.Text.Replace(",", "")) - Convert.ToInt32(spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.QTY].Value.ToString().Replace(",", ""))));

                            spdSplit.Sheets[0].Rows[i].Remove();
                        }
                    }

                    for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                    {
                        spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.SEQ].Value = i.ToString();
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

        ///// <summary>
        ///// Print Inventory Lot Label
        ///// </summary>
        ///// <returns></returns>
        //private bool PrintInvLotLabel()
        //{
        //    try
        //    {
        //        // Check Inventory Lot List
        //        if (CheckChildInvLotList() == false)
        //        {
        //            return false;
        //        }

        //        // Get Label ID
        //        string sLabelID = GetLabelID("INV_PRINT_LABEL_ID");
        //        if (sLabelID == string.Empty)
        //        {
        //            return false;
        //        }

        //        // Get Label Command
        //        string sLabelCommand = GetLabelCommand(sLabelID);
        //        if (sLabelCommand == string.Empty)
        //        {
        //            return false;
        //        }

        //        // Transfer Variable and Print Label
        //        if (TransferAndPrint(sLabelCommand) == false)
        //        {
        //            return false;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Check Row Count
        ///// </summary>
        ///// <returns></returns>
        //private bool CheckChildInvLotList()
        //{
        //    try
        //    {
        //        // No Data
        //        if (spdSplit.Sheets[0].Rows.Count < 1)
        //        {
        //            return false;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Get Labe ID
        ///// </summary>
        ///// <param name="gcmTable"></param>
        ///// <returns></returns>
        //private string GetLabelID(string gcmDataKey1)
        //{
        //    try
        //    {
        //        string sReturn = string.Empty;

        //        TRSNode in_node = new TRSNode("VIEW_LABEL_ID_IN");
        //        TRSNode out_node = new TRSNode("VIEW_LABEL_ID_OUT");

        //        // Call Service
        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("TABLE_NAME", "ATP_MES_OPTIONS");
        //        in_node.AddString("KEY_1", gcmDataKey1);

        //        if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
        //        {
        //            return string.Empty;
        //        }

        //        // No Data
        //        if (out_node.GetList(0) == null || out_node.GetList(0).Count < 1)
        //        {
        //            MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
        //            return string.Empty;
        //        }

        //        // Get Label ID
        //        List<TRSNode> labelIDList = out_node.GetList(0);
        //        foreach (TRSNode node in labelIDList)
        //        {
        //            sReturn = node.GetString("DATA_2");
        //            break;
        //        }

        //        // No Label ID String
        //        if (sReturn == string.Empty)
        //        {
        //            MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
        //            return string.Empty;
        //        }

        //        return sReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return string.Empty;
        //    }
        //}

        ///// <summary>
        ///// Get Label Command
        ///// </summary>
        ///// <param name="labelID"></param>
        ///// <returns></returns>
        //private string GetLabelCommand(string labelID)
        //{
        //    try
        //    {
        //        TRSNode in_node = new TRSNode("VIEW_LABEL_ID_IN");
        //        TRSNode out_node = new TRSNode("VIEW_LABEL_ID_OUT");

        //        // Call Service
        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("LABEL_ID", labelID);

        //        if (MPCF.CallService("LBL", "LBL_View_Label", in_node, ref out_node) == false)
        //        {
        //            return string.Empty;
        //        }

        //        // No Command String
        //        if (out_node.GetString("PRINT_COMMAND") == string.Empty)
        //        {
        //            MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
        //            return string.Empty;
        //        }

        //        return out_node.GetString("PRINT_COMMAND");
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return string.Empty;
        //    }
        //}

        ///// <summary>
        ///// Transfer Variable and Print
        ///// </summary>
        ///// <param name="labelCommand"></param>
        ///// <returns></returns>
        //private bool TransferAndPrint(string labelCommand)
        //{
        //    try
        //    {
        //        string replacedCommand = string.Empty;

        //        for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
        //        {
        //            // Clear
        //            replacedCommand = string.Empty;

        //            // Transfer
        //            replacedCommand = replacedCommand.Replace("$INV_LOT_ID$", spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value.ToString());

        //            // Print
        //            if (MPCF.PrintLabelByCommand(this, base.printOption, replacedCommand, 1, null) == false)
        //            {
        //                return false;
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //        return false;
        //    }
        //}

        /// <summary>
        /// Split Lot
        /// </summary>
        /// <returns></returns>
        private bool MultiSplitLot()
        {
            try
            {
                TRSNode in_node = new TRSNode("SPLIT_LOT_IN");
                TRSNode out_node = new TRSNode("SPLIT_LOT_OUT");
                TRSNode mappingNode = new TRSNode("MAPPING_NODE");
                List<int> successIndex = new List<int>();
                bool failedFlag = false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", txtInvLotID.Text);
                in_node.AddChar("INPUT_TYPE", 'T'); // T:InvLotID, L:Label ID
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", _InvLot.GetInt("LAST_ACTIVE_HIST_SEQ")); // only for T
                in_node.AddString("INV_MAT_ID", _InvLot.GetString("INV_MAT_ID"));
                in_node.AddInt("INV_MAT_VER", _InvLot.GetInt("INV_MAT_VER"));
                in_node.AddString("STORE_ID", _InvLot.GetString("STORE_ID"));

                for (int i = 0; i < spdSplit.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdSplit.Sheets[0].Cells[i, 0].Value == false)
                    {
                        continue;
                    }

                    if (spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value != null)
                    {
                        in_node.SetString("CHILD_INV_LOT_ID", spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.CHILD_LOT_ID].Value.ToString());
                    }
                    else
                    {
                        in_node.SetString("CHILD_INV_LOT_ID", string.Empty);
                    }

                    in_node.SetDouble("MOVE_QTY_1", MPCF.ToDbl(MPCF.DestroyNumberFormat(spdSplit.Sheets[0].Cells[i, (int)COL_SPLIT_LIST.QTY].Value.ToString())));

                    if (MPCF.CallService("ATP", "ATP_Split_Inv_Lot", in_node, ref  out_node) == false)
                    {
                        failedFlag = true;
                    }

                    // Service Failed
                    if (failedFlag == true)
                    {
                        break;
                    }
                    // Service Success
                    else
                    {
                        successIndex.Add(i);
                    }

                    in_node.SetInt("LAST_ACTIVE_HIST_SEQ", 0);

                    if (chkPrintLabel.Checked == true)
                    {
                        // Mapping Data
                        mappingNode.Init();
                        mappingNode.AddString("INV_LABEL_ID", out_node.GetString("CHILD_INV_LOT_ID"));

                        // Print Label
                        if (MPCF.PrintLabelByLabelID(this, base.printOption, "ATP_MES_OPTIONS", "INV_PRINT_LABEL_ID", mappingNode) == false)
                        {
                            return false;
                        }
                    }
                }

                // Remove Finish Row
                for (int i = successIndex.Count - 1; i >= 0; i--)
                {
                    spdSplit.Sheets[0].Rows[successIndex[i]].Remove();
                }
                
                // Fail Return
                if (failedFlag == true)
                {
                    return false;
                }

                // Re-search Inventory Lot
                if (ViewInvLot(txtInvLotID.Text) == false)
                {
                    return false;
                }

                // Success Message
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
    }
}
