using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  partial class Globals {

    public static String parse_km(Track t, String p) {
      throw new NotImplementedException();
      //String pp;

      //t.km = wxStrtol(p, &pp, 10) * 1000;
      //if(*pp == '.')
      //  t.km += wxStrtol(pp + 1, &pp, 10) % 1000;
      //return pp;
    }

    public static void link_signals(Track layout) {
      TrackBase t;

      for(t = layout; t != null; t = t.next)	    /* in case signal was relinked during edit */
        t.esignal = t.wsignal = null;

      for(t = layout; t != null; t = t.next) {

        /*	link signals with the track they control	*/

        if(t is TrackSignal) {
          if((t.controls = findTrack(t.wlinkx, t.wlinky)) == null)
            continue;
          if(t.direction == trkdir.W_E || t.direction == trkdir.S_N)
            t.controls.esignal = (Signal)t;
          else
            t.controls.wsignal = (Signal)t;
        }
      }
    }

    public static Track load_field_tracks(String name, ref Itinerary itinList) {
      Track layout, t, lastTrack;
      TextList tl, tlast;
      Itinerary it;
      string buff;
      int ttype;
      int x, y, sw;
      TDFile trkFile = new TDFile(name);

      trkFile.SetExt(wxPorting.T(".trk"));
      if(!trkFile.Load()) {
        buff = String.Format(wxPorting.T("File '%s' not found."), trkFile.name.GetFullPath());
        Globals.traindir.Error(buff);
        return null;
      }
      lastTrack = null;
      tlast = null;
      layout = null;
      while(trkFile.ReadLine(out buff)) {
        if(buff.StartsWith(wxPorting.T("(script "))) {
          throw new NotImplementedException();
          //p = buff + 8;
          //x = wxStrtol(p, &p, 10);
          //if(*p == wxPorting.T(',')) p.incPointer();
          //y = wxStrtol(p, &p, 10);

          //String script;
          //while(trkFile.ReadLine(buff, sizeof(buff) / sizeof(char)) && buff[0] != ')') {
          //  wxStrcat(buff, wxPorting.T("n"));
          //  script += buff;
          //}

          //for(t = layout; t; t = t.next) {
          //  if(t.x == x && t.y == y)
          //    break;
          //}
          //if(!t)
          //  continue;
          //if(t.stateProgram)
          //  Globals.free(t.stateProgram);
          //t.stateProgram = String.Copy(script);
          //continue;
        }
        if(buff.StartsWith(wxPorting.T("(attributes "))) {
          ReadAttributes(buff, trkFile);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("(switchboard "))) {
          ReadSwitchBoard(buff);
          continue;
        }


        if(buff == null)
          continue;

        ttype = buff[0];

        string[] pieces = buff.Split(',');
        if(pieces.Length < 4)
          continue;

        int posX, posY;
        trkdir direction;
        int pos = 1;

        posX = int.Parse(pieces[pos++]);
        posY = int.Parse(pieces[pos++]);
        direction = (trkdir)int.Parse(pieces[pos++]);

        if(posX >= ((Configuration.XMAX - Configuration.HCOORDBAR) / Configuration.HGRID) ||
          posY >= ((Configuration.YMAX - Configuration.VCOORDBAR) / Configuration.VGRID))
          continue;

        string[] pieces2 = new string[pieces.Length - pos];
        Array.Copy(pieces, pos, pieces2, 0, pieces2.Length);
        pieces = pieces2;

        switch(ttype) {
          default:
            throw new NotImplementedException();

          case '0':
            t = ReadTrack(pieces);
            break;

          case '1':
            t = ReadSwitch(pieces);
            break;

          case '2':
            t = ReadSignal(pieces);
            break;

          case '3':
            t = ReadPlatform(pieces);
            break;

          case '4':
            t = ReadText(pieces);
            break;

          case '5':
            t = ReadImage(pieces);
            break;

          case '6':			/* territory information */
            ReadTerritoryInformation(pieces);
            t = new Track();
            break;

          case '7':			/* itinerary */
            t = ReadItinerary(pieces, ref itinList);
            break;

          case '8':			/* itinerary placement */
            t = ReadItineraryPlacement(pieces);
            break;

          case '9':
            t = ReadTrigger(pieces);
            break;
        }

        // t = new Track();
        t.fgcolor = fieldcolors[(int)fieldcolor.COL_TRACK];
        t.x = posX;
        t.y = posY;
        if(t.direction == trkdir.NODIR) // Erik's patch (this if)
          t.direction = direction;

        if(layout == null)
          layout = t;
        else
          lastTrack.next = t;
        lastTrack = t;
        t._lockedBy = null;

      }
      return layout;
    }

    private static void ReadSwitchBoard(string buff) {
      String line = buff.Substring(13);
      line = line.TrimEnd(')').Trim();
      SwitchBoard sb = CreateSwitchBoard(line);
      sb.Load(line);
    }

    private static void ReadAttributes(string buff, TDFile trkFile) {
      int x, y;
      Track t;

      string line = buff.Substring(12);
      string[] pieces = line.Split(',');

      x = int.Parse(pieces[0]);
      y = int.Parse(pieces[1]);
      t = find_track(layout, x, y);
      while(trkFile.ReadLine(out buff) && buff[0] != ')') {
        if(t == null)
          continue;
        if(buff == wxPorting.T("hidden")) {
          t.invisible = true;
          continue;
        }
        if(buff.StartsWith(wxPorting.T("icons:"))) {	// ITIN and IMAGE
          throw new NotImplementedException();
          //line = buff.Substring(6);
          //x = 0;
          //int ch = 0;
          //do {
          //  while(*p == wxPorting.T(' ') || *p == wxPorting.T('t'))
          //    p.incPointer();
          //  String n = p;
          //  while(*p && *p != wxPorting.T(','))
          //    p.incPointer();
          //  ch = *p.incPointer();	// to check for end of string
          //  *p = 0;
          //  t._flashingIcons[x++] = String.Copy(n);
          //} while(x < MAX_FLASHING_ICONS && ch);
          //continue;
        }
        if(buff.StartsWith(wxPorting.T("locked"))) {
          t._lockedBy = buff.Substring(6).Trim();
          continue;
        }
        if(buff.StartsWith(wxPorting.T("power:"))) {
          throw new NotImplementedException();
          //line = buff.Substring(6).Trim();          
          //t.power = power_parse(line);
          //continue;
        }
        if(buff.StartsWith(wxPorting.T("intermediate"))) {
          line = buff.Substring(12).Trim();
          t._intermediate = int.Parse(line) != 0;
          t._nReservations = 0;
          continue;
        }
        if(buff.StartsWith(wxPorting.T("dontstopshunters"))) {
          t.flags |= TFLG.TFLG_DONTSTOPSHUNTERS;
          continue;
        }
      }
    }

    private static Track ReadTrigger(string[] pieces) {
      int l;
      int pos = 0;

      TrackTrigger t = new TrackTrigger();

      t.wlinkx = int.Parse(pieces[pos++]);
      t.wlinky = int.Parse(pieces[pos++]);
      t.elinkx = int.Parse(pieces[pos++]);
      t.elinky = int.Parse(pieces[pos++]);
      string p2 = pieces[pos];

      String[] pieces2 = pieces[pos++].Split('/');
      for(l = 0; l < Config.NTTYPES && l < pieces2.Length; ++l) {
        t.speed[l] = int.Parse(pieces2[l]);
      }
      p2 = pieces[pos];
      if(string.IsNullOrEmpty(p2) || p2.StartsWith(wxPorting.T("noname")))
        return t;
      t.station = new Station(p2);
      return t;
    }

    private static Track ReadItineraryPlacement(string[] pieces) {
      /* itinerary placement */
      TrackItinerary t = new TrackItinerary();
      t.station = new Station(pieces[0]);
      return t;
    }

    private static Track ReadItinerary(string[] pieces, ref Itinerary itinList) {
      /* itinerary */
      Track t = new Track();
      string p2;
      int pos = 0;

      // Handle (x,y,...) condition in pieces
      int startPos;
      for(startPos = 0; startPos < pieces.Length; ) {
        if(pieces[startPos].Contains('(') == false) {
          startPos++;
        } else {
          if(pieces[startPos].Contains(')')) {
            startPos++;
            continue;
          }
          for(pos = startPos; pos < pieces.Length && !pieces[pos].Contains(')'); pos++)
            ;
          if(pieces[pos].Contains(')') == false)
            return t;
          string[] pieces2 = new string[pieces.Length - (pos - startPos)];
          Array.Copy(pieces, 0, pieces2, 0, startPos);
          pieces2[startPos] = String.Join(",", pieces, startPos, pos - startPos + 1);
          Array.Copy(pieces, pos + 1, pieces2, startPos + 1, pieces2.Length - (startPos + 1));
          pieces = pieces2;
          startPos = pos;
        }
      }
      
      pos = 0;

      Itinerary it = new Itinerary();
      it.name = String.Copy(pieces[pos++]);
      it.signame = String.Copy(pieces[pos++]);
      it.endsig = String.Copy(pieces[pos++]);
      p2 = pieces[pos++];
      if(p2[0] == '@') {
        if(p2.Contains('('))
          throw new NotImplementedException();
      //  for(p1 = p.incPointer(), l = 0; *p && (*p != ',' || l); p.incPointer()) {
      //    if(*p == '(') ++l;
      //    else if(*p == ')') --l;
      //  }
      //  if(!*p)
      //    break;
      //  *p.incPointer() = 0;
      //  it.nextitin = String.Copy(p1);
        it.nextitin = p2.Substring(1);
      }
      while((pos < pieces.Length) && (String.IsNullOrEmpty(pieces[pos]) == false)) {
        int x = int.Parse(pieces[pos++]);
        int y = int.Parse(pieces[pos++]);
        bool sw = int.Parse(pieces[pos++]) != 0;
        add_itinerary(it, x, y, sw);
      }
      it.next = itinList;	/* all ok, add to the list */
      itinList = it;

      return t;
    }

    private static void ReadTerritoryInformation(string[] pieces) {
      throw new NotImplementedException();
            ///* territory information */
            //tl = (TextList*)malloc(sizeof(TextList));
            //wxStrcat(p, wxPorting.T("n"));	/* put it back, since we removed it */
            //tl.txt = String.Copy(p);
            //if(!track_info)
            //  track_info = tl;
            //else
            //  tlast.next = tl;
            //tl.next = 0;
            //tlast = tl;
    }

    private static Track ReadImage(string[] pieces) {
      int pos = 0;
      string p;

      TrackImage t = new TrackImage();

      p = pieces[pos];
      if(p[0] == '@') {
        t.wlinkx = int.Parse(pieces[pos++]);
        t.wlinky = int.Parse(pieces[pos++]);
      }
      t.station = new Station(pieces[pos++]);

      return t;
    }

    private static Track ReadText(string[] pieces) {
      int pos = 0;

      TrackText t = new TrackText();
      t.station = new Station(pieces[pos++]);
      t.wlinkx = int.Parse(pieces[pos++]);
      t.wlinky = int.Parse(pieces[pos++]);
      t.elinkx = int.Parse(pieces[pos++]);
      t.elinky = int.Parse(pieces[pos++]);
      if(pos < pieces.Length && pieces[pos][0] == '>')
        parse_km(t, pieces[pos].Substring(1));

      return t;
    }

    private static Track ReadPlatform(string[] pieces) {
      TrackPlatform t = new TrackPlatform();
      if(t.direction == 0)
        t.direction = trkdir.W_E;
      else
        t.direction = trkdir.N_S;

      return t;
    }

    private static Track ReadSignal(string[] pieces) {
      trkdir l;
      int pos = 0;

      TrackSignal t = new TrackSignal();
      /* 2, x, y, type, linkx, linky [itinerary] */
      t.status = trkstat.ST_RED;
      if(((l = t.direction) & trkdir.NW_SE) != 0) {
        t.fleeted = true;
        l &= ~trkdir.NW_SE;
      }
      if(((int)l & 0x100) != 0)
        t.fixedred = true;
      if(((int)l & 0x200) != 0)
        t.nopenalty = true;
      if(((int)l & 0x400) != 0)
        t.signalx = true;
      if(((int)l & 0x800) != 0)
        t.noClickPenalty = true;
      l = (trkdir)((int)l & ~0xF00);
      t.direction = (trkdir)((int)t.direction & ~0xF00);

      switch(l) {
        case 0:
          t.direction = trkdir.E_W;
          break;

        case (trkdir)1:
          t.direction = trkdir.W_E;
          break;

        case trkdir.N_S:
        case trkdir.S_N:
        case trkdir.signal_SOUTH_FLEETED:
        case trkdir.signal_NORTH_FLEETED:
          /* already there */
          t.direction = l;
          break;
      }
      t.wlinkx = int.Parse(pieces[pos++]);
      t.wlinky = int.Parse(pieces[pos++]);
      if(pieces[pos][0] == '@') {
        t.stateProgram = String.Copy(pieces[pos++].Substring(1));
      }
      if(pos < pieces.Length)			/* for itinerary definition */
        t.station = new Station(pieces[pos]);

      return t;
    }

    private static Track ReadSwitch(string[] pieces) {
      int pos = 0;

      TrackSwitch t = new TrackSwitch();

      t.length = 1;
      t.wlinkx = int.Parse(pieces[pos++]);
      t.wlinky = int.Parse(pieces[pos++]);
      if(pos >= pieces.Length)
        return t;

      throw new NotImplementedException();

      string p2 = pieces[pos];
      if(p2[0] == '@') {
        int i;

        t.speed[0] = int.Parse(pieces[pos++]);
        for(i = 1; i < Config.NTTYPES && p2[0] == '/'; ++i) {
          t.speed[i] = int.Parse(pieces[pos++]);
        }
      }
      p2 = pieces[pos];
      if(String.IsNullOrEmpty(p2) || p2.StartsWith(wxPorting.T("noname")))
        return t;

      if(p2[0] == '>') {
        p2 = parse_km(t, pieces[pos] + 1);
        if(p2[0] == ',')
          p2 = p2.Substring(1);
      }
      t.station = new Station(p2);

      return t;
    }

    private static Track ReadTrack(string[] pieces) {
      int pos = 0;
      Track t = new Track();

      t.isstation = int.Parse(pieces[pos++]) > 0;
      t.length = int.Parse(pieces[pos++]);
      if(t.length == 0)
        t.length = 1;
      t.wlinkx = int.Parse(pieces[pos++]);
      t.wlinky = int.Parse(pieces[pos++]);
      t.elinkx = int.Parse(pieces[pos++]);
      t.elinky = int.Parse(pieces[pos++]);
      string p2 = pieces[pos];
      if(p2[0] == '@') {
        String[] pieces2 = p2.Substring(1).Split('/');
        for(int l = 0; l < Config.NTTYPES && l < pieces2.Length; ++l) {
          t.speed[l] = int.Parse(pieces2[l]);
        }
        pos++;
      }
      if(
        pos >= pieces.Length ||
        string.IsNullOrEmpty(pieces[pos]) ||
        pieces[pos].StartsWith(wxPorting.T("noname"))
      ) {
        t.isstation = false;
        return t;
      }
      if(pieces[pos][0] == '>') {
        parse_km(t, pieces[pos++]);
      }
      t.station = new Station(pieces[pos]);
      
      return t;
    }

    public static Track load_field(String name) {
      int l;
      TextList tl;
      Itinerary it;
      Track t;

      // TODO Uncomment this
      //for(l = 0; l < 4; ++l) {
      //  e_train_pmap[l] = e_train_pmap_default[l];
      //  w_train_pmap[l] = w_train_pmap_default[l];
      //  e_car_pmap[l] = e_car_pmap_default[l];
      //  w_car_pmap[l] = w_car_pmap_default[l];
      //}

      while((tl = track_info) != null) {
        track_info = tl.next;
      }
      while((it = itineraries) != null) {
        itineraries = it.next;
      }
      powerSpecified = false;

      // No need to free the cache, since they're just string that can be re-used across layouts

      free_scripts();
      t = load_field_tracks(name, ref itineraries);
      sort_itineraries();
      if(t != null) {
        link_all_tracks(t);
        link_signals(t);
        powerSpecified = power_specified(t);
        current_project = name;
      }
      layout_modified1 = 0;
      return t;
    }

    public static bool power_specified(Track layout) {
      while(layout != null) {
        if(String.IsNullOrEmpty(layout.power) == false)
          return true;
        layout = layout.next;
      }
      return false;
    }

    public static Track find_track(Track layout, int x, int y) {
      while(layout != null) {
        if(layout.x == x && layout.y == y)
          return (layout);
        layout = layout.next;
      }
      return null;
    }
  }
}
