using System;
using System.Linq;
using CMcG.CodeAlignment.Business;
using Microsoft.Expression.DesignModel.Code;

namespace CMcG.CodeAlignment.Implementations
{
    public class Line : ILine
    {
        readonly int         m_lineNo;
        readonly ITextEditor m_textEditor;

        public Line(int lineNo, ITextEditor editor)
        {
            m_lineNo = lineNo;
            m_textEditor = editor;
        }

        public int Position
        {
            get { return m_textEditor.GetStartOfLineFromLineNumber(m_lineNo); }
        }

        public string Text
        {
            get { return m_textEditor.GetText(Position, m_textEditor.GetLengthOfLineFromLineNumber(m_lineNo)); }
        }
    }
}