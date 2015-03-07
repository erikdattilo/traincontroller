using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TrainController {
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
  }

  partial class Globals {
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
      if(it.sw[it.nsects] == null)
        it.sw[it.nsects] = new switin();
      it.sw[it.nsects].x = x;
      it.sw[it.nsects].y = y;
      it.sw[it.nsects].switched = sw;
      ++it.nsects;
    }
    public class ByName : IComparer {
      public int Compare(object oa, object ob) {
        if(
          ((oa is Itinerary) == false) ||
          ((ob is Itinerary) == false)
        )
          return 0;

        Itinerary ia = (Itinerary)oa;
        Itinerary ib = (Itinerary)ob;
        if((ia == null) || String.IsNullOrEmpty(ia.name))
          return -1;
        if((ib == null) || String.IsNullOrEmpty(ib.name))
          return 1;

        return String.Compare(ia.name, ib.name);
      }
    }

    public static void sort_itineraries() {
      Itinerary[] its;
      Itinerary it;
      int i, n;

      if(itineraries == null)
        return;
      n = 0;
      for(it = itineraries; it != null; it = it.next)
        ++n;
      its = new Itinerary[n];
      n = 0;
      for(it = itineraries; it != null; it = it.next)
        its[n++] = it;
      Array.Sort(its, 0, n, new ByName());
      for(i = 0; i < n - 1; ++i)
        its[i].next = its[i + 1];
      its[i].next = null;
      itineraries = its[0];
    }
  }
}
