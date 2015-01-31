using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class ReportBase : ListCtrl {
    public string m_name;	    // identifier for state file section


    public ReportBase(Window parent, string name)
      : base(parent, (int)MenuIDs2.wxID_ANY, wxDefaultPosition,
        wxDefaultSize,
      WindowStyles.LC_REPORT | WindowStyles.LC_HRULES | WindowStyles.LC_SINGLE_SEL) {
      m_name = name;
    }

    protected void DefineColumns(string[] titles, int[] widths) {
      int i;
      ListItem col;

      //  Insert columns
      for(i = 0; i < titles.Length; ++i) {
        col = new ListItem(titles[i]);
        //	    col.SetImage(-1);
        InsertColumn(i, col);
        SetColumnWidth(i, widths[i]);
      }
    }

    public void LoadState(string header, TConfig state) {
      int nCols;
      int i;
      int w;
      string buff;

      if(!state.FindSection(header))
        return;
      state.GetInt(("nCols"), out nCols);
      for(i = 0; i < nCols; ++i) {
        buff = String.Format("width{0}", i);
        if(state.GetInt(buff, out w))
          SetColumnWidth(i, w);
      }
    }

    public void SaveState(string header, TConfig state) {
      int nCol = ColumnCount;
      int i;
      string buff;

      state.StartSection(header);
      state.PutString(("name"), m_name);
      state.PutString(("type"), Name);
      state.PutInt(("nCols"), nCol);
      for(i = 0; i < nCol; ++i) {
        int w = GetColumnWidth(i);

        buff = String.Format("width{0}", i);
        state.PutInt(buff, w);
      }
    }

    protected ClientData GetSelectedData() {
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