using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace BOI.OIFrx.BOIControls
{
    public partial class udcFlexibleScreen : UserControl
    {
        public udcFlexibleScreen()
        {
            InitializeComponent();
        }

        #region " Events Definition "

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

        #region " Properties Definition "

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
            get { return spdSpread.ActiveSheet.LockBackColor; }
            set { spdSpread.ActiveSheet.LockBackColor = value; }
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

        public string ScreenID
        {
            get { return ms_screen_id; }
            set { ms_screen_id = value; }
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

        private string ms_screen_id;
        private string ms_previous_screen_id;
        private bool mb_auto_stretch;
        private bool mb_screen_locked;

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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LotID
        {
            get { return ms_lot_id; }
            set { ms_lot_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ProcStep
        {
            get { return mc_proc_step; }
            set { mc_proc_step = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatID
        {
            get { return ms_mat_id; }
            set { ms_mat_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MatVer
        {
            get { return mi_mat_ver; }
            set { mi_mat_ver = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Flow
        {
            get { return ms_flow; }
            set { ms_flow = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FlowSeqNum
        {
            get { return mi_flow_seq_num; }
            set { mi_flow_seq_num = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Oper
        {
            get { return ms_oper; }
            set { ms_oper = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResID
        {
            get { return ms_res_id; }
            set { ms_res_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResType
        {
            get { return ms_res_type; }
            set { ms_res_type = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResGroup
        {
            get { return ms_res_group; }
            set { ms_res_group = value; }
        }

        #endregion

        #region " Constants Definition "

        public enum TableMatrix
        {
            COLUMN = 0,
            ROW = 1
        }

        #endregion // Constants Definition

        #region " Variables Definition "

        private string ms_base_path = Application.StartupPath + "\\Screen\\";
        private Hashtable mh_screen_map = new Hashtable();
        private Hashtable mh_data_map = new Hashtable();

        private string ms_loaded_service_name;
        private string ms_loaded_module_name;

        private List<string> mls_flexheader_members = new List<string>();

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

        #endregion // Variables Definition

        /// <summary>
        /// 스프레드 디자인에서 매크로를 탐색한다
        /// </summary>
        /// <returns>true or false</returns>
        private bool ScanScreen()
        {
            int i_row, i_col;
            string s_value = string.Empty;
            char[] c_delimiter = {'=', '>', '.'};

            try
            {
                mh_screen_map.Clear();

                if (spdSpread.ActiveSheet.RowCount == 0 || spdSpread.ActiveSheet.ColumnCount == 0)
                    return false;

                for (i_row = spdSpread.ActiveSheet.RowCount - 1; i_row >= 0 ; i_row--)
                {
                    for (i_col = 0; i_col < spdSpread.ActiveSheet.ColumnCount; i_col++)
                    {
                        s_value = spdSpread.ActiveSheet.Cells[i_row, i_col].Text;
                        
                        if (s_value == "") continue;

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

                        if (mh_screen_map.Contains(screen_info.Path) == false)
                        {
                            screen_info.ValueCells.Add(new clsScreenInfo.Position(i_row, i_col));
                            mh_screen_map.Add(screen_info.Path, screen_info);
                        }
                        else
                        {
                            clsScreenInfo item = (clsScreenInfo)mh_screen_map[screen_info.Path];
                            item.ValueCells.Add(new clsScreenInfo.Position(i_row, i_col));

                            mh_screen_map[screen_info.Path] = item;
                        }

                        spdSpread.ActiveSheet.Cells[i_row, i_col].Text = "";
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                DateTime dt_create_time;

                fs.Flush();
                buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2);
                bw.Write(buffer);

                bw.Close();
                fs.Close();

                dt_create_time = MPCF.ToDate(out_node.GetString("CREATION_TIME"));
                File.SetCreationTime(sPath + ".gzip", dt_create_time);

                Miracom.MESCore.MPCR.ZipDecompress(sPath);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                SOI.OIFrx.MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", ms_screen_id);

                if (SOI.OIFrx.MPCF.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                ms_loaded_service_name = out_node.GetString("SERVICE_NAME");
                ms_loaded_module_name = out_node.GetString("MODULE_NAME");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

                SOI.OIFrx.MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SERVICE_NAME", ms_loaded_service_name);
                in_node.AddString("USER_ID", MPGV.gsUserID);

                do
                {
                    if (SOI.OIFrx.MPCF.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
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
                MPCF.ShowMsgBox(ex.Message);
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
                SOI.OIFrx.MPCF.SetInMsg(in_node);
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

                if (SOI.OIFrx.MPCF.CallService("BAS", "BAS_Process_Flexible_Screen", in_node, ref out_node) == false)
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
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 설정된 Screen ID의 스프레드 디자인을 읽어온다.
        /// </summary>
        /// <returns></returns>
        public bool LoadDesign()
        {
            if (ms_screen_id == null || ms_screen_id == "")
            {
                // Relation에 정의된 Screen ID있는지 확인
                if (ViewScreenID() == false) return false;

                if (ms_screen_id == null || ms_screen_id == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(313));
                    return false;
                }
            }

            if (LoadDesign(ms_screen_id) == false) return false;

            return true;
        }

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
                if (s_screen_id == null || s_screen_id == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(313));
                    return false;
                }

                sPathZip = ms_base_path + s_screen_id + ".gzip";
                if (Directory.Exists(ms_base_path) == false)
                {
                    Directory.CreateDirectory(ms_base_path);
                }

                FileInfo fi = new FileInfo(sPathZip);

                SOI.OIFrx.MPCF.SetInMsg(in_node);
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
                        sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }

                    iFileSize = fi.Length;

                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }

                if (SOI.OIFrx.MPCF.CallService("BAS", "BAS_Check_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                b_upgraded = false;
                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateScreenXML(out_node, s_screen_id);
                    b_upgraded = true;
                }

                if (ms_previous_screen_id != s_screen_id || b_upgraded == true || spdSpread.ActiveSheet.RowCount < 1 || spdSpread.ActiveSheet.ColumnCount < 1)
                {
                    sPathXML = ms_base_path + s_screen_id + ".xml";
                    spdSpread.Open(sPathXML);

                    //MPCF.ConvertMessage(this.Controls);

                    if (ScanScreen() == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(314));
                        return false;
                    }
                }

                ms_screen_id = s_screen_id;
                ms_previous_screen_id = ms_screen_id;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Node에 담긴 데이터를 스프레드에 맵핑한다.
        /// </summary>
        /// <param name="node">스프레드에 맵핑할 데이터</param>
        private void DataMapping(TRSNode node)
        {
            int i, k;
            string s_path;
            VALUE_TAG value_info;

            if (node.MemberCount > 0)
            {
                for (i = 0; i < node.MemberCount; i++)
                {
                    s_path = node.GetMember(i).GetPath();
                    if (s_path == TRSDefine.OUT_MSGCODE || s_path == TRSDefine.OUT_MSG || s_path == TRSDefine.OUT_MSGCATE || s_path == TRSDefine.OUT_STATUSVALUE)
                        continue;

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

            if (node.ListCount > 0)
            {
                for (i = 0; i < node.ListCount; i++)
                {
                    for (k = 0; k < node.GetList(i).Count; k++)
                    {
                        DataMapping(node.GetList(i)[k]);
                    }
                }
            }
        }

        /// <summary>
        /// Fill the data to spread sheet
        /// </summary>
        /// <param name="Row">Row position of spread cell</param>
        /// <param name="Column">Column position of pread cell</param>
        /// <param name="Name">Service member name</param>
        /// <param name="Type">Data type</param>
        /// <param name="Value">Data value</param>
        private void FillDatatoScreen(int Row, int Column, string Name, TRSDataType Type, string Value)
        {
            switch (Type)
            {
                case TRSDataType.Int:
                case TRSDataType.Long:
                    FarPoint.Win.Spread.CellType.NumberCellType IntCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    IntCellType.DecimalPlaces = 0;
                    spdSpread.ActiveSheet.Cells[Row, Column].CellType = IntCellType;
                    spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    break;
                case TRSDataType.Double:
                case TRSDataType.Float:
                    FarPoint.Win.Spread.CellType.NumberCellType FloatCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    FloatCellType.DecimalPlaces = 0;
                    spdSpread.ActiveSheet.Cells[Row, Column].CellType = FloatCellType;
                    spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;

                    if (MPCF.ToDbl(Value) - MPCF.ToInt(Value) > 0.0005)
                    {
                        FloatCellType.DecimalPlaces = 3;
                    }

                    break;
                case TRSDataType.Char:
                case TRSDataType.String:
                    /* 2013.06.12. Aiden. 날짜, 시간에 대한 Cell Format 을 MaskCellType 으로 변경 */
                    if ((Name.Contains("TIME") || Name.Contains("DATE")) && 
                        MPCF.CheckNumeric(Value) && 
                        ((Value.Length == 14) || (Value.Length == 8) || (Value.Length == 6)))
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
                        spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;
                    }
                    else
                    {
                        spdSpread.ActiveSheet.Cells[Row, Column].Value = Value;

                        //Size sz = spdSpread.ActiveSheet.GetPreferredCellSize(Row, Column);
                        //float f_cell_width = sz.Width * ((sz.Height / 20) + 1);
                        //int i_span_count = spdSpread.ActiveSheet.Cells[Row, Column].ColumnSpan;
                        //float f_cell_width_spaned = 0;

                        //for (int mm = 0; mm < i_span_count; mm++)
                        //{
                        //    f_cell_width_spaned += spdSpread.ActiveSheet.Columns[Column + mm].Width;
                        //}

                        //spdSpread.ActiveSheet.Rows[Row].Height = 20 * (int)((f_cell_width / f_cell_width_spaned) + 1);
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
                    in_node.AddInt(MemberName, MPCF.ToInt(Value));
                    break;
                case TRSDataType.Long:
                    in_node.AddLong(MemberName, Convert.ToInt64(Value));
                    break;
                case TRSDataType.Double:
                    in_node.AddDouble(MemberName, MPCF.ToDbl(Value));
                    break;
                case TRSDataType.Float:
                    in_node.AddFloat(MemberName, MPCF.ToDbl(Value));
                    break;
                case TRSDataType.Char:
                    in_node.AddChar(MemberName, MPCF.ToChar(Value));
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
                if (LoadServiceName() == false)
                {
                    return false;
                }

                if (SOI.OIFrx.MPCF.CallService(ms_loaded_module_name, ms_loaded_service_name, in_node, ref out_node, b_ignore_err) == false)
                {
                    return false;
                }

                if (SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                if (ms_screen_id == null || ms_screen_id == "" || ms_previous_screen_id != ms_screen_id || spdSpread.ActiveSheet.RowCount < 1 || spdSpread.ActiveSheet.ColumnCount < 1)
                {
                    if (LoadDesign() == false) return false;
                }

                spdSpread.SuspendLayout();

                // out_node data mapping 
                mh_data_map.Clear();
                DataMapping(out_node);

                col_rule_screen_map = (Hashtable)mh_screen_map.Clone();

                foreach (string s_key_path in mh_screen_map.Keys)
                {
                    screen_info = (clsScreenInfo)mh_screen_map[s_key_path];
                    switch (screen_info.MacroRule)
                    {
                        case clsScreenInfo.MACRO_RULE.NO_RULE:
                            if (mh_data_map.Contains(s_key_path) == true)
                            {
                                value_info = (VALUE_TAG)mh_data_map[s_key_path];
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
                        case clsScreenInfo.MACRO_RULE.COLUMN_RULE:
                            continue;
                            break;
                        case clsScreenInfo.MACRO_RULE.ROW_RULE:
                            if (mh_data_map.Contains(s_key_path) == true)
                            {
                                value_info = (VALUE_TAG)mh_data_map[s_key_path];
                                for (i = 0; i < screen_info.ValueCells.Count; i++)
                                {
                                    for (k = 0; k < value_info.Values.Count; k++)
                                    {
                                        if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[i].Column + k)
                                            break;

                                        FillDatatoScreen(screen_info.ValueCells[i].Row, 
                                                         screen_info.ValueCells[i].Column + k, 
                                                         value_info.Name, 
                                                         value_info.DataType, 
                                                         (string)value_info.Values[k]);
                                    }
                                }
                            }
                            break;
                        case clsScreenInfo.MACRO_RULE.FULL_RULE:
                            list_items = out_node.GetList(s_key_path);
                            if (list_items.Count < 1)
							{
                                break;
							}

                            for (i = 0; i < list_items[0].MemberCount; i++)
                            {
                                spdSpread.ActiveSheet.ColumnHeader.Columns[i].Label = list_items[0].GetMember(i).Name;

                                if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[0].Column + i)
                                {
                                    spdSpread.ActiveSheet.ColumnCount++;
                                }
                            }

                            for (i = 0; i < list_items.Count; i++)
                            {
                                if (spdSpread.ActiveSheet.RowCount <= screen_info.ValueCells[0].Row + i)
                                    spdSpread.ActiveSheet.RowCount++;

                                for (k = 0; k < list_items[i].MemberCount; k++)
                                {
                                    if (spdSpread.ActiveSheet.ColumnCount <= screen_info.ValueCells[0].Column + k)
                                    {
                                        spdSpread.ActiveSheet.ColumnCount++;
                                    }

                                    FillDatatoScreen(screen_info.ValueCells[0].Row + i, screen_info.ValueCells[0].Column + k, list_items[i].GetMember(k).Name, list_items[i].GetMember(k).ValueType, list_items[i].GetMember(k).Value);
                                }
                            }    
                            break;
                        default:
                            break;
                    }
                    col_rule_screen_map.Remove(s_key_path);
                }

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
                                    if (i_row_count <= screen_info.ValueCells[i].Row + k || spdSpread.ActiveSheet.Cells[screen_info.ValueCells[i].Row + k, screen_info.ValueCells[i].Column].Value != null)
                                    {
                                        spdSpread.ActiveSheet.AddRows(screen_info.ValueCells[i].Row + k, 1);
                                        i_row_count++;
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
                MPCF.ShowMsgBox(ex.Message);
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
                switch(Type)
                {
                    case TableMatrix.ROW:
                        for (i = 0; i < spdSpread.ActiveSheet.ColumnCount; i++ ) 
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
                MPCF.ShowMsgBox(ex.Message);
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
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdSpread_Resize(object sender, EventArgs e)
        {
            if (mb_auto_stretch == false) return;

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

        public bool AddRowInSpread(List<object> DataList)
        {
            try
            {
                int iRow = spdSpread.ActiveSheet.RowCount;
                if (spdSpread.ActiveSheet.Cells[iRow - 1, 0].Text != "")
                    spdSpread.ActiveSheet.RowCount++;
                else
                    iRow = iRow - 1;

                for (int iCol = 0; iCol < spdSpread.ActiveSheet.ColumnCount; iCol++)
                    spdSpread.ActiveSheet.Cells[iRow, iCol].Value = DataList[iCol];

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레드의 마지막 가로줄을 한줄 삭제한다.
        /// </summary>
        /// <returns></returns>
        public bool RemoveLastRow()
        {
            try
            {
                spdSpread.ActiveSheet.RemoveRows(spdSpread.ActiveSheet.ActiveRowIndex, 1);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                MPCF.ShowMsgBox(ex.Message);
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
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public void FitScreenHeader()
        {
            if (spdSpread.ActiveSheet.ColumnCount > 0 && spdSpread.ActiveSheet.RowCount > 0)
            {
                MPCF.FitColumnHeader(spdSpread);
            }
        }

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

        public bool SetInputCellInfo(clsFlexibleScreenInputValue cells)
        {
            int i, k;
            string s_name;
            clsScreenInfo screen_info;
            FarPoint.Win.Spread.CellType.BaseCellType cell_type;
            CultureInfo ci_local = CultureInfo.CurrentCulture;

            if (ms_screen_id == null || ms_screen_id == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(313));
                return false;
            }

            if (mh_screen_map.Count < 1)
            {
                MPCF.ShowMsgBox("No Screen Cell Information.");
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
                            d_max_value = MPCF.ToDbl(s_max_value);
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
                            d_max_value = MPCF.ToDbl(s_max_value);
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
                            i_list_width = MPCF.ToInt(g.MeasureString(s_items[k], this.Font).Width) + 30;
                            if(i_list_width > i_list_max_width)
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
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Note = MPCF.GetMessage(349);
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
                            spdSpread.ActiveSheet.Cells[screen_info.ValueCells[k].Row, screen_info.ValueCells[k].Column].Note = MPCF.GetMessage(349);
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

                        if (screen_info.CellType == FSCREEN_CELL_TYPE.COMBOBOX && MPCF.Trim(obj_temp) != "")
                        {
                            string[] s_items;
                            string[] s_item;
                            bool b_found = false;

                            s_items = cells.GetComboItems(s_name);
                            for (int m = 0; m < s_items.Length; m++)
                            {
                                s_item = s_items[m].Split(':');
                                if (MPCF.Trim(s_item[0]) == MPCF.Trim(obj_temp))
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
                            if(MPCF.Trim(obj_temp) == "Y")
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
                            if (MPCF.Trim(cell_type.Link) != "")
                            {
                                b_error_flag = false;
                            }
                        }

                        if (b_error_flag == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\n\n" + s_member);
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

        private clsScreenInfo GetInputCellInfo(int i_row, int i_col)
        {
            clsScreenInfo screen_info;
            if (mh_screen_map == null) return null;
            foreach (string s_key_path in mh_screen_map.Keys)
            {
                screen_info = (clsScreenInfo)mh_screen_map[s_key_path];
                if (screen_info.InputFlag == false) continue;

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

        private void spdSpread_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            clsScreenInfo screen_info;
            FILE_TAG file;
            FileInfo finfo;
            BinaryReader br;

            if ((screen_info = GetInputCellInfo(e.Row, e.Column)) == null) return;
            if (screen_info.InputFlag == false) return;
            if (screen_info.CellType != FSCREEN_CELL_TYPE.IMAGE && screen_info.CellType != FSCREEN_CELL_TYPE.HYPERLINK) return;
            if (mb_screen_locked == true) return;

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
                        MPCF.ShowMsgBox(MPCF.GetMessage(361));
                    }

                    spdSpread.ActiveSheet.Cells[e.Row, e.Column].Tag = file;
                }
            }
        }
    }

    public sealed class clsScreenInfo
    {
        #region "Enum Definition"

        //kelly jung 20121201
        //for Flexible Document
        //Add 4,5,6
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

        #endregion

        #region " Variable Definition "

        public string Path;
        public string MemberName;
        public MACRO_RULE MacroRule;
        public FSCREEN_CELL_TYPE CellType;
        public bool InputFlag;
        public bool RequiredFlag;

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

        public List<Position> ValueCells;

        #endregion
        
        public clsScreenInfo()
        {
            this.Path = string.Empty;
            this.MemberName = string.Empty;
            this.MacroRule = MACRO_RULE.NO_RULE;
            this.CellType = FSCREEN_CELL_TYPE.GENERAL;
            this.InputFlag = false;
            this.ValueCells = new List<Position>();
        }
    }
}
