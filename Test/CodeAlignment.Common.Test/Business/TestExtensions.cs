using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business
{
    public class TestExtensions
    {
        [Fact]
        public void UpTo()
        {
            Assert.Equal(new int[] { 1,2,3,4,5 }, 1.UpTo(5));
            Assert.Equal(new int[] { },           1.UpTo(0));
            Assert.Equal(new int[] { 1 },         1.UpTo(1));
        }

        [Fact]
        public void DownTo()
        {
            Assert.Equal(new int[] { 5,4,3,2,1 }, 5.DownTo(1));
            Assert.Equal(new int[] { },           5.DownTo(6));
            Assert.Equal(new int[] { 1 },         1.DownTo(1));
        }

        [Fact]
        public void ReplaceTabs()
        {
            Assert.Equal("    ",      "\t"     .ReplaceTabs(4));
            Assert.Equal("|   |",     "|\t|"   .ReplaceTabs(4));
            Assert.Equal("|   |",     "| \t|"  .ReplaceTabs(4));
            Assert.Equal("|   |",     "|  \t|" .ReplaceTabs(4));
            Assert.Equal("|       |", "|   \t|".ReplaceTabs(4));
            Assert.Equal("|       |", "| \t\t|".ReplaceTabs(4));
        }

        [Fact]
        public void MaxBy()
        {
            var data = new[] { "A", "B", "C", "DZ" };
            Assert.Throws<ArgumentNullException>    (() => ((IEnumerable<string>)null).MaxBy(x => x.Length));
            Assert.Throws<ArgumentNullException>    (() => data.MaxBy<string, int>(null));
            Assert.Throws<InvalidOperationException>(() => new string[0].MaxBy(x => x.Length));

            Assert.Equal("DZ", data.MaxBy(x => x.Length));
            Assert.Equal("A",  data.Take(3).MaxBy(x => x.Length));
        }

        [Fact]
        public void MaxItemsBy()
        {
            var data = new[] { "A", "B", "C", "AA", "BB", "DZZ" };
            Assert.Throws<ArgumentNullException>    (() => ((IEnumerable<string>)null).MaxItemsBy(x => x.Length));
            Assert.Throws<ArgumentNullException>    (() => data.MaxItemsBy<string, int>(null));
            Assert.Throws<InvalidOperationException>(() => new string[0].MaxItemsBy(x => x.Length));

            Assert.Equal(new[] { "DZZ" },      data        .MaxItemsBy(x => x.Length));
            Assert.Equal(new[] { "AA", "BB" }, data.Take(5).MaxItemsBy(x => x.Length));
        }

        [Fact]
        public void Aggregate()
        {
            Assert.Equal(string.Empty, new string[0]     .Aggregate(", "));
            Assert.Equal("A",          new[] { "A" }     .Aggregate(", "));
            Assert.Equal("A, B",       new[] { "A", "B" }.Aggregate(", "));
        }
    }
}
