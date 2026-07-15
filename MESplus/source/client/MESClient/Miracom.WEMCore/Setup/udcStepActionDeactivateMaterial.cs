using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace Miracom.WEMCore.Setup
{
    public partial class udcStepActionDeactivateMaterial : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionDeactivateMaterial()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            cdvMatID.Text = "@MATERIAL";
        }
        
        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvMatID.Text = node.GetString("DATA_1");
            cdvMatID.Version = MPCF.ToInt(node.GetString("DATA_2"));
            chkAllVersions.Checked = (node.GetString("DATA_3") == "Y" ? true : false);
        }

        public override bool checkCondition()
        {
            if (MPCF.Trim(cdvMatID.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvMatID.MaterialFocus();
                return false;
            }
            if (cdvMatID.Text != "@MATERIAL")
            {
                if (cdvMatID.Version < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMatID.VersionFocus();
                    return false;
                }
            }
            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "DEACTIVATE MATERIAL");

            node.AddString("DATA_1", cdvMatID.Text);
            if (cdvMatID.Text == "@MATERIAL")
            {
                node.AddString("DATA_2", "@");
            }
            else
            {
                node.AddString("DATA_2", cdvMatID.Version.ToString());
            }
            node.AddString("DATA_3", chkAllVersions.Checked == true ? "Y" : "");
        }

        #endregion

        private void cdvMatID_MaterialButtonPressAfter(object sender, EventArgs e)
        {
            if (cdvMatID.MaterialItems.Count > 0)
            {
                cdvMatID.MaterialItems.Insert(0, new ListViewItem(new string[] { "@MATERIAL", "", "" }));
            }
        }
    
    
    
    }
}
