using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {

  class MySplitterWindow : SplitterWindow {
    private Frame m_frame;

    /// TODO Riabilitare queste righe
    // DECLARE_EVENT_TABLE()

    /// TODO Riabilitare queste righe
    //BEGIN_EVENT_TABLE(MySplitterWindow, wxSplitterWindow)
    //    EVT_SPLITTER_SASH_POS_CHANGED(wxID_ANY, MySplitterWindow::OnPositionChanged)
    //    EVT_SPLITTER_SASH_POS_CHANGING(wxID_ANY, MySplitterWindow::OnPositionChanging)

    //    EVT_SPLITTER_DCLICK(wxID_ANY, MySplitterWindow::OnDClick)

    ////    EVT_SPLITTER_UNSPLIT(wxID_ANY, MySplitterWindow::OnUnsplitEvent)
    //END_EVENT_TABLE()

    public MySplitterWindow(Window parent)
      : base(
      parent, (int)MenuIDs2.wxID_ANY, wxDefaultPosition, wxDefaultSize,
      WindowStyles.SP_3D | WindowStyles.SP_LIVE_UPDATE | WindowStyles.CLIP_CHILDREN) {
    }

    public void OnPositionChanged(object sender, Event evt) {
      evt.Skip();
    }

    public void OnPositionChanging(object sender, Event evt) {
      evt.Skip();
    }

    public void OnDClick(object sender, Event evt) {
      /// TODO Riabilitare queste righe
      // evt.StopPropagation();
    }

    public void OnDoubleClickSash(int x, int y) {
    }
  }
}