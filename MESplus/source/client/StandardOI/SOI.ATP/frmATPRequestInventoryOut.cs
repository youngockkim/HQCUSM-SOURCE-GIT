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
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPRequestInventoryOut : SOIBaseForm03
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_INV_OUT_LIST
        {
            SEQ = 0,
            INV_MAT_ID,
            INV_MAT_DESC,
            PROD_REQ_QTY,
            SAFETY_QTY,
            INV_OUT_QTY,
            REQ_QTY,
            INV_QTY
        }

        #endregion

        #region Constructor

        public frmATPRequestInventoryOut()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Init Data
            DateTime dt = DateTime.Now;
            dtPlanDate.SetValueAsDateTime(dt);

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

        /// <summary>
        /// Transit Store CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvTransitStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_IN_STORE_IN");
                TRSNode out_node = new TRSNode("VIEW_IN_STORE_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("OPER_STORE_FLAG", 'Y');

                // CodeView Column Header Setup
                string[] header = new string[] { "Store ID", "Store Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };

                // Show
                cdvTransitStore.Text = cdvTransitStore.Show(cdvTransitStore, "In Store", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "STORE_ID");

                if (ViewRequestInventoryOutList() == false)
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
        /// Open Print Popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmATPRequestInventoryOutPrintPopup frm = new frmATPRequestInventoryOutPrintPopup();
            ATPReqInvOutPrintPopupModelList list;

            try
            {
                DateTime dt = DateTime.Now;

                // Validation
                if (spdInventoryOutList.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                frm.Owner = this;

                // Bind
                frm.model.PlanDate = dtPlanDate.Value.ToString();
                frm.model.Line = cdvTransitStore.Text;
                frm.model.PublishDate = dt.ToString();

                for (int i = 0; i < spdInventoryOutList.Sheets[0].Rows.Count; i++)
                {
                    list = new ATPReqInvOutPrintPopupModelList();

                    list.Seq = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.SEQ].Value);
                    list.InvMatID = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.INV_MAT_ID].Value);
                    list.InvMatDesc = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.INV_MAT_DESC].Value);
                    list.ProdReqQty = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.PROD_REQ_QTY].Value);
                    list.SafetyQty = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.SAFETY_QTY].Value);
                    list.InvOutQty = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.INV_OUT_QTY].Value);
                    list.ReqQty = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.REQ_QTY].Value);
                    list.InvQty = Convert.ToString(spdInventoryOutList.Sheets[0].Cells[i, (int)COL_INV_OUT_LIST.INV_QTY].Value);                    

                    if (frm.model.List == null)
                    {
                        frm.model.List = new List<ATPReqInvOutPrintPopupModelList>();
                    }

                    frm.model.List.Add(list);
                }

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        /// <summary>
        /// View Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(dtPlanDate, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvTransitStore, false) == false)
                {
                    return;
                }

                // View
                if (ViewRequestInventoryOutList() == false)
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

        #region Function

        /// <summary>
        /// View List
        /// </summary>
        /// <returns></returns>
        private bool ViewRequestInventoryOutList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_REQ_INV_OUT_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_INV_OUT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("WORK_DATE", dtPlanDate.GetValueAsString(8));
                in_node.AddString("TO_STORE_ID", cdvTransitStore.Text);

                if (MPCF.CallService("ATP", "ATP_View_Out_Request", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdInventoryOutList.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdInventoryOutList.Sheets[0].Rows.Count;
                        spdInventoryOutList.Sheets[0].RowCount++;

                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.SEQ].Value = (i+1).ToString();
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.PROD_REQ_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("REQUIRE_QTY"));
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.SAFETY_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("SAFETY_QTY"));
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.INV_OUT_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("OUT_QTY"));
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.REQ_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("REQUEST_QTY"));
                        spdInventoryOutList.Sheets[0].Cells[iRow, (int)COL_INV_OUT_LIST.INV_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("INV_QTY"));
                    }
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
