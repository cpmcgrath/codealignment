using System;
using System.Collections.Generic;

namespace CMcG.CodeAlignment.Business
{
    public interface IScopeSelector
    {
        IEnumerable<ILine> GetLinesToAlign(IDocument view);
    }
}
