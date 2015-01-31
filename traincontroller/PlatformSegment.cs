using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDirNET {
  public class PlatformSegment {
    public PlatformSegment next;
    public int y;
    public int x0, x1;
    public Train train;
    public Train parent;
    public long timein, timeout;
  }
}
