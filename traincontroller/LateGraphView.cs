using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  class LateGraphView : ScrolledWindow {
    public LateGraphView(Window parent)
      : base(parent, (int)MenuIDs2.wxID_ANY, new Point(0, 0), new Size(Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX)) {

      EVT_PAINT(new EventListener(OnPaint));


      SetScrollbars(1, 1, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      grid g = new grid(this, Configuration.XMAX * 2 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      GlobalVariables.late_graph_grid = g;
      g.Clear();
    }

    void OnPaint(object sender, Event evt) {
      if(GlobalVariables.late_graph_grid != null)
        GlobalVariables.late_graph_grid.Paint(this);
    }
  }

}