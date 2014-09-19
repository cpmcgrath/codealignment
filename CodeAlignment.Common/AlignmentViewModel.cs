using System;
using System.Linq;
using System.Drawing;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class AlignmentViewModel
    {
        Business.Options m_options = new Business.Options();
        Alignment m_alignment;
        AlignFunctions m_functions;

        int m_lastAlignment = -1;

        public AlignmentViewModel(AlignFunctions functions, Alignment alignment)
        {
            m_alignment = alignment;
            m_functions = functions;
        }

        public void AlignFromPosition()
        {
            m_functions.AlignByDialog(alignFromCaret:true);
        }

        public int PerformAlign(Key key, bool forceFromCaret)
        {
            m_alignment.View.Refresh();
            var shortcut = m_options.GetShortcut(key, m_functions.Document.FileType);

            if (shortcut != null && !string.IsNullOrEmpty(shortcut.Alignment))
            {
                m_alignment.Finder = GetFinder(shortcut);
                int minIndex       = GetMinIndex(forceFromCaret, shortcut);
                m_lastAlignment    = m_alignment.PerformAlignment(shortcut.Alignment, minIndex, shortcut.AddSpace);
                return m_lastAlignment;
            }

            return -1;
        }

        IDelimiterFinder GetFinder(KeyShortcut shortcut)
        {
            return shortcut.UseRegex ? new RegexDelimiterFinder() : new NormalDelimiterFinder();
        }

        int GetMinIndex(bool forceFromCaret, KeyShortcut shortcut)
        {
            if (m_lastAlignment != -1)
                return m_lastAlignment + 1;

            if (forceFromCaret || shortcut.AlignFromCaret)
                return m_functions.Document.CaretColumn;

            return 0;
        }
    }
}