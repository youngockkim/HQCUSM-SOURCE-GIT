
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modGlobalOption.vb
//   Description : Get Global Options Routine Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-17 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public sealed class MPGO
    {
        public static bool GetGlobalOption(string s_option_name, ref string s_value)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5);
        }

        public static bool GetGlobalOption(string s_option_name,
                                            ref string s_value_1, ref string s_value_2, ref string s_value_3, ref string s_value_4, ref string s_value_5)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCR.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                s_value_1 = out_node.GetString("VALUE_1");
                s_value_2 = out_node.GetString("VALUE_2");
                s_value_3 = out_node.GetString("VALUE_3");
                s_value_4 = out_node.GetString("VALUE_4");
                s_value_5 = out_node.GetString("VALUE_5");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /* 2013.06.12. Aiden. SYSTEM Factory ¿¡ Á¤ÀÇµÈ Global Option À» °¡Á®¿À´Â ±â´É Ãß°¡ */
        public static bool GetGlobalOption_System(string s_option_name, ref string s_value)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption_System(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5);
        }

        public static bool GetGlobalOption_System(string s_option_name,
                                            ref string s_value_1, ref string s_value_2, ref string s_value_3, ref string s_value_4, ref string s_value_5)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("FACTORY", MPGV.gsCentralFactory);
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCR.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                s_value_1 = out_node.GetString("VALUE_1");
                s_value_2 = out_node.GetString("VALUE_2");
                s_value_3 = out_node.GetString("VALUE_3");
                s_value_4 = out_node.GetString("VALUE_4");
                s_value_5 = out_node.GetString("VALUE_5");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }


        public static bool MakeHistoryCMFChange()
        {
            string sOption = "MP_MakeHistoryCMFChange";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool UseBackDate()
        {
            string sOption = "MP_AllowUseBackDate";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool ProcessZeroQtyLot()
        {
            string sOption = "MP_AllowProcessZeroQtyLot";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        public static bool AutoCalDueDate()
        {
            string sOption = "MP_AutoCalDueDate";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        public static bool MergeDiffOper()
        {
            string sOption = "MP_AllowMergeDiffOper";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        public static bool MergeDiffMatID()
        {
            string sOption = "MP_AllowMergeDiffMatID";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        public static bool SplitDiffMatID()
        {
            string sOption = "MP_AllowSplitDiffMatID";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref  sValue);

            return (sValue == "Y") ? true : false;
        }
        
        public static bool DiffBomSetVersion()
        {
            string sOption = "MP_AllowDiffBomSetVersion";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        //Cycle Time Setup ???œê°„??Unit ?¤ì •
        public static string CycleTimeUnit()
        {
            string sOption = "MP_CycleTimeUnit";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption,  ref sValue);
            
            return sValue;
            
        }
        
        //Passwordê°€ ?†ëŠ” ?¬ìš©??ID ?ì„±??ê°€?¥í•œì§€ ?¤ì •
        public static bool AllowEmptyUserPassword()
        {
            string sOption = "MP_AllowEmptyUserPassword";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        //Group Table???¬ìš©??ì§€?•í•  ???ˆëŠ”ì§€ ?¤ì •
        public static bool AllowVariableGroupTable()
        {
            string sOption = "MP_AllowVariableGroupTable";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption,ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        //Code View Control?ì„œ ì¹¼ëŸ¼ ?¤ë”ë¥??œì‹œ? ì? ë§ì?ë¥?ê²°ì •
        public static bool DisplayColHeadCodeView()
        {
            string sOption = "MP_DisplayColHeadCodeView";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        
        //Queue Time Setup ???œê°„??Unit ?¤ì •
        public static string QueueTimeUnit()
        {
            string sOption = "MP_QueueTimeUnit";
            string sValue = string.Empty;
            
            GetGlobalOption(sOption, ref sValue);
            
            return sValue;
            
        }

        public static bool RequireCarrierFilter()
        {
            string sOption = "MP_RequireCarrierFilter";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
    
        public static int MaxSubLotSlotCount()
        {
            string sOption = "MP_MaxSubLotSlotCount";
            string sValue = string.Empty;
            int i_max_slot_count;

            GetGlobalOption(sOption, ref sValue);

            i_max_slot_count = MPCF.ToInt(sValue);
            if (i_max_slot_count > MPGC.MP_MAX_SLOT_CNT || i_max_slot_count < 1)
            {
                i_max_slot_count = MPGC.MP_MAX_SLOT_CNT;
            }
            return i_max_slot_count;
        }

        public static bool InheritAlarmToChild()
        {
            string sOption = "MP_InheritAlarmToChild";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool UsePMSheet()
        {
            string sOption = "MP_UsePMSheet";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
            
        public static int UseSampleCount()
        {
            string sOption = "MP_UseSampleCount";
            string sValue = string.Empty;
            int i_sample_rule_count;

            GetGlobalOption(sOption, ref sValue);

            i_sample_rule_count = MPCF.ToInt(sValue);

            if (i_sample_rule_count <= MPGC.MP_SAMPLE_RULE_COUNT_25)
            {
                i_sample_rule_count = MPGC.MP_SAMPLE_RULE_COUNT_25;
            }

            else if (MPGC.MP_SAMPLE_RULE_COUNT_25 < i_sample_rule_count && i_sample_rule_count <= MPGC.MP_SAMPLE_RULE_COUNT_50)
            {
                i_sample_rule_count = MPGC.MP_SAMPLE_RULE_COUNT_50;
            }

            else if (MPGC.MP_SAMPLE_RULE_COUNT_50 < i_sample_rule_count && i_sample_rule_count <= MPGC.MP_SAMPLE_RULE_COUNT_75)
            {
                i_sample_rule_count = MPGC.MP_SAMPLE_RULE_COUNT_75;
            }

            else if (MPGC.MP_SAMPLE_RULE_COUNT_75 < i_sample_rule_count)
            {
                i_sample_rule_count = MPGC.MP_SAMPLE_RULE_MAX_COUNT;
            }

            return i_sample_rule_count;
        }

        public static bool UseSingleTargetAtSPM()
        {
            string sOption = "MP_UseSingleTargetAtSPM";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool UseBinManagement()
        {
            string sOption = "MP_UseBinManagement";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool IndependentSubarea()
        {
            string sOption = "MP_IndependentSubarea";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        public static bool RequireMaterialFilter()
        {
            string sOption = "MP_RequireMaterialFilter";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /* Added By YJJung 150811 for operator in RTD */
        public static bool UseOperatorInRule()
        {
            string sOption = "MP_UseOperatorinRule";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
        /* Added End */

        public static bool ChangePortStateWithLotTran()
        {
            string sOption = "MP_ChangePortStateWithLotTran";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

    
    }
    
}
