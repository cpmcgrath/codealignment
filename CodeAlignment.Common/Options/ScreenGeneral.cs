using System;
using System.Linq;

namespace CMcG.CodeAlignment.Options
{
    public partial class ScreenGeneral : Controls.BaseUserControl
    {
        Business.Options m_options;
        public ScreenGeneral(Business.Options options)
        {
            InitializeComponent();
            m_options              = options;
            bindOptions.DataSource = m_options;
        }
    }
}
