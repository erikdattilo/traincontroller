using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class InterpreterData {

    public bool _forCond;
    public bool _forAddr;
    public int _stackPtr;
    public Statement[] _scopes = new Statement[Configuration.MAXNESTING];

    // run-time environment

    public Track _track;
    public Train _train;
    public Signal _signal;
    public Itinerary _itinerary;

    /// TODO Uncomment this function
    public void Execute(Statement stmt) {
      //ExprValue   result(None);
      //bool	    valid;

      //while(stmt) {
      //    _scopes[_stackPtr] = stmt;

      //    switch(stmt->_type) {
      //    case 'B':
      //  ++_stackPtr;
      //  stmt = stmt->_child;
      //  continue;

      //    case 'I':
      //  try {
      //      wxStrcpy(expr_buff, wxT("if "));
      //      result._op = None;
      //      _forCond = true;
      //      valid = Evaluate(stmt->_expr, result);
      //      if(!valid) {
      //    if(stmt->_elseChild) {
      //        wxStrcat(expr_buff, wxT(" -> else"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt->_elseChild;
      //        continue;
      //    }
      //    wxStrcat(expr_buff, wxT(" -> false"));
      //      } else if(result._op == Number) {
      //    if(result._val) {
      //        wxStrcat(expr_buff, wxT(" -> true"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt->_child;
      //        continue;
      //    }
      //    if(stmt->_elseChild) {
      //        wxStrcat(expr_buff, wxT(" -> else"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt->_elseChild;
      //        continue;
      //    }
      //    wxStrcat(expr_buff, wxT(" -> false"));
      //      } else
      //    wxStrcat(expr_buff, wxT(" * Result not a number"));
      //      Trace(expr_buff);
      //  } catch(...) {
      //      abort();
      //  }
      //  break;

      //    case 'R':
      //  return;

      //    case 'D':
      //  try {
      //      wxChar    buff[256];
      //      wxChar    *p;
      //      const wxChar *s;

      //      for(p = buff, s = stmt->_text; *s && p < &buff[sizeof(buff) - 1]; ++s) {
      //    if(*s == '@' && _train) {
      //        wxStrcpy(p, _train->name);
      //        while(*p)
      //      ++p;
      //    } else
      //        *p++ = *s;
      //      }
      //      *p = 0;
      //      trainsim_cmd(buff);
      //  } catch(...) {
      //      abort();
      //  }
      //  break;

      //    case 'E':
      //  try {
      //      result._op = None;
      //      _forCond = false;
      //      expr_buff[0] = 0;
      //      Evaluate(stmt->_expr, result);
      //      Trace(expr_buff);
      //  } catch(...) {
      //      abort();
      //  }
      //    }
      //    while(!stmt->_next) {
      //  if(!_stackPtr)
      //      return;
      //  stmt = _scopes[--_stackPtr];
      //    }
      //    stmt = stmt->_next;
      //}
    }

  }
}