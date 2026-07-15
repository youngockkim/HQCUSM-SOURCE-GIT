using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASTranChangeAssociationState : Miracom.MESCore.TranForm01
    {
        public frmRASTranChangeAssociationState()
        {
            InitializeComponent();
        }

        #region " Variable definition "
        bool b_load_flag;
        #endregion

        #region " Function definition "

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
                    MPCF.FieldClear(this, cdvResID, null, null, null, null, false);
                }
                else
                {
                    MPCF.FieldClear(this, cdvResID, cdvPortID, null, null, null, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        private bool GetResourceIDList()
        {

            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;

                if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Change":

                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvPortID, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboAscState, 1) == false)
                        {
                            return false;
                        }
                        break;
                    case "View_Port_List":

                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            return false;
                        }
                        break;
                    case "View":

                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvPortID, 1) == false)
                        {
                            return false;
                        }
                        break;
                    case "View1":

                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            return false;
                        }
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



        // View_Port()
        //       -  View Port
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Port()
        {
            TRSNode in_node = new TRSNode("VIEW_PORT_IN");
            TRSNode out_node = new TRSNode("VIEW_PORT_OUT");
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("SUBRES_ID", "");
                in_node.AddString("PORT_ID", MPCF.Trim(cdvPortID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Port", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtPortSeq.Text = MPCF.Trim(out_node.GetInt("PORT_SEQ"));
                txtPortDesc.Text = MPCF.Trim(out_node.GetString("PORT_DESC"));
                txtTrsState.Text = MPCF.Trim(out_node.GetString("TRS_STATE"));

                txtLotID.Text = MPCF.Trim(out_node.GetString("LOT_ID"));
                txtCrrID.Text = MPCF.Trim(out_node.GetString("CRR_ID"));

                cboAscState.Text = MPCF.Trim(out_node.GetChar("ASC_STATE"));
                txtAscObjID.Text = MPCF.Trim(out_node.GetString("ASC_OBJ_ID"));
                txtAccState.Text = MPCF.Trim(out_node.GetChar("ACC_STATE"));
                txtRsvState.Text = MPCF.Trim(out_node.GetChar("RSV_STATE"));
                txtRsvObjID.Text = MPCF.Trim(out_node.GetString("RSV_OBJ_ID"));

                txtBCRSts.Text = MPCF.Trim(out_node.GetChar("BCR_STATUS_FLAG"));
                
                if (out_node.GetChar("PORT_TYPE") == 'L')
                {
                    txtPortType.Text = "LOAD";
                }
                else if (out_node.GetChar("PORT_TYPE") == 'U')
                {
                    txtPortType.Text = "UNLOAD";
                }
                else
                {
                    txtPortType.Text = "BOTH";
                }

                txtPortBatch.Text = MPCF.Trim(out_node.GetChar("PORT_BATCH_FLAG"));

                txtAddPortType.Text = MPCF.Trim(out_node.GetChar("ADD_PORT_TYPE"));
                txtPortLevel.Text = MPCF.Trim(out_node.GetChar("PORT_LEVEL"));

                //Transaction?ÑÏúºÎ°?setup??cmfÎ•??£ÏúºÎ©??àÎêú??
                //cdvCMF1.Text = RTrim(out_node.Get("PORT_CMF_1"))
                //cdvCMF2.Text = RTrim(out_node.Get("PORT_CMF_2"))
                //cdvCMF3.Text = RTrim(out_node.Get("PORT_CMF_3"))
                //cdvCMF4.Text = RTrim(out_node.Get("PORT_CMF_4"))
                //cdvCMF5.Text = RTrim(out_node.Get("PORT_CMF_5"))
                //cdvCMF6.Text = RTrim(out_node.Get("PORT_CMF_6"))
                //cdvCMF7.Text = RTrim(out_node.Get("PORT_CMF_7"))
                //cdvCMF8.Text = RTrim(out_node.Get("PORT_CMF_8"))
                //cdvCMF9.Text = RTrim(out_node.Get("PORT_CMF_9"))
                //cdvCMF10.Text = RTrim(out_node.Get("PORT_CMF_10"))

                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //
        // Change_Port_Status()
        //       -  Update Port
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?ïÏû• Process Step
        //
        private bool Change_Association_State(char c_step)
        {

            TRSNode in_node = new TRSNode("CHANGE_PORT_STATUS_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("SUBRES_ID", "");
                in_node.AddString("PORT_ID", MPCF.Trim(cdvPortID.Text));

                in_node.AddChar("ASC_STATE", MPCF.ToChar(cboAscState.Text));
                in_node.AddString("ASC_OBJ_ID", MPCF.Trim(txtAscObjID.Text));                

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("RAS", "RAS_Change_Association_State", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvResID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASTranChangeAssociationState_Load(object sender, EventArgs e)
        {
            MPCF.FieldClear(this);
            MPCF.FieldVisible(tbpCMF, false);
        }

        private void frmRASTranChangeAssociationState_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                cdvResID.Focus();

                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_CHANGE_PORT, "lblCmf", "cdvCmf", grpCMF);

                if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                {
                    cdvResID.Text = MPGV.gsCurrentRes_ID;
                }

                b_load_flag = true;
            }
        }

        private void cdvResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            ClearData('1');

        }

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {

            ClearData('1');

            cdvPortID.Init();
            GetResourceIDList();

        }

        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            ClearData('1');

        }


        private void cdvResID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                if (CheckCondition("View", '1') == false)
                {
                    return;
                }

                if (View_Port() == false)
                {
                    return;
                }
            }

        }


        private void cdvPortID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            ClearData('2');
            if (View_Port() == false)
            {
                return;
            }

        }

        private void cdvPortID_ButtonPress(object sender, System.EventArgs e)
        {

            ClearData('2');
            if (CheckCondition("View2", '1') == false)
            {
                return;
            }

            cdvPortID.Init();
            MPCF.InitListView(cdvPortID.GetListView);
            cdvPortID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvPortID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPortID.SelectedSubItemIndex = 0;

            if (RASLIST.ViewPortList(cdvPortID.GetListView, '1', cdvResID.Text, "") == false)
            {
                return;
            }

        }

        private void cdvPortID_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            ClearData('2');

        }

        private void cdvPortID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                if (CheckCondition("View", '1') == false)
                {
                    return;
                }

                if (View_Port() == false)
                {
                    return;
                }
            }

        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {

            if (CheckCondition("Change", '1') == false)
            {
                return;
            }

            if (Change_Association_State('1') == false)
            {
                return;
            }

            ClearData('2');
            if (View_Port() == false)
            {
                return;
            }

        }

        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {

            MPCR.ProcGRPCMFButtonPress(sender);

        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            MPCR.CheckCMFKeyPress(sender, e);

        }

    }
}

