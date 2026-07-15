using System.ComponentModel;
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupDocumentDesign.cs
//   Description : Create/Update/Delete Template Design Form
//
//   MES Version : 5.2
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_LabelDesign() : View Template Design definition
//       - Update_LabelDesign() : Create/Update/Delete Template Design definition
//       - initCodeView() :   initial CodeView Control
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2012-04-15 : Created by Patrick Choi
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _POP = True Then


namespace Miracom.BASCore
{
    public partial class frmBASSetupDocumentDesign : Miracom.MESCore.SetupForm01
    {               

        public frmBASSetupDocumentDesign()
        {
            InitializeComponent();
        }

        public frmBASSetupDocumentDesign(string sFormatID, string sDescription)
        {
            InitializeComponent();
            sFormat = sFormatID;
            sDesc = sDescription;
        }

        #region "Constant Defintion"
        
        private const int COL_DOT_ID = 0;
        private const int COL_DOT_DESC = 1;
        private const int COL_DOT_SEQ = 2;
        private const int COL_DOT_LEFT = 3;
        private const int COL_DOT_SPACE = 4;
        private const int COL_DOT_START = 5;
        private const int COL_DOT_STOP = 6;        
        private const int COL_DOT_KEEP_LINE_FLAG = 7;
        private const int COL_DOT_KEEP_LINE = 8;
        private const int COL_DOT_HEADER = 9;
        private const int COL_DOT_PAGE = 10;      
        
        #endregion
        
        #region "Variable Definition"
        
        private bool b_load_flag;
               
        string sFormat;
        string sDesc;
        private string s_base_path;

        private int iHeight;
        private int iRow; 
        private int iPreCol; 
        private int iPreRow; 

        //헤더 테이블
        private struct HEADER_TABLE
        {
            public string s_xml;
            public string s_start;
            public string s_stop;
            public string s_left;
            public string s_space;
        }

        #endregion
        
        #region "Function Definition"


        /// <summary>
        /// Spread Size 셋업
        /// </summary>
        /// <param name="sTempID"> Template ID</param>        
        /// <returns>true or false</returns>    
        private bool SetSize(string sTempID)
        {
            TRSNode in_node = new TRSNode("View_Doc_Temp_IN");
            TRSNode out_node = new TRSNode("View_Doc_Temp_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOT_ID", sTempID);

                if (MPCR.CallService("BAS", "BAS_View_Document_Template", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < spdDesign.ActiveSheet.RowCount; i++)
                {
                    spdDesign.ActiveSheet.SetRowHeight(i, out_node.GetInt("ROW_HEIGHT"));
                    for (int j = 0; j < spdDesign.ActiveSheet.ColumnCount; j++)
                    {
                        spdDesign.ActiveSheet.SetColumnWidth(j, out_node.GetInt("COLUMN_WIDTH"));
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
        /// Preview mixed template
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>  
        private bool PreviewImage()
        {
            string sPathXML;            
            int i, j;
            int iCount = 0;
            bool bPageBreak = false;
            int iPageNum = 1;
            FarPoint.Win.Spread.FpSpread spdTemp;

            try
            {
                HEADER_TABLE[] sHeader = new HEADER_TABLE[lisAttachTemplate.Items.Count-1];                
                //FarPoint.Win.Spread.DrawingSpace.RectangleShape ps;

                //헤더 템플릿 할당
                for (i = 0; i < lisAttachTemplate.Items.Count-1; i++)
                {
                    if(lisAttachTemplate.Items[i].SubItems[COL_DOT_HEADER].Text == "Y")
                    {
                        sHeader[iCount].s_xml = s_base_path + lisAttachTemplate.Items[i].Text + ".xml";
                        sHeader[iCount].s_start = lisAttachTemplate.Items[i].SubItems[COL_DOT_START].Text;
                        sHeader[iCount].s_stop = lisAttachTemplate.Items[i].SubItems[COL_DOT_STOP].Text;
                        sHeader[iCount].s_left = lisAttachTemplate.Items[i].SubItems[COL_DOT_LEFT].Text;
                        sHeader[iCount].s_space = lisAttachTemplate.Items[i].SubItems[COL_DOT_SPACE].Text;
                        iCount++;  
                    }
                }

                iHeight = iRow = iPreRow = 0;

                MPCF.ClearList(spdDesign);
                spdDesign.SuspendLayout();

                // Attach된 Template이 하나인 경우는 바로 화면에 뿌린다
                if (lisAttachTemplate.Items.Count - 1 == 1)
                {
                    sPathXML = s_base_path + lisAttachTemplate.Items[0].Text + ".xml";
                    spdDesign.Open(sPathXML);
                    spdDesign.ResumeLayout();
                    return true;
                }

                for (i = 0; i < lisAttachTemplate.Items.Count-1; i++)
                {
                    if(tabDesign.SelectedTab == tbpDocDesign)
                        pgcMake.Increment((int)((double)1 / (double)lisAttachTemplate.Items.Count * 80));
                    else if (tabDesign.SelectedTab == tbpPreview)
                        pgcPreview.Increment( (int)( (double)1 / (double)lisAttachTemplate.Items.Count * 80) );

                    //페이지 브레이크 갱신 되면
                    if(bPageBreak == true || i == 0)
                    {
                        for (j = 0; j < sHeader.Length; j++)
                        {
                            //시작 페이지 부터 중지 페이지 까지 헤더 표기
                            if (sHeader[j].s_start != null &&
                                sHeader[j].s_stop != null)
                            {
                                if (MPCF.ToInt(sHeader[j].s_start.Trim()) <= iPageNum &&
                                    MPCF.ToInt(sHeader[j].s_stop.Trim()) >= iPageNum)
                                {
                                    if (sHeader[j].s_xml.Trim() != "")
                                    {
                                        //MPCF.ClearList(spdT);
                                        spdTemp = new FpSpread();
                                        sPathXML = sHeader[j].s_xml.Trim();
                                        spdTemp.Open(sPathXML);                                        

                                        //Add template each other
                                        if (TemplateAdd(spdTemp, spdDesign,
                                                        sHeader[j].s_left.Trim(), sHeader[j].s_space.Trim(),
                                                        i, "", iPageNum, "", 0) == false)
                                            return false;                                        
                                    }
                                }
                            }
                        }
                        if (i == 0)
                            continue;
                    }                    

                    //MPCF.ClearList(spdT);
                    spdTemp = new FpSpread();
                    sPathXML = s_base_path + lisAttachTemplate.Items[i].Text + ".xml";
                    spdTemp.Open(sPathXML);                    

                    //Add template each other
                    if (TemplateAdd(spdTemp, spdDesign,                                        
                                    lisAttachTemplate.Items[i].SubItems[COL_DOT_LEFT].Text.Trim(),
                                    lisAttachTemplate.Items[i].SubItems[COL_DOT_SPACE].Text.Trim(),
                                    i, lisAttachTemplate.Items[i].SubItems[COL_DOT_PAGE].Text.Trim(), iPageNum,
                                    lisAttachTemplate.Items[i].SubItems[COL_DOT_KEEP_LINE_FLAG].Text.Trim(),
                                    MPCF.ToInt(lisAttachTemplate.Items[i].SubItems[COL_DOT_KEEP_LINE].Text.Trim()) ) == false)
                        return false;                    
                   
                    //헤더 여부 체크                    
                    if (spdDesign.ActiveSheet.Rows[spdDesign.ActiveSheet.RowCount - 1].PageBreak == true)
                    {
                        bPageBreak = true;
                        iPageNum++;
                    }
                    else
                        bPageBreak = false;
                   
                }
                spdDesign.ResumeLayout();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                //spdT.Visible = false;
            }
        }

        /// <summary>
        /// Add template each other
        /// </summary>
        /// <param name="spdTemp"> Source Spread</param>        
        /// <param name="spdDesign"> Copy Spread</param>        
        /// <param name="sLeft"> Point of startting from left</param>        
        /// <param name="sSpace"> Row of startting from previous template</param>        
        /// <param name="iPresentRow"> Present row</param>        
        /// <param name="sPageBreak"> Page break</param>        
        /// <param name="iPageNum"> Page number</param>        
        /// <param name="sKeepLine"> Keep Line</param>        
        /// <param name="iKeepLine"> Start point by Keep Line</param>        
        /// <returns>true or false</returns>  
        private bool TemplateAdd(FarPoint.Win.Spread.FpSpread spdTemp, FarPoint.Win.Spread.FpSpread spdDesign,
                                string sLeft, string sSpace, int iPresentRow,
                                string sPageBreak, int iPageNum, string sKeepLine,
                                int iKeepLine)
        {
            FarPoint.Win.Spread.Model.DefaultSheetSelectionModel defselModel = new FarPoint.Win.Spread.Model.DefaultSheetSelectionModel();
            
            try
            {
                spdTemp.ActiveSheet.Models.Selection = defselModel;
                defselModel.AddSelection(0, 0, spdTemp.ActiveSheet.RowCount, spdTemp.ActiveSheet.ColumnCount);                

                if (iPresentRow == 0)
                {
                    spdDesign.ActiveSheet.ColumnCount = spdTemp.ActiveSheet.ColumnCount;
                    spdDesign.ActiveSheet.RowCount = spdTemp.ActiveSheet.RowCount;
                    SetSize(lisAttachTemplate.Items[0].Text);
                    spdDesign.ActiveSheet.SetActiveCell(0, 0);                        
                }
                else
                {
                    if (sKeepLine == "Y")
                    {
                        if (iKeepLine == 0)
                        {
                            if (spdDesign.ActiveSheet.ColumnCount < spdTemp.ActiveSheet.ColumnCount + iPreCol)
                            {
                                spdDesign.ActiveSheet.ColumnCount += spdTemp.ActiveSheet.ColumnCount + iPreCol - spdDesign.ActiveSheet.ColumnCount;
                            }

                            if (spdDesign.ActiveSheet.RowCount < spdTemp.ActiveSheet.RowCount + iPreRow)
                            {
                                spdDesign.ActiveSheet.RowCount += spdTemp.ActiveSheet.RowCount + iPreRow - spdDesign.ActiveSheet.RowCount;
                            }

                            spdDesign.ActiveSheet.SetActiveCell(iPreRow, iPreCol);
                        }
                        else
                        {
                            if (spdDesign.ActiveSheet.ColumnCount < spdTemp.ActiveSheet.ColumnCount + iKeepLine)
                            {
                                spdDesign.ActiveSheet.ColumnCount += spdTemp.ActiveSheet.ColumnCount + iKeepLine - spdDesign.ActiveSheet.ColumnCount;
                            }

                            if (spdDesign.ActiveSheet.RowCount < spdTemp.ActiveSheet.RowCount + iPreRow)
                            {
                                spdDesign.ActiveSheet.RowCount += spdTemp.ActiveSheet.RowCount + iPreRow - spdDesign.ActiveSheet.RowCount;
                            }

                            spdDesign.ActiveSheet.SetActiveCell(iPreRow, iKeepLine);
                        }
                    }
                    else
                    {                        

                        spdDesign.ActiveSheet.RowCount = iRow + spdTemp.ActiveSheet.RowCount +
                                MPCF.ToInt(sSpace.Trim());

                        spdDesign.ActiveSheet.ColumnCount += MPCF.ToInt(sLeft.Trim());

                        spdDesign.ActiveSheet.SetActiveCell(iRow +
                                MPCF.ToInt(sSpace.Trim()),
                                MPCF.ToInt(sLeft.Trim()) + 0);
                    }
                }
                
                spdTemp.ActiveSheet.ClipboardCopy(ClipboardCopyOptions.All);
                spdDesign.ActiveSheet.ClipboardPaste();

                for (int j = 0; j < spdTemp.ActiveSheet.DrawingContainer.ContainedObjects.Count; j++)
                {
                    FarPoint.Win.Spread.DrawingSpace.PSShape ps;
                    ps = (FarPoint.Win.Spread.DrawingSpace.PSShape)spdTemp.ActiveSheet.DrawingContainer.ContainedObjects[j];
                    ps.Name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + j;  // Shape ID 재 부여
                    Point p = ps.Location;                                     // 기존 위치 저장
                    // 새 위치에 Shape 추가
                    spdDesign.ActiveSheet.AddShape(ps, spdDesign.ActiveSheet.ActiveCell.Row.Index, spdDesign.ActiveSheet.ActiveCell.Column.Index);
                    ps.Location = new Point(p.X + ps.Location.X, p.Y + ps.Location.Y);  // 위치 조정
                }
                //spdDesign.ActiveSheet.PrintInfo.Orientation = PrintOrientation.Landscape;
                iHeight += spdTemp.Height;

                //이전 컬럼 저장
                iPreCol = spdTemp.ActiveSheet.ColumnCount;
                iPreRow = spdDesign.ActiveSheet.RowCount - spdTemp.ActiveSheet.RowCount - MPCF.ToInt(sSpace.Trim());
                iRow += spdTemp.ActiveSheet.RowCount + MPCF.ToInt(sSpace.Trim());

                if (sPageBreak == "Y")
                {
                    spdDesign.ActiveSheet.Rows[spdDesign.ActiveSheet.RowCount - 1].PageBreak = true;
                }
                else
                    spdDesign.ActiveSheet.Rows[spdDesign.ActiveSheet.RowCount - 1].PageBreak = false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Check Condition
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            try
            {
                switch (FuncName.TrimEnd())
                {
                    case "Add_Template":

                        if (ProcStep == MPGC.MP_STEP_CREATE)
                        {
                            if (lisAvailTemplate.SelectedIndices.Count == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisAvailTemplate.Focus();
                                return false;
                            }

                            if (lisAttachTemplate.SelectedIndices.Count == 0)
                            {
                                return false;
                            }
                        }
                        else if (ProcStep == MPGC.MP_STEP_DELETE)
                        {
                            if (lisAttachTemplate.SelectedIndices.Count == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisAttachTemplate.Focus();
                                return false;
                            }
                        }
                        break;
                    case "Update_Template":                                               
                        
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
                                                            
                                break;
                                
                                
                            case MPGC.MP_STEP_UPDATE:
                                if (chkHeaderFlag.Checked == true && (txtStart.Text == "0" || txtStop.Text == "0" ))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(341));
                                    chkHeaderFlag.Focus();
                                    return false;
                                }

                                if (chkHeaderFlag.Checked == true && chkPageBreak.Checked == true)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(337));
                                    chkHeaderFlag.Focus();
                                    return false;
                                }
                                                                                                
                                break;
                                
                            case MPGC.MP_STEP_DELETE:
                                
                                break;
                                
                        }
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
        /// <summary>
        /// Initalize form fields
        /// </summary>
        /// <param name="ProcStep">Step</param>        
        /// <returns>true or false</returns>        
        private void ClearData(char ProcStep)
        {
            
            try
            {
                
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this,txtFormat,txtDesc);
                    MPCF.ClearList(spdDesign);
                }
                else if (ProcStep == '2')
                {
                    //FieldClear(Me.pnlCenter, cdvLabel.Text)                    
                    MPCF.ClearList(spdDesign);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        /// <summary>
        /// View template design
        /// </summary>
        /// <param name="ProcStep">Step</param>        
        /// <returns>true or false</returns>    
        private bool View_Template_Design(char ProcStep)
        {
            
            TRSNode in_node = new TRSNode("BAS_VIEW_TEMPLATE_DESIGN_IN");
            TRSNode out_node = new TRSNode("BAS_VIEW_TEMPLATE_DESING_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("DOF_ID", MPCF.Trim(txtFormat.Text));
                in_node.AddString("DOT_ID", lisAttachTemplate.SelectedItems[0].Text);
                in_node.SetInt("DOT_SEQ", lisAttachTemplate.SelectedItems[0].Index+1);
                
                if (MPCR.CallService("BAS", "BAS_View_Document_Design", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                
                txtLeft.Text = out_node.GetInt("LEFT_POSITION").ToString();
                txtSpaceCount.Text = out_node.GetInt("SPACE_COUNT").ToString();
                txtStart.Text = out_node.GetInt("START_PAGE").ToString();
                txtStop.Text = out_node.GetInt("STOP_PAGE").ToString();

                if (out_node.GetChar("KEEP_LINE_FLAG") == 'Y')
                {
                    chkKeepLine.Checked = true;
                    txtKeepLine.Text = out_node.GetInt("KEEP_LINE").ToString();
                }
                else
                {
                    chkKeepLine.Checked = false;
                    txtKeepLine.Text = "";
                }

                if(out_node.GetChar("HEADER_FLAG")=='Y')
                    chkHeaderFlag.Checked = true;
                else
                    chkHeaderFlag.Checked = false;

                if (out_node.GetChar("PAGE_BREAK") == 'Y')
                    chkPageBreak.Checked = true;
                else
                    chkPageBreak.Checked = false;                


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// View attached template design list
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>    
        private bool View_Template_Design_List()
        {
            
            int i;
            
            ListViewItem itmX;
            
            TRSNode in_node = new TRSNode("View_Template_Design_In");
            TRSNode out_node = new TRSNode("View_Template_Design_Out");
            
            try
            {
                //ClearData('1')
                MPCF.InitListView(lisAttachTemplate);
    
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOF_ID", MPCF.Trim(txtFormat.Text));
                
                do
                {
                    
                    if (MPCR.CallService("BAS", "BAS_View_Document_Design_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    //txtFormat.Text = out_node.GetString("DOF_ID");
                    //txtDesc.Text = out_node.GetString("DOF_DESC");

                    //itmX = new ListViewItem("Attached ...");
                    //itmX.SubItems.Add(" ");
                    //itmX.SubItems.Add(" ");
                    //itmX.SubItems.Add("0");
                    //itmX.SubItems.Add("0");
                    //itmX.SubItems.Add("0");
                    //itmX.SubItems.Add("0");
                    //itmX.SubItems.Add(" ");
                    //itmX.SubItems.Add(" ");
                    //((ListView)lisAttachTemplate).Items.Add(itmX);                        

                    for (i = 0; i < out_node.GetList("DOF_LIST").Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList("DOF_LIST")[i].GetString("DOT_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                        if (((ListView)lisAttachTemplate).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetString("DOT_DESC"));
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("DOT_SEQ").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("LEFT_POSITION").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("SPACE_COUNT").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("START_PAGE").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("STOP_PAGE").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetChar("KEEP_LINE_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetInt("KEEP_LINE").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetChar("HEADER_FLAG").ToString());
                            itmX.SubItems.Add(out_node.GetList("DOF_LIST")[i].GetChar("PAGE_BREAK").ToString());                                                        
                        }
                        ((ListView)lisAttachTemplate).Items.Add(itmX);                        
                    }

                    in_node.SetInt("NEXT_DOT_SEQ", out_node.GetInt("NEXT_DOT_SEQ"));
                } while (in_node.GetInt("NEXT_DOT_SEQ") > 0);

                itmX = lisAttachTemplate.Items.Insert(lisAttachTemplate.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                itmX.SubItems.Add("");

                //lisAttachOper.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_OPER);
                lisAttachTemplate.Items[0].Selected = true;
                lisAttachTemplate.Items[0].EnsureVisible();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        /// <summary>
        /// View template list is possible
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>    
        private void View_Attach_Template_Design()
        {
            if (BASLIST.ViewDocTempList(lisAvailTemplate, '1', "", MPGV.gsFactory, null, "", false) == true)
            {
                
            }
        }

        /// <summary>
        /// 스프레시 시트 XML 파일을 갱신한다.
        /// </summary>
        /// <param name="out_node">out_node of TRSNode</param>        
        /// <returns>true or false</returns>
        private bool UpdateDocTempXML(TRSNode out_node, string sTemp)
        {
            try
            {
                string sPath = s_base_path + sTemp;
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
        /// 해당 스프레드 XML 파일을 확인한다.
        /// </summary>
        /// <param name></param>        
        /// <returns>true or false</returns>
        private bool CheckTemp(string sTemp)
        {
            string sPathZip;            
            string sCreateTime;

            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Temp_IN");
            TRSNode out_node = new TRSNode("View_Temp_OUT");

            try
            {
                if (lisAttachTemplate.Items.Count < 0)
                    return false;

                sPathZip = s_base_path + sTemp + ".gzip";
                if (Directory.Exists(s_base_path) == false)
                {
                    Directory.CreateDirectory(s_base_path);
                }

                FileInfo fi = new FileInfo(sPathZip);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DOT_ID", sTemp);

                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19001231000000");
                    in_node.AddInt("FILE_SIZE", 0);
                }
                else
                {
                    create_time = fi.CreationTime;
                    sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    iFileSize = fi.Length;

                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }


                if (MPCR.CallService("BAS", "BAS_Check_DocTemp", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateDocTempXML(out_node, sTemp);
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
        /// Update template design
        /// </summary>
        /// <param name="ProcStep">Step</param>        
        /// <returns>true or false</returns>    
        private bool Update_Template(char ProcStep, bool bShowSuccessMsg)
        {
            string sPath = string.Empty;
            TRSNode in_node = new TRSNode("Update_Template_In");
            TRSNode out_node = new TRSNode("Cmn_Out");            
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("DOF_ID", txtFormat.Text.TrimEnd());

                if (in_node.ProcStep == MPGC.MP_STEP_CREATE)
                {
                    in_node.SetString("DOT_ID", lisAvailTemplate.SelectedItems[0].SubItems[COL_DOT_ID].Text);
                    in_node.SetInt("DOT_SEQ", lisAttachTemplate.SelectedItems[0].Index+1);
                }
                else
                {
                    in_node.SetString("DOT_ID", lisAttachTemplate.SelectedItems[0].SubItems[COL_DOT_ID].Text);
                    in_node.SetInt("DOT_SEQ", lisAttachTemplate.SelectedItems[0].Index+1);
                    
                }

                in_node.SetInt("LEFT_POSITION", txtLeft.Text);
                in_node.SetInt("SPACE_COUNT", txtSpaceCount.Text);
                in_node.SetInt("START_PAGE", txtStart.Text);
                in_node.SetInt("STOP_PAGE", txtStop.Text);

                if (chkHeaderFlag.Checked == true)
                    in_node.SetChar("HEADER_FLAG", 'Y');
                else
                    in_node.SetChar("HEADER_FLAG", ' ');
                if (chkPageBreak.Checked == true)
                    in_node.SetChar("PAGE_BREAK", 'Y');
                else
                    in_node.SetChar("PAGE_BREAK", ' ');
                if (chkKeepLine.Checked == true)
                {
                    in_node.SetChar("KEEP_LINE_FLAG", 'Y');
                    in_node.SetInt("KEEP_LINE", txtKeepLine.Text);
                }
                else
                    in_node.SetChar("KEEP_LINE_FLAG", ' ');


                if (in_node.ProcStep == MPGC.MP_STEP_COPY)
                {
                    sPath = s_base_path + MPCF.Trim(txtFormat.Text);

                    if (Directory.Exists(s_base_path) == false)
                    {
                        Directory.CreateDirectory(s_base_path);
                    }

                    spdDesign.Save(sPath + ".xml", false);
                    MPCR.ZipCompress(sPath);

                    // Add Template file
                    {
                        FileInfo finfo;
                        BinaryReader br;
                        byte[] file_buffer;

                        finfo = new FileInfo(sPath + ".gzip");
                        if (finfo.Exists == true)
                        {
                            br = new BinaryReader(finfo.OpenRead());
                            file_buffer = br.ReadBytes((int)finfo.Length);
                            in_node.AddBlob(MPGC.MP_BIN_DATA_2, file_buffer);
                            br.Close();
                        }
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Document_Design", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (bShowSuccessMsg == true)
                    MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }                               
        
        #endregion

        #region " Event Definition "
        private void frmBASSetupDocumentDesign_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                ClearData('1');
                
                //sngRatio = (float)nudRatio.Value / 100;

                b_load_flag = true;
                txtFormat.Text = sFormat;
                txtDesc.Text = sDesc;
                btnRefresh.PerformClick();
                
            }
        }                                      
        
        private void cdvRotate_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdDesign.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisAttachTemplate.SelectedItems[0].Index == lisAttachTemplate.Items.Count - 1)
                    return;

                if (CheckCondition("Update_Template", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Template(MPGC.MP_STEP_UPDATE, true) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    View_Template_Design_List();

                    if(lisAttachTemplate.Items.Count > 1)
                        lisAttachTemplate.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
  
                              
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            //if (cdvLabel.Text.Trim() != "")
            {
                ClearData('2');
                View_Attach_Template_Design();
                View_Template_Design_List();

                //if (lisAttachTemplate.Items.Count < 1)
                //{
                //    txtFormat.Text = sFormat;
                //    txtDesc.Text = sDesc;
                //}
            }
        }
        
        private void chkPreView_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i_select = 0;
            ListViewItem itm;

            try
            {
                if (CheckCondition("Add_Template", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                if (Update_Template(MPGC.MP_STEP_CREATE, false) == true)
                {
                    itm = new ListViewItem(MPCF.Trim(lisAvailTemplate.SelectedItems[0].Text), (int)SMALLICON_INDEX.IDX_MESSAGE_GROUP);
                    itm.SubItems.Add(MPCF.Trim(lisAvailTemplate.SelectedItems[0].SubItems[1].Text));
                    itm.SubItems.Add("0");
                    itm.SubItems.Add("0");
                    itm.SubItems.Add("0");
                    itm.SubItems.Add("0");
                    itm.SubItems.Add("0");
                    itm.SubItems.Add(" ");
                    itm.SubItems.Add("0");
                    itm.SubItems.Add(" ");
                    itm.SubItems.Add(" ");

                    i_select = lisAttachTemplate.SelectedItems[0].Index;
                    lisAttachTemplate.Items.Insert(i_select, itm);

                    if (lisAvailTemplate.SelectedItems[0].Index + 1 < lisAvailTemplate.Items.Count)
                    {
                        lisAvailTemplate.Items[lisAvailTemplate.SelectedItems[0].Index + 1].Selected = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int iIndex = 0;

            try
            {
                if (CheckCondition("Add_Template", MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                iIndex = lisAttachTemplate.SelectedItems[0].Index;
                if (Update_Template(MPGC.MP_STEP_DELETE, false) == true)
                {
                    lisAttachTemplate.Items.RemoveAt(iIndex);

                    if (lisAttachTemplate.Items.Count - 1 == iIndex && iIndex > 0)
                    {
                        iIndex--;
                    }
                    lisAttachTemplate.Items[iIndex].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tabDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDesign.SelectedTab == tbpPreview)
            {                
                pgcPreview.Value = 0;
                pgcPreview.Visible = true;
                pgcPreview.Increment(10);

                btnUpdate.Enabled = false;
                for (int i = 0; i < lisAttachTemplate.Items.Count-1; i++)
                {
                    CheckTemp(lisAttachTemplate.Items[i].Text);
                }
                PreviewImage();

                pgcPreview.Increment(100);
                pgcPreview.Visible = false;                
            }
            else
                btnUpdate.Enabled = true;
        }

        private void frmBASSetupDocumentDesign_Load(object sender, EventArgs e)
        {
            s_base_path = Application.StartupPath + "\\DocTemp\\";
        }

        private void lisAttachTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAttachTemplate.SelectedItems.Count > 0)
            {
                if(lisAttachTemplate.SelectedItems[0].Text !="Attach ...")                
                    View_Template_Design('1');
            }
        }

        private void pnlAllTemp_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlTemplate, pnlAttached, pnlAllTemp, pnlAttachLabelMid, 50);
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            pgcMake.Value = 0;
            pgcMake.Visible = true;
            pgcMake.Increment(10);
            for (int i = 0; i < lisAttachTemplate.Items.Count-1; i++)
            {
                CheckTemp(lisAttachTemplate.Items[i].Text);
            }
            PreviewImage();
            if (Update_Template(MPGC.MP_STEP_COPY, true) == false)
            {
                return;
            }
            pgcMake.Increment(100);
            pgcMake.Visible = false;
        }

        private void chkKeepLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeepLine.Checked == true)
                txtKeepLine.Visible = true;
            else
                txtKeepLine.Visible = false;
        }
        #endregion

    }
    //#End If
}
