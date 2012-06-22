using System;
using CMcG.CodeAlignment.Business;
using Microsoft.VisualStudio.Text;

namespace CMcG.CodeAlignment.Implementations
{
    class Line : ILine
    {
        ITextSnapshotLine m_line;

        public Line(ITextSnapshotLine line)
        {
            m_line = line;
        }

        public int Position
        {
            get { return m_line.Start.Position; }
        }

        public string Text
        {
            get { return m_line.GetText(); }
        }
    }
}