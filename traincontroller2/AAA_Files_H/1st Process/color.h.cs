 /*	color.h - Created by Giampiero Caprino
 
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

namespace Traincontroller2 {
  public class grcolor {
    private int mInt;

    private grcolor(int i) {
      mInt = i;
    }

    public static implicit operator grcolor(int i) {
      return new grcolor(i);
    }

    public static implicit operator int(grcolor color) {
      return color == null ? -1 : color.mInt;
    }
  }

  public enum fieldcolor {
    COL_BACKGROUND = 0,
    COL_TRACK = 1,
    COL_GRAPHBG = 2,
    COL_TRAIN1 = 3,
    COL_TRAIN2 = 4,
    COL_TRAIN3 = 5,
    COL_TRAIN4 = 6,
    COL_TRAIN5 = 7,
    COL_TRAIN6 = 8,
    COL_TRAIN7 = 9,
    COL_TRAIN8 = 10,
    COL_TRAIN9 = 11,
    COL_TRAIN10 = 12,
    MAXFIELDCOL
  }
}