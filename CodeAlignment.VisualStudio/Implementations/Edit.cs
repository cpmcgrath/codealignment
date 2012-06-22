using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMcG.CodeAlignment.Business;
using Microsoft.VisualStudio.Text;

namespace CMcG.CodeAlignment.Implementations
{
    class Edit : IEdit
    {
        ITextEdit m_edit;

        public Edit(ITextEdit edit)
        {
            m_edit = edit;
        }

        public bool Insert(ILine line, int position, string text)
        {
            return m_edit.Insert(line.Position + position, text);
        }

        public void Commit()
        {
            m_edit.Apply();
        }

        public void Dispose()
        {
            m_edit.Dispose();
        }
    }
}