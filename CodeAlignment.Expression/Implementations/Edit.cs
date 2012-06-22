using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Implementations
{
    public class Edit : IEdit
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