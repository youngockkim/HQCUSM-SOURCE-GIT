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
    public partial class ViewMatCode : Miracom.MESCore.TranForm01
    {
        #region 변수선언

        string sViewID;
        string sMatID;
        string sMatType;
        bool bFlag;
        int rowindex;
        int[] colposition;
        FarPoint.Win.Spread.SheetView fpList;
        Miracom.UI.Controls.MCCodeView.MCCodeView mCodeView;
        Miracom.MESCore.Controls.udcMaterial uDcControl;
        protected FarPoint.Win.Spread.StyleInfo _style = new StyleInfo();
        #endregion

        #region 생성자

        public ViewMatCode()
        {
            InitializeComponent();
        }

        public ViewMatCode(Miracom.UI.Controls.MCCodeView.MCCodeView cParamControl, string sParamViewID, string sParamMatID, string sParamMatType)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            sMatID = sParamMatID;
            sMatType = sParamMatType;
            txtValue.Text = sMatID;
            mCodeView = cParamControl;
        }

        public ViewMatCode(Miracom.MESCore.Controls.udcMaterial cParamControl, string sParamViewID, string sParamMatID, string sParamMatType)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            sMatID = sParamMatID;
            sMatType = sParamMatType;
            txtValue.Text = sMatID;
            uDcControl = cParamControl;
        }

        public ViewMatCode(FarPoint.Win.Spread.SheetView fpSpd, string sParamViewID, string sParamMatID, string sParamMatType, int iRowIndex, int[] ColIndex)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            sMatID = sParamMatID;
            txtValue.Text = sMatID;
            fpList = fpSpd;
            rowindex = iRowIndex;
            colposition = ColIndex;
        }

        public ViewMatCode(Miracom.UI.Controls.MCCodeView.MCCodeView cParamControl, string sParamViewID, string sParamMatID, string sParamMatType, bool bChildFlag)
        {
            InitializeComponent();

            sViewID = sParamViewID;
            sMatID = sParamMatID;
            sMatType = sParamMatType;
            txtValue.Text = sMatID;
            mCodeView = cParamControl;
            bFlag = bChildFlag;
        }

        #endregion

        #region 이벤트
        /// <summary>
        /// form load 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ViewMatCode_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cboType.SelectedIndex = 0;

        //        if (string.IsNullOrEmpty(txtValue.Text) == false)
        //        {
        //            btnSearch.PerformClick();
        //        }

        //        txtValue.Focus();
        //        txtValue.SelectAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //    }
        //}

        private void ViewMatCode_Activated(object sender, EventArgs e)
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
                    mCodeView.Text = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_ID"].Index].Text;
                    mCodeView.DescText = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_DESC"].Index].Text;
                }
                else if(fpList is FarPoint.Win.Spread.SheetView)        // 스프레드 시트
                {
                    fpList.Cells[rowindex, colposition[0]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_ID"].Index].Text;
                    fpList.Cells[rowindex, colposition[1]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_DESC"].Index].Text;
                    fpList.Cells[rowindex, colposition[2]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CUST_MAT_ID"].Index].Text;
                    fpList.Cells[rowindex, colposition[3]].Value = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["CUST_MAT_DESC"].Index].Text;
                }
                else if (uDcControl is Miracom.MESCore.Controls.udcMaterial)        // 코어 품목 코드뷰(버전포함)
                {
                    uDcControl.Text = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_ID"].Index].Text;
                    //uDcControl.DescText = with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_DESC"].Index].Text;
                    uDcControl.Version = MPCF.ToInt(with_1.Cells[e.Row, with_1.ColumnHeader.Columns["MAT_VER"].Index].Text);
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
                MPOF.DViewCond[] sCond = new MPOF.DViewCond[4];

                sCond[0].sCondtion_ID = "FACTORY";
                sCond[0].sCondition_Value = MPGV.gsFactory;

                if (cboType.SelectedIndex == 0)
                {
                    sCond[1].sCondtion_ID = "MAT_ID";
                    sCond[1].sCondition_Value = MPCF.Trim(txtValue.Text);
                    sCond[2].sCondtion_ID = "MAT_DESC";
                    sCond[2].sCondition_Value = "";
                    sCond[3].sCondtion_ID = "MAT_TYPE";
                    sCond[3].sCondition_Value = MPCF.Trim(sMatType);

                }
                else if (bFlag == true)
                {
                    sCond[1].sCondtion_ID = "MAT_ID";
                    sCond[1].sCondition_Value = MPCF.Trim(txtValue.Text);
                    sCond[2].sCondtion_ID = "MAT_DESC";
                    sCond[2].sCondition_Value = "";
                    sCond[3].sCondtion_ID = "MAT_TYPE";
                    sCond[3].sCondition_Value = MPCF.Trim(sMatType);

                }
                else
                {
                    sCond[1].sCondtion_ID = "MAT_ID";
                    sCond[1].sCondition_Value = "";
                    sCond[2].sCondtion_ID = "MAT_DESC";
                    sCond[2].sCondition_Value = MPCF.Trim(txtValue.Text);
                    sCond[3].sCondtion_ID = "MAT_TYPE";
                    sCond[3].sCondition_Value = MPCF.Trim(sMatType);
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

                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["MAT_ID"].Index].Value = _dt.Rows[i]["MAT_ID"].ToString();
                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["MAT_DESC"].Index].Value = _dt.Rows[i]["MAT_DESC"].ToString();
                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["MAT_VER"].Index].Value = _dt.Rows[i]["MAT_VER"].ToString();
                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["CUST_MAT_ID"].Index].Value = _dt.Rows[i]["CUST_MAT_ID"].ToString();
                    with_1.Cells[LastRow, with_1.ColumnHeader.Columns["CUST_MAT_DESC"].Index].Value = _dt.Rows[i]["CUST_MAT_DESC"].ToString();
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
