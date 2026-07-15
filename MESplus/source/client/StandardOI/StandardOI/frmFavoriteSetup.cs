using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using System.Collections;
using Miracom.TRSCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace StandardOI
{
    public partial class frmFavoriteSetup : SOIBaseForm01
    {
        #region Constructor

        public frmFavoriteSetup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// 화면을 로드할 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFavoriteSetup_Load(object sender, EventArgs e)
        {
            // Init Grid
            gridFavList.InitDataSource();
            gridAllList.InitDataSource();

            // Bind All List
            if (BindAllList() == false)
            {

            }

            // Bind Fav List
            if (BindFavList(null) == false)
            {

            }

            // 다국어 변환
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// Add Favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFav_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridAllList.Selected.Rows.Count < 1)
                {
                    return;
                }

                // Add To Favorite List
                if (AddToFavorite() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Favorite List에서 제외 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFav_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridFavList.Selected.Rows.Count < 1)
                {
                    return;
                }
                
                // Add To Favorite List
                if (DeleteFromFavorite() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Favorite List에서 Function을 위로 올립니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFavUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridFavList.Selected.Rows.Count < 1)
                {
                    return;
                }

                if (FavoriteUp() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Favorite List에서 Function을 아래로 내립니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFavDown_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridFavList.Selected.Rows.Count < 1)
                {
                    return;
                }

                if (FavoriteDown() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 화면을 갱신합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (RefreshList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Bind Favorite Function List
        /// </summary>
        /// <returns></returns>
        private bool BindFavList(List<int> selectedRowIndex)
        {
            try
            {
                // Clear
                MPCF.FieldClear(gridFavList);

                // Favorite Menu 조회
                if (MPGV.gIMdiForm.GetFavFunctionList() == false)
                {
                    return false;
                }
                if (MPGV.galFavFunctionList == null || MPGV.galFavFunctionList.Count < 1)
                {
                    return false;
                }

                // Init
                int iArgs;
                List<TRSNode> func_list;
                MenuInfoTag menuInfo;
                UltraGridRow ugrRow;
                UltraGridCell ugrActiveCell = null;

                // Check Favorite Function List
                if (MPGV.galFavFunctionList[0] != null)
                {
                    func_list = ((TRSNode)MPGV.galFavFunctionList[0]).GetList(0);
                }
                else
                {
                    return false;
                }

                gridFavList.BeginUpdate();

                int iRowCount = 0;
                foreach (TRSNode node in func_list)
                {
                    // Validation
                    // Function code check
                    if (string.IsNullOrEmpty(node.GetString("FUNC_NAME")) == true)
                    {
                        continue;
                    }
                    // Menu Function check
                    if (string.IsNullOrEmpty(node.GetString("ASSEMBLY_FILE")) == true)
                    {
                        continue;
                    }

                    menuInfo = new MenuInfoTag();

                    menuInfo.s_func_name = node.GetString("FUNC_NAME");
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

                    ugrRow = gridFavList.DisplayLayout.Bands[0].AddNew();
                    ugrRow.Cells[0].Value = ++iRowCount;
                    ugrRow.Cells[1].Value = menuInfo.s_func_name;
                    ugrRow.Cells[2].Value = MPCF.FindLanguage(menuInfo.s_func_desc);
                    ugrRow.Tag = menuInfo;

                    if (selectedRowIndex != null && selectedRowIndex.Contains(iRowCount) == true)
                    {
                        ugrRow.Selected = true;
                        if (ugrActiveCell == null)
                        {
                            ugrActiveCell = ugrRow.Cells[2];
                        }
                    }
                }

                gridFavList.EndUpdate();

                gridFavList.UpdateData();

                gridFavList.ActiveCell = ugrActiveCell;

                if (gridFavList.ActiveCell == null)
                {
                    gridFavList.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
                else
                {
                    gridFavList.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Bind All Function List
        /// </summary>
        /// <returns></returns>
        private bool BindAllList()
        {
            try
            {
                // Clear
                MPCF.FieldClear(gridAllList);

                // All Menu 조회
                if (MPGV.gIMdiForm.GetAllFunctionList() == false)
                {
                    return false;
                }
                if (MPGV.galAllFunctionList == null || MPGV.galAllFunctionList.Count < 1)
                {
                    return false;
                }

                // Init
                int iArgs;
                List<TRSNode> func_list;
                MenuInfoTag menuInfo;
                UltraGridRow ugrRow;
                string s_tmp;
                Keys m_key;
                string s_key_string = string.Empty;

                gridAllList.BeginUpdate();

                // Check Favorite Function List
                if (MPGV.galAllFunctionList[0] != null)
                {
                    func_list = ((TRSNode)MPGV.galAllFunctionList[0]).GetList(0);
                }
                else
                {
                    return false;
                }

                foreach (TRSNode node in func_list)
                {
                    // Validation
                    // Function code check
                    if (string.IsNullOrEmpty(node.GetString("FUNC_NAME")) == true)
                    {
                        continue;
                    }
                    // Menu Function check
                    if (string.IsNullOrEmpty(node.GetString("ASSEMBLY_FILE")) == true)
                    {
                        continue;
                    }

                    menuInfo = new MenuInfoTag();

                    menuInfo.s_func_name = node.GetString("FUNC_NAME");
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

                    s_key_string = string.Empty;
                    if (node.GetString("SHORT_CUT").Length > 0)
                    {
                        m_key = (node.GetString("SHORT_CUT")[0] == 'C' ? Keys.Control : Keys.None);
                        m_key = m_key | (node.GetString("SHORT_CUT")[1] == 'A' ? Keys.Alt : Keys.None);
                        m_key = m_key | (node.GetString("SHORT_CUT")[2] == 'S' ? Keys.Shift : Keys.None);
                        s_tmp = node.GetString("SHORT_CUT").Substring(3);
                        if (s_tmp.Length > 1)
                        {
                            m_key = m_key | (Keys)((int)Keys.F1 + MPCF.ToInt(s_tmp.Substring(1)) - 1);
                        }
                        else
                        {
                            m_key = m_key | (Keys)((int)s_tmp[0]);
                        }
                        if (node.GetString("SHORT_CUT")[0] == 'C')
                        {
                            s_key_string += "Control";
                        }
                        if (node.GetString("SHORT_CUT")[1] == 'A')
                        {
                            if (s_key_string.Length > 1) s_key_string += "|";
                            s_key_string += "Alt";
                        }
                        if (node.GetString("SHORT_CUT")[2] == 'S')
                        {
                            if (s_key_string.Length > 1) s_key_string += "|";
                            s_key_string += "Shift";
                        }
                        if (s_key_string.Length > 1) s_key_string += "+";
                        s_key_string += s_tmp;
                    }

                    ugrRow = gridAllList.DisplayLayout.Bands[0].AddNew();
                    ugrRow.Cells[0].Value = menuInfo.s_func_name;
                    ugrRow.Cells[1].Value = MPCF.FindLanguage(menuInfo.s_func_desc);
                    ugrRow.Cells[2].Value = s_key_string;
                    ugrRow.Tag = menuInfo;
                }

                gridAllList.EndUpdate();

                gridAllList.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
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

        /// <summary>
        /// Favorite List에 Add 합니다.
        /// </summary>
        /// <returns></returns>
        private bool AddToFavorite()
        {
            try
            {
                // Init
                MenuInfoTag allListSelectedRow = new MenuInfoTag();
                int iFavSeqNum = 0;
                List<int> selectedRowIndex = new List<int>();

                for (int i = 0; i < gridAllList.Selected.Rows.Count; i++)
                {
                    // Validation
                    // Same Function Check
                    allListSelectedRow = (MenuInfoTag)gridAllList.Selected.Rows[i].Tag;

                    bool bFound = false;
                    foreach (UltraGridRow ugr in gridFavList.Rows)
                    {
                        if (ugr.Cells[1].Text == allListSelectedRow.s_func_name)
                        {
                            bFound = true;
                            selectedRowIndex.Add(ugr.Index + 1);
                            break;
                        }
                    }

                    if (bFound == true)
                    {
                        continue;
                    }                         

                    // Check Seq Num
                    if (gridFavList.Selected.Rows.Count < 1)
                    {
                        iFavSeqNum = gridFavList.Rows.Count + 1 + i;
                    }
                    else
                    {
                        iFavSeqNum = gridFavList.Selected.Rows[0].Index + 1 + i;
                    }

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_CREATE, iFavSeqNum, allListSelectedRow) == false)
                    {
                        return false;
                    }

                    selectedRowIndex.Add(iFavSeqNum);
                }

                // Refresh
                if (BindFavList(selectedRowIndex) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Favorite List에서 delete 합니다.
        /// </summary>
        /// <returns></returns>
        private bool DeleteFromFavorite()
        {
            try
            {
                for (int i = 0; i < gridFavList.Selected.Rows.Count; i++)
                {
                    // Init
                    MenuInfoTag favListSelectedRow = (MenuInfoTag)gridFavList.Rows[gridFavList.Selected.Rows[i].Index].Tag;
                    int iFavSeqNum = gridFavList.Selected.Rows[i].Index + 1 - i;

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_DELETE, iFavSeqNum, favListSelectedRow) == false)
                    {
                        return false;
                    }
                }

                // Refresh
                if (BindFavList(null) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Favorite List에서 순서를 위로 올립니다.
        /// </summary>
        /// <returns></returns>
        private bool FavoriteUp()
        {
            try
            {
                // Init
                MenuInfoTag favListSelectedRow = new MenuInfoTag();
                int iFavSeqNum = 0;
                List<int> selectedRowIndex = new List<int>();

                for (int i = 0; i < gridFavList.Selected.Rows.Count; i++)
                {
                    // Init
                    favListSelectedRow = (MenuInfoTag)gridFavList.Rows[gridFavList.Selected.Rows[i].Index].Tag;
                    iFavSeqNum = gridFavList.Selected.Rows[i].Index + 1;

                    if (iFavSeqNum <= 1)
                    {
                        selectedRowIndex.Add(1);
                        break;
                    }

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_DELETE, iFavSeqNum, favListSelectedRow) == false)
                    {
                        return false;
                    }

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_CREATE, iFavSeqNum - 1, favListSelectedRow) == false)
                    {
                        return false;
                    }

                    selectedRowIndex.Add(iFavSeqNum - 1);
                }

                // Refresh
                if (BindFavList(selectedRowIndex) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Favorite List에서 순서를 아래로 내립니다.
        /// </summary>
        /// <returns></returns>
        private bool FavoriteDown()
        {
            try
            {
                // Init
                MenuInfoTag favListSelectedRow = new MenuInfoTag();
                int iFavSeqNum = 0;
                List<int> selectedRowIndex = new List<int>();

                for (int i = gridFavList.Selected.Rows.Count- 1; i >= 0; i--)
                {
                    // Init
                    favListSelectedRow = (MenuInfoTag)gridFavList.Rows[gridFavList.Selected.Rows[i].Index].Tag;
                    iFavSeqNum = gridFavList.Selected.Rows[i].Index + 1;

                    if (gridFavList.Selected.Rows[gridFavList.Selected.Rows.Count - 1].Index + 1 >= gridFavList.Rows.Count)
                    {
                        for (int j = 0; j < gridFavList.Selected.Rows.Count; j++)
                        {
                            selectedRowIndex.Add(gridFavList.Selected.Rows[j].Index +1);
                        }
                        break;
                    }

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_DELETE, iFavSeqNum, favListSelectedRow) == false)
                    {
                        return false;
                    }

                    // Update Favorite
                    if (UpdateFavorite(MPGC.MP_STEP_CREATE, iFavSeqNum + 1, favListSelectedRow) == false)
                    {
                        return false;
                    }

                    selectedRowIndex.Add(iFavSeqNum + 1);
                }

                // Refresh
                if (BindFavList(selectedRowIndex) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 즐겨찾기 등록/해제 합니다.
        /// </summary>
        private bool UpdateFavorite(char cStep, int iFavSeqNum, MenuInfoTag tag)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_FUNCTION_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_FUNCTION_LIST_OUT");

                MPCF.SetInMsg(in_node);

                in_node.ProcStep = cStep;
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", tag.s_func_name);
                in_node.AddString("USER_FUNC_DESC", tag.s_func_desc);
                in_node.AddInt("SEQ_NUM", iFavSeqNum);

                if (MPCF.CallService("SEC", "SEC_Update_Favorites", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Opened Form Check
                if (MPGV.glOpenChildForm.Count > 0)
                {
                    for (int i = 0; i < MPGV.glOpenChildForm.Count; i++)
                    {
                        if (MPGV.glOpenChildForm[i] is SOIBaseForm02)
                        {
                            if (cStep == MPGC.MP_STEP_CREATE)
                            {
                                ((SOIBaseForm02)MPGV.glOpenChildForm[i]).SetFavorite(true);
                            }
                            else
                            {
                                ((SOIBaseForm02)MPGV.glOpenChildForm[i]).SetFavorite(false);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 재조회 합니다.
        /// </summary>
        /// <returns></returns>
        public bool RefreshList()
        {
            try
            {
                // Bind All List
                if (BindAllList() == false)
                {
                    return false;
                }

                // Bind Fav List
                if (BindFavList(null) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
