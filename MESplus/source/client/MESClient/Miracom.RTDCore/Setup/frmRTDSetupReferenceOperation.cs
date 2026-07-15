using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;
namespace Miracom.RTDCore
{
    public partial class frmRTDSetupReferenceOperation : Miracom.MESCore.SetupForm02
    {
        public frmRTDSetupReferenceOperation()
        {
            InitializeComponent();
        }


        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            if (udcMFO.SelectedNode == null)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                udcMFO.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvRefOper, 1) == false)
            {
                return false;
            }
            /* Added By YJJung 161024 Validation ´©¶ô */
            if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(184));
                udcMFO.Focus();
                return false;
            }
            /* Added End */

            return true;

        }
        //
        // ViewMFOSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            StringBuilder sb;

            try
            {
                MPCF.InitListView(udcMFO.GetListView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                sb = new StringBuilder();

                switch (udcMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MRTDREFOPR ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND RELATION_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                        sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                        sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MRTDREFOPR ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND RELATION_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                        sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                        sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        sb.Append("SELECT FLOW, OPER FROM MRTDREFOPR ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND RELATION_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                        sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY FLOW, OPER ");
                        sb.Append("ORDER BY FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        sb.Append("SELECT OPER FROM MRTDREFOPR ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND RELATION_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                        sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY OPER ");
                        sb.Append("ORDER BY OPER ASC");
                        break;

                }

                in_node.AddString("SQL", sb.ToString());

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetInt("NEXT_ROW") > 0);
                
            }
            
            
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        //
        // UpdateDispatchRelation()
        //       - Create/Update/Delete Dispatch Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool UpdateReferenceOperation(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_REF_OPER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddChar("RELATION_LEVEL", udcMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", udcMFO.MatID);
                in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                in_node.AddString("FLOW", udcMFO.Flow);
                in_node.AddString("OPER", udcMFO.Oper);

                in_node.AddString("REFERENCE_OPER", cdvRefOper.Text);

                if (MPCR.CallService("RTD", "RTD_Update_Reference_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        //
        // ViewReferenceOperation
        //       - View Dispatch Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewReferenceOperation(char c_relation_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            TRSNode in_node = new TRSNode("VIEW_REF_OPER_IN");
            TRSNode out_node = new TRSNode("VIEW_REF_OPER_OUT");

            MPCF.FieldClear(grpOper);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddChar("RELATION_LEVEL", c_relation_level);
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);

            if (MPCR.CallService("RTD", "RTD_View_Reference_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("REFERENCE_OPER") != "")
            {
                cdvRefOper.Text = out_node.GetString("REFERENCE_OPER");

            }
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));

            return true;

        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.RefreshSelectedList();
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            MPCF.FieldClear(grpOper);
            ViewReferenceOperation(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpOper);
            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcMFO_LevelItemSelect(null, null);
        }

        private void cdvRefOper_ButtonPress(object sender, EventArgs e)
        {
            cdvRefOper.Init();
            MPCF.InitListView(cdvRefOper.GetListView);
            cdvRefOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvRefOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvRefOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvRefOper.GetListView, '1', "", 0, "", "", null, "");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (UpdateReferenceOperation(MPGC.MP_STEP_DELETE) == true)
            {
                if (udcMFO.OnlySetDataList == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (UpdateReferenceOperation(MPGC.MP_STEP_UPDATE) == true)
            {
                if (udcMFO.OnlySetDataList == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (UpdateReferenceOperation(MPGC.MP_STEP_CREATE) == true)
            {
                if (udcMFO.OnlySetDataList == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void udcMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpOper);
        }
    }
}

