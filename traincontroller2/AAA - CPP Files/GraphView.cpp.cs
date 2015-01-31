// /*	tgraph.cpp - Created by Giampiero Caprino
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
// #include <stdlib.h>
// 
// #if !defined(__unix__) && !defined(__WXMAC__)
// #include <malloc.h>
// #endif
// 
// #include "wx/wx.h"
// #include "wx/image.h"
// #include "wx/dcbuffer.h"
// 
// #include "trsim.h"
// #include "Canvas.h"
// #include "Traindir3.h"
// #include "GraphView.h"
// 
// #define	STATION_WIDTH 100
// #define	KM_WIDTH 50
// #define	HEADER_HEIGHT 20
// #define	MAXWIDTH (4 * 60 * 24 + STATION_WIDTH + KM_WIDTH)
// 
// extern	Track	*layout;
// extern	int	is_windows;
// 
// static	Track	*stations[60];
// static	int	nstations;
// 
// static	grid	*tgraph_grid;
// static	int	highkm;
// 
// BEGIN_EVENT_TABLE(GraphView, wxScrolledWindow)
//     EVT_PAINT(GraphView::OnPaint)
// END_EVENT_TABLE()
// 
// static	void	DrawTimeGrid(grid *g, int y)
// {
// 	int	h, m;
// 	int	x;
// 	wxChar	buff[20];
// 
// 	x = STATION_WIDTH + KM_WIDTH;
// 	for(h = 0; h < 24; ++h)
// 	    for(m = 0; m < 60; ++m) {
// 		if((m % 10)) {
// 		    g->DrawLine(
// 			x + h * 240 + m * 4, y - 2,
// 			x + h * 240 + m * 4, y + 2,
// 			0);
// 		} else {
// 		    g->DrawLine(
// 			x + h * 240 + m * 4, 20,
// 			x + h * 240 + m * 4, 1000,
// 			m ? 1 : 0);
// 		}
// 	    }
// 
// 	for(h = 0; h < 24; ++h) {
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%2d:00"), h);
// 	    g->DrawText1(x + h * 240, 10, buff, 0);
// 	}
// }
// 
// static	int	km_to_y(int km)
// {
// 	int	y;
// 
// 	y = HEADER_HEIGHT + (double)km / (double)highkm * 960;
// 	return y;
// }
// 
// static	int	islinkedtext(Track *t)
// {
// 	if(t->elinkx && t->elinky)
// 	    return 1;
// 	if(t->wlinkx && t->wlinky)
// 	    return 1;
// 	return 0;
// }
// 
// void	GraphView::DrawStations(grid *g)
// {
// 	Track	*t;
// 	int	y;
// 	wxChar	*p;
// 	wxChar	buff[64];
// 
// 	nstations = 0;
// 	highkm = 0;
// 	for(t = layout; t; t = t->next) {
// 	    if(t->type == TEXT) {
// 		if(!islinkedtext(t))
// 		    continue;
// 		if(t->km > highkm)
// 		    highkm = t->km;
// 		continue;
// 	    }
// 	    if(!t->isstation || !t->station || !t->km)
// 		continue;
// 	    if(t->km > highkm)
// 		highkm = t->km;
// 	}
// 	for(t = layout; t; t = t->next) {
// 	    if(t->type == TEXT) {
// 		if(!t->km || !islinkedtext(t))
// 		    continue;
// 	    } else if(!t->isstation || !t->station || !t->km)
// 		continue;
// 	    stations[nstations++] = t;
// 	    y = km_to_y(t->km);
// 	    DrawTimeGrid(g, y);
// 
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%3d.%d %s"), t->km / 1000, (t->km / 100) % 10,
// 								t->station);
// 	    if((p = wxStrchr(buff, '@')))
// 		*p = 0;
// 	    g->DrawText1(0, y, buff, 0);
// 	}
// 	if(!nstations) {
// 	    g->DrawText1(10, 10, L("Sorry, this feature is not available on this scenario."), 0);
// 	    g->DrawText1(10, 25, L("No station has distance information."), 0);
// 	}
// }
// 
// static	int	graphstation(const wxChar *st)
// {
// 	int	i;
// 
// 	for(i = 0; i < nstations; ++i)
// 	    if(sameStation(st, stations[i]->station))
// 		return i;
// 	return -1;
// }
// 
// static	void	graph_xy(long km, long tim, int *x, int *y)
// {
// 	*x = tim / 60 * 4 + STATION_WIDTH + KM_WIDTH;
// 	*y = km_to_y(km);
// }
// 
// static	void	time_to_time(grid *g, int x, int y, int nx, int ny, int type)
// {
// 	int	color = COL_TRAIN1 + type;
// 
// 	if(nx < x)	/* ignore if arrival is next day */
// 	    return;
// //	gc = tgraph_grid->gc /*drawing_area->style->black_gc*/;
// 	if(ny < y) {	/* going from bottom of graph to top */
// 	    g->DrawLine(x, y - 5, nx, ny + 5, color);
// 	    g->DrawLine(x, y, x, y - 5, color);
// 	    g->DrawLine(nx, ny + 5, nx, ny, color);
// 	} else {	/* going from top of graph to bottom */
// 	    g->DrawLine(x, y + 5, nx, ny - 5, color);
// 	    g->DrawLine(x, y, x, y + 5, color);
// 	    g->DrawLine(nx, ny - 5, nx, ny, color);
// 	}
// }
// 
// static	int	samestation(const wxChar *st, const wxChar *arrdep)
// {
// 	wxChar	buff[256];
// 	int	i;
// 
// 	for(i = 0; *arrdep && *arrdep != ' '; buff[i++] = *arrdep++);
// 	buff[i] = 0;
// 	return(sameStation(st, buff));
// }
// 
// void	GraphView::DrawTrains(grid *g)
// {
// 	Train	*t;
// 	TrainStop *ts;
// 	Track	*trk;
// 	int	indx;
// 	int	x, y;
// 	int	nx, ny;
// 
// 	for(t = schedule; t; t = t->next) {
// //	    gc = tgraph_grid->gc;
// //	    gdk_rgb_gc_set_foreground(gc,
// //		(colortable[fieldcolors[COL_TRAIN1+t->type]][0] << 16) |
// //		(colortable[fieldcolors[COL_TRAIN1+t->type]][1] << 8) |
// //		(colortable[fieldcolors[COL_TRAIN1+t->type]][2]));
// 	    x = y = -1;
// 	    for(trk = layout; trk; trk = trk->next) {
// 		if(trk->type == TRACK && trk->isstation &&
// 					samestation(trk->station, t->entrance))
// 		    break;
// 		if(trk->type == TEXT && islinkedtext(trk) && trk->km > 0 &&
// 					samestation(trk->station, t->entrance))
// 		    break;
// 	    }
// 	    if(trk && (indx = graphstation(trk->station)) >= 0)
// 		graph_xy(stations[indx]->km, t->timein, &x, &y);
// 	    for(ts = t->stops; ts; ts = ts->next) {
// 		indx = graphstation(ts->station);
// 		if(indx < 0)
// 		    continue;
// 		if(x == -1) {
// 		    graph_xy(stations[indx]->km, ts->departure, &x, &y);
// 		    continue;
// 		}
// 		graph_xy(stations[indx]->km, ts->arrival, &nx, &ny);
// 		time_to_time(g, x, y, nx, ny, t->type);
// 		graph_xy(stations[indx]->km, ts->departure, &x, &y);
// 	    }
// 	    if(x != -1) {
// 		for(trk = layout; trk; trk = trk->next) {
// 		    if(trk->type == TRACK && trk->isstation &&
// 					samestation(trk->station, t->exit))
// 			break;
// 		    if(trk->type == TEXT && islinkedtext(trk) && trk->km > 0 &&
// 					samestation(trk->station, t->exit))
// 			break;
// 		}
// 		if(!trk)
// 		    continue;
// 		indx = graphstation(trk->station);
// 		if(indx < 0)
// 		    continue;
// 		graph_xy(stations[indx]->km, t->timeout, &nx, &ny);
// 		time_to_time(g, x, y, nx, ny, t->type);
// 	    }
// 	}
// }
// 
// GraphView::GraphView(wxWindow *parent)
// 	: wxScrolledWindow(parent, wxID_ANY, wxPoint(0, 0), wxSize(XMAX * 4 + STATION_WIDTH + KM_WIDTH, YMAX))
// {
// 	SetScrollbars(1, 1, XMAX * 4 + STATION_WIDTH + KM_WIDTH, YMAX);
// 	grid	*g = new grid(this, XMAX * 4 + STATION_WIDTH + KM_WIDTH, YMAX);
// 	tgraph_grid = g;
// 	g->Clear();
// }
// 
// void	GraphView::Refresh()
// {
// 	grid	*g = tgraph_grid;
// 
// 	g->Clear();
// 	DrawStations(g);
// 	DrawTrains(g);
// 	wxScrolledWindow::Refresh();
// }
// 
// void	GraphView::OnPaint(wxPaintEvent& event)
// {
// 	if(tgraph_grid)
// 	    tgraph_grid->Paint(this);
// }
// 
