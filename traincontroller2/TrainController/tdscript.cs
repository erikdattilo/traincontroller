using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  partial class Globals {

    public static void free_scripts() {
      while(scriptList != null) {
        scriptList = scriptList._next;
      }
      // TODO Uncomment following line
      //onIconUpdateListeners.Clear();
    }

  }
}
