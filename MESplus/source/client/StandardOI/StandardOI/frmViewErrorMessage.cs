using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;

namespace StandardOI
{
    public partial class frmViewErrorMessage : SOIBaseForm01
    {
        #region Constructor
        
        public frmViewErrorMessage()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면을 로드할 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmViewErrorMessage_Load(object sender, EventArgs e)
        {
            BindErrorMessage();

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// 스프레드에서 Error Message 선택 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdErrorList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            // Column  Header인 경우는 제외
            if (e.ColumnHeader == false)
            {
                BindFieldMessage(e.Row);
            }
        }

        /// <summary>
        /// Delete 버튼 클릭 시, 선택된 에러메시지를 삭제하고 다시 로드합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdErrorList.Sheets[0].Rows.Count - 1; i >= 0; i--)
                {
                    if (spdErrorList.Sheets[0].Cells[i, 0].Value == null)
                    {
                        continue;
                    }

                    if ((bool)spdErrorList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        spdErrorList.Sheets[0].Rows[i].Remove();
                        MPGV.glErrorMessageList.RemoveAt(i);
                    }
                }

                BindErrorMessage();
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Select All 선택 시, Error List의 모든 Row를 체크합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdErrorList.Sheets[0].Rows.Count > 0)
                {
                    for (int i = 0; i < spdErrorList.Sheets[0].Rows.Count; i++)
                    {
                        spdErrorList.Sheets[0].Cells[i, 0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Release All 선택 시, Error List의 모든 Row를 체크해제 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReleaseAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdErrorList.Sheets[0].Rows.Count > 0)
                {
                    for (int i = 0; i < spdErrorList.Sheets[0].Rows.Count; i++)
                    {
                        spdErrorList.Sheets[0].Cells[i, 0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Error Message를 Bind 합니다.
        /// </summary>
        private void BindErrorMessage()
        {
            int iRow;

            try
            {
                // 모든 Row 제거
                spdErrorList.Sheets[0].Rows.Clear();
                spdFieldMessage.Sheets[0].Rows.Clear();

                // Error Message Bind
                if (MPGV.glErrorMessageList.Count > 0)
                {
                    for (int i = 0; i < MPGV.glErrorMessageList.Count; i++)
                    {
                        iRow = spdErrorList.Sheets[0].RowCount;
                        spdErrorList.Sheets[0].RowCount++;

                        spdErrorList.Sheets[0].Cells[iRow, 1].Value = MPCF.Trim(MPGV.glErrorMessageList[i].MsgCode);
                        spdErrorList.Sheets[0].Cells[iRow, 2].Value = MPCF.Trim(MPGV.glErrorMessageList[i].MsgCate);
                        spdErrorList.Sheets[0].Cells[iRow, 3].Value = MPCF.Trim(MPGV.glErrorMessageList[i].ErrorMsg);
                        spdErrorList.Sheets[0].Cells[iRow, 4].Value = MPCF.Trim(MPGV.glErrorMessageList[i].IssueDate);

                        spdErrorList.Sheets[0].Cells[iRow, 1].Locked = true;
                        spdErrorList.Sheets[0].Cells[iRow, 2].Locked = true;
                        spdErrorList.Sheets[0].Cells[iRow, 3].Locked = true;
                        spdErrorList.Sheets[0].Cells[iRow, 4].Locked = true;
                    }

                    spdErrorList.Sheets[0].ActiveRowIndex = 0;

                    BindFieldMessage(0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 하단 스프레드에 선택된 Field Message를 Bind 합니다.
        /// </summary>
        private void BindFieldMessage(int iSelectedRow)
        {
            int iRow;

            try
            {
                // 모든 Row 제거
                spdFieldMessage.Sheets[0].Rows.Clear();

                if (MPGV.glErrorMessageList[iSelectedRow].FieldMsg == null)
                {
                    return;
                }

                // Field Message Bind
                if (MPGV.glErrorMessageList[iSelectedRow].FieldMsg.Count > 0)
                {
                    for (int i = 0; i < MPGV.glErrorMessageList[iSelectedRow].FieldMsg.Count; i++)
                    {
                        iRow = spdFieldMessage.Sheets[0].RowCount;
                        spdFieldMessage.Sheets[0].RowCount++;

                        spdFieldMessage.Sheets[0].Cells[iRow, 0].Value = MPCF.Trim(MPGV.glErrorMessageList[iSelectedRow].FieldMsg[i].Name);
                        spdFieldMessage.Sheets[0].Cells[iRow, 1].Value = MPCF.Trim(MPGV.glErrorMessageList[iSelectedRow].FieldMsg[i].Text);
                        spdFieldMessage.Sheets[0].Cells[iRow, 2].Value = MPCF.Trim(MPGV.glErrorMessageList[iSelectedRow].FieldMsg[i].Type);
                    }

                    lblDbErrMsg.Text = MPCF.Trim(MPGV.glErrorMessageList[iSelectedRow].DBErrorMsg);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        #endregion
    }
}
