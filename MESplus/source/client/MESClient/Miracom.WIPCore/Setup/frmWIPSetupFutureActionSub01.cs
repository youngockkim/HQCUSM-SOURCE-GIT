using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore.Setup
{
    public partial class frmWIPSetupFutureActionSub01 : Form
    {
        public frmWIPSetupFutureActionSub01()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        private const string COND_TYPE_LOT_STATUS = "Lot Status";
        private const string COND_TYPE_LOT_ATTR = "Lot Attribute";
        private const string COND_TYPE_SUBLOT_STATUS = "Sublot Status";
        private const string COND_TYPE_SUBLOT_ATTR = "Sublot Attribute";
        private const string COND_TYPE_CUST_COND = "Custom Condition";

        private const string VALUE_TYPE_FIXED_VALUE = "Fixed Value";
        private const string VALUE_TYPE_GCM_TABLE = "GCM Table";
        private const string VALUE_TYPE_USER_SQL = "User SQL";
        #endregion

        private void MakeRelationCondition()
        {
            int i;
            string s_relation;

            s_relation = "";
            for (i = 0; i < spdConflict.ActiveSheet.RowCount; i++)
            {
                s_relation += MPCF.Trim(spdConflict.ActiveSheet.Cells[i, 1].Value) + " " + ((int)(i + 1)).ToString() + " " + MPCF.Trim(spdConflict.ActiveSheet.Cells[i, 8].Value);
                if (i < spdConflict.ActiveSheet.RowCount - 1)
                {
                    s_relation += " " + MPCF.Trim(spdConflict.ActiveSheet.Cells[i + 1, 0].Value) + " ";
                }
            }

            txtRelation2.Text = s_relation;
        }

        public void setCurrentValue(string s_tran_code, char c_action_type, FarPoint.Win.Spread.FpSpread spdCond, string s_relation)
        {
            int i;
            txtTranCode1.Text = s_tran_code;

            switch (c_action_type)
            {
                case '1':
                    txtActionType1.Text = "Just positive action";
                    break;
                case '2':
                    txtActionType1.Text = "Action with True or False";
                    break;
                case '3':
                    txtActionType1.Text = "By Operation Count with True or False";
                    break;
                case '4':
                    txtActionType1.Text = "To Flow/Oper with True or False";
                    break;
            }

            txtRelation1.Text = s_relation;


            spdCurrent.ActiveSheet.RowCount = spdCond.ActiveSheet.RowCount;

            for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
            {
                spdCurrent.ActiveSheet.Cells[i, 0].Value = spdCond.ActiveSheet.Cells[i, 0].Value;
                spdCurrent.ActiveSheet.Cells[i, 1].Value = spdCond.ActiveSheet.Cells[i, 1].Value;
                spdCurrent.ActiveSheet.Cells[i, 2].Value = spdCond.ActiveSheet.Cells[i, 2].Value;
                spdCurrent.ActiveSheet.Cells[i, 3].Value = spdCond.ActiveSheet.Cells[i, 3].Value;
                spdCurrent.ActiveSheet.Cells[i, 4].Value = spdCond.ActiveSheet.Cells[i, 4].Value;
                spdCurrent.ActiveSheet.Cells[i, 5].Value = spdCond.ActiveSheet.Cells[i, 5].Value;
                spdCurrent.ActiveSheet.Cells[i, 6].Value = spdCond.ActiveSheet.Cells[i, 6].Value;
                spdCurrent.ActiveSheet.Cells[i, 7].Value = spdCond.ActiveSheet.Cells[i, 7].Value;
                spdCurrent.ActiveSheet.Cells[i, 8].Value = spdCond.ActiveSheet.Cells[i, 8].Value;
            }
        }

        public void setConflictValue(TRSNode node)
        {
            List<TRSNode> list_node;
            int i;
            int i1;
            string s_tmp;

            MPCF.ClearList(spdConflict);

            txtTranCode2.Text = node.GetString("TRAN_CODE");

            switch (node.GetChar("ACTION_TYPE"))
            {
                case '1':
                    txtActionType2.Text = "Just positive action";
                    break;
                case '2':
                    txtActionType2.Text = "Action with True or False";
                    break;
                case '3':
                    txtActionType2.Text = "By Operation Count with True or False";
                    break;
                case '4':
                    txtActionType2.Text = "To Flow/Oper with True or False";
                    break;
            }

            txtPointKey2.Text = node.GetString("POINT_KEY");
            txtActionKey2.Text = node.GetString("ACTION_KEY");

            
            list_node = node.GetList("CONDITION_LIST");
            for (i = 0; i < list_node.Count; i++)
            {
                i1 = spdConflict.ActiveSheet.RowCount;
                spdConflict.ActiveSheet.RowCount++;

                spdConflict.ActiveSheet.Cells[i1, 0].Value = list_node[i].GetString("AND_OR");
                spdConflict.ActiveSheet.Cells[i1, 1].Value = list_node[i].GetString("L_BRACKET");

                s_tmp = list_node[i].GetString("COND_TYPE");
                if (s_tmp == "LS")
                    s_tmp = COND_TYPE_LOT_STATUS;
                else if (s_tmp == "LA")
                    s_tmp = COND_TYPE_LOT_ATTR;
                else if (s_tmp == "SS")
                    s_tmp = COND_TYPE_SUBLOT_STATUS;
                else if (s_tmp == "SA")
                    s_tmp = COND_TYPE_SUBLOT_ATTR;
                else if (s_tmp == "CC")
                    s_tmp = COND_TYPE_CUST_COND;

                spdConflict.ActiveSheet.Cells[i1, 2].Value = s_tmp;

                spdConflict.ActiveSheet.Cells[i1, 3].Value = list_node[i].GetString("FIELD_NAME");
                spdConflict.ActiveSheet.Cells[i1, 4].Value = list_node[i].GetString("OPERATOR");

                s_tmp = list_node[i].GetString("VALUE_TYPE");
                if (s_tmp == "FV")
                    s_tmp = VALUE_TYPE_FIXED_VALUE;
                else if (s_tmp == "GT")
                    s_tmp = VALUE_TYPE_GCM_TABLE;
                else if (s_tmp == "US")
                    s_tmp = VALUE_TYPE_USER_SQL;

                spdConflict.ActiveSheet.Cells[i1, 5].Value = s_tmp;

                spdConflict.ActiveSheet.Cells[i1, 6].Value = list_node[i].GetString("VALUE_1");
                spdConflict.ActiveSheet.Cells[i1, 7].Value = list_node[i].GetString("VALUE_2");
                spdConflict.ActiveSheet.Cells[i1, 8].Value = list_node[i].GetString("R_BRACKET");
            }

            MakeRelationCondition();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmWIPSetupFutureActionSub01_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

    }
}