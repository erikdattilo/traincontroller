/*	Canvas.cpp - Created by Giampiero Caprino

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

using wx;
using System;
using System.Drawing;
namespace TrainDirPorting {

  public partial class Globals {
    public static Coord itin_start;
    public static bool bIsVerticalCoord;

    public static grid current_grid, field_grid, tools_grid;

    public static bool updating_all = false;
    public static bool first_time = true;
    public static bool show_grid = false;
    public static int ntoolrows = 2;
    public static bool bShowCoord = true;

    public static int status_on_top;

    public static TDSkin skin_list;
    public static TDSkin curSkin;
    public static TDSkin defaultSkin;



    public static byte[][] colortable = new byte[15][]{
	new byte[] { 0, 0, 0 },
	new byte[] { 255, 255, 255 },
	new byte[] { 0, 255, 0 },
	new byte[] { 255, 255, 0 },
	new byte[] { 255, 0, 0 },
	new byte[] { 255, 128, 0 },
	new byte[] { 255, 128, 128 },
	new byte[] { 128, 128, 128 },
	new byte[] { 168, 168, 168 }, //	new byte[] { 192, 192, 192 },
	new byte[] { 64, 64, 64 },
	new byte[] { 0, 0, 255 },	    // blue
	new byte[] { 0, 255, 255 },    // cyan
        new byte[] { 202, 31, 123 },   // magenta
        new byte[] { 0, 0, 0, },       // free
	new byte[] { 0, 0, 0 }	    // [14] : custom color for option colorBg
};

#if WIN32
#else
wxSimpleHelpProvider	canvasHelp;
#endif


    public static void getcolor_rgb(int col, out byte r, out byte g, out byte b) {
      r = g = b = 0;
      if(col < 0 || col > 11)
        return;
      r = colortable[col][0];
      g = colortable[col][1];
      b = colortable[col][2];
    }

    public static int getcolor_rgb(int col) {
      int c = colortable[col][0] << 16;
      c |= colortable[col][1] << 8;
      c |= colortable[col][2];
      return c;
    }

    public static void create_colors() {
      color_black = 0;
      color_white = 1;
      color_green = 2;
      color_yellow = 3;
      color_red = 4;
      color_orange = 5;
      color_brown = 6;
      color_gray = 7;
      color_lightgray = 8;
      color_darkgray = 9;
      color_blue = 10;
      color_cyan = 11;
      color_magenta = 12;

      fieldcolors[(int)fieldcolor.COL_BACKGROUND] = color_lightgray;
      fieldcolors[(int)fieldcolor.COL_TRACK] = color_black;
      fieldcolors[(int)fieldcolor.COL_GRAPHBG] = color_lightgray;

      fieldcolors[(int)fieldcolor.COL_TRAIN1] = color_orange;
      fieldcolors[(int)fieldcolor.COL_TRAIN2] = color_cyan;
      fieldcolors[(int)fieldcolor.COL_TRAIN3] = color_blue;
      fieldcolors[(int)fieldcolor.COL_TRAIN4] = color_yellow;
      fieldcolors[(int)fieldcolor.COL_TRAIN5] = color_white;
      fieldcolors[(int)fieldcolor.COL_TRAIN6] = color_red;
      fieldcolors[(int)fieldcolor.COL_TRAIN7] = color_brown;
      fieldcolors[(int)fieldcolor.COL_TRAIN8] = color_green;
      fieldcolors[(int)fieldcolor.COL_TRAIN9] = color_magenta;
      fieldcolors[(int)fieldcolor.COL_TRAIN10] = color_lightgray;

      curSkin = new TDSkin();
      curSkin.free_track = getcolor_rgb(color_black);
      curSkin.reserved_track = getcolor_rgb(color_green);
      curSkin.reserved_shunting = getcolor_rgb(color_white);
      curSkin.occupied_track = getcolor_rgb(color_orange);
      curSkin.working_track = getcolor_rgb(color_blue);
      curSkin.background = getcolor_rgb(color_lightgray);
      curSkin.outline = getcolor_rgb(color_darkgray);
      curSkin.text = getcolor_rgb(color_black);
      curSkin.name = Globals.wxStrdup(wxPorting.T("default"));
      curSkin.next = null;
      skin_list = curSkin;
      defaultSkin = curSkin;
    }

    public static void set_show_coord(bool opt) {
      bShowCoord = opt;
      if(opt) {
        field_grid.m_xBase = Configuration.HCOORDBAR;
        field_grid.m_yBase = Configuration.VCOORDBAR;
      } else {
        field_grid.m_xBase = 0;
        field_grid.m_yBase = 0;
      }
    }

    public static void create_draw(ScrolledWindow parent) {
      grid g;

      g = new grid(parent, Configuration.XMAX * 2, Configuration.YMAX * 2);
      g.m_hmult = Configuration.HGRID;
      g.m_vmult = Configuration.VGRID;
      field_grid = g;
      current_grid = g;
      set_show_coord(true);
    }

    public static void draw_all_pixmap() {
      grid g;

      g = field_grid;

      wx.ClientDC clientDC = new wx.ClientDC(g.m_parent);
      ScrolledWindow w = (ScrolledWindow)g.m_parent;
      w.PrepareDC(clientDC);
      wx.BufferedDC wdc = new BufferedDC(clientDC, g.m_pixmap);
    }

    public static void draw_layout_text1(int x, int y, String txt, bool size) {
      current_grid.DrawText1(x, y, txt, size);
    }

    public static void draw_layout_text_font(int x, int y, String txt, int index) {
      current_grid.DrawTextFont(x, y, txt, index);
    }

    public static void draw_text_with_background(int x, int y, String txt, bool size, int bgcolor) {
      current_grid.DrawTextWithBackground(x, y, txt, size, bgcolor);
    }

    public static void draw_itin_text(int x, int y, String txt, bool size) {
      if(current_grid == tools_grid)
        draw_layout_text1(x, y, txt, size);
      else
        draw_layout_text1(x + 1, y, txt, size);
    }

    public static void update_rectangle_at(int x, int y) {
      wxRect update_rect = new wxRect();

      if(Globals.updating_all)
        return;

      update_rect.X = x;
      update_rect.Y = y;
      update_rect.Width = current_grid.m_hmult;
      update_rect.Height = current_grid.m_vmult;

      draw_all_pixmap();	// TEMP
    }

    public static void tr_fillrect(int x, int y) {
      current_grid.FillCell(x, y);
    }


    public static void clear_field() {
      if(editing)
        invalidate_field();
      field_grid.ClearField();
    }

    public static void grid_paint() {
      field_grid.Paint();
    }

    public static void coord_paint(Coord pCoord) {
      string buff;
      int i;
      grid g = field_grid;

      wx.Font font = new wx.Font(6, wx.FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL);
      g.m_dc.SelectObject(g.m_pixmap);

      // draw background of coord bars
      g.m_dc.SetPen(wx.GDIPens.wxLIGHT_GREY_PEN);
      g.m_dc.SetBrush(wx.GDIBrushes.wxLIGHT_GREY_BRUSH);
      g.m_dc.DrawRectangle(0, 0, Configuration.XMAX, Configuration.VCOORDBAR);
      g.m_dc.DrawRectangle(0, 0, Configuration.HCOORDBAR, Configuration.YMAX);

      // draw digits
      g.m_dc.SetFont(font);
      g.m_dc.SetBackgroundMode((int)DCBackgroundMode.SOLID);
      g.m_dc.SetTextForeground(Colour.wxBLACK);
      g.m_dc.SetTextBackground(Colour.wxLIGHT_GREY);
      Point pt = new Point(0, 0);
      for(i = 0; i < Configuration.XNCELLS; ++i) {
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(wx.Colour.wxWHITE);
        buff = String.Format( wxPorting.T("%d"), i / 100);
        pt.X = i * Configuration.HGRID + Configuration.HCOORDBAR;
        pt.Y = 0;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format( wxPorting.T("%d"), (i / 10) % 10);
        pt.Y = 8;
        g.m_dc.DrawText(buff, pt);
        buff = String.Format( wxPorting.T("%d"), i % 10);
        pt.Y = 16;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.x)
          g.m_dc.SetTextForeground(Colour.wxBLACK);
      }
      for(i = 0; i < Configuration.YNCELLS; ++i) {
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(wx.Colour.wxWHITE);
        buff = String.Format( wxPorting.T("%3d"), i);
        pt.X = 0;
        pt.Y = i * Configuration.VGRID + Configuration.VCOORDBAR;
        g.m_dc.DrawText(buff, pt);
        if(pCoord != null && i == pCoord.y)
          g.m_dc.SetTextForeground(Colour.wxBLACK);
      }
      g.m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public static void draw_layout(int x0, int y0, VLines[] p, grcolor col) {
      current_grid.DrawLayoutRGB(x0, y0, p, col);
      update_rectangle_at(x0, y0);
    }

    public static void draw_mid_point(int x0, int y0, int dx, int dy, grcolor col) {
      current_grid.DrawPoint(x0, y0, dx, dy, col);
      update_rectangle_at(x0, y0);
    }

    public static object get_pixmap(String pxpm) {
      wx.Image img = new wx.Image(pxpm);
      return img;
    }

    public static void delete_pixmap(object p) {
      wx.Image img = (wx.Image)p;

      if(img != null)
        Globals.delete(img);
    }

    public static object get_pixmap_file(String fname) {
      throw new NotImplementedException();
//      TDFile xpmFile = new TDFile(fname);

//      if(!xpmFile.Load())
//        return 0;

//      gLogger.SetExtraInfo(fname);

//      int nLines = xpmFile.LineCount();
//      String[] pattern = (String[])Globals.calloc(nLines + 10);
//      int i, j, k;
//      string buff;

//      // collect all strings (delimited by double-quotes)
//      // from the file and store them in pattern[],
//      // one string per entry.

//      for(i = 0; i < nLines; ) {
//        if(!xpmFile.ReadLine(buff, buff.Length))
//          break;
//        for(j = 0; j <= buff.Length && buff[j] != '"'; ++j) ;
//        if(j++ == buff.Length) // Erik: Original code ==> if(buff[j++] == 0)
//          continue;
//        for(k = 0; j <= buff.Length && buff[j] != '"'; buff.ReplaceAt(k, buff[j]), k++, j++) ;

//        if(j == buff.Length)
//          continue;
//        buff = buff.Substring(0, k - 1);
//        // we allocate a bit more to allow extending
//        // shorter lines during the checking phase
//        pattern[i] = ""; //  (String)Globals.calloc(k + 10, 1);
//#if wxUSE_UNICODE
//      wxConvISO8859_1.FromWChar(pattern[i], k + 10, buff, wxNO_LEN);
//#else
//        Globals.strcpy(pattern[i], buff);
//#endif
//        ++i;
//      }

//      wx.Image img = null;

//      // now analyze the lines to check if the image is correct

//      int nRows, nColumns, nColors, depth, x, y, c;
//      if(Globals.sscanf(pattern[0], "%d %d %d %d", nColumns, nRows, nColors, depth) != 4) {
//        buff = String.Format( wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
//        Globals.traindir.layout_error(buff);
//        goto done;
//      }
//      if(nRows > i - 1 - nColors) {
//        string cbuff;
//        buff = String.Format( wxPorting.T("%s: Warning: too many lines in XPM header. Truncated."), fname);
//        Globals.traindir.layout_error(buff);
//        cbuff = String.Format("%d %d %d %d", nColumns, i - 1 - nColors, nColors, depth);
//        Globals.free(pattern[0]);
//        pattern[0] = Globals.strdup(cbuff);
//      }
//      for(y = nColors + 1; y < i; ++y) {  // check each pixel row
//        for(x = 0; x < nColumns; ++x) {
//          bool valid = false;
//          if(pattern[y][x] == 0)
//            break;
//          for(c = 0; c < nColors; ++c) {
//            if(pattern[c + 1][0] == pattern[y][x]) {
//              valid = true;
//              break;
//            }
//          }
//          if(!valid) {
//            pattern[y].ReplaceAt(x, pattern[1][0]);  // force first color (hopefully "None")
//            buff = String.Format( wxPorting.T("%s: Warning: bad color key (y=%d,x=%d). Replaced."), fname, y, x);
//            Globals.traindir.layout_error(buff);
//          }
//        }
//      }
//      try {
//        img = new wx.Image(pattern);
//        if(!img.Ok) {
//          buff = String.Format( wxPorting.T("Error loading '%s'"), fname);
//          Globals.traindir.layout_error(buff);
//          Globals.delete(img);
//          img = null;
//        }
//      } catch(Exception) {
//        buff = String.Format( wxPorting.T("Error loading '%s' - not a valid XPM file."), fname);
//        Globals.traindir.layout_error(buff);
//      }
//    done:
//      for(i = 0; pattern[i] != null; ++i)
//        Globals.free(pattern[i]);
//      Globals.free(pattern);
//      return (object)img;
    }

    public static void draw_pixmap(int x0, int y0, wx.Image map) {
      wx.Image img = map; // (wx.Image*)map;
      Rectangle update_rect = new Rectangle();
      grid g = current_grid;
      int x = x0 * g.m_hmult + g.m_xBase;
      int y = y0 * g.m_vmult + g.m_yBase;

      if(!img.Ok)
        return;
      if(g.m_pixmap == null)
        return;
      if(g.m_dc == null)
        g.m_dc = new MemoryDC();
      if(g == tools_grid && y0 != 0 && x0 < 8) {
        x += tools_grid.m_hmult / 2;
        y += tools_grid.m_vmult / 2;
      }
      wx.Bitmap bitmap = new wx.Bitmap(img, -1);
      g.m_dc.SelectObject(g.m_pixmap);
      g.m_dc.DrawBitmap(bitmap, x, y, true);
      g.m_dc.SelectObject(wx.Bitmap.NullBitmap);
      if(updating_all)
        return;
      update_rect.X = x;
      update_rect.Y = y;
      update_rect.Width = 16 * g.m_hmult;
      update_rect.Height = 11 * g.m_vmult;
    }

    public static void get_pixmap_size(wx.Image map, Coord sz) {
      wx.Image img = map; // (wx.Image*)map;
      sz.x = img.Width;
      sz.y = img.Height;
    }

    public static void get_text_size(String txt, Coord sz) {
      field_grid.GetTextExtent(txt, false, sz);
    }

    public static void draw_link(int x0, int y0, int x1, int y1, int color) {
      field_grid.DrawLineCenterCell(x0, y0, x1, y1, color);
    }

    public static AskAnswer ask(String msg) {
      ShowModalResult res;
      
      res = wx.MessageDialog.MessageBox(wxPorting.LV(msg), wxPorting.L("Question"),
          wx.WindowStyles.DIALOG_YES_DEFAULT | wx.WindowStyles.DIALOG_YES_NO | wx.WindowStyles.ICON_QUESTION, Globals.traindir.m_frame);
      if(res == ShowModalResult.YES)
        return AskAnswer.ANSWER_YES;
      return AskAnswer.ANSWER_NO;
    }

    public static void new_status_position() {
    }

    public static void create_train() {
    }

    //	update_button
    //	called to update the start/stop state of UI's buttons.
    public static void update_button(String cmd, String lbltxt) {
      Globals.traindir.m_frame.m_running.Label = (lbltxt);
      if(running)
        Globals.traindir.m_frame.m_running.State = (true);
      else
        Globals.traindir.m_frame.m_running.State = (false);
    }

    public static int create_schedule(int assign) {
      return 0;
    }

    public static AskAnswer cont(String msg) {
      if(wx.MessageDialog.MessageBox(wxPorting.LV(msg), wxPorting.L("Question"),
          wx.WindowStyles.DIALOG_YES_DEFAULT | wx.WindowStyles.DIALOG_YES_NO | wx.WindowStyles.ICON_QUESTION, Globals.traindir.m_frame) == ShowModalResult.YES)
        return AskAnswer.ANSWER_YES;
      return AskAnswer.ANSWER_NO;
    }

    public static void create_path_window() {
    }

    public static void main_quit_cmd() {
    }

    public static void make_timer(int msec) {
      Globals.traindir.SetTimeSlice(msec / 100);  // each time slice is 100ms
    }

    public static void repaint_all() {
      current_grid = field_grid;
      if(!editing && Globals.cliprect.top > Globals.cliprect.bottom)
        return; /* no changes since last update */
      if(ignore_cliprect || editing)
        clear_field();
      updating_all = true;
      if(show_grid)
        grid_paint();
      if(bShowCoord)
        coord_paint(null);
      layout_paint(layout);
      trains_paint(stranded);
      trains_paint(schedule);
      updating_all = false;
      draw_all_pixmap();
      reset_clip_rect();
    }

    public static void set_zoom(bool zooming) {
      grid g = field_grid;
      ScrolledWindow w = (ScrolledWindow)g.m_parent;

      if(zooming) {
        g.m_dc.SetUserScale(2.0, 2.0);
        w.SetScrollbars(1, 1, Configuration.XMAX * 2, Configuration.YMAX * 2);
      } else {
        g.m_dc.SetUserScale(1.0, 1.0);
        w.SetScrollbars(1, 1, Configuration.XMAX, Configuration.YMAX);
      }
      invalidate_field();
      repaint_all();
    }

    internal static bool wxStrstr(string path, string p) {
      throw new NotImplementedException();
    }
  }


  public class grid {

    public void CellToCoord(ref int x, ref int y) {
      x = (x * m_hmult) + m_xBase;
      y = (y * m_vmult) + m_yBase;
    }

    public wx.Bitmap m_pixmap;
    public Window m_parent;
    public MemoryDC m_dc;
    public int m_hmult, m_vmult;
    public int m_xBase, m_yBase;



    public grid(Window parent)
      : this(parent, Configuration.XMAX, Configuration.YMAX) {
    }

    public grid(Window parent, int width, int height) {
      m_pixmap = new wx.Bitmap(width, height);
      m_parent = parent;
      m_dc = new MemoryDC();

      m_hmult = 1;
      m_vmult = 1;

      m_xBase = 0;
      m_yBase = 0;
    }

    ~grid() {
      if(m_pixmap != null)
        Globals.delete(m_pixmap);
      m_pixmap = null;
      if(m_dc != null)
        Globals.delete(m_dc);
      m_dc = null;
    }

    public void Paint(Window dest) {
      Paint(dest, false);
    }

    public void Paint(Window dest, bool fillBg) {
//#if WIN32
//      BufferedPaintDC dc = new BufferedPaintDC(dest);
//#else
//  wx.ClientDC   dc(dest);
//#endif

//      dest.PrepareDC(dc);
//      BufferedDC wdc = new BufferedDC(dc, m_pixmap);
    }

    public void DrawText1(int x, int y, String txt, bool size) {
      //CellToCoord(ref x, ref y);
      //if(this != Globals.tools_grid)
      //  y -= (size ? 3 : 4);
      //wx.Font font = new wx.Font(size ? Globals.gFontSizeSmall : Globals.gFontSizeBig, wx.FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, wx.FontWeight.wxNORMAL);
      //m_dc.SelectObject(m_pixmap);
      //m_dc.SetFont(font);
      //m_dc.SetBackgroundMode(DCBackgroundMode.TRANSPARENT);
      //m_dc.SetTextForeground(Globals.curSkin.text);
      //m_dc.SetTextBackground(wx.Colour.wxWHITE);
      //Point pt = new Point(x, y);
      //m_dc.DrawText(txt, pt);
      //m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawTextFont(int x, int y, String txt, int fontIndex) {
      //FontEntry f = Globals.fonts.FindFont(fontIndex);
      ////	if(!f) {
      //DrawText1(x, y, txt, fontIndex == 1);
      //return;
      ////	}

      //CellToCoord(ref x, ref y);
      //y -= f._size / 2;
      //wx.Font font = new wx.Font(f._size, f._family, f._style, f._weight);
      //m_dc.SelectObject(m_pixmap);
      //m_dc.SetFont(font);
      //m_dc.SetBackgroundMode(DCBackgroundMode.TRANSPARENT);
      //m_dc.SetTextForeground(f._color); // *Colour.wxBLACK);
      //m_dc.SetTextBackground(wx.Colour.wxWHITE);
      //Point pt = new Point(x, y);
      //m_dc.DrawText(txt, pt);
      //m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawTextWithBackground(int x, int y, String txt, bool size, int bgcolor) {
      //CellToCoord(ref x, ref y);
      //byte r, g, b;
      //Globals.getcolor_rgb(bgcolor, out r, out g, out b);
      //if(this != Globals.tools_grid)
      //  y -= (size ? 3 : 4);
      //wx.Font font = new wx.Font(size ? Globals.gFontSizeSmall :   Globals.gFontSizeBig, wx.FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL);
      //m_dc.SelectObject(m_pixmap);
      //m_dc.SetFont(font);
      //m_dc.SetBackgroundMode(DCBackgroundMode.SOLID);
      //m_dc.SetTextForeground(Globals.curSkin.text);
      //m_dc.SetTextBackground(new wx.Colour(r, g, b));
      //Point pt = new Point(x, y);
      //m_dc.DrawText(txt, pt);
      //m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void GetTextExtent(String txt, bool size, Coord outCoord) {
      wx.Font font = new wx.Font(size ? Globals.gFontSizeSmall :   Globals.gFontSizeBig, wx.FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetFont(font);
      int x, y;
      String str = String.Copy(txt);
      m_dc.GetTextExtent(str, out x, out y);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
      outCoord.x = x;
      outCoord.y = y;
    }

    public void DrawLayoutRGB(int x0, int y0, VLines[] q, int rgb) {
      VLines p;
      wxRect update_rect;
      wx.Colour fg = new wx.Colour((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetPen(new wx.Pen(fg, 1));
      for(int i = 0; i < q.Length; i++) {
        p = q[i];
        // while(p.x0 >= 0) {
        m_dc.DrawLine(
          x + p.x0 * m_hmult / Configuration.HGRID,
          y + p.y0 * m_vmult / Configuration.VGRID,
          x + p.x1 * m_hmult / Configuration.HGRID,
          y + p.y1 * m_vmult / Configuration.VGRID
        );
        m_dc.DrawPoint(x + p.x1 * m_hmult / Configuration.HGRID,
          y + p.y1 * m_vmult / Configuration.VGRID);
        // p = p++;
      }
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }



    public void DrawLayout(int x0, int y0, VLines[] p, grcolor col) {
      DrawLayoutRGB(x0, y0, p, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] << 8) | Globals.colortable[col][2]);
    }

    public void DrawLineRGB(int x0, int y0, int x1, int y1, int rgb) {
      wx.Colour fg = new wx.Colour((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetPen(new wx.Pen(fg, 1));
      m_dc.DrawLine(x, y, x1 * m_hmult, y1 * m_vmult);
      m_dc.DrawPoint(x1 * m_hmult, y1 * m_vmult);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawLine(int x0, int y0, int x1, int y1, grcolor col) {
      DrawLineRGB(x0, y0, x1, y1, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] | 8) | Globals.colortable[col][2]);
    }

    public void DrawLineCenterCellRGB(int x0, int y0, int x1, int y1, int rgb) {
      wx.Colour fg = new wx.Colour((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int mx = Configuration.HGRID / 2;
      int my = Configuration.VGRID / 2;
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      CellToCoord(ref x1, ref y1);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetPen(new wx.Pen(fg, 1));
      m_dc.DrawLine(x + mx, y + my, x1 /* * m_hmult */ + mx, y1 /* * m_vmult */ + my);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawLineCenterCell(int x0, int y0, int x1, int y1, grcolor col) {
      DrawLineCenterCellRGB(x0, y0, x1, y1, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] << 8) | Globals.colortable[col][2]);
    }

    public void DrawPoint(int x0, int y0, int dx, int dy, int rgb) {
      wxRect update_rect;
      wx.Colour fg = new wx.Colour((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      x += m_hmult / 2 + dx;
      y += m_vmult / 2 + dy;
      m_dc.SelectObject(m_pixmap);
      m_dc.SetPen(new wx.Pen(fg, 1));
      m_dc.DrawPoint(x, y);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }
    public void FillCell(int x, int y) {
      CellToCoord(ref x, ref y);
      m_dc.SelectObject(m_pixmap);
      wxRect rect = new wxRect(x, y, m_hmult, m_vmult);
      wx.Colour background_color = new Colour();
      Globals.setBackgroundColor(background_color);
      m_dc.SetBrush(new wx.Brush(background_color));
      m_dc.SetPen(new wx.Pen(background_color, 1));
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void Clear() {
      wx.Colour bg = new Colour();
      Globals.setBackgroundColor(bg);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetBrush(new wx.Brush(bg));
      Rectangle rect = new Rectangle(new Point(0, 0), new Size(m_pixmap.Width, m_pixmap.Height));
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }


    public void ClearField() {
      wx.Colour bg = new Colour();
      Globals.setBackgroundColor(bg);
      m_dc.SelectObject(m_pixmap);
      //	bg = g.dc.GetBackground();
      m_dc.SetBrush(new wx.Brush(bg));
      wxRect rect = new wxRect(
            Globals.cliprect.left * m_hmult,
            Globals.cliprect.top * m_vmult,
            (Globals.cliprect.right - Globals.cliprect.left + 1) * m_hmult,
            (Globals.cliprect.bottom - Globals.cliprect.top + 1) * m_vmult
            );
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    //	Draw the point grid in the canvas.
    //	This gives the player a reference
    //	for positioning track elements.
    //	Only called if the corresponding
    //	option in Preferences is set.

    public void Paint() {
      int x, y;
      wx.Colour bg = new wx.Colour(Globals.colortable[Globals.color_darkgray][0], Globals.colortable[Globals.color_darkgray][1], Globals.colortable[Globals.color_darkgray][2]);

      m_dc.SelectObject(m_pixmap);
      m_dc.SetBrush(new wx.Brush(bg));
      m_dc.SetPen(new wx.Pen(bg, 1));
      for(x = m_xBase; x < Configuration.XMAX; x += Configuration.HGRID)
        for(y = m_yBase; y < Configuration.YMAX; y += Configuration.VGRID)
          if(x >= Globals.cliprect.left * Configuration.HGRID && x <= Globals.cliprect.right * Configuration.HGRID &&
             y >= Globals.cliprect.top * Configuration.VGRID && y <= Globals.cliprect.bottom * Configuration.VGRID)
            m_dc.DrawPoint(x, y);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

  }



  // ----------------------------------------------------------------------------
  // Canvas
  // ----------------------------------------------------------------------------


  public class Canvas : ScrolledWindow {


    public TDLayout m_layout;

    public int m_xyCoord;

    public ToolTip m_tooltip;

    public Canvas(Window parent)
      : base(parent, wxID_ANY, new Point(0, 0),
    new Size(Configuration.XMAX * 2, Configuration.YMAX * 2),
      WindowStyles.HSCROLL | WindowStyles.VSCROLL | WindowStyles.NO_FULL_REPAINT_ON_RESIZE) {
      EVT_PAINT(new wx.EventListener(OnPaint));
//      //    EVT_MOUSE_EVENTS(new wx.EventListener(OnMouse));
//      EVT_MOTION(new wx.EventListener(OnMouseMove));
//      EVT_LEFT_DOWN(new wx.EventListener(OnMouseLeft));
//      EVT_RIGHT_DOWN(new wx.EventListener(OnMouseRight));
//      EVT_LEFT_DCLICK(new wx.EventListener(OnMouseDblLeft));
//      EVT_RIGHT_DCLICK(new wx.EventListener(OnMouseDblRight));

//      EVT_MENU(MenuIDs.MENU_COORD_DEL_1, new wx.EventListener(OnCoordDel1));
//      EVT_MENU(MenuIDs.MENU_COORD_DEL_N, new wx.EventListener(OnCoordDelN));
//      EVT_MENU(MenuIDs.MENU_COORD_INS_1, new wx.EventListener(OnCoordIns1));
//      EVT_MENU(MenuIDs.MENU_COORD_INS_N, new wx.EventListener(OnCoordInsN));

//      EVT_CHAR(new wx.EventListener(OnChar));

      SetScrollbars(1, 1, Configuration.XMAX, Configuration.YMAX);
      m_layout = null;
      Globals.create_colors();
      Globals.create_draw(this);
      Globals.init_pmaps();
      m_tooltip = null;
//      ToolTip.SetDelay(1000);
//      ToolTip.Enable(Globals.show_tooltip);
//#if WIN32
//#else
//  wxHelpProvider::Set(&canvasHelp);
//#endif
    }

    ~Canvas() {
      wxHelpProvider.Set(0);
      Globals.delete(Globals.field_grid);
      Globals.field_grid = null;
    }

    public void OnPaint(object sender, Event evt) {
      if(Globals.field_grid != null)
        Globals.field_grid.Paint(this);
    }

    public void OnEraseBackground(object sender, Event evt) {
    }

    public Point GetEventPosition(Point pt) {
      throw new NotImplementedException();
      //double xScale, yScale;
      //Point pos = new Point(pt.X, pt.Y);
      //int tmpX, tmpY;
      //CalcUnscrolledPosition(pos.X, pos.Y, ref tmpX, ref tmpY);
      //pos.X = tmpX; pos.Y = tmpY;
      //Globals.field_grid.m_dc.GetUserScale(out xScale, out yScale);
      //pos.X = (int)(pos.X / xScale);
      //pos.Y = (int)(pos.Y / yScale);
      //return pos;
    }

    public void OnMouseMove(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = evt.Position;
      pos = GetEventPosition(pos);
      if(Globals.bShowCoord) {
        if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
          evt.Skip();
          return;
        }
        pos.X -= Configuration.HCOORDBAR;
        pos.Y -= Configuration.VCOORDBAR;
      }

      Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.HGRID);

      string oldTooltip = "";
      oldTooltip = String.Copy(Globals.tooltipString);

      Globals.pointer_at(coord);

      if(Globals.show_tooltip && (Globals.wxStrcmp(oldTooltip, Globals.tooltipString) != 0)) {
#if WIN32
        ToolTip newTip = new ToolTip(Globals.tooltipString);
        this.ToolTip = Globals.tooltipString; // Erik: Original code => this.ToolTip = newTip;
        m_tooltip = newTip;
#else
	    canvasHelp.AddHelp(this, tooltipString);
	    canvasHelp.ShowHelp(this);
	    canvasHelp.RemoveHelp(this);
#endif
      }
      if(Globals.bShowCoord) {
        Globals.coord_paint(coord);
        Globals.draw_all_pixmap();
      }
      evt.Skip();
    }

    public void OnMouseLeft(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = evt.Position;
      pos = GetEventPosition(pos);

      // Now pos has the absolute position in the canvas

      if(Globals.bShowCoord) {
        if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
          evt.Skip();
          return;
        }
        pos.X -= Configuration.HCOORDBAR;
        pos.Y -= Configuration.VCOORDBAR;
      }

      Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.HGRID);

      if(evt.ControlDown) {
        Globals.track_control_selected(coord);

        return;
      } else if(evt.ShiftDown) {
        if(Globals.track_shift_selected(coord) != 0)
          return;
        Globals.itin_start = coord;
        return;
      } else if(evt.AltDown) {
      }
      if(Globals.editing) {
        Globals.track_place(coord.x, coord.y);
        Globals.field_grid.Paint();
        Refresh();
        evt.Skip();
        return;
      }
      string buff;

      buff = String.Format( wxPorting.T("click %d %d"), coord.x, coord.y);
      Globals.trainsim_cmd(buff);
      evt.Skip();
    }

    public void OnMouseRight(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = evt.Position;
      pos = GetEventPosition(pos);

      // Now pos has the absolute position in the canvas

      if(Globals.bShowCoord) {
        if(pos.X < Configuration.HCOORDBAR || pos.Y < Configuration.VCOORDBAR) {
          // Show popup menu to insert/delete col/row
          CoordMenu(evt, pos.X >= Configuration.HCOORDBAR && pos.Y < Configuration.VCOORDBAR);
          evt.Skip();
          return;
        }
        pos.X -= Configuration.HCOORDBAR;
        pos.Y -= Configuration.VCOORDBAR;
      }

      // convert screen coord to cell coord
      Coord coord = new Coord(pos.X / Configuration.HGRID, pos.Y / Configuration.VGRID);

      if(evt.ControlDown) {
        if(Globals.editing) {
          Track t;
          if(((t = Globals.findTrack(coord.x, coord.y)) != null) || ((t = Globals.findImage(coord.x, coord.y)) != null)) {
            Globals.ShowTrackScriptDialog(t);
            Globals.repaint_all();
            return;
          }
        }
        Globals.track_control_selected(coord);
        return;
      } else if(evt.ShiftDown) {
        if(Globals.track_shift_selected(coord) != 0)
          return;
        Globals.try_itinerary(Globals.itin_start.x, Globals.itin_start.y, coord.x, coord.y);
        return;
      } else if(evt.AltDown) {
      }

      if(Globals.editing_itinerary) {
        Globals.do_itinerary_dialog(coord.x, coord.y);
        evt.Skip();
        return;
      }
      if(Globals.editing) {
        Globals.track_properties(coord.x, coord.y);
        Globals.repaint_all();
        return;
      }
      string buff;

      buff = String.Format( wxPorting.T("rclick %d %d"), coord.x, coord.y);
      Globals.trainsim_cmd(buff);
      evt.Skip();
    }

    public void OnMouseDblLeft(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = evt.Position;
      pos = GetEventPosition(pos);
      // Now pos has the absolute position in the canvas
      evt.Skip();
    }

    public void OnMouseDblRight(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = evt.Position;
      pos = GetEventPosition(pos);
      // Now pos has the absolute position in the canvas
      evt.Skip();
    }

    public void CoordMenu(MouseEvent evt, bool verticalCoord) {
      Menu menu = new Menu();
      MenuItem item;
      Point pt = evt.Position;
      Point pt1 = GetEventPosition(pt);

      Globals.bIsVerticalCoord = verticalCoord;
      if(verticalCoord) {
        m_xyCoord = (pt1.X - Configuration.HCOORDBAR) / Configuration.HGRID;
        item = menu.Append(MenuIDs.MENU_COORD_DEL_1, wxPorting.L("Delete Column"), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_DEL_N, wxPorting.L("Delete Columns..."), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_INS_1, wxPorting.L("Insert Column"), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_INS_N, wxPorting.L("Insert Columns..."), wxPorting.L(""));
      } else {
        m_xyCoord = (pt1.Y - Configuration.VCOORDBAR) / Configuration.VGRID;
        item = menu.Append(MenuIDs.MENU_COORD_DEL_1, wxPorting.L("Delete Row"), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_DEL_N, wxPorting.L("Delete Rows..."), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_INS_1, wxPorting.L("Insert Row"), wxPorting.L(""));
        item = menu.Append(MenuIDs.MENU_COORD_INS_N, wxPorting.L("Insert Rows..."), wxPorting.L(""));
      }

      PopupMenu(menu, pt);
    }

    //
    //
    //

    public void OnCoordDel1(object sender, Event evt) {
      if(Globals.bIsVerticalCoord) {
        Globals.move_start.x = m_xyCoord + 1;
        Globals.move_start.y = 0;
        Globals.move_end.x = Configuration.XNCELLS;
        Globals.move_end.y = Configuration.YNCELLS;
        Globals.move_layout(m_xyCoord, 0);
      } else {
        Globals.move_start.x = 0;
        Globals.move_start.y = m_xyCoord + 1;
        Globals.move_end.x = Configuration.XNCELLS;
        Globals.move_end.y = Configuration.YNCELLS;
        Globals.move_layout(0, m_xyCoord);
      }
      Globals.invalidate_field();
      Globals.repaint_all();
    }

    //
    //
    //

    public void OnCoordDelN(object sender, Event evt) {
//      // for some reason wxNumberEntryDialog is not defined on my RHEL3!
//#if __unix__ || __WXMAC__
//#else
//      wxNumberEntryDialog diag = new wxNumberEntryDialog(this,
//      wxPorting.L("Number of rows/columns to delete?"),
//      wxPorting.L("Enter a number:"), wxPorting.L("Delete rows/columns"),
//      1, 1, Globals.bIsVerticalCoord ? (Configuration.XNCELLS - m_xyCoord - 1) : (Configuration.YNCELLS - m_xyCoord - 1));
//      int inc;

//      if(diag.ShowModal() != wxID_OK)
//        return;
//      inc = diag.GetValue();
//      if(Globals.bIsVerticalCoord) {
//        Globals.move_start.x = m_xyCoord + inc;
//        Globals.move_start.y = 0;
//        Globals.move_end.x = Configuration.XNCELLS;
//        Globals.move_end.y = Configuration.YNCELLS;
//        Globals.move_layout(m_xyCoord, 0);
//      } else {
//        Globals.move_start.x = 0;
//        Globals.move_start.y = m_xyCoord + inc;
//        Globals.move_end.x = Configuration.XNCELLS;
//        Globals.move_end.y = Configuration.YNCELLS;
//        Globals.move_layout(0, m_xyCoord);
//      }
//      Globals.invalidate_field();
//      Globals.repaint_all();
//#endif
    }

    //
    //
    //

    public void OnCoordIns1(object sender, Event evt) {
      if(Globals.bIsVerticalCoord) {
        Globals.move_start.x = m_xyCoord;
        Globals.move_start.y = 0;
        Globals.move_end.x = Configuration.XNCELLS;
        Globals.move_end.y = Configuration.YNCELLS;
        Globals.move_layout(m_xyCoord + 1, 0);
      } else {
        Globals.move_start.x = 0;
        Globals.move_start.y = m_xyCoord;
        Globals.move_end.x = Configuration.XNCELLS;
        Globals.move_end.y = Configuration.YNCELLS;
        Globals.move_layout(0, m_xyCoord + 1);
      }
      Globals.invalidate_field();
      Globals.repaint_all();
    }

    //
    //
    //

    public void OnCoordInsN(object sender, Event evt) {
//      // for some reason wxNumberEntryDialog is not defined on my RHEL3!
//#if __unix__ || __WXMAC__
//#else
//      wxNumberEntryDialog diag = new wxNumberEntryDialog(this,
//          wxPorting.L("Number of rows/columns to insert?"),
//          wxPorting.L("Enter a number:"), wxPorting.L("Insert rows/columns"),
//          1, 1, Globals.bIsVerticalCoord ? (Configuration.XNCELLS - m_xyCoord - 1) : (Configuration.YNCELLS - m_xyCoord - 1));
//      int inc;

//      if(diag.ShowModal() != wxID_OK)
//        return;
//      inc = diag.GetValue();
//      if(Globals.bIsVerticalCoord) {
//        Globals.move_start.x = m_xyCoord;
//        Globals.move_start.y = 0;
//        Globals.move_end.x = Configuration.XNCELLS;
//        Globals.move_end.y = Configuration.YNCELLS;
//        Globals.move_layout(m_xyCoord + inc, 0);
//      } else {
//        Globals.move_start.x = 0;
//        Globals.move_start.y = m_xyCoord;
//        Globals.move_end.x = Configuration.XNCELLS;
//        Globals.move_end.y = Configuration.YNCELLS;
//        Globals.move_layout(0, m_xyCoord + inc);
//      }
//      Globals.invalidate_field();
//      Globals.repaint_all();
//#endif
    }

    //
    //
    //

    public void OnChar(object sender, Event evt1) {
      //KeyEvent ev = (KeyEvent)evt1;
      //int flags = 0;
      //int x, y;

      //if(ev.ControlDown)
      //  flags |= 1;
      //if(ev.ShiftDown)
      //  flags |= 2;
      //if(ev.AltDown)
      //  flags |= 4;

      //switch(ev.KeyCode) {
      //  case (int)wx.KeyCode.WXK_LEFT:

      //    if(ev.ControlDown) {
      //      GetViewStart(ref x, ref y);
      //      x -= 200;
      //      if(x < 0)
      //        x = 0;
      //      Scroll(x, y);
      //      break;
      //    }
      //    ev.Skip();
      //    break;

      //  case (int)wx.KeyCode.WXK_RIGHT:

      //    if(ev.ControlDown) {
      //      GetViewStart(ref x, ref y);
      //      x += 200;
      //      if(x < 0)
      //        x = 0;
      //      Scroll(x, y);
      //      break;
      //    }
      //    ev.Skip();
      //    break;

      //  case (int)wx.KeyCode.WXK_UP:

      //    if(ev.ControlDown) {
      //      GetViewStart(ref x, ref y);
      //      y -= 200;
      //      if(y < 0)
      //        y = 0;
      //      Scroll(x, y);
      //      break;
      //    }
      //    ev.Skip();
      //    break;

      //  case (int)wx.KeyCode.WXK_DOWN:

      //    if(ev.ControlDown) {
      //      GetViewStart(ref x, ref y);
      //      y += 200;
      //      Scroll(x, y);
      //      break;
      //    }
      //    ev.Skip();
      //    break;

      //  case 0x1b:
      //    Globals.trainsim_cmd(wxPorting.T("run"));
      //    ev.Skip();
      //    break;

      //  case '7':
      //    if(ev.ControlDown)
      //      Scroll(0, 0);		// upper left corner
      //    break;

      //  case '1':
      //    if(ev.ControlDown)	// lower left corner
      //      Scroll(0, 0);
      //    break;

      //  case '9':
      //    if(ev.ControlDown)	// upper right corner
      //      Scroll(0, 0);
      //    break;

      //  case '3':
      //    if(ev.ControlDown)	// lower right corner
      //      Scroll(0, 0);
      //    break;

      //  default:
      //    ev.Skip();
      //    break;
      //}
    }

    public void DoPrint() {
    //  if(Globals.gSaveImageFileDialog == null) {
    //    Globals.gSaveImageFileDialog = new wx.FileDialog(Globals.traindir.m_frame, wxPorting.L("Save Image"), wxPorting.T(""), wxPorting.T(""),
    //  wxPorting.T("PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|Bitmap file (*.bmp)|*.bmp|GIF image (*.gif)|*.gif|All Files (*.*)|*.*"),
    //  WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
    //  }
    //  if(Globals.gSaveImageFileDialog.ShowModal() != ShowModalResult.OK)
    //    return;
    //  String path = Globals.gSaveImageFileDialog.Path;
    //  wxRect bounds;
    //  wx.Bitmap srcbitmap = Globals.field_grid.m_pixmap;
    //  bounds.Height = 0;
    //  bounds.Width = 0;
    //  bounds.X = srcbitmap.Width; ;
    //  bounds.Y = srcbitmap.Height;
    //  Track trk;
    //  for(trk = Globals.layout; trk != null; trk = trk.next) {
    //    if(trk.x * Globals.field_grid.m_hmult < bounds.X)
    //      bounds.X = trk.x * Globals.field_grid.m_hmult;
    //    if(trk.y * Globals.field_grid.m_vmult < bounds.Y)
    //      bounds.Y = trk.y * Globals.field_grid.m_hmult;
    //    if((trk.x + 1) * Globals.field_grid.m_hmult > bounds.Width)
    //      bounds.Width = (trk.x + 1) * Globals.field_grid.m_hmult;
    //    if((trk.y + 1) * Globals.field_grid.m_vmult > bounds.Height)
    //      bounds.Height = (trk.y + 1) * Globals.field_grid.m_hmult;
    //  }
    //  bounds.Width -= bounds.X;
    //  bounds.Height -= bounds.Y;
    //  // give the image a 2-square border
    //  bounds.X -= Globals.field_grid.m_hmult * 2;
    //  if(bounds.X < 0) bounds.X = 0;
    //  bounds.Y -= Globals.field_grid.m_vmult * 2;
    //  if(bounds.Y < 0) bounds.Y = 0;
    //  bounds.Width += Globals.field_grid.m_hmult * 2;
    //  bounds.Height += Globals.field_grid.m_vmult * 2;
    //  bounds.Width += Globals.field_grid.m_xBase;
    //  bounds.Height += Globals.field_grid.m_yBase;
    //  wx.Bitmap submap = srcbitmap.GetSubBitmap(bounds);
    //  wx.BitmapType type = BitmapType.wxBITMAP_TYPE_BMP;
    //  if(Globals.wxStrstr(path, wxPorting.T(".gif")))
    //    type = BitmapType.wxBITMAP_TYPE_GIF;
    //  if(Globals.wxStrstr(path, wxPorting.T(".png")))
    //    type = BitmapType.wxBITMAP_TYPE_PNG;
    //  if(Globals.wxStrstr(path, wxPorting.T(".jpg")))
    //    type = BitmapType.wxBITMAP_TYPE_JPEG;
    //  submap.SaveFile(path, type, null);
    }
  }

  /////////////////////////////////////////////////////////////////////////////

  public partial class TDSkin {
    public TDSkin next;
    public string name;
    public int free_track;		// default: black
    public int reserved_track;		// default: green
    public int reserved_shunting;	// default: white
    public int occupied_track;		// default: orange
    public int working_track;		// default: blue
    public int background;		// default: gray
    public int outline;		// default: dark_gray
    public int text;			// default: black

    public TDSkin() {
      if(Globals.defaultSkin == null)
        return;
      this.next = null;
      this.name = null;
      this.free_track = Globals.defaultSkin.free_track;
      this.reserved_track = Globals.defaultSkin.reserved_track;
      this.reserved_shunting = Globals.defaultSkin.reserved_shunting;
      this.occupied_track = Globals.defaultSkin.occupied_track;
      this.working_track = Globals.defaultSkin.working_track;
      this.background = Globals.defaultSkin.background;
      this.outline = Globals.defaultSkin.outline;
    }

    ~TDSkin() {
      if(name != null)
        Globals.free(name);
      name = null;
    }
  }



}