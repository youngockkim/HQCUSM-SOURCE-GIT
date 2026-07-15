using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WEMCore.Setup
{
    public interface intStepActionControl
    {
        void initControl();
        bool checkCondition();
        void setAction(TRSNode node);
        void getAction(TRSNode node);
    }

    public partial class udcStepActionBase : UserControl, intStepActionControl
    {
        public udcStepActionBase()
        {
            InitializeComponent();
        }

        public virtual void initControl()
        {
            MPCF.FieldClear(this);
        }

        public virtual bool checkCondition()
        {
            // Do nothing
            return false;
        }

        public virtual void setAction(TRSNode node)
        {
            // Do nothing
        }

        public virtual void getAction(TRSNode node)
        {
            // Do nothing
        }

    
    }
}
