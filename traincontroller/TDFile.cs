using System;
using System.Collections.Generic;
using System.Text;
using wx;
using wx.Archive;
using System.IO;

namespace TrainDirNET {

  public class FileOption : Option {
    public FileOption(string name, string descr, string cat, string defValue)
      : base(OptionType.OPTION_FILE, name, descr, cat, defValue) {
    }
  }

  public class TDFile {
    public string name = "";
    public char[] content = new char[0];
    public char[] nextChar = new char[0];
    int size = 0;

    public TDFile(string fname) {
      name = string.Copy(fname);
    }

    public bool Load() {
      if(!GlobalFunctions.LoadFile(name, out content))
        return false;

      size = content.Length;
      nextChar = content;
      return true;
    }

    //private int LineCount() {
    //  int nLines = 0;
    //  int i;

    //  for(i = 0; i < size; ++i)
    //    if(content[i] == wxPorting.T('\n'))
    //      ++nLines;
    //  return nLines;
    //}

    public bool ReadLine(out char[] dest) {
      int i, j;

      if(nextChar.Length == 0) {
        dest = new char[0];
        return false;
      }

      dest = new char[nextChar.Length];

      for(j = 0, i = 0; i < nextChar.Length && nextChar[j] != wxPorting.T('\n') && i < size - 1; j++) {
        if(nextChar[j] != wxPorting.T('\r')) {
          dest[i] = nextChar[i];
          i++;
        }
      }
      if(nextChar[j] == wxPorting.T('\n'))
        j++;

      int lenth = nextChar.Length - j;
      char[] swap = new char[lenth];
      Array.Copy(nextChar, j, swap, 0, lenth);
      nextChar = swap;

      lenth = i;
      swap = new char[i];
      Array.Copy(dest, swap, lenth);
      dest = swap;

      return i != 0 || nextChar.Length > 0;
    }

    //private void Rewind() {
    //  nextChar = content;
    //}

    //private size_t GetPos() {
    //  return nextChar - content;
    //}

    //private void SetPos(size_t pos) {
    //  nextChar = &content[pos];
    //}

    public void SetExt(string ext) {
      //if(ext.Length > 1)
      //  name.SetExt(ext.Substring(1));
      //else
      //  name.SetEmptyExt();
    }

    //private void GetDirName(string dest, int size) {
    //  FileName nm = new FileName(this.name);
    //  nm.Normalize(wxPATH_NORM_LONG | wxPATH_NORM_DOTS | wxPATH_NORM_TILDE | wxPATH_NORM_ABSOLUTE);
    //  wxString dir = nm.GetPath();
    //  wxStrncpy(dest, dir.c_str(), size - 1);
    //  dest[size - 1] = 0;
    //}

    public int LineCount() {
      int nLines = 0;
      int i;

      for(i = 0; i < size; ++i)
        if(content[i] == wxPorting.T('\n'))
          ++nLines;
      return nLines;
    }

  }
}