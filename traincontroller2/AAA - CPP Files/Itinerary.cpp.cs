// /*	Itinerary.cpp - Created by Giampiero Caprino
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
// #include <stdio.h>
// #include <string.h>
// 
// #if !defined(__unix__) && !defined(__WXMAC__)
// #include <malloc.h>
// #else
// #include <stdlib.h>
// #endif
// #include <math.h>
// #include "wx/ffile.h"
// #include "wx/textfile.h"
// #include "Traindir3.h"
// #include "Itinerary.h"
// 
// Itinerary *itineraries;
// 
// int	toggle_signal(Signal *t);
// 
// void	puzzle_check(Track *t);
// extern	int enable_training;
// Vector	*findPath(Track *trk, int dir);
// 
// Itinerary   *find_itinerary(const wxChar *name)
// {
// 	Itinerary *it;
// 
// 	for(it = itineraries; it; it = it->next)
// 	    if(!wxStrcmp(it->name, name))
// 		return it;
// 	return 0;
// }
// 
// void	clear_visited(void)
// {
// 	Itinerary *ip;
// 
// 	for(ip = itineraries; ip; ip = ip->next)
// 	    ip->visited = 0;
// }
// 
// void	delete_itinerary(Itinerary *ip)
// {
// 	Itinerary *it, *oit;
// 
// 	oit = 0;
// 	for(it = itineraries; it && ip != it; it = it->next)
// 	    oit = it;
// 	if(!it)
// 	    return;
// 	if(!oit)
// 	    itineraries = it->next;
// 	else
// 	    oit->next = it->next;
// 	free_itinerary(it);
// }
// 
// void	delete_itinerary(const wxChar *name)
// {
// 	Itinerary *it, *oit;
// 
// 	oit = 0;
// 	for(it = itineraries; it && wxStrcmp(it->name, name); it = it->next)
// 	    oit = it;
// 	if(!it)
// 	    return;
// 	if(!oit)
// 	    itineraries = it->next;
// 	else
// 	    oit->next = it->next;
// 	free_itinerary(it);
// }
// 
// void	free_itinerary(Itinerary *it)
// {
// 	if(it->signame)
// 	    free(it->signame);
// 	if(it->endsig)
// 	    free(it->endsig);
// 	if(it->name)
// 	    free(it->name);
// 	if(it->sw)
// 	    free(it->sw);
// 	free(it);
// }
// 
// void	add_itinerary(Itinerary *it, int x, int y, int sw)
// {
// 	int	i;
// 
// 	for(i = 0; i < it->nsects; ++i)
// 	    if(it->sw[i].x == x && it->sw[i].y == y) {
// 		it->sw[i].switched = sw;
// 		return;
// 	    }
// 	if(it->nsects >= it->maxsects) {
// 	    it->maxsects += 10;
// 	    if(!it->sw) {
// 		it->sw = (switin *)malloc(sizeof(switin) * it->maxsects);
// 	    } else {
// 		it->sw = (switin *)realloc(it->sw,
// 					sizeof(switin) * it->maxsects);
// 	    }
// 	}
// 	it->sw[it->nsects].x = x;
// 	it->sw[it->nsects].y = y;
// 	it->sw[it->nsects].switched = sw;
// 	++it->nsects;
// }
// 
// bool    Itinerary::TurnSwitches()
// {
//         int     el;
//         Track   *trk;
// 
//         // turn every switch
//         for(el = 0; el < nsects; ++el) {
// 	    trk = findSwitch(sw[el].x, sw[el].y);
// 	    if(!trk)
// 	        return false;
//             sw[el].oldsw = trk->switched;
//             trk->switched = sw[el].switched;
//         }
//         return true;
// }
// 
// void    Itinerary::RestoreSwitches()
// {
//         int     el;
//         Track   *trk;
// 
//         // turn every switch
//         for(el = 0; el < nsects; ++el) {
// 	    trk = findSwitch(sw[el].x, sw[el].y);
// 	    if(!trk)
// 	        break;
//             trk->switched = sw[el].oldsw;
//         }
// }
// 
// int	check_itinerary(Itinerary *it)
// {
// 	wxChar	*nextitin;
// 	Track	*t1;
// 	int	i;
// 
// 	clear_visited();
// agn:
// 	if(!it || it->visited)
// 	    return 0;
// 	for(i = 0; i < it->nsects; ++i) {
// 	    t1 = findSwitch(it->sw[i].x, it->sw[i].y);
// 	    if(!t1 || t1->fgcolor == color_green)
// 		return 0;
// 	    it->sw[i].oldsw = t1->switched;
// 	    if(it->sw[i].switched != t1->switched)
// 		if((t1 = findSwitch(t1->wlinkx, t1->wlinky)))
// 		    if(t1->fgcolor == color_green)
// 			return 0;
// 	}
// 	if(!(nextitin = it->nextitin) || !*nextitin)
// 	    return 1;
// 	it->visited = 1;
// 	for(it = itineraries; it; it = it->next)
// 	    if(!wxStrcmp(it->name, nextitin))
// 		break;
// 	goto agn;
// }
// 
// void	toggle_itinerary(Itinerary *it)
// {
// 	Track	*t1;
// 	int	i;
// 	wxChar	*nextitin;
// 
// 	do {
// 	    for(i = 0; i < it->nsects; ++i) {
// 		t1 = findSwitch(it->sw[i].x, it->sw[i].y);
// 		if(it->sw[i].switched != t1->switched) {
// 		    t1->switched = !t1->switched;
// 		    change_coord(t1->x, t1->y);
// 		    if((t1 = findSwitch(t1->wlinkx, t1->wlinky))) {
// 			t1->switched = !t1->switched;
// 			change_coord(t1->x, t1->y);
// 		    }
// 		}
// 	    }
// 	    if(!(nextitin = it->nextitin) || !*nextitin)
// 		return;
// 	    for(it = itineraries; it; it = it->next)
// 		if(!wxStrcmp(it->name, nextitin))
// 		    break;
// 	} while(it);			/* always true */
// }
// 
// int	green_itinerary(Itinerary *it)
// {
// 	Signal	*t1;
// 	Itinerary *ip;
// 	wxChar	*nextitin;
// 	int	i;
// 	Signal	*blocks[100];
// 	int	nxtblk;
// 
// 	nxtblk = 0;
// 	for(ip = it; ip; ) {
// 	    if(!(t1 = findSignalNamed(ip->signame)))
// 		return 0;
// 	    if(t1->status == ST_GREEN)
// 		return 0;
// 	    blocks[nxtblk++] = t1;
// 	    if(!(nextitin = ip->nextitin) || !*nextitin)
// 		break;			/* done */
// 	    for(ip = itineraries; ip; ip = ip->next)
// 		if(!wxStrcmp(ip->name, nextitin))
// 		    break;
// 	}
// 
// 	/* all signals are red, try to turn them green */
// 
// 	for(i = 0; i < nxtblk; ++i)
// 	    if(!toggle_signal(blocks[i]))
// 		break;			/* line block is busy */
// 
// 	if(i >= nxtblk)			/* success! */
// 	    return 1;
// 	while(--i >= 0)			/* undo signal toggling */
// 	    toggle_signal(blocks[i]);
// 	return 0;
// }
// 
// void	itinerary_selected(Itinerary *it)
// {
// 	it->Select();
// }
// 
// void	itinerary_selected(Track *t)
// {
// 	size_t	    namelen;
// 	Itinerary   *it;
// 
// 	if(t->station && *t->station == '@') {	    // use script
// 	    t->OnClicked();
// 	    return;
// 	}
// 	wxChar *nameend = wxStrrchr(t->station, '@');
// 
// 	if(nameend)
// 	    namelen = nameend - t->station;
// 	else
// 	    namelen = wxStrlen(t->station);
// 	for(it = itineraries; it; it = it->next) {
// 	    if(!wxStrncmp(it->name, t->station, namelen) &&
// 		  wxStrlen(it->name) == namelen)
//  		break;
// 	}
// 	if(it)
// 	    itinerary_selected(it);
// 	if(enable_training) {
// 	    puzzle_check(t);
// 	}
// }
// 
// 
// void	try_itinerary(int sx, int sy, int ex, int ey)
// {
// 	Itinerary *it = 0;
// 	Signal	*t1, *t2;
// 
// 	t1 = findSignal(sx, sy);
// 	t2 = findSignal(ex, ey);
// 	if(!t1 || !t2)
// 	    return;
// 	if(t1->station && *t1->station && t2->station && *t2->station) {
// 	    for(it = itineraries; it; it = it->next)
// 		if(!wxStrcmp(it->signame, t1->station) &&
// 			!wxStrcmp(it->endsig, t2->station))
// 		    break;
// 	}
// //	if(!it) {
// //	    Itinerary *it = find_from_to(t1, t2);
// //	    return;
// //	}
// 	itinerary_selected(it);
// }
// 
// 
// bool	Itinerary::Select()
// {
// 	Itinerary *it = this;
// 	Track	*t1;
// 	int	i;
// 	wxChar	*nextitin;
// 
// 	if(!check_itinerary(it))
// 	    return false;
// 	toggle_itinerary(it);
// 	if(green_itinerary(it))
// 	    return true;		/* success */
// 	    
// 	/* error - restore switches status */
// err:
// 	for(i = 0; i < it->nsects; ++i) {
// 	    t1 = findSwitch(it->sw[i].x, it->sw[i].y);
// 	    if(!t1)
// 		continue;
// 	    if(it->sw[i].switched == it->sw[i].oldsw)
// 		continue;
// 	    t1->switched = !t1->switched;
// 	    change_coord(t1->x, t1->y);
// 	    if((t1 = findSwitch(t1->wlinkx, t1->wlinky))) {
// 		t1->switched = !t1->switched;
// 		change_coord(t1->x, t1->y);
// 	    }
// 	}
// 	if(!(nextitin = it->nextitin) || !*nextitin)
// 	    return false;
// 	for(it = itineraries; it; it = it->next)
// 	    if(!wxStrcmp(it->name, nextitin))
// 		break;
// 	if(it)
// 	    goto err;
// 	return true;
// }
// 
// 
// bool	Itinerary::IsSelected()
// {
// 	return Deselect(true);
// }
// 
// 
// bool	Itinerary::CanSelect()
// {
//     	Signal	*sig;
//         int     el;
// 	Track   *trk;
// 
// 	sig = findSignalNamed(signame);
// 	if(!sig)
// 	    return false;
// 
// 	Vector	*path;
// 
// 	if(!sig->controls)
// 	    return false;
// 	if(sig->IsClear())
// 	    return false;
// 
//         TurnSwitches();
// 	path = findPath(sig->controls, sig->direction);
//         if(!path) {
//             RestoreSwitches();
// 	    return false;
//         }
// 	int nel = path->_size;
// 	bool failed = false;
// 	// check that every element in the path is clear
// 	for(el = 0; el < nel; ++el) {
// 	    trk = path->TrackAt(el);
//             if(trk->fgcolor != conf.fgcolor) {
//                 failed = true;
//                 break;
// 	    }
// 	}
// 	Vector_delete(path);
//         RestoreSwitches();
// 	return !failed;
// }
// 
// 
// bool	Itinerary::Deselect(bool checkOnly)
// {
// 	Signal	*sig;
// 
// 	sig = findSignalNamed(signame);
// 	if(!sig)
// 	    return false;
// 
// 	Vector	*path;
// 
// 	if(!sig->controls)
// 	    return false;
// 	if(!sig->IsClear())	// maybe a train entered the block or the
// 	    return false;	// path is occupied in the opposite direction
// 
// 	path = findPath(sig->controls, sig->direction);
// 	if(!path)
// 	    return false;
// 	int nel = path->_size;
// 	int el;
// 	Track *trk;
// 	bool failed = false;
// 	// check that every element in the path is still clear
// 	for(el = 0; el < nel; ++el) {
// 	    trk = path->TrackAt(el);
// 	    if(trk->fgcolor != color_green) {
// 		failed = true;
// 		break;
// 	    }
// 	}
// 	if(!failed) {
// 	    // check that every switch is in the right position
// 	    for(el = 0; el < nsects; ++el) {
// 		trk = findSwitch(sw[el].x, sw[el].y);
// 		if(!trk) {
// 		    failed = true;
// 		    break;
// 		}
// 		if(trk->switched != sw[el].switched) {
// 		    failed = true;
// 		    break;
// 		}
// 	    }
// 	}
// 	if(!failed) {
// 	    if(!checkOnly)		// OK to undo the itinerary
// 		toggle_signal(sig);
// 	}
// 
// 	Vector_delete(path);
// 	return !failed;
// }
// 
// 
// 
// static int ByName(const void *pa, const void *pb)
// {
// 	Itinerary   *ia = *(Itinerary **)pa;
// 	Itinerary   *ib = *(Itinerary **)pb;
// 
// 	return wxStricmp(ia->name, ib->name);
// }
// 
// void	sort_itineraries()
// {
// 	Itinerary   **its;
// 	Itinerary   *it;
// 	int	    i, n;
// 
// 	if(!itineraries)
// 	    return;
// 	n = 0;
// 	for(it = itineraries; it; it = it->next)
// 	    ++n;
// 	its = (Itinerary **)malloc(sizeof(Itinerary *) * n);
// 	n = 0;
// 	for(it = itineraries; it; it = it->next)
// 	    its[n++] = it;
// 	qsort(its, n, sizeof(Itinerary *), ByName);
// 	for(i = 0; i < n - 1; ++i)
// 	    its[i]->next = its[i + 1];
// 	its[i]->next = 0;
// 	itineraries = its[0];
// 	free(its);
// }
// 
// //
// //
// //
// //
// 
// 
// #include "tdscript.h"
// 
// class ItinInterpreterData : public InterpreterData {
// public:
// 	ItinInterpreterData()
// 	{
// 	    _onInit = 0;
// 	    _onClick = 0;
// 	}
// 
// 	~ItinInterpreterData()
// 	{
// 	    if(_onInit)
// 		delete _onInit;
// 	    if(_onClick)
// 		delete _onClick;
// 	};
// 
// 	Statement *_onInit;	// list of actions (statements)
// 	Statement *_onClick;
// 
// 	bool	Evaluate(ExprNode *expr, ExprValue& result);
// };
// 
// bool	Itinerary::GetPropertyValue(const wxChar *prop, ExprValue& result)
// {
// 	if(!wxStrcmp(prop, wxT("name"))) {
// 	    result._op = String;
// 	    result._txt = this->name;
// 	    return true;
// 	}
// 	return false;
// }
// 
// 
// void	Itinerary::OnInit()
// {
// 	if(_interpreterData) {
// 	    ItinInterpreterData& interp = *(ItinInterpreterData *)_interpreterData;
// 	    if(interp._onInit) {
// 		interp._itinerary = this;
// 		wxSnprintf(expr_buff, sizeof(expr_buff)/sizeof(wxChar), wxT("Itinerary::OnInit(%s)"), this->name);
// 		Trace(expr_buff);
// 		interp.Execute(interp._onInit);
// 		return;
// 	    }
// 	}
// }
// 
// void	Itinerary::OnClick()
// {
// 	if(_interpreterData) {
// 	    ItinInterpreterData& interp = *(ItinInterpreterData *)_interpreterData;
// 	    if(interp._onClick) {
// 		interp._itinerary = this;
// 		wxSnprintf(expr_buff, sizeof(expr_buff)/sizeof(wxChar), wxT("Itinerary::OnClick(%s)"), this->name);
// 		Trace(expr_buff);
// 		interp.Execute(interp._onClick);
// 		return;
// 	    }
// 	}
// }
