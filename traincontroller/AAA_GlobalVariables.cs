using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {

  static partial class GlobalVariables {
    public static Action<Track> track_properties_dialog;
    public static Action<Signal> signal_properties_dialog;
    public static Action<Track> switch_properties_dialog;
    public static Action<Track> trigger_properties_dialog;
    public static Action performance_dialog;
    public static Action options_dialog;
    public static Action select_day_dialog;
    public static Action<Train> train_info_dialog;
    public static Action<Train> assign_dialog;
    public static Action<string> station_sched_dialog;
    public static Action<Itinerary> itinerary_dialog;
    public static Action about_dialog;

    public static TrainDir traindir;
    public static bool bShowCoord = true;
    public static bool gbTrkFirst = false;	    // show .trk before .zip in dialogs
    public static string current_project;	/* name of files that we loaded */
    public static string info_page;		/* HTML page to show in the Scenario Info window */

    public static grid current_grid, field_grid, tools_grid;
    public static grid tgraph_grid;
    public static grid platform_graph_grid;
    public static grid late_graph_grid;

    public static FileOption searchPath = new FileOption(wxPorting.T("SearchPath"), wxPorting.T("Directories with signal scripts"),
                       wxPorting.T("Environment"), wxPorting.T(""));

    public static TDSkin skin_list;
    public static TDSkin curSkin;
    public static TDSkin defaultSkin;

    public static grcolor color_white;
    public static grcolor color_black;
    public static grcolor color_green;
    public static grcolor color_yellow;
    public static grcolor color_red;
    public static grcolor color_orange;
    public static grcolor color_brown;
    public static grcolor color_gray;
    public static grcolor color_lightgray;
    public static grcolor color_darkgray;
    public static grcolor color_magenta;
    public static grcolor color_blue;
    public static grcolor color_cyan;


    public static string tooltipString;	// 3.4c: tooltip shown on mouse move
    public static PlatformSegment segments;

    public static string program_name;

    public static string locale_name;

    public static string status_line;

    public static FileItem file_list;

    public static bool show_canceled = true;
    public static bool show_arrived = true;
    public static bool running = false;
    public static bool layout_modified = false;
    public static bool enable_training = false;

    public static Train stranded;	// list of rolling stock left behind by engine after a split operation.

    public static TextList track_info;

    public static Itinerary itineraries;

    public static Track layout;
    public static Train schedule;

    public static RunDays run_day = RunDays.None;

    public static List<string> gMotivePowerCache;

    public static SwitchBoard switchBoards;

    public static SwitchBoard curSwitchBoard;	    // TODO: move to a SwitchBoardCell field

    //void *e_train_pmap[NTTYPES];

    //void *e_train_pmap_default[NTTYPES];
    //void *w_train_pmap_default[NTTYPES];
    //void *e_car_pmap_default[NTTYPES];
    //void *w_car_pmap_default[NTTYPES];

    public static FileDialog gFileDialog;
    public static FileDialog gScriptFileDialog;
    public static FileDialog gSaveGameFileDialog;
    public static FileDialog gSaveLayoutFileDialog;
    public static FileDialog gSaveImageFileDialog;
    public static FileDialog gSaveTextFileDialog;
    public static FileDialog gSaveHtmlFileDialog;
    public static FileDialog gOpenImageDialog;
    // public static SelectPowerDialog gSelectPowerDialog;

    public static byte[][] colortable = new byte[15][] {
	    new byte[] { 0, 0, 0 },
	    new byte[] { 255, 255, 255 },
	    new byte[] { 0, 255, 0 },
	    new byte[] { 255, 255, 0 },
	    new byte[] { 255, 0, 0 },
	    new byte[] { 255, 128, 0 },
	    new byte[] { 255, 128, 128 },
	    new byte[] { 128, 128, 128 },
	    new byte[] { 168, 168, 168 }, //	new byte[] { 192, 192, 192 },
	    new byte[] { 64, 64, 64 },
	    new byte[] { 0, 0, 255 },	    // blue
	    new byte[] { 0, 255, 255 },    // cyan
	    new byte[] { 202, 31, 123 },   // magenta
	    new byte[] { 0, 0, 0, },       // free
	    new byte[] { 0, 0, 0 }	    // [14] : custom color for option colorBg
    };

    public static tr_rect cliprect = new tr_rect();
    public static bool ignore_cliprect = false;

    public static bool editing = false;
    public static bool updating_all = false;
    public static bool show_grid = false;
    public static bool show_icons = true;
    public static bool show_blocks = true;
    public static bool show_speeds = true;

    public static bool swap_head_tail = false;	/* swap head and tail icons when reversing train */

    public static pxmap[] pixmaps;

    public static char[] update_map = new char[Configuration.XNCELLS * Configuration.YNCELLS];

    public static Image pixels;

    public static int ncarpixmaps, maxcarpixmaps;
    public static pxmap[] carpixmaps;

    public static int npixmaps, maxpixmaps;

    public static string alert_msg;
    public static bool beep_on_alert = true;

    public static bool signal_traditional = true;

    public static int nCommands;
    public static string[] commands = new string[10];

    public static Track signal_list;
		public static Track track_list;
    public static Track text_list;
		public static Track switch_list;
       
    public static bool changed;
    public static bool signals_changed;

    public static int time_mult;
    public static int[] time_mults = new int[] { 1, 2, 3, 5, 7, 10, 15, 20, 30, 60, 120, 240, 300, -1 };
    public static int cur_time_mult = 5; /* start with T x 10 */

    public static string expr_buff; // [EXPR_BUFF_SIZE];

    public static int run_points;
    public static int total_delay;
    public static int total_late;
    public static int[] late_data = new int[60 * 24];	// minutes late accumulated at each minute of the day // 60 minutes * 24 hours

    public static string[] days_short_names = new string[] {
	    wxPorting.T("Mon"),
	    wxPorting.T("Tue"),
	    wxPorting.T("Wed"),
	    wxPorting.T("Thu"),
	    wxPorting.T("Fri"),
	    wxPorting.T("Sat"),
	    wxPorting.T("Sun")
    };

    public static Track tool_layout;
    public static Track tool_tracks;
    public static Track tool_signals;
    public static Track tool_switches;
    public static Track tool_misc;
    public static Track tool_actions;

    public static int ntoolrows = 2;

    public static long current_time;
    public static long start_time;

    public static bool hard_counters = false;

    public static perf perf_easy = new perf(		/* performance tracking */
	100,			/* wrong dest */
	10,			/* late trains */
	1,			/* thrown switch */
	1,			/* cleared signal */
	1,			/* command denied */
	0,			/* turned train */
	0,			/* waiting train */
	5,			/* wrong platform */
	0,			/* number of late trains */
	0,			/* number of wrong destinations */
	0,			/* number of missed stops */
	0			/* wrong rolling stock assignments */
);
    public static perf perf_hard = new perf(		/* performance tracking */
	100,			/* wrong dest */
	10,			/* late trains */
	1,			/* thrown switch */
	3,			/* cleared signal */
	1,			/* command denied */
	1,			/* turned train */
	1,			/* waiting train */
	5,			/* wrong platform */
	0,			/* number of late trains */
	0,			/* number of wrong destinations */
	0,			/* number of missed stops */
	5			/* wrong rolling stock assignments */
);
    public static perf perf_vals;		/* currrent performance values */
    public static perf perf_tot;		/* performace counters */

    public static int total_track_number; /* to prevent endless loops in findPath() */

    public static string time_msg;

    public static bool show_seconds;

    public static int ntrains_arrived;
    public static int ntrains_starting;
    public static int ntrains_running;
    public static int ntrains_waiting;
    public static int ntrains_stopped;
    public static int ntrains_ready;

    public static string total_points_msg;

    public static SaveAssign save_assign_list;

    public static TDFile frply;

    public static bool beep_on_enter;
    public static bool do_beep;

    public static int status_on_top;
    public static int auto_link;
    public static int link_to_left;
    public static int random_delays;
    public static int save_prefs;

    public static int lastModTime = 1;    // incremented when data for listeners is updated

    public static int gFontSizeSmall = 7;
    public static int gFontSizeBig = 10;

    public static int num_listed_trains;
    public static Train[] listed_trains = new Train[0];

    public static TrainInfo train_info;

    public static wxFFile flog;
  }
}