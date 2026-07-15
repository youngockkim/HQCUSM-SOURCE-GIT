using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.BASCore
{
    public partial class frmBASSubSetupTable : Form
    {
        public frmBASSubSetupTable()
        {
            InitializeComponent();
        }
        public string[,] ArgValue = null;

        private void frmBASSubSetupTable_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        public void ViewQueryArgument(string[] sArgu, int i_count)
        {
            int i;
            spdData.Sheets[0].RowCount = i_count;
            for (i = 0; i < i_count; i++)
            {
                spdData.Sheets[0].Cells[i, 0].Value = sArgu[i];
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int i;
            ArgValue = new string[spdData.Sheets[0].RowCount, 2];
            for (i = 0; i < spdData.Sheets[0].RowCount; i++)
            {
                if (MPCF.Trim(spdData.Sheets[0].Cells[i, 1].Value) == "")
                {
                    MPCF.GetMessage(108);
                    spdData.Sheets[0].SetActiveCell(i, 1);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    ArgValue[i, 0] = spdData.Sheets[0].Cells[i, 0].Value.ToString();
                    ArgValue[i, 1] = spdData.Sheets[0].Cells[i, 1].Value.ToString();
                }
            }
        }


    }
}