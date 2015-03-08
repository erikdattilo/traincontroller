using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx.Archive;
using TrainController.SimCommands;
using wx;
using System.Timers;

namespace TrainController {
  public class _conf {
    public int gridxbase, gridybase;
    public int gridxsize, gridysize;

    public grcolor gridcolor;
    public grcolor txtbgcolor;	/* for dialogues */
    public grcolor fgcolor;
    public grcolor linkcolor;	/* links signals and entry/exit */
    public grcolor linkcolor2;	/* links tracks */
  }

  public class pxmap {
    public string name;
    public object pixels;
  }

  partial class Globals {
    public static TrainController traindir {
      get {
        return TrainController.GetInstance();
      }
    }

    // TODO Handle this vars
    public static _conf conf;
    public static bool show_links = true; 
    public static bool signal_traditional = false;
    public static bool updating_all = false;
    public static bool editing;
    public static bool show_grid = false;
    public static Train schedule;
    public static Train stranded;
    public static byte[] update_map = new byte[Configuration.XNCELLS * Configuration.YNCELLS];
    public static byte UPDATE_MAP(int x, int y) { return update_map[(y) * Configuration.XNCELLS + (x)]; }
    public static void UPDATE_MAP(int x, int y, byte value) { update_map[(y) * Configuration.XNCELLS + (x)] = value; }
    public static pxmap[] pixmaps;
    public static int npixmaps, maxpixmaps;

    public static void draw_link(int x0, int y0, int x1, int y1, int color) {
      field_grid.DrawLineCenterCell(x0, y0, x1, y1, color);
    }

    public static object get_pixmap_file(String fname) {
      throw new NotImplementedException();
      //      TDFile xpmFile = new TDFile(fname);

      //      if(!xpmFile.Load())
      //        return 0;

      //      gLogger.SetExtraInfo(fname);

      //      int nLines = xpmFile.LineCount();
      //      String[] pattern = (String[])Globals.calloc(nLines + 10);
      //      int i, j, k;
      //      string buff;

      //      // collect all strings (delimited by double-quotes)
      //      // from the file and store them in pattern[],
      //      // one string per entry.

      //      for(i = 0; i < nLines; ) {
      //        if(!xpmFile.ReadLine(buff, buff.Length))
      //          break;
      //        for(j = 0; j <= buff.Length && buff[j] != '"'; ++j) ;
      //        if(j++ == buff.Length) // Erik: Original code ==> if(buff[j++] == 0)
      //          continue;
      //        for(k = 0; j <= buff.Length && buff[j] != '"'; buff.ReplaceAt(k, buff[j]), k++, j++) ;

      //        if(j == buff.Length)
      //          continue;
      //        buff = buff.Substring(0, k - 1);
      //        // we allocate a bit more to allow extending
      //        // shorter lines during the checking phase
      //        pattern[i] = ""; //  (String)Globals.calloc(k + 10, 1);
      //#if wxUSE_UNICODE
      //      wxConvISO8859_1.FromWChar(pattern[i], k + 10, buff, wxNO_LEN);
      //#else
      //        Globals.strcpy(pattern[i], buff);
      //#endif
      //        ++i;
      //      }

      //      wx.Image img = null;

      //      // now analyze the lines to check if the image is correct

      //      int nRows, nColumns, nColors, depth, x, y, c;
      //      if(Globals.sscanf(pattern[0], "%d %d %d %d", nColumns, nRows, nColors, depth) != 4) {
      //        buff = String.Format( wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
      //        Globals.traindir.layout_error(buff);
      //        goto done;
      //      }
      //      if(nRows > i - 1 - nColors) {
      //        string cbuff;
      //        buff = String.Format( wxPorting.T("%s: Warning: too many lines in XPM header. Truncated."), fname);
      //        Globals.traindir.layout_error(buff);
      //        cbuff = String.Format("%d %d %d %d", nColumns, i - 1 - nColors, nColors, depth);
      //        Globals.free(pattern[0]);
      //        pattern[0] = Globals.strdup(cbuff);
      //      }
      //      for(y = nColors + 1; y < i; ++y) {  // check each pixel row
      //        for(x = 0; x < nColumns; ++x) {
      //          bool valid = false;
      //          if(pattern[y][x] == 0)
      //            break;
      //          for(c = 0; c < nColors; ++c) {
      //            if(pattern[c + 1][0] == pattern[y][x]) {
      //              valid = true;
      //              break;
      //            }
      //          }
      //          if(!valid) {
      //            pattern[y].ReplaceAt(x, pattern[1][0]);  // force first color (hopefully "None")
      //            buff = String.Format( wxPorting.T("%s: Warning: bad color key (y=%d,x=%d). Replaced."), fname, y, x);
      //            Globals.traindir.layout_error(buff);
      //          }
      //        }
      //      }
      //      try {
      //        img = new wx.Image(pattern);
      //        if(!img.Ok) {
      //          buff = String.Format( wxPorting.T("Error loading '%s'"), fname);
      //          Globals.traindir.layout_error(buff);
      //          Globals.delete(img);
      //          img = null;
      //        }
      //      } catch(Exception) {
      //        buff = String.Format( wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
      //        Globals.traindir.layout_error(buff);
      //      }
      //    done:
      //      for(i = 0; pattern[i] != null; ++i)
      //        Globals.free(pattern[i]);
      //      Globals.free(pattern);
      //      return (object)img;
    }

    public static int get_pixmap_index(String mapname) {
      throw new NotImplementedException();

      //int i;

      //if(String1.IsNullOrWhiteSpaces(mapname))
      //  return -1;

      //for(i = 0; i < npixmaps; ++i)
      //  if(mapname.Equals(pixmaps[i].name))
      //    return i;
      //if(npixmaps >= maxpixmaps) {
      //  maxpixmaps += 10;
      //  if(pixmaps == null)
      //    pixmaps = new pxmap[maxpixmaps];
      //  else
      //    pixmaps = (pxmap*)realloc(pixmaps, sizeof(pxmap) * maxpixmaps);
      //}
      //if(!(pixmaps[npixmaps].pixels = (string)get_pixmap_file(mapname)))
      //  return -1;          /* failed! file does not exist */
      //pixmaps[npixmaps].name = String.Copy(mapname);
      //return npixmaps++;
    }

    public static wx.Image get_pixmap(String[] pxpm) {
      //wx.Image img = new wx.Image(pxpm);
      //return img;
      return PixMap.FromXpmData(pxpm);
    }

    public static void draw_pixmap(int x0, int y0, System.Drawing.Image map) {
      // Rectangle update_rect = new Rectangle();
      grid g = current_grid;
      int x = x0 * g.m_hmult + g.m_xBase;
      int y = y0 * g.m_vmult + g.m_yBase;

      if(g.m_pixmap == null)
        return;
      if(g.m_dc == null)
        throw new NotImplementedException(); // g.m_dc = System.Drawing.Graphics.FromImage(g.m_pixmap);
      if(g == tools_grid && y0 != 0 && x0 < 8) {
        x += tools_grid.m_hmult / 2;
        y += tools_grid.m_vmult / 2;
      }
      g.m_dc.DrawImage(map, x, y);
      if(updating_all)
        return;
      //update_rect.X = x;
      //update_rect.Y = y;
      //update_rect.Width = 16 * g.m_hmult;
      //update_rect.Height = 11 * g.m_vmult;
    }


    public static void coord_paint(Coord pCoord) {
      string buff;
      int i;
      grid g = field_grid;

      // TODO
      System.Drawing.Font font = new System.Drawing.Font(
        "wx.FontFamily.wxSWISS", 6
        // , wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL
      );

      // draw background of coord bars
      g.m_dc.SetPen(System.Drawing.Pens.LightGray);
      g.m_dc.SetBrush(System.Drawing.Brushes.LightGray);
      g.m_dc.DrawRectangle(0, 0, Configuration.XMAX, Configuration.VCOORDBAR);
      g.m_dc.DrawRectangle(0, 0, Configuration.HCOORDBAR, Configuration.YMAX);

      // draw digits
      g.m_dc.SetFont(font);
      g.m_dc.SetBackgroundMode((int)DCBackgroundMode.SOLID);
      g.m_dc.SetTextForeground(Colour.wxBLACK);
      g.m_dc.SetTextBackground(Colour.wxLIGHT_GREY);
      System.Drawing.Point pt = new System.Drawing.Point(0, 0);
      for(i = 0; i < Configuration.XNCELLS; ++i) {
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(wx.Colour.wxWHITE);
        buff = String.Format(wxPorting.T("%d"), i / 100);
        pt.X = i * Configuration.HGRID + Configuration.HCOORDBAR;
        pt.Y = 0;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format(wxPorting.T("%d"), (i / 10) % 10);
        pt.Y = 8;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format(wxPorting.T("%d"), i % 10);
        pt.Y = 16;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(Colour.wxBLACK);
      }
      for(i = 0; i < Configuration.YNCELLS; ++i) {
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(wx.Colour.wxWHITE);
        buff = String.Format(wxPorting.T("%3d"), i);
        pt.X = 0;
        pt.Y = i * Configuration.VGRID + Configuration.VCOORDBAR;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Colour.wxBLACK);
      }
    }

    public static void grid_paint() {
      field_grid.Paint();
    }

    public static void invalidate_field()	/* next time, repaint whole field */
    {
      Globals.cliprect.top = 0;
      Globals.cliprect.left = 0;
      Globals.cliprect.bottom = Configuration.YNCELLS;
      Globals.cliprect.right = Configuration.XNCELLS;
      ignore_cliprect = true;
    }

    public static void clear_field() {
      if(editing)
        invalidate_field();
      field_grid.ClearField();
    }


    public static void layout_paint(List<Track> lst) {
      Track trk;
      int x, y;

      if(!ignore_cliprect) {
        if(!editing &&
            (cliprect.top < 0 || Globals.cliprect.top >= Configuration.YNCELLS ||
            Globals.cliprect.bottom < 0 || Globals.cliprect.bottom >= Configuration.YNCELLS ||
            Globals.cliprect.left < 0 || Globals.cliprect.left >= Configuration.XNCELLS ||
            Globals.cliprect.right < 0 || Globals.cliprect.right >= Configuration.XNCELLS)) {
          trk = null;
          return;
        }
        for(y = Globals.cliprect.top; y <= Globals.cliprect.bottom; ++y)
          for(x = Globals.cliprect.left; x <= Globals.cliprect.right; ++x)
            if(UPDATE_MAP(x, y) != 0)
              tr_fillrect(x, y);
      }

      foreach(Track trk1 in lst)
      // for(trk = lst; trk != null; trk = trk.next)
      {
#if !DEBUG
        if(editing || track_updated(trk1))
#endif
        {
          UPDATE_MAP(trk1.x, trk1.y, 0);
          track_paint(trk1);
        }
      }
    }

    public static void update_rectangle_at(int x, int y) {
      wxRect update_rect = new wxRect();

      if(Globals.updating_all)
        return;

      update_rect.X = x;
      update_rect.Y = y;
      update_rect.Width = current_grid.m_hmult;
      update_rect.Height = current_grid.m_vmult;

      draw_all_pixmap();	// TEMP
    }

    public static void draw_layout(int x0, int y0, VLines[] p, grcolor col) {
      current_grid.DrawLayoutRGB(x0, y0, p, col);
      update_rectangle_at(x0, y0);
    }


    public static VLines[] w_e_platform_out = new VLines[] {
	new VLines( 0, Configuration.VGRID / 2 - 3, Configuration.HGRID - 1, Configuration.VGRID / 2 - 3 ),
	new VLines( 0, Configuration.VGRID / 2 + 3, Configuration.HGRID - 1, Configuration.VGRID / 2 + 3 ),
	new VLines( 0, Configuration.VGRID / 2 - 3, 0, Configuration.VGRID / 2 + 3 ),
	new VLines( Configuration.HGRID - 1, Configuration.VGRID / 2 - 3, Configuration.HGRID - 1, Configuration.VGRID / 2 + 3 ),
	new VLines( -1 )
};

    public static VLines[] w_e_platform_in = new VLines[] {
	new VLines( 1, Configuration.VGRID / 2 - 2, Configuration.HGRID - 2, Configuration.VGRID / 2 - 2 ),
	new VLines( 1, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, Configuration.VGRID / 2 - 1 ),
	new VLines( 1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 2, Configuration.VGRID / 2 - 0 ),
	new VLines( 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID / 2 + 1 ),
	new VLines( 1, Configuration.VGRID / 2 + 2, Configuration.HGRID - 2, Configuration.VGRID / 2 + 2 ),
	new VLines( -1 )
};

    public static VLines[] n_s_platform_out = new VLines[] {
	new VLines( Configuration.HGRID / 2 - 3, 0, Configuration.HGRID / 2 - 3, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 + 3, 0, Configuration.HGRID / 2 + 3, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 3, 0, Configuration.HGRID / 2 + 3, 0 ),
	new VLines( Configuration.HGRID / 2 - 3, Configuration.VGRID - 1, Configuration.HGRID / 2 + 3, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] n_s_platform_in = new VLines[] {
	new VLines( Configuration.HGRID / 2 - 2, 1, Configuration.HGRID / 2 - 2, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 - 1, 1, Configuration.HGRID / 2 - 1, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 - 0, 1, Configuration.HGRID / 2 - 0, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 + 1, 1, Configuration.HGRID / 2 + 1, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 + 2, 1, Configuration.HGRID / 2 + 2, Configuration.VGRID - 2 ),
	new VLines( -1 )
};

    public static void platform_draw(Track t) {
      switch(t.direction) {
        case trkdir.W_E:
          draw_layout(t.x, t.y, w_e_platform_out, curSkin.free_track); //fieldcolors[TRACK]);
          draw_layout(t.x, t.y, w_e_platform_in, curSkin.outline);
          break;

        case trkdir.N_S:
          draw_layout(t.x, t.y, n_s_platform_out, curSkin.free_track);//fieldcolors[TRACK]);
          draw_layout(t.x, t.y, n_s_platform_in, curSkin.outline);
          break;
      }
    }

    public static void signal_draw(Track t) {
      Signal signal = (Signal)t;
      signal.Draw();
    }

    // TODO Uncomment this function
    public static void track_paint(Track t) {
      tr_fillrect(t.x, t.y);
      if(!editing && t.invisible)
        return;

      switch(t.TrackType) {
        //case trktype.TRACK:
        //  track_draw(t);
        //  break;

        //  case trktype.SWITCH:
      //    switch_draw(t);
      //    break;

        case trktype.PLATFORM:
          platform_draw(t);
          break;

        case trktype.TSIGNAL:
          signal_draw(t);
          break;

        //  case trktype.TRAIN:		/* trains are handled differently */
      //    /*	train_draw(t); */
      //    break;

        //  case trktype.TEXT:
      //    text_draw(t);
      //    break;

        //  case trktype.LINK:
      //    link_draw(t);
      //    break;

        //  case trktype.IMAGE:
      //    image_draw(t);
      //    break;

        //  case trktype.MACRO:
      //    macro_draw(t);
      //    break;

        //  case trktype.ITIN:
      //    itin_draw(t);
      //    break;

        //  case trktype.TRIGGER:
      //    trigger_draw(t);
      //    break;

      //  default:
      //    return;
      }
      //if(editing && show_scripts && t.stateProgram) {
      //  draw_layout(t.x, t.y, switch_rect, curSkin.working_track);//fieldcolors[COL_TRAIN2]);
      //}
    }
    public static bool track_updated(Track trk) {
      if(trk.x < (cliprect.left - 1) || trk.x > Globals.cliprect.right)
        return false;
      if(trk.y < (cliprect.top - 1) || trk.y > Globals.cliprect.bottom)
        return false;
      /* it's inside the clip rect, but do we really need to update it? */

      if(ignore_cliprect || UPDATE_MAP(trk.x, trk.y) != 0)
        return true;
      return false;
    }

    public static void tr_fillrect(int x, int y) {
      current_grid.FillCell(x, y);
    }

    public static void trains_paint(Train trn) {
      throw new NotImplementedException();

      //for(; trn != null; trn = trn.next) {
      //  if(trn.position) {
      //    if(!show_icons) {
      //      int tmp = trn.position.fgcolor;
      //      trn.position.fgcolor = color_orange;
      //      track_paint(trn.position);
      //      trn.position.fgcolor = tmp;
      //      continue;
      //    } else if((trn.flags & TFLG.TFLG_STRANDED) != 0) {
      //      if(findTrain(trn.position.x, trn.position.y))
      //        continue;
      //      car_draw(trn.position, trn);
      //    } else
      //      train_draw(trn.position, trn);
      //  }
      //  if(trn.tail != null && trn.tail.position != null &&
      //    trn.tail.position != trn.position)
      //    car_draw(trn.tail.position, trn);
      //}
    }

    public static void draw_all_pixmap() {
      grid g;
      
      g = field_grid;
#if DEBUG
      System.Drawing.Graphics gr = ((System.Windows.Forms.Control)g.m_parent).CreateGraphics();
      gr.DrawImage(g.m_pixmap, 0, 0);
#else
      ClientDC clientDC = new ClientDC(g.m_parent);
      ScrolledWindow window = (ScrolledWindow)g.m_parent;
      window.PrepareDC(clientDC);
      BufferedDC wdc = new BufferedDC(clientDC, g.m_pixmap);
#endif
    }

    public static void reset_clip_rect()	/* next time, don't paint anything */
    {
#if true // Erik
      Globals.cliprect.top = 0;
      Globals.cliprect.bottom = Configuration.YNCELLS -1;
      Globals.cliprect.left = 0;
      Globals.cliprect.right = Configuration.XNCELLS - 1;
      ignore_cliprect = false;
      Array.Clear(update_map, 0, update_map.Length);
#else
      Globals.cliprect.top = Configuration.YNCELLS;
      Globals.cliprect.bottom = 0;
      Globals.cliprect.left = Configuration.XNCELLS;
      Globals.cliprect.right = 0;
      ignore_cliprect = false;
      Array.Clear(update_map, 0, update_map.Length);
#endif
    }


    // TODO Uncomment everything inside this function
    public static void repaint_all() {
      current_grid = field_grid;
      if(!editing && Globals.cliprect.top > Globals.cliprect.bottom)
        return; /* no changes since last update */
      if(ignore_cliprect || editing)
        clear_field();
      updating_all = true;
      if(show_grid)
        grid_paint();
      //if(bShowCoord)
      //  coord_paint(null);
#if DEBUG
      reset_clip_rect();
#endif


      layout_paint(LayoutList);
      //trains_paint(stranded);
      //trains_paint(schedule);
      //updating_all = false;
      draw_all_pixmap();
      reset_clip_rect();
    }

    public static void flash_signals() {
      Signal s;

      //for(s = (Signal)signal_list; s != null; s = (Signal)s.next1) {
      //  if(!s._isFlashing)
      //    continue;
      //  s.OnFlash();
      //}
    }

    public static void click_time() {
      throw new NotImplementedException();
      //int i;
      //int oldmult;
      //Train t;

      //if(!running) {
      //  flash_signals();
      //  repaint_all();
      //  return;
      //}
      //changed = 0;
      //signals_changed = 0;
      //for(i = oldmult = time_mult; i > 0; --i) {
      //  time_mult = 1;
      //  time_step();
      //  if(time_mult != 1)		// if changed by a trigger
      //    oldmult = time_mult;	// we'll restore the new value
      //  UpdateSignals(null, false);
      //  if((current_time % 60) == 59) {	// at the top of a minute
      //    // record how many late minutes we have accumulated
      //    late_data[(current_time / 60) % (60 * 24)] = total_late;
      //  }
      //  record_state();
      //}
      //flash_signals();
      //if(changed != 0)
      //  repaint_all();
      //changed = 0;
      //time_mult = oldmult;
      //while(save_assign_list != null) {
      //  SaveAssign s = save_assign_list;
      //  save_assign_list = s.next;
      //  assign_train(s.newTrain, s.oldTrain);
      //  Globals.free(s);
      //}
      //update_labels();
      //for(t = schedule; t != null; t = t.next)
      //  if(t.newsched != null)
      //    break;
      //if(t != null) {
      //  // some train's data was updated
      //  // - update all timetable views in our UI
      //  for(t = schedule; t != null; t = t.next)
      //    if(t.newsched != 0) {
      //      update_schedule(t);
      //    }
      //  // - tell any waiting servers (i.e. the web server)
      //  timetable.NotifyListeners();
      //}
    }




    // TODO Remove this item once the code will be fully converted
    public static char PLATFORM_SEP = wxPorting.T('@');

    // TODO Handle the following items
    public static bool gbTrkFirst = false;
    public static string current_project;
    public static LogFilter gLogger = new LogFilter();
    public static int gnErrors = 0;
    public static Track layout;
    public static grcolor[] fieldcolors =
      new grcolor[(int)fieldcolor.MAXFIELDCOL];
    public static TextList track_info;
    public static Itinerary itineraries;
    public static bool powerSpecified;
    public static int layout_modified1;
    public static Script scriptList;
    public static TrainDirPorting.Array<Track> onIconUpdateListeners;
    public static FileOption searchPath = new FileOption(
      wxPorting.T("SearchPath"),
      wxPorting.T("Directories with signal scripts"),
      wxPorting.T("Environment"),
      wxPorting.T("")
    );
    public static SwitchBoard switchBoards;
    public static SwitchBoard curSwitchBoard;	    // TODO: move to a SwitchBoardCell field
    public static grid current_grid, field_grid, tools_grid;

    public static tr_rect cliprect = new tr_rect();
    public static bool ignore_cliprect;

    public static TDSkin skin_list;
    public static TDSkin curSkin;
    public static TDSkin defaultSkin;

    public static int gFontSizeSmall = 7;
    public static int gFontSizeBig = 10;

    public static byte[][] colortable = new byte[15][]{
      new byte[] { 0, 0, 0 },
      new byte[] { 255, 255, 255 },
      new byte[] { 0, 255, 0 },
      new byte[] { 255, 255, 0 },
      new byte[] { 255, 0, 0 },
      new byte[] { 255, 128, 0 },
      new byte[] { 255, 128, 128 },
      new byte[] { 128, 128, 128 },
      new byte[] { 168, 168, 168 }, //	new byte[] { 192, 192, 192 },
      new byte[] { 64, 64, 64 },
      new byte[] { 0, 0, 255 },	    // blue
      new byte[] { 0, 255, 255 },    // cyan
      new byte[] { 202, 31, 123 },   // magenta
      new byte[] { 0, 0, 0, },       // free
      new byte[] { 0, 0, 0 }	    // [14] : custom color for option colorBg
    };

    public static grcolor color_white;
    public static grcolor color_black;
    public static grcolor color_green;
    public static grcolor color_yellow;
    public static grcolor color_red;
    public static grcolor color_orange;
    public static grcolor color_brown;
    public static grcolor color_gray;
    public static grcolor color_lightgray;
    public static grcolor color_darkgray;
    public static grcolor color_magenta;
    public static grcolor color_blue;
    public static grcolor color_cyan;

    public static bool bShowCoord = true;

    public static Action<Track> track_properties_dialog;
    public static Action<Signal> signal_properties_dialog;
    // Erik: I've disabled the following line
    // public static Func<Track, object> switch_properties_dialog;
    public static Action<Track> trigger_properties_dialog;
    public static Action performance_dialog;
    public static Action options_dialog;
    public static Action select_day_dialog;
    public static Action<Train> train_info_dialog;
    public static Action<Train> assign_dialog;
    public static Action<String> station_sched_dialog;
    public static Action<Itinerary> itinerary_dialog;
    public static Action about_dialog;

    // Erik's new (temporary) item
    public static List<Track> LayoutList {
      get {
        List<Track> result = new List<Track>();
        
        Track t = layout;
        for(t = Globals.layout; t != null; t = t.next) {
          result.Add(t);
        }

        return result;
      }
    }



    public static void ShowTrackProperties(Track trk) {
      throw new NotImplementedException();
      //TrackDialog diag = new TrackDialog(Globals.traindir.m_frame);

      //diag.ShowModal(trk);
    }


    public static void ShowTrackScriptDialog(Track trk) {
      throw new NotImplementedException();
      //TrackScriptDialog diag = new TrackScriptDialog(Globals.traindir.m_frame);

      //diag.ShowModal(trk);
    }


    public static void ShowSignalProperties(Signal sig) {
      throw new NotImplementedException();
      //SignalDialog diag = new SignalDialog(Globals.traindir.m_frame);

      //diag.ShowModal(sig);
    }

    public static void ShowTriggerProperties(Track trk) {
      throw new NotImplementedException();
      //TriggerDialog diag = new TriggerDialog(Globals.traindir.m_frame);

      //diag.ShowModal(trk);
    }

    public static void switch_properties_dialog(Track sw) {
      throw new NotImplementedException();
      //TrackDialog diag = new TrackDialog(Globals.traindir.m_frame);

      //diag.ShowModal(sw);
    }

    public static void ShowPerformance() {
      throw new NotImplementedException();
      //HtmlPage page = new HtmlPage(wxPorting.T(""));
      //show_schedule_status(page);

      //Globals.traindir.m_frame.ShowHtml(wxPorting.L("Performance"), page.content);
    }

    public static void ShowSwitchboard() {
      throw new NotImplementedException();
      //HtmlPage page = new HtmlPage(wxPorting.T(""));
      //get_switchboard(page);

      //Globals.traindir.m_frame.ShowHtml(wxPorting.L("Switchboard"), page.content);
    }

    public static void ShowOptionsDialog() {
      throw new NotImplementedException();
      //OptionsDialog opts = new OptionsDialog(Globals.traindir.m_frame);
      //opts.ShowModal();
    }

    public static void ShowDaySelectionDialog() {
      throw new NotImplementedException();
      //DaysDialog days = new DaysDialog(Globals.traindir.m_frame);
      //days.ShowModal();
    }

    public static void ShowTrainInfo(Train trn) {
      throw new NotImplementedException();
      //HtmlPage page = new HtmlPage(wxPorting.T(""));

      //train_print(trn, page);
      //Globals.traindir.m_frame.ShowHtml(wxPorting.L("Train Info"), page.content);
    }

    public static void ShowTrainInfoDialog(Train trn) {
      throw new NotImplementedException();
      //TrainInfoDialog diag = new TrainInfoDialog(Globals.traindir.m_frame);
      //diag.ShowModal(trn);
    }

    public static void ShowScenarioInfoDialog() {
      throw new NotImplementedException();
      //ScenarioInfoDialog diag = new ScenarioInfoDialog(Globals.traindir.m_frame);
      //diag.ShowModal();
    }

    public static void ShowAssignDialog(Train trn) {
      throw new NotImplementedException();
      //AssignDialog diag = new AssignDialog(Globals.traindir.m_frame);
      //diag.ShowModal(trn);
    }

    public static void ShowStationSchedule(String name, bool saveToFile) {
      throw new NotImplementedException();
      //HtmlPage page = new HtmlPage(wxPorting.T(""));

      //if(name == null)
      //  return;
      //build_station_schedule(name);
      //do_station_list_print(name, page);
      //if(!saveToFile) {
      //  Globals.traindir.m_frame.ShowHtml(wxPorting.L("Station Schedule"), page.content);
      //  return;
      //}
      //Globals.traindir.SaveHtmlPage(page);
    }

    public static void ShowStationScheduleDialog(String name) {
      throw new NotImplementedException();
      //StationInfoDialog diag = new StationInfoDialog(Globals.traindir.m_frame);

      //diag.ShowModal(name);
    }

    public static void ShowItineraryDialog(Itinerary it) {
      throw new NotImplementedException();
      //ItineraryDialog itin = new ItineraryDialog(Globals.traindir.m_frame);

      //itin.ShowModal(it);
    }

    public static void ShowWelcomePage() {
      throw new NotImplementedException();
      //HtmlPage page = new HtmlPage(wxPorting.T(""));

      //Globals.traindir.BuildWelcomePage(page);
      //Globals.traindir.m_frame.ShowHtml(wxPorting.L("Welcome"), page.content);
    }

    private static T[] realloc<T>(T[] arr, int newSize) {
      if(arr == null)
        arr = new T[newSize];

      if(newSize == arr.Length)
        return arr;

      T[] newArr = new T[newSize]; 
      Array.Copy(arr, newArr, Math.Min(arr.Length, newArr.Length));
      arr = newArr;

      return arr;
    }

    public static void setBackgroundColor(out System.Drawing.Color col) {
      int rgb = curSkin.background;
      col = System.Drawing.Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
    }


    public static void create_colors() {
      color_black = 0;
      color_white = 1;
      color_green = 2;
      color_yellow = 3;
      color_red = 4;
      color_orange = 5;
      color_brown = 6;
      color_gray = 7;
      color_lightgray = 8;
      color_darkgray = 9;
      color_blue = 10;
      color_cyan = 11;
      color_magenta = 12;

      fieldcolors[(int)fieldcolor.COL_BACKGROUND] = color_lightgray;
      fieldcolors[(int)fieldcolor.COL_TRACK] = color_black;
      fieldcolors[(int)fieldcolor.COL_GRAPHBG] = color_lightgray;

      fieldcolors[(int)fieldcolor.COL_TRAIN1] = color_orange;
      fieldcolors[(int)fieldcolor.COL_TRAIN2] = color_cyan;
      fieldcolors[(int)fieldcolor.COL_TRAIN3] = color_blue;
      fieldcolors[(int)fieldcolor.COL_TRAIN4] = color_yellow;
      fieldcolors[(int)fieldcolor.COL_TRAIN5] = color_white;
      fieldcolors[(int)fieldcolor.COL_TRAIN6] = color_red;
      fieldcolors[(int)fieldcolor.COL_TRAIN7] = color_brown;
      fieldcolors[(int)fieldcolor.COL_TRAIN8] = color_green;
      fieldcolors[(int)fieldcolor.COL_TRAIN9] = color_magenta;
      fieldcolors[(int)fieldcolor.COL_TRAIN10] = color_lightgray;

      curSkin = new TDSkin();
      curSkin.free_track = getcolor_rgb(color_black);
      curSkin.reserved_track = getcolor_rgb(color_green);
      curSkin.reserved_shunting = getcolor_rgb(color_white);
      curSkin.occupied_track = getcolor_rgb(color_orange);
      curSkin.working_track = getcolor_rgb(color_blue);
      curSkin.background = getcolor_rgb(color_lightgray);
      curSkin.outline = getcolor_rgb(color_darkgray);
      curSkin.text = getcolor_rgb(color_black);
      curSkin.name = String.Copy(wxPorting.T("default"));
      curSkin.next = null;
      skin_list = curSkin;
      defaultSkin = curSkin;
    }

    public static int getcolor_rgb(int col) {
      int c = colortable[col][0] << 16;
      c |= colortable[col][1] << 8;
      c |= colortable[col][2];
      return c;
    }

    public static void getcolor_rgb(int col, out byte r, out byte g, out byte b) {
      r = g = b = 0;
      if(col < 0 || col > 11)
        return;
      r = colortable[col][0];
      g = colortable[col][1];
      b = colortable[col][2];
    }

    public static void create_draw(object/*ScrolledWindow*/ parent) {
      grid g;

      g = new grid(parent, Configuration.XMAX * 2, Configuration.YMAX * 2);
      g.m_hmult = Configuration.HGRID;
      g.m_vmult = Configuration.VGRID;
      field_grid = g;
      current_grid = g;
      set_show_coord(true);
    }

    public static void set_show_coord(bool opt) {
      bShowCoord = opt;
      if(opt) {
        field_grid.m_xBase = Configuration.HCOORDBAR;
        field_grid.m_yBase = Configuration.VCOORDBAR;
      } else {
        field_grid.m_xBase = 0;
        field_grid.m_yBase = 0;
      }
    }

    // TODO Implement this function
    public static void init_pmaps() {
      //byte r, g, b;
      //byte fgr, fgg, fgb;
      //int i;
      //string bufffg;
      //string buffcol;

      //getcolor_rgb(fieldcolors[COL_TRACK], out fgr, out fgg, out fgb);
      //sprintf(bufffg, ".      c #%02x00%02x00%02x00", fgr, fgg, fgb);
      //getcolor_rgb(fieldcolors[COL_BACKGROUND], out r, out g, out b);
      //sprintf(buff, "       c #%02x00%02x00%02x00", r, g, b);
      //sprintf(buff, "       c lightgray", r, g, b);

      //e_train_xpm[1] = w_train_xpm[1] = car_xpm[1] = buff;
      //e_train_xpm[2] = w_train_xpm[2] = car_xpm[2] = bufffg;
      //e_train_xpm[3] = w_train_xpm[3] = car_xpm[3] = buffcol;

      //for(i = 0; i < Config.NTTYPES; ++i) {
      //  sprintf(buffcol, "X      c %s", ttypecolors[i]);
      //  e_train_pmap[i] = get_pixmap(e_train_xpm);
      //  w_train_pmap[i] = get_pixmap(w_train_xpm);
      //  e_car_pmap[i] = get_pixmap(car_xpm);
      //  w_car_pmap[i] = get_pixmap(car_xpm);
      //}

      Signal.InitPixmaps();

      //sprintf(buff, "       c #%02x00%02x00%02x00", r, g, b);
      //sprintf(bufffg, ".      c #%02x00%02x00%02x00", fgr, fgg, fgb);
      //speed_xpm[1] = buff;
      //speed_xpm[2] = bufffg;
      //speed_pmap = get_pixmap(speed_xpm);

      //for(r = 0; r < 4; ++r) {
      //  e_train_pmap_default[r] = e_train_pmap[r];
      //  w_train_pmap_default[r] = w_train_pmap[r];
      //  e_car_pmap_default[r] = e_car_pmap[r];
      //  w_car_pmap_default[r] = w_car_pmap[r];
      //}

      //// tools-types pixmaps

      //tracks_pixmap = get_pixmap(tracks_xpm);
      //switches_pixmap = get_pixmap(switches_xpm);
      //signals_pixmap = get_pixmap(signals_xpm);
      //tools_pixmap = get_pixmap(tools_xpm);
      //actions_pixmap = get_pixmap(actions_xpm);
      //move_start_pixmap = get_pixmap(move_start_xpm);
      //move_end_pixmap = get_pixmap(move_end_xpm);
      //move_dest_pixmap = get_pixmap(move_dest_xpm);
      //set_power_pixmap = get_pixmap(set_power_xpm);
    }

    public static void localizeArray(ref string[] localized, string[] english) {
      int i;

      localized = new string[english.Length];
      for(i = 0; String.IsNullOrEmpty(english[i]) == false; ++i)
        localized[i] = String.Copy(wxPorting.LV(english[i]));
    }

    public static void freeLocalizedArray(string[] localized) {
      //int i;

      //for(i = 0; localized[i]; ++i) {
      //  Globals.free((object)localized[i]);
      //  localized[i] = 0;
      //}
    }


    internal static string format_time(TimeSpan timeSpan) {
      throw new NotImplementedException();
    }
  }

  public class TDString {
    public static implicit operator TDString(string str) {
      return new TDString();
    }
    public static implicit operator string(TDString str) {
      return "";
    }
  }

  public partial class Config {
    public const int NTTYPES = 10;

    public static int MAXNOTES = 5;

    public static int MAX_FLASHING_ICONS = 4;

    public static int MAX_DELAY = 10;
    public static char DELAY_CHAR = '!';

  }

  public partial class Configuration {
    public const int HGRID = 9;
    public const int VGRID = 9;

    public const int HCOORDBAR = 20;
    public const int VCOORDBAR = 30;

    public const int XNCELLS = 440;	    // 3.7n - was 226
    public const int YNCELLS = 228;	    // 3.7o - was 114

    public static int XMAX { get { return ((XNCELLS * HGRID) + HCOORDBAR) /* 440*9 */ ; } }
    public static int YMAX { get { return ((YNCELLS * VGRID) + VCOORDBAR) /* 1026 */ ; } }

    public static int NUMTTABLES { get { return (MenuIDs.LAST_TTABLE - MenuIDs.FIRST_TTABLE + 1); } }
    public static int NUMCANVASES { get { return (MenuIDs.LAST_CANVAS - MenuIDs.FIRST_CANVAS + 1); } }
    public static int NUMHTMLS { get { return (MenuIDs.LAST_HTML - MenuIDs.FIRST_HTML + 1); } }
  }



  static class wxPorting {
    // TODO Implement this funcion
    public static void wxSetWorkingDirectory(string p) {
      // throw new NotImplementedException();
    }

    // TODO Remove this function and replace with a better one!
    public static string L(string p) {
      return I18N.L(p);
    }

    // TODO Remove this function and replace with a better one!
    public static string T(string p) {
      return I18N.T(p);
    }

    // TODO Remove this function and replace with a better one!
    public static char T(char p) {
      return I18N.T(p);
    }

    // TODO Remove this function and replace with a better one!
    internal static string LV(string p) {
      return I18N.LV(p);
    }
  }


  public class wxTextFile {
    internal void Write(int p) {
      throw new NotImplementedException();
    }

    internal void Close() {
      throw new NotImplementedException();
    }

    internal bool Open(string fname) {
      throw new NotImplementedException();
    }

    internal void Clear() {
      throw new NotImplementedException();
    }

    internal bool Create(string fname) {
      throw new NotImplementedException();
    }

    internal int GetLineCount() {
      throw new NotImplementedException();
    }
  }

  public class Timer {
    System.Timers.Timer mTimer;
    ElapsedEventHandler mCallback;

    public Timer(Window window, MenuIDs timerID, ElapsedEventHandler callback) {
      mTimer = new System.Timers.Timer();
      mCallback = callback;
      mTimer.Elapsed += new System.Timers.ElapsedEventHandler(mTimer_Elapsed);
    }

    void mTimer_Elapsed(object sender, ElapsedEventArgs e) {
      if(mCallback != null)
        mCallback(sender, e);
    }

    public void Start(int interval) {
      mTimer.Interval = interval;
      mTimer.Start();
    }
  }


  public enum MenuIDs {
    MENU_TIME_SPLIT = 100,
    MENU_TIME_TAB,
    MENU_TIME_FRAME,

    MENU_SHOW_LAYOUT,
    MENU_SHOW_SCHEDULE,
    MENU_INFO_PAGE,

    MENU_ZOOMIN,
    MENU_ZOOMOUT,

    MENU_SHOW_COORD,
    MENU_TOOLBAR,
    MENU_STATUSBAR,
    MENU_COPYRIGHT,
    MENU_LANGUAGE,

    MENU_RECENT,
    MENU_RESTORE,
    MENU_EDIT,
    MENU_NEW_TRAIN,
    MENU_ITINERARY,
    MENU_SWITCHBOARD,
    MENU_SAVE_LAYOUT,
    MENU_PREFERENCES,
    MENU_EDIT_SKIN,
    MENU_NEW_LAYOUT,
    MENU_INFO,
    MENU_STATIONS_LIST,

    MENU_START,
    MENU_GRAPH,
    MENU_LATEGRAPH,
    MENU_PLATFORMGRAPH,
    MENU_RESTART,
    MENU_FAST,
    MENU_SLOW,
    MENU_SKIP,
    MENU_STATION_SCHED,
    MENU_SETGREEN,
    MENU_SELECT_ITIN,
    MENU_PERFORMANCE,

    MENU_ITIN_DELETE,
    MENU_ITIN_PROPERTIES,
    MENU_ITIN_SAVE,

    MENU_ALERT_CLEAR,
    MENU_ALERT_SAVE,

    MENU_HTML_PRINTSETUP,
    MENU_HTML_PREVIEW,
    MENU_HTML_PRINT,

    MENU_SCHED_SHOW_CANCELED,
    MENU_SCHED_SHOW_ARRIVED,
    MENU_SCHED_ASSIGN,
    MENU_SCHED_TRACK_FIRST,
    MENU_SCHED_TRACK_LAST,
    MENU_SCHED_PRINT_TRAIN,

    MENU_COORD_DEL_1,
    MENU_COORD_DEL_N,
    MENU_COORD_INS_1,
    MENU_COORD_INS_N,

    ID_RADIOBOX,
    ID_CHECKBOX,
    ID_LIST,
    ID_NOTEBOOK_TOP,
    ID_NOTEBOOK_LEFT,
    ID_NOTEBOOK_RIGHT,

    ID_SPEEDTEXT,
    ID_SPIN,
    ID_RUN,
    ID_ASSIGN,
    ID_SHUNT,
    ID_SPLIT,
    ID_PROPERTIES,
    ID_PRINT,
    ID_ASSIGNSHUNT,
    ID_REVERSEASSIGN,
    ID_SCRIPT,

    ID_CHOICE,

    ID_ITINSELECT,
    ID_ITINCLEAR,

    TIMER_ID = 1000,

    FIRST_CANVAS = 1100,
    LAST_CANVAS = 1199,

    FIRST_TTABLE = 1200,
    LAST_TTABLE = 1299,

    FIRST_HTML = 1300,
    LAST_HTML = 1399
  };


}
