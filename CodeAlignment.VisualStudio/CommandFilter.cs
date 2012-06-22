using System;
using System.Linq;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;

namespace CMcG.CodeAlignment
{
    public abstract class CommandFilter : IOleCommandTarget
    {
        protected abstract Guid CommandGuid { get; }

        public IOleCommandTarget Next { get; set; }

        public int Exec(ref Guid cmdGroup, uint cmdId, uint options, IntPtr inArg, IntPtr outArg)
        {
            if (cmdGroup != CommandGuid)
                return Next.Exec(ref cmdGroup, cmdId, options, inArg, outArg);

            Execute(cmdId);
            return VSConstants.S_OK;
        }

        public int QueryStatus(ref Guid cmdGroup, uint cmdCount, OLECMD[] cmds, IntPtr cmdText)
        {
            if (cmdGroup != CommandGuid)
                return Next.QueryStatus(ref cmdGroup, cmdCount, cmds, cmdText);

            foreach (var cmd in cmds)
                cmds[0].cmdf = (uint)CanExecuteResult(cmd.cmdID);

            return VSConstants.S_OK;
        }

        public OLECMDF CanExecuteResult(uint cmdId)
        {
            return CanExecute(cmdId) ? (OLECMDF.OLECMDF_ENABLED | OLECMDF.OLECMDF_SUPPORTED)
                                     :  OLECMDF.OLECMDF_SUPPORTED;
        }

        public virtual bool CanExecute(uint cmdId)
        {
            return true;
        }

        public abstract void Execute(uint cmdId);

        public static void Register(IVsTextView textViewAdapter, CommandFilter filter)
        {
            IOleCommandTarget next;
            if (ErrorHandler.Succeeded(textViewAdapter.AddCommandFilter(filter, out next)))
                filter.Next = next;
        }
    }
}