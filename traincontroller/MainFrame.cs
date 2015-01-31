using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;
using wx.Html;
using System.Timers;

namespace TrainDirNET {
  public class MainFrame : Frame {
    //private CanvasManager m_canvasManager;	    // we can have different upper-left corners
    public TimeTableViewManager m_timeTableManager = new TimeTableViewManager();// we can have different stations
    public TimeTableView m_timeTable;

    //
    //
    //

    //private GlobalVariables.traindir m_app;
    public NotebookManager m_top;		// top (pages are Canvases or TimeTable or Html)
    private NotebookManager m_left;	// bottom-left
    private NotebookManager m_right;	// bottom-right
    private SplitterWindow m_splitter;
    private SplitterWindow m_bottomSplitter;
    private int m_topSashValue;
    private ToolBar m_toolbar;
    private StatusBar m_statusbar;
    private Timer m_timer;
    public TimeFrame m_timeFrame;	// showing time table in separate frame
    private HtmlEasyPrinting m_printer;
    private String m_htmlPage;

    public ItineraryView m_itineraryView;
    private ToolsView m_toolsView;
    private GraphView m_graphView;
    private LateGraphView m_lateGraphView;
    private PlatformGraphView m_platformGraphView;
    private TrainInfoList m_trainInfo;
    public AlertList m_alertList;

    private Menu m_viewMenu;


    //
    //  Toolbar objects
    //

    StaticText m_clock;
    SpinButton m_speedArrows;
    TextCtrl m_speed;
    public ToggleButton m_running;
    StaticText m_statusText;
    StaticText m_alertText;

    //  Current state (saved to config file)

    bool m_showToolbar;
    bool m_showStatusbar;
    public TimaTableLocation m_timeTableLocation;

    public MainFrame(string title) /// TODO
      : base(null, (int)MenuIDs2.wxID_ANY, title) {

      m_timer = new Timer(); // TIMER_ID;
      //m_itineraryView = 0;
      //m_toolsView = 0;
      //m_graphView = 0;
      //m_lateGraphView = 0;
      //m_platformGraphView = 0;
      //m_alertList = 0;
      m_trainInfo = null;

      //
      //	Menus
      //

      Menu fileMenu = new Menu();
      fileMenu.Append((int)MenuIDs2.wxID_OPEN, "&Open...\tCtrl-O", "Open a simulation file.");
      fileMenu.Append((int)MenuIDs2.wxID_SAVE, "&Save Game...", "Open a saved simulation file.");
      fileMenu.Append((int)MenuIDs2.wxID_REVERT, "&Restore...", "Restore from the last saved state.");
      fileMenu.AppendSeparator();
      fileMenu.Append((int)MenuIDs.MENU_HTML_PRINTSETUP, "Page set&up", "Changes the page layout settings.");
      fileMenu.Append((int)MenuIDs.MENU_HTML_PREVIEW, "Pre&view", "Preview print output.");
      fileMenu.Append((int)MenuIDs.MENU_HTML_PRINT, "&Print", "Print all or part of the document.");
      fileMenu.AppendSeparator();
      fileMenu.Append((int)MenuIDs2.wxID_EXIT, "E&xit\tAlt-F4", "Quit this program.");

      Menu editMenu = new Menu();
      editMenu.Append((int)MenuIDs.MENU_EDIT, "&Edit\tCtrl-E", "Enter/exit layout editor.");
      //	editMenu.Append((int)MenuIDs.MENU_NEW_TRAIN, "&New Train...", "Enter data about a new train.");
      editMenu.Append((int)MenuIDs.MENU_ITINERARY, "&Itinerary", "Enter/exit itinerary editor.");
      editMenu.Append((int)MenuIDs.MENU_SWITCHBOARD, "Switch&board", "Shows the switchboard editor.");
      editMenu.Append((int)MenuIDs.MENU_SAVE_LAYOUT, "&Save Layout", "Save changes to the layout.");
      editMenu.Append((int)MenuIDs.MENU_PREFERENCES, "&Preferences...", "Change program's preferences.");
      //	editMenu.Append((int)MenuIDs.MENU_EDIT_SKIN, "S&kin colors...", "Change the colors of graphical elements.");
      editMenu.Append((int)MenuIDs.MENU_NEW_LAYOUT, "Ne&w", "Erase the layout.");
      editMenu.Append((int)MenuIDs.MENU_INFO, "In&fo", "Show information about the scenario.");
      editMenu.Append((int)MenuIDs.MENU_STATIONS_LIST, "Stations &List", "Show list of stations and entry points.");

      Menu runMenu = new Menu();
      runMenu.Append((int)MenuIDs.MENU_START, "&Start\tCtrl-S", "Start/stop the simulation.");
      runMenu.Append((int)MenuIDs.MENU_GRAPH, "&Graph\tCtrl-G", "Show the timetable graph.");
      runMenu.Append((int)MenuIDs.MENU_LATEGRAPH, "&Late Graph\tCtrl-L", "Show accumulation of late minutes over time.");
      runMenu.Append((int)MenuIDs.MENU_PLATFORMGRAPH, "&Platform Graph", "Show platforms occupancy over time.");
      runMenu.Append((int)MenuIDs.MENU_RESTART, "&Restart...", "Restart the simulation.");
      runMenu.Append((int)MenuIDs.MENU_FAST, "&Fast\tCtrl-X", "Speed up the simulation.");
      runMenu.Append((int)MenuIDs.MENU_SLOW, "&Slow\tCtrl-Z", "Slow down the simulation.");
      runMenu.Append((int)MenuIDs.MENU_SKIP, "S&kip ahead\tCtrl-K", "Skip to 3 minutes before next evt.");
      runMenu.Append((int)MenuIDs.MENU_STATION_SCHED, "S&tation schedule\tF6", "Show the train schedule of each station.");
      runMenu.Append((int)MenuIDs.MENU_SETGREEN, "Set sig. to green", "Set all automatic signals to green.");
      runMenu.Append((int)MenuIDs.MENU_SELECT_ITIN, "Select Itinerary\tCtrl-I", "Select an itinerary by name.");
      runMenu.Append((int)MenuIDs.MENU_PERFORMANCE, "&Performance", "Show performance data.");

      m_viewMenu = new Menu();
      m_viewMenu.Append((int)MenuIDs.MENU_SHOW_LAYOUT, "Show layout\tF3", "Forcibly show the layout window.");
      m_viewMenu.Append((int)MenuIDs.MENU_SHOW_SCHEDULE, "Show schedule\tF4", "Forcibly show the schedule window.");
      m_viewMenu.Append((int)MenuIDs.MENU_INFO_PAGE, "Show info page\tF5", "Shows the scenario info page, if available.");
      m_viewMenu.AppendSeparator();
      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_SPLIT, "Timetable in split window", "View timetable in a split window.");
      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_TAB, "Timetable in tabbed window", "View timetable in a tab of the main window.");
      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_FRAME, "Timetable in separate window", "View timetable in a window separate from the main window.");

      m_viewMenu.AppendSeparator();

      m_viewMenu.Append((int)MenuIDs.MENU_ZOOMIN, "Zoom in", "Draw the layout at double the resolution.");
      m_viewMenu.Append((int)MenuIDs.MENU_ZOOMOUT, "Zoom out", "Draw the layour at normal resolution.");

      m_viewMenu.AppendSeparator();

      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_SHOW_COORD, "Coord bars", "View/hide the coordinate bars.");
      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_TOOLBAR, "Tool bar", "View/hide the tools bar.");
      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_STATUSBAR, "Status bar", "View/hide the status bar.");

      Menu helpMenu = new Menu();
      helpMenu.Append((int)MenuIDs2.wxID_ABOUT, "Welcome\tF1", "Show the welcome page.");
      helpMenu.Append((int)MenuIDs.MENU_COPYRIGHT, "Copyright", "Show the copyright notice.");
      helpMenu.Append((int)MenuIDs.MENU_LANGUAGE, "Language", "Select the language to be used next time GlobalVariables.traindir is started.");

      MenuBar menuBar = new MenuBar();

      menuBar.Append(fileMenu, "&File");
      menuBar.Append(editMenu, "&Edit");
      menuBar.Append(runMenu, "&Run");
      menuBar.Append(m_viewMenu, "&View");
      menuBar.Append(helpMenu, "&Help");

      this.MenuBar = menuBar;

      MenuItem pItem;

      /// TODO
      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TIME_SPLIT)) != null)
        pItem.Checked = true;
      m_timeTableLocation = TimaTableLocation.TIME_TABLE_SPLIT;
      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TOOLBAR)) != null)
        pItem.Checked = true;
      m_showToolbar = true;
      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_STATUSBAR)) != null)
        pItem.Checked = true;
      m_showStatusbar = true;
      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_SHOW_COORD)) != null)
        pItem.Checked = GlobalVariables.bShowCoord;

      EVT_MENU((int)MenuIDs2.wxID_OPEN, new EventListener(OnOpenFile));
      //EVT_MENU((int)MenuIDs.MENU_RECENT, new EventListener(OnRecent));
      //EVT_MENU((int)MenuIDs2.wxID_SAVE, new EventListener(OnSaveGame));
      //EVT_MENU((int)MenuIDs2.wxID_REVERT, new EventListener(OnRestore));
      //EVT_MENU((int)MenuIDs.MENU_HTML_PRINTSETUP, new EventListener(OnPrintSetup));
      //EVT_MENU((int)MenuIDs.MENU_HTML_PREVIEW, new EventListener(OnPrintPreview));
      //EVT_MENU((int)MenuIDs.MENU_HTML_PRINT, new EventListener(OnPrint));
      //EVT_MENU((int)MenuIDs2.wxID_EXIT, new EventListener(OnQuit));

      //EVT_MENU((int)MenuIDs.MENU_EDIT, new EventListener(OnEdit));
      //EVT_MENU((int)MenuIDs.MENU_NEW_TRAIN, new EventListener(OnNewTrain));
      //EVT_MENU((int)MenuIDs.MENU_ITINERARY, new EventListener(OnItinerary));
      //EVT_MENU((int)MenuIDs.MENU_SWITCHBOARD, new EventListener(OnSwitchboard));
      //EVT_MENU((int)MenuIDs.MENU_SAVE_LAYOUT, new EventListener(OnSaveLayout));
      //EVT_MENU((int)MenuIDs.MENU_PREFERENCES, new EventListener(OnPreferences));
      //EVT_MENU((int)MenuIDs.MENU_EDIT_SKIN, new EventListener(OnEditSkin));
      //EVT_MENU((int)MenuIDs.MENU_NEW_LAYOUT, new EventListener(OnNewLayout));
      //EVT_MENU((int)MenuIDs.MENU_INFO, new EventListener(OnInfo));
      //EVT_MENU((int)MenuIDs.MENU_STATIONS_LIST, new EventListener(OnShowStationsList));

      //EVT_MENU((int)MenuIDs.MENU_START, new EventListener(OnStartStop));
      //EVT_MENU((int)MenuIDs.MENU_GRAPH, new EventListener(OnGraph));
      //EVT_MENU((int)MenuIDs.MENU_LATEGRAPH, new EventListener(OnLateGraph));
      //EVT_MENU((int)MenuIDs.MENU_PLATFORMGRAPH, new EventListener(OnPlatformGraph));
      //EVT_MENU((int)MenuIDs.MENU_RESTART, new EventListener(OnRestart));
      //EVT_MENU((int)MenuIDs.MENU_FAST, new EventListener(OnFast));
      //EVT_MENU((int)MenuIDs.MENU_SLOW, new EventListener(OnSlow));
      //EVT_MENU((int)MenuIDs.MENU_SKIP, new EventListener(OnSkip));
      //EVT_MENU((int)MenuIDs.MENU_STATION_SCHED, new EventListener(OnStationSched));
      //EVT_MENU((int)MenuIDs.MENU_SETGREEN, new EventListener(OnSetGreen));
      //EVT_MENU((int)MenuIDs.MENU_SELECT_ITIN, new EventListener(OnSelectItin));
      //EVT_MENU((int)MenuIDs.MENU_PERFORMANCE, new EventListener(OnPerformance));

      //EVT_MENU((int)MenuIDs.MENU_ZOOMIN, new EventListener(OnZoomIn));
      //EVT_MENU((int)MenuIDs.MENU_ZOOMOUT, new EventListener(OnZoomOut));

      //EVT_MENU((int)MenuIDs.MENU_SHOW_COORD, new EventListener(OnShowCoord));
      EVT_MENU((int)MenuIDs.MENU_SHOW_LAYOUT, new EventListener(OnShowLayout));
      //EVT_MENU((int)MenuIDs.MENU_SHOW_SCHEDULE, new EventListener(OnShowSchedule));
      //EVT_MENU((int)MenuIDs.MENU_INFO_PAGE, new EventListener(OnShowInfoPage));

      //EVT_MENU((int)MenuIDs.MENU_TIME_SPLIT, new EventListener(OnTimeTableSplit));
      //EVT_MENU((int)MenuIDs.MENU_TIME_TAB, new EventListener(OnTimeTableTab));
      //EVT_MENU((int)MenuIDs.MENU_TIME_FRAME, new EventListener(OnTimeTableFrame));

      //EVT_MENU((int)MenuIDs.MENU_TOOLBAR, new EventListener(OnToolBar));
      //EVT_MENU((int)MenuIDs.MENU_STATUSBAR, new EventListener(OnStatusBar));
      EVT_MENU((int)MenuIDs2.wxID_ABOUT, new EventListener(OnAbout));
      EVT_MENU((int)MenuIDs.MENU_COPYRIGHT, new EventListener(OnCopyright));
      //EVT_MENU((int)MenuIDs.MENU_LANGUAGE, new EventListener(OnLanguage));

      EVT_TOGGLEBUTTON((int)MenuIDs.ID_RUN, new EventListener(OnRunButton));

      EVT_SPIN_UP((int)MenuIDs.ID_SPIN, new EventListener(OnSpinUp));
      EVT_SPIN_DOWN((int)MenuIDs.ID_SPIN, new EventListener(OnSpinDown));

      //EVT_CLOSE(new EventListener(OnClose));
      m_timer.Elapsed += new ElapsedEventHandler(OnTimer); //EVT_TIMER((int)MenuIDs.TIMER_ID, new EventListener(OnTimer));
      //EVT_CHAR(new EventListener(OnChar));


      //
      //	Toolbar
      //
      string buff = ""; //wxPorting.T('M'), 70);

      m_toolbar = new ToolBar(this, (int)MenuIDs2.wxID_ANY,
              wxDefaultPosition, wxDefaultSize,
        /// TODO
        /// wxTB_HORIZONTAL | wxNO_BORDER | wxTB_DOCKABLE);
              WindowStyles.TB_DOCKABLE);

      m_clock = new StaticText(m_toolbar, 0, "",
          wxDefaultPosition, wxDefaultSize);
      m_clock.Label = wxPorting.T("   00:00.00    ");
      m_toolbar.AddControl(m_clock);

      m_speed = new TextCtrl(m_toolbar, (int)MenuIDs.ID_SPEEDTEXT, wxPorting.T("10"), wxDefaultPosition,
            new System.Drawing.Size(40, 30));
      m_speed.Enable(false);
      m_toolbar.AddControl(m_speed);

      m_speedArrows = new SpinButton(m_toolbar, (int)MenuIDs.ID_SPIN);
      m_speedArrows.Value = 5;
      m_toolbar.AddControl(m_speedArrows);

      m_toolbar.AddSeparator();

      m_running = new ToggleButton(m_toolbar, (int)MenuIDs.ID_RUN,
          "Start", wxDefaultPosition, new System.Drawing.Size(50, 30));
      m_toolbar.AddControl(m_running);

      m_toolbar.AddSeparator();

      m_statusText = new StaticText(m_toolbar, wxID_ANY, "",
          wxDefaultPosition, wxDefaultSize);
      m_statusText.Label = buff;
      m_toolbar.AddControl(m_statusText);

      m_toolbar.AddSeparator();

      m_alertText = new StaticText(m_toolbar, wxID_ANY, "",
          wxDefaultPosition, wxDefaultSize);
      m_alertText.Label = buff;
      m_toolbar.AddControl(m_alertText);

      m_toolbar.Realize();
      this.ToolBar = m_toolbar;

      m_statusText.Label = wxPorting.T("");
      m_alertText.Label = wxPorting.T("");

      //
      //	Status bar
      //

      StatusBar m_statusBar = new StatusBar(this);
      int[] widths = new int[Configuration.NSTATUSBOXES] { -50, -30, -20, -30, -50 };
      m_statusBar.SetFieldsCount(widths.Length, widths);
      this.StatusBar = m_statusBar;

      //
      //	Client area
      //
      //	m_splitter controls the top and bottom views
      //

      m_splitter = new MySplitterWindow(this);
      m_splitter.SashGravity = 1.0;

      //
      //	the top view is the layout Canvas
      //	inside a managing notebook
      //

      m_top = new NotebookManager(m_splitter, wxPorting.T("top"), (int)MenuIDs.ID_NOTEBOOK_TOP);


      Canvas pCanvas = new Canvas(m_top);
      pCanvas.Name = wxPorting.T("canvas");
      m_top.AddPage(pCanvas, "Layout", true, -1);

      //
      //	the bottom view is another splitter
      //

      m_bottomSplitter = new MySplitterWindow(m_splitter);
      m_bottomSplitter.SashGravity = 0.5;

      //
      //	the bottom left view has a managed
      //	notebook which will hold the schedule
      //	list, edit tools view and itinerary list
      //

      m_left = new NotebookManager(m_bottomSplitter, wxPorting.T("left"), (int)MenuIDs.ID_NOTEBOOK_LEFT);
      m_timeTable = m_timeTableManager.GetNewTimeTableView(m_left, "Schedule");

      m_itineraryView = new ItineraryView(m_left, "Itinerary");
      m_itineraryView.Show(false);

      //
      //	the bottom right view has a managed
      //	notebook which will hold the train
      //	info list and the alerts list
      //

      m_right = new NotebookManager(m_bottomSplitter, wxPorting.T("right"), (int)MenuIDs.ID_NOTEBOOK_RIGHT);
      m_alertList = new AlertList(m_right, "Alerts");
      m_trainInfo = new TrainInfoList(m_right, "Train Info");

      m_timeFrame = null;

      // you can also do this to start with a single window
      // ERIK # if 0
      m_top.Show(false);
      m_splitter.Initialize(m_left);
      // ERIK # else
      // you can also try -100
      m_splitter.SplitHorizontally(m_top, m_bottomSplitter, 300);

      System.Drawing.Size sz = this.Size;
      m_bottomSplitter.SplitVertically(m_left, m_right, -300);

      m_top.Show(true);
      m_left.Show(true);
      m_right.Show(true);
      m_timer.Interval = 100;
      m_timer.Start();

      // gLogger.SetParent(this);

      m_printer = new HtmlEasyPrinting("", this);

      m_timeFrame = null;

      GlobalVariables.track_properties_dialog = ShowTrackProperties;
      GlobalVariables.signal_properties_dialog = ShowSignalProperties;
      GlobalVariables.trigger_properties_dialog = ShowTriggerProperties;
      GlobalVariables.performance_dialog = ShowPerformance;
      GlobalVariables.options_dialog = ShowOptionsDialog;
      GlobalVariables.select_day_dialog = ShowDaySelectionDialog;
      GlobalVariables.train_info_dialog = ShowTrainInfoDialog;
      GlobalVariables.assign_dialog = ShowAssignDialog;
      GlobalVariables.station_sched_dialog = ShowStationScheduleDialog;
      GlobalVariables.itinerary_dialog = ShowItineraryDialog;
      GlobalVariables.about_dialog = GlobalFunctions.ShowWelcomePage;
    }

    public void OnAbout(object sender, Event evt) {
      GlobalFunctions.ShowWelcomePage();
    }

    // TODO Add personal informations
    public void OnCopyright(object sender, Event evt) {
      string notice;

      notice = string.Format(wxPorting.T("{0} - {1}\n\n"), GlobalVariables.program_name, Configuration.__DATE__);	// L("Traindir 3.0\n\n");
      notice += wxPorting.L("Created by");
      notice += wxPorting.T(" Giampiero Caprino\n\n");
      notice += wxPorting.L("This is free software, released under the\nGNU General Public License Version 2.\nThe author declines any responsibility for any damage\nthat might occur from the use of this program.");
      notice += wxPorting.T("    \n\n");
      notice += wxPorting.L("This is a game, and is not intended to\nbe used to actually control train traffic.");

      MessageDialog.MessageBox(notice);
    }
#if false
    public void OnLanguage(object sender, Event evt) {
      ConfigDialog diag = new ConfigDialog(this);

      if(!diag.ShowModal())
        return;
    }

    //
    //	OnQuit
    //	    Called from the File+Exit menu,
    //	    or from the Alt-F4 accelerator of the File+Exit menu
    //

    public void OnQuit(object sender, Event evt) {
      Close();
    }

    //
    //	OnClose
    //	    Called from the "Close" item of the system menu of the frame,
    //	    or when the close button "x" in the frame is clicked.
    //

    public void OnClose(object sender, Event evt) {
      //  TODO: save in project-specific file

      if(layout_modified) {
        if(ask_to_save_layout() < 0)
          return;
      }
      GlobalVariables.traindir.SaveState();
      if(user_name._sValue.Length() > 0) {
        bstreet_logout();
      }
      Destroy();
    }

    //
    //
    //

    MainFrame() {
      if(m_splitter) {
        delete m_splitter;
        m_splitter = 0;
      }
      if(m_printer) {
        delete m_printer;
        m_printer = 0;
      }
    }

    //	The travels of the time table view...
    //
    //	The time table can be in any of 3 states:
    //	1) default it is a tab in the left notebook of the horizontal splitter
    //	2) it's a tab in the top (only) notebook
    //	3) it's the only child of a separate frame
    //
    //	The following routines implement the transitions
    //	between these 3 states

    void MoveTimeTableToTab() {
      if(m_timeTableLocation == TIME_TABLE_SPLIT) {
        m_topSashValue = m_splitter.GetSashPosition();
        m_left.RemovePage(m_timeTable);
      } else if(m_timeTableLocation == TIME_TABLE_FRAME) {
        m_timeFrame.Show(false);
      }
      m_timeTable.Reparent(m_top);
      m_top.AddPage(m_timeTable, L("Schedule"));
      m_splitter.Unsplit();
      m_timeTableLocation = TIME_TABLE_TAB;
      //	AddTimeTable(m_top);
    }

    void MoveTimeTableToSplit() {
      if(m_timeTableLocation == TIME_TABLE_TAB) {
        m_top.RemovePage(m_timeTable);
      } else if(m_timeTableLocation == TIME_TABLE_FRAME) {
        m_timeFrame.Show(false);
      }
      m_splitter.SplitHorizontally(m_top, m_bottomSplitter, m_topSashValue);
      m_timeTableLocation = TIME_TABLE_SPLIT;
      m_timeTable.Reparent(m_left);
      m_left.AddPage(m_timeTable, L("Schedule"));
    }

    void MoveTimeTableToFrame() {
      if(!m_timeFrame)
        m_timeFrame = new TimeFrame(this, L("Schedule"));

      if(m_timeTableLocation == TIME_TABLE_TAB) {
        m_top.RemovePage(m_timeTable);
      } else if(m_timeTableLocation == TIME_TABLE_SPLIT) {
        m_topSashValue = m_splitter.GetSashPosition();
        m_left.RemovePage(m_timeTable);
        m_splitter.Unsplit();
      }

      m_timeTable.Reparent(m_timeFrame);
      Size size = m_timeFrame.GetClientSize();
      m_timeTable.SetSize(0, 0, size.x, size.y);
      m_timeFrame.Show(true);
      m_timeTable.Show(true);
      m_timeTable.Refresh();
      m_timeTableLocation = TIME_TABLE_FRAME;
    }

    //
    //	LoadState()
    //	    Reload the state of the frame window (position, size)
    //	    from file saved on the last run.
    //

    void LoadState(string header, TConfig state) {
      string line;
      bool gotDimensions = false;
      bool bMaximized = false;
      Size size = new Size(-1, -1);
      Point pos = new Point(-1, -1);
      int nTimetables = 0;
      int sashPosition = 100;
      int lowerSashPosition = 100;
      bool bGotSash = false;
      bool bGotLowerSash = false;

      if(!state.FindSection(header))
        return;

      int v;

      //
      //  Reload information about the size and position of the window
      //

      if(state.GetInt(wxT("isMaximized"), v))
        bMaximized = v ? true : false;
      if(state.GetInt(wxT("showStatusBar"), v))
        m_showStatusbar = v ? true : false;
      if(state.GetInt(wxT("showToolBar"), v))
        m_showToolbar = v ? true : false;
      if(state.GetInt(wxT("showCoord"), v))
        bShowCoord = v ? true : false;

      if(state.GetInt(wxT("x"), v)) {
        gotDimensions = true;
        pos.x = v;
      }
      if(state.GetInt(wxT("y"), v)) {
        gotDimensions = true;
        pos.y = v;
      }
      if(state.GetInt(wxT("w"), v)) {
        gotDimensions = true;
        size.x = v;
      }
      if(state.GetInt(wxT("h"), v)) {
        gotDimensions = true;
        size.y = v;
      }

      //
      //  Reload state of splitter
      //

      bGotSash = state.GetInt(wxT("sash"), sashPosition);
      bGotLowerSash = state.GetInt(wxT("lower-sash"), lowerSashPosition);

      if(gotDimensions) {
        SetPosition(pos);
        SetSize(size);
      }
      if(bGotSash) {
        m_splitter.SetSashPosition(sashPosition);
        m_topSashValue = sashPosition;
      }
      if(bGotLowerSash) {
        m_bottomSplitter.SetSashPosition(lowerSashPosition);
      }

      //	Maximize(bMaximized);

      //  Synchronize menus

      wxMenuBar pBar = GetMenuBar();
      wxMenuItem pItem;

      if(m_toolbar) {
        if((pItem = pBar.FindItem(MENU_TOOLBAR, 0)))
          pItem.Check(m_showToolbar);
        m_toolbar.Show(pItem.IsChecked());
      }
      wxStatusBar pStatus;

      if((pStatus = GetStatusBar())) {
        if((pItem = pBar.FindItem(MENU_STATUSBAR, 0)))
          pItem.Check(m_showStatusbar);
        pStatus.Show(m_showStatusbar);
      }

      set_show_coord(bShowCoord);
      if((pItem = pBar.FindItem(MENU_SHOW_COORD, 0)))
        pItem.Check(bShowCoord);

      int val;
      int loc;
      if(!state.GetInt(wxT("timeTableLocation"), loc))
        loc = m_timeTableLocation;
      switch(loc) {
        case TIME_TABLE_TAB:

          val = MENU_TIME_TAB;
          MoveTimeTableToTab();
          break;

        case TIME_TABLE_FRAME:

          m_timeFrame = new TimeFrame(this, L("Schedule"));
          gotDimensions = false;
          if(state.GetInt(wxT("timex"), v)) {
            gotDimensions = true;
            pos.x = v;
          }
          if(state.GetInt(wxT("timey"), v)) {
            gotDimensions = true;
            pos.y = v;
          }
          if(state.GetInt(wxT("timew"), v)) {
            gotDimensions = true;
            size.x = v;
          }
          if(state.GetInt(wxT("timeh"), v)) {
            gotDimensions = true;
            size.y = v;
          }
          if(gotDimensions) {
            m_timeFrame.SetPosition(pos);
            m_timeFrame.SetSize(size);
          }
          MoveTimeTableToFrame();
          val = MENU_TIME_FRAME;
          break;

        case TIME_TABLE_SPLIT:
        default:
          val = MENU_TIME_SPLIT;
      }
      m_timeTableLocation = loc;

      if((pItem = pBar.FindItem(val, 0)))
        pItem.Check(m_showToolbar);

      SendSizeevt();

      //
      //  Reload the dimensions of each list view for each
      //  of the views.
      //

      m_top.LoadState(header, state);
      m_left.LoadState(header, state);
      m_right.LoadState(header, state);
      if(m_timeTableLocation == TIME_TABLE_FRAME) {
        m_timeTable.LoadState(wxT("time-frame"), state);
      }
    }

    //
    //	SaveState()
    //	    Save the state (size, position) of the frame window
    //	    and the state of any child view, mainly the list views
    //

    void SaveState(string header, TConfig state) {
      int nTT = 0;

      m_top.SaveState(header, state);
      m_left.SaveState(header, state);
      m_right.SaveState(header, state);
      if(m_timeFrame) {
        if(m_timeTableLocation == TIME_TABLE_FRAME) {
          m_timeTable.SaveState(wxT("time-frame"), state);
        }
      }

      state.StartSection(header);
      state.PutInt(wxT("isMaximized"), IsMaximized());
      state.PutInt(wxT("showStatusBar"), m_showStatusbar);
      state.PutInt(wxT("showToolBar"), m_showToolbar);
      state.PutInt(wxT("showCoord"), bShowCoord);
      state.PutInt(wxT("timeTableLocation"), m_timeTableLocation);

      Size size = GetSize();
      Point pos = GetPosition();

      state.PutInt(wxT("x"), pos.x);
      state.PutInt(wxT("y"), pos.y);
      state.PutInt(wxT("w"), size.x);
      state.PutInt(wxT("h"), size.y);
      state.PutInt(wxT("sash"), m_splitter.GetSashPosition());
      state.PutInt(wxT("lower-sash"), m_bottomSplitter.GetSashPosition());

      state.PutInt(wxT("selected"), m_top.GetSelection());

      if(m_timeFrame) {
        size = m_timeFrame.GetSize();
        pos = m_timeFrame.GetPosition();
        state.PutInt(wxT("timex"), pos.x);
        state.PutInt(wxT("timey"), pos.y);
        state.PutInt(wxT("timew"), size.x);
        state.PutInt(wxT("timeh"), size.y);
      }
    }

    //
    //
    //

    void AddTimeTable(NotebookManager parent) {
      int i;

      for(i = 0; i < parent.GetPageCount(); ++i) {
        wxWindow pPage = parent.GetPage(i);
        if(pPage.GetName() == wxT("timetable")) {
          break;
        }
      }
      if(i >= parent.GetPageCount()) {	// not found, maybe first time
        TimeTableView pTimeTable =
      m_timeTableManager.GetNewTimeTableView(parent, L("Schedule"));
        parent.AddPage(pTimeTable, L("Schedule"), false, -1);
        parent.SetSelection(i);
      }
    }

    //
    //
    //

    void Finalize() {
      int i;

      switch(m_timeTableLocation) {
        case TIME_TABLE_TAB:
          //	    AddTimeTable(m_top);
          if(m_top.FindPage(m_timeTable) < 0)
            m_top.AddPage(m_timeTable, L("Schedule"), false, -1);
          m_timeTable.Reparent(m_top);
          break;

        case TIME_TABLE_SPLIT:
          //	    AddTimeTable(m_left);
          //	    if((i = m_left.FindPageType(wxT("timetable"))) < 0)
          if(m_left.FindPage(m_timeTable) < 0)
            m_left.AddPage(m_timeTable, L("Schedule"), false, -1);
          m_timeTable.Reparent(m_left);
          break;

        case TIME_TABLE_FRAME:
          break;
      }

      // see if we already created the alerts tab
      // when loading the state of the right notebook

      i = m_right.FindPageType(wxT("alerts"));
      if(i < 0)	// not found, maybe first time
        m_right.AddPage(m_alertList, L("Alerts"), false, -1);

      // see if we already created the traininfo tab
      // when loading the state of the right notebook

      i = m_right.FindPageType(wxT("traininfo"));
      if(i < 0)	// not found, maybe first time
        m_right.AddPage(m_trainInfo, L("Train Info"), false, -1);

      repaint_labels();
    }

    //
    //
    //

    public void OnPrintSetup(object sender, Event evt) {
      m_printer.PageSetup();
    }

    //
    //
    //

    public void OnPrintPreview(object sender, Event evt) {
      wxWindow w = m_top.GetCurrentPage();
      if(!w)
        return;
      if("htmlview".Equals(w.GetName())) {
        HtmlView p = (HtmlView)w;
        p.OnPrintPreview(evt);
      } else {
        wxMessageBox(L("Printing of this page is not supported."),
          wxT("Error"), wxOK | wxICON_STOP, this);
      }
    }

    //
    //
    //

    public void OnPrint(object sender, Event evt) {
      wxWindow w = m_top.GetCurrentPage();
      if(!w)
        return;
      string name = w.GetName();
      if(name == wxT("htmlview")) {
        HtmlView p = (HtmlView)w;
        p.OnPrint(evt);
      } else if(name == wxT("canvas")) {
        Canvas p = (Canvas)w;
        p.DoPrint();
      } else {
        wxMessageBox(L("Printing of this page is not supported."),
          wxT("Error"), wxOK | wxICON_STOP, this);
      }
    }

#endif
    public void OnTimer(object sender, ElapsedEventArgs e) {
      GlobalVariables.traindir.OnTimer();
    }
#if false

    //
    //	Customize user interface
    //


    public void OnZoomIn(object sender, Event evt) {
      set_zoom(true);
      int pg = m_top.FindPage(L("Layout"));
      if(pg >= 0) {
        m_top.SetSelection(pg);
        m_top.Refresh();
      }
    }

    //
    //
    //

    public void OnZoomOut(object sender, Event evt) {
      set_zoom(false);
      int pg = m_top.FindPage(L("Layout"));
      if(pg >= 0) {
        m_top.SetSelection(pg);
        m_top.Refresh();
      }
    }

    //
    //
    //

    public void OnShowCoord(object sender, Event evt) {
      wxMenuBar pBar = GetMenuBar();
      wxMenuItem pItem;

      if((pItem = pBar.FindItem(MENU_SHOW_COORD, 0))) {
        bShowCoord = pItem.IsChecked();
      }
      //	bShowCoord = !bShowCoord;
      set_show_coord(bShowCoord);
      invalidate_field();
      repaint_all();
    }

    //
    //
    //
#endif
    public void OnShowLayout(object sender, Event evt) {
      int pg = m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0) {
        m_top.Selection = pg;
        m_top.Refresh();
      }
    }
#if false
    //
    //
    //

    public void OnShowSchedule(object sender, Event evt) {
      int pg;
      NotebookManager parent;

      if(m_timeTableLocation == TIME_TABLE_TAB)
        parent = m_top;
      else if(m_timeTableLocation == TIME_TABLE_SPLIT)
        parent = m_left;
      else // TODO: bring frame to top
        return;
      pg = parent.FindPage(L("Schedule"));
      if(pg >= 0) {
        parent.SetSelection(pg);
        //	    parent.Refresh();
      }
    }

    //
    //
    //

    public void OnShowInfoPage(object sender, Event evt) {
      if(!info_page[0])
        return;
      string page = new string(wxT("showinfo "));
      page += info_page;
      trainsim_cmd(page.c_str());
    }

    string anchor = "";
    string htmltext = "";

    struct HourLinks {
      object m_next; // HourLinks *m_next
      string m_hour;
      string m_station;
      string m_link;
    };

    HourLinks pHourLinks;

    //
    //
    //

    void TraverseNodes(HtmlCell node) {
      HtmlCell child;

      if(!node) {
        return;
      }
      string txt = node.ConvertToText(NULL);
      wxStrncpy(htmltext, txt, sizeof(htmltext) / sizeof(string));
      wxHtmlLinkInfo link = node.GetLink();

      anchor[0] = 0;
      if(link) {
        wxStrncpy(anchor, link.GetHref(), sizeof(anchor) / sizeof(string));
      }
      if(htmltext[0]) {
        if(htmltext[2] == ':' && wxStrlen(htmltext) == 5 && wxIsdigit(htmltext[1]) && anchor[0]) {
          HourLinks p = new HourLinks();
          p.m_next = pHourLinks;
          pHourLinks = p;
          p.m_link = anchor;
          p.m_hour = htmltext;
        }
      }
      for(child = node.GetFirstChild(); child; ) {
        TraverseNodes(child);
        child = child.GetNext();
      }
    }

    //
    //
    //

    int GetHtmlPage(string url) {
      // ERIK # if 0
      string pc;
      string pc1;

      if(strncmp(url, wxT("http://"), 7))
        return 0;

      pc = url + 7;
      for(pc1 = anchor; pc && pc != '/'; pc1++ = pc++) ;
      pc1 = 0;

      wxHTTP http;
      http.Connect(anchor/*"reiseauskunft.bahn.de"*/, 80);
      wxInputStream inp = http.GetInputStream(pc);//"/bin/zuginfo.exe/en/338733/224970/999712/386945/80/");

      FILE fp;
      int ch;
      fp = fopen("C:/temp/tt.htm", "w");
      while(!inp.Eof()) {
        ch = inp.GetC();
        fputc(ch, fp);
      }
      fclose(fp);
      // ERIK # endif
      return 0;
    }

    int m_TrainPageStatus = 0;
    //
    //
    //

    void GetListOfTrains(HtmlCell node) {
      HtmlCell child;

      if(!node) {
        return;
      }
      string txt = node.ConvertToText(NULL);
      wxStrncpy(htmltext, txt, sizeof(htmltext) / sizeof(string));
      wxHtmlLinkInfo link = node.GetLink();

      anchor[0] = 0;
      if(link) {
        wxStrncpy(anchor, link.GetHref(), sizeof(anchor) / sizeof(string));
      }
      if(htmltext[0]) {
        switch(m_TrainPageStatus) {
          case 5:
            return;

          case 4:
            if(!wxStrcmp(htmltext, wxT("shown"))) {
              m_TrainPageStatus = 5;
              break;
            }
            goto st2;

          case 3:
            if(!wxStrcmp(htmltext, wxT("stops"))) {
              m_TrainPageStatus = 4;
              break;
            }
          st2:
            m_TrainPageStatus = 2;
          // fall through

          case 2:
          if(!wxStrcmp(htmltext, wxT("All"))) {
            m_TrainPageStatus = 3;
            break;
          }
          // ERIK # if 0
          if(0 && htmltext[2] == ':' && wxStrlen(htmltext) == 5 && wxIsdigit(htmltext[1]) && anchor[0]) {
            HourLinks p = new HourLinks();
            p.m_next = pHourLinks;
            pHourLinks = p;
            p.m_link = anchor;
            p.m_hour = htmltext;
          }
          // ERIK # endif
          break;


          case 1:
          if(!wxStrcmp(htmltext, wxT("Train"))) {
            m_TrainPageStatus = 2;
            break;
          }

          m_TrainPageStatus = 0;
          // fall through

          case 0:
          if(!wxStrcmp(htmltext, wxT("Time ")))
            m_TrainPageStatus = 1;
          break;
        }
      }
      for(child = node.GetFirstChild(); child; ) {
        GetListOfTrains(child);
        child = child.GetNext();
      }
    }

    //
    //
    //
#if false
    void ParseStationPage(HtmlView htmlView, string fname) {
      wxFileName name = new wxFileName(fname);
      htmlView.LoadFile(name);
      wxHtmlContainerCell root = htmlView.GetInternalRepresentation();
      m_TrainPageStatus = 0;
      GetListOfTrains(root);
    }
#endif
    //
    //
    //

    public void OnShowStationsList(object sender, Event evt) {
      // ERIK # if 01
      GlobalVariables.traindir.ShowStationsList();
      // ERIK # else
      int pg = m_top.FindPage(wxT("stations"));
      HtmlView htmlView;

      if(pg < 0) {
        htmlView = new HtmlView(m_top);
        m_top.AddPage(htmlView, wxT("stations"), true, -1);
      } else
        htmlView = (HtmlView)m_top.GetPage(pg);

      pHourLinks = 0;

      GetHtmlPage(wxT("http://reiseauskunft.bahn.de/bin/zuginfo.exe/en/338733/224970/999712/386945/80/"));

      wxFileName name = new wxFileName(wxT("C:/temp/vc.htm"));
      htmlView.LoadFile(name);
      wxHtmlContainerCell root = htmlView.GetInternalRepresentation();
      TraverseNodes(root);

      HourLinks ph;
      for(ph = pHourLinks; ph; ph = ph.m_next) {
        GetHtmlPage(ph.m_link.fn_str());
        /// TODO
        // ParseStationPage(htmlView, wxT("C:/temp/tt.htm"));
        /***/
        break;
      }
      wxFileName name1 = new wxFileName(wxT("C:/temp/tt.htm"));
      htmlView.LoadFile(name1);

      pg = m_top.FindPage(wxT("stations"));
      m_top.SetSelection(pg);
      // ERIK # endif
    }

    //
    //
    //

    public void OnTimeTableSplit(object sender, Event evt) {
      MoveTimeTableToSplit();
      OnShowLayout(evt);
    }

    //
    //
    //

    public void OnTimeTableTab(object sender, Event evt) {
      MoveTimeTableToTab();
    }

    //
    //
    //

    public void OnTimeTableFrame(object sender, Event evt) {
      MoveTimeTableToFrame();
    }

    //
    //
    //

    public void OnToolBar(object sender, Event evt) {
      wxMenuBar pBar = GetMenuBar();
      wxMenuItem pItem;

      if((pItem = pBar.FindItem(MENU_TOOLBAR, 0))) {
        m_toolbar.Show(m_showToolbar = pItem.IsChecked());
        SendSizeevt();
      }
    }

    //
    //
    //

    public void OnStatusBar(object sender, Event evt) {
      wxMenuBar pBar = GetMenuBar();
      wxMenuItem pItem;
      wxStatusBar pStatus;

      if((pItem = pBar.FindItem(MENU_STATUSBAR, 0))) {
        pStatus = GetStatusBar();
        pStatus.Show(m_showStatusbar = pItem.IsChecked());
        SendSizeevt();
      }
    }

#endif
    public void OnRunButton(object sender, Event evt) {
      bool pressed = m_running.State;
      GlobalVariables.traindir.OnStartStop();
    }

    public void OnOpenFile(object sender, Event evt) {
      GlobalVariables.traindir.OnOpenFile();
    }

    public void OnSpinUp(object sender, Event evt) {
      GlobalFunctions.trainsim_cmd(wxPorting.T("fast"));
      /// TODO
      // evt.StopPropagation();
    }

    public void OnSpinDown(object sender, Event evt) {
      GlobalFunctions.trainsim_cmd(wxPorting.T("slow"));
      /// TODO
      // evt.StopPropagation();
    }

#if false

    //
    //
    //

    public void OnRecent(object sender, Event evt) {
      GlobalVariables.traindir.OnRecent();
    }

    public void OnRestore(object sender, Event evt) {
      GlobalVariables.traindir.OnRestore();
    }

    public void OnSaveGame(object sender, Event evt) {
      GlobalVariables.traindir.OnSaveGame();
    }

    public void OnEdit(object sender, Event evt) {
      GlobalVariables.traindir.OnEdit();
    }

    public void OnNewTrain(object sender, Event evt) {
      GlobalVariables.traindir.OnNewTrain();
    }

    public void OnItinerary(object sender, Event evt) {
      GlobalVariables.traindir.OnItinerary();
    }

    public void OnSwitchboard(object sender, Event evt) {
      ShowSwitchboard();
    }

    public void OnSaveLayout(object sender, Event evt) {
      GlobalVariables.traindir.OnSaveLayout();
    }

    public void OnPreferences(object sender, Event evt) {
      GlobalVariables.traindir.OnPreferences();
    }

    public void OnEditSkin(object sender, Event evt) {
      TDSkin tmpSkin = new TDSkin();

      tmpSkin.name = wxStrdup(curSkin.name);
      tmpSkin.background = curSkin.background;
      tmpSkin.free_track = curSkin.free_track;
      tmpSkin.next = 0;
      tmpSkin.occupied_track = curSkin.occupied_track;
      tmpSkin.outline = curSkin.outline;
      tmpSkin.reserved_shunting = curSkin.reserved_shunting;
      tmpSkin.reserved_track = curSkin.reserved_track;
      tmpSkin.working_track = curSkin.working_track;
      tmpSkin.text = curSkin.text;

      SkinColorsDialog skin = new SkinColorsDialog(traindir.m_frame, tmpSkin);

      if(skin.ShowModal() != wxID_OK)
        return;

      if(curSkin == defaultSkin) {
        tmpSkin.name = wxStrdup(wxT("Skin1"));
        tmpSkin.next = skin_list;
        skin_list = tmpSkin;
        curSkin = tmpSkin;
      } else {
        curSkin.background = tmpSkin.background;
        curSkin.free_track = tmpSkin.free_track;
        curSkin.occupied_track = tmpSkin.occupied_track;
        curSkin.outline = tmpSkin.outline;
        curSkin.reserved_shunting = tmpSkin.reserved_shunting;
        curSkin.reserved_track = tmpSkin.reserved_track;
        curSkin.working_track = tmpSkin.working_track;
        curSkin.text = tmpSkin.text;
        delete tmpSkin;
      }
    }

    public void OnNewLayout(object sender, Event evt) {
      GlobalVariables.traindir.OnNewLayout();
    }

    public void OnInfo(object sender, Event evt) {
      GlobalVariables.traindir.OnInfo();
    }

    public void OnStartStop(object sender, Event evt) {
      GlobalVariables.traindir.OnStartStop();
    }

    public void OnGraph(object sender, Event evt) {
      GlobalVariables.traindir.OnGraph();
    }

    public void OnLateGraph(object sender, Event evt) {
      ShowLateGraph();
    }

    public void OnPlatformGraph(object sender, Event evt) {
      ShowPlatformGraph();
    }

    public void OnRestart(object sender, Event evt) {
      GlobalVariables.traindir.OnRestart();
    }

    public void OnFast(object sender, Event evt) {
      GlobalVariables.traindir.OnFast();
    }

    public void OnSlow(object sender, Event evt) {
      GlobalVariables.traindir.OnSlow();
    }

    public void OnSkip(object sender, Event evt) {
      GlobalVariables.traindir.OnSkipToNext();
    }

    public void OnStationSched(object sender, Event evt) {
      GlobalVariables.traindir.OnStationSched();
    }

    public void OnSetGreen(object sender, Event evt) {
      GlobalVariables.traindir.OnSetGreen();
    }

    public void OnSelectItin(object sender, Event evt) {
      if(!itinKeyDialog)
        itinKeyDialog = new ItineraryKeyDialog(this);

      itinKeyDialog.ShowModal();
    }

    public void OnPerformance(object sender, Event evt) {
      GlobalVariables.traindir.OnPerformance();
    }
#endif
    public void ShowTrainInfoList(Train trn) {
      int pg = m_right.FindPage(wxPorting.L("Train Info"));
      if(pg >= 0)
        m_right.Selection = pg;
      m_trainInfo.Update(trn);
    }
#if false
    void ShowItinerary(bool show) {
      if(!show) {
        m_itineraryView.Show(false);
        m_left.RemovePage(m_itineraryView);
        return;
      }
      m_itineraryView.Show(true);
      m_left.AddPage(m_itineraryView, L("Itinerary"), true, -1);
    }

    void ShowTools(bool show) {
      bool firstTime = false;

      if(!show) {
        if(!m_toolsView)
          return;
        m_toolsView.Show(false);
        m_left.RemovePage(m_toolsView);
        return;
      }
      if(!m_toolsView) {
        ToolsView pView = new ToolsView(m_left);
        m_toolsView = pView;
        firstTime = true;
      }
      m_toolsView.Show(true);
      m_left.AddPage(m_toolsView, L("Tools"), true, -1);

      int pg = m_left.FindPage(L("Tools"));
      if(pg >= 0) {
        m_left.SetSelection(pg);
        m_left.Refresh();
      }
      if(firstTime)
        trainsim_cmd(wxT("selecttool 1,0"));
    }
#endif
    public void ShowHtml(string name, string page) {
      int pg = m_top.FindPage(name);
      HtmlView htmlView;

      if(pg < 0) {
        htmlView = new HtmlView(m_top);
        m_top.AddPage(htmlView, name, true, -1);
      } else
        htmlView = (HtmlView)m_top.GetPage(pg);
      htmlView.SetPage(page);
      pg = m_top.FindPage(name);
      m_top.Selection = pg;
    }
#if false
    void ShowGraph() {
      if(!m_graphView) {
        GraphView pView = new GraphView(m_top);
        m_graphView = pView;
      }
      m_graphView.Show(true);

      int pg = m_top.FindPage(L("Graph"));
      if(pg >= 0)
        m_top.SetSelection(pg);
      else
        m_top.AddPage(m_graphView, L("Graph"), true, -1);
      m_graphView.Refresh();
      m_top.Refresh();
    }

    void ShowLateGraph() {
      if(!m_lateGraphView) {
        LateGraphView pView = new LateGraphView(m_top);
        m_lateGraphView = pView;
      }
      m_lateGraphView.Show(true);

      int pg = m_top.FindPage(L("Late Graph"));
      if(pg >= 0)
        m_top.SetSelection(pg);
      else
        m_top.AddPage(m_lateGraphView, L("Late Graph"), true, -1);
      m_lateGraphView.Refresh();
      m_top.Refresh();
    }

    void ShowPlatformGraph() {
      if(!m_platformGraphView) {
        PlatformGraphView pView = new PlatformGraphView(m_top);
        m_platformGraphView = pView;
      }
      m_platformGraphView.Show(true);

      int pg = m_top.FindPage(L("Platform Graph"));
      if(pg >= 0)
        m_top.SetSelection(pg);
      else
        m_top.AddPage(m_platformGraphView, L("Platform Graph"), true, -1);
      m_platformGraphView.Refresh();
      m_top.Refresh();
    }

    public void OnChar(object sender, Event evt) {
      if(evt.KeyCode() == 9) {
        return;
      }
      evt.Skip();
    }

#endif
#if false
	MainFrame(string title);
	virtual ~MainFrame();

	void	LoadState(string header, TConfig  state);
	void	SaveState(string header, TConfig  state);
	void	Finalize();
	void	AddTimeTable(NotebookManager parent);

	void	MoveTimeTableToTab();
	void	MoveTimeTableToSplit();
	void	MoveTimeTableToFrame();

	// menus
	void	OnOpenFile(object sender, Event evt);
	void	OnRecent(object sender, Event evt);
	void	OnRestore(object sender, Event evt);
	void	OnSaveGame(object sender, Event evt);
	void	OnClose(wxCloseevt& evt);
	void	OnQuit(object sender, Event evt);
	void	OnTimer(wxTimerevt& evt);
	void	OnPrintSetup(object sender, Event evt);
	void	OnPrintPreview(object sender, Event evt);
	void	OnPrint(object sender, Event evt);

	void	OnEdit(object sender, Event evt);
	void	OnNewTrain(object sender, Event evt);
	void	OnItinerary(object sender, Event evt);
	void	OnSwitchboard(object sender, Event evt);
	void	OnSaveLayout(object sender, Event evt);
	void	OnPreferences(object sender, Event evt);
	void	OnEditSkin(object sender, Event evt);
	void	OnNewLayout(object sender, Event evt);
	void	OnInfo(object sender, Event evt);

	void	OnStartStop(object sender, Event evt);
	void	OnGraph(object sender, Event evt);
	void	OnLateGraph(object sender, Event evt);
	void	OnPlatformGraph(object sender, Event evt);
	void	OnRestart(object sender, Event evt);
	void	OnFast(object sender, Event evt);
	void	OnSlow(object sender, Event evt);
	void	OnSkip(object sender, Event evt);
	void	OnStationSched(object sender, Event evt);
	void	OnSetGreen(object sender, Event evt);
	void	OnSelectItin(object sender, Event evt);
	void	OnPerformance(object sender, Event evt);

	void	OnZoomIn(object sender, Event evt);
	void	OnZoomOut(object sender, Event evt);
	void	OnShowCoord(object sender, Event evt);
	void	OnShowLayout(object sender, Event evt);
	void	OnShowSchedule(object sender, Event evt);
	void	OnShowInfoPage(object sender, Event evt);
	void	OnShowStationsList(object sender, Event evt);
	void	OnTimeTableSplit(object sender, Event evt);
	void	OnTimeTableTab(object sender, Event evt);
	void	OnTimeTableFrame(object sender, Event evt);

	void	OnToolBar(object sender, Event evt);
	void	OnStatusBar(object sender, Event evt);

	void	OnRunButton(object sender, Event evt);

	void	OnAbout(object sender, Event evt);
	void	OnCopyright(object sender, Event evt);
	void	OnLanguage(object sender, Event evt);

	void	OnSpinUp(wxSpinevt& evt);
	void	OnSpinDown(wxSpinevt& evt);
//	void	OnSpin(wxSpinevt& evt);

	void	OnChar(wxKeyevt& evt);

	void	ShowTrainInfoList(Train trn);
	void	ShowItinerary(bool show);
	void	ShowTools(bool show);
	void	ShowGraph();
	void	ShowLateGraph();
	void	ShowPlatformGraph();
	void	ShowHtml(string name, string page);
	void	ShowSwitchboardEditor();

public:
	DECLARE_evt_TABLE()
//	DECLARE_NO_COPY_CLASS(MyFrame)
};

  /*	MainFrm.cpp - Created by Giampiero Caprino

This file is part of Train Director 3

Train Director is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; using exclusively version 2.
It is expressly forbidden the use of higher versions of the GNU
General Public License.

Train Director is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Train Director; see the file COPYING.  If not, write to
the Free Software Foundation, 59 Temple Place - Suite 330,
Boston, MA 02111-1307, USA.
*/

// ERIK # include "wx/wx.h"
// ERIK # include "wx/splitter.h"
// ERIK # include "wx/socket.h"
// ERIK # include "wx/listctrl.h"
// ERIK # include "wx/html/htmlwin.h"
// ERIK # include "wx/image.h"
// ERIK # include "wx/spinctrl.h"
// ERIK # include "wx/textfile.h"
// ERIK # include "wx/protocol/http.h"
// ERIK # include "wx/numdlg.h"
// ERIK # include "TimeTblView.h"
// ERIK # include "HtmlView.h"
// ERIK # include "TrainInfoList.h"
// ERIK # include "AlertList.h"
// ERIK # include "Canvas.h"
// ERIK # include "MainFrm.h"
// ERIK # include "Traindir3.h"
// ERIK # include "html.h"
// ERIK # include "DaysDialog.h"
// ERIK # include "OptionsDialog.h"
// ERIK # include "ItineraryDialog.h"
// ERIK # include "TrackDialog.h"
// ERIK # include "TrackScriptDialog.h"
// ERIK # include "SignalDialog.h"
// ERIK # include "TriggerDialog.h"
// ERIK # include "AssignDialog.h"
// ERIK # include "TrainInfoDialog.h"
// ERIK # include "ScenarioInfoDialog.h"
// ERIK # include "StationInfoDialog.h"
// ERIK # include "ConfigDialog.h"
// ERIK # include "trsim.h"
// ERIK # include "SwitchboardNameDialog.h"
// ERIK # include "SkinColorsDialog.h"
// ERIK # include "Options.h"

// ERIK # define	NSTATUSBOXES	5

extern	void	save_schedule_status(HtmlPage& dest);
extern	int	current_tool;
extern	int	layout_modified;
extern	string    info_page;		/* HTML page to show in the Scenario Info window */
extern	TDSkin	*curSkin;
extern  StringOption user_name;

extern  void    bstreet_logout();

ItineraryKeyDialog *itinKeyDialog;

void	set_show_coord(bool opt);
void	set_zoom(bool zooming);
int	ask_to_save_layout();
void	get_switchboard(HtmlPage& page);
#endif
//
//	Show Dialogs
//

void	ShowTrackProperties(Track trk)
{
  //TrackDialog diag(traindir.m_frame);

  //diag.ShowModal(trk);
}
#if false

void	ShowTrackScriptDialog(Track *trk)
{
	TrackScriptDialog diag(traindir.m_frame);

	diag.ShowModal(trk);
}

#endif
void	ShowSignalProperties(Signal sig)
{
  //SignalDialog	diag(traindir.m_frame);

  //diag.ShowModal(sig);
}

void	ShowTriggerProperties(Track trk)
{
  //TriggerDialog	diag(traindir.m_frame);

  //diag.ShowModal(trk);
}
#if false
void    switch_properties_dialog(Track *sw)
{
        TrackDialog diag(traindir.m_frame);

        diag.ShowModal(sw);
}
#endif
void	ShowPerformance()
{
  //HtmlPage    page(wxT(""));
  //show_schedule_status(page);
	
  //traindir.m_frame.ShowHtml(L("Performance"), *page.content);
}
#if false
void	ShowSwitchboard()
{
	HtmlPage    page(wxT(""));
	get_switchboard(page);
	
	traindir.m_frame.ShowHtml(L("Switchboard"), *page.content);
}
#endif
void	ShowOptionsDialog()
{
  //OptionsDialog  opts(traindir.m_frame);
  //opts.ShowModal();
}

void	ShowDaySelectionDialog()
{
  //DaysDialog  days(traindir.m_frame);
  //days.ShowModal();
}
#if false
void	ShowScenarioInfoDialog()
{
	ScenarioInfoDialog	diag(traindir.m_frame);
	diag.ShowModal();
}
#endif

void	ShowTrainInfoDialog(Train trn)
{
  //TrainInfoDialog	diag(traindir->m_frame);
  //diag.ShowModal(trn);
}

void	ShowAssignDialog(Train trn)
{
  //AssignDialog  diag(traindir.m_frame);
  //diag.ShowModal(trn);
}

void	ShowStationSchedule(string name, bool saveToFile)
{
  //HtmlPage    page(wxT(""));

  //if(!name)
  //    return;
  //build_station_schedule(name);
  //do_station_list_print(name, page);
  //if(!saveToFile) {
  //    GlobalVariables.traindir.m_frame.ShowHtml(L("Station Schedule"), *page.content);
  //    return;
  //}
  //traindir.SaveHtmlPage(page);
}

void	ShowStationScheduleDialog(string name)
{
  //StationInfoDialog	diag(traindir.m_frame);

  //diag.ShowModal(name);
}

void	ShowItineraryDialog(Itinerary it)
{
  //ItineraryDialog	itin(traindir.m_frame);

  //itin.ShowModal(it);
}

#if false
void	track_info_dialogue()
{
//	HtmlPage    page(wxT(""));

//	print_track_info(page);
//	traindir.m_frame.ShowHtml(L("Info"), *page.content);
	ShowScenarioInfoDialog();
}

extern	SwitchBoard *FindSwitchBoard(string *name);

void	switchboard_name_dialog(string *name)
{
	SwitchboardNameDialog	sbname(traindir.m_frame);

	SwitchBoard *sb = 0;
	if(name && *name)
	    sb = FindSwitchBoard(name);
	sbname.ShowModal(sb);
}


void	switchboard_cell_dialog(int x, int y)
{
	SwitchboardCellDialog	sbcell(traindir.m_frame);

	sbcell.ShowModal(x, y);
}

void	skin_config_dialog()
{
	SkinColorsDialog	skin(traindir.m_frame, curSkin);

	skin.ShowModal();
}


// ----------------------------------------------------------------------------
// LogFilter
// ----------------------------------------------------------------------------

void	LogFilter::InstallLog()
{
	m_oldLog = wxLog::GetActiveTarget();
	wxLog::SetActiveTarget(this);
}

void	LogFilter::UninstallLog()
{
	wxLog::SetActiveTarget(m_oldLog);
	m_oldLog = 0;
}

void	LogFilter::DoLog(wxLogLevel level, string *szString, time_t t)
{
	if(m_parent.m_alertList) {
	    m_parent.m_alertList.AddLine(m_extraInfo + wxT(": ") + szString);
	}
//	if(m_oldLog)
//	    m_oldLog.DoLog(level, szString, t);
}

void	 LogFilter::SetExtraInfo(string *extra)
{
	m_extraInfo = extra;
}


LogFilter   gLogger;

// ----------------------------------------------------------------------------
// TimeFrame
// ----------------------------------------------------------------------------

class TimeFrame : public wxFrame
{
public:
	TimeFrame(MainFrame *parent, string title);
	virtual ~TimeFrame();
	void	OnClose(wxCloseevt& evt);

	MainFrame *m_parent;

	DECLARE_evt_TABLE()
};

BEGIN_evt_TABLE(TimeFrame, wxFrame)
	EVT_CLOSE(TimeFrame::OnClose)
END_evt_TABLE()

TimeFrame::TimeFrame(MainFrame *parent, string title)
	: wxFrame(parent, wxID_ANY, title),
	m_parent(parent)
{
}

TimeFrame::~TimeFrame()
{
}

//	When we are closed, we need to detach the schedule
//	list view and attach it to something that's still
//	visible, in this case the main frame's main view.

void	TimeFrame::OnClose(wxCloseevt& evt)
{
	wxMenuItem  *pItem;
	
	m_parent.m_timeTable.Reparent(m_parent.m_top);
	m_parent.m_top.AddPage(m_parent.m_timeTable, L("Schedule"), false, -1);
	m_parent.m_timeTableLocation = TIME_TABLE_TAB;
	m_parent.m_timeFrame = 0;
	if((pItem = m_parent.GetMenuBar().FindItem(MENU_TIME_TAB, 0)))
	    pItem.Check(true);
	evt.Skip();
}
#endif
  }
}