using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainController.SimCommands;

namespace TrainController {
  public enum LoadScenarioType {
    Load = 0,
    Open = 1
  }
  partial class Globals {
    public static Track signal_list,
     track_list,
     text_list,
     switch_list;

    public static void do_command(SimCommand cmd, bool sendToClients) {
      // String p;
      // Train	*t;
      // Track	*trk;
      // int	x, y, fl;
      // string buff;
      int fl;

      switch(cmd.Command) {
        default:
          throw new NotImplementedException();

      // if(!Globals.wxStrncmp(cmd, wxPorting.T("log"), 3)) {
      //     if(!flog.IsOpened()) {
      //   if(!(flog.Open(wxPorting.T("log"), wxPorting.T("w"))))
      //       do_alert(wxPorting.L("Cannot create log file."));
      //   return;
      //     }
      //     flog.Close();
      //     return;
      // }
      // if(!Globals.wxStrncmp(cmd, wxPorting.T("replay"), 6)) {
      //     for(p = cmd + 6; p[0] == ' ' || p[0] == 't'; p.incPointer());
      //     buff = String.Format( wxPorting.T("%s.log"), p);
      //     if(!(frply = new TDFile(buff))) {
      //   do_alert(wxPorting.L("Cannot read log file."));
      //   return;
      //     }
      //     /* replay commands are issued whenever the clock is updated */
      //     return;
      // }
      // if(flog.IsOpened())
      //     flog.Write(String.Format(wxPorting.T("%ld,%sn"), current_time, cmd));
      // buff = String.Format( wxPorting.T("%ld,%sn"), current_time, cmd);
      // if(sendToClients)
      //     send_msg(buff);
      // if(!Globals.wxStrncmp(cmd, wxPorting.T("quit"), 4))
      //     main_quit_cmd();
      // else if(!Globals.wxStrncmp(cmd, wxPorting.T("about"), 5)) {
      //     about_dialog();
      // } else if(!wxStrcmp(cmd, wxPorting.T("edititinerary"))) {
      //     itinerary_cmd();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("edit"), 4)) {
      //     if(running)
      //   start_stop();
      //     edit_cmd();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("noedit"), 6))
      //     noedit_cmd();
      // else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationsched"), 12))
      //     station_sched_dialog(null);
      // else if(!Globals.wxStrncmp(cmd, wxPorting.T("paths"), 5))
      //     create_path_window();
      // else if(!Globals.wxStrncmp(cmd, wxPorting.T("fast"), 4)) {
      //     if(time_mults[cur_time_mult + 1] != -1)
      //   time_mult = time_mults[++cur_time_mult];
      //     update_labels();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("slow"), 4)) {
      //     if(cur_time_mult > 0) {
      //   time_mult = time_mults[--cur_time_mult];
      //   update_labels();
      //     }
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("t0"), 2)) {
      //     if(cont(wxPorting.L("Do you want to restart the simulation?")) == AskAnswer.ANSWER_YES) {
      //   if(!all_trains_everyday(schedule))
      //       select_day_dialog();
      //   clear_delays();
      //   fill_schedule(schedule, 0);
      //         status_line = String.Format( wxPorting.L("Simulation restarted."));
      //         trainsim_init();
      //   invalidate_field();
      //   update_button(wxPorting.T("stop"), wxPorting.L("Stop"));
      //   repaint_all();
      //     }
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("speeds"), 6)) {
      //     show_speeds = !show_speeds;
      //     invalidate_field();
      //     repaint_all();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traditional"), 6)) {
      //     signal_traditional = !signal_traditional;
      //     invalidate_field();
      //     repaint_all();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("graph"), 6)) {
      //     create_tgraph();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("blocks"), 6)) {
      //     show_blocks = !show_blocks;
      //     invalidate_field();
      //     repaint_all();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("alert"), 5)) {
      //     beep_on_alert = !beep_on_alert;
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sched"), 5)) {
      //     create_schedule(0);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("run"), 3)) {
      //     start_stop();
      //     update_button(wxPorting.T("run"), running ? wxPorting.L("Stop") : wxPorting.L("Start"));
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("newtrain"), 8)) {
      //     create_train();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("greensigs"), 9)) {
      //     open_all_signals();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("shunt"), 5)) {
      //     cmd += 5;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     if(!(t = findTrainNamed(cmd)))
      //   return;
      //     shunt_train(t);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traininfopage"), 13)) {
      //     cmd += 13;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     if(!(t = findTrainNamed(cmd)))
      //   return;
      //     ShowTrainInfo(t);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("traininfo"), 9)) {
      //     cmd += 9;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     if(!(t = findTrainNamed(cmd)))
      //   return;
      //     train_info_dialog(t);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("decelerate"), 10)) {
      //     long    val;
      //     String end;

      //     cmd += 10;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     val = wxStrtol(cmd, &end, 0);
      //     while(*end == ' ' || *end == 't') ++end;
      //     if(!(t = findTrainNamed(end)))
      //   return;
      //     decelerate_train(t, val);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("accelerate"), 10)) {
      //     long    val;
      //     String end;

      //     cmd += 10;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     val = wxStrtol(cmd, &end, 0);
      //     while(*end == ' ' || *end == 't') ++end;
      //     if(!(t = findTrainNamed(end)))
      //   return;
      //     accelerate_train(t, val);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationinfopage"), 15)) {
      //     cmd += 15;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     ShowStationSchedule(cmd, false);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("savestationinfopage"), 19)) {
      //     cmd += 19;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     ShowStationSchedule(cmd, true);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("stationinfo"), 11)) {
      //     cmd += 11;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     station_sched_dialog(cmd);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("reverse"), 7)) {
      //     cmd += 7;
      //     while(*cmd == ' ' || *cmd == 't') ++cmd;
      //     if(!(t = findTrainNamed(cmd)))
      //   return;
      //     reverse_train(t);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("new"), 3)) {
      //     if(running)
      //   start_stop();
      //     if(layout_modified) {
      //   if(ask_to_save_layout() < 0)	// cancel selected
      //       return;
      //     }
      //     init_all();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("save "), 5)) {
      //     if(save_layout(cmd + 5, layout))
      //   status_line = String.Format( wxPorting.T("%s '%s.trk'."), wxPorting.L("Layout saved in file"), cmd + 5);
      //     repaint_labels();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("savegame "), 9)) {
      //     if(save_game(cmd + 9))
      //   status_line = String.Format( wxPorting.T("%s '%s.sav'."), wxPorting.L("Game status saved in file"), cmd + 9);
      //     repaint_labels();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("restore "), 8)) {
      //     if(layout_modified) {
      //   if(ask_to_save_layout() < 0)	// cancel selected
      //       return;
      //     }
      //     restore_game(cmd + 8);
      //     invalidate_field();
      //     repaint_all();
      //     fill_schedule(schedule, 0);
      //     update_labels();
        case Command.Open:
        case Command.Load:
          LoadScenarioType flag;
          flag = (cmd.Command == Command.Open) ? LoadScenarioType.Open : LoadScenarioType.Load;
          load_new_scenario(((LoadBaseCommand)cmd).Filename, flag);
          break;
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("puzzle"), 6)) {
      //     cmd += 6;
      //     load_new_scenario(cmd, 2);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("click"), 5)) {
      //     for(cmd += 5; *cmd == ' ' || *cmd == 't'; ++cmd);
      //     if(*cmd >= '0' && *cmd <= '9') {
      //   String end;
      //   x = wxStrtol(cmd, &end, 10);
      //   if(isalpha(*end))
      //       goto isItin;
      //   if(*end == ',') ++end;
      //   y = wxStrtol(end, &end, 10);
      //     } else {
      //isItin:
      //   if(!(trk = findItineraryNamed(cmd)))
      //       return;		/* impossible ? */
      //   x = trk.x;
      //   y = trk.y;
      //     }
      //     track_selected(x, y);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("rclick"), 6)) {
      //     for(cmd += 6; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
      //     if(*cmd >= wxPorting.T('0') && *cmd <= wxPorting.T('9')) {
      //   String end;
      //   x = wxStrtol(cmd, &end, 10);
      //   if(*end == wxPorting.T(',')) ++end;
      //   y = wxStrtol(end, &end, 10);
      //     } else {
      //   if(!(trk = findItineraryNamed(cmd)))
      //       return;		/* impossible ? */
      //   x = trk.x;
      //   y = trk.y;
      //     }
      //     track_selected1(x, y);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("ctrlclick"), 9)) {
      //     for(cmd += 9; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
      //     if(*cmd >= '0' && *cmd <= '9') {
      //   String end;
      //   x = wxStrtol(cmd, &end, 10);
      //   if(*end == wxPorting.T(',')) ++end;
      //   y = wxStrtol(end, &end, 10);
      //     } else {
      //   if(!(trk = findItineraryNamed(cmd)))
      //       return;		/* impossible ? */
      //   x = trk.x;
      //   y = trk.y;
      //     }
      //     Coord	coord = new Coord(x, y);
      //     track_control_selected(coord);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("selecttool"), 10)) {
      //     String end;
      //     for(cmd += 10; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
      //     x = wxStrtol(cmd, &end, 10);
      //     if(*end == wxPorting.T(',')) ++end;
      //     y = wxStrtol(end, &end, 10);
      //     tool_selected(x, y);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("itinerary"), 9)) {
      //            Itinerary *it = parse_itinerary(cmd + 9);
      //     if(it)
      //                it.Select();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("delitinerary"), 9)) {
      //            Itinerary *it = parse_itinerary(cmd + 12);
      //     if(it)
      //                it.Deselect(false);
      // } else if(!wxStrcmp(cmd, wxPorting.T("info"))) {
      //     track_info_dialogue();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-edit"), 7)) {
      //     SwitchboardEditCommand(cmd + 7);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-browser"), 10)) {
      //     SwitchboardOpenBrowser(cmd + 10);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("sb-cell"), 7)) {
      //     SwitchboardCellCommand(cmd + 7);
      // } else if(!wxStrcmp(cmd, wxPorting.T("performance"))) {
      //     performance_dialog();
      // } else if(!wxStrcmp(cmd, wxPorting.T("performance_toggle_canceled"))) {
      //     performance_toggle_canceled();
      //     performance_dialog();	// update page
      // } else if(!wxStrcmp(cmd, wxPorting.T("options"))) {
      //     options_dialog();
      //     if(hard_counters)
      //   perf_vals = perf_hard;
      //     else
      //   perf_vals = perf_easy;
      //     invalidate_field();
      //     repaint_all();
      //     update_labels();
      //     new_status_position();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("assign"), 6)) {
      //     Train   *t1;

      //     for(cmd += 6; *cmd == ' ' || *cmd == 't'; ++cmd);
      //     x = 0;
      //     while(*cmd && *cmd != ',') {
      //   buff[x++] = *cmd++;
      //     }
      //     buff[x] = 0;
      //     if(!(t = findTrainNamed(buff))) {
      //   // trace(wxPorting.L("Cannot assign %s: train not found."));
      //   return;
      //     }
      //     if(*cmd == ',') {
      //   while(*++cmd == ' ' || *cmd == 't');
      //     } else {
      //   if(!t.stock) {
      //       // trace(wxPorting.L("Train %s has no default stock assignment."));
      //       return;
      //   }
      //   cmd = t.stock;
      //     }
      //     if(!(t1 = findTrainNamed(cmd))) {
      //   // trace(wxPorting.L("Cannot assign %s: train not found."));
      //   return;
      //     }
      //     save_assign_train(t1, t);
      ////	    invalidate_field();
      ////	    repaint_all();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("play"), 4)) {
      //     cmd += 4;
      //     while(*cmd == ' ') ++cmd;
      //     Globals.traindir.PlaySound(cmd);
      // } else if(!wxStrcmp(cmd, wxPorting.T("skip"))) {
      //     skip_to_next_event();
      // } else if(!wxStrcmp(cmd, wxPorting.T("save_perf_text"))) {
      //     Globals.traindir.SavePerfText();
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("split"), 5)) {
      //     int length;

      //     for(cmd += 5; *cmd == wxPorting.T(' ') || *cmd == wxPorting.T('t'); ++cmd);
      //     x = 0;
      //     while(*cmd && *cmd != ',') {
      //   buff[x++] = *cmd++;
      //     }
      //     buff[x] = 0;
      //     if(!(t = findTrainNamed(buff))) {
      //   // trace(wxPorting.L("Cannot split %s: train not found."));
      //   return;
      //     }
      //     if(*cmd == ',') {
      //   while(*++cmd == ' ' || *cmd == 't');
      //   length = wxAtoi(cmd);
      //     } else {
      //   length = 0;
      //     }
      //     split_train(t, length);
      // } else if(!Globals.wxStrncmp(cmd, wxPorting.T("script"), 6)) {
      //     String end;
      //     for(cmd += 6; *cmd == ' ' || *cmd == 't'; ++cmd);
      //     x = wxStrtol(cmd, &end, 10);
      //     if(*end == ',') ++end;
      //     y = wxStrtol(end, &end, 10);
      //     while(*end == ' ' || *end == 't') ++end;
      //     if(!*end)
      //   return;
      //     trk = find_track(layout, x, y);
      //            if (!trk)
      //                return;
      //     switch(trk.type) {
      //     case TRACK:
      //     case TRIGGER:
      //     case SWITCH:
      //            case TSIGNAL:
      //   trk.RunScript(end);
      //     }

      // } else if(match(&cmd, wxPorting.T("showinfo"))) {
      //     TDFile	infoFile = new TDFile(cmd);

      //     infoFile.SetExt(wxPorting.T(".htm"));
      //     if(infoFile.Load()) {
      //   Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
      //   info_page = infoFile.name.GetName();
      //     }
      // } else if(match(&cmd, wxPorting.T("showalert"))) {
      //     Globals.traindir.AddAlert(cmd);
      // } else if(match(&cmd, wxPorting.T("clearalert"))) {
      //     Globals.traindir.ClearAlert();
      // } else if(match(&cmd, wxPorting.T("switch"))) {
      //     String end;
      //     cmd = skip_blanks(cmd);
      //            if(*cmd != '\'') {
      //         x = wxStrtol(cmd, &end, 10);
      //         if(*end == ',') ++end;
      //         y = wxStrtol(end, &end, 10);
      //                end = (String )skip_blanks(end);
      //                if(*end) {
      //             SwitchBoard *sw = FindSwitchBoard(end);
      //             if(sw)
      //                 sw.Select(x, y);
      //                }
      //            } else {
      //                end = (string )++cmd;
      //                while(*end && *end != '\'')
      //                    ++end;
      //                *end++ = 0;
      //                end = (String )skip_blanks(end);
      //                if(*end) {
      //             SwitchBoard *sw = FindSwitchBoard(end);
      //             if(sw)
      //                 sw.Select(cmd);
      //                }
      //            }
      //            server_command_done = true;
      // } else {
      //     status_line = String.Format(wxPorting.T("Command: %s"), cmd);
      //     repaint_labels();
      }
    }

    private static Track find_in_list(Track t, int x, int y) {
      for(; t != null; t = t.next1)
        if(t.x == x && t.y == y)
          return t;
      return null;
    }
    public static Track findTrack(int x, int y) {
      return findTrackType(x, y, trktype.TRACK);
    }
    public static Track findSwitch(int x, int y) {
      return findTrackType(x, y, trktype.SWITCH);
    }
    public static Signal findSignal(int x, int y) {
      return (Signal)findTrackType(x, y, trktype.TSIGNAL);
    }
    public static Track findPlatform(int x, int y) {
      return findTrackType(x, y, trktype.PLATFORM);
    }
    public static Track findText(int x, int y) {
      return findTrackType(x, y, trktype.TEXT);
    }
    public static Track findImage(int x, int y) {
      return findTrackType(x, y, trktype.IMAGE);
    }

    public static Track findTrackType(int x, int y, trktype type) {
      Track t;

      switch(type) {
        case trktype.TRACK:
          return find_in_list(track_list, x, y);
        case trktype.TSIGNAL:
          return find_in_list(signal_list, x, y);
        case trktype.SWITCH:
          return find_in_list(switch_list, x, y);
        case trktype.TEXT:
          return find_in_list(text_list, x, y);
      }
      for(t = layout; t != null; t = t.next)
        if(t.x == x && t.y == y && t.TrackType == type)
          return t;
      return null;
    }
    public static void trainsim_cmd(SimCommand command) {
      do_command(command, true);
    }

    public static void load_new_scenario(String cmd, LoadScenarioType fl) {
      if(cmd == null)
        return;

      cmd = cmd.Trim();
      //if(running)
      //    start_stop();
      //if(layout_modified) {
      //    if(ask_to_save_layout() < 0)	// cancel selected
      //  return;
      //}
      //clean_trains(schedule);
      //clean_trains(stranded);
      //schedule = 0;
      //stranded = 0;
      invalidate_field();
      //enable_training = 0;
      //if(fl == 2) {
      //    load_puzzles(cmd);
      //    trainsim_init();		/* clear counters, timer */
      //    load_scripts(layout);	// run OnInit scripts
      //    enable_training = 1;
      //} else {
      if((layout = load_field(cmd)) == null) {
        //  status_line = String.Format( wxPorting.T("%s '%s.trk'"), wxPorting.L("cannot load"), cmd);
        //  Globals.traindir.Error(status_line);
        //  return;
      }
      //    if(!(schedule = load_trains(cmd)))
      //  Globals.traindir.Error(wxPorting.L("No schedule for this territory!"));
      //    if(fl && !all_trains_everyday(schedule) && select_day_dialog)
      //  select_day_dialog();
      //    if(fl)
      //  check_delayed_entries(schedule);
      //    /* fill_schedule(schedule, 0); */
      //    trainsim_init();		/* clear counters, timer */
      //    load_scripts(layout);	// run OnInit scripts
      //           bstreet_playing();
      //}

      //TDFile	infoFile = new TDFile(cmd);

      //       String ext;

      //       ext = String.Format(wxPorting.T("%s.htm"), locale_name);
      //       infoFile.SetExt(ext);
      //       if(infoFile.Load()) {
      //    Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
      //    info_page = infoFile.name.GetName();
      //       } else {
      //           infoFile.SetExt(wxPorting.T(".htm"));
      //    if(infoFile.Load()) {
      //        Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), infoFile.content);
      //        info_page = infoFile.name.GetName();
      //    } else {
      //        TDFile	indexFile = new TDFile(wxPorting.T("index.htm"));
      //        if(indexFile.Load()) {
      //      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Scenario Info"), indexFile.content);
      //      info_page = wxPorting.T("index.htm");
      //        } else
      //      info_page = wxPorting.T("");
      //    }
      //       }
      //if(fl == 2) {
      //    show_puzzle();
      //}
      repaint_all();
      //       timetable._lastReloaded = ++lastModTime;
      //       timetable.NotifyListeners();
    }

    public static void link_all_tracks(Track layout) {
      Track t, l;

      l = null;
      for(t = layout; t != null; t = t.next)
        if(t is Track) {
          t.next1 = l;
          l = t;
        }
      track_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t is TrackSignal) {
          t.next1 = l;
          l = t;
        }
      signal_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t is TrackSwitch) {
          t.next1 = l;
          l = t;
        }
      switch_list = l;
      l = null;
      for(t = layout; t != null; t = t.next)
        if(t is TrackText) {
          t.next1 = l;
          l = t;
        }
      text_list = l;
    }
  }
}