// /*	Main.cpp - Created by Giampiero Caprino
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
// */
// 
// #include "wx/wx.h"
// #include "wx/splitter.h"
// #include "wx/listctrl.h"
// #include "wx/html/htmlwin.h"
// #include "wx/image.h"		// for InitAllImageHandlers
// #include "wx/filedlg.h"
// #include "wx/ffile.h"
// #include "wx/fs_zip.h"
// #include "wx/sound.h"
// #include "TDFile.h"
// #include "TimeTblView.h"
// #include "TrainInfoList.h"
// #include "Canvas.h"
// #include "AlertList.h"
// #include "MainFrm.h"
// #include "Traindir3.h"
// #include "FontManager.h"
// #include "html.h"
// #include "Client.h"
// #include "Options.h"
// #include "OptionsDialog.h"
// #include "GTFS.h"
// #ifdef WIN32
// #define	strcasecmp stricmp
// #endif
// 
// extern	void	ShowWelcomePage(void);
// extern	void	init_tool_layout(void);
// extern	void	free_tool_layout(void);
// extern	void	FreeFileList(void);
// extern	const wxChar	*locale_name;
// extern	void	load_localized_strings(const wxChar *locale);
// extern	void	clean_pixmap_cache();
// extern	void	flash_signals();
// extern  bool    can_save_game();
// 
// extern	void	start_server_thread();
// extern	void	kill_server_thread();
// extern  void    alert_dialog(const Char *msg);
// 
// extern  void    bstreet_login();
// extern  void    bstreet_logout();
// 
// extern	int	gFontSizeSmall, gFontSizeBig;
// extern unsigned char colortable[13][3];
// 
// extern  IntOption   http_server_port;
// extern  BoolOption  http_server_enabled;
// extern  StringOption user_name;
// 
// wxString	program_name;
// wxString	program_home;
// wxString	savedGame;
// 
// ///////////////////////////////////////////////////////////////////////
// 
// DECLARE_APP(Traindir)
// 
// IMPLEMENT_APP(Traindir)
// 
// Traindir	*traindir;
// 
// int		gnErrors = 0;
// 
// int		gbTrkFirst = 0;	    // show .trk before .zip in dialogs
// 
// wxFileDialog	*gFileDialog = 0;
// wxFileDialog	*gScriptFileDialog = 0;
// wxFileDialog	*gSaveGameFileDialog = 0;
// wxFileDialog	*gSaveLayoutFileDialog = 0;
// wxFileDialog	*gSaveImageFileDialog = 0;
// wxFileDialog	*gSaveTextFileDialog = 0;
// wxFileDialog	*gSaveHtmlFileDialog = 0;
// wxFileDialog	*gOpenImageDialog = 0;
// SelectPowerDialog *gSelectPowerDialog = 0;
// 
// FileOption      alert_sound(wxT("EntrySound"),
//                             wxT("Path to sound file for alert notifications"),
//                             wxT("Environment"),
//                             wxT("C:\Windows\Media\ringout.wav"));
// FileOption      entry_sound(wxT("AlertSound"),
//                             wxT("Path to sound file for train entry"),
//                             wxT("Environment"),
//                             wxT("C:\Windows\Media\notify.wav"));
// wxSound		*pAlertSound;
// wxSound		*pEntrySound;
// 
// int		server_port = 8900;
// int             lastModTime = 1;    // incremented when data for listeners is updated
// 
// int		nSounds;
// wxSound		*soundTable[MAX_SOUNDS];
// const wxChar	*soundNames[MAX_SOUNDS];
// 
// extern	int	enable_training;	/* enable signal training menu */
// 
// //
// //
// //
// 
// bool	Traindir::OnInit()
// {
// 	traindir = this;
// 
// 	srand(time(0));
// 
// 	wxInitAllImageHandlers();
// 
// 	if(wxGetenv(wxT("TDHOME")))
// 	    wxSetWorkingDirectory(wxGetenv(wxT("TDHOME")));
// 
// 	m_project = 0;
// 	m_nOldSimulations = 0;
// 
// 	m_colorCanceled = wxColor(64, 64, 64);
// 	m_colorReady    = *wxBLUE;
// 	m_colorArrived  = *wxGREEN;
// 	m_colorDerailed = *wxRED;
//         m_colorWaiting  = *wxLIGHT_GREY;
// 	m_colorRunning  = *wxBLACK;
//         m_colorStopped  = wxColor(0, 0, 128);// dark blue
// 
// 	//
// 	//  Load the preferences before we create the main frame,
// 	//  since we have to decide which locale to use before
// 	//  creating the menus.
// 	//
// 
// 	LoadPreferences();
// 
// 	fonts.AddFont(gFontSizeSmall, wxFONTFAMILY_SWISS, wxNORMAL, wxNORMAL, 0);
// 	fonts.AddFont(gFontSizeBig, wxFONTFAMILY_SWISS, wxNORMAL, wxNORMAL, 0);
// 
// 	program_name.Printf(wxT("Train Director %s"), version);
// 
// 	if(argc > 1 && !wxStrcmp(argv[1], wxT("-server"))) {
// 	    server_mode();
// 	    return true;
// 	}
// 	m_frame = new MainFrame(program_name);
// 	m_frame->SetSize(900, 600);
// 	m_frame->m_app = this;
// 
// 	m_timeSliceCount = 0;
// 	m_timeSlice = 10;
// 	m_ignoreTimer = true;
// 
// #ifdef WIN32
// //	entry_sound = wxT("C:\Windows\Media\notify.wav");
// //	alert_sound = wxT("C:\Windows\Media\ringout.wav");
// #endif
// 
// 	init_tool_layout();
// 
// 	LoadState();
// 
// #ifndef __WXMAC__
// 	if(!entry_sound._sValue.empty()) {
// 	    pEntrySound = new wxSound;
//             pEntrySound->Create(entry_sound._sValue);
// 	}
// 	if(!alert_sound._sValue.empty()) {
// 	    pAlertSound = new wxSound;
//             pAlertSound->Create(alert_sound._sValue);
// 	}
// #endif
// 
// 	m_frame->Finalize();
// 	m_frame->SetIcon(wxIcon(wxT("aaaTD_ICON")));
// 	m_frame->Show(true);
// 
// 	ShowWelcomePage();
// 
// 	start_server_thread();
// 
//         if(user_name._sValue.Length() > 0) {
//             bstreet_login();
//         }
// 
// 	if(argc > 1) {
// 	    wxString filename(argv[1]);
// 	    OpenFile(filename, false);
// 	}
// 	wxHandleFatalExceptions(false);
// 	return true;
// }
// 
// //
// //
// //
// 
// Traindir::~Traindir()
// {
// 	kill_server_thread();
// #if 0
// 	// these are apparently deleted by ~MainFrame
// 	if(gFileDialog)
// 	    delete gFileDialog;
// 	gFileDialog = 0;
// 	if(gSaveGameFileDialog)
// 	    delete gSaveGameFileDialog;
// 	gSaveGameFileDialog = 0;
// 	if(gSaveLayoutFileDialog)
// 	    delete gSaveLayoutFileDialog;
// 	gSaveLayoutFileDialog = 0;
// 	if(gSaveTextFileDialog)
// 	    delete gSaveTextFileDialog;
// 	gSaveTextFileDialog = 0;
// 	if(gOpenImageDialog)
// 	    delete gOpenImageDialog;
// 	gOpenImageDialog = 0;
// #endif
// 
// 	if(m_project)
// 	    delete m_project;
// 
// 	free_tool_layout();
// 	clean_pixmap_cache();
// 	free_pixmaps();
// //	m_frame->Destroy();
// }
// 
// //
// //	When we need to panic, we cannot assume that
// //	our dynamic memory area is still consistent.
// //	Therefore, write to stderr the message,
// //	so that if the message box fails, we at least
// //	have a chance to see the message on the console.
// //
// 
// void	Traindir::Panic()
// {
// #if wxUSE_UNICODE
// 	fprintf(stderr, "%sn", (const char *) wxSafeConvertWX2MB(alert_msg));
// #else
// 	fprintf(stderr, "%sn", alert_msg);
// #endif
// 	wxMessageBox(alert_msg);
// 	exit(1);
// }
// 
// 
// //
// //
// //
// 
// void	Traindir::OnFatalException()
// {
// 	Panic();
// }
// 
// //
// //
// //
// 
// void	Traindir::GetUserDir(wxString& path)
// {
// 	wxChar	*env;
// 	if(!(env = wxGetenv(wxT("TDHOME"))))
// 	    env = wxGetenv(wxT("HOME"));
// 	if(env) {
// 	    path = env;
// #ifndef WIN32
// 	    path += wxT("/");
// #endif
// 	    return;
// 	}
// #ifdef WIN32
// 	path = wxT("C:/Temp/");
// #else
// 	path = wxT("/tmp/");
// #endif
//         if(!wxDirExists(path)) {
//             if(!wxMkdir(path)) {
//                 wxString msg;
//                 msg.Printf(L("Cannot create directory '%s'. Try creating it manually."), path.c_str());
//                 wxMessageBox(msg, L("Error"));
//                 return;
//             }
//         }
// }
// 
// //
// //
// //
// 
// void	Traindir::GetAppDir(wxString& path)
// {
// 	path = wxT("");
// }
// 
// //
// //
// //
// 
// struct optList {
// 	const wxChar	*name;
// 	int	*ptr;
// } opt_list[] = {
//  	{ wxT("fullstatus"), &terse_status },
//  	{ wxT("statusontop"), &status_on_top },
//  	{ wxT("alertsound"), &beep_on_alert },
//  	{ wxT("entersound"), &beep_on_enter },
//  	{ wxT("viewspeed"), &show_speeds },
//  	{ wxT("autolink"), &auto_link },
//  	{ wxT("linktoleft"), &link_to_left },
//  	{ wxT("showgrid"), &show_grid },
//  	{ wxT("showblocks"), &show_blocks },
//  	{ wxT("showsecs"), &show_seconds },
//  	{ wxT("standardsigs"), &signal_traditional },
//  	{ wxT("hardcounters"), &hard_counters },
//  	{ wxT("showlinks"), &show_links },
//  	{ wxT("showscripts"), &show_scripts },
//  	{ wxT("saveprefs"), &save_prefs },
//  	{ wxT("ShowTrkFirst"), &gbTrkFirst },
//  	{ wxT("traceScript"), &trace_script },
// 	{ wxT("ShowIcons"), &show_icons },
// 	{ wxT("RealTimeData"), &use_real_time },
// 	{ wxT("EnableTraining"), &enable_training },
// 	{ wxT("RandomDelays"), &random_delays },
// 	{ wxT("PlaySynchronously"), &play_synchronously },
// 	{ wxT("ServerPort"), &server_port },
//         { wxT("TrainNames"), &draw_train_names },
//         { wxT("NoTrainNamesColors"), &no_train_names_colors },
// 	{ 0 },
// };
// 
// /*	This is called BEFORE setting up the user interface.
//  *	As such, it must not call drawing routines!
//  *	This is because the locale must be set before creating
//  *	menus, buttons and dialogs, so that we can use the
//  *	localized strings.
//  */
// 
// void	Traindir::LoadPreferences(void)
// {
// 	TConfig state;
// 	wxString str;
// 	int	i;
// 
// 	GetUserDir(str);
//  	str += wxT(STATE_FILE_NAME);
//  	if(!state.Load(str))
// 	    return;
// 	if(!state.FindSection(wxT("Preferences")))
// 	    return;
// 	for(i = 0; opt_list[i].name; ++i)
// 	    state.GetInt(opt_list[i].name, *opt_list[i].ptr);
//  	if(!state.GetString(wxT("locale"), str))
//  	    str = wxT(".en");
//  	locale_name = wxStrdup(str.c_str());
// 	load_localized_strings(locale_name);
// 	state.Get(searchPath);
// }
// 
// static	wxColor	ParseColor(wxString& str)
// {
//  	if(str == wxT("red"))    return *wxRED;
//  	if(str == wxT("blue"))   return *wxBLUE;
//  	if(str == wxT("green"))  return *wxGREEN;
//  	if(str == wxT("black"))  return *wxBLACK;
//  	if(str == wxT("white"))  return *wxWHITE;
//  	if(str == wxT("cyan"))   return *wxCYAN;
//  	if(str == wxT("lightgray")) return *wxLIGHT_GREY;
// 
// 	int     r, g, b;
// 	const wxChar    *s = str.c_str();
// 	wxChar *p;
// 	r = wxStrtol(s, &p, 10) & 0xFF;
// 	g = wxStrtol(p, &p, 10) & 0xFF;
// 	b = wxStrtol(p, &p, 10) & 0xFF;
// 	return wxColor(r, g, b);
// }
// 
// //
// //  Reload the state of the previous session
// //
// //  If there was no previous project,
// //  the values are loaded from the default
// //  state file, "C:/td3.ini".
// //  But if a "traindir.lastproject" entry was
// //  found in the default state file, then the
// //  state is loaded from that file.
// //  This allows different states depending on
// //  which project is currently opened.
// //
// 
// void	Traindir::LoadState()
// {
// 	TConfig state;
// 	wxString prjName;
// 	wxString str;
// 	int	i;
// 
// 	GetUserDir(str);
// 	str += wxT(STATE_FILE_NAME);
// 	if(!state.Load(str))
// 	    return;
// 	if(state.FindSection(wxT("Skin1"))) {	    // todo: get skin names from preference file, to
// 	    wxColor col;
// 	    TDSkin  *skin = new TDSkin();
// 	    skin->name = wxStrdup(wxT("Skin1"));
// 	    skin->next = skin_list;
// 	    skin_list = skin;
// 	    if(state.GetString(wxT("background"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->background = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("free_track"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->free_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("reserved_track"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->reserved_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("reserved_shunting"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->reserved_shunting = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("occupied_track"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->occupied_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("working_track"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->working_track = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("outline"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->outline = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	    if(state.GetString(wxT("text"), prjName)) {
// 		col = ParseColor(prjName);
// 		skin->text = (col.Red() << 16) | (col.Green() << 8) | col.Blue();
// 	    }
// 	}
// 	if(state.FindSection(wxT("Preferences"))) {
// 	    wxString prjName;
//  	    if(!state.GetString(wxT("skin"), prjName))
//  		prjName = wxT("default");
// 	    curSkin = skin_list;
// 	    while(curSkin) {
// 		if(wxStrcmp(curSkin->name, prjName.c_str()) == 0)
// 		    break;
// 		curSkin = curSkin->next;
// 	    }
// 	    if(!curSkin)	    // impossible
// 		curSkin = skin_list;
// 	}
// 
//         state.Get(http_server_enabled);
//         state.Get(http_server_port);
//         state.Get(user_name);
// 
// 	if(!state.FindSection(wxT("MainView")))
// 	    goto done;
// 
// 	if(state.GetInt(wxT("OldSimulations"), m_nOldSimulations)) {
// 	    wxString buff;
// 
// 	    if((unsigned int)m_nOldSimulations > MAX_OLD_SIMULATIONS)	// safety check
// 		m_nOldSimulations = MAX_OLD_SIMULATIONS;
// 	    for(i = 0; i < m_nOldSimulations; ++i) {
// 		buff.Printf (wxT("simulation%d"), i + 1);
// 		state.GetString(buff, m_oldSimulations[i]);
// 	    }
// 	}
// 	state.Get(entry_sound);
// 	state.Get(alert_sound);
// 
// 	//  Colors for the time table view
// 
// 	if(state.GetString(wxT("colorCanceled"), prjName)) {
// 	    m_colorCanceled = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorReady"), prjName)) {
// 	    m_colorReady = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorArrived"), prjName)) {
// 	    m_colorArrived = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorDerailed"), prjName)) {
// 	    m_colorDerailed = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorWaiting"), prjName)) {
// 	    m_colorWaiting = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorRunning"), prjName)) {
// 	    m_colorRunning = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorStopped"), prjName)) {
// 	    m_colorStopped = ParseColor(prjName);
// 	}
// 	if(state.GetString(wxT("colorBg"), prjName)) {
// 	    wxColor colorBg = ParseColor(prjName);
// 	    colortable[14][0] = colorBg.Red();
// 	    colortable[14][1] = colorBg.Green();
// 	    colortable[14][2] = colorBg.Blue();
// 	    fieldcolors[COL_BACKGROUND] = 12;
// 	}
// 
// 	// layout's font sizes
// 
// 	state.GetInt(wxT("FontSizeSmall"), gFontSizeSmall);
// 	state.GetInt(wxT("FontSizeBig"), gFontSizeBig);
// 
// 	if(state.GetString(wxT("project"), prjName)) {
// 	    m_project = new TDProject;
// 	    m_project->m_name = prjName;
// 	}
// 	if(!m_project) {
// 	    m_project = new TDProject;
// 	    m_project->m_name = wxT("Untitled");
// 	} else {
// ///	    state.Close();
// 
// 	    //  Reload the state from the previous project
// 
// ///	    if(!state.Load(m_project->m_name + ".tdp")) {
// ///		state.Load(STATE_FILE_NAME);
// ///	    }
// 	}
// done:	m_frame->LoadState(wxT("MainView"), state);
// }
// 
// 
// void	save_rgb(TConfig& state, Char *name, int rgb)
// {
// 	wxString    buff;
// 
// 	buff.Printf(wxT("%d %d %d"), (rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF);
// 	state.PutString(name, buff);
// }
// 
// 
// //
// //
// //
// 
// void	Traindir::SaveState()
// {
// 	TConfig	    state;
// 	wxString    str;
// 	struct optList *opt;
// 
// 	GetUserDir(str);
// 	str += wxT(STATE_FILE_NAME);
// 	if(state.Save(str)) {
// 	    m_frame->SaveState(wxT("MainView"), state);
// 	    int	    i;
// 	    wxString	buff;
// 	    wxString	buff2;
// 
// 	    state.PutInt(wxT("OldSimulations"), m_nOldSimulations);
// 	    for(i = 0; i < m_nOldSimulations; ++i) {
// 		buff2.Printf (wxT("simulation%d"), i + 1);
// 		state.PutString(buff2, m_oldSimulations[i]);
// 	    }
// 	    if(!entry_sound._sValue.empty())
// 		state.Put(entry_sound);
// 	    if(!alert_sound._sValue.empty())
//                 state.Put(alert_sound);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorCanceled.Red(),
// 		    m_colorCanceled.Green(), m_colorCanceled.Blue());
// 	    state.PutString(wxT("colorCanceled"), buff);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorReady.Red(),
// 		    m_colorReady.Green(), m_colorReady.Blue());
// 	    state.PutString(wxT("colorReady"), buff);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorArrived.Red(),
// 		    m_colorArrived.Green(), m_colorArrived.Blue());
// 	    state.PutString(wxT("colorArrived"), buff);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorDerailed.Red(),
// 		    m_colorDerailed.Green(), m_colorDerailed.Blue());
// 	    state.PutString(wxT("colorDerailed"), buff);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorWaiting.Red(),
// 		    m_colorWaiting.Green(), m_colorWaiting.Blue());
// 	    state.PutString(wxT("colorWaiting"), buff);
// 
// 	    buff.Printf(wxT("%d %d %d"), m_colorRunning.Red(),
// 		    m_colorRunning.Green(), m_colorRunning.Blue());
// 	    state.PutString(wxT("colorRunning"), buff);
// 	    buff.Printf(wxT("%d %d %d"), m_colorStopped.Red(),
// 		    m_colorStopped.Green(), m_colorStopped.Blue());
// 	    state.PutString(wxT("colorStopped"), buff);
// 	    if(fieldcolors[COL_BACKGROUND] == 12) {
// 		buff.Printf(wxT("%d %d %d"), colortable[14][0],
// 			colortable[14][1], colortable[14][2]);
// 		state.PutString(wxT("colorBg"), buff);
// 	    }
// 
// 	    state.PutInt(wxT("FontSizeSmall"), gFontSizeSmall);
// 	    state.PutInt(wxT("FontSizeBig"), gFontSizeBig);
// 
// 	    if(save_prefs) {
// 		state.StartSection(wxT("Preferences"));
// 		for(opt = opt_list; opt->name; ++opt) {
// 		    state.PutInt(opt->name, *opt->ptr);
// 		}
//                 state.Put(http_server_enabled);
//                 state.Put(http_server_port);
//                 state.Put(user_name);
// 
// 		state.PutString(wxT("locale"), locale_name);
// 		state.PutString(wxT("skin"), curSkin->name);
// 	        state.Put(searchPath);
// 		TDSkin *skin;
// 		for(skin = skin_list; skin; skin = skin->next) {
// 		    if(skin == defaultSkin)
// 			continue;
// 		    state.StartSection(skin->name);
// 		    save_rgb(state, wxT("free_track"), skin->free_track);
// 		    save_rgb(state, wxT("reserved_track"), skin->reserved_track);
// 		    save_rgb(state, wxT("reserved_shunting"), skin->reserved_shunting);
// 		    save_rgb(state, wxT("occupied_track"), skin->occupied_track);
// 		    save_rgb(state, wxT("working_track"), skin->working_track);
// 		    save_rgb(state, wxT("background"), skin->background);
// 		    save_rgb(state, wxT("outline"), skin->outline);
// 		    save_rgb(state, wxT("text"), skin->text);
// 		}
// 	    }
// 	    state.Close();
// 	}
// }
// 
// //
// //
// //
// 
// void	Traindir::OnOpenFile()
// {
// 	wxString	    types =
// 	    wxT("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|All Files (*.*)|*.*");
// 
// 	if(!gFileDialog) {
// 	    if(gbTrkFirst)
// 		types = wxT("Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|Traindir Scenarios (*.zip)|*.zip|All Files (*.*)|*.*");
// 	    gFileDialog = new wxFileDialog(m_frame, L("Open a file"), wxT(""), wxT(""),
// 		types,
// 		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
// 	}
// 	gFileDialog->SetPath(current_project);
// 	if(gFileDialog->ShowModal() != wxID_OK)
// 	    return;
// 
// 	wxString	path = gFileDialog->GetPath();
// 	OpenFile(path);
// }
// 
// //
// //
// //
// 
// void	Traindir::OpenFile(wxString& path, bool restore)	// RECURSIVE
// {
// 	wxChar    buff[256];
// 
// 	gLogger.InstallLog();
// 	gnErrors = 0;
// 	wxFileName  fname(path);
// 	wxSetWorkingDirectory (fname.GetPath());
// 	wxString    ext(fname.GetExt());
// 	if(!ext.CmpNoCase(wxT("zip"))) {
// 	    FreeFileList();
// 	    wxString    trkName(fname.GetName());
// 	    trkName += wxT(".trk");
// 	    ReadZipFile(path);
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s %s"), restore ? wxT("load") : wxT("open"), trkName.c_str());
// 	    trainsim_cmd(buff);
// 	    current_project = path;
// 	} else if(!ext.CmpNoCase(wxT("trk"))) {
// 	    FreeFileList();
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s %s"), restore ? wxT("load") : wxT("open"), path.c_str());
// 	    trainsim_cmd(buff);
// 	    current_project = path;
// 	} else if(!ext.CmpNoCase(wxT("tdp"))) {
// 	    FreeFileList();
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s %s"), restore ? wxT("load") : wxT("puzzle"), path.c_str());
// 	    trainsim_cmd(buff);
// 	    current_project = path;
// 	} else if(!ext.CmpNoCase(wxT("sav"))) {
// 	    FreeFileList();
// 	    savedGame = path;
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("restore %s"), path.c_str());
// 	    buff[wxStrlen(buff) - 4] = 0;	 // remove extension
// 	    trainsim_cmd(buff);
// 	} else {
// 	    wxMessageBox(L("This file type is not recognized."));
// 	    gLogger.UninstallLog();
// 	    return;
// 	}
// 
// 	int	pg = m_frame->m_top->FindPage(L("Layout"));
// 	if(pg >= 0)
// 	    m_frame->m_top->SetSelection(pg);
// 	if(m_frame->m_trainInfo)
// 	    m_frame->m_trainInfo->Update(0);
// 
// 	gLogger.UninstallLog();
// 
// 	//  Add newly opened file to list of old files
// 
// 	int	i;
// 
// 	for(i = 0; i < m_nOldSimulations; ++i) {
// 	    if(path == m_oldSimulations[i]) {
// 		while(i > 0) {
// 		    m_oldSimulations[i] = m_oldSimulations[i - 1];
// 		    --i;
// 		}
// 		m_oldSimulations[0] = path;
// 		return;
// 	    }
// 	}
// 	for(i = MAX_OLD_SIMULATIONS - 1; i > 0; --i)
// 	    m_oldSimulations[i] = m_oldSimulations[i - 1];
// 	m_oldSimulations[0] = path;
// 	if(m_nOldSimulations < MAX_OLD_SIMULATIONS)
// 	    ++m_nOldSimulations;
// }
// 
// //
// //
// //
// 
// void	Traindir::OpenFile(const wxChar *path, bool restore)
// {
// 	wxString    str(path);
// 
// 	OpenFile(str, restore);
// }
// 
// //
// //
// //
// 
// bool	Traindir::OpenMacroFileDialog(wxChar *buff)
// {
//         if(!gFileDialog) {
// 	    gFileDialog = new wxFileDialog(m_frame, _("Open a file"), wxT(""), wxT(""),
// 		wxT("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
// 		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
// 	}
// 	if(gFileDialog->ShowModal() != wxID_OK)
// 	    return false;
// 
// 	wxStrcpy(buff, gFileDialog->GetPath());
// 	return true;
// }
// 
// //
// //
// //
// 
// bool	Traindir::SaveTextFileDialog(wxChar *buff)
// {
// 	if(!gSaveTextFileDialog) {
// 	    gSaveTextFileDialog = new wxFileDialog(m_frame, L("Save file"), wxT(""), wxT(""),
// 		wxT("Text file (*.txt)|*.txt|All Files (*.*)|*.*"),
// 		wxSAVE | wxCHANGE_DIR);
// 	}
// 	if(gSaveTextFileDialog->ShowModal() != wxID_OK)
// 	    return false;
// 	wxStrcpy(buff, gSaveTextFileDialog->GetPath());
// 	return true;
// }
// 
// //
// //
// //
// 
// bool	Traindir::SaveHtmlFileDialog(wxChar *buff)
// {
// 	if(!gSaveHtmlFileDialog) {
// 	    gSaveHtmlFileDialog = new wxFileDialog(m_frame, L("Save file"), wxT(""), wxT(""),
// 		wxT("HTML file (*.htm)|*.htm|All Files (*.*)|*.*"),
// 		wxSAVE | wxCHANGE_DIR);
// 	}
// 	if(gSaveHtmlFileDialog->ShowModal() != wxID_OK)
// 	    return false;
// 	wxStrcpy(buff, gSaveHtmlFileDialog->GetPath());
// 	return true;
// }
// 
// //
// //
// //
// 
// bool	Traindir::OpenImageDialog(wxChar *buff)
// {
// 	if(!gOpenImageDialog) {
// 	    gOpenImageDialog = new wxFileDialog(m_frame, L("Open image"), wxT(""), wxT(""),
// 		wxT("Icon (*.xpm)|*.xpm|All Files (*.*)|*.*"),
// 		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
// 	}
// 	if(buff[0])
// 	    gOpenImageDialog->SetPath(buff);
// 	if(gOpenImageDialog->ShowModal() != wxID_OK)
// 	    return false;
// 	wxStrcpy(buff, gOpenImageDialog->GetPath());
// 	return true;
// }
// 
// //
// //
// //
// 
// bool	Traindir::OpenScriptDialog(wxChar *buff)
// {
//         if(!gScriptFileDialog) {
// 	    gScriptFileDialog = new wxFileDialog(m_frame, L("Open a script file"), wxT(""), wxT(""),
// 		wxT("Traindir Script (*.tds)|*.tds|All Files (*.*)|*.*"),
// 		wxOPEN | wxFILE_MUST_EXIST | wxCHANGE_DIR);
// 	}
// 	gScriptFileDialog->SetPath(buff);
// 	if(gScriptFileDialog->ShowModal() != wxID_OK)
// 	    return false;
// 
// 	wxStrcpy(buff, gScriptFileDialog->GetPath());
// 	return true;
// }
// 
// //
// //
// //
// 
// bool	Traindir::OpenSelectPowerDialog()
// {
//         if(!gSelectPowerDialog) {
// 	    gSelectPowerDialog = new SelectPowerDialog(m_frame);
// 	}
// 	if(gSelectPowerDialog->ShowModal() != wxID_OK)
// 	    return false;
// 	return true;
// }
// 
// //
// //
// //
// 
// void	Traindir::OnSaveGame()
// {
// 	wxChar	buff[512];
// 
//         if(!can_save_game()) {
//             alert_dialog(wxT("Saving now will lead to an invalid file. Please continue the simulation for a bit and try again."));
//             return;
//         }
// 	if(!gSaveGameFileDialog) {
// 	    gSaveGameFileDialog = new wxFileDialog(m_frame, _("Save simulation file"), wxT(""), wxT(""),
// 		wxT("Saved simulation (*.sav)|*.sav|All Files (*.*)|*.*"),
// 		wxSAVE | wxCHANGE_DIR);
// 	}
// 	if(gSaveGameFileDialog->ShowModal() != wxID_OK)
// 	    return;
// 	savedGame = gSaveGameFileDialog->GetPath();
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("savegame %s"), savedGame.c_str());
// 	trainsim_cmd(buff);
// }
// 
// //
// //
// //
// 
// void	Traindir::OnRestore()
// {
// 	if(!savedGame.length()) {
// 	    OnRestart();
// 	    return;
// 	}
// 	if(ask(L("Are you sure you want to restorenthe simulation to its saved state?")) != ANSWER_YES)
// 	    return;
// 	OpenFile(savedGame);
// }
// 
// bool	Traindir::SaveHtmlPage(HtmlPage& page)
// {
// 	Char	fname[512];
// 
// 	if(!SaveHtmlFileDialog(fname))
// 	    return false;
// 
// 	wxFFile	file;
// 
// 	if(!file.Open(fname, wxT("w"))) {
// 	    do_alert(wxT("Open file failed."));
// 	    return false;
// 	}
// 	file.Write(*page.content);
// 	file.Close();
// 	return true;
// }
// 
// 
// bool	Traindir::SavePerfText()
// {
// 	Char	fname[512];
// 
// 	if(!SaveTextFileDialog(fname))
// 	    return false;
// 
// 	wxFFile	file;
// 	HtmlPage    page(wxT(""));
// 
// 	if(!file.Open(fname, wxT("w"))) {
// 	    do_alert(wxT("Open file failed."));
// 	    return false;
// 	}
// 	save_schedule_status(page);
// 	file.Write(*page.content);
// 	file.Close();
// 	return true;
// }
// 
// //HtmlFile *Traindir::CreateHtmlFile(char *buff)
// //{
// //	remove_ext(buff);
// //	strcat(buff, ".htm");
// //	if(!(fp = file_create(buff)))
// //	    return 0;
// //}
// 
// 
// //
// //
// //
// 
// void	Traindir::Error(const wxChar *msg)
// {
// 	++gnErrors;
// }
// 
// //
// //
// //
// 
// void	Traindir::layout_error(const wxChar *msg)
// {
// 	m_frame->m_alertList->AddLine(msg);
// }
// 
// //
// //
// //
// 
// void	Traindir::AddAlert(const wxChar *msg)
// {
// 	Char	buff[512];
// 
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("%s: %s"), format_time(current_time), msg);
//         alerts.Lock();
//         alerts.AddLine(buff);
//         alerts.NotifyListeners();
//         alerts.Unlock();
// //	m_frame->m_alertList->AddLine(buff);
// }
// 
// //
// //
// //
// 
// void	Traindir::ClearAlert()
// {
// //	m_frame->m_alertList->DeleteAllItems();
//         alerts.Lock();
//         alerts.Clear();
//         alerts.NotifyListeners();
//         alerts.Unlock();
// }
// 
// //
// //
// //
// 
// void	Traindir::end_layout_error()
// {
// }
// 
// //
// //
// //
// 
// void	Traindir::SetTimeSlice(int msec)
// {
// 	if(!msec)
// 	    m_ignoreTimer = true;
// 	else {
// 	    m_ignoreTimer = false;
// 	    m_timeSlice = msec;
// 	}
// }
// 
// //
// //
// //
// 
// wxCriticalSection   cmdLocker;
// wxChar	*commands[10];
// int	nCommands;
// extern	void	do_command(const wxChar *cmd, bool sendToClients);
// 
// void	post_command(wxChar *cmd)
// {
// 	cmdLocker.Enter();
// 	if(nCommands < 10)
// 	    commands[nCommands++] = wxStrdup(cmd);
// 	cmdLocker.Leave();
// }
// 
// void	Traindir::OnTimer()
// {
// 	wxChar	*cmd;
// 	do {
// 	    cmd = 0;
// 	    cmdLocker.Enter();
// 	    if(nCommands > 0) {
// 		cmd = commands[0];
// 		for(int i = 0; i < nCommands - 1; ++i)
// 		    commands[i] = commands[i + 1];
// 		--nCommands;
// 	    }
// 	    cmdLocker.Leave();
// 	    if(cmd != 0) {
// 		do_command(cmd, false);
// 	    }
// 	} while(cmd != 0);
// 	if(++m_timeSliceCount >= m_timeSlice) {
// 	    m_timeSliceCount = 0;
// 	    if(m_ignoreTimer) {
// 		flash_signals();
// 		repaint_all();
// 		return;
// 	    }
// 	    click_time();
// 	}
// }
// 
// //
// //
// //
// 
// void	Traindir::OnRecent()
// {
// }
// 
// //
// //
// //
// 
// //void	Traindir::OnRestore(char *name)
// //{
// //}
// 
// //
// //
// //
// 
// void	Traindir::OnEdit()
// {
// 	if(editing)
// 	    trainsim_cmd(wxT("noedit"));
// 	else
// 	    trainsim_cmd(wxT("edit"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnNewTrain()
// {
// 	trainsim_cmd(wxT("newtrain"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnItinerary()
// {
// 	trainsim_cmd(wxT("edititinerary"));
// }
// 
// //
// //
// //
// 
// bool	Traindir::OnSaveLayout()
// {
// 	wxChar	buff[512];
// 	wxChar	*p;
// 
// 	if(!gSaveLayoutFileDialog) {
// 	    gSaveLayoutFileDialog = new wxFileDialog(m_frame, L("Save Layout"), wxT(""), wxT(""),
// 		wxT("Traindir Layout (*.trk)|*.trk|All Files (*.*)|*.*"),
// 		wxSAVE | wxCHANGE_DIR);
// 	}
// 	gSaveLayoutFileDialog->SetPath(current_project);
// 	if(gSaveLayoutFileDialog->ShowModal() != wxID_OK)
// 	    return false;
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar), wxT("save %s"), gSaveLayoutFileDialog->GetPath().c_str());
// 	p = buff + wxStrlen(buff) - 4;
// 	if(!wxStricmp(p, wxT(".trk")))
// 	    *p = 0;
// 	trainsim_cmd(buff);
// 	return true;
// }
// 
// //
// //
// //
// 
// void	Traindir::OnPreferences()
// {
// 	trainsim_cmd(wxT("options"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnNewLayout()
// {
// 	if(ask(L("This will delete the current layout.nAre you sure you want to continue?")) != ANSWER_YES)
// 	    return;
// 	trainsim_cmd(wxT("new"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnInfo()
// {
// 	trainsim_cmd(wxT("info"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnStartStop()
// {
// 	trainsim_cmd(wxT("run"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnGraph()
// {
// 	trainsim_cmd(wxT("graph"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnRestart()
// {
// 	trainsim_cmd(wxT("t0"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnFast()
// {
// 	trainsim_cmd(wxT("fast"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnSlow()
// {
// 	trainsim_cmd(wxT("slow"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnStationSched()
// {
// 	trainsim_cmd(wxT("stationsched"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnSetGreen()
// {
// 	trainsim_cmd(wxT("greensigs"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnSkipToNext()
// {
// 	trainsim_cmd(wxT("skip"));
// }
// 
// //
// //
// //
// 
// void	Traindir::OnPerformance()
// {
// 	trainsim_cmd(wxT("performance"));
// }
// 
// //
// //
// //
// 
// void	Traindir::BuildWelcomePage(HtmlPage& page)
// {
// #ifndef WIN32
// 	page.Add(wxT("<font size=-1>n"));
// #endif
// 	page.Add(wxT("<table bgcolor=#60C060 width=100% cellspacing=3><tr><td>n"));
// 	page.Add(wxT("<font size=+2 color=#FFFFFF>Welcome to "));
// 	page.Add(program_name);
// 	page.Add(wxT("</font>n"));
// 	page.Add(wxT("</td></tr></table>n"));
// 	page.Add(wxT("<table width="100%"><tr><td align=left valign=top>"));
// 	page.Add(wxT("Copyright 2000 - 2014 Giampiero Caprino<br>Backer Street Software, Sunnyvale, CA, USA"));
// 	page.Add(wxT("</td><td align=right valign=top>"));
// 	page.AddLine(wxT("Train Director is free software, released under the GNU General Public License 2"));
// 	page.AddLine(wxT("Built using the wxWidgets portable framework"));
// 	page.Add(wxT("</td></tr></table>n"));
// 	page.Add(wxT("<hr><br><br>n"));
// 
// //	page.Add(wxT("<table><tr><td valign=top align=left>n"));
// 	page.AddCenter();
// 	page.AddLine(L("You recently played the following simulations:<br><br>"));
// 	int	i;
// 	wxChar	buff[512];
// 
// 	for(i = 0; i < m_nOldSimulations; ++i) {
// 	    wxSnprintf(buff, sizeof(buff)/sizeof(wxChar),
// 		wxT("<a href="open:%s">%s</a><br>"),
// 		m_oldSimulations[i].c_str(), m_oldSimulations[i].c_str());
// 	    page.AddLine(buff);
// 	}
// //	page.Add(wxT("</table>n"));
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar),
// 	    wxT("<br><br><a href="open:">%s...</a><br>"),
// 	    L("Open another simulation"));
// 	page.AddLine(buff);
// 	wxSnprintf(buff, sizeof(buff)/sizeof(wxChar),
// 	    wxT("<a href="edit:">%s</a><br>"), L("Create a new simulation"));
// 	page.AddLine(buff);
// 	page.EndCenter();
// #ifndef WIN32
// 	page.Add(wxT("</font>n"));
// #endif
// 
// }
// 
// void	Traindir::ShowStationsList()
// {
// 	HtmlPage    page(wxT(""));
// 
// 	print_entry_exit_stations(page);
// 	traindir->m_frame->ShowHtml(L("Stations List"), *page.content);
// }
// 
// void	Traindir::PlaySound(const wxChar *path)
// {
// #ifndef __WXMAC__
// 	int	i;
// 
// 	for(i = 0; i < MAX_SOUNDS; ++i) {
// 	    if(!soundNames[i])
// 		continue;
// 	    if(!wxStrcmp(soundNames[i], path)) {
// 		if(soundTable[i] && soundTable[i]->IsOk())
// 		    soundTable[i]->Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
// 		return;
// 	    }
// 	}
// 	for(i = 0; i < MAX_SOUNDS && soundNames[i]; ++i);
// 	if(i >= MAX_SOUNDS)	// too many sounds already registered
// 	    return;
// 	soundNames[i] = wxStrdup(path);
// 	soundTable[i] = new wxSound;
// 	soundTable[i]->Create(path);
// 	if(soundTable[i]->IsOk())
// 	    soundTable[i]->Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
// #endif
// }
// 
// void	alert_beep()
// {
// 	if(pAlertSound && pAlertSound->IsOk())
// 	    pAlertSound->Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
// }
// 
// void	enter_beep(void)
// {
// 	if(pEntrySound && pEntrySound->IsOk())
// 	    pEntrySound->Play(play_synchronously ? wxSOUND_SYNC : wxSOUND_ASYNC);
// }
// 
// //	-1 == cancel operation
// 
// int	ask_to_save_layout()
// {
// 	int answer = wxMessageBox(L("The layout was changed. Do you want to save it?"),
// 	    L("Question"), wxYES_NO|wxCANCEL);
// 	if(answer == wxCANCEL)
// 	    return -1;
// 	if(answer == wxNO)
// 	    return 0;
// 	if(!traindir->OnSaveLayout())
// 	    return -1;
// 	return 1;
// }
// 
// ClientThread	*clients[10];
// int		nClients;
// 
// void	Traindir::server_mode()
// {
// 	int	i;
// 
//         wxSocketBase::Initialize();
// 
// 	nClients = 0;
// 	for(i = 2; i < argc; ++i) {
// 	    wxChar  *server = argv[i];
// 	    ClientThread *client = new ClientThread();
// 	    client->Create();
// 	    client->SetAddr(server, 8900);
// 	    client->Run();
// 	    clients[nClients++] = client;
// 	}
// }
// 
// void	client_command(ClientThread *src, wxChar *cmd)
// {
// 	ClientThread *dst;
// 	int	i;
// 
// 	for(i = 0; i < nClients; ++i) {
// 	    dst = clients[i];
// 	    if(dst == src)
// 		continue;
// 	    dst->Send(cmd);
// 	}
// }
// 
// /////////////////////////////////////////////////////////////////////////////
// 
// TDProject::TDProject()
// {
// 	m_layout = 0;
// }
// 
// TDProject::~TDProject()
// {
//         if(gtfs)
//             delete gtfs;
//         gtfs = 0;
// }
// 
// Itinerary *find_from_to(Track *from, Track *to)
// {
// 	return 0;
// }
// 
