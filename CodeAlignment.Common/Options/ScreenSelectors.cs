using System;
using System.Linq;

namespace CMcG.CodeAlignment.Options
{
    public partial class ScreenSelectors : Controls.BaseUserControl
    {
        Business.Options m_options;
        public ScreenSelectors(Business.Options options)
        {
            InitializeComponent();
            m_options              = options;
            bindOptions.DataSource = m_options;
        }

        void RestoreDefaults(object sender, EventArgs e)
        {
            m_options.ResetSelectorTypes();
        }
    }
}
