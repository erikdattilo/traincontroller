/*	TrainInfoList.cpp - Created by Giampiero Caprino

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
namespace Traincontroller2 {

public class TrainInfoList : ReportBase // ListCtrl
{

	public String    m_name;

  private static	String[] en_titles = new string[] { wxPorting.T("Station"), wxPorting.T("Platform"), wxPorting.T("Arrival"), wxPorting.T("Departure"), wxPorting.T("Min.Stop"), wxPorting.T("Late"), null };
private static	String[] titles = new string[en_titles.Length];
private static	int[]	schedule_widths = new int[] { 200, 50, 80, 80, 80, 80, 0 };

public TrainInfoList(Window parent, String name)
: base(parent, name)
{
	SetName(wxPorting.T("traininfo"));
	if(titles == null)
	    Globals.localizeArray(ref titles, en_titles);
	DefineColumns(titles, schedule_widths);
}

~TrainInfoList()
{
	Globals.freeLocalizedArray(titles);
}

public void Update(Train trn)
{
  //ListItem	item = new ListItem();
  //string buff;
  //String p;
  //int	i;

  //DeleteAllItems();
  //if(!trn)
  //    return;
  //Freeze();
  //TrainStop   ts;

  //i = 0;
  //for(ts = trn.stops; ts != null; ts = ts.next) {
  //    buff = string.Copy(ts.station);
  //    if((p = Globals.wxStrchr(buff, '@')) != null)
  //  *p = 0;
  //    InsertItem(i, buff);
  //    if(p)
  //  SetItem(i, 1, p + 1);
  //    SetItem(i, 2, ts.minstop != null ? Globals.format_time(ts.arrival) : wxPorting.T(""));
  //    SetItem(i, 3, Globals.format_time(ts.departure));
  //    buff[0] = 0;
  //    if(ts.minstop != 0)
  //  buff = string.Format(wxPorting.T("%d"), ts.minstop);
  //    SetItem(i, 4, buff);
  //    buff[0] = 0;
  //    if(ts.delay != 0)
  //  buff = string.Format(wxPorting.T("%d"), ts.delay);
  //    SetItem(i, 5, buff);

  //    item.Id = (i);
  //    GetItem(item);
  //    if(ts.minstop == null)
  //      item.TextColour = (wx.Colour.wxBLUE);
  //    else if(Globals.findStationNamed(ts.station) == null)
  //      item.TextColour = (wx.Colour.wxRED);
  //    else
  //  item.TextColour = (wx.Colour.wxBLACK);
  //    SetItem(item);

  //    ++i;
  //}
  //Thaw();
}

}
}