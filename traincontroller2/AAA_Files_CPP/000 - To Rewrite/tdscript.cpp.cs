/*	tdscript.cpp - Created by Giampiero Caprino

This file is part of Train Director 3

Train Director is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; using exclusively version 2.
It is expressly forbidden the use of higher versions of the GNU
General Public License.

Train Director is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Train Director; see the file COPYING.  If not, write to
the Free Software Foundation, 59 Temple Place - Suite 330,
Boston, MA 02111-1307, USA.
*/

using System;
namespace TrainDirPorting {

  //	scripting support

  public enum NodeOp {
    Equal,			// bool if left == right OR assignment
    NotEqual,		// bool if left != right
    Less,			// bool if left < right
    Greater,		// bool if left > right
    LessEqual,		// bool if left <= right
    GreaterEqual,		// bool if left >= right
    And,			// bool if left && right
    Or,			// bool if left || right
    Dot,			// result is left.value
    TrackRef,		// Track(x, y)   OR  Track(value)
    SwitchRef,		// Switch(x, y)  OR  Switch(value)
    SignalRef,		// Signal(x, y)  OR  Signal(value)
    NextSignalRef,		// Signal,
    NextApproachRef,	// Signal,
    LinkedRef,              // Image to Switch
    TrainRef,
    Addr,			// Ref + Dot
    Random,			// return 0..100
    Time,			// current time, in decimal hhmm
    None,
    Bool,
    Number,
    String
  };

  public class ExprValue {

    public ExprValue(NodeOp op) {
      throw new NotImplementedException();
      //_op = op;
      //_txt = 0;
      //_val = 0;
      //_track = 0;
      //_signal = 0;
      //_train = 0;
    }

    ~ExprValue() { }

    public NodeOp _op;
    public Track _track;
    public Signal _signal;
    public Train _train;
    public String _txt;
    public int _val;
  };

  public class ExprNode {

    public ExprNode(NodeOp op) {
      throw new NotImplementedException();
      //_op = op;
      //_left = _right = mull;
      //_val = 0;
      //_txt = mull;
      //_x = _y = 0;
    }



    public NodeOp _op;
    public ExprNode _left, _right;
    public String _txt;		// value for aspects compares
    public int _val;
    public int _x, _y;		// coordinates of TrackRef, SwitchRef, SignalRef

    ~ExprNode() {
      //if(_op == String && _txt)
      //  Globals.free(_txt);
      //_txt = 0;
      //if(_left)
      //  Globals.delete(_left);
      //if(_right)
      //  Globals.delete(_right);
    }
  };

  public class InterpreterData {
    public void TraceCoord(int x, int y, String label) {
      //expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("%s(%d,%d)."), label, x, y);
    }

    public bool Evaluate(ExprNode n, ExprValue result) {
      throw new NotImplementedException();
      //ExprValue left = new ExprValue(NodeOp.NodeOp.None);
      //ExprValue right = new ExprValue(NodeOp.None);
      //Track t;
      //int val;
      //bool oldForAddr;

      //switch(n._op) {

      //  case SignalRef:

      //    if(n._txt) {
      //      // signal by name
      //      result._op = n._op;
      //      result._signal = findSignalNamed(n._txt);
      //      expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("Signal(%s)"), n._txt);
      //      return result._signal != null;
      //    }

      //  // fall through to x,y case

      //  case SwitchRef:
      //  case TrackRef:
      //    // case TriggerRef:
      //    // case ItineraryRef:

      //    if(n._txt) {
      //      // track or switch by name
      //      result._op = n._op;
      //      result._track = findStationNamed(n._txt);
      //      expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("Track(%s)"), n._txt);
      //      return result._track != null;
      //    }
      //    TraceCoord(n._x, n._y);
      //    if(!n._x && !n._y) {
      //      result._op = n._op;
      //      result._track = _track;
      //      return true;
      //    }
      //    t = find_track(layout, n._x, n._y);
      //    if(!t) {
      //      wxStrcat(expr_buff, wxPorting.T("=no track"));
      //      return false;
      //    }
      //    result._op = n._op;
      //    if(result._op == SignalRef && t.type == TSIGNAL)
      //      result._signal = (Signal)t;
      //    else
      //      result._track = t;
      //    return true;

      //  case TrainRef:

      //    result._op = TrainRef;
      //    if(!n._txt) {
      //      if(!n._x && !n._y) {
      //        result._train = _train;
      //      } else if(!(result._train = findTrain(n._x, n._y))) {
      //        expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("Train(%d,%d) - not found"), n._x, n._y);
      //        return false;
      //      }
      //      expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("Train{%s}"), result._train.name);
      //      return true;
      //    }
      //    result._train = findTrainNamed(n._txt);
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("Train(%s)"), n._txt);
      //    return result._train != null;

      //  case String:

      //    result._op = n._op;
      //    result._txt = n._txt;
      //    wxStrcat(expr_buff, result._txt);
      //    return true;

      //  case Number:

      //    result._op = n._op;
      //    result._txt = n._txt;
      //    result._val = n._val;
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("%d"), result._val);
      //    return true;

      //  case Random:

      //    result._op = Number;
      //    result._val = rand() % 100;
      //    return true;

      //  case Time:

      //    result._op = Number;
      //    result._val = ((current_time / 3600) % 24) * 100 + ((current_time / 60) % 60);
      //    return true;

      //  case Equal:

      //    result._op = Number;
      //    result._val = 0;
      //    if(_forCond) {

      //      // conditionals return false in case of expression error

      //      if(!Evaluate(n._left, left))
      //        return true;
      //      wxStrcat(expr_buff, wxPorting.T(" = "));
      //      if(!Evaluate(n._right, right))	    // virtual
      //        return true;

      //      val = 0;
      //      if(left._op == right._op) {
      //        switch(left._op) {
      //          case String:
      //            val = !wxStrcmp(left._txt, right._txt);
      //            break;

      //          case Number:
      //            val = left._val == right._val;
      //        }
      //      }
      //      result._op = Number;
      //      result._val = val;
      //      expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), val);
      //      return true;
      //    }
      //    oldForAddr = _forAddr;
      //    _forAddr = true;
      //    if(!Evaluate(n._left, result)) {
      //      _forAddr = oldForAddr;
      //      return false;
      //    }
      //    _forAddr = oldForAddr;
      //    if(result._txt)
      //      wxStrcat(expr_buff, result._txt);
      //    wxStrcat(expr_buff, wxPorting.T(" = "));
      //    if(!Evaluate(n._right, right))	    // virtual
      //      return false;
      //    switch(result._op) {

      //      case SignalRef:
      //        if(!result._signal)
      //          return false;
      //        result._signal.SetPropertyValue(result._txt, right);
      //        break;

      //      case TrackRef:
      //      case SwitchRef:
      //      case Addr:

      //        if(!result._track)
      //          return false;
      //        result._track.SetPropertyValue(result._txt, right);
      //        return true;

      //      case TrainRef:

      //        if(!result._train)
      //          return false;
      //        result._train.SetPropertyValue(result._txt, right);
      //        return false;

      //    }
      //    return true;

      //  case NotEqual:

      //    result._op = Number;
      //    result._val = 0;
      //    if(!Evaluate(n._left, left)) {
      //      result._val = 1;	// invalid expressions never match
      //      return true;
      //    }
      //    wxStrcat(expr_buff, wxPorting.T(" != "));
      //    if(!Evaluate(n._right, right))
      //      return true;
      //    val = 0;
      //    if(left._op == right._op) {
      //      switch(left._op) {
      //        case String:
      //          val = wxStrcmp(left._txt, right._txt) != 0;
      //          break;

      //        case Number:
      //          val = left._val != right._val;
      //      }
      //    }
      //    result._val = val;
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), val);
      //    return true;

      //  case Greater:

      //    // conditionals return false in case of expression error

      //    result._op = Number;
      //    result._val = 0;
      //    if(!Evaluate(n._left, left))
      //      return true;
      //    wxStrcat(expr_buff, wxPorting.T(" > "));
      //    if(!Evaluate(n._right, right))
      //      return true;
      //    val = 0;
      //    if(left._op == right._op) {
      //      switch(left._op) {
      //        case String:
      //          val = wxStrcmp(left._txt, right._txt) > 0;
      //          break;

      //        case Number:
      //          val = left._val > right._val;
      //      }
      //    }
      //    result._val = val;
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), val);
      //    return true;

      //  case Less:

      //    // conditionals return false in case of expression error

      //    result._op = Number;
      //    result._val = 0;
      //    if(!Evaluate(n._left, left))
      //      return true;
      //    wxStrcat(expr_buff, wxPorting.T(" < "));
      //    if(!Evaluate(n._right, right))
      //      return true;
      //    val = 0;
      //    if(left._op == right._op) {
      //      switch(left._op) {
      //        case String:
      //          val = wxStrcmp(left._txt, right._txt) < 0;
      //          break;

      //        case Number:
      //          val = left._val < right._val;
      //      }
      //    }
      //    result._val = val;
      //    expr_buff + Globals.wxStrlen(expr_buff) = String.Format( wxPorting.T("{%d}"), val);
      //    return true;

      //  case Or:

      //    result._op = Number;
      //    result._val = 0;
      //    if(Evaluate(n._left, right) && right._op == Number && right._val != 0) {
      //      result._val = 1;
      //      return true;
      //    }
      //    wxStrcat(expr_buff, wxPorting.T(" or "));
      //    // note: invalid expressions evaluate to false (0)
      //    if(Evaluate(n._right, right) && right._op == Number && right._val != 0)
      //      result._val = 1;
      //    else
      //      result._val = 0;
      //    return true;

      //  case And:

      //    result._op = Number;
      //    result._val = 0;
      //    if(Evaluate(n._left, right) && right._op == Number && right._val == 0)
      //      return true;
      //    wxStrcat(expr_buff, wxPorting.T(" and "));
      //    // note: invalid expressions evaluate to false (0)
      //    if(Evaluate(n._right, right) && right._op == Number && right._val == 0)
      //      return true;
      //    result._val = 1;
      //    return true;
      //}
      //return false;
    }


    public void Execute(Statement stmt)
{
  //ExprValue result = new ExprValue(NodeOp.None);
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
  //      expr_buff = String.Copy( wxPorting.T("if "));
  //      result._op = None;
  //      _forCond = true;
  //      valid = Evaluate(stmt._expr, result);
  //      if(!valid) {
  //    if(stmt._elseChild) {
  //        wxStrcat(expr_buff, wxPorting.T(" . else"));
  //        Trace(expr_buff);
  //        ++_stackPtr;
  //        stmt = stmt._elseChild;
  //        continue;
  //    }
  //    wxStrcat(expr_buff, wxPorting.T(" . false"));
  //      } else if(result._op == Number) {
  //    if(result._val) {
  //        wxStrcat(expr_buff, wxPorting.T(" . true"));
  //        Trace(expr_buff);
  //        ++_stackPtr;
  //        stmt = stmt._child;
  //        continue;
  //    }
  //    if(stmt._elseChild) {
  //        wxStrcat(expr_buff, wxPorting.T(" . else"));
  //        Trace(expr_buff);
  //        ++_stackPtr;
  //        stmt = stmt._elseChild;
  //        continue;
  //    }
  //    wxStrcat(expr_buff, wxPorting.T(" . false"));
  //      } else
  //    wxStrcat(expr_buff, wxPorting.T(" * Result not a number"));
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
  //      String p;
  //      String s;

  //      for(p = buff, s = stmt._text; *s && p < &buff[sizeof(buff) - 1]; ++s) {
  //    if(*s == '@' && _train) {
  //        p = String.Copy( _train.name);
  //        while(*p)
  //          p = p.Substring(1);
  //    } else
  //        *p.incPointer() = *s;
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

    public InterpreterData() {
      throw new NotImplementedException();
      //_forCond = _forAddr = false;
      //_stackPtr = 0;
      //memset(_scopes, 0, sizeof(_scopes));
      //_track = 0;
      //_train = 0;
      //_signal = 0;
    }

    public bool _forCond;
    public bool _forAddr;
    public int _stackPtr;
    public Statement[] _scopes = new Statement[Configuration.MAXNESTING];

    // run-time environment

    public Track _track;
    public Train _train;
    public Signal _signal;
    public Itinerary _itinerary;
  }

  public class Statement {

    public Statement() {
      //_next = _child = _lastChild = _parent = 0;
      //_elseChild = _lastElseChild = 0;
      //_isElse = false;
      //_type = 0;
      //_text = 0;	    // todo: remove?
      //_expr = 0;
    }

    ~Statement() {
      //while(_elseChild) {
      //  Statement stmt = _elseChild;
      //  _elseChild = _elseChild._next;
      // Globals.delete(stmt);
      //}
      //_lastElseChild = 0;
      //while(_child) {
      //  Statement stmt = _child;
      //  _child = _child._next;
      // Globals.delete(stmt);
      //}
      //_lastChild = 0;
      //if(_expr)
      //  Globals.delete(_expr);
      //if(_text)
      //  Globals.free(_text);
      //_text = 0;
    }

    public Statement _next;
    public Statement _child, _elseChild;
    public Statement _lastChild, _lastElseChild;
    public Statement _parent;
    public int _type;
    public bool _isElse;
    public String _text;
    public ExprNode _expr;
  };

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


  public partial class Configuration {
    // Track::interpreterData for signals
    public static int MAXNESTING = 20;
    public static int EXPR_BUFF_SIZE = 4096;
  }



  //
  //
  //	Parse a Train Dir Script file into
  //	an Abstract Syntax Tree
  //
  //	The tree has only 3 types of nodes:
  //	Block: beginning of the tree
  //	Statement: for assignments
  //	If: with optional else and child statements
  //
  //

  public partial class Globals {
    public static int SIZE_LEFT(string b) { return (b.Length - Globals.wxStrlen(b)); }

    public static String next_token(String p) {
      throw new NotImplementedException();
      //while(*p && p[0] == ' ' || p[0] == '\t' || p[0] == '\n' || p[0] == '\r')
      //  p.incPointer();
      //return p;
    }

    public static bool match(String pp, String txt) {
      throw new NotImplementedException();
      //String p = *pp;

      //while(p[0] == ' ' || p[0] == '\t')
      //  p.incPointer();
      //*pp = p;
      //if(Globals.wxStrncmp(p, txt, Globals.wxStrlen(txt)))
      //  return false;
      //p += Globals.wxStrlen(txt);
      //while(p[0] == ' ' || p[0] == '\t')
      //  p.incPointer();
      //*pp = p;
      //return true;
    }


    public static String scan_line(String src, String dst) {
      throw new NotImplementedException();
      //while(*src && *src != '\n') {
      //  if(*src == '\r')
      //    continue;
      //  *dst++ = *src++;
      //}
      //*dst = 0;
      //if(*src) ++src;
      //while(*src == ' ' || *src == '\t' || *src == '\n' || *src == '\r')
      //  ++src;
      //return src;
    }


    public static String scan_word(String p, String dst) {
      throw new NotImplementedException();
      //dst = "";
      //while(p.Length > 0 && (p[0] == ' ' || p[0] == '\t')) p = p.Substring(1);
      //if(p[0] == '\'' || p[0] == '"') {
      //  int sep = *p.incPointer();
      //  while(p.Length > 0) {
      //    if(p[0] == '\\' && p[1]) {
      //      *dst++ = p[1];
      //      p += 2;
      //      continue;
      //    }
      //    if(p[0] == sep) {
      //      p = p.Substring(1);
      //      break;
      //    }
      //    *dst++ = *p.incPointer();
      //  }
      //  *dst = 0;
      //  while(p.Length > 0 && (p[0] == ' ' || p[0] == '\t')) p = p.Substring(1);
      //  return p;
      //}
      //if((p[0] >= 'a' && p[0] <= 'z') || (p[0] >= 'A' && p[0] <= 'Z') || p[0] == '_' || p[0] == '@') {
      //  while(p[0] >= 'a' && p[0] <= 'z' ||
      //    p[0] >= 'A' && p[0] <= 'Z' ||
      //    p[0] == '_' || p[0] == '@' ||
      //    p[0] >= '0' && p[0] <= '9')
      //    *dst++ = *p.incPointer();
      //  *dst = 0;
      //  while(*p && (p[0] == ' ' || p[0] == '\t')) p = p.Substring(1);
      //  return p;
      //}
      //if(p[0] >= '0' && p[0] <= '9') {
      //  while(p[0] >= '0' && p[0] <= '9')
      //    *dst++ = *p.incPointer();
      //  *dst = 0;
      //  while(*p && (p[0] == ' ' || p[0] == '\t')) p = p.Substring(1);
      //  return p;
      //}
      //*dst++ = *p.incPointer();
      //*dst = 0;
      //while(*p && (p[0] == ' ' || p[0] == '\t')) p = p.Substring(1);
      //return p;

    }

    public static Statement AddStatementToBlock(Statement block) {
      throw new NotImplementedException();
      //Statement stmt;

      //stmt = new Statement();
      //if(block._isElse) {
      //  if(!block._elseChild)
      //    block._elseChild = stmt;
      //  else
      //    block._lastElseChild._next = stmt;
      //  block._lastElseChild = stmt;
      //} else {
      //  if(!block._child)
      //    block._child = stmt;
      //  else
      //    block._lastChild._next = stmt;
      //  block._lastChild = stmt;
      //}
      //stmt._parent = block;
      //return stmt;
    }




    public static ExprNode ParseToken(String pp) {
      throw new NotImplementedException();
      //string word;
      //String p = *pp;
      //ExprNode* n;

      //p = scan_word(pp, word);
      //if(!wxStrcmp(word, wxPorting.T("Switch"))) {
      //  n = new ExprNode(SwitchRef);
      //} else if(!wxStrcmp(word, wxPorting.T("Track"))) {
      //  n = new ExprNode(TrackRef);
      //} else if(!wxStrcmp(word, wxPorting.T("Signal"))) {
      //  n = new ExprNode(SignalRef);
      //} else if(!wxStrcmp(word, wxPorting.T("Train"))) {
      //  n = new ExprNode(TrainRef);
      //} else if(!wxStrcmp(word, wxPorting.T("next"))) {
      //  n = new ExprNode(NextSignalRef);
      //} else if(!wxStrcmp(word, wxPorting.T("nextApproach"))) {
      //  n = new ExprNode(NextApproachRef);
      //} else if(!wxStrcmp(word, wxPorting.T("linked"))) {
      //  n = new ExprNode(LinkedRef);
      //} else if(!wxStrcmp(word, wxPorting.T("and"))) {
      //  n = new ExprNode(And);
      //} else if(!wxStrcmp(word, wxPorting.T("or"))) {
      //  n = new ExprNode(Or);
      //} else if(!wxStrcmp(word, wxPorting.T("random"))) {
      //  n = new ExprNode(Random);
      //} else if(!wxStrcmp(word, wxPorting.T("time"))) {
      //  n = new ExprNode(Time);
      //} else if(word[0] == '=') {
      //  n = new ExprNode(Equal);
      //} else if(word[0] == '!') {
      //  n = new ExprNode(NotEqual);
      //} else if(word[0] == '>') {
      //  n = new ExprNode(Greater);
      //} else if(word[0] == '<') {
      //  n = new ExprNode(Less);
      //} else if(word[0] == '.') {
      //  n = new ExprNode(Dot);
      //} else {
      //  string cp;
      //  for(cp = word; *cp; ++cp)
      //    if(!isdigit(*cp))
      //      break;
      //  if(!*cp) {
      //    n = new ExprNode(Number);
      //    n._val = wxStrtol(word, 0, 0);
      //  } else if(wxIsalnum(word[0])) {
      //    n = new ExprNode(String);
      //    n._txt = wxStrdup(word);
      //  } else
      //    return 0;
      //}
      //*pp = p;
      //return n;
    }


    public static ExprNode ParseExpr(String p)
{
      throw new NotImplementedException();
//  ExprNode n, n1 = 0, n2 = 0;
//  ExprNode root = 0;
//  string word;

//  while(*p) {
//      n = ParseToken(&p);
//      if(!n)
//    break;
//      switch(n._op) {
//      case TrackRef:
//      case TrainRef:
//      case SwitchRef:
//      case SignalRef:
//    n._txt = 0;
//    n._x = n._y = 0;
//    if(p[0] == '.') {
//        if(!root)
//      root = n;
//        break;
//    }
//    p = scan_word(p, word);
//    if(word[0] != '(') {
//        // error: expected '('
//        return 0;
//    }
//    n1 = ParseToken(&p);
//    if(n1._op == String) {
//        n._txt = n1._txt;
//        n1._txt = 0;
//       Globals.delete(n1);
//        goto end_paren;
//    }
//    if(n1._op != Number) {
//        // error: expected number
//       Globals.delete(n);
//       Globals.delete(n1);
//        return 0;
//    }
//    p = scan_word(p, word);
//    if(word[0] != ',') {
//        // error: expected ','
//       Globals.delete(n);
//       Globals.delete(n1);
//        return 0;
//    }
//    n2 = ParseToken(&p);
//    if(n2._op != Number) {
//        // error: expected number
//       Globals.delete(n);
//       Globals.delete(n1);
//       Globals.delete(n2);
//        return 0;
//    }
//    n._x = n1._val;
//    n._y = n2._val;
//  Globals.delete(n1);
//  Globals.delete(n2);
//end_paren:	if(!root)
//        root = n;
//    p = scan_word(p, word);
//    if(word[0] != ')') {
//        // error: expected '('
//        return 0;
//    }
//    break;

//      case NextSignalRef:
//      case NextApproachRef:
//            case LinkedRef:
//    if(!root)
//        root = n;
//    break;

//      case Dot:
//    if(!root) {
//        // error: missing left reference;
//        n2 = ParseToken(&p);
//        if(!n2)
//      return 0;
//        goto our; // return 0;
//    }
//    switch(root._op) {
//    case TrackRef:
//    case SwitchRef:
//    case SignalRef:
//    case NextSignalRef:
//    case NextApproachRef:
//                case LinkedRef:
//    case TrainRef:
//    case Dot:
//        break;

//    default:
//        // error: invalid '.' for left expression
//        return 0;
//    }

//    n2 = ParseToken(&p);
//    if(!n2)
//        return 0;
//    if(n2._op == NextSignalRef || n2._op == NextApproachRef) {
//        n._left = root;
//        n._right = n2;
//        n2._txt = wxStrdup(n2._op == NextSignalRef ? wxPorting.T("next") : wxPorting.T("nextApproach"));
////		    n2._op = Dot;
////		    n2._left = root;
//        root = n;
//        continue; // goto nxt;
//    }
//    if(n2._op == LinkedRef) {
//        n._left = root;
//        n._right = n2;
//        n2._txt = wxPorting.T("linked");
//        root = n;
//        continue; // goto nxt;
//    }
//    if(n2._op != String) {
//        // error: right of '.' must be a name
//        return 0;
//    }

//our:
//    n._left = root;
//    n._right = n2;
//    root = n;
//    break;

//      case Equal:
//      case NotEqual:
//      case Greater:
//      case Less:
//    if(!root) {
//        // error: missing left expression
//        return 0;
//    }
//    n2 = ParseToken(&p);
//    if(!n2)
//        return 0;
//    n._left = root;
//    n._right = n2;
//    root = n;
//    break;

//      case And:
//      case Or:
//    if(!root) {
//        // error: missing left expression
//        return 0;
//    }
//    n2 = ParseExpr(p);	    // recurse!
//    if(!n2)
//        return 0;
//    n._left = root;
//    n._right = n2;
//    root = n;
//    return root;

//      default:

//    if(!root)
//        root = n;
//      }
//  }
//  return root;
}


    public static Statement ParseStatements(String pp) {
      throw new NotImplementedException();
      //string line;
      //String p = pp;
      //Statement stmt;

      //Statement block = new Statement();
      //block._type = 'B';

      //while(p.Length) {
      //  if(match(&p, wxPorting.T("if"))) {
      //    stmt = AddStatementToBlock(block);
      //    stmt._type = 'I';
      //    block = stmt;			// enter new scope
      //    p = scan_line(p, line);
      //    if(line[0])
      //      stmt._expr = ParseExpr(line);
      //  } else if(match(&p, wxPorting.T("else"))) {	// exit scope and enter new scope
      //    do {
      //      if(block._type != 'I')	// else without if?
      //        return 0;		// error
      //      if(!block._isElse)
      //        break;
      //    } while(block = block._parent);
      //    if(!block)
      //      return 0;
      //    p = next_token(p);
      //    block._isElse = true;
      //  } else if(match(&p, wxPorting.T("end"))) {	// exit scope
      //    if(!block._parent)
      //      break;
      //    block = block._parent;
      //    p = next_token(p);
      //  } else if(match(&p, wxPorting.T("return"))) {	// return from function
      //    stmt = AddStatementToBlock(block);
      //    stmt._type = 'R';
      //    p = next_token(p);
      //  } else if(match(&p, wxPorting.T("do"))) {
      //    p = scan_line(p, line);
      //    if(!line[0])
      //      continue;
      //    stmt = AddStatementToBlock(block);
      //    stmt._type = 'D';
      //    stmt._text = wxStrdup(line);
      //  } else {
      //    p = scan_line(p, line);
      //    if(!line[0])
      //      continue;
      //    stmt = AddStatementToBlock(block);
      //    stmt._type = 'E';
      //    stmt._expr = ParseExpr(line); // wxStrdup(line);
      //  }
      //}
      //*pp = p;
      //return block;
    }


    //
    //
    //
    //

    public static void delete_script_data(TrackBase t) {
      //if(t.type != TSIGNAL)
      //  return;
      //if(t._interpreterData) {
      //  InterpreterData interp = (InterpreterData)t._interpreterData;
      // Globals.delete(interp);
      //}
      //t._interpreterData = 0;
    }





    //
    //
    //
    //

    public static Script scriptList;

    public static void free_scripts() {
      //Script* p;

      //while(scriptList) {
      //  p = scriptList;
      //  scriptList = scriptList._next;
      //  if(p._path)
      //    Globals.free(p._path);
      //  if(p._text)
      //    Globals.free(p._text);
      //  Globals.free(p);
      //}
      //onIconUpdateListeners.Clear();
    }

    public static Script find_script(String path) {
      throw new NotImplementedException();
      //Script s;
      //string buff;
      //String p;

      //buff = string.Copy(path);
      //if((p = wxStrchr(buff, '#')))
      //  *p = 0;
      //for(s = scriptList; s; s = s._next) {
      //  if(!wxStrcmp(s._path, buff))
      //    return s;
      //}
      //return 0;
    }

    public static Script new_script(String path) {
      throw new NotImplementedException();
      //Script s;
      //string buff;
      //String p;

      //buff = string.Copy(path);
      //if((p = wxStrchr(buff, '#')))
      //  *p = 0;
      //s = (Script)calloc(sizeof(Script), 1);
      //s._next = scriptList;
      //scriptList = s;
      //s._path = wxStrdup(buff);
      //s._text = 0;
      //return s;
    }


    //	load_scripts
    //	    Collect all script file names from signals
    //	    (and eventually itineraries) in the list
    //	    scriptList. This allows multiple signals to
    //	    share the same script file.

    public static void load_scripts(Track trk) {
      //for(; trk; trk = trk.next) {
      //  switch(trk.type) {
      //    case TRACK:
      //    case SWITCH:
      //    case ITIN:
      //    case TRIGGER:
      //    case IMAGE:
      //      if(!trk.stateProgram)
      //        continue;
      //      trk.ParseProgram();
      //      trk.OnInit();
      //      continue;

      //    case TSIGNAL:
      //      if(!trk.stateProgram)
      //        continue;
      //      Signal sig = (Signal)trk;
      //      sig.ParseProgram();
      //      sig.OnInit();
      //  }
      //}
      //onIconUpdateListeners.Clear();
      //for(Track t = layout; t; t = t.next) {
      //  if(t.type != IMAGE)
      //    continue;
      //  TrackInterpreterData data = (TrackInterpreterData)t._interpreterData;
      //  if(!data)
      //    continue;
      //  if(data._onIconUpdate) {
      //    onIconUpdateListeners.Add(t);
      //  }
      //}
    }
  }
}
