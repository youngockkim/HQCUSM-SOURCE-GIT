using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using FarPoint.Win.Spread.CellType;

namespace Miracom.MESCore.Controls
{
    public partial class udcFlexibleDocument : UserControl
    {
        public udcFlexibleDocument()
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

        private string m_Screen_ID;

        //private int i_Top_Margin;
        //private int i_Bottom_Margin;
        //private int i_Right_Margin;
        //private int i_Left_Margin;

        //private int i_RowHeader_Column_Count;
        //private int i_ColumnHeader_Row_Count;
        //private bool b_Portrait;
        private int[] i_Page_Break_Row;

        //private System.Drawing.Printing.PaperSize Paper_size;

        public string ScreenID 
        {
            get { return m_Screen_ID; }
            set { m_Screen_ID = value; }
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

        public bool SpreadLocked
        {
            get
            {
                return spdSpread.ActiveSheet.DefaultStyle.Locked;
            }
            set
            {
                spdSpread.ActiveSheet.DefaultStyle.Locked = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FarPoint.Win.Spread.CellHorizontalAlignment SpreadHorizontalAlignment
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
        public FarPoint.Win.Spread.CellVerticalAlignment SpreadVerticalAlignment
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

        private bool m_AutoStretch;

        public bool SpreadAutoStretch
        {
            get
            {
                return m_AutoStretch;
            }
            set
            {
                m_AutoStretch = value;
            }
        }

        private bool m_b_Use_Default_ID;

        public bool UseDefaultID
        {
            get
            {
                return m_b_Use_Default_ID;
            }
            set
            {
                m_b_Use_Default_ID = value;
            }
        }

        //public Size MinSize
        //{
        //    get
        //    {
        //        return this.MinimumSize;
        //    }
        //    set
        //    {
        //        this.MinimumSize = value;
        //    }
        //}

        private string m_lot_id;
        private char m_proc_step;
        private string m_mat_id;
        private int m_mat_ver;
        private string m_flow;
        private int m_flow_seq_num;
        private string m_oper;
        private string m_res_id;
        private string m_res_type;
        private string m_res_group;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LotID
        {
            get { return m_lot_id; }
            set { m_lot_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ProcStep
        {
            get { return m_proc_step; }
            set { m_proc_step = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatID
        {
            get { return m_mat_id; }
            set { m_mat_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MatVer
        {
            get { return m_mat_ver; }
            set { m_mat_ver = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Flow
        {
            get { return m_flow; }
            set { m_flow = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FlowSeqNum
        {
            get { return m_flow_seq_num; }
            set { m_flow_seq_num = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Oper
        {
            get { return m_oper; }
            set { m_oper = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResID
        {
            get { return m_res_id; }
            set { m_res_id = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResType
        {
            get { return m_res_type; }
            set { m_res_type = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResGroup
        {
            get { return m_res_group; }
            set { m_res_group = value; }
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

        private string BasePath = Application.StartupPath + "\\DocTemp\\";
        //private string BaseImagePath = Application.StartupPath + "\\Image\\";
        private string SaveImagePath = Application.StartupPath + "\\Print_Image\\"; //T-card Print 화면에서 저장되는 폴더
        private Hashtable ScreenMap = new Hashtable();
        private Hashtable DataMap = new Hashtable();

        private string ServiceName;
        private string ModuleName;

        private FarPoint.Win.Spread.SheetView SpreadSheet;
        //PictureBox picbox;

        private List<string> ServiceMember = new List<string>();

        public struct Data_Tag
        {
            public string Name;
            public TRSDataType DataType;
            public ArrayList Value;
        }


        #endregion // Variables Definition

        /// <summary>
        /// 스프레드 디자인에서 매크로를 탐색한다
        /// </summary>
        /// <returns>true or false</returns>
        private bool ScanScreen()
        {
            int iRow, iCol;
            string sValue = string.Empty;
            char[] cDelimiter = {'=', '>', '.'};
            
            int iPageBreakCount=0;

            try
            {
                ScreenMap.Clear();

                i_Page_Break_Row = new int[spdSpread.ActiveSheet.RowCount];

                if (spdSpread.ActiveSheet.RowCount == 0 || spdSpread.ActiveSheet.ColumnCount == 0)
                    return false;

                for (iRow = spdSpread.ActiveSheet.RowCount - 1; iRow >= 0 ; iRow--)
                {
                    for (iCol = 0; iCol < spdSpread.ActiveSheet.ColumnCount; iCol++)
                    {
                        sValue = spdSpread.ActiveSheet.Cells[iRow, iCol].Text;
                        
                        if (sValue == "")
                            continue;

                        clsScreenInfo MapItem = new clsScreenInfo();

                        if (spdSpread.ActiveSheet.Rows[iRow].PageBreak == true)
                        {
                            i_Page_Break_Row[iPageBreakCount] = iRow;
                            iPageBreakCount++;
                        }


                        // $= Macro Rule인 경우
                        if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("$=") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.COLUMN_RULE;
                        }
                        // $> Macro Rule인 경우
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("$>") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.ROW_RULE;
                        }
                        // $MemberName$ Macro Rule인 경우
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.EndsWith("$") == true)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.FULL_RULE;
                        }
                        // Macro Rule이 없는 경우
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("$") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.NO_RULE;
                        }
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("@") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.NI_FULL_RULE; // Template에 Insert를 시키지 않고 그려진 Template에 Data만 뿌려줌.
                        }
                        /* Image_Rule*/
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("##") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.IMAGE_RULE;
                        }
                        /* MK_Image_Rule*/
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("#=") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.MK_IMAGE_RULE;
                        }
                        /* Bonding Image_Rule*/
                        else if (spdSpread.ActiveSheet.Cells[iRow, iCol].Text.IndexOf("#&") > -1)
                        {
                            MapItem.MacroRule = clsScreenInfo.MACRO_RULE.BD_IMAGE_RULE;
                        }
                        else
                        {   // Macro가 아닌 데이터의 경우
                            continue;
                        }

                        MapItem.Path = sValue.Replace('.', '/');
                        MapItem.Path = MapItem.Path.Replace("$", "");
                        MapItem.Path = MapItem.Path.Replace("#&", "");
                        MapItem.Path = MapItem.Path.Replace("@", "");

                        MapItem.Path = MapItem.Path.Substring(MapItem.Path.LastIndexOfAny(cDelimiter) + 1);
                        MapItem.MemberName = sValue.Substring(sValue.LastIndexOfAny(cDelimiter) + 1);

                        if (ScreenMap.Contains(MapItem.Path) == false)
                        {
                            MapItem.ValueCells.Add(new clsScreenInfo.Position(iRow, iCol));
                            ScreenMap.Add(MapItem.Path, MapItem);
                        }
                        else
                        {
                            clsScreenInfo item = (clsScreenInfo)ScreenMap[MapItem.Path];
                            item.ValueCells.Add(new clsScreenInfo.Position(iRow, iCol));

                            ScreenMap[MapItem.Path] = item;
                        }

                        spdSpread.ActiveSheet.Cells[iRow, iCol].Text = "";
                    }
                }

                SpreadSheet = spdSpread.ActiveSheet;
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
        private bool UpdateScreenXML(TRSNode out_node)
        {
            try
            {
                string sPath = BasePath + m_Screen_ID;
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

                MPCR.ZipDecompress(sPath);
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
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOF_ID", m_Screen_ID);

                if (MPCR.CallService("BAS", "BAS_View_Document_Format", in_node, ref out_node) == false)
                {
                    return false;
                }

                ServiceName = out_node.GetString("SERVICE_NAME");
                ModuleName = out_node.GetString("MODULE_NAME");

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

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SERVICE_NAME", ServiceName);
                in_node.AddString("USER_ID", MPGV.gsUserID);

                do
                {
                    if (MPCR.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("HEADER_LIST").Count; i++)
                    {
                        ServiceMember.Add(out_node.GetList("HEADER_LIST")[i].GetString("MEMBER_PATH"));
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
        private bool GetScreenID()
        {
            TRSNode in_node = new TRSNode("Get_Screen_ID_IN");
            TRSNode out_node = new TRSNode("Get_Screen_ID_OUT");            

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = m_proc_step;

                in_node.AddString("LOT_ID", m_lot_id);
                in_node.AddString("MAT_ID", m_mat_id);
                in_node.AddInt("MAT_VER", m_mat_ver);
                in_node.AddString("FLOW", m_flow);
                in_node.AddString("FLOW_SEQ_NUM", m_flow_seq_num);
                in_node.AddString("OPER", m_oper);
                in_node.AddString("RES_ID", m_res_id);
                in_node.AddString("RES_TYPE", m_res_type);
                in_node.AddString("RESG_ID", m_res_group);

                if (MPCR.CallService("BAS", "BAS_Process_Flexible_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("EXIST_ID") == 'Y')
                {
                    m_Screen_ID = out_node.GetString("SCREEN_ID");
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
            string sPathZip;
            string sPathXML;
            string sCreateTime;

            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Screen_IN");
            TRSNode out_node = new TRSNode("View_Screen_OUT");
            
            try
            {
                if (m_Screen_ID == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(313));
                    return false;
                }

                sPathZip = BasePath + m_Screen_ID + ".gzip";
                if (Directory.Exists(BasePath) == false)
                {
                    Directory.CreateDirectory(BasePath);
                }

                FileInfo fi = new FileInfo(sPathZip);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOF_ID", m_Screen_ID);

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


                if (MPCR.CallService("BAS", "BAS_Check_Document", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateScreenXML(out_node);
                }

                spdSpread.ActiveSheet.RowCount = 0;

                sPathXML = BasePath + m_Screen_ID + ".xml";
                spdSpread.Open(sPathXML);

                if (ScanScreen() == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(314));
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
        /// Node에 담긴 데이터를 스프레드에 맵핑한다.
        /// </summary>
        /// <param name="node">Data Mapping</param>
        private void DataMapping(TRSNode node)
        {
            string sPath = string.Empty;
            if (node.MemberCount > 0)
            {
                for (int i = 0; i < node.MemberCount; i++)
                {
                    sPath = node.GetMember(i).GetPath();
                    if (sPath == TRSDefine.OUT_MSGCODE || sPath == TRSDefine.OUT_MSG || sPath == TRSDefine.OUT_MSGCATE || sPath == TRSDefine.OUT_STATUSVALUE)
                        continue;

                    if (DataMap.Contains(sPath) == true)
                    {
                        Data_Tag temp = (Data_Tag)DataMap[sPath];
                        temp.Value.Add(node.GetMember(i).Value);

                        DataMap[sPath] = temp;
                    }
                    else
                    {
                        Data_Tag temp = new Data_Tag();
                        temp.Value = new ArrayList();

                        temp.Value.Add(node.GetMember(i).Value);
                        temp.DataType = node.GetMember(i).ValueType;
                        temp.Name = node.GetMember(i).Name;

                        DataMap.Add(sPath, temp);
                    }
                }
            }

            if (node.ListCount > 0)
            {
                for (int i = 0; i < node.ListCount; i++)
                {
                    for (int j = 0; j < node.GetList(i).Count; j++)
                    {
                        DataMapping(node.GetList(i)[j]);
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
        private void FillData(int Row, int Column, string Name, TRSDataType Type, string Value)
        {
            switch (Type)
            {
                case TRSDataType.Int:
                case TRSDataType.Long:
                    FarPoint.Win.Spread.CellType.NumberCellType IntCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    IntCellType.DecimalPlaces = 0;

                    spdSpread.ActiveSheet.Cells[Row , Column ].CellType = IntCellType;
                    spdSpread.ActiveSheet.Cells[Row , Column ].Value = Value;

                    break;
                case TRSDataType.Double:
                case TRSDataType.Float:
                    FarPoint.Win.Spread.CellType.NumberCellType FloatCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                    if (Value.Contains("."))
                        FloatCellType.DecimalPlaces = 3;
                    else
                        FloatCellType.DecimalPlaces = 0;

                    spdSpread.ActiveSheet.Cells[Row, Column].CellType = FloatCellType;
                    spdSpread.ActiveSheet.Cells[Row , Column ].Value = Value;

                    break;
                case TRSDataType.Char:
                case TRSDataType.String:

                    if (Name.Contains("TIME") && ((Value.Length == 14) || (Value.Length == 8)) && MPCF.CheckNumeric(Value))
                    {
                        FarPoint.Win.Spread.CellType.DateTimeCellType DateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                        DateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
                        try
                        {
                            spdSpread.ActiveSheet.Cells[Row , Column ].Value = MPCF.ToDate(Value);
                        }
                        catch (Exception)
                        {
                            spdSpread.ActiveSheet.Cells[Row , Column ].Value = Value;
                        }
                    }
                    else
                    {
                        spdSpread.ActiveSheet.Cells[Row, Column ].Value = Value;
                    }                   

                    break;
            }
        }

        /// <summary>
        /// Fill the data to TRS Node
        /// </summary>
        /// <param name="MemberName">Service member name</param>
        /// <param name="Type">Data type</param>
        /// <param name="Value">Data value</param>
        /// <param name="Value">Data value</param>
        private void FillData(ref TRSNode in_node, string MemberName, TRSDataType Type, object Value)
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
        public bool ViewServiceData(TRSNode in_node)
        {
            return this.ViewServiceData(in_node, false);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="out_node">서비스 결과가 들어갈 Output 노드</param>
        /// <returns></returns>
        public bool ViewServiceData(TRSNode in_node, ref TRSNode out_node)
        {
            return this.ViewServiceData(in_node, ref out_node, false);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="b_ignore_err">서비스 진행시 발생된 에러 처리 방식 결정. true면 무시</param>
        /// <returns></returns>
        public bool ViewServiceData(TRSNode in_node, bool b_ignore_err)
        {
            TRSNode out_node = new TRSNode("SERVICE_DATA_OUT");

            return this.ViewServiceData(in_node, ref out_node, b_ignore_err);
        }

        /// <summary>
        /// Screen ID에 설정된 서비스를 이용하여 그 결과값을 스프레드에 입력한다.
        /// </summary>
        /// <param name="in_node">서비스에 사용될 Input 노드</param>
        /// <param name="out_node">서비스 결과가 들어갈 Output 노드</param>
        /// <param name="b_ignore_err">서비스 진행시 발생된 에러 처리 방식 결정. true면 무시</param>
        /// <returns></returns>
        public bool ViewServiceData(TRSNode in_node, ref TRSNode out_node, bool b_ignore_err)
        {
            try
            {
                if (LoadServiceName() == false)
                {
                    return false;
                }

                in_node.SetString("DOF_ID", m_Screen_ID);

                if (MPCR.CallService(ModuleName, ServiceName, in_node, ref out_node, b_ignore_err) == false)
                {
                    return false;
                }

                
                if (SetDataToSpread(out_node) == false)
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
        public bool SetDataToSpread(TRSNode out_node)
        {
            try
            {
                string sPathXML;
                string sPathImage="";
                //string sCopyImage = "";
                int iSpanRow = 0;
                int iSpanRowCount = 0;
                int iSpanCol = 0;
                int iSpanColCount = 0;

                sPathXML = BasePath + m_Screen_ID + ".xml";

                if (File.Exists(sPathXML) == false)
                {
                    MPCF.ShowMsgBox("Failed to load screen");
                    return false;
                }

                spdSpread.Open(sPathXML);
                
                if (ScanScreen() == false)
                {
                    MPCF.ShowMsgBox("Failed to scan screen macro");
                    return false;
                }

                // out_node data mapping 
                DataMap.Clear();

                spdSpread.SuspendLayout();

                DataMapping(out_node);

                Hashtable ScreenMapOther = (Hashtable)ScreenMap.Clone();

                foreach (string Member in ScreenMap.Keys)
                {
                    clsScreenInfo Item = (clsScreenInfo)ScreenMap[Member];
                    switch (Item.MacroRule)
                    {
                        case clsScreenInfo.MACRO_RULE.NO_RULE:
                            if (DataMap.Contains(Member) == true)
                            {
                                for (int i = 0; i < Item.ValueCells.Count; i++)
                                {
                                    FillData(Item.ValueCells[i].Row, Item.ValueCells[i].Column, ((Data_Tag)DataMap[Member]).Name, ((Data_Tag)DataMap[Member]).DataType, (string)((Data_Tag)DataMap[Member]).Value[0]);
                                }
                            }
                            break;
                        case clsScreenInfo.MACRO_RULE.COLUMN_RULE:
                            continue;
                            break;
                        case clsScreenInfo.MACRO_RULE.ROW_RULE:
                            for (int i = 0; i < Item.ValueCells.Count; i++)
                            {
                                for (int j = 0; j < ((Data_Tag)DataMap[Member]).Value.Count; j++)
                                {
                                    if (spdSpread.ActiveSheet.ColumnCount <= Item.ValueCells[i].Column + j)
                                        break;

                                    FillData(Item.ValueCells[i].Row, Item.ValueCells[i].Column + j + MPGV.giSpanCol, ((Data_Tag)DataMap[Member]).Name, ((Data_Tag)DataMap[Member]).DataType, (string)((Data_Tag)DataMap[Member]).Value[j]);

                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row, Item.ValueCells[i].Column + j + MPGV.giSpanCol).RowCount > 1)
                                    {
                                        MPGV.giSpanCol = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row, Item.ValueCells[i].Column + j + MPGV.giSpanCol).ColumnCount - 1;
                                    }
                                    else
                                        MPGV.giSpanCol = 0;
                                }
                            }
                            break;
                        case clsScreenInfo.MACRO_RULE.FULL_RULE:
                            if (out_node.GetList(Member).Count <= 0)
                                break;

                            iSpanRow = 0;
                            iSpanRowCount = 0;
                            iSpanCol = 0;
                            iSpanColCount = 0;
                            int iListRow = Item.ValueCells[0].Row;

                            for (int j = 0; j < out_node.GetList(Member).Count; j++)
                            {
                                if (j != 0)
                                {
                                    FarPoint.Win.Spread.Model.CellRange range =
                                        new FarPoint.Win.Spread.Model.CellRange(
                                            Item.ValueCells[0].Row + j + iSpanRow,
                                            0,
                                            iSpanRowCount,
                                            spdSpread.ActiveSheet.ColumnCount);
                                    spdSpread.ActiveSheet.ClipboardCopy(range, FarPoint.Win.Spread.ClipboardCopyOptions.All);

                                    range.Row = range.Row + iSpanRowCount;
                                    if(iSpanRowCount <= 0)
                                        spdSpread.ActiveSheet.Rows.Add(range.Row, 1);
                                    else
                                        spdSpread.ActiveSheet.Rows.Add(range.Row, iSpanRowCount);

                                    spdSpread.ActiveSheet.SetActiveCell(range.Row, 0);
                                    spdSpread.ActiveSheet.ClipboardPaste(FarPoint.Win.Spread.ClipboardPasteOptions.All);
                                    spdSpread.ActiveSheet.ClearRange(range.Row, range.Column, range.RowCount, range.ColumnCount, true);
                                }
                                iSpanCol = 0;
                                iSpanColCount = 0;

                                for (int k = 0; k < out_node.GetList(Member)[j].MemberCount; k++)
                                {
                                    if (spdSpread.ActiveSheet.ColumnCount <= Item.ValueCells[0].Column + k + iSpanCol)
                                    {
                                        spdSpread.ActiveSheet.ColumnCount += iSpanColCount;
                                    }

                                    FillData(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column + k + iSpanCol, out_node.GetList(Member)[j].GetMember(k).Name, out_node.GetList(Member)[j].GetMember(k).ValueType, out_node.GetList(Member)[j].GetMember(k).Value);

                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column + k + iSpanCol) != null)
                                    {
                                        if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column + k + iSpanCol).ColumnCount > 1)
                                        {
                                            iSpanColCount = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column + k + iSpanCol).ColumnCount;
                                            iSpanCol = iSpanCol + spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column + k + iSpanCol).ColumnCount - 1;
                                        }
                                    }
                                    else
                                    {
                                        iSpanCol++;
                                        iSpanColCount = 1;
                                    }
                                }

                                if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column) != null)
                                {
                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column).RowCount > 1)
                                    {
                                        iSpanRowCount = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column).RowCount;
                                        iSpanRow = iSpanRow + spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + j + iSpanRow, Item.ValueCells[0].Column).RowCount - 1;
                                    }
                                }
                                else
                                {
                                    iSpanRow++;
                                    iSpanRowCount = 1;
                                }
                            }
                            break;

                        case clsScreenInfo.MACRO_RULE.NI_FULL_RULE:
                            if (out_node.GetList(Member).Count <= 0)
                                break;

                            iSpanRow = 0;
                            iSpanRowCount = 0;
                            iSpanCol = 0;
                            iSpanColCount = 0;

                            for (int j = 0; j < out_node.GetList(Member).Count; j++)
                            {
                                iSpanCol = 0;
                                iSpanColCount = 0;

                                for (int k = 0; k < out_node.GetList(Member)[j].MemberCount; k++)
                                {
                                    if (spdSpread.ActiveSheet.ColumnCount <= Item.ValueCells[0].Column + k + iSpanCol)
                                    {
                                        spdSpread.ActiveSheet.ColumnCount += iSpanColCount;
                                    }

                                    FillData(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column + iSpanCol, out_node.GetList(Member)[j].GetMember(k).Name, out_node.GetList(Member)[j].GetMember(k).ValueType, out_node.GetList(Member)[j].GetMember(k).Value);

                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column + iSpanCol) != null)
                                    {
                                        if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column + iSpanCol).ColumnCount > 1)
                                        {
                                            iSpanColCount = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column  + iSpanCol).ColumnCount;
                                            iSpanCol = iSpanCol + spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column + iSpanCol).ColumnCount - 1;
                                        }
                                    }
                                    else
                                    {
                                        iSpanCol++;
                                        iSpanColCount = 1;
                                    }
                                }

                                if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + iSpanRow, Item.ValueCells[0].Column) != null)
                                {
                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column).RowCount > 1)
                                    {
                                        iSpanRowCount = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row  + iSpanRow, Item.ValueCells[0].Column).RowCount;
                                        iSpanRow = iSpanRow + spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[0].Row + iSpanRow, Item.ValueCells[0].Column).RowCount - 1;
                                    }
                                    else
                                    {
                                        iSpanRowCount = 1;
                                        iSpanRow++;
                                    }
                                }
                                else
                                {
                                    iSpanRow++;
                                    iSpanRowCount = 1;
                                }
                            }
                            break;

                        case clsScreenInfo.MACRO_RULE.IMAGE_RULE:

                            if (Member.ToString() != "")
                            {
                                if (Directory.Exists(BasePath) == false)
                                {
                                    Directory.CreateDirectory(BasePath);
                                }

                                sPathImage = BasePath + Member.ToString().Replace("##", "") + ".jpg";

                                 FarPoint.Win.Spread.CellType.ImageCellType ImageCellType = new FarPoint.Win.Spread.CellType.ImageCellType();
                                 ImageCellType.Style = FarPoint.Win.RenderStyle.StretchAndScale;
                                 spdSpread.ActiveSheet.Cells[Item.ValueCells[0].Row, Item.ValueCells[0].Column].CellType = ImageCellType;
                                 System.Drawing.Image image = System.Drawing.Image.FromFile(sPathImage);
                                 //System.IO.MemoryStream stream = new System.IO.MemoryStream();
                                 //image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                                 spdSpread.ActiveSheet.Cells[Item.ValueCells[0].Row, Item.ValueCells[0].Column].Value = image;
                             }
                             break;


                        case clsScreenInfo.MACRO_RULE.BD_IMAGE_RULE:

                            if (DataMap.Contains(Member) == true)
                            {
                                if (Directory.Exists(BasePath) == false)
                                {
                                    Directory.CreateDirectory(BasePath);
                                }

                                for (int i = 0; i < Item.ValueCells.Count; i++)
                                {
                                    sPathImage = BasePath + (string)((Data_Tag)DataMap[Member]).Value[0] + ".jpg";

                                    FarPoint.Win.Spread.CellType.ImageCellType ImageCellType = new FarPoint.Win.Spread.CellType.ImageCellType();
                                    ImageCellType.Style = FarPoint.Win.RenderStyle.StretchAndScale;
                                    spdSpread.ActiveSheet.Cells[Item.ValueCells[0].Row, Item.ValueCells[0].Column].CellType = ImageCellType;
                                    System.Drawing.Image image = System.Drawing.Image.FromFile(sPathImage);
                                    //System.IO.MemoryStream stream = new System.IO.MemoryStream();
                                    //image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                                    spdSpread.ActiveSheet.Cells[Item.ValueCells[0].Row, Item.ValueCells[0].Column].Value = image;
                                }
                            }

                            break;

                        case clsScreenInfo.MACRO_RULE.MK_IMAGE_RULE:

                            break;
                        default:
                            break;
                    }
                    ScreenMapOther.Remove(Member);
                }

                if (ScreenMapOther.Count > 0)
                {
                    int index = spdSpread.ActiveSheet.RowCount;

                    foreach (string Member in ScreenMapOther.Keys)
                    {
                        clsScreenInfo Item = (clsScreenInfo)ScreenMapOther[Member];
                        if (DataMap.Contains(Member) == true)
                        {
                            for (int i = Item.ValueCells.Count - 1; i >= 0; i--)
                            {
                               iSpanRow = 0;
                               iSpanRowCount = 0;

                                for (int j = 0; j < ((Data_Tag)DataMap[Member]).Value.Count; j++)
                                {
                                    if (index <= Item.ValueCells[i].Row + j + iSpanRow || spdSpread.ActiveSheet.Cells[Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column].Value != null)
                                    {
                                        FarPoint.Win.Spread.Model.CellRange range =
                                        new FarPoint.Win.Spread.Model.CellRange(
                                            spdSpread.ActiveSheet.RowCount - iSpanRowCount,
                                            0,
                                            iSpanRowCount,
                                            spdSpread.ActiveSheet.ColumnCount);

                                        spdSpread.ActiveSheet.AddRows(Item.ValueCells[i].Row + j + iSpanRow, iSpanRowCount);
                                        spdSpread.ActiveSheet.ClipboardCopy(range, FarPoint.Win.Spread.ClipboardCopyOptions.All);

                                        range.Row = range.Row + iSpanRowCount;
                                        spdSpread.ActiveSheet.SetActiveCell(range.Row, 0);
                                        spdSpread.ActiveSheet.ClipboardPaste(FarPoint.Win.Spread.ClipboardPasteOptions.All);
                                        spdSpread.ActiveSheet.ClearRange(range.Row, range.Column, range.RowCount, range.ColumnCount, true);
                                        index += iSpanRowCount;
                                    }
                                    FillData(Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column, ((Data_Tag)DataMap[Member]).Name, ((Data_Tag)DataMap[Member]).DataType, (string)((Data_Tag)DataMap[Member]).Value[j]);

                                    if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column) != null)
                                    {
                                        if (spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column).RowCount > 1)
                                        {
                                            iSpanRowCount = spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column).RowCount;
                                            iSpanRow = iSpanRow + spdSpread.ActiveSheet.GetSpanCell(Item.ValueCells[i].Row + j + iSpanRow, Item.ValueCells[i].Column).RowCount - 1;
                                            
                                        }
                                    }
                                    else
                                    {
                                        iSpanRow++;
                                        iSpanRowCount = 1;
                                    }
                                }
                            }
                        }
                    }

                }

                for (int r = 0; r < spdSpread.ActiveSheet.Rows.Count; r++)
                {
                    bool b_continue = false;
                    bool b_newline = false;
                    for (int c = 0; c < spdSpread.ActiveSheet.Columns.Count; c++)
                    {
                        if (spdSpread.ActiveSheet.Cells[r, c].CellType != null &&
                            (spdSpread.ActiveSheet.Cells[r, c].CellType.ToString() == "BarCodeCellType" ||
                                spdSpread.ActiveSheet.Cells[r, c].CellType.ToString() == "ImageCellType"))
                        {
                            b_continue = true;
                            break;
                        }

                        if (spdSpread.ActiveSheet.Cells[r, c].Value != null &&
                            spdSpread.ActiveSheet.Cells[r, c].CellType != null &&
                            spdSpread.ActiveSheet.Cells[r, c].CellType.ToString() == "TextCellType")
                        {
                            if (spdSpread.ActiveSheet.Cells[r, c].ColumnSpan > 1)
                            {
                                var cellType = spdSpread.ActiveSheet.Cells[r, c].CellType as TextCellType;
                                cellType.WordWrap = false;
                            }

                            if (spdSpread.ActiveSheet.Cells[r, c].Value.ToString().Contains("\r") ||
                                spdSpread.ActiveSheet.Cells[r, c].Value.ToString().Contains("\n"))
                            {
                                b_newline = true;
                                break;
                            }
                        }

                    }

                    if (!b_continue && b_newline)
                        spdSpread.ActiveSheet.Rows[r].Height = spdSpread.ActiveSheet.Rows[r].GetPreferredHeight();
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
        /// Lock Spread Cell
        /// </summary>
        /// <param name="Row">Row number</param>
        /// <param name="Column">Column number</param>
        /// <param name="Locked">True - Lock, False - Unlock</param>
        public void ChangeLockStatus(int Row, int Column, bool Locked)
        {
            try
            {
                spdSpread.ActiveSheet.Cells[Row, Column].Locked = Locked;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        /// Whole spread sheet cell lock or unlock
        /// </summary>
        /// <param name="locked">true : lock</param>
        /// <param name="locked">false : unlock</param>
        public void SpreadLock(bool locked)
        {
            try
            {
                spdSpread.ActiveSheet.DefaultStyle.Locked = locked;
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
                spdSpread.ActiveSheet.PrintInfo.UseSmartPrint = true;
                spdSpread.ActiveSheet.PrintInfo.SmartPrintPagesTall = 1;
                spdSpread.ActiveSheet.PrintInfo.SmartPrintPagesWide = 1;
                spdSpread.ActiveSheet.PrintInfo.ShowGrid = false;

                spdSpread.ActiveSheet.PrintInfo.Centering = FarPoint.Win.Spread.Centering.Both;

                spdSpread.ActiveSheet.ColumnHeaderVisible = false;
                spdSpread.ActiveSheet.RowHeaderVisible = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdSpread_Resize(object sender, EventArgs e)
        {
            try
            {
                if (m_AutoStretch == false)
                    return;

                for (int iCol = 0; iCol < spdSpread.ActiveSheet.ColumnCount; iCol++)
                {
                        //spdSpread.ActiveSheet.Columns[iCol].Width = spdSpread.ActiveSheet.Columns[iCol].Width - (spdSpread.Width - this.MinimumSize.Width) / spdSpread.ActiveSheet.ColumnCount;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        //public bool ChangeCellType(int Column, MPSC.CELL_TYPE CellType)
        //{
        //    try
        //    {
        //        switch (CellType)
        //        {
        //            case MPSC.CELL_TYPE.BUTTON_TYPE:
        //                FarPoint.Win.Spread.CellType.ButtonCellType BtnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
        //                spdSpread.ActiveSheet.Columns.Get(Column).CellType = BtnCellType;
        //                break;
        //            case MPSC.CELL_TYPE.CHECKBOX_TYPE:
        //                FarPoint.Win.Spread.CellType.CheckBoxCellType ChkCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
        //                spdSpread.ActiveSheet.Columns.Get(Column).CellType = ChkCellType;
        //                break;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        /// <summary>
        /// 프린트 Top 마진을 변경한다.
        /// </summary>
        /// <param name="Top">Top 마진</param>        
        /// <returns></returns>
        public bool ChangeMarginTop(int Margin)
        {
            try
            {
                spdSpread.ActiveSheet.PrintInfo.Margin.Top = Margin;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 프린트 Bottom 마진을 변경한다.
        /// </summary>
        /// <param name="Bottom">Bottom 마진</param>        
        /// <returns></returns>
        public bool ChangeMarginBottom(int Margin)
        {
            try
            {
                spdSpread.ActiveSheet.PrintInfo.Margin.Bottom = Margin;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 프린트 Left 마진을 변경한다.
        /// </summary>
        /// <param name="Left">Left 마진</param>        
        /// <returns></returns>
        public bool ChangeMarginLeft(int Margin)
        {
            try
            {                               
                spdSpread.ActiveSheet.PrintInfo.Margin.Left = Margin;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 프린트 Right 마진을 변경한다.
        /// </summary>
        /// <param name="Right">Right 마진</param>        
        /// <returns></returns>
        public bool ChangeMarginRight(int Margin)
        {
            try
            {
                spdSpread.ActiveSheet.PrintInfo.Margin.Right = Margin;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 프린트 출력 방향을 변경한다.
        /// </summary>
        /// <param name="bPortrait">세로 출력 여부</param>        
        /// <returns></returns>
        public bool ChangePrintType(bool bPortrait)
        {
            try
            {

                FarPoint.Win.Spread.SmartPrintRulesCollection rules = new FarPoint.Win.Spread.SmartPrintRulesCollection();
                FarPoint.Win.Spread.SmartPrintRule spr;

                spr = new FarPoint.Win.Spread.BestFitColumnRule(FarPoint.Win.Spread.ResetOption.None);
                rules.Add(new FarPoint.Win.Spread.ScaleRule(FarPoint.Win.Spread.ResetOption.All, 1.0f, 0.0f, 0.2f));

                if (bPortrait == true)
                {
                    spdSpread.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                    rules.Add(new FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None));
                }
                else
                {
                    spdSpread.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                    rules.Add(new FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.All));
                }
                rules.Add(spr);

                spdSpread.ActiveSheet.PrintInfo.SmartPrintRules = rules;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }               

        /// <summary>
        /// 해당 로우 헤더 컬럼 수를 정한다.
        /// </summary>
        /// <param name="iCount"> 로우 헤더 컬럼 수</param>        
        /// <returns></returns>
        public bool ChangeRowHeaderColumnCount(int iCount)
        {
            try
            {
                spdSpread.ActiveSheet.RowHeaderColumnCount = iCount;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 해당 컬럼 헤더 로우 수를 정한다.
        /// </summary>
        /// <param name="iCount"> 컬럼 헤더 로우 수</param>        
        /// <returns></returns>
        public bool ChangeColumnHeaderRowCount(int iCount)
        {
            try
            {
                spdSpread.ActiveSheet.ColumnHeaderRowCount = iCount;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 프린트 할 페이퍼 사이즈를 정한다.
        /// </summary>
        /// <param name="sPaperSize"> 페이퍼 사이즈</param>        
        /// <returns></returns>
        public bool SetPaperSize(Size sPaperSize)
        {
            try
            {
                //spdSpread.ActiveSheet.PrintInfo.PaperSize = new System.Drawing.Printing.PaperSize("PAPER", sPaperSize.Width, sPaperSize.Height);
                // PaperSize를 주면 Print 안됨..;;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }     

        /// <summary>
        /// 해당 시트를 출력한다.
        /// </summary>
        /// <param name="iSheet"> 출력할 시트 번호</param>        
        /// <returns></returns>
        public bool Print(int iSheet)
        {
            int i;
            int iPageBreakCount = 0;
            int[] iPageBreakRow;

            try
            {
                iPageBreakRow = new int[spdSpread.ActiveSheet.RowCount];

                for (i = 0; i < spdSpread.ActiveSheet.RowCount; i++)
                {
                    if (spdSpread.ActiveSheet.Rows[i].PageBreak == true)
                    {
                        iPageBreakRow[iPageBreakCount] = i;
                        iPageBreakCount++;
                    }
                }

                // PageBreak가 설정된 Template의 Row의 +1을 하여 PageBreak를 재 설정한다.
                // 재설정을 하지 않으면 해당 다음 Template이 나올때 해당 Template의 맨마지막 Row도 찍혀서 나옴.
                // 마지막 Template에 PageBreak가 설정되어 있으면 설정되어 있는 PageBreak를 없앤다.
                for (i = 0; i < iPageBreakCount; i++)
                {
                    if (iPageBreakRow[i] < spdSpread.ActiveSheet.RowCount-1)
                    {
                        spdSpread.ActiveSheet.Rows[iPageBreakRow[i]].PageBreak = false;
                        spdSpread.ActiveSheet.Rows[iPageBreakRow[i] + 1].PageBreak = true;
                    }
                    else if (iPageBreakRow[i] == spdSpread.ActiveSheet.RowCount-1)
                    {
                        spdSpread.ActiveSheet.Rows[iPageBreakRow[i]].PageBreak = false;
                    }
                }

                spdSpread.PrintSheet(iSheet);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
    }
}
