using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  class TrackTrigger : Track {
    public override trktype TrackType { get { return trktype.TRIGGER; } }
  }
  public class TrackItinerary : Track {
    public override trktype TrackType { get { return trktype.ITIN; } }
  }
  public class TrackImage : Track {
    public override trktype TrackType { get { return trktype.IMAGE; } }
  }
  public class TrackText : Track {
    public override trktype TrackType { get { return trktype.TEXT; } }
  }
  public class TrackPlatform : Track {
    public override trktype TrackType { get { return trktype.PLATFORM; } }
  }
  public class TrackSignal : Signal {
    public override trktype TrackType { get { return trktype.TSIGNAL; } }
  }
  public class TrackSwitch : Track {
    public override trktype TrackType { get { return trktype.SWITCH; } }
  }

}
