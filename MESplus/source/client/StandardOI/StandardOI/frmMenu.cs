using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.CliFrx.CliFrxPopup;
using SOI.CliFrx;
using Miracom.TRSCore;
using SOI.OIFrx;
using System.Collections;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using StandardOI.Samples;
using System.Reflection;

namespace StandardOI
{
    public partial class frmMenu : Form
    {
        #region Property

        private bool bIsShown = false;

        ImageList menuImage = new ImageList();

        // 우.하단
        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // if click outside dialog -> Close Dlg
            if (m.Msg == 0x0086) //0x86
            {
                // 보이고 화면이 로드완료된 이후에만
                if (this.Visible 
                    && this.bIsShown == true)
                {
                    // 화면 바깥에서 커서가 있는 경우
                    if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
                    {
                        // 화면 닫기
                        this.Close();
                    }
                }
            }
        }

        #endregion

        #region Constructor

        public frmMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면을 로드할 때 발생한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Theme 변환
            SetOITheme();

            // All Menu 조회
            MPGV.gIMdiForm.GetAllFunctionList();

            // Favorite Menu 조회
            MPGV.gIMdiForm.GetFavFunctionList();
            
            // All Menu 할당
            if (MPGV.galAllFunctionList != null)
            {
                if (AddAllFunctionList() == false)
                {
                    this.Close();
                }
            }

            // Favorite Menu 할당
            if (MPGV.galFavFunctionList != null)
            {
                if (AddFavFunctionList() == false)
                {
                    this.Close();
                }
            }

            MPCF.ConvertCaption(this);

            // Focus
            if (lbFavoriteList.Rows.Count > 0)
            {
                lbFavoriteList.ActiveRowScrollRegion.ScrollRowIntoView(lbFavoriteList.Rows[0]);
            }

            // 화면이 숨겨지므로 강제 Activation
            this.Activate();
        }

        /// <summary>
        /// Menu Form Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMenu_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                // Focus
                if (lbFavoriteList.Rows.Count == 0)
                {
                    tabMenu.Tabs[1].Selected = true;
                    MPCF.SetFocus(tvAllMenu);
                }
                else
                {
                    //lbFavoriteList.ActiveRowScrollRegion.ScrollRowIntoView(lbFavoriteList.Rows[0]);
                    MPCF.SetFocus(lbFavoriteList);
                }

                bIsShown = true;
            }
        }

        /// <summary>
        /// 화면이 닫힐 때 Background Mask 화면을 제거합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(false);
            }

            if (this.Owner != null)
            {
                Owner.Activate();
            }
        }

        /// <summary>
        /// All Menu에서 화면 선택 시 화면을 Open합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvAllMenu_AfterSelect(object sender, SelectEventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            Control cFocusControl;

            try
            {
                if (e.NewSelections[0] != null
                    && e.NewSelections[0].Tag != null)
                {
                    selectedMenuInfo = (MenuInfoTag)e.NewSelections[0].Tag;

                    // 화면인 경우
                    if (string.IsNullOrEmpty(selectedMenuInfo.s_assembly_file) == false)
                    {
                        cFocusControl = MPGV.gIMdiForm.OpenMenu(selectedMenuInfo);
                        if (cFocusControl != null)
                        {
                            cFocusControl.Focus();
                        }

                        this.Close();
                    }
                    // 목록인 경우
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("Menu_AfterSelect()\n" + ex.Message);
            }
        }

        /// <summary>
        /// Favorite List Box에서 화면 선택 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFavoriteList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            Control cFocusControl;

            try
            {
                if(lbFavoriteList.Selected.Rows.Count > 0)                
                {
                    selectedMenuInfo = (MenuInfoTag)lbFavoriteList.Selected.Rows[0].Tag;

                    // 화면인 경우
                    if (string.IsNullOrEmpty(selectedMenuInfo.s_assembly_file) == false)
                    {
                        cFocusControl = MPGV.gIMdiForm.OpenMenu(selectedMenuInfo);
                        if (cFocusControl != null)
                        {
                            cFocusControl.Focus();
                        }

                        this.Close();
                    }
                    // 목록인 경우
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("lbFavoriteList_AfterSelectChange \n " + ex.Message);
            }
        }

        /// <summary>
        /// 아이템 선택 변경 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFavorites_ItemSelectionChanged(object sender, Infragistics.Win.UltraWinListView.ItemSelectionChangedEventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            Control cFocusControl;

            try
            {
                if (e.SelectedItems != null
                    && e.SelectedItems[0].Tag != null)
                {
                    selectedMenuInfo = (MenuInfoTag)e.SelectedItems[0].Tag;

                    // 화면인 경우
                    if (string.IsNullOrEmpty(selectedMenuInfo.s_assembly_file) == false)
                    {
                        cFocusControl = MPGV.gIMdiForm.OpenMenu(selectedMenuInfo);
                        if (cFocusControl != null)
                        {
                            cFocusControl.Focus();
                        }

                        this.Close();
                    }
                    // 목록인 경우
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("lbFavorites_ItemSelectionChanged()\n" + ex.Message);
            }
        }

        /// <summary>
        /// Focus to control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                // Favorite
                if (e.Tab.Index == 0)
                {
                    MPCF.SetFocus(lbFavoriteList);
                }
                else
                {
                    MPCF.SetFocus(tvAllMenu);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Favorite 설정 화면을 엽니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbFavoriteSetup_Click(object sender, EventArgs e)
        {
            try
            {
                frmFavoriteSetup frm = new frmFavoriteSetup();
                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "StandardOI.exe";
                menuInfo.s_assembly_name = "StandardOI.frmFavoriteSetup";
                menuInfo.s_func_desc = "Favorites Setup";
                menuInfo.s_func_name = "SYSTEM";

                Control cFocus = MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
                if (cFocus != null)
                {
                    cFocus.Focus();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Menu 화면을 닫는다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// Show Dialog 시에 Background Mask 화면을 보여줍니다.
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            if (MPGV.gIMdiForm.GetLoginState() == false)
            {
                MPCF.SetBackgroundMask(true);
            }

            return base.ShowDialog();
        }

        /// <summary>
        /// Theme를 로드합니다.
        /// </summary>
        private void SetOITheme()
        {
            MPCF.LoadControlTheme(this);
            this.BackColor = MPGV.gTheme.MainMenuFormBorder;
            this.pnlMenuOutline.BackColor = MPGV.gTheme.MainMenuFormBackground;
        }

        /// <summary>
        /// TreeView에 전체화면목록을 Bind합니다.
        /// </summary>
        public bool AddAllFunctionList()
        {            
            int iFuncCount;
            ArrayList func_list = new ArrayList();

            try
            {
                tvAllMenu.Nodes.Clear();

                foreach (TRSNode node in MPGV.galAllFunctionList)
                {
                    if (MPCF.Trim(MPGV.gsUserGroup) != "" && node.GetList(0).Count > 0)
                    {
                        for (int i = 0; i < node.GetList(0).Count; i++)
                        {
                            func_list.Add(node.GetList(0)[i]);
                        }
                    }
                }

                if (MPCF.Trim(MPGV.gsUserGroup) != "")
                {
                    iFuncCount = 0;                    
                    ViewFunctionTreeViewList(null, "0", func_list, ref iFuncCount);
                }
                
                // 모든 Node Expand
                tvAllMenu.ExpandAll();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ListView에 즐겨찾기 화면 목록을 Bind합니다.
        /// </summary>
        public bool AddFavFunctionList()
        {
            //int iIndex;
            int iArgs;
            MenuInfoTag menuInfo;
            UltraGridRow ugrRow;

            try
            {
                // 초기화
                lbFavoriteList.InitDataSource();

                List < TRSNode > func_list;
                if (MPGV.galFavFunctionList[0] != null)
                {
                    func_list = ((TRSNode)MPGV.galFavFunctionList[0]).GetList(0);
                }
                else
                {
                    return false;
                }

                //iIndex = 0;
                foreach (TRSNode node in func_list)
                {
                    if (string.IsNullOrEmpty(node.GetString("FUNC_NAME")) == true)
                    {
                        continue;
                    }

                    menuInfo = new MenuInfoTag();

                    menuInfo.s_func_name = node.GetString("FUNC_NAME");
                    //menuInfo.s_func_desc = node.GetString("FUNC_DESC");
                    menuInfo.s_func_desc = GetFuncDescFromAllMenu(node.GetString("FUNC_NAME"));
                    menuInfo.s_assembly_file = node.GetString("ASSEMBLY_FILE");
                    menuInfo.c_func_type = node.GetChar("FUNC_TYPE_FLAG");
                    iArgs = node.GetString("ASSEMBLY_NAME").IndexOf(' ');
                    if (iArgs > 0)
                    {
                        menuInfo.s_assembly_name = node.GetString("ASSEMBLY_NAME").Substring(0, iArgs);
                        menuInfo.s_args = node.GetString("ASSEMBLY_NAME").Substring(iArgs + 1, node.GetString("ASSEMBLY_NAME").Length - iArgs - 1);
                    }
                    else
                    {
                        menuInfo.s_assembly_name = node.GetString("ASSEMBLY_NAME");
                        menuInfo.s_args = null;
                    }

                    ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                    ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                    ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + MPCF.FindLanguage(menuInfo.s_func_desc);
                    ugrRow.Tag = menuInfo;
                }

                // Debug Sample                
#if DEBUG
                // Test Sample Basic Controls
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleBasicControls";
                //menuInfo.s_func_desc = "Basic Controls";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Layout and other Controls
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleLayoutAndOthers";
                //menuInfo.s_func_desc = "Layout and others";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Grid Controls
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleGridControls";
                //menuInfo.s_func_desc = "Grid Controls";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Spread and Print
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleSpreadAndPrint";
                //menuInfo.s_func_desc = "Spread and print";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Chart
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleChart";
                //menuInfo.s_func_desc = "Chart";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Message From Http
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleMessageFromHttp";
                //menuInfo.s_func_desc = "Message From Http";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Flexible Screen
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleFlexibleScreen";
                //menuInfo.s_func_desc = "Flexible Screen";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample PLM View
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSamplePLMView";
                //menuInfo.s_func_desc = "PLM View";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Image File Upload
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleImageFileUpload";
                //menuInfo.s_func_desc = "Image File Upload";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Basic Control 2
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleBasicControls2";
                //menuInfo.s_func_desc = "Basic Control 2";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Flexible Screen Mfo
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSampleFlexibleScreenMfo";
                //menuInfo.s_func_desc = "Flexible Screen MFO";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;

                //// Test Sample Popup
                //menuInfo = new MenuInfoTag();
                //menuInfo.c_func_type = 'F';
                //menuInfo.s_assembly_file = "StandardOI.exe";
                //menuInfo.s_assembly_name = "StandardOI.Samples.frmTestSamplePopup";
                //menuInfo.s_func_desc = "Sample Popup";
                //menuInfo.s_func_name = "SAMPLE";
                //ugrRow = lbFavoriteList.DisplayLayout.Bands[0].AddNew();
                //ugrRow.Cells[0].Value = Properties.Resources.Menu_Fav_Image;
                //ugrRow.Cells[1].Value = menuInfo.s_func_name + " : " + menuInfo.s_func_desc;
                //ugrRow.Tag = menuInfo;
                
#endif
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  Tree Menu를 구성합니다.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="s_parent_level"></param>
        /// <param name="func_list"></param>
        /// <param name="i"></param>
        /// <param name="b_use_attach_function_tree"></param>
        private void ViewFunctionTreeViewList(UltraTreeNode parentNode, string s_parent_level, ArrayList func_list, ref int iFuncCount)
        {
            string[] s_p_level;
            string[] s_c_level;
            MenuInfoTag m_menu;
            TRSNode func_item;
            UltraTreeNode nodeX;

            try
            {
                if (func_list != null && func_list.Count > 0)
                {
                    nodeX = null;
                    s_p_level = s_parent_level.Split('.');

                    while (iFuncCount < func_list.Count)
                    {
                        func_item = (TRSNode)func_list[iFuncCount];
                        s_c_level = func_item.GetString("DISP_LEVEL").Split('.');

                        // 다음 상위레벨의 화면인 경우
                        if (s_p_level.Length > s_c_level.Length)
                        {
                            return;
                        }
                        // 하위 화면이 존재하는 경우
                        else if (nodeX != null && s_p_level.Length < s_c_level.Length)
                        {
                            ViewFunctionTreeViewList(nodeX, func_item.GetString("DISP_LEVEL"), func_list, ref iFuncCount);
                        }
                        // 화면을 Add 하는 경우
                        else
                        {
                            nodeX = new UltraTreeNode(func_item.GetString("FUNC_NAME"), func_item.GetString("FUNC_NAME") + " : " + MPCF.FindLanguage(func_item.GetString("FUNC_DESC")));

                            m_menu.s_func_name = func_item.GetString("FUNC_NAME");
                            m_menu.s_func_desc = func_item.GetString("FUNC_DESC");
                            m_menu.s_assembly_file = func_item.GetString("ASSEMBLY_FILE");

                            int args_start_p = func_item.GetString("ASSEMBLY_NAME").IndexOf(' ');

                            if (args_start_p > 0)
                            {
                                m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME").Substring(0, args_start_p);
                                m_menu.s_args = func_item.GetString("ASSEMBLY_NAME").Substring(args_start_p + 1, func_item.GetString("ASSEMBLY_NAME").Length - args_start_p - 1);
                            }
                            else
                            {
                                m_menu.s_assembly_name = func_item.GetString("ASSEMBLY_NAME");
                                m_menu.s_args = null;
                            }

                            m_menu.c_func_type = func_item.GetChar("FUNC_TYPE_FLAG");

                            nodeX.Tag = m_menu;

                            // Parent Node가 존재하는 경우
                            if (parentNode != null)
                            {
                                parentNode.Nodes.Add(nodeX);
                            }
                            // Parent Node가 존재하지 않는 경우
                            else
                            {
                                nodeX.Text = MPCF.FindLanguage(func_item.GetString("FUNC_DESC"));
                                tvAllMenu.Nodes.Add(nodeX);
                            }

                            iFuncCount++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MPCF.ShowErrorMessage("ViewFunctionTreeViewList()\n" + e.Message);
            }
        }

        /// <summary>
        /// 전체 메뉴에서 해당 화면의 Title을 가져 옵니다.
        /// </summary>
        /// <param name="sFuncName"></param>
        /// <returns></returns>
        private string GetFuncDescFromAllMenu(string sFuncName)
        {
            ArrayList func_list = new ArrayList();

            try
            {
                foreach (TRSNode node in MPGV.galAllFunctionList)
                {
                    if (MPCF.Trim(MPGV.gsUserGroup) != "" && node.GetList(0).Count > 0)
                    {
                        for (int i = 0; i < node.GetList(0).Count; i++)
                        {
                            func_list.Add(node.GetList(0)[i]);
                        }
                    }
                }

                foreach (TRSNode node in func_list)
                {
                    if (node.GetString("FUNC_NAME") == sFuncName)
                    {
                        return node.GetString("FUNC_DESC");
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("frmMenu: GetFuncDescFromAllMenu\n" + ex.Message);
                return "";
            }
        }

        #endregion
    }
}
