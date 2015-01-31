/*	PlatformGraph.cpp - Created by Giampiero Caprino

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
namespace Traincontroller2 {


  public class PlatformSegment {
    public PlatformSegment next;
    public int y;
    public int x0, x1;
    public Train train;
    public Train parent;
    public long timein, timeout;
  }

  public partial class Configuration {
    public static int STATION_WIDTH = 140;
    public static int KM_WIDTH = 5;
    public static int HEADER_HEIGHT = 20;
    public static int MAXWIDTH { get { return (2 * 60 * 24 + STATION_WIDTH + KM_WIDTH); } }
    public static int Y_DIST = 20;

    public static int HEIGHT = 700;
  }

  public partial class Globals {


    public static Track[] stations = new Track[100];
    public static int nstations;

    public static grid platform_graph_grid;
    public static int highkm;
    public static PlatformSegment segments;

    public static void DrawTimeGrid(grid g, int y) {
      int h, m;
      int x;
      string buff;

      x = Configuration.STATION_WIDTH + Configuration.KM_WIDTH;
      g.DrawLine(x, Configuration.HEIGHT, x + 23 * 120 + 59 * 2, Configuration.HEIGHT, 0);
      for(h = 0; h < 24; ++h)
        for(m = 0; m < 60; ++m) {
          if((m % 10) != 0) {
          } else {
            g.DrawLine(
          x + h * 120 + m * 2, 20,
          x + h * 120 + m * 2, Configuration.HEIGHT,
          m != 0 ? 6 : 0);
          }
        }

      for(h = 0; h < 24; ++h) {
        buff = String.Format(wxPorting.T("%2d:00"), h);
        g.DrawText1(x + h * 120, 10, buff, false);
      }
    }

    public static int graphstation(String st) {
      int i;

      for(i = 0; i < nstations; ++i)
        if(wxStrcmp(st, stations[i].station) == 0)
          return i;
      return -1;
    }

    static void graph_xy(int km, int tim, out int x, out int y) {
      x = tim / 60 * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH;
      y = (km + 1) * Configuration.Y_DIST;
    }

    static void time_to_time(grid g, int x, int y, int nx, int ny, int type) {
      int color = fieldcolors[(int)fieldcolor.COL_TRAIN1 + type];

      if(nx < x)	/* ignore if arrival is next day */
        return;
      g.DrawLine(x, y - 1, nx, y - 1, color);
      g.DrawLine(x, y, nx, y, color);
      g.DrawLine(x, y + 1, nx, y + 1, color);
    }

    public static bool samestation(String st, String arrdep) {
      return wxStrcmp(st, arrdep) == 0;
    }

    static void addSegment(Train trn, int x0, int x1, int y, long timein, long timeout, Train parent) {
      PlatformSegment segment = new PlatformSegment();

      segment.train = trn;
      segment.x0 = x0;
      segment.x1 = x1;
      segment.y = y;
      segment.timein = timein;
      segment.timeout = timeout;
      segment.parent = parent;
      segment.next = segments;
      Globals.segments = segment;
    }
  }

  public class PlatformGraphView : ScrolledWindow {
    private ToolTip m_tooltip;

    private void DrawStations(grid g) {
      Track t;
      int y = Configuration.HEADER_HEIGHT;

      Globals.nstations = 0;
      for(t = Globals.layout; t != null && Globals.nstations < 100; t = t.next) {
        if(!t.isstation || string.IsNullOrEmpty(t.station))
          continue;
        Globals.stations[Globals.nstations++] = t;
        Globals.DrawTimeGrid(g, y);
        g.DrawText1(0, y - 10, t.station, false);
        g.DrawLine(Configuration.STATION_WIDTH + Configuration.KM_WIDTH, y,
      Configuration.STATION_WIDTH + Configuration.KM_WIDTH + 24 * 120, y, 0);
        y += Configuration.Y_DIST;
      }
      if(Globals.nstations == 0) {
        g.DrawText1(10, 10, wxPorting.L("Sorry, this feature is not available on this scenario."), false);
        g.DrawText1(10, 25, wxPorting.L("No station was found on the layout."), false);
      }
    }

    private void DrawTrains(grid g) {
      //Train	t;
      //TrainStop ts;
      //Track	trk;
      //int	indx;
      //int	x, y;
      //int	nx, ny;

      //for(t = Globals.schedule; t != null; t = t.next) {
      //  if(t.days != 0 && Globals.run_day != 0 && (t.days & Globals.run_day) == 0)
      //  continue;
      //    x = y = -1;
      //    for(trk = Globals.layout; trk != null; trk = trk.next) {
      //  if(trk.type == trktype.TRACK && trk.isstation &&
      //        Globals.samestation(trk.station, t.entrance))
      //      break;
      //    }
      //    if(trk != null && (indx = Globals.graphstation(trk.station)) >= 0) {
      //      Globals.graph_xy(indx, t.timein, out x, out y);
      //  if(String.IsNullOrEmpty(t.waitfor) == false) {
      //    Train parent = Globals.findTrainNamed(t.waitfor);
      //      if(parent != null) {
      //        Globals.graph_xy(indx, parent.timeout, out nx, out ny);
      //    Globals.time_to_time(g, x, y, nx, ny, t.type);
      //    Globals.addSegment(t, x, nx, y, parent.timeout, t.timein, parent);
      //      }
      //  }
      //    }
      //    for(ts = t.stops; ts != null; ts = ts.next) {
      //  indx = Globals.graphstation(ts.station);
      //  if(indx < 0)
      //      continue;
      //  Globals.graph_xy(indx, ts.arrival, out nx, out ny);
      //  Globals.graph_xy(indx, ts.departure, out x, out y);
      //  Globals.time_to_time(g, nx, ny, x, y, t.type);
      //  Globals.addSegment(t, nx, x, y, ts.arrival, ts.departure, 0);
      //    }
      //    if(String.IsNullOrEmpty(t.stock) == false) {
      //      for(trk = Globals.layout; trk != null; trk = trk.next) {
      //      if(trk.type == trktype.TRACK && trk.isstation &&
      //            Globals.samestation(trk.station, t.exit))
      //    break;
      //  }
      //      if(trk && (indx = Globals.graphstation(trk.station)) >= 0) {
      //        Train child = Globals.findTrainNamed(t.stock);
      //      if(child != null) {
      //        Globals.graph_xy(indx, t.timeout, out x, out y);
      //        Globals.graph_xy(indx, child.timein, out nx, out ny);
      //        Globals.time_to_time(g, x, y, nx, ny, t.type);
      //        Globals.addSegment(child, x, nx, y, t.timeout, child.timein, t);
      //      }
      //  }
      //    }
      //}
    }

    public PlatformGraphView(Window parent)
      : base(parent, wxID_ANY, new Point(0, 0), new Size(Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX)) {
      //    EVT_MOTION(new wx.EventListener(OnMouseMove));
      //    EVT_PAINT(new wx.EventListener(OnPaint));

      //    SetScrollbars(1, 1, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      //    grid g = new grid(this, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      //    Globals.platform_graph_grid = g;
      //  m_tooltip = null;
      //  ToolTip.SetDelay(1000);
      //  ToolTip.Enable(true);
      //  g.Clear();
    }

    public override void Refresh() {
      //grid	g = platform_graph_grid;

      //g.Clear();
      //while(Globals.segments != null) {
      //  PlatformSegment next = Globals.segments.next;
      //  Globals.free(Globals.segments);
      //  Globals.segments = next;
      //}
      //DrawStations(g);
      //Globals.DrawTimeGrid(g, 0);
      //DrawTrains(g);
      //base.Refresh();
    }

    public void OnPaint(object sender, Event evt) {
      if(Globals.platform_graph_grid != null)
        Globals.platform_graph_grid.Paint(this);
    }

    private Point GetEventPosition(Point pt) {
      throw new NotImplementedException();

      //double	xScale, yScale;
      //Point	pos = new Point(pt.X, pt.Y);
      //CalcUnscrolledPosition(pos.X, pos.Y, out pos.X, out pos.Y);
      //Globals.field_grid.m_dc.GetUserScale(out xScale, out yScale);
      //pos.X /= xScale;
      //pos.Y /= yScale;
      //return pos;
    }

    public void OnMouseMove(object sender, Event evt) {
      //  Point pos = ((MouseEvent)evt).Position;
      //  pos = GetEventPosition(pos);

      //  Coord	coord = new Coord(pos.X, pos.Y);

      //  char[] oldTooltip = new char[Globals.tooltipString.Length];
      //  oldTooltip = String.Copy(Globals.tooltipString);

      //  PlatformSegment segment;

      //  for(segment = Globals.segments; Globals.segment != null; segment = segment.next) {
      //      if(pos.X >= segment.x0 && pos.X < segment.x1 &&
      //    pos.Y >= segment.y - 2 && pos.Y < segment.y + 2) {
      //    if(segment.parent != null) {
      //      String.Format(Globals.tooltipString, wxPorting.L("Train %s              \nArrives %s\n"),
      //      segment.parent.name, Globals.format_time(segment.timein));
      //      Globals.wxSprintf(Globals.tooltipString + Globals.wxStrlen(Globals.tooltipString),
      //      wxPorting.L("Departs %s\nas train %s"), Globals.format_time(segment.timeout), segment.train.name);
      //    } else {
      //      Globals.tooltipString = String.Format(
      //      wxPorting.L("Train %s              \nArrives %s\n"),
      //      segment.train.name, Globals.format_time(segment.timein));
      //      Globals.wxSprintf(Globals.tooltipString + Globals.wxStrlen(Globals.tooltipString),
      //      wxPorting.L("Departs %s\n"), Globals.format_time(segment.timeout));
      //    }
      //    break;
      //      }
      //  }
      //  if(Globals.segment == null) {
      //      SetToolTip(0);
      //      m_tooltip = null;
      //      Globals.tooltipString[0] = 0;
      //  } else if(Globals.wxStrcmp(oldTooltip, Globals.tooltipString) == 0) {
      //#if WIN32
      //    ToolTip newTip = new ToolTip(Globals.tooltipString);
      //      SetToolTip(newTip);
      //      m_tooltip = newTip;
      //#else
      ////	    canvasHelp.AddHelp(this, tooltipString);
      ////	    canvasHelp.ShowHelp(this);
      ////	    canvasHelp.RemoveHelp(this);
      //#endif
      //  }
      //  evt.Skip();
    }

  }
}