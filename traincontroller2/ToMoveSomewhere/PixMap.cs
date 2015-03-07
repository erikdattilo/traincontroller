using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public static class PixMap {
    public static wx.Image FromXpmData(String[] data) {
      int i;
      byte[] xpm;
      StringBuilder sb;

      i = 0;
      sb = new StringBuilder();

      sb.AppendLine("/* XPM */");
      sb.AppendLine("static char * definition[] = {");
      sb.AppendLine("/* width height ncolors chars_per_pixel */");
      sb.AppendFormat("\"{0}\"\r\n", data[i++]);
      sb.AppendLine("/* colors */");
      for(; i < data.Length; i++) {
        bool isLast = (i == data.Length - 1);
        sb.AppendFormat(
          "\"{0}\"{1}\r\n",
          data[i],
          isLast ? ";" : ","
        );
      }
      
      xpm = (new ASCIIEncoding()).GetBytes(sb.ToString());

      return new wx.Image(xpm, wx.BitmapType.wxBITMAP_TYPE_XPM);
    }
  }
}
