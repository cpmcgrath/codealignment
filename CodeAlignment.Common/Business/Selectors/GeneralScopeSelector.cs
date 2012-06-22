using System;
using System.Linq;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public class GeneralScopeSelector : IScopeSelector
    {
        public IEnumerable<ILine> GetLinesToAlign(IDocument view)
        {
            int start = view.StartSelectionLineNumber;
            int end   = view.EndSelectionLineNumber;

            if (start == end)
            {
                var blanks = start.DownTo(0).Where(x => IsLineBlank(view, x));
                start      = blanks.Any() ? blanks.First() + 1 : 0;

                blanks     = end.UpTo(view.LineCount - 1).Where(x => IsLineBlank(view, x));
                end        = blanks.Any() ? blanks.First() - 1 : view.LineCount -1;
            }

            return start.UpTo(end).Select(x => view.GetLineFromLineNumber(x));
        }

        bool IsLineBlank(IDocument view, int lineNo)
        {
            var blankStrings = new[] { string.Empty, "{", "}", "};", ")", "(" };
            var line         = view.GetLineFromLineNumber(lineNo).Text.Trim();
            return blankStrings.Contains(line);
        }
    }
}