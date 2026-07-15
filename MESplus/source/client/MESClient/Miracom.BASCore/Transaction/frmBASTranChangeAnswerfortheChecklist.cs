using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASTranChangeAnswerfortheChecklist.cs
//   Description : Change Answer for the Checklist
//
//   MES Version : 5.3.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-14 : Created by Yeonggon Son
//       - 2013-02-21 : Modified by mhim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.BASCore
{
    public partial class frmBASTranChangeAnswerfortheChecklist : frmCheckListTranMain
    {
        public frmBASTranChangeAnswerfortheChecklist()
        {
            InitializeComponent();
        }

        #region " Function Definition "

        public override bool InitForm()
        {
            return base.InitForm();
        }

        public override bool ViewMain(string check_id)
        {
            try
            {
                ClearData("2");

                if (ViewHistoryList(MPCF.Trim(cdvChecklistID.Text)) == false)
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

        private bool ViewChecklistRelation(string s_chklist_id, string s_rel_key)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_Relation_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Relation_Out");
            CheckListKeyPrompt key;

            try
            {
                if (s_rel_key == "") return true;

                in_node.Init();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHKLIST_ID", s_chklist_id);
                in_node.AddString("REL_KEY", s_rel_key);

                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                CHKLIST.SetChar("REQ_COMPLETE_FLAG", out_node.GetChar("REQ_COMPLETE_FLAG"));
                CHKLIST.SetString("REQ_COMPLETE_USER_ID", out_node.GetString("COMPLETE_USER_ID"));

                /* Override Key Require Flag by Relation */
                for (int i = 0; i < 10; i++)
                {
                    key = KeyPromptList[i];
                    if (out_node.GetChar(string.Format("KEY_{0}_REQ", i + 1)) != ' ')
                    {
                        key.Require = out_node.GetChar(string.Format("KEY_{0}_REQ", i + 1));
                    }
                    KeyPromptList[i] = key;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public override bool ViewHistory(string chklist_id, int check_history_seq)
        {
            if (base.ViewHistory(chklist_id, check_history_seq) == false) return false;
            if (ViewChecklistRelation(chklist_id, CHKLIST.GetString("REL_KEY")) == false) return false;

            if (ViewQueryAnswer(chklist_id, check_history_seq) == false) return false;

            btnProcess.Enabled = true;
            if (CHKLIST.GetChar("COMPLETE_FLAG") == 'Y')
            {
                chkCompleteFlag.Checked = true;
                chkCompleteFlag.Enabled = false;
                if (CHKLIST.GetString("COMPLETE_USER_ID") == MPGV.gsUserID)
                {
                    b_read_only = false;
                }
                else
                {
                    b_read_only = true;
                    btnProcess.Enabled = false;
                }
            }
            else
            {
                chkCompleteFlag.Checked = false;
                if (CHKLIST.GetChar("REQ_COMPLETE_FLAG") == 'Y')
                {
                    if (CHKLIST.GetString("REQ_COMPLETE_USER_ID") == "" || CHKLIST.GetString("REQ_COMPLETE_USER_ID") == MPGV.gsUserID)
                    {
                        chkCompleteFlag.Enabled = true;
                    }
                    else
                    {
                        chkCompleteFlag.Enabled = false;
                    }
                }
                else
                {
                    chkCompleteFlag.Enabled = false;
                }
            }

            txtBaseItemId.Text = CHKLIST.GetString("BASE_OBJ_ID");

            DisplayKeyPrompt();

            return true;
        }

        public override bool ProcessMain()
        {
            int iHistSeq;
            iHistSeq = MPCF.ToInt(lisCheckHistory.SelectedItems[0].SubItems[(int)ColHISTORY.Seq].Text);
            if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'L' && LOT.GetString("LOT_ID") == "")
            {
                LotID = txtBaseItemId.Text;
            }
            else if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'R' && RESOURCE.GetString("RES_ID") == "")
            {
                ResourceID = txtBaseItemId.Text;
            }

            return base.UpdateAnswer(iHistSeq);
        }

        #endregion
    }
}
