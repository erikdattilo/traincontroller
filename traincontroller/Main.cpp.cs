using System;
using System.Drawing;
using System.IO;
using TrainDirNET;
using wx.SampleDialogs;

namespace wx.TrainDirNET {
  public static class MainClass {
    [STAThread]
    static void Main() {
      App app =
        new TrainDir();
      // new TestProgram();
      app.Run();
    }
  }
}
