using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;
using Miracom.UI;
using SOI.OIFrx;
using System.Collections;
using System.Globalization;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOICollectInspData : UserControl
    {
        public SOICollectInspData()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum COL_SPD : int
        {
            COL_LINE_CODE = 0,
            COL_LINE_DESC,
            COL_RES_ID,
            COL_RES_DESC,
            COL_CHAR_ID,
            COL_CHAR_DESC,
            COL_CHAR_SPEC,
            COL_VALUE_TYPE,
            COL_LOWER_SPEC,
            COL_TARGET_VALUE,
            COL_UPPER_SPEC,
            COL_INSP_RESULT
        }
        
        #endregion

        #region " Variable Definition "

        private int[] COL_VISIBLE { get; set; }
        private int[] COL_COLOR { get; set; }

        public string INS_NO { get; set; }
        public string COL_SET_ID { get; set; }
        public int COL_SET_VERSION { get; set; }
        public string MAT_ID { get; set; }
        public string VENDOR_ID { get; set; }
        public string DLV_NO { get; set; }
        
        #endregion

        #region " Function Definition "

        /// <summary>
        /// 테마적용
        /// </summary>
        /// <returns></returns>
        public bool FunctionApplyThema()
        {
            try
            {
                Font HFonts = new Font("맑은 고딕", 14, FontStyle.Bold);
                Font DFonts = new Font("맑은 고딕", 14, FontStyle.Regular);

                for (int i = 0; i < this.spdData.Sheets.Count; i++)
                {
                    this.spdData.Sheets[i].ColumnHeader.DefaultStyle.Font = HFonts;
                    this.spdData.Sheets[i].ColumnHeader.Rows[0].Height = 30;
                    this.spdData.Sheets[i].ColumnHeader.Rows[1].Height = 30;
                    this.spdData.Sheets[i].DefaultStyle.Font = DFonts;
                    this.spdData.Sheets[i].DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    this.spdData.Sheets[i].Rows.Default.Height = 30F;
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
        /// 칼럼 Visible false
        /// </summary>
        /// <param name="i_col_visible"></param>
        /// <returns></returns>
        public bool FunctionnColumnsVisible(int[] i_col_visible)
        {
            try
            {
                this.COL_VISIBLE = i_col_visible;

                for (int i = 0; i < i_col_visible.Length; i++)
                {
                    spdData.ActiveSheet.Columns[i].Visible = false;
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
        /// 칼럼 칼라 변경
        /// </summary>
        /// <param name="i_col_color"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool FunctionColumnsColor(int[] i_col_color, Color color)
        {
            try
            {
                COL_COLOR = i_col_color;

                for (int i = 0; i < i_col_color.Length; i++)
                {
                    spdData.ActiveSheet.Columns[i].BackColor = color;
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
        /// 데이터 담기
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        public bool FillColectionData(TRSNode in_node)
        {
            TRSNode char_item, unit_item, value_item;
            CultureInfo ci_inter = new CultureInfo("en-US");
            int i_value_count;

            try
            {
                //in_node.AddString("INS_NO", INS_NO);
                //in_node.AddString("COL_SET_ID", COL_SET_ID);
                //in_node.AddInt("COL_SET_VERSION", COL_SET_VERSION);
                //in_node.AddString("MAT_ID", MAT_ID);
                //in_node.AddString("VENDOR_ID", VENDOR_ID);
                //in_node.AddString("DELIVERY_NO", DLV_NO);

                //char_item = in_node.AddNode("CHAR_LIST");
                //for (int i = 0; i < spdData.ActiveSheet.RowCount; i++)
                //{
                //    if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COUNT))) == 1)
                //    {
                //        if (i != 0)
                //        {
                //            char_item = in_node.AddNode("CHAR_LIST");
                //        }
                //        char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_COL))));
                //        char_item.SetInt("CHAR_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.CHAR_SEQ_COL))));
                //    }

                //    unit_item = char_item.AddNode("UNIT_LIST");
                //    unit_item.AddChar("VALUE_TYPE", spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL)).ToString()[0]);
                //    unit_item.AddInt("VALUE_COUNT", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)CHAR_COLUMN.VALUE_COUNT_COL)));

                //    unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM))));
                //    unit_item.AddString("UNIT_ID", spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_COL)));

                //    unit_item.AddChar("__REC_SAVE_FLAG", 'Y');

                //    i_value_count = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.SAMPLE_SIZE)));
                //    for (int j = 0; j < i_value_count; j++)
                //    {
                //        value_item = unit_item.AddNode("VALUE_LIST" );

                //        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_TYPE_COL))) == "N" &&
                //            MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j + MPCF.ToInt(CHAR_COLUMN.VALUE_START_COL))) == true)
                //        {
                //            value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)).ToString(ci_inter.NumberFormat));
                //        }
                //        else
                //        {
                //            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)) == null ? " " : MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + DEFAULT_COL_COUNT)));
                //        }

                //        value_item.SetInt("VALUE_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.VALUE_SEQ_NUM))));
                //        value_item.SetInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(CHAR_COLUMN.UNIT_SEQ_NUM))));
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 캐릭터 목록 조회
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool ViewAttachCharacterList(Control control)
        {
            return ViewAttachCharacterList(control, '1');
        }

        /// <summary>
        /// 캐릭터 목록 조회
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_proc_step"></param>
        /// <returns></returns>
        public bool ViewAttachCharacterList(Control control, char c_proc_step)
        {
            return ViewAttachCharacterList(control, c_proc_step, COL_SET_ID, COL_SET_VERSION);
        }

        /// <summary>
        /// 캐릭터 목록 조회
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_proc_step"></param>
        /// <param name="s_col_set_id"></param>
        /// <param name="i_col_set_version"></param>
        /// <returns></returns>
        public bool ViewAttachCharacterList(Control control, char c_proc_step, string s_col_set_id, int i_col_set_version)
        {
            return ViewAttachCharacterList(control, c_proc_step, s_col_set_id, i_col_set_version, string.Empty, null, 'Y');
        }

        /// <summary>
        /// 캐릭터 목록 조회
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_proc_step"></param>
        /// <param name="s_col_set_id"></param>
        /// <param name="i_col_set_version"></param>
        /// <param name="s_ext_factory"></param>
        /// <param name="tn_parent_node"></param>
        /// <param name="c_include_unit_id"></param>
        /// <returns></returns>
        public bool ViewAttachCharacterList(Control control, char c_proc_step, string s_col_set_id, int i_col_set_version, string s_ext_factory, TreeNode tn_parent_node, char c_include_unit_id)
        {


            try
            {



                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
