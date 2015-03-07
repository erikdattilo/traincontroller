/*	TimeTblView.cpp - Created by Giampiero Caprino

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
using System.Drawing;
namespace TrainDirPorting {

  public partial class Globals {
    private static Train[] listed_trains;
    private static int num_listed_trains;
  }

  public class TimeTableView : ReportBase {
    public String m_name;

    // options

    public bool m_bTrackFirst;
    public bool m_bTrackLast;

    private static String[] en_titles = new String[] { wxPorting.T("Entry"), wxPorting.T("From"),
	wxPorting.T("To"), wxPorting.T("Exit"), wxPorting.T("Train"), wxPorting.T("Speed"), wxPorting.T("Min.Del."), wxPorting.T("Min.Late"), wxPorting.T("Status"), wxPorting.T("Notes"), null };
    private static String[] titles = new String[en_titles.Length];
    private static int[] schedule_widths = new int[] { 50, 50, 50, 50, 50, 50, 60, 60, 200, 200, 0 };

    //
    //
    //

    public TimeTableView(Window parent, String name)
      : base(parent, name) {
      m_bTrackFirst = false;
      m_bTrackLast = false;

      EVT_LIST_ITEM_ACTIVATED(wxID_ANY, new wx.EventListener(OnItemActivated));
      EVT_CONTEXT_MENU(new wx.EventListener(OnContextMenu));
      EVT_MENU(MenuIDs.MENU_SCHED_SHOW_CANCELED, new wx.EventListener(OnShowCanceled));
      EVT_MENU(MenuIDs.MENU_SCHED_SHOW_ARRIVED, new wx.EventListener(OnShowArrived));
      EVT_MENU(MenuIDs.MENU_SCHED_ASSIGN, new wx.EventListener(OnAssign));
      EVT_MENU(MenuIDs.MENU_SCHED_TRACK_FIRST, new wx.EventListener(OnTrackFirst));
      EVT_MENU(MenuIDs.MENU_SCHED_TRACK_LAST, new wx.EventListener(OnTrackLast));
      EVT_MENU(MenuIDs.MENU_SCHED_PRINT_TRAIN, new wx.EventListener(OnPrintTrain));

      SetName(wxPorting.T("timetable"));
      if(titles == null)
        Globals.localizeArray(ref titles, en_titles);
      DefineColumns(titles, schedule_widths);
    }

    //
    //
    //

    ~TimeTableView() {
      Globals.freeLocalizedArray(titles);
    }

    //
    //
    //

    public override void LoadState(String header, TConfig state) {
      int res;

      base.LoadState(header, state);
      if(state.GetInt(wxPorting.T("show_canceled"), out res))
        Globals.show_canceled = res != 0;
      if(state.GetInt(wxPorting.T("track_first"), out res))
        m_bTrackFirst = res != 0;
      if(state.GetInt(wxPorting.T("track_last"), out res))
        m_bTrackLast = res != 0;
      if(state.GetInt(wxPorting.T("show_arrived"), out res))
        Globals.show_arrived = res != 0;
    }

    //
    //
    //

    public override void SaveState(String header, TConfig state) {
      base.SaveState(header, state);
      state.PutInt(wxPorting.T("show_canceled"), Globals.show_canceled ? 1 : 0);
      state.PutInt(wxPorting.T("show_arrived"), Globals.show_arrived ? 1 : 0);
      state.PutInt(wxPorting.T("track_first"), m_bTrackFirst ? 1 : 0);
      state.PutInt(wxPorting.T("track_last"), m_bTrackLast ? 1 : 0);
    }

    //
    //
    //


    public void OnContextMenu(object sender, Event evt)
{
  //Menu	menu = new Menu();
  //MenuItem  item;
  //Point pt = ((MouseEvent)evt).Position;

  //pt = ((MouseEvent)evt).Position;
  //      pt = ScreenToClient(pt);

  //item = menu.Append(MenuIDs.MENU_SCHED_SHOW_CANCELED, wxPorting.L("Show Canceled"), wxPorting.L("Show/hide canceled trains from list"), wxITEM_CHECK);
  //item.Checked = (Globals.show_canceled != 0);
  //item = menu.Append(MenuIDs.MENU_SCHED_SHOW_ARRIVED, wxPorting.L("Show Arrived"), wxPorting.L("Show/hide arrived trains from list"), wxITEM_CHECK);
  //item.Checked = (Globals.show_arrived != 0);
  //item = menu.Append(MenuIDs.MENU_SCHED_TRACK_FIRST, wxPorting.L("Track First Train"), wxPorting.L("Automatically show first active train in list"), wxITEM_CHECK);
  //item.Checked = (m_bTrackFirst);
  //item = menu.Append(MenuIDs.MENU_SCHED_TRACK_LAST, wxPorting.L("Track Last Train"), wxPorting.L("Automatically show last active train in list"), wxITEM_CHECK);
  //item.Checked = (m_bTrackLast);
  //item = menu.Append(MenuIDs.MENU_SCHED_ASSIGN, wxPorting.L("Assign"), wxPorting.L("Assingn stock of arrived train to another train"));
  //Train trn = (Train)GetSelectedData();
  //if(trn != null && trn.status != trainstat.train_ARRIVED)
  //    menu.Enable((int)MenuIDs.MENU_SCHED_ASSIGN, false);
  //item = menu.Append(MenuIDs.MENU_SCHED_PRINT_TRAIN, wxPorting.L("Train Info"), wxPorting.L("Show train info page"));
  //PopupMenu(&menu, pt);
}

    //
    //
    //

    public void OnShowCanceled(object sender, Event evt) {
      Globals.show_canceled = !Globals.show_canceled;
      Globals.fill_schedule(Globals.schedule, 0);
    }

    //
    //
    //

    public void OnShowArrived(object sender, Event evt) {
      Globals.show_arrived = !Globals.show_arrived;
      Globals.fill_schedule(Globals.schedule, 0);
    }

    //
    //
    //

    public void OnAssign(object sender, Event evt) {
      Train trn = (Train)GetSelectedData();

      if(trn != null)
        Globals.assign_dialog(trn);
    }

    //
    //
    //

    public void OnTrackFirst(object sender, Event evt) {
      m_bTrackFirst = !m_bTrackFirst;
      m_bTrackLast = false;
      if(m_bTrackFirst)
        ShowFirst();
    }

    //
    //
    //

    public void ShowFirst() {
      //int i;
      //Train t;
      //ListItem item = new ListItem();

      //for(i = 0; i < ItemCount; ++i) {
      //  item.Id = (i);
      //  item.Mask = ListItemMask.DATA;
      //  GetItem(item);
      //  t = (Train)item.Data;
      //  if(t.isExternal)
      //    continue;
      //  switch(t.status) {
      //    case trainstat.train_ARRIVED:
      //    case trainstat.train_DERAILED:
      //      continue;
      //  }
      //  EnsureVisible(i);
      //  break;
      //}
    }

    //
    //
    //

    public void OnTrackLast(object sender, Event evt) {
      m_bTrackLast = !m_bTrackLast;
      m_bTrackFirst = false;
      if(m_bTrackLast)
        ShowLast();
    }

    //
    //
    //

    public void ShowLast() {
      //int i;
      //int last;
      //Train t;
      //ListItem item = new ListItem();

      //last = 0;
      //for(i = ItemCount - 1; i > 0; --i) {
      //  item.Id = i;
      //  item.Mask = ListItemMask.DATA;
      //  GetItem(item);
      //  t = (Train)item.Data;
      //  if(t.isExternal)
      //    continue;
      //  switch(t.status) {
      //    case trainstat.train_ARRIVED:
      //    case trainstat.train_DERAILED:
      //    case trainstat.train_READY:
      //      continue;
      //  }
      //  if(Globals.is_canceled(t))
      //    continue;
      //  last = i;
      //  break;
      //}
      //EnsureVisible(last);
    }

    //
    //
    //

    public void OnPrintTrain(object sender, Event evt) {
      Train trn = (Train)GetSelectedData();
      if(trn != null)
        Globals.ShowTrainInfo(trn);
    }

    //
    //
    //

    public void OnItemActivated(object sender, Event evt) {
      //ListItem item = ((ListEvent)evt).Item;
      //Train trn = (Train)item.Data;

      //if(Globals.traindir.m_frame.m_timeTableLocation == TimeTableLocations.TIME_TABLE_SPLIT)
      //  Globals.traindir.m_frame.ShowTrainInfoList(trn);
      //else
      //  Globals.ShowTrainInfoDialog(trn);
    }

    //
    //
    //

    public void UpdateItem(int i, Train t) {
      //ListItem item = new ListItem();
      //String notes;
      //int n;
      //TrainInfo info;

      //t.Get(info);

      //SetItem(i, 1, t.entrance);
      //SetItem(i, 0, info.entering_time);
      //SetItem(i, 2, t.exit);
      //SetItem(i, 3, info.leaving_time);
      //SetItem(i, 4, t.name);
      //SetItem(i, 5, info.current_speed);
      //SetItem(i, 6, info.current_delay);
      //SetItem(i, 7, info.current_late);
      //SetItem(i, 8, info.current_status);
      //for(n = 0; n < Config.MAXNOTES; ++n) {
      //  notes += String.IsNullOrEmpty(t.notes[n]) == false ? t.notes[n] : wxPorting.T("");
      //  notes += wxPorting.T(" ");
      //}
      //SetItem(i, 9, notes);

      //item.Id = (i);
      //GetItem(item);
      //item.TextColour = (wx.Colour.wxGREEN);
      //item.BackgroundColour = (wx.Colour.wxWHITE);
      //item.Data = t;
      //switch(t.status) {
      //  case trainstat.train_READY:
      //    if(t.days != 0 && Globals.run_day != 0 && (t.days & Globals.run_day) == 0) {
      //      item.TextColour = (Globals.traindir.m_colorCanceled);
      //      break;
      //    } else {
      //      item.TextColour = (Globals.traindir.m_colorReady); //*wx.Colour.wxBLUE);
      //      break;
      //    }
      //  case trainstat.train_ARRIVED:
      //    if(!Globals.show_arrived)
      //      item.TextColour = (wx.Colour.wxLIGHT_GREY);
      //    else
      //      item.TextColour = (Globals.traindir.m_colorArrived); //*wx.Colour.wxGREEN);
      //    break;

      //  case trainstat.train_DERAILED:
      //    item.TextColour = (Globals.traindir.m_colorDerailed); //*wx.Colour.wxRED);
      //    break;

      //  case trainstat.train_WAITING:
      //    item.BackgroundColour = (Globals.traindir.m_colorWaiting);
      //    item.TextColour = (wx.Colour.wxRED);
      //    break;

      //  case trainstat.train_STOPPED:
      //    item.TextColour = (Globals.traindir.m_colorStopped);
      //    break;

      //  default:	    // running
      //    item.TextColour = (Globals.traindir.m_colorRunning); //*wx.Colour.wxBLACK);
      //}
      //SetItem(item);
    }

    //
    //
    //

    public void DeleteRow(int i) {
      DeleteItem(i);
    }
  }

  public partial class Globals {

    //
    //
    //

    public static bool ignore_train(Train tr) {
      if(tr.isExternal)
        return true;

      if(show_arrived)
        return false;

      if(tr.status != trainstat.train_ARRIVED)
        return false;

      if(String.IsNullOrEmpty(tr.stock))
        return true;

      Train t1 = findTrainNamed(tr.stock);
      return t1 != null && t1.status != trainstat.train_READY;
    }

    //
    //
    //

    public static void fill_schedule(Train tr, int assign) {
      ///* Here we do the actual adding of the text. It's done once for
      // * each row.
      // */

      //int i, tt;
      //TimeTableView clist;
      //Train t;
      //wxImageList icons = new wxImageList(48, 16);

      //if(listed_trains != null)
      //  Globals.free(listed_trains);
      //listed_trains = null;
      //num_listed_trains = 0;
      //for(t = tr; t != null; t = t.next)
      //  ++num_listed_trains;
      //if(num_listed_trains != 0)
      //  listed_trains = Globals.calloc<Train>(num_listed_trains);
      //for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
      //  clist = Globals.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
      //  if(clist == null)
      //    continue;
      //  clist.DeleteAllItems();
      //  clist.Freeze();
      //  i = 0;
      //  for(t = tr; t != null; t = t.next) {
      //    /* when reassigning train stock, we consider only
      //        trains that are scheduled to depart at the same
      //        station where the assignee has arrived. */
      //    ///		if(assign && (t.status != train_READY ||
      //    ///			    !sameStation(oldtrain.position.station, t.entrance)))
      //    ///		    continue;
      //    if(String.IsNullOrEmpty(t.entrance))
      //      continue;
      //    if(ignore_train(t))
      //      continue;

      //    if(show_canceled || !is_canceled(t)) {
      //      //print_train_info(t);
      //      TrainInfo info;
      //      t.Get(info);
      //      clist.InsertItem(i, info.entering_time, t.epix);
      //      clist.UpdateItem(i, t);
      //      listed_trains[i] = t;
      //      ++i;
      //    }
      //  }
      //  clist.Thaw();
      //}
    }

    //
    //
    //

    public static void gr_update_schedule(Train tr, int itm) {
      int tt;
      int x;
      TimeTableView clist;

      if(ignore_train(tr)) {
        // remove from list
        for(x = 0; x < num_listed_trains; ++x) {
          if(listed_trains[x] == tr)
            break;
        }
        if(x < num_listed_trains) {
          for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
            clist = Globals.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
            if(clist == null)
              continue;
            clist.DeleteRow(x);
          }
          for(tt = x; tt < num_listed_trains - 1; ++tt)
            listed_trains[tt] = listed_trains[tt + 1];
          --num_listed_trains;
        }
        //	    fill_schedule(schedule, 0);
      }
      print_train_info(tr);
      for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
        clist = Globals.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
        if(clist == null)
          continue;
        if(String.IsNullOrEmpty(tr.entrance))
          continue;
        for(x = 0; x < num_listed_trains; ++x)
          if(listed_trains[x] == tr)
            break;
        if(x >= num_listed_trains)
          continue;
        clist.UpdateItem(x, tr);
        if(clist.m_bTrackFirst)
          clist.ShowFirst();
        else if(clist.m_bTrackLast)
          clist.ShowLast();
      }
    }

  }
}