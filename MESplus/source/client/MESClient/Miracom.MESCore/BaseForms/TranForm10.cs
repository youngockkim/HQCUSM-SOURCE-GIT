using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class TranForm10 : Miracom.MESCore.TranForm02
    {
        private TRSNode m_sublot_info;

        public TranForm10()
        {
            InitializeComponent();
            this.spdSubLotInfo.Tag = "Change Cell";
        }

        private void spdSubLotInfo_Resize(System.Object sender, System.EventArgs e)
        {
            int iDiffSize;

            try
            {
                iDiffSize = (spdSubLotInfo.Size.Width - 714) / 3;

                if (iDiffSize >= 0)
                {
                    spdSubLotInfo.ActiveSheet.Columns[1].Width = 126 + iDiffSize;
                    spdSubLotInfo.ActiveSheet.Columns[3].Width = 126 + iDiffSize;
                    spdSubLotInfo.ActiveSheet.Columns[5].Width = 126 + iDiffSize;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void TranForm10_Load(object sender, EventArgs e)
        {
            m_sublot_info = null;
            ClearSubLotSpread();

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            txtTranDateTime.Visible = !chkTranDateTime.Checked;
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;

            txtTranDateTime.TabStop = !chkTranDateTime.Checked;
            dtpTranDate.TabStop = chkTranDateTime.Checked;
            dtpTranTime.TabStop = chkTranDateTime.Checked;

        }

        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        protected override void OnDeactivate(System.EventArgs e)
        {

            if (btnProcess.Focused == true)
            {
                txtSublotID.Focus();
                txtSublotID.SelectionStart = txtSublotID.TextLength;
            }

            base.OnDeactivate(e);

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtSublotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        protected void SetCMFItem(string s_item_name)
        {
            MPCR.SetCMFItem(s_item_name, "lblCMF", "cdvCMF", grpCMF);
        }

        protected bool CheckCMFItemValue()
        {
            return MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF);
        }

        private void txtSublotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (ViewSubLotInfo(txtSublotID.Text) == false)
                {
                    txtSublotID.Focus();
                    return;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ViewSubLotInfo(txtSublotID.Text) == false)
            {
                txtSublotID.Focus();
                return;
            }
        }

        protected virtual bool ViewSubLotInfo(string s_sublot_id)
        {
            s_sublot_id = MPCF.Trim(s_sublot_id);
            if (s_sublot_id == "") return false;
            return MPCR.SetSublotInfoSpread(spdSubLotInfo, s_sublot_id, ref m_sublot_info);
        }

        protected TRSNode SUBLOT
        {
            get
            {
                if (m_sublot_info == null)
                {
                    return new TRSNode("VIEW_SUBLOT_OUT");
                }
                else
                {
                    return m_sublot_info;
                }
            }
        }

        protected void ClearSubLotSpread()
        {
            MPCR.ClearSubLotSpread(spdSubLotInfo);
        }
    }
}

