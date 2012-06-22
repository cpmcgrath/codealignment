using System;

namespace CMcG.CodeAlignment
{
    static class Commands
    {
        public const uint AlignBy             = 0x0100,
                          AlignByEquals       = 0x0200,
                          AlignByEqualsEquals = 0x0300,
                          AlignByMUnderscore  = 0x0400,
                          AlignByQuote        = 0x0500,
                          AlignByPeriod       = 0x0600,
                          AlignBySpace        = 0x0700,
                          AlignFromCaret      = 0x0800,
                          AlignByKey          = 0x0900;
    };
}