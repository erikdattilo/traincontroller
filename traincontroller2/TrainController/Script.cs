using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public class Script {
    public Script _next;
    public String _path;
    public String _text;

    public bool ReadFile() {
      throw new NotImplementedException();
      //String p;

      //if(_text)
      //  Globals.free(_text);
      //_text = 0;
      //if(!LoadFile(_path, &_text))
      //  return false;

      //for(p = _text; *p; ) {
      //  if(p[0] == '\t')
      //    *p.incPointer() = ' ';
      //  else if(p[0] == '\r')
      //    *p.incPointer() = '\n';
      //  else if(p[0] == '#') {	// ignore comments
      //    while(*p && *p != '\n')
      //      *p.incPointer() = ' ';
      //  } else
      //    p.incPointer();
      //}
      //return true;
    }
  }
}