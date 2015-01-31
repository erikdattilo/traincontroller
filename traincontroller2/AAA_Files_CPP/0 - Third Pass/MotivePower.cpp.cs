/*	MotivePower.cpp - Created by Giampiero Caprino
 
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

 /*      3.9: support motive power specifications in tracks and trains
  *
  *      Motive power is simply specified as a string to represent the
  *      characteristics of the power used on a track or by the train's locomotive.
  *      For example, one can specify the voltage of the electric line
  *      used for a certain stretch of track.
  *      When motive power is specified both on tracks (layout) and on
  *      trains (schedule), the runner will check if the train can enter
  *      a new block.
  *      No power specified for a train means that the train can travel
  *      on any track (e.g. it's diesel-powered).
  */

using System;
namespace Traincontroller2 {
  public partial class Globals {
    public static Array<string> gMotivePowerCache;
    public static string gEditorMotivePower;

    public static IntOption editor_gauge = new IntOption(wxPorting.T("editor_gauge"),
                                 wxPorting.T("Default Track Gauge"),
                                 wxPorting.T("Editor"), wxPorting.T(""));

    public static string power_clean(string p) {
      string clean = ""; // Erik: Original code ==> static Char clean[128];
      int max = clean.Length; // Erik: Original code ==> int max = sizeof(clean) / sizeof(clean[0]);
      int x = 0;

      for(x = 0; x < p.Length; p.incPointer()) {
        if(p[0] == ' ')
          continue;
        if(p[0] == 'n')
          break;
        if(x < max - 1)
          clean.ReplaceAt(x++, p[0]);
      }
      // Erik: original code ==>
      // clean[x] = 0;
      // clean[max - 1] = 0;
      clean = clean.Substring(0, Math.Min(x, max - 1));

      return clean;
    }

    public static string power_find(string p) {
      throw new NotImplementedException();
      //for(int i = 0; i < gMotivePowerCache.Length(); ++i) {
      //  string pc = gMotivePowerCache.At(i);
      //  if(!wxStrcmp(pc, p))
      //    return pc;
      //}
      //return null;
    }

    public static string power_add(string pwr) {
      string pc = String.Copy(pwr);
      gMotivePowerCache.Add(pc);
      return pc;
    }

    public static string power_parse(string p) {
      p = power_clean(p);
      string pc = power_find(p);
      if(pc != null)
        return pc;
      return power_add(p);
    }

    public static void power_select(string pwr) {
      string pc = power_find(pwr);
      if(pc == null) {
        pc = power_add(pwr);
      }
      gEditorMotivePower = pc;
    }
  }
}