using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
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
    public short[] prob = new short[Configuration.MAX_DELAY];/* probability[i] from 0=never to 100=always */
    public short[] seconds = new short[Configuration.MAX_DELAY];/* nseconds per each probability */
    /* TODO: add a script to evaluate the probability and/or nseconds */
  }

  public class TrainStop {
    public TrainStop next;
    public string station;	/* stop at this station */
    public long arrival;	/* scheduled arrival time */
    public long departure;	/* scheduled departure time */
    public long minstop;	/* minimum number of sec. stopping at station */
    public char stopped;	/* we did indeed stop here */
    public char late;		/* we were late arriving here */
    public int delay;		/* delay arriving at this station */
    public TDDelay depDelay;	/* random departure delay, if any */
  }

  [Flags]
  public enum RunDays {
    None = 0x0,
    Monday = 0x1,
    Tuesday = 0x2,
    Wednesday = 0x4,
    Thursday = 0x8,
    Friday = 0x10,
    Saturday = 0x20,
    Sunday = 0x40
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


  public enum trkdir {
    NODIR = 0,
    E_W = 0,

    W_E = 1,
    NW_SE = 2,
    SW_NE = 3,
    W_NE = 4,
    W_SE = 5,
    NW_E = 6,
    SW_E = 7,
    TRK_N_S = 8,

    signal_WEST_FLEETED = 9,
    N_S_W = 9,

    signal_EAST_FLEETED = 10,
    N_S_E = 10,

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

  public class Train : ClientData {
    public Train next = null;
    public string name = null;		/* train name or number */
    public trainstat status = trainstat.train_READY;	/* status: running, waiting etc. */
    public trkdir sdirection = trkdir.W_E;	/* starting direction: W_E or E_W */
    public trkdir direction = trkdir.W_E;	/* current direction: W_E or E_W */
    public int timein = 0;		/* time it shows up on territory */
    public int tailentry { get { return timein; } set { timein = value; } } /* overload timein/out in t.tail structure */
    public int tailexit { get { return timeout; } set { timeout = value; } }
    public int timeout = 0;		/* time it should be out of territory */
    public string entrance = null;
    public string exit = null;
    public string exited = null;		/* if wrongdest, where we exited */
    public int timeexited = 0;		/* when we exited */
    public string[] notes = new string[Configuration.MAXNOTES];
    /// TODO 	memset(notes, 0, sizeof(notes));
    public char nnotes = (char)0x00;
    public bool wrongdest = false;		/* train arrived at wrong destination */
    public char type = (char)0x00;		/* train type */
    public char _gotDelay = (char)0x00;		/* we computed a delay upon entry in the territory */
    public int _lastUpdate;    /* when we last updated this train's status */
    public int _inDelay = 0;		/* the computed delay, in minutes */
    public short newsched = 0;		/* must update schedule window for this train */
    public double curspeed = 0;		// 3.8r: support different acceleration rates /* current speed */
    public double accelRate = 0;    // 3.8r
    public short maxspeed = 0;		/* absolute maximum speed */
    public short curmaxspeed = 0;	/* current (absolute or track) maximum speed */

    public int speedlimit = 0;		/* last speed limit seen */
    public int timelate = 0;		/* minutes late arriving at all stations */
    public int timedelay = 0;		/* minutes late entering territory */
    public int timered = 0;		/* minutes stopped at red signal */
    public int startDelay = 0;    // seconds to wait until starting after stop (runtime - set from train schedule or train type)
    public int myStartDelay = 0;   // seconds this train should wait (from schedule file)

    public double trackpos = 0;		/* how much of lengthy tracks we travelled */
    public TrainStop stops = null;		/* list of scheduled stops */
    public TrainStop laststop = null;		/* last in list of scheduled stops */
    public short length = 0;		/* current train length in meters */
    public short entryLength = 0;	/* train length at entry into territory */
    public Vector path = new Vector();		/* track elements to be travelled by train head */
    public Train tail = null;		/* descriptor of train's end (if length != 0) */
    public double pathtravelled = 0;	/* meters travelled in current path */
    public double disttostop = 0;		/* distance until next stop */
    public double disttoslow = 0; /* distance until next speed limit signal */
    public Track stoppoint = null;
    public Track slowpoint = null;

    public Track position = null;		/* where the train is in the territory */
    public int timedep = 0;		/* expected time of departure from station */
    public Vector fleet = null;		/* list of signals waiting for tail to pass */
    public string waitfor = null;		/* must wait for this train to exit territory*/
    public int waittime = 0;	    /* how many minutes after waitee has arrived we depart */
    public string stock = null;		/* next train which uses this train's stock */
    public short epix = 0; public short wpix = 0;	/* indexes to east and west pixmaps */
    public short ecarpix = 0; public short wcarpix = 0;/* indexes of east abd west car pixmaps (if length != 0) */
    public Track outof = null;		/* ignore this station when checking shunting */
    public Track stopping = null;		/* we are stopping/stopped at this station */
    public trainstat oldstatus = trainstat.train_READY;
    public bool arrived = false;		/* if true we are just shunting */
    public bool shunting = false;
    public RunDays days = RunDays.None;		/* which day this train is running */
    public TFLG flags = 0;		/* performance flags (TFLG_*) */
    public char needfindstop = (char)0x00;	/* terrible hack! */
    public bool isExternal = false; /* train does not run in this scenario */
    public Train merging = null;		/* will merge with this train */
    public TDDelay entryDelay = null;
    public char power = (char)0x00;  // 3.9
    public double gauge;    // 3.9: track gauge

    // start to use C++ methods to make the code cleaner

    Char stateProgram;
    object _interpreterData;
#if false
    public Train() {


      // start to use C++ methods to make the code cleaner

      stateProgram = 0;
      _interpreterData = 0;
      _lastUpdate = 0;
    }

    ~Train()	    // recursive for tails!
    {
      TrainStop ts, ts1;

      if(this.tail) {
        // delete this.tail;
        this.tail = null;
      }
      if(this.path)
        Vector_delete(this.path);
      if(this.name)
        free(this.name);
      if(this.entrance)
        free(this.entrance);
      if(this.exit)
        free(this.exit);
      for(ts = this.stops; ts; ts = ts1) {
        ts1 = ts.next;
        if(ts.station)
          free(ts.station);
        free(ts);
      }
    }

#endif
    public void Get(TrainInfo info) {
      string buff = "";

      if(_gotDelay > 0 && _inDelay > 0) {
        info.entering_time = String.Format(
          wxPorting.T("{0} {1}"),
          GlobalFunctions.format_time(this.timein),
          GlobalFunctions.format_time(this.timein + this._inDelay)
        );
      } else
        info.entering_time = GlobalFunctions.format_time(this.timein);

      info.leaving_time = GlobalFunctions.format_time(this.timeout);
      info.current_speed = String.Format(wxPorting.T("{0}"), (int)this.curspeed);
      info.current_delay = String.Format(wxPorting.T("{0}"), this.timedelay / 60);
      info.current_late = String.Format(wxPorting.T("{0}"), this.timelate);
      info.current_status = GlobalFunctions.train_status(this);
    }
#if false

    bool CanTravelOn(Vector path) {
      int i;

      if(!this.power)    // no power specified, means can travel anywhere
        return true;
      for(i = 0; i < path._size; ++i) {
        Track* trk = path.TrackAt(i);
        if(trk.type == TEXT) // we reached an exit
          return true;
        if(!trk.power)
          return false;
        if(wxStrcmp(trk.power, this.power)) {
          return false; // different power specified (e.g. 3000V vs. 10000V)
        }
      }
      return true;
    }


    void ParseProgram()
{
	string p;

	if(!this.stateProgram || !*this.stateProgram)
	    return;
	if(_interpreterData)	    // previous script
	    delete (TrainInterpreterData)_interpreterData;
	_interpreterData = new TrainInterpreterData;

	TrainInterpreterData *interp = (TrainInterpreterData *)_interpreterData;
	p = this.stateProgram;
	while(*p) {
	    const string	*p1 = p;
	    while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
		++p1;
	    p = p1;
	    if(match(&p, wxPorting.T("OnInit:"))) {
		p1 = p;
		interp._onInit = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnEntry:"))) {
		p = next_token(p);
		p1 = p;
		interp._onEntry = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnExit:"))) {
		p = next_token(p);
		p1 = p;
		interp._onExit = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnStop:"))) {
		p = next_token(p);
		p1 = p;
		interp._onStop = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnWaiting:"))) {
		p = next_token(p);
		p1 = p;
		interp._onWaiting = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnStart:"))) {
		p = next_token(p);
		p1 = p;
		interp._onStart = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnAssign:"))) {
		p = next_token(p);
		p1 = p;
		interp._onAssign = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnArrived:"))) {
		p = next_token(p);
		p1 = p;
		interp._onArrived = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnReverse:"))) {
		p = next_token(p);
		p1 = p;
		interp._onReverse = ParseStatements(&p);
	    } else if(match(&p, wxPorting.T("OnShunt:"))) {
		p = next_token(p);
		p1 = p;
		interp._onShunt = ParseStatements(&p);
	    }
	    if(p1 == p)	    // error! couldn't parse token
		break;
	}
}

    ///
    ///	TRAIN  STATE
    ///


    bool GetPropertyValue(string prop, out ExprValue result) {
      if("name".equals(prop)) {
        result._op = String;
        result._txt = this.name;
        return true;
      }
      if("type".equals(prop)) {
        result._op = Number;
        result._val = this.type;
        return true;
      }
      if("speed".equals(prop)) {
        result._op = Number;
        result._val = this.curspeed;
        return true;
      }
      if("length".equals(prop)) {
        result._op = Number;
        result._val = this.length;
        return true;
      }
      if("arrived".equals(prop)) {
        result._op = Number;
        result._val = this.status == train_ARRIVED;
        return true;
      }
      if("stopped".equals(prop)) {
        result._op = Number;
        result._val = this.status == train_STOPPED;
        return true;
      }
      if("direction".equals(prop)) {
        result._op = Number;
        result._val = this.direction;
        return true;
      }
      if("days".equals(prop)) {
        result._op = Number;
        result._val = this.days;
        return true;
      }
      if("entry".equals(prop)) {
        result._op = String;
        result._txt = this.entrance;
        return true;
      }
      if("exit".equals(prop)) {
        result._op = String;
        result._txt = this.exit;
        return true;
      }
      if("nextStation".equals(prop)) {
        TrainStop* stop = this.stops;
        while(stop && stop.stopped)
          stop = stop.next;
        if(!stop)
          return false;
        result._op = String;
        result._txt = stop.station;
        return true;
      }
      if("stock".equals(prop)) {
        result._op = String;
        result._txt = this.stock;
        return true;
      }
      if("waitfor".equals(prop)) {
        result._op = String;
        result._txt = this.waitfor;
        return true;
      }
      if("status".equals(prop)) {
        result._op = String;
        switch(this.status) {
          case train_READY:
            result._txt = wxPorting.T("ready");
            break;
          case train_RUNNING:
            if(this.shunting)
              result._txt = wxPorting.T("shunting");
            else
              result._txt = wxPorting.T("running");
            break;
          case train_STOPPED:
            result._txt = wxPorting.T("stopped");
            break;
          case train_DELAY:
            result._txt = wxPorting.T("delayed");
            break;
          case train_WAITING:
            result._txt = wxPorting.T("waiting");
            break;
          case train_DERAILED:
            result._txt = wxPorting.T("derailed");
            break;
          case train_ARRIVED:
            result._txt = wxPorting.T("arrived");
            break;
        }
        return true;
      }
      return false;
    }


    bool SetPropertyValue(string prop, out ExprValue value) {
      if("shunt".equals(prop)) {
        if(status != train_STOPPED && status != train_WAITING && status != train_ARRIVED) {
          do_alert(L("Train is not stopped nor arrived."));
          return false;
        }
        shunt_train(this);
        return true;
      }
      if("wait".equals(prop)) {
        if(status != train_RUNNING || curspeed != 0) {
          do_alert(L("Train is not stopped nor arrived."));
          return false;
        }
        timedep += value._val;
        return true;
      }
      return false;
    }


    ///
    ///	TRAIN  EVENTS
    ///


#endif

    /// TODO Uncomment this function
    public void OnEntry() {
      if(_interpreterData != null) {
        // TrainInterpreterData & interp = *(TrainInterpreterData*)GlobalVariables._interpreterData;
        TrainInterpreterData interp = (TrainInterpreterData)_interpreterData;
        if(interp._onEntry != null) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = null;
          interp._stackPtr = 0;
          GlobalVariables.expr_buff = string.Format(wxPorting.T("%s::OnEntry(%d,%d)"), this.name, this.position.x, this.position.y);
          GlobalFunctions.Trace(GlobalVariables.expr_buff);
          interp.Execute(interp._onEntry);
          return;
        }
      }
    }

    /// TODO Uncomment this function
    public void OnStart() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onStart) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnStart(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onStart);
      //    return;
      //  }
      //}
    }

#if false


    void OnStopped() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onStop) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnStopped(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onStop);
          return;
        }
      }
    }


    void OnWaiting(Signal sig) {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onWaiting) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = sig;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnWaiting(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onWaiting);
          return;
        }
      }
    }


    void OnExit() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onExit) {
          interp._train = this;
          interp._track = 0;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnExit()"), this.name);
          Trace(expr_buff);
          interp.Execute(interp._onExit);
          return;
        }
      }
    }


    void OnArrived() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onArrived) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnArrived(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onArrived);
          return;
        }
      }
    }


    void OnAssign() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onAssign) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnAssign(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onAssign);
          return;
        }
      }
    }


    void OnReverse() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onReverse) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnReverse(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onReverse);
          return;
        }
      }
    }


    void OnShunt() {
      if(_interpreterData) {
        TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
        if(interp._onShunt) {
          interp._train = this;
          interp._track = this.position;
          interp._signal = 0;
          interp._stackPtr = 0;
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(string), wxPorting.T("%s::OnShunt(%d,%d)"), this.name, this.position.x, this.position.y);
          Trace(expr_buff);
          interp.Execute(interp._onShunt);
          return;
        }
      }
    }
#endif
  }
}