 /*	Main.cpp - Created by Giampiero Caprino
 
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
using wx;

namespace Traincontroller2 {
  public class optList {
    public String name;
    public object ptr;
  }

  public partial class Globals {
    public static String program_name;
    public static String program_home;
    public static String savedGame;

    ///////////////////////////////////////////////////////////////////////

    /// TODO ~~~ ERIK: Re-enable this lines, if they're needed
    //DECLARE_APP(Traindir)

    //IMPLEMENT_APP(Traindir)

    public static Traindir traindir;

    public static int gnErrors = 0;

    public static int gbTrkFirst = 0;	    // show .trk before .zip in dialogs

    public static FileDialog gFileDialog = null;
    public static FileDialog gScriptFileDialog = null;
    public static FileDialog gSaveGameFileDialog = null;
    public static FileDialog gSaveLayoutFileDialog = null;
    public static FileDialog gSaveImageFileDialog = null;
    public static FileDialog gSaveTextFileDialog = null;
    public static FileDialog gSaveHtmlFileDialog = null;
    public static FileDialog gOpenImageDialog = null;
    public static SelectPowerDialog gSelectPowerDialog = null;

    public static FileOption alert_sound = new FileOption(wxPorting.T("EntrySound"),
                                wxPorting.T("Path to sound file for alert notifications"),
                                wxPorting.T("Environment"),
                                wxPorting.T("C:\\Windows\\Media\\ringout.wav"));
    public static FileOption entry_sound = new FileOption(wxPorting.T("AlertSound"),
                                wxPorting.T("Path to sound file for train entry"),
                                wxPorting.T("Environment"),
                                wxPorting.T("C:\\Windows\\Media\\notify.wav"));
    public static wxSound pAlertSound;
    public static wxSound pEntrySound;

    public static int server_port = 8900;
    public static int lastModTime = 1;    // incremented when data for listeners is updated

    public static int nSounds;
    public static wxSound[] soundTable = new wxSound[Configuration.MAX_SOUNDS];
    public static String[] soundNames = new string[Configuration.MAX_SOUNDS];

    public static optList[] opt_list = new optList[] {
  	new optList() { name = wxPorting.T("fullstatus"), ptr = terse_status },
  	new optList() { name = wxPorting.T("statusontop"), ptr = status_on_top },
  	new optList() { name = wxPorting.T("alertsound"), ptr = beep_on_alert },
  	new optList() { name = wxPorting.T("entersound"), ptr = beep_on_enter },
  	new optList() { name = wxPorting.T("viewspeed"), ptr = show_speeds },
  	new optList() { name = wxPorting.T("autolink"), ptr = auto_link },
  	new optList() { name = wxPorting.T("linktoleft"), ptr = link_to_left },
  	new optList() { name = wxPorting.T("showgrid"), ptr = show_grid },
  	new optList() { name = wxPorting.T("showblocks"), ptr = show_blocks },
  	new optList() { name = wxPorting.T("showsecs"), ptr = show_seconds },
  	new optList() { name = wxPorting.T("standardsigs"), ptr = signal_traditional },
  	new optList() { name = wxPorting.T("hardcounters"), ptr = hard_counters },
  	new optList() { name = wxPorting.T("showlinks"), ptr = show_links },
  	new optList() { name = wxPorting.T("showscripts"), ptr = show_scripts },
  	new optList() { name = wxPorting.T("saveprefs"), ptr = save_prefs },
  	new optList() { name = wxPorting.T("ShowTrkFirst"), ptr = gbTrkFirst },
  	new optList() { name = wxPorting.T("traceScript"), ptr = trace_script },
 	new optList() { name = wxPorting.T("ShowIcons"), ptr = show_icons },
 	new optList() { name = wxPorting.T("RealTimeData"), ptr = use_real_time },
 	new optList() { name = wxPorting.T("EnableTraining"), ptr = enable_training },
 	new optList() { name = wxPorting.T("RandomDelays"), ptr = random_delays },
 	new optList() { name = wxPorting.T("PlaySynchronously"), ptr = play_synchronously },
 	new optList() { name = wxPorting.T("ServerPort"), ptr = server_port },
         new optList() { name = wxPorting.T("TrainNames"), ptr = draw_train_names },
         new optList() { name = wxPorting.T("NoTrainNamesColors"), ptr = no_train_names_colors },
 	null
 };

    internal static void start_server_thread() {
      throw new NotImplementedException();
    }

    internal static void kill_server_thread() {
      throw new NotImplementedException();
    }

    internal static bool wxStricmp(string p, string p_2) {
      throw new NotImplementedException();
    }

    internal static void exit(int p) {
      throw new NotImplementedException();
    }
  }

  public class Traindir : App {
    public MainFrame m_frame;

    public TDProject m_project;

    public int m_nOldSimulations;
    public String[] m_oldSimulations = new string[Configuration.MAX_OLD_SIMULATIONS];

    public bool m_ignoreTimer;
    public int m_timeSlice;
    public int m_timeSliceCount;

    // colors for the time table view
    public Colour m_colorCanceled;
    public Colour m_colorReady;
    public Colour m_colorArrived;
    public Colour m_colorDerailed;
    public Colour m_colorWaiting;
    public Colour m_colorRunning;
    public Colour m_colorStopped;

    public bool OnInit() {
      throw new NotImplementedException();
//      Globals.traindir = this;

//      Globals.srand(Globals.time(0));

//      wxPorting.wxInitAllImageHandlers();

//      if(String.IsNullOrEmpty(wxPorting.wxGetenv(wxPorting.T("TDHOME"))) == false)
//        wxPorting.wxSetWorkingDirectory(wxPorting.wxGetenv(wxPorting.T("TDHOME")));

//      m_project = null;
//      m_nOldSimulations = 0;

//      m_colorCanceled = new wx.Colour(64, 64, 64);
//      m_colorReady = wx.Colour.wxBLUE;
//      m_colorArrived = wx.Colour.wxGREEN;
//      m_colorDerailed = wx.Colour.wxRED;
//      m_colorWaiting = wx.Colour.wxLIGHT_GREY;
//      m_colorRunning = wx.Colour.wxBLACK;
//      m_colorStopped = new wx.Colour(0, 0, 128);// dark blue

//      //
//      //  Load the preferences before we create the main frame,
//      //  since we have to decide which locale to use before
//      //  creating the menus.
//      //

//      LoadPreferences();

//      Globals.fonts.AddFont(Globals.gFontSizeSmall, FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL, 0);
//      Globals.fonts.AddFont(Globals.gFontSizeBig, FontFamily.wxSWISS, wx.FontStyle.wxNORMAL, FontWeight.wxNORMAL, 0);

//      Globals.program_name = String.Format(wxPorting.T("Train Director %s"), Globals.version);

//      if(Globals.argc > 1 && !Globals.wxStrcmp(Globals.argv[1], wxPorting.T("-server"))) {
//        Globals.server_mode();
//        return true;
//      }
//      m_frame = new MainFrame(Globals.program_name);
//      m_frame.SetSize(900, 600);
//      m_frame.m_app = this;

//      m_timeSliceCount = 0;
//      m_timeSlice = 10;
//      m_ignoreTimer = true;

//      Globals.init_tool_layout();

//      LoadState();

//#if __WXMAC__
//#else
//      if(string.IsNullOrEmpty(Globals.entry_sound._sValue.empty())) {
//        Globals.pEntrySound = new wxSound();
//        Globals.pEntrySound.Create(Globals.entry_sound._sValue);
//      }
//      if(string.IsNullOrEmpty(Globals.alert_sound._sValue.empty())) {
//        Globals.pAlertSound = new wxSound();
//        Globals.pAlertSound.Create(Globals.alert_sound._sValue);
//      }
//#endif

//      m_frame.Finalize1();
//      m_frame.Icon = new Icon(wxPorting.T("aaaTD_ICON"));
//      m_frame.Show(true);

//      Globals.ShowWelcomePage();

//      Globals.start_server_thread();

//      if(Globals.user_name._sValue.Length > 0) {
//        Globals.bstreet_login();
//      }

//      if(Globals.argc > 1) {
//        String filename = new string(Globals.argv[1]);
//        OpenFile(filename, false);
//      }
//      wxPorting.wxHandleFatalExceptions(false);
//      return true;
    }

    //
    //
    //

    ~Traindir() {
      Globals.kill_server_thread();

      if(m_project != null)
        Globals.delete(m_project);

      Globals.free_tool_layout();
      Globals.clean_pixmap_cache();
      Globals.free_pixmaps();
    }

    //
    //	When we need to panic, we cannot assume that
    //	our dynamic memory area is still consistent.
    //	Therefore, write to stderr the message,
    //	so that if the message box fails, we at least
    //	have a chance to see the message on the console.
    //

    public void Panic() {
#if wxUSE_UNICODE
 	fprintf(stderr, "%sn", (string ) wxSafeConvertWX2MB(alert_msg));
#else
      Globals.fprintf(Globals.stderr, "%sn", Globals.alert_msg);
#endif
      wx.MessageDialog.MessageBox(Globals.alert_msg);
      Globals.exit(1);
    }


    //
    //
    //

    public void OnFatalException() {
      Panic();
    }

    //
    //
    //

    public void GetUserDir(String path) {
      String env;
      if(string.IsNullOrEmpty((env = wxPorting.wxGetenv(wxPorting.T("TDHOME")))))
        env = wxPorting.wxGetenv(wxPorting.T("HOME"));
      if(string.IsNullOrEmpty(env) == false) {
        path = env;
#if WIN32
#else
 	    path += wxPorting.T("/");
#endif
        return;
      }
#if WIN32
      path = wxPorting.T("C:/Temp/");
#else
 	path = wxPorting.T("/tmp/");
#endif
      if(!wxPorting.wxDirExists(path)) {
        if(!wxPorting.wxMkdir(path)) {
          String msg;
          msg = String.Format(wxPorting.L("Cannot create directory '%s'. Try creating it manually."), path);
          wx.MessageDialog.MessageBox(msg, wxPorting.L("Error"));
          return;
        }
      }
    }

    //
    //
    //

    public void GetAppDir(String path) {
      path = wxPorting.T("");
    }

    //
    //
    //



    /*	This is called BEFORE setting up the user interface.
     *	As such, it must not call drawing routines!
     *	This is because the locale must be set before creating
     *	menus, buttons and dialogs, so that we can use the
     *	localized strings.
     */

    public void LoadPreferences() {
      TConfig state = new TConfig();
      String str = "";
      int i;

      GetUserDir(str);
      str += wxPorting.T(Configuration.STATE_FILE_NAME);
      if(!state.Load(str))
        return;
      if(!state.FindSection(wxPorting.T("Preferences")))
        return;
      for(i = 0; String.IsNullOrEmpty(Globals.opt_list[i].name) == false; ++i) {
        int tmpVal;
        state.GetInt(Globals.opt_list[i].name, out tmpVal);
        Globals.opt_list[i].ptr = tmpVal;
      }
      if(!state.GetString(wxPorting.T("locale"), out str))
        str = wxPorting.T(".en");
      Globals.locale_name = String.Copy(str);
      Globals.load_localized_strings(Globals.locale_name);
      state.Get(Globals.searchPath);
    }

    public static Colour ParseColor(String str) {
      throw new NotImplementedException();
      //if(str == wxPorting.T("red")) return wx.Colour.wxRED;
      //if(str == wxPorting.T("blue")) return wx.Colour.wxBLUE;
      //if(str == wxPorting.T("green")) return wx.Colour.wxGREEN;
      //if(str == wxPorting.T("black")) return wx.Colour.wxBLACK;
      //if(str == wxPorting.T("white")) return wx.Colour.wxWHITE;
      //if(str == wxPorting.T("cyan")) return wx.Colour.wxCYAN;
      //if(str == wxPorting.T("lightgray")) return wx.Colour.wxLIGHT_GREY;

      //byte r, g, b;
      //String s = str;
      //String p;
      //r = (byte)(Globals.wxStrtol(s, ref p, 10) & 0xFF);
      //g = (byte)(Globals.wxStrtol(p, ref p, 10) & 0xFF);
      //b = (byte)(Globals.wxStrtol(p, ref p, 10) & 0xFF);
      //return new wx.Colour(r, g, b);
    }

    //
    //  Reload the state of the previous session
    //
    //  If there was no previous project,
    //  the values are loaded from the default
    //  state file, "C:/td3.ini".
    //  But if a "Globals.traindir.lastproject" entry was
    //  found in the default state file, then the
    //  state is loaded from that file.
    //  This allows different states depending on
    //  which project is currently opened.
    //

    public void LoadState() {
    //  TConfig state;
    //  String prjName;
    //  String str;
    //  int i;

    //  GetUserDir(str);
    //  str += wxPorting.T(Configuration.STATE_FILE_NAME);
    //  if(!state.Load(str))
    //    return;
    //  if(state.FindSection(wxPorting.T("Skin1"))) {	    // todo: get skin names from preference file, to
    //    wx.Colour col;
    //    TDSkin skin = new TDSkin();
    //    skin.name = String.Copy(wxPorting.T("Skin1"));
    //    skin.next = Globals.skin_list;
    //    Globals.skin_list = skin;
    //    if(state.GetString(wxPorting.T("background"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.background = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("free_track"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.free_track = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("reserved_track"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.reserved_track = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("reserved_shunting"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.reserved_shunting = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("occupied_track"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.occupied_track = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("working_track"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.working_track = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("outline"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.outline = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //    if(state.GetString(wxPorting.T("text"), out prjName)) {
    //      col = ParseColor(prjName);
    //      skin.text = (col.Red << 16) | (col.Green << 8) | col.Blue;
    //    }
    //  }
    //  if(state.FindSection(wxPorting.T("Preferences"))) {
    //    String prjName = "";
    //    if(!state.GetString(wxPorting.T("skin"), out prjName))
    //      prjName = wxPorting.T("default");
    //    Globals.curSkin = Globals.skin_list;
    //    while(Globals.curSkin != null) {
    //      if(Globals.wxStrcmp(Globals.curSkin.name, prjName) == 0)
    //        break;
    //      Globals.curSkin = Globals.curSkin.next;
    //    }
    //    if(Globals.curSkin == null)	    // impossible
    //      Globals.curSkin = Globals.skin_list;
    //  }

    //  state.Get(Globals.http_server_enabled);
    //  state.Get(Globals.http_server_port);
    //  state.Get(Globals.user_name);

    //  if(!state.FindSection(wxPorting.T("MainView")))
    //    goto done;

    //  if(state.GetInt(wxPorting.T("OldSimulations"), out m_nOldSimulations)) {
    //    String buff;

    //    if((int)m_nOldSimulations > Configuration.MAX_OLD_SIMULATIONS)	// safety check
    //      m_nOldSimulations = Configuration.MAX_OLD_SIMULATIONS;
    //    for(i = 0; i < m_nOldSimulations; ++i) {
    //      buff = String.Format(wxPorting.T("simulation%d"), i + 1);
    //      state.GetString(buff, out m_oldSimulations[i]);
    //    }
    //  }
    //  state.Get(Globals.entry_sound);
    //  state.Get(Globals.alert_sound);

    //  //  Colors for the time table view

    //  if(state.GetString(wxPorting.T("colorCanceled"), out prjName)) {
    //    m_colorCanceled = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorReady"), out prjName)) {
    //    m_colorReady = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorArrived"), out prjName)) {
    //    m_colorArrived = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorDerailed"), out prjName)) {
    //    m_colorDerailed = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorWaiting"), out prjName)) {
    //    m_colorWaiting = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorRunning"), out prjName)) {
    //    m_colorRunning = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorStopped"), out prjName)) {
    //    m_colorStopped = ParseColor(prjName);
    //  }
    //  if(state.GetString(wxPorting.T("colorBg"), out prjName)) {
    //    wx.Colour colorBg = ParseColor(prjName);
    //    Globals.colortable[14][0] = colorBg.Red;
    //    Globals.colortable[14][1] = colorBg.Green;
    //    Globals.colortable[14][2] = colorBg.Blue;
    //    Globals.fieldcolors[(int)fieldcolor.COL_BACKGROUND] = 12;
    //  }

    //  // layout's font sizes

    //  state.GetInt(wxPorting.T("FontSizeSmall"), out Globals.gFontSizeSmall);
    //  state.GetInt(wxPorting.T("FontSizeBig"),  out Globals.gFontSizeBig);

    //  if(state.GetString(wxPorting.T("project"), out prjName)) {
    //    m_project = new TDProject();
    //    m_project.m_name = prjName;
    //  }
    //  if(m_project == null) {
    //    m_project = new TDProject();
    //    m_project.m_name = wxPorting.T("Untitled");
    //  } else {
    //    ///	    state.Close();

    //    //  Reload the state from the previous project

    //    ///	    if(!state.Load(m_project.m_name + ".tdp")) {
    //    ///		state.Load(STATE_FILE_NAME);
    //    ///	    }
    //  }
    //done: m_frame.LoadState(wxPorting.T("MainView"), state);
    }


    public void save_rgb(TConfig state, string name, int rgb) {
      String buff;

      buff = String.Format(wxPorting.T("%d %d %d"), (rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF);
      state.PutString(name, buff);
    }


    //
    //
    //

    public void SaveState() {
      //TConfig state;
      //String str;
      //optList opt;

      //GetUserDir(str);
      //str += wxPorting.T(Configuration.STATE_FILE_NAME);
      //if(state.Save(str)) {
      //  m_frame.SaveState(wxPorting.T("MainView"), state);
      //  int i;
      //  String buff;
      //  String buff2;

      //  state.PutInt(wxPorting.T("OldSimulations"), m_nOldSimulations);
      //  for(i = 0; i < m_nOldSimulations; ++i) {
      //    buff2 = String.Format(wxPorting.T("simulation%d"), i + 1);
      //    state.PutString(buff2, m_oldSimulations[i]);
      //  }
      //  if(!Globals.entry_sound._sValue.empty())
      //    state.Put(Globals.entry_sound);
      //  if(!Globals.alert_sound._sValue.empty())
      //    state.Put(Globals.alert_sound);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorCanceled.Red,
      //    m_colorCanceled.Green, m_colorCanceled.Blue);
      //  state.PutString(wxPorting.T("colorCanceled"), buff);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorReady.Red,
      //    m_colorReady.Green, m_colorReady.Blue);
      //  state.PutString(wxPorting.T("colorReady"), buff);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorArrived.Red,
      //    m_colorArrived.Green, m_colorArrived.Blue);
      //  state.PutString(wxPorting.T("colorArrived"), buff);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorDerailed.Red,
      //    m_colorDerailed.Green, m_colorDerailed.Blue);
      //  state.PutString(wxPorting.T("colorDerailed"), buff);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorWaiting.Red,
      //    m_colorWaiting.Green, m_colorWaiting.Blue);
      //  state.PutString(wxPorting.T("colorWaiting"), buff);

      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorRunning.Red,
      //    m_colorRunning.Green, m_colorRunning.Blue);
      //  state.PutString(wxPorting.T("colorRunning"), buff);
      //  buff = String.Format(wxPorting.T("%d %d %d"), m_colorStopped.Red,
      //    m_colorStopped.Green, m_colorStopped.Blue);
      //  state.PutString(wxPorting.T("colorStopped"), buff);
      //  if(Globals.fieldcolors[(int)fieldcolor.COL_BACKGROUND] == 12) {
      //    buff = String.Format(wxPorting.T("%d %d %d"), Globals.colortable[14][0],
      //      Globals.colortable[14][1], Globals.colortable[14][2]);
      //    state.PutString(wxPorting.T("colorBg"), buff);
      //  }

      //  state.PutInt(wxPorting.T("FontSizeSmall"), Globals.gFontSizeSmall);
      //  state.PutInt(wxPorting.T("FontSizeBig"),  Globals.gFontSizeBig);

      //  if(Globals.save_prefs) {
      //    state.StartSection(wxPorting.T("Preferences"));
      //    for(opt = Globals.opt_list[0]; String.IsNullOrEmpty(opt.name) == false; ++opt) {
      //      state.PutInt(opt.name, (int)opt.ptr);
      //    }
      //    state.Put(Globals.http_server_enabled);
      //    state.Put(Globals.http_server_port);
      //    state.Put(Globals.user_name);

      //    state.PutString(wxPorting.T("locale"), Globals.locale_name);
      //    state.PutString(wxPorting.T("skin"), Globals.curSkin.name);
      //    state.Put(Globals.searchPath);
      //    TDSkin skin;
      //    for(skin = Globals.skin_list; skin != null; skin = skin.next) {
      //      if(skin == Globals.defaultSkin)
      //        continue;
      //      state.StartSection(skin.name);
      //      save_rgb(state, wxPorting.T("free_track"), skin.free_track);
      //      save_rgb(state, wxPorting.T("reserved_track"), skin.reserved_track);
      //      save_rgb(state, wxPorting.T("reserved_shunting"), skin.reserved_shunting);
      //      save_rgb(state, wxPorting.T("occupied_track"), skin.occupied_track);
      //      save_rgb(state, wxPorting.T("working_track"), skin.working_track);
      //      save_rgb(state, wxPorting.T("background"), skin.background);
      //      save_rgb(state, wxPorting.T("outline"), skin.outline);
      //      save_rgb(state, wxPorting.T("text"), skin.text);
      //    }
      //  }
      //  state.Close();
      //}
    }

    //
    //
    //

    public void OnOpenFile() {
      String types =
          wxPorting.T("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|All Files (*.*)|*.*");

      if(Globals.gFileDialog == null) {
        if(Globals.gbTrkFirst != null)
          types = wxPorting.T("Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|Traindir Scenarios (*.zip)|*.zip|All Files (*.*)|*.*");
        Globals.gFileDialog = new FileDialog(m_frame, wxPorting.L("Open a file"), wxPorting.T(""), wxPorting.T(""),
      types,
      WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR);
      }
      Globals.gFileDialog.Path = (Globals.current_project);
      if(Globals.gFileDialog.ShowModal() != ShowModalResult.OK)
        return;

      String path = Globals.gFileDialog.Path;
      OpenFile(path);
    }

    //
    //
    //
    public void OpenFile(String path) {
      OpenFile(path, false);
    }

    public void OpenFile(String path, bool restore)	// RECURSIVE
    {
      string buff;

      Globals.gLogger.InstallLog();
      Globals.gnErrors = 0;
      wxFileName fname = new wxFileName(path);
      wxPorting.wxSetWorkingDirectory(fname.GetPath());
      String ext = string.Copy(fname.GetExt());
      if(!ext.CmpNoCase(wxPorting.T("zip"))) {
        Globals.FreeFileList();
        String trkName = string.Copy(fname.GetName());
        trkName += wxPorting.T(".trk");
        Globals.ReadZipFile(path);
        buff = String.Format( wxPorting.T("%s %s"), restore ? wxPorting.T("load") : wxPorting.T("open"), trkName);
        Globals.trainsim_cmd(buff);
        Globals.current_project = path;
      } else if(!ext.CmpNoCase(wxPorting.T("trk"))) {
        Globals.FreeFileList();
        buff = String.Format( wxPorting.T("%s %s"), restore ? wxPorting.T("load") : wxPorting.T("open"), path);
        Globals.trainsim_cmd(buff);
        Globals.current_project = path;
      } else if(!ext.CmpNoCase(wxPorting.T("tdp"))) {
        Globals.FreeFileList();
        buff = String.Format( wxPorting.T("%s %s"), restore ? wxPorting.T("load") : wxPorting.T("puzzle"), path);
        Globals.trainsim_cmd(buff);
        Globals.current_project = path;
      } else if(!ext.CmpNoCase(wxPorting.T("sav"))) {
        Globals.FreeFileList();
        Globals.savedGame = path;
        buff = String.Format( wxPorting.T("restore %s"), path);
        buff = buff.Substring(0, Globals.wxStrlen(buff) - 4);	 // remove extension
        Globals.trainsim_cmd(buff);
      } else {
        wx.MessageDialog.MessageBox(wxPorting.L("This file type is not recognized."));
        Globals.gLogger.UninstallLog();
        return;
      }

      int pg = m_frame.m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0)
        m_frame.m_top.Selection = (pg);
      if(m_frame.m_trainInfo != null)
        m_frame.m_trainInfo.Update(null);

      Globals.gLogger.UninstallLog();

      //  Add newly opened file to list of old files

      int i;

      for(i = 0; i < m_nOldSimulations; ++i) {
        if(path == m_oldSimulations[i]) {
          while(i > 0) {
            m_oldSimulations[i] = m_oldSimulations[i - 1];
            --i;
          }
          m_oldSimulations[0] = path;
          return;
        }
      }
      for(i = Configuration.MAX_OLD_SIMULATIONS - 1; i > 0; --i)
        m_oldSimulations[i] = m_oldSimulations[i - 1];
      m_oldSimulations[0] = path;
      if(m_nOldSimulations < Configuration.MAX_OLD_SIMULATIONS)
        ++m_nOldSimulations;
    }

    //
    //
    //

    public bool OpenMacroFileDialog(String buff) {
      if(Globals.gFileDialog == null) {
        Globals.gFileDialog = new FileDialog(m_frame, _("Open a file"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
      WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR);
      }
      if(Globals.gFileDialog.ShowModal() != ShowModalResult.OK)
        return false;

      buff = String.Copy(Globals.gFileDialog.Path);
      return true;
    }

    //
    //
    //

    public bool SaveTextFileDialog(String buff) {
      if(Globals.gSaveTextFileDialog == null) {
        Globals.gSaveTextFileDialog = new FileDialog(m_frame, wxPorting.L("Save file"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("Text file (*.txt)|*.txt|All Files (*.*)|*.*"),
      WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
      }
      if(Globals.gSaveTextFileDialog.ShowModal() != ShowModalResult.OK)
        return false;
      buff = String.Copy( Globals.gSaveTextFileDialog.Path);
      return true;
    }

    //
    //
    //

    public bool SaveHtmlFileDialog(String buff) {
      if(Globals.gSaveHtmlFileDialog == null) {
        Globals.gSaveHtmlFileDialog = new FileDialog(m_frame, wxPorting.L("Save file"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("HTML file (*.htm)|*.htm|All Files (*.*)|*.*"),
      WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
      }
      if(Globals.gSaveHtmlFileDialog.ShowModal() != ShowModalResult.OK)
        return false;
      buff = String.Copy( Globals.gSaveHtmlFileDialog.Path);
      return true;
    }

    //
    //
    //

    public bool OpenImageDialog(String buff) {
      if(Globals.gOpenImageDialog == null) {
        Globals.gOpenImageDialog = new FileDialog(m_frame, wxPorting.L("Open image"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("Icon (*.xpm)|*.xpm|All Files (*.*)|*.*"),
      WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR);
      }
      if(buff.Length > 0)
        Globals.gOpenImageDialog.Path = (buff);
      if(Globals.gOpenImageDialog.ShowModal() != ShowModalResult.OK)
        return false;
      buff = String.Copy( Globals.gOpenImageDialog.Path);
      return true;
    }

    //
    //
    //

    public bool OpenScriptDialog(String buff) {
      if(Globals.gScriptFileDialog == null) {
        Globals.gScriptFileDialog = new FileDialog(m_frame, wxPorting.L("Open a script file"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("Traindir Script (*.tds)|*.tds|All Files (*.*)|*.*"),
      WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR);
      }
      Globals.gScriptFileDialog.Path = (buff);
      if(Globals.gScriptFileDialog.ShowModal() != ShowModalResult.OK)
        return false;

      buff = String.Copy( Globals.gScriptFileDialog.Path);
      return true;
    }

    //
    //
    //

    public bool OpenSelectPowerDialog() {
      if(Globals.gSelectPowerDialog == null) {
        Globals.gSelectPowerDialog = new SelectPowerDialog(m_frame);
      }
      if(Globals.gSelectPowerDialog.ShowModal() != ShowModalResult.OK)
        return false;
      return true;
    }

    //
    //
    //

    public void OnSaveGame() {
      string buff;

      if(!Globals.can_save_game()) {
        Globals.alert_dialog(wxPorting.T("Saving now will lead to an invalid file. Please continue the simulation for a bit and try again."));
        return;
      }
      if(Globals.gSaveGameFileDialog == null) {
        Globals.gSaveGameFileDialog = new FileDialog(m_frame, _("Save simulation file"), wxPorting.T(""), wxPorting.T(""),
      wxPorting.T("Saved simulation (*.sav)|*.sav|All Files (*.*)|*.*"),
      WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
      }
      if(Globals.gSaveGameFileDialog.ShowModal() != ShowModalResult.OK)
        return;
      Globals.savedGame = Globals.gSaveGameFileDialog.Path;
      buff = String.Format( wxPorting.T("savegame %s"), Globals.savedGame);
      Globals.trainsim_cmd(buff);
    }

    //
    //
    //

    public void OnRestore() {
      if(Globals.savedGame.length() == 0) {
        OnRestart();
        return;
      }
      if(Globals.ask(wxPorting.L("Are you sure you want to restorenthe simulation to its saved state?")) != AskAnswer.ANSWER_YES)
        return;
      OpenFile(Globals.savedGame);
    }

    public bool SaveHtmlPage(HtmlPage page) {
      throw new NotImplementedException();
      //string fname = "";

      //if(!SaveHtmlFileDialog(fname))
      //  return false;

      //wxFFile file;

      //if(!file.Open(fname, wxPorting.T("w"))) {
      //  Globals.do_alert(wxPorting.T("Open file failed."));
      //  return false;
      //}
      //file.Write(page.content);
      //file.Close();
      //return true;
    }


    public bool SavePerfText() {
      throw new NotImplementedException();
      //string fname = "";

      //if(!SaveTextFileDialog(fname))
      //  return false;

      //wxFFile file;
      //HtmlPage page = new HtmlPage(wxPorting.T(""));

      //if(!file.Open(fname, wxPorting.T("w"))) {
      //  Globals.do_alert(wxPorting.T("Open file failed."));
      //  return false;
      //}
      //Globals.save_schedule_status(page);
      //file.Write(page.content);
      //file.Close();
      //return true;
    }

    public void Error(String msg) {
      ++Globals.gnErrors;
    }

    //
    //
    //

    public void layout_error(String msg) {
      m_frame.m_alertList.AddLine(msg);
    }

    //
    //
    //

    public void AddAlert(String msg) {
      string buff;

      buff = String.Format( wxPorting.T("%s: %s"), Globals.format_time(Globals.current_time), msg);
      Globals.alerts.Lock();
      Globals.alerts.AddLine(buff);
      Globals.alerts.NotifyListeners();
      Globals.alerts.Unlock();
      //	m_frame.m_alertList.AddLine(buff);
    }

    //
    //
    //

    public void ClearAlert() {
      //	m_frame.m_alertList.DeleteAllItems();
      Globals.alerts.Lock();
      Globals.alerts.Clear();
      Globals.alerts.NotifyListeners();
      Globals.alerts.Unlock();
    }

    //
    //
    //

    public void end_layout_error() {
    }

    //
    //
    //

    public void SetTimeSlice(int msec) {
      if(msec == 0)
        m_ignoreTimer = true;
      else {
        m_ignoreTimer = false;
        m_timeSlice = msec;
      }
    }

    //
    //
    //

    public wxCriticalSection cmdLocker;
    public String[] commands = new String[10];
    public int nCommands;

    public void post_command(String cmd) {
      cmdLocker.Enter();
      if(nCommands < 10)
        commands[nCommands++] = String.Copy(cmd);
      cmdLocker.Leave();
    }

    public void OnTimer() {
      String cmd;
      do {
        cmd = null;
        cmdLocker.Enter();
        if(nCommands > 0) {
          cmd = commands[0];
          for(int i = 0; i < nCommands - 1; ++i)
            commands[i] = commands[i + 1];
          --nCommands;
        }
        cmdLocker.Leave();
        if(String.IsNullOrEmpty(cmd) == false) {
          Globals.do_command(cmd, false);
        }
      } while(String.IsNullOrEmpty(cmd) == false);
      if(++m_timeSliceCount >= m_timeSlice) {
        m_timeSliceCount = 0;
        if(m_ignoreTimer) {
          Globals.flash_signals();
          Globals.repaint_all();
          return;
        }
        Globals.click_time();
      }
    }

    //
    //
    //

    public void OnRecent() {
    }

    //
    //
    //

    //public void OnRestore(string name)
    //{
    //}

    //
    //
    //

    public void OnEdit() {
      if(Globals.editing)
        Globals.trainsim_cmd(wxPorting.T("noedit"));
      else
        Globals.trainsim_cmd(wxPorting.T("edit"));
    }

    //
    //
    //

    public void OnNewTrain() {
      Globals.trainsim_cmd(wxPorting.T("newtrain"));
    }

    //
    //
    //

    public void OnItinerary() {
      Globals.trainsim_cmd(wxPorting.T("edititinerary"));
    }

    //
    //
    //

    public bool OnSaveLayout() {
      throw new NotImplementedException();
      //string buff;
      //String p;

      //if( Globals.gSaveLayoutFileDialog == null) {
      //   Globals.gSaveLayoutFileDialog = new FileDialog(m_frame, wxPorting.L("Save Layout"), wxPorting.T(""), wxPorting.T(""),
      //wxPorting.T("Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
      //WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
      //}
      // Globals.gSaveLayoutFileDialog.Path = Globals.current_project;
      //if( Globals.gSaveLayoutFileDialog.ShowModal() != ShowModalResult.OK)
      //  return false;
      //buff = String.Format( wxPorting.T("save %s"),  Globals.gSaveLayoutFileDialog.Path);
      //p = buff + Globals.wxStrlen(buff) - 4;
      //if(!Globals.wxStricmp(p, wxPorting.T(".trk")))
      //  *p = 0;
      //Globals.trainsim_cmd(buff);
      //return true;
    }

    //
    //
    //

    public void OnPreferences() {
      Globals.trainsim_cmd(wxPorting.T("options"));
    }

    //
    //
    //

    public void OnNewLayout() {
      if(Globals.ask(wxPorting.L("This will delete the current layout.nAre you sure you want to continue?")) != AskAnswer.ANSWER_YES)
        return;
      Globals.trainsim_cmd(wxPorting.T("new"));
    }

    //
    //
    //

    public void OnInfo() {
      Globals.trainsim_cmd(wxPorting.T("info"));
    }

    //
    //
    //

    public void OnStartStop() {
      Globals.trainsim_cmd(wxPorting.T("run"));
    }

    //
    //
    //

    public void OnGraph() {
      Globals.trainsim_cmd(wxPorting.T("graph"));
    }

    //
    //
    //

    public void OnRestart() {
      Globals.trainsim_cmd(wxPorting.T("t0"));
    }

    //
    //
    //

    public void OnFast() {
      Globals.trainsim_cmd(wxPorting.T("fast"));
    }

    //
    //
    //

    public void OnSlow() {
      Globals.trainsim_cmd(wxPorting.T("slow"));
    }

    //
    //
    //

    public void OnStationSched() {
      Globals.trainsim_cmd(wxPorting.T("stationsched"));
    }

    //
    //
    //

    public void OnSetGreen() {
      Globals.trainsim_cmd(wxPorting.T("greensigs"));
    }

    //
    //
    //

    public void OnSkipToNext() {
      Globals.trainsim_cmd(wxPorting.T("skip"));
    }

    //
    //
    //

    public void OnPerformance() {
      Globals.trainsim_cmd(wxPorting.T("performance"));
    }

    //
    //
    //

    public void BuildWelcomePage(HtmlPage page) {
#if WIN32
#else
 	page.Add(wxPorting.T("<font size=-1>n"));
#endif
      page.Add(wxPorting.T("<table bgcolor=#60C060 width=100% cellspacing=3><tr><td>n"));
      page.Add(wxPorting.T("<font size=+2 color=#FFFFFF>Welcome to "));
      page.Add(Globals.program_name);
      page.Add(wxPorting.T("</font>n"));
      page.Add(wxPorting.T("</td></tr></table>n"));
      page.Add(wxPorting.T("<table width=\"100%\"><tr><td align=left valign=top>"));
      page.Add(wxPorting.T("Copyright 2000 - 2014 Giampiero Caprino<br>Backer Street Software, Sunnyvale, CA, USA"));
      page.Add(wxPorting.T("</td><td align=right valign=top>"));
      page.AddLine(wxPorting.T("Train Director is free software, released under the GNU General Public License 2"));
      page.AddLine(wxPorting.T("Built using the wxWidgets portable framework"));
      page.Add(wxPorting.T("</td></tr></table>n"));
      page.Add(wxPorting.T("<hr><br><br>n"));

      //	page.Add(wxPorting.T("<table><tr><td valign=top align=left>n"));
      page.AddCenter();
      page.AddLine(wxPorting.L("You recently played the following simulations:<br><br>"));
      int i;
      string buff;

      for(i = 0; i < m_nOldSimulations; ++i) {
        buff = String.Format(
      wxPorting.T("<a href=\"open:%s\">%s</a><br>"),
      m_oldSimulations[i], m_oldSimulations[i]);
        page.AddLine(buff);
      }
      //	page.Add(wxPorting.T("</table>n"));
      buff = String.Format(
          wxPorting.T("<br><br><a href=\"open:\">%s...</a><br>"),
          wxPorting.L("Open another simulation"));
      page.AddLine(buff);
      buff = String.Format(
          wxPorting.T("<a href=\"edit:\">%s</a><br>"), wxPorting.L("Create a new simulation"));
      page.AddLine(buff);
      page.EndCenter();
#if WIN32
#else
 	page.Add(wxPorting.T("</font>n"));
#endif

    }

    public void ShowStationsList() {
      HtmlPage page = new HtmlPage(wxPorting.T(""));

      Globals.print_entry_exit_stations(page);
      Globals.traindir.m_frame.ShowHtml(wxPorting.L("Stations List"), page.content);
    }

    public void PlaySound(String path) {
#if __WXMAC__
#else
      int i;

      for(i = 0; i < Configuration.MAX_SOUNDS; ++i) {
        if(string.IsNullOrEmpty(Globals.soundNames[i]))
          continue;
        if(Globals.wxStrcmp(Globals.soundNames[i], path) == 0) {
          if(Globals.soundTable[i] != null && Globals.soundTable[i].Ok)
            Globals.soundTable[i].Play(Globals.play_synchronously ? wxSound.wxSOUND_SYNC : wxSound.wxSOUND_ASYNC);
          return;
        }
      }
      for(i = 0; i < Configuration.MAX_SOUNDS && Globals.soundNames[i] != null; ++i) ;
      if(i >= Configuration.MAX_SOUNDS)	// too many sounds already registered
        return;
      Globals.soundNames[i] = String.Copy(path);
      Globals.soundTable[i] = new wxSound();
      Globals.soundTable[i].Create(path);
      if(Globals.soundTable[i].Ok)
        Globals.soundTable[i].Play(Globals.play_synchronously ? wxSound.wxSOUND_SYNC : wxSound.wxSOUND_ASYNC);
#endif
    }
  }

  public partial class Globals {
    public static void alert_beep() {
      if(pAlertSound != null && pAlertSound.Ok)
        pAlertSound.Play(Globals.play_synchronously ? wxSound.wxSOUND_SYNC : wxSound.wxSOUND_ASYNC);
    }

    public static void enter_beep() {
      if(pEntrySound != null && pEntrySound.Ok)
        pEntrySound.Play(Globals.play_synchronously ? wxSound.wxSOUND_SYNC : wxSound.wxSOUND_ASYNC);
    }

    //	-1 == cancel operation

    public static int ask_to_save_layout() {
      ShowModalResult answer = wx.MessageDialog.MessageBox(wxPorting.L("The layout was changed. Do you want to save it?"),
          wxPorting.L("Question"), wx.WindowStyles.DIALOG_YES_NO |  WindowStyles.DIALOG_CANCEL);
      if(answer == ShowModalResult.CANCEL)
        return -1;
      if(answer == ShowModalResult.NO)
        return 0;
      if(!Globals.traindir.OnSaveLayout())
        return -1;
      return 1;
    }

    public static ClientThread[] clients = new ClientThread[10];
    public static int nClients;

    public static void server_mode() {
      int i;

      wxSocketBase.Initialize();

      nClients = 0;
      for(i = 2; i < Globals.argc; ++i) {
        String server = Globals.argv[i];
        ClientThread client = new ClientThread();
        client.Create();
        client.SetAddr(server, 8900);
        client.Run();
        clients[nClients++] = client;
      }
    }

    public static void client_command(ClientThread src, String cmd) {
      ClientThread dst;
      int i;

      for(i = 0; i < nClients; ++i) {
        dst = clients[i];
        if(dst == src)
          continue;
        dst.Send(cmd);
      }
    }
  }
  /////////////////////////////////////////////////////////////////////////////

  public class TDProject {
    public String m_name;
    public Track m_layout;

    ~TDProject() {
      if(Globals.gtfs != null)
        Globals.delete(Globals.gtfs);
      Globals.gtfs = null;
    }

    public Itinerary find_from_to(Track from, Track to) {
      return null;
    }
  }
}