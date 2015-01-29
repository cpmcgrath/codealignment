using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public partial class FormKeyGrabber : Controls.BaseForm, Interactions.IKeyGrabber
    {
        bool m_isChained;
        public AlignmentViewModel ViewModel { get; set; }

        public FormKeyGrabber()
        {
            InitializeComponent();
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Disposed += (s, a) => ViewModel.AlignFromPosition();
                Close();
                return;
            }

            var key = GetKey(e);
            if (key == null)
                return;

            ViewModel.PerformAlign((Key)key, e.Shift);

            if (!e.Control)
            {
                Close();
            }
            else
            {
                m_isChained = true;
                lblDescription.Text = "Release Ctrl key to finish or press another shortcut.";
            }
        }

        Key? GetKey(KeyEventArgs e)
        {
            if (Enum.IsDefined(typeof(Key), (int)e.KeyCode))
                return (Key)e.KeyCode;

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                return (Key)(e.KeyCode - Keys.NumPad0 + Keys.D0);

            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                return null;
            else
            {
                Close();
                return null;
            }
        }

        const int KEY_UP        = 257,
                  LEFT_CONTROL  = -1071841279,
                  RIGHT_CONTROL = -1055064063;

        protected override void WndProc(ref Message m)
        {
            if (m_isChained && m.Msg == KEY_UP
            && (m.LParam.ToInt32() == LEFT_CONTROL || m.LParam.ToInt32() == RIGHT_CONTROL))
            {
                Close();
            }

            base.WndProc(ref m);
        }

        public void Display()
        {
            ShowDialog();
        }

        public void SetBounds(Rectangle bounds)
        {
            Location = bounds.Location;
            Size     = bounds.Size;
        }
    }
}