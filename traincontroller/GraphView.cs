using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  class GraphView : ScrolledWindow {
    GraphView(Window parent) :
      base(parent, (int)MenuIDs2.wxID_ANY, new Point(0, 0),
      new Size(Configuration.XMAX * 4 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX)
    ) {
      EVT_PAINT(new EventListener(OnPaint));

      SetScrollbars(1, 1, Configuration.XMAX * 4 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      grid g = new grid(this, Configuration.XMAX * 4 + Configuration.STATION_WIDTH + Configuration.KM_WIDTH, Configuration.YMAX);
      GlobalVariables.tgraph_grid = g;
      g.Clear();
    }

    public void OnPaint(object sender, Event evt) {
      if(GlobalVariables.tgraph_grid != null)
        GlobalVariables.tgraph_grid.Paint(this);
    }

  }

}