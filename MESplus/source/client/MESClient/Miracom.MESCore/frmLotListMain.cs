
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmLotListMain.vb
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

namespace Miracom.MESCore
{
    public partial class frmLotListMain : System.Windows.Forms.Form
    {
        public frmLotListMain()
        {
            InitializeComponent();
        }
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string s_current_oper;
        private bool b_got_msg_flag;

        #endregion
        
        #region " Function Definition "

        private bool ViewLotList()
        {
            Hashtable lis_out = new Hashtable();

            udcWorkStation.Height = 0;

            if (udcLotList.ViewLotList('1', cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvFlow.Sequence, s_current_oper,
                                          txtLotId.Text, txtCrrId.Text, cdvResId.Text,
                                          cdvAttr.Text, cdvAttrValue.Text, MPCF.Trim(cdvLotCmf.Tag), cdvCmfValue.Text, ref lis_out) == false)
            {
                return false;
            }

            txtTotLot.Text = (string)lis_out["TOT_LOT"];
            txtTotQty.Text = (string)lis_out["TOT_LOT_QTY"];

            return true;
        }

        public void SetOperation(string sOper, int iWidth, int iHeight)
        {
            try
            {
                udcLotList.SetInfo(this.Name);
                s_current_oper = sOper;
                cdvMatID.Text = "";
                
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
                return udcLotList.spdLotList;
                
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
        
        private void frmLotListMain_Load(object sender, System.EventArgs e)
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

                udcWorkStation.MinimumSize = new Size(udcWorkStation.Width, 0);
                udcWorkStation.Height = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }
        
        private void frmLotListMain_Closed(object sender, System.EventArgs e)
        {
            
            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";
        }
        
        private void frmLotListMain_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    udcLotList.Init();

                    MPGV.gbFavoriteChangeForLotListMain = false;
                    ViewLotList();
                    b_load_flag = true;
                }
                else
                {
                    if (chkAutoRefresh.Checked == true)
                    {
                        ViewLotList();
                    }

                    //Add by J.S. 2009.02.13  favorites 수정 했을시 Refresh되게 하기 위해서....
                    if (MPGV.gbFavoriteChangeForLotListMain == true)
                    {
                        MPGV.gbFavoriteChangeForLotListMain = false;
                        udcLotList.GetSubMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmLotListMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
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
        
        private void frmLotListMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        
        private void frmLotListMain_Resize(object sender, System.EventArgs e)
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
                    udcLotList.FocusLot(sLotID);
                    if (udcLotList.spdLotList.ActiveSheet.ActiveRowIndex >= 0)
                    {
                        GetPopupMessage();
                    }
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
            
            if (MPCF.ExportToExcel(udcLotList.spdLotList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
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
            cdvResId.InsertEmptyRow(0, 1);
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
            cdvAttr.InsertEmptyRow(0, 1);
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
                    /* Added By YJJung 151126 Attribute Value가 입력 안되는 Bug Fix */
                    cdvAttrValue.ReadOnly = false;
                }
                else
                {
                    cdvAttrValue.VisibleButton = true;
                    /* Added By YJJung 151126 Attribute Value가 입력 안되는 Bug Fix */
                    cdvAttrValue.ReadOnly = true;
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
            /* Added By YJJung 151126 LOT Cmf 변경 시 값의 초기화 추가 */
            cdvCmfValue.Text = "";
            /* Added End */
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
            //if (cdvCmfValue.SelectedItem.SubItems[2].Text == "") return;
            /* Updated By YJJung 151126 LOT CMF Value Click 시 Error 메시지 발생 Bug Fix */
            if (cdvLotCmf.Text == "") return;
            /* Updated End */

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

        private void udcLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
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
        }
    }
}
