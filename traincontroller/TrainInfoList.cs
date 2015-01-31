using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  class TrainInfoList : ReportBase {
    private string m_name;

    private string[] en_titles = new string[] { wxPorting.T("Station"), wxPorting.T("Platform"), wxPorting.T("Arrival"), wxPorting.T("Departure"), wxPorting.T("Min.Stop"), wxPorting.T("Late") };
    private string[] titles;
    private int[] schedule_widths = new int[] { 200, 50, 80, 80, 80, 80 };

    public TrainInfoList(Window parent, string name)
      : base(parent, name) {
      name = wxPorting.T("traininfo");

      titles = new string[en_titles.Length];

      if(titles[0] != null)
        Translations.LocalizeArray(titles, en_titles);

      DefineColumns(titles, schedule_widths);
    }

    public void Update(Train trn) {
      ListItem item = new ListItem();
      string buff;
      string buff2 = "";
      int i;
      int pos;

      DeleteAllItems();
      if(trn == null)
        return;
      Freeze();
      TrainStop ts;

      i = 0;
      for(ts = trn.stops; ts != null; ts = ts.next) {
        buff = ts.station;
        pos = buff.IndexOf(Configuration.PLATFORM_SEP);
        if(pos >= 0) {
          buff2 = buff.Substring(pos + 1);
          buff = buff.Substring(0, pos);
        }
        InsertItem(i, buff);
        if(pos >= 0)
          SetItem(i, 1, buff2);
        SetItem(i, 2, ts.minstop != 0 ? GlobalFunctions.format_time(ts.arrival) : wxPorting.T(""));
        SetItem(i, 3, GlobalFunctions.format_time(ts.departure));
        buff = "";
        if(ts.minstop != 0)
          string.Format(wxPorting.T("{0}"), ts.minstop);
        SetItem(i, 4, buff);
        buff = "";
        if(ts.delay != 0)
          string.Format(wxPorting.T("{0}"), ts.delay);
        SetItem(i, 5, buff);

        item.Id = i;
        GetItem(item);
        if(ts.minstop == 0)
          item.TextColour = Colour.wxBLUE;
        else if(GlobalFunctions.findStationNamed(ts.station) == null)
          item.TextColour = Colour.wxRED;
        else
          item.TextColour = Colour.wxBLACK;
        SetItem(item);

        ++i;
      }
      Thaw();
    }


  }
}