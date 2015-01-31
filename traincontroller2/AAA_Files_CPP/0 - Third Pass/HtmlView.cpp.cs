/*	HtmlView.cpp - Created by Giampiero Caprino

This file is part of Train Director 3

Train Director is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; using exclusively version 2.
It is expressly forbidden the use of higher versions of the GNU
General Public License.

Train Director is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Train Director; see the file COPYING.  If not, write to
the Free Software Foundation, 59 Temple Place - Suite 330,
Boston, MA 02111-1307, USA.
*/

using System;
using wx;
using wx.Html;
using System.Drawing;
namespace Traincontroller2 {

  public class HtmlView : HtmlWindow {
    private String m_content;

    public HtmlView(Window parent)
      : base(parent) {
      EVT_CONTEXT_MENU(new wx.EventListener(OnContextMenu));	// not used

      Name = (wxPorting.T("htmlview"));
    }

    public void OnLinkClicked(HtmlLinkInfo link) {
      //String cmd;
      //String buff;

      //cmd = link.Href;

      //if(cmd == wxPorting.T("status")) {
      //  Globals.trainsim_cmd(wxPorting.T("performance"));
      //} else if(cmd == wxPorting.T("welcome")) {
      //  Globals.ShowWelcomePage();
      //} else if(cmd.StartsWith(wxPorting.T("open:"), buff)) {
      //  if(buff.Length == 0)
      //    Globals.traindir.OnOpenFile();
      //  else
      //    Globals.traindir.OpenFile(buff);
      //} else if(cmd.StartsWith(wxPorting.T("edit:"), buff)) {
      //  int pg = Globals.traindir.m_frame.m_top.FindPage(wxPorting.L("Layout"));
      //  if(pg >= 0)
      //    Globals.traindir.m_frame.m_top.Selection = (pg);
      //  Globals.traindir.OnEdit();
      //} else {
      //  TDFile infoFile = new TDFile(cmd);
      //  if(infoFile.Load()) {
      //    SetPage(infoFile.content);
      //  } else {
      //    Globals.trainsim_cmd(cmd);
      //  }
      //}
    }

    //
    //	It would be nice to activate the print feature
    //	from a context menu.
    //	Unfortunately the evt is not delivered to us,
    //	so the only way we have to print is through
    //	the main menu (see MainFrame).
    //

    public void OnContextMenu(object sender, Event evt) {
      //Menu menu;
      //Point pt = evt.GetPosition();

      //pt = evt.GetPosition();
      //pt = ScreenToClient(pt);

      //menu.Append(MenuIDs.MENU_HTML_PREVIEW, wxPorting.L("Pre&view"));
      //menu.Append(MenuIDs.MENU_HTML_PRINT, wxPorting.L("&Print"));
      //PopupMenu(&menu, pt);
    }

    public void OnPrintPreview(object sender, Event evt) {
      //HtmlEasyPrinting pr = Globals.traindir.m_frame.m_printer;

      //FILE fp;
      //if(!(fp = fopen("C:/Temp/tdir.prn", "w"))) {
      //  return;
      //}
      //fwrite(m_content, 1, m_content.length(), fp);
      //fclose(fp);

      //pr.PreviewFile(wxPorting.T("C:/Temp/tdir.prn"));
      //unlink("C:/Temp/tdir.prn");
    }

    public bool SetPage(String source) {
      throw new NotImplementedException();
      //m_content = source;
      //return HtmlWindow.SetPage(source);
    }

    public void OnPrint(object sender, Event evt) {
      //HtmlEasyPrinting pr = Globals.traindir.m_frame.m_printer;
      //FILE fp;

      //if(!(fp = fopen("C:/Temp/tdir.prn", "w"))) {
      //  return;
      //}
      //fwrite(m_content, 1, m_content.length(), fp);
      //fclose(fp);

      //pr.PrintFile(wxPorting.T("C:/Temp/tdir.prn"));
      //unlink("C:/Temp/tdir.prn");
    }

  }
}