using System;
using System.Linq;

namespace CMcG.CodeAlignment.Business
{
    public class DelimiterResult
    {
        public int CompareIndex { get; set; }
        public int InsertIndex  { get; set; }

        public static DelimiterResult Create(int index)
        {
            return new DelimiterResult
            {
                CompareIndex = index,
                InsertIndex  = index
            };
        }
    }
}
