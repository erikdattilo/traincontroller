/*	Train.cpp - Created by Giampiero Caprino

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





  public class TrainInterpreterData : InterpreterData {
    public Statement _onInit;	// list of actions (statements)
    public Statement _onEntry;
    public Statement _onExit;
    public Statement _onStop;
    public Statement _onWaiting;
    public Statement _onStart;
    public Statement _onReverse;
    public Statement _onAssign;
    public Statement _onShunt;
    public Statement _onArrived;

    TrainInterpreterData() {
      //_onInit = 0;
      //_onEntry = 0;
      //_onExit = 0;
      //_onStop = 0;
      //_onWaiting = 0;
      //_onStart = 0;
      //_onReverse = 0;
      //_onAssign = 0;
      //_onShunt = 0;
      //_onArrived = 0;
    }

    ~TrainInterpreterData() {
      //if(_onInit)
      //  Globals.delete(_onInit);
      //if(_onEntry)
      //  Globals.delete(_onEntry);
      //if(_onExit)
      //  Globals.delete(_onExit);
      //if(_onWaiting)
      //  Globals.delete(_onWaiting);
      //if(_onStop)
      //  Globals.delete(_onStop);
      //if(_onStart)
      //  Globals.delete(_onStart);
      //if(_onReverse)
      //  Globals.delete(_onReverse);
      //if(_onShunt)
      //  Globals.delete(_onShunt);
      //if(_onAssign)
      //  Globals.delete(_onAssign);
      //if(_onArrived)
      //  Globals.delete(_onArrived);
    }


    bool Evaluate(ExprNode n, ExprValue result) {
      throw new NotImplementedException();

      //ExprValue left = new ExprValue(NodeOp.None);
      //ExprValue right = new ExprValue(NodeOp.None);
      //String prop;

      //if(!n)
      //  return false;
      //switch(n._op) {

      //  case Dot:

      //    result._op = Addr;
      //    if(!(n._left)) {
      //      result._train = this._train;		// .<property> .   this.train
      //      result._op = TrainRef;
      //      if(!result._train) {
      //        wxStrcat(expr_buff, wxPorting.T("no current train for '.'"));
      //        return false;
      //      }
      //      if(result._train.position)
      //        TraceCoord(result._train.position.x, result._train.position.y);
      //    } else {
      //      if(!Evaluate(n._left, result))
      //        return false;
      //    }
      //    result._txt = (n._right && n._right._op == String) ? n._right._txt : n._txt;
      //    if(_forAddr)
      //      return true;

      //    prop = result._txt;
      //    if(!prop)
      //      return false;

      //    switch(result._op) {

      //      case TrainRef:

      //        if(!result._train)
      //          return false;
      //        return result._train.GetPropertyValue(prop, result);

      //      case SwitchRef:

      //        if(!wxStrcmp(prop, wxPorting.T("thrown")) && result._track) {
      //          result._op = Number;
      //          result._val = result._track.switched;
      //          return true;
      //        }

      //      case Addr:
      //      case TrackRef:
      //      default:

      //        if(!result._track)
      //          return false;
      //        return result._track.GetPropertyValue(prop, result);

      //      case SignalRef:

      //        if(!result._signal)
      //          return false;
      //        return result._signal.GetPropertyValue(prop, result);

      //    }

      //  default:

      //    return InterpreterData.Evaluate(n, result);
      //}
      //return false;
    }

  }


  public class Train {
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
    public string[] notes = new string[Config.MAXNOTES];
    /// TODO 	memset(notes, 0, sizeof(notes));
    public char nnotes = (char)0x00;
    public bool wrongdest = false;		/* train arrived at wrong destination */
    public int type = 0;		/* train type */
    public int _gotDelay = 0;		/* we computed a delay upon entry in the territory */
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
    public bool needfindstop = false;	/* terrible hack! */
    public bool isExternal = false; /* train does not run in this scenario */
    public Train merging = null;		/* will merge with this train */
    public TDDelay entryDelay = null;
    public char power = (char)0x00;  // 3.9
    public double gauge;    // 3.9: track gauge

    // start to use C++ methods to make the code cleaner

    Char stateProgram;
    object _interpreterData;


    public Train() {
      //next = 0;
      //name = 0;		/* train name or number */
      //status = train_READY;	/* status: running, waiting etc. */
      //sdirection = W_E;	/* starting direction: W_E or E_W */
      //direction = W_E;	/* current direction: W_E or E_W */
      //timein = 0;		/* time it shows up on territory */
      //timeout = 0;		/* time it should be out of territory */
      //entrance = 0;
      //exit = 0;
      //exited = 0;		/* if wrongdest, where we exited */
      //timeexited = 0;		/* when we exited */
      //memset(notes, 0, sizeof(notes));
      //nnotes = 0;
      //wrongdest = 0;		/* train arrived at wrong destination */
      //type = 0;		/* train type */
      //_gotDelay = 0;		/* we computed a delay upon entry in the territory */
      //_inDelay = 0;		/* the computed delay, in minutes */
      //newsched = 0;		/* must update schedule window for this train */
      //curspeed = 0;		/* current speed */
      //maxspeed = 0;		/* absolute maximum speed */
      //curmaxspeed = 0;	/* current (absolute or track) maximum speed */
      //speedlimit = 0;		/* last speed limit seen */
      //timelate = 0;		/* minutes late arriving at all stations */
      //timedelay = 0;		/* minutes late entering territory */
      //timered = 0;		/* minutes stopped at red signal */
      //trackpos = 0;		/* how much of lengthy tracks we travelled */
      //stops = 0;		/* list of scheduled stops */
      //laststop = 0;		/* last in list of scheduled stops */
      //length = 0;		/* current train length in meters */
      //entryLength = 0;	/* train length at entry into territory */
      ////	pathpos = 0;		/* index into path[] of train head */
      //path = 0;		/* track elements to be travelled by train head */
      //tail = 0;		/* descriptor of train's end (if length != 0) */
      //pathtravelled = 0;	/* meters travelled in current path */
      //disttostop = 0;		/* distance until next stop */
      //stoppoint = 0;
      //disttoslow = 0;	    	/* distance until next speed limit signal */
      //slowpoint = 0;
      //position = 0;		/* where the train is in the territory */
      //timedep = 0;		/* expected time of departure from station */
      //fleet = 0;		/* list of signals waiting for tail to pass */
      //waitfor = 0;		/* must wait for this train to exit territory*/
      //waittime = 0;	    	/* how many minutes after waitee has arrived we depart */
      //stock = 0;		/* next train which uses this train's stock */
      //epix = 0; wpix = 0;	/* indexes to east and west pixmaps */
      //ecarpix = 0; wcarpix = 0;/* indexes of east abd west car pixmaps (if length != 0) */
      //outof = 0;		/* ignore this station when checking shunting */
      //stopping = 0;		/* we are stopping/stopped at this station */
      //oldstatus = train_READY;
      //arrived = 0;		/* if true we are just shunting */
      //shunting = 0;
      //days = 0;		/* which day this train is running */
      //flags = 0;		/* performance flags (TFLG_*) */
      //needfindstop = 0;	/* terrible hack! */
      //merging = 0;		/* will merge with this train */
      //entryDelay = 0;
      //isExternal = 0;         /* train does not run in this scenario */
      //startDelay = 0;
      //myStartDelay = 0;
      //accelRate = 0;          // 3.8r
      //power = 0;              // 3.9

      //// start to use C++ methods to make the code cleaner

      //stateProgram = 0;
      //_interpreterData = 0;
      //_lastUpdate = 0;
    }

    ~Train()	    // recursive for tails!
    {
      //TrainStop ts, ts1;

      //if(this.tail) {
      //  Globals.delete(this.tail);
      //  this.tail = 0;
      //}
      //if(this.path)
      //  Vector_delete(this.path);
      //if(this.name)
      //  Globals.free(this.name);
      //if(this.entrance)
      //  Globals.free(this.entrance);
      //if(this.exit)
      //  Globals.free(this.exit);
      //for(ts = this.stops; ts; ts = ts1) {
      //  ts1 = ts.next;
      //  if(ts.station)
      //    Globals.free(ts.station);
      //  Globals.free(ts);
      //}
    }


    public void Get(TrainInfo info) {
      //string buff;

      //if(_gotDelay && _inDelay) {
      //  buff = String.Format( wxPorting.T("%s"), format_time(this.timein));
      //  buff + Globals.wxStrlen(buff) = String.Format( wxPorting.T(" (%s)"), format_time(this.timein + this._inDelay));
      //  info.entering_time = String.Copy( buff);;
      //} else
      //  info.entering_time = String.Copy( format_time(this.timein));
      //info.leaving_time = String.Copy( format_time(this.timeout));
      //info.current_speed = String.Format( wxPorting.T("%d"), (int)this.curspeed);
      //info.current_delay = String.Format( wxPorting.T("%d"), this.timedelay / 60);
      //info.current_late = String.Format( wxPorting.T("%d"), this.timelate);
      ////disp_columns[4] = this.name;
      ////disp_columns[1] = this.entrance;
      ////disp_columns[2] = this.exit;
      //info.current_status = String.Copy( train_status(this));
      ///*	current_status + Globals.wxStrlen(current_status) = String.Format(
      //      wxPorting.T("  pos: %ld - %ld"), t.pathtravelled, t.trackpos);*/
    }


    public bool CanTravelOn(Vector path) {
      throw new NotImplementedException();

      //int i;

      //if(!this.power)    // no power specified, means can travel anywhere
      //  return true;
      //for(i = 0; i < path._size; ++i) {
      //  Track* trk = path.TrackAt(i);
      //  if(trk.type == TEXT) // we reached an exit
      //    return true;
      //  if(!trk.power)
      //    return false;
      //  if(wxStrcmp(trk.power, this.power)) {
      //    return false; // different power specified (e.g. 3000V vs. 10000V)
      //  }
      //}
      //return true;
    }


    public void ParseProgram() {
      //String p;

      //if(!this.stateProgram || !*this.stateProgram)
      //  return;
      //if(_interpreterData)	    // previous script
      //  Globals.delete((TrainInterpreterData)_interpreterData);
      //_interpreterData = new TrainInterpreterData();

      //TrainInterpreterData interp = (TrainInterpreterData)_interpreterData;
      //p = this.stateProgram;
      //while(*p) {
      //  String p1 = p;
      //  while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
      //    ++p1;
      //  p = p1;
      //  if(match(&p, wxPorting.T("OnInit:"))) {
      //    p1 = p;
      //    interp._onInit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnEntry:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onEntry = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnExit:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onExit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnStop:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onStop = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnWaiting:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onWaiting = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnStart:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onStart = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnAssign:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onAssign = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnArrived:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onArrived = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnReverse:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onReverse = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnShunt:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onShunt = ParseStatements(&p);
      //  }
      //  if(p1 == p)	    // error! couldn't parse token
      //    break;
      //}
    }

    ///
    ///	TRAIN  STATE
    ///


    public bool GetPropertyValue(String prop, ExprValue result) {
      throw new NotImplementedException();
      //if(!wxStrcmp(prop, wxPorting.T("name"))) {
      //  result._op = String;
      //  result._txt = this.name;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("type"))) {
      //  result._op = Number;
      //  result._val = this.type;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("speed"))) {
      //  result._op = Number;
      //  result._val = this.curspeed;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("length"))) {
      //  result._op = Number;
      //  result._val = this.length;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("arrived"))) {
      //  result._op = Number;
      //  result._val = this.status == train_ARRIVED;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("stopped"))) {
      //  result._op = Number;
      //  result._val = this.status == train_STOPPED;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("direction"))) {
      //  result._op = Number;
      //  result._val = this.direction;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("days"))) {
      //  result._op = Number;
      //  result._val = this.days;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("entry"))) {
      //  result._op = String;
      //  result._txt = this.entrance;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("exit"))) {
      //  result._op = String;
      //  result._txt = this.exit;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextStation"))) {
      //  TrainStop* stop = this.stops;
      //  while(stop && stop.stopped)
      //    stop = stop.next;
      //  if(!stop)
      //    return false;
      //  result._op = String;
      //  result._txt = stop.station;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("stock"))) {
      //  result._op = String;
      //  result._txt = this.stock;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("waitfor"))) {
      //  result._op = String;
      //  result._txt = this.waitfor;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("status"))) {
      //  result._op = String;
      //  switch(this.status) {
      //    case train_READY:
      //      result._txt = wxPorting.T("ready");
      //      break;
      //    case train_RUNNING:
      //      if(this.shunting)
      //        result._txt = wxPorting.T("shunting");
      //      else
      //        result._txt = wxPorting.T("running");
      //      break;
      //    case train_STOPPED:
      //      result._txt = wxPorting.T("stopped");
      //      break;
      //    case train_DELAY:
      //      result._txt = wxPorting.T("delayed");
      //      break;
      //    case train_WAITING:
      //      result._txt = wxPorting.T("waiting");
      //      break;
      //    case train_DERAILED:
      //      result._txt = wxPorting.T("derailed");
      //      break;
      //    case train_ARRIVED:
      //      result._txt = wxPorting.T("arrived");
      //      break;
      //  }
      //  return true;
      //}
      //return false;
    }


    public bool SetPropertyValue(String prop, ExprValue value) {
      throw new NotImplementedException();
      //if(!wxStrcmp(prop, wxPorting.T("shunt"))) {
      //  if(status != train_STOPPED && status != train_WAITING && status != train_ARRIVED) {
      //    do_alert(wxPorting.L("Train is not stopped nor arrived."));
      //    return false;
      //  }
      //  shunt_train(this);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("wait"))) {
      //  if(status != train_RUNNING || curspeed != 0) {
      //    do_alert(wxPorting.L("Train is not stopped nor arrived."));
      //    return false;
      //  }
      //  timedep += value._val;
      //  return true;
      //}
      //return false;
    }


    ///
    ///	TRAIN  EVENTS
    ///


    public void OnEntry() {
      //if(_interpreterData) {
      //  TrainInterpreterData interp = *(TrainInterpreterData)_interpreterData;
      //  if(interp._onEntry) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnEntry(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onEntry);
      //    return;
      //  }
      //}
    }


    public void OnStart() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onStart) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnStart(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onStart);
      //    return;
      //  }
      //}
    }


    public void OnStopped() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onStop) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnStopped(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onStop);
      //    return;
      //  }
      //}
    }


    public void OnWaiting(Signal sig) {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onWaiting) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = sig;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnWaiting(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onWaiting);
      //    return;
      //  }
      //}
    }


    public void OnExit() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onExit) {
      //    interp._train = this;
      //    interp._track = 0;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnExit()"), this.name);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onExit);
      //    return;
      //  }
      //}
    }


    public void OnArrived() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onArrived) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnArrived(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onArrived);
      //    return;
      //  }
      //}
    }


    public void OnAssign() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onAssign) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnAssign(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onAssign);
      //    return;
      //  }
      //}
    }


    public void OnReverse() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onReverse) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnReverse(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onReverse);
      //    return;
      //  }
      //}
    }


    public void OnShunt() {
      //if(_interpreterData) {
      //  TrainInterpreterData & interp = *(TrainInterpreterData*)_interpreterData;
      //  if(interp._onShunt) {
      //    interp._train = this;
      //    interp._track = this.position;
      //    interp._signal = 0;
      //    interp._stackPtr = 0;
      //    expr_buff = String.Format( wxPorting.T("%s::OnShunt(%d,%d)"), this.name, this.position.x, this.position.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onShunt);
      //    return;
      //  }
      //}
    }
  }
}