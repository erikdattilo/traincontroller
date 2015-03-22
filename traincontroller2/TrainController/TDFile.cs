using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wx.Archive;
using System.IO;

namespace TrainController {
  public class TDFile {
    StringReader mReader = null;

    public wxFileName mName;
    public string mContent;

    public int size {
      get {
        return (mContent == null) ? 0 : mContent.Length;
      }
    }

    public TDFile(string fname) {
      mName = new wxFileName(fname);
      //content = 0;
      //nextChar = 0;
    }

    public bool Load() {
      if(!Globals.LoadFile(mName.GetFullPath(), out mContent))
        return false;

      mReader = new StringReader(mContent);

      return true;
    }

    public int LineCount() {
      throw new NotImplementedException();
      //int nLines = 0;
      //int i;

      //for(i = 0; i < size; ++i)
      //  if(content[i] == wxPorting.T('\n'))
      //    ++nLines;
      //return nLines;
    }

    public bool ReadLine(out string dest) {
      dest = mReader.ReadLine();
      return (dest != null);
    }

    public void Rewind() {
      mReader = new StringReader(mContent);
    }

    public int GetPos() {
      throw new NotImplementedException();
      //return nextChar - content;
    }

    public void SetPos(int pos) {
      throw new NotImplementedException();
      //nextChar = &content[pos];
    }

    public void SetExt(string ext) {
      if(ext != null && ext.Length > 1)
        mName.SetExt(ext.Substring(1));
      else
        mName.SetEmptyExt();
    }

    public void GetDirName(out string dest) {
      throw new NotImplementedException();
      //wxFileName nm = new wxFileName(this.name);
      //nm.Normalize(wxPATH_NORM_LONG | wxPATH_NORM_DOTS | wxPATH_NORM_TILDE | wxPATH_NORM_ABSOLUTE);
      //String dir = nm.GetPath();
      //dest = string.Copy(dir);
      //dest[size - 1] = 0;
    }
  }

  public partial class Globals {
    // TODO Replace with a List<FileItem>
    public static FileItem file_list;

    public static void FreeFileList() {
      FileItem it;

      while((it = file_list) != null) {
        file_list = it.next;
      }
    }

    public static FileItem AddFile(FileItem it) {
      it.next = file_list;
      file_list = it;
      return it;
    }

    public static bool ReadZipFile(string path) {
      FileItem it;
      String entryName;
      ArchiveInput zip;
      ArchiveEntry entry;

      zip = new ArchiveInput(path);
      while((entry = zip.GetNextEntry()) != null) {
        zip.OpenEntry(entry);

        int size = (int)zip.In.Length;
        entryName = entry.InternalName;

        // TODO Check if this #if is needed and implement the code if so...
#if false // wxUSE_UNICODE
            wxWritableCharBuffer tmpMB(it.size + 4);
            if ((String) tmpMB == null)
          return 0;
            Stringbuffer = tmpMB;
            for(i = 0; !zip.Eof() && i < it.size; buffer[i++] = zip.GetC());
            buffer[i] = 0;
            zip.CloseEntry();
            /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
            if (! (it.content = wxConvAuto().cMB2WX(tmpMB).release()))
          if (! (it.content = wxConvISO8859_1.cMB2WX(tmpMB).release()))
              return 0;
#else
        byte[] buffer = new byte[size];
        zip.In.Read(buffer, 0, size);
#endif // !wxUSE_UNICODE

        it = new FileItem(entryName, buffer);
        AddFile(it);
      }

      return true;
    }

    public static bool LoadFile(string name, out string dest) {
      FileItem it;

      dest = "";

      String fname = String.Copy(name);
      fname = fname.Replace('\\', '/');
      for(it = file_list; it != null; it = it.next) {
        string t = it.name;
        if(String.Equals(fname, it.name, StringComparison.InvariantCultureIgnoreCase))
          break;
      }
      if(it != null) {
        dest = it.content;
        return true;
      }

      String filename = "";
      if(File.Exists(name)) {
        filename = name;
      } else {

        // search in provided directories
        string pth = Globals.searchPath._sValue;
        if(pth == null)
          return false;

        foreach(var path in pth.Split(';')) {
          filename = path.Trim() + '/' + name;
          if(File.Exists(filename)) {
            break;
          }
        }
      }
      if(!File.Exists(filename))
        return false;

#if wxUSE_UNICODE
        wxWritableCharBuffer tmpMB(length + 4);
        if ((String) tmpMB == null)
            return 0;
        if(fread(tmpMB, 1, length, fp) != length) {
            fclose(fp);
            return 0;
        }
        fclose(fp);
        ((String) tmpMB)[length] = 0;		// mark end of file
        /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
        if (! (*dest = wxConvAuto().cMB2WX(tmpMB).release()))
            if (! (*dest = wxConvISO8859_1.cMB2WX(tmpMB).release()))
          return 0;
#else
      using(BinaryReader reader = new BinaryReader(File.Open(name, FileMode.Open))) {
        int length = (int)reader.BaseStream.Length;
        byte[] buffer = new byte[length];
        reader.Read(buffer, 0, length);
        dest = ((new ASCIIEncoding()).GetString(buffer));
      }
#endif // !wxUSE_UNICODE
      return true;
    }

  }

  public class FileItem {
    public FileItem next;
    public String name;
    public int size { get { return (content == null) ? 0 : content.Length; } }
    public string content;

    public FileItem(string name_, byte[] content_) {
      name = (name_ == null) ? "" : name_.Replace('\\', '/');
      content = (new ASCIIEncoding()).GetString(content_);
      next = null;
    }
  };
}
