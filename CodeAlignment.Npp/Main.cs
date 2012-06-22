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
            var functions = new AlignFunctions { Document = new Document(), Handle = PluginBase.nppData._nppHandle };

            PluginBase.SetCommand( 0, "Align by...",            () => functions.AlignByDialog(), new ShortcutKey(true, false, true,  Keys.Oemplus));
            PluginBase.SetCommand( 1, "Align by equals",        () => functions.AlignBy(Key.EqualsPlus));
            PluginBase.SetCommand( 2, "Align by equals equals", () => functions.AlignBy("=="));
            PluginBase.SetCommand( 3, "Align by m_",            () => functions.AlignBy(Key.M));
            PluginBase.SetCommand( 4, "Align by quote (\")",    () => functions.AlignBy(Key.Quotes));
            PluginBase.SetCommand( 5, "Align by period",        () => functions.AlignBy(Key.Period));
            PluginBase.SetCommand( 6, "Align by space",         () => functions.AlignBy(Key.Space));
            PluginBase.SetCommand( 6, "Align from caret",       () => functions.AlignByDialog(alignFromCaret:true));
            PluginBase.SetCommand(99, "Align by key",           functions.AlignByKey,    new ShortcutKey(true, false, false, Keys.Oemplus));
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