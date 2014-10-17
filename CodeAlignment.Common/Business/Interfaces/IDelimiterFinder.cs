using System;

namespace CMcG.CodeAlignment.Business
{
    public interface IDelimiterFinder
    {
        DelimiterResult GetIndex(string source, string delimiter, int minIndex, int tabSize);
    }
}