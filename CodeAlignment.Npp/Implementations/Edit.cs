using System;
using System.Linq;
using System.Text;
using NppPluginNET;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Edit : IEdit
    {
        IntPtr m_docPointer;
        public Edit(IntPtr documentPointer)
        {
            m_docPointer = documentPointer;
            Win32.SendMessage(m_docPointer, SciMsg.SCI_BEGINUNDOACTION, 0, 0);
        }

        public bool Insert(ILine line, int position, string text)
        {
            Win32.SendMessage(m_docPointer, SciMsg.SCI_INSERTTEXT, line.Position + position, text);
            return true;
        }

        public void Commit()
        {
            Win32.SendMessage(m_docPointer, SciMsg.SCI_ENDUNDOACTION, 0, 0);
        }

        public void Dispose() { }
    }
}
