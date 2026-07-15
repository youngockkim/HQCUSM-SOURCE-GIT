using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIPanel : Panel
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

        private SOIPanelStyle _useStyle = SOIPanelStyle.TransparentStyle;
        public SOIPanelStyle _UseStyle
        {
            get
            {
                return _useStyle;
            }
            set
            {
                _useStyle = value;
                SetOITheme();
            }
        }

        #endregion

        #region Constructor

        public SOIPanel()
        {
            InitializeComponent();
        }

        public SOIPanel(IContainer container)
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
                // 공통 속성

                // 공통 색상                

                // Transparent인 경우
                if (_UseStyle == SOIPanelStyle.TransparentStyle)
                {
                    this.BackColor = MOGV.gTheme.PanelBackground;
                }
                // TabControl의 Border로 사용되는 경우
                else if (_UseStyle == SOIPanelStyle.TabControlBorderStyle)
                {
                    this.BackColor = MOGV.gTheme.TabControlBorder;
                }
            }
        }

        #endregion
    }
}
