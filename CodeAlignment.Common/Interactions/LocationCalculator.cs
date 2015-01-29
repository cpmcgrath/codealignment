using System;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CMcG.CodeAlignment.Interactions
{
    public class LocationCalculator
    {                    
        public Rectangle CalculateBounds(IntPtr handle, Point offset)
        {
            RECT rect;
            GetWindowRect(handle, out rect);

            return new Rectangle(x      : rect.Left + offset.X,
                                 y      : rect.Bottom - 20 + offset.Y,
                                 width  : rect.Right - rect.Left - 20,
                                 height : 20);
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
