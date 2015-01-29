using CMcG.CodeAlignment.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMcG.CodeAlignment
{
    public class UIManager : IUIManager
    {
        public IKeyGrabber GetKeyGrabber(AlignmentViewModel viewModel)
        {
            return new FormKeyGrabber { ViewModel = viewModel };
        }

        public IAlignmentDetails PromptForAlignment(bool alignFromCaret)
        {
            var form = new FormCodeAlignment { AlignFromCaret = alignFromCaret };
            return form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel ? null : form;
        }
    }
}
