using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  public class TimeTableView : ReportBase {
    string[] en_titles = {
                           wxPorting.T("Entry"), wxPorting.T("From"), wxPorting.T("To"), wxPorting.T("Exit"), wxPorting.T("Train"), wxPorting.T("Speed"),
                           wxPorting.T("Min.Del."), wxPorting.T("Min.Late"), wxPorting.T("Status"), wxPorting.T("Notes")
                         };
    string[] titles;
    int[]	schedule_widths = new int[] { 50, 50, 50, 50, 50, 50, 60, 60, 200, 200, 0 };

    string m_name;

    // options

    public bool m_bTrackFirst;
    public bool m_bTrackLast;

    static List<Train> listed_trains;
    static int num_listed_trains;

    //
    //
    //

    public TimeTableView(Window parent, String name)
      : base(parent, name) {
      m_bTrackFirst = false;
      m_bTrackLast = false;

      this.Name = wxPorting.T("timetable");
      titles = new string[en_titles.Length];

      if(titles[0] == null)
        Translations.LocalizeArray(titles, en_titles);

      DefineColumns(titles, schedule_widths);

      EVT_LIST_ITEM_ACTIVATED((int)MenuIDs2.wxID_ANY, new EventListener(OnItemActivated));
      EVT_CONTEXT_MENU(new EventListener(OnContextMenu));
      EVT_MENU((int)MenuIDs.MENU_SCHED_SHOW_CANCELED, new EventListener(OnShowCanceled));
      EVT_MENU((int)MenuIDs.MENU_SCHED_SHOW_ARRIVED, new EventListener(OnShowArrived));
      EVT_MENU((int)MenuIDs.MENU_SCHED_ASSIGN, new EventListener(OnAssign));
      EVT_MENU((int)MenuIDs.MENU_SCHED_TRACK_FIRST, new EventListener(OnTrackFirst));
      EVT_MENU((int)MenuIDs.MENU_SCHED_TRACK_LAST, new EventListener(OnTrackLast));
      EVT_MENU((int)MenuIDs.MENU_SCHED_PRINT_TRAIN, new EventListener(OnPrintTrain));

    }


    //
    //
    //

    void LoadState(string header, TConfig state) {
      int res;

      this.LoadState(header, state);
      if(state.GetInt(wxPorting.T("show_canceled"), out res))
        GlobalVariables.show_canceled = res != 0;
      if(state.GetInt(wxPorting.T("track_first"), out res))
        m_bTrackFirst = res != 0;
      if(state.GetInt(wxPorting.T("track_last"), out res))
        m_bTrackLast = res != 0;
      if(state.GetInt(wxPorting.T("show_arrived"), out res))
        GlobalVariables.show_arrived = res != 0;
    }

    //
    //
    //

    void SaveState(string header, TConfig state) {
      this.SaveState(header, state);
      state.PutInt(wxPorting.T("show_canceled"), GlobalVariables.show_canceled ? 1 : 0);
      state.PutInt(wxPorting.T("show_arrived"), GlobalVariables.show_arrived ? 1 : 0);
      state.PutInt(wxPorting.T("track_first"), m_bTrackFirst ? 1 : 0);
      state.PutInt(wxPorting.T("track_last"), m_bTrackLast ? 1 : 0);
    }

    //
    //
    //


    public void OnContextMenu(object Sender, Event evt) {
      Menu menu = new Menu();
      MenuItem item;
      Point pt = ((ContextMenuEvent)evt).Position;

      pt = ScreenToClient(pt);

      item = menu.Append((int)MenuIDs.MENU_SCHED_SHOW_CANCELED, wxPorting.L("Show Canceled"), wxPorting.L("Show/hide canceled trains from list"), ItemKind.wxITEM_CHECK);
      item.Checked = (GlobalVariables.show_canceled == true);
      item = menu.Append((int)MenuIDs.MENU_SCHED_SHOW_ARRIVED, wxPorting.L("Show Arrived"), wxPorting.L("Show/hide arrived trains from list"), ItemKind.wxITEM_CHECK);
      item.Checked = (GlobalVariables.show_arrived == true);
      item = menu.Append((int)MenuIDs.MENU_SCHED_TRACK_FIRST, wxPorting.L("Track First Train"), wxPorting.L("Automatically show first active train in list"), ItemKind.wxITEM_CHECK);
      item.Checked = (m_bTrackFirst);
      item = menu.Append((int)MenuIDs.MENU_SCHED_TRACK_LAST, wxPorting.L("Track Last Train"), wxPorting.L("Automatically show last active train in list"), ItemKind.wxITEM_CHECK);
      item.Checked = (m_bTrackLast);
      item = menu.Append((int)MenuIDs.MENU_SCHED_ASSIGN, wxPorting.L("Assign"), wxPorting.L("Assingn stock of arrived train to another train"));
      Train trn = (Train)GetSelectedData();
      if(trn != null && trn.status != trainstat.train_ARRIVED)
        menu.Enable((int)MenuIDs.MENU_SCHED_ASSIGN, false);
      item = menu.Append((int)MenuIDs.MENU_SCHED_PRINT_TRAIN, wxPorting.L("Train Info"), wxPorting.L("Show train info page"));
      PopupMenu(menu, pt);
    }

    //
    //
    //

    public void OnShowCanceled(object sender, Event evt) {
      GlobalVariables.show_canceled = !GlobalVariables.show_canceled;
      fill_schedule(GlobalVariables.schedule, 0);
    }

    //
    //
    //

    public void OnShowArrived(object sender, Event evt) {
      GlobalVariables.show_arrived = !GlobalVariables.show_arrived;
      fill_schedule(GlobalVariables.schedule, 0);
    }

    //
    //
    //

    public void OnAssign(object sender, Event evt) {
      Train trn = (Train)GetSelectedData();

      if(trn != null)
        GlobalFunctions.assign_dialog(trn);
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
      int i;
      Train t;
      ListItem item;

      for(i = 0; i < ItemCount; ++i) {
        item = new ListItem();
        item.Id = i;
        item.Mask = ListItemMask.DATA;
        GetItem(item);
        t = (Train)item.Data;
        if(t.isExternal)
          continue;
        switch(t.status) {
          case trainstat.train_ARRIVED:
          case trainstat.train_DERAILED:
            continue;
        }
        EnsureVisible(i);
        break;
      }
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
      int i;
      int last;
      Train t;
      ListItem item;

      last = 0;
      for(i = ItemCount - 1; i > 0; --i) {
        item = new ListItem();
        item.Id = i;
        item.Mask = ListItemMask.DATA;
        GetItem(item);
        t = (Train)item.Data;
        if(t.isExternal)
          continue;
        switch(t.status) {
          case trainstat.train_ARRIVED:
          case trainstat.train_DERAILED:
          case trainstat.train_READY:
            continue;
        }
        if(GlobalFunctions.is_canceled(t))
          continue;
        last = i;
        break;
      }
      EnsureVisible(last);
    }

    //
    //
    //

    public void OnPrintTrain(object sender, Event evt) {
      Train trn = (Train)GetSelectedData();
      if(trn != null)
        GlobalFunctions.ShowTrainInfo(trn);
    }

    //
    //
    //

    public void OnItemActivated(object sender, Event evt) {
      ListItem item = ((ListEvent)evt).Item;
      Train trn = (Train)item.Data;

      if(GlobalVariables.traindir.m_frame.m_timeTableLocation == TimaTableLocation.TIME_TABLE_SPLIT)
        GlobalVariables.traindir.m_frame.ShowTrainInfoList(trn);
      else
        GlobalFunctions.ShowTrainInfoDialog(trn);
    }

    //
    //
    //

    public void UpdateItem(int i, Train t) {
      ListItem item = new ListItem();
      String notes = "";
      int n;
      TrainInfo info = new TrainInfo();

      t.Get(info);

      SetItem(i, 1, t.entrance);
      SetItem(i, 0, info.entering_time);
      SetItem(i, 2, t.exit);
      SetItem(i, 3, info.leaving_time);
      SetItem(i, 4, t.name);
      SetItem(i, 5, info.current_speed);
      SetItem(i, 6, info.current_delay);
      SetItem(i, 7, info.current_late);
      SetItem(i, 8, info.current_status);
      for(n = 0; n < Configuration.MAXNOTES; ++n) {
        notes += t.notes[n] != null ? t.notes[n] : wxPorting.T("");
        notes += wxPorting.T(" ");
      }
      SetItem(i, 9, notes);

      item.Id = i;
      GetItem(item);
      item.TextColour = Colour.wxGREEN;
      item.BackgroundColour = Colour.wxWHITE;
      item.Data = t;
      switch(t.status) {
        case trainstat.train_READY:
          if(t.days != RunDays.None && (t.days & GlobalVariables.run_day) != RunDays.None) {
            //		wxColour fg(64, 64, 64);
            //		item.SetTextColour(fg);
            item.TextColour = GlobalVariables.traindir.m_colorCanceled;
            break;
          } else {
            item.TextColour = GlobalVariables.traindir.m_colorReady; //*wxBLUE);
            break;
          }
        case trainstat.train_ARRIVED:
          if(!GlobalVariables.show_arrived)
            item.TextColour = Colour.wxLIGHT_GREY;
          else
            item.TextColour = GlobalVariables.traindir.m_colorArrived; //*wxGREEN);
          break;

        case trainstat.train_DERAILED:
          item.TextColour = GlobalVariables.traindir.m_colorDerailed; //*wxRED);
          break;

        case trainstat.train_WAITING:
          item.BackgroundColour = GlobalVariables.traindir.m_colorWaiting;
          item.TextColour = Colour.wxRED;
          break;

        case trainstat.train_STOPPED:
          item.TextColour = GlobalVariables.traindir.m_colorStopped;
          break;

        default:	    // running
          item.TextColour = GlobalVariables.traindir.m_colorRunning; //*wxBLACK);
          break;
      }
      SetItem(item);
    }

    //
    //
    //

    public void DeleteRow(int i) {
      DeleteItem(i);
    }

    void fill_schedule(Train tr, int assign) {
      /* Here we do the actual adding of the text. It's done once for
       * each row.
       */

      int i, tt;
      TimeTableView clist;
      Train t;
      ImageList icons = new ImageList(48, 16);

      listed_trains.Clear();

      num_listed_trains = 0;
      for(t = tr; t != null; t = t.next)
        ++num_listed_trains;
      // if(num_listed_trains != 0)
      //  listed_trains = (Train**)calloc(sizeof(Train*), num_listed_trains);
      for(tt = 0; tt < Configuration.NUMTTABLES; ++tt) {
        clist = GlobalVariables.traindir.m_frame.m_timeTableManager.GetTimeTable(tt);
        if(clist != null)
          continue;
        clist.DeleteAllItems();
        clist.Freeze();
        i = 0;
        for(t = tr; t != null; t = t.next) {
          /* when reassigning train stock, we consider only
              trains that are scheduled to depart at the same
              station where the assignee has arrived. */
          ///		if(assign && (t.status != train_READY ||
          ///			    !sameStation(oldtrain.position.station, t.entrance)))
          ///		    continue;
          if(t.entrance != null)
            continue;
          if(GlobalFunctions.ignore_train(t))
            continue;

          if(GlobalVariables.show_canceled || GlobalFunctions.is_canceled(t) == false) {
            //print_train_info(t);
            TrainInfo info = new TrainInfo();
            t.Get(info);
            clist.InsertItem(i, info.entering_time, t.epix);
            clist.UpdateItem(i, t);
            listed_trains[i] = t;
            ++i;
          }
        }
        clist.Thaw();
      }
    }


  }
}