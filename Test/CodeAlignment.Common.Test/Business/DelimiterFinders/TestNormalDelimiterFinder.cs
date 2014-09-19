using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business.DelimiterFinders
{
    public class TestNormalDelimiterFinder
    {
        [Fact]
        public void GetIndex()
        {
            var instance = new NormalDelimiterFinder();
            Assert.Equal(0, instance.GetIndex("a",      "a", 0, 4));
            Assert.Equal(1, instance.GetIndex("\ta",    "a", 4, 4));
            Assert.Equal(2, instance.GetIndex(" \ta",   "a", 4, 4));
            Assert.Equal(4, instance.GetIndex("\t   a", "a", 3, 4));
        }

        [Fact]
        public void TabbifyIndex()
        {
            var instance = new NormalDelimiterFinder();
            Assert.Equal(2, instance.TabbifyIndex("\ta",  5, 4));
            Assert.Equal(2, instance.TabbifyIndex("\ta",  2, 4));
            Assert.Equal(0, instance.TabbifyIndex("\ta",  3, 4));
            Assert.Equal(3, instance.TabbifyIndex("  a",  3, 1));
        }
    }
}
