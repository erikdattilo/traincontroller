using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  // ERIK - Start of original file

  //#define OLD		    /* old way of drawing tracks */

  static partial class GlobalVariables {
    public static int terse_status;
    public static grcolor[] fieldcolors = new grcolor[(int)fieldcolor.MAXFIELDCOL];
    public static bool draw_train_names = false;
    public static bool show_links = false;
    public static bool show_scripts = false;
    public static Coord move_start, move_end;

    public static VLines[] n_s_layout = new VLines[] {
	    new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1),
	    new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),
	    new VLines(-1)
    };
    public static SegDir[] n_s_segs = new SegDir[] { SegDir.SEG_N, SegDir.SEG_S, SegDir.SEG_END };
    public static SegDir[] sw_n_segs = new SegDir[] { SegDir.SEG_SW, SegDir.SEG_N, SegDir.SEG_END };
    public static SegDir[] nw_s_segs = new SegDir[] { SegDir.SEG_NW, SegDir.SEG_S, SegDir.SEG_END };
    public static SegDir[] w_e_segs = new SegDir[] { SegDir.SEG_W, SegDir.SEG_E, SegDir.SEG_END };
    public static SegDir[] nw_e_segs = new SegDir[] { SegDir.SEG_NW, SegDir.SEG_E, SegDir.SEG_END };
    public static SegDir[] sw_e_segs = new SegDir[] { SegDir.SEG_SW, SegDir.SEG_E, SegDir.SEG_END };
    public static SegDir[] w_ne_segs = new SegDir[] { SegDir.SEG_W, SegDir.SEG_NE, SegDir.SEG_END };
    public static SegDir[] w_se_segs = new SegDir[] { SegDir.SEG_W, SegDir.SEG_SE, SegDir.SEG_END };
    public static SegDir[] nw_se_segs = new SegDir[] { SegDir.SEG_NW, SegDir.SEG_SE, SegDir.SEG_END };
    public static SegDir[] sw_ne_segs = new SegDir[] { SegDir.SEG_SW, SegDir.SEG_NE, SegDir.SEG_END };
    public static SegDir[] ne_s_segs = new SegDir[] { SegDir.SEG_NE, SegDir.SEG_S, SegDir.SEG_END };
    public static SegDir[] se_n_segs = new SegDir[] { SegDir.SEG_SE, SegDir.SEG_N, SegDir.SEG_END };
    public static SegDir[] itin_segs = new SegDir[] { SegDir.SEG_NW, SegDir.SEG_SW, SegDir.SEG_NE, SegDir.SEG_SE, SegDir.SEG_W, SegDir.SEG_E, SegDir.SEG_END };

    public static VLines[] sw_n_layout = new VLines[] {
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2, 0, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 1, 0, Configuration.VGRID - 2),
	new VLines(-1)
};

    public static VLines[] nw_s_layout = new VLines[] {
	new VLines(1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2),
	new VLines(0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2),
	new VLines(0, 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] se_n_layout = new VLines[] {
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] ne_s_layout = new VLines[] {
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, 0),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2, Configuration.HGRID - 1, 0),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2, Configuration.HGRID - 1, 1),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] w_e_layout = new VLines[] {
	/*{ 0, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1),*/
	new VLines(0, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(-1)
};

    public static VLines[] nw_e_layout = new VLines[] {
	new VLines(1, 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 1),
	new VLines(0, 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0),
	new VLines(0, 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1),
	/*{ Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1),*/
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(-1)
};

    public static VLines[] sw_e_layout = new VLines[] {
	new VLines(0, Configuration.VGRID - 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 /*- 1*/),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0),
	new VLines(1, Configuration.VGRID - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1),
	/*{ Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 - 1),*/
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(-1)
};

    public static VLines[] w_ne_layout = new VLines[] {
	/*{ 0, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 - 1),*/
	new VLines(0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, 0),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, 0),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, 1),
	new VLines(-1)
};

    public static VLines[] w_se_layout = new VLines[] {
	/*{ 0, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2 - 0, Configuration.VGRID / 2 - 1),*/
	new VLines(0, Configuration.VGRID / 2 - 0, Configuration.HGRID / 2, Configuration.VGRID / 2 - 0),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 1),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 /*- 1*/, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] sweng_sw_ne_straight = new VLines[] {
	new VLines(0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0),
	new VLines(1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1),

	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 + 1),

	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0),
	new VLines(-1)
};

    public static VLines[] sweng_sw_ne_switched = new VLines[] {

	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID - 2, 0),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, 0),

	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2),
	new VLines(1, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(-1)
};

    public static VLines[] sweng_nw_se_straight = new VLines[] {
	new VLines(1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1),

	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2),
	new VLines(0, Configuration.VGRID / 2 + 1, Configuration.HGRID / 2 - 1, Configuration.VGRID / 2 + 1),

	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 1, Configuration.VGRID / 2 - 0),
	new VLines(-1)
};

    public static VLines[] sweng_nw_se_switched = new VLines[] {

	new VLines(0, 0, Configuration.HGRID - 1, Configuration.VGRID / 2),
	new VLines(0, 1, Configuration.HGRID - 1, Configuration.VGRID / 2 + 1),

	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] swengv_sw_ne_straight = new VLines[] {
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),

	new VLines(0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0),
	new VLines(1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1),

	new VLines(-1)
};

    public static VLines[] swengv_sw_ne_switched = new VLines[] {

	new VLines(0, Configuration.VGRID - 2, Configuration.HGRID / 2 - 0, 0),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID / 2 + 1, 0),

	new VLines(Configuration.HGRID / 2 - 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0),
	new VLines(Configuration.HGRID / 2 + 1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1),
	new VLines(-1)
};

    public static VLines[] swengv_nw_se_straight = new VLines[] {
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),

	new VLines(1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1),

	new VLines(-1)
};

    public static VLines[] swengv_nw_se_switched = new VLines[] {

	new VLines(0, 0, Configuration.HGRID / 2 - 1, Configuration.VGRID - 1),
	new VLines(0, 1, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1),

	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(-1)
};


    public static VLines[] block_layout = new VLines[] {
	new VLines(Configuration.HGRID / 2, Configuration.VGRID / 2 - 1, Configuration.HGRID / 2, Configuration.VGRID / 2 + 2),
	new VLines(-1)
};

    public static VLines[] block_layout_ns = new VLines[] {
	new VLines(Configuration.HGRID / 2 - 1, Configuration.VGRID / 2, Configuration.HGRID / 2 + 2, Configuration.VGRID / 2),
	new VLines(-1)
};

    public static VLines[] station_block_layout = new VLines[] {
	new VLines(Configuration.HGRID / 2, 0, 0, Configuration.VGRID / 2),
	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID / 2, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID / 2),
	new VLines(Configuration.HGRID / 2, 0, Configuration.HGRID - 1, Configuration.VGRID / 2),
	new VLines(-1)
};

    public static VLines[] nw_se_layout = new VLines[] {
	new VLines(1, 0, Configuration.HGRID - 1, Configuration.VGRID - 2),
	new VLines(0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(0, 1, Configuration.HGRID - 2, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] sw_ne_layout = new VLines[] {
	new VLines(0, Configuration.VGRID - 2, Configuration.HGRID - 2, 0),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0),
	new VLines(1, Configuration.VGRID - 1, Configuration.HGRID - 1, 1),
	new VLines(-1)
};

    public static VLines[] switch_rect = new VLines[] {
	new VLines(0, 0, Configuration.HGRID - 1, 0),
	new VLines(Configuration.HGRID - 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(0, 0, 0, Configuration.VGRID - 1),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] w_e_platform_out = new VLines[] {
	new VLines(0, Configuration.VGRID / 2 - 3, Configuration.HGRID - 1, Configuration.VGRID / 2 - 3),
	new VLines(0, Configuration.VGRID / 2 + 3, Configuration.HGRID - 1, Configuration.VGRID / 2 + 3),
	new VLines(0, Configuration.VGRID / 2 - 3, 0, Configuration.VGRID / 2 + 3),
	new VLines(Configuration.HGRID - 1, Configuration.VGRID / 2 - 3, Configuration.HGRID - 1, Configuration.VGRID / 2 + 3),
	new VLines(-1)
};

    public static VLines[] w_e_platform_in = new VLines[] {
	new VLines(1, Configuration.VGRID / 2 - 2, Configuration.HGRID - 2, Configuration.VGRID / 2 - 2),
	new VLines(1, Configuration.VGRID / 2 - 1, Configuration.HGRID - 2, Configuration.VGRID / 2 - 1),
	new VLines(1, Configuration.VGRID / 2 - 0, Configuration.HGRID - 2, Configuration.VGRID / 2 - 0),
	new VLines(1, Configuration.VGRID / 2 + 1, Configuration.HGRID - 2, Configuration.VGRID / 2 + 1),
	new VLines(1, Configuration.VGRID / 2 + 2, Configuration.HGRID - 2, Configuration.VGRID / 2 + 2),
	new VLines(-1)
};

    public static VLines[] n_s_platform_out = new VLines[] {
	new VLines(Configuration.HGRID / 2 - 3, 0, Configuration.HGRID / 2 - 3, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 + 3, 0, Configuration.HGRID / 2 + 3, Configuration.VGRID - 1),
	new VLines(Configuration.HGRID / 2 - 3, 0, Configuration.HGRID / 2 + 3, 0),
	new VLines(Configuration.HGRID / 2 - 3, Configuration.VGRID - 1, Configuration.HGRID / 2 + 3, Configuration.VGRID - 1),
	new VLines(-1)
};

    public static VLines[] n_s_platform_in = new VLines[] {
	new VLines(Configuration.HGRID / 2 - 2, 1, Configuration.HGRID / 2 - 2, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 - 1, 1, Configuration.HGRID / 2 - 1, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 - 0, 1, Configuration.HGRID / 2 - 0, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 + 1, 1, Configuration.HGRID / 2 + 1, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2 + 2, 1, Configuration.HGRID / 2 + 2, Configuration.VGRID - 2),
	new VLines(-1)
};

    public static VLines[] itin_layout = new VLines[] {
	new VLines(0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1),
	new VLines(0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID / 2),
	new VLines(0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0),
	new VLines(-1)
};

    public static VLines[] etrigger_layout = new VLines[] {
	new VLines(1, 2, Configuration.HGRID - 2, 2),
	new VLines(1, 2, Configuration.HGRID / 2, Configuration.VGRID - 2),
	new VLines(Configuration.HGRID / 2, Configuration.VGRID - 2, Configuration.HGRID - 2, 2),
	new VLines(-1)
};

    public static VLines[] wtrigger_layout = new VLines[] {
	new VLines(1, Configuration.VGRID - 2, Configuration.HGRID - 2, Configuration.VGRID - 2),
	new VLines(1, Configuration.VGRID - 2, Configuration.HGRID / 2, 2),
	new VLines(Configuration.HGRID / 2, 2, Configuration.HGRID - 2, Configuration.VGRID - 2),
	new VLines(-1)
};

    public static VLines[] ntrigger_layout = new VLines[] {
	new VLines(2, 1, 2, Configuration.VGRID - 2),
	new VLines(2, 1, Configuration.HGRID - 2, Configuration.VGRID / 2),
	new VLines(2, Configuration.VGRID - 2, Configuration.HGRID - 2, Configuration.VGRID / 2),
	new VLines(-1)
};

    public static VLines[] strigger_layout = new VLines[] {
	new VLines(Configuration.HGRID - 2, 1, Configuration.HGRID - 2, Configuration.VGRID - 2),
	new VLines(2, Configuration.VGRID / 2, Configuration.HGRID - 2, 1),
	new VLines(2, Configuration.VGRID / 2, Configuration.HGRID - 2, Configuration.VGRID - 2),
	new VLines(-1)
};

    public static Image[] e_train_pmap_default = new Image[Configuration.NTTYPES];
    public static Image[] w_train_pmap_default = new Image[Configuration.NTTYPES];
    public static Image[] e_car_pmap_default = new Image[Configuration.NTTYPES];
    public static Image[] w_car_pmap_default = new Image[Configuration.NTTYPES];

    public static Image[] e_train_pmap = new Image[Configuration.NTTYPES];
    public static string[] e_train_xpm = new string[] {
"13 10 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"             ",
"...........  ",
".XXXXXXXXX.. ",
".X..X..X..X..",
".XXXXXXXXXXX.",
".XXXXXXXXXXX.",
".............",
"  ...   ...  ",
"             ",
"             "};

    public static Image[] w_train_pmap = new Image[Configuration.NTTYPES];
    public static string[] w_train_xpm = new string[] {
"13 10 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"             ",
"  ...........",
" ..XXXXXXXXX.",
"..X.X..X..XX.",
".XXXXXXXXXXX.",
".XXXXXXXXXXX.",
".............",
"  ...   ...  ",
"             ",
"             "};

    public static Image[] w_car_pmap = new Image[Configuration.NTTYPES];
    public static Image[] e_car_pmap = new Image[Configuration.NTTYPES];
    public static string[] car_xpm = new string[] {	/* same for both e and w */
"13 10 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
null, /*"X      c #0000FFFFFFFF",*/
"             ",
"............ ",
".XXXXXXXXXX. ",
".X..X..X..X. ",
".XXXXXXXXXX. ",
"XXXXXXXXXXXX ",
"............ ",
" ...    ...  ",
"             ",
"             "};

    public static Image[] speed_pmap;
    public static string[] speed_xpm = new string[] {
"8 3 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
"X      c #000000000000",
"  ....  ",
" ..  .. ",
"  ....  "};

    public static Image camera_pmap;
    public static string[] camera_xpm = new string[] {
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

    public static Image itin_pmap;
    public static string[] itin_xpm = new string[] {
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
  }

  static partial class GlobalVariables {
    public static string[] ttypecolors = new string[] {
	"orange", "cyan", "blue", "yellow",
	"white", "red", "brown", "green",
        "magenta", "lightgray"
};
    ///*
    // *	Tools-types pixmaps
    // *	(created from xpms defined in the i*.h files)
    // */
    public static Image tracks_pixmap, switches_pixmap, signals_pixmap,
    tools_pixmap, actions_pixmap,
    move_start_pixmap, move_end_pixmap, move_dest_pixmap,
                set_power_pixmap;


    public static string buff = "";
  }

  static partial class GlobalFunctions {

    public static void init_pmaps() {
      int r, g, b;
      int fgr, fgg, fgb;
      int i;
      string bufffg;
      string buffcol = "";

      GlobalFunctions.getcolor_rgb(GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRACK], out fgr, out fgg, out fgb);
      bufffg = string.Format(".      c #{0:x2}00{0:x2}00{0:x2}00", fgr, fgg, fgb);
      GlobalFunctions.getcolor_rgb(GlobalVariables.fieldcolors[(int)fieldcolor.COL_BACKGROUND], out r, out g, out b);
      bufffg = string.Format("       c #{0:x2}00{0:x2}00{0:x2}00", r, g, b);
      bufffg = string.Format("       c lightgray", r, g, b);

      GlobalVariables.e_train_xpm[1] = GlobalVariables.w_train_xpm[1] = GlobalVariables.car_xpm[1] = GlobalVariables.buff;
      GlobalVariables.e_train_xpm[2] = GlobalVariables.w_train_xpm[2] = GlobalVariables.car_xpm[2] = bufffg;
      GlobalVariables.e_train_xpm[3] = GlobalVariables.w_train_xpm[3] = GlobalVariables.car_xpm[3] = buffcol;

      for(i = 0; i < Configuration.NTTYPES; ++i) {
        buffcol = String.Format("X      c %s", GlobalVariables.ttypecolors[i]);
        GlobalVariables.e_train_pmap[i] = GlobalFunctions.get_pixmap(GlobalVariables.e_train_xpm);
        GlobalVariables.w_train_pmap[i] = GlobalFunctions.get_pixmap(GlobalVariables.w_train_xpm);
        GlobalVariables.e_car_pmap[i] = GlobalFunctions.get_pixmap(GlobalVariables.car_xpm);
        GlobalVariables.w_car_pmap[i] = GlobalFunctions.get_pixmap(GlobalVariables.car_xpm);
      }

      Signal.InitPixmaps();

      GlobalVariables.buff = string.Format("       c #{0:x2}00{0:x2}00{0:x2}00", r, g, b);
      bufffg = string.Format(".      c #{0:x2}00{0:x2}00{0:x2}00", fgr, fgg, fgb);
      GlobalVariables.speed_xpm[1] = GlobalVariables.buff;
      GlobalVariables.speed_xpm[2] = bufffg;
      GlobalVariables.speed_pmap = new Image[] { GlobalFunctions.get_pixmap(GlobalVariables.speed_xpm) };

      for(r = 0; r < 4; ++r) {
        GlobalVariables.e_train_pmap_default[r] = GlobalVariables.e_train_pmap[r];
        GlobalVariables.w_train_pmap_default[r] = GlobalVariables.w_train_pmap[r];
        GlobalVariables.e_car_pmap_default[r] = GlobalVariables.e_car_pmap[r];
        GlobalVariables.w_car_pmap_default[r] = GlobalVariables.w_car_pmap[r];
      }

      // tools-types pixmaps

      GlobalVariables.tracks_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.tracks_xpm);
      GlobalVariables.switches_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.switches_xpm);
      GlobalVariables.signals_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.signals_xpm);
      GlobalVariables.tools_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.tools_xpm);
      GlobalVariables.actions_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.actions_xpm);
      GlobalVariables.move_start_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.move_start_xpm);
      GlobalVariables.move_end_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.move_end_xpm);
      GlobalVariables.move_dest_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.move_dest_xpm);
      GlobalVariables.set_power_pixmap = GlobalFunctions.get_pixmap(GlobalVariables.set_power_xpm);
    }

    public static Track track_new() {
      Track t;
      t = new Track();
      t.xsize = 1;
      t.ysize = 1;
      t.type = trktype.NOTRACK;
      t.direction = trkdir.NODIR;
      t.fgcolor = GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRACK];
      return (t);
    }

    public static int translate_track_color(Track t) {
      int fg = GlobalVariables.curSkin.free_track;

      switch(t.status) {
        case trkstat.ST_FREE:
          break;
        case trkstat.ST_BUSY:
          return GlobalVariables.curSkin.occupied_track;
        case trkstat.ST_READY:
          return GlobalVariables.curSkin.reserved_track;
        case trkstat.ST_WORK:
          return GlobalVariables.curSkin.working_track;
      }
      if(t.fgcolor == GlobalVariables.color_orange || t.fgcolor == GlobalVariables.color_red)
        return GlobalVariables.curSkin.occupied_track;
      if(t.fgcolor == GlobalVariables.color_green)
        return GlobalVariables.curSkin.reserved_track;
      if(t.fgcolor == GlobalVariables.color_white)
        return GlobalVariables.curSkin.reserved_shunting;
      if(t.fgcolor == GlobalVariables.color_blue)
        return GlobalVariables.curSkin.working_track;
      return fg;
    }

    public static void track_draw(Track t) {
      int fg;
      int tot;
      VLines[] lns = GlobalVariables.n_s_layout;	// provide dummy initialization - always overwritten

      fg = translate_track_color(t);
      switch(t.direction) {
        case trkdir.TRK_N_S:
          if(string.IsNullOrEmpty(t.power) == false) {
            GlobalFunctions.draw_mid_point(t.x, t.y, -2, 0, fg);
          }
          lns = GlobalVariables.n_s_layout;
          break;

        case trkdir.SW_N:
          lns = GlobalVariables.sw_n_layout;
          break;

        case trkdir.NW_S:
          lns = GlobalVariables.nw_s_layout;
          break;

        case trkdir.W_E:
          if(string.IsNullOrEmpty(t.power) == false) {
            GlobalFunctions.draw_mid_point(t.x, t.y, 0, -2, fg);
          }
          lns = GlobalVariables.w_e_layout;
          break;

        case trkdir.NW_E:
          lns = GlobalVariables.nw_e_layout;
          break;

        case trkdir.SW_E:
          lns = GlobalVariables.sw_e_layout;
          break;

        case trkdir.W_NE:
          lns = GlobalVariables.w_ne_layout;
          break;

        case trkdir.W_SE:
          lns = GlobalVariables.w_se_layout;
          break;

        case trkdir.NW_SE:
          if(string.IsNullOrEmpty(t.power) == false) {
            GlobalFunctions.draw_mid_point(t.x, t.y, 2, -2, fg);
          }
          lns = GlobalVariables.nw_se_layout;
          break;

        case trkdir.SW_NE:
          if(string.IsNullOrEmpty(t.power) == false) {
            GlobalFunctions.draw_mid_point(t.x, t.y, -2, -2, fg);
          }
          lns = GlobalVariables.sw_ne_layout;
          break;

        case trkdir.NE_S:
          lns = GlobalVariables.ne_s_layout;
          break;

        case trkdir.SE_N:
          lns = GlobalVariables.se_n_layout;
          break;

        case trkdir.XH_NW_SE:
          fg = (int)t.direction;
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;

        case trkdir.XH_SW_NE:
          fg = (int)t.direction;
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;

        case trkdir.X_X:
          fg = (int)t.direction;
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;

        case trkdir.X_PLUS:
          fg = (int)t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.W_E;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;

        case trkdir.N_NE_S_SW:
          fg = (int)t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.SW_NE;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;

        case trkdir.N_NW_S_SE:
          fg = (int)t.direction;
          t.direction = trkdir.TRK_N_S;
          track_draw(t);
          t.direction = trkdir.NW_SE;
          track_draw(t);
          t.direction = (trkdir)fg;
          return;
      }
      GlobalFunctions.draw_layout(t.x, t.y, lns, fg);
      if(GlobalVariables.show_blocks && t.direction == trkdir.W_E && t.length >= 100)
        GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.block_layout, GlobalVariables.curSkin.outline); //fieldcolors[TRACK]);
      if(GlobalVariables.show_blocks && t.direction == trkdir.TRK_N_S && t.length >= 100)
        GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.block_layout_ns, GlobalVariables.curSkin.outline); //fieldcolors[TRACK]);
      if(GlobalVariables.show_blocks && string.IsNullOrEmpty(t.station) == false)
        GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.station_block_layout, GlobalVariables.curSkin.outline); //fieldcolors[TRACK]);
      if(GlobalVariables.editing && GlobalVariables.show_links) {
        if(t.wlinkx != 0 && t.wlinky != 0)
          GlobalFunctions.draw_link(t.x, t.y, t.wlinkx, t.wlinky, GlobalVariables.conf.linkcolor2);
        if(t.elinkx != 0 && t.elinky != 0)
          GlobalFunctions.draw_link(t.x, t.y, t.elinkx, t.elinky, GlobalVariables.conf.linkcolor2);
      }
      if(!GlobalVariables.show_speeds)
        return;
      tot = 0;
      for(fg = 0; fg < Configuration.NTTYPES; ++fg)
        tot += t.speed[fg];
      if(tot != 0)
        GlobalFunctions.draw_pixmap(t.x, t.y, GlobalVariables.speed_pmap);
    }

    public static void switch_draw(Track t) {
      int fg;
      int tmp;

      fg = translate_track_color(t);
      tmp = (int)t.direction;
      switch(tmp) {
        case 0:
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(t.switched && !GlobalVariables.editing)
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.sweng_sw_ne_switched, fg);
          else
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.sweng_sw_ne_straight, fg);
          break;

        case 9:				/* horizontal english switch */
          if(t.switched && !GlobalVariables.editing)
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.sweng_nw_se_switched, fg);
          else
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.sweng_nw_se_straight, fg);
          break;

        case 10:
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(t.switched && !GlobalVariables.editing)
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.swengv_sw_ne_switched, fg);
          else
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.swengv_sw_ne_straight, fg);
          break;

        case 17:			/* vertical english switch */
          if(t.switched && !GlobalVariables.editing)
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.swengv_nw_se_switched, fg);
          else
            GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.swengv_nw_se_straight, fg);
          break;

        case 18:
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
          if(GlobalVariables.editing) {
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
        GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.switch_rect, GlobalVariables.curSkin.outline); //fieldcolors[TRACK]);
      t.direction = (trkdir)tmp;
    }

    public static void platform_draw(Track t) {
      switch(t.direction) {
        case trkdir.W_E:
          GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.w_e_platform_out, GlobalVariables.curSkin.free_track); //fieldcolors[TRACK]);
          GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.w_e_platform_in, GlobalVariables.curSkin.outline);
          break;

        case trkdir.N_S:
          GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.n_s_platform_out, GlobalVariables.curSkin.free_track);//fieldcolors[TRACK]);
          GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.n_s_platform_in, GlobalVariables.curSkin.outline);
          break;
      }
    }

    public static void signal_draw(Track t) {
      Signal signal = (Signal)t;
      signal.Draw();
    }

    public static object get_train_pixels(Train trn) {
      object pixels;

      if(GlobalVariables.swap_head_tail && (trn.flags & TFLG.TFLG_SWAPHEADTAIL) != 0) {
        if(trn.direction == trkdir.W_E)
          pixels = trn.wpix == -1 ?
                GlobalVariables.w_train_pmap[trn.type] : GlobalVariables.pixmaps[trn.wpix].pixels;
        else
          pixels = trn.epix == -1 ?
                GlobalVariables.e_train_pmap[trn.type] : GlobalVariables.pixmaps[trn.epix].pixels;
      } else {
        if(trn.direction == trkdir.W_E)
          pixels = trn.epix == -1 ?
                GlobalVariables.e_train_pmap[trn.type] : GlobalVariables.pixmaps[trn.epix].pixels;
        else
          pixels = trn.wpix == -1 ?
                GlobalVariables.w_train_pmap[trn.type] : GlobalVariables.pixmaps[trn.wpix].pixels;
      }
      return pixels;
    }

    public static object get_car_pixels(Train trn) {
      object pixels;

      if(GlobalVariables.swap_head_tail && (trn.flags & TFLG.TFLG_SWAPHEADTAIL) != 0) {
        if(trn.direction == trkdir.W_E)
          pixels = trn.wcarpix == -1 || trn.wcarpix >= GlobalVariables.ncarpixmaps ?
                GlobalVariables.w_car_pmap[trn.type] : GlobalVariables.carpixmaps[trn.wcarpix].pixels;
        else
          pixels = trn.ecarpix == -1 || trn.ecarpix >= GlobalVariables.ncarpixmaps ?
                GlobalVariables.e_car_pmap[trn.type] : GlobalVariables.carpixmaps[trn.ecarpix].pixels;
      } else {
        if(trn.direction == trkdir.W_E)
          pixels = trn.ecarpix == -1 || trn.ecarpix >= GlobalVariables.ncarpixmaps ?
                GlobalVariables.e_car_pmap[trn.type] : GlobalVariables.carpixmaps[trn.ecarpix].pixels;
        else
          pixels = trn.wcarpix == -1 || trn.wcarpix >= GlobalVariables.ncarpixmaps ?
                GlobalVariables.w_car_pmap[trn.type] : GlobalVariables.carpixmaps[trn.wcarpix].pixels;
      }
      return pixels;
    }

    public static void train_draw(Track t, Train trn) {
      object pixels;
      string name;

      if(GlobalVariables.e_train_pmap[0] == null || GlobalVariables.e_train_pmap.Length == 0) {
        GlobalFunctions.init_pmaps();
      }
      if(GlobalVariables.draw_train_names) {
        //get_basic_name(trn, name, sizeof(name)/sizeof(name[0]));
        //if(no_train_names_colors)
        //    draw_text_with_background(t.x, t.y, name, 0, color_green);
        //else
        //    draw_text_with_background(t.x, t.y, name, 0, fieldcolors[COL_TRAIN1 + trn.type]);
        //return;
      }
      pixels = get_train_pixels(trn);
      if(GlobalVariables.swap_head_tail && (trn.flags & TFLG.TFLG_SWAPHEADTAIL) != 0 && trn.length != 0 &&
          trn.tail != null && trn.position != null && trn.position != trn.tail.position)
        pixels = get_car_pixels(trn);
      GlobalFunctions.draw_pixmap(t.x, t.y, pixels);
    }

    public static void car_draw(Track t, Train trn) {
      object pixels;
      string name;

      if(GlobalVariables.e_car_pmap[0] == null) {
        GlobalFunctions.init_pmaps();
      }

      if(GlobalVariables.draw_train_names) {
        //get_basic_name(trn, name, sizeof(name)/sizeof(name[0]));
        //if(no_train_names_colors)
        //    draw_text_with_background(t.x, t.y, name, 0, color_green);
        //else
        //    draw_text_with_background(t.x, t.y, name, 0, fieldcolors[COL_TRAIN1 + trn.type]);
        //return;
      }
      pixels = get_car_pixels(trn);
      if(GlobalVariables.swap_head_tail && (trn.flags & TFLG.TFLG_SWAPHEADTAIL) != 0)
        pixels = get_train_pixels(trn);
      GlobalFunctions.draw_pixmap(t.x, t.y, pixels);
    }

    public static void text_draw(Track t) {
      if(string.IsNullOrEmpty(t.station))
        return;
      GlobalFunctions.tr_fillrect(t.x, t.y);
      if(t._fontIndex != 0)
        GlobalFunctions.draw_layout_text_font(t.x, t.y, t.station, t._fontIndex);
      else
        GlobalFunctions.draw_layout_text1(t.x, t.y, t.station, (int)t.direction);
      if(!GlobalVariables.editing || !GlobalVariables.show_links)
        return;
      if(t.elinkx != 0 && t.elinky != 0)
        GlobalFunctions.draw_link(t.x, t.y, t.elinkx, t.elinky, GlobalVariables.conf.linkcolor);
      else if(t.wlinkx != 0 && t.wlinky != 0)
        GlobalFunctions.draw_link(t.x, t.y, t.wlinkx, t.wlinky, GlobalVariables.conf.linkcolor);
    }

    public static void link_draw(Track t) {
      GlobalFunctions.tr_fillrect(t.x, t.y);
      if(t.direction == trkdir.W_E)
        GlobalFunctions.draw_layout_text1(t.x, t.y, wxPorting.T("...to..."), 1);
      else
        GlobalFunctions.draw_layout_text1(t.x, t.y, wxPorting.T("Link..."), 1);
    }

    public static void macro_draw(Track t) {
      GlobalFunctions.tr_fillrect(t.x, t.y);
      if(t.direction == 0)
        GlobalFunctions.draw_layout_text1(t.x, t.y, wxPorting.T("Macro"), 1);
      else
        GlobalFunctions.draw_layout_text1(t.x, t.y, wxPorting.T("Place"), 1);
    }

    public static void itin_draw(Track t) {
      if(GlobalVariables.itin_pmap == null)
        GlobalVariables.itin_pmap = GlobalFunctions.get_pixmap(GlobalVariables.itin_xpm);

      GlobalFunctions.tr_fillrect(t.x, t.y);
      GlobalFunctions.draw_pixmap(t.x, t.y, GlobalVariables.itin_pmap);

      if(string.IsNullOrEmpty(t.station) == false) {
#if false // !Rask Ingemann Lambertsen
	    draw_itin_text(t.x, t.y, t.station, t.direction == 1);
#else
        string label;
        int pos = t.station.IndexOf(Configuration.PLATFORM_SEP);
        if(pos >= 0) {
          label = t.station.Substring(pos);
          if(label.Length >= 1)
            label = label.Substring(1);
        } else {
          label = t.station;
        }
        GlobalFunctions.draw_itin_text(t.x, t.y, label, (t.direction == trkdir.W_E) ? 1 : 0);
#endif
      }
    }

    public static void mover_draw() {
      GlobalFunctions.draw_link(
        GlobalVariables.move_start.x,
        GlobalVariables.move_start.y,
        GlobalVariables.move_end.x,
        GlobalVariables.move_end.y,
        GlobalVariables.color_white);
    }

    public static void trigger_draw(Track t) {
      VLines[] img;

      switch(t.direction) {
        case trkdir.S_N:
          img = GlobalVariables.ntrigger_layout;
          break;
        case trkdir.N_S:
          img = GlobalVariables.strigger_layout;
          break;
        case trkdir.W_E:
          img = GlobalVariables.etrigger_layout;
          break;
        case trkdir.E_W:
          img = GlobalVariables.wtrigger_layout;
          break;
        default:
          return;
      }

      GlobalFunctions.draw_layout(t.x, t.y, img, GlobalVariables.curSkin.working_track);
      if(GlobalVariables.editing && GlobalVariables.show_links) {
        if(t.wlinkx != 0 && t.wlinky != 0)
          GlobalFunctions.draw_link(t.x, t.y, t.wlinkx, t.wlinky, GlobalVariables.conf.linkcolor);
      }
    }

    public static void image_draw(Track t) {
      string buff;
      string p;
      object pixels = null;
      int ix;

      if(GlobalVariables.camera_pmap == null)
        GlobalVariables.camera_pmap = GlobalFunctions.get_pixmap(GlobalVariables.camera_xpm);
      if(t.direction != 0 || string.IsNullOrEmpty(t.station)) {/* filename! */
        pixels = GlobalVariables.camera_pmap;
      } else {
        if(t._isFlashing && t._flashingIcons[t._nextFlashingIcon] != null)
          ix = GlobalFunctions.get_pixmap_index(t._flashingIcons[t._nextFlashingIcon]);
        else
          ix = GlobalFunctions.get_pixmap_index(t.station);
        if(ix < 0) {	    /* for UNIX, try lower case name */
          buff = string.Copy(t.station);
          string tmpBuff = "";
          for(int i = 0; i < buff.Length; i++) {
            if(buff[i] >= 'A' && buff[i] <= 'Z')
              tmpBuff += buff[i] + ' ';
            else
              tmpBuff += buff[i];
          }
          buff = tmpBuff;

          ix = GlobalFunctions.get_pixmap_index(GlobalVariables.buff);
        }
        if(ix < 0) {
          buff = String.Format(wxPorting.T("%s '%s'."), wxPorting.L("Error reading"), t.station);
          GlobalFunctions.do_alert(buff);
          pixels = GlobalVariables.camera_pmap;
          if(t._isFlashing)
            t._flashingIcons[t._nextFlashingIcon] = null;
          else
            t.station = null;
        } else
          pixels = GlobalVariables.pixmaps[ix].pixels;
      }
      GlobalFunctions.draw_pixmap(t.x, t.y, pixels);
      if(GlobalVariables.editing && GlobalVariables.show_links && t.wlinkx != 0 && t.wlinky != 0)
        GlobalFunctions.draw_link(t.x, t.y, t.wlinkx, t.wlinky, GlobalVariables.conf.linkcolor);
    }

    public static void track_paint(Track t) {
      GlobalFunctions.tr_fillrect(t.x, t.y);
      if(!GlobalVariables.editing && t.invisible)
        return;

      switch(t.type) {
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
          link_draw(t);
          break;

        case trktype.IMAGE:
          image_draw(t);
          break;

        case trktype.MACRO:
          macro_draw(t);
          break;

        case trktype.ITIN:
          itin_draw(t);
          break;

        case trktype.TRIGGER:
          trigger_draw(t);
          break;

        default:
          return;
      }
      if(GlobalVariables.editing && GlobalVariables.show_scripts && string.IsNullOrEmpty(t.stateProgram) == false) {
        GlobalFunctions.draw_layout(t.x, t.y, GlobalVariables.switch_rect, GlobalVariables.curSkin.working_track);//fieldcolors[COL_TRAIN2]);
      }
    }

    public static string train_next_stop(Train t, out int final) {
      Track tr = new Track();
      string buff = "";
      TrainStop ts = new TrainStop();
      TrainStop last = new TrainStop();

      final = 0;
      buff = "";
      if(t.status != trainstat.train_RUNNING && t.status != trainstat.train_WAITING &&
          t.status != trainstat.train_STOPPED)
        return buff;
      buff = "";
      last = null;
      for(ts = t.stops; ts != null; ts = ts.next) {
        if(ts.minstop != 0)
          continue;
        tr = GlobalFunctions.findStationNamed(ts.station);
        if(tr != null || tr.type != trktype.TRACK)
          continue;
        if(ts.stopped != 0)
          continue;
        //	    if(!last || ts.arrival < last.arrival)
        last = ts;
        break;
      }
      if(last == null) {// if(!last != 0) {
        tr = GlobalFunctions.findStationNamed(t.exit);
        if(tr != null || tr.type == trktype.TEXT)
          return buff;
        final = 1;
        buff = string.Format(wxPorting.T(" {0} {1} {2} {3}   "), wxPorting.L("Final stop"), t.exit, wxPorting.L("at"), GlobalFunctions.format_time(t.timeout));
      } else
        buff = string.Format(wxPorting.T(" {0} {1} {2} {3}   "), wxPorting.L("Next stop"), last.station, wxPorting.L("at"), GlobalFunctions.format_time(last.arrival));
      return buff;
    }

    public static bool is_canceled(Train t) {
      if(t.days == RunDays.None || GlobalVariables.run_day == RunDays.None || (t.days & GlobalVariables.run_day) != RunDays.None)
        return false;

      return true;
    }

    public static string train_status0(Train t, int full) {
      string buff;
      int i, j, final = 0;

      if(GlobalVariables.terse_status != 0)
        full = 0;

      buff = "";
      i = 0;
      if(t.isExternal) {
        return wxPorting.L("external");
      }
      switch(t.status) {
        case trainstat.train_READY:
          if(!is_canceled(t)) {
            if(t.entryDelay == null || t.entryDelay.nSeconds == 0)
              return wxPorting.L("ready");
            buff = String.Format(
          wxPorting.T("%s ETA %s"), wxPorting.L("ready"), GlobalFunctions.format_time(t.timein + t.entryDelay.nSeconds));
            return buff;
          }
          buff = String.Format(wxPorting.T("%s "), wxPorting.L("Canceled - runs on"));
          for(i = 1, j = '1'; i < 0x80; i <<= 1, ++j)
            if(((byte)t.days & i) != 0)
              buff += j.ToString();
          return buff;

        case trainstat.train_RUNNING:
          if(full != 0)
            buff = String.Copy(train_next_stop(t, out final));
          if(t.shunting)
            buff += wxPorting.L("Shunting");
          else if(full != 0) {
            if(final != 0)
              buff += String.Format(wxPorting.T("%s: %d Km/h"), wxPorting.L("Speed"), (int)t.curspeed);
            else
              buff += String.Format(wxPorting.T("%s: %d Km/h %s %s"), wxPorting.L("Speed"),
                    (int)t.curspeed, wxPorting.L("to"), t.exit);
          } else
            buff += String.Format(wxPorting.T("%s %s"), wxPorting.L("Running. Dest."), t.exit);
          return buff;

        case trainstat.train_STOPPED:
          if(full != 0) {
            long timedep = t.timedep;
            TrainStop stp = GlobalFunctions.findStop(t, t.position);
            if(stp != null && stp.depDelay != null && stp.depDelay.nSeconds != 0)
              timedep += stp.depDelay.nSeconds;
            else if(t.position.station != null &&
              GlobalFunctions.sameStation(t.entrance, t.position.station) &&
              t.entryDelay != null)
              timedep += t.entryDelay.nSeconds;
            buff = String.Format(wxPorting.T("%s %s "), wxPorting.L("Stopped. ETD"), GlobalFunctions.format_time(timedep));
            if(full != 0)
              buff += train_next_stop(t, out final);
            if(final == 0) {
              buff += wxPorting.L("Dest");
              buff += wxPorting.T(" ");
              buff += t.exit;
            }
          } else {
            long timedep = t.timedep;
            TrainStop stp = GlobalFunctions.findStop(t, t.position);
            if(stp != null && stp.depDelay != null && stp.depDelay.nSeconds != 0)
              timedep += stp.depDelay.nSeconds;
            else if(string.IsNullOrEmpty(t.position.station) == false &&
              GlobalFunctions.sameStation(t.entrance, t.position.station) &&
              t.entryDelay != null)
              timedep += t.entryDelay.nSeconds;
            buff = String.Format(wxPorting.T("%s %s  %s %s"), wxPorting.L("Stopped. ETD"), GlobalFunctions.format_time(timedep),
              wxPorting.L("Dest."), t.exit);
          }
          return buff;

        case trainstat.train_DELAY:
          buff = String.Format(wxPorting.T("%s %s"), wxPorting.L("Delayed entry at"), t.entrance);
          return buff;

        case trainstat.train_WAITING:
          buff = String.Format(wxPorting.T("%s. %s%s %s"), wxPorting.L("Waiting"),
            (full != 0) ? train_next_stop(t, out final) : wxPorting.T(""), wxPorting.L("Dest."), t.exit);
          return buff;

        case trainstat.train_DERAILED:
          return wxPorting.L("derailed");

        case trainstat.train_STARTING:
          buff = String.Format(wxPorting.T("%s (-%d)"), wxPorting.L("Starting"), t.startDelay);
          return buff;

        case trainstat.train_ARRIVED:
          if(t.wrongdest)
            buff = String.Format(wxPorting.T("%s %s %s %s"), wxPorting.L("Arrived at"), t.exited, wxPorting.L("instead of"), t.exit);
          else if(t.timeexited / 60 > t.timeout / 60)
            buff = String.Format(wxPorting.T("%s %d %s %s"), wxPorting.L("Arrived"),
          (t.timeexited - t.timeout) / 60, wxPorting.L("min. late at"), t.exit);
          else
            buff = String.Format(wxPorting.L("Arrived on time"));
          if(t.stock != null && t.stock.Length > 0)
            buff += String.Format(wxPorting.T(" - %s %s"), wxPorting.L("stock for"), t.stock);
          return buff;
      }
      return wxPorting.T("");
    }

    public static string train_status(Train t) {
      return train_status0(t, 0);
    }

    public static void track_delete(Track t)
    {
      //Track	t1, old;

      //if(t == GlobalVariables.layout)
      //  GlobalVariables.layout = t.next;
      //else {
      //  old = GlobalVariables.layout;
      //    for(t1 = old.next; t1 != t; t1 = t1.next)
      //  old = t1;
      //    old.next = t.next;
      //}
      //if(string.IsNullOrEmpty(t.station) == false)
      //  GlobalFunctions.free(t.station);
      //GlobalFunctions.delete_script_data(t);
      //GlobalVariables.onIconUpdateListeners.Remove(t);
      //// delete t;
      //GlobalFunctions.link_all_tracks();
    }
  }

  #region tmp region
  //int     no_train_names_colors = 0;
  //int	auto_link = 1;
  //int	link_to_left = 0;
  //Coord	link_start;
  //int	current_macro = -1;
  //wxChar	*current_macro_name;
  //Track	**macros;
  //int	nmacros, maxmacros;
  //Array<Track *> onIconUpdateListeners;


  //void	free_pixmaps(void)
  //{
  //  int	    i;

  //  for(i = 0; i < 4; ++i) {
  //      delete_pixmap(e_train_pmap[i]);
  //      delete_pixmap(w_train_pmap[i]);
  //      delete_pixmap(e_car_pmap[i]);
  //      delete_pixmap(w_car_pmap[i]);
  //  }

  //  Signal::FreePixmaps();
  //  delete_pixmap(tracks_pixmap);
  //  delete_pixmap(switches_pixmap);
  //  delete_pixmap(signals_pixmap);
  //  delete_pixmap(tools_pixmap);
  //  delete_pixmap(actions_pixmap);
  //  delete_pixmap(move_start_pixmap);
  //  delete_pixmap(move_end_pixmap);
  //  delete_pixmap(move_dest_pixmap);
  //  delete_pixmap(set_power_pixmap);
  //  delete_pixmap(speed_pmap);
  //}

  //void	track_name(Track *t, wxChar *name)
  //{
  //  if(t.station)
  //      free(t.station);
  //  t.station = wxStrdup(name);
  //}

  //void    get_basic_name(Train *trn, Char *dest, int size)
  //{
  //        int     i;

  //        // isolate the main component of a train's name, usually the number
  //        wxStrncpy(dest, trn.name, size);
  //        dest[size - 1] = 0;
  //        for(i = 0; dest[i]; ++i)
  //            if(dest[i] == wxPorting.T(' '))
  //                break;
  //        dest[i] = 0;
  //}

  //const Char *GetColorName(int color)
  //{
  //  if(color == conf.fgcolor)
  //      return wxPorting.T("black");
  //  if(color == color_white)
  //      return wxPorting.T("white");
  //  if(color == color_orange)
  //      return wxPorting.T("orange");
  //  if(color == color_green)
  //      return wxPorting.T("green");
  //  if(color == color_red)
  //      return wxPorting.T("red");
  //  if(color == color_blue)
  //      return wxPorting.T("blue");
  //  if(color == color_cyan)
  //      return wxPorting.T("cyan");
  //  return wxPorting.T("unknown");
  //}


  //void	walk_vertical(Track *trk, Track *t, trkdir *ndir)
  //{
  //  if(*ndir == N_S) {
  //      if(t.elinkx && t.elinky) {
  //    trk.x = t.elinkx;
  //    trk.y = t.elinky;
  //    return;
  //      }
  //      trk.x = t.x;
  //      trk.y = t.y + 1;
  //      return;
  //  }
  //  if(t.wlinkx && t.wlinky) {
  //      trk.x = t.wlinkx;
  //      trk.y = t.wlinky;
  //      return;
  //  }
  //  trk.x = t.x;
  //  trk.y = t.y - 1;
  //}

  //void	walk_vertical_switch(Track *trk, Track *t, trkdir *ndir)
  //{
  //  switch(t.direction) {
  //  case 12:
  //    if(*ndir == W_E)
  //        *ndir = S_N;
  //    if(*ndir == S_N) {
  //        trk.x = t.x;
  //        trk.y = t.y - 1;
  //    } else if(t.switched) {
  //        trk.x = t.x - 1;
  //        trk.y = t.y + 1;
  //        *ndir = E_W;
  //    } else {
  //        trk.x = t.x;
  //        trk.y = t.y + 1;
  //    }
  //    break;

  //  case 13:
  //    if(*ndir == E_W)
  //        *ndir = S_N;
  //    if(*ndir == S_N) {
  //        trk.x = t.x;
  //        trk.y = t.y - 1;
  //    } else if(t.switched) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //        *ndir = W_E;
  //    } else {
  //        trk.x = t.x;
  //        trk.y = t.y + 1;
  //    }
  //    break;

  //  case 14:
  //    if(*ndir == W_E)
  //        *ndir = N_S;
  //    if(*ndir == N_S) {
  //        trk.x = t.x;
  //        trk.y = t.y + 1;
  //    } else if(t.switched) {
  //        trk.x = t.x - 1;
  //        trk.y = t.y - 1;
  //        *ndir = E_W;
  //    } else {
  //        trk.x = t.x;
  //        trk.y = t.y - 1;
  //    }
  //    break;

  //  case 15:
  //    if(*ndir == E_W)
  //        *ndir = N_S;
  //    if(*ndir == N_S) {
  //        trk.x = t.x;
  //        trk.y = t.y + 1;
  //    } else if(t.switched) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //        *ndir = W_E;
  //    } else {
  //        trk.x = t.x;
  //        trk.y = t.y - 1;
  //    }
  //    break;

  //  case 18:
  //    if(t.switched) {
  //        if(*ndir == W_E)
  //      *ndir = S_N;
  //        if(*ndir == S_N) {
  //      trk.x = t.x;
  //      trk.y = t.y - 1;
  //        } else {
  //      trk.x = t.x - 1;
  //      trk.y = t.y + 1;
  //      *ndir = E_W;
  //        }
  //        break;
  //    }
  //    if(*ndir == W_E) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //    } else {
  //        trk.x = t.x - 1;
  //        trk.y = t.y + 1;
  //    }
  //    break;

  //  case 19:
  //    if(t.switched) {
  //        if(*ndir == E_W)
  //      *ndir = N_S;
  //        if(*ndir == S_N) {
  //      trk.x = t.x + 1;
  //      trk.y = t.y - 1;
  //      *ndir = W_E;
  //        } else {
  //      trk.x = t.x;
  //      trk.y = t.y + 1;
  //        }
  //        break;
  //    }
  //    if(*ndir == W_E || *ndir == S_N) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //    } else {
  //        trk.x = t.x - 1;
  //        trk.y = t.y + 1;
  //    }
  //    break;

  //  case 20:
  //    if(t.switched) {
  //        if(*ndir == E_W)
  //      *ndir = S_N;
  //        if(*ndir == N_S) {
  //      trk.x = t.x + 1;
  //      trk.y = t.y + 1;
  //      *ndir = W_E;
  //        } else {
  //      trk.x = t.x;
  //      trk.y = t.y - 1;
  //        }
  //        break;
  //    }
  //    if(*ndir == W_E) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //    } else {
  //        trk.x = t.x - 1;
  //        trk.y = t.y - 1;
  //    }
  //    break;

  //  case 21:
  //    if(t.switched) {
  //        if(*ndir == W_E)
  //      *ndir = N_S;
  //        if(*ndir == S_N) {
  //      trk.x = t.x - 1;
  //      trk.y = t.y - 1;
  //      *ndir = E_W;
  //        } else {
  //      trk.x = t.x;
  //      trk.y = t.y + 1;
  //        }
  //        break;
  //    }
  //    if(*ndir == W_E) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //    } else {
  //        trk.x = t.x - 1;
  //        trk.y = t.y - 1;
  //    }
  //    break;

  //  case 22:
  //    if(t.switched) {
  //        if(*ndir == S_N) {
  //      trk.x = t.x - 1;
  //      trk.y = t.y - 1;
  //      *ndir = E_W;
  //      break;
  //        }
  //    } else if(*ndir == S_N) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //        *ndir = W_E;
  //        break;
  //    }
  //    trk.x = t.x;
  //    trk.y = t.y + 1;
  //    *ndir = N_S;
  //    break;

  //  case 23:
  //    if(t.switched) {
  //        if(*ndir == N_S) {
  //      trk.x = t.x - 1;
  //      trk.y = t.y + 1;
  //      *ndir = E_W;
  //      break;
  //        }
  //    } else if(*ndir == N_S) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //        *ndir = W_E;
  //        break;
  //    }
  //    trk.x = t.x;
  //    trk.y = t.y - 1;
  //    *ndir = S_N;
  //    break;
  //  }
  //}

  //Track	*track_walkeast(Track *t, trkdir *ndir)
  //{
  //  static	Track	trk;

  //  if(t.direction != TRK_N_S && t.elinkx && t.elinky) {
  //      trk.x = t.elinkx;
  //      trk.y = t.elinky;
  //      return &trk;
  //  }
  //  trk.x = t.x + 1;
  //  trk.y = t.y;
  //  switch(t.direction) {
  //  case NW_SE:
  //  case W_SE:
  //    ++trk.y;
  //    break;
  //  case SW_NE:
  //  case W_NE:
  //    --trk.y;
  //    break;
  //  case SW_N:
  //    if(*ndir == N_S) {
  //        trk.x = t.x - 1;
  //        trk.y = t.y + 1;
  //        *ndir = E_W;
  //        break;
  //    }
  //    trk.y = t.y - 1;
  //    trk.x = t.x;
  //    *ndir = S_N;
  //    break;
  //  case NW_S:
  //    if(*ndir == S_N) {
  //        *ndir = E_W;
  //        trk.x = t.x - 1;
  //        trk.y = t.y - 1;
  //        break;
  //    }
  //    trk.x = t.x;
  //    trk.y = t.y + 1;
  //    *ndir = N_S;
  //    break;
  //  case NE_S:
  //    if(*ndir == S_N) {
  //        *ndir = W_E;
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //        break;
  //    }
  //    trk.x = t.x;
  //    trk.y = t.y + 1;
  //    *ndir = N_S;
  //    break;

  //  case SE_N:
  //    if(*ndir == N_S) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //        *ndir = W_E;
  //        break;
  //    }
  //    trk.y = t.y - 1;
  //    trk.x = t.x;
  //    *ndir = S_N;
  //    break;

  //  case TRK_N_S:
  //    walk_vertical(&trk, t, ndir);
  //    break;

  //        case X_X:
  //                break;

  //  default:
  //    *ndir = W_E;
  //  }
  //  return &trk;
  //}

  //Track	*track_walkwest(Track *t, trkdir *ndir)
  //{
  //  static	Track	trk;

  //  if(t.direction != TRK_N_S && t.wlinkx && t.wlinky) {
  //      trk.x = t.wlinkx;
  //      trk.y = t.wlinky;
  //      return &trk;
  //  }
  //  trk.x = t.x - 1;
  //  trk.y = t.y;
  //  switch(t.direction) {
  //  case SW_N:
  //    if(*ndir == N_S) {
  //        ++trk.y;
  //        *ndir = E_W;
  //        break;
  //    }
  //    *ndir = S_N;
  //  case SW_NE:
  //  case SW_E:
  //    ++trk.y;
  //    break;
  //  case NW_S:
  //    if(*ndir == N_S) {
  //        trk.x = t.x;
  //        trk.y = t.y + 1;
  //        break;
  //    }
  //    *ndir = E_W;
  //  case NW_SE:
  //  case NW_E:
  //    --trk.y;
  //    break;
  //  case NE_S:
  //    if(*ndir == S_N) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y - 1;
  //        *ndir = W_E;
  //        break;
  //          }
  //    *ndir = N_S;
  //    trk.y = t.y + 1;
  //    trk.x = t.x;
  //    break;
  //  case SE_N:
  //    if(*ndir == N_S) {
  //        trk.x = t.x + 1;
  //        trk.y = t.y + 1;
  //        *ndir = W_E;
  //        break;
  //    }
  //    *ndir = S_N;
  //    trk.x = t.x;
  //    trk.y = t.y - 1;
  //    break;
  //  case TRK_N_S:
  //    walk_vertical(&trk, t, ndir);
  //    break;

  //        case X_X:
  //                break;

  //  default:
  //    *ndir = E_W;
  //  }
  //  return &trk;
  //}

  //Track	*swtch_walkeast(Track *t, trkdir *ndir)
  //{
  //  static	Track	trk;

  //  trk.x = t.x;
  //  trk.y = t.y;
  //  switch(t.direction) {
  //  case 0:
  //    ++trk.x;
  //    if(t.switched)
  //        --trk.y;
  //    break;

  //  case 1:
  //  case 3:
  //  case 11:
  //    ++trk.x;
  //    break;

  //  case 2:
  //    ++trk.x;
  //    if(t.switched)
  //        ++trk.y;
  //    break;

  //  case 4:
  //    ++trk.x;
  //    if(!t.switched)
  //        --trk.y;
  //    break;

  //  case 5:
  //    ++trk.x;
  //    --trk.y;
  //    break;

  //  case 6:
  //    ++trk.x;
  //    if(!t.switched)
  //        ++trk.y;
  //    break;

  //  case 7:
  //    ++trk.x;
  //    ++trk.y;
  //    break;

  //  case 8:		    /* These are special cases handled in findPath() */
  //  case 9:
  //  case 16:
  //  case 17:
  //    break;

  //  case 10:
  //    ++trk.x;
  //    if(t.switched)
  //        ++trk.y;
  //    else
  //        --trk.y;
  //    break;

  //  case 12:
  //  case 13:
  //  case 14:
  //  case 15:
  //  case 18:
  //  case 19:
  //  case 20:
  //  case 21:
  //  case 22:
  //  case 23:
  //    walk_vertical_switch(&trk, t, ndir);
  //    break;

  //  }
  //  return &trk;
  //}

  //Track	*swtch_walkwest(Track *t, trkdir *ndir)
  //{
  //  static	Track	trk;

  //  trk.x = t.x;
  //  trk.y = t.y;
  //  switch(t.direction) {
  //  case 1:
  //    --trk.x;
  //    if(t.switched)
  //        --trk.y;
  //    break;

  //  case 0:
  //  case 2:
  //  case 10:
  //    --trk.x;
  //    break;

  //  case 3:
  //    --trk.x;
  //    if(t.switched)
  //        ++trk.y;
  //    break;

  //  case 4:
  //    --trk.x;
  //    ++trk.y;
  //    break;

  //  case 5:
  //    --trk.x;
  //    if(!t.switched)
  //        ++trk.y;
  //    break;

  //  case 7:
  //    --trk.x;
  //    if(!t.switched)
  //        --trk.y;
  //    break;

  //  case 6:
  //    --trk.x;
  //    --trk.y;
  //    break;

  //  case 8:		    /* These are special cases handled in findPath() */
  //  case 9:
  //  case 16:
  //  case 17:
  //    break;

  //  case 11:
  //    --trk.x;
  //    if(t.switched)
  //        ++trk.y;
  //    else
  //        --trk.y;
  //    break;

  //  case 12:
  //  case 13:
  //  case 14:
  //  case 15:
  //  case 18:
  //  case 19:
  //  case 20:
  //  case 21:
  //  case 22:
  //  case 23:
  //    walk_vertical_switch(&trk, t, ndir);
  //  }
  //  return &trk;
  //}

  //void	check_layout_errors(void)
  //{
  //  Track	*t, *t1;
  //  wxChar	buff[512];
  //  int firsttime = 1;

  //  for(t = layout; t; t = t.next) {
  //      buff[0] = 0;
  //      if(t.type == TSIGNAL) {
  //    if(!t.controls)
  //        wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s.\n"), L("Signal at"), t.x, t.y, L("not linked to any track"));
  //    else switch(t.direction) {
  //    case E_W:
  //    case signal_WEST_FLEETED:
  //    case N_S:
  //        if(!t.controls.wsignal)
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d - %s %d,%d.\n"), L("Track at"),
  //        t.controls.x, t.controls.y,
  //        L("not controlled by signal at"), t.x, t.y);
  //        break;
  //    case W_E:
  //    case signal_EAST_FLEETED:
  //    case S_N:
  //        if(!t.controls.esignal)
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d - %s %d,%d.\n"), L("Track at"),
  //        t.controls.x, t.controls.y,
  //        L("not controlled by signal at"), t.x, t.y);
  //        break;
  //    }
  //      }
  //      if(t.type == TRACK || t.type == IMAGE) {
  //    if(t.wlinkx && t.wlinky) {
  //        if(!(t1 = findTrack(t.wlinkx, t.wlinky)))
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Track at"), t.x, t.y,
  //          L("linked to non-existant track at"), t.wlinkx, t.wlinky);
  //        else if(!findTrack(t1.elinkx, t1.elinky) &&
  //          !findTrack(t1.wlinkx, t1.wlinky))
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Track at"), t1.x, t1.y,
  //          L("not linked back to"), t.x, t.y);
  //    } else if(t.elinkx && t.elinky) {
  //        if(!(t1 = findTrack(t.elinkx, t.elinky)))
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Track at"), t.x, t.y,
  //          L("linked to non-existant track at"), t.elinkx, t.elinky);
  //        else if(!findTrack(t1.elinkx, t1.elinky) &&
  //          !findTrack(t1.wlinkx, t1.wlinky))
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Track at"), t1.x, t1.y,
  //          L("not linked back to"), t.x, t.y);
  //    }

  //      }
  //      if(t.type == SWITCH) {
  //    if(t.wlinkx && t.wlinky) {
  //        if(!(t1 = findSwitch(t.wlinkx, t.wlinky)))
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Switch at"), t.x, t.y,
  //          L("linked to non-existant switch at"), t.wlinkx, t.wlinky);
  //        else if(t1.wlinkx != t.x || t1.wlinky != t.y)
  //      wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("%s %d,%d %s %d,%d.\n"),
  //          L("Switch at"), t1.x, t1.y,
  //          L("not linked back to switch at"), t.x, t.y);
  //    }
  //      }
  //      if(buff[0]) {
  //    if(firsttime)
  //        traindir.layout_error(L("Checking for errors in layout...\n"));
  //    firsttime = 0;
  //    traindir.layout_error(buff);
  //      }
  //  }
  //  traindir.end_layout_error();
  //}

  //void	link_tracks(Track *t, Track *t1)
  //{
  //  switch(t.type) {
  //  case TRACK:
  //    if(t1.type != TRACK) {
  //        traindir.Error(L("Only like tracks can be linked."));
  //        return;
  //    }
  //    if(t1.direction != W_E && t1.direction != TRK_N_S) {
  //        traindir.Error(L("Only horizontal or vertical tracks can be linked automatically.\nTo link other track types, use the track properties dialog."));
  //        return;
  //    }
  ///*
  //    if(t.direction != t1.direction) {
  //        error(wxPorting.T("You can't link horizontal to vertical tracks."));
  //        return;
  //    }
  //*/		if(t.direction == TRK_N_S) {
  //        if(!findTrack(t.x, t.y + 1)) {
  //      t.elinkx = t1.x;
  //      t.elinky = t1.y;
  //        } else {
  //      t.wlinkx = t1.x;
  //      t.wlinky = t1.y;
  //        }
  //        if(!findTrack(t1.x , t1.y + 1)) {
  //      t1.elinkx = t.x;
  //      t1.elinky = t.y;
  //        } else {
  //      t1.wlinkx = t.x;
  //      t1.wlinky = t.y;
  //        }
  //        break;
  //    }
  //    if(!findTrack(t.x + 1, t.y) &&
  //      !findSwitch(t.x + 1, t.y)) {
  //        t.elinkx = t1.x;
  //        t.elinky = t1.y;
  //    } else {
  //        t.wlinkx = t1.x;
  //        t.wlinky = t1.y;
  //    }
  //    if(!findTrack(t1.x - 1, t1.y) &&
  //      !findSwitch(t1.x - 1, t1.y)) {
  //        t1.wlinkx = t.x;
  //        t1.wlinky = t.y;
  //    } else {
  //        t1.elinkx = t.x;
  //        t1.elinky = t.y;
  //    }
  //    break;

  //  case SWITCH:
  //    if(t1.type != SWITCH) {
  //        traindir.Error(L("Only like tracks can be linked."));
  //        return;
  //    }
  //    t.wlinkx = t1.x;
  //    t.wlinky = t1.y;
  //    t1.wlinkx = t.x;
  //    t1.wlinky = t.y;
  //    break;

  //  case TSIGNAL:
  //    if(t1.type != TRACK) {
  //        traindir.Error(L("Signals can only be linked to a track."));
  //        return;
  //    }
  //    t.wlinkx = t1.x;
  //    t.wlinky = t1.y;
  //    t.controls = findTrack(t1.x, t1.y);
  //    break;

  //  case TRIGGER:
  //    if(t1.type != TRACK) {
  //        traindir.Error(L("Triggers can only be linked to a track."));
  //        return;
  //    }
  //    t.wlinkx = t1.x;
  //    t.wlinky = t1.y;
  //    t.controls = findTrack(t1.x, t1.y);
  //    break;

  //        case IMAGE:
  //                t.wlinkx = t1.x;
  //                t.wlinky = t1.y;
  //                t.controls = t1;  // t1 could be a signal or a switch
  //                break;

  //  case TEXT:
  //    if(t1.type != TRACK) {
  //        traindir.Error(L("Entry/Exit points can only be linked to a track."));
  //        return;
  //    }
  //#if 0
  //    if(t1.direction == TRK_N_S)
  //    {
  //        if(t1.y < t.y) {
  //      t.elinkx = t1.x;
  //      t.elinky = t1.y;
  //        } else {
  //      t.wlinkx = t1.x;
  //      t.wlinky = t1.y;
  //        }
  //    }
  //#endif
  //    if(t1.x < t.x) {
  //        t.wlinkx = t1.x;
  //        t.wlinky = t1.y;
  //    } else {
  //        t.elinkx = t1.x;
  //        t.elinky = t1.y;
  //    }
  //    break;
  //  }
  //}

  //bool	isInside(Coord& upleft, Coord& downright, int x, int y)
  //{
  //  if(x >= upleft.x && x <= downright.x &&
  //      y >= upleft.y && y <= downright.y)
  //      return true;
  //  return false;
  //}

  ////	Move all track elements in the rectangle
  ////	comprised by (move_start,move_end) to
  ////	the coordinarte x,y (upper-left corner)

  //void	move_layout0(int x, int y)
  //{
  //  Coord	start, end;
  //  int	dx, dy;
  //  Track	*t, *t1;

  //  if(move_end.x < move_start.x) {
  //      start.x = move_end.x;
  //      end.x = move_start.x;
  //  } else {
  //      start.x = move_start.x;
  //      end.x = move_end.x;
  //  }
  //  if(move_end.y < move_start.y) {
  //      start.y = move_end.y;
  //      end.y = move_start.y;
  //  } else {
  //      start.y = move_start.y;
  //      end.y = move_end.y;
  //  }
  //  dx = x - start.x;
  //  dy = y - start.y;
  //  for(t = layout; t; t = t.next) {
  //      x = t.x;
  //      y = t.y;
  //      if(isInside(start, end, x, y)) {
  //    if((t1 = find_track(layout, t.x + dx, t.y + dy)))
  //        track_delete(t1);
  //    t.x += dx;
  //    t.y += dy;
  //      }
  //      if(t.elinkx && t.elinky &&
  //    isInside(start, end, t.elinkx, t.elinky)) {
  //    t.elinkx += dx;
  //    t.elinky += dy;
  //      }
  //      if(t.wlinkx && t.wlinky &&
  //    isInside(start, end, t.wlinkx, t.wlinky)) {
  //    t.wlinkx += dx;
  //    t.wlinky += dy;
  //      }
  //  }

  //  //  I hope this is right :)

  //  Itinerary   *it;
  //  int	    n;

  //  for(it = itineraries; it; it = it.next) {
  //      for(n = 0; n < it.nsects; ++n) {
  //    if(isInside(start, end, it.sw[n].x, it.sw[n].y)) {
  //        it.sw[n].x += dx;
  //        it.sw[n].y += dy;
  //    }
  //      }
  //  }
  //}

  //void	move_layout(int x, int y)
  //{
  //  // avoid overlaps by moving the original tracks
  //  // to an area where there cannot be any other track
  //  move_layout0(move_start.x + 1000, move_start.y + 1000);
  //  // move back from the temporary area to the
  //  // final destination area.
  //  move_start.x += 1000;
  //  move_start.y += 1000;
  //  move_end.x += 1000;
  //  move_end.y += 1000;
  //  move_layout0(x, y);
  //  move_start.x -= 1000;
  //  move_start.y -= 1000;
  //  move_end.x -= 1000;
  //  move_end.y -= 1000;
  //}

  //void	auto_link_track(Track *t)
  //{
  //  int	x, y;
  //  Track	*t1;

  //  x = t.x;
  //  y = t.y;
  //  if(link_to_left) {
  //      switch(t.direction) {
  //      case W_E:   --y;    break;
  //      case E_W:   ++y;    break;
  //      case N_S:   ++x;    break;
  //      case S_N:   --x;    break;
  //      }
  //  } else {
  //      switch(t.direction) {
  //      case W_E:   ++y;    break;
  //      case E_W:   --y;    break;
  //      case N_S:   --x;    break;
  //      case S_N:   ++x;    break;
  //      }
  //  }
  //  t1 = findTrack(x, y);
  //  if(t1 && t1.type == TRACK &&
  //    (t1.direction == W_E || t1.direction == TRK_N_S))
  //      link_tracks(t, t1);
  //}

  //int	macro_select(void)
  //{
  //  Track	*t;
  //  Itinerary *nextItin, *itinList = NULL;	// +Rask Ingemann Lambertsen
  //  wxChar	buff[512];

  //  if(!macros) {
  //      maxmacros = 1;
  //      macros = (Track **)calloc(sizeof(Track *), maxmacros);
  //  }
  //  buff[0] = 0;
  //  if(!traindir.OpenMacroFileDialog(buff))
  //      return 0;
  //  remove_ext(buff);
  //  if(!(t = load_field_tracks(buff, &itinList)))
  //      return 0;
  //  if(current_macro_name)
  //      free(current_macro_name);
  //  current_macro_name = wxStrdup(buff);
  //  clean_field(t);
  //  for(; itinList; itinList = nextItin) {	// +Rask Ingemann Lambertsen
  //      nextItin = itinList.next;
  //      free_itinerary(itinList);
  //  }
  ///*	if(macros[0])
  //      clean_field(macros[0]);
  //  macros[0] = t;
  //  current_macro = 0;
  //  nmacros = 1;
  //  maxmacros = 1;
  //*/
  //  return 1;
  //}

  //// begin +Rask Ingemann Lambertsen
  //static void relocate_itinerary(Itinerary *it, int xbase, int ybase)
  //{
  //  int	i;

  //  for(i = 0; i < it.nsects; ++i) {
  //      it.sw[i].x += xbase;
  //      it.sw[i].y += ybase;
  //  }
  //}
  //// end +Rask Ingemann Lambertsen

  //void	macro_place(int xbase, int ybase)
  //{
  //  Track	*mp;
  //  Track	*t, *t1;
  //  int	x, y;
  //  int	oldtool;
  //  Itinerary *itn, *itinList = NULL;	// +Rask Ingemann Lambertsen

  //  if(!current_macro_name)
  //      return;
  //  oldtool = current_tool;
  //  mp = load_field_tracks(current_macro_name, &itinList);
  //  while(mp) {
  //      t1 = mp.next;
  //      x = mp.x + xbase;
  //      y = mp.y + ybase;
  //      if((t = findTrack(x, y)) || (t = findSwitch(x, y)) ||
  //    (t = (Track *)findSignal(x, y)) || (t = findText(x, y)) ||
  //    (t = findPlatform(x, y)) || (t = findImage(x, y)) ||
  //    (t = findTrackType(x, y, ITIN)) ||
  //    (t = findTrackType(x, y, TRIGGER))) {
  //    track_delete(t);
  //      }
  //      mp.x = x;
  //      mp.y = y;
  //      if(mp.elinkx || mp.elinky) {
  //    mp.elinkx += xbase;
  //    mp.elinky += ybase;
  //      }
  //      if(mp.wlinkx || mp.wlinky) {
  //    mp.wlinkx += xbase;
  //    mp.wlinky += ybase;
  //      }
  //      mp.next = layout;
  //      layout = mp;
  //      link_all_tracks();
  //      mp = t1;
  //      layout_modified = 1;
  //  }
  //  // begin +Rask Ingemann Lambertsen
  //  /* Link in the itineraries from the macro.  Delete duplicates  */
  //  if(itinList) {
  //      for(itn = itinList; itn.next; itn = itn.next) {
  //    relocate_itinerary(itn, xbase, ybase);
  //    delete_itinerary(itn.name);
  //      }
  //      relocate_itinerary(itn, xbase, ybase);
  //      delete_itinerary(itn.name);
  //      itn.next = itineraries;
  //      itineraries = itinList;
  //      layout_modified = 1;
  //  }
  //  // end+Rask Ingemann Lambertsen
  //  sort_itineraries();
  //  invalidate_field();
  //  repaint_all();
  //  current_tool = oldtool;
  //}

  //void	track_place(int x, int y)
  //{
  //  Track	*t, *t1;
  //  int	needall;

  //  if(current_tool >= 0 && tooltbl[current_tool].type == MACRO) {
  //      if(!current_macro_name || tooltbl[current_tool].direction == 0) {
  //    select_tool(current_tool - 1);
  //    return;
  //      }
  //      macro_place(x, y);
  //      return;
  //  }
  //  if(current_tool >= 0 && tooltbl[current_tool].type == MOVER) {
  //      if(tooltbl[current_tool].direction == 0) {
  //    move_start.x = x;
  //    move_start.y = y;
  //    move_end.x = move_end.y = -1;
  //    select_tool(current_tool + 1);
  //    return;
  //      }
  //      if((short)move_start.x == -1) {
  //    select_tool(current_tool - 1);
  //    return;
  //      }
  //      if((short)move_end.x == -1) {
  //    move_end.x = x;
  //    move_end.y = y;
  //    select_tool(current_tool + 1);
  //    mover_draw();
  //    return;
  //      }
  //#if 0
  //      // avoid overlaps by moving the original tracks
  //      // to an area where there cannot be any other track
  //      move_layout(move_start.x + 1000, move_start.y + 1000);
  //      // move back from the temporary area to the
  //      // final destination area.
  //      move_start.x += 1000;
  //      move_start.y += 1000;
  //      move_end.x += 1000;
  //      move_end.y += 1000;
  //      move_layout(x, y);
  //#else
  //      move_layout(x, y);
  //#endif
  //      layout_modified = 1;
  //      invalidate_field();
  //      repaint_all();
  //      select_tool(current_tool - 2);
  //      move_start.x = move_start.y = -1;
  //      move_end.x = move_end.y = -1;
  //      return;
  //  }
  //  if(current_tool >= 0 && tooltbl[current_tool].type == LINK) {
  //      if(tooltbl[current_tool].direction == 0) {
  //    if(!findTrack(x, y) && !findSignal(x, y) &&
  //      !findSwitch(x, y) && !findText(x, y) &&
  //      !findTrackType(x, y, TRIGGER) &&
  //                        !findTrackType(x, y, IMAGE))
  //        return;		/* there must be a track */
  //    link_start.x = x;
  //    link_start.y = y;
  //    select_tool(current_tool + 1);
  //    return;
  //      }
  //      if(link_start.x == -1) {
  //    select_tool(current_tool - 1);
  //    return;
  //      }
  //      if(!(t = findTrack(link_start.x, link_start.y)) &&
  //        !(t = findSwitch(link_start.x, link_start.y)) &&
  //        !(t = (Track *)findSignal(link_start.x, link_start.y)) &&
  //        !(t = findText(link_start.x, link_start.y)) &&
  //        !(t = findTrackType(link_start.x, link_start.y, TRIGGER)) &&
  //                    !(t = findTrackType(link_start.x, link_start.y, IMAGE))) {
  //    return;
  //      }
  //      if(!(t1 = findTrack(x, y)) && !(t1 = (Track *)findSignal(x, y)) &&
  //      !(t1 = findSwitch(x, y)) && !(t1 = findText(x, y))) {
  //    return;
  //      }
  //      if(t.type == TRIGGER && t1.type != TRACK)
  //    return;
  //            if(t.type == IMAGE && (t1.type != SWITCH && t1.type != TSIGNAL))
  //                return;
  //      link_start.x = -1;
  //      link_start.y = -1;
  //      link_tracks(t, t1);
  //      layout_modified = 1;
  //      select_tool(current_tool - 1);
  //      return;
  //  }
  //  needall = 0;
  //  if((t = findTrack(x, y)) || (t = findSwitch(x, y)) ||
  //     (t = (Track *)findSignal(x, y)) || (t = findText(x, y)) ||
  //     (t = findPlatform(x, y)) || (t = findImage(x, y)) ||
  //     (t = findTrackType(x, y, ITIN)) ||
  //     (t = findTrackType(x, y, TRIGGER))) {
  //      needall = 1;
  //      track_delete(t);
  //      link_all_tracks();
  //      layout_modified = 1;
  //  }
  //  if(current_tool == 0) {		/* delete element */
  //      repaint_all();
  //      return;
  //  }
  //  t = track_new();
  //  t.x = x;
  //  t.y = y;
  //  t.type = (trktype)tooltbl[current_tool].type;
  //  t.direction = (trkdir)tooltbl[current_tool].direction;
  //        t.power = gEditorMotivePower;
  //        t.gauge = editor_gauge._iValue;
  //  t.next = layout;
  //  if(t.type == TEXT)
  //      t.station = wxStrdup(wxPorting.T("Abc"));
  //  else if(t.type == IMAGE)
  //      t.direction = (trkdir)0;
  //  else if(t.type == TSIGNAL) {
  //      if(t.direction & 2) {
  //    t.fleeted = 1;
  //    t.direction = (trkdir)((int)t.direction & (~2));
  //      } else
  //    t.fleeted = 0;
  //      if(auto_link)
  //    auto_link_track(t);
  //  } else if(t.type == TRIGGER && auto_link)
  //      auto_link_track(t);
  //  layout = t;
  //  link_all_tracks();
  //  layout_modified = 1;
  //  if(needall || is_windows)
  //      repaint_all();
  //  else
  //      track_paint(t);
  //}

  //void	track_properties(int x, int y)
  //{
  //  Track	*t;
  //  Signal	*sig;
  //  wxChar	buff[1024];

  //  if((t = findImage(x, y))) {
  //      buff[0] = 0;
  //      if(t.station)
  //    wxStrcpy(buff, t.station);
  //      if(!traindir.OpenImageDialog(buff))
  //    return;
  //      remove_ext(buff);
  //      wxStrcat(buff, wxPorting.T(".xpm"));
  //      if(t.station)
  //    free(t.station);
  //      t.pixels = 0;
  //      t.station = wxStrdup(buff);
  //      layout_modified = 1;
  //      repaint_all();
  //      return;
  //  }
  //  if((sig = findSignal(x,y)) && signal_properties_dialog) {
  //      signal_properties_dialog(sig);
  //      layout_modified = 1;
  //      return;
  //  }

  //  if((t = findTrackType(x, y, TRIGGER)) && trigger_properties_dialog) {
  //      trigger_properties_dialog(t);
  //      layout_modified = 1;
  //      return;
  //  }

  //        if((t = findSwitch(x, y))) {
  //            switch_properties_dialog(t);
  //            layout_modified = 1;
  //            return;
  //        }

  //  if((t = findTrack(x, y)) || (t = findText(x, y)) ||
  //      (t = (Track *)findSignal(x, y)) || /* (t = findImage(x, y)) || */
  //      (t = findTrackType(x, y, ITIN)) ||
  ////                      (t = findSwitch(x, t)) ||
  //      (t = findTrackType(x, y, TRIGGER))) {
  //      track_properties_dialog(t);
  //      layout_modified = 1;
  //            return;
  //  }
  //}
  #endregion
  ////
  ////	Scripting support
  ////


  //bool	Track::GetPropertyValue(const wxChar *prop, ExprValue& result)
  //{
  //  Track	*t = this;

  //  // move to Track::GetPropertyValue()
  //  if(!wxStrcmp(prop, wxPorting.T("length"))) {
  //      result._op = Number;
  //      result._val = t.length;
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("station"))) {
  //      result._op = String;
  //      result._txt = t.station ? wxPorting.T("") : t.station;
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%s}"), result._txt);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("busy"))) {
  //      result._op = Number;
  //      result._val = (t.fgcolor != conf.fgcolor) || findTrain(t.x, t.y);
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("free"))) {
  //      result._op = Number;
  //      result._val = t.fgcolor == conf.fgcolor && !findTrain(t.x, t.y);
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
  //      result._op = Number;
  //      if(t.type == SWITCH) {
  ///*		switch(t.direction) {
  //    case 10:	// Y switches could be considered always set to a siding
  //    case 11:	// but it conflicts with the option of reading the status
  //    case 22:	// then throwing the switch, so this is not enabled.
  //    case 23:
  //        result._val = 1;
  //        break;

  //    default: */
  //        result._val = t.switched;
  //    //}
  //      } else
  //    result._val = 0;
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("color"))) {
  //      result._op = String;
  //      result._txt = GetColorName(t.fgcolor);
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
  //      return true;
  //  }
  //        if(!wxStrcmp(prop, wxPorting.T("linked"))) {
  //            int x, y;
  //            if(!(x = t.wlinkx) || !(y = t.wlinky)) {
  //                x = t.elinkx;
  //                y = t.elinky;
  //            }
  //            Track *lnk = findTrack(x, y);
  //            if(!lnk) {
  //          wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d,%d} - not found"), x, y);
  //          result._op = Number;
  //          result._val = 0;
  //          return false;
  //            }
  //            if(lnk.type == TSIGNAL) {
  //                result._signal = (Signal *)lnk;
  //                result._op = SignalRef;
  //            } else {
  //                result._track = lnk;
  //                result._op = TrackRef;
  //            }
  //            return true;
  //        }

  //  result._op = Number;
  //  result._val = 0;
  //  return false;
  //}

  //bool	Track::SetPropertyValue(const wxChar *prop, ExprValue& val)
  //{
  //  if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
  //      if(type != SWITCH)
  //    return false;
  //      switched = val._val != 0;
  //            change_coord(this.x, this.y);
  //            repaint_all();
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("click"))) {
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
  //      track_selected(this.x, this.y);
  //      return true;
  //  }
  //  if(!wxStrcmp(prop, wxPorting.T("color"))) {
  //      wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff)/sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
  //            grcolor col = conf.fgcolor;
  //            if(wxStrcmp(val._txt, wxPorting.T("blue")) == 0)
  //                col = color_blue;
  //            else if(wxStrcmp(val._txt, wxPorting.T("white")) == 0)
  //                col = color_white;
  //            else if(wxStrcmp(val._txt, wxPorting.T("red")) == 0)
  //                col = color_red;
  //            else if(wxStrcmp(val._txt, wxPorting.T("green")) == 0)
  //                col = color_green;
  //            else if(wxStrcmp(val._txt, wxPorting.T("orange")) == 0)
  //                col = color_orange;
  //            else if(wxStrcmp(val._txt, wxPorting.T("black")) == 0)
  //                col = color_black;
  //            else if(wxStrcmp(val._txt, wxPorting.T("cyan")) == 0)
  //                col = color_cyan;
  //      SetColor(col);
  //      return true;
  //  }
  //        if(!wxStrcmp(prop, wxPorting.T("icon"))) {
  //            if(this.type == IMAGE) {
  //                if(this.station)
  //                    free(this.station);
  //                this.station = wxStrdup(val._txt);
  //                change_coord(this.x, this.y);
  //                repaint_all();
  //            }
  //        }

  //  return false;
  //}


  //TrackBase::TrackBase()
  //{
  //  next = 0;
  //  next1 = 0;
  //  x = y = 0;
  //  xsize = ysize = 0;
  //  type = NOTRACK;
  //  direction = W_E;
  //  status = ST_FREE;
  //  wlinkx = wlinky = 0;
  //  elinkx = elinky = 0;
  //  isstation = 0;
  //  switched = 0;
  //  busy = 0;
  //  fleeted = 0;
  //  nowfleeted = 0;
  //  norect = 0;
  //  fixedred = 0;
  //  nopenalty = 0;
  //  noClickPenalty = 0;
  //  invisible = 0;
  //  wtrigger = 0;
  //  etrigger = 0;
  //  signalx = 0;
  //  aspect_changed = 0;
  //  flags = 0;		/* performance flags (TFLG_*) */
  //  station = 0;
  //  lock = 0;
  //        _lockedBy = 0;
  //  memset(speed, 0, sizeof(speed));
  //  icon = 0;
  //  length = 0;
  //  wsignal = 0;		/* signal controlling this track */
  //  esignal = 0;		/* signal controlling this track */
  //  controls = 0;		/* track controlled by this signal */
  //  fgcolor = 0;
  //  pixels = 0;		/* for IMAGE pixmap */
  //  km = 0;			/* station distance (in meters) */
  //  stateProgram = 0;	/* 4.0: name of function describing state changes */
  //  _currentState = 0;	/* 4.0: name of current state in state program */
  //  _interpreterData = 0;	/* 4.0: intermediate data for program interpreter */
  //  _isFlashing = 0;	/* 4.0: flashing signal */
  //  _isShuntingSignal = 0;	/* 4.0: only affects shunting trains */
  //  _nextFlashingIcon = 0;	/* 4.0: index in list of icons when flashing */
  //  for(int i = 0; i < MAX_FLASHING_ICONS; ++i)
  //      _flashingIcons[i] = 0;
  //  _fontIndex = 0;
  //        _intermediate = false;
  //        _nReservations = 0;
  //        power = 0;              // 3.9: motive power allowed (diesel, electric)
  //        gauge = 0;              // 3.9: track gauge
  //}

  //bool	TrackInterpreterData::Evaluate(ExprNode *n, ExprValue& result)
  //{
  //  Track	*t = 0;
  //  Signal	*sig = 0;
  //  ExprValue left(None);
  //  ExprValue right(None);
  //  const wxChar	*prop;

  //  if(!n)
  //      return false;
  //        switch(n._op) {

  //        case LinkedRef:

  //            t = this._track;
  //            if(!t.wlinkx || !t.wlinky)
  //                return false;
  //            result._track = findSwitch(t.x, t.y);
  //            if(!result._track)
  //                return false;
  //            result._op = SwitchRef;
  //            return true;

  //  case Dot:

  //      result._op = Addr;
  //      if(!(n._left)) {
  //    result._track = this._track;
  //    result._op = TrackRef;
  //      } else if(n._left && n._left._op == Dot) {
  //    bool oldForAddr = _forAddr;
  //    _forAddr = true;
  //    if(!Evaluate(n._left, result)) {	// <signal>.<property>
  //        _forAddr = oldForAddr;
  //        return false;
  //    }
  //    _forAddr = oldForAddr;

  //    if(result._op == TrackRef || result._op == SwitchRef)
  //        TraceCoord(result._track.x, result._track.y);
  //                else if(result._op == SignalRef) {
  //            TraceCoord(result._signal.x, result._signal.y);
  //                    goto not_track;
  //                } else
  //        return false;
  //      } else {
  //    if(!Evaluate(n._left, result))
  //        return false;

  //    if(result._op == TrainRef)
  //        goto not_track;
  //    if(result._op == SignalRef)
  //        goto not_track;
  //    if(result._op != TrackRef && result._op != SwitchRef)
  //        return false;
  //      }
  //      if(!result._track) {
  //    wxStrcat(expr_buff, wxPorting.T("no current track for '.'"));
  //    return false;
  //      }
  //      t = result._track;
  //      TraceCoord(t.x, t.y);

  //not_track:
  //      if(n._right) {
  //    switch(n._right._op) {
  //    case LinkedRef:
  //                    if(!t) {
  //                        return false;
  //                    }
  //                    result._signal = 0;
  //                    result._track = findTrack(t.wlinkx, t.wlinky);
  //                    if(!result._track) {
  //                        result._track = findSwitch(t.wlinkx, t.wlinky);
  //                        if(result._track)
  //                            result._op = SwitchRef;
  //                        else {
  //                            result._signal = findSignal(t.wlinkx, t.wlinky);
  //                            if(result._signal)
  //                                result._op = SignalRef;
  //                            else {
  //                                result._track = findImage(t.wlinkx, t.wlinky);
  //                                if(result._track)
  //                                    result._op = TrackRef;
  //                                else {
  //                                    result._track = findTrackType(t.wlinkx, t.wlinky, ITIN);
  //                                    if(result._track) // do signal instead?
  //                                        result._op = TrackRef;
  //                                }
  //                            }
  //                        }
  //                    } else
  //                        result._op = TrackRef;
  //                    if(result._track) {
  //            TraceCoord(result._track.x, result._track.y);
  //            break;
  //                    }
  //                    if(result._signal) {
  //            TraceCoord(result._signal.x, result._signal.y);
  //            break;
  //                    }
  //        wxStrcat(expr_buff, wxPorting.T("no linked track for '.'"));
  //        return false;
  //    }
  //      }
  //      result._txt = (n._right && n._right._op == String) ? n._right._txt : n._txt;
  //      if(_forAddr)
  //    return true;

  //      prop = result._txt;
  //      if(!prop)
  //    return false;

  //      wxStrcat(expr_buff, prop);
  //      switch(result._op) {

  //      case SwitchRef:

  //    if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
  //        result._op = Number;
  //        result._val = t.switched;
  //        return true;
  //    }

  //      case Addr:
  //      case TrackRef:

  //    if(!result._track)
  //        return false;
  //    return result._track.GetPropertyValue(prop, result);

  //      case SignalRef:

  //    if(!result._signal)
  //        return false;
  //    return result._signal.GetPropertyValue(prop, result);

  //      case TrainRef:

  //    if(!result._train)
  //        return false;
  //    return result._train.GetPropertyValue(prop, result);

  //      }
  //      return false;

  //  case Equal:

  //      result._op = Number;
  //      result._val = 0;
  //      //if(_forCond)
  //    return InterpreterData::Evaluate(n, result);
  //      //return false;

  //  default:

  //      return InterpreterData::Evaluate(n, result);
  //  }

  //  return false;
  //}


  //void	Track::OnInit()
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onInit)
  //      return;
  //  interp._track = this;
  //  interp._train  = 0;
  //  interp._signal = 0;
  //  interp._stackPtr = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnInit"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onInit);
  //  return;
  //}

  //void	Track::OnEnter(Train *trn)
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onEnter)
  //      return;
  //  interp._track = this;
  //  interp._train = trn;
  //  interp._stackPtr = 0;
  //  interp._signal = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnEnter"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onEnter);
  //  return;
  //}

  //void	Track::OnClicked()
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onClicked)
  //      return;
  //  interp._track = this;
  //  interp._train = 0;
  //  interp._signal = 0;
  //  interp._stackPtr = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnClicked"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onClicked);
  //  return;
  //}

  //void	Track::OnCanceled()
  //{
  //  if(this.type != ITIN)
  //      return;
  //  if(_interpreterData) {
  //      TrackInterpreterData& interp = *(TrackInterpreterData *)_interpreterData;
  //      if(interp._onCanceled) {
  //    interp._track = this;
  //    Itinerary *it;
  //    for(it = itineraries; it; it = it.next)
  //        if(!wxStrcmp(it.name, this.station)) {
  //      interp._itinerary = it;
  //      break;
  //        }
  //    wxSnprintf(expr_buff, sizeof(expr_buff)/sizeof(wxChar), wxPorting.T("Track::OnCanceled(%s)"), this.station);
  //    Trace(expr_buff);
  //    interp.Execute(interp._onCanceled);
  //    return;
  //      }
  //  }
  //}

  //void	Track::OnCrossed(Train *trn)
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onCrossed)
  //      return;
  //  interp._track = this;
  //  interp._train = trn;
  //  interp._signal = 0;
  //  interp._stackPtr = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnCrossed"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onCrossed);
  //  return;
  //}

  //void	Track::OnArrived(Train *trn)
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onArrived)
  //      return;
  //  interp._track = this;
  //  interp._train = trn;
  //  interp._signal = 0;
  //  interp._stackPtr = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnArrived"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onArrived);
  //  return;
  //}

  //void	Track::OnStopped(Train *trn)
  //{
  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  if(!interp)
  //      return;
  //  if(!interp._onStopped)
  //      return;
  //  interp._track = this;
  //  interp._train = trn;
  //  interp._signal = 0;
  //  interp._stackPtr = 0;
  //  interp.TraceCoord(x, y, wxPorting.T("Track::OnStopped"));
  //  Trace(expr_buff);
  //  interp.Execute(interp._onStopped);
  //  return;
  //}

  //void	Track::ParseProgram()
  //{
  //  const wxChar	*p;

  //  if(!this.stateProgram || !*this.stateProgram)
  //      return;
  //  if(_interpreterData)	    // previous script
  //      delete _interpreterData;
  //  _interpreterData = new TrackInterpreterData;

  //  TrackInterpreterData *interp = (TrackInterpreterData *)_interpreterData;
  //  p = this.stateProgram;
  //  while(*p) {
  //      const wxChar	*p1 = p;
  //      while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
  //    ++p1;
  //      p = p1;
  //      if(match(&p, wxPorting.T("OnInit:"))) {
  //    p1 = p;
  //    interp._onInit = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnSetBusy:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onSetBusy = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnSetFree:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onSetFree = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnEnter:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onEnter = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnCrossed:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onCrossed = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnArrived:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onArrived = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnStopped:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onStopped = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnExit:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onExit = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnClicked:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onClicked = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnIconUpdate:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onIconUpdate = ParseStatements(&p);
  //      } else if(match(&p, wxPorting.T("OnCanceled:"))) {
  //    p = next_token(p);
  //    p1 = p;
  //    interp._onCanceled = ParseStatements(&p);
  //      }
  //      if(p1 == p)	    // error! couldn't parse token
  //    break;
  //  }
  //}

  //void	Track::RunScript(const Char *script, Train *trn)
  //{
  //  Script	*s = find_script(script);
  //  if(!s) {
  //      s = new_script(script);
  //      // return;
  //  }
  //  if(!s.ReadFile())
  //      return;

  //  // is it different from current one?
  //  if(!this.stateProgram || wxStrcmp(s._text, this.stateProgram)) {
  //      if(this.stateProgram)
  //    free(this.stateProgram);
  //      this.stateProgram = wxStrdup(s._text);
  //      ParseProgram();
  //  }
  //  OnEnter(trn);
  //}

  //bool	Track::IsBusy() const
  //{
  //  if(this.fgcolor != conf.fgcolor)
  //      return true;
  //  return false;
  //}
  // ERIK - End of original file
  public class grcolor {
    private int mInt;

    private grcolor(int i) {
      mInt = i;
    }

    public static implicit operator grcolor(int i) {
      return new grcolor(i);
    }

    public static implicit operator int(grcolor color) {
      return color == null ? -1 : color.mInt;
    }
  }

  public class TrackBase {
    public Track next = null;
    public Track next1 = null;		/* list of same type tracks */
    public int x, y;
    public int xsize, ysize;
    public trktype type = trktype.NOTRACK;
    public trkdir direction = trkdir.W_E;
    public trkstat status = trkstat.ST_FREE;
    public int wlinkx, wlinky;
    public int elinkx, elinky;
    public bool isstation = false;
    public bool switched = false;
    public char busy = (char)0x00;
    public bool fleeted = false;
    public bool nowfleeted = false;
    public bool norect = false; /* switches have a rectangle around em*/
    public bool fixedred = false;		/* signal is always red */
    public char nopenalty = (char)0x00;		/* no penalty for train stopping at signal */
    public bool noClickPenalty = false;	/* no penalty for un-necessary clicks */
    public bool invisible = false;		/* object is not shown on layout */
    public char wtrigger = (char)0x00;		/* westbound trigger linked */
    public char etrigger = (char)0x00;		/* eastbound trigger linked */
    public char signalx = (char)0x00;		/* use 'x' version when drawing signal */
    public bool aspect_changed = false;	/* ignore script execution - TODO: remove */
    public TFLG flags = 0;			/* performance flags (TFLG_*) */
    public string station = "";
    /// TODO
    // void	*lock;
    public int[] speed = new int[Configuration.NTTYPES];
    public int icon = 0;
    public int length = 0;
    public Signal wsignal = null;		/* signal controlling this track */
    public Signal esignal = null;		/* signal controlling this track */
    public Track controls = null;		/* track controlled by this signal */
    public grcolor fgcolor = null;
    /// TODO
    // void pixels;		/* for IMAGE pixmap */
    public long km = 0;			/* station distance (in meters) */
    public string stateProgram = null;		/* 3.5: name of function describing state changes */
    public string _currentState = null;	/* 3.5: name of current state in state program */
    public string _prevState = null;  /* 3.8q: signal state before update loop */
    public InterpreterData _interpreterData;	/* 3.5: intermediate data for program interpreter */
    public bool _isFlashing = false;		/* 3.5: flashing signal */
    public bool _isShuntingSignal = false;	/* 3.5: only affects shunting trains */
    public int _nextFlashingIcon = 0;	/* 3.5: index in list of icons when flashing */
    public string[] _flashingIcons = new string[Configuration.MAX_FLASHING_ICONS];	// 3.8: array of flashing icon names
    public int _fontIndex = 0;		// 3.6: font selection for TEXT tracks 

    public string _lockedBy = "";  // 3.7q: signal is locked by other signal(s)
    public bool _intermediate = false;   // 3.8h: signal is intermediate
    public int _nReservations = 0;  // 3.8h: number of trains still expected to pass this signal
    public string power = null;   // 3.9: motive power allowed (diesel, electric)
    public double gauge = 0;       // 3.9: track gauge

    bool GetPropertyValue(string prop, out ExprValue result) {
      result = null; return false;
    }
    bool SetPropertyValue(string prop, out ExprValue val) {
      val = null; return false;
    }
  }

  public class Track : TrackBase {
#if false
    public Track() { }
    virtual ~Track() { }

    bool GetPropertyValue(string prop, out ExprValue result) {
      Track t = this;

      // move to GetPropertyValue()
      if("length".equals(prop)) {
        result._op = Number;
        result._val = t.length;
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
        return true;
      }
      if("station".equals(prop)) {
        result._op = String;
        result._txt = t.station ? wxPorting.T("") : t.station;
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%s}"), result._txt);
        return true;
      }
      if("busy".equals(prop)) {
        result._op = Number;
        result._val = (t.fgcolor != conf.fgcolor) || findTrain(t.x, t.y);
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
        return true;
      }
      if("free".equals(prop)) {
        result._op = Number;
        result._val = t.fgcolor == conf.fgcolor && !findTrain(t.x, t.y);
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
        return true;
      }
      if("thrown".equals(prop)) {
        result._op = Number;
        if(t.type == SWITCH) {
          /*		switch(t.direction) {
              case 10:	// Y switches could be considered always set to a siding
              case 11:	// but it conflicts with the option of reading the status
              case 22:	// then throwing the switch, so this is not enabled.
              case 23:
                  result._val = 1;
                  break;

              default: */
          result._val = t.switched;
          //}
        } else
          result._val = 0;
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
        return true;
      }
      if("color".equals(prop)) {
        result._op = String;
        result._txt = GetColorName(t.fgcolor);
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d}"), result._val);
        return true;
      }
      if("linked".equals(prop)) {
        int x, y;
        if(!(x = t.wlinkx) || !(y = t.wlinky)) {
          x = t.elinkx;
          y = t.elinky;
        }
        Track* lnk = findTrack(x, y);
        if(!lnk) {
          wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("{%d,%d} - not found"), x, y);
          result._op = Number;
          result._val = 0;
          return false;
        }
        if(lnk.type == TSIGNAL) {
          result._signal = (Signal*)lnk;
          result._op = SignalRef;
        } else {
          result._track = lnk;
          result._op = TrackRef;
        }
        return true;
      }

      result._op = Number;
      result._val = 0;
      return false;
    }

    bool SetPropertyValue(string prop, out ExprValue val) {
      if("thrown".equals(prop)) {
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
        if(type != SWITCH)
          return false;
        switched = val._val != 0;
        change_coord(this.x, this.y);
        repaint_all();
        return true;
      }
      if("click".equals(prop)) {
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
        track_selected(this.x, this.y);
        return true;
      }
      if("color".equals(prop)) {
        wxSnprintf(expr_buff + wxStrlen(expr_buff), sizeof(expr_buff) / sizeof(wxChar) - wxStrlen(expr_buff), wxPorting.T("=%d"), val._val);
        grcolor col = conf.fgcolor;
        if(wxStrcmp(val._txt, wxPorting.T("blue")) == 0)
          col = color_blue;
        else if(wxStrcmp(val._txt, wxPorting.T("white")) == 0)
          col = color_white;
        else if(wxStrcmp(val._txt, wxPorting.T("red")) == 0)
          col = color_red;
        else if(wxStrcmp(val._txt, wxPorting.T("green")) == 0)
          col = color_green;
        else if(wxStrcmp(val._txt, wxPorting.T("orange")) == 0)
          col = color_orange;
        else if(wxStrcmp(val._txt, wxPorting.T("black")) == 0)
          col = color_black;
        else if(wxStrcmp(val._txt, wxPorting.T("cyan")) == 0)
          col = color_cyan;
        SetColor(col);
        return true;
      }
      if("icon".equals(prop)) {
        if(this.type == IMAGE) {
          if(this.station)
            free(this.station);
          this.station = wxStrdup(val._txt);
          change_coord(this.x, this.y);
          repaint_all();
        }
      }

      return false;
    }

    void OnInit() {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onInit)
        return;
      interp._track = this;
      interp._train = 0;
      interp._signal = 0;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnInit"));
      Trace(expr_buff);
      interp.Execute(interp._onInit);
      return;
    }
#endif

    void OnSetBusy() {
      TrackInterpreterData interp = (TrackInterpreterData)_interpreterData;
      if(interp != null)
        return;
      if(interp._onSetBusy != null)
        return;
      interp._track = this;
      interp._train = null;
      interp._signal = null;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnSetBusy"));
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onSetBusy);
    }

    void OnSetFree() {
      TrackInterpreterData interp = (TrackInterpreterData)_interpreterData;
      if(interp != null)
        return;
      if(interp._onSetFree != null)
        return;
      interp._track = this;
      interp._train = null;
      interp._signal = null;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnSetFree"));
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onSetFree);
      return;
    }
#if false
    void OnEnter(Train* trn) {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onEnter)
        return;
      interp._track = this;
      interp._train = trn;
      interp._stackPtr = 0;
      interp._signal = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnEnter"));
      Trace(expr_buff);
      interp.Execute(interp._onEnter);
      return;
    }
#endif
    public void OnExit(Train trn) {
      TrackInterpreterData interp = (TrackInterpreterData)_interpreterData;
      if(interp == null)
        return;
      if(interp._onExit == null)
        return;
      interp._track = this;
      interp._train = trn;
      interp._stackPtr = 0;
      interp._signal = null;
      interp.TraceCoord(x, y, wxPorting.T("OnExit"));
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onExit);
      return;
    }
#if false
    void OnClicked() {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onClicked)
        return;
      interp._track = this;
      interp._train = 0;
      interp._signal = 0;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnClicked"));
      Trace(expr_buff);
      interp.Execute(interp._onClicked);
      return;
    }

    void OnCanceled() {
      if(this.type != ITIN)
        return;
      if(_interpreterData) {
        TrackInterpreterData & interp = *(TrackInterpreterData*)_interpreterData;
        if(interp._onCanceled) {
          interp._track = this;
          Itinerary* it;
          for(it = itineraries; it; it = it.next)
            if(!wxStrcmp(it.name, this.station)) {
              interp._itinerary = it;
              break;
            }
          wxSnprintf(expr_buff, sizeof(expr_buff) / sizeof(wxChar), wxPorting.T("OnCanceled(%s)"), this.station);
          Trace(expr_buff);
          interp.Execute(interp._onCanceled);
          return;
        }
      }
    }

    void OnCrossed(Train* trn) {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onCrossed)
        return;
      interp._track = this;
      interp._train = trn;
      interp._signal = 0;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnCrossed"));
      Trace(expr_buff);
      interp.Execute(interp._onCrossed);
      return;
    }

    void OnArrived(Train* trn) {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onArrived)
        return;
      interp._track = this;
      interp._train = trn;
      interp._signal = 0;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnArrived"));
      Trace(expr_buff);
      interp.Execute(interp._onArrived);
      return;
    }

    void OnStopped(Train* trn) {
      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      if(!interp)
        return;
      if(!interp._onStopped)
        return;
      interp._track = this;
      interp._train = trn;
      interp._signal = 0;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnStopped"));
      Trace(expr_buff);
      interp.Execute(interp._onStopped);
      return;
    }
#endif

    public void OnIconUpdate() {
      TrackInterpreterData interp = (TrackInterpreterData)_interpreterData;
      if(interp != null)
        return;
      if(interp._onIconUpdate != null)
        return;
      interp._track = this;
      interp._train = null;
      interp._signal = null;
      interp._stackPtr = 0;
      interp.TraceCoord(x, y, wxPorting.T("OnIconUpdate"));
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onIconUpdate);
      return;
    }
#if false
    void ParseProgram() {
      string p;

      if(!this.stateProgram)
        return;
      /// TODO
      //if(_interpreterData)	    // previous script
      //    delete _interpreterData;
      _interpreterData = new TrackInterpreterData();

      TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      p = this.stateProgram;
      while(*p) {
        const wxChar* p1 = p;
        while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
          ++p1;
        p = p1;
        if(match(&p, wxPorting.T("OnInit:"))) {
          p1 = p;
          interp._onInit = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnSetBusy:"))) {
          p = next_token(p);
          p1 = p;
          interp._onSetBusy = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnSetFree:"))) {
          p = next_token(p);
          p1 = p;
          interp._onSetFree = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnEnter:"))) {
          p = next_token(p);
          p1 = p;
          interp._onEnter = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnCrossed:"))) {
          p = next_token(p);
          p1 = p;
          interp._onCrossed = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnArrived:"))) {
          p = next_token(p);
          p1 = p;
          interp._onArrived = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnStopped:"))) {
          p = next_token(p);
          p1 = p;
          interp._onStopped = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnExit:"))) {
          p = next_token(p);
          p1 = p;
          interp._onExit = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnClicked:"))) {
          p = next_token(p);
          p1 = p;
          interp._onClicked = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnIconUpdate:"))) {
          p = next_token(p);
          p1 = p;
          interp._onIconUpdate = ParseStatements(&p);
        } else if(match(&p, wxPorting.T("OnCanceled:"))) {
          p = next_token(p);
          p1 = p;
          interp._onCanceled = ParseStatements(&p);
        }
        if(p1 == p)	    // error! couldn't parse token
          break;
      }
    }

    void RunScript(string script, Train trn) {
      Script s = find_script(script);
      if(!s) {
        s = new_script(script);
        // return;
      }
      if(!s.ReadFile())
        return;

      // is it different from current one?
      if(!this.stateProgram || wxStrcmp(s._text, this.stateProgram)) {
        if(this.stateProgram)
          free(this.stateProgram);
        this.stateProgram = wxStrdup(s._text);
        ParseProgram();
      }
      OnEnter(trn);
    }

    bool IsBusy() {
      if(this.fgcolor != conf.fgcolor)
        return true;
      return false;
    }
#endif
    public void SetColor(grcolor color) {
      if(this.fgcolor == color)
        return;
      this.fgcolor = color;
      GlobalFunctions.change_coord(this.x, this.y);
      if(color == GlobalVariables.conf.fgcolor)
        OnSetFree();
      else
        OnSetBusy();
    }

  }
}