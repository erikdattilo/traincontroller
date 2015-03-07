using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {
  public class NotebookManager : Notebook {
    public String m_name;

    public NotebookManager(Window parent, String name, int id)
      : base(parent, id, wxDefaultPosition, wxDefaultSize, WindowStyles.NB_BOTTOM)
    {
      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_TOP, new wx.EventListener(OnPageChanged));
      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_LEFT, new wx.EventListener(OnPageChanged));
      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_RIGHT, new wx.EventListener(OnPageChanged));

      m_name = name;
    }

    public void OnPageChanged(object sender, Event evt) {
      evt.Skip();
    }

    public int FindPage(Window w) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        if(pPage == w) {
          return i;
        }
      }
      return -1;
    }

    public int FindPage(String title) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        String name = GetPageText(i);
        if(title == name) {
          return i;
        }
      }
      return -1;
    }

    public int FindPageType(String name) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        if(pPage.Name == wxPorting.T("traininfo")) {
          return i;
        }
      }
      return -1;
    }

    public void RemovePage(object/*Window*/ pView) {
      //Window pChild;
      //int i;

      //for(i = 0; i < PageCount; ++i) {
      //  pChild = GetPage(i);
      //  if(pChild == pView) {
      //    wxNotebook.RemovePage(i);
      //    break;
      //  }
      //}
    }

    public void SaveState(String header, TConfig state) {
      throw new NotImplementedException();
      //int i;
      //int pageCnt = 0;
      //String ttheader;

      //ttheader = String.Format(wxPorting.T("%s-%s"), header, m_name);
      //state.StartSection(ttheader);
      //state.PutInt(wxPorting.T("nPages"), PageCount);

      //for(i = 0; i < PageCount; ++i) {
      //  Window pPage = GetPage(i);
      //  String type = pPage.Name;

      //  ttheader = String.Format(wxPorting.T("%s-%s-%d"), header, m_name, pageCnt++);

      //  if(type == wxPorting.T("timetable") || type == wxPorting.T("itinerary") ||
      //     type == wxPorting.T("alerts") || type == wxPorting.T("traininfo")) {
      //    ReportBase pReport = (ReportBase)pPage;
      //    pReport.SaveState(ttheader, state);
      //  }
      //}
    }

    public void LoadState(String header, TConfig state) {
      throw new NotImplementedException();
      //String ttheader;
      //String tabhdr;
      //int nTabs;
      //int nt;

      //ttheader = String.Format(wxPorting.T("%s-%s"), header, m_name);
      //state.PushSection(ttheader);
      //state.GetInt(wxPorting.T("nPages"), out nTabs);

      //for(nt = 0; nt < nTabs; ++nt) {
      //  tabhdr = String.Format(wxPorting.T("%s-%s-%d"), header, m_name, nt);
      //  String name = "";
      //  ReportBase pReport;

      //  if(!state.PushSection(tabhdr))
      //    continue;
      //  state.GetString(wxPorting.T("type"), out name);
      //  if(name == wxPorting.T("timetable")) {
      //    //		state.GetString(wxPorting.T("name"), name);
      //    name = wxPorting.T("Schedule");
      //    //		TimeTableView *pTimeTable = Globals.traindir.m_frame.m_timeTableManager.GetNewTimeTableView(this, name);
      //    //		pReport = pTimeTable;
      //    pReport = Globals.traindir.m_frame.m_timeTable;
      //    //	    } else if(name == wxPorting.T("itinerary")) {
      //    //		state.GetString(wxPorting.T("name"), name);
      //    //		ItineraryView *pItinerary = Globals.traindir.m_frame.m_itineraryView;
      //    //		pReport = pItinerary;
      //  } else if(name == wxPorting.T("alerts")) {
      //    //		state.GetString(wxPorting.T("name"), name);
      //    name = wxPorting.T("Alerts");
      //    pReport = Globals.traindir.m_frame.m_alertList;
      //  } else if(name == wxPorting.T("traininfo")) {
      //    //		state.GetString(wxPorting.T("name"), name);
      //    name = wxPorting.T("Train Info");
      //    pReport = Globals.traindir.m_frame.m_trainInfo;
      //  } else
      //    continue;
      //  if(FindPage(pReport) < 0)
      //    AddPage(pReport, wxPorting.LV(name), false, -1);
      //  String name1;
      //  name1 = String.Format(wxPorting.T("%s-%s"), ttheader, name);
      //  pReport.LoadState(tabhdr, state);
      //  state.PopSection();
      //}
      //state.PopSection();
    }
  }
}
