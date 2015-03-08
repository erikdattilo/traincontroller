using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrainController {
  public static class z___ExtensionMethods {
    public static bool IsNullOrWhiteSpaces(this String str) {
      return (str == null) || str.Trim().Length == 0;
    }

    public static Bitmap ToWindowsBitmap(this wx.Bitmap bitmap) {
      Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height);
      Graphics gr = Graphics.FromImage(bmp);
      gr.Clear(Color.Brown);
      return bmp;
    }

    private static Dictionary<Graphics, Brush> z_CurrentBrush = new Dictionary<Graphics, Brush>();
    private static Dictionary<Graphics, Pen> z_CurrentPen = new Dictionary<Graphics, Pen>();
    private static Dictionary<Graphics, Font> z_CurrentFont = new Dictionary<Graphics, Font>();

    public static void DrawRectangle(this Graphics gr, int x, int y, int widht, int height) {
      gr.DrawRectangle(z_CurrentPen[gr], x, y, widht, height);
    }

    public static void SetPen(this Graphics gr, Pen pen) {
      if(z_CurrentBrush.ContainsKey(gr))
        z_CurrentPen[gr] = pen;
      else
        z_CurrentPen.Add(gr, pen);
    }

    public static void SetBrush(this Graphics gr, Brush brush) {
      if(z_CurrentBrush.ContainsKey(gr))
        z_CurrentBrush[gr] = brush;
      else
        z_CurrentBrush.Add(gr, brush);
    }

    public static void SetFont(this Graphics gr, Font font) {
      if(z_CurrentFont.ContainsKey(gr))
        z_CurrentFont[gr] = font;
      else
        z_CurrentFont.Add(gr, font);
    }

    public static void SetBackgroundMode(this Graphics gr, wx.DCBackgroundMode mode) {
      throw new NotImplementedException();
    }

    public static void SetBackgroundMode(this Graphics gr, int mode) {
      throw new NotImplementedException();
    }

    public static void SetTextForeground(this Graphics gr, wx.Colour color) {
      throw new NotImplementedException();
    }

    public static void SetTextBackground(this Graphics gr, wx.Colour color) {
      throw new NotImplementedException();
    }

    public static void DrawText(this Graphics gr, string buff, Point pt) {
      throw new NotImplementedException();
    }

    public static void DrawPoint(this Graphics gr, int x, int y) {
      throw new NotImplementedException();
    }

    public static void DrawLine(this Graphics gr, int x1, int y1, int x2, int y2) {
      throw new NotImplementedException();
    }

    public static void DrawRectangle(this Graphics gr, wx.wxRect rect) {
      gr.DrawRectangle(rect.X, rect.Y, rect.Width, rect.Height);
    }

    public static void DrawRectangle(this Graphics gr, Rectangle rect) {
      throw new NotImplementedException();
    }

    public static void DrawImage(this Graphics gr, Bitmap bmp, int x, int y) {
      gr.DrawImage(bmp, x, y);
    }
  }

  public static class String1 {
    public static bool IsNullOrWhiteSpaces(String str) {
      return (str == null) || str.Trim().Length == 0;
    }
  }
}
