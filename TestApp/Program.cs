using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using wx;

namespace TestApp {
  class Program : App {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main() {
      // Create an instance of our TrainController's TrainController class
      Program app = new Program();

      // Run the application
      app.Run();
    }

    public override bool OnInit() {
      MyFrame m_frame = new MyFrame("ERIK");
      m_frame.Show();

      return true;
    }
  }

  class MyFrame : Frame {
    MyNotebook m_top;

    public MyFrame(String title)
      : base(null, wx.Window.wxID_ANY, title) {
      var m_splitter = this;
      m_top = new MyNotebook(m_splitter, "top", 12345);
    }
  }

  //class MySplitter : SplitterWindow {
  //}

  class MyNotebook : Notebook {
    public MyNotebook(Window parent, String name, int id)
      : base(parent, id, wxDefaultPosition, wxDefaultSize, WindowStyles.NB_BOTTOM) {

      // EVT_PAINT(new EventListener(OnPaint));
      OnPaint(null, null);
    }

    public void OnPaint(object sender, Event evt) {
      using(MemoryDC dc = new MemoryDC()) {
        wx.Bitmap m_pixmap = new wx.Bitmap(100, 100);

        dc.SelectObject(m_pixmap);
        // Erik: Test code
        dc.Pen = new wx.Pen(wx.Colour.wxGREEN, 100);
        dc.DrawLine(0, 0, 1000, 1000);
        dc.SelectObject(wx.Bitmap.NullBitmap);
      }
    }

  }
}