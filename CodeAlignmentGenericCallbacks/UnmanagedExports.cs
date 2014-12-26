using System;
using System.Runtime.InteropServices;
using NppPlugin.DllExport;
using System.IO;
using System.Reflection;
using CMcG.CodeAlignment.Business;

namespace CMcG.CodeAlignment
{
    class UnmanagedExports
    {
        #region Delegates

        public delegate void   VoidCallbackVoid        ();
        public delegate void   VoidCallbackIntString   (int somtINT, string someSTRING);
        public delegate int    ReturnIntCallbackVoid   ();
        public delegate int    ReturnIntCallbackInt    (int someINT);
        public delegate string ReturnStringCallbackInt (int someINT);
        public delegate string ReturnStringCallbackVoid();

        #endregion // Delegates

        #region Callback Functions

        public static ReturnIntCallbackVoid    lineCountCallback;
        public static ReturnIntCallbackVoid    selectionStartCallback;
        public static ReturnIntCallbackVoid    selectionEndCallback;
        public static ReturnIntCallbackVoid    getColumnCallback;
        public static ReturnIntCallbackVoid    useTabsCallback;
        public static ReturnIntCallbackVoid    tabWidthCallback;
        public static ReturnStringCallbackVoid fileTypeCallback;
        public static ReturnIntCallbackInt     positionFromLineCallback;
        public static ReturnStringCallbackInt  getLineCallback;
        public static VoidCallbackVoid         startUndoActionCallback;
        public static VoidCallbackVoid         endUndoActionCallback;
        public static VoidCallbackIntString    insertTextCallback;

        #endregion // Callback Functions

        static UnmanagedExports()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
        }

        static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("CodeAlignment.Common"))
            {
                var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Assembly.LoadFile(Path.Combine(location, @"CodeAlignment.Common.dll"));
            }

            return null;
        }

        static AlignFunctions Functions
        {
            get
            {
                return new AlignFunctions
                {
                    UIManager = new UIManager(),
                    Document  = new Document(),
                    Handle    = IntPtr.Zero
                }; }
        }

        #region Align Function Exports

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignBy()
        {
            Functions.AlignByDialog();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignByEquals()
        {
            Functions.AlignBy(Key.EqualsPlus);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignByEqualsEquals()
        {
            Functions.AlignBy("==");
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignBym_()
        {
            Functions.AlignBy(Key.M);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignByQuote()
        {
            Functions.AlignBy(Key.Quotes);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignByPeriod()
        {
            Functions.AlignBy(Key.Period);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignBySpace()
        {
            Functions.AlignBy(Key.Space);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignFromCaret()
        {
            Functions.AlignByDialog(alignFromCaret: true);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void AlignByKey(IntPtr hWnd)
        {
            new AlignFunctions { Document = new Document(), Handle = hWnd }.AlignByKey();
        }

        #endregion // Align Function Exports

        #region Methods for Setting Callbacks

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        static void SetupAllCallbacks(
            ReturnIntCallbackVoid    lineCount,
            ReturnIntCallbackVoid    selectionStart,
            ReturnIntCallbackVoid    selectionEnd,
            ReturnIntCallbackVoid    getColumn,
            ReturnIntCallbackVoid    useTabs,
            ReturnIntCallbackVoid    tabWidth,
            ReturnStringCallbackVoid fileType,
            ReturnIntCallbackInt     positionFromLine,
            ReturnStringCallbackInt  getLine,
            VoidCallbackVoid         startUndoAction,
            VoidCallbackVoid         endUndoAction,
            VoidCallbackIntString    insertText)
        {
            UnmanagedExports.lineCountCallback           = lineCount;
            UnmanagedExports.selectionStartCallback      = selectionStart;
            UnmanagedExports.selectionEndCallback        = selectionEnd;
            UnmanagedExports.getColumnCallback           = getColumn;
            UnmanagedExports.useTabsCallback             = useTabs;
            UnmanagedExports.tabWidthCallback            = tabWidth;
            UnmanagedExports.fileTypeCallback            = fileType;
            UnmanagedExports.positionFromLineCallback    = positionFromLine;
            UnmanagedExports.getLineCallback             = getLine;
            UnmanagedExports.startUndoActionCallback     = startUndoAction;
            UnmanagedExports.endUndoActionCallback       = endUndoAction;
            UnmanagedExports.insertTextCallback          = insertText;
        }

        #endregion // Methods for Setting Callbacks

    }
}
