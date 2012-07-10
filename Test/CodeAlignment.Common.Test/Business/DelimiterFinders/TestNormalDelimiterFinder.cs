using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business.DelimiterFinders
{
    public class TestNormalDelimiterFinder
    {
        [Fact]
        public void GetIndex()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void TabbifyIndex()
        {
            var instance = new NormalDelimiterFinder();
            Assert.Equal(2, instance.TabbifyIndex("\ta", 5, 4));
            Assert.Equal(2, instance.TabbifyIndex("\ta", 2, 4));
            Assert.Equal(0, instance.TabbifyIndex("\ta", 3, 4));
            Assert.Equal(3, instance.TabbifyIndex("  a", 3, 1));
        }
    }
}
