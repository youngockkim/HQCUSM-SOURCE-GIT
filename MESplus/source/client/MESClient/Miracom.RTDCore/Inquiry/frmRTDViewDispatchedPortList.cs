using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RTDCore
{
    public partial class frmRTDViewDispatchedPortList : Miracom.MESCore.ViewForm01
    {
        public frmRTDViewDispatchedPortList()
        {
            InitializeComponent();
        }
        char c_case = ' ';

        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvResource, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvPort, 1) == false)
            {
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            switch(cboRequestType.SelectedIndex)
            {
                case 0:
                    c_case = '1';
                    break;
                case 1:
                    c_case = '2';
                    break;
                case 2:
                    c_case = '3';
                    break;
                case 3:
                    c_case = '4';
                    break;
            }

            RTDLIST.ViewDispatchedPortList(lisPortList, c_case, cdvResource.Text, cdvPort.Text, chkUnselect.Checked, chkUncapable.Checked);
            MPCF.FitColumnHeader(lisPortList);
        }

        private void frmRTDViewDispatchedPortList_Load(object sender, EventArgs e)
        {
            cboRequestType.SelectedIndex = 0;
            MPCF.InitListView(lisPortList);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            if (cdvPort.Text != "")
            {
                sCond = sCond + "Port ID    : " + cdvPort.Text + "\r";
            }

            if (MPCF.ExportToExcel(lisPortList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        private void cdvResource_ButtonPress(object sender, EventArgs e)
        {
            cdvResource.Init();
            MPCF.InitListView(cdvResource.GetListView);
            cdvResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResource.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResource.GetListView, false);
        }

        private void cdvResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisPortList);
        }

        private void cdvPort_ButtonPress(object sender, EventArgs e)
        {
            cdvPort.Init();
            MPCF.InitListView(cdvPort.GetListView);
            cdvPort.Columns.Add("Port ID", 50, HorizontalAlignment.Left);
            cdvPort.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPort.SelectedSubItemIndex = 0;
            RASLIST.ViewPortList(cdvPort.GetListView, '1', cdvResource.Text, "");
        }

        private void cdvPort_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvResource.Text != "" && cdvPort.Text != ""
                || cdvResource.Text != "" && cboRequestType.SelectedIndex == 3)
            {
                switch (cboRequestType.SelectedIndex)
                {
                    case 0:
                        c_case = '1';
                        break;
                    case 1:
                        c_case = '2';
                        break;
                    case 2:
                        c_case = '3';
                        break;
                    case 3:
                        c_case = '4';
                        break;
                }

                RTDLIST.ViewDispatchedPortList(lisPortList, c_case, cdvResource.Text, cdvPort.Text, chkUnselect.Checked, chkUncapable.Checked);
                MPCF.FitColumnHeader(lisPortList);
            }
        }
    }
}

