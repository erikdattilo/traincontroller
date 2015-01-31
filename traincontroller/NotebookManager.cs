using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class NotebookManager : Notebook {
    public string m_name;
    public NotebookManager(Window parent, string name, int id)
      : base(parent, id, wxDefaultPosition, wxDefaultSize, WindowStyles.NB_BOTTOM) {
      m_name = name;

      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_TOP, new EventListener(OnPageChanged));
      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_LEFT, new EventListener(OnPageChanged));
      EVT_NOTEBOOK_PAGE_CHANGED((int)MenuIDs.ID_NOTEBOOK_RIGHT, new EventListener(OnPageChanged));
    }

    ~NotebookManager() {
    }

    void OnPageChanged(object sender, Event evt) {
      evt.Skip();
    }

    int FindPage(Window w) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        if(pPage == w) {
          return i;
        }
      }
      return -1;
    }

    public int FindPage(string title) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        string name = GetPageText(i);
        if(title == name) {
          return i;
        }
      }
      return -1;
    }

    int FindPageType(string name) {
      int i;

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        if("traininfo".Equals(pPage.Name)) {
          return i;
        }
      }
      return -1;
    }

    void RemovePage(Window pView) {
      Window pChild;
      int i;

      for(i = 0; i < PageCount; ++i) {
        pChild = GetPage(i);
        if(pChild == pView) {
          RemovePage(i);
          break;
        }
      }
    }

    void SaveState(string header, TConfig state) {
      int i;
      int pageCnt = 0;
      string ttheader;

      ttheader = String.Format("{0}-{1}", header, m_name);
      state.StartSection(ttheader);
      state.PutInt(wxPorting.T("nPages"), PageCount);

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        string type = pPage.Name;

        ttheader = String.Format("{0}-{1}-{2}", header, m_name, pageCnt++);

        if(type == wxPorting.T("timetable") || type == wxPorting.T("itinerary") ||
           type == wxPorting.T("alerts") || type == wxPorting.T("traininfo")) {
          ReportBase pReport = (ReportBase)pPage;
          pReport.SaveState(ttheader, state);
        }
      }
    }

    void LoadState(string header, TConfig state) {
      string ttheader;
      string tabhdr;
      int nTabs;
      int nt;

      ttheader = String.Format("{0}-{1}", header, m_name);
      state.PushSection(ttheader);
      state.GetInt(wxPorting.T("nPages"), out nTabs);

      for(nt = 0; nt < nTabs; ++nt) {
        tabhdr = String.Format("{0}-{1}-{2}", header, m_name, nt);
        string name;
        ReportBase pReport = null;

        if(!state.PushSection(tabhdr))
          continue;

        state.GetString(wxPorting.T("type"), out name);
        if(name == wxPorting.T("timetable")) {
          name = wxPorting.T("Schedule");
          /// TODO
          // pReport = GlobalVariables.traindir.m_frame.m_timeTable;
        } else if("alerts".Equals(name)) {
          name = wxPorting.T("Alerts");
          /// TODO
          // pReport = GlobalVariables.traindir.m_frame.m_alertList;
        } else if("traininfo".Equals(name)) {
          name = wxPorting.T("Train Info");
          /// TODO
          // pReport = GlobalVariables.traindir.m_frame.m_trainInfo;
        } else {
          continue;
        }

        if(FindPage(pReport) < 0)
          AddPage(pReport, wxPorting.LV(name), false, -1);
        string name1;
        name1 = String.Format("{0}-{1}", ttheader, name);
        pReport.LoadState(tabhdr, state);
        state.PopSection();
      }
      state.PopSection();
    }
  }
}