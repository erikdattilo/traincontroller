using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  static partial class _TimeTableCPP {
    public static TimeTable timetable;
  }

  class TimeTable : SynchronizedList<TrainEntry> {
    public int _lastReloaded;
  };
}