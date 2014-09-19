using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Document : IDocument
    {
        public Document()
        {
        }

        public int LineCount
        {
            get
            {
                if (UnmanagedExports.lineCountCallback != null)
                {
                    return UnmanagedExports.lineCountCallback();
                }

                return 0;
            }
        }

        public ILine GetLineFromLineNumber(int lineNo)
        {
            return new Line(lineNo);
        }

        public int StartSelectionLineNumber
        {
            get
            {
                if (UnmanagedExports.selectionStartCallback != null)
                {
                    return UnmanagedExports.selectionStartCallback();
                }

                return 0;
            }
        }

        public int EndSelectionLineNumber
        {
            get
            {
                if (UnmanagedExports.selectionEndCallback != null)
                {
                    return UnmanagedExports.selectionEndCallback();
                }

                return 0;
            }
        }

        public int CarretColumn
        {
            get
            {
                if (UnmanagedExports.getColumnCallback != null)
                {
                    return UnmanagedExports.getColumnCallback();
                }

                return 0;
            }
        }

        public bool ConvertTabsToSpaces
        {
            get
            {
                if (UnmanagedExports.useTabsCallback != null)
                {
                    return (UnmanagedExports.useTabsCallback() != 0);
                }

                return false;
            }
        }

        public int TabSize
        {
            get
            {
                if (UnmanagedExports.tabWidthCallback != null)
                {
                    return UnmanagedExports.tabWidthCallback();
                }

                return 4;
            }
        }

        public string FileType
        {
            get
            {
                if (UnmanagedExports.fileTypeCallback != null)
                {
                    return UnmanagedExports.fileTypeCallback();
                }

                return ".txt";
            }
        }

        public IEdit StartEdit()
        {
            return new Edit();
        }


        public void Refresh()
        {
        }
    }
}