using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  partial class Globals {

    public static SwitchBoard FindSwitchBoard(String name) {
      SwitchBoard sb;

      if(string.IsNullOrEmpty(name))
        return null;

      for(sb = switchBoards; sb != null; sb = sb._next) {
        if(name.Equals(sb._fname))
          return sb;
      }

      return null;
    }



    public static void RemoveSwitchBoard(SwitchBoard sb) {
      SwitchBoard old = null;
      SwitchBoard s;

      if((sb == null) || (switchBoards == null))
        return;

      for(s = switchBoards; s != null && s != sb; s = s._next)
        old = s;
      if(s != null) {
        if(old == null)
          switchBoards = s._next;
        else
          old._next = s._next;
      }
    }

    public static SwitchBoard CreateSwitchBoard(String name) {
      SwitchBoard sb = FindSwitchBoard(name);
      RemoveSwitchBoard(sb);
      sb = new SwitchBoard();
      sb._name = name;
      sb._fname = name;
      sb._next = switchBoards;
      switchBoards = sb;
      return sb;
    }
  }

  public class SwitchBoard {
    public TDString _name;		// name of this SwitchBoard (usually a station) - for display
    public TDString _fname;		// name of description file
    //public SwitchBoardCell _cells;
    //public int _nCells;
    //public SwitchBoardCellAspect _aspects;	// list of aspects (states)
    public SwitchBoard _next;

    //public SwitchBoardCellAspect GetAspect(String name) {
    //  throw new NotImplementedException();

    //  //int n = 0;
    //  //SwitchBoardCellAspect* asp;

    //  //for(asp = _aspects; asp; asp = asp._next) {
    //  //  if(!wxStrcmp(name, asp._name))
    //  //    return asp;
    //  //  ++n;
    //  //}
    //  //return 0;
    //}

    //public SwitchBoard() {
    //  //_cells = 0;
    //  //_nCells = 0;
    //  //_aspects = 0;
    //}


    //~SwitchBoard() {
    //  //while(_aspects) {
    //  //  SwitchBoardCellAspect* asp = _aspects;
    //  //  _aspects = asp._next;
    //  //  Globals.delete(asp);
    //  //}
    //  //while(_cells) {
    //  //  SwitchBoardCell* cell = _cells;
    //  //  _cells = cell._next;
    //  //  Globals.delete(cell);
    //  //}
    //}


    // TODO Implement this function
    public bool Load(String fname) {
      return true;
      throw new NotImplementedException();

      //String p;
      //string buff;
      //buff = fname + wxPorting.T(".swb");
      //Script s = new Script();
      //s._next = null;
      //s._path = String.Copy(buff);
      //s._text = null;
      //if(!s.ReadFile()) {
      //  return false;
      //}

      //_fname = fname;

      //p = s._text;
      //while(String.IsNullOrEmpty(p) == false) {
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


    //public bool toHTML(TDString str, String urlBase) {
    //  throw new NotImplementedException();

    //  //int xMax = 0;
    //  //int yMax = 0;
    //  //int x, y;
    //  //SwitchBoardCell cell;
    //  //SwitchBoardCell[][] grid = new SwitchBoardCell[Configuration.MAX_SWBD_X];

    //  //for(int tmpX = 0; tmpX < grid.Length; x++) {
    //  //  grid[x] = new SwitchBoardCell[Configuration.MAX_SWBD_Y];
    //  //}

    //  //memset(grid, 0, sizeof(grid));
    //  //for(cell = _cells; cell; cell = cell._next) {
    //  //  if(cell._x < MAX_SWBD_X && cell._y < MAX_SWBD_Y) {
    //  //    grid[cell._x][cell._y] = cell;
    //  //    if(cell._x + 1 > xMax)
    //  //      xMax = cell._x + 1;
    //  //    if(cell._y + 1 > yMax)
    //  //      yMax = cell._y + 1;
    //  //  }
    //  //}
    //  //if(!xMax || !yMax)
    //  //  return false;

    //  //curSwitchBoard = this;	    // TODO: remove
    //  //++xMax;
    //  //++yMax;
    //  //str.Append(wxPorting.T("<table class=\"switchboard\">\n"));
    //  //for(y = 0; y < yMax; ++y) {
    //  //  str.Append(wxPorting.T("<tr>\n"));
    //  //  for(x = 0; x < xMax; ++x) {
    //  //    cell = grid[x][y];
    //  //    if(!cell)
    //  //      str.Append(wxPorting.T("<td class=\"empty\">&nbsp;</td>\n"));
    //  //    else
    //  //      cell.toHTML(str, urlBase);
    //  //  }
    //  //  str.Append(wxPorting.T("</tr>\n"));
    //  //}
    //  //str.Append(wxPorting.T("</table>\n"));
    //  //return true;
    //}



    //public SwitchBoardCell Find(int x, int y) {
    //  throw new NotImplementedException();

    //  //SwitchBoardCell* cell;

    //  //for(cell = _cells; cell; cell = cell._next)
    //  //  if(cell._x == x && cell._y == y)
    //  //    return cell;
    //  //return 0;
    //}


    //public void Add(SwitchBoardCell cell) {
    //  //SwitchBoardCell* c;

    //  //// make sure it's not already there,
    //  //// to prevend loops in the list
    //  //for(c = _cells; c; c = c._next)
    //  //  if(c == cell)
    //  //    return;
    //  //cell._next = _cells;
    //  //_cells = cell;
    //}


    //public void Remove(SwitchBoardCell cell) {
    //  //SwitchBoardCell c, old = null;

    //  //for(c = _cells; c && c != cell; old = c, c = c._next) ;
    //  //if(!c)		    // not in list - impossible
    //  //  return;
    //  //if(old)
    //  //  old._next = cell._next;
    //  //else
    //  //  _cells = cell._next;
    //  //cell._next = 0;
    //}


    //public bool Select(int x, int y) {
    //  throw new NotImplementedException();

    //  //SwitchBoardCell* cell = Find(x, y);

    //  //if(!cell)
    //  //  return false;
    //  //Itinerary* it = find_itinerary(cell._itinerary);
    //  //if(!it)
    //  //  return false;
    //  //if(it.CanSelect())
    //  //  it.Select();
    //  //else if(it.IsSelected())
    //  //  it.Deselect(false);
    //  //return true;
    //}


    //public bool Select(String itinName) {
    //  throw new NotImplementedException();

    //  //SwitchBoardCell* cell;

    //  //for(cell = _cells; cell; cell = cell._next)
    //  //  if(cell._text.CompareTo(itinName) == 0)
    //  //    break;
    //  //if(!cell)
    //  //  return false;

    //  //Itinerary* it = find_itinerary(cell._itinerary);
    //  //if(!it)
    //  //  return false;
    //  //if(it.CanSelect())
    //  //  it.Select();
    //  //else if(it.IsSelected())
    //  //  it.Deselect(false);
    //  //return true;
    //}



    //public void Change(int x, int y, String name, String itinName) {
    //  throw new NotImplementedException();

    //  //SwitchBoardCell* cell = Find(x, y);

    //  //if(!cell) {
    //  //  cell = new SwitchBoardCell();
    //  //  cell._x = x;
    //  //  cell._y = y;
    //  //}
    //  //cell._text = name;
    //  //cell._itinerary = itinName;
    //}
  }

}
