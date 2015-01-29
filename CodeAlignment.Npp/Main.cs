using System;
using System.IO;
using System.Text;
using NppPluginNET;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    class Main
    {
        internal const string PluginName  = "Code alignment";
        static         string s_iniFilePath;

        internal static void CommandMenuInit()
        {
            SetupIniFile();
            SetupCommands();
            SetupAbout();
        }

        static void SetupIniFile()
        {
            var sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
            var path = sbIniFilePath.ToString();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            s_iniFilePath = Path.Combine(path, PluginName + ".ini");
        }

        static void SetupCommands()
        {
            SetCommand( 0, "Align by...",            x => x.AlignByDialog(), new ShortcutKey(true, false, true,  Keys.Oemplus));
            SetCommand( 1, "Align by equals",        x => x.AlignBy(Key.EqualsPlus));
            SetCommand( 2, "Align by equals equals", x => x.AlignBy("=="));
            SetCommand( 3, "Align by m_",            x => x.AlignBy(Key.M));
            SetCommand( 4, "Align by quote (\")",    x => x.AlignBy(Key.Quotes));
            SetCommand( 5, "Align by period",        x => x.AlignBy(Key.Period));
            SetCommand( 6, "Align by space",         x => x.AlignBy(Key.Space));
            SetCommand( 6, "Align from caret",       x => x.AlignByDialog(alignFromCaret:true));
            SetCommand(99, "Align by key",           x => x.AlignByKey(),    new ShortcutKey(true, false, false, Keys.Oemplus));
        }

        static void SetCommand(int index, string name, Action<AlignFunctions> action, ShortcutKey shortcut = new ShortcutKey())
        {
            PluginBase.SetCommand(index, name, () => action.Invoke(GetFunctions()), shortcut);
        }

        static AlignFunctions GetFunctions()
        {
            return new AlignFunctions
            {
                UIManager = new UIManager(),
                Document  = new Document(),
                Handle    = PluginBase.nppData._nppHandle
            };
        }

        internal static void SetToolBarIcon()
        {
            var tbIcons  = new toolbarIcons();
            var pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
        }

        static void SetupAbout()
        {
            AboutData.MainAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            AboutData.Image        = Properties.Resources.CodeAlignmentNppBanner;
        }
    }
}