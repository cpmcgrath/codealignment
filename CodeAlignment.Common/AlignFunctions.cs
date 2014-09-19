using System;
using System.Linq;
using System.Drawing;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    public class AlignFunctions
    {
        Business.Options m_options       = new Business.Options();
        Point            m_keyGrabOffset = new Point(10, -50);

        public IDocument Document { get; set; }
        public IntPtr    Handle   { get; set; }

        public Point KeyGrabOffset
        {
            get { return m_keyGrabOffset; }
            set { m_keyGrabOffset = value; }
        }

        public void AlignBy(string alignDelimiter, bool alignFromCaret = false, bool useRegex = false, bool addSpace = false)
        {
            if (!string.IsNullOrEmpty(alignDelimiter))
                CreateAlignment(useRegex).PerformAlignment(alignDelimiter, alignFromCaret ? Document.CarretColumn : 0, addSpace);
        }

        public void AlignBy(Key key, bool forceFromCaret = false)
        {
            var shortcut = m_options.GetShortcut(key, Document.FileType);
            if (shortcut != null)
                AlignBy(shortcut.Alignment, forceFromCaret || shortcut.AlignFromCaret, shortcut.UseRegex, shortcut.AddSpace);
        }

        public void AlignByDialog(bool alignFromCaret = false)
        {
            var result = ShowAlignDialog(alignFromCaret);
            if (result != null)
                AlignBy(result.Delimiter, result.AlignFromCaret, useRegex:result.UseRegex);
        }

        Alignment CreateAlignment(bool useRegex = false)
        {
            var alignment = new Alignment { View = Document, UseIdeTabSettings = m_options.UseIdeTabSettings };

            if (m_options.XmlTypes.Contains(Document.FileType))
                alignment.Selector = new XmlScopeSelector
                                     {
                                         Start              = Document.StartSelectionLineNumber,
                                         End                = Document.EndSelectionLineNumber
                                     };
            else
                alignment.Selector = new GeneralScopeSelector
                                     {
                                         ScopeSelectorRegex = m_options.ScopeSelectorRegex,
                                         Start              = Document.StartSelectionLineNumber,
                                         End                = Document.EndSelectionLineNumber
                                     };

            if (useRegex)
                alignment.Finder = new RegexDelimiterFinder();

            return alignment;
        }

        public FormCodeAlignment ShowAlignDialog(bool alignFromCaret)
        {
            var form = new FormCodeAlignment { AlignFromCaret = alignFromCaret };
            return form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel ? null : form;
        }

        public void AlignByKey()
        {
            var viewModel = new AlignmentViewModel(this, CreateAlignment());

            using (var form = new FormKeyGrabber { ViewModel = viewModel })
            {
                form.SetLocation(Handle, KeyGrabOffset);
                form.ShowDialog();
            }
        }
    }
}