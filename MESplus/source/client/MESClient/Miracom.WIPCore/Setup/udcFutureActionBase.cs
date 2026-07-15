using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore.Setup
{
    public interface intFutureActionControl
    {
        void initControl();
        void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper);
        void setPoint(char c_oper_point, char c_ba_point, char c_skip_originated_service);
        bool checkCondition();
        void setAction(TRSNode node);
        void getAction(TRSNode node);
        void setMFOSelectLevel(Miracom.MESCore.Controls.MFOSelectLevel SelectLevel);
        Miracom.MESCore.Controls.MFOSelectLevel getMFOSelectLevel();
    }

    public partial class udcFutureActionBase : UserControl, intFutureActionControl
    {
        protected string m_s_mat_id;
        protected int m_i_mat_ver;
        protected string m_s_flow;
        protected string m_s_oper;
        protected Miracom.MESCore.Controls.MFOSelectLevel m_select_level;
        protected char m_c_oper_point;
        protected char m_c_ba_point;
        protected char m_c_skip_originated_service;

        public udcFutureActionBase()
        {
            InitializeComponent();

            m_s_mat_id = "";
            m_i_mat_ver = 0;
            m_s_flow = "";
            m_s_oper = "";
            m_c_oper_point = ' ';
            m_c_ba_point = ' ';
            m_c_skip_originated_service = ' ';
        }

        public virtual void initControl()
        {
            m_s_mat_id = "";
            m_i_mat_ver = 0;
            m_s_flow = "";
            m_s_oper = "";

            MPCF.FieldClear(this);
        }

        public virtual void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            m_s_mat_id = s_mat_id;
            m_i_mat_ver = i_mat_ver;
            m_s_flow = s_flow;
            m_s_oper = s_oper;
        }

        public virtual void setPoint(char c_oper_point, char c_ba_point, char c_skip_originated_service)
        {
            m_c_oper_point = c_oper_point;
            m_c_ba_point = c_ba_point;
            m_c_skip_originated_service = c_skip_originated_service;
        }

        public virtual bool checkCondition()
        {
            // Do nothing
            return false;
        }

        public virtual void setAction(TRSNode node)
        {
            // Do nothing
        }

        public virtual void getAction(TRSNode node)
        {
            // Do nothing
        }

        public virtual void setMFOSelectLevel(Miracom.MESCore.Controls.MFOSelectLevel SelectLevel)
        {
            m_select_level = SelectLevel;
        }

        public virtual Miracom.MESCore.Controls.MFOSelectLevel getMFOSelectLevel()
        {
            return m_select_level;
        }
    }
}
