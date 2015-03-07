 /*	Alerts.cpp - Created by Giampiero Caprino
 
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

  public class AlertLine : LinkItem<AlertLine> {
    public AlertLine() { _text = null; }
    ~AlertLine() { Globals.free(_text); }
    public string _text;
    public int _modTime;
  };

  public partial class Globals {
    public static AlertLine firstAlert, lastAlert;
    public static Alerts alerts;
  }

  public class Alerts : SynchronizedList<AlertLine> {
    public AlertLine AddLine(string text) {
      AlertLine line = AppendNewItem();
      line._text = String.Copy(text);
      line._modTime = Globals.lastModTime++;
      return line;
    }

  }
}