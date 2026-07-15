using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using BOI.OIFrx;
using SOI.DNM;
using BOI.COMCus;
using BOI.OIFrx.BOIControls;

namespace BOI.WIPCus.Popup
{
    public partial class frmWIPInputLossQty : frmPopupBase
    {
        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        private enum INV_LOT_COL
        {
            MAT_ID = 0,
            MAT_DESC,
            UNIT_1,
            MAT_GRP_1,
            MAT_GRP_2,
            MAT_GRP_3
        }
        public string OUT_MAT_ID = "";
        public string OUT_MAT_DESC = "";
        public string OUT_MAT_UNIT_1 = "";
        public string mat_property = "";

        private bool bCheckAll = false;
        private string oper = "";

        public frmWIPInputLossQty()
        {
            InitializeComponent();
        }

        public frmWIPInputLossQty(string s_inv_lot, string s_oper)
        {
            InitializeComponent();
            ViewAssemblyList(s_inv_lot);
            oper = s_oper;
            
        }

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }
       

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "ADD_ROW":

                        if (spdInvLot.Sheets[0].RowCount < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(429), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        //cdvLossCode
                        if (MPCF.Trim(cdvLossCode.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLossCode.Focus();
                            return false;
                        }

                        //txtLossQty
                        if (MPCF.ToDbl(txtLossQty.Text) <=0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(434), MSG_LEVEL.WARNING, true); // 손실 수량이 0보다 작을수 없습니다.
                            cdvLossCode.Focus();
                            return false;
                        }
                        break;

                        case "LOSS_LOT":

                        if (spdInvLot.Sheets[0].RowCount < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(429), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        //cdvLossCode
                        if (MPCF.Trim(cdvLossCode.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLossCode.Focus();
                            return false;
                        }

                        //txtLossQty
                        if (MPCF.ToDbl(txtLossQty.Text) <=0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(434), MSG_LEVEL.WARNING, true); // 손실 수량이 0보다 작을수 없습니다.
                            cdvLossCode.Focus();
                            return false;
                        }

                        break;
                   
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }


        private void spdInvLot_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdInvLot.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;
                OUT_MAT_ID = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_ID].Text;
                OUT_MAT_DESC = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_DESC].Text;
                OUT_MAT_UNIT_1 = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.UNIT_1].Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void comSwitch1_Com_1_DataReceived_1(string aData)
        {
            KeyPressEventArgs e1 = new KeyPressEventArgs((char)Keys.Enter);
            try
            {
                txtLossQty.Value = MPCF.ToDbl(aData);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
                
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOSS_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", oper);
                in_node.AddString("COL_GRP_1", BIGC.B_COL_GRP_1_MB);

                // CodeView Column Header Setup
                string[] header = new string[] { "Loss Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "LOSS_CODE", "LOSS_DESC" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss", "BWIP", "BWIP_View_Collection_Character", in_node, "DATA_LIST", display, header, "LOSS_DESC");

                if (MPCF.Trim(cdvLossCode.Text) != "")
                {
                    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                    {
                        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                        cdvLossCode.Text = cdvLossCode.returnDatas[1];

                        txtLossQty.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (bCheckAll == false)
                {
                    for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                    {
                        spdLossList.Sheets[0].Cells[i, 0].Value = true;
                    }

                    bCheckAll = true;
                    btnCheckAll.Text = "Uncheck All";
                }
                else
                {
                    for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                    {
                        spdLossList.Sheets[0].Cells[i, 0].Value = false;
                    }

                    bCheckAll = false;
                    btnCheckAll.Text = "Check All";
                }

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSelectDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdLossList.ActiveSheet.RowCount; i++)
                {
                    if ((Boolean)spdLossList.ActiveSheet.Cells[i, 0].Value == true)
                    {
                        spdLossList.ActiveSheet.Rows[i].Remove();
                        i--;
                    }
                }
                //for (int i = 0; i < spdLossList.ActiveSheet.RowCount; i++)
                //{
                //    spdLossList.ActiveSheet.Cells[i, 1].Value = i + 1;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        // Loss_Lot()
        //       - Loss Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Loss_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("LOSS_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                
                in_node.AddString("LOT_ID", MPCF.Trim(spdInvLot.ActiveSheet.Cells[0,0].Text));
                in_node.AddString("LOSS_CODE_TYPE", BIGC.B_LOSS_CODE_TYPE_I);

                for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                {
                    if ((bool)spdLossList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        list_item = in_node.AddNode("UNIT1");
                        list_item.AddString("CODE", MPCF.Trim(spdLossList.Sheets[0].Cells[i, 1].Value));
                        list_item.AddString("CODE_DESC", MPCF.Trim(spdLossList.Sheets[0].Cells[i, 2].Value));
                        list_item.AddDouble("QTY", MPCF.Trim(spdLossList.Sheets[0].Cells[i, 3].Value));
                    }
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Loss_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvLossCode.Text = "";
                cdvLossCode.Tag = "";
                txtLossQty.Value = txtLossQty.NullText;
                spdLossList.ActiveSheet.RowCount = 0;
                ViewAssemblyList(MPCF.Trim(spdInvLot.ActiveSheet.Cells[0, 0].Text));

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void ViewAssemblyList(string lotId)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {
                spdLossList.ActiveSheet.RowCount = 0;
                spdInvLot_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = lotId;



                if (TPDR.GetDataOne("", ref dt, "CWIP8040-004", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdInvLot_Sheet1.RowCount++;
                    spdInvLot_Sheet1.Cells[i, 0].Value = MPCF.Trim(dt.Rows[i][0].ToString());
                    spdInvLot_Sheet1.Cells[i, 1].Value = MPCF.ToDbl(dt.Rows[i][1].ToString());
                    spdInvLot_Sheet1.Cells[i, 2].Value = MPCF.ToDbl(dt.Rows[i][2].ToString());
                    spdInvLot_Sheet1.Cells[i, 3].Value = MPCF.ToDbl(dt.Rows[i][3].ToString());
                    spdInvLot_Sheet1.Cells[i, 4].Value = MPCF.Trim(dt.Rows[i][4].ToString());
                    spdInvLot_Sheet1.Cells[i, 5].Value = MPCF.ToDate(dt.Rows[i][5].ToString()).ToString("yyyy-MM-dd");
                }
                MPCF.FitColumnHeader(spdInvLot);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSetWeight_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (CheckCondition("ADD_ROW") == true)
                    {
                        spdLossList.ActiveSheet.AddRows(0, 1);
                        spdLossList.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 0].Value = true;
                        spdLossList.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 2].Text = MPCF.Trim(cdvLossCode.Text);
                        spdLossList.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 1].Text = MPCF.Trim(cdvLossCode.Tag);
                        spdLossList.ActiveSheet.Cells[spdInvLot.ActiveSheet.RowCount - 1, 3].Value = MPCF.ToDbl(txtLossQty.Value);
                    }

                }
                catch (Exception ex)
                {
                    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition("LOSS_LOT") == true)
            {
                if (Loss_Lot('1') == false)
                {
                    return;
                }
            }
        }
    }
}
