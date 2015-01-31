using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;
using wx.SampleDialogs;

namespace TrainDirNET {
  public class grid {
    public wx.Bitmap m_pixmap;
    public Window m_parent;
    public MemoryDC m_dc;
    public int m_hmult, m_vmult;
    public int m_xBase, m_yBase;

    public grid(Window parent) :
      this(parent, Configuration.XMAX, Configuration.YMAX) {
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


    // cell coord to canvas coord
    void CellToCoord(ref int x, ref int y) {
      x = (x * m_hmult) + m_xBase;
      y = (y * m_vmult) + m_yBase;
    }

    public void FillCell(int x, int y) {
      CellToCoord(ref x, ref y);
      m_dc.SelectObject(m_pixmap);
      wxRect rect = new wxRect(x, y, m_hmult, m_vmult);
      Colour background_color = new Colour();
      GlobalFunctions.setBackgroundColor(background_color);
      m_dc.SetBrush(new wx.Brush(background_color));
      m_dc.SetPen(new wx.Pen(background_color, 1));
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void Clear() {
      Colour bg = new Colour();
      GlobalFunctions.setBackgroundColor(bg);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetBrush(new wx.Brush(bg));
      Rectangle rect = new Rectangle(new Point(0, 0), new Size(m_pixmap.Width, m_pixmap.Height));
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(null);
    }

    public void Paint(Window dest) {
      Paint(dest, false);
    }

    public void Paint(Window dest, bool fillBg) {
      // TestProgram.TestSomething3(this, dest, fillBg);
      // TestProgram.TestSomething4(this, dest, fillBg);
      //#if WIN32
      //        wxBufferedPaintDC   dc(dest);
      //#else
      //      ClientDC dc = new ClientDC(dest);
      //#endif

      //      dest.PrepareDC(dc);
      //      BufferedDC wdc = new BufferedDC(dc, m_pixmap);

      // Erik's (temporary) patch

      PaintDC dc2 = new PaintDC(dest);
      MemoryDC mDC = new MemoryDC();
      wx.Bitmap bitmap = GlobalVariables.current_grid.m_pixmap;
      mDC.SelectObject(bitmap);
      dc2.DrawBitmap(bitmap, 0, 0, true);
      // mDC.DrawRectangle(10, 10, 100, 100);
      mDC.SelectObject(wx.Bitmap.NullBitmap);

      dc2.DrawBitmap(bitmap, 30, 30);

      mDC.Dispose();
      dc2.Dispose(); //needed
    }


    public void ClearField() {
      Colour bg = new Colour();
      GlobalFunctions.setBackgroundColor(bg);
      m_dc.SelectObject(m_pixmap);
      //	bg = g.dc.GetBackground();
      m_dc.SetBrush(new wx.Brush(bg));
      Rectangle rect = new Rectangle(
            GlobalVariables.cliprect.left * m_hmult,
            GlobalVariables.cliprect.top * m_vmult,
            (GlobalVariables.cliprect.right - GlobalVariables.cliprect.left + 1) * m_hmult,
            (GlobalVariables.cliprect.bottom - GlobalVariables.cliprect.top + 1) * m_vmult
            );
      m_dc.DrawRectangle(rect);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }


    public void Paint() {
      int x, y;
      Colour bg = new Colour(
        GlobalVariables.colortable[GlobalVariables.color_darkgray][0],
        GlobalVariables.colortable[GlobalVariables.color_darkgray][1],
        GlobalVariables.colortable[GlobalVariables.color_darkgray][2]);

      m_dc.SelectObject(m_pixmap);
      m_dc.SetBrush(new wx.Brush(bg));
      m_dc.SetPen(new wx.Pen(bg, 1));
      for(x = m_xBase; x < Configuration.XMAX; x += Configuration.HGRID)
        for(y = m_yBase; y < Configuration.YMAX; y += Configuration.VGRID)
          if(x >= GlobalVariables.cliprect.left * Configuration.HGRID && x <= GlobalVariables.cliprect.right * Configuration.HGRID &&
           y >= GlobalVariables.cliprect.top * Configuration.VGRID && y <= GlobalVariables.cliprect.bottom * Configuration.VGRID)
            m_dc.DrawPoint(x, y);
      /// TODO Correct this for everyone. Look in original sources
      // m_dc.SelectObject(wxNullBitmap);
      m_dc.SelectObject(null);
    }

    public void DrawLayoutRGB(int x0, int y0, VLines[] p1, int rgb) {
      wxRect update_rect;
      Colour fg = new Colour(
        (byte)(rgb >> 16),
        (byte)((rgb >> 8) & 0xFF),
        (byte)(rgb & 0xFF)
      );

      int x = x0;
      int y = y0;

      CellToCoord(ref x, ref y);
      m_dc.SelectObject(m_pixmap);
      m_dc.SetPen(new wx.Pen(fg, 1));
      for(int i = 0; i < p1.Length && p1[i].x0 >= 0; i++) {
        VLines p = p1[i];
        m_dc.DrawLine(
      (int)(x + p.x0 * m_hmult / Configuration.HGRID),
      (int)(y + p.y0 * m_vmult / Configuration.VGRID),
      (int)(x + p.x1 * m_hmult / Configuration.HGRID),
      (int)(y + p.y1 * m_vmult / Configuration.VGRID)
      );
        m_dc.DrawPoint(
          (int)(x + p.x1 * m_hmult / Configuration.HGRID),
      (int)(y + p.y1 * m_vmult / Configuration.VGRID)
      );
      }
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawText1(int x, int y, string txt, int size) {
      //CellToCoord(ref x, ref y);
      //if(this != tools_grid)
      //  y -= (size ? 3 : 4);
      //wx.Font font = new wx.Font(
      //  size ? GlobalVariables.gFontSizeSmall : GlobalVariables.gFontSizeBig,
      //  wx.FontFamily.SWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL
      //);
      //m_dc.SelectObject(m_pixmap);
      //m_dc.SetFont(font);
      //m_dc.SetBackgroundMode(wxTRANSPARENT);
      //m_dc.SetTextForeground(curSkin.text);
      //m_dc.SetTextBackground(*wxWHITE);
      //wxPoint pt = new wxPoint(x, y);
      //m_dc.DrawText(txt, pt);
      //m_dc.SelectObject(wx.Bitmap.NullBitmap);
    }

    public void DrawTextFont(int x, int y, string txt, int fontIndex) {
      //  FontEntry *f = fonts.FindFont(fontIndex);
      ////	if(!f) {
      //      DrawText1(x, y, txt, fontIndex == 1);
      //      return;
      ////	}

      //  CellToCoord(x, y);
      //  y -= f._size / 2;
      //  wxFont	font(f._size, f._family, f._style, f._weight);
      //  m_dc.SelectObject(*m_pixmap);
      //  m_dc.SetFont(font);
      //  m_dc.SetBackgroundMode(wxTRANSPARENT);
      //  m_dc.SetTextForeground(f._color); // *wxBLACK);
      //  m_dc.SetTextBackground(*wxWHITE);
      //  wxPoint	pt(x, y);
      //  m_dc.DrawText(txt, pt);
      //  m_dc.SelectObject(wxNullBitmap);
    }
    public void DrawLineCenterCellRGB(int x0, int y0, int x1, int y1, int rgb) {
      //  wxColour fg(rgb >> 16, (rgb >> 8) & 0xFF, rgb & 0xFF);
      //  int	mx = HGRID / 2;
      //  int	my = VGRID / 2;
      //  int	x = x0;
      //  int	y = y0;

      //  CellToCoord(x, y);
      //  CellToCoord(x1, y1);
      //  m_dc.SelectObject(*m_pixmap);
      //  m_dc.SetPen(wxPen(fg, 1));
      //  m_dc.DrawLine(x + mx, y + my, x1 /* * m_hmult */ + mx, y1 /* * m_vmult */ + my);
      //  m_dc.SelectObject(wxNullBitmap);
    }

    public void DrawLineCenterCell(int x0, int y0, int x1, int y1, grcolor col) {
      // DrawLineCenterCellRGB(x0, y0, x1, y1, (colortable[col][0] << 16) | (colortable[col][1] << 8) | colortable[col][2]);
    }

    public void DrawPoint(int x0, int y0, int dx, int dy, int rgb) {
      //wxRect update_rect;
      //wxColour fg(rgb >> 16, (rgb >> 8) & 0xFF, rgb & 0xFF);
      //int	x = x0;
      //int	y = y0;

      //CellToCoord(x, y);
      //      x += m_hmult / 2 + dx;
      //      y += m_vmult / 2 + dy;
      //m_dc.SelectObject(*m_pixmap);
      //m_dc.SetPen(wxPen(fg, 1));
      //      m_dc.DrawPoint(x, y);
      //m_dc.SelectObject(wxNullBitmap);
    }


    public void GetTextExtent(string txt, int size, Coord outCoord) {
      wx.Font font = new wx.Font(
        size != 0 ? GlobalVariables.gFontSizeSmall : GlobalVariables.gFontSizeBig,
        wx.FontFamily.wxSWISS,
        wx.FontStyle.wxNORMAL,
        FontWeight.wxNORMAL
      );
      m_dc.SelectObject(m_pixmap);
      m_dc.SetFont(font);
      int x, y;
      string str = string.Copy(txt);
      m_dc.GetTextExtent(str, out x, out y);
      m_dc.SelectObject(wx.Bitmap.NullBitmap);
      outCoord.x = (int)x;
      outCoord.y = (int)y;
    }
  }
}