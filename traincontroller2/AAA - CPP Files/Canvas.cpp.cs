// /*	Canvas.cpp - Created by Giampiero Caprino
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
// #include "wx/image.h"
// #include "wx/dcbuffer.h"
// #include "wx/cshelp.h"
// #include "wx/numdlg.h"
// #include "MainFrm.h"
// #include "Canvas.h"
// #include "Traindir3.h"
// #include "TDFile.h"
// 
// #ifdef WIN32
// #define snprintf _snprintf
// #endif
// 
// void	create_colors();
// void	create_draw(wxScrolledWindow *parent);
// static	void	draw_all_pixmap(void);
// 
// extern	void	ShowSignalProperties(Track *sig);
// extern	void	ShowTrackProperties(Track *trk);
// extern	void	ShowTriggerProperties(Track *trk);
// extern	void	ShowTrainInfoDialog(Train *t);
// extern  void	ShowTrackScriptDialog(Track *trk);
// 
// void	coord_paint(const Coord *pCur);
// 
// extern	Coord	move_start, move_end;
// extern	void	move_layout(int x, int y);
// Coord	itin_start;
// 
// extern	wxFileDialog	*gSaveImageFileDialog;
// 
// // ----------------------------------------------------------------------------
// // Canvas
// // ----------------------------------------------------------------------------
// 
// BEGIN_EVENT_TABLE(Canvas, wxScrolledWindow)
//     EVT_PAINT(Canvas::OnPaint)
// //    EVT_MOUSE_EVENTS(Canvas::OnMouse)
//     EVT_MOTION(Canvas::OnMouseMove)
//     EVT_LEFT_DOWN(Canvas::OnMouseLeft)
//     EVT_RIGHT_DOWN(Canvas::OnMouseRight)
//     EVT_LEFT_DCLICK(Canvas::OnMouseDblLeft)
//     EVT_RIGHT_DCLICK(Canvas::OnMouseDblRight)
// 
//     EVT_MENU(MENU_COORD_DEL_1, Canvas::OnCoordDel1)
//     EVT_MENU(MENU_COORD_DEL_N, Canvas::OnCoordDelN)
//     EVT_MENU(MENU_COORD_INS_1, Canvas::OnCoordIns1)
//     EVT_MENU(MENU_COORD_INS_N, Canvas::OnCoordInsN)
// 
//     EVT_CHAR(Canvas::OnChar)
// END_EVENT_TABLE()
// 
// #ifndef WIN32
// wxSimpleHelpProvider	canvasHelp;
// #endif
// 
// Canvas::Canvas(wxWindow* parent)
//         : wxScrolledWindow(parent, wxID_ANY, wxPoint(0, 0),
// 			wxSize(XMAX * 2, YMAX * 2),
//                         wxHSCROLL | wxVSCROLL | wxNO_FULL_REPAINT_ON_RESIZE)
// {
// 	SetScrollbars(1, 1, XMAX, YMAX);
// 	m_layout = 0;
// 	create_colors();
// 	create_draw(this);
// 	init_pmaps();
// 	m_tooltip = 0;
// 	wxToolTip::SetDelay(1000);
// 	wxToolTip::Enable(show_tooltip);
// #ifndef WIN32
// 	wxHelpProvider::Set(&canvasHelp);
// #endif
// }
// 
// Canvas::~Canvas()
// {
// 	wxHelpProvider::Set(0);
// 	delete field_grid;
// 	field_grid = 0;
// }
// 
// void Canvas::OnPaint(wxPaintEvent& event)
// {
// 	if(field_grid)
// 	    field_grid->Paint(this);
// }
// 
// void Canvas::OnEraseBackground(wxEraseEvent& event)
// {
// }
// 
// wxPoint Canvas::GetEventPosition(wxPoint& pt)
// {
// 	double	xScale, yScale;
// 	wxPoint	pos(pt);
// 	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
// 	field_grid->m_dc->GetUserScale(&xScale, &yScale);
// 	pos.x /= xScale;
// 	pos.y /= yScale;
// 	return pos;
// }
// 
// void Canvas::OnMouseMove(wxMouseEvent& event)
// {
// 	wxPoint pos = event.GetPosition();
// 	pos = GetEventPosition(pos);
// 	if(bShowCoord) {
// 	    if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
// 		event.Skip();
// 		return;
// 	    }
// 	    pos.x -= HCOORDBAR;
// 	    pos.y -= VCOORDBAR;
// 	}
// 
// 	Coord	coord(pos.x / HGRID, pos.y / HGRID);
// 
// 	wxChar	oldTooltip[sizeof(tooltipString)/sizeof(tooltipString[0])];
// 	wxStrcpy(oldTooltip, tooltipString);
// 
// 	pointer_at(coord);
// 
// 	if(show_tooltip && wxStrcmp(oldTooltip, tooltipString)) {
// #ifdef WIN32
// 	    wxToolTip *newTip = new wxToolTip(tooltipString);
// 	    SetToolTip(newTip);
// //	    if(m_tooltip)
// //		delete m_tooltip;
// 	    m_tooltip = newTip;
// #else
// 	    canvasHelp.AddHelp(this, tooltipString);
// 	    canvasHelp.ShowHelp(this);
// 	    canvasHelp.RemoveHelp(this);
// #endif
// 	}
// 	if(bShowCoord) {
// 	    coord_paint(&coord);
// 	    draw_all_pixmap();
// 	}
// 	event.Skip();
// }
// 
// void Canvas::OnMouseLeft(wxMouseEvent& event)
// {
// 	wxPoint pos = event.GetPosition();
// 	pos = GetEventPosition(pos);
// 
// 	// Now pos has the absolute position in the canvas
// 
// 	if(bShowCoord) {
// 	    if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
// 		event.Skip();
// 		return;
// 	    }
// 	    pos.x -= HCOORDBAR;
// 	    pos.y -= VCOORDBAR;
// 	}
// 
// 	Coord	coord(pos.x / HGRID, pos.y / HGRID);
// 
// 	if(event.ControlDown()) {
// 	    track_control_selected(coord);
// #if 0
// 	    || event.ShiftDown()) {
// 	    Train   *t = findTrain(pos.x / HGRID, pos.y / VGRID);
// 	    if(t)
// 		ShowTrainInfoDialog(t);
// #endif
// 	    return;
// 	} else if(event.ShiftDown()) {
// 	    if(track_shift_selected(coord))
// 		return;
// 	    itin_start = coord;
// 	    return;
// 	} else if(event.AltDown()) {
// 	}
// 	if(editing) {
// 	    track_place(coord.x, coord.y);
// 	    field_grid->Paint();
// 	    Refresh();
// 	    event.Skip();
// 	    return;
// 	}
// 	wxChar	buff[64];
// 
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("click %d %d"), coord.x, coord.y);
// 	trainsim_cmd(buff);
// 	event.Skip();
// }
// 
// void Canvas::OnMouseRight(wxMouseEvent& event)
// {
// 	wxPoint pos = event.GetPosition();
// 	pos = GetEventPosition(pos);
// 
// 	// Now pos has the absolute position in the canvas
// 
// 	if(bShowCoord) {
// 	    if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
// 		// Show popup menu to insert/delete col/row
// 		CoordMenu(event, pos.x >= HCOORDBAR && pos.y < VCOORDBAR);
// 		event.Skip();
// 		return;
// 	    }
// 	    pos.x -= HCOORDBAR;
// 	    pos.y -= VCOORDBAR;
// 	}
// 
// 	// convert screen coord to cell coord
// 	Coord	coord(pos.x / HGRID, pos.y / VGRID);
// 
// 	if(event.ControlDown()) {
//     	    if(editing) {
//                 Track	*t;
//                 if((t = findTrack(coord.x, coord.y)) || (t = findImage(coord.x, coord.y))) {
//                     ShowTrackScriptDialog(t);
// 	            repaint_all();
// 	            return;
// 	        }
//             }
// 	    track_control_selected(coord);
// 	    return;
// 	} else if(event.ShiftDown()) {
// 	    if(track_shift_selected(coord))
// 		return;
// 	    try_itinerary(itin_start.x, itin_start.y, coord.x, coord.y);
// 	    return;
// 	} else if(event.AltDown()) {
// 	}
// 
// 	if(editing_itinerary) {
// 	    do_itinerary_dialog(coord.x, coord.y);
// 	    event.Skip();
// 	    return;
// 	}
// 	if(editing) {
// 	    track_properties(coord.x, coord.y);
// 	    repaint_all();
// 	    return;
// 	}
// 	wxChar	buff[64];
// 
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("rclick %d %d"), coord.x, coord.y);
// 	trainsim_cmd(buff);
// 	event.Skip();
// }
// 
// void Canvas::OnMouseDblLeft(wxMouseEvent& event)
// {
// 	wxPoint pos = event.GetPosition();
// 	pos = GetEventPosition(pos);
// 	// Now pos has the absolute position in the canvas
// 	event.Skip();
// }
// 
// void Canvas::OnMouseDblRight(wxMouseEvent& event)
// {
// 	wxPoint pos = event.GetPosition();
// 	pos = GetEventPosition(pos);
// 	// Now pos has the absolute position in the canvas
// 	event.Skip();
// }
// 
// bool	bIsVerticalCoord;
// 
// void Canvas::CoordMenu(wxMouseEvent& event, bool verticalCoord)
// {
// 	wxMenu	menu;
// 	wxMenuItem  *item;
// 	wxPoint pt = event.GetPosition();
// 	wxPoint pt1 = GetEventPosition(pt);
// 
// 	bIsVerticalCoord = verticalCoord;
// 	if(verticalCoord) {
// 	    m_xyCoord = (pt1.x - HCOORDBAR) / HGRID;
// 	    item = menu.Append(MENU_COORD_DEL_1, L("Delete Column"), L(""));
// 	    item = menu.Append(MENU_COORD_DEL_N, L("Delete Columns..."), L(""));
// 	    item = menu.Append(MENU_COORD_INS_1, L("Insert Column"), L(""));
// 	    item = menu.Append(MENU_COORD_INS_N, L("Insert Columns..."), L(""));
// 	} else {
// 	    m_xyCoord = (pt1.y - VCOORDBAR) / VGRID;
// 	    item = menu.Append(MENU_COORD_DEL_1, L("Delete Row"), L(""));
// 	    item = menu.Append(MENU_COORD_DEL_N, L("Delete Rows..."), L(""));
// 	    item = menu.Append(MENU_COORD_INS_1, L("Insert Row"), L(""));
// 	    item = menu.Append(MENU_COORD_INS_N, L("Insert Rows..."), L(""));
// 	}
// 
// 	PopupMenu(&menu, pt);
// }
// 
// //
// //
// //
// 
// void	Canvas::OnCoordDel1(wxCommandEvent& event)
// {
// 	if(bIsVerticalCoord) {
// 	    move_start.x = m_xyCoord + 1;
// 	    move_start.y = 0;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(m_xyCoord, 0);
// 	} else {
// 	    move_start.x = 0;
// 	    move_start.y = m_xyCoord + 1;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(0, m_xyCoord);
// 	}
// 	invalidate_field();
// 	repaint_all();
// }
// 
// //
// //
// //
// 
// void	Canvas::OnCoordDelN(wxCommandEvent& event)
// {
// // for some reason wxNumberEntryDialog is not defined on my RHEL3!
// #if !defined(__unix__) && !defined(__WXMAC__)
// 	wxNumberEntryDialog diag(this,
// 	    L("Number of rows/columns to delete?"),
// 	    L("Enter a number:"), L("Delete rows/columns"),
// 	    1, 1, bIsVerticalCoord ? (XNCELLS - m_xyCoord - 1) : (YNCELLS - m_xyCoord - 1));
// 	long	inc;
// 
// 	if(diag.ShowModal() != wxID_OK)
// 	    return;
// 	inc = diag.GetValue();
// 	if(bIsVerticalCoord) {
// 	    move_start.x = m_xyCoord + inc;
// 	    move_start.y = 0;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(m_xyCoord, 0);
// 	} else {
// 	    move_start.x = 0;
// 	    move_start.y = m_xyCoord + inc;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(0, m_xyCoord);
// 	}
// 	invalidate_field();
// 	repaint_all();
// #endif
// }
// 
// //
// //
// //
// 
// void	Canvas::OnCoordIns1(wxCommandEvent& event)
// {
// 	if(bIsVerticalCoord) {
// 	    move_start.x = m_xyCoord;
// 	    move_start.y = 0;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(m_xyCoord + 1, 0);
// 	} else {
// 	    move_start.x = 0;
// 	    move_start.y = m_xyCoord;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(0, m_xyCoord + 1);
// 	}
// 	invalidate_field();
// 	repaint_all();
// }
// 
// //
// //
// //
// 
// void	Canvas::OnCoordInsN(wxCommandEvent& event)
// {
// // for some reason wxNumberEntryDialog is not defined on my RHEL3!
// #if !defined(__unix__) && !defined(__WXMAC__)
// 	wxNumberEntryDialog diag(this,
// 	    L("Number of rows/columns to insert?"),
// 	    L("Enter a number:"), L("Insert rows/columns"),
// 	    1, 1, bIsVerticalCoord ? (XNCELLS - m_xyCoord - 1) : (YNCELLS - m_xyCoord - 1));
// 	long	inc;
// 
// 	if(diag.ShowModal() != wxID_OK)
// 	    return;
// 	inc = diag.GetValue();
// 	if(bIsVerticalCoord) {
// 	    move_start.x = m_xyCoord;
// 	    move_start.y = 0;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(m_xyCoord + inc, 0);
// 	} else {
// 	    move_start.x = 0;
// 	    move_start.y = m_xyCoord;
// 	    move_end.x = XNCELLS;
// 	    move_end.y = YNCELLS;
// 	    move_layout(0, m_xyCoord + inc);
// 	}
// 	invalidate_field();
// 	repaint_all();
// #endif
// }
// 
// //
// //
// //
// 
// void Canvas::OnChar(wxKeyEvent& ev)
// {
// 	int	flags = 0;
// 	int	x, y;
// 
// 	if(ev.ControlDown())
// 	    flags |= 1;
// 	if(ev.ShiftDown())
// 	    flags |= 2;
// 	if(ev.AltDown())
// 	    flags |= 4;
// 
// 	switch(ev.GetKeyCode()) {
// 	case WXK_LEFT:
// 
// 	    if(ev.ControlDown()) {
// 		GetViewStart(&x, &y);
// 		x -= 200;
// 		if(x < 0)
// 		    x = 0;
// 		Scroll(x, y);
// 		break;
// 	    }
// 	    ev.Skip();
// 	    break;
// 
// 	case WXK_RIGHT:
// 
// 	    if(ev.ControlDown()) {
// 		GetViewStart(&x, &y);
// 		x += 200;
// 		if(x < 0)
// 		    x = 0;
// 		Scroll(x, y);
// 		break;
// 	    }
// 	    ev.Skip();
// 	    break;
// 
// 	case WXK_UP:
// 
// 	    if(ev.ControlDown()) {
// 		GetViewStart(&x, &y);
// 		y -= 200;
// 		if(y < 0)
// 		    y = 0;
// 		Scroll(x, y);
// 		break;
// 	    }
// 	    ev.Skip();
// 	    break;
// 
// 	case WXK_DOWN:
// 
// 	    if(ev.ControlDown()) {
// 		GetViewStart(&x, &y);
// 		y += 200;
// 		Scroll(x, y);
// 		break;
// 	    }
// 	    ev.Skip();
// 	    break;
// 
// 	case 0x1b:
// 	    trainsim_cmd(wxT("run"));
// 	    ev.Skip();
// 	    break;
// 
// 	case '7':
// 	    if(ev.ControlDown())
// 		Scroll(0, 0);		// upper left corner
// 	    break;
// 
// 	case '1':
// 	    if(ev.ControlDown())	// lower left corner
// 		Scroll(0, 0);
// 	    break;
// 
// 	case '9':
// 	    if(ev.ControlDown())	// upper right corner
// 		Scroll(0, 0);
// 	    break;
// 
// 	case '3':
// 	    if(ev.ControlDown())	// lower right corner
// 		Scroll(0, 0);
// 	    break;
// 
// 	default:
// 
// 	    ev.Skip();
// 	}
// }
// 
// void Canvas::DoPrint()
// {
// 	if(!gSaveImageFileDialog) {
// 	    gSaveImageFileDialog = new wxFileDialog(traindir->m_frame, L("Save Image"), wxT(""), wxT(""),
// 		wxT("PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|Bitmap file (*.bmp)|*.bmp|GIF image (*.gif)|*.gif|All Files (*.*)|*.*"),
// 		wxSAVE | wxCHANGE_DIR);
// 	}
// 	if(gSaveImageFileDialog->ShowModal() != wxID_OK)
// 	    return;
// 	wxString path = gSaveImageFileDialog->GetPath();
// 	wxRect bounds;
// 	wxBitmap *srcbitmap = field_grid->m_pixmap;
// 	bounds.height = 0;
// 	bounds.width = 0;
// 	bounds.x = srcbitmap->GetWidth();
// 	bounds.y = srcbitmap->GetHeight();
// 	Track *trk;
// 	for(trk = layout; trk; trk = trk->next) {
// 	    if(trk->x * field_grid->m_hmult < bounds.x)
// 		bounds.x = trk->x * field_grid->m_hmult;
// 	    if(trk->y * field_grid->m_vmult < bounds.y)
// 		bounds.y = trk->y * field_grid->m_hmult;
// 	    if((trk->x + 1) * field_grid->m_hmult > bounds.width)
// 		bounds.width = (trk->x + 1) * field_grid->m_hmult;
// 	    if((trk->y + 1) * field_grid->m_vmult > bounds.height)
// 		bounds.height = (trk->y + 1) * field_grid->m_hmult;
// 	}
// 	bounds.width -= bounds.x;
// 	bounds.height -= bounds.y;
// 	// give the image a 2-square border
// 	bounds.x -= field_grid->m_hmult * 2;
// 	if(bounds.x < 0) bounds.x = 0;
// 	bounds.y -= field_grid->m_vmult * 2;
// 	if(bounds.y < 0) bounds.y = 0;
// 	bounds.width += field_grid->m_hmult * 2;
// 	bounds.height += field_grid->m_vmult * 2;
// 	bounds.width += field_grid->m_xBase;
// 	bounds.height += field_grid->m_yBase;
// 	wxBitmap submap = srcbitmap->GetSubBitmap(bounds);
// 	wxBitmapType type = wxBITMAP_TYPE_BMP;
// 	if(wxStrstr(path, wxT(".gif")))
// 	    type = wxBITMAP_TYPE_GIF;
// 	if(wxStrstr(path, wxT(".png")))
// 	    type = wxBITMAP_TYPE_PNG;
// 	if(wxStrstr(path, wxT(".jpg")))
// 	    type = wxBITMAP_TYPE_JPEG;
// 	submap.SaveFile(path, type, NULL);
// }
// 
// 
// /////////////////////////////////////////////////////////////////////////////
// 
// extern	int	ignore_cliprect;
// 
// grid	*current_grid, *field_grid, *tools_grid;
// 
// int	updating_all;
// int	first_time = 1;
// int	show_grid = 0;
// int	ntoolrows = 2;
// bool	bShowCoord = 1;
// 
// int	status_on_top;
// 
// TDSkin	*skin_list;
// TDSkin	*curSkin;
// TDSkin	*defaultSkin;
// 
// 
// TDSkin::TDSkin()
// {
// 	if(!defaultSkin)
// 	    return;
// 	this->next = 0;
// 	this->name = 0;
// 	this->free_track = defaultSkin->free_track;
// 	this->reserved_track = defaultSkin->reserved_track;
// 	this->reserved_shunting = defaultSkin->reserved_shunting;
// 	this->occupied_track = defaultSkin->occupied_track;
// 	this->working_track = defaultSkin->working_track;
// 	this->background = defaultSkin->background;
// 	this->outline = defaultSkin->outline;
// }
// 
// TDSkin::~TDSkin()
// {
// 	if(name)
// 	    free(name);
// 	name = 0;
// }
// 
// unsigned char	colortable[15][3] = {
// 	{ 0, 0, 0 },
// 	{ 255, 255, 255 },
// 	{ 0, 255, 0 },
// 	{ 255, 255, 0 },
// 	{ 255, 0, 0 },
// 	{ 255, 128, 0 },
// 	{ 255, 128, 128 },
// 	{ 128, 128, 128 },
// 	{ 168, 168, 168 }, //	{ 192, 192, 192 },
// 	{ 64, 64, 64 },
// 	{ 0, 0, 255 },	    // blue
// 	{ 0, 255, 255 },    // cyan
//         { 202, 31, 123 },   // magenta
//         { 0, 0, 0, },       // free
// 	{ 0, 0, 0 }	    // [14] : custom color for option colorBg
// };
// 
// void	getcolor_rgb(int col, int *r, int *g, int *b)
// {
// 	if(col < 0 || col > 11)
// 	    return;
// 	*r = colortable[col][0];
// 	*g = colortable[col][1];
// 	*b = colortable[col][2];
// }
// 
// int	getcolor_rgb(int col)
// {
// 	int	c = colortable[col][0] << 16;
// 	c |= colortable[col][1] << 8;
// 	c |= colortable[col][2];
// 	return c;
// }
// 
// void	create_colors(void)
// {
// 	color_black = 0;
// 	color_white = 1;
// 	color_green = 2;
// 	color_yellow = 3;
// 	color_red = 4;
// 	color_orange = 5;
// 	color_brown = 6;
// 	color_gray = 7;
// 	color_lightgray = 8;
// 	color_darkgray = 9;
// 	color_blue = 10;
// 	color_cyan = 11;
//         color_magenta = 12;
// 
// 	fieldcolors[COL_BACKGROUND] = color_lightgray;
// 	fieldcolors[COL_TRACK] = color_black;
// 	fieldcolors[COL_GRAPHBG] = color_lightgray;
// 
// 	fieldcolors[COL_TRAIN1] = color_orange;
// 	fieldcolors[COL_TRAIN2] = color_cyan;
// 	fieldcolors[COL_TRAIN3] = color_blue;
// 	fieldcolors[COL_TRAIN4] = color_yellow;
//         fieldcolors[COL_TRAIN5] = color_white;
//         fieldcolors[COL_TRAIN6] = color_red;
//         fieldcolors[COL_TRAIN7] = color_brown;
//         fieldcolors[COL_TRAIN8] = color_green;
//         fieldcolors[COL_TRAIN9] = color_magenta;
//         fieldcolors[COL_TRAIN10] = color_lightgray;
// 
// 	curSkin = new TDSkin();
// 	curSkin->free_track = getcolor_rgb(color_black);
// 	curSkin->reserved_track = getcolor_rgb(color_green);
// 	curSkin->reserved_shunting = getcolor_rgb(color_white);
// 	curSkin->occupied_track = getcolor_rgb(color_orange);
// 	curSkin->working_track = getcolor_rgb(color_blue);
// 	curSkin->background = getcolor_rgb(color_lightgray);
// 	curSkin->outline = getcolor_rgb(color_darkgray);
// 	curSkin->text = getcolor_rgb(color_black);
// 	curSkin->name = wxStrdup(wxT("default"));
// 	curSkin->next = 0;
// 	skin_list = curSkin;
// 	defaultSkin = curSkin;
// }
// 
// void	set_show_coord(bool opt)
// {
// 	bShowCoord = opt;
// 	if(opt) {
// 	    field_grid->m_xBase = HCOORDBAR;
// 	    field_grid->m_yBase = VCOORDBAR;
// 	} else {
// 	    field_grid->m_xBase = 0;
// 	    field_grid->m_yBase = 0;
// 	}
// }
// 
// void	create_draw(wxScrolledWindow *parent)
// {
// 	grid	*g;
// 
// 	g = new grid(parent, XMAX * 2, YMAX * 2);
// 	g->m_hmult = HGRID;
// 	g->m_vmult = VGRID;
// 	field_grid = g;
// 	current_grid = g;
// 	set_show_coord(true);
// }
// 
// static
// void	draw_all_pixmap(void)
// {
// 	grid	*g;
// 
// 	g = field_grid;
// 	wxClientDC  clientDC(g->m_parent);
// 	wxScrolledWindow *w = (wxScrolledWindow *)g->m_parent;
// 	w->DoPrepareDC(clientDC);
// 	wxBufferedDC	wdc(&clientDC, *g->m_pixmap);
// }
// 
// void	draw_layout_text1(int x, int y, const wxChar *txt, int size)
// {
// 	current_grid->DrawText1(x, y, txt, size);
// }
// 
// void	draw_layout_text_font(int x, int y, const wxChar *txt, int index)
// {
// 	current_grid->DrawTextFont(x, y, txt, index);
// }
// 
// void	draw_text_with_background(int x, int y, const wxChar *txt, int size, int bgcolor)
// {
// 	current_grid->DrawTextWithBackground(x, y, txt, size, bgcolor);
// }
// 
// void	draw_itin_text(int x, int y, const wxChar *txt, int size)
// {
// 	if(current_grid == tools_grid)
// 	    draw_layout_text1(x, y, txt, size);
// 	else
// 	    draw_layout_text1(x + 1, y, txt, size);
// }
// 
// void	update_rectangle_at(int x, int y)
// {
// 	wxRect	update_rect;
// 
// 	if(updating_all)
// 	    return;
// 	//x *= current_grid->m_hmult;
// 	//y *= current_grid->m_vmult;
// 	update_rect.x = x;
// 	update_rect.y = y;
// 	update_rect.width = current_grid->m_hmult;
// 	update_rect.height = current_grid->m_vmult;
// //	gtk_widget_draw(current_grid->drawing_area, &update_rect);
// 	draw_all_pixmap();	// TEMP
// }
// 
// void	tr_fillrect(int x, int y)
// {
// 	current_grid->FillCell(x, y);
// }
// 
// 
// void	clear_field(void)
// {
// 	if(editing)
// 	    invalidate_field();
// 	field_grid->ClearField();
// }
// 
// static
// void	grid_paint()
// {
// 	field_grid->Paint();
// }
// 
// void	coord_paint(const Coord *pCoord)
// {
// 	wxChar	buff[32];
// 	int	i;
// 	grid	*g = field_grid;
// 
// 	wxFont	font(6, wxFONTFAMILY_SWISS, wxNORMAL, wxNORMAL);
// 	g->m_dc->SelectObject(*g->m_pixmap);
// 
// 	// draw background of coord bars
// 	g->m_dc->SetPen(*wxLIGHT_GREY_PEN);
// 	g->m_dc->SetBrush(*wxLIGHT_GREY_BRUSH);
// 	g->m_dc->DrawRectangle(0, 0, XMAX, VCOORDBAR);
// 	g->m_dc->DrawRectangle(0, 0, HCOORDBAR, YMAX);
// 
// 	// draw digits
// 	g->m_dc->SetFont(font);
// 	g->m_dc->SetBackgroundMode(wxSOLID);
// 	g->m_dc->SetTextForeground(*wxBLACK);
// 	g->m_dc->SetTextBackground(*wxLIGHT_GREY);
// 	wxPoint	pt(0, 0);
// 	for(i = 0; i < XNCELLS; ++i) {
// 	    if(pCoord && i == pCoord->x)
// 		g->m_dc->SetTextForeground(*wxWHITE);
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%d"), i / 100);
// 	    pt.x = i * HGRID + HCOORDBAR;
// 	    pt.y = 0;
// 	    g->m_dc->DrawText(buff, pt);
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%d"), (i / 10) % 10);
// 	    pt.y = 8;
// 	    g->m_dc->DrawText(buff, pt);
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%d"), i % 10);
// 	    pt.y = 16;
// 	    g->m_dc->DrawText(buff, pt);
// 	    if(pCoord && i == pCoord->x)
// 		g->m_dc->SetTextForeground(*wxBLACK);
// 	}
// 	for(i = 0; i < YNCELLS; ++i) {
// 	    if(pCoord && i == pCoord->y)
// 		g->m_dc->SetTextForeground(*wxWHITE);
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%3d"), i);
// 	    pt.x = 0;
// 	    pt.y = i * VGRID + VCOORDBAR;
// 	    g->m_dc->DrawText(buff, pt);
// 	    if(pCoord && i == pCoord->y)
// 		g->m_dc->SetTextForeground(*wxBLACK);
// 	}
// 	g->m_dc->SelectObject(wxNullBitmap);
// }
// 
// void	draw_layout(int x0, int y0, VLines *p, grcolor col)
// {
// 	current_grid->DrawLayoutRGB(x0, y0, p, col);
// 	update_rectangle_at(x0, y0);
// }
// 
// void	draw_mid_point(int x0, int y0, int dx, int dy, grcolor col)
// {
// 	current_grid->DrawPoint(x0, y0, dx, dy, col);
// 	update_rectangle_at(x0, y0);
// }
// 
// void	*get_pixmap(const char **pxpm)
// {
// 	wxImage *img = new wxImage(pxpm);
// 	return (void *)img;
// }
// 
// void	delete_pixmap(void *p)
// {
// 	wxImage *img = (wxImage *)p;
// 
// 	if(img)
// 	    delete img;
// }
// 
// void	*get_pixmap_file(const wxChar *fname)
// {
// 	TDFile	xpmFile(fname);
// 
// 	if(!xpmFile.Load())
// 	    return 0;
// 
// 	gLogger.SetExtraInfo(fname);
// 
// 	int	nLines = xpmFile.LineCount();
// 	char	**pattern = (char **)calloc(nLines + 10, sizeof(char *));
// 	int	i, j, k;
// 	wxChar	buff[256];
// 
// 	// collect all strings (delimited by double-quotes)
// 	// from the file and store them in pattern[],
// 	// one string per entry.
// 
// 	for(i = 0; i < nLines; ) {
// 	    if(!xpmFile.ReadLine(buff, sizeof(buff)))
// 		break;
// 	    for(j = 0; buff[j] && buff[j] != '"'; ++j);
// 	    if(!buff[j++])
// 		continue;
// 	    for(k = 0; buff[j] && buff[j] != '"'; buff[k++] = buff[j++]);
// 	    if(!buff[j])
// 		continue;
// 	    buff[k] = 0;
// 	    // we allocate a bit more to allow extending
// 	    // shorter lines during the checking phase
// 	    pattern[i] = (char *)calloc(k + 10, 1);
// #if wxUSE_UNICODE
// 	    wxConvISO8859_1.FromWChar(pattern[i], k + 10, buff, wxNO_LEN);
// #else
// 	    strcpy(pattern[i], buff);
// #endif
// 	    ++i;
// 	}
// 
// 	wxImage	*img = 0;
// 
// 	// now analyze the lines to check if the image is correct
// 
// 	int	nRows, nColumns, nColors, depth, x, y, c;
// 	if(sscanf(pattern[0], "%d %d %d %d", &nColumns, &nRows, &nColors, &depth) != 4) {
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("Error loading '%s' - not a valid XPM file."), fname);
// 	    traindir->layout_error(buff);
// 	    goto done;
// 	}
// 	if(nRows > i - 1 - nColors) {
// 	    char	cbuff[256];
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s: Warning: too many lines in XPM header. Truncated."), fname);
// 	    traindir->layout_error(buff);
// 	    snprintf(cbuff, sizeof(cbuff)/sizeof(char), "%d %d %d %d", nColumns, i - 1 - nColors, nColors, depth);
// 	    free(pattern[0]);
// 	    pattern[0] = strdup(cbuff);
// 	}
// 	for(y = nColors + 1; y < i; ++y) {  // check each pixel row
// 	    for(x = 0; x < nColumns; ++x) {
// 		bool valid = false;
// 		if(!pattern[y][x])
// 		    break;
// 		for(c = 0; c < nColors; ++c) {
// 		    if(pattern[c + 1][0] == pattern[y][x]) {
// 			valid = true;
// 			break;
// 		    }
// 		}
// 		if(!valid) {
// 		    pattern[y][x] = pattern[1][0];  // force first color (hopefully "None")
// 		    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s: Warning: bad color key (y=%d,x=%d). Replaced."), fname, y, x);
// 		    traindir->layout_error(buff);
// 		}
// 	    }
// 	}
// 	try {
// 	    img = new wxImage(pattern);
// 	    if(!img->Ok()) {
// 		wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("Error loading '%s'"), fname);
// 		traindir->layout_error(buff);
// 		delete img;
// 		img = 0;
// 	    }
// 	} catch(...) {
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("Error loading '%s' - not a valid XPM file."), fname);
// 	    traindir->layout_error(buff);
// 	}
// done:
// 	for(i = 0; pattern[i]; ++i)
// 	    free(pattern[i]);
// 	free(pattern);
// 	return (void *)img;
// }
// 
// void	draw_pixmap(int x0, int y0, void *map)
// {
// 	wxImage	*img = (wxImage *)map;
// 	wxRect update_rect;
// 	grid	*g = current_grid;
// 	int	x = x0 * g->m_hmult + g->m_xBase;
// 	int	y = y0 * g->m_vmult + g->m_yBase;
// 
// 	if(!img->Ok())
// 	    return;
// 	if(!g->m_pixmap)
// 	    return;
// 	if(!g->m_dc)
// 	    g->m_dc = new wxMemoryDC;
// 	if(g == tools_grid && y0 && x0 < 8) {
// 	    x += tools_grid->m_hmult / 2;
// 	    y += tools_grid->m_vmult / 2;
// 	}
// 	wxBitmap bitmap(*img, -1);
// 	g->m_dc->SelectObject(*g->m_pixmap);
// 	g->m_dc->DrawBitmap(bitmap, x, y, true);
// 	g->m_dc->SelectObject(wxNullBitmap);
// 	if(updating_all)
// 	    return;
// 	update_rect.x = x;
// 	update_rect.y = y;
// 	update_rect.width = 16 * g->m_hmult;
// 	update_rect.height = 11 * g->m_vmult;
// }
// 
// void	get_pixmap_size(void *map, Coord& sz)
// {
// 	wxImage	*img = (wxImage *)map;
// 	sz.x = img->GetWidth();
// 	sz.y = img->GetHeight();
// }
// 
// void	get_text_size(const wxChar *txt, Coord& sz)
// {
//         field_grid->GetTextExtent(txt, 0, sz);
// }
// 
// void	draw_link(int x0, int y0, int x1, int y1, int color)
// {
// 	field_grid->DrawLineCenterCell(x0, y0, x1, y1, color);
// }
// 
// int	ask(const wxChar *msg)
// {
// 	int	res;
// 
// 	res = wxMessageBox(LV(msg), L("Question"),
// 	    wxYES_DEFAULT|wxYES_NO|wxICON_QUESTION, traindir->m_frame);
// 	if(res == wxYES)
// 	    return ANSWER_YES;
// 	return ANSWER_NO;
// }
// 
// void	new_status_position()
// {
// }
// 
// void	create_train(void)
// {
// }
// 
// //	update_button
// //	called to update the start/stop state of UI's buttons.
// void	update_button(const wxChar *cmd, const wxChar *lbltxt)
// {
// 	traindir->m_frame->m_running->SetLabel(lbltxt);
// 	if(running)
// 	    traindir->m_frame->m_running->SetValue(true);
// 	else
// 	    traindir->m_frame->m_running->SetValue(false);
// }
// 
// int	create_schedule(int assign)
// {
// 	return 0;
// }
// 
// int	cont(const wxChar *msg)
// {
// 	if(wxMessageBox(LV(msg), L("Question"),
// 	    wxYES_DEFAULT|wxYES_NO|wxICON_QUESTION, traindir->m_frame) == wxYES)
// 	    return ANSWER_YES;
// 	return ANSWER_NO;
// }
// 
// void	create_path_window(void)
// {
// }
// 
// void	main_quit_cmd(void)
// {
// }
// 
// void	make_timer(int msec)
// {
// 	traindir->SetTimeSlice(msec / 100);  // each time slice is 100ms
// }
// 
// void	repaint_all()
// {
// 	current_grid = field_grid;
// 	if(!editing && cliprect.top > cliprect.bottom)
// 	    return; /* no changes since last update */
// 	if(ignore_cliprect || editing)
// 	    clear_field();
// 	updating_all = 1;
// 	if(show_grid)
// 	    grid_paint();
// 	if(bShowCoord)
// 	    coord_paint(0);
// 	layout_paint(layout);
// 	trains_paint(stranded);
// 	trains_paint(schedule);
// 	updating_all = 0;
// 	draw_all_pixmap();
// 	reset_clip_rect();
// }
// 
// void	set_zoom(bool zooming)
// {
// 	grid	*g = field_grid;
// 	wxScrolledWindow *w = (wxScrolledWindow *)g->m_parent;
// 
// 	if(zooming) {
// 	    g->m_dc->SetUserScale(2.0, 2.0);
// 	    w->SetScrollbars(1, 1, XMAX * 2, YMAX * 2);
// 	} else {
// 	    g->m_dc->SetUserScale(1.0, 1.0);
// 	    w->SetScrollbars(1, 1, XMAX, YMAX);
// 	}
// 	invalidate_field();
// 	repaint_all();
// }
// 
// 
