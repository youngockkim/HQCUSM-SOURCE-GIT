
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranQAGate.vb
//   Description : QA Transaction
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Operation() : View Operation Information
//       - Loss_Lot() : Loss Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.WIPCore
{
	public partial class frmWIPTranQAGate : Miracom.MESCore.TranForm07
	{
		public frmWIPTranQAGate()
		{
			InitializeComponent();
		}
		
		#region " Constant Definition "
		
		#endregion
		
		#region " Variable Definition "
		
		private bool b_load_flag;
		private string s_loss_table = "LOSS_CODE";
        private string s_material = "[Material]";
        private string s_oper = "[Operation]";
        
		
		#endregion
		
		#region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (View_Operation() == false) return false;

            cdvResID.Text = LOT.GetString("START_RES_ID");
            
            txtLotSMPQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtLotSMPQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            
            txtOutQty1.Text = txtLotSMPQty1.Text;
            txtOutQty2.Text = txtLotSMPQty2.Text;

            if (ViewQARuleForLot(s_lot_id) == false)
            {
                return false;
            }
            spdDefectData.Enabled = true;

            return true;
        }

		// ViewQARuleForLot()
		//       - Get QA Rule Information by Lot
		// Return Value
		//       -
		// Arguments
		//
        private bool ViewQARuleForLot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_QA_RULE_BY_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_QA_RULE_BY_LOT_OUT");

            int i=0;
            int j = 0;

            ListViewItem itemx;

			try
			{
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);
                in_node.AddString("OPER", LOT.GetString("OPER"));

                if (MPCR.CallService("WIP", "WIP_View_QA_Rule_By_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtQAOper.Text = MPCF.Trim(out_node.GetString("QA_OPER"));
                txtTestCount.Text = MPCF.Trim(out_node.GetInt("TEST_COUNT"));
                txtSMPType.Text = MPCF.Trim(out_node.GetString("SMP_TYPE"));
                txtUnit1SMPSizeType.Text = MPCF.Trim(out_node.GetString("SMP_SIZE_TYPE"));
                //txtSMPSize1.Text = out_node.GetDouble("SMP_SIZE_1").ToString();
                //txtSMPSize2.Text = out_node.GetDouble("SMP_SIZE_2").ToString();
                txtLotQty1.Text = LOT.GetDouble("QTY_1").ToString();
                txtLotQty2.Text = LOT.GetDouble("QTY_2").ToString();

                txtSMPRule.Text = MPCF.Trim(out_node.GetString("SMP_RULE_ID"));
                txtSMPDesc.Text = MPCF.Trim(out_node.GetString("SMP_RULE_DESC"));

                if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y')
                    chkSMPUnit1Flag.Checked = true;
                else
                    chkSMPUnit1Flag.Checked = false;
                
                txtUnit1SMPSizeType.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_TYPE"));
                txtUnit1SMPSize.Text = out_node.GetDouble("UNIT1_SMP_SIZE").ToString();
                txtUnit1SMPSelType.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_SEL_TYPE"));
                

                if (out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                    chkSMPUnit2Flag.Checked = true;
                else
                    chkSMPUnit2Flag.Checked = false;

                txtUnit2SMPSizeType.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_TYPE"));
                txtUnit2SMPSize.Text = out_node.GetDouble("UNIT2_SMP_SIZE").ToString();
                txtUnit2SMPSelType.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_SEL_TYPE"));

                txtDefQty1.Text = "0";
                txtDefQty2.Text = "0";

                //Sample Size Control
                if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y' && out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = true;
                    txtSMPSize2.Enabled = true;

                    DefectFieldControl(true, true);
                    
                }
                else if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = true;
                    txtSMPSize2.Enabled = false;

                    DefectFieldControl(true, false);
                    
                }
                else if (out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = false;
                    txtSMPSize2.Enabled = true;

                    DefectFieldControl(false, true);
                    
                }
                if (MPCF.Trim(out_node.GetString("SMP_TYPE")) == MPGC.TAP_QA_SMP_SIZE_TYPE_U)
                {
                    spdDefectData.Enabled = false;
                    lisSubLot.Enabled = false;
                }
                else if (MPCF.Trim(out_node.GetString("SMP_TYPE")) == MPGC.TAP_QA_SMP_SIZE_TYPE_SLOT)
                {

                    DefectFieldControl(false, false);
                    spdDefectData.Enabled = true;
                    lisSubLot.Enabled = true;
                }

                if (out_node.GetDouble("UNIT1_SMP_SIZE") != 0)
                {
                    txtSMPSize1.Enabled = false;
                    txtSMPSize1.Text = out_node.GetDouble("SMP_SIZE_1").ToString();
                    txtLotSMPQty1.Text = txtSMPSize1.Text;
                    txtOutQty1.Text = txtSMPSize1.Text;
                    
                }
                if (out_node.GetDouble("UNIT2_SMP_SIZE") != 0)
                {
                    txtSMPSize2.Enabled = false;
                    txtSMPSize2.Text = out_node.GetDouble("SMP_SIZE_2").ToString();
                    txtLotSMPQty2.Text = txtSMPSize2.Text;
                    txtOutQty2.Text = txtSMPSize2.Text;
                }

                if (txtSMPSize1.Enabled == false)
                    txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                else
                    txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.Window);

                if (txtSMPSize2.Enabled == false)
                    txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                else
                    txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.Window);

                //Defect Test control

                txtLotQty_1.Text = txtLotQty1.Text;
                txtLotQty_2.Text = txtLotQty2.Text;
                txtSMPQty_1.Text = txtSMPSize1.Text;
                txtSMPQty_2.Text = txtSMPSize2.Text;
                txtDefSubLotCnt.Text = "0";
                txtDefectCount.Text = "0";
                txtTotDefQty.Text = "0";
                txtTotlYield.Text = "100";

                MPCF.InitListView(lisSubLot);
                for (i = 0; i < 25; i++)
                {
                    itemx = new ListViewItem("", (int)SMALLICON_INDEX.IDX_MODULE);
                    itemx.SubItems.Add((i+1).ToString());
                    itemx.SubItems.Add("0");
                    itemx.SubItems.Add("0");
                    itemx.SubItems.Add("0");
                    itemx.SubItems.Add("100");
                    itemx.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                    lisSubLot.Items.Add(itemx);
                }
                
                if (
                    (MPCF.Trim(out_node.GetString("SMP_TYPE")) == MPGC.TAP_QA_SMP_SIZE_TYPE_SLOT) &&
                    (out_node.GetInt("SUBLOT_COUNT") != 0)
                    )
                {
                    for (i = 0; i < out_node.GetInt("SUBLOT_COUNT"); i++)
                    {
                        out_node.GetList("SUBLOT_TBL");

                        for (j = 0; j < lisSubLot.Items.Count; j++)
                        {
                            if (out_node.GetList("SUBLOT_TBL")[i].GetInt("SLOT_NO").ToString() == lisSubLot.Items[j].SubItems[1].Text)
                            {

                                lisSubLot.Items[j].BackColor = Color.FromKnownColor(KnownColor.Window);
                                lisSubLot.Items[j].Text = MPCF.Trim(out_node.GetList("SUBLOT_TBL")[i].GetString("SUBLOT_ID"));
                                lisSubLot.Items[j].SubItems[1].Text = out_node.GetList("SUBLOT_TBL")[i].GetInt("SLOT_NO").ToString();
                                lisSubLot.Items[j].SubItems[2].Text = out_node.GetList("SUBLOT_TBL")[i].GetDouble("SMP_SIZE").ToString();
                                lisSubLot.Items[j].SubItems[3].Text = "0";
                                lisSubLot.Items[j].SubItems[4].Text = out_node.GetList("SUBLOT_TBL")[i].GetDouble("SMP_SIZE").ToString();
                                lisSubLot.Items[j].SubItems[5].Text = "100";
                            }
                        }
                    }
                    for (j = 0; j < lisSubLot.Items.Count; j++)
                    {
                        if (out_node.GetString("UNIT1_SMP_SEL_LOC")[j] == 'Y' && MPCF.Trim(lisSubLot.Items[j].Text) != "")
                        {
                            lisSubLot.Items[j].Checked = true;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // DefectFieldControl()
        //       - Setting Defect Filed Control
        // Return Value
        //       -
        // Arguments
        // 
        private void DefectFieldControl(bool bUnit1, bool bUnit2)
        {
            try
            {
                if (bUnit1 == true)
                {
                    cdvUnit1Code1.Enabled = true;
                    cdvUnit1Code2.Enabled = true;
                    cdvUnit1Code3.Enabled = true;
                    cdvUnit1Code4.Enabled = true;
                    cdvUnit1Code5.Enabled = true;
                    cdvUnit1Code6.Enabled = true;
                    cdvUnit1Code7.Enabled = true;
                    cdvUnit1Code8.Enabled = true;
                    cdvUnit1Code9.Enabled = true;
                    cdvUnit1Code10.Enabled = true;

                    txtUnit1Qty1.Enabled = true;
                    txtUnit1Qty2.Enabled = true;
                    txtUnit1Qty3.Enabled = true;
                    txtUnit1Qty4.Enabled = true;
                    txtUnit1Qty5.Enabled = true;
                    txtUnit1Qty6.Enabled = true;
                    txtUnit1Qty7.Enabled = true;
                    txtUnit1Qty8.Enabled = true;
                    txtUnit1Qty9.Enabled = true;
                    txtUnit1Qty10.Enabled = true;

                    cdvUnit1Code1.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code2.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code3.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code4.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code5.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code6.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code7.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code8.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code9.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit1Code10.BackColor = Color.FromKnownColor(KnownColor.Window);

                    txtUnit1Qty1.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty2.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty3.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty4.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty5.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty6.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty7.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty8.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty9.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit1Qty10.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
                else
                {
                    cdvUnit1Code1.Enabled = false;
                    cdvUnit1Code2.Enabled = false;
                    cdvUnit1Code3.Enabled = false;
                    cdvUnit1Code4.Enabled = false;
                    cdvUnit1Code5.Enabled = false;
                    cdvUnit1Code6.Enabled = false;
                    cdvUnit1Code7.Enabled = false;
                    cdvUnit1Code8.Enabled = false;
                    cdvUnit1Code9.Enabled = false;
                    cdvUnit1Code10.Enabled = false;

                    txtUnit1Qty1.Enabled = false;
                    txtUnit1Qty2.Enabled = false;
                    txtUnit1Qty3.Enabled = false;
                    txtUnit1Qty4.Enabled = false;
                    txtUnit1Qty5.Enabled = false;
                    txtUnit1Qty6.Enabled = false;
                    txtUnit1Qty7.Enabled = false;
                    txtUnit1Qty8.Enabled = false;
                    txtUnit1Qty9.Enabled = false;
                    txtUnit1Qty10.Enabled = false;

                    cdvUnit1Code1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code3.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code4.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code5.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code6.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code7.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code8.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code9.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit1Code10.BackColor = Color.FromKnownColor(KnownColor.MenuBar);

                    txtUnit1Qty1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty3.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty4.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty5.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty6.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty7.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty8.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty9.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit1Qty10.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                }

                if (bUnit2 == true)
                {
                    cdvUnit2Code1.Enabled = true;
                    cdvUnit2Code2.Enabled = true;
                    cdvUnit2Code3.Enabled = true;
                    cdvUnit2Code4.Enabled = true;
                    cdvUnit2Code5.Enabled = true;
                    cdvUnit2Code6.Enabled = true;
                    cdvUnit2Code7.Enabled = true;
                    cdvUnit2Code8.Enabled = true;
                    cdvUnit2Code9.Enabled = true;
                    cdvUnit2Code10.Enabled = true;

                    txtUnit2Qty1.Enabled = true;
                    txtUnit2Qty2.Enabled = true;
                    txtUnit2Qty3.Enabled = true;
                    txtUnit2Qty4.Enabled = true;
                    txtUnit2Qty5.Enabled = true;
                    txtUnit2Qty6.Enabled = true;
                    txtUnit2Qty7.Enabled = true;
                    txtUnit2Qty8.Enabled = true;
                    txtUnit2Qty9.Enabled = true;
                    txtUnit2Qty10.Enabled = true;

                    cdvUnit2Code1.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code2.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code3.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code4.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code5.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code6.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code7.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code8.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code9.BackColor = Color.FromKnownColor(KnownColor.Window);
                    cdvUnit2Code10.BackColor = Color.FromKnownColor(KnownColor.Window);

                    txtUnit2Qty1.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty2.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty3.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty4.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty5.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty6.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty7.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty8.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty9.BackColor = Color.FromKnownColor(KnownColor.Window);
                    txtUnit2Qty10.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
                else
                {
                    cdvUnit2Code1.Enabled = false;
                    cdvUnit2Code2.Enabled = false;
                    cdvUnit2Code3.Enabled = false;
                    cdvUnit2Code4.Enabled = false;
                    cdvUnit2Code5.Enabled = false;
                    cdvUnit2Code6.Enabled = false;
                    cdvUnit2Code7.Enabled = false;
                    cdvUnit2Code8.Enabled = false;
                    cdvUnit2Code9.Enabled = false;
                    cdvUnit2Code10.Enabled = false;

                    txtUnit2Qty1.Enabled = false;
                    txtUnit2Qty2.Enabled = false;
                    txtUnit2Qty3.Enabled = false;
                    txtUnit2Qty4.Enabled = false;
                    txtUnit2Qty5.Enabled = false;
                    txtUnit2Qty6.Enabled = false;
                    txtUnit2Qty7.Enabled = false;
                    txtUnit2Qty8.Enabled = false;
                    txtUnit2Qty9.Enabled = false;
                    txtUnit2Qty10.Enabled = false;

                    cdvUnit2Code1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code3.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code4.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code5.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code6.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code7.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code8.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code9.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    cdvUnit2Code10.BackColor = Color.FromKnownColor(KnownColor.MenuBar);

                    txtUnit2Qty1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty3.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty4.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty5.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty6.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty7.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty8.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty9.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                    txtUnit2Qty10.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
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
		// Arguments
		//       - Optional ByVal ProcStep As String ("1")
		//
		private void ClearData(string ProcStep)
		{
            try
			{
				switch (ProcStep)
				{
					case "1":
                        MPCF.FieldClear(this);
						ClearLotSpread();
						break;
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}		
		
		// CheckCondition()
		//       - Check the conditions before transaction
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//       - ByVal FuncName As String : Function Name
		//
        private bool CheckCondition(char ProcStep)
		{
			int i = 0;
			int j = 0;
			bool bInputCheck = false;
            switch (ProcStep)
			{
				case '1':
					ArrayList controlUnit1Qty = null;
					ArrayList controlUnit1Code = null;
					ArrayList controlUnit2Qty = null;
					ArrayList controlUnit2Code = null;

                    if (LOT.GetChar("HOLD_FLAG") == 'Y')
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(350));
                        return false;
                    }
					
					if (MPCF.CheckValue(txtLotID, 1) == false)
					{
                        txtLotID.Focus();
						return false;
					}
                    //if (MPCF.CheckValue(txtComment, 1) == false)
                    //{
                    //    tabTran.SelectedTab = tbpGeneral;
                    //    txtComment.Focus();
                    //    return false;
                    //}
					if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
					{
						MPCF.ShowMsgBox(MPCF.GetMessage(154) + s_material);
						txtLotID.Focus();
						return false;
					}
					if (MPCF.Trim(LOT.GetString("OPER")) == "")
					{
						MPCF.ShowMsgBox(MPCF.GetMessage(154) + s_oper);
						txtLotID.Focus();
						return false;
					}
                    if (MPCF.CheckValue(cdvAction,1) == false)
                    {
                        cdvAction.Focus();
                        return false;
                    }	
					
					controlUnit1Qty = MPCF.GetIndexedControl("txtUnit1Qty", grpUnit1);
					controlUnit1Code = MPCF.GetIndexedControl("cdvUnit1Code", grpUnit1);
					controlUnit2Qty = MPCF.GetIndexedControl("txtUnit2Qty", grpUnit2);
					controlUnit2Code = MPCF.GetIndexedControl("cdvUnit2Code", grpUnit2);
					for (i = 0; i <= controlUnit1Code.Count - 1; i++)
					{
						if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Text) != "")
						{
							bInputCheck = true;
							break;
						}
					}
					if (bInputCheck == false && MPCF.ToDbl(txtDefQty1.Text) > 0)
					{
						for (i = 0; i <= controlUnit2Code.Count - 1; i++)
						{
							if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Text) != "")
							{
								bInputCheck = true;
								break;
							}
						}
					}

					for (i = 0; i <= controlUnit1Code.Count - 1; i++)
					{
						if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Text) != "")
						{
							if (MPCF.Trim(((UltraNumericEditor) controlUnit1Qty[i]).Text) == "")
							{
								MPCF.ShowMsgBox(MPCF.GetMessage(108));
								tabTran.SelectedTab = tbpDefect1;
								((UltraNumericEditor) controlUnit1Qty[i]).Focus();
								return false;
							}
							else
							{
								if (MPCF.ToDbl(((UltraNumericEditor) controlUnit1Qty[i]).Text) <= 0)
								{
									MPCF.ShowMsgBox(MPCF.GetMessage(114));
									tabTran.SelectedTab = tbpDefect1;
									((UltraNumericEditor) controlUnit1Qty[i]).Focus();
									return false;
								}
							}
						}
					}
					for (i = 0; i <= controlUnit1Qty.Count - 1; i++)
					{
						if (MPCF.Trim(((UltraNumericEditor) controlUnit1Qty[i]).Text) != "")
						{
							if (MPCF.ToDbl(MPCF.Trim(((UltraNumericEditor) controlUnit1Qty[i]).Text)) > 0 && MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Text) == "")
							{
								MPCF.ShowMsgBox(MPCF.GetMessage(108));
								tabTran.SelectedTab = tbpDefect1;
								((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Focus();
								return false;
							}
						}
					}
					for (i = 0; i <= controlUnit1Code.Count - 2; i++)
					{
						if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Text) != "")
						{
							for (j = i + 1; j <= controlUnit1Code.Count - 1; j++)
							{
								if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Text) == MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[j]).Text))
								{
									MPCF.ShowMsgBox(MPCF.GetMessage(111));
									tabTran.SelectedTab = tbpDefect1;
									((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit1Code[i]).Focus();
									return false;
								}
							}
						}
					}
					for (i = 0; i <= controlUnit1Code.Count - 1; i++)
					{
						if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Text) != "")
						{
							if (MPCF.Trim(((UltraNumericEditor) controlUnit2Qty[i]).Text) == "")
							{
								MPCF.ShowMsgBox(MPCF.GetMessage(108));
								tabTran.SelectedTab = tbpDefect1;
								((UltraNumericEditor) controlUnit2Qty[i]).Focus();
								return false;
							}
							else
							{
								if (MPCF.ToDbl(((UltraNumericEditor) controlUnit2Qty[i]).Text) <= 0)
								{
									MPCF.ShowMsgBox(MPCF.GetMessage(114));
									tabTran.SelectedTab = tbpDefect1;
									((UltraNumericEditor) controlUnit2Qty[i]).Focus();
									return false;
								}
							}
						}
					}
					for (i = 0; i <= controlUnit2Qty.Count - 1; i++)
					{
						if (MPCF.Trim(((UltraNumericEditor) controlUnit2Qty[i]).Text) != "")
						{
							if (MPCF.ToDbl(MPCF.Trim(((UltraNumericEditor) controlUnit2Qty[i]).Text)) > 0 && MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Text) == "")
							{
								MPCF.ShowMsgBox(MPCF.GetMessage(108));
								tabTran.SelectedTab = tbpDefect1;
								((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Focus();
								return false;
							}
						}
					}
					for (i = 0; i <= controlUnit2Code.Count - 2; i++)
					{
						if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Text) != "")
						{
							for (j = i + 1; j <= controlUnit2Code.Count - 1; j++)
							{
                                if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) == MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[j]).Text))
								{
									MPCF.ShowMsgBox(MPCF.GetMessage(111));
									tabTran.SelectedTab = tbpDefect1;
									((Miracom.UI.Controls.MCCodeView.MCCodeView) controlUnit2Code[i]).Focus();
									return false;
								}
							}
						}
					}

                    //make sure no mismatch                    
                    for (i = 0; i < spdDefectData_LotInfo.RowCount; i++)
                    {
                        if (spdDefectData_LotInfo.GetValue(i, 0) != null
                            || spdDefectData_LotInfo.GetValue(i, 2) != null
                            || spdDefectData_LotInfo.GetValue(i, 5) != null)
                        {
                            if (spdDefectData_LotInfo.GetValue(i, 0) == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }
                            else if (spdDefectData_LotInfo.GetValue(i, 0).ToString().Trim() == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }

                            if (spdDefectData_LotInfo.GetValue(i, 2) == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }
                            else if (spdDefectData_LotInfo.GetValue(i, 2).ToString().Trim() == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }

                            if (spdDefectData_LotInfo.GetValue(i, 5) == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }
                            else if (spdDefectData_LotInfo.GetValue(i, 5).ToString().Trim() == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpDefect2;
                                return false;
                            }
                        }
                    }
					if (CheckCMFItemValue() == false)
					{
						tabTran.SelectedTab = tbpCMF;
						return false;
					}
					break;
			}
            return true;
		}		
		
		// View_Operation()
		//       -  View Operation Information
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//
		private bool View_Operation()
		{

            TRSNode in_node = new TRSNode("QA_GATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
			{
                MPCF.FieldVisible(grpUnit1, true);
			}
			else
			{
                MPCF.FieldVisible(grpUnit1, false);
				txtOutQty1.Text = "0";
				
			}
            if (out_node.GetString("UNIT_2") != "")
			{
                MPCF.FieldVisible(grpUnit2, true);
			}
			else
			{
                MPCF.FieldVisible(grpUnit2, false);
				txtOutQty2.Text = "0";
			}

            s_loss_table = "";
            s_loss_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
            if (s_loss_table == "")
            {
                s_loss_table = out_node.GetString("LOSS_TBL");
            }

            if (s_loss_table == "")
            {
                MPCF.FieldVisible(pnlUnitMid, false);
                MPCF.ShowMsgBox(MPCF.GetMessage(247));
            }
			return true;
		}
		
		// QA Gate()
		//       - Transaction Qa Gate
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//       - ByVal ProcStep As String : Process Step
		//
		private bool QA_Gate(char ProcStep)
		{

            TRSNode in_node = new TRSNode("QA_GATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode def_unit1;
            TRSNode def_unit2;
            TRSNode def_sublot;
            int i = 0;
            int i_lot_def1 = 0;
            int i_lot_def2 = 0;
            int i_sublot_def = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddInt("LAST_HIST_SEQ", LOT.GetInt("LAST_HIST_SEQ"));
                in_node.AddString("QA_OPER", txtQAOper.Text);
                in_node.AddString("ACT_RULE_ID", cdvAction.Text);
                in_node.AddString("SMP_RULE_ID", txtSMPRule.Text);
                in_node.AddString("PASS_FLAG", txtPassFail.Text);

                in_node.AddDouble("SMP_SIZE_1", MPCF.ToDbl(txtSMPSize1.Text));
                in_node.AddDouble("SMP_SIZE_2", MPCF.ToDbl(txtSMPSize2.Text));
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("INSPECTOR", txtInspector.Text);
                in_node.AddString("SHIFT", cdvShift.Text);
                in_node.AddString("IRRMRR", txtIRRMRR.Text);

                in_node.AddString("QA_COMMENT", txtComment.Text);

                //Defect Unit1/Unit2
                if (MPCF.ToDbl(txtSMPSize1.Text) > 0)
                {
                    in_node.AddDouble("DEF_QTY_1",  MPCF.ToDbl(txtDefQty1.Text));
                    in_node.AddDouble("YIELD_1", (MPCF.ToDbl(txtOutQty1.Text) / MPCF.ToDbl(txtLotQty1.Text)) * 100);
                }

                if (MPCF.ToDbl(txtSMPSize2.Text) > 0)
                {
                    in_node.AddDouble("DEF_QTY_2", MPCF.ToDbl(txtDefQty2.Text));
                    in_node.AddDouble("YIELD_2", (MPCF.ToDbl(txtOutQty2.Text) / MPCF.ToDbl(txtLotQty2.Text)) * 100);
                }

                in_node.AddString("QA_CMF_1", cdvCMF1.Text);
                in_node.AddString("QA_CMF_2", cdvCMF2.Text);
                in_node.AddString("QA_CMF_3", cdvCMF3.Text);
                in_node.AddString("QA_CMF_4", cdvCMF4.Text);
                in_node.AddString("QA_CMF_5", cdvCMF5.Text);
                in_node.AddString("QA_CMF_6", cdvCMF6.Text);
                in_node.AddString("QA_CMF_7", cdvCMF7.Text);
                in_node.AddString("QA_CMF_8", cdvCMF8.Text);
                in_node.AddString("QA_CMF_9", cdvCMF9.Text);
                in_node.AddString("QA_CMF_10", cdvCMF10.Text);

                in_node.AddString("RESV_FIELD_1", cdvCMF11.Text);
                in_node.AddString("RESV_FIELD_2", cdvCMF12.Text);
                in_node.AddString("RESV_FIELD_3", cdvCMF13.Text);
                in_node.AddString("RESV_FIELD_4", cdvCMF14.Text);
                in_node.AddString("RESV_FIELD_5", cdvCMF15.Text);
                in_node.AddString("RESV_FIELD_6", cdvCMF16.Text);
                in_node.AddString("RESV_FIELD_7", cdvCMF17.Text);
                in_node.AddString("RESV_FIELD_8", cdvCMF18.Text);
                in_node.AddString("RESV_FIELD_9", cdvCMF19.Text);
                in_node.AddString("RESV_FIELD_10", cdvCMF20.Text);

                if(MPCF.ToDbl(txtUnit1Qty1.Text)>0)
                {
                    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code1.Text);
				    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty1.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty2.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code2.Text);
				    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty2.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty3.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code3.Text);
				    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty3.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty4.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code4.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty4.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty5.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code5.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty5.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty6.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code6.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty6.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty7.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code7.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty7.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty8.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code8.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty8.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty9.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code9.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty9.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit1Qty10.Text)>0)
                {
				    def_unit1 = in_node.AddNode("DEF_UNIT1");
                    def_unit1.AddString("DEF_CODE", cdvUnit1Code10.Text);
                    def_unit1.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit1Qty10.Text));
                    i_lot_def1++;
                }
                if(MPCF.ToDbl(txtUnit2Qty1.Text)>0)
                {

                    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code1.Text);
				    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty1.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty2.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code2.Text);
				    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty2.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty3.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code3.Text);
				    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty3.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty4.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code4.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty4.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty5.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code5.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty5.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty6.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code6.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty6.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty7.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code7.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty7.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty8.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code8.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty8.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty9.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code9.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty9.Text));
                    i_lot_def2++;
                }
                if(MPCF.ToDbl(txtUnit2Qty10.Text)>0)
                {
				    def_unit2 = in_node.AddNode("DEF_UNIT2");
                    def_unit2.AddString("DEF_CODE", cdvUnit2Code10.Text);
                    def_unit2.AddDouble("DEF_QTY", MPCF.ToDbl(txtUnit2Qty10.Text));
                    i_lot_def2++;
                }

                in_node.AddInt("DEF_UNIT1_CNT", i_lot_def1);
                in_node.AddInt("DEF_UNIT2_CNT", i_lot_def2);

                //Defect for Sub Lot
                for (i = 0; i < spdDefectData_LotInfo.RowCount; i++)
                {
                    if( spdDefectData_LotInfo.GetValue(i, 0) != null)
                    {
                        def_sublot = in_node.AddNode("DEF_SUBLOT");
                        def_sublot.AddString("DEF_CODE", spdDefectData_LotInfo.GetText(i, 0));
                        def_sublot.AddString("SUBLOT_ID", spdDefectData_LotInfo.GetText(i, 2));
                        def_sublot.AddDouble("DEF_QTY", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 5)));
                        def_sublot.AddDouble("LOC_X", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 6)));
                        def_sublot.AddDouble("LOC_Y", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 7)));
                        def_sublot.AddDouble("LOC_Z", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 8)));
                        def_sublot.AddDouble("CELL_X", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 9)));
                        def_sublot.AddDouble("CELL_Y", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 10)));
                        def_sublot.AddDouble("CELL_Z", MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 11)));
                        i_sublot_def++;
                    }
                }

                in_node.AddInt("DEF_SUBLOT_CNT", i_sublot_def);

                //Defect for Sub Lot
                i_sublot_def = 0;
                for (i = 0; i < lisSubLot.Items.Count; i++)
                {
                    if (MPCF.Trim(lisSubLot.Items[i].Text)!="")
                    {
                        def_sublot = in_node.AddNode("SUBLOT");
                        def_sublot.AddString("SUBLOT_ID", lisSubLot.Items[i].Text);
                        def_sublot.AddDouble("IN_QTY", MPCF.ToDbl(lisSubLot.Items[i].SubItems[1].Text));
                        def_sublot.AddDouble("SMP_QTY", MPCF.ToDbl(lisSubLot.Items[i].SubItems[2].Text));
                        def_sublot.AddDouble("DEF_QTY", MPCF.ToDbl(lisSubLot.Items[i].SubItems[3].Text));
                        def_sublot.AddDouble("GOOD_QTY", MPCF.ToDbl(lisSubLot.Items[i].SubItems[4].Text));
                        def_sublot.AddDouble("YIELD", MPCF.ToDbl(lisSubLot.Items[i].SubItems[5].Text));
                        i_sublot_def++;
                    }
                }

                in_node.AddInt("SUBLOT_CNT", i_sublot_def);

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", dtpTranDate.Value.ToString("yyyyMMddHHmmss"));
                }

                if (MPCR.CallService("WIP", "WIP_QA_Gate", in_node, ref out_node) == false)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
		}

        // VIEW_SKIP_PASS_FAIL_COUNT()
        //       - View Result Action
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool VIEW_SKIP_PASS_FAIL_COUNT(char Procstep)
        {
            TRSNode in_node = new TRSNode("VIEW_SKIP_PASS_FAIL_COUNT_IN");
            TRSNode out_node = new TRSNode("VIEW_SKIP_PASS_FAIL_COUNT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = Procstep;
            in_node.AddString("ACT_RULE_ID", cdvAction.Text);
            in_node.AddString("SMP_RULE_ID", txtSMPRule.Text);
            in_node.AddString("ACTION_DESC", MPGC.PASS_FLAG_DESC);
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddInt("FLOW_SEQ", LOT.GetInt("FLOW_SEQ_NUM"));
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Qa_Result_Action", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetInt("QA_FAIL_COUNT") > 0)
            {
                if (MPCF.Trim(cdvAction.Text) == MPGC.ACT_RULE_SKIP)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(320));
                    return false;
                }
            }

            if (out_node.GetInt("QA_SKIP_COUNT") > 0 && out_node.GetInt("SKIP_CNT_BY_PASS") > 0)
            {
                if (out_node.GetInt("QA_SKIP_COUNT") == out_node.GetInt("SKIP_CNT_BY_PASS"))
                {
                    if (MPCF.Trim(cdvAction.Text) == MPGC.ACT_RULE_SKIP)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(321));
                        return false;
                    }
                }
            }
            
            if (out_node.GetInt("QA_PASS_COUNT") > 0 && out_node.GetInt("PASS_COUNT_FOR_SKIP") > 0)
            {
                if (out_node.GetInt("QA_PASS_COUNT") < out_node.GetInt("PASS_COUNT_FOR_SKIP"))
                {
                    if (MPCF.Trim(cdvAction.Text) == MPGC.ACT_RULE_SKIP)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(362));  // PASS ÈÄ »ç¿ë
                        return false;
                    }
                }
            }
            return true;
        }

        // QA_RESULT_ACTION_COUNT()
        //       - Update Result Action
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool QA_RESULT_ACTION_COUNT(char Procstep)
        {
            TRSNode in_node = new TRSNode("QA_RESULT_ACTION_COUNT_IN");
            TRSNode out_node = new TRSNode("QA_RESULT_ACTION_COUNT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = Procstep;
            in_node.AddString("ACT_RULE_ID", cdvAction.Text);
            in_node.AddString("SMP_RULE_ID", txtSMPRule.Text);
            in_node.AddString("ACTION_DESC", MPGC.PASS_FLAG_DESC);
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddInt("FLOW_SEQ", LOT.GetInt("FLOW_SEQ_NUM"));
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (cdvAction.Text == MPGC.ACT_RULE_FAIL)
            {
                in_node.AddString("FAIL_FLAG", "Y");
            }

            if (MPCR.CallService("WIP", "WIP_Qa_Result_Action", in_node, ref out_node) == false)
            {
                return false;
            }
            return true;
        }

        // ViewSublotListT()
        //       - View SublotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal List As ListView : ListView
        private bool ViewSublotList(ListView control, string sLotId)
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.InitListView(control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
            {
                return false;
            }
                
            for (i = 0; i < out_node.GetList("SUBLOT").Count; i++)
            {
                itmX = new ListViewItem(MPCF.Trim(out_node.GetList("SUBLOT")[i].GetString("SUBLOT_ID")), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList("SUBLOT")[i].GetInt("SLOT_NO").ToString()));

                control.Items.Add(itmX);
            }
            return true;
        }

        // SetLocCellField()
        //       - View Loc Cell Data  
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        private void SetLocCellField()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            int i = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPGC.TAP_QA_LOC_CELL);

            if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
            {
                return;
            }

            for (i = 0; i < out_node.GetList("DATA_LIST").Count; i++)
            {
                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "LOC_X" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[8].Width = 0;
                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "LOC_Y" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[9].Width = 0;
                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "LOC_Z" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[10].Width = 0;

                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "CELL_X" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[11].Width = 0;
                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "CELL_Y" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[12].Width = 0;
                if (out_node.GetList("DATA_LIST")[i].GetString("KEY_1") == "CELL_Z" && out_node.GetList("DATA_LIST")[i].GetString("DATA_1") == "N")
                    spdDefectData_LotInfo.ColumnHeader.Columns[13].Width = 0;
            }
            return;
        }

		#endregion


        private void frmWIPTranQAGate_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.TAP_CMF_TRN_QA_GATE);
                    spdDefectData_LotInfo.RowCount = 150;

                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    spdDefectData_LotInfo.ColumnHeader.Columns[4].Width = 0;
                    spdDefectData_LotInfo.ColumnHeader.Columns[6].Width = 0;
                    spdDefectData_LotInfo.ColumnHeader.Columns[7].Width = 0;
                    spdDefectData.Enabled = false;
                    SetLocCellField();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
		
		private void cdvUnitCode_ButtonPress(object sender, System.EventArgs e)
		{			
			Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
			try
			{
				cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
				
				cdvTemp.Init();
				cdvTemp.Columns.Add("Code", 50, HorizontalAlignment.Left);
				cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
				cdvTemp.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', s_loss_table) == false)
				{
					return;
				}				
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return;
			}			
		}
		
		private void cdvResID_ButtonPress(object sender, System.EventArgs e)
		{
			try
			{
				if (txtLotID.Text == "")
				{
					MPCF.ShowMsgBox(MPCF.GetMessage(108));
					txtLotID.Focus();
					return;
				}
				if (MPCF.Trim(LOT.GetString("OPER")) == "")
				{
					MPCF.ShowMsgBox(MPCF.GetMessage(154) + s_oper);
					return;
				}
				
				cdvResID.Init();
				cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
				cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
				cdvResID.SelectedSubItemIndex = 0;
				#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
				{
					return;
				}
				#endif
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return;
			}			
		}

        private void CloseWnd()
        {
            this.Close();
        }		
		
		private void btnProcess_Click(System.Object sender, System.EventArgs e)
		{			
			try
			{
                if (CheckCondition('1') == false) return;
                if (VIEW_SKIP_PASS_FAIL_COUNT('1') == false) return;
				if (QA_Gate((MPGC.MP_STEP_CREATE)) == false) return;
                if (QA_RESULT_ACTION_COUNT('1') == false)
                {
                    return;
                }
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
                ClearData("1");
                //ViewLotInfo(txtLotID.Text);
                //this.Invoke(new MethodInvoker(this.CloseWnd));
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

        private void txtUnit1Qty_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i = 0;
				double dTempQty = 0;
				ArrayList controlUnit1Qty = null;
				UltraNumericEditor txtUnit1Qty = (UltraNumericEditor) sender;
				
				controlUnit1Qty = MPCF.GetIndexedControl("txtUnit1Qty", grpUnit1);
				for (i = 0; i <= controlUnit1Qty.Count - 1; i++)
				{
					if (((UltraNumericEditor) controlUnit1Qty[i]).Value == System.DBNull.Value)
					{
						dTempQty = dTempQty + 0;
					}
					else
					{
						dTempQty = dTempQty + MPCF.ToDbl(MPCF.ToDbl(((UltraNumericEditor) controlUnit1Qty[i]).Value));
						if (MPCF.ToDbl(MPCF.ToDbl(txtLotSMPQty1.Text)) - dTempQty < 0)
						{
							MPCF.ShowMsgBox(MPCF.GetMessage(198));
							txtUnit1Qty.Value = "";
							txtUnit1Qty.Focus();
							return;
						}
					}
				}
                txtDefQty1.Text = dTempQty.ToString();
				txtOutQty1.Text = Convert.ToString(MPCF.ToDbl(MPCF.ToDbl(txtLotSMPQty1.Text)) - dTempQty);
				
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}
		
		private void txtUnit2Qty_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i = 0;
				double dTempQty = 0;
				ArrayList controlUnit2Qty = null;
				UltraNumericEditor txtUnit2Qty = (UltraNumericEditor) sender;
				
				controlUnit2Qty = MPCF.GetIndexedControl("txtUnit2Qty", grpUnit2);
				for (i = 0; i <= controlUnit2Qty.Count - 1; i++)
				{
					if (((UltraNumericEditor) controlUnit2Qty[i]).Value == System.DBNull.Value)
					{
						dTempQty = dTempQty + 0;
					}
					else
					{
						dTempQty = dTempQty + MPCF.ToDbl(MPCF.ToDbl(((UltraNumericEditor) controlUnit2Qty[i]).Value));
						if (MPCF.ToDbl(MPCF.ToDbl(txtLotSMPQty2.Text)) - dTempQty < 0)
						{
							MPCF.ShowMsgBox(MPCF.GetMessage(198));
							txtUnit2Qty.Value = "";
							txtUnit2Qty.Focus();
							return;
						}
					}
				}
                txtDefQty2.Text = dTempQty.ToString();
				txtOutQty2.Text = Convert.ToString(MPCF.ToDbl(MPCF.ToDbl(txtLotSMPQty2.Text)) - dTempQty);
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
        }

        private void cdvAction_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            cdvAction.Init();
            cdvAction.Columns.Add("Pass/Fail", 50, HorizontalAlignment.Left);
            cdvAction.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAction.SelectedSubItemIndex = 0;

            if (QCMLIST.ViewMFOQARuleList(cdvAction.GetListView, '2', MPGC.TAP_CMF_QA_ACTION_RULE, "", LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetInt("FLOW_SEQ_NUM"), LOT.GetString("OPER"), "", "") == false)
                return;
        }

        private void cdvShift_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvShift.Init();
                MPCF.InitListView(cdvShift.GetListView);
                cdvShift.Columns.Add("Group Id", 50, HorizontalAlignment.Left);
                cdvShift.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvShift.SelectedSubItemIndex = 0;
                SECLIST.ViewSecGroupList(cdvShift.GetListView, '1', null, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdDefectData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_lot_defect_table;
            int i = 0;
            ListViewItem itmX;

            try
            {
                if (txtLotID.Text == "")
                {
                    return;
                }

                if (e.Column == 1)
                {
                    cdvDefect.Init();
                    cdvDefect.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDefect.GetListView);
                    cdvDefect.Columns.Add("Defect", 50, HorizontalAlignment.Left);
                    cdvDefect.Columns.Add("Desc", 200, HorizontalAlignment.Left);

                    s_lot_defect_table = "";
                    s_lot_defect_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOT_DEFECT_TBL);
                    if (s_lot_defect_table == "")
                    {
                        s_lot_defect_table = MPGC.MP_WIP_LOT_DEFECT_CODE;
                    }

                    if (BASLIST.ViewGCMDataList(cdvDefect.GetListView, '1', s_lot_defect_table) == false)
                    {
                        return;
                    }

                    if (cdvDefect.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == 3)
                {
                    cdvSublotID.Init();
                    cdvSublotID.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvSublotID.GetListView);
                    cdvSublotID.Columns.Add("Sub Lot ID", 50, HorizontalAlignment.Left);

                    for (i = 0; i < lisSubLot.CheckedItems.Count; i++)
                     {
                       itmX = new ListViewItem(lisSubLot.CheckedItems[i].Text, (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                       cdvSublotID.Items.Add(itmX);
                    }

                    if (cdvSublotID.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDefect_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "")
                {
                    return;
                }
                spdDefectData.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvSublotID_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "")
                {
                    return;
                }
                spdDefectData.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false)
                return;

            ofdFile.Reset();
            ofdFile.Filter = "Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdFile.DefaultExt = "xls,xlsx";
            ofdFile.FileName = txtLotID.Text;
            if (ofdFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
            }
        }

        private void spdDefectData_EditModeOff(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            double d_def_sum = 0;
            int i_lot_cnt = 0;
            int i_def_cnt = 0;
            double d_temp = 0;

            if((spdDefectData_LotInfo.ActiveCell.Column.Index!=1)
                && (spdDefectData_LotInfo.ActiveCell.Column.Index!=3)
                && (spdDefectData_LotInfo.ActiveCell.Column.Index!=5))
                return;

            for (i = 0; i < lisSubLot.Items.Count; i++)
            {
                lisSubLot.Items[i].SubItems[3].Text = "0";
                lisSubLot.Items[i].SubItems[4].Text = lisSubLot.Items[i].SubItems[2].Text;
                lisSubLot.Items[i].SubItems[5].Text = "100";
            }

            for (i = 0; i < spdDefectData_LotInfo.RowCount; i++)
            {
                if (MPCF.Trim(spdDefectData_LotInfo.GetText(i, 2)) != "")
                {
                    for (j = 0; j < lisSubLot.Items.Count; j++)
                    {
                        if (MPCF.Trim(lisSubLot.Items[j].Text) == MPCF.Trim(spdDefectData_LotInfo.GetText(i, 2))
                            && lisSubLot.Items[j].Checked==true)
                        {

                            d_temp = MPCF.ToDbl(lisSubLot.Items[j].SubItems[3].Text) + MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 5));
                            lisSubLot.Items[j].SubItems[3].Text = d_temp.ToString("0.000");
                            d_temp = MPCF.ToDbl(lisSubLot.Items[j].SubItems[2].Text) - MPCF.ToDbl(lisSubLot.Items[j].SubItems[3].Text);
                            lisSubLot.Items[j].SubItems[4].Text = d_temp.ToString("0.000");
                            d_temp = (MPCF.ToDbl(lisSubLot.Items[j].SubItems[4].Text) / MPCF.ToDbl(lisSubLot.Items[j].SubItems[2].Text)) * 100;
                            lisSubLot.Items[j].SubItems[5].Text = d_temp.ToString("0.00");
                        }
                    }
                    i_def_cnt++;
                    d_def_sum = d_def_sum + MPCF.ToDbl(spdDefectData_LotInfo.GetText(i, 5));
                }
            }

            for (j = 0; j < lisSubLot.Items.Count; j++)
                if (MPCF.ToDbl(lisSubLot.Items[j].SubItems[3].Text) != 0)
                    i_lot_cnt++;

            txtDefectCount.Text = i_def_cnt.ToString();
            txtTotDefQty.Text = d_def_sum.ToString();
            txtDefSubLotCnt.Text = i_lot_cnt.ToString();
            d_temp = ((MPCF.ToDbl(txtLotQty_2.Text) - d_def_sum) * 100) / MPCF.ToDbl(txtLotQty_2.Text);
            txtTotlYield.Text =  d_temp.ToString("00.00");

            txtDefQty2.Text = txtTotDefQty.Text;
            d_temp=MPCF.ToDbl(txtSMPSize2.Text) - MPCF.ToDbl(txtDefQty2.Text);
            txtOutQty2.Text = d_temp.ToString();
        }

        private void chkWaferSelect_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            int i_count = 0;

            if (chkWaferSelect.Checked == true)
            {
                for (i = 0; i < lisSubLot.Items.Count; i++)
                {
                    if (lisSubLot.Items[i].Checked == true)
                        i_count++;
                }
                if (MPCF.ToInt(txtSMPSize1.Text) != i_count)
                {
                        chkWaferSelect.Checked = false;

                        MPCF.ShowMsgBox(MPCF.GetMessage(282));
                    return;
                }
            }
            if (chkWaferSelect.Checked == true)
            {
                lisSubLot.Enabled = false;
                spdDefectData.Enabled = true;
            }
            if (chkWaferSelect.Checked == false)
            {
                lisSubLot.Enabled = true;
                spdDefectData.Enabled = false;
            }
        }

        private void txtSMPSize1_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.ToDbl(txtSMPSize1.Text) > LOT.GetDouble("QTY_1"))
            {
                txtSMPSize1.Text = "0";
                MPCF.ShowMsgBox(MPCF.GetMessage(356));
            }
        }

        private void cdvAction_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            TRSNode in_node = new TRSNode("UPDATE_QA_RULE_IN");
            TRSNode out_node = new TRSNode("UPDATE_QA_RULE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RULE_ID", cdvAction.Text);
            in_node.AddString("RULE_TYPE", MPGC.TAP_ACTION_RULE);

            if (MPCR.CallService("WIP", "WIP_View_QA_Rule", in_node, ref out_node) == false)
            {
                return;
            }
            txtActionDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));
            txtPassFail.Text = MPCF.Trim(out_node.GetString("PASS_FLAG"));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            spdDefectData.EditMode = true;
            spdDefectData.ActiveSheet.ClearRange(0, 0, spdDefectData.ActiveSheet.RowCount, spdDefectData.ActiveSheet.ColumnCount, true);
            spdDefectData.EditMode = false;
        }

        private void spdDefectData_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            //update the spread
            spdDefectData_EditModeOff(sender, e);
        }

        private void spdDefectData_TextChanged(object sender, EventArgs e)
        {
            //update the spread
            spdDefectData_EditModeOff(sender, e);
        }

        private void spdDefectData_Leave(object sender, EventArgs e)
        {
            //update the spread
            spdDefectData_EditModeOff(sender, e);
        }
    }
}
