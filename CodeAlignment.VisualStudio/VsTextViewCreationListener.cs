using System;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;

namespace CMcG.CodeAlignment
{
    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    class VsTextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        IVsEditorAdaptersFactoryService AdaptersFactory = null;

        static VsTextViewCreationListener()
        {
            AboutData.MainAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            AboutData.Image        = Resources.CodeAlignmentVSBanner;
        }

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            var wpfTextView = AdaptersFactory.GetWpfTextView(textViewAdapter);
            if (wpfTextView != null)
                CommandFilter.Register(textViewAdapter, new CodeAlignmentCommandFilter(textViewAdapter, wpfTextView));
        }
    }
}