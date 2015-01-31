using System;
using System.Collections.Generic;
using System.Text;
using wx;
using System.IO;

namespace TrainDirNET {
  public class TrainDir : App {
    public MainFrame m_frame;

    // colors for the time table view
    public Colour m_colorCanceled;
    public Colour m_colorReady;
    public Colour m_colorArrived;
    public Colour m_colorDerailed;
    public Colour m_colorWaiting;
    public Colour m_colorRunning;
    public Colour m_colorStopped;
#if false
	TDProject	m_project;
#endif
	int		m_nOldSimulations;
  string[] m_oldSimulations = new string[Configuration.MAX_OLD_SIMULATIONS];

    bool m_ignoreTimer;
    int m_timeSlice;
    int		m_timeSliceCount;

    public override bool OnInit() {
      GlobalVariables.traindir = this;

      //  srand(time(0));

      //  wxInitAllImageHandlers();

      //  if(wxGetenv(("TDHOME")))
      //      wxSetWorkingDirectory(wxGetenv(("TDHOME")));

      //  m_project = 0;
      m_nOldSimulations = 0;

      //  m_colorCanceled = wxColor(64, 64, 64);
      //  m_colorReady    = *wxBLUE;
      //  m_colorArrived  = *wxGREEN;
      //  m_colorDerailed = *wxRED;
      //        m_colorWaiting  = *wxLIGHT_GREY;
      //  m_colorRunning  = *wxBLACK;
      //        m_colorStopped  = wxColor(0, 0, 128);// dark blue

      //  //
      //  //  Load the preferences before we create the main frame,
      //  //  since we have to decide which locale to use before
      //  //  creating the menus.
      //  //

      //  LoadPreferences();

      //  fonts.AddFont(gFontSizeSmall, wxFONTFAMILY_SWISS, wxNORMAL, wxNORMAL, 0);
      //  fonts.AddFont(gFontSizeBig, wxFONTFAMILY_SWISS, wxNORMAL, wxNORMAL, 0);

      GlobalVariables.program_name = String.Format(("Train Director {0}"), "TODO!!!"); //version);

      //  if(argc > 1 && !wxStrcmp(argv[1], ("-server"))) {
      //      server_mode();
      //      return true;
      //  }
      m_frame = new MainFrame(GlobalVariables.program_name);
      m_frame.SetSize(900, 600);
      // m_frame.m_app = this;

      m_timeSliceCount = 0;
      //  m_timeSlice = 10;
      //  m_ignoreTimer = true;

      //// ERIK #ifdef WIN32
      ////	entry_sound = ("C:\\Windows\\Media\\notify.wav");
      ////	alert_sound = ("C:\\Windows\\Media\\ringout.wav");
      //// ERIK #endif

      //  init_tool_layout();

      //  LoadState();

      //// ERIK #ifndef __WXMAC__
      //  if(!entry_sound._sValue.empty()) {
      //      pEntrySound = new wxSound();
      //            pEntrySound.Create(entry_sound._sValue);
      //  }
      //  if(!alert_sound._sValue.empty()) {
      //      pAlertSound = new wxSound();
      //            pAlertSound.Create(alert_sound._sValue);
      //  }
      //// ERIK #endif

      //  m_frame.Finalize();
      //  m_frame.SetIcon(wxIcon(("aaaTD_ICON")));
      m_frame.Show(true);

      GlobalFunctions.ShowWelcomePage();

      //  start_server_thread();

      //        if(user_name._sValue.Length() > 0) {
      //            bstreet_login();
      //        }

      //  if(argc > 1) {
      //      wxString filename = new wxString(argv[1]);
      //      OpenFile(filename, false);
      //  }
      //  wxHandleFatalExceptions(false);
      return true;
    }

#if false

//
//
//

Traindir::~Traindir()
{
	kill_server_thread();
// Erik #if 0
	// these are apparently deleted by ~MainFrame
	if(gFileDialog)
	    delete gFileDialog;
	gFileDialog = 0;
	if(gSaveGameFileDialog)
	    delete gSaveGameFileDialog;
	gSaveGameFileDialog = 0;
	if(gSaveLayoutFileDialog)
	    delete gSaveLayoutFileDialog;
	gSaveLayoutFileDialog = 0;
	if(gSaveTextFileDialog)
	    delete gSaveTextFileDialog;
	gSaveTextFileDialog = 0;
	if(gOpenImageDialog)
	    delete gOpenImageDialog;
	gOpenImageDialog = 0;
// Erik #endif

	if(m_project)
	    delete m_project;

	free_tool_layout();
	clean_pixmap_cache();
	free_pixmaps();
//	m_frame.Destroy();
}

//
//	When we need to panic, we cannot assume that
//	our dynamic memory area is still consistent.
//	Therefore, write to stderr the message,
//	so that if the message box fails, we at least
//	have a chance to see the message on the console.
//

void	Traindir::Panic()
{
// Erik #if wxUSE_UNICODE
	fprintf(stderr, "%s\n", (const char *) wxSafeConvertWX2MB(alert_msg));
// Erik #else
	fprintf(stderr, "%s\n", alert_msg);
// Erik #endif
	wxMessageBox(alert_msg);
	exit(1);
}


//
//
//

void	Traindir::OnFatalException()
{
	Panic();
}

//
//
//

void	Traindir::GetUserDir(wxString& path)
{
	wxChar	*env;
	if(!(env = wxGetenv(("TDHOME"))))
	    env = wxGetenv(("HOME"));
	if(env) {
	    path = env;
// Erik #ifndef WIN32
	    path += ("/");
// Erik #endif
	    return;
	}
// Erik #ifdef WIN32
	path = ("C:/Temp/");
// Erik #else
	path = ("/tmp/");
// Erik #endif
        if(!wxDirExists(path)) {
            if(!wxMkdir(path)) {
                wxString msg;
                msg.Printf(L("Cannot create directory '%s'. Try creating it manually."), path.c_str());
                wxMessageBox(msg, L("Error"));
                return;
            }
        }
}

//
//
//

void	Traindir::GetAppDir(wxString& path)
{
	path = ("");
}

//
//
//

struct optList {
	const wxChar	*name;
	int	*ptr;
} opt_list[] = {
 	{ ("fullstatus"), &terse_status },
 	{ ("statusontop"), &status_on_top },
 	{ ("alertsound"), &beep_on_alert },
 	{ ("entersound"), &beep_on_enter },
 	{ ("viewspeed"), &show_speeds },
 	{ ("autolink"), &auto_link },
 	{ ("linktoleft"), &link_to_left },
 	{ ("showgrid"), &show_grid },
 	{ ("showblocks"), &show_blocks },
 	{ ("showsecs"), &show_seconds },
 	{ ("standardsigs"), &signal_traditional },
 	{ ("hardcounters"), &hard_counters },
 	{ ("showlinks"), &show_links },
 	{ ("showscripts"), &show_scripts },
 	{ ("saveprefs"), &save_prefs },
 	{ ("ShowTrkFirst"), &gbTrkFirst },
 	{ ("traceScript"), &trace_script },
	{ ("ShowIcons"), &show_icons },
	{ ("RealTimeData"), &use_real_time },
	{ ("EnableTraining"), &enable_training },
	{ ("RandomDelays"), &random_delays },
	{ ("PlaySynchronously"), &play_synchronously },
	{ ("ServerPort"), &server_port },
        { ("TrainNames"), &draw_train_names },
        { ("NoTrainNamesColors"), &no_train_names_colors },
	{ 0 },
};

/*	This is called BEFORE setting up the user interface.
 *	As such, it must not call drawing routines!
 *	This is because the locale must be set before creating
 *	menus, buttons and dialogs, so that we can use the
 *	localized strings.
 */

void	Traindir::LoadPreferences(void)
{
	TConfig state;
	wxString str;
	int	i;

	GetUserDir(str);
 	str += (STATE_FILE_NAME);
 	if(!state.Load(str))
	    return;
	if(!state.FindSection(("Preferences")))
	    return;
	for(i = 0; opt_list[i].name; ++i)
	    state.GetInt(opt_list[i].name, *opt_list[i].ptr);
 	if(!state.GetString(("locale"), str))
 	    str = (".en");
 	locale_name = wxStrdup(str.c_str());
	load_localized_strings(locale_name);
	state.Get(searchPath);
}

static	wxColor	ParseColor(wxString& str)
{
 	if(str == ("red"))    return *wxRED;
 	if(str == ("blue"))   return *wxBLUE;
 	if(str == ("green"))  return *wxGREEN;
 	if(str == ("black"))  return *wxBLACK;
 	if(str == ("white"))  return *wxWHITE;
 	if(str == ("cyan"))   return *wxCYAN;
 	if(str == ("lightgray")) return *wxLIGHT_GREY;

	int     r, g, b;
	const wxChar    *s = str.c_str();
	wxChar *p;
	r = wxStrtol(s, &p, 10) & 0xFF;
	g = wxStrtol(p, &p, 10) & 0xFF;
	b = wxStrtol(p, &p, 10) & 0xFF;
	return wxColor(r, g, b);
}

//
//  Reload the state of the previous session
//
//  If there was no previous project,
//  the values are loaded from the default
//  state file, "C:/td3.ini".
//  But if a "traindir.lastproject" entry was
//  found in the default state file, then the
//  state is loaded from that file.
//  This allows different states depending on
//  which project is currently opened.
//

void	Traindir::LoadState()
{
	TConfig state;
	wxString prjName;
	wxString str;
	int	i;

	GetUserDir(str);
	str += (STATE_FILE_NAME);
	if(!state.Load(str))
	    return;
	if(state.FindSection(("Skin1"))) {	    // todo: get skin names from preference file, to
	    wxColor col;
	    TDSkin  *skin = new TDSkin();
	    skin.name = wxStrdup(("Skin1"));
	    skin.next = skin_list;
	    skin_list = skin;
	    if(state.GetString(("background"), prjName)) {
		col = ParseColor(prjName);
		skin.background = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("free_track"), prjName)) {
		col = ParseColor(prjName);
		skin.free_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("reserved_track"), prjName)) {
		col = ParseColor(prjName);
		skin.reserved_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("reserved_shunting"), prjName)) {
		col = ParseColor(prjName);
		skin.reserved_shunting = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("occupied_track"), prjName)) {
		col = ParseColor(prjName);
		skin.occupied_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("working_track"), prjName)) {
		col = ParseColor(prjName);
		skin.working_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("outline"), prjName)) {
		col = ParseColor(prjName);
		skin.outline = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	    if(state.GetString(("text"), prjName)) {
		col = ParseColor(prjName);
		skin.text = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
	    }
	}
	if(state.FindSection(("Preferences"))) {
	    wxString prjName;
 	    if(!state.GetString(("skin"), prjName))
 		prjName = ("default");
	    curSkin = skin_list;
	    while(curSkin) {
		if(wxStrcmp(curSkin.name, prjName.c_str()) == 0)
		    break;
		curSkin = curSkin.next;
	    }
	    if(!curSkin)	    // impossible
		curSkin = skin_list;
	}

        state.Get(http_server_enabled);
        state.Get(http_server_port);
        state.Get(user_name);

	if(!state.FindSection(("MainView")))
	    goto done;

	if(state.GetInt(("OldSimulations"), m_nOldSimulations)) {
	    wxString buff;

	    if((unsigned int)m_nOldSimulations > MAX_OLD_SIMULATIONS)	// safety check
		m_nOldSimulations = MAX_OLD_SIMULATIONS;
	    for(i = 0; i < m_nOldSimulations; ++i) {
		buff.Printf (("simulation%d"), i + 1);
		state.GetString(buff, m_oldSimulations[i]);
	    }
	}
	state.Get(entry_sound);
	state.Get(alert_sound);

	//  Colors for the time table view

	if(state.GetString(("colorCanceled"), prjName)) {
	    m_colorCanceled = ParseColor(prjName);
	}
	if(state.GetString(("colorReady"), prjName)) {
	    m_colorReady = ParseColor(prjName);
	}
	if(state.GetString(("colorArrived"), prjName)) {
	    m_colorArrived = ParseColor(prjName);
	}
	if(state.GetString(("colorDerailed"), prjName)) {
	    m_colorDerailed = ParseColor(prjName);
	}
	if(state.GetString(("colorWaiting"), prjName)) {
	    m_colorWaiting = ParseColor(prjName);
	}
	if(state.GetString(("colorRunning"), prjName)) {
	    m_colorRunning = ParseColor(prjName);
	}
	if(state.GetString(("colorStopped"), prjName)) {
	    m_colorStopped = ParseColor(prjName);
	}
	if(state.GetString(("colorBg"), prjName)) {
	    wxColor colorBg = ParseColor(prjName);
	    colortable[14][0] = colorBg.Red();
	    colortable[14][1] = colorBg.Green();
	    colortable[14][2] = colorBg.Blue();
	    fieldcolors[COL_BACKGROUND] = 12;
	}

	// layout's font sizes

	state.GetInt(("FontSizeSmall"), gFontSizeSmall);
	state.GetInt(("FontSizeBig"), gFontSizeBig);

	if(state.GetString(("project"), prjName)) {
	    m_project = new TDProject;
	    m_project.m_name = prjName;
	}
	if(!m_project) {
	    m_project = new TDProject;
	    m_project.m_name = ("Untitled");
	} else {
///	    state.Close();

	    //  Reload the state from the previous project

///	    if(!state.Load(m_project.m_name + ".tdp")) {
///		state.Load(STATE_FILE_NAME);
///	    }
	}
done:	m_frame.LoadState(("MainView"), state);
}


void	save_rgb(TConfig& state, Char *name, int rgb)
{
	wxString    buff;

	buff.Printf(("%d %d %d"), (rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF);
	state.PutString(name, buff);
}


//
//
//

void	Traindir::SaveState()
{
	TConfig	    state;
	wxString    str;
	struct optList *opt;

	GetUserDir(str);
	str += (STATE_FILE_NAME);
	if(state.Save(str)) {
	    m_frame.SaveState(("MainView"), state);
	    int	    i;
	    wxString	buff;
	    wxString	buff2;

	    state.PutInt(("OldSimulations"), m_nOldSimulations);
	    for(i = 0; i < m_nOldSimulations; ++i) {
		buff2.Printf (("simulation%d"), i + 1);
		state.PutString(buff2, m_oldSimulations[i]);
	    }
	    if(!entry_sound._sValue.empty())
		state.Put(entry_sound);
	    if(!alert_sound._sValue.empty())
                state.Put(alert_sound);

	    buff.Printf(("%d %d %d"), m_colorCanceled.Red(),
		    m_colorCanceled.Green(), m_colorCanceled.Blue());
	    state.PutString(("colorCanceled"), buff);

	    buff.Printf(("%d %d %d"), m_colorReady.Red(),
		    m_colorReady.Green(), m_colorReady.Blue());
	    state.PutString(("colorReady"), buff);

	    buff.Printf(("%d %d %d"), m_colorArrived.Red(),
		    m_colorArrived.Green(), m_colorArrived.Blue());
	    state.PutString(("colorArrived"), buff);

	    buff.Printf(("%d %d %d"), m_colorDerailed.Red(),
		    m_colorDerailed.Green(), m_colorDerailed.Blue());
	    state.PutString(("colorDerailed"), buff);

	    buff.Printf(("%d %d %d"), m_colorWaiting.Red(),
		    m_colorWaiting.Green(), m_colorWaiting.Blue());
	    state.PutString(("colorWaiting"), buff);

	    buff.Printf(("%d %d %d"), m_colorRunning.Red(),
		    m_colorRunning.Green(), m_colorRunning.Blue());
	    state.PutString(("colorRunning"), buff);
	    buff.Printf(("%d %d %d"), m_colorStopped.Red(),
		    m_colorStopped.Green(), m_colorStopped.Blue());
	    state.PutString(("colorStopped"), buff);
	    if(fieldcolors[COL_BACKGROUND] == 12) {
		buff.Printf(("%d %d %d"), colortable[14][0],
			colortable[14][1], colortable[14][2]);
		state.PutString(("colorBg"), buff);
	    }

	    state.PutInt(("FontSizeSmall"), gFontSizeSmall);
	    state.PutInt(("FontSizeBig"), gFontSizeBig);

	    if(save_prefs) {
		state.StartSection(("Preferences"));
		for(opt = opt_list; opt.name; ++opt) {
		    state.PutInt(opt.name, *opt.ptr);
		}
                state.Put(http_server_enabled);
                state.Put(http_server_port);
                state.Put(user_name);

		state.PutString(("locale"), locale_name);
		state.PutString(("skin"), curSkin.name);
	        state.Put(searchPath);
		TDSkin *skin;
		for(skin = skin_list; skin; skin = skin.next) {
		    if(skin == defaultSkin)
			continue;
		    state.StartSection(skin.name);
		    save_rgb(state, ("free_track"), skin.free_track);
		    save_rgb(state, ("reserved_track"), skin.reserved_track);
		    save_rgb(state, ("reserved_shunting"), skin.reserved_shunting);
		    save_rgb(state, ("occupied_track"), skin.occupied_track);
		    save_rgb(state, ("working_track"), skin.working_track);
		    save_rgb(state, ("background"), skin.background);
		    save_rgb(state, ("outline"), skin.outline);
		    save_rgb(state, ("text"), skin.text);
		}
	    }
	    state.Close();
	}
}

//
//
//
#endif

    public void OnOpenFile() {
      String types = "Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|All Files (*.*)|*.*";

      if(GlobalVariables.gFileDialog == null) {
        if(GlobalVariables.gbTrkFirst)
          types = ("Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|Traindir Scenarios (*.zip)|*.zip|All Files (*.*)|*.*");
        GlobalVariables.gFileDialog = new FileDialog(
          m_frame, wxPorting.L("Open a file"), (""), (""),
          types, WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR
        );
      }
      GlobalVariables.gFileDialog.Path = GlobalVariables.current_project;
      if(GlobalVariables.gFileDialog.ShowModal() != ShowModalResult.OK)
        return;

      string path = GlobalVariables.gFileDialog.Path;
      OpenFile(path);
    }

    void OpenFile(string path) {
      OpenFile(path, false);
    }

    void OpenFile(string path, bool restore)	// RECURSIVE
    {
      string buff;

      //gLogger.InstallLog();
      //gnErrors = 0;
      // FileName fname = new FileName(path);
      //wxSetWorkingDirectory (fname.GetPath()); // -. See .NET method Directory.SetCurrentDirectory
      string ext = Path.GetExtension(path).Replace(".", "").ToLower();
      if("zip".Equals(ext)) {
        GlobalFunctions.FreeFileList();
        string trkName = Path.GetFileNameWithoutExtension(path);
        trkName += ".trk";
        GlobalFunctions.ReadZipFile(path);
        buff = string.Format("{0} {1}", restore ? ("load") : ("open"), trkName);
        GlobalFunctions.trainsim_cmd(buff);
        GlobalVariables.current_project = path;
        //} else if(!ext.CmpNoCase(("trk"))) {
        //    FreeFileList();
        //    buff = string.Format( ("%s %s"), restore ? ("load") : ("open"), path.c_str());
        //    trainsim_cmd(buff);
        //    current_project = path;
        //} else if(!ext.CmpNoCase(("tdp"))) {
        //    FreeFileList();
        //    buff = string.Format( ("%s %s"), restore ? ("load") : ("puzzle"), path.c_str());
        //    trainsim_cmd(buff);
        //    current_project = path;
        //} else if(!ext.CmpNoCase(("sav"))) {
        //    FreeFileList();
        //    savedGame = path;
        //    buff = string.Format( ("restore %s"), path.c_str());
        //    buff[wxStrlen(buff) - 4] = 0;	 // remove extension
        //    trainsim_cmd(buff);
      } else {
        wxPorting.MessageBox(wxPorting.L("This file type is not recognized."));
        //    gLogger.UninstallLog();
        return;
      }

      int pg = m_frame.m_top.FindPage(wxPorting.L("Layout"));
      if(pg >= 0)
        m_frame.m_top.Selection = pg;
      //if(m_frame.m_trainInfo)
      //    m_frame.m_trainInfo.Update(0);

      //gLogger.UninstallLog();

      ////  Add newly opened file to list of old files

      //int	i;

      //for(i = 0; i < m_nOldSimulations; ++i) {
      //    if(path == m_oldSimulations[i]) {
      //  while(i > 0) {
      //      m_oldSimulations[i] = m_oldSimulations[i - 1];
      //      --i;
      //  }
      //  m_oldSimulations[0] = path;
      //  return;
      //    }
      //}
      //for(i = MAX_OLD_SIMULATIONS - 1; i > 0; --i)
      //    m_oldSimulations[i] = m_oldSimulations[i - 1];
      //m_oldSimulations[0] = path;
      //if(m_nOldSimulations < MAX_OLD_SIMULATIONS)
      //    ++m_nOldSimulations;
    }


    //
    //
    //

#if false
//
//
//

bool	Traindir::OpenMacroFileDialog(wxChar *buff)
{
        if(!gFileDialog) {
	    gFileDialog = new wxFileDialog(m_frame, _("Open a file"), (""), (""),
		("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
	}
	if(gFileDialog.ShowModal() != wxID_OK)
	    return false;

	wxStrcpy(buff, gFileDialog.GetPath());
	return true;
}

//
//
//
#endif
    public bool SaveTextFileDialog(out string buff) {
      buff = "";
      if(GlobalVariables.gSaveTextFileDialog == null) {
        GlobalVariables.gSaveTextFileDialog = new FileDialog(
          m_frame, wxPorting.L("Save file"), (""), (""),
      ("Text file (*.txt)|*.txt|All Files (*.*)|*.*"),
      WindowStyles.FD_SAVE | WindowStyles.FD_CHANGE_DIR);
      }
      if(GlobalVariables.gSaveTextFileDialog.ShowModal() != ShowModalResult.OK)
        return false;
      buff = GlobalVariables.gSaveTextFileDialog.Path;
      return true;
    }
#if false

//
//
//

bool	Traindir::SaveHtmlFileDialog(wxChar *buff)
{
	if(!gSaveHtmlFileDialog) {
	    gSaveHtmlFileDialog = new wxFileDialog(m_frame, L("Save file"), (""), (""),
		("HTML file (*.htm)|*.htm|All Files (*.*)|*.*"),
		wxSAVE | wxCHANGE_DIR);
	}
	if(gSaveHtmlFileDialog.ShowModal() != wxID_OK)
	    return false;
	wxStrcpy(buff, gSaveHtmlFileDialog.GetPath());
	return true;
}

//
//
//

bool	Traindir::OpenImageDialog(wxChar *buff)
{
	if(!gOpenImageDialog) {
	    gOpenImageDialog = new wxFileDialog(m_frame, L("Open image"), (""), (""),
		("Icon (*.xpm)|*.xpm|All Files (*.*)|*.*"),
		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
	}
	if(buff[0])
	    gOpenImageDialog.SetPath(buff);
	if(gOpenImageDialog.ShowModal() != wxID_OK)
	    return false;
	wxStrcpy(buff, gOpenImageDialog.GetPath());
	return true;
}

//
//
//

bool	Traindir::OpenScriptDialog(wxChar *buff)
{
        if(!gScriptFileDialog) {
	    gScriptFileDialog = new wxFileDialog(m_frame, L("Open a script file"), (""), (""),
		("Traindir Script (*.tds)|*.tds|All Files (*.*)|*.*"),
		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
	}
	gScriptFileDialog.SetPath(buff);
	if(gScriptFileDialog.ShowModal() != wxID_OK)
	    return false;

	wxStrcpy(buff, gScriptFileDialog.GetPath());
	return true;
}

//
//
//

bool	Traindir::OpenSelectPowerDialog()
{
        if(!gSelectPowerDialog) {
	    gSelectPowerDialog = new SelectPowerDialog(m_frame);
	}
	if(gSelectPowerDialog.ShowModal() != wxID_OK)
	    return false;
	return true;
}

//
//
//

void	Traindir::OnSaveGame()
{
	wxChar	buff[512];

        if(!can_save_game()) {
            alert_dialog(("Saving now will lead to an invalid file. Please continue the simulation for a bit and try again."));
            return;
        }
	if(!gSaveGameFileDialog) {
	    gSaveGameFileDialog = new wxFileDialog(m_frame, _("Save simulation file"), (""), (""),
		("Saved simulation (*.sav)|*.sav|All Files (*.*)|*.*"),
		wxSAVE | wxCHANGE_DIR);
	}
	if(gSaveGameFileDialog.ShowModal() != wxID_OK)
	    return;
	savedGame = gSaveGameFileDialog.GetPath();
	buff = string.Format( ("savegame %s"), savedGame.c_str());
	trainsim_cmd(buff);
}

//
//
//

void	Traindir::OnRestore()
{
	if(!savedGame.length()) {
	    OnRestart();
	    return;
	}
	if(ask(L("Are you sure you want to restore\nthe simulation to its saved state?")) != ANSWER_YES)
	    return;
	OpenFile(savedGame);
}

bool	Traindir::SaveHtmlPage(HtmlPage& page)
{
	Char	fname[512];

	if(!SaveHtmlFileDialog(fname))
	    return false;

	wxFFile	file;

	if(!file.Open(fname, ("w"))) {
	    do_alert(("Open file failed."));
	    return false;
	}
	file.Write(*page.content);
	file.Close();
	return true;
}


bool	Traindir::SavePerfText()
{
	Char	fname[512];

	if(!SaveTextFileDialog(fname))
	    return false;

	wxFFile	file;
	HtmlPage    page((""));

	if(!file.Open(fname, ("w"))) {
	    do_alert(("Open file failed."));
	    return false;
	}
	save_schedule_status(page);
	file.Write(*page.content);
	file.Close();
	return true;
}

//HtmlFile *Traindir::CreateHtmlFile(char *buff)
//{
//	remove_ext(buff);
//	strcat(buff, ".htm");
//	if(!(fp = file_create(buff)))
//	    return 0;
//}


//
//
//
#endif
    public void Error(string msg) {
      // ++gnErrors;
    }

    public void layout_error(string msg)
{
	m_frame.m_alertList.AddLine(msg);
}

    public void AddAlert(string msg) {
      //string buff = string.Format("%s: %s", GlobalFunctions.format_time(current_time), msg);
      //alerts.Lock();
      //alerts.AddLine(buff);
      //alerts.NotifyListeners();
      //alerts.Unlock();
    }
#if false
//
//
//

void	Traindir::ClearAlert()
{
//	m_frame.m_alertList.DeleteAllItems();
        alerts.Lock();
        alerts.Clear();
        alerts.NotifyListeners();
        alerts.Unlock();
}

//
//
//

void	Traindir::end_layout_error()
{
}

//
//
//

#endif
    public void SetTimeSlice(int msec) {
      if(msec == 0)
        m_ignoreTimer = true;
      else {
        m_ignoreTimer = false;
        m_timeSlice = msec;
      }
    }

    // Erik's patch: let's try with lock() command
    object cmdLocker = new object(); // wxCriticalSection

    void post_command(string cmd) {
      lock(cmdLocker) { // cmdLocker.Enter();
        if(GlobalVariables.nCommands < 10)
          GlobalVariables.commands[GlobalVariables.nCommands++] = string.Copy(cmd);
      } //  cmdLocker.Leave();
    }

public void OnTimer() {
  string cmd;
  do {
    cmd = null;
    lock(cmdLocker) { // cmdLocker.Enter();
      if(GlobalVariables.nCommands > 0) {
        cmd = GlobalVariables.commands[0];
        for(int i = 0; i < GlobalVariables.nCommands - 1; ++i)
          GlobalVariables.commands[i] = GlobalVariables.commands[i + 1];
        --GlobalVariables.nCommands;
      }
    } //  cmdLocker.Leave();
    if(cmd != null) {
      GlobalFunctions.do_command(cmd, false);
    }
  } while(cmd != null);
  if(++m_timeSliceCount >= m_timeSlice) {
    m_timeSliceCount = 0;
    if(m_ignoreTimer) {
      GlobalFunctions.flash_signals();
      GlobalFunctions.repaint_all();
      return;
    }
    GlobalFunctions.click_time();
  }
}

    public void OnRecent()
{
}
    public void OnRestore(string name)
    {
    }

#if false
void	Traindir::OnEdit()
{
	if(editing)
	    trainsim_cmd(("noedit"));
	else
	    trainsim_cmd(("edit"));
}

//
//
//

void	Traindir::OnNewTrain()
{
	trainsim_cmd(("newtrain"));
}

//
//
//

void	Traindir::OnItinerary()
{
	trainsim_cmd(("edititinerary"));
}

//
//
//

bool	Traindir::OnSaveLayout()
{
	wxChar	buff[512];
	wxChar	*p;

	if(!gSaveLayoutFileDialog) {
	    gSaveLayoutFileDialog = new wxFileDialog(m_frame, L("Save Layout"), (""), (""),
		("Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
		wxSAVE | wxCHANGE_DIR);
	}
	gSaveLayoutFileDialog.SetPath(current_project);
	if(gSaveLayoutFileDialog.ShowModal() != wxID_OK)
	    return false;
	buff = string.Format( ("save %s"), gSaveLayoutFileDialog.GetPath().c_str());
	p = buff + wxStrlen(buff) - 4;
	if(!wxStricmp(p, (".trk")))
	    *p = 0;
	trainsim_cmd(buff);
	return true;
}

//
//
//

void	Traindir::OnPreferences()
{
	trainsim_cmd(("options"));
}

//
//
//

void	Traindir::OnNewLayout()
{
	if(ask(L("This will delete the current layout.\nAre you sure you want to continue?")) != ANSWER_YES)
	    return;
	trainsim_cmd(("new"));
}

//
//
//

void	Traindir::OnInfo()
{
	trainsim_cmd(("info"));
}

#endif
public void OnStartStop()
{
	GlobalFunctions.trainsim_cmd(("run"));
}
#if false

//
//
//

void	Traindir::OnGraph()
{
	trainsim_cmd(("graph"));
}

//
//
//

void	Traindir::OnRestart()
{
	trainsim_cmd(("t0"));
}

//
//
//

void	Traindir::OnFast()
{
	trainsim_cmd(("fast"));
}

//
//
//

void	Traindir::OnSlow()
{
	trainsim_cmd(("slow"));
}

//
//
//

void	Traindir::OnStationSched()
{
	trainsim_cmd(("stationsched"));
}

//
//
//

void	Traindir::OnSetGreen()
{
	trainsim_cmd(("greensigs"));
}

//
//
//

void	Traindir::OnSkipToNext()
{
	trainsim_cmd(("skip"));
}

//
//
//

void	Traindir::OnPerformance()
{
	trainsim_cmd(("performance"));
}

//
//
//
#endif
public void BuildWelcomePage(HtmlPage page)
{
#if WIN32
#else
	page.Add(("<font size=-1>\n"));
#endif
// Erik #endif
	page.Add(("<table bgcolor=// Erik #60C060 width=100% cellspacing=3><tr><td>\n"));
	page.Add(("<font size=+2 color=// Erik #FFFFFF>Welcome to "));
	page.Add(GlobalVariables.program_name);
	page.Add(("</font>\n"));
	page.Add(("</td></tr></table>\n"));
	page.Add(("<table width=\"100%\"><tr><td align=left valign=top>"));
	page.Add(("Copyright 2000 - 2014 Giampiero Caprino<br>Backer Street Software, Sunnyvale, CA, USA"));
	page.Add(("</td><td align=right valign=top>"));
	page.AddLine(("Train Director is free software, released under the GNU General Public License 2"));
	page.AddLine(("Built using the wxWidgets portable framework"));
	page.Add(("</td></tr></table>\n"));
	page.Add(("<hr><br><br>\n"));

//	page.Add(("<table><tr><td valign=top align=left>\n"));
	page.AddCenter();
	page.AddLine(wxPorting.L("You recently played the following simulations:<br><br>"));
	int	i;
  string buff;

	for(i = 0; i < m_nOldSimulations; ++i) {
	    buff = string.Format(
        "<a href=\"open:{0}\">{1}</a><br>",
        m_oldSimulations[i],
        m_oldSimulations[i]
      );
	    page.AddLine(buff);
	}
//	page.Add(("</table>\n"));
  buff = string.Format(
    "<br><br><a href=\"open:\">{0}...</a><br>",
    wxPorting.L("Open another simulation")
  );
	page.AddLine(buff);
  buff = string.Format(
    "<a href=\"edit:\">{0}</a><br>",
    wxPorting.L("Create a new simulation")
  );
	page.AddLine(buff);
	page.EndCenter();
#if WIN32
#else
	page.Add(("</font>\n"));
#endif

}
#if false
void	Traindir::ShowStationsList()
{
	HtmlPage    page((""));

	print_entry_exit_stations(page);
	traindir.m_frame.ShowHtml(L("Stations List"), *page.content);
}

void	Traindir::PlaySound(const wxChar *path)
{
// Erik #ifndef __WXMAC__
	int	i;

	for(i = 0; i < MAX_SOUNDS; ++i) {
	    if(!soundNames[i])
		continue;
	    if(!wxStrcmp(soundNames[i], path)) {
		if(soundTable[i] && soundTable[i].IsOk())
		    soundTable[i].Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
		return;
	    }
	}
	for(i = 0; i < MAX_SOUNDS && soundNames[i]; ++i);
	if(i >= MAX_SOUNDS)	// too many sounds already registered
	    return;
	soundNames[i] = wxStrdup(path);
	soundTable[i] = new wxSound;
	soundTable[i].Create(path);
	if(soundTable[i].IsOk())
	    soundTable[i].Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
// Erik #endif
}

void	alert_beep()
{
	if(pAlertSound && pAlertSound.IsOk())
	    pAlertSound.Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
}

void	enter_beep(void)
{
	if(pEntrySound && pEntrySound.IsOk())
	    pEntrySound.Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
}

//	-1 == cancel operation

int	ask_to_save_layout()
{
	int answer = wxMessageBox(L("The layout was changed. Do you want to save it?"),
	    L("Question"), wxYES_NO|wxCANCEL);
	if(answer == wxCANCEL)
	    return -1;
	if(answer == wxNO)
	    return 0;
	if(!traindir.OnSaveLayout())
	    return -1;
	return 1;
}

ClientThread	*clients[10];
int		nClients;

void	Traindir::server_mode()
{
	int	i;

        wxSocketBase::Initialize();

	nClients = 0;
	for(i = 2; i < argc; ++i) {
	    wxChar  *server = argv[i];
	    ClientThread *client = new ClientThread();
	    client.Create();
	    client.SetAddr(server, 8900);
	    client.Run();
	    clients[nClients++] = client;
	}
}

void	client_command(ClientThread *src, wxChar *cmd)
{
	ClientThread *dst;
	int	i;

	for(i = 0; i < nClients; ++i) {
	    dst = clients[i];
	    if(dst == src)
		continue;
	    dst.Send(cmd);
	}
}

/////////////////////////////////////////////////////////////////////////////

TDProject::TDProject()
{
	m_layout = 0;
}

TDProject::~TDProject()
{
        if(gtfs)
            delete gtfs;
        gtfs = 0;
}

Itinerary *find_from_to(Track *from, Track *to)
{
	return 0;
}


#endif

    
  }
}