using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FarPoint.Win.Spread;
using Infragistics.Win.UltraWinEditors;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;
using Miracom.MESCore;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Miracom.BASCore
{
    public sealed class BASCR
    {
        #region " Const "

        public const char CHKLIST_STEP_LOT = 'L';
        public const char CHKLIST_STEP_RESOURCE = 'R';
        public const char CHKLIST_STEP_MFO = 'M';
        public const char CHKLIST_STEP_ALL = 'A';

        #endregion
        #region "CheckList Popup"

        //by MFO
        public static bool CheckListPopup(Form owner_form, string tran_code, string mat_id, int mat_ver, string flow, string oper, char ba_point)
        {
            return CheckListPopup(owner_form, tran_code, mat_id, mat_ver, flow, oper, "", "", "", ba_point);
        }
        //by LotID
        public static bool CheckListPopup(Form owner_form, string tran_code, string lot_id, char ba_point)
        {
            return CheckListPopup(owner_form, tran_code, "", 0, "", "", lot_id, "", "", ba_point);
        }
        //by LotID, ResID
        public static bool CheckListPopup(Form owner_form, string tran_code, string lot_id, string res_id, char ba_point)
        {
            return CheckListPopup(owner_form, tran_code, "", 0, "", "", lot_id, res_id, "", ba_point);
        }
        public static bool CheckListPopup(Form owner_form, string tran_code, string lot_id, string res_id, string event_id, char ba_point)
        {
            return CheckListPopup(owner_form, tran_code, "", 0, "", "", lot_id, res_id, event_id, ba_point);
        }
        //by RAS
        public static bool CheckListPopupRAS(Form owner_form, string res_id, string event_id, char ba_point)
        {
            if (res_id == null || res_id == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n[Res ID]");
                return false;
            }

            return CheckListPopup(owner_form, "RES_EVENT", "", 0, "", "", "", res_id, event_id, ba_point);
        }
        private static bool CheckListPopup(Form owner_form, string tran_code, string mat_id, int mat_ver, string flow, string oper, string lot_id, string res_id, string event_id, char ba_point)
        {
            TRSNode in_node = new TRSNode("");
            TRSNode out_node = new TRSNode("");
            DialogResult result;
            int iCount = 0;
            List<TRSNode> lis_checklist = new List<TRSNode>();
            List<string> lis_type = new List<string>();

            frmBASTranAnswerfortheChecklist child_form;

            try
            {
                if (owner_form == null)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n[Owner Form]");
                    return false;
                }

                if (tran_code == null || tran_code == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n[Tran Code]");
                    return false;
                }

                if (lot_id != "")
                {
                    iCount = ViewChecklistRelationList(CHKLIST_STEP_LOT, tran_code, ba_point, lot_id, ref lis_checklist);
                }
                if ((mat_id != "" && mat_ver > 0) || (flow != "") || (oper != ""))
                {
                    iCount += ViewChecklistRelationList(CHKLIST_STEP_MFO, tran_code, ba_point, mat_id, mat_ver, flow, oper, ref lis_checklist);
                }
                if (res_id != "")
                {
                    iCount += ViewChecklistRelationList(CHKLIST_STEP_RESOURCE, event_id, ba_point, res_id, ref lis_checklist);
                }

                if (iCount > 0)
                {
                    child_form = new frmBASTranAnswerfortheChecklist();
                    child_form.StartPosition = FormStartPosition.CenterParent;

                    child_form.IsPopup = true;
                    child_form.RelationCount = iCount;
                    child_form.CHKLIST_LIST = lis_checklist;
                    child_form.LotID = lot_id;
                    child_form.ResourceID = res_id;
                    child_form.MatId = mat_id;
                    child_form.MatVer = mat_ver;
                    child_form.Flow = flow;
                    child_form.Oper = oper;
                    child_form.TranCode = tran_code;
                    child_form.EventID = event_id;
                    child_form.BAPoint = ba_point;

                    result = child_form.ShowDialog(owner_form);

                    /*
                     * DialogResult.Yes = Checklist Process Succcess
                     * DialogResult.OK = Checklist Process Skip
                     * DialogResult.No = Checklist Process Fail
                     * */

                    if (result == DialogResult.Yes || result == DialogResult.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Checklist Relation List
        /// </summary>
        /// <param name="c_rel_step">L(Lot) or R(Resource)</param>
        /// <param name="s_item_id">Lot id(c_rel_step is L) or Resource Id(c_rel_step is R)</param>
        /// <param name="s_transaction_id">Transaction Code(c_rel_step is L) or Event ID(c_rel_step_is R)</param>
        /// <returns>Number of relation</returns>
        public static int ViewChecklistRelationList(char c_rel_step, string s_transaction_id, char c_ba_point, string s_item_id, ref List<TRSNode> lis_checklist)
        {
            return ViewChecklistRelationList(c_rel_step, s_transaction_id, c_ba_point, s_item_id, "", 0, "", "", ref lis_checklist);
        }
        public static int ViewChecklistRelationList(char c_rel_step, string s_transaction_id, char c_ba_point, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, ref List<TRSNode> lis_checklist)
        {
            return ViewChecklistRelationList(c_rel_step, s_transaction_id, c_ba_point, "", s_mat_id, i_mat_ver, s_flow, s_oper, ref lis_checklist);
        }
        public static int ViewChecklistRelationList(char c_rel_step, string s_transaction_id, char c_ba_point, string s_item_id, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, ref List<TRSNode> lis_checklist)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_Relation_List_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Relation_List_Out");

            int i_lisCount = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                if (c_rel_step == CHKLIST_STEP_LOT)
                {
                    in_node.AddString("LOT_ID", s_item_id);
                    in_node.AddString("TRAN_CODE", s_transaction_id);
                }
                else if (c_rel_step == CHKLIST_STEP_RESOURCE)
                {
                    in_node.AddString("RES_ID", s_item_id);
                    in_node.AddString("EVENT_ID", s_transaction_id);
                }
                else if (c_rel_step == CHKLIST_STEP_MFO)
                {
                    in_node.AddString("MAT_ID", s_mat_id);
                    in_node.AddInt("MAT_VER", i_mat_ver);
                    in_node.AddString("FLOW", s_flow);
                    in_node.AddString("OPER", s_oper);
                    in_node.AddString("TRAN_CODE", s_transaction_id);
                }
                else
                {
                    in_node.ProcStep = '1';
                }
                in_node.AddChar("BA_POINT", c_ba_point);

                do
                {
                    out_node = new TRSNode("BAS_View_Checklist_Relation_List_Out");
                    if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation_List", in_node, ref out_node) == false)
                    {
                        break;
                    }
                    in_node.SetString("NEXT_CHKLIST_ID", out_node.GetString("NEXT_CHKLIST_ID"));
                    in_node.SetString("SYS_TRAN_TIME", out_node.GetString("SYS_TRAN_TIME"));

                    if (lis_checklist == null)
                    {
                        lis_checklist = new List<TRSNode>();
                    }
                    i_lisCount += out_node.GetList(0).Count;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        lis_checklist.Add(out_node.GetList(0)[i]);
                    }
                }
                while (in_node.GetString("NEXT_CHKLIST_ID") != "");

                return i_lisCount;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }
        }

        #endregion
    }
}



   