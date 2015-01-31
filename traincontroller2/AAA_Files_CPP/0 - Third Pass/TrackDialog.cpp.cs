// /*	TrackDialog.cpp - Created by Giampiero Caprino
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

  public class TrackDialog : Dialog {
    public TextCtrl m_length,
          m_name,
          m_km,
          m_speeds,
          m_link_east,
          m_link_west,
                       m_power,
                       m_gauge;
    public Button m_scripts;
    public CheckBox m_invisible;
    public CheckBox m_dontstop;

    public StaticText m_stationLabel;
    public StaticText m_speedLabel;

    public Track m_track;

    wx.Font m_font;
    wx.Colour m_textColor;

    private static StaticText lastLabel;

    private static TextCtrl AddTextLine(Dialog dialog, BoxSizer column, String txt) {
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      StaticText header = new StaticText(dialog, 0, wxPorting.LV(txt));
      TextCtrl txtctrl = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      row.Add(header, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 4);
      row.Add(txtctrl, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);

      column.Add(row, 1, SizerFlag.wxGROW |  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT, 10);

      lastLabel = header;

      return txtctrl;
    }

    public TrackDialog(Window parent)
      : base(parent, 0, wxPorting.L("Track Properties"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Track Properties")) {
      //EVT_BUTTON((int)MenuIDs.ID_SCRIPT, new wx.EventListener(OnScript));

      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      //column.AddSpacer(10);
      //m_length = AddTextLine(this, column, wxPorting.L("Track Length (m) :"));
      //m_name = AddTextLine(this, column, wxPorting.L("Station name :"));
      //m_stationLabel = lastLabel;
      //m_km = AddTextLine(this, column, wxPorting.L("Km. :"));
      //m_speeds = AddTextLine(this, column, wxPorting.L("Speed(s) :"));
      //m_speedLabel = lastLabel;
      //m_link_east = AddTextLine(this, column, wxPorting.L("Linked to east :"));
      //m_link_west = AddTextLine(this, column, wxPorting.L("Linked to west :"));
      //m_power = AddTextLine(this, column, wxPorting.L("Motive power :"));
      //m_invisible = new CheckBox(this, Window.wxID_ANY, wxPorting.L("Hidden"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_invisible, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);
      //m_dontstop = new CheckBox(this, Window.wxID_ANY, wxPorting.L("Don't stop if shunting"), Window.wxDefaultPosition, Window.wxDefaultSize);
      //column.Add(m_dontstop, 0,  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 10);

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //m_scripts = new Button(this, (int)MenuIDs.ID_SCRIPT, wxPorting.L("&Script..."));
      //row.Add(m_scripts, 0, SizerFlag.wxALL, 4);
      //row.Add(new Button(this, wxID_CANCEL, wxPorting.L("&Cancel")), 0, SizerFlag.wxALL, 4);
      //Button buttonOk = new Button(this, (int)wx.MenuIDs.wxID_OK, wxPorting.L("&Close"));
      //buttonOk.SetDefault();
      //row.Add(buttonOk, 0, SizerFlag.wxALL, 4);
      //column.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public void OnScript(object sender, Event evt) {
      Globals.ShowTrackScriptDialog(m_track);
    }

    public ShowModalResult ShowModal(Track trk) {
      throw new NotImplementedException();
      //string buff;
      //String p;
      //int i;
      //String str;

      //m_track = trk;
      //buff = String.Format( wxPorting.T("%d"), trk.length);
      //m_length.Value = (buff);
      //m_name.Value = (trk.station);
      //buff = "";
      //if(trk.km != 0) {
      //  buff = String.Format( wxPorting.T("%d.%d,"), trk.km / 1000, trk.km % 1000);
      //}
      //m_km.Value = (buff);
      //p = buff;
      //*p = 0;
      //for(i = 0; i < Config.NTTYPES; ++i) {
      //  Globals.wxSprintf(p, wxPorting.T("%d/"), trk.speed[i]);
      //  p += Globals.wxStrlen(p);
      //}
      //if(p > buff)		    // remove last '/'
      //  p[-1] = 0;
      //m_speeds.Value = (buff);
      //buff = String.Format( wxPorting.T("%d,%d"), trk.elinkx, trk.elinky);
      //m_link_east.Value = (buff);
      //buff = String.Format( wxPorting.T("%d,%d"), trk.wlinkx, trk.wlinky);
      //m_link_west.Value = (buff);
      //m_invisible.Value = (trk.invisible);
      //m_dontstop.Value = ((trk.flags & TFLG.TFLG_DONTSTOPSHUNTERS) != 0 ? true : false);
      //m_link_east.Enabled = (true);

      //if(String.IsNullOrEmpty(trk.power) == false)
      //  m_power.Value = (trk.power);

      //m_stationLabel.Label = (wxPorting.L("Station name :"));
      //m_speedLabel.Label = (wxPorting.L("Speed(s) :"));
      //bool enable = true;
      //if(trk.type == trktype.TEXT) {
      //  m_length.Enabled = (false);
      //  m_km.Enabled = (false);
      //  m_speeds.Enabled = (false);
      //  m_power.Enabled = (false);
      //  m_dontstop.Enabled = (false);
      //  m_invisible.Enabled = (false);
      //  m_link_east.Enabled = (false);
      //} else if(trk.type == trktype.SWITCH) {
      //  m_stationLabel.Label = (wxPorting.L("Switch name :"));
      //  m_speedLabel.Label = (wxPorting.L("Branch Speed(s) :"));
      //  m_length.Enabled = (false);
      //  m_km.Enabled = (false);
      //  m_dontstop.Enabled = (false);
      //  m_invisible.Enabled = (false);
      //  m_link_east.Enabled = (false);
      //} else {
      //  m_length.Enabled = (true);
      //  m_km.Enabled = (true);
      //  m_speeds.Enabled = (true);
      //  m_power.Enabled = (true);
      //  m_dontstop.Enabled = (true);
      //  m_invisible.Enabled = (true);
      //  m_link_east.Enabled = (true);
      //}

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_length.SetFocus();
      //ShowModalResult res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res != wxID_OK)
      //  return ShowModalResult.CANCEL;

      //str = m_length.Value;
      //if(String.IsNullOrEmpty(str) == false) {
      //  trk.length = Globals.wxAtoi(str);
      //  if(trk.length < 0)
      //    trk.length = 0;
      //}
      //str = m_name.Value;
      //if(String.IsNullOrEmpty(trk.station) == false)
      //  Globals.free(trk.station);
      //trk.station = null;
      //trk.isstation = false;
      //if(str.length() > 0) {
      //  trk.station = String.Copy(str);
      //  trk.isstation = true;
      //}
      //str = m_km.Value;
      //trk.km = 0;
      //if(str[0] != 0) {
      //  Globals.parse_km(trk, str);
      //}
      //str = m_speeds.Value;
      //Array.Clear(trk.speed, 0, trk.speed.Length);
      //if(str.length() > 0) {
      //  buff = String.Copy( str);
      //  trk.speed[0] = Globals.wxStrtol(buff, &p, 10);
      //  for(i = 1; i < Configuration.NTTYPES && p[0] == '/'; ++i) {
      //    trk.speed[i] = (short)Globals.wxStrtol(p + 1, &p, 10);
      //  }
      //}
      //trk.invisible = m_invisible.Value ? 1 : 0;
      //if(m_dontstop.Value != 0)
      //  trk.flags |= TFLG.TFLG_DONTSTOPSHUNTERS;
      //else
      //  trk.flags &= ~TFLG.TFLG_DONTSTOPSHUNTERS;
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
      //str = m_power.Value;
      //if(str.length() > 0) {
      //  trk.power = Globals.power_parse(str);
      //}

      //return ShowModalResult.OK;
    }
  }
}