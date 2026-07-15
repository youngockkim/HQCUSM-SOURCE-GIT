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

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSViewSiliconeList : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        public enum JB_SILICONE_LIST
        {
            CREATE_TIME,
            LINE,
            NAME,
            SILICONE_TYPE,
            RIGHT_WEIGHT,
            RIGHT_WEIGHT_RESULT,
            CENTER_WEIGHT,
            CENTER_WEIGHT_RESULT,
            LEFT_WEIGHT,
            LEFT_WEIGHT_RESULT,
            COMMENT_CONT
        }

        public enum RATIO_LIST
        {
            CREATE_TIME,
            LINE,
            NAME,
            SILICONE_TYPE,
            POTTING_WEIGHT_A,
            POTTING_WEIGHT_B,
            POTTING_WEIGHT_RATIO,
            RATIO_WEIGHT_RESULT,
            COMMENT_CONT
        }

        public enum SILICONE_LIST
        {
            CREATE_TIME,
            LINE,
            NAME,
            SILICONE_TYPE,
            RIGHT_WEIGHT,
            RIGHT_WEIGHT_RESULT,
            CENTER_WEIGHT,
            CENTER_WEIGHT_RESULT,
            LEFT_WEIGHT,
            LEFT_WEIGHT_RESULT,
            COMMENT_CONT
        }

        public enum FRAME_LIST
        {
            CREATE_TIME,
            LINE,
            NAME,
            SILICONE_TYPE,
            MODULE_TYPE,
            SHORT_WEIGHT,
            SHORT_WEIGHT_RESULT,
            LONG_WEIGHT,
            LONG_WEIGHT_RESULT,
            COMMENT_CONT
        }

        #endregion

        #region Constructor

        public frmCUSViewSiliconeList()
        {
            InitializeComponent();

            // Init
            dtpFromW.Value = DateTime.Today;

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
                }
            }

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSViewDailyWork_Load(object sender, EventArgs e)
        {
            // Init
            dtpFromW.Value = DateTime.Today;

            // Init
            //GET LINE 
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

            int i;
            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    soiLine.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
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
                }
            }

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
        private void frmCUSViewSiliconeList_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }


        private void cdvName_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@SILICONE_NAME"));

                string[] header = new string[] { "Name", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvName.Text = cdvName.Show(cdvName, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvName);

                // Validation
                if (string.IsNullOrEmpty(cdvName.Text) == true)
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
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
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


        
        #endregion
        
        #region Functions


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
                if (dtpFromW.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFromW.Value.ToString(), out dtpDateTimeOut);
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

                if (cdvName != null && cdvName.Text != "" && cdvName.Text != "All")
                {
                    in_node.AddString("NAME", MPCF.Trim(cdvName.Text));
                }
                else
                {
                    in_node.AddString("NAME", "%");
                }



                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@JB_ATTCH_SIL_WEIGHT"));
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_RATIO"));
                }else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@POTT_SIL_WEIGHT"));
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    in_node.AddString("TABLE_NAME", MPCF.Trim("@FRAME_MODULE_WEIGHT"));
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
            
            // Bind
            sheet.ActiveSheet.RowCount = out_node.GetList(0).Count;
            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {

                lot_list = out_node.GetList(0)[i];
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.CREATE_TIME].Value = MPCF.ToDate(lot_list.GetString("CREATE_TIME"));
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.LINE].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.NAME].Value = lot_list.GetString("NAME");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.RIGHT_WEIGHT].Value = lot_list.GetString("RIGHT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.RIGHT_WEIGHT_RESULT].Value = lot_list.GetString("RIGHT_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.LEFT_WEIGHT].Value = lot_list.GetString("LEFT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.LEFT_WEIGHT_RESULT].Value = lot_list.GetString("LEFT_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.CENTER_WEIGHT].Value = lot_list.GetString("CENTER_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.CENTER_WEIGHT_RESULT].Value = lot_list.GetString("CENTER_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)JB_SILICONE_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.CREATE_TIME].Value = MPCF.ToDate(lot_list.GetString("CREATE_TIME"));
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.LINE].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.NAME].Value = lot_list.GetString("NAME");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.POTTING_WEIGHT_A].Value = lot_list.GetString("POTTING_WEIGHT_A");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.POTTING_WEIGHT_B].Value = lot_list.GetString("POTTING_WEIGHT_B");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.POTTING_WEIGHT_RATIO].Value = lot_list.GetString("POTTING_WEIGHT_RATIO");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.RATIO_WEIGHT_RESULT].Value = lot_list.GetString("RATIO_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)RATIO_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.CREATE_TIME].Value = MPCF.ToDate(lot_list.GetString("CREATE_TIME"));
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.LINE].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.NAME].Value = lot_list.GetString("NAME");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.RIGHT_WEIGHT].Value = lot_list.GetString("RIGHT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.RIGHT_WEIGHT_RESULT].Value = lot_list.GetString("RIGHT_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.LEFT_WEIGHT].Value = lot_list.GetString("LEFT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.LEFT_WEIGHT_RESULT].Value = lot_list.GetString("LEFT_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.CENTER_WEIGHT].Value = lot_list.GetString("CENTER_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.CENTER_WEIGHT_RESULT].Value = lot_list.GetString("CENTER_WEIGHT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)SILICONE_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.CREATE_TIME].Value = MPCF.ToDate(lot_list.GetString("CREATE_TIME"));
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.LINE].Value = lot_list.GetString("LINE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.NAME].Value = lot_list.GetString("NAME");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.SILICONE_TYPE].Value = lot_list.GetString("SILICONE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.MODULE_TYPE].Value = lot_list.GetString("FRAME_MODULE_TYPE");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.SHORT_WEIGHT].Value = lot_list.GetString("FRAME_SHORT_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.SHORT_WEIGHT_RESULT].Value = lot_list.GetString("FRAME_SHORT_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.LONG_WEIGHT].Value = lot_list.GetString("FRAME_LONG_WEIGHT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.LONG_WEIGHT_RESULT].Value = lot_list.GetString("FRAME_LONG_RESULT");
                    sheet.ActiveSheet.Cells[i, (int)FRAME_LIST.COMMENT_CONT].Value = lot_list.GetString("COMMENT_CONT");
                }

                

                
            }
           //MPCF.FitColumnHeader(sheet);
            MPCF.FitColumnHeader(sheet);
            lblSumQty_W.Text = sheet.ActiveSheet.RowCount.ToString();
            return true;
        }


        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                SOISpread sheet = new SOISpread();
                string sheetText = string.Empty;
                if (tabControl1.SelectedTab.Text == "JB Attach")
                {
                    //MPCF.ClearList(this.spdDailyWorkList);
                    sheetText = "JB_Attach";                   
                    sheet = spdDailyWorkList;           
                }
                else if (tabControl1.SelectedTab.Text == "Potting Ratio")
                {
                    //MPCF.ClearList(this.soiSpread1);
                    sheetText = "Potting_Ratio";    
                    sheet = soiSpread1;
                   
                }
                else if (tabControl1.SelectedTab.Text == "Potting Weight")
                {
                    //MPCF.ClearList(this.soiSpread2);
                    sheetText = "Potting_Weight";   
                    sheet = soiSpread2;
                }
                else if (tabControl1.SelectedTab.Text == "Frame Weight")
                {
                    //MPCF.ClearList(this.soiSpread2);
                    sheetText = "Frame_Weight";
                    sheet = frameWeight_Sheet;
                }
              
                SaveFileDialog pop = new SaveFileDialog();
                pop.InitialDirectory = "C:\\";
                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(sheetText) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    sheet.Sheets[0].Protect = false;
                    sheet.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    sheet.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            cdvName.Text = "";
            soiSilType.Text = "";
            soiLine.Text = "";
        }

    }
}
