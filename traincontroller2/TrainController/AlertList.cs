using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {
  public class AlertList : ReportBase {
    private AlertListListener _listener;
    private String m_name;



    private static string[] en_titles = new string[] { wxPorting.T("Alerts"), null };
    private static string[] titles; // Erik: Original code ==> static	const Char	*titles[sizeof(en_titles)/sizeof(char *)];
    private static int[] schedule_widths = new int[] { 500, 0 };


    public AlertList(Window parent, string name)
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
      throw new NotImplementedException();
      //if(Globals.ask(wxPorting.L("Remove all alerts from this list?")) != AskAnswer.ANSWER_YES)
      //  return;
      //Globals.traindir.ClearAlert();
    }

    public void OnSave(object sender, Event evt) {
      throw new NotImplementedException();
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

}
