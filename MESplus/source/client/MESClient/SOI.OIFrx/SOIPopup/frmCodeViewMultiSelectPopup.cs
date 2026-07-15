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
using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIPopup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCodeViewMultiSelectPopup : frmPopupBase
    {
        #region Property

        private string returnValueSeparator = ", ";
        private string returnDataTRSName = "CODEVIEW_MULTISELECT_OUT";
        private string returnDataTRSNodeName = "DATA_LIST";
        
        public string ReturnValue;

        public List<string> ReturnValues;

        public TRSNode ReturnData;
        
        private DataTable dtOriginalData;
        private DataTable dtSelectedData;

        private CodeViewMultiSelectPopupModel cvpm;

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

        #endregion

        #region Constructor

        public frmCodeViewMultiSelectPopup()
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
            // Title 변경
            lblPopupTitle.Text = MPOF.FindLanguage(cvpm.Title);

            // 초기화            
            ReturnValues = cvpm.ReturnValues;
            ReturnData = cvpm.ReturnData;
            grdAllData.InitDataSource();
            grdSelectedData.InitDataSource();
            
            // Find 초기화
            InitFindComboBox();

            // Pagenation 초기화
            InitPagenation();

#if _H101
            // 서비스 조회
            if (ViewService(true) == false)
            {
                // Error Close
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                ReturnValue = cvpm.Control.Text;
                this.Close();
            }
#endif
#if _Http
            // 서비스 조회
            if (ViewPageService(1, cvpm.PageSize, true) == false)
            {
                // Error Close
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                ReturnValue = cvpm.Control.Text;
                this.Close();
            }
#endif

            // Check Selected Data in All Grid
            CheckSelectedDataInAllGrid(this.ReturnValues);

            // Set Selected Data Bind
            SetSelectedDataBind(this.ReturnData);
            
            // Caption 변경
            MPOF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// All Data Grid Cell Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdAllData_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                // 데이터 소스가 없거나 데이터가 없는 경우
                if (grdAllData.Rows.Count == 0)
                {
                    return;
                }

                // 선택된 Row가 없는 경우
                if (grdAllData.Selected.Rows.Count < 1)
                {
                    return;
                }

                // 선택한 경우
                if (((bool)grdAllData.Selected.Rows[0].Cells[0].Value) == true)
                {
                    // 선택된 Row 데이터 저장
                    int iIndex = GetIndexDisplayColumn(cvpm.SelectedColumn);
                    this.ReturnValues = AddSelectedColumnText(this.ReturnValues, grdAllData.Selected.Rows[0].Cells[iIndex].Text);
                    AddSelectedColumnToGrid(grdAllData.Selected.Rows[0].Index);
                }
                // 선택 해제한 경우
                else
                {
                    int iIndex = GetIndexDisplayColumn(cvpm.SelectedColumn);
                    this.ReturnValues = RemoveSelectedColumnText(this.ReturnValues, grdAllData.Selected.Rows[0].Cells[iIndex].Text);
                    RemoveSelectedColumnFromGrid(iIndex, grdAllData.Selected.Rows[0].Cells[iIndex].Text);
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Cell Click 시 선택을 해제 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdSelectedData_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                // 데이터 소스가 없거나 데이터가 없는 경우
                if (grdSelectedData.Rows.Count == 0)
                {
                    return;
                }

                // 선택된 Row가 없는 경우
                if (grdSelectedData.Selected.Rows.Count < 1)
                {
                    return;
                }

                int iIndex = GetIndexDisplayColumn(cvpm.SelectedColumn);
                this.ReturnValues = RemoveSelectedColumnText(this.ReturnValues, grdSelectedData.Selected.Rows[0].Cells[iIndex].Text);
                RemoveSelectedColumnFromGrid(iIndex, grdSelectedData.Selected.Rows[0].Cells[iIndex].Text);

                CheckSelectedDataInAllGrid(this.ReturnValues);
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// First Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            try
            {
                txtInputPage.Text = "1";

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Previous Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtInputPage.Text) <= 1)
                {
                    return;
                }

                txtInputPage.Text = (Convert.ToInt32(txtInputPage.Text) - 1).ToString();

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Next Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtInputPage.Text) >= Convert.ToInt32(txtTotalPage.Text))
                {
                    return;
                }

                txtInputPage.Text = (Convert.ToInt32(txtInputPage.Text) + 1).ToString();

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Last Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            try
            {
                txtInputPage.Text = Convert.ToInt32(txtTotalPage.Text).ToString();

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find TextBox KeyDown Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FindData();
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Button Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                FindData();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Field Reset Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFieldsReset_Click(object sender, EventArgs e)
        {
            this.ReturnValue = string.Empty;
            this.ReturnValues = new List<string>();
            this.ReturnData = new TRSNode(returnDataTRSName);

            this.DialogResult = System.Windows.Forms.DialogResult.No;
            
            this.Close();
        }

        /// <summary>
        /// Refresh Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // 초기화
                ReturnValues = cvpm.ReturnValues;
                ReturnData = cvpm.ReturnData;
                grdAllData.ClearDataSource();
                grdAllData.Refresh();

                // Find ComboBox 초기화
                InitFindComboBox();

                // Find TextBox 초기화
                txtFind.Text = string.Empty;

#if _H101
                // 서비스 조회
                ViewService(true);
#endif
#if _Http
                // 서비스 조회
                txtInputPage.Text = "1";

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize, true) == false)
                {
                    return;
                }
#endif

                // Check Selected Data in All Grid
                CheckSelectedDataInAllGrid(this.ReturnValues);

                // Set Selected Data Bind
                SetSelectedDataBind(this.ReturnData);
            }
            catch (Exception ex)
            {
                MPOF.ShowErrorMessage("CodeView btnRefresh_Click() \n" + ex.Message);
            }
        }

        /// <summary>
        /// OK 버튼 클릭 시, 저장된 데이터를 반환하고 종료합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Return Value : Return Values를 기반으로 패턴화함.
            // Return Values: All Grid에서 Add,Remove할 때 변경됨.
            // Return Datas: Selected Grid에 있는 데이터를 List<TRSNode>로 변경하여 반환함.
            this.ReturnValue = ConvertReturnValuesToReturnValue(this.ReturnValues);
            this.ReturnData = ConvertSelectedGridToReturnData();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ReturnValue = cvpm.Control.Text;
            this.ReturnValues = cvpm.ReturnValues;
            this.ReturnData = cvpm.ReturnData;
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// Find ComboBox를 초기화 합니다.
        /// Header 값을 기준으로 설정합니다.
        /// </summary>
        private void InitFindComboBox()
        {
            // Item Clear
            cboFind.Items.Clear();

            // 보여지는 컬럼에 대하여
            for (int i = 0; i < cvpm.DisplayColumn.Length; i++)
            {
                // Header가 부족하여 column 이름을 사용한 경우
                if (i > cvpm.Header.Length - 1)
                {
                    cboFind.Items.Add(cvpm.DisplayColumn[i], MPOF.FindLanguage(cvpm.DisplayColumn[i]));
                }
                // Header를 사용한 경우
                else
                {
                    cboFind.Items.Add(cvpm.DisplayColumn[i], MPOF.FindLanguage(cvpm.Header[i]));
                }
            }

            // Focus
            if (cboFind.Items.Count > 0)
            {
                cboFind.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Pagenation 부분을 초기화 합니다.
        /// Http, H101 접속에 따라 구분되어 초기화 됩니다.
        /// </summary>
        private void InitPagenation()
        {
#if _Http
            if (cvpm.PageSize != -1)
            {
                pnlPageLeftAll.Visible = true;
                btnFirstPage.Enabled = false;
                pnlPageLeftAllMargin.Visible = true;
                pnlPageLeft.Visible = true;
                btnPrevPage.Enabled = false;
                pnlPagePrevMargin.Visible = true;
                pnlPageCurrent.Visible = true;
                txtInputPage.Text = "1";
                pnlPageSlash.Visible = true;
                pnlPageTotal.Visible = true;
                txtTotalPage.Text = "1";
                pnlPageNext.Visible = true;
                btnNextPage.Enabled = false;
                pnlPageNextMargin.Visible = true;
                pnlPageLast.Visible = true;
                btnLastPage.Enabled = false;
                pnlPageCount.Visible = true;
                txtTotalCount.Text = "";
            }
            else
            {
                pnlPagenation.Visible = false;
                tlpCondition.RowStyles[1].Height = 0;
                tlpMiddle.RowStyles[2].Height = 60;
            }
#endif
#if _H101
            //pnlPageLeftAll.Visible = false;
            //btnFirstPage.Enabled = false;
            //pnlPageLeftAllMargin.Visible = false;
            //pnlPageLeft.Visible = false;
            //btnPrevPage.Enabled = false;
            //pnlPagePrevMargin.Visible = false;
            //pnlPageCurrent.Visible = false;
            //txtInputPage.Text = "0";
            //pnlPageSlash.Visible = false;
            //pnlPageTotal.Visible = false;
            //txtTotalPage.Text = "0";
            //pnlPageNext.Visible = true;
            //btnNextPage.Enabled = false;
            //pnlPageNextMargin.Visible = false;
            //pnlPageLast.Visible = false;
            //btnLastPage.Enabled = false;
            //pnlPageCount.Visible = true;
            //txtTotalCount.Text = "";

            pnlPagenation.Visible = false;
            tlpCondition.RowStyles[1].Height = 0;
            tlpMiddle.RowStyles[2].Height = 60;
#endif
        }

        /// <summary>
        /// 초기화 합니다.
        /// 데이터를 할당합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="popupTitle"></param>
        /// <param name="moduleName"></param>
        /// <param name="serviceName"></param>
        /// <param name="inNode"></param>
        /// <param name="listName"></param>
        /// <param name="displayColumn"></param>
        /// <param name="header"></param>
        /// <param name="selectedColumn"></param>
        /// <returns></returns>
        public bool InitCodeViewPopup(SOICodeViewMultiSelect control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize, List<string> returnValues, TRSNode returnData)
        {
            // 생성
            if (cvpm == null)
            {
                cvpm = new CodeViewMultiSelectPopupModel();
            }

            // 할당
            cvpm.Control = control;
            cvpm.Title = popupTitle;
            cvpm.ModuleName = moduleName;
            cvpm.ServiceName = serviceName;
            cvpm.InNode = inNode;
            cvpm.ListName = listName;
            cvpm.DisplayColumn = displayColumn;
            cvpm.Header = header;
            cvpm.SelectedColumn = selectedColumn;
            cvpm.PageSize = pageSize;
            cvpm.ReturnValues = returnValues;
            cvpm.ReturnData = returnData;

            // 종료
            return true;
        }

        /// <summary>
        /// 서비스를 조회합니다.
        /// H101의 전체조회 용도 입니다.
        /// </summary>
        /// <param name="pPageIndex"></param>
        /// <param name="pPageSize"></param>
        /// <returns></returns>
        private bool ViewService(bool initialize)
        {
            try
            {
                // Init
                TRSNode out_node = new TRSNode("VIEW_SERVICE_OUT");

                // Service Call
                if (MPCR.CallService(cvpm.ModuleName, cvpm.ServiceName, cvpm.InNode, ref out_node) == false)
                {
                    // Error Message
                    if (string.IsNullOrEmpty(out_node.GetString("MSG")) == false)
                    {
                        //MPCR.ShowMessage(out_node.GetString("MSG"), CliFrx.MSSAG_LEVEL.ERROR, false);
                    }

                    return false;
                }

                //  Init Grid
                grdAllData.ClearDataSource();

                // Data Bind
                dtOriginalData = BindToSOIGrid(grdAllData, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header, false);

                // Initialize를 위한 초기화 구문
                if (initialize == true)
                {
                    grdSelectedData.ClearDataSource();
                    dtSelectedData = BindToSOIGrid(grdSelectedData, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header, true);
                }                

                // Scroll
                MPOF.SetScrollRow(grdAllData, cvpm.SelectedColumn, cvpm.Control.Text);

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 서비스를 조회합니다.
        /// HTTP의 페이징 처리 용도 입니다.
        /// </summary>
        /// <param name="pPageIndex"></param>
        /// <param name="pPageSize"></param>
        /// <returns></returns>
        private bool ViewPageService(int pageIndex, int pageSize)
        {
            return ViewPageService(pageIndex, pageSize, false);
        }

        /// <summary>
        /// 서비스를 조회합니다.
        /// HTTP의 페이징 처리 용도 입니다.
        /// </summary>
        /// <param name="pPageIndex"></param>
        /// <param name="pPageSize"></param>
        /// <returns></returns>
        private bool ViewPageService(int pageIndex, int pageSize, bool initialize)
        {
            try
            {
                // Init
                TRSNode out_node = new TRSNode("VIEW_SERVICE_OUT");

                if (cvpm.PageSize > 0)
                {
                    // Page Setting
                    cvpm.InNode.SetInt("PAGE_INDEX", pageIndex - 1);
                    cvpm.InNode.SetInt("PAGE_SIZE", pageSize);

                    if (cvpm.InNode.GetList(0).Count != 0
                            && cvpm.InNode.GetList(0)[0] != null
                            && cvpm.InNode.GetList(0)[0].Name == "EXTJS_FILTER")
                    {
                        cvpm.InNode.Lists[0].items.Clear();
                    }

                    if (string.IsNullOrEmpty(txtFind.Text) == false)
                    {
                        TRSNode filterdata = new TRSNode("EXTJS_FILTER");
                        filterdata.AddString("PROPERTY", cboFind.SelectedItem.DataValue.ToString());
                        filterdata.AddString("VALUE", txtFind.Text);

                        cvpm.InNode.AddNode(filterdata);
                    }
                }

                // Service Call
                if (MPCR.CallService(cvpm.ModuleName, cvpm.ServiceName, cvpm.InNode, ref out_node) == false)
                {
                    // Error Message
                    if (string.IsNullOrEmpty(out_node.GetString("MSG")) == false)
                    {
                        MPOF.ShowMessage(out_node.GetString("MSG"), MSSAG_LEVEL.ERROR, true);
                    }

                    return false;
                }

                //  Init Grid
                grdAllData.ClearDataSource();

                // Data Bind
                dtOriginalData = BindToSOIGrid(grdAllData, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header, false);

                // Initialize를 위한 초기화 구문
                if (initialize == true)
                {
                    grdSelectedData.ClearDataSource();
                    dtSelectedData = BindToSOIGrid(grdSelectedData, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header, true);
                }                

                // Scroll
                //MPCF.SetScrollRow(grdAllData, cvpm.SelectedColumn, cvpm.Control.Text);
                
                if (cvpm.PageSize > 0)
                {
                    txtTotalCount.Text = GetTotal(out_node.GetInt("Total"));
                    txtTotalPage.Text = GetTotalPage(out_node.GetInt("Total"), Convert.ToInt32(cvpm.PageSize));

                    SetButton();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Find 조회조건에 따라 재조회 합니다.
        /// </summary>
        private void FindData()
        {
            try
            {
                // ComboBox에 선택된 컬럼이 없는 경우
                if (cboFind.SelectedIndex < 0)
                {
                    return;
                }

#if _H101
                //// TextBox에 입력된 데이터가 없는 경우
                //if (string.IsNullOrEmpty(txtFind.Text) == true)
                //{
                //    return;
                //}

                if (dtOriginalData != null)
                {
                    // Find
                    dtOriginalData.DefaultView.RowFilter = cboFind.Items[cboFind.SelectedIndex].DataValue + " like '%" + txtFind.Text + "%'";

                    // Grid 초기화
                    grdAllData.ClearDataSource();
                    grdAllData.Refresh();

                    // Bind
                    BindToSOIGrid(grdAllData, dtOriginalData.DefaultView.ToTable(), cvpm.DisplayColumn, cvpm.Header);
                }
#endif
#if _Http
                // Pagenation인 경우
                if (cvpm.PageSize > 0)
                {
                    txtInputPage.Text = "1";

                    if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                    {
                        return;
                    }
                }
                // 그렇지 않은 경우
                else
                {
                    if (dtOriginalData != null)
                    {
                        // Find
                        dtOriginalData.DefaultView.RowFilter = cboFind.Items[cboFind.SelectedIndex].DataValue + " like '%" + txtFind.Text + "%'";

                        // Grid 초기화
                        grdAllData.ClearDataSource();
                        grdAllData.Refresh();

                        // Bind
                        BindToSOIGrid(grdAllData, dtOriginalData.DefaultView.ToTable(), cvpm.DisplayColumn, cvpm.Header);
                    }
                }
#endif
            }
            catch (Exception ex)
            {
                MPOF.ShowErrorMessage("CodeView FindData() \n" + ex.Message);
            }
        }

        /// <summary>
        /// Display Column에서 return해야하는 column의 index를 찾습니다.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int GetIndexDisplayColumn(string columnName)
        {
            int iReturn = 0;

            for (int i = 0; i < cvpm.DisplayColumn.Length; i++)
            {
                if (cvpm.DisplayColumn[i] == columnName)
                {
                    iReturn = i + 1;
                    break;
                }
            }

            return iReturn;
        }

        /// <summary>
        /// 해당 Text를 List에 Add 한다.
        /// </summary>
        /// <param name="addText"></param>
        /// <returns></returns>
        private List<string> AddSelectedColumnText(List<string> valueList, string addText)
        {
            List<string> returnList = new List<string>();

            // List에 데이터가 없는 경우
            if (valueList == null
                || valueList.Count < 1)
            {
                returnList = new List<string>();
                returnList.Add(addText);
            }
            // List에 데이터가 있는 경우
            else
            {
                foreach (string value in valueList)
                {
                    returnList.Add(value);
                }

                // 이미 포함된 경우
                if (returnList.Contains(addText) == true)
                {
                    // 아무것도 하지 않음
                }
                // 포함되지 않은 경우
                else
                {
                    returnList.Add(addText);
                }
            }

            return returnList;
        }

        /// <summary>
        /// 해당 Text를 List에서 제거한다.
        /// </summary>
        /// <param name="addText"></param>
        /// <returns></returns>
        private List<string> RemoveSelectedColumnText(List<string> valueList, string removeText)
        {
            List<string> returnList = new List<string>();

            // List에 데이터가 없는 경우
            if (valueList == null
                || valueList.Count < 1)
            {
                // 아무것도 하지 않음
            }
            // List에 데이터가 있는 경우
            else
            {
                foreach (string value in valueList)
                {
                    returnList.Add(value);
                }

                // 이미 포함된 경우
                if (returnList.Contains(removeText) == true)
                {
                    returnList.Remove(removeText);
                }
                // 포함되지 않은 경우
                else
                {
                    // 아무것도 하지 않음
                }
            }

            return returnList;
        }

        /// <summary>
        /// 해당 Row를 Selected Grid에 Add 한다.
        /// </summary>
        /// <param name="addRow"></param>
        private void AddSelectedColumnToGrid(int addRowIndex)
        {
            // Validation
            if (addRowIndex < 0)
            {
                return;
            }
            if (grdAllData.Rows[addRowIndex] == null)
            {
                return;
            }

            DataTable dtAll = grdAllData.GetDataSource();
            DataTable dtSelected = grdSelectedData.GetDataSource();

            DataRow dr = dtSelected.NewRow();
            for (int i = 0; i < dtAll.Rows[addRowIndex].ItemArray.Length; i++)
            {
                // CheckBox에 대해
                if (i == 0)
                {
                    dr[i] = true;
                }
                else
                {
                    dr[i] = dtAll.Rows[addRowIndex][i];
                }
            }
            dtSelected.Rows.Add(dr);

            grdSelectedData.SetDataSource(dtSelected);
        }

        /// <summary>
        /// 해당 Row를 Selected Grid에서 Remove 한다.
        /// </summary>
        /// <param name="removeRow"></param>
        private void RemoveSelectedColumnFromGrid(int columnIndex, string removeText)
        {
            // Validation
            if(string.IsNullOrEmpty(removeText) == true)
            {
                return;
            }            
            
            DataTable dtSelected = grdSelectedData.GetDataSource();

            int iFoundSelectedIndex = -1;
            for(int i = 0 ; i < dtSelected.Rows.Count; i++)
            {
                if(dtSelected.Rows[i] != null)
                {
                    if(dtSelected.Rows[i][columnIndex].ToString() == removeText)
                    {
                        iFoundSelectedIndex = i;
                        break;
                    }
                }
            }

            if(iFoundSelectedIndex > -1)
            {
                dtSelected.Rows.RemoveAt(iFoundSelectedIndex);
            }

            grdSelectedData.SetDataSource(dtSelected);
        }

        /// <summary>
        /// Return Values 내용을 string 패턴(A,B,C)으로 변환합니다.
        /// </summary>
        /// <param name="valueList"></param>
        /// <returns></returns>
        private string ConvertReturnValuesToReturnValue(List<string> valueList)
        {
            StringBuilder sb = new StringBuilder();

            bool firstData = true;
            foreach (string value in valueList)
            {
                if (firstData == true)
                {
                    sb.Append(value);
                }
                else
                {
                    sb.Append(returnValueSeparator);
                    sb.Append(value);
                }
                firstData = false;
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// Selected Grid에 있는 선택된 모든 값들을 TRSNode로 변환하여 보냅니다.
        /// </summary>
        /// <returns></returns>
        private TRSNode ConvertSelectedGridToReturnData()
        {
            TRSNode trsReturn = new TRSNode(returnDataTRSName);
            DataTable dt = grdSelectedData.GetDataSource();

            // Validation
            if(dt.Rows.Count < 1)
            {
                return trsReturn;
            }

            TRSNode valueNode;
            // Row 수 만큼
            for (int iRowIndex = 0; iRowIndex < dt.Rows.Count; iRowIndex++)
            {
                valueNode = trsReturn.AddNode(returnDataTRSNodeName);

                // Column 수 만큼
                for (int i = 0; i < cvpm.DisplayColumn.Length; i++)
                {                    
                    TRSDataType dataType = TRSDataType.String;
                    if(dt.Columns[i+1].DataType == typeof(bool))
                    {
                        dataType = TRSDataType.Boolean;
                    }
                    else if (dt.Columns[i+1].DataType == typeof(char))
                    {
                          dataType = TRSDataType.Char;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(DateTime))
                    {
                        dataType = TRSDataType.Datetime;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(double))
                    {
                        dataType = TRSDataType.Double;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(float))
                    {
                        dataType = TRSDataType.Float;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(int))
                    {
                        dataType = TRSDataType.Int;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(long))
                    {
                        dataType = TRSDataType.Long;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(object))
                    {
                        dataType = TRSDataType.Object;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(short))
                    {
                        dataType = TRSDataType.Short;
                    }
                    else if(dt.Columns[i+1].DataType == typeof(string))
                    {
                        dataType = TRSDataType.String;
                    }

                    valueNode.AddMember(cvpm.DisplayColumn[i], grdSelectedData.Rows[iRowIndex].Cells[i + 1].Value, dataType);
                }
            }

            return trsReturn;
        }

        /// <summary>
        /// Grid에 column을 Add 합니다.
        /// </summary>
        private UltraGridColumn SOIGridAddColumn(SOIGrid targetGrid, string columnHeaderText, string columnKey)
        {
            UltraGridColumn ugc;

            ugc = targetGrid.DisplayLayout.Bands[0].Columns.Add();
            ugc.Key = columnKey;
            ugc.Header.Caption = columnHeaderText;

            return ugc;
        }

        /// <summary>
        /// Grid CheckBox Column을 Add 합니다.
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="columnHeaderText"></param>
        /// <param name="columnKey"></param>
        /// <returns></returns>
        private UltraGridColumn SOIGridAddCheckBoxColumn(SOIGrid targetGrid, string columnHeaderText, string columnKey)
        {
            UltraGridColumn ugc;

            ugc = targetGrid.DisplayLayout.Bands[0].Columns.Add();
            ugc.DataType = typeof(System.Boolean);
            ugc.Width = 10;
            ugc.Key = columnKey;
            ugc.Header.Caption = columnHeaderText;

            return ugc;
        }

        /// <summary>
        /// 조회한 Out Node의 List를 Grid에 Bind 합니다.
        /// </summary>
        /// <param name="outNodeList"></param>
        /// <param name="displayColumn"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private DataTable BindToSOIGrid(SOIGrid targetGrid, List<TRSNode> outNodeList, string[] displayColumn, string[] headers, bool selected)
        {
            string sTableKey = "codeViewPopup";
            string sCheckBoxColumnKey = "cdvCheckBox";
            DataColumn dc;
            DataRow dr;
            UltraGridColumn ugc;

            // 1. Table Key가 등록되지 않은 경우 임의로 등록.
            if (string.IsNullOrEmpty(targetGrid.DisplayLayout.Bands[0].Key) == false)
            {
                sTableKey = targetGrid.DisplayLayout.Bands[0].Key;
            }

            // 2. Bind Table 생성
            DataTable dtReturn = new DataTable(sTableKey);

            // 3. Out node List의 멤버수 만큼
            foreach (TRSNode node in outNodeList)
            {
                // 첫번째 Column은 반드시 체크박스로 설정
                ugc = SOIGridAddCheckBoxColumn(targetGrid, " ", sCheckBoxColumnKey);
                dc = new DataColumn(sCheckBoxColumnKey, typeof(bool));                
                dtReturn.Columns.Add(dc);

                // 보여지는 컬럼에 대하여
                for (int i = 0; i < displayColumn.Length; i++)
                {
                    // Header가 없는 경우
                    if (i > headers.Length - 1)
                    {
                        // Member가 없거나 값이 없는 경우
                        if (node.GetMember(displayColumn[i]) == null)
                        {
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(displayColumn[i]), displayColumn[i]);
                        }
                        else
                        {
                            // Out Node의 컬럼값을 사용
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(node.GetMember(displayColumn[i]).Name), displayColumn[i]);
                        }
                    }
                    // Header가 있는 경우
                    else
                    {
                        ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(headers[i]), displayColumn[i]);
                    }

                    if (node.GetMember(displayColumn[i]) == null)
                    {
                        dc = new DataColumn(displayColumn[i]);
                    }
                    else
                    {
                        dc = new DataColumn(node.GetMember(displayColumn[i]).Name);
                    }

                    // 해당 컬럼이 없는 경우
                    if (node.GetMember(displayColumn[i]) == null)
                    {
                        ugc.DataType = typeof(string);
                        dc.DataType = typeof(string);
                    }
                    // 해당 컬럼이 있는 경우
                    else
                    {
                        switch (node.GetMember(displayColumn[i]).ValueType)
                        {
                            case TRSDataType.Boolean:
                                ugc.DataType = typeof(bool);
                                dc.DataType = typeof(bool);
                                break;
                            case TRSDataType.Char:
                                ugc.DataType = typeof(char);
                                dc.DataType = typeof(char);
                                break;
                            case TRSDataType.Datetime:
                                ugc.DataType = typeof(DateTime);
                                dc.DataType = typeof(DateTime);
                                break;
                            case TRSDataType.Double:
                                ugc.DataType = typeof(double);
                                dc.DataType = typeof(double);
                                break;
                            case TRSDataType.Float:
                                ugc.DataType = typeof(float);
                                dc.DataType = typeof(float);
                                break;
                            case TRSDataType.Int:
                                ugc.DataType = typeof(int);
                                dc.DataType = typeof(int);
                                break;
                            case TRSDataType.Long:
                                ugc.DataType = typeof(long);
                                dc.DataType = typeof(long);
                                break;
                            case TRSDataType.Object:
                                ugc.DataType = typeof(object);
                                dc.DataType = typeof(object);
                                break;
                            case TRSDataType.Short:
                                ugc.DataType = typeof(short);
                                dc.DataType = typeof(short);
                                break;
                            case TRSDataType.String:
                                ugc.DataType = typeof(string);
                                dc.DataType = typeof(string);
                                break;
                        }
                    }

                    dtReturn.Columns.Add(dc);
                }

                // Column은 1건만 추가
                break;
            }

            // Selected Grid인지 아닌지 여부
            if (selected == false)
            {
                // List Item 만큼
                foreach (TRSNode node in outNodeList)
                {
                    dr = dtReturn.NewRow();

                    // CheckBox의 기본값은 false
                    dr[0] = false;

                    // Display Column 수 만큼
                    for (int i = 0; i < displayColumn.Length; i++)
                    {
                        // 해당 컬럼이 없는 경우
                        if (node.GetMember(displayColumn[i]) == null)
                        {
                            // CheckBox를 포함하기 때문에 +1
                            dr[i + 1] = string.Empty;
                        }
                        // 해당 컬럼이 있는 경우
                        else
                        {
                            // CheckBox를 포함하기 때문에 +1
                            dr[i + 1] = node.GetMember(displayColumn[i]).Value;
                        }
                    }

                    dtReturn.Rows.Add(dr);
                }
            }

            targetGrid.SetDataSource(dtReturn);

            CheckSelectedDataInAllGrid(this.ReturnValues);

            return dtReturn;
        }

        /// <summary>
        /// Data Table을 Grid에 Bind 합니다.
        /// </summary>
        /// <param name="outNodeList"></param>
        /// <param name="displayColumn"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private DataTable BindToSOIGrid(SOIGrid targetGrid, DataTable dtData, string[] displayColumn, string[] headers)
        {
            string sTableKey = "codeViewPopup";
            string sCheckBoxColumnKey = "cdvCheckBox";
            DataColumn dc;
            DataRow dr;
            UltraGridColumn ugc;
            UltraGridRow ugr;

            // 1. Table Key가 등록되지 않은 경우 임의로 등록
            if (string.IsNullOrEmpty(targetGrid.DisplayLayout.Bands[0].Key) == false)
            {
                sTableKey = targetGrid.DisplayLayout.Bands[0].Key;
            }

            // 2. Bind Table 생성
            DataTable dtReturn = new DataTable(sTableKey);

            // 3. 첫번째 Column은 반드시 체크박스로 설정
            ugc = SOIGridAddCheckBoxColumn(targetGrid, " ", sCheckBoxColumnKey);
            dc = new DataColumn(sCheckBoxColumnKey, typeof(bool));
            dtReturn.Columns.Add(dc);

            // 4. 컬럼수 만큼
            foreach (DataColumn dcData in dtData.Columns)
            {
                dc = new DataColumn();

                // 보여지는 컬럼에 대하여
                for (int i = 0; i < displayColumn.Length; i++)
                {
                    // 찾는 컬럼이 아닌 경우 continue
                    if (dcData.ColumnName != displayColumn[i])
                    {
                        continue;
                    }
                    // 찾는 컬럼인 경우
                    else
                    {
                        // Header가 없는 경우
                        if (i > headers.Length - 1)
                        {
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(dcData.ColumnName), displayColumn[i]);
                        }
                        // Header가 있는 경우
                        else
                        {
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(headers[i]), displayColumn[i]);
                        }

                        dc.ColumnName = dcData.ColumnName;

                        ugc.DataType = dcData.DataType;
                        dc.DataType = dcData.DataType;
                    }
                }

                if (string.IsNullOrEmpty(dc.ColumnName) == false)
                {
                    dtReturn.Columns.Add(dc);
                }
            }

            // 찾는 컬럼이 있는 경우
            if (dtReturn.Columns.Count > 0)
            {
                // 데이터 수 만큼
                foreach (DataRow drData in dtData.Rows)
                {
                    ugr = targetGrid.DisplayLayout.Bands[0].AddNew();
                    dr = dtReturn.NewRow();

                    for (int i = 0; i < dtReturn.Columns.Count; i++)
                    {
                        // CheckBox를 포함하기 때문에 +1
                        ugr.Cells[i].Value = drData[dtReturn.Columns[i].ColumnName];
                        dr[i] = drData[dtReturn.Columns[i].ColumnName];
                    }

                    dtReturn.Rows.Add(dr);
                }
            }

            targetGrid.SetDataSource(dtReturn);

            CheckSelectedDataInAllGrid(this.ReturnValues);

            return dtReturn;
        }

        /// <summary>
        /// 기존에 선택한 Data에 대해 All Grid의 Row의 체크박스에 체크합니다.
        /// </summary>
        private void CheckSelectedDataInAllGrid(List<string> values)
        {
            // Validation
            if (values == null)
            {
                return;
            }

            DataTable dt = grdAllData.GetDataSource();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[GetIndexDisplayColumn(cvpm.SelectedColumn)] != null)
                {
                    if (values.Contains(dr[GetIndexDisplayColumn(cvpm.SelectedColumn)].ToString()) == true)
                    {
                        dr[0] = true;
                    }
                    else
                    {
                        dr[0] = false;
                    }
                }
            }

            grdAllData.SetDataSource(dt);
        }

        /// <summary>
        /// 기존에 선택한 Data를 Selected Grid에 Bind 합니다.
        /// </summary>
        private void SetSelectedDataBind(TRSNode data)
        {
            // Validation
            if (data == null
                || data.GetList(0) == null
                || data.GetList(0).Count < 1)
            {
                return;
            }

            DataTable dt = grdSelectedData.GetDataSource();

            foreach (TRSNode node in data.GetList(0))
            {
                DataRow dr = dt.NewRow();
                dr[0] = true;

                for (int i = 0; i < cvpm.DisplayColumn.Length; i++)
                {
                    switch (node.GetMember(cvpm.DisplayColumn[i]).ValueType)
                    {
                        case TRSDataType.String:
                            dr[i + 1] = node.GetString(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Boolean:
                            dr[i + 1] = node.GetBoolean(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Char:
                            dr[i + 1] = node.GetChar(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Datetime:
                            dr[i + 1] = node.GetDatetime(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Double:
                            dr[i + 1] = node.GetDouble(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Float:
                            dr[i + 1] = node.GetFloat(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Int:
                            dr[i + 1] = node.GetInt(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Long:
                            dr[i + 1] = node.GetLong(cvpm.DisplayColumn[i]);
                            break;
                        case TRSDataType.Object:
                            dr[i + 1] = node.GetObject(cvpm.DisplayColumn[i]);
                            break;                        
                        default:
                            dr[i + 1] = node.GetMember(cvpm.DisplayColumn[i]).Value;
                            break;
                    }
                }

                dt.Rows.Add(dr);
            }

            grdSelectedData.SetDataSource(dt);
        }

        /// <summary>
        /// 전체 데이터 수 계산
        /// </summary>
        /// <param name="iTotalRows"></param>
        /// <returns></returns>
        private string GetTotal(int iTotalRows)
        {
            string sReturn = MPOF.FindLanguage("No data to display");

            // 조회 데이터가 없는 경우
            if (iTotalRows <= 0)
            {
                return sReturn;
            }
            // 1건이상 있는 경우
            else
            {
                string iPasgeSize = cvpm.PageSize > iTotalRows ? iTotalRows.ToString() : cvpm.PageSize.ToString();
                sReturn = iPasgeSize + "/" + iTotalRows.ToString();
            }

            return sReturn;
        }

        /// <summary>
        /// 전체 페이지 수 계산
        /// </summary>
        /// <param name="iTotalRows"></param>
        /// <param name="iPageSize"></param>
        /// <returns></returns>
        private string GetTotalPage(int iTotalRows, int iPageSize)
        {
            string sReturn = "1";

            // 조회된 데이터가 없는 경우
            if (iTotalRows <= 0)
            {
                return sReturn;
            }
            // 1건이상 조회된 경우
            else
            {
                double dPageCount = Math.Ceiling((double)iTotalRows / (double)iPageSize);
                sReturn = Convert.ToInt32(dPageCount).ToString();
            }

            return sReturn;
        }

        /// <summary>
        /// Set Condition Button
        /// </summary>
        private void SetButton()
        {
            // 마지막 Page인 경우
            if (Convert.ToInt32(txtInputPage.Text) >= Convert.ToInt32(txtTotalPage.Text))
            {
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            }
            // 마지막 Page가 아닌 경우
            else
            {
                btnNextPage.Enabled = true;
                btnLastPage.Enabled = true;
            }

            // 첫번째 Page인 경우
            if (Convert.ToInt32(txtInputPage.Text) < 2)
            {
                btnFirstPage.Enabled = false;
                btnPrevPage.Enabled = false;
            }
            // 첫번째 Page가 아닌 경우
            else
            {
                btnFirstPage.Enabled = true;
                btnPrevPage.Enabled = true;
            }
        }

        #endregion
    }

    public class CodeViewMultiSelectPopupModel
    {
        private SOICodeViewMultiSelect _control;
        public SOICodeViewMultiSelect Control
        {
            get { return _control; }
            set { _control = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _moduleName;
        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }

        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        private TRSNode _inNode;
        public TRSNode InNode
        {
            get { return _inNode; }
            set { _inNode = value; }
        }

        private string _listName;
        public string ListName
        {
            get { return _listName; }
            set { _listName = value; }
        }

        private string[] _displayColumn;
        public string[] DisplayColumn
        {
            get { return _displayColumn; }
            set { _displayColumn = value; }
        }

        private string[] _header;
        public string[] Header
        {
            get { return _header; }
            set { _header = value; }
        }

        private string _selectedColumn;
        public string SelectedColumn
        {
            get { return _selectedColumn; }
            set { _selectedColumn = value; }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private List<string> _returnValues;
        public List<string> ReturnValues
        {
            get { return _returnValues; }
            set { _returnValues = value; }
        }

        private TRSNode _returnData;
        public TRSNode ReturnData
        {
            get { return _returnData; }
            set { _returnData = value; }
        }
    }
}
