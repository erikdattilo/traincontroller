/*	trsim.h - Created by Giampiero Caprino

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
namespace Traincontroller2 {
  public partial class Config {
    public const int NTTYPES = 10;

    public static int MAXNOTES = 5;

    public static int MAX_FLASHING_ICONS = 4;

    public static int MAX_DELAY = 10;
    public static char DELAY_CHAR = '!';

  }
  public partial class Globals {
    public static char PLATFORM_SEP = wxPorting.T('@');

  }

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

  public enum trkdir {
    NODIR = 0,
    W_E = 1,
    NW_SE = 2,
    SW_NE = 3,
    W_NE = 4,
    W_SE = 5,
    NW_E = 6,
    SW_E = 7,
    TRK_N_S = 8,
    E_W = NODIR,

    signal_WEST_FLEETED = 9,
    signal_EAST_FLEETED = 10,
    N_S_W = signal_WEST_FLEETED,
    N_S_E = signal_EAST_FLEETED,
    SW_N = 11,
    NW_S = 12,
    SE_N = 13,
    NE_S = 14,
    N_S = 16,		/* must be 16 because of signals */
    S_N = 17,
    signal_SOUTH_FLEETED = 18,
    signal_NORTH_FLEETED = 19,
    XH_NW_SE = 20,
    XH_SW_NE = 21,
    X_X = 22,		/* X (no switch) */
    X_PLUS = 23,		/* + (no switch) */
    N_NE_S_SW = 24,		// no switch / |
    N_NW_S_SE = 25		// no switch \ |
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



  public enum trainstat {
    train_READY,
    train_RUNNING,
    train_STOPPED,
    train_DELAY,
    train_WAITING,
    train_DERAILED,			/* couldn't place on territory! */
    train_ARRIVED,			/* reached some destination */
    train_STARTING,                 // starting after a stop at signal
    /*train_SHUNTING*/
    /* going to next station at 30Km/h */
  }



  [Flags]
  public enum TFLG {
    TFLG_TURNED = 1,			/* train changed direction */
    TFLG_THROWN = 2,			/* switch was thrown */
    TFLG_WAITED = 4,			/* train waited at signal */
    TFLG_MERGING = 8,			/* train is shunting to merge with another train */
    TFLG_STRANDED = 16,		/* material left on track without engine */
    TFLG_WAITINGMERGE = 32,		/* another train is approaching us to be merged */
    TFLG_ENTEREDLATE = 64,		/* don't penalize for late arrivals */
    TFLG_GOTDELAYATSTOP = 128,		/* only select delay (or none) once */
    TFLG_SETLATEARRIVAL = 256,		/* only compute late arrival once */
    TFLG_SWAPHEADTAIL = 512,		/* swap loco and caboose icons */
    TFLG_DONTSTOPSHUNTERS = 1024,      // don't stop here if train is shunting
  }

  public class TrainInfo {
    public string entering_time;
    public string leaving_time;
    public string current_speed;
    public string current_delay;
    public string current_late;
    public string current_status;
  }

  public class TDDelay {
    public short nDelays;	/* how many entries are in prob[] and seconds[] */
    public short nSeconds;	/* # of seconds selected for this delay (from seconds[] */
    public short[] prob = new short[Config.MAX_DELAY];/* probability[i] from 0=never to 100=always */
    public short[] seconds = new short[Config.MAX_DELAY];/* nseconds per each probability */
    /* TODO: add a script to evaluate the probability and/or nseconds */
  }

  public class TrainStop {
    public TrainStop next;
    public string station;	/* stop at this station */
    public int arrival;	/* scheduled arrival time */
    public int departure;	/* scheduled departure time */
    public int minstop;	/* minimum number of sec. stopping at station */
    public int stopped;	/* we did indeed stop here */
    public int late;		/* we were late arriving here */
    public int delay;		/* delay arriving at this station */
    public TDDelay depDelay;	/* random departure delay, if any */
  }

  public class TextList {
    public TextList next; // struct _textlist *next;
    public string txt;
  }

  public class Trigger {
    public Trigger next;
    public int type;
    public string action;
    public Pos wlinkx, wlinky;
    public Pos elinkx, elinky;
  };

  public class station_sched {
    public station_sched next;
    public Train tr;
    public string stopname;	    /* in case different platform */
    public long arrival, departure;
    public char transit;
  }


  public class Path {
    public Path next;
    public string from;
    public string to;
    public string enter;
    public long[] times = new long[Config.NTTYPES];
  }







  /*	Performance data	*/
  public class perf {
    public int wrong_dest;
    public int late_trains;
    public int thrown_switch;		/* incorrectly thrown switches */
    public int cleared_signal;		/* incorrectly cleared signals */
    public int denied;			/* command denied */
    public int turned_train;
    public int waiting_train;
    public int wrong_platform;
    public int ntrains_late;
    public int ntrains_wrong;
    public int nmissed_stops;
    public int wrong_assign;

    public perf() {
    }

    public perf(int wrong_dest_, int late_trains_, int thrown_switch_, int cleared_signal_, int denied_, int turned_train_, int waiting_train_, int wrong_platform_, int ntrains_late_, int ntrains_wrong_, int nmissed_stops_, int wrong_assign_) {
      wrong_dest = wrong_dest_;
      late_trains = late_trains_;
      thrown_switch = thrown_switch_;
      cleared_signal = cleared_signal_;
      denied = denied_;
      turned_train = turned_train_;
      waiting_train = waiting_train_;
      wrong_platform = wrong_platform_;
      ntrains_late = ntrains_late_;
      ntrains_wrong = ntrains_wrong_;
      nmissed_stops = nmissed_stops_;
      wrong_assign = wrong_assign_;
    }
  }


  public class _conf {
    public int gridxbase, gridybase;
    public int gridxsize, gridysize;

    public grcolor gridcolor;
    public grcolor txtbgcolor;	/* for dialogues */
    public grcolor fgcolor;
    public grcolor linkcolor;	/* links signals and entry/exit */
    public grcolor linkcolor2;	/* links tracks */
  }

  public class pxmap {
    public string name;
    public object pixels;
  }
}
