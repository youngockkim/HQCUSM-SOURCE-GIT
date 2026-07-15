using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public class MPGO : CMNO
    {
        /// <summary>
        ///  Get Global Option
        /// </summary>
        /// <param name="s_option_name">Option Name</param>
        /// <param name="s_value">(Ref)Value</param>
        /// <returns>bool(Success/Fail)</returns>
        public static bool GetGlobalOption(string s_option_name, ref string s_value)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5);
        }

        /// <summary>
        /// Get Global Option
        /// </summary>
        /// <param name="s_option_name">Option Name</param>
        /// <param name="s_value_1">(Ref)value 1</param>
        /// <param name="s_value_2">(Ref)value 2</param>
        /// <param name="s_value_3">(Ref)value 3</param>
        /// <param name="s_value_4">(Ref)value 4</param>
        /// <param name="s_value_5">(Ref)value 5</param>
        /// <returns>bool(Success/Fail)</returns>
        public static bool GetGlobalOption(string s_option_name, ref string s_value_1, ref string s_value_2, ref string s_value_3, ref string s_value_4, ref string s_value_5)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPOF.SetInMsg(in_node);
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
                MPOF.ShowErrorMessage(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get Global Option of System Factory
        /// Add - 2013.06.12. Aiden
        /// 설명 - SYSTEM Factory 에 정의된 Global Option 을 가져오는 기능 추가
        /// </summary>
        /// <param name="s_option_name">Option Name</param>
        /// <param name="s_value">(Ref)value</param>
        /// <returns>bool(Success/Fail)</returns>
        public static bool GetGlobalOption_System(string s_option_name, ref string s_value)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption_System(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5);
        }

        /// <summary>
        /// Get Global Option of System Factory
        /// Add - 2013.06.12. Aiden
        /// 설명 - SYSTEM Factory 에 정의된 Global Option 을 가져오는 기능 추가
        /// </summary>
        /// <param name="s_option_name">Option Name</param>
        /// <param name="s_value_1">(Ref)value1</param>
        /// <param name="s_value_2">(Ref)value2</param>
        /// <param name="s_value_3">(Ref)value3</param>
        /// <param name="s_value_4">(Ref)value4</param>
        /// <param name="s_value_5">(Ref)value5</param>
        /// <returns>bool(Success/Fail)</returns>
        public static bool GetGlobalOption_System(string s_option_name, ref string s_value_1, ref string s_value_2, ref string s_value_3, ref string s_value_4, ref string s_value_5)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("FACTORY", MOGV.gsCentralFactory);
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
                MPOF.ShowErrorMessage(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Make History CMF Change
        /// </summary>
        /// <returns></returns>
        public static bool MakeHistoryCMFChange()
        {
            string sOption = "MP_MakeHistoryCMFChange";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Use Back Date
        /// </summary>
        /// <returns></returns>
        public static bool UseBackDate()
        {
            string sOption = "MP_AllowUseBackDate";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Process Zero Qty Lot
        /// </summary>
        /// <returns></returns>
        public static bool ProcessZeroQtyLot()
        {
            string sOption = "MP_AllowProcessZeroQtyLot";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Auto Cal Due Date
        /// </summary>
        /// <returns></returns>
        public static bool AutoCalDueDate()
        {
            string sOption = "MP_AutoCalDueDate";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Merge Diff oper
        /// </summary>
        /// <returns></returns>
        public static bool MergeDiffOper()
        {
            string sOption = "MP_AllowMergeDiffOper";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Merge Diff Mat ID
        /// </summary>
        /// <returns></returns>
        public static bool MergeDiffMatID()
        {
            string sOption = "MP_AllowMergeDiffMatID";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Split Diff Mat ID
        /// </summary>
        /// <returns></returns>
        public static bool SplitDiffMatID()
        {
            string sOption = "MP_AllowSplitDiffMatID";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref  sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Diff BOM Set Version
        /// </summary>
        /// <returns></returns>
        public static bool DiffBomSetVersion()
        {
            string sOption = "MP_AllowDiffBomSetVersion";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Cycle Time Unit
        /// </summary>
        /// <returns></returns>
        public static string CycleTimeUnit()
        {
            string sOption = "MP_CycleTimeUnit";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return sValue;
        }

        /// <summary>
        /// Allow Empty User Password
        /// </summary>
        /// <returns></returns>
        public static bool AllowEmptyUserPassword()
        {
            string sOption = "MP_AllowEmptyUserPassword";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Allow Variable Group Table
        /// </summary>
        /// <returns></returns>
        public static bool AllowVariableGroupTable()
        {
            string sOption = "MP_AllowVariableGroupTable";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Display Col Head Code View
        /// </summary>
        /// <returns></returns>
        public static bool DisplayColHeadCodeView()
        {
            string sOption = "MP_DisplayColHeadCodeView";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Queue Time Unit
        /// </summary>
        /// <returns></returns>
        public static string QueueTimeUnit()
        {
            string sOption = "MP_QueueTimeUnit";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return sValue;
        }

        /// <summary>
        /// Require Carrier Filter
        /// </summary>
        /// <returns></returns>
        public static bool RequireCarrierFilter()
        {
            string sOption = "MP_RequireCarrierFilter";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Max Sub Lot Slot Count
        /// </summary>
        /// <returns></returns>
        public static int MaxSubLotSlotCount()
        {
            string sOption = "MP_MaxSubLotSlotCount";
            string sValue = string.Empty;
            int i_max_slot_count;

            GetGlobalOption(sOption, ref sValue);

            i_max_slot_count = MPOF.ToInt(sValue);
            if (i_max_slot_count > MPGC.MP_MAX_SLOT_CNT || i_max_slot_count < 1)
            {
                i_max_slot_count = MPGC.MP_MAX_SLOT_CNT;
            }
            return i_max_slot_count;
        }

        /// <summary>
        /// Inherit Alarm To Child
        /// </summary>
        /// <returns></returns>
        public static bool InheritAlarmToChild()
        {
            string sOption = "MP_InheritAlarmToChild";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Use PM Sheet
        /// </summary>
        /// <returns></returns>
        public static bool UsePMSheet()
        {
            string sOption = "MP_UsePMSheet";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Use Sample Count
        /// </summary>
        /// <returns></returns>
        public static int UseSampleCount()
        {
            string sOption = "MP_UseSampleCount";
            string sValue = string.Empty;
            int i_sample_rule_count;

            GetGlobalOption(sOption, ref sValue);

            i_sample_rule_count = MPOF.ToInt(sValue);

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

        /// <summary>
        /// Use Single Target At SPM
        /// </summary>
        /// <returns></returns>
        public static bool UseSingleTargetAtSPM()
        {
            string sOption = "MP_UseSingleTargetAtSPM";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Use Bin Management
        /// </summary>
        /// <returns></returns>
        public static bool UseBinManagement()
        {
            string sOption = "MP_UseBinManagement";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Independent Sub Area
        /// </summary>
        /// <returns></returns>
        public static bool IndependentSubarea()
        {
            string sOption = "MP_IndependentSubarea";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }

        /// <summary>
        /// Require Material Filter
        /// </summary>
        /// <returns></returns>
        public static bool RequireMaterialFilter()
        {
            string sOption = "MP_RequireMaterialFilter";
            string sValue = string.Empty;

            GetGlobalOption(sOption, ref sValue);

            return (sValue == "Y") ? true : false;
        }
    }
}
