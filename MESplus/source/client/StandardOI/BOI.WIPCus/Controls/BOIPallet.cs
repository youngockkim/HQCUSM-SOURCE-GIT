using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;


namespace BOI.WIPCus.Controls
{
    public partial class BOIPallet : UserControl
    {
        public BOIPallet()
        {
            InitializeComponent();
        }

        private string s_order_id = "";
        private string s_mat_id = "";
        private string s_mat_desc = "";
        private string s_line_id = "";
        private string s_line_desc = "";
        private string s_res_id = "";
        private string s_res_desc = "";
        private string s_counter_id = "";
        private string s_counter_desc = "";
        private string s_shelf_date = "";
        private int i_ord_qty = 0;
        private int i_box_per_pallet = 0;
        private int i_cum_prod_qty = 0;
        private int i_prod_qty = 0;
        private int i_box_qty = 0;

        private System.EventHandler OrderChangedEvent;
        public event System.EventHandler OrderChanged
        {
            add
            {
                OrderChangedEvent = (System.EventHandler)System.Delegate.Combine(OrderChangedEvent, value);
            }
            remove
            {
                OrderChangedEvent = (System.EventHandler)System.Delegate.Remove(OrderChangedEvent, value);
            }
        }

        private System.EventHandler OrderChangingEvent;
        public event System.EventHandler OrderChanging
        {
            add
            {
                OrderChangingEvent = (System.EventHandler)System.Delegate.Combine(OrderChangingEvent, value);
            }
            remove
            {
                OrderChangingEvent = (System.EventHandler)System.Delegate.Remove(OrderChangingEvent, value);
            }
        }

        private System.EventHandler CounterChangedEvent;
        public event System.EventHandler CounterChanged
        {
            add
            {
                CounterChangedEvent = (System.EventHandler)System.Delegate.Combine(CounterChangedEvent, value);
            }
            remove
            {
                CounterChangedEvent = (System.EventHandler)System.Delegate.Remove(CounterChangedEvent, value);
            }
        }

        private System.EventHandler ShelfChangedEvent;
        public event System.EventHandler ShelfChanged
        {
            add
            {
                ShelfChangedEvent = (System.EventHandler)System.Delegate.Combine(ShelfChangedEvent, value);
            }
            remove
            {
                ShelfChangedEvent = (System.EventHandler)System.Delegate.Remove(ShelfChangedEvent, value);
            }
        }

        private System.EventHandler PrintStartEvent;
        public event System.EventHandler PrintStart
        {
            add
            {
                PrintStartEvent = (System.EventHandler)System.Delegate.Combine(PrintStartEvent, value);
            }
            remove
            {
                PrintStartEvent = (System.EventHandler)System.Delegate.Remove(PrintStartEvent, value);
            }
        }

        public string OrderID
        {
            get
            { return s_order_id; }
            set
            { 
                s_order_id = value;
                txtOrderID.Text = value;
            }
        }

        public string MatID
        {
            get { return s_mat_id; }
            set{ s_mat_id = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatDesc
        {
            get { return s_mat_desc; }
            set 
            { 
                s_mat_desc = value;
                if (s_mat_id != "")
                    txtMaterial.Text = "[" + s_mat_id + "]" + s_mat_desc;
                else
                    txtMaterial.Text = s_mat_desc;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResID
        {
            get
            {  return s_res_id; }
            set { s_res_id = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResDesc
        {
            get { return s_res_desc; }
            set 
            { 
                s_res_desc = value;
                txtResource.Text = value;
            }
        }

        public string LineID
        {
            get { return s_line_id; }
            set { s_line_id = value; }
        }

        public string LineDesc
        {
            get { return s_line_desc; }
            set { s_line_desc = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShelfDate
        {
            get { return s_shelf_date; }
        }

        public int OrdQty
        {
            get {return i_ord_qty; }
            set 
            { 
                i_ord_qty = value;
                numOrderBoxQty.Value = i_ord_qty;
                if (i_ord_qty > 0 && i_box_per_pallet > 0)
                    numOrderPalletQty.Value = (int)Math.Round((double)i_ord_qty / (double)i_box_per_pallet);
                else
                    numOrderPalletQty.Value = 0;
            }
        }

        public int BoxPerPallet
        {
            get { return i_box_per_pallet; }
            set 
            { 
                i_box_per_pallet = value;
                numBoxPerPallet.Value = value;
                if (i_ord_qty > 0 && i_box_per_pallet > 0)
                    numOrderPalletQty.Value = (int)Math.Round((double)i_ord_qty / (double)i_box_per_pallet);
                else
                    numOrderPalletQty.Value = 0;
            }
        }

        public int CumProdQty
        {
            get { return i_cum_prod_qty; }
            set 
            {
                i_cum_prod_qty = value;
                numCumProdBoxQty.Value = i_cum_prod_qty;
            }
        }

        public int ProdQty
        {
            get { return i_prod_qty; }
            set
            {
                i_prod_qty = value;
                numProdBoxQty.Value = i_prod_qty;
            }
        }

        public int BoxQty
        {
            get { return i_box_qty;}
            set
            {
                i_box_qty = value;
                if(this.DesignMode == false)
                    numProdPalletQty.Value = i_box_qty;
            }
        }

        public string CounterID
        {
            get {return s_counter_id; }
            set { s_counter_id = value; }
        }

        public string CounterDesc
        {
            get { return s_counter_desc; }
            set { s_counter_desc = value; }
        }

        private int View_Last_Qty_Of_Counter(string s_counter_id)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;

            int i_ret = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ATTR_TYPE";
                dvcArgu[1].sCondition_Value = MPGC.MP_ATTR_TYPE_RESOURCE;

                dvcArgu[2].sCondtion_ID = "ATTR_NAME";
                dvcArgu[2].sCondition_Value = "MP_RESOURCE_CNT";

                dvcArgu[3].sCondtion_ID = "ATTR_KEY";
                dvcArgu[3].sCondition_Value = s_counter_id;

                if (TPDR.GetDataOne("", ref dt, "CWIP8532-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return i_ret;
                }

                i_ret = MPCF.ToInt(dt.Rows[0]["VALUE"]);

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return i_ret;
            }

            return i_ret;
        }

        private void btnOrderSelect_Click(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            DialogResult drRet;
            int i = 0;

            try
            {
                frmWIPViewWorkOrderList frm = new frmWIPViewWorkOrderList();
                frm.s_mold_pack_flag = "Y";
                frm.b_show_reset_buttom = true;

                drRet = frm.ShowDialog(this);

                if (drRet == DialogResult.OK)
                {
                    i = frm.mspdWorkOrder.ActiveRowIndex;

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "RES_ID";
                    dvcArgu[1].sCondition_Value = MPCF.Trim(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Tag);

                    if (TPDR.GetDataOne("", ref dt, "CWIP8532-001", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        // CMN479 ERROR - 충진기에 ESL 탱크 또는 저장 탱크를 지정하세요.
                        MPCF.ShowMessage(MPCF.GetMessage(479), MSG_LEVEL.ERROR, true);

                        GC.Collect();
                        return;
                    }

                    if (MPCF.Trim(txtOrderID.Text) != frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Text)
                    {
                        if (OrderChangingEvent != null)
                            OrderChangingEvent(this, e);

                        OrderID = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Text;
                        MatID = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_ID].Text;
                        MatDesc = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_DESC].Text;
                        ResDesc = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Text;
                        ResID = MPCF.Trim(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Tag);
                        LineID = MPCF.Trim(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Tag);
                        LineDesc = MPCF.Trim(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Value);

                        OrdQty = MPCF.ToInt(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_QTY].Value);
                        BoxPerPallet = MPCF.ToInt(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.BOX_QTY].Value);
                        CumProdQty = MPCF.ToInt(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RLT_QTY].Value);

                        CounterID = "";
                        CounterDesc = "";
                        s_shelf_date = "";
                        cboShelfLife.Clear();

                        BoxQty = (int)(CumProdQty / BoxPerPallet);

                        BICF.View_Shelf_Life(s_order_id, cboShelfLife);

                        if (OrderChangedEvent != null)
                            OrderChangedEvent(this, e);
                    }                    
                }
                else if (drRet == DialogResult.No)
                {
                    if (OrderChangingEvent != null)
                        OrderChangingEvent(this, e);

                    OrderID = "";
                    MatID = "";
                    MatDesc = "";
                    ResDesc = "";
                    ResID = "";
                    LineID = "";
                    LineDesc = "";
                    CumProdQty = 0;

                    OrdQty = 0;
                    BoxPerPallet = 0;

                    CounterID = "";
                    CounterDesc = "";
                    s_shelf_date = "";
                    cboShelfLife.Clear();

                    BoxQty = 0;

                    if (OrderChangedEvent != null)
                        OrderChangedEvent(this, e);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintStartEvent != null)
                    PrintStartEvent(this, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cboShelfLife_SelectionChanged(object sender, EventArgs e)
        {
            if (s_shelf_date != "")
                CumProdQty = 0;

            s_shelf_date = cboShelfLife.Text.Replace("-", "");

            if (ShelfChangedEvent != null)
                ShelfChangedEvent(this, e);
        }

        private void btnSelectCounter_Click(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

            BOI.OIFrx.BOIPopup.frmCodeViewPopup cvp = null;
            BOI.OIFrx.BOIControls.BOICodeView cdv = null;

            DialogResult drResult;

            try
            {
                if (s_order_id == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, true);
                    return;
                }

                cdv = new BOI.OIFrx.BOIControls.BOICodeView();

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_ID";
                dvcArgu[1].sCondition_Value = s_line_id;

                dvcArgu[2].sCondtion_ID = "USER_ID";
                dvcArgu[2].sCondition_Value = MPGV.gsUserID;

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                dvcArgu[3].sCondition_Value = s_line_id;

                cvp = new BOI.OIFrx.BOIPopup.frmCodeViewPopup();

                // 초기화
                if (cvp.InitCodeViewPopup(cdv, "Resource", "COM0000-025", dvcArgu, null, null, "RES_DESC", -1, false) == false)
                {
                    return;
                }

                // Show Dialog
                cvp.Owner = MPGV.gfrmMDI;
                drResult = cvp.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    if (s_counter_id != cvp.ReturnDatas[0])
                    {
                        if (s_counter_id != "")
                        {
                            CumProdQty = 0;
                        }

                        s_counter_id = cvp.ReturnDatas[0];
                        s_counter_desc = cvp.ReturnDatas[1];

                        ProdQty = View_Last_Qty_Of_Counter(s_counter_id);
                        CumProdQty += ProdQty;

                        if (CounterChangedEvent != null)
                            CounterChangedEvent(this, e);

                    }
                }

                if (cvp.Owner != null)
                {
                    cvp.Owner.Activate();
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Counter 설비의 집계수량 조정
        /// </summary>
        /// <returns></returns>
        private bool Adjust_Quantity_Of_Counter()
        {
            TRSNode in_node = new TRSNode("Adjust_Quantity_Of_Counter_In");
            TRSNode out_node = new TRSNode("Cnm_Out");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COUNTER_ID", s_counter_id);
                in_node.AddString("ORDER_ID", s_order_id);
                in_node.AddString("RES_ID", s_res_id);
                in_node.AddString("LINE_ID", s_line_id);
                in_node.AddString("FILLER_ID", s_res_id);
                in_node.AddInt("QTY", -1);
                in_node.AddChar("AJT_FLAG", 'Y');

                if (MPCF.CallService("BRAS", "BRAS_Adjust_Quantity_Of_Counter", in_node, ref out_node) == false)
                    return false;

                CumProdQty--;
                ProdQty--;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if(MPCF.ToInt(numProdBoxQty.Value) > 0)
                Adjust_Quantity_Of_Counter();
        }
    }
}
