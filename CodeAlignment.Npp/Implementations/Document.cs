using System;
using System.Linq;
using System.Text;
using NppPluginNET;
using System.Collections.Generic;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class Document : IDocument
    {
        IntPtr m_docPointer;

        public Document() : this(PluginBase.GetCurrentScintilla()) { }
        public Document(IntPtr documentPointer)
        {
            m_docPointer = documentPointer;
        }

        public int LineCount
        {
            get { return (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETLINECOUNT, 0, 0); }
        }

        public ILine GetLineFromLineNumber(int lineNo)
        {
            return new Line(m_docPointer, lineNo);
        }

        public int StartSelectionLineNumber
        {
            get { return GetLineNumberFromPos((int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETSELECTIONNSTART, 0, 0)); }
        }

        public int EndSelectionLineNumber
        {
            get { return GetLineNumberFromPos((int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETSELECTIONNEND, 0, 0)); }
        }

        public int CarretColumn
        {
            get
            {
                int currPos = (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETCURRENTPOS, 0, 0);
                return (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETCOLUMN, currPos, 0);
            }
        }

        int GetLineNumberFromPos(int position)
        {
            return (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_LINEFROMPOSITION, position, 0);
        }

        public bool ConvertTabsToSpaces
        {
            get { return ((int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETUSETABS, 0, 0)) == 0; }
        }

        public int TabSize
        {
            get { return (int)Win32.SendMessage(m_docPointer, SciMsg.SCI_GETTABWIDTH, 0, 0); }
        }

        public string FileType
        {
            get
            {
                LangType lang;
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETCURRENTLANGTYPE, 0, out lang);
                switch (lang)
                {
                    case LangType.L_XML  : return ".xml";
                    case LangType.L_HTML : return ".html";
                }

                var extension = new StringBuilder(Win32.MAX_PATH);
                var result = Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETEXTPART, Win32.MAX_PATH, extension);
                return extension.ToString().ToLower();
            }
        }

        public IEdit StartEdit()
        {
            return new Edit(m_docPointer);
        }


        public void Refresh()
        {
        }
    }
}