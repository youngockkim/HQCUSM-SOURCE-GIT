using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MsgHandler;

namespace Miracom.MESCore
{
    public partial class TranForm29 : Miracom.MESCore.TranForm26
    {
        public TranForm29()
        {
            InitializeComponent();
        }

        private bool mb_collect_data_flag;
        public bool CollectDataFlag
        {
            get
            {
                return mb_collect_data_flag;
            }
            set
            {
                mb_collect_data_flag = value;
            }
        }

        private void TranForm29_Load(object sender, EventArgs e)
        {
            tabTran.TabPages.Remove(tbpCMF);
            tabTran.TabPages.Add(tbpCMF);

            udcCollectData.CollectionType = MESCore.Controls.CollectionType.Lot;
            mb_collect_data_flag = false;
        }

        protected override bool ViewLotInfo(string s_lot_id)
        {
            if (base.ViewLotInfo(s_lot_id) == false) return false;

            mb_collect_data_flag = false;
            cdvColSet_ButtonPress(null, null);
            if (MPCR.ViewMFOColSet('2', 
                                   LOT.GetString("MAT_ID"), 
                                   LOT.GetInt("MAT_VER"), 
                                   LOT.GetString("FLOW"), 
                                   LOT.GetString("OPER"), 
                                   'M', 
                                   cdvColSet,
                                   true) == true)
            {
                mb_collect_data_flag = true;
            }

            if (mb_collect_data_flag == false)
            {
                this.tabTran.TabPages.Remove(this.tbpCollectData);
            }
            else
            {
                if (this.tabTran.TabPages.Contains(this.tbpCollectData) == false)
                {
                    if (this.tabTran.Contains(this.tbpCMF) == true)
                    {
                        this.tabTran.TabPages.Remove(this.tbpCMF);
                        this.tabTran.Controls.Add(this.tbpCollectData);
                        this.tabTran.Controls.Add(this.tbpCMF);
                    }
                    else
                    {
                        this.tabTran.Controls.Add(this.tbpCollectData);
                    }
                }
            }

            return true;
        }

        protected override void ClearData(int i_case, object ExceptCtl1,
            [Optional, DefaultParameterValue(null)] object ExceptCtl2,
            [Optional, DefaultParameterValue(null)] object ExceptCtl3,
            [Optional, DefaultParameterValue(null)] object ExceptCtl4)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        base.ClearData(1, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4);
                        udcCollectData.ClearCollectDataControl();
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        protected override bool CheckCondition()
        {
            try
            {
                if (base.CheckCondition() == false) return false;

                if (mb_collect_data_flag == false) return true;
                if (udcCollectData.CheckCondition() == false)
                {
                    tabTran.SelectedTab = tbpCollectData;
                    return false;
                }
                if (CheckCollectLotData() == false)
                {
                    tabTran.SelectedTab = tbpCollectData;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // CollectLotData()
        //       - Collect Lot Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        protected virtual bool SetCollectLotData(TRSNode in_node)
        {
            CultureInfo ci_inter = new CultureInfo("en-US");
            TRSNode collect_in;

            try
            {
                if (mb_collect_data_flag == false) return true;
                if (GetInputValuePoint() != Miracom.MESCore.Controls.INPUT_VALUE_POINT.END) return true;

                collect_in = in_node.AddNode("COLLECT_LOT_DATA");

                MPCR.SetInMsg(collect_in);
                collect_in.ProcStep = '4';
                collect_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                collect_in.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                collect_in.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                collect_in.AddString("FLOW", LOT.GetString("FLOW"));
                collect_in.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                collect_in.AddString("OPER", LOT.GetString("OPER"));
                collect_in.AddChar("COL_SET_OVR_FLAG", (chkColSetOvr.Checked ? 'Y' : ' '));

                if (chkTranDateTime.Checked == true)
                {
                    collect_in.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                collect_in.AddString("MEAS_RES_ID", GetResID());
                collect_in.AddString("COL_SET_ID", MPCF.Trim(cdvColSet.Text));
                if (MPCF.CheckNumeric(txtColSetVersion.Text) == true)
                {
                    collect_in.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVersion.Text));
                }
                else
                {
                    collect_in.AddInt("COL_SET_VERSION", 0);
                }

                collect_in.AddString("PROC_FLOW", LOT.GetString("FLOW"));
                if (MPCF.Trim(cdvProcResID.Text) != "")
                {
                    if (MPCF.Trim(cdvProcResID.Tag) != "")
                    {
                        collect_in.AddString("PROC_OPER", MPCF.Trim(cdvProcResID.Tag));
                    }
                    collect_in.AddString("PROC_RES_ID", MPCF.Trim(cdvProcResID.Text));
                }

                if (udcCollectData.FillCollectionData(collect_in) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        protected virtual bool CheckCollectLotData()
        {
            TRSNode in_node = new TRSNode("COLLECT_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("COLLECT_LOT_DATA_OUT");

            CultureInfo ci_inter = new CultureInfo("en-US");

            try
            {
                if (mb_collect_data_flag == false) return true;
                if (GetInputValuePoint() != Miracom.MESCore.Controls.INPUT_VALUE_POINT.END) return true;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("COL_SET_OVR_FLAG", (chkColSetOvr.Checked ? 'Y' : ' '));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("MEAS_RES_ID", GetResID());

                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvColSet.Text));
                if (MPCF.CheckNumeric(txtColSetVersion.Text) == true)
                {
                    in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVersion.Text));
                }
                else
                {
                    in_node.AddInt("COL_SET_VERSION", 0);
                }

                if (udcCollectData.FillCollectionData(in_node) == false)
                {
                    return false;
                }

                if (MessageCaster.CallService("EDC", "EDC_Collect_Lot_Data", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                udcCollectData.DrawSpecOutMask(out_node);

                int i_ret = udcCollectData.ConfirmSpecOutData(out_node, true);
                switch (i_ret)
                {
                    case 0: // Error Case
                    return false;
                    case 1: // Success Case
                        break;
                    case 2: // Commit Data Case
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //// Events ////
        private void cdvColSet_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvColSet.Init();
                MPCF.InitListView(cdvColSet.GetListView);
                cdvColSet.Columns.Add("Collection Set ID", 100, HorizontalAlignment.Left);
                cdvColSet.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvColSet.SelectedSubItemIndex = 0;

                if (this.chkColSetOvr.Checked == true)
                {
                    if (EDCLIST.ViewEDCColSetList(cdvColSet.GetListView, '3', null, "", -1, -1, 'L', true) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (EDCLIST.ViewMFOColSetList(cdvColSet.GetListView, '2', null, "", '0', 
                                                  LOT.GetString("MAT_ID"), 
                                                  LOT.GetInt("MAT_VER"),
                                                  LOT.GetString("FLOW"),
                                                  LOT.GetString("OPER"), 'M', ' ', 'N', -1, -1) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvColSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(pnlCollectData, cdvColSet);
                udcCollectData.ClearCollectDataControl();

                if (MPCF.Trim(cdvColSet.Text) != "")
                {
                    udcCollectData.ColSetID = MPCF.Trim(cdvColSet.Text);
                    udcCollectData.LotID = MPCF.Trim(txtLotID.Text);

                    if (udcCollectData.DrawCollectionCharacter() == false)
                    {
                        return;
                    }

                    txtColSetVersion.Text = udcCollectData.ColSetVersion.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvProcResID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvProcResID.Init();
                MPCF.InitListView(cdvProcResID.GetListView);
                cdvProcResID.Columns.Add("Resource ID", 100, HorizontalAlignment.Left);
                cdvProcResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvProcResID.SelectedSubItemIndex = 0;

                if (MPCF.Trim(cdvProcResID.Tag) == "")
                {
                    if (RASLIST.ViewResourceList(cdvProcResID.GetListView, "", "", false) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (RASLIST.ViewResourceList(cdvProcResID.GetListView, "", 0, "", MPCF.Trim(cdvProcResID.Tag), false) == false)
                    {
                        return;
                    }
                }
                cdvProcResID.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkColSetOvr_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdvColSet.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }





    }
}
