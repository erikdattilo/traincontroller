using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class AlertList : ReportBase {
#if false
    private AlertListListener _listener;
    private string m_name;

    // DECLARE_EVENT_TABLE()


    //extern	pxmap	*pixmaps;
    //extern	int	npixmaps;

    //static	const Char	*en_titles[] = { wxT("Alerts"), 0 };
    //static	const Char	*titles[sizeof(en_titles)/sizeof(wxChar *)];
    //static	int	schedule_widths[] = { 500, 0 };

    //BEGIN_EVENT_TABLE(AlertList, wxListCtrl)
    //  EVT_CONTEXT_MENU(AlertList::OnContextMenu)
    //  EVT_MENU(MENU_ALERT_CLEAR, AlertList::OnClear)
    //  EVT_MENU(MENU_ALERT_SAVE, AlertList::OnSave)
    //END_EVENT_TABLE()

#endif
    public AlertList(Window parent, string name)
      : base(parent, name) {
#if false
      this.Name = "alerts";

      if(titles[0])
        localizeArray(titles, en_titles);
      DefineColumns(titles, schedule_widths);
      _listener = new AlertListListener(this);
      alerts.AddListener(_listener);
#endif
    }
#if false

    ~AlertList() {
      freeLocalizedArray(titles);
    }
#endif
    public void AddLine(string txt) {
      //InsertItem(ItemCount, txt);
      //EnsureVisible(ItemCount - 1);
    }
#if false
    void OnContextMenu(object sender, Event evt) {
      Menu menu;
      wxPoint pt = evt.GetPosition();

      pt = evt.GetPosition();
      pt = ScreenToClient(pt);

      menu.Append(MenuIDs.MENU_ALERT_CLEAR, wxPorting.L("Clear"));
      menu.Append(MenuIDs.MENU_ALERT_SAVE, wxPorting.L("Save"));
      PopupMenu(&menu, pt);
    }

    void OnClear(object sender, Event evt) {
      if(ask(L("Remove all alerts from this list?")) != ANSWER_YES)
        return;
      //	DeleteAllItems();
      traindir.ClearAlert();
    }

    void OnSave(object sender, Event evt) {
      wxFFile fp;
      int i;
      char[] buff = new char[512];

      if(ItemCount == 0) {
        wxMessageBox(L("No alerts to save."), wxT("Info"),
      wxOK | wxICON_INFORMATION, traindir.m_frame);
        return;
      }
      if(!traindir.SaveTextFileDialog(buff))
        return;
      if(!(fp.Open(buff, wxT("w")))) {
        wxMessageBox(L("Cannot open file for save."),
      wxT("Info"), wxOK | wxICON_STOP, traindir.m_frame);
        return;
      }
      for(i = 0; i < ItemCount; ++i) {
        string txt = GetItemText(i);
        fp.Write(txt);
      }
      fp.Close();
    }
#endif
  }
}