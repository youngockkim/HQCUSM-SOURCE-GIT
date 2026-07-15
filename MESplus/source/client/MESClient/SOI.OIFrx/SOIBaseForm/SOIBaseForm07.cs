using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SOI.CliFrx;

namespace SOI.OIFrx.SOIBaseForm
{
    public partial class SOIBaseForm07 : SOIBaseForm01
    {
        #region Property

        private bool m_Title_Visible;

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool TitleVisible
        {
            get { return m_Title_Visible; }
            set 
            { 
                m_Title_Visible = value;

                if (m_Title_Visible == true)
                {
                    pnlTop.Visible = true;
                }
                else
                {
                    pnlTop.Visible = false;
                }
            }
        }

        #endregion

        #region Constructor

        public SOIBaseForm07()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler


        #endregion

        #region Function


        #endregion
    }
}
