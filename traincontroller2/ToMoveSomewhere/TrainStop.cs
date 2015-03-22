using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class TrainStop {
    public TrainStop next;
    public Station station;	/* stop at this station */
    public TimeSpan arrival;	/* scheduled arrival time */
    public TimeSpan departure;	/* scheduled departure time */
    public int minstop;	/* minimum number of sec. stopping at station */
    //public int stopped;	/* we did indeed stop here */
    //public int late;		/* we were late arriving here */
    public int delay;		/* delay arriving at this station */
    public TDDelay depDelay;	/* random departure delay, if any */
  }
}
