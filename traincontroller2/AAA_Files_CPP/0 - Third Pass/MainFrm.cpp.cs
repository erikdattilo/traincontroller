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

using System;
using wx;
using wx.Html;
using System.Drawing;


namespace TrainDirPorting {

  using TabControl = System.Windows.Forms.TabControl;
  using SplitContainer = System.Windows.Forms.SplitContainer;


  public partial class Configuration { public const int NSTATUSBOXES = 5; }

  public enum TimeTableLocations {
    TIME_TABLE_NONE = 0,
    TIME_TABLE_TAB = 1,
    TIME_TABLE_SPLIT = 2,
    TIME_TABLE_FRAME = 3
  }

  public class CanvasManager {
    public Canvas[] m_canvasList = new Canvas[Configuration.NUMCANVASES];
  }

  public class TimeTableViewManager {
    public TimeTableView GetNewTimeTableView(Window parent, String name) {
      int i;

      for(i = 0; i < Configuration.NUMTTABLES; ++i) {
        if(m_timeTableList[i] == null)
          break;
      }
      if(i >= Configuration.NUMTTABLES)
        return null;
      TimeTableView pTimeTable = new TimeTableView(parent, name);
      m_timeTableList[i] = pTimeTable;
      return pTimeTable;
    }

    public bool IsTimeTable(Window pWin) {
      int i;
      for(i = 0; i < Configuration.NUMTTABLES; ++i)
        if(pWin == m_timeTableList[i])
          return true;
      return false;
    }

    public TimeTableView GetTimeTable(int i) {
      if(i >= Configuration.NUMTTABLES)
        return null;
      return m_timeTableList[i];
    }

    public Window m_parent;
    public TimeTableView[] m_timeTableList = new TimeTableView[Configuration.NUMTTABLES];
  }

  public class HtmlManager {
    public Canvas[] m_htmlList = new Canvas[Configuration.NUMHTMLS];
  }

  public class MySplitterWindow : SplitterWindow {

    private Frame m_frame;
    public MySplitterWindow(Window parent)
      : base(parent, wx.Window.wxID_ANY,
                         wxDefaultPosition, wxDefaultSize,
                         WindowStyles.SP_3D | WindowStyles.SP_LIVE_UPDATE |
                         WindowStyles.CLIP_CHILDREN /* | wxSP_NO_XP_THEME */ ) {

      //EVT_SPLITTER_SASH_POS_CHANGED(wx.Window.wxID_ANY, new wx.EventListener(OnPositionChanged));
      //EVT_SPLITTER_SASH_POS_CHANGING(wx.Window.wxID_ANY, new wx.EventListener(OnPositionChanged));

      //EVT_SPLITTER_DCLICK(wx.Window.wxID_ANY, new wx.EventListener(OnDClick));
    }

    public void OnPositionChanged(object sender, Event evt) {
      evt.Skip();
    }

    public void OnPositionChanging(object sender, Event evt) {
      evt.Skip();
    }

    public void OnDClick(object sender, Event evt) {
      //evt.StopPropagation();
    }

    public void OnDoubleClickSash(int x, int y) {
    }
  }

  public static partial class Globals {
    public static ItineraryKeyDialog itinKeyDialog;
    public static LogFilter gLogger;
    //
    //	Show Dialogs
    //

    public static void ShowTrackProperties(Track trk) {
      TrackDialog diag = new TrackDialog(Globals.traindir.m_frame);

      diag.ShowModal(trk);
    }


    public static void ShowTrackScriptDialog(Track trk) {
      TrackScriptDialog diag = new TrackScriptDialog(Globals.traindir.m_frame);

      diag.ShowModal(trk);
    }


    public static void ShowSignalProperties(Signal sig) {
      SignalDialog diag = new SignalDialog(Globals.traindir.m_frame);

      diag.ShowModal(sig);
    }

    public static void ShowTriggerProperties(Track trk) {
      TriggerDialog diag = new TriggerDialog(Globals.traindir.m_frame);

      diag.ShowModal(trk);
    }

    public static void switch_properties_dialog(Track sw) {
      TrackDialog diag = new TrackDialog(Globals.traindir.m_frame);

      diag.ShowModal(sw);
    }

    public static void ShowPerformance() {
      HtmlPage page = new HtmlPage(wxPorting.T(""));
      show_schedule_status(page);

      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Performance"), page.content);
    }

    public static void ShowSwitchboard() {
      HtmlPage page = new HtmlPage(wxPorting.T(""));
      get_switchboard(page);

      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Switchboard"), page.content);
    }

    public static void ShowOptionsDialog() {
      OptionsDialog opts = new OptionsDialog(Globals.traindir.m_frame);
      opts.ShowModal();
    }

    public static void ShowDaySelectionDialog() {
      DaysDialog days = new DaysDialog(Globals.traindir.m_frame);
      days.ShowModal();
    }

    public static void ShowTrainInfo(Train trn) {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      train_print(trn, page);
      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Train Info"), page.content);
    }

    public static void ShowTrainInfoDialog(Train trn) {
      TrainInfoDialog diag = new TrainInfoDialog(Globals.traindir.m_frame);
      diag.ShowModal(trn);
    }

    public static void ShowScenarioInfoDialog() {
      ScenarioInfoDialog diag = new ScenarioInfoDialog(Globals.traindir.m_frame);
      diag.ShowModal();
    }

    public static void ShowAssignDialog(Train trn) {
      AssignDialog diag = new AssignDialog(Globals.traindir.m_frame);
      diag.ShowModal(trn);
    }

    public static void ShowStationSchedule(String name, bool saveToFile) {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      if(name == null)
        return;
      build_station_schedule(name);
      do_station_list_print(name, page);
      if(!saveToFile) {
        Globals.traindir.m_frame.ShowHtml(wxPorting.L("Station Schedule"), page.content);
        return;
      }
      Globals.traindir.SaveHtmlPage(page);
    }

    public static void ShowStationScheduleDialog(String name) {
      StationInfoDialog diag = new StationInfoDialog(Globals.traindir.m_frame);

      diag.ShowModal(name);
    }

    public static void ShowItineraryDialog(Itinerary it) {
      ItineraryDialog itin = new ItineraryDialog(Globals.traindir.m_frame);

      itin.ShowModal(it);
    }

    public static void ShowWelcomePage() {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      Globals.traindir.BuildWelcomePage(page);
      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Welcome"), page.content);
    }

    public static void track_info_dialogue() {
      ShowScenarioInfoDialog();
    }



    public static void switchboard_name_dialog(String name) {
      SwitchboardNameDialog sbname = new SwitchboardNameDialog(Globals.traindir.m_frame);

      SwitchBoard sb = null;
      if(string.IsNullOrEmpty(name) == false)
        sb = FindSwitchBoard(name);
      sbname.ShowModal(sb);
    }


    public static void switchboard_cell_dialog(int x, int y) {
      SwitchboardNameDialog.SwitchboardCellDialog sbcell = new SwitchboardNameDialog.SwitchboardCellDialog(Globals.traindir.m_frame);

      sbcell.ShowModal(x, y);
    }

    public static void skin_config_dialog() {
      SkinColorsDialog skin = new SkinColorsDialog(Globals.traindir.m_frame, curSkin);

      skin.ShowModal();
    }
  }

  public class LogFilter {
    public LogFilter() {
      m_parent = null;
      m_oldLog = null;
    }

    public void SetParent(MainFrame pParent) { m_parent = pParent; }

    public MainFrame m_parent;
    public Log m_oldLog;
    public String m_extraInfo;

    // ----------------------------------------------------------------------------
    // LogFilter
    // ----------------------------------------------------------------------------

    public void InstallLog() {
      //m_oldLog = wx.Log.GetActiveTarget();
      //wx.Log.SetActiveTarget(this);
    }

    public void UninstallLog() {
      //wx.Log.SetActiveTarget(m_oldLog);
      //m_oldLog = null;
    }

    public void DoLog(wx.Log.eLogLevel level, String szString, time_t t) {
      if(m_parent.m_alertList != null) {
        m_parent.m_alertList.AddLine(m_extraInfo + wxPorting.T(": ") + szString);
      }
    }

    public void SetExtraInfo(String extra) {
      m_extraInfo = extra;
    }
  }

  // ----------------------------------------------------------------------------
  // TimeFrame
  // ----------------------------------------------------------------------------

  public class TimeFrame : Frame {
    public MainFrame m_parent;

    public TimeFrame(MainFrame parent, String title)
      : base(parent, wx.Window.wxID_ANY, title) {
      EVT_CLOSE(new wx.EventListener(OnClose));

      m_parent = parent;
    }

    //	When we are closed, we need to detach the schedule
    //	list view and attach it to something that's still
    //	visible, in this case the main frame's main view.

    public void OnClose(object sender, Event evt) {
      //MenuItem pItem;

      //m_parent.m_timeTable.Reparent(m_parent.m_top);
      //m_parent.m_top.AddPage(m_parent.m_timeTable, wxPorting.L("Schedule"), false, -1);
      //m_parent.m_timeTableLocation = TimeTableLocations.TIME_TABLE_TAB;
      //m_parent.m_timeFrame = null;
      //if((pItem = m_parent.MenuBar.FindItem(MenuIDs.MENU_TIME_TAB, 0)))
      //  pItem.Checked = true;
      //evt.Skip();
    }
  }

  // ----------------------------------------------------------------------------
  // MainFrame
  // ----------------------------------------------------------------------------

  public class MainFrame : Frame {
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

    public StaticText m_clock;
    public SpinButton m_speedArrows;
    public TextCtrl m_speed;
    public ToggleButton m_running;
    public StaticText m_statusText;
    public StaticText m_alertText;

    //
    //
    //

    public Traindir m_app;
    public NotebookManager m_top;		// top (pages are Canvases or TimeTable or Html)
    public NotebookManager m_left;	// bottom-left
    public NotebookManager m_right;	// bottom-right
    public SplitContainer m_splitter;
    public SplitterWindow m_bottomSplitter;
    public int m_topSashValue;
    public ToolBar m_toolbar;
    public StatusBar m_statusbar;
    public Timer m_timer;
    public TimeFrame m_timeFrame;	// showing time table in separate frame
    public HtmlEasyPrinting m_printer;
    public String m_htmlPage;

    public ItineraryView m_itineraryView;
    public ToolsView m_toolsView;
    public GraphView m_graphView;
    public LateGraphView m_lateGraphView;
    public PlatformGraphView m_platformGraphView;
    public TrainInfoList m_trainInfo;
    public AlertList m_alertList;

    public Menu m_viewMenu;

    public void OnAbout(object sender, Event evt) {
      Globals.ShowWelcomePage();
    }

    public void OnCopyright(object sender, Event evt) {
      String notice;

      notice = String.Format(wxPorting.T("%s - %s\n\n"), Globals.program_name, Globals.__DATE__);	// wxPorting.L("Traindir 3.0\n\n");
      notice += wxPorting.L("Created by");
      notice += wxPorting.T(" Giampiero Caprino\n\n");
      notice += wxPorting.L("This is free software, released under the\nGNU General Public License Version 2.\nThe author declines any responsibility for any damage\nthat might occur from the use of this program.");
      notice += wxPorting.T("    \n\n");
      notice += wxPorting.L("This is a game, and is not intended to\nbe used to actually control train traffic.");

      wx.MessageDialog.MessageBox(notice);
      //	ShowWelcomePage();
    }

    public void OnLanguage(object sender, Event evt) {
      ConfigDialog diag = new ConfigDialog(this);

      if(diag.ShowModal() == 0) // TODO / Erik ==> Find the right enum value
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

      if(Globals.layout_modified) {
        if(Globals.ask_to_save_layout() < 0)
          return;
      }
      Globals.traindir.SaveState();
      if(Globals.user_name._sValue.Length > 0) {
        Globals.bstreet_logout();
      }
      Destroy();
    }

    //
    //
    //

    public MainFrame(String title)
      : base(null, wx.Window.wxID_ANY, title) {
//      m_timer = new Timer(this, MenuIDs.TIMER_ID);
//      m_itineraryView = null;
//      m_toolsView = null;
//      m_graphView = null;
//      m_lateGraphView = null;
//      m_platformGraphView = null;
//      m_alertList = null;
//      m_trainInfo = null;

//      EVT_MENU(wx.MenuIDs.wxID_OPEN, new wx.EventListener(OnOpenFile));
//      EVT_MENU(MenuIDs.MENU_RECENT, new wx.EventListener(OnRecent));
//      EVT_MENU(wx.MenuIDs.wxID_SAVE, new wx.EventListener(OnSaveGame));
//      EVT_MENU(wx.MenuIDs.wxID_REVERT, new wx.EventListener(OnRestore));
//      EVT_MENU(MenuIDs.MENU_HTML_PRINTSETUP, new wx.EventListener(OnPrintSetup));
//      EVT_MENU(MenuIDs.MENU_HTML_PREVIEW, new wx.EventListener(OnPrintPreview));
//      EVT_MENU(MenuIDs.MENU_HTML_PRINT, new wx.EventListener(OnPrint));
//      EVT_MENU(wx.MenuIDs.wxID_EXIT, new wx.EventListener(OnQuit));

//      EVT_MENU(MenuIDs.MENU_EDIT, new wx.EventListener(OnEdit));
//      EVT_MENU(MenuIDs.MENU_NEW_TRAIN, new wx.EventListener(OnNewTrain));
//      EVT_MENU(MenuIDs.MENU_ITINERARY, new wx.EventListener(OnItinerary));
//      EVT_MENU(MenuIDs.MENU_SWITCHBOARD, new wx.EventListener(OnSwitchboard));
//      EVT_MENU(MenuIDs.MENU_SAVE_LAYOUT, new wx.EventListener(OnSaveLayout));
//      EVT_MENU(MenuIDs.MENU_PREFERENCES, new wx.EventListener(OnPreferences));
//      EVT_MENU(MenuIDs.MENU_EDIT_SKIN, new wx.EventListener(OnEditSkin));
//      EVT_MENU(MenuIDs.MENU_NEW_LAYOUT, new wx.EventListener(OnNewLayout));
//      EVT_MENU(MenuIDs.MENU_INFO, new wx.EventListener(OnInfo));
//      EVT_MENU(MenuIDs.MENU_STATIONS_LIST, new wx.EventListener(OnShowStationsList));

//      EVT_MENU(MenuIDs.MENU_START, new wx.EventListener(OnStartStop));
//      EVT_MENU(MenuIDs.MENU_GRAPH, new wx.EventListener(OnGraph));
//      EVT_MENU(MenuIDs.MENU_LATEGRAPH, new wx.EventListener(OnLateGraph));
//      EVT_MENU(MenuIDs.MENU_PLATFORMGRAPH, new wx.EventListener(OnPlatformGraph));
//      EVT_MENU(MenuIDs.MENU_RESTART, new wx.EventListener(OnRestart));
//      EVT_MENU(MenuIDs.MENU_FAST, new wx.EventListener(OnFast));
//      EVT_MENU(MenuIDs.MENU_SLOW, new wx.EventListener(OnSlow));
//      EVT_MENU(MenuIDs.MENU_SKIP, new wx.EventListener(OnSkip));
//      EVT_MENU(MenuIDs.MENU_STATION_SCHED, new wx.EventListener(OnStationSched));
//      EVT_MENU(MenuIDs.MENU_SETGREEN, new wx.EventListener(OnSetGreen));
//      EVT_MENU(MenuIDs.MENU_SELECT_ITIN, new wx.EventListener(OnSelectItin));
//      EVT_MENU(MenuIDs.MENU_PERFORMANCE, new wx.EventListener(OnPerformance));

//      EVT_MENU(MenuIDs.MENU_ZOOMIN, new wx.EventListener(OnZoomIn));
//      EVT_MENU(MenuIDs.MENU_ZOOMOUT, new wx.EventListener(OnZoomOut));

//      EVT_MENU(MenuIDs.MENU_SHOW_COORD, new wx.EventListener(OnShowCoord));
//      EVT_MENU(MenuIDs.MENU_SHOW_LAYOUT, new wx.EventListener(OnShowLayout));
//      EVT_MENU(MenuIDs.MENU_SHOW_SCHEDULE, new wx.EventListener(OnShowSchedule));
//      EVT_MENU(MenuIDs.MENU_INFO_PAGE, new wx.EventListener(OnShowInfoPage));

//      EVT_MENU(MenuIDs.MENU_TIME_SPLIT, new wx.EventListener(OnTimeTableSplit));
//      EVT_MENU(MenuIDs.MENU_TIME_TAB, new wx.EventListener(OnTimeTableTab));
//      EVT_MENU(MenuIDs.MENU_TIME_FRAME, new wx.EventListener(OnTimeTableFrame));

//      EVT_MENU(MenuIDs.MENU_TOOLBAR, new wx.EventListener(OnToolBar));
//      EVT_MENU(MenuIDs.MENU_STATUSBAR, new wx.EventListener(OnStatusBar));
//      EVT_MENU(wx.MenuIDs.wxID_ABOUT, new wx.EventListener(OnAbout));
//      EVT_MENU(MenuIDs.MENU_COPYRIGHT, new wx.EventListener(OnCopyright));
//      EVT_MENU(MenuIDs.MENU_LANGUAGE, new wx.EventListener(OnLanguage));

//      EVT_TOGGLEBUTTON((int)MenuIDs.ID_RUN, new wx.EventListener(OnRunButton));

//      EVT_SPIN_UP((int)MenuIDs.ID_SPIN, new wx.EventListener(OnSpinUp));
//      EVT_SPIN_DOWN((int)MenuIDs.ID_SPIN, new wx.EventListener(OnSpinDown));

//      EVT_CLOSE(new wx.EventListener(OnClose));
      EVT_TIMER(new wx.EventListener(OnTimer)); // EVT_TIMER((int)MenuIDs.TIMER_ID, new wx.EventListener(OnTimer));
//      EVT_CHAR(new wx.EventListener(OnChar));

//      //
//      //	Menus
//      //

//      Menu fileMenu = new Menu();
//      fileMenu.Append(wx.MenuIDs.wxID_OPEN, wxPorting.L("&Open...\tCtrl-O"), wxPorting.L("Open a simulation file."));
//      fileMenu.Append(wx.MenuIDs.wxID_SAVE, wxPorting.L("&Save Game..."), wxPorting.L("Open a saved simulation file."));
//      fileMenu.Append(wx.MenuIDs.wxID_REVERT, wxPorting.L("&Restore..."), wxPorting.L("Restore from the last saved state."));
//      fileMenu.AppendSeparator();
//      fileMenu.Append(MenuIDs.MENU_HTML_PRINTSETUP, wxPorting.L("Page set&up"), wxPorting.L("Changes the page layout settings."));
//      fileMenu.Append(MenuIDs.MENU_HTML_PREVIEW, wxPorting.L("Pre&view"), wxPorting.L("Preview print output."));
//      fileMenu.Append(MenuIDs.MENU_HTML_PRINT, wxPorting.L("&Print"), wxPorting.L("Print all or part of the document."));
//      fileMenu.AppendSeparator();
//      fileMenu.Append(wx.MenuIDs.wxID_EXIT, wxPorting.L("E&xit\tAlt-F4"), wxPorting.L("Quit this program."));

//      Menu editMenu = new Menu();
//      editMenu.Append(MenuIDs.MENU_EDIT, wxPorting.L("&Edit\tCtrl-E"), wxPorting.L("Enter/exit layout editor."));
//      //	editMenu.Append(MenuIDs.MENU_NEW_TRAIN, wxPorting.L("&New Train..."), wxPorting.L("Enter data about a new train."));
//      editMenu.Append(MenuIDs.MENU_ITINERARY, wxPorting.L("&Itinerary"), wxPorting.L("Enter/exit itinerary editor."));
//      editMenu.Append(MenuIDs.MENU_SWITCHBOARD, wxPorting.L("Switch&board"), wxPorting.L("Shows the switchboard editor."));
//      editMenu.Append(MenuIDs.MENU_SAVE_LAYOUT, wxPorting.L("&Save Layout"), wxPorting.L("Save changes to the layout."));
//      editMenu.Append(MenuIDs.MENU_PREFERENCES, wxPorting.L("&Preferences..."), wxPorting.L("Change program's preferences."));
//      //	editMenu.Append(MenuIDs.MENU_EDIT_SKIN, wxPorting.L("S&kin colors..."), wxPorting.L("Change the colors of graphical elements."));
//      editMenu.Append(MenuIDs.MENU_NEW_LAYOUT, wxPorting.L("Ne&w"), wxPorting.L("Erase the layout."));
//      editMenu.Append(MenuIDs.MENU_INFO, wxPorting.L("In&fo"), wxPorting.L("Show information about the scenario."));
//      editMenu.Append(MenuIDs.MENU_STATIONS_LIST, wxPorting.L("Stations &List"), wxPorting.L("Show list of stations and entry points."));

//      Menu runMenu = new Menu();
//      runMenu.Append(MenuIDs.MENU_START, wxPorting.L("&Start\tCtrl-S"), wxPorting.L("Start/stop the simulation."));
//      runMenu.Append(MenuIDs.MENU_GRAPH, wxPorting.L("&Graph\tCtrl-G"), wxPorting.L("Show the timetable graph."));
//      runMenu.Append(MenuIDs.MENU_LATEGRAPH, wxPorting.L("&Late Graph\tCtrl-wxPorting.L"), wxPorting.L("Show accumulation of late minutes over time."));
//      runMenu.Append(MenuIDs.MENU_PLATFORMGRAPH, wxPorting.L("&Platform Graph"), wxPorting.L("Show platforms occupancy over time."));
//      runMenu.Append(MenuIDs.MENU_RESTART, wxPorting.L("&Restart..."), wxPorting.L("Restart the simulation."));
//      runMenu.Append(MenuIDs.MENU_FAST, wxPorting.L("&Fast\tCtrl-X"), wxPorting.L("Speed up the simulation."));
//      runMenu.Append(MenuIDs.MENU_SLOW, wxPorting.L("&Slow\tCtrl-Z"), wxPorting.L("Slow down the simulation."));
//      runMenu.Append(MenuIDs.MENU_SKIP, wxPorting.L("S&kip ahead\tCtrl-K"), wxPorting.L("Skip to 3 minutes before next evt."));
//      runMenu.Append(MenuIDs.MENU_STATION_SCHED, wxPorting.L("S&tation schedule\tF6"), wxPorting.L("Show the train schedule of each station."));
//      runMenu.Append(MenuIDs.MENU_SETGREEN, wxPorting.L("Set sig. to green"), wxPorting.L("Set all automatic signals to green."));
//      runMenu.Append(MenuIDs.MENU_SELECT_ITIN, wxPorting.L("Select Itinerary\tCtrl-I"), wxPorting.L("Select an itinerary by name."));
//      runMenu.Append(MenuIDs.MENU_PERFORMANCE, wxPorting.L("&Performance"), wxPorting.L("Show performance data."));

//      m_viewMenu = new Menu();
//      m_viewMenu.Append(MenuIDs.MENU_SHOW_LAYOUT, wxPorting.L("Show layout\tF3"), wxPorting.L("Forcibly show the layout window."));
//      m_viewMenu.Append(MenuIDs.MENU_SHOW_SCHEDULE, wxPorting.L("Show schedule\tF4"), wxPorting.L("Forcibly show the schedule window."));
//      m_viewMenu.Append(MenuIDs.MENU_INFO_PAGE, wxPorting.L("Show info page\tF5"), wxPorting.L("Shows the scenario info page, if available."));
//      m_viewMenu.AppendSeparator();
//      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_SPLIT, wxPorting.L("Timetable in split window"), wxPorting.L("View timetable in a split window."));
//      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_TAB, wxPorting.L("Timetable in tabbed window"), wxPorting.L("View timetable in a tab of the main window."));
//      m_viewMenu.AppendRadioItem((int)MenuIDs.MENU_TIME_FRAME, wxPorting.L("Timetable in separate window"), wxPorting.L("View timetable in a window separate from the main window."));

//      m_viewMenu.AppendSeparator();

//      m_viewMenu.Append(MenuIDs.MENU_ZOOMIN, wxPorting.L("Zoom in"), wxPorting.L("Draw the layout at double the resolution."));
//      m_viewMenu.Append(MenuIDs.MENU_ZOOMOUT, wxPorting.L("Zoom out"), wxPorting.L("Draw the layour at normal resolution."));

//      m_viewMenu.AppendSeparator();

//      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_SHOW_COORD, wxPorting.L("Coord bars"), wxPorting.L("View/hide the coordinate bars."));
//      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_TOOLBAR, wxPorting.L("Tool bar"), wxPorting.L("View/hide the tools bar."));
//      m_viewMenu.AppendCheckItem((int)MenuIDs.MENU_STATUSBAR, wxPorting.L("Status bar"), wxPorting.L("View/hide the status bar."));

//      Menu helpMenu = new Menu();
//      helpMenu.Append(wx.MenuIDs.wxID_ABOUT, wxPorting.L("Welcome\tF1"), wxPorting.L("Show the welcome page."));
//      helpMenu.Append(MenuIDs.MENU_COPYRIGHT, wxPorting.L("Copyright"), wxPorting.L("Show the copyright notice."));
//      helpMenu.Append(MenuIDs.MENU_LANGUAGE, wxPorting.L("Language"), wxPorting.L("Select the language to be used next time Traindir is started."));

//      MenuBar menuBar = new MenuBar();

//      menuBar.Append(fileMenu, wxPorting.L("&File"));
//      menuBar.Append(editMenu, wxPorting.L("&Edit"));
//      menuBar.Append(runMenu, wxPorting.L("&Run"));
//      menuBar.Append(m_viewMenu, wxPorting.L("&View"));
//      menuBar.Append(helpMenu, wxPorting.L("&Help"));

//      MenuBar = (menuBar);

//      MenuItem pItem = new MenuItem();

//      Menu dummy;
//      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TIME_SPLIT, ref dummy)))
//        pItem.Checked = (true);
//      m_timeTableLocation = TimeTableLocations.TIME_TABLE_SPLIT;
//      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_TOOLBAR, ref dummy)))
//        pItem.Checked = (true);
//      m_showToolbar = true;
//      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_STATUSBAR, ref dummy)))
//        pItem.Checked = (true);
//      m_showStatusbar = true;
//      if((pItem = menuBar.FindItem((int)MenuIDs.MENU_SHOW_COORD, ref dummy)))
//        pItem.Checked = (Globals.bShowCoord);

//      //
//      //	Toolbar
//      //
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
//          wxPorting.L("Start"), wxDefaultPosition, new Size(50, 30));
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

//      //
//      //	Status bar
//      //

//      StatusBar m_statusBar = new StatusBar(this, wx.Window.wxID_ANY);
//      int[] widths = new int[Configuration.NSTATUSBOXES] { -50, -30, -20, -30, -50 };
//      m_statusBar.SetFieldsCount(WXSIZEOF(widths), widths);
//      this.StatusBar = m_statusBar;

#if ADDED_IN_DESIGNER
      //
      //	Client area
      //
      //	m_splitter controls the top and bottom views
      //

      m_splitter = new TabControl(this);
      m_splitter.SashGravity = (1.0);
#endif
//      //
//      //	the top view is the layout Canvas
//      //	inside a managing notebook
//      //

//      m_top = new NotebookManager(m_splitter, wxPorting.T("top"), MenuIDs.ID_NOTEBOOK_TOP);

//      Canvas pCanvas = new Canvas(m_top);
//      pCanvas.Name = (wxPorting.T("canvas"));
//      m_top.AddPage(pCanvas, wxPorting.L("Layout"), true, -1);

//      //
//      //	the bottom view is another splitter
//      //

//      m_bottomSplitter = new MySplitterWindow(m_splitter);
//      m_bottomSplitter.SashGravity = (0.5);

//      //
//      //	the bottom left view has a managed
//      //	notebook which will hold the schedule
//      //	list, edit tools view and itinerary list
//      //

//      m_left = new NotebookManager(m_bottomSplitter, wxPorting.T("left"), MenuIDs.ID_NOTEBOOK_LEFT);
//      m_timeTable = m_timeTableManager.GetNewTimeTableView(m_left, wxPorting.L("Schedule"));
//      m_itineraryView = new ItineraryView(m_left, wxPorting.L("Itinerary"));
//      m_itineraryView.Show(false);

//      //
//      //	the bottom right view has a managed
//      //	notebook which will hold the train
//      //	info list and the alerts list
//      //

//      m_right = new NotebookManager(m_bottomSplitter, wxPorting.T("right"), MenuIDs.ID_NOTEBOOK_RIGHT);
//      m_alertList = new AlertList(m_right, wxPorting.L("Alerts"));
//      m_trainInfo = new TrainInfoList(m_right, wxPorting.L("Train Info"));

//      m_timeFrame = null;
#if ADDED_IN_DESIGNER
      // you can also do this to start with a single window
      // you can also try -100
      m_splitter.SplitHorizontally(m_top, m_bottomSplitter, 300);
#endif
//      wxSize sz = this.Size;
//      m_bottomSplitter.SplitVertically(m_left, m_right, -300);

//      m_top.Show(true);
//      m_left.Show(true);
//      m_right.Show(true);
//      m_timer.Start(100);

//      gLogger.SetParent(this);

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

    //~MainFrame() {
    //  if(m_splitter != null) {
    //    Globals.delete(m_splitter);
    //    m_splitter = null;
    //  }
    //  if(m_printer != null) {
    //    Globals.delete(m_printer);
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
      //Menu dummyMenu;

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

    public void OnPrintSetup(object sender, Event evt) {
      m_printer.PageSetup();
    }

    //
    //
    //

    public void OnPrintPreview(object sender, Event evt) {
      //Window w = m_top.GetCurrentPage();
      //if(w == null)
      //  return;
      //if(w.Name == wxPorting.T("htmlview")) {
      //  HtmlView p = (HtmlView)w;
      //  p.OnPrintPreview(sender, evt);
      //} else
      //  wx.MessageDialog.MessageBox(wxPorting.L("Printing of this page is not supported."),
      //    wxPorting.T("Error"), wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_STOP, this);
    }

    //
    //
    //

    public void OnPrint(object sender, Event evt) {
      //Window w = m_top.GetCurrentPage();
      //if(w == null)
      //  return;
      //String name = w.Name;
      //if(name == wxPorting.T("htmlview")) {
      //  HtmlView p = (HtmlView)w;
      //  p.OnPrint(sender, evt);
      //} else if(name == wxPorting.T("canvas")) {
      //  Canvas p = (Canvas)w;
      //  p.DoPrint();
      //} else {
      //  wx.MessageDialog.MessageBox(wxPorting.L("Printing of this page is not supported."),
      //    wxPorting.T("Error"), wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_STOP, this);
      //}
    }

    //
    //
    //

    public void OnTimer(object sender, Event evt) {
      Globals.traindir.OnTimer();
    }

    //
    //	Customize user interface
    //


    public void OnZoomIn(object sender, Event evt) {
      Globals.set_zoom(true);
      int pg = m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0) {
        m_top.Selection = (pg);
        m_top.Refresh();
      }
    }

    //
    //
    //

    public void OnZoomOut(object sender, Event evt) {
      Globals.set_zoom(false);
      int pg = m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0) {
        m_top.Selection = (pg);
        m_top.Refresh();
      }
    }

    //
    //
    //

    public void OnShowCoord(object sender, Event evt) {
      //MenuBar pBar = this.MenuBar;
      //MenuItem pItem;

      //Menu dummyMenu;
      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_SHOW_COORD, ref dummyMenu)) != null) {
      //  Glboals.bShowCoord = pItem.Checked;
      //}
      ////	bShowCoord = !bShowCoord;
      //Globals.set_show_coord(Globals.bShowCoord);
      //Globals.invalidate_field();
      //Globals.repaint_all();
    }

    //
    //
    //

    public void OnShowLayout(object sender, Event evt) {
      int pg = m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0) {
        m_top.Selection = (pg);
        m_top.Refresh();
      }
    }

    //
    //
    //

    public void OnShowSchedule(object sender, Event evt) {
      int pg;
      NotebookManager parent;

      if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_TAB)
        parent = m_top;
      else if(m_timeTableLocation == TimeTableLocations.TIME_TABLE_SPLIT)
        parent = m_left;
      else // TODO: bring frame to top
        return;
      pg = parent.FindPage(wxPorting.L("Schedule"));
      if(pg >= 0) {
        parent.Selection = (pg);
        //	    parent.Refresh();
      }
    }

    //
    //
    //

    public void OnShowInfoPage(object sender, Event evt) {
      if(string.IsNullOrEmpty(Globals.info_page))
        return;
      String page = String.Copy(wxPorting.T("showinfo "));
      page += Globals.info_page;
      Globals.trainsim_cmd(page);
    }


    //
    //
    //

    public void OnShowStationsList(object sender, Event evt) {
#if true
      Globals.traindir.ShowStationsList();
#else
	int	pg = m_top.FindPage(wxPorting.T("stations"));
	HtmlView *htmlView;

	if(pg < 0) {
	    htmlView = new HtmlView(m_top);
	    m_top.AddPage(htmlView, wxPorting.T("stations"), true, -1);
	} else
	    htmlView = (HtmlView *)m_top.GetPage(pg);

	pHourLinks = 0;

	GetHtmlPage(wxPorting.T("http://reiseauskunft.bahn.de/bin/zuginfo.exe/en/338733/224970/999712/386945/80/"));

	wxFileName name = new wxFileName(wxPorting.T("C:/temp/vc.htm"));
	htmlView.LoadFile(name);
	wxHtmlContainerCell *root = htmlView.GetInternalRepresentation();
	TraverseNodes(root);

	HourLinks   *ph;
	for(ph = pHourLinks; ph; ph = ph.m_next) {
	    GetHtmlPage(ph.m_link.fn_str());
	    ParseStationPage(htmlView, wxPorting.T("C:/temp/tt.htm"));
/***/	    break;
	}
	wxFileName name1 = new wxFileName(wxPorting.T("C:/temp/tt.htm"));
	htmlView.LoadFile(name1);

	pg = m_top.FindPage(wxPorting.T("stations"));
	m_top.Selection = (pg);
#endif
    }

    //
    //
    //

    public void OnTimeTableSplit(object sender, Event evt) {
      //MoveTimeTableToSplit();
      //Globals.OnShowLayout(sender, evt);
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
      //MenuBar pBar = this.MenuBar;
      //MenuItem pItem;

      //Menu dummyMenu;
      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_TOOLBAR, ref dummyMenu))) {
      //  m_toolbar.Show(m_showToolbar = pItem.Checked);
      //  SendSizeEvent();
      //}
    }

    //
    //
    //

    public void OnStatusBar(object sender, Event evt) {
      //MenuBar pBar = this.MenuBar;
      //MenuItem pItem;
      //StatusBar pStatus;

      //Menu dummyMenu;
      //if((pItem = pBar.FindItem((int)MenuIDs.MENU_STATUSBAR, ref dummyMenu)) != null) {
      //  pStatus = this.StatusBar;
      //  pStatus.Show(m_showStatusbar = pItem.Checked);
      //  SendSizeEvent();
      //}
    }

    //
    //
    //

    public void OnRunButton(object sender, Event evt) {
      //bool pressed = m_running.GetValue();
      //Globals.traindir.OnStartStop();
    }

    //
    //
    //

    public void OnOpenFile(object sender, Event evt) {
      Globals.traindir.OnOpenFile();
    }

#if true
    //
    //
    //

    public void OnSpinUp(object sender, Event evt) {
      //Globals.trainsim_cmd(wxPorting.T("fast"));
      //evt.StopPropagation();
    }

    //
    //
    //

    public void OnSpinDown(object sender, Event evt) {
      //Globals.trainsim_cmd(wxPorting.T("slow"));
      //evt.StopPropagation();
    }
#endif

    //	OnSpin()
    //
    //	The if() below is required because on wxWidgets 2.8 on Linux
    //	only the EVT_SPINCTRL() evt is sent, thus we
    //	have to find out the desired direction (up/down)
    //	and whether we reached the upper/lower limit.
    //
#if false
public void OnSpin(object sender, Event evt)
{
	int x = evt.this.Position;
	if((x == time_mult && time_mult != 1) || x >= time_mult)
	    trainsim_cmd(wxPorting.T("fast"));
	else
	    trainsim_cmd(wxPorting.T("slow"));
	repaint_labels(true);
	evt.Skip();
}
#endif

    //
    //
    //

    public void OnRecent(object sender, Event evt) {
      Globals.traindir.OnRecent();
    }

    public void OnRestore(object sender, Event evt) {
      Globals.traindir.OnRestore();
    }

    public void OnSaveGame(object sender, Event evt) {
      Globals.traindir.OnSaveGame();
    }

    public void OnEdit(object sender, Event evt) {
      Globals.traindir.OnEdit();
    }

    public void OnNewTrain(object sender, Event evt) {
      Globals.traindir.OnNewTrain();
    }

    public void OnItinerary(object sender, Event evt) {
      Globals.traindir.OnItinerary();
    }

    public void OnSwitchboard(object sender, Event evt) {
      Globals.ShowSwitchboard();
    }

    public void OnSaveLayout(object sender, Event evt) {
      Globals.traindir.OnSaveLayout();
    }

    public void OnPreferences(object sender, Event evt) {
      Globals.traindir.OnPreferences();
    }

    public void OnEditSkin(object sender, Event evt) {
      TDSkin tmpSkin = new TDSkin();

      tmpSkin.name = Globals.wxStrdup(Globals.curSkin.name);
      tmpSkin.background = Globals.curSkin.background;
      tmpSkin.free_track = Globals.curSkin.free_track;
      tmpSkin.next = null;
      tmpSkin.occupied_track = Globals.curSkin.occupied_track;
      tmpSkin.outline = Globals.curSkin.outline;
      tmpSkin.reserved_shunting = Globals.curSkin.reserved_shunting;
      tmpSkin.reserved_track = Globals.curSkin.reserved_track;
      tmpSkin.working_track = Globals.curSkin.working_track;
      tmpSkin.text = Globals.curSkin.text;

      SkinColorsDialog skin = new SkinColorsDialog(Globals.traindir.m_frame, tmpSkin);

      if(skin.ShowModal() != ShowModalResult.OK)
        return;

      if(Globals.curSkin == Globals.defaultSkin) {
        tmpSkin.name = Globals.wxStrdup(wxPorting.T("Skin1"));
        tmpSkin.next = Globals.skin_list;
        Globals.skin_list = tmpSkin;
        Globals.curSkin = tmpSkin;
      } else {
        Globals.curSkin.background = tmpSkin.background;
        Globals.curSkin.free_track = tmpSkin.free_track;
        Globals.curSkin.occupied_track = tmpSkin.occupied_track;
        Globals.curSkin.outline = tmpSkin.outline;
        Globals.curSkin.reserved_shunting = tmpSkin.reserved_shunting;
        Globals.curSkin.reserved_track = tmpSkin.reserved_track;
        Globals.curSkin.working_track = tmpSkin.working_track;
        Globals.curSkin.text = tmpSkin.text;
        Globals.delete(tmpSkin);
      }
    }

    public void OnNewLayout(object sender, Event evt) {
      Globals.traindir.OnNewLayout();
    }

    public void OnInfo(object sender, Event evt) {
      Globals.traindir.OnInfo();
    }

    public void OnStartStop(object sender, Event evt) {
      Globals.traindir.OnStartStop();
    }

    public void OnGraph(object sender, Event evt) {
      Globals.traindir.OnGraph();
    }

    public void OnLateGraph(object sender, Event evt) {
      ShowLateGraph();
    }

    public void OnPlatformGraph(object sender, Event evt) {
      ShowPlatformGraph();
    }

    public void OnRestart(object sender, Event evt) {
      Globals.traindir.OnRestart();
    }

    public void OnFast(object sender, Event evt) {
      Globals.traindir.OnFast();
    }

    public void OnSlow(object sender, Event evt) {
      Globals.traindir.OnSlow();
    }

    public void OnSkip(object sender, Event evt) {
      Globals.traindir.OnSkipToNext();
    }

    public void OnStationSched(object sender, Event evt) {
      Globals.traindir.OnStationSched();
    }

    public void OnSetGreen(object sender, Event evt) {
      Globals.traindir.OnSetGreen();
    }

    public void OnSelectItin(object sender, Event evt) {
      if(Globals.itinKeyDialog == null)
        Globals.itinKeyDialog = new ItineraryKeyDialog(this);

      Globals.itinKeyDialog.ShowModal();
    }

    public void OnPerformance(object sender, Event evt) {
      Globals.traindir.OnPerformance();
    }

    public void ShowTrainInfoList(Train trn) {
      int pg = m_right.FindPage(wxPorting.L("Train Info"));
      if(pg >= 0)
        m_right.Selection = (pg);
      m_trainInfo.Update(trn);
    }

    public void ShowItinerary(bool show) {
      if(!show) {
        m_itineraryView.Show(false);
        m_left.RemovePage(m_itineraryView);
        return;
      }
      m_itineraryView.Show(true);
      m_left.AddPage(m_itineraryView, wxPorting.L("Itinerary"), true, -1);
    }

    public void ShowTools(bool show) {
      bool firstTime = false;

      if(!show) {
        if(m_toolsView == null)
          return;
        m_toolsView.Show(false);
        m_left.RemovePage(m_toolsView);
        return;
      }
      if(m_toolsView == null) {
        ToolsView pView = new ToolsView(m_left);
        m_toolsView = pView;
        firstTime = true;
      }
      m_toolsView.Show(true);
      m_left.AddPage(m_toolsView, wxPorting.L("Tools"), true, -1);

      int pg = m_left.FindPage(wxPorting.L("Tools"));
      if(pg >= 0) {
        m_left.Selection = (pg);
        m_left.Refresh();
      }
      if(firstTime)
        Globals.trainsim_cmd(wxPorting.T("selecttool 1,0"));
    }

    public void ShowHtml(String name, String page) {
      int pg = m_top.FindPage(name);
      HtmlView htmlView;

      if(pg < 0) {
        htmlView = new HtmlView(m_top);
        m_top.AddPage(htmlView, name, true, -1);
      } else
        htmlView = (HtmlView)m_top.GetPage(pg);
      htmlView.SetPage(page);
      pg = m_top.FindPage(name);
      m_top.Selection = (pg);
    }

    public void ShowGraph() {
      if(m_graphView == null) {
        GraphView pView = new GraphView(m_top);
        m_graphView = pView;
      }
      m_graphView.Show(true);

      int pg = m_top.FindPage(wxPorting.L("Graph"));
      if(pg >= 0)
        m_top.Selection = (pg);
      else
        m_top.AddPage(m_graphView, wxPorting.L("Graph"), true, -1);
      m_graphView.Refresh();
      m_top.Refresh();
    }

    public void ShowLateGraph() {
      if(m_lateGraphView == null) {
        LateGraphView pView = new LateGraphView(m_top);
        m_lateGraphView = pView;
      }
      m_lateGraphView.Show(true);

      int pg = m_top.FindPage(wxPorting.L("Late Graph"));
      if(pg >= 0)
        m_top.Selection = (pg);
      else
        m_top.AddPage(m_lateGraphView, wxPorting.L("Late Graph"), true, -1);
      m_lateGraphView.Refresh();
      m_top.Refresh();
    }

    public void ShowPlatformGraph() {
      if(m_platformGraphView == null) {
        PlatformGraphView pView = new PlatformGraphView(m_top);
        m_platformGraphView = pView;
      }
      m_platformGraphView.Show(true);

      int pg = m_top.FindPage(wxPorting.L("Platform Graph"));
      if(pg >= 0)
        m_top.Selection = (pg);
      else
        m_top.AddPage(m_platformGraphView, wxPorting.L("Platform Graph"), true, -1);
      m_platformGraphView.Refresh();
      m_top.Refresh();
    }

    public void OnChar(object sender, Event evt) {
      if(((KeyEvent)evt).KeyCode == 9) {
        return;
      }
      evt.Skip();
    }


  }
  public class HourLinks {
    public HourLinks m_next;
    public String m_hour;
    public String m_station;
    public String m_link;
  }
  public static partial class Globals {

    public static string anchor;
    public static string htmltext;


    public static HourLinks pHourLinks;

    //
    //
    //

    public static void TraverseNodes(HtmlCell node) {
      HtmlCell child;

      if(node == null) {
        return;
      }
      String txt = node.Text; // .Text; // .ConvertToText(null);
      htmltext = string.Copy(txt);
      HtmlLinkInfo link = node.Link;

      anchor = "";
      if(link != null) {
        anchor = string.Copy(link.Href);
      }
      if(htmltext[0] != null) {
        if(htmltext[2] == ':' && Globals.wxStrlen(htmltext) == 5 && wxPorting.wxIsdigit(htmltext[1]) && anchor.Length > 0) {
          HourLinks p = new HourLinks();
          p.m_next = pHourLinks;
          pHourLinks = p;
          p.m_link = anchor;
          p.m_hour = htmltext;
        }
      }
      for(child = node.FirstChild; child != null; ) {
        TraverseNodes(child);
        child = child.Next;
      }
    }

    //
    //
    //

    public static int GetHtmlPage(String url) {
#if false
	String pc;
	String pc1;

	if(strncmp(url, wxPorting.T("http://"), 7))
	    return 0;

	pc = url + 7;
	for(pc1 = anchor; *pc && *pc != '/'; *pc1++ = *pc++);
	*pc1 = 0;

	wxHTTP	http;
	http.Connect(anchor/*"reiseauskunft.bahn.de"*/, 80);
	wxInputStream *inp = http.GetInputStream(pc);//"/bin/zuginfo.exe/en/338733/224970/999712/386945/80/");

	FILE	*fp;
	int	ch;
	fp = fopen("C:/temp/tt.htm", "w");
	while(!inp.Eof()) {
	    ch = inp.GetC();
	    fputc(ch, fp);
	}
	fclose(fp);
#endif
      return 0;
    }

    public static int m_TrainPageStatus = 0;
    //
    //
    //

    public static void GetListOfTrains(HtmlCell node) {
      HtmlCell child;

      if(node == null) {
        return;
      }
      String txt = node.Text; // .ConvertToText(null);
      htmltext = string.Copy(txt);
      HtmlLinkInfo link = node.Link;

      anchor = "";
      if(link != null) {
        anchor = string.Copy(link.Href);
      }
      if(htmltext[0] != null) {
        switch(m_TrainPageStatus) {
          case 5:
            return;

          case 4:
            if(Globals.wxStrcmp(htmltext, wxPorting.T("shown")) == 0) {
              m_TrainPageStatus = 5;
              break;
            }
            goto st2;

          case 3:
            if(Globals.wxStrcmp(htmltext, wxPorting.T("stops")) == 0) {
              m_TrainPageStatus = 4;
              break;
            }
          st2:
            m_TrainPageStatus = 2;
          // fall through
          goto case 2;

          case 2:
          if(Globals.wxStrcmp(htmltext, wxPorting.T("All")) == 0) {
            m_TrainPageStatus = 3;
            break;
          }
#if false
		if(0 && htmltext[2] == ':' && Globals.wxStrlen(htmltext) == 5 && wxIsdigit(htmltext[1]) && anchor[0]) {
		    HourLinks *p = new HourLinks;
		    p.m_next = pHourLinks;
		    pHourLinks = p;
		    p.m_link = anchor;
		    p.m_hour = htmltext;
		}
#endif
          break;


          case 1:
          if(Globals.wxStrcmp(htmltext, wxPorting.T("Train")) == 0) {
            m_TrainPageStatus = 2;
            break;
          }

          m_TrainPageStatus = 0;
          // fall through
          goto case 0;

          case 0:
          if(Globals.wxStrcmp(htmltext, wxPorting.T("Time ")) == 0)
            m_TrainPageStatus = 1;
          break;
        }
      }
      for(child = node.FirstChild; child != null; ) {
        GetListOfTrains(child);
        child = child.Next;
      }
    }

    //
    //
    //

    public static void ParseStationPage(HtmlView htmlView, String fname) {
      wxFileName name = new wxFileName(fname);
      htmlView.LoadFile(name);
      HtmlContainerCell root = htmlView.InternalRepresentation;
      m_TrainPageStatus = 0;
      GetListOfTrains(root);
    }

    //
    //
    //

    public static String fileName(String p) {
      throw new NotImplementedException();
      //String p1 = p + Globals.wxStrlen(p);

      //while(p1 > p) {
      //  if(p1[0] == ':' || p1[0] == '\\' || p1[0] == '/')
      //    return p1.Substring(1);
      //  --p1;
      //}
      //return p1;
    }

    //
    //
    //

    public static void repaint_labels() {
      repaint_labels(false);
    }

    public static void repaint_labels(bool force) {
      //int i;

      //for(i = 0; i < 8; ++i)
      //  if(//labelList[i].handle &&
      //force ||
      //(Globals.wxStrcmp(labelList[i].text, labelList[i].oldtext) != 0)) {
      //    if(i == 7)
      //      Globals.traindir.m_frame.m_statusText.Label = (labelList[i].text);
      //    else if(i == 2)
      //      Globals.traindir.m_frame.m_alertText.Label = (labelList[i].text);
      //    else if(i == 0) {
      //      String buff = labelList[i].text;
      //      size_t p;

      //      p = buff.find(wxPorting.T('('));
      //      if(p == String.npos)
      //        p = buff.find(wxPorting.T('x'));
      //      if(p != String.npos) {
      //        String buff1;
      //        buff1 = String.Format(wxPorting.T("x %d"), time_mult);
      //        Globals.traindir.m_frame.m_speed.Value = (buff1);
      //        Globals.traindir.m_frame.m_speedArrows.Value = (cur_time_mult);
      //      }
      //      Globals.traindir.m_frame.m_clock.Label = (buff.Substring(0, p));
      //    } else if(i < Configuration.NSTATUSBOXES)
      //      Globals.traindir.m_frame.SetStatusText(labelList[i].text, i);
      //    labelList[i].oldtext = string.Copy(labelList[i].text);
      //    labelList[i].oldtext = labelList[i].oldtext.Substring(labelList[i].oldtext.Length - 1);
      //  }
      //String title;

      //if(Globals.traindir.m_frame.m_showToolbar) {
      //  title += program_name;
      //  title += wxPorting.T(" - ");
      //  title += fileName(current_project);
      //  if(Globals.layout_modified)
      //    title += wxPorting.T(" *");
      //  title += wxPorting.T(" - ");
      //  title += labelList[0].text;
      //  title += wxPorting.T(" - ");
      //  title += total_points_msg;
      //} else {
      //  title += labelList[0].text;
      //  title += wxPorting.T(" - ");
      //  title += total_points_msg;
      //  title += wxPorting.T(" - ");
      //  title += labelList[7].text;
      //}
      //Globals.traindir.m_frame.Title = title;
    }


    public static void select_tool(int i) {
      current_tool = i;
      tools_grid.Clear();
      Globals.traindir.m_frame.m_toolsView.Refresh();
    }

    public static void show_table()	// originally to show start/stop,fast/slow buttons and labels
        {
    }

    public static void hide_table()	// originally to hide start/stop,fast/slow buttons and labels
        {
    }

    public static void show_tooltable()	// show editing tools
        {
      Globals.traindir.m_frame.ShowTools(true);
    }

    public static void hide_tooltable()	// hide editing tools
        {
      Globals.traindir.m_frame.ShowTools(false);
    }

    public static void show_itinerary()	// show itinerary table
        {
      Globals.traindir.m_frame.ShowItinerary(true);
      FillItineraryTable();
    }

    public static void hide_itinerary()	// hide itinerary table
        {
      Globals.traindir.m_frame.ShowItinerary(false);
    }

    public static int create_tgraph() {
      Globals.traindir.m_frame.ShowGraph();
      return 0;
    }

    public static int ask_number(String title, String question) {
      TextEntryDialog diag = new TextEntryDialog(Globals.traindir.m_frame, wxPorting.LV(question), wxPorting.LV(title));

      if(diag.ShowModal() != ShowModalResult.OK)
        return -1;
      String result = diag.Value;
      return Globals.wxAtoi(result);
    }

    public static void alert_dialog(String msg) {
      String message = string.Copy(msg);
      wx.MessageDialog.MessageBox(message, wxPorting.T("Info"));
    }
  }
}