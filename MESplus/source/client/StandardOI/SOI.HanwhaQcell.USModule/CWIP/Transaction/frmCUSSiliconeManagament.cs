using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.CliFrx;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIModel;
using SOI.HanwhaQcell.USModule.CWIP.Popup;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSSiliconeManagament : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private string left_weight_rs = string.Empty;
        private string right_weight_rs = string.Empty;
        private string center_weight_rs = string.Empty;
        private string ratio_rs = string.Empty;
        private string ratio_rs2 = string.Empty;

        private string frame_sw_rs = string.Empty;
        private string frame_lw_rs = string.Empty;

        //2026/01/15
        private string miattach1_rs = string.Empty;
        private string miattach2_rs = string.Empty;
        

        public enum JB_SILICONE_LIST
        {
            CREATE_DATE,
            CREATE_TIME,
            LINE_ID,
            SILICONE_TYPE,
            RIGHT_WEIGHT,
            CENTER_WEIGHT,
            LEFT_WEIGHT,
            COMMENT_CONT
        }

        public enum RATIO_LIST
        {
            CREATE_DATE,
            CREATE_TIME,
            LINE_ID,
            SILICONE_TYPE,
            MIXER1_POTTING_WEIGHT_A,
            MIXER1_POTTING_WEIGHT_B,
            MIXER1_POTTING_WEIGHT_RATIO,
            MIXER2_POTTING_WEIGHT_A,
            MIXER2_POTTING_WEIGHT_B,
            MIXER2_POTTING_WEIGHT_RATIO,
            COMMENT_CONT
        }

        public enum SILICONE_LIST
        {
            CREATE_DATE,
            CREATE_TIME,
            LINE_ID,
            SILICONE_TYPE,
            RIGHT_WEIGHT,
            CENTER_WEIGHT,
            LEFT_WEIGHT,
            COMMENT_CONT
        }

        public enum FRAME_LIST
        {
            CREATE_DATE,
            CREATE_TIME,
            LINE_ID,
            SILICONE_TYPE,
            MODULE_TYPE,
            SHORT_WEIGHT,
            LONG_WEIGHT,
            COMMENT_CONT
        }

        public enum MICRO_INVERTER_ATTACH_LIST
        {
            CREATE_DATE,
            CREATE_TIME,
            LINE_ID,
            SILICONE_TYPE,
            MI_ATTACH1,
            MI_ATTACH2,
            COMMENT_CONT
        }


        #endregion

        #region Constructor

        public frmCUSSiliconeManagament()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSCleavingProduction_Load(object sender, EventArgs e)
        {

            dtpDate.Value = DateTime.Today;

            // Init
            //GET LINE 
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '5';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

            int i;
            if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    soiLine.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    cbLine_Input_Tab1.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    cbLine_Input_Tab2.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    cbLine_Input_Tab3.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    cbLine_Input_Tab4.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    cbLine_Input_Tab5.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }


            //GET SILICONE TYPE
            TRSNode in_node2 = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node2 = new TRSNode("VIEW_DATA_OUT");
            TRSNode out_list2;
            MPCF.SetInMsg(in_node2);

            in_node2.ProcStep = '1';
            in_node2.AddString("TABLE_NAME", MPCF.Trim("@SILICONE_TYPE"));

            int c;
            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node2, ref out_node2) == true)
            {
                for (c = 0; c < out_node2.GetList(0).Count; c++)
                {
                    out_list2 = out_node2.GetList(0)[c];

                    soiSilType.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));
                    cbSiliconeType_Input_Tab1.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));
                    cbSiliconeType_Input_Tab2.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));
                    cbSiliconeType_Input_Tab3.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));
                    cbSiliconeType_Input_Tab4.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));
                    cbSiliconeType_Input_Tab5.Items.Add(out_list2.GetString("KEY_1"), out_list2.GetString("DATA_1"));

                }
            }

            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    string strTime = string.Format("{0:D2}:{1:D2}", hour, minute); 
                    cbTime_Input_Tab1.Items.Add(strTime);
                    cbTime_Input_Tab2.Items.Add(strTime);
                    cbTime_Input_Tab3.Items.Add(strTime);
                    cbTime_Input_Tab4.Items.Add(strTime);
                    cbTime_Input_Tab5.Items.Add(strTime);
                }
            }

            // 기본 선택값 설정 (선택 사항)
            DateTime nowDate = DateTime.Now;
            string strCurrTime = "";
            if(nowDate.Minute < 30){
                strCurrTime = string.Format("{0:D2}:00", nowDate.Hour); 
            }else{
                strCurrTime = string.Format("{0:D2}:30", nowDate.Hour); 
            }
            for (int nIndex = 0; nIndex < cbTime_Input_Tab1.Items.Count; nIndex++)
            {
                string itemText = cbTime_Input_Tab1.Items[nIndex].ToString();
                if (itemText.Contains(strCurrTime))
                {
                    cbTime_Input_Tab1.SelectedIndex = nIndex; 
                    cbTime_Input_Tab2.SelectedIndex = nIndex; 
                    cbTime_Input_Tab3.SelectedIndex = nIndex; 
                    cbTime_Input_Tab4.SelectedIndex = nIndex;
                    cbTime_Input_Tab5.SelectedIndex = nIndex;
                    break;
                }
            }
            
            

            dtDate_Input_Tab1.Value = DateTime.Today;
            dtDate_Input_Tab2.Value = DateTime.Today;
            dtDate_Input_Tab3.Value = DateTime.Today;
            dtDate_Input_Tab4.Value = DateTime.Today;
            dtDate_Input_Tab5.Value = DateTime.Today;

            MPCF.ConvertCaption(this);
        }

        private void cdvName_CodeViewButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    // In Node Setup
            //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            //    MPCF.SetInMsg(in_node);
            //    in_node.ProcStep = '1';
            //    in_node.AddString("TABLE_NAME", MPCF.Trim("@SILICONE_NAME"));

            //    string[] header = new string[] { "Name", "Description" };
            //    string[] display = new string[] { "KEY_1", "DATA_1" };

            //    cdvName.Text = cdvName.Show(cdvName, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

              
            //    // Clear
            //    MPCF.FieldClear(pnlMiddleMargin, cdvName);

            //    // Validation
            //    if (string.IsNullOrEmpty(cdvName.Text) == true)
            //    {
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}
        }


        private void cdvModuleType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '6';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_TYPE"));
                in_node.AddString("KEY_2", MPCF.Trim(cbSiliconeType_Input_Tab4.Value));

                string[] header = new string[] { "Code", "Name"};
                string[] display = new string[] { "KEY_1", "DATA_1"};

                cdvModuleType.Text = cdvModuleType.Show(cdvModuleType, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");
                // Clear
                //MPCF.FieldClear(pnlMiddleMargin, cdvModuleType);

                // Validation
                if (string.IsNullOrEmpty(cdvModuleType.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void soiSilType_ValueChanged(object sender, EventArgs e)
        {
            //cdvModuleType.Text = string.Empty;
            //cdvModuleType.Focus();
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            
            try
            {
                //공통 입력 사항
                //if (MPCF.CheckValue(cdvName, false) == false)
                //{
                //    return;
                //}

                //if (MPCF.CheckValue(cbLine_Input_Tab1, false) == false)
                //{
                //    return;
                //}

                //if (MPCF.CheckValue(dtDate_Input_Tab1, false) == false)
                //{
                //    return;
                //}

                //if (MPCF.CheckValue(cbTime_Input_Tab1, false) == false)
                //{
                //    return;
                //}

                //if (MPCF.CheckValue(cbSiliconeType_Input_Tab1, false) == false)
                //{
                //    return;
                //}
                //__End 공통사항

                


                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    if (MPCF.CheckValue(cbLine_Input_Tab1, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(dtDate_Input_Tab1, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbTime_Input_Tab1, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbSiliconeType_Input_Tab1, false) == false)
                    {
                        return;
                    }
                    //---------------------------------------

                    if (MPCF.CheckValue(soiJbLW, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiJbRW, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiJbCW, false) == false)
                    {
                        return;
                    }
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    if (MPCF.CheckValue(cbLine_Input_Tab2, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(dtDate_Input_Tab2, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbTime_Input_Tab2, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbSiliconeType_Input_Tab2, false) == false)
                    {
                        return;
                    }
                    //---------------------------------------


                    if (MPCF.CheckValue(soiPotAW_Mixer1, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiPotBW_Mixer1, false) == false)
                    {
                        return;
                    }
                    

                    if (MPCF.CheckValue(soiPotAW_Mixer2, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiPotBW_Mixer2, false) == false)
                    {
                        return;
                    }
                    

                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    if (MPCF.CheckValue(cbLine_Input_Tab3, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(dtDate_Input_Tab3, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbTime_Input_Tab3, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbSiliconeType_Input_Tab3, false) == false)
                    {
                        return;
                    }
                    //---------------------------------------

                    if (MPCF.CheckValue(txtPotLW, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiPotRW, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(soiPotCW, false) == false)
                    {
                        return;
                    }
                    /*
                    if (MPCF.CheckValue(soiComboSide, false) == false)
                    {
                        return;
                    }
                     * */
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    if (MPCF.CheckValue(cbLine_Input_Tab4, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(dtDate_Input_Tab4, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbTime_Input_Tab4, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbSiliconeType_Input_Tab4, false) == false)
                    {
                        return;
                    }
                    

                    //---------------------------------------
                    if (MPCF.CheckValue(cdvModuleType, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(txtFrameLW, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(txtFrameSW, false) == false)
                    {
                        return;
                    }

                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    if (MPCF.CheckValue(cbLine_Input_Tab5, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(dtDate_Input_Tab5, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbTime_Input_Tab5, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cbSiliconeType_Input_Tab5, false) == false)
                    {
                        return;
                    }
                    //---------------------------------------

                    if (MPCF.CheckValue(txtMIAttach1, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(txtMIAttach2, false) == false)
                    {
                        return;
                    }

                }

                //VALIDATION 
                if (!ValidateSiliconeManagement2())
                {
                    return;
                }

                //UPDATE
                if (!UpdateSiliconeManagement())
                {
                    //return;
                }

                //VALIDATION 
                if (!ValidateSiliconeManagement())
                {
                    return;
                }
 

                // Refresh
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool ValidateSiliconeManagement()
        {
            TRSNode in_node = new TRSNode("SIL_UPDATE_IN");
            TRSNode out_node = new TRSNode("SIL_UPDATE_OUT");
            //TRSNode terminate_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                left_weight_rs = "NG";
                right_weight_rs = "NG";
                center_weight_rs = "NG";
                ratio_rs = "NG";
                ratio_rs2 = "NG";

                frame_lw_rs = "NG";
                frame_sw_rs = "NG";

                //2026/01/15
                miattach1_rs = "NG";
                miattach2_rs = "NG";

                in_node.AddString("FACTORY", MPCF.Trim(MPGV.gsFactory));
                //in_node.AddString("NAME", MPCF.Trim(cdvName.Text));
                //in_node.AddString("LINE", MPCF.Trim(soiLine.Value));
                //in_node.AddString("SILICONE_TYPE", MPCF.Trim(soiSilType.Value));

                //각 조건에 맞게 데이터 셋 
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab1.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab1.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@JB_ATTCH_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(soiJbLW.Text));
                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiJbRW.Text));
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiJbCW.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiJbCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                    /*
                    if (!numberCheck(MPCF.Trim(soiJbLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbCW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbRW.Text))) return false;
                     */
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab2.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab2.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_RATIO"));
                    in_node.AddString("POTTING_WEIGHT_A", MPCF.Trim(soiPotAW_Mixer1.Text));
                    in_node.AddString("POTTING_WEIGHT_B", MPCF.Trim(soiPotBW_Mixer1.Text));
                    /*
                   if (!numberCheck(MPCF.Trim(soiPotAW.Text))) return false;
                   if (!numberCheck(MPCF.Trim(soiPotBW.Text))) return false;
                      */
                    float potAw = float.Parse(MPCF.Trim(soiPotAW_Mixer1.Text));
                    float potBw = float.Parse(MPCF.Trim(soiPotBW_Mixer1.Text));
                    float potRatio = potAw / potBw;
                    in_node.AddString("POTTING_WEIGHT_RATIO", float.Parse(potRatio.ToString("0.00")).ToString());

                    //추가
                    float potAw2 = float.Parse(MPCF.Trim(soiPotAW_Mixer2.Text));
                    float potBw2 = float.Parse(MPCF.Trim(soiPotBW_Mixer2.Text));
                    float potRatio2 = potAw2 / potBw2;
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(soiPotAW_Mixer2.Text)); //MI_ATTACH1
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(soiPotAW_Mixer2.Text));  //MI_ATTACH2
                    in_node.AddString("POTTING_WEIGHT_RATIO2", float.Parse(potRatio2.ToString("0.00")).ToString());
                    //

                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiRatioCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    

                    
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab3.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab3.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(txtPotLW.Text));
                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiPotRW.Text));
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiPotCW.Text));
                    //in_node.AddString("SILICONE_SIDE", MPCF.Trim(soiComboSide.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiPotRCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                    /*
                    if (!numberCheck(MPCF.Trim(txtPotLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotRW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotCW.Text))) return false;
                       */
                }else if(tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab4.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab4.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", txtFrameSW.Text);
                    in_node.AddString("FRAME_LONG_WEIGHT", txtFrameLW.Text);
                    in_node.AddString("FRAME_MODULE_TYPE", cdvModuleType.Text);

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    //in_node.AddString("SILICONE_SIDE", MPCF.Trim(soiComboSide.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiFrameCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab5.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab5.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@MI_SIL_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(txtMIAttach1.Text)); //MI_ATTACH1
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(txtMIAttach2.Text));  //MI_ATTACH2
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiMIAttachCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    
                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    //in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');
                    
                }


                if (MPCF.CallService("CWIP", "CWIP_Validation_Silicone_Management", in_node, ref out_node) == false)
                {
                    return false;
                }


                
                if (out_node.ListCount > 0
                    && out_node.GetList(0).Count > 0)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // PROMPT가 값이 있는 경우 등록
                        if (out_node.GetList(0)[i].GetString("LEFT_WEIGHT_RS") != "")
                        {
                            left_weight_rs = out_node.GetList(0)[i].GetString("LEFT_WEIGHT_RS");
                        }
                        if(out_node.GetList(0)[i].GetString("RIGHT_WEIGHT_RS") != "")
                        {
                            right_weight_rs = out_node.GetList(0)[i].GetString("RIGHT_WEIGHT_RS");
                        }
                        if(out_node.GetList(0)[i].GetString("CENTER_WEIGHT_RS") != "")
                        {
                            center_weight_rs = out_node.GetList(0)[i].GetString("CENTER_WEIGHT_RS");
                        }
                        if(out_node.GetList(0)[i].GetString("RATIO_RS") != "")
                        {
                            ratio_rs = out_node.GetList(0)[i].GetString("RATIO_RS");
                        }
                        //추가
                        if (out_node.GetList(0)[i].GetString("RATIO_RS2") != "")
                        {
                            ratio_rs2 = out_node.GetList(0)[i].GetString("RATIO_RS2");
                        }

                        if (out_node.GetList(0)[i].GetString("FRAME_SHORT_RS") != "")
                        {
                            frame_sw_rs = out_node.GetList(0)[i].GetString("FRAME_SHORT_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("FRAME_LONG_RS") != "")
                        {
                            frame_lw_rs = out_node.GetList(0)[i].GetString("FRAME_LONG_RS");
                        }

                        //2026/01/15
                        if (out_node.GetList(0)[i].GetString("MIATTACH1_RS") != "")
                        {
                            miattach1_rs = out_node.GetList(0)[i].GetString("MIATTACH1_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("MIATTACH2_RS") != "")
                        {
                            miattach2_rs = out_node.GetList(0)[i].GetString("MIATTACH2_RS");
                        }
                    }
                }

                DialogResult drResult;
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {

                    frmCWIPSiliconeResultPopup f = new frmCWIPSiliconeResultPopup();
                    f.Owner = MPGV.gfrmMDI;
                    f.left_rs = MPCF.Trim(left_weight_rs);
                    f.center_rs = MPCF.Trim(center_weight_rs);
                    f.right_rs = MPCF.Trim(right_weight_rs);
                    //f.title_rs = MPCF.Trim("JB Attach");
                    f.title = "JB Attaching Silicone Weight";
                    drResult = f.ShowDialog();
                    
                    /*
                    if (drResult == DialogResult.No)
                    {
                        return false;
                    }
                     * */
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    frmCWIPSiliconeRatioResultPopup f = new frmCWIPSiliconeRatioResultPopup();
                    f.Owner = MPGV.gfrmMDI;
                    f.ratio_rs = MPCF.Trim(ratio_rs);
                    f.ratio_rs2 = MPCF.Trim(ratio_rs2);
                    drResult = f.ShowDialog();
                    /*
                    if (drResult == DialogResult.No)
                    {
                        return false;
                    }
                     * */
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    frmCWIPSiliconeResultPopup f = new frmCWIPSiliconeResultPopup();
                    f.Owner = MPGV.gfrmMDI;
                    f.left_rs = MPCF.Trim(left_weight_rs);
                    f.center_rs = MPCF.Trim(center_weight_rs);
                    f.right_rs = MPCF.Trim(right_weight_rs);
                    //f.title_rs = "Silicone Weight";
                    f.title = "Potting Silicone Weight";
                    drResult = f.ShowDialog();
                    /*
                    if (drResult == DialogResult.No)
                    {
                        return false;
                    }
                    */
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    //frmCWIPSiliconeFrameResultPopup f = new frmCWIPSiliconeFrameResultPopup();
                    frmCWIPSiliconeFrameResultPopup fs = new frmCWIPSiliconeFrameResultPopup();
                    fs.Owner = MPGV.gfrmMDI;
                    fs.frameSW.Text = MPCF.Trim(frame_sw_rs);
                    fs.frameLW.Text = MPCF.Trim(frame_lw_rs);

                    // f.title_rs = MPCF.Trim(soiComboSide.Text);
                    //fs.title = "Frame Silicone Weight";
                    fs.lblPopupTitle.Text = "Frame Silicone Weight";
                   
                    drResult = fs.ShowDialog();
                    /*
                    if (drResult == DialogResult.No)
                    {
                        return false;
                    }
                    */
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")  //2026/01/15
                {
                    //frmCWIPSiliconeFrameResultPopup f = new frmCWIPSiliconeFrameResultPopup();
                    frmCWIPSiliconeMIAttachResultPopup fs = new frmCWIPSiliconeMIAttachResultPopup();
                    fs.Owner = MPGV.gfrmMDI;
                    fs.txtMIAttach1.Text = MPCF.Trim(miattach1_rs);
                    fs.txtMIAttach2.Text = MPCF.Trim(miattach2_rs);

                    // f.title_rs = MPCF.Trim(soiComboSide.Text);
                    //fs.title = "Frame Silicone Weight";
                    fs.lblPopupTitle.Text = "Micro Inverter Attach";

                    drResult = fs.ShowDialog();
                    /*
                    if (drResult == DialogResult.No)
                    {
                        return false;
                    }
                    */
                }
                

                MPCF.ShowSuccessMessage(out_node, false);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private bool ValidateSiliconeManagement2()
        {
            TRSNode in_node = new TRSNode("SIL_UPDATE_IN");
            TRSNode out_node = new TRSNode("SIL_UPDATE_OUT");
            //TRSNode terminate_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                left_weight_rs = "NG";
                right_weight_rs = "NG";
                center_weight_rs = "NG";
                ratio_rs = "NG";
                ratio_rs2 = "NG";

                frame_lw_rs = "NG";
                frame_sw_rs = "NG";

                //2026/01/15
                miattach1_rs = "NG";
                miattach2_rs = "NG";

                in_node.AddString("FACTORY", MPCF.Trim(MPGV.gsFactory));
                //in_node.AddString("NAME", MPCF.Trim(cdvName.Text));
                //in_node.AddString("LINE", MPCF.Trim(soiLine.Value));
                //in_node.AddString("SILICONE_TYPE", MPCF.Trim(soiSilType.Value));

                //각 조건에 맞게 데이터 셋 
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab1.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab1.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@JB_ATTCH_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(soiJbLW.Text));
                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiJbRW.Text));
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiJbCW.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiJbCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                    /*
                    if (!numberCheck(MPCF.Trim(soiJbLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbCW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbRW.Text))) return false;
                     */
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab2.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab2.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_RATIO"));
                    in_node.AddString("POTTING_WEIGHT_A", MPCF.Trim(soiPotAW_Mixer1.Text));
                    in_node.AddString("POTTING_WEIGHT_B", MPCF.Trim(soiPotBW_Mixer1.Text));
                    /*
                   if (!numberCheck(MPCF.Trim(soiPotAW.Text))) return false;
                   if (!numberCheck(MPCF.Trim(soiPotBW.Text))) return false;
                      */
                    float potAw = float.Parse(MPCF.Trim(soiPotAW_Mixer1.Text));
                    float potBw = float.Parse(MPCF.Trim(soiPotBW_Mixer1.Text));
                    float potRatio = potAw / potBw;
                    in_node.AddString("POTTING_WEIGHT_RATIO", float.Parse(potRatio.ToString("0.00")).ToString());

                    //추가
                    float potAw2 = float.Parse(MPCF.Trim(soiPotAW_Mixer2.Text));
                    float potBw2 = float.Parse(MPCF.Trim(soiPotBW_Mixer2.Text));
                    float potRatio2 = potAw2 / potBw2;

                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(soiPotAW_Mixer2.Text)); // MI_ATTACH1
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(soiPotAW_Mixer2.Text));  // MI_ATTACH2
                    in_node.AddString("POTTING_WEIGHT_RATIO2", float.Parse(potRatio2.ToString("0.00")).ToString()); // RATIO2
                    //

                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiRatioCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    

                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab3.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab3.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(txtPotLW.Text));
                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiPotRW.Text));
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiPotCW.Text));
                    //in_node.AddString("SILICONE_SIDE", MPCF.Trim(soiComboSide.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiPotRCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');

                    /*
                    if (!numberCheck(MPCF.Trim(txtPotLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotRW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotCW.Text))) return false;
                       */
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab4.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab4.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", txtFrameSW.Text);
                    in_node.AddString("FRAME_LONG_WEIGHT", txtFrameLW.Text);
                    in_node.AddString("FRAME_MODULE_TYPE", cdvModuleType.Text);
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiFrameCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    
                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab5.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab5.Value));

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@MI_SIL_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(txtMIAttach1.Text)); //MI_ATTACH1
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(txtMIAttach2.Text));  //MI_ATTACH2
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiMIAttachCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    //in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');
                    /*
                    if (!numberCheck(MPCF.Trim(soiJbLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbCW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbRW.Text))) return false;
                     */
                }

                if (MPCF.CallService("CWIP", "CWIP_Validation_Silicone_Management", in_node, ref out_node) == false)
                {
                    return false;
                }



                if (out_node.ListCount > 0
                    && out_node.GetList(0).Count > 0)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // PROMPT가 값이 있는 경우 등록
                        if (out_node.GetList(0)[i].GetString("LEFT_WEIGHT_RS") != "")
                        {
                            left_weight_rs = out_node.GetList(0)[i].GetString("LEFT_WEIGHT_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("RIGHT_WEIGHT_RS") != "")
                        {
                            right_weight_rs = out_node.GetList(0)[i].GetString("RIGHT_WEIGHT_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("CENTER_WEIGHT_RS") != "")
                        {
                            center_weight_rs = out_node.GetList(0)[i].GetString("CENTER_WEIGHT_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("RATIO_RS") != "")
                        {
                            ratio_rs = out_node.GetList(0)[i].GetString("RATIO_RS");
                        }
                        //추가
                        if (out_node.GetList(0)[i].GetString("RATIO_RS2") != "")
                        {
                            ratio_rs2 = out_node.GetList(0)[i].GetString("RATIO_RS2");
                        }
                        if (out_node.GetList(0)[i].GetString("FRAME_SHORT_RS") != "")
                        {
                            frame_sw_rs = out_node.GetList(0)[i].GetString("FRAME_SHORT_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("FRAME_LONG_RS") != "")
                        {
                            frame_lw_rs = out_node.GetList(0)[i].GetString("FRAME_LONG_RS");
                        }

                        //2026/01/15
                        if (out_node.GetList(0)[i].GetString("MIATTACH1_RS") != "")
                        {
                            miattach1_rs = out_node.GetList(0)[i].GetString("MIATTACH1_RS");
                        }
                        if (out_node.GetList(0)[i].GetString("MIATTACH2_RS") != "")
                        {
                            miattach2_rs = out_node.GetList(0)[i].GetString("MIATTACH2_RS");
                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdateSiliconeManagement()
        {
            TRSNode in_node = new TRSNode("SIL_UPDATE_IN");
            TRSNode out_node = new TRSNode("SIL_UPDATE_OUT");
            //TRSNode terminate_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPCF.Trim(MPGV.gsFactory));
                in_node.AddString("NAME", ' ');
                //in_node.AddString("LINE", MPCF.Trim(soiLine.Value));
                //in_node.AddString("SILICONE_TYPE", MPCF.Trim(soiSilType.Value));
                in_node.AddString("CREATE_USER_ID", MPCF.Trim(MPGV.gsUserID));

                DateTime dtpDateTimeOut = new DateTime();
                String strDT = "";


                //각 조건에 맞게 데이터 셋 
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    if (dtDate_Input_Tab1.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtDate_Input_Tab1.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            strDT = String.Format("{0}{1:D4}00", dtpDateTimeOut.ToString("yyyyMMdd"), MPCF.Trim(cbTime_Input_Tab1.Value.ToString().Replace(":", "")));
                            in_node.AddString("CREATE_TIME", strDT);
                        }
                    }

                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab1.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab1.Value));

                    if (!numberCheck(MPCF.Trim(soiJbLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbCW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiJbRW.Text))) return false;

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@JB_ATTCH_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(soiJbLW.Text));
                    in_node.AddString("LEFT_WEIGHT_RESULT", left_weight_rs);

                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiJbRW.Text));
                    in_node.AddString("RIGHT_WEIGHT_RESULT", right_weight_rs);
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiJbCW.Text));
                    in_node.AddString("CENTER_WEIGHT_RESULT", center_weight_rs);
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiJbCont.Text));
                    in_node.AddString("RATIO_WEIGHT_RESULT", ' ');

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');

                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    if (dtDate_Input_Tab2.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtDate_Input_Tab2.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            strDT = String.Format("{0}{1:D4}00", dtpDateTimeOut.ToString("yyyyMMdd"), MPCF.Trim(cbTime_Input_Tab2.Value.ToString().Replace(":", "")));
                            in_node.AddString("CREATE_TIME", strDT);
                        }
                    }

                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab2.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab2.Value));

                    if (!numberCheck(MPCF.Trim(soiPotAW_Mixer1.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotBW_Mixer1.Text))) return false;

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_RATIO"));
                    in_node.AddString("POTTING_WEIGHT_A", MPCF.Trim(soiPotAW_Mixer1.Text));
                    in_node.AddString("POTTING_WEIGHT_B", MPCF.Trim(soiPotBW_Mixer1.Text));

                    float potAw = float.Parse(MPCF.Trim(soiPotAW_Mixer1.Text));
                    float potBw = float.Parse(MPCF.Trim(soiPotBW_Mixer1.Text));
                    float potRatio = potAw / potBw;
                    in_node.AddString("POTTING_WEIGHT_RATIO", float.Parse(potRatio.ToString("0.00")).ToString());
                    in_node.AddString("RATIO_WEIGHT_RESULT", ratio_rs);

                    //추가
                    float potAw2 = float.Parse(MPCF.Trim(soiPotAW_Mixer2.Text));
                    float potBw2 = float.Parse(MPCF.Trim(soiPotBW_Mixer2.Text));
                    float potRatio2 = potAw2 / potBw2;
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(soiPotAW_Mixer2.Text));   //MI_ATTACH1
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(soiPotBW_Mixer2.Text));    //MI_ATTACH2
                    in_node.AddString("FRAME_SHORT_RESULT", float.Parse(potRatio2.ToString("0.00")).ToString());//업데이트 시에는 POTTING_WEIGHT_RATIO2 대신 FRAME_MODULE_TYPE 사용
                    //

                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiRatioCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("LEFT_WEIGHT_RESULT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT_RESULT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT_RESULT", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    

                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    if (dtDate_Input_Tab3.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtDate_Input_Tab3.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            strDT = String.Format("{0}{1:D4}00", dtpDateTimeOut.ToString("yyyyMMdd"), MPCF.Trim(cbTime_Input_Tab3.Value.ToString().Replace(":", "")));
                            in_node.AddString("CREATE_TIME", strDT);
                        }
                    }

                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab3.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab3.Value));

                    if (!numberCheck(MPCF.Trim(txtPotLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotRW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(soiPotCW.Text))) return false;

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_WEIGHT"));
                    in_node.AddString("LEFT_WEIGHT", MPCF.Trim(txtPotLW.Text));
                    in_node.AddString("LEFT_WEIGHT_RESULT", left_weight_rs);
                    in_node.AddString("RIGHT_WEIGHT", MPCF.Trim(soiPotRW.Text));
                    in_node.AddString("RIGHT_WEIGHT_RESULT", right_weight_rs);
                    in_node.AddString("CENTER_WEIGHT", MPCF.Trim(soiPotCW.Text));
                    in_node.AddString("CENTER_WEIGHT_RESULT", center_weight_rs);
                    //in_node.AddString("SILICONE_SIDE", MPCF.Trim(soiComboSide.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiPotRCont.Text));
                    
                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("RATIO_WEIGHT_RESULT", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    if (dtDate_Input_Tab4.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtDate_Input_Tab4.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            strDT = String.Format("{0}{1:D4}00", dtpDateTimeOut.ToString("yyyyMMdd"), MPCF.Trim(cbTime_Input_Tab4.Value.ToString().Replace(":", "")));
                            in_node.AddString("CREATE_TIME", strDT);
                        }
                    }

                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab4.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab4.Value));

                    if (!numberCheck(MPCF.Trim(txtFrameLW.Text))) return false;
                    if (!numberCheck(MPCF.Trim(txtFrameSW.Text))) return false;

                    in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(txtFrameSW.Text));
                    in_node.AddString("FRAME_SHORT_RESULT", frame_sw_rs);
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(txtFrameLW.Text));
                    in_node.AddString("FRAME_LONG_RESULT", frame_lw_rs);
                    in_node.AddString("FRAME_MODULE_TYPE", MPCF.Trim(cdvModuleType.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');
                    //in_node.AddString("SILICONE_SIDE", MPCF.Trim(soiComboSide.Text));
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiFrameCont.Text));

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("MI_ATTACH1", ' ');
                    //in_node.AddString("MI_ATTACH2", ' ');
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    if (dtDate_Input_Tab5.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(dtDate_Input_Tab5.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            strDT = String.Format("{0}{1:D4}00", dtpDateTimeOut.ToString("yyyyMMdd"), MPCF.Trim(cbTime_Input_Tab5.Value.ToString().Replace(":", "")));
                            in_node.AddString("CREATE_TIME", strDT);
                        }
                    }

                    in_node.AddString("LINE", MPCF.Trim(cbLine_Input_Tab5.Value));
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(cbSiliconeType_Input_Tab5.Value));

                    if (!numberCheck(MPCF.Trim(txtMIAttach1.Text))) return false;
                    if (!numberCheck(MPCF.Trim(txtMIAttach2.Text))) return false;


                    in_node.AddString("TABLE_NAME", MPCF.Trim("@MI_SIL_WEIGHT"));
                    in_node.AddString("FRAME_SHORT_WEIGHT", MPCF.Trim(txtMIAttach1.Text)); //MI_ATTACH1
                    in_node.AddString("FRAME_SHORT_RESULT", miattach1_rs);
                    in_node.AddString("FRAME_LONG_WEIGHT", MPCF.Trim(txtMIAttach2.Text));  //MI_ATTACH2
                    in_node.AddString("FRAME_LONG_RESULT", miattach2_rs);
                    in_node.AddString("COMMENT_CONT", MPCF.Trim(soiMIAttachCont.Text));

                    in_node.AddString("LEFT_WEIGHT", ' ');
                    in_node.AddString("RIGHT_WEIGHT", ' ');
                    in_node.AddString("CENTER_WEIGHT", ' ');

                    in_node.AddString("POTTING_WEIGHT_A", ' ');
                    in_node.AddString("POTTING_WEIGHT_B", ' ');
                    in_node.AddString("POTTING_WEIGHT_RATIO", ' ');
                    in_node.AddString("SILICONE_SIDE", '-');

                    //in_node.AddString("FRAME_SHORT_WEIGHT", ' ');
                    //in_node.AddString("FRAME_LONG_WEIGHT", ' ');
                    in_node.AddString("FRAME_MODULE_TYPE", ' ');

                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Silicone_Management", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool numberCheck(String number)
        {
            string num = number;
            int returnVal = 0;
            decimal returnVal2 = 0;
            bool bl = int.TryParse(num, out returnVal);
            if (bl == false)
            {
                bl = decimal.TryParse(num, out returnVal2);
            }
            return bl;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear
            soiJbLW.Text = "";
            soiJbRW.Text = "";
            soiJbCW.Text = "";
            soiJbCont.Text = "";
            soiPotAW_Mixer1.Text = "";
            soiPotBW_Mixer1.Text = "";
            soiPotAW_Mixer2.Text = "";
            soiPotBW_Mixer2.Text = "";
            soiRatioCont.Text = "";
            txtPotLW.Text = "";
            soiPotRW.Text = "";
            soiPotCW.Text = "";
           // soiComboSide.Text = "";
            soiPotRCont.Text = "";
            txtFrameLW.Text = "";
            txtFrameSW.Text = "";
            cdvModuleType.Text = "";
            cdvModuleType.Description = "";
            soiFrameCont.Text = "";

            txtMIAttach1.Text = "";
            txtMIAttach2.Text = "";
            soiMIAttachCont.Text = "";

            MPCF.ClearList(this.spdDailyWorkList);
            MPCF.ClearList(this.soiSpread1);
            MPCF.ClearList(this.soiSpread2);
            MPCF.ClearList(this.frameWeight_Sheet);
            MPCF.ClearList(this.soiSpread3);
            

            cbLine_Input_Tab1.SelectedIndex = -1;
            cbLine_Input_Tab2.SelectedIndex = -1;
            cbLine_Input_Tab3.SelectedIndex = -1;
            cbLine_Input_Tab4.SelectedIndex = -1;
            cbLine_Input_Tab5.SelectedIndex = -1;

            cbSiliconeType_Input_Tab1.SelectedIndex = -1;
            cbSiliconeType_Input_Tab2.SelectedIndex = -1;
            cbSiliconeType_Input_Tab3.SelectedIndex = -1;
            cbSiliconeType_Input_Tab4.SelectedIndex = -1;
            cbSiliconeType_Input_Tab5.SelectedIndex = -1;

            DateTime nowDate = DateTime.Now;
            string strCurrTime = "";
            if (nowDate.Minute < 30)
            {
                strCurrTime = string.Format("{0:D2}:00", nowDate.Hour);
            }
            else
            {
                strCurrTime = string.Format("{0:D2}:30", nowDate.Hour);
            }
            for (int nIndex = 0; nIndex < cbTime_Input_Tab1.Items.Count; nIndex++)
            {
                string itemText = cbTime_Input_Tab1.Items[nIndex].ToString();
                if (itemText.Contains(strCurrTime))
                {
                    cbTime_Input_Tab1.SelectedIndex = nIndex;
                    cbTime_Input_Tab2.SelectedIndex = nIndex;
                    cbTime_Input_Tab3.SelectedIndex = nIndex;
                    cbTime_Input_Tab4.SelectedIndex = nIndex;
                    cbTime_Input_Tab5.SelectedIndex = nIndex;
                    break;
                }
            }



            dtDate_Input_Tab1.Value = DateTime.Today;
            dtDate_Input_Tab2.Value = DateTime.Today;
            dtDate_Input_Tab3.Value = DateTime.Today;
            dtDate_Input_Tab4.Value = DateTime.Today;
            dtDate_Input_Tab5.Value = DateTime.Today;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

       
        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewDailyWorkList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewDailyWorkList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                DateTime dtpDateTimeOut = new DateTime();
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("CREATE_TIME", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (soiLine != null && soiLine.Text != "")
                {
                    in_node.AddString("LINE", MPCF.Trim(soiLine.Value));
                }
                else
                {
                    in_node.AddString("LINE", "%");
                }

                if (soiSilType != null && soiSilType.Text != "")
                {
                    in_node.AddString("SILICONE_TYPE", MPCF.Trim(soiSilType.Value));
                }
                else
                {
                    in_node.AddString("SILICONE_TYPE", "%");
                }

                in_node.AddString("NAME", "%");

                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@JB_ATTCH_SIL_WEIGHT"));
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_RATIO"));
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_WEIGHT"));
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_WEIGHT"));
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@MI_SIL_WEIGHT"));
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Silicone_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                setSheetData(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }



        private bool setSheetData(TRSNode out_node)
        {
            SOISpread sheet = new SOISpread();
            TRSNode lot_list;
            if (tabControl1.SelectedTab.Text == "JB Attach")
            {
                MPCF.ClearList(this.spdDailyWorkList);
                sheet = spdDailyWorkList;
            }
            else if (tabControl1.SelectedTab.Text == "Potting Ratio")
            {
                MPCF.ClearList(this.soiSpread1);
                sheet = soiSpread1;
            }
            else if (tabControl1.SelectedTab.Text == "Potting Weight")
            {
                MPCF.ClearList(this.soiSpread2);
                sheet = soiSpread2;
            }
            else if (tabControl1.SelectedTab.Text == "Frame Weight")
            {
                MPCF.ClearList(this.frameWeight_Sheet);
                sheet = frameWeight_Sheet;
            }
            else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
            {
                MPCF.ClearList(this.soiSpread3);
                sheet = soiSpread3;
            }

            // Bind
            sheet.ActiveSheet.RowCount = out_node.GetList(0).Count;
            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {

                lot_list = out_node.GetList(0)[i];
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    InitDateCell(sheet, i, (int)JB_SILICONE_LIST.CREATE_DATE, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    InitTimeCell(sheet, i, (int)JB_SILICONE_LIST.CREATE_TIME, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.LINE_ID].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.RIGHT_WEIGHT].Value = lot_list.GetString("RIGHT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.CENTER_WEIGHT].Value = lot_list.GetString("CENTER_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.LEFT_WEIGHT].Value = lot_list.GetString("LEFT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");

                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio") //수정해야함
                {
                    InitDateCell(sheet, i, (int)RATIO_LIST.CREATE_DATE, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    InitTimeCell(sheet, i, (int)RATIO_LIST.CREATE_TIME, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.LINE_ID].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER1_POTTING_WEIGHT_A].Value = lot_list.GetString("POTTING_WEIGHT_A");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER1_POTTING_WEIGHT_B].Value = lot_list.GetString("POTTING_WEIGHT_B");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER1_POTTING_WEIGHT_RATIO].Value = lot_list.GetString("POTTING_WEIGHT_RATIO");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER2_POTTING_WEIGHT_A].Value = lot_list.GetString("FRAME_SHORT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER2_POTTING_WEIGHT_B].Value = lot_list.GetString("FRAME_LONG_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.MIXER2_POTTING_WEIGHT_RATIO].Value = lot_list.GetString("FRAME_SHORT_RESULT"); // 임의로 지정
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    InitDateCell(sheet, i, (int)SILICONE_LIST.CREATE_DATE, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    InitTimeCell(sheet, i, (int)SILICONE_LIST.CREATE_TIME, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.LINE_ID].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.RIGHT_WEIGHT].Value = lot_list.GetString("RIGHT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.LEFT_WEIGHT].Value = lot_list.GetString("LEFT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.CENTER_WEIGHT].Value = lot_list.GetString("CENTER_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    InitDateCell(sheet, i, (int)FRAME_LIST.CREATE_DATE, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    InitTimeCell(sheet, i, (int)FRAME_LIST.CREATE_TIME, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.CREATE_TIME].Value = MPCF.ToDate(lot_list.GetString("CREATE_TIME"));
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.LINE_ID].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.MODULE_TYPE].Value = lot_list.GetString("FRAME_MODULE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.SHORT_WEIGHT].Value = lot_list.GetString("FRAME_SHORT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.LONG_WEIGHT].Value = lot_list.GetString("FRAME_LONG_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Micro Inverter Attach")
                {
                    InitDateCell(sheet, i, (int)MICRO_INVERTER_ATTACH_LIST.CREATE_DATE, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    InitTimeCell(sheet, i, (int)MICRO_INVERTER_ATTACH_LIST.CREATE_TIME, MPCF.ToDate(lot_list.GetString("CREATE_TIME")), false);
                    sheet.ActiveSheet.Cells[i, (int)MICRO_INVERTER_ATTACH_LIST.LINE_ID].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)MICRO_INVERTER_ATTACH_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)MICRO_INVERTER_ATTACH_LIST.MI_ATTACH1].Value = lot_list.GetString("FRAME_SHORT_WEIGHT"); //MI_ATTACH1
                    sheet.ActiveSheet.Cells[i, (int)MICRO_INVERTER_ATTACH_LIST.MI_ATTACH2].Value = lot_list.GetString("FRAME_LONG_WEIGHT");  //MI_ATTACH2
                    sheet.ActiveSheet.Cells[i, (int)MICRO_INVERTER_ATTACH_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");

                }




            }
            //MPCF.FitColumnHeader(sheet);
            MPCF.FitColumnHeader(sheet);
            //lblSumQty_W.Text = sheet.ActiveSheet.RowCount.ToString();
            return true;
        }

        private void cbSiliconeType_Input_Tab4_ValueChanged(object sender, EventArgs e)
        {
            cdvModuleType.Text = string.Empty;
            cdvModuleType.Focus();
        }




        bool InitDateCell(FarPoint.Win.Spread.FpSpread spdData, int i_row, int i_col, DateTime date /*string strDate*/, bool bEditable)
        {
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType;

            try
            {
                dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                //dateCellType.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
                dateCellType.UserDefinedFormat = "yyyy-MM-dd";
                dateCellType.DateDefault = System.DateTime.Today;
                if (bEditable)
                {
                    dateCellType.DropDownButton = true;
                }
                else
                {
                    dateCellType.DropDownButton = false;
                }

                spdData.Sheets[0].Cells[i_row, i_col].CellType = dateCellType;
                spdData.Sheets[0].Cells[i_row, i_col].Value = date;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        bool InitTimeCell(FarPoint.Win.Spread.FpSpread spdData, int i_row, int i_col, DateTime date /*string strDate*/, bool bEditable)
        {
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType;

            try
            {
                dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                //dateCellType.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
                dateCellType.UserDefinedFormat = "HH:mm";
                dateCellType.DateDefault = System.DateTime.Today;
                if (bEditable)
                {
                    dateCellType.DropDownButton = true;
                }
                else
                {
                    dateCellType.DropDownButton = false;
                }

                spdData.Sheets[0].Cells[i_row, i_col].CellType = dateCellType;
                spdData.Sheets[0].Cells[i_row, i_col].Value = date;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


    }
}
