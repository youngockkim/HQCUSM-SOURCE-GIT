//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSEquipmentSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//       - UpdateMms() : Create/Update/Delete Mms
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-21 09:08:14 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSEquipmentSetup : SetupForm02
    {
        public frmMMSEquipmentSetup()
        {
            InitializeComponent();
            if (MPGV.gcLanguage == '2')
                btnItemRefresh.Font = new Font("Microsoft Sans Serif", 7);
        }


        #region " Constant Definition "

        private Size imgSize = new Size(50, 50);

        private enum MMS_ITEM : int
        {
            CHECK = 0,
            ITEM_CODE,
            ITEM_NAME,
            LSL,
            USL,
            UNIT_CODE,
            DECIMAL_PLACE,
            EQUIP_ITEM_FLAG
        }
        private enum MMS_EQUIP_ITEM : int
        {
            CHECK = 0,
            ITEM_CODE,
            ITEM_NAME,
            LSL,
            USL,
            UNIT_CODE,
            DECIMAL_PLACE,
            USE_GRR_CONT_FLAG,
            USE_GRR_DISC_FLAG,
            USE_BIAS_FLAG,
            USE_LINE_FLAG
        }

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        private PictureBox picImage;

        #endregion

        #region " Function Definition "

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.txtEquipCode;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ('1', '2')
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    MPCF.FieldClear(this);
                    spdEquipItemList.ActiveSheet.RowCount = 0;
                    spdItemList.ActiveSheet.RowCount = 0;

                    // TODO
                }
                else if (c_case == '2')
                {
                    pnlImageList.Controls.Clear();
                    picViewImage.Image = null;
                    txtImageFileName.Text = "";
                    txtImageDescription.Text = "";
                    picImage = null;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string FuncName : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(txtEquipCode, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "CREATE":
                case "UPDATE":
                    // TODO
                    if (chkMSA.Checked == true)
                    {
                        if (nudMSACycle.Value < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(629)); //The MSA(validation) period must be at least 1.
                            return false;
                        }
                    }

                    if (chkCalibration.Checked == true)
                    {
                        if (nudCalibrationCycle.Value < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(630)); //Calibration cycle must be at least 1.
                            return false;
                        }
                    }

                    break;
                case "DELETE":
                    // TODO
                    break;
            }

            return true;            
        }

        // SetGroupCmfItem()
        //       -   Set Group/Cmf property to control
        // Return Value
        //       -
        // Arguments
        //       -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_MMS_EQUIP_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_MMS_EQUIP_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_MMS_EQUIP_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_MMS_EQUIP_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_MMS_EQUIP_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_MMS_EQUIP_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_MMS_EQUIP_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_MMS_EQUIP_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_MMS_EQUIP_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_MMS_EQUIP_GRP_10;

            MPCR.SetCMFItem(MPGC.MP_CMF_MMS_EQUIPMENT, "lblCMF", "cdvCMF", grpCMF);
        }
                        
        //
        // ViewEquipmentList()
        //       - View Equipment List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '5';

                in_node.AddString("EQUIP_TYPE", cdvViewEquipType.Text);
                in_node.AddString("USE_DEPT", cdvViewUseDept.Text);
                in_node.AddString("MGT_DEPT", cdvViewMgtDept.Text);
                in_node.AddString("USE_DIV", cdvViewUseDiv.Text);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Equipment_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                    in_node.SetString("NEXT_EQUIP_ID", out_node.GetString("NEXT_EQUIP_ID"));

                } while (in_node.GetString("NEXT_EQUIP_ID") != "");

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("EQUIPMENT_LIST");
                    foreach (TRSNode node in equipment_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("EQUIP_ID")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("EQUIP_NAME")));
                        lisView.Items.Add(itmX);
                    }
                }
                lblDataCount.Text = lisView.Items.Count.ToString();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewEquipmentList()
        //       - View Equipment List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentRelationItemList(string sEquipCode)
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_ITEM_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            int i;

            try
            {
                // Item List 조회 
                MPCF.ClearList(spdItemList);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString("EQUIP_ID", sEquipCode);
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ITEM_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    out_list.Add(out_node);
                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;
                i = 0;
                
                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("ITEM_LIST");
                    
                    foreach (TRSNode node in equipment_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.CHECK), false);
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.LSL), node.GetDouble("LSL"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.USL), node.GetDouble("USL"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.UNIT_CODE), node.GetString("UNIT_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.DECIMAL_PLACE), node.GetInt("DECIMAL_PLACE"));
                        with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.EQUIP_ITEM_FLAG), node.GetChar("EQUIP_ITEM_FLAG").ToString());
                        if (node.GetChar("EQUIP_ITEM_FLAG") == 'Y')
                        {
                            with_1.Rows[i].Visible = false;
                            with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.CHECK), true);
                        }

                        i++;
                    }
                }

                // Equipment Relation Item List 조회 
                MPCF.ClearList(spdEquipItemList);
                MPCR.SetInMsg(in_node);
                out_list.Clear();
                in_node.ProcStep = '1';
                in_node.AddString("EQUIP_ID", sEquipCode);
                do
                {                    
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_ITEM_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Equipment_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    out_list.Add(out_node);
                } while (out_list.Count < 1);


                FarPoint.Win.Spread.SheetView with_2 = spdEquipItemList.ActiveSheet;
                i = 0;
                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("EQUIPMENT_ITEM_LIST");
                    
                    foreach (TRSNode node in equipment_list)
                    {
                        with_2.RowCount = i + 1;

                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK), false);
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.LSL), node.GetDouble("LSL"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.USL), node.GetDouble("USL"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.UNIT_CODE), node.GetString("UNIT_CODE"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.DECIMAL_PLACE), node.GetInt("DECIMAL_PLACE"));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.USE_GRR_CONT_FLAG), (node.GetChar("USE_GRR_CONT_FLAG") == 'Y' ? true : false));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.USE_GRR_DISC_FLAG), (node.GetChar("USE_GRR_DISC_FLAG") == 'Y' ? true : false));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.USE_BIAS_FLAG), (node.GetChar("USE_BIAS_FLAG") == 'Y' ? true : false));
                        with_2.SetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.USE_LINE_FLAG), (node.GetChar("USE_LINE_FLAG") == 'Y' ? true : false));
                        i++;  
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

        //
        // ViewEquipmentImageList()
        //       - View Equipment Image List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentImageList(string sEquipCode)
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_IMAGE_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                // Item List 조회 
                MPCF.ClearList(spdItemList);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';


                in_node.AddString("EQUIP_ID", sEquipCode);
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ITEM_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    out_list.Add(out_node);
                } while (out_list.Count < 1);

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("ITEM_LIST");

                    foreach (TRSNode node in equipment_list)
                    {
                        fnAddImageFormServer(MPCF.Trim(node.GetString("IMAGE_NAME"))
                                            , MPCF.Trim(node.GetString("IMAGE_REMARK"))
                                            , (byte[])node.GetBlob("IMAGE_BLOB_DATA"));
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


        //
        // ViewEquipment()
        //       - View Equipment
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipment()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_OUT");

            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Equipment", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtEquipCode.Text = out_node.GetString("EQUIP_ID");
                //txtEquipCode.Text = out_node.GetString("EQUIP_CODE");
                cdvEquipType.Text = out_node.GetString("EQUIP_TYPE");
                cdvEquipType.DescText = out_node.GetString("EQUIP_TYPE_NAME");
                txtEquipName.Text = out_node.GetString("EQUIP_NAME");
                txtEquipNo.Text = out_node.GetString("EQUIP_NO");
                cdvMgtDept.Text = out_node.GetString("MGT_DEPT_CODE");
                cdvMgtDept.DescText = out_node.GetString("MGT_DEPT_NAME");
                cdvMgtUser.Text = out_node.GetString("MGT_USER_ID");
                cdvMgtUser.DescText = out_node.GetString("MGT_USER_NAME");
                cdvUseDept.Text = out_node.GetString("USE_DEPT_CODE");
                cdvUseDept.DescText = out_node.GetString("USE_DEPT_NAME");
                cdvUseUser.Text = out_node.GetString("USE_USER_ID");
                cdvUseUser.DescText = out_node.GetString("USE_USER_NAME");

                cdvUseDiv.Text = out_node.GetString("USE_DIV");
                cdvUseDiv.DescText = out_node.GetString("USE_DIV_NAME");

                if (out_node.GetChar("CALI_DIV") == '0')
                {
                    rdoCaliInside.Checked = true;
                    //rdoCaliOutside.Checked = false;
                }
                else
                {
                    //rdoCaliInside.Checked = false;
                    rdoCaliOutside.Checked = true;
                }
                txtEquipModel.Text = out_node.GetString("EQUIP_MODEL");
                txtEquipSpec.Text = out_node.GetString("EQUIP_SPEC");
                txtEquipMaker.Text = out_node.GetString("EQUIP_MAKER");
                txtEquipPurpose.Text = out_node.GetString("EQUIP_PURPOSE");
                txtEquipFeature.Text = out_node.GetString("EQUIP_FEATURE");
                cdvInstallationPlace.Text = out_node.GetString("EQUIP_PLACE_CODE");
                cdvInstallationPlace.DescText = out_node.GetString("EQUIP_PLACE_NAME");
                nudCalibrationCycle.Value = out_node.GetInt("CALI_CYCLE");
                nudMSACycle.Value = out_node.GetInt("MSA_CYCLE");
                txtEquipRemark.Text = out_node.GetString("EQUIP_DESC");
                chkMSA.Checked = (out_node.GetChar("MSA_FLAG") == 'Y' ? true : false);
                chkSPC.Checked = (out_node.GetChar("SPC_FLAG") == 'Y' ? true : false);
                chkCalibration.Checked = (out_node.GetChar("CALI_FLAG") == 'Y' ? true : false);
                chkCheck.Checked = (out_node.GetChar("CHECK_FLAG") == 'Y' ? true : false);
                chkIdleEquipment.Checked = (out_node.GetChar("NONE_FLAG") == 'Y' ? true : false);

                if (out_node.GetChar("STANDARD_FLAG") == 'Y')
                    rdoStandardY.Checked = true;
                else
                    rdoStandardN.Checked = true;

                //Asset Info
                txtAssetNo.Text = out_node.GetString("PROP_NO"); //자산번호 
                txtVendorCode.Text = out_node.GetString("SUPPLY_CODE"); //공급사 코드 
                txtSerialNo.Text = out_node.GetString("SERIAL_NO");
                dtpPurchaseDate.Value = MPCF.ToDate(out_node.GetString("BUY_DATE"));
                nudPurchaseAmount.Value = MPCF.ToDecimal(out_node.GetDouble("BUY_COST"));
                cdvApplyUser.Text = out_node.GetString("APPROVE_USER_ID");
                cdvApplyUser.DescText = out_node.GetString("APPROVE_USER_NAME");
                chkApplyFlag.Checked = (out_node.GetChar("APPROVE_FLAG") == 'Y' ? true:false);

                // Customized Field
                cdvCMF1.Text = out_node.GetString("CMF_1");
                cdvCMF2.Text = out_node.GetString("CMF_2");
                cdvCMF3.Text = out_node.GetString("CMF_3");
                cdvCMF4.Text = out_node.GetString("CMF_4");
                cdvCMF5.Text = out_node.GetString("CMF_5");
                cdvCMF6.Text = out_node.GetString("CMF_6");
                cdvCMF7.Text = out_node.GetString("CMF_7");
                cdvCMF8.Text = out_node.GetString("CMF_8");
                cdvCMF9.Text = out_node.GetString("CMF_9");
                cdvCMF10.Text = out_node.GetString("CMF_10");
                
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));


                // Image 처리 추가 필요 
                List<TRSNode> equipment_image_list = out_node.GetList("EQUIPMENT_IMAGE_LIST");
                foreach (TRSNode node in equipment_image_list)
                {
                    fnAddImageFormServer(MPCF.Trim(node.GetString("FILE_NAME"))
                                            , MPCF.Trim(node.GetString("FILE_DESC"))
                                            , (byte[])out_node.GetBlob(MPCF.Trim(node.GetString("FILE_NAME"))));
                }

                // Relation Item 
                //ViewEquipmentRelationItemList(MPCF.Trim(txtEquipCode.Text));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateEquipment()
        //       - Update Equipment
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateEquipment(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_EQUIPMENT_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_EQUIPMENT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                //General Data
                in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                in_node.AddString("EQUIP_CODE", txtEquipCode.Text); //일단 동일 값으로 저장 
                in_node.AddString("EQUIP_NAME", txtEquipName.Text);
                in_node.AddString("EQUIP_TYPE", cdvEquipType.Text);
                in_node.AddString("EQUIP_NO", txtEquipNo.Text);
                in_node.AddString("MGT_DEPT_CODE", cdvMgtDept.Text);
                in_node.AddString("MGT_USER_ID", cdvMgtUser.Text);
                in_node.AddString("USE_DEPT_CODE", cdvUseDept.Text);
                in_node.AddString("USE_USER_ID", cdvUseUser.Text);
                in_node.AddString("USE_DIV", cdvUseDiv.Text);
                in_node.AddChar("CALI_DIV", (rdoCaliInside.Checked == true ? '0':'1'));
                in_node.AddString("EQUIP_MAKER", txtEquipMaker.Text);
                in_node.AddString("EQUIP_MODEL", txtEquipModel.Text);
                in_node.AddString("EQUIP_SPEC", txtEquipSpec.Text);
                in_node.AddString("EQUIP_PURPOSE", txtEquipPurpose.Text);
                in_node.AddString("EQUIP_FEATURE", txtEquipFeature.Text);
                in_node.AddString("EQUIP_PLACE_CODE", cdvInstallationPlace.Text);
                in_node.AddInt("CALI_CYCLE", nudCalibrationCycle.Value);
                in_node.AddInt("MSA_CYCLE", nudMSACycle.Value);
                in_node.AddChar("MSA_FLAG", (chkMSA.Checked == true ? 'Y':'N'));
                in_node.AddChar("SPC_FLAG", (chkSPC.Checked == true ? 'Y' : 'N'));
                in_node.AddChar("CALI_FLAG", (chkCalibration.Checked == true ? 'Y' : 'N'));
                in_node.AddChar("CHECK_FLAG", (chkCheck.Checked == true ? 'Y' : 'N'));
                in_node.AddChar("NONE_FLAG", (chkIdleEquipment.Checked == true ? 'Y' : 'N'));
                in_node.AddChar("STANDARD_FLAG", (rdoStandardY.Checked == true ? 'Y' : 'N'));
                
                //Asset Info
                in_node.AddString("PROP_NO", txtAssetNo.Text);
                in_node.AddString("SUPPLY_CODE", txtVendorCode.Text);
                in_node.AddString("SERIAL_NO", txtSerialNo.Text);
                in_node.AddString("BUY_DATE", dtpPurchaseDate.Value.ToString("yyyyMMdd"));
                in_node.AddInt("BUY_COST", nudPurchaseAmount.Value);
                in_node.AddString("APPROVE_USER_ID", cdvApplyUser.Text);
                in_node.AddChar("APPROVE_FLAG", (chkApplyFlag.Checked == true ? 'Y' : 'N'));
                
                // Customized Field                
                in_node.AddString("CMF_1", cdvCMF1.Text);
                in_node.AddString("CMF_2", cdvCMF2.Text);
                in_node.AddString("CMF_3", cdvCMF3.Text);
                in_node.AddString("CMF_4", cdvCMF4.Text);
                in_node.AddString("CMF_5", cdvCMF5.Text);
                in_node.AddString("CMF_6", cdvCMF6.Text);
                in_node.AddString("CMF_7", cdvCMF7.Text);
                in_node.AddString("CMF_8", cdvCMF8.Text);
                in_node.AddString("CMF_9", cdvCMF9.Text);
                in_node.AddString("CMF_10", cdvCMF10.Text);

                // Image Data 저장 추가 필요.
                if (UpdateEquipImage(in_node) == false) return false;

                //Equip Relation Item Data
                if (UpdateEquipRelationItem(in_node) == false) return false;
                
                if (MPCR.CallService("CMMS", "CMMS_Update_Equipment", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateEquipRelationItem()
        //       - Update Equip Relation Item
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private bool UpdateEquipRelationItem(TRSNode in_node)
        {
            TRSNode list_item;
            if (spdEquipItemList.ActiveSheet.RowCount == 0) return true;

            try
            {

                FarPoint.Win.Spread.SheetView with_1 = spdEquipItemList.ActiveSheet;

                for (int i = 0; i < spdEquipItemList.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("EQUIP_ITEM_LIST");

                    list_item.AddString("ITEM_CODE", MPCF.Trim(with_1.Cells[i, (int)MMS_EQUIP_ITEM.ITEM_CODE].Value));
                    list_item.AddString("ITEM_NAME", MPCF.Trim(with_1.Cells[i, (int)MMS_EQUIP_ITEM.ITEM_NAME].Value));
                    list_item.AddInt("ITEM_ORDER", (i + 1));
                    list_item.AddDouble("LSL", MPCF.ToDbl(with_1.Cells[i, (int)MMS_EQUIP_ITEM.LSL].Value));
                    list_item.AddDouble("USL", MPCF.ToDbl(with_1.Cells[i, (int)MMS_EQUIP_ITEM.USL].Value));
                    list_item.AddString("UNIT_CODE", MPCF.Trim(with_1.Cells[i, (int)MMS_EQUIP_ITEM.UNIT_CODE].Value));
                    list_item.AddInt("DECIMAL_PLACE", MPCF.ToInt(with_1.Cells[i, (int)MMS_EQUIP_ITEM.DECIMAL_PLACE].Value));
                    list_item.AddChar("USE_GRR_CONT_FLAG", (Convert.ToBoolean(with_1.Cells[i, (int)MMS_EQUIP_ITEM.USE_GRR_CONT_FLAG].Value) == true ? 'Y' : 'N'));
                    list_item.AddChar("USE_GRR_DISC_FLAG", (Convert.ToBoolean(with_1.Cells[i, (int)MMS_EQUIP_ITEM.USE_GRR_DISC_FLAG].Value) == true ? 'Y' : 'N'));
                    list_item.AddChar("USE_BIAS_FLAG", (Convert.ToBoolean(with_1.Cells[i, (int)MMS_EQUIP_ITEM.USE_BIAS_FLAG].Value) == true ? 'Y' : 'N'));
                    list_item.AddChar("USE_LINE_FLAG", (Convert.ToBoolean(with_1.Cells[i, (int)MMS_EQUIP_ITEM.USE_LINE_FLAG].Value) == true ? 'Y' : 'N'));
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateEquipImage()
        //       - Update Equip Image
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private bool UpdateEquipImage(TRSNode in_node)
        {
            TRSNode list_image;
            byte[] file_buffer;
            int i = 0;
            if (pnlImageList.Controls.Count == 0) return true;

            try
            {
                foreach (PictureBox picImage in pnlImageList.Controls)
                {                   
                    if (picImage.Image.Tag != null)
                    {
                        i++;
                        list_image = in_node.AddNode("EQUIP_IMAGE_LIST");

                        list_image.AddString("FILE_NAME", MPCF.Trim(picImage.Name));
                        list_image.AddString("FILE_DESC", MPCF.Trim(picImage.Tag.ToString()));
                        list_image.AddInt("FILE_ORDER", i);

                        file_buffer = (byte[])picImage.Image.Tag;
                        list_image.AddChar("IMAGE_FLAG", 'Y');
                        list_image.SetBlob(MPCF.Trim(picImage.Name), file_buffer);                        
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

        //
        // fnSortImage()
        //       - Update image list Sort
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        public void fnSortImage()
        {
            try
            {
                for (int i = 0; i < pnlImageList.Controls.Count; i++)
                {
                    pnlImageList.Controls[i].Location = new Point((i * 60), 0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        //
        // fnAddImage()
        //       - Add image
        // Return Value
        //       - 
        // Arguments
        //       - sFileName
        //
        public void fnAddImage(string sFileName, string sNewFlag)
        {
            try
            {
                string sShotFileName = System.IO.Path.GetFileName(sFileName);

                if (pnlImageList.Controls.Find(sShotFileName, true).Length > 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(631)); //The same filename exists
                    return;
                }

                System.IO.FileInfo fileinfo;
                System.IO.BinaryReader br;
                byte[] file_buffer;

                picImage = new PictureBox();                
                picImage.Name = sShotFileName; //System.IO.Path.GetFileName(sFileName);
                picImage.Image = Image.FromFile(sFileName);
                picImage.Size = imgSize;
                picImage.Location = new Point((pnlImageList.Controls.Count * 60), 0);
                picImage.BorderStyle = BorderStyle.FixedSingle;
                picImage.Tag = ""; //File Desc 사용 예정                
                fileinfo = new System.IO.FileInfo(sFileName);
                if (fileinfo.Exists == true)
                {
                    br = new System.IO.BinaryReader(fileinfo.OpenRead());
                    file_buffer = br.ReadBytes((int)fileinfo.Length);
                    picImage.Image.Tag = file_buffer;
                    br.Close();
                }

                picImage.Click += new System.EventHandler(this.PictureBox_Click);
                picImage.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
                pnlImageList.Controls.Add(picImage);

                PictureBox_Click(picImage, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // fnAddImage()
        //       - Add image
        // Return Value
        //       - 
        // Arguments
        //       - sFileName
        //
        public void fnAddImageFormServer(string sFileName, string sRemark, byte[] bImageData)
        {
            try
            {
                if (bImageData == null) return;

                System.IO.MemoryStream image_stream = new System.IO.MemoryStream(bImageData);

                picImage = new PictureBox();
                picImage.Name = sFileName; //System.IO.Path.GetFileName(sFileName);
                picImage.Image = Image.FromStream(image_stream);
                picImage.Size = imgSize;
                picImage.Location = new Point((pnlImageList.Controls.Count * 60), 0);
                picImage.BorderStyle = BorderStyle.FixedSingle;
                picImage.Tag = sRemark;
                picImage.Image.Tag = bImageData;

                picImage.Click += new System.EventHandler(this.PictureBox_Click);
                picImage.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
                pnlImageList.Controls.Add(picImage);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // fnAddImage()
        //       - Add image
        // Return Value
        //       - 
        // Arguments
        //       - sFileName
        //
        public void fnLoadImage(TRSNode out_node)
        {
            try
            {
                byte[] file_buffer;
                int i;

                for (i = 1; i < 6; i++) //5개 까지만 등록
                {
                    if ((file_buffer = out_node.GetBlob("__BIN_DATA_" + i.ToString())) != null)
                    {
                        System.IO.MemoryStream ms_buffer;
                        picImage = new PictureBox();
                        picImage.Name = out_node.GetString("IMGE_FILE_NAME_" + i.ToString());
                        picImage.Size = imgSize;
                        picImage.Location = new Point((pnlImageList.Controls.Count * 60), 0);
                        picImage.BorderStyle = BorderStyle.FixedSingle;
                        picImage.Tag = out_node.GetString("IMGE_FILE_DESC_" + i.ToString());

                        try
                        {
                            ms_buffer = new System.IO.MemoryStream();
                            ms_buffer.Write(file_buffer, 0, file_buffer.Length);
                            ms_buffer.Position = 0;

                            picImage.Image = Image.FromStream(ms_buffer);
                            picImage.Image.Tag = file_buffer;
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                        picImage.Click += new System.EventHandler(this.PictureBox_Click);
                        picImage.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
                        pnlImageList.Controls.Add(picImage);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // PictureBox_Click()
        //       -  
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                picImage = (PictureBox)sender;

                foreach (PictureBox ctl in pnlImageList.Controls)
                {
                    ctl.BorderStyle = BorderStyle.FixedSingle;
                }

                txtImageFileName.Text = picImage.Name;
                txtImageDescription.Text = picImage.Tag.ToString();
                picImage.BorderStyle = BorderStyle.Fixed3D;
                picViewImage.Image = picImage.Image;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // pictureBox_MouseHover()
        //       -  
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox picImageTip = (PictureBox)sender;
            try
            {
                ToolTip tip = new ToolTip();
                tip.SetToolTip(picImageTip, picImageTip.Name + (MPCF.Trim(picImageTip.Tag.ToString()) == "" ? "" : " - " + picImageTip.Tag.ToString()));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private int spdFindRow(FarPoint.Win.Spread.SheetView spdSheet, string sValues, int iFindCol)
        {
            int iRow = -1;
            try
            {              
                for (int i = 0; i < spdSheet.RowCount; i++)
                {
                    if (spdSheet.GetValue(i, iFindCol).ToString().Equals(sValues) == true)
                    {
                        iRow = i;
                        return iRow;                        
                    }
                }
                return iRow;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return iRow;                
            }
        }
        #endregion

        private void frmMMSEquipmentSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                SetGroupCmfItem();

                cdvViewUseDiv.Text = "0"; //초기 조회 시 사용 중인 측정기만 조회 

                btnRefresh.PerformClick();

                // TODO
                b_load_flag = true;
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

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisView, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                ViewEquipmentList();
                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtEquipCode.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisView, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisView, txtFind.Text, 0, true, false);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == false) return;

                if (UpdateEquipment(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE") == false) return;

                if (UpdateEquipment(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition("DELETE") == false) return;

                if (UpdateEquipment(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                MPCF.FieldClear(this.pnlRight);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtEquipCode.Text = lisView.SelectedItems[0].Text;
                    txtEquipName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewEquipment();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewUseDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewUseDept.Init();
                MPCF.InitListView(cdvViewUseDept.GetListView);
                cdvViewUseDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewUseDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewUseDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewUseDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvViewUseDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewMgtDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewMgtDept.Init();
                MPCF.InitListView(cdvViewMgtDept.GetListView);
                cdvViewMgtDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewMgtDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewMgtDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewMgtDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvViewMgtDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMgtDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMgtDept.Init();
                MPCF.InitListView(cdvMgtDept.GetListView);
                cdvMgtDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvMgtDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvMgtDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvMgtDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvMgtDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUseDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUseDept.Init();
                MPCF.InitListView(cdvUseDept.GetListView);
                cdvUseDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvUseDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvUseDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvUseDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvUseDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewUseDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewUseDiv.Init();
                MPCF.InitListView(cdvViewUseDiv.GetListView);
                cdvViewUseDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewUseDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewUseDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewUseDiv.GetListView, '1', MPGC.MP_GCM_MMS_USE_DIV) == true)
                {
                    cdvViewUseDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewControl_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(tabMain);
            ViewEquipmentList();
        }

        private void cdvUseDiv_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUseDiv.Init();
                MPCF.InitListView(cdvUseDiv.GetListView);
                cdvUseDiv.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvUseDiv.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvUseDiv.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvUseDiv.GetListView, '1', MPGC.MP_GCM_MMS_USE_DIV) == true)
                {
                    cdvUseDiv.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvInstallationPlace_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvInstallationPlace.Init();
                MPCF.InitListView(cdvInstallationPlace.GetListView);
                cdvInstallationPlace.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvInstallationPlace.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvInstallationPlace.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvInstallationPlace.GetListView, '1', MPGC.MP_GCM_MMS_PLACE_CODE) == true)
                {
                    cdvInstallationPlace.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMgtUser_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMgtUser.Init();
                MPCF.InitListView(cdvMgtUser.GetListView);
                cdvMgtUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvMgtUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMgtUser.SelectedSubItemIndex = 0;

                SECLIST.ViewSECUserList(cdvMgtUser.GetListView);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUseUser_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUseUser.Init();
                MPCF.InitListView(cdvUseUser.GetListView);
                cdvUseUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvUseUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvUseUser.SelectedSubItemIndex = 0;

                SECLIST.ViewSECUserList(cdvUseUser.GetListView);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvApplyUser_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvApplyUser.Init();
                MPCF.InitListView(cdvApplyUser.GetListView);
                cdvApplyUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvApplyUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvApplyUser.SelectedSubItemIndex = 0;

                SECLIST.ViewSECUserList(cdvApplyUser.GetListView);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkIdleEquipment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIdleEquipment.Checked == true)
            {
                chkMSA.Checked = false;
                chkSPC.Checked = false;
                chkCalibration.Checked = false;
                chkCheck.Checked = false;
            }
        }

        private void chkMgtDiv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkbox = (CheckBox)sender;
                if (chkbox.Checked == true)
                {
                    if (chkIdleEquipment.Checked == true)
                    {
                        chkIdleEquipment.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void btnImageDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (picViewImage == null) return;

                SaveFileDialog sfdFile = new SaveFileDialog(); ;
                sfdFile.Filter = "JPEG File(*.jpg)|*.jpg";
                sfdFile.FileName = "";

                if (sfdFile.ShowDialog() == DialogResult.OK)
                {
                    picViewImage.Image.Save(sfdFile.FileName);

                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = sfdFile.FileName;
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlImageList.Controls.Count > 4)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(632)); //Up to 5 images can be registered.
                    return;
                }
                OpenFileDialog ofdFile = new OpenFileDialog(); ;
                ofdFile.Filter = "JPEG File(*.jpg)|*.jpg";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    fnAddImage(ofdFile.FileName, "U");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (picImage == null) return;

                if (pnlImageList.Controls.Count > 0)
                {
                    pnlImageList.Controls.Remove(picImage);
                    picViewImage.Image = null;
                    txtImageFileName.Text = "";
                    txtImageDescription.Text = "";
                    picImage = null;
                    fnSortImage();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtImageDescription_TextChanged(object sender, EventArgs e)
        {
            if (picImage == null) return;
            picImage.Tag = txtImageDescription.Text;
        }

        private void spdItemList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdItemList.Sheets[0].Columns[1].Visible == false)
            {
                return;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            int iRow;
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdEquipItemList.ActiveSheet;

                FarPoint.Win.Spread.SheetView with_2 = spdItemList.ActiveSheet;

                for (int i = with_1.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(with_1.GetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK))) == true)
                    {
                        iRow = spdFindRow(with_2, with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.ITEM_CODE)).ToString(), MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_CODE));

                        if (iRow > -1)
                        {
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_ITEM.EQUIP_ITEM_FLAG), ' ');
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_ITEM.CHECK), false);
                            with_2.Rows[iRow].Visible = true;
                            with_1.Rows[i].Remove();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int iRow;
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;

                FarPoint.Win.Spread.SheetView with_2 = spdEquipItemList.ActiveSheet;

                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.CHECK))) == true && MPCF.ToChar(with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.EQUIP_ITEM_FLAG))) != 'Y')
                    {
                        iRow = spdFindRow(with_2, with_1.GetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_CODE)).ToString(), MPCF.ToInt(MMS_ITEM.ITEM_CODE));

                        if (iRow < 0)
                        {
                            iRow = with_2.RowCount;
                            with_2.RowCount++;
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_CODE), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.ITEM_CODE)));
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.ITEM_NAME), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.ITEM_NAME)));
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.LSL), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.LSL)));
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.USL), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.USL)));
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.UNIT_CODE), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.UNIT_CODE)));
                            with_2.SetValue(iRow, MPCF.ToInt(MMS_EQUIP_ITEM.DECIMAL_PLACE), with_1.GetValue(i, MPCF.ToInt(MMS_ITEM.DECIMAL_PLACE)));

                            with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.EQUIP_ITEM_FLAG), 'Y');
                            //with_1.SetValue(i, MPCF.ToInt(MMS_ITEM.CHECK), true);
                            with_1.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnItemSortUp_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdEquipItemList.ActiveSheet;
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.GetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK))) == true)
                    {
                        if (i > 0)
                        {
                            if (Convert.ToBoolean(with_1.GetValue(i - 1, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK))) != true)
                                with_1.MoveRow(i, i - 1, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnItemSortDown_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdEquipItemList.ActiveSheet;
                for (int i = with_1.RowCount - 1; i > -1; i--)
                {
                    if (Convert.ToBoolean(with_1.GetValue(i, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK))) == true)
                    {
                        if (i < with_1.RowCount - 1)
                        {
                            if (Convert.ToBoolean(with_1.GetValue(i + 1, MPCF.ToInt(MMS_EQUIP_ITEM.CHECK))) != true)
                                with_1.MoveRow(i, i + 1, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvEquipType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEquipType.Init();
                MPCF.InitListView(cdvEquipType.GetListView);
                cdvEquipType.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvEquipType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvEquipType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvEquipType.GetListView, '1', MPGC.MP_GCM_MMS_EQUIP_TYPE) == true)
                {
                    cdvEquipType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewEquipType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewEquipType.Init();
                MPCF.InitListView(cdvViewEquipType.GetListView);
                cdvViewEquipType.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewEquipType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewEquipType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewEquipType.GetListView, '1', MPGC.MP_GCM_MMS_EQUIP_TYPE) == true)
                {
                    cdvViewEquipType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewEquipType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(tabMain);
            ViewEquipmentList();
        }

        private void btnItemRefresh_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtEquipCode.Text) != "")
                ViewEquipmentRelationItemList(txtEquipCode.Text);
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Name == "tapRelationItem")
            {
                if (MPCF.Trim(txtEquipCode.Text) != "")
                    ViewEquipmentRelationItemList(txtEquipCode.Text);
            }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = -1;
                int iCol = -1;

                spdItemList.Search(0, txtItemSearch.Text, false, false, false, true, 0, 0, ref iRow, ref iCol);

                if (iRow > -1)
                    spdItemList.ActiveSheet.SetActiveCell(iRow, iCol);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);

            }
        }

        

        

        

    }
}
