using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  class AlertListListener { // : EventListener {
    public AlertList _list;

    AlertListListener(AlertList list) {
      _list = list;
    }
#if false
    void OnEvent(object dummy) {
      if(alerts._firstItem == 0) {
        _list.DeleteAllItems();
      } else {
        int nItems = _list.ItemCount;
        int x = 0;
        AlertLine line;
        for(line = alerts._firstItem; line && x < nItems; line = line._next)
          ++x;
        while(line) {
          _list.AddLine(line._text);
          line = line._next;
        }
      }
    }
#endif
  }
}
