// /*	tdscript.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */
// 
// #include <stdio.h>
// #include <stdlib.h>
// #include <string.h>
// 
// #if !defined(__unix__) && !defined(__WXMAC__)
// #include <malloc.h>
// #else
// #define	stricmp strcasecmp
// #endif
// 
// #include <memory.h>
// #include <string.h>
// #include "Traindir3.h"
// #include "TDFile.h"
// 
// #define	SIZE_LEFT(b)   (sizeof(b) / sizeof(wxChar) - wxStrlen(b))
// 
// bool	Script::ReadFile()
// {
// 	wxChar	*p;
// 
// 	if(_text)
// 	    free(_text);
// 	_text = 0;
// 	if(!LoadFile(_path, &_text))
// 	    return false;
// 
// 	for(p = _text; *p; ) {
// 	    if(*p == 't')
// 		*p++ = ' ';
// 	    else if(*p == 'r')
// 		*p++ = 'n';
// 	    else if(*p == '#') {	// ignore comments
// 		while(*p && *p != 'n')
// 		    *p++ = ' ';
// 	    }
// 	    else
// 		++p;
// 	}
// 	return true;
// }
// 
// 
// //
// //
// //	Parse a Train Dir Script file into
// //	an Abstract Syntax Tree
// //
// //	The tree has only 3 types of nodes:
// //	Block: beginning of the tree
// //	Statement: for assignments
// //	If: with optional else and child statements
// //
// //
// 
// 
// const wxChar	*next_token(const wxChar *p)
// {
// 	while(*p && *p == ' ' || *p == 't' || *p == 'n' || *p == 'r')
// 	    ++p;
// 	return p;
// }
// 
// bool match(const wxChar **pp, const wxChar *txt)
// {
// 	const wxChar	*p = *pp;
// 
// 	while(*p == ' ' || *p == 't')
// 	    ++p;
// 	*pp = p;
// 	if(wxStrncmp(p, txt, wxStrlen(txt)))
// 	    return false;
// 	p += wxStrlen(txt);
// 	while(*p == ' ' || *p == 't')
// 	    ++p;
// 	*pp = p;
// 	return true;
// }
// 
// 
// const wxChar *scan_line(const wxChar *src, wxChar *dst)
// {
// 	while(*src && *src != 'n') {
// 	    if(*src == 'r')
// 		continue;
// 	    *dst++ = *src++;
// 	}
// 	*dst = 0;
// 	if(*src) ++src;
// 	while(*src == ' ' || *src == 't' || *src == 'n' || *src == 'r')
// 	    ++src;
// 	return src;
// }
// 
// 
// const wxChar	*scan_word(const wxChar *p, wxChar *dst)
// {
// 	*dst = 0;
// 	while(*p && (*p == ' ' || *p == 't')) ++p;
//         if(*p == ''' || *p == '"') {
//             int sep = *p++;
//             while(*p) {
//                 if(*p == '\' && p[1]) {
//                     *dst++ = p[1];
//                     p += 2;
//                     continue;
//                 }
//                 if(*p == sep) {
//                     ++p;
//                     break;
//                 }
//                 *dst++ = *p++;
//             }
//             *dst = 0;
// 	    while(*p && (*p == ' ' || *p == 't')) ++p;
//             return p;
//         }
// 	if((*p >= 'a' && *p <= 'z') || (*p >= 'A' && *p <= 'Z') || *p == '_' || *p == '@') {
// 	    while(*p >= 'a' && *p <= 'z' ||
// 		    *p >= 'A' && *p <= 'Z' ||
// 		    *p == '_' || *p == '@' ||
// 		    *p >= '0' && *p <= '9')
// 		*dst++ = *p++;
// 	    *dst = 0;
// 	    while(*p && (*p == ' ' || *p == 't')) ++p;
// 	    return p;
// 	}
// 	if(*p >= '0' && *p <= '9') {
// 	    while(*p >= '0' && *p <= '9')
// 		*dst++ = *p++;
// 	    *dst = 0;
// 	    while(*p && (*p == ' ' || *p == 't')) ++p;
// 	    return p;
// 	}
// 	*dst++ = *p++;
// 	*dst = 0;
// 	while(*p && (*p == ' ' || *p == 't')) ++p;
// 	return p;
// 
// }
// 
// Statement *AddStatementToBlock(Statement *block)
// {
// 	Statement *stmt;
// 
// 	stmt = new Statement();
// 	if(block->_isElse) {
// 	    if(!block->_elseChild)
// 		block->_elseChild = stmt;
// 	    else
// 		block->_lastElseChild->_next = stmt;
// 	    block->_lastElseChild = stmt;
// 	} else {
// 	    if(!block->_child)
// 		block->_child = stmt;
// 	    else
// 		block->_lastChild->_next = stmt;
// 	    block->_lastChild = stmt;
// 	}
// 	stmt->_parent = block;
// 	return stmt;
// }
// 
// 
// 
// 
// ExprNode *ParseToken(const wxChar **pp)
// {
// 	wxChar	word[256];
// 	const wxChar	*p = *pp;
// 	ExprNode *n;
// 
// 	p = scan_word(*pp, word);
// 	if(!wxStrcmp(word, wxT("Switch"))) {
// 	    n = new ExprNode(SwitchRef);
// 	} else if(!wxStrcmp(word, wxT("Track"))) {
// 	    n = new ExprNode(TrackRef);
// 	} else if(!wxStrcmp(word, wxT("Signal"))) {
// 	    n = new ExprNode(SignalRef);
// 	} else if(!wxStrcmp(word, wxT("Train"))) {
// 	    n = new ExprNode(TrainRef);
// 	} else if(!wxStrcmp(word, wxT("next"))) {
// 	    n = new ExprNode(NextSignalRef);
// 	} else if(!wxStrcmp(word, wxT("nextApproach"))) {
// 	    n = new ExprNode(NextApproachRef);
//         } else if(!wxStrcmp(word, wxT("linked"))) {
//             n = new ExprNode(LinkedRef);
// 	} else if(!wxStrcmp(word, wxT("and"))) {
// 	    n = new ExprNode(And);
// 	} else if(!wxStrcmp(word, wxT("or"))) {
// 	    n = new ExprNode(Or);
// 	} else if(!wxStrcmp(word, wxT("random"))) {
// 	    n = new ExprNode(Random);
// 	} else if(!wxStrcmp(word, wxT("time"))) {
// 	    n = new ExprNode(Time);
// 	} else if(word[0] == '=') {
// 	    n = new ExprNode(Equal);
// 	} else if(word[0] == '!') {
// 	    n = new ExprNode(NotEqual);
// 	} else if(word[0] == '>') {
// 	    n = new ExprNode(Greater);
// 	} else if(word[0] == '<') {
// 	    n = new ExprNode(Less);
// 	} else if(word[0] == '.') {
// 	    n = new ExprNode(Dot);
//         } else {
//             Char *cp;
//             for(cp = word; *cp; ++cp)
//                 if(!isdigit(*cp))
//                     break;
//             if(!*cp) {
// 	        n = new ExprNode(Number);
// 	        n->_val = wxStrtol(word, 0, 0);
// 	    } else if(wxIsalnum(word[0])) {
// 	        n = new ExprNode(String);
// 	        n->_txt = wxStrdup(word);
// 	    } else
// 	        return 0;
//         }
// 	*pp = p;
// 	return n;
// }
// 
// 
// ExprNode::~ExprNode()
// {
// 	if(_op == String && _txt)
// 	    free(_txt);
// 	_txt = 0;
// 	if(_left)
// 	    delete _left;
// 	if(_right)
// 	    delete _right;
// }
// 
// 
// ExprNode *ParseExpr(const wxChar *p)
// {
// 	ExprNode *n, *n1 = 0, *n2 = 0;
// 	ExprNode *root = 0;
// 	wxChar	word[256];
// 
// 	while(*p) {
// 	    n = ParseToken(&p);
// 	    if(!n)
// 		break;
// 	    switch(n->_op) {
// 	    case TrackRef:
// 	    case TrainRef:
// 	    case SwitchRef:
// 	    case SignalRef:
// 		n->_txt = 0;
// 		n->_x = n->_y = 0;
// 		if(p[0] == '.') {
// 		    if(!root)
// 			root = n;
// 		    break;
// 		}
// 		p = scan_word(p, word);
// 		if(word[0] != '(') {
// 		    // error: expected '('
// 		    return 0;
// 		}
// 		n1 = ParseToken(&p);
// 		if(n1->_op == String) {
// 		    n->_txt = n1->_txt;
// 		    n1->_txt = 0;
// 		    delete n1;
// 		    goto end_paren;
// 		}
// 		if(n1->_op != Number) {
// 		    // error: expected number
// 		    delete n;
// 		    delete n1;
// 		    return 0;
// 		}
// 		p = scan_word(p, word);
// 		if(word[0] != ',') {
// 		    // error: expected ','
// 		    delete n;
// 		    delete n1;
// 		    return 0;
// 		}
// 		n2 = ParseToken(&p);
// 		if(n2->_op != Number) {
// 		    // error: expected number
// 		    delete n;
// 		    delete n1;
// 		    delete n2;
// 		    return 0;
// 		}
// 		n->_x = n1->_val;
// 		n->_y = n2->_val;
// 		delete n1;
// 		delete n2;
// end_paren:	if(!root)
// 		    root = n;
// 		p = scan_word(p, word);
// 		if(word[0] != ')') {
// 		    // error: expected '('
// 		    return 0;
// 		}
// 		break;
// 
// 	    case NextSignalRef:
// 	    case NextApproachRef:
//             case LinkedRef:
// 		if(!root)
// 		    root = n;
// 		break;
// 
// 	    case Dot:
// 		if(!root) {
// 		    // error: missing left reference;
// 		    n2 = ParseToken(&p);
// 		    if(!n2)
// 			return 0;
// 		    goto our; // return 0;
// 		}
// 		switch(root->_op) {
// 		case TrackRef:
// 		case SwitchRef:
// 		case SignalRef:
// 		case NextSignalRef:
// 		case NextApproachRef:
//                 case LinkedRef:
// 		case TrainRef:
// 		case Dot:
// 		    break;
// 
// 		default:
// 		    // error: invalid '.' for left expression
// 		    return 0;
// 		}
// 
// 		n2 = ParseToken(&p);
// 		if(!n2)
// 		    return 0;
// 		if(n2->_op == NextSignalRef || n2->_op == NextApproachRef) {
// 		    n->_left = root;
// 		    n->_right = n2;
// 		    n2->_txt = wxStrdup(n2->_op == NextSignalRef ? wxT("next") : wxT("nextApproach"));
// //		    n2->_op = Dot;
// //		    n2->_left = root;
// 		    root = n;
// 		    continue; // goto nxt;
// 		}
// 		if(n2->_op == LinkedRef) {
// 		    n->_left = root;
// 		    n->_right = n2;
// 		    n2->_txt = wxT("linked");
// 		    root = n;
// 		    continue; // goto nxt;
// 		}
// 		if(n2->_op != String) {
// 		    // error: right of '.' must be a name
// 		    return 0;
// 		}
// 
// our:
// 		n->_left = root;
// 		n->_right = n2;
// 		root = n;
// 		break;
// 
// 	    case Equal:
// 	    case NotEqual:
// 	    case Greater:
// 	    case Less:
// 		if(!root) {
// 		    // error: missing left expression
// 		    return 0;
// 		}
// 		n2 = ParseToken(&p);
// 		if(!n2)
// 		    return 0;
// 		n->_left = root;
// 		n->_right = n2;
// 		root = n;
// 		break;
// 
// 	    case And:
// 	    case Or:
// 		if(!root) {
// 		    // error: missing left expression
// 		    return 0;
// 		}
// 		n2 = ParseExpr(p);	    // recurse!
// 		if(!n2)
// 		    return 0;
// 		n->_left = root;
// 		n->_right = n2;
// 		root = n;
// 		return root;
// 
// 	    default:
// 
// 		if(!root)
// 		    root = n;
// 	    }
// 	}
// 	return root;
// }
// 
// 
// Statement *ParseStatements(const wxChar **pp)
// {
// 	wxChar	line[1024];
// 	const wxChar	*p = *pp;
// 	Statement *stmt;
// 
// 	Statement *block = new Statement();
// 	block->_type = 'B';
// 
// 	while(*p) {
// 	    if(match(&p, wxT("if"))) {
// 		stmt = AddStatementToBlock(block);
// 		stmt->_type = 'I';
// 		block = stmt;			// enter new scope
// 		p = scan_line(p, line);
// 		if(line[0])
// 		    stmt->_expr = ParseExpr(line);
// 	    } else if(match(&p, wxT("else"))) {	// exit scope and enter new scope
// 		do {
// 		    if(block->_type != 'I')	// else without if?
// 			return 0;		// error
// 		    if(!block->_isElse)
// 			break;
// 		} while(block = block->_parent);
// 		if(!block)
// 		    return 0;
// 		p = next_token(p);
// 		block->_isElse = true;
// 	    } else if(match(&p, wxT("end"))) {	// exit scope
// 		if(!block->_parent)
// 		    break;
// 		block = block->_parent;
// 		p = next_token(p);
// 	    } else if(match(&p, wxT("return"))) {	// return from function
// 		stmt = AddStatementToBlock(block);
// 		stmt->_type = 'R';		
// 		p = next_token(p);
// 	    } else if(match(&p, wxT("do"))) {
// 		p = scan_line(p, line);
// 		if(!line[0])
// 		    continue;
// 		stmt = AddStatementToBlock(block);
// 		stmt->_type = 'D';
// 		stmt->_text = wxStrdup(line);
// 	    } else {
// 		p = scan_line(p, line);
// 		if(!line[0])
// 		    continue;
// 		stmt = AddStatementToBlock(block);
// 		stmt->_type = 'E';
// 		stmt->_expr = ParseExpr(line); // wxStrdup(line);
// 	    }
// 	}
// 	*pp = p;
// 	return block;
// }
// 
// 
// //
// //
// //
// //
// 
// void	delete_script_data(TrackBase *t)
// {
// 	if(t->type != TSIGNAL)
// 	    return;
// 	if(t->_interpreterData) {
// 	    InterpreterData *interp = (InterpreterData *)t->_interpreterData;
// 	    delete interp;
// 	}
// 	t->_interpreterData = 0;
// }
// 
// void	InterpreterData::TraceCoord(int x, int y, const wxChar *label)
// {
// 	wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("%s(%d,%d)."), label, x, y);
// }
// 
// bool	InterpreterData::Evaluate(ExprNode *n, ExprValue& result)
// {
// 	ExprValue left(None);
// 	ExprValue right(None);
// 	Track	*t;
// 	int	val;
// 	bool	oldForAddr;
// 
// 	switch(n->_op) {
// 
// 	case SignalRef:
// 
// 	    if(n->_txt) {
// 		// signal by name
//                 result._op = n->_op;
//                 result._signal = findSignalNamed(n->_txt);
// 	        wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("Signal(%s)"), n->_txt);
//                 return result._signal != NULL;
// 	    }
// 
// 	    // fall through to x,y case
// 
// 	case SwitchRef:
// 	case TrackRef:
// 	// case TriggerRef:
// 	// case ItineraryRef:
// 
// 	    if(n->_txt) {
// 		// track or switch by name
//                 result._op = n->_op;
//                 result._track = findStationNamed(n->_txt);
// 	        wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("Track(%s)"), n->_txt);
//                 return result._track != NULL;
// 	    }
// 	    TraceCoord(n->_x, n->_y);
// 	    if(!n->_x && !n->_y) {
// 		result._op = n->_op;
// 		result._track = _track;
// 		return true;
// 	    }
// 	    t = find_track(layout, n->_x, n->_y);
// 	    if(!t) {
// 		wxStrcat(expr_buff, wxT("=no track"));
// 		return false;
// 	    }
// 	    result._op = n->_op;
// 	    if(result._op == SignalRef && t->type == TSIGNAL)
// 		result._signal = (Signal *)t;
// 	    else
// 		result._track = t;
// 	    return true;
// 
// 	case TrainRef:
// 
// 	    result._op = TrainRef;
// 	    if(!n->_txt) {
// 		if(!n->_x && !n->_y) {
// 		    result._train = _train;
// 		} else if(!(result._train = findTrain(n->_x, n->_y))) {
// 		    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("Train(%d,%d) - not found"), n->_x, n->_y);
// 		    return false;
// 		}
// 		wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("Train{%s}"), result._train->name);
// 		return true;
// 	    }
// 	    result._train = findTrainNamed(n->_txt);
// 	    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("Train(%s)"), n->_txt);
// 	    return result._train != NULL;
// 
// 	case String:
// 
// 	    result._op = n->_op;
// 	    result._txt = n->_txt;
// 	    wxStrcat(expr_buff, result._txt);
// 	    return true;
// 
// 	case Number:
// 
// 	    result._op = n->_op;
// 	    result._txt = n->_txt;
// 	    result._val = n->_val;
// 	    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("%d"), result._val);
// 	    return true;
// 
// 	case Random:
// 
// 	    result._op = Number;
// 	    result._val = rand() % 100;
// 	    return true;
// 
// 	case Time:
// 
// 	    result._op = Number;
// 	    result._val = ((current_time / 3600) % 24) * 100 + ((current_time / 60) % 60);
// 	    return true;
// 
// 	case Equal:
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(_forCond) {
// 		
// 		// conditionals return false in case of expression error
// 
// 		if(!Evaluate(n->_left, left))
// 		    return true;
// 		wxStrcat(expr_buff, wxT(" = "));
// 		if(!Evaluate(n->_right, right))	    // virtual
// 		    return true;
// 
// 		val = 0;
// 		if(left._op == right._op) {
// 		    switch(left._op) {
// 		    case String:
// 			val = !wxStrcmp(left._txt, right._txt);
// 			break;
// 
// 		    case Number:
// 			val = left._val == right._val;
// 		    }
// 		}
// 		result._op = Number;
// 		result._val = val;
// 		wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("{%d}"), val);
// 		return true;
// 	    }
// 	    oldForAddr = _forAddr;
// 	    _forAddr = true;
// 	    if(!Evaluate(n->_left, result)) {
// 		_forAddr = oldForAddr;
// 		return false;
// 	    }
// 	    _forAddr = oldForAddr;
//             if (result._txt)
// 	        wxStrcat(expr_buff, result._txt);
// 	    wxStrcat(expr_buff, wxT(" = "));
// 	    if(!Evaluate(n->_right, right))	    // virtual
// 		return false;
// 	    switch(result._op) {
// 	    
// 	    case SignalRef:
// 		if(!result._signal)
// 		    return false;
// 		result._signal->SetPropertyValue(result._txt, right);
// 		break;
// 
// 	    case TrackRef:
// 	    case SwitchRef:
// 	    case Addr:
// 		
// 		if(!result._track)
// 		    return false;
// 		result._track->SetPropertyValue(result._txt, right);
// 		return true;
// 
// 	    case TrainRef:
// 
// 		if(!result._train)
// 		    return false;
// 		result._train->SetPropertyValue(result._txt, right);
// 		return false;
// 
// 	    }
// 	    return true;
// 
// 	case NotEqual:
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(!Evaluate(n->_left, left)) {
// 		result._val = 1;	// invalid expressions never match
// 		return true;
// 	    }
// 	    wxStrcat(expr_buff, wxT(" != "));
// 	    if(!Evaluate(n->_right, right))
// 		return true;
// 	    val = 0;
// 	    if(left._op == right._op) {
// 		switch(left._op) {
// 		case String:
// 		    val = wxStrcmp(left._txt, right._txt) != 0;
// 		    break;
// 
// 		case Number:
// 		    val = left._val != right._val;
// 		}
// 	    }
// 	    result._val = val;
// 	    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("{%d}"), val);
// 	    return true;
// 
// 	case Greater:
// 
// 	    // conditionals return false in case of expression error
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(!Evaluate(n->_left, left))
// 		return true;
// 	    wxStrcat(expr_buff, wxT(" > "));
// 	    if(!Evaluate(n->_right, right))
// 		return true;
// 	    val = 0;
// 	    if(left._op == right._op) {
// 		switch(left._op) {
// 		case String:
// 		    val = wxStrcmp(left._txt, right._txt) > 0;
// 		    break;
// 
// 		case Number:
// 		    val = left._val > right._val;
// 		}
// 	    }
// 	    result._val = val;
// 	    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("{%d}"), val);
// 	    return true;
// 
// 	case Less:
// 
// 	    // conditionals return false in case of expression error
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(!Evaluate(n->_left, left))
// 		return true;
// 	    wxStrcat(expr_buff, wxT(" < "));
// 	    if(!Evaluate(n->_right, right))
// 		return true;
// 	    val = 0;
// 	    if(left._op == right._op) {
// 		switch(left._op) {
// 		case String:
// 		    val = wxStrcmp(left._txt, right._txt) < 0;
// 		    break;
// 
// 		case Number:
// 		    val = left._val < right._val;
// 		}
// 	    }
// 	    result._val = val;
// 	    wxSnprintf(expr_buff + wxStrlen(expr_buff), SIZE_LEFT(expr_buff), wxT("{%d}"), val);
// 	    return true;
// 
// 	case Or:
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(Evaluate(n->_left, right) && right._op == Number && right._val != 0) {
// 		result._val = 1;
// 		return true;
// 	    }
// 	    wxStrcat(expr_buff, wxT(" or "));
// 	    // note: invalid expressions evaluate to false (0)
// 	    if(Evaluate(n->_right, right) && right._op == Number && right._val != 0)
// 		result._val = 1;
// 	    else
// 		result._val = 0;
// 	    return true;
// 
// 	case And:
// 
// 	    result._op = Number;
// 	    result._val = 0;
// 	    if(Evaluate(n->_left, right) && right._op == Number && right._val == 0)
// 		return true;
// 	    wxStrcat(expr_buff, wxT(" and "));
// 	    // note: invalid expressions evaluate to false (0)
// 	    if(Evaluate(n->_right, right) && right._op == Number && right._val == 0)
// 		return true;
// 	    result._val = 1;
// 	    return true;
// 	}
// 	return false;
// }
// 
// 
// void	InterpreterData::Execute(Statement *stmt)
// {
// 	ExprValue   result(None);
// 	bool	    valid;
// 
// 	while(stmt) {
// 	    _scopes[_stackPtr] = stmt;
// 
// 	    switch(stmt->_type) {
// 	    case 'B':
// 		++_stackPtr;
// 		stmt = stmt->_child;
// 		continue;
// 
// 	    case 'I':
// 		try {
// 		    wxStrcpy(expr_buff, wxT("if "));
// 		    result._op = None;
// 		    _forCond = true;
// 		    valid = Evaluate(stmt->_expr, result);
// 		    if(!valid) {
// 			if(stmt->_elseChild) {
// 			    wxStrcat(expr_buff, wxT(" -> else"));
// 			    Trace(expr_buff);
// 			    ++_stackPtr;
// 			    stmt = stmt->_elseChild;
// 			    continue;
// 			}
// 			wxStrcat(expr_buff, wxT(" -> false"));
// 		    } else if(result._op == Number) {
// 			if(result._val) {
// 			    wxStrcat(expr_buff, wxT(" -> true"));
// 			    Trace(expr_buff);
// 			    ++_stackPtr;
// 			    stmt = stmt->_child;
// 			    continue;
// 			}
// 			if(stmt->_elseChild) {
// 			    wxStrcat(expr_buff, wxT(" -> else"));
// 			    Trace(expr_buff);
// 			    ++_stackPtr;
// 			    stmt = stmt->_elseChild;
// 			    continue;
// 			}
// 			wxStrcat(expr_buff, wxT(" -> false"));
// 		    } else
// 			wxStrcat(expr_buff, wxT(" * Result not a number"));
// 		    Trace(expr_buff);
// 		} catch(...) {
// 		    abort();
// 		}
// 		break;
// 
// 	    case 'R':
// 		return;
// 
// 	    case 'D':
// 		try {
// 		    wxChar    buff[256];
// 		    wxChar    *p;
// 		    const wxChar *s;
// 
// 		    for(p = buff, s = stmt->_text; *s && p < &buff[sizeof(buff) - 1]; ++s) {
// 			if(*s == '@' && _train) {
// 			    wxStrcpy(p, _train->name);
// 			    while(*p)
// 				++p;
// 			} else
// 			    *p++ = *s;
// 		    }
// 		    *p = 0;
// 		    trainsim_cmd(buff);
// 		} catch(...) {
// 		    abort();
// 		}
// 		break;
// 
// 	    case 'E':
// 		try {
// 		    result._op = None;
// 		    _forCond = false;
// 		    expr_buff[0] = 0;
// 		    Evaluate(stmt->_expr, result);
// 		    Trace(expr_buff);
// 		} catch(...) {
// 		    abort();
// 		}
// 	    }
// 	    while(!stmt->_next) {
// 		if(!_stackPtr)
// 		    return;
// 		stmt = _scopes[--_stackPtr];
// 	    }
// 	    stmt = stmt->_next;
// 	}
// }
// 
// 
// 
// //
// //
// //
// //
// 
// Script	*scriptList;
// 
// void	free_scripts()
// {
// 	Script	*p;
// 
// 	while(scriptList) {
// 	    p = scriptList;
// 	    scriptList = scriptList->_next;
// 	    if(p->_path)
// 		free(p->_path);
// 	    if(p->_text)
// 		free(p->_text);
// 	    free(p);
// 	}
//         onIconUpdateListeners.Clear();
// }
// 
// Script	*find_script(const wxChar *path)
// {
// 	Script	*s;
// 	wxChar	buff[256];
// 	wxChar	*p;
// 
// 	wxStrncpy(buff, path, sizeof(buff) / sizeof(wxChar));
// 	if((p = wxStrchr(buff, '#')))
// 	    *p = 0;
// 	for(s = scriptList; s; s = s->_next) {
// 	    if(!wxStrcmp(s->_path, buff))
// 		return s;
// 	}
// 	return 0;
// }
// 
// Script	*new_script(const wxChar *path)
// {
// 	Script	*s;
// 	wxChar	buff[256];
// 	wxChar	*p;
// 
// 	wxStrncpy(buff, path, sizeof(buff) / sizeof(wxChar));
// 	if((p = wxStrchr(buff, '#')))
// 	    *p = 0;
// 	s = (Script *)calloc(sizeof(Script), 1);
// 	s->_next = scriptList;
// 	scriptList = s;
// 	s->_path = wxStrdup(buff);
// 	s->_text = 0;
// 	return s;
// }
// 
// 
// //	load_scripts
// //	    Collect all script file names from signals
// //	    (and eventually itineraries) in the list
// //	    scriptList. This allows multiple signals to
// //	    share the same script file.
// 
// void	load_scripts(Track *trk)
// {
// 	for(; trk; trk = trk->next) {
// 	    switch(trk->type) {
// 	    case TRACK:
// 	    case SWITCH:
// 	    case ITIN:
// 	    case TRIGGER:
// 	    case IMAGE:
// 		if(!trk->stateProgram)
// 		    continue;
// 		trk->ParseProgram();
// 		trk->OnInit();
// 		continue;
// 
// 	    case TSIGNAL:
// 		if(!trk->stateProgram)
// 		    continue;
// 		Signal *sig = (Signal *)trk;
// 		sig->ParseProgram();
// 		sig->OnInit();
// 	    }
// 	}
//         onIconUpdateListeners.Clear();
//         for(Track *t = layout; t; t = t->next) {
//             if(t->type != IMAGE)
//                 continue;
//             TrackInterpreterData *data = (TrackInterpreterData *)t->_interpreterData;
//             if(!data)
//                 continue;
//             if(data->_onIconUpdate) {
//                 onIconUpdateListeners.Add(t);
//             }
//         }
// }
