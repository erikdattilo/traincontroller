using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public enum trainstat {
    train_READY,
    train_RUNNING,
    train_STOPPED,
    train_DELAY,
    train_WAITING,
    train_DERAILED,			/* couldn't place on territory! */
    train_ARRIVED,			/* reached some destination */
    train_STARTING,                 // starting after a stop at signal
    /*train_SHUNTING*/
    /* going to next station at 30Km/h */
  }
}
