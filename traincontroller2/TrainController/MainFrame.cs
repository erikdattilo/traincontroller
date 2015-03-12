using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainController {
  public partial class MainFrame : Form {
    public MainFrame() {
      InitializeComponent();

      this.WindowState = FormWindowState.Maximized;


      pictureBox1.Init();

      MainFrame_OldConstructor("AAA");

      TrainController.GetInstance();

      TrainController.GetInstance().OpenFile(@"C:\Documents and Settings\Erik_\Desktop\tdir38win\Scenari\Padova2014.zip");
    }

    public void MainFrame_OldConstructor(String title)
      //: base(null, wx.Window.wxID_ANY, title)
    {
      this.Text = title;

      //      m_timeTableManager = new TimeTableViewManager();
      //      m_canvasManager = new CanvasManager();
      //      m_timer = new Timer(this, MenuIDs.TIMER_ID, new ElapsedEventHandler(mTimer_Elapsed));

      //      AttachEvents();

      //      PrepareMenuBar();
      //      PrepareToolBar();
      //      PrepareStatusBar();

#if DEFINED_IN_DESIGNER
      //
      //	Client area
      //
      //	m_splitter controls the top and bottom views
      //

      m_splitter = new MySplitterWindow(this);
      m_splitter.SashGravity = (1.0);
#endif
      //      //
      //      //	the top view is the layout Canvas
      //      //	inside a managing notebook
      //      //

#if DEFINED_IN_DESIGNER
      m_top = new NotebookManager(m_splitter, wxPorting.T("top"), (int)MenuIDs.ID_NOTEBOOK_TOP);

      Canvas pCanvas = new Canvas(m_top);
      pCanvas.Name = (wxPorting.T("canvas"));
      m_top.AddPage(pCanvas, wxPorting.L("Layout"), true, -1);

      //
      //	the bottom view is another splitter
      //

      m_bottomSplitter = new MySplitterWindow(m_splitter);
      m_bottomSplitter.SashGravity = (0.5);
#endif

      //      //
      //      //	the bottom left view has a managed
      //      //	notebook which will hold the schedule
      //      //	list, edit tools view and itinerary list
      //      //

      //      m_left = new NotebookManager(m_bottomSplitter, wxPorting.T("left"), (int)MenuIDs.ID_NOTEBOOK_LEFT);
      //      m_timeTable = m_timeTableManager.GetNewTimeTableView(m_left, wxPorting.L("Schedule"));
      //      m_itineraryView = new ItineraryView(m_left, wxPorting.L("Itinerary"));
      //      m_itineraryView.Show(false);

      //      //
      //      //	the bottom right view has a managed
      //      //	notebook which will hold the train
      //      //	info list and the alerts list
      //      //

      //      m_right = new NotebookManager(m_bottomSplitter, wxPorting.T("right"), (int)MenuIDs.ID_NOTEBOOK_RIGHT);
      //      m_alertList = new AlertList(m_right, wxPorting.L("Alerts"));
      //      m_trainInfo = new TrainInfoList(m_right, wxPorting.L("Train Info"));

      //      m_timeFrame = null;

#if DEFINED_IN_DESIGNER
      // you can also do this to start with a single window
      // you can also try -100
      m_splitter.SplitHorizontally(m_top, m_bottomSplitter, 300);
#endif

      //      //      wxSize sz = this.Size;
      //      //      m_bottomSplitter.SplitVertically(m_left, m_right, -300);

      //      m_top.Show(true);
      //      m_left.Show(true);
      //      m_right.Show(true);

      //      // TODO Re-enable this line once learn how to handle cross-thread calling...
      //      // m_timer.Start(100);
      //      Globals.gLogger.SetParent(this);

      //      m_printer = new HtmlEasyPrinting(wxPorting.L(""), this);

      //      m_timeFrame = null;

      //      Globals.track_properties_dialog = Globals.ShowTrackProperties;
      //      Globals.signal_properties_dialog = Globals.ShowSignalProperties;
      //      Globals.trigger_properties_dialog = Globals.ShowTriggerProperties;
      //      Globals.performance_dialog = Globals.ShowPerformance;
      //      Globals.options_dialog = Globals.ShowOptionsDialog;
      //      Globals.select_day_dialog = Globals.ShowDaySelectionDialog;
      //      Globals.train_info_dialog = Globals.ShowTrainInfoDialog;
      //      Globals.assign_dialog = Globals.ShowAssignDialog;
      //      Globals.station_sched_dialog = Globals.ShowStationScheduleDialog;
      //      Globals.itinerary_dialog = Globals.ShowItineraryDialog;
      //      Globals.about_dialog = Globals.ShowWelcomePage;
    }

    public CanvasManager m_canvasManager;	    // we can have different upper-left corners
    public TimeTableViewManager m_timeTableManager;// we can have different stations
    public TimeTableView m_timeTable;

    //  Current state (saved to config file)

    public bool m_showToolbar;
    public bool m_showStatusbar;
    public TimeTableLocations m_timeTableLocation;

    //
    //  Toolbar objects
    //

    //public StaticText m_clock;
    //public SpinButton m_speedArrows;
    //public TextCtrl m_speed;
    //public ToggleButton m_running;
    //public StaticText m_statusText;
    //public StaticText m_alertText;

    //
    //
    //

    //public Traindir m_app;
#if DEFINED_IN_DESIGNER
    public NotebookManager m_top;		// top (pages are Canvases or TimeTable or Html)
    //public NotebookManager m_left;	// bottom-left
    //public NotebookManager m_right;	// bottom-right
    //public SplitterWindow m_splitter;
#endif
    //public SplitterWindow m_bottomSplitter;
    //public int m_topSashValue;
    //public ToolBar m_toolbar;
    //public StatusBar m_statusbar;
    //public Timer m_timer;
    //public TimeFrame m_timeFrame;	// showing time table in separate frame
    //public HtmlEasyPrinting m_printer;
    //public String m_htmlPage;

    public ItineraryView m_itineraryView;
    public ToolsView m_toolsView;
    public GraphView m_graphView;
    public LateGraphView m_lateGraphView;
    public PlatformGraphView m_platformGraphView;
    public TrainInfoList m_trainInfo;
    public AlertList m_alertList;

    public MenuStrip m_viewMenu;

    //public void OnAbout(object sender, Event evt) {
    //  throw new NotImplementedException();
    //  // Globals.ShowWelcomePage();
    //}

    //public void OnCopyright(object sender, Event evt) {
    //  throw new NotImplementedException();

    //  //String notice;

    //  //notice = String.Format(wxPorting.T("%s - %s\n\n"), Globals.program_name, Globals.__DATE__);	// wxPorting.L("Traindir 3.0\n\n");
    //  //notice += wxPorting.L("Created by");
    //  //notice += wxPorting.T(" Giampiero Caprino\n\n");
    //  //notice += wxPorting.L("This is free software, released under the\nGNU General Public License Version 2.\nThe author declines any responsibility for any damage\nthat might occur from the use of this program.");
    //  //notice += wxPorting.T("    \n\n");
    //  //notice += wxPorting.L("This is a game, and is not intended to\nbe used to actually control train traffic.");

    //  //wx.MessageDialog.MessageBox(notice);
    //}

    //public void OnLanguage(object sender, Event evt) {
    //  throw new NotImplementedException();

    //  //ConfigDialog diag = new ConfigDialog(this);

    //  //if(diag.ShowModal() == 0) // TODO / Erik ==> Find the right enum value
    //  //  return;
    //}

    ////
    ////	OnQuit
    ////	    Called from the File+Exit menu,
    ////	    or from the Alt-F4 accelerator of the File+Exit menu
    ////

    //public void OnQuit(object sender, Event evt) {
    //  Close();
    //}

    ////
    ////	OnClose
    ////	    Called from the "Close" item of the system menu of the frame,
    ////	    or when the close button "x" in the frame is clicked.
    ////

    //public void OnClose(object sender, Event evt) {
    //  throw new NotImplementedException();
    //  ////  TODO: save in project-specific file

    //  //if(Globals.layout_modified) {
    //  //  if(Globals.ask_to_save_layout() < 0)
    //  //    return;
    //  //}
    //  //Globals.traindir.SaveState();
    //  //if(Globals.user_name._sValue.Length > 0) {
    //  //  Globals.bstreet_logout();
    //  //}
    //  //Destroy();
    //}

    //
    //
    //

    private void PrepareStatusBar() {
      //
      //	Status bar
      //

      //      StatusBar m_statusBar = new StatusBar(this, wx.Window.wxID_ANY);
      //      int[] widths = new int[Configuration.NSTATUSBOXES] { -50, -30, -20, -30, -50 };
      //      m_statusBar.SetFieldsCount(WXSIZEOF(widths), widths);
      //      this.StatusBar = m_statusBar;
    }


    private void PrepareToolBar() {

      //
      //	Toolbar
      //
      //      String buff = new String(wxPorting.T('M'), 70);

      //      m_toolbar = new ToolBar(this, wx.Window.wxID_ANY,
      //              wxDefaultPosition, wxDefaultSize,
      //              WindowStyles.ORIENT_HORIZONTAL | WindowStyles.BORDER_NONE | WindowStyles.TB_DOCKABLE);

      //      m_clock = new StaticText(m_toolbar, 0, Globals.wxEmptyString,
      //          wxDefaultPosition, wxDefaultSize);
      //      m_clock.Label = (wxPorting.T("   00:00.00    "));
      //      m_toolbar.AddControl(m_clock);

      //      m_speed = new TextCtrl(m_toolbar, (int)MenuIDs.ID_SPEEDTEXT, wxPorting.T("10"), wxDefaultPosition,
      //            new Size(40, 30));
      //      m_speed.Enable(false);
      //      m_toolbar.AddControl(m_speed);

      //      m_speedArrows = new SpinButton(m_toolbar, (int)MenuIDs.ID_SPIN);
      //      m_speedArrows.Value = (5);
      //      m_toolbar.AddControl(m_speedArrows);

      //      m_toolbar.AddSeparator();

      //      m_running = new ToggleButton(m_toolbar, MenuIDs.ID_RUN,
      //          I18N.L("Start"), wxDefaultPosition, new Size(50, 30));
      //      m_toolbar.AddControl(m_running);

      //      m_toolbar.AddSeparator();

      //      m_statusText = new StaticText(m_toolbar, wx.Window.wxID_ANY, Globals.wxEmptyString,
      //          wxDefaultPosition, wxDefaultSize);
      //      m_statusText.Label = (buff);
      //      m_toolbar.AddControl(m_statusText);

      //      m_toolbar.AddSeparator();

      //      m_alertText = new StaticText(m_toolbar, wx.Window.wxID_ANY, Globals.wxEmptyString,
      //          wxDefaultPosition, wxDefaultSize);
      //      m_alertText.Label = (buff);
      //      m_toolbar.AddControl(m_alertText);

      //      m_toolbar.Realize();
      //      this.ToolBar = (m_toolbar);

      //      m_statusText.Label = (wxPorting.T(""));
      //      m_alertText.Label = (wxPorting.T(""));
    }

    private void TEMP_AddMenuItem(ToolStripMenuItem menu, wx.MenuIDs menuIDs, string p, string p_4) {
      ToolStripMenuItem qweToolStripMenuItem2 = new ToolStripMenuItem();
      qweToolStripMenuItem2.Name = "qweToolStripMenuItem2";
      qweToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
      qweToolStripMenuItem2.Text = "qwe";

      menu.DropDownItems.Add(qweToolStripMenuItem2);
    }

     //<summary>
     //Create menu bar and attach it to this Frame
     //</summary>
    private void PrepareMenuBar() {
      // MenuStrip fileMenu = new MenuStrip();
        // TEMP_AddMenuItem(fileMenu, wx.MenuIDs.wxID_OPEN, I18N.L("&Open...\tCtrl-O"), I18N.L("Open a simulation file."));
      //      TEMP_AddMenuItem(fileMenu, wx.MenuIDs.wxID_SAVE, I18N.L("&Save Game..."), I18N.L("Open a saved simulation file."));
      //      TEMP_AddMenuItem(fileMenu, wx.MenuIDs.wxID_REVERT, I18N.L("&Restore..."), I18N.L("Restore from the last saved state."));
      //      fileMenu.AppendSeparator();
      //      TEMP_AddMenuItem(fileMenu, MenuIDs.MENU_HTML_PRINTSETUP, I18N.L("Page set&up"), I18N.L("Changes the page layout settings."));
      //      TEMP_AddMenuItem(fileMenu, MenuIDs.MENU_HTML_PREVIEW, I18N.L("Pre&view"), I18N.L("Preview print output."));
      //      TEMP_AddMenuItem(fileMenu, MenuIDs.MENU_HTML_PRINT, I18N.L("&Print"), I18N.L("Print all or part of the document."));
      //fileMenu.AppendSeparator();
      //fileMenu.Append((int)wx.MenuIDs.wxID_EXIT, I18N.L("E&xit\tAlt-F4"), I18N.L("Quit this program."));
      // this.Controls.Add(fileMenu);
      //MenuStrip editMenu = new MenuStrip();
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_EDIT, I18N.L("&Edit\tCtrl-E"), I18N.L("Enter/exit layout editor."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_ITINERARY, I18N.L("&Itinerary"), I18N.L("Enter/exit itinerary editor."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_SWITCHBOARD, I18N.L("Switch&board"), I18N.L("Shows the switchboard editor."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_SAVE_LAYOUT, I18N.L("&Save Layout"), I18N.L("Save changes to the layout."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_PREFERENCES, I18N.L("&Preferences..."), I18N.L("Change program's preferences."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_NEW_LAYOUT, I18N.L("Ne&w"), I18N.L("Erase the layout."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_INFO, I18N.L("In&fo"), I18N.L("Show information about the scenario."));
      ////      TEMP_AddMenuItem(editMenu, MenuIDs.MENU_STATIONS_LIST, I18N.L("Stations &List"), I18N.L("Show list of stations and entry points."));

      //MenuStrip runMenu = new MenuStrip();
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_START, I18N.L("&Start\tCtrl-S"), I18N.L("Start/stop the simulation."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_GRAPH, I18N.L("&Graph\tCtrl-G"), I18N.L("Show the timetable graph."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_LATEGRAPH, I18N.L("&Late Graph\tCtrl-I18N.L"), I18N.L("Show accumulation of late minutes over time."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_PLATFORMGRAPH, I18N.L("&Platform Graph"), I18N.L("Show platforms occupancy over time."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_RESTART, I18N.L("&Restart..."), I18N.L("Restart the simulation."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_FAST, I18N.L("&Fast\tCtrl-X"), I18N.L("Speed up the simulation."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_SLOW, I18N.L("&Slow\tCtrl-Z"), I18N.L("Slow down the simulation."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_SKIP, I18N.L("S&kip ahead\tCtrl-K"), I18N.L("Skip to 3 minutes before next evt."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_STATION_SCHED, I18N.L("S&tation schedule\tF6"), I18N.L("Show the train schedule of each station."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_SETGREEN, I18N.L("Set sig. to green"), I18N.L("Set all automatic signals to green."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_SELECT_ITIN, I18N.L("Select Itinerary\tCtrl-I"), I18N.L("Select an itinerary by name."));
      ////      TEMP_AddMenuItem(runMenu, MenuIDs.MENU_PERFORMANCE, I18N.L("&Performance"), I18N.L("Show performance data."));

      //// m_viewMenu = new MenuStrip();
      ////      TEMP_AddMenuItem(m_viewMenu, MenuIDs.MENU_SHOW_LAYOUT, I18N.L("Show layout\tF3"), I18N.L("Forcibly show the layout window."));
      ////      TEMP_AddMenuItem(m_viewMenu, MenuIDs.MENU_SHOW_SCHEDULE, I18N.L("Show schedule\tF4"), I18N.L("Forcibly show the schedule window."));
      ////      TEMP_AddMenuItem(m_viewMenu, MenuIDs.MENU_INFO_PAGE, I18N.L("Show info page\tF5"), I18N.L("Shows the scenario info page, if available."));
      ////      m_viewMenu.AppendSeparator();
      ////      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_SPLIT, I18N.L("Timetable in split window"), I18N.L("View timetable in a split window."));
      ////      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_TAB, I18N.L("Timetable in tabbed window"), I18N.L("View timetable in a tab of the main window."));
      ////      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_FRAME, I18N.L("Timetable in separate window"), I18N.L("View timetable in a window separate from the main window."));

      ////      m_viewMenu.AppendSeparator();

      ////      TEMP_AddMenuItem(m_viewMenu, MenuIDs.MENU_ZOOMIN, I18N.L("Zoom in"), I18N.L("Draw the layout at double the resolution."));
      ////      TEMP_AddMenuItem(m_viewMenu, MenuIDs.MENU_ZOOMOUT, I18N.L("Zoom out"), I18N.L("Draw the layour at normal resolution."));

      ////      m_viewMenu.AppendSeparator();

      ////      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_SHOW_COORD, I18N.L("Coord bars"), I18N.L("View/hide the coordinate bars."));
      ////      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_TOOLBAR, I18N.L("Tool bar"), I18N.L("View/hide the tools bar."));
      ////      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_STATUSBAR, I18N.L("Status bar"), I18N.L("View/hide the status bar."));

      //MenuStrip helpMenu = new MenuStrip();
      ////      TEMP_AddMenuItem(helpMenu, wx.MenuIDs.wxID_ABOUT, I18N.L("Welcome\tF1"), I18N.L("Show the welcome page."));
      ////      TEMP_AddMenuItem(helpMenu, MenuIDs.MENU_COPYRIGHT, I18N.L("Copyright"), I18N.L("Show the copyright notice."));
      ////      TEMP_AddMenuItem(helpMenu, MenuIDs.MENU_LANGUAGE, I18N.L("Language"), I18N.L("Select the language to be used next time Traindir is started."));

      //MenuBar menuBar = new MenuBar();

      //menuBar.Append(fileMenu, I18N.L("&File"));
      //menuBar.Append(editMenu, I18N.L("&Edit"));
      //menuBar.Append(runMenu, I18N.L("&Run"));
      //// menuBar.Append(m_viewMenu, I18N.L("&View"));
      //menuBar.Append(helpMenu, I18N.L("&Help"));

      //MenuBar = (menuBar);


      ////      MenuItem pItem = new MenuItem();

      ////      MenuStrip dummy;
      ////      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TIME_SPLIT, ref dummy)))
      ////        pItem.Checked = (true);
      ////      m_timeTableLocation = TimeTableLocations.TIME_TABLE_SPLIT;
      ////      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TOOLBAR, ref dummy)))
      ////        pItem.Checked = (true);
      ////      m_showToolbar = true;
      ////      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_STATUSBAR, ref dummy)))
      ////        pItem.Checked = (true);
      ////      m_showStatusbar = true;
      ////      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_SHOW_COORD, ref dummy)))
      ////        pItem.Checked = (Globals.bShowCoord);
    }

    ///// <summary>
    ///// Register all events for this Frame
    ///// </summary>
    //private void AttachEvents() {
    //  EVT_MENU(wx.MenuIDs.wxID_OPEN, new wx.EventListener(OnOpenFile));
    //  //      EVT_MENU(MenuIDs.MENU_RECENT, new wx.EventListener(OnRecent));
    //  //      EVT_MENU(wx.MenuIDs.wxID_SAVE, new wx.EventListener(OnSaveGame));
    //  //      EVT_MENU(wx.MenuIDs.wxID_REVERT, new wx.EventListener(OnRestore));
    //  //      EVT_MENU(MenuIDs.MENU_HTML_PRINTSETUP, new wx.EventListener(OnPrintSetup));
    //  //      EVT_MENU(MenuIDs.MENU_HTML_PREVIEW, new wx.EventListener(OnPrintPreview));
    //  //      EVT_MENU(MenuIDs.MENU_HTML_PRINT, new wx.EventListener(OnPrint));
    //  EVT_MENU(wx.MenuIDs.wxID_EXIT, new wx.EventListener(OnQuit));

    //  //      EVT_MENU(MenuIDs.MENU_EDIT, new wx.EventListener(OnEdit));
    //  //      EVT_MENU(MenuIDs.MENU_NEW_TRAIN, new wx.EventListener(OnNewTrain));
    //  //      EVT_MENU(MenuIDs.MENU_ITINERARY, new wx.EventListener(OnItinerary));
    //  //      EVT_MENU(MenuIDs.MENU_SWITCHBOARD, new wx.EventListener(OnSwitchboard));
    //  //      EVT_MENU(MenuIDs.MENU_SAVE_LAYOUT, new wx.EventListener(OnSaveLayout));
    //  //      EVT_MENU(MenuIDs.MENU_PREFERENCES, new wx.EventListener(OnPreferences));
    //  //      EVT_MENU(MenuIDs.MENU_EDIT_SKIN, new wx.EventListener(OnEditSkin));
    //  //      EVT_MENU(MenuIDs.MENU_NEW_LAYOUT, new wx.EventListener(OnNewLayout));
    //  //      EVT_MENU(MenuIDs.MENU_INFO, new wx.EventListener(OnInfo));
    //  //      EVT_MENU(MenuIDs.MENU_STATIONS_LIST, new wx.EventListener(OnShowStationsList));

    //  //      EVT_MENU(MenuIDs.MENU_START, new wx.EventListener(OnStartStop));
    //  //      EVT_MENU(MenuIDs.MENU_GRAPH, new wx.EventListener(OnGraph));
    //  //      EVT_MENU(MenuIDs.MENU_LATEGRAPH, new wx.EventListener(OnLateGraph));
    //  //      EVT_MENU(MenuIDs.MENU_PLATFORMGRAPH, new wx.EventListener(OnPlatformGraph));
    //  //      EVT_MENU(MenuIDs.MENU_RESTART, new wx.EventListener(OnRestart));
    //  //      EVT_MENU(MenuIDs.MENU_FAST, new wx.EventListener(OnFast));
    //  //      EVT_MENU(MenuIDs.MENU_SLOW, new wx.EventListener(OnSlow));
    //  //      EVT_MENU(MenuIDs.MENU_SKIP, new wx.EventListener(OnSkip));
    //  //      EVT_MENU(MenuIDs.MENU_STATION_SCHED, new wx.EventListener(OnStationSched));
    //  //      EVT_MENU(MenuIDs.MENU_SETGREEN, new wx.EventListener(OnSetGreen));
    //  //      EVT_MENU(MenuIDs.MENU_SELECT_ITIN, new wx.EventListener(OnSelectItin));
    //  //      EVT_MENU(MenuIDs.MENU_PERFORMANCE, new wx.EventListener(OnPerformance));

    //  //      EVT_MENU(MenuIDs.MENU_ZOOMIN, new wx.EventListener(OnZoomIn));
    //  //      EVT_MENU(MenuIDs.MENU_ZOOMOUT, new wx.EventListener(OnZoomOut));

    //  //      EVT_MENU(MenuIDs.MENU_SHOW_COORD, new wx.EventListener(OnShowCoord));
    //  //      EVT_MENU(MenuIDs.MENU_SHOW_LAYOUT, new wx.EventListener(OnShowLayout));
    //  //      EVT_MENU(MenuIDs.MENU_SHOW_SCHEDULE, new wx.EventListener(OnShowSchedule));
    //  //      EVT_MENU(MenuIDs.MENU_INFO_PAGE, new wx.EventListener(OnShowInfoPage));

    //  //      EVT_MENU(MenuIDs.MENU_TIME_SPLIT, new wx.EventListener(OnTimeTableSplit));
    //  //      EVT_MENU(MenuIDs.MENU_TIME_TAB, new wx.EventListener(OnTimeTableTab));
    //  //      EVT_MENU(MenuIDs.MENU_TIME_FRAME, new wx.EventListener(OnTimeTableFrame));

    //  //      EVT_MENU(MenuIDs.MENU_TOOLBAR, new wx.EventListener(OnToolBar));
    //  //      EVT_MENU(MenuIDs.MENU_STATUSBAR, new wx.EventListener(OnStatusBar));
    //  //      EVT_MENU(wx.MenuIDs.wxID_ABOUT, new wx.EventListener(OnAbout));
    //  //      EVT_MENU(MenuIDs.MENU_COPYRIGHT, new wx.EventListener(OnCopyright));
    //  //      EVT_MENU(MenuIDs.MENU_LANGUAGE, new wx.EventListener(OnLanguage));

    //  //      EVT_TOGGLEBUTTON((int)MenuIDs.ID_RUN, new wx.EventListener(OnRunButton));

    //  //      EVT_SPIN_UP((int)MenuIDs.ID_SPIN, new wx.EventListener(OnSpinUp));
    //  //      EVT_SPIN_DOWN((int)MenuIDs.ID_SPIN, new wx.EventListener(OnSpinDown));

    //  //      EVT_CLOSE(new wx.EventListener(OnClose));
    //  //      EVT_TIMER((int)MenuIDs.TIMER_ID, new wx.EventListener(OnTimer));
    //  //      EVT_CHAR(new wx.EventListener(OnChar));
    //}

    //~MainFrame() {
    //  if(m_splitter != null) {
    //    m_splitter = null;
    //  }
    //  if(m_printer != null) {
    //    m_printer = null;
    //  }
    //}

    //	The travels of the time table view...
    //
    //	The time table can be in any of 3 states:
    //	1) default it is a tab in the left notebook of the horizontal splitter
    //	2) it's a tab in the top (only) notebook
    //	3) it's the only child of a separate frame
    //
    //	The following routines implement the transitions
    //	between these 3 states

    public void MoveTimeTableToTab() {
      throw new NotImplementedException();

      //if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_SPLIT) {
      //  m_topSashValue = m_splitter.SashPosition;
      //  m_left.RemovePage(m_timeTable);
      //} else if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_FRAME) {
      //  m_timeFrame.Show(false);
      //}
      //m_timeTable.Reparent(m_top);
      //m_top.AddPage(m_timeTable, wxPorting.L("Schedule"));
      //m_splitter.Unsplit();
      //m_timeTableLocation = TimeTableLocations.TIME_TABLE_TAB;
      ////	AddTimeTable(m_top);
    }

    public void MoveTimeTableToSplit() {
      throw new NotImplementedException();
      //if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_TAB) {
      //  m_top.RemovePage(m_timeTable);
      //} else if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_FRAME) {
      //  m_timeFrame.Show(false);
      //}
      //m_splitter.SplitHorizontally(m_top, m_bottomSplitter, m_topSashValue);
      //m_timeTableLocation = TimeTableLocations.TIME_TABLE_SPLIT;
      //m_timeTable.Reparent(m_left);
      //m_left.AddPage(m_timeTable, wxPorting.L("Schedule"));
    }

    public void MoveTimeTableToFrame() {
      throw new NotImplementedException();
      //if(m_timeFrame == null)
      //  m_timeFrame = new TimeFrame(this, wxPorting.L("Schedule"));

      //if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_TAB) {
      //  m_top.RemovePage(m_timeTable);
      //} else if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_SPLIT) {
      //  m_topSashValue = m_splitter.SashPosition;
      //  m_left.RemovePage(m_timeTable);
      //  m_splitter.Unsplit();
      //}

      //m_timeTable.Reparent(m_timeFrame);
      //Size size = m_timeFrame.ClientSize;
      //m_timeTable.SetSize(0, 0, size.Width, size.Height);
      //m_timeFrame.Show(true);
      //m_timeTable.Show(true);
      //m_timeTable.Refresh();
      //m_timeTableLocation = TimeTableLocations.TIME_TABLE_FRAME;
    }

    //
    //	LoadState()
    //	    Reload the state of the frame window (position, size)
    //	    from file saved on the last run.
    //

    public void LoadState(String header, TConfig state) {
      throw new NotImplementedException();
      //String line;
      //bool gotDimensions = false;
      //bool bMaximized = false;
      //Size size = new Size(-1, -1);
      //Point pos = new Point(-1, -1);
      //int nTimetables = 0;
      //int sashPosition = 100;
      //int lowerSashPosition = 100;
      //bool bGotSash = false;
      //bool bGotLowerSash = false;

      //if(!state.FindSection(header))
      //  return;

      //int v;

      ////
      ////  Reload information about the size and position of the window
      ////

      //if(state.GetInt(wxPorting.T("isMaximized"), out v))
      //  bMaximized = (v != 0) ? true : false;
      //if(state.GetInt(wxPorting.T("showStatusBar"), out v))
      //  m_showStatusbar = (v != 0) ? true : false;
      //if(state.GetInt(wxPorting.T("showToolBar"), out v))
      //  m_showToolbar = (v != 0) ? true : false;
      //if(state.GetInt(wxPorting.T("showCoord"), out v))
      //  Globals.bShowCoord = (v != 0) ? true : false;

      //if(state.GetInt(wxPorting.T("x"), out v)) {
      //  gotDimensions = true;
      //  pos.X = v;
      //}
      //if(state.GetInt(wxPorting.T("y"), out v)) {
      //  gotDimensions = true;
      //  pos.Y = v;
      //}
      //if(state.GetInt(wxPorting.T("w"), out v)) {
      //  gotDimensions = true;
      //  size.Width = v;
      //}
      //if(state.GetInt(wxPorting.T("h"), out v)) {
      //  gotDimensions = true;
      //  size.Height = v;
      //}

      ////
      ////  Reload state of splitter
      ////

      //bGotSash = state.GetInt(wxPorting.T("sash"), out sashPosition);
      //bGotLowerSash = state.GetInt(wxPorting.T("lower-sash"), out lowerSashPosition);

      //if(gotDimensions) {
      //  this.Position = (pos);
      //  SetSize(size);
      //}
      //if(bGotSash) {
      //  m_splitter.SashPosition = (sashPosition);
      //  m_topSashValue = sashPosition;
      //}
      //if(bGotLowerSash) {
      //  m_bottomSplitter.SashPosition = (lowerSashPosition);
      //}

      ////	Maximize(bMaximized);

      ////  Synchronize menus

      //MenuBar pBar = this.MenuBar;
      //MenuItem pItem;
      //MenuStrip dummyMenu;

      //if(m_toolbar != null) {
      //  if((pItem = pBar.FindItem((int)MenuIDs.MENU_TOOLBAR, ref dummyMenu)) != null)
      //    pItem.Checked = (m_showToolbar);
      //  m_toolbar.Show(pItem.Checked);
      //}
      //StatusBar pStatus;

      //if((pStatus = this.StatusBar) != null) {
      //  if((pItem = pBar.FindItem((int)MenuIDs.MENU_STATUSBAR, ref dummyMenu)))
      //    pItem.Checked = (m_showStatusbar);
      //  pStatus.Show(m_showStatusbar);
      //}

      //Globals.set_show_coord(Globals.bShowCoord);
      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_SHOW_COORD, ref dummyMenu)))
      //  pItem.Checked = (Globals.bShowCoord);

      //int val;
      //TimeTableLocations loc;
      //if(!state.GetInt(wxPorting.T("timeTableLocation"), out val))
      //  loc = m_timeTableLocation;
      //else
      //  loc = (TimeTableLocations)val;
      //switch(loc) {
      //  case TimeTableLocations.TIME_TABLE_TAB:

      //    val = (int)MenuIDs.MENU_TIME_TAB;
      //    MoveTimeTableToTab();
      //    break;

      //  case TimeTableLocations.TIME_TABLE_FRAME:

      //    m_timeFrame = new TimeFrame(this, wxPorting.L("Schedule"));
      //    gotDimensions = false;
      //    if(state.GetInt(wxPorting.T("timex"), out v)) {
      //      gotDimensions = true;
      //      pos.X = v;
      //    }
      //    if(state.GetInt(wxPorting.T("timey"), out v)) {
      //      gotDimensions = true;
      //      pos.Y = v;
      //    }
      //    if(state.GetInt(wxPorting.T("timew"), out v)) {
      //      gotDimensions = true;
      //      size.Width = v;
      //    }
      //    if(state.GetInt(wxPorting.T("timeh"), out v)) {
      //      gotDimensions = true;
      //      size.Height = v;
      //    }
      //    if(gotDimensions) {
      //      m_timeFrame.Position = (pos);
      //      m_timeFrame.SetSize(size);
      //    }
      //    MoveTimeTableToFrame();
      //    val = (int)MenuIDs.MENU_TIME_FRAME;
      //    break;

      //  case TimeTableLocations.TIME_TABLE_SPLIT:
      //  default:
      //    val = (int)MenuIDs.MENU_TIME_SPLIT;
      //}
      //m_timeTableLocation = loc;

      //if((pItem = pBar.FindItem(val, ref dummyMenu)) != null)
      //  pItem.Checked = (m_showToolbar);

      //SendSizeEvent();

      ////
      ////  Reload the dimensions of each list view for each
      ////  of the views.
      ////

      //m_top.LoadState(header, state);
      //m_left.LoadState(header, state);
      //m_right.LoadState(header, state);
      //if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_FRAME) {
      //  m_timeTable.LoadState(wxPorting.T("time-frame"), state);
      //}
    }

    //
    //	SaveState()
    //	    Save the state (size, position) of the frame window
    //	    and the state of any child view, mainly the list views
    //

    public void SaveState(String header, TConfig state) {
      throw new NotImplementedException();
      //  int nTT = 0;

      //  m_top.SaveState(header, state);
      //  m_left.SaveState(header, state);
      //  m_right.SaveState(header, state);
      //  if(m_timeFrame != null) {
      //    if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_FRAME) {
      //      m_timeTable.SaveState(wxPorting.T("time-frame"), state);
      //    }
      //  }

      //  state.StartSection(header);
      //  state.PutInt(wxPorting.T("isMaximized"), this.Maximized ? 1 : 0);
      //  state.PutInt(wxPorting.T("showStatusBar"), m_showStatusbar ? 1 : 0);
      //  state.PutInt(wxPorting.T("showToolBar"), m_showToolbar ? 1 : 0);
      //  state.PutInt(wxPorting.T("showCoord"), Globals.bShowCoord ? 1 : 0);
      //  state.PutInt(wxPorting.T("timeTableLocation"), (int)m_timeTableLocation);

      //  Size size = this.Size;
      //  Point pos = this.Position;

      //  state.PutInt(wxPorting.T("x"), pos.X);
      //  state.PutInt(wxPorting.T("y"), pos.Y);
      //  state.PutInt(wxPorting.T("w"), size.Width);
      //  state.PutInt(wxPorting.T("h"), size.Height);
      //  state.PutInt(wxPorting.T("sash"), m_splitter.SashPosition);
      //  state.PutInt(wxPorting.T("lower-sash"), m_bottomSplitter.SashPosition);

      //  state.PutInt(wxPorting.T("selected"), m_top.Selection);

      //  if(m_timeFrame != null) {
      //    size = m_timeFrame.Size;
      //    pos = m_timeFrame.Position;
      //    state.PutInt(wxPorting.T("timex"), pos.X);
      //    state.PutInt(wxPorting.T("timey"), pos.Y);
      //    state.PutInt(wxPorting.T("timew"), size.Width);
      //    state.PutInt(wxPorting.T("timeh"), size.Height);
      //  }
      //}

      ////
      ////
      ////

      //public void AddTimeTable(NotebookManager parent) {
      //  int i;

      //  for(i = 0; i < parent.PageCount; ++i) {
      //    Window pPage = parent.GetPage(i);
      //    if(pPage.Name == wxPorting.T("timetable")) {
      //      break;
      //    }
      //  }
      //  if(i >= parent.PageCount) {	// not found, maybe first time
      //    TimeTableView pTimeTable =
      //  m_timeTableManager.GetNewTimeTableView(parent, wxPorting.L("Schedule"));
      //    parent.AddPage(pTimeTable, wxPorting.L("Schedule"), false, -1);
      //    parent.Selection = (i);
      //  }
      //}

      ////
      ////
      ////

      //// Erik: Refactored to Finalize1 to avoid compiling problems
      //public void Finalize1() {
      //  int i;

      //  switch(m_timeTableLocation) {
      //    case TimeTableLocations.TIME_TABLE_TAB:
      //      //	    AddTimeTable(m_top);
      //      if(m_top.FindPage(m_timeTable) < 0)
      //        m_top.AddPage(m_timeTable, wxPorting.L("Schedule"), false, -1);
      //      m_timeTable.Reparent(m_top);
      //      break;

      //    case TimeTableLocations.TIME_TABLE_SPLIT:
      //      //	    AddTimeTable(m_left);
      //      //	    if((i = m_left.FindPageType(wxPorting.T("timetable"))) < 0)
      //      if(m_left.FindPage(m_timeTable) < 0)
      //        m_left.AddPage(m_timeTable, wxPorting.L("Schedule"), false, -1);
      //      m_timeTable.Reparent(m_left);
      //      break;

      //    case TimeTableLocations.TIME_TABLE_FRAME:
      //      break;
      //  }

      //  // see if we already created the alerts tab
      //  // when loading the state of the right notebook

      //  i = m_right.FindPageType(wxPorting.T("alerts"));
      //  if(i < 0)	// not found, maybe first time
      //    m_right.AddPage(m_alertList, wxPorting.L("Alerts"), false, -1);

      //  // see if we already created the traininfo tab
      //  // when loading the state of the right notebook

      //  i = m_right.FindPageType(wxPorting.T("traininfo"));
      //  if(i < 0)	// not found, maybe first time
      //    m_right.AddPage(m_trainInfo, wxPorting.L("Train Info"), false, -1);

      //  Globals.repaint_labels();
    }

    //
    //
    //

//    public void OnPrintSetup(object sender, Event evt) {
//      throw new NotImplementedException();
//      //m_printer.PageSetup();
//    }

//    //
//    //
//    //

//    public void OnPrintPreview(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Window w = m_top.GetCurrentPage();
//      //if(w == null)
//      //  return;
//      //if(w.Name == wxPorting.T("htmlview")) {
//      //  HtmlView p = (HtmlView)w;
//      //  p.OnPrintPreview(sender, evt);
//      //} else
//      //  wx.MessageDialog.MessageBox(wxPorting.L("Printing of this page is not supported."),
//      //    wxPorting.T("Error"), wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_STOP, this);
//    }

//    //
//    //
//    //

//    public void OnPrint(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Window w = m_top.GetCurrentPage();
//      //if(w == null)
//      //  return;
//      //String name = w.Name;
//      //if(name == wxPorting.T("htmlview")) {
//      //  HtmlView p = (HtmlView)w;
//      //  p.OnPrint(sender, evt);
//      //} else if(name == wxPorting.T("canvas")) {
//      //  Canvas p = (Canvas)w;
//      //  p.DoPrint();
//      //} else {
//      //  wx.MessageDialog.MessageBox(wxPorting.L("Printing of this page is not supported."),
//      //    wxPorting.T("Error"), wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_STOP, this);
//      //}
//    }

//    //
//    //
//    //

//    void mTimer_Elapsed(object sender, ElapsedEventArgs e) {
//      OnTimer(sender, null);
//    }

//    public void OnTimer(object sender, Event evt) {
//      Globals.traindir.OnTimer();
//    }

//    //
//    //	Customize user interface
//    //


//    public void OnZoomIn(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.set_zoom(true);
//      //int pg = m_top.FindPage(wxPorting.L("Layout"));
//      //if(pg >= 0) {
//      //  m_top.Selection = (pg);
//      //  m_top.Refresh();
//      //}
//    }

//    //
//    //
//    //

//    public void OnZoomOut(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.set_zoom(false);
//      //int pg = m_top.FindPage(wxPorting.L("Layout"));
//      //if(pg >= 0) {
//      //  m_top.Selection = (pg);
//      //  m_top.Refresh();
//      //}
//    }

//    //
//    //
//    //

//    public void OnShowCoord(object sender, Event evt) {
//      throw new NotImplementedException();
//      //MenuBar pBar = this.MenuBar;
//      //MenuItem pItem;

//      //MenuStrip dummyMenu;
//      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_SHOW_COORD, ref dummyMenu)) != null) {
//      //  Glboals.bShowCoord = pItem.Checked;
//      //}
//      ////	bShowCoord = !bShowCoord;
//      //Globals.set_show_coord(Globals.bShowCoord);
//      //Globals.invalidate_field();
//      //Globals.repaint_all();
//    }

//    //
//    //
//    //

//    public void OnShowLayout(object sender, Event evt) {
//      int pg = m_top.FindPage(wxPorting.L("Layout"));
//      if(pg >= 0) {
//        m_top.Selection = (pg);
//        m_top.Refresh();
//      }
//    }

//    //
//    //
//    //

//    public void OnShowSchedule(object sender, Event evt) {
//      int pg;
//      NotebookManager parent;

//      if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_TAB)
//        parent = m_top;
//      else if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_SPLIT)
//        parent = m_left;
//      else // TODO: bring frame to top
//        return;
//      pg = parent.FindPage(wxPorting.L("Schedule"));
//      if(pg >= 0) {
//        parent.Selection = (pg);
//        //	    parent.Refresh();
//      }
//    }

//    //
//    //
//    //

//    public void OnShowInfoPage(object sender, Event evt) {
//      throw new NotImplementedException();
//      //if(string.IsNullOrEmpty(Globals.info_page))
//      //  return;
//      //String page = String.Copy(wxPorting.T("showinfo "));
//      //page += Globals.info_page;
//      //Globals.trainsim_cmd(page);
//    }


//    //
//    //
//    //

//    public void OnShowStationsList(object sender, Event evt) {
//      throw new NotImplementedException();
////#if true
////      Globals.traindir.ShowStationsList();
////#else
////  int	pg = m_top.FindPage(wxPorting.T("stations"));
////  HtmlView *htmlView;

////  if(pg < 0) {
////      htmlView = new HtmlView(m_top);
////      m_top.AddPage(htmlView, wxPorting.T("stations"), true, -1);
////  } else
////      htmlView = (HtmlView *)m_top.GetPage(pg);

////  pHourLinks = 0;

////  GetHtmlPage(wxPorting.T("http://reiseauskunft.bahn.de/bin/zuginfo.exe/en/338733/224970/999712/386945/80/"));

////  wxFileName name = new wxFileName(wxPorting.T("C:/temp/vc.htm"));
////  htmlView.LoadFile(name);
////  wxHtmlContainerCell *root = htmlView.GetInternalRepresentation();
////  TraverseNodes(root);

////  HourLinks   *ph;
////  for(ph = pHourLinks; ph; ph = ph.m_next) {
////      GetHtmlPage(ph.m_link.fn_str());
////      ParseStationPage(htmlView, wxPorting.T("C:/temp/tt.htm"));
/////***/	    break;
////  }
////  wxFileName name1 = new wxFileName(wxPorting.T("C:/temp/tt.htm"));
////  htmlView.LoadFile(name1);

////  pg = m_top.FindPage(wxPorting.T("stations"));
////  m_top.Selection = (pg);
////#endif
//    }

//    //
//    //
//    //

//    public void OnTimeTableSplit(object sender, Event evt) {
//      throw new NotImplementedException();
//      //MoveTimeTableToSplit();
//      //Globals.OnShowLayout(sender, evt);
//    }

//    //
//    //
//    //

//    public void OnTimeTableTab(object sender, Event evt) {
//      MoveTimeTableToTab();
//    }

//    //
//    //
//    //

//    public void OnTimeTableFrame(object sender, Event evt) {
//      MoveTimeTableToFrame();
//    }

//    //
//    //
//    //

//    public void OnToolBar(object sender, Event evt) {
//      throw new NotImplementedException();
//      //MenuBar pBar = this.MenuBar;
//      //MenuItem pItem;

//      //MenuStrip dummyMenu;
//      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_TOOLBAR, ref dummyMenu))) {
//      //  m_toolbar.Show(m_showToolbar = pItem.Checked);
//      //  SendSizeEvent();
//      //}
//    }

//    //
//    //
//    //

//    public void OnStatusBar(object sender, Event evt) {
//      throw new NotImplementedException();
//      //MenuBar pBar = this.MenuBar;
//      //MenuItem pItem;
//      //StatusBar pStatus;

//      //MenuStrip dummyMenu;
//      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_STATUSBAR, ref dummyMenu)) != null) {
//      //  pStatus = this.StatusBar;
//      //  pStatus.Show(m_showStatusbar = pItem.Checked);
//      //  SendSizeEvent();
//      //}
//    }

//    //
//    //
//    //

//    public void OnRunButton(object sender, Event evt) {
//      throw new NotImplementedException();
//      //bool pressed = m_running.GetValue();
//      //Globals.traindir.OnStartStop();
//    }

//    //
//    //
//    //

//    public void OnOpenFile(object sender, Event evt) {
//      Globals.traindir.OnOpenFile();
//    }

//    //
//    //
//    //

//    public void OnSpinUp(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.trainsim_cmd(wxPorting.T("fast"));
//      //evt.StopPropagation();
//    }

//    //
//    //
//    //

//    public void OnSpinDown(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.trainsim_cmd(wxPorting.T("slow"));
//      //evt.StopPropagation();
//    }

//    //	OnSpin()
//    //
//    //	The if() below is required because on wxWidgets 2.8 on Linux
//    //	only the EVT_SPINCTRL() evt is sent, thus we
//    //	have to find out the desired direction (up/down)
//    //	and whether we reached the upper/lower limit.
//    //
//#if false
//public void OnSpin(object sender, Event evt)
//{
//  int x = evt.this.Position;
//  if((x == time_mult && time_mult != 1) || x >= time_mult)
//      trainsim_cmd(wxPorting.T("fast"));
//  else
//      trainsim_cmd(wxPorting.T("slow"));
//  repaint_labels(true);
//  evt.Skip();
//}
//#endif

//    //
//    //
//    //

//    public void OnRecent(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnRecent();
//    }

//    public void OnRestore(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnRestore();
//    }

//    public void OnSaveGame(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnSaveGame();
//    }

//    public void OnEdit(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnEdit();
//    }

//    public void OnNewTrain(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnNewTrain();
//    }

//    public void OnItinerary(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnItinerary();
//    }

//    public void OnSwitchboard(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.ShowSwitchboard();
//    }

//    public void OnSaveLayout(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnSaveLayout();
//    }

//    public void OnPreferences(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnPreferences();
//    }

//    public void OnEditSkin(object sender, Event evt) {
//      throw new NotImplementedException();
//      //TDSkin tmpSkin = new TDSkin();

//      //tmpSkin.name = Globals.wxStrdup(Globals.curSkin.name);
//      //tmpSkin.background = Globals.curSkin.background;
//      //tmpSkin.free_track = Globals.curSkin.free_track;
//      //tmpSkin.next = null;
//      //tmpSkin.occupied_track = Globals.curSkin.occupied_track;
//      //tmpSkin.outline = Globals.curSkin.outline;
//      //tmpSkin.reserved_shunting = Globals.curSkin.reserved_shunting;
//      //tmpSkin.reserved_track = Globals.curSkin.reserved_track;
//      //tmpSkin.working_track = Globals.curSkin.working_track;
//      //tmpSkin.text = Globals.curSkin.text;

//      //SkinColorsDialog skin = new SkinColorsDialog(Globals.traindir.m_frame, tmpSkin);

//      //if(skin.ShowModal() != ShowModalResult.OK)
//      //  return;

//      //if(Globals.curSkin == Globals.defaultSkin) {
//      //  tmpSkin.name = Globals.wxStrdup(wxPorting.T("Skin1"));
//      //  tmpSkin.next = Globals.skin_list;
//      //  Globals.skin_list = tmpSkin;
//      //  Globals.curSkin = tmpSkin;
//      //} else {
//      //  Globals.curSkin.background = tmpSkin.background;
//      //  Globals.curSkin.free_track = tmpSkin.free_track;
//      //  Globals.curSkin.occupied_track = tmpSkin.occupied_track;
//      //  Globals.curSkin.outline = tmpSkin.outline;
//      //  Globals.curSkin.reserved_shunting = tmpSkin.reserved_shunting;
//      //  Globals.curSkin.reserved_track = tmpSkin.reserved_track;
//      //  Globals.curSkin.working_track = tmpSkin.working_track;
//      //  Globals.curSkin.text = tmpSkin.text;
//      //  Globals.delete(tmpSkin);
//      //}
//    }

//    public void OnNewLayout(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnNewLayout();
//    }

//    public void OnInfo(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnInfo();
//    }

//    public void OnStartStop(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnStartStop();
//    }

//    public void OnGraph(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnGraph();
//    }

//    public void OnLateGraph(object sender, Event evt) {
//      ShowLateGraph();
//    }

//    public void OnPlatformGraph(object sender, Event evt) {
//      ShowPlatformGraph();
//    }

//    public void OnRestart(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnRestart();
//    }

//    public void OnFast(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnFast();
//    }

//    public void OnSlow(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnSlow();
//    }

//    public void OnSkip(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnSkipToNext();
//    }

//    public void OnStationSched(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnStationSched();
//    }

//    public void OnSetGreen(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnSetGreen();
//    }

//    public void OnSelectItin(object sender, Event evt) {
//      throw new NotImplementedException();
//      //if(Globals.itinKeyDialog == null)
//      //  Globals.itinKeyDialog = new ItineraryKeyDialog(this);

//      //Globals.itinKeyDialog.ShowModal();
//    }

//    public void OnPerformance(object sender, Event evt) {
//      throw new NotImplementedException();
//      //Globals.traindir.OnPerformance();
//    }

    public void ShowTrainInfoList(Train trn) {
      throw new NotImplementedException();
      //int pg = m_right.FindPage(wxPorting.L("Train Info"));
      //if(pg >= 0)
      //  m_right.Selection = (pg);
      //m_trainInfo.Update(trn);
    }

    public void ShowItinerary(bool show) {
      throw new NotImplementedException();
      //if(!show) {
      //  m_itineraryView.Show(false);
      //  m_left.RemovePage(m_itineraryView);
      //  return;
      //}
      //m_itineraryView.Show(true);
      //m_left.AddPage(m_itineraryView, wxPorting.L("Itinerary"), true, -1);
    }

    public void ShowTools(bool show) {
      throw new NotImplementedException();
      //bool firstTime = false;

      //if(!show) {
      //  if(m_toolsView == null)
      //    return;
      //  m_toolsView.Show(false);
      //  m_left.RemovePage(m_toolsView);
      //  return;
      //}
      //if(m_toolsView == null) {
      //  ToolsView pView = new ToolsView(m_left);
      //  m_toolsView = pView;
      //  firstTime = true;
      //}
      //m_toolsView.Show(true);
      //m_left.AddPage(m_toolsView, wxPorting.L("Tools"), true, -1);

      //int pg = m_left.FindPage(wxPorting.L("Tools"));
      //if(pg >= 0) {
      //  m_left.Selection = (pg);
      //  m_left.Refresh();
      //}
      //if(firstTime)
      //  Globals.trainsim_cmd(wxPorting.T("selecttool 1,0"));
    }

    public void ShowHtml(String name, String page) {
      throw new NotImplementedException();
      //int pg = m_top.FindPage(name);
      //HtmlView htmlView;

      //if(pg < 0) {
      //  htmlView = new HtmlView(m_top);
      //  m_top.AddPage(htmlView, name, true, -1);
      //} else
      //  htmlView = (HtmlView)m_top.GetPage(pg);
      //htmlView.SetPage(page);
      //pg = m_top.FindPage(name);
      //m_top.Selection = (pg);
    }

    public void ShowGraph() {
      throw new NotImplementedException();
      //if(m_graphView == null) {
      //  GraphView pView = new GraphView(m_top);
      //  m_graphView = pView;
      //}
      //m_graphView.Show(true);

      //int pg = m_top.FindPage(wxPorting.L("Graph"));
      //if(pg >= 0)
      //  m_top.Selection = (pg);
      //else
      //  m_top.AddPage(m_graphView, wxPorting.L("Graph"), true, -1);
      //m_graphView.Refresh();
      //m_top.Refresh();
    }

    public void ShowLateGraph() {
      throw new NotImplementedException();
      //if(m_lateGraphView == null) {
      //  LateGraphView pView = new LateGraphView(m_top);
      //  m_lateGraphView = pView;
      //}
      //m_lateGraphView.Show(true);

      //int pg = m_top.FindPage(wxPorting.L("Late Graph"));
      //if(pg >= 0)
      //  m_top.Selection = (pg);
      //else
      //  m_top.AddPage(m_lateGraphView, wxPorting.L("Late Graph"), true, -1);
      //m_lateGraphView.Refresh();
      //m_top.Refresh();
    }

    public void ShowPlatformGraph() {
      throw new NotImplementedException();
      //if(m_platformGraphView == null) {
      //  PlatformGraphView pView = new PlatformGraphView(m_top);
      //  m_platformGraphView = pView;
      //}
      //m_platformGraphView.Show(true);

      //int pg = m_top.FindPage(wxPorting.L("Platform Graph"));
      //if(pg >= 0)
      //  m_top.Selection = (pg);
      //else
      //  m_top.AddPage(m_platformGraphView, wxPorting.L("Platform Graph"), true, -1);
      //m_platformGraphView.Refresh();
      //m_top.Refresh();
    }

    //public void OnChar(object sender, Event evt) {
    //  if(((KeyEvent)evt).KeyCode == 9) {
    //    return;
    //  }
    //  evt.Skip();
    //}


  }
}
