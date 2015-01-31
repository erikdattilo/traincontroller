using System;
/*	ToolsView.cpp - Created by Giampiero Caprino

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
using wx;
using System.Drawing;
namespace Traincontroller2 {

  public static partial class Globals {


    public static int gFontSizeSmall = 7;
    public static int  gFontSizeBig = 10;


    public static void setBackgroundColor(wx.Colour col) {
      int rgb = curSkin.background;
      col.Set((byte)(rgb >> 16), (byte)((rgb >> 8) & 0xFF), (byte)(rgb & 0xFF));
    }

  }


  // ----------------------------------------------------------------------------
  // ToolsView
  // ----------------------------------------------------------------------------

  public class ToolsView : Window {
    public String m_name;

    public ToolsView(Window parent)
      : base(parent, (int)Window.wxID_ANY, new Point(0, 0),
    new Size(Configuration.XMAX, Configuration.YMAX),
      0, "" // Erik's patch (This line)
    ) {
    //  EVT_PAINT(new wx.EventListener(OnPaint));
    //  //    EVT_MOUSE_EVENTS(new wx.EventListener(OnMouse));
    //  EVT_LEFT_DOWN(new wx.EventListener(OnMouseLeft));
    //  EVT_RIGHT_DOWN(new wx.EventListener(OnMouseRight));
    //  EVT_LEFT_DCLICK(new wx.EventListener(OnMouseDblLeft));
    //  EVT_RIGHT_DCLICK(new wx.EventListener(OnMouseDblRight));

    //  Globals.tools_grid = new grid(this);
    //  Globals.tools_grid.m_hmult = Configuration.HGRID * 3;
    //  Globals.tools_grid.m_vmult = Configuration.VGRID * 3;
    //  Globals.tools_grid.Clear();
    }

    ~ToolsView() {
      if(Globals.tools_grid == null)
        Globals.delete(Globals.tools_grid);
      Globals.tools_grid = null;
    }

    public void OnPaint(object sender, Event evt) {
      //Track trk_tools;

      //if(Globals.tools_grid == null)
      //  return;
      //grid old = Globals.current_grid;
      //Globals.current_grid = Globals.tools_grid;
      //switch(Globals.current_toolset) {
      //  case 1:
      //    trk_tools = Globals.tool_tracks;
      //    break;

      //  case 2:
      //    trk_tools = Globals.tool_switches;
      //    break;

      //  case 3:
      //    trk_tools = Globals.tool_signals;
      //    break;

      //  case 4:
      //    trk_tools = Globals.tool_misc;
      //    break;

      //  case 5:
      //    trk_tools = Globals.tool_actions;
      //    break;

      //  default:
      //    return;
      //}
      //Globals.tools_grid.m_dc.SelectObject(Globals.tools_grid.m_pixmap);
      //Globals.tools_grid.m_dc.SetBrush(new wx.Brush(wxTRANSPARENT_BRUSH));
      //Globals.layout_paint(trk_tools);
      //Globals.tools_grid.m_dc.SelectObject(Globals.tools_grid.m_pixmap);
      //Globals.tools_grid.m_dc.SetBrush(new wxBrush(*wxTRANSPARENT_BRUSH));
      //int i;
      //for(i = 0; Globals.tooltbl[i].type != -1; ++i) {
      //  if(Globals.current_tool == i)
      //    Globals.tools_grid.m_dc.SetPen(wxCYAN_PEN);
      //  else
      //    Globals.tools_grid.m_dc.SetPen(wxBLACK_PEN);
      //  Globals.tools_grid.m_dc.DrawRectangle(
      //Globals.tooltbl[i].x * Globals.tools_grid.m_hmult,
      //Globals.tooltbl[i].y * Globals.tools_grid.m_vmult,
      //Globals.tools_grid.m_hmult,
      //Globals.tools_grid.m_vmult);
      //}
      //Globals.tools_grid.m_dc.SelectObject(wx.Bitmap.NullBitmap);

      //Globals.draw_pixmap(1, 0, Globals.tracks_pixmap);
      //Globals.draw_pixmap(2, 0, Globals.switches_pixmap);
      //Globals.draw_pixmap(3, 0, Globals.signals_pixmap);
      //Globals.draw_pixmap(4, 0, Globals.tools_pixmap);
      //Globals.draw_pixmap(5, 0, Globals.actions_pixmap);
      //if(Globals.current_toolset == 5) {
      //  Globals.draw_pixmap(8, 1, Globals.move_start_pixmap);
      //  Globals.draw_pixmap(9, 1, Globals.move_end_pixmap);
      //  Globals.draw_pixmap(10, 1, Globals.move_dest_pixmap);
      //  Globals.draw_pixmap(11, 1, Globals.set_power_pixmap);
      //}
      //Globals.tools_grid.Paint(this, true);
      //Globals.current_grid = old;
    }

    public void OnMouseLeft(object sender, Event evt1) {
      //MouseEvent evt = (MouseEvent)evt1;
      //Point pos = new Point(evt.Position.X, evt.Position.Y);

      //if(evt.ControlDown) {
      //} else if(evt.AltDown) {
      //} else if(evt.ShiftDown) {
      //}
      ///////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      //// Now pos has the absolute position in the ToolsView
      //string buff;

      //buff = String.Format( wxPorting.T("selecttool %d,%d"),
      //    pos.x / Globals.tools_grid.m_hmult,
      //    pos.y / Globals.tools_grid.m_vmult);
      //trainsim_cmd(buff);
    }

    public void OnMouseRight(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = new Point(evt.Position.X, evt.Position.Y);

      if(evt.ControlDown) {
      } else if(evt.AltDown) {
      } else if(evt.ShiftDown) {
      }
      /////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
    }

    public void OnMouseDblLeft(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = new Point(evt.Position.X, evt.Position.Y);

      /////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      // Now pos has the absolute position in the ToolsView
    }

    public void OnMouseDblRight(object sender, Event evt1) {
      MouseEvent evt = (MouseEvent)evt1;
      Point pos = new Point(evt.Position.X, evt.Position.Y);

      /////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      // Now pos has the absolute position in the ToolsView
    }

  }
}