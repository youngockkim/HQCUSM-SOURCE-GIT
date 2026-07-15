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
using SOI.DNM;
using Infragistics.Win.UltraWinGrid;
using SOI.HanwhaQcell.USModule.CWIP.Popup;
using System.Collections;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSModuleOQCResult : SOIBaseForm02
    {

        #region Property

        private TRSNode nodeLotInfo;
        private TRSNode nodeLotInfo2;

              
        #endregion



        #region Function

        public string str_cell;

        //조회 데이터 CLEAR
        private void clearFieldText()
        {
            txtGrade.Text = "";
            txtDefect.Text = "";
            txtCellInfo.Text = "";
            txtRemark.Text = "";

            cdvOqcGrade.Text = "";
            cdvOqcDefectCode.Text = "";
            cdvOqcCellLocation.Text = "";
            txtOqcRemark.Text = "";
        
        }
        //OQC 정보를 UPDATE 한다.
        private bool OQC_Update()
        {
            try
            {
              
                if (string.IsNullOrEmpty(txtworker.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(560), MSG_LEVEL.ERROR, true);
                    txtworker.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(561), MSG_LEVEL.ERROR, true);
                    txtLotID.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cdvOqcGrade.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(562), MSG_LEVEL.ERROR, true);
                    cdvOqcGrade.Focus();
                    return false;

                }


                if (cdvOqcGrade.Text != "G01")
                {
                    if (string.IsNullOrEmpty(cdvOqcDefectCode.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(563), MSG_LEVEL.ERROR, true);
                        cdvOqcDefectCode.Focus();
                        return false;

                    }

                    if (string.IsNullOrEmpty(cdvOqcCellLocation.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(564), MSG_LEVEL.ERROR, true);
                        cdvOqcCellLocation.Focus();
                        return false;

                    }
                }
                if (ViewLotCheck(txtLotID.Text) == false)
                {
                    txtLotID.Focus();
                    txtLotID.SelectAll();
                    return false;
                }

                                           

                TRSNode in_node = new TRSNode("CWIP_UPDATE_OQC_TECHNICIAN");
                TRSNode out_node = new TRSNode("CWIP_UPDATE_OQC_TECHNICIAN");
                MPCF.SetInMsg(in_node);
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("INS_TYPE", "TEC");
                in_node.AddString("INS_USER_ID", txtworker.Text);
                in_node.AddString("GRADE", cdvOqcGrade.Text);
                in_node.AddString("DEFECT_CODE", cdvOqcDefectCode.Text);
                in_node.AddString("CELL_INFO", cdvOqcCellLocation.Text);
                in_node.AddString("REMARK", txtOqcRemark.Text);
                in_node.AddString("CREATE_USER_ID", MPCF.Trim(MPGV.gsUserID));

                if (MPCF.CallService("CWIP", "CWIP_Update_Oqc_Technician", in_node, ref out_node) == false)
                {
                    return false;
                }
                cdvOqcGrade.Code = null;
                cdvOqcGrade.Description = null;
                cdvOqcDefectCode.Code = null;
                cdvOqcDefectCode.Description = null;
                cdvOqcCellLocation.Code = null;
                cdvOqcCellLocation.Description = null;
                txtOqcRemark.Text = "";
                txtLotID.Text = "";
                txtworker.Text = "";
                txtGrade.Text = "";
                txtDefect.Text = "";
                txtCellInfo.Text = "";
                txtRemark.Text = "";

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

        }

        //모듈 ID로 FQC 정보를 조회한다. 
        private void InitViews()
        {
            // Lot ID Check
            if (MPCF.CheckValue(txtLotID, false) == false)
            {
                return;
            }

            // LOT의 FQC 판정을 조회한다.
            if (ViewLot(txtLotID.Text) == false)
            {
                txtLotID.SelectAll();
                return;
            }

        }
  
        //LOT ID로 FQC 판정 정보를 가져오는 함수
        private bool ViewLotCheck(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_FQC_IN");
            TRSNode out_node = new TRSNode("VIEW_FQC_OUT");
            str_cell = "";
            // 1.LOT의 FQC 데이터를 조회한다.
                                
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
            in_node.AddChar("RE_JUDGE_FLAG", 'Y');

            if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                return false;
            }

            nodeLotInfo = out_node;

            str_cell = out_node.GetString("MAT_CMF_3"); 

            return true;
        }



        //LOT ID로 FQC 판정 정보를 가져오는 함수
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_FQC_IN");
            TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

            TRSNode in_node2 = new TRSNode("CWIP_VIEW_OQC_TECHNICIAN");
            TRSNode out_node2 = new TRSNode("CWIP_VIEW_OQC_TECHNICIAN");
            
            bool bEnable = true;


            try
            {
                // 1.LOT의 FQC 데이터를 조회한다.
                str_cell = "";
                clearFieldText();     //조회전 FQC 관련 필드 클리어

                MPCF.FieldClear(pnlMiddleMargin, txtLotID);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddChar("RE_JUDGE_FLAG", 'Y'); 

                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

                nodeLotInfo = out_node;
                txtGrade.Text = out_node.GetString("GRADE");
                txtRemark.Text = out_node.GetString("RLT_COMMENT");
                txtDefect.Text = out_node.GetString("DEFECT_CODE");
                txtCellInfo.Text = out_node.GetString("CELL_INFO");
                txtRemark.Text = out_node.GetString("RLT_COMMENT");

                str_cell = out_node.GetString("MAT_CMF_3"); 

                //2.OQC 데이터 이력을 조회한다.

                MPCF.SetInMsg(in_node2);

                in_node2.ProcStep = '1';
                in_node2.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node2.AddString("INS_TYPE", "TEC");

                
                MPCF.CallService("CWIP", "CWIP_View_Oqc_Technician", in_node2, ref out_node2);

                nodeLotInfo2 = out_node2;
                cdvOqcGrade.Text = out_node2.GetString("GRADE");
                cdvOqcDefectCode.Text = out_node2.GetString("DEFECT_CODE");
                cdvOqcCellLocation.Text = out_node2.GetString("CELL_INFO");
                txtOqcRemark.Text = out_node2.GetString("REMARK");
                txtworker.Text = out_node2.GetString("INS_USER_ID");

                if (cdvOqcGrade.Text == "G01")
                {
                    bEnable = false;
                }

                this.cdvOqcDefectCode.Enabled = bEnable;
                this.cdvOqcCellLocation.Enabled = bEnable;
                if (!bEnable)
                {
                    this.cdvOqcDefectCode.Text = "";
                    this.cdvOqcDefectCode.Description = "";
                    this.cdvOqcCellLocation.Text = "";
                    this.cdvOqcCellLocation.Description = "";
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


        public frmCUSModuleOQCResult()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitViews();
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                InitViews();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (OQC_Update())
                {
                    txtLotID.Focus();
                    txtLotID.SelectAll();

                   
                }
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        //워커 조회
        private void btnsearch2_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@OQC_WORKER");
                in_node.AddString("KEY_1", "TECHNICIAN");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "TECHNICIAN", "TECHNICIAN Name" };
                
                cdvTxtWorker.Text = "";
                cdvTxtWorker.Text = txtworker.Text;

                cdvTxtWorker.Text = cdvTxtWorker.Show(cdvTxtWorker, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "TECHNICIAN");

                // Validation
                if (string.IsNullOrEmpty(cdvTxtWorker.Text) == true)
                {
                    return;
                }

                
                txtworker.Text = cdvTxtWorker.Text;
                // Focus
                MPCF.SetFocus(txtworker);

                

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

       

        private void cdvOqcGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }
                bool bEnable = true;


                cdvOqcGrade.Text = "";
                cdvOqcGrade.Description = "";

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_GRADE));

                string[] header = new string[] { "Grade", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOqcGrade.Text = cdvOqcGrade.Show(cdvOqcGrade, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");


                if (MPCF.Trim(cdvOqcGrade.Text) != "")
                {
                    if (cdvOqcGrade.returnDatas.Count > 0)
                    {
                        cdvOqcGrade.Tag = cdvOqcGrade.returnDatas[1];
                    }

                }

                // Validation
                if (string.IsNullOrEmpty(cdvOqcGrade.Text) == true)
                {
                    MPCF.SetFocus(cdvOqcGrade);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvOqcGrade);

                if (cdvOqcGrade.Text == "G01")
                {
                    bEnable = false;
                }

                this.cdvOqcDefectCode.Enabled = bEnable;
                this.cdvOqcCellLocation.Enabled = bEnable;
                if (!bEnable)
                {
                    this.cdvOqcDefectCode.Text = "";
                    this.cdvOqcDefectCode.Description = "";
                    this.cdvOqcCellLocation.Text = "";
                    this.cdvOqcCellLocation.Description = "";
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }




        private void cdvOqcDefectCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_LOSS_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_OUT");

                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEFECT));
                in_node.AddString("KEY_2", "M3110");
                in_node.AddString("KEY_1", "E90");

                // CodeView Column Header Setup
                string[] header = new string[] { "Defect Code", "Defect Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_4" };

                // Show

                cdvOqcDefectCode.Text = cdvOqcDefectCode.Show(cdvOqcDefectCode, "Defect Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvOqcDefectCode.Text) != "")
                {
                    if (cdvOqcDefectCode.returnDatas.Count > 0)
                    {
                        cdvOqcDefectCode.Tag = cdvOqcDefectCode.returnDatas[1];
                    }

                }

                // Validation
                if (string.IsNullOrEmpty(cdvOqcDefectCode.Text) == true)
                {
                    MPCF.SetFocus(cdvOqcDefectCode);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvOqcDefectCode);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        
        }


        private void cdvOqcCellLocation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult drResult;

                frmCWIPCellLocationPopup f = new frmCWIPCellLocationPopup(cdvOqcCellLocation.Text, str_cell);
                f.Owner = MPGV.gfrmMDI;
                drResult = f.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    cdvOqcCellLocation.Text = f.ReturnValue;
                    //SetValidationOff();
                }
                if (drResult == DialogResult.No)
                {
                    cdvOqcCellLocation.Text = f.ReturnValue;
                    //SetValidationOff();
                }
                else
                {
                    // 아무것도 하지 않음
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOqcDefectCode_Load(object sender, EventArgs e)
        {

        }

      

   
     
    }
}
