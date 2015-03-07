using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {

  public class TrainInfoList : ReportBase // ListCtrl
  {

    public String m_name;

    private static String[] en_titles = new string[] { wxPorting.T("Station"), wxPorting.T("Platform"), wxPorting.T("Arrival"), wxPorting.T("Departure"), wxPorting.T("Min.Stop"), wxPorting.T("Late"), null };
    private static String[] titles = new string[en_titles.Length];
    private static int[] schedule_widths = new int[] { 200, 50, 80, 80, 80, 80, 0 };

    public TrainInfoList(Window parent, String name)
      : base(parent, name) {
      SetName(wxPorting.T("traininfo"));
      if(titles == null)
        Globals.localizeArray(ref titles, en_titles);
      DefineColumns(titles, schedule_widths);
    }

    ~TrainInfoList() {
      Globals.freeLocalizedArray(titles);
    }

    // TODO Check and clean this method
    public void Update(Train trn) {
      ListItem item = new ListItem();
      string buff;
      int i;

      DeleteAllItems();
      if(trn == null)
        return;
      Freeze();
      Station station;

      i = 0;
      foreach(TrainStop ts in trn.stops) {
      // for(ts = trn.stops; ts != null; ts = ts.next) {
        station = ts.station ?? new Station();


        //buff = string.Copy(ts.station);
        //if((p = Globals.wxStrchr(buff, '@')) != null)
        //  *p = 0;
        buff = String.Copy(station.StationName);
        InsertItem(i, buff);

        if(station.PlatformName.Length == 0) // if(p)
          SetItem(i, 1, station.PlatformName);

        SetItem(i, 2, ts.minstop != 0 ? Globals.format_time(ts.arrival) : wxPorting.T(""));
        SetItem(i, 3, Globals.format_time(ts.departure));
        buff = ""; // buff[0] = 0;
        if(ts.minstop != 0)
          // TODO Change the format of this
          buff = string.Format(wxPorting.T("%d"), ts.minstop);
        SetItem(i, 4, buff);
        buff = ""; // buff[0] = 0;
        if(ts.delay != 0)
          // TODO Change the format of this
          buff = string.Format(wxPorting.T("%d"), ts.delay);
        SetItem(i, 5, buff);

        item.Id = (i);
        GetItem(item);
        if(ts.minstop == null)
          item.TextColour = (wx.Colour.wxBLUE);
        else if(Station.FindStationNamed(ts.station) == null)
          item.TextColour = (wx.Colour.wxRED);
        else
          item.TextColour = (wx.Colour.wxBLACK);
        SetItem(item);

        ++i;
      }
      Thaw();
    }

  }
}
