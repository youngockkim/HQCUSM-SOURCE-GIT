//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : clsCusGlobalConstant.cs
//   Description : Customizing Global Constant
//
//   MES Version : 5.2.0.0
//
//   Function List
//       -  
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

#region " using Definition "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace SOI.HanwhaQcell.USModule
{
    public class HQGC
    {
        #region " Constant Definition "

        
        /***********************************/
        /* GCM Table Name                  */
        /********************************* */
        public const string GCM_LINE_CODE = "@LINE_CODE";
        public const string GCM_AREA = "AREA";
        public const string GCM_POWER_RANGE = "@POWER_RANGE";
        public const string GCM_PACKING = "@PACKING";
        public const string GCM_ARTICLE = "@ARTICLE";
        public const string GCM_TERMINATE_CODE = "TERMINATE_CODE";
        public const string GCM_DEFECT = "@DEFECT";
        public const string GCM_LOSS_CODE = "LOSS_CODE";
        public const string GCM_TERMINATE_CAUSE = "@TERMINATE_CAUSE";
        public const string GCM_GRADE = "@GRADE";
        public const string GCM_SHIFT = "@SHIFT";
        public const string GCM_EQ_STATUS = "@EQ_STATUS";
        public const string GCM_EQ_TROUBLE = "@EQ_TROUBLE";
        public const string GCM_MD_CW = "@MD_CW";
        public const string GCM_MD_MACHINE = "@MD_MACHINE";
        public const string GCM_MD_POSITION = "@MD_POSITION";
        public const string GCM_MD_MEASURE_TYPE = "@MD_MEASURE_TYPE";
        public const string GCM_MD_BS_TYPE = "@MD_BS_TYPE";
        public const string GCM_MD_EVA_TYPE = "@MD_EVA_TYPE";
        public const string GCM_MD_CORRELATION_FILE = "@MD_CORRELATION_FILE";
        public const string GCM_MD_X_LINK_NO = "@MD_X_LINK_NO";
        public const string GCM_MD_TYPE_EVA_FRONT = "@MD_TYPE_EVA_FRONT";
        public const string GCM_MD_TYPE_GLASS = "@MD_TYPE_GLASS";
        public const string GCM_MD_TYPE_EVA_BACK = "@MD_TYPE_EVA_BACK";
        public const string GCM_MD_TYPE_BACKSHEET = "@MD_TYPE_BACKSHEET";
        public const string GCM_MD_RPT_MEASURE_NO = "@MD_RPT_MEASURE_NO";
        public const string GCM_DEPARTMENT = "@DEPARTMENT";
        public const string GCM_PATROL_CHECK = "@PATROL_CHECK";
        public const string GCM_PLANNING = "@PLANNING";
        public const string GCM_4M_KIND = "@4M_KIND";
        public const string GCM_4M_MACHINE = "@4M_MACHINE";
        public const string GCM_4M_MACHINE_DTL = "@4M_MACHINE_DTL";
        public const string GCM_4M_EQ = "@4M_EQ";
        public const string GCM_4M_OPERATION = "@4M_OPERATION";
        public const string GCM_4M_PERSON = "@4M_PERSON";
        public const string GCM_4M_ISSUE = "@4M_ISSUE";
        public const string GCM_DETECT_POSITION = "@DETECT_POSITION";
        public const string GCM_MACHINE_ISSUE_TYPE = "@MACHINE_ISSUE_TYPE";
        public const string GCM_FRAME_EQUIPMENT = "@FRAME_EQUIPMENT";
        public const string GCM_CELL_POWER_GRADE = "@CELL_POWER_GRADE";
        public const string TABBER_GROUP_QUAD = "@TABBER_GROUP_QUAD";
        public const string WORKER_SHIFT = "@WORKER_SHIFT";
        public const string TABBER_ROOT_CAUSE = "@TABBER_ROOT_CAUSE";
        public const string GCM_LAMI_ATTR = "@LAMI_ATTR";
        public const string GCM_LAMI_CHAMBER = "@LAMI_CHAMBER";
        public const string GCM_LAMI_CHAMBER_ATTR = "@LAMI_CHAMBER_ATTR";
        public const string GCM_REJUDGMENT = "@REJUDGMENT";
        public const string GCM_JOB_STATUS = "@JOB_STATUS";
        public const string GCM_PORT_TYPE = "@PORT_TYPE";
        public const string GCM_PORT_MAT_TYPE = "@PORT_MAT_TYPE";
        public const string GCM_REJUDGEMENT_CODE = "@REJUDGEMENT_CODE";
        public const string GCM_LINE_LOCATION = "@LINE_LOCATION";
        public const string GCM_MATERIAL_TERMINATE = "@MATERIAL_TERMINATE";
        public const string GCM_PAKING_MTRL_LIST = "@PAKING_MTRL_LIST";
        public const string GCM_REPAKING_CAUSE_LIST = "@REPAKING_CAUSE_LIST";
        public const string GCM_TBCLN_CLNG_TYP_LINE = "@TBCLN_CLNG_TYP_LINE";

        /***********************************/
        /* WORK ORDER STATUS CODE          */
        /***********************************/
        public const char WORK_ORDER_STATUS_C = 'C'; // Closed
        public const char WORK_ORDER_STATUS_D = 'D'; // Deleted or Canceled
        public const char WORK_ORDER_STATUS_F = 'F'; // Finished
        public const char WORK_ORDER_STATUS_O = 'O'; // Open
        public const char WORK_ORDER_STATUS_S = 'S'; // Started

        /***********************************/
        /* WORK ORDER STATUS DESCRIPTION   */
        /***********************************/
        public const string WORK_ORDER_STATUS_DESC_C = "Closed";    // Closed
        public const string WORK_ORDER_STATUS_DESC_D = "Deleted";   // Deleted or Canceled
        public const string WORK_ORDER_STATUS_DESC_F = "Finished";  // Finished
        public const string WORK_ORDER_STATUS_DESC_O = "Open";      // Open
        public const string WORK_ORDER_STATUS_DESC_S = "Started";   // Started

        /***********************************/
        /* MATERIAL TYPE                   */
        /***********************************/
        public const char MATERIAL_TYPE_H = 'H'; // Half Production
        public const char MATERIAL_TYPE_M = 'M'; // Material
        public const char MATERIAL_TYPE_P = 'P'; // Production
        public const char MATERIAL_TYPE_S = 'S'; // Spare Part

        /***********************************/
        /* INSPECTION TYPE                 */
        /***********************************/
        public const string INSP_TYPE_FC = "FC";    // FQC

        /***********************************/
        /* LINE                            */
        /***********************************/
        public const string LINE_CVL01 = "CVL01";    // Cleaving Line
        public const string LINE_MDL01 = "MDL01";    // Module Line 1
        public const string LINE_MDL02 = "MDL02";    // Module Line 2
        public const string LINE_MDL03 = "MDL03";    // Module Line 3
        public const string LINE_MDL04 = "MDL04";    // Module Line 4
        public const string LINE_MDL05 = "MDL05";    // Module Line 5
        public const string LINE_MDL06 = "MDL06";    // Module Line 6
        public const string LINE_MDL07 = "MDL07";    // Module Line 7

        /***********************************/
        /* AREA                            */
        /***********************************/
        public const string AREA_CV = "CV";    // Cleaving
        public const string AREA_MA = "MA";    // Module

        /***********************************/
        /* OPERATION                       */
        /***********************************/
        public const string OPER_M0050 = "M0050";   // Opeation Stock & Full Cell Management
        public const string OPER_M1000 = "M1000";   // Cleaving
        public const string OPER_M2000 = "M2000";   // Tabber
        public const string OPER_M2040 = "M2040";   // FrontEnd EL
        public const string OPER_M3110 = "M3110";   // FQC
        public const string OPER_T1000 = "T1000";   // Cell Termination
        public const string OPER_M4030 = "M4030"; //OQC 창고
        public const string OPER_M4230 = "M4230"; //OQC 창고 E23
        /***********************************/
        /* OPERATION DESCRIPTION           */
        /***********************************/
        public const string OPER_T1000_DESC = "Cell Termination";

        /***********************************/
        /* DATE & TINE CONSTANT            */
        /***********************************/
        public const string INIT_HH_MM = "00:00";

        /***********************************/
        /* GENERATE ID                     */
        /***********************************/
        public const string GEN_ID_TRAN_CODE_AUTO = "AUTO";
        public const string GEN_ID_TRAN_CODE_MANUAL = "MANUAL";
        public static string GEN_ID_RULE_ID_AUTO = "MODULE_PALLET_ID";
        public static string GEN_ID_RULE_ID_MANUAL = "MODULE_PALLET_ID_M";

        /***********************************/
        /* Status Check Time               */
        /***********************************/
        public static int MESOI_STATUS_CHECK_TIME = 6; //60초(1분) 마다 Status 전송 
        public static int MESOI_SERVER_CHECK_TIME = 360; //3,600초 (1시간) 마다 Check

        #endregion
    }
}
