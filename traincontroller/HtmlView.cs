using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;
using wx.Html;

namespace TrainDirNET {
  class HtmlView : HtmlWindow {
    private string m_content;

    public HtmlView(Window parent)
      : base(parent) {
      Name = wxPorting.T("htmlview");

      EVT_CONTEXT_MENU(new EventListener(OnContextMenu));	// not used
    }

    //
    //	It would be nice to activate the print feature
    //	from a context menu.
    //	Unfortunately the event is not delivered to us,
    //	so the only way we have to print is through
    //	the main menu (see MainFrame).
    //

    public void OnContextMenu(object sender, Event evt) {
      //Menu menu = new Menu();
      //Point pt = ((ContextMenuEvent)evt).Position;
      //pt = ScreenToClient(pt);

      //menu.Append(MENU_HTML_PREVIEW, L("Pre&view"));
      //menu.Append(MENU_HTML_PRINT, L("&Print"));
      //PopupMenu(menu, pt);
    }


  }
}