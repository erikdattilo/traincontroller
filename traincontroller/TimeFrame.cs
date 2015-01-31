using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class TimeFrame : Frame {
    public MainFrame m_parent;

    public TimeFrame(MainFrame parent, string title)
      : base(parent, (int)MenuIDs2.wxID_ANY, title) {
      EVT_CLOSE(new EventListener(OnClose));

      m_parent = parent;
    }
    
    public void OnClose(object sender, Event evt) {
      MenuItem pItem;

      m_parent.m_timeTable.Reparent(m_parent.m_top);
      m_parent.m_top.AddPage(m_parent.m_timeTable, wxPorting.L("Schedule"), false, -1);
      m_parent.m_timeTableLocation = TimaTableLocation.TIME_TABLE_TAB;
      m_parent.m_timeFrame = null;
      Menu tmpMenu = null;
      if((pItem = m_parent.MenuBar.FindItem((int)TimaTableLocation.TIME_TABLE_TAB, ref tmpMenu)) != null)
        pItem.Checked = true;
      evt.Skip();
    }

  }
}