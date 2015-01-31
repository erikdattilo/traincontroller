 /*	loadsave.cpp - Created by Giampiero Caprino
 
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
  public static partial class Globals {
    public static Path paths;

    public static bool performance_hide_canceled = false;

    public static pxmap[] pixmaps;
    public static int npixmaps, maxpixmaps;

    public static pxmap carpixmaps;
    public static int ncarpixmaps, maxcarpixmaps;

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

    private static String getline1(TDFile fp) {
      throw new NotImplementedException();
      //int i;
      //Char ch;

      //if(String.IsNullOrEmpty(linebuff1)) {
      //  maxline1 = 256;
      //  linebuff1 = (String)malloc(maxline1); // Erik: Origina code ==>  malloc(maxline1 * sizeof(linebuff1[0]));
      //  if(!linebuff1)
      //    return null;
      //}
      //i = 0;
      //while((ch = *fp.nextChar)) {
      //  if(ch == wxPorting.T('r')) {
      //    ++fp.nextChar;
      //    continue;
      //  }
      //  if(ch == wxPorting.T('n')) {
      //    ++fp.nextChar;
      //    break;
      //  }
      //  if(i + 2 >= maxline1) {
      //    maxline1 += 256;
      //    linebuff1 = (String)realloc(linebuff1, maxline1);
      //    if(!linebuff1)
      //      return null;
      //  }
      //  linebuff1[i++] = ch;
      //  ++fp.nextChar;
      //}
      //if(ch == 0 && i == 0)
      //  return 0;
      //linebuff1[i] = 0;
      //return linebuff1;
    }

    public static bool file_create(String name, String ext, wxFFile fp) {
      throw new NotImplementedException();
      //string buff;
      //String p;
      //// extern	int errno;

      //buff = string.Copy(name);
      //buff[sizeof(buff) / sizeof(char) - 1] = 0;
      //for(p = buff + Globals.wxStrlen(buff); p > buff && *p != '.' && *p != '/' && *p != '\\'; --p) ;
      //if(p[0] == '.')
      //  p = String.Copy(ext);
      //else
      //  wxStrcat(p, ext);
      //if(fp.Open(buff, wxPorting.T("w")))
      //  return true;
      //buff = String.Format(wxPorting.T("%s '%s' - %s."), wxPorting.L("Can't create file"), name, wxPorting.L("Error"));
      //Globals.traindir.Error(buff);
      //return false;
    }

    public static String locase(String s) {
      throw new NotImplementedException();
      //String p;

      //for(p = s; *p; p.incPointer())
      //  *p = wxTolower(*p);
      //return s;
    }

    public static String skipblk(String p) {
      throw new NotImplementedException();
      //while(*p == ' ' || *p == 't') p.incPointer();
      //return p;
    }

    public static void clean_field(Track layout) {
      //Track t;

      //while(layout) {
      //  t = layout.next;
      //  if(layout.station)
      //    Globals.free(layout.station);
      //  Globals.free(layout);
      //  layout = t;
      //}
      //powerSpecified = false;
    }

    public static bool power_specified(Track layout) {
      throw new NotImplementedException();
      //while(layout) {
      //  if(layout.power)
      //    return true;
      //  layout = layout.next;
      //}
      //return false;
    }

    public static Track load_field_tracks(String name, Itinerary itinList) {
      throw new NotImplementedException();
      //Track layout, t, lastTrack;
      //TextList tl, tlast;
      //Itinerary it;
      //string buff;
      //int l;
      //int ttype;
      //int x, y, sw;
      //String p, p1;
      //TDFile trkFile = new TDFile(name);

      //trkFile.SetExt(wxPorting.T(".trk"));
      //if(!trkFile.Load()) {
      //  buff = String.Format(wxPorting.T("File '%s' not found."), trkFile.name.GetFullPath());
      //  Globals.traindir.Error(buff);
      //  return 0;
      //}
      //lastTrack = 0;
      //tlast = 0;
      //layout = 0;
      //while(trkFile.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("(script "), 8)) {
      //    p = buff + 8;
      //    x = wxStrtol(p, &p, 10);
      //    if(*p == wxPorting.T(',')) p.incPointer();
      //    y = wxStrtol(p, &p, 10);

      //    String script;
      //    while(trkFile.ReadLine(buff, sizeof(buff) / sizeof(char)) && buff[0] != ')') {
      //      wxStrcat(buff, wxPorting.T("n"));
      //      script += buff;
      //    }

      //    for(t = layout; t; t = t.next) {
      //      if(t.x == x && t.y == y)
      //        break;
      //    }
      //    if(!t)
      //      continue;
      //    if(t.stateProgram)
      //      Globals.free(t.stateProgram);
      //    t.stateProgram = String.Copy(script);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("(attributes "), 12)) {
      //    x = wxStrtol(buff + 12, &p, 10);
      //    if(*p == wxPorting.T(',')) p.incPointer();
      //    y = wxStrtol(p, &p, 10);
      //    t = find_track(layout, x, y);
      //    while(trkFile.ReadLine(buff, sizeof(buff) / sizeof(char)) && buff[0] != ')') {
      //      if(!t)
      //        continue;
      //      if(!wxStrcmp(buff, wxPorting.T("hidden"))) {
      //        t.invisible = 1;
      //        continue;
      //      }
      //      if(!Globals.wxStrncmp(buff, wxPorting.T("icons:"), 6)) {	// ITIN and IMAGE
      //        p = buff + 6;
      //        int x = 0;
      //        int ch = 0;
      //        do {
      //          while(*p == wxPorting.T(' ') || *p == wxPorting.T('t'))
      //            p.incPointer();
      //          String n = p;
      //          while(*p && *p != wxPorting.T(','))
      //            p.incPointer();
      //          ch = *p.incPointer();	// to check for end of string
      //          *p = 0;
      //          t._flashingIcons[x++] = String.Copy(n);
      //        } while(x < MAX_FLASHING_ICONS && ch);
      //        continue;
      //      }
      //      if(!Globals.wxStrncmp(buff, wxPorting.T("locked"), 6)) {
      //        p = buff + 6;
      //        t._lockedBy = String.Copy(p);
      //        continue;
      //      }
      //      if(!Globals.wxStrncmp(buff, wxPorting.T("power:"), 6)) {
      //        p = buff + 6;
      //        while(*p && *p == ' ') p.incPointer();
      //        t.power = power_parse(p);
      //        continue;
      //      }
      //      if(!Globals.wxStrncmp(buff, wxPorting.T("intermediate"), 12)) {
      //        p = buff + 12;
      //        t._intermediate = wxStrtol(p, &p, 10) != 0;
      //        t._nReservations = 0;
      //        continue;
      //      }
      //      if(!Globals.wxStrncmp(buff, wxPorting.T("dontstopshunters"), 16)) {
      //        t.flags |= TFLG_DONTSTOPSHUNTERS;
      //        continue;
      //      }
      //    }
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("(switchboard "), 13)) {
      //    p = buff + 13;
      //    if(wxStrchr(p, wxPorting.T(')')))
      //      *wxStrchr(p, wxPorting.T(')')) = 0;
      //    SwitchBoard* sb = CreateSwitchBoard(p);
      //    sb.Load(p);
      //    continue;
      //  }
      //  t = new Track();
      //  t.fgcolor = fieldcolors[COL_TRACK];
      //  ttype = buff[0];

      //  p = buff + 1;
      //  if(*p == wxPorting.T(',')) p.incPointer();
      //  t.x = wxStrtol(p, &p, 10);
      //  if(*p == wxPorting.T(',')) p.incPointer();
      //  t.y = wxStrtol(p, &p, 10);
      //  if(t.x >= ((XMAX - Configuration.HCOORDBAR) / Configuration.HGRID) ||
      //    t.y >= ((YMAX - Configuration.VCOORDBAR) / Configuration.VGRID))
      //    continue;
      //  if(*p == wxPorting.T(',')) p.incPointer();
      //  t.direction = (trkdir)wxStrtol(p, &p, 10);
      //  if(*p == wxPorting.T(',')) p.incPointer();
      //  if(!layout)
      //    layout = t;
      //  else
      //    lastTrack.next = t;
      //  lastTrack = t;
      //  t._lockedBy = 0;
      //  switch(ttype) {
      //    case wxPorting.T('0'):
      //      t.type = TRACK;
      //      t.isstation = (char)wxStrtol(p, &p, 10);
      //      if(*p == wxPorting.T(',')) p.incPointer();
      //      t.length = wxStrtol(p, &p, 10);
      //      if(!t.length)
      //        t.length = 1;
      //      if(*p == ',') p.incPointer();
      //      t.wlinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.wlinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      if(*p == '@') {
      //        int i;

      //        t.speed[0] = wxStrtol(p + 1, &p, 10);
      //        for(i = 1; i < NTTYPES && *p == '/'; ++i) {
      //          t.speed[i] = wxStrtol(p + 1, &p, 10);
      //        }
      //        if(*p == ',') p.incPointer();
      //      }
      //      if(!*p || !wxStrcmp(p, wxPorting.T("noname"))) {
      //        t.isstation = 0;
      //        break;
      //      }
      //      if(*p == '>') {
      //        p = parse_km(t, p + 1);
      //        if(*p == ',')
      //          p.incPointer();
      //      }
      //      t.station = String.Copy(p);
      //      break;

      //    case '1':
      //      t.type = SWITCH;
      //      t.length = 1;
      //      t.wlinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.wlinky = wxStrtol(p, &p, 10);
      //      if(*p == '@') {
      //        int i;

      //        t.speed[0] = wxStrtol(p + 1, &p, 10);
      //        for(i = 1; i < NTTYPES && *p == '/'; ++i) {
      //          t.speed[i] = wxStrtol(p + 1, &p, 10);
      //        }
      //        if(*p == ',') p.incPointer();
      //      }
      //      if(!*p || !wxStrcmp(p, wxPorting.T("noname")))
      //        break;
      //      if(*p == '>') {
      //        p = parse_km(t, p + 1);
      //        if(*p == ',')
      //          p.incPointer();
      //      }
      //      t.station = String.Copy(p);
      //      break;

      //    /* 2, x, y, type, linkx, linky [itinerary] */

      //    case '2':
      //      t.type = TSIGNAL;
      //      t.status = ST_RED;
      //      if((l = t.direction) & 2) {
      //        t.fleeted = 1;
      //        l &= ~2;
      //      }
      //      if(l & 0x100)
      //        t.fixedred = 1;
      //      if(l & 0x200)
      //        t.nopenalty = 1;
      //      if(l & 0x400)
      //        t.signalx = 1;
      //      if(l & 0x800)
      //        t.noClickPenalty = 1;
      //      l &= ~0xF00;
      //      t.direction = (trkdir)((int)t.direction & ~0xF00);

      //      switch(l) {
      //        case 0:
      //          t.direction = E_W;
      //          break;

      //        case 1:
      //          t.direction = W_E;
      //          break;

      //        case N_S:
      //        case S_N:
      //        case signal_SOUTH_FLEETED:
      //        case signal_NORTH_FLEETED:
      //          /* already there */
      //          t.direction = (trkdir)l;
      //          break;
      //      }
      //      t.wlinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.wlinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      if(*p == '@') {
      //        p1 = p + 1;
      //        p = wxStrchr(p1, ',');
      //        if(p)
      //          *p.incPointer() = 0;
      //        t.stateProgram = String.Copy(p1);
      //      }
      //      if(p && *p)			/* for itinerary definition */
      //        t.station = String.Copy(p);
      //      break;

      //    case '3':
      //      t.type = PLATFORM;
      //      if(t.direction == 0)
      //        t.direction = W_E;
      //      else
      //        t.direction = N_S;
      //      break;

      //    case '4':
      //      t.type = TEXT;
      //      t.station = String.Copy(p);
      //      for(l = 0; t.station[l] && t.station[l] != ','; ++l) ;
      //      t.station[l] = 0;
      //      while(*p && *p != ',') p.incPointer();
      //      if(*p == ',') p.incPointer();
      //      t.wlinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.wlinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinky = wxStrtol(p, &p, 10);
      //      if(*p == '>')
      //        p = parse_km(t, p.incPointer());
      //      break;

      //    case '5':
      //      t.type = IMAGE;
      //      if(*p == '@') {
      //        t.wlinkx = wxStrtol(p + 1, &p, 10);
      //        if(*p == ',') p.incPointer();
      //        t.wlinky = wxStrtol(p, &p, 10);
      //        if(*p == ',') p.incPointer();
      //      }
      //      t.station = String.Copy(p);
      //      break;

      //    case '6':			/* territory information */
      //      tl = (TextList*)malloc(sizeof(TextList));
      //      wxStrcat(p, wxPorting.T("n"));	/* put it back, since we removed it */
      //      tl.txt = String.Copy(p);
      //      if(!track_info)
      //        track_info = tl;
      //      else
      //        tlast.next = tl;
      //      tl.next = 0;
      //      tlast = tl;
      //      break;

      //    case '7':			/* itinerary */
      //      for(p1 = p; *p && *p != ','; p.incPointer()) ;
      //      if(!*p)
      //        break;
      //      *p.incPointer() = 0;
      //      it = (Itinerary*)calloc(sizeof(Itinerary), 1);
      //      it.name = String.Copy(p1);
      //      for(p1 = p, l = 0; *p && (*p != ',' || l); p.incPointer()) {
      //        if(*p == '(') ++l;
      //        else if(*p == ')') --l;
      //      }
      //      if(!*p)
      //        break;
      //      *p.incPointer() = 0;
      //      it.signame = String.Copy(p1);
      //      for(p1 = p, l = 0; *p && (*p != ',' || l); p.incPointer()) {
      //        if(*p == '(') ++l;
      //        else if(*p == ')') --l;
      //      }
      //      if(!*p)
      //        break;
      //      *p.incPointer() = 0;
      //      it.endsig = String.Copy(p1);
      //      if(*p == '@') {
      //        for(p1 = p.incPointer(), l = 0; *p && (*p != ',' || l); p.incPointer()) {
      //          if(*p == '(') ++l;
      //          else if(*p == ')') --l;
      //        }
      //        if(!*p)
      //          break;
      //        *p.incPointer() = 0;
      //        it.nextitin = String.Copy(p1);
      //      }
      //      l = 0;
      //      while(*p) {
      //        x = wxStrtol(p, &p, 0);
      //        if(*p != ',')
      //          break;
      //        y = wxStrtol(p + 1, &p, 0);
      //        if(*p != ',')
      //          break;
      //        sw = wxStrtol(p + 1, &p, 0);
      //        add_itinerary(it, x, y, sw);
      //        if(*p == ',') p.incPointer();
      //      }
      //      it.next = *itinList;	/* all ok, add to the list */
      //      *itinList = it;
      //      break;

      //    case '8':			/* itinerary placement */
      //      t.type = ITIN;
      //      t.station = String.Copy(p);
      //      break;

      //    case '9':
      //      t.type = TRIGGER;
      //      t.wlinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.wlinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinkx = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      t.elinky = wxStrtol(p, &p, 10);
      //      if(*p == ',') p.incPointer();
      //      for(l = 0; l < NTTYPES && *p != ','; ++l) {
      //        t.speed[l] = wxStrtol(p, &p, 10);
      //        if(*p == '/') p.incPointer();
      //      }
      //      if(*p == ',') p.incPointer();
      //      if(!*p || !wxStrcmp(p, wxPorting.T("noname")))
      //        break;
      //      t.station = String.Copy(p);
      //      break;
      //  }
      //}
      //return layout;
    }

    public static Track load_field(String name) {
      throw new NotImplementedException();
      //int l;
      //TextList tl;
      //Itinerary it;
      //Track t;

      //for(l = 0; l < 4; ++l) {
      //  e_train_pmap[l] = e_train_pmap_default[l];
      //  w_train_pmap[l] = w_train_pmap_default[l];
      //  e_car_pmap[l] = e_car_pmap_default[l];
      //  w_car_pmap[l] = w_car_pmap_default[l];
      //}
      //while((tl = track_info)) {
      //  track_info = tl.next;
      //  Globals.free(tl.txt);
      //  Globals.free(tl);
      //}
      //while((it = itineraries)) {
      //  itineraries = it.next;
      //  free_itinerary(it);
      //}
      //powerSpecified = false;
      //// No need to free the cache, since they're just string that can be re-used across layouts

      //free_scripts();
      //t = load_field_tracks(name, &itineraries);
      //sort_itineraries();
      //if(t) {
      //  link_all_tracks(t);
      //  link_signals(t);
      //  powerSpecified = power_specified(t);
      //  current_project = name;
      //}
      //layout_modified1 = 0;
      //return t;
    }

    public static Track find_track(Track layout, int x, int y) {
      throw new NotImplementedException();
      //while(layout) {
      //  if(layout.x == x && layout.y == y)
      //    return (layout);
      //  layout = layout.next;
      //}
      //return 0;
    }

    public static void link_signals(Track layout) {
      //TrackBase t;

      //for(t = layout; t; t = t.next)	    /* in case signal was relinked during edit */
      //  t.esignal = t.wsignal = 0;

      //for(t = layout; t; t = t.next) {

      //  /*	link signals with the track they control	*/

      //  if(t.type == TSIGNAL) {
      //    if(!(t.controls = findTrack(t.wlinkx, t.wlinky)))
      //      continue;
      //    if(t.direction == W_E || t.direction == S_N)
      //      t.controls.esignal = (Signal*)t;
      //    else
      //      t.controls.wsignal = (Signal*)t;
      //  }
      //}
    }

    public static void clean_pixmap_cache() {
      //int i;

      //for(i = 0; i < npixmaps; ++i)
      //  if(pixmaps[i].name) {
      //    Globals.free(pixmaps[i].name);
      //    delete_pixmap(pixmaps[i].pixels);
      //  }
      //npixmaps = 0;
      //for(i = 0; i < ncarpixmaps; ++i)
      //  if(carpixmaps[i].name) {
      //    Globals.free(carpixmaps[i].name);
      //    delete_pixmap(carpixmaps[i].pixels);
      //  }
      //ncarpixmaps = 0;
    }

    public static int get_pixmap_index(String mapname) {
      throw new NotImplementedException();
      //int i;

      //for(i = 0; i < npixmaps; ++i)
      //  if(!wxStrcmp(mapname, pixmaps[i].name))
      //    return i;
      //if(npixmaps >= maxpixmaps) {
      //  maxpixmaps += 10;
      //  if(!pixmaps)
      //    pixmaps = (pxmap*)malloc(sizeof(pxmap) * maxpixmaps);
      //  else
      //    pixmaps = (pxmap*)realloc(pixmaps, sizeof(pxmap) * maxpixmaps);
      //}
      //if(!(pixmaps[npixmaps].pixels = (string)get_pixmap_file(mapname)))
      //  return -1;          /* failed! file does not exist */
      //pixmaps[npixmaps].name = String.Copy(mapname);
      //return npixmaps++;
    }

    public static int get_carpixmap_index(String mapname) {
      throw new NotImplementedException();
      //int i;

      //for(i = 0; i < ncarpixmaps; ++i)
      //  if(!wxStrcmp(mapname, carpixmaps[i].name))
      //    return i;
      //if(ncarpixmaps >= maxcarpixmaps) {
      //  maxcarpixmaps += 10;
      //  if(!carpixmaps)
      //    carpixmaps = (pxmap*)malloc(sizeof(pxmap) * maxcarpixmaps);
      //  else
      //    carpixmaps = (pxmap*)realloc(carpixmaps, sizeof(pxmap) * maxcarpixmaps);
      //}
      //if(!(carpixmaps[ncarpixmaps].pixels = (string)get_pixmap_file(mapname)))
      //  return -1;          /* failed! file does not exist */
      //carpixmaps[ncarpixmaps].name = String.Copy(mapname);
      //return ncarpixmaps++;
    }

    public static void clean_trains(Train sched) {
      //Train t;

      //clean_pixmap_cache();
      //while(sched) {
      //  t = sched.next;
      //  delete sched;
      //  sched = t;
      //}
    }

    public static int trcmp(object a, object b) {
      throw new NotImplementedException();
      //const Train ap = *(Train**)a;
      //const Train bp = *(Train**)b;
      //if(ap.timein < bp.timein)
      //  return -1;
      //if(ap.timein > bp.timein)
      //  return 1;
      //return 0;
    }

    public static Train sort_schedule(Train sched) {
      throw new NotImplementedException();
      //Train** qb, t;
      //int ntrains;
      //int l;

      //for(t = sched, ntrains = 0; t; t = t.next)
      //  ++ntrains;
      //if(!ntrains)
      //  return sched;
      //qb = (Train**)malloc(sizeof(Train*) * ntrains);
      //for(t = sched, l = 0; l < ntrains; ++l, t = t.next)
      //  qb[l] = t;
      //qsort(qb, ntrains, sizeof(Train*), trcmp);
      //for(l = 0; l < ntrains - 1; ++l)
      //  qb[l].next = qb[l + 1];
      //qb[ntrains - 1].next = 0;
      //t = qb[0];
      //Globals.free(qb);
      //return t;
    }

    public static String convert_station(String p) {
      return (p);
    }

    public static Train cancelTrain(String p, Train sched) {
      throw new NotImplementedException();
      //Train t, t1;

      //t1 = 0;
      //for(t = sched; t && wxStrcmp(t.name, p); t = t.next)
      //  t1 = t;
      //if(!t)
      //  return sched;
      //if(t == sched)
      //  sched = t.next;
      //else
      //  t1.next = t.next;
      //Globals.free(t.name);
      //Globals.free(t);
      //return sched;
    }

    public static Train find_train(Train sched, string name) {
      throw new NotImplementedException();
      //Train t;

      //for(t = sched; t; t = t.next)
      //  if(!wxStrcmp(t.name, name))
      //    break;
      //return t;
    }

    private static Train sched;

    public static int scanline(String dst, int size, String ptr) {
      throw new NotImplementedException();
      //String p = ptr;
      //int c;

      //while((c = *p.incPointer()) && c != 'n') {
      //  if(c == 'r')
      //    continue;
      //  *dst++ = c;
      //  if(--size < 2) {
      //    *dst = 0;
      //    break;
      //  }
      //}
      //*ptr = p;
      //return c != 0;
    }

    private static string gtfs_dirname;
    private static string gtfs_filename;

    public static string build_gtfs_name(string fileName) {
      throw new NotImplementedException();
      //if(*gtfs_dirname)
      //  gtfs_filename = String.Format(wxPorting.T("%s/%s"), gtfs_dirname, fileName);
      //else
      //  gtfs_filename = string.Copy(fileName);
      //return gtfs_filename;
    }

    public static void get_fields(string dst, string src) {
      //int i;

      //for(i = 0; *src; ++i) {
      //  dst[i] = src;
      //  while(*src && *src != ',')
      //    ++src;
      //  if(!*src) {
      //    if(src != dst[i])
      //      ++i;
      //    break;
      //  }
      //  *src++ = 0;
      //}
      //dst[i] = 0;
    }

    public static Train read_gtfs(Train sched, string dirname) {
      throw new NotImplementedException();
      //string buff;
      //string[] fields = new string[32];
      //string p;
      //Train tr;
      //TrainStop stp;

      //while(*dirname == ' ' || *dirname == 't')
      //  ++dirname;
      //gtfs_dirname = dirname;
      //gtfs.Load(dirname);

      //// match routes with types

      //TDFile stops = new TDFile(build_gtfs_name(wxPorting.T("stop_times.txt")));
      //if(!stops.Load()) {
      //  // TODO: free stop
      //  return sched;
      //}
      //stops.ReadLine(buff, sizeof(buff) / sizeof(char));	// first line is fields names
      //// TODO: get field names positions in each record
      //while(stops.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //  get_fields(fields, buff);
      //  tr = find_train(sched, fields[0]);
      //  if(!tr) {
      //    tr = new Train();
      //    tr.name = String.Copy(fields[0]);
      //    tr.next = sched;
      //    tr.type = curtype;
      //    tr.epix = tr.wpix = -1;
      //    tr.ecarpix = tr.wcarpix = -1;
      //    sched = tr;
      //  }

      //  stp = (TrainStop*)calloc(1, sizeof(TrainStop));
      //  stp.minstop = 30;
      //  p = fields[1];
      //  stp.arrival = parse_time(&p);	/* arrival */
      //  p = fields[2];
      //  stp.departure = parse_time(&p);
      //  if(stp.departure == stp.arrival)
      //    stp.departure = stp.arrival + stp.minstop;
      //  else if(stp.minstop > stp.departure - stp.arrival)
      //    stp.minstop = stp.departure - stp.arrival;
      //  stp.station = String.Copy(fields[3]);
      //  if(!tr.stops)
      //    tr.stops = stp;
      //  else
      //    tr.laststop.next = stp;
      //  tr.laststop = stp;
      //}
      //for(tr = sched; tr; tr = tr.next) {
      //  if(!tr.entrance && !tr.exit && tr.stops) {
      //    stp = tr.stops;
      //    tr.stops = tr.stops.next;
      //    tr.entrance = stp.station;
      //    tr.timein = stp.departure;
      //    Globals.free(stp);
      //    TrainStop* ostop = 0;
      //    for(stp = tr.stops; stp && stp != tr.laststop; stp = stp.next)
      //      ostop = stp;
      //    tr.exit = tr.laststop.station;
      //    tr.timeout = tr.laststop.arrival;
      //    tr.laststop = ostop;
      //    if(ostop)
      //      ostop.next = 0;
      //    else
      //      tr.stops = 0;
      //    if(stp) {
      //      Globals.free(stp);
      //    } else {
      //      ostop = 0;
      //    }
      //  }
      //}

      //GTFS_Route[] selected = new GTFS_Route[Configuration.NTTYPES];
      //int nSelected = 0;
      //GTFS_Route route;
      //int s, r;

      //GTFS_Trip trip;
      //int x;

      //// find the subset of routes used in the schedule
      //// and with different colors
      //for(x = 0; x < gtfs._trips.Length(); ++x) {
      //  trip = gtfs._trips.At(x);
      //  if(gtfs.IgnoreRoute(trip._routeId))
      //    continue;
      //  route = gtfs.FindRouteById(trip._routeId);
      //  if(!route)
      //    continue;
      //  for(s = 0; s < nSelected; ++s)
      //    if(selected[s]._routeColor == route._routeColor)
      //      break;
      //  if(s >= nSelected && nSelected < NTTYPES) {
      //    selected[nSelected++] = route;
      //  }
      //}

      //for(x = 0; x < gtfs._trips.Length(); ++x) {
      //  trip = gtfs._trips.At(x);
      //  tr = find_train(sched, trip._tripId);
      //  if(!tr)             // impossible
      //    continue;
      //  if(gtfs.IgnoreRoute(trip._routeId)) {
      //    tr.isExternal = 1;
      //    continue;
      //  }
      //  GTFS_Calendar* calEntry = gtfs.FindCalendarByService(trip._serviceId);
      //  if(calEntry)
      //    tr.days = calEntry.GetMask();
      //  // set type based on routeId
      //  route = gtfs.FindRouteById(trip._routeId);
      //  if(!route)
      //    continue;
      //  for(r = 0; r < nSelected; ++r) {
      //    if(selected[r]._routeColor == route._routeColor) {
      //      tr.type = r;
      //      break;
      //    }
      //  }
      //}
      //return sched;
    }

    public static String parse_delay(String p, TDDelay del) {
      throw new NotImplementedException();
      //del.nDelays = 0;
      //do {
      //  int secs = wxStrtoul(p, &p, 0);
      //  if(*p == '/')
      //    p.incPointer();
      //  int prob = wxStrtoul(p, &p, 0);
      //  if(del.nDelays < MAX_DELAY) {
      //    del.prob[del.nDelays] = prob;
      //    del.seconds[del.nDelays] = secs;
      //    ++del.nDelays;
      //  }
      //} while(*p && *p.incPointer() == ',');
      //return p;
    }

    public static Train parse_newformat(TDFile schFile) {
      throw new NotImplementedException();
      //Train t;
      //TrainStop stp;
      //string buff;
      //int l;
      //String p;
      //String fileinc;
      //String nw, ne;
      //object pmw, pme;

      //t = 0;
      //while(schFile.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //  if(!buff[0] || buff[0] == '#')
      //    continue;
      //  if(buff[0] == '.') {
      //    t = 0;
      //    continue;
      //  }
      //  for(l = 0; buff[l]; ++l)
      //    if(buff[l] == 't')
      //      buff[l] = ' ';
      //  while(l && (buff[l - 1] == ' ' || buff[l - 1] == 't')) --l;
      //  buff[l] = 0;
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Include: "), 9)) {
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
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Routes:"), 7)) {
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    gtfs.SetOurRoutes(p);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("GTFS:"), 5)) {
      //    for(p = buff + 5; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    sched = read_gtfs(sched, p);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Cancel:"), 7)) {
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    sched = cancelTrain(p, sched);
      //    t = 0;
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Today: "), 7)) {
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    for(l = 0; p[0] >= '0' && p[0] <= '9'; p.incPointer())
      //      l |= 1 << (*p - '1');
      //    run_day = l;
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Start: "), 7)) {
      //    p = buff + 7;
      //    current_time = start_time = parse_time(&p);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Train: "), 7)) {
      //    t = find_train(sched, buff + 7);
      //    if(t)
      //      continue;
      //    t = new Train();
      //    t.name = String.Copy(buff + 7);
      //    t.next = sched;
      //    t.type = curtype;
      //    t.epix = t.wpix = -1;
      //    t.ecarpix = t.wcarpix = -1;
      //    sched = t;
      //    continue;
      //  }
      //  if(!t) {
      //    if(!Globals.wxStrncmp(buff, wxPorting.T("Type: "), 6)) {
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      curtype = l;
      //      if(!p)
      //        continue;
      //      while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //      if(!*p)
      //        continue;
      //      if(p[0] == '+') {
      //        startDelay[curtype] = wxStrtol(p.incPointer(), &p, 10);
      //      }
      //      if(p[0] == '>') {
      //        accelRate[curtype] = wxAtof(p.incPointer());
      //        while(*p && *p != ' ' && *p != 't')
      //          p.incPointer();
      //      }
      //      while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //      if(!*p)
      //        continue;
      //      nw = p;
      //      while(*p && *p != ' ' && *p != 't') p.incPointer();
      //      if(!*p)
      //        continue;
      //      *p.incPointer() = 0;
      //      while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //      ne = p;
      //      while(*p && *p != ' ' && *p != 't') p.incPointer();
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
      //      while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //      ne = p;
      //      while(*p && *p != ' ' && *p != 't') p.incPointer();
      //      l = *p;
      //      *p.incPointer() = 0;
      //      if(!(pmw = get_pixmap_file(locase(ne))))
      //        continue;
      //      w_car_pmap[curtype] = pmw;
      //      e_car_pmap[curtype] = pmw;
      //      if(!l)
      //        continue;
      //      while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //      if(!*p)
      //        continue;
      //      if(!(pme = get_pixmap_file(locase(p))))
      //        continue;
      //      e_car_pmap[curtype] = pme;
      //      continue;
      //    }
      //    if(!Globals.wxStrncmp(buff, wxPorting.T("Power:"), 6)) {
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      powerType[l] = power_parse(p);
      //      continue;
      //    }
      //    if(!Globals.wxStrncmp(buff, wxPorting.T("Gauge:"), 6)) {
      //      if((l = wxStrtol(buff + 6, &p, 0) - 1) >= NTTYPES || l < 0)
      //        continue;
      //      gauge[l] = wxAtof(p);
      //      continue;
      //    }
      //    continue;
      //  }
      //  p = buff;
      //  while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Wait: "), 6)) {
      //    p += 6;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    for(nw = p; *nw && *nw != ' '; ++nw) ;
      //    if(*nw)
      //      *nw++ = 0;
      //    else
      //      nw = 0;
      //    t.waitfor = String.Copy(p);
      //    t.waittime = nw ? wxAtoi(nw) : 60;
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("StartDelay: "), 12)) {
      //    t.myStartDelay = wxAtoi(p + 12);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("AccelRate: "), 11)) {
      //    t.accelRate = wxAtof(p + 11);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Power:"), 6)) {
      //    t.power = power_parse(buff + 6);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(buff, wxPorting.T("Gauge:"), 6)) {
      //    t.gauge = wxAtof(buff + 6);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("When: "), 6)) {
      //    for(p += 6; p[0] == ' '; p.incPointer()) ;
      //    for(l = 0; p[0] >= '0' && p[0] <= '9'; p.incPointer())
      //      l |= 1 << (*p - '1');
      //    t.days = l;
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Speed: "), 7)) {
      //    t.maxspeed = wxAtoi(p + 7);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Type: "), 6)) {
      //    if((l = wxStrtol(p + 6, &p, 0)) - 1 < NTTYPES)
      //      t.type = l - 1;
      //    if(!p || !*p)
      //      continue;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if(!*p)
      //      continue;
      //    nw = p;
      //    while(*p && *p != ' ' && *p != 't') p.incPointer();
      //    if(!*p)
      //      continue;
      //    *p.incPointer() = 0;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if((t.wpix = get_pixmap_index(locase(nw))) < 0)
      //      continue;
      //    t.epix = get_pixmap_index(locase(p));
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Stock: "), 7)) {
      //    t.stock = String.Copy(p + 7);
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Length: "), 8)) {
      //    t.length = wxStrtol(p + 8, &p, 0);
      //    t.entryLength = t.length;
      //    t.tail = (Train*)calloc(sizeof(Train), 1);
      //    t.ecarpix = t.wcarpix = -1;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if(!*p)
      //      continue;
      //    ne = p;
      //    while(*p && *p != ' ' && *p != 't') p.incPointer();
      //    l = *p;
      //    *p.incPointer() = 0;
      //    t.ecarpix = t.wcarpix = get_carpixmap_index(locase(ne));
      //    if(!l)
      //      continue;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if(!*p)
      //      continue;
      //    t.wcarpix = get_carpixmap_index(locase(p));
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Enter: "), 7)) {
      //    p += 7;
      //    t.timein = parse_time(&p);
      //    if(p[0] == DELAY_CHAR) {
      //      t.entryDelay = (TDDelay*)calloc(sizeof(TDDelay), 1);
      //      p = parse_delay(p.incPointer(), t.entryDelay);
      //    }
      //    if(p[0] == ',') p.incPointer();
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    t.entrance = String.Copy(convert_station(p));
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Notes: "), 7)) {
      //    p += 7;
      //    if(t.nnotes < MAXNOTES)
      //      t.notes[t.nnotes++] = String.Copy(p);
      //    continue;
      //  }
      //  if(!wxStrcmp(p, wxPorting.T("Script:"))) {
      //    String scr;
      //    while(schFile.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //      if(!buff[0] || buff[0] == '#')
      //        continue;
      //      if(!wxStrcmp(buff, wxPorting.T("EndScript"))) {
      //        break;
      //      }
      //      wxStrcat(buff, wxPorting.T("n"));
      //      scr += buff;
      //    }
      //    t.stateProgram = String.Copy(scr);
      //    continue;
      //  }
      //  stp = (TrainStop*)malloc(sizeof(TrainStop));
      //  memset(stp, 0, sizeof(TrainStop));
      //  stp.minstop = 30;
      //  if(p[0] == '-') {		/* doesn't stop */
      //    while(*p.incPointer() == ' ' || p[0] == 't') ;
      //    stp.minstop = 0;
      //  } else if(p[0] == '+') {	// arrival: delta from previous departure
      //    p.incPointer();
      //    l = wxStrtoul(p, &p, 10);
      //    if(!t.stops)
      //      l += t.timein;
      //    else
      //      l += t.laststop.departure;
      //  } else
      //    l = parse_time(&p);	/* arrival */
      //  if(p[0] == '+') {
      //    p.incPointer();
      //    stp.minstop = wxStrtoul(p, &p, 10);
      //  }
      //  if(p[0] == ',') p.incPointer();
      //  while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //  if(p[0] == '-') {
      //    Globals.free(stp);
      //    if(t.exit)		/* already processed exit point! */
      //      continue;
      //    t.timeout = l;
      //    while(*p.incPointer() == ' ' || p[0] == 't') ;
      //    if(p[0] == ',') p.incPointer();
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    t.exit = String.Copy(convert_station(p));
      //    continue;
      //  }
      //  if(p[0] == '+') {
      //    stp.departure = wxStrtoul(p + 1, &p, 10);
      //    if(stp.departure < stp.minstop)
      //      stp.departure = stp.minstop;
      //    if(!stp.minstop) {	// doesn't stop
      //      if(!t.stops)
      //        l = t.timein;
      //      else
      //        l = t.laststop.departure;
      //    }
      //    stp.departure += l;
      //  } else
      //    stp.departure = parse_time(&p);
      //  if(!stp.minstop)
      //    stp.arrival = stp.departure;
      //  else {
      //    stp.arrival = l;
      //    if(stp.departure == stp.arrival)  //
      //      stp.departure = stp.arrival + stp.minstop;
      //    else if(stp.minstop > stp.departure - stp.arrival)	// +Rask Ingemann Lambertsen
      //      stp.minstop = stp.departure - stp.arrival;	// +Rask Ingemann Lambertsen
      //  }
      //  if(p[0] == DELAY_CHAR) {
      //    stp.depDelay = (TDDelay*)calloc(sizeof(TDDelay), 1);
      //    p = parse_delay(p.incPointer(), stp.depDelay);
      //  }
      //  if(p[0] == ',') p.incPointer();
      //  while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //  stp.station = String.Copy(convert_station(p));
      //  if(!t.stops)
      //    t.stops = stp;
      //  else
      //    t.laststop.next = stp;
      //  t.laststop = stp;
      //}
      //return sched;
    }

    public static void check_delayed_entries(Train sched) {

      //Train t, t1;
      //Track trk, tk1;
      //int firsttime = 1;
      //int i;
      //string buff;

      ///*  Check entrance conflicts */

      //for(t = sched; t; t = t.next) {
      //  if(t.isExternal)
      //    continue;
      //  for(t1 = t.next; t1; t1 = t1.next) {
      //    if(t1.isExternal)
      //      continue;
      //    if(t.timein != t1.timein)
      //      continue;
      //    if(t.days && t1.days && run_day)
      //      if(!(t.days & t1.days & run_day))
      //        continue;
      //    if(wxStrcmp(t.entrance, t1.entrance))
      //      continue;
      //    for(trk = layout; trk; trk = trk.next)
      //      if(trk.type == TRACK && trk.isstation &&
      //        !wxStrcmp(t.entrance, trk.station))
      //        break;
      //    if(trk)
      //      continue;
      //    if(firsttime) {
      //      Globals.traindir.layout_error(wxPorting.L("These trains will be delayed on entry:"));
      //      Globals.traindir.layout_error(wxPorting.T("n"));
      //    }
      //    firsttime = 0;
      //    buff = String.Format(wxPorting.L("%s and %s both enter at %s on %s"),
      //      t.name, t1.name, t.entrance, format_time(t.timein));
      //    wxStrcat(buff, wxPorting.T("n"));
      //    Globals.traindir.layout_error(buff);
      //  }
      //}
      //firsttime = 1;
      //for(t = sched; t; t = t.next) {
      //  if(t.isExternal)
      //    continue;
      //  trk = findStationNamed(t.entrance);
      //  if(!trk) {
      //    buff = String.Copy(t.entrance);
      //    for(i = 0; buff[i] && buff[i] != ' '; ++i) ;
      //    buff[i] = 0;
      //    trk = findStationNamed(buff);
      //  }
      //  tk1 = findStationNamed(t.exit);
      //  if(!tk1) {
      //    buff = String.Copy(t.exit);
      //    for(i = 0; buff[i] && buff[i] != ' '; ++i) ;
      //    buff[i] = 0;
      //    tk1 = findStationNamed(buff);
      //  }
      //  if(trk && tk1)
      //    continue;
      //  if(firsttime) {
      //    Globals.traindir.layout_error(wxPorting.L("These trains have unknown entry or exit points:"));
      //    Globals.traindir.layout_error(wxPorting.T("n"));
      //  }
      //  firsttime = 0;
      //  buff = String.Format(wxPorting.L("%s enters from '%s', exits at '%s'"),
      //                     t.name, t.entrance, t.exit);
      //  wxStrcat(buff, wxPorting.T("n"));
      //  Globals.traindir.layout_error(buff);
      //}
      //Globals.traindir.end_layout_error();
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

    private static void resolve_path(Train t) {
    //  Path pt, pth;
    //  TrainStop ts, tt;
    //  long t0;
    //  int f1;

    //  if(findStationNamed(t.entrance)) {
    //    f1 = 1;
    //    goto xit;
    //  }
    //  f1 = 0;
    //  for(ts = t.stops; ts; ts = ts.next) {
    //    if((pt = find_path(t.entrance, ts.station))) {
    //      t.entrance = String.Copy(pt.enter);
    //      t.timein = ts.arrival - pt.times[t.type];
    //      f1 = 1;
    //      goto xit;
    //    }
    //  }
    //  for(tt = t.stops; tt; tt = tt.next) {
    //    for(ts = tt.next; ts; ts = ts.next) {
    //      if((pt = find_path(tt.station, ts.station))) {
    //        t.entrance = String.Copy(pt.enter);
    //        t.timein = ts.arrival - pt.times[t.type];
    //        f1 = 1;
    //        goto xit;
    //      }
    //    }
    //  }

    //xit:
    //  if(f1 && t.timein < 0)         // first stop is close to midnight but path time is longer
    //    t.timein += 24 * 60 * 60;  // so move time in to the end of this day
    //  if(findStationNamed(t.exit)) {
    //    if(f1)			// both entrance and exit in layout
    //      return;
    //    pth = 0;
    //    for(tt = t.stops; tt; tt = tt.next)
    //      if((pt = find_path(tt.station, t.exit)))
    //        pth = pt;
    //    if(!pth)
    //      pth = find_path(t.entrance, t.exit);
    //    if(!pth)
    //      return;
    //    t.entrance = String.Copy(pth.enter);
    //    t.timein = t.timeout - pth.times[t.type];
    //    if(t.timein < 0)
    //      t.timein += 24 * 60 * 60;
    //    return;
    //  }
    //  pth = 0;
    //  for(tt = t.stops; tt; tt = tt.next) {
    //    for(ts = tt.next; ts; ts = ts.next) {
    //      if((pt = find_path(tt.station, ts.station))) {
    //        t0 = tt.departure;
    //        pth = pt;
    //      }
    //    }
    //  }
    //  for(ts = t.stops; ts; ts = ts.next)
    //    if((pt = find_path(ts.station, t.exit))) {
    //      t0 = ts.departure;
    //      pth = pt;
    //    }
    //  if(pth) {
    //    t.exit = String.Copy(pth.enter);
    //    t.timeout = t0 + pth.times[t.type];
    //    return;
    //  }
    //  if(!f1)
    //    return;
    //  for(ts = t.stops; ts; ts = ts.next)
    //    if((pt = find_path(t.entrance, ts.station))) {
    //      t.exit = String.Copy(pt.enter);
    //      t.timeout = t.timein + pt.times[t.type];
    //      return;
    //    }
    //  if((pt = find_path(t.entrance, t.exit))) {
    //    t.exit = String.Copy(pt.enter);
    //    t.timeout = t.timein + pt.times[t.type];
    //  }
    }

    public static void resolve_paths(Train schedule) {
      //Train t;

      //if(!paths)
      //  return;
      //for(t = schedule; t; t = t.next)
      //  resolve_path(t);
    }

    public static void load_paths(String name) {
      //Path pt;
      //string buff;
      //int l;
      //String p, p1;
      //int errors;

      //while(paths) {
      //  pt = paths.next;
      //  if(paths.from) Globals.free(paths.from);
      //  if(paths.to) Globals.free(paths.to);
      //  if(paths.enter) Globals.free(paths.enter);
      //  Globals.free(paths);
      //  paths = pt;
      //}

      //TDFile pthFile = new TDFile(name);

      //pthFile.SetExt(wxPorting.T(".pth"));
      //if(!pthFile.Load())
      //  return;
      //pt = 0;
      //errors = 0;
      //while(pthFile.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //  p = skipblk(buff);
      //  if(!*p || p[0] == '#')
      //    continue;
      //  if(!wxStrcmp(p, wxPorting.T("Path:"))) {
      //    if(pt) {			/* end previous entry */
      //      if(!pt.from || !pt.to || !pt.enter) {
      //        ++errors;
      //        paths = pt.next;	/* ignore last entry */
      //        Globals.free(pt);
      //      }
      //    }
      //    p += 5;
      //    pt = (Path*)calloc(sizeof(Path), 1);
      //    pt.next = paths;
      //    paths = pt;
      //    continue;
      //  }
      //  if(!Globals.wxStrncmp(p, wxPorting.T("From: "), 6))
      //    pt.from = String.Copy(skipblk(p + 6));
      //  if(!Globals.wxStrncmp(p, wxPorting.T("To: "), 4))
      //    pt.to = String.Copy(skipblk(p + 4));
      //  if(!Globals.wxStrncmp(p, wxPorting.T("Times: "), 7)) {
      //    p += 7;
      //    for(p1 = p; *p1 && *p1 != ' '; ++p1) ;
      //    if(!*p1)			/* no entry point! */
      //      continue;
      //    *p1++ = 0;
      //    for(l = 0; l < NTTYPES; ++l) {
      //      pt.times[l] = wxStrtol(p, &p, 10) * 60;
      //      if(p[0] == '/' || p[0] == ',') p.incPointer();
      //    }
      //    p = skipblk(p1);
      //    pt.enter = String.Copy(p);
      //  }
      //}
    }

    public static bool load_trains_from_gtfs() {
      throw new NotImplementedException();
      //gtfs = new GTFS();
      //return gtfs.Load(dirPath);
    }

    public static Train load_trains(String name) {
      throw new NotImplementedException();
      //Train t;
      //TrainStop stp;
      //string buff;
      //int l;
      //String p, p1;
      //int newformat;

      //sched = 0;
      //newformat = 0;
      //start_time = 0;
      //curtype = 0;
      //memset(startDelay, 0, sizeof(startDelay));
      //for(int i = 0; i < NTTYPES; ++i) { // 3.9
      //  powerType[i] = 0;
      //  gauge[i] = 0;
      //}

      //if(gtfs)
      //  Globals.delete(gtfs);
      //gtfs = new GTFS();

      //TDFile schFile = new TDFile(name);
      //schFile.SetExt(wxPorting.T(".sch"));
      //schFile.GetDirName(dirPath, sizeof(dirPath) / sizeof(char));
      //if(!schFile.Load()) {
      //  if(!load_trains_from_gtfs())
      //    return 0;
      //} else while(schFile.ReadLine(buff, sizeof(buff) / sizeof(char))) {
      //    if(!buff[0])
      //      continue;
      //    if(newformat || !wxStrcmp(buff, wxPorting.T("#!trdir"))) {
      //      newformat = 1;
      //      t = parse_newformat(schFile);
      //      if(!t)
      //        continue;
      //      sched = t;
      //      continue;
      //    }
      //    if(buff[0] == '#')
      //      continue;
      //    t = new Train();
      //    t.next = sched;
      //    sched = t;
      //    for(p = buff; *p && *p != ','; p.incPointer()) ;
      //    if(!*p)
      //      continue;
      //    *p.incPointer() = 0;
      //    t.name = String.Copy(buff);
      //    t.status = train_READY;
      //    t.direction = t.sdirection = (trkdir)wxStrtol(p, &p, 10);
      //    if(p[0] == ',') p.incPointer();
      //    t.timein = parse_time(&p);
      //    if(p[0] == ',') p.incPointer();
      //    p1 = p;
      //    while(*p && *p != ',') p.incPointer();
      //    if(!*p)
      //      continue;
      //    *p.incPointer() = 0;
      //    t.entrance = String.Copy(p1);
      //    t.timeout = parse_time(&p);
      //    if(p[0] == ',') p.incPointer();
      //    p1 = p;
      //    while(*p && *p != ',') p.incPointer();
      //    if(!*p)
      //      continue;
      //    *p.incPointer() = 0;
      //    t.exit = String.Copy(p1);
      //    t.maxspeed = wxStrtol(p, &p, 10);
      //    if(p[0] == ',') p.incPointer();
      //    while(*p) {
      //      for(p1 = p; *p && *p != ','; p.incPointer()) ;
      //      if(!*p)
      //        continue;
      //      *p.incPointer() = 0;
      //      stp = (TrainStop*)malloc(sizeof(TrainStop));
      //      memset(stp, 0, sizeof(TrainStop));
      //      if(!t.stops)
      //        t.stops = stp;
      //      else
      //        t.laststop.next = stp;
      //      t.laststop = stp;
      //      stp.station = String.Copy(p1);
      //      stp.arrival = parse_time(&p);
      //      if(p[0] == ',') p.incPointer();
      //      stp.departure = parse_time(&p);
      //      if(p[0] == ',') p.incPointer();
      //      stp.minstop = wxStrtol(p, &p, 10);
      //      if(p[0] == ',') p.incPointer();
      //    }
      //  }

      ///* check correctness of schedule */

      //l = 0;
      //for(t = sched; t; t = t.next) {
      //  if(!t.exit) {
      //    t.exit = String.Copy(wxPorting.T("?"));
      //    ++l;
      //  }
      //  if(!t.entrance) {
      //    t.entrance = String.Copy(wxPorting.T("?"));
      //    ++l;
      //  }
      //}
      //if(l)
      //  Globals.traindir.Error(wxPorting.L("Some train has unknown entry/exit point!"));

      //// 3.9: propagate motive power

      //for(t = sched; t; t = t.next) {
      //  if(t.power)
      //    continue;
      //  t.power = powerType[t.type]; // either null or real power spec.
      //}

      //load_paths(name);
      //resolve_paths(sched);

      //sched = sort_schedule(sched);

      //for(t = sched; t; t = t.next)
      //  if(t.stateProgram)
      //    t.ParseProgram();

      //return sched;
    }

    /* ================================= */

    public static int save_layout(String name, Track layout) {
      throw new NotImplementedException();
      //wxFFile file;
      //Track* t;
      //TextList* tl;
      //Itinerary* it;
      //int i;
      //int ch;

      //if(!file_create(name, wxPorting.T(".trk"), file))
      //  return 0;
      //for(t = layout; t; t = t.next) {
      //  switch(t.type) {
      //    case TRACK:
      //      file.Write(String.Format(wxPorting.T("0,%d,%d,%d,"), t.x, t.y, t.direction));
      //      file.Write(String.Format(wxPorting.T("%d,%d,"), t.isstation, t.length));
      //      file.Write(String.Format(wxPorting.T("%d,%d,%d,%d,"), t.wlinkx, t.wlinky,
      //            t.elinkx, t.elinky));
      //      if(t.speed[0]) {
      //        ch = '@';

      //        for(i = 0; i < NTTYPES; ++i) {
      //          file.Write(String.Format(wxPorting.T("%c%d"), ch, t.speed[i]));
      //          ch = '/';
      //        }
      //        file.Write(wxPorting.T(','));
      //      }
      //      if(t.km)
      //        file.Write(String.Format(wxPorting.T(">%d.%d,"), t.km / 1000, t.km % 1000));
      //      if(t.isstation && t.station)
      //        file.Write(String.Format(wxPorting.T("%sn"), t.station));
      //      else
      //        file.Write(String.Format(wxPorting.T("nonamen")));
      //      break;

      //    case SWITCH:
      //      file.Write(String.Format(wxPorting.T("1,%d,%d,%d,"), t.x, t.y, t.direction));
      //      file.Write(String.Format(wxPorting.T("%d,%d"), t.wlinkx, t.wlinky));
      //      if(t.speed[0]) {
      //        ch = '@';

      //        for(i = 0; i < NTTYPES; ++i) {
      //          file.Write(String.Format(wxPorting.T("%c%d"), ch, t.speed[i]));
      //          ch = '/';
      //        }
      //        file.Write(wxPorting.T(','));
      //      }
      //      if(t.km)
      //        file.Write(String.Format(wxPorting.T(">%d.%d,"), t.km / 1000, t.km % 1000));
      //      if(t.isstation && t.station)
      //        file.Write(String.Format(wxPorting.T("%sn"), t.station));
      //      else
      //        file.Write(String.Format(wxPorting.T("nonamen")));
      //      break;

      //    case TSIGNAL:
      //      file.Write(String.Format(wxPorting.T("2,%d,%d,%d,"), t.x, t.y,
      //        t.direction + t.fleeted * 2 +
      //        (t.fixedred << 8) +
      //        (t.nopenalty << 9) + (t.signalx << 10) +
      //        (t.noClickPenalty << 11)));
      //      file.Write(String.Format(wxPorting.T("%d,%d"), t.wlinkx, t.wlinky));
      //      if(t.stateProgram) {
      //        for(i = Globals.wxStrlen(t.stateProgram); i >= 0; --i)
      //          if(t.stateProgram[i] == '/' || t.stateProgram[i] == '\\')
      //            break;
      //        file.Write(String.Format(wxPorting.T(",@%s"), t.stateProgram + i + 1));
      //      }
      //      if(t.station && *t.station)	/* for itineraries */
      //        file.Write(String.Format(wxPorting.T(",%s"), t.station));
      //      file.Write(String.Format(wxPorting.T("n")));
      //      break;

      //    case PLATFORM:
      //      file.Write(String.Format(wxPorting.T("3,%d,%d,%dn"), t.x, t.y, t.direction == W_E ? 0 : 1));
      //      break;

      //    case TEXT:
      //      file.Write(String.Format(wxPorting.T("4,%d,%d,%d,%s,"), t.x, t.y, t.direction, t.station));
      //      file.Write(String.Format(wxPorting.T("%d,%d,%d,%d"), t.wlinkx, t.wlinky,
      //              t.elinkx, t.elinky));
      //      if(t.km)
      //        file.Write(String.Format(wxPorting.T(">%d.%d"), t.km / 1000, t.km % 1000));
      //      file.Write(String.Format(wxPorting.T("n")));
      //      break;

      //    case IMAGE:
      //      if(!t.station)
      //        t.station = String.Copy(wxPorting.T(""));
      //      for(i = Globals.wxStrlen(t.station); i >= 0; --i)
      //        if(t.station[i] == '/' || t.station[i] == '\\')
      //          break;
      //      if(t.wlinkx && t.wlinky)
      //        file.Write(String.Format(wxPorting.T("5,%d,%d,0,@%d,%d,%sn"), t.x, t.y,
      //                             t.wlinkx, t.wlinky, t.station + i + 1));
      //      else
      //        file.Write(String.Format(wxPorting.T("5,%d,%d,0,%sn"), t.x, t.y, t.station + i + 1));
      //      break;

      //    case ITIN:
      //      file.Write(String.Format(wxPorting.T("8,%d,%d,%d,%sn"), t.x, t.y, t.direction, t.station));
      //      break;

      //    case TRIGGER:
      //      file.Write(String.Format(wxPorting.T("9,%d,%d,%d,"), t.x, t.y, t.direction));
      //      file.Write(String.Format(wxPorting.T("%d,%d,%d,%d"), t.wlinkx, t.wlinky,
      //            t.elinkx, t.elinky));
      //      ch = ',';
      //      for(i = 0; i < NTTYPES; ++i) {
      //        file.Write(String.Format(wxPorting.T("%c%d"), ch, t.speed[i]));
      //        ch = '/';
      //      }
      //      file.Write(String.Format(wxPorting.T(",%sn"), t.station));
      //      break;
      //  }
      //}
      //for(tl = track_info; tl; tl = tl.next)
      //  file.Write(String.Format(wxPorting.T("6,0,0,0,%sn"), tl.txt));

      //for(it = itineraries; it; it = it.next) {
      //  file.Write(String.Format(wxPorting.T("7,0,0,0,%s,%s,%s,"), it.name,
      //      it.signame, it.endsig));
      //  if(it.nextitin)
      //    file.Write(String.Format(wxPorting.T("@%s,"), it.nextitin));
      //  for(i = 0; i < it.nsects; ++i)
      //    file.Write(String.Format(wxPorting.T("%d,%d,%d,"), it.sw[i].x, it.sw[i].y,
      //          it.sw[i].switched));
      //  file.Write(String.Format(wxPorting.T("n")));
      //}

      //for(t = layout; t; t = t.next) {
      //  switch(t.type) {
      //    case ITIN:
      //    case IMAGE:

      //      if(t._flashingIcons[0]) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dnicons:"), t.x, t.y));
      //        for(int x = 0; ; ) {
      //          file.Write(t._flashingIcons[x]);
      //          ++x;
      //          if(x >= MAX_FLASHING_ICONS || !t._flashingIcons[x])
      //            break;
      //          file.Write(wxPorting.T(","));
      //        }
      //        file.Write(wxPorting.T("n)n"));
      //      }

      //    case TRACK:
      //    case SWITCH:
      //    case TRIGGER:

      //      if(t.stateProgram) {
      //        file.Write(String.Format(wxPorting.T("(script %d,%dn%s)n"), t.x, t.y, t.stateProgram));
      //      }
      //      if(t.power && *t.power) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dnpower:%sn)n"), t.x, t.y, t.power));
      //      }
      //      if(t.gauge) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dngauge:%sn)n"), t.x, t.y, t.gauge));
      //      }

      //    case TSIGNAL:
      //      if((long)t._lockedBy == (long)0xcdcdcdcd) {
      //        t._lockedBy = 0;
      //      }
      //      if(t._lockedBy) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dnlocked %sn)n"), t.x, t.y, t._lockedBy));
      //      }
      //      if(t.flags & TFLG_DONTSTOPSHUNTERS) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dndontstopshuntersn)n"), t.x, t.y));
      //      }
      //      if(t._intermediate) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dnintermediate %dn)n"),
      //            t.x, t.y, t._intermediate));
      //      }
      //    // fall through

      //    case TEXT:
      //      if(t.invisible) {
      //        file.Write(String.Format(wxPorting.T("(attributes %d,%dnhiddenn)n"), t.x, t.y));
      //      }
      //      continue;
      //  }
      //}

      //SaveSwitchBoards(file);

      //file.Close();
      //layout_modified1 = 0;
      //return 1;
    }

    private static int MAXSHORTNAME = 10;

    private static void short_station_name(String d, String s) {
      //int i;

      //for(i = 0; *s && *s != ' ' && i < MAXSHORTNAME - 1; ++i)
      //  *d++ = *s++;
      //*d = 0;
    }

    public enum OutFormat {
      OUT_wxHTML = 0,
      OUT_TEXT = 1,
      OUT_HTML = 2
    }

    public static void schedule_status_print(HtmlPage page, OutFormat outFormat) {
      //String buff;
      //String[] buffs = new string[9];
      //String[] cols = new string[9];
      //Train t;
      //TrainStop ts;
      //String eol;

      //if(outFormat == OUT_TEXT) {
      //  *page.content = wxPorting.T("");
      //  eol = wxPorting.T("n");
      //} else {
      //  eol = wxPorting.T("<br>n");
      //  page.StartPage(wxPorting.L("Simulation results"));
      //  page.AddCenter();
      //  page.AddLine(wxPorting.T("<table><tr><td valign=top>"));
      //}
      //buff = String.Format(wxPorting.T("%s : %s%s"), wxPorting.L("Time"), format_time(current_time), eol);
      //page.Add(buff);
      //if(run_day) {
      //  buff = String.Format(wxPorting.T("%s : %s%s"), wxPorting.L("Day"), format_day(run_day), eol);
      //  page.Add(buff);
      //}
      //buff = String.Format(wxPorting.T("%s : %ld%s"), wxPorting.L("Total points"), run_points, eol);
      //page.Add(buff);
      //buff = String.Format(wxPorting.T("%s : %d%s"), wxPorting.L("Total min. of delayed entry"), total_delay / 60, eol);
      //page.Add(buff);
      //buff = String.Format(wxPorting.T("%s : %ld%s"), wxPorting.L("Total min. trains arrived late"), total_late, eol);
      //page.Add(buff);
      //if(outFormat == OUT_wxHTML) {
      //  buff = String.Format(wxPorting.T("<br><a href=\"save_perf_text\">%s</a>"), wxPorting.L("Save as text"));
      //  page.AddLine(buff);
      //  if(performance_hide_canceled) {
      //    buff = String.Format(wxPorting.T("<br><a href=\"performance_toggle_canceled\">%s</a>"), wxPorting.L("(show canceled trains)"));
      //  } else {
      //    buff = String.Format(wxPorting.T("<br><a href=\"performance_toggle_canceled\">%s</a>"), wxPorting.L("(hide canceled trains)"));
      //  }
      //  page.AddLine(buff);
      //  //	    buff = String.Format(wxPorting.T("<br><a href="save_perf_HTML">%s</a>"), wxPorting.L("Save as HTML"));
      //  //	    page.AddLine(buff);
      //}
      /////	fprintf(fp, "%s : %ldn",     LCS("Total performance penalties"), performance());
      ////fprintf(fp, "</blockquote>n");
      //if(outFormat == OUT_TEXT) {
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Wrong destinations"),
      //perf_tot.wrong_dest, perf_vals.wrong_dest,
      //perf_tot.wrong_dest * perf_vals.wrong_dest);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Late trains"),
      //perf_tot.late_trains, perf_vals.late_trains,
      //perf_tot.late_trains * perf_vals.late_trains);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Wrong platforms"),
      //perf_tot.wrong_platform, perf_vals.wrong_platform,
      //perf_tot.wrong_platform * perf_vals.wrong_platform);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Commands denied"),
      //perf_tot.denied, perf_vals.denied,
      //perf_tot.denied * perf_vals.denied);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Trains waiting at signals"),
      //perf_tot.waiting_train, perf_vals.waiting_train,
      //perf_tot.waiting_train * perf_vals.waiting_train);

      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Thrown switches"),
      //perf_tot.thrown_switch, perf_vals.thrown_switch,
      //perf_tot.thrown_switch * perf_vals.thrown_switch);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Cleared signals"),
      //perf_tot.cleared_signal, perf_vals.cleared_signal,
      //perf_tot.cleared_signal * perf_vals.cleared_signal);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Reversed trains"),
      //perf_tot.turned_train, perf_vals.turned_train,
      //perf_tot.turned_train * perf_vals.turned_train);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dn"), wxPorting.L("Missed station stops"),
      //perf_tot.nmissed_stops, perf_vals.nmissed_stops,
      //perf_tot.nmissed_stops * perf_vals.nmissed_stops);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("%-40s : %5d x %3d = %-5dnn"), wxPorting.L("Wrong stock assignments"),
      //perf_tot.wrong_assign, perf_vals.wrong_assign,
      //perf_tot.wrong_assign * perf_vals.wrong_assign);
      //  page.Add(buff);
      //} else {
      //  page.Add(wxPorting.T("</td><td valign=top>n"));
      //  buff = String.Format(wxPorting.T("<table><tr><td valign=top>%s</td>n"), wxPorting.L("Wrong destinations"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.wrong_dest, perf_vals.wrong_dest);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td>%d</td></tr>n"), perf_tot.wrong_dest * perf_vals.wrong_dest);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Late trains"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.late_trains, perf_vals.late_trains);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.late_trains * perf_vals.late_trains);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Wrong platforms"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top align=right>%d&nbsp;x</td><td valign=top align=right>%d&nbsp;=</td>"),
      //      perf_tot.wrong_platform, perf_vals.wrong_platform);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.wrong_platform * perf_vals.wrong_platform);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Commands denied"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.denied, perf_vals.denied);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.denied * perf_vals.denied);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Trains waiting at signals"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.waiting_train, perf_vals.waiting_train);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.waiting_train * perf_vals.waiting_train);
      //  page.Add(buff);

      //  buff = String.Format(wxPorting.T("</table></td><td valign=top><table>"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Thrown switches"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.thrown_switch, perf_vals.thrown_switch);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.thrown_switch * perf_vals.thrown_switch);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Cleared signals"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.cleared_signal, perf_vals.cleared_signal);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.cleared_signal * perf_vals.cleared_signal);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Reversed trains"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.turned_train, perf_vals.turned_train);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.turned_train * perf_vals.turned_train);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Missed station stops"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.nmissed_stops, perf_vals.nmissed_stops);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.nmissed_stops * perf_vals.nmissed_stops);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<tr><td valign=top>%s</td>n"), wxPorting.L("Wrong stock assignments"));
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td align=right valign=top>%d&nbsp;x</td><td align=right valign=top>%d&nbsp;=</td>"),
      //      perf_tot.wrong_assign, perf_vals.wrong_assign);
      //  page.Add(buff);
      //  buff = String.Format(wxPorting.T("<td valign=top>%d</td></tr>n"), perf_tot.wrong_assign * perf_vals.wrong_assign);
      //  page.Add(buff);
      //  page.Add(wxPorting.T("</table></td></tr></table>"));
      //  page.AddLine(wxPorting.T("</center>"));
      //}

      //cols[0] = wxPorting.L("Train");
      //cols[1] = wxPorting.L("Enters");
      //cols[2] = wxPorting.L("At");
      //cols[3] = wxPorting.L("Exits");
      //cols[4] = wxPorting.L("Before");
      //cols[5] = wxPorting.L("Delay");
      //cols[6] = wxPorting.L("Late");
      //cols[7] = wxPorting.L("Status");
      //cols[8] = 0;
      //if(outFormat == OUT_TEXT) {
      //} else
      //  page.StartTable(&cols[0]);

      //cols[0] = buffs[0];
      //cols[1] = buffs[1];
      //cols[2] = buffs[2];
      //cols[3] = buffs[3];
      //cols[4] = buffs[4];
      //cols[5] = buffs[5];
      //cols[6] = buffs[6];
      //cols[7] = buffs[7];
      //cols[8] = 0;

      //TrainInfo info;
      //for(t = schedule; t; t = t.next) {
      //  if(performance_hide_canceled && is_canceled(t))
      //    continue;
      //  //print_train_info(t);
      //  t.Get(info);
      //  buffs[0] = String.Format(wxPorting.T("<a href=\"traininfopage %s\">%s</a>"), t.name, t.name);
      //  cols[0] = buffs[0];
      //  buffs[1] = t.entrance;
      //  cols[1] = buffs[1];
      //  cols[2] = info.entering_time;
      //  buffs[3] = t.exit;
      //  cols[3] = buffs[3];
      //  cols[4] = info.leaving_time;
      //  cols[5] = info.current_delay;
      //  cols[6] = info.current_late;
      //  cols[7] = info.current_status;
      //  if(outFormat == OUT_TEXT) {
      //    buff = String.Format(wxPorting.T("%-10.10s  %-20.20s  %12s  %-20.20s  %12s %3s %3s %sn"),
      //        t.name, cols[1], cols[2], cols[3], cols[4], cols[5], cols[6], cols[7]);
      //    page.Add(buff);
      //  } else
      //    page.AddTableRow(cols);
      //  cols[0] = wxPorting.T("&nbsp;");
      //  cols[1] = wxPorting.T("&nbsp;");
      //  cols[2] = wxPorting.T("&nbsp;");
      //  cols[3] = wxPorting.T("&nbsp;");
      //  cols[4] = wxPorting.T("&nbsp;");
      //  cols[5] = wxPorting.T("&nbsp;");
      //  buff = wxPorting.T("");
      //  for(ts = t.stops; ts; ts = ts.next) {
      //    if(outFormat == OUT_TEXT && t.status != train_READY) {
      //      String s;

      //      s = String.Format(wxPorting.T("   %d: %s"), ts.delay, ts.station);
      //      if(buff.length() + s.length() > 93) {
      //        page.Add(buff);
      //        page.Add(wxPorting.T("n"));
      //        buff = wxPorting.T("");
      //      }
      //      buff += s;
      //      continue;
      //    }
      //    if(!ts.delay)
      //      continue;
      //    buffs[6] = String.Format(wxPorting.T("%c%d"), ts.delay > 0 ? '+' : ' ', ts.delay);
      //    cols[6] = buffs[6];
      //    cols[7] = ts.station;
      //    page.AddTableRow(cols);
      //  }
      //  if(buff.length() > 0) {
      //    page.Add(buff);
      //    page.Add(wxPorting.T("nn"));
      //  }
      //}
      //if(outFormat != OUT_TEXT) {
      //  page.EndTable();
      //  page.EndPage();
      //}
    }

    public static void show_schedule_status(HtmlPage dest) {
      //schedule_status_print(dest, OUT_wxHTML);
    }

    public static void save_schedule_status(HtmlPage dest) {
      //schedule_status_print(dest, OUT_TEXT);
    }

    public static void performance_toggle_canceled() {
      //performance_hide_canceled = !performance_hide_canceled;
    }

    public static void train_print(Train t, HtmlPage page) {
  //    TrainStop ts;
  //    String buff;
  //    int i;
  //    String beg, end;
  //    int status;
  //    String[] buffs = new string[7];
  //    String[] cols = new string[7];

  //    buff = String.Format(wxPorting.T("%s %s"), wxPorting.L("Train"), t.name);
  //    page.StartPage(buff);
  //    cols[0] = wxPorting.L("Station");
  //    cols[1] = wxPorting.L("Arrival");
  //    cols[2] = wxPorting.L("Departure");
  //    cols[3] = wxPorting.L("Min.stop");
  //    cols[4] = 0 /*"Stopped";
  //cols[5] = "Delay";
  //cols[6] = 0*/
  //                 ;
  //    page.StartTable(cols);
  //    cols[0] = buffs[0];
  //    cols[1] = buffs[1];
  //    cols[2] = buffs[2];
  //    cols[3] = buffs[3];
  //    cols[4] = 0 /*buffs[4];
  //cols[5] = buffs[5];
  //cols[6] = 0 */
  //                  ;

  //    status = 0;
  //    beg = wxPorting.T(""); end = wxPorting.T("");
  //    for(ts = t.stops; ts; ts = ts.next) {
  //      if(ts.arrival >= t.timein/* && findStation(ts.station)*/) {
  //        if(status == 0) {
  //          buffs[0] = String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.entrance, t.entrance); cols[0] = buffs[0];
  //          buffs[1] = String.Format(wxPorting.T("&nbsp;")); cols[1] = buffs[1];
  //          buffs[2] = String.Format(wxPorting.T("<b>%s</b>"), format_time(t.timein)); cols[2] = buffs[2];
  //          buffs[3] = String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
  //          cols[4] = 0;
  //          page.AddTableRow(cols);
  //          status = 1;
  //        }
  //      }
  //      if(ts.arrival > t.timeout && status == 1) {
  //        buffs[0] = String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.exit, t.exit); cols[0] = buffs[0];
  //        buffs[1] = String.Format(wxPorting.T("<b>%s</b>"), format_time(t.timeout)); cols[1] = buffs[1];
  //        buffs[2] = String.Format(wxPorting.T("&nbsp;")); cols[2] = buffs[2];
  //        buffs[3] = String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
  //        cols[4] = 0;
  //        page.AddTableRow(cols);
  //        status = 2;
  //      }
  //      buffs[0] = String(ts.station).BeforeFirst(wxPorting.T('@'));
  //      if(findStationNamed(buffs[0])) {
  //        beg = wxPorting.T("<b>"); end = wxPorting.T("</b>");
  //      } else {
  //        beg = wxPorting.T(""); end = wxPorting.T("");
  //      }
  //      buffs[0] = String.Format(wxPorting.T("%s<a href=\"stationinfopage %s\">%s</a>%s"), beg, ts.station, ts.station, end); cols[0] = buffs[0];
  //      if(!ts.arrival || !ts.minstop)
  //        cols[1] = wxPorting.T("&nbsp;");
  //      else {
  //        buffs[1] = String.Format(wxPorting.T("%s%s%s"), beg, format_time(ts.arrival), end); cols[1] = buffs[1];
  //      }
  //      buffs[2] = String.Format(wxPorting.T("%s%s%s"), beg, format_time(ts.departure), end); cols[2] = buffs[2];
  //      if(status != 1)
  //        cols[3] = wxPorting.T("&nbsp;");
  //      else {
  //        buffs[3] = String.Format(wxPorting.T("%ld"), ts.minstop); cols[3] = buffs[3];
  //      }
  //      /*	    sprintf(cols[4], ts.stopped ? "<b>Yes</b>" : "<b>No</b>");
  //           sprintf(cols[5], "%s%ld%s", beg, (long)ts.delay, end);
  //      */
  //      cols[4] = 0;
  //      page.AddTableRow(cols);
  //    }
  //    if(status < 1) {
  //      buffs[0] = String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.entrance, t.entrance); cols[0] = buffs[0];
  //      buffs[1] = String.Format(wxPorting.T("&nbsp;")); cols[1] = buffs[1];
  //      buffs[2] = String.Format(wxPorting.T("<b>%s</b>"), format_time(t.timein)); cols[2] = buffs[2];
  //      buffs[3] = String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
  //      cols[4] = 0;
  //      page.AddTableRow(cols);
  //      ++status;
  //    }
  //    if(status < 2) {
  //      buffs[0] = String.Format(wxPorting.T("<b><a href=\"stationinfopage %s\">%s</a></b>"), t.exit, t.exit); cols[0] = buffs[0];
  //      buffs[1] = String.Format(wxPorting.T("<b>%s</b>"), format_time(t.timeout)); cols[1] = buffs[1];
  //      buffs[2] = String.Format(wxPorting.T("&nbsp;")); cols[2] = buffs[2];
  //      buffs[3] = String.Format(wxPorting.T("&nbsp;")); cols[3] = buffs[3];
  //      cols[4] = 0;
  //      page.AddTableRow(cols);
  //    }
  //    page.EndTable();
  //    page.Add(wxPorting.T("<blockquote><blockquote>n"));
  //    if(t.days) {
  //      buff = String.Format(wxPorting.T("%s : "), wxPorting.L("Runs on"));
  //      for(i = 0; i < 7; ++i)
  //        if(t.days & (1 << i))
  //          buff += String.Format(wxPorting.T("%d"), i + 1);
  //      page.AddLine(buff);
  //    }
  //    if(t.nnotes) {
  //      buff = String.Format(wxPorting.T("%s: "), wxPorting.L("Notes"));
  //      page.Add(buff);
  //      for(status = 0; status < t.nnotes; ++status) {
  //        buff = String.Format(wxPorting.T("%s.<br>n"), t.notes[status]);
  //        page.Add(buff);
  //      }
  //    }
  //    page.AddLine(wxPorting.T("</blockquote></blockquote>"));
  //    page.EndPage();
    }

    //  Test if there's any condition that prevents us to save
    //  the game, such as trains currently on an X switch.

    public static bool can_save_game() {
      throw new NotImplementedException();
      //Train* train;
      //Track* track;

      //for(train = schedule; train; train = train.next) {
      //  if(!(track = train.position))
      //    continue;
      //  if(track.type == SWITCH) {
      //    switch(track.direction) {
      //      case 8:
      //      case 9:
      //      case 16:
      //      case 17:
      //        return false;
      //    }
      //  } else if(track.type == TRACK) {
      //    switch(track.direction) {
      //      case N_NE_S_SW:
      //      case N_NW_S_SE:
      //      case XH_NW_SE:
      //      case XH_SW_NE:
      //      case X_X:
      //      case X_PLUS:
      //        return false;
      //    }
      //  }
      //}
      //return true;
    }


    public static int save_game(String name) {
      throw new NotImplementedException();
      //wxFFile file;
      //Track* t;
      //Train* tr;
      //TrainStop* ts;
      //int i;

      //if(!file_create(name, wxPorting.T(".sav"), file))
      //  return 0;
      //file.Write(String.Format(wxPorting.T("%sn"), current_project));

      //file.Write(String.Format(wxPorting.T("%d,%ld,%d,%d,%d,%d,%d,%d,%d,%ldn"),
      //  cur_time_mult, start_time, show_speeds,
      //  show_blocks, beep_on_alert, run_points, total_delay,
      //  total_late, time_mult, current_time));

      ///* Save the state of every switch */

      //for(t = layout; t; t = t.next) {
      //  if(t.type != SWITCH || !t.switched)
      //    continue;
      //  file.Write(String.Format(wxPorting.T("%d,%d,%dn"), t.x, t.y, t.switched));
      //}
      //file.Write(String.Format(wxPorting.T("n")));

      ///* Save the state of every signal */

      //for(t = layout; t; t = t.next) {
      //  if(t.type != TSIGNAL)
      //    continue;
      //  Signal* sig = (Signal*)t;
      //  if(!sig.IsClear() && !t.nowfleeted)
      //    continue;
      //  file.Write(String.Format(wxPorting.T("%d,%d,%d,%d"), t.x, t.y,
      //  sig.IsClear(), t.nowfleeted != 0));
      //  if(sig._intermediate)
      //    file.Write(String.Format(wxPorting.T("/%d"), sig._nReservations));
      //  if(sig._interpreterData)
      //    file.Write(String.Format(wxPorting.T(",%s"), sig._currentState));
      //  file.Write(String.Format(wxPorting.T("n")));
      //}
      //file.Write(String.Format(wxPorting.T("n")));

      ///* Save the position of every train */

      //for(tr = schedule; tr; tr = tr.next) {
      //  if(tr.status == train_READY && (!tr.entryDelay || !tr.entryDelay.nSeconds))
      //    continue;
      //  file.Write(String.Format(wxPorting.T("%sn"), tr.name));
      //  file.Write(String.Format(wxPorting.T("  %d,%d,%sn"), tr.status, tr.direction,
      //    tr.exited ? tr.exited : wxPorting.T("")));
      //  file.Write(String.Format(wxPorting.T("  %d,%d,%g,%d,%d,%g,%d,%d,%d"), tr.timeexited,
      //    tr.wrongdest, tr.curspeed, tr.maxspeed,
      //    tr.curmaxspeed, tr.trackpos, tr.timelate,
      //    tr.timedelay, tr.timered));
      //  if(tr.entryDelay) {
      //    file.Write(String.Format(wxPorting.T(",%d"), tr.entryDelay.nSeconds));
      //  }
      //  file.Write(wxPorting.T("n"));
      //  file.Write(String.Format(wxPorting.T("  %ld,%d,%g,%g,%dn"), tr.timedep, 0, //tr.pathpos,
      //    tr.pathtravelled, tr.disttostop, tr.shunting));
      //  if(!tr.stoppoint)
      //    file.Write(String.Format(wxPorting.T("  0,0,0,")));
      //  else
      //    file.Write(String.Format(wxPorting.T("  %d,%d,%g,"), tr.stoppoint.x, tr.stoppoint.y,
      //        tr.disttoslow));
      //  if(!tr.slowpoint)
      //    file.Write(String.Format(wxPorting.T("0,0")));
      //  else
      //    file.Write(String.Format(wxPorting.T("%d,%d"), tr.slowpoint.x, tr.slowpoint.y));
      //  file.Write(String.Format(wxPorting.T(",%dn"), tr.needfindstop));
      //  if(tr.fleet && tr.fleet._size) {
      //    /* file.Write(String.Format("  %d,%dn", tr.fleet.x, tr.fleet.y)); */
      //    file.Write(wxPorting.T("  "));
      //    for(i = 0; i < tr.fleet._size; ++i) {
      //      t = tr.fleet.TrackAt(i);
      //      if(i)
      //        file.Write(wxPorting.T(','));
      //      file.Write(String.Format(wxPorting.T("%d,%d"), t.x, t.y));
      //    }
      //    file.Write(wxPorting.T('n'));
      //  } else
      //    file.Write(String.Format(wxPorting.T("  0,0n")));	    /* length has fleet info at end */
      //  if(tr.position)
      //    file.Write(String.Format(wxPorting.T("  %d,%d"), tr.position.x, tr.position.y));
      //  else
      //    file.Write(String.Format(wxPorting.T("  0,0")));
      //  file.Write(String.Format(wxPorting.T(",%d,%d,%dn"), tr.waittime, tr.flags, tr.arrived));
      //  file.Write(String.Format(wxPorting.T("  %d,%sn"), tr.oldstatus,
      //    tr.outof ? tr.outof.station : wxPorting.T("")));

      //  if(tr.startDelay) {
      //    file.Write(String.Format(wxPorting.T(":startDelay %dn"), tr.startDelay));
      //  }

      //  /* Save status of each stop */

      //  for(ts = tr.stops; ts; ts = ts.next) {
      //    //		if(ts.stopped || ts.delay)
      //    if(!ts.depDelay)
      //      file.Write(String.Format(wxPorting.T("    %s,%d,%dn"),
      //        ts.station, ts.stopped, ts.delay));
      //    else
      //      file.Write(String.Format(wxPorting.T("    %s,%d,%d,%dn"),
      //        ts.station, ts.stopped, ts.delay, ts.depDelay.nSeconds));
      //  }
      //  if(tr.tail && tr.tail.path) {
      //    Train* tail = tr.tail;

      //    file.Write(String.Format(wxPorting.T(".n")));	/* marks beginning of tail path */
      //    file.Write(String.Format(wxPorting.T("  %sn"), tr.stopping ? tr.stopping.station : wxPorting.T("")));
      //    if(tr.length) {
      //      /* save the length. This may be different than
      //       * the length specified in the sch file because
      //       * it may have been changed by a split/merge operation.
      //       */
      //      file.Write(String.Format(wxPorting.T("=length %dn"), tr.length));
      //      file.Write(String.Format(wxPorting.T("=icons %d %dn"), tr.ecarpix, tr.wcarpix));
      //    }
      //    if(tail.fleet && tail.fleet._size) {
      //      for(i = 0; i < tail.fleet._size; ++i) {
      //        t = tail.fleet.TrackAt(i);
      //        file.Write(String.Format(wxPorting.T("%c%d,%d"), i ? ',' : '!', t.x, t.y));
      //      }
      //      file.Write(wxPorting.T('n'));
      //    }
      //    file.Write(String.Format(wxPorting.T("  %d,%g,%d,%d"), !tail.position ? -1 : 0, //tail.pathpos,
      //        tail.trackpos, tail.tailentry, tail.tailexit));
      //    for(i = 0; i < tail.path._size; ++i) {
      //      t = tail.path.TrackAt(i);
      //      file.Write(String.Format(wxPorting.T(",%d,%d,%d"), t.x, t.y, tail.path.FlagAt(i)));
      //    }
      //  }
      //  file.Write(wxPorting.T('n'));
      //}
      //file.Write(wxPorting.T(".n"));

      ///* save white tracks (to allow merging trains) */
      //for(t = layout; t; t = t.next)
      //  if((t.type == TRACK || t.type == SWITCH) && t.fgcolor == color_white)
      //    break;

      //if(t) {	    /* we found a white track */
      //  file.Write(wxPorting.T("(white tracksn"));
      //  for(t = layout; t; t = t.next) {
      //    if((t.type == TRACK || t.type == SWITCH) && t.fgcolor == color_white)
      //      file.Write(String.Format(wxPorting.T("%d,%dn"), t.x, t.y));
      //  }
      //  file.Write(wxPorting.T(")n"));
      //}

      ///* Save the position of every stranded train */

      //for(tr = stranded; tr; tr = tr.next) {
      //  file.Write(wxPorting.T("(strandedn"));
      //  file.Write(String.Format(wxPorting.T("%d,%d,%d,%d,%d,%d,%d,%d,%d"),
      //tr.type, tr.position.x, tr.position.y,
      //tr.direction, tr.ecarpix, tr.wcarpix,
      //tr.maxspeed, tr.curmaxspeed,
      //tr.length));
      //  if(tr.length) {
      //    if(tr.tail && tr.tail.path) {
      //      int f;
      //      const String sep = wxPorting.T("");

      //      file.Write(String.Format(wxPorting.T(",%dn"), tr.tail.path._size));
      //      for(i = 0; i < tr.tail.path._size; ++i) {
      //        t = tr.tail.path.TrackAt(i);
      //        f = tr.tail.path.FlagAt(i);
      //        file.Write(String.Format(wxPorting.T("%s%d,%d,%d"), sep, t.x, t.y, f));
      //        sep = wxPorting.T(",");
      //      }
      //      file.Write(wxPorting.T('n'));
      //    } else
      //      file.Write(wxPorting.T(",0n"));
      //  } else
      //    file.Write(wxPorting.T('n'));
      //  file.Write(wxPorting.T(")n"));
      //}

      //int m;
      //file.Write(wxPorting.T("(late minutesn"));
      //for(i = m = 0; i < 24 * 60; ++i) {
      //  file.Write(String.Format(wxPorting.T(" %d"), late_data[i]));
      //  if(++m == 15) {	// 15 values per line
      //    file.Write(wxPorting.T("n"));
      //    m = 0;
      //  }
      //}
      //file.Write(wxPorting.T(")n"));

      //file.Write(String.Format(wxPorting.T("%d,%d,%d,%d,%dn"), run_day, terse_status, status_on_top,
      //  show_seconds, signal_traditional));
      //file.Write(String.Format(wxPorting.T("%d,%dn"), auto_link, show_grid));
      //file.Write(String.Format(wxPorting.T("%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%dn"),
      //    perf_tot.wrong_dest, perf_tot.late_trains, perf_tot.thrown_switch,
      //    perf_tot.cleared_signal, perf_tot.denied, perf_tot.turned_train,
      //    perf_tot.waiting_train, perf_tot.wrong_platform,
      //    perf_tot.ntrains_late, perf_tot.ntrains_wrong,
      //    perf_tot.nmissed_stops, perf_tot.wrong_assign));
      //file.Write(String.Format(wxPorting.T("%dn"), hard_counters));
      //file.Write(String.Format(wxPorting.T("%dn"), show_canceled));
      //file.Write(String.Format(wxPorting.T("%dn"), show_links));
      //file.Write(String.Format(wxPorting.T("%dn"), beep_on_enter));
      //file.Write(String.Format(wxPorting.T("%dn"), bShowCoord));
      //file.Write(String.Format(wxPorting.T("%dn"), show_icons));
      //file.Write(String.Format(wxPorting.T("%dn"), show_tooltip));
      //file.Write(String.Format(wxPorting.T("%dn"), show_scripts));
      //file.Write(String.Format(wxPorting.T("%dn"), random_delays));
      //file.Write(String.Format(wxPorting.T("%dn"), link_to_left));
      //file.Write(String.Format(wxPorting.T("%dn"), play_synchronously));

      //file.Close();
      //return 1;
    }


    public static void position_tail(Train tr) {
      //Train* tail;

      //// moved from above
      //if((tail = tr.tail) && tail.path) {
      //  tail.position = 0;
      //  //	    if(tr.status == train_ARRIVED) {
      //  //		Vector_delete(tail.path);
      //  //		tail.path = 0;
      //  //	    } else {
      //  colorPartialPath(tail.path, ST_RED, 0); //tail.pathpos + 1);
      //  if(tr.path) {
      //    colorPath(tr.path, ST_GREEN);
      //    tr.position.fgcolor = conf.fgcolor;
      //  }
      //  //		if(tail.pathpos >= 0 && tail.pathpos < tail.path._size)
      //  if(tail.path._size > 0)
      //    tail.position = tail.path.TrackAt(0); //tail.pathpos);
      //  //		else
      //  //		    tail.pathpos = 0;
      //  ///?		if(notOnTrack)
      //  ///?		    tr.status = tr.curspeed ? train_RUNNING : train_STOPPED;
      //  ///?		notOnTrack = 0;
      //  //	    }
      //  // sometimes the saved tail path does not include all
      //  // track elements that the train's path has. This causes
      //  // some tracks to be left colored red because the tail "skips"
      //  // them when it is advanced. The following loop tries to correct
      //  // this situation, even though the real problem is clearly
      //  // somewhere else (the tail's path should always contain all
      //  // elements of the head's path).
      //  int i;
      //  if(tr.path) {      // if we are not exiting...
      //    for(i = 0; i < tr.path._size; ++i) {
      //      Track* trk = tr.path.TrackAt(i);
      //      if(tail.path.Find(trk) < 0)
      //        tail.path.Add(trk, tr.path.FlagAt(i));
      //    }
      //  }
      //}
    }


    public static void clear_delays() {
      //Train* trn;
      //TrainStop* ts;

      //for(trn = schedule; trn; trn = trn.next) {
      //  if(trn.entryDelay)
      //    trn.entryDelay.nSeconds = 0;
      //  for(ts = trn.stops; ts; ts = ts.next) {
      //    if(ts.depDelay)
      //      ts.depDelay.nSeconds = 0;
      //  }
      //  trn.flags &= ~(TFLG_ENTEREDLATE | TFLG_GOTDELAYATSTOP);
      //}
    }

    public static void restore_game(String name) {
//      FILE fp1;
//      String buffptr;
//      string buff;
//      String p;
//      int x, y;
//      int notOnTrack;
//      Track t;
//      Train tr, tail;
//      TrainStop ts;

//      buff = String.Format(wxPorting.T("%s.sav"), name);
//      TDFile fp = new TDFile(buff);
//      if(!(fp.Load())) {
//#if wxUSE_UNICODE
//      perror(wxSafeConvertWX2MB(buff));	/* No wxPerror()? */
//#else
//        perror(buff);
//#endif
//        return;
//      }
//      clear_delays();
//      buff = String.Copy(wxPorting.T("load "));
//      buffptr = getline1(&fp);
//      wxStrncat(buff, buffptr, sizeof(buff) / sizeof(char) - 6);
//      if(wxStrstr(buff, wxPorting.T(".zip")) || wxStrstr(buff, wxPorting.T(".ZIP")))
//        ;
//      else if(!wxStrstr(buff, wxPorting.T(".trk")) && !wxStrstr(buff, wxPorting.T(".TRK")))
//        wxStrcat(buff, wxPorting.T(".trk"));
//      if(!(fp1 = wxFopen(buff + 5, wxPorting.T("r")))) {		// path not there
//        p = (String)(buffptr + Globals.wxStrlen(buffptr));	// try isolating only the file name
//        while(--p > buffptr && *p != '\\' && *p != '/' && *p != ':') ;
//        if(p > buffptr)
//          buff + 5 = String.Copy(p + 1);
//      } else
//        fclose(fp1);
//      // trainsim_cmd(buff);
//      Globals.traindir.OpenFile(buff + 5, true);

//      buffptr = getline1(&fp);
//      wxSscanf(buffptr, wxPorting.T("%d,%ld,%d,%d,%d,%d,%d,%d,%d,%ld"),
//        &cur_time_mult, &start_time, &show_speeds,
//        &show_blocks, &beep_on_alert, &run_points, &total_delay,
//        &total_late, &time_mult, &current_time);

//      /* reload state of all switches */

//      while((buffptr = getline1(&fp))) {
//        if(!buffptr[0])
//          break;
//        x = wxStrtol(buffptr, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        y = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        if(!(t = findSwitch(x, y)))
//          continue;
//        t.switched = wxAtoi(p);
//        if(t.switched)
//          change_coord(t.x, t.y);
//      }

//      /* reload state of all signals */

//      while((buffptr = getline1(&fp))) {
//        Signal* sig;

//        if(!buffptr[0])
//          break;
//        x = wxStrtol(buffptr, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        y = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        if(!(sig = findSignal(x, y)))
//          continue;
//        sig.status = wxStrtol(p, &p, 0) == 1 ? ST_GREEN : ST_RED;
//        if(p[0] == ',') p.incPointer();
//        sig.nowfleeted = wxStrtol(p, &p, 0);
//        if(p[0] == '/') {
//          p.incPointer();
//          sig._nReservations = wxStrtol(p, &p, 0);
//        }

//        if(p[0] == ',') p.incPointer();
//        if(*p)
//          sig._currentState = String.Copy(p); // this is a small memory leak!
//        if(!sig.IsApproach() && sig.IsClear())
//          signal_unlock(sig);
//        change_coord(sig.x, sig.y);
//      }

//      /* reload state of all trains */

//      while((buffptr = getline1(&fp))) {
//        if(!buffptr[0] || buffptr[0] == '.')
//          break;			/* end of file */
//        tr = findTrainNamed(buffptr);
//        if(!tr) {
//          /* the train could not be found in the schedule.
//           * Warn the user, and ignore all lines up to the
//           * next empty line.
//           */
//          do {
//            buffptr = getline1(&fp);
//          } while(buffptr && buffptr[0] && buffptr[0] != '.');
//          continue;
//        }
//        /* second line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        tr.status = (trainstat)wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.direction = (trkdir)wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        if(*p)
//          tr.exited = String.Copy(p);

//        /* third line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        tr.timeexited = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.wrongdest = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        //	    tr.curspeed = wxStrtol(p, &p, 0);
//        string lbuf;
//        for(x = 0; x < (sizeof(lbuf) - 1) && *p && *p != ','; ++x)
//          lbuf[x] = *p.incPointer();
//        lbuf[x] = 0;
//        wxSscanf(lbuf, wxPorting.T("%lg"), &tr.curspeed);
//        while(*p && *p != ',') p.incPointer();
//        if(p[0] == ',') p.incPointer();
//        tr.maxspeed = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.curmaxspeed = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        //tr.trackpos = wxStrtol(p, &p, 0);
//        for(x = 0; x < (sizeof(lbuf) - 1) && *p && *p != ','; ++x)
//          lbuf[x] = *p.incPointer();
//        lbuf[x] = 0;
//        wxSscanf(lbuf, wxPorting.T("%lg"), &tr.trackpos);
//        if(p[0] == ',') p.incPointer();
//        tr.timelate = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.timedelay = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.timered = wxStrtol(p, &p, 0);
//        if(p[0] == ',') {
//          int nDelEntry = wxStrtol(p.incPointer(), &p, 0);
//          if(tr.entryDelay)
//            tr.entryDelay.nSeconds = nDelEntry;
//        }

//        /* fourth line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        tr.timedep = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        /* tr.pathpos = */
//        wxStrtol(p, &p, 0); // backward compatibility
//        if(p[0] == ',') p.incPointer();
//        tr.pathtravelled = wxAtof(p); // wxStrtol(p, &p, 0);
//        while(*p && *p != ',') p.incPointer();
//        if(p[0] == ',') p.incPointer();
//        tr.disttostop = wxAtof(p); // wxStrtol(p, &p, 0);
//        while(*p && *p != ',') p.incPointer();
//        if(p[0] == ',') {
//          p.incPointer();
//          tr.shunting = wxStrtol(p, &p, 0);
//        }

//        /* fifth line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        x = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        y = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        if(!(tr.stoppoint = findTrack(x, y)))
//          tr.stoppoint = findSwitch(x, y);
//        tr.disttoslow = wxAtof(p); //wxStrtol(p, &p, 0);
//        while(*p && *p != ',') p.incPointer();
//        if(p[0] == ',') p.incPointer();
//        x = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        y = wxStrtol(p, &p, 0);
//        if(!(tr.slowpoint = findTrack(x, y)))
//          tr.slowpoint = findSwitch(x, y);
//        if(p[0] == ',') {
//          p.incPointer();
//          tr.needfindstop = wxStrtol(p, &p, 0);
//        }

//        /* sixth line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        while(*p) {		/* list of fleeting signals */
//          x = wxStrtol(p, &p, 0);
//          if(p[0] == ',') p.incPointer();
//          y = wxStrtol(p, &p, 0);
//          /*	    tr.fleet = findSignal(x, y);	*/
//          if(x && y) {
//            if(!tr.fleet)
//              tr.fleet = new_Vector();
//            tr.fleet.Add(findSignal(x, y), 0); // TODO
//          }
//        }

//        /* seventh line */
//        notOnTrack = 0;
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        x = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        y = wxStrtol(p, &p, 0);
//        if(!(tr.position = findTrack(x, y)))
//          if(!(tr.position = findSwitch(x, y))) {
//            switch(tr.status) {
//              case train_READY:
//              case train_ARRIVED:
//              case train_DERAILED:
//              case train_DELAY:
//                break;

//              case train_WAITING:
//              case train_STOPPED:
//              case train_RUNNING:
//                notOnTrack = 1;
//            }
//          }
//        if(p[0] == ',') p.incPointer();
//        tr.waittime = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.flags = wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        tr.arrived = wxStrtol(p, &p, 0);

//        /* eighth line */
//        buffptr = getline1(&fp);
//        for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//        tr.oldstatus = (trainstat)wxStrtol(p, &p, 0);
//        if(p[0] == ',') p.incPointer();
//        if(*p)
//          tr.outof = findStation(p);

//        if(!buffptr)
//          break;

//        /* nineth line */
//        while((buffptr = getline1(&fp))) {
//          if(!Globals.wxStrncmp(buffptr, wxPorting.T(":startDelay"), 11)) {
//            tr.startDelay = wxStrtol(buffptr + 11, &p, 0);
//            continue;
//          }
//          if(!buffptr[0] || buffptr[0] == '.')
//            break;
//          if(!(p = (String)wxStrchr(buffptr, ',')))
//            continue;
//          *p.incPointer() = 0;
//          for(ts = tr.stops; ts; ts = ts.next)
//            if(!wxStrcmp(ts.station, buffptr + 4))
//              break;
//          if(!ts)
//            continue;
//          ts.stopped = wxStrtol(p, &p, 0);
//          if(p[0] == ',') p.incPointer();
//          ts.delay = wxStrtol(p, &p, 0);
//          if(*p) {
//            int nSecDelay = wxStrtol(p.incPointer(), &p, 0);
//            if(ts.depDelay)
//              ts.depDelay.nSeconds = nSecDelay;
//          }
//        }
//        if(!buffptr)
//          break;
//        if(buffptr[0] == '.') {	/* tail path info present */
//          buffptr = getline1(&fp);
//          if(!buffptr[0] || buffptr[0] == '.')
//            break;
//          if(!(tail = tr.tail))	/* maybe length was removed in .sch */ {
//            tr.tail = tail = (Train*)calloc(sizeof(Train), 1);
//            tr.ecarpix = tr.wcarpix = -1;
//          }
//          for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//          if(*p)			/* stopping at station name present */
//            tr.stopping = findStation(p);
//          buffptr = getline1(&fp);
//          for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//          while(p[0] == '=') {
//            if(!Globals.wxStrncmp(p.incPointer(), wxPorting.T("length"), 6)) {
//              tr.length = wxStrtol(p + 6, &p, 0);
//            } else if(!Globals.wxStrncmp(p, wxPorting.T("icons"), 5)) {
//              tr.ecarpix = wxStrtol(p + 5, &p, 0);
//              tr.wcarpix = wxStrtol(p, &p, 0);
//            }
//            buffptr = getline1(&fp);
//            for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//          }
//          if(p[0] == '!') {
//            p.incPointer();
//            while(*p) {		/* list of fleeting signals */
//              x = wxStrtol(p, &p, 0);
//              if(p[0] == ',') p.incPointer();
//              y = wxStrtol(p, &p, 0);
//              if(x && y) {
//                if(!tail.fleet)
//                  tail.fleet = new_Vector();
//                tail.fleet.Add(findSignal(x, y), 0);	// TODO
//              }
//              if(p[0] == ',') p.incPointer();
//            }
//            buffptr = getline1(&fp);
//            for(p = (String)buffptr; p[0] == ' '; p.incPointer()) ;
//          }
//          /*tail.pathpos = */
//          wxStrtol(p, &p, 0);    // backward compatibility
//          if(p[0] == ',') p.incPointer();
//          //tail.trackpos = wxStrtol(p, &p, 0);
//          for(x = 0; x < (sizeof(lbuf) - 1) && *p && *p != ','; ++x)
//            lbuf[x] = *p.incPointer();
//          lbuf[x] = 0;
//          wxSscanf(lbuf, wxPorting.T("%lg"), &tail.trackpos);
//          if(p[0] == ',') p.incPointer();
//          tail.tailentry = wxStrtol(p, &p, 0);
//          if(p[0] == ',') p.incPointer();
//          tail.tailexit = wxStrtol(p, &p, 0);
//          while(p[0] == ',') {
//            x = wxStrtol(p + 1, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            y = wxStrtol(p, &p, 0);
//            if(!tail.path)
//              tail.path = new_Vector();
//            if(!(t = findTrack(x, y)))
//              if(!(t = findSwitch(x, y)))
//                t = findText(x, y);
//            if(!t) {		/* maybe layout changed? */
//              if(tail.path)	/* disable length for this train */
//                Vector_delete(tail.path);
//              tail.path = 0;
//              tr.tail = 0;
//              tr.length = 0;
//              break;
//            }
//            if(p[0] == ',') p.incPointer();
//            tail.path.Add(t, wxStrtol(p, &p, 0));
//          }
//          if(tr.status == train_DELAY && tail && tail.path) {
//            Vector_delete(tail.path);
//            tail.path = 0;
//          }
//        }
//        //	    if(notOnTrack) {
//        //		do_alert(wxPorting.T("Train is not on track!"));
//        //		new_train_status(tr, train_DERAILED);
//        //	    }
//        update_schedule(tr);
//      }

//      while((buffptr = getline1(&fp)) && buffptr[0] == '(') {
//        if(!Globals.wxStrncmp(buffptr, wxPorting.T("(white tracks"), 13)) {
//          while((buffptr = getline1(&fp)) && buffptr[0] != ')') {
//            wxSscanf(buffptr, wxPorting.T("%d,%d"), &x, &y);
//            if(!(t = findTrack(x, y)))
//              t = findSwitch(x, y);
//            if(t) {
//              t.fgcolor = color_white;
//              change_coord(x, y);
//            }
//          }
//          continue;
//        }
//        if(!Globals.wxStrncmp(buffptr, wxPorting.T("(stranded"), 9)) {
//          while((buffptr = getline1(&fp)) && buffptr[0] != ')') {
//            Train* stk = new Train();
//            stk.next = stranded;
//            stranded = stk;
//            stk.name = String.Copy(wxPorting.T(""));
//            p = (String)buffptr;
//            stk.type = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            x = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            y = wxStrtoul(p, &p, 0);
//            stk.position = findTrack(x, y);
//            if(!stk.position)
//              stk.position = findSwitch(x, y);
//            stk.flags = TFLG_STRANDED;
//            stk.status = train_ARRIVED;
//            if(p[0] == ',') p.incPointer();
//            stk.direction = (trkdir)wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            stk.ecarpix = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            stk.wcarpix = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            stk.maxspeed = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            stk.curmaxspeed = wxStrtoul(p, &p, 0);
//            if(p[0] == ',') p.incPointer();
//            stk.length = wxStrtoul(p, &p, 0);
//            if(stk.length) {
//              int tailLength, l, f;
//              int pathLength = 0;

//              if(p[0] == ',') p.incPointer();
//              tailLength = wxStrtoul(p, &p, 0);
//              if(tailLength) {
//                if(!(buffptr = getline1(&fp)))
//                  break;
//                p = (String)buffptr;
//                stk.tail = new Train();
//                stk.tail.path = new_Vector();
//                for(l = 0; l < tailLength; ++l) {
//                  if(p[0] == ',') p.incPointer();
//                  x = wxStrtoul(p, &p, 0);
//                  if(p[0] == ',') p.incPointer();
//                  y = wxStrtoul(p, &p, 0);
//                  if(p[0] == ',') p.incPointer();
//                  f = wxStrtoul(p, &p, 0);
//                  if(!(t = findTrack(x, y)))
//                    t = findSwitch(x, y);
//                  if(!t)
//                    break;
//                  t.fgcolor = color_orange;
//                  change_coord(x, y);

//                  stk.tail.path.Add(t, f);
//                  pathLength += t.length;
//                }
//                stk.tail.length = pathLength;
//                stk.tail.position = stk.tail.path.TrackAt(0);
//              }
//              //			stk.position = stk.path.TrackAt(0);
//            }
//            stk.position.fgcolor = color_black;
//          }
//          continue;
//        }
//        if(!Globals.wxStrncmp(buffptr, wxPorting.T("(late minutes"), 13)) {
//          x = 0;
//          while((buffptr = getline1(&fp)) && buffptr[0] != ')') {
//            p = (String)buffptr;
//            while(*p) {
//              late_data[x % (24 * 60)] = wxStrtoul(p, &p, 0);
//              ++x;
//            }
//          }
//          continue;
//        }
//      }
//      if(buffptr) {
//        wxSscanf(buffptr, wxPorting.T("%d,%d,%d,%d,%d"), &run_day, &terse_status, &status_on_top,
//      &show_seconds, &signal_traditional);
//      }

//      if((buffptr = getline1(&fp)))
//        wxSscanf(buffptr, wxPorting.T("%d,%d"), &auto_link, &show_grid);
//      memset(&perf_tot, 0, sizeof(perf_tot));
//      if((buffptr = getline1(&fp)))
//        wxSscanf(buffptr, wxPorting.T("%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d"),
//        &perf_tot.wrong_dest, &perf_tot.late_trains, &perf_tot.thrown_switch,
//        &perf_tot.cleared_signal, &perf_tot.denied, &perf_tot.turned_train,
//        &perf_tot.waiting_train, &perf_tot.wrong_platform,
//        &perf_tot.ntrains_late, &perf_tot.ntrains_wrong,
//        &perf_tot.nmissed_stops, &perf_tot.wrong_assign);
//      if((buffptr = getline1(&fp)) && *buffptr)
//        hard_counters = wxAtoi(buffptr);
//      if((buffptr = getline1(&fp)) && *buffptr)
//        show_canceled = wxAtoi(buffptr);
//      if((buffptr = getline1(&fp)) && *buffptr)
//        show_links = wxAtoi(buffptr);
//      if((buffptr = getline1(&fp)) && *buffptr)
//        beep_on_enter = wxAtoi(buffptr);
//      if((buffptr = getline1(&fp)) && *buffptr)
//        bShowCoord = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        show_icons = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        show_tooltip = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        show_scripts = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        random_delays = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        link_to_left = wxAtoi(buffptr) != 0;
//      if((buffptr = getline1(&fp)) && *buffptr)
//        play_synchronously = wxAtoi(buffptr) != 0;

//      /* needs to be here, after we reloaded the list
//       * of stranded rolling stock, because it might
//       * reduce the path a shunting train can travel.
//       */

//      // first need to position trains
//      for(tr = sched; tr; tr = tr.next) {
//        if(tr.shunting || (tr.flags & TFLG_MERGING))
//          continue;
//        if(tr.position) {
//          tr.path = findPath(tr.position, tr.direction);
//          //	    tr.pathpos = 1;
//          if(tr.path && tr.path._size > 1) {
//            Track* tt = tr.path.TrackAt(1);
//            if(tt.fgcolor != color_white) {
//              colorPath(tr.path, ST_GREEN);
//            }
//          }
//          tr.position.fgcolor = conf.fgcolor;
//        }
//        position_tail(tr);
//      }
//      // then need to position shunting material
//      // beacause we need to know the position
//      // of material we are merging to
//      for(tr = sched; tr; tr = tr.next) {
//        if(!tr.shunting && !(tr.flags & TFLG_MERGING))
//          continue;
//        if(!tr.position)
//          continue;

//        int i;
//        Train* trn;

//        tr.path = findPath(tr.position, tr.direction);
//        //	    tr.pathpos = 1;
//        if(tr.path) {
//          // 0 the the position of the train
//          for(i = 1; i < tr.path._size; ++i) {
//            t = tr.path.TrackAt(i);
//            if(!(trn = findTrain(t.x, t.y))) {
//              if(!(trn = findTail(t.x, t.y)))
//                if(!(trn = findStranded(t.x, t.y)))
//                  trn = findStrandedTail(t.x, t.y);
//            }
//            if(trn) {
//              tr.merging = trn;
//              tr.flags |= TFLG_MERGING;
//              tr.path._size = i;
//              trn.flags |= TFLG_WAITINGMERGE;
//              break;
//            }
//            // if conf.fgcolor, the path was clear when we saved the game
//            if(t.fgcolor == conf.fgcolor)
//              t.fgcolor = color_green;
//            // else the path must have been colored white by (white tracks) above
//            if(t.fgcolor != color_white && t.fgcolor != color_green)
//              break;	// impossible (should be caught by findStranded above)
//          }
//        }
//        tr.position.fgcolor = conf.fgcolor;
//        //	    position_tail(tr);
//        Train* tail;

//        // moved from above
//        if((tail = tr.tail) && tail.path) {
//          tail.position = 0;
//          for(i = 0; i < tail.path._size; ++i) {
//            t = tail.path.TrackAt(i);
//            if(t == tr.position)
//              break;
//            t.fgcolor = color_red;
//          }
//          if(tail.path._size > 0)
//            tail.position = tail.path.TrackAt(0);
//        }
//      }
//      compute_train_numbers();
    }

    public static void print_track_info(HtmlPage page) {
      //String buff;
      //TextList* tl;

      //buff = String.Format(wxPorting.T("%s : %s"), wxPorting.L("Territory"), current_project);
      //page.StartPage(buff);
      //page.AddRuler();
      //page.Add(wxPorting.T("<blockquote>n"));
      //for(tl = track_info; tl; tl = tl.next) {
      //  buff = String.Format(wxPorting.T("%sn"), tl.txt);
      //  page.Add(buff);
      //}
      //page.EndPage();
    }

    private static String[] en_headers = new string[] { wxPorting.T("Station Name"), wxPorting.T("Coordinates"), wxPorting.T("&nbsp;"), wxPorting.T("Entry/Exit"), wxPorting.T("Coordinates"), null };
    private static String[] headers = new string[en_headers.Length];

    public static void print_entry_exit_stations(HtmlPage page) {
      //Track** stations = get_station_list();
      //Track** entry_exit = get_entry_list();
      //Track* trk;
      //int i, j;
      //String buff;

      //if(!headers[0])
      //  Globals.localizeArray(ref headers, en_headers);

      //page.StartPage(wxPorting.L("Stations and Entry/Exit Points"));
      //page.Add(wxPorting.T("<blockquote>n"));
      //page.StartTable(headers);
      //for(i = j = 0; (stations && stations[i]) || (entry_exit && entry_exit[j]); ) {
      //  page.Add(wxPorting.T("<tr><td>"));
      //  if((trk = stations[i])) {
      //    buff = String.Format(wxPorting.T("<a href=\"stationinfopage %s\">%s</a>"), trk.station, trk.station);
      //    page.Add(buff);
      //    page.Add(wxPorting.T("</td><td>"));
      //    buff = String.Format(wxPorting.T("%d, %d"), trk.x, trk.y);
      //    page.Add(buff);
      //    ++i;
      //  } else {
      //    page.Add(wxPorting.T("&nbsp;</td><td>&nbsp;"));
      //  }
      //  page.Add(wxPorting.T("</td><td>&nbsp;&nbsp;&nbsp;</td>n<td>"));
      //  if((trk = entry_exit[j])) {
      //    buff = String.Format(wxPorting.T("<a href=\"stationinfopage %s\">%s</a>"), trk.station, trk.station);
      //    page.Add(buff);
      //    page.Add(wxPorting.T("</td><td>"));
      //    buff = String.Format(wxPorting.T("%d, %d"), trk.x, trk.y);
      //    page.Add(buff);
      //    ++j;
      //  } else {
      //    page.Add(wxPorting.T("&nbsp;</td><td>&nbsp;"));
      //  }
      //  page.Add(wxPorting.T("</td></tr>n"));
      //}
      //page.EndTable();
      //page.EndPage();
    }

    /*	Set default preferences		*/

    public static void default_prefs() {
      //terse_status = 1;
      //status_on_top = 1;
      //beep_on_alert = 1;
      //beep_on_enter = 0;
      //show_speeds = 1;
      //auto_link = 1;
      //link_to_left = 0;
      //show_grid = 0;
      //show_blocks = 1;
      //show_seconds = 0;
      //show_icons = 1;
      //signal_traditional = 0;
      //hard_counters = 0;
      //random_delays = 1;
      //save_prefs = 1;
      //bShowCoord = true;
    }

  }
}