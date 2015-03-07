 /*	StationInfoDialog.cpp - Created by Giampiero Caprino
 
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

using wx;
using System;

namespace TrainDirPorting {

  public class StationInfoDialog : Dialog {
    private Choice m_stations;
    private CheckBox m_check;
    private ListCtrl m_stops;

    private static Track[] all_stations;
    private static int station_idx;
    private static int sort_station;

    private static string[] en_titles = new string[] { wxPorting.T("Train"), wxPorting.T("Arrival"), wxPorting.T("From"), wxPorting.T("Departure"), wxPorting.T("To"), wxPorting.T("Plat."), wxPorting.T("Runs on"), wxPorting.T("Notes"), null };
    private static string[] titles = new string[9];

    public StationInfoDialog(Window parent)
      : base(parent, 0, wxPorting.L("Station schedule"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Station schedule")) {
      //EVT_CHECKBOX((int)MenuIDs.ID_CHECKBOX, new wx.EventListener(OnCheckbox));
      //EVT_CHOICE((int)MenuIDs.ID_CHOICE, new wx.EventListener(OnChoice));
      //EVT_BUTTON((int)MenuIDs.ID_PRINT, new wx.EventListener(OnPrint));

      //int i;
      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

      //StaticText txt = new StaticText(this, wxID_ANY, wxPorting.L("&Schedule for station :"));
      //row.Add(txt, 25, SizerFlag.wxALL, 4);

      //m_stations = new Choice(this, (int)MenuIDs.ID_CHOICE,
      //      Window.wxDefaultPosition, Window.wxDefaultSize, strings);
      //row.Add(m_stations, 50, SizerFlag.wxGROW | SizerFlag.wxALL, 4);

      //m_check = new CheckBox(this, (int)MenuIDs.ID_CHECKBOX, wxPorting.L("&Ignore platform number"));
      //m_check.Value = true;

      //row.Add(m_check, 25, SizerFlag.wxALL, 4);

      //column.Add(row, 10, SizerFlag.wxALL, 4);

      //m_stops = new ListCtrl(this, wxID_ANY, Window.wxDefaultPosition, Window.wxDefaultSize,
      //    WindowStyles.LC_REPORT);
      //ListItem col = new ListItem();

      //if(titles == null)
      //  Globals.localizeArray(ref titles, en_titles);

      ////  Insert columns

      //for(i = 0; titles[i] != null; ++i) {
      //  col.Text = (titles[i]);
      //  m_stops.InsertColumn(i, col);
      //  m_stops.SetColumnWidth(i, 80);
      //}

      //column.Add(m_stops, 100, SizerFlag.wxGROW | SizerFlag.wxALL, 4);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);
      //row.Add(new Button(this, (int)MenuIDs.ID_PRINT, wxPorting.L("&Print")), 0, SizerFlag.wxALL, 4);
      //row.Add(new Button(this, wxID_OK, wxPorting.L("&Close")), 0, SizerFlag.wxALL, 4);

      //column.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    ~StationInfoDialog() {
      Globals.freeLocalizedArray(titles);
    }

    private bool LoadStationList(string station) {
      throw new NotImplementedException();
      //int i;
      //String p;
      //string buff;
      //String str;

      //if(all_stations != null)
      //  Globals.free(all_stations);
      //all_stations = Globals.get_station_list();
      //if(all_stations == null) {
      //  wx.MessageDialog.MessageBox(wxPorting.L("No stations found."));
      //  return false;
      //}
      //m_stations.Clear();
      //station_idx = 0;
      //for(i = 0; all_stations[i] != null; ++i) {
      //  if(String.IsNullOrEmpty(station) != false && Globals.sameStation(all_stations[i].station, station))
      //    station_idx = i;
      //  buff = String.Copy(all_stations[i].station);
      //  if(!Globals.platform_schedule && (p = Globals.wxStrrchr(buff, '@')) != null)
      //    *p = 0;
      //  m_stations.Append(buff);
      //}

      //m_stations.Selection = (station_idx);
      //return true;
    }

    public void OnCheckbox(object sender, Event evt) {
      int i;

      station_idx = m_stations.Selection;
      String origStation = all_stations[station_idx].station;

      Globals.platform_schedule = !m_check.Value;
      LoadStationList(origStation);
      for(i = 0; all_stations[i] != null; ++i)
        if(Globals.sameStation(origStation, all_stations[i].station)) {
          m_stations.Selection = (i);
          break;
        }
      OnChoice(sender, evt);
    }

    public void OnChoice(object sender, Event evt) {
      station_idx = m_stations.Selection;
      Globals.build_station_schedule(all_stations[station_idx].station);
      FillStops();
    }

    private void FillStops() {
      //int i, r;
      //station_sched sc;
      //String p;
      //string buff;

      //m_stops.DeleteAllItems();
      //i = 0;
      //for(sc = Globals.stat_sched; sc != null; sc = sc.next) {
      //  int id = m_stops.InsertItem(i, sc.tr.name);
      //  m_stops.SetItem(id, 1, sc.arrival != -1 ? Globals.format_time(sc.arrival) : wxPorting.T(""));
      //  m_stops.SetItem(id, 2, sc.tr.entrance);
      //  m_stops.SetItem(id, 3, sc.departure != -1 ? Globals.format_time(sc.departure) : wxPorting.T(""));
      //  m_stops.SetItem(id, 4, sc.tr.exit);
      //  buff = "";
      //  if(sc.stopname && (p = Globals.wxStrchr(sc.stopname, '@')))
      //    buff = String.Copy( p + 1);
      //  m_stops.SetItem(id, 5, buff);
      //  int x = 0;
      //  if(sc.tr.days != 0) {
      //    for(r = 0; r < 7; ++r)
      //      if((sc.tr.days & (1 << r)) != 0)
      //        buff.ReplaceAt(x++, (char)(r + '1'));
      //  }
      //  buff = buff.Substring(0, x);
      //  m_stops.SetItem(id, 6, buff);
      //  ++i;
      //}
    }

    public void OnPrint(object sender, Event evt) {
      station_idx = m_stations.Selection;
      Globals.ShowStationSchedule(all_stations[station_idx].station, false);

    }

    public ShowModalResult ShowModal(string station) {
      ShowModalResult res;

      if(!LoadStationList(station))
        return ShowModalResult .CANCEL;
      m_check.Value = (!Globals.platform_schedule);
      Globals.build_station_schedule(all_stations[station_idx].station);
      FillStops();

      Centre();
      bool oldIgnore = Globals.traindir.m_ignoreTimer;
      Globals.traindir.m_ignoreTimer = true;
      m_stations.SetFocus();
      res = base.ShowModal();
      Globals.traindir.m_ignoreTimer = oldIgnore;

      return res;
    }
  }
}