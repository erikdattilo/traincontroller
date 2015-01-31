using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class SwitchBoardCell {
    public SwitchBoardCell _next;	    // next cell in switchboard

    public int _x, _y;		    // position in SwitchBoard._cells
    public string _itinerary;	    // linked itinerary
    public string _text;		    // text to draw, if any

    string _aspect;	    // current aspect
    string _stateProgram;
    // void	*_interpreterData;
  }
}