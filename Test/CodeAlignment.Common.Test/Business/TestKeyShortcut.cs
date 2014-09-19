using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xunit;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business
{
    [Serializable]
    public class TestKeyShortcut
    {
        [Fact]
        public void SerializeAndGet()
        {
            var shortcut = new KeyShortcut
            {
                AddSpace       = true,
                AlignFromCaret = true,
                Alignment      = " = ",
                Language       = "CSharp",
                UseRegex       = true,
                Value          = Key.EqualsPlus
            };

            var xml        = KeyShortcut.Serialize(new[] { shortcut });
            var cloneArray = KeyShortcut.Get(xml);
            Assert.Equal(1, cloneArray.Length);

            var clone = cloneArray[0];

            Assert.Equal(shortcut.AddSpace,       clone.AddSpace);
            Assert.Equal(shortcut.AlignFromCaret, clone.AlignFromCaret);
            Assert.Equal(shortcut.Alignment,      clone.Alignment);
            Assert.Equal(shortcut.Language,       clone.Language);
            Assert.Equal(shortcut.UseRegex,       clone.UseRegex);
            Assert.Equal(shortcut.Value,          clone.Value);
        }
    }
}