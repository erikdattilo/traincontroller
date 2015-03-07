using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class grcolor {
    private int mInt;

    private grcolor(int i) {
      mInt = i;
    }

    public static implicit operator grcolor(int i) {
      return new grcolor(i);
    }

    public static implicit operator int(grcolor color) {
      return color == null ? -1 : color.mInt;
    }
  }

  public enum fieldcolor {
    COL_BACKGROUND = 0,
    COL_TRACK = 1,
    COL_GRAPHBG = 2,
    COL_TRAIN1 = 3,
    COL_TRAIN2 = 4,
    COL_TRAIN3 = 5,
    COL_TRAIN4 = 6,
    COL_TRAIN5 = 7,
    COL_TRAIN6 = 8,
    COL_TRAIN7 = 9,
    COL_TRAIN8 = 10,
    COL_TRAIN9 = 11,
    COL_TRAIN10 = 12,
    MAXFIELDCOL
  }
}
