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
    public partial class frmViewAlarmPublishMessage : SOIBaseForm01
    {
        #region Contructor

        public frmViewAlarmPublishMessage()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Alarm Message 화면을 로드합니다.
        /// 데이터를 바인드 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmViewAlarmPublishMessage_Load(object sender, EventArgs e)
        {
            BindAlarmMessage();

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// Alarm Spread에서 셀 클릭 시 발생합니다.
        /// Image Button을 처리합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdAlarmMessage_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // Image Column인 경우
                if (e.Column == spdAlarmMessage.Sheets[0].Columns[6].Index)
                {
                    if (spdAlarmMessage.Sheets[0].Cells[e.Row, e.Column].Tag == null)
                    {
                        return;
                    }

                    MPCF.RunImageViewer(MPCF.ByteArrayToImage((byte[])(spdAlarmMessage.Sheets[0].Cells[e.Row, e.Column].Tag)));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Acknowledge 버튼 클릭 시 발생합니다.
        /// 선택된 알람 이력을 지웁니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdAlarmMessage.Sheets[0].Rows.Count - 1; i >= 0; i--)
                {
                    if (spdAlarmMessage.Sheets[0].Cells[i, 0].Value == null)
                    {
                        continue;
                    }

                    if ((bool)spdAlarmMessage.Sheets[0].Cells[i, 0].Value == true)
                    {
                        spdAlarmMessage.Sheets[0].Rows[i].Remove();
                        MPGV.gtAlarmList.RemoveAt(i);
                        MPGV.gIMdiForm.SetDecreaseAlarmCount();
                    }
                }

                BindAlarmMessage();
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Select All 선택 시, 모든 Row를 체크합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdAlarmMessage.Sheets[0].Rows.Count > 0)
                {
                    for (int i = 0; i < spdAlarmMessage.Sheets[0].Rows.Count; i++)
                    {
                        spdAlarmMessage.Sheets[0].Cells[i, 0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Release All 선택 시, 모든 Row를 체크해제 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReleaseAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdAlarmMessage.Sheets[0].Rows.Count > 0)
                {
                    for (int i = 0; i < spdAlarmMessage.Sheets[0].Rows.Count; i++)
                    {
                        spdAlarmMessage.Sheets[0].Cells[i, 0].Value = false;
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
        private void BindAlarmMessage()
        {
            int iRow;

            try
            {
                // 모든 Row 제거
                spdAlarmMessage.Sheets[0].Rows.Clear();

                // Error Message Bind
                if (MPGV.gtAlarmList.Count > 0)
                {
                    for (int i = 0; i < MPGV.gtAlarmList.Count; i++)
                    {
                        iRow = spdAlarmMessage.Sheets[0].RowCount;
                        spdAlarmMessage.Sheets[0].RowCount++;
                        
                        spdAlarmMessage.Sheets[0].Cells[iRow, 1].Value = MPCF.Trim(MPGV.gtAlarmList[i].AlarmLevel);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 2].Value = MPCF.Trim(MPGV.gtAlarmList[i].AlarmType);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 3].Value = MPCF.Trim(MPGV.gtAlarmList[i].AlarmId);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 4].Value = MPCF.Trim(MPGV.gtAlarmList[i].AlarmSubject);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(MPGV.gtAlarmList[i].AlarmMsg);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 6].Tag = MPGV.gtAlarmList[i].ImgData;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 7].Value = MPCF.MakeDateFormat(MPCF.Trim(MPGV.gtAlarmList[i].CreateTime), SOI.CliFrx.DATE_TIME_FORMAT.DATETIME);                        
                        spdAlarmMessage.Sheets[0].Cells[iRow, 8].Value = MPCF.Trim(MPGV.gtAlarmList[i].LotId);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 9].Value = MPCF.Trim(MPGV.gtAlarmList[i].ResId);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 10].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceId1);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 11].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceDesc1);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 12].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceId2);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 13].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceDesc2);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 14].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceId3);
                        spdAlarmMessage.Sheets[0].Cells[iRow, 15].Value = MPCF.Trim(MPGV.gtAlarmList[i].SourceDesc3);

                        spdAlarmMessage.Sheets[0].Cells[iRow, 1].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 2].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 3].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 4].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 5].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 6].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 7].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 8].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 9].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 10].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 11].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 12].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 13].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 14].Locked = true;
                        spdAlarmMessage.Sheets[0].Cells[iRow, 15].Locked = true;

                        if (spdAlarmMessage.Sheets[0].Cells[iRow, 6].Tag != null)
                        {
                            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType = MPCF.GetSpreadButtonCellType();
                            btnCellType.Picture = Properties.Resources.Search_s;
                            spdAlarmMessage.Sheets[0].Cells[iRow, 6].CellType = btnCellType;                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return;
            }
        }

        #endregion
    }
}
