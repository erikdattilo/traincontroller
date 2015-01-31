using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class SignalAspect {
    public SignalAspect _next;
    public string _name;
    public string[] _iconN = new string[Configuration.MAX_FLASHING_ICONS];
    public string[] _iconE = new string[Configuration.MAX_FLASHING_ICONS];
    public string[] _iconS = new string[Configuration.MAX_FLASHING_ICONS];
    public string[] _iconW = new string[Configuration.MAX_FLASHING_ICONS];
    public string _action;
  }
}