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
using System.IO;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using Miracom.MsgHandler;


namespace SOI.OIFrx
{
    public partial class udcCustomPatrolCollectData : UserControl
    {
        public udcCustomPatrolCollectData()
        {
            InitializeComponent();
            Init();
        }

        #region " Constant Definition "

        private const int LINE = 0;
        private const int WORK_GROUP_ID = 1;
        private const int WORK_GROUP_DESC = 2;
        private const int RES_ID = 3;
        private const int RES_DESC = 4;
        private const int MAKER = 5;
        private const int SIZE_FORMAT = 6;
        private const int PLAN_DATE = 7;
        private const int CHAR_MTOD = 8;
        private const int CHAR_COL = 9;
        private const int CHAR_DESC_COL = 10;
        private const int ATTACH_FILE_DIR = 11;
        private const int SPEC_COL = 12;
        private const int OPT_INPUT_COL = 13;
        private const int VALUE_TYPE_COL = 14;
        private const int VALUE_COUNT_COL = 15;
        private const int DEF_UNIT_OVR_FLAG_COL = 16;
        private const int DEF_VALUE_COL = 17;
        private const int UNIT_TBL_COL = 18;
        private const int VALUE_TBL_COL = 19;
        private const int UNIT_SEQ_COL = 20;
        private const int UNIT_COL = 21;

        private const int VALUE_START_COL = 31;
        private const int DEFAULT_COL_COUNT = 31;
        private const int CUSTOM_ADD_COL_COUNT = 5;

        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;

        private const int MAX_DATA_COUNT = 5000;

        private enum CHAR_COLUMN : int
        {
            LINE = 0,
            WORK_GROUP_ID,
            WORK_GROUP_DESC,
            RES_ID,
            RES_DESC,
            MAKER,
            SIZE_FORMAT,
            PLAN_DATE,
            CHAR_MTOD,
            CHAR_COL,
            CHAR_DESC_COL,
            ATTACH_FILE_DIR,
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
            COL_MAT_ID = 0,
            COL_MAT_VER,
            COL_OPER,
            COL_COL_SET_ID,
            COl_COL_SET_DESC,
            COL_COL_SET_VERSION,
            COL_DEFAULT_FLAG,
            COL_COL_CMF_1
        }

        #endregion

        #region " Property Definition "

        public string InsNo
        {
            get
            {
                return ms_ins_no;
            }
            set
            {
                ms_ins_no = value;
            }
        }

        public string MatID
        {
            get
            {
                return ms_mat_id;
            }
            set
            {
                ms_mat_id = value;
            }
        }

        public string DeliveryNo
        {
            get
            {
                return ms_delivery_no;
            }
            set
            {
                ms_delivery_no = value;
            }
        }

        public string InspectionOper
        {
            get
            {
                return ms_insp_oper;
            }
            set
            {
                ms_insp_oper = value;
            }
        }

        public string VendorID
        {
            get
            {
                return ms_vendor_id;
            }
            set
            {
                ms_vendor_id = value;
            }
        }

        public string ColSetID
        {
            get
            {
                return ms_col_set_id;
            }
            set
            {
                ms_col_set_id = value;
            }
        }

        public string ColSetDesc
        {
            get
            {
                return ms_col_set_desc;
            }
            set
            {
                ms_col_set_desc = value;
            }
        }

        public string ColSetVersion
        {
            get
            {
                return ms_col_set_ver;
            }
            set
            {
                ms_col_set_ver = value;
            }
        }

        // SPREAD에 해당 컬럼을 추가할 것인지에 대한 여부
        public string CommentViewFlag
        {
            get
            {
                return ms_comment_flag;
            }
            set
            {
                ms_comment_flag = value;
            }
        }

        public string ImageViewFlag
        {
            get
            {
                return ms_image_flag;
            }
            set
            {
                ms_image_flag = value;
            }
        }

        public string WorkGroupViewFlag
        {
            get
            {
                return ms_work_group_flag;
            }
            set
            {
                ms_work_group_flag = value;
            }
        }

        public string ResourceViewFlag
        {
            get
            {
                return ms_res_flag;
            }
            set
            {
                ms_res_flag = value;
            }
        }

        public string AbsValueViewFlag
        {
            get
            {
                return ms_abs_flag;
            }
            set
            {
                ms_abs_flag = value;
            }
        }

        public int ColCount
        {
            get
            {
                return iSpdColCount;
            }
            set
            {
                iSpdColCount = value;
            }
        }

        public string Line
        {
            get
            {
                return ms_line;
            }
            set
            {
                ms_line = value;
            }
        }

        public string LineDesc
        {
            get
            {
                return ms_line_desc;
            }
            set
            {
                ms_line_desc = value;
            }
        }

        public string InspType
        {
            get
            {
                return ms_insp_type;
            }
            set
            {
                ms_insp_type = value;
            }
        }

        public string ShopCode
        {
            get
            {
                return ms_shop_code;
            }
            set
            {
                ms_shop_code = value;
            }
        }

        public string AttachFileFlag
        {
            get
            {
                return ms_attach_file_flag;
            }
            set
            {
                ms_attach_file_flag = value;
            }
        }

        #endregion

        #region " Variable Definition "

        private string ms_ins_no;
        private string ms_mat_id;
        private string ms_delivery_no;
        private string ms_vendor_id;
        private string ms_insp_oper;
        private string ms_col_set_id;
        private string ms_col_set_desc;
        private string ms_col_set_ver;
        private string ms_work_group_flag;
        private string ms_res_flag;
        private string ms_abs_flag;
        private string ms_comment_flag;
        private string ms_image_flag;
        private string ms_line;
        private string ms_line_desc;
        private string ms_shop_code;
        private string ms_insp_type;
        private string ms_attach_file_flag;

        private int iMaxColumnCnt = 0;
        private int iModifyColumnCnt = 0;
        private int iSpdColCount = 0;

        #endregion

        #region " Function Definition "

        public void Init()
        {
            ClearCollectDataControl();

            ms_ins_no = "";
            ms_delivery_no = "";
            ms_mat_id = "";
            ms_vendor_id = "";
            ms_insp_oper = "";
            ms_col_set_id = "";
            ms_col_set_desc = "";
            ms_col_set_ver = "";
        }

        /// <summary>
        /// 스프레드 초기화
        /// </summary>
        public void ClearCollectDataControl()
        {
            MPCF.ClearList(spdData, true);
        }

        /// <summary>
        /// 검사 정보 값의 개수 가져오기
        /// </summary>
        /// <returns></returns>
        private int ViewMaxColumnCount()
        {
            try
            {
                DataTable _dt = MPOF.MGetData("", new string[] { });

                if (_dt == null || _dt.Rows.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(370));
                }

                return MPCF.ToInt(_dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 벨리데이션 
        /// </summary>
        /// <returns></returns>
        public bool CheckCondition()
        {
            int i = 0;
            int j = 0;

            try
            {
                if (spdData.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    spdData.Select();
                    return false;
                }
                else if (spdData.ActiveSheet.RowCount > MAX_DATA_COUNT)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(134));
                    spdData.Select();
                    return false;
                }

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, CHAR_COL)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        spdData.ActiveSheet.SetActiveCell(i, CHAR_COL);
                        spdData.Select();
                        return false;
                    }

                    // unit_id check
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, OPT_INPUT_COL)) != "Y")
                    {
                        for (j = UNIT_COL; j <= UNIT_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)); j++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.GetTag(i, j)) != "NULL")
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) == "" && spdData.ActiveSheet.Cells[i, j].Locked == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, j);
                                    spdData.Select();
                                    return false;
                                }
                            }
                        }
                    }
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, VALUE_TYPE_COL)) == "N")
                    {
                        for (j = VALUE_START_COL; j < VALUE_START_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)); j++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) != "")
                            {
                                if (MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j)) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    spdData.ActiveSheet.SetActiveCell(i, j);
                                    spdData.Select();
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        public bool FillCollectionData(TRSNode in_node)
        {
            int i;
            int j;
            int i_value_count;

            TRSNode char_item, unit_item, value_item;

            CultureInfo ci_inter = new CultureInfo("en-US");

            //byte[] file_buffer;

            try
            {
                in_node.SetString("INS_NO", InsNo);
                in_node.SetString("COL_SET_ID", ColSetID);
                in_node.SetInt("COL_SET_VERSION", ColSetVersion);
                in_node.SetString("MAT_ID", MatID);
                in_node.SetString("VENDOR_ID", VendorID);
                in_node.SetString("DELIVERY_NO", DeliveryNo);

                //file_buffer = (byte[])spdData.ActiveSheet.Cells[0, iSpdColCount + 3].Tag;
                //in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);

                char_item = in_node.AddNode("CHAR_LIST");
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COUNT))) == 1)
                    {
                        if (i != 0)
                        {
                            char_item = in_node.AddNode("CHAR_LIST");
                        }
                        char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL))));
                        char_item.SetInt("CHAR_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL))));

                        string sDate = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE))).Substring(0,10).Replace("-","");
                        char_item.AddString("PLAN_DATE", sDate);

                        if (CommentViewFlag == "Y")
                        {
                            char_item.AddString("INSP_COMMENT", MPCF.Trim(spdData.ActiveSheet.GetValue(i, iSpdColCount + 1)));
                        }

                        char_item.AddString("INS_JUDG_RESULT", MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL))));

                        //if (ImageViewFlag == "Y")
                        //{
                        //    file_buffer = (byte[])spdData.ActiveSheet.Cells[i, iSpdColCount + 3].Tag;
                        //    char_item.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                        //}
                    }

                    unit_item = char_item.AddNode("UNIT_LIST");
                    unit_item.AddChar("VALUE_TYPE", spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL)).ToString()[0]);
                    unit_item.AddInt("VALUE_COUNT", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_COUNT_COL)));

                    unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM))));
                    unit_item.AddString("UNIT_ID", spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)));

                    unit_item.AddChar("__REC_SAVE_FLAG", 'Y');

                    i_value_count = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE)));
                    for (j = 0; j < i_value_count; j++)
                    {
                        value_item = unit_item.AddNode("VALUE_LIST");

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL))) == "N" &&
                            MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j + MPCF.ToInt(CHAR_COLUMN.VALUE_START_COL))) == true)
                        {
                            value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)).ToString(ci_inter.NumberFormat));
                        }
                        else
                        {
                            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)) == null ? " " : MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)));
                        }

                        value_item.SetInt("VALUE_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_SEQ_NUM))));
                        value_item.SetInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM))));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DrawCollectionCharacter()
        {
            try
            {
                ClearCollectDataControl();

                if (spdData != null)
                {
                    if (ViewAttachCharacterList(spdData,
                                                '5',
                                                this.ColSetID,
                                                this.ColSetVersion,
                                                "",
                                                null,
                                                'Y',
                                                'Y') == false)
                    {
                        return false;
                    }

                    spdData.Tag = null;
                }

                {
                    int i, k;
                    bool b_escape;

                    b_escape = false;
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        for (k = UNIT_COL; k < spdData.ActiveSheet.ColumnCount; k++)
                        {
                            if (spdData.ActiveSheet.Cells[i, k].Locked == false)
                            {
                                spdData.ActiveSheet.SetActiveCell(i, k);
                                spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);
                                spdData.Focus();
                                b_escape = true;
                                break;
                            }
                        }

                        if (b_escape == true) break;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DrawCollectionCharacter_Data()
        {
            try
            {
                ClearCollectDataControl();

                if (spdData != null)
                {
                    if (ViewAttachCharacterList_Data(spdData,
                                                    '1',
                                                    this.ColSetID,
                                                    this.ColSetVersion,
                                                    "",
                                                    null,
                                                    'Y') == false)
                    {
                        return false;
                    }

                    spdData.Tag = null;
                }

                {
                    int i, k;
                    bool b_escape;

                    b_escape = false;
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        for (k = UNIT_COL; k < spdData.ActiveSheet.ColumnCount; k++)
                        {
                            if (spdData.ActiveSheet.Cells[i, k].Locked == false)
                            {
                                spdData.ActiveSheet.SetActiveCell(i, k);
                                spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);
                                spdData.Focus();
                                b_escape = true;
                                break;
                            }
                        }

                        if (b_escape == true) break;
                    }
                }

                if (AbsValueViewFlag == "Y")
                {
                    int iCount = 0;
                    double iDev;
                    double iMaxValue;
                    double iMinValue;
                    double iValue;
                    for (int i = 0; i < spdData.Sheets[0].Rows.Count; i++)
                    {
                        iCount = 0;
                        iDev = 0;
                        iMaxValue = 0;
                        iMinValue = 9999999;

                        if (spdData.Sheets[0].Cells[i, (int)CHAR_COLUMN.VALUE_TYPE_COL].Text == "N")
                        {
                            for (int j = 0; j < MPCF.ToInt(spdData.Sheets[0].Cells[i, (int)CHAR_COLUMN.SAMPLE_SIZE].Text); j++)
                            {
                                if (string.IsNullOrEmpty(spdData.Sheets[0].Cells[i, 31 + j].Text) == true)
                                    continue;

                                iValue = MPCF.ToDbl(spdData.Sheets[0].Cells[i, 31 + j].Text);

                                if (iMaxValue < iValue)
                                {
                                    iMaxValue = iValue;
                                }

                                if (iMinValue > iValue)
                                {
                                    iMinValue = iValue;
                                }

                                iCount = iCount + 1;
                            }

                            if (iCount > 0)
                            {
                                iDev = Math.Abs(Math.Round(iMaxValue - iMinValue, 3));
                                spdData.Sheets[0].Cells[i, iSpdColCount + 5].Text = MPCF.Trim(iDev);
                            }
                        }
 
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
        /// 
        /// </summary>
        /// <param name="out_node"></param>
        /// <param name="b_check_data_case"></param>
        /// <returns></returns>
        public int ConfirmSpecOutData(TRSNode out_node, bool b_check_data_case)
        {
            if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
            {
                return ResultManagement(out_node);
            }
            else if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
            {
                if (b_check_data_case == false)
                {
                    // MPCR.ShowSuccessMsg(out_node);

                    //if (DrawCollectionCharacter() == false)
                    //{
                    //    return 0;
                    //}
                }
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private int ResultManagement(TRSNode out_node)
        {
            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    frmConfirmCollectData f = new frmConfirmCollectData();
                    ViewResult(f.spdResult, out_node);
                    f.ShowDialog(this);

                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Data Commit
                        //OOC History Insert

                        return 2;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        spdData.Select();
                        return 0;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        spdData.Select();
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spdResult"></param>
        /// <param name="out_node"></param>
        private void ViewResult(FarPoint.Win.Spread.FpSpread spdResult, TRSNode out_node)
        {
            int i, j;
            TRSNode unit_list;
            try
            {
                MPCF.ClearList(spdResult, true);

                for (i = 0; i < out_node.GetList("CHAR_LIST").Count; i++)
                {
                    for (j = 0; j < out_node.GetList("CHAR_LIST")[i].GetList("UNIT_LIST").Count; j++)
                    {
                        unit_list = out_node.GetList("CHAR_LIST")[i].GetList("UNIT_LIST")[j];
                        if (unit_list.GetChar("SPEC_OUT_TYPE") == ' ')
                        {

                        }
                        else
                        {
                            spdResult.Sheets[0].RowCount++;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_SEQ].Value = j + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_CHAR].Value = out_node.GetList("CHAR_LIST")[i].GetString("CHAR_ID");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_UNIT_ID].Value = unit_list.GetString("UNIT_ID");

                            if (unit_list.GetChar("SPEC_OUT_TYPE") == 'W')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOW";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('W');
                            }
                            else if (unit_list.GetChar("SPEC_OUT_TYPE") == 'S')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOS";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('S');
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SetEnable()
        {
            try
            {
                for (int i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    spdData.ActiveSheet.Rows[i].Locked = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void spdData_EditModeOff(object sender, System.EventArgs e)
        {
            try
            {
                int iColumn;
                int iRow;

                if (spdData.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                iColumn = spdData.ActiveSheet.ActiveColumnIndex;
                iRow = spdData.ActiveSheet.ActiveRowIndex;

                if (iColumn == (int)CHAR_COLUMN.SAMPLE_SIZE)
                {
                    FarPoint.Win.Spread.CellType.ComboBoxCellType UnitCellType = null;

                    if (iModifyColumnCnt < MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value))
                    {
                        int i_max_value_count = 0;

                        for (int i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            int i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value);
                            if (iModifyColumnCnt < i_value_count)
                            {
                                i_max_value_count = i_value_count;
                            }
                        }

                        if (iModifyColumnCnt < i_max_value_count)
                        {
                            for (int nCol = DEFAULT_COL_COUNT + iModifyColumnCnt; nCol < (DEFAULT_COL_COUNT + i_max_value_count); nCol++)
                            {
                                spdData.ActiveSheet.ColumnCount += 1;
                                spdData.ActiveSheet.ColumnHeader.Cells.Get(1, nCol).Value = (nCol - (DEFAULT_COL_COUNT) + 1);
                                spdData.ActiveSheet.Columns[nCol].Locked = true;
                                spdData.ActiveSheet.Columns[nCol].BackColor = System.Drawing.Color.WhiteSmoke;
                            }

                            iModifyColumnCnt = i_max_value_count;
                            spdData.ActiveSheet.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).ColumnSpan = i_max_value_count;
                        }

                        for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iModifyColumnCnt); nCol++)
                        {
                            if (string.IsNullOrEmpty(spdData.ActiveSheet.Cells[iRow, nCol].Text) == true)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("A") == true)
                                {
                                    if (UnitCellType == null)
                                    {
                                        if (BASLIST.ViewGCMDataList(spdData, '1', "OKNG", -1, null, "", false, nCol, iRow, null) == false)
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(spdData.ActiveSheet.Cells[iRow, nCol].CellType);
                                            spdData.ActiveSheet.Columns[nCol].Width = 50;
                                        }
                                    }

                                    spdData.ActiveSheet.Cells[iRow, nCol].CellType = UnitCellType;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Text = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.STD_VALUE].Value);

                                    MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                    spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                }
                                else if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("N") == true)
                                {
                                    MPCR.SetNumberCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                    spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                }

                                CheckByCell(spdData.ActiveSheet, iRow, nCol);
                            }
                        }
                    }
                    else if (iModifyColumnCnt > MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value))
                    {
                        FarPoint.Win.Spread.CellType.TextCellType textCellType = null;

                        for (int nCol = DEFAULT_COL_COUNT + iModifyColumnCnt - 1; nCol >= DEFAULT_COL_COUNT; nCol--)
                        {
                            if (DEFAULT_COL_COUNT + MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value) <= nCol)
                            {
                                spdData.ActiveSheet.Cells[iRow, nCol].CellType = textCellType;
                                spdData.ActiveSheet.Cells[iRow, nCol].Value = string.Empty;
                                MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.WhiteSmoke;
                                spdData.ActiveSheet.Cells[iRow, nCol].Locked = true;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(spdData.ActiveSheet.Cells[iRow, nCol].Text) == true)
                                {
                                    if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("A") == true)
                                    {
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(spdData, '1', "OKNG", -1, null, "", false, nCol, iRow, null) == false)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(spdData.ActiveSheet.Cells[iRow, nCol].CellType);
                                                spdData.ActiveSheet.Columns[nCol].Width = 50;
                                            }
                                        }

                                        spdData.ActiveSheet.Cells[iRow, nCol].CellType = UnitCellType;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Text = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.STD_VALUE].Value);

                                        MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                        spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                    }
                                    else if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("N") == true)
                                    {
                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                        spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                    }

                                    CheckByCell(spdData.ActiveSheet, iRow, nCol);
                                }
                            }
                        }
                    }
                    else if (iMaxColumnCnt < MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value))
                    {
                        for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iModifyColumnCnt); nCol++)
                        {
                            if (string.IsNullOrEmpty(spdData.ActiveSheet.Cells[iRow, nCol].Text) == false)
                            {
                                if (DEFAULT_COL_COUNT + MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value) <= nCol)
                                {
                                    FarPoint.Win.Spread.CellType.TextCellType textCellType = null;
                                    spdData.ActiveSheet.Cells[iRow, nCol].CellType = textCellType;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Value = string.Empty;
                                    MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                    spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.WhiteSmoke;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Locked = true;
                                }
                                continue;
                            }

                            if (nCol < DEFAULT_COL_COUNT + MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value))
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("A") == true)
                                {
                                    if (UnitCellType == null)
                                    {
                                        if (BASLIST.ViewGCMDataList(spdData, '1', "OKNG", -1, null, "", false, nCol, iRow, null) == false)
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(spdData.ActiveSheet.Cells[iRow, nCol].CellType);
                                            spdData.ActiveSheet.Columns[nCol].Width = 50;
                                        }
                                    }

                                    spdData.ActiveSheet.Cells[iRow, nCol].CellType = UnitCellType;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Text = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.STD_VALUE].Value);

                                    MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                    spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                }
                                else if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("N") == true)
                                {
                                    MPCR.SetNumberCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                    spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                    spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                }

                                CheckByCell(spdData.ActiveSheet, iRow, nCol);
                            }
                        }
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.TextCellType textCellType = null;

                        for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iMaxColumnCnt); nCol++)
                        {
                            if (DEFAULT_COL_COUNT + MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.SAMPLE_SIZE].Value) <= nCol)
                            {
                                spdData.ActiveSheet.Cells[iRow, nCol].CellType = textCellType;
                                spdData.ActiveSheet.Cells[iRow, nCol].Value = string.Empty;
                                MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.WhiteSmoke;
                                spdData.ActiveSheet.Cells[iRow, nCol].Locked = true;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(spdData.ActiveSheet.Cells[iRow, nCol].Text) == true)
                                {
                                    if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("A") == true)
                                    {
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(spdData, '1', "OKNG", -1, null, "", false, nCol, iRow, null) == false)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(spdData.ActiveSheet.Cells[iRow, nCol].CellType);
                                                spdData.ActiveSheet.Columns[nCol].Width = 50;
                                            }
                                        }

                                        spdData.ActiveSheet.Cells[iRow, nCol].CellType = UnitCellType;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Text = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.STD_VALUE].Value);

                                        MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                        spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                    }
                                    else if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Value).Equals("N") == true)
                                    {
                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[iRow, nCol]);
                                        spdData.ActiveSheet.Cells[iRow, nCol].BackColor = Color.White;
                                        spdData.ActiveSheet.Cells[iRow, nCol].Locked = false;
                                    }

                                    CheckByCell(spdData.ActiveSheet, iRow, nCol);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Spec out 색깔 변경
                    CheckByCell(spdData_Sheet1, iRow, iColumn);

                    //데이터 필드만 적용
                    if (iColumn < DEFAULT_COL_COUNT)
                        return;

                    {
                        System.Collections.ArrayList a_values = new System.Collections.ArrayList();
                        string s_char_id;
                        int i_unit_seq;
                        int i_value_count;
                        int i;

                        s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, CHAR_COL].Value);
                        i_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, UNIT_SEQ_COL].Value);
                        i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, VALUE_COUNT_COL].Value);

                        for (i = 0; i < i_value_count; i++)
                        {
                            a_values.Add(spdData.ActiveSheet.Cells[iRow, VALUE_START_COL + i].Value);
                        }

                    }

                    spdData.ActiveSheet.Cells[iRow, iColumn].Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                    if (iColumn < spdData.ActiveSheet.ColumnCount - 1 && spdData.ActiveSheet.Cells[iRow, iColumn + 1].Locked == false)
                    {
                        spdData.ActiveSheet.SetActiveCell(iRow, iColumn + 1);
                    }
                    else
                    {
                        if (iRow + 1 == spdData.ActiveSheet.RowCount)
                        {
                            return;
                        }
                        if (spdData.ActiveSheet.Cells[iRow + 1, VALUE_START_COL].Locked == false)
                        {
                            spdData.ActiveSheet.SetActiveCell(iRow + 1, VALUE_START_COL);
                        }
                        else
                        {
                            int i;
                            for (i = iRow + 1; i < spdData.ActiveSheet.RowCount; i++)
                            {
                                if (spdData.ActiveSheet.Cells[i, VALUE_START_COL].Locked == false)
                                {
                                    spdData.ActiveSheet.SetActiveCell(i, VALUE_START_COL);
                                    break;
                                }
                            }
                        }
                    }

                    MPCF.FitColumnHeader(spdData);
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (spdData.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                if (spdData.ActiveSheet.Cells[spdData.ActiveSheet.ActiveRowIndex, VALUE_TYPE_COL].Text == "N")
                {
                    if (spdData.ActiveSheet.ActiveColumnIndex == UNIT_COL)
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public bool ViewAttachCharacterList(Control control, char ProcStep, string ColSetID, string ColSetVersion, string Ext_Factory,
                                                   TreeNode parentNode, char cIncludeUnitID)
        {
            return ViewAttachCharacterList(control, ProcStep, ColSetID, ColSetVersion, Ext_Factory, parentNode, cIncludeUnitID, ' ');

        }

        public bool ViewAttachCharacterList(Control control, char ProcStep, string ColSetID, string ColSetVersion, string Ext_Factory,
                                                   TreeNode parentNode, char cIncludeUnitID, char cAfterFlag)
        {

            int i;
            int i_index;
            int iUnitCnt = 0;
            int iValueCnt = 0;
            int iColCnt = 0;
            char cUnitType;
            char cDerivedParamFlag;
            char cDefUnitFlag;
            char cDefUnitOvrFlag;
            string sUnitTbl;

            FarPoint.Win.Spread.CellType.ComboBoxCellType UnitCellType = null;
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = null;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType txtCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType1.Multiline = true;
            dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateCellType.UserDefinedFormat = "yyyy-MM-dd";
            dateCellType.SpinButton = true;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");

            try
            {
                if (control is FpSpread)
                {
                    ((FpSpread)control).SuspendLayout();

                    ((FpSpread)control).ActiveSheet.RowCount = 0;
                    ((FpSpread)control).ActiveSheet.ColumnCount = DEFAULT_COL_COUNT;

                    ((FpSpread)control).ResumeLayout();
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (Ext_Factory != "")
                {
                    in_node.Factory = Ext_Factory;
                }

                in_node.AddChar("INCLUDE_UNIT_ID", cIncludeUnitID);
                in_node.AddString("COL_SET_ID", ColSetID);
                in_node.AddInt("COL_SET_VERSION", ColSetVersion);

                if (ResourceViewFlag == "Y")
                {
                    in_node.AddChar("RES_VIEW_FLAG", 'Y');
                }

                if (control is FpSpread)
                {
                    // Initialize
                    FarPoint.Win.Spread.SheetView with_1 = ((FpSpread)control).ActiveSheet;
                    do
                    {
                        if (MPCR.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        // Get Max Value Count
                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            if (iMaxColumnCnt < iValueCnt)
                            {
                                iMaxColumnCnt = iValueCnt;
                            }
                        }

                        iModifyColumnCnt = iMaxColumnCnt;
                        with_1.ColumnCount = DEFAULT_COL_COUNT + iMaxColumnCnt + CUSTOM_ADD_COL_COUNT;
                        with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).ColumnSpan = iMaxColumnCnt;
                        with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).Text = "Value";

                        with_1.Columns[MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE)].Locked = false;

                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            with_1.RowCount++;

                            /* 기본값 세팅 */
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.LINE), Line);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.WORK_GROUP_ID), out_node.GetList(0)[i].GetString("WORK_GROUP_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.WORK_GROUP_DESC), out_node.GetList(0)[i].GetString("WORK_GROUP_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.RES_ID), out_node.GetList(0)[i].GetString("RES_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.RES_DESC), out_node.GetList(0)[i].GetString("RES_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.MAKER), out_node.GetList(0)[i].GetString("MAKER"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SIZE_FORMAT), out_node.GetList(0)[i].GetString("SIZE_FORMAT"));

                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE)].CellType = dateCellType;
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE), DateTime.Now.ToString("yyyy-MM-dd"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_MTOD), out_node.GetList(0)[i].GetString("CHAR_MTOD"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL), out_node.GetList(0)[i].GetString("CHAR_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_DESC_COL), out_node.GetList(0)[i].GetString("CHAR_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.ATTACH_FILE_DIR), out_node.GetList(0)[i].GetString("ATTACH_FILE_DIR"));
                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.ATTACH_FILE_DIR)].CellType = txtCellType1;
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
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL), out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE), out_node.GetList(0)[i].GetInt("VALUE_COUNT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COUNT), out_node.GetList(0)[i].GetInt("UNIT_COUNT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_SEQ_NUM), out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.COL_SEQ), out_node.GetList(0)[i].GetInt("COL_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM), 1);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.EDC_HIST_SEQ), out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), out_node.GetList(0)[i].GetString("UNIT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL), "OK");

                            iUnitCnt = out_node.GetList(0)[i].GetInt("UNIT_COUNT");
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            cUnitType = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                            cDerivedParamFlag = out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG");
                            cDefUnitFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG");
                            cDefUnitOvrFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG");
                            sUnitTbl = out_node.GetList(0)[i].GetString("UNIT_TBL");

                            i_index = 0;
                            /* Value Count  - 숨긴컬럼 차감*/
                            for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iMaxColumnCnt); nCol++)
                            {
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
                                        /*콤보박스*/
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', "OKNG", -1, null, "", false, nCol, i, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[i, nCol].CellType);
                                                with_1.Columns[nCol].Width = 50;
                                            }
                                        }
                                        with_1.Cells[i, nCol].CellType = UnitCellType;
                                        with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET_VALUE"));

                                        MPCR.SetAsciiCell(with_1.Cells[i, nCol]);
                                    }
                                    else if (cUnitType == 'N')
                                    {
                                        if (BASLIST.ViewGCMDataList(control, '1', "PATROLCHECK", -1, null, "", false, nCol, i, null) == false)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[i, nCol].CellType);
                                            with_1.Columns[nCol].Width = 50;
                                        }
                                        with_1.Cells[i, nCol].CellType = UnitCellType;
                                        with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET_VALUE"));

                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[i, nCol]);
                                    }
                                }
                                i_index = i_index + 1;

                                CheckByCell(with_1, i, nCol);

                                iColCnt = nCol;
                            }

                            iSpdColCount = iColCnt;

                            // insp comment 컬럼 추가 
                            if (CommentViewFlag == "Y")
                            {
                                with_1.ColumnHeader.Cells[0, iColCnt + 1].Text = "Comment";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 1, 2, 1);
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 1].CellType);
                                with_1.Columns[iColCnt + 1].Width = 50;
                            }
                            else
                            {
                                with_1.Columns[iColCnt + 1].Visible = false;
                            }

                            // IMAGE 컬럼 추가 
                            if (ImageViewFlag == "Y")
                            {
                                with_1.ColumnHeader.Cells[0, iColCnt + 2].Text = "Image";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 2, 2, 1);
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 2].CellType);
                                with_1.Columns[iColCnt + 2].Width = 100;

                                with_1.ColumnHeader.Cells[0, iColCnt + 3].Text = "Upload";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 3, 2, 1);
                                with_1.Cells[i, iColCnt + 3].CellType = btnCellType;
                                with_1.Columns[iColCnt + 3].Width = 30;

                                with_1.ColumnHeader.Cells[0, iColCnt + 4].Text = "Delete";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 4, 2, 1);
                                with_1.Cells[i, iColCnt + 4].CellType = btnCellType;
                                with_1.Columns[iColCnt + 4].Width = 30;
                            }
                            else
                            {
                                with_1.Columns[iColCnt + 2].Visible = false;
                                with_1.Columns[iColCnt + 3].Visible = false;
                                with_1.Columns[iColCnt + 4].Visible = false;
                            }

                            if (AbsValueViewFlag == "Y")
                            {
                                with_1.ColumnHeader.Cells[0, iColCnt + 5].Text = "편차";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 5, 2, 1);
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 5].CellType);
                                with_1.Columns[iColCnt + 5].Width = 50;
                            }
                            else 
                            {
                                with_1.Columns[iColCnt + 5].Visible = false;
                            }

                            if (AttachFileFlag == "Y")
                            {
                                with_1.Rows[i].Height = with_1.Rows[i].GetPreferredHeight() + 4;
                            }
                        }

                        in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

                    } while (in_node.GetString("NEXT_CHAR_ID") != "");
                }

                MPCF.ConvertMessage(this.Controls);
                MPCF.FitColumnHeader(spdData);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


            return true;

        }

        public bool ViewAttachCharacterList_Data(Control control, char ProcStep, string ColSetID, string ColSetVersion, string Ext_Factory,
                                                   TreeNode parentNode, char cIncludeUnitID)
        {

            int i;
            int i_index;
            int iUnitCnt = 0;
            int iValueCnt = 0;
            int iColCnt = 0;
            char cUnitType;
            char cDerivedParamFlag;
            char cDefUnitFlag;
            char cDefUnitOvrFlag;
            string sUnitTbl;
            string sInspComment;
            string sInspDoc;
            string sAbsValue = string.Empty;

            FarPoint.Win.Spread.CellType.ComboBoxCellType UnitCellType = null;
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = null;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType txtCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType1.Multiline = true;
            dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dateCellType.UserDefinedFormat = "yyyy-MM-dd";
            dateCellType.SpinButton = true;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_LIST_OUT");

            try
            {
                if (control is FpSpread)
                {
                    ((FpSpread)control).SuspendLayout();

                    ((FpSpread)control).ActiveSheet.RowCount = 0;
                    ((FpSpread)control).ActiveSheet.ColumnCount = DEFAULT_COL_COUNT;

                    ((FpSpread)control).ResumeLayout();
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (Ext_Factory != "")
                {
                    in_node.Factory = Ext_Factory;
                }

                in_node.SetString("INS_NO", MPCF.Trim(InsNo));
                in_node.SetString("COL_SET_ID", ColSetID);
                in_node.SetInt("COL_SET_VERSION", ColSetVersion);

                if (ResourceViewFlag == "Y")
                {
                    in_node.AddChar("RES_VIEW_FLAG", 'Y');
                }

                if (control is FpSpread)
                {
                    // Initialize
                    FarPoint.Win.Spread.SheetView with_1 = ((FpSpread)control).ActiveSheet;
                    do
                    {
                        if (MPCR.CallService("IEDC", "IEDC_View_Ins_Data_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        // Get Max Value Count
                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            if (iMaxColumnCnt < iValueCnt)
                            {
                                iMaxColumnCnt = iValueCnt;
                            }
                        }

                        iModifyColumnCnt = iMaxColumnCnt;
                        with_1.ColumnCount = DEFAULT_COL_COUNT + iMaxColumnCnt + CUSTOM_ADD_COL_COUNT;
                        with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).ColumnSpan = iMaxColumnCnt;
                        with_1.ColumnHeader.Cells.Get(0, DEFAULT_COL_COUNT).Text = "Value";

                        with_1.Columns[MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE)].Locked = false;

                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            with_1.RowCount++;

                            /* 기본값 세팅 */
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.LINE), Line);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.WORK_GROUP_ID), out_node.GetList(0)[i].GetString("WORK_GROUP_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.WORK_GROUP_DESC), out_node.GetList(0)[i].GetString("WORK_GROUP_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.RES_ID), out_node.GetList(0)[i].GetString("RES_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.RES_DESC), out_node.GetList(0)[i].GetString("RES_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.MAKER), out_node.GetList(0)[i].GetString("MAKER"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SIZE_FORMAT), out_node.GetList(0)[i].GetString("SIZE_FORMAT"));

                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE)].CellType = dateCellType;
                            if (string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("PLAN_DATE")) == true)
                            {
                                with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE), DateTime.Now.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                string sDate = MPOF.Convstr8ToDateTime(out_node.GetList(0)[i].GetString("PLAN_DATE"));
                                with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.PLAN_DATE), sDate);
                            }

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_MTOD), out_node.GetList(0)[i].GetString("CHAR_MTOD"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL), out_node.GetList(0)[i].GetString("CHAR_ID"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_DESC_COL), out_node.GetList(0)[i].GetString("CHAR_DESC"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.ATTACH_FILE_DIR), out_node.GetList(0)[i].GetString("ATTACH_FILE_DIR"));
                            with_1.Cells[i, MPCF.ToInt(CHAR_COLUMN.ATTACH_FILE_DIR)].CellType = txtCellType1;

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
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL), out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE), out_node.GetList(0)[i].GetInt("VALUE_COUNT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COUNT), out_node.GetList(0)[i].GetInt("UNIT_COUNT"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_SEQ_NUM), out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.COL_SEQ), out_node.GetList(0)[i].GetInt("COL_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM), 1);
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.EDC_HIST_SEQ), out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COL), out_node.GetList(0)[i].GetString("UNIT"));

                            with_1.SetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_RESULT_COL), "OK");

                            iUnitCnt = out_node.GetList(0)[i].GetInt("UNIT_COUNT");
                            iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                            cUnitType = out_node.GetList(0)[i].GetChar("VALUE_TYPE");
                            cDerivedParamFlag = out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG");
                            cDefUnitFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG");
                            cDefUnitOvrFlag = out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG");
                            sUnitTbl = out_node.GetList(0)[i].GetString("UNIT_TBL");
                            sInspComment = out_node.GetList(0)[i].GetString("INSP_COMMENT");
                            sInspDoc = out_node.GetList(0)[i].GetString("INSP_DOC");

                            i_index = 0;
                            /* Value Count  - 숨긴컬럼 차감*/
                            for (int nCol = DEFAULT_COL_COUNT; nCol < (DEFAULT_COL_COUNT + iMaxColumnCnt); nCol++)
                            {
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
                                        /*콤보박스*/
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', "OKNG", -1, null, "", false, nCol, i, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[i, nCol].CellType);
                                                with_1.Columns[nCol].Width = 50;
                                            }
                                        }
                                        with_1.Cells[i, nCol].CellType = UnitCellType;
                                        with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_" + (nCol - DEFAULT_COL_COUNT + 1)));

                                        MPCR.SetAsciiCell(with_1.Cells[i, nCol]);
                                    }
                                    else if (cUnitType == 'N')
                                    {
                                        /*콤보박스*/
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', "PATROLCHECK", -1, null, "", false, nCol, i, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[i, nCol].CellType);
                                                with_1.Columns[nCol].Width = 50;
                                            }
                                        }
                                        with_1.Cells[i, nCol].CellType = UnitCellType;
                                        with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_" + (nCol - DEFAULT_COL_COUNT + 1)));
                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[i, nCol]);
                                    }
                                }
                                i_index = i_index + 1;

                                iSpdColCount = nCol;

                                CheckByCell(with_1, i, nCol);
                                iColCnt = nCol;
                            }

                            iSpdColCount = iColCnt;

                            // insp comment 컬럼 추가 
                            if (CommentViewFlag == "Y")
                            {
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 1].CellType);
                                with_1.Columns[iColCnt + 1].Width = 200;
                                with_1.Cells[i, iColCnt + 1].Text = sInspComment;
                                with_1.ColumnHeader.Cells[0, iColCnt + 1].Text = "Comment";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 1, 2, 1);
                            }
                            else
                            {
                                with_1.Columns[iColCnt + 1].Visible = false;
                            }

                            // IMAGE 컬럼 추가 
                            if (ImageViewFlag == "Y")
                            {
                                with_1.ColumnHeader.Cells[0, iColCnt + 2].Text = "Image";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 2, 2, 1);
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 2].CellType);
                                with_1.Columns[iColCnt + 2].Width = 100;
                                with_1.Cells[i, iColCnt + 2].Text = sInspDoc;

                                with_1.ColumnHeader.Cells[0, iColCnt + 3].Text = "Upload";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 3, 2, 1);
                                with_1.Cells[i, iColCnt + 3].CellType = btnCellType;
                                with_1.Columns[iColCnt + 3].Width = 30;

                                with_1.ColumnHeader.Cells[0, iColCnt + 4].Text = "Delete";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 4, 2, 1);
                                with_1.Cells[i, iColCnt + 4].CellType = btnCellType;
                                with_1.Columns[iColCnt + 4].Width = 30;
                            }
                            else
                            {
                                with_1.Columns[iColCnt + 2].Visible = false;
                                with_1.Columns[iColCnt + 3].Visible = false;
                                with_1.Columns[iColCnt + 4].Visible = false;
                            }

                            if (AbsValueViewFlag == "Y")
                            {
                                txtCellType = (FarPoint.Win.Spread.CellType.TextCellType)(with_1.Cells[i, iColCnt + 5].CellType);
                                with_1.Columns[iColCnt + 5].Width = 50;
                                with_1.Cells[i, iColCnt + 5].Text = sAbsValue;
                                with_1.ColumnHeader.Cells[0, iColCnt + 5].Text = "편차";
                                with_1.AddColumnHeaderSpanCell(0, iColCnt + 5, 2, 1);
                            }
                            else
                            {
                                with_1.Columns[iColCnt + 5].Visible = false;
                            }

                            if (AttachFileFlag == "Y")
                            {
                                with_1.Rows[i].Height = with_1.Rows[i].GetPreferredHeight() + 4;
                            }
                        }

                        in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));

                    } while (in_node.GetString("NEXT_CHAR_ID") != "");
                }

                MPCF.ConvertMessage(this.Controls);
                MPCF.FitColumnHeader(spdData);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


            return true;

        }

        private string GetDev(string s_ins_no, string s_col_set_id, string s_col_set_version, string s_char_id)
        {
            try
            {
                string s_dev_value = "";
                string sql;

                TRSNode in_node = new TRSNode("Sql_In");
                TRSNode out_node = new TRSNode("Sql_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';


                sql = "SELECT ABS(DECODE(VALUE_MAX, ' ', 0, VALUE_MAX) - DECODE(VALUE_MIN, 9999999999, 0, VALUE_MIN)) VALUE_25 " +
                        " FROM( SELECT GREATEST(VALUE_1 ,VALUE_2 ,VALUE_3 ,VALUE_4 ,VALUE_5 ,VALUE_6 ,VALUE_7 ,VALUE_8 ,VALUE_9 ,VALUE_10 " +
                        " ,VALUE_11 ,VALUE_12 ,VALUE_13 ,VALUE_14 ,VALUE_15 ,VALUE_16 ,VALUE_17 ,VALUE_18 ,VALUE_19 ,VALUE_20 " +
                        " ,VALUE_21 ,VALUE_22 ,VALUE_23 ,VALUE_24 ,VALUE_25 ) VALUE_MAX, " +
                        " LEAST(DECODE(VALUE_1, ' ', 9999999999, VALUE_1)  ,DECODE(VALUE_2, ' ', 9999999999, VALUE_2) " +
                        " ,DECODE(VALUE_3, ' ', 9999999999, VALUE_3) ,DECODE(VALUE_4, ' ', 9999999999, VALUE_4) " +
                        " ,DECODE(VALUE_5, ' ', 9999999999, VALUE_5)  ,DECODE(VALUE_6, ' ', 9999999999, VALUE_6) " +
                        " ,DECODE(VALUE_7, ' ', 9999999999, VALUE_7)  ,DECODE(VALUE_8, ' ', 9999999999, VALUE_8) " +
                        " ,DECODE(VALUE_9, ' ', 9999999999, VALUE_9)  ,DECODE(VALUE_10, ' ', 9999999999, VALUE_10) " +
                        " ,DECODE(VALUE_11, ' ', 9999999999, VALUE_11)  ,DECODE(VALUE_12, ' ', 9999999999, VALUE_12) " +
                        " ,DECODE(VALUE_13, ' ', 9999999999, VALUE_13)  ,DECODE(VALUE_14, ' ', 9999999999, VALUE_14) " +
                        " ,DECODE(VALUE_15, ' ', 9999999999, VALUE_15)  ,DECODE(VALUE_16, ' ', 9999999999, VALUE_16)  " +
                        " ,DECODE(VALUE_17, ' ', 9999999999, VALUE_17)  ,DECODE(VALUE_18, ' ', 9999999999, VALUE_18) " +
                        " ,DECODE(VALUE_19, ' ', 9999999999, VALUE_19)  ,DECODE(VALUE_20, ' ', 9999999999, VALUE_20) " +
                        " ,DECODE(VALUE_21, ' ', 9999999999, VALUE_21)  ,DECODE(VALUE_22, ' ', 9999999999, VALUE_22) " +
                        " ,DECODE(VALUE_23, ' ', 9999999999, VALUE_23)  ,DECODE(VALUE_24, ' ', 9999999999, VALUE_24) " +
                        " ,DECODE(VALUE_25, ' ', 9999999999, VALUE_25)  ) VALUE_MIN " +
                        " FROM CEDCINSDAT " +
                        " WHERE FACTORY = '" + MPGV.gsFactory + "'" +
                        " AND INS_NO = '" + s_ins_no + "'" + 
                        " AND COL_SET_ID = '" + s_col_set_id + "'" +
                        " AND COL_SET_VERSION = " + s_col_set_version + 
                        " AND CHAR_ID = '" + s_char_id + "') ";

                in_node.AddString("SQL", sql);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return s_dev_value;
                }

                if (out_node.ListCount > 0)
                {
                    s_dev_value = MPCF.Trim(out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA"));
                }

                return s_dev_value;

            }
            catch (Exception)
            {
                return "";
            }
        }

        private bool ViewImage(int iRow)
        {
            TRSNode in_node = new TRSNode("VIEW_IMAGE_IN");
            TRSNode out_node = new TRSNode("VIEW_IMAGE_OUT");
            byte[] bt_buffer;
            FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';
            in_node.AddString("INS_NO", MPCF.Trim(InsNo));
            in_node.AddString("COL_SET_ID", MPCF.Trim(ColSetID));
            in_node.AddString("CHAR_ID", MPCF.Trim(with_1.Cells[iRow, (int)CHAR_COLUMN.CHAR_COL].Text));


            if (MPCR.CallService("IEDC", "IEDC_Tran_Check_Sheet", in_node, ref out_node) == false)
            {
                return false;
            }

            // Image File
            pictureBox1.Image = null;
            pictureBox1.Tag = ' ';

            if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
            {
                MemoryStream ms_buffer;

                try
                {
                    ms_buffer = new MemoryStream();
                    ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                    ms_buffer.Position = 0;

                    pictureBox1.Image = Image.FromStream(ms_buffer);
                    pictureBox1.Image.Tag = bt_buffer;
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }

            return true;

        }

        private bool DeleteImage(int iRow)
        {
            TRSNode in_node = new TRSNode("VIEW_IMAGE_IN");
            TRSNode out_node = new TRSNode("VIEW_IMAGE_OUT");

            FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '5';
            in_node.AddString("INS_NO", MPCF.Trim(InsNo));
            in_node.AddString("COL_SET_ID", MPCF.Trim(ColSetID));
            in_node.AddString("CHAR_ID", MPCF.Trim(with_1.Cells[iRow, (int)CHAR_COLUMN.CHAR_COL].Text));
            in_node.AddString("INSP_DOC", "");

            if (MPCR.CallService("IEDC", "IEDC_Tran_Check_Sheet", in_node, ref out_node) == false)
            {
                return false;
            }

            // Image File
            pictureBox1.Image = null;
            pictureBox1.Tag = ' ';

            return true;
        }

        public bool ViewLotData()
        {
            return ViewLotData(spdData);
        }

        public bool ViewLotData(Control control)
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

            int iMaxColumnCnt = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

            System.Collections.ArrayList a_values = new System.Collections.ArrayList();

            FarPoint.Win.Spread.CellType.ComboBoxCellType UnitCellType = null;
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

                MPCF.ClearList(spdData, true);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("INS_NO", MPCF.Trim(ms_ins_no));
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
                    //for (i = 0; i < out_node.GetList(0).Count; i++)
                    //{
                    //    iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                    //    if (iMaxColumnCnt < iValueCnt)
                    //    {
                    //        iMaxColumnCnt = iValueCnt;
                    //    }
                    //}

                    iModifyColumnCnt = iMaxColumnCnt;

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
                            this.ColSetID = out_node.GetList(0)[i].GetString("COL_SET_ID");

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
                                        /*콤보박스*/
                                        if (UnitCellType == null)
                                        {
                                            if (BASLIST.ViewGCMDataList(control, '1', "OKNG", -1, null, "", false, nCol, i, null) == false)
                                            {
                                                return false;
                                            }
                                            else
                                            {
                                                UnitCellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)(with_1.Cells[i, nCol].CellType);
                                                with_1.Columns[nCol].Width = 50;
                                            }
                                        }
                                        with_1.Cells[i, nCol].CellType = UnitCellType;

                                        if (MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name)) != "")
                                        {
                                            with_1.Cells[i, nCol].Text = MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name));
                                        }

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
                                        MPCR.SetNumberCell(spdData.ActiveSheet.Cells[i, nCol]);

                                        if (string.IsNullOrEmpty(MPCF.Trim(with_1.Cells[i, (int)CHAR_COLUMN.LOWER_LIMIT].Value)) == true &&
                                            string.IsNullOrEmpty(MPCF.Trim(with_1.Cells[i, (int)CHAR_COLUMN.MAX_LIMIT].Value)) == true)
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

        private bool UpdateImage(int iRow)
        {
            TRSNode in_node = new TRSNode("TRAN_LPA_CHECK_SHEET_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_LPA_CHECK_SHEET_LIST_OUT");

            FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
            byte[] file_buffer;

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '3';

                in_node.SetString("INS_NO", InsNo);
                in_node.SetString("COL_SET_ID", ColSetID);
                in_node.SetString("CHAR_ID", MPCF.Trim(with_1.Cells[iRow, (int)CHAR_COLUMN.CHAR_COL].Text));
                in_node.SetString("INSP_DOC", MPCF.Trim(with_1.Cells[iRow, ColCount + 2].Text));
                file_buffer = (byte[])with_1.Cells[iRow, ColCount + 3].Tag;
                in_node.SetBlob(MPGC.MP_BIN_DATA_1, file_buffer);

                if (MPCR.CallService("IEDC", "IEDC_Tran_Check_Sheet", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool UpdateInspList()
        {
            TRSNode in_node = new TRSNode("TRAN_LPA_CHECK_SHEET_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_LPA_CHECK_SHEET_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);

                if (string.IsNullOrEmpty(InsNo) == true)
                {
                    in_node.ProcStep = '1';
                }
                else
                    in_node.ProcStep = '2';

                in_node.AddString("INS_NO", InsNo);
                in_node.AddString("INSP_TYPE", InspType);
                in_node.AddString("SHOP_CODE", ShopCode);
                in_node.AddString("MAT_ID", MPCF.Trim(MatID));

                if (FillCollectionData(in_node) == false) return false;

                if (MPCR.CallService("IEDC", "IEDC_Tran_Check_Sheet", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                InsNo = out_node.GetString("INS_NO");

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Change_Lot_Data(char ProcStep)
        {
            int i = 0;
            int k = 0;
            int i_ret = 0;
            int i_count = 0;
            int iValueCnt = 0;
            int i_unit_count = 0;
            string s_char_id = "";
            string s_unit_seq = "";

            TRSNode in_node = new TRSNode("CHANGE_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("CHANGE_LOT_DATA_OUT");
            TRSNode char_item = null, value_item = null, unit_item = null, value_seq_item = null;

            CultureInfo ci_inter = new CultureInfo("en-US");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.Factory = MPGV.gsFactory;
                in_node.UserID = MPGV.gsUserID;

                if (ProcStep == '6')
                {
                    ProcStep = '5';
                    in_node.AddChar("CONTINUE_FLAG", 'Y');
                }

                in_node.ProcStep = ProcStep;
                in_node.SetString("INS_NO", MPCF.Trim(ms_ins_no));

                char_item = in_node.AddNode("CHAR_LIST");
                unit_item = char_item.AddNode("UNIT_LIST");
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {

                    iValueCnt = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_COUNT_COL));

                    if (MPCF.Trim(s_char_id) != MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL))))
                    {
                        if (i_count != 0)
                        {
                            char_item = in_node.AddNode("CHAR_LIST");
                        }
                        s_char_id = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL)));

                        char_item.AddString("COL_SET_ID", this.ColSetID);
                        char_item.AddInt("COL_SET_VERSION", this.ColSetVersion);

                        char_item.AddInt("COL_SEQ", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, spdData.ActiveSheet.ColumnCount - MPCF.ToInt(CHAR_COLUMN.COL_SEQ))));
                        char_item.AddInt("CHAR_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, spdData.ActiveSheet.ColumnCount - MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL))));
                        char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.CHAR_COL)));

                        s_unit_seq = "";
                        i_count++;
                    }

                    //2008.02.19 추가 - LAVERWON
                    if (MPCF.Trim(s_unit_seq) != MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL))))
                    {
                        if (i_unit_count != 0)
                        {
                            unit_item = char_item.AddNode("UNIT_LIST");
                        }
                        unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, spdData.ActiveSheet.ColumnCount - MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM))));
                        unit_item.AddString("UNIT_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.UNIT_COL)));
                        unit_item.AddString("VALUE_TYPE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_TYPE_COL)));
                        unit_item.AddString("VALUE_COUNT", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_COUNT_COL)));


                        s_unit_seq = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL)));

                        i_unit_count++;
                    }
                    value_seq_item = unit_item.AddNode("VALUE_SEQ_LIST");
                    value_seq_item.AddInt("VALUE_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, spdData.ActiveSheet.ColumnCount - 3)));

                    for (k = 0; k < iValueCnt; k++)
                    {
                        value_item = value_seq_item.AddNode("VALUE_LIST");

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_TYPE_COL)) == "N" && MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, k + VALUE_START_COL)) == true)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, k + DEFAULT_COL_COUNT)) == "")
                                value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, k + DEFAULT_COL_COUNT)));
                            else
                                value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, k + DEFAULT_COL_COUNT)).ToString(ci_inter.NumberFormat));
                        }
                        else
                        {
                            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, k + DEFAULT_COL_COUNT)));
                        }
                    }
                }

                if (MessageCaster.CallService("QCM", "QCM_Change_Lot_Data", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                i_ret = ConfirmSpecOutData(out_node, false);

                if (i_ret == 2) // Data Commit Case
                {
                    if (Change_Lot_Data('6') == false)
                    {
                        return false;
                    }
                }
                else if (i_ret == 0)
                {
                    return false;
                }
                else
                {
                    MPCR.ShowSuccessMsg(out_node);
                }

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

                //비고, 이미지 컬럼의 경우 적용 안함. 
                //if (iSpdColCount < nCol)
                //    return;

                if (spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Text == "N" && iSpdColCount >= nCol)
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
                else if (spdView.Cells[nRow, (int)CHAR_COLUMN.VALUE_TYPE_COL].Text == "A" && iSpdColCount >= nCol)
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

        private void spdData_ClipboardPasting(object sender, ClipboardPastingEventArgs e)
        {
            e.Handled = true;
            //Spread.fpSpd_Clipboard(sender, e);
        }

        //private void spdData_CellClick(object sender, CellClickEventArgs e)
        //{
        //    FileInfo finfo;
        //    BinaryReader br;
        //    byte[] file_buffer;

        //    FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;

        //    try
        //    {
        //        if (e.Row < 0 || e.Column != iSpdColCount + 3)
        //            return;

        //        ofdFile.Filter = "JPEG File(*.jpg)|*.jpg";
        //        ofdFile.FileName = "";

        //        if (ofdFile.ShowDialog() == DialogResult.OK)
        //        {
        //            finfo = new FileInfo(ofdFile.FileName);
        //            if (finfo.Exists == true)
        //            {
        //                br = new BinaryReader(finfo.OpenRead());
        //                file_buffer = br.ReadBytes((int)finfo.Length);
        //                with_1.Cells[e.Row, e.Column].Tag = file_buffer;
        //                br.Close();

        //                with_1.Cells[e.Row, iSpdColCount + 2].Text = finfo.Name; 
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.ToString());
        //    }
        //}

        private void spdData_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            FarPoint.Win.Spread.SheetView with_1 = spdData.ActiveSheet;

            try
            {
                if (e.Row < 0)
                    return;

                if (e.Column == iSpdColCount + 3)       // 업로드 버튼
                {
                    ofdFile.Filter = "JPEG File(*.jpg)|*.jpg";
                    ofdFile.FileName = "";

                    if (ofdFile.ShowDialog() == DialogResult.OK)
                    {
                        finfo = new FileInfo(ofdFile.FileName);
                        if (finfo.Exists == true)
                        {
                            br = new BinaryReader(finfo.OpenRead());
                            file_buffer = br.ReadBytes((int)finfo.Length);
                            with_1.Cells[e.Row, e.Column].Tag = file_buffer;
                            br.Close();

                            with_1.Cells[e.Row, iSpdColCount + 2].Text = finfo.Name;
                        }

                        if (string.IsNullOrEmpty(InsNo) == true)
                        {
                            if (UpdateInspList() == false) return;
                        }

                        if (UpdateImage(e.Row) == false) return;

                        if (DrawCollectionCharacter_Data() == false) return;
                    }
                }
                else if (e.Column == iSpdColCount + 4)      // 삭제 버튼 
                {
                    if (DeleteImage(e.Row) == false)
                        return;

                    if (DrawCollectionCharacter_Data() == false)
                        return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
        }

        private void spdData_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                if (e.Row < 0 || e.Column != iSpdColCount + 2 || string.IsNullOrEmpty(spdData.Sheets[0].Cells[e.Row, e.Column].Text) == true)
                    return;

                panel1.BringToFront();

                if (ViewImage(e.Row) == false)
                    return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                spdData.BringToFront();

                pictureBox1.Image = null;
                pictureBox1.Tag = ' ';
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
        }
    }
}