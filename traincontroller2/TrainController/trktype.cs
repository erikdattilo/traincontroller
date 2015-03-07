using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public enum trktype {
    NOTRACK = 0,
    TRACK = 1,
    SWITCH = 2,
    PLATFORM = 3,
    TSIGNAL = 4,
    TRAIN = 5,
    TEXT = 6,
    LINK = 7,		/* not a real track - for the editor */
    IMAGE = 8,		/* for stations, bridges etc. */
    MACRO = 9,		/* editor only - not to be saved */
    ITIN = 10,		/* itinerary */
    TRIGGER = 11,		/* trigger point linked to track */
    MOVER = 12,		/* not a real track - for the editor */
    POWERTOOL = 13          /* not a real track - for the editor */
  }
}
