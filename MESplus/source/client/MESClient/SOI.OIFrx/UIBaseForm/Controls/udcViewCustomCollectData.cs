using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using Miracom.MsgHandler;

namespace SOI.OIFrx
{
    public partial class udcViewCustomCollectData : UserControl
    {
        public udcViewCustomCollectData()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int CHAR_COL = 0;
        private const int CHAR_DESC_COL = 1;
        private const int SPEC_COL = 2;
        private const int OPT_INPUT_COL = 3;
        private const int VALUE_TYPE_COL = 4;
        private const int VALUE_COUNT_COL = 5;
        private const int DEF_UNIT_OVR_FLAG_COL = 6;
        private const int DEF_VALUE_COL = 7;
        private const int UNIT_TBL_COL = 8;
        private const int VALUE_TBL_COL = 9;
        private const int UNIT_SEQ_COL = 10;
        private const int UNIT_COL = 11;

        private const int VALUE_START_COL = 21;
        private const int DEFAULT_COL_COUNT = 21;

        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;

        private const int MAX_DATA_COUNT = 5000;

        private enum CHAR_COLUMN : int
        {
            CHAR_COL = 0,
            CHAR_DESC_COL,
            SPEC_COL,
            OPT_INPUT_COL,
            VALUE_TYPE_COL,
            VALUE_COUNT_COL,
            DEF_UNIT_OVR_FLAG_COL,
            LOWER_LIMIT,
            STD_VALUE,
            MAX_LIMIT,
            SAMPLE_SIZE,
            UNIT_TBL_COL,
            VALUE_TBL_COL,
            CHAR_SEQ_COL,
            UNIT_COL,
            VALUE_SEQ_NUM,
            EDC_HIST_SEQ,
            UNIT_SEQ_NUM,
            UNIT_COUNT,
            COL_SEQ,
            VALUE_RESULT_COL,
            VALUE_START_COL
        }

        private enum COL_INFO : int
        {
            COL_LOT_GROUP_ID = 0,
            COL_INS_NO,
            COL_INS_SEQ,
            COL_MAT_ID,
            COL_MAT_VER,
            COL_OPER,
            COL_OPER_DESC,
            COL_COL_SET_ID,
            COL_COL_SET_VERSION,
            COL_INS_LEVEL,
            COL_INS_TYPE
        }

        #endregion

        #region " Property Definition "

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Lot_Group_ID
        {
            get
            {
                return s_lot_group_id;
            }
            set
            {
                s_lot_group_id = value;
            }
        }

        #endregion

        #region " Variable Definition "

        private string  s_lot_group_id       = string.Empty;
        private string  s_col_set_id         = string.Empty;
        private int     i_col_set_ver;
        private string  s_oper               = string.Empty;
        private string  s_mat_id             = string.Empty;
        private int     i_mat_ver;
        private string  s_ins_no             = string.Empty;
        private int     i_ins_seq;
        private string  s_ins_level          = string.Empty;
        private string  s_ins_type           = string.Empty;

        private int     iMaxColumnCnt        = 0;
        private int     iModifyColumnCnt     = 0;

        #endregion

        #region " Function Definition "

        public void Init()
        {
            ClearCollectDataControl();
        }

        public void ClearCollectDataControl()
        {
            MPCF.ClearList(spdData, true);
        }

        private string ViewSQL(int i_step, List<string> lstCond)
        {
            StringBuilder sbQry = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sbQry.Length);

            try
            {
                if (i_step == 1)
                {
                    #region [Begin LOT_GROUP_ID에 대한 부가 정보 조회]

                    sb.AppendLine("SELECT A.LOT_GROUP_ID_1                AS LOT_GROUP_ID    ");
                    sb.AppendLine("     , C.INS_NO                        AS INS_NO          ");
                    sb.AppendLine("     , C.INS_SEQ                       AS INS_SEQ         ");
                    sb.AppendLine("     , A.MAT_ID                        AS MAT_ID          ");
                    sb.AppendLine("     , A.MAT_VER                       AS MAT_VER         ");
                    sb.AppendLine("     , E.OPER                          AS OPER            ");
                    sb.AppendLine("     , FN_OPER_DATA(E.FACTORY, E.OPER) AS OPER_DESC       ");
                    sb.AppendLine("     , C.COL_SET_ID                    AS COL_SET_ID      ");
                    sb.AppendLine("     , C.COL_SET_VERSION               AS COL_SET_VERSION ");
                    sb.AppendLine("     , C.INS_CMF_1                     AS INS_LEVEL       ");
                    sb.AppendLine("     , C.INS_CMF_2                     AS INS_TYPE        ");
                    sb.AppendLine("FROM                                                      ");
                    sb.AppendLine("(                                                         ");
                    sb.AppendLine("        SELECT FACTORY, LOT_GROUP_ID_1, MAT_ID, MAT_VER   ");
                    sb.AppendLine("    FROM MWIPLOTSTS                                       ");
                    sb.AppendLine("    WHERE 1=1                                             ");
                    sb.AppendLine("    AND FACTORY         = :FACTORY                        ");
                    sb.AppendLine("    AND LOT_GROUP_ID_1  = :LOT_ID                         ");
                    sb.AppendLine("    GROUP BY FACTORY, LOT_GROUP_ID_1, MAT_ID, MAT_VER     ");
                    sb.AppendLine(")              A,                                         ");
                    sb.AppendLine("    MINVDLVLOT B,                                         ");
                    sb.AppendLine("    MQCMINSREQ C,                                         ");
                    sb.AppendLine("    MWIPMATDEF D,                                         ");
                    sb.AppendLine("(                                                         ");
                    sb.AppendLine("    SELECT FACTORY, OPER, OPER_GRP_1                      ");
                    sb.AppendLine("    FROM MWIPOPRDEF                                       ");
                    sb.AppendLine("    WHERE 1=1                                             ");
                    sb.AppendLine("    AND FACTORY     = :FACTORY                            ");
                    sb.AppendLine("    AND OPER_CMF_11 = 'Y'                                 ");
                    sb.AppendLine(")              E                                          ");
                    sb.AppendLine("WHERE 1=1                                                 ");
                    sb.AppendLine("AND A.FACTORY            = B.FACTORY                      ");
                    sb.AppendLine("AND A.LOT_GROUP_ID_1     = B.LOT_GROUP_ID                 ");
                    sb.AppendLine("AND B.FACTORY            = C.FACTORY                      ");
                    sb.AppendLine("AND B.ORDER_ID           = C.ORDER_ID                     ");
                    sb.AppendLine("AND B.ORD_SEQ            = C.ORD_SEQ                      ");
                    sb.AppendLine("AND A.FACTORY            = D.FACTORY                      ");
                    sb.AppendLine("AND A.MAT_ID             = D.MAT_ID                       ");
                    sb.AppendLine("AND A.MAT_VER            = D.MAT_VER                      ");
                    sb.AppendLine("AND D.FACTORY            = E.FACTORY                      ");
                    sb.AppendLine("AND D.MAT_GRP_1          = E.OPER_GRP_1                   ");

                    #endregion
                }
                else if (i_step == 2)
                {
                    #region [Begin 칼럼 최대값 조회]

                    sb.AppendLine("SELECT NVL(MAX(SUM(VALUE_COUNT)), 0) AS MAX_COLUMN_COUNT ");
                    sb.AppendLine("FROM MEDCINSDAT                                          ");
                    sb.AppendLine("WHERE 1=1                                                ");
                    sb.AppendLine("AND FACTORY             = :FACTORY                       ");
                    sb.AppendLine("AND INS_NO              = :INS_NO                        ");
                    sb.AppendLine("GROUP BY CHAR_ID                                         ");

                    #endregion
                }

                string[] straTemp = null;
                if (lstCond != null)
                {
                    foreach (string strKey in lstCond)
                    {
                        straTemp = strKey.Split('?');
                        sb = sb.Replace(straTemp[0], straTemp[1]);
                    }
                }

                return sb.ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
            finally
            {
                StringBuilder sbSqlLog = new StringBuilder();
                sbSqlLog.AppendLine("/*******************쿼리 시작******************************/");
                sbSqlLog.AppendLine(sb.ToString());
                sbSqlLog.AppendLine("/*******************쿼리 끝******************************/");
                System.Diagnostics.Trace.WriteLine(sbSqlLog.ToString());
            }
        }

        private bool ViewCollectionSet()
        {
            TRSNode in_node = new TRSNode("VIEW_INS_INFO_IN");
            TRSNode out_node = new TRSNode("VIEW_INS_INFO_OUT");
            StringBuilder sbQry = new StringBuilder();
            List<string> lstInfo = new List<string>();
            DataTable _dt = new DataTable();

            try
            {
                lstInfo.Clear();
                _dt.Clear();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                lstInfo.Add(":FACTORY?" + string.Concat("'", MPGV.gsFactory, "'"));
                lstInfo.Add(":LOT_ID?" + string.Concat("'", MPCF.Trim(this.s_lot_group_id), "'"));

                in_node.AddString("SQL", sbQry.AppendLine(ViewSQL(1, lstInfo).ToString()).ToString());

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCR.ConvertToDataTable(out_node) == null)
                {
                    MPCF.ShowMsgBox("스펙 정보가 존재하지 않습니다.");
                    return false;
                }

                _dt = MPCR.ConvertToDataTable(out_node);

                s_ins_no        = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_INS_NO]);
                i_ins_seq       = MPCF.ToInt(_dt.Rows[0][(int)COL_INFO.COL_INS_SEQ]);
                s_mat_id        = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_MAT_ID]);
                i_mat_ver       = MPCF.ToInt(_dt.Rows[0][(int)COL_INFO.COL_MAT_VER]);
                s_ins_level     = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_INS_LEVEL]);
                s_ins_type      = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_INS_TYPE]);
                s_oper          = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_OPER]);
                s_col_set_id    = MPCF.Trim(_dt.Rows[0][(int)COL_INFO.COL_COL_SET_ID]);
                i_col_set_ver   = MPCF.ToInt(_dt.Rows[0][(int)COL_INFO.COL_COL_SET_VERSION]);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private int ViewMaxColumnCount()
        {
            TRSNode in_node = new TRSNode("VIEW_INS_INFO_IN");
            TRSNode out_node = new TRSNode("VIEW_INS_INFO_OUT");
            StringBuilder sbQry = new StringBuilder();
            List<string> lstInfo = new List<string>();
            DataTable _dt = new DataTable();

            try
            {
                lstInfo.Clear();
                _dt.Clear();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                lstInfo.Add(":FACTORY?" + string.Concat("'", MPGV.gsFactory, "'"));
                lstInfo.Add(":INS_NO?" + string.Concat("'", MPCF.Trim(this.s_ins_no), "'"));

                in_node.AddString("SQL", sbQry.AppendLine(ViewSQL(2, lstInfo).ToString()).ToString());

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return 0;
                }

                if (MPCR.ConvertToDataTable(out_node) == null)
                {
                    MPCF.ShowMsgBox("저장된 검사 결과 값이 존재하지 않습니다.");
                    return 0;
                }

                _dt = MPCR.ConvertToDataTable(out_node);
                return MPCF.ToInt(_dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }
        }

        #endregion

        public bool ViewLotData()
        {
            return ViewLotData(spdData);
        }

        private bool ViewLotData(Control control)
        {
            int i;
            int iValueCnt = 0;
            int i_index;

            string sUnitTbl;

            string s_value_name;

            char cUnitType;
            char cDerivedParamFlag;
            char cDefUnitFlag;
            char cDefUnitOvrFlag;

            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

            System.Collections.ArrayList a_values = new System.Collections.ArrayList();
            FarPoint.Win.Spread.SheetView with_1;

            try
            {
                if (control is FpSpread)
                {
                    ((FpSpread)control).SuspendLayout();

                    ((FpSpread)control).ActiveSheet.RowCount = 0;
                    ((FpSpread)control).ActiveSheet.ColumnCount = DEFAULT_COL_COUNT;

                    ((FpSpread)control).ResumeLayout();
                }

                if (ViewCollectionSet() == false)
                {
                    return false;
                }

                MPCF.ClearList(spdData, true);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("INS_NO", MPCF.Trim(s_ins_no));
                in_node.SetInt("INS_SEQ", i_ins_seq);
                in_node.SetChar("INCLUDE_DEL_HIST", 'Y');
                in_node.SetString("NEXT_COL_SET_ID", " ");
                in_node.SetInt("NEXT_CHAR_SEQ_NUM", 0);
                in_node.SetInt("NEXT_UNIT_SEQ_NUM", 0);
                in_node.SetInt("NEXT_VALUE_SEQ_NUM", 0);
                in_node.SetInt("NEXT_COL_SEQ", 0);

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Ins_Data", in_node, ref out_node, true) == false)
                    {
                        /*검사 결과가 없을 경우 아무것도 하지않음*/
                        if (out_node.MsgCode == "EDC-0050")
                        {
                            return false;
                        }
                        MPCR.ShowSuccessMsg(out_node);
                        return false;
                    }


                    // Get Max Value Count
                    iMaxColumnCnt = ViewMaxColumnCount();
                    iModifyColumnCnt = iMaxColumnCnt;

                    //iMaxColumnCnt가 0이면 return
                    if (iMaxColumnCnt == 0)
                    {
                        MPCF.ShowMsgBox("저장된 검사 결과 값이 존재하지 않습니다.");
                        return false;
                    }

                    if (control is FpSpread)
                    {
                        with_1 = ((FpSpread)control).ActiveSheet;
                        with_1.ColumnCount = DEFAULT_COL_COUNT + iMaxColumnCnt;
                        with_1.RowCount = out_node.GetList(0).Count;
                        if (iMaxColumnCnt > 0)
                        {
                            with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).ColumnSpan = iMaxColumnCnt;
                            with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).Text = "Value";
                        }

                        with_1.Columns[MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE)].Locked = false;

                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            /* 기본값 세팅 */
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL), out_node.GetList(0)[i].GetString("CHAR_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_DESC_COL), out_node.GetList(0)[i].GetString("CHAR_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SPEC_COL), out_node.GetList(0)[i].GetString("SPEC_INFO"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.OPT_INPUT_COL), out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL), out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_COUNT_COL), out_node.GetList(0)[i].GetInt("VALUE_COUNT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.DEF_UNIT_OVR_FLAG_COL), out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.LOWER_LIMIT), out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.STD_VALUE), out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.MAX_LIMIT), out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_TBL_COL), out_node.GetList(0)[i].GetString("UNIT_TBL"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TBL_COL), out_node.GetList(0)[i].GetString("VALUE_TBL"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE), out_node.GetList(0)[i].GetInt("VALUE_COUNT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL), out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COUNT), out_node.GetList(0)[i].GetInt("UNIT_COUNT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_SEQ_NUM), 1);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.COL_SEQ), out_node.GetList(0)[i].GetInt("COL_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM), 1);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.EDC_HIST_SEQ), out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), out_node.GetList(0)[i].GetString("UNIT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL), "OK");

                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            cUnitType = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                            cDerivedParamFlag = out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG");
                            cDefUnitFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG");
                            cDefUnitOvrFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG");
                            sUnitTbl = out_node.GetList(0)[i].GetString("UNIT_TBL");


                            i_index = 0;
                            /* Value Count  */
                            for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iMaxColumnCnt); nCol++)
                            {
                                s_value_name = "VALUE_" + (i_index + 1).ToString();

                                with_1.ColumnHeader.Cells.Get(1, nCol).Value = (i_index + 1);
                                /*Cell Lock*/
                                if (nCol >= (DEFAULT_COL_COUNT + iValueCnt))
                                {
                                    with_1.Cells[i, nCol].Locked = true;
                                    with_1.Cells[i, nCol].BackColor = System.Drawing.Color.WhiteSmoke;
                                }
                                /*기타 셀서식지정*/
                                else
                                {
                                    if (cUnitType == 'A')
                                    {
                                        if (MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name)) != "")
                                        {
                                            with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name));
                                        }

                                        with_1.Cells[i, nCol].Locked = true;

                                        if (MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name)).Equals(MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET_VALUE"))) == false)
                                        {
                                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL), "NG");
                                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL)].BackColor = Color.Red;
                                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL)].ForeColor = Color.PaleTurquoise;
                                        }
                                    }
                                    else if (cUnitType == 'N')
                                    {
                                        if (MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name)) != "")
                                        {
                                            spdData.ActiveSheet.Cells[i, nCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name));
                                        }

                                        with_1.Cells[i, nCol].Locked = true;
                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[i, nCol]);

                                        if (string.IsNullOrEmpty(MPCF.Trim(with_1.Cells[i, (int)CHAR_COLUMN.LOWER_LIMIT].Value)) == true &&
                                            string.IsNullOrEmpty(MPCF.Trim(with_1.Cells[i, (int)CHAR_COLUMN.MAX_LIMIT].Value)) == true)
                                        {

                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name))) == true)
                                            {
                                            }
                                            else
                                            {
                                                if (MPCF.ToDbl(out_node.GetList(0)[i].GetString(s_value_name)) < MPCF.ToDbl(with_1.Cells[i, (int)CHAR_COLUMN.LOWER_LIMIT].Value) ||
                                                    MPCF.ToDbl(out_node.GetList(0)[i].GetString(s_value_name)) > MPCF.ToDbl(with_1.Cells[i, (int)CHAR_COLUMN.MAX_LIMIT].Value))
                                                {
                                                    with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL), "NG");
                                                    with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL)].BackColor = Color.Red;
                                                    with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL)].ForeColor = Color.PaleTurquoise;
                                                }
                                            }
                                        }
                                    }

                                    if (cDerivedParamFlag == 'Y')
                                    {
                                        with_1.Cells[i, nCol].Locked = true;
                                        with_1.Cells[i, nCol].BackColor = System.Drawing.Color.Cyan;
                                        with_1.Rows[i].Tag = "AUTO";

                                    }

                                    // value 매핑

                                }
                                i_index = i_index + 1;

                                CheckByCell(with_1, i, nCol);
                            }

                        } // End of For-loop                        

                    }  // End of Spread
                } while (MPCF.Trim(in_node.GetString("NEXT_COL_SET_ID")) != "" ||
                                    in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
                                    in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                                    in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0 ||
                                    in_node.GetInt("NEXT_COL_SEQ") > 0);


                MPCF.ConvertMessage(this.Controls);
                MPCF.FitColumnHeader(spdData);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void CheckByCell(FarPoint.Win.Spread.SheetView spdView, int nRow, int nCol)
        {
            string sValueType = string.Empty;

            string sLowerLimit = string.Empty;
            string sUpperLimit = string.Empty;
            double dLowerLimit = 0D;
            double dUpperLimit = 0D;
            double dValue = 0D;

            try
            {
                if (spdView.Cells[nRow, nCol].Locked == true)
                    return;

                //넘버형 데이터 필드만 적용
                if (nCol < DEFAULT_COL_COUNT)
                    return;

                if (spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Text == "N")
                {
                    dValue = MPCF.ToDbl(spdView.Cells[nRow, nCol].Text);

                    sLowerLimit = spdView.Cells[nRow, (int)CHAR_COLUMN.LOWER_LIMIT].Text;
                    sUpperLimit = spdView.Cells[nRow, (int)CHAR_COLUMN.MAX_LIMIT].Text;

                    dLowerLimit = MPCF.ToDbl(sLowerLimit);
                    dUpperLimit = MPCF.ToDbl(sUpperLimit);

                    if ((MPCF.Trim(sLowerLimit) != string.Empty && dValue < dLowerLimit) ||
                         (MPCF.Trim(sUpperLimit) != string.Empty && dValue > dUpperLimit))
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.Red;
                        spdView.Cells[nRow, nCol].ForeColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.White;
                        spdView.Cells[nRow, nCol].ForeColor = Color.Black;
                    }

                    //공백일 경우 skip
                    if (MPCF.Trim(spdView.Cells[nRow, nCol].Text) == string.Empty)
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.White;
                        spdView.Cells[nRow, nCol].ForeColor = Color.Black;
                    }
                }
                else if (spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Text == "A")
                {
                    if (MPCF.Trim(spdView.Cells[nRow, (int)CHAR_COLUMN.STD_VALUE].Text) != string.Empty &&
                        MPCF.Trim(spdView.Cells[nRow, (int)CHAR_COLUMN.STD_VALUE].Text).Equals(MPCF.Trim(spdView.Cells[nRow, nCol].Text)) == true)
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.White;
                        spdView.Cells[nRow, nCol].ForeColor = Color.Black;
                    }
                    else
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.Red;
                        spdView.Cells[nRow, nCol].ForeColor = Color.PaleTurquoise;
                    }

                    //공백일 경우 skip
                    if (MPCF.Trim(spdView.Cells[nRow, nCol].Text) == string.Empty)
                    {
                        spdView.Cells[nRow, nCol].BackColor = Color.White;
                        spdView.Cells[nRow, nCol].ForeColor = Color.Black;
                    }
                }

                bool b_ng_flag = false;
                for (int i = DEFAULT_COL_COUNT; i < DEFAULT_COL_COUNT + iModifyColumnCnt; i++)
                {
                    if (spdView.Cells[nRow, i].BackColor == Color.Red)
                    {
                        b_ng_flag = true;
                    }
                }

                if (b_ng_flag == true)
                {
                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].BackColor = Color.Red;
                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].ForeColor = Color.PaleTurquoise;

                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].Value = "NG";
                }
                else
                {
                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].BackColor = Color.White;
                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].ForeColor = Color.Black;

                    spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_RESULT_COL].Value = "OK";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
        }
    }
}
