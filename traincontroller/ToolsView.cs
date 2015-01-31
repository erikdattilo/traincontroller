using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.Drawing;

namespace TrainDirNET {
  class ToolsView : Window {
    public string m_name;

    public ToolsView(Window parent)
      : base(parent, (int)MenuIDs2.wxID_ANY, new Point(0, 0),
    new Size(Configuration.XMAX, Configuration.YMAX), (WindowStyles)0, "") {
      EVT_PAINT(new EventListener(OnPaint));
      EVT_LEFT_DOWN(new EventListener(OnMouseLeft));
      EVT_RIGHT_DOWN(new EventListener(OnMouseRight));
      EVT_LEFT_DCLICK(new EventListener(OnMouseDblLeft));
      EVT_RIGHT_DCLICK(new EventListener(OnMouseDblRight));

      GlobalVariables.tools_grid = new grid(this);
      GlobalVariables.tools_grid.m_hmult = Configuration.HGRID * 3;
      GlobalVariables.tools_grid.m_vmult = Configuration.VGRID * 3;
      GlobalVariables.tools_grid.Clear();

    }

    public void OnPaint(object sender, Event evt) {
      //Track trk_tools;

      //if(GlobalVariables.tools_grid == null)
      //    return;
      //grid old = GlobalVariables.current_grid;
      //current_grid = tools_grid;
      //switch(current_toolset) {
      //case 1:
      //    trk_tools = tool_tracks;
      //    break;

      //case 2:
      //    trk_tools = tool_switches;
      //    break;

      //case 3:
      //    trk_tools = tool_signals;
      //    break;

      //case 4:
      //    trk_tools = tool_misc;
      //    break;

      //case 5:
      //    trk_tools = tool_actions;
      //    break;

      //default:
      //    return;
      //}
      //tools_grid.m_dc.SelectObject(*tools_grid.m_pixmap);
      //tools_grid.m_dc.SetBrush(wxBrush(*wxTRANSPARENT_BRUSH));
      //layout_paint(trk_tools);
      //tools_grid.m_dc.SelectObject(*tools_grid.m_pixmap);
      //tools_grid.m_dc.SetBrush(wxBrush(*wxTRANSPARENT_BRUSH));
      //int	i;
      //for(i = 0; tooltbl[i].type != -1; ++i) {
      //    if(current_tool == i)
      //  tools_grid.m_dc.SetPen(*wxCYAN_PEN);
      //    else
      //  tools_grid.m_dc.SetPen(*wxBLACK_PEN);
      //    tools_grid.m_dc.DrawRectangle(
      //  tooltbl[i].x * tools_grid.m_hmult,
      //  tooltbl[i].y * tools_grid.m_vmult,
      //  tools_grid.m_hmult,
      //  tools_grid.m_vmult);
      //}
      //tools_grid.m_dc.SelectObject(wxNullBitmap);

      //draw_pixmap(1, 0, tracks_pixmap);
      //draw_pixmap(2, 0, switches_pixmap);
      //draw_pixmap(3, 0, signals_pixmap);
      //draw_pixmap(4, 0, tools_pixmap);
      //draw_pixmap(5, 0, actions_pixmap);
      //if(current_toolset == 5) {
      //    draw_pixmap(8, 1, move_start_pixmap);
      //    draw_pixmap(9, 1, move_end_pixmap);
      //    draw_pixmap(10, 1, move_dest_pixmap);
      //    draw_pixmap(11, 1, set_power_pixmap);
      //}
      //tools_grid.Paint(this, true);
      //current_grid = old;
    }

    public void OnMouseLeft(object sender, Event evt) {
      //  Point pos = ((MouseEvent)evt).Position;

      //  if(evt.ControlDown()) {
      //  } else if(evt.AltDown()) {
      //  } else if(evt.ShiftDown()) {
      //  }
      ///////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      //  // Now pos has the absolute position in the ToolsView
      //  string buff;

      //  buff = string.Format(wxPorting.T("selecttool %d,%d"),
      //      pos.x / tools_grid.m_hmult,
      //      pos.y / tools_grid.m_vmult
      //  );
      //  trainsim_cmd(buff);
    }

    public void OnMouseRight(object sender, Event evt) {
      //  Point pos = ((MouseEvent)evt).Position;

      //  if(evt.ControlDown()) {
      //  } else if(evt.AltDown()) {
      //  } else if(evt.ShiftDown()) {
      //  }
      ///////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
    }

    public void OnMouseDblLeft(object sender, Event evt) {
      //  Point pos = ((MouseEvent)evt).Position;

      ///////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      //  // Now pos has the absolute position in the ToolsView
    }

    public void OnMouseDblRight(object sender, Event evt) {
      //  Point pos = ((MouseEvent)evt).Position;

      ///////	CalcUnscrolledPosition(pos.x, pos.y, &pos.x, &pos.y);
      //  // Now pos has the absolute position in the ToolsView
    }


  }
}