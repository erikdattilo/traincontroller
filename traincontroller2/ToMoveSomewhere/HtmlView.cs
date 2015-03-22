using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainController {

  public class HtmlView : WebBrowser {
    private String m_content;

    public HtmlView()
    {
    //  EVT_CONTEXT_MENU(new wx.EventListener(OnContextMenu));	// not used

      Name = (wxPorting.T("htmlview"));

      // DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(HtmlView_DocumentCompleted);
      this.Navigating += new WebBrowserNavigatingEventHandler(HtmlView_Navigating);
    }

    void HtmlView_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
      string href = e.Url.AbsoluteUri;
      if(href != "about:blank") {
        try {
          LinkClick(href);
        } catch(Exception ex) {
        }
        e.Cancel = true;
      }
    }

    //void HtmlView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
    //  int i;
    //  for(i = 0; i < this.Document.Links.Count; i++) {
    //    this.Document.Links[i].Click += new HtmlElementEventHandler(this.LinkClick);
    //    this.Document.Links[i].SetAttribute("A", "B");
    //  }
    //}

    private void LinkClick(string href) {
      //public void OnLinkClicked(HtmlLinkInfo link) {
      String cmd;
      String buff;

      cmd = href ?? "";

      if(cmd == wxPorting.T("status")) {
        throw new NotImplementedException();
        // Globals.trainsim_cmd(wxPorting.T("performance"));
      } else if(cmd == wxPorting.T("welcome")) {
        throw new NotImplementedException();
        // Globals.ShowWelcomePage();
      } else if(cmd.StartsWith(wxPorting.T("open:"), out buff)) {
        if(buff.Length == 0)
          Globals.traindir.OnOpenFile();
        else
          Globals.traindir.OpenFile(buff);
      } else if(cmd.StartsWith(wxPorting.T("edit:"), out buff)) {
        throw new NotImplementedException();
        //int pg = Globals.traindir.m_frame.m_top.FindPage(wxPorting.L("Layout"));
        //if(pg >= 0)
        //  Globals.traindir.m_frame.m_top.Selection = (pg);
        //Globals.traindir.OnEdit();
      } else {
        throw new NotImplementedException();
        //TDFile infoFile = new TDFile(cmd);
        //if(infoFile.Load()) {
        //  SetPage(infoFile.content);
        //} else {
        //  Globals.trainsim_cmd(cmd);
        //}
      }
    }

    ////
    ////	It would be nice to activate the print feature
    ////	from a context menu.
    ////	Unfortunately the evt is not delivered to us,
    ////	so the only way we have to print is through
    ////	the main menu (see MainFrame).
    ////

    //public void OnContextMenu(object sender, Event evt) {
    //  //Menu menu;
    //  //Point pt = evt.GetPosition();

    //  //pt = evt.GetPosition();
    //  //pt = ScreenToClient(pt);

    //  //menu.Append(MenuIDs.MENU_HTML_PREVIEW, wxPorting.L("Pre&view"));
    //  //menu.Append(MenuIDs.MENU_HTML_PRINT, wxPorting.L("&Print"));
    //  //PopupMenu(&menu, pt);
    //}

    //public void OnPrintPreview(object sender, Event evt) {
    //  //HtmlEasyPrinting pr = Globals.traindir.m_frame.m_printer;

    //  //FILE fp;
    //  //if(!(fp = fopen("C:/Temp/tdir.prn", "w"))) {
    //  //  return;
    //  //}
    //  //fwrite(m_content, 1, m_content.length(), fp);
    //  //fclose(fp);

    //  //pr.PreviewFile(wxPorting.T("C:/Temp/tdir.prn"));
    //  //unlink("C:/Temp/tdir.prn");
    //}

    public bool SetPage(String source) {
      m_content = source;
      DocumentText = source;
      return true;
    }

    //public void OnPrint(object sender, Event evt) {
    //  //HtmlEasyPrinting pr = Globals.traindir.m_frame.m_printer;
    //  //FILE fp;

    //  //if(!(fp = fopen("C:/Temp/tdir.prn", "w"))) {
    //  //  return;
    //  //}
    //  //fwrite(m_content, 1, m_content.length(), fp);
    //  //fclose(fp);

    //  //pr.PrintFile(wxPorting.T("C:/Temp/tdir.prn"));
    //  //unlink("C:/Temp/tdir.prn");
    //}
  }
}
