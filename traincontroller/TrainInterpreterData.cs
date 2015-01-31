using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  class TrainInterpreterData : InterpreterData {
    public Statement _onInit;	// list of actions (statements)
    public Statement _onEntry;
    public Statement _onExit;
    public Statement _onStop;
    public Statement _onWaiting;
    public Statement _onStart;
    public Statement _onReverse;
    public Statement _onAssign;
    public Statement _onShunt;
    public Statement _onArrived;

#if false
  public TrainInterpreterData()
	{
	    _onInit = 0;
	    _onEntry = 0;
	    _onExit = 0;
	    _onStop = 0;
	    _onWaiting = 0;
	    _onStart = 0;
	    _onReverse = 0;
	    _onAssign = 0;
	    _onShunt = 0;
	    _onArrived = 0;
	}

	~TrainInterpreterData()
	{
    //  if(_onInit)
    //delete _onInit;
    //  if(_onEntry)
    //delete _onEntry;
    //  if(_onExit)
    //delete _onExit;
    //  if(_onWaiting)
    //delete _onWaiting;
    //  if(_onStop)
    //delete _onStop;
    //  if(_onStart)
    //delete _onStart;
    //  if(_onReverse)
    //delete _onReverse;
    //  if(_onShunt)
    //delete _onShunt;
    //  if(_onAssign)
    //delete _onAssign;
    //  if(_onArrived)
    //delete _onArrived;
	}

	Statement _onInit;	// list of actions (statements)
	Statement _onEntry;
	Statement _onExit;
	Statement _onStop;
	Statement _onWaiting;
	Statement _onStart;
	Statement _onReverse;
	Statement _onAssign;
	Statement _onShunt;
	Statement _onArrived;

bool Evaluate(ExprNode n, ExprValue result)
{
	ExprValue left = new ExprValue(None);
	ExprValue right = new ExprValue(None);
	string prop;

	if(!n)
	    return false;
        switch(n._op) {

	case Dot:
	    
	    result._op = Addr;
	    if(!(n._left)) {
		result._train = this._train;		// .<property> .   this.train
		result._op = TrainRef;
		if(!result._train) {
		    wxStrcat(expr_buff, wxT("no current train for '.'"));
		    return false;
		}
		if(result._train.position)
		    TraceCoord(result._train.position.x, result._train.position.y);
	    } else {
		if(!Evaluate(n._left, result))
		    return false;
	    }
	    result._txt = (n._right && n._right._op == String) ? n._right._txt : n._txt;
	    if(_forAddr)
		return true;

	    prop = result._txt;
	    if(!prop)
		return false;

	    switch(result._op) {
	    
	    case TrainRef:

		if(!result._train)
		    return false;
		return result._train.GetPropertyValue(prop, result);

	    case SwitchRef:

		if(!wxStrcmp(prop, wxT("thrown")) && result._track) {
		    result._op = Number;
		    result._val = result._track.switched;
		    return true;
		}

	    case Addr:
	    case TrackRef:
	    default:

		if(!result._track)
		    return false;
		return result._track.GetPropertyValue(prop, result);

	    case SignalRef:

		if(!result._signal)
		    return false;
		return result._signal.GetPropertyValue(prop, result);

	    }

	default:
	    return InterpreterData::Evaluate(n, result);
	}
	return false;
}


#endif
  }
}