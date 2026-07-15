using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSTranTrayStringCreate : SOIBaseForm03
    {
        #region [Property]

        const int ENTER = 13;

        const string CREATE = "Create";
        const string DISMANTLING = "Dismantling";
        const string DELETE = "Delete";

        #endregion

        public frmCUSTranTrayStringCreate()
        {
            InitializeComponent();
        }
        
        #region [Constant Definition]

        private enum TAB_CASE
        {
            CREATE,
            DISMANTLING,
            DELETE
        }

        private enum TRAY
        {
            CHK,
            STRING_SEQ,
            STRING,
            CELL_1,
            CELL_2,
            CELL_3,
            CELL_4,
            CELL_5,
            CELL_6,
            CELL_7,
            CELL_8,
            CELL_9,
            CELL_10,
            CELL_11,
            CELL_12,
            TRAY_ID,
            TRAY_TYPE,
			MAT_ID
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private void InitCreateView()
        {
            MPCF.ClearList(this.spdStringList);
            InitTrayInformation();
        }

        private void InitTrayInformation()
        {
            txtStringQty.Text = string.Empty;
            txtTrayID.Text = string.Empty;
            txtTrayDesc.Text = string.Empty;
            cbxJudge.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void InitDismantlingView()
        {
            MPCF.ClearList(this.spdDisStringList);

            txtDisTrayID.Text = string.Empty;
            txtDisTrayDesc.Text = string.Empty;
            txtReturnResID.Text = string.Empty;
        }

        private void InitDeleteListView()
        {
            MPCF.ClearList(this.spdDelList);

            txtDisTrayID.Text = string.Empty;
            txtDisTrayDesc.Text = string.Empty;
        }

        private bool CheckCondition(string FuncName, int Case = 0)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
                        {
                            if (Case.Equals(0))
                            {
                                if (string.IsNullOrEmpty(cdvResID.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(410));
                                    return false;
                                }
                            }
                            if (Case.Equals(1))
                            {
                                if (string.IsNullOrEmpty(cdvLine.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(411));
                                    return false;
                                }
                            }
                            if (Case.Equals(2))
                            {
                                if (string.IsNullOrEmpty(cdvOper.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(412));
                                    return false;
                                }
                            }
                        }
                        else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
                        {
                            if (Case.Equals(0))
                            {
                                if (string.IsNullOrEmpty(txtDisTrayID.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                    return false;
                                }
                            }
                        }
                        else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
                        {
                            if (string.IsNullOrEmpty(txtDisTrayID.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                return false;
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
                        {
                            if (!CheckSaveTray()) return false;
                        }
                        else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
                        {
                            if (spdDisStringList.ActiveSheet.RowCount < 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(413));
                                return false;
                            }
                        }
                        else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
                        {
                            if (spdDelList.ActiveSheet.RowCount < 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(122));
                                return false;
                            }

                            bool searchFlag = true;

                            for (int r = 0; r < spdDelList.ActiveSheet.RowCount; r++)
                            {
                                if (Convert.ToBoolean(spdDelList.ActiveSheet.Cells[r, (int)TRAY.CHK].Value))
                                {
                                    searchFlag = false;
                                }
                            }

                            if (searchFlag)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(122));
                                return false;
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        break;

                    default:

                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewNGTrayList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdStringList);

            try
            {
                //sViewID = "VIEW_TRAY_NG_STRING_LIST";
                sViewID = "VIEW_TRAY_NG_STRING_LIST_01";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$RES_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                if (TPDR.DirectViewOne(spdStringList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdStringList);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewDismantlingResID()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdDisStringList);

            try
            {
                sViewID = "VIEW_DISMANTLING_RES_ID";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$TRAY_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtDisTrayID.Text);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                    txtReturnResID.Text = dt.Rows[0]["RES_ID"].ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewCreatedTrayList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdDisStringList);

            try
            {
                //sViewID = "VIEW_TRAY_STRING_LIST_ALL";
                sViewID = "VIEW_TRAY_STRING_LIST_ALL_01";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$TRAY_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtDisTrayID.Text);

                if (TPDR.DirectViewOne(spdDisStringList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdDisStringList);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckSaveTray()
        {
            if (string.IsNullOrEmpty(MPCF.Trim(cdvResID.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cdvResID);
                return false;
            }

            if (float.Parse(txtStringQty.Text) <= 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(txtStringQty);
                return false;
            }

            if (string.IsNullOrEmpty(MPCF.Trim(txtTrayID.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(txtTrayID);
                return false;
            }

            if (string.IsNullOrEmpty(MPCF.Trim(cbxJudge.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cbxJudge);
                return false;
            }

            return true;
        }

        private bool SaveStringInTray(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CUS_CREATE_STRINGLIST_IN");
            TRSNode out_node = new TRSNode("CUS_CREATE_STRINGLIST_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (ProcStep.Equals(MPGC.MP_STEP_CREATE))
                {
                    in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                    in_node.AddInt("STRING_QTY", MPCF.Trim(txtStringQty.Text));
                    in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID.Text));
                    in_node.AddString("JUDGE", MPCF.Trim(cbxJudge.Text));
                    in_node.AddString("NOTE", MPCF.Trim(txtNote.Text));
                }
                else if (ProcStep.Equals(MPGC.MP_STEP_UPDATE))
                {
                    in_node.AddString("TRAY_ID", MPCF.Trim(txtDisTrayID.Text));
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Create_String_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool DeleteStringInTray(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CUS_CREATE_STRINGLIST_IN");
            TRSNode out_node = new TRSNode("CUS_CREATE_STRINGLIST_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (ProcStep.Equals(MPGC.MP_STEP_DELETE))
                {
                    for (int i = 0; i < spdDelList.Sheets[0].RowCount; i++)
                    {
                        if (Convert.ToBoolean(spdDelList.ActiveSheet.Cells[i, (int)TRAY.CHK].Value) == true)
                        {
                            list_item = in_node.AddNode("DATA_LIST");
                            list_item.AddString("TRAY_ID", MPCF.Trim(spdDelList.ActiveSheet.Cells[i, (int)TRAY.TRAY_ID].Value));
                            list_item.AddString("STRING_ID", MPCF.Trim(spdDelList.ActiveSheet.Cells[i, (int)TRAY.STRING].Value));
                            list_item.AddString("STRING_SEQ", MPCF.Trim(spdDelList.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value));
                        }
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Create_String_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetCreateButton(bool visibleFlag)
        {
            lblLine.Visible = visibleFlag;
            cdvLine.Visible = visibleFlag;
            txtLineDesc.Visible = visibleFlag;

            lblOper.Visible = visibleFlag;
            cdvOper.Visible = visibleFlag;
            txtOperDesc.Visible = visibleFlag;

            cdvResID.Visible = visibleFlag;
            txtResDesc.Visible = visibleFlag;
        }

        private void SetDismantlingButton(bool visibleFlag)
        {
            lblTrayID.Visible = visibleFlag;
            lblResID.Visible = visibleFlag;
            txtDisTrayID.Visible = visibleFlag;
            txtDisTrayDesc.Visible = visibleFlag;
            txtReturnResID.Visible = visibleFlag;
        }

        private bool ExistTrayID()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtDisTrayID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_EXIST_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(407));

                    txtDisTrayID.Text = string.Empty;
                    spdDelList_Sheet1.RowCount = 0;
                    MPCF.SetFocus(txtDisTrayID);

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewTrayInfo()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";
            string strStringID = string.Empty;
            string strMatID = string.Empty;

            try
            {
                spdDelList_Sheet1.RowCount = 0;
                
                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtDisTrayID.Text);

                //if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_CASE_LIST", dvcArgu, false, false, ref s_sql) == false)
                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_CASE_LIST_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    spdDelList_Sheet1.RowCount = 0;
                    MPCF.SetFocus(txtDisTrayID);

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        strStringID = dt.Rows[i]["STRING_ID"].ToString();
                        strMatID = dt.Rows[i]["MAT_ID"].ToString();
                        spdDelList.ActiveSheet.RowCount++;
                        spdDelList.ActiveSheet.Cells[i, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                        spdDelList.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                        spdDelList.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                        spdDelList.ActiveSheet.Cells[i, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
						spdDelList.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    }
                    else
                    {
                        if (strStringID != dt.Rows[i]["STRING_ID"].ToString())
                        {
                            strStringID = dt.Rows[i]["STRING_ID"].ToString();
                            spdDelList.ActiveSheet.RowCount++;
                            spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                            spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
							spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }

                        if (strMatID != dt.Rows[i]["MAT_ID"].ToString())
                        {
                            if(string.Compare(strMatID, dt.Rows[i]["MAT_ID"].ToString()) > 0)
                            {
                                spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                            }
                        }
                    }

                    if (dt.Rows[i]["LOSS_CODE"].ToString() != " " && dt.Rows[i]["LOSS_CODE"].ToString() != "")
                    {
                        spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 2].Text = "√";
                        spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 2].BackColor = Color.Red;
                    }
                    else
                    {
                        spdDelList.ActiveSheet.Cells[spdDelList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 2].BackColor = Color.LightGreen;
                    }
                }

				MPCF.FitColumnHeader(spdDelList);

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranTrayStringCreate_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranTrayStringCreate_Shown(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_VIEW)) 
            { 
                if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
                    MPCF.SetFocus(txtTrayID);
                else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
                    MPCF.SetFocus(txtDisTrayID);
                else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
                    MPCF.SetFocus(txtDisTrayID);

                return; 
            }

            if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
            {
                ViewNGTrayList();
                MPCF.SetFocus(txtTrayID);
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
            {
                ViewDismantlingResID();
                ViewCreatedTrayList();
                MPCF.SetFocus(txtDisTrayID);
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
            {
                if (ExistTrayID())
                {
                    ViewTrayInfo();
                    MPCF.SetFocus(txtDisTrayID);
                }
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_AREA_CODE));

                string[] header = new string[] { "Line", "Line Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                cdvOper.Text = string.Empty;
                txtOperDesc.Text = string.Empty;
                cdvResID.Text = string.Empty;
                txtResDesc.Text = string.Empty;

                if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                {
                    cdvLine.Tag = cdvLine.returnDatas[0];
                    cdvLine.Text = cdvLine.returnDatas[0];
                    txtLineDesc.Text = cdvLine.returnDatas[1];

                    MPCF.SetFocus(txtTrayID);
                }
                else
                {
                    cdvLine.Text = string.Empty;
                    txtLineDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 1)) { return; }

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "Code Desc", "VIEW_OPER_LIST", dvcArgu, display, header, "OPER", -1);

                cdvResID.Text = string.Empty;
                txtResDesc.Text = string.Empty;

                if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                {
                    cdvOper.Tag = cdvOper.returnDatas[0];
                    cdvOper.Text = cdvOper.returnDatas[0];
                    txtOperDesc.Text = cdvOper.returnDatas[1];

                    MPCF.SetFocus(txtTrayID);
                }
                else
                {
                    cdvOper.Tag = string.Empty;
                    txtOperDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 2)) { return; }

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER";
                dvcArgu[1].sCondition_Value = cdvOper.Tag;

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResID.Text = cdvResID.Show(cdvResID, "Code Desc", "VIEW_MFO_RES_LIST", dvcArgu, display, header, "RES_ID", -1);

                if (MPCF.Trim(cdvResID.Text) != "")
                {
                    if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                    {
                        cdvResID.Tag = cdvResID.returnDatas[0];
                        cdvResID.Text = cdvResID.returnDatas[0];
                        txtResDesc.Text = cdvResID.returnDatas[1];

                        ViewNGTrayList();

                        MPCF.SetFocus(txtTrayID);
                    }
                }
                else
                {
                    cdvResID.Tag = string.Empty;
                    txtResDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    DataTable dt = new DataTable();
                    TPDR.DirectViewCond[] ArrDVC = new TPDR.DirectViewCond[2];

                    ArrDVC[0].sCondtion_ID = "$FACTORY";
                    ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                    ArrDVC[1].sCondtion_ID = "$TRAY_ID";

                    if (sender.Equals(txtTrayID))
                    {
                        txtTrayID.Text = MPCF.ToUpper(txtTrayID.Text); // 일괄 대문자

                        ArrDVC[1].sCondition_Value = txtTrayID.Text.ToUpper();

                        if (TPDR.DirectViewOne(null, "VIEW_TRAY_EXIST_LIST", ref dt, false, false, ArrDVC, true) == false)
                        {
                            if (dt != null) { dt.Dispose(); }
                            GC.Collect();
                            return;
                        }

                        txtTrayID.Text = dt.Rows[0]["TRAN_ID"].ToString();
                        txtTrayDesc.Text = dt.Rows[0]["TRAN_DESC"].ToString();
                    }
                    else if (sender.Equals(txtDisTrayID))
                    {
                        txtDisTrayID.Text = MPCF.ToUpper(txtDisTrayID.Text); // 일괄 대문자

                        ArrDVC[1].sCondition_Value = txtDisTrayID.Text.ToUpper();

                        if (TPDR.DirectViewOne(null, "VIEW_TRAY_EXIST_LIST", ref dt, false, false, ArrDVC, true) == false)
                        {
                            if (dt != null) { dt.Dispose(); }
                            GC.Collect();
                            return;
                        }

                        txtDisTrayID.Text = dt.Rows[0]["TRAN_ID"].ToString();
                        txtDisTrayDesc.Text = dt.Rows[0]["TRAN_DESC"].ToString();
                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_CREATE)) { return; }

            if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
            {
                DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(380), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                if (dr != System.Windows.Forms.DialogResult.OK)
                    return;

                if (SaveStringInTray(MPGC.MP_STEP_CREATE))
                {
                    ViewNGTrayList();
                }

				txtTrayID.Text = "";
				txtTrayDesc.Text = "";
                txtTrayID.Focus();
                txtTrayID.SelectAll();
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
            {
                DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(418), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                if (dr != System.Windows.Forms.DialogResult.OK)
                    return;

                if (SaveStringInTray(MPGC.MP_STEP_UPDATE))
                {
                    ViewCreatedTrayList();
                }

				txtDisTrayID.Text = "";
				txtDisTrayDesc.Text = "";
				txtResDesc.Text = "";
				txtDisTrayID.Focus();
            }
            if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
            {
                DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(451), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                if (dr != System.Windows.Forms.DialogResult.OK)
                    return;

                if (DeleteStringInTray(MPGC.MP_STEP_DELETE))
                {
                    ViewTrayInfo();
                }

				txtDisTrayID.Text = "";
				txtDisTrayDesc.Text = "";
				txtDisTrayID.Focus();
            }
        }

        private void utbTrayTap_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
            {
                SetCreateButton(true);
                SetDismantlingButton(false);

                lblResID.Visible = true;
                txtReturnResID.Visible = false;

                btnProcess.Text = CREATE;
                MPCF.SetFocus(txtTrayID);
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
            {
                InitDismantlingView();
                SetCreateButton(false);
                SetDismantlingButton(true);

                lblResID.Visible = true;
                txtReturnResID.Visible = true;

                btnProcess.Text = DISMANTLING;
                MPCF.SetFocus(txtDisTrayID);
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
            {
                InitDeleteListView();
                SetCreateButton(false);

                lblResID.Visible = false;
                txtReturnResID.Visible = false;
                txtDisTrayID.Visible = true;
                txtDisTrayDesc.Visible = true;
                lblTrayID.Visible = true;

                btnProcess.Text = DELETE;
                MPCF.SetFocus(txtDisTrayID);
            }

            MPCF.ConvertCaption(btnProcess);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.CREATE)
            {
                InitCreateView();
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DISMANTLING)
            {
                InitDismantlingView();
            }
            else if (utbTrayTap.SelectedTab.Index == (int)TAB_CASE.DELETE)
            {
                InitDeleteListView();
            }
        }

        private void spdDelList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true && e.Column == (int)TRAY.CHK)
            {
                if (spdDelList.ActiveSheet.RowCount < 1) return;

                bool allChecked = (spdDelList.Tag == null || spdDelList.Tag.ToString() == "0") ? false : true;

                if (allChecked == true) spdDelList.Tag = "0";
                else spdDelList.Tag = "1";

                for (int r = 0; r < spdDelList.ActiveSheet.RowCount; r++)
                    spdDelList.ActiveSheet.Cells[r, e.Column].Value = allChecked;
            }
        }

        private void btnCellBatch_Click(object sender, EventArgs e)
        {
            try
            {
                //셀배치작업 화면
                BICF.OpenMenu("SOI3004");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnRawInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //자재장착관리 화면
                BICF.OpenMenu("SOI3003");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnTrayStringChange_Click(object sender, EventArgs e)
        {
            try
            {
                //트레이 스트링 변경 화면
                BICF.OpenMenu("SOI2018");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        #endregion        

    } 
}
