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
    public partial class frmTestSampleBasicControls2 : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleBasicControls2()
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
            // DateTimeComboBox 컨트롤을 사용하는 경우 초기화가 필요합니다.
            //soiDateTimeComboBox1.Value = "20160101120505";
            soiDateTimeComboBox1.SetValue(DateTime.Now);
            soiCodeView1.ReadOnly = false;


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
        /// MultiSelect CodeView Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiCodeViewMultiSelect1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // SOICodeViewMultiSelect에서 코드뷰 창을 띄우기 전에 실행됩니다.
                // 호출 해야하는 서비스에 대한 정보를 입력해야 합니다.
                // 아래의 5가지 로직을 구현합니다.

                // ***** GCM Table *****
                // 1) (Optional) Check Required Value 
                // 코드뷰 이전에 필수입력사항이 있는지 확인합니다.
                //if (MPCF.CheckValue(soiComboBox3, false) == false)
                //{
                //    return;
                //}

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

                // Additional Option) Invisible Column Setup
                // 숨김처리할 컬럼을 설정합니다.
                // display에 할당된 키 중에서 숨기고 싶은 컬럼의 키를 입력합니다.
                string[] visibleFalse = new string[] { "DATA_1" };

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
                //    Add. 숨김처리 컬럼배열: visibleFalse
                //    9. 코드뷰팝업창에서 아이템선택 시 값을 반환할 컬럼.
                // 팝업화면이 닫히면 설정된 컬럼의 선택된 값을 반환 받습니다.
                soiCodeViewMultiSelect1.Text = soiCodeViewMultiSelect1.Show(soiCodeViewMultiSelect1, "UNIT Information", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, visibleFalse, "KEY_1");

                // (Option) Cancel
                // 화면을 종료하였을 때, 이후 로직을 처리하고 싶지 않은 경우에 사용합니다.
                if (soiCodeViewMultiSelect1.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // (Option) Return Data
                // 팝업화면이 닫힌 후 return되는 데이터의 종류는 다음과 같은 것들이 있습니다.
                //   1- ,(comma) 를 구분자로 사용하여 단일 string 값을 받을 수 있습니다.
                //       Show 메소드에서 기본으로 return하는 값 입니다.
                //       나열되는 순서는 코드뷰팝업창에서 선택한 순서입니다.
                //       ex) CELL, WAFER, DIE
                MPCF.ShowMessage("Return string : " + soiCodeViewMultiSelect1.Text, SOI.CliFrx.MSG_LEVEL.INFO, true);

                //   2- List<string> 타입으로 string 값을 받을 수 있습니다.
                //       "returnValues" 속성에 값이 저장되어 있습니다.
                //      코드뷰팝업창을 열 때, 입력한 반환 컬럼의 값들이 저장되어 있습니다.
                StringBuilder sb = new StringBuilder();
                foreach(string key in soiCodeViewMultiSelect1.returnValues)
                {
                    sb.Append("[");
                    sb.Append(key);
                    sb.Append("]");
                }
                MPCF.ShowMessage("Return List<string> : " + sb.ToString(), MSG_LEVEL.INFO, true);

                //   3- TRSNode 타입으로 선택한 전체 데이터를 받을 수 있습니다.
                //      "returnData" 속성에 값이 저장되어 있습니다.
                //       returnData는 TRSNode입니다. returnData 하위에 List가 있으며, 이름은 "DATA_LIST"로 고정되어 있습니다.
                //       List 하위에는 각각의 row에 입력한 display 키값과 값이 들어 있습니다.
                //       만일, 해당 TRSNode를 서비스에 그대로 사용하고자 한다면, list 이름을 서비스 in_node와 맞게 변경합니다. 
                //             soiCodeViewMultiSelect1.returnData.Lists[0].name = "ABC_LIST";                
                sb = new StringBuilder();
                foreach (TRSNode node in soiCodeViewMultiSelect1.returnData.GetList(0))
                {
                    sb.Append("<row>");
                    for (int i = 0; i < node.MemberCount; i++)
                    {
                        sb.Append("[");
                        sb.Append(node.Members[i].Value);
                        sb.Append("]");
                    }
                    sb.Append("</row>");
                }
                MPCF.ShowMessage("Return TRSNode : " + sb.ToString(), MSG_LEVEL.INFO, true);                               
                // **********************************************************************
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// SOICodeView의 입력가능한 상태에 대한 처리를 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiCodeView1_KeyDown(object sender, KeyEventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_CODEVIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_CODEVIEW_DATA_OUT");
            bool bFound = false;

            try
            {
                // Enter인 경우에만 실행합니다.
                if (e.KeyCode == Keys.Enter)
                {
                    // 입력한 값이 있는지 체크합니다.
                    if (MPCF.CheckValue(soiCodeView1, false) == false)
                    {
                        return;
                    }

                    // 서비스를 조회합니다.
                    // 아래는 서비스 조회에 대한 예제입니다.                    
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAMe", MPCF.Trim("UNIT"));
                    if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    // 조회한 서비스에서 List를 찾고 List에 해당 데이터가 있는지 검색합니다.                    
                    if (out_node.GetList("DATA_LIST") != null && out_node.GetList("DATA_LIST").Count > 0)
                    {
                        foreach (TRSNode data in out_node.GetList("DATA_LIST"))
                        {
                            if (data.GetString("KEY_1") == soiCodeView1.Text)
                            {
                                // ReturnDatas 객체를 초기화 합니다.
                                if (soiCodeView1.returnDatas == null)
                                {
                                    soiCodeView1.returnDatas = new List<string>();
                                }
                                else
                                {
                                    soiCodeView1.returnDatas.Clear();
                                }

                                // 해당 row의 data를 추가합니다.
                                soiCodeView1.returnDatas.Add(data.GetString("KEY_1"));
                                soiCodeView1.returnDatas.Add(data.GetString("DATA_1"));

                                // 정상종료 합니다.
                                bFound = true;
                                break;
                            }
                        }
                    }

                    // 결과가 없는 경우 코드뷰 값을 초기화 하거나 또는 에러메시지를 내보냅니다.
                    if (bFound == false)
                    {
                        soiCodeView1.Text = string.Empty;
                        soiCodeView1.Focus();
                        // 데이타가 유효하지 않습니다.
                        MPCF.ShowMessage(MPCF.GetMessage(74), MSG_LEVEL.ERROR, false);
                    }
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// CodeView Data를 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiCodeView1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("UNIT"));
                string[] header = new string[] { "UNIT Code", "UNIT Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };
                soiCodeView1.Text = soiCodeView1.Show(soiCodeView1, "UNIT Information", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// CodeView에서 GetValue를 사용하여, 다른 키값을 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvGetValue_CodeViewButtonClick(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim("UNIT"));
            string[] header = new string[] { "UNIT Code", "UNIT Description" };
            string[] display = new string[] { "KEY_1", "DATA_1" };
            cdvGetValue._ValueColumn = "KEY_1";
            cdvGetValue.Text = cdvGetValue.Show(cdvGetValue, "UNIT Information", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
            MPCF.ShowMessage(cdvGetValue.Value, MSG_LEVEL.NONE, true);
        }

        /// <summary>
        /// SOIDateTimeComboBox의 value를 조회 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                // Pattern에 따라 value 값이 달라집니다.
                // 아래는 "20160101120505"를 입력했을 때, value를 통해 얻을 수 있는 값의 예시 입니다.
                // YYYY : 2016
                // YYYYMM: 201601
                // YYYYMMDD: 20160101
                // YYYYMMDDHHMMSS: 20160101120505
                // HHMM: 1205
                // HHMMSS: 120505
                MPCF.ShowMessage("value : " + soiDateTimeComboBox1.Value, MSG_LEVEL.INFO, true);
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
