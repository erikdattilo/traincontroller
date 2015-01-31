/*	AlertList.cpp - Created by Giampiero Caprino
 
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

namespace Traincontroller2 {
  public class AlertList : ReportBase {
    private AlertListListener _listener;
    private String m_name;



    private static string[] en_titles = new string[] { wxPorting.T("Alerts"), null };
    private static string[] titles; // Erik: Original code ==> static	const Char	*titles[sizeof(en_titles)/sizeof(char *)];
    private static int[] schedule_widths = new int[] { 500, 0 };


    AlertList(Window parent, string name)
      : base(parent, name) {
      //EVT_CONTEXT_MENU(new wx.EventListener(OnContextMenu));
      //EVT_MENU(MenuIDs.MENU_ALERT_CLEAR, new wx.EventListener(OnClear));
      //EVT_MENU(MenuIDs.MENU_ALERT_SAVE, new wx.EventListener(OnSave));

      //SetName(wxPorting.T("alerts"));
      //if(titles == null)
      //  Globals.localizeArray(ref titles, en_titles);
      //DefineColumns(titles, schedule_widths);
      //_listener = new AlertListListener(this);
      //Globals.alerts.AddListener(_listener);
    }

    ~AlertList() {
      Globals.freeLocalizedArray(titles);
    }

    public void AddLine(String txt) {
      InsertItem(ItemCount, txt);
      EnsureVisible(ItemCount - 1);
    }

    public void OnContextMenu(object sender, Event evt) {
      wx.Menu menu = new Menu();
      System.Drawing.Point pt = ((ContextMenuEvent)evt).Position;

      pt = ((ContextMenuEvent)evt).Position;
      pt = ScreenToClient(pt);

      menu.Append(MenuIDs.MENU_ALERT_CLEAR, wxPorting.L("Clear"));
      menu.Append(MenuIDs.MENU_ALERT_SAVE, wxPorting.L("Save"));
      PopupMenu(menu, pt);
    }

    public void OnClear(object sender, Event evt) {
      if(Globals.ask(wxPorting.L("Remove all alerts from this list?")) != AskAnswer.ANSWER_YES)
        return;
      Globals.traindir.ClearAlert();
    }

    public void OnSave(object sender, Event evt) {
      //wxFFile fp;
      //int i;
      //string buff;
      //if(this.ItemCount == 0) {
      //  wx.MessageDialog.MessageBox(wxPorting.L("No alerts to save."), wxPorting.T("Info"),
      //wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_INFORMATION, Globals.traindir.m_frame);
      //  return;
      //}
      //if(!Globals.traindir.SaveTextFileDialog(buff))
      //  return;
      //if(!(fp.Open(buff, wxPorting.T("w")))) {
      //  wx.MessageDialog.MessageBox(wxPorting.L("Cannot open file for save."),
      //wxPorting.T("Info"), wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_STOP, Globals.traindir.m_frame);
      //  return;
      //}
      //for(i = 0; i < this.ItemCount; ++i) {
      //  String txt = GetItemText(i);
      //  fp.Write(txt);
      //}
      //fp.Close();
    }
  }


  public class AlertListListener : EventListener {

    public AlertListListener(AlertList list) { _list = list; }
    ~AlertListListener() { }

    public AlertList _list;

    public override void OnEvent(object dummy) {
      if(Globals.alerts._firstItem == null) {
        _list.DeleteAllItems();
      } else {
        int nItems = _list.ItemCount;
        int x = 0;
        AlertLine line;
        for(line = Globals.alerts._firstItem; line != null && x < nItems; line = line._next)
          ++x;
        while(line != null) {
          _list.AddLine(line._text);
          line = line._next;
        }
      }
    }
  }
}