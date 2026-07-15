using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASAttributeDetail : Form
    {
        public frmBASAttributeDetail()
        {
            InitializeComponent();
        }

        private string sAttrKey;
        private string sAttrName;
        private string sAttrType;
        private bool b_load_flag = false;        
        
        public string AttributeKey
        {
            get
            {
                return sAttrKey;
            }
            set
            {
                sAttrKey = value;
            }
        }

        public string AttributeName
        {
            get
            {
                return sAttrName;
            }
            set
            {
                sAttrName = value;
            }
        }

        public string AttributeType
        {
            get
            {
                return sAttrType;
            }
            set
            {
                sAttrType = value;
            }
        }

        private void ViewAttributeDetail()
        {
            int i_key_hist_seq;
            int i_last_active_hist_seq;
            int i_last_hist_seq;

            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            MPCR.SetInMsg(in_node);
            in_node.AddString("ATTR_KEY", sAttrKey);
            in_node.AddString("ATTR_NAME", sAttrName);
            in_node.AddString("ATTR_TYPE", sAttrType);
            in_node.ProcStep = '1';

            if (MPCR.CallService("BAS", "BAS_View_Attribute", in_node, ref out_node) == false)
            {                
                return;
            }

            txtAttrKey.Text = MPCF.Trim(sAttrKey);
            txtAttrName.Text = MPCF.Trim(sAttrName);
            txtAttrType.Text = MPCF.Trim(sAttrType);
            txtAttrValue.Text = out_node.GetString("ATTR_VALUE");
            i_key_hist_seq = out_node.GetInt("KEY_HIST_SEQ");
            txtHistorySeq.Text = i_key_hist_seq.ToString();
            i_last_active_hist_seq = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");
            txtLastActiveHistorySeq.Text = i_last_active_hist_seq.ToString();
            i_last_hist_seq = out_node.GetInt("LAST_HIST_SEQ");
            txtLastHistorySeq.Text = i_last_hist_seq.ToString();
            txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));        
        }


        
        
        private void frmAttributeDetail_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmAttributeDetail_Activated(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Activated(this, e);
            }

            if (b_load_flag == false)
            {
                b_load_flag = true;
                ViewAttributeDetail();
            }
        }

        private void frmAttributeDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Closed(this, e);
            }
        }

        private void frmAttributeDetail_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}