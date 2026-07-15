using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CTMAgent
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                //MessageBox.Show("이미 실행 중입니다.");
            }

        }
    }
}
