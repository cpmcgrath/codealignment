using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Line : ILine
    {
        int m_lineNo;

        public Line(int lineNo)
        {
            m_lineNo = lineNo;
        }

        public string Text
        {
            get
            {
                if (UnmanagedExports.getLineCallback != null)
                {
                    return UnmanagedExports.getLineCallback(m_lineNo);
                }

                return "";
            }
        }

        public int Position
        {
            get
            {
                if (UnmanagedExports.positionFromLineCallback != null)
                {
                    return UnmanagedExports.positionFromLineCallback(m_lineNo);
                }

                return 0;
            }
        }
    }
}