using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.Expression.Extensibility;
using Microsoft.Expression.DesignModel.Code;
using Microsoft.Expression.DesignSurface.View;
using Microsoft.Expression.Framework.Documents;

namespace CMcG.CodeAlignment
{
    public abstract class Package : IPackage
    {
        Window m_oldWindow;

        protected WPFSceneView View { get; private set; }

        protected virtual void OnViewChanged() { }

        public virtual void Load(IServices services)
        {
            var viewService = services.GetService<IViewService>();
            viewService.ActiveViewChanged += OnActiveViewChanged;
        }

        public void Unload() { }

        public Window CurrentWindow
        {
            get { return View != null ? Window.GetWindow(View.ViewRootContainer) : null; }
        }

        List<Tuple<ModifierKeys, Key, Action>> m_shortcuts = new List<Tuple<ModifierKeys, Key, Action>>();
        protected void AddShortcut(ModifierKeys modKeys, Key key, Action action)
        {
            m_shortcuts.Add(Tuple.Create(modKeys, key, action));
        }

        void OnActiveViewChanged(object sender, ViewChangedEventArgs e)
        {
            if (m_oldWindow != null)
                m_oldWindow.KeyDown -= OnKeyDown;

            m_oldWindow = CurrentWindow;
            View        = e.NewView as WPFSceneView;
            OnViewChanged();

            if (CurrentWindow != null)
                CurrentWindow.KeyDown += OnKeyDown;
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            var shortcut = m_shortcuts.FirstOrDefault(x => x.Item1 == e.KeyboardDevice.Modifiers && x.Item2 == e.Key);

            if (shortcut != null)
            {
                shortcut.Item3();
                e.Handled = true;
            }
        }
    }

    public static class BlendExtensions
    {
        public static ITextBuffer GetTextBuffer(this ITextEditor instance)
        {
            return (ITextBuffer)instance.GetType().GetProperty("TextBuffer").GetValue(instance, null);
        }
    }
}