using System;

namespace CMcG.CodeAlignment.Business
{
    public interface IDelimiterFinder
    {
        int GetIndex(string source, string delimiter, int minIndex, int tabSize);
    }
}