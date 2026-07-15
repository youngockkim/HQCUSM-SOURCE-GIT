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
    public partial class frmBASTranAttributeDetail : Form
    {
        public frmBASTranAttributeDetail()
        {
            InitializeComponent();
        }

        #region " Variable Definition "

        private string sAttrKey;
        private string sAttrName;
        private string sAttrDesc;
        private string sAttrType;

        private bool b_load_flag = false;
        /*** #989 SPM Development (2012.04.25 by JYPARK) ***/
        private string sSpecID;
        private int iSpecVer;
        private string sCharID;
        /*** End of Add (2012.04.25) ***/

        #endregion

        #region " Property Definition "

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

        public string AttributeDesc
        {
            get
            {
                return sAttrDesc;
            }
            set
            {
                sAttrDesc = value;
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

        public string AttributeValue
        {
            get
            {
                return txtAttrValue.Text;
            }
        }
        /*** #989 SPM Development (2012.04.25 by JYPARK) ***/
        public string SpecID
        {
            get
            {
                return sSpecID;
            }
            set
            {
                sSpecID = value;
            }
        }

        public int SpecVersion
        {
            get
            {
                return iSpecVer;
            }
            set
            {
                iSpecVer = value;
            }
        }

        public string CharID
        {
            get
            {
                return sCharID;
            }
            set
            {
                sCharID = value;
            }
        }
        /*** End of Add (2012.04.25) ***/
        #endregion

        #region " Function Definition "

        private void ViewAttributeDetail()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_KEY", sAttrKey);
            in_node.AddString("ATTR_NAME", sAttrName);
            in_node.AddString("ATTR_TYPE", sAttrType);
            /*** #989 SPM Development (2012.04.25 by JYPARK) ***/
            in_node.AddString("SPEC_REL_ID", sSpecID);
            in_node.AddString("SPEC_REL_VER", iSpecVer);
            in_node.AddString("CHAR_ID", sCharID);
            /*** End of Add (2012.04.25) ***/

            if (MPCR.CallService("BAS", "BAS_View_Attribute", in_node, ref out_node) == false)
            {
                return;
            }

            txtAttrKey.Text = MPCF.Trim(sAttrKey);
            txtAttrName.Text = MPCF.Trim(sAttrName);
            txtAttrDesc.Text = MPCF.Trim(sAttrDesc);
            txtAttrType.Text = MPCF.Trim(sAttrType);
            txtAttrValue.Text = MPCF.Trim(out_node.GetString("ATTR_VALUE"));

            txtAttrValue.MaxLength = out_node.GetInt("ATTR_SIZE");
        }

        #endregion

        private void frmBASTranAttributeDetail_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmBASTranAttributeDetail_Activated(object sender, EventArgs e)
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

        private void frmBASTranAttributeDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Closed(this, e);
            }
        }

        private void frmBASTranAttributeDetail_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    
    
    }
}