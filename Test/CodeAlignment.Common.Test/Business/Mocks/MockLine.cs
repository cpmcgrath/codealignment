using System;
using System.Linq;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business.Mocks
{
    public class MockLine : ILine
    {
        public int    Position { get; set; }
        public string Text     { get; set; }
    }
}
