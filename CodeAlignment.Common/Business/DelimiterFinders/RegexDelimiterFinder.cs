using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CMcG.CodeAlignment.Business
{
    public class RegexDelimiterFinder : NormalDelimiterFinder
    {
        public override DelimiterResult GetIndex(string source, string delimiter, int minIndex, int tabSize)
        {
            minIndex = TabbifyIndex(source, minIndex, tabSize);

            if (source.Length < minIndex)
            {
                return DelimiterResult.Create(-1);
            }

            var match = Regex.Match(source.Substring(minIndex), delimiter);

            if (!match.Success)
            {
                return DelimiterResult.Create(-1);
            }

            return new DelimiterResult
            {
                CompareIndex = minIndex + GetGroupIndex(match, "compare", "x"),
                InsertIndex  = minIndex + GetGroupIndex(match, "insert", "compare", "x")
            };
        }

        int GetGroupIndex(Match match, params string[] keys)
        {
            foreach (var key in keys)
            {
                var group = match.Groups[key];
                if (group.Success)
                    return group.Index;
            }

            return match.Index;
        }
    }
}
