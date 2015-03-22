using System;
using System.Collections.Generic;

namespace TrainController {
  public class GTFS_Agency {
    public String _agencyId;
    public String _agencyName;
    public String _agencyUrl;
    public String _agencyTimeZone;
    public String _agencyLang;
    public String _agencyPhone;
    public String _agencyFareUrl;
  }

  public class GTFS_Stop {
    public String _stopId;
    public String _stopCode;
    public String _stopName;
    public String _stopDesc;
    public double _stopLat, _stopLon;
    public String _zoneId;
    public String _stopUrl;
    public int _locationType;      // 0=platform, 1=station with multiple platforms
    public String _parentStation;
    public String _stopTimeZone;
    public int _wheelchairBoarding;
  }

  public class GTFS_Route {
    public String _routeId;
    public String _agencyId;
    public String _routeShortName;
    public String _routeLongName;
    public String _routeDesc;
    public int _routeType;
    public String _routeUrl;
    public int _routeColor;
    public int _routeTextColor;
  }

  public class GTFS_Trip {
    public String _routeId;
    public String _serviceId;
    public String _tripId;
    public String _tripHeadsign;
    public String _tripShortName;
    public int _directionId;
    public String _blockId;
    public String _shapeId;
  }

  public class GTFS_StopTime {
    public String _tripId;
    public String _arrivalTime;
    public String _departureTime;
    public String _stopId;
    public int _stopSequence;
    public String _stopHeadsign;
    public int _pickupType;
    public int _dropoffType;
    public double _shapeDistTraveled;
  }

  public class GTFS_Calendar {
    public String _serviceId;
    public int[] _days = new int[7];       // 0=Monday, 7=Sunday
    public String _startDate, _endDate;

    public int GetMask() {
      int days = 0;
      int m = 1;
      int i;
      for(i = 0; i < 7; ++i) {
        if(_days[i] != 0)
          days |= m;
        m <<= 1;
      }
      return days;
    }
  }

  public class GTFS_CalendarDate {
    public String _serviceId;
    public String _date;
    public int _exceptionType; // 1=added for date, 2=removed for date
  }

  public class GTFS_FareAttribute {
    public String _fareId;
    public double _price;
    public String _currencyType;
    public int _paymentMethod; // 0=on board, 1=before boarding
    public int _transfers;     // 0=no transfers, 1=tranfer once, 2=transfer twice, -1=unlimited transfers
    public int _transferDuration;
  }

  public class GTFS_FareRule {
    public String _fareId;
    public String _routeId;
    public String _originId;
    public String _destinationId;
    public String _containsId;
  }

  public class GTFS_Shape {
    public String _shapeId;
    public double _shapePtLat, _shapePtLon;
    public int _shapePtSequence;
    public double _shapeDistTraveled;
  }

  public class GTFS_Frequency {
    public String _tripId;
    public String _startTime;
    public String _endTime;
    public int _headwaySecs;
    public int _exactTimes;
  }

  public class GTFS_Transfer {
    public String _fromStopId;
    public String _toStopId;
    public int _transferType;
    public int _minTransferTime;
  }

  public class GTFS_FeedInfo {
    public String _feedPublisherName;
    public String _feedPublisherUrl;
    public String _feedLang;
    public String _feedStartDate, _feedEndDate;
    public String _feedVersion;
  }

  public class GTFS {
    public List<GTFS_Agency> _agencies;
    public List<GTFS_Stop> _stops;
    public List<GTFS_Route> _routes;
    public List<GTFS_Trip> _trips;
    public List<GTFS_StopTime> _stopTimes;
    public List<GTFS_Calendar> _calendar;
    public List<GTFS_CalendarDate> _calendarDates;
    public List<GTFS_FareAttribute> _fareAttributes;
    public List<GTFS_FareRule> _fareRules;
    public List<GTFS_Shape> _shapes;
    public List<GTFS_Frequency> _frequencies;
    public List<GTFS_Transfer> _transfers;
    public GTFS_FeedInfo _feedInfo;

    public String _our_routes;       // ignore routes not in this list

    public bool Load(string rootDir) {
      throw new NotImplementedException();
      //CSVFile csv;
      //if((csv = exists(rootDir, wxPorting.T("agency"))) != null) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn agencyId = csv.FindColumn(wxPorting.T("agency_id"));
      //    CSVColumn agencyName = csv.FindColumn(wxPorting.T("agency_name"));
      //    CSVColumn agencyUrl = csv.FindColumn(wxPorting.T("agency_url"));
      //    CSVColumn agencyTimeZone = csv.FindColumn(wxPorting.T("agency_timezone"));
      //    CSVColumn agencyLang = csv.FindColumn(wxPorting.T("agency_lang"));
      //    CSVColumn agencyPhone = csv.FindColumn(wxPorting.T("agency_phone"));
      //    CSVColumn agencyFareUrl = csv.FindColumn(wxPorting.T("agency_fare_url"));
      //    while(csv.ReadLine()) {
      //      GTFS_Agency a = new GTFS_Agency();
      //      csv.GetColumn(a._agencyId, agencyId);
      //      csv.GetColumn(a._agencyName, agencyName);
      //      csv.GetColumn(a._agencyUrl, agencyUrl);
      //      csv.GetColumn(a._agencyTimeZone, agencyTimeZone);
      //      csv.GetColumn(a._agencyLang, agencyLang);
      //      csv.GetColumn(a._agencyPhone, agencyPhone);
      //      csv.GetColumn(a._agencyFareUrl, agencyFareUrl);
      //      _agencies.Add(a);
      //    }
      //  }
      //  Globals.delete(csv);
      //}

      //if((csv = exists(rootDir, wxPorting.T("stops"))) != null) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn stopId = csv.FindColumn(wxPorting.T("stop_id"));
      //    CSVColumn stopCode = csv.FindColumn(wxPorting.T("stop_code"));
      //    CSVColumn stopName = csv.FindColumn(wxPorting.T("stop_name"));
      //    CSVColumn stopDesc = csv.FindColumn(wxPorting.T("stop_desc"));
      //    CSVColumn stopLat = csv.FindColumn(wxPorting.T("stop_lat"));
      //    CSVColumn stopLon = csv.FindColumn(wxPorting.T("stop_lon"));
      //    CSVColumn zoneId = csv.FindColumn(wxPorting.T("zone_id"));
      //    CSVColumn stopUrl = csv.FindColumn(wxPorting.T("stop_url"));
      //    CSVColumn locationType = csv.FindColumn(wxPorting.T("location_type"));
      //    CSVColumn parentStation = csv.FindColumn(wxPorting.T("parent_station"));
      //    CSVColumn stopTimeZone = csv.FindColumn(wxPorting.T("stop_timezone"));
      //    CSVColumn wheelchairBoarding = csv.FindColumn(wxPorting.T("wheelchair_boarding"));
      //    while(csv.ReadLine()) {
      //      GTFS_Stop s = new GTFS_Stop();
      //      csv.GetColumn(s._stopId, stopId);
      //      csv.GetColumn(s._stopCode, stopCode);
      //      csv.GetColumn(s._stopName, stopName);
      //      csv.GetColumn(s._stopDesc, stopDesc);
      //      csv.GetColumn(s._stopLat, stopLat);
      //      csv.GetColumn(s._stopLon, stopLon);
      //      csv.GetColumn(s._zoneId, zoneId);
      //      csv.GetColumn(s._stopUrl, stopUrl);
      //      csv.GetColumn(s._locationType, locationType);
      //      csv.GetColumn(s._parentStation, parentStation);
      //      csv.GetColumn(s._stopTimeZone, stopTimeZone);
      //      csv.GetColumn(s._wheelchairBoarding, wheelchairBoarding);
      //      _stops.Add(s);
      //    }
      //  }
      //  Globals.delete(csv);
      //} else
      //  return false;

      //if((csv = exists(rootDir, wxPorting.T("routes"))) != null) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn routeId = csv.FindColumn(wxPorting.T("route_id"));
      //    CSVColumn agencyId = csv.FindColumn(wxPorting.T("agency_id"));
      //    CSVColumn routeShortName = csv.FindColumn(wxPorting.T("route_short_name"));
      //    CSVColumn routeLongName = csv.FindColumn(wxPorting.T("route_long_name"));
      //    CSVColumn routeDesc = csv.FindColumn(wxPorting.T("route_desc"));
      //    CSVColumn routeType = csv.FindColumn(wxPorting.T("route_type"));
      //    CSVColumn routeUrl = csv.FindColumn(wxPorting.T("route_url"));
      //    CSVColumn routeColor = csv.FindColumn(wxPorting.T("route_color"));
      //    CSVColumn routeTextColor = csv.FindColumn(wxPorting.T("route_text_color"));
      //    while(csv.ReadLine()) {
      //      GTFS_Route r = new GTFS_Route();
      //      csv.GetColumn(r._routeId, routeId);
      //      csv.GetColumn(r._agencyId, agencyId);
      //      csv.GetColumn(r._routeShortName, routeShortName);
      //      csv.GetColumn(r._routeLongName, routeLongName);
      //      csv.GetColumn(r._routeDesc, routeDesc);
      //      csv.GetColumn(r._routeType, routeType);
      //      csv.GetColumn(r._routeUrl, routeUrl);
      //      csv.GetColumnHex(r._routeColor, routeColor);
      //      csv.GetColumnHex(r._routeTextColor, routeTextColor);
      //      _routes.Add(r);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("trips"))) != null) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn routeId = csv.FindColumn(wxPorting.T("route_id"));
      //    CSVColumn serviceId = csv.FindColumn(wxPorting.T("service_id"));
      //    CSVColumn tripId = csv.FindColumn(wxPorting.T("trip_id"));
      //    CSVColumn tripHeadSign = csv.FindColumn(wxPorting.T("trip_head_sign"));
      //    CSVColumn tripShortName = csv.FindColumn(wxPorting.T("trip_short_name"));
      //    CSVColumn directionId = csv.FindColumn(wxPorting.T("direction_id"));
      //    CSVColumn blockId = csv.FindColumn(wxPorting.T("block_id"));
      //    CSVColumn shapeId = csv.FindColumn(wxPorting.T("shape_id"));
      //    while(csv.ReadLine()) {
      //      GTFS_Trip t = new GTFS_Trip();

      //      csv.GetColumn(t._routeId, routeId);
      //      csv.GetColumn(t._serviceId, serviceId);
      //      csv.GetColumn(t._tripId, tripId);
      //      csv.GetColumn(t._tripHeadsign, tripHeadSign);
      //      csv.GetColumn(t._tripShortName, tripShortName);
      //      csv.GetColumn(t._directionId, directionId);
      //      csv.GetColumn(t._blockId, blockId);
      //      csv.GetColumn(t._shapeId, shapeId);
      //      _trips.Add(t);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("stop_times"))) != null) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn tripId = csv.FindColumn(wxPorting.T("trip_id"));
      //    CSVColumn arrivalTime = csv.FindColumn(wxPorting.T("arrival_time"));
      //    CSVColumn departureTime = csv.FindColumn(wxPorting.T("departure_time"));
      //    CSVColumn stopId = csv.FindColumn(wxPorting.T("stop_id"));
      //    CSVColumn stopSequence = csv.FindColumn(wxPorting.T("stop_sequence"));
      //    CSVColumn stopHeadsign = csv.FindColumn(wxPorting.T("stop_headsign"));
      //    CSVColumn pickupType = csv.FindColumn(wxPorting.T("pickup_type"));
      //    CSVColumn dropoffType = csv.FindColumn(wxPorting.T("dropoff_type"));
      //    CSVColumn shapeDistTraveled = csv.FindColumn(wxPorting.T("shape_dist_traveled"));
      //    while(csv.ReadLine()) {
      //      GTFS_StopTime t = new GTFS_StopTime();

      //      csv.GetColumn(t._tripId, tripId);
      //      csv.GetColumn(t._arrivalTime, arrivalTime);
      //      csv.GetColumn(t._departureTime, departureTime);
      //      csv.GetColumn(t._stopId, stopId);
      //      csv.GetColumn(t._stopSequence, stopSequence);
      //      csv.GetColumn(t._stopHeadsign, stopHeadsign);
      //      csv.GetColumn(t._pickupType, pickupType);
      //      csv.GetColumn(t._dropoffType, dropoffType);
      //      csv.GetColumn(t._shapeDistTraveled, shapeDistTraveled);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("calendar")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn serviceId = csv.FindColumn(wxPorting.T("service_id"));
      //    CSVColumn mon = csv.FindColumn(wxPorting.T("monday"));
      //    CSVColumn tue = csv.FindColumn(wxPorting.T("tuesday"));
      //    CSVColumn wed = csv.FindColumn(wxPorting.T("wednesday"));
      //    CSVColumn thu = csv.FindColumn(wxPorting.T("thursday"));
      //    CSVColumn fri = csv.FindColumn(wxPorting.T("friday"));
      //    CSVColumn sat = csv.FindColumn(wxPorting.T("saturday"));
      //    CSVColumn sun = csv.FindColumn(wxPorting.T("sunday"));
      //    CSVColumn startDate = csv.FindColumn(wxPorting.T("start_date"));
      //    CSVColumn endDate = csv.FindColumn(wxPorting.T("end_date"));
      //    while(csv.ReadLine()) {
      //      GTFS_Calendar c = new GTFS_Calendar();

      //      csv.GetColumn(c._serviceId, serviceId);
      //      csv.GetColumn(c._days[0], mon);
      //      csv.GetColumn(c._days[1], tue);
      //      csv.GetColumn(c._days[2], wed);
      //      csv.GetColumn(c._days[3], thu);
      //      csv.GetColumn(c._days[4], fri);
      //      csv.GetColumn(c._days[5], sat);
      //      csv.GetColumn(c._days[6], sun);
      //      csv.GetColumn(c._startDate, startDate);
      //      csv.GetColumn(c._endDate, endDate);
      //      _calendar.Add(c);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("calendar_dates")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn serviceId = csv.FindColumn(wxPorting.T("service_id"));
      //    CSVColumn date = csv.FindColumn(wxPorting.T("date"));
      //    CSVColumn exceptionType = csv.FindColumn(wxPorting.T("exception_type"));
      //    while(csv.ReadLine()) {
      //      GTFS_CalendarDate c = new GTFS_CalendarDate();

      //      csv.GetColumn(c._serviceId, serviceId);
      //      csv.GetColumn(c._date, date);
      //      csv.GetColumn(c._exceptionType, exceptionType);
      //      _calendarDates.Add(c);
      //    }
      //  }
      //  Globals.delete(csv);
      //}

      //if((csv = exists(rootDir, wxPorting.T("fare_attributes")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn fareId = csv.FindColumn(wxPorting.T("fare_id"));
      //    CSVColumn price = csv.FindColumn(wxPorting.T("price"));
      //    CSVColumn currencyType = csv.FindColumn(wxPorting.T("currency_type"));
      //    CSVColumn paymentMethod = csv.FindColumn(wxPorting.T("payment_method"));
      //    CSVColumn transfers = csv.FindColumn(wxPorting.T("transfers"));
      //    CSVColumn transferDuration = csv.FindColumn(wxPorting.T("transfer_duration"));
      //    while(csv.ReadLine()) {
      //      GTFS_FareAttribute f = new GTFS_FareAttribute();

      //      csv.GetColumn(f._fareId, fareId);
      //      csv.GetColumn(f._price, price);
      //      csv.GetColumn(f._currencyType, currencyType);
      //      csv.GetColumn(f._paymentMethod, paymentMethod);
      //      csv.GetColumn(f._transfers, transfers);
      //      csv.GetColumn(f._transferDuration, transferDuration);
      //      _fareAttributes.Add(f);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("fare_rules")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn fareId = csv.FindColumn(wxPorting.T("fare_id"));
      //    CSVColumn routeId = csv.FindColumn(wxPorting.T("route_id"));
      //    CSVColumn originId = csv.FindColumn(wxPorting.T("origin_id"));
      //    CSVColumn destinationId = csv.FindColumn(wxPorting.T("destination_id"));
      //    CSVColumn containsId = csv.FindColumn(wxPorting.T("contains_id"));
      //    while(csv.ReadLine()) {
      //      GTFS_FareRule f = new GTFS_FareRule();

      //      csv.GetColumn(f._fareId, fareId);
      //      csv.GetColumn(f._routeId, routeId);
      //      csv.GetColumn(f._originId, originId);
      //      csv.GetColumn(f._destinationId, destinationId);
      //      csv.GetColumn(f._containsId, containsId);
      //      _fareRules.Add(f);
      //    }
      //  }
      //  Globals.delete(csv);
      //}

      //if((csv = exists(rootDir, wxPorting.T("shapes")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn shapeId = csv.FindColumn(wxPorting.T("shape_id"));
      //    CSVColumn shapePtLat = csv.FindColumn(wxPorting.T("shape_pt_lat"));
      //    CSVColumn shapePtLon = csv.FindColumn(wxPorting.T("shape_pt_lon"));
      //    CSVColumn shapePtSequence = csv.FindColumn(wxPorting.T("shape_pt_sequence"));
      //    CSVColumn shapeDistTraveled = csv.FindColumn(wxPorting.T("shape_dist_traveled"));
      //    while(csv.ReadLine()) {
      //      GTFS_Shape s = new GTFS_Shape();

      //      csv.GetColumn(s._shapeId, shapeId);
      //      csv.GetColumn(s._shapePtLat, shapePtLat);
      //      csv.GetColumn(s._shapePtLon, shapePtLon);
      //      csv.GetColumn(s._shapePtSequence, shapePtSequence);
      //      csv.GetColumn(s._shapeDistTraveled, shapeDistTraveled);
      //      _shapes.Add(s);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("frequencies")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn tripId = csv.FindColumn(wxPorting.T("trip_id"));
      //    CSVColumn startTime = csv.FindColumn(wxPorting.T("start_time"));
      //    CSVColumn endTime = csv.FindColumn(wxPorting.T("end_time"));
      //    CSVColumn headwaySecs = csv.FindColumn(wxPorting.T("headways_secs"));
      //    CSVColumn exactTimes = csv.FindColumn(wxPorting.T("exact_times"));
      //    while(csv.ReadLine()) {
      //      GTFS_Frequency f = new GTFS_Frequency();

      //      csv.GetColumn(f._tripId, tripId);
      //      csv.GetColumn(f._startTime, startTime);
      //      csv.GetColumn(f._endTime, endTime);
      //      csv.GetColumn(f._headwaySecs, headwaySecs);
      //      csv.GetColumn(f._exactTimes, exactTimes);
      //      _frequencies.Add(f);
      //    }
      //  }
      //  Globals.delete(csv);
      //}


      //if((csv = exists(rootDir, wxPorting.T("transfers")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn fromStopId = csv.FindColumn(wxPorting.T("from_stop_id"));
      //    CSVColumn toStopId = csv.FindColumn(wxPorting.T("to_stop_id"));
      //    CSVColumn transferType = csv.FindColumn(wxPorting.T("transfer_type"));
      //    CSVColumn minTransferTime = csv.FindColumn(wxPorting.T("min_transfer_time"));
      //    while(csv.ReadLine()) {
      //      GTFS_Transfer t = new GTFS_Transfer();

      //      csv.GetColumn(t._fromStopId, fromStopId);
      //      csv.GetColumn(t._toStopId, toStopId);
      //      csv.GetColumn(t._transferType, transferType);
      //      csv.GetColumn(t._minTransferTime, minTransferTime);
      //      _transfers.Add(t);
      //    }
      //  }
      //  Globals.delete(csv);
      //}

      //if((csv = exists(rootDir, wxPorting.T("feed_info")))) {
      //  if(csv.ReadColumns()) {
      //    CSVColumn feedPublisherName = csv.FindColumn(wxPorting.T("feed_publisher_name"));
      //    CSVColumn feedPublisherUrl = csv.FindColumn(wxPorting.T("feed_publisher_url"));
      //    CSVColumn feedLang = csv.FindColumn(wxPorting.T("feed_lang"));
      //    CSVColumn feedStartDate = csv.FindColumn(wxPorting.T("feed_start_date"));
      //    CSVColumn feedEndDate = csv.FindColumn(wxPorting.T("feed_end_date"));
      //    CSVColumn feedVersion = csv.FindColumn(wxPorting.T("feed_version"));
      //    if(csv.ReadLine()) {
      //      csv.GetColumn(_feedInfo._feedPublisherName, feedPublisherName);
      //      csv.GetColumn(_feedInfo._feedPublisherUrl, feedPublisherUrl);
      //      csv.GetColumn(_feedInfo._feedLang, feedLang);
      //      csv.GetColumn(_feedInfo._feedStartDate, feedStartDate);
      //      csv.GetColumn(_feedInfo._feedEndDate, feedEndDate);
      //      csv.GetColumn(_feedInfo._feedVersion, feedVersion);
      //    }
      //  }
      //  Globals.delete(csv);
      //}

      //return true;
    }



    public GTFS_Calendar FindCalendarByService(string serviceId) {
      for(int c = 0; c < _calendar.Count; ++c) {
        GTFS_Calendar calEntry = _calendar[c];
        if(calEntry._serviceId.CompareTo(serviceId) == 0) {
          return calEntry;
        }
      }
      return null;
    }

    public GTFS_Route FindRouteById(string routeId) {
      int r;
      GTFS_Route route;

      for(r = 0; r < _routes.Count; ++r) {
        route = _routes[r];
        if(route._routeId.CompareTo(routeId) == 0)
          return route;
      }
      return null;
    }


    public void SetOurRoutes(string r) {
      _our_routes = r;
    }

    public bool IgnoreRoute(string routeId) {
      throw new NotImplementedException();
      //if(_our_routes.IsNull() || _our_routes.IsEmpty())
      //  return false;       // no route list specified, allow all
      //string buff;
      //buff = string.Copy(_our_routes);
      //string p, begin;
      //for(p = begin = buff; *p; ) {
      //  if(p[0] == ',') {
      //    *p.incPointer() = 0;
      //    if(!wxStrcmp(begin, routeId))
      //      return false;
      //    begin = p;
      //  } else
      //    p = p.Substring(1);
      //}
      //if(begin != p) {
      //  if(!wxStrcmp(begin, routeId))
      //    return false;
      //}
      //return true;        // not found in our list, so ignore it
    }
  }

  public partial class Globals {
    public static void Panic(string msg) {
      throw new NotImplementedException();
      // Globals.traindir.Panic();
    }


    static CSVFile exists(string rootDir, string fileName) {
      string path;
      CSVFile csv;

      path = String.Format(wxPorting.T("%s/%s.txt"), rootDir, fileName);
      csv = new CSVFile(path);
      if(csv.Load())
        return csv;
      
      // Globals.delete(csv);
      return null;
    }

  }
}