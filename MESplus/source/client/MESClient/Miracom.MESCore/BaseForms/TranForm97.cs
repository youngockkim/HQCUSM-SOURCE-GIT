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
    public partial class TranForm97 : Miracom.MESCore.TranForm95
    {
        private TRSNode m_lot_info;

        public TranForm97()
        {
            InitializeComponent();
            this.spdLotInfo.Tag = "Change Cell";
        }

        private void TranForm97_Load(object sender, EventArgs e)
        {
            m_lot_info = null;
            ClearLotSpread();
        }

        private void spdLotInfo_Resize(System.Object sender, System.EventArgs e)
        {
            int iDiffSize;

            try
            {
                iDiffSize = (spdLotInfo.Size.Width - 714) / 3;

                if (iDiffSize >= 0)
                {
                    spdLotInfo.ActiveSheet.Columns[1].Width = 126 + iDiffSize;
                    spdLotInfo.ActiveSheet.Columns[3].Width = 126 + iDiffSize;
                    spdLotInfo.ActiveSheet.Columns[5].Width = 126 + iDiffSize;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnRefresh.PerformClick();
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
            return ViewLotInfo(s_lot_id, true);
        }

        protected virtual bool ViewLotInfo(string s_lot_id, bool b_show_inform_note)
        {
            s_lot_id = MPCF.Trim(s_lot_id);
            if (s_lot_id == "") return false;
            if (MPCR.SetLotInfoSpread(spdLotInfo, s_lot_id, ref m_lot_info) == false) return false;

            if (b_show_inform_note == true)
            {
                MPCR.PopupInformNote(null, "", s_lot_id, "", "", "", "");
            }

            return true;
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

        protected void ClearLotSpread()
        {
            MPCR.ClearLotSpread(spdLotInfo);
        }


    }
}

