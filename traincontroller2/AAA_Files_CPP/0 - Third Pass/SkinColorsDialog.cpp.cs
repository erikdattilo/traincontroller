 /*	SkinColorsDialog.cpp - Created by Giampiero Caprino
 
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
  public class SkinElementColor {
    public TextCtrl m_r, m_g, m_b;
    public Button m_rgbSelector;
    public StaticText m_label;
    public ColorOption m_option;
  }

  public class SkinColorsDialog : Dialog {
    public SkinElementColor m_background;
    public SkinElementColor m_freeTrack;
    public SkinElementColor m_reservedTrack;
    public SkinElementColor m_reservedShunting;
    public SkinElementColor m_occupiedTrack;
    public SkinElementColor m_workingTrack;
    public SkinElementColor m_outline;
    public SkinElementColor m_text;

    public TDSkin m_skin;

    private static void AddSkinRow(Dialog dialog, BoxSizer column, string txt, SkinElementColor rgb, int rgbV) {
      string buff;
      wxSize sz = new wxSize(40, 20);
      StaticText separator = new StaticText(dialog, 0, wxPorting.T("   "));

      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      rgb.m_label = new StaticText(dialog, 0, wxPorting.LV(txt));
      rgb.m_rgbSelector = new Button(dialog, (int)MenuIDs.ID_CHOICE, wxPorting.L("Color..."), Window.wxDefaultPosition, Window.wxDefaultSize);
      sz.Height = (rgb.m_rgbSelector.Size.Height);
      rgb.m_r = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);
      rgb.m_g = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);
      rgb.m_b = new TextCtrl(dialog, 0, Globals.wxEmptyString, Window.wxDefaultPosition, sz);

      buff = String.Format(wxPorting.T("%d"), (rgbV >> 16) & 0xFF);
      rgb.m_r.Value = (buff);
      buff = String.Format(wxPorting.T("%d"), (rgbV >> 8) & 0xFF);
      rgb.m_g.Value = (buff);
      buff = String.Format(wxPorting.T("%d"), rgbV & 0xFF);
      rgb.m_b.Value = (buff);

      row.Add(rgb.m_label, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_r, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_g, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(rgb.m_b, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);
      row.Add(separator, 2, SizerFlag.wxTOP, 4);
      row.Add(rgb.m_rgbSelector, 20, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxTOP, 4);

      column.Add(row, 1, SizerFlag.wxGROW |  SizerFlag.wxLEFT |  SizerFlag.wxRIGHT, 10);
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


    public SkinColorsDialog(Window parent, TDSkin skn)
      : base(parent, 0, wxPorting.L("Skin Colors"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Skin Colors")) {
      EVT_BUTTON((int)MenuIDs.ID_CHOICE, new wx.EventListener(OnColorChoice));

      m_skin = skn;

      BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);

      AddSkinRow(this, column, wxPorting.L("Background"), m_background, m_skin.background);
      AddSkinRow(this, column, wxPorting.L("Free Track"), m_freeTrack, m_skin.free_track);
      AddSkinRow(this, column, wxPorting.L("Reserved Track"), m_reservedTrack, m_skin.reserved_track);
      AddSkinRow(this, column, wxPorting.L("Reserved for Shunting"), m_reservedShunting, m_skin.reserved_shunting);
      AddSkinRow(this, column, wxPorting.L("Occupied"), m_occupiedTrack, m_skin.occupied_track);
      AddSkinRow(this, column, wxPorting.L("Reserved for Working"), m_workingTrack, m_skin.working_track);
      AddSkinRow(this, column, wxPorting.L("Switch Outline"), m_outline, m_skin.outline);
      AddSkinRow(this, column, wxPorting.L("Text"), m_text, m_skin.text);

      BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      row.Add(new Button(this, wxID_CANCEL, wxPorting.L("Cance&l")), 0, SizerFlag.wxALL, 4);
      row.Add(new Button(this, wxID_OK, wxPorting.L("&Close")), 0, SizerFlag.wxALL, 4);
      column.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);

      SetSizer(column);
      column.Fit(this);
      column.SetSizeHints(this);
    }

    public void OnColorChoice(object sender, Event evt)
 {
  //wxObject obj = evt.GetEventObject();
  //SkinElementColor el = 0;
  //if(obj == m_background.m_rgbSelector) {
  //    el = m_background;
  //} else if(obj == m_freeTrack.m_rgbSelector) {
  //    el = m_freeTrack;
  //} else if(obj == m_reservedTrack.m_rgbSelector) {
  //    el = m_reservedTrack;
  //} else if(obj == m_reservedShunting.m_rgbSelector) {
  //    el = m_reservedShunting;
  //} else if(obj == m_occupiedTrack.m_rgbSelector) {
  //    el = m_occupiedTrack;
  //} else if(obj == m_workingTrack.m_rgbSelector) {
  //    el = m_workingTrack;
  //} else if(obj == m_outline.m_rgbSelector) {
  //    el = m_outline;
  //} else if(obj == m_text.m_rgbSelector) {
  //    el = m_text;
  //} else
  //    return;
 
  //byte rv, gv, bv;
  //String	str;
  //str = el.m_r.Value;
  //rv = Globals.wxStrtoul(str, 0, 0);
  //str = el.m_g.Value;
  //gv = Globals.wxStrtoul(str, 0, 0);
  //str = el.m_b.Value;
  //bv = Globals.wxStrtoul(str, 0, 0);
  //wx.Colour elCol = new Colour(rv, gv, bv);
  //ColourData data = new ColourData();
  //data.ChooseFull = (true);
  //data.Colour = (elCol);
 
  //ColourDialog dialog = new ColourDialog(this, data);
  //if (dialog.ShowModal() == ShowModalResult.OK)
  //{
  //    ColourData retData = dialog.ColourData;
  //    wx.Colour col = retData.Colour;
  //    int v = col.Red;
  //    str = String.Format(wxPorting.T("%d"), v);
  //    el.m_r.Value = (str);
 
  //    v = col.Green;
  //    str = String.Format(wxPorting.T("%d"), v);
  //    el.m_g.Value = (str);
 
  //    v = col.Blue;
  //    str = String.Format(wxPorting.T("%d"), v);
  //    el.m_b.Value = (str);
  //}
 }


    public override ShowModalResult ShowModal() {
      String str;

      Centre();
      bool oldIgnore = Globals.traindir.m_ignoreTimer;
      Globals.traindir.m_ignoreTimer = true;

      ShowModalResult res = base.ShowModal();
      Globals.traindir.m_ignoreTimer = oldIgnore;
      if(res != ShowModalResult.OK)
        return ShowModalResult.CANCEL;


      m_skin.background = RetrieveValue(this.m_background);
      m_skin.free_track = RetrieveValue(this.m_freeTrack);
      m_skin.occupied_track = RetrieveValue(this.m_occupiedTrack);
      m_skin.outline = RetrieveValue(this.m_outline);
      m_skin.reserved_shunting = RetrieveValue(this.m_reservedShunting);
      m_skin.reserved_track = RetrieveValue(this.m_reservedTrack);
      m_skin.working_track = RetrieveValue(this.m_workingTrack);
      m_skin.text = RetrieveValue(this.m_text);
      return ShowModalResult.OK;
    }
  }
}