 /*	ItineraryDialog.cpp - Created by Giampiero Caprino
 
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
  public class ItineraryDialog : Dialog {
    public
     TextCtrl m_name,
       m_next;
    StaticText m_start_point;

    public ItineraryDialog(Window parent)
      : base(parent, 0, wxPorting.T("Itinerary Properties"), Window.wxDefaultPosition, Window.wxDefaultSize,
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L(" Itinerary Properties ")) {
      //ArrayString strings;
      //string buff;
      //BoxSizer column = new BoxSizer(Orientation.wxVERTICAL);
      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);

      //StaticText header = new StaticText(this, 0, wxPorting.L("&Name"));
      //m_name = new TextCtrl(this, 0, Globals.wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(header, 35, Alignment.wxALIGN_LEFT | Alignment.wxALIGN_RIGHT, 4);
      //row.Add(m_name, 65, Direction.wxGROW | Alignment.wxALIGN_RIGHT | Direction.wxLEFT, 6);

      //column.Add(row, 1, Direction.wxGROW | Direction.wxTOP |  Direction.wxRIGHT |  Direction.wxLEFT, 10);

      //buff = String.Format( wxPorting.L("From signal 'MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM'"), 0, 0); //sig.x, sig.y);

      //m_start_point = new StaticText(this, 0, buff);
      //column.Add(m_start_point, 1, Direction.wxGROW | Direction.wxTOP |  Direction.wxRIGHT |  Direction.wxLEFT, 10);

      //row = new BoxSizer(Orientation.wxHORIZONTAL);

      //header = new StaticText(this, 0, wxPorting.L("Ne&xt itinerary"));
      //m_next = new TextCtrl(this, 0, wxEmptyString, Window.wxDefaultPosition, Window.wxDefaultSize);

      //row.Add(header, 35, Alignment.wxALIGN_LEFT |  Direction.wxRIGHT, 4);
      //row.Add(m_next, 65, Direction.wxGROW | Orientation.wxALIGN_RIGHT |  Direction.wxLEFT, 6);

      //column.Add(row, 1, Direction.wxGROW | Direction.wxTOP |  Direction.wxRIGHT |  Direction.wxLEFT, 10);
      ////	wxStaticLine *line = new wxStaticLine( this );

      ////	column.Add(line);

      //column.Add(CreateButtonSizer(ButtonFlags.OK | ButtonFlags.DIALOG_CANCEL), 0, Direction.wxGROW | Direction.wxALL, 10);

      //SetSizer(column);
      //column.Fit(this);
      //column.SetSizeHints(this);
    }

    public int ShowModal(Itinerary it) {
      throw new NotImplementedException();
      //string buff, buff1;

      //if(String.IsNullOrEmpty(it.name) == false)
      //  m_name.Value = (it.name);
      //buff = String.Format(wxPorting.L("From signal '%s'"), it.signame);
      //m_start_point.Label = (buff);
      //if(String.IsNullOrEmpty(it.nextitin) == false)
      //  m_next.Value = (it.nextitin);

      //Centre();
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_name.SetFocus();
      //int res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //if(res != wxID_OK)
      //  return wxID_CANCEL;

      //buff = String.Copy(m_name.Value);
      //buff1 = String.Copy(m_next.Value);

      //if(!Globals.set_itin_name(it, buff, buff1))
      //  return wxID_CANCEL;
      //Globals.FillItineraryTable();
      //return wxID_OK;
    }
  }



  /////////////////////////////////////////////////////////////////////////////
  /////////////////////////////////////////////////////////////////////////////
  /////////////////////////////////////////////////////////////////////////////


  public class ItineraryKeyDialog : Dialog {
    private StaticText m_header;
    private TextCtrl m_edit;

    private Button m_selectbutton,
          m_clearbutton,
          m_closebutton;
    private ListCtrl m_list;

    private static string[] en_titles2 = new string[] { wxPorting.T("Name"), wxPorting.T("Start Signal"),
 			    wxPorting.T("End Signal"), wxPorting.T("Next Itinerary"), null };
    private static string[] titles2 = new string[en_titles2.Length];
    private static int[] col_widths2 = new int[] { 100, 80, 80, 100, 0 };

    public ItineraryKeyDialog(Window parent)
      : base(parent, 0, wxPorting.L("Select Itinerary"),
          Window.wxDefaultPosition, new wxSize(400, 200),
          WindowStyles.DD_DEFAULT_STYLE, wxPorting.L("Select Itinerary")) {
      //EVT_BUTTON((int)MenuIDs.ID_ITINSELECT, new wx.EventListener(OnSelect));
      //EVT_BUTTON((int)MenuIDs.ID_ITINCLEAR, new wx.EventListener(OnClear));
      //EVT_LIST_ITEM_ACTIVATED(wxID_ANY, new wx.EventListener(OnActivated));

      //int i;

      //if(!titles2[0])
      //  Globals.localizeArray(ref titles2, en_titles2);

      //BoxSizer row = new BoxSizer(Orientation.wxHORIZONTAL);
      //BoxSizer col = new BoxSizer(Orientation.wxVERTICAL);

      //m_header = new StaticText(this, 0, new String(wxPorting.T('M'), 80));
      //col.Add(m_header, 0,  Direction.wxRIGHT, 5);

      //m_list = new ListCtrl(this, (int)MenuIDs.ID_LIST, Window.wxDefaultPosition,
      //  Window.wxDefaultSize, WindowStyles.LC_REPORT | WindowStyles.LC_HRULES | WindowStyles.LC_SINGLE_SEL);

      //col.Add(m_list, 1, Direction.wxGROW | Direction.wxTOP | Direction.wxBOTTOM, 5);

      //row.Add(col, 1, Direction.wxGROW | Direction.wxALL, 5);

      //col = new BoxSizer(Orientation.wxVERTICAL);

      //m_selectbutton = new Button(this, (int)MenuIDs.ID_ITINSELECT, wxPorting.L("&Select"));
      //m_selectbutton.SetDefault();
      //col.Add(m_selectbutton, 0, Direction.wxTOP | Direction.wxGROW, 10);
      //m_clearbutton = new Button(this, (int)MenuIDs.ID_ITINCLEAR, wxPorting.L("&Clear"));
      //col.Add(m_clearbutton, 0, Direction.wxTOP | Direction.wxGROW, 10);
      //m_closebutton = new Button(this, (int)wxID_CANCEL, wxPorting.L("Cl&ose"));
      //col.Add(m_closebutton, 0, Direction.wxTOP | Direction.wxGROW, 10);

      //row.Add(col, 0, SizerFlag.wxALL, 5);

      //wx.ListItem listcol = new ListItem();

      ////  Insert columns

      //for(i = 0; String.IsNullOrEmpty(titles2[i]) == false; ++i) {
      //  listcol.SetText(titles2[i]);
      //  m_list.InsertColumn(i, listcol);
      //  m_list.SetColumnWidth(i, col_widths2[i]);
      //}
      //SetSizer(row);
      //row.Fit(this);
      //row.SetSizeHints(this);
      //m_header.Label = (wxPorting.L("Select itinerary"));
      //SetSize(600, 400);
    }

    ~ItineraryKeyDialog() {
      Globals.freeLocalizedArray(titles2);
    }

    private long GetSelectedItem() {
      int i = m_list.SelectedItemCount;

      if(i != 1)
        return -1;

      long l = m_list.GetNextItem(-1, ListCtrl.NEXT.ALL, ListItemState.SELECTED);

      EndModal(ShowModalResult.OK);
      return l;
    }

    private void OnSelect(object sender, Event evt) {
      long i = GetSelectedItem();
      int j;
      Itinerary it;

      if(i < 0)
        return;

      j = 0;
      for(it = Globals.itineraries; it != null && j != i; it = it.next)
        ++j;
      if(it == null)		// impossible
        return;
      it.Select();
    }

    private void OnClear(object sender, Event evt) {
      long i = GetSelectedItem();
      if(i < 0)
        return;

      int j = 0;
      Itinerary it;
      for(it = Globals.itineraries; it != null && j != i; it = it.next)
        ++j;
      if(it == null)		// impossible
        return;

      it.Deselect(false);
    }

    private void OnClose(object sender, Event evt) {
      //	EndModal
    }

    private void OnActivated(object sender, Event evt) {
      long i = GetSelectedItem();
      int j;
      Itinerary it;

      if(i < 0)
        return;

      j = 0;
      for(it = Globals.itineraries; it != null && j != i; it = it.next)
        ++j;
      if(it == null)		// impossible
        return;
      it.Select();
    }

    private void FillItineraryList() {
      Itinerary it;
      int i;

      m_list.DeleteAllItems();
      m_list.Freeze();

      i = 0;
      for(it = Globals.itineraries; it != null; it = it.next) {
        m_list.InsertItem(i, it.name);
        m_list.SetItem(i, 1, it.signame);
        m_list.SetItem(i, 2, it.endsig);
        m_list.SetItem(i, 3, it.nextitin);
        ++i;
      }
      m_list.Thaw();
    }

    public int ShowModal() {
      throw new NotImplementedException();
      //FillItineraryList();

      //// Centre();	    // use last time's position
      //bool oldIgnore = Globals.traindir.m_ignoreTimer;
      //Globals.traindir.m_ignoreTimer = true;
      //m_list.SetFocus();
      //ListItem item = new ListItem();
      //item.SetId(0);
      //item.Mask = ListItemMask.STATE;
      //item.State = ListItemState.SELECTED | ListItemState.FOCUSED;
      //m_list.SetItem(item);
      //int res = base.ShowModal();
      //Globals.traindir.m_ignoreTimer = oldIgnore;
      //return res;
    }
  }
}