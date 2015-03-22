using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        buff = String.Format(wxPorting.T("File '{0}' not found."), trkFile.mName.GetFullPath());
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

        string[] pieces =
          // buff.Split(',');
          SplitWithGrouping(buff, ',', '(', ')');

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
DEBUG_Func1(layout);
      return layout;
    }

    private static string[] SplitWithGrouping(string str, char separator, char opening, char closing) {
      List<string> pieces = new List<string>();

      char ch;
      int length, deep;
      char[] srcBuffer = str.ToCharArray();
      char[] dstBuffer = new char[str.Length];

      length = 0;
      deep = 0;
      for(int x = 0; x < srcBuffer.Length; x++, length++) {
        ch = srcBuffer[x];
        if(deep == 0 && ch == ',') {
          pieces.Add(new string(dstBuffer, 0, length));
          length = -1;
        } else {
          dstBuffer[length] = ch;

          if(ch == '(')
            deep++;
          else if(ch == ')')
            deep--;
        }
      }
      if(length > 0)
        pieces.Add(new string(dstBuffer, 0, length));

      return pieces.ToArray();
    }

    private static void DEBUG_Func1(Track layout) {
      Track t = layout;
      while(t != null) {
        if(t.TrackType == trktype.TRACK) {
          if(t.x == 0 && t.y == 0) {
          }
        }
        t = t.next;
      }
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
          //  while(*p == wxPorting.T(' ') || *p == wxPorting.T('\t'))
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
      NoTrack t = new NoTrack();
      string p2;
      int pos = 0;

      // Erik: I don't know if this code is really needed!
      //// Handle (x,y,...) condition in pieces
      //int startPos;
      //for(startPos = 0; startPos < pieces.Length; ) {
      //  if(pieces[startPos].Contains('(') == false) {
      //    startPos++;
      //  } else {
      //    if(pieces[startPos].Contains(')')) {
      //      startPos++;
      //      continue;
      //    }
      //    for(pos = startPos; pos < pieces.Length && !pieces[pos].Contains(')'); pos++)
      //      ;
      //    if(pieces[pos].Contains(')') == false)
      //      return t;
      //    string[] pieces2 = new string[pieces.Length - (pos - startPos)];
      //    Array.Copy(pieces, 0, pieces2, 0, startPos);
      //    pieces2[startPos] = String.Join(",", pieces, startPos, pos - startPos + 1);
      //    Array.Copy(pieces, pos + 1, pieces2, startPos + 1, pieces2.Length - (startPos + 1));
      //    pieces = pieces2;
      //    startPos = pos;
      //  }
      //}
      
      //pos = 0;

      Itinerary it = new Itinerary();
      it.name = String.Copy(pieces[pos++]);
      it.signame = String.Copy(pieces[pos++]);
      it.endsig = String.Copy(pieces[pos++]);
      p2 = pieces[pos++];
      if(p2[0] == '@') {
        //if(p2.Length > 1)
        //  throw new NotImplementedException();
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

    public static Path paths;

    public static bool performance_hide_canceled = false;

    public static List<pxmap> pixmaps;
    public static List<pxmap> carpixmaps;

    public static GTFS gtfs;


    public static string dirPath;

    private static int curtype = 0;
    public static bool save_prefs = true;
    public static string[] powerType = new string[Config.NTTYPES];
    public static double[] gauge = new double[Config.NTTYPES];
    public static bool powerSpecified;

    private static String linebuff1;
    private static int maxline1;
    public static int layout_modified1;

    private static Train sched;

    public static bool load_trains_from_gtfs() {
      gtfs = new GTFS();
      return gtfs.Load(dirPath);
    }

    public static Train parse_newformat(TDFile schFile) {
      Train t;
      TrainStop stp;
      string buff;
      int x;
      int i;
      TimeSpan l;
      String p;
      String fileinc;
      String nw, ne;
      object pmw, pme;
      Match match;

      t = null;
      while(schFile.ReadLine(out buff)) {
        if(String1.IsNullOrWhiteSpaces(buff) || buff[0] == '#')
          continue;

        if(buff[0] == '.') {
          t = null;
          continue;
        }
        char[] charBuff = buff.ToCharArray();
        for(x = 0; x < charBuff.Length; ++x)
          if(charBuff[x] == '\t')
            charBuff[x] = ' ';
        while(x != 0 && (charBuff[x - 1] == ' ' || charBuff[x - 1] == '\t')) --x;
        buff = new string(charBuff, 0, x);
        
        if(buff.StartsWith(wxPorting.T("Include: "))) {
          throw new NotImplementedException();
      //    for(p = buff + 9; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;

      //    TDFile incFile = new TDFile(p);

      //    if(incFile.Load())
      //      parse_newformat(incFile);
      //    else {
      //      fileinc = String.Format(wxPorting.T("%s/%s"), dirPath, locase(p));
      //      TDFile incFile1 = new TDFile(fileinc);

      //      if(!incFile1.Load())
      //        continue;
      //      parse_newformat(incFile1);
      //    }

      //    t = 0;
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Routes:"))) {
          throw new NotImplementedException();
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    gtfs.SetOurRoutes(p);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("GTFS:"))) {
          throw new NotImplementedException();
      //    for(p = buff + 5; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    sched = read_gtfs(sched, p);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Cancel:"))) {
          throw new NotImplementedException();
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    sched = cancelTrain(p, sched);
      //    t = 0;
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Today: "))) {
          throw new NotImplementedException();
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    for(l = 0; p[0] >= '0' && p[0] <= '9'; p.incPointer())
      //      l |= 1 << (*p - '1');
      //    run_day = l;
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Start: "))) {
          p = buff.Substring(7);
          current_time = start_time = parse_time(p);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Train: "))) {
          t = find_train(sched, buff.Substring(7));
          if(t != null)
            continue;
          t = new Train();
          t.name = buff.Substring(7);
          t.next = sched;
          t.type = curtype;
          t.epix = t.wpix = -1;
          t.ecarpix = t.wcarpix = -1;
          sched = t;
          continue;
        }
        if(t == null) {
          if(buff.StartsWith(wxPorting.T("Type: "))) {
            throw new NotImplementedException();
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      curtype = l;
      //      if(!p)
      //        continue;
            //      while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //      if(!*p)
      //        continue;
      //      if(p[0] == '+') {
      //        startDelay[curtype] = wxStrtol(p.incPointer(), &p, 10);
      //      }
      //      if(p[0] == '>') {
      //        accelRate[curtype] = wxAtof(p.incPointer());
            //        while(*p && *p != ' ' && *p != '\t')
      //          p.incPointer();
      //      }
            //      while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //      if(!*p)
      //        continue;
      //      nw = p;
            //      while(*p && *p != ' ' && *p != '\t') p.incPointer();
      //      if(!*p)
      //        continue;
      //      *p.incPointer() = 0;
            //      while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //      ne = p;
            //      while(*p && *p != ' ' && *p != '\t') p.incPointer();
      //      l = *p;
      //      *p.incPointer() = 0;
      //      if(!(pmw = get_pixmap_file(locase(nw))))
      //        continue;
      //      if(!(pme = get_pixmap_file(locase(ne))))
      //        continue;
      //      w_train_pmap[curtype] = pmw;
      //      e_train_pmap[curtype] = pme;
      //      if(!l)
      //        continue;
            //      while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //      ne = p;
            //      while(*p && *p != ' ' && *p != '\t') p.incPointer();
      //      l = *p;
      //      *p.incPointer() = 0;
      //      if(!(pmw = get_pixmap_file(locase(ne))))
      //        continue;
      //      w_car_pmap[curtype] = pmw;
      //      e_car_pmap[curtype] = pmw;
      //      if(!l)
      //        continue;
            //      while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //      if(!*p)
      //        continue;
      //      if(!(pme = get_pixmap_file(locase(p))))
      //        continue;
      //      e_car_pmap[curtype] = pme;
      //      continue;
          }
          if(buff.StartsWith(wxPorting.T("Power:"))) {
            throw new NotImplementedException();
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      powerType[l] = power_parse(p);
      //      continue;
          }
          if(buff.StartsWith(wxPorting.T("Gauge:"))) {
            throw new NotImplementedException();
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      gauge[l] = wxAtof(p);
      //      continue;
          }
          continue;
        }
        p = buff;
        while(p.Length > 0 && (p[0] == ' ' || p[0] == '\t'))
          p = p.Substring(1);
        if(p.StartsWith("Wait: ")) {
          match = Regex.Match(p, "^Wait:[ \t]*([^ \t]+)[ \t]*$");
          if(match.Success == false)
            throw new NotImplementedException();
          //while(p[0] == ' ' || p[0] == '\t') p.incPointer();
          //for(nw = p; *nw && *nw != ' '; ++nw) ;
          //if(*nw)
          //  *nw++ = 0;
          //else
          //  nw = 0;
          t.waitfor = match.Groups[1].Value;
          t.waittime = /*nw ? int.Parse(nw) : */ 60;
          continue;
        }
        if(p.StartsWith("StartDelay: ")) {
          throw new NotImplementedException();
      //    t.myStartDelay = wxAtoi(p + 12);
          continue;
        }
        if(p.StartsWith("AccelRate: ")) {
          throw new NotImplementedException();
      //    t.accelRate = wxAtof(p + 11);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Power:"))) {
          throw new NotImplementedException();
      //    t.power = power_parse(buff + 6);
          continue;
        }
        if(buff.StartsWith(wxPorting.T("Gauge:"))) {
          throw new NotImplementedException();
      //    t.gauge = wxAtof(buff + 6);
          continue;
        }
        if(p.StartsWith("When: ")) {
          p = p.Substring(6).Trim();
          for(x = 0; p.Length > 0 && p[0] >= '0' && p[0] <= '9'; p = p.Substring(1))
            t.days |= (RunDays)(1 << (p[0] - '1'));
          continue;
        }
        if(p.StartsWith("Speed:")) {
          t.maxspeed = int.Parse(p.Substring(6).Trim());
          continue;
        }
        if(p.StartsWith("Type: ")) {
          match = Regex.Match(p, "^Type: ([0-9]+) ([^ ]+\\.xpm) ([^ ]+\\.xpm)$");

          if(match.Success == false)
            throw new NotImplementedException();

          x = int.Parse(match.Groups[1].Value);

          if(x - 1 < Config.NTTYPES)
            t.type = x - 1;

          nw = match.Groups[2].Value.ToLower();
          if((t.wpix = get_pixmap_index(nw)) < 0)
            continue;
          
          p = match.Groups[3].Value.ToLower();
          t.epix = get_pixmap_index(p);
            continue;
        }
        if(p.StartsWith("Stock: ")) {
          t.stock = p.Substring(7).Trim();
          continue;
        }
        if(p.StartsWith("Length: ")) {
          throw new NotImplementedException();
      //    t.length = wxStrtol(p + 8, &p, 0);
      //    t.entryLength = t.length;
      //    t.tail = (Train*)calloc(sizeof(Train), 1);
      //    t.ecarpix = t.wcarpix = -1;
          //    while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //    if(!*p)
      //      continue;
      //    ne = p;
          //    while(*p && *p != ' ' && *p != '\t') p.incPointer();
      //    l = *p;
      //    *p.incPointer() = 0;
      //    t.ecarpix = t.wcarpix = get_carpixmap_index(locase(ne));
      //    if(!l)
      //      continue;
          //    while(p[0] == ' ' || p[0] == '\t') p.incPointer();
      //    if(!*p)
      //      continue;
      //    t.wcarpix = get_carpixmap_index(locase(p));
          continue;
        }
        if(p.StartsWith("Enter: ")) {
          match = Regex.Match(p, "^Enter:[ \t]*([0-9]+:[0-9]+:[0-9]+)[, \t][ \t]*([^ \t].*)$");
          if(match.Success == false) {
            match = Regex.Match(p, "^Enter:[ \t]*([0-9]+:[0-9]+),[ \t]*([^ \t].*)$");
            if(match.Success == false)
              throw new NotImplementedException();
          }

          t.timein = parse_time(match.Groups[1].Value);
          if(p[0] == Globals.DELAY_CHAR) {
            throw new NotImplementedException();
            //t.entryDelay = (TDDelay*)calloc(sizeof(TDDelay), 1);
            //p = parse_delay(p.incPointer(), t.entryDelay);
          }
          t.entrance = String.Copy(convert_station(match.Groups[2].Value));
          continue;
        }
        if(p.StartsWith("Notes:")) {
          t.notes.Add(p.Substring(6).Trim());
          continue;
        }
        if(p.StartsWith(wxPorting.T("Script:"))) {
          String scr = "";
          while(schFile.ReadLine(out buff)) {
            if(buff.Length > 0 && buff[0] == '#')
              continue;
            if(String.Equals(buff, wxPorting.T("EndScript"))) {
              break;
            }
            buff += wxPorting.T("\n");
            scr += buff;
          }
          t.stateProgram = scr;
          continue;
        }
        // TODO Check if following line is correct. I had the need to initialize l
        l = TimeSpan.Zero;

        stp = new TrainStop();
        stp.minstop = 30;

        p = p.Trim();
        String singleParam = "([0-9]+:[0-9]+:[0-9]+[^, ]*|:|\\+|-)";
        String spaces = "[ \t]*";
        String separator = String.Concat(spaces, "[, ]?", spaces);
        String everything = "(..*)";
        String pattern = String.Concat("^", spaces, singleParam, separator, singleParam, separator, everything, "$");
        match = Regex.Match(p, pattern);

        if(match.Success == false)
          throw new NotImplementedException();

        p = match.Groups[1].Value;

        if(p[0] == '-') {		/* doesn't stop */
          stp.minstop = 0;
        } else if(p[0] == '+') {	// arrival: delta from previous departure
          throw new NotImplementedException();
        //  p.incPointer();
        //  l = wxStrtoul(p, &p, 10);
        //  if(!t.stops)
        //    l += t.timein;
        //  else
        //    l += t.laststop.departure;
        } else
          l = parse_time(p);	/* arrival */
        // TODO Handle following code
        //if(p[0] == '+') {
        //  p.incPointer();
        //  stp.minstop = wxStrtoul(p, &p, 10);
        //}

        p = match.Groups[2].Value;
        if(p[0] == '-') {
          // Globals.free(stp);
          if(String1.IsNullOrWhiteSpaces(t.exit) == false)		/* already processed exit point! */
            continue;
          t.timeout = l;
          p = match.Groups[3].Value;
          t.exit = String.Copy(convert_station(p));
          continue;
        }
        if(p[0] == '+') {
          throw new NotImplementedException();
          //stp.departure = wxStrtoul(p + 1, &p, 10);
          //if(stp.departure < stp.minstop)
          //  stp.departure = stp.minstop;
          //if(!stp.minstop) {	// doesn't stop
          //  if(!t.stops)
          //    l = t.timein;
          //  else
          //    l = t.laststop.departure;
          //}
          //stp.departure += l;
        } else {
          if((i = p.IndexOf('!')) < 0)
            i = p.Length;
          stp.departure = parse_time(p.Substring(0, i));
        }
        //if(!stp.minstop)
        //  stp.arrival = stp.departure;
        //else {
        //  stp.arrival = l;
        //  if(stp.departure == stp.arrival)  //
        //    stp.departure = stp.arrival + stp.minstop;
        //  else if(stp.minstop > stp.departure - stp.arrival)	// +Rask Ingemann Lambertsen
        //    stp.minstop = stp.departure - stp.arrival;	// +Rask Ingemann Lambertsen
        //}
        if((i = p.IndexOf(DELAY_CHAR)) >= 0) {
          stp.depDelay = new TDDelay();
          parse_delay(p.Substring(i + 1), stp.depDelay);
        }
        p = match.Groups[3].Value;
        stp.station = new Station(convert_station(p));
        if(t.stops == null)
          t.stops = new List<TrainStop>();
        t.stops.Add(stp);
        //else {
        //  t.laststop.next = stp;
        //t.laststop = stp;
      }
      
      return sched;
    }

    public static Train load_trains(String name) {
      Train t;
      TrainStop stp;
      string buff;
      int l;
      String p, p1;
      bool newformat;

      sched = null;
      newformat = false;
      start_time = TimeSpan.Zero;
      curtype = 0;
      Array.Clear(startDelay, 0, startDelay.Length);
      for(int i = 0; i < Config.NTTYPES; ++i) { // 3.9
        powerType[i] = null;
        gauge[i] = 0;
      }

      ////if(gtfs != null)
      ////  Globals.delete(gtfs);
      gtfs = new GTFS();


      TDFile schFile = new TDFile(name);
      schFile.SetExt(wxPorting.T(".sch"));
      // schFile.GetDirName(out dirPath);
      if(!schFile.Load()) {
        if(!load_trains_from_gtfs())
          return null;
      } else while(schFile.ReadLine(out buff)) {
        if(String1.IsNullOrWhiteSpaces(buff))
          continue;

        if(newformat || (buff == wxPorting.T("#!trdir"))) {
          newformat = true;
          t = parse_newformat(schFile);
          if(t == null)
            continue;
          sched = t;
          continue;
        }
        
        throw new NotImplementedException();

        //if(buff[0] == '#')
        //  throw new NotImplementedException(); // continue;

        //t = new Train();
        //t.next = sched;
        //sched = t;
        //int i;
        //i = buff.IndexOf(',');// for(p = buff; *p && *p != ','; p.incPointer()) ;
        //if(i < 0)
        //  continue; // if(!*p)
        //t.name = buff.Substring(0, i); // *p.incPointer() = 0; t.name = String.Copy(buff);
        //t.status = trainstat.train_READY;
        //t.direction = t.sdirection = (trkdir)wxStrtol(p, out p, 10);
        //if(p != null && p[0] == ',') p = p.Substring(1);
        //t.timein = parse_time(&p);
        //if(p != null && p[0] == ',') p = p.Substring(1);
        //p1 = p;
        //while(p.Length > 0 && p[0] != ',') p = p.Substring(1);
        //if(p.Length == 0)
        //  continue;
        //*p.incPointer() = 0;
        //t.entrance = String.Copy(p1);
        //t.timeout = parse_time(&p);
        //if(p[0] == ',') p = p.Substring(1);
        //p1 = p;
        //if(p != null && p[0] == ',') p = p.Substring(1);
        //if(p.Length == 0)
        //  continue;
        //*p.incPointer() = 0;
        //t.exit = String.Copy(p1);
        //t.maxspeed = wxStrtol(p, out p, 10);
        //if(p[0] == ',') p = p.Substring(1);
        //while(p.Length > 0) {
        //  for(p1 = p; *p && *p != ','; p.incPointer()) ;
        //  if(p.Length == 0)
        //    continue;
        //  *p.incPointer() = 0;
        //  stp = new TrainStop();
        //  if(t.stops == null)
        //    t.stops = new List<TrainStop> { stp };
        //  else
        //    t.laststop.next = stp;
        //  t.laststop = stp;
        //  stp.station = String.Copy(p1);
        //  stp.arrival = parse_time(&p);
        //  if(p[0] == ',') p = p.Substring(1);
        //  stp.departure = parse_time(&p);
        //  if(p[0] == ',') p = p.Substring(1);
        //  stp.minstop = wxStrtol(p, &p, 10);
        //  if(p[0] == ',') p = p.Substring(1);
        //}
      }

      /* check correctness of schedule */

      l = 0;
      for(t = sched; t != null; t = t.next) {
        if(String1.IsNullOrWhiteSpaces(t.exit)) {
          t.exit = wxPorting.T("?");
          ++l;
        }
        if(String1.IsNullOrWhiteSpaces(t.exit)) {
          t.entrance = wxPorting.T("?");
          ++l;
        }
      }
      if(l != 0)
        Globals.traindir.Error(wxPorting.L("Some train has unknown entry/exit point!"));

      // 3.9: propagate motive power

      for(t = sched; t != null; t = t.next) {
        if(String1.IsNullOrWhiteSpaces(t.power) == false)
          continue;
        t.power = powerType[t.type]; // either null or real power spec.
      }

      load_paths(name);
      resolve_paths(sched);

      sched = sort_schedule(sched);

      for(t = sched; t != null; t = t.next)
        if(String1.IsNullOrWhiteSpaces(t.stateProgram) == false)
          t.ParseProgram();

      return sched;

      throw new NotImplementedException();
    }

    public static int wxStrtol(string buffer, out string nextPiece, int baseNumber) {
      if(baseNumber != 10)
        throw new NotImplementedException();
      if(String1.IsNullOrWhiteSpaces(buffer))
        throw new ArgumentException();

      int result = 0;
      int nextToken;
      for(nextToken = 0; nextToken < buffer.Length; nextToken++) {
        int val = buffer[nextToken] - '0';
        if(val < 0 || val > 9) {
          nextPiece = buffer.Substring(nextToken);
          return result;
        }

        result *= 10;
        result += val;
      }

      nextPiece = "";
      return result;
    }

    public static Train find_train(Train sched, string name) {
      Train t;

      for(t = sched; t != null; t = t.next)
        if(String.Equals(t.name, name))
          return t;

      return null;
    }

    public static Train sort_schedule(Train sched) {
      Train[] qb;
      Train t;
      int ntrains;
      int l;

      for(t = sched, ntrains = 0; t != null; t = t.next)
        ++ntrains;
      if(ntrains == 0)
        return sched;
      qb = new Train[ntrains];
      for(t = sched, l = 0; l < ntrains; ++l, t = t.next)
        qb[l] = t;
      Array.Sort(qb, trcmp); // qsort(qb, ntrains, sizeof(Train*), trcmp);
      for(l = 0; l < ntrains - 1; ++l)
        qb[l].next = qb[l + 1];
      qb[ntrains - 1].next = null;
      t = qb[0];
      return t;
    }

    public static String convert_station(String p) {
      return (p);
    }

    public static String parse_delay(String p, TDDelay del) {
      int secs, prob = 0;
      foreach(var piece in p.Split(',')) {
        String[] parts = piece.Split('/');
        secs = int.Parse(parts[0]);
        if(parts.Length > 0)
          prob = int.Parse(parts[1]);
        del.delays.Add(new TDDelay.Delay(secs, prob));
      }
      return p;
    }

    private static void resolve_path(Train t) {

      Path pt, pth;
      TrainStop ts, tt;
      TimeSpan t0 = TimeSpan.Zero;
      bool f1;

      if(findStationNamed(t.entrance) != null) {
        f1 = true;
        goto xit;
      }
      f1 = false;
      for(ts = t.stops.FirstOrDefault(); ts != null; ts = ts.next) {
        if((pt = find_path(t.entrance, ts.station.FullName)) != null) {
          t.entrance = String.Copy(pt.enter);
          t.timein = ts.arrival - pt.times[t.type];
          f1 = true;
          goto xit;
        }
      }
      for(tt = t.stops.FirstOrDefault(); tt != null; tt = tt.next) {
        for(ts = tt.next; ts != null; ts = ts.next) {
          if((pt = find_path(tt.station.FullName, ts.station.FullName)) != null) {
            t.entrance = String.Copy(pt.enter);
            t.timein = ts.arrival - pt.times[t.type];
            f1 = true;
            goto xit;
          }
        }
      }

    xit:
      if(f1 && t.timein == null)         // first stop is close to midnight but path time is longer
        t.timein.Add(new TimeSpan(1, 0, 0, 0)); // += 24 * 60 * 60;  // so move time in to the end of this day
      if(findStationNamed(t.exit) != null) {
        if(f1)			// both entrance and exit in layout
          return;
        pth = null;
        for(tt = t.stops.FirstOrDefault(); tt != null; tt = tt.next)
          if((pt = find_path(tt.station.FullName, t.exit)) != null)
            pth = pt;
        if(pth == null)
          pth = find_path(t.entrance, t.exit);
        if(pth == null)
          return;
        t.entrance = String.Copy(pth.enter);
        t.timein = t.timeout - pth.times[t.type];
        if(t.timein == null)
          t.timein.Add(new TimeSpan(1, 0, 0, 0)); // 24 * 60 * 60;
        return;
      }
      pth = null;
      for(tt = t.stops.FirstOrDefault(); tt != null; tt = tt.next) {
        for(ts = tt.next; ts != null; ts = ts.next) {
          if((pt = find_path(tt.station.FullName, ts.station.FullName)) != null) {
            t0 = tt.departure;
            pth = pt;
          }
        }
      }
      for(ts = t.stops.FirstOrDefault(); ts != null; ts = ts.next)
        if((pt = find_path(ts.station.FullName, t.exit)) != null) {
          t0 = ts.departure;
          pth = pt;
        }
      if(pth != null) {
        t.exit = String.Copy(pth.enter);
        t.timeout = t0 + pth.times[t.type];
        return;
      }
      if(!f1)
        return;
      for(ts = t.stops.FirstOrDefault(); ts != null; ts = ts.next)
        if((pt = find_path(t.entrance, ts.station.FullName)) != null) {
          t.exit = String.Copy(pt.enter);
          t.timeout = t.timein + pt.times[t.type];
          return;
        }
      if((pt = find_path(t.entrance, t.exit)) != null) {
        t.exit = String.Copy(pt.enter);
        t.timeout = t.timein + pt.times[t.type];
      }
    }

    public static void resolve_paths(Train schedule) {
      Train t;

      if(paths == null)
        return;
      for(t = schedule; t != null; t = t.next)
        resolve_path(t);
    }

    public static void load_paths(String name) {
      Path pt;
      string buff;
      int l;
      String p, p1;
      int errors;

      TDFile pthFile = new TDFile(name);

      pthFile.SetExt(wxPorting.T(".pth"));
      if(!pthFile.Load())
        return;
      pt = null;
      errors = 0;
      while(pthFile.ReadLine(out buff)) {
        p = skipblk(buff);
        if(p.Length == 0 || p[0] == '#')
          continue;
        if(p.StartsWith(wxPorting.T("Path:"))) {
          if(pt != null) {			/* end previous entry */
            if(
              String1.IsNullOrWhiteSpaces(pt.from) ||
              String1.IsNullOrWhiteSpaces(pt.to) ||
              String1.IsNullOrWhiteSpaces(pt.enter)
            ) {
              ++errors;
              paths = pt.next;	/* ignore last entry */
            }
          }
          p = p.Substring(5).Trim();
          pt = new Path {
            next = paths
          };
          paths = pt;
          continue;
        }
        if(p.StartsWith(wxPorting.T("From:")))
          pt.from = p.Substring(5).Trim();
        if(p.StartsWith(wxPorting.T("To:")))
          pt.to= p.Substring(3).Trim();
        if(p.StartsWith(wxPorting.T("Times:"))) {
          p = p.Substring(6).Trim();
          p1 = p.Trim();
          if(p1.Length == 0)			/* no entry point! */
            continue;
          for(l = 0; l < Config.NTTYPES; ++l) {
            throw new NotImplementedException();
            //pt.times[l] = wxStrtol(p, &p, 10) * 60;
            //if(p[0] == '/' || p[0] == ',') p.incPointer();
          }
          p = skipblk(p1);
          pt.enter = String.Copy(p);
        }
      }
    }

    public static String skipblk(String p) {
      return p.Trim();
    }

    private static Path find_path(String from, String to) {
      throw new NotImplementedException();
      //Path pt;

      //for(pt = paths; pt; pt = pt.next) {
      //  if(!pt.from || !pt.to || !pt.enter)
      //    continue;
      //  if(sameStation(from, pt.from) && sameStation(to, pt.to))
      //    return pt;
      //}
      //return 0;
    }

    public static int trcmp(object a, object b) {
      Train ap = (Train)a;
      Train bp = (Train)b;
      if(ap.timein < bp.timein)
        return -1;
      if(ap.timein > bp.timein)
        return 1;
      return 0;
    }

  }
}
