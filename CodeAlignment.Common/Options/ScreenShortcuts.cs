using System;
using System.Linq;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Options
{
    public partial class ScreenShortcuts : Controls.BaseUserControl
    {
        public ScreenShortcuts(Business.Options context)
        {
            InitializeComponent();
            DataContext        = context;
            listShortcut.Items = DataContext.Shortcuts;
        }

        Business.Options DataContext { get; set; }

        void AddShortcut(object sender, EventArgs e)
        {
            listShortcut.AddItem(new KeyShortcut());
        }

        void RestoreDefaults(object sender, EventArgs e)
        {
            DataContext.ResetShortcuts();
            listShortcut.Items = DataContext.Shortcuts;
        }
    }
}