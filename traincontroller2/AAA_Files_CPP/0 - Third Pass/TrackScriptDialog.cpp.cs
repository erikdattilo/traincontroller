// /*	TrackScriptDialog.cpp - Created by Giampiero Caprino
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
  public partial class Globals {
    public static TextCtrl AddTextLine(Dialog dialog, BoxSizer column, string txt) {
      throw new NotImplementedException();

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //StaticText header = new StaticText(dialog, 0, wxPorting.LV(txt));
      //TextCtrl txtctrl = new TextCtrl(dialog, 0, wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(header, 35, SizerFlag.wxALIGN_LEFT | SizerFlag.wxRIGHT | SizerFlag.TOP, 4);
      //row.Add(txtctrl, 65, SizerFlag.wxGROW | SizerFlag.wxALIGN_RIGHT | SizerFlag.TOP, 4);

      //column.Add(row, 1, SizerFlag.wxGROW |  SizerFlag.wxLEFT | SizerFlag.wxRIGHT, 10);

      //return txtctrl;
    }
  }

  public class TrackScriptDialog : Dialog {
    public TextCtrl m_script;
    
    public TrackScriptDialog(Window parent)
   : base(parent, 0, wxPorting.L("Track Script"), Window.wxDefaultPosition, Window.wxDefaultSize,
   	   WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Track Properties"))
   {
    //BoxSizer	column = new BoxSizer(Orientation.wxVERTICAL );
   
    //m_script = new TextCtrl( this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, new Size(260, 200), wxPorting.TE_MULTILINE);
    //column.Add(m_script, 0, SizerFlag.wxALIGN_LEFT | SizerFlag.wxGROW, 4);
   
    //BoxSizer	row = new BoxSizer(Orientation.wxHORIZONTAL );
    //row.Add(new Button(this, (int)wx.MenuIDs.wxID_CANCEL, wxPorting.L("&Cancel")), 0, SizerFlag.wxALL, 4);
    //row.Add(new Button(this, (int)wx.MenuIDs.wxID_OK, wxPorting.L("&Close")), 0, SizerFlag.wxALL, 4);
    //column.Add(row, 0, SizerFlag.wxALIGN_RIGHT | SizerFlag.wxGROW | SizerFlag.wxALL, 6);
   
    //SetSizer(column);
    //column.Fit(this);
    //column.SetSizeHints(this);
   }

    public ShowModalResult ShowModal(Track trk)
   {
      throw new NotImplementedException();

    //String    str;
   
    //if(String.IsNullOrEmpty(trk.stateProgram) == false)
    //    m_script.Value = (trk.stateProgram);
    //else {
    //    m_script.Value = (wxPorting.T("OnEnter:nendnnOnExit:nendnnOnClicked:nendnn"));
    //}
    //Centre();
    //bool oldIgnore = Globals.traindir.m_ignoreTimer;
    //Globals.traindir.m_ignoreTimer = true;
    //m_script.SetFocus();
    //ShowModalResult res = base.ShowModal();
    //Globals.traindir.m_ignoreTimer = oldIgnore;
    //if(res != ShowModalResult.OK)
    //  return ShowModalResult.CANCEL;
   
    //str = m_script.Value;
    //if(String.IsNullOrEmpty(trk.stateProgram) == false)
    //    Globals.free(trk.stateProgram);
    //       int len = str.length();
    //       if (len > 0 && str.GetChar(len - 1) != wxPorting.T('n'))
    //           str.append(wxPorting.T("n"));
    //trk.stateProgram = String.Copy(str);
    //trk.ParseProgram();		// update internal representation of the script
    //        // TODO: check if parsed correctly
    //return ShowModalResult.OK;
   }
  }
}