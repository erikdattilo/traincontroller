using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public partial class HtmlPage {

    public string content;

    public HtmlPage(String title) {
      content = String.Copy(wxPorting.T("<html>\n"));
      StartPage(title);
    }

    public void StartPage(String title) {
      content = wxPorting.T("<head><title>");
      content += title;
      content += wxPorting.T("</title></head>\n");
      content += wxPorting.T("<body bgcolor=\"#FFFFFF\" text=\"#000000\">\n");
      if(string.IsNullOrEmpty(title) == false) {
        content += wxPorting.T("<center><h1>");
        content += title;
        content += wxPorting.T("</h1></center>\n");
        content += wxPorting.T("<hr>\n");
      }
    }

    public void EndPage() {
      content += wxPorting.T("</body></html>\n");
    }

    public void AddCenter() {
      content += wxPorting.T("<center><br>");
    }

    public void EndCenter() {
      content += wxPorting.T("</center><br>");
    }

    public void AddHeader(String hdr) {
      content += wxPorting.T("<h1>");
      content += hdr;
      content += wxPorting.T("</h1>\n");
    }

    public void Add(String txt) {
      content += txt;
    }

    public void AddLine(String txt) {
      content += txt;
      content += wxPorting.T("<br>\n");
    }

    public void AddRuler() {
      content += wxPorting.T("<hr>\n");
    }

    public void StartTable(String headers) {
      throw new NotImplementedException();
      //int i;

      //content += wxPorting.T("<center><table cellspacing=3>\n");
      //content += wxPorting.T("<tr valign=top bgcolor=\"#00ffcc\">\n");
      //for(i = 0; headers[i]; ++i) {
      //  content += wxPorting.T("<td valign=top>");
      //  content += headers[i];
      //  content += wxPorting.T("</td>\n");
      //}
      //content += wxPorting.T("</tr>\n\n");
    }

    public void AddTableRow(String values) {
      throw new NotImplementedException();
      //int i;

      //content += wxPorting.T("<tr VALIGN=TOP>\n");
      //for(i = 0; values[i]; ++i) {
      //  content += wxPorting.T("<td valign=top>");
      //  content += (*values[i] ? values[i] : wxPorting.T("&nbsp;"));
      //  content += wxPorting.T("</td>\n");
      //}
      //content += wxPorting.T("</tr>\n\n");
    }

    public void AddTableRow(int nValues, String[] values) {
      throw new NotImplementedException();
      //int i;
      //String nbsp = string.Copy(wxPorting.T("&nbsp;"));

      //content += wxPorting.T("<tr VALIGN=TOP>\n");
      //for(i = 0; i < nValues; ++i) {
      //  content += wxPorting.T("<td valign=top>");
      //  content += (values[i].size() ? *values[i] : nbsp);
      //  content += wxPorting.T("</td>\n");
      //}
      //content += wxPorting.T("</tr>\n\n");
    }

    public void EndTable() {
      content += wxPorting.T("</table>\n");
    }
  }
}
