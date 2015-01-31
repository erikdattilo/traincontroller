// /*	TriggerDialog.cpp - Created by Giampiero Caprino
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

namespace Traincontroller2 {
  public class TriggerDialog : Dialog {
    // public:
    public StaticText m_coord;
    public TextCtrl m_links, m_name, m_probabilities;
    public Choice action_list;
    public CheckBox m_invisible;

    // BEGIN_EVENT_TABLE(TriggerDialog, Dialog)
    // 	EVT_CHOICE(ID_CHOICE, OnChoice)
    // END_EVENT_TABLE()

    public string[] trigger_actions = new string[] {
   	wxPorting.T("click x,y"),
   	wxPorting.T("rclick x,y"),
   	wxPorting.T("ctrlclick x,y"),
   	wxPorting.T("fast"),
   	wxPorting.T("slow"),
   	wxPorting.T("shunt train"),
   	wxPorting.T("reverse train"),
   	wxPorting.T("traininfo train"),
   	wxPorting.T("stationinfo train"),
   	wxPorting.T("accelerate speed train"),
   	wxPorting.T("decelerate speed train"),
   	wxPorting.T("assign train"),
   	wxPorting.T("play sound"),
   	wxPorting.T("itinerary"),
   	wxPorting.T("script"),
    null
  };

    public static TextCtrl AddTextLine(Dialog dialog, BoxSizer column, string txt) {
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      StaticText header = new StaticText(dialog, 0, wxPorting.LV(txt));
      TextCtrl txtctrl = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      row.Add(header, 50, SizerFlag.wxGROW | SizerFlag.wxLEFT, 10);
      row.Add(txtctrl, 50, SizerFlag.wxGROW | SizerFlag.wxLEFT, 10);

      column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      return txtctrl;
    }

    void OnChoice(object sender, Event evt) {
      int idx = action_list.Selection;
      m_name.Value = (trigger_actions[idx]);
    }

    public TriggerDialog(Window parent)
      : base(parent, 0, wxPorting.L("Trigger properties"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DIALOG_DEFAULT_STYLE, wxPorting.L("Trigger properties")) {
      //int i;
      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      //for(i = 0; String.IsNullOrEmpty(trigger_actions[i]); ++i)
      //  strings.Add(trigger_actions[i]);

      //m_coord = new StaticText(this, wxID_ANY, wxPorting.T(""));
      //column.Add(m_coord, 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //StaticText txt = new StaticText(this, wxID_ANY, wxPorting.L("Action:      ('@' in action = name of triggering train)"));
      //column.Add(txt, 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //action_list = new Choice(this, (int)MenuIDs.ID_CHOICE, Window.wxDefaultPosition, Window.wxDefaultSize, strings);
      //m_name = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(action_list, 50, SizerFlag.wxGROW | SizerFlag.wxLEFT, 10);
      //row.Add(m_name, 50, SizerFlag.wxGROW | SizerFlag.wxRIGHT, 10);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //m_links = AddTextLine(this, column, wxPorting.L("Linked to track at coord :"));
      //m_probabilities = AddTextLine(this, column, wxPorting.L("Probabilities for action :"));

      //m_invisible = new CheckBox(this, wxID_ANY, wxPorting.L("Hidden"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_invisible, 0, SizerFlag.wxLEFT | SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //column.Add(CreateButtonSizer(ButtonFlags.OK | ButtonFlags.CANCEL), 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public ShowModalResult ShowModal(Track trk) {
      ShowModalResult res;
      string buff;
      int i;
      string p;
      string str;

      buff = string.Format(wxPorting.L("Trigger at  %d,%d"), trk.x, trk.y);
      m_coord.Label = (buff);
      buff = "";
      if(string.IsNullOrEmpty(trk.station) == false)		// actually the name of the triggering train
        buff = string.Copy(trk.station);
      m_name.Value = (buff);
      buff = string.Format(wxPorting.T("%d,%d"), trk.wlinkx, trk.wlinky);
      m_links.Value = (buff);
      p = "";
      for(i = 0; i < Config.NTTYPES; ++i) {
        p += string.Format(wxPorting.T("%d/"), trk.speed[i]);
      }
      // Erik: what does this means?!?
      // p[-1] = 0;
      m_probabilities.Value = (buff);
      m_invisible.Value = (trk.invisible);
      m_name.SetFocus();

      Centre();
      bool oldIgnore = Globals.traindir.m_ignoreTimer;
      Globals.traindir.m_ignoreTimer = true;
      res = base.ShowModal();
      Globals.traindir.m_ignoreTimer = oldIgnore;
      if(res != ShowModalResult.OK)
        return res;

      Globals.set_track_properties(trk, wxPorting.T(""), m_name.Value,
          m_probabilities.Value, wxPorting.T(""), m_links.Value, wxPorting.T(""));
      trk.invisible = m_invisible.Value ? true : false;
      return res;
    }
  }
}