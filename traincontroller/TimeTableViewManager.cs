using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {

  public class TimeTableViewManager {
    Window m_parent;
    TimeTableView[] m_timeTableList = new TimeTableView[Configuration.NUMTTABLES];

    public TimeTableViewManager() {
    }

    public TimeTableView GetNewTimeTableView(Window parent, string name) {
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

    void ReleaseTimeTableView() {
    }
    bool IsTimeTable(Window pWin) {
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
  }
}