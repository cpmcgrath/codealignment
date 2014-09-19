using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business.Mocks
{
    public class MockDocuments : IDocument
    {
        MockLine[] m_lines;
        public string[] Lines
        {
            get { return m_lines.Select(x => x.Text).ToArray(); }
            set { m_lines = value.Select(x => new MockLine { Text = x }).ToArray(); }
        }

        public int LineCount
        {
            get { return m_lines.Length; }
        }

        public int    StartSelectionLineNumber { get; set; }
        public int    EndSelectionLineNumber   { get; set; }
        public int    CaretColumn              { get; set; }
        public bool   ConvertTabsToSpaces      { get; set; }
        public int    TabSize                  { get; set; }
        public string FileType                 { get; set; }

        public ILine GetLineFromLineNumber(int lineNo)
        {
            return m_lines[lineNo];
        }

        public IEdit StartEdit()
        {
            return new MockEdit();
        }

        public void Refresh()
        {
        }
    }
}
