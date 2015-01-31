/*	ItineraryView.cpp - Created by Giampiero Caprino

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
using System.Drawing;
namespace Traincontroller2 {
  public static partial class Globals {

    public static void FillItineraryTable() {
      ///* Here we do the actual adding of the text. It's done once for
      // * each row.
      // */

      //int i;
      //ItineraryView clist;
      //Itinerary it;
      //clist = Globals.traindir.m_frame.m_itineraryView;

      //if(clist == null)
      //  return;
      //clist.DeleteAllItems();
      //clist.Freeze();
      //i = 0;
      //for(it = itineraries; it != null; it = it.next) {
      //  string buff;
      //  ListItem item = new ListItem();

      //  buff = String.Format( wxPorting.T("%s . %s"), it.signame, it.endsig);
      //  clist.InsertItem(i, it.name);
      //  clist.SetItem(i, 1, buff);
      //  item.Id = i;
      //  item.Mask = ListItemMask.DATA;
      //  clist.GetItem(item);
      //  item.Data = (it);
      //  clist.SetItem(item);
      //  ++i;
      //}
      //clist.Thaw();
    }
  }

  public class ItineraryView : ReportBase {
    private static String[] en_titles = new string[] { wxPorting.T("Name"), wxPorting.T("Sections"), null };
    private static String[] titles = new string[en_titles.Length];
    private static int[] itinerary_widths = new int[] { 90, 300, 0 };


    public ItineraryView(Window parent, String name)
      : base(parent, name) {
      EVT_CONTEXT_MENU(new wx.EventListener(OnContextMenu));
      EVT_MENU(MenuIDs.MENU_ITIN_PROPERTIES, new wx.EventListener(OnProperties));
      EVT_MENU(MenuIDs.MENU_ITIN_DELETE, new wx.EventListener(OnDelete));
      EVT_MENU(MenuIDs.MENU_ITIN_SAVE, new wx.EventListener(OnSave));

      SetName(wxPorting.T("itinerary"));
      if(titles == null)
        Globals.localizeArray(ref titles, en_titles);
      DefineColumns(titles, itinerary_widths);
    }

    ~ItineraryView() {
      Globals.freeLocalizedArray(titles);
    }

    public void OnContextMenu(object sender, Event evt) {
      //Point pt = evt.Position;
      //pt = evt.Position;
      //pt = ScreenToClient(pt);
      //Menu menu;
      //bool res;

      //menu.Append(MenuIDs.MENU_ITIN_DELETE, wxPorting.L("Delete"));
      //menu.Append(MenuIDs.MENU_ITIN_PROPERTIES, wxPorting.L("Properties"));
      //menu.Append(MenuIDs.MENU_ITIN_SAVE, wxPorting.L("Save"));
      //res = PopupMenu(menu, pt);
    }

    public void OnProperties(object sender, Event evt) {
      Itinerary it = (Itinerary)GetSelectedData();
      if(it == null)			// impossible
        return;
      Globals.ShowItineraryDialog(it);
    }

    public void OnDelete(object sender, Event evt) {
      Itinerary it = (Itinerary)GetSelectedData();
      if(it == null)			// impossible
        return;
      Globals.delete_itinerary(it);
      Globals.FillItineraryTable();
    }

    public void OnSave(object sender, Event evt) {
      //wxFFile fp;
      //Itinerary it;
      //string buff;

      //if(Globals.itineraries == null) {
      //  wx.MessageDialog.MessageBox(wxPorting.L("No itineraries defined."), wxPorting.T("Info"),
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
      //for(it = Globals.itineraries; it != null; it = it.next) {
      //  fp.Write(String.Format(wxPorting.T("%s : %s . %s\n"), it.name, it.signame, it.endsig));
      //}
      //fp.Close();
    }
  }
}