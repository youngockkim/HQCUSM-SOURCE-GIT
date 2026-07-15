using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using Miracom.CliFrx;

namespace Miracom.MESCore.Controls
{
    public interface intFlexiblePanelControl
    {
        void InitControl();
        void SetData(TRSNode node);
        void GetData(ref TRSNode node);
    }

    public partial class udcFlexiblePanel : UserControl, intFlexiblePanelControl
    {
        public udcFlexiblePanel()
        {
            InitializeComponent();
        }

        public virtual void InitControl()
        {
            MPCF.FieldClear(this);
        }

        public virtual bool CheckCondition()
        {
            // Do nothing
            return false;
        }

        public virtual void SetData(TRSNode node)
        {
            // Do nothing
        }

        public virtual void GetData(ref TRSNode node)
        {
            // Do nothing
        }
    }
}
