using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class Signal : Track {
    // static
    public static void InitPixmaps() {
      string bufffg;
      string buff;
      int fgr, fgg, fgb;
      int r, g, b;
      string green_name = "G      c #0000d8000000";

      GlobalFunctions.getcolor_rgb(GlobalVariables.fieldcolors[(int)fieldcolor.COL_TRACK], out fgr, out fgg, out fgb);
      GlobalFunctions.getcolor_rgb(GlobalVariables.fieldcolors[(int)fieldcolor.COL_BACKGROUND], out r, out g, out b);

      bufffg = string.Format(".      c #{0:x2}00{0:x2}00{0:x2}00", fgr, fgg, fgb);
      buff = string.Format("       c #{0:x2}00{0:x2}00{0:x2}00", r, g, b);
      buff = string.Format("       c lightgray", r, g, b);
      GlobalVariables.n_sig_xpm[1] = GlobalVariables.s_sig_xpm[1] = GlobalVariables.e_sig_xpm[1] = GlobalVariables.w_sig_xpm[1] =
GlobalVariables.n_sigx_xpm[1] = GlobalVariables.s_sigx_xpm[1] = GlobalVariables.e_sigx_xpm[1] = GlobalVariables.w_sigx_xpm[1] = buff;

      GlobalVariables.n_sig_xpm[2] = GlobalVariables.s_sig_xpm[2] = GlobalVariables.e_sig_xpm[2] = GlobalVariables.w_sig_xpm[2] =
GlobalVariables.n_sigx_xpm[2] = GlobalVariables.s_sigx_xpm[2] = GlobalVariables.e_sigx_xpm[2] = GlobalVariables.w_sigx_xpm[2] = bufffg;
      GlobalVariables.n_sig_xpm[3] = GlobalVariables.s_sig_xpm[3] = GlobalVariables.e_sig_xpm[3] = GlobalVariables.w_sig_xpm[3] =
GlobalVariables.n_sigx_xpm[3] = GlobalVariables.s_sigx_xpm[3] = GlobalVariables.e_sigx_xpm[3] = GlobalVariables.w_sigx_xpm[3] = "G      c red";
      GlobalVariables.n_sig_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig_xpm);
      GlobalVariables.s_sig_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig_xpm);
      GlobalVariables.e_sig_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig_xpm);
      GlobalVariables.w_sig_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig_xpm);
      GlobalVariables.n_sigx_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.n_sigx_xpm);
      GlobalVariables.s_sigx_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.s_sigx_xpm);
      GlobalVariables.e_sigx_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigx_xpm);
      GlobalVariables.w_sigx_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigx_xpm);

      GlobalVariables.n_sig_xpm[3] = GlobalVariables.s_sig_xpm[3] = GlobalVariables.e_sig_xpm[3] = GlobalVariables.w_sig_xpm[3] =
GlobalVariables.n_sigx_xpm[3] = GlobalVariables.s_sigx_xpm[3] = GlobalVariables.e_sigx_xpm[3] = GlobalVariables.w_sigx_xpm[3] = green_name;
      GlobalVariables.n_sig_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig_xpm);
      GlobalVariables.s_sig_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig_xpm);
      GlobalVariables.e_sig_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig_xpm);
      GlobalVariables.w_sig_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig_xpm);
      GlobalVariables.n_sigx_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.n_sigx_xpm);
      GlobalVariables.s_sigx_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.s_sigx_xpm);
      GlobalVariables.e_sigx_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigx_xpm);
      GlobalVariables.w_sigx_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigx_xpm);

      GlobalVariables.e_sig2_xpm[1] = GlobalVariables.w_sig2_xpm[1] =
        GlobalVariables.n_sig2_xpm[1] = GlobalVariables.s_sig2_xpm[1] =
        GlobalVariables.e_sig2x_xpm[1] = GlobalVariables.w_sig2x_xpm[1] =
        GlobalVariables.n_sig2x_xpm[1] = GlobalVariables.s_sig2x_xpm[1] =
        GlobalVariables.e_sigP_xpm[1] = GlobalVariables.w_sigP_xpm[1] = buff;
      GlobalVariables.e_sig2_xpm[2] = GlobalVariables.w_sig2_xpm[2] =
        GlobalVariables.n_sig2_xpm[2] = GlobalVariables.s_sig2_xpm[2] =
        GlobalVariables.e_sig2x_xpm[2] = GlobalVariables.w_sig2x_xpm[2] =
        GlobalVariables.n_sig2x_xpm[2] = GlobalVariables.s_sig2x_xpm[2] =
        GlobalVariables.e_sigP_xpm[2] = GlobalVariables.w_sigP_xpm[2] = bufffg;
      GlobalVariables.e_sig2_xpm[3] = GlobalVariables.w_sig2_xpm[3] =
        GlobalVariables.n_sig2_xpm[3] = GlobalVariables.s_sig2_xpm[3] =
        GlobalVariables.e_sig2x_xpm[3] = GlobalVariables.w_sig2x_xpm[3] =
        GlobalVariables.n_sig2x_xpm[3] = GlobalVariables.s_sig2x_xpm[3] =
        GlobalVariables.e_sigP_xpm[3] = GlobalVariables.w_sigP_xpm[3] = "G      c red";
      GlobalVariables.e_sig2_xpm[4] = GlobalVariables.w_sig2_xpm[4] =
        GlobalVariables.n_sig2_xpm[4] = GlobalVariables.s_sig2_xpm[4] =
        GlobalVariables.e_sig2x_xpm[4] = GlobalVariables.w_sig2x_xpm[4] =
        GlobalVariables.n_sig2x_xpm[4] = GlobalVariables.s_sig2x_xpm[4] = "X      c red";
      GlobalVariables.e_sigP_xpm[4] = GlobalVariables.w_sigP_xpm[4] = "X      c gray";
      GlobalVariables.e_sig2_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2_xpm);
      GlobalVariables.w_sig2_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2_xpm);
      GlobalVariables.e_sigP_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigP_xpm);
      GlobalVariables.w_sigP_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigP_xpm);
      GlobalVariables.n_sig2_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2_xpm);
      GlobalVariables.s_sig2_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2_xpm);
      GlobalVariables.e_sig2x_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2x_xpm);
      GlobalVariables.w_sig2x_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2x_xpm);
      GlobalVariables.n_sig2x_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2x_xpm);
      GlobalVariables.s_sig2x_pmap[0] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2x_xpm);

      GlobalVariables.e_sig2_xpm[3] = GlobalVariables.w_sig2_xpm[3] =
      GlobalVariables.n_sig2_xpm[3] = GlobalVariables.s_sig2_xpm[3] =
      GlobalVariables.e_sig2x_xpm[3] = GlobalVariables.w_sig2x_xpm[3] =
      GlobalVariables.n_sig2x_xpm[3] = GlobalVariables.s_sig2x_xpm[3] = green_name;
      GlobalVariables.e_sigP_xpm[3] = GlobalVariables.w_sigP_xpm[3] = green_name;
      GlobalVariables.e_sig2_xpm[4] = GlobalVariables.w_sig2_xpm[4] =
      GlobalVariables.n_sig2_xpm[4] = GlobalVariables.s_sig2_xpm[4] =
      GlobalVariables.e_sig2x_xpm[4] = GlobalVariables.w_sig2x_xpm[4] =
      GlobalVariables.n_sig2x_xpm[4] = GlobalVariables.s_sig2x_xpm[4] = "X      c red";
      GlobalVariables.e_sigP_xpm[4] = GlobalVariables.w_sigP_xpm[4] = "X      c gray";
      GlobalVariables.e_sig2_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2_xpm);
      GlobalVariables.w_sig2_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2_xpm);
      GlobalVariables.e_sigP_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigP_xpm);
      GlobalVariables.w_sigP_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigP_xpm);
      GlobalVariables.n_sig2_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2_xpm);
      GlobalVariables.s_sig2_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2_xpm);
      GlobalVariables.e_sig2x_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2x_xpm);
      GlobalVariables.w_sig2x_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2x_xpm);
      GlobalVariables.n_sig2x_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2x_xpm);
      GlobalVariables.s_sig2x_pmap[1] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2x_xpm);

      GlobalVariables.e_sig2_xpm[3] = GlobalVariables.w_sig2_xpm[3] =
      GlobalVariables.n_sig2_xpm[3] = GlobalVariables.s_sig2_xpm[3] =
      GlobalVariables.e_sig2x_xpm[3] = GlobalVariables.w_sig2x_xpm[3] =
      GlobalVariables.n_sig2x_xpm[3] = GlobalVariables.s_sig2x_xpm[3] = green_name;
      GlobalVariables.e_sig2_xpm[4] = GlobalVariables.w_sig2_xpm[4] =
      GlobalVariables.n_sig2_xpm[4] = GlobalVariables.s_sig2_xpm[4] =
      GlobalVariables.e_sig2x_xpm[4] = GlobalVariables.w_sig2x_xpm[4] =
      GlobalVariables.n_sig2x_xpm[4] = GlobalVariables.s_sig2x_xpm[4] = "X      c #0000d8000000";
      GlobalVariables.e_sigP_xpm[4] = GlobalVariables.w_sigP_xpm[4] = "X      c white";
      GlobalVariables.e_sig2_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2_xpm);
      GlobalVariables.w_sig2_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2_xpm);
      GlobalVariables.e_sigP_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigP_xpm);
      GlobalVariables.w_sigP_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigP_xpm);
      GlobalVariables.n_sig2_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2_xpm);
      GlobalVariables.s_sig2_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2_xpm);
      GlobalVariables.e_sig2x_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2x_xpm);
      GlobalVariables.w_sig2x_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2x_xpm);
      GlobalVariables.n_sig2x_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2x_xpm);
      GlobalVariables.s_sig2x_pmap[2] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2x_xpm);

      GlobalVariables.e_sig2_xpm[3] = GlobalVariables.w_sig2_xpm[3] =
      GlobalVariables.n_sig2_xpm[3] = GlobalVariables.s_sig2_xpm[3] =
      GlobalVariables.e_sig2x_xpm[3] = GlobalVariables.w_sig2x_xpm[3] =
      GlobalVariables.n_sig2x_xpm[3] = GlobalVariables.s_sig2x_xpm[3] = "G      c red";
      GlobalVariables.e_sigP_xpm[3] = GlobalVariables.w_sigP_xpm[3] = "G      c red";
      GlobalVariables.e_sig2_xpm[4] = GlobalVariables.w_sig2_xpm[4] =
      GlobalVariables.n_sig2_xpm[4] = GlobalVariables.s_sig2_xpm[4] =
      GlobalVariables.e_sig2x_xpm[4] = GlobalVariables.w_sig2x_xpm[4] =
      GlobalVariables.n_sig2x_xpm[4] = GlobalVariables.s_sig2x_xpm[4] = "X      c orange";
      GlobalVariables.e_sigP_xpm[4] = GlobalVariables.w_sigP_xpm[4] = "X      c white";
      GlobalVariables.e_sig2_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2_xpm);
      GlobalVariables.w_sig2_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2_xpm);
      GlobalVariables.e_sigP_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.e_sigP_xpm);
      GlobalVariables.w_sigP_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.w_sigP_xpm);
      /*GlobalVariables.n_sig2_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.n_sig2_xpm);
      GlobalVariables.s_sig2_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.s_sig2_xpm);*/
      GlobalVariables.e_sig2x_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.e_sig2x_xpm);
      GlobalVariables.w_sig2x_pmap[3] = GlobalFunctions.get_pixmap(GlobalVariables.w_sig2x_xpm);
    }

    public void Draw() {
      grcolor color = GlobalVariables.color_red;
      int i;
      object p = null;
      Signal t = this;

      i = 0;					/* RR */
      if(t._interpreterData == null || (p = FindIcon()) == null) {
        if(t.fleeted) {
          if(t.status == trkstat.ST_GREEN) {
            if(t.nowfleeted)
              i = 2;			/* GG */
            else
              i = 1;			/* GR */
          } else if(t.nowfleeted)
            i = 3;				/* RO */
          switch(t.direction) {
            case trkdir.W_E:
              p = GlobalVariables.signal_traditional ?
            (t.signalx != 0 ? GlobalVariables.e_sig2x_pmap[i] : GlobalVariables.e_sig2_pmap[i]) : GlobalVariables.e_sigP_pmap[i];
              break;
            case trkdir.E_W:
              p = GlobalVariables.signal_traditional ?
            (t.signalx != 0 ? GlobalVariables.w_sig2x_pmap[i] : GlobalVariables.w_sig2_pmap[i]) : GlobalVariables.w_sigP_pmap[i];
              break;
            case trkdir.N_S:
              p = t.signalx != 0 ? GlobalVariables.s_sig2x_pmap[i] : GlobalVariables.s_sig2_pmap[i];
              break;
            case trkdir.S_N:
              p = t.signalx != 0 ? GlobalVariables.n_sig2x_pmap[i] : GlobalVariables.n_sig2_pmap[i];
              break;
          }
          if(p != null)
            GlobalFunctions.draw_pixmap(t.x, t.y, p);
          if(GlobalVariables.editing && GlobalVariables.show_links && t.controls != null)
            GlobalFunctions.draw_link(t.x, t.y, t.controls.x, t.controls.y, GlobalVariables.conf.linkcolor);
          return;
        }
        if(t.status == trkstat.ST_GREEN)
          i = 1;
        switch(t.direction) {
          case trkdir.W_E:
            p = t.signalx != 0 ? GlobalVariables.e_sigx_pmap[i] : GlobalVariables.e_sig_pmap[i];
            break;
          case trkdir.E_W:
            p = t.signalx != 0 ? GlobalVariables.w_sigx_pmap[i] : GlobalVariables.w_sig_pmap[i];
            break;
          case trkdir.N_S:
            p = t.signalx != 0 ? GlobalVariables.s_sigx_pmap[i] : GlobalVariables.s_sig_pmap[i];
            break;
          case trkdir.S_N:
            p = t.signalx != 0 ? GlobalVariables.n_sigx_pmap[i] : GlobalVariables.n_sig_pmap[i];
            break;
        }
      }
      if(p != null)
        GlobalFunctions.draw_pixmap(t.x, t.y, p);
      if(GlobalVariables.editing && GlobalVariables.show_links && t.controls != null)
        GlobalFunctions.draw_link(t.x, t.y, t.controls.x, t.controls.y, GlobalVariables.conf.linkcolor);
    }

    object FindIcon() {
      SignalInterpreterData interp = (SignalInterpreterData)_interpreterData;
      SignalAspect asp = interp._aspects;
      string[] p = null;
      int ix;
      string curState = "";

      if(string.IsNullOrEmpty(this._currentState) == false)
        curState = this._currentState;
      else if(this.status == trkstat.ST_GREEN)
        curState = wxPorting.T("green");
      else
        curState = wxPorting.T("red");

      while(asp != null) {
        if(curState.Equals(asp._name))
          break;
        asp = asp._next;
      }
      if(asp == null)
        return null;
      switch(this.direction) {
        case trkdir.W_E:
          p = asp._iconE;
          break;

        case trkdir.E_W:
          p = asp._iconW;
          break;

        case trkdir.N_S:
          p = asp._iconS;
          break;

        case trkdir.S_N:
          p = asp._iconN;
          break;
      }
      if(p == null || p.Length == 0)
        return null;
      if(_isFlashing) {
        if(p[_nextFlashingIcon] == null)
          _nextFlashingIcon = 0;

        string[] tmp = new string[p.Length - _nextFlashingIcon];
        Array.Copy(p, _nextFlashingIcon, tmp, 0, tmp.Length);
        p = tmp; // p = &p[_nextFlashingIcon];
      }
      if((ix = GlobalFunctions.get_pixmap_index(p[0])) < 0)
        return 0;
      return GlobalVariables.pixmaps[ix].pixels;
    }

    public void OnFlash() {
      SignalAspect asp;

      if(_interpreterData == null)
        return;
      if(string.IsNullOrEmpty(_currentState))
        return;

      SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      string[] p;

      for(asp = interp._aspects; asp != null; asp = asp._next)
        if(asp._name != null && asp._name.Equals(_currentState)) {
          int nxt = _nextFlashingIcon + 1;

          if(nxt >= Configuration.MAX_FLASHING_ICONS)
            nxt = 0;
          p = null;
          switch(this.direction) {
            case trkdir.W_E:
              p = asp._iconE;
              break;

            case trkdir.E_W:
              p = asp._iconW;
              break;

            case trkdir.N_S:
              p = asp._iconS;
              break;

            case trkdir.S_N:
              p = asp._iconN;
              break;
          }
          if(p == null || p[nxt] == null)
            nxt = 0;
          _nextFlashingIcon = nxt;
          GlobalFunctions.change_coord(this.x, this.y);
          break;
        }
    }
    public bool IsClear() {
      if(string.IsNullOrEmpty(this._currentState) == false) {
        if(_isShuntingSignal) {
          return wxPorting.T("yellow").Equals(this._currentState) == false;
        }
        return wxPorting.T("stop").Equals(GetAction()) == false;	// !Rask
      }
      return this.status == trkstat.ST_GREEN;
    }

    public string GetAspect() {
      if(string.IsNullOrEmpty(_currentState) == false)
        return _currentState;
      if(this.status == trkstat.ST_RED)
        return wxPorting.T("red");
      return wxPorting.T("green");
    }

    public string GetAction() {
      string name = GetAspect();
      SignalInterpreterData interp = (SignalInterpreterData)_interpreterData;
      SignalAspect asp;

      if(interp == null) {
        if(wxPorting.T("red").Equals(name))
          return wxPorting.T("stop");
        return wxPorting.T("proceed");
      }
      for(asp = interp._aspects; asp != null; asp = asp._next) {
        if((name != null) && name == asp._name && string.IsNullOrEmpty(asp._action) == false)
          return asp._action;
      }
      return wxPorting.T("proceed");	    // broken signal? maybe we should stop.
    }

    public void OnUpdate() {
      //	if(this.aspect_changed)
      //	    return;

      if(_interpreterData == null)
        return;

      SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      if(interp._onUpdate == null)
        return;

      interp._signal = this;
      GlobalVariables.expr_buff = string.Format(wxPorting.T("{0}::OnUpdate({1},{2})"), this.stateProgram, this.x, this.y);
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onUpdate);
    }

    public void OnClicked() {
      if(_interpreterData == null)
        return;

      SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
      if(interp._onClick == null)
        return;

      interp._signal = this;
      interp._mustBeClearPath = true;
      GlobalVariables.expr_buff = string.Format(wxPorting.T("%s::OnClicked(%d,%d)"), this.stateProgram, this.x, this.y);
      GlobalFunctions.Trace(GlobalVariables.expr_buff);
      interp.Execute(interp._onClick);
    }

    public void OnUnclear() {
      GlobalVariables.signals_changed = true;
      if(_interpreterData != null) {
        SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
        if(interp._onClick != null) {
          interp._signal = this;
          GlobalVariables.expr_buff = string.Format(wxPorting.T("%s::OnUnclear(%d,%d)"), this.stateProgram, this.x, this.y);
          GlobalFunctions.Trace(GlobalVariables.expr_buff);
          interp.Execute(interp._onClick);
          return;
        }
      }

      this.status = trkstat.ST_RED;
      SetAspect(wxPorting.T("red")); // _currentState = wxT("red");
      _nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }




    public void OnClear() {
      GlobalVariables.signals_changed = true;
      if(_interpreterData != null) {
        SignalInterpreterData interp = new SignalInterpreterData((SignalInterpreterData)_interpreterData);
        if(interp._onCleared != null) {
          interp._signal = this;
          interp._mustBeClearPath = true;
          GlobalVariables.expr_buff = string.Format(wxPorting.T("%s::OnClear(%d,%d)"), this.stateProgram, this.x, this.y);
          GlobalFunctions.Trace(GlobalVariables.expr_buff);
          interp.Execute(interp._onCleared);
          return;
        }
      }

      this.status = trkstat.ST_GREEN;
      _currentState = wxPorting.T("green");
      _nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }

    public void SetAspect(string aspect) {
      if(string.IsNullOrEmpty(_currentState) || _currentState.Equals(aspect)) {
        GlobalVariables.signals_changed = true;
        GlobalFunctions.change_coord(this.x, this.y);
        this.aspect_changed = true;
      }

      _currentState = aspect;
      _nextFlashingIcon = 0;	    // in case new aspect is not flashing
    }


  }
}