using System;
using System.Collections.Generic;
using System.Text;
using wx;
using wx.Archive;
using System.IO;

namespace TrainDirNET {

  //	scripting support

  public enum NodeOp {
    Equal,			// bool if left == right OR assignment
    NotEqual,		// bool if left != right
    Less,			// bool if left < right
    Greater,		// bool if left > right
    LessEqual,		// bool if left <= right
    GreaterEqual,		// bool if left >= right
    And,			// bool if left && right
    Or,			// bool if left || right
    Dot,			// result is left.value
    TrackRef,		// Track(x, y)   OR  Track(value)
    SwitchRef,		// Switch(x, y)  OR  Switch(value)
    SignalRef,		// Signal(x, y)  OR  Signal(value)
    NextSignalRef,		// Signal,
    NextApproachRef,	// Signal,
    LinkedRef,              // Image to Switch
    TrainRef,
    Addr,			// Ref + Dot
    Random,			// return 0..100
    Time,			// current time, in decimal hhmm
    None,
    Bool,
    Number,
    String
  };

  public enum SegDir {
    SEG_N = 0,
    SEG_NE = 1,
    SEG_E = 2,
    SEG_SE = 3,
    SEG_S = 4,
    SEG_SW = 5,
    SEG_W = 6,
    SEG_NW = 7,
    SEG_END = 8
  }

  public class TextList {
    public TextList next; // struct _textlist *next;
    public string txt;
  }

  public enum fieldcolor {
    COL_BACKGROUND = 0,
    COL_TRACK = 1,
    COL_GRAPHBG = 2,
    COL_TRAIN1 = 3,
    COL_TRAIN2 = 4,
    COL_TRAIN3 = 5,
    COL_TRAIN4 = 6,
    COL_TRAIN5 = 7,
    COL_TRAIN6 = 8,
    COL_TRAIN7 = 9,
    COL_TRAIN8 = 10,
    COL_TRAIN9 = 11,
    COL_TRAIN10 = 12,
    MAXFIELDCOL
  }

  public class switin {
    public int x, y;		/* coordinate of the switch */
    public int switched;	/* whether to automatically throw the switch */
    public int oldsw;		/* old status */
  }

  public enum trkstat {
    ST_FREE = 0,
    ST_BUSY = 1,
    ST_READY = 2,
    ST_WORK = 3,
    ST_GREEN = 4,
    ST_RED = 5,
    ST_WHITE = 6
  }

  [Flags]
  public enum TFLG {
    TFLG_TURNED = 1,		/* train changed direction */
    TFLG_THROWN = 2,		/* switch was thrown */
    TFLG_WAITED = 4,		/* train waited at signal */
    TFLG_MERGING = 8,		/* train is shunting to merge with another train */
    TFLG_STRANDED = 16,		/* material left on track without engine */
    TFLG_WAITINGMERGE = 32,		/* another train is approaching us to be merged */
    TFLG_ENTEREDLATE = 64,		/* don't penalize for late arrivals */
    TFLG_GOTDELAYATSTOP = 128,		/* only select delay (or none) once */
    TFLG_SETLATEARRIVAL = 256,		/* only compute late arrival once */
    TFLG_SWAPHEADTAIL = 512,		/* swap loco and caboose icons */
    TFLG_DONTSTOPSHUNTERS = 1024,      // don't stop here if train is shunting
  }

  /*  ---------------------------------------------------------------------------- */
  /*  standard IDs */
  /*  ---------------------------------------------------------------------------- */

  /*  Standard menu IDs */
  public enum MenuIDs2 : int {
    /* no id matches this one when compared to it */
    wxID_NONE = -3,

    /*  id for a separator line in the menu (invalid for normal item) */
    wxID_SEPARATOR = -2,

    /* any id: means that we don't care about the id, whether when installing
     * an event handler or when creating a new window */
    wxID_ANY = -1,


    /* all predefined ids are between wxID_LOWEST and wxID_HIGHEST */
    wxID_LOWEST = 4999,

    wxID_OPEN,
    wxID_CLOSE,
    wxID_NEW,
    wxID_SAVE,
    wxID_SAVEAS,
    wxID_REVERT,
    wxID_EXIT,
    wxID_UNDO,
    wxID_REDO,
    wxID_HELP,
    wxID_PRINT,
    wxID_PRINT_SETUP,
    wxID_PAGE_SETUP,
    wxID_PREVIEW,
    wxID_ABOUT,
    wxID_HELP_CONTENTS,
    wxID_HELP_INDEX,
    wxID_HELP_SEARCH,
    wxID_HELP_COMMANDS,
    wxID_HELP_PROCEDURES,
    wxID_HELP_CONTEXT,
    wxID_CLOSE_ALL,
    wxID_PREFERENCES,

    wxID_EDIT = 5030,
    wxID_CUT,
    wxID_COPY,
    wxID_PASTE,
    wxID_CLEAR,
    wxID_FIND,
    wxID_DUPLICATE,
    wxID_SELECTALL,
    wxID_DELETE,
    wxID_REPLACE,
    wxID_REPLACE_ALL,
    wxID_PROPERTIES,

    wxID_VIEW_DETAILS,
    wxID_VIEW_LARGEICONS,
    wxID_VIEW_SMALLICONS,
    wxID_VIEW_LIST,
    wxID_VIEW_SORTDATE,
    wxID_VIEW_SORTNAME,
    wxID_VIEW_SORTSIZE,
    wxID_VIEW_SORTTYPE,

    wxID_FILE = 5050,
    wxID_FILE1,
    wxID_FILE2,
    wxID_FILE3,
    wxID_FILE4,
    wxID_FILE5,
    wxID_FILE6,
    wxID_FILE7,
    wxID_FILE8,
    wxID_FILE9,

    /*  Standard button and menu IDs */
    wxID_OK = 5100,
    wxID_CANCEL,
    wxID_APPLY,
    wxID_YES,
    wxID_NO,
    wxID_STATIC,
    wxID_FORWARD,
    wxID_BACKWARD,
    wxID_DEFAULT,
    wxID_MORE,
    wxID_SETUP,
    wxID_RESET,
    wxID_CONTEXT_HELP,
    wxID_YESTOALL,
    wxID_NOTOALL,
    wxID_ABORT,
    wxID_RETRY,
    wxID_IGNORE,
    wxID_ADD,
    wxID_REMOVE,

    wxID_UP,
    wxID_DOWN,
    wxID_HOME,
    wxID_REFRESH,
    wxID_STOP,
    wxID_INDEX,

    wxID_BOLD,
    wxID_ITALIC,
    wxID_JUSTIFY_CENTER,
    wxID_JUSTIFY_FILL,
    wxID_JUSTIFY_RIGHT,
    wxID_JUSTIFY_LEFT,
    wxID_UNDERLINE,
    wxID_INDENT,
    wxID_UNINDENT,
    wxID_ZOOM_100,
    wxID_ZOOM_FIT,
    wxID_ZOOM_IN,
    wxID_ZOOM_OUT,
    wxID_UNDELETE,
    wxID_REVERT_TO_SAVED,

    /*  System menu IDs (used by wxUniv): */
    wxID_SYSTEM_MENU = 5200,
    wxID_CLOSE_FRAME,
    wxID_MOVE_FRAME,
    wxID_RESIZE_FRAME,
    wxID_MAXIMIZE_FRAME,
    wxID_ICONIZE_FRAME,
    wxID_RESTORE_FRAME,

    /*  IDs used by generic file dialog (13 consecutive starting from this value) */
    wxID_FILEDLGG = 5900,

    wxID_HIGHEST = 5999
  };

  public enum MenuIDs {
    MENU_TIME_SPLIT = 100,
    MENU_TIME_TAB,
    MENU_TIME_FRAME,

    MENU_SHOW_LAYOUT,
    MENU_SHOW_SCHEDULE,
    MENU_INFO_PAGE,

    MENU_ZOOMIN,
    MENU_ZOOMOUT,

    MENU_SHOW_COORD,
    MENU_TOOLBAR,
    MENU_STATUSBAR,
    MENU_COPYRIGHT,
    MENU_LANGUAGE,

    MENU_RECENT,
    MENU_RESTORE,
    MENU_EDIT,
    MENU_NEW_TRAIN,
    MENU_ITINERARY,
    MENU_SWITCHBOARD,
    MENU_SAVE_LAYOUT,
    MENU_PREFERENCES,
    MENU_EDIT_SKIN,
    MENU_NEW_LAYOUT,
    MENU_INFO,
    MENU_STATIONS_LIST,

    MENU_START,
    MENU_GRAPH,
    MENU_LATEGRAPH,
    MENU_PLATFORMGRAPH,
    MENU_RESTART,
    MENU_FAST,
    MENU_SLOW,
    MENU_SKIP,
    MENU_STATION_SCHED,
    MENU_SETGREEN,
    MENU_SELECT_ITIN,
    MENU_PERFORMANCE,

    MENU_ITIN_DELETE,
    MENU_ITIN_PROPERTIES,
    MENU_ITIN_SAVE,

    MENU_ALERT_CLEAR,
    MENU_ALERT_SAVE,

    MENU_HTML_PRINTSETUP,
    MENU_HTML_PREVIEW,
    MENU_HTML_PRINT,

    MENU_SCHED_SHOW_CANCELED,
    MENU_SCHED_SHOW_ARRIVED,
    MENU_SCHED_ASSIGN,
    MENU_SCHED_TRACK_FIRST,
    MENU_SCHED_TRACK_LAST,
    MENU_SCHED_PRINT_TRAIN,

    MENU_COORD_DEL_1,
    MENU_COORD_DEL_N,
    MENU_COORD_INS_1,
    MENU_COORD_INS_N,

    ID_RADIOBOX,
    ID_CHECKBOX,
    ID_LIST,
    ID_NOTEBOOK_TOP,
    ID_NOTEBOOK_LEFT,
    ID_NOTEBOOK_RIGHT,

    ID_SPEEDTEXT,
    ID_SPIN,
    ID_RUN,
    ID_ASSIGN,
    ID_SHUNT,
    ID_SPLIT,
    ID_PROPERTIES,
    ID_PRINT,
    ID_ASSIGNSHUNT,
    ID_REVERSEASSIGN,
    ID_SCRIPT,

    ID_CHOICE,

    ID_ITINSELECT,
    ID_ITINCLEAR,

    TIMER_ID = 1000,

    FIRST_CANVAS = 1100,
    LAST_CANVAS = 1199,

    FIRST_TTABLE = 1200,
    LAST_TTABLE = 1299,

    FIRST_HTML = 1300,
    LAST_HTML = 1399
  };

  public enum trktype {
    NOTRACK = 0,
    TRACK = 1,
    SWITCH = 2,
    PLATFORM = 3,
    TSIGNAL = 4,
    TRAIN = 5,
    TEXT = 6,
    LINK = 7,		/* not a real track - for the editor */
    IMAGE = 8,		/* for stations, bridges etc. */
    MACRO = 9,		/* editor only - not to be saved */
    ITIN = 10,		/* itinerary */
    TRIGGER = 11,		/* trigger point linked to track */
    MOVER = 12,		/* not a real track - for the editor */
    POWERTOOL = 13          /* not a real track - for the editor */
  }
  public class Configuration {
    public const string __DATE__ = "__DATE__";
    public const char PLATFORM_SEP = '@';

    public const int MAX_OLD_SIMULATIONS = 16;
    public const int NSTATUSBOXES = 5;
    public const int MAX_CONFIG_SECT = 40;
    public const int MAX_DELAY = 10;
    public const int NTTYPES = 10;
    public const int MAX_FLASHING_ICONS = 4;

    public const int MAXNOTES = 5;

    public const int HGRID = 9;
    public const int VGRID = 9;

    public const int HCOORDBAR = 20;
    public const int VCOORDBAR = 30;

    public const int XNCELLS = 440;	    // 3.7n - was 226
    public const int YNCELLS = 228;	    // 3.7o - was 114

    public static int XMAX { get { return ((XNCELLS * HGRID) + HCOORDBAR) /* 440*9 */ ; } }
    public static int YMAX { get { return ((YNCELLS * VGRID) + VCOORDBAR) /* 1026 */ ; } }




    public static int NUMTTABLES { get { return (MenuIDs.LAST_TTABLE - MenuIDs.FIRST_TTABLE + 1); } }
    public static int NUMCANVASES { get { return (MenuIDs.LAST_CANVAS - MenuIDs.FIRST_CANVAS + 1); } }
    public static int NUMHTMLS { get { return (MenuIDs.LAST_HTML - MenuIDs.FIRST_HTML + 1); } }


    public static int STATION_WIDTH = 140;
    public static int KM_WIDTH = 5;
    public static int HEADER_HEIGHT = 20;
    public static int MAXWIDTH { get { return (2 * 60 * 24 + STATION_WIDTH + KM_WIDTH); } }
    public static int Y_DIST = 20;


    public static int MAXNESTING = 20;
  }

  public class wxPorting {
    // Porting of wxPorting.T
    public static char T(char text) {
      return text;
    }

    public static string T(string text) {
      return text;
    }

    public static string L(string text) {
      /// TODO
      // Replace with localize(wxPorting.T(text))
      return text;
    }

    public static string LV(string text) {
      /// TODO
      // Replace with localize(text)
      return text;
    }

    public static ShowModalResult MessageBox(string message) {
      return MessageBox(message, GlobalVariables.program_name, WindowStyles.DIALOG_OK);
    }

    public static ShowModalResult MessageBox(string message, string caption, WindowStyles style) {
      return MessageBox(message, caption, style);
    }

    public static string Strdup(string text) {
      return string.Copy(text);
    }


    public static int Strtol(string buffer, out int i, int p) {
      if(p != 10)
        throw new NotImplementedException();

      int result = 0;

      for(i = 0; (i < buffer.Length && buffer[i] >= '0' && buffer[i] <= '9'); i++) {
        result = result * 10 + (int)(buffer[i] - '0');
      }

      return result;
    }

    public static T[] realloc<T>(T[] oldArray, int newSize) {
      T[] result = new T[newSize];
      int how = Math.Min(oldArray.Length, newSize);
      Array.Copy(oldArray, 0, result, 0, how);
      return result;
    }
  }

  public enum TimaTableLocation {
    TIME_TABLE_NONE = 0,
    TIME_TABLE_TAB = 1,
    TIME_TABLE_SPLIT = 2,
    TIME_TABLE_FRAME = 3
  };

  public partial class GlobalFunctions {
    public static int myAtoi(string p) {
      int i = 0;
      int val = 0;
      while(i < p.Length && (int)p[i] >= (int)'0' && (int)p[i] <= (int)'9') {
        val = (val * 10) + ((int)p[i] - (int)'0');
        i++;
      }

      return val;
    }

    public static string format_time(long tim) {
      // !Rask Ingemann Lambersten - added seconds
      return String.Format(wxPorting.T("{0:D3}:{1:D2}:{2:D2} "), (tim / 3600) % 24, (tim / 60) % 60, tim % 60);
    }


    public static Track findStationNamed(string name) {
      Track t;
      int p;
      int l;

      l = name.Length;
      p = name.IndexOf(Configuration.PLATFORM_SEP);
      if(p >= 0)
        l = p;
      for(t = GlobalVariables.layout; t != null; t = t.next) {
        if(String.IsNullOrEmpty(t.station) == false)
          continue;
        if(t.type == trktype.TRACK && t.isstation && name.Substring(0, l).Equals(t.station)) {
          if(p >= 0) // if(!t.station[l] || t.station[l] == Configuration.PLATFORM_SEP)
            return t;
        }
        if(t.type == trktype.TEXT && name.Equals(t.station) &&
          ((t.wlinkx != 0 && t.wlinky != 0) || (t.elinkx != 0 && t.elinky != 0)))
          return t;
        if(t.type == trktype.SWITCH && name.Equals(t.station))
          return t;
      }
      return null;
    }

    public static TrainStop findStop(Train trn, Track trk) {
      TrainStop stp;

      if(trk == null || string.IsNullOrEmpty(trk.station))
        return null;
      for(stp = trn.stops; stp != null; stp = stp.next)
        if(sameStation(stp.station, trk.station))
          break;
      return stp;
    }

    public static bool sameStation(string s1, string s2) {
      int i1, i2;
      i1 = s1.IndexOf(Configuration.PLATFORM_SEP);
      i2 = s2.IndexOf(Configuration.PLATFORM_SEP);

      i1 = i1 >= 0 ? i1 : s1.Length;
      i2 = i2 >= 0 ? i2 : s2.Length;

      return s1.Substring(0, i1).Equals(s2.Substring(0, i2));
    }

    public static bool ignore_train(Train tr) {
      if(tr.isExternal)
        return true;

      if(GlobalVariables.show_arrived)
        return false;

      if(tr.status != trainstat.train_ARRIVED)
        return false;

      if(string.IsNullOrEmpty(tr.stock))
        return true;

      Train t1 = findTrainNamed(tr.stock);
      return t1 != null && t1.status != trainstat.train_READY;
    }

    public static Train findTrainNamed(string name) {
      Train t;

      for(t = GlobalVariables.schedule; t != null; t = t.next)
        if(name.Equals(t.name))
          return t;
      return null;
    }

    public static Action<Train> assign_dialog;


    public static void ShowTrainInfo(Train trn) {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      train_print(trn, page);
      GlobalVariables.traindir.m_frame.ShowHtml(wxPorting.L("Train Info"), page.content);
    }

    public static void ShowTrainInfoDialog(Train trn) {
      /// TODO
      // TrainInfoDialog	diag(traindir.m_frame);
      // diag.ShowModal(trn);
    }

    public static void do_command(string cmd, bool sendToClients) {
      //  const wxChar	*p;
      //  Train	*t;
      //  Track	*trk;
      int x, y, fl;
      //  wxChar	buff[1024];

      //  if(!wxStrncmp(cmd, wxPorting.T("log"), 3)) {
      //      if(!flog.IsOpened()) {
      //    if(!(flog.Open(wxPorting.T("log"), wxPorting.T("w"))))
      //        do_alert(wxPorting.L("Cannot create log file."));
      //    return;
      //      }
      //      flog.Close();
      //      return;
      //  }
      if(false) {
        //  if(!wxStrncmp(cmd, wxPorting.T("replay"), 6)) {
        //      for(p = cmd + 6; *p == ' ' || *p == '\t'; ++p);
        //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s.log"), p);
        //      if(!(frply = new TDFile(buff))) {
        //    do_alert(wxPorting.L("Cannot read log file."));
        //    return;
        //      }
        //      /* replay commands are issued whenever the clock is updated */
        //      return;
        //  }
        //  if(flog.IsOpened())
        //      flog.Write(wxString::Format(wxPorting.T("%ld,%s\n"), current_time, cmd));
        //  wxSnprintf(buff, sizeof(buff), wxPorting.T("%ld,%s\n"), current_time, cmd);
        //  if(sendToClients)
        //      send_msg(buff);
        //  if(!wxStrncmp(cmd, wxPorting.T("quit"), 4))
        //      main_quit_cmd();
        //  else if(!wxStrncmp(cmd, wxPorting.T("about"), 5)) {
        //      about_dialog();
        //  } else if(!wxStrcmp(cmd, wxPorting.T("edititinerary"))) {
        //      itinerary_cmd();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("edit"), 4)) {
        //      if(running)
        //    start_stop();
        //      edit_cmd();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("noedit"), 6))
        //      noedit_cmd();
        //  else if(!wxStrncmp(cmd, wxPorting.T("stationsched"), 12))
        //      station_sched_dialog(NULL);
        //  else if(!wxStrncmp(cmd, wxPorting.T("paths"), 5))
        //      create_path_window();
        //  else if(!wxStrncmp(cmd, wxPorting.T("fast"), 4)) {
        //      if(time_mults[cur_time_mult + 1] != -1)
        //    time_mult = time_mults[++cur_time_mult];
        //      update_labels();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("slow"), 4)) {
        //      if(cur_time_mult > 0) {
        //    time_mult = time_mults[--cur_time_mult];
        //    update_labels();
        //      }
        //  } else if(!wxStrncmp(cmd, wxPorting.T("t0"), 2)) {
        //      if(cont(wxPorting.L("Do you want to restart the simulation?")) == ANSWER_YES) {
        //    if(!all_trains_everyday(schedule))
        //        select_day_dialog();
        //    clear_delays();
        //    fill_schedule(schedule, 0);
        //          wxSnprintf(status_line, sizeof(status_line)/sizeof(wxChar), wxPorting.L("Simulation restarted."));
        //          trainsim_init();
        //    invalidate_field();
        //    update_button(wxPorting.T("stop"), wxPorting.L("Stop"));
        //    repaint_all();
        //      }
        //  } else if(!wxStrncmp(cmd, wxPorting.T("speeds"), 6)) {
        //      show_speeds = !show_speeds;
        //      invalidate_field();
        //      repaint_all();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("traditional"), 6)) {
        //      signal_traditional = !signal_traditional;
        //      invalidate_field();
        //      repaint_all();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("graph"), 6)) {
        //      create_tgraph();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("blocks"), 6)) {
        //      GlobalVariables.show_blocks = !GlobalVariables.show_blocks;
        //      invalidate_field();
        //      repaint_all();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("alert"), 5)) {
        //      beep_on_alert = !beep_on_alert;
        //  } else if(!wxStrncmp(cmd, wxPorting.T("sched"), 5)) {
        //      create_schedule(0);
      } else if(cmd.StartsWith(wxPorting.T("run"))) {
        start_stop();
        GlobalFunctions.update_button(wxPorting.T("run"), GlobalVariables.running ? wxPorting.L("Stop") : wxPorting.L("Start"));
        //  } else if(!wxStrncmp(cmd, wxPorting.T("newtrain"), 8)) {
        //      create_train();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("greensigs"), 9)) {
        //      open_all_signals();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("shunt"), 5)) {
        //      cmd += 5;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      if(!(t = findTrainNamed(cmd)))
        //    return;
        //      shunt_train(t);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("traininfopage"), 13)) {
        //      cmd += 13;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      if(!(t = findTrainNamed(cmd)))
        //    return;
        //      ShowTrainInfo(t);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("traininfo"), 9)) {
        //      cmd += 9;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      if(!(t = findTrainNamed(cmd)))
        //    return;
        //      train_info_dialog(t);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("decelerate"), 10)) {
        //      long    val;
        //      wxChar *end;

        //      cmd += 10;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      val = wxPorting.Strtol(cmd, &end, 0);
        //      while(*end == ' ' || *end == '\t') ++end;
        //      if(!(t = findTrainNamed(end)))
        //    return;
        //      decelerate_train(t, val);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("accelerate"), 10)) {
        //      long    val;
        //      wxChar *end;

        //      cmd += 10;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      val = wxPorting.Strtol(cmd, &end, 0);
        //      while(*end == ' ' || *end == '\t') ++end;
        //      if(!(t = findTrainNamed(end)))
        //    return;
        //      accelerate_train(t, val);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("stationinfopage"), 15)) {
        //      cmd += 15;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      ShowStationSchedule(cmd, false);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("savestationinfopage"), 19)) {
        //      cmd += 19;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      ShowStationSchedule(cmd, true);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("stationinfo"), 11)) {
        //      cmd += 11;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      station_sched_dialog(cmd);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("reverse"), 7)) {
        //      cmd += 7;
        //      while(*cmd == ' ' || *cmd == '\t') ++cmd;
        //      if(!(t = findTrainNamed(cmd)))
        //    return;
        //      reverse_train(t);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("new"), 3)) {
        //      if(running)
        //    start_stop();
        //      if(layout_modified) {
        //    if(ask_to_save_layout() < 0)	// cancel selected
        //        return;
        //      }
        //      init_all();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("save "), 5)) {
        //      if(save_layout(cmd + 5, layout))
        //    wxSnprintf(status_line, sizeof(status_line)/sizeof(wxChar), wxPorting.T("%s '%s.trk'."), wxPorting.L("Layout saved in file"), cmd + 5);
        //      repaint_labels();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("savegame "), 9)) {
        //      if(save_game(cmd + 9))
        //    wxSnprintf(status_line, sizeof(status_line)/sizeof(wxChar), wxPorting.T("%s '%s.sav'."), wxPorting.L("Game status saved in file"), cmd + 9);
        //      repaint_labels();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("restore "), 8)) {
        //      if(layout_modified) {
        //    if(ask_to_save_layout() < 0)	// cancel selected
        //        return;
        //      }
        //      restore_game(cmd + 8);
        //      invalidate_field();
        //      repaint_all();
        //      fill_schedule(schedule, 0);
        //      update_labels();
      } else if(cmd.StartsWith(wxPorting.T("open")) || cmd.StartsWith(wxPorting.T("load"))) {
        fl = (cmd[0] == 'o') ? 1 : 0;		/* open vs. load */
        cmd = cmd.Substring(4);
        load_new_scenario(cmd, fl);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("puzzle"), 6)) {
        //      cmd += 6;
        //      load_new_scenario(cmd, 2);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("click"), 5)) {
        //      for(cmd += 5; *cmd == ' ' || *cmd == '\t'; ++cmd);
        //      if(*cmd >= '0' && *cmd <= '9') {
        //    wxChar *end;
        //    x = wxPorting.Strtol(cmd, &end, 10);
        //    if(isalpha(*end))
        //        goto isItin;
        //    if(*end == ',') ++end;
        //    y = wxPorting.Strtol(end, &end, 10);
        //      } else {
        //isItin:
        //    if(!(trk = findItineraryNamed(cmd)))
        //        return;		/* impossible ? */
        //    x = trk.x;
        //    y = trk.y;
        //      }
        //      track_selected(x, y);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("rclick"), 6)) {
        //      for(cmd += 6; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('\t'); ++cmd);
        //      if(*cmd >= wxPorting.T('0') && *cmd <= wxPorting.T('9')) {
        //    wxChar *end;
        //    x = wxPorting.Strtol(cmd, &end, 10);
        //    if(*end == wxPorting.T(',')) ++end;
        //    y = wxPorting.Strtol(end, &end, 10);
        //      } else {
        //    if(!(trk = findItineraryNamed(cmd)))
        //        return;		/* impossible ? */
        //    x = trk.x;
        //    y = trk.y;
        //      }
        //      track_selected1(x, y);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("ctrlclick"), 9)) {
        //      for(cmd += 9; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('\t'); ++cmd);
        //      if(*cmd >= '0' && *cmd <= '9') {
        //    wxChar *end;
        //    x = wxPorting.Strtol(cmd, &end, 10);
        //    if(*end == wxPorting.T(',')) ++end;
        //    y = wxPorting.Strtol(end, &end, 10);
        //      } else {
        //    if(!(trk = findItineraryNamed(cmd)))
        //        return;		/* impossible ? */
        //    x = trk.x;
        //    y = trk.y;
        //      }
        //      Coord	coord(x, y);
        //      track_control_selected(coord);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("selecttool"), 10)) {
        //      wxChar *end;
        //      for(cmd += 10; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('\t'); ++cmd);
        //      x = wxPorting.Strtol(cmd, &end, 10);
        //      if(*end == wxPorting.T(',')) ++end;
        //      y = wxPorting.Strtol(end, &end, 10);
        //      tool_selected(x, y);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("itinerary"), 9)) {
        //            Itinerary *it = parse_itinerary(cmd + 9);
        //      if(it)
        //                it.Select();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("delitinerary"), 9)) {
        //            Itinerary *it = parse_itinerary(cmd + 12);
        //      if(it)
        //                it.Deselect(false);
        //  } else if(!wxStrcmp(cmd, wxPorting.T("info"))) {
        //      track_info_dialogue();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("sb-edit"), 7)) {
        //      SwitchboardEditCommand(cmd + 7);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("sb-browser"), 10)) {
        //      SwitchboardOpenBrowser(cmd + 10);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("sb-cell"), 7)) {
        //      SwitchboardCellCommand(cmd + 7);
        //  } else if(!wxStrcmp(cmd, wxPorting.T("performance"))) {
        //      performance_dialog();
        //  } else if(!wxStrcmp(cmd, wxPorting.T("performance_toggle_canceled"))) {
        //      performance_toggle_canceled();
        //      performance_dialog();	// update page
        //  } else if(!wxStrcmp(cmd, wxPorting.T("options"))) {
        //      options_dialog();
        //      if(hard_counters)
        //    perf_vals = perf_hard;
        //      else
        //    perf_vals = perf_easy;
        //      invalidate_field();
        //      repaint_all();
        //      update_labels();
        //      new_status_position();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("assign"), 6)) {
        //      Train   *t1;

        //      for(cmd += 6; *cmd == ' ' || *cmd == '\t'; ++cmd);
        //      x = 0;
        //      while(*cmd && *cmd != ',') {
        //    buff[x++] = *cmd++;
        //      }
        //      buff[x] = 0;
        //      if(!(t = findTrainNamed(buff))) {
        //    // trace(wxPorting.L("Cannot assign %s: train not found."));
        //    return;
        //      }
        //      if(*cmd == ',') {
        //    while(*++cmd == ' ' || *cmd == '\t');
        //      } else {
        //    if(!t.stock) {
        //        // trace(wxPorting.L("Train %s has no default stock assignment."));
        //        return;
        //    }
        //    cmd = t.stock;
        //      }
        //      if(!(t1 = findTrainNamed(cmd))) {
        //    // trace(wxPorting.L("Cannot assign %s: train not found."));
        //    return;
        //      }
        //      save_assign_train(t1, t);
        ////	    invalidate_field();
        ////	    repaint_all();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("play"), 4)) {
        //      cmd += 4;
        //      while(*cmd == ' ') ++cmd;
        //      traindir.PlaySound(cmd);
        //  } else if(!wxStrcmp(cmd, wxPorting.T("skip"))) {
        //      skip_to_next_event();
        //  } else if(!wxStrcmp(cmd, wxPorting.T("save_perf_text"))) {
        //      traindir.SavePerfText();
        //  } else if(!wxStrncmp(cmd, wxPorting.T("split"), 5)) {
        //      int length;

        //      for(cmd += 5; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('\t'); ++cmd);
        //      x = 0;
        //      while(*cmd && *cmd != ',') {
        //    buff[x++] = *cmd++;
        //      }
        //      buff[x] = 0;
        //      if(!(t = findTrainNamed(buff))) {
        //    // trace(wxPorting.L("Cannot split %s: train not found."));
        //    return;
        //      }
        //      if(*cmd == ',') {
        //    while(*++cmd == ' ' || *cmd == '\t');
        //    length = wxAtoi(cmd);
        //      } else {
        //    length = 0;
        //      }
        //      split_train(t, length);
        //  } else if(!wxStrncmp(cmd, wxPorting.T("script"), 6)) {
        //      wxChar *end;
        //      for(cmd += 6; *cmd == ' ' || *cmd == '\t'; ++cmd);
        //      x = wxPorting.Strtol(cmd, &end, 10);
        //      if(*end == ',') ++end;
        //      y = wxPorting.Strtol(end, &end, 10);
        //      while(*end == ' ' || *end == '\t') ++end;
        //      if(!*end)
        //    return;
        //      trk = find_track(layout, x, y);
        //            if (!trk)
        //                return;
        //      switch(trk.type) {
        //      case TRACK:
        //      case TRIGGER:
        //      case SWITCH:
        //            case TSIGNAL:
        //    trk.RunScript(end);
        //      }

        //  } else if(match(&cmd, wxPorting.T("showinfo"))) {
        //      TDFile	infoFile(cmd);

        //      infoFile.SetExt(wxPorting.T(".htm"));
        //      if(infoFile.Load()) {
        //    traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
        //    info_page = infoFile.name.GetName();
        //      }
        //  } else if(match(&cmd, wxPorting.T("showalert"))) {
        //      traindir.AddAlert(cmd);
        //  } else if(match(&cmd, wxPorting.T("clearalert"))) {
        //      traindir.ClearAlert();
        //        } else if(match(&cmd, wxPorting.T("switch"))) {
        //      wxChar *end;
        //      cmd = skip_blanks(cmd);
        //            if(*cmd != '\'') {
        //          x = wxPorting.Strtol(cmd, &end, 10);
        //          if(*end == ',') ++end;
        //          y = wxPorting.Strtol(end, &end, 10);
        //                end = (wxChar *)skip_blanks(end);
        //                if(*end) {
        //              SwitchBoard *sw = FindSwitchBoard(end);
        //              if(sw)
        //                  sw.Select(x, y);
        //                }
        //            } else {
        //                end = (Char *)++cmd;
        //                while(*end && *end != '\'')
        //                    ++end;
        //                *end++ = 0;
        //                end = (wxChar *)skip_blanks(end);
        //                if(*end) {
        //              SwitchBoard *sw = FindSwitchBoard(end);
        //              if(sw)
        //                  sw.Select(cmd);
        //                }
        //            }
        //            server_command_done = true;
        //  } else {
        //      wxSnprintf(status_line, sizeof(status_line)/sizeof(status_line[0]), wxPorting.T("Command: %s"), cmd);
        //      repaint_labels();
      } else {
        // Erik's temporary patch
        throw new NotImplementedException();
      }
    }

    public static void trainsim_cmd(string cmd) {
      do_command(cmd, true);
    }

    public static void load_new_scenario(string cmd, int fl) {
      cmd = cmd.TrimStart();
      if(GlobalVariables.running)
        start_stop();
      if(GlobalVariables.layout_modified) {
        if(GlobalFunctions.ask_to_save_layout() < 0)	// cancel selected
          return;
      }
      clean_trains(GlobalVariables.schedule);
      clean_trains(GlobalVariables.stranded);
      GlobalVariables.schedule = null;
      GlobalVariables.stranded = null;
      invalidate_field();
      GlobalVariables.enable_training = false;
      if(fl == 2) {
        //load_puzzles(cmd);
        //trainsim_init();		/* clear counters, timer */
        //load_scripts(layout);	// run OnInit scripts
        //GlobalVariables.enable_training = true;
      } else {
        if((GlobalVariables.layout = load_field(cmd)) == null) {
          GlobalVariables.status_line = String.Format(wxPorting.T("{0} '{1}.trk'"), wxPorting.L("cannot load"), cmd);
          GlobalVariables.traindir.Error(GlobalVariables.status_line);
          return;
        }
        //if((GlobalVariables.schedule = load_trains(cmd)) != null)
        //  GlobalVariables.traindir.Error(wxPorting.L("No schedule for this territory!"));
        //if(fl != 0 && !all_trains_everyday(schedule) && select_day_dialog)
        //  select_day_dialog();
        //if(fl != 0)
        //  check_delayed_entries(schedule);
        ///* fill_schedule(schedule, 0); */
        //trainsim_init();		/* clear counters, timer */
        //load_scripts(layout);	// run OnInit scripts
        //bstreet_playing();
      }

      TDFile infoFile = new TDFile(cmd);

      wxString ext;

      //ext = String.Format(wxPorting.T("{0}.htm"), GlobalVariables.locale_name);
      //infoFile.SetExt(ext);
      //if(infoFile.Load()) {
      //  GlobalVariables.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
      //  info_page = infoFile.name.GetName();
      //} else {
      //  infoFile.SetExt(wxPorting.T(".htm"));
      //  if(infoFile.Load()) {
      //    GlobalVariables.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
      //    info_page = infoFile.name.GetName();
      //  } else {
      //    TDFile indexFile = new TDFile(wxPorting.T("index.htm"));
      //    if(indexFile.Load()) {
      //      GlobalVariables.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), indexFile.content);
      //      info_page = wxPorting.T("index.htm");
      //    } else
      //      info_page = wxPorting.T("");
      //  }
      //}
      //if(fl == 2) {
      //  show_puzzle();
      //}
      GlobalFunctions.repaint_all();
      //timetable._lastReloaded = ++lastModTime;
      //timetable.NotifyListeners();
    }


    public static void start_stop() {
      if(GlobalVariables.running) {
        make_timer(0);
        GlobalVariables.running = false;
      } else {
        GlobalVariables.running = true;
        make_timer(1000);
      }
    }

    public static void make_timer(int msec) {
      GlobalVariables.traindir.SetTimeSlice(msec / 100);  // each time slice is 100ms
    }


    public static int ask_to_save_layout() {
      ShowModalResult answer = wxPorting.MessageBox(wxPorting.L("The layout was changed. Do you want to save it?"),
          wxPorting.L("Question"), WindowStyles.DIALOG_YES_NO | WindowStyles.DIALOG_CANCEL);
      if(answer == ShowModalResult.CANCEL)
        return -1;
      if(answer == ShowModalResult.CANCEL)
        return 0;
      //if(!GlobalVariables.traindir.OnSaveLayout())
      //  return -1;
      return 1;
    }

    public static void clean_trains(Train sched) {
      //Train t;

      //clean_pixmap_cache();
      //while(sched != null) {
      //  t = sched.next;
      //  // delete sched;
      //  sched = t;
      //}
    }

    public static Track load_field(string name) {
      int l;
      TextList tl;
      Itinerary it;
      Track t;

      for(l = 0; l < 4; ++l) {
        GlobalVariables.e_train_pmap[l] = GlobalVariables.e_train_pmap_default[l];
        GlobalVariables.w_train_pmap[l] = GlobalVariables.w_train_pmap_default[l];
        GlobalVariables.e_car_pmap[l] = GlobalVariables.e_car_pmap_default[l];
        GlobalVariables.w_car_pmap[l] = GlobalVariables.w_car_pmap_default[l];
      }
      while((tl = GlobalVariables.track_info) != null) {
        GlobalVariables.track_info = tl.next;
        tl.txt = null;
        tl = null;
      }
      while((it = GlobalVariables.itineraries) != null) {
        GlobalVariables.itineraries = it.next;
        //  free_itinerary(it);
      }
      //powerSpecified = false;

      //free_scripts();
      t = load_field_tracks(name, out GlobalVariables.itineraries);
      //sort_itineraries();
      if(t != null) {
        GlobalFunctions.link_all_tracks(t);
        GlobalFunctions.link_signals(t);
        //  powerSpecified = power_specified(t);
        //  //	    load_scripts(t);	    // too soon, need trainsim_init() first
        //  current_project = name;
      }
      //layout_modified = 0;
      ////add_to_script(t);
      ////parse_script();
      return t;
    }

    public static Track load_field_tracks(string name, out Itinerary itinList) {
      itinList = null;

      Track layout, t, lastTrack;
      TextList tl, tlast;
      Itinerary it;
      char[] charArray;
      string buff;
      int l;
      int ttype;
      int x, y, sw;
      string p, p1;
      TDFile trkFile = new TDFile(name);

      trkFile.SetExt(wxPorting.T(".trk"));
      if(!trkFile.Load()) {
        buff = string.Format(wxPorting.T("File '{0}' not found."), trkFile.name);
        GlobalVariables.traindir.Error(buff);
        return null;
      }
      lastTrack = null;
      tlast = null;
      layout = null;

      int i;
      while(trkFile.ReadLine(out charArray)) {
        buff = new string(charArray);
        t = new Track();
        if(buff.StartsWith(wxPorting.T("(script "))) {
          p = buff.Substring(8);
          x = wxPorting.Strtol(p, out i, 10);
          p = p.Substring(i);
          y = wxPorting.Strtol(p, out i, 10);

          string script = "";
          while(trkFile.ReadLine(out charArray) && charArray[0] != ')') {
            buff = new string(charArray);
            buff += wxPorting.T("\n");
            script += buff;
          }

          for(t = layout; t != null; t = t.next) {
            if(t.x == x && t.y == y)
              break;
          }

          if(t == null)
            continue;

          t.stateProgram = string.Copy(script);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("(attributes "))) {
          p = buff.Substring(12);
          x = wxPorting.Strtol(p, out i, 10);
          if(p[i] == wxPorting.T(','))
            i++;
          p = p.Substring(i);
          y = wxPorting.Strtol(p, out i, 10);
          t = find_track(layout, x, y);
          while(trkFile.ReadLine(out charArray) && charArray[0] != ')') {
            buff = new string(charArray);
            if(t == null)
              continue;

            if(wxPorting.T("hidden").Equals(buff)) {
              t.invisible = true;
              continue;
            }

            if(buff.StartsWith(wxPorting.T("icons:"))) {	// ITIN and IMAGE
              p = buff.Substring(6);
              x = 0;
              int ch = 0;
              do {
                for(i = 0; (p[i] == wxPorting.T(' ') || p[i] == wxPorting.T('\t')); i++)
                  ;
                p = p.Substring(i);
                string n = string.Copy(p);

                for(i = 0; (i < p.Length && p[i] != wxPorting.T(',')); i++)
                  ;
                p = p.Substring(i);
                ch = p[0];
                p = p.Substring(0, 1);
                t._flashingIcons[x++] = string.Copy(n);
              } while(x < Configuration.MAX_FLASHING_ICONS && ch != 0);
              continue;
            }

            if(buff.StartsWith(wxPorting.T("locked"))) {
              p = buff.Substring(6);
              t._lockedBy = string.Copy(p);
              continue;
            }

            if(buff.StartsWith(wxPorting.T("power:"))) {
              p = buff.Substring(6);
              for(i = 0; i < p.Length && p[i] == ' '; i++)
                ;
              p = p.Substring(i);

              t.power = power_parse(p);
              continue;
            }

            if(buff.StartsWith(wxPorting.T("intermediate"))) {
              p = buff.Substring(12);
              t._intermediate = wxPorting.Strtol(p, out i, 10) != 0;
              t._nReservations = 0;
              continue;
            }

            if(buff.StartsWith(wxPorting.T("dontstopshunters"))) {
              t.flags |= TFLG.TFLG_DONTSTOPSHUNTERS;
              continue;
            }
          }
          continue;
        }

        if(buff.StartsWith(wxPorting.T("(switchboard "))) {
          p = buff.Substring(13);
          int pos = p.IndexOf(wxPorting.T(')'));
          if(pos >= 0)
            p = p.Substring(0, pos - 1); // *wxStrchr(p, wxPorting.T(')')) = 0;

          SwitchBoard sb = CreateSwitchBoard(p);
          sb.Load(p);
          continue;
        }

        t = new Track();
        t.fgcolor = GlobalVariables.fieldcolors[(int)(int)fieldcolor.COL_TRACK];
        ttype = buff[0];

#if false
            // script lines

            if(ttype == wxPorting.T('\t') || ttype == wxPorting.T(' ')) {
          wxStrcat(buff, wxPorting.T("\n"));
          append_to_script(buff);
            }
#endif

        p = buff.Substring(1);
        if(p[0] == wxPorting.T(','))
          p = p.Substring(1);
        t.x = wxPorting.Strtol(p, out i, 10);
        p = p.Substring(i);
        if(p[0] == wxPorting.T(','))
          p = p.Substring(1);
        t.y = wxPorting.Strtol(p, out i, 10);
        p = p.Substring(i);
        if(t.x >= ((Configuration.XMAX - Configuration.HCOORDBAR) / Configuration.HGRID) ||
          t.y >= ((Configuration.YMAX - Configuration.VCOORDBAR) / Configuration.VGRID))
          continue;
        if(p[0] == wxPorting.T(',')) p = p.Substring(1);
        t.direction = (trkdir)wxPorting.Strtol(p, out i, 10);
        p = p.Substring(i);
        if(p.Length > 0 && p[0] == wxPorting.T(',')) p = p.Substring(1);
        if(layout == null)
          layout = t;
        else
          lastTrack.next = t;
        lastTrack = t;
        t._lockedBy = null;
        switch(ttype) {
          case '0': // wxPorting.T('0'):
            t.type = trktype.TRACK;
            t.isstation = wxPorting.Strtol(p, out i, 10) > 0;
            if(p[0] == wxPorting.T(',')) p = p.Substring(1);
            t.length = wxPorting.Strtol(p, out i, 10);
            if(t.length == 0)
              t.length = 1;
            if(p[0] == ',') p = p.Substring(1);
            t.wlinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            if(p[0] == '@') {
              int j;

              p = p.Substring(1);
              t.speed[0] = wxPorting.Strtol(p, out i, 10);
              p = p.Substring(i);
              for(j = 1; j < Configuration.NTTYPES && p[0] == '/'; ++j) {
                p = p.Substring(1);
                t.speed[j] = wxPorting.Strtol(p, out i, 10);
                p = p.Substring(i);
              }
              if(p[0] == ',') p = p.Substring(1);
            }
            if(p[0] == (char)0 || p.Equals(wxPorting.T("noname"))) {
              t.isstation = false;
              break;
            }
            if(p[0] == '>') {
              p = parse_km(t, p + 1);
              if(p[0] == ',')
                p = p.Substring(1);
            }
            t.station = string.Copy(p);
            break;

          case '1':
            t.type = trktype.SWITCH;
            t.length = 1;
            t.wlinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == '@') {
              int j;

              p = p.Substring(1);
              t.speed[0] = wxPorting.Strtol(p, out i, 10);
              p = p.Substring(i);
              for(j = 1; j < Configuration.NTTYPES && p[0] == '/'; ++j) {
                p = p.Substring(1);
                t.speed[j] = wxPorting.Strtol(p, out i, 10);
                p = p.Substring(i);
              }
              if(p[0] == ',') p = p.Substring(1);
            }
            if(p.Length == 0 || p.Equals(wxPorting.T("noname")))
              break;
            if(p[0] == '>') {
              p = parse_km(t, p + 1);
              if(p[0] == ',')
                p = p.Substring(1);
            }
            t.station = string.Copy(p);
            break;

          /* 2, x, y, type, linkx, linky [itinerary] */

          case '2':
            trkdir dir;

            // Erik's patch - start
            Signal signal = new Signal();
            signal.fgcolor = t.fgcolor;
            signal.x = t.x;
            signal.y = t.y;
            signal.direction = t.direction;
            signal._lockedBy = t._lockedBy;

            Track tmp = layout;
            while(tmp.next != t)
              tmp = tmp.next;
            t = signal;
            tmp.next = t;
            lastTrack = t;
            // Erik's patch - end

            t.type = trktype.TSIGNAL;
            t.status = trkstat.ST_RED;
            dir = t.direction;
            if((t.direction & (trkdir)2) != 0) {
              t.fleeted = true;
              dir = (trkdir)((int)dir & ~2);
            }
            if(((int)dir & 0x100) != 0)
              t.fixedred = true;
            if(((int)dir & 0x200) != 0)
              t.nopenalty = (char)1;
            if(((int)dir & 0x400) != 0)
              t.signalx = (char)1;
            if(((int)(int)dir & 0x800) != 0)
              t.noClickPenalty = true;
            dir = (trkdir)((int)dir & ~0xF00);
            t.direction = (trkdir)((int)t.direction & ~0xF00);

            switch(dir) {
              case (trkdir)0:
                t.direction = trkdir.E_W;
                break;

              case (trkdir)1:
                t.direction = trkdir.W_E;
                break;

              case trkdir.N_S:
              case trkdir.S_N:
              case trkdir.signal_SOUTH_FLEETED:
              case trkdir.signal_NORTH_FLEETED:
                /* already there */
                t.direction = dir;
                break;
            }
            t.wlinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            if(p[0] == '@') {
              p1 = p.Substring(1);
              int pos = p1.IndexOf(',');
              if(pos >= 0) {
                p1 = p1.Substring(0, pos);
              }

              t.stateProgram = string.Copy(p1);
              if(pos >= 0)
                p = null;
            }
            if(p != null)			/* for itinerary definition */
              t.station = string.Copy(p);
            break;

          case '3':
            t.type = trktype.PLATFORM;
            if(t.direction == 0)
              t.direction = trkdir.W_E;
            else
              t.direction = trkdir.N_S;
            break;

          case '4':
            t.type = trktype.TEXT;
            t.station = string.Copy(p);
            for(l = 0; t.station[l] != 0x00 && t.station[l] != ','; ++l) ;
            t.station = t.station.Substring(l);
            while(p.Length > 0 && p[0] != ',')
              p = p.Substring(1);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == '>') {
              p = p.Substring(1);
              p = parse_km(t, p);
            }
            break;

          case '5':
            t.type = trktype.IMAGE;
            if(p[0] == '@') {
              p = p.Substring(1);
              t.wlinkx = wxPorting.Strtol(p, out i, 10);
              if(p[0] == ',') p = p.Substring(1);
              t.wlinky = wxPorting.Strtol(p, out i, 10);
              if(p[0] == ',') p = p.Substring(1);
            }
            t.station = string.Copy(p);
            break;

          case '6':			/* territory information */
            tl = new TextList();
            p += wxPorting.T("\n");	/* put it back, since we removed it */
            tl.txt = string.Copy(p);
            if(GlobalVariables.track_info == null)
              GlobalVariables.track_info = tl;
            else
              tlast.next = tl;
            tl.next = null;
            tlast = tl;
            break;

          case '7':			/* itinerary */
            p1 = string.Copy(p);
            for(i = 0; i < p.Length && p[i] != ','; i++)
              ;
            p = p.Substring(i);
            if(p.Length == 0)
              break;
            p = p.Substring(0, 1);
            it = new Itinerary();
            it.name = string.Copy(p1);

            p1 = string.Copy(p);
            for(l = 0; p.Length > 0 && (p[0] != ',' || l != 0); p = p.Substring(1)) {
              if(p[0] == '(') ++l;
              else if(p[0] == ')') --l;
            }
            if(p.Length == 0)
              break;
            p = p.Substring(1);
            it.signame = string.Copy(p1);
            p1 = string.Copy(p);
            for(l = 0; p.Length > 0 && (p[0] != ',' || l != 0); p = p.Substring(1)) {
              if(p[0] == '(') ++l;
              else if(p[0] == ')') --l;
            }
            if(p.Length == 0)
              break;
            p = p.Substring(1);
            it.endsig = string.Copy(p1);
            if(p[0] == '@') {
              p = p.Substring(1);
              p1 = string.Copy(p);
              for(l = 0; p.Length > 0 && (p[0] != ',' || l != 0); p = p.Substring(1)) {
                if(p[0] == '(') ++l;
                else if(p[0] == ')') --l;
              }
              if(p.Length == 0)
                break;
              p = p.Substring(1);
              it.nextitin = string.Copy(p1);
            }
            l = 0;
            while(p.Length > 0) {
              x = wxPorting.Strtol(p, out i, 0);
              p = p.Substring(i);
              if(p[0] != ',')
                break;
              p = p.Substring(1);
              y = wxPorting.Strtol(p, out i, 0);
              p = p.Substring(i);
              if(p[0] != ',')
                break;
              p = p.Substring(1);
              sw = wxPorting.Strtol(p, out i, 0);
              p = p.Substring(i);
              add_itinerary(it, x, y, sw);
              if(p[0] == ',') p = p.Substring(1);
            }
            it.next = itinList;	/* all ok, add to the list */
            itinList = it;
            break;

          case '8':			/* itinerary placement */
            t.type = trktype.ITIN;
            t.station = string.Copy(p);
            break;

          case '9':
            t.type = trktype.TRIGGER;
            t.wlinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.wlinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinkx = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            t.elinky = wxPorting.Strtol(p, out i, 10);
            if(p[0] == ',') p = p.Substring(1);
            for(l = 0; l < Configuration.NTTYPES && p[0] != ','; ++l) {
              t.speed[l] = wxPorting.Strtol(p, out i, 10);
              p = p.Substring(i);
              if(p[0] == '/') p = p.Substring(1);
            }
            if(p[0] == ',') p = p.Substring(1);
            if(p.Length == 0 || p.Equals(wxPorting.T("noname")))
              break;
            t.station = string.Copy(p);
            break;
        }
      }
      return layout;
    }

    public static Track find_track(Track layout, int x, int y) {
      while(layout != null) {
        if(layout.x == x && layout.y == y)
          return (layout);
        layout = layout.next;
      }
      return null;
    }


    public static string power_clean(string p) {
      const int max = 128;
      int i;
      char[] clean = new char[max];
      int x = 0;

      for(i = 0; i < p.Length; i++) {
        if(p[i] == ' ')
          continue;
        if(p[i] == '\n')
          break;
        if(x < max - 1)
          clean[x++] = p[i];
      }
      return new string(clean, 0, Math.Min(x, max - 1));
    }

    public static string power_find(string p) {
      for(int i = 0; i < GlobalVariables.gMotivePowerCache.Count; ++i) {
        string pc = GlobalVariables.gMotivePowerCache[i];
        if(pc.Equals(p))
          return pc;
      }
      return null;
    }

    public static string power_add(string pwr) {
      string pc = string.Copy(pwr);
      GlobalVariables.gMotivePowerCache.Add(pc);
      return pc;
    }

    public static string power_parse(string p) {
      p = power_clean(p);
      string pc = power_find(p);
      if(pc != null)
        return pc;
      return power_add(p);
    }

    public static string parse_km(Track t, string p) {
      int i;
      string pp;

      t.km = wxPorting.Strtol(p, out i, 10) * 1000;
      pp = p.Substring(i);

      if(pp[0] == '.') {
        pp = pp.Substring(1);
        t.km += wxPorting.Strtol(pp, out i, 10) % 1000;
      }
      return pp;
    }

    public static void add_itinerary(Itinerary it, int x, int y, int sw) {
      int i;

      for(i = 0; i < it.nsects; ++i)
        if(it.sw[i].x == x && it.sw[i].y == y) {
          it.sw[i].switched = sw;
          return;
        }
      if(it.nsects >= it.maxsects) {
        it.maxsects += 10;
        if(it.sw.Length == 0) {
          it.sw = new switin[it.maxsects];
        } else {
          it.sw = wxPorting.realloc(it.sw, it.maxsects);
        }
      }
      it.sw[it.nsects].x = x;
      it.sw[it.nsects].y = y;
      it.sw[it.nsects].switched = sw;
      ++it.nsects;
    }

    public static SwitchBoard FindSwitchBoard(string name) {
      SwitchBoard sb;

      for(sb = GlobalVariables.switchBoards; sb != null; sb = sb._next) {
        if(name.Equals(sb._fname))
          return sb;
      }
      return null;
    }


    public static void RemoveSwitchBoard(SwitchBoard sb) {
      SwitchBoard old = null;
      SwitchBoard s;

      for(s = GlobalVariables.switchBoards; s != null && s != sb; s = s._next)
        old = s;
      if(s != null) {
        if(old == null)
          GlobalVariables.switchBoards = s._next;
        else
          old._next = s._next;
      }
      //if(sb)
      //    delete sb;
    }

    public static SwitchBoard CreateSwitchBoard(string name) {
      SwitchBoard sb = FindSwitchBoard(name);
      RemoveSwitchBoard(sb);
      sb = new SwitchBoard();
      sb._name = name;
      sb._fname = name;
      sb._next = GlobalVariables.switchBoards;
      GlobalVariables.switchBoards = sb;
      return sb;
    }

    public static string scan_line(string src, out string dst) {
      string result = "";

      dst = "";
      while(src.Length > 0 && src[0] != '\n') {
        if(src[0] == '\r')
          continue;

        result += src[0];
        src = src.Substring(1);
      }
      dst = result;

      if(src.Length > 0)
        src = src.Substring(1);

      // if(*src) ++src;

      while(src[0] == ' ' || src[0] == '\t' || src[0] == '\n' || src[0] == '\r')
        src = src.Substring(1);

      return src;
    }

    public static void delete_itinerary(Itinerary ip) {
      Itinerary it, oit;

      oit = null;
      for(it = GlobalVariables.itineraries; it != null && ip != it; it = it.next)
        oit = it;
      if(it != null)
        return;
      if(oit != null)
        GlobalVariables.itineraries = it.next;
      else
        oit.next = it.next;
      free_itinerary(it);
    }

    static void free_itinerary(Itinerary it) {
      it.signame = null;
      it.endsig = null;
      it.name = null;
      it.sw = null;
      it = null;
    }


    public static void FillItineraryTable() {
      /* Here we do the actual adding of the text. It's done once for
       * each row.
       */

      int i;
      ItineraryView clist;
      Itinerary it;
      clist = GlobalVariables.traindir.m_frame.m_itineraryView;

      if(clist != null)
        return;
      clist.DeleteAllItems();
      clist.Freeze();
      i = 0;
      for(it = GlobalVariables.itineraries; it != null; it = it.next) {
        string buff;
        ListItem item = new ListItem();

        buff = string.Format(wxPorting.T("%s . %s"), it.signame, it.endsig);
        clist.InsertItem(i, it.name);
        clist.SetItem(i, 1, buff);
        item.Id = i;
        item.Mask = ListItemMask.DATA;
        clist.GetItem(item);
        item.Data = it;
        clist.SetItem(item);
        ++i;
      }
      clist.Thaw();
    }

    public static void FreeFileList() {
      FileItem it;

      while((it = GlobalVariables.file_list) != null) {
        GlobalVariables.file_list = it.next;
        // delete it;
      }

    }



    public static FileItem AddFile(string name) {
      FileItem it = new FileItem(name.Replace("\\", "/"));
      it.next = GlobalVariables.file_list;
      GlobalVariables.file_list = it;

      return it;
    }

    public static bool ReadZipFile(string path) {
      ArchiveInput zip = new ArchiveInput(path);

      ArchiveEntry entry;
      string entryName;
      FileItem it;

      while((entry = zip.GetNextEntry()) != null) {
        entryName = entry.InternalName;
        it = AddFile(entryName);
        zip.OpenEntry(entry);
        it.size = (int)zip.In.Length;

#if wxUSE_UNICODE
    /// TODO Erik: This code was not parsed/verified
	    wxWritableCharBuffer tmpMB(it.size + 4);
	    if ((char *) tmpMB == NULL)
		return 0;
	    char *buffer = tmpMB;
	    for(i = 0; !zip.Eof() && i < it.size; buffer[i++] = zip.GetC());
	    buffer[i] = 0;
	    zip.CloseEntry();
	    /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
	    if (! (it.content = wxConvAuto().cMB2WX(tmpMB).release()))
		if (! (it.content = wxConvISO8859_1.cMB2WX(tmpMB).release()))
		    return 0;
#else
        int ch;
        it.content = new char[it.size];
        using(StreamReader reader = new StreamReader(zip.In)) {
          // ... now read entry's data
          reader.Read(it.content, 0, it.size);
        }


#endif // !wxUSE_UNICODE
      }
      return true;
    }

    public static bool LoadFile(string name, out char[] dest) {
      FileItem it;

      dest = new char[0];

      string fname = name;
      fname = fname.Replace("\\", "/");
      for(it = GlobalVariables.file_list; it != null; it = it.next) {
        string t = it.name;
        if((fname.Equals(t)))
          break;
      }
      if(it != null) {
        dest = new char[it.size];
        Array.Copy(it.content, dest, it.size);
        return true;
      }

      //FILE    *fp;
      //if(!(fp = wxFopen(name, wxPorting.T("rb")))) {

      string filename;
      filename = name;

      if(!File.Exists(filename)) {
        int p, p1, len;

#if true
        // search in provided directories
        string pth = GlobalVariables.searchPath._sValue;
        for(p = 0; p < GlobalVariables.searchPath._sValue.Length; ++p) {
          if(pth[p] == wxPorting.T(';')) {
            if(filename.Length > 0) {
              filename += wxPorting.T('/');
              filename += name;

              // if((fp = wxFopen(filename, wxPorting.T("rb"))))
              if(File.Exists(filename))
                goto found;

              filename = wxPorting.T("");
            }
          } else
            filename += pth[p];
        }
        if(filename.Length > 0) {
          filename += wxPorting.T('/');
          filename += name;
          // if((fp = wxFopen(filename, wxPorting.T("rb"))))
          if(File.Exists(filename))
            goto found;
        }
#else
	    p = p1 = 0;
	    while(!searchPath.empty() && p1 != wxString::npos) {
		p1 = searchPath.find(wxPorting.T(';'), p);
		len = p1 == wxString::npos ? p1 : p1 - p;
		filename = searchPath.substr(p, len) + wxPorting.T('/') + name;
		if((fp = wxFopen(filename, wxPorting.T("rb"))))
		    goto found;
		p = p1;
	    }
#endif
        return false;
      }
    found:
      using(BinaryReader reader = new BinaryReader(File.OpenRead(filename))) {
        //fseek(fp, 0, 2);
        //int	length = ftell(fp);
        //rewind(fp);
        int length = (int)reader.BaseStream.Length;

#if wxUSE_UNICODE
	wxWritableCharBuffer tmpMB(length + 4);
	if ((char *) tmpMB == NULL)
	    return 0;
	if(fread(tmpMB, 1, length, fp) != length) {
	    fclose(fp);
	    return 0;
	}
	fclose(fp);
	((char *) tmpMB)[length] = 0;		// mark end of file
	/* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
	if (! (*dest = wxConvAuto().cMB2WX(tmpMB).release()))
	    if (! (*dest = wxConvISO8859_1.cMB2WX(tmpMB).release()))
		return 0;
#else
        dest = reader.ReadChars(length);
      }

#endif // !wxUSE_UNICODE
      return true;
    }

    public static void setBackgroundColor(Colour col) {
      int rgb = GlobalVariables.curSkin.background;
      col.Set(
        (byte)(rgb >> 16),
        (byte)((rgb >> 8) & 0xFF),
        (byte)(rgb & 0xFF)
      );
    }

    public static void create_colors() {
      GlobalVariables.color_black = 0;
      GlobalVariables.color_white = 1;
      GlobalVariables.color_green = 2;
      GlobalVariables.color_yellow = 3;
      GlobalVariables.color_red = 4;
      GlobalVariables.color_orange = 5;
      GlobalVariables.color_brown = 6;
      GlobalVariables.color_gray = 7;
      GlobalVariables.color_lightgray = 8;
      GlobalVariables.color_darkgray = 9;
      GlobalVariables.color_blue = 10;
      GlobalVariables.color_cyan = 11;
      GlobalVariables.color_magenta = 12;

      GlobalVariables.fieldcolors[(int)fieldcolor.COL_BACKGROUND] = GlobalVariables.color_lightgray;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRACK] = GlobalVariables.color_black;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_GRAPHBG] = GlobalVariables.color_lightgray;

      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN1] = GlobalVariables.color_orange;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN2] = GlobalVariables.color_cyan;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN3] = GlobalVariables.color_blue;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN4] = GlobalVariables.color_yellow;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN5] = GlobalVariables.color_white;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN6] = GlobalVariables.color_red;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN7] = GlobalVariables.color_brown;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN8] = GlobalVariables.color_green;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN9] = GlobalVariables.color_magenta;
      GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRAIN10] = GlobalVariables.color_lightgray;

      GlobalVariables.curSkin = new TDSkin();
      GlobalVariables.curSkin.free_track = getcolor_rgb(GlobalVariables.color_black);
      GlobalVariables.curSkin.reserved_track = getcolor_rgb(GlobalVariables.color_green);
      GlobalVariables.curSkin.reserved_shunting = getcolor_rgb(GlobalVariables.color_white);
      GlobalVariables.curSkin.occupied_track = getcolor_rgb(GlobalVariables.color_orange);
      GlobalVariables.curSkin.working_track = getcolor_rgb(GlobalVariables.color_blue);
      GlobalVariables.curSkin.background = getcolor_rgb(GlobalVariables.color_lightgray);
      GlobalVariables.curSkin.outline = getcolor_rgb(GlobalVariables.color_darkgray);
      GlobalVariables.curSkin.text = getcolor_rgb(GlobalVariables.color_black);
      GlobalVariables.curSkin.name = string.Copy(wxPorting.T("default"));
      GlobalVariables.curSkin.next = null;
      GlobalVariables.skin_list = GlobalVariables.curSkin;
      GlobalVariables.defaultSkin = GlobalVariables.curSkin;
    }

    public static void getcolor_rgb(int col, out int r, out int g, out int b) {
      r = g = b = 0;
      if(col < 0 || col > 11)
        return;
      r = GlobalVariables.colortable[col][0];
      g = GlobalVariables.colortable[col][1];
      b = GlobalVariables.colortable[col][2];
    }

    public static int getcolor_rgb(int col) {
      int c = 0
        | (GlobalVariables.colortable[col][0] << 16)
        | (GlobalVariables.colortable[col][1] << 8)
        | (GlobalVariables.colortable[col][2] << 0);
      return c;
    }

    public static void create_draw(ScrolledWindow parent) {
      grid g;

      g = new grid(parent, Configuration.XMAX * 2, Configuration.YMAX * 2);
      g.m_hmult = Configuration.HGRID;
      g.m_vmult = Configuration.VGRID;
      GlobalVariables.field_grid = g;
      GlobalVariables.current_grid = g;
      set_show_coord(true);
    }

    public static void set_show_coord(bool opt) {
      GlobalVariables.bShowCoord = opt;
      if(opt) {
        GlobalVariables.field_grid.m_xBase = Configuration.HCOORDBAR;
        GlobalVariables.field_grid.m_yBase = Configuration.VCOORDBAR;
      } else {
        GlobalVariables.field_grid.m_xBase = 0;
        GlobalVariables.field_grid.m_yBase = 0;
      }
    }

    public static Image get_pixmap(string[] pxpm) {
      /// TODO
      return ConvertFormat(pxpm);

      //Image img = new wx.Image(
      //  (new ASCIIEncoding()).GetBytes(pxpm),
      //  // ERIK The following line was added by Erik for compatibility reasons. WARNING: It's not verified!!!
      //  BitmapType.wxBITMAP_TYPE_XPM_DATA
      //);
      // return img;
    }

    // ERIK's patch
    private static Image ConvertFormat(string[] pixmax) {
      List<byte> list = new List<byte>();
      ASCIIEncoding encoder = new ASCIIEncoding();

      byte[] terminator = new byte[] { 0x10, 0x13 };
      list.Clear();
      list.AddRange(encoder.GetBytes("/* XPM */")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("static char * dummy[] = {")); list.AddRange(terminator);
      foreach(string line in pixmax) {
        list.AddRange(encoder.GetBytes("\"" + line + "\",")); list.AddRange(terminator);
      }

      return new Image(list.ToArray(), BitmapType.wxBITMAP_TYPE_XPM);
    }


    public static void invalidate_field()	/* next time, repaint whole field */
    {
      GlobalVariables.cliprect.top = 0;
      GlobalVariables.cliprect.left = 0;
      GlobalVariables.cliprect.bottom = Configuration.YNCELLS;
      GlobalVariables.cliprect.right = Configuration.XNCELLS;
      GlobalVariables.ignore_cliprect = true;
    }
    public static void tr_fillrect(int x, int y) {
      GlobalVariables.current_grid.FillCell(x, y);
    }

    public static void clear_field() {
      if(GlobalVariables.editing)
        GlobalFunctions.invalidate_field();
      GlobalVariables.field_grid.ClearField();
    }

    public static void grid_paint() {
      GlobalVariables.field_grid.Paint();
    }

    public static void coord_paint(Coord pCoord) {
      string buff;
      int i;
      grid g = GlobalVariables.field_grid;

      wx.Font font = new wx.Font(6, FontFamily.wxSWISS, FontStyle.wxNORMAL, FontWeight.wxNORMAL);
      g.m_dc.SelectObject(g.m_pixmap);

      // draw background of coord bars
      g.m_dc.SetPen(GDIPens.wxLIGHT_GREY_PEN);
      g.m_dc.SetBrush(GDIBrushes.wxLIGHT_GREY_BRUSH);
      g.m_dc.DrawRectangle(0, 0, Configuration.XMAX, Configuration.VCOORDBAR);
      g.m_dc.DrawRectangle(0, 0, Configuration.HCOORDBAR, Configuration.YMAX);

      // draw digits
      g.m_dc.SetFont(font);
      g.m_dc.BackgroundMode = DCBackgroundMode.SOLID;
      g.m_dc.SetTextForeground(Colour.wxBLACK);
      g.m_dc.SetTextBackground(Colour.wxLIGHT_GREY);
      System.Drawing.Point pt = new System.Drawing.Point(0, 0);
      for(i = 0; i < Configuration.XNCELLS; ++i) {
        if(pCoord != null && i == pCoord.x)
          g.m_dc.TextForeground = Colour.wxWHITE;
        buff = string.Format(wxPorting.T("{0}"), i / 100);
        pt.X = i * Configuration.HGRID + Configuration.HCOORDBAR;
        pt.Y = 0;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format(wxPorting.T("{0}"), (i / 10) % 10);
        pt.Y = 8;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format(wxPorting.T("{0}"), i % 10);
        pt.Y = 16;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.x)
          g.m_dc.TextForeground = Colour.wxBLACK;
      }
      for(i = 0; i < Configuration.YNCELLS; ++i) {
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Colour.wxWHITE);
        buff = String.Format(wxPorting.T("{0:d3}"), i);
        pt.X = 0;
        pt.Y = i * Configuration.VGRID + Configuration.VCOORDBAR;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Colour.wxBLACK);
      }
      g.m_dc.SelectObject(Bitmap.NullBitmap);
    }

    public static void layout_paint(Track lst) {
      Track trk;
      int x, y;

      if(!GlobalVariables.ignore_cliprect) {
#if true
        if(!GlobalVariables.editing &&
              (GlobalVariables.cliprect.top < 0 || GlobalVariables.cliprect.top >= Configuration.YNCELLS ||
              GlobalVariables.cliprect.bottom < 0 || GlobalVariables.cliprect.bottom >= Configuration.YNCELLS ||
              GlobalVariables.cliprect.left < 0 || GlobalVariables.cliprect.left >= Configuration.XNCELLS ||
              GlobalVariables.cliprect.right < 0 || GlobalVariables.cliprect.right >= Configuration.XNCELLS)) {
          trk = null;
          return;
        }
#endif
        for(y = GlobalVariables.cliprect.top; y <= GlobalVariables.cliprect.bottom; ++y)
          for(x = GlobalVariables.cliprect.left; x <= GlobalVariables.cliprect.right; ++x)
            if(GlobalFunctions.UPDATE_MAP(x, y) != 0)
              GlobalFunctions.tr_fillrect(x, y);
      }

      for(trk = lst; trk != null; trk = trk.next)
        if(GlobalVariables.editing || GlobalFunctions.track_updated(trk) != 0) {
          GlobalFunctions.UPDATE_MAP(trk.x, trk.y, 0);
          GlobalFunctions.track_paint(trk);
        }
    }

    public static void trains_paint(Train trn) {
      for(; trn != null; trn = trn.next) {
        if(trn.position != null) {
          if(!GlobalVariables.show_icons) {
            int tmp = trn.position.fgcolor;
            trn.position.fgcolor = GlobalVariables.color_orange;
            GlobalFunctions.track_paint(trn.position);
            trn.position.fgcolor = tmp;
            continue;
          } else if((trn.flags & TFLG.TFLG_STRANDED) != 0) {
            if(GlobalFunctions.findTrain(trn.position.x, trn.position.y) != null)
              continue;
            GlobalFunctions.car_draw(trn.position, trn);
          } else
            GlobalFunctions.train_draw(trn.position, trn);
        }
        if(trn.tail != null && trn.tail.position != null &&
          trn.tail.position != trn.position)
          GlobalFunctions.car_draw(trn.tail.position, trn);
      }
    }
    public static void draw_all_pixmap() {
      //wx.SampleDialogs.TestProgram.TestSomething2();
      //return;
      grid g;
      g = GlobalVariables.field_grid;
      ClientDC clientDC = new ClientDC(g.m_parent);
      ScrolledWindow w = (ScrolledWindow)g.m_parent;
      w.PrepareDC(clientDC);
      BufferedDC wdc = new BufferedDC(clientDC, g.m_pixmap);
    }

    public static void reset_clip_rect()	/* next time, don't paint anything */
    {
      GlobalVariables.cliprect.top = Configuration.YNCELLS;
      GlobalVariables.cliprect.bottom = 0;
      GlobalVariables.cliprect.left = Configuration.XNCELLS;
      GlobalVariables.cliprect.right = 0;
      GlobalVariables.ignore_cliprect = false;
      Array.Clear(GlobalVariables.update_map, 0, GlobalVariables.update_map.Length);
    }

    public static char UPDATE_MAP(int x, int y) {
      return GlobalVariables.update_map[(y) * Configuration.XNCELLS + (x)];
    }

    public static void UPDATE_MAP(int x, int y, int val) {
      GlobalVariables.update_map[(y) * Configuration.XNCELLS + (x)] = (char)val;
    }

    public static int track_updated(Track trk) {
      if(trk.x < (GlobalVariables.cliprect.left - 1) || trk.x > GlobalVariables.cliprect.right)
        return 0;
      if(trk.y < (GlobalVariables.cliprect.top - 1) || trk.y > GlobalVariables.cliprect.bottom)
        return 0;
      /* it's inside the clip rect, but do we really need to update it? */
#if false
	int	i;
	int	j;

	for(j = 0; j < 2; ++j)
	    for(i = 0; i < 3; ++i)
		if(UPDATE_MAP(trk.x, trk.y))
		    return 1;
#endif
      if(GlobalVariables.ignore_cliprect || GlobalFunctions.UPDATE_MAP(trk.x, trk.y) != 0)
        return 1;
      return 0;
    }

    public static Train findTrain(int x, int y) {
      Train tr;

      for(tr = GlobalVariables.schedule; tr != null; tr = tr.next)
        if(tr.position != null && tr.position.x == x && tr.position.y == y)
          return tr;
      return null;
    }

    public static void draw_layout(int x0, int y0, VLines[] p, grcolor col) {
      GlobalVariables.current_grid.DrawLayoutRGB(x0, y0, p, col);
      GlobalFunctions.update_rectangle_at(x0, y0);
    }

    public static void draw_pixmap(int x0, int y0, object map) {
      wx.Image img = (wx.Image)map;
      grid g = GlobalVariables.current_grid;
      int x = x0 * g.m_hmult + g.m_xBase;
      int y = y0 * g.m_vmult + g.m_yBase;

      if(!img.Ok)
        return;
      if(g.m_pixmap == null)
        return;
      if(g.m_dc == null)
        g.m_dc = new MemoryDC();
      if(g == GlobalVariables.tools_grid && y0 != 0 && x0 < 8) {
        x += GlobalVariables.tools_grid.m_hmult / 2;
        y += GlobalVariables.tools_grid.m_vmult / 2;
      }
      wx.Bitmap bitmap = new Bitmap(img, -1);
      g.m_dc.SelectObject(g.m_pixmap);
      g.m_dc.DrawBitmap(bitmap, x, y, true);
      g.m_dc.SelectObject(Bitmap.NullBitmap);
    }

    public static void draw_layout_text1(int x, int y, string txt, int size) {
      GlobalVariables.current_grid.DrawText1(x, y, txt, size);
    }

    public static void draw_layout_text_font(int x, int y, string txt, int index) {
      GlobalVariables.current_grid.DrawTextFont(x, y, txt, index);
    }

    public static void draw_link(int x0, int y0, int x1, int y1, int color) {
      GlobalVariables.field_grid.DrawLineCenterCell(x0, y0, x1, y1, color);
    }

    public static void draw_itin_text(int x, int y, string txt, int size) {
      if(GlobalVariables.current_grid == GlobalVariables.tools_grid)
        draw_layout_text1(x, y, txt, size);
      else
        draw_layout_text1(x + 1, y, txt, size);
    }

    public static void update_rectangle_at(int x, int y) {
      wxRect update_rect = new wxRect();

      if(GlobalVariables.updating_all)
        return;

      update_rect.X = x;
      update_rect.Y = y;
      update_rect.Width = GlobalVariables.current_grid.m_hmult;
      update_rect.Height = GlobalVariables.current_grid.m_vmult;

      GlobalFunctions.draw_all_pixmap();	// TEMP
    }

    public static int get_pixmap_index(string mapname) {
      int i;

      for(i = 0; i < GlobalVariables.npixmaps; ++i)
        if(mapname.Equals(GlobalVariables.pixmaps[i].name))
          return i;
      if(GlobalVariables.npixmaps >= GlobalVariables.maxpixmaps) {
        GlobalVariables.maxpixmaps += 10;
        if(GlobalVariables.pixmaps == null)
          GlobalVariables.pixmaps = new pxmap[GlobalVariables.maxpixmaps];
        else
          GlobalVariables.pixmaps = wxPorting.realloc(GlobalVariables.pixmaps, GlobalVariables.maxpixmaps);
        // Erik's patch
        for(i = GlobalVariables.maxpixmaps - 10; i < GlobalVariables.maxpixmaps; i++) {
          GlobalVariables.pixmaps[i] = new pxmap();
        }
      }
      if((GlobalVariables.pixmaps[GlobalVariables.npixmaps].pixels = get_pixmap_file(mapname)) == null)
        return -1;          /* failed! file does not exist */
      GlobalVariables.pixmaps[GlobalVariables.npixmaps].name = string.Copy(mapname);
      return GlobalVariables.npixmaps++;
    }

    public static void do_alert(string msg) {
      GlobalVariables.alert_msg = msg;
      GlobalFunctions.repaint_labels();
      GlobalVariables.traindir.AddAlert(msg);
      if(GlobalVariables.beep_on_alert)
        GlobalFunctions.alert_beep();
    }

    public static void draw_mid_point(int x0, int y0, int dx, int dy, grcolor col) {
      GlobalVariables.current_grid.DrawPoint(x0, y0, dx, dy, col);
      GlobalFunctions.update_rectangle_at(x0, y0);
    }

    public static void repaint_labels() {
      repaint_labels(false);
    }
    public static void repaint_labels(bool force) {
      //int	i;

      //for(i = 0; i < 8; ++i)
      //    if(//labelList[i].handle &&
      //  force ||
      //  wxStrcmp(labelList[i].text, labelList[i].oldtext)) {
      //  if(i == 7)
      //      traindir.m_frame.m_statusText.SetLabel(labelList[i].text);
      //  else if(i == 2)
      //      traindir.m_frame.m_alertText.SetLabel(labelList[i].text);
      //  else if(i == 0) {
      //      wxString	buff = labelList[i].text;
      //      size_t	p;

      //      p = buff.find(wxPorting.T('('));
      //      if(p == wxString::npos)
      //    p = buff.find(wxPorting.T('x'));
      //      if(p != wxString::npos) {
      //    wxString buff;
      //    buff.Printf (wxPorting.T("x %d"), time_mult);
      //    traindir.m_frame.m_speed.SetValue(buff);
      //    traindir.m_frame.m_speedArrows.SetValue(cur_time_mult);
      //      }
      //      traindir.m_frame.m_clock.SetLabel(buff.substr (0, p));
      //  } else if(i < NSTATUSBOXES)
      //      traindir.m_frame.SetStatusText(labelList[i].text, i);
      //  wxStrncpy(labelList[i].oldtext, labelList[i].text,
      //    sizeof(labelList[i].oldtext) / sizeof(wxChar));
      //  labelList[i].oldtext[sizeof(labelList[i].oldtext) / sizeof(wxChar)- 1] = 0;
      //    }
      //wxString    title;

      //if(traindir.m_frame.m_showToolbar) {
      //    title << program_name;
      //    title << wxPorting.T(" - ");
      //    title << fileName(current_project);
      //    if(layout_modified)
      //  title << wxPorting.T(" *");
      //    title << wxPorting.T(" - ");
      //    title << labelList[0].text;
      //    title << wxPorting.T(" - ");
      //    title << total_points_msg;
      //} else {
      //    title << labelList[0].text;
      //    title << wxPorting.T(" - ");
      //    title << total_points_msg;
      //    title << wxPorting.T(" - ");
      //    title << labelList[7].text;
      //}
      //traindir.m_frame.SetTitle(title);
    }

    public static void alert_beep() {
      //if(pAlertSound && pAlertSound.IsOk())
      //  pAlertSound.Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
    }

    public static wx.Image get_pixmap_file(string fname) {

      TDFile xpmFile = new TDFile(fname);

      if(!xpmFile.Load())
        return null;

      // Erik's patch
      byte[] data = (new ASCIIEncoding()).GetBytes(xpmFile.content);
      return new Image(data, BitmapType.wxBITMAP_TYPE_XPM);

      // gLogger.SetExtraInfo(fname);

      int nLines = xpmFile.LineCount();
      string[] pattern = new string[nLines + 10];
      // = (char **)calloc(nLines + 10, sizeof(char *));
      int i, j, k;
      string buff;

      char[] charArray;

      // collect all strings (delimited by double-quotes)
      // from the file and store them in pattern[],
      // one string per entry.


      int pos;
      string tmpBuff;
      for(i = 0; i < nLines; ) {
        if(xpmFile.ReadLine(out charArray) == false)
          break;

        buff = new string(charArray);

        j = buff.IndexOf('"');
        if(j < 0)
          continue;
        j++;
        k = buff.IndexOf('"', j);
        if(k < 0)
          continue;

        buff = buff.Substring(j, k - j);

#if wxUSE_UNICODE
	    wxConvISO8859_1.FromWChar(pattern[i], k + 10, buff, wxNO_LEN);
#else
        pattern[i] = buff;
#endif
        ++i;
      }

      wx.Image img = null;

      // now analyze the lines to check if the image is correct

      int nRows, nColumns, nColors, depth, x, y, c;

      nRows = nColumns = nColors = depth = 0;

      bool hasError = true;
      string[] pieces = pattern[0].Split(' ');
      if(pieces.Length == 4) {
        try {
          int dummy;
          nColumns = wxPorting.Strtol(pieces[0], out dummy, 10);
          nRows = wxPorting.Strtol(pieces[1], out dummy, 10);
          nColors = wxPorting.Strtol(pieces[2], out dummy, 10);
          depth = wxPorting.Strtol(pieces[3], out dummy, 10);
          hasError = false;
        } catch(Exception) {
        }
      }

      if(hasError) {
        buff = string.Format(wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
        GlobalVariables.traindir.layout_error(buff);
        goto done;
      }
      if(nRows > i - 1 - nColors) {
        string cbuff;
        buff = string.Format(wxPorting.T("%s: Warning: too many lines in XPM header. Truncated."), fname);
        GlobalVariables.traindir.layout_error(buff);
        cbuff = string.Format("%d %d %d %d", nColumns, i - 1 - nColors, nColors, depth);
        pattern[0] = null;
        pattern[0] = string.Copy(cbuff);
      }
      for(y = nColors + 1; y < i; ++y) {  // check each pixel row
        for(x = 0; x < nColumns; ++x) {
          bool valid = false;
          if(pattern[y][x] == 0)
            break;
          for(c = 0; c < nColors; ++c) {
            if(pattern[c + 1][0] == pattern[y][x]) {
              valid = true;
              break;
            }
          }
          if(!valid) {
            charArray = pattern[y].ToCharArray();
            charArray[x] = pattern[1][0];  // force first color (hopefully "None")
            pattern[y] = new string(charArray);
            buff = string.Format(wxPorting.T("%s: Warning: bad color key (y=%d,x=%d). Replaced."), fname, y, x);
            GlobalVariables.traindir.layout_error(buff);
          }
        }
      }
      try {
        /// TODO
        /// img = new wx.Image(pattern);
        img = new wx.Image();

        if(!img.Ok) {
          buff = string.Format(wxPorting.T("Error loading '%s'"), fname);
          GlobalVariables.traindir.layout_error(buff);
          img = null;
        }
      } catch(Exception) {
        buff = string.Format(wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
        GlobalVariables.traindir.layout_error(buff);
      }
    done:
      for(i = 0; i < pattern.Length; ++i)
        pattern[i] = null;
      pattern = null;
      return img;
    }

    public static void repaint_all() {
      GlobalVariables.current_grid = GlobalVariables.field_grid;
      if(!GlobalVariables.editing && GlobalVariables.cliprect.top > GlobalVariables.cliprect.bottom)
        return; /* no changes since last update */
      if(GlobalVariables.ignore_cliprect || GlobalVariables.editing)
        GlobalFunctions.clear_field();
      GlobalVariables.updating_all = true;
      if(GlobalVariables.show_grid)
        GlobalFunctions.grid_paint();
      if(GlobalVariables.bShowCoord)
        GlobalFunctions.coord_paint(null);
      GlobalFunctions.layout_paint(GlobalVariables.layout);
      GlobalFunctions.trains_paint(GlobalVariables.stranded);
      GlobalFunctions.trains_paint(GlobalVariables.schedule);
      GlobalVariables.updating_all = false;
      GlobalFunctions.draw_all_pixmap();
      GlobalFunctions.reset_clip_rect();
    }

    public static void ShowWelcomePage() {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      GlobalVariables.traindir.BuildWelcomePage(page);
      GlobalVariables.traindir.m_frame.ShowHtml(wxPorting.L("Welcome"), page.content);
    }

    //	update_button
    //	called to update the start/stop state of UI's buttons.
    public static void update_button(string cmd, string lbltxt) {
      GlobalVariables.traindir.m_frame.m_running.Label = lbltxt;
      if(GlobalVariables.running)
        GlobalVariables.traindir.m_frame.m_running.State = true;
      else
        GlobalVariables.traindir.m_frame.m_running.State = false;
    }

    public static void UpdateSignals(Signal ignore) { //, bool doUpdate = true) {
      UpdateSignals(ignore, true);
    }

    public static void open_all_fleeted() {
      Signal s;

      for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1) {
        if(!s.fleeted)
          continue;
        if(!s.nowfleeted || s.IsClear()) // s.status == ST_GREEN)
          continue;
        if(s.controls != null || s.controls.fgcolor == GlobalVariables.color_green)
          continue;
        GlobalFunctions.toggle_signal_auto(s, false);
      }
    }

    public static void UpdateSignals(Signal ignore, bool doUpdate) {
      GlobalFunctions.open_all_fleeted();

      // if the aspect of any signal has changed,
      // notify all signals and have them perform
      // any appropriate action, such as changing
      // the aspect of an approach signal.

      if(GlobalVariables.signals_changed) {
        Signal s;

        if(ignore != null)
          ignore.aspect_changed = true;
        for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1) {
          s._prevState = s._currentState;
          if(s != ignore)
            s.aspect_changed = false;
        }
        do {
          GlobalVariables.signals_changed = false;
          for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1)
            s._prevState = s._currentState;
          for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1)
            s.OnUpdate();
          for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1)
            if(s._currentState != s._prevState) {
              break;
            }
        } while(s != null); // was: signals_changed);
        GlobalFunctions.open_all_fleeted();
        GlobalFunctions.onIconUpdateAll();
      }
      GlobalVariables.signals_changed = false;
      GlobalFunctions.repaint_all();
    }

    public static void flash_signals() {
      Signal s;

      for(s = (Signal)GlobalVariables.signal_list; s != null; s = (Signal)s.next1) {
        if(!s._isFlashing)
          continue;
        s.OnFlash();
      }
    }

    public static void click_time() {
      int i;
      int oldmult;
      Train t;

      if(!GlobalVariables.running) {
        flash_signals();
        repaint_all();
        return;
      }
      GlobalVariables.changed = false;
      GlobalVariables.signals_changed = false;
      for(i = oldmult = GlobalVariables.time_mult; i > 0; --i) {
        GlobalVariables.time_mult = 1;
        GlobalFunctions.time_step();
        if(GlobalVariables.time_mult != 1)		// if changed by a trigger
          oldmult = GlobalVariables.time_mult;	// we'll restore the new value
        GlobalFunctions.UpdateSignals(null, false);
        if((GlobalVariables.current_time % 60) == 59) {	// at the top of a minute
          // record how many late minutes we have accumulated
          GlobalVariables.late_data[(GlobalVariables.current_time / 60) % (60 * 24)] = GlobalVariables.total_late;
        }
        GlobalFunctions.record_state();
      }
      GlobalFunctions.flash_signals();
      if(GlobalVariables.changed)
        GlobalFunctions.repaint_all();
      GlobalVariables.changed = false;
      GlobalVariables.time_mult = oldmult;
      while(GlobalVariables.save_assign_list != null) {
        SaveAssign s = GlobalVariables.save_assign_list;
        GlobalVariables.save_assign_list = s.next;
        GlobalFunctions.assign_train(s.newTrain, s.oldTrain);
        GlobalFunctions.free(s);
      }
      GlobalFunctions.update_labels();
      for(t = GlobalVariables.schedule; t != null; t = t.next)
        if(t.newsched != null)
          break;
      if(t != null) {
        // some train's data was updated
        // - update all timetable views in our UI
        for(t = GlobalVariables.schedule; t != null; t = t.next)
          if(t.newsched != null) {
            GlobalFunctions.update_schedule(t);
          }
        // - tell any waiting servers (i.e. the web server)
        _TimeTableCPP.timetable.NotifyListeners();
      }
    }

    public static void free(object s) {
      /// TODO Maybe?
      //_CRTIMP _CRTNOALIAS void   __cdecl free(_Inout_opt_ void * _Memory);
    }


    public static void link_signals(Track layout) {
      TrackBase t;

      for(t = GlobalVariables.layout; t != null; t = t.next)	    /* in case signal was relinked during edit */
        t.esignal = t.wsignal = null;

      for(t = GlobalVariables.layout; t != null; t = t.next) {

        /*	link signals with the track they control	*/

        if(t.type == trktype.TSIGNAL) {
          if((t.controls = GlobalFunctions.findTrack(t.wlinkx, t.wlinky)) == null)
            continue;
          if(t.direction == trkdir.W_E || t.direction == trkdir.S_N)
            t.controls.esignal = (Signal)t;
          else
            t.controls.wsignal = (Signal)t;
        }
      }
    }

    public static void link_all_tracks(Track layout) {
      Track t, l;

      l = null;
      for(t = GlobalVariables.layout; t != null; t = t.next)
        if(t.type == trktype.TRACK) {
          t.next1 = l;
          l = t;
        }
      GlobalVariables.track_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t.type == trktype.TSIGNAL) {
          t.next1 = l;
          l = t;
        }
      GlobalVariables.signal_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t.type == trktype.SWITCH) {
          t.next1 = l;
          l = t;
        }
      GlobalVariables.switch_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t.type == trktype.TEXT) {
          t.next1 = l;
          l = t;
        }
      GlobalVariables.text_list = l;
    }

    public static void link_all_tracks() {
      link_all_tracks(GlobalVariables.layout);
    }

    ///  TODO Check where this is called!
    public static void init_sim() {
      if(GlobalVariables.tool_layout == null)
        GlobalFunctions.init_tool_layout();
      GlobalVariables.time_mult = 10;
      GlobalVariables.cur_time_mult = 5;
      GlobalVariables.run_points = 0;
      GlobalVariables.total_delay = 0;
      GlobalVariables.total_late = 0;
      Array.Clear(GlobalVariables.late_data, 0, GlobalVariables.late_data.Length);
      GlobalVariables.alert_msg = "";
      string p;
      int i;
      for(i = 0; i < 7; ++i) {
        p = GlobalVariables.days_short_names[i];
        GlobalVariables.days_short_names[i] = wxPorting.LV(p);
      }
    }

    public static Track init_tool_from_array(edittools[] tbl) {
      int i;
      Track t;
      Track lst;

      lst = null;
      for(i = 0; (int)tbl[i].type != -1; ++i) {
        t = GlobalFunctions.track_new();
        tbl[i].trk = t;
        t.x = tbl[i].x;
        t.y = tbl[i].y;
        t.type = (trktype)tbl[i].type;
        t.direction = (trkdir)tbl[i].direction;
        t.norect = true;
        t.next = lst;
        if(t.type == trktype.TEXT)
          t.station = string.Copy(i == 0 ? wxPorting.T("Del") : wxPorting.T("Abc"));
        else if(t.type == trktype.ITIN)
          t.station = string.Copy(wxPorting.T("A"));
        else if(t.type == trktype.TSIGNAL && (((int)t.direction & 2) != 0)) {
          t.fleeted = true;
          t.direction = (trkdir)((int)t.direction & (~2));
        }
        lst = t;
      }
      return lst;
    }



    public static void init_tool_layout() {
      GlobalVariables.tool_layout = init_tool_from_array(GlobalVariables.tooltbl);	/* old way */
      GlobalVariables.tool_tracks = init_tool_from_array(GlobalVariables.tooltbltracks);/* new way */
      GlobalVariables.tool_switches = init_tool_from_array(GlobalVariables.tooltblswitches);
      GlobalVariables.tool_signals = init_tool_from_array(GlobalVariables.tooltblsignals);
      GlobalVariables.tool_misc = init_tool_from_array(GlobalVariables.tooltblmisc);
      GlobalVariables.tool_actions = init_tool_from_array(GlobalVariables.tooltblactions);
    }


    ///  TODO Check where this is called!
    public static void init_all() {
      while(GlobalVariables.layout != null)
        GlobalFunctions.track_delete(GlobalVariables.layout);
      GlobalVariables.onIconUpdateListeners.Clear();
      GlobalFunctions.clean_trains(GlobalVariables.schedule);
      GlobalVariables.schedule = null;
      GlobalFunctions.clean_trains(GlobalVariables.stranded);
      GlobalVariables.stranded = null;
      GlobalVariables.start_time = 0;
      GlobalFunctions.trainsim_init();
      GlobalFunctions.invalidate_field();
      GlobalFunctions.repaint_all();
    }

    ///  TODO Check where this is called!
    public static void trainsim_init() {
      Track t;
      Train trn;

      GlobalVariables.ntoolrows = 3;
      GlobalVariables.tooltbl = GlobalVariables.tooltbl800;
      if(GlobalVariables.tool_layout == null)
        GlobalFunctions.init_tool_layout();
      GlobalVariables.conf.fgcolor = GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRACK];
      GlobalVariables.conf.linkcolor = GlobalVariables.color_red;
      GlobalVariables.conf.linkcolor2 = GlobalVariables.color_blue;
      GlobalVariables.current_time = GlobalVariables.start_time;
      GlobalVariables.run_points = 0;
      GlobalVariables.total_delay = 0;
      GlobalVariables.total_late = 0;
      GlobalVariables.time_mult = 10;
      GlobalVariables.cur_time_mult = 5;
      GlobalVariables.alert_msg = "";
      GlobalVariables.perf_vals = GlobalVariables.hard_counters ? GlobalVariables.perf_hard : GlobalVariables.perf_easy;
      GlobalVariables.perf_tot = new perf();
      link_all_tracks();
      GlobalVariables.total_track_number = 0;
      for(t = GlobalVariables.track_list; t != null; t = t.next1)
        ++GlobalVariables.total_track_number;
      GlobalFunctions.reset_schedule();
      trn = GlobalVariables.schedule;
      GlobalVariables.schedule = GlobalVariables.stranded;
      GlobalVariables.stranded = null;
      GlobalFunctions.reset_schedule();
      GlobalVariables.schedule = trn;
      GlobalFunctions.fill_schedule(GlobalVariables.schedule, 0);
      GlobalFunctions.compute_train_numbers();
      GlobalFunctions.update_labels();
    }

    public static void time_step() {
      Train t, t1;
      Track trk;
      TrainStop stp;
      string buff;
      string buff1;
      int speed;
      int do_beep = 0;
      int nSecDelay;
      bool changed;

      GlobalVariables.current_time += 1;
      if((GlobalVariables.current_time % GlobalFunctions.HOUR(24)) == 0)
        GlobalFunctions.crossing_midnight();
      if(GlobalVariables.frply != null)		/* issue all commands for this time slice */
        GlobalFunctions.do_replay();
      for(t = GlobalVariables.schedule; t != null; t = t.next) {
        trk = null;
        if(t.isExternal)
          continue;
        switch(t.status) {
          case trainstat.train_ARRIVED:
            continue;

          case trainstat.train_READY:
            if(string.IsNullOrEmpty(t.entrance)) // || t.timein > current_time)
              continue;
            if(t.days != 0 && GlobalVariables.run_day != 0 && (t.days & GlobalVariables.run_day) == 0)
              continue;
            if(t.timein < GlobalVariables.start_time)	/* will always ignore it */
              continue;
            /* check delay 3 minutes before entry time */
            if((t.timein - 180 < GlobalVariables.current_time) && t._gotDelay == 0) {
              t._inDelay = GlobalFunctions.get_delay(t) * 60;
              if(t._inDelay == 0) {
                t._inDelay = GlobalFunctions.bstreet_enterdelay(t, out changed) * 60;
                t._inDelay += GlobalFunctions.selectDelay(t, t.entryDelay, out changed);
                if(changed)
                  GlobalFunctions.add_update_schedule(t);
              }
              t._gotDelay = (char)1;
            }
            if(t.timein + t._inDelay > GlobalVariables.current_time)
              continue;
            if(string.IsNullOrEmpty(t.waitfor) == false) {
              t1 = findTrainNamed(t.waitfor);
              if(t1 == null || t1.status != trainstat.train_ARRIVED)
                continue;
              if(t.waittime == 0)
                t.waittime = 60;	/* default we wait 60 seconds */
              if(t1.timeexited + t.waittime > GlobalVariables.current_time)
                continue;		/* can't depart, yet */
              buff1 = string.Copy(t1.exit);
#if false  // -Rask Ingemann Lambertsen
                          int i;
              for(i = 0; buff1[i] && buff1[i] != ' '; ++i);
              buff1[i] = 0;
#endif
              if((trk = GlobalFunctions.findStation(buff1)) != null && trk.type != trktype.TRACK)
                goto startit;		/* exited the layout - no need to assign */
              if(t.timedelay == 0) {		/* first time, issue an alert */
                buff = string.Format(wxPorting.L("You must assign train %s using stock from train %s!"),
                      t.name, t.waitfor);
                GlobalFunctions.do_alert(buff);
              }
              t.timedelay += GlobalVariables.time_mult;
              GlobalVariables.total_delay += GlobalVariables.time_mult;
              continue;
            }
            do_beep = 1;
          startit:
            buff1 = string.Copy(t.entrance);
#if false   // -Rask Ingemann Lambertsen
                      int i;
          for(i = 0; buff1[i] && buff1[i] != ' '; ++i);
          buff1[i] = 0;
#endif
          if(t.position != null)
            //change_coord(t.position.x, t.position.y);
            GlobalFunctions.leave_track(t);
          if((trk = GlobalFunctions.findEntryTrack(t, buff1)) == null) {
            GlobalFunctions.train_derailed(t, trk);
            continue;
          }
          t.path = GlobalFunctions.findPath0(t.path, trk, t.direction);
          if(t.path == null) {
            GlobalFunctions.train_derailed(t, trk);
            continue;
          }
          if(t.tail != null) {
            t.tail.path = GlobalFunctions.appendPath(t.tail.path, t.path);
            t.tail.tailentry = -t.length;
          }
          if(GlobalFunctions.pathIsBusy(null, t.path, t.direction) != 0) {
            if(t.status != trainstat.train_DELAY) {
              // first time, warn the player
              GlobalFunctions.new_train_status(t, trainstat.train_DELAY);
              GlobalFunctions.add_update_schedule(t);
              buff = string.Format(wxPorting.L("Train %s delayed at %s!"), t.name, buff1);
              do_alert(buff);
            } else {
              t.timedelay += GlobalVariables.time_mult;
              GlobalVariables.total_delay += GlobalVariables.time_mult;
              GlobalFunctions.add_update_schedule(t);
            }
            continue;
          }
          t.pathtravelled = 0;
        start_it:
          if(GlobalVariables.do_beep && GlobalVariables.beep_on_enter)
            GlobalFunctions.enter_beep();
        GlobalFunctions.new_train_status(t, trainstat.train_RUNNING);
        t.position = trk;
        //		t.pathpos = 1;	    /* 1 because trk is in path[0] */
        t.wrongdest = false;
        t.curspeed = t.maxspeed != 0 ? t.maxspeed : 60;
        t.curmaxspeed = (short)t.curspeed;
        t.trackpos = 0;
        speed = t.position.speed[t.type];
        if(speed != 0)
          speed = t.position.speed[0];
        if(speed != 0 && t.maxspeed != 0 && t.curspeed > speed) {
          t.curspeed = speed;
          t.curmaxspeed = (short)t.curspeed;
        } else if(speed != 0 && t.maxspeed == 0 && speed > t.curspeed) {
          t.curspeed = speed;
          t.curmaxspeed = (short)t.curspeed;
        }
        changed = true;
        GlobalFunctions.colorPath(t.path, trkstat.ST_GREEN);
        trk.SetColor(t.tail != null ? GlobalVariables.color_orange : GlobalVariables.conf.fgcolor);
        //		t.pathpos = 0;
        GlobalFunctions.findStopPoint(t);
        GlobalFunctions.findSlowPoint(t);
        //		t.pathpos = 1;
        if(trk.isstation)
          GlobalFunctions.train_at_station(t, trk);
        GlobalFunctions.add_update_schedule(t);
        t.OnEntry();
        continue;

          case trainstat.train_DELAY:
        if(t.path == null)
          goto startit;
        if(GlobalFunctions.pathIsBusy(null, t.path, t.direction) != null) {
          t.timedelay += GlobalVariables.time_mult;
          GlobalVariables.total_delay += GlobalVariables.time_mult;
          GlobalFunctions.add_update_schedule(t);
          break;
        }
        do_beep = 1;
        trk = t.path.TrackAt(0);
        goto start_it;

          case trainstat.train_STOPPED:
        trk = t.position;
        if(string.IsNullOrEmpty(trk.station) && t.tail != null && t.tail.path != null) {
          trk = GlobalFunctions.path_find_station(t.tail.path, t.position);
          if(trk == null)
            trk = t.position;
        }
        nSecDelay = 0;
        changed = false;
        if(trk != null && string.IsNullOrEmpty(trk.station) == false) {
          stp = findStop(t, trk);
          if(stp != null) {
            nSecDelay = GlobalFunctions.selectDelay(t, stp.depDelay, out changed);
          } else if(sameStation(trk.station, t.entrance)) {
            nSecDelay = GlobalFunctions.selectDelay(t, t.entryDelay, out changed);
          }
        }
        t.flags |= TFLG.TFLG_GOTDELAYATSTOP;

        if(changed)
          GlobalFunctions.add_update_schedule(t);
        if(t.timedep + nSecDelay > GlobalVariables.current_time)
          continue;
        if((t.flags & (TFLG.TFLG_WAITINGMERGE | TFLG.TFLG_MERGING)) != 0)
          continue;
        GlobalFunctions.new_train_status(t, trainstat.train_RUNNING);
        t.OnStart();
        if(t.timedep > GlobalVariables.current_time) {
          GlobalFunctions.new_train_status(t, trainstat.train_STOPPED);
          continue;
        }
        t.flags &= TFLG.TFLG_ENTEREDLATE;	/* clear performance flags */
        GlobalFunctions.findStopPoint(t);	/* find next stop point */
        t.needfindstop = (char)1;
        GlobalFunctions.new_train_status(t, trainstat.train_RUNNING);
        goto runit;

          case trainstat.train_STARTING:        // 3.8i

        if(--t.startDelay > 0) {
          GlobalFunctions.add_update_schedule(t);
          break;
        }
        t.startDelay = 0;

        // After the STARTING delay has expired, we need
        // to call fetch_path() again so that we can advance
        // past the signal, and also to check if the signal
        // is still cleared.
        //
        // So, fall through...
        goto case trainstat.train_WAITING;

          case trainstat.train_WAITING:
        if((t.flags & TFLG.TFLG_WAITINGMERGE) != 0)
          continue;
        switch(GlobalFunctions.fetch_path(t)) {
          case 0:
            // we could not enter the path, maybe because the user
            // has closed the signal while we were starting,
            // so go back to WAITING state
            if(t.status == trainstat.train_STARTING && t.startDelay == 0)
              GlobalFunctions.new_train_status(t, trainstat.train_WAITING);
            continue;
          case -1:
            GlobalFunctions.train_derailed(t, null);
            continue;
        }
        t.outof = null;		/* in case we are moving from
                 * one platform to another, we
                 * want to stop at the same station.
                 */
        goto case trainstat.train_RUNNING;


          case trainstat.train_RUNNING:
      /*case train_SHUNTING:*/
      runit:
        t.flags &= ~(TFLG.TFLG_TURNED | TFLG.TFLG_GOTDELAYATSTOP);
      if(GlobalFunctions.run_train(t) == -1)
        GlobalFunctions.train_derailed(t, null);
      else
        GlobalFunctions.add_update_schedule(t);
      continue;
        }
      }
    }


    public static void Trace(string msg) {
      //if(!trace_script)
      //    return;
      //traindir.AddAlert(msg);
    }

    public static int toggle_signal(Signal t) {
      return toggle_signal_auto(t, true);
    }

    public static void onIconUpdateAll() {
      int i;

      for(i = GlobalVariables.onIconUpdateListeners.Length(); --i >= 0; ) {
        Track trk = GlobalVariables.onIconUpdateListeners.At(i);
        trk.OnIconUpdate();
      }
    }

    public static Track findTrack(int x, int y) { return GlobalFunctions.findTrackType(x, y, trktype.TRACK); }
    public static Track findSwitch(int x, int y) { return GlobalFunctions.findTrackType(x, y, trktype.SWITCH); }
    public static Signal findSignal(int x, int y) { return (Signal)GlobalFunctions.findTrackType(x, y, trktype.TSIGNAL); }
    public static Track findPlatform(int x, int y) { return GlobalFunctions.findTrackType(x, y, trktype.PLATFORM); }
    public static Track findText(int x, int y) { return GlobalFunctions.findTrackType(x, y, trktype.TEXT); }
    public static Track findImage(int x, int y) { return GlobalFunctions.findTrackType(x, y, trktype.IMAGE); }

    public static Track findTrackType(int x, int y, trktype type) {
      Track t;

      switch(type) {
        case trktype.TRACK:
          return find_in_list(GlobalVariables.track_list, x, y);
        case trktype.TSIGNAL:
          return find_in_list(GlobalVariables.signal_list, x, y);
        case trktype.SWITCH:
          return find_in_list(GlobalVariables.switch_list, x, y);
        case trktype.TEXT:
          return find_in_list(GlobalVariables.text_list, x, y);
      }
      for(t = GlobalVariables.layout; t != null; t = t.next)
        if(t.x == x && t.y == y && t.type == type)
          return t;
      return null;
    }

    public static Track find_in_list(Track t, int x, int y) {
      for(; t != null; t = t.next1)
        if(t.x == x && t.y == y)
          return t;

      return null;
    }



    /// TODO Uncomment this function
    public static void reset_schedule() {
      Train t;
      TrainStop ts;

      for(t = GlobalVariables.schedule; t != null; t = t.next) {
        if(t.tail != null) {
          if(t.tail.path != null) {
            colorPartialPath(t.tail.path, trkstat.ST_FREE, 0); //t.tail.pathpos);
            Vector_delete(t.tail.path);
            t.tail.path = null;
          }
          t.tail.position = null;
        }
        if(t.path != null) {
          colorPartialPath(t.path, trkstat.ST_FREE, 0); //t.pathpos);
          Vector_delete(t.path);
        }
        t.path = null;
      }
      GlobalVariables.ntrains_arrived = 0;
      GlobalVariables.ntrains_stopped = 0;
      GlobalVariables.ntrains_waiting = 0;
      GlobalVariables.ntrains_running = 0;
      GlobalVariables.ntrains_starting = 0;
      GlobalVariables.ntrains_ready = 0;
      for(t = GlobalVariables.schedule; t != null; t = t.next) {
        if(t.fleet != null)
          Vector_delete(t.fleet);
        t.fleet = null;
        t.status = trainstat.train_READY;
        ++GlobalVariables.ntrains_ready;
        t.direction = t.sdirection;
        t.exited = null;
        t.timeexited = 0;
        t.wrongdest = false;
        t.curspeed = 0;
        t.curmaxspeed = 0;
        t.trackpos = 0;
        t.timelate = 0;
        t.timedelay = 0;
        t.timered = 0;
        //	    t.pathpos = 0;
        t.position = null;
        t.timedep = 0;
        t.arrived = false;
        t.timeexited = 0;
        t.shunting = false;
        t.stopping = null;
        t.merging = null;
        t._gotDelay = (char)0;
        t._inDelay = 0;
        t.startDelay = 0;
        // first time after load myStartDelay will be 0 if not set for this train,
        // so we need to use the type-specific start delay.
        if(t.myStartDelay == 0 && GlobalVariables.startDelay[t.type] != 0)
          t.myStartDelay = GlobalVariables.startDelay[t.type];
        // same for acceleration rate
        if(t.accelRate == 0 && GlobalVariables.accelRate[t.type] != 0)
          t.accelRate = GlobalVariables.accelRate[t.type];
        t.flags &= ~(TFLG.TFLG_GOTDELAYATSTOP | TFLG.TFLG_SETLATEARRIVAL);
        if(t.entryDelay != null)
          t.entryDelay.nSeconds = 0;
        t.length = t.entryLength;
        if(t.length != 0 && t.tail == null) {
          // tail could have become 0 if train had exited
          // or it was assigned or it was split
          t.tail = (Train)calloc(sizeof(Train), 1);
        }
        for(ts = t.stops; ts != null; ts = ts.next) {
          ts.late = (char)0;
          ts.delay = 0;
          ts.stopped = (char)0;
          if(ts.depDelay != null)
            ts.depDelay.nSeconds = 0;
        }
      }
      memset(late_data, 0, sizeof(late_data));
    }


    /// TODO Uncomment this function
    public static void fill_schedule(Train tr, int assign) {
      ///* Here we do the actual adding of the text. It's done once for
      // * each row.
      // */

      //int i, tt;
      //TimeTableView* clist;
      //Train* t;
      //wxImageList* icons = new wxImageList(48, 16);

      //if(listed_trains)
      //  free(listed_trains);
      //listed_trains = 0;
      //num_listed_trains = 0;
      //for(t = tr; t; t = t.next)
      //  ++num_listed_trains;
      //if(num_listed_trains)
      //  listed_trains = (Train**)calloc(sizeof(Train*), num_listed_trains);
      //for(tt = 0; tt < NUMTTABLES; ++tt) {
      //  clist = traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
      //  if(!clist)
      //    continue;
      //  clist.DeleteAllItems();
      //  clist.Freeze();
      //  i = 0;
      //  for(t = tr; t; t = t.next) {
      //    /* when reassigning train stock, we consider only
      //        trains that are scheduled to depart at the same
      //        station where the assignee has arrived. */
      //    ///		if(assign && (t.status != train_READY ||
      //    ///			    !sameStation(oldtrain.position.station, t.entrance)))
      //    ///		    continue;
      //    if(!t.entrance)
      //      continue;
      //    if(ignore_train(t))
      //      continue;

      //    if(show_canceled || !is_canceled(t)) {
      //      //print_train_info(t);
      //      TrainInfo info;
      //      t.Get(info);
      //      clist.InsertItem(i, info.entering_time, t.epix);
      //      clist.UpdateItem(i, t);
      //      listed_trains[i] = t;
      //      ++i;
      //    }
      //  }
      //  clist.Thaw();
      //}
    }

    public static void compute_train_numbers() {
      Train t;

      GlobalVariables.ntrains_arrived = 0;
      GlobalVariables.ntrains_waiting = 0;
      GlobalVariables.ntrains_stopped = 0;
      GlobalVariables.ntrains_ready = 0;
      GlobalVariables.ntrains_starting = 0;
      GlobalVariables.ntrains_running = 0;
      for(t = GlobalVariables.schedule; t != null; t = t.next) {
        switch(t.status) {
          case trainstat.train_READY:
            if(GlobalVariables.run_day == 0 || ((t.days & GlobalVariables.run_day) != 0))
              ++GlobalVariables.ntrains_ready;
            break;
          case trainstat.train_STARTING:
            ++GlobalVariables.ntrains_starting;
            break;
          case trainstat.train_RUNNING:
            ++GlobalVariables.ntrains_running;
            break;
          case trainstat.train_WAITING:
            ++GlobalVariables.ntrains_waiting;
            break;
          case trainstat.train_STOPPED:
            ++GlobalVariables.ntrains_stopped;
            break;
          case trainstat.train_ARRIVED:
            ++GlobalVariables.ntrains_arrived;
            break;
        }
      }
    }

    public static void update_labels() {
      GlobalVariables.time_msg = string.Copy(wxPorting.T("   "));
      if(GlobalVariables.show_seconds)
        GlobalVariables.time_msg =
          GlobalVariables.time_msg.Substring(0, 3) +
          String.Format(wxPorting.T("%3ld:%02ld.%02ld "), (GlobalVariables.current_time / 3600) % 24,
            (GlobalVariables.current_time / 60) % 60,
            GlobalVariables.current_time % 60);
      else
        GlobalVariables.time_msg =
  GlobalVariables.time_msg.Substring(0, 3) +
GlobalFunctions.format_time(GlobalVariables.current_time);

      // show name of current day, if any
      if(GlobalVariables.run_day != 0) {
        int i;
        for(i = 0; i < 7 && ((int)GlobalVariables.run_day & (1 << i)) == 0; ++i) ;
        if(i < 7) {
          GlobalVariables.time_msg += String.Format(wxPorting.T(" ({0}) "), GlobalVariables.days_short_names[i]);
        }
      }
      GlobalVariables.time_msg += String.Format(wxPorting.T("   x{0}    "), GlobalVariables.time_mult);
      GlobalVariables.time_msg += String.Format(wxPorting.T("R %d/S %d/r %d/w %d/s %d/a %d"),
          GlobalVariables.ntrains_running, GlobalVariables.ntrains_starting, GlobalVariables.ntrains_ready, GlobalVariables.ntrains_waiting,
          GlobalVariables.ntrains_stopped, GlobalVariables.ntrains_arrived);
      GlobalVariables.total_points_msg = String.Format(wxPorting.T("Pt:%4ld, Del:%4ld, Late:%4ld"),
              -GlobalFunctions.performance(), GlobalVariables.total_delay / 60, GlobalVariables.total_late);
      GlobalFunctions.repaint_labels();
    }

    public static void train_print(Train t, HtmlPage page) {
      TrainStop ts;
      string buff;
      int i;
      string beg, end;
      int status;
      string[] buffs = new string[7];
      string[] cols = new string[7];

      buff = String.Format(wxPorting.T("{0} {1}"), wxPorting.L("Train"), t.name);
      page.StartPage(buff);
      cols[0] = wxPorting.L("Station");
      cols[1] = wxPorting.L("Arrival");
      cols[2] = wxPorting.L("Departure");
      cols[3] = wxPorting.L("Min.stop");
      cols[4] = null /*"Stopped";
	cols[5] = "Delay";
	cols[6] = 0*/
                   ;
      page.StartTable(cols);
      cols[0] = buffs[0];
      cols[1] = buffs[1];
      cols[2] = buffs[2];
      cols[3] = buffs[3];
      cols[4] = null; /*buffs[4];
	cols[5] = buffs[5];
	cols[6] = 0; */

      status = 0;
      beg = wxPorting.T("");
      end = wxPorting.T("");
      for(ts = t.stops; ts != null; ts = ts.next) {
        if(ts.arrival >= t.timein/* && findStation(ts.station)*/) {
          if(status == 0) {
            buffs[0] += String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.entrance, t.entrance); cols[0] = buffs[0];
            buffs[1] += String.Format(wxPorting.T("&nbsp;")); cols[1] = buffs[1];
            buffs[2] += String.Format(wxPorting.T("<b>%s</b>"), GlobalFunctions.format_time(t.timein)); cols[2] = buffs[2];
            buffs[3] += String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
            cols[4] = null;
            page.AddTableRow(cols);
            status = 1;
          }
        }
        if(ts.arrival > t.timeout && status == 1) {
          buffs[0] += String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.exit, t.exit); cols[0] = buffs[0];
          buffs[1] += String.Format(wxPorting.T("<b>%s</b>"), GlobalFunctions.format_time(t.timeout)); cols[1] = buffs[1];
          buffs[2] += String.Format(wxPorting.T("&nbsp;")); cols[2] = buffs[2];
          buffs[3] += String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
          cols[4] = null;
          page.AddTableRow(cols);
          status = 2;
        }
        int pos = wxPorting.T(Configuration.PLATFORM_SEP);
        buffs[0] = (pos >= 0) ? ts.station.Substring(0, pos - 1) : ts.station;
        if(GlobalFunctions.findStationNamed(buffs[0]) != null) { beg = wxPorting.T("<b>"); end = wxPorting.T("</b>"); } else { beg = wxPorting.T(""); end = wxPorting.T(""); }
        buffs[0] += String.Format(wxPorting.T("%s<a href=\"stationinfopage %s\">%s</a>%s"), beg, ts.station, ts.station, end); cols[0] = buffs[0];
        if(ts.arrival == 0 || ts.minstop == 0)
          cols[1] = wxPorting.T("&nbsp;");
        else
          buffs[1] += String.Format(wxPorting.T("%s%s%s"), beg, format_time(ts.arrival), end); cols[1] = buffs[1];
        buffs[2] += String.Format(wxPorting.T("%s%s%s"), beg, format_time(ts.departure), end); cols[2] = buffs[2];
        if(status != 1)
          cols[3] = wxPorting.T("&nbsp;");
        else
          buffs[3] += String.Format(wxPorting.T("%ld"), ts.minstop); cols[3] = buffs[3];
        /*	    sprintf(cols[4], ts.stopped ? "<b>Yes</b>" : "<b>No</b>");
              sprintf(cols[5], "%s%ld%s", beg, (long)ts.delay, end);
        */
        cols[4] = null;
        page.AddTableRow(cols);
      }
      if(status < 1) {
        buffs[0] += String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.entrance, t.entrance); cols[0] = buffs[0];
        buffs[1] += String.Format(wxPorting.T("&nbsp;")); cols[1] = buffs[1];
        buffs[2] += String.Format(wxPorting.T("<b>%s</b>"), GlobalFunctions.format_time(t.timein)); cols[2] = buffs[2];
        buffs[3] += String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
        cols[4] = null;
        page.AddTableRow(cols);
        ++status;
      }
      if(status < 2) {
        buffs[0] += String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.exit, t.exit); cols[0] = buffs[0];
        buffs[1] += String.Format(wxPorting.T("<b>%s</b>"), GlobalFunctions.format_time(t.timeout)); cols[1] = buffs[1];
        buffs[2] += String.Format(wxPorting.T("&nbsp;")); cols[2] = buffs[2];
        buffs[3] += String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
        cols[4] = null;
        page.AddTableRow(cols);
      }
      page.EndTable();
      page.Add(wxPorting.T("<blockquote><blockquote>\n"));
      if(t.days != 0) {
        buff += String.Format(wxPorting.T("%s : "), wxPorting.L("Runs on"));
        for(i = 0; i < 7; ++i)
          if(((int)t.days & (1 << i)) != 0)
            buff += String.Format(wxPorting.T("%d"), i + 1);
        page.AddLine(buff);
      }
      if(t.nnotes != 0) {
        buff += String.Format(wxPorting.T("%s: "), wxPorting.L("Notes"));
        page.Add(buff);
        for(status = 0; status < t.nnotes; ++status) {
          buff += String.Format(wxPorting.T("%s.<br>\n"), t.notes[status]);
          page.Add(buff);
        }
      }
      page.AddLine(wxPorting.T("</blockquote></blockquote>"));
      page.EndPage();
    }


    ///  TODO Check where this is called!
    public static void default_prefs() {
      GlobalVariables.terse_status = 1;
      GlobalVariables.status_on_top = 1;
      GlobalVariables.beep_on_alert = true;
      GlobalVariables.beep_on_enter = false;
      GlobalVariables.show_speeds = true;
      GlobalVariables.auto_link = 1;
      GlobalVariables.link_to_left = 0;
      GlobalVariables.show_grid = false;
      GlobalVariables.show_blocks = true;
      GlobalVariables.show_seconds = false;
      GlobalVariables.show_icons = true;
      GlobalVariables.signal_traditional = false;
      GlobalVariables.hard_counters = false;
      GlobalVariables.random_delays = 1;
      GlobalVariables.save_prefs = 1;
      GlobalVariables.bShowCoord = true;
    }

    public static long performance() {
      long tot;

      tot = GlobalVariables.perf_tot.wrong_dest * GlobalVariables.perf_vals.wrong_dest;
      tot += GlobalVariables.perf_tot.late_trains * GlobalVariables.perf_vals.late_trains;
      tot += GlobalVariables.perf_tot.thrown_switch * GlobalVariables.perf_vals.thrown_switch;
      tot += GlobalVariables.perf_tot.cleared_signal * GlobalVariables.perf_vals.cleared_signal;
      tot += GlobalVariables.perf_tot.turned_train * GlobalVariables.perf_vals.turned_train;
      tot += GlobalVariables.perf_tot.waiting_train * GlobalVariables.perf_vals.waiting_train;
      tot += GlobalVariables.perf_tot.wrong_platform * GlobalVariables.perf_vals.wrong_platform;
      tot += GlobalVariables.perf_tot.denied * GlobalVariables.perf_vals.denied;
      return tot;
    }

    public static void record_state() { }

    ///  TODO Uncomment this function
    public static void assign_train(Train t, Train oldtrain) {
      //if(oldtrain.stock && wxStrcmp(t.name, oldtrain.stock))
      //  ++perf_tot.wrong_assign;
      /////	if(oldtrain.status != train_ARRIVED) {
      /////	    train_arrived(oldtrain);
      /////	    add_update_schedule(oldtrain);
      /////	}

      //if(oldtrain.flags & TFLG_STRANDED) {
      //  oldtrain.path = findPath(oldtrain.position, oldtrain.direction);
      //  if(!oldtrain.path) {
      //    ++perf_tot.denied;
      //    update_labels();
      //    return;
      //  }
      //  if(pathIsBusy(oldtrain, oldtrain.path, oldtrain.direction)) {
      //    Track* nxtrk = oldtrain.path.TrackAt(1);
      //    if(nxtrk.fgcolor != color_green) {
      //      do_alert(L("Cannot restart train. Path is busy."));
      //      Vector_delete(oldtrain.path);
      //      oldtrain.path = 0;
      //      ++perf_tot.denied;
      //      update_labels();
      //      return;
      //    }
      //  }
      //  if(oldtrain.tail && oldtrain.tail.path) {
      //    appendPath(oldtrain.tail.path, oldtrain.path);
      //  }
      //  colorPath(oldtrain.path, ST_GREEN);
      //  findStopPoint(oldtrain);
      //  findSlowPoint(oldtrain);
      //}

      //if((t.arrived || t.oldstatus == train_ARRIVED) && t.merging) {// we are shunting
      //  new_train_status(t, train_ARRIVED);
      //  t.stopping = 0;
      //  t.curspeed = 0;
      //  t.shunting = 0;
      //  t.outof = 0;
      //} else
      //  new_train_status(t, train_STOPPED);	// train_at_station
      //update_labels();
      ////	changed = 1;
      //if(oldtrain.status == train_ARRIVED && !oldtrain.position) {
      //  return;
      //}
      //t.path = oldtrain.path;
      //t.position = oldtrain.position;
      ////	t.pathpos = oldtrain.pathpos;
      //t.direction = oldtrain.direction;
      //t.curmaxspeed = oldtrain.curmaxspeed;
      //if(!t.maxspeed)
      //  t.maxspeed = oldtrain.maxspeed;
      //// the new train departs in the morning, but the old train arrived in the afternoon
      //// this means the new train will start in the following day, so add 24 hours
      //if(t.timein < HOUR(12) && oldtrain.timeexited >= HOUR(12))
      //  t.timedep = t.timein + HOUR(24);
      //else
      //  t.timedep = t.timein;
      //if(t.waitfor) {
      //  if(!t.waittime)
      //    t.waittime = 60;	/* default we wait 60 seconds */
      //}
      ///*
      //  if(!t._inDelay) {
      //      bool    changed;
      //      t._inDelay = selectDelay(t, t.entryDelay, &changed);
      //      if(changed)
      //    add_update_schedule(t);
      //  }
      //  t._gotDelay = 1;
      //  if(t._inDelay) {
      //      t.timedep += t._inDelay;
      //  }
      //  */
      //if(oldtrain.tail) {
      //  if(!t.tail) {
      //    t.length = oldtrain.length;
      //    t.tail = (Train*)calloc(sizeof(Train), 1);
      //    t.ecarpix = oldtrain.ecarpix;
      //    t.wcarpix = oldtrain.wcarpix;
      //  }
      //  if((oldtrain.flags & TFLG_STRANDED) && t.tail.path) {
      //    // extend stranded train's tail path with incoming train's tail path
      //    oldtrain.tail.path.Insert(t.tail.path);
      //    oldtrain.tail.position = t.tail.path.TrackAt(0);
      //    oldtrain.tail.trackpos = t.tail.trackpos;
      //  } else {

      //    /* here we are assigning the material of a train
      //     * already in the territory (oldtrain) to a train
      //     * which is not on the territory (t).
      //     * We should check that the preset length of the
      //     * destination train is the same as that of the old train.
      //     * If it is, then we can simply copy the path to the
      //     * destination train.
      //     * If the destination train is longer, we should
      //     * notify the player that we don't have enough rolling
      //     * stock, and add to the penalty.
      //     * If the destination train is longer we should split
      //     * the source in two, and leave some cars in the path.
      //     *
      //     * For the time being we simply assign the source train
      //     * to the destination train.
      //     */

      //  }
      //  t.tail.path = oldtrain.tail.path;
      //  //	    t.tail.pathpos = oldtrain.tail.pathpos;
      //  t.tail.position = oldtrain.tail.position;
      //  t.tail.trackpos = oldtrain.tail.trackpos;
      //  t.fleet = oldtrain.fleet;
      //  oldtrain.fleet = 0;
      //  oldtrain.tail.path = 0;
      //  //	    oldtrain.tail.pathpos = 0;
      //  oldtrain.tail.trackpos = 0;
      //  oldtrain.tail.position = 0;
      //}
      //// maybe the assignment was initiated by a trigger
      //if(oldtrain.status != train_ARRIVED) {
      //  train_arrived(oldtrain);
      //  oldtrain.OnArrived();
      //  //	    add_update_schedule(oldtrain);
      //}
      //if(t.waitfor) {
      //  if(oldtrain.timeexited + t.waittime > t.timedep)
      //    t.timedep = oldtrain.timeexited + t.waittime;
      //}
      ////	oldtrain.pathpos = 0;
      //oldtrain.path = 0;
      //oldtrain.position = 0;
      //if(oldtrain.flags & TFLG_STRANDED) {
      //  remove_from_stranded_list(oldtrain);
      //  change_coord(t.position.x, t.position.y);
      //  update_schedule(oldtrain);	// to remove from list
      //  delete oldtrain;
      //} else {
      //  change_coord(t.position.x, t.position.y);
      //  update_schedule(oldtrain);	// to remove from list
      //}
      //update_schedule(t);
      //t.OnAssign();
    }

    public static void update_schedule(Train t) {
      int i;
      Train t0;

      for(i = 0, t0 = GlobalVariables.schedule; t0 != null && t0 != t; t0 = t0.next) {
        if(string.IsNullOrEmpty(t.entrance))
          continue;
        if(GlobalVariables.show_canceled || !GlobalFunctions.is_canceled(t0))
          ++i;
      }
      if(t0 == null)
        return;

      GlobalFunctions.gr_update_schedule(t, i);
      t.newsched = 0;
      t._lastUpdate = GlobalVariables.lastModTime++;
    }

    public static int HOUR(int h) { return ((h) * 60 * 60); }

    public static void crossing_midnight() {
      Train t;
      TrainStop ts;

      for(t = GlobalVariables.schedule; t != null; t = t.next) {
        if(t.timein < GlobalFunctions.HOUR(12))
          t.timein += GlobalFunctions.HOUR(24);
        if(t.timeout < GlobalFunctions.HOUR(12))
          t.timeout += GlobalFunctions.HOUR(24);
        for(ts = t.stops; ts != null; ts = ts.next) {
          if(ts.arrival < GlobalFunctions.HOUR(12))
            ts.arrival += GlobalFunctions.HOUR(24);
          if(ts.departure < GlobalFunctions.HOUR(12))
            ts.departure += GlobalFunctions.HOUR(24);
        }
      }
    }

    ///  TODO Uncomment this function
    public static void do_replay() {
      //long issue_time;
      //int pos;
      //string p;
      //string buff;

      //while(GlobalVariables.frply != null) {
      //  pos = GlobalVariables.frply.GetPos();
      //  if(!GlobalVariables.frply.ReadLine(buff))
      //    break;
      //  // buff[sizeof(buff)/sizeof(buff[0]) - 1] = 0;
      //  p = buff + wxStrlen(buff);
      //  if(p > buff && p[-1] == '\n') --p;
      //  if(p > buff && p[-1] == '\r') --p;
      //  *p = 0;
      //  issue_time = wxStrtoul(buff, &p, 10);
      //  if(*p == ',') ++p;
      //  if(issue_time > GlobalVariables.current_time) {	/* goes into next time slice */
      //    GlobalVariables.frply.SetPos(pos);		/* back off to cmd start */
      //    return;				/* nothing else to do */
      //  }
      //  trainsim_cmd(p);
      //}
      //if(GlobalVariables.frply != null) {
      //  GlobalVariables.frply = null;
      //}
    }

    /// TODO Uncomment this function
    public static int get_delay(Train t) {
      return 0;

      //  int	delay = 0;
      //#ifdef WIN32
      //  wxHTTP	get;

      //  if(!use_real_time)
      //      return 0;

      //  get.SetHeader(_T("Content-type"), _T("text/html; charset=utf-8"));
      //  get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...

      //  // this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
      //  while (!get.Connect(_T("mobile.viaggiatreno.it")))  // only the server, no pages here yet ...
      //      wxSleep(5);

      //  traindir.IsMainLoopRunning(); // should return true

      //  wxChar buff[256];
      //  int i, j = 0;

      //  for(i = 0; t.name[i]; ++i) {
      //      if(!wxIsdigit(t.name[i]))
      //    continue;
      //      buff[j++] = t.name[i];
      //  }
      //  buff[j] = 0;

      //  wxChar	url[256];

      //  wxSnprintf(url, sizeof(url), wxPorting.T("/viaggiatreno/mobile/scheda?numeroTreno=%s&tipoRicerca=numero"), buff);
      //  // use _T("/") for index.html, index.php, default.asp, etc.
      //  wxInputStream *httpStream = get.GetInputStream(url);

      //  // wxLogVerbose( wxString(_T(" GetInputStream: ")) << get.GetResponse() << _T("-") << ((resStream)? _T("OK ") : _T("FAILURE ")) << get.GetError() );

      //  if (get.GetError() == wxPROTO_NOERR)
      //  {
      //      wxString res;
      //      wxStringOutputStream out_stream(&res);
      //      httpStream.Read(out_stream);
      //      //wxMessageBox(res);

      //      const Char *p = res.c_str();
      //      const Char *line = p;

      //      if((p = locate(p, wxPorting.T("<!-- SITUAZIONE")))) {
      //    while(*p && wxStrncmp(p, wxPorting.T("minuti di ritardo"), 17)) {
      //        ++p;
      //        if(*p == '\n')
      //      line = p;
      //    }
      //    if(*p) {
      //        for(p = line; *p && !wxIsdigit(*p); ++p);
      //        if(wxIsdigit(*p))
      //      delay = wxAtoi(p);
      //    }
      //      }

      //      // wxLogVerbose( wxString(_T(" returned document length: ")) << res.Length() );
      //  }
      //  else
      //  {
      //      wxMessageBox(_T("Unable to connect!"));
      //  }

      //  wxDELETE(httpStream);
      //  get.Close();
      //#endif
      //return delay;
    }

    /// TODO Uncomment this function
    public static int bstreet_enterdelay(Train trn, out bool changed) {
      changed = false;
      return 0;
      //      int delay = 0;
      //      if(user_name._sValue.Length() == 0)
      //          return 0;

      //      Char    url[256];
      //      Char    tname[256];
      //      prepareTrainName(tname, trn.name);
      //      //http://backerstreet.com/traindir/server/entering.php?s=bartSF.trk&t=01DCM2SUN_merged_2075&f=OAK1&d=64
      //      wxSnprintf(url, sizeof(url)/sizeof(Char),
      //          wxPorting.T("/traindir/server/entering.php?&s=%s&t=%s&f=%s&d=%d"),
      //          fileName(current_project.c_str()),
      //          tname,
      //          trn.entrance,
      //          run_day);
      //wxHTTP	get;
      //get.SetHeader(_T("Content-type"), _T("text/html; charset=utf-8"));
      //get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...

      //// this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
      //      if(!get.Connect(_T("www.backerstreet.com")))  // only the server, no pages here yet ...
      //    return 0;
      //      wxInputStream *stream = get.GetInputStream(url);
      //      // we don't care about the result or any error
      //if (get.GetError() == wxPROTO_NOERR) {
      //    wxString res;
      //    wxStringOutputStream out_stream(&res);
      //    stream.Read(out_stream);
      //    //wxMessageBox(res);

      //    const Char *line = res.c_str();
      //    const Char *p;
      //          if((p = wxStrchr(line, '#'))) {
      //              delay = wxAtoi(p + 1);
      //              *changed = true;
      //          }
      //      }
      //      wxDELETE(stream);
      //      get.Close();
      //      return delay;
    }

    public static int selectDelay(Train t, TDDelay del, out bool changed) {
      changed = false;

      if(del == null || GlobalVariables.random_delays == 0)
        return 0;
      if(del.nDelays == 0)
        return 0;
      if((t.flags & TFLG.TFLG_GOTDELAYATSTOP) != 0)
        return del.nSeconds;
      if(del.nSeconds == 0) {
        int r = GlobalFunctions.rand() % 100;
        for(int i = 0; i < del.nDelays; ++i) {
          if(r < del.prob[i]) {
            changed = true;
            del.nSeconds = del.seconds[i];
            t.flags |= TFLG.TFLG_ENTEREDLATE;
            break;
          }
        }
      }
      return del.nSeconds;
    }

    public static int rand() {
      /// TODO Implement this like stdlib rand()
      return 0;
    }

    public static void add_update_schedule(Train trn) {
      trn.newsched = 1;
    }

    public static Track findStation(string name) {
      Track t, l;

      for(t = GlobalVariables.layout; t != null; t = t.next) {
        if(t.type == trktype.TRACK && t.isstation)
          if(name.Equals(t.station))
            return t;
        if(t.type == trktype.TEXT && name.Equals(t.station) &&
          ((t.wlinkx != 0 && t.wlinky != 0) || (t.elinkx != 0 && t.elinky != 0)))
          return t;
        l = t;
      }
      return null;
    }

    /*	leave_track
 *
 *	The train is about to move away from the
 *	current cell.
 *	Update the cells that are affected by this
 *	train.
 *	When a train has an icon, we need to know
 *	how many cells the icon covers so that they
 *	are marked to be redrawn at the next refresh.
 */
    /// TODO Uncomment this function
    public static void leave_track(Track position, trkdir direction, Train trn, bool delayOnExit) {
      Image map;
      int idx;
      Coord size = new Coord();
      Coord pos = new Coord();

      if(position == null)	// train's head has exited the layout
        return;
      pos.Set(position.x, position.y);
      if(GlobalVariables.draw_train_names) {
        GlobalFunctions.get_text_size(trn.name, size);
        size.y = ((size.y + Configuration.VGRID - 1) / Configuration.VGRID);// * VGRID; // round up to next cell
        pos.y -= 1; //(size.y / 2) / (VGRID / 2) + 1; // text is centered, so we need to clear the cell above
        size.y += 1;
        size.x = ((size.x + Configuration.HGRID - 1) / Configuration.HGRID);// * HGRID; // round up to next cell
        pos.x -= 2;         // text is left-aligned, so we need to clear one before and one after
        size.x += 4;
      } else {
        idx = direction == trkdir.W_E ? trn.epix : trn.wpix;
        if(GlobalVariables.pixmaps != null && idx != -1)
          map = GlobalVariables.pixmaps[idx].pixels;
        else
          map = direction == trkdir.W_E ? GlobalVariables.e_train_pmap[trn.type] : GlobalVariables.w_train_pmap[trn.type];
        GlobalFunctions.get_pixmap_size(map, size);
        size.x = size.x / Configuration.HGRID + 1;
        size.y = size.y / Configuration.VGRID + 1;
      }
      if(!delayOnExit)
        position.OnExit(trn);
      change_coord(pos.x, pos.y, size.x, size.y);
    }

    public static void leave_track(Train trn) {
      leave_track(trn.position, trn.direction, trn, trn.tail != null ? true : false);
    }

    /// TODO Uncomment this function
    public static void train_derailed(Train trn) {
      //trn.curspeed = 0;
      //new_train_status(trn, train_DERAILED);
      ////change_coord(t.position.x, t.position.y);
      //leave_track(trn);
      //trn.position = 0;
      //// TODO: if train has a tail, remove it, too!
      //add_update_schedule(trn);
    }

    /// TODO Uncomment this function
    public static void train_derailed(Train trn, Track trk) {
      //Char	buff[256];

      //      new_train_status(trn, train_DERAILED);
      //      trn.position = 0;
      //      add_update_schedule(trn);
      //      if(trk)
      //          wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), L("Train %s derailed at %d,%d!"), trn.name, trk.x, trk.y);
      //      else
      //          wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), L("Train %s derailed!"), trn.name);
      //      do_alert(buff);
    }


    /*	FindEntryTrack
     *
     *	Find the entry point of a train and
     *	the train's initial direction.
     *	By convention, if the entry point string
     *	is to the left of the track, the direction
     *	will be eastbound. Similarly if the string
     *	is above a vertical track, the direction will
     *	be southbound.
     */

    /// TODO Uncomment this function
    public static Track findEntryTrack(Train tr, string entrance) {
      return null;
      //Track	*t, *st;
      //int	x, y;

      //st = findStation(entrance);
      //if(!st)
      //    return 0;
      //if(st.elinkx && st.elinky) {
      //    tr.direction = W_E;
      //    x = st.elinkx;
      //    y = st.elinky;
      //} else if(st.wlinkx && st.wlinky) {
      //    tr.direction = E_W;
      //    x = st.wlinkx;
      //    y = st.wlinky;
      //} else
      //    return 0;
      //if((t = findTrack(x, y))) {
      //    if(t.direction == TRK_N_S)
      //  tr.direction = st.y < t.y ? N_S : S_N;
      //    return t;
      //}
      //t = findSwitch(x, y);
      //if(t.direction >= 12 && t.direction <= 15)
      //    tr.direction = st.y < t.y ? N_S : S_N;
      //return t;
    }

    /*	FindStopPoint
     *
     *	Look ahead in the path to see if we have to stop
     *	at any station. The distance from the station (or
     *	from the end of the path) is recorded so that we
     *	can start decellerating in time.
     */
    /// TODO Uncomment this function
    public static void findStopPoint(Train t) {
      //Track* trk;
      //Signal* sig;
      //TrainStop* stp;
      //int i;
      //trkdir dir;
      //long l1;
      //int nspeed;
      //int overlength;

      //t.stoppoint = 0;
      //if(!t.path)
      //  return;
      //trk = t.path.TrackAt(t.path._size - 1);
      //dir = (trkdir)t.path.FlagAt(t.path._size - 1);
      //if((trk = findNextTrack(dir, trk.x, trk.y))) {
      //  sig = (dir == W_E || dir == S_N) ? trk.esignal : trk.wsignal;
      //  if(sig) {
      //    t.stoppoint = (Track*)sig;	// TODO: this looks like a hack!
      //    t.disttostop = t.path._pathlen;
      //    //		t.pathtravelled = 0;
      //  }
      //}
      //nspeed = t.curmaxspeed;
      //l1 = 0; // t.pathtravelled;
      //for(i = 0 /*t.pathpos*/; i < t.path._size; ++i) {
      //  if(!(trk = t.path.TrackAt(i)))
      //    continue;
      //  if(!trk.isstation) {
      //    l1 += trk.length;
      //    continue;
      //  }
      //  if(i == 0 /*t.pathpos*/) {	/* if we're already at station */
      //    l1 += trk.length;
      //    continue;		/* ignore it */
      //  }
      //  if(!(t.flags & TFLG_STRANDED) && !t.shunting) {
      //    if(!sameStation(t.exit, trk.station)) {
      //      stp = findStop(t, trk);
      //      if(!stp || !stp.minstop) {
      //        l1 += trk.length;	/* ignore this station */
      //        continue;
      //      }
      //    }
      //  }

      //  /* Below is only when stoppoint is at a station */

      //  t.stoppoint = trk;
      //  t.disttostop = l1;
      //  if(!t.length) {		/* pre 1.17 code */
      //    t.disttostop += trk.length / 2;
      //    break;
      //  }
      //  /* 1.18 code */
      //  if(t.length <= trk.length) {
      //    t.disttostop += (trk.length / 2) + (t.length / 2);
      //    return;
      //  }
      //  /* proceed until end of path, or until half of the
      //   * train's length has travelled past the station.
      //   */

      //  overlength = t.length / 2 - trk.length / 2;
      //  t.disttostop += trk.length;
      //  while(++i < t.path._size) {
      //    if(!(trk = t.path.TrackAt(i)))
      //      break;
      //    if(trk.station)
      //      break;
      //    if(overlength - trk.length < 0) {
      //      t.disttostop += overlength;
      //      t.stoppoint = trk;
      //      break;
      //    }
      //    overlength -= trk.length;
      //    t.disttostop += trk.length;
      //  }
      //  break;
      //}
    }

    /*	FindSlowPoint
     *
     *	Look ahead in the path to see if we have to slow down
     *	because of a speed limit. The distance from the limit
     *	is recorded so that we can start decellerating in time.
     */
    /// TODO Uncomment this function
    public static void findSlowPoint(Train t) {
      //Track* trk;
      //int i;
      //long l2;
      //int speed, prev_speed, min_speed;

      //t.slowpoint = 0;
      //t.disttoslow = 0;
      //prev_speed = t.curmaxspeed;
      //l2 = 0; // t.pathtravelled;
      //for(i = 0 /*t.pathpos*/; i < t.path._size; ++i) {
      //  if(!(trk = t.path.TrackAt(i)))
      //    continue;
      //  if(trk.type == SWITCH && !trk.switched)
      //    continue;

      //  speed = trk.speed[t.type];
      //  if(!speed)
      //    speed = trk.speed[0];
      //  if(speed && speed < prev_speed) {
      //    /* This is a track that is slower than
      //       previous track, i.e. a slowpoint. */
      //    /* However, if this track is short and next track is slower,
      //       maybe one of the next tracks is the true slowpoint.*/
      //    /* For the first found slowpoint set tentatively. For next
      //       found slow point, set only if it requires a slower speed */
      //    if(!t.slowpoint) {
      //      t.slowpoint = trk;
      //      t.disttoslow = l2;
      //      min_speed = speed;
      //    } else if(max_approach_speed(t, l2 - t.disttoslow, speed) < min_speed) {
      //      /* Found a new candidate */
      //      t.slowpoint = trk;
      //      t.disttoslow = l2;
      //      min_speed = speed;
      //    }
      //  }
      //  l2 += trk.length;
      //  if(speed)
      //    prev_speed = speed;
      //}
    }

    /*	findPath0
 *
 *	This is one of the main functions of the program.
 *	It is responsible for computing and validating the
 *	next path that the train will have to travel,
 *	based on the position of the switches and the
 *	type of the tracks.
 *
 *	The path is first computed by "walking" each track.
 *	The track routines return the next track based on
 *	the current track and the track or switch orientation.
 *
 *	When we reach the next signal, or the end of the line
 *	we validate the path by walking back. This is necessary
 *	because switches might point us to the wrong direction
 *	when travelled backwards.
 *
 *	Also note that we don't care about any train being
 *	on the path. pathIsBusy() below takes care of that.
 */

    /// TODO Uncomment this function
    public static Vector findPath0(Vector path, Track t, trkdir dir)
      //Vector* findPath0(Vector* path, Track* t, int dir)
{
      return null;
      //  Track	*t1, *tbck;
      //  Track	*to;
      //  int	cx, cy;
      //  int	i;
      //  Track	*sw;
      //  Signal	*s;
      //  trkdir	ndir;

      //  if(!path)
      //      path = new_Vector();
      //  else
      //      path.Empty();
      //        if(!t)
      //            return path;
      //agn:
      //  path.Add(t, dir);
      //  cx = t.x;
      //  cy = t.y;
      //  to = t;
      //  if(dir == E_W || dir == N_S) {		/* westbound */
      //      ndir = (trkdir)dir;
      //      while(1) {
      //    if(to.type == TRACK)
      //        t1 = track_walkwest(to, &ndir);
      //    else
      //        t1 = swtch_walkwest(to, &ndir);
      //    if(t1 == 0)
      //        break;
      //nxtw:
      //    if(path._size >= total_track_number)// impossible
      //        goto err;
      //    t = findTrack(t1.x, t1.y);
      //    if(t != 0) {
      //        if(t.wsignal != 0 && ndir != S_N) {
      //      s = (Signal *)t.wsignal;
      //      if(!s.IsApproach())	    // 4.0
      //          break;
      //        }
      //        if(t.x == to.wlinkx && t.y == to.wlinky &&
      //       t.wlinkx == to.x && t.wlinky == to.y) {
      //      dir = W_E;
      //      if(t.wsignal != 0) {
      //          s = (Signal *)t.wsignal;
      //          if(!s.IsApproach())    // 4.0
      //        break;
      //      }
      //      goto agn;
      //        }
      //        if(t.direction == XH_SW_NE) {
      //      path.Add(t, ndir);
      //      if(to.y != t1.y)
      //          ++t1.y;
      //      --t1.x;
      //      to = t;
      //      goto nxtw;
      //        }
      //        if(t.direction == XH_NW_SE) {
      //      path.Add(t, ndir);
      //      if(to.y != t1.y)
      //          --t1.y;
      //      --t1.x;
      //      to = t;
      //      goto nxtw;
      //        }
      //        if(t.direction == X_X) {
      //      path.Add(t, ndir);
      //      if(to.y < t.y)
      //          ++t1.y;
      //      else
      //          --t1.y;
      //      if(to.x < t.x)
      //          ++t1.x;
      //      else
      //          --t1.x;
      //      goto nxtw;
      //        }
      //        if(t.direction == X_PLUS) {
      //      path.Add(t, ndir);
      //      if(to.y < t.y)
      //          ++t1.y;
      //      else if(to.y > t.y)
      //          --t1.y;
      //      else
      //          --t1.x;
      //      goto nxtw;
      //        }
      //        if(t.direction == N_NE_S_SW) {
      //      path.Add(t, ndir);
      //      if(to.x == t.x) {
      //          if(ndir == N_S)
      //        ++t1.y;
      //          else
      //        --t1.y;
      //      } else {
      //          if(t.y < to.y)
      //        --t1.y, ++t1.x;   // move sw to ne
      //          else if(t.y > to.y)
      //        ++t1.y, --t1.x;   // move ne to sw
      //      }
      //      goto nxtw;
      //        }
      //        if(t.direction == N_NW_S_SE) {
      //      path.Add(t, ndir);
      //      if(to.x == t.x) {
      //          if(ndir == N_S)
      //        ++t1.y;
      //          else
      //        --t1.y;
      //      } else {
      //          if(t.y > to.y)
      //        ++t1.y, ++t1.x;   // move nw to se
      //          else if(t.y < to.y)
      //        --t1.y, --t1.x;   // move se to nw
      //      }
      //      goto nxtw;
      //        }
      //        if(ndir == W_E || ndir == S_N) {
      //      dir = ndir;
      //      goto agn;
      //        }
      //        path.Add(t, ndir);
      //        to = t;
      //        cx = t.x;
      //        cy = t.y;
      //        continue;
      //    }
      //    sw = findSwitch(t1.x, t1.y);
      //    if(sw != 0) {
      //        if(ndir == W_E) {
      //      if(sw.direction == 8 || sw.direction == 9 ||
      //          sw.direction == 16 || sw.direction == 17)
      //          goto we89;
      //      t = sw;
      //      dir = W_E;
      //      goto agn;
      //        }
      //ew89:		    path.Add(sw, ndir);
      //        cx = sw.x;
      //        cy = sw.y;
      //        if(sw.direction == 8) {/* special case: english switch */
      //      --t1.x;
      //      if(to.y == cy) {/* we come from a horiz track */
      //          if(sw.switched)
      //        ++t1.y;
      //      } else if(!sw.switched)
      //          ++t1.y;
      //      to = sw;
      //      goto nxtw;
      //        }
      //        if(sw.direction == 9) {/* special case: english switch */
      //      --t1.x;
      //      if(to.y == cy) {/* we come from a horiz track */
      //          if(sw.switched)
      //        --t1.y;
      //      } else if(!sw.switched)
      //          --t1.y;
      //      to = sw;
      //      goto nxtw;
      //        }
      //        if(sw.direction == 16) {/* special case: english switch sw-ne */
      //      if(sw.switched) {
      //          if(ndir == N_S) {
      //        if(to.x == cx) {
      //            --t1.x;
      //            ++t1.y;
      //            ndir = E_W;
      //        } else {
      //            ++t1.y;
      //        }
      //          } else if(ndir == S_N) {
      //        if(to.x == cx) {
      //            --t1.y;
      //            ++t1.x;
      //            ndir = W_E;
      //        } else
      //            --t1.y;
      //          } else {	    /* E_W */
      //        if(to.x == cx) {
      //            ++t1.y;
      //            --t1.x;
      //        } else {
      //            ++t1.y;
      //            ndir = N_S;
      //        }
      //          }
      //      } else {
      //          if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.y;
      //        } else {
      //            ++t1.y;
      //            --t1.x;
      //        }
      //          } else if(ndir == S_N) {
      //        if(to.x == cx)
      //            --t1.y;
      //        else {
      //            --t1.y;
      //            --t1.x;
      //        }
      //          } else {	    /* E_W */
      //        if(to.x == cx) {
      //            ++t1.y;
      //            ndir = N_S;
      //        } else {
      //            ++t1.y;
      //            --t1.x;
      //        }
      //          }
      //      }
      //      to = sw;
      //      goto nxtw;
      //        }
      //        if(sw.direction == 17) {/* special case: english switch nw-se */
      //      if(sw.switched) {
      //          if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.x;
      //            ++t1.y;
      //            ndir = W_E;
      //            goto nxte;
      //        } else {
      //            ++t1.y;
      //        }
      //          } else {	    /* E_W */
      //        if(to.x == cx) {
      //            --t1.y;
      //            --t1.x;
      //        } else {
      //            --t1.y;
      //            ndir = S_N;
      //            goto nxte;
      //        }
      //          }
      //      } else {
      //          if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.y;
      //        } else {
      //            ++t1.y;
      //            ++t1.x;
      //        }
      //          } else {	    /* E_W */
      //        if(to.x == cx) {
      //            --t1.y;
      //            ndir = S_N;
      //            goto nxte;
      //        } else {
      //            --t1.y;
      //            --t1.x;
      //        }
      //          }
      //      }
      //      to = sw;
      //      goto nxtw;
      //        }
      //        to = sw;
      //        continue;
      //    }
      //    tbck = findLinkTo(to.x, to.y);
      //    if(tbck != 0) {
      //        path.Add(tbck, ndir);
      //        break;
      //    }
      //    wxPrintf(wxPorting.T("No trk west of %d,%d\n"), cx, cy);
      //    break;
      //      }
      //      if(ndir == N_S)
      //    ndir = S_N;
      //      else if(ndir == S_N)
      //    ndir = N_S;
      //      else
      //    ndir = W_E;
      //      for(i = path._size - 1; i > 0; --i) {
      //chkw:
      //    to = path.TrackAt(i);
      //    t1 = path.TrackAt(i - 1);
      //    if(to.type == TEXT) {
      //        if(to.elinkx && to.elinky)
      //      tbck = findTrack(to.elinkx, to.elinky);
      //        else
      //      tbck = findTrack(to.wlinkx, to.wlinky);
      //        if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //      goto err;
      //        continue;
      //    }
      //    if(to.type == TRACK) {
      //        if(to.direction == XH_NW_SE)
      //      continue;
      //        if(to.direction == XH_SW_NE)
      //      continue;
      //        if(to.direction == X_X || to.direction == X_PLUS ||
      //      to.direction == N_NE_S_SW || to.direction == N_NW_S_SE)
      //      continue;
      //        tbck = track_walkeast(to, &ndir);
      //        if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //      goto err;
      //        if(path.FlagAt(i - 1) == W_E && i > 1) {
      //      --i;
      //      goto chke;
      //        }
      //        continue;
      //    }
      //    if(to.direction == 8) {
      //        if(t1.x == to.x + 1 && t1.y != to.y + 1)
      //      continue;
      //        goto err;
      //    }
      //    if(to.direction == 9) {
      //        if(t1.x == to.x + 1 && t1.y != to.y - 1)
      //      continue;
      //        goto err;
      //    }
      //    if(to.direction == 16) {
      ////		    if(t1.y == to.y - 1 && t1.x != to.x + 1)
      ////			continue;
      //        if(to.switched && ndir == E_W)
      //      ndir = N_S;
      //        if(to.switched && ndir == W_E)
      //      ndir = S_N;
      //        continue;
      //    }
      //    if(to.direction == 17) {
      ////		    if(t1.y == to.y - 1 && t1.x != to.x - 1)
      //        if(to.switched && ndir == W_E)
      //      ndir = N_S;
      //        if(to.switched && ndir == E_W)
      //      ndir = S_N;
      //        continue;
      //    }
      //    tbck = swtch_walkeast(to, &ndir);
      //    if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //        goto err;
      //    if(path.FlagAt(i - 1) == W_E && i > 1) {
      //        --i;
      //        goto chke;
      //    }
      //      }
      //  } else {			/* eastbound */
      //      ndir = (trkdir)dir;
      //      while(1) {
      //    if(to.type == TRACK)
      //        t1 = track_walkeast(to, &ndir);
      //    else
      //        t1 = swtch_walkeast(to, &ndir);
      //    if(t1 == 0)
      //        break;
      //nxte:
      //    if(path._size >= total_track_number)	// impossible
      //        goto err;
      //    t = findTrack(t1.x, t1.y);
      //    if(t != 0) {
      //        if(t.esignal != 0 && ndir != N_S) {
      //      Signal *s = (Signal *)t.esignal;
      //      if(!s.IsApproach())
      //          break;
      //        }
      //        if(t.x == to.elinkx && t.y == to.elinky &&
      //       t.elinkx == to.x && t.elinky == to.y) {
      //      dir = E_W;
      //      if(t.esignal != 0) {
      //          s = (Signal *)t.esignal;
      //          if(!s.IsApproach())
      //        break;
      //      }
      //      goto agn;
      //        }
      //        if(t.direction == XH_SW_NE) {
      //      path.Add(t, ndir);
      //      if(to.y != t1.y)
      //          --t1.y;
      //      ++t1.x;
      //      to = t;
      //      goto nxte;
      //        }
      //        if(t.direction == XH_NW_SE) {
      //      path.Add(t, ndir);
      //      if(to.y != t1.y)
      //          ++t1.y;
      //      ++t1.x;
      //      to = t;
      //      goto nxte;
      //        }
      //        if(t.direction == X_X) {
      //      path.Add(t, ndir);
      //      if(to.y < t.y)
      //          ++t1.y;
      //      else
      //          --t1.y;
      //      if(to.x < t.x)
      //          ++t1.x;
      //      else
      //          --t1.x;
      //      goto nxte;
      //        }
      //        if(t.direction == X_PLUS) {
      //      path.Add(t, ndir);
      //      if(to.y < t.y)
      //          ++t1.y;
      //      else if(to.y > t.y)
      //          --t1.y;
      //      else
      //          ++t1.x;
      //      goto nxte;
      //        }
      //        if(t.direction == N_NE_S_SW) {
      //      path.Add(t, ndir);
      //      if(to.x == t.x) {
      //          if(ndir == N_S)
      //        ++t1.y;
      //          else
      //        --t1.y;
      //      } else {
      //          if(t.y < to.y)
      //        --t1.y, ++t1.x;
      //          else if(t.y > to.y)
      //        ++t1.y, --t1.x;
      //      }
      //      goto nxte;
      //        }
      //        if(t.direction == N_NW_S_SE) {
      //      path.Add(t, ndir);
      //      if(to.x == t.x) {
      //          if(ndir == N_S)
      //        ++t1.y;
      //          else
      //        --t1.y;
      //      } else {
      //          if(t.y < to.y)	    // moving north-eastward
      //        --t1.y, --t1.x;
      //          else if(t.y > to.y)   // moving south-eastward
      //        ++t1.y, ++t1.x;
      //      }
      //      goto nxte;
      //        }
      //        if(ndir == E_W || ndir == N_S) {
      //      dir = ndir;
      //      goto agn;
      //        }
      //        path.Add(t, ndir);
      //        to = t;
      //        cx = t.x;
      //        cy = t.y;
      //        continue;
      //    }
      //    sw = findSwitch(t1.x, t1.y);
      //    if(sw != 0) {
      //        if(ndir == E_W) {
      //      if(sw.direction == 8 || sw.direction == 9 ||
      //          sw.direction == 16 || sw.direction == 17)
      //          goto ew89;
      //      t = sw;
      //      dir = E_W;
      //      goto agn;
      //        }
      //we89:		    path.Add(sw, ndir);
      //        cx = sw.x;
      //        cy = sw.y;
      //        if(sw.direction == 8) {/* special case: english switch */
      //      ++t1.x;
      //      if(to.y == cy) {/* we come from a horiz track */
      //          if(sw.switched)
      //        --t1.y;
      //      } else if(!sw.switched)
      //          --t1.y;
      //      to = sw;
      //      goto nxte;
      //        }
      //        if(sw.direction == 9) {/* special case: english switch */
      //      ++t1.x;
      //      if(to.y == cy) {/* we come from a horiz track */
      //          if(sw.switched)
      //        ++t1.y;
      //      } else if(!sw.switched)
      //          ++t1.y;
      //      to = sw;
      //      goto nxte;
      //        }
      //        if(sw.direction == 16) {/* special case: english switch sw-ne */
      //      if(sw.switched) {
      //          if(ndir == S_N) {
      //        if(to.x == cx) {
      //            --t1.y;
      //            ++t1.x;
      //            ndir = W_E;
      //            goto nxte;
      //        } else {
      //            --t1.y;
      //        }
      //          } else if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.y;
      //            --t1.x;
      //            ndir = E_W;
      //            goto nxtw;
      //        } else {
      //            ++t1.y;
      //        }
      //          } else {	    /* W_E */
      //        if(to.x == cx) {
      //            --t1.y;
      //            ++t1.x;
      //        } else {
      //            --t1.y;
      ////				    --t1.x;
      //            ndir = S_N;
      //        }
      //        goto nxte;
      //          }
      //      } else {
      //          if(ndir == S_N) {
      //        if(to.x == cx) {
      //            --t1.y;
      //        } else {
      //            --t1.y;
      //            ++t1.x;
      //            ndir = W_E;
      //        }
      //          } else if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.y;
      //        } else {
      //            ++t1.y;
      //            --t1.x;
      //            ndir = E_W;
      //        }
      //          } else {	    /* W_E */
      //        if(to.x == cx) {
      //            --t1.y;
      //            --t1.x;
      //            ndir = S_N;
      //        } else {
      //            --t1.y;
      //            ++t1.x;
      //        }
      //          }
      //      }
      //      to = sw;
      //      goto nxte;
      //        }
      //        if(sw.direction == 17) {/* special case: english switch */
      //      if(sw.switched) {
      //          if(ndir == S_N) {
      //        if(to.x == cx) {
      //            --t1.x;
      //            --t1.y;
      //            ndir = E_W;
      //            goto nxtw;
      //        } else {
      //            --t1.y;
      //        }
      //          } else if(ndir == N_S) {
      //        if(to.x == cx) {
      //            ++t1.x;
      //            ++t1.y;
      //            ndir = W_E;
      //            goto nxte;
      //        } else {
      //            ++t1.y;
      //        }
      //          } else {	    /* W_E */
      //        if(to.x == cx) {
      //            ++t1.y;
      //            ++t1.x;
      //        } else {
      //            ++t1.y;
      //            ndir = N_S;
      //        }
      //        goto nxtw;
      //          }
      //      } else {	    /* switch is not thrown */
      //          if(ndir == S_N) {
      //        if(to.x == cx) {
      //            --t1.y;
      //        } else {
      //            --t1.y;
      //            --t1.x;
      //            ndir = W_E;
      //        }
      //          } else if(ndir == N_S) {
      //        if(to.x == cx)
      //            ++t1.y;
      //        else {
      //            ++t1.y;
      //            ++t1.x;
      //        }
      //          } else {	    /* W_E */
      //        if(to.x == cx) {
      //            --t1.y;
      //            ndir = S_N;
      //        } else {
      //            ++t1.y;
      //            ++t1.x;
      //        }
      //          }
      //      }
      //      to = sw;
      //      goto nxte;
      //        }
      //        to = sw;
      //        continue;
      //    }
      //    tbck = findLinkTo(to.x, to.y);
      //    if(tbck != 0) {
      //        path.Add(tbck, ndir);
      //        break;
      //    }
      //    wxPrintf(wxPorting.T("No trk east of %d,%d\n"), cx, cy);
      //    break;
      //      }
      //      if(ndir == N_S)
      //    ndir = S_N;
      //      else if(ndir == S_N)
      //    ndir = N_S;
      //      else
      //    ndir = E_W;
      //      for(i = path._size - 1; i > 0; --i) {
      //chke:
      //    to = path.TrackAt(i);
      //    t1 = path.TrackAt(i - 1);
      //    if(to.type == TEXT) {
      //        if(to.wlinkx && to.wlinky)
      //      tbck = findTrack(to.wlinkx, to.wlinky);
      //        else
      //      tbck = findTrack(to.elinkx, to.elinky);
      //        if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //      goto err;
      //        continue;
      //    }
      //    if(to.type == TRACK) {
      //        if(to.direction == XH_NW_SE)
      //      continue;
      //        if(to.direction == XH_SW_NE)
      //      continue;
      //        if(to.direction == X_X || to.direction == X_PLUS ||
      //      to.direction == N_NE_S_SW || to.direction == N_NW_S_SE)
      //      continue;
      //        tbck = track_walkwest(to, &ndir);
      //        if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //      goto err;
      //        if(path.FlagAt(i - 1) == E_W && i > 1) {
      //      --i;
      //      goto chkw;
      //        }
      //        continue;
      //    }
      //    if(to.direction == 8) {
      //        if(t1.x == to.x - 1 && t1.y != to.y - 1)
      //      continue;
      //        goto err;
      //    }
      //    if(to.direction == 9) {
      //        if(t1.x == to.x - 1 && t1.y != to.y + 1)
      //      continue;
      //        goto err;
      //    }
      //    if(to.direction == 16) {
      ////		    if(t1.y == to.y - 1 && t1.x != to.x - 1)
      //        if(to.switched && ndir == E_W)
      //      ndir = N_S;
      //        if(to.switched && ndir == W_E)
      //      ndir = S_N;
      //        continue;
      //    }
      //    if(to.direction == 17) {
      //        if(to.switched && ndir == W_E)
      //      ndir = N_S;
      //        if(to.switched && ndir == E_W)
      //      ndir = S_N;
      //        continue;
      //    }
      //    tbck = swtch_walkwest(to, &ndir);
      //    if(!tbck || tbck.x != t1.x || tbck.y != t1.y)
      //        goto err;
      //    if(path.FlagAt(i - 1) == E_W && i > 1) {
      //        --i;
      //        goto chkw;
      //    }
      //    continue;
      //      }
      //  }
      //  path.ComputeLength();
      //  return path;
      //err:
      //  Vector_delete(path);
      //  return 0;
    }

    public static Vector findPath(Track trk, trkdir dir) {
      return findPath0(null, trk, dir);
    }

    /// TODO Uncomment this function
    public static Vector appendPath(Vector oldpath, Vector newelems) {
      //Vector* appendPath(Vector* oldpath, Vector* newelems) {
      return null;
      //  int i, j;
      //  Track* trk;

      //  if(!oldpath)
      //    oldpath = new_Vector();
      //  for(i = 0; i < newelems._size; ++i) {
      //    for(j = 0; j < oldpath._size; ++j)
      //      if(oldpath.TrackAt(j) == newelems.TrackAt(i))
      //        break;
      //    if(j < oldpath._size)
      //      continue;
      //    trk = newelems.TrackAt(i);
      //    oldpath.Add(trk, newelems.FlagAt(i));
      //  }
      //  return oldpath;
    }

    /// TODO Uncomment this function
    public static void enter_beep() {
      //if(pEntrySound && pEntrySound.IsOk())
      //  pEntrySound.Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
    }

    /// TODO Uncomment this function
    public static int pathIsBusy(Train tr, Vector path, trkdir dir) {
      return 0;
      //int el, nel;
      //Track* t;
      //Track* trk;
      //Train* trn;

      //if(!path)
      //  return 0;
      //nel = path._size;
      //for(el = 0; el < nel; ++el) {
      //  t = path.TrackAt(el);
      //  if(t.IsBusy()) {
      //    trk = findTrack(t.x, t.y);
      //    if(trk == 0) {
      //      if(findText(t.x, t.y) != 0)
      //        return 0;
      //      return el + 1;
      //    }
      //    if(el)
      //      switch(dir) {
      //        case W_E:
      //        case signal_EAST_FLEETED:
      //        case S_N:
      //        case signal_NORTH_FLEETED:
      //          if(trk.esignal != 0 && !trk.esignal.IsApproach())
      //            return 0;
      //          break;
      //        case E_W:
      //        case signal_WEST_FLEETED:
      //        case N_S:
      //        case signal_SOUTH_FLEETED:
      //          if(trk.wsignal != 0 && !trk.wsignal.IsApproach())
      //            return 0;
      //          break;
      //      }
      //    /*wxPrintf(wxPorting.T("busy at %d,%d\n"), trk.x, trk.y);*/
      //    return el + 1;
      //  }
      //  if((trn = findTrain(t.x, t.y)) != 0 && trn != tr) {
      //    /*wxPrintf(wxPorting.T("busy for train at %d,%d\n"), t.x, t.y);*/
      //    return el + 1;
      //  }
      //  if((trn = findTail(t.x, t.y)) != 0 && trn != tr) {
      //    return el + 1;
      //  }
      //  if((trn = findStranded(t.x, t.y)) != 0 && trn != tr) {
      //    /*wxPrintf(wxPorting.T("busy for train at %d,%d\n"), t.x, t.y);*/
      //    return el + 1;
      //  }
      //  if((trn = findStrandedTail(t.x, t.y)) != 0 && trn != tr) {
      //    /*wxPrintf(wxPorting.T("busy for train at %d,%d\n"), t.x, t.y);*/
      //    return el + 1;
      //  }
      //  if(t.fgcolor == color_green || t.fgcolor == color_orange || t.fgcolor == color_red)
      //    return el + 1;
      //}
      //return 0;
    }

    /// TODO Uncomment this function
    /*	new_train_status
     *
     *	This is a utility function to keep track of
     *	the number of trains in each different state.
     *	The data is just displayed to the user.
     */
    public static void new_train_status(Train t, trainstat status) {
      //if(t.status == status)
      //  return;
      //switch(t.status) {
      //  case train_WAITING:
      //    --ntrains_waiting;
      //    break;
      //  case train_STOPPED:
      //    --ntrains_stopped;
      //    break;
      //  case train_READY:
      //    --ntrains_ready;
      //    break;
      //  case train_ARRIVED:
      //    --ntrains_arrived;
      //    break;
      //  case train_STARTING:
      //    --ntrains_starting;
      //    t.startDelay = 0;
      //    break;
      //  case train_RUNNING:
      //    --ntrains_running;
      //}
      //t.status = (trainstat)status;
      //switch(t.status) {
      //  case train_WAITING:
      //    ++ntrains_waiting;
      //    break;
      //  case train_STOPPED:
      //    ++ntrains_stopped;
      //    break;
      //  case train_READY:
      //    ++ntrains_ready;
      //    break;
      //  case train_ARRIVED:
      //    ++ntrains_arrived;
      //    t.arrived = 1;
      //    break;
      //  case train_STARTING:
      //    ++ntrains_starting;
      //    break;
      //  case train_RUNNING:
      //    ++ntrains_running;
      //}
    }

    /// TODO Uncomment this function
    public static void colorPartialPath0(Vector path, trkstat state, int start, int end) {
      //grcolor c;
      //int el, nel;
      //int busy;
      //Track* trk;

      //if(path == 0)
      //  return;
      //busy = 0;
      //c = conf.fgcolor;		/* ST_FREE is the default */
      //if(state == ST_GREEN) {
      //  c = color_green;
      //  busy = 1;
      //} else if(state == ST_RED) {
      //  c = color_orange;
      //  busy = 1;
      //} else if(state == ST_WHITE) {
      //  c = color_white;
      //  busy = 1;
      //}
      //nel = end;
      //for(el = start; el < nel; ++el) {
      //  trk = path.TrackAt(el);
      //  if(trk == 0)
      //    continue;
      //  trk.SetColor(c);
      //  /* t.busy = busy; */
      //}
    }

    public static void colorPartialPath(Vector path, trkstat state, int start) {
      colorPartialPath0(path, state, start, path._size);
    }

    public static void colorPathStart(Vector path, trkstat state, int end) {
      colorPartialPath0(path, state, 0, end);
    }

    public static void colorPath(Vector path, trkstat state) {
      colorPartialPath0(path, state, 0, path._size);
    }

    /// TODO Uncomment this function

    /*	Train_at_station
     *
     *	A train is at a station.
     *	We have to decide whether we have to stop
     *	at this station (because it's in our schedule
     *	or during shunting), and if so we have to
     *	compute the penalties for late arrivals,
     *	wrong platform and the estimated time of departure.
     */

    public static int train_at_station(Train trn, Track trk) {
      return 0;
      //TrainStop *stp, *stp1;
      //int	minlate;
      //long	arrtime;

      //if(!trk.station)
      //    return 0;
      //for(stp = trn.stops; stp; stp = stp.next)
      //    if(sameStation(stp.station, trk.station))
      //  break;
      //if(trn.shunting) {
      //    if(trn.outof == trk)	/* don't stop */
      //  return 0;
      //    if(trn.oldstatus == train_WAITING || trn.oldstatus == train_RUNNING)
      //  trn.oldstatus = train_STOPPED;
      //    new_train_status(trn, trn.oldstatus);
      //    trn.stopping = 0;
      //    trn.curspeed = 0;
      //    trn.shunting = 0;
      //    trn.outof = 0;
      //    if(stp)
      //  trn.timedep = stp.departure;
      //    else if(sameStation(trk.station, trn.entrance))
      //  trn.timedep = trn.timein;
      //    else if(sameStation(trk.station, trn.exit) || trn.arrived) {
      //  // in case we were shunted to our destination
      //  train_arrived(trn);
      //    }
      //    return 1;
      //}
      //trn.stopping = 0;
      //if(!stp) {			/* we are not at a stop */
      //    if(!assign_ok || !sameStation(trk.station, trn.exit))
      //  return 0;

      //    /* but we arrived at our destination! */

      //    check_platform(trk.station, trn.exit);
      //    train_arrived(trn);
      //    trn.OnArrived();
      //} else {
      //    check_platform(trk.station, stp.station);
      //    arrtime = stp.arrival;
      //    if(arrtime < trn.timein)
      //  arrtime += 24 * 60 * 60;
      //    minlate = (current_time - arrtime) / 60;
      //    if(!stp.minstop) {		/* does not stop */
      //  stp.delay = minlate;
      //  return 0;
      //    }
      //    trn.OnStopped();
      //    new_train_status(trn, train_STOPPED);
      //    if(stp.stopped)		/* we stopped here before! */
      //  minlate = 0;
      //    stp.delay = minlate;
      //    stp.stopped = 1;
      //    for(stp1 = stp.next; stp1; stp1 = stp1.next)/* sometimes we have */
      //  if(sameStation(stp1.station, stp.station))/* multiple entries for the */
      //      stp1.stopped = 1;	/* same station. This should be fixed in loadsave! */
      //    if(minlate > 0) {
      //  stp.late = 1;
      //  trn.timelate += minlate;
      //  total_late += minlate;
      //    }
      //}
      //trn.curspeed = 0;
      //if(!stp)
      //    return 1;
      //      if(stp.departure < stp.arrival)   // arrived in the evening, departing in the morning
      //          stp.departure += 24 * 60 * 60;
      //trn.timedep = current_time + stp.minstop;
      //if(trn.timedep < stp.departure)
      //    trn.timedep = stp.departure;
      //Track *trk1 = trn.position;
      //if(trk1) {
      //    if(!trk1.station && trn.tail && trn.tail.path) {
      //  trk1 = path_find_station(trn.tail.path, trn.position);
      //    }
      //}
      //if(trk1 && trk1.station) {
      //    trk1.OnStopped(trn);
      //}
      //return 1;
    }


    /// TODO Uncomment this function
    public static Track path_find_station(Vector path, Track headpos) {
      return null;

      //int i;
      //Track* trk;

      //for(i = path._size - 1; i >= 0; --i) {
      //  trk = path.TrackAt(i);
      //  if(trk == headpos)
      //    break;
      //}
      //for(; i >= 0; --i) {
      //  trk = path.TrackAt(i);
      //  if(trk.station)
      //    return trk;
      //}
      //return 0;
    }

    /// TODO Uncomment this function
    public static int fetch_path(Train t) {
      return 0;
      //  wxChar	buff[512];
      //  int	i;
      //  trkdir	ndir;
      //  Track	*trk;
      //  Signal	*sig;

      //  if(!(trk = t.position) || (trk.type == TEXT && !trk.isstation)) {
      //      train_is_exiting(t, trk);
      //      return 0;
      //  }

      //  //  Find the start of the next block

      //  if(!(trk = findNextTrack1(t.direction, t.position.x, t.position.y, &ndir))) {
      //      train_derailed(t);
      //      return 0;
      //  }
      //  if(trk.busy) {			/* THIS CODE APPEARS TO BE DEAD */
      //      t.curspeed = 0;
      //      if(t.status != train_WAITING) {
      //    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), L("Train %s waiting at %d,%d!"),
      //        t.name, trk.x, trk.y);
      //    do_alert(buff);
      //    ++perf_tot.waiting_train;
      //      }
      //      sig = (Signal *)((t.direction == W_E || t.direction == S_N) ?
      //            trk.esignal : trk.wsignal);
      //      t.OnWaiting(sig);
      //      new_train_status(t, train_WAITING);
      //      t.flags |= TFLG_WAITED;
      //      add_update_schedule(t);
      //      return 0;
      //  }

      //  // Check if we can cross the signal that protects the next block

      //  sig = (Signal *)((t.direction == W_E || t.direction == S_N) ?
      //        trk.esignal : trk.wsignal);
      //  if(!sig) {
      //      train_derailed(t);
      //      return 0;
      //  }

      //        if(powerSpecified && sig.IsClear() || (t.shunting && trk.fgcolor == color_white)) {
      //            Vector *newPath = findPath0(0, trk, t.direction = ndir);
      //            bool canTravelOnNewPath = t.CanTravelOn(newPath);
      //            Vector_delete(newPath);
      //            if(!canTravelOnNewPath) {
      //                if(t.status != train_WAITING) {
      //                    wxString alertMsg;

      //                    if(sig.station)
      //                        alertMsg.Printf(L("Train %s stopped at %s (%d,%d) due to power loss."), t.name, sig.station, trk.x, trk.y);
      //                    else
      //                        alertMsg.Printf(L("Train %s stopped at (%d,%d) due to power loss."), t.name, trk.x, trk.y);
      //                    do_alert(alertMsg.c_str());
      //                }
      //                goto stop_train;
      //            }
      //        }

      //  // Check if we are shunting and entering
      //  // a block that is already occupied

      //  if(trk.fgcolor == color_white && t.shunting) {
      //      int	x;
      //      Track	*wtrk;

      //      // if so, create a path limited to where the next train is
      //      t.path = findPath0(t.path, trk, t.direction = ndir);
      //      for(x = 0; x < t.path._size; ++x) {
      //    if(!(wtrk = t.path.TrackAt(x)))
      //        continue;
      //    if(wtrk.fgcolor == color_white)
      //        continue;
      //    if(!(t.merging = findTrain(wtrk.x, wtrk.y))) {
      //        if(!(t.merging = findTail(wtrk.x, wtrk.y)))
      //      if(!(t.merging = findStranded(wtrk.x, wtrk.y)))
      //          t.merging = findStrandedTail(wtrk.x, wtrk.y);
      //    }
      //    if(t.merging && (t.merging.status == train_STOPPED ||
      //      t.merging.status == train_WAITING ||
      //      t.merging.status == train_ARRIVED)) {
      //        t.path._size = x;  // limit to where next train is
      //        t.flags |= TFLG_MERGING;
      //        t.merging.flags |= TFLG_WAITINGMERGE;
      //    } else {// train is not there anymore or it's moving.
      //        t.merging = 0;
      //        wtrk = t.path.TrackAt(0);
      //        Signal *sig = (Signal *)wtrk.esignal;
      //        if(!sig)
      //      sig = (Signal *)wtrk.wsignal;
      //        if(sig)
      //      sig.OnUnclear();
      //        colorPath(t.path, ST_FREE);
      //        Vector_delete(t.path);
      //        t.path = 0;
      //        goto stop_train;
      //    }
      //    break;
      //      }
      //      sig.OnCross();	// turn signal to red
      //      goto proceed;
      //  }

      //  // we are not shunting, but the signal is opened for shunting
      //  // we force the train to stop and the user to send it forward
      //  // with an explicit shunt command (otherwise a reload will
      //  // incorrectly fetch a path beyond the signal and color it green)
      //  if(trk.fgcolor == color_white || !sig.IsClear()) {
      //stop_train:
      //      t.curspeed = 0;
      //      if(t.status != train_WAITING) {
      //    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), L("Train %s waiting at"), t.name);
      //          if(sig.station) {
      //              wxStrcat(buff, wxPorting.T(" "));
      //              wxStrcat(buff, sig.station);
      //              wxStrcat(buff, wxPorting.T(" "));
      //          }
      //          wxSnprintf(buff + wxStrlen(buff), sizeof(buff)/sizeof(wxChar) - wxStrlen(buff), wxPorting.T("(%d,%d)"),	trk.x, trk.y);
      //    do_alert(buff);
      //    if(!sig.nopenalty)
      //        ++perf_tot.waiting_train;
      //      }
      //      t.OnWaiting(sig);
      //      new_train_status(t, train_WAITING);
      //      if(t.trackpos > t.position.length)
      //    t.trackpos = t.position.length;
      //      add_update_schedule(t);
      //      return 0;
      //  }
      //        if(get_limit_from_signal(sig, &i)) {
      //            if (t.maxspeed && i > t.maxspeed)
      //                i = t.maxspeed;
      //      t.curmaxspeed = i;
      //        }
      //        if(t.status == train_WAITING) {
      //            if(t.myStartDelay != 0) {
      //                new_train_status(t, train_STARTING);
      //                t.startDelay = t.myStartDelay;
      //                return 0;
      //            }
      //        }
      //  sig.OnCross();
      ////	sig.status = ST_RED;
      //  change_coord(sig.x, sig.y);
      //  leave_track(t);
      //        t.path = findPath0(t.path, trk, t.direction = ndir);
      //  if(!t.path)
      //      return -1;
      //proceed:
      //  if(t.tail) {
      //      // make tail's path partially overlap the head's path
      //      t.tail.path = appendPath(t.tail.path, t.path);
      //  }
      ////	t.pathpos = 0;
      //  t.direction = (trkdir)t.path.FlagAt(0); //t.pathpos);
      //  t.position = t.path.TrackAt(0); //t.pathpos);
      //  t.position.SetColor(t.tail ? color_orange : conf.fgcolor);
      //  findStopPoint(t);
      //  findSlowPoint(t);
      ////	++t.pathpos;
      //  changed = 1;
      //  return 1;
    }

    public static

/*	Run_train
 *
 *	This is the main function for train movement.
 *	It must compute the next position and the next
 *	speed of the train after one time click.
 */
      /// TODO Uncomment this function

int run_train(Train t) {
      return 0;
      //  double	travelled;
      //  double	posit;
      //  Track	*trk;

      //  new_train_status(t, train_RUNNING);
      //  if(t.shunting && t.curmaxspeed > 30)
      //      t.curmaxspeed = 30;
      //  travelled = t.curspeed / 3.6;	/* meters travelled in 1 sec. */
      //  trk = t.position;
      //  if(!t.position) {		/* train is exiting the territory */
      //      if(!t.tail)
      //    return 0;
      //      compute_new_speed(t);
      //      if(t.tail.tailentry) {
      //    if((t.tail.tailentry += travelled) >= 0) {
      //        /* tail enters the field */
      //        t.tail.trackpos = t.tail.tailentry;
      //        t.tail.tailentry = 0;
      ////		    t.tail.pathpos = 0;
      //    }
      //      } else
      //    t.tail.trackpos -= travelled;
      //      tail_advance(t);
      //      if(!t.tail.path) {
      //    Char buff[256];

      //    wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]), wxPorting.T("Train '%s' has no tail path!\n"), t.name);
      //    do_alert(buff);
      //    return -1;
      //      }
      //      if(t.tail.path._size /*&& t.tail.pathpos < t.tail.path._size*/)
      //    return 1;
      //      /* exited! */
      //      fetch_path(t);
      //      return 0;
      //  }
      //agn:
      //  speed_limit(t, trk);

      //  trk.busy = 0;
      //  trk.flags &= ~TFLG_THROWN;
      //  if(!trk.length)
      //      trk.length = 1;
      //  if(trk.length < 2 && t.needfindstop) {
      //      findStopPoint(t);
      //      t.needfindstop = 0;
      //  }
      //  posit = t.trackpos;
      //  if(posit < trk.length) {
      //      posit += travelled;
      //      run_points += time_mult * run_point_base + 1;

      //      compute_new_speed(t);	/* accelerate/decelerate train */
      //      if(t.stopping && /*t.pathtravelled +*/ travelled >= t.disttostop) {
      //    tail_advance(t);
      //    train_at_station(t, t.stopping);
      //    return 0;
      //      }

      //      t.pathtravelled += travelled;
      //      t.disttostop -= travelled;
      //      if(t.disttostop < 0) t.disttostop = 0;
      //      t.disttoslow -= travelled;
      //      if(t.disttoslow < 0) t.disttoslow = 0;
      //      if(posit < trk.length) {
      //    t.trackpos = posit;    /* we are still in the same track */
      //    if(!t.length || !t.tail)/* no length info for this train */
      //        return 1;
      //    if(t.tail.tailentry) {
      //        if((t.tail.tailentry += travelled) < 0)
      //            return 1;	/* tail is still out of field */
      //        /* tail enters the field */
      //        t.tail.trackpos = t.tail.tailentry;
      //        t.tail.tailentry = 0;
      ////		    t.tail.pathpos = 0;
      //    } else
      //        t.tail.trackpos += travelled;
      //    tail_advance(t);
      //    return 1;
      //      }
      //      t.trackpos = posit - trk.length;/* meters already travelled in next track */
      //      if(t.tail) {
      //    if(t.tail.tailentry) {
      //        if((t.tail.tailentry += travelled) >= 0) {
      //      /* tail enters the field */
      //      t.tail.trackpos = t.tail.tailentry;
      //      t.tail.tailentry = 0;
      ////			t.tail.pathpos = 0;
      //        }
      //    } else
      //        t.tail.trackpos += travelled;
      //    //tail_advance(t);
      //      }
      //      travelled = 0;
      //  }

      //  // train has traveled the full length
      //  // of the current track element.
      //  // Advance to the next track element in the path,
      //  // or get a new path.

      //  if(!t.path || /*t.pathpos == */t.path._size == 1) {
      //      if(t.stopping) {		/* don't advance to another path if
      //           * we wanted to stop at a station.
      //           */
      //    train_at_station(t, t.stopping);
      //    return 0;
      //      }
      //      if(t.shunting && t.merging) {
      //    merge_train(t);
      //    return 0;
      //      }
      //      t.pathtravelled = t.trackpos;
      //      switch(fetch_path(t)) {
      //      case 0:
      //    if(t.tail)
      //        tail_advance(t);
      //    return 0;
      //      case -1:
      //    return -1;
      //      }
      //      travelled = t.trackpos;
      //      t.trackpos = 0;
      //      t.pathtravelled = 0;
      //      trk = t.position;
      //      goto agn;		/* no more tracks in this path, get new path */
      //  }

      //  /* advance to next track in this path */

      //  tail_advance(t);
      //  if(t.stopping) {
      //      if(/*t.pathtravelled >= */ t.disttostop < 1 || trk == t.stoppoint) {
      //    train_at_station(t, t.stopping);
      //    return 0;
      //      }
      //  }
      //  if(travelled) {
      //      // we didn't update the position because we travelled
      //      // a number of meter higher than current track's length.
      //      // Adjust the stop and slow points here by the track's length
      //      // so that we don't "go long" on the expected stop point
      //      travelled -= trk.length;
      //      t.disttostop -= trk.length;
      //      t.disttoslow -= trk.length;
      //  }
      //  changed = 1;
      //  //change_coord(trk.x, trk.y);
      //        leave_track(t);
      //        if(t.tail && !t.tail.position)
      //            t.tail.position = trk;
      //  t.path.DeleteAt(0);
      //  t.direction = (trkdir)t.path.FlagAt(0); //t.pathpos);
      //  t.position = trk = t.path.TrackAt(0); //t.pathpos++);
      //  trk.SetColor(t.tail ? color_orange : conf.fgcolor);
      //  do_triggers(t);
      //  trk.OnEnter(t);

      //  if(t.slowpoint && trk == t.slowpoint) {
      //      speed_limit(t, trk);    /* set maxcurspeed */
      //      findSlowPoint(t);
      //  }

      //  if(trk.isstation && /*train_at_station(t, trk)*/
      //      stopping_at_this_station(t, trk)) {

      //      if(!t.length || t.status == train_STOPPED) {
      //                // train may have become STOPPED as a result of a reverse
      //                // command executed by a trigger. If so, we should compute
      //                // the new time of departure, because reverse_train() does
      //                // not do that.
      //    if(!train_at_station(t, trk))
      //        goto agn;
      //    return 1;
      //      }

      //      /* 1.18 code: decide where to stop so that
      //       *		as much of the train as possible
      //       *		is at the station.
      //       */

      //      t.stopping = trk;	/* we're stopping at this station */
      //      return 1;
      //  }
      //  if(t.status != train_RUNNING)	// maybe we stopped due to a trigger
      //      return 1;
      //        if(t.trackpos >= trk.length) {
      //            travelled = t.trackpos;
      //            t.trackpos = 0;
      //            t.disttostop += travelled;
      //            t.disttoslow += travelled;
      //        }
      //        goto agn;
    }

    //
    //
    //
    public static void gr_update_schedule(Train tr, int itm) {
      int tt;
      int x;
      TimeTableView clist;

      if(GlobalFunctions.ignore_train(tr)) {
        // remove from list
        for(x = 0; x < GlobalVariables.num_listed_trains; ++x) {
          if(GlobalVariables.listed_trains[x] == tr)
            break;
        }
        if(x < GlobalVariables.num_listed_trains) {
          for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
            clist = GlobalVariables.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
            if(clist == null)
              continue;
            clist.DeleteRow(x);
          }
          for(tt = x; tt < GlobalVariables.num_listed_trains - 1; ++tt)
            GlobalVariables.listed_trains[tt] = GlobalVariables.listed_trains[tt + 1];
          --GlobalVariables.num_listed_trains;
        }
      }
      GlobalFunctions.print_train_info(tr);
      for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
        clist = GlobalVariables.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
        if(clist == null)
          continue;
        if(string.IsNullOrEmpty(tr.entrance))
          continue;
        for(x = 0; x < GlobalVariables.num_listed_trains; ++x)
          if(GlobalVariables.listed_trains[x] == tr)
            break;
        if(x >= GlobalVariables.num_listed_trains)
          continue;
        clist.UpdateItem(x, tr);
        if(clist.m_bTrackFirst)
          clist.ShowFirst();
        else if(clist.m_bTrackLast)
          clist.ShowLast();
      }
    }


    public static void change_coord(int x, int y) { // , int w = 3, int h = 1
      change_coord(x, y, 3, 1);
    }

    public static void change_coord(int x, int y, int w, int h)/* next time, paint within clip rectangle */
    {
      int i;

      if(x < 0) x = 0;
      if(y < 0) y = 0;
      if(x + w >= Configuration.XNCELLS)
        w = Configuration.XNCELLS - x;
      if(y + h >= Configuration.YNCELLS)
        h = Configuration.YNCELLS - y;
      if(x < GlobalVariables.cliprect.left)
        GlobalVariables.cliprect.left = x;
      if(x + w > GlobalVariables.cliprect.right)
        GlobalVariables.cliprect.right = x + w;
      if(y < GlobalVariables.cliprect.top)
        GlobalVariables.cliprect.top = y;
      if(y + h > GlobalVariables.cliprect.bottom)
        GlobalVariables.cliprect.bottom = y + h;
      while(h-- >= 0) {
        for(i = 0; i <= w; ++i) {
          GlobalFunctions.UPDATE_MAP(x + i, y, 1);
        }
        ++y;
      }
    }


    public static void get_text_size(string txt, Coord sz) {
      GlobalVariables.field_grid.GetTextExtent(txt, 0, sz);
    }


    public static void get_pixmap_size(Image map, Coord sz) {
      wx.Image img = map;
      sz.x = img.Width;
      sz.y = img.Height;
    }


    public static void print_train_info(Train t) {
      t.Get(GlobalVariables.train_info);
    }

    public static int toggle_signal_auto(Signal t, bool do_log) {
      Vector path;

      if(t.fixedred) {
        do_alert(wxPorting.L("This signal cannot be turned to green!"));
        return 0;
      }
      path = findPath(t.controls, t.direction);
      if(path == null)
        return 0;
      if(GlobalVariables.flog.IsOpened() && do_log)
        GlobalVariables.flog.Write(string.Format(wxPorting.T("%ld,click %d,%d\n"), GlobalVariables.current_time, t.x, t.y));
      if(t._isShuntingSignal) {
        t.OnClicked();
        change_coord(t.x, t.y);
        if(do_log)
          repaint_all();
        UpdateSignals(t);
        Vector_delete(path);
        return 0;
      }
      if(t.IsClear()) { // t.status == ST_GREEN) {
        if(!t.fleeted && !t.noClickPenalty) {
          ++GlobalVariables.perf_tot.cleared_signal;
          update_labels();
        }
        unreserveIntermediateSignals(path);
        t.OnUnclear();	// set to red
        //	    t.status = ST_RED;
        if(!t._intermediate)
          t.nowfleeted = false;
        change_coord(t.x, t.y);
        colorPath(path, trkstat.ST_READY);
        if(do_log)
          repaint_all();
        UpdateSignals(t);
        Vector_delete(path);
        return 0;
      }
      if(string.IsNullOrEmpty(t._lockedBy) == false) {
        string p = string.Copy(t._lockedBy);
        int x, y;
        int i;
        while(p.Length > 0) {
          if(p[0] == wxPorting.T(' ') || p[0] == wxPorting.T('\t'))
            p = p.Substring(1);
          if(p.Length == 0)
            break;
          x = wxPorting.Strtol(p, out i, 10);
          p = p.Substring(i);
          if(p[0] == wxPorting.T(','))
            p = p.Substring(1);
          y = wxPorting.Strtol(p, out i, 10);
          p = p.Substring(i);
          Track trk = findTrack(x, y);
          if(trk != null) {
            if(trk.fgcolor != GlobalVariables.conf.fgcolor) {
              Vector_delete(path);
              return 0;
            }
          }
          if(p[0] == wxPorting.T(';'))
            p = p.Substring(1);
        }
      }
      if(pathIsBusy(null, path, t.direction) != 0) {
        Vector_delete(path);
        if(do_log)
          repaint_all();
        return 0;
      }
      Array<Signal> intermediateSignals = new Array<Signal>();
      if(!t._intermediate && !checkIntermediateSignals(path, intermediateSignals)) {
        Vector_delete(path);
        if(do_log)
          repaint_all();
        return 0;
      }
      change_coord(t.x, t.y);
      t.OnClear();	// set to green
      if(!t.IsClear()) {     // script wants to keep the signal red
        Vector_delete(path);
        if(do_log)
          repaint_all();
        return 0;
      }
      //	t.status = ST_GREEN;
      t.SetColor(GlobalVariables.color_green);
      colorPath(path, trkstat.ST_GREEN);
      if(do_log)
        repaint_all();
      UpdateSignals(t);
      t.aspect_changed = false;
      t.OnUpdate();
      reserveIntermediateSignals(intermediateSignals);
      Vector_delete(path);
      return 1;
    }


    public static void Vector_delete(Vector v) {
      if(v._ptr != null)
        free(v._ptr);
      if(v._flags != null)
        free(v._flags);
      free(v);
    }

    public static void unreserveIntermediateSignals(Vector path) {
      Track trk;
      Signal sig;
      Vector nextPath = null;
      trkdir ndir;
      trkdir dir;
      int size = path._size;
      if(size < 1)
        return;
      trk = path.LastTrack();
      dir = (trkdir)path.FlagAt(size - 1);
      while((trk = findNextTrack1(dir, trk.x, trk.y, out ndir)) != null) {

        sig = (Signal)((dir == trkdir.W_E || dir == trkdir.S_N) ? trk.esignal : trk.wsignal);
        if(sig == null)
          break;

        if(!sig._intermediate)
          break;

        nextPath = findPath0(nextPath, trk, ndir);
        if(nextPath == null)
          break;

        // clear signal
        change_coord(sig.x, sig.y);
        if(sig._nReservations < 2) {
          sig.nowfleeted = false;
          sig.fleeted = false;
          if(sig.IsClear()) {  // no train after signal
            //sig.SetColor(color_green);
            colorPath(nextPath, (trkstat)(int)GlobalVariables.conf.fgcolor);
          }
          sig.OnUnclear();
          sig._nReservations = 0;
          UpdateSignals(sig);
        } else {
          --sig._nReservations;
        }

        size = nextPath._size;
        if(size < 1)
          break;
        trk = nextPath.LastTrack();
        dir = (trkdir)nextPath.FlagAt(size - 1);
      }
      if(nextPath != null)
        Vector_delete(nextPath);
    }


    public static bool checkIntermediateSignals(Vector path, Array<Signal> intermediateSignals) {
      Track trk;
      Signal sig;
      Vector nextPath = null;
      trkdir ndir;
      trkdir dir;
      int size = path._size;
      if(size < 1)
        return true;

      trk = path.TrackAt(size - 1);
      dir = (trkdir)path.FlagAt(size - 1);
      while((trk = findNextTrack1(dir, trk.x, trk.y, out ndir)) != null) {

        // Check if we can cross the signal that protects the next block

        sig = (Signal)((dir == trkdir.W_E || dir == trkdir.S_N) ? trk.esignal : trk.wsignal);
        if(sig == null)
          break;

        if(!sig._intermediate)
          break;

        nextPath = findPath0(nextPath, trk, ndir);
        if(nextPath == null)
          break;
        if(!sig.IsClear()) {
          if(pathIsBusy(null, nextPath, (trkdir)ndir) != 0) {
            //                if(sig.fleeted && sig.nowfleeted) // all following signals will eventually clear
            //                    break; // which means the following path(s) are valid
            Track t0 = nextPath.FirstTrack();
            Track tx = nextPath.LastTrack();
            if(t0.fgcolor != GlobalVariables.conf.fgcolor || tx.fgcolor == GlobalVariables.conf.fgcolor) {
              Vector_delete(nextPath);
              return false;
            }
            // track is occupied by a train traveling in the same direction,
            // that is, another train preceding us
          }
        }
        size = nextPath._size;
        if(size < 1)
          break;
        intermediateSignals.Add(sig);
        trk = nextPath.TrackAt(size - 1);
        dir = (trkdir)nextPath.FlagAt(size - 1);
      }
      for(int i = 0; i < intermediateSignals.Length(); ++i) {
        sig = intermediateSignals.At(i);
        sig.fleeted = true;
        sig.nowfleeted = true;
        change_coord(sig.x, sig.y);
      }
      if(nextPath != null)
        Vector_delete(nextPath);
      return true;
    }


    public static Track findNextTrack1(trkdir direction, int x, int y, out trkdir ndir) {
      Track t;
      Track t1;

      ndir = direction;
      if((t = findTrack(x, y)) == null && (t = findSwitch(x, y)) == null)
        return null;		/* should be impossible */
      if(direction == trkdir.E_W || direction == trkdir.N_S) {/* westbound */
        if(t.type == trktype.TRACK)
          t1 = track_walkwest(t, ndir);
        else
          t1 = swtch_walkwest(t, ndir);
      } else {
        if(t.type == trktype.TRACK)
          t1 = track_walkeast(t, ndir);
        else
          t1 = swtch_walkeast(t, ndir);
      }
      if((t = findTrack(t1.x, t1.y)) != null)
        return t;
      return findSwitch(t1.x, t1.y);
    }

    public static Track findNextTrack(trkdir direction, int x, int y) {
      trkdir ndir;

      return findNextTrack1(direction, x, y, out ndir);
    }


    private static Track track_walkeast_trk = new Track();
    public static Track track_walkeast(Track t, trkdir ndir) {
      if(t.direction != trkdir.TRK_N_S && t.elinkx != 0 && t.elinky != 0) {
        track_walkeast_trk.x = t.elinkx;
        track_walkeast_trk.y = t.elinky;
        return track_walkeast_trk;
      }
      track_walkeast_trk.x = t.x + 1;
      track_walkeast_trk.y = t.y;
      switch(t.direction) {
        case trkdir.NW_SE:
        case trkdir.W_SE:
          ++track_walkeast_trk.y;
          break;
        case trkdir.SW_NE:
        case trkdir.W_NE:
          --track_walkeast_trk.y;
          break;
        case trkdir.SW_N:
          if(ndir == trkdir.N_S) {
            track_walkeast_trk.x = t.x - 1;
            track_walkeast_trk.y = t.y + 1;
            ndir = trkdir.E_W;
            break;
          }
          track_walkeast_trk.y = t.y - 1;
          track_walkeast_trk.x = t.x;
          ndir = trkdir.S_N;
          break;
        case trkdir.NW_S:
          if(ndir == trkdir.S_N) {
            ndir = trkdir.E_W;
            track_walkeast_trk.x = t.x - 1;
            track_walkeast_trk.y = t.y - 1;
            break;
          }
          track_walkeast_trk.x = t.x;
          track_walkeast_trk.y = t.y + 1;
          ndir = trkdir.N_S;
          break;
        case trkdir.NE_S:
          if(ndir == trkdir.S_N) {
            ndir = trkdir.W_E;
            track_walkeast_trk.x = t.x + 1;
            track_walkeast_trk.y = t.y - 1;
            break;
          }
          track_walkeast_trk.x = t.x;
          track_walkeast_trk.y = t.y + 1;
          ndir = trkdir.N_S;
          break;

        case trkdir.SE_N:
          if(ndir == trkdir.N_S) {
            track_walkeast_trk.x = t.x + 1;
            track_walkeast_trk.y = t.y + 1;
            ndir = trkdir.W_E;
            break;
          }
          track_walkeast_trk.y = t.y - 1;
          track_walkeast_trk.x = t.x;
          ndir = trkdir.S_N;
          break;

        case trkdir.TRK_N_S:
          walk_vertical(track_walkeast_trk, t, ndir);
          break;

        case trkdir.X_X:
          break;

        default:
          ndir = trkdir.W_E;
          break;
      }

      return track_walkeast_trk;
    }

    private static Track track_walkwest_trk = new Track();
    public static Track track_walkwest(Track t, trkdir ndir) {

      if(t.direction != trkdir.TRK_N_S && t.wlinkx != 0 && t.wlinky != 0) {
        track_walkwest_trk.x = t.wlinkx;
        track_walkwest_trk.y = t.wlinky;
        return track_walkwest_trk;
      }
      track_walkwest_trk.x = t.x - 1;
      track_walkwest_trk.y = t.y;
      switch(t.direction) {
        case trkdir.SW_N:
          if(ndir == trkdir.N_S) {
            ++track_walkwest_trk.y;
            ndir = trkdir.E_W;
            break;
          }
          ndir = trkdir.S_N;
          goto case trkdir.SW_NE;

        case trkdir.SW_NE:
        case trkdir.SW_E:
          ++track_walkwest_trk.y;
          break;

        case trkdir.NW_S:
          if(ndir == trkdir.N_S) {
            track_walkwest_trk.x = t.x;
            track_walkwest_trk.y = t.y + 1;
            break;
          }
          ndir = trkdir.E_W;
          goto case trkdir.NW_SE;

        case trkdir.NW_SE:
        case trkdir.NW_E:
          --track_walkwest_trk.y;
          break;

        case trkdir.NE_S:
          if(ndir == trkdir.S_N) {
            track_walkwest_trk.x = t.x + 1;
            track_walkwest_trk.y = t.y - 1;
            ndir = trkdir.W_E;
            break;
          }
          ndir = trkdir.N_S;
          track_walkwest_trk.y = t.y + 1;
          track_walkwest_trk.x = t.x;
          break;
        case trkdir.SE_N:
          if(ndir == trkdir.N_S) {
            track_walkwest_trk.x = t.x + 1;
            track_walkwest_trk.y = t.y + 1;
            ndir = trkdir.W_E;
            break;
          }
          ndir = trkdir.S_N;
          track_walkwest_trk.x = t.x;
          track_walkwest_trk.y = t.y - 1;
          break;
        case trkdir.TRK_N_S:
          walk_vertical(track_walkwest_trk, t, ndir);
          break;

        case trkdir.X_X:
          break;

        default:
          ndir = trkdir.E_W;
          break;
      }
      return track_walkwest_trk;
    }

    private static Track swtch_walkeast_trk = new Track();
    public static Track swtch_walkeast(Track t, trkdir ndir) {
      swtch_walkeast_trk.x = t.x;
      swtch_walkeast_trk.y = t.y;
      switch((int)t.direction) {
        case 0:
          ++swtch_walkeast_trk.x;
          if(t.switched)
            --swtch_walkeast_trk.y;
          break;

        case 1:
        case 3:
        case 11:
          ++swtch_walkeast_trk.x;
          break;

        case 2:
          ++swtch_walkeast_trk.x;
          if(t.switched)
            ++swtch_walkeast_trk.y;
          break;

        case 4:
          ++swtch_walkeast_trk.x;
          if(!t.switched)
            --swtch_walkeast_trk.y;
          break;

        case 5:
          ++swtch_walkeast_trk.x;
          --swtch_walkeast_trk.y;
          break;

        case 6:
          ++swtch_walkeast_trk.x;
          if(!t.switched)
            ++swtch_walkeast_trk.y;
          break;

        case 7:
          ++swtch_walkeast_trk.x;
          ++swtch_walkeast_trk.y;
          break;

        case 8:		    /* These are special cases handled in findPath() */
        case 9:
        case 16:
        case 17:
          break;

        case 10:
          ++swtch_walkeast_trk.x;
          if(t.switched)
            ++swtch_walkeast_trk.y;
          else
            --swtch_walkeast_trk.y;
          break;

        case 12:
        case 13:
        case 14:
        case 15:
        case 18:
        case 19:
        case 20:
        case 21:
        case 22:
        case 23:
          walk_vertical_switch(swtch_walkeast_trk, t, ndir);
          break;

      }
      return swtch_walkeast_trk;
    }

    private static Track swtch_walkwest_trk = new Track();
    public static Track swtch_walkwest(Track t, trkdir ndir) {

      swtch_walkwest_trk.x = t.x;
      swtch_walkwest_trk.y = t.y;
      switch((int)t.direction) {
        case 1:
          --swtch_walkwest_trk.x;
          if(t.switched)
            --swtch_walkwest_trk.y;
          break;

        case 0:
        case 2:
        case 10:
          --swtch_walkwest_trk.x;
          break;

        case 3:
          --swtch_walkwest_trk.x;
          if(t.switched)
            ++swtch_walkwest_trk.y;
          break;

        case 4:
          --swtch_walkwest_trk.x;
          ++swtch_walkwest_trk.y;
          break;

        case 5:
          --swtch_walkwest_trk.x;
          if(!t.switched)
            ++swtch_walkwest_trk.y;
          break;

        case 7:
          --swtch_walkwest_trk.x;
          if(!t.switched)
            --swtch_walkwest_trk.y;
          break;

        case 6:
          --swtch_walkwest_trk.x;
          --swtch_walkwest_trk.y;
          break;

        case 8:		    /* These are special cases handled in findPath() */
        case 9:
        case 16:
        case 17:
          break;

        case 11:
          --swtch_walkwest_trk.x;
          if(t.switched)
            ++swtch_walkwest_trk.y;
          else
            --swtch_walkwest_trk.y;
          break;

        case 12:
        case 13:
        case 14:
        case 15:
        case 18:
        case 19:
        case 20:
        case 21:
        case 22:
        case 23:
          walk_vertical_switch(swtch_walkwest_trk, t, ndir);
          break;
      }
      return swtch_walkwest_trk;
    }

    public static void walk_vertical(Track trk, Track t, trkdir ndir) {
      if(ndir == trkdir.N_S) {
        if(t.elinkx != 0 && t.elinky != 0) {
          trk.x = t.elinkx;
          trk.y = t.elinky;
          return;
        }
        trk.x = t.x;
        trk.y = t.y + 1;
        return;
      }
      if(t.wlinkx != 0 && t.wlinky != 0) {
        trk.x = t.wlinkx;
        trk.y = t.wlinky;
        return;
      }
      trk.x = t.x;
      trk.y = t.y - 1;
    }

    public static void walk_vertical_switch(Track trk, Track t, trkdir ndir) {
      switch((int)t.direction) {
        case 12:
          if(ndir == trkdir.W_E)
            ndir = trkdir.S_N;
          if(ndir == trkdir.S_N) {
            trk.x = t.x;
            trk.y = t.y - 1;
          } else if(t.switched) {
            trk.x = t.x - 1;
            trk.y = t.y + 1;
            ndir = trkdir.E_W;
          } else {
            trk.x = t.x;
            trk.y = t.y + 1;
          }
          break;

        case 13:
          if(ndir == trkdir.E_W)
            ndir = trkdir.S_N;
          if(ndir == trkdir.S_N) {
            trk.x = t.x;
            trk.y = t.y - 1;
          } else if(t.switched) {
            trk.x = t.x + 1;
            trk.y = t.y + 1;
            ndir = trkdir.W_E;
          } else {
            trk.x = t.x;
            trk.y = t.y + 1;
          }
          break;

        case 14:
          if(ndir == trkdir.W_E)
            ndir = trkdir.N_S;
          if(ndir == trkdir.N_S) {
            trk.x = t.x;
            trk.y = t.y + 1;
          } else if(t.switched) {
            trk.x = t.x - 1;
            trk.y = t.y - 1;
            ndir = trkdir.E_W;
          } else {
            trk.x = t.x;
            trk.y = t.y - 1;
          }
          break;

        case 15:
          if(ndir == trkdir.E_W)
            ndir = trkdir.N_S;
          if(ndir == trkdir.N_S) {
            trk.x = t.x;
            trk.y = t.y + 1;
          } else if(t.switched) {
            trk.x = t.x + 1;
            trk.y = t.y - 1;
            ndir = trkdir.W_E;
          } else {
            trk.x = t.x;
            trk.y = t.y - 1;
          }
          break;

        case 18:
          if(t.switched) {
            if(ndir == trkdir.W_E)
              ndir = trkdir.S_N;
            if(ndir == trkdir.S_N) {
              trk.x = t.x;
              trk.y = t.y - 1;
            } else {
              trk.x = t.x - 1;
              trk.y = t.y + 1;
              ndir = trkdir.E_W;
            }
            break;
          }
          if(ndir == trkdir.W_E) {
            trk.x = t.x + 1;
            trk.y = t.y - 1;
          } else {
            trk.x = t.x - 1;
            trk.y = t.y + 1;
          }
          break;

        case 19:
          if(t.switched) {
            if(ndir == trkdir.E_W)
              ndir = trkdir.N_S;
            if(ndir == trkdir.S_N) {
              trk.x = t.x + 1;
              trk.y = t.y - 1;
              ndir = trkdir.W_E;
            } else {
              trk.x = t.x;
              trk.y = t.y + 1;
            }
            break;
          }
          if(ndir == trkdir.W_E || ndir == trkdir.S_N) {
            trk.x = t.x + 1;
            trk.y = t.y - 1;
          } else {
            trk.x = t.x - 1;
            trk.y = t.y + 1;
          }
          break;

        case 20:
          if(t.switched) {
            if(ndir == trkdir.E_W)
              ndir = trkdir.S_N;
            if(ndir == trkdir.N_S) {
              trk.x = t.x + 1;
              trk.y = t.y + 1;
              ndir = trkdir.W_E;
            } else {
              trk.x = t.x;
              trk.y = t.y - 1;
            }
            break;
          }
          if(ndir == trkdir.W_E) {
            trk.x = t.x + 1;
            trk.y = t.y + 1;
          } else {
            trk.x = t.x - 1;
            trk.y = t.y - 1;
          }
          break;

        case 21:
          if(t.switched) {
            if(ndir == trkdir.W_E)
              ndir = trkdir.N_S;
            if(ndir == trkdir.S_N) {
              trk.x = t.x - 1;
              trk.y = t.y - 1;
              ndir = trkdir.E_W;
            } else {
              trk.x = t.x;
              trk.y = t.y + 1;
            }
            break;
          }
          if(ndir == trkdir.W_E) {
            trk.x = t.x + 1;
            trk.y = t.y + 1;
          } else {
            trk.x = t.x - 1;
            trk.y = t.y - 1;
          }
          break;

        case 22:
          if(t.switched) {
            if(ndir == trkdir.S_N) {
              trk.x = t.x - 1;
              trk.y = t.y - 1;
              ndir = trkdir.E_W;
              break;
            }
          } else if(ndir == trkdir.S_N) {
            trk.x = t.x + 1;
            trk.y = t.y - 1;
            ndir = trkdir.W_E;
            break;
          }
          trk.x = t.x;
          trk.y = t.y + 1;
          ndir = trkdir.N_S;
          break;

        case 23:
          if(t.switched) {
            if(ndir == trkdir.N_S) {
              trk.x = t.x - 1;
              trk.y = t.y + 1;
              ndir = trkdir.E_W;
              break;
            }
          } else if(ndir == trkdir.N_S) {
            trk.x = t.x + 1;
            trk.y = t.y + 1;
            ndir = trkdir.W_E;
            break;
          }
          trk.x = t.x;
          trk.y = t.y - 1;
          ndir = trkdir.S_N;
          break;
      }
    }

    public static void reserveIntermediateSignals(Array<Signal> intermSigs) {
      for(int i = 0; i < intermSigs.Length(); ++i) {
        Signal sig = intermSigs.At(i);
        sig._nReservations++;
      }
    }



  }
}