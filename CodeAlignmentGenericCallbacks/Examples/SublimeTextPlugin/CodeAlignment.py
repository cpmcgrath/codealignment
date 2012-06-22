import sublime
import sublime_plugin

import os
from ctypes import *
from ctypes.wintypes import HWND

class AlignBy(sublime_plugin.TextCommand):

    m_debug = False

    m_lineCount    = 0
    m_firstLineNum = 0
    m_lastLineNum  = 0
    m_endColumn    = 0
    m_useTabs      = False
    m_tabWidth     = 4
    m_fileType     = '.txt'
    m_edit         = None

    def run(self, edit, by='dialog'):

        self.m_edit = edit

        plugin_path = os.path.join(sublime.packages_path(), 'CodeAlignment', os.environ["PROCESSOR_ARCHITECTURE"])

        #
        # Callback Function Prototypes (Delegates)
        #
        VOIDCALLBACKVOID         = CFUNCTYPE(None,                    )
        VOIDCALLBACKINTSTRING    = CFUNCTYPE(None,     c_int, c_char_p)
        RETURNINTCALLBACKVOID    = CFUNCTYPE(c_int,                   )
        RETURNINTCALLBACKINT     = CFUNCTYPE(c_int,    c_int          )
        RETURNSTRINGCALLBACKVOID = CFUNCTYPE(c_char_p,                )
        RETURNSTRINGCALLBACKINT  = CFUNCTYPE(c_char_p, c_int          )

        # Load the CodeAlignment DLL
        self.cadll = cdll.LoadLibrary(plugin_path + os.sep + "CodeAlignmentGenericCallbacks.dll")

        # Configure Setup Method
        self.cadll.SetupAllCallbacks.restype  = None
        self.cadll.SetupAllCallbacks.argtypes = [ c_void_p, c_void_p, c_void_p,
                                                  c_void_p, c_void_p, c_void_p,
                                                  c_void_p, c_void_p, c_void_p,
                                                  c_void_p, c_void_p, c_void_p ]

        #
        # Configure Python Callback Functions
        #
        lineCountCB           = RETURNINTCALLBACKVOID   (self.lineCount)
        selectionStartCB      = RETURNINTCALLBACKVOID   (self.selectionStart)
        selectionEndCB        = RETURNINTCALLBACKVOID   (self.selectionEnd)
        getColumnCB           = RETURNINTCALLBACKVOID   (self.getColumn)
        useTabsCB             = RETURNINTCALLBACKVOID   (self.useTabs)
        tabWidthCB            = RETURNINTCALLBACKVOID   (self.tabWidth)
        fileTypeCB            = RETURNSTRINGCALLBACKVOID(self.fileType)
        positionFromLineCB    = RETURNINTCALLBACKINT    (self.positionFromLine)
        getLineCB             = RETURNSTRINGCALLBACKINT (self.getLine)
        startUndoActionCB     = None # Not needed for Sublime
        endUndoActionCB       = None # Not needed for Sublime
        insertTextCB          = VOIDCALLBACKINTSTRING   (self.insertText)

        # Initialize all of the Callbacks
        self.cadll.SetupAllCallbacks(lineCountCB       ,
                                     selectionStartCB  ,
                                     selectionEndCB    ,
                                     getColumnCB       ,
                                     useTabsCB         ,
                                     tabWidthCB        ,
                                     fileTypeCB        ,
                                     positionFromLineCB,
                                     getLineCB         ,
                                     startUndoActionCB ,
                                     endUndoActionCB   ,
                                     insertTextCB)

        # Configure Alignment Methods
        self.cadll.AlignBy            .restype  = None
        self.cadll.AlignBy            .argtypes = None
        self.cadll.AlignByEquals      .restype  = None
        self.cadll.AlignByEquals      .argtypes = None
        self.cadll.AlignByEqualsEquals.restype  = None
        self.cadll.AlignByEqualsEquals.argtypes = None
        self.cadll.AlignBym_          .restype  = None
        self.cadll.AlignBym_          .argtypes = None
        self.cadll.AlignByQuote       .restype  = None
        self.cadll.AlignByQuote       .argtypes = None
        self.cadll.AlignByPeriod      .restype  = None
        self.cadll.AlignByPeriod      .argtypes = None
        self.cadll.AlignBySpace       .restype  = None
        self.cadll.AlignBySpace       .argtypes = None
        self.cadll.AlignFromCaret     .restype  = None
        self.cadll.AlignFromCaret     .argtypes = None
        self.cadll.AlignByKey         .restype  = None
        self.cadll.AlignByKey         .argtypes = [HWND]


        # Selection
        sel                 = self.view.sel()

        # Settings
        settings            = self.view.settings()

        # m_lineCount
        selLines            = self.view.lines(sel[0])
        self.m_lineCount    = len(selLines)

        # m_firstLineNum
        firstLine           = selLines[0]
        self.m_firstLineNum = self.view.rowcol(firstLine.a)[0]

        # m_lastLineNum
        lastLine            = self.view.lines(sel[0])[self.m_lineCount-1]
        self.m_lastLineNum  = self.view.rowcol(lastLine.b)[0]

        # m_endColumn
        self.m_endColumn    = self.view.rowcol(sel[0].b)[1]

        # m_useTabs
        self.m_useTabs      = not settings.get('translate_tabs_to_spaces')

        # m_tabWidth
        self.m_tabWidth     = int(settings.get('tab_size', 4))

        # m_fileType
        filename, ext       = os.path.splitext(self.view.file_name())
        self.m_fileType     = ext

        if   (by == 'equals'):
            self.cadll.AlignByEquals()
        elif (by == 'equalsequals'):
            self.cadll.AlignByEqualsEquals()
        elif (by == 'm'):
            self.cadll.AlignByM()
        elif (by == 'quote'):
            self.cadll.AlignByQuote()
        elif (by == 'period'):
            self.cadll.AlignByPeriod()
        elif (by == 'space'):
            self.cadll.AlignBySpace()
        elif (by == 'caret'):
            self.cadll.AlignFromCaret()
        elif (by == 'key'):
            self.cadll.AlignByKey(sublime.active_window().hwnd())
        else:
            self.cadll.AlignBy()

    def lineCount(self):
        if (self.m_debug):
            print '    lineCount       () = {0}'.format(self.m_lineCount)
        return self.m_lineCount

    def selectionStart(self):
        if (self.m_debug):
            print '    selectionStart  () = {0}'.format(self.m_firstLineNum)
        return self.m_firstLineNum

    def selectionEnd(self):
        if (self.m_debug):
            print '    selectionEnd    () = {0}'.format(self.m_lastLineNum)
        return self.m_lastLineNum

    def getColumn(self):
        if (self.m_debug):
            print '    getColumn       () = {0}'.format(self.m_endColumn)
        return self.m_endColumn

    def useTabs(self):
        if (self.m_debug):
            print "    useTabs() : {0}".format(self.m_useTabs)
        return self.m_useTabs

    def tabWidth(self):
        if (self.m_debug):
            print "    tabWidth(): {0}".format(self.m_tabWidth)
        return self.m_tabWidth

    def fileType(self):
        if (self.m_debug):
            print '    fileType        () = {0}'.format(self.m_fileType)
        return self.m_fileType;

    def positionFromLine(self, lineNum):
        retVal = self.view.text_point(lineNum, 0)
        if (self.m_debug):
            print '    positionFromLine({0}) = {1}'.format(lineNum, retVal)
        return retVal

    def getLine(self, lineNum):
        fullLineRegion = self.view.line(self.positionFromLine(lineNum))
        sFullLine      = self.view.substr(fullLineRegion)
        if (self.m_debug):
            print '    getLine         ({0}) = "{1}"'.format(lineNum, sFullLine)
        return sFullLine

    def insertText(self, position, text):
        if (self.m_debug):
            print '    insertText      ({0}, "{1}")'.format(position, text)
        self.view.insert(self.m_edit, position, text)
        return
