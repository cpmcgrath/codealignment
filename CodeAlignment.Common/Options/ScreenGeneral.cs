using System;
using System.Linq;
using CMcG.CodeAlignment.Properties;

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

        private void ResetMruList(object sender, EventArgs e)
        {
            Settings.Default.Delimiters = new System.Collections.Specialized.StringCollection();
            Settings.Default.Save();
        }
    }
}
