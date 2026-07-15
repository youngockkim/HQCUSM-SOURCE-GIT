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
    public partial class frmRTDTranAdjustPriority : Miracom.MESCore.TranForm01
    {
        public frmRTDTranAdjustPriority()
        {
            InitializeComponent();
        }

        private bool CheckCondition()
        {
            if (rbnOper.Checked == false && rbnResource.Checked == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                rbnOper.Checked = true;
                return false;
            }
            if (rbnOper.Checked == true)
            {
                if (MPCF.CheckValue(cdvOper, 1) == false)
                {
                    return false;
                }
            }
            if (rbnResource.Checked == true)
            {
                if (MPCF.CheckValue(cdvResource, 1) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool Adjust_Lot_Priority(char c_step, int i_index, string s_reason)
        {
            TRSNode in_node = new TRSNode("ADJUST_PRIORITY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i_target_1, i_target_2;
            int i_length;
            string s_score;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                if (rbnOper.Checked == true)
                {
                    in_node.AddChar("RES_OPER_FLAG", 'O');
                    in_node.AddString("RES_OPER_ID", MPCF.Trim(cdvOper.Text));
                }
                else 
                {
                    in_node.AddChar("RES_OPER_FLAG", 'R');
                    in_node.AddString("RES_OPER_ID", MPCF.Trim(cdvResource.Text));
                }

                in_node.AddString("LOT_ID", lisDispatcher.SelectedItems[0].SubItems[1].Text);
                
                //in_node.AddString("TARGET_LOT_1", lisDispatcher.Items[i_index].SubItems[1].Text);
                if (c_step == '1')//up
                {                    
                    //in_node.AddString("TARGET_LOT_2", lisDispatcher.Items[i_index -1].SubItems[1].Text);
                    //Modify by J.S. 15 -> 16
                    i_length = lisDispatcher.Items[i_index].SubItems[16].Text.Length;
                    i_target_1 = MPCF.ToInt(lisDispatcher.Items[i_index].SubItems[16].Text.Substring(i_length - 4, 4));
                    s_score = lisDispatcher.Items[i_index].SubItems[16].Text.Substring(0, i_length - 4);
                    if (i_index == 0)
                    {
                        i_target_2 = 9999;
                    }
                    else
                    {
                        i_length = lisDispatcher.Items[i_index - 1].SubItems[16].Text.Length;
                        i_target_2 = MPCF.ToInt(lisDispatcher.Items[i_index - 1].SubItems[16].Text.Substring(i_length - 4, 4));
                        if (i_target_2 < i_target_1)
                        {
                            i_target_2 = 9999;
                        }
                    }
                    i_target_1 = (i_target_1 + i_target_2) / 2;
                    s_score = s_score + i_target_1.ToString("0000");
                    in_node.AddString("PRIORITY_SCORE", s_score);
                }
                else if (c_step == '2')//down
                {
                    //in_node.AddString("TARGET_LOT_2", lisDispatcher.Items[i_index + 1].SubItems[1].Text);
                    i_length = lisDispatcher.Items[i_index].SubItems[16].Text.Length;
                    i_target_1 = MPCF.ToInt(lisDispatcher.Items[i_index].SubItems[16].Text.Substring(i_length - 4, 4));
                    s_score = lisDispatcher.Items[i_index].SubItems[16].Text.Substring(0, i_length - 4);
                    if (i_index == lisDispatcher.Items.Count - 1)
                    {
                        i_target_2 = 0;
                    }
                    else
                    {
                        i_length = lisDispatcher.Items[i_index +1].SubItems[16].Text.Length;
                        i_target_2 = MPCF.ToInt(lisDispatcher.Items[i_index + 1].SubItems[16].Text.Substring(i_length - 4, 4));
                        if (i_target_2 > i_target_1)
                        {
                            i_target_2 = 0;
                        }
                    }
                    i_target_1 = (i_target_1 + i_target_2) / 2;
                    s_score = s_score + i_target_1.ToString("0000");
                    in_node.AddString("PRIORITY_SCORE", s_score);
                }
                else if (c_step == '3')//unselect
                {
                    in_node.AddString("PRIORITY_SCORE", lisDispatcher.SelectedItems[0].SubItems[16].Text);
                }
                
                in_node.AddString("PRI_ADJUST_REASON", MPCF.Trim(s_reason));
                
                if (MPCR.CallService("RTD", "RTD_Adjust_Lot_Priority", in_node, ref out_node) == false)
                {
                    return false;
                }


                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private void rbnResource_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (rbnOper.Checked == true)
            {
                cdvOper.Enabled = true;
                cdvResource.Text = "";
                cdvResource.Enabled = false;
            }
            else if (rbnResource.Checked == true)
            {
                cdvResource.Enabled = true;
                cdvOper.Text = "";
                cdvOper.Enabled = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            char c_res_oper_flag;
            string s_res_oper_id;
            if (CheckCondition() == false)
            {
                return;
            }
            if(rbnOper.Checked == true)
            {
                c_res_oper_flag = 'O';
                s_res_oper_id = cdvOper.Text;
            }
            else
            {
                c_res_oper_flag = 'R';
                s_res_oper_id = cdvResource.Text;
            }
            RTDLIST.ViewPreDispatchedStatus(lisDispatcher, '1', c_res_oper_flag, s_res_oper_id);
            MPCF.FitColumnHeader(lisDispatcher);
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0, "", "", null, "");
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

        private void frmRTDTranAdjustPriority_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            rbnResource.Checked = true;
        }

        private void cdvOper_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (MPCF.Trim(cdvOper.Text) != "")
            {
                rbnOper.Checked = true;
            }
        }

        private void cdvResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (MPCF.Trim(cdvResource.Text) != "")
            {
                rbnResource.Checked = true;
            }
        }

        private void cdvResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvResource.Text) != "")
            {
                rbnResource.Checked = true;
            }
        }

        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvOper.Text) != "")
            {
                rbnOper.Checked = true;
            }
        }

  

        private void lisDispatcher_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lisDispatcher.DoDragDrop(lisDispatcher.SelectedItems[0].Text, DragDropEffects.Move);
        }

        private void lisDispatcher_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisDispatcher_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                char c_step;
                frmRTDTranAdjustComment frm = new frmRTDTranAdjustComment();
                Point targetPoint = lisDispatcher.PointToClient(new Point(e.X, e.Y));
                if (lisDispatcher.GetItemAt(targetPoint.X, targetPoint.Y) == null)
                {
                    return;
                }
                if (lisDispatcher.SelectedItems.Count > 0)
                {
                    if (lisDispatcher.SelectedItems[0].Index > lisDispatcher.GetItemAt(targetPoint.X, targetPoint.Y).Index)
                    {
                        c_step = '1';
                    }
                    else
                    {
                        c_step = '2';
                    }
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Adjust_Lot_Priority(c_step, lisDispatcher.GetItemAt(targetPoint.X, targetPoint.Y).Index, frm.txtComment.Text) == false)
                        {
                            return;
                        }
                        btnView.PerformClick();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                frmRTDTranAdjustComment frm = new frmRTDTranAdjustComment();
                
                if (MPCF.CheckValue(txtCount, 1) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtCount, 2) == false)
                {
                    return;
                }
                if (lisDispatcher.SelectedItems.Count <= 0)
                {
                    return;
                }
                if (lisDispatcher.SelectedItems[0].Index - MPCF.ToInt(txtCount.Text) < 0)
                {
                    return;
                }
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Adjust_Lot_Priority('1', lisDispatcher.SelectedItems[0].Index - MPCF.ToInt(txtCount.Text), frm.txtComment.Text) == false)
                    {
                        return;
                    }
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                frmRTDTranAdjustComment frm = new frmRTDTranAdjustComment();

                if (MPCF.CheckValue(txtCount, 1) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtCount, 2) == false)
                {
                    return;
                }
                if (lisDispatcher.SelectedItems.Count <= 0)
                {
                    return;
                }
                if (lisDispatcher.SelectedItems[0].Index + MPCF.ToInt(txtCount.Text) > lisDispatcher.Items.Count)
                {
                    return;
                }
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Adjust_Lot_Priority('2', lisDispatcher.SelectedItems[0].Index + MPCF.ToInt(txtCount.Text), frm.txtComment.Text) == false)
                    {
                        return;
                    }
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //Unselect
        private void btnProcess_Click(object sender, EventArgs e)
        {
            string s_lot_id;

            frmRTDTranAdjustComment frm = new frmRTDTranAdjustComment();
            if (lisDispatcher.SelectedItems.Count > 0)
            {
                s_lot_id = lisDispatcher.SelectedItems[0].SubItems[1].Text;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Adjust_Lot_Priority('3', lisDispatcher.SelectedItems[0].Index, frm.txtComment.Text) == false)
                    {
                        return;
                    }
                    btnView.PerformClick();

                    MPCF.FindListItem(lisDispatcher, s_lot_id, 1, false);
                }
               
            }
        }

        //Uncapable
        private void btnUncapable_Click(object sender, EventArgs e)
        {
            string s_lot_id;

            frmRTDTranAdjustComment frm = new frmRTDTranAdjustComment();
            if (lisDispatcher.SelectedItems.Count > 0)
            {
                s_lot_id = lisDispatcher.SelectedItems[0].SubItems[1].Text;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Adjust_Lot_Priority('5', lisDispatcher.SelectedItems[0].Index, frm.txtComment.Text) == false)
                    {
                        return;
                    }

                    btnView.PerformClick();
                    MPCF.FindListItem(lisDispatcher, s_lot_id, 1, false);
                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            string s_lot_id;

            if (lisDispatcher.SelectedItems.Count <= 0)
            {
                return;
            }

            s_lot_id = lisDispatcher.SelectedItems[0].SubItems[1].Text;

            //Modify by J.S.  10 -> 11, 14 -> 15 adjust flag만 설정된 경우 다시 dispatch 시킬 수 있게 한다.
            //11 - unselect, 14-capable, 15-adjust
            if (MPCF.Trim(lisDispatcher.SelectedItems[0].SubItems[15].Text) == "")
            {
                return;
            }

            if (Adjust_Lot_Priority('4', 0, "") == false)
            {
                return;
            }

            btnView.PerformClick();
            MPCF.FindListItem(lisDispatcher, s_lot_id, 1, false);
            
        }
    }
}

