using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class SignalInterpreterData : InterpreterData {

    public SignalAspect _aspects;	// list of aspects (states)
    public Statement _onClick;	// list of actions (statements)
    public Statement _onCleared;	// list of actions (statements)
    public Statement _onShunt;	// list of actions (statements)
    public Statement _onUpdate;	// list of actions (statements)
    public Statement _onInit;	// list of actions (statements)
    public Statement _onCross;	// list of actions (statements)
    public Statement _onAuto;	// list of actions (statements)

    public bool _mustBeClearPath;

    public SignalInterpreterData() {
    }

    public SignalInterpreterData(SignalInterpreterData source) {
      _aspects = source._aspects;
      _onClick = source._onClick;
      _onCleared = source._onCleared;
      _onShunt = source._onShunt;
      _onUpdate = source._onUpdate;
      _onInit = source._onInit;
      _onCross = source._onCross;
      _onAuto = source._onAuto;

      _mustBeClearPath = false;
    }

    ///  TODO Uncomment this function
    public void Execute(Statement stmt) {
      //ExprValue   result = new ExprValue(None);
      //bool	    valid;

      //while(stmt) {
      //    _scopes[_stackPtr] = stmt;

      //    switch(stmt._type) {
      //    case 'B':
      //  ++_stackPtr;
      //  stmt = stmt._child;
      //  continue;

      //    case 'I':
      //  try {
      //      wxStrcpy(expr_buff, wxT("if "));
      //      result._op = None;
      //      _forCond = true;
      //      valid = Evaluate(stmt._expr, result);
      //      if(!valid) {
      //    if(stmt._elseChild) {
      //        wxStrcat(expr_buff, wxT(" . else"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt._elseChild;
      //        continue;
      //    }
      //    wxStrcat(expr_buff, wxT(" . false"));
      //      } else if(result._op == Number) {
      //    if(result._val) {
      //        wxStrcat(expr_buff, wxT(" . true"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt._child;
      //        continue;
      //    }
      //    if(stmt._elseChild) {
      //        wxStrcat(expr_buff, wxT(" . else"));
      //        Trace(expr_buff);
      //        ++_stackPtr;
      //        stmt = stmt._elseChild;
      //        continue;
      //    }
      //    wxStrcat(expr_buff, wxT(" . false"));
      //      } else
      //    wxStrcat(expr_buff, wxT(" * Result not a number"));
      //      Trace(expr_buff);
      //  } catch(Exception) {
      //      abort();
      //  }
      //  break;

      //    case 'R':
      //  return;

      //    case 'D':
      //  try {
      //      string buff;
      //      string p;
      //    string s;

      //      for(p = buff, s = stmt._text; *s && p < &buff[sizeof(buff) - 1]; ++s) {
      //    if(*s == '@' && _train) {
      //        wxStrcpy(p, _train.name);
      //        while(*p)
      //      ++p;
      //    } else
      //        *p++ = *s;
      //      }
      //      *p = 0;
      //      trainsim_cmd(buff);
      //  } catch(Exception) {
      //      abort();
      //  }
      //  break;

      //    case 'E':
      //  try {
      //      result._op = None;
      //      _forCond = false;
      //      expr_buff[0] = 0;
      //      Evaluate(stmt._expr, result);
      //      Trace(expr_buff);
      //  } catch(Exception) {
      //      abort();
      //  }
      //    }
      //    while(!stmt._next) {
      //  if(!_stackPtr)
      //      return;
      //  stmt = _scopes[--_stackPtr];
      //    }
      //    stmt = stmt._next;
      //}
    }
  }
}