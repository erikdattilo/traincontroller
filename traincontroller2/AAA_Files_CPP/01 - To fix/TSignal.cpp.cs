/*	TSignal.cpp - Created by Giampiero Caprino

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



  public class SignalAction {
    public SignalAction _next;
    public String _name;
    public String _program;
  }





  public partial class Globals {
    public static int trace_script = 0;

    public static bool gMustBeClearPath;

    public static void stop_here() {
    }


    //
    //	Execution of the Abstract Syntax Tree
    //

    public static string expr_buff; // Erik: old code ==> char expr_buff[EXPR_BUFF_SIZE];

    public static void Trace(String msg) {
      //if(!trace_script)
      //  return;
      //Globals.traindir.AddAlert(msg);
    }


    public static object[] n_sig_pmap = new object[2];         /* R, G */
    public static object[] n_sigx_pmap = new object[2];
    public static String[] n_sig_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  ",
"   .   ",
"   .   ",
" ..... "};
    public static String[] n_sigx_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... ",
"   .   ",
"   .   ",
" ..... "};

    public static object[] s_sig_pmap = new object[2];         /* R, G */
    public static object[] s_sigx_pmap = new object[2];
    public static String[] s_sig_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
"   .   ",
"   .   ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  "};
    public static String[] s_sigx_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
"   .   ",
"   .   ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... "};

    public static object[] n_sig2_pmap = new object[4];         /* R, G */
    public static object[] n_sig2x_pmap = new object[4];
    public static String[] n_sig2_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  ",
"  ...  ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
"  ...  ",
"   .   ",
"   .   ",
" ..... "};
    public static String[] n_sig2x_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... ",
" ..... ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
" ..... ",
"   .   ",
"   .   ",
" ..... "};

    public static object[] s_sig2_pmap = new object[4];         /* R, G */
    public static object[] s_sig2x_pmap = new object[4];         /* R, G */
    public static String[] s_sig2_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
"   .   ",
"   .   ",
"  ...  ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
"  ...  ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  "};
    public static String[] s_sig2x_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
"   .   ",
"   .   ",
" ..... ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
" ..... ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... "};

    public static object[] e_sig_pmap = new object[2];		/* R, G */
    public static object[] e_sigx_pmap = new object[2];
    public static String[] e_sig_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".    ... ",
".   .GGG.",
".....GGG.",
".   .GGG.",
".    ... "};
    public static String[] e_sigx_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".   .....",
".   .GGG.",
".....GGG.",
".   .GGG.",
".   ....."};

    public static object[] w_sig_pmap = new object[2];		/* R, G */
    public static object[] w_sigx_pmap = new object[2];
    public static String[] w_sig_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
" ...    .",
".GGG.   .",
".GGG.....",
".GGG.   .",
" ...    ."
};
    public static String[] w_sigx_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".....   .",
".GGG.   .",
".GGG.....",
".GGG.   .",
".....   ."
};

    public static object[] e_sig2_pmap = new object[4];		/* RR, GR, GG, GO */
    public static object[] e_sig2x_pmap = new object[4];
    public static String[] e_sig2_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	".   ...  ... ",
	".  .XXX..GGG.",
	"....XXX..GGG.",
	".  .XXX..GGG.",
	".   ...  ... "};
    public static String[] e_sig2x_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	".  ..........",
	".  .XXX..GGG.",
	"....XXX..GGG.",
	".  .XXX..GGG.",
	".  .........."};

    public static object[] e_sigP_pmap = new object[4];		/* RR, GR, GG, GO */
    public static String[] e_sigP_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
        ". ...... ... ",
        ". XXXXX..GGG.",
        "....X.X..GGG.",
        ". ..XXX..GGG.",
        ". ...... ... "};


    public static object[] w_sig2_pmap = new object[4];		/* RR, GR, GG, GO */
    public static object[] w_sig2x_pmap = new object[4];
    public static String[] w_sig2_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	" ...  ...   .",
	".GGG..XXX.  .",
	".GGG..XXX....",
	".GGG..XXX.  .",
	" ...  ...   ."};
    public static String[] w_sig2x_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	"..........  .",
	".GGG..XXX.  .",
	".GGG..XXX....",
	".GGG..XXX.  .",
	"..........  ."};

    public static object[] w_sigP_pmap = new object[4];		/* RR, GR, GG, GO */
    public static String[] w_sigP_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	" ... ...... .",
	".GGG..XXX.. .",
	".GGG..X.X....",
	".GGG..XXXXX .",
	" ... ...... ."};
  }

  public class SignalAspect {
    public SignalAspect _next;
    public String _name;
    public String[] _iconN = new String[Config.MAX_FLASHING_ICONS],
          _iconE = new String[Config.MAX_FLASHING_ICONS],
          _iconS = new String[Config.MAX_FLASHING_ICONS],
          _iconW = new String[Config.MAX_FLASHING_ICONS];
    public String _action;

    public SignalAspect() {
      //_next = null;
      //_name = null;
      //_action = wxStrdup(wxPorting.T("none"));
      //memset(_iconN, 0, sizeof(_iconN));
      //memset(_iconE, 0, sizeof(_iconE));
      //memset(_iconS, 0, sizeof(_iconS));
      //memset(_iconW, 0, sizeof(_iconW));
    }


    ~SignalAspect() {
      //int i;

      //for(i = 0; i < MAX_FLASHING_ICONS; ++i) {
      //  if(_iconN[i])
      //    Globals.free(_iconN[i]);
      //  if(_iconE[i])
      //    Globals.free(_iconE[i]);
      //  if(_iconS[i])
      //    Globals.free(_iconS[i]);
      //  if(_iconW[i])
      //    Globals.free(_iconW[i]);
      //}
      //if(_name)
      //  Globals.free(_name);
    }
  }

  public class Signal : Track {

    public void SetAspect(String aspect) {
      //if(!_currentState || wxStrcmp(_currentState, aspect)) {
      //  signals_changed = 1;
      //  change_coord(this.x, this.y);
      //  this.aspect_changed = 1;
      //}

      //_currentState = aspect;
      //_nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }


    public String GetAspect() {
      throw new NotImplementedException();

      //if(_currentState)
      //  return _currentState;
      //if(this.status == ST_RED)
      //  return wxPorting.T("red");
      //return wxPorting.T("green");
    }

    public String GetAction() {
      throw new NotImplementedException();

      //String name = GetAspect();
      //SignalInterpreterData* interp = (SignalInterpreterData*)_interpreterData;
      //SignalAspect* asp;

      //if(!interp) {
      //  if(!wxStrcmp(name, wxPorting.T("red")))
      //    return wxPorting.T("stop");
      //  return wxPorting.T("proceed");
      //}
      //for(asp = interp._aspects; asp; asp = asp._next) {
      //  if(!wxStrcmp(name, asp._name) && asp._action)
      //    return asp._action;
      //}
      //return wxPorting.T("proceed");	    // broken signal? maybe we should stop.
    }

    public int GetNAspects() {
      throw new NotImplementedException();

      //int n = 0;
      //SignalInterpreterData* interp = (SignalInterpreterData*)_interpreterData;
      //SignalAspect* asp;

      //if(!interp) {
      //  if(this.fixedred)
      //    return 1;	    // only "stop" possible
      //  return 2;		    // only "stop" and "proceed"
      //}
      //for(asp = interp._aspects; asp; asp = asp._next)
      //  ++n;
      //return n;
    }

    public String GetAspect(int index) {
      throw new NotImplementedException();

      //int n = 0;
      //SignalInterpreterData* interp = (SignalInterpreterData*)_interpreterData;
      //SignalAspect* asp;

      //if(!interp) {
      //  if(this.fixedred)
      //    return wxPorting.T("red");
      //  return index == 0 ? wxPorting.T("red") : wxPorting.T("green");
      //}
      //for(asp = interp._aspects; asp; asp = asp._next) {
      //  if(n == index)
      //    return asp._name;
      //  ++n;
      //}
      //return wxPorting.T("red");	    // should be impossible to come here
    }

    public bool IsApproach() {
      throw new NotImplementedException();

      //return wxStrcmp(GetAction(), wxPorting.T("none")) == 0 || _isShuntingSignal;
    }

    public bool IsShuntingSignal() {
      return _isShuntingSignal;
    }

    public bool GetSpeedLimit(out int limit) {
      throw new NotImplementedException();

      //string buff;
      //String action = GetAction();
      //action = scan_word(action, buff);

      //if(!wxStrcmp(buff, wxPorting.T("speedLimit"))) {
      //  limit = wxAtoi(action);
      //  return true;
      //}
      //return false;
    }

    public bool GetApproach(ExprValue result) {
      throw new NotImplementedException();
      //bool res;
      //Vector* path;
      //int i;

      //res = GetNextPath(&path);
      //if(!path)
      //  return res;

      //for(i = 0; i < path._size; ++i) {
      //  Track* trk = path.TrackAt(i);
      //  trkdir dir = (trkdir)path.FlagAt(i);
      //  if(dir == E_W || dir == N_S) {
      //    if(trk.wsignal) {
      //      Signal* sig = trk.wsignal;
      //      if(sig != this && !sig.IsShuntingSignal() && sig.IsApproach()) {
      //        result._op = Addr;
      //        result._signal = sig;
      //        result._track = sig;
      //        break;
      //      }
      //    }
      //  } else if(trk.esignal) {
      //    Signal* sig = trk.esignal;
      //    if(sig != this && !sig.IsShuntingSignal() && sig.IsApproach()) {
      //      result._op = Addr;
      //      result._signal = sig;
      //      result._track = sig;
      //      break;
      //    }
      //  }
      //}
      //res = (i >= path._size) ? 0 : 1;
      //Vector_delete(path);
      //expr_buff += String.Format(res ? wxPorting.T(" approach found ") : wxPorting.T(" no approach "));
      //return res;
    }


    public bool GetPropertyValue(String prop, ExprValue result) {
      throw new NotImplementedException();
      //bool res;
      //Vector path;
      //int i;

      //Signal s = this;
      //wxPorting.wxStrncat(expr_buff, prop, sizeof(expr_buff) - 1);

      //if(!wxStrcmp(prop, wxPorting.T("aspect"))) {
      //  result._op = String;
      //  result._txt = s.GetAspect();
      //  Globals.expr_buff += String.Format(wxPorting.T("{%s}"), result._txt);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("auto"))) {
      //  result._op = Number;
      //  result._val = s.fleeted;
      //  Globals.expr_buff += String.Format(wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("enabled"))) {
      //  result._op = Number;
      //  result._val = s.fleeted && s.nowfleeted;
      //  Globals.expr_buff += String.Format(wxPorting.T("{%d}"), result._val);
      //  return true;
      //}

      //result._op = Number;
      //result._val = 0;
      //if(!wxStrcmp(prop, wxPorting.T("switchThrown"))) {
      //  res = s.GetNextPath(&path);
      //  if(!path)
      //    return res;

      //  for(i = 0; i < path._size; ++i) {
      //    Track* trk = path.TrackAt(i);

      //    if(trk.type != SWITCH)
      //      continue;
      //    switch(trk.direction) {
      //      case 10:	// these are Y switches, which are always
      //      case 11:	// considered as going to the main line,
      //      case 22:	// thus ignored as far as signals are concerned.
      //      case 23:
      //        continue;
      //    }
      //    if(trk.switched) {
      //      result._val = 1;
      //      break;
      //    }
      //  }
      //  Globals.expr_buff += String.Format(wxPorting.T("{%s}"), result._val ? wxPorting.T("switchThrown") : wxPorting.T("switchNotThrown"));
      //  Vector_delete(path);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextLimit"))) {
      //  res = s.GetNextPath(&path);
      //  if(!path)
      //    return res;

      //  int j;
      //  int lowSpeed = 1000;

      //  for(i = 0; i < path._size; ++i) {
      //    Track* trk = path.TrackAt(i);

      //    for(j = 0; j < NTTYPES; ++j)
      //      if(trk.speed[j] && trk.speed[j] < lowSpeed)
      //        lowSpeed = trk.speed[j];
      //  }
      //  result._val = lowSpeed;
      //  Vector_delete(path);
      //  Globals.expr_buff += String.Format(wxPorting.T("{%d}"), lowSpeed);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("occupied")) || !wxStrcmp(prop, wxPorting.T("locked"))) {
      //  res = s.GetNextPath(&path);
      //  if(!path)
      //    return res;

      //  int oldcolor = -1;
      //  Track* trk = 0;
      //  for(i = 0; i < path._size; ++i) {
      //    trk = path.TrackAt(i);
      //    if(trk.fgcolor != conf.fgcolor)
      //      break;
      //  }
      //  if(i >= path._size) // path is all black
      //    result._val = 0;
      //  else if(i == 0 && trk.fgcolor == color_green) // path is all green
      //    result._val = wxStrcmp(prop, wxPorting.T("locked")) == 0;
      //  else // path has an element that is red or blue or is white or is half black and half green
      //    result._val = 1;
      //  Vector_delete(path);
      //  Globals.expr_buff += String.Format(wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextLength"))) {
      //  res = s.GetNextPath(&path);
      //  if(!path)
      //    return res;

      //  int length = 0;

      //  for(i = 0; i < path._size; ++i) {
      //    Track* trk = path.TrackAt(i);
      //    length += trk.length;
      //  }
      //  result._val = length;
      //  Vector_delete(path);
      //  Globals.expr_buff += String.Format(wxPorting.T("{%d}"), length);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextApproach"))) {
      //  return GetApproach(result);
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextIsApproach"))) {
      //  res = GetApproach(result);
      //  result._op = Number;
      //  result._val = res == true;
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("nextStation"))) {
      //  result._op = String;
      //  result._txt = wxPorting.T("");

      //  res = s.GetNextPath(&path);
      //  if(!path)
      //    return res;

      //  for(i = 0; i < path._size; ++i) {
      //    Track* trk = path.TrackAt(i);

      //    if(!trk.isstation)
      //      continue;
      //    result._txt = trk.station;
      //    break;
      //  }
      //  Vector_delete(path);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%s}"), result._txt);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("redDistance"))) {
      //  result._op = Number;
      //  result._val = 50000;
      //  int distance = 0;
      //  Signal* nextSig = s;
      //  if(!s.IsClear())
      //    return true;
      //  do {
      //    res = nextSig.GetNextPath(&path);
      //    if(!path)
      //      return res;
      //    path.ComputeLength();
      //    distance += path._pathlen;
      //    Vector_delete(path);

      //    nextSig = nextSig.GetNextSignal();
      //    if(!nextSig)
      //      return true;
      //  } while(nextSig.IsClear());
      //  result._val = distance;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format(
      //            wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("color"))) {
      //  result._op = String;
      //  result._txt = wxPorting.T("");
      //  if(s.controls)
      //    result._txt = GetColorName(s.controls.fgcolor);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("script"))) {
      //  result._op = String;
      //  result._txt = this.stateProgram ? this.stateProgram : wxPorting.T("None");
      //  return true;
      //}
      //return false;
    }


    public bool SetPropertyValue(String prop, ExprValue val) {
      throw new NotImplementedException();
      //Signal* s = this;

      //if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //  // call t.Throw(val._val);
      //} else if(!wxStrcmp(prop, wxPorting.T("aspect"))) {
      //  s.SetAspect(val._txt);
      //} else if(!wxStrcmp(prop, wxPorting.T("auto"))) {
      //  s.fleeted = val._val;
      //} else if(!wxStrcmp(prop, wxPorting.T("enabled"))) {
      //  s.nowfleeted = val._val;
      //} else if(!wxStrcmp(prop, wxPorting.T("fleeted"))) {
      //  s.fleeted = val._val;
      //  s.nowfleeted = val._val;
      //} else if(!wxStrcmp(prop, wxPorting.T("shunting"))) {
      //  s._isShuntingSignal = val._val != 0;
      //} else if(!wxStrcmp(prop, wxPorting.T("click"))) {
      //  track_selected(s.x, s.y);
      //} else if(!wxStrcmp(prop, wxPorting.T("rclick"))) {
      //  track_selected1(s.x, s.y);
      //} else if(!wxStrcmp(prop, wxPorting.T("ctrlclick"))) {
      //  Coord c = new Coord(s.x, s.y);
      //  track_control_selected(c);
      //} else
      //  return false;
      //return true;
    }

    public void InitPixmaps() {
//      string bufffg;
//      string buff;
//      int fgr, fgg, fgb;
//      int r, g, b;
//      String green_name = "G      c #0000d8000000";

//      getcolor_rgb(fieldcolors[COL_TRACK], &fgr, &fgg, &fgb);
//      getcolor_rgb(fieldcolors[COL_BACKGROUND], &r, &g, &b);

//      sprintf(bufffg, ".      c #%02x00%02x00%02x00", fgr, fgg, fgb);
//      sprintf(buff, "       c #%02x00%02x00%02x00", r, g, b);
//      sprintf(buff, "       c lightgray", r, g, b);
//      n_sig_xpm[1] = s_sig_xpm[1] = e_sig_xpm[1] = w_sig_xpm[1] =
//n_sigx_xpm[1] = s_sigx_xpm[1] = e_sigx_xpm[1] = w_sigx_xpm[1] = buff;

//      n_sig_xpm[2] = s_sig_xpm[2] = e_sig_xpm[2] = w_sig_xpm[2] =
//n_sigx_xpm[2] = s_sigx_xpm[2] = e_sigx_xpm[2] = w_sigx_xpm[2] = bufffg;
//      n_sig_xpm[3] = s_sig_xpm[3] = e_sig_xpm[3] = w_sig_xpm[3] =
//n_sigx_xpm[3] = s_sigx_xpm[3] = e_sigx_xpm[3] = w_sigx_xpm[3] = "G      c red";
//      n_sig_pmap[0] = get_pixmap(n_sig_xpm);
//      s_sig_pmap[0] = get_pixmap(s_sig_xpm);
//      e_sig_pmap[0] = get_pixmap(e_sig_xpm);
//      w_sig_pmap[0] = get_pixmap(w_sig_xpm);
//      n_sigx_pmap[0] = get_pixmap(n_sigx_xpm);
//      s_sigx_pmap[0] = get_pixmap(s_sigx_xpm);
//      e_sigx_pmap[0] = get_pixmap(e_sigx_xpm);
//      w_sigx_pmap[0] = get_pixmap(w_sigx_xpm);

//      n_sig_xpm[3] = s_sig_xpm[3] = e_sig_xpm[3] = w_sig_xpm[3] =
//n_sigx_xpm[3] = s_sigx_xpm[3] = e_sigx_xpm[3] = w_sigx_xpm[3] = green_name;
//      n_sig_pmap[1] = get_pixmap(n_sig_xpm);
//      s_sig_pmap[1] = get_pixmap(s_sig_xpm);
//      e_sig_pmap[1] = get_pixmap(e_sig_xpm);
//      w_sig_pmap[1] = get_pixmap(w_sig_xpm);
//      n_sigx_pmap[1] = get_pixmap(n_sigx_xpm);
//      s_sigx_pmap[1] = get_pixmap(s_sigx_xpm);
//      e_sigx_pmap[1] = get_pixmap(e_sigx_xpm);
//      w_sigx_pmap[1] = get_pixmap(w_sigx_xpm);

//      e_sig2_xpm[1] = w_sig2_xpm[1] =
//        n_sig2_xpm[1] = s_sig2_xpm[1] =
//        e_sig2x_xpm[1] = w_sig2x_xpm[1] =
//        n_sig2x_xpm[1] = s_sig2x_xpm[1] =
//        e_sigP_xpm[1] = w_sigP_xpm[1] = buff;
//      e_sig2_xpm[2] = w_sig2_xpm[2] =
//        n_sig2_xpm[2] = s_sig2_xpm[2] =
//        e_sig2x_xpm[2] = w_sig2x_xpm[2] =
//        n_sig2x_xpm[2] = s_sig2x_xpm[2] =
//        e_sigP_xpm[2] = w_sigP_xpm[2] = bufffg;
//      e_sig2_xpm[3] = w_sig2_xpm[3] =
//        n_sig2_xpm[3] = s_sig2_xpm[3] =
//        e_sig2x_xpm[3] = w_sig2x_xpm[3] =
//        n_sig2x_xpm[3] = s_sig2x_xpm[3] =
//        e_sigP_xpm[3] = w_sigP_xpm[3] = "G      c red";
//      e_sig2_xpm[4] = w_sig2_xpm[4] =
//        n_sig2_xpm[4] = s_sig2_xpm[4] =
//        e_sig2x_xpm[4] = w_sig2x_xpm[4] =
//        n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c red";
//      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c gray";
//      e_sig2_pmap[0] = get_pixmap(e_sig2_xpm);
//      w_sig2_pmap[0] = get_pixmap(w_sig2_xpm);
//      e_sigP_pmap[0] = get_pixmap(e_sigP_xpm);
//      w_sigP_pmap[0] = get_pixmap(w_sigP_xpm);
//      n_sig2_pmap[0] = get_pixmap(n_sig2_xpm);
//      s_sig2_pmap[0] = get_pixmap(s_sig2_xpm);
//      e_sig2x_pmap[0] = get_pixmap(e_sig2x_xpm);
//      w_sig2x_pmap[0] = get_pixmap(w_sig2x_xpm);
//      n_sig2x_pmap[0] = get_pixmap(n_sig2x_xpm);
//      s_sig2x_pmap[0] = get_pixmap(s_sig2x_xpm);

//      e_sig2_xpm[3] = w_sig2_xpm[3] =
//      n_sig2_xpm[3] = s_sig2_xpm[3] =
//      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
//      n_sig2x_xpm[3] = s_sig2x_xpm[3] = green_name;
//      e_sigP_xpm[3] = w_sigP_xpm[3] = green_name;
//      e_sig2_xpm[4] = w_sig2_xpm[4] =
//      n_sig2_xpm[4] = s_sig2_xpm[4] =
//      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
//      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c red";
//      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c gray";
//      e_sig2_pmap[1] = get_pixmap(e_sig2_xpm);
//      w_sig2_pmap[1] = get_pixmap(w_sig2_xpm);
//      e_sigP_pmap[1] = get_pixmap(e_sigP_xpm);
//      w_sigP_pmap[1] = get_pixmap(w_sigP_xpm);
//      n_sig2_pmap[1] = get_pixmap(n_sig2_xpm);
//      s_sig2_pmap[1] = get_pixmap(s_sig2_xpm);
//      e_sig2x_pmap[1] = get_pixmap(e_sig2x_xpm);
//      w_sig2x_pmap[1] = get_pixmap(w_sig2x_xpm);
//      n_sig2x_pmap[1] = get_pixmap(n_sig2x_xpm);
//      s_sig2x_pmap[1] = get_pixmap(s_sig2x_xpm);

//      e_sig2_xpm[3] = w_sig2_xpm[3] =
//      n_sig2_xpm[3] = s_sig2_xpm[3] =
//      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
//      n_sig2x_xpm[3] = s_sig2x_xpm[3] = green_name;
//      e_sig2_xpm[4] = w_sig2_xpm[4] =
//      n_sig2_xpm[4] = s_sig2_xpm[4] =
//      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
//      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c #0000d8000000";
//      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c white";
//      e_sig2_pmap[2] = get_pixmap(e_sig2_xpm);
//      w_sig2_pmap[2] = get_pixmap(w_sig2_xpm);
//      e_sigP_pmap[2] = get_pixmap(e_sigP_xpm);
//      w_sigP_pmap[2] = get_pixmap(w_sigP_xpm);
//      n_sig2_pmap[2] = get_pixmap(n_sig2_xpm);
//      s_sig2_pmap[2] = get_pixmap(s_sig2_xpm);
//      e_sig2x_pmap[2] = get_pixmap(e_sig2x_xpm);
//      w_sig2x_pmap[2] = get_pixmap(w_sig2x_xpm);
//      n_sig2x_pmap[2] = get_pixmap(n_sig2x_xpm);
//      s_sig2x_pmap[2] = get_pixmap(s_sig2x_xpm);

//      e_sig2_xpm[3] = w_sig2_xpm[3] =
//      n_sig2_xpm[3] = s_sig2_xpm[3] =
//      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
//      n_sig2x_xpm[3] = s_sig2x_xpm[3] = "G      c red";
//      e_sigP_xpm[3] = w_sigP_xpm[3] = "G      c red";
//      e_sig2_xpm[4] = w_sig2_xpm[4] =
//      n_sig2_xpm[4] = s_sig2_xpm[4] =
//      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
//      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c orange";
//      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c white";
//      e_sig2_pmap[3] = get_pixmap(e_sig2_xpm);
//      w_sig2_pmap[3] = get_pixmap(w_sig2_xpm);
//      e_sigP_pmap[3] = get_pixmap(e_sigP_xpm);
//      w_sigP_pmap[3] = get_pixmap(w_sigP_xpm);
//      /*n_sig2_pmap[3] = get_pixmap(n_sig2_xpm);
//      s_sig2_pmap[3] = get_pixmap(s_sig2_xpm);*/
//      e_sig2x_pmap[3] = get_pixmap(e_sig2x_xpm);
//      w_sig2x_pmap[3] = get_pixmap(w_sig2x_xpm);
    }

    // static
    public void FreePixmaps() {
      //int i;

      //for(i = 0; i < 4; ++i) {
      //  delete_pixmap(e_sig2_pmap[i]);
      //  delete_pixmap(w_sig2_pmap[i]);
      //  delete_pixmap(e_sigP_pmap[i]);
      //  delete_pixmap(w_sigP_pmap[i]);
      //  delete_pixmap(n_sig2_pmap[i]);
      //  delete_pixmap(s_sig2_pmap[i]);
      //  delete_pixmap(e_sig2x_pmap[i]);
      //  delete_pixmap(w_sig2x_pmap[i]);
      //  delete_pixmap(n_sig2x_pmap[i]);
      //  delete_pixmap(s_sig2x_pmap[i]);
      //}
      //for(i = 0; i < 2; ++i) {
      //  delete_pixmap(n_sig_pmap[i]);
      //  delete_pixmap(s_sig_pmap[i]);
      //  delete_pixmap(e_sig_pmap[i]);
      //  delete_pixmap(w_sig_pmap[i]);
      //  delete_pixmap(n_sigx_pmap[i]);
      //  delete_pixmap(s_sigx_pmap[i]);
      //  delete_pixmap(e_sigx_pmap[i]);
      //  delete_pixmap(w_sigx_pmap[i]);
      //}
    }

    public void Draw() {
      //grcolor color = color_red;
      //int i;
      //object p = 0;
      //Signal* t = this;

      //i = 0;					/* RR */
      //if(!t._interpreterData || !(p = FindIcon())) {
      //  if(t.fleeted) {
      //    if(t.status == ST_GREEN) {
      //      if(t.nowfleeted)
      //        i = 2;			/* GG */
      //      else
      //        i = 1;			/* GR */
      //    } else if(t.nowfleeted)
      //      i = 3;				/* RO */
      //    switch(t.direction) {
      //      case W_E:
      //        p = signal_traditional ?
      //      (t.signalx ? e_sig2x_pmap[i] : e_sig2_pmap[i]) : e_sigP_pmap[i];
      //        break;
      //      case E_W:
      //        p = signal_traditional ?
      //      (t.signalx ? w_sig2x_pmap[i] : w_sig2_pmap[i]) : w_sigP_pmap[i];
      //        break;
      //      case N_S:
      //        p = t.signalx ? s_sig2x_pmap[i] : s_sig2_pmap[i];
      //        break;
      //      case S_N:
      //        p = t.signalx ? n_sig2x_pmap[i] : n_sig2_pmap[i];
      //        break;
      //    }
      //    if(p)
      //      draw_pixmap(t.x, t.y, p);
      //    if(editing && show_links && t.controls)
      //      draw_link(t.x, t.y, t.controls.x, t.controls.y, conf.linkcolor);
      //    return;
      //  }
      //  if(t.status == ST_GREEN)
      //    i = 1;
      //  switch(t.direction) {
      //    case W_E:
      //      p = t.signalx ? e_sigx_pmap[i] : e_sig_pmap[i];
      //      break;
      //    case E_W:
      //      p = t.signalx ? w_sigx_pmap[i] : w_sig_pmap[i];
      //      break;
      //    case N_S:
      //      p = t.signalx ? s_sigx_pmap[i] : s_sig_pmap[i];
      //      break;
      //    case S_N:
      //      p = t.signalx ? n_sigx_pmap[i] : n_sig_pmap[i];
      //      break;
      //  }
      //}
      //if(p)
      //  draw_pixmap(t.x, t.y, p);
      //if(editing && show_links && t.controls)
      //  draw_link(t.x, t.y, t.controls.x, t.controls.y, conf.linkcolor);
    }




    public void ParseAspect(String pp) {
      //string line;
      //String p = *pp;
      //String* dst;
      //SignalAspect* asp = new SignalAspect();
      //SignalInterpreterData* interp = (SignalInterpreterData*)_interpreterData;

      //p = scan_line(p, line);
      //if(line[0])
      //  asp._name = wxStrdup(line);
      //do {
      //  dst = 0;
      //  if(match(&p, wxPorting.T("IconN:")))
      //    dst = &asp._iconN[0];
      //  else if(match(&p, wxPorting.T("IconE:")))
      //    dst = &asp._iconE[0];
      //  else if(match(&p, wxPorting.T("IconS:")))
      //    dst = &asp._iconS[0];
      //  else if(match(&p, wxPorting.T("IconW:")))
      //    dst = &asp._iconW[0];
      //  if(dst) {
      //    p = scan_line(p, line);
      //    if(line[0]) {
      //      if(wxStrchr(line, ' ')) {
      //        this._isFlashing = true;
      //        int nxt = 0;
      //        String p1, pp;

      //        pp = line;
      //        do {
      //          for(p1 = pp; *pp && *pp != ' '; ++pp) ;
      //          if(p1 != pp) {
      //            int oc = *pp;
      //            *pp = 0;
      //            *dst++ = wxStrdup(p1);
      //            *pp = oc;
      //            while(*pp == ' ') ++pp;
      //            if(++nxt >= MAX_FLASHING_ICONS)
      //              break;
      //          }
      //        } while(*pp);
      //      } else
      //        *dst = wxStrdup(line);
      //    }
      //    continue;
      //  }
      //  if(match(&p, wxPorting.T("Action:"))) {
      //    p = scan_line(p, line);
      //    if(!line[0])
      //      continue;
      //    if(asp._action)
      //      Globals.free(asp._action);
      //    asp._action = wxStrdup(line);
      //    continue;
      //  }
      //  break;
      //  // unknown. Should we give an error?
      //} while(1);
      //asp._next = interp._aspects;
      //interp._aspects = asp;
      //*pp = p;
    }


    public void ParseProgram() {
      //String p;

      //if(!this.stateProgram || !*this.stateProgram)
      //  return;
      //Script* s = find_script(this.stateProgram);
      //SignalInterpreterData* interp;
      //if(!s) {
      //  s = new_script(this.stateProgram);
      //  // return;
      //}
      //if(!s.ReadFile())
      //  return;

      //if(!_interpreterData)
      //  _interpreterData = new SignalInterpreterData();

      //interp = (SignalInterpreterData*)_interpreterData;
      //p = s._text;
      //while(*p) {
      //  String p1 = p;
      //  while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
      //    ++p1;
      //  p = p1;
      //  if(match(&p, wxPorting.T("Aspect:"))) {
      //    p1 = p;
      //    ParseAspect(&p);
      //  } else if(match(&p, wxPorting.T("OnClick:"))) {
      //    p1 = p;
      //    interp._onClick = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCleared:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCleared = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnShunt:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onShunt = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnInit:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onInit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnUpdate:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onUpdate = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnAuto:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onAuto = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCross:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCross = ParseStatements(&p);
      //  }
      //  if(p1 == p)	    // error! couldn't parse token
      //    break;
      //}
    }

    public Signal GetNextSignal() {
      throw new NotImplementedException();
      //Signal* sig = this;

      //Track* t;
      //trkdir dir;
      //Vector* path;

      //if(!sig.controls)
      //  return 0;

      //path = findPath(sig.controls, sig.direction);
      //if(!path)
      //  return 0;
      //t = path.TrackAt(path._size - 1);
      //dir = (trkdir)path.FlagAt(path._size - 1);
      //Vector_delete(path);
      //Track* t1;
      //if(!(t1 = findNextTrack(dir, t.x, t.y))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format(
      //wxPorting.T("no next track after (%d,%d)"), t.x, t.y);
      //  return 0;
      //}
      //t = t1;
      //sig = (Signal*)((dir == W_E || dir == S_N) ? t.esignal : t.wsignal);
      //if(!sig) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format(
      //wxPorting.T("no signal after (%d,%d)"), t.x, t.y);
      //  return 0;
      //}
      //expr_buff + Globals.wxStrlen(expr_buff) = String.Format(
      //    wxPorting.T("(%d,%d)"), sig.x, sig.y);
      //return sig;
    }

    public bool GetNextPath(Vector ppath) // Erik: original code: (Vector **ppath)
    {
      throw new NotImplementedException();

      //Signal* s = this;

      //*ppath = 0;
      //if(s.fixedred) {
      //  wxStrncat(expr_buff, wxPorting.T("signal is always red"), sizeof(expr_buff) - 1);
      //  return true;
      //}
      //if(s.controls)
      //  *ppath = findPath(s.controls, s.direction);
      //if(!*ppath) {
      //  wxStrncat(expr_buff, wxPorting.T("no valid path"), sizeof(expr_buff) - 1);
      //  return false;
      //}
      //if(gMustBeClearPath) {
      //  //	    if(!s.IsClear()) { // t.status == ST_GREEN) {
      //  //		Vector_delete(path);
      //  //		return true;
      //  //	    }
      //  if(pathIsBusy(null, *ppath, s.direction)) {
      //    Vector_delete(*ppath);
      //    *ppath = 0;
      //    wxStrncat(expr_buff, wxPorting.T("path is busy"), sizeof(expr_buff) - 1);
      //    return true;
      //  }
      //}
      //return true;
    }



    public object FindIcon() {
      throw new NotImplementedException();
      //SignalInterpreterData* interp = (SignalInterpreterData*)_interpreterData;
      //SignalAspect* asp = interp._aspects;
      //String* p = 0;
      //int ix;
      //String curState;

      //if(this._currentState)
      //  curState = this._currentState;
      //else if(this.status == ST_GREEN)
      //  curState = wxPorting.T("green");
      //else
      //  curState = wxPorting.T("red");

      //while(asp) {
      //  if(!wxStricmp(asp._name, curState))
      //    break;
      //  asp = asp._next;
      //}
      //if(!asp)
      //  return 0;
      //switch(this.direction) {
      //  case W_E:
      //    p = asp._iconE;
      //    break;

      //  case E_W:
      //    p = asp._iconW;
      //    break;

      //  case N_S:
      //    p = asp._iconS;
      //    break;

      //  case S_N:
      //    p = asp._iconN;
      //    break;
      //}
      //if(!p || !*p)
      //  return 0;
      //if(_isFlashing) {
      //  if(!p[_nextFlashingIcon])
      //    _nextFlashingIcon = 0;
      //  p = &p[_nextFlashingIcon];
      //}
      //if((ix = get_pixmap_index(*p)) < 0)
      //  return 0;
      //return pixmaps[ix].pixels;
    }




    public bool IsClear() {
      throw new NotImplementedException();
      //if(this._currentState) {
      //  if(_isShuntingSignal) {
      //    return wxStrcmp(this._currentState, wxPorting.T("yellow")) != 0;
      //  }
      //  return wxStrcmp(GetAction(), wxPorting.T("stop")) != 0;	// !Rask
      //}
      //return this.status == ST_GREEN;
    }


    public void OnClear() {
      throw new NotImplementedException();

      //signals_changed = 1;
      //if(_interpreterData) {
      //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //  if(interp._onCleared) {
      //    interp._signal = this;
      //    interp._mustBeClearPath = true;
      //    expr_buff = String.Format( wxPorting.T("%s::OnClear(%d,%d)"), this.stateProgram, this.x, this.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onCleared);
      //    return;
      //  }
      //}

      //this.status = ST_GREEN;
      //_currentState = wxPorting.T("green");
      //_nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }


    public void OnUnclear() {
      //signals_changed = 1;
      //if(_interpreterData) {
      //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //  if(interp._onClick) {
      //    interp._signal = this;
      //    expr_buff = String.Format( wxPorting.T("%s::OnUnclear(%d,%d)"), this.stateProgram, this.x, this.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onClick);
      //    return;
      //  }
      //}

      //this.status = ST_RED;
      //SetAspect(wxPorting.T("red")); // _currentState = wxPorting.T("red");
      //_nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }


    public void OnShunt() {
      //signals_changed = 1;
      //if(_interpreterData) {
      //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //  if(interp._onShunt) {
      //    interp._signal = this;
      //    interp._mustBeClearPath = false;
      //    expr_buff = String.Format( wxPorting.T("%s::OnShunt(%d,%d)"), this.stateProgram, this.x, this.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onShunt);
      //    return;
      //  }
      //}

      //this.status = ST_WHITE;
      //_currentState = wxPorting.T("white");
      //_nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }



    public void OnCross() {
      ////	if(this.aspect_changed)
      ////	    return;

      //if(_interpreterData) {
      //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //  if(interp._onCross) {
      //    interp._signal = this;
      //    expr_buff = String.Format( wxPorting.T("%s::OnCross(%d,%d)"), this.stateProgram, this.x, this.y);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onCross);
      //    return;
      //  }
      //}
      //signals_changed = 1;
      //this.status = ST_RED;
      //SetAspect(wxPorting.T("red"));
      //_nextFlashingIcon = 0;	    // in case new aspect is not flashing
      //if(_intermediate) {
      //  if(_nReservations < 2) {
      //    _nReservations = 0;
      //    nowfleeted = 0;
      //    fleeted = 0;
      //  } else
      //    --_nReservations;
      //}
    }


    public void OnUnlock() {
      //signals_changed = 1;
      //this.status = ST_GREEN;
    }


    public void OnUnfleet() {
      //signals_changed = 1;
      //this.status = ST_GREEN;
    }

    public void OnUpdate() {
      ////	if(this.aspect_changed)
      ////	    return;

      //if(!_interpreterData)
      //  return;

      //SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //if(!interp._onUpdate)
      //  return;

      //interp._signal = this;
      //expr_buff = String.Format( wxPorting.T("%s::OnUpdate(%d,%d)"), this.stateProgram, this.x, this.y);
      //Trace(expr_buff);
      //interp.Execute(interp._onUpdate);
    }

    public void OnInit() {
      //if(!_interpreterData)
      //  return;
      //SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //if(!interp._onInit)
      //  return;
      //interp._signal = this;
      //interp._mustBeClearPath = true;
      //expr_buff = String.Format( wxPorting.T("%s::OnInit(%d,%d)"), this.stateProgram, this.x, this.y);
      //Trace(expr_buff);
      //interp.Execute(interp._onInit);
      //return;
    }

    public void OnAuto() {
      //if(!_interpreterData)
      //  return;

      //SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //if(!interp._onAuto)
      //  return;

      //interp._signal = this;
      //interp._mustBeClearPath = true;
      //expr_buff = String.Format( wxPorting.T("%s::OnAuto(%d,%d)"), this.stateProgram, this.x, this.y);
      //Trace(expr_buff);
      //interp.Execute(interp._onAuto);
    }


    public void OnClicked() {
      //if(!_interpreterData)
      //  return;

      //SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //if(!interp._onClick)
      //  return;

      //interp._signal = this;
      //interp._mustBeClearPath = true;
      //expr_buff = String.Format( wxPorting.T("%s::OnClicked(%d,%d)"), this.stateProgram, this.x, this.y);
      //Trace(expr_buff);
      //interp.Execute(interp._onClick);
    }


    public void OnFlash() {
    //  SignalAspect* asp;

    //  if(!_interpreterData)
    //    return;
    //  if(!_currentState)
    //    return;

    //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
    //  String* p;

    //  for(asp = interp._aspects; asp; asp = asp._next)
    //    if(!wxStrcmp(_currentState, asp._name)) {
    //      int nxt = _nextFlashingIcon + 1;

    //      if(nxt >= MAX_FLASHING_ICONS)
    //        nxt = 0;
    //      p = 0;
    //      switch(this.direction) {
    //        case W_E:
    //          p = asp._iconE;
    //          break;

    //        case E_W:
    //          p = asp._iconW;
    //          break;

    //        case N_S:
    //          p = asp._iconS;
    //          break;

    //        case S_N:
    //          p = asp._iconN;
    //          break;
    //      }
    //      if(!p || !p[nxt])
    //        nxt = 0;
    //      _nextFlashingIcon = nxt;
    //      change_coord(this.x, this.y);
    //      break;
    //    }
    }
  }

  public class SignalInterpreterData : InterpreterData {

    public SignalInterpreterData() {
      //_aspects = 0;
      //_onClick = 0;
      //_onCleared = 0;
      //_onShunt = 0;
      //_onUpdate = 0;
      //_onInit = 0;
      //_onCross = 0;
      //_onAuto = 0;
      //_mustBeClearPath = false;
    }

    public SignalInterpreterData(SignalInterpreterData base_) {
      //_aspects = base_._aspects;
      //_onClick = base_._onClick;
      //_onCleared = base_._onCleared;
      //_onShunt = base_._onShunt;
      //_onUpdate = base_._onUpdate;
      //_onInit = base_._onInit;
      //_onCross = base_._onCross;
      //_onAuto = base_._onAuto;

      //_signal = 0;
      //_track = 0;
      //_train = 0;
      //_stackPtr = 0;
      //_mustBeClearPath = false;
    }

    ~SignalInterpreterData() {
    }

    public void Free() {
      //while(_aspects) {
      //  SignalAspect asp = _aspects;
      //  _aspects = asp._next;
      //  Globals.delete(asp);
      //}

      //if(_onAuto)
      //  Globals.delete(_onAuto);
      //if(_onCleared)
      //  Globals.delete(_onCleared);
      //if(_onShunt)
      //  Globals.delete(_onShunt);
      //if(_onClick)
      //  Globals.delete(_onClick);
      //if(_onCross)
      //  Globals.delete(_onCross);
      //if(_onInit)
      //  Globals.delete(_onInit);
      //if(_onUpdate)
      //  Globals.delete(_onUpdate);
    }

    public SignalAspect _aspects;	// list of aspects (states)
    public Statement _onClick;	// list of actions (statements)
    public Statement _onCleared;	// list of actions (statements)
    public Statement _onShunt;	// list of actions (statements)
    public Statement _onUpdate;	// list of actions (statements)
    public Statement _onInit;	// list of actions (statements)
    public Statement _onCross;	// list of actions (statements)
    public Statement _onAuto;	// list of actions (statements)

    public bool _mustBeClearPath;


    public Signal GetNextSignal(Signal sig) {
      return sig.GetNextSignal();
    }

    public bool GetNextPath(Signal sig, ref Vector ppath) {
      throw new NotImplementedException();

      //gMustBeClearPath = _mustBeClearPath;
      //bool res = sig.GetNextPath(ppath);
      //gMustBeClearPath = false;
      //return res;
    }

    public bool Evaluate(ExprNode n, ExprValue result) {
      throw new NotImplementedException();

      //ExprValue left = new ExprValue(NodeOp.None);
      //ExprValue right = new ExprValue(NodeOp.None);
      //String prop;
      //Signal sig;

      //if(!n)
      //  return false;
      //switch(n._op) {

      //  case NextSignalRef:

      //    sig = GetNextSignal(_signal);
      //    if(!sig)
      //      return false;
      //    result._op = SignalRef;
      //    result._signal = sig;
      //    return true;

      //  case NextApproachRef:

      //    if(!_signal.GetApproach(result))
      //      return false;
      //    result._op = SignalRef;
      //    return true;

      //  case Dot:

      //    result._op = Addr;
      //    if(!(n._left)) {
      //      result._signal = this._signal;		// .<property> .   this.signal
      //      result._op = SignalRef;
      //      if(!result._signal) {
      //        wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
      //        return false;
      //      }
      //      TraceCoord(result._signal.x, result._signal.y);
      //    } else if(n._left && n._left._op == Dot) {
      //      bool oldForAddr = _forAddr;
      //      _forAddr = true;
      //      if(!Evaluate(n._left, result)) {	// <signal>.<property>
      //        _forAddr = oldForAddr;
      //        return false;
      //      }
      //      _forAddr = oldForAddr;

      //      if(result._op != SignalRef)
      //        return false;
      //      /*		result._signal = GetNextSignal(result._signal);
      //          if(!result._signal) {
      //              wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
      //              return false;
      //          } */
      //      TraceCoord(result._signal.x, result._signal.y);
      //    } else {
      //      if(!Evaluate(n._left, result))
      //        return false;
      //    }
      //    if(n._right) {
      //      switch(n._right._op) {
      //        case SignalRef:
      //        case NextSignalRef:
      //          result._signal = GetNextSignal(result._signal);
      //          if(!result._signal) {
      //            wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
      //            return false;
      //          }
      //          TraceCoord(result._signal.x, result._signal.y);
      //          break;

      //        case NextApproachRef:
      //          if(!result._signal.GetApproach(result))
      //            return false;
      //          result._op = SignalRef;
      //          break;
      //      }
      //    }
      //    result._txt = (n._right && n._right._txt) ? n._right._txt : n._txt;
      //    if(_forAddr)
      //      return true;

      //    prop = result._txt;
      //    if(!prop)
      //      return false;

      //    switch(result._op) {

      //      case SwitchRef:

      //        if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //          result._op = Number;
      //          if(!result._track || result._track.type != SWITCH)
      //            result._val = 0;
      //          else
      //            result._val = result._track.switched;
      //          return true;
      //        }

      //      case Addr:
      //      case TrackRef:

      //        if(!result._track)
      //          return false;
      //        return result._track.GetPropertyValue(prop, result);

      //      case SignalRef:

      //        if(!result._signal)
      //          return false;
      //        return result._signal.GetPropertyValue(prop, result);

      //      case TrainRef:

      //        if(!result._train)
      //          return false;
      //        return result._train.GetPropertyValue(prop, result);

      //    }
      //    return false;

      //  default:

      //    return InterpreterData.Evaluate(n, result);
      //}
      //return false;
    }
  }


}