using System;
using System.Linq;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment.Test.Business.Mocks
{
    public class MockEdit : IEdit
    {
        public bool Insert(ILine line, int position, string text)
        {
            var mockLine  = (MockLine)line;
            mockLine.Text = mockLine.Text.Insert(position, text);
            return true;
        }

        public void Commit()
        {
        }

        public void Dispose()
        {
        }
    }
}
