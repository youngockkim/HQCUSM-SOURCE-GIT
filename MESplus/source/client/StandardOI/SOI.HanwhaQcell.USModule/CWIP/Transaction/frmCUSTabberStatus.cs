using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

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
    public partial class frmCUSTabberStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;


        public enum TABBER_STATUS
        {
            NO,
            EQ,
            LEFT,
            RIGHT
        }

        #endregion

        #region Constructor

        public frmCUSTabberStatus()
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
            // Init
            //LINE 가져오기.

            // Init
            //GET LINE 
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
            in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
            in_node.AddString("LINE_LOCATION", "E1");

            int i;
            if (MPCF.CallService("CWIP", "CWIP_View_Line_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    cboLineId.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }

            // Init
            //Dep. Requested 가져오기.

            // Init
            //GET LINE 
            TRSNode in_node_c = new TRSNode("VIEW_CGCM_DATA_IN");
            TRSNode out_node_c = new TRSNode("VIEW_CGCM_DATA_OUT");
            TRSNode out_list_c;
            MPCF.SetInMsg(in_node);

            in_node_c.ProcStep = '1';
            in_node_c.AddString("FACTORY", MPGV.gsFactory);
            in_node_c.AddString("TYPE_1", "DEP_REQUESTED");
            in_node_c.AddString("TYPE_2", "DEP");
            int j;
            if (MPCF.CallService("CBAS", "CBAS_View_CGCMTBLDAT_List", in_node_c, ref out_node_c) == true)
            {
                for (j = 0; j < out_node_c.GetList(0).Count; j++)
                {
                    out_list_c = out_node_c.GetList(0)[j];

                    soiTabberLDep01.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep01.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep02.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep02.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep03.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep03.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep04.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep04.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep05.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep05.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep06.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep06.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep07.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep07.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep08.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep08.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep09.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep09.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep10.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep10.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep11.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep11.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberLDep12.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
                    soiTabberRDep12.Items.Add(out_list_c.GetString("TYPE_3"), out_list_c.GetString("DATA_1"));
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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        //LINE CHANGE EVENT
        //btnProcess_Click();

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (ViewTabberStatusList() == false)
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

        public String LPAD(String downtime)
        {
            String LPADStr = "";
            String[] dt = downtime.Split(':');

            for (int i = 0; i < dt.Length; i++)
            {
                if (dt[i].Length == 1)
                {
                    dt[i] = "0" + dt[i];
                }
                if (i < dt.Length - 1)
                {
                    LPADStr = LPADStr + dt[i] + ":";
                }
                else
                {
                    LPADStr = LPADStr + dt[i];
                }
            }
            return LPADStr;
        }

        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewTabberStatusList()
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_TABBER_STATUS_IN");
                TRSNode out_node = new TRSNode("LIST");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", cboLineId.Value);

                if (MPCF.CallService("CWIP", "CWIP_View_Tabber_Status", in_node, ref out_node) == false)
                {
                    return false;
                }

                int max_count = out_node.GetList(0).Count;
                string res_id = string.Empty;
                string last_udpate_time = string.Empty;
                string last_udpate_time_tmp = string.Empty;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (i == 0)
                    {
                        res_id = out_node.GetList(0)[i].GetString("RES_ID").Substring(3, 2);
                        soiTabber1.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber1.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL01.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR01.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown01.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown01.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep01.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep01.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 1)
                    {
                        soiTabber2.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber2.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL02.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR02.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown02.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown02.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep02.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep02.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 2)
                    {
                        soiTabber3.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber3.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL03.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR03.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown03.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown03.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep03.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep03.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 3)
                    {
                        soiTabber4.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber4.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL04.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR04.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown04.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown04.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep04.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep04.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 4)
                    {
                        soiTabber5.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber5.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL05.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR05.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown05.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown05.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep05.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep05.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 5)
                    {
                        soiTabber6.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber6.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL06.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR06.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown06.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown06.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep06.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep06.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 6)
                    {
                        soiTabber7.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber7.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL07.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR07.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown07.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown07.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep07.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep07.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 7)
                    {
                        soiTabber8.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber8.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL08.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR08.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown08.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown08.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep08.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep08.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 8)
                    {
                        soiTabber9.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber9.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL09.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR09.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown09.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown09.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep09.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep09.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 9)
                    {
                        soiTabber10.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber10.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL10.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR10.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown10.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown10.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep10.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep10.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 10)
                    {
                        soiTabber11.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber11.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL11.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR11.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown11.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown11.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep11.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep11.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }
                    else if (i == 11)
                    {
                        soiTabber12.Tag = out_node.GetList(0)[i].GetString("RES_ID");
                        soiTabber12.Text = out_node.GetList(0)[i].GetString("RES_DESC");
                        soiTabberL12.Text = out_node.GetList(0)[i].GetString("COMMENT_1");
                        soiTabberR12.Text = out_node.GetList(0)[i].GetString("COMMENT_2");
                        soiTabberLDown12.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_2"));
                        soiTabberRDown12.Text = LPAD(out_node.GetList(0)[i].GetString("CMF_4"));
                        soiTabberLDep12.Value = out_node.GetList(0)[i].GetString("CMF_3");
                        soiTabberRDep12.Value = out_node.GetList(0)[i].GetString("CMF_5");
                    }

                    if (out_node.GetList(0)[i].GetString("UPDATE_TIME").Length == 14)
                    {
                        if (i == 0)
                        {
                            last_udpate_time = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();
                        }
                        else
                        {
                            last_udpate_time_tmp = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();

                            if (DateTime.Parse(MPCF.MakeDateFormat(last_udpate_time, DATE_TIME_FORMAT.DATETIME)) < DateTime.Parse(MPCF.MakeDateFormat(last_udpate_time_tmp, DATE_TIME_FORMAT.DATETIME)))
                            {
                                last_udpate_time = out_node.GetList(0)[i].GetString("UPDATE_TIME").ToString();
                            }
                        }
                    }
                }

                if (last_udpate_time.Length == 14)
                {
                    soiGroupBox1.Text = "Tabber Status - " + res_id + "(Time: " + last_udpate_time.Substring(8, 2) + ":" + last_udpate_time.Substring(10, 2) + ")";
                }
                else
                {
                    soiGroupBox1.Text = "Tabber Status - " + res_id + "(Time: xx:xx)";
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        /// 
        /*
        public string ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return "";
                }


                return out_node.GetString("USER_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return "";
            }
        }
        */


        //UPDATE
        private bool Update_Tabber_Status_List()
        {
            TRSNode in_node = new TRSNode("TRAN_LIST");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode work_list = null;

            try
            {
                MPCF.SetInMsg(in_node);

                for (int i = 0; i < 12; i++)
                {
                    string resId = String.Empty;
                    string comment1 = String.Empty;
                    string comment2 = String.Empty;
                    string depRequesteL = String.Empty;
                    string depRequesteR = String.Empty;

                    if (i == 0)
                    {
                        if (soiTabber1.Tag == null)
                            continue;

                        resId = soiTabber1.Tag.ToString();
                        comment1 = soiTabberL01.Text;
                        comment2 = soiTabberR01.Text;
                        depRequesteL = (String)soiTabberLDep01.Value;
                        depRequesteR = (String)soiTabberRDep01.Value;
                    }
                    else if (i == 1)
                    {
                        if (soiTabber2.Tag == null)
                            continue;

                        resId = soiTabber2.Tag.ToString();
                        comment1 = soiTabberL02.Text;
                        comment2 = soiTabberR02.Text;
                        depRequesteL = (String)soiTabberLDep02.Value;
                        depRequesteR = (String)soiTabberRDep02.Value;
                    }
                    else if (i == 2)
                    {
                        if (soiTabber3.Tag == null)
                            continue;

                        resId = soiTabber3.Tag.ToString();
                        comment1 = soiTabberL03.Text;
                        comment2 = soiTabberR03.Text;
                        depRequesteL = (String)soiTabberLDep03.Value;
                        depRequesteR = (String)soiTabberRDep03.Value;
                    }
                    else if (i == 3)
                    {
                        if (soiTabber4.Tag == null)
                            continue;

                        resId = soiTabber4.Tag.ToString();
                        comment1 = soiTabberL04.Text;
                        comment2 = soiTabberR04.Text;
                        depRequesteL = (String)soiTabberLDep04.Value;
                        depRequesteR = (String)soiTabberRDep04.Value;
                    }
                    else if (i == 4)
                    {
                        if (soiTabber5.Tag == null)
                            continue;

                        resId = soiTabber5.Tag.ToString();
                        comment1 = soiTabberL05.Text;
                        comment2 = soiTabberR05.Text;
                        depRequesteL = (String)soiTabberLDep05.Value;
                        depRequesteR = (String)soiTabberRDep05.Value;
                    }
                    else if (i == 5)
                    {
                        if (soiTabber6.Tag == null)
                            continue;

                        resId = soiTabber6.Tag.ToString();
                        comment1 = soiTabberL06.Text;
                        comment2 = soiTabberR06.Text;
                        depRequesteL = (String)soiTabberLDep06.Value;
                        depRequesteR = (String)soiTabberRDep06.Value;
                    }
                    else if (i == 6)
                    {
                        if (soiTabber7.Tag == null)
                            continue;

                        resId = soiTabber7.Tag.ToString();
                        comment1 = soiTabberL07.Text;
                        comment2 = soiTabberR07.Text;
                        depRequesteL = (String)soiTabberLDep07.Value;
                        depRequesteR = (String)soiTabberRDep07.Value;
                    }
                    else if (i == 7)
                    {
                        if (soiTabber8.Tag == null)
                            continue;

                        resId = soiTabber8.Tag.ToString();
                        comment1 = soiTabberL08.Text;
                        comment2 = soiTabberR08.Text;
                        depRequesteL = (String)soiTabberLDep08.Value;
                        depRequesteR = (String)soiTabberRDep08.Value;
                    }
                    else if (i == 8)
                    {
                        if (soiTabber9.Tag == null)
                            continue;

                        resId = soiTabber9.Tag.ToString();
                        comment1 = soiTabberL09.Text;
                        comment2 = soiTabberR09.Text;
                        depRequesteL = (String)soiTabberLDep09.Value;
                        depRequesteR = (String)soiTabberRDep09.Value;
                    }
                    else if (i == 9)
                    {
                        if (soiTabber10.Tag == null)
                            continue;

                        resId = soiTabber10.Tag.ToString();
                        comment1 = soiTabberL10.Text;
                        comment2 = soiTabberR10.Text;
                        depRequesteL = (String)soiTabberLDep10.Value;
                        depRequesteR = (String)soiTabberRDep10.Value;
                    }
                    else if (i == 10)
                    {
                        if (soiTabber11.Tag == null)
                            continue;

                        resId = soiTabber11.Tag.ToString();
                        comment1 = soiTabberL11.Text;
                        comment2 = soiTabberR11.Text;
                        depRequesteL = (String)soiTabberLDep11.Value;
                        depRequesteR = (String)soiTabberRDep11.Value;
                    }
                    else if (i == 11)
                    {
                        if (soiTabber12.Tag == null)
                            continue;

                        resId = soiTabber12.Tag.ToString();
                        comment1 = soiTabberL12.Text;
                        comment2 = soiTabberR12.Text;
                        depRequesteL = (String)soiTabberLDep12.Value;
                        depRequesteR = (String)soiTabberRDep12.Value;
                    }

                    if (string.IsNullOrEmpty(resId))
                        continue;

                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("FACTORY", MPGV.gsFactory);
                    work_list.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                    work_list.AddString("OPER", MPCF.Trim(HQGC.OPER_M2000));
                    work_list.AddString("RES_ID", resId);
                    work_list.AddString("COMMENT_1", MPCF.Trim(comment1));
                    work_list.AddString("COMMENT_2", MPCF.Trim(comment2));
                    if (MPCF.Trim(comment1).Equals(""))
                    {

                        depRequesteL = String.Empty;
                    }
                    else
                    {
                        if (MPCF.Trim(depRequesteL).Equals(""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            if (i == 0)
                            {
                                MPCF.SetFocus(soiTabberLDep01);
                            }
                            else if (i == 1)
                            {
                                MPCF.SetFocus(soiTabberLDep02);
                            }
                            else if (i == 2)
                            {
                                MPCF.SetFocus(soiTabberLDep03);
                            }
                            else if (i == 3)
                            {
                                MPCF.SetFocus(soiTabberLDep04);
                            }
                            else if (i == 4)
                            {
                                MPCF.SetFocus(soiTabberLDep05);
                            }
                            else if (i == 5)
                            {
                                MPCF.SetFocus(soiTabberLDep06);
                            }
                            else if (i == 6)
                            {
                                MPCF.SetFocus(soiTabberLDep07);
                            }
                            else if (i == 7)
                            {
                                MPCF.SetFocus(soiTabberLDep08);
                            }
                            else if (i == 8)
                            {
                                MPCF.SetFocus(soiTabberLDep09);
                            }
                            else if (i == 9)
                            {
                                MPCF.SetFocus(soiTabberLDep10);
                            }
                            else if (i == 10)
                            {
                                MPCF.SetFocus(soiTabberLDep11);
                            }
                            else if (i == 11)
                            {
                                MPCF.SetFocus(soiTabberLDep12);
                            }
                            return false;
                        }
                    }
                    if (MPCF.Trim(comment2).Equals(""))
                    {
                        depRequesteR = String.Empty;
                    }
                    else
                    {
                        if (MPCF.Trim(depRequesteR).Equals(""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            if (i == 0)
                            {
                                MPCF.SetFocus(soiTabberRDep01);
                            }
                            else if (i == 1)
                            {
                                MPCF.SetFocus(soiTabberRDep02);
                            }
                            else if (i == 2)
                            {
                                MPCF.SetFocus(soiTabberRDep03);
                            }
                            else if (i == 3)
                            {
                                MPCF.SetFocus(soiTabberRDep04);
                            }
                            else if (i == 4)
                            {
                                MPCF.SetFocus(soiTabberRDep05);
                            }
                            else if (i == 5)
                            {
                                MPCF.SetFocus(soiTabberRDep06);
                            }
                            else if (i == 6)
                            {
                                MPCF.SetFocus(soiTabberRDep07);
                            }
                            else if (i == 7)
                            {
                                MPCF.SetFocus(soiTabberRDep08);
                            }
                            else if (i == 8)
                            {
                                MPCF.SetFocus(soiTabberRDep09);
                            }
                            else if (i == 9)
                            {
                                MPCF.SetFocus(soiTabberRDep10);
                            }
                            else if (i == 10)
                            {
                                MPCF.SetFocus(soiTabberRDep11);
                            }
                            else if (i == 11)
                            {
                                MPCF.SetFocus(soiTabberRDep12);
                            }
                            return false;
                        }
                    }
                    work_list.AddString("CMF_3", MPCF.Trim(depRequesteL));
                    work_list.AddString("CMF_5", MPCF.Trim(depRequesteR));

                }


                if (MPCF.CallService("CWIP", "CWIP_Update_Tabber_Status", in_node, ref out_node) == false)
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

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Update_Tabber_Status_List() == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cboLineId_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

    }
}
