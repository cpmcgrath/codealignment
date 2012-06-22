using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public class Alignment
    {
        public IDocument        View     { get; set; }
        public IScopeSelector   Selector { get; set; }
        public IDelimiterFinder Finder   { get; set; }

        public Alignment()
        {
            Selector = new GeneralScopeSelector();
            Finder   = new NormalDelimiterFinder();
        }

        public void PerformAlignment(string delimiter, int minIndex = 0, bool addSpace = false)
        {
            var lines = Selector.GetLinesToAlign(View);
            var data  = lines.Select(x => new LineDetails(x, Finder, delimiter, minIndex, View.TabSize))
                             .Where(y => y.Index >= 0).ToArray();

            if (!data.Any())
                return;

            int targetPosition = data.MaxBy(y => y.Position).GetPositionToAlignTo(addSpace, View.TabSize);

            CommitChanges(data, targetPosition);
        }

        void CommitChanges(LineDetails[] data, int targetPosition)
        {
            using (var edit = View.StartEdit())
            {
                foreach (var change in data)
                {
                    if (!edit.Insert(change.Line, change.Index, GetSpacesToInsert(change.Position, targetPosition)))
                        return;
                }

                edit.Commit();
            }
        }

        string GetSpacesToInsert(int startIndex, int endIndex)
        {
            bool useSpaces = View.ConvertTabsToSpaces;
            if (useSpaces)
                return string.Empty.PadLeft(endIndex - startIndex);

            int spaces = endIndex % View.TabSize;
            int tabs   = (int)Math.Ceiling((endIndex - spaces - startIndex) / (double)View.TabSize);

            return (tabs == 0) ? string.Empty.PadLeft(endIndex - startIndex)
                               : string.Empty.PadLeft(tabs, '\t') + string.Empty.PadLeft(spaces);
        }
    }
}