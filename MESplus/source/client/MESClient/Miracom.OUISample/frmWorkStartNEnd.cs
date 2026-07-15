using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.OUISample
{
    public partial class frmWorkStartNEnd : BaseForm03
    {
        public frmWorkStartNEnd()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        private TRSNode LOT;

        #endregion

        #region " Function Definition "

        private void ClearData(int i_case)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        VisibleInputValue(false);

                        udcLotInfor.InitFlexibleScreen();

                        LOT = null;
                        btnProcess.Tag = null;

                        break;

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool ViewLotInfo(string s_lot_id)
        {
            s_lot_id = MPCF.Trim(s_lot_id);
            if (s_lot_id == "") return false;

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            DateTime dt_time = MPCF.ToDate(out_node.GetString("OPER_IN_TIME"));
            TimeSpan ts_time = DateTime.Now - dt_time;
            string s_time = ts_time.Days + ", " + ts_time.Hours + ":" + ts_time.Minutes + ":" + ts_time.Seconds;
            out_node.AddString("QUEUE_TIME", s_time);

            if (out_node.GetString("START_TIME") != "")
            {
                dt_time = MPCF.ToDate(out_node.GetString("START_TIME"));
                ts_time = DateTime.Now - dt_time;
                s_time = ts_time.Days + ", " + ts_time.Hours + ":" + ts_time.Minutes + ":" + ts_time.Seconds;
                out_node.AddString("PROC_TIME", s_time);
            }

            if (udcLotInfor.LoadDesign("OUI_LotStatus") == false) return false;
            if (udcLotInfor.SetDataToScreen(out_node) == false) return false;

            LOT = out_node;

            MPCR.PopupInformNote(null, "", s_lot_id, "", "", "", "");

            return true;
        }

        private void SetInValueControl(Label lbl, Miracom.UI.Controls.MCCodeView.MCCodeView cdv, string s_label, string s_default_value)
        {
            if (s_label == "")
            {
                lbl.Visible = false;
                cdv.Visible = false;
            }
            else
            {
                lbl.Visible = true;
                cdv.Visible = true;

                lbl.Text = s_label;
                cdv.Text = s_default_value;

                if (cdv.Items.Count > 0)
                {
                    cdv.VisibleButton = true;
                }
            }
        }

        private void VisibleInputValue(bool b_visible,
            string s_label_1 = "",
            string s_default_value_1 = "",
            string s_label_2 = "",
            string s_default_value_2 = "",
            string s_label_3 = "",
            string s_default_value_3 = "",
            string s_label_4 = "",
            string s_default_value_4 = "",
            string s_label_5 = "",
            string s_default_value_5 = "")
        {
            if (b_visible == false)
            {
                pnlInValue.Visible = false;

                lblInValue01.Text = "";
                lblInValue02.Text = "";
                lblInValue03.Text = "";
                lblInValue04.Text = "";
                lblInValue05.Text = "";

                cdvInValue01.Text = "";
                cdvInValue02.Text = "";
                cdvInValue03.Text = "";
                cdvInValue04.Text = "";
                cdvInValue05.Text = "";

                return;
            }

            pnlInValue.Visible = true;
            SetInValueControl(lblInValue01, cdvInValue01, s_label_1, s_default_value_1);
            SetInValueControl(lblInValue02, cdvInValue02, s_label_2, s_default_value_2);
            SetInValueControl(lblInValue03, cdvInValue03, s_label_3, s_default_value_3);
            SetInValueControl(lblInValue04, cdvInValue04, s_label_4, s_default_value_4);
            SetInValueControl(lblInValue05, cdvInValue05, s_label_5, s_default_value_5);
        }

        private bool StartLot()
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;

            try
            {
                MPCR.SetInMsg(in_node);

                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_START,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "START_LOT",
                                                MPCF.Trim(cdvInValue01.Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}
                in_node.AddString("RES_ID", MPCF.Trim(cdvInValue01.Text));

                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool EndLot()
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            bool b_proc_alarm_action;

            try
            {
                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_END,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "END_LOT",
                                                MPCF.Trim(cdvInValue01.Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddDouble("QTY_1", -1);
                in_node.AddDouble("QTY_2", -1);
                in_node.AddDouble("QTY_3", -1);

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}

                //in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                //in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvInValue02.Text));
                //in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                //in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                //in_node.AddString("RET_OPER", MPCF.Trim(cdvRetOperation.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvInValue01.Text));
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                //in_node.AddChar("FORCIBLY_END_WITH_SUBLOT_FLAG", chkForceEndSublot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_End_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool HoldLot()
        {
            TRSNode in_node = new TRSNode("HOLD_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                //if (chkTranDateTime.Checked == true)
                //{
                //    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                //}

                in_node.AddString("HOLD_CODE", MPCF.Trim(cdvInValue01.Text));
                in_node.AddString("HOLD_PASSWORD", MPCF.Trim(cdvInValue02.Text).ToUpper(), true);

                //in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                //in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                //in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                //in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                //in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                //in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                //in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                //in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                //in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                //in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                //in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                //in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                //in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                //in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                //in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                //in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                //in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                //in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                //in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                //in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Hold_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmWorkStartNEnd_Load(object sender, EventArgs e)
        {
            udcLotInfor.ScreenSpread.Tag = "Change Cell";
            udcLotInfor.InitFlexibleScreen();

            udcLotList.SetInfo(this.Name);
            udcLotList.Init();
            udcLotList.GetSpread().ActiveSheet.ColumnHeader.Rows.Default.Height = 35;
            udcLotList.GetSpread().ActiveSheet.Rows.Default.Height = 35;

            ClearData(1);
        }

        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            cdvOper.SameWidthHeightOfButton = true;

            if (WIPLIST.ViewOperationList(cdvOper.GetListView, '1') == false)
            {
                return;
            }
        }

        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cdvRes_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvOper, 1) == false) return;

            cdvRes.Init();
            MPCF.InitListView(cdvRes.GetListView);
            cdvRes.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvRes.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvRes.SelectedSubItemIndex = 0;
            cdvRes.SameWidthHeightOfButton = true;

            if (RASLIST.ViewResourceList(cdvRes.GetListView, "", 0, "", cdvOper.Text, false) == false)
            {
                return;
            }
        }

        private void cdvRes_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvOper, 1) == false) return;

            Hashtable lis_out = new Hashtable();

            if (udcLotList.ViewLotList('1', "", 0, "", 0, cdvOper.Text,
                                          "", "", cdvRes.Text,
                                          "", "", "", "", ref lis_out) == false)
            {
                return;
            }

            lblLotCount.Text = "Lot Count : " + (string)lis_out["TOT_LOT"];
            lblLotQty.Text = "Lot Quantity : " + (string)lis_out["TOT_LOT_QTY"];

            if (LOT != null)
            {
                if (udcLotList.FocusLot(LOT.GetString("LOT_ID")) == true)
                {
                    ViewLotInfo(LOT.GetString("LOT_ID"));
                }
            }

        }

        private void cdvInValue_Enter(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            switch (cdvTemp.Name)
            {
                case "cdvInValue01":
                    lblInValue01.Visible = false;
                    break;
                case "cdvInValue02":
                    lblInValue02.Visible = false;
                    break;
                case "cdvInValue03":
                    lblInValue03.Visible = false;
                    break;
                case "cdvInValue04":
                    lblInValue04.Visible = false;
                    break;
                case "cdvInValue05":
                    lblInValue05.Visible = false;
                    break;
            }
        }

        private void cdvInValue_Leave(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (cdvTemp.Text == "")
            {
                switch (cdvTemp.Name)
                {
                    case "cdvInValue01":
                        lblInValue01.Visible = true;
                        break;
                    case "cdvInValue02":
                        lblInValue02.Visible = true;
                        break;
                    case "cdvInValue03":
                        lblInValue03.Visible = true;
                        break;
                    case "cdvInValue04":
                        lblInValue04.Visible = true;
                        break;
                    case "cdvInValue05":
                        lblInValue05.Visible = true;
                        break;
                }
            }
        }

        private void cdvInValue_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            Label lblTemp = null;

            if (cdvTemp.Text != "")
            {
                switch (cdvTemp.Name)
                {
                    case "cdvInValue01":
                        lblTemp = lblInValue01;
                        break;
                    case "cdvInValue02":
                        lblTemp = lblInValue02;
                        break;
                    case "cdvInValue03":
                        lblTemp = lblInValue03;
                        break;
                    case "cdvInValue04":
                        lblTemp = lblInValue04;
                        break;
                    case "cdvInValue05":
                        lblTemp = lblInValue05;
                        break;
                }

                if (lblTemp.Visible == true)
                {
                    lblTemp.Visible = false;
                }
            }
        }

        private void lblInValue_Click(object sender, EventArgs e)
        {
            Label lblTemp = (Label)sender;

            switch (lblTemp.Name)
            {
                case "lblInValue01":
                    cdvInValue01.Focus();
                    break;
                case "lblInValue02":
                    cdvInValue02.Focus();
                    break;
                case "lblInValue03":
                    cdvInValue03.Focus();
                    break;
                case "lblInValue04":
                    cdvInValue04.Focus();
                    break;
                case "lblInValue05":
                    cdvInValue05.Focus();
                    break;
            }
        }

        private void udcLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (MPGV.gsCurrentLot_ID == null || MPGV.gsCurrentLot_ID == "") return;

            ClearData(1);
            ViewLotInfo(MPGV.gsCurrentLot_ID);
        }

        private void btnStartLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnStartLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;


            if (RASLIST.ViewResourceList(cdvInValue01.GetListView, "", 0, "", LOT.GetString("OPER"), false) == false)
            {
                return;
            }

            if (cdvInValue01.Items.Count < 1)
            {
                VisibleInputValue(false);
                return;
            }

            VisibleInputValue(true, "Start Res ID");
        }

        private void btnEndLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnEndLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;

            if (RASLIST.ViewResourceList(cdvInValue01.GetListView, "", 0, "", LOT.GetString("OPER"), false) == false)
            {
                return;
            }

            cdvInValue02.Init();
            MPCF.InitListView(cdvInValue02.GetListView);
            cdvInValue02.Columns.Add("To Oper", 50, HorizontalAlignment.Left);
            cdvInValue02.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue02.SelectedSubItemIndex = 0;
            cdvInValue02.SameWidthHeightOfButton = true;

            if (WIPLIST.ViewOperationList(cdvInValue02.GetListView, '2', LOT.GetString("FLOW")) == false)
            {
                return;
            }


            if (cdvInValue01.Items.Count < 1)
            {
                VisibleInputValue(true, "", "", "To Oper");
            }
            else
            {
                VisibleInputValue(true, "End Res ID", LOT.GetString("START_RES_ID"), "To Oper");
            }
        }

        private void btnHoldLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            btnProcess.Tag = btnHoldLot.Name;

            cdvInValue01.Init();
            MPCF.InitListView(cdvInValue01.GetListView);
            cdvInValue01.Columns.Add("Hold Code", 50, HorizontalAlignment.Left);
            cdvInValue01.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInValue01.SelectedSubItemIndex = 0;
            cdvInValue01.SameWidthHeightOfButton = true;

            if (BASLIST.ViewGCMDataList(cdvInValue01.GetListView, '1', MPGC.MP_WIP_HOLD_CODE) == false)
            {
                return;
            }

            cdvInValue02.Init();
            cdvInValue02.VisibleButton = false;

            VisibleInputValue(true, "Hold Code", "", "Hold Password");
        }

        private void btnSplitLot_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;

            MPGV.gIMdiForm.ActiveMenu("WIP2008");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (LOT == null) return;
            if (MPCF.Trim(btnProcess.Tag) == "") return;

            switch (MPCF.Trim(btnProcess.Tag))
            {
                case "btnStartLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (StartLot() == false) return;

                    break;

                case "btnEndLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (cdvInValue01.Visible == true && MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (EndLot() == false) return;

                    break;

                case "btnHoldLot":
                    if (pnlInValue.Visible == true)
                    {
                        if (MPCF.Trim(cdvInValue01.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n[" + lblInValue01.Text + "]");
                            cdvInValue01.Focus();
                            return;
                        }
                    }

                    if (HoldLot() == false) return;

                    break;
            }

            btnRefresh.PerformClick();
        }


    
    
    }
}
