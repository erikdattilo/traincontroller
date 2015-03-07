using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class Station {
    private String mStationName, mPlatformName;

    public String StationName {
      get { return mStationName; }
      set { mStationName = (value ?? "").Trim(); }
    }

    public String PlatformName {
      get { return mPlatformName; }
      set { mPlatformName = (value ?? "").Trim(); }
    }

    public Station()
      : this(null) {
    }

    public Station(String stationName, String platformName) {
      StationName = stationName;
      PlatformName = platformName;
    }

    public Station(String fullDefinition) {
      int pos;
      String stName, pfName;

      fullDefinition = (fullDefinition ?? "").Trim();

      pos = fullDefinition.IndexOf(Globals.PLATFORM_SEP);
      if(pos >= 0) {
        stName = fullDefinition.Substring(0, pos);
        pfName = (fullDefinition.Length > pos) ?
          fullDefinition.Substring(pos + 1) :
          "";
      } else {
        stName = fullDefinition;
        pfName = "";
      }

      StationName = (stName ?? "").Trim();
      PlatformName = (pfName ?? "").Trim();
    }

    // TODO Check and clean this method
    public static Track FindStationNamed(Station station) {
      if(station == null || String1.IsNullOrWhiteSpaces(station.StationName))
        return null;

      string stationName = station.StationName;


      // for(t = Globals.layout; t != null; t = t.next) {
      foreach(Track t in Globals.LayoutList) {
        if(t.station == null)
          continue;

        if(!stationName.Equals(t.station))
          continue;

        switch(t.TrackType) {
          case trktype.TRACK:
            // if(t.type == trktype.TRACK && t.isstation && !Globals.wxStrncmp(name, t.station, len)) {
            if(t.isstation)
              return t;

            break;

          case trktype.TEXT:
            // if(t.type == trktype.TEXT && !wxStrcmp(stationName, t.station) &&
            // ((t.wlinkx && t.wlinky) || (t.elinkx && t.elinky)))
            if((t.wlinkx != 0 && t.wlinky != 0) || (t.elinkx != 0 && t.elinky != 0))
              return t;
            break;

          case trktype.SWITCH:
            // if(t.type == trktype.SWITCH && !wxStrcmp(stationName, t.station))
            return t;
        }
      }
      
      return null;
    }

  }
}
