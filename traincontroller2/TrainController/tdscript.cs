using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {

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

  public class Statement {
    public Statement _next;
    public Statement _child, _elseChild;
    public Statement _lastChild, _lastElseChild;
    public Statement _parent;
    public int _type;
    public bool _isElse;
    public String _text;
    public ExprNode _expr;
  };

  public class ExprNode {

    public ExprNode(NodeOp op) {
      _op = op;
    }



    public NodeOp _op;
    public ExprNode _left, _right;
    public String _txt;		// value for aspects compares
    public int _val;
    public int _x, _y;		// coordinates of TrackRef, SwitchRef, SignalRef
  };


  partial class Globals {

    public static void free_scripts() {
      while(scriptList != null) {
        scriptList = scriptList._next;
      }
      // TODO Uncomment following line
      //onIconUpdateListeners.Clear();
    }

    public static Statement ParseStatements(ref String pp) {
      string line = "";
      String p = pp;
      Statement stmt;

      Statement block = new Statement();
      block._type = 'B';

      while(p.Length > 0) {
        if(match(ref p, wxPorting.T("if"))) {
          stmt = AddStatementToBlock(block);
          stmt._type = 'I';
          block = stmt;			// enter new scope
          p = scan_line(p, line);
          if(line.Length > 0)
            stmt._expr = ParseExpr(line);
        } else if(match(ref p, wxPorting.T("else"))) {	// exit scope and enter new scope
          do {
            if(block._type != 'I')	// else without if?
              return null;		// error
            if(!block._isElse)
              break;
          } while((block = block._parent) != null);
          if(block == null)
            return null;
          p = next_token(p);
          block._isElse = true;
        } else if(match(ref p, wxPorting.T("end"))) {	// exit scope
          if(block._parent == null)
            break;
          block = block._parent;
          p = next_token(p);
        } else if(match(ref p, wxPorting.T("return"))) {	// return from function
          stmt = AddStatementToBlock(block);
          stmt._type = 'R';
          p = next_token(p);
        } else if(match(ref p, wxPorting.T("do"))) {
          p = scan_line(p, line);
          if(line.Length == 0)
            continue;
          stmt = AddStatementToBlock(block);
          stmt._type = 'D';
          stmt._text = String.Copy(line);
        } else {
          p = scan_line(p, line);
          if(line.Length == 0)
            continue;
          stmt = AddStatementToBlock(block);
          stmt._type = 'E';
          stmt._expr = ParseExpr(line); // wxStrdup(line);
        }
      }
      pp = p;
      return block;
    }


    public static String next_token(String p) {
      throw new NotImplementedException();
      //while(*p && p[0] == ' ' || p[0] == '\t' || p[0] == '\n' || p[0] == '\r')
      //  p.incPointer();
      //return p;
    }

    public static bool match(ref String pp, String txt) {
      pp = pp.Trim();
      if(pp.StartsWith(txt) != false)
        return false;
      pp = pp.Substring(txt.Length).Trim();

      return true;
    }

    public static Statement AddStatementToBlock(Statement block) {
      Statement stmt = new Statement();
      if(block._isElse) {
        if(block._elseChild == null)
          block._elseChild = stmt;
        else
          block._lastElseChild._next = stmt;
        block._lastElseChild = stmt;
      } else {
        if(block._child == null)
          block._child = stmt;
        else
          block._lastChild._next = stmt;
        block._lastChild = stmt;
      }
      stmt._parent = block;
      return stmt;
    }


    public static ExprNode ParseExpr(String p) {
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


    public static String scan_line(String src, String dst) {
      int i = 0;
      while(i < src.Length && src[i] != '\n') {
        if(src[i] == '\r')
          continue;
        i++;
      }
      dst = src.Substring(0, i);
      if(i >= src.Length)
        i++;

      while(i < src.Length && (src[i] == ' ' || src[i] == '\t' || src[i] == '\n' || src[i] == '\r'))
        i++;
      if(i >= src.Length)
        return "";
      return src.Substring(i);
    }
  }
}
