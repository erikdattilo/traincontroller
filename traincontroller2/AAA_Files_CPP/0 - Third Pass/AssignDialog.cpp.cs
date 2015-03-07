 /*	AssignDialog.cpp - Created by Giampiero Caprino
 
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

namespace TrainDirPorting {
  public partial class Globals {
    public static Track path_find_station(Vector path, Track headpos) {
      int i;
      Track trk;

      for(i = path._size - 1; i >= 0; --i) {
        trk = path.TrackAt(i);
        if(trk == headpos)
          break;
      }
      for(; i >= 0; --i) {
        trk = path.TrackAt(i);
        if(string.IsNullOrEmpty(trk.station) == false)
          return trk;
      }
      return null;
    }
  }

  public class AssignDialog : Dialog {

    public StaticText m_header;
    public ListCtrl m_list;
    public Button m_assign,
        m_shunt,
        m_assignshunt,
        m_reverseassign,
        m_split,
        m_properties,
        m_cancel;

    private Train assign_tr;
    private Train[] assign_list;
    private int nassign;
    private int maxassign;

    private static String[] en_titles = new string[] { wxPorting.T("Train"), wxPorting.T("Departure"), wxPorting.T("Platform"),
 				wxPorting.T("Destination"), wxPorting.T("Arrival"), wxPorting.T("Notes"), null };
    private static String[] titles = new string[en_titles.Length];
    private static int[] col_widths = { 60, 60, 40, 150, 80, 80, 0 };

    public AssignDialog(Window parent)
      : base(parent, 0, wxPorting.L("Assign rolling stock"),
          Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Assign rolling stock")) {
      //EVT_BUTTON((int)MenuIDs.ID_ASSIGN, new wx.EventListener(OnAssign));
      //EVT_BUTTON((int)MenuIDs.ID_ASSIGNSHUNT, new wx.EventListener(OnAssignAndShunt));
      //EVT_BUTTON((int)MenuIDs.ID_REVERSEASSIGN, new wx.EventListener(OnReverseAndAssign));
      //EVT_BUTTON((int)MenuIDs.ID_SHUNT, new wx.EventListener(OnShunt));
      //EVT_BUTTON((int)MenuIDs.ID_SPLIT, new wx.EventListener(OnSplit));
      //EVT_BUTTON((int)MenuIDs.ID_PROPERTIES, new wx.EventListener(OnProperties));
      //EVT_UPDATE_UI((int)MenuIDs.ID_LIST, new wx.EventListener(OnUpdate));

      //int i;

      //if(titles == null)
      //  Globals.localizeArray(ref titles, en_titles);

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //BoxSizer col = new BoxSizer(Orientation.wxVERTICAL);

      //// Erik: Original code => Following line
      //// m_header = new StaticText(this, 0, String(wxPorting.T('M'), 60));
      //m_header = new StaticText(this, 0, String.Format("%60d", 0).replace('0', wxPorting.T('M')));
      //col.Add(m_header, 0,  Direction.wxRIGHT, 5);
      //m_list = new ListCtrl(this, (int)MenuIDs.ID_LIST, Window.wxDefaultPosition,
      //  Window.wxDefaultSize, WindowStyles.LC_REPORT | WindowStyles.LC_HRULES | WindowStyles.LC_SINGLE_SEL);

      //col.Add(m_list, 1, Stretch.wxGROW | Direction.wxTOP | Direction.wxBOTTOM, 5);
      
      //row.Add(col, 1, Stretch.wxGROW | Direction.wxALL, 5);

      //col = new BoxSizer(Orientation.wxVERTICAL);

      //m_assign = new Button(this, (int)MenuIDs.ID_ASSIGN, wxPorting.L("&Assign"));
      //m_assign.SetDefault();
      //col.Add(m_assign, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_shunt = new Button(this, (int)MenuIDs.ID_SHUNT, wxPorting.L("S&hunt"));
      //col.Add(m_shunt, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_assignshunt = new Button(this, (int)MenuIDs.ID_ASSIGNSHUNT, wxPorting.L("Assign&+Shunt"));
      //col.Add(m_assignshunt, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_reverseassign = new Button(this, (int)MenuIDs.ID_REVERSEASSIGN, wxPorting.L("&Reverse+Assign"));
      //col.Add(m_reverseassign, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_split = new Button(this, (int)MenuIDs.ID_SPLIT, wxPorting.L("Sp&lit"));
      //col.Add(m_split, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_properties = new Button(this, (int)MenuIDs.ID_PROPERTIES, wxPorting.L("&Properties"));
      //m_properties.Disable();
      //col.Add(m_properties, 0, Direction.wxTOP | Stretch.wxGROW, 10);
      //m_cancel = new Button(this, (int)wxID_CANCEL, wxPorting.L("&Cancel"));
      //col.Add(m_cancel, 0, Direction.wxTOP | Stretch.wxGROW, 10);

      //row.Add(col, 0, Direction.wxALL, 5);

      //wx.ListItem listcol = new ListItem();

      ////  Insert columns

      //for(i = 0; titles[i] != null; ++i) {
      //  listcol.Text = (titles[i]);
      //  m_list.InsertColumn(i, listcol);
      //  m_list.SetColumnWidth(i, col_widths[i]);
      //}
      //SetSizer(row);
      //row.Fit(this);
      //row.SetSizeHints(this);
      //m_header.Label = wxPorting.T("");
    }

    ~AssignDialog() {
      Globals.freeLocalizedArray(titles);
    }

    private long assign_train_from_dialog() {
      int i = m_list.SelectedItemCount;

      if(i != 1)
        return -1;

      long l = m_list.GetNextItem(-1, ListCtrl.NEXT.ALL, ListItemState.SELECTED);

      if(l >= 0) {
        Globals.assign_train(assign_list[l], assign_tr);
      }
      EndModal(ShowModalResult.OK);
      return l;
    }

    public void OnAssign(object sender, Event evt) {
      assign_train_from_dialog();
    }

    public void OnAssignAndShunt(object sender, Event evt) {
      long t = assign_train_from_dialog();
      if(t >= 0)
        Globals.shunt_train(assign_list[t]);
    }

    public void OnReverseAndAssign(object sender, Event evt) {
      int i = m_list.SelectedItemCount;

      if(i != 1)
        return;

      long l = m_list.GetNextItem(-1, ListCtrl.NEXT.ALL, ListItemState.SELECTED);

      if(l < 0)
        return;

      if(!Globals.reverse_train(assign_tr))
        return;
      assign_train_from_dialog();
    }

    public void OnShunt(object sender, Event evt) {
      Globals.shunt_train(assign_tr);
      EndModal(ShowModalResult.OK);
    }

    public void OnSplit(object sender, Event evt) {
      int l = 0;

      if(assign_tr.length != 0) {
        l = Globals.ask_number(wxPorting.T("Split train"), wxPorting.T("Position where to split the train (meters from the head)"));
        if(l < 0)
          return;
      }
      Globals.split_train(assign_tr, l);
      Globals.shunt_train(assign_tr);
      EndModal(ShowModalResult.OK);
    }

    public void OnProperties(object sender, Event evt) {
    }

    public void OnUpdate(object sender, Event evt) {
      long l = m_list.GetNextItem(-1, ListCtrl.NEXT.ALL, ListItemState.SELECTED);

      bool enable = false;
      if(l >= 0)
        enable = true;

      m_assign.Enabled = enable; 
      m_assignshunt.Enabled = enable;
      m_reverseassign.Enabled = enable;
    }

    private void fill_assign_train_list(Train t, Track station) {
      Track trk = station;

      if(string.IsNullOrEmpty(trk.station))
        return;
      assign_tr = t;

      nassign = maxassign = 0;
      for(t = Globals.schedule; t != null; t = t.next) {
        if(t.status == trainstat.train_READY &&
          Globals.sameStation(t.entrance, trk.station) &&	// 3.4: was assign_tr.exit
          (t.days == RunDays.None || (t.days & Globals.run_day) != RunDays.None)) {
          if(nassign >= maxassign) {
            maxassign += 20;
            if(assign_list == null)
              assign_list = new Train[maxassign];
            else
              assign_list = Globals.realloc(ref assign_list, maxassign);
          }
          assign_list[nassign++] = t;
        }
      }
    }

    public int ShowModal(Train t) {
      throw new NotImplementedException();
      //string buff;
      //String p;
      //int i;
      //Track trk;

      //trk = t.position;
      //if(trk == null) {
      //  wx.MessageDialog.MessageBox(wxPorting.L("Train has already been assigned."), wxPorting.T("Error"),
      //wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_ERROR, Globals.traindir.m_frame);
      //  return 0;
      //}
      //if(string.IsNullOrEmpty(trk.station) && t.tail && t.tail.path) {
      //  trk = path_find_station(t.tail.path, t.position);
      //  if(trk == null)
      //    trk = t.position;
      //}
      //buff = String.Format( wxPorting.L("Assigning stock of train %s arrived at station %s"),
      //    t.name, trk.station);
      //m_header.Label = buff;

      //fill_assign_train_list(t, trk);

      //m_list.DeleteAllItems();
      //m_list.Freeze();

      //for(i = 0; i < nassign; ++i) {
      //  Train t1 = assign_list[i];
      //  m_list.InsertItem(i, t1.name);
      //  m_list.SetItem(i, 1, Globals.format_time(t1.timein));
      //  buff = String.Copy( t1.entrance);
      //  if((p = Globals.wxStrchr(buff, '@'))) {
      //    *p = 0;
      //    m_list.SetItem(i, 2, p + 1);
      //  }
      //  m_list.SetItem(i, 3, t1.exit);
      //  m_list.SetItem(i, 4, Globals.format_time(t1.timeout));

      //  String notes;
      //  int n;

      //  for(n = 0; n < Configuration.MAXNOTES; ++n) {
      //    notes += string.IsNullOrEmpty(t1.notes[n]) == false ? t1.notes[n] : wxPorting.T("");
      //    notes += wxPorting.T(" ");
      //  }
      //  m_list.SetItem(i, 5, notes);
      //}
      //m_list.Thaw();
      //if(string.IsNullOrEmpty(t.stock) == false) {
      //  for(i = 0; i < nassign; ++i)
      //    if(Globals.wxStrcmp(t.stock, assign_list[i].name) == 0) {
      //      m_list.SetItemState(i, ListItemState.SELECTED, ListItemState.SELECTED);
      //    }
      //}

      //if((t.flags & TFLG.TFLG_STRANDED) != 0)
      //  m_reverseassign.Disable();
      //else
      //  m_reverseassign.Enabled = true;
      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //int res = this.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //return res;
    }

  }
}