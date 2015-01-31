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
namespace Traincontroller2 {

  public partial class Configuration {
    public static int MAX_SWBD_X = 40;
    public static int MAX_SWBD_Y = 40;
    public static int MAX_NAME_LEN = 256;
  }

  public class SwitchBoardInterpreterData : InterpreterData {

    public SwitchBoardInterpreterData() {
      _onClick = null;
      _onCleared = null;
      _onUpdate = null;
      _onInit = null;
    }

    public SwitchBoardInterpreterData(SwitchBoardInterpreterData base_) {
      //_onClick = base_._onClick;
      //_onCleared = base_._onCleared;
      //_onUpdate = base_._onUpdate;
      //_onInit = base_._onInit;

      //_signal = null;
      //_track = null;
      //_train = null;
      //_stackPtr = null;
    }

    public void Free() {
      if(_onAuto != null)
        Globals.delete(_onAuto);
      if(_onCleared != null)
        Globals.delete(_onCleared);
      if(_onShunt != null)
        Globals.delete(_onShunt);
      if(_onClick != null)
        Globals.delete(_onClick);
      if(_onCross != null)
        Globals.delete(_onCross);
      if(_onInit != null)
        Globals.delete(_onInit);
      if(_onUpdate != null)
        Globals.delete(_onUpdate);
    }

    public Statement _onClick;	// list of actions (public Statements)
    public Statement _onCleared;	// list of actions (public Statements)
    public Statement _onShunt;	// list of actions (public Statements)
    public Statement _onUpdate;	// list of actions (public Statements)
    public Statement _onInit;	// list of actions (public Statements)
    public Statement _onCross;	// list of actions (public Statements)
    public Statement _onAuto;	// list of actions (public Statements)


    public bool Evaluate(ExprNode n, ExprValue result) {
#if false
	ExprValue left(None);
	ExprValue right(None);
	String prop;

	if(!n)
	    return false;
        switch(n._op) {

	case NextSignalRef:

	    sig = GetNextSignal(_signal);
	    if(!sig)
		return false;
	    result._op = SignalRef;
	    result._signal = sig;
	    return true;

	case NextApproachRef:

	    if(!_signal.GetApproach(result))
		return false;
	    result._op = SignalRef;
	    return true;

	case Dot:
	    
	    result._op = Addr;
	    if(!(n._left)) {
		result._signal = this._signal;		// .<property> .   this.signal
		result._op = SignalRef;
		if(!result._signal) {
		    wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
		    return false;
		}
		TraceCoord(result._signal.x, result._signal.y);
	    } else if(n._left && n._left._op == Dot) {
		bool oldForAddr = _forAddr;
		_forAddr = true;
		if(!Evaluate(n._left, result)) {	// <signal>.<property>
		    _forAddr = oldForAddr;
		    return false;
		}
		_forAddr = oldForAddr;

		if(result._op != SignalRef)
		    return false;
/*		result._signal = GetNextSignal(result._signal);
		if(!result._signal) {
		    wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
		    return false;
		} */
		TraceCoord(result._signal.x, result._signal.y);
	    } else {
		if(!Evaluate(n._left, result))
		    return false;
	    }
	    if(n._right) {
		switch(n._right._op) {
		case SignalRef:
		case NextSignalRef:
		    result._signal = GetNextSignal(result._signal);
		    if(!result._signal) {
			wxStrcat(expr_buff, wxPorting.T("no current signal for '.'"));
			return false;
		    }
		    TraceCoord(result._signal.x, result._signal.y);
		    break;

		case NextApproachRef:
		    if(!result._signal.GetApproach(result))
			return false;
		    result._op = SignalRef;
		    break;
		}
	    }
	    result._txt = (n._right && n._right._txt) ? n._right._txt : n._txt;
	    if(_forAddr)
		return true;

	    prop = result._txt;
	    if(!prop)
		return false;

	    switch(result._op) {
	    
	    case SwitchRef:

		if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
		    result._op = Number;
		    if(!result._track || result._track.type != SWITCH)
			result._val = 0;
		    else
			result._val = result._track.switched;
		    return true;
		}

	    case Addr:
	    case TrackRef:

		if(!result._track)
		    return false;
		return result._track.GetPropertyValue(prop, result);

	    case SignalRef:

		if(!result._signal)
		    return false;
		return result._signal.GetPropertyValue(prop, result);

	    case TrainRef:

		if(!result._train)
		    return false;
		return result._train.GetPropertyValue(prop, result);

	    }
	    return false;

	default:

	    return InterpreterData::Evaluate(n, result);
	}
#endif
      return false;
    }

  }




  public class SwitchBoardCellAspect {
    public SwitchBoardCellAspect _next;
    public String _name;		// aspect name
    public String[] _icons = new String[4];		// image to show in cell if any
    public String _action;		// URL of action to perform when clicked
    public String _bgcolor;		// background color for this aspect

    public SwitchBoardCellAspect() {
      //_next = null;
      //_name = null;
      //_action = null;
      //_bgcolor = null;
      //memset(_icons, 0, sizeof(_icons));
    }


    ~SwitchBoardCellAspect() {
      //int i;

      //for(i = 0; i < Config.MAX_FLASHING_ICONS; ++i) {
      //  if(_icons[i])
      //    Globals.free(_icons[i]);
      //}
      //if(_name)
      //  Globals.free(_name);
      //if(_action)
      //  Globals.free(_action);
      //if(_bgcolor)
      //  Globals.free(_bgcolor);
    }
  }


  //	Aspect: locked/free/avail
  //	Bgcolor: color/#rrggbb
  //	Icons: icon1 [icon2 ...]

  //
  //	Execution of the Abstract Syntax Tree
  //






  public class SwitchBoardCell {

    public SwitchBoardCell _next;	    // next cell in switchboard

    public int _x, _y;		    // position in SwitchBoard._cells
    public TDString _itinerary;	    // linked itinerary
    public TDString _text;		    // text to draw, if any

    public String _aspect;	    // current aspect
    public String _stateProgram;
    public object _interpreterData;

    public SwitchBoardCell() {
      _x = _y = 0;
      _aspect = null;
      _stateProgram = null;
      _interpreterData = null;
    }

    ~SwitchBoardCell() {
      //if(_stateProgram)
      //  Globals.free(_stateProgram);
      //if(_interpreterData)
      //  Globals.delete(_interpreterData);
    }

    public object FindIcon() {
#if false
	SwitchBoardInterpreterData *interp = (SwitchBoardInterpreterData *)_interpreterData;
	SwitchBoardCellAspect	*asp = interp._aspects;
	String *p = 0;
	int		ix;
	String curState;

	curState = this._currentState;

	while(asp) {
	    if(!wxStricmp(asp._name, curState))
		break;
	    asp = asp._next;
	}
	if(!asp)
	    return 0;
	p = asp._icons[0];
	if(!p || !*p)
	    return 0;
	if(_isFlashing) {
	    if(!p[_nextFlashingIcon])
		_nextFlashingIcon = 0;
	    p = &p[_nextFlashingIcon];
	}
	if((ix = get_pixmap_index(*p)) < 0)
	    return 0;
	return pixmaps[ix].pixels;
#else
      return 0;
#endif
    }



    public void OnUpdate() {
      //if(!_interpreterData)
      //  return;

      //SwitchBoardInterpreterData interp = new SwitchBoardInterpreterData((SwitchBoardInterpreterData*)_interpreterData);
      //if(!interp._onUpdate)
      //  return;

      //expr_buff = String.Format(wxPorting.T("%s::OnUpdate(%d,%d)"), _stateProgram, _x, _y);
      //Trace(expr_buff);
      //interp.Execute(interp._onUpdate);
    }

    public void OnInit() {
      //if(!_interpreterData)
      //  return;
      //SwitchBoardInterpreterData interp = new SwitchBoardInterpreterData((SwitchBoardInterpreterData)_interpreterData);
      //if(!interp._onInit)
      //  return;
      //expr_buff = String.Format(wxPorting.T("%s::OnInit(%d,%d)"), _stateProgram, _x, _y);
      //Trace(expr_buff);
      //interp.Execute(interp._onInit);
      //return;
    }

    public void OnClicked() {
      //if(!_interpreterData)
      //  return;

      //SwitchBoardInterpreterData interp = new SwitchBoardInterpreterData((SwitchBoardInterpreterData)_interpreterData);
      //if(!interp._onClick)
      //  return;

      //expr_buff = String.Format(wxPorting.T("%s::OnClicked(%d,%d)"), _stateProgram, _x, _y);
      //Trace(expr_buff);
      //interp.Execute(interp._onClick);
    }


    public void OnFlash() {
#if false
	SwitchBoardAspect *asp;

	if(!_interpreterData)
	    return;
	if(!_currentState)
	    return;

	SwitchBoardInterpreterData interp = new SwitchBoardInterpreterData((SwitchBoardInterpreterData)_interpreterData);
	String *p;

	for(asp = interp._aspects; asp; asp = asp._next)
	    if(!wxStrcmp(_currentState, asp._name)) {
		int	nxt = _nextFlashingIcon + 1;

		if(nxt >= MAX_FLASHING_ICONS)
		    nxt = 0;
		p = asp._icons;
		if(!p || ! p[nxt])
		    nxt = 0;
		_nextFlashingIcon = nxt;
//    		change_coord(this.x, this.y);
		break;
	    }
#endif
    }


    public void SetAspect(String aspect) {
      //if(!_aspect || wxStrcmp(_aspect, aspect)) {
      //  //    	    change_coord(this.x, this.y);
      //  //	    this.aspect_changed = 1;
      //}

      //if(_aspect)
      //  Globals.free(_aspect);
      //_aspect = wxStrdup(aspect);
      ////	_nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }


    public String GetAspect() {
      throw new NotImplementedException();

      //if(_aspect)
      //  return _aspect;
      //return wxPorting.T("blank");
    }

    public String GetAction() {
#if false
	String name = GetAspect();
	SwitchBoardInterpreterData *interp = (SwitchBoardInterpreterData *)_interpreterData;
	SwitchBoardCellAspect *asp;

	if(!interp) {
	    return wxPorting.T("none");
	}
	for(asp = interp._aspects; asp; asp = asp._next) {
	    if(!wxStrcmp(name, asp._name) && asp._action)
		return asp._action;
	}
#endif
      return wxPorting.T("none");
    }

    public bool toHTML(TDString str, String urlBase) {
      throw new NotImplementedException();

      //Itinerary* it = find_itinerary(_itinerary);
      //string buff;

      //if(!it) {
      //  str.Append(wxPorting.T("<td class=\"empty\">"));
      //  str.Append(_text);
      //  str.Append(wxPorting.T("</td>\n"));
      //  return false;
      //}

      //str.Append(wxPorting.T("<td class=\""));
      //if(it.CanSelect())
      //  str.Append(wxPorting.T("available"));
      //else if(it.IsSelected())
      //  str.Append(wxPorting.T("selected"));
      //else
      //  str.Append(wxPorting.T("locked"));
      //str.Append(wxPorting.T("\"><a href=\""));
      //buff = String.Format(wxPorting.L("%s/%d/%d\">"), urlBase, this._x, this._y);
      //str.Append(buff);
      //str.Append(this._text);
      //str.Append(wxPorting.T("</a></td>\n"));
      //return true;
    }


    public int GetNAspects() {
      throw new NotImplementedException();

      //int n = 0;
      //SwitchBoardCellAspect* asp;

      //for(asp = _aspects; asp; asp = asp._next)
      //  ++n;
      //return n;
    }

    public bool GetPropertyValue(String prop, ExprValue result) {
#if false
	bool	res;
	Vector	*path;
	int	i;

	Signal	*s = this;
	wxStrncat(expr_buff, prop, sizeof(expr_buff)-1);

	if(!wxStrcmp(prop, wxPorting.T("aspect"))) {
	    result._op = String;
	    result._txt = s.GetAspect();
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff), wxPorting.T("{%s}"), result._txt);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("auto"))) {
	    result._op = Number;
	    result._val = s.fleeted;
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("enabled"))) {
	    result._op = Number;
	    result._val = s.fleeted && s.nowfleeted;
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
	    return true;
	}

	result._op = Number;
	result._val = 0;
	if(!wxStrcmp(prop, wxPorting.T("switchThrown"))) {
	    res = s.GetNextPath(&path);
	    if(!path)
		return res;

	    for(i = 0; i < path._size; ++i) {
		Track	*trk = path.TrackAt(i);

		if(trk.type != SWITCH)
		    continue;
		switch(trk.direction) {
		case 10:	// these are Y switches, which are always
		case 11:	// considered as going to the main line,
		case 22:	// thus ignored as far as signals are concerned.
		case 23:
		    continue;
		}
		if(trk.switched) {
		    result._val = 1;
		    break;
		}
	    }
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff),
		wxPorting.T("{%s}"), result._val ? wxPorting.T("switchThrown") : wxPorting.T("switchNotThrown"));
	    Vector_delete(path);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("nextLimit"))) {
	    res = s.GetNextPath(&path);
	    if(!path)
		return res;

	    int	    j;
	    int	    lowSpeed = 1000;
	    
	    for(i = 0; i < path._size; ++i) {
		Track	*trk = path.TrackAt(i);

		for(j = 0; j < NTTYPES; ++j)
		    if(trk.speed[j] && trk.speed[j] < lowSpeed)
			lowSpeed = trk.speed[j];
	    }
	    result._val = lowSpeed;
	    Vector_delete(path);
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff), wxPorting.T("{%d}"), lowSpeed);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("nextLength"))) {
	    res = s.GetNextPath(&path);
	    if(!path)
		return res;

	    int	    length = 0;
	    
	    for(i = 0; i < path._size; ++i) {
		Track	*trk = path.TrackAt(i);
		length += trk.length;
	    }
	    result._val = length;
	    Vector_delete(path);
	    wxSnprintf(expr_buff + Globals.wxStrlen(expr_buff),
		sizeof(expr_buff)/sizeof(char) - Globals.wxStrlen(expr_buff), wxPorting.T("{%d}"), length);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("nextApproach"))) {
	    return GetApproach(result);
	}
	if(!wxStrcmp(prop, wxPorting.T("nextIsApproach"))) {
	    res = GetApproach(result);
	    result._op = Number;
	    result._val = res == true;
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("nextStation"))) {
	    result._op = String;
	    result._txt = wxPorting.T("");

	    res = s.GetNextPath(&path);
	    if(!path)
		return res;

	    for(i = 0; i < path._size; ++i) {
		Track	*trk = path.TrackAt(i);

		if(!trk.isstation)
		    continue;
		result._txt = trk.station;
		break;
	    }
	    Vector_delete(path);
	    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%s}"), result._txt);
	    return true;
	}
	if(!wxStrcmp(prop, wxPorting.T("color"))) {
	    result._op = String;
	    result._txt = wxPorting.T("");
	    if(s.controls)
		result._txt = GetColorName(s.controls.fgcolor);
	    return true;
	}
#endif
      return false;
    }


    public bool SetPropertyValue(String prop, ExprValue val) {
#if false
	if(!wxStrcmp(prop, wxPorting.T("aspect"))) {
	    s.SetAspect(val._txt);
	} else if(!wxStrcmp(prop, wxPorting.T("click"))) {
	} else
	    return false;

#endif
      return true;
    }
  }




  public class SwitchBoard {
    public TDString _name;		// name of this SwitchBoard (usually a station) - for display
    public TDString _fname;		// name of description file
    public SwitchBoardCell _cells;
    public int _nCells;
    public SwitchBoardCellAspect _aspects;	// list of aspects (states)
    public SwitchBoard _next;

    public SwitchBoardCellAspect GetAspect(String name) {
      throw new NotImplementedException();

      //int n = 0;
      //SwitchBoardCellAspect* asp;

      //for(asp = _aspects; asp; asp = asp._next) {
      //  if(!wxStrcmp(name, asp._name))
      //    return asp;
      //  ++n;
      //}
      //return 0;
    }

    public SwitchBoard() {
      //_cells = 0;
      //_nCells = 0;
      //_aspects = 0;
    }


    ~SwitchBoard() {
      //while(_aspects) {
      //  SwitchBoardCellAspect* asp = _aspects;
      //  _aspects = asp._next;
      //  Globals.delete(asp);
      //}
      //while(_cells) {
      //  SwitchBoardCell* cell = _cells;
      //  _cells = cell._next;
      //  Globals.delete(cell);
      //}
    }


    public bool Load(String fname) {
      throw new NotImplementedException();

      //String p;
      //string buff;
      //buff = String.Copy(fname);
      //wxStrcat(buff, wxPorting.T(".swb"));
      //Script* s = new Script();
      //s._next = 0;
      //s._path = wxStrdup(buff);
      //s._text = 0;
      //if(!s.ReadFile()) {
      //  Globals.free(s._path);
      //  s._path = 0;
      //  Globals.delete(s);
      //  return false;
      //}

      //_fname = fname;

      //p = s._text;
      //while(*p) {
      //  String p1 = p;
      //  while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
      //    ++p1;
      //  p = p1;
      //  if(match(&p, wxPorting.T("Aspect:"))) {
      //    p1 = p;
      //    ParseAspect(&p);
      //  } else if(match(&p, wxPorting.T("Cell:"))) {
      //    p1 = p + 5;
      //    ParseCell(&p);
      //  } else if(match(&p, wxPorting.T("Name:"))) {
      //    while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //    p1 = p;
      //    if(*p) {
      //      int i = 0;
      //      while(*p && *p != '\r' && *p != '\n')
      //        buff[i++] = *p.incPointer();
      //      buff[i] = 0;
      //      this._name = buff;
      //      if(!*p.incPointer())
      //        break;
      //    }
      //  }
      //  if(p1 == p)	    // error! couldn't parse token
      //    break;
      //}
      //Globals.free(s._path);
      //s._path = 0;
      //Globals.delete(s);
      //return true;
    }


    public bool toHTML(TDString str, String urlBase) {
      throw new NotImplementedException();

      //int xMax = 0;
      //int yMax = 0;
      //int x, y;
      //SwitchBoardCell cell;
      //SwitchBoardCell[][] grid = new SwitchBoardCell[Configuration.MAX_SWBD_X];

      //for(int tmpX = 0; tmpX < grid.Length; x++) {
      //  grid[x] = new SwitchBoardCell[Configuration.MAX_SWBD_Y];
      //}

      //memset(grid, 0, sizeof(grid));
      //for(cell = _cells; cell; cell = cell._next) {
      //  if(cell._x < MAX_SWBD_X && cell._y < MAX_SWBD_Y) {
      //    grid[cell._x][cell._y] = cell;
      //    if(cell._x + 1 > xMax)
      //      xMax = cell._x + 1;
      //    if(cell._y + 1 > yMax)
      //      yMax = cell._y + 1;
      //  }
      //}
      //if(!xMax || !yMax)
      //  return false;

      //curSwitchBoard = this;	    // TODO: remove
      //++xMax;
      //++yMax;
      //str.Append(wxPorting.T("<table class=\"switchboard\">\n"));
      //for(y = 0; y < yMax; ++y) {
      //  str.Append(wxPorting.T("<tr>\n"));
      //  for(x = 0; x < xMax; ++x) {
      //    cell = grid[x][y];
      //    if(!cell)
      //      str.Append(wxPorting.T("<td class=\"empty\">&nbsp;</td>\n"));
      //    else
      //      cell.toHTML(str, urlBase);
      //  }
      //  str.Append(wxPorting.T("</tr>\n"));
      //}
      //str.Append(wxPorting.T("</table>\n"));
      //return true;
    }



    public SwitchBoardCell Find(int x, int y) {
      throw new NotImplementedException();

      //SwitchBoardCell* cell;

      //for(cell = _cells; cell; cell = cell._next)
      //  if(cell._x == x && cell._y == y)
      //    return cell;
      //return 0;
    }


    public void Add(SwitchBoardCell cell) {
      //SwitchBoardCell* c;

      //// make sure it's not already there,
      //// to prevend loops in the list
      //for(c = _cells; c; c = c._next)
      //  if(c == cell)
      //    return;
      //cell._next = _cells;
      //_cells = cell;
    }


    public void Remove(SwitchBoardCell cell) {
      //SwitchBoardCell c, old = null;

      //for(c = _cells; c && c != cell; old = c, c = c._next) ;
      //if(!c)		    // not in list - impossible
      //  return;
      //if(old)
      //  old._next = cell._next;
      //else
      //  _cells = cell._next;
      //cell._next = 0;
    }


    public bool Select(int x, int y) {
      throw new NotImplementedException();

      //SwitchBoardCell* cell = Find(x, y);

      //if(!cell)
      //  return false;
      //Itinerary* it = find_itinerary(cell._itinerary);
      //if(!it)
      //  return false;
      //if(it.CanSelect())
      //  it.Select();
      //else if(it.IsSelected())
      //  it.Deselect(false);
      //return true;
    }


    public bool Select(String itinName) {
      throw new NotImplementedException();

      //SwitchBoardCell* cell;

      //for(cell = _cells; cell; cell = cell._next)
      //  if(cell._text.CompareTo(itinName) == 0)
      //    break;
      //if(!cell)
      //  return false;

      //Itinerary* it = find_itinerary(cell._itinerary);
      //if(!it)
      //  return false;
      //if(it.CanSelect())
      //  it.Select();
      //else if(it.IsSelected())
      //  it.Deselect(false);
      //return true;
    }



    public void Change(int x, int y, String name, String itinName) {
      throw new NotImplementedException();

      //SwitchBoardCell* cell = Find(x, y);

      //if(!cell) {
      //  cell = new SwitchBoardCell();
      //  cell._x = x;
      //  cell._y = y;
      //}
      //cell._text = name;
      //cell._itinerary = itinName;
    }
  }


  //
  //
  //
  //



  public static partial class Globals {
    public static SwitchBoard switchBoards;
    public static SwitchBoard curSwitchBoard;	    // TODO: move to a SwitchBoardCell field

    public static void ParseAspect(String pp) {
      //  string line;
      //  String p = pp;
      //  String dst;
      //  SwitchBoardCellAspect asp = new SwitchBoardCellAspect();

      //  p = scan_line(p, line);
      //  if(line[0] != 0)
      //      asp._name = wxStrdup(line);
      //  do {
      //      dst = null;
      //      if(match(&p, wxPorting.T("Icons:")))
      //    dst = &asp._icons[0];
      //      if(dst) {
      //    p = scan_line(p, line);
      //    if(line[0]) {
      //        if(wxStrchr(line, ' ')) {
      ////			this._isFlashing = true;
      //      int	nxt = 0;
      //      String p1, pp;

      //      pp = line;
      //      do {
      //          for(p1 = pp; *pp && *pp != ' '; ++pp);
      //          if(p1 != pp) {
      //        int oc = *pp;
      //        *pp = 0;
      //        *dst++ = wxStrdup(p1);
      //        *pp = oc;
      //        while(*pp == ' ') ++pp;
      //        if(++nxt >= MAX_FLASHING_ICONS)
      //            break;
      //          }
      //      } while(*pp);
      //        } else
      //      *dst = wxStrdup(line);
      //    }
      //    continue;
      //      }
      //      if(match(&p, wxPorting.T("Action:"))) {
      //    p = scan_line(p, line);
      //    if(!line[0])
      //        continue;
      //    if(asp._action)
      //        Globals.free(asp._action);
      //    asp._action = wxStrdup(line);
      //    continue;
      //      }
      //      if(match(&p, wxPorting.T("Bgcolor:"))) {
      //    p = scan_line(p, line);
      //    if(!line[0])
      //        continue;
      //    if(asp._bgcolor)
      //        Globals.free(asp._bgcolor);
      //    asp._bgcolor = wxStrdup(line);
      //    continue;
      //      }
      //      break;
      //      // unknown. Should we give an error?
      //  } while(1);
      //  asp._next = _aspects;
      //  _aspects = asp;
      //  *pp = p;
    }


    //	Cell: x, y
    //	    Itinerary:	name
    //	    Text:	string


    public static void ParseCell(String pp) {
      //string line;
      //String p1;
      //Stringp = *pp;
      //Stringp2;
      //SwitchBoardCell* cell = 0;

      //p = scan_line(p, line);
      //int x = wxStrtol(line, &p1, 10);
      //if(*p1 == wxPorting.T(',')) ++p1;
      //int y = wxStrtol(p1, &p1, 10);
      //cell = new SwitchBoardCell();
      //cell._x = x;
      //cell._y = y;

      //do {
      //  p2 = p;
      //  p = scan_line(p, line);
      //  p1 = line;
      //  if(match((String*)&p1, wxPorting.T("Itinerary:"))) {
      //    cell._itinerary = p1;
      //    continue;
      //  }
      //  if(match((String*)&p1, wxPorting.T("Text:"))) {
      //    cell._text = p1;
      //    continue;
      //  }
      //  p = p2;
      //  break;
      //} while(*p);
      //Add(cell);
      //*pp = p;
    }


    public static void SwitchboardEditCommand(String cmd) {
      //SwitchBoard sb;
      //string buff;
      //int	i;

      //while(*cmd == wxPorting.T(' '))
      //    ++cmd;
      //if(!*cmd) {
      //    switchboard_name_dialog(0);
      //    ShowSwitchboard();
      //    return;
      //}
      //if(*cmd == wxPorting.T('-') && cmd[1] == wxPorting.T('a')) {
      //    cmd += 2;
      //    while(*cmd == wxPorting.T(' '))
      //  ++cmd;
      //    for(i = 0; i < MAX_NAME_LEN - 1 && *cmd && *cmd != wxPorting.T(' '); ++i)
      //  buff[i] = *cmd++;
      //    buff[i] = 0;
      //    sb = FindSwitchBoard(buff);
      //    if(!sb)
      //  curSwitchBoard = CreateSwitchBoard(buff);
      //    else
      //  curSwitchBoard = sb;
      //    while(*cmd == wxPorting.T(' '))
      //  ++cmd;
      //          if(*cmd)
      //        curSwitchBoard._name = cmd;
      //    ShowSwitchboard();
      //    return;
      //}
      //if(*cmd == wxPorting.T('-') && cmd[1] == wxPorting.T('e')) {
      //    cmd += 2;
      //    while(*cmd == wxPorting.T(' '))
      //  ++cmd;
      //    sb = FindSwitchBoard(cmd);
      //    if(!sb)		// not there - nothing to do
      //  return;
      //    curSwitchBoard = sb;
      //    switchboard_name_dialog(cmd);
      //    ShowSwitchboard();
      //    return;
      //}
      //if(*cmd == wxPorting.T('-') && cmd[1] == wxPorting.T('d')) {
      //    cmd += 2;
      //    while(*cmd == wxPorting.T(' '))
      //  ++cmd;
      //    sb = FindSwitchBoard(cmd);
      //    if(!sb)		// not there - nothing to do
      //  return;
      //    RemoveSwitchBoard(sb);
      //    curSwitchBoard = switchBoards;
      //    ShowSwitchboard();
      //    return;
      //}
      //sb = FindSwitchBoard(cmd);
      //if(!sb)		// not there - nothing to do
      //    return;
      //curSwitchBoard = sb;
      //ShowSwitchboard();
    }

    public static void SwitchboardCellCommand(String cmd) {
      //SwitchBoard* sb = curSwitchBoard;
      //int x, y;

      //if(!sb)			// impossible
      //  return;

      //Stringp;

      //while(*cmd == wxPorting.T(' '))
      //  ++cmd;
      //x = wxStrtol(cmd, &p, 10);
      //if(p[0] == wxPorting.T(','))
      //  p.incPointer();
      //y = wxStrtol(p, &p, 10);
      //while(p[0] == wxPorting.T(' '))
      //  p.incPointer();
      //if(!*p) {
      //  switchboard_cell_dialog(x, y);
      //  ShowSwitchboard();
      //  return;
      //}
      //// label, itinName
    }


    public static SwitchBoard FindSwitchBoard(String name) {
      throw new NotImplementedException();
      //SwitchBoard* sb;

      //for(sb = switchBoards; sb; sb = sb._next) {
      //  if(!wxStrcmp(name, sb._fname))
      //    return sb;
      //}
      //return 0;
    }


    public static SwitchBoard CreateSwitchBoard(String name) {
      throw new NotImplementedException();
      //SwitchBoard* sb = FindSwitchBoard(name);
      //RemoveSwitchBoard(sb);
      //sb = new SwitchBoard();
      //sb._name = name;
      //sb._fname = name;
      //sb._next = switchBoards;
      //switchBoards = sb;
      //return sb;
    }


    public static void RemoveSwitchBoard(SwitchBoard sb) {
      //SwitchBoard* old = 0;
      //SwitchBoard* s;

      //for(s = switchBoards; s && s != sb; s = s._next)
      //  old = s;
      //if(s) {
      //  if(!old)
      //    switchBoards = s._next;
      //  else
      //    old._next = s._next;
      //}
      //if(sb)
      //  Globals.delete(sb);
    }


    public static void RemoveAllSwitchBoards() {
      //SwitchBoard* sb;

      //while(switchBoards) {
      //  sb = switchBoards;
      //  switchBoards = sb._next;
      //  Globals.delete(sb);
      //}
    }


    public static void SaveSwitchBoards(wxFFile file) {
      //SwitchBoard *sb;

      //for(sb = switchBoards; sb; sb = sb._next) {
      //    file.Write(String.Format(wxPorting.T("(switchboard %s)\n"), sb._fname));
      //    wxFFile file;
      //    if(!file_create(sb._fname, wxPorting.T(".swb"), file))
      //  break;
      //    SwitchBoardCellAspect *asp;
      //    for(asp = sb._aspects; asp; asp = asp._next) {
      //  file.Write(String.Format(wxPorting.T("Aspect: %s\n"), asp._name));
      //  file.Write(String.Format(wxPorting.T("Bgcolor: %s\n\n"), asp._bgcolor));
      //    }
      //    SwitchBoardCell *cell;
      //          file.Write(String.Format(wxPorting.T("Name: %s\n"), sb._name));
      //    for(cell = sb._cells; cell; cell = cell._next) {
      //  file.Write(String.Format(wxPorting.T("Cell: %d,%d\n"), cell._x, cell._y));
      //  file.Write(String.Format(wxPorting.T("Itinerary: %s\n"), cell._itinerary));
      //  file.Write(String.Format(wxPorting.T("Text: %s\n\n"), cell._text));
      //    }
      //    file.Close();
      //}
    }

  }
}