using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.CliFrx.SOIModel;
using SOI.OIFrx;

namespace StandardOI
{
    public partial class frmAlarmMessage : Form
    {
        #region Property

        private bool bFadeIn = false;
        private bool bFadeOut = false;
        private bool bIsClosing = false;

        private int iCloseCount = 0;
        private int iFadeInterval = 50;
        private int iCloseInterval = 100;
        private int iAlarmFormID = 0;

        private double iShowCount = 0;

        #endregion

        #region Constructor
        
        public frmAlarmMessage()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면 로드 시 불투명도를 0으로 조절합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAlarmMessage_Load(object sender, EventArgs e)
        {
            // Fade In 설정
            bFadeIn = true;
            this.Opacity = 0;

            // Alarm Position 설정
            SetAlarmPosition(true);

            // Timer 설정
            tmrAlarm.Interval = iFadeInterval;
            tmrAlarm.Start();
        }

        /// <summary>
        /// 화면이 닫힐 때 타이머를 해제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAlarmMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tmrAlarm != null)
            {
                tmrAlarm.Stop();
                tmrAlarm.Dispose();
            }

            SetAlarmPosition(false);

            MPCF.SetShowAlarmCountDecrease();

            MPCF.FlushMemory();
        }

        /// <summary>
        /// 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 화면을 닫는 Timer 입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrClose_Tick(object sender, EventArgs e)
        {
            // 대기 상태인 경우
            if(bFadeIn == false
                && bIsClosing == false
                && bFadeOut == false)
            {
                if (MPCF.GetFourthAlarm() == false)
                {
                    this.iAlarmFormID--;

                    if (iAlarmFormID == 4)
                    {
                        bFadeIn = true;
                        MPCF.SetFourthAlarm(true);
                    }
                }
            }
            // Fade In 상태인 경우
            else if (bFadeIn == true)
            {
                // Fade In 완료한 경우
                if (iShowCount >= 5)
                {
                    bFadeIn = false;
                    tmrAlarm.Stop();
                    tmrAlarm.Interval = iCloseInterval;
                    tmrAlarm.Start();                    
                    bIsClosing = true;
                }
                // Fade In인 경우
                else
                {
                    iShowCount++;
                    this.Opacity = ((iShowCount * 20) / 100);                    
                    this.Update();
                }
            }
            // Close 중인 경우
            else if (bIsClosing == true)
            {
                MovePosition();

                // 3초
                if (iCloseCount >= 30)
                {
                    bIsClosing = false;                    
                    tmrAlarm.Stop();
                    tmrAlarm.Interval = iFadeInterval;
                    tmrAlarm.Start();
                    bFadeOut = true;
                    iShowCount = 0;
                }
                else
                {
                    iCloseCount++;
                }            
            }
            // Fade Out 상태인 경우
            else if (bFadeOut == true)
            {
                // Fade Out 완료한 경우
                if (iShowCount >= 5)
                {
                    tmrAlarm.Stop();
                    this.Close();
                }
                // Fade Out 중인 경우
                else
                {
                    iShowCount++;
                    this.Opacity = 1 - ((iShowCount*20) / 100);
                    this.Update();                    
                }
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Alarm을 추가합니다.
        /// </summary>
        /// <param name="message"></param>
        public void AddAlarm(AlarmMessage message)
        {
            //message.UniqueId = iUniqueID++;

            // Alarm Subject
            this.lblTitle.Text = message.AlarmSubject;

            // Alarm Message
            this.lblMessage.Text = message.AlarmMsg;

            // Alarm Level
            if (message.AlarmLevel == 'I')
            {
                this.BackColor = MPGV.gTheme.AlarmMessageFormBackgroundInfo;
            }
            else if (message.AlarmLevel == 'W')
            {
                this.BackColor = MPGV.gTheme.AlarmMessageFormBackgroundWarn;
            }
            else if (message.AlarmLevel == 'E')
            {
                this.BackColor = MPGV.gTheme.AlarmMessageFormBackgroundError;
            }
            else
            {
                this.BackColor = MPGV.gTheme.AlarmMessageFormBackgroundInfo;
            }

            tmrAlarm.Start();
        }

        /// <summary>
        /// Alarm Message Form에 ID를 할당합니다.
        /// </summary>
        /// <param name="i"></param>
        public void SetAlarmFormID(int i)
        {
            this.iAlarmFormID = i;
        }

        /// <summary>
        /// 현재 Alarm 메시지 화면의 위치를 재조정합니다.
        /// </summary>
        public void MovePosition()
        {
            // 1번인 경우
            if (iAlarmFormID == 1)
            {
                // No action
            }
            // 2번인 경우
            else if (iAlarmFormID == 2)
            {
                if (MPCF.GetFirstAlarm() == false)
                {
                    iAlarmFormID = 1;
                    this.Top = this.Top + this.Height + 10;
                    MPCF.SetFirstAlarm(true);
                    MPCF.SetSecondAlarm(false);
                }
            }
            // 3번인 경우
            else if (iAlarmFormID == 3)
            {
                if (MPCF.GetSecondAlarm() == false)
                {
                    iAlarmFormID = 2;
                    this.Top = this.Top + this.Height + 10;
                    MPCF.SetSecondAlarm(true);
                    MPCF.SetThirdAlarm(false);
                }
            }
            // 4번인 경우
            else if (iAlarmFormID == 4)
            {
                if (MPCF.GetThirdAlarm() == false)
                {
                    iAlarmFormID = 3;
                    this.Top = this.Top + this.Height + 10;
                    MPCF.SetThirdAlarm(true);
                    MPCF.SetFourthAlarm(false);
                }
            }
        }

        /// <summary>
        /// Alarm Position을 재설정해 줍니다.
        /// </summary>
        public void SetAlarmPosition(bool bRegisterFlag)
        {
            // 1번인 경우
            if (iAlarmFormID == 1)
            {
                MPCF.SetFirstAlarm(bRegisterFlag);
            }
            // 2번인 경우
            else if (iAlarmFormID == 2)
            {
                MPCF.SetSecondAlarm(bRegisterFlag);
            }
            // 3번인 경우
            else if (iAlarmFormID == 3)
            {
                MPCF.SetThirdAlarm(bRegisterFlag);
            }
            // 4번인 경우
            else if (iAlarmFormID == 4)
            {
                MPCF.SetFourthAlarm(bRegisterFlag);
            }
            // 4번 이상인 경우
            else
            {
                bFadeIn = false;
            }
        }

        #endregion
    }
}
