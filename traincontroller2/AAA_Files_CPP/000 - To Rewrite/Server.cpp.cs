using System;
namespace Traincontroller2 {
  public static partial class Globals {
    public static IntOption http_server_port = new IntOption(wxPorting.T("httpPort"),
                                   wxPorting.T("Listen on this HTTP port"),
                                   wxPorting.T("Server"),
                                   wxPorting.T("8999"));
    public static BoolOption http_server_enabled = new BoolOption(wxPorting.T("httpServerEnabled"),
                                        wxPorting.T("Enable listening for HTTP clients"),
                                        wxPorting.T("Server"),
                                        wxPorting.T("1"));

    public static Servlet[] services;
    public static ServerThread serverThread;



  }

  public class ServerThread : wxThread {
    public wxSocketBase sock;

    public ServerThread() {
    }

    public object Entry() {
      throw new NotImplementedException();
      //string buff; // char	buff[1];
      //string line; // char	line[128];
      //int nxt;

      //wxIPV4address addr = new wxIPV4address();
      //addr.AnyAddress();
      //addr.Service(server_port);
      //wxSocketServer srvr = new wxSocketServer(addr, wxSOCKET_REUSEADDR);
      //while(true) {
      //  sock = srvr.Accept();
      //  if(sock != 0) {
      //    nxt = 0;
      //    while(true) {
      //      sock.Read(buff, sizeof(buff));
      //      if(sock.Error())
      //        break;
      //      int n = sock.LastCount();
      //      if(!n)
      //        continue;
      //      if(buff[0] == 'r' || buff[0] == 'n') {
      //        if(!nxt)
      //          continue;
      //        line[nxt] = 0;
      //        if(!wxStrcmp(line, wxPorting.T("quit"))) {
      //          Exit(0);
      //          return 0;
      //        }
      //        Globals.traindir.AddAlert(line);
      //        post_command(line);
      //        nxt = 0;
      //        continue;
      //      }
      //      if(nxt < sizeof(line) - 2)
      //        line[nxt++] = buff[0];
      //    }
      //    sock = 0;
      //  }
      //}
      //printf("Done with thread.n");
      //Exit(0);
      //return 0;
    }

    public static void start_server_thread() {
      //wxSocketBase.Initialize();

      //serverThread = new ServerThread();
      //serverThread.Create();
      //serverThread.Run();
      //start_web_server();
    }

    public static void kill_server_thread() {
      //stop_web_server();
      //if(!serverThread)
      //  return;
      //serverThread.Kill();
    }

    public static void send_msg(String msg) {
      //if(!serverThread || !serverThread.sock || !serverThread.sock.IsConnected())
      //  return;
      //serverThread.sock.Write(msg, Globals.wxStrlen(msg));
    }


    public static void insert_file(String str, string fname) {
      //string buff;
      //TDFile file = new TDFile(fname);

      //if(file.Load()) {
      //  while(file.ReadLine(buff)) {
      //    str.Append(buff);
      //    str.Append(wxPorting.T("n"));
      //  }
      //}
    }

    public static void send_refresh(mg_connection conn, String urlBase) {
      //String str;

      //str.Append(wxPorting.T("<html><head>n"));
      //str.Append(wxPorting.T("<META HTTP-EQUIV=\"refresh\" CONTENT=\"1;URL="));
      //str.Append(urlBase);
      //str.Append(wxPorting.T("\">n"));
      //str.Append(wxPorting.T("</head><body>Refreshing...</body></html>\n"));
      //string mimeType = "text/html";
      //string content = strdup(str.mb_str(wxConvUTF8));
      //int contentLength = strlen(content);
      //mg_printf(conn, "HTTP/1.1 200 OK\r\n" +
      //                "Cache: no-cache\r\n" +
      //                "Content-Type: %s\r\n" +
      //                "Content-Length: %d\r\n" +
      //                "\r\n",
      //                mimeType,
      //                contentLength);
      //mg_write(conn, content, contentLength);
      //Globals.free(content);
    }

    public static bool server_command_done;

    public static void wait_command(string cmd) {
//      server_command_done = false;
//      post_command(cmd);
//      do {
//#if __WXMAC__
//      usleep(100000);
//#else
//        Sleep(100);
//#endif
//      } while(!server_command_done);
    }


    public static string convToUCode(string p) {
      throw new NotImplementedException();
//#if __WXMAC__
//  int i;
 
//         wxWritableCharBuffer tmpMB(strlen(p) + 4);
//         if ((string ) tmpMB == null)
//      return 0;
//         string buffer = tmpMB;
//         for(i = 0; *p; buffer[i++] = *p.incPointer());
//         buffer[i] = 0;
//         string content;
//         /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
//         if (! (content = wxConvAuto().cMB2WX(tmpMB).release()))
//      if (! (content = wxConvISO8859_1.cMB2WX(tmpMB).release()))
//          return 0;
//         return content;
//#else
//      return strdup(p);
//#endif
    }

    public object event_handler(mg_event evt, mg_connection conn, mg_request_info request_info)
 {
      throw new NotImplementedException();
 // string event_handler_done = "done";
 // string  mimeType = "text/plain";
 // string  content = "Not found";
 // int contentLength = strlen(content);
 //        String str;
 // string buff;
 
 //        getcwd(buff, sizeof(buff));
 
 // if (evt == MG_NEW_REQUEST) {
 //     if (strncmp(request_info.uri, "/switchboard/", 13) == 0) {
 //   if(strcmp(request_info.request_method, "GET") != 0) {
 //error:
 //       // send error (we only care about HTTP GET)
 //       mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
 //     500,
 //     "we only care about HTTP GET",
 //     "we only care about HTTP GET");
 //       // return not null means we handled the request
 //       return done;
 //   }
 
 //   string host = mg_get_header(conn, "Host");
 
 //   string urlBase;
 //   string cmdBuff;
 //   string uri;
 //   uri = convToUCode(request_info.uri + 13);
 //         if(!uri)
 //       goto error;
 //   buff = string.Copy(uri);	// isolate switchboard name
 //   string p = wxStrchr(buff, wxPorting.T('/'));
 //   if(p)
 //       *p = 0;
 //   // handle your GET request to /hello
 //   SwitchBoard *sw = FindSwitchBoard(buff);
 //   if(sw) {
 //       string base_ = convToUCode(host);
 //       urlBase = string.Format(wxPorting.T("http://%s/switchboard/%s"), base_, buff);
 //       Globals.free(base_);
 //       string p = uri;
 //       p = wxStrchr(p, '/');
 //       if(p) p.incPointer();
 //             if (p && Globals.wxStrncmp(p, wxPorting.T("command/"), 8) == 0) {
 //                        do_command(p + 8, true);        // this is dangerous since we are not in the UI thread!
 //                        send_refresh(conn, urlBase);
 //     Globals.free(uri);
 //                        return done;
 //                    }
 //       if(p && *p) {
 //     string pp;
 //           int x = wxStrtol(p, &pp, 10);
 //           if(*pp == '/') ++pp;
 //           int y = wxStrtol(pp, &pp, 10);
 //                        cmdBuff = string.Format(wxPorting.T("switch %d,%d %s"), x, y, buff);
 //                        wait_command(cmdBuff);
 //           //sw.Select(x, y);     // don't do this since we are not in the GUI thread
 //                        send_refresh(conn, urlBase);
 //     Globals.free(uri);
 //                        return done;
 //       }
 //                    if(request_info.query_string && request_info.query_string[0]) {
 //     p = convToUCode(request_info.query_string);
 //                        if(p[0] == 'i' && p[1] == '=')
 //                            p += 2;
 //                        cmdBuff = string.Format(wxPorting.T("switch '%s' %s"), p, buff);
 //                        wait_command(cmdBuff);
 //                        send_refresh(conn, urlBase);
 //     Globals.free(uri);
 //     Globals.free((void *)p);
 //                        return done;
 //                    }
 //       //Globals.free(uri);
 //       str.Append(wxPorting.T("<html>n"));
 //                    insert_file(str, wxPorting.T("tdstyle.css"));
 //       str.Append(wxPorting.T("<body>n"));
 //                    ///insert_file(str, wxPorting.T("body_header.html"));
 //                    buff = String.Format(
 //     wxPorting.T("<form name=\"iform\" method=\"get\" action=\"http://%s/switchboard/%s\">"),
 //     host, sw._fname, sw._name);
 //                    str.Append(buff);
 //                    str.Append(wxPorting.T("<input type=\"text\" name=\"i\"></form><br>\n"));
 //       SwitchBoard *ss;
 //       str.Append(wxPorting.T("<ul class=\"navbar\">\n<br /><br />"));
 //       for(ss = switchBoards; ss; ss = ss._next) {
 //     if(!wxStrcmp(ss._name, sw._name)) {
 //         str.Append(wxPorting.T("<li class='selected'>"));
 //         str.Append(ss._name);
 //         str.Append(wxPorting.T("</li>\n"));
 //     } else {
 //         str.Append(wxPorting.T("<li class='other'>"));
 //         base_ = convToUCode(host);
 //         String sss;
 //         sss = String.Format(wxPorting.T("<a href=\"http://%s/switchboard/%s\">%s</a>"),
 //                                base_, ss._fname, ss._name);
 //         str.Append(sss);
 //         Globals.free(base_);
 ///*
 //         buff = String.Format(
 //       wxPorting.T("<a href="http://%s/switchboard/%s">%s</a>"),
 //       host, ss._fname, ss._name);
 //         str.Append(buff);
 //*/
 //         str.Append(wxPorting.T("</li>n"));
 //     }
 //       }
 //       str.Append(wxPorting.T("</ul>n"));
 //       sw.toHTML(str, urlBase);
 ////		    str.Append(wxPorting.T("<p><a href=""));
 ////		    str.Append(urlBase);
 ////		    str.Append(wxPorting.T("">Refresh</a>n"));
 //                    ///insert_file(str, wxPorting.T("body_footer.html"));
 //                   // str.Append(wxPorting.T("<body OnLoad="document.iform.i.focus();">n"));
 //      // str.Append(wxPorting.T("</body></html>n"));
 //                    ///str.Append(wxPorting.T("<body>n"));
 //                    ///str.Append(wxPorting.T("</body>n"));
 //       mimeType = "text/html";
 //       content = strdup(str.mb_str(wxConvUTF8));
 //       contentLength = strlen(content);
 //   }
 //   mg_printf(conn,
 //       "HTTP/1.1 200 OK\r\n" +
 //       "Cache: no-cache\r\n" +
 //       "Content-Type: %s\r\n" +
 //       "Content-Length: %d\r\n" +
 //       "\r\n",
 //       mimeType,
 //       contentLength);
 //   mg_write(conn, content, contentLength);
 //   if(sw)
 //       Globals.free((void *)content);
 //   return done;
 //     }
 //     // in this example i only handle /hello
 ////	    mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
 ////		500, /* This the error code you want to send back*/
 ////		"Invalid Request.",
 ////		"Invalid Request.");
 ////	    return done;
 //            Servlet *s;
 //            int i;
 //            for(i = 0; i < services.Length(); ++i) {
 //                s = services.At(i);
 //                if(!strncmp(request_info.uri, s._path, strlen(s._path))) {
 //       string uri = 0;
 //                    if(request_info.query_string) {
 //                        uri = convToUCode(request_info.query_string);
 //                 if(!uri)
 //               goto error;
 //           buff = string.Copy(uri);
 //                    } else
 //                        buff[0] = 0;
 //       if(!strcmp(request_info.request_method, "GET")) {
 //                        if(!s.get(str, buff)) {
 //                            goto error;
 //                        }
 //                        /*
 //                        sprintf(buff, "C:\eclipse-js\workspace\TrainDirectorClient\%s", request_info.uri);
 //                        FILE *fp = fopen(buff, "w");
 //                        if(fp) {
 //                            fwrite(str, 1, str.length(), fp);
 //                            fclose(fp);
 //                        }
 //                        return 0;
 //                        */
 //                    } else if(!strcmp(request_info.request_method, "POST")) {
 //                        if(!s.post(str, buff)) {
 //                            goto error;
 //                        }
 //                    } else {
 //           // send error (we only care about HTTP GET and POST
 //bad_method:
 //           mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
 //         405,
 //         "Method not allowed",
 //         "Method not allowed");
 //           // return not null means we handled the request
 //           return done;
 //                    }
 //             mimeType = s.getMimeType();
 //             content = strdup(str.mb_str(wxConvUTF8));
 //             contentLength = strlen(content);
 //                    mimeType = "text/plain";
 //#if false
 //                    mg_printf(conn,
 //           "HTTP/1.1 206 Partial Content\r\n" +
 //           "Cache: no-cache\r\n" +
 //           "Content-Type: %s\r\n" +
 //                        "Access-Control-Allow-Origin: *\r\n" +
 //                        "Content-Range: 10/100" +
 //                        "Content-Length: %d\r\n" +
 //           "\r\n",
 //           mimeType,
 //           contentLength);
 //       mg_write(conn, content, contentLength);
 //                    wxSleep(10);
 //#endif
 //       mg_printf(conn,
 //           "HTTP/1.1 200 OK\r\n" +
 //           "Cache: no-cache\r\n" +
 //           "Content-Type: %s\r\n" +
 //                        "Access-Control-Allow-Origin: *\r\n" +
 //                        "Content-Length: %d\r\n" +
 //           "\r\n",
 //           mimeType,
 //           contentLength);
 //       mg_write(conn, content, contentLength);
 //             Globals.free((void *)content);
 //       return done;
 //                }
 //            }
 // }
 ////#endif
 
 // // No suitable handler found, mark as not processed. Mongoose will
 // // try to serve the request.
 // return null;
 }

    /* Initialize HTTP layer */
    static mg_context ctx;

    public static bool start_web_server() {
      throw new NotImplementedException();
 //     string port_number;
 //     /* Default options for the HTTP server */
 //     string[] options = new string[]{
 //     "listening_ports", "8081",
 //     "num_threads", "2",
 //////	    "enable_keep_alive", "yes",
 //            "document_root", "C:\\TrainDir",
 //     null
 // };

 //     string root;
 //     String rootStr = wxStandardPaths.Get().GetExecutablePath();
 //     root = rootStr;
 //     if(wxGetenv(wxPorting.T("TDHOME"))) {
 //       root = wxGetenv(wxPorting.T("TDHOME"));
 //     }
 //     options[5] = strdup(root);
 //     string p = (string)strstr(options[5], "\\traindir3.exe");
 //     if(p)
 //       *p = 0;
 //     sprintf(port_number, "%d", http_server_port._iValue);
 //     options[1] = port_number;
 //     //        options[5] = "C:\eclipse-js\workspace\TrainDirectorClient";
 //     ctx = mg_start(&event_handler, null, options);
 //     if(ctx == null) {
 //       return false;
 //     }
 //     return true;
    }

    public static void stop_web_server() {
      //if(ctx)
      //  mg_stop(ctx);
    }



    //
    //
    //

    public static void registerWebService(Servlet s) {
      //services.Add(s);
    }
  }

  public class Servlet {
    public static string MIME_TEXT = "text/plain";
    public static string MIME_HTML = "text/html";
    public static string MIME_XML = "text/xml";
    public static string MIME_JSON = "application/json";

    public virtual string getMimeType() { return MIME_TEXT; }
    public virtual bool get(String out_, String url) { return false; }
    public bool post(String out_, String url) { return false; }
    public void json(String out_, String field, String value) {
      json(out_, field, value, false);
    }
    public void json(String out_, String field, int value) {
      json(out_, field, value, false);
    }

    public string _path;

    public Servlet(string path) {
      //_path = strdup(path);
      //registerWebService(this);
    }

    ~Servlet() {
      Globals.free(_path);
    }

    public void json(String out_, String field, String value, bool last) {
      String str;
      str = String.Format(wxPorting.T("\"%s\": \"%s\""), field, value);
      out_.append(str);
      out_.append(last ? wxPorting.T("n") : wxPorting.T(",n"));
    }

    public void json(String out_, String field, int value, bool last) {
      String str;
      str = String.Format(wxPorting.T("\"%s\": \"%d\""), field, value);
      out_.append(str);
      out_.append(last ? wxPorting.T("n") : wxPorting.T(",n"));
    }
  }
}