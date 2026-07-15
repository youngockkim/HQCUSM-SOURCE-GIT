using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;

namespace SOI.OIFrx.SOIBaseForm
{
    public partial class SOIBaseForm03 : SOIBaseForm02
    {
        #region Property

        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;

        #endregion

        #region Constructor

        public SOIBaseForm03()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면 로드 시 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SOIBaseForm03_Load(object sender, EventArgs e)
        {
            // 디자인 모드인 경우 제외
            if (DesignMode == true)
            {
                return;
            }

            // Menu 정보 로드
            menuInfo = (MenuInfoTag)this.Tag;

            // Print Option 할당
            if(printOption == null)
            {
                printOption = new PrintOptionModel();
            }

            // Print Option 정보 호출
            MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);
        }

        /// <summary>
        /// Print Option 버튼 클릭 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;          
            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion
    }
}
