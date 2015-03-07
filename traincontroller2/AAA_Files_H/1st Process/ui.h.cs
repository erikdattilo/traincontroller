/*	ui.h - Created by Giampiero Caprino
 
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

  public class tr_rect {
    public int left, top;
    public int right, bottom;
  }

  public class VLines {
    public int x0, y0;
    public int x1, y1;

    public VLines(int x0_, int y0_, int x1_, int y1_) {
      x0 = x0_;
      x1 = x1_;
      y0 = y0_;
      y1 = y1_;
    }

    public VLines(int all)
      : this(all, all, all, all) {
    }
  }

  public enum SegDir {
    SEG_N = 0,
    SEG_NE = 1,
    SEG_E = 2,
    SEG_SE = 3,
    SEG_S = 4,
    SEG_SW = 5,
    SEG_W = 6,
    SEG_NW = 7,
    SEG_END = 8
  }

  public class TrLabel {
    public String text;
    public string oldtext;
    public object handle;

    public TrLabel(String str) {
      throw new NotImplementedException();
    }
  }
   

  public class edittools {
    public trktype type;
    public trkdir direction;
    public int x, y;
    public Track trk;

    public edittools() {
    }

    public edittools(trktype type_, int direction_, int x_, int y_)
      : this(type_, (trkdir)direction_, x_, y_) {
    }

    public edittools(trktype type_, trkdir direction_, int x_, int y_) {
      type = type_;
      direction = direction_;
      x = x_;
      y = y_;
    }
  }


  // 
  // struct clist {
  // 	String title;
  // 	String *headers;
  // 	int	*col_width;
  // 	String (*col_string)(int row, int col, void *ptr);
  // };
  // 
  public enum AskAnswer {
    ANSWER_NO = 0,
    ANSWER_YES = 1
  }

}