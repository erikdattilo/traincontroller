 /*	ScenarioInfoDialog.cpp - Created by Giampiero Caprino
 
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
using System.Drawing;
using System;

namespace TrainDirPorting {

  public class ScenarioInfoDialog : Dialog {
    public TextCtrl m_notes;

    public ScenarioInfoDialog(Window parent)
      : base(parent, 0, wxPorting.L("Scenario Information"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Scenario Information")) {
      BoxSizer buttonCol = new BoxSizer(Orientation.wxVERTICAL);
      BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      BoxSizer leftColumn = new BoxSizer(Orientation.wxVERTICAL);
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      ListItem col = new ListItem();

      m_notes = new TextCtrl(this, wxID_ANY, Globals.wxEmptyString,
          Window.wxDefaultPosition, new Size(200, 100), WindowStyles.TE_MULTILINE);

      leftColumn.Add(m_notes, 2, SizerFlag.wxGROW | SizerFlag.wxALL, 3);

      row.Add(leftColumn, 60, SizerFlag.wxGROW | SizerFlag.wxRIGHT | SizerFlag.wxLEFT, 3);

      buttonCol.Add(row, 0, SizerFlag.wxGROW | SizerFlag.wxALL, 5);

      row = new BoxSizer(Orientation.wxHORIZONTAL);
      row.Add(new Button(this, wxID_OK, wxPorting.L("&OK")), 0, SizerFlag.wxALL, 4);
      row.Add(new Button(this, wxID_CANCEL, wxPorting.L("&Cancel")), 0, SizerFlag.wxALL, 4);

      buttonCol.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);
      SetSizer(buttonCol);
      buttonCol.Fit(this);
      buttonCol.SetSizeHints(this);
    }
    public override ShowModalResult ShowModal() {
      throw new NotImplementedException();
      //string buff;
      //int i;
      //string p;
      //String str;

      //str = wxPorting.T("");
      //TextList t, last;

      //for(t = Globals.track_info; t != null; t = t.next) {
      //  str += t.txt;
      //}
      //m_notes.Value = (str);
      //m_notes.SetFocus();

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //if(base.ShowModal() == ShowModalResult.OK) {
      //  str = m_notes.Value;
      //  while(Globals.track_info != null) {
      //    t = Globals.track_info.next;
      //    Globals.free(Globals.track_info.txt);
      //    Globals.free(Globals.track_info);
      //    Globals.track_info = t;
      //  }
      //  last = null;
      //  i = 0;
      //  p = str;
      //  if(Globals.wxStrlen(p) > 0 && p[Globals.wxStrlen(p) - 1] != 'n')
      //    str += 'n';
      //  for(p = str; p.Length > 0; ) {
      //    if(p[0] != 'n') {
      //      buff[i++] = *p.incPointer();
      //      continue;
      //    }
      //    buff = buff.Substring(0, i);
      //    p.incPointer();
      //    i = 0;
      //    t = new TextList();
      //    t.next = null;
      //    t.txt = String.Copy(buff);
      //    if(Globals.track_info == null)
      //      Globals.track_info = t;
      //    else
      //      last.next = t;
      //    last = t;
      //  }
      //}
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //return ShowModalResult.OK;
    }
  }
}