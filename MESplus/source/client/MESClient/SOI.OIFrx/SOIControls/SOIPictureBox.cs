using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using System.Drawing;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIPictureBox : UltraPictureBox
    {
        #region Property
        
        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        private SOIPictureBoxStyle _useLotStatusStyle = SOIPictureBoxStyle.None;
        public SOIPictureBoxStyle _UseLotStatusStyle
        {
            get
            {
                return _useLotStatusStyle;
            }
            set
            {
                _useLotStatusStyle = value;
                ChangeImage();
            }
        }

        private bool lotStatus = false;
        public bool LotStatus
        {
            get
            {
                return lotStatus;
            }
            set
            {
                lotStatus = value;
                ChangeImage();
            }
        }

        #endregion

        #region Constructor

        public SOIPictureBox()
        {
            InitializeComponent();
        }

        public SOIPictureBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            }
        }

        /// <summary>
        /// 이미지를 적용합니다.
        /// 이미지 적용시 OnPaint가 발생하므로 무한루프에 빠지지 않도록 주의가 필요합니다.
        /// </summary>
        public void ChangeImage()
        {
            if (_UseOITheme == true)
            {
                // Style
                if (_UseLotStatusStyle == SOIPictureBoxStyle.None)
                {
                    if (this.DesignMode == true)
                    {
                        //this.Image = null;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Start)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.StatusProc;
                    }
                    else
                    {
                        this.Image = Properties.Resources.StatusWait;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Hold)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.Hold;
                    }
                    else
                    {
                        this.Image = Properties.Resources.NotHold;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Rework)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.Rework;
                    }
                    else
                    {
                        this.Image = Properties.Resources.NotRework;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Repair)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.Repair;
                    }
                    else
                    {
                        this.Image = Properties.Resources.NotRepair;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Inventory)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.Inventory;
                    }
                    else
                    {
                        this.Image = Properties.Resources.NotInventory;
                    }
                }
                else if (_UseLotStatusStyle == SOIPictureBoxStyle.Transit)
                {
                    if (LotStatus == true)
                    {
                        this.Image = Properties.Resources.Transit;
                    }
                    else
                    {
                        this.Image = Properties.Resources.NotTransit;
                    }
                }
            }
        }

        #endregion
    }
}
