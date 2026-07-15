using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;


namespace Miracom.CliFrx
{
    public class ListViewItemComparer : IComparer
    {
        
        
        public enum SORTING_OPTION
        {
            STRING_TYPE = 0,
            NUMBER_TYPE = 1
        }

        private CompareInfo cmpi = new CultureInfo("").CompareInfo;
        private CompareOptions cmpo = CompareOptions.Ordinal;

        private int m_iColumn;
        private SortOrder m_iSortOrder = SortOrder.Ascending;
        private SORTING_OPTION m_eSortingOption = SORTING_OPTION.STRING_TYPE;
        
        public ListViewItemComparer()
        {
            m_iColumn = 0;
        }
        
        public ListViewItemComparer(int column, SortOrder iSortOrder, SORTING_OPTION eSortingOption)
        {
            m_iColumn = column;
            m_iSortOrder = iSortOrder;
            m_eSortingOption = eSortingOption;
        }
        
        public virtual int Compare(object x, object y)
        {
            
            try
            {
                int iResult;
                string sTextX;
                string sTextY;
                
                // 2007.01.16. Aiden Koo
                // 문자열이 숫자형식인 경우는 10 이 9 보다 작은것으로 처리됨. 따라서 문자열이 숫자형인 경우 숫자로 변환하여 비교하도록 함.
                // 2007.08.20. Aiden Koo
                // 아래 로직이 들어갈 경우 소팅 시간이 오래걸림. 따라서 문자열 기본으로 다시 복귀함.
                //////double dNumX;
                //////double dNumY;
                //////bool bNumX;
                //////bool bNumY;

                //////dNumX = 0;
                //////dNumY = 0;
                //////bNumX = false;
                //////bNumY = false;
                iResult = 0;

                if (((ListViewItem) x).SubItems.Count > m_iColumn)
                {
                    sTextX = ((ListViewItem) x).SubItems[m_iColumn].Text;
                }
                else
                {
                    sTextX = "";
                }
                if (((ListViewItem) y).SubItems.Count > m_iColumn)
                {
                    sTextY = ((ListViewItem) y).SubItems[m_iColumn].Text;
                }
                else
                {
                    sTextY = "";
                }

                switch (m_eSortingOption)
                {
                    case SORTING_OPTION.STRING_TYPE:

                        //////if (MPCF.CheckNumeric(sTextX))
                        //////{
                        //////    dNumX = MPCF.ToDbl(sTextX);
                        //////    bNumX = true;
                        //////}
                        //////if (MPCF.CheckNumeric(sTextY))
                        //////{
                        //////    dNumY = MPCF.ToDbl(sTextY);
                        //////    bNumY = true;
                        //////}

                        //////if (bNumX == true && bNumY == true)
                        //////{
                        //////    if (dNumX == dNumY)
                        //////        iResult = 0;
                        //////    else if (dNumX < dNumY)
                        //////        iResult = -1;
                        //////    else if (dNumX > dNumY)
                        //////        iResult = 1;
                        //////}
                        //////else
                        //////{
                            iResult = cmpi.Compare(sTextX, sTextY, cmpo);
                        //////}
                        break;
                    case SORTING_OPTION.NUMBER_TYPE:
                        
                        if (sTextX == sTextY)
                        {
                            iResult = 0;
                        }
                        else if (MPCF.ToDbl(sTextX) < MPCF.ToDbl(sTextY))
                        {
                            iResult = - 1;
                        }
                        else if (MPCF.ToDbl(sTextX) > MPCF.ToDbl(sTextY))
                        {
                            iResult = 1;
                        }
                        break;
                }

                return (m_iSortOrder == SortOrder.Descending ? iResult * - 1 : iResult);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ListViewItemComparer.Compare()\n" + ex.Message);
                return 0;
            }
            
        }
        
    }
    
    
}
