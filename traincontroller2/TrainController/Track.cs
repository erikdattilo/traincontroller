using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class ExprValue { }

  public class Track : TrackBase {
    public override trktype TrackType { get { return trktype.TRACK; } }

    //
    //	Scripting support
    //


    bool GetPropertyValue(String prop, ExprValue result) {
      throw new NotImplementedException();
      //Track* t = this;

      //// move to Track::GetPropertyValue()
      //if(!wxStrcmp(prop, wxPorting.T("length"))) {
      //  result._op = Number;
      //  result._val = t.length;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("station"))) {
      //  result._op = String;
      //  result._txt = t.station ? wxPorting.T("") : t.station;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%s}"), result._txt);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("busy"))) {
      //  result._op = Number;
      //  result._val = (t.fgcolor != conf.fgcolor) || findTrain(t.x, t.y);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("free"))) {
      //  result._op = Number;
      //  result._val = t.fgcolor == conf.fgcolor && !findTrain(t.x, t.y);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //  result._op = Number;
      //  if(t.type == SWITCH) {
      //    /*		switch(t.direction) {
      //        case 10:	// Y switches could be considered always set to a siding
      //        case 11:	// but it conflicts with the option of reading the status
      //        case 22:	// then throwing the switch, so this is not enabled.
      //        case 23:
      //            result._val = 1;
      //            break;

      //        default: */
      //    result._val = t.switched;
      //    //}
      //  } else
      //    result._val = 0;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("color"))) {
      //  result._op = String;
      //  result._txt = GetColorName(t.fgcolor);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("linked"))) {
      //  int x, y;
      //  if(!(x = t.wlinkx) || !(y = t.wlinky)) {
      //    x = t.elinkx;
      //    y = t.elinky;
      //  }
      //  Track* lnk = findTrack(x, y);
      //  if(!lnk) {
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d,%d} - not found"), x, y);
      //    result._op = Number;
      //    result._val = 0;
      //    return false;
      //  }
      //  if(lnk.type == TSIGNAL) {
      //    result._signal = (Signal*)lnk;
      //    result._op = SignalRef;
      //  } else {
      //    result._track = lnk;
      //    result._op = TrackRef;
      //  }
      //  return true;
      //}

      //result._op = Number;
      //result._val = 0;
      //return false;
    }

    bool SetPropertyValue(String prop, ExprValue val) {
      throw new NotImplementedException();
      //if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  if(type != SWITCH)
      //    return false;
      //  switched = val._val != 0;
      //  change_coord(this.x, this.y);
      //  repaint_all();
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("click"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  track_selected(this.x, this.y);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("color"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  grcolor col = conf.fgcolor;
      //  if(wxStrcmp(val._txt, wxPorting.T("blue")) == 0)
      //    col = color_blue;
      //  else if(wxStrcmp(val._txt, wxPorting.T("white")) == 0)
      //    col = color_white;
      //  else if(wxStrcmp(val._txt, wxPorting.T("red")) == 0)
      //    col = color_red;
      //  else if(wxStrcmp(val._txt, wxPorting.T("green")) == 0)
      //    col = color_green;
      //  else if(wxStrcmp(val._txt, wxPorting.T("orange")) == 0)
      //    col = color_orange;
      //  else if(wxStrcmp(val._txt, wxPorting.T("black")) == 0)
      //    col = color_black;
      //  else if(wxStrcmp(val._txt, wxPorting.T("cyan")) == 0)
      //    col = color_cyan;
      //  SetColor(col);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("icon"))) {
      //  if(this.type == IMAGE) {
      //    if(this.station)
      //      Globals.free(this.station);
      //    this.station = wxStrdup(val._txt);
      //    change_coord(this.x, this.y);
      //    repaint_all();
      //  }
      //}

      //return false;
    }


    void OnInit() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onInit)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnInit"));
      //Trace(expr_buff);
      //interp.Execute(interp._onInit);
      //return;
    }

    void OnSetBusy() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onSetBusy)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnSetBusy"));
      //Trace(expr_buff);
      //interp.Execute(interp._onSetBusy);
      //return;
    }

    void OnSetFree() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onSetFree)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnSetFree"));
      //Trace(expr_buff);
      //interp.Execute(interp._onSetFree);
      //return;
    }

    public void OnEnter(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onEnter)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._stackPtr = 0;
      //interp._signal = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnEnter"));
      //Trace(expr_buff);
      //interp.Execute(interp._onEnter);
      //return;
    }

    public void OnExit(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onExit)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._stackPtr = 0;
      //interp._signal = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnExit"));
      //Trace(expr_buff);
      //interp.Execute(interp._onExit);
      //return;
    }

    public void OnClicked() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onClicked)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnClicked"));
      //Trace(expr_buff);
      //interp.Execute(interp._onClicked);
      //return;
    }

    void OnCanceled() {
      //if(this.type != ITIN)
      //  return;
      //if(_interpreterData) {
      //  TrackInterpreterData interp = *(TrackInterpreterData*)_interpreterData;
      //  if(interp._onCanceled) {
      //    interp._track = this;
      //    Itinerary* it;
      //    for(it = itineraries; it; it = it.next)
      //      if(!wxStrcmp(it.name, this.station)) {
      //        interp._itinerary = it;
      //        break;
      //      }
      //    expr_buff = String.Format( wxPorting.T("Track::OnCanceled(%s)"), this.station);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onCanceled);
      //    return;
      //  }
      //}
    }

    public void OnCrossed(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onCrossed)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnCrossed"));
      //Trace(expr_buff);
      //interp.Execute(interp._onCrossed);
      //return;
    }

    public void OnArrived(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onArrived)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnArrived"));
      //Trace(expr_buff);
      //interp.Execute(interp._onArrived);
      //return;
    }

    public void OnStopped(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onStopped)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnStopped"));
      //Trace(expr_buff);
      //interp.Execute(interp._onStopped);
      //return;
    }

    public void OnIconUpdate() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onIconUpdate)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnIconUpdate"));
      //Trace(expr_buff);
      //interp.Execute(interp._onIconUpdate);
      //return;
    }

    public void ParseProgram() {
      //String p;

      //if(!this.stateProgram || !*this.stateProgram)
      //  return;
      //if(_interpreterData)	    // previous script
      //  Globals.delete(_interpreterData);
      //_interpreterData = new TrackInterpreterData();

      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //p = this.stateProgram;
      //while(*p) {
      //  String p1 = p;
      //  while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
      //    ++p1;
      //  p = p1;
      //  if(match(&p, wxPorting.T("OnInit:"))) {
      //    p1 = p;
      //    interp._onInit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnSetBusy:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onSetBusy = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnSetFree:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onSetFree = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnEnter:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onEnter = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCrossed:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCrossed = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnArrived:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onArrived = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnStopped:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onStopped = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnExit:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onExit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnClicked:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onClicked = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnIconUpdate:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onIconUpdate = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCanceled:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCanceled = ParseStatements(&p);
      //  }
      //  if(p1 == p)	    // error! couldn't parse token
      //    break;
      //}
    }

    public void RunScript(string script, Train trn) {
      //Script* s = find_script(script);
      //if(!s) {
      //  s = new_script(script);
      //  // return;
      //}
      //if(!s.ReadFile())
      //  return;

      //// is it different from current one?
      //if(!this.stateProgram || wxStrcmp(s._text, this.stateProgram)) {
      //  if(this.stateProgram)
      //    Globals.free(this.stateProgram);
      //  this.stateProgram = wxStrdup(s._text);
      //  ParseProgram();
      //}
      //OnEnter(trn);
    }


    public void SetColor(grcolor color) {
      //if(this.fgcolor == color)
      //  return;
      //this.fgcolor = color;
      //change_coord(this.x, this.y);
      //if(color == conf.fgcolor)
      //  OnSetFree();
      //else
      //  OnSetBusy();
    }

    public bool IsBusy() {
      throw new NotImplementedException();
      //if(this.fgcolor != conf.fgcolor)
      //  return true;
      //return false;
    }

  }


  public abstract class TrackBase {
    public abstract trktype TrackType { get; }

    public Track next = null;
    public Track next1 = null;		/* list of same type tracks */
    public int x, y;
    public int xsize, ysize;
    // public trktype type = trktype.NOTRACK;
    public trkdir direction = trkdir.W_E;
    public trkstat status = trkstat.ST_FREE;
    public int wlinkx, wlinky;
    public int elinkx, elinky;
    public bool isstation = false;
    public bool switched = false;
    public bool busy = false;
    public bool fleeted = false;
    public bool nowfleeted = false;
    public bool norect = false; /* switches have a rectangle around em*/
    public bool fixedred = false;		/* signal is always red */
    public bool nopenalty = false;		/* no penalty for train stopping at signal */
    public bool noClickPenalty = false;	/* no penalty for un-necessary clicks */
    public bool invisible = false;		/* object is not shown on layout */
    public char wtrigger = (char)0x00;		/* westbound trigger linked */
    public char etrigger = (char)0x00;		/* eastbound trigger linked */
    public bool signalx = false;		/* use 'x' version when drawing signal */
    public bool aspect_changed = false;	/* ignore script execution - TODO: remove */
    public TFLG flags = 0;			/* performance flags (TFLG_*) */
    public Station station = new Station();
    public object lock_;
    public int[] speed = new int[Config.NTTYPES];
    public int icon = 0;
    public int length = 0;
    public Signal wsignal = null;		/* signal controlling this track */
    public Signal esignal = null;		/* signal controlling this track */
    public Track controls = null;		/* track controlled by this signal */
    public grcolor fgcolor = null;
    public object pixels;		/* for IMAGE pixmap */
    public int km = 0;			/* station distance (in meters) */
    public string stateProgram = null;		/* 3.5: name of function describing state changes */
    public string _currentState = null;	/* 3.5: name of current state in state program */
    public string _prevState = null;  /* 3.8q: signal state before update loop */
    public InterpreterData _interpreterData;	/* 3.5: intermediate data for program interpreter */
    public bool _isFlashing = false;		/* 3.5: flashing signal */
    public bool _isShuntingSignal = false;	/* 3.5: only affects shunting trains */
    public int _nextFlashingIcon = 0;	/* 3.5: index in list of icons when flashing */
    public string[] _flashingIcons = new string[Config.MAX_FLASHING_ICONS];	// 3.8: array of flashing icon names
    public int _fontIndex = 0;		// 3.6: font selection for TEXT tracks 

    public string _lockedBy = "";  // 3.7q: signal is locked by other signal(s)
    public bool _intermediate = false;   // 3.8h: signal is intermediate
    public int _nReservations = 0;  // 3.8h: number of trains still expected to pass this signal
    public string power = null;   // 3.9: motive power allowed (diesel, electric)
    public double gauge = 0;       // 3.9: track gauge

    bool GetPropertyValue(string prop, out ExprValue result) {
      result = null; return false;
    }
    bool SetPropertyValue(string prop, out ExprValue val) {
      val = null; return false;
    }

    public TrackBase() {
      //next = null;
      //next1 = null;
      //x = y = 0;
      //xsize = ysize = 0;
      //type = trktype.NOTRACK;
      //direction = trkdir.W_E;
      //status = trkstat.ST_FREE;
      //wlinkx = wlinky = 0;
      //elinkx = elinky = 0;
      //isstation = null;
      //switched = null;
      //busy = null;
      //fleeted = null;
      //nowfleeted = null;
      //norect = null;
      //fixedred = null;
      //nopenalty = null;
      //noClickPenalty = null;
      //invisible = null;
      //wtrigger = null;
      //etrigger = null;
      //signalx = null;
      //aspect_changed = null;
      //flags = null;		/* performance flags (TFLG_*) */
      //station = null;
      //lock_ = 0;
      //_lockedBy = null;
      //memset(speed, 0, sizeof(speed));
      //icon = 0;
      //length = 0;
      //wsignal = null;		/* signal controlling this track */
      //esignal = null;		/* signal controlling this track */
      //controls = null;		/* track controlled by this signal */
      //fgcolor = 0;
      //pixels = 0;		/* for IMAGE pixmap */
      //km = 0;			/* station distance (in meters) */
      //stateProgram = null;	/* 4.0: name of function describing state changes */
      //_currentState = null;	/* 4.0: name of current state in state program */
      //_interpreterData = null;	/* 4.0: intermediate data for program interpreter */
      //_isFlashing = null;	/* 4.0: flashing signal */
      //_isShuntingSignal = null;	/* 4.0: only affects shunting trains */
      //_nextFlashingIcon = 0;	/* 4.0: index in list of icons when flashing */
      //for(int i = 0; i < MAX_FLASHING_ICONS; ++i)
      //  _flashingIcons[i] = 0;
      //_fontIndex = 0;
      //_intermediate = false;
      //_nReservations = 0;
      //power = 0;              // 3.9: motive power allowed (diesel, electric)
      //gauge = 0;              // 3.9: track gauge
    }
  }
}
