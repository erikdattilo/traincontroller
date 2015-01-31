using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class SwitchBoard {
    public string _name;		// name of this SwitchBoard (usually a station) - for display
    public string _fname;		// name of description file
    public SwitchBoardCell _cells;
    public int _nCells;
    public SwitchBoardCellAspect _aspects;	// list of aspects (states)
    public SwitchBoard _next;

    public bool Load(string fname) {
      int i;
      string p;
      string buff;

      buff = string.Copy(fname) + wxPorting.T(".swb");
      Script s = new Script();
      s._next = null;
      s._path = string.Copy(buff);
      s._text = null;
      if(!s.ReadFile()) {
        // free(s._path);
        s._path = null;
        // delete s;
        return false;
      }

      _fname = fname;

      p = s._text;
      while(p.Length > 0) {
        string p1 = string.Copy(p);
        for(i = 0; (p1[i] == ' ' || p1[i] == '\t' || p1[i] == '\r' || p1[i] == '\n'); i++)
          ;
        p1 = p1.Substring(i);

        p = string.Copy(p1);

        if(p.Equals(wxPorting.T("Aspect:"))) {
          p1 = string.Copy(p);
          ParseAspect(p);
        } else if(p.Equals(wxPorting.T("Cell:"))) {
          p1 = string.Copy(p.Substring(5));
          ParseCell(p);
        } else if(p.Equals(wxPorting.T("Name:"))) {
          for(i = 0; (p[i] == ' ' || p[i] == '\t'); i++)
            ;
          p = p.Substring(i);
          p1 = string.Copy(p);

          if(p.Length > 0) {
            for(i = 0; (i < p.Length && p[i] != '\r' && p[i] != '\n'); i++)
              ;
            buff = p.Substring(0, i);
            p = p.Substring(i);
            this._name = buff;
            if(p.Length == 0) {
              break;
            }
            p = p.Substring(1);
          }
        }
        if(p1.Equals(p))	    // error! couldn't parse token
          break;
      }
      // free(s._path);
      s._path = null;
      //delete s;
      return true;
    }

    void ParseAspect(string pp) {
      string line = "";
      string p = pp;
      string dst;
      SwitchBoardCellAspect asp = new SwitchBoardCellAspect();

      p = GlobalFunctions.scan_line(p, out line);
      if(line.Length > 0)
        asp._name = string.Copy(line);

      do {
        dst = null;
        if(p.Equals(wxPorting.T("Icons:")))
          dst = asp._icons[0];

        if(dst != null) {
          p = GlobalFunctions.scan_line(p, out line);
          if(line.Length > 0) {
            if(line.IndexOf(' ') >= 0) {
              int nxt = 0;
              string p1; //, pp;

              pp = string.Copy(line);
              do {
                for(p1 = pp; pp.Length > 0 && pp[0] != ' '; pp = pp.Substring(1)) ;

                if(p1.Equals(pp) == false) {
                  int oc = pp[0];
                  pp = "";
                  dst += string.Copy(p1);
                  dst = dst.Substring(1);
                  pp = ((char)oc).ToString();
                  while(pp[0] == ' ') pp = pp.Substring(1);
                  if(++nxt >= Configuration.MAX_FLASHING_ICONS)
                    break;
                }
              } while(pp.Length > 0);
            } else
              dst = string.Copy(line);
          }
          continue;
        }

        if(p.Equals(wxPorting.T("Action:"))) {
          p = GlobalFunctions.scan_line(p, out line);
          if(line == null)
            continue;
          // if(string.IsNullOrEmpty(asp._action) == false)
          //   free(asp._action);
          asp._action = string.Copy(line);
          continue;
        }
        if(p.Equals(wxPorting.T("Bgcolor:"))) {
          p = GlobalFunctions.scan_line(p, out line);
          if(line == null)
            continue;
          // if(asp._bgcolor)
          //   free(asp._bgcolor);
          asp._bgcolor = string.Copy(line);
          continue;
        }
        break;
        // unknown. Should we give an error?
      } while(true);
      asp._next = _aspects;
      _aspects = asp;
      pp = string.Copy(p);
    }


//	Cell: x, y
//	    Itinerary:	name
//	    Text:	string


    void ParseCell(string pp) {
      int i;
      string line;
      string p1;
      string p = pp;
      string p2;
      SwitchBoardCell cell = null;

      p = GlobalFunctions.scan_line(p, out line);
      int x = wxPorting.Strtol(line, out i, 10);
      p1 = line.Substring(1);
      if(p1[0] == wxPorting.T(',')) p1 = p1.Substring(1);
      int y = wxPorting.Strtol(p1, out i, 10);
      p1 = line.Substring(1);
      cell = new SwitchBoardCell();
      cell._x = x;
      cell._y = y;

      do {
        p2 = p;
        p = GlobalFunctions.scan_line(p, out line);
        p1 = string.Copy(line);
        if(p1.Equals(wxPorting.T("Itinerary:"))) {
          cell._itinerary = p1;
          continue;
        }
        if(p1.Equals(wxPorting.T("Text:"))) {
          cell._text = p1;
          continue;
        }
        p = p2;
        break;
      } while(p.Length > 0);
      Add(cell);
      pp = string.Copy(p);
    }

    void Add(SwitchBoardCell cell) {
      SwitchBoardCell c;

      // make sure it's not already there,
      // to prevend loops in the list
      for(c = _cells; c != null; c = c._next)
        if(c == cell)
          return;
      cell._next = _cells;
      _cells = cell;
    }

  }
}