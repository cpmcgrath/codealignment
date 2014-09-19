using System;

namespace CMcG.CodeAlignment.Business
{
    public interface IDocument
    {
        int    LineCount                { get; }
        int    StartSelectionLineNumber { get; }
        int    EndSelectionLineNumber   { get; }
        int    CaretColumn              { get; }
        bool   ConvertTabsToSpaces      { get; }
        int    TabSize                  { get; }
        string FileType                 { get; }

        ILine GetLineFromLineNumber(int lineNo);
        IEdit StartEdit();
        void Refresh();
    }
}