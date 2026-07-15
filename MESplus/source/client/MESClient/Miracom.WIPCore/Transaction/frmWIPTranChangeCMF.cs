using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

namespace Miracom.WIPCore
{

    public partial class frmWIPTranChangeCMF : Miracom.MESCore.TranForm02
    {
        #region " Constant Definition "
        private const string LOT = "LOT";
        private const string SUBLOT = "SUBLOT";

        private const short TRAN_CMF_COUNT = 20;
        #endregion

        #region " Variable Definition "
        private bool bLoadFlag;
        private string lstrOriginCellText;
        #endregion

        #region " Function Definition "
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char cStep)
        {
            if (MPCF.CheckValue(cboType, 1) == false)    return false;
            switch (MPCF.Trim(cboType.Text))
            {
                case LOT: 
                    if (MPCF.CheckValue(cdvLot, 1) == false)   return false;
                    break;
                case SUBLOT:
                    if (MPCF.CheckValue(cdvLot, 1) == false) return false;
                    if (MPCF.CheckValue(cdvSubLot, 1) == false) return false;
                    break;
            }

            switch (cStep)
            {
                case 'V':
                    break;
                case MPGC.MP_STEP_UPDATE:
                    bool bCheck = false;
                    int i, iRows = spdList.Sheets[0].RowCount;

                    for (i = 0; i < iRows; i++)
                    {
                        if (spdList.Sheets[0].Cells[i, 0].Value != null)
                        {
                            bCheck = true;
                            break;
                        }
                    }

                    if (!bCheck) return false;
                    break;
            }

            return true;
        }
        
        private bool View_CMF_Change()
        {
            try
            {
                TRSNode in_node = new TRSNode("View_CMF_Change_In");
                TRSNode out_node = new TRSNode("View_CMF_Change_Out");

                MPCF.ClearList(spdList, true);
                MPCF.FieldClear(grpCMF);

                MPCR.SetInMsg(in_node);

                switch (MPCF.Trim(cboType.Text))
                {
                    case LOT:
                        in_node.ProcStep = '1';
                        in_node.AddString("ITEM_NAME", MPGC.MP_CMF_LOT);
                        in_node.AddString("LOT_ID", MPCF.Trim(cdvLot.Text));
                        break;
                    case SUBLOT:
                        in_node.ProcStep = '2';
                        in_node.AddString("ITEM_NAME", MPGC.MP_CMF_SUBLOT);
                        in_node.AddString("SUBLOT_ID", MPCF.Trim(cdvSubLot.Text));
                        break;
                }

                if (MPCR.CallService("WIP", "WIP_View_CMF_Change", in_node, ref out_node) == false)
                {
                    return false;
                }

                int i, iRow;
                FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.Sheets[0].RowCount;
                    spdList.Sheets[0].RowCount++;

                    spdList.Sheets[0].Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("PMT");
                    spdList.Sheets[0].Cells[iRow, 2].Value = out_node.GetList(0)[i].GetString("VALUE");
                    spdList.Sheets[0].Cells[iRow, 3].Value = out_node.GetList(0)[i].GetString("VALUE");

                    if (out_node.GetList(0)[i].GetString("TBL") == "")
                    {
                        spdList.Sheets[0].AddSpanCell(iRow, 3, 1, 3);
                    }
                    else
                    {
                        btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnCell.Text = "...";
                        spdList.Sheets[0].Cells[iRow, 4].CellType = btnCell;
                        spdList.Sheets[0].Cells[iRow, 4].Tag = out_node.GetList(0)[i].GetString("TBL");
                    }

                    if (out_node.GetList(0)[i].GetString("PMT") == "")
                    {
                        spdList.Sheets[0].Cells[iRow, 3].BackColor = Color.WhiteSmoke;
                        spdList.Sheets[0].Cells[iRow, 3].Locked = true;
                    }

                    spdList.Sheets[0].Cells[iRow, 5].Value = out_node.GetList(0)[i].GetChar("OPT");
                    spdList.Sheets[0].Cells[iRow, 6].Value = out_node.GetList(0)[i].GetChar("FMT");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            

            return true;
        }

        private bool CMF_Change()
        {
            try
            {
                int i;
                TRSNode in_node = new TRSNode("LIST_IN");
                TRSNode out_node = new TRSNode("CMN_OUT");

                ArrayList cdvList;
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

                MPCR.SetInMsg(in_node);
                switch (MPCF.Trim(cboType.Text))
                {
                    case LOT:
                        in_node.ProcStep = '1';
                        in_node.AddString("LOT_ID", MPCF.Trim(cdvLot.Text));
                        break;
                    case SUBLOT:
                        in_node.ProcStep = '2';
                        in_node.AddString("LOT_ID", MPCF.Trim(cdvLot.Text));
                        in_node.AddString("SUBLOT_ID", MPCF.Trim(cdvSubLot.Text));
                        break;
                }

                for (i = 0; i < spdList.Sheets[0].RowCount; i++)
                {
                    in_node.AddString("LOT_CMF_" + ((int)(i + 1)).ToString(), (spdList.Sheets[0].GetValue(i, 3) != null) ? MPCF.Trim(spdList.Sheets[0].GetValue(i, 3)) : "");
                }

                cdvList = MPCF.GetIndexedControl("cdvCMF", grpCMF);

                for (i = 0; i < TRAN_CMF_COUNT; i++)
                {
                    cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];
                    in_node.AddString("TRAN_CMF_" + ((int)(i + 1)).ToString(), MPCF.Trim(cdvTemp.Text));
                }

                if (MPCR.CallService("WIP", "WIP_Change_CMF", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
        }
        #endregion

        public frmWIPTranChangeCMF()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(CheckCondition('V')) View_CMF_Change();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE))
                if (CMF_Change())
                {
                    View_CMF_Change();
                }
        }

        private void cdvLot_ButtonPress(object sender, EventArgs e)
        {
            //if (MPCF.CheckValue(cdvKey, 1) == false)
            //{
            //    return;
            //}

            cdvLot.Init();
            MPCF.InitListView(cdvLot.GetListView);
            cdvLot.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvLot.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLot.SelectedSubItemIndex = 0;
            WIPLIST.ViewLotList(cdvLot.GetListView, '1', MPCF.Trim(cdvOperation.Text), MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, null);
        }

        private void cdvSubLot_ButtonPress(object sender, EventArgs e)
        {
            cdvSubLot.Init();
            MPCF.InitListView(cdvSubLot.GetListView);
            if (MPCF.CheckValue(cdvLot, 1) == false) return;

            cdvSubLot.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvSubLot.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvSubLot.SelectedSubItemIndex = 0;
            WIPLIST.ViewSublotList(cdvSubLot.GetListView, '1', MPCF.Trim(cdvLot.Text), null);
        }

        private void cboType_TextChanged(object sender, EventArgs e)
        {
            switch (MPCF.Trim(cboType.Text))
            {
                case LOT:       lblLot.Visible = true; cdvLot.Visible = true; lblSubLot.Visible = false; cdvSubLot.Visible = false; break;
                case SUBLOT:    lblLot.Visible = true; cdvLot.Visible = true; lblSubLot.Visible = true; cdvSubLot.Visible = true; break;
                default:        lblLot.Visible = false; cdvLot.Visible = false; lblSubLot.Visible = false; cdvSubLot.Visible = false; break;
            }
            cdvMaterial.Text = cdvFlow.Text = cdvOperation.Text = "";
            cdvMaterial.Version = 0;
        }

        private void cdvLot_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cboType.Text) == LOT)
            {
                if (MPCF.Trim(cdvLot.Text) != "")
                {
                    View_CMF_Change();
                }
                else
                {
                    MPCF.ClearList(spdList, true);
                }
            }
        }

        private void cdvSubLot_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvSubLot.Text = e.SelectedItem.SubItems[1].Text;
            if (MPCF.Trim(cboType.Text) == SUBLOT)
            {
                if (MPCF.Trim(cdvLot.Text) != "" && MPCF.Trim(cdvSubLot.Text) != "")
                {
                    View_CMF_Change();
                }
                else
                {
                    MPCF.ClearList(spdList, true);
                }
            }
        }

        private void frmWIPTranChangeCMF_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmWIPTranChangeCMF_Activated(object sender, EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    if (!MPGO.MakeHistoryCMFChange())
                    {
                        tabCMF.TabPages.Remove(tabCMF.TabPages[1]);
                    }
                    else
                    {
                        MPCR.SetCMFItem(MPGC.MP_CMF_TRN_CHANGE_CMF, "lblCMF", "cdvCMF", grpCMF);
                    }

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCellOptFmt(int iRow, int iCol, string strValue)
        { 
            if (spdList.Sheets[0].GetText(iRow, iCol + 2) == "Y" && MPCF.Trim(strValue) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                spdList.Sheets[0].SetText(iRow, iCol, lstrOriginCellText);
                return false;
            }

            if (MPCF.CheckFormat(MPCF.ToChar(spdList.Sheets[0].GetValue(iRow, iCol + 3)), MPCF.Trim(strValue)) == false)
            {
                spdList.Sheets[0].SetText(iRow, iCol, "");
                return false;
            }

            return true;
        }

        private void cdvTableData_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            if (CheckCellOptFmt(e.Row, 3, e.SelectedItem.Text) == true)
            {
                //Modify by J.S. 2012.02.20 trim제거
                spdList.Sheets[0].Cells[e.Row, 3].Text = e.SelectedItem.Text;
                spdList.Sheets[0].Cells[e.Row, 0].Value = true;
            }
        }

        private void spdList_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdList.Sheets[0].Cells[e.Row, 0].Value = true;
            CheckCellOptFmt(e.Row, e.Column, e.EditingControl.Text);
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == 3) lstrOriginCellText = spdList.Sheets[0].GetText(e.Row, e.Column);
        }

        private void spdList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                cdvTableData.Init();
                cdvTableData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableData.GetListView);
                cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                cdvTableData.ViewPosition = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
                BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdList.Sheets[0].Cells[e.Row, e.Column].Tag));

                cdvTableData.ShowPopUp(e.Row, e.Column);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "");
            }
            else
            {
                if (cdvFlow.Text == "")
                {
                    if (cdvMaterial.Text == "")
                    {
                        WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
                    }
                    else
                    {
                        WIPLIST.ViewOperationList(cdvOperation.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "");
                    }
                }
                else
                {
                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, cdvFlow.Text, "", null, "");
                }
            }
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (cdvMaterial.Text == "")
            {
                cdvFlow.ListCond_Step = '1';
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = cdvOperation.Text = cdvLot.Text = cdvSubLot.Text = "";
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvOperation.Text = cdvLot.Text = cdvSubLot.Text = "";
        }

        private void cdvOperation_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvLot.Text = cdvSubLot.Text = "";
        }

        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

    }
}

