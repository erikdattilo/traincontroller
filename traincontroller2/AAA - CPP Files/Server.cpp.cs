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
// #include "mongoose.h"
// #include "SwitchBoard.h"
// #include "Array.h"
// #include "Server.h"
// #include <wx/socket.h>
// #include <wx/file.h>
// #include <wx/stdpaths.h>
// 
// extern	int server_port;		// command/log port - defined in Main.cpp
// IntOption     http_server_port(wxT("httpPort"),
//                                wxT("Listen on this HTTP port"),
//                                wxT("Server"),
//                                wxT("8999"));
// BoolOption      http_server_enabled(wxT("httpServerEnabled"),
//                                     wxT("Enable listening for HTTP clients"),
//                                     wxT("Server"),
//                                     wxT("1"));
// 
// extern	Traindir *traindir;
// 
// Array<Servlet *> services;
// 
// 
// bool	start_web_server();
// void	stop_web_server();
// void	do_command(const wxChar *cmd, bool sendToClients);
// 
// class ServerThread : public wxThread
// {
// public:
// 	ServerThread();
// 	~ServerThread();
// 
// 	wxSocketBase *sock;
// 	ExitCode    Entry();
// };
// 
// ServerThread *serverThread;
// 
// ServerThread::ServerThread()
// {
// 	sock = 0;
// }
// 
// ServerThread::~ServerThread()
// {
// }
// 
// extern	void	post_command(wxChar *cmd);
// 
// void *ServerThread::Entry()
// {
// 	char	buff[1];
// 	wxChar	line[128];
// 	int	nxt;
// 
// 	wxIPV4address addr;
// 	addr.AnyAddress();
// 	addr.Service(server_port);
// 	wxSocketServer *srvr = new wxSocketServer(addr, wxSOCKET_REUSEADDR);
// 	while(true) {
// 	    sock = srvr->Accept();
// 	    if(sock != 0) {
// 		nxt = 0;
// 		while(true) {
// 		    sock->Read(buff, sizeof(buff));
// 		    if(sock->Error())
// 			break;
// 		    int n = sock->LastCount();
// 		    if(!n)
// 			continue;
// 		    if(buff[0] == 'r' || buff[0] == 'n') {
// 			if(!nxt)
// 			    continue;
// 			line[nxt] = 0;
// 			if(!wxStrcmp(line, wxT("quit"))) {
// 			    Exit(0);
// 			    return 0;
// 			}
// 			traindir->AddAlert(line);
// 			post_command(line);
// 			nxt = 0;
// 			continue;
// 		    }
// 		    if(nxt < sizeof(line) - 2)
// 			line[nxt++] = buff[0];
// 		}
// 		sock = 0;
// 	    }
// 	}
// 	printf("Done with thread.n");
// 	Exit(0);
// 	return 0;
// }
// 
// void	start_server_thread(void)
// {
//         wxSocketBase::Initialize();
// 
// 	serverThread = new ServerThread();
// 	serverThread->Create();
// 	serverThread->Run();
// 	start_web_server();
// }
// 
// void	kill_server_thread()
// {
// 	stop_web_server();
// 	if(!serverThread)
// 	    return;
// 	serverThread->Kill();
// 	//delete serverThread;
// }
// 
// void	send_msg(wxChar *msg)
// {
// 	if(!serverThread || !serverThread->sock || !serverThread->sock->IsConnected())
// 	    return;
// 	serverThread->sock->Write(msg, wxStrlen(msg));
// }
// 
// 
// void insert_file(wxString& str, const Char *fname)
// {
// 	Char  buff[1024];
//         TDFile file(fname);
// 
//         if(file.Load()) {
// 	    while(file.ReadLine(buff, sizeof(buff)/sizeof(buff[0]))) {
// 	        str.Append(buff);
// 	        str.Append(wxT("n"));
// 	    }
//         }
// }
// 
// void send_refresh(mg_connection *conn, wxChar *urlBase)
// {
//         wxString str;
// 
//         str.Append(wxT("<html><head>n"));
//         str.Append(wxT("<META HTTP-EQUIV="refresh" CONTENT="1;URL="));
//         str.Append(urlBase);
//         str.Append(wxT("">n"));
//         str.Append(wxT("</head><body>Refreshing...</body></html>n"));
//         const char *mimeType = "text/html";
//         char *content = strdup(str.mb_str(wxConvUTF8));
//         int contentLength = strlen(content);
//         mg_printf(conn, "HTTP/1.1 200 OKrn"
//                         "Cache: no-cachern"
//                         "Content-Type: %srn"
//                         "Content-Length: %drn"
//                         "rn",
//                         mimeType,
//                         contentLength);
//         mg_write(conn, content, contentLength);
//         free(content);
// }
// 
// volatile bool   server_command_done;
// 
// void    wait_command(Char *cmd)
// {
//         server_command_done = false;
//         post_command(cmd);
//         do {
// #ifdef __WXMAC__
// 	    usleep(100000);
// #else
//             Sleep(100);
// #endif
//         } while(!server_command_done);
// }
// 
// 
// Char *convToUCode(const char *p)
// {
// #ifdef __WXMAC__
// 	int i;
// 
//         wxWritableCharBuffer tmpMB(strlen(p) + 4);
//         if ((char *) tmpMB == NULL)
// 	    return 0;
//         char *buffer = tmpMB;
//         for(i = 0; *p; buffer[i++] = *p++);
//         buffer[i] = 0;
//         Char *content;
//         /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
//         if (! (content = wxConvAuto().cMB2WX(tmpMB).release()))
// 	    if (! (content = wxConvISO8859_1.cMB2WX(tmpMB).release()))
// 	        return 0;
//         return content;
// #else
//         return strdup(p);
// #endif
// }
// 
// //char    curdir[512];
// 
// void *event_handler(enum mg_event event,
// 	struct mg_connection *conn,
// 	const struct mg_request_info *request_info)
// {
// 	static void* done = (void *)"done";
// 	const char* mimeType = "text/plain";
// 	const char* content = "Not found";
// 	int contentLength = strlen(content);
//         wxString str;
// 	wxChar  buff[512];
// 
//         getcwd(buff, sizeof(buff));
// 
// //#ifndef __WXMAC__
// 	if (event == MG_NEW_REQUEST) {
// //	    traindir->AddAlert(request_info->uri);
// 	    if (strncmp(request_info->uri, "/switchboard/", 13) == 0) {
// 		if(strcmp(request_info->request_method, "GET") != 0) {
// error:
// 		    // send error (we only care about HTTP GET)
// 		    mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
// 			500,
// 			"we only care about HTTP GET",
// 			"we only care about HTTP GET");
// 		    // return not null means we handled the request
// 		    return done;
// 		}
// 
// 		const char *host = mg_get_header(conn, "Host");
// 
// 		wxChar  urlBase[512];
// 		wxChar  cmdBuff[512];
// 		Char *uri;
// 		uri = convToUCode(request_info->uri + 13);
// 	        if(!uri)
// 		    goto error;
// 		wxStrncpy(buff, uri, sizeof(buff)/sizeof(buff[0]));	// isolate switchboard name
// 		Char *p = wxStrchr(buff, wxT('/'));
// 		if(p)
// 		    *p = 0;
// 		// handle your GET request to /hello
// 		SwitchBoard *sw = FindSwitchBoard(buff);
// 		if(sw) {
// 		    Char *base = convToUCode(host);
// 		    wxSnprintf(urlBase, sizeof(urlBase)/sizeof(urlBase[0]), wxT("http://%s/switchboard/%s"), base, buff);
// 		    free(base);
// 		    const Char *p = uri;
// 		    p = wxStrchr(p, '/');
// 		    if(p) ++p;
// 	            if (p && wxStrncmp(p, wxT("command/"), 8) == 0) {
//                         do_command(p + 8, true);        // this is dangerous since we are not in the UI thread!
//                         send_refresh(conn, urlBase);
// 			free(uri);
//                         return done;
//                     }
// 		    if(p && *p) {
// 			Char *pp;
// 		        int x = wxStrtol(p, &pp, 10);
// 		        if(*pp == '/') ++pp;
// 		        int y = wxStrtol(pp, &pp, 10);
//                         wxSnprintf(cmdBuff, sizeof(cmdBuff)/sizeof(cmdBuff[0]), wxT("switch %d,%d %s"), x, y, buff);
//                         wait_command(cmdBuff);
// 		        //sw->Select(x, y);     // don't do this since we are not in the GUI thread
//                         send_refresh(conn, urlBase);
// 			free(uri);
//                         return done;
// 		    }
//                     if(request_info->query_string && request_info->query_string[0]) {
// 			p = convToUCode(request_info->query_string);
//                         if(*p == 'i' && p[1] == '=')
//                             p += 2;
//                         wxSnprintf(cmdBuff, sizeof(cmdBuff)/sizeof(cmdBuff[0]), wxT("switch '%s' %s"), p, buff);
//                         wait_command(cmdBuff);
//                         send_refresh(conn, urlBase);
// 			free(uri);
// 			free((void *)p);
//                         return done;
//                     }
// 		    //free(uri);
// 		    str.Append(wxT("<html>n"));
//                     insert_file(str, wxT("tdstyle.css"));
// 		    str.Append(wxT("<body>n"));
//                     ///insert_file(str, wxT("body_header.html"));
//                     wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]),
// 			wxT("<form name="iform" method="get" action="http://%s/switchboard/%s">"),
// 			host, sw->_fname.c_str(), sw->_name.c_str());
//                     str.Append(buff);
//                     str.Append(wxT("<input type="text" name="i"></form><br>n"));
// 		    SwitchBoard *ss;
// 		    str.Append(wxT("<ul class="navbar">n<br /><br />"));
// 		    for(ss = switchBoards; ss; ss = ss->_next) {
// 			if(!wxStrcmp(ss->_name.c_str(), sw->_name.c_str())) {
// 			    str.Append(wxT("<li class='selected'>"));
// 			    str.Append(ss->_name);
// 			    str.Append(wxT("</li>n"));
// 			} else {
// 			    str.Append(wxT("<li class='other'>"));
// 			    base = convToUCode(host);
// 			    wxString sss;
// 			    sss.Printf(wxT("<a href="http://%s/switchboard/%s">%s</a>"),
//                                 base, ss->_fname.c_str(), ss->_name.c_str());
// 			    str.Append(sss.c_str());
// 			    free(base);
// /*
// 			    wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]),
// 				wxT("<a href="http://%s/switchboard/%s">%s</a>"),
// 				host, ss->_fname.c_str(), ss->_name.c_str());
// 			    str.Append(buff);
// */
// 			    str.Append(wxT("</li>n"));
// 			}
// 		    }
// 		    str.Append(wxT("</ul>n"));
// 		    sw->toHTML(str, urlBase);
// //		    str.Append(wxT("<p><a href=""));
// //		    str.Append(urlBase);
// //		    str.Append(wxT("">Refresh</a>n"));
//                     ///insert_file(str, wxT("body_footer.html"));
//                    // str.Append(wxT("<body OnLoad="document.iform.i.focus();">n"));
// 		   // str.Append(wxT("</body></html>n"));
//                     ///str.Append(wxT("<body>n"));
//                     ///str.Append(wxT("</body>n"));
// 		    mimeType = "text/html";
// 		    content = strdup(str.mb_str(wxConvUTF8));
// 		    contentLength = strlen(content);
// 		}
// 		mg_printf(conn,
// 		    "HTTP/1.1 200 OKrn"
// 		    "Cache: no-cachern"
// 		    "Content-Type: %srn"
// 		    "Content-Length: %drn"
// 		    "rn",
// 		    mimeType,
// 		    contentLength);
// 		mg_write(conn, content, contentLength);
// 		if(sw)
// 		    free((void *)content);
// 		return done;
// 	    }
// 	    // in this example i only handle /hello
// //	    mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
// //		500, /* This the error code you want to send back*/
// //		"Invalid Request.",
// //		"Invalid Request.");
// //	    return done;
//             Servlet *s;
//             int i;
//             for(i = 0; i < services.Length(); ++i) {
//                 s = services.At(i);
//                 if(!strncmp(request_info->uri, s->_path, strlen(s->_path))) {
// 		    Char *uri = 0;
//                     if(request_info->query_string) {
//                         uri = convToUCode(request_info->query_string);
// 	                if(!uri)
// 		            goto error;
// 		        wxStrncpy(buff, uri, sizeof(buff)/sizeof(buff[0]));
//                     } else
//                         buff[0] = 0;
// 		    if(!strcmp(request_info->request_method, "GET")) {
//                         if(!s->get(str, buff)) {
//                             goto error;
//                         }
//                         /*
//                         sprintf(buff, "C:\eclipse-js\workspace\TrainDirectorClient\%s", request_info->uri);
//                         FILE *fp = fopen(buff, "w");
//                         if(fp) {
//                             fwrite(str.c_str(), 1, str.length(), fp);
//                             fclose(fp);
//                         }
//                         return 0;
//                         */
//                     } else if(!strcmp(request_info->request_method, "POST")) {
//                         if(!s->post(str, buff)) {
//                             goto error;
//                         }
//                     } else {
// 		        // send error (we only care about HTTP GET and POST
// bad_method:
// 		        mg_printf(conn, "HTTP/1.1 %d Error (%s)rnrn%s",
// 			    405,
// 			    "Method not allowed",
// 			    "Method not allowed");
// 		        // return not null means we handled the request
// 		        return done;
//                     }
// 	            mimeType = s->getMimeType();
// 	            content = strdup(str.mb_str(wxConvUTF8));
// 	            contentLength = strlen(content);
//                     mimeType = "text/plain";
// #if 0
//                     mg_printf(conn,
// 		        "HTTP/1.1 206 Partial Contentrn"
// 		        "Cache: no-cachern"
// 		        "Content-Type: %srn"
//                         "Access-Control-Allow-Origin: *rn"
//                         "Content-Range: 10/100"
//                         "Content-Length: %drn"
// 		        "rn",
// 		        mimeType,
// 		        contentLength);
// 		    mg_write(conn, content, contentLength);
//                     wxSleep(10);
// #endif
// 		    mg_printf(conn,
// 		        "HTTP/1.1 200 OKrn"
// 		        "Cache: no-cachern"
// 		        "Content-Type: %srn"
//                         "Access-Control-Allow-Origin: *rn"
//                         "Content-Length: %drn"
// 		        "rn",
// 		        mimeType,
// 		        contentLength);
// 		    mg_write(conn, content, contentLength);
// 	            free((void *)content);
// 		    return done;
//                 }
//             }
// 	}
// //#endif
// 
// 	// No suitable handler found, mark as not processed. Mongoose will
// 	// try to serve the request.
// 	return NULL;
// }
// 
// /* Initialize HTTP layer */
// static struct mg_context *ctx;
// 
// bool	start_web_server()
// {
//         char port_number[20];
// 	/* Default options for the HTTP server */
// 	const char *options[] = {
// 	    "listening_ports", "8081",
// 	    "num_threads", "2",
// ////	    "enable_keep_alive", "yes",
//             "document_root", "C:\TrainDir",
// 	    NULL
// 	};
// 
//         const Char *root;
//         wxString rootStr = wxStandardPaths::Get().GetExecutablePath();
//         root = rootStr.c_str();
//         if(wxGetenv(wxT("TDHOME"))) {
// 	    root = wxGetenv(wxT("TDHOME"));
//         }
//         options[5] = strdup(root);
//         Char *p = (Char *)strstr(options[5], "\traindir3.exe");
//         if(p)
//             *p = 0;
//         sprintf(port_number, "%d", http_server_port._iValue);
//         options[1] = port_number;
// //        options[5] = "C:\eclipse-js\workspace\TrainDirectorClient";
// 	ctx = mg_start(&event_handler, NULL, options);
// 	if(ctx == NULL) {
// 	    return false;
// 	}
// 	return true;
// }
// 
// void	stop_web_server() {
// 	if(ctx)
// 	    mg_stop(ctx);
// }
// 
// 
// 
// //
// //
// //
// 
// void    registerWebService(Servlet *s)
// {
//         services.Add(s);
// }
// 
// Servlet::Servlet(const char *path)
// {
//         _path = strdup(path);
//         registerWebService(this);
// }
// 
// Servlet::~Servlet()
// {
//         free((void *)_path);
// }
// 
// void    Servlet::json(wxString& out, const wxChar *field, const wxChar *value, bool last)
// {
//         wxString    str;
//         str.Printf(wxT(""%s": "%s""), field, value);
//         out.append(str);
//         out.append(last ? wxT("n") : wxT(",n"));
// }
// 
// void    Servlet::json(wxString& out, const wxChar *field, int value, bool last)
// {
//         wxString    str;
//         str.Printf(wxT(""%s": "%d""), field, value);
//         out.append(str);
//         out.append(last ? wxT("n") : wxT(",n"));
// }
