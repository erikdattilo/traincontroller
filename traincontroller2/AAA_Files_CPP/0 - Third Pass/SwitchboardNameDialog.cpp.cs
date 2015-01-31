 /*	ItineraryDialog.cpp - Created by Giampiero Caprino
 
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

  public class SwitchboardNameDialog : Dialog {
    public TextCtrl m_name;
    public TextCtrl m_path;
    public Button m_removebutton,
            m_savebutton,
            m_closebutton;



    public SwitchboardNameDialog(Window parent)
      : base(parent, 0, wxPorting.T("Switchboard Name"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Switchboard Name")) {
      //EVT_BUTTON((int)wx.MenuIDs.wxID_RESET, new wx.EventListener(OnRemove));
      //EVT_BUTTON((int)wx.MenuIDs.wxID_OK, new wx.EventListener(OnSave));
      //EVT_BUTTON((int)wx.MenuIDs.wxID_CANCEL, new wx.EventListener(OnClose));

      //ArrayString strings;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

      //StaticText header = new StaticText(this, 0, wxPorting.L("&Visible Name:"));
      //m_name = new TextCtrl(this, 0, wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT, 4);
      //row.Add(m_name, 65, SizerFlagGlobals.wxGROW | SizerFlag.wxALIGN_RIGHT |  SizerFlag.wxLEFT, 6);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);

      //header = new StaticText(this, 0, wxPorting.L("&File name:"));
      //m_path = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT, 4);
      //row.Add(m_path, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT |  SizerFlag.wxLEFT, 6);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);

      ////	wxStaticLine *line = new wxStaticLine( this );

      ////	column.Add(line);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //m_removebutton = new Button(this, (int)wx.MenuIDs.wxID_RESET, wxPorting.L("&Remove"));
      //row.Add(m_removebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);
      //m_savebutton = new Button(this, wxID_OK, wxPorting.L("&Save"));
      //m_savebutton.SetDefault();
      //row.Add(m_savebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);
      //m_closebutton = new Button(this, wxID_CANCEL, wxPorting.L("Cl&ose"));
      //row.Add(m_closebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);

      //column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public ShowModalResult ShowModal(SwitchBoard sb) {
      throw new NotImplementedException();

      //string buff;
      //string buff2;
      //String buff1;

      //if(sb) {
      //  m_name.Value = (sb._name);
      //  m_path.Value = (sb._fname);
      //}

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_name.SetFocus();
      //ShowModalResult res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;

      //buff = string.Copy(m_name.Value);
      //buff2 = string.Copy(m_path.Value);

      //if(res == wx.MenuIDs.wxID_RESET) {
      //  buff1 = String.Format(wxPorting.T("sb-edit -d %s"), buff2);
      //  Globals.do_command(buff1, false);
      //  return wxID_OK;
      //}
      //if(res != wxID_OK)
      //  return wxID_CANCEL;

      //buff1 = String.Format(wxPorting.T("sb-edit -a %s %s"), buff2, buff);
      //Globals.do_command(buff1, false);
      //return wxID_OK;
    }

    public void OnRemove(object sender, Event evt) {
      //EndModal((int)wx.MenuIDs.wxID_RESET);
    }

    public void OnSave(object sender, Event evt) {
      //EndModal((int)wx.MenuIDs.wxID_OK);
    }

    public void OnClose(object sender, Event evt) {
      //EndModal((int)wx.MenuIDs.wxID_CANCEL);
    }


    public class SwitchboardCellDialog : Dialog {
      public TextCtrl m_name;
      public TextCtrl m_itin;
      public Button m_removebutton,
            m_savebutton,
            m_closebutton;

      //
      //
      //


      public SwitchboardCellDialog(Window parent)
        : base(parent, 0, wxPorting.T("Switchboard Name"), Window.wxDefaultPosition, Window.wxDefaultSize,
            WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Switchboard Name")) {
        EVT_BUTTON((int)wx.MenuIDs.wxID_RESET, new wx.EventListener(OnRemove));
        EVT_BUTTON((int)wx.MenuIDs.wxID_OK, new wx.EventListener(OnSave));
        EVT_BUTTON((int)wx.MenuIDs.wxID_CANCEL, new wx.EventListener(OnClose));



        ArrayString strings;
        BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
        BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

        StaticText header = new StaticText(this, 0, wxPorting.L("&Label"));
        m_name = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

        row.Add(header, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT, 4);
        row.Add(m_name, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT |  SizerFlag.wxLEFT, 6);

        column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);

        row = new BoxSizer(Orientation.wxHORIZONTAL);

        header = new StaticText(this, 0, wxPorting.L("&Itinerary Name"));
        m_itin = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

        row.Add(header, 35, SizerFlag.wxALIGN_LEFT |  SizerFlag.wxRIGHT, 4);
        row.Add(m_itin, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT |  SizerFlag.wxLEFT, 6);

        column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);
        //	wxStaticLine *line = new wxStaticLine( this );

        //	column.Add(line);

        row = new BoxSizer(Orientation.wxHORIZONTAL);

        m_removebutton = new Button(this, (int)wx.MenuIDs.wxID_RESET, wxPorting.L("&Remove"));
        row.Add(m_removebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);
        m_savebutton = new Button(this, wxID_OK, wxPorting.L("&Save"));
        m_savebutton.SetDefault();
        row.Add(m_savebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);
        m_closebutton = new Button(this, wxID_CANCEL, wxPorting.L("Cl&ose"));
        row.Add(m_closebutton, 0, SizerFlag.wxTOP | SizerFlag.wxGROW, 10);

        column.Add(row, 1, SizerFlag.wxGROW | SizerFlag.wxTOP |  SizerFlag.wxRIGHT |  SizerFlag.wxLEFT, 10);

        SetSizer(column);
        column.Fit(this);
        column.SetSizeHints(this);
      }


      public ShowModalResult ShowModal(int x, int y)
 {
              throw new NotImplementedException();

  //string buff;
  //string itinName;
  //SwitchBoard sb = Globals.curSwitchBoard;
  //SwitchBoardCell cell;
 
  //if(sb) {
  //    cell = sb.Find(x, y);
  //    if(cell) {
  //  m_name.Value = (cell._text);
  //  m_itin.Value = (cell._itinerary);
  //    }
  //}
  //Centre();
  //bool oldIgnore = Globals.traindir.m_ignoreTimer;
  //Globals.traindir.m_ignoreTimer = true;
  //m_name.SetFocus();
  //ShowModalResult res = base.ShowModal();
  //Globals.traindir.m_ignoreTimer = oldIgnore;
  //       if(res != wxID_OK) {
  //         if(res == (int)wx.MenuIDs.wxID_RESET && cell) {
  //  sb.Remove(cell);
  //    }
  //    return ShowModalResult.CANCEL;
 // }
 
 // buff = string.Copy(m_name.Value);
 // itinName = string.Copy(m_itin.Value);
 /////	buff1 = String.Format(wxPorting.T("sb-cell %d,%d %s, %s"), x, y, buff, itinName);
 /////	do_command(buff1, false);
 
 // if(cell == null) {
 //     cell = new SwitchBoardCell();
 //     cell._x = x;
 //     cell._y = y;
 //     sb.Add(cell);
 // }
 // cell._text = buff;
 // cell._itinerary = itinName;
 // Globals.ShowSwitchboard();
 // return wxID_OK;
 }

      public void OnRemove(object sender, Event evt) {
        //EndModal((int)wx.MenuIDs.wxID_RESET);
      }

      public void OnSave(object sender, Event evt) {
        //EndModal((int)wx.MenuIDs.wxID_OK);
      }

      public void OnClose(object sender, Event evt) {
        //EndModal((int)wx.MenuIDs.wxID_CANCEL);
      }

    }
  }
}