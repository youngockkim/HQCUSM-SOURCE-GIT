//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranMountingTrayOnLayup.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-10-08 : Created by clearlim
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranMountingTrayOnLayup : BOIBaseForm02
    {
        public frmCUSTranMountingTrayOnLayup()
        {
            InitializeComponent();
        }


        #region [Constant Definition]

        const int ENTER = 13;

        #endregion


        #region [Variable Definition]

        private enum TRAY_OK_LIST : int
        {
            NO = 0,
            TRAY_ID,
            TRAY_TYPE,
            STRING_QTY,
            NOTE,
            CREATE_TIME,
            CREATE_USER_ID,
            MAT_ID
        }

        #endregion


        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                // (Required) Convert Caption
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);

                //MPCF.ClearList(this.spdTrayList, true);
                this.spdTrayList.ActiveSheet.RowCount = 0;
                MPCF.FitColumnHeader(spdTrayList);

                this.cdvLine.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, "");
                this.cdvLine.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, "");
                this.txtLineDesc.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.txtLineDesc.Name, "");
                this.cdvOper.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, "");
                this.cdvOper.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, "");
                this.txtOperDesc.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.txtOperDesc.Name, "");
                this.cdvResID.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, "");
                this.cdvResID.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, "");
                this.txtResDesc.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.txtResDesc.Name, "");
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
            //MPCF.ClearList(this.spdTrayList);
            this.spdTrayList.ActiveSheet.RowCount = 0;
            InitTrayInformation();
        }

        private void InitTrayInformation()
        {
            txtTrayID.Text = string.Empty;
            txtStringQty.Text = string.Empty;
            txtJudge.Text = string.Empty;
            txtMatID.Text = string.Empty;
            txtNote.Text = string.Empty;

            txtTrayID.Focus();
            txtTrayID.SelectAll();
        }

        private bool CheckCondition(string FuncName, int Case = 0)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        if (Case.Equals(0))
                        {
                            if (string.IsNullOrEmpty(cdvResID.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(410));
                                MPCF.SetFocus(cdvResID);
                                return false;
                            }
                        }
                        else if (Case.Equals(1))
                        {
                            if (string.IsNullOrEmpty(cdvLine.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(411));
                                MPCF.SetFocus(cdvLine);
                                return false;
                            }
                        }
                        else if (Case.Equals(2))
                        {
                            if (string.IsNullOrEmpty(cdvOper.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(412));
                                MPCF.SetFocus(cdvOper);
                                return false;
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:
                        
                            if (string.IsNullOrEmpty(MPCF.Trim(cdvResID.Text)))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(410));
                                MPCF.SetFocus(cdvResID);
                                return false;
                            }

                            if (string.IsNullOrEmpty(MPCF.Trim(txtTrayID.Text)))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                MPCF.SetFocus(txtTrayID);
                                return false;
                            }

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        if (string.IsNullOrEmpty(MPCF.Trim(txtTrayID.Text)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            MPCF.FieldClear(this.grbTrayInfor);
                            MPCF.SetFocus(txtTrayID);
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        if (string.IsNullOrEmpty(MPCF.Trim(txtMountingTrayID.Text)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            MPCF.SetFocus(txtMountingTrayID);
                            return false;
                        }

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

        private bool ViewOKTrayList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdTrayList);
            this.spdTrayList.ActiveSheet.RowCount = 0;

            try
            {
                //sViewID = "VIEW_TRAY_OK_LIST";
                sViewID = "VIEW_TRAY_OK_LIST_01";
                i_cond_cnt = 1;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                if (TPDR.DirectViewOne(spdTrayList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdTrayList);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetMountTrayOnLayup()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_MOUNT_TRAY_ON_LAYUP", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    this.txtMountingTrayID.Text = "";
                    this.txtMountingTrayNote.Text = "";
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    txtMountingTrayID.Text = dt.Rows[0]["CRR_ID"].ToString();
                    txtMountingTrayNote.Text = dt.Rows[0]["NOTE"].ToString();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetOKTray()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;
                
                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtTrayID.Text);

                //if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_OK_INFO", dvcArgu, false, false, ref s_sql) == false)
                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_OK_INFO_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    this.txtTrayID.Text = dt.Rows[0]["TRAY_ID"].ToString();
                    this.txtStringQty.Text = dt.Rows[0]["STRING_QTY"].ToString();
                    this.txtJudge.Text = dt.Rows[0]["TRAY_TYPE"].ToString();
                    this.txtMatID.Text = dt.Rows[0]["MAT_ID"].ToString();
                    this.txtNote.Text = dt.Rows[0]["NOTE"].ToString();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateMountingTray(char cProcStep)
        {
            TRSNode in_node = new TRSNode("CUS_UPDATE_CARRY_IN");
            TRSNode out_node = new TRSNode("CUS_UPDATE_CARRY_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                in_node.AddString("LINE_NO", MPCF.Trim(this.cdvLine.Text));
                in_node.AddString("OPER", MPCF.Trim(this.cdvOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(this.cdvResID.Text));
                if (cProcStep == MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("CRR_ID_OLD", MPCF.Trim(this.txtMountingTrayID.Text));
                    in_node.AddString("CRR_ID_NEW", "");
                }
                else if (cProcStep == MPGC.MP_STEP_CREATE)
                {
                    in_node.AddString("CRR_ID_OLD", MPCF.Trim(this.txtMountingTrayID.Text));
                    in_node.AddString("CRR_ID_NEW", MPCF.Trim(this.txtTrayID.Text));
                }

                if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CUS", "CUS_Update_Carrier_Mounting_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }


        #endregion


        #region [Event Definition]

        private void frmCUSTranMountingTrayOnLayup_Load(object sender, EventArgs e)
        {
            initCtrl();

            //if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

            //GetMountTrayOnLayup();
            //ViewOKTrayList();
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

                        GetMountTrayOnLayup();
                        ViewOKTrayList();

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

		//private void btnView_Click(object sender, EventArgs e)
		//{
		//    if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

		//    GetMountTrayOnLayup();
		//    ViewOKTrayList();
		//}

        private void btnView1_Click(object sender, EventArgs e)
        {
            //if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

            //ViewOKTrayList();

            if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

            GetMountTrayOnLayup();
            ViewOKTrayList();
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_UPDATE)) { return; }

            GetOKTray();
        }

        private void spdTrayList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            MPCF.FieldClear(this.grbTrayInfor);

            //this.btnInstall.Enabled = true;
            //this.btnRemove.Enabled = false;

            if (this.spdTrayList.ActiveSheet.RowCount < 1) { return; }

            this.txtTrayID.Text = MPCF.Trim(this.spdTrayList.ActiveSheet.Cells[this.spdTrayList.ActiveSheet.ActiveRowIndex, (int)TRAY_OK_LIST.TRAY_ID].Value);
            this.txtStringQty.Text = MPCF.Trim(this.spdTrayList.ActiveSheet.Cells[this.spdTrayList.ActiveSheet.ActiveRowIndex, (int)TRAY_OK_LIST.STRING_QTY].Value);
            this.txtJudge.Text = MPCF.Trim(this.spdTrayList.ActiveSheet.Cells[this.spdTrayList.ActiveSheet.ActiveRowIndex, (int)TRAY_OK_LIST.TRAY_TYPE].Value);
            this.txtMatID.Text = MPCF.Trim(this.spdTrayList.ActiveSheet.Cells[this.spdTrayList.ActiveSheet.ActiveRowIndex, (int)TRAY_OK_LIST.MAT_ID].Value);
            this.txtNote.Text = MPCF.Trim(this.spdTrayList.ActiveSheet.Cells[this.spdTrayList.ActiveSheet.ActiveRowIndex, (int)TRAY_OK_LIST.NOTE].Value);

            txtTrayID.Focus();
            txtTrayID.SelectAll();
        }

        private void txtTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    btnView2.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_CREATE)) { return; }

            if (UpdateMountingTray(MPGC.MP_STEP_CREATE) == true)
            {
                GetMountTrayOnLayup();
                MPCF.FieldClear(this.grbTrayInfor);
                ViewOKTrayList();
            }

            txtTrayID.Focus();
            txtTrayID.SelectAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_DELETE)) { return; }

            if (UpdateMountingTray(MPGC.MP_STEP_DELETE) == true)
            {
                GetMountTrayOnLayup();
                ViewOKTrayList();
            }
        }

        private void frmCUSTranMountingTrayOnLayup_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Message Bar를 초기화 합니다.
                MPCF.ShowMessageClear();

                // Memory Flush
                MPCF.FlushMemory();

                //// 조회 조건 Registry에 저장
                //BICF.SaveCondition(this);

                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, MPCF.Trim(this.cdvLine.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtLineDesc.Name, MPCF.Trim(this.txtLineDesc.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, MPCF.Trim(this.cdvOper.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtOperDesc.Name, MPCF.Trim(this.txtOperDesc.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, MPCF.Trim(this.cdvResID.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtResDesc.Name, MPCF.Trim(this.txtResDesc.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("frmCUSTranMountingTrayOnLayup_FormClosed() \n" + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

    }
}
