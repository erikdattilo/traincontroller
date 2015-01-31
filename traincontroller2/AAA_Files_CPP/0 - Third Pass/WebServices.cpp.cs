 /*	WebServices.cpp - Created by Giampiero Caprino
 
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
  public class WS_Trains : Servlet {
    public WS_Trains()
      : base("/war/trains.json") {
    }

    // } ws_trains;

    public override bool get(string outStr, string args) {
      Train trn;
      string sep = wxPorting.T("{\n");
      TrainInfo info = new TrainInfo();

      outStr.append(wxPorting.T("{trains:\n["));
      for(trn = Globals.schedule; trn != null; trn = trn.next) {
        outStr.append(sep);
        trn.Get(info);
        json(outStr, wxPorting.T("name"), trn.name);
        json(outStr, wxPorting.T("entry"), trn.entrance);
        json(outStr, wxPorting.T("exit"), trn.exit);
        json(outStr, wxPorting.T("timeIn"), info.entering_time);
        json(outStr, wxPorting.T("timeoutStr"), info.leaving_time);
        json(outStr, wxPorting.T("speed"), info.current_speed);
        json(outStr, wxPorting.T("delay"), info.current_delay);
        json(outStr, wxPorting.T("late"), info.current_late);
        json(outStr, wxPorting.T("status"), info.current_status, true);
        sep = wxPorting.T("},\n{");
      }
      outStr.append(wxPorting.T("}\n]\n}\n"));
      return true;
    }
  }

  public class WS_Stations : Servlet {
    public WS_Stations() : base("/war/stations.json") { }
    public override string getMimeType() { return MIME_JSON; }
    //  } ws_stations;

    public override bool get(string outStr, string args) {
      Track trk;
      Track[] stations;
      int i;
      string sep = wxPorting.T("{");

      outStr.append(wxPorting.T("{stations:n["));
      stations = Globals.get_station_list();
      if(stations != null) {
        for(i = 0; stations[i] != null; ++i) {
          trk = stations[i];
          outStr.append(sep);
          json(outStr, wxPorting.T("name"), trk.station, true);
          sep = wxPorting.T("},\n{");
        }
        outStr.append(wxPorting.T("}"));
      }
      outStr.append(wxPorting.T("\n]\n}\n"));
      return true;
    }


    public class WS_TrainStops : Servlet {
      public WS_TrainStops() : base("/war/stops.json") { }
      public override string getMimeType() { return MIME_JSON; }
      //  } ws_train_stops;

      public override bool get(String outStr, string args) {
        Train trn;
        TrainStop stp;
        string sep = wxPorting.T("{");

        outStr.append(wxPorting.T("{\n"));
        if(Globals.wxStrncmp(args, wxPorting.T("t="), 2) == 0) {
          trn = Globals.find_train(Globals.schedule, args + 2);
          if(trn != null) {
            json(outStr, wxPorting.T("name"), trn.name);
            outStr.append(wxPorting.T("\"stops\" :\n["));
            for(stp = trn.stops; stp != null; stp = stp.next) {
              outStr.append(sep);
              json(outStr, wxPorting.T("station"), stp.station);
              json(outStr, wxPorting.T("arrival"), Globals.format_time(stp.arrival));
              json(outStr, wxPorting.T("departure"), Globals.format_time(stp.departure));
              json(outStr, wxPorting.T("minstop"), stp.minstop);
              json(outStr, wxPorting.T("stopped"), stp.stopped);
              json(outStr, wxPorting.T("late"), stp.late);
              json(outStr, wxPorting.T("delay"), stp.delay, true);
              sep = wxPorting.T("},\n{");
            }
            if(trn.stops != null)
              outStr.append(wxPorting.T("}"));
            outStr.append(wxPorting.T("\n]\n"));
          }
        }
        outStr.append(wxPorting.T("}\n"));
        return true;
      }
    }


    public class WS_Schedule : Servlet {
      public WS_Schedule() : base("/war/sched.json") { }
      public override string getMimeType() { return MIME_JSON; }
      // } ws_schedule;

      public override bool get(String outStr, string args) {
      throw new NotImplementedException();
      //  string sep = wxPorting.T("n{ ");
      //  string buff;
      //  string p;
      //  int r;
      //  outStr.append(wxPorting.T("{schedule:n["));

      //  if(Globals.wxStrncmp(args, wxPorting.T("s="), 2) == 0) {
      //    Globals.build_station_schedule(args + 2);
      //    station_sched sc;

      //    for(sc = Globals.stat_sched; sc != null; sc = sc.next) {
      //      outStr.append(sep);
      //      json(outStr, wxPorting.T("train"), sc.tr.name);
      //      json(outStr, wxPorting.T("arrival"), sc.arrival != -1 ? Globals.format_time(sc.arrival) : wxPorting.T(""));
      //      json(outStr, wxPorting.T("entrance"), sc.tr.entrance);
      //      json(outStr, wxPorting.T("departure"), sc.departure != -1 ? Globals.format_time(sc.departure) : wxPorting.T(""));
      //      json(outStr, wxPorting.T("exit"), sc.tr.exit);
      //      buff[0] = 0;
      //      if(String.IsNullOrEmpty(sc.stopname) == false && (p = Globals.wxStrchr(sc.stopname, '@')) != null)
      //        buff = String.Copy( p + 1);
      //      json(outStr, wxPorting.T("platform"), buff);
      //      int x = 0;
      //      if(sc.tr.days != 0) {
      //        for(r = 0; r < 7; ++r)
      //          if(((int)sc.tr.days & (1 << r)) != 0)
      //            buff.ReplaceAt(x++, (char)(r + '1'));
      //      }
      //      buff[x] = 0;
      //      json(outStr, wxPorting.T("days"), buff, true);
      //      sep = wxPorting.T("},n{ ");
      //    }
      //    if(Globals.stat_sched != null)
      //      outStr.append(wxPorting.T("}"));
      //  }
      //  outStr.append(wxPorting.T("\n]\n}\n"));
      //  return true;
      }
    }


    public class WS_Alerts : Servlet {
      public WS_Alerts() : base("/war/alerts.json") { }
      public override string getMimeType() { return MIME_JSON; }
      // } ws_alerts;

      public override bool get(String outStr, string args) {
        string sep = wxPorting.T("\n");
        AlertLine alert;
        String str;

        outStr.append(wxPorting.T("{alerts:n["));
        Globals.alerts.Lock();
        for(alert = Globals.alerts._firstItem; alert != null; alert = alert._next) {
          str = String.Format(wxPorting.T("\"%s\""), alert._text);
          outStr.append(str);
          sep = wxPorting.T(",\n");
        }
        Globals.alerts.Unlock();
        outStr.append(wxPorting.T("\n]\n}\n"));
        return true;
      }
    }

    public class EventListListener : EventListener {
      public EventListListener() { _sema = new wxSemaphore(0, 0); }
      public wxSemaphore _sema;
      // } events_listener;

      public wxSemaError Wait() {
        return _sema.WaitTimeout(20000);
      }

      public override void OnEvent(object list) {
        _sema.Post();
      }
    }

    public class WS_Events : Servlet {
      public WS_Events() : base("/war/events.json") { }
      public override string getMimeType() { return MIME_JSON; }
      // } ws_events;

      public override bool get(String outStr, string args) {
        throw new NotImplementedException();

        //string buff;
        //string sep = wxPorting.T("{");

        //int lastEventId = 0;
        //if(String.IsNullOrEmpty(args) == false && Globals.wxStrncmp(args, "l=", 2) == 0) {
        //  lastEventId = Globals.wxStrtoul(args + 2, args, 10);
        //}
        //outStr.append(wxPorting.T("{\n\"events\" : {\n"));
        //if(lastEventId >= Globals.lastModTime) {
        //  // wait here until some event is available (i.e. lastEventId < lastModTime)
        //  Globals.alerts.AddListener(events_listener);
        //  Globals.timetable.AddListener(events_listener);
        //  wxSemaError error = events_listener.Wait();
        //  Globals.timetable.RemoveListener(events_listener);
        //  Globals.alerts.RemoveListener(events_listener);
        //  if(error != wxSEMA_NO_ERROR) {
        //    buff = String.Format("  \"lastMod\" : %d,\n", Globals.lastModTime);
        //    outStr.append(buff);
        //    outStr.append(wxPorting.T("  \"reloaded\": "));
        //    if(Globals.timetable._lastReloaded > lastEventId) {
        //      outStr.append(wxPorting.T("\"true\""));
        //    } else {
        //      outStr.append(wxPorting.T("\"false\""));
        //    }
        //    outStr.append(wxPorting.T("n  }\n}\n"));   // end events
        //    return true;
        //  }
        //}
        //buff = string.Format("  \"lastMod\" : %d,\n", Globals.lastModTime);
        //outStr.append(buff);

        //// return alerts

        //outStr.append(wxPorting.T("  \"alerts\": [\n"));
        //AlertLine line;
        //sep = wxPorting.T("    {");
        //for(line = Globals.alerts._firstItem; line != null; line = line._next) {
        //  if(line._modTime < lastEventId) {
        //    continue;
        //  }
        //  outStr.append(sep);
        //  outStr.append(wxPorting.T(" \"msg\":\""));
        //  outStr.append(line._text);
        //  outStr.append(wxPorting.T("\" }"));
        //  sep = wxPorting.T(",\n    {");
        //}
        //outStr.append(wxPorting.T("\n],\n"));

        //outStr.append(wxPorting.T("  \"timetable\": [\n"));
        //Train tr;
        //TrainInfo info;
        //sep = wxPorting.T("    {");
        //for(tr = Globals.schedule; tr != null; tr = tr.next) {
        //  if(tr._lastUpdate < lastEventId)
        //    continue;
        //  if(String.IsNullOrEmpty(tr.entrance) || tr.isExternal)
        //    continue;
        //  if(!Globals.show_canceled && Globals.is_canceled(tr))
        //    continue;

        //  string internalStatus = 0; // non-localized version of tr.status
        //  if(tr.status == trainstat.train_ARRIVED) {
        //    if(String.IsNullOrEmpty(tr.stock) == false) {
        //      Train t1 = Globals.findTrainNamed(tr.stock);
        //      if(t1 != null && t1.status != trainstat.train_READY) {
        //        internalStatus = wxPorting.T("to-be-assigned");
        //        break;
        //      }
        //    }
        //  }
        //  if(internalStatus == 0) {
        //    switch(tr.status) {
        //      case trainstat.train_ARRIVED:
        //        internalStatus = wxPorting.T("arrived");
        //        break;
        //      case trainstat.train_DELAY:
        //        internalStatus = wxPorting.T("delayed");
        //        break;
        //      case trainstat.train_DERAILED:
        //        internalStatus = wxPorting.T("derailed");
        //        break;
        //      case trainstat.train_READY:
        //        internalStatus = wxPorting.T("ready");
        //        break;
        //      case trainstat.train_RUNNING:
        //        internalStatus = wxPorting.T("running");
        //        break;
        //      case trainstat.train_STOPPED:
        //        internalStatus = wxPorting.T("stopped");
        //        break;
        //      case trainstat.train_WAITING:
        //        internalStatus = wxPorting.T("waiting");
        //        break;
        //      default:
        //        internalStatus = wxPorting.T("?");
        //    }
        //  }
        //  tr.Get(info);

        //  outStr.append(sep);
        //  outStr.append(wxPorting.T(" \"name\":\""));
        //  outStr.append(tr.name);
        //  outStr.append(wxPorting.T("\",\n  \"entry\":\""));
        //  outStr.append(tr.entrance);
        //  outStr.append(wxPorting.T("\",\n  \"exit\":\""));
        //  outStr.append(tr.exit);
        //  outStr.append(wxPorting.T("\",\n  \"timeIn\":\""));
        //  outStr.append(info.entering_time);
        //  outStr.append(wxPorting.T("\",\n  \"timeOut\":\""));
        //  outStr.append(info.leaving_time);
        //  outStr.append(wxPorting.T("\",\n  \"speed\":\""));
        //  outStr.append(info.current_speed);
        //  outStr.append(wxPorting.T("\",\n  \"status\":\""));
        //  outStr.append(info.current_status);
        //  outStr.append(wxPorting.T("\",\n  \"internalstatus\":\""));
        //  outStr.append(internalStatus);
        //  outStr.append(wxPorting.T("\",\n  \"late\":\""));
        //  outStr.append(info.current_late);
        //  outStr.append(wxPorting.T("\"\n  }"));
        //  sep = wxPorting.T(",\n    {");
        //}

        //outStr.append(wxPorting.T("\n],\n"));

        //outStr.append(wxPorting.T("  \"reloaded\": "));
        //if(Globals.timetable._lastReloaded > lastEventId) {
        //  outStr.append(wxPorting.T("\"true\"\n"));
        //} else {
        //  outStr.append(wxPorting.T("\"false\"n"));
        //}
        //outStr.append(wxPorting.T("}\n}\n"));   // end events
        //return true;
      }
    }
  }
}