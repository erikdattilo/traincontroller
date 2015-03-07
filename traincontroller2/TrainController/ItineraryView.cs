using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {

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
      throw new NotImplementedException();

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
      throw new NotImplementedException();
      //Itinerary it = (Itinerary)GetSelectedData();
      //if(it == null)			// impossible
      //  return;
      //Globals.ShowItineraryDialog(it);
    }

    public void OnDelete(object sender, Event evt) {
      throw new NotImplementedException();
      //Itinerary it = (Itinerary)GetSelectedData();
      //if(it == null)			// impossible
      //  return;
      //Globals.delete_itinerary(it);
      //Globals.FillItineraryTable();
    }

    public void OnSave(object sender, Event evt) {
      throw new NotImplementedException();
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
