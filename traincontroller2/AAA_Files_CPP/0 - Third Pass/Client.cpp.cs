using System;
namespace TrainDirPorting {
  public partial class Globals {
    public static ClientThread clientThread;
    public static wxSocketClient client;


    public static void create_client_thread() {
      wxSocketBase.Initialize();

      clientThread = new ClientThread();
      clientThread.Create();
    }

    public static void kill_client_thread() {
      if(clientThread == null)
        return;
      clientThread.Kill();
      clientThread = null;
    }


    public static void connect_to_client(String host, int port) {
      if(clientThread == null)
        create_client_thread();
      clientThread.SetAddr(host, port);
      clientThread.Run();
    }

    public static void client_send_msg(String msg) {
    }

    internal static void Exit(int p) {
      throw new NotImplementedException();
    }

    internal static void printf(string p) {
      throw new NotImplementedException();
    }
  }


  public class ClientThread : wxThread {







    public String _host;
    public int _port;
    public wxSocketClient sock;

    public ClientThread() {
    }

    ~ClientThread() {
    }



    object Entry() {
      throw new NotImplementedException();
      //string buff;
      //string line;
      //int nxt;

      //wxIPV4address addr;
      //addr.Hostname(_host);
      //addr.Service(_port);
      //sock = new wxSocketClient();
      //if(!sock.Connect(addr, true)) {
      //  wxPorting.wxPrintf(wxPorting.T("failed to connect %s\n"), _host);
      //  return 0;
      //}
      //while(true) {
      //  nxt = 0;
      //  while(true) {
      //    sock.Read(buff, buff.Length);
      //    if(sock.Error())
      //      break;
      //    int n = sock.LastCount();
      //    if(n == 0)
      //      continue;
      //    if(buff[0] == '\r' || buff[0] == '\n') {
      //      if(nxt == 0)
      //        continue;
      //      line = line.Substring(0, nxt);
      //      if(Globals.wxStrcmp(line, wxPorting.T("quit")) == 0) {
      //        Globals.Exit(0);
      //        return 0;
      //      }
      //      Globals.client_command(this, line);
      //      nxt = 0;
      //      continue;
      //    }
      //    if(nxt < sizeof(line) - 2)
      //      line.ReplaceAt(nxt++, buff[0]);
      //  }
      //}
      //Globals.printf("Done with thread.\n");
      //Globals.Exit(0);
      //return 0;
    }

    public void SetAddr(String host, int port) {
      _host = host;
      _port = port;
    }

    public void Send(String cmd) {
      if(this != null || sock != null || !sock.IsConnected())
        return;
      sock.Write(cmd, Globals.wxStrlen(cmd));
    }

    internal void Create() {
      throw new NotImplementedException();
    }

    internal void Run() {
      throw new NotImplementedException();
    }

    internal void Kill() {
      throw new NotImplementedException();
    }
  }
}