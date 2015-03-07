/*	defs.h - Created by Giampiero Caprino
 
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
namespace TrainDirPorting {
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

  partial class Configuration {
    public static string STATE_FILE_NAME = "tdir3.ini";
  }
    // 
    // typedef unsigned short Pos;		/* reduce memory occupation of Track */
  

     //	Coord
     //
     //	A location on the canvas.
     //	The coords are multiplied by HGRID and VGRID
     //	before drawing on the canvas.
     //	Conversely, the coords are divided by HGRID and VGRID
     //	when converting from canvas coord.

  public class Coord {
    public int x;
    public int y;

    public void Set(int _x, int _y) {
      x = _x; y = _y;
    }

    public Coord(int _x, int _y) { x = _x; y = _y; }
    // 	Coord& operator=(Coord& other)
    // 	{
    // 	    x = other.x;
    // 	    y = other.y;
    // 	    return *this;
    // 	}
    // 
    // 	bool operator==(Coord& other) const
    // 	{
    // 	    return x == other.x && y == other.y;
    // 	}
    // 
    // 	bool operator!=(Coord& other) const
    // 	{
    // 	    return x != other.x || y != other.y;
    // 	}
    // 
  }

    // typedef char	Char;
    // typedef String String;
    // typedef String TDString;
    // 
    // #define	wxPorting.L(s)	localize(wxPorting.T(s))
    // #define	wxPorting.LV(s)	localize(s)
    // 
    // void	Globals.localizeArray(ref string english[]);
    // void	Globals.freeLocalizedArray(string localized[]);
}