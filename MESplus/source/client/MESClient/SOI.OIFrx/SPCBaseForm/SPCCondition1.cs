using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public partial class SPCCondition1 : UserControl
    {
        public SPCCondition1()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum DATE_TYPE : int
        {
            COL_YEAR = 0,
            COL_YEAR_MM,
            COL_YEAR_MM_DD,
            COL_FROM_TO_DATE
        }

        public enum POPUP_TYPE : int
        {
            COL_TYPE_1 = 1,
            COL_TYPE_2,
            COL_TYPE_3
        }

        #endregion

        #region " Variable Definition "

        public string SELECT_LINE_CODE { get; set; }
        public string SELECT_LINE_DESC { get; set; }
        public string SELECT_SHOP_CODE { get; set; }
        public string SELECT_SHOP_DESC { get; set; }
        public string SELECT_CAR_TYPE { get; set; }
        public string SELECT_CAR_TYPE_DESC { get; set; }
        public string SELECT_MAT_ID { get; set; }
        public string SELECT_MAT_DESC { get; set; }
        public string SELECT_RES_ID { get; set; }
        public string SELECT_RES_DESC { get; set; }
        public string SELECT_CHAR_ID { get; set; }
        public string SELECT_CHAR_DESC { get; set; }
        public string SELECT_UPPER_SPEC_LIMIT { get; set; }
        public string SELECT_UPPER_WARN_LIMIT { get; set; }
        public string SELECT_TARGET_VALUE { get; set; }
        public string SELECT_LOWER_WARN_LIMIT { get; set; }
        public string SELECT_LOWER_SPEC_LIMIT { get; set; }
        public int SELECT_POPUP_TYPE { get; set; }
        public int SELECT_DATE_TYPE { get; set; }

        public SOI.OIFrx.SOIControls.SOIButton BTN_EXCEL { get { return btnExcel; } }
        public SOI.OIFrx.SOIControls.SOIButton BTN_VIEW { get { return btnView; } }
        public SOI.OIFrx.SOIControls.SOIButton BTN_CLOSE { get { return btnClose; } }

        #endregion

        #region " Function Definition "

        /// <summary>
        /// 이벤트 핸들러
        /// </summary>
        private void EventHandler()
        {
            try
            {
                #region " Button Event "
                btnCondition.Click += new System.EventHandler(btnCondition_Click);
                #endregion
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 초기화
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            try
            {
                SELECT_LINE_CODE = string.Empty;
                SELECT_LINE_DESC = string.Empty;
                SELECT_SHOP_CODE = string.Empty;
                SELECT_SHOP_DESC = string.Empty;
                SELECT_CAR_TYPE = string.Empty;
                SELECT_CAR_TYPE_DESC = string.Empty;
                SELECT_MAT_ID = string.Empty;
                SELECT_MAT_DESC = string.Empty;
                SELECT_RES_ID = string.Empty;
                SELECT_RES_DESC = string.Empty;
                SELECT_CHAR_ID = string.Empty;
                SELECT_CHAR_DESC = string.Empty;
                SELECT_UPPER_SPEC_LIMIT = string.Empty;
                SELECT_UPPER_WARN_LIMIT = string.Empty;
                SELECT_TARGET_VALUE = string.Empty;
                SELECT_LOWER_WARN_LIMIT = string.Empty;
                SELECT_LOWER_SPEC_LIMIT = string.Empty;

                txtLineDesc.Text = string.Empty;
                txtShopDesc.Text = string.Empty;
                txtCharDesc.Text = string.Empty;
                txtCarTypeDesc.Text = string.Empty;
                txtResDesc.Text = string.Empty;
                txtSpec.Text = string.Empty;
                txtWarnSpec.Text = string.Empty;
                txtMatDesc.Text = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 날짜 유형 변경
        /// </summary>
        /// <returns></returns>
        public bool DateTypeInit()
        {
            try
            {
                if (SELECT_DATE_TYPE == (int)DATE_TYPE.COL_YEAR)
                {
                    tblDate2.Visible = false;
                    tblDate1.Visible = true;
                    dtpDate.FormatPattern = SOIDateTimeFormat.DATE_SHORT_YYYY;
                }
                else if (SELECT_DATE_TYPE == (int)DATE_TYPE.COL_YEAR_MM)
                {
                    tblDate2.Visible = false;
                    tblDate1.Visible = true;
                    dtpDate.FormatPattern = SOIDateTimeFormat.DATE_SHORT_YYYY_MM;
                }
                else if (SELECT_DATE_TYPE == (int)DATE_TYPE.COL_YEAR_MM_DD)
                {
                    tblDate2.Visible = false;
                    tblDate1.Visible = true;
                    dtpDate.FormatPattern = SOIDateTimeFormat.DATE_SHORT;
                }
                else if (SELECT_DATE_TYPE == (int)DATE_TYPE.COL_FROM_TO_DATE)
                {
                    tblDate2.Visible = true;
                    tblDate1.Visible = false;
                    dtpDate.FormatPattern = SOIDateTimeFormat.DATE_SHORT;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                EventHandler();
                if (DateTypeInit() == false) return;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        public string DateText()
        {
            return dtpDate.Text.Replace("-", "");
        }

        public string FromDate()
        {
            return udcFromToDate.FromDate;
        }

        public string ToDate()
        {
            return udcFromToDate.ToDate;
        }

        private void btnCondition_Click(object sender, EventArgs e)
        {
            if (Init() == false) return;

            SPCPopupCondition1 popup = new SPCPopupCondition1();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.TYPE = SELECT_POPUP_TYPE;
            popup.ShowDialog();

            if (popup.DialogResult == DialogResult.OK)
            {
                SELECT_LINE_CODE = popup.SELECT_LINE_CODE;
                SELECT_LINE_DESC = popup.SELECT_LINE_DESC;
                SELECT_SHOP_CODE = popup.SELECT_SHOP_CODE;
                SELECT_SHOP_DESC = popup.SELECT_SHOP_DESC;
                SELECT_CAR_TYPE = popup.SELECT_CAR_TYPE;
                SELECT_CAR_TYPE_DESC = popup.SELECT_CAR_TYPE_DESC;
                SELECT_MAT_ID = popup.SELECT_MAT_ID;
                SELECT_MAT_DESC = popup.SELECT_MAT_DESC;
                SELECT_RES_ID = popup.SELECT_RES_ID;
                SELECT_RES_DESC = popup.SELECT_RES_DESC;
                SELECT_CHAR_ID = popup.SELECT_CHAR_ID;
                SELECT_CHAR_DESC = popup.SELECT_CHAR_DESC;
                SELECT_UPPER_SPEC_LIMIT = popup.SELECT_UPPER_SPEC_LIMIT;
                SELECT_UPPER_WARN_LIMIT = popup.SELECT_UPPER_WARN_LIMIT;
                SELECT_TARGET_VALUE = popup.SELECT_TARGET_VALUE;
                SELECT_LOWER_WARN_LIMIT = popup.SELECT_LOWER_WARN_LIMIT;
                SELECT_LOWER_SPEC_LIMIT = popup.SELECT_LOWER_SPEC_LIMIT;

                txtLineDesc.Text = SELECT_SHOP_DESC;
                txtShopDesc.Text = SELECT_LINE_DESC;
                txtCarTypeDesc.Text = SELECT_CAR_TYPE_DESC;
                txtCharDesc.Text = SELECT_CHAR_DESC;
                txtMatDesc.Text = SELECT_MAT_DESC;
                txtResDesc.Text = SELECT_RES_DESC;
                txtSpec.Text = SELECT_TARGET_VALUE + "  " + SELECT_UPPER_SPEC_LIMIT + " / " + SELECT_LOWER_SPEC_LIMIT;
                txtWarnSpec.Text = SELECT_TARGET_VALUE + "  " + SELECT_UPPER_WARN_LIMIT + " / " + SELECT_LOWER_WARN_LIMIT;
            }
        }

        private void btnCondition_Click_1(object sender, EventArgs e)
        {

        }
    }
}
