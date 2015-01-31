// /*	run.cpp - Created by Giampiero Caprino
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

using System;

namespace Traincontroller2 {

  public class SaveAssign {
    public SaveAssign next;
    public Train oldTrain;
    public Train newTrain;
  }

  public static partial class Globals {

    public static short[] startDelay = new short[Config.NTTYPES];
    public static double[] accelRate = new double[Config.NTTYPES];

    public static int assign_ok = 1;

    public static int changed;
    public static int signals_changed;

    public static SaveAssign save_assign_list;

    public static int[] late_data = new int[60 * 24];	// 60 minutes * 24 hours

    public static void Vector_dump(Train trn, String suff) {
      TrackBase trk;
      int i;
      Vector v;
      string buff;

      /* For debugging purposes */

      buff = String.Format(wxPorting.T("%s - %s"), trn.name, suff);
      Globals.traindir.layout_error(buff);
      v = trn.path;
      if(v == null) {
        Globals.traindir.layout_error(wxPorting.T("No Path"));
      } else for(i = 0; i < v._size; i++) {
          trk = v._ptr[i];
          if(trk == null) {
            buff = String.Format(wxPorting.T("%3d - null"), i);
            continue;
          }
          buff = String.Format(wxPorting.T("%3d - %3d, %3d"),
        i, trk.x, trk.y); //, trn.pathpos == i ? wxPorting.T(" <-") : wxPorting.T(""));
          Globals.traindir.layout_error(buff);
        }

      if(trn.length != 0 || trn.tail != null || trn.tail.path != null) {
        Globals.traindir.end_layout_error();
        return;
      }
      buff = String.Format(wxPorting.T("Tail:"), trn.name);
      Globals.traindir.layout_error(buff);
      v = trn.tail.path;
      for(i = 0; i < v._size; i++) {
        trk = v._ptr[i];
        if(trk == null)
          buff = String.Format(wxPorting.T("%3d - null"), i);
        else
          buff = String.Format(wxPorting.T("%3d - %3d, %3d"), i, trk.x, trk.y);
        Globals.traindir.layout_error(buff);
      }
      buff = String.Format(wxPorting.T(""));
      Globals.traindir.layout_error(buff);
      Globals.traindir.end_layout_error();
    }

    public static bool sameSubPath(Vector v1, Vector v2) {
      int i, e;
      Track t1, t2;

      e = v2._size - 1;
      for(i = v1._size - 1; i >= 0; --i) {
        t1 = v1.TrackAt(i);
        t2 = v2.TrackAt(e);
        if(t1.x != t2.x || t1.y != t2.y)
          return false;
        if(e-- == 0)
          return true;
      }
      return true;
    }

    public static Vector appendPath(Vector oldpath, Vector newelems) {
      int i, j;
      Track trk;

      if(oldpath == null)
        oldpath = Globals.new_Vector();
      for(i = 0; i < newelems._size; ++i) {
        for(j = 0; j < oldpath._size; ++j)
          if(oldpath.TrackAt(j) == newelems.TrackAt(i))
            break;
        if(j < oldpath._size)
          continue;
        trk = newelems.TrackAt(i);
        oldpath.Add(trk, newelems.FlagAt(i));
      }
      return oldpath;
    }

    public static void reverse_path(Train tr) {
      tr.path.Reverse();
    }

    /*	findPath0
     *
     *	This is one of the main functions of the program.
     *	It is responsible for computing and validating the
     *	next path that the train will have to travel,
     *	based on the position of the switches and the
     *	type of the tracks.
     *
     *	The path is first computed by "walking" each track.
     *	The track routines return the next track based on
     *	the current track and the track or switch orientation.
     *
     *	When we reach the next signal, or the end of the line
     *	we validate the path by walking back. This is necessary
     *	because switches might point us to the wrong direction
     *	when travelled backwards.
     *
     *	Also note that we don't care about any train being
     *	on the path. pathIsBusy() below takes care of that.
     */

    public static Vector findPath0(Vector path, Track t, trkdir dir) {
      throw new NotImplementedException();

    //  Track t1, tbck;
    //  Track to;
    //  int cx, cy;
    //  int i;
    //  Track sw;
    //  Signal s;
    //  trkdir ndir;

    //  if(path == null)
    //    path = Globals.new_Vector();
    //  else
    //    path.Empty();
    //  if(t == null)
    //    return path;
    //agn:
    //  path.Add(t, dir);
    //  cx = t.x;
    //  cy = t.y;
    //  to = t;
    //  if(dir == trkdir.E_W || dir == trkdir.N_S) {		/* westbound */
    //    ndir = (trkdir)dir;
    //    while(true) {
    //      if(to.type == trktype.TRACK)
    //        t1 = track_walkwest(to, ndir);
    //      else
    //        t1 = swtch_walkwest(to, ndir);
    //      if(t1 == null)
    //        break;
    //    nxtw:
    //      if(path._size >= total_track_number)// impossible
    //        goto err;
    //      t = findTrack(t1.x, t1.y);
    //      if(t != null) {
    //        if(t.wsignal != null && ndir != trkdir.S_N) {
    //          s = (Signal)t.wsignal;
    //          if(!s.IsApproach())	    // 4.0
    //            break;
    //        }
    //        if(t.x == to.wlinkx && t.y == to.wlinky &&
    //       t.wlinkx == to.x && t.wlinky == to.y) {
    //          dir = trkdir.W_E;
    //          if(t.wsignal != null) {
    //            s = (Signal)t.wsignal;
    //            if(!s.IsApproach())    // 4.0
    //              break;
    //          }
    //          goto agn;
    //        }
    //        if(t.direction == trkdir.XH_SW_NE) {
    //          path.Add(t, ndir);
    //          if(to.y != t1.y)
    //            ++t1.y;
    //          --t1.x;
    //          to = t;
    //          goto nxtw;
    //        }
    //        if(t.direction == trkdir.XH_NW_SE) {
    //          path.Add(t, ndir);
    //          if(to.y != t1.y)
    //            --t1.y;
    //          --t1.x;
    //          to = t;
    //          goto nxtw;
    //        }
    //        if(t.direction == trkdir.X_X) {
    //          path.Add(t, ndir);
    //          if(to.y < t.y)
    //            ++t1.y;
    //          else
    //            --t1.y;
    //          if(to.x < t.x)
    //            ++t1.x;
    //          else
    //            --t1.x;
    //          goto nxtw;
    //        }
    //        if(t.direction == trkdir.X_PLUS) {
    //          path.Add(t, ndir);
    //          if(to.y < t.y)
    //            ++t1.y;
    //          else if(to.y > t.y)
    //            --t1.y;
    //          else
    //            --t1.x;
    //          goto nxtw;
    //        }
    //        if(t.direction == trkdir.N_NE_S_SW) {
    //          path.Add(t, ndir);
    //          if(to.x == t.x) {
    //            if(ndir == trkdir.N_S)
    //              ++t1.y;
    //            else
    //              --t1.y;
    //          } else {
    //            if(t.y < to.y) {
    //              --t1.y; ++t1.x;   // move sw to ne
    //            } else if(t.y > to.y) {
    //              ++t1.y; --t1.x;   // move ne to sw
    //            }
    //          }
    //          goto nxtw;
    //        }
    //        if(t.direction == trkdir.N_NW_S_SE) {
    //          path.Add(t, ndir);
    //          if(to.x == t.x) {
    //            if(ndir == trkdir.N_S)
    //              ++t1.y;
    //            else
    //              --t1.y;
    //          } else {
    //            if(t.y > to.y) {
    //              ++t1.y; ++t1.x;   // move nw to se
    //            } else if(t.y < to.y) {
    //              --t1.y; --t1.x;   // move se to nw
    //            }
    //          }
    //          goto nxtw;
    //        }
    //        if(ndir == trkdir.W_E || ndir == trkdir.S_N) {
    //          dir = ndir;
    //          goto agn;
    //        }
    //        path.Add(t, ndir);
    //        to = t;
    //        cx = t.x;
    //        cy = t.y;
    //        continue;
    //      }
    //      sw = findSwitch(t1.x, t1.y);
    //      if(sw != null) {
    //        if(ndir == trkdir.W_E) {
    //          if(sw.direction == (trkdir)8 || sw.direction == (trkdir)9 ||
    //            sw.direction == (trkdir)16 || sw.direction == (trkdir)17)
    //            goto we89;
    //          t = sw;
    //          dir = trkdir.W_E;
    //          goto agn;
    //        }
    //      ew89: path.Add(sw, ndir);
    //        cx = sw.x;
    //        cy = sw.y;
    //        if(sw.direction == (trkdir)8) {/* special case: english switch */
    //          --t1.x;
    //          if(to.y == cy) {/* we come from a horiz track */
    //            if(sw.switched)
    //              ++t1.y;
    //          } else if(!sw.switched)
    //            ++t1.y;
    //          to = sw;
    //          goto nxtw;
    //        }
    //        if(sw.direction == (trkdir)9) {/* special case: english switch */
    //          --t1.x;
    //          if(to.y == cy) {/* we come from a horiz track */
    //            if(sw.switched)
    //              --t1.y;
    //          } else if(!sw.switched)
    //            --t1.y;
    //          to = sw;
    //          goto nxtw;
    //        }
    //        if(sw.direction == (trkdir)16) {/* special case: english switch sw-ne */
    //          if(sw.switched) {
    //            if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                --t1.x;
    //                ++t1.y;
    //                ndir = trkdir.E_W;
    //              } else {
    //                ++t1.y;
    //              }
    //            } else if(ndir == trkdir.S_N) {
    //              if(to.x == cx) {
    //                --t1.y;
    //                ++t1.x;
    //                ndir = trkdir.W_E;
    //              } else
    //                --t1.y;
    //            } else {	    /* E_W */
    //              if(to.x == cx) {
    //                ++t1.y;
    //                --t1.x;
    //              } else {
    //                ++t1.y;
    //                ndir = trkdir.N_S;
    //              }
    //            }
    //          } else {
    //            if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.y;
    //              } else {
    //                ++t1.y;
    //                --t1.x;
    //              }
    //            } else if(ndir == trkdir.S_N) {
    //              if(to.x == cx)
    //                --t1.y;
    //              else {
    //                --t1.y;
    //                --t1.x;
    //              }
    //            } else {	    /* E_W */
    //              if(to.x == cx) {
    //                ++t1.y;
    //                ndir = trkdir.N_S;
    //              } else {
    //                ++t1.y;
    //                --t1.x;
    //              }
    //            }
    //          }
    //          to = sw;
    //          goto nxtw;
    //        }
    //        if(sw.direction == (trkdir)17) {/* special case: english switch nw-se */
    //          if(sw.switched) {
    //            if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.x;
    //                ++t1.y;
    //                ndir = trkdir.W_E;
    //                goto nxte;
    //              } else {
    //                ++t1.y;
    //              }
    //            } else {	    /* E_W */
    //              if(to.x == cx) {
    //                --t1.y;
    //                --t1.x;
    //              } else {
    //                --t1.y;
    //                ndir = trkdir.S_N;
    //                goto nxte;
    //              }
    //            }
    //          } else {
    //            if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.y;
    //              } else {
    //                ++t1.y;
    //                ++t1.x;
    //              }
    //            } else {	    /* E_W */
    //              if(to.x == cx) {
    //                --t1.y;
    //                ndir = trkdir.S_N;
    //                goto nxte;
    //              } else {
    //                --t1.y;
    //                --t1.x;
    //              }
    //            }
    //          }
    //          to = sw;
    //          goto nxtw;
    //        }
    //        to = sw;
    //        continue;
    //      }
    //      tbck = findLinkTo(to.x, to.y);
    //      if(tbck != null) {
    //        path.Add(tbck, ndir);
    //        break;
    //      }
    //      Globals.wxPrintf(wxPorting.T("No trk west of %d,%dn"), cx, cy);
    //      break;
    //    }
    //    if(ndir == trkdir.N_S)
    //      ndir = trkdir.S_N;
    //    else if(ndir == trkdir.S_N)
    //      ndir = trkdir.N_S;
    //    else
    //      ndir = trkdir.W_E;
    //    for(i = path._size - 1; i > 0; --i) {
    //    chkw:
    //      to = path.TrackAt(i);
    //      t1 = path.TrackAt(i - 1);
    //      if(to.type == trktype.TEXT) {
    //        if(to.elinkx != 0 && to.elinky != 0)
    //          tbck = findTrack(to.elinkx, to.elinky);
    //        else
    //          tbck = findTrack(to.wlinkx, to.wlinky);
    //        if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //          goto err;
    //        continue;
    //      }
    //      if(to.type == trktype.TRACK) {
    //        if(to.direction == trkdir.XH_NW_SE)
    //          continue;
    //        if(to.direction == trkdir.XH_SW_NE)
    //          continue;
    //        if(to.direction == trkdir.X_X || to.direction == trkdir.X_PLUS ||
    //        to.direction == trkdir.N_NE_S_SW || to.direction == trkdir.N_NW_S_SE)
    //          continue;
    //        tbck = track_walkeast(to, ndir);
    //        if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //          goto err;
    //        if(path.FlagAt(i - 1) == (int)trkdir.W_E && i > 1) {
    //          --i;
    //          goto chke;
    //        }
    //        continue;
    //      }
    //      if(to.direction == (trkdir)8) {
    //        if(t1.x == to.x + 1 && t1.y != to.y + 1)
    //          continue;
    //        goto err;
    //      }
    //      if(to.direction == (trkdir)9) {
    //        if(t1.x == to.x + 1 && t1.y != to.y - 1)
    //          continue;
    //        goto err;
    //      }
    //      if(to.direction == (trkdir)16) {
    //        //		    if(t1.y == to.y - 1 && t1.x != to.x + 1)
    //        //			continue;
    //        if(to.switched && ndir == trkdir.E_W)
    //          ndir = trkdir.N_S;
    //        if(to.switched && ndir == trkdir.W_E)
    //          ndir = trkdir.S_N;
    //        continue;
    //      }
    //      if(to.direction == (trkdir)17) {
    //        //		    if(t1.y == to.y - 1 && t1.x != to.x - 1)
    //        if(to.switched && ndir == trkdir.W_E)
    //          ndir = trkdir.N_S;
    //        if(to.switched && ndir == trkdir.E_W)
    //          ndir = trkdir.S_N;
    //        continue;
    //      }
    //      tbck = swtch_walkeast(to, ndir);
    //      if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //        goto err;
    //      if(path.FlagAt(i - 1) == (int)trkdir.W_E && i > 1) {
    //        --i;
    //        goto chke;
    //      }
    //    }
    //  } else {			/* eastbound */
    //    ndir = (trkdir)dir;
    //    while(true) {
    //      if(to.type == trktype.TRACK)
    //        t1 = track_walkeast(to, ndir);
    //      else
    //        t1 = swtch_walkeast(to, ndir);
    //      if(t1 == null)
    //        break;
    //    nxte:
    //      if(path._size >= total_track_number)	// impossible
    //        goto err;
    //      t = findTrack(t1.x, t1.y);
    //      if(t != null) {
    //        if(t.esignal != null && ndir != trkdir.N_S) {
    //          Signal s1 = (Signal)t.esignal;
    //          if(!s1.IsApproach())
    //            break;
    //        }
    //        if(t.x == to.elinkx && t.y == to.elinky &&
    //       t.elinkx == to.x && t.elinky == to.y) {
    //          dir = trkdir.E_W;
    //          if(t.esignal != null) {
    //            s = (Signal)t.esignal;
    //            if(!s.IsApproach())
    //              break;
    //          }
    //          goto agn;
    //        }
    //        if(t.direction == trkdir.XH_SW_NE) {
    //          path.Add(t, ndir);
    //          if(to.y != t1.y)
    //            --t1.y;
    //          ++t1.x;
    //          to = t;
    //          goto nxte;
    //        }
    //        if(t.direction == trkdir.XH_NW_SE) {
    //          path.Add(t, ndir);
    //          if(to.y != t1.y)
    //            ++t1.y;
    //          ++t1.x;
    //          to = t;
    //          goto nxte;
    //        }
    //        if(t.direction == trkdir.X_X) {
    //          path.Add(t, ndir);
    //          if(to.y < t.y)
    //            ++t1.y;
    //          else
    //            --t1.y;
    //          if(to.x < t.x)
    //            ++t1.x;
    //          else
    //            --t1.x;
    //          goto nxte;
    //        }
    //        if(t.direction == trkdir.X_PLUS) {
    //          path.Add(t, ndir);
    //          if(to.y < t.y)
    //            ++t1.y;
    //          else if(to.y > t.y)
    //            --t1.y;
    //          else
    //            ++t1.x;
    //          goto nxte;
    //        }
    //        if(t.direction == trkdir.N_NE_S_SW) {
    //          path.Add(t, ndir);
    //          if(to.x == t.x) {
    //            if(ndir == trkdir.N_S)
    //              ++t1.y;
    //            else
    //              --t1.y;
    //          } else {
    //            if(t.y < to.y) {
    //              --t1.y; ++t1.x;
    //            } else if(t.y > to.y) {
    //              ++t1.y; --t1.x;
    //            }
    //          }
    //          goto nxte;
    //        }
    //        if(t.direction == trkdir.N_NW_S_SE) {
    //          path.Add(t, ndir);
    //          if(to.x == t.x) {
    //            if(ndir == trkdir.N_S)
    //              ++t1.y;
    //            else
    //              --t1.y;
    //          } else {
    //            if(t.y < to.y) {	    // moving north-eastward
    //              --t1.y; --t1.x;
    //            } else if(t.y > to.y) {   // moving south-eastward
    //              ++t1.y; ++t1.x;
    //            }
    //          }
    //          goto nxte;
    //        }
    //        if(ndir == trkdir.E_W || ndir == trkdir.N_S) {
    //          dir = ndir;
    //          goto agn;
    //        }
    //        path.Add(t, ndir);
    //        to = t;
    //        cx = t.x;
    //        cy = t.y;
    //        continue;
    //      }
    //      sw = findSwitch(t1.x, t1.y);
    //      if(sw != null) {
    //        if(ndir == trkdir.E_W) {
    //          if(sw.direction == (trkdir)8 || sw.direction == (trkdir)9 ||
    //              sw.direction == (trkdir)16 || sw.direction == (trkdir)17)
    //            goto ew89;
    //          t = sw;
    //          dir = trkdir.E_W;
    //          goto agn;
    //        }
    //      we89: path.Add(sw, ndir);
    //        cx = sw.x;
    //        cy = sw.y;
    //        if(sw.direction == (trkdir)8) {/* special case: english switch */
    //          ++t1.x;
    //          if(to.y == cy) {/* we come from a horiz track */
    //            if(sw.switched)
    //              --t1.y;
    //          } else if(!sw.switched)
    //            --t1.y;
    //          to = sw;
    //          goto nxte;
    //        }
    //        if(sw.direction == (trkdir)9) {/* special case: english switch */
    //          ++t1.x;
    //          if(to.y == cy) {/* we come from a horiz track */
    //            if(sw.switched)
    //              ++t1.y;
    //          } else if(!sw.switched)
    //            ++t1.y;
    //          to = sw;
    //          goto nxte;
    //        }
    //        if(sw.direction == (trkdir)16) {/* special case: english switch sw-ne */
    //          if(sw.switched) {
    //            if(ndir == trkdir.S_N) {
    //              if(to.x == cx) {
    //                --t1.y;
    //                ++t1.x;
    //                ndir = trkdir.W_E;
    //                goto nxte;
    //              } else {
    //                --t1.y;
    //              }
    //            } else if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.y;
    //                --t1.x;
    //                ndir = trkdir.E_W;
    //                goto nxtw;
    //              } else {
    //                ++t1.y;
    //              }
    //            } else {	    /* W_E */
    //              if(to.x == cx) {
    //                --t1.y;
    //                ++t1.x;
    //              } else {
    //                --t1.y;
    //                //				    --t1.x;
    //                ndir = trkdir.S_N;
    //              }
    //              goto nxte;
    //            }
    //          } else {
    //            if(ndir == trkdir.S_N) {
    //              if(to.x == cx) {
    //                --t1.y;
    //              } else {
    //                --t1.y;
    //                ++t1.x;
    //                ndir = trkdir.W_E;
    //              }
    //            } else if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.y;
    //              } else {
    //                ++t1.y;
    //                --t1.x;
    //                ndir = trkdir.E_W;
    //              }
    //            } else {	    /* W_E */
    //              if(to.x == cx) {
    //                --t1.y;
    //                --t1.x;
    //                ndir = trkdir.S_N;
    //              } else {
    //                --t1.y;
    //                ++t1.x;
    //              }
    //            }
    //          }
    //          to = sw;
    //          goto nxte;
    //        }
    //        if(sw.direction == (trkdir)17) {/* special case: english switch */
    //          if(sw.switched) {
    //            if(ndir == trkdir.S_N) {
    //              if(to.x == cx) {
    //                --t1.x;
    //                --t1.y;
    //                ndir = trkdir.E_W;
    //                goto nxtw;
    //              } else {
    //                --t1.y;
    //              }
    //            } else if(ndir == trkdir.N_S) {
    //              if(to.x == cx) {
    //                ++t1.x;
    //                ++t1.y;
    //                ndir = trkdir.W_E;
    //                goto nxte;
    //              } else {
    //                ++t1.y;
    //              }
    //            } else {	    /* W_E */
    //              if(to.x == cx) {
    //                ++t1.y;
    //                ++t1.x;
    //              } else {
    //                ++t1.y;
    //                ndir = trkdir.N_S;
    //              }
    //              goto nxtw;
    //            }
    //          } else {	    /* switch is not thrown */
    //            if(ndir == trkdir.S_N) {
    //              if(to.x == cx) {
    //                --t1.y;
    //              } else {
    //                --t1.y;
    //                --t1.x;
    //                ndir = trkdir.W_E;
    //              }
    //            } else if(ndir == trkdir.N_S) {
    //              if(to.x == cx)
    //                ++t1.y;
    //              else {
    //                ++t1.y;
    //                ++t1.x;
    //              }
    //            } else {	    /* W_E */
    //              if(to.x == cx) {
    //                --t1.y;
    //                ndir = trkdir.S_N;
    //              } else {
    //                ++t1.y;
    //                ++t1.x;
    //              }
    //            }
    //          }
    //          to = sw;
    //          goto nxte;
    //        }
    //        to = sw;
    //        continue;
    //      }
    //      tbck = findLinkTo(to.x, to.y);
    //      if(tbck != null) {
    //        path.Add(tbck, ndir);
    //        break;
    //      }
    //      Globals.wxPrintf(wxPorting.T("No trk east of %d,%dn"), cx, cy);
    //      break;
    //    }
    //    if(ndir == trkdir.N_S)
    //      ndir = trkdir.S_N;
    //    else if(ndir == trkdir.S_N)
    //      ndir = trkdir.N_S;
    //    else
    //      ndir = trkdir.E_W;
    //    for(i = path._size - 1; i > 0; --i) {
    //    chke:
    //      to = path.TrackAt(i);
    //      t1 = path.TrackAt(i - 1);
    //      if(to.type == trktype.TEXT) {
    //        if(to.wlinkx != 0 && to.wlinky != 0)
    //          tbck = findTrack(to.wlinkx, to.wlinky);
    //        else
    //          tbck = findTrack(to.elinkx, to.elinky);
    //        if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //          goto err;
    //        continue;
    //      }
    //      if(to.type == trktype.TRACK) {
    //        if(to.direction == trkdir.XH_NW_SE)
    //          continue;
    //        if(to.direction == trkdir.XH_SW_NE)
    //          continue;
    //        if(to.direction == trkdir.X_X || to.direction == trkdir.X_PLUS ||
    //      to.direction == trkdir.N_NE_S_SW || to.direction == trkdir.N_NW_S_SE)
    //          continue;
    //        tbck = track_walkwest(to, ndir);
    //        if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //          goto err;
    //        if(path.FlagAt(i - 1) == (int)trkdir.E_W && i > 1) {
    //          --i;
    //          goto chkw;
    //        }
    //        continue;
    //      }
    //      if(to.direction == (trkdir)8) {
    //        if(t1.x == to.x - 1 && t1.y != to.y - 1)
    //          continue;
    //        goto err;
    //      }
    //      if(to.direction == (trkdir)9) {
    //        if(t1.x == to.x - 1 && t1.y != to.y + 1)
    //          continue;
    //        goto err;
    //      }
    //      if(to.direction == (trkdir)16) {
    //        //		    if(t1.y == to.y - 1 && t1.x != to.x - 1)
    //        if(to.switched && ndir == trkdir.E_W)
    //          ndir = trkdir.N_S;
    //        if(to.switched && ndir == trkdir.W_E)
    //          ndir = trkdir.S_N;
    //        continue;
    //      }
    //      if(to.direction == (trkdir)17) {
    //        if(to.switched && ndir == trkdir.W_E)
    //          ndir = trkdir.N_S;
    //        if(to.switched && ndir == trkdir.E_W)
    //          ndir = trkdir.S_N;
    //        continue;
    //      }
    //      tbck = swtch_walkwest(to, ndir);
    //      if(tbck == null || tbck.x != t1.x || tbck.y != t1.y)
    //        goto err;
    //      if(path.FlagAt(i - 1) == (int)trkdir.E_W && i > 1) {
    //        --i;
    //        goto chkw;
    //      }
    //      continue;
    //    }
    //  }
    //  path.ComputeLength();
    //  return path;
    //err:
    //  Globals.Vector_delete(path);
    //  return null;
    }

    public static Vector findPath(Track trk, trkdir dir) {
      return findPath0(null, trk, dir);
    }

    /*	pathIsBusy
     *
     *	Return 0 if path is clear from start to end.
     *	Return number of busy path element + 1 otherwise.
     */

    public static int pathIsBusy(Train tr, Vector path, trkdir dir) {
      int el, nel;
      Track t;
      Track trk;
      Train trn;

      if(path == null)
        return 0;
      nel = path._size;
      for(el = 0; el < nel; ++el) {
        t = path.TrackAt(el);
        if(t.IsBusy()) {
          trk = findTrack(t.x, t.y);
          if(trk == null) {
            if(findText(t.x, t.y) != null)
              return 0;
            return el + 1;
          }
          if(el != null)
            switch(dir) {
              case trkdir.W_E:
              case trkdir.signal_EAST_FLEETED:
              case trkdir.S_N:
              case trkdir.signal_NORTH_FLEETED:
                if(trk.esignal != null && !trk.esignal.IsApproach())
                  return 0;
                break;
              case trkdir.E_W:
              case trkdir.signal_WEST_FLEETED:
              case trkdir.N_S:
              case trkdir.signal_SOUTH_FLEETED:
                if(trk.wsignal != null && !trk.wsignal.IsApproach())
                  return 0;
                break;
            }
          /*wxPrintf(wxPorting.T("busy at %d,%dn"), trk.x, trk.y);*/
          return el + 1;
        }
        if((trn = findTrain(t.x, t.y)) != null && trn != tr) {
          /*wxPrintf(wxPorting.T("busy for train at %d,%dn"), t.x, t.y);*/
          return el + 1;
        }
        if((trn = findTail(t.x, t.y)) != null && trn != tr) {
          return el + 1;
        }
        if((trn = findStranded(t.x, t.y)) != null && trn != tr) {
          /*wxPrintf(wxPorting.T("busy for train at %d,%dn"), t.x, t.y);*/
          return el + 1;
        }
        if((trn = findStrandedTail(t.x, t.y)) != null && trn != tr) {
          /*wxPrintf(wxPorting.T("busy for train at %d,%dn"), t.x, t.y);*/
          return el + 1;
        }
        if(t.fgcolor == color_green || t.fgcolor == color_orange || t.fgcolor == color_red)
          return el + 1;
      }
      return 0;
    }

    public static void colorPartialPath0(Vector path, trkstat state, int start, int end) {
      grcolor c;
      int el, nel;
      int busy;
      Track trk;

      if(path == null)
        return;
      busy = 0;
      c = conf.fgcolor;		/* ST_FREE is the default */
      if(state == trkstat.ST_GREEN) {
        c = color_green;
        busy = 1;
      } else if(state == trkstat.ST_RED) {
        c = color_orange;
        busy = 1;
      } else if(state == trkstat.ST_WHITE) {
        c = color_white;
        busy = 1;
      }
      nel = end;
      for(el = start; el < nel; ++el) {
        trk = path.TrackAt(el);
        if(trk == null)
          continue;
        trk.SetColor(c);
        /* t.busy = busy; */
      }
    }

    public static void colorPartialPath(Vector path, trkstat state, int start) {
      colorPartialPath0(path, state, start, path._size);
    }

    public static void colorPathStart(Vector path, trkstat state, int end) {
      colorPartialPath0(path, state, 0, end);
    }

    public static void colorPath(Vector path, trkstat state) {
      colorPartialPath0(path, state, 0, path._size);
    }

    public static void onIconUpdateAll() {
      int i;

      for(i = onIconUpdateListeners.Length(); --i >= 0; ) {
        Track trk = onIconUpdateListeners.At(i);
        trk.OnIconUpdate();
      }
    }

    /*	new_train_status
     *
     *	This is a utility function to keep track of
     *	the number of trains in each different state.
     *	The data is just displayed to the user.
     */

    public static void new_train_status(Train t, trainstat status) {
      if(t.status == status)
        return;
      switch(t.status) {
        case trainstat.train_WAITING:
          --ntrains_waiting;
          break;
        case trainstat.train_STOPPED:
          --ntrains_stopped;
          break;
        case trainstat.train_READY:
          --ntrains_ready;
          break;
        case trainstat.train_ARRIVED:
          --ntrains_arrived;
          break;
        case trainstat.train_STARTING:
          --ntrains_starting;
          t.startDelay = 0;
          break;
        case trainstat.train_RUNNING:
          --ntrains_running;
          break;
      }
      t.status = (trainstat)status;
      switch(t.status) {
        case trainstat.train_WAITING:
          ++ntrains_waiting;
          break;
        case trainstat.train_STOPPED:
          ++ntrains_stopped;
          break;
        case trainstat.train_READY:
          ++ntrains_ready;
          break;
        case trainstat.train_ARRIVED:
          ++ntrains_arrived;
          t.arrived = true;
          break;
        case trainstat.train_STARTING:
          ++ntrains_starting;
          break;
        case trainstat.train_RUNNING:
          ++ntrains_running;
          break;
      }
    }

    public static void reset_schedule() {
      Train t;
      TrainStop ts;

      for(t = schedule; t != null; t = t.next) {
        if(t.tail != null) {
          if(t.tail.path != null) {
            colorPartialPath(t.tail.path, trkstat.ST_FREE, 0); //t.tail.pathpos);
            Vector_delete(t.tail.path);
            t.tail.path = null;
          }
          t.tail.position = null;
        }
        if(t.path != null) {
          colorPartialPath(t.path, trkstat.ST_FREE, 0); //t.pathpos);
          Vector_delete(t.path);
        }
        t.path = null;
      }
      ntrains_arrived = 0;
      ntrains_stopped = 0;
      ntrains_waiting = 0;
      ntrains_running = 0;
      ntrains_starting = 0;
      ntrains_ready = 0;
      for(t = schedule; t != null; t = t.next) {
        if(t.fleet != null)
          Vector_delete(t.fleet);
        t.fleet = null;
        t.status = trainstat.train_READY;
        ++ntrains_ready;
        t.direction = t.sdirection;
        t.exited = null;
        t.timeexited = 0;
        t.wrongdest = false;
        t.curspeed = 0;
        t.curmaxspeed = 0;
        t.trackpos = 0;
        t.timelate = 0;
        t.timedelay = 0;
        t.timered = 0;
        //	    t.pathpos = 0;
        t.position = null;
        t.timedep = 0;
        t.arrived = false;
        t.timeexited = 0;
        t.shunting = false;
        t.stopping = null;
        t.merging = null;
        t._gotDelay = 0;
        t._inDelay = 0;
        t.startDelay = 0;
        // first time after load myStartDelay will be 0 if not set for this train,
        // so we need to use the type-specific start delay.
        if(t.myStartDelay == 0 && startDelay[t.type] != 0)
          t.myStartDelay = startDelay[t.type];
        // same for acceleration rate
        if(t.accelRate == 0 && accelRate[t.type] != 0)
          t.accelRate = accelRate[t.type];
        t.flags &= ~(TFLG.TFLG_GOTDELAYATSTOP | TFLG.TFLG_SETLATEARRIVAL);
        if(t.entryDelay != null)
          t.entryDelay.nSeconds = 0;
        t.length = t.entryLength;
        if(t.length != 0 && t.tail == null) {
          // tail could have become 0 if train had exited
          // or it was assigned or it was split
          t.tail = new Train();
        }
        for(ts = t.stops; ts != null; ts = ts.next) {
          ts.late = 0;
          ts.delay = 0;
          ts.stopped = 0;
          if(ts.depDelay != null)
            ts.depDelay.nSeconds = 0;
        }
      }
      Array.Clear(late_data, 0, late_data.Length);
    }

    public static bool sameStation(String s1, String s2) {
      while(string.IsNullOrEmpty(s1) == false && s1[0] != '@' && s1[0] == s2[0]) {
        s1 = s1.Substring(1);
        s2 = s2.Substring(1);
      }
      if(string.IsNullOrEmpty(s1) || s1[0] == '@')
        if(string.IsNullOrEmpty(s2) || s2[0] == '@')
          return true;
      return false;
    }

    /*	FindNextTrack
     *
     *	Find the next track in the specified direction.
     *	This is used when a train enters the layout
     *	or when we are crossing a signal, thus starting
     *	to create a new path.
     *	This is necessary because signals can be attached
     *	to diagonal or vertical tracks.
     */

    public static Track findNextTrack1(trkdir direction, int x, int y, out trkdir ndir) {
      Track t;
      Track t1;

      ndir = direction;
      if((t = findTrack(x, y)) == null && (t = findSwitch(x, y)) == null)
        return null;		/* should be impossible */
      if(direction == trkdir.E_W || direction == trkdir.N_S) {/* westbound */
        if(t.type == trktype.TRACK)
          t1 = track_walkwest(t, ndir);
        else
          t1 = swtch_walkwest(t, ndir);
      } else {
        if(t.type == trktype.TRACK)
          t1 = track_walkeast(t, ndir);
        else
          t1 = swtch_walkeast(t, ndir);
      }
      if((t = findTrack(t1.x, t1.y)) != null)
        return t;
      return findSwitch(t1.x, t1.y);
    }

    public static Track findNextTrack(trkdir direction, int x, int y) {
      trkdir ndir;

      return findNextTrack1(direction, x, y, out ndir);
    }

    /*	FindEntryTrack
     *
     *	Find the entry point of a train and
     *	the train's initial direction.
     *	By convention, if the entry point string
     *	is to the left of the track, the direction
     *	will be eastbound. Similarly if the string
     *	is above a vertical track, the direction will
     *	be southbound.
     */

    public static Track findEntryTrack(Train tr, String entrance) {
      Track t, st;
      int x, y;

      st = findStation(entrance);
      if(st != null)
        return null;
      if(st.elinkx != 0 && st.elinky != 0) {
        tr.direction = trkdir.W_E;
        x = st.elinkx;
        y = st.elinky;
      } else if(st.wlinkx != 0 && st.wlinky != 0) {
        tr.direction = trkdir.E_W;
        x = st.wlinkx;
        y = st.wlinky;
      } else
        return null;
      if((t = findTrack(x, y)) != null) {
        if(t.direction == trkdir.TRK_N_S)
          tr.direction = st.y < t.y ? trkdir.N_S : trkdir.S_N;
        return t;
      }
      t = findSwitch(x, y);
      if(t.direction >= (trkdir)12 && t.direction <= (trkdir)15)
        tr.direction = st.y < t.y ? trkdir.N_S : trkdir.S_N;
      return t;
    }

    /*	FindStopPoint
     *
     *	Look ahead in the path to see if we have to stop
     *	at any station. The distance from the station (or
     *	from the end of the path) is recorded so that we
     *	can start decellerating in time.
     */

    public static void findStopPoint(Train t) {
      Track trk;
      Signal sig;
      TrainStop stp;
      int i;
      trkdir dir;
      long l1;
      int nspeed;
      int overlength;

      t.stoppoint = null;
      if(t.path == null)
        return;
      trk = t.path.TrackAt(t.path._size - 1);
      dir = (trkdir)t.path.FlagAt(t.path._size - 1);
      if((trk = findNextTrack(dir, trk.x, trk.y)) != null) {
        sig = (dir == trkdir.W_E || dir == trkdir.S_N) ? trk.esignal : trk.wsignal;
        if(sig != null) {
          t.stoppoint = (Track)sig;	// TODO: this looks like a hack!
          t.disttostop = t.path._pathlen;
          //		t.pathtravelled = 0;
        }
      }
      nspeed = t.curmaxspeed;
      l1 = 0; // t.pathtravelled;
      for(i = 0 /*t.pathpos*/; i < t.path._size; ++i) {
        if((trk = t.path.TrackAt(i)) == null)
          continue;
        if(!trk.isstation) {
          l1 += trk.length;
          continue;
        }
        if(i == 0 /*t.pathpos*/) {	/* if we're already at station */
          l1 += trk.length;
          continue;		/* ignore it */
        }
        if((t.flags & TFLG.TFLG_STRANDED) == 0 && !t.shunting) {
          if(!sameStation(t.exit, trk.station)) {
            stp = findStop(t, trk);
            if(stp == null || stp.minstop == 0) {
              l1 += trk.length;	/* ignore this station */
              continue;
            }
          }
        }

        /* Below is only when stoppoint is at a station */

        t.stoppoint = trk;
        t.disttostop = l1;
        if(t.length == 0) {		/* pre 1.17 code */
          t.disttostop += trk.length / 2;
          break;
        }
        /* 1.18 code */
        if(t.length <= trk.length) {
          t.disttostop += (trk.length / 2) + (t.length / 2);
          return;
        }
        /* proceed until end of path, or until half of the
         * train's length has travelled past the station.
         */

        overlength = t.length / 2 - trk.length / 2;
        t.disttostop += trk.length;
        while(++i < t.path._size) {
          if((trk = t.path.TrackAt(i)) == null)
            break;
          if(String.IsNullOrEmpty(trk.station) == false)
            break;
          if(overlength - trk.length < 0) {
            t.disttostop += overlength;
            t.stoppoint = trk;
            break;
          }
          overlength -= trk.length;
          t.disttostop += trk.length;
        }
        break;
      }
    }

    /*	FindSlowPoint
     *
     *	Look ahead in the path to see if we have to slow down
     *	because of a speed limit. The distance from the limit
     *	is recorded so that we can start decellerating in time.
     */

    public static void findSlowPoint(Train t) {
      //Track trk;
      //int i;
      //long l2;
      //int speed, prev_speed, min_speed;

      //t.slowpoint = null;
      //t.disttoslow = 0;
      //prev_speed = t.curmaxspeed;
      //l2 = 0; // t.pathtravelled;
      //for(i = 0 /*t.pathpos*/; i < t.path._size; ++i) {
      //  if((trk = t.path.TrackAt(i)) == null)
      //    continue;
      //  if(trk.type == trktype.SWITCH && !trk.switched)
      //    continue;

      //  speed = trk.speed[t.type];
      //  if(speed == 0)
      //    speed = trk.speed[0];
      //  if(speed != 0 && speed < prev_speed) {
      //    /* This is a track that is slower than
      //       previous track, i.e. a slowpoint. */
      //    /* However, if this track is short and next track is slower,
      //       maybe one of the next tracks is the true slowpoint.*/
      //    /* For the first found slowpoint set tentatively. For next
      //       found slow point, set only if it requires a slower speed */
      //    if(t.slowpoint == null) {
      //      t.slowpoint = trk;
      //      t.disttoslow = l2;
      //      min_speed = speed;
      //    } else if(max_approach_speed(t, l2 - t.disttoslow, speed) < min_speed) {
      //      /* Found a new candidate */
      //      t.slowpoint = trk;
      //      t.disttoslow = l2;
      //      min_speed = speed;
      //    }
      //  }
      //  l2 += trk.length;
      //  if(speed != 0)
      //    prev_speed = speed;
      //}
    }

    /*	Signal_unlock
     *
     *	Put a signal to green if the following
     *	path is clear.
     */

    public static void signal_unlock(Signal sig) {
      Vector path;

      if(sig.controls == null)
        return;
      path = findPath(sig.controls, sig.direction);
      if(path == null)
        return;
      if(pathIsBusy(null, path, sig.direction) == 0) {
        ((Signal)sig).OnUnlock();
        //	    sig.status = ST_GREEN;
        change_coord(sig.x, sig.y);
        colorPath(path, trkstat.ST_GREEN);
      }
      Vector_delete(path);
    }

    /*	leave_track
     *
     *	The train is about to move away from the
     *	current cell.
     *	Update the cells that are affected by this
     *	train.
     *	When a train has an icon, we need to know
     *	how many cells the icon covers so that they
     *	are marked to be redrawn at the next refresh.
     */

    public static void leave_track(Track position, trkdir direction, Train trn, bool delayOnExit) {
      //wx.Image map;
      //int idx;
      //Coord size;
      //Coord pos;

      //if(position == null)	// train's head has exited the layout
      //  return;
      //pos.Set(position.x, position.y);
      //if(draw_train_names) {
      //  get_text_size(trn.name, size);
      //  size.y = ((size.y + Configuration.VGRID - 1) / Configuration.VGRID);// * Configuration.VGRID; // round up to next cell
      //  pos.y -= 1; //(size.y / 2) / (VGRID / 2) + 1; // text is centered, so we need to clear the cell above
      //  size.y += 1;
      //  size.x = ((size.x + Configuration.HGRID - 1) / Configuration.HGRID);// * Configuration.HGRID; // round up to next cell
      //  pos.x -= 2;         // text is left-aligned, so we need to clear one before and one after
      //  size.x += 4;
      //} else {
      //  idx = direction == trkdir.W_E ? trn.epix : trn.wpix;
      //  if(pixmaps != null && idx != -1)
      //    map = pixmaps[idx].pixels;
      //  else
      //    map = direction == trkdir.W_E ? e_train_pmap[trn.type] : w_train_pmap[trn.type];
      //  get_pixmap_size(map, size);
      //  size.x = size.x / Configuration.HGRID + 1;
      //  size.y = size.y / Configuration.VGRID + 1;
      //}
      //if(!delayOnExit)
      //  position.OnExit(trn);
      //change_coord(pos.x, pos.y, size.x, size.y);
    }

    public static void leave_track(Train trn) {
      leave_track(trn.position, trn.direction, trn, trn.tail != null ? true : false);
    }

    public static void add_update_schedule(Train trn) {
      trn.newsched = 1;
    }


    public static void train_arrived(Train trn) {
      //int minlate;
      //TrainStop ts;
      //string buff;
      //String p;
      //int arrtime;

      //new_train_status(trn, trainstat.train_ARRIVED);/* becomes available for assign cmd */
      //trn.curspeed = 0;
      //arrtime = trn.timeout;
      //if(arrtime < trn.timein)
      //  arrtime += 24 * 60 * 60;
      //minlate = (current_time - arrtime) / 60;
      //if((trn.flags & TFLG.TFLG_SETLATEARRIVAL) != 0)	/* we stopped here before! */
      //  minlate = 0;
      //else
      //  trn.timeexited = current_time;
      //trn.flags |= TFLG.TFLG_SETLATEARRIVAL;
      //trn.arrived = true;

      //if(minlate > 0) {
      //  trn.timelate += minlate;
      //  total_late += minlate;
      //  if(hard_counters != 0 || (trn.flags & TFLG.TFLG_ENTEREDLATE) == 0)
      //    ++perf_tot.late_trains;
      //} else for(ts = trn.stops; ts != null; ts = ts.next) {
      //    if(ts.late != null && (hard_counters != 0 || (trn.flags & TFLG.TFLG_ENTEREDLATE) == 0)) {
      //      ++perf_tot.late_trains;
      //      break;
      //    }
      //  }
      //// get entry delay
      //for(ts = trn.stops; ts != null; ts = ts.next) {
      //  buff = String.Copy(ts.station);
      //  if(String.IsNullOrEmpty((p = wxStrchr(buff, '@'))) == false)
      //    *p = 0;
      //  if(findStation(ts.station) != null && ts.stopped == 0)
      //    ++perf_tot.nmissed_stops;
      //}

      //Track trk = trn.position;
      //if(trk != null) {
      //  if(String.IsNullOrEmpty(trk.station) && trn.tail != null && trn.tail.path != null) {
      //    trk = Globals.path_find_station(trn.tail.path, trn.position);
      //  }
      //}
      //if(trk != null && String.IsNullOrEmpty(trk.station) == false) {
      //  trk.OnArrived(trn);
      //}
    }

    public static void train_derailed(Train trn) {
      trn.curspeed = 0;
      new_train_status(trn, trainstat.train_DERAILED);
      //change_coord(t.position.x, t.position.y);
      leave_track(trn);
      trn.position = null;
      // TODO: if train has a tail, remove it, too!
      add_update_schedule(trn);
    }


    public static void check_platform(String s1, String s2) {
      while(s1[0] == s2[0] && s1.Length > 0) {
        s1 = s1.Substring(1);
        s2 = s2.Substring(1);
      }
      if(String.IsNullOrEmpty(s1)) {
        if(String.IsNullOrEmpty(s2) || s2[0] == '@')
          return;
      } else if(String.IsNullOrEmpty(s2)) {
        if(s1[0] == '@')
          return;
      }
      ++perf_tot.wrong_platform;
    }

    public static int stopping_at_this_station(Train trn, Track st) {
      TrainStop stp;

      if(trn.shunting && (st.flags & TFLG.TFLG_DONTSTOPSHUNTERS) != 0)
        return 0;
      for(stp = trn.stops; stp != null; stp = stp.next)
        if(stp.minstop != 0 && sameStation(stp.station, st.station))
          return 1;
      if(sameStation(st.station, trn.exit))
        return 1;
      if(trn.shunting && trn.outof != st)
        return 1;
      return 0;
    }

    /*	Train_at_station
     *
     *	A train is at a station.
     *	We have to decide whether we have to stop
     *	at this station (because it's in our schedule
     *	or during shunting), and if so we have to
     *	compute the penalties for late arrivals,
     *	wrong platform and the estimated time of departure.
     */

    public static int train_at_station(Train trn, Track trk) {
      TrainStop stp, stp1;
      int minlate;
      int arrtime;

      if(string.IsNullOrEmpty(trk.station))
        return 0;
      for(stp = trn.stops; stp != null; stp = stp.next)
        if(sameStation(stp.station, trk.station))
          break;
      if(trn.shunting) {
        if(trn.outof == trk)	/* don't stop */
          return 0;
        if(trn.oldstatus == trainstat.train_WAITING || trn.oldstatus == trainstat.train_RUNNING)
          trn.oldstatus = trainstat.train_STOPPED;
        new_train_status(trn, trn.oldstatus);
        trn.stopping = null;
        trn.curspeed = 0;
        trn.shunting = false;
        trn.outof = null;
        if(stp != null)
          trn.timedep = stp.departure;
        else if(sameStation(trk.station, trn.entrance))
          trn.timedep = trn.timein;
        else if(sameStation(trk.station, trn.exit) || trn.arrived) {
          // in case we were shunted to our destination
          train_arrived(trn);
        }
        return 1;
      }
      trn.stopping = null;
      if(stp == null) {			/* we are not at a stop */
        if(assign_ok == 0 || !sameStation(trk.station, trn.exit))
          return 0;

        /* but we arrived at our destination! */

        check_platform(trk.station, trn.exit);
        train_arrived(trn);
        trn.OnArrived();
      } else {
        check_platform(trk.station, stp.station);
        arrtime = stp.arrival;
        if(arrtime < trn.timein)
          arrtime += 24 * 60 * 60;
        minlate = (current_time - arrtime) / 60;
        if(stp.minstop == 0) {		/* does not stop */
          stp.delay = minlate;
          return 0;
        }
        trn.OnStopped();
        new_train_status(trn, trainstat.train_STOPPED);
        if(stp.stopped == 0)		/* we stopped here before! */
          minlate = 0;
        stp.delay = minlate;
        stp.stopped = 1;
        for(stp1 = stp.next; stp1 != null; stp1 = stp1.next)/* sometimes we have */
          if(sameStation(stp1.station, stp.station))/* multiple entries for the */
            stp1.stopped = 1;	/* same station. This should be fixed in loadsave! */
        if(minlate > 0) {
          stp.late = 1;
          trn.timelate += minlate;
          total_late += minlate;
        }
      }
      trn.curspeed = 0;
      if(stp == null)
        return 1;
      if(stp.departure < stp.arrival)   // arrived in the evening, departing in the morning
        stp.departure += 24 * 60 * 60;
      trn.timedep = current_time + stp.minstop;
      if(trn.timedep < stp.departure)
        trn.timedep = stp.departure;
      Track trk1 = trn.position;
      if(trk1 != null) {
        if(string.IsNullOrEmpty(trk1.station) && trn.tail != null && trn.tail.path != null) {
          trk1 = Globals.path_find_station(trn.tail.path, trn.position);
        }
      }
      if(trk1 != null && String.IsNullOrEmpty(trk1.station) == false) {
        trk1.OnStopped(trn);
      }
      return 1;
    }

    /*	Do_triggers
     *
     *	Handle all triggers associated with the
     *	current train position.
     */

    public static void do_triggers(Train t) {
      //Track trk;
      //int prob;
      //int i;
      //int rnd = rand() % 100;
      //string buff;
      //bool found;

      //if(t == null || t.position == null)
      //  return;
      //for(trk = Globals.layout; trk != null; trk = trk.next) {
      //  if(trk.type != trktype.TRIGGER || String.IsNullOrEmpty(trk.station))
      //    continue;
      //  if(t.direction != trk.direction)
      //    continue;
      //  if(trk.wlinkx != t.position.x || trk.wlinky != t.position.y)
      //    continue;

      //  trk.OnCrossed(t);

      //  /* old, clunky code (pre 3.6) below */

      //  /*
      //   *	check to see if this trigger applies to a list of
      //   *	specific trains.
      //   *	The list starts with "{" and each train name is
      //   *	separated from the next by a ',' character.
      //   *	The list is terminated by "}".
      //   */

      //  for(i = 0; i <= trk.station.Length; ++i)
      //    if(trk.station[i] == '{')
      //      break;
      //  if(trk.station[i] == '{') {
      //    found = false;
      //    do {
      //      while(++i <= trk.station.Length && trk.station[i] == ' ') ;
      //      for(prob = 0; i <= trk.station.Length &&
      //      trk.station[i] != '}' && trk.station[i] != ',';
      //          buff.ReplaceAt(prob++, trk.station[i++])) ;
      //      buff = buff.Substring(0, prob);
      //      if(wxStrcmp(t.name, buff) == 0) {
      //        found = true;
      //        break;
      //      }
      //    } while(i <= trk.station.Length && trk.station[i] != '}');
      //    if(!found)			/* this train is not in the list */
      //      continue;
      //  }

      //  prob = trk.speed[t.type];
      //  if(prob == 0)
      //    prob = 100;

      //  /*
      //   *	rnd < prob means:
      //   *	    prob = 1, rnd almost never <
      //   *	    prob = 99, rnd almost always <
      //   */
      //  if(rnd < prob) {
      //    for(prob = rnd = 0; prob <= trk.station.Length; ++prob) {
      //      switch(trk.station[prob]) {
      //        case '{':
      //          /* skip conditional train sequence */
      //          while(prob <= trk.station.Length && trk.station[prob] != '}')
      //            ++prob;
      //          if(trk.station[prob] != 0) ++prob;
      //          continue;

      //        case '@':
      //          buff + rnd = String.Copy(t.name);
      //          rnd += Globals.wxStrlen(t.name);
      //          continue;

      //        case ';':
      //          buff = buff.Substring(0, rnd);
      //          trainsim_cmd(buff);
      //          while(trk.station[++prob] == ' ') ;
      //          --prob;
      //          rnd = 0;
      //          continue;
      //      }
      //      buff.ReplaceAt(rnd++, trk.station[prob]);
      //    }
      //    buff = buff.Substring(0, rnd);
      //    if(rnd != 0) {
      //      if(Globals.wxStrncmp(buff, wxPorting.T("script"), 6) == 0) {
      //        for(rnd = 6; buff[rnd] == ' ' || buff[rnd] == 't'; ++rnd) ;
      //        if(rnd == 0)
      //          continue;
      //        trk.RunScript(buff + rnd, t);
      //      } else
      //        trainsim_cmd(buff);
      //    }
      //  }
      //}
    }

    /*	max_approach_speed()
     *
     *	This computes the maximum speed allowed based on the
     *	distance of the train from the next slow or stop point.
     *	If the current train speed is greater than the computed
     *	speed, the train will be slowed down.
     *	If the current train speed is lower, it will be sped up.
     */

    public static int max_approach_speed(Train trn, double distance, int targetspeed) {
      /* It would be neat to have the ability to define the trains retardation, */
      /* but then we have to mess with a lot of other stuff, for instance
       changing the definition of the Schdeule keywords and change to speed
       as cm/s or something like that. Next project! */

      /* v*v - v0*v0 = 2*a*s => v = sqrt(2*a*s + v0*v0) */

      /* distance in meters, result in m/s, but we need it in km/h */
      /* deceleration is 0.6 m/s2, for now. */
      double s, v0;
      int v;

      s = distance;
      v0 = ((double)targetspeed) / 3.6;

      s = s * 2.0 * 0.6 + v0 * v0;
      if(s < 0)		/* should be impossible, but... */
        return (int)trn.curspeed;
      //v = (int)(sqrt(s) * 3.6);
      s = Math.Sqrt(s);
      s = s * 3.6;
      v = (int)s;
      return v;
    }

    /*	Speed_limit
     *
     *	Compute the maximum speed for a train.
     *	The speed is the lowest of the maximum speed
     *	for the train, the last speed limit encountered
     *	by the train, or a new speed limit found on the
     *	current track.
     */

    public static void speed_limit(Train trn, Track trk) {
      int speed;

      if(trk.type == trktype.SWITCH && !trk.switched)
        return;
      speed = trk.speed[trn.type];
      if(speed == 0)
        speed = trk.speed[0];
      if(trn.shunting && speed > 30)
        speed = 30;
      if(speed > 0) {
        trn.curmaxspeed = (short)speed;
        if(trn.maxspeed != 0 && trn.curmaxspeed > trn.maxspeed)
          trn.curmaxspeed = trn.maxspeed;
        if(trn.shunting)
          trn.curmaxspeed = 30;
        trn.speedlimit = trn.curmaxspeed;
        if(trn.curmaxspeed != 0 && trn.curspeed > trn.curmaxspeed)
          trn.curspeed = trn.curmaxspeed;
      }
    }

    public static bool stopping_at_signal(Signal s) {
      if(s.type != trktype.TSIGNAL)
        return false;
      if(s.IsClear())
        return false;
      return true;
    }


    public static bool get_limit_from_signal(Signal s, out int maxspeed) {
      maxspeed = 0;
      if(s.type != trktype.TSIGNAL)
        return false;
      return s.GetSpeedLimit(out maxspeed);
    }

    /*	Compute_new_speed
     *
     *	Change the speed of the train based on:
     *	- current speed
     *	- current speed limit
     *	- distance from next stop
     *	- distance from next (lower) speed limit
     */

    public static void compute_new_speed(Train t) {
      int maxspeed = 10000, maxslowspeed, slowspeed;
      double speedincr = 1;

      if(t.accelRate > 0)
        speedincr = t.accelRate;

      /* This computes the speed by using max_approach_speed() to
         calculate the braking curve. Consider first the stopping distance
         and then distance to slowpoint */

      if(t.stoppoint != null) {
        // TODO: stoppoint may be beyond a station if train.length > 0
        if(t.stoppoint.type == trktype.TRACK || stopping_at_signal((Signal)t.stoppoint)) {
          /* Check if we need to brake. Set target speed to 5 km/h, so we
             don't stop too early */
          maxspeed = max_approach_speed(t,
                      t.disttostop, // - t.pathtravelled,
                      5);
        } else if(get_limit_from_signal((Signal)t.stoppoint, out maxspeed))
          maxspeed = max_approach_speed(t,
                      t.disttostop, // - t.pathtravelled,
                      maxspeed);
        else
          goto do_slow;
        if(t.curmaxspeed < maxspeed)
          maxspeed = t.curmaxspeed;
        if(t.curspeed > maxspeed) {
          /* Instead of decelerating, we adjust immediately to
       target speed. Our train _must not_ speed */
          t.curspeed = maxspeed;
        } else if(t.curspeed < maxspeed) {
          /* Accelerate, this shouldn't be a fixed number,
       but OK for now. */
          t.curspeed += speedincr;
          speedincr = 0;
        }
      }

     /* Is slowspeed lower? */

    do_slow:
      if(t.slowpoint != null) {
        if((slowspeed = t.slowpoint.speed[t.type]) == 0)
          slowspeed = t.slowpoint.speed[0];
        /* Check if we need to brake. */
        maxslowspeed = max_approach_speed(t, t.disttoslow, // - t.pathtravelled,
              slowspeed);
        if(maxspeed == 10000)
          maxspeed = maxslowspeed;
        else {
          if(maxslowspeed < maxspeed)
            maxspeed = maxslowspeed;
        }
        if(t.curmaxspeed < maxspeed)
          maxspeed = t.curmaxspeed;
        if(t.curspeed > maxspeed) {
          /* Instead of decelerating, we adjust immediately to
       target speed. Our train _must not_ speed */
          t.curspeed = maxspeed;
        } else if(t.curspeed < maxspeed) {
          t.curspeed += speedincr;
        }
        if(t.disttoslow /*- t.pathtravelled*/ < 1) {
          if(t.position == t.slowpoint)
            t.slowpoint = null;
          /* This shouldn't really happen... */
          t.curspeed = slowspeed;
        }
      } else if(t.curmaxspeed != 0 && t.curspeed < t.curmaxspeed) {
        t.curspeed += speedincr;
      }
    }

    /*	Tail_advance
     *
     *	Compute the new position of the train's tail.
     *	This is a new algorithm introduced in 1.18k.
     *	It simply locates the head of the train in the
     *	tail's path, and colors all the tracks starting from
     *	the head's position until the length of the train
     *	is all covered. Then color in black all the remaining
     *	tracks and remove them from the tail's path.
     */

    public static void tail_advance(Train t) {
      //Train tail;
      //int i;
      //double len;
      //Track trk;

      //if((tail = t.tail) == null || t.tail.tailentry != null || tail.path == null)
      //  return;
      ////Vector_dump(t, wxPorting.T("tail_advance"));
      //if(t.position != null) {
      //  for(i = 0; i < tail.path._size; ++i) {
      //    trk = tail.path.TrackAt(i);
      //    if(trk == t.position)
      //      break;
      //  }
      //  // tail is on the same as head -- do nothing
      //  if(i == tail.path._size)
      //    return;
      //}
      //if(tail.position != null) {
      //  tail.position.SetColor(conf.fgcolor);
      //  leave_track(tail.position, t.direction, t, true);
      //  //	    tail.position.OnExit(t);
      //  tail.position = null;
      //}
      //if(t.position != null) {
      //  len = t.length;
      //  len -= t.trackpos;	/* portion already travelled by train's head */
      //} else {		/* when exiting, */
      //  len = tail.trackpos;/* this is the length still inside the layout */
      //  i = tail.path._size;
      //}
      //if(len > 0) {
      //  --i;
      //  while(i >= 0) {
      //    changed = 1;
      //    trk = tail.path.TrackAt(i);
      //    if(trk.type == trktype.TRACK || trk.type == trktype.SWITCH) {
      //      trk.SetColor(color_orange);
      //      tail.position = trk;
      //    }
      //    --i;
      //    if(len < trk.length)
      //      break;
      //    len -= trk.length;
      //  }
      //} else
      //  --i;
      //while(i >= 0) {
      //  trk = tail.path.TrackAt(i);
      //  if(trk.fgcolor != color_orange) {
      //    trk.OnExit(t);
      //    tail.path.DeleteAt(i);
      //    --i;
      //    break;
      //  }
      //  trk.SetColor(conf.fgcolor);
      //  trk.OnExit(t);
      //  tail.path.DeleteAt(i);
      //  --i;
      //  changed = 1;
      //}
    }

    public static void train_is_exiting(Train t, Track trk) {
      string buff;

      /*
       // this should be useless, since trk can only be a text element
       // which is never colored anything other than black
       if(trk) {
           trk.SetColor(conf.fgcolor);
           leave_track(t);
           //change_coord(trk.x, trk.y);
       }
      */
      t.position = null;

      //  Check that we are exiting by the
      //  same station as specified in our schedule

      buff = String.Copy(t.exit);
      if(!t.arrived && trk != null && String.IsNullOrEmpty(trk.station) == false && !sameStation(trk.station, buff)) {
        ++perf_tot.wrong_dest;
        t.wrongdest = true;
        t.exited = String.Copy(trk.station);
      }

      //  If train has a tail, see if the tail
      //  is still traveling in the layout

      if(t.tail == null) {
        if(t.tail.path != null &&
          /*t.tail.pathpos < */ t.tail.path._size > 0) {
          if(trk != null)	/* length still inside the layout */
            t.tail.trackpos = t.length - t.trackpos;
          return;
        }

        // tail has traveled all tracks, remove it from the layout
        t.tail.position = null;
        if(t.tail.path != null)
          Vector_delete(t.tail.path);
        t.tail.path = null;
        Globals.free(t.tail);
        t.tail = null;
      }
      train_arrived(t);
      bstreet_trainexited(t);
      //	if(trk)
      //	    change_coord(trk.x, trk.y);
      t.curspeed = 0;
      changed = 1;
      add_update_schedule(t);
      t.OnExit();
    }



    public static int fetch_path(Train t) {
      throw new NotImplementedException();

    //  string buff;
    //  int i;
    //  trkdir ndir;
    //  Track trk;
    //  Signal sig;

    //  if((trk = t.position) == null || (trk.type == trktype.TEXT && !trk.isstation)) {
    //    train_is_exiting(t, trk);
    //    return 0;
    //  }

    //  //  Find the start of the next block

    //  if((trk = findNextTrack1(t.direction, t.position.x, t.position.y, out ndir)) == null) {
    //    train_derailed(t);
    //    return 0;
    //  }
    //  if(trk.busy) {			/* THIS CODE APPEARS TO BE DEAD */
    //    t.curspeed = 0;
    //    if(t.status != trainstat.train_WAITING) {
    //      buff = String.Format(wxPorting.L("Train %s waiting at %d,%d!"),
    //          t.name, trk.x, trk.y);
    //      do_alert(buff);
    //      ++perf_tot.waiting_train;
    //    }
    //    sig = (Signal)((t.direction == trkdir.W_E || t.direction == trkdir.S_N) ?
    //          trk.esignal : trk.wsignal);
    //    t.OnWaiting(sig);
    //    new_train_status(t, trainstat.train_WAITING);
    //    t.flags |= TFLG.TFLG_WAITED;
    //    add_update_schedule(t);
    //    return 0;
    //  }

    //  // Check if we can cross the signal that protects the next block

    //  sig = (Signal)((t.direction == trkdir.W_E || t.direction == trkdir.S_N) ?
    //        trk.esignal : trk.wsignal);
    //  if(sig == null) {
    //    train_derailed(t);
    //    return 0;
    //  }

    //  if(powerSpecified && sig.IsClear() || (t.shunting && trk.fgcolor == color_white)) {
    //    Vector newPath = findPath0(null, trk, t.direction = ndir);
    //    bool canTravelOnNewPath = t.CanTravelOn(newPath);
    //    Vector_delete(newPath);
    //    if(!canTravelOnNewPath) {
    //      if(t.status != trainstat.train_WAITING) {
    //        String alertMsg;

    //        if(String.IsNullOrEmpty(sig.station) == false)
    //          alertMsg = String.Format(wxPorting.L("Train %s stopped at %s (%d,%d) due to power loss."), t.name, sig.station, trk.x, trk.y);
    //        else
    //          alertMsg = String.Format(wxPorting.L("Train %s stopped at (%d,%d) due to power loss."), t.name, trk.x, trk.y);
    //        do_alert(alertMsg);
    //      }
    //      goto stop_train;
    //    }
    //  }

    //  // Check if we are shunting and entering
    //  // a block that is already occupied

    //  if(trk.fgcolor == color_white && t.shunting) {
    //    int x;
    //    Track wtrk;

    //    // if so, create a path limited to where the next train is
    //    t.path = findPath0(t.path, trk, t.direction = ndir);
    //    for(x = 0; x < t.path._size; ++x) {
    //      if((wtrk = t.path.TrackAt(x)) == null)
    //        continue;
    //      if(wtrk.fgcolor == color_white)
    //        continue;
    //      if((t.merging = findTrain(wtrk.x, wtrk.y)) == null) {
    //        if((t.merging = findTail(wtrk.x, wtrk.y)) == null)
    //          if((t.merging = findStranded(wtrk.x, wtrk.y)) == null)
    //            t.merging = findStrandedTail(wtrk.x, wtrk.y);
    //      }
    //      if(t.merging != null && (t.merging.status == trainstat.train_STOPPED ||
    //        t.merging.status == trainstat.train_WAITING ||
    //        t.merging.status == trainstat.train_ARRIVED)) {
    //        t.path._size = x;  // limit to where next train is
    //        t.flags |= TFLG.TFLG_MERGING;
    //        t.merging.flags |= TFLG.TFLG_WAITINGMERGE;
    //      } else {// train is not there anymore or it's moving.
    //        t.merging = null;
    //        wtrk = t.path.TrackAt(0);
    //        Signal sig1 = (Signal)wtrk.esignal;
    //        if(sig1 == null)
    //          sig1 = (Signal)wtrk.wsignal;
    //        if(sig1 != null)
    //          sig1.OnUnclear();
    //        colorPath(t.path, trkstat.ST_FREE);
    //        Vector_delete(t.path);
    //        t.path = null;
    //        goto stop_train;
    //      }
    //      break;
    //    }
    //    sig.OnCross();	// turn signal to red
    //    goto proceed;
    //  }

    //  // we are not shunting, but the signal is opened for shunting
    //  // we force the train to stop and the user to send it forward
    //  // with an explicit shunt command (otherwise a reload will
    //  // incorrectly fetch a path beyond the signal and color it green)
    //  if(trk.fgcolor == color_white || !sig.IsClear()) {
    //  stop_train:
    //    t.curspeed = 0;
    //    if(t.status != trainstat.train_WAITING) {
    //      buff = String.Format(wxPorting.L("Train %s waiting at"), t.name);
    //      if(String.IsNullOrEmpty(sig.station) == false) {
    //        wxStrcat(buff, wxPorting.T(" "));
    //        wxStrcat(buff, sig.station);
    //        wxStrcat(buff, wxPorting.T(" "));
    //      }
    //      buff + Globals.wxStrlen(buff) = String.Format(wxPorting.T("(%d,%d)"), trk.x, trk.y);
    //      do_alert(buff);
    //      if(!sig.nopenalty)
    //        ++perf_tot.waiting_train;
    //    }
    //    t.OnWaiting(sig);
    //    new_train_status(t, trainstat.train_WAITING);
    //    if(t.trackpos > t.position.length)
    //      t.trackpos = t.position.length;
    //    add_update_schedule(t);
    //    return 0;
    //  }
    //  if(get_limit_from_signal(sig, out i)) {
    //    if(t.maxspeed != 0 && i > t.maxspeed)
    //      i = t.maxspeed;
    //    t.curmaxspeed = (short)i;
    //  }
    //  if(t.status == trainstat.train_WAITING) {
    //    if(t.myStartDelay != 0) {
    //      new_train_status(t, trainstat.train_STARTING);
    //      t.startDelay = t.myStartDelay;
    //      return 0;
    //    }
    //  }
    //  sig.OnCross();
    //  //	sig.status = ST_RED;
    //  change_coord(sig.x, sig.y);
    //  leave_track(t);
    //  t.path = findPath0(t.path, trk, t.direction = ndir);
    //  if(t.path == null)
    //    return -1;
    //proceed:
    //  if(t.tail != null) {
    //    // make tail's path partially overlap the head's path
    //    t.tail.path = appendPath(t.tail.path, t.path);
    //  }
    //  //	t.pathpos = 0;
    //  t.direction = (trkdir)t.path.FlagAt(0); //t.pathpos);
    //  t.position = t.path.TrackAt(0); //t.pathpos);
    //  t.position.SetColor(t.tail != null ? color_orange : conf.fgcolor);
    //  findStopPoint(t);
    //  findSlowPoint(t);
    //  //	++t.pathpos;
    //  changed = 1;
    //  return 1;
    }

    public static void merge_train(Train trn) {
      Train t2;
      bool doDelete = false;
      int i;

      //Vector_dump(trn, trn.name);
      new_train_status(trn, trn.oldstatus);
      trn.shunting = false;
      trn.curspeed = 0;
      t2 = trn.merging;
      trn.position.fgcolor = conf.fgcolor;
      leave_track(trn);
      t2.flags &= ~TFLG.TFLG_WAITINGMERGE;
      trn.position = null;
      if((t2.flags & TFLG.TFLG_STRANDED) != 0) {
        trn.length += t2.length;
        if(t2.length != 0) {
          if(trn.direction != t2.direction) {
            reverse_train(t2);
          }
          //		Vector_dump(trn, "loco");
          //		Vector_dump(t2, "materiale");
          // incoming train always attaches to the tail of previous train.
          assign_train(trn, t2);
          //		Vector_dump(trn, "dopo assign");
          trn.merging = null;
          Train tail = trn.tail;
          // t2 is deleted here, so nothing else to do
          if(tail == null || tail.path == null) {
            if(trn.position == null || String.IsNullOrEmpty(trn.position.station) || trn.position == trn.outof)
              return;
            if(sameStation(trn.position.station, trn.exit) || trn.arrived) {
              // in case we were shunted to our destination
              train_arrived(trn);
            }
            return;
          }
          for(i = 0 /*tail.pathpos*/; i < tail.path._size; ++i) {
            Track trk = tail.path.TrackAt(i);
            if(String.IsNullOrEmpty(trk.station) && sameStation(trk.station, trn.exit) && trk != trn.outof) {
              train_arrived(trn);
            }
            if(trk == trn.position)
              break;
            trk.SetColor(color_orange);
          }
          return;
        }
        trn.position = t2.position;
        remove_from_stranded_list(t2);
        trn.path = findPath(trn.position, trn.direction);
        colorPartialPath(trn.path, trkstat.ST_GREEN, 1);
        //	    trn.pathpos = 0;
        findStopPoint(trn);
        findSlowPoint(trn);
        //	    trn.pathpos = 1;
        if(trn.position.isstation)
          train_at_station(trn, trn.position);
        trn.merging = null;
        Globals.delete(t2);
        repaint_all();  // TEMP - there should be a more efficient way
        return;
      }
      trn.merging = null;
      t2.length += trn.length;

      if(t2.status == trainstat.train_ARRIVED) {
        // we want to keep trn, and remove t2
        Vector_delete(trn.path);
        trn.path = t2.path;
        t2.path = null;
        if(t2.length != 0) {
          trn.length = t2.length;
          if(t2.tail != null) {
            if(trn.tail != null && trn.tail.path != null) {
              appendPath(trn.tail.path, t2.tail.path);
              Vector_delete(t2.tail.path);
              t2.tail.path = null;
            } else {
              trn.tail = t2.tail;
            }
            trn.ecarpix = t2.ecarpix;
            trn.wcarpix = t2.wcarpix;
          }
        }
        trn.position = t2.position;
        t2.position = null;
        t2.tail = null;
        return;
      }
      // else we want to keep t2 and remove trn
      if(trn.length != 0) {
        if(t2.tail == null)
          t2.tail = trn.tail;
        else {
          // the append is to trn instead of t2
          // so that the tail's path of the merging tain
          // will appear before the path of the stationary train
          appendPath(trn.tail.path, t2.tail.path);
          Vector_delete(t2.tail.path);
          t2.tail.path = trn.tail.path;
          t2.tail.position = trn.tail.position;
          trn.tail.path = null;
          //		Globals.free(t.tail);	    // double-check for other frees
        }
        trn.tail = null;
      }
    }

    /*	Run_train
     *
     *	This is the main function for train movement.
     *	It must compute the next position and the next
     *	speed of the train after one time click.
     */

    public static int run_train(Train t) {
      double travelled;
      double posit;
      Track trk;

      new_train_status(t, trainstat.train_RUNNING);
      if(t.shunting && t.curmaxspeed > 30)
        t.curmaxspeed = 30;
      travelled = t.curspeed / 3.6;	/* meters travelled in 1 sec. */
      trk = t.position;
      if(t.position == null) {		/* train is exiting the territory */
        if(t.tail == null)
          return 0;
        compute_new_speed(t);
        if(t.tail.tailentry != 0) {
          if((t.tail.tailentry += (int)travelled) >= 0) {
            /* tail enters the field */
            t.tail.trackpos = t.tail.tailentry;
            t.tail.tailentry = 0;
            //		    t.tail.pathpos = 0;
          }
        } else
          t.tail.trackpos -= travelled;
        tail_advance(t);
        if(t.tail.path == null) {
          string buff;

          buff = string.Format(wxPorting.T("Train '%s' has no tail path!n"), t.name);
          do_alert(buff);
          return -1;
        }
        if(t.tail.path._size != 0 /*&& t.tail.pathpos < t.tail.path._size*/)
          return 1;
        /* exited! */
        fetch_path(t);
        return 0;
      }
    agn:
      speed_limit(t, trk);

      trk.busy = false;
      trk.flags &= ~TFLG.TFLG_THROWN;
      if(trk.length == 0)
        trk.length = 1;
      if(trk.length < 2 && t.needfindstop) {
        findStopPoint(t);
        t.needfindstop = false;
      }
      posit = t.trackpos;
      if(posit < trk.length) {
        posit += travelled;
        run_points += time_mult * run_point_base + 1;

        compute_new_speed(t);	/* accelerate/decelerate train */
        if(t.stopping != null && /*t.pathtravelled +*/ travelled >= t.disttostop) {
          tail_advance(t);
          train_at_station(t, t.stopping);
          return 0;
        }

        t.pathtravelled += travelled;
        t.disttostop -= travelled;
        if(t.disttostop < 0) t.disttostop = 0;
        t.disttoslow -= travelled;
        if(t.disttoslow < 0) t.disttoslow = 0;
        if(posit < trk.length) {
          t.trackpos = posit;    /* we are still in the same track */
          if(t.length == 0 || t.tail == null)/* no length info for this train */
            return 1;
          if(t.tail.tailentry != null) {
            if((t.tail.tailentry += (int)travelled) < 0)
              return 1;	/* tail is still out of field */
            /* tail enters the field */
            t.tail.trackpos = t.tail.tailentry;
            t.tail.tailentry = 0;
            //		    t.tail.pathpos = 0;
          } else
            t.tail.trackpos += travelled;
          tail_advance(t);
          return 1;
        }
        t.trackpos = posit - trk.length;/* meters already travelled in next track */
        if(t.tail != null) {
          if(t.tail.tailentry != null) {
            if((t.tail.tailentry += (int)travelled) >= 0) {
              /* tail enters the field */
              t.tail.trackpos = t.tail.tailentry;
              t.tail.tailentry = 0;
              //			t.tail.pathpos = 0;
            }
          } else
            t.tail.trackpos += travelled;
          //tail_advance(t);
        }
        travelled = 0;
      }

      // train has traveled the full length
      // of the current track element.
      // Advance to the next track element in the path,
      // or get a new path.

      if(t.path == null || /*t.pathpos == */t.path._size == 1) {
        if(t.stopping != null) {		/* don't advance to another path if
     					 * we wanted to stop at a station.
     					 */
          train_at_station(t, t.stopping);
          return 0;
        }
        if(t.shunting && t.merging != null) {
          merge_train(t);
          return 0;
        }
        t.pathtravelled = t.trackpos;
        switch(fetch_path(t)) {
          case 0:
            if(t.tail != null)
              tail_advance(t);
            return 0;
          case -1:
            return -1;
        }
        travelled = t.trackpos;
        t.trackpos = 0;
        t.pathtravelled = 0;
        trk = t.position;
        goto agn;		/* no more tracks in this path, get new path */
      }

      /* advance to next track in this path */

      tail_advance(t);
      if(t.stopping != null) {
        if(/*t.pathtravelled >= */ t.disttostop < 1 || trk == t.stoppoint) {
          train_at_station(t, t.stopping);
          return 0;
        }
      }
      if(travelled != 0) {
        // we didn't update the position because we travelled
        // a number of meter higher than current track's length.
        // Adjust the stop and slow points here by the track's length
        // so that we don't "go long" on the expected stop point
        travelled -= trk.length;
        t.disttostop -= trk.length;
        t.disttoslow -= trk.length;
      }
      changed = 1;
      //change_coord(trk.x, trk.y);
      leave_track(t);
      if(t.tail != null && t.tail.position == null)
        t.tail.position = trk;
      t.path.DeleteAt(0);
      t.direction = (trkdir)t.path.FlagAt(0); //t.pathpos);
      t.position = trk = t.path.TrackAt(0); //t.pathpos++);
      trk.SetColor(t.tail != null ? color_orange : conf.fgcolor);
      do_triggers(t);
      trk.OnEnter(t);

      if(t.slowpoint != null && trk == t.slowpoint) {
        speed_limit(t, trk);    /* set maxcurspeed */
        findSlowPoint(t);
      }

      if(trk.isstation != null && /*train_at_station(t, trk)*/
          stopping_at_this_station(t, trk) != 0) {

        if(t.length == 0 || t.status == trainstat.train_STOPPED) {
          // train may have become STOPPED as a result of a reverse
          // command executed by a trigger. If so, we should compute
          // the new time of departure, because reverse_train() does
          // not do that.
          if(train_at_station(t, trk) == 0)
            goto agn;
          return 1;
        }

        /* 1.18 code: decide where to stop so that
         *		as much of the train as possible
         *		is at the station.
         */

        t.stopping = trk;	/* we're stopping at this station */
        return 1;
      }
      if(t.status != trainstat.train_RUNNING)	// maybe we stopped due to a trigger
        return 1;
      if(t.trackpos >= trk.length) {
        travelled = t.trackpos;
        t.trackpos = 0;
        t.disttostop += travelled;
        t.disttoslow += travelled;
      }
      goto agn;
    }

    public static double HOUR(double h) { return ((h) * 60 * 60); }

    public static void crossing_midnight() {
      Train t;
      TrainStop ts;

      for(t = schedule; t != null; t = t.next) {
        if(t.timein < HOUR(12))
          t.timein += (int)HOUR(24);
        if(t.timeout < HOUR(12))
          t.timeout += (int)HOUR(24);
        for(ts = t.stops; ts != null; ts = ts.next) {
          if(ts.arrival < HOUR(12))
            ts.arrival += (int)HOUR(24);
          if(ts.departure < HOUR(12))
            ts.departure += (int)HOUR(24);
        }
      }
    }

    public static int selectDelay(Train t, TDDelay del, out bool changed) {
      changed = false;

      if(del == null || !random_delays)
        return 0;
      if(del.nDelays == 0)
        return 0;
      if((t.flags & TFLG.TFLG_GOTDELAYATSTOP) != 0)
        return del.nSeconds;
      if(del.nSeconds == 0) {
        int r = rand() % 100;
        for(int i = 0; i < del.nDelays; ++i) {
          if(r < del.prob[i]) {
            changed = true;
            del.nSeconds = del.seconds[i];
            t.flags |= TFLG.TFLG_ENTEREDLATE;
            break;
          }
        }
      }
      return del.nSeconds;
    }

    public static void train_derailed(Train trn, Track trk) {
      string buff;

      new_train_status(trn, trainstat.train_DERAILED);
      trn.position = null;
      add_update_schedule(trn);
      if(trk != null)
        buff = String.Format(wxPorting.L("Train %s derailed at %d,%d!"), trn.name, trk.x, trk.y);
      else
        buff = String.Format(wxPorting.L("Train %s derailed!"), trn.name);
      do_alert(buff);
    }

    public static void time_step() {
      Train t, t1;
      Track trk;
      TrainStop stp;
      string buff;
      string buff1;
      int speed;
      int do_beep = 0;
      int nSecDelay;
      bool changed;

      current_time += 1;
      if((current_time % HOUR(24)) == 0)
        crossing_midnight();
      if(frply != null)		/* issue all commands for this time slice */
        do_replay();
      for(t = schedule; t != null; t = t.next) {
        trk = null;
        if(t.isExternal)
          continue;
        switch(t.status) {
          case trainstat.train_ARRIVED:
            continue;

          case trainstat.train_READY:
            if(String.IsNullOrEmpty(t.entrance)) // || t.timein > current_time)
              continue;
            if(t.days != 0 && run_day != 0 && (t.days & run_day) == 0)
              continue;
            if(t.timein < start_time)	/* will always ignore it */
              continue;
            /* check delay 3 minutes before entry time */
            if((t.timein - 180 < current_time) && t._gotDelay == 0) {
              t._inDelay = get_delay(t) * 60;
              if(t._inDelay == 0) {
                t._inDelay = bstreet_enterdelay(t, out changed) * 60;
                t._inDelay += selectDelay(t, t.entryDelay, out changed);
                if(changed)
                  add_update_schedule(t);
              }
              t._gotDelay = 1;
            }
            if(t.timein + t._inDelay > current_time)
              continue;
            if(String.IsNullOrEmpty(t.waitfor) == false) {
              t1 = findTrainNamed(t.waitfor);
              if(t1 == null || t1.status != trainstat.train_ARRIVED)
                continue;
              if(t.waittime == 0)
                t.waittime = 60;	/* default we wait 60 seconds */
              if(t1.timeexited + t.waittime > current_time)
                continue;		/* can't depart, yet */
              buff1 = String.Copy(t1.exit);

              if((trk = findStation(buff1)) != null && trk.type != trktype.TRACK)
                goto startit;		/* exited the layout - no need to assign */
              if(t.timedelay == 0) {		/* first time, issue an alert */
                buff = String.Format(wxPorting.L("You must assign train %s using stock from train %s!"),
                      t.name, t.waitfor);
                do_alert(buff);
              }
              t.timedelay += time_mult;
              total_delay += time_mult;
              continue;
            }
            do_beep = 1;
          startit:
            buff1 = String.Copy(t.entrance);

          if(t.position != null)
            //change_coord(t.position.x, t.position.y);
            leave_track(t);
          if((trk = findEntryTrack(t, buff1)) == null) {
            train_derailed(t, trk);
            continue;
          }
          t.path = findPath0(t.path, trk, t.direction);
          if(t.path == null) {
            train_derailed(t, trk);
            continue;
          }
          if(t.tail == null) {
            t.tail.path = appendPath(t.tail.path, t.path);
            t.tail.tailentry = -t.length;
          }
          if(pathIsBusy(null, t.path, t.direction) != 0) {
            if(t.status != trainstat.train_DELAY) {
              // first time, warn the player
              new_train_status(t, trainstat.train_DELAY);
              add_update_schedule(t);
              buff = String.Format(wxPorting.L("Train %s delayed at %s!"), t.name, buff1);
              do_alert(buff);
            } else {
              t.timedelay += time_mult;
              total_delay += time_mult;
              add_update_schedule(t);
            }
            continue;
          }
          t.pathtravelled = 0;
        start_it:
          if(do_beep != 0 && beep_on_enter)
            enter_beep();
        new_train_status(t, trainstat.train_RUNNING);
        t.position = trk;
        //		t.pathpos = 1;	    /* 1 because trk is in path[0] */
        t.wrongdest = false;
        t.curspeed = t.maxspeed != 0 ? t.maxspeed : 60;
        t.curmaxspeed = (short)t.curspeed;
        t.trackpos = 0;
        speed = t.position.speed[t.type];
        if(speed == 0)
          speed = t.position.speed[0];
        if(speed != 0 && t.maxspeed != 0 && t.curspeed > speed) {
          t.curspeed = speed;
          t.curmaxspeed = (short)t.curspeed;
        } else if(speed != 0 && t.maxspeed == 0 && speed > t.curspeed) {
          t.curspeed = speed;
          t.curmaxspeed = (short)t.curspeed;
        }
        changed = true;
        colorPath(t.path, trkstat.ST_GREEN);
        trk.SetColor(t.tail != null ? color_orange : conf.fgcolor);
        //		t.pathpos = 0;
        findStopPoint(t);
        findSlowPoint(t);
        //		t.pathpos = 1;
        if(trk.isstation)
          train_at_station(t, trk);
        add_update_schedule(t);
        t.OnEntry();
        continue;

          case trainstat.train_DELAY:
        if(t.path == null)
          goto startit;
        if(pathIsBusy(null, t.path, t.direction) != 0) {
          t.timedelay += time_mult;
          total_delay += time_mult;
          add_update_schedule(t);
          break;
        }
        do_beep = 1;
        trk = t.path.TrackAt(0);
        goto start_it;

          case trainstat.train_STOPPED:
        trk = t.position;
        if(String.IsNullOrEmpty(trk.station) && t.tail != null && t.tail.path != null) {
          trk = path_find_station(t.tail.path, t.position);
          if(trk == null)
            trk = t.position;
        }
        nSecDelay = 0;
        changed = false;
        if(trk != null && String.IsNullOrEmpty(trk.station) == false) {
          stp = findStop(t, trk);
          if(stp != null) {
            nSecDelay = selectDelay(t, stp.depDelay, out changed);
          } else if(sameStation(trk.station, t.entrance)) {
            nSecDelay = selectDelay(t, t.entryDelay, out changed);
          }
        }
        t.flags |= TFLG.TFLG_GOTDELAYATSTOP;

        if(changed)
          add_update_schedule(t);
        if(t.timedep + nSecDelay > current_time)
          continue;
        if((t.flags & (TFLG.TFLG_WAITINGMERGE | TFLG.TFLG_MERGING)) != 0)
          continue;
        new_train_status(t, trainstat.train_RUNNING);
        t.OnStart();
        if(t.timedep > current_time) {
          new_train_status(t, trainstat.train_STOPPED);
          continue;
        }
        t.flags &= TFLG.TFLG_ENTEREDLATE;	/* clear performance flags */
        findStopPoint(t);	/* find next stop point */
        t.needfindstop = true;
        new_train_status(t, trainstat.train_RUNNING);
        goto runit;

          case trainstat.train_STARTING:        // 3.8i

        if(--t.startDelay > 0) {
          add_update_schedule(t);
          break;
        }
        t.startDelay = 0;

          // After the STARTING delay has expired, we need
          // to call fetch_path() again so that we can advance
          // past the signal, and also to check if the signal
          // is still cleared.
          //
          // So, fall through...
        goto case trainstat.train_WAITING;

          case trainstat.train_WAITING:
        if((t.flags & TFLG.TFLG_WAITINGMERGE) != 0)
          continue;
        switch(fetch_path(t)) {
          case 0:
            // we could not enter the path, maybe because the user
            // has closed the signal while we were starting,
            // so go back to WAITING state
            if(t.status == trainstat.train_STARTING && t.startDelay == 0)
              new_train_status(t, trainstat.train_WAITING);
            continue;
          case -1:
            train_derailed(t, null);
            continue;
        }
        t.outof = null;		/* in case we are moving from
     					 * one platform to another, we
     					 * want to stop at the same station.
     					 */
        goto case trainstat.train_RUNNING;

          case trainstat.train_RUNNING:
      /*case train_SHUNTING:*/
      runit:
        t.flags &= ~(TFLG.TFLG_TURNED | TFLG.TFLG_GOTDELAYATSTOP);
      if(run_train(t) == -1)
        train_derailed(t, null);
      else
        add_update_schedule(t);
      continue;
        }
      }
    }

    public static void record_state() {
    }


    public static void click_time() {
      int i;
      int oldmult;
      Train t;

      if(!running) {
        flash_signals();
        repaint_all();
        return;
      }
      changed = 0;
      signals_changed = 0;
      for(i = oldmult = time_mult; i > 0; --i) {
        time_mult = 1;
        time_step();
        if(time_mult != 1)		// if changed by a trigger
          oldmult = time_mult;	// we'll restore the new value
        UpdateSignals(null, false);
        if((current_time % 60) == 59) {	// at the top of a minute
          // record how many late minutes we have accumulated
          late_data[(current_time / 60) % (60 * 24)] = total_late;
        }
        record_state();
      }
      flash_signals();
      if(changed != 0)
        repaint_all();
      changed = 0;
      time_mult = oldmult;
      while(save_assign_list != null) {
        SaveAssign s = save_assign_list;
        save_assign_list = s.next;
        assign_train(s.newTrain, s.oldTrain);
        Globals.free(s);
      }
      update_labels();
      for(t = schedule; t != null; t = t.next)
        if(t.newsched != null)
          break;
      if(t != null) {
        // some train's data was updated
        // - update all timetable views in our UI
        for(t = schedule; t != null; t = t.next)
          if(t.newsched != 0) {
            update_schedule(t);
          }
        // - tell any waiting servers (i.e. the web server)
        timetable.NotifyListeners();
      }
    }

    public static void start_stop() {
      if(running) {
        make_timer(0);
        running = false;
      } else {
        running = true;
        make_timer(1000);
      }
    }


    public static void save_assign_train(Train newTrain, Train oldTrain) {
      SaveAssign s;

      // 3.7u: Avoid duplicates. These can happen if 2 triggers
      // apply the same assign action to the same train
      // (because they are linked to the same track).
      for(s = save_assign_list; s != null; s = s.next)
        if(s.oldTrain == oldTrain && s.newTrain == newTrain)
          return;
      s = new SaveAssign();
      s.oldTrain = oldTrain;
      s.newTrain = newTrain;
      s.next = save_assign_list;
      save_assign_list = s;
    }

    public static void assign_train(Train t, Train oldtrain) {
      //if(String.IsNullOrEmpty(oldtrain.stock) == false && wxStrcmp(t.name, oldtrain.stock) != 0)
      //  ++perf_tot.wrong_assign;
      /////	if(oldtrain.status != train_ARRIVED) {
      /////	    train_arrived(oldtrain);
      /////	    add_update_schedule(oldtrain);
      /////	}

      //if((oldtrain.flags & TFLG.TFLG_STRANDED) != 0) {
      //  oldtrain.path = findPath(oldtrain.position, oldtrain.direction);
      //  if(oldtrain.path == null) {
      //    ++perf_tot.denied;
      //    update_labels();
      //    return;
      //  }
      //  if(pathIsBusy(oldtrain, oldtrain.path, oldtrain.direction) != 0) {
      //    Track nxtrk = oldtrain.path.TrackAt(1);
      //    if(nxtrk.fgcolor != color_green) {
      //      do_alert(wxPorting.L("Cannot restart train. Path is busy."));
      //      Vector_delete(oldtrain.path);
      //      oldtrain.path = null;
      //      ++perf_tot.denied;
      //      update_labels();
      //      return;
      //    }
      //  }
      //  if(oldtrain.tail != null && oldtrain.tail.path != null) {
      //    appendPath(oldtrain.tail.path, oldtrain.path);
      //  }
      //  colorPath(oldtrain.path, trkstat.ST_GREEN);
      //  findStopPoint(oldtrain);
      //  findSlowPoint(oldtrain);
      //}

      //if((t.arrived || t.oldstatus == trainstat.train_ARRIVED) && t.merging != null) {// we are shunting
      //  new_train_status(t, trainstat.train_ARRIVED);
      //  t.stopping = null;
      //  t.curspeed = 0;
      //  t.shunting = false;
      //  t.outof = null;
      //} else
      //  new_train_status(t, trainstat.train_STOPPED);	// train_at_station
      //update_labels();
      ////	changed = 1;
      //if(oldtrain.status == trainstat.train_ARRIVED && oldtrain.position == null) {
      //  return;
      //}
      //t.path = oldtrain.path;
      //t.position = oldtrain.position;
      ////	t.pathpos = oldtrain.pathpos;
      //t.direction = oldtrain.direction;
      //t.curmaxspeed = oldtrain.curmaxspeed;
      //if(t.maxspeed == 0)
      //  t.maxspeed = oldtrain.maxspeed;
      //// the new train departs in the morning, but the old train arrived in the afternoon
      //// this means the new train will start in the following day, so add 24 hours
      //if(t.timein < HOUR(12) && oldtrain.timeexited >= HOUR(12))
      //  t.timedep = (int)(t.timein + HOUR(24));
      //else
      //  t.timedep = t.timein;
      //if(String.IsNullOrEmpty(t.waitfor) == false) {
      //  if(t.waittime == 0)
      //    t.waittime = 60;	/* default we wait 60 seconds */
      //}
      ///*
      // if(!t._inDelay) {
      //     bool    changed;
      //     t._inDelay = selectDelay(t, t.entryDelay, &changed);
      //     if(changed)
      //   add_update_schedule(t);
      // }
      // t._gotDelay = 1;
      // if(t._inDelay) {
      //     t.timedep += t._inDelay;
      // }
      // */
      //if(oldtrain.tail != null) {
      //  if(t.tail == null) {
      //    t.length = oldtrain.length;
      //    t.tail = calloc<Train>(1);
      //    t.ecarpix = oldtrain.ecarpix;
      //    t.wcarpix = oldtrain.wcarpix;
      //  }
      //  if((oldtrain.flags & TFLG.TFLG_STRANDED) != 0 && t.tail.path != null) {
      //    // extend stranded train's tail path with incoming train's tail path
      //    oldtrain.tail.path.Insert(t.tail.path);
      //    oldtrain.tail.position = t.tail.path.TrackAt(0);
      //    oldtrain.tail.trackpos = t.tail.trackpos;
      //  } else {

      //    /* here we are assigning the material of a train
      //     * already in the territory (oldtrain) to a train
      //     * which is not on the territory (t).
      //     * We should check that the preset length of the
      //     * destination train is the same as that of the old train.
      //     * If it is, then we can simply copy the path to the
      //     * destination train.
      //     * If the destination train is longer, we should
      //     * notify the player that we don't have enough rolling
      //     * stock, and add to the penalty.
      //     * If the destination train is longer we should split
      //     * the source in two, and leave some cars in the path.
      //     *
      //     * For the time being we simply assign the source train
      //     * to the destination train.
      //     */

      //  }
      //  t.tail.path = oldtrain.tail.path;
      //  //	    t.tail.pathpos = oldtrain.tail.pathpos;
      //  t.tail.position = oldtrain.tail.position;
      //  t.tail.trackpos = oldtrain.tail.trackpos;
      //  t.fleet = oldtrain.fleet;
      //  oldtrain.fleet = null;
      //  oldtrain.tail.path = null;
      //  //	    oldtrain.tail.pathpos = 0;
      //  oldtrain.tail.trackpos = 0;
      //  oldtrain.tail.position = null;
      //}
      //// maybe the assignment was initiated by a trigger
      //if(oldtrain.status != trainstat.train_ARRIVED) {
      //  train_arrived(oldtrain);
      //  oldtrain.OnArrived();
      //  //	    add_update_schedule(oldtrain);
      //}
      //if(String.IsNullOrEmpty(t.waitfor) == false) {
      //  if(oldtrain.timeexited + t.waittime > t.timedep)
      //    t.timedep = oldtrain.timeexited + t.waittime;
      //}
      ////	oldtrain.pathpos = 0;
      //oldtrain.path = null;
      //oldtrain.position = null;
      //if((oldtrain.flags & TFLG.TFLG_STRANDED) != 0) {
      //  remove_from_stranded_list(oldtrain);
      //  change_coord(t.position.x, t.position.y);
      //  update_schedule(oldtrain);	// to remove from list
      //  delete(oldtrain);
      //} else {
      //  change_coord(t.position.x, t.position.y);
      //  update_schedule(oldtrain);	// to remove from list
      //}
      //update_schedule(t);
      //t.OnAssign();
    }

    public static void shunt_train(Train t) {
      if(t == null || ((t.flags & (TFLG.TFLG_STRANDED | TFLG.TFLG_WAITINGMERGE)) != 0))
        return;
      t.oldstatus = t.status;
      new_train_status(t, trainstat.train_RUNNING);
      t.shunting = true;
      t.stoppoint = null;
      t.slowpoint = null;
      t.outof = t.position;
      t.OnShunt();
    }

    public static void split_train(Train t, int length) {
      Train stk;

      if((t.flags & TFLG.TFLG_STRANDED) != 0)	    /* can't split multiple times */
        return;
      stk = new Train();
      stk.next = stranded;
      stranded = stk;
      stk.name = String.Copy(wxPorting.T(""));
      stk.type = t.type;
      stk.flags = TFLG.TFLG_STRANDED;
      stk.position = t.position;
      stk.direction = t.direction;
      stk.curmaxspeed = t.curmaxspeed;  /* in case of re-assignment later */
      stk.maxspeed = t.maxspeed;
      stk.ecarpix = t.ecarpix;
      stk.wcarpix = t.wcarpix;
      stk.status = trainstat.train_ARRIVED;
      if(t.length != 0) {
        stk.length = (short)(t.length - length);
        if(t.tail != null) {
          int l = 0;

          stk.tail = new Train();
          stk.tail.path = Globals.new_Vector();
          for(l = 0; l < stk.length; ) {
            Track trk = t.tail.path.TrackAt(0);
            int f = t.tail.path.FlagAt(0);
            stk.tail.path.Add(trk, f);
            l += trk.length;
            if(l >= stk.length) {
              t.tail.position = trk;
              stk.position = trk;
              stk.tail.position = stk.tail.path.TrackAt(0);
              break;
            }
            t.tail.path.DeleteAt(0);
            if(t.tail.path._size < 1)
              break;
          }
        }
        if(length != 0)
          t.length = (short)length;
      }
    }


    public static bool reverse_train(Train tr) {
      throw new NotImplementedException();
      //Track pos, headpos, tailpos = null;
      //Vector path;
      //trkdir newdir;
      //double f;

      //if(tr.position == null)
      //  return false;
      //switch(tr.direction) {
      //  case trkdir.W_E:
      //    newdir = trkdir.E_W;
      //    break;
      //  case trkdir.E_W:
      //    newdir = trkdir.W_E;
      //    break;
      //  case trkdir.N_S:
      //    newdir = trkdir.S_N;
      //    break;
      //  case trkdir.S_N:
      //    newdir = trkdir.N_S;
      //    break;
      //}
      //headpos = tr.position;
      //if(tr.tail != null && (tailpos = tr.tail.position) != null && tailpos != tr.position)
      //  path = findPath(tailpos, newdir);
      //else
      //  path = findPath(headpos, newdir);
      //if(path == null) {
      //  ++perf_tot.denied;
      //  update_labels();
      //  return false;
      //}
      //if(tailpos != null) {
      //  tailpos.SetColor(conf.fgcolor);
      //  tr.tail.position = null;
      //} else {
      //  leave_track(tr);
      //  tr.position.SetColor(conf.fgcolor);
      //  tr.position = null;
      //}
      //if(pathIsBusy(tr, path, newdir) != 0) {
      //  if(tailpos != null) {
      //    tr.tail.position = tailpos;
      //    tailpos.SetColor(color_orange);
      //  } else
      //    tr.position = headpos;
      //  do_alert(wxPorting.L("Cannot reverse direction. Path is busy."));
      //  Vector_delete(path);
      //  ++perf_tot.denied;
      //  update_labels();
      //  return false;
      //}

      //// We verified that all conditions are good for reversing
      //// the direction, so now do the actual reverse.

      //if(tr.path != null) {
      //  if(tr.tail != null && tr.tail.path != null) {
      //    // remove tracks ahead of old head from tail's path
      //    // leaving head's position (the loco) in the path
      //    for(f = 1; f < tr.path._size; ++f)
      //      tr.tail.path.DeleteTrack(tr.path.TrackAt((int)f));
      //  }
      //  colorPartialPath(tr.path, trkstat.ST_FREE, 0); //tr.pathpos);
      //  Vector_delete(tr.path);
      //  tr.path = null;
      //}
      //if(tr.merging != null) {
      //  tr.merging.flags &= ~TFLG.TFLG_WAITINGMERGE;
      //  tr.flags &= ~TFLG.TFLG_MERGING;
      //  tr.merging = null;
      //}
      //if(tailpos != null && tr.tail.path != null) {
      //  reverse_path(tr.tail);
      //  //	    tr.tail.pathpos = 0;
      //  f = tr.tail.trackpos;
      //  tr.tail.trackpos = headpos.length - tr.trackpos;
      //  if(tailpos != null)
      //    tr.trackpos = tailpos.length - f;
      //  else
      //    tr.trackpos = headpos.length - f - tr.length;
      //  if(tr.trackpos < 0)
      //    tr.trackpos = 0;
      //}
      //tr.direction = newdir;
      //if((tr.flags & TFLG.TFLG_STRANDED) == 0)
      //  colorPath(path, trkstat.ST_GREEN);
      //if(tr.tail != null) {
      //  tr.position = tailpos != null ? tailpos : headpos;
      //  tr.tail.position = tailpos != null ? headpos : null;
      //  tr.tail.path = appendPath(tr.tail.path, path);
      //  change_coord(headpos.x, headpos.y);
      //} else
      //  tr.position = headpos;
      //pos = tr.position;
      //pos.SetColor(conf.fgcolor);
      //if((tr.flags & TFLG.TFLG_TURNED) != 0) {
      //  ++perf_tot.turned_train;
      //  update_labels();
      //}
      //tr.flags |= TFLG.TFLG_TURNED;
      //tr.flags ^= TFLG.TFLG_SWAPHEADTAIL;	// swap head and tail icons
      //tr.path = path;
      //tr.pathtravelled = 0;
      ////	tr.pathpos = 1;	    /* 1 because trk is in path[0] */
      //if(tr.status != trainstat.train_STOPPED) {/* waiting at a signal? */
      //  if(tr.status != trainstat.train_ARRIVED) {
      //    if(tr.status == trainstat.train_WAITING) {
      //      new_train_status(tr, trainstat.train_RUNNING);
      //      findStopPoint(tr);
      //      findSlowPoint(tr);
      //    } else {
      //      new_train_status(tr, trainstat.train_STOPPED);
      //      if(tr.tail != null && tr.tail.path != null && path_find_station(tr.tail.path, tr.stopping) != null) {
      //        train_at_station(tr, tr.stopping);
      //      } else {
      //        tr.timedep = current_time;
      //      }
      //    }
      //    tr.outof = null;
      //  }
      //}
      //tail_advance(tr);	    /* compute and draw tail path */
      //tr.OnReverse();
      //repaint_all();
      //return true;
    }

    public static bool toggle_signal_auto(Signal t, bool do_log) {
      throw new NotImplementedException();
      //Vector path;

      //if(t.fixedred) {
      //  do_alert(wxPorting.L("This signal cannot be turned to green!"));
      //  return false;
      //}
      //path = findPath(t.controls, t.direction);
      //if(path == null)
      //  return false;
      //if(flog.IsOpened() && do_log)
      //  flog.Write(String.Format(wxPorting.T("%ld,click %d,%dn"), current_time, t.x, t.y));
      //if(t._isShuntingSignal) {
      //  t.OnClicked();
      //  change_coord(t.x, t.y);
      //  if(do_log)
      //    repaint_all();
      //  UpdateSignals(t);
      //  Vector_delete(path);
      //  return false;
      //}
      //if(t.IsClear()) { // t.status == ST_GREEN) {
      //  if(!t.fleeted && !t.noClickPenalty) {
      //    ++perf_tot.cleared_signal;
      //    update_labels();
      //  }
      //  unreserveIntermediateSignals(path);
      //  t.OnUnclear();	// set to red
      //  //	    t.status = ST_RED;
      //  if(!t._intermediate)
      //    t.nowfleeted = false;
      //  change_coord(t.x, t.y);
      //  colorPath(path, trkstat.ST_READY);
      //  if(do_log)
      //    repaint_all();
      //  UpdateSignals(t);
      //  Vector_delete(path);
      //  return false;
      //}
      //if(String.IsNullOrEmpty(t._lockedBy) == false) {
      //  string p = t._lockedBy;
      //  int x, y;
      //  while(p.Length > 0) {
      //    if(p[0] == wxPorting.T(' ') || p[0] == wxPorting.T('t')) p.incPointer();
      //    if(p.Length == 0)
      //      break;
      //    x = wxStrtol(p, &p, 10);
      //    if(p[0] == wxPorting.T(',')) p.incPointer();
      //    y = wxStrtol(p, &p, 10);
      //    Track trk = findTrack(x, y);
      //    if(trk != null) {
      //      if(trk.fgcolor != conf.fgcolor) {
      //        Vector_delete(path);
      //        return false;
      //      }
      //    }
      //    if(p[0] == wxPorting.T(';')) p.incPointer();
      //  }
      //}
      //if(pathIsBusy(null, path, t.direction) != 0) {
      //  Vector_delete(path);
      //  if(do_log)
      //    repaint_all();
      //  return false;
      //}
      //Array<Signal> intermediateSignals;
      //if(!t._intermediate && !checkIntermediateSignals(path, intermediateSignals)) {
      //  Vector_delete(path);
      //  if(do_log)
      //    repaint_all();
      //  return false;
      //}
      //change_coord(t.x, t.y);
      //t.OnClear();	// set to green
      //if(!t.IsClear()) {     // script wants to keep the signal red
      //  Vector_delete(path);
      //  if(do_log)
      //    repaint_all();
      //  return false;
      //}
      ////	t.status = ST_GREEN;
      //t.SetColor(color_green);
      //colorPath(path, trkstat.ST_GREEN);
      //if(do_log)
      //  repaint_all();
      //UpdateSignals(t);
      //t.aspect_changed = false;
      //t.OnUpdate();
      //reserveIntermediateSignals(intermediateSignals);
      //Vector_delete(path);
      //return true;
    }

    public static bool toggle_signal(Signal t) {
      return toggle_signal_auto(t, true);
    }

    public static void track_selected(int x, int y) {
//      Track t, t1;
//      Signal s;
//      Train trn;
//      int i;
//      string buff;

//      if((trn = findTrain(x, y)) != null) {
//        if(trn.curspeed != 0) {
//          do_alert(wxPorting.L("You must wait for train to stop."));
//          return;
//        }
//        if(ask(wxPorting.L("Reverse train direction?")) != AskAnswer.ANSWER_YES)
//          return;
//        buff = String.Format(wxPorting.T("reverse %s"), trn.name);
//        trainsim_cmd(buff);
//      } else if((t = findSwitch(x, y)) != null) {
//        t.OnClicked();
//        if(t.fgcolor == color_green) {
//          ++perf_tot.denied;
//          update_labels();
//          return;
//        }
//        if(flog.IsOpened())
//          flog.Write(String.Format(wxPorting.T("%ld,click %d,%dn"), current_time, x, y));
//        if((t1 = findSwitch(t.wlinkx, t.wlinky)) != null) {
//          if(t1.fgcolor == color_green) {
//            ++perf_tot.denied;
//            update_labels();
//            return;
//          }
//          change_coord(t1.x, t1.y);
//          t1.switched = !t1.switched;
//        }
//        t.switched = !t.switched;
//        if((t.flags & TFLG.TFLG_THROWN) != 0) {
//          ++perf_tot.thrown_switch;
//          update_labels();
//        }
//        t.flags |= TFLG.TFLG_THROWN;
//        change_coord(t.x, t.y);
//        onIconUpdateAll();
//        repaint_all();
//      } else if((s = findSignal(x, y)) != null && s.controls != null && s.IsShuntingSignal()) {
//        i = (int)s.status;
//        if(!toggle_signal(s) && i != trkstat.ST_GREEN) {
//          ++perf_tot.denied;
//          update_labels();
//        } else {
//          s.aspect_changed = true;
//          UpdateSignals(s);
//        }
//      } else if((s = findSignal(x, y)) != null && s.controls != null && !s.IsApproach() && !s._intermediate) {
//        i = (int)s.status;
//        if(!toggle_signal(s) && i != trkstat.ST_GREEN) {
//          if(!s.noClickPenalty)
//            ++perf_tot.denied;
//          update_labels();
//        } else {
//          s.aspect_changed = true;
//          UpdateSignals(s);
//        }
//      } else if((t = findTrackType(x, y, trktype.ITIN))) {
//#if false  // !Rask Ingemann Lambertsen
//          Itinerary *it;
//          for(it = itineraries; it; it = it.next)
//        if(!wxStrcmp(it.name, t.station))
//            break;
//          itinerary_selected(it);
//#else
//        itinerary_selected(t);
//        onIconUpdateAll();
//#endif
//      } else if((t = findImage(x, y)) != null || (t = findTrack(x, y)) != null) {
//        t.OnClicked();
//        onIconUpdateAll();
//      }
    }

    public static void track_selected1(int x, int y) {
      //	Track	*t;
      Train tr;
      string buff;
      Signal s;

      if((s = findSignal(x, y)) != null) {
        if(!s.fleeted || !s.IsClear()) // t.status != ST_GREEN)
          return;
        if(flog.IsOpened())
          flog.Write(String.Format(wxPorting.T("%ld,rclick %d,%dn"), current_time, x, y));
        s.nowfleeted = !s.nowfleeted;
        s.OnAuto();
        change_coord(s.x, s.y);
        repaint_all();
        return;
      }
      if((tr = findTrain(x, y)) != null || (tr = findStranded(x, y)) != null || (tr = findStrandedTail(x, y)) != null) {
        if(tr.status == trainstat.train_ARRIVED && assign_ok != 0) {
          assign_dialog(tr);
          return;
        }
        if(tr.curspeed != 0) {
          if(!tr.shunting) {
            do_alert(wxPorting.L("You must wait for train to stop."));
            return;
          }
          do_alert(wxPorting.L("Train stopped."));
          tr.outof = null;
          train_at_station(tr, tr.position);    // revert from shunting to stopped
          add_update_schedule(tr);
          return;
        }
        if(ask(wxPorting.L("Proceed to next station?")) != AskAnswer.ANSWER_YES)
          return;
        buff = String.Format(wxPorting.T("shunt %s"), tr.name);
        trainsim_cmd(buff);
        return;
      }
    }

    public static int track_shift_selected(Coord pos) {
      Track t;
      Train trn;
      string buff;

      if((trn = findTrain(pos.x, pos.y)) != null) {
        //	    buff = String.Format( wxPorting.T("traininfo %s"), trn.name);
        //	    trainsim_cmd(buff);
        ShowTrainInfoDialog(trn);
        /*	    train_info_dialog(trn); */
        return 1;
      }
      if((t = findTrack(pos.x, pos.y)) != null && t.type == trktype.TRACK && String.IsNullOrEmpty(t.station) == false) {
        buff = String.Format(wxPorting.T("stationinfo %s"), t.station);
        trainsim_cmd(buff);
        /*	    station_sched_dialog(t.station); */
        return 1;
      }
      return 0;
    }

    public static int setShuntingPath(Vector path, trkdir direction, Train shunting) {
      Track trk;
      Train trn;
      int i;

      if((i = pathIsBusy(shunting, path, direction)) != 0) {
        trk = path.TrackAt(i - 1);
        trn = findTrain(trk.x, trk.y);
        if(trn == null)
          trn = findTail(trk.x, trk.y);
        if(trn == null)
          trn = findStranded(trk.x, trk.y);
        if(trn == null)
          trn = findStrandedTail(trk.x, trk.y);
        if(trn == null) {
          repaint_all();
          return -1;
        }
        switch(trn.status) {
          case trainstat.train_STOPPED:
          case trainstat.train_ARRIVED:
          case trainstat.train_WAITING:
            break;
          default:
            if(trn.shunting)
              break;
            repaint_all();
            return -1;
        }
        if(shunting != null) {
          shunting.merging = trn;
          trn.flags |= TFLG.TFLG_WAITINGMERGE;
        }
      } else
        i = path._size + 1;
      return i;
    }

    public static int track_control_selected(Coord pos) {
      Signal t;
      Track trk;
      Vector path;
      int i;

      if(((t = findSignal(pos.x, pos.y)) != null) && t.controls != null) {
        if(t.status == trkstat.ST_GREEN)
          return 0;
        if(t.fixedred) {
          /* ADD PENALTY */
          return 0;
        }
        // we ignore true approach signals
        if((t.IsApproach() && !t._isShuntingSignal) || t._intermediate)
          return 0;
        path = findPath(t.controls, t.direction);
        if(path == null)
          return 0;
        trk = path.TrackAt(0);
        if(trk.fgcolor == color_white) {
          for(i = 0; i < path._size; ++i) {
            trk = path.TrackAt(i);
            if(trk.fgcolor != color_white)
              break;
            trk.SetColor(conf.fgcolor);
            t.OnUnclear();	// set to red
          }
        } else {
          i = setShuntingPath(path, t.direction, null);
          if(i < 0) {
            Vector_delete(path);
            return 0;
          }
          change_coord(t.x, t.y);
          t.status = trkstat.ST_WHITE;		// TODO: remove
          t.SetColor(color_white);	// TODO: remove
          colorPathStart(path, trkstat.ST_WHITE, i - 1);
          t.OnShunt();
        }
        t.aspect_changed = true;
        signals_changed = 1;
        UpdateSignals(null);
        Vector_delete(path);
        repaint_all();
        return 1;
      }

      return track_shift_selected(pos);
    }

    public static void fill_itinerary(Itinerary it, Signal sig) {
    //  Track t;
    //  Vector path;
    //  int i;
    //  trkdir dir;
    //  string buff;

    //  if(sig.controls == null)	/* bad! */
    //    return;
    //  if(!sig.IsClear()) // status != ST_GREEN)/* we want a path after the signal! */
    //    return;
    //  path = findPath(sig.controls, sig.direction);
    //  if(path == null)
    //    return;
    //  i = path._size - 1;
    //  if(i < 0)
    //    return;
    //  t = path.TrackAt(i);
    //  dir = (trkdir)path.FlagAt(i);
    //  if(t.type == trktype.TEXT)
    //    goto ok;
    //  if((t = findNextTrack(dir, t.x, t.y)) == null) {
    //    Vector_delete(path);
    //    return;		/* should be impossible */
    //  }
    //  sig = (dir == trkdir.E_W || dir == trkdir.N_S) ? t.wsignal : t.esignal;
    //  if(sig == null) {
    //    Vector_delete(path);
    //    return;
    //  }
    //  if(String.IsNullOrEmpty(sig.station)) {
    //    buff = String.Format(wxPorting.T("(%d,%d)"), sig.x, sig.y);
    //    sig.station = String.Copy(buff);
    //  }
    //  t = (Track)sig;
    //ok:
    //  if(it.endsig && wxStrcmp(it.endsig, t.station))
    //    Globals.free(it.endsig);
    //  it.endsig = String.Copy(t.station);
    //  for(i = 0; i < path._size; ++i) {
    //    t = path.TrackAt(i);
    //    if(t.type == trktype.SWITCH)
    //      add_itinerary(it, t.x, t.y, t.switched ? 1 : 0);
    //  }
    //  Vector_delete(path);
    }

    public static void open_all_signals() {
      TrackBase t;

      for(t = layout; t != null; t = t.next) {
        if(t.type == trktype.TSIGNAL) {
          Signal sig = (Signal)t;
          if(t.fleeted) {
            if(t.nowfleeted || t.status == trkstat.ST_GREEN || t.signalx != 0)
              continue;
            if(sig.IsApproach())
              continue;
            t.nowfleeted = true;
            toggle_signal((Signal)t);
          }
        }
      }
    }

    public static void open_all_fleeted() {
      Signal s;

      for(s = (Signal)signal_list; s != null; s = (Signal)s.next1) {
        if(!s.fleeted)
          continue;
        if(!s.nowfleeted || s.IsClear()) // s.status == ST_GREEN)
          continue;
        if(s.controls == null || s.controls.fgcolor == color_green)
          continue;
        toggle_signal_auto(s, false);
      }
    }

    public static void UpdateSignals(Signal ignore) {
      UpdateSignals(ignore, true);
    }
    public static void UpdateSignals(Signal ignore, bool doUpdate) {
      open_all_fleeted();

      // if the aspect of any signal has changed,
      // notify all signals and have them perform
      // any appropriate action, such as changing
      // the aspect of an approach signal.

      if(signals_changed != 0) {
        Signal s;

        if(ignore != null)
          ignore.aspect_changed = true;
        for(s = (Signal)signal_list; s != null; s = (Signal)s.next1) {
          s._prevState = s._currentState;
          if(s != ignore)
            s.aspect_changed = false;
        }
        do {
          signals_changed = 0;
          for(s = (Signal)signal_list; s != null; s = (Signal)s.next1)
            s._prevState = s._currentState;
          for(s = (Signal)signal_list; s != null; s = (Signal)s.next1)
            s.OnUpdate();
          for(s = (Signal)signal_list; s != null; s = (Signal)s.next1)
            if(s._currentState != s._prevState) {
              break;
            }
        } while(s != null); // was: signals_changed);
        open_all_fleeted();
        onIconUpdateAll();
      }
      signals_changed = 0;
      repaint_all();
    }

    public static void flash_signals() {
      Signal s;

      for(s = (Signal)signal_list; s != null; s = (Signal)s.next1) {
        if(!s._isFlashing)
          continue;
        s.OnFlash();
      }
    }


    public static void accelerate_train(Train t, long val) {
      if(t.status != trainstat.train_RUNNING)
        return;
      t.curmaxspeed += (short)val;
      if(t.curmaxspeed >= t.speedlimit) /* can't go faster than last speed limit */
        t.curmaxspeed = (short)t.speedlimit;
    }

    public static void decelerate_train(Train t, long val) {
      if(t.status != trainstat.train_RUNNING)
        return;
      if(t.curmaxspeed - val < 0)	    /* can't stop train! No way to resume, yet */
        return;
      t.curmaxspeed -= (short)val;
      if(t.curspeed > t.curmaxspeed)
        t.curspeed = t.curmaxspeed;
    }


    //
    //
    //

    public static void skip_to_next_event() {
      Train t;
      long next_time = 0x7fffffff;

      for(t = schedule; t != null; t = t.next) {
        if(t.isExternal)
          continue;
        switch(t.status) {
          case trainstat.train_READY:

            if(String.IsNullOrEmpty(t.entrance))
              continue;
            if(t.days != 0 && run_day != 0 && (t.days & run_day) == 0)
              continue;
            if(t.timein < start_time)	/* will always ignore it */
              continue;
            if(t.timein >= current_time && t.timein < next_time)
              next_time = t.timein;
            break;

          case trainstat.train_STOPPED:
            if(t.timedep > current_time && t.timedep < next_time)
              next_time = t.timedep;
            break;

          case trainstat.train_DELAY:
          case trainstat.train_RUNNING:
          case trainstat.train_WAITING:
            do_alert(wxPorting.L("Not all trains are stopped."));
            return;	    // failed

          case trainstat.train_DERAILED:
          case trainstat.train_ARRIVED:
            break;	    // don't care
        }
      }
      if(current_time + 180 > next_time) {
        do_alert(wxPorting.L("Next event is within 3 minutes."));
        return;
      }
      current_time = (int)(next_time - 180);
      update_labels();
    }

    //
    //
    //




    public static bool checkIntermediateSignals(Vector path, Array<Signal> intermediateSignals) {
      Track trk;
      Signal sig;
      Vector nextPath = null;
      trkdir ndir;
      trkdir dir;
      int size = path._size;
      if(size < 1)
        return true;

      trk = path.TrackAt(size - 1);
      dir = (trkdir)path.FlagAt(size - 1);
      while((trk = findNextTrack1(dir, trk.x, trk.y, out ndir)) != null) {

        // Check if we can cross the signal that protects the next block

        sig = (Signal)((dir == trkdir.W_E || dir == trkdir.S_N) ? trk.esignal : trk.wsignal);
        if(sig == null)
          break;

        if(!sig._intermediate)
          break;

        nextPath = findPath0(nextPath, trk, ndir);
        if(nextPath == null)
          break;
        if(!sig.IsClear()) {
          if(pathIsBusy(null, nextPath, ndir) != 0) {
            //                if(sig.fleeted && sig.nowfleeted) // all following signals will eventually clear
            //                    break; // which means the following path(s) are valid
            Track t0 = nextPath.FirstTrack();
            Track tx = nextPath.LastTrack();
            if(t0.fgcolor != conf.fgcolor || tx.fgcolor == conf.fgcolor) {
              Vector_delete(nextPath);
              return false;
            }
            // track is occupied by a train traveling in the same direction,
            // that is, another train preceding us
          }
        }
        size = nextPath._size;
        if(size < 1)
          break;
        intermediateSignals.Add(sig);
        trk = nextPath.TrackAt(size - 1);
        dir = (trkdir)nextPath.FlagAt(size - 1);
      }
      for(int i = 0; i < intermediateSignals.Length(); ++i) {
        sig = intermediateSignals.At(i);
        sig.fleeted = true;
        sig.nowfleeted = true;
        change_coord(sig.x, sig.y);
      }
      if(nextPath != null)
        Vector_delete(nextPath);
      return true;
    }

    public static void reserveIntermediateSignals(Array<Signal> intermSigs) {
      for(int i = 0; i < intermSigs.Length(); ++i) {
        Signal sig = intermSigs.At(i);
        sig._nReservations++;
      }
    }

    public static void unreserveIntermediateSignals(Vector path) {
      //Track trk;
      //Signal sig;
      //Vector nextPath = null;
      //trkdir ndir;
      //trkdir dir;
      //int size = path._size;
      //if(size < 1)
      //  return;
      //trk = path.LastTrack();
      //dir = (trkdir)path.FlagAt(size - 1);
      //while((trk = findNextTrack1(dir, trk.x, trk.y, out ndir)) != null) {

      //  sig = (Signal)((dir == trkdir.W_E || dir == trkdir.S_N) ? trk.esignal : trk.wsignal);
      //  if(sig == null)
      //    break;

      //  if(!sig._intermediate)
      //    break;

      //  nextPath = findPath0(nextPath, trk, ndir);
      //  if(nextPath == null)
      //    break;

      //  // clear signal
      //  change_coord(sig.x, sig.y);
      //  if(sig._nReservations < 2) {
      //    sig.nowfleeted = false;
      //    sig.fleeted = false;
      //    if(sig.IsClear()) {  // no train after signal
      //      //sig.SetColor(color_green);
      //      colorPath(nextPath, conf.fgcolor);
      //    }
      //    sig.OnUnclear();
      //    sig._nReservations = 0;
      //    UpdateSignals(sig);
      //  } else {
      //    --sig._nReservations;
      //  }

      //  size = nextPath._size;
      //  if(size < 1)
      //    break;
      //  trk = nextPath.LastTrack();
      //  dir = (trkdir)nextPath.FlagAt(size - 1);
      //}
      //if(nextPath != null)
      //  Vector_delete(nextPath);
    }

  }
}