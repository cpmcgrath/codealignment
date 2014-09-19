using System;
using System.Linq;
using CMcG.CodeAlignment.Business;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace CMcG.CodeAlignment.Implementations
{
    class Document : IDocument
    {
        IWpfTextView  m_doc;
        ITextSnapshot m_snapshot;

        public Document(IWpfTextView doc)
        {
            m_doc      = doc;
            m_snapshot = doc.TextSnapshot;
        }

        public int LineCount
        {
            get { return m_snapshot.LineCount; }
        }

        public int StartSelectionLineNumber
        {
            get { return m_snapshot.GetLineNumberFromPosition(m_doc.Selection.Start.Position); }
        }

        public int EndSelectionLineNumber
        {
            get { return m_snapshot.GetLineNumberFromPosition(m_doc.Selection.End.Position); }
        }

        public int CarretColumn
        {
            get
            {
                var caret = m_doc.Caret.Position.BufferPosition;
                var index = m_doc.GetTextViewLineContainingBufferPosition(caret).Start.Difference(caret);
                var line  = m_snapshot.GetLineFromPosition(caret).GetText().Substring(0, index);
                return line.ReplaceTabs(TabSize).Length + m_doc.Caret.Position.VirtualSpaces;
            }
        }

        public bool ConvertTabsToSpaces
        {
            get { return m_doc.Options.GetOptionValue(DefaultOptions.ConvertTabsToSpacesOptionId); }
        }

        public int TabSize
        {
            get { return m_doc.Options.GetOptionValue(DefaultOptions.TabSizeOptionId); }
        }

        public ILine GetLineFromLineNumber(int lineNo)
        {
            return new Line(m_snapshot.GetLineFromLineNumber(lineNo));
        }

        public IEdit StartEdit()
        {
            return new Edit(m_snapshot.TextBuffer.CreateEdit());
        }

        public string FileType
        {
            get { return "." + m_doc.TextBuffer.ContentType.TypeName.ToLower(); }
        }

        public void Refresh()
        {
            m_snapshot = m_doc.TextSnapshot;
        }
    }
}