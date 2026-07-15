using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public interface iFormEventFunction
    {
        void Form_Load(System.Windows.Forms.Form frm, System.EventArgs e);
        void Form_Activated(System.Windows.Forms.Form frm, System.EventArgs e);
        void Form_Closed(System.Windows.Forms.Form frm, FormClosedEventArgs e);
    }
}
