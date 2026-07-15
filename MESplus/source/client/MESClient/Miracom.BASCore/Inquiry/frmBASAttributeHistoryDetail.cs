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
    public partial class frmBASAttributeHistoryDetail : Form
    {
        public frmBASAttributeHistoryDetail()
        {
            InitializeComponent();
        }

        private string sAttrKey;
        private string sAttrName;
        private string sAttrType;
        private int iAttrHistSeq;

        private bool b_load_flag = false;



        public string AttributeKey
        {
            set
            {
                sAttrKey = value;
            }
        }

        public string AttributeName
        {
            set
            {
                sAttrName = value;
            }
        }

        public string AttributeType
        {
            set
            {
                sAttrType = value;
            }
        }

        public int AttributeHistSeq
        {
            set
            {
                iAttrHistSeq = value;
            }
        }

        private void ViewAttributeHistory()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_KEY", sAttrKey);
            in_node.AddString("ATTR_NAME", sAttrName);
            in_node.AddString("ATTR_TYPE", sAttrType);
            in_node.AddInt("HIST_SEQ", iAttrHistSeq);
            

            if (MPCR.CallService("BAS", "BAS_View_Attribute_History", in_node, ref out_node) == false)
            {
                return;
            }

            txtAttrKey.Text = MPCF.Trim(sAttrKey);
            txtAttrName.Text = MPCF.Trim(sAttrName);
            txtAttrType.Text = MPCF.Trim(sAttrType);
            txtHistorySeq.Text = iAttrHistSeq.ToString();
            txtTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("TRAN_TIME"));

            txtOldAttrValue.Text = out_node.GetString("ATTR_OLD_VALUE");
            txtAttrValue.Text = out_node.GetString("ATTR_NEW_VALUE");

        }




        private void frmAttributeHistoryDetail_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmAttributeHistoryDetail_Activated(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Activated(this, e);
            }

            if (b_load_flag == false)
            {
                ViewAttributeHistory();
                b_load_flag = true;
            }
        }

        private void frmAttributeHistoryDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Closed(this, e);
            }
        }

        private void frmAttributeHistoryDetail_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
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