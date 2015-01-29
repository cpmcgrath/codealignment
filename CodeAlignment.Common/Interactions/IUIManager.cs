using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CMcG.CodeAlignment.Interactions
{
    public interface IUIManager
    {
        IKeyGrabber GetKeyGrabber(AlignmentViewModel viewModel);

        IAlignmentDetails PromptForAlignment(bool alignFromCaret);
    }

    public interface IKeyGrabber : IDisposable
    {
        AlignmentViewModel ViewModel { get; set; }
        void Display();
        void SetBounds(Rectangle bounds);
    }

    public interface IAlignmentDetails
    {
        string Delimiter      { get; }
        bool   AlignFromCaret { get; set; }
        bool   UseRegex       { get; set; }
    }
}
