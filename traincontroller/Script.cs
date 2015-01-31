using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDirNET {
  class Script {
    public Script _next;
    public string _path;
    public string _text;

    public bool ReadFile() {
      string result = "";
      string p;

      // if(_text)
      //    free(_text);
      _text = null;
      char[] charArray;
      if(!GlobalFunctions.LoadFile(_path, out charArray))
        return false;

      _text = new string(charArray);

      for(p = _text; p.Length > 0; ) {
        if(p[0] == '\t') {
          result += " ";
          // *p++ = ' ';
          p = p.Substring(1);
        } else if(p[0] == '\r') {
          result += "\n";
          // *p++ = '\n';
          p = p.Substring(1);
        } else if(p[0] == '#') {	// ignore comments
          while(p.Length > 0 && p[0] != '\n') {
            result += " ";
            p = p.Substring(1);
            // *p++ = ' ';
          }
        } else {
          result += p[0];
          p = p.Substring(1);
        }
      }

      _text = result;

      return true;
    }
  }
}
