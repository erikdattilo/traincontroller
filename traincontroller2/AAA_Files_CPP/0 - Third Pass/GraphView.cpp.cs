/*	GraphView.cpp - Created by Giampiero Caprino

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
using System.Drawing;

namespace TrainDirPorting {

  public partial class Configuration {
    public static int STATION_WIDTH1 = 100;
    public static int KM_WIDTH1 = 50;
    public static int HEADER_HEIGHT1 = 20;
    public static int MAXWIDTH1 {
      get { return (4 * 60 * 24 + STATION_WIDTH1 + KM_WIDTH1); }
    }

  }

  public static partial class Globals {
    public static Track[] stations1 = new Track[60];
    public static int nstations1;

    public static grid tgraph_grid;
    public static int highkm1;




    public static void DrawTimeGrid1(grid g, int y) {
      int h, m;
      int x;
      string buff;

      x = Configuration.STATION_WIDTH1 + Configuration.KM_WIDTH1;
      for(h = 0; h < 24; ++h)
        for(m = 0; m < 60; ++m) {
          if((m % 10) != 0) {
            g.DrawLine(
          x + h * 240 + m * 4, y - 2,
          x + h * 240 + m * 4, y + 2,
          0);
          } else {
            g.DrawLine(
          x + h * 240 + m * 4, 20,
          x + h * 240 + m * 4, 1000,
          m != 0 ? 1 : 0);
          }
        }

      for(h = 0; h < 24; ++h) {
        buff = String.Format( wxPorting.T("%2d:00"), h);
        g.DrawText1(x + h * 240, 10, buff, false);
      }
    }

    public static int km_to_y(int km) {
      int y;

      y = (int)(Configuration.HEADER_HEIGHT1 + (double)km / (double)highkm1 * 960);
      return y;
    }

    public static bool islinkedtext(Track t) {
      if(t.elinkx != 0 && t.elinky != 0)
        return true;
      if(t.wlinkx != 0 && t.wlinky != 0)
        return true;
      return false;
    }

    public static int graphstation1(String st) {
      int i;

      for(i = 0; i < nstations1; ++i)
        if(sameStation(st, stations1[i].station))
          return i;
      return -1;
    }

    public static void graph_xy1(int km, int tim, out int x, out int y) {
      x = tim / 60 * 4 + Configuration.STATION_WIDTH1 + Configuration.KM_WIDTH1;
      y = km_to_y(km);
    }

    public static void time_to_time1(grid g, int x, int y, int nx, int ny, int type) {
      int color = (int)fieldcolor.COL_TRAIN1 + type;

      if(nx < x)	/* ignore if arrival is next day */
        return;
      //	gc = tgraph_grid.gc /*drawing_area.style.black_gc*/;
      if(ny < y) {	/* going from bottom of graph to top */
        g.DrawLine(x, y - 5, nx, ny + 5, color);
        g.DrawLine(x, y, x, y - 5, color);
        g.DrawLine(nx, ny + 5, nx, ny, color);
      } else {	/* going from top of graph to bottom */
        g.DrawLine(x, y + 5, nx, ny - 5, color);
        g.DrawLine(x, y, x, y + 5, color);
        g.DrawLine(nx, ny - 5, nx, ny, color);
      }
    }

    public static bool samestation1(String st, String arrdep) {
      string buff = "";

      while(String.IsNullOrEmpty(arrdep) == false && arrdep[0] != ' ') {
        buff += arrdep[0];
        arrdep = arrdep.Substring(1);
      }
      return (sameStation(st, buff));
    }

    internal static string wxStrchr(string buff, char p) {
      throw new NotImplementedException();
    }
  }

  public class GraphView : ScrolledWindow {
    private void DrawStations(grid g) {
      //Track t;
      //int y;
      //String p;
      //string buff;

      //Globals.nstations1 = 0;
      //Globals.highkm1 = 0;
      //for(t = Globals.layout; t != null; t = t.next) {
      //  if(t.type == trktype.TEXT) {
      //    if(!Globals.islinkedtext(t))
      //      continue;
      //    if(t.km > Globals.highkm1)
      //      Globals.highkm1 = t.km;
      //    continue;
      //  }
      //  if(!t.isstation || String.IsNullOrEmpty(t.station) || t.km == 0)
      //    continue;
      //  if(t.km > Globals.highkm1)
      //    Globals.highkm1 = t.km;
      //}
      //for(t = Globals.layout; t != null; t = t.next) {
      //  if(t.type == trktype.TEXT) {
      //    if(t.km == 0 || !Globals.islinkedtext(t))
      //      continue;
      //  } else if(!t.isstation || String.IsNullOrEmpty(t.station) || t.km == 0)
      //    continue;
      //  Globals.stations1[Globals.nstations1++] = t;
      //  y = Globals.km_to_y(t.km);
      //  Globals.DrawTimeGrid1(g, y);

      //  buff = String.Format( wxPorting.T("%3d.%d %s"), t.km / 1000, (t.km / 100) % 10,
      //            t.station);
      //  if((p = Globals.wxStrchr(buff, '@')) != null)
      //    *p = 0;
      //  g.DrawText1(0, y, buff, false);
      //}
      //if(Globals.nstations1 == 0) {
      //  g.DrawText1(10, 10, wxPorting.L("Sorry, this feature is not available on this scenario."), false);
      //  g.DrawText1(10, 25, wxPorting.L("No station has distance information."), false);
      //}
    }

    private void DrawTrains(grid g) {
      Train t;
      TrainStop ts;
      Track trk;
      int indx;
      int x, y;
      int nx, ny;

      for(t = Globals.schedule; t != null; t = t.next) {
        //	    gc = tgraph_grid.gc;
        //	    gdk_rgb_gc_set_foreground(gc,
        //		(colortable[fieldcolors[COL_TRAIN1+t.type]][0] << 16) |
        //		(colortable[fieldcolors[COL_TRAIN1+t.type]][1] << 8) |
        //		(colortable[fieldcolors[COL_TRAIN1+t.type]][2]));
        x = y = -1;
        for(trk = Globals.layout; trk != null; trk = trk.next) {
          if(trk.type == trktype.TRACK && trk.isstation &&
                Globals.samestation1(trk.station, t.entrance))
            break;
          if(trk.type == trktype.TEXT && Globals.islinkedtext(trk) && trk.km > 0 &&
                Globals.samestation1(trk.station, t.entrance))
            break;
        }
        if(trk != null && (indx = Globals.graphstation1(trk.station)) >= 0)
          Globals.graph_xy1(Globals.stations1[indx].km, t.timein, out x, out y);
        for(ts = t.stops; ts != null; ts = ts.next) {
          indx = Globals.graphstation1(ts.station);
          if(indx < 0)
            continue;
          if(x == -1) {
            Globals.graph_xy1(Globals.stations1[indx].km, ts.departure, out x, out y);
            continue;
          }
          Globals.graph_xy1(Globals.stations1[indx].km, ts.arrival, out nx, out ny);
          Globals.time_to_time1(g, x, y, nx, ny, t.type);
          Globals.graph_xy1(Globals.stations1[indx].km, ts.departure, out x, out y);
        }
        if(x != -1) {
          for(trk = Globals.layout; trk != null; trk = trk.next) {
            if(trk.type == trktype.TRACK && trk.isstation &&
              Globals.samestation1(trk.station, t.exit))
              break;
            if(trk.type == trktype.TEXT && Globals.islinkedtext(trk) && trk.km > 0 &&
              Globals.samestation1(trk.station, t.exit))
              break;
          }
          if(trk == null)
            continue;
          indx = Globals.graphstation1(trk.station);
          if(indx < 0)
            continue;
          Globals.graph_xy1(Globals.stations1[indx].km, t.timeout, out nx, out ny);
          Globals.time_to_time1(g, x, y, nx, ny, t.type);
        }
      }
    }

    public GraphView(Window parent)
      : base(parent, wxID_ANY, new Point(0, 0), new wxSize(Configuration.XMAX * 4 + Configuration.STATION_WIDTH1 + Configuration.KM_WIDTH1, Configuration.YMAX)) {
      EVT_PAINT(new wx.EventListener(OnPaint));

      SetScrollbars(1, 1, Configuration.XMAX * 4 + Configuration.STATION_WIDTH1 + Configuration.KM_WIDTH1, Configuration.YMAX);
      grid g = new grid(this, Configuration.XMAX * 4 + Configuration.STATION_WIDTH1 + Configuration.KM_WIDTH1, Configuration.YMAX);
      Globals.tgraph_grid = g;
      g.Clear();
    }

    public override void Refresh() {
      grid g = Globals.tgraph_grid;

      g.Clear();
      DrawStations(g);
      DrawTrains(g);
      base.Refresh();
    }

    public void OnPaint(object sender, Event evt) {
      if(Globals.tgraph_grid != null)
        Globals.tgraph_grid.Paint(this);
    }
  }
}