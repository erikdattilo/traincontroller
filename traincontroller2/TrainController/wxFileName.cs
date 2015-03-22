using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrainController {
  // TODO Refactor all getters into properties
  public class wxFileName {
    private string mFileName;
    private string mExt;

    //public static implicit operator String(wxFileName fname) {
    //  throw new NotImplementedException();
    //}

    public wxFileName(String fname) {
      mFileName = String.Copy(fname);
    }

    public string GetPath() {
      return Path.GetDirectoryName(mFileName);
    }

    public string GetExt() {
      string ext = Path.GetExtension(mFileName);
      if((ext.Length > 0) && (ext[0] == '.'))
        ext = ext.Substring(1);
      return ext ?? "";
    }

    public string GetName() {
      return Path.GetFileNameWithoutExtension(mFileName);
    }

    public string GetFullPath() {
      return mFileName;
      // TODO In case of error consider following line instead...
      return Path.GetFullPath(mFileName);
    }

    public void SetExt(string ext) {
      mExt = ext;

      int i = mFileName.LastIndexOf('.');
      if(i >= 0) {
        mFileName = mFileName.Substring(0, i) + '.' + mExt;
      }
    }

    public void SetEmptyExt() {
      mExt = "";
    }
  }

}
