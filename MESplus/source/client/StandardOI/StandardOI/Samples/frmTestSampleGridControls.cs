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

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleGridControls : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleGridControls()
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
            // (Required) ListBox Initialize
            // SOIListBox 사용 시,  초기화를 해야 합니다.
            lbDefault.InitDataSource();
            lbCheckBox.InitDataSource();
            lbSequence.InitDataSource();

            // (Required) Grid Initialize
            // SOIGrid 사용 시,  초기화를 해야 합니다.
            gridDefault.InitDataSource();
            gridCheckBox.InitDataSource();
            gridSequence.InitDataSource();

            // (Option) ListBox Add Row
            //  - For only 1 text Column
            lbDefault.AddRowText("Text Added: Load Event");
            //  - For check and text column
            lbCheckBox.AddRowCheckAndText(false, "Text Added: Load Event");
            //  - For Int32 and text column
            lbSequence.AddRowSeqAndText(0, "Text Added: Load Event");
            //  - For Int32 and text column (Auto generated)
            lbSequence.AddRowSeqAndText("Text Added: Load Event");

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
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

        #region About ListBox

        /// <summary>
        /// ListBox Selected Row Changed Event
        /// **** Event fires when,
        /// ** ListBox.DataBind()
        /// ** row.selected = true
        /// ** User clicks different row.
        /// Selected Row가 변경되는 모든 시점에 발생하므로 구분자를 통해 사용이 필요합니다.
        /// 또는 Cell Click 이벤트로 대체하여 로직을 처리합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDefault_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            //try
            //{
            //    string sSelectedRow = string.Empty;

            //    if (((SOIListBox)sender).Name == "lbDefault")
            //    {
            //        if (lbDefault.Selected.Rows.Count > 0)
            //        {
            //            sSelectedRow = "DATA : " + lbDefault.Selected.Rows[0].Cells["data"].Text;
            //        }
            //    }
            //    else if (((SOIListBox)sender).Name == "lbCheckBox")
            //    {
            //        if (lbCheckBox.Selected.Rows.Count > 0)
            //        {
            //            sSelectedRow = "Check : " + lbCheckBox.Selected.Rows[0].Cells["chk"].Value.ToString() + "\n" +
            //                                        lbCheckBox.Selected.Rows[0].Cells["data"].Text;
            //        }
            //    }
            //    else if (((SOIListBox)sender).Name == "lbSequence")
            //    {
            //        if (lbSequence.Selected.Rows.Count > 0)
            //        {
            //            sSelectedRow = "Seq : " + lbSequence.Selected.Rows[0].Cells["seq"].Text + "\n" +
            //                                        lbSequence.Selected.Rows[0].Cells["data"].Text;
            //        }
            //    }

            //    MPCF.ShowMsgBox(sSelectedRow, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            //}
        }

        /// <summary>
        /// ListBox Cell Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDefault_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            try
            {
                string sSelectedRow = string.Empty;

                if (((SOIListBox)sender).Name == "lbDefault")
                {
                    if (lbDefault.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "DATA : " + lbDefault.Selected.Rows[0].Cells["data"].Text;
                    }
                }
                else if (((SOIListBox)sender).Name == "lbCheckBox")
                {
                    if (lbCheckBox.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "Check : " + lbCheckBox.Selected.Rows[0].Cells["chk"].Value.ToString() + "\n" +
                                                    lbCheckBox.Selected.Rows[0].Cells["data"].Text;
                    }
                }
                else if (((SOIListBox)sender).Name == "lbSequence")
                {
                    if (lbSequence.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "Seq : " + lbSequence.Selected.Rows[0].Cells["seq"].Text + "\n" +
                                                    lbSequence.Selected.Rows[0].Cells["data"].Text;
                    }
                }

                MPCF.ShowMsgBox(sSelectedRow, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Row To SOIListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbDefault.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = "Text Added: Add Row " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                lbDefault.DataBind();

                // (Option) Scroll to first row
                lbDefault.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Delete Row From SOIListBox (Last Row)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbDefault.GetDataSource();

                // 2) Find row
                // - selected row 
                if (lbDefault.Selected.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(lbDefault.Selected.Rows[0].Index);
                }
                // - Find by value (It can be more than 2 rows.)                
                foreach (DataRow dr in dt.Select("data='Text Added: Add Row 5'"))
                {
                    dt.Rows.Remove(dr);
                }

                // 3) Bind
                lbDefault.DataBind();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Selected Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultSelectedRow_Click(object sender, EventArgs e)
        {
            try
            {
                // SOIListBox Selected Property                
                // - selected.Rows[0]: current selected row
                // - selected.Rows[0].Cells[0]: current Selected Cell
                // ** selected.Cells property is not used. **
                if (lbDefault.Selected.Rows.Count > 0)
                {
                    MPCF.ShowMessage("Selected Cell Text : " + lbDefault.Selected.Rows[0].Cells[0].Text, SOI.CliFrx.MSG_LEVEL.INFO, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Row To SOIListBox (CheckBox Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckBoxAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbCheckBox.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = false;
                    dr[1] = "Text Added: Add Row " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                lbCheckBox.DataBind();

                // (Option) Scroll to first row
                lbCheckBox.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Check Row in ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckFirstRow_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option) Directly change
                if (lbCheckBox.Rows.Count > 0)
                {
                    lbCheckBox.Rows[0].Cells[0].Value = !((bool)(lbCheckBox.Rows[0].Cells[0].Value));
                }

                // (Option) Using DataTable
                //DataTable dt = lbCheckBox.GetDataSource();

                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows[0][0] = !((bool)dt.Rows[0][0]);
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Search Checked Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckBoxCheckedRow_Click(object sender, EventArgs e)
        {
            try
            {
                string sCheckedRowIndex = string.Empty;

                // (Option) Directly find
                if (lbCheckBox.Rows.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow dr in lbCheckBox.Rows)
                    {
                        if ((bool)dr.Cells[0].Value == true)
                        {
                            sCheckedRowIndex = sCheckedRowIndex + dr.Index + " ";
                        }
                    }

                    MPCF.ShowMsgBox(sCheckedRowIndex, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
                }

                sCheckedRowIndex = string.Empty;

                // (Option) Using DataTable
                DataTable dt = lbCheckBox.GetDataSource();
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((bool)dr[0] == true)
                        {
                            sCheckedRowIndex = sCheckedRowIndex + i.ToString() + " ";
                        }

                        i++;
                    }

                    MPCF.ShowMsgBox(sCheckedRowIndex, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Row To SOIListBox (Sequence Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSequenceAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbSequence.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = GetNextSequence(lbSequence);
                    dr[1] = "Text Added: Add Row " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                lbSequence.DataBind();

                // (Option) Scroll to first row
                lbSequence.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Sort ListBox (Sequence Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSequenceSort_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbSequence.GetDataSource();

                // 2) Defalut View Sort
                if (btnSequenceSort.Tag.ToString() == "D")
                {
                    // seq : column key
                    dt.DefaultView.Sort = "seq desc";
                    btnSequenceSort.Text = MPCF.FindLanguage("Sort (Asc)");
                    btnSequenceSort.Tag = "A";
                }
                else
                {
                    dt.DefaultView.Sort = "seq asc";
                    btnSequenceSort.Text = MPCF.FindLanguage("Sort (Desc)");
                    btnSequenceSort.Tag = "D";
                }

                // 3) Bind Data
                lbSequence.SetDataSource(dt.DefaultView.ToTable());
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Row by Sequence of ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSequenceFind_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = lbSequence.GetDataSource();

                // 2) Select
                // seq : column key
                DataRow[] drArray = dt.Select("seq = 2");
                if (drArray.Length > 0)
                {
                    string sFindData = string.Empty;
                    foreach (DataRow dr in drArray)
                    {
                        sFindData = sFindData + dr[1].ToString() + "\n";
                    }

                    MPCF.ShowMsgBox(sFindData, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region About Grid

        /// <summary>
        /// Grid Add Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridDefaultAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridDefault.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = "Code " + i.ToString();
                    dr[1] = "EA";
                    dr[2] = "Description " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                gridDefault.DataBind();

                // (Option) Scroll to first row
                gridDefault.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Grid Cell Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDefault_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            try
            {
                string sSelectedRow = string.Empty;

                if (((SOIGrid)sender).Name == "gridDefault")
                {
                    if (gridDefault.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "Code : " + gridDefault.Selected.Rows[0].Cells["code"].Text;
                    }
                }
                else if (((SOIGrid)sender).Name == "gridCheckBox")
                {
                    if (gridCheckBox.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "Chceck : " + gridCheckBox.Selected.Rows[0].Cells["chk"].Value.ToString() + "\n" +
                                                    "Code : " + gridCheckBox.Selected.Rows[0].Cells["code"].Text;
                    }
                }
                else if (((SOIGrid)sender).Name == "gridSequence")
                {
                    if (gridSequence.Selected.Rows.Count > 0)
                    {
                        sSelectedRow = "Seq : " + gridSequence.Selected.Rows[0].Cells["seq"].Text + "\n" +
                                                    "Code : " + gridSequence.Selected.Rows[0].Cells["code"].Text;
                    }
                }

                MPCF.ShowMsgBox(sSelectedRow, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Grid Delete Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridDefaultDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int iSelectedIndex = 0;

                // 1) Get Data Source
                DataTable dt = gridDefault.GetDataSource();

                // 2) Find row
                // - selected row 
                if (gridDefault.Selected.Rows.Count > 0)
                {
                    iSelectedIndex = gridDefault.Selected.Rows[0].Index;
                    dt.Rows.RemoveAt(gridDefault.Selected.Rows[0].Index);
                }

                // - Find by value (It can be more than 2 rows.)                
                //foreach (DataRow dr in dt.Select("code = 'Code 5'"))
                //{
                //    dt.Rows.Remove(dr);
                //}

                // 3) Bind
                gridDefault.DataBind();

                // 4) Select Next row
                if (iSelectedIndex == 0)
                {
                    if (gridDefault.Rows.Count > 0)
                    {
                        gridDefault.Rows[0].Selected = true;
                        gridDefault.ActiveRowScrollRegion.ScrollRowIntoView(gridDefault.Rows[0]);
                    }
                }
                else if (gridDefault.Rows[iSelectedIndex - 1] != null)
                {
                    gridDefault.Rows[iSelectedIndex - 1].Selected = true;
                    gridDefault.ActiveRowScrollRegion.ScrollRowIntoView(gridDefault.Rows[iSelectedIndex - 1]);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Selected Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridDefaultSelected_Click(object sender, EventArgs e)
        {
            try
            {
                // SOIGrid Selected Property (Same as SOIListBox)
                // - selected.Rows[0]: current selected row
                // - selected.Rows[0].Cells[0]: current Selected Cell
                // - selected.Rows[0].Cells[columnKey]: current selected Cell by column key
                // ** selected.Cells property is not used. **
                if (gridDefault.Selected.Rows.Count > 0)
                {
                    // code : column key
                    MPCF.ShowMessage("Selected Code : " + gridDefault.Selected.Rows[0].Cells["code"].Text, SOI.CliFrx.MSG_LEVEL.INFO, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Row for SOIGrid (CheckBox Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridCheckBoxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridCheckBox.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = false;
                    dr[1] = "Code " + i.ToString();
                    dr[2] = "Desc " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                gridCheckBox.DataBind();

                // (Option) Scroll to first row
                gridCheckBox.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Checked Row for SOIGrid (CheckBox Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridCheckBoxChecked_Click(object sender, EventArgs e)
        {
            try
            {
                string sCheckedRowIndex = string.Empty;

                // (Option) Directly find
                if (gridCheckBox.Rows.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow dr in gridCheckBox.Rows)
                    {
                        if ((bool)dr.Cells[0].Value == true)
                        {
                            sCheckedRowIndex = sCheckedRowIndex + dr.Index + " ";
                        }
                    }

                    MPCF.ShowMsgBox(sCheckedRowIndex, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
                }

                sCheckedRowIndex = string.Empty;

                // (Option) Using DataTable
                DataTable dt = gridCheckBox.GetDataSource();
                if (dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((bool)dr[0] == true)
                        {
                            sCheckedRowIndex = sCheckedRowIndex + i.ToString() + " ";
                        }

                        i++;
                    }

                    MPCF.ShowMsgBox(sCheckedRowIndex, MessageBoxButtons.OK, SOI.CliFrx.MSG_LEVEL.INFO);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Check Row by Code (CheckBox Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridCheckBoxCheckCode_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridCheckBox.GetDataSource();

                // 2) Find Code
                // code : column key
                // It can be more than 2 rows.
                DataRow[] drArray = dt.Select("code = 'Code 3' or code = 'Code 2' or code = 'Code 1'");
                foreach (DataRow dr in drArray)
                {
                    dr[0] = true;
                }

                // 3) Bind
                gridCheckBox.DataBind();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Row for SOIGrid (Sequence Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridSequenceAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridSequence.GetDataSource();

                for (int i = 0; i < 10; i++)
                {
                    // 2) New Row
                    DataRow dr = dt.NewRow();

                    // 3) Data Insert
                    dr[0] = GetNextSequence(gridSequence);
                    dr[1] = "Code " + i.ToString();
                    dr[2] = "Desc " + i.ToString();

                    // 4) New Row Add
                    dt.Rows.Add(dr);
                }

                // 5) Bind
                gridSequence.DataBind();

                // (Option) Scroll to first row
                gridSequence.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Sort for SOIGrid (Sequence Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridSequenceSort_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Get Data Source
                DataTable dt = gridSequence.GetDataSource();

                // 2) Defalut View Sort
                if (btnGridSequenceSort.Tag.ToString() == "D")
                {
                    // seq : column key
                    dt.DefaultView.Sort = "seq desc";
                    btnGridSequenceSort.Text = MPCF.FindLanguage("Sort (Asc)");
                    btnGridSequenceSort.Tag = "A";
                }
                else
                {
                    dt.DefaultView.Sort = "seq asc";
                    btnGridSequenceSort.Text = MPCF.FindLanguage("Sort (Desc)");
                    btnGridSequenceSort.Tag = "D";
                }

                // 3) Bind Data
                gridSequence.SetDataSource(dt.DefaultView.ToTable(dt.TableName));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Column for SOIGrid (Sequence Type)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridSequenceAddCol_Click(object sender, EventArgs e)
        {
            try
            {
                // (Option) String Column Add
                // addColumn(column key, column header)
                // column key는 반드시 중복되지 않아야 합니다.
                // column header의 다국어는 추가할 때 적용됩니다.
                // column type은 string만 가능합니다.
                // Basic Column Add
                gridSequence.AddColumn("add_col_1", "1");
                // Change width
                Infragistics.Win.UltraWinGrid.UltraGridColumn ugc = gridSequence.AddColumn("add_col_2", "2");
                if (ugc != null)
                {
                    ugc.Width = 10;
                }
                // Change Align
                ugc = gridSequence.AddColumn("add_col_3", "3");
                if (ugc != null)
                {
                    ugc.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                }
                gridSequence.AddColumn("add_col_4", "4");
                gridSequence.AddColumn("add_col_5", "5");
                // *************************************************************

                // (Option) Other column add
                // 다른 타입의 컬럼을 Add시에는 아래와 같이 직접 Add해야 합니다.
                // 반드시 column key를 지정해야 DataTable과 binding 됩니다.
                // Display Column Add
                ugc = gridSequence.DisplayLayout.Bands[0].Columns.Add("add_col_6", MPCF.FindLanguage("6"));
                ugc.DataType = typeof(int);
                ugc.Width = 10;
                // Data Table Add
                DataColumn dc = new DataColumn();
                dc.ColumnName = ugc.Key;
                dc.DataType = typeof(int);
                DataTable dt = gridSequence.GetDataSource();
                dt.Columns.Add(dc);
                // Bind
                gridSequence.DataBind();
                // **************************************************************

                // (Option) Row Add (Same as before)
                // 1) Get Data Source
                dt = gridSequence.GetDataSource();

                if (dt.Rows.Count > 0)
                {
                    // 2) Exist Row
                    foreach (DataRow dr in dt.Rows)
                    {
                        // 3) Data Insert
                        dr["add_col_1"] = 0;
                        dr["add_col_2"] = 0;
                        dr["add_col_3"] = 1;
                        dr["add_col_4"] = 0;
                        dr["add_col_5"] = 1;
                        dr["add_col_6"] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #endregion

        #region Function

        /// <summary>
        /// Find Next Sequence
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int GetNextSequence(SOIListBox control)
        {
            try
            {
                int iNextSeq = 0;

                // 1) row가 없는 경우 0
                // 2) row가 있는 경우 이전 값 검색
                if (control.GetDataSource().Rows.Count > 0)
                {
                    if (control.GetDataSource().Columns[0].DataType == typeof(int)
                        && control.GetDataSource().Rows[control.GetDataSource().Rows.Count - 1][0] != null)
                    {
                        iNextSeq = ((int)control.GetDataSource().Rows[control.GetDataSource().Rows.Count - 1][0]) + 1;
                    }
                }

                return iNextSeq;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return 0;
            }
        }

        /// <summary>
        /// Find Next Sequence (Same as SOIListBox)
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int GetNextSequence(SOIGrid control)
        {
            try
            {
                int iNextSeq = 0;

                // 1) row가 없는 경우 0
                // 2) row가 있는 경우 이전 값 검색
                if (control.GetDataSource().Rows.Count > 0)
                {
                    if (control.GetDataSource().Columns[0].DataType == typeof(int)
                        && control.GetDataSource().Rows[control.GetDataSource().Rows.Count - 1][0] != null)
                    {
                        iNextSeq = ((int)control.GetDataSource().Rows[control.GetDataSource().Rows.Count - 1][0]) + 1;
                    }
                }

                return iNextSeq;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return 0;
            }
        }

        #endregion
    }
}
