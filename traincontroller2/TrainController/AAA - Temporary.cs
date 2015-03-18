using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx.Archive;
using TrainController.SimCommands;
using wx;
using System.Timers;
using System.Drawing;

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
    public System.Drawing.Image pixels;
  }

  partial class Globals {
    public static String version = wxPorting.T("3.8v");

    // TODO Implement this function
    public static void do_alert(String msg) {
      //alert_msg = String.Copy(msg);
      //repaint_labels();
      //Globals.traindir.AddAlert(msg);
      //if(beep_on_alert)
      //  alert_beep();
    }

    public static VLines[] switch_rect = new VLines[] {
	new VLines( 0, 0, Configuration.HGRID - 1, 0 ),
	new VLines( Configuration.HGRID - 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 0, 0, Configuration.VGRID - 1 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static System.Drawing.Image speed_pmap;
    public static String[] speed_xpm = new String[] {
"8 3 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
"X      c #000000000000",
"  ....  ",
" ..  .. ",
"  ....  "};



    public static VLines[] block_layout = new VLines[] {
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 2 ),
	new VLines( -1 )
};

    public static VLines[] block_layout_ns = new VLines[] {
	new VLines( Configuration.HGRID / 2 - 1, Configuration.VGRID / 2, Configuration.HGRID / 2 + 2, Configuration.VGRID / 2 ),
	new VLines( -1 )
};

    public static VLines[] station_block_layout = new VLines[] {
	new VLines( Configuration.HGRID / 2, 0, 0, Configuration.VGRID / 2 ),
	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID / 2, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2, 0, Configuration.HGRID - 1, Configuration.VGRID / 2 ),
	new VLines( -1 )
};


    public static VLines[] nw_se_layout = new VLines[] {
	new VLines( 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] sw_ne_layout = new VLines[] {
	new VLines( 0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0 ),
	new VLines( 1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1 ),
	new VLines( -1 )
};

    public static VLines[] n_s_layout = new VLines[]{
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),
	new VLines(-1)
};

    public static VLines[] sw_n_layout = new VLines[] {
	new VLines( Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2, 0, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 1, 0, Configuration.VGRID - 2 ),
	new VLines( -1 )
};

    public static VLines[] nw_s_layout = new VLines[] {
	new VLines( 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 ),
	new VLines( 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 ),
	new VLines( 0, 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] se_n_layout = new VLines[] {
	new VLines( Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] ne_s_layout = new VLines[] {
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, 0 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2, Configuration.HGRID - 1, 0 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, Configuration.HGRID - 1, 1 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] w_e_layout = new VLines[] {
	/*new VLines( 0, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1 ),*/
	new VLines( 0, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( -1 )
};

    public static VLines[] nw_e_layout = new VLines[] {
	new VLines( 1, 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 1 ),
	new VLines( 0, 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0 ),
	new VLines( 0, 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1 ),
	/*new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1 ),*/
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( -1 )
};

    public static VLines[] sw_e_layout = new VLines[] {
	new VLines( 0, Configuration.VGRID - 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 /*- 1*/ ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0 ),
	new VLines( 1, Configuration.VGRID - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1 ),
	/*new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1 ),*/
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( -1 )
};

    public static VLines[] w_ne_layout = new VLines[] {
	/*new VLines( 0, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 - 1 ),*/
	new VLines( 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, 0 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, 0 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, 1 ),
	new VLines( -1 )
};

    public static VLines[] w_se_layout = new VLines[] {
	/*new VLines( 0, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 1 ),*/
	new VLines( 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 /*- 1*/, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] sweng_sw_ne_straight = new VLines[] {
	new VLines( 0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0 ),
	new VLines( 1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1 ),

	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 + 1 ),

	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0 ),
	new VLines( -1 )
};

    public static VLines[] sweng_sw_ne_switched = new VLines[] {

	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID - 2, 0 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, 0 ),

	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 ),
	new VLines( 1, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( -1 )
};

    public static VLines[] sweng_nw_se_straight = new VLines[] {
	new VLines( 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1 ),

	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 ),
	new VLines( 0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 + 1 ),

	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0 ),
	new VLines( -1 )
};

    public static VLines[] sweng_nw_se_switched = new VLines[] {

	new VLines( 0, 0, Configuration.HGRID - 1, Configuration.VGRID / 2 ),
	new VLines( 0, 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1 ),

	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

    public static VLines[] swengv_sw_ne_straight = new VLines[] {
	new VLines( Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),

	new VLines( 0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0 ),
	new VLines( 1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1 ),

	new VLines( -1 )
};

    public static VLines[] swengv_sw_ne_switched = new VLines[] {

	new VLines( 0, Configuration.VGRID - 2, Configuration.HGRID / 2 - 0, 0 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID / 2 + 1, 0 ),

	new VLines( Configuration.HGRID / 2 - 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0 ),
	new VLines( Configuration.HGRID / 2 + 1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1 ),
	new VLines( -1 )
};

    public static VLines[] swengv_nw_se_straight = new VLines[] {
	new VLines( Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines( Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),

	new VLines( 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1 ),

	new VLines( -1 )
};

    public static VLines[] swengv_nw_se_switched = new VLines[] {

	new VLines( 0, 0, Configuration.HGRID / 2 - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 1, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),

	new VLines( Configuration.HGRID / 2 - 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2 + 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( -1 )
};
    public static VLines[] etrigger_layout = new VLines[] {
	new VLines( 1, 2, Configuration.HGRID - 2, 2 ),
	new VLines( 1, 2, Configuration.HGRID / 2, Configuration.VGRID - 2 ),
	new VLines( Configuration.HGRID / 2, Configuration.VGRID - 2, Configuration.HGRID - 2, 2 ),
	new VLines( -1 )
};

    public static VLines[] wtrigger_layout = new VLines[] {
	new VLines( 1, Configuration.VGRID - 2, Configuration.HGRID - 2, Configuration.VGRID - 2 ),
	new VLines( 1, Configuration.VGRID - 2, Configuration.HGRID / 2, 2 ),
	new VLines( Configuration.HGRID / 2, 2, Configuration.HGRID - 2, Configuration.VGRID - 2 ),
	new VLines( -1 )
};

    public static VLines[] ntrigger_layout = new VLines[] {
	new VLines( 2, 1, 2, Configuration.VGRID - 2 ),
	new VLines( 2, 1, Configuration.HGRID - 2, Configuration.VGRID / 2 ),
	new VLines( 2, Configuration.VGRID - 2, Configuration.HGRID - 2, Configuration.VGRID / 2 ),
	new VLines( -1 )
};

    public static VLines[] strigger_layout = new VLines[] {
	new VLines( Configuration.HGRID - 2, 1, Configuration.HGRID - 2, Configuration.VGRID - 2 ),
	new VLines( 2, Configuration.VGRID / 2, Configuration.HGRID - 2, 1 ),
	new VLines( 2, Configuration.VGRID / 2, Configuration.HGRID - 2, Configuration.VGRID - 2 ),
	new VLines( -1 )
};

    public static System.Drawing.Image itin_pmap;
    public static String[] itin_xpm = new String[] {
"8 9 4 1",
"       c lightgray",
".      c #000000000000",
"X      c gray",
"#      c black",
"        ",
"  ....  ",
" ...... ",
"..XXXX..",
".XXXXXX.",
"..XXXX..",
"#......#",
" #....# ",
"  ####  "
};

    public static System.Drawing.Image camera_pmap;
    public static String[] camera_xpm = new String[] {
"13 10 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
"X      c #0000FFFFFFFF",
"             ",
"   ..        ",
" ........... ",
" . ..      . ",
" .   ...   . ",
" .   . .   . ",
" .   ...   . ",
" .         . ",
" ........... ",
"             "};

    public static TrainControllerApp traindir {
      get {
        return TrainControllerApp.GetInstance();
      }
    }

    // TODO Handle this vars
    public static _conf conf;
    public static bool show_speeds = false;
    public static bool show_blocks = false;
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
    public static List<pxmap> pixmaps = new List<pxmap>();

    public static void draw_link(int x0, int y0, int x1, int y1, int color) {
      field_grid.DrawLineCenterCell(x0, y0, x1, y1, color);
    }

    public static System.Drawing.Image get_pixmap_file(String fname) {
      System.Drawing.Image img;

      TDFile xpmFile = new TDFile(fname);

      if(!xpmFile.Load())
        return null;

      gLogger.SetExtraInfo(fname);

      List<String> pattern = new List<string>();
      int i, j, k;
      string buff;

      // collect all strings (delimited by double-quotes)
      // from the file and store them in pattern[],
      // one string per entry.

      while(xpmFile.ReadLine(out buff)) {
        j = buff.IndexOf('"');
        k = buff.IndexOf('"', j + 1);
        if(j < 0 || j < 0)
          continue;
        j++;
        k--;

        pattern.Add(buff.Substring(j, k));
      }

      // now analyze the lines to check if the image is correct
      img = PixMap.FromXpmData(pattern.ToArray());

      // TODO Enable errors
      //if(img == null) {
      //  buff = String.Format(wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
      //  Globals.traindir.layout_error(buff);
      //}

      return img;
    }

    public static int get_pixmap_index(String mapname) {
      int i;

      if(String1.IsNullOrWhiteSpaces(mapname))
        return -1;

      for(i = 0; i < pixmaps.Count(); ++i) {
        if(mapname.Equals(pixmaps[i].name))
          return i;
      }
      pxmap pmap = new pxmap();
      if((pmap.pixels = get_pixmap_file(mapname)) == null)
        return -1;          /* failed! file does not exist */
      pmap.name = String.Copy(mapname);
      pixmaps.Add(pmap);
      return pixmaps.Count() - 1;
    }

    public static System.Drawing.Image get_pixmap(String[] pxpm) {
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
      g.m_dc.FillRectangle(System.Drawing.Brushes.LightGray, 0, 0, Configuration.XMAX, Configuration.VCOORDBAR);
      g.m_dc.FillRectangle(System.Drawing.Brushes.LightGray, 0, 0, Configuration.HCOORDBAR, Configuration.YMAX);

      // draw digits
      g.m_dc.SetFont(font);
      g.m_dc.SetBackgroundMode((int)DCBackgroundMode.SOLID);
      g.m_dc.SetTextForeground(Color.Black);
      g.m_dc.SetTextBackground(Color.LightGray);
      System.Drawing.Point pt = new System.Drawing.Point(0, 0);
      for(i = 0; i < Configuration.XNCELLS; ++i) {
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(Color.White);
        buff = String.Format("{0:D}", i / 100);
        pt.X = i * Configuration.HGRID + Configuration.HCOORDBAR;
        pt.Y = 0;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format("{0:D}", (i / 10) % 10);
        pt.Y = 8;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format("{0:D}", i % 10);
        pt.Y = 16;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(Color.Black);
      }
      for(i = 0; i < Configuration.YNCELLS; ++i) {
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Color.White);
        buff = String.Format("{0:D3}", i);
        pt.X = 0;
        pt.Y = i * Configuration.VGRID + Configuration.VCOORDBAR;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Color.Black);
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

    public static void draw_layout(int x0, int y0, VLines[] p, Color col) {
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
    public static void draw_layout_text_font(int x, int y, String txt, int index) {
      current_grid.DrawTextFont(x, y, txt, index);
    }

    public static void draw_layout_text1(int x, int y, String txt, bool size) {
      current_grid.DrawText1(x, y, txt, size);
    }

    public static void text_draw(Track t) {
      if(t.station == null)
        return;
      tr_fillrect(t.x, t.y);
      if(t._fontIndex != 0)
        draw_layout_text_font(t.x, t.y, t.station.FullName, t._fontIndex);
      else
        draw_layout_text1(t.x, t.y, t.station.FullName, t.direction != trkdir.NODIR);
      if(!editing || !show_links)
        return;
      if(t.elinkx != 0 && t.elinky != 0)
        draw_link(t.x, t.y, t.elinkx, t.elinky, conf.linkcolor);
      else if(t.wlinkx != 0 && t.wlinky != 0)
        draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
    }

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

    public static void link_draw(Track t) {
      tr_fillrect(t.x, t.y);
      if(t.direction == trkdir.W_E)
        draw_layout_text1(t.x, t.y, wxPorting.T("...to..."), true);
      else
        draw_layout_text1(t.x, t.y, wxPorting.T("Link..."), true);
    }

    public static void image_draw(Track t) {
      string buff;
      String p;
      System.Drawing.Image pixels = null;
      int ix;

      if(camera_pmap == null)
        camera_pmap = get_pixmap(camera_xpm);
      if(t.direction != trkdir.NODIR || t.station == null || t.station.FullName.Length == 0) {/* filename! */
        pixels = camera_pmap;
      } else {
        if(t._isFlashing && t._flashingIcons[t._nextFlashingIcon] != null)
          ix = get_pixmap_index(t._flashingIcons[t._nextFlashingIcon]);
        else
          ix = get_pixmap_index(t.station.FullName);
        if(ix < 0) {	    /* for UNIX, try lower case name */
          buff = String.Copy(t.station.FullName);
          // TODO Check how to convert this...
          //for(p = buff; *p; p.incPointer())
          //  if(p[0] >= 'A' && p[0] <= 'Z')
          //    *p += ' ';
          ix = get_pixmap_index(buff);
        }
        if(ix < 0) {
          buff = String.Format(wxPorting.T("%s '%s'."), wxPorting.L("Error reading"), t.station);
          Globals.do_alert(buff);
          pixels = camera_pmap;
          if(t._isFlashing)
            t._flashingIcons[t._nextFlashingIcon] = null;
          else
            t.station = null;
        } else
          pixels = pixmaps[ix].pixels;
      }
      draw_pixmap(t.x, t.y, pixels);
      if(editing && show_links && t.wlinkx != 0 && t.wlinky != 0)
        draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
    }

    public static void draw_itin_text(int x, int y, String txt, bool size) {
      if(current_grid == tools_grid)
        draw_layout_text1(x, y, txt, size);
      else
        draw_layout_text1(x + 1, y, txt, size);
    }

    public static void itin_draw(Track t) {
      if(itin_pmap == null)
        itin_pmap = get_pixmap(itin_xpm);

      tr_fillrect(t.x, t.y);
      draw_pixmap(t.x, t.y, itin_pmap);

      if(t.station != null && t.station.FullName != null) {
#if false // !Rask Ingemann Lambertsen
            draw_itin_text(t.x, t.y, t.station, t.direction == 1);
#else
        String label = t.station.PlatformName.Length > 0 ? t.station.PlatformName : t.station.StationName;
        draw_itin_text(t.x, t.y, label, t.direction == trkdir.W_E);
#endif
      }
    }

    public static void trigger_draw(Track t) {
      VLines[] img;

      switch(t.direction) {
        case trkdir.S_N:
          img = ntrigger_layout;
          break;
        case trkdir.N_S:
          img = strigger_layout;
          break;
        case trkdir.W_E:
          img = etrigger_layout;
          break;
        case trkdir.E_W:
          img = wtrigger_layout;
          break;
        default:
          return;
      }

      draw_layout(t.x, t.y, img, curSkin.working_track);
      if(editing && show_links) {
        if(t.wlinkx != 0 && t.wlinky != 0)
          draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
      }
    }

    public static Color translate_track_color(Track t) {
      Color fg = curSkin.free_track;

      switch(t.status) {
        case trkstat.ST_FREE:
          break;
        case trkstat.ST_BUSY:
          //		fg = color_red;
          return curSkin.occupied_track;
        case trkstat.ST_READY:
          //		fg = color_green;
          return curSkin.reserved_track;
        case trkstat.ST_WORK:
          //		fg = color_blue;
          return curSkin.working_track;
      }
      if(t.fgcolor == color_orange || t.fgcolor == color_red)
        return curSkin.occupied_track;
      if(t.fgcolor == color_green)
        return curSkin.reserved_track;
      if(t.fgcolor == color_white)
        return curSkin.reserved_shunting;
      if(t.fgcolor == color_blue)
        return curSkin.working_track;
      return fg;
    }

    public static void track_draw(Track t) {
      Color fg;
      trkdir tmp;
      int tot;
      VLines[] lns = n_s_layout;	// provide dummy initialization - always overwritten

      fg = translate_track_color(t);
      switch(t.direction) {

        case trkdir.TRK_N_S:
          if(t.power != null) {
            draw_mid_point(t.x, t.y, -2, 0, fg);
          }
          lns = n_s_layout;
          break;

        case trkdir.SW_N:
          lns = sw_n_layout;
          break;

        case trkdir.NW_S:
          lns = nw_s_layout;
          break;

        case trkdir.W_E:
          if(t.power != null) {
            draw_mid_point(t.x, t.y, 0, -2, fg);
          }
          lns = w_e_layout;
          break;

        case trkdir.NW_E:
          lns = nw_e_layout;
          break;

        case trkdir.SW_E:
          lns = sw_e_layout;
          break;

        case trkdir.W_NE:
          lns = w_ne_layout;
          break;

        case trkdir.W_SE:
          lns = w_se_layout;
          break;

        case trkdir.NW_SE:
          if(t.power != null) {
            draw_mid_point(t.x, t.y, 2, -2, fg);
          }
          lns = nw_se_layout;
          break;

        case trkdir.SW_NE:
          if(t.power != null) {
            draw_mid_point(t.x, t.y, -2, -2, fg);
          }
          lns = sw_ne_layout;
          break;

        case trkdir.NE_S:
          lns = ne_s_layout;
          break;

        case trkdir.SE_N:
          lns = se_n_layout;
          break;

        case trkdir.XH_NW_SE:
          tmp = t.direction;
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = tmp;
          return;

        case trkdir.XH_SW_NE:
          tmp = t.direction;
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = tmp;
          return;

        case trkdir.X_X:
          tmp = t.direction;
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = tmp;
          return;

        case trkdir.X_PLUS:
          tmp = t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = tmp;
          return;

        case trkdir.N_NE_S_SW:
          tmp = t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = tmp;
          return;

        case trkdir.N_NW_S_SE:
          tmp = t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = tmp;
          return;
      }

      draw_layout(t.x, t.y, lns, fg);
      if(show_blocks && t.direction == trkdir.W_E && t.length >= 100)
        draw_layout(t.x, t.y, block_layout, curSkin.outline); //fieldcolors[TRACK]);
      if(show_blocks && t.direction == trkdir.TRK_N_S && t.length >= 100)
        draw_layout(t.x, t.y, block_layout_ns, curSkin.outline); //fieldcolors[TRACK]);
      if(show_blocks && t.station != null && t.station.FullName.Length > 0)
        draw_layout(t.x, t.y, station_block_layout, curSkin.outline); //fieldcolors[TRACK]);
      if(editing && show_links) {
        if(t.wlinkx != 0 && t.wlinky != 0)
          draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor2);
        if(t.elinkx != 0 && t.elinky != 0)
          draw_link(t.x, t.y, t.elinkx, t.elinky, conf.linkcolor2);
      }
      if(!show_speeds)
        return;
      tot = 0;
      for(int tmp2 = 0; tmp2 < Config.NTTYPES; ++tmp2)
        tot += t.speed[tmp2];
      if(tot != 0)
        draw_pixmap(t.x, t.y, speed_pmap);
    }

    private static void draw_mid_point(int p, int p_2, int p_3, int p_4, Color fg) {
      throw new NotImplementedException();
    }

    public static void switch_draw(Track t) {
      Color fg;
      int tmp;

      fg = translate_track_color(t);
      tmp = (int)t.direction;
      switch(tmp) {
        case 0:
          if(editing) {
            t.direction = trkdir.W_NE;
            track_draw(t);
            t.direction = trkdir.W_E;
            track_draw(t);
          } else if(t.switched) {
            t.direction = trkdir.W_NE;
            track_draw(t);
          } else
            t.direction = trkdir.W_E;
          track_draw(t);
          break;

        case 1:
          if(editing) {
            t.direction = trkdir.NW_E;
            track_draw(t);
            t.direction = trkdir.W_E;
            track_draw(t);
          } else if(t.switched) {
            t.direction = trkdir.NW_E;
            track_draw(t);
          } else
            t.direction = trkdir.W_E;
          track_draw(t);
          break;

        case 2:
          if(editing) {
            t.direction = trkdir.W_SE;
            track_draw(t);
            t.direction = trkdir.W_E;
            track_draw(t);
          } else if(t.switched) {
            t.direction = trkdir.W_SE;
            track_draw(t);
          } else
            t.direction = trkdir.W_E;
          track_draw(t);
          break;

        case 3:
          if(editing) {
            t.direction = trkdir.SW_E;
            track_draw(t);
            t.direction = trkdir.W_E;
            track_draw(t);
          } else if(t.switched) {
            t.direction = trkdir.SW_E;
            track_draw(t);
          } else
            t.direction = trkdir.W_E;
          track_draw(t);
          break;

        case 4:
          if(editing) {
            t.direction = trkdir.SW_E;
            track_draw(t);
            t.direction = trkdir.SW_NE;
          } else if(t.switched)
            t.direction = trkdir.SW_E;
          else
            t.direction = trkdir.SW_NE;
          track_draw(t);
          break;

        case 5:
          if(editing) {
            t.direction = trkdir.W_NE;
            track_draw(t);
            t.direction = trkdir.SW_NE;
          } else if(t.switched)
            t.direction = trkdir.W_NE;
          else
            t.direction = trkdir.SW_NE;
          track_draw(t);
          break;

        case 6:
          if(editing) {
            t.direction = trkdir.NW_E;
            track_draw(t);
            t.direction = trkdir.NW_SE;
          } else if(t.switched) {
            t.direction = trkdir.NW_E;
          } else
            t.direction = trkdir.NW_SE;
          track_draw(t);
          break;

        case 7:
          if(editing) {
            t.direction = trkdir.W_SE;
            track_draw(t);
            t.direction = trkdir.NW_SE;
          } else if(t.switched)
            t.direction = trkdir.W_SE;
          else
            t.direction = trkdir.NW_SE;
          track_draw(t);
          break;

        case 8:				/* horizontal english switch */
          if(t.switched && !editing)
            draw_layout(t.x, t.y, sweng_sw_ne_switched, fg);
          else
            draw_layout(t.x, t.y, sweng_sw_ne_straight, fg);
          break;

        case 9:				/* horizontal english switch */
          if(t.switched && !editing)
            draw_layout(t.x, t.y, sweng_nw_se_switched, fg);
          else
            draw_layout(t.x, t.y, sweng_nw_se_straight, fg);
          break;

        case 10:
          if(editing) {
            t.direction = trkdir.W_SE;
            track_draw(t);
            t.direction = trkdir.W_NE;
          } else if(t.switched)
            t.direction = trkdir.W_SE;
          else
            t.direction = trkdir.W_NE;
          track_draw(t);
          break;

        case 11:
          if(editing) {
            t.direction = trkdir.SW_E;
            track_draw(t);
            t.direction = trkdir.NW_E;
          } else if(t.switched)
            t.direction = trkdir.SW_E;
          else
            t.direction = trkdir.NW_E;
          track_draw(t);
          break;

        case 12:
          if(editing) {
            t.direction = trkdir.TRK_N_S;
            track_draw(t);
            t.direction = trkdir.SW_N;
          } else if(t.switched)
            t.direction = trkdir.SW_N;
          else
            t.direction = trkdir.TRK_N_S;
          track_draw(t);
          break;

        case 13:
          if(editing) {
            t.direction = trkdir.TRK_N_S;
            track_draw(t);
            t.direction = trkdir.SE_N;
          } else if(t.switched)
            t.direction = trkdir.SE_N;
          else
            t.direction = trkdir.TRK_N_S;
          track_draw(t);
          break;

        case 14:
          if(editing) {
            t.direction = trkdir.TRK_N_S;
            track_draw(t);
            t.direction = trkdir.NW_S;
          } else if(t.switched)
            t.direction = trkdir.NW_S;
          else
            t.direction = trkdir.TRK_N_S;
          track_draw(t);
          break;

        case 15:
          if(editing) {
            t.direction = trkdir.TRK_N_S;
            track_draw(t);
            t.direction = trkdir.NE_S;
          } else if(t.switched)
            t.direction = trkdir.NE_S;
          else
            t.direction = trkdir.TRK_N_S;
          track_draw(t);
          break;

        case 16:			/* vertical english switch */
          if(t.switched && !editing)
            draw_layout(t.x, t.y, swengv_sw_ne_switched, fg);
          else
            draw_layout(t.x, t.y, swengv_sw_ne_straight, fg);
          break;

        case 17:			/* vertical english switch */
          if(t.switched && !editing)
            draw_layout(t.x, t.y, swengv_nw_se_switched, fg);
          else
            draw_layout(t.x, t.y, swengv_nw_se_straight, fg);
          break;

        case 18:
          if(editing) {
            t.direction = trkdir.SW_NE;
            track_draw(t);
            t.direction = trkdir.SW_N;
          } else if(t.switched)
            t.direction = trkdir.SW_N;
          else
            t.direction = trkdir.SW_NE;
          track_draw(t);
          break;

        case 19:
          if(editing) {
            t.direction = trkdir.SW_NE;
            track_draw(t);
            t.direction = trkdir.NE_S;
          } else if(t.switched)
            t.direction = trkdir.NE_S;
          else
            t.direction = trkdir.SW_NE;
          track_draw(t);
          break;

        case 20:
          if(editing) {
            t.direction = trkdir.NW_SE;
            track_draw(t);
            t.direction = trkdir.SE_N;
          } else if(t.switched)
            t.direction = trkdir.SE_N;
          else
            t.direction = trkdir.NW_SE;
          track_draw(t);
          break;

        case 21:
          if(editing) {
            t.direction = trkdir.NW_SE;
            track_draw(t);
            t.direction = trkdir.NW_S;
          } else if(t.switched)
            t.direction = trkdir.NW_S;
          else
            t.direction = trkdir.NW_SE;
          track_draw(t);
          break;

        case 22:
          if(editing) {
            t.direction = trkdir.NW_S;
            track_draw(t);
            t.direction = trkdir.NE_S;
          } else if(t.switched)
            t.direction = trkdir.NW_S;
          else
            t.direction = trkdir.NE_S;
          track_draw(t);
          break;

        case 23:
          if(editing) {
            t.direction = trkdir.SW_N;
            track_draw(t);
            t.direction = trkdir.SE_N;
          } else if(t.switched)
            t.direction = trkdir.SW_N;
          else
            t.direction = trkdir.SE_N;
          track_draw(t);
          break;
      }
      if(!t.norect)
        draw_layout(t.x, t.y, switch_rect, curSkin.outline); //fieldcolors[TRACK]);
      t.direction = (trkdir)tmp;
    }

    static int DEBUG_Counter1 = 0;

    // TODO Uncomment this function
    public static void track_paint(Track t) {
      tr_fillrect(t.x, t.y);
      if(!editing && t.invisible)
        return;

      switch(t.TrackType) {
        case trktype.TRACK:
          track_draw(t);
          break;

        case trktype.SWITCH:
          switch_draw(t);
          break;

        case trktype.PLATFORM:
          platform_draw(t);
          break;

        case trktype.TSIGNAL:
          signal_draw(t);
          break;

        case trktype.TRAIN:		/* trains are handled differently */
          /*	train_draw(t); */
          break;

        case trktype.TEXT:
          text_draw(t);
          break;

        case trktype.LINK:
          throw new NotImplementedException();
          link_draw(t);
          break;

        case trktype.IMAGE:
          image_draw(t);
          break;

        case trktype.MACRO:
          throw new NotImplementedException();
          // macro_draw(t);
          break;

        case trktype.ITIN:
          itin_draw(t);
          break;

        case trktype.TRIGGER:
          trigger_draw(t);
          break;

        case trktype.NOTRACK:
          break;

        default:
          throw new NotImplementedException();
          return;
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
      if(bShowCoord)
        coord_paint(null);
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
      col = curSkin.background;
      // col = System.Drawing.Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
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

    public static Color getcolor_rgb(int col) {
      return Color.FromArgb(
        colortable[col][0],
        colortable[col][1],
        colortable[col][2]
      );
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

      Size size = new Size(Configuration.XMAX * 2, Configuration.YMAX * 2);

      g = new grid(parent, size.Width, size.Height);
      g.m_hmult = Configuration.HGRID;
      g.m_vmult = Configuration.VGRID;

      ((MyCanvas)parent).Size = size;
      ((MyCanvas)parent).Refresh();

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
    public const int NSTATUSBOXES = 5;

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
