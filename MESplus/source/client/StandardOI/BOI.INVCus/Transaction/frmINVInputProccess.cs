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
using BOI.OIFrx.BOIBaseForm;
using System.Collections;
using SOI.DNM;
using BOI.OIFrx;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVInputProccess : BOIBaseForm02
    {
        string ireceipt_Num = "";

        public enum ColWeightList
        {
            SELECT = 0,
            MAT_ID,
            MAT_DESC,
            DLV_QTY_1,
            LOT_CNT,
            ISSUE_PLACE,
            CAR_NO,
            SEQ,
            WEIGHT_DATE,
            CAR_MAT_TYPE,                        
            WEIGHT_IN,
            WEIGHT_OUT,
            WEIGHT_MEASURE,
            WEIGHT_REAL,
            WEIGHT_GAP,                
            CAR_IN_TIME,
            CAR_OUT_TIME,
            WEIGHT_PUT,
            IQC_FLAG,
            INV_LOT_ID,        
            DRIVER,
            INOUT_FLAG,
            INV_REQ_NO,
            PO_NO,
            PO_SEQ,
            IO_TYPE,
            IUD_FLAG
        }
        public enum INV_LOT_COL
        {
            SELECT = 0,
            MAT_ID,
            MAT_DESC,
            UNIT_1,
            LOT_ID,
            DLV_QTY_1,
            BULK_YN
        }

        private enum INV_LOT_COL2
        {
            CHECK_SELECT = 0,
            INV_LOT_ID,
            MAT_DESC,
            MAT_ID,
            TO_STORE,
            TO_STORE_CODE,
            UNIT,
            UNIT_QTY,
            TOTAL_QTY,
            FROM_STORE_CODE
        }

        private enum INV_SCANED_LOT
        {
            TO_STORE_CODE ,
            TO_STORE_DESC ,
            MAT_ID        ,
            MAT_DESC      ,
            BULK_YN       ,
            LOT_ID        ,
            LOT_QTY
        }

        #region Property

        // (Required) 
        private bool bIsShown = false;

        private string _dlv_no = "" ;
        private string _dlv_seq = "";
        private string _dlv_date = "" ;
        private string _dlv_type = "";
        private string _dlv_type_desc = "";
        private string _vendor_code = "";
        private string _vendor_desc = "";
        private string _po_no = "";
        private string _po_seq = "";
        private string _po_sts = "";

        public string Dlv_no
        {
            get { return _dlv_no; }
            set { _dlv_no = value; }
        }
        public string Dlv_seq
        {
            get { return _dlv_seq; }
            set { _dlv_seq = value; }
        }
        public string Dlv_date
        {
            get { return _dlv_date; }
            set { _dlv_date = value; }
        }

        public string Vendor_code
        {
            get { return _vendor_code; }
            set { _vendor_code = value; }
        }

        public string Vendor_desc
        {
            get { return _vendor_desc; }
            set { _vendor_desc = value; }
        }
        public string Po_no
        {
            get { return _po_no; }
            set { _po_no = value; }
        }
        public string Po_seq
        {
            get { return _po_seq; }
            set { _po_seq = value; }
        }
        public string Po_sts
        {
            get { return _po_sts; }
            set { _po_sts = value; }
        }
        public string Dlv_type
        {
            get { return _dlv_type; }
            set { _dlv_type = value; }
        }
        public string Dlv_type_desc
        {
            get { return _dlv_type_desc; }
            set { _dlv_type_desc = value; }
        }
   
        #endregion

        #region Constructor

        public frmINVInputProccess()
        {
            InitializeComponent();

            
        }

        public frmINVInputProccess(string receipt_Num)
        {
            InitializeComponent();

            ireceipt_Num = MPCF.Trim(receipt_Num);
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
           
            this.txtDlvNo.Text = this._dlv_no;
            this.txtDlvSeq.Text = this._dlv_seq;
            this.txtDlvdate.Text = this._dlv_date;
            //this.txtDlvSts.Text = this._po_sts;
            this.txtVendorCode.Text = this._vendor_code;
            this.txtVendorDesc.Text = this._vendor_desc;
            this.txtPoNo.Text = this._po_no;
            this.txtPoSeq.Text = this._po_seq;
            this.txtDlvType.Text = this._dlv_type;
            this.txtDlvTypeDesc.Text = this._dlv_type_desc;

            /*20170424 JYD 팝업일경우 표시*/
            if (this._dlv_no.Trim() != "")
            {
                this.lbPopup.Text = "Popup";
                pnlTop.BackColor = Color.Blue;
            }

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
 
            GetData();
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        #region Function
        private void GetData()
        {
            TRSNode in_node = new TRSNode("VIEW_DLV_IN");
            TRSNode out_node = new TRSNode("VIEW_DLV_OUT");


            try
            {
                MPCF.ClearList(spdReceipt);

                string matID = string.Empty;
                string matDesc = string.Empty;
                string scarNo = string.Empty;
                string scarFullNo = string.Empty;
                string sioType = string.Empty;
                string sioTypeDesc = string.Empty;
                string srawMilkMatId = string.Empty;
                string srawMilkMatDesc = string.Empty;
                string sinvLotId = string.Empty;
                string sweightDate = string.Empty;

                
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                //string sSql = null;
                string sMatId = string.Empty;
                string sOper = string.Empty;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "DLV_NO";
                dvcArgu[1].sCondition_Value = _dlv_no;

                if (TPDR.GetDataOne(s_column, ref dt, "OINV1008-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                }
                else
                {
                    MPCF.ClearList(spdReceipt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spdReceipt.Sheets[0].RowCount += 1;
                        spdReceipt.Sheets[0].Cells[spdReceipt.Sheets[0].RowCount - 1, (int)ColWeightList.SELECT].Value = 0;
                        //spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.DLV_SEQ].Value = dt.Rows[i]["DLV_SEQ"].ToString();
                        spdReceipt.Sheets[0].Cells[spdReceipt.Sheets[0].RowCount - 1, (int)ColWeightList.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        spdReceipt.Sheets[0].Cells[spdReceipt.Sheets[0].RowCount - 1, (int)ColWeightList.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                        spdReceipt.Sheets[0].Cells[spdReceipt.Sheets[0].RowCount - 1, (int)ColWeightList.DLV_QTY_1].Value = dt.Rows[i]["DLV_QTY_1"].ToString();
                        spdReceipt.Sheets[0].Cells[spdReceipt.Sheets[0].RowCount - 1, (int)ColWeightList.LOT_CNT].Value = dt.Rows[i]["LOT_CNT"].ToString();
                    }
                    MPCF.FitColumnHeader(spdReceipt);
                }


                dvcArgu = new TPDR.DirectViewCond[2];
                dt = null;
                //string sSql = null;
                sMatId = string.Empty;
                sOper = string.Empty;
                s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "DLV_NO";
                dvcArgu[1].sCondition_Value = _dlv_no;
                //dvcArgu[1].sCondtion_ID = "$LOT_ID";
                //dvcArgu[1].sCondition_Value = MPCF.Trim(txtInvLotID.Text);

                if (TPDR.GetDataOne(s_column, ref dt, "OINV1008-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                }
                else
                {
                    MPCF.ClearList(spdInvLot);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spdInvLot.Sheets[0].RowCount += 1;
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.SELECT].Value = 0;
                        //spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.DLV_SEQ].Value = dt.Rows[i]["DLV_SEQ"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.DLV_QTY_1].Value = dt.Rows[i]["DLV_QTY_1"].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.BULK_YN].Value = dt.Rows[i]["BULK_YN"].ToString();

                        
                    }
                    //MPCF.FitColumnHeader(spdInvLot);

                    //spdInvLot.Sheets[0].Columns[0].Width = 35 ; // JYD Fit이 먹지 않아 적용함 20170405
                       
                }

                //Scan 그리드 리셋'
                MPCF.ClearList(spdScanedInvLot);

               

            }

            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                //return false;
            }
            finally{

                 setFocus();
            }

            //return true;
        }

        private void scanLot() {
            scanLot("");
        }

        private void scanLot(string clsfct)
        {

            try
            {
                if (!string.IsNullOrEmpty(cdvToStoreID.Text))
                {
                    int selectedRow = 0 ;
                    int selectedRowCnt = 0;
                    //MPCF.ClearList(spdScanedInvLot);


                    if (clsfct == "SCAN")
                    {
                        for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                        {
                                spdScanedInvLot.Sheets[0].RowCount += 1;
                              
                                string lotId = (string)spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.LOT_ID].Value;

                                if (tbLotId.Text == lotId)
                                {
                                    selectedRow = i;
                                    selectedRowCnt++;
                                }
                                
                        }

                        if (selectedRowCnt == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(450), MSG_LEVEL.ERROR, false);
                        }
                        else
                        {
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.TO_STORE_CODE].Value = cdvToStoreID.Tag;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.TO_STORE_DESC].Value = cdvToStoreID.Value;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.MAT_ID].Value = spdInvLot.Sheets[0].Cells[selectedRow, (int)INV_LOT_COL.MAT_ID].Value;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.MAT_DESC].Value = spdInvLot.Sheets[0].Cells[selectedRow, (int)INV_LOT_COL.MAT_DESC].Value;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.BULK_YN].Value = spdInvLot.Sheets[0].Cells[selectedRow, (int)INV_LOT_COL.BULK_YN].Value;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.LOT_ID].Value = spdInvLot.Sheets[0].Cells[selectedRow, (int)INV_LOT_COL.LOT_ID].Value;
                            spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.LOT_QTY].Value = spdInvLot.Sheets[0].Cells[selectedRow, (int)INV_LOT_COL.DLV_QTY_1].Value;

                            spdInvLot.Sheets[0].RemoveRows(selectedRow, 1);

                        }


                    }
                    else { /*이동버튼을 눌렀을 때 */

                        for (int i = spdInvLot.Sheets[0].RowCount; i > 0 ; i--)
                        {
                            if (spdInvLot.Sheets[0].RowCount == 0)
                            {
                                //CMN133 ERROR - 최소한 1개 이상의 아이템을 선택해 주세요.
                                MPCF.ShowMessage(MPCF.GetMessage(133), MSG_LEVEL.ERROR, false);
                            }


                            if (spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.SELECT].Value != null && Convert.ToBoolean(spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.SELECT].Value) == true)
                            {

                                spdScanedInvLot.Sheets[0].RowCount += 1;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.TO_STORE_CODE].Value = cdvToStoreID.Tag;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.TO_STORE_DESC].Value = cdvToStoreID.Value;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.MAT_ID].Value = spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.MAT_ID].Value;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.MAT_DESC].Value = spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.MAT_DESC].Value;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.BULK_YN].Value = spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.BULK_YN].Value;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.LOT_ID].Value = spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.LOT_ID].Value;
                                spdScanedInvLot.Sheets[0].Cells[spdScanedInvLot.Sheets[0].RowCount - 1, (int)INV_SCANED_LOT.LOT_QTY].Value = spdInvLot.Sheets[0].Cells[i-1, (int)INV_LOT_COL.DLV_QTY_1].Value;

                                selectedRow = i-1;
                                selectedRowCnt--;

                                spdInvLot.Sheets[0].RemoveRows(selectedRow, 1);

                            }

                          

                        }


                       
                    
                    }
                }
                else
                {   //CMN446 ERROR - 이동창고를 선택해주세요.
                    MPCF.ShowMessage(MPCF.GetMessage(446), MSG_LEVEL.ERROR, false);
                }



               // MPCF.FitColumnHeader(spdScanedInvLot);
               // spdScanedInvLot.Sheets[0].Columns[0].Width = 80; // JYD Fit이 먹지 않아 적용함 20170405
               // spdScanedInvLot.Sheets[0].Columns[3].Width = 120; // JYD Fit이 먹지 않아 적용함 20170405
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                //return false;
            }
            finally
            {

                setFocus();
            }


        }

        private void setFocus()
        {
            this.tbLotId.Focus();
            this.tbLotId.Select();

        }
        
        #endregion



        private void soiButton5_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void soiTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
            }
        }

        private void cdvToStoreID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                dvcArgu[2].sCondtion_ID = "FLOW";
                dvcArgu[2].sCondition_Value = "";

                dvcArgu[3].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[3].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvToStoreID.Text = cdvToStoreID.Show(cdvToStoreID, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvToStoreID.Text) != "")
                {
                    if (cdvToStoreID.returnDatas.Count > 0)
                    {
                        cdvToStoreID.Tag = cdvToStoreID.returnDatas[0];
                    }
                    else
                    {
                        cdvToStoreID.Tag = "";
                    }
                }
                else
                {
                    cdvToStoreID.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {

                setFocus();
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            scanLot();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("MOVE_LOT_IN");
            TRSNode out_node = new TRSNode("MOVE_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                for (i = 0; i < spdScanedInvLot.Sheets[0].RowCount; i++)
                {
                    list_item = in_node.AddNode("RECEIPT_LIST"); //자재 MOVE는 Receive Transaction 처리

                    //To Store Oper
                    //list_item.AddString("TO_OPER", cdvToStoreID.Tag);//MPCF.Trim(boiSpread2.Sheets[0].Cells[i, (int)INV_LOT_COL2.TO_STORE_CODE].Value));
                    list_item.AddString("TO_OPER", MPCF.Trim(spdScanedInvLot.Sheets[0].Cells[i, (int)INV_SCANED_LOT.TO_STORE_CODE].Value));
                    
                    //자재 LotID
                    list_item.AddString("LOT_ID", MPCF.Trim(spdScanedInvLot.Sheets[0].Cells[i, (int)INV_SCANED_LOT.LOT_ID].Value));

                    //MAT_ID
                    list_item.AddString("MAT_ID", MPCF.Trim(spdScanedInvLot.Sheets[0].Cells[i, (int)INV_SCANED_LOT.MAT_ID].Value));
                    list_item.AddInt("MAT_VER", 1);

                    //txtDlvType
                    list_item.AddString("DLV_TYPE", MPCF.Trim( this.txtDlvType.Text ));

                    //DLV NO
                    list_item.AddString("DLV_NO", MPCF.Trim(this.txtDlvNo.Text));

                    //DLV NO
                    list_item.AddInt("DLV_SEQ", this.txtDlvSeq.Text );

                    //DLV SEQ

                    //계정그룹&계정그룹상세유형
                    //PO 납품일 경우R21 -> 구매입고
                    //MO 이송일 경우R41 -> 타공장이송입고 

                    if (txtDlvType.Text == "PO")
                    {   //계정
                        list_item.AddString("LOT_CMF_1", BIGC.B_INV_ACC_GRP_RECV_BUY); //LOT_CMF_1 계정그룹
                        list_item.AddString("LOT_CMF_2", BIGC.B_INV_ACC_DETAIL_BUY); //LOT_CMF_2 계정상세유형

                        //사유
                        list_item.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RGB); //LOT_CMF_7 사유그룹
                        list_item.AddString("LOT_CMF_8", BIGC.B_INV_RSN_DTL_RB1); //LOT_CMF_8 사유
                    }
                    else if (txtDlvType.Text == "MO")
                    {   //계정
                        list_item.AddString("LOT_CMF_1", BIGC.B_INV_ACC_GRP_FACTORY_BUY); //LOT_CMF_1 계정그룹
                        list_item.AddString("LOT_CMF_2", BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY); //LOT_CMF_2 계정상세유형

                        //사유
                        list_item.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RGC); //LOT_CMF_7 사유그룹
                        list_item.AddString("LOT_CMF_8",  BIGC.B_INV_RSN_DTL_RC1); //LOT_CMF_8 사유
                    }
                    else
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(460), MSG_LEVEL.WARNING, false);
                        //CMN460 ERROR - 입고 유형이 없습니다. 관리자에게 문의 하세요.
                    }

                    string bulk_yn = MPCF.Trim(spdScanedInvLot.Sheets[0].Cells[i, (int)INV_SCANED_LOT.BULK_YN].Value) ;

                    if (bulk_yn == "" )
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(461), MSG_LEVEL.WARNING, false);
                        //CMN461 ERROR - 벌크 자재 여부는 필수 선택사항 입니다.

                        return;
                    }
                   
                    list_item.AddString("LOT_CMF_14", bulk_yn);
                  
                    
                    
                }

                if (in_node.GetList("RECEIPT_LIST").Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.WARNING, false);
                    return;
                }
                else
                { }

                if (MPCF.CallService("BINV", "BINV_Tran_Receipt_Lot", in_node, ref out_node) == false) //BINV_Multi_Tran_Move_Inventory_Lot
                {
                    return;
                }
                MPCF.ShowMessage(MPCF.GetMessage(52), MSG_LEVEL.WARNING, false);
                MPCF.ClearList(spdScanedInvLot);
              
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                //return false;
            }
            finally
            {

                setFocus();
            }
        }

        private void soiGroupBox6_Click(object sender, EventArgs e)
        {

        }

        private void soiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtDlvdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void soiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void soiLabel7_Click(object sender, EventArgs e)
        {

        }

        private void soiLabel6_Click(object sender, EventArgs e)
        {

        }

        private void soiLabel8_Click(object sender, EventArgs e)
        {

        }

        private void txtDlvNo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void soiTableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void soiLabel2_Click(object sender, EventArgs e)
        {

        }

   

        private void tbLotId_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                scanLot("SCAN");
            }

        }

        private void spdInvLot_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
        //    int i = 0;
        //    if (e.ColumnHeader == false)
        //    {
        //        return;
        //    }
        //    if (e.Column != 0)
        //    {
        //        return;
        //    }
        //    bool allChecked = spdInvLot.ColumnHeader.Cells[0, 0].Value
        //                                                 == null ? false : (bool)spdInvLot.ColumnHeader.Cells[0, 0].Value;

        //    if (allChecked == true)
        //    {
        //        for (i = 0; i < spdInvLot.RowCount; i++)
        //        {
        //            spdInvLot.Cells[i, 0].Value = false;
        //        }
        //        spdInvLot.ColumnHeader.Cells[0, 0].Value = false;
        //    }
        //    else
        //    {
        //        for (i = 0; i < spdData_Sheet1.RowCount; i++)
        //        {
        //            if (spdData_Sheet1.Cells[i, 0].Locked == false)
        //            {
        //                spdData_Sheet1.Cells[i, 0].Value = true;
        //            }
        //        }
        //        spdData_Sheet1.ColumnHeader.Cells[0, 0].Value = true;
        //    }   
        }

      

        #region Function

        #endregion
    }
}
