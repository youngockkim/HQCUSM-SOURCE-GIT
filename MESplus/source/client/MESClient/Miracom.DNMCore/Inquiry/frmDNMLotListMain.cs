
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmDNMLotListMain.vb
//   Description : MES Cient Form View Lot List Main
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-10 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

using Miracom.MsgHandler;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
 

namespace Miracom.DNMCore
{
    public partial class frmDNMLotListMain : System.Windows.Forms.Form
    {
        public frmDNMLotListMain()
        {
            InitializeComponent();
        }
        
        #region " Constant Definition "

        enum LOT_LIST : int
        {
            ICON = 0,
            BGCOLOR,
            FACTORY,
            OPER,
            OPER_DESC,
            MAT_ID,
            MAT_SHORT_DESC,
            MAT_DESC,
            UNIT_1,
            LOT_ID,
            QTY_1,
            RACK_ID,
            LONG_TERM_FLAG,
            EXPIRE_DATE,
            HOLD_FLAG,
            CREATE_TIME,
            ERP_OINV_IN_DATE,
            USER_DESC,
            ERP_LAST_TRAN_DATE
        }

        private bool b_got_favorite;

        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string s_current_oper;
        private bool b_got_msg_flag;

        #endregion
        
        #region " Function Definition "

        private bool ViewLotList()
        {
            
            /*Hashtable lis_out = new Hashtable();

            udcWorkStation.Height = 0;

            if (udcLotList.ViewLotList('1', cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvFlow.Sequence, s_current_oper,
                                          txtLotId.Text, txtCrrId.Text, cdvResId.Text,
                                          cdvAttr.Text, cdvAttrValue.Text, MPCF.Trim(cdvLotCmf.Tag), cdvCmfValue.Text, ref lis_out) == false)
            {
                return false;
            }

            txtTotLot.Text = (string)lis_out["TOT_LOT"];
            txtTotQty.Text = (string)lis_out["TOT_LOT_QTY"];
            */

            string sViewID = string.Empty;
            Boolean bIcon = true;

            DataTable dt = new DataTable();

            string s_item_name = string.Empty;
            string s_value = string.Empty;
            string s_time = string.Empty;
            char c_step;

            try
            {
                MPCF.ClearList(spdLotList);
                spdLotList.ActiveSheet.RowCount = 0;
                txtTotLot.Text = "0";
                txtTotQty.Text = "0/ 0/ 0";

                if(chkIcon.Checked == false)
                {
                    bIcon = false;
                }

                if (rdByLot.Checked == true)
                {
                    c_step = '1';
                }
                else if (rdByMaterial.Checked == true)
                {
                    c_step = '2';
                }
                else
                {
                    c_step = '1';
                }
                
                TPDR.DirectViewCond[] a;
 
                if (c_step == '1')
                {
                    a = new TPDR.DirectViewCond[7];
                    sViewID = TPDR.MP_VL_INV_LOT_LIST_02;

                    a[0].sCondtion_ID = "$FACTORY";
                    a[0].sCondition_Value = MPGV.gsFactory;
                    a[1].sCondtion_ID = "$OPER";
                    a[1].sCondition_Value = s_current_oper;
                    a[2].sCondtion_ID = "$MAT_ID";

                    if (MPCF.Trim(cdvMatID.Text).ToString().Length > 0)
                    {
                        a[2].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                    }
                    else
                    {
                        a[2].sCondition_Value = MPCF.Trim("ALL");
                    }
                  
                    a[3].sCondtion_ID = "$LOT_ID";
                    if (MPCF.Trim(txtLotId.Text).ToString().Length > 0)
                    {
                        a[3].sCondition_Value = MPCF.Trim(txtLotId.Text);
                    }
                    else
                    {
                        a[3].sCondition_Value = MPCF.Trim("ALL");
                    }

                    a[4].sCondtion_ID = "$INCLUNDE_ADJ_LOT";
                    if (chkIncludeAdjustLot.Checked == false)
                    {
                        a[4].sCondition_Value = "A";
                    }
                    else
                    {
                        a[4].sCondition_Value = "X";
                    }

                    a[5].sCondtion_ID = "$HOLD_FLAG";
                    if (ckHoldFlag.Checked == true)
                    {
                        a[5].sCondition_Value = "Y";
                    }
                    else
                    {
                        a[5].sCondition_Value = "A";
                    }

                    a[6].sCondtion_ID = "$LONG_TERM_FLAG";
                    if (ckLongTerm.Checked == true)
                    {
                        a[6].sCondition_Value = "Y";
                    }
                    else
                    {
                        a[6].sCondition_Value = "A";
                    }
                }
                else
                {
                    a = new TPDR.DirectViewCond[4];
                    sViewID = TPDR.MP_VL_INV_MAT_LIST_01;

                    a[0].sCondtion_ID = "$FACTORY";
                    a[0].sCondition_Value = MPGV.gsFactory;
                    a[1].sCondtion_ID = "$OPER";
                    a[1].sCondition_Value = s_current_oper;

                    a[2].sCondtion_ID = "$INCLUNDE_ADJ_LOT";
                    if (chkIncludeAdjustLot.Checked == false)
                    {
                        a[2].sCondition_Value = "A";
                    }
                    else
                    {
                        a[2].sCondition_Value = "X";
                    }

                    a[3].sCondtion_ID = "$MAT_ID";
                    if (MPCF.Trim(cdvMatID.Text) != "")
                    {
                        a[3].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                    }
                    else
                    {
                        a[3].sCondition_Value = "ALL";
                    }

                    //a[3].sCondtion_ID = "$LOT_ID";
                    //if (MPCF.Trim(s_lot_id) != "")
                    //{
                    //    a[3].sCondition_Value = MPCF.Trim(s_lot_id);
                    //}
                    //else
                    //{
                    //    a[3].sCondition_Value = "ALL";
                    //}

                }
                
                if (TPDR.DirectViewOne(spdLotList, sViewID, ref dt, bIcon, bIcon, a, true, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }
 

                if (spdLotList.ActiveSheet.RowCount > 0)
                {
                    spdLotList.ActiveSheet.SetActiveCell(0, 0);
                    spdLotList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);
                    FarPoint.Win.Spread.CellClickEventArgs aa = new FarPoint.Win.Spread.CellClickEventArgs(null ,0,0,0,0, System.Windows.Forms.MouseButtons.Left,false,false);
                    spdLotList_CellClick(null,aa);
                }

                spdLotList.ActiveSheet.Columns[0, spdLotList.ActiveSheet.ColumnCount - 1].Locked = true;

                txtTotLot.Text = spdLotList.ActiveSheet.RowCount.ToString();

                spdLotList.Sheets[0].FrozenColumnCount = (int)LOT_LIST.MAT_SHORT_DESC;
                //spdLotList.DataSource = dt;

                //FarPoint.Win.Spread.CellType.BaseCellType cell_type = cell_type = new FarPoint.Win.Spread.CellType.NumberCellType();
                //((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).DecimalPlaces = 0;

                //if (bIcon == true)
                //{
                //    this.spdLotList_Sheet1.Columns[(int)LOT_LIST.ICON].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                //    this.spdLotList_Sheet1.Columns[(int)LOT_LIST.ICON].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                //}
                //else
                //{
                //    spdLotList.ActiveSheet.Columns.Add(0, 1);
                //    spdLotList.ActiveSheet.SetColumnVisible(0, false);
                //}

                //txtTotLot.Text = spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TOT_LOT].Text.ToString();
                //txtTotQty.Text = spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TOT_LOT_QTY].Text.ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public void SetOperation(string sOper, int iWidth, int iHeight)
        {
            try
            {
                //udcLotList.SetInfo(this.Name);
                
                s_current_oper = sOper;
                cdvMatID.Text = "";

                cdvOper.Text = s_current_oper;

                if (this.Width + 4 > iWidth)
                {
                    this.Left = 0;
                    this.Width = iWidth - 4;
                }
                if (this.Height + 4 > iHeight)
                {
                    this.Top = 0;
                    this.Height = iHeight - 4;
                }
                
                if (b_load_flag == true)
                {
                    ViewLotList();
                }
                else
                {
                    this.Top = 0;
                    this.Left = 0;
                    this.Width = iWidth - 4;
                    this.Height = iHeight - 4;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                //return udcLotList.spdLotList;
                return spdLotList;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        // ViewAttributeNameList()
        //       - View Attribute Name list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - 
        //
        public bool ViewAttributeNameList()
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_LOT);

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("ATTR_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_KEY);

                        if (out_node.GetList(0)[i].GetString("VALID_TBL") != "")
                        {
                            itmX.Tag = out_node.GetList(0)[i].GetString("VALID_TBL");
                        }
                        else
                        {
                            itmX.Tag = "";
                        }

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_NAME")));
                        cdvAttr.GetListView.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetPopupMessage()
        {
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
            int i_msg_cnt = 0;

            b_got_msg_flag = false;
            tmrGotMessage.Stop();
            tmrGotMessage.Enabled = false;
            btnMessage.Visible = false;
            btnMessage.Tag = null;

            try
            {
                if (BASLIST.ViewBBSMsgListForLot(out_node, MPGV.gsCurrentLot_ID) == false)
                {
                    return false;
                }

                i_msg_cnt = out_node.GetList("MSG_LIST").Count;
                if (i_msg_cnt > 0)
                {
                    b_got_msg_flag = true;
                    btnMessage.Tag = out_node;
                    tmrGotMessage.Enabled = true;
                    tmrGotMessage.Start();
                }

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion
        
        private void frmDNMLotListMain_Load(object sender, System.EventArgs e)
        {            
            try
            {
                this.lblFormTitle.Text = this.Text;
                
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                chkAutoRefresh.Checked = false;
                if (MPGV.giAutoRefreshTime > 0)
                {
                    chkAutoRefresh.Checked = MPGV.gbAutoRefresh;
                    tmrTimer.Interval = MPGV.giAutoRefreshTime * 1000;
                }
                
                if (chkAutoRefresh.Checked == true)
                {
                    tmrTimer.Start();
                }
                else
                {
                    tmrTimer.Stop();
                }
                rdByLot.Checked = true;

                udcWorkStation.MinimumSize = new Size(udcWorkStation.Width, 0);
                udcWorkStation.Height = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }
        
        private void frmDNMLotListMain_Closed(object sender, System.EventArgs e)
        {
            
            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";
        }
        
        private void frmDNMLotListMain_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    //udcLotList.Init();
                    MPCF.ClearList(spdLotList, true);

                    //MPGV.gbFavoriteChangeForLotListMain = false;

                    GetSubMenu();

                    cdvOper.Text = s_current_oper;

                    ViewLotList();
                    b_load_flag = true;
                }
                else
                {
                    cdvOper.Text = s_current_oper;

                    if (chkAutoRefresh.Checked == true)
                    {
                        ViewLotList();
                    }

                    //Add by J.S. 2009.02.13  favorites 수정 했을시 Refresh되게 하기 위해서....
                    if (MPGV.gbFavoriteChangeForLotListMain == true)
                    {
                        MPGV.gbFavoriteChangeForLotListMain = false;
                        GetSubMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmDNMLotListMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        
        private void frmDNMLotListMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyChar == (char)58)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void frmDNMLotListMain_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (this.MdiParent == null)
                {
                    pnlTop.Visible = false;
                }
                else
                {
                    pnlTop.Visible = true;
                }
            }
            else
            {
                pnlTop.Visible = false;
            }
        }
        
        private void lblFormTitle_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            string sLotID;

            /* 2013.06.12. Aiden. Middleware 가 사용가능한지 확인 */
            if (s_current_oper != "" && MPIF.gInit.IsAvailableSendMessage == true)
            {
                sLotID = MPGV.gsCurrentLot_ID;
                ViewLotList();

                if (sLotID != "")
                {
                    MPGV.gsCurrentLot_ID = sLotID;
                    //udcLotList.FocusLot(sLotID);
                    //if (udcLotList.spdLotList.ActiveSheet.ActiveRowIndex >= 0)
                    //{
                    //    GetPopupMessage();
                    //}
                }
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (s_current_oper != "")
            {
                ViewLotList();
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "";
            if (cdvMatID.Text != "")
            {
                sCond = sCond + "Mat ID    : " + cdvMatID.Text + "\r";
            }
            if (cdvFlow.Text != "")
            {
                sCond = sCond + "Flow      : " + cdvFlow.Text + "\r";
            }
            sCond = sCond + "Operation : " + s_current_oper;
            
            ////if (MPCF.ExportToExcel(udcLotList.spdLotList, this.Text, sCond, true, true, true, -1, -1) == false)
            //if (MPCF.ExportToExcel(spdLotList, this.Text, sCond, true, true, true, 1, -1) == false)
            //{
            //    return;
            //}

            try
            {
                sfdExcel.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

                spdLotList.ActiveSheet.Protect = false;
                spdLotList.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cdvMatID_VersionChanged(object sender, EventArgs e)
        {
            cdvFlow.Text = "";
            cdvFlow.Sequence = 0;

            cdvFlow_ButtonPress(null, null);
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvMatID.Text) == "") 
            {
                cdvFlow.ListCond_Step = '1';
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMatID.Text;
                cdvFlow.ListCond_MatVersion = cdvMatID.Version;
            }
        }
        
        private void btnMessage_Click(object sender, EventArgs e)
        {
            TRSNode out_node;
            try
            {
                out_node = (TRSNode)btnMessage.Tag;
                if (out_node != null)
                {
                    MPCR.PopupInformNote(out_node, "", MPGV.gsCurrentLot_ID, "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tmrGotMessage_Tick(object sender, EventArgs e)
        {
            /* Added by DM KIM 2012.05.07 View Popup Msg List*/
            if (b_got_msg_flag == true)
            {
                btnMessage.Visible = true;
                if (btnMessage.BackColor.Equals(Color.LemonChiffon) == true)
                {
                    btnMessage.BackColor = Color.Salmon;
                }
                else
                {
                    btnMessage.BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                btnMessage.Visible = false;
            }
        }

        private void cdvResId_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(s_current_oper) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                return;
            }

            cdvResId.Init();
            MPCF.InitListView(cdvResId.GetListView);
            cdvResId.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResId.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResId.GetListView, cdvMatID.Text, 0, "", s_current_oper, false);
        }

        private void cdvResId_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (MPCF.Trim(cdvResId.Text) != "")
                    {
                        ViewLotList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtCrrId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (MPCF.Trim(txtCrrId.Text) != "")
                    {
                        ViewLotList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtLotId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (MPCF.Trim(txtLotId.Text) != "")
                    {
                        ViewLotList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMatID.Text) == "")
            {
                cdvFlow.ListCond_Step = '1';
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMatID.Text;
                cdvFlow.ListCond_MatVersion = cdvMatID.Version;
            }
        }

        private void cdvAttr_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(s_current_oper) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                return;
            }

            cdvAttr.Init();
            MPCF.InitListView(cdvAttr.GetListView);
            cdvAttr.Columns.Add("Attribute Name", 50, HorizontalAlignment.Left);
            cdvAttr.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAttr.SelectedSubItemIndex = 1;
            cdvAttr.DisplaySubItemIndex = 1;

            ViewAttributeNameList();
            cdvAttr.AddEmptyRow(1);
        }

        private void cdvAttr_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvAttrValue.Text = "";

                if (string.IsNullOrEmpty(cdvAttr.Text) == true) return;

                if (string.IsNullOrEmpty(cdvAttr.GetListView.SelectedItems[0].Tag.ToString()) == true)
                {
                    cdvAttrValue.VisibleButton = false;
                }
                else
                {
                    cdvAttrValue.VisibleButton = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLotCmf_ButtonPress(object sender, EventArgs e)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmX;

            try
            {
                if (MPCF.Trim(s_current_oper) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                    return;
                }

                cdvLotCmf.Init();
                MPCF.InitListView(cdvLotCmf.GetListView);
                cdvLotCmf.Columns.Add("CMF Prompt", 50, HorizontalAlignment.Left);
                cdvLotCmf.Columns.Add("Format", 0, HorizontalAlignment.Left);
                cdvLotCmf.Columns.Add("Table Name", 0, HorizontalAlignment.Left);
                cdvLotCmf.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_LOT, ref out_node, "", true) == false)
                {
                    return;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) == "") continue;
                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")));
                    itmX.Tag = i + 1;
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("FORMAT")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                    cdvLotCmf.Items.Add(itmX);
                }

                cdvLotCmf.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLotCmf_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvLotCmf.SelectedItem.SubItems[2].Text == "")
            {
                cdvCmfValue.VisibleButton = false;
                cdvCmfValue.ReadOnly = false;
            }
            else
            {
                cdvCmfValue.VisibleButton = true;
                cdvCmfValue.ReadOnly = true;
            }
            cdvLotCmf.Tag = cdvLotCmf.GetListView.SelectedItems[0].Tag;
        }

        private void cdvCmfValue_ButtonPress(object sender, EventArgs e)
        {
            if (cdvLotCmf.SelectedItem.SubItems[2].Text == "") return;

            cdvCmfValue.Init();
            MPCF.InitListView(cdvCmfValue.GetListView);
            cdvCmfValue.Columns.Add("CMF Prompt", 50, HorizontalAlignment.Left);
            cdvCmfValue.Columns.Add("Format", 0, HorizontalAlignment.Left);
            cdvCmfValue.Columns.Add("Table Name", 0, HorizontalAlignment.Left);
            cdvCmfValue.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCmfValue.GetListView, '1', MPCF.Trim(cdvLotCmf.SelectedItem.SubItems[2].Text));
            cdvCmfValue.InsertEmptyRow(0, 1);
        }

        private void cdvCmfValue_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvLotCmf.Text) != "" && MPCF.Trim(cdvCmfValue.Text) != "")
                {
                    ViewLotList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAttrValue_ButtonPress(object sender, EventArgs e)
        {
            cdvAttrValue.Init();
            MPCF.InitListView(cdvAttrValue.GetListView);
            cdvAttrValue.Columns.Add("Attribute Value", 150, HorizontalAlignment.Left);
            cdvAttrValue.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrValue.SelectedSubItemIndex = 0;
            cdvAttrValue.DisplaySubItemIndex = 0;

            if (string.IsNullOrEmpty(cdvAttr.Text) == true) return;

            BASLIST.ViewGCMDataList(cdvAttrValue.GetListView, '1', cdvAttr.GetListView.SelectedItems[0].Tag.ToString());
        }

        private void cdvAttrValue_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvAttr.Text) != "" && MPCF.Trim(cdvAttrValue.Text) != "")
            {
                ViewLotList();
            }
        }

       /* private void udcLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            udcWorkStation.LotId = MPGV.gsCurrentLot_ID;
            udcWorkStation.ViewTransaction();
            if (udcWorkStation.TransactionCount < 1)
            {
                udcWorkStation.Height = 0;
            }
            else
            {
                udcWorkStation.Height = 60;
            }

            GetPopupMessage();
        }*/

        //udcLotList_SelectionChanged
        private void spdLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //if (e.Button == System.Windows.Forms.MouseButtons.Left)
                //{
                //    MPGV.gsCurrentLot_ID = MPCF.Trim(spdLotList.ActiveSheet.Cells[e.Row, (int)LOT_LIST.LOT_ID].Text.ToString());
                //    Clipboard.SetDataObject("", true);
                //    Clipboard.SetDataObject(MPGV.gsCurrentLot_ID, true);

                //    //udcWorkStation.LotId = MPGV.gsCurrentLot_ID;
                //    //udcWorkStation.ViewTransaction();
                //    //if (udcWorkStation.TransactionCount < 1)
                //    //{
                //    //    udcWorkStation.Height = 0;
                //    //}
                //    //else
                //    //{
                //    //    udcWorkStation.Height = 60;
                //    //}

                //    //GetPopupMessage();
                //}
                //else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                //{
                //    ctxMenu.Show(spdLotList, new Point(e.X, e.Y));
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }            
        }

        private void chkIcon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        // GetSubMenu()
        //       - initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //        -
        private bool GetSubMenu()
        {
            int i;
            ListView lisTmp;
            MenuItem mnuTmp;

            try
            {
                ctxMenu.MenuItems.Clear();
                lisTmp = new ListView();
                lisTmp.View = View.Details;

                lisTmp.Columns.Add(new ColumnHeader());
                lisTmp.Columns.Add(new ColumnHeader());
                SECLIST.ViewFavoritesList(lisTmp, '1', MPGV.gsProgramID, null, "");

                if (lisTmp.Items.Count < 1)
                {
                    b_got_favorite = false;
                    mnuTmp = new MenuItem("View Lot Status", new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "WIP3001"; ctxMenu.MenuItems.Add(mnuTmp);
                    mnuTmp = new MenuItem("View Lot History", new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "WIP3002"; ctxMenu.MenuItems.Add(mnuTmp);
                    ctxMenu.MenuItems.Add("-");
                    mnuTmp = new MenuItem("View Lot Trace", new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "WIP3004"; ctxMenu.MenuItems.Add(mnuTmp);
                }
                else
                {
                    b_got_favorite = true;
                    for (i = 0; i < lisTmp.Items.Count; i++)
                    {
                        mnuTmp = new MenuItem(lisTmp.Items[i].SubItems[1].Text, new EventHandler(subMenu_Click));
                        mnuTmp.Tag = lisTmp.Items[i].Tag;
                        ctxMenu.MenuItems.Add(mnuTmp);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void subMenu_Click(System.Object sender, System.EventArgs e)
        {
            if (((MenuItem)sender).Tag == null) return;

            if (b_got_favorite == false)
            {
                string s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(s_func_name);
            }
            else
            {
                MenuInfoTag m_menu = (MenuInfoTag)(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(m_menu);
            }
        }

        

        private void spdLotList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void chkWait_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                //int i, j;
                //FarPoint.Win.Spread.Model.CellRange[] cl;

                //MPGV.gaSelectLot_ID.Clear();
                //MPGV.gsCurrentLot_ID = "";

                //if (spdLotList.ActiveSheet.SelectionCount > 0)
                //{
                //    cl = spdLotList.ActiveSheet.GetSelections();
                //    for (i = 0; i < cl.Length; i++)
                //    {
                //        for (j = 0; j < cl[i].RowCount; j++)
                //        {
                //            MPGV.gaSelectLot_ID.Add(MPCF.Trim(spdLotList.ActiveSheet.Cells[cl[i].Row + j, (int)LOT_LIST.LOT_ID].Text));
                //        }
                //    }

                //    if (spdLotList.ActiveSheet.ActiveRowIndex >= 0)
                //    {
                //        MPGV.gsCurrentLot_ID = MPCF.Trim(spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.LOT_ID].Text);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }

        private void cboOQCResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void cboPQCResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewLotList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void chkColorIndex_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (chkColorIndex.Checked == false)
            {
                spdColorIndex.Visible = false;
                return;
            }

            spdColorIndex.ActiveSheet.RowCount = 0;

            if (TPDR.DirectViewOne(spdColorIndex, "VL_COLOR_LIST", ref dt, true, true) == false)
            {
                if (dt != null) { dt.Dispose(); }
                GC.Collect();
                return;
            }
            spdColorIndex.Width = 100;
            spdColorIndex.Visible = true;


        }

        private void spdLotList_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void spdLotList_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void rdByMaterial_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd;

            try
            {
                rd = (RadioButton)sender;

                if (rd != null)
                {
                    if (rd.Checked == true)
                    {
                        if (rdByLot.Checked == true)
                        {
                            grpLotCond.Visible = true;
                        }
                        else
                        {
                            grpLotCond.Visible = false;
                        }

                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvOper.Init();
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Description", 200, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvOper.GetListView, '1', "C@INV_OPER");
                cdvOper.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvOper.Text) == "")
                return;

            s_current_oper = MPCF.Trim(cdvOper.Text);

            btnRefresh.PerformClick();
        }

        private void ckLongTerm_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void ckHoldFlag_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
    }
}
