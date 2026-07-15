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
using Infragistics.Win.UltraWinGrid;

namespace SOI.Solar
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCUSModulePrintPopup : frmPopupBase
    {
        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        public CUSModulePrintPopup module = new CUSModulePrintPopup();

        const int COL = 9;
        const int ROW = 24;

        #endregion

        #region Constructor

        public frmCUSModulePrintPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Convert Caption Spread Cell
            MPCF.ConvertCaptionSpreadCell(spdDocument);

            //  Set Data
            spdDocument.Sheets[0].Cells["E4"].Value = module.ContractNo;
            spdDocument.Sheets[0].Cells["E5"].Value = module.CustomerID;
            spdDocument.Sheets[0].Cells["E6"].Value = module.CustomerID;
            spdDocument.Sheets[0].Cells["E7"].Value = module.DlvLocation;
            spdDocument.Sheets[0].Cells["L5"].Value = module.OrderID;
            spdDocument.Sheets[0].Cells["L6"].Value = module.Receiver;
            spdDocument.Sheets[0].Cells["L7"].Value = module.ReceiverPhone;
            spdDocument.Sheets[0].Cells["E30"].Value = module.CustomerID;
            spdDocument.Sheets[0].Cells["E31"].Value = MPCF.MakeDateFormat(module.StDate + "00", DATE_TIME_FORMAT.DATETIME);
            spdDocument.Sheets[0].Cells["I30"].Value = string.Empty;
            spdDocument.Sheets[0].Cells["I31"].Value = MPCF.MakeDateFormat(module.DueDate + "00", DATE_TIME_FORMAT.DATETIME);
            spdDocument.Sheets[0].Cells["N30"].Value = module.VehicleNum;
            spdDocument.Sheets[0].Cells["N31"].Value = module.VehicleDesc;

            // Set Image
            FarPoint.Win.Spread.CellType.ImageCellType cell_type;
            cell_type = new FarPoint.Win.Spread.CellType.ImageCellType();
            cell_type.Style = FarPoint.Win.RenderStyle.Stretch;
            spdDocument.ActiveSheet.Cells["A37"].CellType = cell_type;
            spdDocument.ActiveSheet.Cells["A37"].Value = Properties.Resources.print;

            int sumQty = 0;
            int sumWp = 0;
            int listCount = 0;
            for (int i = COL; i < module.List.Count + COL; i++)
            {
                spdDocument.Sheets[0].Cells[i, 1].Value = module.List[listCount].MatID;
                spdDocument.Sheets[0].Cells[i, 3].Value = module.List[listCount].MatDesc;
                spdDocument.Sheets[0].Cells[i, 8].Value = module.List[listCount].Unit;
                spdDocument.Sheets[0].Cells[i, 9].Value = module.List[listCount].Qty;
                spdDocument.Sheets[0].Cells[i, 10].Value = module.List[listCount].Wp;
                spdDocument.Sheets[0].Cells[i, 11].Value = module.List[listCount].Model;

                sumQty += int.Parse(module.List[listCount].Qty);
                sumWp += int.Parse(module.List[listCount].Wp);

                listCount++;
            }

            for (int i = listCount + COL; i < ROW; i++)
            {
                spdDocument.Sheets[0].Cells[i, 1].Value = string.Empty;
                spdDocument.Sheets[0].Cells[i, 3].Value = string.Empty;
                spdDocument.Sheets[0].Cells[i, 8].Value = string.Empty;
                spdDocument.Sheets[0].Cells[i, 9].Value = string.Empty;
                spdDocument.Sheets[0].Cells[i, 10].Value = string.Empty;
                spdDocument.Sheets[0].Cells[i, 11].Value = string.Empty;
            }

            spdDocument.Sheets[0].Cells["J25"].Value = sumQty;
			//spdDocument.Sheets[0].Cells["K25"].Value = sumWp;
			spdDocument.Sheets[0].Cells["K25"].Value = string.Format("{0}", sumWp.ToString("#,##0"));

			int lstCnt = 0;
			for (int i = COL; i < module.List.Count + COL; i++)
			{
				//spdDocument.Sheets[0].Cells[i, 10].Value = int.Parse(module.List[listCount].Wp.ToString()).ToString("#,##0");
				spdDocument.Sheets[0].Cells[i, 10].Value = int.Parse(module.List[lstCnt].Wp.ToString()).ToString("#,##0");
			}

			//줄 변경 옵션 적용 
			FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
			txt.Multiline = true;
			txt.WordWrap = true;
			
			spdDocument.Sheets[0].Cells[32,0].CellType = txt;
			spdDocument.Sheets[0].Cells[32, 0].Text = "☞ 상기 위 납품 사항이 이상없을을 확인합니다." + '\n' +
														"☞ 인수자 확인 :                               (인)" + '\n' +
														"※ 인수하신 담당자분의 Sign or 결재자의 Sign 후 당사 FAX 또는 기타 방법으로 송부 부탁드립니다." + '\n';

			spdDocument.Sheets[0].Cells[36, 6].CellType = txt;
			spdDocument.Sheets[0].Cells[36, 6].Text = "본사주소:경기도 성남시 분당구 백현동 404-1" + '\n' +
														"전화 : 031-7889-500        FAX : 031-7889-584" + '\n' +
														"음성주소:369823 충청북도 음성군 대소면 한삼로" + '\n' +
														"108-73(소석리 556 번지)" + '\n' +
														"전화 : 043-880-0548        FAX : 043-881-1924" + '\n';
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        /// <summary>
        /// Print Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
				spdDocument.ActiveSheet.PrintInfo.UseSmartPrint = false;
                spdDocument.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait; // 용지방향. Portrait(세로), Landscape(가로), Auto(자동)에서 선택.

				spdDocument.ActiveSheet.PrintInfo.SmartPrintPagesTall = 1;
				spdDocument.ActiveSheet.PrintInfo.SmartPrintPagesWide = 1;

                if (module.FormName.Equals("frmCUSTranMatShipManagement"))
                {
                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranMatShipManagement)this.Owner).printOption, spdDocument) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                        this.Close();
                    }
                }
                else if (module.FormName.Equals("frmCUSTranTempMatShipManagement"))
                {
                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranTempMatShipManagement)this.Owner).printOption, spdDocument) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;

                MPCF.ExportToExcel(spdDocument.ActiveSheet, MPCF.FindLanguage("Product Shipment Form"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region Function

        #endregion
    }

    public class CUSModulePrintPopup
    {
        private string formName;
        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }

        private string contractNo;
        public string ContractNo
        {
            get { return contractNo; }
            set { contractNo = value; }
        }

        private string customerID;
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private string orderID;
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        private string receiver;
        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        private string receiverPhone;
        public string ReceiverPhone
        {
            get { return receiverPhone; }
            set { receiverPhone = value; }
        }

        private string dlvLocation;
        public string DlvLocation
        {
            get { return dlvLocation; }
            set { dlvLocation = value; }
        }

        private string stDate;
        public string StDate
        {
            get { return stDate; }
            set { stDate = value; }
        }

        private string dueDate;
        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private string vehicleDesc;
        public string VehicleDesc
        {
            get { return vehicleDesc; }
            set { vehicleDesc = value; }
        }

        private string vehicleNum;
        public string VehicleNum
        {
            get { return vehicleNum; }
            set { vehicleNum = value; }
        }

        private List<CUSModulePrintPopupList> list;
        public List<CUSModulePrintPopupList> List
        {
            get { return list; }
            set { list = value; }
        }
    }

    public class CUSModulePrintPopupList
    {
        private string matID;
        public string MatID
        {
            get { return matID; }
            set { matID = value; }
        }

        private string matDesc;
        public string MatDesc
        {
            get { return matDesc; }
            set { matDesc = value; }
        }

        private string unit;
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private string qty;
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private string wp;
        public string Wp
        {
            get { return wp; }
            set { wp = value; }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
