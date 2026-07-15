using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.CliFrx;
using FarPoint.Win.Spread;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using SOI.CINV.Popup;
using System.Collections;
using SOI.OIFrx;
using BOI.INVCus.Popup;

namespace BOI.INVCus
{
    public partial class frmINVWeighInRawMilkCar : BOIBaseForm02
    {
        #region Enum
        
        public enum ColWeightList
        {
            SELECT = 0,
            IO_TYPE,
            ISSUE_PLACE,
            WEIGHT_DATE,
            CAR_NO,
            SEQ,
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
            TANKRRORY,
            RECEIPT_STORE,
            INOUT_FLAG,
            INV_REQ_NO,
            INV_REQ_SEQ,
            PO_NO,
            PO_SEQ,
            IUD_FLAG,
            GRADE,
            REQ_STATUS
        }

        public enum RadioVendorList { 
            ALL,
            DAIRY_FARM,
            TEAM,
            OTHER_FACTORT,
            DARIY_COMMITTEE,
            BUY
        }
    
        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string s_rdo_type = string.Empty;

        
        
        #endregion

        #region Constructor

        public frmINVWeighInRawMilkCar()
        {
            InitializeComponent();
        }
        public frmINVWeighInRawMilkCar(string args)
        {
            InitializeComponent();
            s_rdo_type = args;
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
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdWeightListByCar);

           
            InvisibleColumn();

           

            LockColumn();

            dtpWeightDate.SetValueAsDateTime(DateTime.Now);
            dtpCarInTime.SetValueAsDateTime(DateTime.Now);
            dtpCarOutTime.SetValueAsDateTime(DateTime.Now);

            cmbInHour.Text = DateTime.Now.AddHours(-1).ToString("HH");
            cmbOutHour.Text = DateTime.Now.ToString("HH");
            //cmbInMinute.Text = (DateTime.Now.Minute - DateTime.Now.Minute % 10).ToString();
            cmbInMinute.Text = DateTime.Now.ToString("mm");
            //cmbOutMinute.Text = (DateTime.Now.Minute - DateTime.Now.Minute % 10).ToString();
            cmbOutMinute.Text = DateTime.Now.ToString("mm");
            SelectRadioType(s_rdo_type);
   
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
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                                                                
                // (Required) 
                bIsShown = true;
            }
        }

        

        
        private void cdvCarNo_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {           
                TRSNode in_node = new TRSNode("VIEW_MILK_CAR_IN");
                TRSNode out_node = new TRSNode("VIEW_MILK_CAR_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_MILKCAR_TANK));

                // CodeView Column Header Setup
                string[] header = new string[] { "Car Code", "Material", "Driver", "Car No" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2", "DATA_3" };

                // Show
                cdvCarNo.Text = cdvCarNo.Show(cdvCarNo, "Tank Lorry", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_3");

                if (MPCF.Trim(cdvCarNo.Text) != "")
                {
                    if (cdvCarNo.returnDatas.Count > 0)
                    {
                        cdvCarNo.Tag = cdvCarNo.returnDatas[0];
                        txtDriver.Text = cdvCarNo.returnDatas[2];                     
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInputInType_Click(object sender, EventArgs e)
        {
            string sinvReqNo = string.Empty;
            int iinvReqSeq = 0;
            string sinType = string.Empty;
            string sinTypeDesc = string.Empty;
            string srawMilkMatId = string.Empty;
            string srawmilkMatDesc = string.Empty;
            string spoNo = string.Empty;
            int ipoSeq = 0;
            string scarCode = string.Empty;
            string scarCodeDesc = string.Empty;
            string sreceiptStore = string.Empty;
            string sreceiptStoreDesc = string.Empty;
            int icurRow = 0;

            string sVendor = string.Empty;
            string sVendorDesc = string.Empty;
           

            try
            {                
                if (!CheckConditions("INPUT_TYPE"))
                {
                    return;
                }

                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                sinType = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.IO_TYPE].Tag);
                sinTypeDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.IO_TYPE].Value);                
                srawMilkMatId = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Tag);
                srawmilkMatDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Value);
                spoNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.PO_NO].Value);
                ipoSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.PO_SEQ].Value);
                scarCode = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.TANKRRORY].Tag);
                scarCodeDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.TANKRRORY].Value);
                sreceiptStore = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.RECEIPT_STORE].Tag);
                sreceiptStoreDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.RECEIPT_STORE].Value);

                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_In");
                TRSNode out_node;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_REQ_NO", MPCF.Trim(sinvReqNo));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(iinvReqSeq));
                out_node = new TRSNode("View_Weight_Rawmilk_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }
                sVendor = MPCF.Trim(out_node.GetList(0)[0].GetString("REQ_DTL_CMF_3"));
                sVendorDesc = MPCF.Trim(out_node.GetList(0)[0].GetString("REQ_DTL_CMF_3_DESC"));

                frmINVInputInTypePopup frm = new frmINVInputInTypePopup();
                frm.InvReqNo = sinvReqNo;
                frm.InvReqSeq = iinvReqSeq;
                frm.CarNo = MPCF.Trim(txtCarNo.Text);
                frm.CarFullNo = MPCF.Trim(txtCarNo.Text);
                frm.WeightDate = dtpWeightDate.GetValueAsDateTime();
                frm.WeightIn = MPCF.ToDbl(txtWeightIn.Value);
                frm.WeightOut = MPCF.ToDbl(txtWeightOut.Value);
                frm.InType = sinType;
                frm.InTypeDesc = sinTypeDesc;
                frm.RawmilkMaterial = srawMilkMatId;
                frm.RawmilkMaterialDesc = srawmilkMatDesc;
                frm.PoNo = spoNo;
                frm.PoSeq = ipoSeq;
                frm.CarCode = scarCode;
                frm.CarCodeDesc = scarCodeDesc;
                frm.ReceiptStore = sreceiptStore;
                frm.ReceiptStoreDesc = sreceiptStoreDesc;
                frm.VendorId = sVendor;
                frm.VendorDesc = sVendorDesc;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.INOUT_FLAG, frm.IoFlag);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.INOUT_FLAG, frm.IoFlagDesc);
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.IO_TYPE, frm.InType);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.IO_TYPE, frm.InTypeDesc);
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.CAR_MAT_TYPE, frm.RawmilkMaterial);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.CAR_MAT_TYPE, frm.RawmilkMaterialDesc);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.PO_NO, frm.PoNo);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.PO_SEQ, frm.PoSeq);
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.TANKRRORY, frm.CarCode);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.TANKRRORY, frm.CarCodeDesc);
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.RECEIPT_STORE, frm.ReceiptStore);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.RECEIPT_STORE, frm.ReceiptStoreDesc);

                    btnView_Click(btnView, new EventArgs());
                }  
                                    
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckConditions("DELETE"))
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (UpdateWeightRawmilk('D', '1') == true)
                {
                    spdWeightListByCar.Sheets[0].ActiveRow.Remove();
                    spdWeightListByCar.Sheets[0].SetActiveCell(spdWeightListByCar.Sheets[0].ActiveRowIndex, 0, true);
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckConditions("UPDATE"))
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(373), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (UpdateWeightRawmilk('U', '1') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {                        
            try
            {
                if (!CheckConditions("VIEW"))
                {
                    return;
                }

                MPCF.ClearList(this.spdWeightListByCar);

                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_List_In");

                TRSNode out_node;
                ArrayList lisWeight = new ArrayList();

                string steamCode = string.Empty;
                string steamDesc = string.Empty;
                string scarNo = string.Empty;
                string scarFullNo = string.Empty;
                string sioType = string.Empty;
                string sioTypeDesc = string.Empty;
                string srawMilkMatId = string.Empty;
                string srawMilkMatDesc = string.Empty;
                string sinvLotId = string.Empty;
                string sweightDate = string.Empty;
                int icarSeq = 0;
                double dweightIn = 0.0d;
                double dweightOut = 0.0d;
                double dweightMeasure = 0.0d;
                double dweightGap = 0.0d;
                double dweightReal = 0.0d;                
                double dweightPut = 0.0d;
                string sinTime = string.Empty;
                string soutTime = string.Empty;
                string scarDriverId = string.Empty;
                string scarDriverName = string.Empty;
                char ciqcFlag = ' ';
                string sinoutFlagDesc = string.Empty;
                string sinoutFlag = string.Empty;
                string sinvReqNo = string.Empty;
                int sinvReqSeq = 0;
                string spoNo = string.Empty;
                int ipoSeq = 0;
                string scarCode = string.Empty;
                string scarCodeDesc = string.Empty;
                string sreceiptStore = string.Empty;
                string sreceiptStoreDesc = string.Empty;
                sweightDate = dtpWeightDate.GetValueAsString(8);
                string sGrade = string.Empty;
                char sReqStatus = ' ';

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("REQ_DATE", MPCF.Trim(sweightDate));
                in_node.AddChar("IO_FLAG", BIGC.B_IO_FLAG_IN);
                in_node.AddString("CAR_NO", MPCF.Trim(txtCarNo.Text));

                if (rdoViewType.CheckedIndex == (int)RadioVendorList.DAIRY_FARM)
                {
                    in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_DAIRY_FARM));
                }
                else if (rdoViewType.CheckedIndex == (int)RadioVendorList.TEAM)
                {
                    in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_TEAM));
                }
                else if (rdoViewType.CheckedIndex == (int)RadioVendorList.OTHER_FACTORT)
                {
                    in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY));
                }
                else if (rdoViewType.CheckedIndex == (int)RadioVendorList.DARIY_COMMITTEE)
                {
                    in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_DAIRY_COMMITTEE));
                }
                else if (rdoViewType.CheckedIndex == (int)RadioVendorList.BUY)
                {
                    in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_BUY));
                }
                //in_node.AddString
                

                out_node = new TRSNode("View_Weight_Rawmilk_List_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk_List", in_node, ref out_node) == false)
                {
                    return;
                }

                lisWeight.Add(out_node);

                int iRow = 0;
                foreach (object obj in lisWeight)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdWeightListByCar.Sheets[0].Rows.Count++;
                        
                        steamCode = MPCF.Trim(out_node.GetList(0)[i].GetString("TEAM_CODE"));
                        steamDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("TEAM_DESC"));
                        scarNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_NO"));                        
                        scarFullNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_FULL_NO"));                        
                        icarSeq = out_node.GetList(0)[i].GetInt("CAR_SEQ");
                        sioType = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_TYPE"));
                        sioTypeDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_TYPE_DESC"));
                        srawMilkMatId = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_ID"));
                        srawMilkMatDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_DESC"));
                        dweightIn = out_node.GetList(0)[i].GetDouble("WEIGHT_IN");
                        dweightOut = out_node.GetList(0)[i].GetDouble("WEIGHT_OUT");
                        dweightMeasure = out_node.GetList(0)[i].GetDouble("WEIGHT_MEASURE");
                        dweightReal = out_node.GetList(0)[i].GetDouble("WEIGHT_REAL");
                        dweightGap = dweightMeasure - dweightReal;
                        dweightPut = out_node.GetList(0)[i].GetDouble("WEIGHT_PUT");
                        sinTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_IN_TIME"));
                        soutTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_OUT_TIME"));
                        scarDriverId = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_ID"));
                        scarDriverName = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_NAME"));
                        ciqcFlag = out_node.GetList(0)[i].GetChar("IQC_FLAG");
                        sinoutFlagDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_FLAG_DESC"));                        
                        sinoutFlag = MPCF.Trim(out_node.GetList(0)[i].GetChar("IO_FLAG"));
                        //sinvLotId = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_LOT_ID"));
                        sinvReqNo = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_REQ_NO"));
                        sinvReqSeq = out_node.GetList(0)[i].GetInt("INV_REQ_SEQ");
                        spoNo = MPCF.Trim(out_node.GetList(0)[i].GetString("ERP_REQ_NO"));                        
                        ipoSeq = out_node.GetList(0)[i].GetInt("ERP_REQ_SEQ");
                        scarCode = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_CODE"));
                        scarCodeDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_CODE_DESC"));
                        sreceiptStore = MPCF.Trim(out_node.GetList(0)[i].GetString("RECIEPT_STORE"));
                        sreceiptStoreDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("RECIEPT_STORE_DESC"));
                        sGrade = MPCF.Trim(out_node.GetList(0)[i].GetString("REQ_DTL_CMF_8")); //grade
                        sReqStatus = out_node.GetList(0)[i].GetChar("REQ_STATUS");

                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.ISSUE_PLACE, steamCode);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_PLACE, steamDesc);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.CAR_NO, scarNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_NO, scarFullNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.SEQ, icarSeq);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_DATE, MPCF.MakeDateFormat(dtpWeightDate.GetValueAsString(8), DATE_TIME_FORMAT.DATE));
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.IO_TYPE, sioType);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.IO_TYPE, sioTypeDesc);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.CAR_MAT_TYPE, srawMilkMatId);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_MAT_TYPE, srawMilkMatDesc);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_IN, dweightIn);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                        if (sinTime != "")
                        {
                            spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(sinTime));
                        }

                        if (soutTime != "") 
                        {
                            spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(soutTime));
                        }
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_PUT, dweightPut);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.IQC_FLAG, ciqcFlag);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.IQC_FLAG, ciqcFlag);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_LOT_ID, sinvLotId);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.DRIVER, scarDriverName);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.INOUT_FLAG, sinoutFlag);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INOUT_FLAG, sinoutFlagDesc);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_REQ_NO, sinvReqNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_REQ_SEQ, sinvReqSeq);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.PO_NO, spoNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.PO_SEQ, ipoSeq);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.TANKRRORY, scarCode);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.TANKRRORY, scarCodeDesc);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.RECEIPT_STORE, sreceiptStore);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.RECEIPT_STORE, sreceiptStoreDesc);
                        if (dweightGap < 0)
                            spdWeightListByCar.Sheets[0].Cells[iRow, (int)ColWeightList.WEIGHT_GAP].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
                        if (i == 0)
                        {
                            spdWeightListByCar_RowFocusChanged(0, i);
                        }
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.GRADE, sGrade);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.REQ_STATUS, sReqStatus.ToString());


                        /*******************************************************/
                        /**** 상태 색상표시 *****/
                        lbEndX.Appearance.BackColor = Color.Red;
                        lb2ndX.Appearance.BackColor = Color.Yellow;
                        lbTnkX.Appearance.BackColor = Color.Lime;
                        lbIQCX.Appearance.BackColor = Color.Green;
                        lbRealX.Appearance.BackColor = Color.Aqua;

                        /*20170426 JYD 입고처리 미완료 색깔표시*/
                        if (String.Equals(sReqStatus.ToString(), "E", StringComparison.Ordinal) == false)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Red;

                        }
                        /*20170426 JYD 2차계근되지 않은 건 색깔표시*/
                        if (dweightOut < 1)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Yellow;

                        }
                        /*20170426 JYD 탱크입력누락 색깔표시*/
                        if (dweightPut < 1)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Lime;

                        }
                        /*20170426 JYD 원유미검사 색깔표시*/
                        if (String.Equals(ciqcFlag.ToString(), "Y", StringComparison.Ordinal) == false)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Green;

                        }

                        /*20170426 JYD 전표미등록 색깔표시*/
                        if (dweightReal < 1)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Aqua;
                            
                        }

     
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        

      

        private void spdWeightListByCar_Change(object sender, ChangeEventArgs e)
        {
            //if (MPCF.ToChar(spdWeightListByCar.Sheets[0].Cells[e.Row, (int)ColWeightList.IUD_FLAG].Value) != 'I')
            //{
            //    spdWeightListByCar.Sheets[0].Cells[e.Row, (int)ColWeightList.IUD_FLAG].Value = 'U';
            //}
        }                              

        private void spdWeightListByCar_RowFocusChanged(int iprvRow, int icurRow)
        {

            try
            {                
                if (icurRow >= 0)
                {
                    spdWeightListByCar.Sheets[0].ActiveRowIndex = icurRow;
                    spdWeightListByCar.Sheets[0].SetActiveCell(icurRow, 0, true);
                    dtpWeightDate.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_DATE].Value);
                    txtCarNo.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_NO].Tag);
                    txtCarNo.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_NO].Value);
                    txtCarSeq.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.SEQ].Value);
                    dtpCarInTime.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value);
                    cmbInHour.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value).ToString("HH");
                    cmbInMinute.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value).ToString("mm");
                    dtpCarOutTime.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value);
                    cmbOutHour.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value).ToString("HH");
                    cmbOutMinute.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value).ToString("mm");

                    txtDriver.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.DRIVER].Value);
                    txtWeightIn.Value = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_IN].Value);
                    txtWeightOut.Value = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_OUT].Value);

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            try
            {

                if (!CheckConditions("ADD"))
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(373), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (!UpdateWeightRawmilk('I', '1'))
                {
                    return;
                }   
                
                
             
                
                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (!CheckConditions("DEL_RES"))
                {
                    return;
                }

                int icurRowByCar = 0;
                int icurRow = 0;                
                int idelTankRow = 0;

                icurRowByCar = spdWeightListByCar.Sheets[0].ActiveRowIndex;
                icurRow = spdCarResList.Sheets[0].ActiveRowIndex;
                if (icurRow >= 0)
                {                                        

                    if (MPCF.ToChar(spdCarResList.Sheets[0].Cells[icurRow, (int)ColCraResList.IUD_FLAG].Value) != 'I')
                    {
                        idelTankRow = spdDelCarResList.Sheets[0].RowCount++;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.CLEAN_TANK].Tag = spdCarResList.Sheets[0].Cells[icurRow, (int)ColCraResList.CLEAN_TANK].Tag;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.CLEAN_TANK].Value = spdCarResList.Sheets[0].Cells[icurRow, (int)ColCraResList.CLEAN_TANK].Value;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.WEIGHT_TANK].Value = spdCarResList.Sheets[0].Cells[icurRow, (int)ColCraResList.WEIGHT_TANK].Value;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.CAR_NO].Tag = spdWeightListByCar.Sheets[0].Cells[icurRowByCar, (int)ColWeightList.CAR_NO].Tag;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.WEIGHT_DATE].Value = spdWeightListByCar.Sheets[0].Cells[icurRowByCar, (int)ColWeightList.WEIGHT_DATE].Value;
                        spdDelCarResList.Sheets[0].Cells[idelTankRow, (int)ColCraResList.CAR_SEQ].Value = spdWeightListByCar.Sheets[0].Cells[icurRowByCar, (int)ColWeightList.CAR_SEQ].Value;
                    }

                    spdCarResList.Sheets[0].ActiveRow.Remove();
                }
                */
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
       

        private void btnInputWeightSlip_Click(object sender, EventArgs e)
        {
            
            //2017.03.18 전표 수량만 입력하도록 로직이 변경되어 주석처리
            //try
            //{
            //    if (spdWeightListByCar.Sheets[0].ActiveRowIndex >= 0)
            //    {
            //        double weightMeasure = 0.0d;
            //        int icurRow = 0;
            //        icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;


            //        weightMeasure = MPCF.ToDbl(spdWeightListByCar.Sheets[0].GetValue(icurRow, (int)ColWeightList.WEIGHT_MEASURE));

            //        if (MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(icurRow, (int)ColWeightList.IO_TYPE)) == "")
            //        {
            //            MPCF.ShowMessage(MPCF.GetMessage(411), MSG_LEVEL.ERROR, false);
            //            return;
            //        }
            //        //MenuInfoTag selectedMenuInfo;

            //        string activeInvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value);
            //        int activeInvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value);
            //        string sarg = string.Empty;
            //        sarg = activeInvReqNo + ":" + activeInvReqSeq.ToString();

            //        ///////////// 품번유형 선택 여부 조회 //////////////////
            //        TRSNode in_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_IN");
            //        TRSNode out_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_OUT");
            //        MPCF.SetInMsg(in_node);
            //        in_node.ProcStep = '1';
            //        in_node.SetString("INV_REQ_NO", activeInvReqNo);
            //        in_node.SetInt("INV_REQ_SEQ", activeInvReqSeq);

            //        if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
            //        {
            //            return;
            //        }

                    
            //        if (MPCF.Trim(out_node.GetList(0)[0].GetString("MAT_ID")) == " "){
            //            MPCF.ShowMessage(MPCF.GetMessage(165), MSG_LEVEL.ERROR, false);
            //            return;
            //        }

            //        //////////////////////////////////////////////////


            //        frmINVInputCollectionRawmilk frm = new frmINVInputCollectionRawmilk(sarg);                    
            //        frm.ShowDialog();


            //        spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.WEIGHT_REAL, frm.WeightSlip);
            //        spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.WEIGHT_GAP, weightMeasure - frm.WeightSlip);
            //    }
            //    else
            //    {
            //        return;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}


            string sinvReqNo = string.Empty;
            int iinvReqSeq = 0;
            int icurRow = 0;
            //string sMatId = string.Empty;
            //int iMatVer = 0;
            double dWeightReal = 0.0;
            double dWeightMeasure = 0.0;
            try
            {
                if (!CheckConditions("INPUT_TYPE"))
                {
                    return;
                }

                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                dWeightReal = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_REAL].Value);
                //sMatId = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Value);
                frmINVInputWeightQtyPopup frm = new frmINVInputWeightQtyPopup();
                frm.InvReqNo = sinvReqNo;
                frm.InvReqSeq = iinvReqSeq;
                frm.WeightReal = dWeightReal;
                frm.CarNo = MPCF.Trim(txtCarNo.Text);
                frm.CarFullNo = MPCF.Trim(txtCarNo.Text);
                frm.WeightDate = dtpWeightDate.GetValueAsDateTime();
                frm.WeightIn = MPCF.ToDbl(txtWeightIn.Value);
                frm.WeightOut = MPCF.ToDbl(txtWeightOut.Value);
                

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.WEIGHT_REAL, MPCF.ToDbl(frm.WeightReal));
                    dWeightMeasure = MPCF.ToDbl(spdWeightListByCar.Sheets[0].GetValue(icurRow, (int)ColWeightList.WEIGHT_MEASURE));
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.WEIGHT_GAP, dWeightMeasure - MPCF.ToDbl(frm.WeightReal));
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            
        }

        private void btnPutInTank_Click(object sender, EventArgs e)
        {
            string sinvReqNo = string.Empty;
            int iinvReqSeq = 0;
            string sMaterial = string.Empty;
            int icurRow = 0;
            string grade = string.Empty;

            try
            {
                if (!CheckConditions("PUT_IN_TANK"))
                {
                    return;
                }

                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;
                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq =MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                sMaterial = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Tag);
                grade = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.GRADE].Value);

                ///////////// 수입검사 여부 조회 //////////////////
                TRSNode in_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_IN");
                TRSNode out_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("INV_REQ_NO", sinvReqNo);
                in_node.SetInt("INV_REQ_SEQ", iinvReqSeq);

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }
                
                if (MPCF.ToChar(out_node.GetList(0)[0].GetChar("IQC_FLAG")) != 'Y')
                {
                    MPCF.ShowMessage(MPCF.GetMessage(421), MSG_LEVEL.ERROR, false);
                    return;
                }
             
                //////////////////////////////////////////////////

                frmINVPutInTankPopup frm = new frmINVPutInTankPopup();
                frm.InvReqNo = sinvReqNo;
                frm.Material = sMaterial;
                frm.InvReqSeq = iinvReqSeq;
                frm.WeightReal = MPCF.ToDbl(out_node.GetList(0)[0].GetDouble("WEIGHT_REAL"));
                frm.Grade = grade;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.WEIGHT_PUT, frm.WeightTank);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnWeightIn_Click(object sender, EventArgs e)
        {
            string scarNo = string.Empty;
            string sweightDate = string.Empty;
            double dweightIn = 0.0d;
            double dweightOut = 0.0d;
            string sinTime = string.Empty;
            string soutTime = string.Empty;
            try
            {
                scarNo = MPCF.Trim(txtCarNo.Text);                
                sweightDate = dtpWeightDate.GetValueAsString(8);               
                dweightIn = MPCF.ToDbl(txtWeightIn.Value);
                dweightOut = MPCF.ToDbl(txtWeightOut.Value);                
                sinTime = dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00";
                soutTime = dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00";

                //Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);
                

                TRSNode node = new TRSNode("Weight_In_Rawmilk_In");
                MPCF.SetInMsg(node);
                node.ProcStep = '1';
                node.SetString("_MC_CHANNEL", "MCCHANNEL");
                node.SetString("CAR_NO", scarNo);
                node.SetString("CAR_IN_DATE", sweightDate);
                node.SetString("CAR_IN_TIME", sinTime);
                node.SetDouble("WEIGHT_IN", dweightIn);
                node.SetString("MAT_ID", MPCF.Trim("310306"));
                if (cmbVendor.SelectedIndex == 1)
                {
                    node.SetString("VENDOR_ID", MPCF.Trim("2908"));
                }
                else if (cmbVendor.SelectedIndex == 2) {
                    node.SetString("VENDOR_ID", MPCF.Trim("2912"));
                }
                
                
                if (MPCF.CallService("BEIS", "MCEIS_Tran_Weight_In_Rawmilk", node, SOI.MsgHandlerH101.DeliveryMode.Unicast) == false)
                {
                    return;
                }

                //if (MPCF.CallService("BEIS", "MCEIS_Tran_Weight_In_Rawmilk", node, "/TiGate/Tunner", 30000, SOI.MsgHandlerH101.DeliveryMode.Unicast, false) == false)
                //{
                //    return;
                //}

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnWeightOut_Click(object sender, EventArgs e)
        {
            string scarNo = string.Empty;
            string sweightDate = string.Empty;
            double dweightIn = 0.0d;
            double dweightOut = 0.0d;
            string sinTime = string.Empty;
            string soutTime = string.Empty;
            try
            {
                scarNo = MPCF.Trim(txtCarNo.Text);
                sweightDate = dtpWeightDate.GetValueAsString(8);
                dweightIn = MPCF.ToDbl(txtWeightIn.Value);
                dweightOut = MPCF.ToDbl(txtWeightOut.Value);
                sinTime = dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00";
                soutTime = dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00";
                //Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);


                TRSNode node = new TRSNode("Weight_In_Rawmilk_Out");
                MPCF.SetInMsg(node);
                node.ProcStep = '1';
                node.SetString("_MC_CHANNEL", "MCCHANNEL");
                node.SetString("CAR_NO", scarNo);
                node.SetString("CAR_OUT_DATE", sweightDate);
                node.SetString("CAR_OUT_TIME", soutTime);
                node.SetDouble("WEIGHT_OUT", dweightOut);


                if (MPCF.CallService("BEIS", "MCEIS_Tran_Weight_Out_Rawmilk", node, SOI.MsgHandlerH101.DeliveryMode.Unicast) == false)
                {
                    return;
                }

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void h101TunerSwitch1_DataReceived(TRSNode node)
        {
            MPCF.ShowMessage("MC수신완료", MSG_LEVEL.INFO, true);
        }

        private void h101TunerSwitch2_DataReceived(TRSNode node)
        {
            if (node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                MPCF.CheckContinueProc(node, false);
                
            }
            else
            {
                //dtpWeightDate.Value = MPCF.ToDate(node.GetString("CAR_IN_DATE"));
                btnView_Click(btnView, new EventArgs());
            }
            
        }

        private void btnIqc_Click(object sender, EventArgs e)
        {
            //임시사용
            UpdateIQCFlag();
        }

        private void btnInConfirm_Click(object sender, EventArgs e)
        {
            if (!CheckConditions("CONFIRM"))
            {
                return;
            }


            string sinvReqNo = string.Empty;
            int iinvReqSeq= 0;
            try
            {
                if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                int selectRowIndex = spdWeightListByCar.Sheets[0].ActiveRowIndex;
                
                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value);
                frmInvRawmilkConfirmPopup frm = new frmInvRawmilkConfirmPopup();
                frm.S_inv_req_no = sinvReqNo;
                frm.I_inv_req_seq = iinvReqSeq;


                ///////////// 수입검사 여부 조회 //////////////////
                TRSNode in_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_IN");
                TRSNode out_node = new TRSNode("BINV_VIEW_WEIGHT_RAWMILK_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("INV_REQ_NO", sinvReqNo);
                in_node.SetInt("INV_REQ_SEQ", iinvReqSeq);

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }

                if (MPCF.ToChar(out_node.GetList(0)[0].GetChar("IQC_FLAG")) != 'Y')
                {
                    MPCF.ShowMessage(MPCF.GetMessage(421), MSG_LEVEL.ERROR, false);
                    return;
                }

                //////////////////////////////////////////////////

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion                             
        

        #region Function

        private bool CheckConditions(string scheckFlag)
        {
            try
            {
                if (scheckFlag == "ADD")
                {
                    if (!MPCF.CheckValue(txtCarNo, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(txtWeightIn, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(txtWeightOut, true))
                    {
                        return false;
                    }

                    if (DateTime.Compare(dtpCarInTime.GetValueAsDateTime().Date, dtpCarOutTime.GetValueAsDateTime().Date) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        if ((MPCF.ToInt(cmbOutHour.Text) - MPCF.ToInt(cmbInHour.Text)) < 0)
                        {
                            return false;
                        }
                        else if ((MPCF.ToInt(cmbOutHour.Text) - MPCF.ToInt(cmbInHour.Text)) == 0)
                        {
                            if ((MPCF.ToInt(cmbOutMinute.Text) - MPCF.ToInt(cmbInMinute.Text)) < 0)
                            {
                                return false;
                            }
                        }                        
                    }

                }               
                else if (scheckFlag == "DELETE")
                {
                    if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                        return false;
                    }
                }
                else if (scheckFlag == "UPDATE")
                {
                    if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                        return false;
                    }
                }
                else if (scheckFlag == "INPUT_TYPE")
                {
                    if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                        return false;
                    }
                    TRSNode in_node = new TRSNode("CHECK_CONFIRM_IN");
                    TRSNode out_node = new TRSNode("CHECK_RAWMILK_OUT");

                    try
                    {
                        if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                            return false;

                        }
                        int selectRowIndex = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.Factory = MPGV.gsFactory;
                        in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                        in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                        if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        if (out_node.GetList(0)[0].GetChar("IQC_FLAG") == 'Y')
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(451), MSG_LEVEL.ERROR, true);
                            return false;
                        }
                        //MPCF.ShowSuccessMessage(out_node, false);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
                else if (scheckFlag == "PUT_IN_TANK")
                {
                    if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                        return false;
                    }
                }
                else if (scheckFlag == "CONFIRM")
                {
                    TRSNode in_node = new TRSNode("CHECK_CONFIRM_IN");
                    TRSNode out_node = new TRSNode("CHECK_RAWMILK_OUT");

                    try
                    {
                        if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
                            return false;

                        }
                        int selectRowIndex = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.Factory = MPGV.gsFactory;
                        in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                        in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                        if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        if (out_node.GetList(0)[0].GetChar("REQ_STATUS") == BIGC.B_REQ_STATUS_END)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(438), MSG_LEVEL.ERROR, true);
                            return false;
                        }
                        //MPCF.ShowSuccessMessage(out_node, false);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
                else if (scheckFlag == "VIEW")
                {
                    if (!MPCF.CheckValue(dtpWeightDate, true))
                    {
                        return false;
                    }
                }                
                

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdateWeightRawmilk(char cprocStep, char csubStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_IN");
            TRSNode out_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_OUT");            

            
            string scarNo = string.Empty;
            string scarFullNo = string.Empty;
            string scarMatType = string.Empty;
            string sinvLotId = string.Empty;
            string sweightDate = string.Empty;
            int icarSeq = 0;

            double dweightIn = 0.0d;
            double dweightOut = 0.0d;
            double dweightMeasure = 0.0d;
            double dweightReal = 0.0d;
            double dweightGap = 0.0d;
            string sinTime = string.Empty;
            string soutTime = string.Empty;
            string scarDriverId = string.Empty;
            string scarDriverName = string.Empty;
            
            int icarWthRow = 0;
            string sinvReqNo = string.Empty;
            int iinvReqSeq = 0;
            try
            {

                scarNo = MPCF.Trim(txtCarNo.Text);
                scarFullNo = txtCarNo.Text;
                sinvLotId = "";
                sweightDate = dtpWeightDate.GetValueAsString(8);
                //icarSeq = 0;
                iinvReqSeq = 1;
                dweightIn = MPCF.ToDbl(txtWeightIn.Value);
                dweightOut = MPCF.ToDbl(txtWeightOut.Value);                
                dweightMeasure = Math.Abs(dweightIn - dweightOut); ;
                dweightReal = 0;
                dweightGap = dweightMeasure - dweightReal;

                sinTime = dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00";
                soutTime = dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00";
                scarDriverId = MPCF.Trim(txtDriver.Text);
                scarDriverName = MPCF.Trim(txtDriver.Text);

                

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cprocStep;
                in_node.AddChar("SUB_STEP", csubStep);

                if (cprocStep == 'I')
                {
                    in_node.ProcStep = '1';
                    in_node.AddString("REQ_DATE", MPCF.Trim(sweightDate));
                    in_node.AddString("REQ_TIME", MPCF.Trim(sweightDate + "000000"));
                    in_node.AddString("REQ_USER_ID", MPGV.gsUserID);
                    in_node.AddString("ERP_REQ_NO", "");
                    in_node.AddChar("IO_FLAG", BIGC.B_IO_FLAG_IN);
                    in_node.AddString("IO_TYPE", "");
                    in_node.AddString("CAR_NO", MPCF.Trim(scarNo));
                    in_node.AddInt("CAR_SEQ", icarSeq);
                    in_node.SetString("CAR_IN_DATE", sweightDate);
                    in_node.AddString("CAR_IN_TIME", MPCF.Trim(sinTime));
                    //in_node.AddString("CAR_OUT_TIME", MPCF.Trim(soutTime));
                    in_node.AddDouble("WEIGHT_IN", dweightIn);
                    //in_node.AddDouble("WEIGHT_OUT", dweightOut);
                    //in_node.AddDouble("WEIGHT_MEASURE", dweightMeasure);
                    //in_node.AddDouble("WEIGHT_REAL", dweightReal);
                    in_node.AddChar("IQC_FLAG", 'N');
                    in_node.AddString("CUST_ID", "");
                    in_node.AddString("DEPT_ID", "");
                    in_node.AddString("PREV_INV_REQ_NO", "");
                    in_node.AddString("REQ_COMMENT", "");
                    in_node.AddString("REQ_STATUS", BIGC.B_REQ_STATUS_REQUEST);
                    in_node.AddString("REQ_CMF_1", "");
                    in_node.AddString("REQ_CMF_2", "");
                    in_node.AddString("REQ_CMF_3", "");
                    in_node.AddString("REQ_CMF_4", "");
                    in_node.AddString("REQ_CMF_5", "");
                    in_node.AddString("REQ_CMF_6", "");
                    in_node.AddString("REQ_CMF_7", "");
                    in_node.AddString("REQ_CMF_8", "");
                    in_node.AddString("REQ_CMF_9", "");
                    in_node.AddString("REQ_CMF_10", "");

                    if (MPCF.CallService("BEIS", "MCEIS_Tran_Weight_In_Rawmilk", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                else if (cprocStep == 'U')
                {
                    dweightReal = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_REAL].Value);
                    dweightGap = dweightMeasure - dweightReal;

                    in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                    in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                    in_node.AddInt("CAR_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.SEQ].Value));
                    in_node.AddString("CAR_IN_TIME", MPCF.Trim(sinTime));
                    in_node.AddString("CAR_OUT_TIME", MPCF.Trim(soutTime));
                    in_node.AddDouble("WEIGHT_IN", dweightIn);
                    in_node.AddDouble("WEIGHT_OUT", dweightOut);
                    in_node.AddDouble("WEIGHT_MEASURE", dweightMeasure);

                    if (MPCF.CallService("BINV", "BINV_Update_Weight_Rawmilk", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                else if (cprocStep == 'D')
                {
                    in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                    in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                    
                    if (MPCF.CallService("BINV", "BINV_Update_Weight_Rawmilk", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }

               

                if (cprocStep == 'I')
                {
                    icarSeq = out_node.GetInt("NEW_CAR_SEQ");
                    sinvReqNo = out_node.GetString("NEW_INV_REQ_NO");

                    spdWeightListByCar.Sheets[0].Rows.Add(0, 1);
                    icarWthRow = 0;

                    spdWeightListByCar.Sheets[0].SetTag(icarWthRow, (int)ColWeightList.CAR_NO, scarNo);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_NO, scarFullNo);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_MAT_TYPE, scarMatType);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_DATE, MPCF.ToDate(dtpWeightDate.GetValueAsString(8)));
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.SEQ, icarSeq);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_IN, dweightIn);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.INV_LOT_ID, sinvLotId);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00"));
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00"));
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_PUT, 0);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.DRIVER, scarDriverName);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.INV_REQ_NO, sinvReqNo);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.INV_REQ_SEQ, iinvReqSeq);
                    spdWeightListByCar.Sheets[0].SetTag(icarWthRow, (int)ColWeightList.IQC_FLAG, BIGC.B_NO);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.IQC_FLAG, BIGC.B_NO);
                    spdWeightListByCar.Sheets[0].SetTag(icarWthRow, (int)ColWeightList.INOUT_FLAG, BIGC.B_IO_FLAG_IN);
                    spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.INOUT_FLAG, BIGC.B_IO_FLAG_IN_DESC);
                    spdWeightListByCar_RowFocusChanged(0, icarWthRow);           
                }
                else if (cprocStep == 'U')
                {
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_IN, dweightIn);
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00"));
                    spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00"));
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

        private bool UpdateIQCFlag()
        {
            TRSNode in_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_IN");
            TRSNode out_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_OUT");           

            try
            {                

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddChar("SUB_STEP", '4');
                in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                in_node.AddChar("IQC_FLAG", 'Y');
             

                if (MPCF.CallService("BINV", "BINV_Update_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                spdWeightListByCar.Sheets[0].SetValue(spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.IQC_FLAG, 'Y');                

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void InvisibleColumn()
        {
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.SELECT].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.ISSUE_PLACE].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.INV_LOT_ID].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.INV_REQ_NO].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.PO_NO].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.PO_SEQ].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.IUD_FLAG].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.RECEIPT_STORE].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.IO_TYPE].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.INV_REQ_SEQ].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.REQ_STATUS].Visible = false;
           
        }
        

        private void LockColumn()
        {
            for (int i = 0; i < spdWeightListByCar.Sheets[0].Columns.Count; i++)
            {
                spdWeightListByCar.Sheets[0].Columns[i].Locked = true;
            }
        }

        private bool SelectRadioType(string args) {
            try {
                if (args.Equals(BIGC.B_INV_ACC_DETAIL_ALL))
                { // 전체
                    rdoViewType.CheckedIndex = 0;

                }
                else if (args.Equals(BIGC.B_INV_ACC_DETAIL_DAIRY_FARM))
                { //낙농가 R22
                    //B_INV_ACC_DETAIL_DAIRY_FARM
                    rdoViewType.CheckedIndex = 1;
                }
                else if (args.Equals(BIGC.B_INV_ACC_DETAIL_TEAM))
                { //팀간 R42 B_INV_ACC_DETAIL_TEAM
                    rdoViewType.CheckedIndex = 2;
                }
                else if (args.Equals(BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY))
                { //타공장이송 R41  B_INV_ACC_DETAIL_OTHER_FACTORY
                    rdoViewType.CheckedIndex = 3;
                }
                else if (args.Equals(BIGC.B_INV_ACC_DETAIL_DAIRY_COMMITTEE))
                { //낙진회 R23  B_INV_ACC_DETAIL_DAIRY_COMMITTEE
                    rdoViewType.CheckedIndex = 4;
                }
                else if (args.Equals(BIGC.B_INV_ACC_DETAIL_BUY))
                { //구매 R21  B_INV_ACC_DETAIL_BUY
                    rdoViewType.CheckedIndex = 5;
                }
                btnView_Click(btnView, new EventArgs());
                return true;
            }
            catch (Exception ex) {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private bool TranRawmilkInOut(char cprocStep)
        {
            TRSNode in_node = new TRSNode("TRAN_RAWMILK_IN");
            TRSNode out_node = new TRSNode("TRAN_RAWMILK_OUT");

            try
            {
                if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                {
                    return false;

                }
                int selectRowIndex = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cprocStep;

                in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                in_node.AddInt("CAR_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.SEQ].Value));
                in_node.AddString("LOT_ID", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_LOT_ID].Value));
                in_node.AddDouble("LOAD_QTY_1", MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.WEIGHT_MEASURE].Value));
                in_node.AddString("OPER", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.RECEIPT_STORE].Tag));

               
                //in_node.AddString("KEY_1", material);
                in_node.AddString("USER_TEAM", MPGV.gsUserTeam);
                //in_node.AddString("CAR_IN_TIME", MPCF.Trim(sinTime));
                //in_node.AddString("CAR_OUT_TIME", MPCF.Trim(soutTime));
                //in_node.AddDouble("WEIGHT_IN", dweightIn);
                //in_node.AddDouble("WEIGHT_OUT", dweightOut);
                //in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.WEIGHT_REAL].Value));
                //in_node.AddString("RES_ID", ");
                //in_node.AddString("ORDER_ID", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_LOT_ID].Value));
                if (MPCF.CallService("BINV", "BINV_Tran_Rawmilk_In_Out", in_node, ref out_node) == false)
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

        private void dtpWeightDate_TextChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(txtCarSeq);
            MPCF.FieldClear(txtCarNo);
            MPCF.FieldClear(txtDriver);
            MPCF.FieldClear(txtWeightIn);
            MPCF.FieldClear(txtWeightOut);
            btnView_Click(btnView, new EventArgs());
        }



        private void rdoViewType_ValueChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdWeightListByCar);
            MPCF.FieldClear(txtCarNo);
            if (rdoViewType.CheckedIndex == 0)
            { // 전체

            }
            else if (rdoViewType.CheckedIndex == 1)
            { //낙농가 R22
                //B_INV_ACC_DETAIL_DAIRY_FARM

            }
            else if (rdoViewType.CheckedIndex == 2)
            { //팀간 R42 B_INV_ACC_DETAIL_TEAM

            }
            else if (rdoViewType.CheckedIndex == 3)
            { //타공장이송 R41  B_INV_ACC_DETAIL_OTHER_FACTORY

            }
            else if (rdoViewType.CheckedIndex == 4)
            { //낙진회 R23  B_INV_ACC_DETAIL_DAIRY_COMMITTEE

            }
        }



    }

}

