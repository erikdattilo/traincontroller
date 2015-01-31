using wx;
using System.Drawing;
using System.IO;
using System;
using TrainDirNET;
using System.Collections.Generic;
using System.Text;

namespace wx.SampleDialogs {
  // namespace TrainDirNET.Tests {
  class TestProgram : wx.App {
    public override bool OnInit() {
      MyFrame frame = new MyFrame();
      frame.Show(true);

      GlobalVariables.traindir = new TrainDir();
      GlobalVariables.traindir.OnInit();
      GlobalVariables.traindir.OnOpenFile();

      return true;
    }

    public static void TestSomething() {
      NotebookManager top = GlobalVariables.traindir.m_frame.m_top;
      int id = top.FindPage("Layout");
      PaintDC dc = new PaintDC(top.GetPage(id));

      // dc.Font = font;
      // dc.TextForeground = textColour;
      dc.BackgroundMode = DCBackgroundMode.TRANSPARENT;

      dc.BackgroundMode = DCBackgroundMode.SOLID;
      dc.Background = new Brush(new Colour(0x80, 0, 0));
      dc.Clear();

      dc.DrawText("wxWidgets common dialogs test application", 10, 10);

      dc.Dispose(); //needed      
    }

    public static void TestSomething2() {
#if true
        ClientDC dc = new ClientDC(GlobalVariables.field_grid.m_parent);
        Pen pen = new Pen(new Colour(0xF0, 0x00, 0x00), 1); // red pen of width 1
        dc.Background = new Brush(new Colour(0x00, 0x00, 0xFF));
        dc.BackgroundMode = DCBackgroundMode.SOLID;
        dc.Clear();
        dc.SetPen(pen);
        dc.DrawPoint(10, 10);
        dc.DrawRectangle(2, 2, 100, 100);
        // dc.SetPen(wx.Pen.null);
        dc.Dispose();
        return;
#endif

      grid g;
      g = GlobalVariables.field_grid;
#if true
      g.m_parent.BackgroundStyle = BackgroundStyle.wxBG_STYLE_COLOUR;
      g.m_parent.BackgroundColour = new Colour(0x00, 0x80, 0x00);
#endif

#if true
      g.m_pixmap = new Bitmap(500, 500);
      MemoryDC mDC = new MemoryDC();
      Bitmap bitmap = g.m_pixmap;
      mDC.SelectObject(bitmap);
      // dc.DrawBitmap(bitmap, 0, 0, true);
      mDC.SetBrush(new Brush(new Colour(0xFF, 0x00, 0x00)));
      mDC.DrawRectangle(10, 10, 100, 100);
      mDC.SelectObject(Bitmap.NullBitmap);
      // dc.DrawBitmap(bitmap, 30, 30);
      mDC.Dispose();
#endif
      ClientDC clientDC = new ClientDC(g.m_parent);
      ScrolledWindow w = (ScrolledWindow)g.m_parent;
      w.PrepareDC(clientDC);
      BufferedDC wdc = new BufferedDC(clientDC, g.m_pixmap);


#if true
      wdc.DrawBitmap(bitmap, 10, 10);

      wdc.Dispose();
      wdc = null;
#endif
    }
    public static bool debug = false;
    public static void TestSomething3(grid g, Window dest, bool fillBg) {
      if(!debug)
        return;

      TestSomething2();
      ClientDC dc = new ClientDC(dest);
      dest.PrepareDC(dc);
      BufferedDC wdc = new BufferedDC(dc, g.m_pixmap);
    }

    private static DateTime mLastTime = DateTime.MinValue;
    public static void TestSomething4(grid grid, Window dest, bool fillBg) {
      PaintDC dc2 = new PaintDC(dest);
      dc2.BackgroundMode = DCBackgroundMode.SOLID;
      dc2.Background = new Brush(new Colour(0x80, 0, 0));
      dc2.Clear();

#if false
      MemoryDC mDC = new MemoryDC();
      Bitmap bitmap = null; // new Bitmap(img, -1);
      bitmap = GlobalVariables.current_grid.m_pixmap;
      mDC.SelectObject(bitmap);
      dc2.DrawBitmap(bitmap, 0, 0, true);
      // mDC.DrawRectangle(10, 10, 100, 100);
      mDC.SelectObject(Bitmap.NullBitmap);

      dc2.DrawBitmap(bitmap, 30, 30);



      mDC.Dispose();
      dc2.Dispose(); //needed
#else

      if((DateTime.Now - mLastTime).TotalMilliseconds < 500)
        return;

      try {
#if WIN32
              wxBufferedPaintDC   dc(dest);
#else
        ClientDC dc = new ClientDC(dest);
#endif

        dest.PrepareDC(dc);
        BufferedDC wdc = new BufferedDC(dc, grid.m_pixmap);
      } catch(Exception) {
      }
#endif
      return;


      if((DateTime.Now - mLastTime).TotalMilliseconds < 500)
        return;

      try {
#if WIN32
              wxBufferedPaintDC   dc(dest);
#else
        ClientDC dc = new ClientDC(dest);
#endif

        dest.PrepareDC(dc);
        BufferedDC wdc = new BufferedDC(dc, grid.m_pixmap);
      } catch(Exception) {
      }
      mLastTime = DateTime.Now;
    }
  }

  public class MyFrame : Frame {
    private MyCanvas canvas;

    //---------------------------------------------------------------------

    public MyFrame()
      : this("wxWidgets Dialogs Example", new Point(50, 50), new Size(450, 340)) {
    }

    public MyFrame(string title, Point pos, Size size)
      : base(title, pos, size) {
      // Create the canvas for drawing
      canvas = new MyCanvas(this);
    }
  }

  public class MyCanvas : ScrolledWindow {
    public Font font;
    public Colour textColour;

    public MyCanvas(Window parent)
      : base(parent) {
      font = Font.wxNORMAL_FONT;
      textColour = new Colour(0, 0, 0);

      EVT_PAINT(new EventListener(OnPaint));
    }

    public void OnPaint(object sender, Event e) {
      PaintDC dc = new PaintDC(this);
      
      dc.Font = font;
      dc.TextForeground = textColour;
      dc.BackgroundMode = DCBackgroundMode.TRANSPARENT;

      dc.BackgroundMode = DCBackgroundMode.SOLID;
      dc.Background = new Brush(new Colour(0x80, 0, 0));
      dc.Clear();

      dc.DrawText("wxWidgets common dialogs test application", 10, 10);

      Image img;
      // img = new Image(50, 50);
      img = GlobalFunctions.get_pixmap(GlobalVariables.itin_xpm);

      List<byte> list = new List<byte>();
      ASCIIEncoding encoder = new ASCIIEncoding();

      byte[] terminator = new byte[] { 0x10, 0x13 };
      list.Clear();
      list.AddRange(encoder.GetBytes("/* XPM */")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("static char * plaid[] = {")); list.AddRange(terminator);
//      list.AddRange(encoder.GetBytes("/* plaid pixmap ")); list.AddRange(terminator);
//      list.AddRange(encoder.GetBytes(" * width height ncolors chars_per_pixel */")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"22 22 5 2\",")); list.AddRange(terminator);
//      list.AddRange(encoder.GetBytes("/* colors */")); list.AddRange(terminator);
#if false
      list.AddRange(encoder.GetBytes("\".  c red       m white  s light_color \",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"Y  c green     m black  s lines_in_mix \",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"+  c yellow    m white  s lines_in_dark \",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"x              m black  s dark_color \",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"   c none               s mask \",")); list.AddRange(terminator);
#else
      list.AddRange(encoder.GetBytes("\".      c lightgray\",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"Y      c #000000000000\",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"+      c #000000000000\",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"x      c #000000000000\",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"       c #000000000000\",")); list.AddRange(terminator);
#endif
//      list.AddRange(encoder.GetBytes("/* pixels */")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"                      x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"                    . x x x x x x x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"                  . x x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"                . x . x x x x x x x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"              . x . x x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"            Y Y Y Y Y + x + x + x + x + x + \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"          x x . x . x x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"        . x . x . x . x x x x x x x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"      . x x x . x . x x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"    . x . x . x . x . x x x x x x x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"  . x . x x x . x . x x x x x x + x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . . x . x . Y . x . x . \",")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . . x . x . Y . x . x . \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\"x x x x x x x x x x x x x x x x x x x x x x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . . x . x . Y . x . x . \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . . x . x . Y . x . x . \", ")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("\". . . . . x . . . . . x . x . x Y x . x . x \"")); list.AddRange(terminator);

      byte[] data = list.ToArray();
      string debugData = encoder.GetString(data);
      img = new Image(data, BitmapType.wxBITMAP_TYPE_XPM);

      img = ConvertFormat(GlobalVariables.itin_xpm);


      MemoryDC mDC = new MemoryDC();
      Bitmap bitmap = new Bitmap(img, -1);
bitmap = GlobalVariables.current_grid.m_pixmap;
      mDC.SelectObject(bitmap);
      dc.DrawBitmap(bitmap, 0, 0, true);
      // mDC.DrawRectangle(10, 10, 100, 100);
      mDC.SelectObject(Bitmap.NullBitmap);

      dc.DrawBitmap(bitmap, 30, 30);



      mDC.Dispose();
      dc.Dispose(); //needed
    }

    private Image ConvertFormat(string[] pixmax) {
      List<byte> list = new List<byte>();
      ASCIIEncoding encoder = new ASCIIEncoding();

      byte[] terminator = new byte[] { 0x10, 0x13 };
      list.Clear();
      list.AddRange(encoder.GetBytes("/* XPM */")); list.AddRange(terminator);
      list.AddRange(encoder.GetBytes("static char * dummy[] = {")); list.AddRange(terminator);
      foreach(string line in pixmax) {
        list.AddRange(encoder.GetBytes("\"" + line + "\",")); list.AddRange(terminator);
      }

      return new Image(list.ToArray(), BitmapType.wxBITMAP_TYPE_XPM);
    }

    public static void draw_pixmap(int x0, int y0, object map) {
      Image img = (Image)map;
      //grid g = GlobalVariables.current_grid;
      //int x = x0 * g.m_hmult + g.m_xBase;
      //int y = y0 * g.m_vmult + g.m_yBase;

      //if(!img.Ok)
      //  return;
      //if(g.m_pixmap == null)
      //  return;
      //if(g.m_dc != null)
      //  g.m_dc = new MemoryDC();
      //if(g == GlobalVariables.tools_grid && y0 != 0 && x0 < 8) {
      //  x += GlobalVariables.tools_grid.m_hmult / 2;
      //  y += GlobalVariables.tools_grid.m_vmult / 2;
      //}
      //Bitmap bitmap = new Bitmap(img, -1);
      //g.m_dc.SelectObject(g.m_pixmap);
      //g.m_dc.DrawBitmap(bitmap, x, y, true);
      //g.m_dc.SelectObject(Bitmap.NullBitmap);
    }
  }
}