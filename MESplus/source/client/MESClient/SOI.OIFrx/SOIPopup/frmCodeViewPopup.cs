using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using SOI.OIFrx.SOIControls;
using Miracom.TRSCore;
using Infragistics.Win.UltraWinGrid;
using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIPopup
{
    public partial class frmCodeViewPopup : frmPopupBase
    {
        #region Property

        public enum VIEW_TYPE : int
        {
            TYPE_SERVICE = 0,
            TYPE_DYNAMIC
        }

        public string ReturnValue;

        public List<string> ReturnDatas;

        private DataTable dtOriginalData;

        private CodeViewPopupModel cvpm;

        /// <summary>
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

        public frmCodeViewPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 팝업화면 로드 시 발생합니다.
        /// 서비스를 조회하고 Find를 초기화 합니다.
        /// 캡션을 적용합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCodeViewPopup_Load(object sender, EventArgs e)
        {
            // Title 변경
            lblPopupTitle.Text = MPOF.FindLanguage(cvpm.Title);

            // Grid 초기화
            gridCodeViewPopup.InitDataSource();

            // Return Data 초기화
            ReturnDatas = new List<string>();

            // Find ComboBox 초기화
            InitFindComboBox();

            // Pagenation 초기화
            InitPagenation();

#if _H101
            // 서비스 조회
            if (ViewService(cvpm.Step) == false)
            {
                // Error Close
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                ReturnValue = cvpm.Control.Text;
                this.Close();
            }
#endif
#if _Http
            // 서비스 조회
            if (ViewPageService(1, cvpm.PageSize) == false)
            {
                // Error Close
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                ReturnValue = cvpm.Control.Text;
                this.Close();
            }
#endif

            // Caption 변경
            MPOF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// Grid에서 아이템 선택 시 해당 값을 리턴합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCodeViewPopup_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                // 데이터 소스가 없거나 데이터가 없는 경우
                if (gridCodeViewPopup.Rows.Count == 0)
                {
                    return;
                }

                // 선택된 Row가 없는 경우
                if (gridCodeViewPopup.Selected.Rows.Count < 1)
                {
                    return;
                }

                // 선택된 Row 데이터 저장
                int iIndex = GetIndexDisplayColumn(cvpm.SelectedColumn);
                this.ReturnValue = gridCodeViewPopup.Selected.Rows[0].Cells[iIndex].Text;

                this.ReturnDatas.Clear();
                for (int i = 0; i < gridCodeViewPopup.Selected.Rows[0].Cells.Count; i++)
                {
                    this.ReturnDatas.Add(gridCodeViewPopup.Selected.Rows[0].Cells[i].Text);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Fields Reset 버튼 클릭 시, 공백을 Return 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFieldsReset_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            ReturnDatas.Clear();
            this.ReturnValue = string.Empty;

            this.Close();
        }

        /// <summary>
        /// Refresh 버튼을 누른 경우, 코드뷰 팝업 화면을 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Grid 초기화
                gridCodeViewPopup.ClearDataSource();
                gridCodeViewPopup.Refresh();

                // Find ComboBox 초기화
                InitFindComboBox();

                // Find TextBox 초기화
                txtFind.Text = string.Empty;

#if _H101
                // 서비스 조회
                ViewService(cvpm.Step);
#endif
#if _Http
                // 서비스 조회
                txtInputPage.Text = "1";

                if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
                {
                    return;
                }
#endif
                // Return Data 초기화
                ReturnDatas = new List<string>();
            }
            catch (Exception ex)
            {
                MPOF.ShowErrorMessage("CodeView btnRefresh_Click() \n" + ex.Message);
            }
        }

        /// <summary>
        /// Close 버튼을 클릭한 경우, 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            ReturnDatas.Clear();
            ReturnValue = cvpm.Control.Text;

            this.Close();
        }

        /// <summary>
        /// Find TextBox에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindData();
            }
        }

        /// <summary>
        /// Find 버튼을 클릭 시 데이터를 재구성합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }
        
        /// <summary>
        /// Get Next Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Get Last Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            txtInputPage.Text = Convert.ToInt32(txtTotalPage.Text).ToString();

            if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
            {
                return;
            }
        }

        /// <summary>
        /// Get Prev Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Get First Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            txtInputPage.Text = "1";

            if (ViewPageService(Convert.ToInt32(txtInputPage.Text), cvpm.PageSize) == false)
            {
                return;
            }
        }
        
        #endregion

        #region Function

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
        public bool InitCodeViewPopup(int step, SOICodeView control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            // 생성
            if (cvpm == null)
            {
                cvpm = new CodeViewPopupModel();
            }

            // 할당
            cvpm.Step = step;
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

            // 종료
            return true;
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
        public bool InitCodeViewPopup(int step, SOICodeView control, string popupTitle, string queryID, string[] queryArgument,
            string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            // 생성
            if (cvpm == null)
            {
                cvpm = new CodeViewPopupModel();
            }

            // 할당
            cvpm.Step = step;
            cvpm.Control = control;
            cvpm.Title = popupTitle;
            cvpm.DisplayColumn = displayColumn;
            cvpm.Header = header;
            cvpm.SelectedColumn = selectedColumn;
            cvpm.PageSize = pageSize;
            cvpm.QueryID = queryID;
            cvpm.QueryArgument = queryArgument;

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
        private bool ViewService(int step)
        {
            try
            {
                // Init
                TRSNode out_node = new TRSNode("VIEW_SERVICE_OUT");
                DataTable _dt = new DataTable();

                if (step == (int)VIEW_TYPE.TYPE_SERVICE)
                {
                    // Service Call
                    if (MPCR.CallService(cvpm.ModuleName, cvpm.ServiceName, cvpm.InNode, ref out_node) == false)
                    {
                        // Error Message
                        if (string.IsNullOrEmpty(out_node.GetString("MSG")) == false)
                        {
                            MPOF.ShowMessage(out_node.GetString("MSG"), MSSAG_LEVEL.ERROR, false);
                        }

                        return false;
                    }
                    // Data Bind
                    dtOriginalData = BindToSOIGrid(gridCodeViewPopup, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header);
                }
                else
                {
                    _dt = MPOF.MGetData(cvpm.QueryID, cvpm.QueryArgument);

                    // Data Bind
                    dtOriginalData = BindToSOIGrid(gridCodeViewPopup, _dt, cvpm.DisplayColumn, cvpm.Header);
                }

                // Scroll
                MPOF.SetScrollRow(gridCodeViewPopup, cvpm.SelectedColumn, cvpm.Control.Text);

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
                gridCodeViewPopup.ClearDataSource();

                // Data Bind
                dtOriginalData = BindToSOIGrid(gridCodeViewPopup, out_node.GetList(cvpm.ListName), cvpm.DisplayColumn, cvpm.Header);

                // Scroll
                MPOF.SetScrollRow(gridCodeViewPopup, cvpm.SelectedColumn, cvpm.Control.Text);

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
        /// Find ComboBox를 초기화 합니다.
        /// Header 값을 기준으로 설정합니다.
        /// </summary>
        private void InitFindComboBox()
        {
            cboFind.Items.Clear();

            for (int i = 0; i < cvpm.DisplayColumn.Length; i++)
            {
                // Header가 부족하여 column 이름을 사용한 경우
                if (i > cvpm.Header.Length - 1)
                {
                    cboFind.Items.Add(cvpm.DisplayColumn[i], MPOF.FindLanguage(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cvpm.DisplayColumn[i].Replace('_', ' ').ToLower())));
                }
                // Header를 사용한 경우
                else
                {
                    cboFind.Items.Add(cvpm.DisplayColumn[i], MPOF.FindLanguage(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cvpm.Header[i].Replace('_', ' ').ToLower()))); 
                }
            }

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

                if (gridCodeViewPopup.Rows.Count <= 0)
                {
                    return;
                }

#if _H101
                // TextBox에 입력된 데이터가 없는 경우
                if (string.IsNullOrEmpty(txtFind.Text) == true)
                {
                    return;
                }

                if (dtOriginalData != null)
                {
                    // Find
                    dtOriginalData.DefaultView.RowFilter = cboFind.Items[cboFind.SelectedIndex].DataValue + " like '%" + txtFind.Text + "%'";

                    // Grid 초기화
                    gridCodeViewPopup.ClearDataSource();
                    gridCodeViewPopup.Refresh();

                    // Bind
                    BindToSOIGrid(gridCodeViewPopup, dtOriginalData.DefaultView.ToTable(), cvpm.DisplayColumn, cvpm.Header);
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
                        gridCodeViewPopup.ClearDataSource();
                        gridCodeViewPopup.Refresh();

                        // Bind
                        BindToSOIGrid(gridCodeViewPopup, dtOriginalData.DefaultView.ToTable(), cvpm.DisplayColumn, cvpm.Header);
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
                    iReturn = i;
                    break;
                }
            }

            return iReturn;
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
        /// 조회한 Out Node의 List를 Grid에 Bind 합니다.
        /// </summary>
        /// <param name="outNodeList"></param>
        /// <param name="displayColumn"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private DataTable BindToSOIGrid(SOIGrid targetGrid, List<TRSNode> outNodeList, string[] displayColumn, string[] headers)
        {
            string sTableKey = "codeViewPopup";
            DataColumn dc;
            DataRow dr;
            UltraGridColumn ugc;
            //UltraGridRow ugr;

            if (string.IsNullOrEmpty(targetGrid.DisplayLayout.Bands[0].Key) == false)
            {
                sTableKey = targetGrid.DisplayLayout.Bands[0].Key;
            }

            DataTable dtReturn = new DataTable(sTableKey);

            // List Item 만큼
            foreach (TRSNode node in outNodeList)
            {
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

            // List Item 만큼
            foreach (TRSNode node in outNodeList)
            {
                //ugr = targetGrid.DisplayLayout.Bands[0].AddNew();
                dr = dtReturn.NewRow();

                // Display Column 수 만큼
                for (int i = 0; i < displayColumn.Length; i++)
                {
                    // 해당 컬럼이 없는 경우
                    if (node.GetMember(displayColumn[i]) == null)
                    {
                        //ugr.Cells[i].Value = string.Empty;
                        dr[i] = string.Empty;
                    }
                    else
                    {
                        //ugr.Cells[i].Value = node.GetMember(displayColumn[i]).Value;
                        dr[i] = node.GetMember(displayColumn[i]).Value;
                    }
                }

                dtReturn.Rows.Add(dr);
            }

            targetGrid.SetDataSource(dtReturn);

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
            DataColumn dc;
            DataRow dr;
            UltraGridColumn ugc;
            UltraGridRow ugr;

            if (string.IsNullOrEmpty(targetGrid.DisplayLayout.Bands[0].Key) == false)
            {
                sTableKey = targetGrid.DisplayLayout.Bands[0].Key;
            }

            DataTable dtReturn = new DataTable(sTableKey);

            // 컬럼 수 만큼
            foreach (DataColumn dcData in dtData.Columns)
            {
                dc = new DataColumn();

                // 보여지는 컬럼 목록 만큼
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
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dcData.ColumnName.Replace('_', ' ').ToLower())), displayColumn[i]);
                        }
                        // Header가 있는 경우
                        else
                        {
                            ugc = SOIGridAddColumn(targetGrid, MPOF.FindLanguage(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(headers[i].Replace('_', ' ').ToLower())), displayColumn[i]);
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
                        ugr.Cells[i].Value = drData[dtReturn.Columns[i].ColumnName];
                        dr[i] = drData[dtReturn.Columns[i].ColumnName];
                    }

                    dtReturn.Rows.Add(dr);
                }
            }

            targetGrid.SetDataSource(dtReturn);

            return dtReturn;
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

    public class CodeViewPopupModel
    {
        private SOICodeView _control;
        public SOICodeView Control
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

        private string _queryID;
        public string QueryID
        {
            get { return _queryID; }
            set { _queryID = value; }
        }

        private string[] _queryArgument;
        public string[] QueryArgument
        {
            get { return _queryArgument; }
            set { _queryArgument = value; }
        }

        private int _step;
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

    }
}
