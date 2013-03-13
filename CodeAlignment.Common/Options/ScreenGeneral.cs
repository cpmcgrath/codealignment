using System;
using System.Linq;
using System.Windows.Forms;
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

        void ResetMruList(object sender, EventArgs e)
        {
            Settings.Default.Delimiters = new System.Collections.Specialized.StringCollection();
            Settings.Default.Save();
        }

        void BackupSettings(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
                m_options.SaveAs(dlgSave.FileName);
        }

        void RestoreSettings(object sender, EventArgs e)
        {
            if (dlgLoad.ShowDialog() == DialogResult.OK)
                m_options.LoadFrom(dlgLoad.FileName);
        }
    }
}
