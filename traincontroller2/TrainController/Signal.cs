using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class Signal : Track {
    public void OnFlash() {
      throw new NotImplementedException();

      //  SignalAspect* asp;

      //  if(!_interpreterData)
      //    return;
      //  if(!_currentState)
      //    return;

      //  SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      //  String* p;

      //  for(asp = interp._aspects; asp; asp = asp._next)
      //    if(!wxStrcmp(_currentState, asp._name)) {
      //      int nxt = _nextFlashingIcon + 1;

      //      if(nxt >= MAX_FLASHING_ICONS)
      //        nxt = 0;
      //      p = 0;
      //      switch(this.direction) {
      //        case W_E:
      //          p = asp._iconE;
      //          break;

      //        case E_W:
      //          p = asp._iconW;
      //          break;

      //        case N_S:
      //          p = asp._iconS;
      //          break;

      //        case S_N:
      //          p = asp._iconN;
      //          break;
      //      }
      //      if(!p || !p[nxt])
      //        nxt = 0;
      //      _nextFlashingIcon = nxt;
      //      change_coord(this.x, this.y);
      //      break;
      //    }
    }


    public void Draw() {
      grcolor color = Globals.color_red;
      int i;
      wx.Image p = null;
      Signal t = this;

      i = 0;					/* RR */
      if(t._interpreterData == null || (p = FindIcon()) == null) {
        if(t.fleeted) {
          if(t.status == trkstat.ST_GREEN) {
            if(t.nowfleeted)
              i = 2;			/* GG */
            else
              i = 1;			/* GR */
          } else if(t.nowfleeted)
            i = 3;				/* RO */
          switch(t.direction) {
            case trkdir.W_E:
              p = Globals.signal_traditional ?
            (t.signalx ? e_sig2x_pmap[i] : e_sig2_pmap[i]) : e_sigP_pmap[i];
              break;
            case trkdir.E_W:
              p = Globals.signal_traditional ?
            (t.signalx ? w_sig2x_pmap[i] : w_sig2_pmap[i]) : w_sigP_pmap[i];
              break;
            case trkdir.N_S:
              p = t.signalx ? s_sig2x_pmap[i] : s_sig2_pmap[i];
              break;
            case trkdir.S_N:
              p = t.signalx ? n_sig2x_pmap[i] : n_sig2_pmap[i];
              break;
          }
          if(p != null)
            Globals.draw_pixmap(t.x, t.y, p);
          if(Globals.editing && Globals.show_links && t.controls != null)
            Globals.draw_link(t.x, t.y, t.controls.x, t.controls.y, Globals.conf.linkcolor);
          return;
        }
        if(t.status == trkstat.ST_GREEN)
          i = 1;
        switch(t.direction) {
          case trkdir.W_E:
            p = t.signalx ? e_sigx_pmap[i] : e_sig_pmap[i];
            break;
          case trkdir.E_W:
            p = t.signalx ? w_sigx_pmap[i] : w_sig_pmap[i];
            break;
          case trkdir.N_S:
            p = t.signalx ? s_sigx_pmap[i] : s_sig_pmap[i];
            break;
          case trkdir.S_N:
            p = t.signalx ? n_sigx_pmap[i] : n_sig_pmap[i];
            break;
        }
      }
      if(p != null)
        Globals.draw_pixmap(t.x, t.y, p);
      if(Globals.editing && Globals.show_links && t.controls != null)
        Globals.draw_link(t.x, t.y, t.controls.x, t.controls.y, Globals.conf.linkcolor);
    }

    private wx.Image FindIcon() {
      throw new NotImplementedException();
      //SignalInterpreterData interp = (SignalInterpreterData)_interpreterData;
      //SignalAspect	asp = interp._aspects;
      //wx.Image[] p;
      //int		ix;
      //String curState;

      //if(!String1.IsNullOrWhiteSpaces(this._currentState))
      //    curState = this._currentState;
      //else if(this.status == trkstat.ST_GREEN)
      //    curState = wxPorting.T("green");
      //else
      //  curState = wxPorting.T("red");

      //if(String1.IsNullOrWhiteSpaces(curState))
      //  return null;

      //while(asp != null) {
      //  if(curState.Equals(asp._name, StringComparison.InvariantCultureIgnoreCase))
      //    break;

      //  asp = asp._next;
      //}
      //if(asp == null)
      //  return null;

      //switch(this.direction) {
      //case trkdir.W_E:
      //  p = asp._iconE;
      //  break;

      //case trkdir.E_W:
      //  p = asp._iconW;
      //  break;

      //case trkdir.N_S:
      //  p = asp._iconS;
      //  break;

      //case trkdir.S_N:
      //  p = asp._iconN;
      //  break;
      //}
      //if(p == null || p[0] == null)
      //  return null;

      //if(_isFlashing) {
      //  if(p[_nextFlashingIcon] == null)
      //  _nextFlashingIcon = 0;
      //    p = &p[_nextFlashingIcon];
      //}
      //if((ix = Globals.get_pixmap_index(*p)) < 0)
      //    return 0;
      //return pixmaps[ix].pixels;
    }


    // TODO Implement this function
    public static void InitPixmaps() {
      string bufffg;
      string buff;
      byte fgr, fgg, fgb;
      byte r, g, b;
      String green_name = "G      c #0000d8000000";

      Globals.getcolor_rgb(Globals.fieldcolors[(int)fieldcolor.COL_TRACK], out fgr, out fgg, out fgb);
      Globals.getcolor_rgb(Globals.fieldcolors[(int)fieldcolor.COL_BACKGROUND], out r, out g, out b);

      bufffg = string.Format(".      c #{0:x2}00{1:x2}00{2:x2}00", fgr, fgg, fgb);
      buff = string.Format("       c #{0:x2}00{1:x2}00{2:x2}00", r, g, b);
      buff = string.Format("       c lightgray", r, g, b);
      
      n_sig_xpm[1] = s_sig_xpm[1] = e_sig_xpm[1] = w_sig_xpm[1] =
        n_sigx_xpm[1] = s_sigx_xpm[1] = e_sigx_xpm[1] = w_sigx_xpm[1] =
        buff;

      n_sig_xpm[2] = s_sig_xpm[2] = e_sig_xpm[2] = w_sig_xpm[2] =
        n_sigx_xpm[2] = s_sigx_xpm[2] = e_sigx_xpm[2] = w_sigx_xpm[2] =
        bufffg;

      n_sig_xpm[3] = s_sig_xpm[3] = e_sig_xpm[3] = w_sig_xpm[3] =
        n_sigx_xpm[3] = s_sigx_xpm[3] = e_sigx_xpm[3] = w_sigx_xpm[3] =
        "G      c red";

      n_sig_pmap[0] = Globals.get_pixmap(n_sig_xpm);
      s_sig_pmap[0] = Globals.get_pixmap(s_sig_xpm);
      e_sig_pmap[0] = Globals.get_pixmap(e_sig_xpm);
      w_sig_pmap[0] = Globals.get_pixmap(w_sig_xpm);
      n_sigx_pmap[0] = Globals.get_pixmap(n_sigx_xpm);
      s_sigx_pmap[0] = Globals.get_pixmap(s_sigx_xpm);
      e_sigx_pmap[0] = Globals.get_pixmap(e_sigx_xpm);
      w_sigx_pmap[0] = Globals.get_pixmap(w_sigx_xpm);

      n_sig_xpm[3] = s_sig_xpm[3] = e_sig_xpm[3] = w_sig_xpm[3] =
n_sigx_xpm[3] = s_sigx_xpm[3] = e_sigx_xpm[3] = w_sigx_xpm[3] = green_name;
      n_sig_pmap[1] = Globals.get_pixmap(n_sig_xpm);
      s_sig_pmap[1] = Globals.get_pixmap(s_sig_xpm);
      e_sig_pmap[1] = Globals.get_pixmap(e_sig_xpm);
      w_sig_pmap[1] = Globals.get_pixmap(w_sig_xpm);
      n_sigx_pmap[1] = Globals.get_pixmap(n_sigx_xpm);
      s_sigx_pmap[1] = Globals.get_pixmap(s_sigx_xpm);
      e_sigx_pmap[1] = Globals.get_pixmap(e_sigx_xpm);
      w_sigx_pmap[1] = Globals.get_pixmap(w_sigx_xpm);

      e_sig2_xpm[1] = w_sig2_xpm[1] =
        n_sig2_xpm[1] = s_sig2_xpm[1] =
        e_sig2x_xpm[1] = w_sig2x_xpm[1] =
        n_sig2x_xpm[1] = s_sig2x_xpm[1] =
e_sigP_xpm[1] = w_sigP_xpm[1] = buff;
      e_sig2_xpm[2] = w_sig2_xpm[2] =
        n_sig2_xpm[2] = s_sig2_xpm[2] =
        e_sig2x_xpm[2] = w_sig2x_xpm[2] =
        n_sig2x_xpm[2] = s_sig2x_xpm[2] =
e_sigP_xpm[2] = w_sigP_xpm[2] = bufffg;
      e_sig2_xpm[3] = w_sig2_xpm[3] =
        n_sig2_xpm[3] = s_sig2_xpm[3] =
        e_sig2x_xpm[3] = w_sig2x_xpm[3] =
        n_sig2x_xpm[3] = s_sig2x_xpm[3] =
e_sigP_xpm[3] = w_sigP_xpm[3] = "G      c red";
      e_sig2_xpm[4] = w_sig2_xpm[4] =
        n_sig2_xpm[4] = s_sig2_xpm[4] =
        e_sig2x_xpm[4] = w_sig2x_xpm[4] =
        n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c red";
      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c gray";
      e_sig2_pmap[0] = Globals.get_pixmap(e_sig2_xpm);
      w_sig2_pmap[0] = Globals.get_pixmap(w_sig2_xpm);
      e_sigP_pmap[0] = Globals.get_pixmap(e_sigP_xpm);
      w_sigP_pmap[0] = Globals.get_pixmap(w_sigP_xpm);
      n_sig2_pmap[0] = Globals.get_pixmap(n_sig2_xpm);
      s_sig2_pmap[0] = Globals.get_pixmap(s_sig2_xpm);
      e_sig2x_pmap[0] = Globals.get_pixmap(e_sig2x_xpm);
      w_sig2x_pmap[0] = Globals.get_pixmap(w_sig2x_xpm);
      n_sig2x_pmap[0] = Globals.get_pixmap(n_sig2x_xpm);
      s_sig2x_pmap[0] = Globals.get_pixmap(s_sig2x_xpm);

      e_sig2_xpm[3] = w_sig2_xpm[3] =
      n_sig2_xpm[3] = s_sig2_xpm[3] =
      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
      n_sig2x_xpm[3] = s_sig2x_xpm[3] = green_name;
      e_sigP_xpm[3] = w_sigP_xpm[3] = green_name;
      e_sig2_xpm[4] = w_sig2_xpm[4] =
      n_sig2_xpm[4] = s_sig2_xpm[4] =
      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c red";
      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c gray";
      e_sig2_pmap[1] = Globals.get_pixmap(e_sig2_xpm);
      w_sig2_pmap[1] = Globals.get_pixmap(w_sig2_xpm);
      e_sigP_pmap[1] = Globals.get_pixmap(e_sigP_xpm);
      w_sigP_pmap[1] = Globals.get_pixmap(w_sigP_xpm);
      n_sig2_pmap[1] = Globals.get_pixmap(n_sig2_xpm);
      s_sig2_pmap[1] = Globals.get_pixmap(s_sig2_xpm);
      e_sig2x_pmap[1] = Globals.get_pixmap(e_sig2x_xpm);
      w_sig2x_pmap[1] = Globals.get_pixmap(w_sig2x_xpm);
      n_sig2x_pmap[1] = Globals.get_pixmap(n_sig2x_xpm);
      s_sig2x_pmap[1] = Globals.get_pixmap(s_sig2x_xpm);

      e_sig2_xpm[3] = w_sig2_xpm[3] =
      n_sig2_xpm[3] = s_sig2_xpm[3] =
      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
      n_sig2x_xpm[3] = s_sig2x_xpm[3] = green_name;
      e_sig2_xpm[4] = w_sig2_xpm[4] =
      n_sig2_xpm[4] = s_sig2_xpm[4] =
      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c #0000d8000000";
      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c white";
      e_sig2_pmap[2] = Globals.get_pixmap(e_sig2_xpm);
      w_sig2_pmap[2] = Globals.get_pixmap(w_sig2_xpm);
      e_sigP_pmap[2] = Globals.get_pixmap(e_sigP_xpm);
      w_sigP_pmap[2] = Globals.get_pixmap(w_sigP_xpm);
      n_sig2_pmap[2] = Globals.get_pixmap(n_sig2_xpm);
      s_sig2_pmap[2] = Globals.get_pixmap(s_sig2_xpm);
      e_sig2x_pmap[2] = Globals.get_pixmap(e_sig2x_xpm);
      w_sig2x_pmap[2] = Globals.get_pixmap(w_sig2x_xpm);
      n_sig2x_pmap[2] = Globals.get_pixmap(n_sig2x_xpm);
      s_sig2x_pmap[2] = Globals.get_pixmap(s_sig2x_xpm);

      e_sig2_xpm[3] = w_sig2_xpm[3] =
      n_sig2_xpm[3] = s_sig2_xpm[3] =
      e_sig2x_xpm[3] = w_sig2x_xpm[3] =
      n_sig2x_xpm[3] = s_sig2x_xpm[3] = "G      c red";
      e_sigP_xpm[3] = w_sigP_xpm[3] = "G      c red";
      e_sig2_xpm[4] = w_sig2_xpm[4] =
      n_sig2_xpm[4] = s_sig2_xpm[4] =
      e_sig2x_xpm[4] = w_sig2x_xpm[4] =
      n_sig2x_xpm[4] = s_sig2x_xpm[4] = "X      c orange";
      e_sigP_xpm[4] = w_sigP_xpm[4] = "X      c white";
      e_sig2_pmap[3] = Globals.get_pixmap(e_sig2_xpm);
      w_sig2_pmap[3] = Globals.get_pixmap(w_sig2_xpm);
      e_sigP_pmap[3] = Globals.get_pixmap(e_sigP_xpm);
      w_sigP_pmap[3] = Globals.get_pixmap(w_sigP_xpm);
      /*n_sig2_pmap[3] = Globals.get_pixmap(n_sig2_xpm);
      s_sig2_pmap[3] = Globals.get_pixmap(s_sig2_xpm);*/
      e_sig2x_pmap[3] = Globals.get_pixmap(e_sig2x_xpm);
      w_sig2x_pmap[3] = Globals.get_pixmap(w_sig2x_xpm);
    }

    //}

    //public partial class Globals {
    public static wx.Image[] e_sig2_pmap = new wx.Image[4];		/* RR, GR, GG, GO */
    public static wx.Image[] e_sig2x_pmap = new wx.Image[4];
    public static String[] e_sig2_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	".   ...  ... ",
	".  .XXX..GGG.",
	"....XXX..GGG.",
	".  .XXX..GGG.",
	".   ...  ... "};
    public static String[] e_sig2x_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	".  ..........",
	".  .XXX..GGG.",
	"....XXX..GGG.",
	".  .XXX..GGG.",
	".  .........."};

    public static wx.Image[] e_sigP_pmap = new wx.Image[4];		/* RR, GR, GG, GO */
    public static String[] e_sigP_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
        ". ...... ... ",
        ". XXXXX..GGG.",
        "....X.X..GGG.",
        ". ..XXX..GGG.",
        ". ...... ... "};
    public static wx.Image[] w_sig2_pmap = new wx.Image[4];		/* RR, GR, GG, GO */
    public static wx.Image[] w_sig2x_pmap = new wx.Image[4];
    public static String[] w_sig2_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	" ...  ...   .",
	".GGG..XXX.  .",
	".GGG..XXX....",
	".GGG..XXX.  .",
	" ...  ...   ."};
    public static wx.Image[] w_sigP_pmap = new wx.Image[4];		/* RR, GR, GG, GO */
    public static String[] w_sigP_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	" ... ...... .",
	".GGG..XXX.. .",
	".GGG..X.X....",
	".GGG..XXXXX .",
	" ... ...... ."};
    public static wx.Image[] s_sig2_pmap = new wx.Image[4];         /* R, G */
    public static wx.Image[] s_sig2x_pmap = new wx.Image[4];         /* R, G */
    public static String[] s_sig2_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
"   .   ",
"   .   ",
"  ...  ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
"  ...  ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  "};
    public static wx.Image[] n_sig2_pmap = new wx.Image[4];         /* R, G */
    public static wx.Image[] n_sig2x_pmap = new wx.Image[4];
    public static String[] n_sig2_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  ",
"  ...  ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
"  ...  ",
"   .   ",
"   .   ",
" ..... "};
    public static wx.Image[] e_sig_pmap = new wx.Image[2];		/* R, G */
    public static wx.Image[] e_sigx_pmap = new wx.Image[2];
    public static String[] e_sig_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".    ... ",
".   .GGG.",
".....GGG.",
".   .GGG.",
".    ... "};
    public static wx.Image[] w_sig_pmap = new wx.Image[2];		/* R, G */
    public static wx.Image[] w_sigx_pmap = new wx.Image[2];
    public static String[] w_sig_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
" ...    .",
".GGG.   .",
".GGG.....",
".GGG.   .",
" ...    ."
};
    public static wx.Image[] s_sig_pmap = new wx.Image[2];         /* R, G */
    public static wx.Image[] s_sigx_pmap = new wx.Image[2];
    public static String[] s_sig_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
"   .   ",
"   .   ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  "};
    public static wx.Image[] n_sig_pmap = new wx.Image[2];         /* R, G */
    public static wx.Image[] n_sigx_pmap = new wx.Image[2];
    public static String[] n_sig_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
"  ...  ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
"  ...  ",
"   .   ",
"   .   ",
" ..... "};
    public static String[] e_sigx_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".   .....",
".   .GGG.",
".....GGG.",
".   .GGG.",
".   ....."};
    public static String[] n_sigx_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... ",
"   .   ",
"   .   ",
" ..... "};

    public static String[] w_sig2x_xpm = new String[] {
	"13 7 4 1",
	"       c #FFFFFFFFFFFF",
	".      c #000000000000",
	null, /*"G      c #0000FFFFFFFF",*/
	null, /*"X      c #0000FFFFFFFF",*/
	"             ",
	"             ",
	"..........  .",
	".GGG..XXX.  .",
	".GGG..XXX....",
	".GGG..XXX.  .",
	"..........  ."};
    public static String[] s_sig2x_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
"   .   ",
"   .   ",
" ..... ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
" ..... ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... "};

    public static String[] n_sig2x_xpm = new String[] {
"7 13 4 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"G      c #0000FFFFFFFF",*/
null, /*"X      c #0000FFFFFFFF",*/
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... ",
" ..... ",
" .XXX. ",
" .XXX. ",
" .XXX. ",
" ..... ",
"   .   ",
"   .   ",
" ..... "};

    public static String[] w_sigx_xpm = new String[] {
"9 7 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"         ",
"         ",
".....   .",
".GGG.   .",
".GGG.....",
".GGG.   .",
".....   ."
};

    public static String[] s_sigx_xpm = new String[] {
"7 9 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"       ",
" ..... ",
"   .   ",
"   .   ",
" ..... ",
" .GGG. ",
" .GGG. ",
" .GGG. ",
" ..... "};

  }

}