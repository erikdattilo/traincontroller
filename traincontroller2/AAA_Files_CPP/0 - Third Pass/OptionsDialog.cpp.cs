 /*	OptionsDialog.cpp - Created by Giampiero Caprino
 
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

namespace Traincontroller2 {
  public partial class Configuration {
    public static int NUM_OPTIONS = 20;
  }


  public class FileRow {
    public FileRow() { }

    public Option _option;
    public TextCtrl _path;
    public Button _button;
  };


  public class opt {
    public string name;
    public int[] optp;

    public opt(string name_, int[] optp_) {
      name = name_;
      optp = optp_;
    }

    public opt(string name_, bool optp_) {
      throw new NotImplementedException();
    }

    public opt(string name_, int optp_) {
      throw new NotImplementedException();
    }
  }

  public partial class Globals {
    public static opt[] opts = new opt[] {
     new opt(wxPorting.T("Short train info"), terse_status),
     new opt( wxPorting.T("Alert sound on"), beep_on_alert),
     new opt( wxPorting.T("Alert on train entering layout"), beep_on_enter),
     new opt( wxPorting.T("View speed limits"), show_speeds),
     new opt( wxPorting.T("Automatically link signals"), auto_link),
     new opt( wxPorting.T("Link signals to left track"), link_to_left),
     new opt( wxPorting.T("Show grid"), show_grid),
     new opt( wxPorting.T("View long blocks"), show_blocks),
     new opt( wxPorting.T("Show seconds on clock"), show_seconds),
     new opt( wxPorting.T("Traditional signals"), signal_traditional),
     new opt( wxPorting.T("Strong performance checking"), hard_counters),
     new opt( wxPorting.T("Show linked objects in editor"), show_links),
     new opt( wxPorting.T("Show scripted objects in editor"), show_scripts),
     new opt( wxPorting.T("Show trains icons"), show_icons),
     new opt( wxPorting.T("Show trains tooltip"), show_tooltip),
     new opt( wxPorting.T("Enable random delays"), random_delays),
     new opt( wxPorting.T("Wait while playing sounds"), play_synchronously),
     new opt( wxPorting.T("Swap head and tail icons"), swap_head_tail),
     new opt( wxPorting.T("Show train names instead of icons"), draw_train_names),
     new opt( wxPorting.T("Don't show train names colors"), no_train_names_colors),
     null
  };

  }

  public class OptionsDialog : Dialog {
    public CheckBox[] m_boxes = new CheckBox[Configuration.NUM_OPTIONS];

    public FileRow _alert, _enter, _search;

    public SkinElementColor m_background;
    public SkinElementColor m_freeTrack;
    public SkinElementColor m_reservedTrack;
    public SkinElementColor m_reservedShunting;
    public SkinElementColor m_occupiedTrack;
    public SkinElementColor m_workingTrack;
    public SkinElementColor m_outline;
    public SkinElementColor m_text;

    public CheckBox _httpServerEnabled;
    public TextCtrl _httpPort;
    public TextCtrl _userName;

    public OptionsDialog(Window parent)
      : base(parent, 0, wxPorting.L("Preferences"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Preferences")) {
      //EVT_BUTTON((int)MenuIDs.ID_CHOICE, new wx.EventListener(OnColorChoice));

      //int i;
      //ArrayString strings;

      //Panel page1 = new Panel(this, wxID_ANY);
      //BoxSizer column3 = new BoxSizer(Orientation.wxVERTICAL);

      //StaticText header = new StaticText(page1, 0,
      //    wxPorting.L("Check the desired options:"));
      //column3.Add(header, 0, SizerFlag.wxALL, 10);

      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer column2 = new BoxSizer(Orientation.wxVERTICAL);
      //for(i = 0; String.IsNullOrEmpty(Globals.opts[i].name) == false; ++i) {

      //  m_boxes[i] = new CheckBox(page1, (int)MenuIDs.ID_CHECKBOX,
      //wxPorting.LV(Globals.opts[i].name), Window.wxDefaultPosition, Window.wxDefaultSize);

      //  if(i > 9) {
      //    column2.Add(m_boxes[i], 0,  SizerFlag.wxLEFT, 10);
      //    column2.AddSpacer(6);
      //  } else {
      //    column.Add(m_boxes[i], 0, SizerFlag.wxLEFT, 10);
      //    column.AddSpacer(6);
      //  }
      //}

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //row.Add(column, 1, SizerFlag.wxGROW |  SizerFlag.wxRIGHT, 5);
      //row.Add(column2, 1, SizerFlag.wxGROW |  SizerFlag.wxRIGHT, 5);
      //column3.Add(row, 0, SizerFlag.wxALL, 10);

      //page1.SetSizer(column3);

      //Panel page2 = CreatePage2();
      //Notebook noteBook = new Notebook(this, Window.wxID_ANY);

      //Panel page3 = CreatePage3();

      //Panel page4 = CreatePage4();     // Remote servers

      //noteBook.AddPage(page1, wxPorting.L("Options"), true, 0);
      //noteBook.AddPage(page2, wxPorting.L("Environment"), false, 1);
      //noteBook.AddPage(page3, wxPorting.L("Skin"), false, 2);
      //noteBook.AddPage(page4, wxPorting.L("Server"), false, 3);

      //BoxSizer column4 = new BoxSizer(Orientation.wxVERTICAL);
      //column4.Add(noteBook);

      //column4.Add(CreateButtonSizer(ButtonFlags.OK | ButtonFlags.CANCEL), 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //SetSizer(column4);
      //column4.Fit(this);
      //column4.SetSizeHints(this);
    }

    public BoxSizer AddFileRow(Panel page, Option option, FileRow outParam) {
      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      StaticText label = new StaticText(page, wxID_ANY, Globals.localize(option._descr));
      //row.Add(label);
      row.Add(label, 55, SizerFlag.wxALIGN_LEFT | SizerFlag.wxLEFT | SizerFlag.wxRIGHT | SizerFlag.wxTOP, 4);
      outParam._path = new TextCtrl(page, wxID_ANY);
      outParam._path.Value = (option._sValue);
      //row.Add(outParam._path);
      row.Add(outParam._path, 75, SizerFlag.wxRIGHT | SizerFlag.wxGROW | SizerFlag.wxTOP, 4);
      outParam._button = new Button(page, wxID_ANY, wxPorting.T("..."));
      //row.Add(outParam._button);
      row.Add(outParam._button, 20, SizerFlag.wxRIGHT | SizerFlag.wxTOP, 4);
      outParam._option = option;
      return row;
    }

    public Panel CreatePage2() {
      Panel page2 = new Panel(this, wxID_ANY);

      BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      BoxSizer row;

      row = AddFileRow(page2, Globals.alert_sound, _alert);
      column.Add(row);
      row = AddFileRow(page2, Globals.entry_sound, _enter);
      column.Add(row);
      row = AddFileRow(page2, Globals.searchPath, _search);
      column.Add(row);

      page2.SetSizer(column);
      return page2;
    }


    private static void AddSkinRow(Panel parent, BoxSizer column, string txt, SkinElementColor rgb, int rgbV) {
      string buff = "";
      wxSize sz = new wxSize(40, 20);
      StaticText separator = new StaticText(parent, 0, wxPorting.T("   "));

      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      rgb.m_label = new StaticText(parent, 0, wxPorting.LV(txt));
      rgb.m_rgbSelector = new Button(parent, (int)MenuIDs.ID_CHOICE, wxPorting.L("Color..."), Window.wxDefaultPosition, Window.wxDefaultSize);
      sz.Height = (rgb.m_rgbSelector.Size.Height);
      rgb.m_r = new TextCtrl(parent, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);
      rgb.m_g = new TextCtrl(parent, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);
      rgb.m_b = new TextCtrl(parent, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);

      Globals.wxSprintf(buff, wxPorting.T("%d"), (rgbV >> 16) & 0xFF);
      rgb.m_r.Value = (buff);
      Globals.wxSprintf(buff, wxPorting.T("%d"), (rgbV >> 8) & 0xFF);
      rgb.m_g.Value = (buff);
      Globals.wxSprintf(buff, wxPorting.T("%d"), rgbV & 0xFF);
      rgb.m_b.Value = (buff);

      row.Add(rgb.m_label, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_r, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_g, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_b, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(separator, 2, SizerFlag.wxTOP, 4);
      row.Add(rgb.m_rgbSelector, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);

      column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);
    }

    private static int RetrieveValue(SkinElementColor el) {
      int rv, gv, bv;
      String str;

      str = el.m_r.Value;
      rv = Globals.wxStrtoul(str, 0, 0);
      str = el.m_g.Value;
      gv = Globals.wxStrtoul(str, 0, 0);
      str = el.m_b.Value;
      bv = Globals.wxStrtoul(str, 0, 0);
      return (rv << 16) | (gv << 8) | bv;
    }


    Panel CreatePage3() {
      Panel page = new Panel(this, wxID_ANY);

      BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      TDSkin m_skin = Globals.curSkin;

      AddSkinRow(page, column, wxPorting.L("Background"), m_background, m_skin.background);
      AddSkinRow(page, column, wxPorting.L("Free Track"), m_freeTrack, m_skin.free_track);
      AddSkinRow(page, column, wxPorting.L("Reserved Track"), m_reservedTrack, m_skin.reserved_track);
      AddSkinRow(page, column, wxPorting.L("Reserved for Shunting"), m_reservedShunting, m_skin.reserved_shunting);
      AddSkinRow(page, column, wxPorting.L("Occupied"), m_occupiedTrack, m_skin.occupied_track);
      AddSkinRow(page, column, wxPorting.L("Reserved for Working"), m_workingTrack, m_skin.working_track);
      AddSkinRow(page, column, wxPorting.L("Switch Outline"), m_outline, m_skin.outline);
      AddSkinRow(page, column, wxPorting.L("Text"), m_text, m_skin.text);

      page.SetSizer(column);
      return page;
    }

    public Panel CreatePage4() {
      throw new NotImplementedException();
      //Panel page = new Panel(this, wxID_ANY);

      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

      //_httpServerEnabled = new CheckBox(page, (int)MenuIDs.ID_CHECKBOX,
      //    wxPorting.L("Enable HTTP server"), Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(_httpServerEnabled, 1, SizerFlag.wxGROW | SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //StaticText label = new StaticText(page, 0, wxPorting.L("HTTP Server Port"));
      //_httpPort = new TextCtrl(page, 0, Globals.wxEmptyString, Window.wxDefaultPosition);

      //row.Add(label, 40);
      //row.Add(_httpPort, 60);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //label = new StaticText(page, 0, wxPorting.L("User name"));
      //_userName = new TextCtrl(page, 0, Globals.wxEmptyString, Window.wxDefaultPosition);

      //row.Add(label, 40);
      //row.Add(_userName, 60);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);

      //page.SetSizer(column);
      //return page;
    }

    public void OnColorChoice(object sender, Event evt) {
      wx.Object obj = evt.EventObject;
      SkinElementColor el = null;
      if(obj == m_background.m_rgbSelector) {
        el = m_background;
      } else if(obj == m_freeTrack.m_rgbSelector) {
        el = m_freeTrack;
      } else if(obj == m_reservedTrack.m_rgbSelector) {
        el = m_reservedTrack;
      } else if(obj == m_reservedShunting.m_rgbSelector) {
        el = m_reservedShunting;
      } else if(obj == m_occupiedTrack.m_rgbSelector) {
        el = m_occupiedTrack;
      } else if(obj == m_workingTrack.m_rgbSelector) {
        el = m_workingTrack;
      } else if(obj == m_outline.m_rgbSelector) {
        el = m_outline;
      } else if(obj == m_text.m_rgbSelector) {
        el = m_text;
      } else
        return;

      byte rv, gv, bv;
      String str;
      str = el.m_r.Value;
      rv = Globals.wxStrtoul(str, 0, 0);
      str = el.m_g.Value;
      gv = Globals.wxStrtoul(str, 0, 0);
      str = el.m_b.Value;
      bv = Globals.wxStrtoul(str, 0, 0);
      Colour elCol = new wx.Colour(rv, gv, bv);
      ColourData data = new ColourData();
      data.ChooseFull = (true);
      data.Colour = (elCol);

      ColourDialog dialog = new ColourDialog(this, data);
      if(dialog.ShowModal() == ShowModalResult.OK) {
        ColourData retData = dialog.ColourData;
        wx.Colour col = retData.Colour;
        byte v = col.Red;
        str = String.Format(wxPorting.T("%d"), v);
        el.m_r.Value = (str);

        v = col.Green;
        str = String.Format(wxPorting.T("%d"), v);
        el.m_g.Value = (str);

        v = col.Blue;
        str = String.Format(wxPorting.T("%d"), v);
        el.m_b.Value = (str);
      }
    }

    public override ShowModalResult ShowModal() {
      throw new NotImplementedException();

      //int i;
      //ShowModalResult res;

      //for(i = 0; String.IsNullOrEmpty(Globals.opts[i].name) == false; ++i) {
      //  m_boxes[i].Value = (Globals.opts[i].optp != 0);
      //}
      //_alert._path.Value = (Globals.alert_sound._sValue);
      //_enter._path.Value = (Globals.entry_sound._sValue);
      //_search._path.Value = (Globals.searchPath._sValue);

      //_httpServerEnabled.Value = (Globals.http_server_enabled._iValue != 0);
      //_httpPort.Value = (Globals.http_server_port._sValue);
      //_userName.Value = (Globals.user_name._sValue);

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res == ShowModalResult.OK) {
      //  for(i = 0; String.IsNullOrEmpty(Globals.opts[i].name) == false; ++i) {
      //    Globals.opts[i].optp = m_boxes[i].Value ? 1 : 0;
      //  }
      //  Globals.alert_sound.Set(_alert._path.Value);
      //  Globals.entry_sound.Set(_enter._path.Value);
      //  Globals.searchPath.Set(_search._path.Value);

      //  TDSkin m_skin = Globals.curSkin;
      //  m_skin.background = RetrieveValue(this.m_background);
      //  m_skin.free_track = RetrieveValue(this.m_freeTrack);
      //  m_skin.occupied_track = RetrieveValue(this.m_occupiedTrack);
      //  m_skin.outline = RetrieveValue(this.m_outline);
      //  m_skin.reserved_shunting = RetrieveValue(this.m_reservedShunting);
      //  m_skin.reserved_track = RetrieveValue(this.m_reservedTrack);
      //  m_skin.working_track = RetrieveValue(this.m_workingTrack);
      //  m_skin.text = RetrieveValue(this.m_text);

      //  Globals.http_server_enabled.Set(_httpServerEnabled.Value);
      //  Globals.http_server_port.Set(_httpPort.Value);
      //  Globals.user_name.Set(_userName.Value);
      //}
      //return res;
    }
  }




  public class SelectPowerDialog : Dialog {
    public ComboBox m_power;
    public TextCtrl m_gauge;

    public SelectPowerDialog(Window parent)
      : base(parent, 0, wxPorting.T("Select Motive Power"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L(" Motive Power ")) {
      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

      //StaticText header = new StaticText(this, 0, wxPorting.L("Motive &Power"));
      //m_power = new ComboBox(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT, 4);
      //row.Add(m_power, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT | SizerFlag.wxLEFT, 6);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP | SizerFlag.wxRIGHT | SizerFlag.wxLEFT, 10);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT, 4);
      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP | SizerFlag.wxRIGHT | SizerFlag.wxLEFT, 10);

      //column.Add(CreateButtonSizer(ButtonFlags.OK | ButtonFlags.CANCEL), 0, SizerFlag.wxGROW | SizerFlag.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public override ShowModalResult ShowModal() {
      throw new NotImplementedException();
      //string buff;

      //m_power.Clear();

      //for(int i = 0; i < Globals.gMotivePowerCache.Length(); ++i) {
      //  string p = Globals.gMotivePowerCache[i];
      //  m_power.AppendString(p);
      //}
      //if(Globals.gEditorMotivePower != null)
      //  m_power.Value = (Globals.gEditorMotivePower);

      //Center();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_power.SetFocus();
      //ShowModalResult res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res != ShowModalResult.OK)
      //  return ShowModalResult.CANCEL;

      //Globals.power_select(m_power.Value);
      //return ShowModalResult.OK;
    }


  }
}