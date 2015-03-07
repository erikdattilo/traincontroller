using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {

  public partial class TDSkin {
    public TDSkin next;
    public string name;
    public int free_track;		// default: black
    public int reserved_track;		// default: green
    public int reserved_shunting;	// default: white
    public int occupied_track;		// default: orange
    public int working_track;		// default: blue
    public int background;		// default: gray
    public int outline;		// default: dark_gray
    public int text;			// default: black

    public TDSkin() {
      if(Globals.defaultSkin == null)
        return;
      this.next = null;
      this.name = null;
      this.free_track = Globals.defaultSkin.free_track;
      this.reserved_track = Globals.defaultSkin.reserved_track;
      this.reserved_shunting = Globals.defaultSkin.reserved_shunting;
      this.occupied_track = Globals.defaultSkin.occupied_track;
      this.working_track = Globals.defaultSkin.working_track;
      this.background = Globals.defaultSkin.background;
      this.outline = Globals.defaultSkin.outline;
    }

    ~TDSkin() {
      name = null;
    }
  }

}
