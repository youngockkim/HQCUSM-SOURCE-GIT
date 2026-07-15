using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupCustomizedField : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupCustomizedField()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const string GCM_GRP_TABLE_NAME = "GROUP_ITEM_NAME";
        private const string GCM_CMF_TABLE_NAME = "CMF_ITEM_NAME";
        private const string GCM_FACTORY_TYPE = "FACTORY_TYPE";
        private const string _DEFAULT_GCM_TABLE = "Default GCM Table";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool bCellEdit;

        #endregion

        #region " Function Definition "

        // initCodeView()
        //       -   initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //       -
        private void initCodeView()
        {
            cdvTableList.Init();
            MPCF.InitListView(cdvTableList.GetListView);
            cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
            BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1');
        }

        // Get_FacCmf_Data()
        //       - Get FacCmf Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal iStep As Integer : Group = 1, Cmf = 2
        //        - ByVal sItemName As String : Item Name
        //
        private void Get_FacCmf_Data(char c_step, string sItemName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");            
            int i;
            FarPoint.Win.Spread.CellType.TextCellType sheettxt = null;
           
            if (c_step == '2')
            {
                MPCF.ClearList(spdCmfDef, true);
                if (sItemName.IndexOf("FKT-") >= 0)
                {
                    spdCmfDef.ActiveSheet.RowCount = 5;
                }
                else
                {
                    txtCmfDesc.Text = lisCmfList.SelectedItems[0].SubItems[1].Text;
                    txtCmfType.Text = lisCmfList.SelectedItems[0].SubItems[2].Text;
                    txtCmfCount.Text = lisCmfList.SelectedItems[0].SubItems[3].Text;

                    spdCmfDef.ActiveSheet.RowCount = MPCF.ToInt(lisCmfList.SelectedItems[0].SubItems[3].Text);
                }
            }

            if (WIPLIST.ViewFactoryCmfData('1', sItemName, ref out_node, "", true) == false)
            {
                return;
            }

            if (c_step == '2')
            {
                spdCmfDef.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    sheettxt = new FarPoint.Win.Spread.CellType.TextCellType();
                    sheettxt.MaxLength = 20;
                    spdCmfDef.ActiveSheet.Cells[i, 0].CellType = sheettxt;

                    spdCmfDef.ActiveSheet.Cells[i, 0].Value = out_node.GetList(0)[i].GetString("PROMPT");
                    spdCmfDef.ActiveSheet.Cells[i, 1].Value = out_node.GetList(0)[i].GetChar("OPT");
                    switch (out_node.GetList(0)[i].GetChar("FORMAT"))
                    {
                        case 'A':

                            spdCmfDef.ActiveSheet.Cells[i, 2].Value = "Ascii";
                            break;
                        case 'N':

                            spdCmfDef.ActiveSheet.Cells[i, 2].Value = "Number";
                            break;
                        case 'F':

                            spdCmfDef.ActiveSheet.Cells[i, 2].Value = "Float";
                            break;
                    }
                    spdCmfDef.ActiveSheet.Cells[i, 3].CellType = sheettxt;
                    spdCmfDef.ActiveSheet.Cells[i, 3].Value = out_node.GetList(0)[i].GetString("TABLE_NAME");
                }
            }
        }

        // Update_Factory_Cmf()
        //       - Update Factory Customized Field Value
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal iStep As Integer : Cmf = 2
        //        - ByVal c_step As String : MP_STEP_CREATE/UPDATE/DELETE
        //        - ByVal sItemName As String : MWIPFACCMF??Item Name
        private bool Update_Factory_Cmf(int iStep, char c_step, string sItemName)
        {
            TRSNode in_node = new TRSNode("UPDATE_CMF_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("ITEM_NAME", MPCF.Trim(sItemName));

            if (iStep == 2)
            {
                FarPoint.Win.Spread.SheetView with_1 = spdCmfDef.Sheets[0];
                for (i = 0; i < with_1.RowCount; i++)
                {
                    list_item = in_node.AddNode("LIST");

                    list_item.AddString("PROMPT", MPCF.Trim(with_1.GetValue(i, 0)));
                    list_item.AddChar("OPT", MPCF.ToChar(with_1.GetValue(i, 1)));
                    list_item.AddChar("FORMAT", MPCF.ToChar(with_1.GetValue(i, 2)));
                    list_item.AddString("TABLE_NAME", MPCF.Trim(with_1.GetValue(i, 3)));                    
                }
            }

            if (MPCR.CallService("WIP", "WIP_Update_Factory_Cmf_Item", in_node, ref out_node) == false)
            {
                return false;
            }

            if (c_step != 'D')
            {
                MPCR.ShowSuccessMsg(out_node);
            }

            return true;

        }

        //
        // Update_CMF_Item()
        //       - Create/Update/Delete CMF Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_CMF_Item(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TABLE_NAME", "CMF_ITEM_NAME");
                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", txtCmfItem.Text);
                node.AddString("DATA_1", txtCmfDesc.Text);             // CMF Desc  
                node.AddString("DATA_2", txtCmfType.Text);
                node.AddString("DATA_3", txtCmfCount.Text);

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (ProcStep == 'D')
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool View_Data_List(string s_table_name)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;
            ListViewItem itmX;
            ArrayList a_list;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", s_table_name);

                a_list = new ArrayList();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetString("NEXT_KEY_3", out_node.GetString("NEXT_KEY_3"));
                    in_node.SetString("NEXT_KEY_4", out_node.GetString("NEXT_KEY_4"));
                    in_node.SetString("NEXT_KEY_5", out_node.GetString("NEXT_KEY_5"));
                    in_node.SetString("NEXT_KEY_6", out_node.GetString("NEXT_KEY_6"));
                    in_node.SetString("NEXT_KEY_7", out_node.GetString("NEXT_KEY_7"));
                    in_node.SetString("NEXT_KEY_8", out_node.GetString("NEXT_KEY_8"));
                    in_node.SetString("NEXT_KEY_9", out_node.GetString("NEXT_KEY_9"));
                    in_node.SetString("NEXT_KEY_10", out_node.GetString("NEXT_KEY_10"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));


                } while (in_node.GetString("NEXT_KEY_1") != "" ||
                         in_node.GetString("NEXT_KEY_2") != "" ||
                         in_node.GetString("NEXT_KEY_3") != "" ||
                         in_node.GetString("NEXT_KEY_4") != "" ||
                         in_node.GetString("NEXT_KEY_5") != "" ||
                         in_node.GetString("NEXT_KEY_6") != "" ||
                         in_node.GetString("NEXT_KEY_7") != "" ||
                         in_node.GetString("NEXT_KEY_8") != "" ||
                         in_node.GetString("NEXT_KEY_9") != "" ||
                         in_node.GetString("NEXT_KEY_10") != "" ||
                         in_node.GetInt("NEXT_ROW") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem("FKT-" + out_node.GetList(0)[i].GetString("KEY_1"), (int)SMALLICON_INDEX.IDX_KEY);
                        lisCmfList.Items.Add(itmX);
                    }

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        private void frmWIPSetupCustomizedField_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisCmfList);
                MPCF.ClearList(spdCmfDef, true);
                spdCmfDef.ActiveSheet.RowCount = 1;

                initCodeView();

                BASLIST.ViewGCMDataList(lisCmfList, '1', GCM_CMF_TABLE_NAME, (int)SMALLICON_INDEX.IDX_CODE_DATA, null, "", true, -1, -1, null);
                View_Data_List(MPGC.MP_FUNC_KEY_TYPE);

                b_load_flag = true;

                lblDataCount.Text = lisCmfList.Items.Count.ToString();
            }
        }

        private void lisCmfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);

                if (lisCmfList.SelectedItems.Count > 0)
                {                    
                    txtCmfItem.Text = lisCmfList.SelectedItems[0].Text;           
                    
                    Get_FacCmf_Data('2', txtCmfItem.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_CMF_Item(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                Update_Factory_Cmf(2, MPGC.MP_STEP_UPDATE, txtCmfItem.Text);

                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }     
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lisCmfList.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisCmfList.Items[0].Selected = true;
                    return;
                }

                if (Update_CMF_Item(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                Update_Factory_Cmf(2, MPGC.MP_STEP_UPDATE, txtCmfItem.Text);
                Get_FacCmf_Data('2', txtCmfItem.Text);

                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (MPCF.Trim(spdCmfDef.ActiveSheet.Cells[0, 0].Value) != "")
                {
                    if (Update_Factory_Cmf(2, MPGC.MP_STEP_DELETE, txtCmfItem.Text) == false)
                    {
                        return;                        
                    }
                }

                if (Update_CMF_Item(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
                
                MPCF.FieldClear(this.pnlCmfItem);
                MPCF.ClearList(spdCmfDef, true);
                spdCmfDef.ActiveSheet.RowCount = 1;
                                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisCmfList, txtFind.Text, 0, true, false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisCmfList, txtFind.Text, true, false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
            
                if (BASLIST.ViewGCMDataList(lisCmfList, '1', GCM_CMF_TABLE_NAME, (int)SMALLICON_INDEX.IDX_CODE_DATA, null, "", true, -1, -1, null) == false)
                {
                    return;
                }
                View_Data_List(MPGC.MP_FUNC_KEY_TYPE);

                lblDataCount.Text = lisCmfList.Items.Count.ToString();
                if (lisCmfList.Items.Count > 0)
                {
                    MPCF.FindListItem(lisCmfList, txtCmfItem.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisCmfList, this.Text, "");
        }

        private void spdCmfDef_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (bCellEdit == false && (e.Column == 0 || e.Column == 3))
            {
                if (spdCmfDef.EditModePermanent == true)
                {
                    return;
                }
            }

            if (bCellEdit == true && (e.Column == 0 || e.Column == 3))
            {
                spdCmfDef.EditModePermanent = true;
                if (spdCmfDef.ActiveSheet.RowCount > 0)
                {
                    spdCmfDef.EditMode = true;
                }
                bCellEdit = false;
            }
            else
            {
                spdCmfDef.EditModePermanent = false;
                bCellEdit = true;
            }
        }

        private void spdCmfDef_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Row == e.NewRow && e.Column == e.NewColumn)
            {
                return;
            }

            if (e.NewColumn == 0 || e.NewColumn == 3)
            {
                bCellEdit = true;
            }
            else
            {
                bCellEdit = false;
            }

            if (this.ActiveControl.Name.ToUpper() == "BTNCREATE" || this.ActiveControl.Name.ToUpper() == "BTNUPDATE" || this.ActiveControl.Name.ToUpper() == "BTNDELETE" || this.ActiveControl.Name.ToUpper() == "BTNCLOSE")
            {
                spdCmfDef.EditModePermanent = false;
                bCellEdit = false;
            }
        }

        private void spdCmfDef_MouseDown(object sender, MouseEventArgs e)
        {
             if (e.X < spdCmfDef.ActiveSheet.RowHeader.Columns[0].Width)
             {
                 spdCmfDef.EditModePermanent = false;
                 spdCmfDef.ActiveSheet.ActiveColumnIndex = 1;
                 bCellEdit = false;
             }

             if (e.Button == System.Windows.Forms.MouseButtons.Right)
             {
                 ctxSpread.Show(spdCmfDef, new Point(e.X, e.Y));
                 bCellEdit = false;
             }
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            int i;
            int iSelectRowCnt;

            FarPoint.Win.Spread.SheetView with_1 = spdCmfDef.Sheets[0];
            if (with_1.SelectionCount <= 0)
            {
                return;
            }

            iSelectRowCnt = 0;
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (with_1.IsSelected(i, 1) == true)
                {
                    iSelectRowCnt++;
                }
            }
            if (iSelectRowCnt == 0)
            {
                return;
            }
            with_1.ClearRange(with_1.ActiveRow.Index, 0, iSelectRowCnt, with_1.ColumnCount, true);

        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            int i;
            int iSelectRowCnt;

            FarPoint.Win.Spread.SheetView with_1 = spdCmfDef.Sheets[0];
            if (with_1.SelectionCount <= 0)
            {
                return;
            }

            iSelectRowCnt = 0;
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (with_1.IsSelected(i, 1) == true)
                {
                    iSelectRowCnt++;
                }
            }

            if (iSelectRowCnt == 0)
            {
                return;
            }
            with_1.ClearRange(with_1.ActiveRow.Index, 0, iSelectRowCnt, with_1.ColumnCount, true);

        }

        private void spdCmfDef_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, MCSSCodeViewSelChanged_EventArgs e)
        {
            spdCmfDef.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
        }





    }
}
