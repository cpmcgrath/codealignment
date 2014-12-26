using System;
using System.Linq;
using System.Windows.Forms;
using CMcG.CodeAlignment.Properties;

namespace CMcG.CodeAlignment
{
    public partial class FormCodeAlignment : Controls.BaseForm, Interactions.IAlignmentDetails
    {
        public FormCodeAlignment()
        {
            InitializeComponent();
            UseRegex = Settings.Default.UseRegex;
            if (Settings.Default.Delimiters == null)
            {
                Settings.Default.Delimiters = new System.Collections.Specialized.StringCollection();
                Settings.Default.Save();
            }

            foreach (string delimiter in Settings.Default.Delimiters)
                cboDelimiter.Items.Add(delimiter);

            if (cboDelimiter.Items.Count > 0)
                cboDelimiter.SelectedIndex = 0;
        }

        void Ok(object sender = null, EventArgs e = null)
        {
            Settings.Default.Delimiters.Remove(cboDelimiter.Text);
            Settings.Default.Delimiters.Insert(0, cboDelimiter.Text);
            Settings.Default.UseRegex = UseRegex;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        void Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        void ShowHelp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new FormAbout().ShowDialog();
            e.Cancel = true;
        }

        void ShowOptions(object sender, EventArgs e)
        {
            new Options.FormOptions().ShowDialog(this);
        }

        public string Delimiter
        {
            get { return cboDelimiter.Text; }
        }

        public bool AlignFromCaret
        {
            get { return chkAlignFromCaret.Checked || (Control.ModifierKeys == Keys.Shift); }
            set { chkAlignFromCaret.Checked = value; }
        }

        public bool UseRegex
        {
            get { return chkUseRegex.Checked; }
            set { chkUseRegex.Checked = value; }
        }
    }
}