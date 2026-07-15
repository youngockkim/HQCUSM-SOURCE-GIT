using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.DNMCore
{
    public partial class frmDNMViewDynamicMenu : Miracom.MESCore.ViewForm01
    {
        public frmDNMViewDynamicMenu()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "
        private int i_cond_cnt=0;
        public string VIEWID = "";
        private bool b_load_flag = false;
        #endregion

        #region " Function Definition "
        private bool ViewFunction()
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", this.Tag.ToString());

                if (MPCR.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }

                VIEWID = MPCF.Trim(out_node.GetString("CTL_NAME_10"));
                this.Text = MPCF.Trim(out_node.GetString("FUNC_DESC"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        //
        // ViewDirectViewConditionList()
        //       - View Direct View Condition List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewConditionList()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_CONDITION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_CONDITION_LIST_OUT");

            int i;
            double dCount;
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCell;

            try
            {
                spdCondition.ActiveSheet.RowCount = 0;


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("VIEW_ID", VIEWID);

                do
                {

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_Condition_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdCondition.ActiveSheet.RowCount=0;

                    i_cond_cnt = out_node.GetList("LIST").Count;

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            spdCondition.ActiveSheet.RowCount++;
                            spdCondition.ActiveSheet.Cells[i/2, 1].Tag = out_node.GetList("LIST")[i].GetString("COND_NAME");
                            spdCondition.ActiveSheet.Cells[i / 2, 0].Text = out_node.GetList("LIST")[i].GetString("COND_DESC");

                            if (out_node.GetList("LIST")[i].GetChar("REQ_FLAG") == 'Y')
                            {
                                spdCondition.ActiveSheet.Cells[i / 2, 0].Tag = "REQ";
                                //spdCondition.ActiveSheet.Cells[i / 2, 0].BackColor = Color.LightSalmon;
                                spdCondition.ActiveSheet.Cells[i / 2, 0].Font = new Font(spdCondition.Font, FontStyle.Bold);
                            }

                            if (out_node.GetList("LIST")[i].GetString("DATA_TBL") != "")
                            {
                                if (out_node.GetList("LIST")[i].GetString("DATA_TBL") == "$FROM_DATE" ||
                                    out_node.GetList("LIST")[i].GetString("DATA_TBL") == "TO_DATE")
                                {

                                    dateCell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                                    dateCell.DropDownButton = true;
                                    spdCondition.ActiveSheet.Cells[i / 2, 1].ColumnSpan = 2;
                                    spdCondition.ActiveSheet.Cells[i / 2, 1].CellType = dateCell;
                                    spdCondition.ActiveSheet.Cells[i / 2, 2].Tag = out_node.GetList("LIST")[i].GetString("DATA_TBL");

                                    if (out_node.GetList("LIST")[i].GetString("DATA_TBL") == "$FROM_DATE")
                                    {
                                        spdCondition.ActiveSheet.Cells[i / 2, 1].Value = DateTime.Today.AddDays(-7);
                                    }
                                    else
                                    {
                                        spdCondition.ActiveSheet.Cells[i / 2, 1].Value = DateTime.Today;
                                    }
                                }
                                else
                                {
                                    spdCondition.ActiveSheet.Cells[i / 2, 2].Tag = out_node.GetList("LIST")[i].GetString("DATA_TBL");
                                    spdCondition.ActiveSheet.Cells[i / 2, 1].ColumnSpan = 1;
                                }
                            }
                            else
                            {
                                spdCondition.ActiveSheet.Cells[i / 2, 1].ColumnSpan = 2;
                                spdCondition.ActiveSheet.Cells[i / 2, 2].Tag = "";
                                //spdCondition.ActiveSheet.Cells[i / 2, 1].Tag = out_node.GetList("LIST")[i].GetString("DATA_TYPE");

                                FarPoint.Win.Spread.CellType.TextCellType clType = new FarPoint.Win.Spread.CellType.TextCellType();
                                if (out_node.GetList("LIST")[i].GetString("DATA_TYPE") == "String")
                                {
                                    clType.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    spdCondition.ActiveSheet.Cells[i / 2, 1].CellType = clType;
                                }
                                else
                                {
                                    clType.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    spdCondition.ActiveSheet.Cells[i / 2, 1].CellType = clType;
                                }
                                
                            }
                            if (i == out_node.GetList("LIST").Count-1)
                            {
                                spdCondition.ActiveSheet.Cells[i / 2, 3].ColumnSpan = 4;
                            }
                        }
                        else
                        {
                            spdCondition.ActiveSheet.Cells[i / 2, 5].Tag = out_node.GetList("LIST")[i].GetString("COND_NAME");
                            spdCondition.ActiveSheet.Cells[i / 2, 4].Text = out_node.GetList("LIST")[i].GetString("COND_DESC");

                            if (out_node.GetList("LIST")[i].GetChar("REQ_FLAG") == 'Y')
                            {
                                spdCondition.ActiveSheet.Cells[i / 2, 4].Tag = "REQ";
                                //spdCondition.ActiveSheet.Cells[i / 2, 4].BackColor = Color.LightSalmon;
                                spdCondition.ActiveSheet.Cells[i / 2, 4].Font = new Font(spdCondition.Font, FontStyle.Bold);
                            }

                            if (out_node.GetList("LIST")[i].GetString("DATA_TBL") != "")
                            {

                                if (out_node.GetList("LIST")[i].GetString("DATA_TBL") == "$FROM_DATE" ||
                                    out_node.GetList("LIST")[i].GetString("DATA_TBL") == "TO_DATE")
                                {

                                    dateCell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                                    dateCell.DropDownButton = true;
                                    spdCondition.ActiveSheet.Cells[i / 2, 5].ColumnSpan = 2;
                                    spdCondition.ActiveSheet.Cells[i / 2, 5].CellType = dateCell;
                                    spdCondition.ActiveSheet.Cells[i / 2, 6].Tag = out_node.GetList("LIST")[i].GetString("DATA_TBL");

                                    if (out_node.GetList("LIST")[i].GetString("DATA_TBL") == "$FROM_DATE")
                                    {
                                        spdCondition.ActiveSheet.Cells[i / 2, 5].Value = DateTime.Today.AddDays(-7);
                                    }
                                    else
                                    {
                                        spdCondition.ActiveSheet.Cells[i / 2, 5].Value = DateTime.Today;
                                    }
                                }
                                else
                                {
                                    spdCondition.ActiveSheet.Cells[i / 2, 6].Tag = out_node.GetList("LIST")[i].GetString("DATA_TBL");
                                    spdCondition.ActiveSheet.Cells[i / 2, 5].ColumnSpan = 1;
                                }
                            }
                            else
                            {
                                spdCondition.ActiveSheet.Cells[i / 2, 5].ColumnSpan = 2;
                                spdCondition.ActiveSheet.Cells[i / 2, 6].Tag = "";
                                //spdCondition.ActiveSheet.Cells[i / 2, 5].Tag = out_node.GetList("LIST")[i].GetString("DATA_TYPE");

                                FarPoint.Win.Spread.CellType.TextCellType clType = new FarPoint.Win.Spread.CellType.TextCellType();
                                if (out_node.GetList("LIST")[i].GetString("DATA_TYPE") == "String")
                                {
                                    clType.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    spdCondition.ActiveSheet.Cells[i / 2, 5].CellType = clType;
                                }
                                else
                                {
                                    clType.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    spdCondition.ActiveSheet.Cells[i / 2, 5].CellType = clType;
                                }

                            }
                        }
                    }

                    in_node.SetInt("NEXT_COND_SEQ", out_node.GetInt("NEXT_COND_SEQ"));

                } while (in_node.GetInt("NEXT_COND_SEQ") != 0);

                dCount = i_cond_cnt;

                splitContainer1.SplitterDistance = 15+ (int)Math.Ceiling(dCount / 2) * 17;
                spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            int i = 0;
            DataTable dt = new DataTable();
            try
            {
                TPDR.DirectViewCond[] a = new TPDR.DirectViewCond[i_cond_cnt];

                for (i = 0; i < i_cond_cnt; i++)
                {
                    if (i % 2 == 0)
                    {
                        a[i].sCondtion_ID = spdCondition.ActiveSheet.Cells[i / 2, 1].Tag.ToString();

                        if (spdCondition.ActiveSheet.Cells[i / 2, 2].Tag.ToString() == "$FROM_DATE")
                            a[i].sCondition_Value = MPCF.FromDate(spdCondition.ActiveSheet.Cells[i / 2, 1].Value);
                        else if (spdCondition.ActiveSheet.Cells[i / 2, 2].Tag.ToString() == "$TO_DATE")
                            a[i].sCondition_Value = MPCF.ToDate(spdCondition.ActiveSheet.Cells[i / 2, 1].Value);
                        else
                            a[i].sCondition_Value = spdCondition.ActiveSheet.Cells[i / 2, 1].Text;
                    }
                    else
                    {
                        a[i].sCondtion_ID = spdCondition.ActiveSheet.Cells[i / 2, 5].Tag.ToString();

                        if (spdCondition.ActiveSheet.Cells[i / 2, 6].Tag.ToString() == "$FROM_DATE")
                            a[i].sCondition_Value = MPCF.FromDate(spdCondition.ActiveSheet.Cells[i / 2, 5].Value);
                        else if (spdCondition.ActiveSheet.Cells[i / 2, 6].Tag.ToString() == "$TO_DATE")
                            a[i].sCondition_Value = MPCF.ToDate(spdCondition.ActiveSheet.Cells[i / 2, 5].Value);
                        else
                            a[i].sCondition_Value = spdCondition.ActiveSheet.Cells[i / 2, 5].Text;
                    }
                }

                //if (TPDR.DirectViewOne(spdData, cdvViewID.Text, ref dt, true, true, a) == false)
                if (TPDR.DirectViewOne(spdData, VIEWID, ref dt, false, false, a, true, false) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }
                
                spdData.ActiveSheet.Columns[0, spdData.ActiveSheet.ColumnCount - 1].AllowAutoSort = true;
               
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                spdData.SaveExcel(Application.StartupPath + "\\temp.xls");
                
                Process proc = new Process();
                proc.StartInfo.FileName = Application.StartupPath + "\\temp.xls";
                proc.Start();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void spdCondition_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_Table;
            try
            {
                if (e.Column != 2 && e.Column != 6)
                    return;

                if (MPCF.Trim( spdCondition.ActiveSheet.Cells[e.Row,e.Column].Tag.ToString() ) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(217));
                    return;
                }
                s_Table=MPCF.Trim( spdCondition.ActiveSheet.Cells[e.Row,e.Column].Tag.ToString()) ;


                cdvTable.Init();
                cdvTable.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTable.GetListView);
                cdvTable.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTable.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvTable.GetListView, '1', s_Table);

                if (cdvTable.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTable_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdCondition.ActiveSheet.Cells[e.Row, e.Col-1].Value = MPCF.Trim(e.SelectedItem.Text);
        }


        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Enter)
            {
                btnView_Click(null, null);
                e.Handled = true;
            }
        }

        private void frmDNMViewDynamicMenu_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                spdCondition.ActiveSheet.RowCount = 0;
                spdData.ActiveSheet.RowCount = 0;
                spdData.ActiveSheet.ColumnCount = 0;

                ViewFunction();
                ViewDirectViewConditionList();

                b_load_flag = true;
            }
        }

      
    }
}

