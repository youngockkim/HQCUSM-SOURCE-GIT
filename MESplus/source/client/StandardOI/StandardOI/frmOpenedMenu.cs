using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.OIFrx.SOIBaseForm;

namespace StandardOI
{
    public partial class frmOpenedMenu : Form
    {
        #region Property

        private bool bIsShown = false;

        // 우.하단
        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // if click outside dialog -> Close Dlg
            if (m.Msg == 0x0086) //0x86
            {
                // 보이고 화면이 로드완료된 이후에만
                if (this.Visible
                    && this.bIsShown == true)
                {
                    // 화면 바깥에서 커서가 있는 경우
                    if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
                    {
                        // 화면 닫기
                        this.Close();
                    }
                }
            }
        }

        #endregion

        #region Constructor

        public frmOpenedMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(true);
            }
            return base.ShowDialog();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOpenedMenu_Load(object sender, EventArgs e)
        {
            // Opened List Init
            lbOpenedFormList.InitDataSource();

            // Theme 변환
            SetOITheme();

            if (AddOpenedFormList() == false)
            {
                this.Close();
            }

            MPCF.ConvertCaption(this);

            // 화면이 숨겨지므로 강제 Activation
            this.Activate();
        }

        /// <summary>
        /// Form Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOpenedMenu_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;
            }
        }

        /// <summary>
        /// Form Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOpenedMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(false);
            }

            if (this.Owner != null)
            {
                Owner.Activate();
            }
        }

        /// <summary>
        /// Close Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Form Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbOpenedFormList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            Control cFocusControl;

            try
            {
                if (lbOpenedFormList.Selected.Rows.Count > 0)
                {
                    selectedMenuInfo = (MenuInfoTag)lbOpenedFormList.Selected.Rows[0].Tag;

                    cFocusControl = MPGV.gIMdiForm.OpenMenu(selectedMenuInfo);
                    if (cFocusControl != null)
                    {
                        cFocusControl.Focus();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Theme를 로드합니다.
        /// </summary>
        private void SetOITheme()
        {
            MPCF.LoadControlTheme(this);
            this.BackColor = MPGV.gTheme.OpenedMenuFormBacgkround;
        }

        /// <summary>
        /// ListView에 즐겨찾기 화면 목록을 Bind합니다.
        /// </summary>
        public bool AddOpenedFormList()
        {
            int iRowCount;
            MenuInfoTag menuInfo;
            UltraGridRow ugrRow;

            try
            {
                // Get List
                if (MPGV.glOpenChildForm.Count < 1)
                {
                    return false;
                }

                iRowCount = 0;
                foreach (Form childForm in MPGV.glOpenChildForm)
                {
                    if (childForm is SOIDefaultBackgroundForm)
                    {
                        continue;
                    }

                    menuInfo = (MenuInfoTag)childForm.Tag;
                    ugrRow = lbOpenedFormList.DisplayLayout.Bands[0].AddNew();
                    if (string.IsNullOrEmpty(menuInfo.s_func_name) == true)
                    {
                        ugrRow.Cells[0].Value = MPCF.FindLanguage(menuInfo.s_func_desc);
                    }
                    else
                    {
                        ugrRow.Cells[0].Value = menuInfo.s_func_name + " : " + MPCF.FindLanguage(menuInfo.s_func_desc);
                    }                    
                    ugrRow.Tag = menuInfo;

                    iRowCount++;
                }

                // 최대 5개
                if(iRowCount < 6)
                {
                    this.Height = 4 + (53*iRowCount);
                }
                else
                {
                    this.Height = 4 + (53*5);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
