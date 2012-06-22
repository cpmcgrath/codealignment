using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CMcG.CodeAlignment.Business;
using System.Runtime.InteropServices;

namespace CMcG.CodeAlignment
{
    public partial class FormKeyGrabber : Controls.BaseForm
    {
        public FormKeyGrabber()
        {
            InitializeComponent();
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                AlignFromPosition = true;
            else if (Enum.IsDefined(typeof(Key), (int)e.KeyCode))
                Result = (Key)e.KeyCode;
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                Result = (Key)(e.KeyCode - Keys.NumPad0 + Keys.D0);
            else if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                return;
            else
            {
                Close();
                return;
            }

            ForceFromCaret = e.Shift;
            DialogResult = DialogResult.OK;
            Close();
        }

        public Key  Result            { get; set; }
        public bool AlignFromPosition { get; set; }
        public bool ForceFromCaret    { get; set; }

        public void SetLocation(IntPtr handle, Point offset)
        {
            RECT rect;
            GetWindowRect(handle, out rect);
            Width    = rect.Right - rect.Left - 20;
            Location = new Point(rect.Left + offset.X, rect.Bottom - Height + offset.Y);
        }

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left   { get; set; }
            public int Top    { get; set; }
            public int Right  { get; set; }
            public int Bottom { get; set; }
        }
    }
}