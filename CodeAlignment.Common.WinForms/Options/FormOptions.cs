using System;
using System.Windows.Forms;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Options
{
    public partial class FormOptions : Controls.BaseForm
    {
        Business.Options m_options = new Business.Options();
        public FormOptions()
        {
            InitializeComponent();
        }

        void ShowScreen(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "nodeGeneral"       : DisplayScreen(new ScreenGeneral  (m_options)); break;
                case "nodeShortcuts"     : DisplayScreen(new ScreenShortcuts(m_options)); break;
                case "nodeAutoSelection" : DisplayScreen(new ScreenSelectors(m_options)); break;
                default                  : break;
            }
        }

        void DisplayScreen(Control ctl)
        {
            foreach (Control control in pnlMain.Controls)
                control.Dispose();

            pnlMain.Controls.Clear();
            ctl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ctl);
        }

        void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        void Ok(object sender, EventArgs e)
        {
            m_options.Save();
            Close();
        }
    }
}