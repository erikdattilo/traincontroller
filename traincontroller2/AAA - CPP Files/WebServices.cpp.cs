// /*	WebServices.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */
// 
// #include <wx/thread.h>
// #include "Traindir3.h"
// #include "trsim.h"
// #include "Train.h"
// #include "Array.h"
// #include "Server.h"
// 
// Train	*find_train(Train *sched, const Char *name);
// bool    ignore_train(Train *tr);
// 
// class WS_Trains : public Servlet
// {
// public:
//         WS_Trains() : Servlet("/war/trains.json") { };
//         ~WS_Trains() { };
//         const char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_trains;
// 
// bool    WS_Trains::get(wxString& out, Char *args)
// {
//         Train   *trn;
//         const Char *sep = wxT("{n");
//         TrainInfo info;
// 
//         out.append(wxT("{trains:n["));
//         for(trn = schedule; trn; trn = trn->next) {
//             out.append(sep);
//             trn->Get(info);
//             json(out, wxT("name"), trn->name);
//             json(out, wxT("entry"), trn->entrance);
//             json(out, wxT("exit"), trn->exit);
//             json(out, wxT("timeIn"), info.entering_time);
//             json(out, wxT("timeOut"), info.leaving_time);
//             json(out, wxT("speed"), info.current_speed);
//             json(out, wxT("delay"), info.current_delay);
//             json(out, wxT("late"), info.current_late);
//             json(out, wxT("status"), info.current_status, true);
//             sep = wxT("},n{");
//         }
//         out.append(wxT("}n]n}n"));
//         return true;
// }
// 
// 
// class WS_Stations : public Servlet
// {
// public:
//         WS_Stations() : Servlet("/war/stations.json") { };
//         ~WS_Stations() { };
//        const Char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_stations;
// 
// bool    WS_Stations::get(wxString& out, Char *args)
// {
//         Track   *trk;
//         Track   **stations;
//         int     i;
//         const Char *sep = wxT("{");
// 
//         out.append(wxT("{stations:n["));
//         stations = get_station_list();
//         if(stations) {
//             for(i = 0; stations[i]; ++i) {
//                 trk = stations[i];
//                 out.append(sep);
//                 json(out, wxT("name"), trk->station, true);
//                 sep = wxT("},n{");
//             }
//             out.append(wxT("}"));
//         }
//         out.append(wxT("n]n}n"));
//         return true;
// }
// 
// 
// class WS_TrainStops : public Servlet
// {
// public:
//         WS_TrainStops() : Servlet("/war/stops.json") { };
//         ~WS_TrainStops() { };
//         const char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_train_stops;
// 
// bool    WS_TrainStops::get(wxString& out, Char *args)
// {
//         Train   *trn;
//         TrainStop *stp;
//         const Char *sep = wxT("{");
// 
//         out.append(wxT("{n"));
//         if(!wxStrncmp(args, wxT("t="), 2)) {
//             trn = find_train(schedule, args + 2);
//             if(trn) {
//                 json(out, wxT("name"), trn->name);
//                 out.append(wxT(""stops" :n["));
//                 for(stp = trn->stops; stp; stp = stp->next) {
//                     out.append(sep);
//                     json(out, wxT("station"), stp->station);
//                     json(out, wxT("arrival"), format_time(stp->arrival));
//                     json(out, wxT("departure"), format_time(stp->departure));
//                     json(out, wxT("minstop"), stp->minstop);
//                     json(out, wxT("stopped"), stp->stopped);
//                     json(out, wxT("late"), stp->late);
//                     json(out, wxT("delay"), stp->delay, true);
//                     sep = wxT("},n{");
//                 }
//                 if(trn->stops)
//                     out.append(wxT("}"));
//                 out.append(wxT("n]n"));
//             }
//         }
//         out.append(wxT("}n"));
//         return true;
// }
// 
// 
// class WS_Schedule : public Servlet
// {
// public:
//         WS_Schedule() : Servlet("/war/sched.json") { };
//         ~WS_Schedule() { };
//         const char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_schedule;
// 
// bool    WS_Schedule::get(wxString& out, Char *args)
// {
//         const Char *sep = wxT("n{ ");
//         Char buff[40];
//         Char    *p;
//         int     r;
//         out.append(wxT("{schedule:n["));
// 
//         if(!wxStrncmp(args, wxT("s="), 2)) {
//        	    build_station_schedule(args + 2);
//             struct station_sched *sc;
// 
//             for(sc = stat_sched; sc; sc = sc->next) {
//                 out.append(sep);
//                 json(out, wxT("train"), sc->tr->name);
//                 json(out, wxT("arrival"), sc->arrival != -1 ? format_time(sc->arrival) : wxT(""));
//                 json(out, wxT("entrance"), sc->tr->entrance);
//                 json(out, wxT("departure"), sc->departure != -1 ? format_time(sc->departure) : wxT(""));
//                 json(out, wxT("exit"), sc->tr->exit);
// 	        buff[0] = 0;
// 	        if(sc->stopname && (p = wxStrchr(sc->stopname, '@')))
// 		    wxStrcpy(buff, p + 1);
//                 json(out, wxT("platform"), buff);
// 	        int x = 0;
// 	        if(sc->tr->days) {
// 		    for(r = 0; r < 7; ++r)
// 		        if(sc->tr->days & (1 << r))
// 			    buff[x++] = r + '1';
// 	        }
// 	        buff[x] = 0;
//                 json(out, wxT("days"), buff, true);
//                 sep = wxT("},n{ ");
//             }
//             if(stat_sched)
//                 out.append(wxT("}"));
//         }
//         out.append(wxT("n]n}n"));
//         return true;
// }
// 
// 
// 
// class WS_Alerts : public Servlet
// {
// public:
//         WS_Alerts() : Servlet("/war/alerts.json") { };
//         ~WS_Alerts() { };
//         const char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_alerts;
// 
// bool    WS_Alerts::get(wxString& out, Char *args)
// {
//         const Char *sep = wxT("n");
//         AlertLine *alert;
//         wxString    str;
// 
//         out.append(wxT("{alerts:n["));
//         alerts.Lock();
//         for(alert = alerts._firstItem; alert; alert = alert->_next) {
//             str.Printf(wxT(""%s""), alert->_text);
//             out.append(str);
//             sep = wxT(",n");
//         }
//         alerts.Unlock();
//         out.append(wxT("n]n}n"));
//         return true;
// }
// 
// 
// class EventListListener : public EventListener
// {
// public:
//         EventListListener() { _sema = new wxSemaphore(0, 0); }
//         ~EventListListener() { };
// 
//         wxSemaError Wait();
//         void    OnEvent(void *list);
// 
//         wxSemaphore *_sema;
// } events_listener;
// 
// wxSemaError EventListListener::Wait()
// {
//         return _sema->WaitTimeout(20000);
// }
// 
// void    EventListListener::OnEvent(void *list)
// {
//          _sema->Post();
// }
// 
// class WS_Events : public Servlet
// {
// public:
//         WS_Events() : Servlet("/war/events.json") { };
//         ~WS_Events() { };
//        const Char *getMimeType() const { return MIME_JSON; };
// 
//         bool    get(wxString& out, Char *args);
// } ws_events;
// 
// bool    WS_Events::get(wxString& out, Char *args)
// {
//         Char    buff[64];
//         const Char *sep = wxT("{");
// 
//         int     lastEventId = 0;
//         if(args && !wxStrncmp(args, "l=", 2)) {
//             lastEventId = wxStrtoul(args + 2, &args, 10);
//         }
//         out.append(wxT("{n"events" : {n"));
//         if(lastEventId >= lastModTime) {
//             // wait here until some event is available (i.e. lastEventId < lastModTime)
//             alerts.AddListener(&events_listener);
//             timetable.AddListener(&events_listener);
//             wxSemaError error = events_listener.Wait();
//             timetable.RemoveListener(&events_listener);
//             alerts.RemoveListener(&events_listener);
//             if(error != wxSEMA_NO_ERROR) {
//                 wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]), "  "lastMod" : %d,n", lastModTime);
//                 out.append(buff);
//                 out.append(wxT("  "reloaded": "));
//                 if(timetable._lastReloaded > lastEventId) {
//                     out.append(wxT(""true""));
//                 } else {
//                     out.append(wxT(""false""));
//                 }
//                 out.append(wxT("n  }n}n"));   // end events
//                 return true;
//             }
//         }
//         wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]), "  "lastMod" : %d,n", lastModTime);
//         out.append(buff);
// 
//         // return alerts
// 
//         out.append(wxT("  "alerts": [n"));
//         AlertLine *line;
//         sep = wxT("    {");
//         for(line = alerts._firstItem; line; line = line->_next) {
//             if(line->_modTime < lastEventId) {
//                 continue;
//             }
//             out.append(sep);
//             out.append(wxT(" "msg":""));
//             out.append(line->_text);
//             out.append(wxT("" }"));
//             sep = wxT(",n    {");
//         }
//         out.append(wxT("n],n"));
// 
//         out.append(wxT("  "timetable": [n"));
//         Train *tr;
//         TrainInfo info;
//         sep = wxT("    {");
//         for(tr = schedule; tr; tr = tr->next) {
//             if(tr->_lastUpdate < lastEventId)
//                 continue;
//             if(!tr->entrance || tr->isExternal)
//                 continue;
//             if(!show_canceled && is_canceled(tr))
//                 continue;
// 
//             const Char *internalStatus = 0; // non-localized version of tr->status
//             if(tr->status == train_ARRIVED) {
//                 if(tr->stock) {
// 	            Train *t1 = findTrainNamed(tr->stock);
//                     if(t1 && t1->status != train_READY) {
//                         internalStatus = wxT("to-be-assigned");
//                         break;
//                     }
//                 }
//             }
//             if(internalStatus == 0) {
//                 switch(tr->status) {
//                 case train_ARRIVED:
//                     internalStatus = wxT("arrived");
//                     break;
//                 case train_DELAY:
//                     internalStatus = wxT("delayed");
//                     break;
//                 case train_DERAILED:
//                     internalStatus = wxT("derailed");
//                     break;
//                 case train_READY:
//                     internalStatus = wxT("ready");
//                     break;
//                 case train_RUNNING:
//                     internalStatus = wxT("running");
//                     break;
//                 case train_STOPPED:
//                     internalStatus = wxT("stopped");
//                     break;
//                 case train_WAITING:
//                     internalStatus = wxT("waiting");
//                     break;
//                 default:
//                     internalStatus = wxT("?");
//                 }
//             }
//             tr->Get(info);
// 
//             out.append(sep);
//             out.append(wxT(" "name":""));
//             out.append(tr->name);
//             out.append(wxT("",n  "entry":""));
//             out.append(tr->entrance);
//             out.append(wxT("",n  "exit":""));
//             out.append(tr->exit);
//             out.append(wxT("",n  "timeIn":""));
//             out.append(info.entering_time);
//             out.append(wxT("",n  "timeOut":""));
//             out.append(info.leaving_time);
//             out.append(wxT("",n  "speed":""));
//             out.append(info.current_speed);
//             out.append(wxT("",n  "status":""));
//             out.append(info.current_status);
//             out.append(wxT("",n  "internalstatus":""));
//             out.append(internalStatus);
//             out.append(wxT("",n  "late":""));
//             out.append(info.current_late);
//             out.append(wxT(""n  }"));
//             sep = wxT(",n    {");
//         }
//   //      SetItem(i, 0, info.entering_time);
// //	SetItem(i, 3, info.leaving_time);
// //	SetItem(i, 5, info.current_speed);
// //	SetItem(i, 6, info.current_delay);
// //	SetItem(i, 7, info.current_late);
// //	SetItem(i, 8, info.current_status);
// //	for(n = 0; n < MAXNOTES; ++n) {
// //	    notes += t->notes[n] ? t->notes[n] : wxT("");
// //	    notes += wxT(" ");
// //	}
// //	SetItem(i, 9, notes);
//   //      }
//         out.append(wxT("n],n"));
// 
//         out.append(wxT("  "reloaded": "));
//         if(timetable._lastReloaded > lastEventId) {
//             out.append(wxT(""true"n"));
//         } else {
//             out.append(wxT(""false"n"));
//         }
//         out.append(wxT("}n}n"));   // end events
//         return true;
// }
// 
// 
