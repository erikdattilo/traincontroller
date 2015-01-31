/*	Track.cpp - Created by Giampiero Caprino

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
using wx;

namespace Traincontroller2 {


  public partial class Globals {
    public static int terse_status;


    public static grcolor[] fieldcolors = new grcolor[(int)fieldcolor.MAXFIELDCOL];

    public static bool draw_train_names = false;
    public static int no_train_names_colors = 0;
    public static int auto_link = 1;
    public static int link_to_left = 0;
    public static int show_links = 1;
    public static int show_scripts = 0;
    public static Coord link_start;
    public static Coord move_start, move_end;
    public static int current_macro = -1;
    public static String current_macro_name;
    public static Track macros;
    public static int nmacros, maxmacros;
    public static Array<Track> onIconUpdateListeners;

    public static VLines[] n_s_layout = new VLines[]{
	new VLines(Configuration.HGRID / 2 + 1, 0, Configuration.HGRID / 2 + 1, Configuration.VGRID - 1 ),
	new VLines(Configuration.HGRID / 2 - 0, 0, Configuration.HGRID / 2 - 0, Configuration.VGRID - 1 ),
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

    public static VLines[] switch_rect = new VLines[] {
	new VLines( 0, 0, Configuration.HGRID - 1, 0 ),
	new VLines( Configuration.HGRID - 1, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, 0, 0, Configuration.VGRID - 1 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( -1 )
};

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

    public static VLines[] itin_layout = new VLines[] {
	new VLines( 0, 0, Configuration.HGRID - 1, Configuration.VGRID - 1 ),
	new VLines( 0, Configuration.VGRID / 2, Configuration.HGRID - 1, Configuration.VGRID / 2 ),
	new VLines( 0, Configuration.VGRID - 1, Configuration.HGRID - 1, 0 ),
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

    public static Image[] e_train_pmap_default = new Image[Config.NTTYPES];
    public static Image[] w_train_pmap_default = new Image[Config.NTTYPES];
    public static Image[] e_car_pmap_default = new Image[Config.NTTYPES];
    public static Image[] w_car_pmap_default = new Image[Config.NTTYPES];

    public static Image[] e_train_pmap = new Image[Config.NTTYPES];
    public static String[] e_train_xpm = new String[] {
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

    public static Image[] w_train_pmap = new Image[Config.NTTYPES];
    public static String[] w_train_xpm = new String[] {
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

    public static Image[] w_car_pmap = new Image[Config.NTTYPES];
    public static Image[] e_car_pmap = new Image[Config.NTTYPES];
    public static String[] car_xpm = new String[] {	/* same for both e and w */
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

    public static Image speed_pmap;
    public static String[] speed_xpm = new String[] {
"8 3 3 1",
"       c #FFFFFFFFFFFF",
".      c #000000000000",
"X      c #000000000000",
"  ....  ",
" ..  .. ",
"  ....  "};

    public static Image camera_pmap;
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

    public static Image itin_pmap;
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


    public static String[] ttypecolors = new String[Config.NTTYPES]{
	"orange", "cyan", "blue", "yellow",
	"white", "red", "brown", "green",
        "magenta", "lightgray"
};


    /*
     *	Tools-types pixmaps
     *	(created from xpms defined in the i*.h files)
     */

    public static wx.Image tracks_pixmap, switches_pixmap, signals_pixmap,
      tools_pixmap, actions_pixmap,
      move_start_pixmap, move_end_pixmap, move_dest_pixmap,
            set_power_pixmap;

    static string buff;

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

      //Signal.InitPixmaps();

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

    public static void free_pixmaps() {
      //int i;

      //for(i = 0; i < 4; ++i) {
      //  delete_pixmap(e_train_pmap[i]);
      //  delete_pixmap(w_train_pmap[i]);
      //  delete_pixmap(e_car_pmap[i]);
      //  delete_pixmap(w_car_pmap[i]);
      //}

      //Signal.FreePixmaps();
      //delete_pixmap(tracks_pixmap);
      //delete_pixmap(switches_pixmap);
      //delete_pixmap(signals_pixmap);
      //delete_pixmap(tools_pixmap);
      //delete_pixmap(actions_pixmap);
      //delete_pixmap(move_start_pixmap);
      //delete_pixmap(move_end_pixmap);
      //delete_pixmap(move_dest_pixmap);
      //delete_pixmap(set_power_pixmap);
      //delete_pixmap(speed_pmap);
    }

    public static Track track_new() {
      throw new NotImplementedException();
      //Track t;

      ////	t = (Track *)malloc(sizeof(Track));
      ////	memset(t, 0, sizeof(Track));
      //t = new Track();
      //t.xsize = 1;
      //t.ysize = 1;
      //t.type = NOTRACK;
      //t.direction = NODIR;
      //t.fgcolor = fieldcolors[COL_TRACK];
      //return (t);
    }

    public static void track_delete(Track t) {
      //Track t1, old;

      //if(t == layout)
      //  layout = t.next;
      //else {
      //  old = layout;
      //  for(t1 = old.next; t1 != t; t1 = t1.next)
      //    old = t1;
      //  old.next = t.next;
      //}
      //if(t.station)
      //  Globals.free(t.station);
      //delete_script_data(t);
      //onIconUpdateListeners.Remove(t);
      ////Globals.free(t);
      //Globals.delete(t);
      //link_all_tracks();
    }

    public static void track_name(Track t, String name) {
      //if(t.station)
      //  Globals.free(t.station);
      //t.station = wxStrdup(name);
    }

    public static int translate_track_color(Track t) {
      throw new NotImplementedException();
      //int fg = curSkin.free_track;

      //switch(t.status) {
      //  case ST_FREE:
      //    break;
      //  case ST_BUSY:
      //    //		fg = color_red;
      //    return curSkin.occupied_track;
      //  case ST_READY:
      //    //		fg = color_green;
      //    return curSkin.reserved_track;
      //  case ST_WORK:
      //    //		fg = color_blue;
      //    return curSkin.working_track;
      //}
      //if(t.fgcolor == color_orange || t.fgcolor == color_red)
      //  return curSkin.occupied_track;
      //if(t.fgcolor == color_green)
      //  return curSkin.reserved_track;
      //if(t.fgcolor == color_white)
      //  return curSkin.reserved_shunting;
      //if(t.fgcolor == color_blue)
      //  return curSkin.working_track;
      //return fg;
    }


    public static void track_draw(Track t) {
      //int fg;
      //int tot;
      //VLines* lns = n_s_layout;	// provide dummy initialization - always overwritten

      //fg = translate_track_color(t);
      //switch(t.direction) {

      //  case TRK_N_S:
      //    if(t.power) {
      //      draw_mid_point(t.x, t.y, -2, 0, fg);
      //    }
      //    lns = n_s_layout;
      //    break;

      //  case SW_N:
      //    lns = sw_n_layout;
      //    break;

      //  case NW_S:
      //    lns = nw_s_layout;
      //    break;

      //  case W_E:
      //    if(t.power) {
      //      draw_mid_point(t.x, t.y, 0, -2, fg);
      //    }
      //    lns = w_e_layout;
      //    break;

      //  case NW_E:
      //    lns = nw_e_layout;
      //    break;

      //  case SW_E:
      //    lns = sw_e_layout;
      //    break;

      //  case W_NE:
      //    lns = w_ne_layout;
      //    break;

      //  case W_SE:
      //    lns = w_se_layout;
      //    break;

      //  case NW_SE:
      //    if(t.power) {
      //      draw_mid_point(t.x, t.y, 2, -2, fg);
      //    }
      //    lns = nw_se_layout;
      //    break;

      //  case SW_NE:
      //    if(t.power) {
      //      draw_mid_point(t.x, t.y, -2, -2, fg);
      //    }
      //    lns = sw_ne_layout;
      //    break;

      //  case NE_S:
      //    lns = ne_s_layout;
      //    break;

      //  case SE_N:
      //    lns = se_n_layout;
      //    break;

      //  case XH_NW_SE:
      //    fg = t.direction;
      //    t.direction = NW_SE;
      //    track_draw(t);
      //    t.direction = W_E;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;

      //  case XH_SW_NE:
      //    fg = t.direction;
      //    t.direction = SW_NE;
      //    track_draw(t);
      //    t.direction = W_E;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;

      //  case X_X:
      //    fg = t.direction;
      //    t.direction = SW_NE;
      //    track_draw(t);
      //    t.direction = NW_SE;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;

      //  case X_PLUS:
      //    fg = t.direction;
      //    t.direction = TRK_N_S;
      //    track_draw(t);
      //    t.direction = W_E;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;

      //  case N_NE_S_SW:
      //    fg = t.direction;
      //    t.direction = TRK_N_S;
      //    track_draw(t);
      //    t.direction = SW_NE;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;

      //  case N_NW_S_SE:
      //    fg = t.direction;
      //    t.direction = TRK_N_S;
      //    track_draw(t);
      //    t.direction = NW_SE;
      //    track_draw(t);
      //    t.direction = (trkdir)fg;
      //    return;
      //}
      //draw_layout(t.x, t.y, lns, fg);
      //if(show_blocks && t.direction == W_E && t.length >= 100)
      //  draw_layout(t.x, t.y, block_layout, curSkin.outline); //fieldcolors[TRACK]);
      //if(show_blocks && t.direction == TRK_N_S && t.length >= 100)
      //  draw_layout(t.x, t.y, block_layout_ns, curSkin.outline); //fieldcolors[TRACK]);
      //if(show_blocks && t.station)
      //  draw_layout(t.x, t.y, station_block_layout, curSkin.outline); //fieldcolors[TRACK]);
      //if(editing && show_links) {
      //  if(t.wlinkx && t.wlinky)
      //    draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor2);
      //  if(t.elinkx && t.elinky)
      //    draw_link(t.x, t.y, t.elinkx, t.elinky, conf.linkcolor2);
      //}
      //if(!show_speeds)
      //  return;
      //tot = 0;
      //for(fg = 0; fg < Config.NTTYPES; ++fg)
      //  tot += t.speed[fg];
      //if(tot)
      //  draw_pixmap(t.x, t.y, speed_pmap);
    }

    public static void switch_draw(Track t) {
      //int fg;
      //int tmp;

      //fg = translate_track_color(t);
      //tmp = t.direction;
      //switch(tmp) {
      //  case 0:
      //    if(editing) {
      //      t.direction = W_NE;
      //      track_draw(t);
      //      t.direction = W_E;
      //      track_draw(t);
      //    } else if(t.switched) {
      //      t.direction = W_NE;
      //      track_draw(t);
      //    } else
      //      t.direction = W_E;
      //    track_draw(t);
      //    break;

      //  case 1:
      //    if(editing) {
      //      t.direction = NW_E;
      //      track_draw(t);
      //      t.direction = W_E;
      //      track_draw(t);
      //    } else if(t.switched) {
      //      t.direction = NW_E;
      //      track_draw(t);
      //    } else
      //      t.direction = W_E;
      //    track_draw(t);
      //    break;

      //  case 2:
      //    if(editing) {
      //      t.direction = W_SE;
      //      track_draw(t);
      //      t.direction = W_E;
      //      track_draw(t);
      //    } else if(t.switched) {
      //      t.direction = W_SE;
      //      track_draw(t);
      //    } else
      //      t.direction = W_E;
      //    track_draw(t);
      //    break;

      //  case 3:
      //    if(editing) {
      //      t.direction = SW_E;
      //      track_draw(t);
      //      t.direction = W_E;
      //      track_draw(t);
      //    } else if(t.switched) {
      //      t.direction = SW_E;
      //      track_draw(t);
      //    } else
      //      t.direction = W_E;
      //    track_draw(t);
      //    break;

      //  case 4:
      //    if(editing) {
      //      t.direction = SW_E;
      //      track_draw(t);
      //      t.direction = SW_NE;
      //    } else if(t.switched)
      //      t.direction = SW_E;
      //    else
      //      t.direction = SW_NE;
      //    track_draw(t);
      //    break;

      //  case 5:
      //    if(editing) {
      //      t.direction = W_NE;
      //      track_draw(t);
      //      t.direction = SW_NE;
      //    } else if(t.switched)
      //      t.direction = W_NE;
      //    else
      //      t.direction = SW_NE;
      //    track_draw(t);
      //    break;

      //  case 6:
      //    if(editing) {
      //      t.direction = NW_E;
      //      track_draw(t);
      //      t.direction = NW_SE;
      //    } else if(t.switched) {
      //      t.direction = NW_E;
      //    } else
      //      t.direction = NW_SE;
      //    track_draw(t);
      //    break;

      //  case 7:
      //    if(editing) {
      //      t.direction = W_SE;
      //      track_draw(t);
      //      t.direction = NW_SE;
      //    } else if(t.switched)
      //      t.direction = W_SE;
      //    else
      //      t.direction = NW_SE;
      //    track_draw(t);
      //    break;

      //  case 8:				/* horizontal english switch */
      //    if(t.switched && !editing)
      //      draw_layout(t.x, t.y, sweng_sw_ne_switched, fg);
      //    else
      //      draw_layout(t.x, t.y, sweng_sw_ne_straight, fg);
      //    break;

      //  case 9:				/* horizontal english switch */
      //    if(t.switched && !editing)
      //      draw_layout(t.x, t.y, sweng_nw_se_switched, fg);
      //    else
      //      draw_layout(t.x, t.y, sweng_nw_se_straight, fg);
      //    break;

      //  case 10:
      //    if(editing) {
      //      t.direction = W_SE;
      //      track_draw(t);
      //      t.direction = W_NE;
      //    } else if(t.switched)
      //      t.direction = W_SE;
      //    else
      //      t.direction = W_NE;
      //    track_draw(t);
      //    break;

      //  case 11:
      //    if(editing) {
      //      t.direction = SW_E;
      //      track_draw(t);
      //      t.direction = NW_E;
      //    } else if(t.switched)
      //      t.direction = SW_E;
      //    else
      //      t.direction = NW_E;
      //    track_draw(t);
      //    break;

      //  case 12:
      //    if(editing) {
      //      t.direction = TRK_N_S;
      //      track_draw(t);
      //      t.direction = SW_N;
      //    } else if(t.switched)
      //      t.direction = SW_N;
      //    else
      //      t.direction = TRK_N_S;
      //    track_draw(t);
      //    break;

      //  case 13:
      //    if(editing) {
      //      t.direction = TRK_N_S;
      //      track_draw(t);
      //      t.direction = SE_N;
      //    } else if(t.switched)
      //      t.direction = SE_N;
      //    else
      //      t.direction = TRK_N_S;
      //    track_draw(t);
      //    break;

      //  case 14:
      //    if(editing) {
      //      t.direction = TRK_N_S;
      //      track_draw(t);
      //      t.direction = NW_S;
      //    } else if(t.switched)
      //      t.direction = NW_S;
      //    else
      //      t.direction = TRK_N_S;
      //    track_draw(t);
      //    break;

      //  case 15:
      //    if(editing) {
      //      t.direction = TRK_N_S;
      //      track_draw(t);
      //      t.direction = NE_S;
      //    } else if(t.switched)
      //      t.direction = NE_S;
      //    else
      //      t.direction = TRK_N_S;
      //    track_draw(t);
      //    break;

      //  case 16:			/* vertical english switch */
      //    if(t.switched && !editing)
      //      draw_layout(t.x, t.y, swengv_sw_ne_switched, fg);
      //    else
      //      draw_layout(t.x, t.y, swengv_sw_ne_straight, fg);
      //    break;

      //  case 17:			/* vertical english switch */
      //    if(t.switched && !editing)
      //      draw_layout(t.x, t.y, swengv_nw_se_switched, fg);
      //    else
      //      draw_layout(t.x, t.y, swengv_nw_se_straight, fg);
      //    break;

      //  case 18:
      //    if(editing) {
      //      t.direction = SW_NE;
      //      track_draw(t);
      //      t.direction = SW_N;
      //    } else if(t.switched)
      //      t.direction = SW_N;
      //    else
      //      t.direction = SW_NE;
      //    track_draw(t);
      //    break;

      //  case 19:
      //    if(editing) {
      //      t.direction = SW_NE;
      //      track_draw(t);
      //      t.direction = NE_S;
      //    } else if(t.switched)
      //      t.direction = NE_S;
      //    else
      //      t.direction = SW_NE;
      //    track_draw(t);
      //    break;

      //  case 20:
      //    if(editing) {
      //      t.direction = NW_SE;
      //      track_draw(t);
      //      t.direction = SE_N;
      //    } else if(t.switched)
      //      t.direction = SE_N;
      //    else
      //      t.direction = NW_SE;
      //    track_draw(t);
      //    break;

      //  case 21:
      //    if(editing) {
      //      t.direction = NW_SE;
      //      track_draw(t);
      //      t.direction = NW_S;
      //    } else if(t.switched)
      //      t.direction = NW_S;
      //    else
      //      t.direction = NW_SE;
      //    track_draw(t);
      //    break;

      //  case 22:
      //    if(editing) {
      //      t.direction = NW_S;
      //      track_draw(t);
      //      t.direction = NE_S;
      //    } else if(t.switched)
      //      t.direction = NW_S;
      //    else
      //      t.direction = NE_S;
      //    track_draw(t);
      //    break;

      //  case 23:
      //    if(editing) {
      //      t.direction = SW_N;
      //      track_draw(t);
      //      t.direction = SE_N;
      //    } else if(t.switched)
      //      t.direction = SW_N;
      //    else
      //      t.direction = SE_N;
      //    track_draw(t);
      //    break;
      //}
      //if(!t.norect)
      //  draw_layout(t.x, t.y, switch_rect, curSkin.outline); //fieldcolors[TRACK]);
      //t.direction = (trkdir)tmp;
    }

    public static void platform_draw(Track t) {
      //switch(t.direction) {
      //  case W_E:
      //    draw_layout(t.x, t.y, w_e_platform_out, curSkin.free_track); //fieldcolors[TRACK]);
      //    draw_layout(t.x, t.y, w_e_platform_in, curSkin.outline);
      //    break;

      //  case N_S:
      //    draw_layout(t.x, t.y, n_s_platform_out, curSkin.free_track);//fieldcolors[TRACK]);
      //    draw_layout(t.x, t.y, n_s_platform_in, curSkin.outline);
      //    break;
      //}
    }

    public static void signal_draw(Track t) {
      Signal signal = (Signal)t;
      signal.Draw();
    }

    public static object get_train_pixels(Train trn) {
      throw new NotImplementedException();
      //object pixels;

      //if(swap_head_tail && (trn.flags & TFLG_SWAPHEADTAIL)) {
      //  if(trn.direction == W_E)
      //    pixels = trn.wpix == -1 ?
      //          w_train_pmap[trn.type] : pixmaps[trn.wpix].pixels;
      //  else
      //    pixels = trn.epix == -1 ?
      //          e_train_pmap[trn.type] : pixmaps[trn.epix].pixels;
      //} else {
      //  if(trn.direction == W_E)
      //    pixels = trn.epix == -1 ?
      //          e_train_pmap[trn.type] : pixmaps[trn.epix].pixels;
      //  else
      //    pixels = trn.wpix == -1 ?
      //          w_train_pmap[trn.type] : pixmaps[trn.wpix].pixels;
      //}
      //return pixels;
    }

    public static object get_car_pixels(Train trn) {
      throw new NotImplementedException();
      //object pixels;

      //if(swap_head_tail && (trn.flags & TFLG_SWAPHEADTAIL)) {
      //  if(trn.direction == W_E)
      //    pixels = trn.wcarpix == -1 || trn.wcarpix >= ncarpixmaps ?
      //          w_car_pmap[trn.type] : carpixmaps[trn.wcarpix].pixels;
      //  else
      //    pixels = trn.ecarpix == -1 || trn.ecarpix >= ncarpixmaps ?
      //          e_car_pmap[trn.type] : carpixmaps[trn.ecarpix].pixels;
      //} else {
      //  if(trn.direction == W_E)
      //    pixels = trn.ecarpix == -1 || trn.ecarpix >= ncarpixmaps ?
      //          e_car_pmap[trn.type] : carpixmaps[trn.ecarpix].pixels;
      //  else
      //    pixels = trn.wcarpix == -1 || trn.wcarpix >= ncarpixmaps ?
      //          w_car_pmap[trn.type] : carpixmaps[trn.wcarpix].pixels;
      //}
      //return pixels;
    }

    public static void get_basic_name(Train trn, string dest, int size) {
      //int i;

      //// isolate the main component of a train's name, usually the number
      //dest = String.Copy( trn.name);;
      //dest[size - 1] = 0;
      //for(i = 0; dest[i]; ++i)
      //  if(dest[i] == wxPorting.T(' '))
      //    break;
      //dest[i] = 0;
    }

    public static void train_draw(Track t, Train trn) {
      //object pixels;
      //string name;

      //if(!e_train_pmap[0]) {
      //  init_pmaps();
      //}
      //if(draw_train_names) {
      //  get_basic_name(trn, name, name.Length);
      //  if(no_train_names_colors)
      //    draw_text_with_background(t.x, t.y, name, 0, color_green);
      //  else
      //    draw_text_with_background(t.x, t.y, name, 0, fieldcolors[COL_TRAIN1 + trn.type]);
      //  return;
      //}
      //pixels = get_train_pixels(trn);
      //if(swap_head_tail && (trn.flags & TFLG_SWAPHEADTAIL) && trn.length &&
      //    trn.tail && trn.position && trn.position != trn.tail.position)
      //  pixels = get_car_pixels(trn);
      //draw_pixmap(t.x, t.y, pixels);
    }

    public static void car_draw(Track t, Train trn) {
      //object pixels;
      //string name;

      //if(!e_car_pmap[0]) {
      //  init_pmaps();
      //}
      //if(draw_train_names) {
      //  get_basic_name(trn, name, name.Length);
      //  if(no_train_names_colors)
      //    draw_text_with_background(t.x, t.y, name, 0, color_green);
      //  else
      //    draw_text_with_background(t.x, t.y, name, 0, fieldcolors[COL_TRAIN1 + trn.type]);
      //  return;
      //}
      //pixels = get_car_pixels(trn);
      //if(swap_head_tail && (trn.flags & TFLG_SWAPHEADTAIL))
      //  pixels = get_train_pixels(trn);
      //draw_pixmap(t.x, t.y, pixels);
    }

    public static void text_draw(Track t) {
      //if(!t.station)
      //  return;
      //tr_fillrect(t.x, t.y);
      //if(t._fontIndex)
      //  draw_layout_text_font(t.x, t.y, t.station, t._fontIndex);
      //else
      //  draw_layout_text1(t.x, t.y, t.station, t.direction);
      //if(!editing || !show_links)
      //  return;
      //if(t.elinkx && t.elinky)
      //  draw_link(t.x, t.y, t.elinkx, t.elinky, conf.linkcolor);
      //else if(t.wlinkx && t.wlinky)
      //  draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
    }

    public static void link_draw(Track t) {
      //tr_fillrect(t.x, t.y);
      //if(t.direction == W_E)
      //  draw_layout_text1(t.x, t.y, wxPorting.T("...to..."), 1);
      //else
      //  draw_layout_text1(t.x, t.y, wxPorting.T("Link..."), 1);
    }

    public static void macro_draw(Track t) {
      //tr_fillrect(t.x, t.y);
      //if(t.direction == 0)
      //  draw_layout_text1(t.x, t.y, wxPorting.T("Macro"), 1);
      //else
      //  draw_layout_text1(t.x, t.y, wxPorting.T("Place"), 1);
    }

    public static void itin_draw(Track t) {
//      if(!itin_pmap)
//        itin_pmap = get_pixmap(itin_xpm);

//      tr_fillrect(t.x, t.y);
//      draw_pixmap(t.x, t.y, itin_pmap);

//      if(t.station) {
//#if false // !Rask Ingemann Lambertsen
//      draw_itin_text(t.x, t.y, t.station, t.direction == 1);
//#else
//        String label = wxStrrchr(t.station, '@');
//        if(label)
//          label++;
//        else
//          label = t.station;
//        draw_itin_text(t.x, t.y, label, t.direction == 1);
//#endif
//      }
    }

    public static void mover_draw() {
      draw_link(move_start.x, move_start.y, move_end.x, move_end.y, color_white);
    }

    public static void trigger_draw(Track t) {
      //VLines img;

      //switch(t.direction) {
      //  case S_N:
      //    img = ntrigger_layout;
      //    break;
      //  case N_S:
      //    img = strigger_layout;
      //    break;
      //  case W_E:
      //    img = etrigger_layout;
      //    break;
      //  case E_W:
      //    img = wtrigger_layout;
      //    break;
      //  default:
      //    return;
      //}

      //draw_layout(t.x, t.y, img, curSkin.working_track);
      //if(editing && show_links) {
      //  if(t.wlinkx && t.wlinky)
      //    draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
      //}
    }

    public static void image_draw(Track t) {
      //string buff;
      //String p;
      //object pixels = 0;
      //int ix;

      //if(!camera_pmap)
      //  camera_pmap = get_pixmap(camera_xpm);
      //if(t.direction || !t.station || !*t.station) {/* filename! */
      //  pixels = camera_pmap;
      //} else {
      //  if(t._isFlashing && t._flashingIcons[t._nextFlashingIcon])
      //    ix = get_pixmap_index(t._flashingIcons[t._nextFlashingIcon]);
      //  else
      //    ix = get_pixmap_index(t.station);
      //  if(ix < 0) {	    /* for UNIX, try lower case name */
      //    buff = String.Copy( t.station);
      //    for(p = buff; *p; p.incPointer())
      //      if(p[0] >= 'A' && p[0] <= 'Z')
      //        *p += ' ';
      //    ix = get_pixmap_index(buff);
      //  }
      //  if(ix < 0) {
      //    buff = String.Format( wxPorting.T("%s '%s'."), wxPorting.L("Error reading"), t.station);
      //    do_alert(buff);
      //    pixels = camera_pmap;
      //    if(t._isFlashing)
      //      t._flashingIcons[t._nextFlashingIcon] = 0;
      //    else
      //      t.station = 0;
      //  } else
      //    pixels = pixmaps[ix].pixels;
      //}
      //draw_pixmap(t.x, t.y, pixels);
      //if(editing && show_links && t.wlinkx && t.wlinky)
      //  draw_link(t.x, t.y, t.wlinkx, t.wlinky, conf.linkcolor);
    }

    public static void track_paint(Track t) {
      //tr_fillrect(t.x, t.y);
      //if(!editing && t.invisible)
      //  return;

      //switch(t.type) {
      //  case TRACK:
      //    track_draw(t);
      //    break;

      //  case SWITCH:
      //    switch_draw(t);
      //    break;

      //  case PLATFORM:
      //    platform_draw(t);
      //    break;

      //  case TSIGNAL:
      //    signal_draw(t);
      //    break;

      //  case TRAIN:		/* trains are handled differently */
      //    /*	train_draw(t); */
      //    break;

      //  case TEXT:
      //    text_draw(t);
      //    break;

      //  case LINK:
      //    link_draw(t);
      //    break;

      //  case IMAGE:
      //    image_draw(t);
      //    break;

      //  case MACRO:
      //    macro_draw(t);
      //    break;

      //  case ITIN:
      //    itin_draw(t);
      //    break;

      //  case TRIGGER:
      //    trigger_draw(t);
      //    break;

      //  default:
      //    return;
      //}
      //if(editing && show_scripts && t.stateProgram) {
      //  draw_layout(t.x, t.y, switch_rect, curSkin.working_track);//fieldcolors[COL_TRAIN2]);
      //}
    }

    public static string GetColorName(int color) {
      throw new NotImplementedException();
      //if(color == conf.fgcolor)
      //  return wxPorting.T("black");
      //if(color == color_white)
      //  return wxPorting.T("white");
      //if(color == color_orange)
      //  return wxPorting.T("orange");
      //if(color == color_green)
      //  return wxPorting.T("green");
      //if(color == color_red)
      //  return wxPorting.T("red");
      //if(color == color_blue)
      //  return wxPorting.T("blue");
      //if(color == color_cyan)
      //  return wxPorting.T("cyan");
      //return wxPorting.T("unknown");
    }

    // Erik: Static method var
    private static string train_next_stop___buff = "";
    public static String train_next_stop(Train t, out int final) {
      throw new NotImplementedException();
      //Track tr;
      //TrainStop ts, last;

      //*final = 0;
      //train_next_stop___buff[0] = 0;
      //train_next_stop___buff[1] = 0;
      //if(t.status != train_RUNNING && t.status != train_WAITING &&
      //    t.status != train_STOPPED)
      //  return train_next_stop___buff;
      //train_next_stop___buff[0] = 0;
      //last = 0;
      //for(ts = t.stops; ts; ts = ts.next) {
      //  if(!ts.minstop)
      //    continue;
      //  if(!(tr = findStationNamed(ts.station)) || tr.type != TRACK)
      //    continue;
      //  if(ts.stopped)
      //    continue;
      //  //	    if(!last || ts.arrival < last.arrival)
      //  last = ts;
      //  break;
      //}
      //if(!last) {
      //  tr = findStationNamed(t.exit);
      //  if(!tr || tr.type == TEXT)
      //    return train_next_stop___buff;
      //  *final = 1;
      //  train_next_stop___buff = String.Format( wxPorting.T(" %s %s %s %s   "), wxPorting.L("Final stop"), t.exit, wxPorting.L("at"), format_time(t.timeout));
      //} else
      //  train_next_stop___buff = String.Format( wxPorting.T(" %s %s %s %s   "), wxPorting.L("Next stop"), last.station, wxPorting.L("at"), format_time(last.arrival));
      //return train_next_stop___buff;
    }

    public static bool is_canceled(Train t) {
      throw new NotImplementedException();
      //if(!t.days || !run_day || (t.days & run_day))
      //  return false;
      //return true;
    }

    // Erik: Static method var
    private static string train_status0___buff = "";
    public static String train_status0(Train t, int full) {
      throw new NotImplementedException();
      //int i, j, k, final;

      //if(terse_status)
      //  full = 0;
      //train_status0___buff[0] = 0;
      //i = 0;
      //if(t.isExternal) {
      //  return wxPorting.L("external");
      //}
      //switch(t.status) {
      //  case train_READY:
      //    if(!is_canceled(t)) {
      //      if(!t.entryDelay || !t.entryDelay.nSeconds)
      //        return wxPorting.L("ready");
      //      train_status0___buff = String.Format(
      //    wxPorting.T("%s ETA %s"), wxPorting.L("ready"), format_time(t.timein + t.entryDelay.nSeconds));
      //      return train_status0___buff;
      //    }
      //    train_status0___buff = String.Format( wxPorting.T("%s "), wxPorting.L("Canceled - runs on"));
      //    k = Globals.wxStrlen(train_status0___buff);
      //    for(i = 1, j = '1'; i < 0x80; i <<= 1, ++j)
      //      if(t.days & i)
      //        train_status0___buff[k++] = j;
      //    train_status0___buff[k] = 0;
      //    return train_status0___buff;

      //  case train_RUNNING:
      //    if(full)
      //      train_status0___buff = String.Copy( train_next_stop(t));
      //    if(t.shunting)
      //      train_status0___buff + Globals.wxStrlen(train_status0___buff) = String.Copy( wxPorting.L("Shunting"));
      //    else if(full) {
      //      if(final)
      //        train_status0___buff + Globals.wxStrlen(train_status0___buff) = String.Format( wxPorting.T("%s: %d Km/h"), wxPorting.L("Speed"), (int)t.curspeed);
      //      else
      //        train_status0___buff + Globals.wxStrlen(train_status0___buff) = String.Format( wxPorting.T("%s: %d Km/h %s %s"), wxPorting.L("Speed"),
      //              (int)t.curspeed, wxPorting.L("to"), t.exit);
      //    } else
      //      train_status0___buff + Globals.wxStrlen(train_status0___buff) = String.Format( wxPorting.T("%s %s"), wxPorting.L("Running. Dest."), t.exit);
      //    return train_status0___buff;

      //  case train_STOPPED:
      //    if(full) {
      //      long timedep = t.timedep;
      //      TrainStop* stp = findStop(t, t.position);
      //      if(stp && stp.depDelay && stp.depDelay.nSeconds)
      //        timedep += stp.depDelay.nSeconds;
      //      else if(t.position.station &&
      //        sameStation(t.entrance, t.position.station) &&
      //        t.entryDelay)
      //        timedep += t.entryDelay.nSeconds;
      //      train_status0___buff = String.Format( wxPorting.T("%s %s "), wxPorting.L("Stopped. ETD"), format_time(timedep));
      //      if(full)
      //        wxStrcat(train_status0___buff, train_next_stop(t, &final));
      //      if(!final) {
      //        wxStrcat(train_status0___buff, wxPorting.L("Dest"));
      //        wxStrcat(train_status0___buff, wxPorting.T(" "));
      //        wxStrcat(train_status0___buff, t.exit);
      //      }
      //    } else {
      //      long timedep = t.timedep;
      //      TrainStop* stp = findStop(t, t.position);
      //      if(stp && stp.depDelay && stp.depDelay.nSeconds)
      //        timedep += stp.depDelay.nSeconds;
      //      else if(t.position.station &&
      //        sameStation(t.entrance, t.position.station) &&
      //        t.entryDelay)
      //        timedep += t.entryDelay.nSeconds;
      //      train_status0___buff = String.Format( wxPorting.T("%s %s  %s %s"), wxPorting.L("Stopped. ETD"), format_time(timedep),
      //        wxPorting.L("Dest."), t.exit);
      //    }
      //    return train_status0___buff;

      //  case train_DELAY:
      //    train_status0___buff = String.Format( wxPorting.T("%s %s"), wxPorting.L("Delayed entry at"), t.entrance);
      //    return train_status0___buff;

      //  case train_WAITING:
      //    train_status0___buff = String.Format( wxPorting.T("%s. %s%s %s"), wxPorting.L("Waiting"),
      //      full ? train_next_stop(t, &final) : wxPorting.T(""), wxPorting.L("Dest."), t.exit);
      //    return train_status0___buff;

      //  case train_DERAILED:
      //    return wxPorting.L("derailed");

      //  case train_STARTING:
      //    train_status0___buff = String.Format( wxPorting.T("%s (-%d)"), wxPorting.L("Starting"), t.startDelay);
      //    return train_status0___buff;

      //  case train_ARRIVED:
      //    if(t.wrongdest)
      //      train_status0___buff = String.Format( wxPorting.T("%s %s %s %s"), wxPorting.L("Arrived at"), t.exited, wxPorting.L("instead of"), t.exit);
      //    else if(t.timeexited / 60 > t.timeout / 60)
      //      train_status0___buff = String.Format( wxPorting.T("%s %d %s %s"), wxPorting.L("Arrived"),
      //    (t.timeexited - t.timeout) / 60, wxPorting.L("min. late at"), t.exit);
      //    else
      //      train_status0___buff = String.Format( wxPorting.L("Arrived on time"));
      //    if(t.stock)
      //      train_status0___buff + Globals.wxStrlen(train_status0___buff) = String.Format( wxPorting.T(" - %s %s"), wxPorting.L("stock for"), t.stock);
      //    return train_status0___buff;
      //}
      //return wxPorting.T("");
    }

    public static String train_status(Train t) {
      return train_status0(t, 0);
    }

    public static void walk_vertical(Track trk, Track t, trkdir ndir) {
      //if(*ndir == N_S) {
      //  if(t.elinkx && t.elinky) {
      //    trk.x = t.elinkx;
      //    trk.y = t.elinky;
      //    return;
      //  }
      //  trk.x = t.x;
      //  trk.y = t.y + 1;
      //  return;
      //}
      //if(t.wlinkx && t.wlinky) {
      //  trk.x = t.wlinkx;
      //  trk.y = t.wlinky;
      //  return;
      //}
      //trk.x = t.x;
      //trk.y = t.y - 1;
    }

    public static void walk_vertical_switch(Track trk, Track t, trkdir ndir) {
      //switch(t.direction) {
      //  case 12:
      //    if(*ndir == W_E)
      //      *ndir = S_N;
      //    if(*ndir == S_N) {
      //      trk.x = t.x;
      //      trk.y = t.y - 1;
      //    } else if(t.switched) {
      //      trk.x = t.x - 1;
      //      trk.y = t.y + 1;
      //      *ndir = E_W;
      //    } else {
      //      trk.x = t.x;
      //      trk.y = t.y + 1;
      //    }
      //    break;

      //  case 13:
      //    if(*ndir == E_W)
      //      *ndir = S_N;
      //    if(*ndir == S_N) {
      //      trk.x = t.x;
      //      trk.y = t.y - 1;
      //    } else if(t.switched) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y + 1;
      //      *ndir = W_E;
      //    } else {
      //      trk.x = t.x;
      //      trk.y = t.y + 1;
      //    }
      //    break;

      //  case 14:
      //    if(*ndir == W_E)
      //      *ndir = N_S;
      //    if(*ndir == N_S) {
      //      trk.x = t.x;
      //      trk.y = t.y + 1;
      //    } else if(t.switched) {
      //      trk.x = t.x - 1;
      //      trk.y = t.y - 1;
      //      *ndir = E_W;
      //    } else {
      //      trk.x = t.x;
      //      trk.y = t.y - 1;
      //    }
      //    break;

      //  case 15:
      //    if(*ndir == E_W)
      //      *ndir = N_S;
      //    if(*ndir == N_S) {
      //      trk.x = t.x;
      //      trk.y = t.y + 1;
      //    } else if(t.switched) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y - 1;
      //      *ndir = W_E;
      //    } else {
      //      trk.x = t.x;
      //      trk.y = t.y - 1;
      //    }
      //    break;

      //  case 18:
      //    if(t.switched) {
      //      if(*ndir == W_E)
      //        *ndir = S_N;
      //      if(*ndir == S_N) {
      //        trk.x = t.x;
      //        trk.y = t.y - 1;
      //      } else {
      //        trk.x = t.x - 1;
      //        trk.y = t.y + 1;
      //        *ndir = E_W;
      //      }
      //      break;
      //    }
      //    if(*ndir == W_E) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y - 1;
      //    } else {
      //      trk.x = t.x - 1;
      //      trk.y = t.y + 1;
      //    }
      //    break;

      //  case 19:
      //    if(t.switched) {
      //      if(*ndir == E_W)
      //        *ndir = N_S;
      //      if(*ndir == S_N) {
      //        trk.x = t.x + 1;
      //        trk.y = t.y - 1;
      //        *ndir = W_E;
      //      } else {
      //        trk.x = t.x;
      //        trk.y = t.y + 1;
      //      }
      //      break;
      //    }
      //    if(*ndir == W_E || *ndir == S_N) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y - 1;
      //    } else {
      //      trk.x = t.x - 1;
      //      trk.y = t.y + 1;
      //    }
      //    break;

      //  case 20:
      //    if(t.switched) {
      //      if(*ndir == E_W)
      //        *ndir = S_N;
      //      if(*ndir == N_S) {
      //        trk.x = t.x + 1;
      //        trk.y = t.y + 1;
      //        *ndir = W_E;
      //      } else {
      //        trk.x = t.x;
      //        trk.y = t.y - 1;
      //      }
      //      break;
      //    }
      //    if(*ndir == W_E) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y + 1;
      //    } else {
      //      trk.x = t.x - 1;
      //      trk.y = t.y - 1;
      //    }
      //    break;

      //  case 21:
      //    if(t.switched) {
      //      if(*ndir == W_E)
      //        *ndir = N_S;
      //      if(*ndir == S_N) {
      //        trk.x = t.x - 1;
      //        trk.y = t.y - 1;
      //        *ndir = E_W;
      //      } else {
      //        trk.x = t.x;
      //        trk.y = t.y + 1;
      //      }
      //      break;
      //    }
      //    if(*ndir == W_E) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y + 1;
      //    } else {
      //      trk.x = t.x - 1;
      //      trk.y = t.y - 1;
      //    }
      //    break;

      //  case 22:
      //    if(t.switched) {
      //      if(*ndir == S_N) {
      //        trk.x = t.x - 1;
      //        trk.y = t.y - 1;
      //        *ndir = E_W;
      //        break;
      //      }
      //    } else if(*ndir == S_N) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y - 1;
      //      *ndir = W_E;
      //      break;
      //    }
      //    trk.x = t.x;
      //    trk.y = t.y + 1;
      //    *ndir = N_S;
      //    break;

      //  case 23:
      //    if(t.switched) {
      //      if(*ndir == N_S) {
      //        trk.x = t.x - 1;
      //        trk.y = t.y + 1;
      //        *ndir = E_W;
      //        break;
      //      }
      //    } else if(*ndir == N_S) {
      //      trk.x = t.x + 1;
      //      trk.y = t.y + 1;
      //      *ndir = W_E;
      //      break;
      //    }
      //    trk.x = t.x;
      //    trk.y = t.y - 1;
      //    *ndir = S_N;
      //    break;
      //}
    }

    // Erik: Static method var
    private static Track track_walkeast___trk = new Track();
    public static Track track_walkeast(Track t, trkdir ndir) {
      throw new NotImplementedException();
      //if(t.direction != track_walkeast___trk_N_S && t.elinkx && t.elinky) {
      //  track_walkeast___trk.x = t.elinkx;
      //  track_walkeast___trk.y = t.elinky;
      //  return &track_walkeast___trk;
      //}
      //track_walkeast___trk.x = t.x + 1;
      //track_walkeast___trk.y = t.y;
      //switch(t.direction) {
      //  case NW_SE:
      //  case W_SE:
      //    ++track_walkeast___trk.y;
      //    break;
      //  case SW_NE:
      //  case W_NE:
      //    --track_walkeast___trk.y;
      //    break;
      //  case SW_N:
      //    if(*ndir == N_S) {
      //      track_walkeast___trk.x = t.x - 1;
      //      track_walkeast___trk.y = t.y + 1;
      //      *ndir = E_W;
      //      break;
      //    }
      //    track_walkeast___trk.y = t.y - 1;
      //    track_walkeast___trk.x = t.x;
      //    *ndir = S_N;
      //    break;
      //  case NW_S:
      //    if(*ndir == S_N) {
      //      *ndir = E_W;
      //      track_walkeast___trk.x = t.x - 1;
      //      track_walkeast___trk.y = t.y - 1;
      //      break;
      //    }
      //    track_walkeast___trk.x = t.x;
      //    track_walkeast___trk.y = t.y + 1;
      //    *ndir = N_S;
      //    break;
      //  case NE_S:
      //    if(*ndir == S_N) {
      //      *ndir = W_E;
      //      track_walkeast___trk.x = t.x + 1;
      //      track_walkeast___trk.y = t.y - 1;
      //      break;
      //    }
      //    track_walkeast___trk.x = t.x;
      //    track_walkeast___trk.y = t.y + 1;
      //    *ndir = N_S;
      //    break;

      //  case SE_N:
      //    if(*ndir == N_S) {
      //      track_walkeast___trk.x = t.x + 1;
      //      track_walkeast___trk.y = t.y + 1;
      //      *ndir = W_E;
      //      break;
      //    }
      //    track_walkeast___trk.y = t.y - 1;
      //    track_walkeast___trk.x = t.x;
      //    *ndir = S_N;
      //    break;

      //  case track_walkeast___trk_N_S:
      //    walk_vertical(&track_walkeast___trk, t, ndir);
      //    break;

      //  case X_X:
      //    break;

      //  default:
      //    *ndir = W_E;
      //}
      //return &track_walkeast___trk;
    }


    // Erik: Static method var
    private static Track track_walkwest___trk = new Track();
    public static Track track_walkwest(Track t, trkdir ndir) {
      throw new NotImplementedException();
      //if(t.direction != track_walkwest___track_walkwest___trk_N_S && t.wlinkx && t.wlinky) {
      //  track_walkwest___track_walkwest___trk.x = t.wlinkx;
      //  track_walkwest___track_walkwest___trk.y = t.wlinky;
      //  return &track_walkwest___track_walkwest___trk;
      //}
      //track_walkwest___track_walkwest___trk.x = t.x - 1;
      //track_walkwest___track_walkwest___trk.y = t.y;
      //switch(t.direction) {
      //  case SW_N:
      //    if(*ndir == N_S) {
      //      ++track_walkwest___track_walkwest___trk.y;
      //      *ndir = E_W;
      //      break;
      //    }
      //    *ndir = S_N;
      //  case SW_NE:
      //  case SW_E:
      //    ++track_walkwest___track_walkwest___trk.y;
      //    break;
      //  case NW_S:
      //    if(*ndir == N_S) {
      //      track_walkwest___track_walkwest___trk.x = t.x;
      //      track_walkwest___track_walkwest___trk.y = t.y + 1;
      //      break;
      //    }
      //    *ndir = E_W;
      //  case NW_SE:
      //  case NW_E:
      //    --track_walkwest___track_walkwest___trk.y;
      //    break;
      //  case NE_S:
      //    if(*ndir == S_N) {
      //      track_walkwest___track_walkwest___trk.x = t.x + 1;
      //      track_walkwest___track_walkwest___trk.y = t.y - 1;
      //      *ndir = W_E;
      //      break;
      //    }
      //    *ndir = N_S;
      //    track_walkwest___track_walkwest___trk.y = t.y + 1;
      //    track_walkwest___track_walkwest___trk.x = t.x;
      //    break;
      //  case SE_N:
      //    if(*ndir == N_S) {
      //      track_walkwest___track_walkwest___trk.x = t.x + 1;
      //      track_walkwest___track_walkwest___trk.y = t.y + 1;
      //      *ndir = W_E;
      //      break;
      //    }
      //    *ndir = S_N;
      //    track_walkwest___track_walkwest___trk.x = t.x;
      //    track_walkwest___track_walkwest___trk.y = t.y - 1;
      //    break;
      //  case track_walkwest___track_walkwest___trk_N_S:
      //    walk_vertical(&track_walkwest___track_walkwest___trk, t, ndir);
      //    break;

      //  case X_X:
      //    break;

      //  default:
      //    *ndir = E_W;
      //}
      //return &track_walkwest___track_walkwest___trk;
    }
    // Erik: Static method var
    private static Track swtch_walkeast___trk = new Track();
    public static Track swtch_walkeast(Track t, trkdir ndir) {
      throw new NotImplementedException();
      //swtch_walkeast___trk.x = t.x;
      //swtch_walkeast___trk.y = t.y;
      //switch(t.direction) {
      //  case 0:
      //    ++swtch_walkeast___trk.x;
      //    if(t.switched)
      //      --swtch_walkeast___trk.y;
      //    break;

      //  case 1:
      //  case 3:
      //  case 11:
      //    ++swtch_walkeast___trk.x;
      //    break;

      //  case 2:
      //    ++swtch_walkeast___trk.x;
      //    if(t.switched)
      //      ++swtch_walkeast___trk.y;
      //    break;

      //  case 4:
      //    ++swtch_walkeast___trk.x;
      //    if(!t.switched)
      //      --swtch_walkeast___trk.y;
      //    break;

      //  case 5:
      //    ++swtch_walkeast___trk.x;
      //    --swtch_walkeast___trk.y;
      //    break;

      //  case 6:
      //    ++swtch_walkeast___trk.x;
      //    if(!t.switched)
      //      ++swtch_walkeast___trk.y;
      //    break;

      //  case 7:
      //    ++swtch_walkeast___trk.x;
      //    ++swtch_walkeast___trk.y;
      //    break;

      //  case 8:		    /* These are special cases handled in findPath() */
      //  case 9:
      //  case 16:
      //  case 17:
      //    break;

      //  case 10:
      //    ++swtch_walkeast___trk.x;
      //    if(t.switched)
      //      ++swtch_walkeast___trk.y;
      //    else
      //      --swtch_walkeast___trk.y;
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
      //    walk_vertical_switch(&swtch_walkeast___trk, t, ndir);
      //    break;

      //}
      //return &swtch_walkeast___trk;
    }

    // Erik: Static method var
    private static Track swtch_walkwest___trk = new Track();
    public static Track swtch_walkwest(Track t, trkdir ndir) {
      throw new NotImplementedException();
      //swtch_walkwest___trk.x = t.x;
      //swtch_walkwest___trk.y = t.y;
      //switch(t.direction) {
      //  case 1:
      //    --swtch_walkwest___trk.x;
      //    if(t.switched)
      //      --swtch_walkwest___trk.y;
      //    break;

      //  case 0:
      //  case 2:
      //  case 10:
      //    --swtch_walkwest___trk.x;
      //    break;

      //  case 3:
      //    --swtch_walkwest___trk.x;
      //    if(t.switched)
      //      ++swtch_walkwest___trk.y;
      //    break;

      //  case 4:
      //    --swtch_walkwest___trk.x;
      //    ++swtch_walkwest___trk.y;
      //    break;

      //  case 5:
      //    --swtch_walkwest___trk.x;
      //    if(!t.switched)
      //      ++swtch_walkwest___trk.y;
      //    break;

      //  case 7:
      //    --swtch_walkwest___trk.x;
      //    if(!t.switched)
      //      --swtch_walkwest___trk.y;
      //    break;

      //  case 6:
      //    --swtch_walkwest___trk.x;
      //    --swtch_walkwest___trk.y;
      //    break;

      //  case 8:		    /* These are special cases handled in findPath() */
      //  case 9:
      //  case 16:
      //  case 17:
      //    break;

      //  case 11:
      //    --swtch_walkwest___trk.x;
      //    if(t.switched)
      //      ++swtch_walkwest___trk.y;
      //    else
      //      --swtch_walkwest___trk.y;
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
      //    walk_vertical_switch(&swtch_walkwest___trk, t, ndir);
      //}
      //return &swtch_walkwest___trk;
    }

    public static void check_layout_errors() {
      //Track t, t1;
      //string buff;
      //int firsttime = 1;

      //for(t = layout; t; t = t.next) {
      //  buff[0] = 0;
      //  if(t.type == TSIGNAL) {
      //    if(!t.controls)
      //      buff = String.Format( wxPorting.T("%s %d,%d %s.\n"), wxPorting.L("Signal at"), t.x, t.y, wxPorting.L("not linked to any track"));
      //    else switch(t.direction) {
      //        case E_W:
      //        case signal_WEST_FLEETED:
      //        case N_S:
      //          if(!t.controls.wsignal)
      //            buff = String.Format( wxPorting.T("%s %d,%d - %s %d,%d.\n"), wxPorting.L("Track at"),
      //              t.controls.x, t.controls.y,
      //              wxPorting.L("not controlled by signal at"), t.x, t.y);
      //          break;
      //        case W_E:
      //        case signal_EAST_FLEETED:
      //        case S_N:
      //          if(!t.controls.esignal)
      //            buff = String.Format( wxPorting.T("%s %d,%d - %s %d,%d.\n"), wxPorting.L("Track at"),
      //              t.controls.x, t.controls.y,
      //              wxPorting.L("not controlled by signal at"), t.x, t.y);
      //          break;
      //      }
      //  }
      //  if(t.type == TRACK || t.type == IMAGE) {
      //    if(t.wlinkx && t.wlinky) {
      //      if(!(t1 = findTrack(t.wlinkx, t.wlinky)))
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Track at"), t.x, t.y,
      //            wxPorting.L("linked to non-existant track at"), t.wlinkx, t.wlinky);
      //      else if(!findTrack(t1.elinkx, t1.elinky) &&
      //        !findTrack(t1.wlinkx, t1.wlinky))
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Track at"), t1.x, t1.y,
      //            wxPorting.L("not linked back to"), t.x, t.y);
      //    } else if(t.elinkx && t.elinky) {
      //      if(!(t1 = findTrack(t.elinkx, t.elinky)))
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Track at"), t.x, t.y,
      //            wxPorting.L("linked to non-existant track at"), t.elinkx, t.elinky);
      //      else if(!findTrack(t1.elinkx, t1.elinky) &&
      //        !findTrack(t1.wlinkx, t1.wlinky))
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Track at"), t1.x, t1.y,
      //            wxPorting.L("not linked back to"), t.x, t.y);
      //    }

      //  }
      //  if(t.type == SWITCH) {
      //    if(t.wlinkx && t.wlinky) {
      //      if(!(t1 = findSwitch(t.wlinkx, t.wlinky)))
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Switch at"), t.x, t.y,
      //            wxPorting.L("linked to non-existant switch at"), t.wlinkx, t.wlinky);
      //      else if(t1.wlinkx != t.x || t1.wlinky != t.y)
      //        buff = String.Format( wxPorting.T("%s %d,%d %s %d,%d.\n"),
      //            wxPorting.L("Switch at"), t1.x, t1.y,
      //            wxPorting.L("not linked back to switch at"), t.x, t.y);
      //    }
      //  }
      //  if(buff[0]) {
      //    if(firsttime)
      //      Globals.traindir.layout_error(wxPorting.L("Checking for errors in layout...\n"));
      //    firsttime = 0;
      //    Globals.traindir.layout_error(buff);
      //  }
      //}
      //Globals.traindir.end_layout_error();
    }

    public static void link_tracks(Track t, Track t1) {
//      switch(t.type) {
//        case TRACK:
//          if(t1.type != TRACK) {
//            Globals.traindir.Error(wxPorting.L("Only like tracks can be linked."));
//            return;
//          }
//          if(t1.direction != W_E && t1.direction != TRK_N_S) {
//            Globals.traindir.Error(wxPorting.L("Only horizontal or vertical tracks can be linked automatically.\nTo link other track types, use the track properties dialog."));
//            return;
//          }
//          /*
//              if(t.direction != t1.direction) {
//                  error(wxPorting.T("You can't link horizontal to vertical tracks."));
//                  return;
//              }
//          */
//          if(t.direction == TRK_N_S) {
//            if(!findTrack(t.x, t.y + 1)) {
//              t.elinkx = t1.x;
//              t.elinky = t1.y;
//            } else {
//              t.wlinkx = t1.x;
//              t.wlinky = t1.y;
//            }
//            if(!findTrack(t1.x, t1.y + 1)) {
//              t1.elinkx = t.x;
//              t1.elinky = t.y;
//            } else {
//              t1.wlinkx = t.x;
//              t1.wlinky = t.y;
//            }
//            break;
//          }
//          if(!findTrack(t.x + 1, t.y) &&
//            !findSwitch(t.x + 1, t.y)) {
//            t.elinkx = t1.x;
//            t.elinky = t1.y;
//          } else {
//            t.wlinkx = t1.x;
//            t.wlinky = t1.y;
//          }
//          if(!findTrack(t1.x - 1, t1.y) &&
//            !findSwitch(t1.x - 1, t1.y)) {
//            t1.wlinkx = t.x;
//            t1.wlinky = t.y;
//          } else {
//            t1.elinkx = t.x;
//            t1.elinky = t.y;
//          }
//          break;

//        case SWITCH:
//          if(t1.type != SWITCH) {
//            Globals.traindir.Error(wxPorting.L("Only like tracks can be linked."));
//            return;
//          }
//          t.wlinkx = t1.x;
//          t.wlinky = t1.y;
//          t1.wlinkx = t.x;
//          t1.wlinky = t.y;
//          break;

//        case TSIGNAL:
//          if(t1.type != TRACK) {
//            Globals.traindir.Error(wxPorting.L("Signals can only be linked to a track."));
//            return;
//          }
//          t.wlinkx = t1.x;
//          t.wlinky = t1.y;
//          t.controls = findTrack(t1.x, t1.y);
//          break;

//        case TRIGGER:
//          if(t1.type != TRACK) {
//            Globals.traindir.Error(wxPorting.L("Triggers can only be linked to a track."));
//            return;
//          }
//          t.wlinkx = t1.x;
//          t.wlinky = t1.y;
//          t.controls = findTrack(t1.x, t1.y);
//          break;

//        case IMAGE:
//          t.wlinkx = t1.x;
//          t.wlinky = t1.y;
//          t.controls = t1;  // t1 could be a signal or a switch
//          break;

//        case TEXT:
//          if(t1.type != TRACK) {
//            Globals.traindir.Error(wxPorting.L("Entry/Exit points can only be linked to a track."));
//            return;
//          }
//#if false
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
//          if(t1.x < t.x) {
//            t.wlinkx = t1.x;
//            t.wlinky = t1.y;
//          } else {
//            t.elinkx = t1.x;
//            t.elinky = t1.y;
//          }
//          break;
//      }
    }

    public static bool isInside(Coord upleft, Coord downright, int x, int y) {
      throw new NotImplementedException();
      if(x >= upleft.x && x <= downright.x &&
          y >= upleft.y && y <= downright.y)
        return true;
      return false;
    }

    //	Move all track elements in the rectangle
    //	comprised by (move_start,move_end) to
    //	the coordinarte x,y (upper-left corner)

    public static void move_layout0(int x, int y) {
      //Coord start, end;
      //int dx, dy;
      //Track t, t1;

      //if(move_end.x < move_start.x) {
      //  start.x = move_end.x;
      //  end.x = move_start.x;
      //} else {
      //  start.x = move_start.x;
      //  end.x = move_end.x;
      //}
      //if(move_end.y < move_start.y) {
      //  start.y = move_end.y;
      //  end.y = move_start.y;
      //} else {
      //  start.y = move_start.y;
      //  end.y = move_end.y;
      //}
      //dx = x - start.x;
      //dy = y - start.y;
      //for(t = layout; t; t = t.next) {
      //  x = t.x;
      //  y = t.y;
      //  if(isInside(start, end, x, y)) {
      //    if((t1 = find_track(layout, t.x + dx, t.y + dy)))
      //      track_delete(t1);
      //    t.x += dx;
      //    t.y += dy;
      //  }
      //  if(t.elinkx && t.elinky &&
      //isInside(start, end, t.elinkx, t.elinky)) {
      //    t.elinkx += dx;
      //    t.elinky += dy;
      //  }
      //  if(t.wlinkx && t.wlinky &&
      //isInside(start, end, t.wlinkx, t.wlinky)) {
      //    t.wlinkx += dx;
      //    t.wlinky += dy;
      //  }
      //}

      ////  I hope this is right :)

      //Itinerary* it;
      //int n;

      //for(it = itineraries; it; it = it.next) {
      //  for(n = 0; n < it.nsects; ++n) {
      //    if(isInside(start, end, it.sw[n].x, it.sw[n].y)) {
      //      it.sw[n].x += dx;
      //      it.sw[n].y += dy;
      //    }
      //  }
      //}
    }

    public static void move_layout(int x, int y) {
      // avoid overlaps by moving the original tracks
      // to an area where there cannot be any other track
      move_layout0(move_start.x + 1000, move_start.y + 1000);
      // move back from the temporary area to the
      // final destination area.
      move_start.x += 1000;
      move_start.y += 1000;
      move_end.x += 1000;
      move_end.y += 1000;
      move_layout0(x, y);
      move_start.x -= 1000;
      move_start.y -= 1000;
      move_end.x -= 1000;
      move_end.y -= 1000;
    }

    public static void auto_link_track(Track t) {
      //int x, y;
      //Track* t1;

      //x = t.x;
      //y = t.y;
      //if(link_to_left) {
      //  switch(t.direction) {
      //    case W_E: --y; break;
      //    case E_W: ++y; break;
      //    case N_S: ++x; break;
      //    case S_N: --x; break;
      //  }
      //} else {
      //  switch(t.direction) {
      //    case W_E: ++y; break;
      //    case E_W: --y; break;
      //    case N_S: --x; break;
      //    case S_N: ++x; break;
      //  }
      //}
      //t1 = findTrack(x, y);
      //if(t1 && t1.type == TRACK &&
      //  (t1.direction == W_E || t1.direction == TRK_N_S))
      //  link_tracks(t, t1);
    }

    public static int macro_select() {
      throw new NotImplementedException();
      //Track t;
      //Itinerary nextItin, itinList = null;	// +Rask Ingemann Lambertsen
      //string buff;

      //if(!macros) {
      //  maxmacros = 1;
      //  macros = (Track**)calloc(sizeof(Track*), maxmacros);
      //}
      //buff[0] = 0;
      //if(!Globals.traindir.OpenMacroFileDialog(buff))
      //  return 0;
      //remove_ext(buff);
      //if(!(t = load_field_tracks(buff, &itinList)))
      //  return 0;
      //if(current_macro_name)
      //  Globals.free(current_macro_name);
      //current_macro_name = wxStrdup(buff);
      //clean_field(t);
      //for(; itinList; itinList = nextItin) {	// +Rask Ingemann Lambertsen
      //  nextItin = itinList.next;
      //  free_itinerary(itinList);
      //}
      ///*	if(macros[0])
      //      clean_field(macros[0]);
      //  macros[0] = t;
      //  current_macro = 0;
      //  nmacros = 1;
      //  maxmacros = 1;
      //*/
      //return 1;
    }

    // begin +Rask Ingemann Lambertsen
    static void relocate_itinerary(Itinerary it, int xbase, int ybase) {
      int i;

      for(i = 0; i < it.nsects; ++i) {
        it.sw[i].x += xbase;
        it.sw[i].y += ybase;
      }
    }
    // end +Rask Ingemann Lambertsen

    public static void macro_place(int xbase, int ybase) {
      //Track mp;
      //Track t, t1;
      //int x, y;
      //int oldtool;
      //Itinerary itn, itinList = null;	// +Rask Ingemann Lambertsen

      //if(!current_macro_name)
      //  return;
      //oldtool = current_tool;
      //mp = load_field_tracks(current_macro_name, &itinList);
      //while(mp) {
      //  t1 = mp.next;
      //  x = mp.x + xbase;
      //  y = mp.y + ybase;
      //  if((t = findTrack(x, y)) || (t = findSwitch(x, y)) ||
      //(t = (Track)findSignal(x, y)) || (t = findText(x, y)) ||
      //(t = findPlatform(x, y)) || (t = findImage(x, y)) ||
      //(t = findTrackType(x, y, ITIN)) ||
      //(t = findTrackType(x, y, TRIGGER))) {
      //    track_delete(t);
      //  }
      //  mp.x = x;
      //  mp.y = y;
      //  if(mp.elinkx || mp.elinky) {
      //    mp.elinkx += xbase;
      //    mp.elinky += ybase;
      //  }
      //  if(mp.wlinkx || mp.wlinky) {
      //    mp.wlinkx += xbase;
      //    mp.wlinky += ybase;
      //  }
      //  mp.next = layout;
      //  layout = mp;
      //  link_all_tracks();
      //  mp = t1;
      //  layout_modified = 1;
      //}
      //// begin +Rask Ingemann Lambertsen
      ///* Link in the itineraries from the macro.  Delete duplicates  */
      //if(itinList) {
      //  for(itn = itinList; itn.next; itn = itn.next) {
      //    relocate_itinerary(itn, xbase, ybase);
      //    delete_itinerary(itn.name);
      //  }
      //  relocate_itinerary(itn, xbase, ybase);
      //  delete_itinerary(itn.name);
      //  itn.next = itineraries;
      //  itineraries = itinList;
      //  layout_modified = 1;
      //}
      //// end+Rask Ingemann Lambertsen
      //sort_itineraries();
      //invalidate_field();
      //repaint_all();
      //current_tool = oldtool;
    }

    public static void track_place(int x, int y) {
//      Track t, t1;
//      int needall;

//      if(current_tool >= 0 && tooltbl[current_tool].type == MACRO) {
//        if(!current_macro_name || tooltbl[current_tool].direction == 0) {
//          select_tool(current_tool - 1);
//          return;
//        }
//        macro_place(x, y);
//        return;
//      }
//      if(current_tool >= 0 && tooltbl[current_tool].type == MOVER) {
//        if(tooltbl[current_tool].direction == 0) {
//          move_start.x = x;
//          move_start.y = y;
//          move_end.x = move_end.y = -1;
//          select_tool(current_tool + 1);
//          return;
//        }
//        if((short)move_start.x == -1) {
//          select_tool(current_tool - 1);
//          return;
//        }
//        if((short)move_end.x == -1) {
//          move_end.x = x;
//          move_end.y = y;
//          select_tool(current_tool + 1);
//          mover_draw();
//          return;
//        }
//#if false
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
//        move_layout(x, y);
//#endif
//        layout_modified = 1;
//        invalidate_field();
//        repaint_all();
//        select_tool(current_tool - 2);
//        move_start.x = move_start.y = -1;
//        move_end.x = move_end.y = -1;
//        return;
//      }
//      if(current_tool >= 0 && tooltbl[current_tool].type == LINK) {
//        if(tooltbl[current_tool].direction == 0) {
//          if(!findTrack(x, y) && !findSignal(x, y) &&
//            !findSwitch(x, y) && !findText(x, y) &&
//            !findTrackType(x, y, TRIGGER) &&
//                              !findTrackType(x, y, IMAGE))
//            return;		/* there must be a track */
//          link_start.x = x;
//          link_start.y = y;
//          select_tool(current_tool + 1);
//          return;
//        }
//        if(link_start.x == -1) {
//          select_tool(current_tool - 1);
//          return;
//        }
//        if(!(t = findTrack(link_start.x, link_start.y)) &&
//          !(t = findSwitch(link_start.x, link_start.y)) &&
//          !(t = (Track*)findSignal(link_start.x, link_start.y)) &&
//          !(t = findText(link_start.x, link_start.y)) &&
//          !(t = findTrackType(link_start.x, link_start.y, TRIGGER)) &&
//                      !(t = findTrackType(link_start.x, link_start.y, IMAGE))) {
//          return;
//        }
//        if(!(t1 = findTrack(x, y)) && !(t1 = (Track*)findSignal(x, y)) &&
//        !(t1 = findSwitch(x, y)) && !(t1 = findText(x, y))) {
//          return;
//        }
//        if(t.type == TRIGGER && t1.type != TRACK)
//          return;
//        if(t.type == IMAGE && (t1.type != SWITCH && t1.type != TSIGNAL))
//          return;
//        link_start.x = -1;
//        link_start.y = -1;
//        link_tracks(t, t1);
//        layout_modified = 1;
//        select_tool(current_tool - 1);
//        return;
//      }
//      needall = 0;
//      if((t = findTrack(x, y)) || (t = findSwitch(x, y)) ||
//         (t = (Track*)findSignal(x, y)) || (t = findText(x, y)) ||
//         (t = findPlatform(x, y)) || (t = findImage(x, y)) ||
//         (t = findTrackType(x, y, ITIN)) ||
//         (t = findTrackType(x, y, TRIGGER))) {
//        needall = 1;
//        track_delete(t);
//        link_all_tracks();
//        layout_modified = 1;
//      }
//      if(current_tool == 0) {		/* delete element */
//        repaint_all();
//        return;
//      }
//      t = track_new();
//      t.x = x;
//      t.y = y;
//      t.type = (trktype)tooltbl[current_tool].type;
//      t.direction = (trkdir)tooltbl[current_tool].direction;
//      t.power = gEditorMotivePower;
//      t.gauge = editor_gauge._iValue;
//      t.next = layout;
//      if(t.type == TEXT)
//        t.station = wxStrdup(wxPorting.T("Abc"));
//      else if(t.type == IMAGE)
//        t.direction = (trkdir)0;
//      else if(t.type == TSIGNAL) {
//        if(t.direction & 2) {
//          t.fleeted = 1;
//          t.direction = (trkdir)((int)t.direction & (~2));
//        } else
//          t.fleeted = 0;
//        if(auto_link)
//          auto_link_track(t);
//      } else if(t.type == TRIGGER && auto_link)
//        auto_link_track(t);
//      layout = t;
//      link_all_tracks();
//      layout_modified = 1;
//      if(needall || is_windows)
//        repaint_all();
//      else
//        track_paint(t);
    }

    public static void track_properties(int x, int y) {
      //Track* t;
      //Signal* sig;
      //string buff;

      //if((t = findImage(x, y))) {
      //  buff[0] = 0;
      //  if(t.station)
      //    buff = String.Copy(t.station);
      //  if(!Globals.traindir.OpenImageDialog(buff))
      //    return;
      //  remove_ext(buff);
      //  wxStrcat(buff, wxPorting.T(".xpm"));
      //  if(t.station)
      //    Globals.free(t.station);
      //  t.pixels = 0;
      //  t.station = wxStrdup(buff);
      //  layout_modified = 1;
      //  repaint_all();
      //  return;
      //}
      //if((sig = findSignal(x, y)) && signal_properties_dialog) {
      //  signal_properties_dialog(sig);
      //  layout_modified = 1;
      //  return;
      //}

      //if((t = findTrackType(x, y, TRIGGER)) && trigger_properties_dialog) {
      //  trigger_properties_dialog(t);
      //  layout_modified = 1;
      //  return;
      //}

      //if((t = findSwitch(x, y))) {
      //  switch_properties_dialog(t);
      //  layout_modified = 1;
      //  return;
      //}

      //if((t = findTrack(x, y)) || (t = findText(x, y)) ||
      //    (t = (Track*)findSignal(x, y)) || /* (t = findImage(x, y)) || */
      //    (t = findTrackType(x, y, ITIN)) ||
      //  //                      (t = findSwitch(x, t)) ||
      //    (t = findTrackType(x, y, TRIGGER))) {
      //  track_properties_dialog(t);
      //  layout_modified = 1;
      //  return;
      //}
    }
  }

  public class TrackInterpreterData : InterpreterData {

    TrackInterpreterData() {
      //_onInit = 0;
      //_onSetBusy = 0;
      //_onSetFree = 0;
      //_onEnter = 0;
      //_onExit = 0;
      //_onClicked = 0;
      //_onCanceled = 0;
      //_onCrossed = 0;
      //_onArrived = 0;
      //_onStopped = 0;
      //_onIconUpdate = 0;
    }

    ~TrackInterpreterData() {
      //if(_onInit)
      //  Globals.delete(_onInit);
      //if(_onSetBusy)
      //  Globals.delete(_onSetBusy);
      //if(_onSetFree)
      //  Globals.delete(_onSetFree);
      //if(_onEnter)
      //  Globals.delete(_onEnter);
      //if(_onExit)
      //  Globals.delete(_onExit);
      //if(_onClicked)
      //  Globals.delete(_onClicked);
      //if(_onCanceled)
      //  Globals.delete(_onCanceled);
      //if(_onCrossed)
      //  Globals.delete(_onCrossed);
      //if(_onArrived)
      //  Globals.delete(_onArrived);
      //if(_onStopped)
      //  Globals.delete(_onStopped);
      //if(_onIconUpdate)
      //  Globals.delete(_onIconUpdate);
    }

    public Statement _onInit;	// list of actions (statements)
    public Statement _onSetBusy;
    public Statement _onSetFree;
    public Statement _onEnter;
    public Statement _onExit;
    public Statement _onClicked;
    public Statement _onCanceled;
    public Statement _onCrossed;
    public Statement _onArrived;
    public Statement _onStopped;
    public Statement _onIconUpdate;

    public bool Evaluate(ExprNode n, ExprValue result) {
      throw new NotImplementedException();
      //Track t = 0;
      //Signal sig = 0;
      //ExprValue left = new ExprValue(NodeOp.None);
      //ExprValue right = new ExprValue(NodeOp.None);
      //String prop;

      //if(!n)
      //  return false;
      //switch(n._op) {

      //  case LinkedRef:

      //    t = this._track;
      //    if(!t.wlinkx || !t.wlinky)
      //      return false;
      //    result._track = findSwitch(t.x, t.y);
      //    if(!result._track)
      //      return false;
      //    result._op = SwitchRef;
      //    return true;

      //  case Dot:

      //    result._op = Addr;
      //    if(!(n._left)) {
      //      result._track = this._track;
      //      result._op = TrackRef;
      //    } else if(n._left && n._left._op == Dot) {
      //      bool oldForAddr = _forAddr;
      //      _forAddr = true;
      //      if(!Evaluate(n._left, result)) {	// <signal>.<property>
      //        _forAddr = oldForAddr;
      //        return false;
      //      }
      //      _forAddr = oldForAddr;

      //      if(result._op == TrackRef || result._op == SwitchRef)
      //        TraceCoord(result._track.x, result._track.y);
      //      else if(result._op == SignalRef) {
      //        TraceCoord(result._signal.x, result._signal.y);
      //        goto not_track;
      //      } else
      //        return false;
      //    } else {
      //      if(!Evaluate(n._left, result))
      //        return false;

      //      if(result._op == TrainRef)
      //        goto not_track;
      //      if(result._op == SignalRef)
      //        goto not_track;
      //      if(result._op != TrackRef && result._op != SwitchRef)
      //        return false;
      //    }
      //    if(!result._track) {
      //      wxStrcat(expr_buff, wxPorting.T("no current track for '.'"));
      //      return false;
      //    }
      //    t = result._track;
      //    TraceCoord(t.x, t.y);

      //  not_track:
      //    if(n._right) {
      //      switch(n._right._op) {
      //        case LinkedRef:
      //          if(!t) {
      //            return false;
      //          }
      //          result._signal = 0;
      //          result._track = findTrack(t.wlinkx, t.wlinky);
      //          if(!result._track) {
      //            result._track = findSwitch(t.wlinkx, t.wlinky);
      //            if(result._track)
      //              result._op = SwitchRef;
      //            else {
      //              result._signal = findSignal(t.wlinkx, t.wlinky);
      //              if(result._signal)
      //                result._op = SignalRef;
      //              else {
      //                result._track = findImage(t.wlinkx, t.wlinky);
      //                if(result._track)
      //                  result._op = TrackRef;
      //                else {
      //                  result._track = findTrackType(t.wlinkx, t.wlinky, ITIN);
      //                  if(result._track) // do signal instead?
      //                    result._op = TrackRef;
      //                }
      //              }
      //            }
      //          } else
      //            result._op = TrackRef;
      //          if(result._track) {
      //            TraceCoord(result._track.x, result._track.y);
      //            break;
      //          }
      //          if(result._signal) {
      //            TraceCoord(result._signal.x, result._signal.y);
      //            break;
      //          }
      //          wxStrcat(expr_buff, wxPorting.T("no linked track for '.'"));
      //          return false;
      //      }
      //    }
      //  result._txt = (n._right && n._right._op == String) ? n._right._txt : n._txt;
      //  if(_forAddr)
      //    return true;

      //  prop = result._txt;
      //  if(!prop)
      //    return false;

      //  wxStrcat(expr_buff, prop);
      //  switch(result._op) {

      //    case SwitchRef:

      //      if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //        result._op = Number;
      //        result._val = t.switched;
      //        return true;
      //      }

      //    case Addr:
      //    case TrackRef:

      //      if(!result._track)
      //        return false;
      //      return result._track.GetPropertyValue(prop, result);

      //    case SignalRef:

      //      if(!result._signal)
      //        return false;
      //      return result._signal.GetPropertyValue(prop, result);

      //    case TrainRef:

      //      if(!result._train)
      //        return false;
      //      return result._train.GetPropertyValue(prop, result);

      //  }
      //  return false;

      //  case Equal:

      //  result._op = Number;
      //  result._val = 0;
      //  //if(_forCond)
      //  return InterpreterData.Evaluate(n, result);
      //  //return false;

      //  default:

      //  return InterpreterData.Evaluate(n, result);
      //}

      //return false;
    }

  }

  public class Track : TrackBase {


    //
    //	Scripting support
    //


    bool GetPropertyValue(String prop, ExprValue result) {
      throw new NotImplementedException();
      //Track* t = this;

      //// move to Track::GetPropertyValue()
      //if(!wxStrcmp(prop, wxPorting.T("length"))) {
      //  result._op = Number;
      //  result._val = t.length;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("station"))) {
      //  result._op = String;
      //  result._txt = t.station ? wxPorting.T("") : t.station;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%s}"), result._txt);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("busy"))) {
      //  result._op = Number;
      //  result._val = (t.fgcolor != conf.fgcolor) || findTrain(t.x, t.y);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("free"))) {
      //  result._op = Number;
      //  result._val = t.fgcolor == conf.fgcolor && !findTrain(t.x, t.y);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //  result._op = Number;
      //  if(t.type == SWITCH) {
      //    /*		switch(t.direction) {
      //        case 10:	// Y switches could be considered always set to a siding
      //        case 11:	// but it conflicts with the option of reading the status
      //        case 22:	// then throwing the switch, so this is not enabled.
      //        case 23:
      //            result._val = 1;
      //            break;

      //        default: */
      //    result._val = t.switched;
      //    //}
      //  } else
      //    result._val = 0;
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("color"))) {
      //  result._op = String;
      //  result._txt = GetColorName(t.fgcolor);
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), result._val);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("linked"))) {
      //  int x, y;
      //  if(!(x = t.wlinkx) || !(y = t.wlinky)) {
      //    x = t.elinkx;
      //    y = t.elinky;
      //  }
      //  Track* lnk = findTrack(x, y);
      //  if(!lnk) {
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d,%d} - not found"), x, y);
      //    result._op = Number;
      //    result._val = 0;
      //    return false;
      //  }
      //  if(lnk.type == TSIGNAL) {
      //    result._signal = (Signal*)lnk;
      //    result._op = SignalRef;
      //  } else {
      //    result._track = lnk;
      //    result._op = TrackRef;
      //  }
      //  return true;
      //}

      //result._op = Number;
      //result._val = 0;
      //return false;
    }

    bool SetPropertyValue(String prop, ExprValue val) {
      throw new NotImplementedException();
      //if(!wxStrcmp(prop, wxPorting.T("thrown"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  if(type != SWITCH)
      //    return false;
      //  switched = val._val != 0;
      //  change_coord(this.x, this.y);
      //  repaint_all();
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("click"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  track_selected(this.x, this.y);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("color"))) {
      //  expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("=%d"), val._val);
      //  grcolor col = conf.fgcolor;
      //  if(wxStrcmp(val._txt, wxPorting.T("blue")) == 0)
      //    col = color_blue;
      //  else if(wxStrcmp(val._txt, wxPorting.T("white")) == 0)
      //    col = color_white;
      //  else if(wxStrcmp(val._txt, wxPorting.T("red")) == 0)
      //    col = color_red;
      //  else if(wxStrcmp(val._txt, wxPorting.T("green")) == 0)
      //    col = color_green;
      //  else if(wxStrcmp(val._txt, wxPorting.T("orange")) == 0)
      //    col = color_orange;
      //  else if(wxStrcmp(val._txt, wxPorting.T("black")) == 0)
      //    col = color_black;
      //  else if(wxStrcmp(val._txt, wxPorting.T("cyan")) == 0)
      //    col = color_cyan;
      //  SetColor(col);
      //  return true;
      //}
      //if(!wxStrcmp(prop, wxPorting.T("icon"))) {
      //  if(this.type == IMAGE) {
      //    if(this.station)
      //      Globals.free(this.station);
      //    this.station = wxStrdup(val._txt);
      //    change_coord(this.x, this.y);
      //    repaint_all();
      //  }
      //}

      //return false;
    }


    void OnInit() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onInit)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnInit"));
      //Trace(expr_buff);
      //interp.Execute(interp._onInit);
      //return;
    }

    void OnSetBusy() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onSetBusy)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnSetBusy"));
      //Trace(expr_buff);
      //interp.Execute(interp._onSetBusy);
      //return;
    }

    void OnSetFree() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onSetFree)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnSetFree"));
      //Trace(expr_buff);
      //interp.Execute(interp._onSetFree);
      //return;
    }

    public void OnEnter(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onEnter)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._stackPtr = 0;
      //interp._signal = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnEnter"));
      //Trace(expr_buff);
      //interp.Execute(interp._onEnter);
      //return;
    }

    public void OnExit(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onExit)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._stackPtr = 0;
      //interp._signal = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnExit"));
      //Trace(expr_buff);
      //interp.Execute(interp._onExit);
      //return;
    }

    public void OnClicked() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onClicked)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnClicked"));
      //Trace(expr_buff);
      //interp.Execute(interp._onClicked);
      //return;
    }

    void OnCanceled() {
      //if(this.type != ITIN)
      //  return;
      //if(_interpreterData) {
      //  TrackInterpreterData interp = *(TrackInterpreterData*)_interpreterData;
      //  if(interp._onCanceled) {
      //    interp._track = this;
      //    Itinerary* it;
      //    for(it = itineraries; it; it = it.next)
      //      if(!wxStrcmp(it.name, this.station)) {
      //        interp._itinerary = it;
      //        break;
      //      }
      //    expr_buff = String.Format( wxPorting.T("Track::OnCanceled(%s)"), this.station);
      //    Trace(expr_buff);
      //    interp.Execute(interp._onCanceled);
      //    return;
      //  }
      //}
    }

    public void OnCrossed(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onCrossed)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnCrossed"));
      //Trace(expr_buff);
      //interp.Execute(interp._onCrossed);
      //return;
    }

    public void OnArrived(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onArrived)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnArrived"));
      //Trace(expr_buff);
      //interp.Execute(interp._onArrived);
      //return;
    }

    public void OnStopped(Train trn) {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onStopped)
      //  return;
      //interp._track = this;
      //interp._train = trn;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnStopped"));
      //Trace(expr_buff);
      //interp.Execute(interp._onStopped);
      //return;
    }

    public void OnIconUpdate() {
      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //if(!interp)
      //  return;
      //if(!interp._onIconUpdate)
      //  return;
      //interp._track = this;
      //interp._train = 0;
      //interp._signal = 0;
      //interp._stackPtr = 0;
      //interp.TraceCoord(x, y, wxPorting.T("Track::OnIconUpdate"));
      //Trace(expr_buff);
      //interp.Execute(interp._onIconUpdate);
      //return;
    }

    public void ParseProgram() {
      //String p;

      //if(!this.stateProgram || !*this.stateProgram)
      //  return;
      //if(_interpreterData)	    // previous script
      //  Globals.delete(_interpreterData);
      //_interpreterData = new TrackInterpreterData();

      //TrackInterpreterData* interp = (TrackInterpreterData*)_interpreterData;
      //p = this.stateProgram;
      //while(*p) {
      //  String p1 = p;
      //  while(*p1 == ' ' || *p1 == '\t' || *p1 == '\r' || *p1 == '\n')
      //    ++p1;
      //  p = p1;
      //  if(match(&p, wxPorting.T("OnInit:"))) {
      //    p1 = p;
      //    interp._onInit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnSetBusy:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onSetBusy = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnSetFree:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onSetFree = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnEnter:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onEnter = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCrossed:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCrossed = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnArrived:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onArrived = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnStopped:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onStopped = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnExit:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onExit = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnClicked:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onClicked = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnIconUpdate:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onIconUpdate = ParseStatements(&p);
      //  } else if(match(&p, wxPorting.T("OnCanceled:"))) {
      //    p = next_token(p);
      //    p1 = p;
      //    interp._onCanceled = ParseStatements(&p);
      //  }
      //  if(p1 == p)	    // error! couldn't parse token
      //    break;
      //}
    }

    public void RunScript(string script, Train trn) {
      //Script* s = find_script(script);
      //if(!s) {
      //  s = new_script(script);
      //  // return;
      //}
      //if(!s.ReadFile())
      //  return;

      //// is it different from current one?
      //if(!this.stateProgram || wxStrcmp(s._text, this.stateProgram)) {
      //  if(this.stateProgram)
      //    Globals.free(this.stateProgram);
      //  this.stateProgram = wxStrdup(s._text);
      //  ParseProgram();
      //}
      //OnEnter(trn);
    }


    public void SetColor(grcolor color) {
      //if(this.fgcolor == color)
      //  return;
      //this.fgcolor = color;
      //change_coord(this.x, this.y);
      //if(color == conf.fgcolor)
      //  OnSetFree();
      //else
      //  OnSetBusy();
    }

    public bool IsBusy() {
      throw new NotImplementedException();
      //if(this.fgcolor != conf.fgcolor)
      //  return true;
      //return false;
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
    public bool busy = false;
    public bool fleeted = false;
    public bool nowfleeted = false;
    public bool norect = false; /* switches have a rectangle around em*/
    public bool fixedred = false;		/* signal is always red */
    public bool nopenalty = false;		/* no penalty for train stopping at signal */
    public bool noClickPenalty = false;	/* no penalty for un-necessary clicks */
    public bool invisible = false;		/* object is not shown on layout */
    public char wtrigger = (char)0x00;		/* westbound trigger linked */
    public char etrigger = (char)0x00;		/* eastbound trigger linked */
    public char signalx = (char)0x00;		/* use 'x' version when drawing signal */
    public bool aspect_changed = false;	/* ignore script execution - TODO: remove */
    public TFLG flags = 0;			/* performance flags (TFLG_*) */
    public string station = "";
    public object lock_;
    public int[] speed = new int[Config.NTTYPES];
    public int icon = 0;
    public int length = 0;
    public Signal wsignal = null;		/* signal controlling this track */
    public Signal esignal = null;		/* signal controlling this track */
    public Track controls = null;		/* track controlled by this signal */
    public grcolor fgcolor = null;
    public object pixels;		/* for IMAGE pixmap */
    public int km = 0;			/* station distance (in meters) */
    public string stateProgram = null;		/* 3.5: name of function describing state changes */
    public string _currentState = null;	/* 3.5: name of current state in state program */
    public string _prevState = null;  /* 3.8q: signal state before update loop */
    public InterpreterData _interpreterData;	/* 3.5: intermediate data for program interpreter */
    public bool _isFlashing = false;		/* 3.5: flashing signal */
    public bool _isShuntingSignal = false;	/* 3.5: only affects shunting trains */
    public int _nextFlashingIcon = 0;	/* 3.5: index in list of icons when flashing */
    public string[] _flashingIcons = new string[Config.MAX_FLASHING_ICONS];	// 3.8: array of flashing icon names
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

    public TrackBase() {
      //next = null;
      //next1 = null;
      //x = y = 0;
      //xsize = ysize = 0;
      //type = trktype.NOTRACK;
      //direction = trkdir.W_E;
      //status = trkstat.ST_FREE;
      //wlinkx = wlinky = 0;
      //elinkx = elinky = 0;
      //isstation = null;
      //switched = null;
      //busy = null;
      //fleeted = null;
      //nowfleeted = null;
      //norect = null;
      //fixedred = null;
      //nopenalty = null;
      //noClickPenalty = null;
      //invisible = null;
      //wtrigger = null;
      //etrigger = null;
      //signalx = null;
      //aspect_changed = null;
      //flags = null;		/* performance flags (TFLG_*) */
      //station = null;
      //lock_ = 0;
      //_lockedBy = null;
      //memset(speed, 0, sizeof(speed));
      //icon = 0;
      //length = 0;
      //wsignal = null;		/* signal controlling this track */
      //esignal = null;		/* signal controlling this track */
      //controls = null;		/* track controlled by this signal */
      //fgcolor = 0;
      //pixels = 0;		/* for IMAGE pixmap */
      //km = 0;			/* station distance (in meters) */
      //stateProgram = null;	/* 4.0: name of function describing state changes */
      //_currentState = null;	/* 4.0: name of current state in state program */
      //_interpreterData = null;	/* 4.0: intermediate data for program interpreter */
      //_isFlashing = null;	/* 4.0: flashing signal */
      //_isShuntingSignal = null;	/* 4.0: only affects shunting trains */
      //_nextFlashingIcon = 0;	/* 4.0: index in list of icons when flashing */
      //for(int i = 0; i < MAX_FLASHING_ICONS; ++i)
      //  _flashingIcons[i] = 0;
      //_fontIndex = 0;
      //_intermediate = false;
      //_nReservations = 0;
      //power = 0;              // 3.9: motive power allowed (diesel, electric)
      //gauge = 0;              // 3.9: track gauge
    }
  }
}