using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {

  public enum trkdir {
    NODIR = 0,
    W_E = 1,
    NW_SE = 2,
    SW_NE = 3,
    W_NE = 4,
    W_SE = 5,
    NW_E = 6,
    SW_E = 7,
    TRK_N_S = 8,
    E_W = NODIR,

    signal_WEST_FLEETED = 9,
    signal_EAST_FLEETED = 10,
    N_S_W = signal_WEST_FLEETED,
    N_S_E = signal_EAST_FLEETED,
    SW_N = 11,
    NW_S = 12,
    SE_N = 13,
    NE_S = 14,
    N_S = 16,		/* must be 16 because of signals */
    S_N = 17,
    signal_SOUTH_FLEETED = 18,
    signal_NORTH_FLEETED = 19,
    XH_NW_SE = 20,
    XH_SW_NE = 21,
    X_X = 22,		/* X (no switch) */
    X_PLUS = 23,		/* + (no switch) */
    N_NE_S_SW = 24,		// no switch / |
    N_NW_S_SE = 25		// no switch \ |
  }
}
