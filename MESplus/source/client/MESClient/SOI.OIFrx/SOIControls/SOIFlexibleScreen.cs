using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Miracom.TRSCore;
using System.IO;
using System.Globalization;
using FarPoint.Win.Spread;

using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIFlexibleScreen : UserControl
    {
        #region Property

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        private bool _listCellCopy = true; // Rule에 의해 List Data를 Bind하는 경우, 기준 Cell info를 복사할지 여부
        public bool _ListCellCopy
        {
            get
            {
                return _listCellCopy;
            }
            set
            {
                _listCellCopy = value;
            }
        }

        private string ms_screen_id;
        private string ms_previous_screen_id;
        private bool mb_auto_stretch;
        private bool mb_screen_locked;
        private string ms_owner_func_name;

        private string ms_lot_id;
        private char mc_proc_step;
        private string ms_mat_id;
        private int mi_mat_ver;
        private string ms_flow;
        private int mi_flow_seq_num;
        private string ms_oper;
        private string ms_res_id;
        private string ms_res_type;
        private string ms_res_group;

        private string ms_base_path = MOGV.gsFlexibleScreenLocalPath;
        private Hashtable mh_screen_map = new Hashtable(); // 화면에 정의된 예약어($~)를 중복없이 저장하기 위한 용도 (ex. $LOT_ID)
        private Hashtable mh_data_map = new Hashtable(); // out_node에 member를 저장하기 위한 용도 (ex. LOT_ID)

        private string ms_loaded_service_name;
        private string ms_loaded_module_name;

        private List<string> mls_flexheader_members = new List<string>();

        public string ScreenID
        {
            get 
            { 
                return ms_screen_id; 
            }
            set 
            { 
                ms_screen_id = value; 
            }
        }
        public string OwnerFuncName
        {
            get { return ms_owner_func_name; }
            set { ms_owner_func_name = value; }
        }

        public bool ScreenAutoStretch
        {
            get
            {
                return mb_auto_stretch;
            }
            set
            {
                mb_auto_stretch = value;
            }
        }
        public bool ScreenLock
        {
            get
            {
                return mb_screen_locked;
            }
            set
            {
                mb_screen_locked = value;

                if (spdSpread.ActiveSheet.Protect == false)
                {
                    spdSpread.ActiveSheet.Protect = true;
                }

                spdSpread.ActiveSheet.DefaultStyle.Locked = mb_screen_locked;
            }
        }

        public Color ScreenLockBackColor
        {
            get 
            {
                return spdSpread.ActiveSheet.LockBackColor; 
            }
            set 
            {
                spdSpread.ActiveSheet.LockBackColor = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FarPoint.Win.Spread.FpSpread ScreenSpread
        {
            get
            {
                return spdSpread;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FarPoint.Win.Spread.SheetView ScreenView
        {
            get
            {
                return spdSpread.ActiveSheet;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FarPoint.Win.Spread.CellHorizontalAlignment ScreenHorizontalAlignment
        {
            get
            {
                return spdSpread.ActiveSheet.DefaultStyle.HorizontalAlignment;
            }
            set
            {
                spdSpread.ActiveSheet.DefaultStyle.HorizontalAlignment = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FarPoint.Win.Spread.CellVerticalAlignment ScreenVerticalAlignment
        {
            get
            {
                return spdSpread.ActiveSheet.DefaultStyle.VerticalAlignment;
            }
            set
            {
                spdSpread.ActiveSheet.DefaultStyle.VerticalAlignment = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LotID
        {
            get 
            { 
                return ms_lot_id; 
            }
            set 
            { 
                ms_lot_id = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ProcStep
        {
            get 
            { 
                return mc_proc_step; 
            }
            set 
            { 
                mc_proc_step = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatID
        {
            get 
            { 
                return ms_mat_id; 
            }
            set 
            { 
                ms_mat_id = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MatVer
        {
            get 
            { 
                return mi_mat_ver; 
            }
            set 
            { 
                mi_mat_ver = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Flow
        {
            get 
            { 
                return ms_flow; 
            }
            set 
            { 
                ms_flow = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FlowSeqNum
        {
            get 
            { 
                return mi_flow_seq_num; 
            }
            set 
            { 
                mi_flow_seq_num = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Oper
        {
            get
            { 
                return ms_oper; 
            }
            set 
            { 
                ms_oper = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResID
        {
            get 
            { 
                return ms_res_id;
            }
            set 
            {
                ms_res_id = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResType
        {
            get 
            { 
                return ms_res_type;
            }
            set 
            { 
                ms_res_type = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResGroup
        {
            get 
            { 
                return ms_res_group; 
            }
            set 
            { 
                ms_res_group = value; 
            }
        }

        public enum TableMatrix
        {
            COLUMN = 0,
            ROW = 1
        }

        private struct VALUE_TAG
        {
            public string Name;
            public TRSDataType DataType;
            public ArrayList Values;
        }

        private struct FILE_TAG
        {
            public string FileName;
            public byte[] FileData;
        }

        /// <summary>
        /// Cell Click Event Handler
        /// </summary>
        public event FarPoint.Win.Spread.CellClickEventHandler Spread_CellClick
        {
            add
            {
                spdSpread.CellClick += value;
            }
            remove
            {
                spdSpread.CellClick -= value;
            }
        }

        #endregion

        #region Constructor

        public SOIFlexibleScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Spread Resize Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdSpread_Resize(object sender, EventArgs e)
        {
            try
            {
                // 1. 자동 크기 조절을 설정하였는지 여부 체크
                if (mb_auto_stretch == false)
                {
                    return;
                }

                // 2. 전체 컬럼길이와 화면길이를 비교하여 Widh 조절
                int i;
                float f_width;

                f_width = 0;
                for (i = 0; i < spdSpread.ActiveSheet.ColumnCount; i++)
                {
                    f_width += spdSpread.ActiveSheet.Columns[i].Width;
                }
                for (i = 0; i < spdSpread.ActiveSheet.RowHeader.ColumnCount; i++)
                {
                    f_width += spdSpread.ActiveSheet.RowHeader.Columns[i].Width;
                }

                // 20은 스크롤바크기
                if (f_width + 20 <= this.Width)
                {
                    f_width = this.Width - f_width - 20;
                    f_width = f_width / spdSpread.ActiveSheet.ColumnCount;

                    for (i = 0; i < spdSpread.ActiveSheet.ColumnCount; i++)
                    {
                        spdSpread.ActiveSheet.Columns[i].Width += f_width;
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Spread Cell Double Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                clsScreenInfo screen_info;
                FILE_TAG file;
                FileInfo finfo;
                BinaryReader br;

                if ((screen_info = GetInputCellInfo(e.Row, e.Column)) == null)
                {
                    return;
                }

                if (screen_info.InputFlag == false)
                {
                    return;
                }

                if (screen_info.CellType != FSCREEN_CELL_TYPE.IMAGE
                    && screen_info.CellType != FSCREEN_CELL_TYPE.HYPERLINK)
                {
                    return;
                }

                if (mb_screen_locked == true)
                {
                    return;
                }

                ofdFile.FileName = "";
                if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE)
                {
                    ofdFile.Filter = "JPEG File(*.jpg)|*.jpg";
                }
                else if (screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                {
                    ofdFile.Filter = "All File(*.*)|*.*";
                }

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE)
                    {
                        spdSpread.ActiveSheet.Cells[e.Row, e.Column].Value = Image.FromFile(ofdFile.FileName);
                    }
                    else if (screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                    {
                        FarPoint.Win.Spread.CellType.HyperLinkCellType cell_type;
                        cell_type = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
                        cell_type.Link = ofdFile.FileName;
                        cell_type.Text = ofdFile.SafeFileName;
                        cell_type.LinkArea = new LinkArea(0, ofdFile.SafeFileName.Length);
                        spdSpread.ActiveSheet.Cells[e.Row, e.Column].CellType = cell_type;
                    }

                    file = new FILE_TAG();
                    file.FileName = ofdFile.SafeFileName;

                    finfo = new FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                    {
                        try
                        {
                            br = new BinaryReader(finfo.OpenRead());
                            file.FileData = br.ReadBytes((int)finfo.Length);
                            br.Close();
                        }
                        catch (Exception)
                        {
                            // A fatal error occurred during opening a file.
                            MPOF.ShowMsgBox(MPOF.GetMessage(361));
                        }

                        spdSpread.ActiveSheet.Cells[e.Row, e.Column].Tag = file;
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 공통 속성
                this.spdSpread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // 공통 색상
                this.spdSpread.BackColor = MOGV.gTheme.SpreadBackground;
                if (this.spdSpread.Sheets.Count > 0)
                {
                    //this.spdSpread.Sheets[0].ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
                    this.spdSpread.Sheets[0].GrayAreaBackColor = MOGV.gTheme.SpreadBackground;

                    this.spdSpread.Sheets[0].ColumnHeader.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.spdSpread.Sheets[0].ColumnHeader.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.spdSpread.Sheets[0].ColumnHeader.DefaultStyle.Font = new System.Drawing.Font(this.spdSpread.Font.FontFamily, this.spdSpread.Font.Size, System.Drawing.FontStyle.Bold);
                    this.spdSpread.Sheets[0].ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.spdSpread.Sheets[0].ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    //this.spdSpread.Sheets[0].ColumnHeader.Rows[0].Height = 30;

                    this.spdSpread.Sheets[0].RowHeader.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.spdSpread.Sheets[0].RowHeader.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.spdSpread.Sheets[0].RowHeader.DefaultStyle.Font = new System.Drawing.Font(this.spdSpread.Font.FontFamily, this.spdSpread.Font.Size, System.Drawing.FontStyle.Bold);
                    this.spdSpread.Sheets[0].RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.spdSpread.Sheets[0].RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    //if (this.spdSpread.Sheets[0].Rows.Count > 0)
                    //{
                    //    this.spdSpread.Sheets[0].RowHeader.Rows[0].Height = 25;
                    //}

                    this.spdSpread.Sheets[0].SheetCorner.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.spdSpread.Sheets[0].SheetCorner.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.spdSpread.Sheets[0].SheetCorner.DefaultStyle.Font = new System.Drawing.Font(this.spdSpread.Font.FontFamily, this.spdSpread.Font.Size, System.Drawing.FontStyle.Bold);
                    this.spdSpread.Sheets[0].SheetCorner.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.spdSpread.Sheets[0].SheetCorner.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    this.spdSpread.Sheets[0].DefaultStyle.BackColor = MOGV.gTheme.FlexibleScreenBackground;
                    this.spdSpread.Sheets[0].DefaultStyle.ForeColor = MOGV.gTheme.FlexibleScreenCellForeground;
                    this.spdSpread.Sheets[0].DefaultStyle.Font = new System.Drawing.Font(this.spdSpread.Font.FontFamily, this.spdSpread.Font.Size, System.Drawing.FontStyle.Regular);
                    this.spdSpread.Sheets[0].HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.spdSpread.Sheets[0].VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    this.spdSpread.Sheets[0].SelectionBackColor = MOGV.gTheme.SpreadRowSelectedBackground;

                    //this.spdSpread.Sheets[0].RowChanged += new SheetViewEventHandler(spdSpread_RowChanged);
                }
                if (this.spdSpread.HorizontalScrollBar != null
                    && this.spdSpread.HorizontalScrollBar.Renderer != null
                    && this.spdSpread.HorizontalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ArrowColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ArrowHoveredColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ArrowSelectedColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonHoveredBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonHoveredBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).ButtonSelectedBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).TrackBarBackgroundColor = MOGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.HorizontalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                }
                if (this.spdSpread.VerticalScrollBar != null
                    && this.spdSpread.VerticalScrollBar.Renderer != null
                    && this.spdSpread.VerticalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ArrowColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ArrowHoveredColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ArrowSelectedColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonHoveredBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonHoveredBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).ButtonSelectedBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).TrackBarBackgroundColor = MOGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.spdSpread.VerticalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                }
                if (this.spdSpread.Skin != null
                    && this.spdSpread.Skin.InterfaceRenderer != null
                    && this.spdSpread.Skin.InterfaceRenderer is EnhancedInterfaceRenderer)
                {
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).ScrollBoxBackgroundColor = MOGV.gTheme.SpreadBackground;
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).SplitBoxBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).SplitBoxBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).SplitBarBackgroundColor = MOGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).SplitBarDarkColor = MOGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.spdSpread.Skin.InterfaceRenderer).SplitBarLightColor = MOGV.gTheme.SpreadCellBorder;
                }
            }
        }

        /// <summary>
        /// 스프레드 디자인에서 매크로를 탐색한다.
        /// 각 셀별로 지정된 텍스트를 screen_map에 저장한다.
        /// Key : cell path (cell text)
        /// Value : clsScreenInfo (cell position 등...)
        /// </summary>
        /// <returns>true or false</returns>
        private bool ScanScreen()
        {
            int i_row, i_col;
            string s_value = string.Empty;
            char[] c_delimiter = { '=', '>', '.' };

            try
            {
                // screen_map 초기화
                mh_screen_map.Clear();

                // 데이터가 없는 경우 종료
                if (spdSpread.ActiveSheet.RowCount == 0
                    || spdSpread.ActiveSheet.ColumnCount == 0)
                {
                    return false;
                }

                // 모든 Cell에 대해
                for (i_row = spdSpread.ActiveSheet.RowCount - 1; i_row >= 0; i_row--)
                {
                    for (i_col = 0; i_col < spdSpread.ActiveSheet.ColumnCount; i_col++)
                    {
                        // Get Cell Text 
                        s_value = spdSpread.ActiveSheet.Cells[i_row, i_col].Text;

                        // 설정된 값이 없는 경우 스킵
                        if (s_value == "")
                        {
                            continue;
                        }

                        clsScreenInfo screen_info = new clsScreenInfo();

                        // $= Macro Rule인 경우
                        if (s_value.IndexOf("$=") > -1)
                        {
                            screen_info.MacroRule = clsScreenInfo.MACRO_RULE.COLUMN_RULE;
                        }
                        // $> Macro Rule인 경우
                        else if (s_value.IndexOf("$>") > -1)
                        {
                            screen_info.MacroRule = clsScreenInfo.MACRO_RULE.ROW_RULE;
                        }
                        // $MemberName$ Macro Rule인 경우
                        else if (s_value.EndsWith("$") == true)
                        {
                            screen_info.MacroRule = clsScreenInfo.MACRO_RULE.FULL_RULE;
                        }
                        // Macro Rule이 없는 경우
                        else if (s_value.IndexOf("$") > -1)
                        {
                            screen_info.MacroRule = clsScreenInfo.MACRO_RULE.NO_RULE;
                        }
                        else
                        {   // Macro가 아닌 데이터의 경우
                            continue;
                        }

                        screen_info.Path = s_value.Replace('.', '/');
                        screen_info.Path = screen_info.Path.Replace("$", "");
                        screen_info.Path = screen_info.Path.Substring(screen_info.Path.LastIndexOfAny(c_delimiter) + 1);    //c_delimiter = {'=', '>', '.'}
                        screen_info.MemberName = s_value.Substring(s_value.LastIndexOfAny(c_delimiter) + 1);                //c_delimiter = {'=', '>', '.'}

                        // screen_map에 없는 경우
                        if (mh_screen_map.Contains(screen_info.Path) == false)
                        {
                            // Cell Position 설정
                            screen_info.ValueCells.Add(new clsScreenInfo.Position(i_row, i_col));

                            // Add
                            mh_screen_map.Add(screen_info.Path, screen_info);
                        }
                        else
                        {
                            // 동일 path 검색
                            clsScreenInfo item = (clsScreenInfo)mh_screen_map[screen_info.Path];

                            // Position 추가
                            item.ValueCells.Add(new clsScreenInfo.Position(i_row, i_col));

                            // 교체
                            mh_screen_map[screen_info.Path] = item;
                        }

                        spdSpread.ActiveSheet.Cells[i_row, i_col].Text = "";
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 서버로부터 가져온 디자인 파일을 Client 저장 경로에 저장한다.
        /// </summary>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool UpdateScreenXML(TRSNode out_node, string s_screen_id)
        {
            try
            {
                string sPath = ms_base_path + s_screen_id;

                FileStream fs = File.Open(sPath + ".gzip", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] buffer;
                //DateTime dt_create_time;
                fs.Flush();
                buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2);
                bw.Write(buffer);
                bw.Close();
                fs.Close();

                //dt_create_time = MPOF.ToDate(out_node.GetString("CREATION_TIME"));
                //File.SetCreationTime(sPath + ".gzip", dt_create_time);

                //MPOF.ZipDecompress(sPath);
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Screen ID에 설정되어 있는 서비스 이름을 가져온다.
        /// </summary>
        /// <returns></returns>
        private bool LoadServiceName()
        {
            TRSNode in_node = new TRSNode("LOAD_SERVICE_NAME_IN");
            TRSNode out_node = new TRSNode("LOAD_SERVICE_NAME_OUT");

            try
            {
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", ms_screen_id);

                if (MPCR.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                ms_loaded_service_name = out_node.GetString("SERVICE_NAME");
                ms_loaded_module_name = out_node.GetString("MODULE_NAME");

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Screen ID에 설정되어 있는 서비스의 멤버를 가져온다. Flexible Header에 정의되어 있는 멤버를 가져옴
        /// </summary>
        /// <returns></returns>
        private bool LoadServiceMember()
        {
            TRSNode in_node = new TRSNode("VIEW_FLEXIBLE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLEXIBLE_LIST_OUT");
            int i;

            try
            {
                LoadServiceName();

                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SERVICE_NAME", ms_loaded_service_name);
                in_node.AddString("USER_ID", MOGV.gsUserID);

                do
                {
                    if (MPCR.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("HEADER_LIST").Count; i++)
                    {
                        mls_flexheader_members.Add(out_node.GetList("HEADER_LIST")[i].GetString("MEMBER_PATH"));
                    }

                    in_node.SetInt("NEXT_MEMBER_SEQ", out_node.GetInt("NEXT_MEMBER_SEQ"));

                } while (in_node.GetInt("NEXT_MEMBER_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 관계 설정을 탐색하여 Screen ID를 가져온다
        /// </summary>
        /// <returns></returns>
        private bool ViewScreenID()
        {
            TRSNode in_node = new TRSNode("Get_Screen_ID_IN");
            TRSNode out_node = new TRSNode("Get_Screen_ID_OUT");

            try
            {
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = mc_proc_step;

                in_node.AddString("LOT_ID", ms_lot_id);
                in_node.AddString("MAT_ID", ms_mat_id);
                in_node.AddInt("MAT_VER", mi_mat_ver);
                in_node.AddString("FLOW", ms_flow);
                in_node.AddString("FLOW_SEQ_NUM", mi_flow_seq_num);
                in_node.AddString("OPER", ms_oper);
                in_node.AddString("RES_ID", ms_res_id);
                in_node.AddString("RES_TYPE", ms_res_type);
                in_node.AddString("RESG_ID", ms_res_group);

                if (MPCR.CallService("BAS", "BAS_Process_Flexible_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("EXIST_ID") == 'Y')
                {
                    ms_screen_id = out_node.GetString("SCREEN_ID");
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 관계 설정을 탐색하여 Screen ID를 가져온다
        /// 찾고자하는 화면명(Func_name)으로 Screen ID를 GCM 테이블에서 조회한다.
        /// </summary>
        /// <returns></returns>
        private bool ViewScreenID(string funcName)
        {
            TRSNode in_node = new TRSNode("Get_Screen_ID_IN");
            TRSNode out_node = new TRSNode("Get_Screen_ID_OUT");

            try
            {
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = mc_proc_step;

                in_node.AddString("TABLE_NAME", MPOF.Trim(MOGC.MP_GCM_BAS_SCREEN_REL));
                in_node.AddString("KEY_1", MPOF.Trim(funcName));
                
                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.ListCount > 0)
                {
                    if(out_node.GetList(0).Count > 0)
                    {
                        ms_screen_id = out_node.GetList(0)[0].GetString("DATA_1");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Node에 담긴 데이터를 data_map에 저장한다.
        /// Key : member path
        /// Value : member value
        /// </summary>
        /// <param name="node">스프레드에 맵핑할 데이터</param>
        private void DataMapping(TRSNode node)
        {
            int i, k;
            string s_path;
            VALUE_TAG value_info;

            // 멤버 데이터가 존재하는 경우
            if (node.MemberCount > 0)
            {
                // node의 memeber 수만큼
                for (i = 0; i < node.MemberCount; i++)
                {
                    // Framework관련 멤버는 스킵
                    s_path = node.GetMember(i).GetPath();
                    if (s_path == TRSDefine.OUT_MSGCODE
                        || s_path == TRSDefine.OUT_MSG
                        || s_path == TRSDefine.OUT_MSGCATE
                        || s_path == TRSDefine.OUT_STATUSVALUE)
                    {
                        continue;
                    }

                    // data_map Key : member path
                    // data_map Value : member value
                    if (mh_data_map.Contains(s_path) == true)
                    {
                        value_info = (VALUE_TAG)mh_data_map[s_path];
                        value_info.Values.Add(node.GetMember(i).Value);

                        mh_data_map[s_path] = value_info;
                    }
                    else
                    {
                        value_info = new VALUE_TAG();
                        value_info.Values = new ArrayList();

                        value_info.Values.Add(node.GetMember(i).Value);
                        value_info.DataType = node.GetMember(i).ValueType;
                        value_info.Name = node.GetMember(i).Name;

                        mh_data_map.Add(s_path, value_info);
                    }
                }
            }

            // 리스트 데이터가 존재하는 경우
            if (node.ListCount > 0)
            {
                for (i = 0; i < node.ListCount; i++)
                {
                    for (k = 0; k < node.GetList(i).Count; k++)
                    {
                        // 재귀호출
                        // data_map Key : member path
                        // data_map Value : member value
                        DataMapping(node.GetList(i)[k]);
                    }
                }
            }
            
        }

        /// <summary>
        /// Before List Data Binding, Copy Previous Cell Information.
        /// </summary>
        private void CopyCellInfo(int fromCellRowIndex, int fromCellColIndex, int toCellRowIndex, int toCellColIndex)
        {
            if (_listCellCopy == true)
            {
                // Cell fomatting, align, etc...
                spdSpread.ActiveSheet.CopyRange(fromCellRowIndex, fromCellColIndex, toCellRowIndex, toCellColIndex, 1, 1, false);

                // Cell width and Height
                if(fromCellRowIndex == toCellRowIndex && fromCellColIndex != toCellColIndex)
                {
                    spdSpread.ActiveSheet.Columns[toCellColIndex].Width = spdSpread.ActiveSheet.Columns[fromCellColIndex].Width;
                }
                else if (fromCellColIndex == toCellColIndex && fromCellRowIndex != toCellRowIndex)
                {
                    spdSpread.ActiveSheet.Rows[toCellRowIndex].Height = spdSpread.ActiveSheet.Rows[fromCellRowIndex].Height;
                }
                else if (fromCellRowIndex != toCellRowIndex && fromCellColIndex != toCellColIndex)
                {
                    spdSpread.ActiveSheet.Columns[toCellColIndex].Width = spdSpread.ActiveSheet.Columns[fromCellColIndex].Width;
                    spdSpread.ActiveSheet.Rows[toCellRowIndex].Height = spdSpread.ActiveSheet.Rows[fromCellRowIndex].Height;
                }
            }
        }

        /// <summary>
        /// Fill the data to spread sheet
        /// </summary>
        /// <param name="Row">Row position of spread cell</param>
        /// <param name="Column">Column position of spread cell</param>
        /// <param name="Name">Member Name</param>
        /// <param name="Type">Member Data type</param>
        /// <param name="Value">Member value</param>
        private void FillDatatoScreen(int Row, int Column, string Name, TRSDataType Type, string Value)
        {
            switch (Type)
            {
                // 정수 (Number Cell Type)
                case TRSDataType.Int:
                case TRSDataType.Long:
                    if (spdSpread.ActiveSheet.Cells[Row, Column].CellType == null)
                    {
                        FarPoint.Win.Spread.CellType.NumberCellType IntCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        IntCellType.DecimalPlaces = 0;
                        spdSpread.ActiveSheet.Cells[Row, Column].CellType = IntCellType;
                    }
                    spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    break;
                // 실수 (Number Cell Type)
                case TRSDataType.Double:
                case TRSDataType.Float:
                    if (spdSpread.ActiveSheet.Cells[Row, Column].CellType == null)
                    {
                        FarPoint.Win.Spread.CellType.NumberCellType FloatCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        FloatCellType.DecimalPlaces = 0;
                        if (MPOF.ToDbl(Value) - MPOF.ToInt(Value) > 0.0005)
                        {
                            FloatCellType.DecimalPlaces = 3;
                        }
                        spdSpread.ActiveSheet.Cells[Row, Column].CellType = FloatCellType;
                    }
                    spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    break;
                // 시간 또는 날짜 (MaskCellType)
                // 문자 (변경안함)
                case TRSDataType.Char:
                case TRSDataType.String:
                    /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
                    if ((Name.Contains("TIME") || Name.Contains("DATE")) &&
                        MPOF.CheckNumeric(Value) &&
                        ((Value.Length == 14) || (Value.Length == 8) || (Value.Length == 6)))
                    {
                        if (spdSpread.ActiveSheet.Cells[Row, Column].CellType == null)
                        {
                            string s_date_sep = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator;
                            string s_time_sep = System.Globalization.DateTimeFormatInfo.CurrentInfo.TimeSeparator;

                            FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                            if (Value.Length == 6)
                            {
                                MaskCellType.Mask = "##" + s_time_sep + "##" + s_time_sep + "##";
                            }
                            else if (Value.Length == 8)
                            {
                                MaskCellType.Mask = "####" + s_date_sep + "##" + s_date_sep + "##";
                            }
                            else
                            {
                                MaskCellType.Mask = "####" + s_date_sep + "##" + s_date_sep + "## ##" + s_time_sep + "##" + s_time_sep + "##";
                            }

                            spdSpread.ActiveSheet.Cells[Row, Column].CellType = MaskCellType;
                        }
                        spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    }
                    else
                    {
                        spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    }

                    break;
            }
        }

        /// <summary>
        /// Set the data to TRS Node
        /// </summary>
        /// <param name="MemberName">Service member name</param>
        /// <param name="Type">Data type</param>
        /// <param name="Value">Data value</param>
        /// <param name="Value">Data value</param>
        private void SetDataToNode(ref TRSNode in_node, string MemberName, TRSDataType Type, object Value)
        {
            switch (Type)
            {
                case TRSDataType.Int:
                    in_node.AddInt(MemberName, MPOF.ToInt(Value));
                    break;
                case TRSDataType.Long:
                    in_node.AddLong(MemberName, Convert.ToInt64(Value));
                    break;
                case TRSDataType.Double:
                    in_node.AddDouble(MemberName, MPOF.ToDbl(Value));
                    break;
                case TRSDataType.Float:
                    in_node.AddFloat(MemberName, MPOF.ToDbl(Value));
                    break;
                case TRSDataType.Char:
                    in_node.AddChar(MemberName, MPOF.ToChar(Value));
                    break;
                case TRSDataType.String:
                    in_node.AddString(MemberName, Value.ToString());
                    break;
                case TRSDataType.Datetime:
                    in_node.AddDatetime(MemberName, Convert.ToDateTime(Value));
                    break;
            }
        }

        /// <summary>
        /// Get Input Cell Info
        /// </summary>
        /// <param name="i_row"></param>
        /// <param name="i_col"></param>
        /// <returns></returns>
        private clsScreenInfo GetInputCellInfo(int i_row, int i_col)
        {
            try
            {
                clsScreenInfo screen_info;

                if (mh_screen_map == null)
                {
                    return null;
                }

                foreach (string s_key_path in mh_screen_map.Keys)
                {
                    screen_info = (clsScreenInfo)mh_screen_map[s_key_path];

                    if (screen_info.InputFlag == false)
                    {
                        continue;
                    }

                    for (int i = 0; i < screen_info.ValueCells.Count; i++)
                    {
                        if (screen_info.ValueCells[i].Row == i_row && screen_info.ValueCells[i].Column == i_col)
                        {
                            return screen_info;
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 설정된 Screen ID의 스프레드 디자인을 읽어온다.
        /// </summary>
        /// <returns></returns>
        public bool LoadDesign()
        {
            try
            {
                if (ms_screen_id == null || ms_screen_id == "")
                {
#if _H101
                    // Relation에 정의된 Screen ID있는지 확인
                    if (ViewScreenID() == false) return false;
#endif
#if _Http
                    // GCM에 정의된 Screen ID있는지 확인
                    if (ViewScreenID(ms_owner_func_name) == false)
                    {
                        return false;
                    }
#endif

                    if (ms_screen_id == null || ms_screen_id == "")
                    {
                        MPOF.ShowMsgBox(MPOF.GetMessage(313));
                        return false;
                    }
                }

                if (LoadDesign(ms_screen_id) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Load Design By Screen ID
        /// </summary>
        /// <param name="s_screen_id"></param>
        /// <returns></returns>
        public bool LoadDesign(string s_screen_id)
        {
            string sPathZip;
            string sPathXML;
            string sCreateTime;
            bool b_upgraded;

            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Screen_IN");
            TRSNode out_node = new TRSNode("View_Screen_OUT");

            try
            {
                if (s_screen_id == null
                    || s_screen_id == "")
                {
                    // Cannot find screen ID. Please check flexible screen relation or default screen ID.
                    MPOF.ShowMsgBox(MPOF.GetMessage(313));
                    return false;
                }

                sPathZip = ms_base_path + s_screen_id + ".gzip";

                if (Directory.Exists(ms_base_path) == false)
                {
                    Directory.CreateDirectory(ms_base_path);
                }

                FileInfo fi = new FileInfo(sPathZip);

                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", s_screen_id);

                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19011231010000");
                    in_node.AddInt("FILE_SIZE", 0);
                }
                else
                {
                    if (fi.CreationTime == null || fi.CreationTime.Year < 1900)
                    {
                        sCreateTime = "19011231010000";
                    }
                    else
                    {
                        create_time = fi.CreationTime;
                      //  sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }

                    iFileSize = fi.Length;

                  //  in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }

                if (MPCR.CallService("BAS", "BAS_Check_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                b_upgraded = false;
                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateScreenXML(out_node, s_screen_id);
                    b_upgraded = true;
                }

                if (ms_previous_screen_id != s_screen_id
                    || b_upgraded == true
                    || spdSpread.ActiveSheet.RowCount < 1
                    || spdSpread.ActiveSheet.ColumnCount < 1)
                {
                    sPathXML = ms_base_path + s_screen_id + ".xml";
                    spdSpread.Open(sPathXML);

                    this.SetOITheme();

                    //MPCF.ConvertMessage(this.Controls);
                    MPOF.ConvertCaption(this);

                    if (ScanScreen() == false)
                    {
                        // Failed to scan the screen macro.
                        MPOF.ShowMsgBox(MPOF.GetMessage(314));
                        return false;
                    }
                }

                ms_screen_id = s_screen_id;
                ms_previous_screen_id = ms_screen_id;

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <returns></returns>
        public bool SetServiceData(TRSNode in_node)
        {
            return this.SetServiceData(in_node, false);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="out_node">서비스 결과가 들어갈 Output 노드</param>
        /// <returns></returns>
        public bool SetServiceData(TRSNode in_node, ref TRSNode out_node)
        {
            return this.SetServiceData(in_node, ref out_node, false);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="b_ignore_err">서비스 진행시 발생된 에러 처리 방식 결정. true면 무시</param>
        /// <returns></returns>
        public bool SetServiceData(TRSNode in_node, bool b_ignore_err)
        {
            TRSNode out_node = new TRSNode("SERVICE_DATA_OUT");

            return this.SetServiceData(in_node, ref out_node, b_ignore_err);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="out_node">서비스 결과가 들어갈 Output 노드</param>
        /// <param name="b_ignore_err">서비스 진행시 발생된 에러 처리 방식 결정. true면 무시</param>
        /// <returns></returns>
        public bool SetServiceData(TRSNode in_node, ref TRSNode out_node, bool b_ignore_err)
        {
            try
            {
                // Find Service Name
                if (LoadServiceName() == false)
                {
                    return false;
                }

                // Call Service
                if (MPCR.CallService(ms_loaded_module_name, ms_loaded_service_name, in_node, ref out_node, b_ignore_err) == false)
                {
                    return false;
                }

                // Data To Screen Mapping
                if (SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Node에 담긴 데이터를 스프레드에 입력한다.
        /// </summary>
        /// <param name="out_node">스프레드에 입력할 데이터</param>
        /// <returns></returns>
        public bool SetDataToScreen(TRSNode out_node)
        {
            int i, k;
            clsScreenInfo screen_info;
            VALUE_TAG value_info;
            List<TRSNode> list_items;
            Hashtable col_rule_screen_map;

            try
            {
                // 디자인 로드
                if (ms_screen_id == null 
                    || ms_screen_id == "" 
                    || ms_previous_screen_id != ms_screen_id 
                    || spdSpread.ActiveSheet.RowCount < 1 
                    || spdSpread.ActiveSheet.ColumnCount < 1)
                {
                    if (LoadDesign() == false)
                    {
                        return false;
                    }
                }

                // Spread 적용 suspend
                spdSpread.SuspendLayout();

                // out_node --> mh_data_map
                mh_data_map.Clear();
                DataMapping(out_node);

                col_rule_screen_map = (Hashtable)mh_screen_map.Clone();

                // 스프레드 모든 Cell에 있던 Text 만큼 
                foreach (string s_key_path in mh_screen_map.Keys)
                {                    
                    screen_info = (clsScreenInfo)mh_screen_map[s_key_path];
                    switch (screen_info.MacroRule)
                    {
                        // $ 인 경우
                        // -- 단일 Cell에 대해 값을 맵핑하고자 하는 경우에 사용한다.
                        case clsScreenInfo.MACRO_RULE.NO_RULE:                            
                            if (mh_data_map.Contains(s_key_path) == true)
                            {
                                value_info = (VALUE_TAG)mh_data_map[s_key_path];
                                // 저장된 Cell에 대해서만
                                for (i = 0; i < screen_info.ValueCells.Count; i++)
                                {
                                    FillDatatoScreen(screen_info.ValueCells[i].Row,
                                                     screen_info.ValueCells[i].Column,
                                                     value_info.Name,
                                                     value_info.DataType,
                                                     (string)value_info.Values[0]);
                                }
                            }
                            break;
                        // $= 인 경우
                        // -- ex.) $=DATA_LIST.CODE, $=DATA_LIST.DESC , ...
                        // -- 예약어가 정의된 Cell을 기준으로 LIST의 값을 순차적으로 수직으로 입력한다. 
                        // -- row수는 값의 개수에 따라 자동 증가된다.
                        // -- 하나의 column에 list 값을 맵핑하고자 하는 경우에 사용한다.
                        case clsScreenInfo.MACRO_RULE.COLUMN_RULE:
                            continue;
                        // $> 인 경우
                        // -- ex.) $>DATA_LIST.CODE, $>DATA_LIST.DESC, ...
                        // -- 예약어가 정의된 Cell을 기준으로 LIST의 값을 순차적으로 수평으로 입력한다.
                        // -- column수는 자동증가되지 않는다. 설정된 column 수 만큼만 데이터를 맵핑한다.
                        // -- 단일 row에 list 값을 지정된 column수만큼만 맵핑하고자 하는 경우에 사용한다.
                        case clsScreenInfo.MACRO_RULE.ROW_RULE:
                            if (mh_data_map.Contains(s_key_path) == true)
                            {
                                value_info = (VALUE_TAG)mh_data_map[s_key_path];
                                for (i = 0; i < screen_info.ValueCells.Count; i++)
                                {
                                    for (k = 0; k < value_info.Values.Count; k++)
                                    {
                                        if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[i].Column + k)
                                        {
                                            break;
                                        }

                                        if(k != 0)
                                        {
                                            CopyCellInfo(screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column + k - 1,
                                                                    screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column + k);
                                        }
                                        
                                        FillDatatoScreen(screen_info.ValueCells[i].Row,
                                                         screen_info.ValueCells[i].Column + k,
                                                         value_info.Name,
                                                         value_info.DataType,
                                                         (string)value_info.Values[k]);
                                    }
                                }
                            }
                            break;
                        // $LISTNAME$ 인 경우
                        // -- Column Header를 List Item의 Member 이름으로 변경하기 때문에
                        // -- Sheet의 모든 내용을 LIST로 채우고자 하는 경우에만 사용한다.
                        case clsScreenInfo.MACRO_RULE.FULL_RULE:
                            // 1. Get List from out_node
                            list_items = out_node.GetList(s_key_path);

                            // 2. Validation : no data
                            if (list_items.Count < 1)
                            {
                                break;
                            }

                            // 3. Add Spread Column 
                            for (i = 0; i < list_items[0].MemberCount; i++)
                            {
                                if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[0].Column + i)
                                {
                                    spdSpread.ActiveSheet.ColumnCount++;
                                }

                                // Column Header Change
                                spdSpread.ActiveSheet.ColumnHeader.Columns[i].Label = list_items[0].GetMember(i).Name;
                            }

                            // 4. Data Bind
                            // node count = data count = row count
                            for (i = 0; i < list_items.Count; i++)
                            {
                                // Add Spread Row
                                if (spdSpread.ActiveSheet.RowCount <= screen_info.ValueCells[0].Row + i)
                                {
                                    spdSpread.ActiveSheet.RowCount++;
                                }

                                // node's member count = column count
                                for (k = 0; k < list_items[i].MemberCount; k++)
                                {
                                    // Add Spread Column
                                    if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[0].Column + k)
                                    {
                                        spdSpread.ActiveSheet.ColumnCount++;
                                    }

                                    // Mapping
                                    FillDatatoScreen(screen_info.ValueCells[0].Row + i, screen_info.ValueCells[0].Column + k, list_items[i].GetMember(k).Name, list_items[i].GetMember(k).ValueType, list_items[i].GetMember(k).Value);
                                }
                            }

                            break;
                        default:
                            break;
                    }
                    col_rule_screen_map.Remove(s_key_path);
                }

                // COLUMN RULE인 대상에 대하여 
                if (col_rule_screen_map.Count > 0)
                {
                    int i_row_count = spdSpread.ActiveSheet.RowCount;

                    foreach (string s_key_path in col_rule_screen_map.Keys)
                    {
                        screen_info = (clsScreenInfo)col_rule_screen_map[s_key_path];
                        if (mh_data_map.Contains(s_key_path) == true)
                        {
                            value_info = (VALUE_TAG)mh_data_map[s_key_path];
                            for (i = screen_info.ValueCells.Count - 1; i >= 0; i--)
                            {
                                for (k = 0; k < value_info.Values.Count; k++)
                                {
                                    if (i_row_count <= screen_info.ValueCells[i].Row + k 
                                        || spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row + k, screen_info.ValueCells[i].Column].Value != null)
                                    {
                                        spdSpread.ActiveSheet.AddRows(screen_info.ValueCells[i].Row + k, 1);
                                        i_row_count++;
                                    }

                                    if (k != 0)
                                    {
                                        CopyCellInfo(screen_info.ValueCells[i].Row + k - 1, screen_info.ValueCells[i].Column,
                                                                screen_info.ValueCells[i].Row + k, screen_info.ValueCells[i].Column);
                                    }

                                    FillDatatoScreen(screen_info.ValueCells[i].Row + k, screen_info.ValueCells[i].Column, value_info.Name, value_info.DataType, (string)value_info.Values[k]);
                                }
                            }
                        }
                    }

                }

                spdSpread.ResumeLayout();
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lock Spread whole cell of row or column
        /// </summary>
        /// <param name="Type">ROW or COLUMN</param>
        /// <param name="Value">Row number or Column number</param>
        /// <param name="Locked">True - Lock, False - Unlock</param>
        public void ChangeLockStatus(TableMatrix Type, int Value, bool Locked)
        {
            int i;

            try
            {
                switch (Type)
                {
                    case TableMatrix.ROW:
                        for (i = 0; i < spdSpread.ActiveSheet.ColumnCount; i++)
                        {
                            spdSpread.ActiveSheet.Cells[Value, i].Locked = Locked;
                        }
                        break;
                    case TableMatrix.COLUMN:
                        for (i = 0; i < spdSpread.ActiveSheet.RowCount; i++)
                        {
                            spdSpread.ActiveSheet.Cells[i, Value].Locked = Locked;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Initialize flexible screen
        /// </summary>
        public void InitFlexibleScreen()
        {
            try
            {
                spdSpread.ActiveSheet.RowCount = 0;
                spdSpread.ActiveSheet.ColumnCount = 0;

                ms_previous_screen_id = "";
                ms_screen_id = "";
                ScreenAutoStretch = false;
                ScreenLock = false;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Add Row 
        /// </summary>
        /// <param name="DataList"></param>
        /// <returns></returns>
        public bool AddRowInSpread(List<object> DataList)
        {
            try
            {
                // Current Row Count
                int iRow = spdSpread.ActiveSheet.RowCount;

                // If row needs to be added,
                if (spdSpread.ActiveSheet.Cells[iRow - 1, 0].Text != "")
                {
                    spdSpread.ActiveSheet.RowCount++;
                }
                // No needs to be added
                else
                {
                    iRow = iRow - 1;
                }

                // Add list to row
                for (int iCol = 0; iCol < spdSpread.ActiveSheet.ColumnCount; iCol++)
                {
                    spdSpread.ActiveSheet.Cells[iRow, iCol].Value = DataList[iCol];
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Remove Active Row
        /// </summary>
        /// <returns></returns>
        public bool RemoveLastRow()
        {
            try
            {
                if (spdSpread.ActiveSheet.ActiveRowIndex < 0)
                {
                    return true;
                }

                spdSpread.ActiveSheet.RemoveRows(spdSpread.ActiveSheet.ActiveRowIndex, 1);
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 특정 칼럼의 Visible 속성을 변경한다.
        /// </summary>
        /// <param name="Column">속성을 변경할 칼럼의 시작 인덱스</param>
        /// <param name="Count">속성을 변경할 칼럼의 개수</param>
        /// <param name="Visible">속성 변경 값</param>
        /// <returns></returns>
        public bool ChangeColumnVisible(int Column, int Count, bool Visible)
        {
            try
            {
                for (int i = 0; i < Count; i++)
                {
                    spdSpread.ActiveSheet.Columns[Column + i].Visible = Visible;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 특정 칼럼의 셀 타입을 변경한다.
        /// </summary>
        /// <param name="Column">셀 타입을 변경할 칼럼의 인덱스</param>
        /// <param name="CellType">변경할 셀 타입</param>
        /// <returns></returns>
        public bool ChangeCellType(int Column, FSCREEN_CELL_TYPE CellType)
        {
            try
            {
                switch (CellType)
                {
                    case FSCREEN_CELL_TYPE.BUTTON:
                        FarPoint.Win.Spread.CellType.ButtonCellType BtnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        spdSpread.ActiveSheet.Columns.Get(Column).CellType = BtnCellType;
                        break;
                    case FSCREEN_CELL_TYPE.CHECKBOX:
                        FarPoint.Win.Spread.CellType.CheckBoxCellType ChkCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        spdSpread.ActiveSheet.Columns.Get(Column).CellType = ChkCellType;
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Fit Column Header
        /// </summary>
        public void FitScreenHeader()
        {
            if (spdSpread.ActiveSheet.ColumnCount > 0 && spdSpread.ActiveSheet.RowCount > 0)
            {
                MPOF.FitColumnHeader(spdSpread);
            }
        }

        /// <summary>
        /// Set Image Cell
        /// </summary>
        /// <param name="s_name"></param>
        /// <param name="image"></param>
        public void SetImageCell(string s_name, Image image)
        {
            clsScreenInfo screen_info;
            FarPoint.Win.Spread.CellType.ImageCellType cell_type;

            if (mh_screen_map.Contains(s_name) == false) return;

            screen_info = (clsScreenInfo)mh_screen_map[s_name];
            if (screen_info.MacroRule != clsScreenInfo.MACRO_RULE.NO_RULE) return;
            screen_info.CellType = FSCREEN_CELL_TYPE.IMAGE;

            cell_type = new FarPoint.Win.Spread.CellType.ImageCellType();
            cell_type.Style = FarPoint.Win.RenderStyle.Stretch;

            for (int i = 0; i < screen_info.ValueCells.Count; i++)
            {
                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].CellType = cell_type;
                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Value = image;
            }
        }

        /// <summary>
        /// Set Hyper Link Cell
        /// </summary>
        /// <param name="s_name"></param>
        /// <param name="s_link"></param>
        /// <param name="s_text"></param>
        public void SetHyperLinkCell(string s_name, string s_link, string s_text)
        {
            clsScreenInfo screen_info;
            FarPoint.Win.Spread.CellType.HyperLinkCellType cell_type;

            if (mh_screen_map.Contains(s_name) == false) return;

            screen_info = (clsScreenInfo)mh_screen_map[s_name];
            if (screen_info.MacroRule != clsScreenInfo.MACRO_RULE.NO_RULE) return;
            screen_info.CellType = FSCREEN_CELL_TYPE.HYPERLINK;

            cell_type = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
            cell_type.Link = s_link;
            cell_type.Text = s_text;
            cell_type.LinkArea = new LinkArea(0, s_text.Length);

            for (int i = 0; i < screen_info.ValueCells.Count; i++)
            {
                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Value = null;
                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].CellType = cell_type;
                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Locked = false;

                if (mb_screen_locked == true)
                {
                    spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].BackColor = spdSpread.ActiveSheet.LockBackColor;
                }
            }
        }

        /// <summary>
        /// Set Input Cell Info
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public bool SetInputCellInfo(clsFlexibleScreenInputValue cells)
        {
            int i, k;
            string s_name;
            clsScreenInfo screen_info;
            FarPoint.Win.Spread.CellType.BaseCellType cell_type;
            CultureInfo ci_local = CultureInfo.CurrentCulture;

            if (ms_screen_id == null || ms_screen_id == "")
            {
                MPOF.ShowMsgBox(MPOF.GetMessage(313));
                return false;
            }

            if (mh_screen_map.Count < 1)
            {
                MPOF.ShowMsgBox("No Screen Cell Information.");
                return false;
            }

            /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
            string s_date_sep = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator;
            string s_time_sep = System.Globalization.DateTimeFormatInfo.CurrentInfo.TimeSeparator;

            for (i = 0; i < cells.Count; i++)
            {
                s_name = cells.GetName(i);
                if (mh_screen_map.Contains(s_name) == false) continue;

                screen_info = (clsScreenInfo)mh_screen_map[s_name];
                if (screen_info.MacroRule != clsScreenInfo.MACRO_RULE.NO_RULE) continue;

                screen_info.InputFlag = true;
                /* 2013.06.12. Aiden. 조회 전용인 경우 Input Flag 를 false */
                if (cells.GetInputFlag(s_name) == 'V')
                {
                    screen_info.InputFlag = false;
                }

                screen_info.RequiredFlag = cells.GetRequiredFlag(s_name);
                screen_info.CellType = cells.GetCellType(s_name);

                cell_type = null;
                switch (screen_info.CellType)
                {
                    case FSCREEN_CELL_TYPE.TEXT:
                        cell_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        ((FarPoint.Win.Spread.CellType.TextCellType)cell_type).MaxLength = cells.GetValueSize(s_name);

                        /* 2013.06.12. Aiden. ASCII 인 경우 Multi Line 설정이 되어 있다면 Multi Line 허용 */
                        if (cells.GetMultiLineFlag(s_name) == true)
                        {
                            ((FarPoint.Win.Spread.CellType.TextCellType)cell_type).WordWrap = true;
                            ((FarPoint.Win.Spread.CellType.TextCellType)cell_type).Multiline = true;
                        }
                        break;
                    case FSCREEN_CELL_TYPE.NUMBER:
                        cell_type = new FarPoint.Win.Spread.CellType.NumberCellType();
                        ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).DecimalPlaces = 0;
                        {
                            string s_max_value = "";
                            double d_max_value = 0;
                            for (k = 0; k < cells.GetValueSize(s_name); k++)
                            {
                                s_max_value += "9";
                            }
                            d_max_value = MPOF.ToDbl(s_max_value);
                            ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).MaximumValue = d_max_value;
                            ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).MinimumValue = d_max_value * -1;
                        }
                        ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).Separator = ci_local.NumberFormat.NumberGroupSeparator;
                        break;
                    case FSCREEN_CELL_TYPE.FLOAT:
                        cell_type = new FarPoint.Win.Spread.CellType.NumberCellType();
                        ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).DecimalPlaces = 3;
                        {
                            string s_max_value = "";
                            double d_max_value = 0;
                            for (k = 0; k < cells.GetValueSize(s_name); k++)
                            {
                                s_max_value += "9";
                            }
                            d_max_value = MPOF.ToDbl(s_max_value);
                            ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).MaximumValue = d_max_value;
                            ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).MinimumValue = d_max_value * -1;
                        }
                        ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).Separator = ci_local.NumberFormat.NumberGroupSeparator;
                        ((FarPoint.Win.Spread.CellType.NumberCellType)cell_type).DecimalSeparator = ci_local.NumberFormat.NumberDecimalSeparator;
                        break;
                    case FSCREEN_CELL_TYPE.COMBOBOX:
                        Graphics g = this.CreateGraphics();
                        string[] s_items;
                        int i_list_max_width;
                        int i_list_width;

                        i_list_max_width = 0;
                        i_list_width = 0;

                        s_items = cells.GetComboItems(s_name);

                        for (k = 0; k < s_items.Length; k++)
                        {
                            i_list_width = MPOF.ToInt(g.MeasureString(s_items[k], this.Font).Width) + 30;
                            if (i_list_width > i_list_max_width)
                            {
                                i_list_max_width = i_list_width;
                            }
                        }

                        cell_type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        ((FarPoint.Win.Spread.CellType.ComboBoxCellType)cell_type).Items = s_items;
                        ((FarPoint.Win.Spread.CellType.ComboBoxCellType)cell_type).ListWidth = i_list_max_width;
                        break;
                    case FSCREEN_CELL_TYPE.DATETIME:
                        /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
                        cell_type = new FarPoint.Win.Spread.CellType.MaskCellType();
                        ((FarPoint.Win.Spread.CellType.MaskCellType)cell_type).Mask = "####" + s_date_sep + "##" + s_date_sep + "## ##" + s_time_sep + "##" + s_time_sep + "##";
                        break;
                    case FSCREEN_CELL_TYPE.DATE:
                        /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
                        cell_type = new FarPoint.Win.Spread.CellType.MaskCellType();
                        ((FarPoint.Win.Spread.CellType.MaskCellType)cell_type).Mask = "####" + s_date_sep + "##" + s_date_sep + "##";
                        break;
                    case FSCREEN_CELL_TYPE.TIME:
                        /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
                        cell_type = new FarPoint.Win.Spread.CellType.MaskCellType();
                        ((FarPoint.Win.Spread.CellType.MaskCellType)cell_type).Mask = "##" + s_time_sep + "##" + s_time_sep + "##";
                        break;
                    case FSCREEN_CELL_TYPE.IMAGE:
                        cell_type = new FarPoint.Win.Spread.CellType.ImageCellType();
                        ((FarPoint.Win.Spread.CellType.ImageCellType)cell_type).Style = FarPoint.Win.RenderStyle.Stretch;
                        break;
                    case FSCREEN_CELL_TYPE.HYPERLINK:
                        cell_type = new FarPoint.Win.Spread.CellType.HyperLinkCellType();
                        break;
                    case FSCREEN_CELL_TYPE.CHECKBOX:
                        /* 2013.06.12. Aiden. CheckBox Cell Type 추가 */
                        cell_type = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        if (cells.GetDisplayDescFlag(s_name) == true)
                        {
                            ((FarPoint.Win.Spread.CellType.CheckBoxCellType)cell_type).Caption = cells.GetCheckBoxDesc(s_name);
                        }
                        break;
                }

                /* 2013.06.12. Aiden. Status Type 이 Attibute, Table-Colum 인 경우에도 Cell BackColor 를 지정하도록 변경 */
                if (screen_info.CellType == FSCREEN_CELL_TYPE.VIEW_ONLY)
                {
                    Color bg_color_1 = cells.GetBackColor(s_name);

                    for (k = 0; k < screen_info.ValueCells.Count; k++)
                    {
                        if (bg_color_1 != Color.Empty)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].BackColor = bg_color_1;
                            if (bg_color_1.GetBrightness() < 0.5)
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].ForeColor = Color.White;
                            }
                        }
                        spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Locked = true;
                    }
                }

                if (cell_type == null) continue;

                object obj_temp;
                Color bg_color = cells.GetBackColor(s_name);

                for (k = 0; k < screen_info.ValueCells.Count; k++)
                {
                    if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE)
                    {
                        if (spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType is FarPoint.Win.Spread.CellType.ImageCellType)
                        {
                            if (cells.GetInputFlag(s_name) == 'I')
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value = null;
                            }
                        }
                        else
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                        }

                        if (mb_screen_locked == false)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].NoteIndicatorSize = new Size(10, 10);
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].NoteStyle = FarPoint.Win.Spread.NoteStyle.PopupStickyNote;
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Note = MPOF.GetMessage(349);
                        }

                        if (bg_color != Color.Empty)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].BackColor = bg_color;
                            if (bg_color.GetBrightness() < 0.5)
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].ForeColor = Color.White;
                            }
                        }
                    }
                    else if (screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                    {
                        if (spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType is FarPoint.Win.Spread.CellType.HyperLinkCellType)
                        {
                            if (cells.GetInputFlag(s_name) == 'I')
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                            }
                        }
                        else
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                        }

                        if (mb_screen_locked == false)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].NoteIndicatorSize = new Size(10, 10);
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].NoteStyle = FarPoint.Win.Spread.NoteStyle.PopupStickyNote;
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Note = MPOF.GetMessage(349);
                        }

                        if (bg_color != Color.Empty)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].BackColor = bg_color;
                            if (bg_color.GetBrightness() < 0.5)
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].ForeColor = Color.White;
                            }
                        }
                    }
                    else
                    {
                        if (bg_color != Color.Empty)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].BackColor = bg_color;
                            if (bg_color.GetBrightness() < 0.5)
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].ForeColor = Color.White;
                            }
                        }

                        obj_temp = null;
                        if (cells.GetInputFlag(s_name) != 'I')
                        {
                            obj_temp = spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value;
                        }

                        if (screen_info.CellType == FSCREEN_CELL_TYPE.COMBOBOX && MPOF.Trim(obj_temp) != "")
                        {
                            string[] s_items;
                            string[] s_item;
                            bool b_found = false;

                            s_items = cells.GetComboItems(s_name);
                            for (int m = 0; m < s_items.Length; m++)
                            {
                                s_item = s_items[m].Split(':');
                                if (MPOF.Trim(s_item[0]) == MPOF.Trim(obj_temp))
                                {
                                    obj_temp = s_items[m];
                                    b_found = true;
                                    break;
                                }
                            }

                            if (b_found == true)
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value = obj_temp;
                            }
                        }
                        else if (screen_info.CellType == FSCREEN_CELL_TYPE.CHECKBOX)
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value = false;
                            if (MPOF.Trim(obj_temp) == "Y")
                            {
                                spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value = true;
                            }
                        }
                        else
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].CellType = cell_type;
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Value = obj_temp;
                        }

                        if (cells.GetInputFlag(s_name) == 'V')
                        {
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Locked = true;
                        }

                    }//end if
                }//end for
            }//end for

            return true;
        }

        /// <summary>
        /// Input Cell Value
        /// </summary>
        /// <returns></returns>
        public clsFlexibleScreenInputValue GetInputCellValue()
        {
            clsFlexibleScreenInputValue fsiv;
            clsScreenInfo screen_info;
            FILE_TAG file;
            int i;
            object input_value;

            fsiv = null;
            if (mh_screen_map == null) return null;
            if (mb_screen_locked == true) return null;

            foreach (string s_member in mh_screen_map.Keys)
            {
                screen_info = (clsScreenInfo)mh_screen_map[s_member];
                if (screen_info.InputFlag == false) continue;

                if (fsiv == null)
                {
                    fsiv = new clsFlexibleScreenInputValue();
                }

                for (i = 0; i < screen_info.ValueCells.Count; i++)
                {
                    input_value = null;
                    if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE || screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                    {
                        input_value = spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Tag;
                    }
                    else
                    {
                        input_value = spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Value;
                    }

                    if (screen_info.RequiredFlag == true && (input_value == null || input_value.ToString() == ""))
                    {
                        bool b_error_flag = true;

                        if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE)
                        {
                            if (spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].Value != null)
                            {
                                b_error_flag = false;
                            }
                        }
                        else if (screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                        {
                            FarPoint.Win.Spread.CellType.HyperLinkCellType cell_type;
                            cell_type = (FarPoint.Win.Spread.CellType.HyperLinkCellType)spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column].CellType;
                            if (MPOF.Trim(cell_type.Link) != "")
                            {
                                b_error_flag = false;
                            }
                        }

                        if (b_error_flag == true)
                        {
                            MPOF.ShowMsgBox(MPOF.GetMessage(108) + "\n\n" + s_member);
                            spdSpread.ActiveSheet.SetActiveCell(screen_info.ValueCells[i].Row, screen_info.ValueCells[i].Column);
                            spdSpread.Select();
                            spdSpread.Focus();
                            return null;
                        }
                    }

                    if (input_value != null && input_value.ToString() != "")
                    {
                        if (screen_info.CellType == FSCREEN_CELL_TYPE.IMAGE || screen_info.CellType == FSCREEN_CELL_TYPE.HYPERLINK)
                        {
                            file = (FILE_TAG)input_value;
                            fsiv.AddCell(s_member, screen_info.CellType, file.FileData, file.FileName);
                        }
                        else
                        {
                            fsiv.AddCell(s_member, screen_info.CellType, input_value);
                        }
                    }
                }
            }

            return fsiv;
        }

        #endregion
    }

    public sealed class clsScreenInfo
    {
        #region Properties

        public bool InputFlag;
        public bool RequiredFlag;

        public string Path;
        public string MemberName;

        public MACRO_RULE MacroRule;
        public FSCREEN_CELL_TYPE CellType;

        public List<Position> ValueCells;

        public enum MACRO_RULE
        {
            NO_RULE = 0,
            COLUMN_RULE = 1,
            ROW_RULE = 2,
            FULL_RULE = 3,
            IMAGE_RULE = 4,
            MK_IMAGE_RULE = 5,
            BD_IMAGE_RULE = 6,
            NI_FULL_RULE = 7   // Row를 Insert하지 않고 그려진 Template에 그대로 Data만 뿌림.
        }

        public struct Position
        {
            public int Column;
            public int Row;

            public Position(int row, int col)
            {
                this.Row = row;
                this.Column = col;
            }
        }

        #endregion

        #region Constructor

        public clsScreenInfo()
        {
            this.Path = string.Empty;
            this.MemberName = string.Empty;
            this.MacroRule = MACRO_RULE.NO_RULE;
            this.CellType = FSCREEN_CELL_TYPE.GENERAL;
            this.InputFlag = false;
            this.ValueCells = new List<Position>();
        }

        #endregion
    }
}
