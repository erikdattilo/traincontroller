using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {

  //	Coord
  //
  //	A location on the canvas.
  //	The coords are multiplied by HGRID and VGRID
  //	before drawing on the canvas.
  //	Conversely, the coords are divided by HGRID and VGRID
  //	when converting from canvas coord.

  public class Coord {
    public int x;
    public int y;

    public void Set(int _x, int _y) {
      x = _x; y = _y;
    }

    public Coord(int _x, int _y) { x = _x; y = _y; }
    // 	Coord& operator=(Coord& other)
    // 	{
    // 	    x = other.x;
    // 	    y = other.y;
    // 	    return *this;
    // 	}
    // 
    // 	bool operator==(Coord& other) const
    // 	{
    // 	    return x == other.x && y == other.y;
    // 	}
    // 
    // 	bool operator!=(Coord& other) const
    // 	{
    // 	    return x != other.x || y != other.y;
    // 	}
    // 
  }
}
