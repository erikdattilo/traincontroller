using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class SwitchBoardCellAspect {
    public SwitchBoardCellAspect _next;
    public string _name;		// aspect name
    public string[] _icons = new string[4];		// image to show in cell if any
    public string _action;		// URL of action to perform when clicked
    public string _bgcolor;		// background color for this aspect
  }
}