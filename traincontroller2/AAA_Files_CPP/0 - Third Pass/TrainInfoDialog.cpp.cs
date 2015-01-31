// /*	TrainInfoDialog.cpp - Created by Giampiero Caprino
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
using wx;
using System;
using System.Drawing;

namespace Traincontroller2 {
  public class TrainInfoDialog : Dialog {
    public TextCtrl m_name,
        m_type,
        m_entryPoint, m_entryTime,
        m_exitPoint, m_exitTime,
        m_waitFor, m_stockFor,
        m_runsOn, m_length,
        m_maxSpeed;
    public TextCtrl m_notes;
    public TrainInfoList m_stops;
    public Train m_train;



    public TextCtrl AddTextLine(BoxSizer column, string txt) {
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      StaticText header = new StaticText(this, 0, wxPorting.LV(txt));
      TextCtrl txtctrl = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      row.Add(header, 50, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT, 5);
      row.Add(txtctrl, 50, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT, 5);

      column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxALL, 5);

      return txtctrl;
    }

    public TrainInfoDialog(Window parent)
      : base(parent, 0, wxPorting.L("Train Properties"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Train Properties")) {
      //EVT_BUTTON((int)MenuIDs.ID_PRINT, new wx.EventListener(OnPrint));

      //BoxSizer buttonCol = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer leftColumn = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //ListItem col = new ListItem();

      //m_name = AddTextLine(column, wxPorting.L("Train name"));
      //m_type = AddTextLine(column, wxPorting.L("Train type"));
      //m_entryPoint = AddTextLine(column, wxPorting.L("Entry point"));
      //m_entryTime = AddTextLine(column, wxPorting.L("Entry time (hh:mm)"));
      //m_exitPoint = AddTextLine(column, wxPorting.L("Exit point"));
      //m_exitTime = AddTextLine(column, wxPorting.L("Exit time (hh:mm)"));
      //m_waitFor = AddTextLine(column, wxPorting.L("Wait arrival of train"));
      //m_stockFor = AddTextLine(column, wxPorting.L("Stock for train"));
      //m_runsOn = AddTextLine(column, wxPorting.L("Runs on"));
      //m_length = AddTextLine(column, wxPorting.L("Train length :"));
      //m_maxSpeed = AddTextLine(column, wxPorting.L("Max. speed :"));

      //m_stops = new TrainInfoList(this, wxPorting.L("Stops"));
      //m_notes = new TextCtrl(this, wxID_ANY, Globals.wxEmptyString, Window.wxDefaultPosition,
      //    new Size(200, 70), wxPorting.TE_MULTILINE);

      //leftColumn.Add(m_stops, 8, SizerFlag.wxGROW | SizerFlag.wxALL, 3);
      //leftColumn.Add(m_notes, 2, SizerFlag.wxGROW | SizerFlag.wxALL, 3);

      //row.Add(column, 40, SizerFlag.wxGROW | SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 3);
      //row.Add(leftColumn, 60, SizerFlag.wxGROW | SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 3);

      //buttonCol.Add(row, 0, SizerFlag.wxGROW | SizerFlag.wxALL, 5);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);
      //row.Add(new Button(this, (int)MenuIDs.ID_PRINT, wxPorting.L("&Print")), 0, SizerFlag.wxALL, 4);
      //row.Add(new Button(this, (int)wx.MenuIDs.wxID_OK, wxPorting.L("&Close")), 0, SizerFlag.wxALL, 4);

      //column.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);
      //SetSizer(buttonCol);
      //buttonCol.Fit(this);
      //buttonCol.SetSizeHints(this);
    }

    void OnPrint(object sender, Event evt) {
      Globals.ShowTrainInfo(m_train);
    }

    public ShowModalResult ShowModal(Train t) {
      throw new NotImplementedException();
      //String buff;
      //int i;
      //String str;

      //m_train = t;
      //m_name.Value = (t.name);
      //buff = String.Format(wxPorting.T("%d"), t.type + 1);
      //m_type.Value = (buff);
      //m_entryPoint.Value = (t.entrance);
      //m_entryTime.Value = (Globals.format_time(t.timein));
      //m_exitPoint.Value = (t.exit);
      //m_exitTime.Value = (Globals.format_time(t.timeout));
      //m_waitFor.Value = (String.IsNullOrEmpty(t.waitfor) == false ? t.waitfor : wxPorting.T(""));
      //m_stockFor.Value = (String.IsNullOrEmpty(t.stock) == false ? t.stock : wxPorting.T(""));
      //if(t.days != 0) {
      //  buff.Empty();
      //  for(i = 0; i < 7; ++i)
      //    if(((int)t.days & (1 << i)) != 0)
      //      buff += string.Format(wxPorting.T("%d"), i + 1);
      //  m_runsOn.Value = (buff);
      //}
      //buff[0] = 0;
      //if(t.length != 0)
      //  buff = String.Format(wxPorting.T("%d"), t.length);
      //m_length.Value = (buff);
      //buff[0] = 0;
      //if(t.maxspeed != 0)
      //  buff = String.Format(wxPorting.T("%d"), t.maxspeed);
      //m_maxSpeed.Value = (buff);
      //m_stops.Update(t);
      //str.Empty();
      //for(i = 0; i < Config.MAXNOTES; ++i) {
      //  str += t.notes[i];
      //  str += wxPorting.T("rn");
      //}
      //m_notes.Value = (str);
      //m_name.SetFocus();

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //return ShowModalResult.OK;
    }
  }
}