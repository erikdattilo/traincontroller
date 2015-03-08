using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;
using System.Drawing;

namespace TrainController {

  public class grid {

    public void CellToCoord(ref int x, ref int y) {
      x = (x * m_hmult) + m_xBase;
      y = (y * m_vmult) + m_yBase;
    }

    public System.Drawing.Bitmap m_pixmap;
    public object/*Window*/ m_parent;
    public Graphics /*MemoryDC*/ m_dc;
    public int m_hmult, m_vmult;
    public int m_xBase, m_yBase;



    public grid(Window parent)
      : this(parent, Configuration.XMAX, Configuration.YMAX) {
    }

    public grid(object/*Window*/ parent, int width, int height) {
      m_pixmap = new System.Drawing.Bitmap(width, height);
      m_parent = parent;
      m_dc = Graphics.FromImage(m_pixmap); // new MemoryDC();

      m_hmult = 1;
      m_vmult = 1;

      m_xBase = 0;
      m_yBase = 0;
    }

    ~grid() {
      m_pixmap = null;
      m_dc = null;
    }

    public void Paint(Window dest) {
      Paint(dest, false);
    }

    public void Paint(Window dest, bool fillBg) {
      throw new NotImplementedException("Use the other overload (System.Drawing.Bitmap");
//      // Erik's replacement code.
//      // TODO Check if this is a really equivalent code...
//#if DEBUG
//      // TODO Check following code
//      // This (useless) code seems to be needed to properly update the drawing area
//      //using(MemoryDC dc = new MemoryDC()) {
//      //  dc.SelectObject(m_pixmap);
//      //  dc.SelectObject(wx.Bitmap.NullBitmap);
//      //}

//      using(PaintDC dc = new PaintDC(dest)) {
//        dc.DrawBitmap(m_pixmap, 0, 0);

//        // Erik: Test code
//        dc.Pen = new wx.Pen(wx.Colour.wxGREEN, 100);
//        dc.DrawLine(0, 0, 1000, 1000);

//      }
//      // dc.Dispose(); //needed <-- Erik: Replaced with 'using' pattern
//#else
//#if WIN32
//      BufferedPaintDC dc = new BufferedPaintDC(dest);
//#else
//        wx.ClientDC   dc(dest);
//#endif

//      dest.PrepareDC(dc);
//      BufferedDC wdc = new BufferedDC(dc, m_pixmap);
//#endif
    }

    public void Paint(Graphics graphics) {
      graphics.DrawImage(m_pixmap, 0, 0);
    }

    public void DrawText1(int x, int y, String txt, bool size) {
      throw new NotImplementedException();
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
      throw new NotImplementedException();
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
      throw new NotImplementedException();
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
      throw new NotImplementedException();

      //wx.Font font = new wx.Font(size ? Globals.gFontSizeSmall : Globals.gFontSizeBig, wx.FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL);
      //m_dc.SelectObject(m_pixmap);
      //m_dc.SetFont(font);
      //int x, y;
      //String str = String.Copy(txt);
      //m_dc.GetTextExtent(str, out x, out y);
      //m_dc.SelectObject(wx.Bitmap.NullBitmap);
      //outCoord.x = x;
      //outCoord.y = y;
    }

    public void DrawLayoutRGB(int x0, int y0, VLines[] q, int rgb) {
      VLines p;
      wxRect update_rect;
      Color fg = Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      m_dc.SetPen(new System.Drawing.Pen(fg, 1));
      for(int i = 0; i < q.Length; i++) {
        p = q[i];
        m_dc.DrawLine(
          x + p.x0 * m_hmult / Configuration.HGRID,
          y + p.y0 * m_vmult / Configuration.VGRID,
          x + p.x1 * m_hmult / Configuration.HGRID,
          y + p.y1 * m_vmult / Configuration.VGRID
        );
        m_dc.DrawPoint(x + p.x1 * m_hmult / Configuration.HGRID,
          y + p.y1 * m_vmult / Configuration.VGRID);
      }
    }



    public void DrawLayout(int x0, int y0, VLines[] p, grcolor col) {
      DrawLayoutRGB(x0, y0, p, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] << 8) | Globals.colortable[col][2]);
    }

    public void DrawLineRGB(int x0, int y0, int x1, int y1, int rgb) {
      Color fg = Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      m_dc.SetPen(new System.Drawing.Pen(fg, 1));
      m_dc.DrawLine(x, y, x1 * m_hmult, y1 * m_vmult);
      m_dc.DrawPoint(x1 * m_hmult, y1 * m_vmult);
    }

    public void DrawLine(int x0, int y0, int x1, int y1, grcolor col) {
      DrawLineRGB(x0, y0, x1, y1, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] | 8) | Globals.colortable[col][2]);
    }

    public void DrawLineCenterCellRGB(int x0, int y0, int x1, int y1, int rgb) {
      Color fg = Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int mx = Configuration.HGRID / 2;
      int my = Configuration.VGRID / 2;
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      CellToCoord(ref x1, ref y1);
      m_dc.SetPen(new System.Drawing.Pen(fg, 1));
      m_dc.DrawLine(x + mx, y + my, x1 /* * m_hmult */ + mx, y1 /* * m_vmult */ + my);
    }

    public void DrawLineCenterCell(int x0, int y0, int x1, int y1, grcolor col) {
      DrawLineCenterCellRGB(x0, y0, x1, y1, (Globals.colortable[col][0] << 16) | (Globals.colortable[col][1] << 8) | Globals.colortable[col][2]);
    }

    public void DrawPoint(int x0, int y0, int dx, int dy, int rgb) {
      wxRect update_rect;
      Color fg = Color.FromArgb((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      x += m_hmult / 2 + dx;
      y += m_vmult / 2 + dy;
      m_dc.SetPen(new System.Drawing.Pen(fg, 1));
      m_dc.DrawPoint(x, y);
    }
    public void FillCell(int x, int y) {
      CellToCoord(ref x, ref y);
      wxRect rect = new wxRect(x, y, m_hmult, m_vmult);
      Color background_color;
      Globals.setBackgroundColor(out background_color);
      m_dc.SetBrush(new System.Drawing.SolidBrush(background_color));
      m_dc.SetPen(new System.Drawing.Pen(background_color, 1));
      m_dc.DrawRectangle(rect);
    }

    public void Clear() {
      Color bg;
      Globals.setBackgroundColor(out bg);
      m_dc.SetBrush(new SolidBrush(bg));
      Rectangle rect = new Rectangle(new Point(0, 0), new Size(m_pixmap.Width, m_pixmap.Height));
      m_dc.DrawRectangle(rect);
    }


    public void ClearField() {
      Color bg;
      Globals.setBackgroundColor(out bg);
      //	bg = g.dc.GetBackground();
      m_dc.SetBrush(new SolidBrush(bg));
      wxRect rect = new wxRect(
            Globals.cliprect.left * m_hmult,
            Globals.cliprect.top * m_vmult,
            (Globals.cliprect.right - Globals.cliprect.left + 1) * m_hmult,
            (Globals.cliprect.bottom - Globals.cliprect.top + 1) * m_vmult
            );
      m_dc.DrawRectangle(rect);
    }

    //	Draw the point grid in the canvas.
    //	This gives the player a reference
    //	for positioning track elements.
    //	Only called if the corresponding
    //	option in Preferences is set.

    public void Paint() {
      int x, y;
      Color bg = Color.FromArgb(Globals.colortable[Globals.color_darkgray][0], Globals.colortable[Globals.color_darkgray][1], Globals.colortable[Globals.color_darkgray][2]);

      m_dc.SetBrush(new SolidBrush(bg));
      m_dc.SetPen(new System.Drawing.Pen(bg, 1));
      for(x = m_xBase; x < Configuration.XMAX; x += Configuration.HGRID)
        for(y = m_yBase; y < Configuration.YMAX; y += Configuration.VGRID)
          if(x >= Globals.cliprect.left * Configuration.HGRID && x <= Globals.cliprect.right * Configuration.HGRID &&
             y >= Globals.cliprect.top * Configuration.VGRID && y <= Globals.cliprect.bottom * Configuration.VGRID)
            m_dc.DrawPoint(x, y);
    }

  }

}
