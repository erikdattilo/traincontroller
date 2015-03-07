 /*	trsim.cpp - Created by Giampiero Caprino
 
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

namespace TrainDirPorting {
  public partial class Configuration {
    public static int MAXPUZZLESIGNALS = 20;
    public static int MAXPUZZLESWITCHES = 20;
    public static int MAXPUZZLESPEEDS = 20;
    public static int MAXPUZZLELENGTHS = 20;
    public static int MAXPUZZLESCRIPTS = 100;

    public static int MAXSPEEDS = Config.NTTYPES;
  }

  public class Speed {
    public Track station;
    public int[] speeds = new int[Configuration.MAXSPEEDS];
    public int nSpeeds;
  }

  public class Puzzle {
    public Signal[] signals = new Signal[Configuration.MAXPUZZLESIGNALS];
    public int nSignals;

    public Track[] switches = new Track[Configuration.MAXPUZZLESWITCHES];
    public int nSwitches;

    public Speed[] speeds = new Speed[Configuration.MAXPUZZLESPEEDS];
    public int nSpeeds;

    public Speed[] lengths = new Speed[Configuration.MAXPUZZLELENGTHS];
    public int nLengths;
  }


  public partial class Globals {
    public static int mystery_signal = 0;

    public static Puzzle puzzle;

    public static Signal get_signal(String p) {
      if(p[0] >= '0' && p[0] <= '9') {
        int x = Globals.wxStrtol(p, ref p, 10);
        if(p[0] == ',') p.incPointer();
        int y = Globals.wxStrtol(p, ref p, 10);
        return findSignal(x, y);
      }
      return findSignalNamed(p);
    }

    public static Track get_track(String p) {
      if(p[0] >= '0' && p[0] <= '9') {
        int x = Globals.wxStrtol(p, ref p, 10);
        if(p[0] == ',') p.incPointer();
        int y = Globals.wxStrtol(p, ref p, 10);
        return findTrack(x, y);
      }
      return findStationNamed(p);
    }


    public static void load_puzzles(String cmd) {
      //TDFile puzzleFile = new TDFile(cmd);
      //String buff;
      //String p;
      //int l;

      //puzzleFile.SetExt(wxPorting.T(".tdp"));
      //if(!puzzleFile.Load()) {
      //  status_line = String.Format(wxPorting.T("%s '%s.tdp'"), wxPorting.L("cannot load"), cmd);
      //  Globals.traindir.Error(status_line);
      //  return;
      //}
      //if(puzzle != null) {
      //  Globals.delete(puzzle);
      //}
      //puzzle = new Puzzle();

      //while(puzzleFile.ReadLine(buff)) {
      //  if(buff.Length == 0 || buff[0] == '#')
      //    continue;
      //  if(buff[0] == '.') {
      //    continue;
      //  }
      //  for(l = 0; l < buff.Length; ++l)
      //    if(buff[l] == 't')
      //      buff.ReplaceAt(l, ' ');
      //  while(l != 0 && (buff[l - 1] == ' ' || buff[l - 1] == 't')) --l;
      //  buff = buff.Substring(0, l);
      //  if(Globals.wxStrncmp(buff, wxPorting.T("Layout: "), 8) == 0) {
      //    for(p = buff + 8; p[0] == ' '; p.incPointer()) ;
      //    if((layout = load_field(p)) == null) {
      //      status_line = String.Format( wxPorting.T("%s '%s.trk'"), wxPorting.L("cannot load"), cmd);
      //      Globals.traindir.Error(status_line);
      //      return;
      //    }
      //    continue;
      //  }
      //  if(Globals.wxStrncmp(buff, wxPorting.T("Signal: "), 8) == 0) {
      //    for(p = buff + 8; p[0] == ' '; p.incPointer()) ;
      //    Signal sig = get_signal(p);
      //    if(puzzle.nSignals < Configuration.MAXPUZZLESIGNALS) {
      //      puzzle.signals[puzzle.nSignals++] = sig;
      //    }
      //    continue;
      //  }
      //  if(Globals.wxStrncmp(buff, wxPorting.T("Switch: "), 8) == 0) {
      //    for(p = buff + 8; p[0] == ' '; p.incPointer()) ;
      //    int x, y;
      //    x = Globals.wxStrtol(p, ref p, 10);
      //    if(p[0] == ',') p.incPointer();
      //    y = Globals.wxStrtol(p, ref p, 10);
      //    Track trk = findSwitch(x, y);
      //    if(puzzle.nSwitches < Configuration.MAXPUZZLESWITCHES) {
      //      puzzle.switches[puzzle.nSwitches++] = trk;
      //    }
      //    continue;
      //  }
      //  if(Globals.wxStrncmp(buff, wxPorting.T("Speed: "), 7) == 0) {
      //    if(puzzle.nSpeeds >= Configuration.MAXPUZZLESPEEDS)
      //      continue;
      //    for(p = buff + 7; p[0] == ' '; p.incPointer()) ;
      //    Speed speed = new Speed();
      //    Array.Clear(speed.speeds, 0, speed.speeds.Length);
      //    int i = 0;
      //    while(p.Length > 0) {
      //      speed.speeds[i++] = Globals.wxStrtol(p, ref p, 10);
      //      if(p[0] != '/' || i >= Configuration.MAXSPEEDS)
      //        break;
      //      p.incPointer();
      //    }
      //    speed.nSpeeds = i;
      //    for(; p[0] == ' '; p.incPointer()) ;
      //    speed.station = get_track(p);
      //    puzzle.speeds[puzzle.nSpeeds++] = speed;
      //    continue;
      //  }
      //  if(Globals.wxStrncmp(buff, wxPorting.T("Length: "), 8) == 0) {
      //    if(puzzle.nLengths >= Configuration.MAXPUZZLELENGTHS)
      //      continue;
      //    for(p = buff + 8; p[0] == ' '; p.incPointer()) ;
      //    Speed speed = new Speed();
      //    Array.Clear(speed.speeds, 0, speed.speeds.Length);
      //    int i = 0;
      //    while(p.Length > 0) {
      //      speed.speeds[i++] = Globals.wxStrtol(p, ref p, 10);
      //      if(p[0] != '/' || i >= Configuration.MAXSPEEDS)
      //        break;
      //      p.incPointer();
      //    }
      //    speed.nSpeeds = i;
      //    for(; p[0] == ' '; p.incPointer()) ;
      //    speed.station = get_track(p);
      //    puzzle.lengths[puzzle.nLengths++] = speed;
      //    continue;
      //  }
      //}
      //set_zoom(true);
    }

    public static void show_puzzle() {
      int i, j;
      Signal sig;
      Signal s;
      int which = Globals.rand() % puzzle.nSignals;

      for(i = 0; i < puzzle.nSignals; ++i) {
        sig = puzzle.signals[i];
        sig.invisible = false;
      }
      sig = puzzle.signals[which];
      sig.invisible = true;
      mystery_signal = which;

      /*
       *  Randomize lengths
       */

      for(i = 0; i < puzzle.nLengths; ++i) {
        which = Globals.rand() % puzzle.lengths[i].nSpeeds;
        puzzle.lengths[i].station.length = puzzle.lengths[i].speeds[which];
      }

      /*
       *  Randomize speeds
       */

      for(i = 0; i < puzzle.nSpeeds; ++i) {
        which = Globals.rand() % puzzle.speeds[i].nSpeeds;
        puzzle.speeds[i].station.speed[0] = puzzle.speeds[i].speeds[which];
      }

      /*
       *  Randomize switches
       */

      for(i = 0; i < puzzle.nSwitches; ++i) {
        which = Globals.rand() % 2;
        puzzle.switches[i].switched = which != 0;
      }

      /*
       *  Clear most signals
       */

      for(i = 0; i < puzzle.nSignals; ++i) {
        s = puzzle.signals[i];
        if(!s.IsClear()) {
          toggle_signal(s);
        }
      }

      /*
       *  Get hidden signal's aspect
       *  then select x other aspects
       *  to be chosen by the user
       */

      bool found;
      String aspect = sig._currentState;
      String[] aspects = new String[3];
      aspects[0] = aspect;
      int lim = sig.GetNAspects();
      for(i = 1; i < 3; ) {
        which = Globals.rand() % lim;
        aspect = sig.GetAspect(which);

        // make sure we have not selected this aspect already
        found = false;
        for(j = 1; j < i; ++j) {
          if(wxStrcmp(aspect, aspects[j]) == 0) {
            found = true;
            break;
          }
        }
        if(found)
          continue;
        aspects[i++] = aspect;
      }

      /*
       *  We now have 3 aspects to show the player,
       *  one of them the valid one. Chose a random
       *  order to show them to the user.
       */

      i = 0;
      String[] order = new String[3];
      for(j = 2; j >= 0; --j) {
        which = (j != 0) ? (Globals.rand() % j) : 0;
        order[i++] = aspects[which];
        aspects[which] = aspects[j];
      }

      s = findSignalNamed(wxPorting.T("TRY1"));
      s.stateProgram = String.Copy(sig.stateProgram);
      s.ParseProgram();
      s.SetAspect(order[0]);

      s = findSignalNamed(wxPorting.T("TRY2"));
      s.stateProgram = String.Copy(sig.stateProgram);
      s.ParseProgram();
      s.SetAspect(order[1]);

      s = findSignalNamed(wxPorting.T("TRY3"));
      s.stateProgram = String.Copy(sig.stateProgram);
      s.ParseProgram();
      s.SetAspect(order[2]);

    }

    private static int rand() {
      throw new NotImplementedException();
    }


    public static void puzzle_check(Track t) {
      Signal hiddenSignal = puzzle.signals[mystery_signal];
      Signal sig = null;
      if(wxStrcmp(t.station, wxPorting.T("B1")) == 0) {
        sig = findSignalNamed(wxPorting.T("TRY1"));
      } else if(wxStrcmp(t.station, wxPorting.T("B2")) == 0) {
        sig = findSignalNamed(wxPorting.T("TRY2"));
      } else if(wxStrcmp(t.station, wxPorting.T("B3")) == 0) {
        sig = findSignalNamed(wxPorting.T("TRY3"));
      } else
        return;

      if(wxStrcmp(hiddenSignal._currentState, sig._currentState) != 0) {
        do_alert(wxPorting.L("Wrong answer."));
      } else {
        Globals.traindir.AddAlert(wxPorting.L("Correct answer."));
        hiddenSignal.invisible = false;
        repaint_all();
      }
    }
  }
}