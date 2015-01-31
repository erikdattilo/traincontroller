/*	NotebookMgr.cpp - Created by Giampiero Caprino

This file is part of Train Director 3

Train Director is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; using exclusively version 2.
It is expressly forbidden the use of higher versions of the GNU
General Public License.

Train Director is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Train Director; see the file COPYING.  If not, write to
the Free Software Foundation, 59 Temple Place - Suite 330,
Boston, MA 02111-1307, USA.
*/
using System;
using wx;
namespace Traincontroller2 {


  public class NotebookManager : Notebook {
    public String m_name;

    public NotebookManager(Window parent, String name, int id)
      : base(parent, id, wxDefaultPosition, wxDefaultSize, WindowStyles.NB_BOTTOM) {
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

    public void RemovePage(Window pView) {
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
      int i;
      int pageCnt = 0;
      String ttheader;

      ttheader = String.Format(wxPorting.T("%s-%s"), header, m_name);
      state.StartSection(ttheader);
      state.PutInt(wxPorting.T("nPages"), PageCount);

      for(i = 0; i < PageCount; ++i) {
        Window pPage = GetPage(i);
        String type = pPage.Name;

        ttheader = String.Format(wxPorting.T("%s-%s-%d"), header, m_name, pageCnt++);

        if(type == wxPorting.T("timetable") || type == wxPorting.T("itinerary") ||
           type == wxPorting.T("alerts") || type == wxPorting.T("traininfo")) {
          ReportBase pReport = (ReportBase)pPage;
          pReport.SaveState(ttheader, state);
        }
      }
    }

    public void LoadState(String header, TConfig state) {
      String ttheader;
      String tabhdr;
      int nTabs;
      int nt;

      ttheader = String.Format(wxPorting.T("%s-%s"), header, m_name);
      state.PushSection(ttheader);
      state.GetInt(wxPorting.T("nPages"), out nTabs);

      for(nt = 0; nt < nTabs; ++nt) {
        tabhdr = String.Format(wxPorting.T("%s-%s-%d"), header, m_name, nt);
        String name = "";
        ReportBase pReport;

        if(!state.PushSection(tabhdr))
          continue;
        state.GetString(wxPorting.T("type"), out name);
        if(name == wxPorting.T("timetable")) {
          //		state.GetString(wxPorting.T("name"), name);
          name = wxPorting.T("Schedule");
          //		TimeTableView *pTimeTable = Globals.traindir.m_frame.m_timeTableManager.GetNewTimeTableView(this, name);
          //		pReport = pTimeTable;
          pReport = Globals.traindir.m_frame.m_timeTable;
          //	    } else if(name == wxPorting.T("itinerary")) {
          //		state.GetString(wxPorting.T("name"), name);
          //		ItineraryView *pItinerary = Globals.traindir.m_frame.m_itineraryView;
          //		pReport = pItinerary;
        } else if(name == wxPorting.T("alerts")) {
          //		state.GetString(wxPorting.T("name"), name);
          name = wxPorting.T("Alerts");
          pReport = Globals.traindir.m_frame.m_alertList;
        } else if(name == wxPorting.T("traininfo")) {
          //		state.GetString(wxPorting.T("name"), name);
          name = wxPorting.T("Train Info");
          pReport = Globals.traindir.m_frame.m_trainInfo;
        } else
          continue;
        if(FindPage(pReport) < 0)
          AddPage(pReport, wxPorting.LV(name), false, -1);
        String name1;
        name1 = String.Format(wxPorting.T("%s-%s"), ttheader, name);
        pReport.LoadState(tabhdr, state);
        state.PopSection();
      }
      state.PopSection();
    }
  }
}