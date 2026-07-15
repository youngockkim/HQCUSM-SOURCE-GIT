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
    public partial class TranForm27 : Miracom.MESCore.TranForm21
    {
        private TRSNode m_lot_info;
        private TRSNode m_lot_cond;
        private char mc_view_lot_proc_step;
        private string ms_view_lot_module_name;
        private string ms_view_lot_service_name;
        private bool mb_view_lot_success_flag;
        private bool mb_use_flexible_screen_service_flag;

        public TranForm27()
        {
            mc_view_lot_proc_step = '1';
            ms_view_lot_module_name = "WIP";
            ms_view_lot_service_name = "WIP_View_Lot";
            mb_use_flexible_screen_service_flag = false;
            
            m_lot_info = null;
            m_lot_cond = null;

            InitializeComponent();
        }

        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    txtLotID.Focus();
                    return;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return;
            }
        }

        protected virtual bool ViewLotInfo(string s_lot_id)
        {
            mb_view_lot_success_flag = false;

            s_lot_id = MPCF.Trim(s_lot_id);
            if (s_lot_id == "") return false;

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            if (ms_view_lot_module_name == null || ms_view_lot_module_name == "")
            {
                ms_view_lot_module_name = "WIP";
            }
            if (ms_view_lot_service_name == null || ms_view_lot_service_name == "")
            {
                ms_view_lot_service_name = "WIP_View_Lot";
            }
            if (MPCF.Trim(mc_view_lot_proc_step) == "")
            {
                mc_view_lot_proc_step = '1';
            }
            if (m_lot_cond != null)
            {
                for (int i = 0; i < m_lot_cond.MemberCount; i++)
                {
                    in_node.AddMember(m_lot_cond.Members[i].Name, m_lot_cond.Members[i].Value, m_lot_cond.Members[i].ValueType);
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = mc_view_lot_proc_step;
            in_node.AddString("LOT_ID", s_lot_id);

            if (mb_use_flexible_screen_service_flag == false)
            {
                if (MPCR.CallService(ms_view_lot_module_name, ms_view_lot_service_name, in_node, ref out_node) == false)
                {
                    m_lot_info = null;
                    return false;
                }

                mb_view_lot_success_flag = true;
                m_lot_info = out_node;

                txtLotDesc.Text = LOT.GetString("LOT_DESC");

                udcLotInfor.ScreenSpread.Tag = "Change Cell";
                udcLotInfor.ProcStep = '1';
                udcLotInfor.LotID = s_lot_id;
                if (udcLotInfor.LoadDesign() == false) return false;
                if (udcLotInfor.SetDataToScreen(out_node) == false) return false;
            }
            else
            {
                udcLotInfor.ScreenSpread.Tag = "Change Cell";
                udcLotInfor.ProcStep = '1';
                udcLotInfor.LotID = s_lot_id;
                if (udcLotInfor.LoadDesign() == false) return false;
                if (udcLotInfor.SetServiceData(in_node, ref out_node) == false) return false;

                mb_view_lot_success_flag = true;

                m_lot_info = out_node;

                txtLotDesc.Text = LOT.GetString("LOT_DESC");
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
                        udcLotInfor.InitFlexibleScreen();
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        protected TRSNode LOT
        {
            get
            {
                if (m_lot_info == null)
                {
                    return new TRSNode("VIEW_LOT_OUT");
                }
                else
                {
                    return m_lot_info;
                }
            }
        }

        protected string VIEW_LOT_MODULE_NAME
        {
            set
            {
                ms_view_lot_module_name = value;
            }
        }

        protected string VIEW_LOT_SERVICE_NAME
        {
            set
            {
                ms_view_lot_service_name = value;
            }
        }

        protected char VIEW_LOT_PROC_STEP
        {
            set
            {
                mc_view_lot_proc_step = value;
            }
        }

        protected TRSNode VIEW_LOT_COND
        {
            set
            {
                m_lot_cond = value;
            }
        }

        protected bool VIEW_LOT_SUCCESS_FLAG
        {
            get
            {
                return mb_view_lot_success_flag;
            }
        }

        protected bool USE_FLEXIBLE_SCREEN_SERVICE_FLAG
        {
            get
            {
                return mb_use_flexible_screen_service_flag;
            }
            set
            {
                mb_use_flexible_screen_service_flag = value;
            }
        }



    }
}
