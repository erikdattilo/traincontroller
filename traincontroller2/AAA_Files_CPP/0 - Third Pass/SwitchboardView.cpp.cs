 /*	tgraph.cpp - Created by Giampiero Caprino
 
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
namespace Traincontroller2 {


  partial class Configuration {
    // public static int HEADER_HEIGHT = 20;
    public static int NAMEPANEL_WIDTH = 180;

    public static int CELL_WIDTH = 50;
    public static int CELL_HEIGHT = 50;

    public static int MAXXCELLS = 20;
    public static int MAXYCELLS = 20;
  }

  public partial class Globals {
    public static void get_switchboard(HtmlPage page) {
      string buff;
      string[] buffs = new string[9];
      string eol;
      int i;

      eol = wxPorting.T("<br>n");
      page.StartPage(wxPorting.L("Switchboard"));
      page.Add(wxPorting.T("<p>"));
      page.Add(wxPorting.L("Use this screen to define the layout of a switchboard and which itineraries are shown in it."));
      page.Add(eol);
      page.Add(wxPorting.L("Switchboards are accessed via an external web browser at the port"));
      buff = String.Format(wxPorting.T(" %d"), http_server_port._iValue); //8081); //server_port);
      page.Add(buff);
      page.Add(eol);
      page.Add(wxPorting.T("<a href=\"sb-browser\">"));
      page.Add(wxPorting.L("Open the switchboard in a browser."));
      page.Add(wxPorting.T("</a><br>n"));
      page.AddCenter();
      page.Add(wxPorting.T("<table><tr><td valign=\"top\">n"));

      // 2 tables side by side
      // left table is the list of pages
      // right table is the switchboard for the current page

      page.Add(wxPorting.T("<table><tr><th width='180'>"));
      page.Add(wxPorting.L("Switchboards"));
      page.Add(wxPorting.T("</th></tr>n"));

      SwitchBoard sb;
      if(curSwitchBoard == null)
        curSwitchBoard = switchBoards;

      for(sb = switchBoards; sb != null; sb = sb._next) {
        if(sb == curSwitchBoard) {
          page.Add(wxPorting.T("<tr><td bgcolor=\"#c0ffc0\">"));
          page.Add(sb._name);
          page.Add(wxPorting.T("&nbsp;&nbsp;&nbsp;<a href=\"sb-edit -e "));
          page.Add(sb._fname);
          page.Add(wxPorting.T("\">"));
          page.Add(wxPorting.L("change"));
          page.Add(wxPorting.T("</a></td></tr>n"));
        } else {
          page.Add(wxPorting.T("<tr><td bgcolor=\"#e0e0e0\">"));
          page.Add(wxPorting.T("<a href=\"sb-edit "));
          page.Add(sb._fname);
          page.Add(wxPorting.T("\">"));
          page.Add(sb._name);
          page.Add(wxPorting.T("</a></td></tr>n"));
        }
      }
      page.Add(wxPorting.T("<tr><td><hr></td></tr>n"));
      page.Add(wxPorting.T("<tr><td><a href=\"sb-edit\">"));
      page.Add(wxPorting.L("New board"));
      //	page.Add(wxPorting.T("<tr><td><a href="sb-save">"));
      //	page.Add(wxPorting.L("Save"));
      //	page.Add(wxPorting.T("</a></td></tr>n"));
      page.Add(wxPorting.T("</a></td></tr>n"));

      page.Add(wxPorting.T("</table></td>"));	    // end of left table

      sb = curSwitchBoard;
      if(sb == null)
        sb = switchBoards;

      page.Add(wxPorting.T("<td><table><tr valign=\"top\"><td width='40'>&nbsp;</td>n"));
      for(i = 0; i < Configuration.MAXXCELLS; ++i) {
        page.Add(wxPorting.T("<th width='70'>"));
        buff = String.Format(wxPorting.T("%d"), i);
        page.Add(buff);
        page.Add(wxPorting.T("</th>n"));
      }
      page.Add(wxPorting.T("</tr>n"));
      if(sb == null) {
        page.Add(wxPorting.T("<tr><td>"));
        page.Add(wxPorting.L("No selected switchboard."));
        page.Add(wxPorting.T("</td></tr></table>n"));
        page.Add(wxPorting.T("</td></tr>n"));

        page.EndTable();
        page.EndPage();
        return;
      }

      for(i = 0; i < Configuration.MAXYCELLS; ++i) {
        int j;
        page.Add(wxPorting.T("<tr>"));
        buff = String.Format(wxPorting.T("<td width='40'>%d</td>n"), i);
        page.Add(buff);
        for(j = 0; j < Configuration.MAXXCELLS; ++j) {
          SwitchBoardCell cell = sb.Find(j, i);
          buff = String.Format(wxPorting.T("<td width='70' align='center' valign='top'><a href=\"sb-cell %d,%d\">%s</a></td>n"),
              j, i, cell != null ? (string)cell._text : wxPorting.T("?"));
          page.Add(buff);
        }
        page.Add(wxPorting.T("</tr>n"));
      }
      page.Add(wxPorting.T("</tr></table>n"));
      page.Add(wxPorting.T("</td></tr>n"));

      page.EndTable();
      page.EndPage();
    }


    public static void SwitchboardOpenBrowser(string cmd) {
      String url;

      if(curSwitchBoard == null)
        return;
      url = String.Format(wxPorting.T("http://localhost:%d/switchboard/%s"), http_server_port._iValue, curSwitchBoard._fname);

      wxPorting.wxLaunchDefaultBrowser(url);
    }
  }
}