using System.Data;
using System.Collections;
using System.Diagnostics;
using System;
using System.Windows.Forms;

namespace Miracom.CliFrx
{
    public interface intFormEventFunction
    {
        void Form_Load(System.Windows.Forms.Form frm, System.EventArgs e);
        void Form_Activated(System.Windows.Forms.Form frm, System.EventArgs e);
        void Form_Closed(System.Windows.Forms.Form frm, FormClosedEventArgs e);
    }    
}
