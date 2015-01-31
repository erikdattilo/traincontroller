using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirNET {
  public class TDSkin {
    public TDSkin next = null;
    public string name = null;

    public int free_track;		// default: black
    public int reserved_track;		// default: green
    public int reserved_shunting;	// default: white
    public int occupied_track;		// default: orange
    public int working_track;		// default: blue
    public int background;		// default: gray
    public int outline;		// default: dark_gray
    public int text;			// default: black

    public TDSkin() {

      if(GlobalVariables.defaultSkin == null)
        return;

      this.free_track = GlobalVariables.defaultSkin.free_track;
      this.reserved_track = GlobalVariables.defaultSkin.reserved_track;
      this.reserved_shunting = GlobalVariables.defaultSkin.reserved_shunting;
      this.occupied_track = GlobalVariables.defaultSkin.occupied_track;
      this.working_track = GlobalVariables.defaultSkin.working_track;
      this.background = GlobalVariables.defaultSkin.background;
      this.outline = GlobalVariables.defaultSkin.outline;
    }
  }
}