using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    public partial class frmCUSViewPackingList : SOIBaseForm03
    {
        #region Property

        private bool bIsShown = false;
        const int ENTER = 13;

        #endregion

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        bool b_load_flag;

        private enum LOT_LIST : int
        {
            COL_NO = 0,
            COL_FACTORY,
            COL_BOX_ID,
            COL_LOT_ID,
            COL_FG_ID,
            COL_MAT_ID,
            COL_MAT_SHORT_DESC,
            COL_CREATE_TIME,
            COL_BOX_CLOSE
        }

        #endregion

        #region Constructor

        public frmCUSViewPackingList()
        {
            InitializeComponent();
        }

        #endregion

        #region " Control Event Definition "

        #endregion

        #region Event Handler

        /// <summary>
        /// Form Load
        /// Caption Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSViewPackingList_Load(object sender, EventArgs e)
        {
            ClearData('1');
            // Caption 변환
            MPCF.ConvertCaption(this);

            dtFrDate.Value = DateTime.Now.AddDays(-7);
            dtToDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Form Shown (Load --> Activate --> Shown)
        /// Focus control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSViewPackingList_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                bIsShown = true;
            }
        }

        private void frmCUSViewPackingList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                b_load_flag = true;
            }
        }

        #endregion

        #region Function

        #region " ClearData "
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this.pnlMiddle);
                    MPCF.ClearList(spdList);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        #endregion

        #region " CheckCondition "

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":

                    if (cdvBoxID.Text == string.Empty && txtModuleID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvBoxID.Focus();
                        return false;
                    }

                    break;

                case "CLOSE":

                    if (cdvBoxID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvBoxID.Focus();
                        return false;
                    }

                    if(spdList.ActiveSheet.RowCount ==0)
                    {
                        MPCF.ShowMsgBox("Data가 존재하지 않습니다.");
                        return false;
                    }

                    break;
            }

            return true;
        }

        #endregion        

        #endregion

        private bool ProcPrint()
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            int iRowCount;
            string sProdID;

            try
            {
                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "ViewPackingList";
                udcPrint.ScreenSpread.Tag = "ViewPackingList";
                udcPrint.ProcStep = '1';
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcPrint.OwnerFuncName = menuInfo.s_func_name; 
                udcPrint.LotID = "ViewPackingList";

                if (udcPrint.LoadDesign() == false)
                {
                    return false;
                }

                iRowCount = spdList.ActiveSheet.RowCount;

                out_node.SetString("CREATE_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)LOT_LIST.COL_CREATE_TIME].Value));
                out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdList.ActiveSheet.Cells[0, (int)LOT_LIST.COL_MAT_SHORT_DESC].Value));
                out_node.SetString("BOX_ID", cdvBoxID.Text);

                for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_FG_ID].Value));
                }

                if (udcPrint.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrint.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;                

                MPCF.PrintFlexibleScreen(this, base.printOption, udcPrint, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void ProcPrintAuto()
        {
            for (int i = 0; i < MPCF.ToInt(txtPrintQty.Value); i++)
            {
                ProcPrint();
            }
        }

        #region " Button Event Definition "

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //sfdExcel.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

                //spdList.ActiveSheet.Protect = false;
                //spdList.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCloseC_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdList);
            cdvBoxID.Text = string.Empty;
            txtModuleID.Text = string.Empty;

            txtModuleID.Focus();
            txtModuleID.SelectAll();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ProcPrintAuto();
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            //박스 마감
            if (this.CheckCondition("CLOSE") == false)
            {
                return;
            }

            //선택한 항목을 마감하시겠습니까?
            if (MPCF.ShowMsgBox(MPCF.GetMessage(387), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            Tran_Box_Close('1');
        }

        private bool Tran_Box_Close(char cStep)
        {
            try
            {
                TRSNode in_node = new TRSNode("TRAN_IN");
                TRSNode out_node = new TRSNode("TRAN_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("BOX_ID", MPCF.Trim(spdList.Sheets[0].GetValue(0, (int)LOT_LIST.COL_BOX_ID)));                

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node, false) == false)
                {
                    return false;
                }                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #region " Function definition "
        
        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvBoxID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        private bool ViewPackingList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdList.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$BOX_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvBoxID.Text);

                dvcArgu[2].sCondtion_ID = "$FG_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(txtModuleID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_BOX_LOT_LIST_1", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdList.ActiveSheet.RowCount++;
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_NO].Value = dt.Rows[i]["NO"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_FACTORY].Value = dt.Rows[i]["FACTORY"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_BOX_ID].Value = dt.Rows[i]["BOX_ID"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_MAT_SHORT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_BOX_CLOSE].Value = dt.Rows[i]["BOX_CLOSE"].ToString();

                    if(i == 0)
                        cdvBoxID.Text = dt.Rows[i]["BOX_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdList);

                if (chkPrintFlag.Checked)
                    ProcPrintAuto();
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion

        private void cdvBoxID_CodeViewButtonClick(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];

            try
            {
                cdvBoxID.Tag = "";
                cdvBoxID.Text = "";

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                if (chkIncludeShippingBox.Checked)
                {
                    dvcArgu[1].sCondtion_ID = "$SHIP_FACTORY";
                    dvcArgu[1].sCondition_Value = "SHP";
                }
                else
                {
                    dvcArgu[1].sCondtion_ID = "$SHIP_FACTORY";
                    dvcArgu[1].sCondition_Value = MPGV.gsFactory;
                }

                dvcArgu[2].sCondtion_ID = "$BOX_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvBoxID.Text);

                dvcArgu[3].sCondtion_ID = "$FROM_DATE";
                dvcArgu[3].sCondition_Value = MPCF.Trim(this.dtFrDate.GetValueAsString(8) + "080000");

                dvcArgu[4].sCondtion_ID = "$TO_DATE";
                dvcArgu[4].sCondition_Value = DateTime.Parse(dtToDate.Value.ToString()).AddDays(1).ToString("yyyyMMdd") + "075959";

                // CodeView Column Header Setup
                string[] header = new string[] { "Box ID", "Factory" };

                // CodeView Display Column Setup
                string[] display = new string[] { "BOX_ID", "FACTORY" };

                // Show by RPTServer
                cdvBoxID.Text = cdvBoxID.Show(cdvBoxID, "Box List", "VIEW_BOX_LIST_1", dvcArgu, display, header, "BOX_ID", -1);

                if (cdvBoxID.returnDatas != null && cdvBoxID.returnDatas.Count > 0)
                {
                    cdvBoxID.Tag = cdvBoxID.returnDatas[0];
                    cdvBoxID.Text = cdvBoxID.returnDatas[0];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                if (string.IsNullOrEmpty(cdvBoxID.Text) && string.IsNullOrEmpty(txtModuleID.Text))
                    return;

                ViewPackingList();

                txtModuleID.Focus();
                txtModuleID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvBoxID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdvBoxID.Text) == false)
                {
                    if (sender.Equals(cdvBoxID))
                        txtModuleID.Text = string.Empty;

                    btnView.PerformClick();

                    txtModuleID.Focus();
                    txtModuleID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    if (sender.Equals(cdvBoxID))
                        txtModuleID.Text = string.Empty;

                    btnView.PerformClick();

                    txtModuleID.Focus();
                    txtModuleID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
    }
}
