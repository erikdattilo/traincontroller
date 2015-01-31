using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  class PlatformGraphView : ScrolledWindow {
    private ToolTip m_tooltip;

    public PlatformGraphView(Window parent)
      : base(parent, (int)MenuIDs2.wxID_ANY, new Point(0, 0), new Size(Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX)) {
      {
        EVT_MOTION(new EventListener(OnMouseMove));
        EVT_PAINT(new EventListener(OnPaint));

        SetScrollbars(1, 1, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
        grid g = new grid(this, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);

        GlobalVariables.platform_graph_grid = g;
        m_tooltip = null;
        // wxToolTip::SetDelay(1000);
        // wxToolTip::Enable(true);
        g.Clear();
      }
    }

    void OnPaint(object sender, Event evt) {
      if(GlobalVariables.platform_graph_grid != null)
        GlobalVariables.platform_graph_grid.Paint(this);
    }

    void OnMouseMove(object sender, Event evt) {
      Point pos = ((MouseEvent)evt).Position;
      // pos = GetEventPosition(pos);

      string oldTooltip;
      oldTooltip = string.Copy(GlobalVariables.tooltipString);

      PlatformSegment segment;

      for(segment = GlobalVariables.segments; segment != null; segment = segment.next) {
        if(pos.X >= segment.x0 && pos.X < segment.x1 &&
      pos.Y >= segment.y - 2 && pos.Y < segment.y + 2) {
          if(segment.parent != null) {
            GlobalVariables.tooltipString = string.Format(
              wxPorting.L("Train %s              \nArrives %s\n"),
              segment.parent.name, GlobalFunctions.format_time(segment.timein)
            );
            GlobalVariables.tooltipString += String.Format(
              wxPorting.L("Departs %s\nas train %s"), GlobalFunctions.format_time(segment.timeout), segment.train.name
            );
          } else {
            GlobalVariables.tooltipString = string.Format(
              wxPorting.L("Train %s              \nArrives %s\n"),
              segment.train.name, GlobalFunctions.format_time(segment.timein)
            );
            GlobalVariables.tooltipString = string.Format(
              wxPorting.L("Departs %s\n"), GlobalFunctions.format_time(segment.timeout)
            );
          }

          break;
        }
      }
      if(segment != null) {
        this.ToolTip = null;
        m_tooltip = null;
        GlobalVariables.tooltipString = "";
      } else if(oldTooltip.Equals(GlobalVariables.tooltipString)) {
#if WIN32
	    wxToolTip *newTip = new wxToolTip(tooltipString);
	    SetToolTip(newTip);
//	    if(m_tooltip)
//		delete m_tooltip;
	    m_tooltip = newTip;
#else
        //	    canvasHelp.AddHelp(this, tooltipString);
        //	    canvasHelp.ShowHelp(this);
        //	    canvasHelp.RemoveHelp(this);
#endif
      }
      evt.Skip();
    }


  }
}