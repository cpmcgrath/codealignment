using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public class LineDetails
    {
        public LineDetails(ILine line, IDelimiterFinder finder, string delimiter, int minIndex, int tabSize)
        {
            var withoutTabs = line.Text.ReplaceTabs(tabSize);
            Line            = line;
            Index           = finder.GetIndex(line.Text,   delimiter, minIndex, tabSize);
            Position        = finder.GetIndex(withoutTabs, delimiter, minIndex, tabSize);
        }

        public ILine Line     { get; private set; }
        public int   Index    { get; private set; }
        public int   Position { get; private set; }

        public int GetPositionToAlignTo(bool addSpace, int tabSize)
        {
            if (addSpace && Position > 0 && Line.Text.ReplaceTabs(tabSize)[Position - 1] != ' ')
                return Position + 1;

            return Position;
        }
    }
}