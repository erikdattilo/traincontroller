using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDirPorting {
  [Flags]
  public enum RunDays {
    None = 0x0,
    Monday = 0x1,
    Tuesday = 0x2,
    Wednesday = 0x4,
    Thursday = 0x8,
    Friday = 0x10,
    Saturday = 0x20,
    Sunday = 0x40
  }

  public class wxHelpProvider {
    internal static void Set(int p) {
      throw new NotImplementedException();
    }
  }

  public class wxNumberEntryDialog {
    public wxNumberEntryDialog(Canvas canvas, string p, string p_3, string p_4, int p_5, int p_6, int p_7) {
      throw new NotImplementedException();
    }

  }

  public static class OperatorsOverload {
    public static void Append(this String str, String str2) {
      str += str2;
    }
    public static void append(this String str, String str2) {
      str += str2;
    }
    public static int length(this String str) {
      return str.Length;
    }

    public static String incPointer(this String str)
    {
      return str.Substring(1);
    }
  }

  public class wxIPV4address {
    internal void Hostname(string _host) {
      throw new NotImplementedException();
    }

    internal void Service(int _port) {
      throw new NotImplementedException();
    }
  }

  public class wxTextFile {
    internal void Write(int p) {
      throw new NotImplementedException();
    }

    internal void Close() {
      throw new NotImplementedException();
    }

    internal bool Open(string fname) {
      throw new NotImplementedException();
    }

    internal void Clear() {
      throw new NotImplementedException();
    }

    internal bool Create(string fname) {
      throw new NotImplementedException();
    }

    internal int GetLineCount() {
      throw new NotImplementedException();
    }
  }

  public class wxSocketClient {
    internal bool Connect(wxIPV4address addr, bool p) {
      throw new NotImplementedException();
    }

    internal void Read(string buff, int p) {
      throw new NotImplementedException();
    }

    internal bool Error() {
      throw new NotImplementedException();
    }

    internal int LastCount() {
      throw new NotImplementedException();
    }

    internal bool IsConnected() {
      throw new NotImplementedException();
    }

    internal void Write(string cmd, int p) {
      throw new NotImplementedException();
    }
  }

  public class wxThread {
  }

  public class wxSound {
    public const int wxSOUND_SYNC = 1;
    public const int wxSOUND_ASYNC = 2;

    public void Create(string p) {
      throw new NotImplementedException();
    }

    public bool Ok {
      get {
        throw new NotImplementedException();
      }
    }

    internal void Play(int p) {
      throw new NotImplementedException();
    }
  }

  public class wxFFile {
    internal bool Open(string buff, string p) {
      throw new NotImplementedException();
    }

    internal void Close() {
      throw new NotImplementedException();
    }

    internal void Write(string txt) {
      throw new NotImplementedException();
    }

    internal bool IsOpened() {
      throw new NotImplementedException();
    }
  }

  public class wxCriticalSection {
    internal void Enter() {
      throw new NotImplementedException();
    }

    internal void Leave() {
      throw new NotImplementedException();
    }
  }

  public enum wxLogLevel {
  }

  public class time_t {
  }

  public class Timer {
    public Timer(MainFrame mainFrame, MenuIDs menuIDs) {
      throw new NotImplementedException();
    }

    internal void Start(int p) {
      throw new NotImplementedException();
    }
  }

  public class wxInputStream {
    internal void Read(wxStringOutputStream out_stream) {
      throw new NotImplementedException();
    }
  }
  public class wxStringOutputStream {
    public wxStringOutputStream(String res) {

    }
  }
  public class wxHTTP {
    internal wxInputStream GetInputStream(string url) {
      throw new NotImplementedException();
    }

    internal void SetHeader(object p, object p_2) {
      throw new NotImplementedException();
    }

    internal void SetTimeout(int p) {
      throw new NotImplementedException();
    }

    internal bool Connect(object p) {
      throw new NotImplementedException();
    }

    internal void Close() {
      throw new NotImplementedException();
    }

    internal object GetError() {
      throw new NotImplementedException();
    }
  }

  public class FontPool {
    internal int size() {
      throw new NotImplementedException();
    }
  }

  public class TDString {
    public static implicit operator TDString(string str) {
      return new TDString();
    }
    public static implicit operator string(TDString str) {
      return "";
    }
  }

  public class TextFile {
    internal void Write(int p) {
      throw new NotImplementedException();
    }

    internal void Close() {
      throw new NotImplementedException();
    }

    internal bool Open(string fname) {
      throw new NotImplementedException();
    }

    internal void Clear() {
      throw new NotImplementedException();
    }

    internal bool Create(string fname) {
      throw new NotImplementedException();
    }

    internal int GetLineCount() {
      throw new NotImplementedException();
    }

    internal void AddLine(string buff) {
      throw new NotImplementedException();
    }
  }

  public class wxSocketBase {
    internal static void Initialize() {
      throw new NotImplementedException();
    }
  }

  public class mg_connection {
  }

  public class mg_event {
  }

  public class mg_request_info {
  }

  public class mg_context {
  }

  public class TDLayout {
  }

  //public class Point {
  //}

  public class wxSemaphore {
    public wxSemaphore(int a, int b) {
    }

    internal wxSemaError WaitTimeout(int p) {
      throw new NotImplementedException();
    }

    internal void Post() {
    }
  }

  public class wxSemaError {
  }

  public class wxFileName {
    public static implicit operator String(wxFileName fname) {
      throw new NotImplementedException();
    }

    public wxFileName(String fname) {
      throw new NotImplementedException();
    }

    internal string GetPath() {
      throw new NotImplementedException();
    }

    internal string GetExt() {
      throw new NotImplementedException();
    }

    internal string GetName() {
      throw new NotImplementedException();
    }

    internal object GetFullPath() {
      throw new NotImplementedException();
    }
  }

  public class size_t {
  }

  public class FILE {
  }

  public class Pos {
  }

  //public interface Icomparer {
  //}

  public static class ExtensionMethods {
    public static string find(this string str, char ch) {
      throw new NotImplementedException();
    }
    public static bool empty(this string str) {
      throw new NotImplementedException();
    }
    public static void ReplaceAt(this string str, int index, char newChar) {
      // If index > Length => append!
      // str[index] = newChar;
    }
    public static bool CmpNoCase(this string str, string str2) {
      return false;
    }
  }

  public static partial class Globals {
    public static int stderr = 0;
    public static int argc = 0;
    public static String[] argv = new string[0];
    public static String wxEmptyString { get { return "wxEmptyString"; } }
    public static String __DATE__ { get { return "__DATE__"; } }

    public static void wxPrintf(params object[] list) {
      throw new NotImplementedException();
    }
    public static void wxSprintf(params object[] list) {
      throw new NotImplementedException();
    }
    public static byte wxStrtoul(params object[] list) {
      throw new NotImplementedException();
    }
    public static void wxFprintf(params object[] paramList) {
      throw new NotImplementedException();
    }
    public static void fprintf(params object[] list) {
    }
    public static int wxAtoi(string result) {
      throw new NotImplementedException();
    }

    public static int wxStrtol(string s, ref string p, int p_3) {
      throw new NotImplementedException();
    }

    public static object time(int p) {
      throw new NotImplementedException();
    }

    public static void srand(object p) {
      throw new NotImplementedException();
    }


    // bool ==> int result; return (result != 0)
    public static int wxStrcmp(string oldTooltip, string p) {
      throw new NotImplementedException();
    }

    private static string strdup(string cbuff) {
      throw new NotImplementedException();
    }

    public static int sscanf(params object[] list) {
      throw new NotImplementedException();
    }
    
    public static void strcpy(string p, string buff) {
      throw new NotImplementedException();
    }

    public static object calloc(int p) {
      throw new NotImplementedException();
    }

    public static T1[] calloc<T1>(int num_listed_trains) {
      throw new NotImplementedException();
    }

    public static object calloc(int p, int q) {
      throw new NotImplementedException();
    }

    public static string wxStrdup(string p) {
      throw new NotImplementedException();
    }

    public static void wxStrcat(string url, string p) {
      throw new System.NotImplementedException();
    }

    public static int wxStrncmp(string args, string p, int p_3) {
      throw new NotImplementedException();
    }

    public static int wxStrlen(string b) {
      throw new NotImplementedException();
    }

    public static void free(object p) {
    }

    public static void delete(object p) {
    }


    internal static Train[] realloc(ref Train[] assign_list, int maxassign) {
      throw new NotImplementedException();
    }

    internal static string wxStrrchr(string buff, char p) {
      throw new NotImplementedException();
    }

    internal static int strncmp(string p, string var, int p_3) {
      throw new NotImplementedException();
    }

    internal static int atoi(string p) {
      throw new NotImplementedException();
    }
  }

  public class wxFile {
    internal static bool Exists(string fname) {
      throw new NotImplementedException();
    }
  }

  public class wxPorting {
    public static int wxTextFileType_Dos { get { return 0; } }
    public String wxEmptyString { get { throw new NotImplementedException(); } }
    public static string T(string str) {
      return string.Copy(str);
    }

    public static char T(char ch) {
      return ch;
    }

    public static string L(string str) {
      return string.Copy(str);
    }

    public static string LV(string str) {
      return string.Copy(str);
    }



    internal static void wxInitAllImageHandlers() {
      throw new NotImplementedException();
    }

    internal static String wxGetenv(string p) {
      throw new NotImplementedException();
    }

    internal static void wxSetWorkingDirectory(string p) {
      throw new NotImplementedException();
    }

    internal static bool wxMkdir(string path) {
      throw new NotImplementedException();
    }

    internal static bool wxDirExists(string path) {
      throw new NotImplementedException();
    }

    internal static void wxHandleFatalExceptions(bool p) {
      throw new NotImplementedException();
    }

    internal static void wxPrintf(string p, string _host) {
      throw new NotImplementedException();
    }

    internal static object _T(string p) {
      throw new NotImplementedException();
    }

    internal static void wxSleep(int p) {
      throw new NotImplementedException();
    }

    internal static bool wxIsdigit(char p) {
      throw new NotImplementedException();
    }

    internal static void wxDELETE(wxInputStream httpStream) {
      throw new NotImplementedException();
    }

    internal static string wxStrrchr(string p, char p_2) {
      throw new NotImplementedException();
    }

    internal static void wxLaunchDefaultBrowser(string url) {
      throw new NotImplementedException();
    }
  }

}
