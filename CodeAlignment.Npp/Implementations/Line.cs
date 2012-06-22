using System;
using System.Linq;
using System.Text;
using NppPluginNET;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Line : ILine
    {
        IntPtr m_docPointer;
        int    m_lineNo;

        public Line(IntPtr docPointer, int lineNo)
        {
            m_docPointer = docPointer;
            m_lineNo     = lineNo;
        }

        public string Text
        {
            get
            {
                var start   = (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_POSITIONFROMLINE,   m_lineNo, 0);
                var end     = (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETLINEENDPOSITION, m_lineNo, 0);
                var builder = new StringBuilder(end - start + 1);
                Win32.SendMessage(m_docPointer, SciMsg.SCI_GETLINE, m_lineNo, builder);
                return builder.ToString();
            }
        }

        public int Position
        {
            get { return (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_POSITIONFROMLINE, m_lineNo, 0); }
        }
    }
}