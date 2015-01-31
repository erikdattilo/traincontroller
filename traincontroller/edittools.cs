using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class edittools {
    public trktype type;
    public trkdir direction;
    public int x, y;
    public Track trk;

    public edittools() {
    }

    public edittools(trktype type_, int direction_, int x_, int y_) 
    :this(type_, (trkdir)direction_, x_, y_) {
    }

    public edittools(trktype type_, trkdir direction_, int x_, int y_) {
      type = type_;
      direction = direction_;
      x = x_;
      y = y_;
    }
  }
}
