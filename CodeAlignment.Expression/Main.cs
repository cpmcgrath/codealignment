using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Interop;
using System.ComponentModel.Composition;
using Microsoft.Expression.Extensibility;
using Microsoft.Expression.DesignSurface.View;

namespace CMcG.CodeAlignment
{
    [Export(typeof(IPackage))]
    public class Main : Package
    {
        AlignFunctions m_functions = new AlignFunctions();

        public override void Load(IServices services)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            AddShortcut(ModifierKeys.Control,                      Key.OemPlus, () => m_functions.AlignByKey());
            AddShortcut(ModifierKeys.Control | ModifierKeys.Shift, Key.OemPlus, () => m_functions.AlignByDialog());
            base.Load(services);
        }

        protected override void OnViewChanged()
        {
            var editor           = View != null && View.ViewMode != ViewMode.Design ? View.CodeEditor : null;
            m_functions.Document = editor != null ? new Implementations.Document(editor) : null;

            if (View != null)
                m_functions.Handle = new WindowInteropHelper(CurrentWindow).Handle;
        }
    }
}