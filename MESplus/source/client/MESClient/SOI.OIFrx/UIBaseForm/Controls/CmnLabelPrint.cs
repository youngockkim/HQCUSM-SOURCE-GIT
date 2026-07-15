/*---------------------------------------------------------------------------------------------------
 
    PROG ID     : CmnLabelPrint
    Creator     : sunghee park
    Create Date : 2013.03.26
    Description : Lavel Print Format and Print for Backgrand Process
 
    History     : 
 *                2013.07.02 Creation Function.
----------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Collections;
//==
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Drawing;
using System.Windows.Forms;
using Miracom.CliFrx;
//using Miracom.POPCore;

namespace SOI.OIFrx
{
    public class CmnLabelPrint
    {
        #region " Constant Definition "
        private enum Cols : int
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, AA, AB, AC, AD, AE, AF, AG, AH, AI, AJ, AK, AL, AM, AN, AO, AP, AQ, AR, AS, AT, AU, AV, AW, AX, AY, AZ
        }
        private enum Cols1 : int
        {
            RNUM, DATAFILED, XY1, XY2
        }
        #endregion

        System.DateTime ServerDate = DateTime.Parse("1999-01-01");
        FarPoint.Win.Spread.CellType.ComboBoxCellType cb1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        FarPoint.Win.Spread.CellType.ComboBoxCellType cb2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        FarPoint.Win.Spread.CellType.MaskCellType maskType = new FarPoint.Win.Spread.CellType.MaskCellType();
        FarPoint.Win.Spread.CellType.NumberCellType numType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType numType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType numType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType numType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.TextCellType txtType1 = new FarPoint.Win.Spread.CellType.TextCellType();

        FarPoint.Win.ComplexBorder complexBorder176 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        FarPoint.Win.ComplexBorder complexBorder177 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        
        int iPageRowCount = 21;
        int iPageDataCount = 21;
        int iDefaultDataPosX = 11;
        int iSpdRow = 11;
        int iDefaultPagePosX = 33;
        int i20PageCount = 20;
        
        public Form frmPrint = null;
        public CmnLabelPrint()
        {
            ServerDate = DateTime.Now;
        }

        public bool RcvInspDocPrint(DataTable dtHeader, ArrayList arryInspItemList, Form sFrm)
        {
            bool bResult = false;
            int iRowCnt = 0;
            int iPageCnt = 0;
            int iRows = 0;            
            double dPageTotalCnt = 1;
            double dCnt = 0.0;
            string sMatId = string.Empty;
            string sNewMatId = string.Empty;
            //int iPageRowCount = 24;
            //int iPageDataCount = 24;
            //int iDefaultDataPosX = 11;
            //int iSpdRow = iDefaultDataPosX;
            //int iDefaultPagePosX = 35;

            try
            {
                //임시테스트
                //frmPrint = new frmInspResultForm();
                //PrintSheet(frmPrint); //프린트 출력
                //return true;


                //page total을 구함. 
                if (arryInspItemList != null && arryInspItemList.Count > 0)
                {
                    dCnt = Math.Round(arryInspItemList.Count / Convert.ToDouble(iPageDataCount), 2);
                    dPageTotalCnt = Math.Ceiling(dCnt);
                }

                //초기화
                iRowCnt = 0;
                iPageCnt = 0;
                iRows = 0;
                iSpdRow = iDefaultDataPosX;
                if (sFrm.Name.Equals("frmInspResultForm"))
                {
                    #region [ frmInspResultForm ]
                    frmPrint = new frmInspResultForm();

                    for (int i = (frmPrint as frmInspResultForm).spdData.Sheets.Count - 1; i >= 1; i--)
                    {
                        (frmPrint as frmInspResultForm).spdData.Sheets.Remove((frmPrint as frmInspResultForm).spdData.Sheets[i]);
                    }

                    //Print_init(dt, frmPrint); //프린트 내용 초기화
                    int iCnt = 1;
                    /* 내역을 출력 */

                    //Header정보 셋팅
                    #region [Header정보 설정]
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(1, (int)Cols.B, dtHeader.Rows[0]["INSP_TITLE"].ToString() + " 검사성적서"); //TITLE
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(2, (int)Cols.D, dtHeader.Rows[0]["MAT_DESC"].ToString()); //품명
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(2, (int)Cols.M, dtHeader.Rows[0]["MAT_ID"].ToString()); //자재번호

                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(3, (int)Cols.D, dtHeader.Rows[0]["VENDOR_NAME"].ToString()); //공급자명
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(3, (int)Cols.M, dtHeader.Rows[0]["VENDOR_ID"].ToString()); //공급자

                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(4, (int)Cols.D, dtHeader.Rows[0]["DLV_NO"].ToString()); //납품서
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(4, (int)Cols.M, dtHeader.Rows[0]["VENDOR_PROD_DATE"].ToString()); //생산일자

                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(5, (int)Cols.D, dtHeader.Rows[0]["V_JUDG_DATE"].ToString()); //검사일(공급)
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(5, (int)Cols.I, dtHeader.Rows[0]["JUDG_DATE"].ToString()); //검사일(수요)
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(5, (int)Cols.M, dtHeader.Rows[0]["VENDOR_LOT_ID"].ToString()); //생산LOT

                    int iJudgCol = (int)Cols.D;
                    if (dtHeader.Rows[0]["JUDG_RESULT"].ToString() == "NG") iJudgCol = (int)Cols.F;
                    else if (dtHeader.Rows[0]["JUDG_RESULT"].ToString() == "SPECIAL") iJudgCol = (int)Cols.I;
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(6, iJudgCol, dtHeader.Rows[0]["JUDG_RESULT_DESC"].ToString()); //종합판정 DESC
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(6, (int)Cols.M, dtHeader.Rows[0]["DLV_DATE"].ToString()); //납품일자

                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(7, (int)Cols.D, dtHeader.Rows[0]["JUDG_COMMENT"].ToString()); //검사의견
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(7, (int)Cols.M, dtHeader.Rows[0]["DLV_QTY"].ToString());  //납품수량

                    int iIQCCol = (int)Cols.S;
                    if(dtHeader.Rows[0]["IQC_FLAG"].ToString() != "Y") iIQCCol = (int)Cols.U;
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(2, iIQCCol, dtHeader.Rows[0]["IQC_FLAG_DESC"].ToString());//검사방법DESC

                    int iCycleCol = (int)Cols.S;
                    if (dtHeader.Rows[0]["INSP_CYCLE"].ToString() != "REGULAR") iCycleCol = (int)Cols.U;
                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(3, iCycleCol, dtHeader.Rows[0]["INSP_CYCLE_DESC"].ToString());//검사주기DESC

                    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(4, (int)Cols.S, dtHeader.Rows[0]["COL_SET"].ToString());//검사set

                    #endregion

                    //FarPoint.Win.Spread.CellType.RichTextCellType rtb = new FarPoint.Win.Spread.CellType.RichTextCellType();
                    //rtb.Multiline = true;
                    //rtb.WordWrap = true;
                   
                    foreach (string[] dr in arryInspItemList)
                    {
                        #region [ITEM별 검사값 설정.]
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.C, dr[0]);//검사항목

                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.H, dr[1]);//단위
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.I, dr[2]);//LSL
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.J, dr[3]);//USL

                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.K, dr[4]);//S1
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.L, dr[5]);//S2
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.M, dr[6]);//S3
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.N, dr[7]);//S4
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.O, dr[8]);//S5
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.P, dr[9]);//판정

                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.Q, dr[10]);//K1
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.R, dr[11]);//K2
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.S, dr[12]);//K3
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.T, dr[13]);//K4
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.U, dr[14]);//K5
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(iSpdRow, (int)Cols.V, dr[15]);//판정

                        //for (int c = (int)Cols.C; c < 22; c++)
                        //{
                        //    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].Cells[iSpdRow, c].CellType = rtb;
                        //}
                        #endregion

                        //PAGE CHECK
                        if (iRowCnt == iPageRowCount - 1)
                        {
                            #region [21건씩 데이터를 끊어서 출력한다. ]
                            iSpdRow = iDefaultDataPosX; //데이터 시작 위치를 초기화
                            iRowCnt = 0; //데이타수 초기화
                            iPageCnt++;  //페이지 카운트 증가
                            /* Current Page 출력 */
                            (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.M).Value = string.Concat(iPageCnt, " / ", dPageTotalCnt, " Page");
                            #endregion

                            //Sheet추가
                            FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                            newsheet = (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Clone();
                            newsheet.SheetName = "Sheet" + (iPageCnt + 1).ToString();
                            (frmPrint as frmInspResultForm).spdData.Sheets.Add(newsheet);
                            if (iRows != arryInspItemList.Count - 1) Print_init(iPageCnt, frmPrint, (frmPrint as frmInspResultForm).spdData); ; //만약 총20건인데 현재 상태가 20번째건이면 초기화를 하면 안된다.   
                        }
                        else
                        {
                            iSpdRow++; //iRowCnt가 iPageRowCount번째가 안 되었다면 증가
                            iRowCnt++; //iRowCnt가 iPageRowCount번째가 안 되었다면 증가
                        }
                        iRows++;
                    }

                    #region [ Current Page 변수 ++iPageCnt가 dPageTotalCnt와 같다면 마지막 페이지를 출력한다. ]
                    if (++iPageCnt == 1)
                    {//dPageTotalCnt 중 첫 페이지 출력
                        string sPageCount = string.Empty;
                        sPageCount = dPageTotalCnt > 0 ? string.Concat(iPageCnt, " / ", dPageTotalCnt, " Page") : string.Concat(iPageCnt, " / ", 1, " Page");
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.M).Value = sPageCount; //페이징 표시
                        
                    }
                    else if (iPageCnt == dPageTotalCnt)
                    {//마지막 페이지 출력
                        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.M).Value = string.Concat(dPageTotalCnt, " / ", dPageTotalCnt, " Page"); //페이징 표시
                        
                    }
                    PrintSheet(frmPrint); //프린트 출력

                    //foreach (string[] dr  in arryInspItemList)
                    //{
                    //    //sUnit, sLSL, sUSL, 
                    //    //sVal_1, sVal_2, sVal_3, sVal_4, sVal_5, sResult, 
                    //    //sVal_V_1, sVal_V_2, sVal_V_3, sVal_V_4, sVal_V_5, sResult_V
                    //    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt].SetValue(4, (int)Cols.S, dr[0]);
                     

                    //    //PAGE CHECK
                    //    if (iSpdRow == iPageRowCount)
                    //    {
                    //        #region [24건씩 데이터를 끊어서 출력한다. ]
                    //        iSpdRow = iDefaultDataPosX; //데이터 시작 위치를 초기화
                    //        iRowCnt = 0; //데이터 수 초기화
                    //        iPageCnt++;  //페이지 카운트 증가
                    //        /* Current Page 출력 */
                    //        (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.F).Value = string.Concat(iPageCnt, " / ", dPageTotalCnt, " Page");
                    //        #endregion

                    //        //Sheet추가
                    //        FarPoint.Win.Spread.SheetView newsheet = new FarPoint.Win.Spread.SheetView();
                    //        newsheet = (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Clone();
                    //        newsheet.SheetName = "Sheet" + (iPageCnt + 1).ToString();
                    //        (frmPrint as frmInspResultForm).spdData.Sheets.Add(newsheet);
                    //        if (iRows != arryInspItemList.Count - 1) Print_init(iPageCnt, frmPrint, (frmPrint as frmInspResultForm).spdData); ; //만약 총19건인데 현재 상태가 19번째건이면 초기화를 하면 안된다.   
                    //    }
                    //    else
                    //    {
                    //        iSpdRow +=1; //iRowCnt가 iPageRowCount번째가 안 되었다면 증가
                    //        iRowCnt++; //iRowCnt가 iPageRowCount번째가 안 되었다면 증가
                    //    }
                    //    iRows++;
                    //}

                    //#region [ Current Page 변수 ++iPageCnt가 dPageTotalCnt와 같다면 마지막 페이지를 출력한다. ]
                    //if (++iPageCnt == 1)
                    //{//dPageTotalCnt 중 첫 페이지 출력
                    //    string sPageCount = string.Empty;
                    //    sPageCount = dPageTotalCnt > 0 ? string.Concat(iPageCnt, " / ", dPageTotalCnt, " Page") : string.Concat(iPageCnt, " / ", 1, " Page");
                    //    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.F).Value = sPageCount; //페이징 표시
                    //    //PrintSheet(frmPrint); //프린트 출력
                    //}
                    //else if (iPageCnt == dPageTotalCnt)
                    //{//마지막 페이지 출력
                    //    (frmPrint as frmInspResultForm).spdData.Sheets[iPageCnt - 1].Cells.Get(iDefaultPagePosX, (int)Cols.F).Value = string.Concat(dPageTotalCnt, " / ", dPageTotalCnt, " Page"); //페이징 표시
                    //    //PrintSheet(frmPrint); //프린트 출력
                    //}
                    //PrintSheet(frmPrint); //프린트 출력
                    #endregion
                    #endregion
                }
                bResult = true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
                bResult = false;
            }
            finally
            {
                //if (arryInspItemList != null) dt.Dispose();
            }
            return bResult;

        }

        /// <summary>
        /// 출력물 Initialize
        /// </summary>
        /// <param name="dt"></param>
        private void Print_init(DataTable dt, Form sFrm)
        {
            numType1.DecimalPlaces = 0; numType1.ShowSeparator = true; numType1.MaximumValue = 9999999999999.99; numType1.MinimumValue = -9999999999999.99;
            numType2.DecimalPlaces = 1; numType2.ShowSeparator = true; numType2.MaximumValue = 9999999999999.99; numType2.MinimumValue = -9999999999999.99;
            numType3.DecimalPlaces = 2; numType3.ShowSeparator = true; numType3.MaximumValue = 9999999999999.99; numType3.MinimumValue = -9999999999999.99;
            numType4.DecimalPlaces = 3; numType4.ShowSeparator = true; numType4.MaximumValue = 9999999999999.99; numType4.MinimumValue = -9999999999999.99;
            maskType.Mask = "XXXX-XX-XX";
            int iSpdRow = iDefaultDataPosX;

            try
            {
                if (frmPrint.Name.Equals("frmInspResultForm"))
                {
                    #region [ 수입검사 성적서 ]
                    frmPrint = new frmInspResultForm();

                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.D, dt.Rows[0]["PLAN_DATE"]);          //계획일자
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.F, dt.Rows[0]["WORK_GROUP_DESC"]);          //작업반
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.I, dt.Rows[0]["PRINT_TIME"]);               //발행일시
                    //(frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(4, (int)Cols.I).CellType = numType1;

                    /* 내역을 빈공간으로 처리. */
                    for (int iRows = 0; iRows < 30; iRows++)
                    {
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.B).CellType = txtType1;//No
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.B, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.C).CellType = txtType1;//불출품번
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.C, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.D).CellType = txtType1;//불출품명
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.D, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.F).CellType = numType1;//생산소요
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.F, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.G).CellType = numType1;//안전재고
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.G, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.H).CellType = numType1;//재공재고
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.H, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.I).CellType = numType1;//불출계획
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.I, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.J).CellType = numType1;//SNP
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.J, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.K).CellType = numType1;//PACK_QTY
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.K, DBNull.Value);
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.L).CellType = numType1;//자재재고
                        (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.L, DBNull.Value);

                        iSpdRow++;
                    }
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).Font = new System.Drawing.Font("돋음", 8.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).Font = new System.Drawing.Font("돋음", 8.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    (frmPrint as frmInspResultForm).spdData.ActiveSheet.SetValue(iDefaultPagePosX, (int)Cols.B, string.Concat("Print Date : ", DateTime.Now.ToString()));
                    #endregion
                }
            }
            catch { }
            finally { }
        }

        private void Print_init(int iSheet, Form sFrm, FarPoint.Win.Spread.FpSpread Spread)
        {
            int iSpdRow = iDefaultDataPosX;

            try
            {
                if (frmPrint.Name.Equals("frmInspResultForm"))
                {
                    #region [ 불출 요청서 ]

                    for (int iRows = 0; iRows < iDefaultPagePosX; iRows++)
                    {
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.C, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.H, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.I, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.J, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.K, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.L,  DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.M, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.N, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.O, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.P, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.Q, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.R, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.S, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.T, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.U, DBNull.Value);
                        Spread.Sheets[iSheet].SetValue(iSpdRow, (int)Cols.V, DBNull.Value);

                        iSpdRow++;
                    }

                    #endregion
                }
                
            }
            catch(Exception ex) 
            {

            }
            finally { }
        }
        /// <summary>
        /// print
        /// </summary>
        /// <param name="frmPrint"></param>
        private void PrintSheet(Form frmPrint)
        {
            FarPoint.Win.Spread.PrintMargin pMargin = new FarPoint.Win.Spread.PrintMargin();
            /* PRINT */
            if (frmPrint.Name.Equals("frmInspResultForm"))
            {
                #region [ 수입검사 성적서 ]

                pMargin.Left = 10;
                pMargin.Right = 4;
                pMargin.Top = 5;
                pMargin.Bottom = 5;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Footer = " ";
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Header = " ";
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Margin = pMargin;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.ColumnHeader.Visible = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.RowHeader.Visible = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowGrid = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowColor = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ZoomFactor = 100;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Margin.Bottom = 0;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowBorder = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.ShowPrintDialog = false;
                (frmPrint as frmInspResultForm).spdData.ActiveSheet.PrintInfo.Preview = true;
                (frmPrint as frmInspResultForm).spdData.PrintSheet(-1); //모든 쉬트 출력 
                #endregion
            }
            
        }

        private void PrintSheet(Form frmPrint, FarPoint.Win.Spread.FpSpread Spread)
        {
            FarPoint.Win.Spread.PrintMargin pMargin = new FarPoint.Win.Spread.PrintMargin();
            /* PRINT */
            if (frmPrint.Name.Equals("frmCmnRequestForm"))
            {
                #region [ 출하 지시서 ]

                pMargin.Left = 5;
                pMargin.Right = 5;
                pMargin.Top = 5;
                pMargin.Bottom = 5;
                Spread.ActiveSheet.PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                Spread.ActiveSheet.PrintInfo.Footer = " ";
                Spread.ActiveSheet.PrintInfo.Header = " ";
                Spread.ActiveSheet.PrintInfo.Margin = pMargin;
                Spread.ActiveSheet.ColumnHeader.Visible = false;
                Spread.ActiveSheet.RowHeader.Visible = false;
                Spread.ActiveSheet.PrintInfo.ShowGrid = false;
                Spread.ActiveSheet.PrintInfo.ShowColor = false;
                Spread.ActiveSheet.PrintInfo.ZoomFactor = 100;
                Spread.ActiveSheet.PrintInfo.Margin.Bottom = 0;
                Spread.ActiveSheet.PrintInfo.ShowBorder = false;
                Spread.ActiveSheet.PrintInfo.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                Spread.ActiveSheet.PrintInfo.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                Spread.ActiveSheet.PrintInfo.ShowPrintDialog = false;
                Spread.ActiveSheet.PrintInfo.Preview = false;
                Spread.PrintSheet(-1);
                #endregion
            }
        }

        #region [출력물 미리보기]
        /// <summary>
        /// 인쇄 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public bool btnPrint_Preview(DataTable dt, List<string> lstInfo, Form sFrm)
        {
            return btnPrint_Preview(dt, lstInfo, sFrm, 1, i20PageCount, 1, "Preview");
        }
        public bool btnPrint_Preview(DataTable dt, List<string> lstInfo, Form sFrm, int FrRow, int ToRow, int iPageCnt, string sPrintType)
        {
            bool bResult = false;
            int iRowCnt = 0;
            //int iPageCnt = 0;
            int iRows = 0;
            int iSpdRow = iDefaultDataPosX;
            double dPageTotalCnt = 1;
            double dCnt = 0.0;
            string sMatId = string.Empty;
            string sNewMatId = string.Empty;

            DataTable tblTotal = new DataTable();
            DataTable tblTemp = new DataTable();
            string[] straTemp = null;

            //object[,] oCol = null;
            //int iRnum = 1;
            //string sDtField = string.Empty;
            //int iX1 = 0;
            //int iY1 = 0;
            //string[] sXY1;

            try
            {
                //ID별로 LOOP한다. dt
                if (lstInfo != null)
                {
                    tblTemp = dt.Clone();
                    foreach (string strKey in lstInfo)
                    {
                        if (sFrm.Name.Equals("frmInspResultForm"))
                        {
                            #region [ frmInspResultForm ]
                            //자재불출요청서
                            string ROW_SEQ = string.Empty;//NO.
                            string MAT_ID = string.Empty;//불출품번
                            string MAT_DESC = string.Empty;//불출품명
                            string CURR_REQ_QTY = string.Empty;//생산소요
                            string SAFE_QTY = string.Empty;//안전재고
                            string WIP_AVA_QTY = string.Empty;//재공재고
                            string MOVE_REM_QTY = string.Empty;//불출계획
                            string PACK_QTY = string.Empty;//SNP
                            string PACK_CNT = string.Empty;//Box수
                            string INV_AVA_QTY = string.Empty;//자재재고
                            tblTotal.Clear();
                            tblTemp.Clear();
                            straTemp = strKey.Split(':');
                            DataRow[] rowsTot = dt.Select("WORK_GROUP_DESC='" + straTemp[0].ToString() + "'");
                            if (rowsTot != null && rowsTot.Length > 0) foreach (DataRow row in rowsTot) tblTotal.ImportRow(row);
                            //page total을 구함. 
                            if (tblTotal != null && tblTotal.Rows.Count > 0)
                            {
                                dCnt = tblTotal.Rows.Count / Convert.ToDouble(i20PageCount);
                                dPageTotalCnt = Math.Ceiling(dCnt);
                            }

                            DataRow[] rows = dt.Select("WORK_GROUP_DESC='" + straTemp[0].ToString() + "' AND RNUM >= " + FrRow + " AND RNUM <= " + ToRow, "RNUM");
                            if (rows != null && rows.Length > 0) foreach (DataRow row in rows) tblTemp.ImportRow(row);
                            //초기화
                            iRowCnt = 0;
                            //iPageCnt = 0;
                            iRows = 0;
                            iSpdRow = iDefaultDataPosX; //데이터 시작 지점
                            Preview_init(tblTemp, sFrm); //프린트 내용 초기화
                            ///* 내역을 출력 */
                            foreach (DataRow dr in tblTemp.Rows)
                            {
                                iRows = dr.Table.Rows.IndexOf(dr);

                                #region [Cell단위로 데이터를 저장한다.]
                                ROW_SEQ = dr["ROW_SEQ"].ToString();//NO.
                                MAT_ID = dr["MAT_ID"].ToString();//품번
                                MAT_DESC = dr["MAT_DESC"].ToString();//품명
                                CURR_REQ_QTY = dr["CURR_REQ_QTY"].ToString();//생산소요
                                SAFE_QTY = dr["SAFE_QTY"].ToString();//안전재고
                                WIP_AVA_QTY = dr["WIP_AVA_QTY"].ToString();//재공재고
                                MOVE_REM_QTY = dr["MOVE_REM_QTY"].ToString();//불출계획
                                PACK_QTY = dr["PACK_QTY"].ToString();//SNP
                                PACK_CNT = dr["PACK_CNT"].ToString();//Box수
                                INV_AVA_QTY = dr["INV_AVA_QTY"].ToString();//자재재고
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.B, ROW_SEQ);        //NO.
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.C, MAT_ID);         //불출품번
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.D, MAT_DESC);       //불출품명
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.F, CURR_REQ_QTY);   //생산소요
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.G, SAFE_QTY);       //안전재고
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.H, WIP_AVA_QTY);    //재공재고
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.I, MOVE_REM_QTY);   //불출계획
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.J, PACK_QTY);       //SNP
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.K, PACK_CNT);       //Box수
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.L, INV_AVA_QTY);    //자재재고
                                #endregion
                                //PAGE CHECK
                                if (iRowCnt == 29)
                                {
                                    #region [30건씩 데이터를 끊어서 출력한다. ]
                                    iSpdRow = iDefaultDataPosX;  //데이터 시작 위치를 초기화
                                    iRowCnt = 0;  //데이터 수가 19건째이면 초기화
                                    //iPageCnt++; //데이터 수가 20건째이면 페이지 카운트 증가
                                    /* Current Page 출력 */
                                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).Value = string.Concat(iPageCnt, " / ", dPageTotalCnt, " Page");
                                    if (sPrintType == "Preview")
                                    {
                                        (sFrm as frmInspResultForm).Update();
                                    }
                                    else
                                    {
                                        PrintSheet(sFrm); //프린트 출력
                                    }
                                    #endregion
                                    if (iRows != tblTemp.Rows.Count - 1) Preview_init(tblTemp, sFrm); //만약 총20건인데 현재 상태가 20번째건이면 초기화를 하면 안된다.                                
                                }
                                else
                                {
                                    iSpdRow++; //iRowCnt가 19번째가 안 되었다면 증가
                                    iRowCnt++; //iRowCnt가 19번째가 안 되었다면 증가
                                }
                            }
                            #region [ Current Page 변수 ++iPageCnt가 dPageTotalCnt와 같다면 마지막 페이지를 출력한다. ]
                            if (iPageCnt == dPageTotalCnt)
                            {//마지막 페이지 출력
                                (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).Value = string.Concat(dPageTotalCnt, " / ", dPageTotalCnt, " Page"); //페이징 표시
                                if (sPrintType == "Preview")
                                {
                                    (sFrm as frmInspResultForm).Update();
                                }
                                else
                                {
                                    PrintSheet(sFrm); //프린트 출력
                                }
                            }
                            #endregion
                            #endregion
                        }
                    }
                }
                bResult = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
                bResult = false;
            }
            finally
            {
                if (dt != null) dt.Dispose();
            }
            return bResult;

        }

        /// <summary>
        /// 출력물 Initialize
        /// </summary>
        /// <param name="dt"></param>
        private void Preview_init(DataTable dt, Form sFrm)
        {
            numType1.DecimalPlaces = 0; numType1.ShowSeparator = true; numType1.MaximumValue = 9999999999999.99; numType1.MinimumValue = -9999999999999.99;
            numType2.DecimalPlaces = 1; numType2.ShowSeparator = true; numType2.MaximumValue = 9999999999999.99; numType2.MinimumValue = -9999999999999.99;
            numType3.DecimalPlaces = 2; numType3.ShowSeparator = true; numType3.MaximumValue = 9999999999999.99; numType3.MinimumValue = -9999999999999.99;
            numType4.DecimalPlaces = 3; numType4.ShowSeparator = true; numType4.MaximumValue = 9999999999999.99; numType4.MinimumValue = -9999999999999.99;
            maskType.Mask = "XXXX-XX-XX";
            int iSpdRow = iDefaultDataPosX;

            //object[,] oCol = null;
            //int iRnum = 1;
            //string sDtField = string.Empty;
            //int iX1 = 0;
            //int iY1 = 0;
            //string[] sXY1;

            try
            {
                if (sFrm.Name.Equals("frmInspResultForm"))
                {
                    #region [ 불출 요청서 ]
                    iSpdRow = iDefaultDataPosX;
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.D, dt.Rows[0]["PLAN_DATE"]);          //계획일자
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.F, dt.Rows[0]["WORK_GROUP_DESC"]);          //작업반
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(4, (int)Cols.I, dt.Rows[0]["PRINT_TIME"]);               //발행일시
                    //(sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(4, (int)Cols.I).CellType = numType1;

                    /* 내역을 빈공간으로 처리. */
                    for (int iRows = 0; iRows < 30; iRows++)
                    {
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.B).CellType = txtType1;//No
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.B, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.C).CellType = txtType1;//불출품번
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.C, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.D).CellType = txtType1;//불출품명
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.D, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.F).CellType = numType1;//생산소요
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.F, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.G).CellType = numType1;//안전재고
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.G, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.H).CellType = numType1;//재공재고
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.H, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.I).CellType = numType1;//불출계획
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.I, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.J).CellType = numType1;//SNP
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.J, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.K).CellType = numType1;//Box수
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.K, DBNull.Value);
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iSpdRow, (int)Cols.L).CellType = numType1;//자재재고
                        (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iSpdRow, (int)Cols.L, DBNull.Value);

                        iSpdRow++;
                    }
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).Font = new System.Drawing.Font("돋음", 8.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.L).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).Font = new System.Drawing.Font("돋음", 8.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.Cells.Get(iDefaultPagePosX, (int)Cols.B).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    (sFrm as frmInspResultForm).spdData.ActiveSheet.SetValue(iDefaultPagePosX, (int)Cols.B, string.Concat("Print Date : ", DateTime.Now.ToString()));
                    #endregion
                }
            }
            catch { }
            finally { }
        }
        #endregion

    }
}
