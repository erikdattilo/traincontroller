 /*	SignalDialog.cpp - Created by Giampiero Caprino
 
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
using System;
using System.Drawing;

namespace Traincontroller2 {
  public class SignalDialog : Dialog {
    public StaticText m_coord;
    public TextCtrl m_length,
          m_name,
          m_link_east,
          m_link_west,
                       m_locked_by,
          m_script_path;
    public CheckBox m_always_red,
          m_square_frame,
          m_no_penalty_on_red,
          m_no_penalty_on_click,
          m_invisible,
                       m_intermediate;
    public Button m_fileBrowser;

    public static TextCtrl AddTextLine(Dialog dialog, BoxSizer column, string txt) {
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      StaticText header = new StaticText(dialog, 0, wxPorting.LV(txt));
      TextCtrl txtctrl = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      row.Add(header, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT, 4);
      row.Add(txtctrl, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT | SizerFlag.wxLEFT, 6);

      column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP | SizerFlag.wxRIGHT | SizerFlag.wxLEFT, 10);

      return txtctrl;
    }

    public static TextCtrl AddScriptLine(SignalDialog dialog, BoxSizer column, string txt) {
      throw new NotImplementedException();
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //StaticText header = new StaticText(dialog, 0, wxPorting.LV(txt));
      //TextCtrl txtctrl = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);
      //Size size = txtctrl.Size;

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT, 4);
      //row.Add(txtctrl, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT | SizerFlag.wxLEFT, 6);
      //dialog.m_fileBrowser = new Button(dialog, MenuIDs.ID_PROPERTIES, wxPorting.T("..."), Window.wxDefaultPosition, new Size(32, size.Height + 2));
      //row.Add(dialog.m_fileBrowser, 0, SizerFlag.wxTOP | SizerFlag.wxALIGN_RIGHT, 4);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP | SizerFlag.wxRIGHT | SizerFlag.wxLEFT, 10);

      //return txtctrl;
    }

    public SignalDialog(Window parent)
      : base(parent, 0, wxPorting.L("Signal properties"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Signal properties")) {
      //EVT_BUTTON((int)MenuIDs.ID_PROPERTIES, new wx.EventListener(OnFileBrowser));

      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      //m_coord = new StaticText(this, wx.Window.wxID_ANY, wxPorting.T(""), Window.wxDefaultPosition, Window.wxDefaultSize, Alignment.wxALIGN_LEFT);
      //column.Add(m_coord, 0, SizerFlag.wxLEFT | SizerFlag.wxTOP, 10);

      //m_name = AddTextLine(this, column, wxPorting.L("Signal name :"));
      //m_link_east = AddTextLine(this, column, wxPorting.L("Linked to east :"));
      //m_link_west = AddTextLine(this, column, wxPorting.L("Linked to west :"));
      //m_locked_by = AddTextLine(this, column, wxPorting.L("Blocked by :"));

      //m_always_red = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("Signal is always red"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_always_red, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_square_frame = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("Signal has square frame"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_square_frame, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_no_penalty_on_red = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("No penalty for train stopping at this signal"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_no_penalty_on_red, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_no_penalty_on_click = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("No penalty for un-necessary clicks"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_no_penalty_on_click, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_invisible = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("Hidden"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_invisible, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_intermediate = new CheckBox(this, wx.Window.wxID_ANY, wxPorting.L("Intermediate"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_intermediate, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //m_script_path = AddScriptLine(this, column, wxPorting.L("Script file :"));

      //column.Add(CreateButtonSizer(ButtonFlags.OK | ButtonFlags.CANCEL), 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public void OnFileBrowser(object sender, Event evt) {
      string path;
      String strpath;

      strpath = m_script_path.Value;
      path = String.Copy( strpath);
      if(!Globals.traindir.OpenScriptDialog(path))
        return;
      m_script_path.Value = (path);
    }


    public ShowModalResult ShowModal(Signal trk) {
      throw new NotImplementedException();
      //ShowModalResult res;
      //string buff;
      //string p;
      //string str;

      //buff = string.Copy(wxPorting.L("Signal at coordinates :"));
      //buff += string.Format(wxPorting.T("   %d, %d"), trk.x, trk.y);
      //m_coord.Label = (buff);
      //buff = "";
      //if(String.IsNullOrEmpty(trk.station) == false)
      //  buff = String.Copy( trk.station);
      //m_name.Value = (buff);
      //buff = string.Format(wxPorting.T("%d,%d"), trk.elinkx, trk.elinky);
      //m_link_east.Value = (buff);
      //buff = string.Format(wxPorting.T("%d,%d"), trk.wlinkx, trk.wlinky);
      //m_link_west.Value = (buff);
      //if(String.IsNullOrEmpty(trk._lockedBy) == false)
      //  m_locked_by.Value = (trk._lockedBy);
      //m_always_red.Value = (trk.fixedred);
      //m_square_frame.Value = (trk.signalx != 0);
      //m_no_penalty_on_red.Value = (trk.nopenalty);
      //m_no_penalty_on_click.Value = (trk.noClickPenalty);
      //m_invisible.Value = (trk.invisible);
      //m_intermediate.Value = (trk._intermediate);
      //m_script_path.Value = (trk.stateProgram);

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_name.SetFocus();
      //res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res != ShowModalResult.OK)
      //  return res;

      //str = m_name.Value;
      //if(String.IsNullOrEmpty(trk.station) == false)
      //  Globals.free(trk.station);
      //trk.station = 0;
      //if(str.length() > 0)
      //  trk.station = String.Copy(str);
      //str = m_link_east.Value;
      //trk.elinkx = trk.elinky = 0;
      //if(str.length() > 0) {
      //  buff = String.Copy( str);
      //  trk.elinkx = Globals.wxStrtol(buff, &p, 10);
      //  if(*p != ',')
      //    trk.elinkx = 0;
      //  else
      //    trk.elinky = Globals.wxStrtol(p + 1, &p, 10);
      //}
      //str = m_link_west.Value;
      //trk.wlinkx = trk.wlinky = 0;
      //if(str.length() > 0) {
      //  buff = String.Copy( str);
      //  trk.wlinkx = Globals.wxStrtol(buff, &p, 10);
      //  if(*p != ',')
      //    trk.wlinkx = 0;
      //  else
      //    trk.wlinky = Globals.wxStrtol(p + 1, &p, 10);
      //}
      //if(String.IsNullOrEmpty(trk._lockedBy) == false)
      //  Globals.free(trk._lockedBy);
      //trk._lockedBy = null;
      //str = m_locked_by.Value;
      //if(str.length() > 0)
      //  trk._lockedBy = String.Copy(str);
      //trk.fixedred = m_always_red.Value;
      //trk.signalx = m_square_frame.Value;
      //trk.nopenalty = m_no_penalty_on_red.Value;
      //trk.noClickPenalty = m_no_penalty_on_click.Value;
      //trk.invisible = m_invisible.Value;
      //trk._intermediate = m_intermediate.Value;
      //str = m_script_path.Value;
      //if(Globals.wxStrcmp(str, trk.stateProgram) == 0) {
      //    return ShowModalResult.OK;
      //  Globals.free(trk.stateProgram);
      //}
      //Signal sig = trk;

      //Globals.delete_script_data(trk);
      //trk.stateProgram = String.Copy(str);
      //sig.ParseProgram();
      //return ShowModalResult.OK;
    }
  }
}