using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using System.IO;

namespace Miracom.BASCore.Transaction
{
    public partial class frmBASTranPrintDocument : Miracom.MESCore.TranForm32
    {
        #region " Windows Form auto generated code "
        public frmBASTranPrintDocument()
        {
            InitializeComponent();
        }
        #endregion

        #region " Constant Definition "

        private const int MAX_VALUE_COUNT = 500;
        private const string FORMAT_ID = "FORMAT_ID";

        #endregion

        #region "VariableDefinition"

        private bool b_load_flag;
        private string m_Screen_ID;
        //private string[] lotIDList = null;
        //private string lotID;
        //private bool b_chk_manaul_flag;
        public string s_Format_ID;
        #endregion

        #region " Function Definition "       

        /// <summary>
        /// Check Condition
        /// </summary>
        /// <param name="ProcStep">Step</param>        
        /// <returns>true or false</returns>        
        private bool CheckCondition(char ProcStep)
        {

            switch (ProcStep)
            {
                case 'V':
                    
                    break;
                case MPGC.MP_STEP_UPDATE:
        
                    break;
            }

            return true;

        }        
        
        /// <summary>
        /// 프린트 옵션 설정을 한다.
        /// </summary>        
        /// <returns>true or false</returns>
        private bool SetOptionFormat()
        {
            TRSNode in_node = new TRSNode("View_Format_ID_IN");
            TRSNode out_node = new TRSNode("View_Format_ID_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("DOF_ID", m_Screen_ID);

                if (MPCR.CallService("BAS", "BAS_View_Document_Format", in_node, ref out_node) == false)
                {
                    return false;
                }

                base.TOP_MARGIN = MPCF.ToInt(out_node.GetDouble("TOP_SPACE"));
                base.LEFT_MARGIN = MPCF.ToInt(out_node.GetDouble("LEFT_SPACE"));
                base.RIGHT_MARGIN = MPCF.ToInt(out_node.GetDouble("RIGHT_SPACE"));
                base.BOTTOM_MARGIN = MPCF.ToInt(out_node.GetDouble("BOTTOM_SPACE"));

                if(out_node.GetString("DIRECTION_TYPE") == "POT")
                    base.PRINT_TYPE = true;
                else
                    base.PRINT_TYPE = false;

                base.PAPER_SIZE = new Size(out_node.GetInt("PAGE_WIDTH"), out_node.GetInt("PAGE_HEIGHT"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 관계 설정을 탐색하여 Screen ID를 가져온다
        /// </summary>
        /// <returns></returns>
        private bool GetFormatID()
        {
            TRSNode in_node = new TRSNode("Get_Format_ID_IN");
            TRSNode out_node = new TRSNode("Get_Format_ID_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", txtLotID.Text);

                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_MATERIAL);
                in_node.AddString("ATTR_NAME", "FORMAT_ID");
                in_node.AddString("ATTR_KEY", out_node.GetString("MAT_ID") + " : " + out_node.GetInt("MAT_VER").ToString() );

                if (MPCR.CallService("BAS", "BAS_View_Attribute", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                m_Screen_ID = out_node.GetString("ATTR_VALUE");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Lot Information
        /// </summary>
        /// <param name="s_lot_id"> Lot 번호</param>        
        /// <returns>true or false</returns>
        protected override bool ViewLotInfo(string s_lot_id)
        {
            base.USE_FLEXIBLE_SCREEN_SERVICE_FLAG = true;

            MPGV.giSpanRow = 0;
            MPGV.giSpanCol = 0;

            if ( MPCF.Trim(cdvManualFormat.Text) != "" && chkManual.Checked == true)
            {
                m_Screen_ID = MPCF.Trim(cdvManualFormat.Text);
            }
            else
            {
                if (GetFormatID() == false)
                    return false;
            }

            base.SCREEN_ID = m_Screen_ID;
            base.VIEW_LOT_SERVICE_NAME = "BAS_View_Tcard_Info";
            base.VIEW_LOT_MODULE_NAME = "BAS";
            base.VIEW_LOT_PROC_STEP = '1';

            if (chkHistory.Checked == true)
                base.VIEW_HISTORY_FLAG = 'Y';
            else
                base.VIEW_HISTORY_FLAG = 'N';

            if (base.ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }

            base.InitFlexibleScreen();
            if (SetOptionFormat() == false)
                return false;

            return true;
        }

        #endregion

        #region " Event Definition "

        private void btnProcess_Click(object sender, EventArgs e)
        {                                   
            base.PRINT = 0;
        }

        private void frmBASTranPrintDocument_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;
                if (MPCF.Trim(MPCF.Trim(txtLotID.Text)) != "")
                    return;
                MPCF.FieldClear(this,cdvManualFormat,txtLotID,chkManual);

                cdvManualFormat.Visible = false;
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                b_load_flag = true;
            }            
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewLotInfo(txtLotID.Text);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text != "")
                ViewLotInfo(txtLotID.Text);
        }

        #endregion

        private void cdvManualFormat_ButtonPress(object sender, EventArgs e)
        {
            cdvManualFormat.Init();
            MPCF.InitListView(cdvManualFormat.GetListView);
            cdvManualFormat.Columns.Add("Dof_Id", 50, HorizontalAlignment.Left);
            cdvManualFormat.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvManualFormat.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvManualFormat.GetListView, '1', "B@FORMAT_ID");
        }

        private void chkManual_Click(object sender, EventArgs e)
        {
            if (chkManual.Checked == true)
            {
                cdvManualFormat.Visible = true;
            }
            else 
            {
                cdvManualFormat.Visible = false;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtLotID.Text) != "")
            {
                ViewLotInfo(txtLotID.Text);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (var form = new SaveFileDialog())
            {
                form.Filter = "Excel File|*.xls";
                form.DefaultExt = "xls";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    udcLotInfor.ScreenSpread.SaveExcel(form.FileName);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            base.PRINT = 0;
        }
    }
}
