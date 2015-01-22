using System;
using System.Linq;

namespace CMcG.CodeAlignment.Business
{
    public class NormalDelimiterFinder : IDelimiterFinder
    {
        public virtual DelimiterResult GetIndex(string source, string delimiter, int minIndex, int tabSize)
        {
            minIndex = TabbifyIndex(source, minIndex, tabSize);

            int result = source.Length >= minIndex ? source.IndexOf(delimiter, minIndex) : -1;
            return DelimiterResult.Create(result);
        }

        public int TabbifyIndex(string source, int minIndex, int tabSize)
        {
            int adjustment = 0;
            int index      = source.IndexOf('\t');

            while (index >= 0 && index < minIndex)
            {
                int padding = tabSize - (index % tabSize);
                if (index + padding - 1 <= minIndex)
                    adjustment += padding - 1;
                source = source.Remove(index, 1).Insert(index, string.Empty.PadLeft(padding));
                index  = source.IndexOf('\t');
            }

            return minIndex - adjustment;
        }
    }
}