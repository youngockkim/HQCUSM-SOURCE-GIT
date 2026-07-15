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

namespace BOI.INVCus
{
    public partial class frmINVWeighOutRawMilkCar : BOIBaseForm02
    {
        #region Enum
        
        public enum ColWeightList
        {
            SELECT = 0,
            IO_TYPE,
            CAR_MAT_TYPE,
            ISSUE_PLACE,            
            CAR_NO,
            SEQ,            
            WEIGHT_DATE,                        
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
            ISSUE_STORE,
            INOUT_FLAG,
            INV_REQ_NO,
            INV_REQ_SEQ,
            PO_NO,
            PO_SEQ,
            IUD_FLAG
        }

    
        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

        
        
        #endregion

        #region Constructor

        public frmINVWeighOutRawMilkCar()
        {
            InitializeComponent();
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

        private void btnInputOutType_Click(object sender, EventArgs e)
        {
            string sinvReqNo = string.Empty;
            int iinvReqSeq = 0;
            string sOutType = string.Empty;
            string sOutTypeDesc = string.Empty;
            string srawMilkMatId = string.Empty;
            string srawmilkMatDesc = string.Empty;
            string spoNo = string.Empty;            
            int ipoSeq = 0;
            string sissuePlace = string.Empty;
            string sissuePlaceDesc = string.Empty;			
			string scarCode = string.Empty;
            string scarCodeDesc = string.Empty;
            string sissueStore = string.Empty;
            string sissueStoreDesc = string.Empty;
            string sCarNo = string.Empty;
            int iCarSeq = 0;
            int icurRow = 0;

            try
            {                
                if (!CheckConditions("INPUT_TYPE"))
                {
                    return;
                }

                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;

                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                sOutType = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.IO_TYPE].Tag);
                sOutTypeDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.IO_TYPE].Value);                
                srawMilkMatId = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Tag);
                srawmilkMatDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Value);
                spoNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.PO_NO].Value);
                ipoSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.PO_SEQ].Value);
                sissuePlace = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.ISSUE_PLACE].Tag);
                sissuePlaceDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.ISSUE_PLACE].Value);
				scarCode = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.TANKRRORY].Tag);
                scarCodeDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.TANKRRORY].Value);
                sissueStore = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.ISSUE_STORE].Tag);
                sissueStoreDesc = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.ISSUE_STORE].Value);
                sCarNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_NO].Value);
                iCarSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.SEQ].Value);

                frmINVInputOutTypePopup frm = new frmINVInputOutTypePopup();
                frm.InvReqNo = sinvReqNo;
                frm.InvReqSeq = iinvReqSeq;
                frm.CarNo = MPCF.Trim(cdvCarNo.Tag);
                frm.CarNo = MPCF.Trim(sCarNo);
                frm.CarFullNo = MPCF.Trim(cdvCarNo.Text);
                frm.WeightDate = dtpWeightDate.GetValueAsDateTime();
                frm.WeightIn = MPCF.ToDbl(txtWeightIn.Value);
                frm.WeightOut = MPCF.ToDbl(txtWeightOut.Value);
                frm.InType = sOutType;
                frm.InTypeDesc = sOutTypeDesc;
                frm.RawmilkMaterial = srawMilkMatId;
                frm.RawmilkMaterialDesc = srawmilkMatDesc;
                frm.PoNo = spoNo;
                frm.PoSeq = ipoSeq;
                frm.IssuePlace = sissuePlace;
                frm.IssuePlaceDesc = sissuePlaceDesc;
				frm.CarCode = scarCode;
                frm.CarCodeDesc = scarCodeDesc;
                frm.IssueStore = sissueStore;
                frm.IssueStoreDesc = sissueStoreDesc;
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
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.ISSUE_PLACE, frm.IssuePlace);                    
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.ISSUE_PLACE, frm.IssuePlaceDesc);
					spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.TANKRRORY, frm.CarCode);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.TANKRRORY, frm.CarCodeDesc);
                    spdWeightListByCar.Sheets[0].SetTag(icurRow, (int)ColWeightList.ISSUE_STORE, frm.IssueStore);
                    spdWeightListByCar.Sheets[0].SetValue(icurRow, (int)ColWeightList.ISSUE_STORE, frm.IssueStoreDesc);

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

                string sissuePlace = string.Empty;
                string sissuePalceDesc = string.Empty;
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
                string sissueStore = string.Empty;
                string sissueStoreDesc = string.Empty;
                sweightDate = dtpWeightDate.GetValueAsString(8);                                   

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("REQ_DATE", MPCF.Trim(sweightDate));
                in_node.AddChar("IO_FLAG", BIGC.B_IO_FLAG_OUT);
                in_node.AddString("CAR_NO", MPCF.Trim(txtCarNo.Text));
                

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

                        sissuePlace = MPCF.Trim(out_node.GetList(0)[i].GetString("CUST_ID"));
                        sissuePalceDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("CUST_DESC"));
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
                        dweightGap = Math.Abs(dweightMeasure - dweightReal);
                        dweightPut = out_node.GetList(0)[i].GetDouble("WEIGHT_PUT");
                        sinTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_IN_TIME"));
                        soutTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_OUT_TIME"));
                        scarDriverId = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_ID"));
                        scarDriverName = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_NAME"));
                        ciqcFlag = out_node.GetList(0)[i].GetChar("IQC_FLAG");
                        sinoutFlagDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_FLAG_DESC"));                        
                        sinoutFlag = MPCF.Trim(out_node.GetList(0)[i].GetChar("IO_FLAG"));
                        sinvLotId = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                        sinvReqNo = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_REQ_NO"));
                        sinvReqSeq = out_node.GetList(0)[i].GetInt("INV_REQ_SEQ");
                        spoNo = MPCF.Trim(out_node.GetList(0)[i].GetString("ERP_REQ_NO"));                        
                        ipoSeq = out_node.GetList(0)[i].GetInt("ERP_REQ_SEQ");
						scarCode = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_CODE"));
                        scarCodeDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_CODE_DESC"));
                        sissueStore = MPCF.Trim(out_node.GetList(0)[i].GetString("RECIEPT_STORE"));
                        sissueStoreDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("RECIEPT_STORE_DESC"));                        
                        

                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.ISSUE_PLACE, sissuePlace);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_PLACE, sissuePalceDesc);
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.CAR_NO, scarNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_NO, scarFullNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.SEQ, icarSeq);
                        //spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_DATE, MPCF.ToDate(dtpWeightDate.GetValueAsString(8)));
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
                        spdWeightListByCar.Sheets[0].SetTag(iRow, (int)ColWeightList.ISSUE_STORE, sissueStore);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_STORE, sissueStoreDesc);
                        
                        if (i == 0)
                        {
                            spdWeightListByCar_RowFocusChanged(0, i);
                        }

                        /*20170426 JYD 2차계근되지 않은 건 색깔표시*/
                        if (dweightOut < 1)
                        {
                            spdWeightListByCar.Sheets[0].Rows[iRow].BackColor = Color.Yellow;
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


        private void btnWeight_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckConditions("WEIGHT"))
                {
                    return;
                }

                TRSNode in_node = new TRSNode("UPDATE_WIEIGHT_IN");
                TRSNode out_node = new TRSNode("UPDATE_LIST_OUT");
                TRSNode car_wth_list;
                

                int icarWthRow = 0;
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


                scarNo = MPCF.Trim(cdvCarNo.Tag);                
                scarFullNo = cdvCarNo.Text;
                sinvLotId = "";
                sweightDate = dtpWeightDate.GetValueAsString(8);
                icarSeq = 1;
                dweightIn = MPCF.ToDbl(txtWeightIn.Value);
                dweightOut = MPCF.ToDbl(txtWeightOut.Value);
                dweightGap = Math.Abs(dweightIn - dweightOut);
                dweightMeasure = dweightGap;
                dweightReal = dweightMeasure;

                sinTime = dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00";
                soutTime = dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00";
                scarDriverId = MPCF.Trim(txtDriver.Text);
                scarDriverName = MPCF.Trim(txtDriver.Text);

                 

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'W';
                car_wth_list = in_node.AddNode("CAR_WTH_LIST");
                car_wth_list.AddString("CAR_NO", scarNo);
                car_wth_list.AddString("CAR_FULL_NO", scarFullNo);
                car_wth_list.AddString("CAR_MAT_TYPE", scarMatType);
                car_wth_list.AddString("WEIGHT_DATE", dtpWeightDate.GetValueAsString(8));
                car_wth_list.AddInt("CAR_SEQ", icarSeq);
                car_wth_list.AddDouble("WEIGHT_IN", dweightIn);
                car_wth_list.AddDouble("WEIGHT_OUT", dweightOut);
                car_wth_list.AddDouble("WEIGHT_MEASURE", dweightMeasure);
                car_wth_list.AddDouble("WEIGHT_REAL", dweightReal);
                car_wth_list.AddDouble("WEIGHT_GAP", dweightGap);
                car_wth_list.AddString("INV_LOT_ID", sinvLotId);
                car_wth_list.AddString("IN_TIME", sinTime);
                car_wth_list.AddString("OUT_TIME", soutTime);
                car_wth_list.AddString("CAR_DRIVER_ID", scarDriverId);
                car_wth_list.AddString("CAR_DRIVER_NAME", scarDriverName);                

                if (MPCF.CallService("CINV", "Cinv_Update_Rawmilk_Weight", in_node, ref out_node) == false)
                {
                    return;
                }

                icarSeq = out_node.GetInt("CAR_SEQ");

                icarWthRow = spdWeightListByCar.Sheets[0].Rows.Count++;

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
                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.DRIVER, scarDriverName);   

                MPCF.ShowSuccessMessage(out_node, false);


                /*
                string carWthKeyValue = string.Empty;
                string carResKeyValue = string.Empty;

                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.SetString("RESG_ID", BIGC.BI_RES_GROUP_MLTANK);

                // Display and Header Text Setup
                string[] display = new string[] { "SELECT", "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Select", "Res ID", "Res Desc" };

                // Show CodeView and Get Return
                //cdvResID.Text = cdvResID.ShowMultiSelect(cdvResID, "RAS", "View Resource List", "Ras_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

                frmCINVViewResourceListPopup frm = new frmCINVViewResourceListPopup();
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.ReturnList.Count > 0)
                    {
                        for (int i = 0; i < frm.ReturnList.Count; i++)
                        {
                            icarResRow = spdCarResList.Sheets[0].Rows.Count++;
                            if (i == 0)
                            {
                                icarWthRow = spdWeightListByCar.Sheets[0].Rows.Count++;
                                ifirstRegRow = icarWthRow;
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_NO, scarNo);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_DATE, MPCF.ToDate(dtpWeightDate.GetValueAsString(8)));
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_IN, dweightIn);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.INV_LOT_ID, sinvLotId);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.IN_OUT_FLAG, sinOutFlag);
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00"));
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00"));
                                spdWeightListByCar.Sheets[0].SetValue(icarWthRow, (int)ColWeightList.DRIVER, scarDriverName);
                                //spdWeightListByCar.Sheets[0].SetValue(icarResRow, (int)ColWeightList.IUD_FLAG, 'I');

                            }

                            //spdCarResList.Sheets[0].Cells[icarResRow, (int)ColCraResList.CLEAN_TANK].Tag = frm.ReturnList[i][1];
                            //spdCarResList.Sheets[0].Cells[icarResRow, (int)ColCraResList.CLEAN_TANK].Value = frm.ReturnList[i][2];
                            //spdCarResList.Sheets[0].SetValue(icarResRow, (int)ColCraResList.WEIGHT_TANK, MPCF.ToDbl(frm.ReturnList[i][3]));
                            //spdCarResList.Sheets[0].SetValue(icarResRow, (int)ColCraResList.IUD_FLAG, 'I');

                        }

                    }
                }

                //frm.ReturnList.Clear();
                */
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        

        private void spdWeightListByCar_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            //int icurRow = 0;
           
            //try
            //{
            //    if (e.Row == e.NewRow)
            //    {
            //        return;
            //    }

            //    icurRow = e.NewRow;
            //    if (icurRow >= 0)
            //    {
            //        dtpWeightDate.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_DATE].Value);
            //        cdvCarNo.Tag = spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_NO].Tag;
            //        cdvCarNo.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_NO].Value);                                        
            //        txtCarSeq.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.SEQ].Value);
            //        dtpCarInTime.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value);
            //        cmbInHour.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value).ToString("HH");
            //        cmbInMinute.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_IN_TIME].Value).ToString("MM");
            //        dtpCarOutTime.Value = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value);
            //        cmbOutHour.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value).ToString("HH");
            //        cmbOutMinute.Text = Convert.ToDateTime(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_OUT_TIME].Value).ToString("MM");

            //        txtDriver.Text = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.DRIVER].Value);
            //        txtWeightIn.Value = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_IN].Value);
            //        txtWeightOut.Value = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.WEIGHT_OUT].Value);                    
                    
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

        }
       

        private void btnInputWeightSlip_Click(object sender, EventArgs e)
        {
            if (spdWeightListByCar.Sheets[0].ActiveRowIndex >= 0)
            {
                BICF.OpenMenu("ORMK2001", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
            }
            else {
                return;
            }
        }


        private void btnFillTankrrory_Click(object sender, EventArgs e)
        {
            string sinvReqNo = string.Empty;
            string sMaterial = string.Empty;
            int iinvReqSeq = 0;
            int icurRow = 0;

            try
            {
                if (!CheckConditions("FILL_TANKRRORY"))
                {
                    return;
                }
                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;
                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                sMaterial = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Tag);

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

                icurRow = spdWeightListByCar.Sheets[0].ActiveRowIndex;
                sinvReqNo = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_NO].Value);
                sMaterial = MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.CAR_MAT_TYPE].Tag);
                iinvReqSeq = MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[icurRow, (int)ColWeightList.INV_REQ_SEQ].Value);
                frmINVEmptyTankPopup frm = new frmINVEmptyTankPopup();
                frm.InvReqNo = sinvReqNo;
                frm.Material = sMaterial;
                frm.InvReqSeq = iinvReqSeq;
                frm.WeightReal = MPCF.ToDbl(out_node.GetList(0)[0].GetDouble("WEIGHT_MEASURE"));
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
                node.SetString("VENDOR_ID", MPCF.Trim(""));
                


                if (MPCF.CallService("BEIS", "MCEIS_Tran_Weight_In_Rawmilk", node, SOI.MsgHandlerH101.DeliveryMode.Unicast) == false)
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
                MPCF.CheckContinueProc(node, true);

            }
            else
            {
                //dtpWeightDate.Value = MPCF.ToDate(node.GetString("CAR_IN_DATE"));
                btnView_Click(btnView, new EventArgs());
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
                else if (scheckFlag == "FILL_TANKRRORY")
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

                        if (out_node.GetList(0)[0].GetChar("REQ_STATUS") == BIGC.B_REQ_STATUS_CONFIRM)
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

                else if (scheckFlag == "INPUT_TYPE")
                {
                    if (spdWeightListByCar.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(109), MSG_LEVEL.WARNING, true);
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
                icarSeq = 1;
                dweightIn = MPCF.ToDbl(txtWeightIn.Value);
                dweightOut = MPCF.ToDbl(txtWeightOut.Value);                
                dweightMeasure = Math.Abs(dweightIn - dweightOut); ;
                dweightReal = 0;
                dweightGap = Math.Abs(dweightMeasure - dweightReal);

                sinTime = dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00";
                soutTime = dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00";
                scarDriverId = MPCF.Trim(txtDriver.Text);
                scarDriverName = MPCF.Trim(txtDriver.Text);

                

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cprocStep;
                in_node.AddChar("SUB_STEP", csubStep);

                if (cprocStep == 'I')
                {
                    in_node.AddString("REQ_DATE", MPCF.Trim(sweightDate));
                    in_node.AddString("REQ_TIME", MPCF.Trim(sweightDate + "000000"));
                    in_node.AddString("REQ_USER_ID", MPGV.gsUserID);
                    in_node.AddString("ERP_REQ_NO", "");
                    in_node.AddChar("IO_FLAG", BIGC.B_IO_FLAG_OUT);
                    in_node.AddString("IO_TYPE", "");
                    in_node.AddString("CAR_NO", MPCF.Trim(scarNo));
                    in_node.AddInt("CAR_SEQ", icarSeq);
                    in_node.AddString("CAR_IN_TIME", MPCF.Trim(sinTime));
                    in_node.AddString("CAR_OUT_TIME", MPCF.Trim(soutTime));
                    in_node.AddDouble("WEIGHT_IN", dweightIn);
                    in_node.AddDouble("WEIGHT_OUT", dweightOut);
                    in_node.AddDouble("WEIGHT_MEASURE", dweightMeasure);
                    in_node.AddDouble("WEIGHT_REAL", dweightReal);
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
                }
                else if (cprocStep == 'U')
                {
                    dweightReal = MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.WEIGHT_REAL].Value);
                    dweightGap = Math.Abs(dweightMeasure - dweightReal);
                    in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                    in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                    in_node.AddString("CAR_IN_TIME", MPCF.Trim(sinTime));
                    in_node.AddString("CAR_OUT_TIME", MPCF.Trim(soutTime));
                    in_node.AddDouble("WEIGHT_IN", dweightIn);
                    in_node.AddDouble("WEIGHT_OUT", dweightOut);
                    in_node.AddDouble("WEIGHT_MEASURE", dweightMeasure);
                }
                else if (cprocStep == 'D')
                {
                    in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_NO].Value));
                    in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].Cells[spdWeightListByCar.Sheets[0].ActiveRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value));
                }

                if (MPCF.CallService("BINV", "BINV_Update_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (cprocStep == 'I')
                {
                    icarSeq = out_node.GetInt("CAR_SEQ");
                    sinvReqNo = out_node.GetString("NEW_INV_REQ_NO");
                    iinvReqSeq = out_node.GetInt("NEW_INV_REQ_SEQ");

                    //icarWthRow = spdWeightListByCar.Sheets[0].Rows.Count++;
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
                //in_node.AddString("LOT_ID", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_LOT_ID].Value));
                in_node.AddDouble("WEIGHT_MEASURE", MPCF.ToDbl(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.WEIGHT_MEASURE].Value));
                in_node.AddString("OPER", MPCF.Trim(spdWeightListByCar.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.ISSUE_STORE].Tag));
                
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

        private void InvisibleColumn()
        {
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.SELECT].Visible = false;
            //spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.WEIGHT_TEAM].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.INV_LOT_ID].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.INV_REQ_NO].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.PO_NO].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.PO_SEQ].Visible = false;
            spdWeightListByCar.Sheets[0].Columns[(int)ColWeightList.IUD_FLAG].Visible = false;
            
        }

        private void LockColumn()
        {
            for (int i = 0; i < spdWeightListByCar.Sheets[0].Columns.Count; i++)
            {
                spdWeightListByCar.Sheets[0].Columns[i].Locked = true;
            }
        }

        #endregion 

        


   

    

       

       

       

        

     

       

        

       

      

        

       
    }


    
}
