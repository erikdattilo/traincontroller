using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  class Canvas : ScrolledWindow {
    public TDLayout m_layout;
    public int m_xyCoord;
    public ToolTip m_tooltip;

    public Canvas(Window parent) :
      base(parent, (int)MenuIDs2.wxID_ANY, new Point(0, 0),
           new Size(Configuration.XMAX * 2, Configuration.YMAX * 2),
       WindowStyles.HSCROLL | WindowStyles.VSCROLL | WindowStyles.NO_FULL_REPAINT_ON_RESIZE) {

      EVT_PAINT(OnPaint);
      EVT_MOTION(new EventListener(OnMouseMove));
      EVT_LEFT_DOWN(new EventListener(OnMouseLeft));
      EVT_RIGHT_DOWN(new EventListener(OnMouseRight));
      EVT_LEFT_DCLICK(new EventListener(OnMouseDblLeft));
      EVT_RIGHT_DCLICK(new EventListener(OnMouseDblRight));

      EVT_MENU((int)MenuIDs.MENU_COORD_DEL_1, new EventListener(OnCoordDel1));
      EVT_MENU((int)MenuIDs.MENU_COORD_DEL_N, new EventListener(OnCoordDelN));
      EVT_MENU((int)MenuIDs.MENU_COORD_INS_1, new EventListener(OnCoordIns1));
      EVT_MENU((int)MenuIDs.MENU_COORD_INS_N, new EventListener(OnCoordInsN));

      EVT_CHAR(OnChar);


      SetScrollbars(1, 1, Configuration.XMAX, Configuration.YMAX);


      m_layout = null;
      GlobalFunctions.create_colors();
      GlobalFunctions.create_draw(this);
      GlobalFunctions.init_pmaps();
      m_tooltip = null;
      // ToolTip.SetDelay(1000);
      // ToolTip.Enable(show_tooltip);
      // #if WIN32
      // #else
      // HelpProvider.Set(canvasHelp);
      // #endif
    }

    ~Canvas() {
      // HelpProvider::Set(0);
      // delete field_grid;
      // field_grid = 0;
    }

    public static void repaint_all() {
      GlobalVariables.current_grid = GlobalVariables.field_grid;
      if(!GlobalVariables.editing && GlobalVariables.cliprect.top > GlobalVariables.cliprect.bottom)
        return; /* no changes since last update */
      if(GlobalVariables.ignore_cliprect || GlobalVariables.editing)
        GlobalFunctions.clear_field();
      GlobalVariables.updating_all = true;
      if(GlobalVariables.show_grid)
        GlobalFunctions.grid_paint();
      if(GlobalVariables.bShowCoord)
        GlobalFunctions.coord_paint(null);
      GlobalFunctions.layout_paint(GlobalVariables.layout);
      GlobalFunctions.trains_paint(GlobalVariables.stranded);
      GlobalFunctions.trains_paint(GlobalVariables.schedule);
      GlobalVariables.updating_all = false;
      GlobalFunctions.draw_all_pixmap();
      GlobalFunctions.reset_clip_rect();
    }


    public void OnPaint(object sender, Event evt) {
      if(GlobalVariables.field_grid != null)
        GlobalVariables.field_grid.Paint(this);
    }

    public void OnEraseBackground(object sender, Event evt) {
    }

    Point GetEventPosition(Point pt) {
      double xScale, yScale;
      Point pos = new Point(pt.X, pt.Y);
      //CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      //GlobalVariables.field_grid.m_dc.GetUserScale(&xScale, &yScale);
      //pos.x /= xScale;
      //pos.y /= yScale;
      return pos;
    }

    public void OnMouseMove(object sender, Event evt)
    {
    //  Point pos = evt.Position;
    //  pos = GetEventPosition(pos);
    //  if(bShowCoord) {
    //      if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
    //    evt.Skip();
    //    return;
    //      }
    //      pos.x -= HCOORDBAR;
    //      pos.y -= VCOORDBAR;
    //  }

    //  Coord	coord(pos.x / HGRID, pos.y / HGRID);

    //  wxChar	oldTooltip[sizeof(tooltipString)/sizeof(tooltipString[0])];
    //  wxStrcpy(oldTooltip, tooltipString);

    //  pointer_at(coord);

    //  if(show_tooltip && wxStrcmp(oldTooltip, tooltipString)) {
    //// Erik #ifdef WIN32
    //      wxToolTip *newTip = new wxToolTip(tooltipString);
    //      SetToolTip(newTip);
    ////	    if(m_tooltip)
    ////		delete m_tooltip;
    //      m_tooltip = newTip;
    //// Erik #else
    //      canvasHelp.AddHelp(this, tooltipString);
    //      canvasHelp.ShowHelp(this);
    //      canvasHelp.RemoveHelp(this);
    //// Erik #endif
    //  }
    //  if(bShowCoord) {
    //      coord_paint(&coord);
    //      draw_all_pixmap();
    //  }
    //  evt.Skip();
    }

    public void OnMouseLeft(object sender, Event evt) {
      //  Point pos = evt.Position;
      //  pos = GetEventPosition(pos);

      //  // Now pos has the absolute position in the canvas

      //  if(bShowCoord) {
      //      if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
      //    evt.Skip();
      //    return;
      //      }
      //      pos.x -= HCOORDBAR;
      //      pos.y -= VCOORDBAR;
      //  }

      //  Coord	coord = new Coord(pos.x / HGRID, pos.y / HGRID);

      //  if(evt.ControlDown()) {
      //      track_control_selected(coord);
      //// Erik #if 0
      //      || evt.ShiftDown()) {
      //      Train   *t = findTrain(pos.x / HGRID, pos.y / VGRID);
      //      if(t)
      //    ShowTrainInfoDialog(t);
      //// Erik #endif
      //      return;
      //  } else if(evt.ShiftDown()) {
      //      if(track_shift_selected(coord))
      //    return;
      //      itin_start = coord;
      //      return;
      //  } else if(evt.AltDown()) {
      //  }
      //  if(editing) {
      //      track_place(coord.x, coord.y);
      //      field_grid.Paint();
      //      Refresh();
      //      evt.Skip();
      //      return;
      //  }
      //  string buff = String.Format(wxPorting.T("click %d %d"), coord.x, coord.y);
      //  trainsim_cmd(buff);
      //  evt.Skip();
    }

    public void OnMouseRight(object sender, Event evt) {
      //Point pos = evt.Position;
      //pos = GetEventPosition(pos);

      //// Now pos has the absolute position in the canvas

      //if(bShowCoord) {
      //    if(pos.x < HCOORDBAR || pos.y < VCOORDBAR) {
      //  // Show popup menu to insert/delete col/row
      //  CoordMenu(evt, pos.x >= HCOORDBAR && pos.y < VCOORDBAR);
      //  evt.Skip();
      //  return;
      //    }
      //    pos.x -= HCOORDBAR;
      //    pos.y -= VCOORDBAR;
      //}

      //// convert screen coord to cell coord
      //Coord	coord(pos.x / HGRID, pos.y / VGRID);

      //if(evt.ControlDown()) {
      //        if(editing) {
      //              Track	*t;
      //              if((t = findTrack(coord.x, coord.y)) || (t = findImage(coord.x, coord.y))) {
      //                  ShowTrackScriptDialog(t);
      //            repaint_all();
      //            return;
      //        }
      //          }
      //    track_control_selected(coord);
      //    return;
      //} else if(evt.ShiftDown()) {
      //    if(track_shift_selected(coord))
      //  return;
      //    try_itinerary(itin_start.x, itin_start.y, coord.x, coord.y);
      //    return;
      //} else if(evt.AltDown()) {
      //}

      //if(editing_itinerary) {
      //    do_itinerary_dialog(coord.x, coord.y);
      //    evt.Skip();
      //    return;
      //}
      //if(editing) {
      //    track_properties(coord.x, coord.y);
      //    repaint_all();
      //    return;
      //}
      //wxChar	buff[64];

      //wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxPorting.T("rclick %d %d"), coord.x, coord.y);
      //trainsim_cmd(buff);
      //evt.Skip();
    }

    public void OnMouseDblLeft(object sender, Event evt) {
      //Point pos = evt.Position;
      //pos = GetEventPosition(pos);
      //// Now pos has the absolute position in the canvas
      //evt.Skip();
    }

    public void OnMouseDblRight(object sender, Event evt) {
      //Point pos = evt.Position;
      //pos = GetEventPosition(pos);
      //// Now pos has the absolute position in the canvas
      //evt.Skip();
    }
#if false
    bool	bIsVerticalCoord;

    void CoordMenu(object sender, Event evt, bool verticalCoord)
    {
      wxMenu	menu;
      wxMenuItem  *item;
      wxPoint pt = evt.GetPosition();
      wxPoint pt1 = GetEventPosition(pt);

      bIsVerticalCoord = verticalCoord;
      if(verticalCoord) {
          m_xyCoord = (pt1.x - HCOORDBAR) / HGRID;
          item = menu.Append(MENU_COORD_DEL_1, wxPorting.L("Delete Column"), wxPorting.L(""));
          item = menu.Append(MENU_COORD_DEL_N, wxPorting.L("Delete Columns..."), wxPorting.L(""));
          item = menu.Append(MENU_COORD_INS_1, wxPorting.L("Insert Column"), wxPorting.L(""));
          item = menu.Append(MENU_COORD_INS_N, wxPorting.L("Insert Columns..."), wxPorting.L(""));
      } else {
          m_xyCoord = (pt1.y - VCOORDBAR) / VGRID;
          item = menu.Append(MENU_COORD_DEL_1, wxPorting.L("Delete Row"), wxPorting.L(""));
          item = menu.Append(MENU_COORD_DEL_N, wxPorting.L("Delete Rows..."), wxPorting.L(""));
          item = menu.Append(MENU_COORD_INS_1, wxPorting.L("Insert Row"), wxPorting.L(""));
          item = menu.Append(MENU_COORD_INS_N, wxPorting.L("Insert Rows..."), wxPorting.L(""));
      }

      PopupMenu(&menu, pt);
    }
#endif
    //
    //
    //

    void OnCoordDel1(object sender, Event evt) {
      //if(bIsVerticalCoord) {
      //    move_start.x = m_xyCoord + 1;
      //    move_start.y = 0;
      //    move_end.x = XNCELLS;
      //    move_end.y = YNCELLS;
      //    move_layout(m_xyCoord, 0);
      //} else {
      //    move_start.x = 0;
      //    move_start.y = m_xyCoord + 1;
      //    move_end.x = XNCELLS;
      //    move_end.y = YNCELLS;
      //    move_layout(0, m_xyCoord);
      //}
      //invalidate_field();
      //repaint_all();
    }

    //
    //
    //

    void OnCoordDelN(object sender, Event evt) {
      //// for some reason wxNumberEntryDialog is not defined on my RHEL3!
      //// Erik #if !defined(__unix__) && !defined(__WXMAC__)
      //  wxNumberEntryDialog diag(this,
      //      wxPorting.L("Number of rows/columns to delete?"),
      //      wxPorting.L("Enter a number:"), wxPorting.L("Delete rows/columns"),
      //      1, 1, bIsVerticalCoord ? (XNCELLS - m_xyCoord - 1) : (YNCELLS - m_xyCoord - 1));
      //  long	inc;

      //  if(diag.ShowModal() != wxID_OK)
      //      return;
      //  inc = diag.GetValue();
      //  if(bIsVerticalCoord) {
      //      move_start.x = m_xyCoord + inc;
      //      move_start.y = 0;
      //      move_end.x = XNCELLS;
      //      move_end.y = YNCELLS;
      //      move_layout(m_xyCoord, 0);
      //  } else {
      //      move_start.x = 0;
      //      move_start.y = m_xyCoord + inc;
      //      move_end.x = XNCELLS;
      //      move_end.y = YNCELLS;
      //      move_layout(0, m_xyCoord);
      //  }
      //  invalidate_field();
      //  repaint_all();
      //// Erik #endif
    }

    //
    //
    //

    void OnCoordIns1(object sender, Event evt) {
      //if(bIsVerticalCoord) {
      //    move_start.x = m_xyCoord;
      //    move_start.y = 0;
      //    move_end.x = XNCELLS;
      //    move_end.y = YNCELLS;
      //    move_layout(m_xyCoord + 1, 0);
      //} else {
      //    move_start.x = 0;
      //    move_start.y = m_xyCoord;
      //    move_end.x = XNCELLS;
      //    move_end.y = YNCELLS;
      //    move_layout(0, m_xyCoord + 1);
      //}
      //invalidate_field();
      //repaint_all();
    }

    //
    //
    //

    void OnCoordInsN(object sender, Event evt) {
      //// for some reason wxNumberEntryDialog is not defined on my RHEL3!
      //// Erik #if !defined(__unix__) && !defined(__WXMAC__)
      //  wxNumberEntryDialog diag(this,
      //      wxPorting.L("Number of rows/columns to insert?"),
      //      wxPorting.L("Enter a number:"), wxPorting.L("Insert rows/columns"),
      //      1, 1, bIsVerticalCoord ? (XNCELLS - m_xyCoord - 1) : (YNCELLS - m_xyCoord - 1));
      //  long	inc;

      //  if(diag.ShowModal() != wxID_OK)
      //      return;
      //  inc = diag.GetValue();
      //  if(bIsVerticalCoord) {
      //      move_start.x = m_xyCoord;
      //      move_start.y = 0;
      //      move_end.x = XNCELLS;
      //      move_end.y = YNCELLS;
      //      move_layout(m_xyCoord + inc, 0);
      //  } else {
      //      move_start.x = 0;
      //      move_start.y = m_xyCoord;
      //      move_end.x = XNCELLS;
      //      move_end.y = YNCELLS;
      //      move_layout(0, m_xyCoord + inc);
      //  }
      //  invalidate_field();
      //  repaint_all();
      //// Erik #endif
    }

    //
    //
    //

    public void OnChar(object sender, Event evt) {
      //int	flags = 0;
      //int	x, y;

      //if(ev.ControlDown())
      //    flags |= 1;
      //if(ev.ShiftDown())
      //    flags |= 2;
      //if(ev.AltDown())
      //    flags |= 4;

      //switch(ev.GetKeyCode()) {
      //case WXK_LEFT:

      //    if(ev.ControlDown()) {
      //  GetViewStart(&x, &y);
      //  x -= 200;
      //  if(x < 0)
      //      x = 0;
      //  Scroll(x, y);
      //  break;
      //    }
      //    ev.Skip();
      //    break;

      //case WXK_RIGHT:

      //    if(ev.ControlDown()) {
      //  GetViewStart(&x, &y);
      //  x += 200;
      //  if(x < 0)
      //      x = 0;
      //  Scroll(x, y);
      //  break;
      //    }
      //    ev.Skip();
      //    break;

      //case WXK_UP:

      //    if(ev.ControlDown()) {
      //  GetViewStart(&x, &y);
      //  y -= 200;
      //  if(y < 0)
      //      y = 0;
      //  Scroll(x, y);
      //  break;
      //    }
      //    ev.Skip();
      //    break;

      //case WXK_DOWN:

      //    if(ev.ControlDown()) {
      //  GetViewStart(&x, &y);
      //  y += 200;
      //  Scroll(x, y);
      //  break;
      //    }
      //    ev.Skip();
      //    break;

      //case 0x1b:
      //    trainsim_cmd(wxPorting.T("run"));
      //    ev.Skip();
      //    break;

      //case '7':
      //    if(ev.ControlDown())
      //  Scroll(0, 0);		// upper left corner
      //    break;

      //case '1':
      //    if(ev.ControlDown())	// lower left corner
      //  Scroll(0, 0);
      //    break;

      //case '9':
      //    if(ev.ControlDown())	// upper right corner
      //  Scroll(0, 0);
      //    break;

      //case '3':
      //    if(ev.ControlDown())	// lower right corner
      //  Scroll(0, 0);
      //    break;

      //default:

      //    ev.Skip();
      //}
    }
#if false
    void DoPrint()
    {
      if(!gSaveImageFileDialog) {
          gSaveImageFileDialog = new wxFileDialog(traindir.m_frame, wxPorting.L("Save Image"), wxPorting.T(""), wxPorting.T(""),
        wxPorting.T("PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|Bitmap file (*.bmp)|*.bmp|GIF image (*.gif)|*.gif|All Files (*.*)|*.*"),
        wxSAVE | wxCHANGE_DIR);
      }
      if(gSaveImageFileDialog.ShowModal() != wxID_OK)
          return;
      wxString path = gSaveImageFileDialog.GetPath();
      wxRect bounds;
      wxBitmap *srcbitmap = field_grid.m_pixmap;
      bounds.height = 0;
      bounds.width = 0;
      bounds.x = srcbitmap.GetWidth();
      bounds.y = srcbitmap.GetHeight();
      Track *trk;
      for(trk = layout; trk; trk = trk.next) {
          if(trk.x * field_grid.m_hmult < bounds.x)
        bounds.x = trk.x * field_grid.m_hmult;
          if(trk.y * field_grid.m_vmult < bounds.y)
        bounds.y = trk.y * field_grid.m_hmult;
          if((trk.x + 1) * field_grid.m_hmult > bounds.width)
        bounds.width = (trk.x + 1) * field_grid.m_hmult;
          if((trk.y + 1) * field_grid.m_vmult > bounds.height)
        bounds.height = (trk.y + 1) * field_grid.m_hmult;
      }
      bounds.width -= bounds.x;
      bounds.height -= bounds.y;
      // give the image a 2-square border
      bounds.x -= field_grid.m_hmult * 2;
      if(bounds.x < 0) bounds.x = 0;
      bounds.y -= field_grid.m_vmult * 2;
      if(bounds.y < 0) bounds.y = 0;
      bounds.width += field_grid.m_hmult * 2;
      bounds.height += field_grid.m_vmult * 2;
      bounds.width += field_grid.m_xBase;
      bounds.height += field_grid.m_yBase;
      wxBitmap submap = srcbitmap.GetSubBitmap(bounds);
      wxBitmapType type = wxBITMAP_TYPE_BMP;
      if(wxStrstr(path, wxPorting.T(".gif")))
          type = wxBITMAP_TYPE_GIF;
      if(wxStrstr(path, wxPorting.T(".png")))
          type = wxBITMAP_TYPE_PNG;
      if(wxStrstr(path, wxPorting.T(".jpg")))
          type = wxBITMAP_TYPE_JPEG;
      submap.SaveFile(path, type, NULL);
    }
#endif
  }
}
