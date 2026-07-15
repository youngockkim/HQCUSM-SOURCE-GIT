using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class TranForm28 : Miracom.MESCore.TranForm27
    {
        public TranForm28()
        {
            InitializeComponent();
            m_input_value_point = MESCore.Controls.INPUT_VALUE_POINT.ADHOC;
            m_res_id = "";
        }

        private Controls.INPUT_VALUE_POINT m_input_value_point;
        private string m_res_id;

        protected Controls.INPUT_VALUE_POINT GetInputValuePoint()
        {
            return m_input_value_point;
        }
        protected void SetInputValuePoint(Controls.INPUT_VALUE_POINT point)
        {
            m_input_value_point = point;
        }

        protected string GetResID()
        {
            return m_res_id;
        }

        protected void SetResID(string s_res_id)
        {
            m_res_id = s_res_id;

            if (udcAttrValue.ItemInputSheet.RowCount > 0)
            {
                udcAttrValue.SetUseResource(m_res_id);
            }
            if (udcToolValue.ItemInputSheet.RowCount > 0)
            {
                udcToolValue.SetUseResource(m_res_id);
            }
        }

        protected virtual bool GetToolList()
        {
            char c_point_type;

            try
            {
                if (MPCF.CheckValue(txtLotID, 1) == false) return false;

                cdvToolID.Init();
                MPCF.InitListView(cdvToolID.GetListView);
                cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
                cdvToolID.Columns.Add("Tool Desc", 100, HorizontalAlignment.Left);
                cdvToolID.Columns.Add("Used Resource", 100, HorizontalAlignment.Left);
                cdvToolID.SelectedSubItemIndex = 0;
                cdvToolID.DisplaySubItemIndex = 0;

                c_point_type = ' ';
                if (m_input_value_point == MESCore.Controls.INPUT_VALUE_POINT.START)
                {
                    c_point_type = 'S';
                }
                else if (m_input_value_point == MESCore.Controls.INPUT_VALUE_POINT.END)
                {
                    c_point_type = 'E';
                }
                else if (m_input_value_point == MESCore.Controls.INPUT_VALUE_POINT.ADHOC)
                {
                    c_point_type = 'A';
                }

                return WIPLIST.ViewToolListByMFO(cdvToolID.GetListView,
                                                 LOT.GetString("MAT_ID"),
                                                 LOT.GetInt("MAT_VER"),
                                                 LOT.GetString("FLOW"),
                                                 LOT.GetString("OPER"),
                                                 c_point_type,
                                                 m_res_id);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        protected override bool ViewLotInfo(string s_lot_id)
        {
            if (base.ViewLotInfo(s_lot_id) == false) return false;

            udcAttrValue.Init();

            System.Collections.ArrayList a_lots = new System.Collections.ArrayList();
            a_lots.Add(LOT.GetString("LOT_ID"));

            if (udcAttrValue.ViewOperInputValueList(a_lots,
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    m_input_value_point,
                                                    false) == true)
            {
                if (udcAttrValue.ItemInputSheet.RowCount < 1)
                {
                    udcAttrValue.Visible = false;
                    udcAttrValue.ActiveFlag = false;
                }
                else
                {
                    udcAttrValue.Visible = true;
                    udcAttrValue.ActiveFlag = true;
                    udcAttrValue.SetLotQty(LOT.GetDouble("QTY_1"));
                    udcAttrValue.SetLotCount(1);
                    udcAttrValue.SetCurrentTime();
                }
            }

            if (ViewToolInfo() == false)
            {
                return false;
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
                        udcAttrValue.Init();
                        udcToolValue.Init();
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
                if (udcAttrValue.CheckItemInputValue() == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    tabTranInfor.SelectedTab = tbpAttrToolValue;
                    return false;
                }
                if (udcToolValue.CheckItemInputValue() == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    tabTranInfor.SelectedTab = tbpAttrToolValue;
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

        protected virtual bool ViewToolInfo()
        {
            int i;

            udcToolValue.Init();
            cdvToolID.Text = "";

            if (GetToolList() == true)
            {
                if (cdvToolID.Items.Count < 1)
                {
                    udcToolValue.Visible = false;
                    udcToolValue.ActiveFlag = false;
                    pnlToolID.Visible = false;

                }
                else if (cdvToolID.Items.Count == 1)
                {
                    udcToolValue.Visible = true;
                    udcToolValue.ActiveFlag = true;
                    pnlToolID.Visible = false;
                    cdvToolID.Text = cdvToolID.Items[0].Text;
                }
                else
                {
                    udcToolValue.Visible = true;
                    udcToolValue.ActiveFlag = true;
                    pnlToolID.Visible = true;

                    if (m_res_id != "")
                    {
                        for (i = 0; i < cdvToolID.Items.Count; i++)
                        {
                            if (cdvToolID.Items[i].Text.Equals(m_res_id))
                            {
                                cdvToolID.Text = cdvToolID.Items[i].Text;
                                break;
                            }
                        }//end for

                        if (i >= cdvToolID.Items.Count && cdvToolID.Columns.Count > 2)
                        {
                            for (i = 0; i < cdvToolID.Items.Count; i++)
                            {
                                if (cdvToolID.Items[i].SubItems[2].Text.Equals(m_res_id))
                                {
                                    cdvToolID.Text = cdvToolID.Items[i].Text;
                                    break;
                                }
                            }//end for
                        }
                    }//end if
                }//end if

                if (cdvToolID.Text != "")
                {
                    System.Collections.ArrayList a_tools = new System.Collections.ArrayList();
                    a_tools.Add(cdvToolID.Text);

                    if (cdvToolID.Items.Count > 1 && cdvToolID.Columns.Count > 2 && m_res_id != "")
                    {
                        for (i = 0; i < cdvToolID.Items.Count; i++)
                        {
                            if (cdvToolID.Items[i].SubItems[2].Text.Equals(m_res_id))
                            {
                                if (cdvToolID.Text == cdvToolID.Items[i].Text)
                                {
                                    continue;
                                }

                                a_tools.Add(cdvToolID.Items[i].Text);
                            }
                        }//end for
                    }

                    if (udcToolValue.ViewOperInputValueList(a_tools,
                                                            LOT.GetString("MAT_ID"),
                                                            LOT.GetInt("MAT_VER"),
                                                            LOT.GetString("FLOW"),
                                                            LOT.GetString("OPER"),
                                                            m_input_value_point,
                                                            false) == true)
                    {
                        if (udcToolValue.ItemInputSheet.RowCount < 1)
                        {
                            udcToolValue.Visible = false;
                            udcToolValue.ActiveFlag = false;
                        }
                        else
                        {
                            udcToolValue.Visible = true;
                            udcToolValue.ActiveFlag = true;

                            udcToolValue.SetLotQty(LOT.GetDouble("QTY_1"));
                            udcToolValue.SetLotCount(1);
                            udcToolValue.SetCurrentTime();
                        }
                    }
                }
            }

            return true;
        }

        protected virtual bool SetItemValue(TRSNode in_node)
        {
            if (udcAttrValue.ItemInputSheet.RowCount > 0)
            {
                if (udcAttrValue.SetItemInputValue(in_node) == false)
                {
                    return false;
                }
            }
            if (udcToolValue.ItemInputSheet.RowCount > 0)
            {
                if (udcToolValue.SetItemInputValue(in_node) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void cdvToolID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolID.Text != "")
            {
                System.Collections.ArrayList a_tools = new System.Collections.ArrayList();
                a_tools.Add(cdvToolID.Text);

                if (udcToolValue.ViewOperInputValueList(a_tools,
                                                        LOT.GetString("MAT_ID"),
                                                        LOT.GetInt("MAT_VER"),
                                                        LOT.GetString("FLOW"),
                                                        LOT.GetString("OPER"),
                                                        m_input_value_point,
                                                        true) == true)
                {
                    udcToolValue.SetLotQty(LOT.GetDouble("QTY_1"));
                    udcToolValue.SetLotCount(1);
                    udcToolValue.SetCurrentTime();
                }
            }
        }

        private void tbpAttrToolValue_Resize(object sender, EventArgs e)
        {
            grpAttrValue.Width = tbpAttrToolValue.Width / 2;
        }



    }
}
