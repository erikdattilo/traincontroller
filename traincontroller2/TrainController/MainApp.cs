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

  public class TrainController : App {
    private static TrainController mInstance = null;

    private Queue mCommands = Queue.Synchronized(new Queue());
    private bool mIgnoreTimer;
    private int mTimeSlice;
    private int mTimeSliceCount;


    private TrainController() {
      if(mInstance != null)
        throw new Exception("TrainController constructor can be called only once");

      mInstance = this;

      // TODO Handle better this part of code
      mTimeSliceCount = 0;
      mTimeSlice = 10;
      mIgnoreTimer = true;
    }

    public static TrainController GetInstance() {
      if(mInstance == null)
        mInstance = new TrainController();

      return mInstance;
    }

    private wx.FileDialog mFileDialog;
    // TODO Rename to mFrame
    private MainFrame2 m_frame;



    public override bool OnInit() {
      // TODO Place correct code in this function!
      m_frame = new MainFrame2("ERIK");
      m_frame.Show();

      OpenFile(@"C:\Documents and Settings\Erik_\Desktop\tdir38win\Scenari\Padova2014.zip");

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

        mFileDialog = new wx.FileDialog(
          m_frame,
          I18N.L("Open a file"), I18N.T(""), I18N.T(""),
          types,
          WindowStyles.FD_OPEN | WindowStyles.FD_FILE_MUST_EXIST | WindowStyles.FD_CHANGE_DIR
        );
      }

      mFileDialog.Path = (Globals.current_project);
      if(mFileDialog.ShowModal() != ShowModalResult.OK)
        return;

      String path = mFileDialog.Path;
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
