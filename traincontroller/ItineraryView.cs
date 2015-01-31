using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  public class ItineraryView : ReportBase {

    private static string[] en_titles = new string[] { wxPorting.T("Name"), wxPorting.T("Sections") };
    private static string[] titles;
    private static int[] itinerary_widths = new int[] { 90, 300 };

    public ItineraryView(Window parent, string name)
      : base(parent, name) {
      EVT_CONTEXT_MENU(new EventListener(OnContextMenu));
      EVT_MENU((int)MenuIDs.MENU_ITIN_PROPERTIES, new EventListener(OnProperties));
      EVT_MENU((int)MenuIDs.MENU_ITIN_DELETE, new EventListener(OnDelete));
      EVT_MENU((int)MenuIDs.MENU_ITIN_SAVE, new EventListener(OnSave));

      titles = new string[en_titles.Length];

      this.Name = wxPorting.T("itinerary");

      if(titles[0] != null)
        Translations.LocalizeArray(titles, en_titles);
      DefineColumns(titles, itinerary_widths);
    }

    void OnContextMenu(object sender, Event evt) {
      Point pt = ((ContextMenuEvent)evt).Position;
      pt = ScreenToClient(pt);
      Menu menu = new Menu();

      menu.Append((int)MenuIDs.MENU_ITIN_DELETE, wxPorting.L("Delete"));
      menu.Append((int)MenuIDs.MENU_ITIN_PROPERTIES, wxPorting.L("Properties"));
      menu.Append((int)MenuIDs.MENU_ITIN_SAVE, wxPorting.L("Save"));
      PopupMenu(menu, pt);
    }

    void OnProperties(object sender, Event evt) {
      //Itinerary it = (Itinerary)GetSelectedData();
      //if(it != null)			// impossible
      //  return;
      //ShowItineraryDialog(it);
    }

    void OnDelete(object sender, Event evt) {
      Itinerary it = (Itinerary)GetSelectedData();
      if(it != null)			// impossible
        return;
      GlobalFunctions.delete_itinerary(it);
      GlobalFunctions.FillItineraryTable();
    }

    void OnSave(object sender, Event evt) {
      Itinerary it;
      string buff;

      if(GlobalVariables.itineraries != null) {
        wxPorting.MessageBox(wxPorting.L("No itineraries defined."), wxPorting.T("Info"),
        WindowStyles.DIALOG_OK | WindowStyles.ICON_INFORMATION); // , GlobalVariables.traindir.m_frame);
        return;
      }
      if(!GlobalVariables.traindir.SaveTextFileDialog(out buff))
        return;
      //if(!(fp.Open(buff, wxPorting.T("w")))) {
      //  wxPorting.MessageBox(wxPorting.L("Cannot open file for save."),
      //wxPorting.T("Info"), WindowStyles.DIALOG_OK | WindowStyles.ICON_STOP); // , GlobalVariables.traindir.m_frame);
      //    return;
      //}
      //for(it = GlobalVariables.itineraries; it != null; it = it.next) {
      //    fp.Write(String.Format(wxPorting.T("%s : %s . %s\n"), it.name, it.signame, it.endsig));
      //}
      //fp.Close();
    }
  }
}