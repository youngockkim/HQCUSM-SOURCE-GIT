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
    public partial class udcStepActionMoveStep : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionMoveStep()
        {
            InitializeComponent();
            initControl();
        }

        #region "Functions"

        public override void initControl()
        {
            base.initControl();
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            switch (node.GetString("DATA_1"))
            {
                case "1": rbtMoveToStep.Checked = true; break;
                case "2": rbtMoveToCnt.Checked = true; break;
                default: rbtMoveToStep.Checked = true; break;
            }
            cdvToStep.Text = node.GetString("DATA_2");
            numByCount.Value = MPCF.ToInt(node.GetString("DATA_3"));
        }

        public override bool checkCondition()
        {
            if (rbtMoveToStep.Checked == true)
            {
                if (MPCF.CheckValue(cdvToStep, 1) == false) return false;
            }
            else if (rbtMoveToCnt.Checked == true)
            {
                if (numByCount.Value == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    numByCount.Focus();
                    return false;
                }
            }

            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "MOVE STEP");

            if (rbtMoveToStep.Checked == true)
            {
                node.AddString("DATA_1", "1");
                node.AddString("DATA_2", cdvToStep.Text);
            }
            else if (rbtMoveToCnt.Checked == true)
            {
                node.AddString("DATA_1", "2");
                node.AddString("DATA_3", numByCount.Value);
            }
        }

        public void setWorkProcType(string s_work_proc_type)
        {
            cdvToStep.Init();
            MPCF.InitListView(cdvToStep.GetListView);
            cdvToStep.Columns.Add("Step ID", 150, HorizontalAlignment.Left);
            cdvToStep.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvToStep.SelectedSubItemIndex = 0;
            WEMLIST.ViewProcessStepList(cdvToStep.GetListView, s_work_proc_type);
        }

        #endregion

        private void udcStepActionMoveStep_Load(object sender, EventArgs e)
        {
            rbtMoveToStep.Checked = true;
        }

        private void rbtMove_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMoveToStep.Checked == true)
            {
                cdvToStep.Enabled = true;

                numByCount.Value = 0;
                numByCount.Enabled = false;
            }
            else if (rbtMoveToCnt.Checked == true)
            {
                numByCount.Enabled = true;

                cdvToStep.Text = "";
                cdvToStep.Enabled = false;
            }
        }


    }
}
