/*	Itinerary.cpp - Created by Giampiero Caprino

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


  public class switin {
    public int x, y;		/* coordinate of the switch */
    public bool switched;	/* whether to automatically throw the switch */
    public bool oldsw;		/* old status */
  }

  public class Itinerary {

    public Itinerary next;
    public bool visited;	/* flag to avoid endless loop */
    public String name;		/* name of itinerary */
    public String signame;	/* name of start signal */
    public String endsig;	/* name of end signal */
    public String nextitin;	/* next itinerary automatically activated */
    public int nsects, maxsects;/* sections are signal-to-signal */
    public switin[] sw;

    public String _iconSelected;
    public String _iconDeselected;
    public object _interpreterData;

    public bool GetPropertyValue(String prop, ExprValue result) {
      throw new NotImplementedException();
      //if(wxStrcmp(prop, wxPorting.T("name")) == 0) {
      //  result._op = NodeOp.String;
      //  result._txt = this.name;
      //  return true;
      //}
      //return false;
    }


    public void OnInit() {
      if(_interpreterData != null) {
        ItinInterpreterData interp = (ItinInterpreterData)_interpreterData;
        if(interp._onInit != null) {
          interp._itinerary = this;
          Globals.expr_buff = String.Format( wxPorting.T("Itinerary::OnInit(%s)"), this.name);
          Globals.Trace(Globals.expr_buff);
          interp.Execute(interp._onInit);
          return;
        }
      }
    }

    public void OnClick() {
      if(_interpreterData != null) {
        ItinInterpreterData interp = (ItinInterpreterData)_interpreterData;
        if(interp._onClick != null) {
          interp._itinerary = this;
          Globals.expr_buff = String.Format( wxPorting.T("Itinerary::OnClick(%s)"), this.name);
          Globals.Trace(Globals.expr_buff);
          interp.Execute(interp._onClick);
          return;
        }
      }
    }


    public bool TurnSwitches() {
      int el;
      Track trk;

      // turn every switch
      for(el = 0; el < nsects; ++el) {
        trk = Globals.findSwitch(sw[el].x, sw[el].y);
        if(trk == null)
          return false;
        sw[el].oldsw = trk.switched;
        trk.switched = sw[el].switched;
      }
      return true;
    }

    public void RestoreSwitches() {
      //int el;
      //Track trk;

      //// turn every switch
      //for(el = 0; el < nsects; ++el) {
      //  trk = findSwitch(sw[el].x, sw[el].y);
      //  if(trk == null)
      //    break;
      //  trk.switched = sw[el].oldsw;
      //}
    }
    public bool Select() {
      throw new NotImplementedException();
    //  Itinerary it = this;
    //  Track t1;
    //  int i;
    //  String nextitin;

    //  if(!Globals.check_itinerary(it))
    //    return false;
    //  Globals.toggle_itinerary(it);
    //  if(Globals.green_itinerary(it))
    //    return true;		/* success */

    //  /* error - restore switches status */
    //err:
    //  for(i = 0; i < it.nsects; ++i) {
    //    t1 = findSwitch(it.sw[i].x, it.sw[i].y);
    //    if(t1 == null)
    //      continue;
    //    if(it.sw[i].switched == it.sw[i].oldsw)
    //      continue;
    //    t1.switched = !t1.switched;
    //    Globals.change_coord(t1.x, t1.y);
    //    if((t1 = findSwitch(t1.wlinkx, t1.wlinky)) != null) {
    //      t1.switched = !t1.switched;
    //      Globals.change_coord(t1.x, t1.y);
    //    }
    //  }
    //  if(((nextitin = it.nextitin) == null) || nextitin.Length == 0)
    //    return false;
    //  for(it = itineraries; it != null; it = it.next)
    //    if(Globals.wxStrcmp(it.name, nextitin) == 0)
    //      break;
    //  if(it != null)
    //    goto err;
    //  return true;
    }


    public bool IsSelected() {
      return Deselect(true);
    }


    public bool CanSelect() {
      Signal sig;
      int el;
      Track trk;

      sig = Globals.findSignalNamed(signame);
      if(sig == null)
        return false;

      Vector path;

      if(sig.controls == null)
        return false;
      if(sig.IsClear())
        return false;

      TurnSwitches();
      path = Globals.findPath(sig.controls, sig.direction);
      if(path == null) {
        RestoreSwitches();
        return false;
      }
      int nel = path._size;
      bool failed = false;
      // check that every element in the path is clear
      for(el = 0; el < nel; ++el) {
        trk = path.TrackAt(el);
        if(trk.fgcolor != Globals.conf.fgcolor) {
          failed = true;
          break;
        }
      }
      Globals.Vector_delete(path);
      RestoreSwitches();
      return !failed;
    }


    public bool Deselect(bool checkOnly) {
      throw new NotImplementedException();
      //Signal sig;

      //sig = Globals.findSignalNamed(signame);
      //if(sig == null)
      //  return false;

      //Vector path;

      //if(sig.controls == null)
      //  return false;
      //if(!sig.IsClear())	// maybe a train entered the block or the
      //  return false;	// path is occupied in the opposite direction

      //path = findPath(sig.controls, sig.direction);
      //if(path == null)
      //  return false;
      //int nel = path._size;
      //int el;
      //Track trk;
      //bool failed = false;
      //// check that every element in the path is still clear
      //for(el = 0; el < nel; ++el) {
      //  trk = path.TrackAt(el);
      //  if(trk.fgcolor != color_green) {
      //    failed = true;
      //    break;
      //  }
      //}
      //if(!failed) {
      //  // check that every switch is in the right position
      //  for(el = 0; el < nsects; ++el) {
      //    trk = findSwitch(sw[el].x, sw[el].y);
      //    if(trk == null) {
      //      failed = true;
      //      break;
      //    }
      //    if(trk.switched != sw[el].switched) {
      //      failed = true;
      //      break;
      //    }
      //  }
      //}
      //if(!failed) {
      //  if(!checkOnly)		// OK to undo the itinerary
      //    toggle_signal(sig);
      //}

      //Globals.Vector_delete(path);
      //return !failed;
    }



  }


  public partial class Globals {
    public static Itinerary itineraries;

    public static Itinerary find_itinerary(String name) {
      Itinerary it;

      for(it = itineraries; it != null; it = it.next)
        if(Globals.wxStrcmp(it.name, name) == 0)
          return it;
      return null;
    }

    public static void clear_visited() {
      Itinerary ip;

      for(ip = itineraries; ip != null; ip = ip.next)
        ip.visited = false;
    }

    public static void delete_itinerary(Itinerary ip) {
      Itinerary it, oit;

      oit = null;
      for(it = itineraries; it != null && ip != it; it = it.next)
        oit = it;
      if(it == null)
        return;
      if(oit == null)
        itineraries = it.next;
      else
        oit.next = it.next;
      free_itinerary(it);
    }

    public static void delete_itinerary(String name) {
      Itinerary it, oit;

      oit = null;
      for(it = itineraries; it != null && Globals.wxStrcmp(it.name, name) != 0; it = it.next)
        oit = it;
      if(it == null)
        return;
      if(oit == null)
        itineraries = it.next;
      else
        oit.next = it.next;
      free_itinerary(it);
    }

    public static void free_itinerary(Itinerary it) {
      if(String.IsNullOrEmpty(it.signame) == false)
        Globals.free(it.signame);
      if(String.IsNullOrEmpty(it.endsig) == false)
        Globals.free(it.endsig);
      if(String.IsNullOrEmpty(it.name) == false)
        Globals.free(it.name);
      if(it.sw != null)
        Globals.free(it.sw);
      Globals.free(it);
    }

    public static void add_itinerary(Itinerary it, int x, int y, bool sw) {
      int i;

      for(i = 0; i < it.nsects; ++i)
        if(it.sw[i].x == x && it.sw[i].y == y) {
          it.sw[i].switched = sw;
          return;
        }
      if(it.nsects >= it.maxsects) {
        it.maxsects += 10;
        if(it.sw == null) {
          it.sw = new switin[it.maxsects];
        } else {
          it.sw = Globals.realloc(it.sw, it.maxsects);
        }
      }
      it.sw[it.nsects].x = x;
      it.sw[it.nsects].y = y;
      it.sw[it.nsects].switched = sw;
      ++it.nsects;
    }

    private static T[] realloc<T>(T[] switin, int p) {
      throw new NotImplementedException();
    }


    public static int check_itinerary(Itinerary it) {
      String nextitin;
      Track t1;
      int i;

      clear_visited();
    agn:
      if(it == null || it.visited)
        return 0;
      for(i = 0; i < it.nsects; ++i) {
        t1 = findSwitch(it.sw[i].x, it.sw[i].y);
        if(t1 == null || t1.fgcolor == color_green)
          return 0;
        it.sw[i].oldsw = t1.switched;
        if(it.sw[i].switched != t1.switched)
          if((t1 = findSwitch(t1.wlinkx, t1.wlinky)) != null)
            if(t1.fgcolor == color_green)
              return 0;
      }
      if((nextitin = it.nextitin) == null || nextitin.Length == 0)
        return 1;
      it.visited = true;
      for(it = itineraries; it != null; it = it.next)
        if(Globals.wxStrcmp(it.name, nextitin) == 0)
          break;
      goto agn;
    }

    public static void toggle_itinerary(Itinerary it) {
      Track t1;
      int i;
      String nextitin;

      do {
        for(i = 0; i < it.nsects; ++i) {
          t1 = findSwitch(it.sw[i].x, it.sw[i].y);
          if(it.sw[i].switched != t1.switched) {
            t1.switched = !t1.switched;
            change_coord(t1.x, t1.y);
            if((t1 = findSwitch(t1.wlinkx, t1.wlinky)) != null) {
              t1.switched = !t1.switched;
              change_coord(t1.x, t1.y);
            }
          }
        }
        if(((nextitin = it.nextitin) != null) || (nextitin.Length == 0))
          return;
        for(it = itineraries; it != null; it = it.next)
          if(Globals.wxStrcmp(it.name, nextitin) == 0)
            break;
      } while(it != null);			/* always true */
    }

    public static int green_itinerary(Itinerary it) {
      Signal t1;
      Itinerary ip;
      String nextitin;
      int i;
      Signal[] blocks = new Signal[100];
      int nxtblk;

      nxtblk = 0;
      for(ip = it; ip != null; ) {
        if((t1 = findSignalNamed(ip.signame)) != null)
          return 0;
        if(t1.status == trkstat.ST_GREEN)
          return 0;
        blocks[nxtblk++] = t1;
        if(((nextitin = ip.nextitin) == null) || (nextitin.Length == 0))
          break;			/* done */
        for(ip = itineraries; ip != null; ip = ip.next)
          if(Globals.wxStrcmp(ip.name, nextitin) == 0)
            break;
      }

      /* all signals are red, try to turn them green */

      for(i = 0; i < nxtblk; ++i)
        if(toggle_signal(blocks[i]))
          break;			/* line block is busy */

      if(i >= nxtblk)			/* success! */
        return 1;
      while(--i >= 0)			/* undo signal toggling */
        toggle_signal(blocks[i]);
      return 0;
    }

    public static void itinerary_selected(Itinerary it) {
      it.Select();
    }

    public static void itinerary_selected(Track t) {
      int namelen;
      Itinerary it;

      if(t.station.Length > 0 && t.station[0] == '@') {	    // use script
        t.OnClicked();
        return;
      }
      int nameend = t.station.IndexOf('@');

      if(nameend > 0)
        namelen = nameend;
      else
        namelen = Globals.wxStrlen(t.station);
      for(it = itineraries; it != null; it = it.next) {
        if((Globals.wxStrncmp(it.name, t.station, namelen) == 0)&&
        (Globals.wxStrlen(it.name) == namelen))
          break;
      }
      if(it != null)
        itinerary_selected(it);
      if(enable_training) {
        puzzle_check(t);
      }
    }


    public static void try_itinerary(int sx, int sy, int ex, int ey) {
      Itinerary it = null;
      Signal t1, t2;

      t1 = findSignal(sx, sy);
      t2 = findSignal(ex, ey);
      if(t1 == null || t2 == null)
        return;
      if(String.IsNullOrEmpty(t1.station) == false && String.IsNullOrEmpty(t2.station) == false) {
        for(it = itineraries; it != null; it = it.next)
          if((Globals.wxStrcmp(it.signame, t1.station) == 0) &&
            (Globals.wxStrcmp(it.endsig, t2.station) == 0))
            break;
      }
      itinerary_selected(it);
    }


    public static bool ByName(object pa, object pb) {
      Itinerary ia = (Itinerary)pa;
      Itinerary ib = (Itinerary)pb;

      return Globals.wxStricmp(ia.name, ib.name);
    }

    public static void sort_itineraries() {
      //Itinerary[] its;
      //Itinerary it;
      //int i, n;

      //if(itineraries == null)
      //  return;
      //n = 0;
      //for(it = itineraries; it != null; it = it.next)
      //  ++n;
      //its = new Itinerary[n];
      //n = 0;
      //for(it = itineraries; it != null; it = it.next)
      //  its[n++] = it;
      //qsort(its, n, sizeof(Itinerary*), ByName);
      //for(i = 0; i < n - 1; ++i)
      //  its[i].next = its[i + 1];
      //its[i].next = null;
      //itineraries = its[0];
      //Globals.free(its);
    }
  }
  public class ItinInterpreterData : InterpreterData {
    public ItinInterpreterData() {

    }

    ~ItinInterpreterData() {
      if(_onInit != null)
        Globals.delete(_onInit);
      if(_onClick != null)
        Globals.delete(_onClick);
    }

    public Statement _onInit;	// list of actions (statements)
    public Statement _onClick;
  }

}