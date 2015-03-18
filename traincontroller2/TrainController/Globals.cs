using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public partial class Globals {

    public class TrLabel {
      private const int size = 8;
      private bool[] mIsChanged = new bool[size];
      private string[] mValues = new string[size];

      public string time_msg { get { return this[0]; } set { this[0] = value; } }
      public string total_points_msg { get { return this[1]; } set { this[1] = value; } }
      public string alert_msg { get { return this[2]; } set { this[2] = value; } }
      public string time_mult_msg { get { return this[3]; } set { this[3] = value; } }
      public string delay_points_msg { get { return this[4]; } set { this[4] = value; } }
      public string late_points_msg { get { return this[5]; } set { this[5] = value; } }
      public string dummy_line { get { return this[6]; } set { this[6] = value; } }
      public string status_line { get { return this[7]; } set { this[7] = value; } }

      public string this[int i] {
        get {
          if(i < 0 || i >= mValues.Length)
            throw new IndexOutOfRangeException();

          return mValues[i];
        }

        set {
          if(i < 0 || i >= mValues.Length)
            throw new IndexOutOfRangeException();

          mValues[i] = value;
          mIsChanged[i] = true;
        }
      }

      //public String text;
      //public string oldtext;
      //public object handle;

      //public TrLabel(String str) {
      //  text = str;
      //}

      public TrLabel() {
        time_msg = "";
        total_points_msg = "";
        delay_points_msg = "";
        time_mult_msg = "";
        late_points_msg = "";
        alert_msg = "";
        status_line = "";
        dummy_line = "";

        Array.Clear(mIsChanged, 0, mIsChanged.Length);
      }

      public bool IsChanged(int i) {
        if(i < 0 || i >= mValues.Length)
          throw new IndexOutOfRangeException();

        return mIsChanged[i];
      }

      public void ResetChangedStatus(int i) {
        if(i < 0 || i >= mValues.Length)
          throw new IndexOutOfRangeException();

        mIsChanged[i] = false;
      }
    }

    public static String program_name = "TODO - Write something here...";

    public static int time_mult;
    public static int[] time_mults = new int[] { 1, 2, 3, 5, 7, 10, 15, 20, 30, 60, 120, 240, 300, -1 };
    public static int cur_time_mult = 5;	/* start with T x 10 */

    public static string tooltipString;	// 3.4c: tooltip shown on mouse move

    public static TrLabel labelList = new TrLabel();

    public static void add_linked_info_to_status(StringBuilder sb, Track t) {
      if(t.wlinkx != 0 && t.wlinky != 0) {
        sb.AppendFormat(" ({0} {1:D},{2:D})", wxPorting.L("linked to"), t.wlinkx, t.wlinky);
      } else if(t.elinkx != 0 && t.elinky != 0) {
        sb.AppendFormat(" ({0} {1:D},{2:D)", wxPorting.L("linked to"), t.elinkx, t.elinky);
      }
    }

    public static void pointer_at(Coord cell) {
      Track t;
      Signal sig;
      Train tr;
      int x = cell.x;
      int y = cell.y;
      String p = "";
      StringBuilder sb = new StringBuilder();

      tooltipString = "";
      // TODO Re-Enable this case
      if(false) { // (tr = findTrain(x, y))) {
        //status_line = String.Format(wxPorting.T("%d,%d: %s %s"), x, y, tr.name, train_status0(tr, 1));
        //tr.SetTooltip();
      } else if((t = findTrack(x, y)) != null || (t = findSwitch(x, y)) != null) {
        sb.AppendFormat("{0:D},{1:D}: {2} ", x, y, wxPorting.L("speed"));
        for(x = 0; x < Config.NTTYPES; ++x) {
          if(x > 0)
            sb.Append("/");
          sb.AppendFormat("{0:D}", t.speed[x]);
        }
        sb.AppendFormat((" Km/h, {0} {1:D} m"), wxPorting.L("length"), t.length);
        if(t.isstation)
          sb.AppendFormat("  {0}: {1}", wxPorting.L("Station"), t.station);
      } else if((t = findText(x, y)) != null) {
        sb.AppendFormat(
          "{0:D},{1:D}: {2} {3}",
          x, y, wxPorting.L("entry/exit"), t.station
        );
        add_linked_info_to_status(sb, t);
      } else if((sig = findSignal(x, y)) != null) {
        if(sig.controls != null)
          sb.AppendFormat(
            "{0:D},{1:D}: {2} {3} {4} {5:D}, {0:D}",
            x, y,
            wxPorting.L("Signal"),
            sig.station != null ? sig.station.FullName : wxPorting.T(""),
            wxPorting.L("controls"),
            sig.controls.x, sig.controls.y
          );
        else
          sb.AppendFormat(
            "{0:D},{1:D}: {2} {3}",
            x, y,
            wxPorting.L("Signal"),
            sig.station != null ? sig.station.FullName : wxPorting.T("")
          );
        if(String1.IsNullOrWhiteSpaces(sig.stateProgram) == false) {
          sb.AppendFormat(
            wxPorting.T("  {0}: \"{1}\""),
            wxPorting.L("script"), sig.stateProgram
          );
          sb.AppendFormat(
            wxPorting.T("  {0}: \"{1}\""),
            wxPorting.L("aspect"),
            sig._currentState != null ? sig._currentState : wxPorting.T("?")
          );
        }
      } else if((t = findTrackType(x, y, trktype.TRIGGER)) != null) {
        sb.AppendFormat("{0:D},{1:D}: {2} - {3}  . ({4:D},{5:D})  Prob.: ",
          x, y,
          wxPorting.L("Trigger"),
          t.station != null ? t.station.FullName : wxPorting.T(""),
          t.wlinkx, t.wlinky
        );
        for(x = 0; x < Config.NTTYPES; ++x) {
          if(x > 0)
            sb.Append("/");
          sb.AppendFormat("{0:D}", t.speed[x]);
        }
      } else if((t = findTrackType(x, y, trktype.ITIN)) != null) {
        sb.AppendFormat(
          "{0:D},{1:D}: {2} - {3}",
          x, y, wxPorting.L("Itinerary"),
          t.station != null ? t.station.FullName : wxPorting.T("")
        );
      } else if((t = findTrackType(x, y, trktype.IMAGE)) != null) {
        sb.AppendFormat(
          "{0:D},{1:D}: {2} {3}",
          x, y, wxPorting.L("Image"),
          t.station != null ? t.station.FullName : wxPorting.T("")
        );
        add_linked_info_to_status(sb, t);
      } else {
        // status_line[0] = 0;
      }
      labelList.status_line = sb.ToString();
      repaint_labels();
    }


    public static Train findTrain(int x, int y) {
      throw new NotImplementedException();

      //Train tr;

      //for(tr = schedule; tr != null; tr = tr.next)
      //  if(tr.position && tr.position.x == x && tr.position.y == y)
      //    return tr;
      //return 0;
    }

    public static void repaint_labels() {
      repaint_labels(false);
    }

    public static void repaint_labels(bool force) {
      int i;

      for(i = 0; i < 8; ++i)
        if(force || labelList.IsChanged(i)) {
          if(i == 7)
            Globals.traindir.m_frame.m_statusText.Text = labelList[i];
          else if(i == 2)
            Globals.traindir.m_frame.m_alertText.Text = labelList[i];
          else if(i == 0) {
            String buff = labelList[i];
            int p;

            p = buff.IndexOf(wxPorting.T('('));
            if(p < 0)
              p = buff.IndexOf(wxPorting.T('x'));
            if(p < 0) {
              String buff1;
              buff1 = String.Format("x {0:D}", time_mult);
              Globals.traindir.m_frame.m_speed.Text = buff1;
              Globals.traindir.m_frame.m_speedArrows.Value = cur_time_mult;
            }
            Globals.traindir.m_frame.m_clock.Text = buff.Substring(0, p);
          } else if(i < Configuration.NSTATUSBOXES)
            Globals.traindir.m_frame.SetStatusText(labelList[i], i);
          labelList.ResetChangedStatus(i);
        }
      String title = "";

      if(Globals.traindir.m_frame.m_showToolbar) {
        title += program_name;
        title += wxPorting.T(" - ");
        // TODO Re-Enable this part
        //title += fileName(current_project);
        //if(Globals.layout_modified)
        //  title += wxPorting.T(" *");
        title += wxPorting.T(" - ");
        title += labelList[0];
        title += wxPorting.T(" - ");
        title += labelList.total_points_msg;
      } else {
        title += labelList[0];
        title += wxPorting.T(" - ");
        title += labelList.total_points_msg;
        title += wxPorting.T(" - ");
        title += labelList[7];
      }
      Globals.traindir.m_frame.Text = title;
    }

  }
}
