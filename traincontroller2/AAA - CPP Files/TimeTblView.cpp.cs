// /*	TimeTableView.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */
// 
// #include "wx/wx.h"
// #include "wx/listctrl.h"
// #include "wx/image.h"
// #include "wx/imaglist.h"
// #include "TimeTblView.h"
// #include "MainFrm.h"
// #include "Traindir3.h"
// 
// extern	void	ShowTrainInfo(Train *trn);
// extern	void	ShowTrainInfoDialog(Train *trn);
// 
// extern	pxmap	*pixmaps;
// extern	int	npixmaps;
// 
// static	const wxChar	*en_titles[] = { wxT("Entry"), wxT("From"),
// 	wxT("To"), wxT("Exit"), wxT("Train"), wxT("Speed"), wxT("Min.Del."), wxT("Min.Late"), wxT("Status"), wxT("Notes"), NULL };
// static	const wxChar	*titles[sizeof(en_titles)/sizeof(wxChar *)];
// static	int	schedule_widths[] = { 50, 50, 50, 50, 50, 50, 60, 60, 200, 200, 0 };
// 
// BEGIN_EVENT_TABLE(TimeTableView, wxListCtrl)
// 	EVT_LIST_ITEM_ACTIVATED(wxID_ANY, TimeTableView::OnItemActivated)
// 	EVT_CONTEXT_MENU(TimeTableView::OnContextMenu)
// 	EVT_MENU(MENU_SCHED_SHOW_CANCELED, TimeTableView::OnShowCanceled)
// 	EVT_MENU(MENU_SCHED_SHOW_ARRIVED, TimeTableView::OnShowArrived)
// 	EVT_MENU(MENU_SCHED_ASSIGN, TimeTableView::OnAssign)
// 	EVT_MENU(MENU_SCHED_TRACK_FIRST, TimeTableView::OnTrackFirst)
// 	EVT_MENU(MENU_SCHED_TRACK_LAST, TimeTableView::OnTrackLast)
// 	EVT_MENU(MENU_SCHED_PRINT_TRAIN, TimeTableView::OnPrintTrain)
// END_EVENT_TABLE()
// 
// static	Train **listed_trains;
// static	int num_listed_trains;
// 
// //
// //
// //
// 
// TimeTableView::TimeTableView(wxWindow *parent, const wxString& name)
// 	: ReportBase(parent, name),
// 	m_bTrackFirst(false),
// 	m_bTrackLast(false)
// {
// 	SetName(wxT("timetable"));
// 	if(!titles[0])
// 	    localizeArray(titles, en_titles);
// 	DefineColumns(titles, schedule_widths);
// }
// 
// //
// //
// //
// 
// TimeTableView::~TimeTableView()
// {
// 	freeLocalizedArray(titles);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::LoadState(const wxString& header, TConfig& state)
// {
// 	int	res;
// 
// 	ReportBase::LoadState(header, state);
// 	if(state.GetInt(wxT("show_canceled"), res))
// 	    show_canceled = res != 0;
// 	if(state.GetInt(wxT("track_first"), res))
// 	    m_bTrackFirst = res != 0;
// 	if(state.GetInt(wxT("track_last"), res))
// 	    m_bTrackLast = res != 0;
// 	if(state.GetInt(wxT("show_arrived"), res))
// 	    show_arrived = res != 0;
// }
// 
// //
// //
// //
// 
// void	TimeTableView::SaveState(const wxString& header, TConfig& state)
// {
// 	ReportBase::SaveState(header, state);
// 	state.PutInt(wxT("show_canceled"), show_canceled ? 1 : 0);
// 	state.PutInt(wxT("show_arrived"), show_arrived ? 1 : 0);
// 	state.PutInt(wxT("track_first"), m_bTrackFirst ? 1 : 0);
// 	state.PutInt(wxT("track_last"), m_bTrackLast ? 1 : 0);
// }
// 
// //
// //
// //
// 
// 
// void	TimeTableView::OnContextMenu(wxContextMenuEvent& event)
// {
// 	wxMenu	menu;
// 	wxMenuItem  *item;
// 	wxPoint pt = event.GetPosition();
// 
// 	pt = event.GetPosition();
//         pt = ScreenToClient(pt);
// 
// 	item = menu.Append(MENU_SCHED_SHOW_CANCELED, L("Show Canceled"), L("Show/hide canceled trains from list"), wxITEM_CHECK);
// 	item->Check(show_canceled != 0);
// 	item = menu.Append(MENU_SCHED_SHOW_ARRIVED, L("Show Arrived"), L("Show/hide arrived trains from list"), wxITEM_CHECK);
// 	item->Check(show_arrived != 0);
// 	item = menu.Append(MENU_SCHED_TRACK_FIRST, L("Track First Train"), L("Automatically show first active train in list"), wxITEM_CHECK);
// 	item->Check(m_bTrackFirst);
// 	item = menu.Append(MENU_SCHED_TRACK_LAST, L("Track Last Train"), L("Automatically show last active train in list"), wxITEM_CHECK);
// 	item->Check(m_bTrackLast);
// 	item = menu.Append(MENU_SCHED_ASSIGN, L("Assign"), L("Assingn stock of arrived train to another train"));
// 	Train *trn = (Train *)GetSelectedData();
// 	if(trn && trn->status != train_ARRIVED)
// 	    menu.Enable(MENU_SCHED_ASSIGN, false);
// 	item = menu.Append(MENU_SCHED_PRINT_TRAIN, L("Train Info"), L("Show train info page"));
// 	PopupMenu(&menu, pt);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnShowCanceled(wxCommandEvent& event)
// {
// 	show_canceled = !show_canceled;
// 	fill_schedule(schedule, 0);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnShowArrived(wxCommandEvent& event)
// {
// 	show_arrived = !show_arrived;
// 	fill_schedule(schedule, 0);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnAssign(wxCommandEvent& event)
// {
// 	Train	    *trn = (Train *)GetSelectedData();
// 
//         if(trn)
// 	    assign_dialog(trn);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnTrackFirst(wxCommandEvent& event)
// {
// 	m_bTrackFirst = !m_bTrackFirst;
// 	m_bTrackLast = false;
// 	if(m_bTrackFirst)
// 	    ShowFirst();
// }
// 
// //
// //
// //
// 
// void	TimeTableView::ShowFirst()
// {
// 	int	i;
// 	Train	*t;
// 	wxListItem item;
// 
// 	for(i = 0; i < GetItemCount(); ++i) {
// 	    item.SetId(i);
// 	    item.SetMask(wxLIST_MASK_DATA);
// 	    GetItem(item);
// 	    t = (Train *)item.GetData();
//             if(t->isExternal)
//                 continue;
// 	    switch(t->status) {
// 	    case train_ARRIVED:
// 	    case train_DERAILED:
// 		continue;
// 	    }
// 	    EnsureVisible(i);
// 	    break;
// 	}
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnTrackLast(wxCommandEvent& event)
// {
// 	m_bTrackLast = !m_bTrackLast;
// 	m_bTrackFirst = false;
// 	if(m_bTrackLast)
// 	    ShowLast();
// }
// 
// //
// //
// //
// 
// void	TimeTableView::ShowLast()
// {
// 	int	i;
// 	int	last;
// 	Train	*t;
// 	wxListItem item;
// 
// 	last = 0;
// 	for(i = GetItemCount() - 1; i > 0; --i) {
// 	    item.SetId(i);
// 	    item.SetMask(wxLIST_MASK_DATA);
// 	    GetItem(item);
// 	    t = (Train *)item.GetData();
//             if(t->isExternal)
//                 continue;
// 	    switch(t->status) {
// 	    case train_ARRIVED:
// 	    case train_DERAILED:
// 	    case train_READY:
// 		continue;
// 	    }
// 	    if(is_canceled(t))
// 		continue;
// 	    last = i;
// 	    break;
// 	}
// 	EnsureVisible(last);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnPrintTrain(wxCommandEvent& event)
// {
// 	Train	    *trn = (Train *)GetSelectedData();
// 	if(trn)
// 	    ShowTrainInfo(trn);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::OnItemActivated(wxListEvent& event)
// {
// 	wxListItem  item = event.GetItem();
// 	Train	    *trn = (Train *)item.GetData();
// 
// 	if(traindir->m_frame->m_timeTableLocation == TIME_TABLE_SPLIT)
// 	    traindir->m_frame->ShowTrainInfoList(trn);
// 	else
// 	    ShowTrainInfoDialog(trn);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::UpdateItem(int i, Train *t)
// {
// 	wxListItem item;
// 	wxString    notes;
// 	int	    n;
//         TrainInfo   info;
// 
//         t->Get(info);
// 
// 	SetItem(i, 1, t->entrance);
//         SetItem(i, 0, info.entering_time);
// 	SetItem(i, 2, t->exit);
// 	SetItem(i, 3, info.leaving_time);
// 	SetItem(i, 4, t->name);
// 	SetItem(i, 5, info.current_speed);
// 	SetItem(i, 6, info.current_delay);
// 	SetItem(i, 7, info.current_late);
// 	SetItem(i, 8, info.current_status);
// 	for(n = 0; n < MAXNOTES; ++n) {
// 	    notes += t->notes[n] ? t->notes[n] : wxT("");
// 	    notes += wxT(" ");
// 	}
// 	SetItem(i, 9, notes);
// 
// 	item.SetId(i);
// 	GetItem(item);
// 	item.SetTextColour(*wxGREEN);
//         item.SetBackgroundColour(*wxWHITE);
// 	item.SetData((wxUIntPtr)t);
// 	switch(t->status) {
// 	case train_READY:
// 	    if(t->days && run_day && !(t->days & run_day)) {
// //		wxColour fg(64, 64, 64);
// //		item.SetTextColour(fg);
// 		item.SetTextColour(traindir->m_colorCanceled);
// 		break;
// 	    } else {
// 		item.SetTextColour(traindir->m_colorReady); //*wxBLUE);
// 		break;
// 	    }
// 	case train_ARRIVED:
// 	    if(!show_arrived)
// 		item.SetTextColour(*wxLIGHT_GREY);
// 	    else
// 		item.SetTextColour(traindir->m_colorArrived); //*wxGREEN);
// 	    break;
// 
// 	case train_DERAILED:
// 	    item.SetTextColour(traindir->m_colorDerailed); //*wxRED);
// 	    break;
// 
//         case train_WAITING:
//             item.SetBackgroundColour(traindir->m_colorWaiting);
//             item.SetTextColour(*wxRED);
//             break;
// 
//         case train_STOPPED:
//             item.SetTextColour(traindir->m_colorStopped);
//             break;
// 
// 	default:	    // running
// 	    item.SetTextColour(traindir->m_colorRunning); //*wxBLACK);
// 	}
// 	SetItem(item);
// }
// 
// //
// //
// //
// 
// void	TimeTableView::DeleteRow(int i)
// {
// 	DeleteItem(i);
// }
// 
// //
// //
// //
// 
// bool    ignore_train(Train *tr)
// {
//         if(tr->isExternal)
//             return true;
// 
// 	if(show_arrived)
// 	    return false;
// 
// 	if(tr->status != train_ARRIVED)
// 	    return false;
// 
// 	if(!tr->stock)
// 	    return true;
// 
// 	Train *t1 = findTrainNamed(tr->stock);
// 	return t1 && t1->status != train_READY;
// }
// 
// //
// //
// //
// 
// void	fill_schedule(Train *tr, int assign)
// {
// 	/* Here we do the actual adding of the text. It's done once for
// 	 * each row.
// 	 */
// 
// 	int	i, tt;
// 	TimeTableView *clist;
// 	Train	*t;
// 	wxImageList *icons = new wxImageList(48, 16);
// 
// 	if(listed_trains)
// 	    free(listed_trains);
// 	listed_trains = 0;
// 	num_listed_trains = 0;
// 	for(t = tr; t; t = t->next)
// 	    ++num_listed_trains;
// 	if(num_listed_trains)
// 	    listed_trains = (Train **)calloc(sizeof(Train *), num_listed_trains);
// 	for(tt = 0; tt < NUMTTABLES; ++tt) {
// 	    clist = traindir->m_frame->m_timeTableManager.GetTimeTable(tt);
// 	    if(!clist)
// 		continue;
// 	    clist->DeleteAllItems();
// 	    clist->Freeze();
// 	    i = 0;
// 	    for(t = tr; t; t = t->next) {
// 		/* when reassigning train stock, we consider only
// 		    trains that are scheduled to depart at the same
// 		    station where the assignee has arrived. */
// ///		if(assign && (t->status != train_READY ||
// ///			    !sameStation(oldtrain->position->station, t->entrance)))
// ///		    continue;
// 		if(!t->entrance)
// 		    continue;
// 		if(ignore_train(t))
// 		    continue;
// 
// 		if(show_canceled || !is_canceled(t)) {
// 		    //print_train_info(t);
//                     TrainInfo info;
//                     t->Get(info);
// 		    clist->InsertItem(i, info.entering_time, t->epix);
// 		    clist->UpdateItem(i, t);
// 		    listed_trains[i] = t;
// 		    ++i;
// 		}
// 	    }
// 	    clist->Thaw();
// 	}
// }
// 
// //
// //
// //
// 
// void	gr_update_schedule(Train *tr, int itm)
// {
// 	int	tt;
// 	int	x;
// 	TimeTableView *clist;
// 
// 	if(ignore_train(tr)) {
// 	    // remove from list
// 	    for(x = 0; x < num_listed_trains; ++x) {
// 		if(listed_trains[x] == tr)
// 		    break;
// 	    }
// 	    if(x < num_listed_trains) {
// 		for(tt = 0; tt < NUMTTABLES; ++tt) {
// 		    clist = traindir->m_frame->m_timeTableManager.GetTimeTable(tt);
// 		    if(!clist)
// 			continue;
// 		    clist->DeleteRow(x);
// 		}
// 		for(tt = x; tt < num_listed_trains - 1; ++tt)
// 		    listed_trains[tt] = listed_trains[tt + 1];
// 		--num_listed_trains;
// 	    }
// //	    fill_schedule(schedule, 0);
// 	}
// 	print_train_info(tr);
// 	for(tt = 0; tt < NUMTTABLES; ++tt) {
// 	    clist = traindir->m_frame->m_timeTableManager.GetTimeTable(tt);
// 	    if(!clist)
// 		continue;
// 	    if(!tr->entrance)
// 		continue;
// 	    for(x = 0; x < num_listed_trains; ++x)
// 		if(listed_trains[x] == tr)
// 		    break;
// 	    if(x >= num_listed_trains)
// 		continue;
// 	    clist->UpdateItem(x, tr);
// 	    if(clist->m_bTrackFirst)
// 		clist->ShowFirst();
// 	    else if(clist->m_bTrackLast)
// 		clist->ShowLast();
// 	}
// }
// 
