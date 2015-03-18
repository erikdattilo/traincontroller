using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx;
using System.Drawing;
using TrainController.SimCommands;
using TrainDirPorting;
using System.Collections;
using System.Windows.Forms;

namespace TrainController {
  class MainApp {
    //[STAThread]
    //public static void Main() {
    //  // Create an instance of our TrainController's TrainController class
    //  TrainController trainController = new TrainController();

    //  // Run the application
    //  trainController.Run();
    //}

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainFrame());
    }
  }

  public class TrainControllerApp : App {
    private static TrainControllerApp mInstance = null;

    private Queue mCommands = Queue.Synchronized(new Queue());
    private bool mIgnoreTimer;
    private int mTimeSlice;
    private int mTimeSliceCount;


    private TrainControllerApp() {
      if(mInstance != null)
        throw new Exception("TrainController constructor can be called only once");

      mInstance = this;

      // TODO Handle better this part of code
      mTimeSliceCount = 0;
      mTimeSlice = 10;
      mIgnoreTimer = true;

      OnInit();
    }

    public static TrainControllerApp GetInstance() {
      if(mInstance == null)
        mInstance = new TrainControllerApp();

      return mInstance;
    }

    private OpenFileDialog mFileDialog;
    // TODO Rename to mFrame
    public MainFrame m_frame;



    public override bool OnInit() {
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

        Globals.program_name = String.Format(wxPorting.T("Train Director {0}"), Globals.version);

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
      return true;
    }


    public void OnOpenFile() {
      String types;

      // TODO Move this initialization inside the constructor? It depends on the gbTrkFirst flag also
      if(mFileDialog == null) {
        if(Globals.gbTrkFirst) {
          types = I18N.T("Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|Traindir Scenarios (*.zip)|*.zip|All Files (*.*)|*.*");
        } else {
         types = I18N.T("Traindir Scenario (*.zip)|*.zip|Traindir Layout (*.trk)|*.trk|Saved Simulations (*.sav)|*.sav|All Files (*.*)|*.*");
        }

        mFileDialog = new OpenFileDialog {
          Title = I18N.L("Open a file"),
          Filter = types,
          // WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR,
          InitialDirectory = Globals.current_project,

        };
      }
      if(mFileDialog.ShowDialog() != DialogResult.OK)
        return;

      String path = mFileDialog.FileName;
      OpenFile(path);
    }

    public void OnTimer() {
      SimCommand cmd;
      // TODO Implement a safety check to avoid infinite loop (push faster than pull)
      while(mCommands.Count > 0) {
        cmd = (SimCommand)mCommands.Dequeue();
        if(cmd == null)
          continue;

        Globals.do_command(cmd, false);
      }
      if(++mTimeSliceCount >= mTimeSlice) {
        mTimeSliceCount = 0;
        if(mIgnoreTimer) {
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
      String ext = string.Copy(fname.GetExt()).ToLower();
      switch(ext) {
        case "zip":
          Globals.FreeFileList();
          String trkName = string.Copy(fname.GetName());
          trkName += I18N.T(".trk");
          Globals.ReadZipFile(path);
          SimCommand cmd;
          cmd = restore ?
              (LoadBaseCommand)new LoadCommand(trkName) :
              (LoadBaseCommand)new OpenCommand(trkName);

          Globals.trainsim_cmd(cmd);
          Globals.current_project = path;
          break;

        case "trk":
          throw new NotImplementedException();
        //  Globals.FreeFileList();
        //  buff = String.Format(I18N.T("%s %s"), restore ? I18N.T("load") : I18N.T("open"), path);
        //  Globals.trainsim_cmd(buff);
        //  Globals.current_project = path;

        case "tdp":
          throw new NotImplementedException();
        //  Globals.FreeFileList();
        //  buff = String.Format(I18N.T("%s %s"), restore ? I18N.T("load") : I18N.T("puzzle"), path);
        //  Globals.trainsim_cmd(buff);
        //  Globals.current_project = path;
        case "sav":
          throw new NotImplementedException();
        //  Globals.FreeFileList();
        //  Globals.savedGame = path;
        //  buff = String.Format(I18N.T("restore %s"), path);
        //  buff = buff.Substring(0, Globals.wxStrlen(buff) - 4);	 // remove extension
        //  Globals.trainsim_cmd(buff);

        default:
          wx.MessageDialog.MessageBox(wxPorting.L("This file type is not recognized."));
          Globals.gLogger.UninstallLog();
          return;
      }

      //int pg = m_frame.m_top.FindPage(wxPorting.L("Layout"));
      //if(pg >= 0)
      //  m_frame.m_top.Selection = (pg);
      //if(m_frame.m_trainInfo != null)
      //  m_frame.m_trainInfo.Update(null);

      //Globals.gLogger.UninstallLog();

      //  Add newly opened file to list of old files

      //int i;

      //for(i = 0; i < m_nOldSimulations; ++i) {
      //  if(path == m_oldSimulations[i]) {
      //    while(i > 0) {
      //      m_oldSimulations[i] = m_oldSimulations[i - 1];
      //      --i;
      //    }
      //    m_oldSimulations[0] = path;
      //    return;
      //  }
      //}
      //for(i = Configuration.MAX_OLD_SIMULATIONS - 1; i > 0; --i)
      //  m_oldSimulations[i] = m_oldSimulations[i - 1];
      //m_oldSimulations[0] = path;
      //if(m_nOldSimulations < Configuration.MAX_OLD_SIMULATIONS)
      //  ++m_nOldSimulations;
    }

    // TODO Look for all NotImplementedException and implement them

    public void Error(string buff) {
      throw new NotImplementedException();
    }
  }
}
