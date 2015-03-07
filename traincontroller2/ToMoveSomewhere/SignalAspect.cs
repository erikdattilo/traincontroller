using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class SignalAspect {
    public SignalAspect _next;
    public String _name;
    public wx.Image[] _iconN = new wx.Image[Config.MAX_FLASHING_ICONS],
          _iconE = new wx.Image[Config.MAX_FLASHING_ICONS],
          _iconS = new wx.Image[Config.MAX_FLASHING_ICONS],
          _iconW = new wx.Image[Config.MAX_FLASHING_ICONS];
    public String _action;

    public SignalAspect() {
      _next = null;
      _name = null;
      _action = String.Copy(wxPorting.T("none"));
      Array.Clear(_iconN, 0, _iconN.Length);
      Array.Clear(_iconE, 0, _iconE.Length);
      Array.Clear(_iconS, 0, _iconS.Length);
      Array.Clear(_iconW, 0, _iconW.Length);
    }
  }
}
