using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDirNET {
  public class VLines {
    public long x0, y0;
    public long x1, y1;

    public VLines(long x0_, long y0_, long x1_, long y1_) {
      x0 = x0_;
      x1 = x1_;
      y0 = y0_;
      y1 = y1_;
    }

    public VLines(long all)
      : this(all, all, all, all) {
    }
  }
}
