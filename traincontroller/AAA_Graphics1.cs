using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  static partial class GlobalVariables {
    public static edittools[] tooltbltracks = new edittools[] {  /* used when screen is 800x600 */
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.TRACK, trkdir.TRK_N_S, 0, 1),
	    new edittools(trktype.TRACK, trkdir.W_E, 1, 1),
	    new edittools(trktype.TRACK, trkdir.NW_SE, 2, 1),
	    new edittools(trktype.TRACK, trkdir.SW_NE, 3, 1),
	    new edittools(trktype.TRACK, trkdir.W_NE, 4, 1),
	    new edittools(trktype.TRACK, trkdir.W_SE, 5, 1),
	    new edittools(trktype.TRACK, trkdir.NW_E, 6, 1),
	    new edittools(trktype.TRACK, trkdir.SW_E, 7, 1),
	    new edittools(trktype.TRACK, trkdir.NW_S, 8, 1),
	    new edittools(trktype.TRACK, trkdir.SW_N, 9, 1),
	    new edittools(trktype.TRACK, trkdir.NE_S, 10, 1),
	    new edittools(trktype.TRACK, trkdir.SE_N, 11, 1),
	    new edittools(trktype.TRACK, trkdir.XH_NW_SE, 12, 1),
	    new edittools(trktype.TRACK, trkdir.XH_SW_NE, 13, 1),
	    new edittools(trktype.TRACK, trkdir.X_X, 14, 1),
	    new edittools(trktype.TRACK, trkdir.X_PLUS, 15, 1),
      new edittools(trktype.TRACK, trkdir.N_NE_S_SW, 16, 1),	// no switch  / |
	    new edittools(trktype.TRACK, trkdir.N_NW_S_SE, 17, 1),	// no switch  \ |
    	new edittools()
    };

    public static edittools[] tooltbl = tooltbltracks; /* tooltbl800 */

    public static edittools[] tooltblswitches = new edittools[] {
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.SWITCH, 0, 0, 1),
	    new edittools(trktype.SWITCH, 1, 1, 1),
	    new edittools(trktype.SWITCH, 2, 2, 1),
	    new edittools(trktype.SWITCH, 3, 3, 1),
	    new edittools(trktype.SWITCH, 4, 4, 1),
	    new edittools(trktype.SWITCH, 5, 5, 1),
	    new edittools(trktype.SWITCH, 6, 6, 1),
	    new edittools(trktype.SWITCH, 7, 7, 1),
	    new edittools(trktype.SWITCH, 8, 8, 1),
	    new edittools(trktype.SWITCH, 9, 9, 1),
	    new edittools(trktype.SWITCH, 10, 10, 1),
	    new edittools(trktype.SWITCH, 11, 11, 1),

	    new edittools(trktype.SWITCH, 12, 12, 1),	    /* vertical switches */
	    new edittools(trktype.SWITCH, 13, 13, 1),
	    new edittools(trktype.SWITCH, 14, 14, 1),
	    new edittools(trktype.SWITCH, 15, 15, 1),
	    new edittools(trktype.SWITCH, 16, 16, 1),
	    new edittools(trktype.SWITCH, 17, 17, 1),
	    new edittools(trktype.SWITCH, 18, 18, 1),
	    new edittools(trktype.SWITCH, 19, 19, 1),
	    new edittools(trktype.SWITCH, 20, 20, 1),
	    new edittools(trktype.SWITCH, 21, 21, 1),
	    new edittools(trktype.SWITCH, 22, 22, 1),
	    new edittools(trktype.SWITCH, 23, 23, 1),
	    new edittools()
    };
    
public static edittools[] tooltblsignals = new edittools[] {
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.TSIGNAL, 0, 0, 1),
	    new edittools(trktype.TSIGNAL, 1, 1, 1),
	    new edittools(trktype.TSIGNAL, 2, 2, 1),
	    new edittools(trktype.TSIGNAL, 3, 3, 1),
	    new edittools(trktype.TSIGNAL, trkdir.S_N, 4, 1),
	    new edittools(trktype.TSIGNAL, trkdir.N_S, 5, 1),
	    new edittools(trktype.TSIGNAL, trkdir.signal_NORTH_FLEETED, 6, 1),
	    new edittools(trktype.TSIGNAL, trkdir.signal_SOUTH_FLEETED, 7, 1),
	    new edittools()
};
public static edittools[] tooltblmisc = new edittools[] {
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.TEXT, 0, 0, 1),
	    new edittools(trktype.TEXT, 1, 1, 1),
	    new edittools(trktype.ITIN, 0, 2, 1),
	    new edittools(trktype.ITIN, 1, 3, 1),
	    new edittools(trktype.IMAGE, 1, 4, 1),
	    new edittools(trktype.PLATFORM, 1, 5, 1),
	    new edittools()
};
public static edittools[] tooltblactions = new edittools[] {
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.LINK, 0, 0, 1),
	    new edittools(trktype.LINK, 1, 1, 1),
	    new edittools(trktype.MACRO, 0, 2, 1),
	    new edittools(trktype.MACRO, 1, 3, 1),
	    new edittools(trktype.TRIGGER, trkdir.W_E, 4, 1),
	    new edittools(trktype.TRIGGER, trkdir.E_W, 5, 1),
	    new edittools(trktype.TRIGGER, trkdir.N_S, 6, 1),
	    new edittools(trktype.TRIGGER, trkdir.S_N, 7, 1),
	    new edittools(trktype.MOVER, 0, 8, 1),
	    new edittools(trktype.MOVER, 1, 9, 1),
	    new edittools(trktype.MOVER, 2, 10, 1),
	    new edittools(trktype.POWERTOOL, 0, 11, 1),
	    new edittools()
};

    
public static edittools[] tooltbl800 = new edittools[] { /* used when screen is 800x600 */
	    new edittools(trktype.TEXT, 0, 0, 0),
	    new edittools(trktype.TRACK, trkdir.W_E, 0, 1),
	    new edittools(trktype.TRACK, trkdir.NW_SE, 1, 0),
	    new edittools(trktype.TRACK, trkdir.SW_NE, 1, 1),
	    new edittools(trktype.TRACK, trkdir.W_NE, 2, 0),
	    new edittools(trktype.TRACK, trkdir.W_SE, 2, 1),
	    new edittools(trktype.TRACK, trkdir.NW_E, 3, 0),
	    new edittools(trktype.TRACK, trkdir.SW_E, 3, 1),
	    new edittools(trktype.TRACK, trkdir.XH_NW_SE, 15, 0),
	    new edittools(trktype.TRACK, trkdir.XH_SW_NE, 15, 1),
	    new edittools(trktype.TRACK, trkdir.X_X, 16, 0),
	    new edittools(trktype.TRACK, trkdir.X_PLUS, 16, 1),
	    new edittools(trktype.SWITCH, 0, 4, 0),
	    new edittools(trktype.SWITCH, 1, 4, 1),
	    new edittools(trktype.SWITCH, 2, 5, 0),
	    new edittools(trktype.SWITCH, 3, 5, 1),
	    new edittools(trktype.SWITCH, 4, 6, 0),
	    new edittools(trktype.SWITCH, 5, 6, 1),
	    new edittools(trktype.SWITCH, 10, 7, 0),
	    new edittools(trktype.SWITCH, 11, 7, 1),
	    new edittools(trktype.SWITCH, 6, 8, 0),
	    new edittools(trktype.SWITCH, 7, 8, 1),
	    new edittools(trktype.SWITCH, 8, 9, 0),
	    new edittools(trktype.SWITCH, 9, 9, 1),

	    new edittools(trktype.SWITCH, 12, 10, 0),	    /* vertical switches */
	    new edittools(trktype.SWITCH, 13, 10, 1),
	    new edittools(trktype.SWITCH, 14, 11, 0),
	    new edittools(trktype.SWITCH, 15, 11, 1),
	    new edittools(trktype.TRACK, trkdir.NW_S, 12, 0),
	    new edittools(trktype.TRACK, trkdir.SW_N, 12, 1),
	    new edittools(trktype.TRACK, trkdir.NE_S, 13, 0),
	    new edittools(trktype.TRACK, trkdir.SE_N, 13, 1),
	    new edittools(trktype.TRACK, trkdir.TRK_N_S, 14, 0),
	    new edittools(trktype.ITIN, 0, 14, 1),
	    new edittools(trktype.IMAGE, 1, 15, 2),
	    new edittools(trktype.PLATFORM, 1, 0, 2),
	    new edittools(trktype.TSIGNAL, 0, 1, 2),
	    new edittools(trktype.TSIGNAL, 1, 2, 2),
	    new edittools(trktype.TSIGNAL, 2, 3, 2),
	    new edittools(trktype.TSIGNAL, 3, 4, 2),
	    new edittools(trktype.TSIGNAL, trkdir.S_N, 5, 2),
	    new edittools(trktype.TSIGNAL, trkdir.N_S, 6, 2),
	    new edittools(trktype.TSIGNAL, trkdir.signal_NORTH_FLEETED, 7, 2),
	    new edittools(trktype.TSIGNAL, trkdir.signal_SOUTH_FLEETED, 8, 2),
	    new edittools(trktype.TEXT, 0, 9, 2),
	    new edittools(trktype.TEXT, 1, 10, 2),
	    new edittools(trktype.LINK, 0, 11, 2),
	    new edittools(trktype.LINK, 1, 12, 2),
	    new edittools(trktype.MACRO, 0, 13, 2),
	    new edittools(trktype.MACRO, 1, 14, 2),
	    new edittools(trktype.TRIGGER, trkdir.W_E, 17, 0),
	    new edittools(trktype.TRIGGER, trkdir.E_W, 17, 1),
	    new edittools(trktype.TRIGGER, trkdir.N_S, 18, 0),
	    new edittools(trktype.TRIGGER, trkdir.S_N, 18, 1),
	    new edittools()
};
  }
}