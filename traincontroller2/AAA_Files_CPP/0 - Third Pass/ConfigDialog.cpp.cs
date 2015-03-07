 /*	ConfigDialog.cpp - Created by Giampiero Caprino
 
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
using wx;

namespace TrainDirPorting {

  public class ConfigDialog : Dialog {
    public RadioBox m_radio_box;

    private static String[] languages = new string[] { wxPorting.T("English"), wxPorting.T("Espanol"), wxPorting.T("Francaise"), wxPorting.T("Italiano"), wxPorting.T("Magyar"), null };
    private static String[] locales = new string[] { wxPorting.T(".en"), wxPorting.T(".es"), wxPorting.T(".fr"), wxPorting.T(".it"), wxPorting.T(".hu"), null };

    public ConfigDialog(Window parent)
      : base(parent, 0, wxPorting.L("Language Selection"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Language Selection")) {
      //int i;
      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //StaticText header = new StaticText(this, 0,
      //    wxPorting.L("Language to use next timenTraindir is started:"));

      //column.Add(header, 0, Alignment.wxALIGN_LEFT | Direction.wxALL, 10);

      //for(i = 0; String.IsNullOrEmpty(languages[i]) == false; ++i) {
      //  strings.Add(languages[i]);
      //}

      //m_radio_box = new RadioBox(this, MenuIDs.ID_RADIOBOX,
      //    wxPorting.L(""), Window.wxDefaultPosition, Window.wxDefaultSize,
      //    strings, 1, WindowStyles.wxRA_SPECIFY_COLS);

      //for(i = 0; String.IsNullOrEmpty(locales[i]) == false; ++i) {
      //  if(Globals.wxStrcmp(Globals.locale_name, locales[i]) == 0) {
      //    m_radio_box.Selection = (i);
      //    break;
      //  }
      //}
      //column.Add(m_radio_box, 1, Direction.wxGROW | Alignment.wxALIGN_LEFT | Direction.wxALL, 10);
      //column.Add(CreateButtonSizer(wx.WindowStyles.DIALOG_OK | wx.WindowStyles.DIALOG_CANCEL), 0, Direction.wxGROW | Direction.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    ~ConfigDialog() {
    }

    public override ShowModalResult ShowModal() {
      throw new NotImplementedException();
      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //ShowModalResult res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res != wxID_OK)
      //  return res;

      //res = m_radio_box.Selection;
      //Globals.locale_name = locales[res];
      //return ShowModalResult.OK;
    }

  }
}