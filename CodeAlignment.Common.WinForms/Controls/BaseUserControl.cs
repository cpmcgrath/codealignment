using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace CMcG.CodeAlignment.Controls
{
    public partial class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 9.0F);

            InitializeComponent();

            AutoScaleMode = AutoScaleMode.Font;
        }
    }
}
