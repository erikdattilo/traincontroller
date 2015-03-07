using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class VLines {
    public int x0, y0;
    public int x1, y1;

    public VLines(int x0_, int y0_, int x1_, int y1_) {
      x0 = x0_;
      x1 = x1_;
      y0 = y0_;
      y1 = y1_;
    }

    public VLines(int all)
      : this(all, all, all, all) {
    }
  }
}
