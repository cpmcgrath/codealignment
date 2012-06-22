using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Edit : IEdit
    {
        public Edit()
        {
            if (UnmanagedExports.startUndoActionCallback != null)
            {
                UnmanagedExports.startUndoActionCallback();
            }
        }

        public bool Insert(ILine line, int position, string text)
        {
            if (UnmanagedExports.insertTextCallback != null)
            {
                UnmanagedExports.insertTextCallback(line.Position + position, text);
                return true;
            }
            return false;
        }

        public void Commit()
        {
            if (UnmanagedExports.endUndoActionCallback != null)
            {
                UnmanagedExports.endUndoActionCallback();
            }
        }

        public void Dispose()
        {
        }
    }
}
