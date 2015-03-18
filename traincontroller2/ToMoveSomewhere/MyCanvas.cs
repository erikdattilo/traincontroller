using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace TrainController {

  public class MyCanvas : PictureBox {


    public TDLayout m_layout;

    //    public int m_xyCoord;

    //    public ToolTip m_tooltip;

    public MyCanvas() // Window parent)
      // : base(parent, wxID_ANY, new Point(0, 0),
      // new Size(Configuration.XMAX * 2, Configuration.YMAX * 2),
      // WindowStyles.HSCROLL | WindowStyles.VSCROLL | WindowStyles.NO_FULL_REPAINT_ON_RESIZE)
    {
    }

    public void Init() {
      //      EVT_PAINT(new wx.EventListener(OnPaint));
      //      //      //    EVT_MOUSE_EVENTS(new wx.EventListener(OnMouse));
      //      //      EVT_MOTION(new wx.EventListener(OnMouseMove));
      //      //      EVT_LEFT_DOWN(new wx.EventListener(OnMouseLeft));
      //      //      EVT_RIGHT_DOWN(new wx.EventListener(OnMouseRight));
      //      //      EVT_LEFT_DCLICK(new wx.EventListener(OnMouseDblLeft));
      //      //      EVT_RIGHT_DCLICK(new wx.EventListener(OnMouseDblRight));

      //      //      EVT_MENU(MenuIDs.MENU_COORD_DEL_1, new wx.EventListener(OnCoordDel1));
      //      //      EVT_MENU(MenuIDs.MENU_COORD_DEL_N, new wx.EventListener(OnCoordDelN));
      //      //      EVT_MENU(MenuIDs.MENU_COORD_INS_1, new wx.EventListener(OnCoordIns1));
      //      //      EVT_MENU(MenuIDs.MENU_COORD_INS_N, new wx.EventListener(OnCoordInsN));

      //      //      EVT_CHAR(new wx.EventListener(OnChar));

      //      SetScrollbars(1, 1, Configuration.XMAX, Configuration.YMAX);
      if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        return;

      m_layout = null;
      Globals.create_colors();
      Globals.create_draw(this);
      Globals.init_pmaps();
      //      //      m_tooltip = null;
      //      //      ToolTip.SetDelay(1000);
      //      //      ToolTip.Enable(Globals.show_tooltip);
      //      //#if WIN32
      //      //#else
      //      //  wxHelpProvider::Set(&canvasHelp);
      //      //#endif
    }

    //    // TODO Check if this is still needed... probably not!
    //    ~Canvas() {
    //      // throw new NotImplementedException();
    //      //wxHelpProvider.Set(0);
    //      //Globals.field_grid = null;
    //    }

    protected override void OnPaint(PaintEventArgs e) {
      // public void OnPaint(object sender, Event evt) {
      if(Globals.field_grid != null)
        Globals.field_grid.Paint(e.Graphics);
    }

    //    public void OnEraseBackground(object sender, Event evt) {
    //    }

    //    public Point GetEventPosition(Point pt) {
    //      throw new NotImplementedException();
    //      //double xScale, yScale;
    //      //Point pos = new Point(pt.X, pt.Y);
    //      //int tmpX, tmpY;
    //      //CalcUnscrolledPosition(pos.X, pos.Y, ref tmpX, ref tmpY);
    //      //pos.X = tmpX; pos.Y = tmpY;
    //      //Globals.field_grid.m_dc.GetUserScale(out xScale, out yScale);
    //      //pos.X = (int)(pos.X / xScale);
    //      //pos.Y = (int)(pos.Y / yScale);
    //      //return pos;
    //    }

    protected override void OnMouseMove(MouseEventArgs e) {
      // public void OnMouseMove(object sender, Event evt1) {
      //throw new NotImplementedException();
      //MouseEvent evt = (MouseEvent)evt1;
      //Point pos = evt.Position;
      //pos = GetEventPosition(pos);

      Point pos = e.Location;

      if(Globals.bShowCoord) {
        if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
//          evt.Skip();
          base.OnMouseMove(e);
          return;
        }
        pos.X -= Configuration.HCOORDBAR;
        pos.Y -= Configuration.VCOORDBAR;
      }

      Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.HGRID);

//      string oldTooltip = "";
//      oldTooltip = String.Copy(Globals.tooltipString);

      Globals.pointer_at(coord);

//      if(Globals.show_tooltip && (Globals.wxStrcmp(oldTooltip, Globals.tooltipString) != 0)) {
//#if WIN32
//        ToolTip newTip = new ToolTip(Globals.tooltipString);
//        this.ToolTip = Globals.tooltipString; // Erik: Original code => this.ToolTip = newTip;
//        m_tooltip = newTip;
//#else
//          canvasHelp.AddHelp(this, tooltipString);
//          canvasHelp.ShowHelp(this);
//          canvasHelp.RemoveHelp(this);
//#endif
//      }
      if(Globals.bShowCoord) {
        Globals.coord_paint(coord);
        Globals.draw_all_pixmap();
      }

      // evt.Skip();
      base.OnMouseMove(e);
    }

    //    public void OnMouseLeft(object sender, Event evt1) {
    //      throw new NotImplementedException();
    //      //MouseEvent evt = (MouseEvent)evt1;
    //      //Point pos = evt.Position;
    //      //pos = GetEventPosition(pos);

    //      //// Now pos has the absolute position in the canvas

    //      //if(Globals.bShowCoord) {
    //      //  if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
    //      //    evt.Skip();
    //      //    return;
    //      //  }
    //      //  pos.X -= Configuration.HCOORDBAR;
    //      //  pos.Y -= Configuration.VCOORDBAR;
    //      //}

    //      //Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.HGRID);

    //      //if(evt.ControlDown) {
    //      //  Globals.track_control_selected(coord);

    //      //  return;
    //      //} else if(evt.ShiftDown) {
    //      //  if(Globals.track_shift_selected(coord) != 0)
    //      //    return;
    //      //  Globals.itin_start = coord;
    //      //  return;
    //      //} else if(evt.AltDown) {
    //      //}
    //      //if(Globals.editing) {
    //      //  Globals.track_place(coord.x, coord.y);
    //      //  Globals.field_grid.Paint();
    //      //  Refresh();
    //      //  evt.Skip();
    //      //  return;
    //      //}
    //      //string buff;

    //      //buff = String.Format(wxPorting.T("click %d %d"), coord.x, coord.y);
    //      //Globals.trainsim_cmd(buff);
    //      //evt.Skip();
    //    }

    //    public void OnMouseRight(object sender, Event evt1) {
    //      throw new NotImplementedException();
    //      //MouseEvent evt = (MouseEvent)evt1;
    //      //Point pos = evt.Position;
    //      //pos = GetEventPosition(pos);

    //      //// Now pos has the absolute position in the canvas

    //      //if(Globals.bShowCoord) {
    //      //  if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
    //      //    // Show popup menu to insert/delete col/row
    //      //    CoordMenu(evt, pos.X >= Configuration.HCOORDBAR && pos.Y < Configuration.VCOORDBAR);
    //      //    evt.Skip();
    //      //    return;
    //      //  }
    //      //  pos.X -= Configuration.HCOORDBAR;
    //      //  pos.Y -= Configuration.VCOORDBAR;
    //      //}

    //      //// convert screen coord to cell coord
    //      //Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.VGRID);

    //      //if(evt.ControlDown) {
    //      //  if(Globals.editing) {
    //      //    Track t;
    //      //    if(((t = Globals.findTrack(coord.x, coord.y)) != null) || ((t = Globals.findImage(coord.x, coord.y)) != null)) {
    //      //      Globals.ShowTrackScriptDialog(t);
    //      //      Globals.repaint_all();
    //      //      return;
    //      //    }
    //      //  }
    //      //  Globals.track_control_selected(coord);
    //      //  return;
    //      //} else if(evt.ShiftDown) {
    //      //  if(Globals.track_shift_selected(coord) != 0)
    //      //    return;
    //      //  Globals.try_itinerary(Globals.itin_start.x, Globals.itin_start.y, coord.x, coord.y);
    //      //  return;
    //      //} else if(evt.AltDown) {
    //      //}

    //      //if(Globals.editing_itinerary) {
    //      //  Globals.do_itinerary_dialog(coord.x, coord.y);
    //      //  evt.Skip();
    //      //  return;
    //      //}
    //      //if(Globals.editing) {
    //      //  Globals.track_properties(coord.x, coord.y);
    //      //  Globals.repaint_all();
    //      //  return;
    //      //}
    //      //string buff;

    //      //buff = String.Format(wxPorting.T("rclick %d %d"), coord.x, coord.y);
    //      //Globals.trainsim_cmd(buff);
    //      //evt.Skip();
    //    }

    //    public void OnMouseDblLeft(object sender, Event evt1) {
    //      MouseEvent evt = (MouseEvent)evt1;
    //      Point pos = evt.Position;
    //      pos = GetEventPosition(pos);
    //      // Now pos has the absolute position in the canvas
    //      evt.Skip();
    //    }

    //    public void OnMouseDblRight(object sender, Event evt1) {
    //      MouseEvent evt = (MouseEvent)evt1;
    //      Point pos = evt.Position;
    //      pos = GetEventPosition(pos);
    //      // Now pos has the absolute position in the canvas
    //      evt.Skip();
    //    }

    //    public void CoordMenu(MouseEvent evt, bool verticalCoord) {
    //      throw new NotImplementedException();
    //      //Menu menu = new Menu();
    //      //MenuItem item;
    //      //Point pt = evt.Position;
    //      //Point pt1 = GetEventPosition(pt);

    //      //Globals.bIsVerticalCoord = verticalCoord;
    //      //if(verticalCoord) {
    //      //  m_xyCoord = (pt1.X - Configuration.HCOORDBAR) / Configuration.HGRID;
    //      //  item = menu.Append(MenuIDs.MENU_COORD_DEL_1, wxPorting.L("Delete Column"), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_DEL_N, wxPorting.L("Delete Columns..."), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_INS_1, wxPorting.L("Insert Column"), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_INS_N, wxPorting.L("Insert Columns..."), wxPorting.L(""));
    //      //} else {
    //      //  m_xyCoord = (pt1.Y - Configuration.VCOORDBAR) / Configuration.VGRID;
    //      //  item = menu.Append(MenuIDs.MENU_COORD_DEL_1, wxPorting.L("Delete Row"), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_DEL_N, wxPorting.L("Delete Rows..."), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_INS_1, wxPorting.L("Insert Row"), wxPorting.L(""));
    //      //  item = menu.Append(MenuIDs.MENU_COORD_INS_N, wxPorting.L("Insert Rows..."), wxPorting.L(""));
    //      //}

    //      //PopupMenu(menu, pt);
    //    }

    //    //
    //    //
    //    //

    //    public void OnCoordDel1(object sender, Event evt) {
    //      throw new NotImplementedException();
    //      //if(Globals.bIsVerticalCoord) {
    //      //  Globals.move_start.x = m_xyCoord + 1;
    //      //  Globals.move_start.y = 0;
    //      //  Globals.move_end.x = Configuration.XNCELLS;
    //      //  Globals.move_end.y = Configuration.YNCELLS;
    //      //  Globals.move_layout(m_xyCoord, 0);
    //      //} else {
    //      //  Globals.move_start.x = 0;
    //      //  Globals.move_start.y = m_xyCoord + 1;
    //      //  Globals.move_end.x = Configuration.XNCELLS;
    //      //  Globals.move_end.y = Configuration.YNCELLS;
    //      //  Globals.move_layout(0, m_xyCoord);
    //      //}
    //      //Globals.invalidate_field();
    //      //Globals.repaint_all();
    //    }

    //    //
    //    //
    //    //

    //    public void OnCoordDelN(object sender, Event evt) {
    //      throw new NotImplementedException();
    //      //      // for some reason wxNumberEntryDialog is not defined on my RHEL3!
    //      //#if __unix__ || __WXMAC__
    //      //#else
    //      //      wxNumberEntryDialog diag = new wxNumberEntryDialog(this,
    //      //      wxPorting.L("Number of rows/columns to delete?"),
    //      //      wxPorting.L("Enter a number:"), wxPorting.L("Delete rows/columns"),
    //      //      1, 1, Globals.bIsVerticalCoord ? (Configuration.XNCELLS - m_xyCoord - 1) : (Configuration.YNCELLS - m_xyCoord - 1));
    //      //      int inc;

    //      //      if(diag.ShowModal() != wxID_OK)
    //      //        return;
    //      //      inc = diag.GetValue();
    //      //      if(Globals.bIsVerticalCoord) {
    //      //        Globals.move_start.x = m_xyCoord + inc;
    //      //        Globals.move_start.y = 0;
    //      //        Globals.move_end.x = Configuration.XNCELLS;
    //      //        Globals.move_end.y = Configuration.YNCELLS;
    //      //        Globals.move_layout(m_xyCoord, 0);
    //      //      } else {
    //      //        Globals.move_start.x = 0;
    //      //        Globals.move_start.y = m_xyCoord + inc;
    //      //        Globals.move_end.x = Configuration.XNCELLS;
    //      //        Globals.move_end.y = Configuration.YNCELLS;
    //      //        Globals.move_layout(0, m_xyCoord);
    //      //      }
    //      //      Globals.invalidate_field();
    //      //      Globals.repaint_all();
    //      //#endif
    //    }

    //    //
    //    //
    //    //

    //    public void OnCoordIns1(object sender, Event evt) {
    //      throw new NotImplementedException();
    //      //if(Globals.bIsVerticalCoord) {
    //      //  Globals.move_start.x = m_xyCoord;
    //      //  Globals.move_start.y = 0;
    //      //  Globals.move_end.x = Configuration.XNCELLS;
    //      //  Globals.move_end.y = Configuration.YNCELLS;
    //      //  Globals.move_layout(m_xyCoord + 1, 0);
    //      //} else {
    //      //  Globals.move_start.x = 0;
    //      //  Globals.move_start.y = m_xyCoord;
    //      //  Globals.move_end.x = Configuration.XNCELLS;
    //      //  Globals.move_end.y = Configuration.YNCELLS;
    //      //  Globals.move_layout(0, m_xyCoord + 1);
    //      //}
    //      //Globals.invalidate_field();
    //      //Globals.repaint_all();
    //    }

    //    //
    //    //
    //    //

    //    public void OnCoordInsN(object sender, Event evt) {
    //      throw new NotImplementedException();
    //      //      // for some reason wxNumberEntryDialog is not defined on my RHEL3!
    //      //#if __unix__ || __WXMAC__
    //      //#else
    //      //      wxNumberEntryDialog diag = new wxNumberEntryDialog(this,
    //      //          wxPorting.L("Number of rows/columns to insert?"),
    //      //          wxPorting.L("Enter a number:"), wxPorting.L("Insert rows/columns"),
    //      //          1, 1, Globals.bIsVerticalCoord ? (Configuration.XNCELLS - m_xyCoord - 1) : (Configuration.YNCELLS - m_xyCoord - 1));
    //      //      int inc;

    //      //      if(diag.ShowModal() != wxID_OK)
    //      //        return;
    //      //      inc = diag.GetValue();
    //      //      if(Globals.bIsVerticalCoord) {
    //      //        Globals.move_start.x = m_xyCoord;
    //      //        Globals.move_start.y = 0;
    //      //        Globals.move_end.x = Configuration.XNCELLS;
    //      //        Globals.move_end.y = Configuration.YNCELLS;
    //      //        Globals.move_layout(m_xyCoord + inc, 0);
    //      //      } else {
    //      //        Globals.move_start.x = 0;
    //      //        Globals.move_start.y = m_xyCoord;
    //      //        Globals.move_end.x = Configuration.XNCELLS;
    //      //        Globals.move_end.y = Configuration.YNCELLS;
    //      //        Globals.move_layout(0, m_xyCoord + inc);
    //      //      }
    //      //      Globals.invalidate_field();
    //      //      Globals.repaint_all();
    //      //#endif
    //    }

    //    //
    //    //
    //    //

    //    public void OnChar(object sender, Event evt1) {
    //      throw new NotImplementedException();
    //      //KeyEvent ev = (KeyEvent)evt1;
    //      //int flags = 0;
    //      //int x, y;

    //      //if(ev.ControlDown)
    //      //  flags |= 1;
    //      //if(ev.ShiftDown)
    //      //  flags |= 2;
    //      //if(ev.AltDown)
    //      //  flags |= 4;

    //      //switch(ev.KeyCode) {
    //      //  case (int)wx.KeyCode.WXK_LEFT:

    //      //    if(ev.ControlDown) {
    //      //      GetViewStart(ref x, ref y);
    //      //      x -= 200;
    //      //      if(x < 0)
    //      //        x = 0;
    //      //      Scroll(x, y);
    //      //      break;
    //      //    }
    //      //    ev.Skip();
    //      //    break;

    //      //  case (int)wx.KeyCode.WXK_RIGHT:

    //      //    if(ev.ControlDown) {
    //      //      GetViewStart(ref x, ref y);
    //      //      x += 200;
    //      //      if(x < 0)
    //      //        x = 0;
    //      //      Scroll(x, y);
    //      //      break;
    //      //    }
    //      //    ev.Skip();
    //      //    break;

    //      //  case (int)wx.KeyCode.WXK_UP:

    //      //    if(ev.ControlDown) {
    //      //      GetViewStart(ref x, ref y);
    //      //      y -= 200;
    //      //      if(y < 0)
    //      //        y = 0;
    //      //      Scroll(x, y);
    //      //      break;
    //      //    }
    //      //    ev.Skip();
    //      //    break;

    //      //  case (int)wx.KeyCode.WXK_DOWN:

    //      //    if(ev.ControlDown) {
    //      //      GetViewStart(ref x, ref y);
    //      //      y += 200;
    //      //      Scroll(x, y);
    //      //      break;
    //      //    }
    //      //    ev.Skip();
    //      //    break;

    //      //  case 0x1b:
    //      //    Globals.trainsim_cmd(wxPorting.T("run"));
    //      //    ev.Skip();
    //      //    break;

    //      //  case '7':
    //      //    if(ev.ControlDown)
    //      //      Scroll(0, 0);		// upper left corner
    //      //    break;

    //      //  case '1':
    //      //    if(ev.ControlDown)	// lower left corner
    //      //      Scroll(0, 0);
    //      //    break;

    //      //  case '9':
    //      //    if(ev.ControlDown)	// upper right corner
    //      //      Scroll(0, 0);
    //      //    break;

    //      //  case '3':
    //      //    if(ev.ControlDown)	// lower right corner
    //      //      Scroll(0, 0);
    //      //    break;

    //      //  default:
    //      //    ev.Skip();
    //      //    break;
    //      //}
    //    }

    //    public void DoPrint() {
    //      throw new NotImplementedException();
    //      //  if(Globals.gSaveImageFileDialog == null) {
    //      //    Globals.gSaveImageFileDialog = new wx.FileDialog(Globals.traindir.m_frame, wxPorting.L("Save Image"), wxPorting.T(""), wxPorting.T(""),
    //      //  wxPorting.T("PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|Bitmap file (*.bmp)|*.bmp|GIF image (*.gif)|*.gif|All Files (*.*)|*.*"),
    //      //  WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
    //      //  }
    //      //  if(Globals.gSaveImageFileDialog.ShowModal() != ShowModalResult.OK)
    //      //    return;
    //      //  String path = Globals.gSaveImageFileDialog.Path;
    //      //  wxRect bounds;
    //      //  wx.Bitmap srcbitmap = Globals.field_grid.m_pixmap;
    //      //  bounds.Height = 0;
    //      //  bounds.Width = 0;
    //      //  bounds.X = srcbitmap.Width; ;
    //      //  bounds.Y = srcbitmap.Height;
    //      //  Track trk;
    //      //  for(trk = Globals.layout; trk != null; trk = trk.next) {
    //      //    if(trk.x * Globals.field_grid.m_hmult < bounds.X)
    //      //      bounds.X = trk.x * Globals.field_grid.m_hmult;
    //      //    if(trk.y * Globals.field_grid.m_vmult < bounds.Y)
    //      //      bounds.Y = trk.y * Globals.field_grid.m_hmult;
    //      //    if((trk.x + 1) * Globals.field_grid.m_hmult > bounds.Width)
    //      //      bounds.Width = (trk.x + 1) * Globals.field_grid.m_hmult;
    //      //    if((trk.y + 1) * Globals.field_grid.m_vmult > bounds.Height)
    //      //      bounds.Height = (trk.y + 1) * Globals.field_grid.m_hmult;
    //      //  }
    //      //  bounds.Width -= bounds.X;
    //      //  bounds.Height -= bounds.Y;
    //      //  // give the image a 2-square border
    //      //  bounds.X -= Globals.field_grid.m_hmult * 2;
    //      //  if(bounds.X < 0) bounds.X = 0;
    //      //  bounds.Y -= Globals.field_grid.m_vmult * 2;
    //      //  if(bounds.Y < 0) bounds.Y = 0;
    //      //  bounds.Width += Globals.field_grid.m_hmult * 2;
    //      //  bounds.Height += Globals.field_grid.m_vmult * 2;
    //      //  bounds.Width += Globals.field_grid.m_xBase;
    //      //  bounds.Height += Globals.field_grid.m_yBase;
    //      //  wx.Bitmap submap = srcbitmap.GetSubBitmap(bounds);
    //      //  wx.BitmapType type = BitmapType.wxBITMAP_TYPE_BMP;
    //      //  if(Globals.wxStrstr(path, wxPorting.T(".gif")))
    //      //    type = BitmapType.wxBITMAP_TYPE_GIF;
    //      //  if(Globals.wxStrstr(path, wxPorting.T(".png")))
    //      //    type = BitmapType.wxBITMAP_TYPE_PNG;
    //      //  if(Globals.wxStrstr(path, wxPorting.T(".jpg")))
    //      //    type = BitmapType.wxBITMAP_TYPE_JPEG;
    //      //  submap.SaveFile(path, type, null);
    //    }
  }

}
