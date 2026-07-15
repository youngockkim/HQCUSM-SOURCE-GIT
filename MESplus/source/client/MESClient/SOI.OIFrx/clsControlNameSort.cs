using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    // ControlNameSort Class
    //       - GetIndexedControl()에서의 Control들을 이름으로 정렬하기 위해 만든 class
    // Return Value
    //       - Integer : Sorting Hash Code
    // Arguments
    //       - ByVal con1 As Object    : ArrayList에 들어있는 Control1
    //        - ByVal con2 As Object    : ArrayList에 들어있는 Control2
    public class ControlNameSort : IComparer
    {

        public int Compare(object con1, object con2)
        {
            string sConName;
            int iCon1;
            int iCon2;
            int i;

            sConName = ((Control)con1).Name.Trim();
            for (i = sConName.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(sConName[i]))
                {
                    break;
                }
            }
            iCon1 = MPOF.ToInt(sConName.Substring(i + 1, sConName.Length - i - 1));

            sConName = ((Control)con2).Name.Trim();
            for (i = sConName.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(sConName[i]))
                {
                    break;
                }
            }
            iCon2 = MPOF.ToInt(sConName.Substring(i + 1, sConName.Length - i - 1));

            return new CaseInsensitiveComparer().Compare(iCon1, iCon2);
        }
    }
}
