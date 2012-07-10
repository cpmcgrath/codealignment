using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CMcG.CodeAlignment.Business
{
    public class RegexDelimiterFinder : NormalDelimiterFinder
    {
        public override int GetIndex(string source, string delimiter, int minIndex, int tabSize)
        {
            minIndex = TabbifyIndex(source, minIndex, tabSize);

            if (source.Length < minIndex)
                return -1;

            var match = Regex.Match(source.Substring(minIndex), delimiter);

            if (!match.Success)
                return -1;

            var group = match.Groups["x"];
            return (group.Success ? group.Index  : match.Index) + minIndex;
        }
    }
}
