using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Reflection;
using Miracom.UI.Controls.MCCodeView;

namespace SOI.OIFrx
{
    public partial class ViewCmnCode : Miracom.MESCore.TranForm01
    {
        #region 변수선언

        string sViewID;
        string sParmID;
        int rowindex;
        int[] colposition;
        FarPoint.Win.Spread.SheetView fpList;
        Miracom.UI.Controls.MCCodeView.MCCodeView mCodeView;
        protected FarPoint.Win.Spread.StyleInfo _style = new StyleInfo();
        #endregion

        #region 생성자

        public ViewCmnCode()
        {
            InitializeComponent();
        }

        public ViewCmnCode(Miracom.UI.Controls.MCCodeView.MCCodeView cParamControl, string sParamViewID, string sParamID, string sCodeName)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            sParmID = sParamID;
            txtValue.Text = sParmID;
            mCodeView = cParamControl;
            ComboAddRange(sCodeName);
        }

        public ViewCmnCode(FarPoint.Win.Spread.SheetView fpSpd, string sParamViewID, string sParamID, int iRowIndex, int[] ColIndex, string sCodeName)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            txtValue.Text = sParamID;
            fpList = fpSpd;
            rowindex = iRowIndex;
            colposition = ColIndex;
            ComboAddRange(sCodeName);
        }

        #endregion

        #region 이벤트

        private void ViewCmnCode_Load(object sender, EventArgs e)
        {
            try
            {
                cboType.SelectedIndex = 0;

                if (string.IsNullOrEmpty(txtValue.Text) == false)
                {
                    btnSearch.PerformClick();
                }

                txtValue.Focus();
                txtValue.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void ViewCmnCode_Activated(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 조회 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDataAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// gcm codeview 값 초기화 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                mCodeView.Text = "";
                mCodeView.DescText = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 리프레쉬 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDataAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// mat id/ code 입력 후, 엔터 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 && string.IsNullOrEmpty(txtValue.Text) == false)
                {
                    btnSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /// <summary>
        /// 데이터 선택 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdList_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdList.ActiveSheet;     // 품목리스트

                if (mCodeView is Miracom.UI.Controls.MCCodeView.MCCodeView)     // 코드뷰
                {
                    mCodeView.Text = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CODE"].Index].Text;
                    mCodeView.DescText = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CODE_DESC"].Index].Text;
                }
                else if(fpList is FarPoint.Win.Spread.SheetView)        // 스프레드 시트
                {
                    fpList.Cells[rowindex, colposition[0]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CODE"].Index].Text;
                    fpList.Cells[rowindex, colposition[1]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CODE_DESC"].Index].Text;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 닫기 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// cell 선택 시, row에 보더 표시.(선택된 행 표시)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdList_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                int i = 0;

                // 행 선택 흔적 지우기
                for (i = 0; i < ((FpSpread)sender).Sheets[0].Rows.Count; i++)
                {
                    if (((FpSpread)sender).Sheets[0].Rows[i].Border != _style.Border)
                    {
                        ((FpSpread)sender).Sheets[0].Rows[i].Border = _style.Border;
                        break;
                    }
                }

                // 행 선택
                FarPoint.Win.Spread.Row row;
                FarPoint.Win.BevelBorder bord = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered, Color.Black, Color.Black, 1, false, true, false, true);
                row = ((FpSpread)sender).Sheets[0].Rows[e.Row];
                row.Border = bord;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region user function

        private void ComboAddRange(string sCodeName)
        {
            try
            {
                if (sCodeName == "VENDOR")
                {
                    cboType.Items.AddRange(new object[] { "Vendoer Code", "Vendor Desc" });
                }
                else if (sCodeName == "CUST")
                {
                    cboType.Items.AddRange(new object[] { "Cust Code", "Cust Desc" });
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 조회 로직
        /// </summary>
        /// <returns></returns>
        private void ViewDataAll()
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdList.ActiveSheet;     // 품목리스트

                with_1.RowCount = 0;

                DataTable _dt = new DataTable();
                MPOF.DViewCond[] sCond = new MPOF.DViewCond[3];

                sCond[0].sCondtion_ID = "FACTORY";
                sCond[0].sCondition_Value = MPGV.gsFactory;

                if (cboType.SelectedIndex == 0)
                {
                    sCond[1].sCondtion_ID = "CMN_CODE";
                    sCond[1].sCondition_Value = MPCF.Trim(txtValue.Text);
                    sCond[2].sCondtion_ID = "CODE_DESC";
                    sCond[2].sCondition_Value = "";
                }
                else
                {
                    sCond[1].sCondtion_ID = "CMN_CODE";
                    sCond[1].sCondition_Value = "";
                    sCond[2].sCondtion_ID = "CODE_DESC";
                    sCond[2].sCondition_Value = MPCF.Trim(txtValue.Text);
                }

                _dt = MPOF.DGetData(sViewID, sCond);

                if (_dt.Rows.Count == 0)
                {
                    return;
                }

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    int LastRow;

                    spdList.Sheets[0].RowCount++;
                    LastRow = spdList.Sheets[0].RowCount - 1;

                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["CODE"].Index].Value = _dt.Rows[i]["CMN_CODE"].ToString();
                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["CODE_DESC"].Index].Value = _dt.Rows[i]["CODE_DESC"].ToString();
                }

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        #endregion


    }
}
