using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {

  public class TimeTableViewManager {
    public TimeTableView GetNewTimeTableView(Window parent, String name) {
      int i;

      for(i = 0; i < Configuration.NUMTTABLES; ++i) {
        if(m_timeTableList[i] == null)
          break;
      }
      if(i >= Configuration.NUMTTABLES)
        return null;
      TimeTableView pTimeTable = new TimeTableView(parent, name);
      m_timeTableList[i] = pTimeTable;
      return pTimeTable;
    }

    public bool IsTimeTable(Window pWin) {
      int i;
      for(i = 0; i < Configuration.NUMTTABLES; ++i)
        if(pWin == m_timeTableList[i])
          return true;
      return false;
    }

    public TimeTableView GetTimeTable(int i) {
      if(i >= Configuration.NUMTTABLES)
        return null;
      return m_timeTableList[i];
    }

    public Window m_parent;
    public TimeTableView[] m_timeTableList = new TimeTableView[Configuration.NUMTTABLES];
  }

}
