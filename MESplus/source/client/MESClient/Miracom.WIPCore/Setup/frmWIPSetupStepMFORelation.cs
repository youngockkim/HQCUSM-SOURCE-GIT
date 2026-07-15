//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupStepMFORelation.cs
//   Description : Step - MFO Relation setup
//
//   MES Version : 5.1.1.1
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2010-11-11 : Created by Simon Kim
//
//
//   Copyright(C) 1998-2007 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
namespace Miracom.WIPCore
{
    public partial class frmWIPSetupStepMFORelation : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupStepMFORelation()
        {
            InitializeComponent();
        }

#region " Constant Definition "
#endregion

#region " Variable Definition "

        private bool b_is_work = false;
        
#endregion

#region " Function Definition "
               
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                tvMFO.Focus();
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "ATTACH_STEP":
                    if (lisMFORel.SelectedItems.Count <= 0)
                    {
                        if (lisStepList.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisMFORel.Items[0].Selected = true;
                            lisMFORel.Focus();
                        }
                        return false;
                    }
                    if (lisStepList.SelectedItems.Count <= 0)
                    {
                        if (lisStepList.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisStepList.Items[0].Selected = true;
                            lisStepList.Focus();
                        }
                        return false;
                    }
                    break;

                case "DETACH_STEP":

                    if (lisMFORel.SelectedItems.Count <= 0)
                    {
                        if (lisMFORel.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisMFORel.Items[0].Selected = true;
                            lisMFORel.Focus();
                        }
                        return false;
                    }
                    break;

                case "UPDATE":

                    if (lisMFORel.SelectedItems.Count <= 0)
                    {
                        if (lisMFORel.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisMFORel.Items[0].Selected = true;
                            lisMFORel.Focus();
                        }
                        return false;
                    }
                    if (lisMFORel.SelectedItems[0].Index >= lisMFORel.Items.Count - 1)
                    {
                        return false;
                    }                    
                    break;
                
            }

            return true;
        }

        // Attach_Step_ToOperation()
        //       - Attach Step to Operation 
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string sAttachStep    : Attach Step
        //       - string sBeforeStep    : Step before Attaching Step 
        //
        private bool Attach_Step_ToOperation(string sAttachStep, string sBeforeStep)
        {

            TRSNode in_node = new TRSNode("ATTACH_STEP_TOOPERATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);

            in_node.AddString("STEP", MPCF.Trim(sAttachStep));
            in_node.AddString("ADD_BEFORE_STEP", MPCF.Trim(sBeforeStep));

            in_node.AddChar("REL_LEVEL", tvMFO.SelectLevelChar);
            in_node.AddChar("AUTO_START_FLAG", (chkAutoStartFlag.Checked == true ? 'Y' : ' '));
            in_node.AddChar("AUTO_END_FLAG", (chkAutoEndFlag.Checked == true ? 'Y' : ' '));
            in_node.AddChar("START_REQ_FLAG", (chkStartReqFlag.Checked == true ? 'Y' : ' '));
            in_node.AddChar("END_REQ_FLAG", (chkEndReqFlag.Checked == true ? 'Y' : ' '));
            in_node.AddChar("SERIAL_PROC_FLAG", (chkSerialProcFlag.Checked == true ? 'Y' : ' '));


            if (MPCR.CallService("WIP", "WIP_Attach_Step_ToOperation", in_node, ref out_node) == false)
            {
                return false;
            }
                        
            return true;

        }

        // Detach_Step_FromOperation()
        //       - Detach Step From Operation 
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string sStep    : Detach Step
        //
        private bool Detach_Step_FromOperation(string sStep)
        {

            TRSNode in_node = new TRSNode("DETACH_STEP_FROMOPERATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);

            in_node.AddString("STEP", MPCF.Trim(sStep));

            if (MPCR.CallService("WIP", "WIP_Detach_Step_FromOperation", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;

        }

        // UpdateStepMFORelation()
        //       - Update Step MFO Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char c_step       : Process Step
        //       - string step       : Step 
        //
        private bool UpdateStepMFORelation(char c_step, string step)
        {
            TRSNode in_node = new TRSNode("Update_Step_MFO_Relation_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddString("OPER", tvMFO.Oper);
                in_node.AddString("STEP", step);

                in_node.AddChar("AUTO_START_FLAG", (chkAutoStartFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("AUTO_END_FLAG", (chkAutoEndFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("START_REQ_FLAG", (chkStartReqFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("END_REQ_FLAG", (chkEndReqFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("SERIAL_PROC_FLAG", (chkSerialProcFlag.Checked == true ? 'Y' : ' '));

                in_node.AddString("RESV_FIELD_1", MPCF.Trim(txtResvField1.Text));
                in_node.AddString("RESV_FIELD_2", MPCF.Trim(txtResvField2.Text));
                in_node.AddString("RESV_FIELD_3", MPCF.Trim(txtResvField3.Text));
                in_node.AddString("RESV_FIELD_4", MPCF.Trim(txtResvField4.Text));
                in_node.AddString("RESV_FIELD_5", MPCF.Trim(txtResvField5.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Step_MFO_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
              
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // ViewSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSettingDataList()
        {
            TRSNode in_node = new TRSNode("Sql_In");
            TRSNode out_node = new TRSNode("Sql_Out");
           
            StringBuilder sb;

            MPCF.InitListView(tvMFO.GetListView);
                        
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';            
            in_node.AddInt("NEXT_ROW", 0);

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPSTPMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MWIPSTPMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MWIPSTPMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MWIPSTPMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
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

                MPCR.FillDataView(tvMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0 );

            lblDataCount.Text = tvMFO.GetListView.Items.Count.ToString();

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.tvMFO;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private bool Swap_Step_Sequence(string sAOper, int iAOperSeq, string sBOper, int iBOperSeq)
        {
            TRSNode in_node = new TRSNode("SWAP_OPER_SEQ_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);
            in_node.AddString("STEP_1", MPCF.Trim(sAOper));
            in_node.AddInt("STEP_SEQ_NUM_1", iAOperSeq);
            in_node.AddString("STEP_2", MPCF.Trim(sBOper));
            in_node.AddInt("STEP_SEQ_NUM_2", iBOperSeq);

            if (MPCR.CallService("WIP", "WIP_Swap_Step_Seq", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        private void Swap_List_Item(int iAStepSeq, int iBStepSeq)
        {
            int i;
            string sStep_Temp;

            for (i = 0; i < lisMFORel.Columns.Count; i++)
            {
                sStep_Temp = lisMFORel.Items[iAStepSeq].SubItems[i].Text;

                lisMFORel.Items[iAStepSeq].SubItems[i].Text = lisMFORel.Items[iBStepSeq].SubItems[i].Text;

                lisMFORel.Items[iBStepSeq].SubItems[i].Text = sStep_Temp;
            }
        }



#endregion

        private void frmWIPSetupStepMFORelation_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisStepList);
            MPCF.InitListView(lisMFORel);
            
            pnlGrpMid_Resize(null, null);
            
            lisStepList.Focus();

            if (WIPLIST.ViewStepList(lisStepList, '1') == false) return;
            
            btnCreate.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.RefreshSelectedList();
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.GetNext(txtFind.Text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(tvMFO.GetListView, this.Text, "");
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void pnlGrpMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlGrpTop, pnlGrpMidLeft, pnlGrpMidRight, pnlGrpMidMid, 40);
        }

        // 선택 Level의 말단 노드가 선택되었을 때
        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (WIPLIST.ViewStepList(lisMFORel, '2', tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, tvMFO.SelectLevelChar) == false) return;

            ListViewItem itmX;

            itmX = lisMFORel.Items.Insert(lisMFORel.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_OPER);
            
            lisMFORel.Items[0].Selected = true;
            lisMFORel.Items[0].EnsureVisible();
        }

        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
        }

        private void btnToLeft_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                string sAStep;
                string sBStep;
                ListViewItem itmX;
                int idx;
                int i;

                if (CheckCondition("ATTACH_STEP") == false)
                {
                    return;
                }

                for (i = 0; i <= lisStepList.SelectedItems.Count - 1; i++)
                {
                    sAStep = lisStepList.SelectedItems[i].Text;
                    sBStep = lisMFORel.SelectedItems[0].Text;

                    if (sBStep == "Attach ...")
                    {
                        sBStep = "";
                    }

                    if (Attach_Step_ToOperation(sAStep, sBStep) == true)
                    {
                        if (MPCF.FindListItem(lisMFORel, sAStep, false) == false)
                        {
                            itmX = lisMFORel.Items.Insert(lisMFORel.SelectedItems[0].Index, sAStep, (int)SMALLICON_INDEX.IDX_OPER);
                            itmX.SubItems.Add(chkAutoStartFlag.Checked == true ? "Y" : " ");
                            itmX.SubItems.Add(chkAutoEndFlag.Checked == true ? "Y" : " ");
                            itmX.SubItems.Add(chkStartReqFlag.Checked == true ? "Y" : " ");
                            itmX.SubItems.Add(chkEndReqFlag.Checked == true ? "Y" : " ");
                            itmX.SubItems.Add(chkSerialProcFlag.Checked == true ? "Y" : " ");
                            itmX.SubItems.Add(MPCF.Trim(txtResvField1.Text));
                            itmX.SubItems.Add(MPCF.Trim(txtResvField2.Text));
                            itmX.SubItems.Add(MPCF.Trim(txtResvField3.Text));
                            itmX.SubItems.Add(MPCF.Trim(txtResvField4.Text));
                            itmX.SubItems.Add(MPCF.Trim(txtResvField5.Text));
                            itmX.SubItems.Add(lisStepList.SelectedItems[i].SubItems[1].Text);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                if (lisStepList.SelectedItems.Count == 1)
                {
                    idx = lisStepList.SelectedItems[0].Index;
                    if (idx + 1 < lisStepList.Items.Count)
                    {
                        lisStepList.Items[idx].Selected = false;
                        lisStepList.Items[idx + 1].Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnToRight_Click(System.Object sender, System.EventArgs e)
        {
            int iIdx = 0;
            int i;

            if (CheckCondition("DETACH_STEP") == false)
            {
                return;
            }
            for (i = lisMFORel.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisMFORel.SelectedItems[i].Text != "Attach ...")
                {
                    if (Detach_Step_FromOperation(lisMFORel.SelectedItems[i].Text) == true)
                    {
                        iIdx = lisMFORel.SelectedItems[i].Index;
                        lisMFORel.Items.RemoveAt(iIdx);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (lisMFORel.Items.Count - 1 == iIdx && iIdx > 0)
            {
                iIdx--;
            }
            lisMFORel.Items[iIdx].Selected = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string sAStep, sBStep;
            int iAStepSeq, iBStepSeq;
            ListView.SelectedListViewItemCollection lisItems = lisMFORel.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisMFORel.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 천택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisMFORel.Items.Count - 2)
                return;

            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = 0; i < lisItems.Count; i++)
                {
                    if (lisItems[i].Index == 0)
                        continue;

                    if (lisItems[i].Index > lisMFORel.Items.Count - 2)
                        continue;

                    iAStepSeq = lisItems[i].Index;
                    iBStepSeq = iAStepSeq - 1;

                    if (lisMFORel.Items[iBStepSeq].Selected == true)
                        continue;

                    sAStep = lisMFORel.Items[iAStepSeq].Text;
                    sBStep = lisMFORel.Items[iBStepSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Step_Sequence(sBStep, iBStepSeq + 1, sAStep, iAStepSeq + 1) == true)
                    {
                        Swap_List_Item(iAStepSeq, iBStepSeq);
                        lisMFORel.Items[iAStepSeq].Selected = false;
                        lisMFORel.Items[iBStepSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string sAStep, sBStep;
            int iAStepSeq, iBStepSeq;
            ListView.SelectedListViewItemCollection lisItems = lisMFORel.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisMFORel.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisMFORel.Items.Count - 2)
                return;

            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = lisItems.Count - 1; i >= 0; i--)
                {
                    if (lisItems[i].Index > lisMFORel.Items.Count - 3)
                        continue;

                    iAStepSeq = lisItems[i].Index;
                    iBStepSeq = iAStepSeq + 1;

                    if (lisMFORel.Items[iBStepSeq].Selected == true)
                        continue;

                    sAStep = lisMFORel.Items[iAStepSeq].Text;
                    sBStep = lisMFORel.Items[iBStepSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Step_Sequence(sAStep, iAStepSeq + 1, sBStep, iBStepSeq + 1) == true)
                    {
                        Swap_List_Item(iAStepSeq, iBStepSeq);
                        lisMFORel.Items[iAStepSeq].Selected = false;
                        lisMFORel.Items[iBStepSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }

        }
        
        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            if (WIPLIST.ViewStepList(lisMFORel, '2', tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, tvMFO.SelectLevelChar) == false) return;

            ListViewItem itmX;

            itmX = lisMFORel.Items.Insert(lisMFORel.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_OPER);
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");

            lisMFORel.Items[0].Selected = true;
            lisMFORel.Items[0].EnsureVisible();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            if (CheckCondition("UPDATE") == true)
            {
                string sStep;
                sStep = lisMFORel.SelectedItems[0].Text;

                if (UpdateStepMFORelation(MPGC.MP_STEP_UPDATE, sStep) == true)
                {
                    lisMFORel.SelectedItems[0].SubItems[1].Text = chkAutoStartFlag.Checked == true ? "Y" : " ";
                    lisMFORel.SelectedItems[0].SubItems[2].Text = chkAutoEndFlag.Checked == true ? "Y" : " ";
                    lisMFORel.SelectedItems[0].SubItems[3].Text = chkStartReqFlag.Checked == true ? "Y" : " ";
                    lisMFORel.SelectedItems[0].SubItems[4].Text = chkEndReqFlag.Checked == true ? "Y" : " ";
                    lisMFORel.SelectedItems[0].SubItems[5].Text = chkSerialProcFlag.Checked == true ? "Y" : " ";
                    lisMFORel.SelectedItems[0].SubItems[6].Text = MPCF.Trim(txtResvField1.Text);
                    lisMFORel.SelectedItems[0].SubItems[7].Text = MPCF.Trim(txtResvField2.Text);
                    lisMFORel.SelectedItems[0].SubItems[8].Text = MPCF.Trim(txtResvField3.Text);
                    lisMFORel.SelectedItems[0].SubItems[9].Text = MPCF.Trim(txtResvField4.Text);
                    lisMFORel.SelectedItems[0].SubItems[10].Text = MPCF.Trim(txtResvField5.Text);

                    return;
                }
                
            }
            
        }

        private void lisMFORel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisMFORel.Items.Count > 1)
            {
                if (lisMFORel.SelectedItems.Count > 0 && lisMFORel.SelectedItems[0].SubItems[0].Text != "Attach ...")
                {
                    chkAutoStartFlag.Checked = (lisMFORel.SelectedItems[0].SubItems[1].Text == "Y") ? true : false;
                    chkAutoEndFlag.Checked = (lisMFORel.SelectedItems[0].SubItems[2].Text == "Y") ? true : false;
                    chkStartReqFlag.Checked = (lisMFORel.SelectedItems[0].SubItems[3].Text == "Y") ? true : false;
                    chkEndReqFlag.Checked = (lisMFORel.SelectedItems[0].SubItems[4].Text == "Y") ? true : false;
                    chkSerialProcFlag.Checked = (lisMFORel.SelectedItems[0].SubItems[5].Text == "Y") ? true : false;

                    txtResvField1.Text = lisMFORel.SelectedItems[0].SubItems[6].Text;
                    txtResvField2.Text = lisMFORel.SelectedItems[0].SubItems[7].Text;
                    txtResvField3.Text = lisMFORel.SelectedItems[0].SubItems[8].Text;
                    txtResvField4.Text = lisMFORel.SelectedItems[0].SubItems[9].Text;
                    txtResvField5.Text = lisMFORel.SelectedItems[0].SubItems[10].Text;
                }
            }

        }

   
    }
}

