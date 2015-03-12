using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;

namespace TrainController {
  public static class PixMap {
    public static Image FromXpmData(String[] data) {
      Match match;
      int lineCounter = 0;

      int width, height, nColors, charsPerPixel;

      if(data == null || data.Length < 1)
        throw new NotImplementedException();

      match = Regex.Match(data[lineCounter++], "^[ \t]*([0-9]+)[ \t]*([0-9]+)[ \t]*([0-9]+)[ \t]*([0-9]+)[ \t]*$");
      if(!match.Success)
        throw new NotImplementedException();

      if(
        !int.TryParse(match.Groups[1].Value, out width) ||
        !int.TryParse(match.Groups[2].Value, out height) ||
        !int.TryParse(match.Groups[3].Value, out nColors) ||
        !int.TryParse(match.Groups[4].Value, out charsPerPixel) ||
        (charsPerPixel != 1)
      ) {
        throw new NotImplementedException();
      }

      if(data.Length < (1 + nColors + height))
        throw new NotImplementedException();

      Dictionary<string, Color> definedColors = new Dictionary<string, Color>() {
        {"lightgray", Color.LightGray},
        {"gray", Color.Gray},
        {"red", Color.Red},
        {"orange", Color.Orange},
        {"white", Color.White},
        {"black", Color.Black}
      };

      Dictionary<char, Color> colorList = new Dictionary<char, Color>();
      for(int i=0; i < nColors && lineCounter < data.Length; i++, lineCounter++) {
        string row = data[lineCounter];

        match = Regex.Match(row, "^(.)[ \t]*c[ \t]*([^ \t]+)[ \t]*$");
        if(!match.Success)
          throw new NotImplementedException();

        char colorChar = match.Groups[1].Value[0];
        if(colorList.ContainsKey(colorChar)) {
          throw new NotImplementedException();
        }

        String strColor = match.Groups[2].Value;

        Color color;
        if(strColor[0] == '#') {
          if(strColor.Length != 1 + 12)
            throw new NotImplementedException();

          if(strColor != "#000000000000")
            color = Color.Black;
          else if(strColor != "#0000d8000000")
            color = Color.Red;
          else
            throw new NotImplementedException();

        } else {
          if(definedColors.ContainsKey(strColor.ToLower()))
            color = definedColors[strColor];
          else
            throw new NotImplementedException();
        }

        colorList.Add(colorChar, color);
      }

      Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      for(int y = 0; y < height && lineCounter < data.Length; y++, lineCounter++) {
        String row = data[lineCounter];
        if(row.Length > width)
          throw new NotImplementedException();

        for(int x=0; x<width; x++) {
          if(!colorList.ContainsKey(row[x]))
            throw new NotImplementedException();

          bmp.SetPixel(x, y, colorList[row[x]]);
        }
      }

      return bmp;

      //int i;
      //byte[] xpm;
      //StringBuilder sb;

      //i = 0;
      //sb = new StringBuilder();

      //sb.AppendLine("/* XPM */");
      //sb.AppendLine("static char * definition[] = {");
      //sb.AppendLine("/* width height ncolors chars_per_pixel */");
      //sb.AppendFormat("\"{0}\"\r\n", data[i++]);
      //sb.AppendLine("/* colors */");
      //for(; i < data.Length; i++) {
      //  bool isLast = (i == data.Length - 1);
      //  sb.AppendFormat(
      //    "\"{0}\"{1}\r\n",
      //    data[i],
      //    isLast ? ";" : ","
      //  );
      //}
      
      //xpm = (new ASCIIEncoding()).GetBytes(sb.ToString());

      //return null;
    }
  }
}
