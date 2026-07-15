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
    public partial class frmCUSProductPrintPopup : frmPopupBase
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

        public CUSProductPrintPopup product = new CUSProductPrintPopup();

        const int ROW = 11;

        private enum MATH_TYPE
        {
            AVG,
            MAX,
            MIN,
            SUM
        }

        #endregion

        #region Constructor

        public frmCUSProductPrintPopup()
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
            try
            {
                int iPageRowCount = 40;

                // Convert Caption Spread Cell
                MPCF.ConvertCaptionSpreadCell(spdCover);

                //  Set Data
                if(product.ContractNo.Length == 9)
                    spdCover.Sheets[0].Cells["K13"].Value = product.ContractNo.Substring(0, 4) + "-"
                        + product.ContractNo.Substring(4, 1) + "-"
                        + product.ContractNo.Substring(5, 4);
                else
                    spdCover.Sheets[0].Cells["K13"].Value = product.ContractNo;
                spdCover.Sheets[0].Cells["K14"].Value = product.DlvLocation;
                spdCover.Sheets[0].Cells["K15"].Value = product.Model;
                spdCover.Sheets[0].Cells["K16"].Value = string.Format("{0} EA", product.Qty);
                spdCover.Sheets[0].Cells["K17"].Value = product.Date;
                spdCover.Sheets[0].Cells["K18"].Value = string.Empty;

                // Set Image
                FarPoint.Win.Spread.CellType.ImageCellType cell_type;
                cell_type = new FarPoint.Win.Spread.CellType.ImageCellType();
                cell_type.Style = FarPoint.Win.RenderStyle.Stretch;
                spdCover.ActiveSheet.Cells["G32"].CellType = cell_type;
                spdCover.ActiveSheet.Cells["G32"].Value = Properties.Resources.print;

                int listCount = 0;

                double[] vocArray = new double[product.List.Count]; // VOC
                double[] iscArray = new double[product.List.Count]; // ISC
                double[] pmaxArray = new double[product.List.Count]; // PMAX
                double[] vmpArray = new double[product.List.Count]; // VMP
                double[] impArray = new double[product.List.Count]; // IMP

                for (int i = ROW; i < product.List.Count + ROW; i++)
                {
                    if (spdProduct.ActiveSheet.RowCount % iPageRowCount == 0)
                    {
                        spdProduct.ActiveSheet.RowCount++;
                        spdProduct.ActiveSheet.SetRowHeight(spdProduct.ActiveSheet.RowCount - 1, 25);

                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).Value = "순번";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 1).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 1).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).ColumnSpan = 5;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).Value = "Serial Number";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 3).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 3).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 4).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 4).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 5).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 5).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 6).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 6).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).Value = "Voc";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 8).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 8).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).Value = "Isc";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 10).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 10).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).Value = "Pmax";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 12).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).Value = "Vmp";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 14).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).Value = "Imp";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 16).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).ColumnSpan = 2;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).Locked = true;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).Value = "비고";
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 18).BackColor = System.Drawing.Color.DodgerBlue;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;

                        // ColumnSpan
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).ColumnSpan = 5;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).ColumnSpan = 2;
                        spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).ColumnSpan = 2;
                    }

                    spdProduct.ActiveSheet.RowCount++;
                    spdProduct.ActiveSheet.SetRowHeight(spdProduct.ActiveSheet.RowCount - 1, 25);

                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 0].Value = product.List[listCount].Seq;

                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 2].Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 2].Value = product.List[listCount].SerialNumber;

                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 7].Value = Math.Round(decimal.Parse(product.List[listCount].Voc), 3);
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 9].Value = Math.Round(decimal.Parse(product.List[listCount].Isc), 3);
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 11].Value = Math.Round(decimal.Parse(product.List[listCount].Pmax), 3);
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 13].Value = Math.Round(decimal.Parse(product.List[listCount].Vmp), 3);
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 15].Value = Math.Round(decimal.Parse(product.List[listCount].Imp), 3);

                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 7].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 9].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 11].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 13].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdProduct.Sheets[0].Cells[spdProduct.ActiveSheet.RowCount - 1, 15].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                    vocArray[listCount] = double.Parse(product.List[listCount].Voc.ToString()); // VOC
                    iscArray[listCount] = double.Parse(product.List[listCount].Isc.ToString()); // ISC
                    pmaxArray[listCount] = double.Parse(product.List[listCount].Pmax.ToString()); // PMAX
                    vmpArray[listCount] = double.Parse(product.List[listCount].Vmp.ToString()); // VMP
                    impArray[listCount] = double.Parse(product.List[listCount].Imp.ToString()); // IMP

                    // ColumnSpan
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 0).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 2).ColumnSpan = 5;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 7).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 9).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 11).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 13).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 15).ColumnSpan = 2;
                    spdProduct_Sheet1.Cells.Get(spdProduct.ActiveSheet.RowCount - 1, 17).ColumnSpan = 2;

                    listCount++;

                }

                spdProduct.Sheets[0].Cells["C7"].Value = string.Format("{0} EA", listCount);  // 수량
                spdProduct.Sheets[0].Cells["H7"].Value = MathMethod(MATH_TYPE.AVG, vocArray);  // VOC AVG
                spdProduct.Sheets[0].Cells["H8"].Value = MathMethod(MATH_TYPE.MAX, vocArray);  // VOC MAX
                spdProduct.Sheets[0].Cells["H9"].Value = MathMethod(MATH_TYPE.MIN, vocArray);  // VOC MIN
                spdProduct.Sheets[0].Cells["J7"].Value = MathMethod(MATH_TYPE.AVG, iscArray);  // ISC AVG
                spdProduct.Sheets[0].Cells["J8"].Value = MathMethod(MATH_TYPE.MAX, iscArray);  // ISC MAX
                spdProduct.Sheets[0].Cells["J9"].Value = MathMethod(MATH_TYPE.MIN, iscArray);  // ISC MIN
                spdProduct.Sheets[0].Cells["L7"].Value = MathMethod(MATH_TYPE.AVG, pmaxArray);  // PMAX AVG
                spdProduct.Sheets[0].Cells["L8"].Value = MathMethod(MATH_TYPE.MAX, pmaxArray);  // PMAX MAX
                spdProduct.Sheets[0].Cells["L9"].Value = MathMethod(MATH_TYPE.MIN, pmaxArray);  // PMAX MIN
                spdProduct.Sheets[0].Cells["N7"].Value = MathMethod(MATH_TYPE.AVG, vmpArray);  // VMP AVG
                spdProduct.Sheets[0].Cells["N8"].Value = MathMethod(MATH_TYPE.MAX, vmpArray);  // VMP MAX
                spdProduct.Sheets[0].Cells["N9"].Value = MathMethod(MATH_TYPE.MIN, vmpArray);  // VMP MIN
                spdProduct.Sheets[0].Cells["P7"].Value = MathMethod(MATH_TYPE.AVG, impArray);  // IMP AVG
                spdProduct.Sheets[0].Cells["P8"].Value = MathMethod(MATH_TYPE.MAX, impArray);  // IMP MAX
                spdProduct.Sheets[0].Cells["P9"].Value = MathMethod(MATH_TYPE.MIN, impArray);  // IMP MIN
                spdProduct.Sheets[0].Cells["R7"].Value = string.Empty;  // ETC AVG
                spdProduct.Sheets[0].Cells["R8"].Value = string.Empty;  // ETC MAX
                spdProduct.Sheets[0].Cells["R9"].Value = string.Empty;  // ETC MIN
                spdProduct.Sheets[0].Cells["A4"].Value = product.Date;

                // Caption 변경
                MPCF.ConvertCaption(this);

                // 활성화
                this.Activate();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private double MathMethod(MATH_TYPE type, double[] values)
        {
            double sum = 0;
            decimal average;

            Array.Sort(values);

            for (int i = 0; i < product.List.Count; i++)
                sum += values[i];

            average = ((decimal)sum / product.List.Count);

            if (type == MATH_TYPE.MIN)
                return Math.Round(values[0], 3);
            else if (type == MATH_TYPE.MAX)
                return Math.Round(values[values.Length - 1], 3);
            else if (type == MATH_TYPE.SUM)
                return sum;
            else
                return double.Parse(Math.Round(average, 3).ToString());
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
                spdCover.ActiveSheet.PrintInfo.UseSmartPrint = false;
                spdCover.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait; // 용지방향. Portrait(세로), Landscape(가로), Auto(자동)에서 선택.

                spdCover.ActiveSheet.PrintInfo.SmartPrintPagesTall = 1;
                spdCover.ActiveSheet.PrintInfo.SmartPrintPagesWide = 1;

                spdProduct.ActiveSheet.PrintInfo.UseSmartPrint = false;
                spdProduct.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait; // 용지방향. Portrait(세로), Landscape(가로), Auto(자동)에서 선택.

                spdProduct.ActiveSheet.PrintInfo.SmartPrintPagesTall = 1;
                spdProduct.ActiveSheet.PrintInfo.SmartPrintPagesWide = 1;

                spdCover.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                spdProduct.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;

                if (product.FormName.Equals("frmCUSTranMatShipManagement"))
                {
                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranMatShipManagement)this.Owner).printOption, spdCover) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                    }

                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranMatShipManagement)this.Owner).printOption, spdProduct) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                        this.Close();
                    }
                }
                else if (product.FormName.Equals("frmCUSTranTempMatShipManagement"))
                {
                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranTempMatShipManagement)this.Owner).printOption, spdCover) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                    }

                    if (MPCF.PrintSpread(this.Owner, ((frmCUSTranTempMatShipManagement)this.Owner).printOption, spdProduct) == true)
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

                MPCF.ExportToExcel(spdCover.ActiveSheet, MPCF.FindLanguage("Photovoltaic Module Certificate"));
                MPCF.ExportToExcel(spdProduct.ActiveSheet, MPCF.FindLanguage("Performance test report by product"));
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

    public class CUSProductPrintPopup
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

        private string dlvLocation;
        public string DlvLocation
        {
            get { return dlvLocation; }
            set { dlvLocation = value; }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string qty;
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private string vocAvg;
        public string VocAvg
        {
            get { return vocAvg; }
            set { vocAvg = value; }
        }

        private string vocMax;
        public string VocMax
        {
            get { return vocMax; }
            set { vocMax = value; }
        }

        private string vocMin;
        public string VocMin
        {
            get { return vocMin; }
            set { vocMin = value; }
        }

        private string iscAvg;
        public string IscAvg
        {
            get { return iscAvg; }
            set { iscAvg = value; }
        }

        private string iscMax;
        public string IscMax
        {
            get { return iscMax; }
            set { iscMax = value; }
        }

        private string iscMin;
        public string IscMin
        {
            get { return iscMin; }
            set { iscMin = value; }
        }

        private string pMaxAvg;
        public string PMaxAvg
        {
            get { return pMaxAvg; }
            set { pMaxAvg = value; }
        }

        private string pMaxMax;
        public string PMaxMax
        {
            get { return pMaxMax; }
            set { pMaxMax = value; }
        }

        private string pMaxMin;
        public string PMaxMin
        {
            get { return pMaxMin; }
            set { pMaxMin = value; }
        }

        private string vmpAvg;
        public string VmpAvg
        {
            get { return vmpAvg; }
            set { vmpAvg = value; }
        }

        private string vmpMax;
        public string VmpMax
        {
            get { return vmpMax; }
            set { vmpMax = value; }
        }

        private string vmpMin;
        public string VmpMin
        {
            get { return vmpMin; }
            set { vmpMin = value; }
        }

        private string impAvg;
        public string ImpAvg
        {
            get { return impAvg; }
            set { impAvg = value; }
        }

        private string noteAvg;
        public string NoteAvg
        {
            get { return noteAvg; }
            set { noteAvg = value; }
        }

        private string noteMax;
        public string NoteMax
        {
            get { return noteMax; }
            set { noteMax = value; }
        }

        private string noteMin;
        public string NoteMin
        {
            get { return noteMin; }
            set { noteMin = value; }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private List<CUSProductPrintPopupList> list;
        public List<CUSProductPrintPopupList> List
        {
            get { return list; }
            set { list = value; }
        }
    }

    public class CUSProductPrintPopupList
    {
        private string seq;
        public string Seq
        {
            get { return seq; }
            set { seq = value; }
        }

        private string serialNumber;
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        private string voc;
        public string Voc
        {
            get { return voc; }
            set { voc = value; }
        }

        private string isc;
        public string Isc
        {
            get { return isc; }
            set { isc = value; }
        }

        private string pmax;
        public string Pmax
        {
            get { return pmax; }
            set { pmax = value; }
        }

        private string vmp;
        public string Vmp
        {
            get { return vmp; }
            set { vmp = value; }
        }

        private string imp;
        public string Imp
        {
            get { return imp; }
            set { imp = value; }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
