using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class perf {
    public int wrong_dest;
    public int late_trains;
    public int thrown_switch;		/* incorrectly thrown switches */
    public int cleared_signal;		/* incorrectly cleared signals */
    public int denied;			/* command denied */
    public int turned_train;
    public int waiting_train;
    public int wrong_platform;
    public int ntrains_late;
    public int ntrains_wrong;
    public int nmissed_stops;
    public int wrong_assign;

    public perf() {
    }

    public perf(int wrong_dest_, int late_trains_, int thrown_switch_, int cleared_signal_, int denied_, int turned_train_, int waiting_train_, int wrong_platform_, int ntrains_late_, int ntrains_wrong_, int nmissed_stops_, int wrong_assign_) {
      wrong_dest = wrong_dest_;
      late_trains = late_trains_;
      thrown_switch = thrown_switch_;
      cleared_signal = cleared_signal_;
      denied = denied_;
      turned_train = turned_train_;
      waiting_train = waiting_train_;
      wrong_platform = wrong_platform_;
      ntrains_late = ntrains_late_;
      ntrains_wrong = ntrains_wrong_;
      nmissed_stops = nmissed_stops_;
      wrong_assign = wrong_assign_;
    }
  }
}