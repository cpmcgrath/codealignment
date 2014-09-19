using System;
using System.Linq;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public class XmlScopeSelector : IScopeSelector
    {
        public int? Start { get; set; }
        public int? End   { get; set; }

        public IEnumerable<ILine> GetLinesToAlign(IDocument view)
        {
            int start = Start ?? view.StartSelectionLineNumber;
            int end   = End   ?? view.EndSelectionLineNumber;

            if (start == end)
            {
                var line = view.GetLineFromLineNumber(start).Text.ReplaceTabs(view.TabSize);
                var isMulti = IsMultiLineTag(view, line);

                var blanks = isMulti ? start      .DownTo(0).Where(x => IsMultiLineStart(view, x))
                                     : (start + 1).DownTo(1).Where(x => IsNotSameScope(view, x - 1, line));

                start      = blanks.Any() ? blanks.First() : 0;

                blanks     = isMulti ?  end     .UpTo(view.LineCount - 1).Where(x => IsMultiLineEnd(view, x))
                                     : (end - 1).UpTo(view.LineCount - 2).Where(x => IsNotSameScope(view, x + 1, line));
                end        = blanks.Any() ? blanks.First() : view.LineCount - 1;
            }

            return start.UpTo(end).Select(x => view.GetLineFromLineNumber(x));
        }

        bool IsMultiLineTag(IDocument view, string line)
        {
            line = line.Trim();
            return !line.StartsWith("<") || !line.Contains(">");
        }

        bool IsMultiLineStart(IDocument view, int lineNo)
        {
            var blankStrings = new[] { string.Empty,  };
            var line = view.GetLineFromLineNumber(lineNo).Text.Trim();
            return line == string.Empty || line.StartsWith("<");
        }

        bool IsMultiLineEnd(IDocument view, int lineNo)
        {
            var blankStrings = new[] { string.Empty,  };
            var line = view.GetLineFromLineNumber(lineNo).Text.Trim();
            return line == string.Empty || line.Contains(">");
        }

        bool IsNotSameScope(IDocument view, int lineNo, string original)
        {
            var line           = view.GetLineFromLineNumber(lineNo).Text.ReplaceTabs(view.TabSize);
            var lineIndent     = line    .Length - line    .TrimStart().Length;
            var originalIndent = original.Length - original.TrimStart().Length;
            return line.Trim() == string.Empty || lineIndent != originalIndent;
        }
    }
}