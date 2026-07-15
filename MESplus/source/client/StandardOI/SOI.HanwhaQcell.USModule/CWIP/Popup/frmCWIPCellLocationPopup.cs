using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule.CWIP.Popup
{
    public partial class frmCWIPCellLocationPopup : frmPopupBase
    {
        //ISSUE-07-011 : FQC 재판정 OI수정
        #region Property

        public string StrLoc;
        public string ReturnValue;
        public int min_cell_column;

        #endregion


        #region Constructor

        public frmCWIPCellLocationPopup(string strLoc, string str_cell_qty)
        {

            InitializeComponent();


            spdCellMap_Sheet1.ColumnCount = 26;

            if (Int32.TryParse(str_cell_qty, out min_cell_column))
                min_cell_column = min_cell_column / 6; //row 갯수가 6으로 고정이므로, 6으로 나눠서 column 값을 계산한다.
            else
                min_cell_column = 26;

            this.StrLoc = strLoc;
        }

        #endregion


        #region Event Handler

        private void frmCellLocationPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // (Required) Grid Initialize
            GetLocation(this.StrLoc);

            // 활성화
            this.Activate();
        }

        private void spdCellMap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column > min_cell_column - 1) // e.Column은 0부터 시작.
            {
                MPCF.ShowMessage("Cell defect location does not exist in some modules.", MSG_LEVEL.ERROR, false);
                return;
            }

            AddLossCode(e.Row, e.Column);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        private void btnFieldsReset_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.ReturnValue = string.Empty;

            this.Close();
        }

        #endregion


        #region Functions

        private bool AddLossCode(int x, int y)
        {
            try
            {
                string strx = "A";
                string stry = "00";

                switch (x)
                {
                    case 0:
                        strx = "A";
                        break;
                    case 1:
                        strx = "B";
                        break;
                    case 2:
                        strx = "C";
                        break;
                    case 3:
                        strx = "D";
                        break;
                    case 4:
                        strx = "E";
                        break;
                    case 5:
                        strx = "F";
                        break;

                    default:
                        break;
                }

                y = y + 101;
                stry = y.ToString();
                stry = stry.Substring(1, 2);

                this.ReturnValue = strx + stry;

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void GetLocation(string strLoc)
        {
            try
            {
                if (strLoc != "")
                {
                    string strx = "";
                    string stry = "";

                    int posX = 0;
                    int posY = 0;

                    strx = strLoc.Substring(0, 1);
                    stry = strLoc.Substring(1, 2);

                    switch (strx)
                    {
                        case "A":
                            posX = 0;
                            break;
                        case "B":
                            posX = 1;
                            break;
                        case "C":
                            posX = 2;
                            break;
                        case "D":
                            posX = 3;
                            break;
                        case "E":
                            posX = 4;
                            break;
                        case "F":
                            posX = 5;
                            break;
                        default:
                            break;
                    }

                    posY = Convert.ToInt16(stry) - 1;

                    spdCellMap.ActiveSheet.Cells[posX, posY].BackColor = System.Drawing.Color.Red;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


    }
}