/*	ReportBase.cpp - Created by Giampiero Caprino

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

namespace TrainDirPorting {




  public class ReportBase : ListCtrl {
    // Erik's patch
    protected void SetName(string name) {
      Name = name;
    }


    public String m_name;	    // identifier for state file section

    public ReportBase(Window parent, String name)
      : base(parent, wxID_ANY, wxDefaultPosition,
        wxDefaultSize, WindowStyles.LC_REPORT | WindowStyles.LC_HRULES | WindowStyles.LC_SINGLE_SEL) {
      m_name = name;
    }

    public void DefineColumns(string[] titles, int[] widths) {
      int i;

      ListItem col = new ListItem();

      //  Insert columns

      for(i = 0; String.IsNullOrEmpty(titles[i]) == false; ++i) {
        col.Text = (titles[i]);
        InsertColumn(i, col);
        SetColumnWidth(i, widths[i]);
      }
    }

    public virtual void LoadState(String header, TConfig state) {
      int nCols;
      int i;
      int w;
      String buff;

      if(!state.FindSection(header))
        return;
      state.GetInt(wxPorting.T("nCols"), out nCols);
      for(i = 0; i < nCols; ++i) {
        buff = String.Format(wxPorting.T("width%d"), i);
        if(state.GetInt(buff, out w))
          SetColumnWidth(i, w);
      }
    }

    public virtual void SaveState(String header, TConfig state) {
      int nCol = this.ColumnCount;
      int i;
      String buff;

      state.StartSection(header);
      state.PutString(wxPorting.T("name"), m_name);
      state.PutString(wxPorting.T("type"), this.Name);
      state.PutInt(wxPorting.T("nCols"), nCol);
      for(i = 0; i < nCol; ++i) {
        int w = GetColumnWidth(i);

        buff = String.Format(wxPorting.T("width%d"), i);
        state.PutInt(buff, w);
      }
    }

    public object GetSelectedData() {
      ListItem item = new ListItem();
      int idx = -1;
      idx = GetNextItem(idx, NEXT.ALL, ListItemState.SELECTED);
      if(idx == -1)
        return null;
      item.Id = idx;
      item.Mask = ListItemMask.DATA;
      GetItem(item);
      return item.Data;

    }
  }
}