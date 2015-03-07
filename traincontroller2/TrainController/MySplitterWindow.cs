using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;

namespace TrainController {

  public class MySplitterWindow : SplitterWindow {

    private Frame m_frame;
    public MySplitterWindow(Window parent)
      : base(parent, wx.Window.wxID_ANY,
                         wxDefaultPosition, wxDefaultSize,
                         WindowStyles.SP_3D | WindowStyles.SP_LIVE_UPDATE |
                         WindowStyles.CLIP_CHILDREN /* | wxSP_NO_XP_THEME */ ) {

      //EVT_SPLITTER_SASH_POS_CHANGED(wx.Window.wxID_ANY, new wx.EventListener(OnPositionChanged));
      //EVT_SPLITTER_SASH_POS_CHANGING(wx.Window.wxID_ANY, new wx.EventListener(OnPositionChanged));

      //EVT_SPLITTER_DCLICK(wx.Window.wxID_ANY, new wx.EventListener(OnDClick));
    }

    public void OnPositionChanged(object sender, Event evt) {
      evt.Skip();
    }

    public void OnPositionChanging(object sender, Event evt) {
      evt.Skip();
    }

    public void OnDClick(object sender, Event evt) {
      //evt.StopPropagation();
    }

    public void OnDoubleClickSash(int x, int y) {
    }
  }

}
