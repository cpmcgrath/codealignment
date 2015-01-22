using System;
using System.Linq;
using CMcG.CodeAlignment.Business;
using Microsoft.Expression.DesignModel.Code;

namespace CMcG.CodeAlignment.Implementations
{
    public class Document : Business.IDocument
    {
        ITextEditor m_textEditor;

        public Document(ITextEditor editor)
        {
            m_textEditor = editor;
        }

        public int LineCount
        {
            get { return m_textEditor.LineCount; }
        }

        public int StartSelectionLineNumber
        {
            get { return m_textEditor.GetLineNumberFromPosition(m_textEditor.SelectionStart); }
        }

        public int EndSelectionLineNumber
        {
            get { return m_textEditor.GetLineNumberFromPosition(m_textEditor.SelectionStart + m_textEditor.SelectionLength); }
        }

        public int CaretColumn
        {
            get { return m_textEditor.GetLineOffsetFromPosition(m_textEditor.CaretPosition); }
        }

        public bool ConvertTabsToSpaces
        {
            get { return m_textEditor.ConvertTabsToSpace; }
        }

        public int TabSize
        {
            get { return m_textEditor.TabSize; }
        }

        public string FileType
        {
            get { return "." + m_textEditor.GetTextBuffer().ContentType.DisplayName.ToLower(); }
        }

        public ILine GetLineFromLineNumber(int lineNo)
        {
            return new Line(lineNo, m_textEditor);
        }

        public IEdit StartEdit()
        {
            return new Edit(m_textEditor.GetTextBuffer().CreateEdit());
        }
    }
}