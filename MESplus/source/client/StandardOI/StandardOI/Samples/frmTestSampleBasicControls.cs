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

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleBasicControls : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleBasicControls()
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
            // (Option) SOIRadioButton Initialize
            // SOIRadioButton의 초기값을 설정합니다.
            // Value Changed Event를 발생시킵니다.
            soiRadioButton3.Value = 0;

            // (Option) SOIComboBox Initialize
            // SOIComboBox의 초기값을 설정합니다.
            soiComboBox3.SelectedIndex = 0;

            // (Option) DateTime Initialize
            // SOIDateTime의 초기값을 설정합니다.
            // DateTime 타입으로 설정.
            soiDateTime2.SetValueAsDateTime(new DateTime(2016, 1, 1));
            // 또는 string 타입으로 설정. 
            //  - 14 Degit: YYYYMMDDHHmmss
            //  - 8 Degit: YYYYMMDD
            //  - 6 Degit: HHmmss
            //  - Others: string.empty
            //soiDateTime2.SetValueAsString("20160101");

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
        /// (Option) Process Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Process 로직을 처리합니다.
        }

        /// <summary>
        /// Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            // SOIButton 사용 시, 클릭 이벤트를 처리합니다.
            // SOIButtonImage 사용 시,  클릭 이벤트를 처리합니다.
            // 아래 로직은 테스트 코드입니다.
            if (sender is SOIButton)
            {
                MPCF.ShowMessage(((SOIButton)sender).Text, SOI.CliFrx.MSG_LEVEL.INFO, false);
            }
            else if (sender is SOIButtonImage)
            {
                MPCF.ShowMessage(((SOIButtonImage)sender).Text, SOI.CliFrx.MSG_LEVEL.INFO, false);
            }
        }

        /// <summary>
        /// Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiButton2_Click(object sender, EventArgs e)
        {
            // SOIButton 사용 시,  클릭 이벤트를 처리합니다.
            // 아래 로직은 테스트 코드입니다.
            MPCF.ShowMessage("Only Image", SOI.CliFrx.MSG_LEVEL.INFO, false);
        }

        /// <summary>
        /// Picture Box Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiPictureBox1_Click(object sender, EventArgs e)
        {
            // SOIPictureBox 사용 시, 클릭 이벤트를 처리합니다.
            // 아래 로직은 테스트 코드입니다.
            MPCF.ShowMessage("Picture Box", SOI.CliFrx.MSG_LEVEL.INFO, false);
        }

        /// <summary>
        /// (Option) Radio Button Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiRadioButton3_ValueChanged(object sender, EventArgs e)
        {
            // SOIRadioButton에서 아이템 변경 시, 발생합니다.
            // 초기값을 할당할 때에도 발생하므로, 화면 로드가 완료된 후 처리되도록 합니다.
            if (bIsShown == false)
            {
                return;
            }
            MPCF.ShowMessage(((SOIRadioButton)sender).Text, SOI.CliFrx.MSG_LEVEL.INFO, true);
        }

        /// <summary>
        /// Text Box Validation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTextBoxCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // SOITextBox Validation 로직입니다.
                MPCF.CheckValue(soiTextBox1, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// ComboBox Selected Item Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiComboBox3_SelectionChanged(object sender, EventArgs e)
        {
            // SOIComboBox에서 Item이 변경되었을 때 발생합니다.
            // 초기값을 할당할 때에도 발생하므로, 화면 로드가 완료된 후 처리되도록 합니다.
            if (bIsShown == false)
            {
                return;
            }

            // 1) selectedIndex는 선택된 아이템의 Index를 return합니다.
            // 2) selectedItem.DataValue는 선택된 아이템의 value를 return합니다.
            // 3) selectedItem.DataValue는 선택된 아이템의 Display Text를 return합니다.
            // 4) selectedText는 사용하지 않습니다.
            MPCF.ShowMessage("Index : " + ((SOIComboBox)sender).SelectedIndex.ToString() + "\n" +
                                               "Item.DataValue : " + ((SOIComboBox)sender).SelectedItem.DataValue.ToString() + "\n" +
                                               "Item.DisplayText : " + ((SOIComboBox)sender).SelectedItem.DisplayText.ToString() + "\n"
                                                , SOI.CliFrx.MSG_LEVEL.INFO, true);
        }

        /// <summary>
        /// CodeView Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiCodeView2_CodeViewButtonClick(object sender, EventArgs e)
        {
            // SOICodeView에서 코드뷰 창을 띄우기 전에 실행됩니다.
            // 호출 해야하는 서비스에 대한 정보를 입력해야 합니다.
            // 아래의 5가지 로직을 구현합니다.

            // ***** GCM Table *****
            // 1) (Optional) Check Required Value 
            // 코드뷰 이전에 필수입력사항이 있는지 확인합니다.
            if (MPCF.CheckValue(soiComboBox3, false) == false)
            {
                return;
            }

            // 2) In Node Setup
            // In Node를 설정합니다.
            // GCM Table을 조회하는 경우, GCM Table 명을 아래와 같이 추가합니다.
            TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim("UNIT"));

            // 3) Column Header Text Setup
            // CodeView의 Column 명을 직접 입력합니다.
            // Column 명은 다국어설정에 따라 변환됩니다.
            // 앞에서부터 순차적으로 컬럼이 설정됩니다.
            string[] header = new string[] { "UNIT Code", "UNIT Description" };

            // 4) Column Select
            // 조회할 컬럼을 설정합니다.
            // GCM Table의 경우, KEY_1, KEY_2...와 같은 형식으로 입력합니다.
            // 앞에서부터 순차적으로 컬럼이 설정됩니다.
            string[] display = new string[] { "KEY_1", "DATA_1" };

            // 5) Show
            // Show 메소드를 호출합니다. 파라미터는 다음과 같습니다.
            //    1. 코드뷰 컨트롤
            //    2. 코드뷰팝업창 타이틀
            //    3. 호출서비스의 모듈명 (GCM Table은 BAS)
            //    4. 호출서비스 명 (GCM Table은 BAS_View_Data_List)
            //    5. In Node
            //    6. 조회한 List의 명 (GCM Table은 DATA_LIST)
            //    7. 조회할 컬럼배열: display
            //    8. 컬럼명 배열: header
            //    9. 코드뷰팝업창에서 아이템선택 시 값을 반환할 컬럼.
            // 팝업화면이 닫히면 설정된 컬럼의 선택된 값을 반환 받습니다.
            soiCodeView2.Text = soiCodeView2.Show(soiCodeView2, "UNIT Information", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            // (Option) Cancel
            // 화면을 종료하였을 때, 이후 로직을 처리하고 싶지 않은 경우에 사용합니다.
            if (soiCodeView2.drResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // (Option) Return Datas
            // 팝업화면이 닫힌 후 선택된 Row의 모든 컬럼 값을 사용하고자 하는 경우 returnDatas 배열을 사용합니다.
            string sCodeViewReturnTest = string.Empty;
            if (soiCodeView2.returnDatas != null && soiCodeView2.returnDatas.Count > 0)
            {
                foreach (string s in soiCodeView2.returnDatas)
                {
                    sCodeViewReturnTest = sCodeViewReturnTest + s + "\n";
                }
                MPCF.ShowMessage(sCodeViewReturnTest, SOI.CliFrx.MSG_LEVEL.INFO, true);
            }
            // **********************************************************************

            //// ***** Service *****
            //// 1) (Optional) Check Required Value 
            //// 코드뷰 이전에 필수입력사항이 있는지 확인합니다.
            //if (MPCF.CheckValue(soiComboBox3, false) == false)
            //{
            //    return;
            //}

            //// 2) In Node Setup
            //// In Node를 설정합니다.
            //TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
            //MPCF.SetInMsg(in_node);
            //in_node.ProcStep = '2';
            //in_node.AddString("MAT_ID", nodeLotInfo.GetString("MAT_ID"));
            //in_node.AddString("FLOW", nodeLotInfo.GetString("FLOW"));
            //in_node.AddString("OPER", nodeLotInfo.GetString("OPER"));

            //// 3) Column Header Text Setup
            //// CodeView의 Column 명을 직접 입력합니다.
            //// Column 명은 다국어설정에 따라 변환됩니다.
            //// 앞에서부터 순차적으로 컬럼이 설정됩니다.
            //string[] header = new string[] { "Resource ID", "Resource Description" };

            //// 4) Column Select
            //// 조회할 컬럼을 설정합니다.
            //// GCM Table의 경우, KEY_1, KEY_2...와 같은 형식으로 입력합니다.
            //// 앞에서부터 순차적으로 컬럼이 설정됩니다.
            //string[] display = new string[] { "RES_ID", "RES_DESC" };

            //// 5) Show
            //// Show 메소드를 호출합니다. 파라미터는 다음과 같습니다.
            ////    1. 코드뷰 컨트롤
            ////    2. 코드뷰팝업창 타이틀
            ////    3. 호출서비스의 모듈명 (GCM Table은 BAS)
            ////    4. 호출서비스 명 (GCM Table은 BAS_View_Data_List)
            ////    5. In Node
            ////    6. 조회한 List의 명 (GCM Table은 DATA_LIST)
            ////    7. 조회할 컬럼배열: display
            ////    8. 컬럼명 배열: header
            ////    9. 코드뷰팝업창에서 아이템선택 시 값을 반환할 컬럼.
            //// 팝업화면이 닫히면 설정된 컬럼의 선택된 값을 반환 받습니다.
            //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");

            //// (Option) Return Datas
            //// 팝업화면이 닫힌 후 선택된 Row의 모든 컬럼 값을 반환받고자 하는 경우 아래의 변수를 사용합니다.
            //string sCodeViewReturnTest = string.Empty;
            //foreach (string s in soiCodeView2.returnDatas)
            //{
            //    sCodeViewReturnTest = sCodeViewReturnTest + s + "\n";
            //}
            //MPCF.ShowMessage(sCodeViewReturnTest, SOI.CliFrx.MSG_LEVEL.INFO, true);
            //// **********************************************************************

            soiTextBoxNumber2.Value = 10;
        }

        /// <summary>
        /// CodeView Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiCodeViewDescription1_CodeViewButtonClick(object sender, EventArgs e)
        {
            // SOICodeViewDescription에서 코드뷰 창을 띄우기 전에 실행됩니다.
            // 호출 해야하는 서비스에 대한 정보를 입력해야 합니다.
            // 구현해야 하는 로직은 SOICodeView와 동일합니다.

            // 1) (Optional) Check Required Value 
            if (MPCF.CheckValue(soiComboBox3, false) == false)
            {
                return;
            }

            // 2) In Node Setup
            TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim("UNIT"));

            // 3) Column Header Text Setup
            string[] header = new string[] { "UNIT Code", "UNIT Description" };

            // 4) Column Select
            string[] display = new string[] { "KEY_1", "DATA_1" };

            // 5) Show
            soiCodeViewDescription1.Text = soiCodeViewDescription1.Show(soiCodeViewDescription1, "UNIT Information", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

        }

        /// <summary>
        /// Date Time Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiDateTime2_ValueChanged(object sender, EventArgs e)
        {
            // SOIDateTime에서 값이 변경되었을 때 발생합니다.
            // 초기값을 할당할 때에도 발생하므로, 화면 로드가 완료된 후 처리되도록 합니다.
            if (bIsShown == false)
            {
                return;
            }

            // Return Value As "DateTime" Type
            MPCF.ShowMessage(((SOIDateTime)sender).GetValueAsDateTime().ToString(), SOI.CliFrx.MSG_LEVEL.INFO, true);

            // Return Value As "String" Type
            //  - 14 Degit: YYYYMMDDHHmmss
            //  - 8 Degit: YYYYMMDD
            //  - 6 Degit: HHmmss
            MPCF.ShowMessage(((SOIDateTime)sender).GetValueAsString(14), SOI.CliFrx.MSG_LEVEL.INFO, true);
            MPCF.ShowMessage(((SOIDateTime)sender).GetValueAsString(8), SOI.CliFrx.MSG_LEVEL.INFO, true);
            MPCF.ShowMessage(((SOIDateTime)sender).GetValueAsString(6), SOI.CliFrx.MSG_LEVEL.INFO, true);
        }

        #endregion

        #region Function

        #endregion
    }
}
