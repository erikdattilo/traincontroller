using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainDirNET {
  static partial class GlobalVariables {

    public static Image[] n_sig_pmap = new Image[2];         /* R, G */
    public static Image[] n_sigx_pmap = new Image[2];
    public static string[] n_sig_xpm = new string[] {
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
    public static string[] n_sigx_xpm = new string[] {
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

    public static Image[] s_sig_pmap = new Image[2];         /* R, G */
    public static Image[] s_sigx_pmap = new Image[2];
    public static string[] s_sig_xpm = new string[] {
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
    public static string[] s_sigx_xpm = new string[] {
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

    public static Image[] n_sig2_pmap = new Image[4];         /* R, G */
    public static Image[] n_sig2x_pmap = new Image[4];
    public static string[] n_sig2_xpm = new string[] {
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
    public static string[] n_sig2x_xpm = new string[] {
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

    public static Image[] e_sig_pmap = new Image[2];		/* R, G */
    public static Image[] e_sigx_pmap = new Image[2];
    public static string[] e_sig_xpm = new string[] {
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
    public static string[] e_sigx_xpm = new string[] {
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

    public static Image[] w_sig_pmap = new Image[2];		/* R, G */
    public static Image[] w_sigx_pmap = new Image[2];
    public static string[] w_sig_xpm = new string[] {
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
    public static string[] w_sigx_xpm = new string[] {
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

    public static Image[] e_sig2_pmap = new Image[4];		/* RR, GR, GG, GO */
    public static Image[] e_sig2x_pmap = new Image[4];
    public static string[] e_sig2_xpm = new string[] {
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
    public static string[] e_sig2x_xpm = new string[] {
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

    public static Image[] e_sigP_pmap = new Image[4];		/* RR, GR, GG, GO */
    public static string[] e_sigP_xpm = new string[] {
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


    public static Image[] w_sig2_pmap = new Image[4];		/* RR, GR, GG, GO */
    public static Image[] w_sig2x_pmap = new Image[4];
    public static string[] w_sig2_xpm = new string[] {
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
    public static string[] w_sig2x_xpm = new string[] {
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

    public static Image[] w_sigP_pmap = new Image[4];		/* RR, GR, GG, GO */
    public static string[] w_sigP_xpm = new string[] {
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

    public static Image[] s_sig2_pmap = new Image[4];         /* R, G */
    public static Image[] s_sig2x_pmap = new Image[4];         /* R, G */
    public static string[] s_sig2_xpm = new string[] {
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
    public static string[] s_sig2x_xpm = new string[] {
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


  }
}