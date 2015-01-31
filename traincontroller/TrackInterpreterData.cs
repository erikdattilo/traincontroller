using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {

  public class TrackInterpreterData : InterpreterData {

    public Statement _onInit;	// list of actions (statements)
    public Statement _onSetBusy;
    public Statement _onSetFree;
    public Statement _onEnter;
    public Statement _onExit;
    public Statement _onClicked;
    public Statement _onCanceled;
    public Statement _onCrossed;
    public Statement _onArrived;
    public Statement _onStopped;
    public Statement _onIconUpdate;

    public void TraceCoord(int x, int y, string label) {
      GlobalVariables.expr_buff += String.Format(wxPorting.T("%s(%d,%d)."), label, x, y);
    }
  }
}