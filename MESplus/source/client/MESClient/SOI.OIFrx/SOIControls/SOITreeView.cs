using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTree;
using SOI.OIFrx.SOIControls;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOITreeView : UltraTree
    {
        #region Property

        private NoFocusRect noFocusRect = new NoFocusRect();        

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

        #endregion

        #region Constructor

        public SOITreeView()
        {
            InitializeComponent();

            this.Override.ItemHeight = 40;
        }

        public SOITreeView(IContainer container)
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
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //this.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                this.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                this.FullRowSelect = true;
                this.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
                this.DrawFilter = noFocusRect;

                // 색상
                this.Appearance.BackColor = MOGV.gTheme.TreeViewBackground;                
                this.Appearance.ForeColor = MOGV.gTheme.TreeViewForeground;
                this.NodeConnectorColor = MOGV.gTheme.TreeViewLineForeground;
                this.Override.HotTrackingNodeAppearance.BackColor = MOGV.gTheme.TreeViewLineForeground;
                this.ScrollBarLook.ThumbAppearance.BackColor = MOGV.gTheme.TreeViewScrollThumbBackground;
            }
        }

        #endregion        
    }
}
