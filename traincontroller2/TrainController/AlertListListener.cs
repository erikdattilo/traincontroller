using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {

  public class AlertListListener { // : EventListener {

    public AlertListListener(AlertList list) { _list = list; }
    ~AlertListListener() { }

    public AlertList _list;

    //public override void OnEvent(object dummy) {
    //  if(Globals.alerts._firstItem == null) {
    //    _list.DeleteAllItems();
    //  } else {
    //    int nItems = _list.ItemCount;
    //    int x = 0;
    //    AlertLine line;
    //    for(line = Globals.alerts._firstItem; line != null && x < nItems; line = line._next)
    //      ++x;
    //    while(line != null) {
    //      _list.AddLine(line._text);
    //      line = line._next;
    //    }
    //  }
    //}
  }
}
