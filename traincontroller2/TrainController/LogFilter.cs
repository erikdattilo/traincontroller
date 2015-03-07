using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;
using TrainDirPorting;

namespace TrainController {

  // TODO Implement this class
  public class LogFilter {
    public LogFilter() {
      m_parent = null;
      m_oldLog = null;
    }

    public void SetParent(MainFrame2 pParent) { m_parent = pParent; }

    public MainFrame2 m_parent;
    public Log m_oldLog;
    public String m_extraInfo;

    // ----------------------------------------------------------------------------
    // LogFilter
    // ----------------------------------------------------------------------------

    public void InstallLog() {
      //m_oldLog = wx.Log.GetActiveTarget();
      //wx.Log.SetActiveTarget(this);
    }

    public void UninstallLog() {
      //wx.Log.SetActiveTarget(m_oldLog);
      //m_oldLog = null;
    }

    public void DoLog(wx.Log.eLogLevel level, String szString, time_t t) {
      //if(m_parent.m_alertList != null) {
      //  m_parent.m_alertList.AddLine(m_extraInfo + wxPorting.T(": ") + szString);
      //}
    }

    public void SetExtraInfo(String extra) {
      //m_extraInfo = extra;
    }
  }
}
