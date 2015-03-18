 /*	trsim.cpp - Created by Giampiero Caprino
 
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

namespace TrainDirPorting {

  public static partial class Globals {
    public static String version = wxPorting.T("3.8v");

#if __linux__
 String host = wxPorting.T(" Linux");
#elif __WXMAC__
 String host = wxPorting.T(" MacOS X");
#elif __FreeBSD__
 String host = wxPorting.T(" FreeBSD");
#else
    public static String host = wxPorting.T("");
#endif

    public static _conf conf;

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

    public static Func<Track, object> track_properties_dialog;
    public static Func<Signal, object> signal_properties_dialog;
    // Erik: I've disabled the following line
    // public static Func<Track, object> switch_properties_dialog;
    public static Func<Track, object> trigger_properties_dialog;
    public static Func<object> performance_dialog;
    public static Func<object> options_dialog;
    public static Func<object> select_day_dialog;
    public static Func<Train, object> train_info_dialog;
    public static Func<Train, object> assign_dialog;
    public static Func<String, object> station_sched_dialog;
    public static Func<Itinerary, object> itinerary_dialog;
    public static Func<object> about_dialog;

    public static bool is_windows;
    public static int[] time_mults = new int[] { 1, 2, 3, 5, 7, 10, 15, 20, 30, 60, 120, 240, 300, -1 };
    public static int cur_time_mult = 5;	/* start with T x 10 */
    public static long start_time;
    public static bool show_speeds = false;
    public static bool signal_traditional = false;
    public static bool show_blocks = false;
    public static bool show_icons = false;
#if WIN32
    public static bool show_tooltip = true;
#else
 int	show_tooltip = 0;
#endif
    public static bool beep_on_alert = true;
    public static bool beep_on_enter = false;
    public static bool show_seconds;
    public static int hard_counters = 0;
    public static bool platform_schedule;
    public static bool show_canceled = true;
    public static bool show_arrived = true;
    public static bool showing_graph = false;	/* windows only */
    public static bool use_real_time = false;
    public static bool layout_modified = false;	/* user edited the layout */
    public static bool enable_training = false;	/* enable signal training menu */
    public static bool random_delays = true;	/* enable delayed entrances and departures */
    public static bool play_synchronously = true;	/* stop simulation while playing sounds */
    public static bool swap_head_tail = false;	/* swap head and tail icons when reversing train */

    public static string[] days_short_names = new string[] {
 	wxPorting.T("Mon"),
 	wxPorting.T("Tue"),
 	wxPorting.T("Wed"),
 	wxPorting.T("Thu"),
 	wxPorting.T("Fri"),
 	wxPorting.T("Sat"),
 	wxPorting.T("Sun")
 };

    public static wxFFile flog;
    public static TDFile frply;

    public static TrainInfo train_info;
    public static String current_project;	/* name of files that we loaded */
    public static String info_page;		/* HTML page to show in the Scenario Info window */

    public static Track layout;
    public static Train schedule;
    public static Train stranded;
    public static TextList track_info;

    public static Track signal_list,
     track_list,
     text_list,
     switch_list;

    public static tr_rect cliprect;
    public static bool ignore_cliprect;
    public static char[] update_map = new char[Configuration.XNCELLS * Configuration.YNCELLS];
    public static int UPDATE_MAP(int x, int y) { return update_map[(y) * Configuration.XNCELLS + (x)]; }

    public static station_sched stat_sched;

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

    public static bool editing;
    public static bool editing_itinerary;
    public static bool running;
    public static int run_points;
    public static int total_delay;
    public static int total_late;
    public static int time_mult;
    public static int current_time;
    public static RunDays run_day;
    public static int total_track_number;	/* to prevent endless loops in findPath() */

    public static int run_point_base = 1;	/* 10 points per second travelled */

    public static string time_msg;
    public static string total_points_msg;
    public static string delay_points_msg;
    public static string time_mult_msg;
    public static string late_points_msg;
    public static string alert_msg;
    public static string status_line;
    public static string dummy_line;

    public static string tooltipString;	// 3.4c: tooltip shown on mouse move

    public static TrLabel[] labelList = new TrLabel[] {
 	new TrLabel(time_msg ),
 	new TrLabel(total_points_msg ),
 	new TrLabel(alert_msg ),
 	new TrLabel(time_mult_msg ),
 	new TrLabel(delay_points_msg ),
 	new TrLabel(late_points_msg ),
 	new TrLabel(dummy_line ),		/* could be used for additional msgs */
 	new TrLabel(status_line ),
 	null
 };

    public static edittools[] tooltbl1024 = new edittools[] {
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.TRACK, trkdir.W_E, 0, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_SE, 1, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_NE, 1, 1 ),
 	new edittools( trktype.TRACK, trkdir.W_NE, 2, 0 ),
 	new edittools( trktype.TRACK, trkdir.W_SE, 2, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_E, 3, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_E, 3, 1 ),
 	new edittools( trktype.TRACK, trkdir.XH_NW_SE, 23, 0 ),
 	new edittools( trktype.TRACK, trkdir.XH_SW_NE, 23, 1 ),
 	new edittools( trktype.TRACK, trkdir.X_X, 24, 0 ),
 	new edittools( trktype.TRACK, trkdir.X_PLUS, 24, 1 ),
 	new edittools( trktype.SWITCH, 0, 4, 0 ),
 	new edittools( trktype.SWITCH, 1, 4, 1 ),
 	new edittools( trktype.SWITCH, 2, 5, 0 ),
 	new edittools( trktype.SWITCH, 3, 5, 1 ),
 	new edittools( trktype.SWITCH, 4, 6, 0 ),
 	new edittools( trktype.SWITCH, 5, 6, 1 ),
 	new edittools( trktype.SWITCH, 10, 7, 0 ),
 	new edittools( trktype.SWITCH, 11, 7, 1 ),
 	new edittools( trktype.SWITCH, 6, 8, 0 ),
 	new edittools( trktype.SWITCH, 7, 8, 1 ),
 	new edittools( trktype.SWITCH, 8, 9, 0 ),
 	new edittools( trktype.SWITCH, 9, 9, 1 ),
 
 	new edittools( trktype.SWITCH, 12, 10, 0 ),	    /* vertical switches */
 	new edittools( trktype.SWITCH, 13, 10, 1 ),
 	new edittools( trktype.SWITCH, 14, 11, 0 ),
 	new edittools( trktype.SWITCH, 15, 11, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_S, 12, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_N, 12, 1 ),
 	new edittools( trktype.TRACK, trkdir.NE_S, 13, 0 ),
 	new edittools( trktype.TRACK, trkdir.SE_N, 13, 1 ),
 	new edittools( trktype.TRACK, trkdir.TRK_N_S, 14, 0 ),
 	new edittools( trktype.ITIN, 0, 14, 1 ),
 	new edittools( trktype.IMAGE, 1, 15, 0 ),
 	new edittools( trktype.PLATFORM, 1, 15, 1 ),
 	new edittools( trktype.TSIGNAL, 0, 16, 0 ),
 	new edittools( trktype.TSIGNAL, 1, 16, 1 ),
 	new edittools( trktype.TSIGNAL, 2, 17, 0 ),
 	new edittools( trktype.TSIGNAL, 3, 17, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.S_N, 18, 0 ),
 	new edittools( trktype.TSIGNAL, trkdir.N_S, 18, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_NORTH_FLEETED, 19, 0 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_SOUTH_FLEETED, 19, 1 ),
 	new edittools( trktype.TEXT, 0, 20, 0 ),
 	new edittools( trktype.TEXT, 1, 20, 1 ),
 	new edittools( trktype.LINK, 0, 21, 0 ),
 	new edittools( trktype.LINK, 1, 21, 1 ),
 	new edittools( trktype.MACRO, 0, 22, 0 ),
 	new edittools( trktype.MACRO, 1, 22, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.W_E, 25, 0 ),
 	new edittools( trktype.TRIGGER, trkdir.E_W, 25, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.N_S, 26, 0 ),
 	new edittools( trktype.TRIGGER, trkdir.S_N, 26, 1 ),
 	null
    };

    public static edittools[] tooltbl800 = new edittools[] {   /* used when screen is 800x600 */
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.TRACK, trkdir.W_E, 0, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_SE, 1, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_NE, 1, 1 ),
 	new edittools( trktype.TRACK, trkdir.W_NE, 2, 0 ),
 	new edittools( trktype.TRACK, trkdir.W_SE, 2, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_E, 3, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_E, 3, 1 ),
 	new edittools( trktype.TRACK, trkdir.XH_NW_SE, 15, 0 ),
 	new edittools( trktype.TRACK, trkdir.XH_SW_NE, 15, 1 ),
 	new edittools( trktype.TRACK, trkdir.X_X, 16, 0 ),
 	new edittools( trktype.TRACK, trkdir.X_PLUS, 16, 1 ),
 	new edittools( trktype.SWITCH, 0, 4, 0 ),
 	new edittools( trktype.SWITCH, 1, 4, 1 ),
 	new edittools( trktype.SWITCH, 2, 5, 0 ),
 	new edittools( trktype.SWITCH, 3, 5, 1 ),
 	new edittools( trktype.SWITCH, 4, 6, 0 ),
 	new edittools( trktype.SWITCH, 5, 6, 1 ),
 	new edittools( trktype.SWITCH, 10, 7, 0 ),
 	new edittools( trktype.SWITCH, 11, 7, 1 ),
 	new edittools( trktype.SWITCH, 6, 8, 0 ),
 	new edittools( trktype.SWITCH, 7, 8, 1 ),
 	new edittools( trktype.SWITCH, 8, 9, 0 ),
 	new edittools( trktype.SWITCH, 9, 9, 1 ),
 
 	new edittools( trktype.SWITCH, 12, 10, 0 ),	    /* vertical switches */
 	new edittools( trktype.SWITCH, 13, 10, 1 ),
 	new edittools( trktype.SWITCH, 14, 11, 0 ),
 	new edittools( trktype.SWITCH, 15, 11, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_S, 12, 0 ),
 	new edittools( trktype.TRACK, trkdir.SW_N, 12, 1 ),
 	new edittools( trktype.TRACK, trkdir.NE_S, 13, 0 ),
 	new edittools( trktype.TRACK, trkdir.SE_N, 13, 1 ),
 	new edittools( trktype.TRACK, trkdir.TRK_N_S, 14, 0 ),
 	new edittools( trktype.ITIN, 0, 14, 1 ),
 	new edittools( trktype.IMAGE, 1, 15, 2 ),
 	new edittools( trktype.PLATFORM, 1, 0, 2 ),
 	new edittools( trktype.TSIGNAL, 0, 1, 2 ),
 	new edittools( trktype.TSIGNAL, 1, 2, 2 ),
 	new edittools( trktype.TSIGNAL, 2, 3, 2 ),
 	new edittools( trktype.TSIGNAL, 3, 4, 2 ),
 	new edittools( trktype.TSIGNAL, trkdir.S_N, 5, 2 ),
 	new edittools( trktype.TSIGNAL, trkdir.N_S, 6, 2 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_NORTH_FLEETED, 7, 2 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_SOUTH_FLEETED, 8, 2 ),
 	new edittools( trktype.TEXT, 0, 9, 2 ),
 	new edittools( trktype.TEXT, 1, 10, 2 ),
 	new edittools( trktype.LINK, 0, 11, 2 ),
 	new edittools( trktype.LINK, 1, 12, 2 ),
 	new edittools( trktype.MACRO, 0, 13, 2 ),
 	new edittools( trktype.MACRO, 1, 14, 2 ),
 	new edittools( trktype.TRIGGER, trkdir.W_E, 17, 0 ),
 	new edittools( trktype.TRIGGER, trkdir.E_W, 17, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.N_S, 18, 0 ),
 	new edittools( trktype.TRIGGER, trkdir.S_N, 18, 1 ),
 	null
 };
    public static edittools[] tooltbltracks = new edittools[] {   /* used when screen is 800x600 */
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.TRACK, trkdir.TRK_N_S, 0, 1 ),
 	new edittools( trktype.TRACK, trkdir.W_E, 1, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_SE, 2, 1 ),
 	new edittools( trktype.TRACK, trkdir.SW_NE, 3, 1 ),
 	new edittools( trktype.TRACK, trkdir.W_NE, 4, 1 ),
 	new edittools( trktype.TRACK, trkdir.W_SE, 5, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_E, 6, 1 ),
 	new edittools( trktype.TRACK, trkdir.SW_E, 7, 1 ),
 	new edittools( trktype.TRACK, trkdir.NW_S, 8, 1 ),
 	new edittools( trktype.TRACK, trkdir.SW_N, 9, 1 ),
 	new edittools( trktype.TRACK, trkdir.NE_S, 10, 1 ),
 	new edittools( trktype.TRACK, trkdir.SE_N, 11, 1 ),
 	new edittools( trktype.TRACK, trkdir.XH_NW_SE, 12, 1 ),
 	new edittools( trktype.TRACK, trkdir.XH_SW_NE, 13, 1 ),
 	new edittools( trktype.TRACK, trkdir.X_X, 14, 1 ),
 	new edittools( trktype.TRACK, trkdir.X_PLUS, 15, 1 ),
 	new edittools( trktype.TRACK, trkdir.N_NE_S_SW, 16, 1 ),	// no switch  / |
 	new edittools( trktype.TRACK, trkdir.N_NW_S_SE, 17, 1 ),	// no switch   |
 	null
 };
    public static edittools[] tooltblswitches = new edittools[] {
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.SWITCH, 0, 0, 1 ),
 	new edittools( trktype.SWITCH, 1, 1, 1 ),
 	new edittools( trktype.SWITCH, 2, 2, 1 ),
 	new edittools( trktype.SWITCH, 3, 3, 1 ),
 	new edittools( trktype.SWITCH, 4, 4, 1 ),
 	new edittools( trktype.SWITCH, 5, 5, 1 ),
 	new edittools( trktype.SWITCH, 6, 6, 1 ),
 	new edittools( trktype.SWITCH, 7, 7, 1 ),
 	new edittools( trktype.SWITCH, 8, 8, 1 ),
 	new edittools( trktype.SWITCH, 9, 9, 1 ),
 	new edittools( trktype.SWITCH, 10, 10, 1 ),
 	new edittools( trktype.SWITCH, 11, 11, 1 ),
 
 	new edittools( trktype.SWITCH, 12, 12, 1 ),	    /* vertical switches */
 	new edittools( trktype.SWITCH, 13, 13, 1 ),
 	new edittools( trktype.SWITCH, 14, 14, 1 ),
 	new edittools( trktype.SWITCH, 15, 15, 1 ),
 	new edittools( trktype.SWITCH, 16, 16, 1 ),
 	new edittools( trktype.SWITCH, 17, 17, 1 ),
 	new edittools( trktype.SWITCH, 18, 18, 1 ),
 	new edittools( trktype.SWITCH, 19, 19, 1 ),
 	new edittools( trktype.SWITCH, 20, 20, 1 ),
 	new edittools( trktype.SWITCH, 21, 21, 1 ),
 	new edittools( trktype.SWITCH, 22, 22, 1 ),
 	new edittools( trktype.SWITCH, 23, 23, 1 ),
 	null
 };
    public static edittools[] tooltblsignals = new edittools[] {
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.TSIGNAL, 0, 0, 1 ),
 	new edittools( trktype.TSIGNAL, 1, 1, 1 ),
 	new edittools( trktype.TSIGNAL, 2, 2, 1 ),
 	new edittools( trktype.TSIGNAL, 3, 3, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.S_N, 4, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.N_S, 5, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_NORTH_FLEETED, 6, 1 ),
 	new edittools( trktype.TSIGNAL, trkdir.signal_SOUTH_FLEETED, 7, 1 ),
 	null
 };
    public static edittools[] tooltblmisc = new edittools[] {
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.TEXT, 0, 0, 1 ),
 	new edittools( trktype.TEXT, 1, 1, 1 ),
 	new edittools( trktype.ITIN, 0, 2, 1 ),
 	new edittools( trktype.ITIN, 1, 3, 1 ),
 	new edittools( trktype.IMAGE, 1, 4, 1 ),
 	new edittools( trktype.PLATFORM, 1, 5, 1 ),
 	null
 };
    public static edittools[] tooltblactions = new edittools[] {
 	new edittools( trktype.TEXT, 0, 0, 0 ),
 	new edittools( trktype.LINK, 0, 0, 1 ),
 	new edittools( trktype.LINK, 1, 1, 1 ),
 	new edittools( trktype.MACRO, 0, 2, 1 ),
 	new edittools( trktype.MACRO, 1, 3, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.W_E, 4, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.E_W, 5, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.N_S, 6, 1 ),
 	new edittools( trktype.TRIGGER, trkdir.S_N, 7, 1 ),
 	new edittools( trktype.MOVER, 0, 8, 1 ),
 	new edittools( trktype.MOVER, 1, 9, 1 ),
 	new edittools( trktype.MOVER, 2, 10, 1 ),
 	new edittools( trktype.POWERTOOL, 0, 11, 1 ),
 	null
 };

    public static int current_toolset;
    public static int current_tool;
    public static edittools[] tooltbl = tooltbltracks /* tooltbl800 */;
    public static Track tool_layout;
    public static Track tool_tracks, tool_signals, tool_switches, tool_misc, tool_actions;

    public static String[] en_station_titles = new string[] { wxPorting.T("Train"), wxPorting.T("Arrival"), wxPorting.T("From"), wxPorting.T("Departure"),
 				wxPorting.T("To&nbsp;&nbsp;&nbsp;"), wxPorting.T("Runs&nbsp;on&nbsp;&nbsp;"),
 				wxPorting.T("Platform"), wxPorting.T("Notes"),
 				null };
    public static String[] station_titles = new string[9];

    public static int ntrains_arrived;
    public static int ntrains_starting;
    public static int ntrains_running;
    public static int ntrains_waiting;
    public static int ntrains_stopped;
    public static int ntrains_ready;

    public static String skip_blanks(String p) {
      while(p[0] == wxPorting.T(' ') || p[0] == wxPorting.T('t'))
        p.incPointer();
      return p;
    }

    public static void remove_ext(String buff) {
      //String p;

      ///* remove extension. Will be added back by open cmd */
      //for(p = buff + Globals.wxStrlen(buff); *p != ' ' && *p != '/' &&
      //    *p != '\\' && *p != '.'; --p) ;
      //if(p[0] == '.')
      //  *p = 0;
    }

    public static String format_time(long tim)
 {
 	string buff;
 
 	// !Rask Ingemann Lambersten - added seconds
 	buff = String.Format( wxPorting.T("%3d:%02d:%02d "), (tim / 3600) % 24, (tim / 60) % 60, tim % 60);
 	return(buff);
 }

    public static int parse_time(String pp) {
      throw new NotImplementedException();
      //String p = *pp;
      //int v = 0, v1 = 0, v2 = 0;

      //while(p[0] == ' ') p.incPointer();
      //if(*p)
      //  v = *p.incPointer() - '0';
      //if(*p != ':')
      //  v = v * 10 + (*p.incPointer() - '0');
      //if(p[0] == ':')
      //  p.incPointer();
      //if(*p)
      //  v1 = *p.incPointer() - '0';
      //if(p[0] >= '0' && p[0] <= '9')
      //  v1 = v1 * 10 + (*p.incPointer() - '0');
      //if(p[0] == ':') {	    // +Rask Ingemann Lambersten
      //  p.incPointer();
      //  if(p[0] >= '0' && p[0] <= '9')
      //    v2 = *p.incPointer() - '0';
      //  if(p[0] >= '0' && p[0] <= '9')
      //    v2 = v2 * 10 + (*p.incPointer() - '0');
      //}		    // +Rask Ingemann Lambersten
      //*pp = p;
      //return v * 3600 + v1 * 60 + v2;
    }

    public static String parse_km(Track t, String p) {
      throw new NotImplementedException();
      //String pp;

      //t.km = wxStrtol(p, &pp, 10) * 1000;
      //if(*pp == '.')
      //  t.km += wxStrtol(pp + 1, &pp, 10) % 1000;
      //return pp;
    }

    public static void compute_train_numbers() {
      //Train t;

      //ntrains_arrived = 0;
      //ntrains_waiting = 0;
      //ntrains_stopped = 0;
      //ntrains_ready = 0;
      //ntrains_starting = 0;
      //ntrains_running = 0;
      //for(t = schedule; t != null; t = t.next) {
      //  switch(t.status) {
      //    case trainstat.train_READY:
      //      if(run_day == 0 || (t.days & run_day) != 0)
      //        ++ntrains_ready;
      //      break;
      //    case trainstat.train_STARTING:
      //      ++ntrains_starting;
      //      break;
      //    case trainstat.train_RUNNING:
      //      ++ntrains_running;
      //      break;
      //    case trainstat.train_WAITING:
      //      ++ntrains_waiting;
      //      break;
      //    case trainstat.train_STOPPED:
      //      ++ntrains_stopped;
      //      break;
      //    case trainstat.train_ARRIVED:
      //      ++ntrains_arrived;
      //  }
      //}
    }

    public static long performance() {
      throw new NotImplementedException();
      //long tot;

      //tot = perf_tot.wrong_dest * perf_vals.wrong_dest;
      //tot += perf_tot.late_trains * perf_vals.late_trains;
      //tot += perf_tot.thrown_switch * perf_vals.thrown_switch;
      //tot += perf_tot.cleared_signal * perf_vals.cleared_signal;
      //tot += perf_tot.turned_train * perf_vals.turned_train;
      //tot += perf_tot.waiting_train * perf_vals.waiting_train;
      //tot += perf_tot.wrong_platform * perf_vals.wrong_platform;
      //tot += perf_tot.denied * perf_vals.denied;
      //return tot;
    }

    public static void update_labels() {
      //time_msg = String.Copy( wxPorting.T("   "));
      //if(show_seconds)
      //  time_msg + 3 = String.Format( wxPorting.T("%3ld:%02ld.%02ld "), (current_time / 3600) % 24,
      //      (current_time / 60) % 60,
      //      current_time % 60);
      //else
      //  time_msg + 3 = String.Copy( format_time(current_time));

      //// show name of current day, if any
      //if(run_day != 0) {
      //  int i;
      //  for(i = 0; i < 7 && ((int)run_day & (1 << i)) == 0; ++i) ;
      //  if(i < 7) {
      //    time_msg + Globals.wxStrlen(time_msg) = String.Format(
      //    wxPorting.T(" (%s) "), days_short_names[i]);
      //  }
      //}
      //time_msg + Globals.wxStrlen(time_msg) = String.Format( wxPorting.T("   x%d    "), time_mult);
      //time_msg + Globals.wxStrlen(time_msg) = String.Format( wxPorting.T("R %d/S %d/r %d/w %d/s %d/a %d"),
      //    ntrains_running, ntrains_starting, ntrains_ready, ntrains_waiting,
      //    ntrains_stopped, ntrains_arrived);
      ///*	time_mult_msg = String.Format(    wxPorting.T("   Time multiplier: %4ld"), time_mult);
      // total_points_msg = String.Format( wxPorting.T("Performance    : -%4ld"), performance());
      // delay_points_msg = String.Format( wxPorting.T("Delay minutes  : %4ld"), total_delay / 60);
      // late_points_msg = String.Format(  wxPorting.T("Late arrivals  : %4ld min"), total_late); */
      //total_points_msg = String.Format( wxPorting.T("Pt:%4ld, Del:%4ld, Late:%4ld"),
      //        -performance(), total_delay / 60, total_late);
      //repaint_labels();
    }

    public static void print_train_info(Train t) {
      //t.Get(train_info);
    }

    public static void invalidate_field()	/* next time, repaint whole field */
    {
      Globals.cliprect.top = 0;
      Globals.cliprect.left = 0;
      Globals.cliprect.bottom = Configuration.YNCELLS;
      Globals.cliprect.right = Configuration.XNCELLS;
      ignore_cliprect = true;
    }

    public static void reset_clip_rect()	/* next time, don't paint anything */
    {
      //Globals.cliprect.top = Configuration.YNCELLS;
      //Globals.cliprect.bottom = 0;
      //Globals.cliprect.left = Configuration.XNCELLS;
      //Globals.cliprect.right = 0;
      //ignore_cliprect = 0;
      //memset(update_map, 0, sizeof(update_map));
    }

    public static void change_coord(int x, int y) {
      change_coord(x, y, 3, 1);
    }
    public static void change_coord(int x, int y, int w, int h)/* next time, paint within clip rectangle */
    {
      //int i;

      //if(x < 0) x = 0;
      //if(y < 0) y = 0;
      //if(x + w >= Configuration.XNCELLS)
      //  w = Configuration.XNCELLS - x;
      //if(y + h >= Configuration.YNCELLS)
      //  h = Configuration.YNCELLS - y;
      //if(x < Globals.cliprect.left)
      //  Globals.cliprect.left = x;
      //if(x + w > Globals.cliprect.right)
      //  Globals.cliprect.right = x + w;
      //if(y < Globals.cliprect.top)
      //  Globals.cliprect.top = y;
      //if(y + h > Globals.cliprect.bottom)
      //  Globals.cliprect.bottom = y + h;
      //while(h-- >= 0) {
      //  for(i = 0; i <= w; ++i) {
      //    UPDATE_MAP(x + i, y, 1);
      //  }
      //  ++y;
      //}
    }

    public static Track init_tool_from_array(edittools[] tbl) {
      throw new NotImplementedException();
      //int i;
      //Track t;
      //Track lst;

      //lst = null;
      //for(i = 0; tbl[i].type != -1; ++i) {
      //  t = track_new();
      //  tbl[i].trk = t;
      //  t.x = tbl[i].x;
      //  t.y = tbl[i].y;
      //  t.type = (trktype)tbl[i].type;
      //  t.direction = (trkdir)tbl[i].direction;
      //  t.norect = 1;
      //  t.next = lst;
      //  if(t.type == TEXT)
      //    t.station = String.Copy(i == 0 ? wxPorting.T("Del") : wxPorting.T("Abc"));
      //  else if(t.type == ITIN)
      //    t.station = String.Copy(wxPorting.T("A"));
      //  else if(t.type == TSIGNAL && (t.direction & 2)) {
      //    t.fleeted = 1;
      //    t.direction = (trkdir)((int)t.direction & (~2));
      //  }
      //  lst = t;
      //}
      //return lst;
    }

    public static void init_tool_layout() {
      tool_layout = init_tool_from_array(tooltbl);	/* old way */
      tool_tracks = init_tool_from_array(tooltbltracks);/* new way */
      tool_switches = init_tool_from_array(tooltblswitches);
      tool_signals = init_tool_from_array(tooltblsignals);
      tool_misc = init_tool_from_array(tooltblmisc);
      tool_actions = init_tool_from_array(tooltblactions);
    }

    public static void free_tool_list(Track t) {
      Track nxt;

      while(t != null) {
        nxt = t.next;
        if(String.IsNullOrEmpty(t.station) == false)
          Globals.free(t.station);
        Globals.free(t);
        t = nxt;
      }
    }

    public static void free_tool_layout() {
      free_tool_list(tool_layout);
      free_tool_list(tool_tracks);
      free_tool_list(tool_switches);
      free_tool_list(tool_signals);
      free_tool_list(tool_misc);
      free_tool_list(tool_actions);
    }

    public static void tool_selected(int x, int y) {
      //int i;

      //if(y == 0) {
      //  switch(x) {
      //    case 1:
      //      current_toolset = x;
      //      tooltbl = tooltbltracks;
      //      select_tool(0);
      //      return;

      //    case 2:
      //      current_toolset = x;
      //      tooltbl = tooltblswitches;
      //      select_tool(0);
      //      return;

      //    case 3:
      //      current_toolset = x;
      //      tooltbl = tooltblsignals;
      //      select_tool(0);
      //      return;

      //    case 4:
      //      current_toolset = x;
      //      tooltbl = tooltblmisc;
      //      select_tool(0);
      //      return;

      //    case 5:
      //      current_toolset = x;
      //      tooltbl = tooltblactions;
      //      select_tool(0);
      //      return;
      //  }
      //}
      //for(i = 0; tooltbl[i].type != -1; ++i)
      //  if(tooltbl[i].x == x && tooltbl[i].y == y) {
      //    break;
      //  }
      //if(tooltbl[i].type == -1)
      //  return;
      //if(tooltbl[i].type == trktype.MACRO) {
      //  if(!macro_select())
      //    return;
      //  ++i;	    // automatically select "Place"
      //}
      //if(tooltbl[i].type == trktype.POWERTOOL) {
      //  Globals.traindir.OpenSelectPowerDialog();
      //  return;
      //}
      //select_tool(i);
    }

    public static int track_updated(Track trk) {
      if(trk.x < (cliprect.left - 1) || trk.x > Globals.cliprect.right)
        return 0;
      if(trk.y < (cliprect.top - 1) || trk.y > Globals.cliprect.bottom)
        return 0;
      /* it's inside the clip rect, but do we really need to update it? */

      if(ignore_cliprect || UPDATE_MAP(trk.x, trk.y) != 0)
        return 1;
      return 0;
    }

    public static void layout_paint(Track lst) {
//      Track trk;
//      int x, y;

//      if(!ignore_cliprect) {
//#if true
//        if(!editing &&
//            (cliprect.top < 0 || Globals.cliprect.top >= Configuration.YNCELLS ||
//            Globals.cliprect.bottom < 0 || Globals.cliprect.bottom >= Configuration.YNCELLS ||
//            Globals.cliprect.left < 0 || Globals.cliprect.left >= Configuration.XNCELLS ||
//            Globals.cliprect.right < 0 || Globals.cliprect.right >= Configuration.XNCELLS)) {
//          trk = 0;
//          return;
//        }
//#endif
//        for(y = Globals.cliprect.top; y <= Globals.cliprect.bottom; ++y)
//          for(x = Globals.cliprect.left; x <= Globals.cliprect.right; ++x)
//            if(UPDATE_MAP(x, y) != 0)
//              tr_fillrect(x, y);
//      }

//      for(trk = lst; trk; trk = trk.next)
//        if(editing || track_updated(trk)) {
//          UPDATE_MAP(trk.x, trk.y, 0);
//          track_paint(trk);
//        }
    }

    public static void trains_paint(Train trn) {
      //for(; trn != null; trn = trn.next) {
      //  if(trn.position) {
      //    if(!show_icons) {
      //      int tmp = trn.position.fgcolor;
      //      trn.position.fgcolor = color_orange;
      //      track_paint(trn.position);
      //      trn.position.fgcolor = tmp;
      //      continue;
      //    } else if((trn.flags & TFLG.TFLG_STRANDED) != 0) {
      //      if(findTrain(trn.position.x, trn.position.y))
      //        continue;
      //      car_draw(trn.position, trn);
      //    } else
      //      train_draw(trn.position, trn);
      //  }
      //  if(trn.tail != null && trn.tail.position != null &&
      //    trn.tail.position != trn.position)
      //    car_draw(trn.tail.position, trn);
      //}
    }

    public static void link_all_tracks(Track layout)
 {
 // Track	t, l;
 
 // l = 0;
 // for(t = layout; t != null; t = t.next)
 //     if(t.type == trktype.TRACK) {
 //   t.next1 = l;
 //   l = t;
 //     }
 // track_list = l;
 // l = 0;
 // for(t = layout; t != null; t = t.next)
 //   if(t.type == trktype.TSIGNAL) {
 //   t.next1 = l;
 //   l = t;
 //     }
 // signal_list = l;
 // l = 0;
 // for(t = layout; t != null; t = t.next)
 //   if(t.type == trktype.SWITCH) {
 //   t.next1 = l;
 //   l = t;
 //     }
 // switch_list = l;
 // l = 0;
 // for(t = layout; t != null; t = t.next)
 //   if(t.type == trktype.TEXT) {
 //   t.next1 = l;
 //   l = t;
 //     }
 // text_list = l;
 }

    public static void link_all_tracks() {
      link_all_tracks(layout);
    }

    public static void init_sim() {
      //if(tool_layout == null)
      //  init_tool_layout();
      //time_mult = 10;
      //cur_time_mult = 5;
      //run_points = 0;
      //total_delay = 0;
      //total_late = 0;
      //memset(late_data, 0, sizeof(late_data));
      //alert_msg[0] = 0;
      //String p;
      //int i;
      //for(i = 0; i < 7; ++i) {
      //  p = days_short_names[i];
      //  days_short_names[i] = (string)wxPorting.LV(p);
      //}
    }

    public static void trainsim_init() {
      //Track t;
      //Train trn;

      //ntoolrows = 3;
      //tooltbl = tooltbl800;
      //if(tool_layout == null)
      //  init_tool_layout();
      //conf.fgcolor = fieldcolors[(int)fieldcolor.COL_TRACK];
      //conf.linkcolor = color_red;
      //conf.linkcolor2 = color_blue;
      //current_time = start_time;
      //run_points = 0;
      //total_delay = 0;
      //total_late = 0;
      //time_mult = 10;
      //cur_time_mult = 5;
      //alert_msg[0] = 0;
      //perf_vals = hard_counters != 0 ? perf_hard : perf_easy;
      //memset(&perf_tot, 0, sizeof(perf_tot));
      //link_all_tracks();
      //total_track_number = 0;
      //for(t = track_list; t; t = t.next1)
      //  ++total_track_number;
      //showing_graph = 0;
      //reset_schedule();
      ///*
      //while((trn = stranded)) {
      //    stranded = trn.next;
      //    leave_track(trn);
      //    delete trn;
      //} */
      //trn = schedule;
      //schedule = stranded;
      //stranded = null;
      //reset_schedule();
      //schedule = trn;
      //fill_schedule(schedule, 0);
      //compute_train_numbers();
      //update_labels();
    }

    public static void init_all() {
      while(layout != null)
        track_delete(layout);
      onIconUpdateListeners.Clear();
      //	if(script_text)
      //	    Globals.free(script_text);
      //	script_text = 0;
      clean_trains(schedule);
      schedule = null;
      clean_trains(stranded);
      stranded = null;
      start_time = 0;
      trainsim_init();
      invalidate_field();
      repaint_all();
    }

    private static Track find_in_list(Track t, int x, int y) {
      for(; t != null; t = t.next1)
        if(t.x == x && t.y == y)
          return t;
      return null;
    }
    
    public static Track findTrack(int x, int y) {
      return findTrackType(x, y, trktype.TRACK);
    }
    public static Track findSwitch(int x, int y) {
          return findTrackType(x, y, trktype.SWITCH);
    }
    public static Signal findSignal(int x, int y) {
          return (Signal)findTrackType(x, y, trktype.TSIGNAL);
    }
    public static Track findPlatform(int x, int y) {
          return findTrackType(x, y, trktype.PLATFORM);
    }
    public static Track findText(int x, int y) {
      return findTrackType(x, y, trktype.TEXT);
    }
    public static Track findImage(int x, int y) {
      return findTrackType(x, y, trktype.IMAGE);
    }
  
    public static Track findTrackType(int x, int y, trktype type) {
      Track t;

      switch(type) {
        case trktype.TRACK:
          return find_in_list(track_list, x, y);
        case trktype.TSIGNAL:
          return find_in_list(signal_list, x, y);
        case trktype.SWITCH:
          return find_in_list(switch_list, x, y);
        case trktype.TEXT:
          return find_in_list(text_list, x, y);
      }
      for(t = layout; t != null; t = t.next)
        if(t.x == x && t.y == y && t.type == type)
          return t;
      return null;
    }

    public static Track findLinkTo(int x, int y) {
      Track t;

      for(t = layout; t != null; t = t.next)
        if(t.type == trktype.TEXT) {
          if(t.wlinkx == x && t.wlinky == y)
            return t;
          if(t.elinkx == x && t.elinky == y)
            return t;
        }
      return null;
    }

    public static Track findTriggerTo(int x, int y) {
      Track t;

      for(t = layout; t != null; t = t.next)
        if(t.type == trktype.TRIGGER) {
          if(t.wlinkx == x && t.wlinky == y)
            return t;
          if(t.elinkx == x && t.elinky == y)
            return t;
        }
      return null;
    }

    public static Track findStationNamed(String name) {
      throw new NotImplementedException();
      // return TrainController.Station.FindStationNamed(name);
    }

    public static Track findStation(String name) {
      throw new NotImplementedException();
      //Track t, l;

      //for(t = layout; t != null; t = t.next) {
      //  if(t.type == trktype.TRACK && t.isstation)
      //    if(!wxStrcmp(name, t.station))
      //      return t;
      //  if(t.type == trktype.TEXT && !wxStrcmp(name, t.station) &&
      //      ((t.wlinkx && t.wlinky) || (t.elinkx && t.elinky)))
      //    return t;
      //  l = t;
      //}
      //return 0;
    }

    public static Signal findSignalNamed(String name) {
      throw new NotImplementedException();
      //Track t;

      //for(t = layout; t != null; t = t.next)
      //  if(t.type == trktype.TSIGNAL && t.station && !wxStrcmp(name, t.station))
      //    return (Signal)t;
      //return 0;
    }

    public static Track findItineraryNamed(String name) {
      throw new NotImplementedException();
      //Track* t;

      //for(t = layout; t != null; t = t.next)
      //  if(t.type == trktype.ITIN && t.station && !wxStrcmp(name, t.station))
      //    return t;
      //return 0;
    }

    public static TrainStop findStop(Train trn, Track trk) {
      TrainStop stp;

      if(trk == null || String.IsNullOrEmpty(trk.station))
        return null;
      for(stp = trn.stops; stp != null; stp = stp.next)
        if(sameStation(stp.station, trk.station))
          break;
      return stp;
    }

    public static Train findTrain(int x, int y) {
      throw new NotImplementedException();
      //Train tr;

      //for(tr = schedule; tr != null; tr = tr.next)
      //  if(tr.position && tr.position.x == x && tr.position.y == y)
      //    return tr;
      //return 0;
    }

    public static Train findTrainNamed(String name) {
      throw new NotImplementedException();
      //Train t;

      //for(t = schedule; t != null; t = t.next)
      //  if(!wxStrcmp(name, t.name))
      //    return t;
      //return null;
    }

    public static Train findTail(int x, int y) {
      throw new NotImplementedException();
      //Train tr;

      //for(tr = schedule; tr != null; tr = tr.next)
      //  if(tr.tail && tr.tail.position &&
      //    tr.tail.position.x == x && tr.tail.position.y == y)
      //    return tr;
      //return null;
    }

    public static Train findStranded(int x, int y) {
      throw new NotImplementedException();
      //Train tr;

      //for(tr = stranded; tr != null; tr = tr.next)
      //  if(tr.position && tr.position.x == x && tr.position.y == y)
      //    return tr;
      //return 0;
    }

    public static Train findStrandedTail(int x, int y) {
      throw new NotImplementedException();
      //Train trn;

      //for(trn = stranded; trn != null; trn = trn.next)
      //  if(trn.tail && trn.tail.position &&
      //    trn.tail.position.x == x && trn.tail.position.y == y)
      //    return trn;
      //return null;
    }

    public static void remove_from_stranded_list(Train tr) {
      Train old = null;
      Train t;

      for(t = stranded; t != null && t != tr; t = t.next)
        old = t;
      if(t == null)
        return;
      if(old != null)
        old.next = t.next;
      else
        stranded = t.next;
    }

    public static bool sameStationPlatform(String s1, String s2) {
      if(platform_schedule)
        return wxStrcmp(s1, s2) == 0;
      return sameStation(s1, s2);
    }


    public static void NameWithoutPlatform(String outStr, string name)
 {
  //    string temp;
  //string p;
 
  //temp = String.Copy( name);
  //if((p = wxStrchr(temp, PLATFORM_SEP)) != null)
  //    *p = 0;
  //outStr = temp;
 }


    private static Track array_append(out int nstations, out int maxstations, ref Track stations,
         Track t)
    {
      throw new NotImplementedException();
      //int i;

      //for(i = 0; i < nstations; ++i)
      //  if(!platform_schedule) {
      //    if(sameStation(stations[i].station, t.station))
      //      break;
      //  } else if(!wxStrcmp(stations[i].station, t.station))
      //    break;
      //if(i < nstations)		/* already in list */
      //  return stations;
      //if(nstations + 1 >= maxstations) {
      //  maxstations += 10;
      //  if(!stations)
      //    stations = (Track**)malloc(sizeof(Track*) * maxstations);
      //  else
      //    stations = (Track**)realloc(stations,
      //            sizeof(Track*) * maxstations);
      //}
      //stations[nstations] = t;
      //++nstations;
      //return stations;
    }

    public static int cmp_names(object a, object b) {
      String pa = (String)a;
      String pb = (String)b;
      return (wxStrcmp(pa, pb));
    }

    public static int cmp_stations(object a, object b) {
      Track ap = (Track)a;
      Track bp = (Track)b;

      return (wxStrcmp(ap.station, bp.station));
    }

    public static Track[] get_station_list() {
      throw new NotImplementedException();
      //Track t;
      //Track stations;
      //int nstations, maxstations;

      //stations = 0;
      //nstations = 0;
      //maxstations = 0;
      //for(t = layout; t; t = t.next) {
      //  if(!t.isstation || !t.station)
      //    continue;
      //  stations = array_append(&nstations, &maxstations, stations, t);
      //}
      //if(stations) {
      //  qsort(stations, nstations, sizeof(Track*), cmp_stations);
      //  stations[nstations] = 0;
      //}
      //return stations;
    }

    public static Track get_entry_list() {
      throw new NotImplementedException();
      //Track t;
      //Track stations;
      //int nstations, maxstations;

      //stations = 0;
      //nstations = 0;
      //maxstations = 0;
      //for(t = layout; t; t = t.next) {
      //  if(t.type != TEXT)
      //    continue;
      //  if(t.wlinkx && t.wlinky) {
      //  } else if(t.elinkx && t.elinky) {
      //  } else
      //    continue;
      //  stations = array_append(&nstations, &maxstations, stations, t);
      //}
      //if(stations) {
      //  qsort(stations, nstations, sizeof(Track*), cmp_stations);
      //  stations[nstations] = 0;
      //}
      //return stations;
    }

    public static String name_append(out int nnames, out int maxnames, String names, String str) {
      throw new NotImplementedException();
      //int i;

      //for(i = 0; i < *nnames; ++i)
      //  if(sameStation(names[i], str))
      //    break;
      //if(i != *nnames)		/* already in list */
      //  return names;
      //if(*nnames + 1 >= *maxnames) {
      //  *maxnames += 20;
      //  if(!names)
      //    names = (String*)malloc(sizeof(String) * *maxnames);
      //  else
      //    names = (String*)realloc(names, sizeof(String) * *maxnames);
      //}
      //names[*nnames] = str;
      //++*nnames;
      //return names;
    }

    public static String get_all_station_list() {
      throw new NotImplementedException();
      //Track t;
      //Train tr;
      //TrainStop ts;
      //String names;
      //int nnames, maxnames;

      //names = 0;
      //nnames = 0;
      //maxnames = 0;
      //for(t = layout; t; t = t.next) {
      //  if(!t.isstation || !t.station)
      //    continue;
      //  names = name_append(&nnames, &maxnames, names, t.station);
      //}
      //for(tr = schedule; tr; tr = tr.next)
      //  for(ts = tr.stops; ts; ts = ts.next)
      //    names = name_append(&nnames, &maxnames, names, ts.station);
      //if(names) {
      //  qsort(names, nnames, sizeof(String), cmp_names);
      //  names[nnames] = 0;
      //}
      //return names;
    }

    public static void do_alert(String msg) {
      alert_msg = String.Copy( msg);
      repaint_labels();
      Globals.traindir.AddAlert(msg);
      if(beep_on_alert)
        alert_beep();
    }

    public static void add_linked_info_to_status(Track t)
 {
         //if(t.wlinkx && t.wlinky) {
         //    status_line += string.Format(
         //        wxPorting.T(" (%s %d,%d)"), wxPorting.L("linked to"), t.wlinkx, t.wlinky);
         //} else if(t.elinkx && t.elinky) {
         //    status_line += string.Format(
         //        wxPorting.T(" (%s %d,%d)"), wxPorting.L("linked to"), t.elinkx, t.elinky);
         //}
 }

    public static void pointer_at(Coord cell) {
      //Track	t;
      //Signal sig;
      //Train tr;
      //int x = cell.x;
      //int y = cell.y;
      //String p = "";

      //tooltipString[0] = 0;
      //if((tr = findTrain(x, y))) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s %s"), x, y, tr.name, train_status0(tr, 1));
      //  tr.SetTooltip();
      //} else if((t = findTrack(x, y)) != null || (t = findSwitch(x, y)) != null) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s "), x, y, wxPorting.L("speed"));
      //  p = status_line + Globals.wxStrlen(status_line);
      //  for(x = 0; x < Config.NTTYPES; ++x) {
      //    wxSprintf(p, wxPorting.T("%d/"), t.speed[x]);
      //    p += Globals.wxStrlen(p);
      //  }
      //  wxSprintf(--p, wxPorting.T(" Km/h, %s %d m"), wxPorting.L("length"), t.length);
      //  if(t.isstation)
      //    status_line += string.Format(
      //         wxPorting.T("  %s: %s"), wxPorting.L("Station"), t.station);
      //} else if((t = findText(x, y)) != null) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s %s"), x, y, wxPorting.L("entry/exit"), t.station);
      //  add_linked_info_to_status(t);
      //} else if((sig = findSignal(x, y)) != null) {
      //  if(sig.controls)
      //    status_line = String.Format(wxPorting.T("%d,%d: %s %s %s %d, %d"), x, y,
      //        wxPorting.L("Signal"), sig.station ? sig.station : wxPorting.T(""),
      //        wxPorting.L("controls"), sig.controls.x, sig.controls.y);
      //  else
      //    status_line = String.Format(wxPorting.T("%d,%d: %s %s"), x, y,
      //        wxPorting.L("Signal"), sig.station ? sig.station : wxPorting.T(""));
      //  if(String1.IsNullOrEmpty(sig.stateProgram) == false) {
      //    status_line += string.Format(
      //        wxPorting.T("  %s: \"%s\""), wxPorting.L("script"), sig.stateProgram);
      //    status_line += string.Format(
      //        wxPorting.T("  %s: \"%s\""), wxPorting.L("aspect"), sig._currentState ? sig._currentState : wxPorting.T("?"));
      //  }
      //} else if((t = findTrackType(x, y, TRIGGER))) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s - %s  . (%d,%d)  Prob.: "),
      //x, y, wxPorting.L("Trigger"), t.station ? t.station : wxPorting.T(""), t.wlinkx, t.wlinky);
      //  p = status_line + Globals.wxStrlen(status_line);
      //  for(x = 0; x < NTTYPES; ++x) {
      //    wxSprintf(p, wxPorting.T("%d/"), t.speed[x]);
      //    p += Globals.wxStrlen(p);
      //  }
      //  p[-1] = 0;
      //} else if((t = findTrackType(x, y, ITIN))) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s - %s"), x, y,
      //      wxPorting.L("Itinerary"), t.station ? t.station : wxPorting.T(""));
      //} else if((t = findTrackType(x, y, IMAGE))) {
      //  status_line = String.Format(wxPorting.T("%d,%d: %s %s"), x, y,
      //      wxPorting.L("Image"), t.station ? t.station : wxPorting.T(""));
      //  add_linked_info_to_status(t);
      //} else {
      //  status_line[0] = 0;
      //}
      //repaint_labels();
    }

    public static void update_schedule(Train t) {
      //int i;
      //Train* t0;

      //for(i = 0, t0 = schedule; t0 && t0 != t; t0 = t0.next) {
      //  if(!t.entrance)
      //    continue;
      //  if(show_canceled || !is_canceled(t0))
      //    ++i;
      //}
      //if(!t0)
      //  return;
      ////print_train_info(t);
      //gr_update_schedule(t, i);
      //t.newsched = 0;
      //t._lastUpdate = lastModTime++;
    }

    public static void edit_cmd() {
      if(editing)
        return;
      if(editing_itinerary)		/* exit edit itinerary mode */
        itinerary_cmd();
      editing = true;			/* enter edit layout mode */
      hide_table();
      show_tooltable();
      repaint_all();
    }

    public static void noedit_cmd() {
      //Track* t;

      //if(!editing)
      //  return;
      //editing = 0;
      //link_all_tracks();
      //total_track_number = 0;
      //for(t = track_list; t; t = t.next1)
      //  ++total_track_number;
      //hide_tooltable();
      //show_table();
      //link_signals(layout);
      //invalidate_field();
      //repaint_all();
      //check_layout_errors();
    }

    public static void itinerary_cmd() {
      //if(editing_itinerary) {		/* back to simulation mode */
      //  editing_itinerary = false;
      //  hide_itinerary();
      //  show_table();
      //} else {
      //  if(editing)			/* exit edit layout mode */
      //    noedit_cmd();
      //  editing_itinerary = tr_fillrect;	/* enter edit itinerary mode */
      //  hide_table();
      //  show_itinerary();
      //}
      //repaint_all();
    }

    public static void do_replay()
 {
  //long	issue_time;
  //size_t	pos;
  //String p;
  //string buff;
 
  //while(frply) {
  //    pos = frply.GetPos();
  //    if(!frply.ReadLine(buff, sizeof(buff)/sizeof(char)))
  //  break;
  //    // Erik: Disabled ==> buff[sizeof(buff)/sizeof(buff[0]) - 1] = 0;
  //    p = buff + Globals.wxStrlen(buff);
  //    if(p > buff && p[-1] == 'n') --p;
  //    if(p > buff && p[-1] == 'r') --p;
  //    *p = 0;
  //    issue_time = wxStrtoul(buff, &p, 10);
  //    if(p[0] == ',') p.incPointer();
  //    if(issue_time > current_time) {	/* goes into next time slice */
  //  frply.SetPos(pos);		/* back off to cmd start */
  //  return;				/* nothing else to do */
  //    }
  //    trainsim_cmd(p);
  //}
  //if(frply) {
  //    delete frply;
  //    frply = null;
  //}
 }

    public static void free_station_schedule() {
      //station_sched sc;

      //while((sc = stat_sched)) {
      //  stat_sched = sc.next;
      //  Globals.free(sc);
      //}
    }

    static int stschcmp(object a, object b) {
      throw new NotImplementedException();
      //station_sched* ap = *(station_sched**)a;
      //station_sched* bp = *(station_sched**)b;
      //long t1, t2;

      //if((t1 = ap.arrival) == -1)
      //  t1 = ap.departure;
      //if((t2 = bp.arrival) == -1)
      //  t2 = bp.departure;
      //return (t1 < t2 ? -1 : t1 == t2 ? 0 : 1);
    }

    public static station_sched sort_station_schedule(station_sched sched) {
      throw new NotImplementedException();
      //station_sched** qb;
      //station_sched* t;
      //int ntrains;
      //int l;

      //for(t = sched, ntrains = 0; t; t = t.next)
      //  ++ntrains;
      //qb = (station_sched**)malloc(sizeof(station_sched*) * ntrains);
      //for(t = sched, l = 0; l < ntrains; ++l, t = t.next)
      //  qb[l] = t;
      //qsort(qb, ntrains, sizeof(station_sched*), stschcmp);
      //for(l = 0; l < ntrains - 1; ++l)
      //  qb[l].next = qb[l + 1];
      //qb[ntrains - 1].next = 0;
      //t = qb[0];
      //Globals.free(qb);
      //return t;
    }

    public static void build_station_schedule(String station) {
      //Train* tr;
      //TrainStop* ts;
      //station_sched* sc;

      //free_station_schedule();
      //for(tr = schedule; tr; tr = tr.next) {
      //  if(sameStationPlatform(tr.entrance, station)) {
      //    sc = (station_sched*)malloc(sizeof(station_sched));
      //    memset(sc, 0, sizeof(station_sched));
      //    sc.tr = tr;
      //    sc.arrival = -1;
      //    sc.departure = tr.timein;
      //    sc.stopname = tr.entrance;
      //    sc.next = stat_sched;
      //    stat_sched = sc;
      //  } else if(sameStationPlatform(tr.exit, station)) {
      //    sc = (station_sched*)malloc(sizeof(station_sched));
      //    memset(sc, 0, sizeof(station_sched));
      //    sc.tr = tr;
      //    sc.arrival = tr.timeout;
      //    sc.departure = -1;
      //    sc.stopname = tr.exit;
      //    sc.next = stat_sched;
      //    stat_sched = sc;
      //  } else for(ts = tr.stops; ts; ts = ts.next) {
      //      if(sameStationPlatform(ts.station, station)) {
      //        sc = (station_sched*)malloc(sizeof(station_sched));
      //        memset(sc, 0, sizeof(station_sched));
      //        sc.tr = tr;
      //        sc.arrival = ts.arrival;
      //        sc.departure = ts.departure;
      //        sc.stopname = ts.station;
      //        if(!ts.minstop)
      //          sc.transit = 1;
      //        sc.next = stat_sched;
      //        stat_sched = sc;
      //        break;
      //      }
      //    }
      //}
      //if(stat_sched)
      //  stat_sched = sort_station_schedule(stat_sched);
    }

    public static void do_station_list_print(String station_name, HtmlPage page)
 {
 // String p;
 // int	i;
 // string buff;
 // station_sched	sc;
 // string[] buffs = new string[8];
 ////	String cols[9];
 // String[] cols = new string[9];
 // String[] values = new string[9];
 
 // buff = String.Copy( wxPorting.T("station.htm"));
 // cols[0] = values[0];
 // cols[1] = values[1];
 // cols[2] = values[2];
 // cols[3] = values[3];
 // cols[4] = values[4];
 // cols[5] = values[5];
 // cols[6] = values[6];
 // cols[7] = values[7];
 // cols[8] = null;
 
 // buffs[0] = String.Copy( station_name);
 // if((p = wxStrchr(buffs[0], PLATFORM_SEP)))
 //     *p = 0;
 // buff = String.Format( wxPorting.T("%s %s"), wxPorting.L("Station of"), buffs[0]);
 // if(p && platform_schedule)
 //     buff + Globals.wxStrlen(buff) = String.Format( wxPorting.T(" - %s %s"), wxPorting.L("Platform"), p + 1);
 // page.StartPage(buff);
 // buff = String.Format(
 //     wxPorting.T("<br><a href=\"savestationinfopage %s\">%s</a><br>\n"), station_name, wxPorting.L("Save as text"));
 // page.Add(buff);
 // for(i = 0; en_station_titles[i]; ++i)
 //     station_titles[i] = wxPorting.LV(en_station_titles[i]);
 // page.StartTable(station_titles);
 // for(sc = stat_sched; sc; sc = sc.next) {
 // /* when reassigning train stock, we consider only
 //     trains that are scheduled to depart at the same
 //     station where the assignee has arrived. */
 //     buffs[0] = string.Format(wxPorting.T("<a href=\"traininfopage %s\">%s</a>"), sc.tr.name, sc.tr.name);
 //     values[0] = buffs[0];
 //////	    cols[0] = String.Copy( sc.tr.name);
 //     buffs[2][0] = 0;
 //     if(sc.transit) {
 //   values[1] = wxPorting.T("");
 //   buffs[2] = String.Copy( sc.tr.entrance);
 //   if((p = wxStrchr(buffs[2], PLATFORM_SEP)))
 //       *p = 0;
 //     } else if(sc.arrival != -1) {
 //   values[1] = format_time(sc.arrival);
 //   buffs[2] = String.Copy( sc.tr.entrance);
 //   if((p = wxStrchr(buffs[2], PLATFORM_SEP)))
 //       *p = 0;
 //     } else {
 //   values[1] = wxPorting.T("");
 //     }
 //     values[2] = buffs[2];
 //     if(sc.departure != -1) {
 //   if(sc.transit)
 //       buffs[3] = string.Format(wxPorting.T("(%s)"), format_time(sc.departure));
 //   else
 //       buffs[3] = String.Copy( format_time(sc.departure));
 //   values[3] = buffs[3];
 //   buffs[4] = String.Copy( sc.tr.exit);
 //   if((p = wxStrchr(buffs[4], PLATFORM_SEP)))
 //       *p = 0;
 //   values[4] = buffs[4];
 //     } else {
 //   values[3] = wxPorting.T("");
 //   values[4] = wxPorting.T("");
 //     }
 //     buffs[5][0] = 0;
 //     for(i = 0; i < 7; ++i)
 //   if(sc.tr.days & (1 << i))
 //       buffs[5] += string.Format(wxPorting.T("%d"), i+1);
 //     values[5] = buffs[5];
 //     buffs[6][0] = 0;
 //     if(sc.stopname && (p = wxStrchr(sc.stopname, PLATFORM_SEP)))
 //   buffs[6] = string.Format(wxPorting.T("%s"), p + 1);
 //     values[6] = buffs[6];
 //     buffs[7][0] = 0;
 //     if(sc.tr.nnotes)
 //   buffs[7] = string.Copy(sc.tr.notes[0]);
 //     values[7] = buffs[7];
 //     page.AddTableRow(8, cols);
 // }
 // page.EndTable();
 // page.EndPage();
 }

    public static int all_trains_everyday(Train t) {
      throw new NotImplementedException();
      //while(t) {
      //  if(t.days)
      //    return 0;
      //  t = t.next;
      //}
      //return 1;
    }

    public static void do_itinerary_dialog(int x, int y)
 {
 // Itinerary it = 0;
 // Signal	sig;
 // string buff;
 
 // sig = findSignal(x, y);
 // if(!sig)
 //     return;
 // if(!sig.station || !*sig.station) {
 //     buff = String.Format( wxPorting.T("(%d,%d)"), sig.x, sig.y);
 //     sig.station = String.Copy(buff);
 // }
 ///*	for(it = itineraries; it; it = it.next)
 //     if(!wxStrcmp(it.signame, sig.station))
 //   break;
 //*/	if(!it) {
 //     it = (Itinerary *)calloc(sizeof(Itinerary), 1);
 //     it.signame = String.Copy(sig.station);
 //     it.name = String.Copy(wxPorting.T(""));
 //     it.next = itineraries;
 //     itineraries = it;
 // }
 // fill_itinerary(it, (Signal *)sig);
 // itinerary_dialog(it);
 }

    public static int set_itin_name(Itinerary it, String name, String nextit)
 {
      throw new NotImplementedException();
  //Itinerary it1, it2;
  //String p;
 
  //if((p = wxStrchr(name, ',')))	/* no commas allowed */
  //    *p = 0;
  //it2 = 0;
  //for(it1 = itineraries; it1; it2 = it1, it1 = it1.next)
  //    if(it1 != it && !wxStrcmp(name, it1.name)) {
  //  if(ask(wxPorting.L("An itinerary by the same name already exists.\n" +
  //    "Do you want to replace the old itinerary with the new one?"))
  //    == AskAnswer.ANSWER_YES) {
  //      if(!it2)
  //    itineraries = it1.next;
  //      else
  //    it2.next = it1.next;
  //      if(it1.signame) Globals.free(it1.signame);
  //      Globals.free(it1.name);
  //      Globals.free(it1);
  //      break;
  //  }
  //  return 0;		/* let user change name */
  //    }
  //if(it.name)
  //    Globals.free(it.name);
  //it.name = String.Copy(name);
 
  //if((p = wxStrchr(nextit, ',')))	/* no commas allowed */
  //    *p = 0;
  //if(it.nextitin)
  //    Globals.free(it.nextitin);
  //it.nextitin = String.Copy(nextit);
  //return 1;
 }

    public static int set_track_properties(Track t, String len, String station, String speed,
              String distance, String wlink, String elink)
 {
      throw new NotImplementedException();

  //String p;
  //int	flag;
 
  //t.length = wxAtol(len);
  //t.speed[0] = (short)wxStrtol(speed, &p, 10);
  //for(flag = 1; flag < NTTYPES && p[0] == '/'; ++flag) {
  //    t.speed[flag] = (short)wxStrtol(p + 1, &p, 10);
  //}
  //t.isstation = 0;
  //if(t.station)
  //    Globals.free(t.station);
  //t.station = 0;
  //flag = 0;
  //if(station && *station) {
  //    t.station = String.Copy(station);
  //    if(t.type != TEXT && t.type != TSIGNAL)
  //  t.isstation = 1;
  //    else
  //  flag = 1;
  //}
  //if(*distance)
  //    parse_km(t, distance);
  //else
  //    t.km = 0;
  //t.wlinkx = (short)wxStrtol(wlink, &p, 10);
  //if(p[0] == ',') p.incPointer();
  //t.wlinky = (short)wxStrtol(p, &p, 10);
 
  //if(t.type == IMAGE)
  //    t.pixels = 0;	/* will reload image from file */
  //else if(t.type != TSIGNAL && t.type != SWITCH) {
  //    t.elinkx = (short)wxStrtol(elink, &p, 10);
  //    if(p[0] == ',') p.incPointer();
  //    t.elinky = (short)wxStrtol(p, &p, 10);
  //}
  //return flag;
 }

    public static void load_new_scenario(String cmd, int fl)
 {
  //while(*cmd == ' ') ++cmd;
  //if(running)
  //    start_stop();
  //if(layout_modified) {
  //    if(ask_to_save_layout() < 0)	// cancel selected
  //  return;
  //}
  //clean_trains(schedule);
  //clean_trains(stranded);
  //schedule = 0;
  //stranded = 0;
  //invalidate_field();
  //enable_training = 0;
  //if(fl == 2) {
  //    load_puzzles(cmd);
  //    trainsim_init();		/* clear counters, timer */
  //    load_scripts(layout);	// run OnInit scripts
  //    enable_training = 1;
  //} else {
  //    if(!(layout = load_field(cmd))) {
  //  status_line = String.Format( wxPorting.T("%s '%s.trk'"), wxPorting.L("cannot load"), cmd);
  //  Globals.traindir.Error(status_line);
  //  return;
  //    }
  //    if(!(schedule = load_trains(cmd)))
  //  Globals.traindir.Error(wxPorting.L("No schedule for this territory!"));
  //    if(fl && !all_trains_everyday(schedule) && select_day_dialog)
  //  select_day_dialog();
  //    if(fl)
  //  check_delayed_entries(schedule);
  //    /* fill_schedule(schedule, 0); */
  //    trainsim_init();		/* clear counters, timer */
  //    load_scripts(layout);	// run OnInit scripts
  //           bstreet_playing();
  //}
 
  //TDFile	infoFile = new TDFile(cmd);
 
  //       String ext;
 
  //       ext = String.Format(wxPorting.T("%s.htm"), locale_name);
  //       infoFile.SetExt(ext);
  //       if(infoFile.Load()) {
  //    Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
  //    info_page = infoFile.name.GetName();
  //       } else {
  //           infoFile.SetExt(wxPorting.T(".htm"));
  //    if(infoFile.Load()) {
  //        Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
  //        info_page = infoFile.name.GetName();
  //    } else {
  //        TDFile	indexFile = new TDFile(wxPorting.T("index.htm"));
  //        if(indexFile.Load()) {
  //      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), indexFile.content);
  //      info_page = wxPorting.T("index.htm");
  //        } else
  //      info_page = wxPorting.T("");
  //    }
  //       }
  //if(fl == 2) {
  //    show_puzzle();
  //}
  //repaint_all();
  //       timetable._lastReloaded = ++lastModTime;
  //       timetable.NotifyListeners();
 }

    public static Itinerary parse_itinerary(String cmd) {
      throw new NotImplementedException();

      //for(; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd) ;
      //String nameend = wxStrrchr(cmd, wxPorting.T('@'));
      //int namelen;
      //Itinerary* it;

      //if(nameend)
      //  namelen = nameend - cmd;
      //else
      //  namelen = Globals.wxStrlen(cmd);
      //for(it = itineraries; it; it = it.next) {
      //  if(!Globals.wxStrncmp(it.name, cmd, namelen) && Globals.wxStrlen(it.name) == namelen)
      //    break;
      //}
      //return it;
    }

    public static void do_command(String cmd, bool sendToClients)
 {
 // String p;
 // Train	*t;
 // Track	*trk;
 // int	x, y, fl;
 // string buff;
 
 // if(!Globals.wxStrncmp(cmd, wxPorting.T("log"), 3)) {
 //     if(!flog.IsOpened()) {
 //   if(!(flog.Open(wxPorting.T("log"), wxPorting.T("w"))))
 //       do_alert(wxPorting.L("Cannot create log file."));
 //   return;
 //     }
 //     flog.Close();
 //     return;
 // }
 // if(!Globals.wxStrncmp(cmd, wxPorting.T("replay"), 6)) {
 //     for(p = cmd + 6; p[0] == ' ' || p[0] == 't'; p.incPointer());
 //     buff = String.Format( wxPorting.T("%s.log"), p);
 //     if(!(frply = new TDFile(buff))) {
 //   do_alert(wxPorting.L("Cannot read log file."));
 //   return;
 //     }
 //     /* replay commands are issued whenever the clock is updated */
 //     return;
 // }
 // if(flog.IsOpened())
 //     flog.Write(String.Format(wxPorting.T("%ld,%sn"), current_time, cmd));
 // buff = String.Format( wxPorting.T("%ld,%sn"), current_time, cmd);
 // if(sendToClients)
 //     send_msg(buff);
 // if(!Globals.wxStrncmp(cmd, wxPorting.T("quit"), 4))
 //     main_quit_cmd();
 // else if(!Globals.wxStrncmp(cmd, wxPorting.T("about"), 5)) {
 //     about_dialog();
 // } else if(!wxStrcmp(cmd, wxPorting.T("edititinerary"))) {
 //     itinerary_cmd();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("edit"), 4)) {
 //     if(running)
 //   start_stop();
 //     edit_cmd();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("noedit"), 6))
 //     noedit_cmd();
 // else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationsched"), 12))
 //     station_sched_dialog(null);
 // else if(!Globals.wxStrncmp(cmd, wxPorting.T("paths"), 5))
 //     create_path_window();
 // else if(!Globals.wxStrncmp(cmd, wxPorting.T("fast"), 4)) {
 //     if(time_mults[cur_time_mult + 1] != -1)
 //   time_mult = time_mults[++cur_time_mult];
 //     update_labels();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("slow"), 4)) {
 //     if(cur_time_mult > 0) {
 //   time_mult = time_mults[--cur_time_mult];
 //   update_labels();
 //     }
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("t0"), 2)) {
 //     if(cont(wxPorting.L("Do you want to restart the simulation?")) == AskAnswer.ANSWER_YES) {
 //   if(!all_trains_everyday(schedule))
 //       select_day_dialog();
 //   clear_delays();
 //   fill_schedule(schedule, 0);
 //         status_line = String.Format( wxPorting.L("Simulation restarted."));
 //         trainsim_init();
 //   invalidate_field();
 //   update_button(wxPorting.T("stop"), wxPorting.L("Stop"));
 //   repaint_all();
 //     }
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("speeds"), 6)) {
 //     show_speeds = !show_speeds;
 //     invalidate_field();
 //     repaint_all();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traditional"), 6)) {
 //     signal_traditional = !signal_traditional;
 //     invalidate_field();
 //     repaint_all();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("graph"), 6)) {
 //     create_tgraph();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("blocks"), 6)) {
 //     show_blocks = !show_blocks;
 //     invalidate_field();
 //     repaint_all();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("alert"), 5)) {
 //     beep_on_alert = !beep_on_alert;
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sched"), 5)) {
 //     create_schedule(0);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("run"), 3)) {
 //     start_stop();
 //     update_button(wxPorting.T("run"), running ? wxPorting.L("Stop") : wxPorting.L("Start"));
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("newtrain"), 8)) {
 //     create_train();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("greensigs"), 9)) {
 //     open_all_signals();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("shunt"), 5)) {
 //     cmd += 5;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     if(!(t = findTrainNamed(cmd)))
 //   return;
 //     shunt_train(t);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traininfopage"), 13)) {
 //     cmd += 13;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     if(!(t = findTrainNamed(cmd)))
 //   return;
 //     ShowTrainInfo(t);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traininfo"), 9)) {
 //     cmd += 9;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     if(!(t = findTrainNamed(cmd)))
 //   return;
 //     train_info_dialog(t);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("decelerate"), 10)) {
 //     long    val;
 //     String end;
 
 //     cmd += 10;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     val = wxStrtol(cmd, &end, 0);
 //     while(*end == ' ' || *end == 't') ++end;
 //     if(!(t = findTrainNamed(end)))
 //   return;
 //     decelerate_train(t, val);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("accelerate"), 10)) {
 //     long    val;
 //     String end;
 
 //     cmd += 10;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     val = wxStrtol(cmd, &end, 0);
 //     while(*end == ' ' || *end == 't') ++end;
 //     if(!(t = findTrainNamed(end)))
 //   return;
 //     accelerate_train(t, val);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationinfopage"), 15)) {
 //     cmd += 15;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     ShowStationSchedule(cmd, false);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("savestationinfopage"), 19)) {
 //     cmd += 19;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     ShowStationSchedule(cmd, true);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationinfo"), 11)) {
 //     cmd += 11;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     station_sched_dialog(cmd);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("reverse"), 7)) {
 //     cmd += 7;
 //     while(*cmd == ' ' || *cmd == 't') ++cmd;
 //     if(!(t = findTrainNamed(cmd)))
 //   return;
 //     reverse_train(t);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("new"), 3)) {
 //     if(running)
 //   start_stop();
 //     if(layout_modified) {
 //   if(ask_to_save_layout() < 0)	// cancel selected
 //       return;
 //     }
 //     init_all();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("save "), 5)) {
 //     if(save_layout(cmd + 5, layout))
 //   status_line = String.Format( wxPorting.T("%s '%s.trk'."), wxPorting.L("Layout saved in file"), cmd + 5);
 //     repaint_labels();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("savegame "), 9)) {
 //     if(save_game(cmd + 9))
 //   status_line = String.Format( wxPorting.T("%s '%s.sav'."), wxPorting.L("Game status saved in file"), cmd + 9);
 //     repaint_labels();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("restore "), 8)) {
 //     if(layout_modified) {
 //   if(ask_to_save_layout() < 0)	// cancel selected
 //       return;
 //     }
 //     restore_game(cmd + 8);
 //     invalidate_field();
 //     repaint_all();
 //     fill_schedule(schedule, 0);
 //     update_labels();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("open"), 4) || !Globals.wxStrncmp(cmd, wxPorting.T("load"), 4)) {
 //     fl = cmd[0] == 'o';		/* open vs. load */
 //     cmd += 4;
 //     load_new_scenario(cmd, fl);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("puzzle"), 6)) {
 //     cmd += 6;
 //     load_new_scenario(cmd, 2);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("click"), 5)) {
 //     for(cmd += 5; *cmd == ' ' || *cmd == 't'; ++cmd);
 //     if(*cmd >= '0' && *cmd <= '9') {
 //   String end;
 //   x = wxStrtol(cmd, &end, 10);
 //   if(isalpha(*end))
 //       goto isItin;
 //   if(*end == ',') ++end;
 //   y = wxStrtol(end, &end, 10);
 //     } else {
 //isItin:
 //   if(!(trk = findItineraryNamed(cmd)))
 //       return;		/* impossible ? */
 //   x = trk.x;
 //   y = trk.y;
 //     }
 //     track_selected(x, y);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("rclick"), 6)) {
 //     for(cmd += 6; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
 //     if(*cmd >= wxPorting.T('0') && *cmd <= wxPorting.T('9')) {
 //   String end;
 //   x = wxStrtol(cmd, &end, 10);
 //   if(*end == wxPorting.T(',')) ++end;
 //   y = wxStrtol(end, &end, 10);
 //     } else {
 //   if(!(trk = findItineraryNamed(cmd)))
 //       return;		/* impossible ? */
 //   x = trk.x;
 //   y = trk.y;
 //     }
 //     track_selected1(x, y);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("ctrlclick"), 9)) {
 //     for(cmd += 9; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
 //     if(*cmd >= '0' && *cmd <= '9') {
 //   String end;
 //   x = wxStrtol(cmd, &end, 10);
 //   if(*end == wxPorting.T(',')) ++end;
 //   y = wxStrtol(end, &end, 10);
 //     } else {
 //   if(!(trk = findItineraryNamed(cmd)))
 //       return;		/* impossible ? */
 //   x = trk.x;
 //   y = trk.y;
 //     }
 //     Coord	coord = new Coord(x, y);
 //     track_control_selected(coord);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("selecttool"), 10)) {
 //     String end;
 //     for(cmd += 10; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
 //     x = wxStrtol(cmd, &end, 10);
 //     if(*end == wxPorting.T(',')) ++end;
 //     y = wxStrtol(end, &end, 10);
 //     tool_selected(x, y);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("itinerary"), 9)) {
 //            Itinerary *it = parse_itinerary(cmd + 9);
 //     if(it)
 //                it.Select();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("delitinerary"), 9)) {
 //            Itinerary *it = parse_itinerary(cmd + 12);
 //     if(it)
 //                it.Deselect(false);
 // } else if(!wxStrcmp(cmd, wxPorting.T("info"))) {
 //     track_info_dialogue();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-edit"), 7)) {
 //     SwitchboardEditCommand(cmd + 7);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-browser"), 10)) {
 //     SwitchboardOpenBrowser(cmd + 10);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-cell"), 7)) {
 //     SwitchboardCellCommand(cmd + 7);
 // } else if(!wxStrcmp(cmd, wxPorting.T("performance"))) {
 //     performance_dialog();
 // } else if(!wxStrcmp(cmd, wxPorting.T("performance_toggle_canceled"))) {
 //     performance_toggle_canceled();
 //     performance_dialog();	// update page
 // } else if(!wxStrcmp(cmd, wxPorting.T("options"))) {
 //     options_dialog();
 //     if(hard_counters)
 //   perf_vals = perf_hard;
 //     else
 //   perf_vals = perf_easy;
 //     invalidate_field();
 //     repaint_all();
 //     update_labels();
 //     new_status_position();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("assign"), 6)) {
 //     Train   *t1;
 
 //     for(cmd += 6; *cmd == ' ' || *cmd == 't'; ++cmd);
 //     x = 0;
 //     while(*cmd && *cmd != ',') {
 //   buff[x++] = *cmd++;
 //     }
 //     buff[x] = 0;
 //     if(!(t = findTrainNamed(buff))) {
 //   // trace(wxPorting.L("Cannot assign %s: train not found."));
 //   return;
 //     }
 //     if(*cmd == ',') {
 //   while(*++cmd == ' ' || *cmd == 't');
 //     } else {
 //   if(!t.stock) {
 //       // trace(wxPorting.L("Train %s has no default stock assignment."));
 //       return;
 //   }
 //   cmd = t.stock;
 //     }
 //     if(!(t1 = findTrainNamed(cmd))) {
 //   // trace(wxPorting.L("Cannot assign %s: train not found."));
 //   return;
 //     }
 //     save_assign_train(t1, t);
 ////	    invalidate_field();
 ////	    repaint_all();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("play"), 4)) {
 //     cmd += 4;
 //     while(*cmd == ' ') ++cmd;
 //     Globals.traindir.PlaySound(cmd);
 // } else if(!wxStrcmp(cmd, wxPorting.T("skip"))) {
 //     skip_to_next_event();
 // } else if(!wxStrcmp(cmd, wxPorting.T("save_perf_text"))) {
 //     Globals.traindir.SavePerfText();
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("split"), 5)) {
 //     int length;
 
 //     for(cmd += 5; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
 //     x = 0;
 //     while(*cmd && *cmd != ',') {
 //   buff[x++] = *cmd++;
 //     }
 //     buff[x] = 0;
 //     if(!(t = findTrainNamed(buff))) {
 //   // trace(wxPorting.L("Cannot split %s: train not found."));
 //   return;
 //     }
 //     if(*cmd == ',') {
 //   while(*++cmd == ' ' || *cmd == 't');
 //   length = wxAtoi(cmd);
 //     } else {
 //   length = 0;
 //     }
 //     split_train(t, length);
 // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("script"), 6)) {
 //     String end;
 //     for(cmd += 6; *cmd == ' ' || *cmd == 't'; ++cmd);
 //     x = wxStrtol(cmd, &end, 10);
 //     if(*end == ',') ++end;
 //     y = wxStrtol(end, &end, 10);
 //     while(*end == ' ' || *end == 't') ++end;
 //     if(!*end)
 //   return;
 //     trk = find_track(layout, x, y);
 //            if (!trk)
 //                return;
 //     switch(trk.type) {
 //     case TRACK:
 //     case TRIGGER:
 //     case SWITCH:
 //            case TSIGNAL:
 //   trk.RunScript(end);
 //     }
 
 // } else if(match(&cmd, wxPorting.T("showinfo"))) {
 //     TDFile	infoFile = new TDFile(cmd);
 
 //     infoFile.SetExt(wxPorting.T(".htm"));
 //     if(infoFile.Load()) {
 //   Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
 //   info_page = infoFile.name.GetName();
 //     }
 // } else if(match(&cmd, wxPorting.T("showalert"))) {
 //     Globals.traindir.AddAlert(cmd);
 // } else if(match(&cmd, wxPorting.T("clearalert"))) {
 //     Globals.traindir.ClearAlert();
 //        } else if(match(&cmd, wxPorting.T("switch"))) {
 //     String end;
 //     cmd = skip_blanks(cmd);
 //            if(*cmd != '\'') {
 //         x = wxStrtol(cmd, &end, 10);
 //         if(*end == ',') ++end;
 //         y = wxStrtol(end, &end, 10);
 //                end = (String )skip_blanks(end);
 //                if(*end) {
 //             SwitchBoard *sw = FindSwitchBoard(end);
 //             if(sw)
 //                 sw.Select(x, y);
 //                }
 //            } else {
 //                end = (string )++cmd;
 //                while(*end && *end != '\'')
 //                    ++end;
 //                *end++ = 0;
 //                end = (String )skip_blanks(end);
 //                if(*end) {
 //             SwitchBoard *sw = FindSwitchBoard(end);
 //             if(sw)
 //                 sw.Select(cmd);
 //                }
 //            }
 //            server_command_done = true;
 // } else {
 //     status_line = String.Format(wxPorting.T("Command: %s"), cmd);
 //     repaint_labels();
 // }
 }

    public static void trainsim_cmd(String cmd) {
      do_command(cmd, true);
    }
  }
}
 
