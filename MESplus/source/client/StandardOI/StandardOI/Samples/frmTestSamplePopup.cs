using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using StandardOI.Samples.SamplePopups;

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSamplePopup : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSamplePopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// 일반적인 팝업창 호출 방식입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNormalPopup_Click(object sender, EventArgs e)
        {
            try
            {
                frmTestSampleFuncAsPopup frm = new frmTestSampleFuncAsPopup();
                frm.Owner = MPGV.gfrmMDI;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// frmMain과 동일한 크기의 팝업창을 호출합니다.
        /// 이동은 불가능합니다.
        /// 메인화면 하단의 에러메시지는 보이지만, "에러메시지 상세조회"화면으로 이동은 불가능합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaxPopup_Click(object sender, EventArgs e)
        {
            try
            {
                frmTestSampleFuncAsPopup frm = new frmTestSampleFuncAsPopup();
                frm.Owner = MPGV.gfrmMDI;
                frm._SOIPopupShowStyle = SOIPopupShowStyle.Maximized;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Popup 화면을 일반화면처럼 띄웁니다. ShowDialog 형태가 아닌, 일반화면과 동일하게 동작합니다.
        /// ShowDialog가 아니므로 frmMain 화면에 귀속이 없습니다. 따라서, 에러메시지 상세조회를 포함해 
        ///   frmMain의 기능(화면확대, 이동, 축소) 등을 사용할 수 있습니다.
        /// 다만, 서버에 등록된 화면이 아니므로 메뉴에서 실행할수는 없습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPopupAsFunc_Click(object sender, EventArgs e)
        {
            try
            {
                frmTestSampleFuncAsPopup frm = new frmTestSampleFuncAsPopup();
                // 팝업화면을 기본적으로 부모폼에 대해 CenterParent 속성을 가지므로, 이를 Manual로 변환해야 정상적인 위치가 잡힙니다.
                frm.StartPosition = FormStartPosition.Manual;
                // 팝업화면은 기본적으로 이동이 가능하지만, 이동이 불가능하도록 아래 속성을 할당합니다.
                frm._SOIPopupShowStyle = SOIPopupShowStyle.PopupAsFunc;
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "StandardOI.exe";
                menuInfo.s_assembly_name = "StandardOI.Samples.SamplePopups.frmTestSampleFuncAsPopup";                
                // 화면 제목은 팝업화면에 명시된 이름과 동일한 제목을 입력합니다.
                menuInfo.s_func_desc = "Sample Popup"; 
                // 서버에 등록되지 않은 화면이므로 화면 코드가 없습니다.
                menuInfo.s_func_name = string.Empty;
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

        #region Function

        #endregion
    }
}
