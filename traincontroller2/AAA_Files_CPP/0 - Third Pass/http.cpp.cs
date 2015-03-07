using System;
namespace TrainDirPorting {
  public partial class Globals {
    public static StringOption user_name = new StringOption(wxPorting.T("userName"),
                              wxPorting.T("Name of the player"),
                              wxPorting.T("Server"),
                              wxPorting.T(""));

    public static string locate(string p, string pattern) {
      throw new NotImplementedException();
      //int l = Globals.wxStrlen(pattern);

      //while(p.Length > 0 && Globals.wxStrncmp(p, pattern, l))
      //  p = p.Substring(1);
      //if(p.Length > 0)
      //  return p;
      //return null;
    }

    public static int get_delay(Train t) {
      throw new NotImplementedException();
//      int delay = 0;
//#if WIN32
//  wxHTTP	get;
 
//  if(!use_real_time)
//      return 0;
 
//  get.SetHeader(wxPorting._T("Content-type"), wxPorting._T("text/html; charset=utf-8"));
//  get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...
  
//  // this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
//  while (!get.Connect(wxPorting._T("mobile.viaggiatreno.it")))  // only the server, no pages here yet ...
//    wxPorting.wxSleep(5);
  
//  var dummy = Globals.traindir.IsMainLoopRunning; // should return true
  
//  string buff;
//  int i, j = 0;
 
//  for(i = 0; i < t.name.Length; ++i) {
//    if(!wxPorting.wxIsdigit(t.name[i]))
//    continue;
//      buff.ReplaceAt(j++, t.name[i]);
//  }
//  buff = buff.Substring(0, j);
 
//  string url;
 
//  url = String.Format( wxPorting.T("/viaggiatreno/mobile/scheda?numeroTreno=%s&tipoRicerca=numero"), buff);
//  // use wxPorting._T("/") for index.html, index.php, default.asp, etc.
//  wxInputStream httpStream = get.GetInputStream(url);
  
//  // wxLogVerbose( String(wxPorting._T(" GetInputStream: ")) << get.GetResponse() << wxPorting._T("-") << ((resStream)? wxPorting._T("OK ") : wxPorting._T("FAILURE ")) << get.GetError() );
  
//  if (get.GetError() == wxPROTO_NOERR)
//  {
//      String res = "";
//      wxStringOutputStream out_stream = new wxStringOutputStream(res);
//      httpStream.Read(out_stream);
//      //wx.MessageDialog.MessageBox(res);
  
//      string p = res;
//      string line = p;
 
//      if((p = locate(p, wxPorting.T("<!-- SITUAZIONE"))) != null) {
//    while(p.length > 0 && Globals.wxStrncmp(p, wxPorting.T("minuti di ritardo"), 17)) {
//        p = p.Substring(1);
//        if(p[0] == 'n')
//      line = p;
//    }
//    if(p.length > 0) {
//        for(p = line; p.length > 0 && !wxPorting.wxIsdigit(p); p = p.Substring(1));
//        if(wxPorting.wxIsdigit(p))
//          delay = wxPorting.wxAtoi(p);
//    }
//      }
 
//      // wxLogVerbose( String(wxPorting._T(" returned document length: ")) << res.Length() );
//  }
//  else
//  {
//      wx.MessageDialog.MessageBox(wxPorting._T("Unable to connect!"));
//  }

//  wxPorting.wxDELETE(httpStream);
//  get.Close();
//#endif
//      return delay;
    }


    public static void bstreet_send(string url) {
      //if(user_name._sValue.Length == 0)
      //  return;

      //wxHTTP get;
      //get.SetHeader(wxPorting._T("Content-type"), wxPorting._T("text/html; charset=utf-8"));
      //get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...

      //// this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
      //if(!get.Connect(wxPorting._T("www.backerstreet.com")))  // only the server, no pages here yet ...
      //  return;
      //wxInputStream stream = get.GetInputStream(url);
      //// we don't care about the result or any error
      //wxPorting.wxDELETE(stream);
      //get.Close();
    }


    public static void bstreet_login() {
      string url;
      url = String.Copy( wxPorting.T("/Globals.traindir/server/login.php?u="));
      wxStrcat(url, user_name._sValue);
      bstreet_send(url);
    }

    public static void bstreet_logout() {
      string url;
      url = String.Copy( wxPorting.T("/Globals.traindir/server/logout.php?u="));
      Globals.wxStrcat(url, user_name._sValue);
      Globals.bstreet_send(url);
    }

    public static void bstreet_playing() {
      string url;
      url = String.Format(
          wxPorting.T("/Globals.traindir/server/nowplaying.php?u=%s&s=%s&d=%d"),
          user_name._sValue,
          fileName(current_project),
          run_day);
      bstreet_send(url);
    }


    public static void bstreet_getlinks() {
      //if(user_name._sValue.Length == 0)
      //  return;
      //wxHTTP get;
      //get.SetHeader(wxPorting._T("Content-type"), wxPorting._T("text/html; charset=utf-8"));
      //get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...

      //// this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
      //string url;
      //if(!get.Connect(wxPorting._T("www.backerstreet.com")))  // only the server, no pages here yet ...
      //  return;
      //url = String.Format(
      //    wxPorting.T("/Globals.traindir/server/links.php?scenario=%s"),
      //    fileName(current_project));
      //wxInputStream stream = get.GetInputStream(url);
      //String res;
      //wxStringOutputStream out_stream = new wxStringOutputStream(res);
      //stream.Read(out_stream);
      ////wx.MessageDialog.MessageBox(res);

      //string p = res;
      //// parse Path file
      //wxPorting.wxDELETE(stream);
      //get.Close();
    }

    public static void prepareTrainName(string dest, string src) {
      //int destIndex = 0;
      //while(src.length > 0) {
      //  if(src[0] == ' ') {
      //    dest.ReplaceAt(destIndex++, '%');
      //    dest.ReplaceAt(destIndex++, '2');
      //    dest.ReplaceAt(destIndex++, '0');
      //  } else
      //    dest.ReplaceAt(destIndex++, src[0]);
      //  src = src.Substring(1);
      //}
      //dest = dest.Substring(0, destIndex);
    }

    public static void bstreet_trainexited(Train trn) {
      //if(user_name._sValue.Length == 0)
      //  return;
      //long arrtime = trn.timeout;
      //if(arrtime < trn.timein)
      //  arrtime += 24 * 60 * 60;
      //long minlate = (current_time - arrtime) / 60;
      //string url;
      //string tname;
      //prepareTrainName(tname, trn.name);
      //url = String.Format(
      //    wxPorting.T("/Globals.traindir/server/exited.php?&s=%s&t=%s&f=%s&x=%d&d=%d&v=%d"),
      //    fileName(current_project),
      //    tname,
      //    (String.IsNullOrEmpty(trn.exited) == false) ? trn.exited : trn.exit,  // wrong exit or correct exit
      //    minlate,
      //    run_day,
      //    (int)trn.curspeed);
      //bstreet_send(url);
    }


    public static int bstreet_enterdelay(Train trn, out bool changed) {
      throw new NotImplementedException();
      //changed = false;
      //int delay = 0;
      //if(user_name._sValue.Length == 0)
      //  return 0;

      //string url;
      //string tname;
      //prepareTrainName(tname, trn.name);
      ////http://backerstreet.com/Globals.traindir/server/entering.php?s=bartSF.trk&t=01DCM2SUN_merged_2075&f=OAK1&d=64
      //url = String.Format(
      //    wxPorting.T("/Globals.traindir/server/entering.php?&s=%s&t=%s&f=%s&d=%d"),
      //    fileName(current_project),
      //    tname,
      //    trn.entrance,
      //    run_day);
      //wxHTTP get;
      //get.SetHeader(wxPorting._T("Content-type"), wxPorting._T("text/html; charset=utf-8"));
      //get.SetTimeout(10); // 10 seconds of timeout instead of 10 minutes ...

      //// this will wait until the user connects to the internet. It is important in case of dialup (or ADSL) connections
      //if(!get.Connect(wxPorting._T("www.backerstreet.com")))  // only the server, no pages here yet ...
      //  return 0;
      //wxInputStream stream = get.GetInputStream(url);
      //// we don't care about the result or any error
      //if(get.GetError() == wxPROTO_NOERR) {
      //  String res;
      //  wxStringOutputStream out_stream = new wxStringOutputStream(res);
      //  stream.Read(out_stream);
      //  //wx.MessageDialog.MessageBox(res);

      //  string line = res;
      //  string p;
      //  if((p = Globals.wxStrchr(line, '#'))) {
      //    delay = wxAtoi(p + 1);
      //    changed = true;
      //  }
      //}
      //wxPorting.wxDELETE(stream);
      //get.Close();
      //return delay;
    }
  }
}