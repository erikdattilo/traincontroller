// /*	tgraph.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */
using wx;
using System;
using System.Drawing;

namespace Traincontroller2 {
  public class LateGraphView : ScrolledWindow {
    // #define	STATION_WIDTH 10
    // #define	KM_WIDTH 5
    // #define	HEADER_HEIGHT 20
    // #define	MAXWIDTH (2 * 60 * 24 + STATION_WIDTH + KM_WIDTH)

    private static Track[] stations = new Track[60];
    private static int nstations;

    private static grid late_graph_grid;
    private static int highkm;

    // #define	HEIGHT	700

    private static void DrawTimeGrid(grid g, int y) {
      int h, m;
      int x;
      string buff;

      x = Configuration.STATION_WIDTH + Configuration.KM_WIDTH;
      g.DrawLine(x, Configuration.HEIGHT, x + 23 * 120 + 59 * 2, Configuration.HEIGHT, 0);
      for(h = 0; h < 24; ++h)
        for(m = 0; m < 60; ++m) {
          if((m % 10) != 0) {
#if false
     		    g.DrawLine(
     			x + h * 120 + m * 2, y - 2,
     			x + h * 120 + m * 2, y + 2,
     			0);
#endif
          } else {
            g.DrawLine(
          x + h * 120 + m * 2, 20,
          x + h * 120 + m * 2, Configuration.HEIGHT,
          m != 0 ? 5 : 0);
          }
        }

      for(h = 0; h < 24; ++h) {
        buff = String.Format( wxPorting.T("%2d:00"), h);
        g.DrawText1(x + h * 120, 10, buff, false);
      }
    }

    private static int km_to_y(int km) {
      throw new NotImplementedException();
      //int y;

      //y = Configuration.HEADER_HEIGHT + (double)km / (double)highkm * 960;
      //return y;
    }

    private static bool islinkedtext(Track t) {
      if(t.elinkx != 0 && t.elinky != 0)
        return true;
      if(t.wlinkx != 0 && t.wlinky != 0)
        return true;
      return false;
    }

    private void DrawStations(grid g) {
      //Track t;
      //int y;
      //String p;
      //string buff;

      //nstations = 0;
      //highkm = 0;
      //for(t = Globals.layout; t != null; t = t.next) {
      //  if(t.type == trktype.TEXT) {
      //    if(!islinkedtext(t))
      //      continue;
      //    if(t.km > highkm)
      //      highkm = t.km;
      //    continue;
      //  }
      //  if(!t.isstation || String.IsNullOrEmpty(t.station) || t.km == 0)
      //    continue;
      //  if(t.km > highkm)
      //    highkm = t.km;
      //}
      //for(t = Globals.layout; t != null; t = t.next) {
      //  if(t.type == trktype.TEXT) {
      //    if(t.km == 0|| !islinkedtext(t))
      //      continue;
      //  } else if(!t.isstation || String.IsNullOrEmpty(t.station) || t.km == 0)
      //    continue;
      //  stations[nstations++] = t;
      //  y = km_to_y(t.km);
      //  DrawTimeGrid(g, y);

      //  buff = String.Format( wxPorting.T("%3d.%d %s"), t.km / 1000, (t.km / 100) % 10,
      //            t.station);
      //  if((p = wxStrchr(buff, '@')))
      //    *p = 0;
      //  g.DrawText1(0, y, buff, false);
      //}
      //if(nstations == 0) {
      //  g.DrawText1(10, 10, wxPorting.L("Sorry, this feature is not available on this scenario."), false);
      //  g.DrawText1(10, 25, wxPorting.L("No station has distance information."), false);
      //}
    }

    private static int graphstation(string st) {
      int i;

      for(i = 0; i < nstations; ++i)
        if(Globals.sameStation(st, stations[i].station))
          return i;
      return -1;
    }

    private static void graph_xy(long km, long tim, out int x, out int y) {
      throw new NotImplementedException();
      //x = tim / 60 * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH;
      //y = Globals.km_to_y(km);
    }

    private static void time_to_time(grid g, int x, int y, int nx, int ny, int type) {
      //int color = Configuration.COL_TRAIN1 + type;

      //if(nx < x)	/* ignore if arrival is next day */
      //  return;
      //if(ny < y) {	/* going from bottom of graph to top */
      //  g.DrawLine(x, y - 5, nx, ny + 5, color);
      //  g.DrawLine(x, y, x, y - 5, color);
      //  g.DrawLine(nx, ny + 5, nx, ny, color);
      //} else {	/* going from top of graph to bottom */
      //  g.DrawLine(x, y + 5, nx, ny - 5, color);
      //  g.DrawLine(x, y, x, y + 5, color);
      //  g.DrawLine(nx, ny - 5, nx, ny, color);
      //}
    }

    private static bool samestation(string st, string arrdep) {
      throw new NotImplementedException();
      //string buff;
      //int i;

      //for(i = 0; arrdep.length > 0 && arrdep[0] != ' '; buff[i++] = arrdep[0], arrdep = arrdep.Substring(1)) ;
      //buff = buff.Substring(0, i);
      //return (Globals.sameStation(st, buff));
    }

    private void DrawTrains(grid g) {
      int x;

      for(x = 0; x < 24 * 60; ++x) {
        int nx = x * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH;
        if(Globals.late_data[x] != 0)
          late_graph_grid.DrawLine(nx, Configuration.HEIGHT - Globals.late_data[x], nx, Configuration.HEIGHT, 2);
      }
    }

    public LateGraphView(Window parent)
      : base(parent, (int)wxID_ANY, new Point(0, 0), new Size(Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX)) {

      EVT_PAINT(new wx.EventListener(OnPaint));

      SetScrollbars(1, 1, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      grid g = new grid(this, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      late_graph_grid = g;
      g.Clear();
    }


    public override void Refresh() {
      grid g = late_graph_grid;

      g.Clear();
      DrawTimeGrid(g, 0);
      DrawTrains(g);
      base.Refresh();
    }

    public void OnPaint(object sender, Event evt) {
      if(late_graph_grid != null)
        late_graph_grid.Paint(this);
    }
  }
}