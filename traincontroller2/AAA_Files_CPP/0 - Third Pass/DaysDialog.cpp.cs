 /*	DaysDialog.cpp - Created by Giampiero Caprino
 
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

namespace TrainDirPorting {
  public class DaysDialog : Dialog {
    public RadioBox m_radio_box;

    private static String[] names = new String[] {
 	wxPorting.T("Monday"),
 	wxPorting.T("Tuesday"),
 	wxPorting.T("Wednesday"),
 	wxPorting.T("Thursday"),
 	wxPorting.T("Friday"),
 	wxPorting.T("Saturday"),
 	wxPorting.T("Sunday"),
 	null
 };

    public DaysDialog(Window parent)
      : base(parent, 0, wxPorting.L("Day Selection"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L(" Days ")) {
      //int i;
      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //StaticText header = new StaticText(this, 0,
      //    wxPorting.L("Not all trains run every day of the week.nWhich day do you want to simulate?"));

      //column.Add(header, 0, Alignment.wxALIGN_LEFT | Direction.wxALL, 10);

      //for(i = 0; String.IsNullOrEmpty(names[i]) == false; ++i) {
      //  strings.Add(wxPorting.LV(names[i]));
      //}

      //m_radio_box = new RadioBox(this, MenuIDs.ID_RADIOBOX,
      //    wxPorting.L(""), Window.wxDefaultPosition, Window.wxDefaultSize,
      //    strings, 1, WindowStyles.RA_SPECIFY_COLS);

      //column.Add(m_radio_box, 1, Direction.wxGROW | Alignment.wxALIGN_LEFT | Direction.wxALL, 10);

      //Button ok = new Button(this, wxID_OK, wxPorting.L("&Continue"));

      //ok.SetDefault();
      //column.Add(ok, 0, Alignment.wxALIGN_CENTER | Direction.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }


    public int ShowModal() {
      throw new NotImplementedException();
      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //int res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //Globals.run_day = (RunDays)( 1 << m_radio_box.Selection);
      //return res;
    }

    public String format_day(RunDays day) {
      throw new NotImplementedException();
      //int i;
      //int c;

      //if(day == RunDays.None)
      //  return wxPorting.T("");
      //c = 0;
      //for(i = 1; String.IsNullOrEmpty(names[c]) == false; i <<= 1, ++c) {
      //  if((run_day & i) != 0) {
      //    return wxPorting.LV(names[c]);
      //  }
      //}
      //return wxPorting.T("?");	    // impossible
    }

  }
}