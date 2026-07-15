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

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPPrintLabel : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER_INFO");

        private string s_label_command = "";

        private List<string> OrderMemberList;
        private List<string> GeneratedLotIdList = new List<string>();

        private enum COL_PRINTED_LIST
        {
            SEQ = 1,
            PRINTED_ID,
            PRINT_TIME,
            COMMAND
        }

        #endregion

        #region Constructor

        public frmWIPPrintLabel()
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
            gridPrintLabel.InitDataSource();

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
                 MPCF.SetFocus(cdvLabelID);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Label CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLabelID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // CodeView
                TRSNode in_node = new TRSNode("VIEW_LABEL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "LABEL_ID", "LABEL_DESC" };
                string[] header = new string[] { "Label ID", "Label Desc" };
                cdvLabelID.Text = cdvLabelID.Show(cdvLabelID, "View Label List", "LBL", "LBL_View_Label_List", in_node, "LABEL_LIST", display, header, "Label ID");

                //// Close
                //if (cdvLabelID.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}

                // Clear
                MPCF.FieldClear(this, cdvLabelID);

                // Validation
                if (string.IsNullOrEmpty(cdvLabelID.Text) == true)
                {
                    return;
                }                

                // Get Label Command
                if (GetLabelCommand(cdvLabelID.Text) == false)
                {
                    return;
                }

                // View Print History
                if (ViewPrintHistory() == false)
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
        /// 선택된 Label ID로 재조회 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLabelIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvLabelID, false) == false)
                {
                    return;
                }

                // Field Clear
                MPCF.FieldClear(this, cdvLabelID);

                // Get Label Command
                if (GetLabelCommand(cdvLabelID.Text) == false)
                {
                    return;
                }

                // View Print History
                if (ViewPrintHistory() == false)
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
        /// Order ID Code View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // CodeView Service
                TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "View Order List", "ORD", "ORD_View_Order_List", in_node, "ORD_LIST", display, header, "Order ID");

                // Clear
                MPCF.FieldClear(txtLabelCount);

                // Validation
                if (string.IsNullOrEmpty(cdvOrderID.Text) == true)
                {
                    return;
                }

                // Get Order Information
                if (GetOrderInfo(cdvOrderID.Text) == false)
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
        /// Operation CodeView Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }

                // CodeView Service
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                // Validation
                if (string.IsNullOrEmpty(cdvOper.Text) == true)
                {
                    return;
                }                

                //// Get Rule
                //if (GetLotIdGenerationRule(cdvInOper.Text) == false)
                //{
                //    txtLotID.ReadOnly = false;
                //    btnGenLotID.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }        
        }

        /// <summary>
        /// Print Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvLabelID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtLabelCount, 0.0005, Double.MaxValue, false) == false)
                {
                    return;
                }

                // Lot ID Generation
                if (GenerateLotIds() == false)
                {
                    return;
                }

                // Print Label
                if (PrintLabel() == false)
                {
                    return;
                }

                // View Print History
                if (ViewPrintHistory() == false)
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
        /// Search Print ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPrintedID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Enter인 경우
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(cdvLabelID, false) == false)
                    {
                        return;
                    }
                    if (gridPrintLabel.Rows.Count < 1)
                    {
                        return;
                    }
                    if(MPCF.CheckValue(txtSearchPrintedID, false) == false)
                    {
                        return;
                    }

                    // Find Printed ID Row
                    if (FindGridRow(txtSearchPrintedID.Text) == false)
                    {
                        return;
                    }

                    // Focus
                    MPCF.SetFocus(txtSearchPrintedID);
                    txtSearchPrintedID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Select All Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridPrintLabel.Rows.Count < 1)
                {
                    return;
                }

                // CheckBox Check
                for (int i = 0; i < gridPrintLabel.Rows.Count; i++)
                {
                    gridPrintLabel.Rows[i].Cells[0].Value = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Release All Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReleaseAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridPrintLabel.Rows.Count < 1)
                {
                    return;
                }

                // CheckBox Uncheck
                for (int i = 0; i < gridPrintLabel.Rows.Count; i++)
                {
                    gridPrintLabel.Rows[i].Cells[0].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Reprint Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvLabelID, false) == false)
                {
                    return;
                }
                if (gridPrintLabel.Rows.Count < 1)
                {
                    return;
                }

                // Selected Item Check
                bool bSelected = false;
                for (int i = 0; i < gridPrintLabel.Rows.Count; i++)
                {
                    if(gridPrintLabel.Rows[i].Cells[0].Value != null)
                    {
                        if ((bool)gridPrintLabel.Rows[i].Cells[0].Value == true)
                        {
                            bSelected = true;
                            break;
                        }
                    }
                }
                if (bSelected == false)
                {
                    // Please, select at least one item.
                    MPCF.ShowMessage(MPCF.GetMessage(71), MSG_LEVEL.ERROR, false);
                    return;
                }

                // Reprint
                if (ReprintLabel() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool GetOrderInfo(string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");

            try
            {
                // Init
                OrderMemberList = new List<string>();
                ORDER.Init();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref ORDER) == false)
                {
                    return false;
                }

                // Bind Data
                foreach (TRSNode member in ORDER.Members)
                {
                    if (member.ValueType == TRSDataType.String
                        || member.ValueType == TRSDataType.Char
                        || member.ValueType == TRSDataType.Double
                        || member.ValueType == TRSDataType.Int
                        || member.ValueType == TRSDataType.Float
                        || member.ValueType == TRSDataType.Long)
                    {
                        OrderMemberList.Add(member.Name);
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

        /// <summary>
        /// View Print History
        /// </summary>
        /// <returns></returns>
        private bool ViewPrintHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_PRINT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_PRINT_HISTORY_OUT");
            DataTable dtGrid = null;
            DataRow dr = null;

            try
            {
                // Field Clear
                MPCF.FieldClear(txtSearchPrintedID);
                dtGrid = gridPrintLabel.GetDataSource();
                dtGrid.Rows.Clear();
                MPCF.FieldClear(txtPrintedCount);

                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", cdvLabelID.Text);
                if (MPCF.CallService("WIP", "WIP_View_Print_History_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind Data                
                foreach (TRSNode node in out_node.GetList(0))
                {
                    dr = dtGrid.NewRow();
                    dr[0] = false;
                    dr[(int)COL_PRINTED_LIST.SEQ] = node.GetInt("SEQ");
                    dr[(int)COL_PRINTED_LIST.PRINTED_ID] = node.GetString("PRINTED_ID");
                    dr[(int)COL_PRINTED_LIST.PRINT_TIME] = MPCF.MakeDateFormat(node.GetString("PRINT_TIME"));
                    dr[(int)COL_PRINTED_LIST.COMMAND] = node.GetString("COMMAND");
                    dtGrid.Rows.Add(dr);
                }                
                gridPrintLabel.DataBind();

                // Set Total Printed Count
                txtPrintedCount.Text = dtGrid.Rows.Count.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Generate Lot ID
        /// </summary>
        /// <returns></returns>
        private bool GenerateLotIds()
        {
            TRSNode in_node = new TRSNode("GENERATE_ID_BATCH_IN");
            TRSNode out_node = new TRSNode("GENERATE_ID_BATCH_OUT");

            try
            {
                // Clear
                GeneratedLotIdList.Clear();

                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", ORDER.GetString("MAT_ID"));                
                in_node.AddInt("MAT_VER", ORDER.GetInt("MAT_VER"));
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", ORDER.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "CREATE");
                in_node.AddInt("NUMBER_OF_ID", txtLabelCount.Text);
                if (MPCF.CallService("WIP", "WIP_Generate_Id_Batch", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Get Generated Ids & Save
                for (int i = 0; i < out_node.GetArray("GEN_ID_LIST").MemberCount; i++)
                {
                    GeneratedLotIdList.Add(out_node.GetArray("GEN_ID_LIST").GetString(i.ToString()));
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
        /// Print Label
        /// </summary>
        private bool PrintLabel()
        {
            string replacedCommand = string.Empty;
            string memberValue = string.Empty;
            string delimiterVar = string.Empty;

            try
            {
                // Print
                foreach (string lotId in GeneratedLotIdList)
                {            
                    // Replace LOT_ID
                    replacedCommand = s_label_command.Replace(delimiterVar + "LOT_ID" + delimiterVar, lotId);

                    foreach (string name in OrderMemberList)
                    {
                        memberValue = ORDER.GetMember(name).Value;
                        replacedCommand = replacedCommand.Replace("$" + name + "$", memberValue);
                    }

                    if (Print(replacedCommand) == false)
                    {
                        return false;
                    }

                    if (InsertPrintHistory(lotId, replacedCommand) == false)
                    {
                        return false;
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

        /// <summary>
        /// Get Label Command
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        private bool GetLabelCommand(string labelId)
        {
            TRSNode in_node = new TRSNode("VIEW_LABEL_IN");
            TRSNode out_node = new TRSNode("VIEW_LABEL_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", labelId);

                if (MPCF.CallService("LBL", "LBL_View_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                s_label_command = out_node.GetString("PRINT_COMMAND");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Print
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool Print(string command)
        {
            try
            {
                if (MPCF.PrintLabelByCommand(this, base.printOption, command, 1, null) == false)
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
        /// Insert Print History
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool InsertPrintHistory(string lotId, string command)
        {
            TRSNode in_node = new TRSNode("UPDATE_PRINT_HISTORY_IN");
            TRSNode out_node = new TRSNode("UPDATE_PRINT_HISTORY_OUT");

            try
            {
                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("LABEL_ID", cdvLabelID.Text);
                in_node.AddString("PRINTED_ID", lotId);
                in_node.AddString("COMMAND", command);
                if (MPCF.CallService("WIP", "WIP_Update_Print_History", in_node, ref out_node) == false)
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
        /// Re Print Label
        /// </summary>
        private bool ReprintLabel()
        {
            DataTable dtGrid = null;

            try
            {
                // Get Grid Data
                dtGrid = gridPrintLabel.GetDataSource();

                // Validation
                if (dtGrid.Rows.Count < 1)
                {
                    return false;
                }

                // Reprint
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    // 체크된 경우
                    if ((bool)dtGrid.Rows[i][0] == true)
                    {
                        if (dtGrid.Rows[i][(int)COL_PRINTED_LIST.SEQ] != null
                            && dtGrid.Rows[i][(int)COL_PRINTED_LIST.COMMAND] != null)
                        {
                            if (Print(dtGrid.Rows[i][(int)COL_PRINTED_LIST.COMMAND].ToString()) == false)
                            {
                                return false;
                            }
                        }
                    }
                }

                // 4. View Print History
                if (ViewPrintHistory() == false)
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
        /// Select Print History
        /// </summary>
        /// <param name="printedId"></param>
        private bool FindGridRow(string printedId)
        {
            try
            {
                for (int i = 0; i < gridPrintLabel.Rows.Count; i++)
                {
                    if (gridPrintLabel.Rows[i].Cells[(int)COL_PRINTED_LIST.PRINTED_ID].Value != null)
                    {
                        if (gridPrintLabel.Rows[i].Cells[(int)COL_PRINTED_LIST.PRINTED_ID].Value.ToString() == printedId)
                        {
                            // Check Box Check
                            gridPrintLabel.Rows[i].Cells[0].Value = true;
                            MPCF.SetScrollRow(gridPrintLabel, gridPrintLabel.Rows[i].Cells[(int)COL_PRINTED_LIST.PRINTED_ID].Column.Key, printedId);
                            break;
                        }
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

        #endregion
    }
}
