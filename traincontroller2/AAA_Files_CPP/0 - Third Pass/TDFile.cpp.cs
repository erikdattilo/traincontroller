/*	TDFile.cpp - Created by Giampiero Caprino

This file is part of Train Director 3

Train Director is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; using exclusively version 2.
It is expressly forbidden the use of higher versions of the GNU
General Public License.

Train Director is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Train Director; see the file COPYING.  If not, write to
the Free Software Foundation, 59 Temple Place - Suite 330,
Boston, MA 02111-1307, USA.
*/

using System;
namespace TrainDirPorting {

  public partial class Globals {
    public static FileOption searchPath = new FileOption(wxPorting.T("SearchPath"), wxPorting.T("Directories with signal scripts"),
                           wxPorting.T("Environment"), wxPorting.T(""));


    public static FileItem file_list;
    public static void FreeFileList() {
      //FileItem it;

      //while((it = file_list) != null) {
      //  file_list = it.next;
      //  Globals.delete(it);
      //}
    }


    public static FileItem AddFile(string name) {
      throw new NotImplementedException();

      //FileItem it = new FileItem(name);
      //it.name.Replace('\\', '/', true);
      //it.next = file_list;
      //file_list = it;
      //return it;
    }

    public static bool ReadZipFile(string path)
{
      throw new NotImplementedException();
//  wxFFileInputStream  dbStream = new wxFFileInputStream(path);
//  wxZipInputStream zip = new wxZipInputStream(dbStream);

//  wxZipEntry  entry;
//  String    entryName;
//  FileItem    it;
//  int	    i;

//  while(entry = zip.GetNextEntry()) {
//      entryName = entry.GetInternalName();
//      it = AddFile(entryName);
//      zip.OpenEntry(entry);
//      it.size = zip.GetSize();

//#if wxUSE_UNICODE
//      wxWritableCharBuffer tmpMB(it.size + 4);
//      if ((String) tmpMB == null)
//    return 0;
//      Stringbuffer = tmpMB;
//      for(i = 0; !zip.Eof() && i < it.size; buffer[i++] = zip.GetC());
//      buffer[i] = 0;
//      zip.CloseEntry();
//      /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
//      if (! (it.content = wxConvAuto().cMB2WX(tmpMB).release()))
//    if (! (it.content = wxConvISO8859_1.cMB2WX(tmpMB).release()))
//        return 0;
//#else
//      int	ch;
//      it.content = (char *)malloc((it.size + 4) * sizeof(char));
//      for(i = 0; !zip.Eof() && i < it.size; it.content[i++] = ch) {
//    ch = zip.GetC();
//    //if(ch < 0)
//    //    break;
//      }
//      it.content[i] = 0;
//#endif // !wxUSE_UNICODE
//  }
//  return 1;
}

    public static int LoadFile(string name, out string dest) {
      throw new NotImplementedException();
//      FileItem it;

//      String fname = name;
//      fname.Replace("\\", "/", true);
//      for(it = file_list; it; it = it.next) {
//        string t = string.Copy(it.name);
//        if(!wxStricmp(fname, t))
//          break;
//      }
//      if(it) {
//        *dest = (char*)malloc(sizeof(char) * (it.size + 4));
//        memcpy(*dest, it.content, sizeof(char) * (it.size + 1));
//        return 1;
//      }
//      FILE* fp;

//      if(!(fp = wxFopen(name, wxPorting.T("rb")))) {
//        String filename;
//        size_t p, p1, len;

//#if true
//        // search in provided directories
//        const Char* pth = searchPath._sValue;
//        for(p = 0; p < searchPath._sValue.size(); p.incPointer()) {
//          if(pth[p] == wxPorting.T(';')) {
//            if(filename.size() > 0) {
//              filename += wxPorting.T('/');
//              filename += name;
//              if((fp = wxFopen(filename, wxPorting.T("rb"))))
//                goto found;
//              filename = wxPorting.T("");
//            }
//          } else
//            filename += pth[p];
//        }
//        if(filename.size() > 0) {
//          filename += wxPorting.T('/');
//          filename += name;
//          if((fp = wxFopen(filename, wxPorting.T("rb"))))
//            goto found;
//        }
//#else
//      p = p1 = 0;
//      while(!searchPath.empty() && p1 != String::npos) {
//    p1 = searchPath.find(wxPorting.T(';'), p);
//    len = p1 == String::npos ? p1 : p1 - p;
//    filename = searchPath.substr(p, len) + wxPorting.T('/') + name;
//    if((fp = wxFopen(filename, wxPorting.T("rb"))))
//        goto found;
//    p = p1;
//      }
//#endif
//        return 0;
//      }
//    found:
//      fseek(fp, 0, 2);
//      int length = ftell(fp);
//      rewind(fp);

//#if wxUSE_UNICODE
//  wxWritableCharBuffer tmpMB(length + 4);
//  if ((String) tmpMB == null)
//      return 0;
//  if(fread(tmpMB, 1, length, fp) != length) {
//      fclose(fp);
//      return 0;
//  }
//  fclose(fp);
//  ((String) tmpMB)[length] = 0;		// mark end of file
//  /* wxConvAuto can't (as of wxWidgets 2.8.7) handle ISO-8859-1.  */
//  if (! (*dest = wxConvAuto().cMB2WX(tmpMB).release()))
//      if (! (*dest = wxConvISO8859_1.cMB2WX(tmpMB).release()))
//    return 0;
//#else
//      *dest = (char*)malloc((length + 4) * sizeof(char));
//      if(fread(*dest, 1, length, fp) != length) {
//        fclose(fp);
//        return 0;
//      }
//      fclose(fp);
//      (*dest)[length] = 0;		// mark end of file
//#endif // !wxUSE_UNICODE
//      return 1;
    }


  }


  public class FileItem {
    public FileItem(string item) {
      name = item;
      content = null;
      next = null;
      size = 0;
    }

    ~FileItem() {
      if(content != null)
        Globals.free(content);
      content = null;
    }


    public FileItem next;
    public String name;
    public int size;
    public String content;
  };


  public class TDFile {
    public wxFileName name;
    public string content;
    public string nextChar;
    public int size;

    public TDFile(string fname) {
      //name = String.Copy(fname);
      //size = 0;
      //content = 0;
      //nextChar = 0;
    }
    ~TDFile() {
      if(content != null)
        Globals.free(content);
      content = null;
      size = 0;
      nextChar = null;
    }

    public bool Load() {
      throw new NotImplementedException();
      //if(!LoadFile(name.GetFullPath(), content))
      //  return false;

      //size = Globals.wxStrlen(content);
      //nextChar = content;
      //return true;
    }

    public int LineCount() {
      int nLines = 0;
      int i;

      for(i = 0; i < size; ++i)
        if(content[i] == wxPorting.T('\n'))
          ++nLines;
      return nLines;
    }

    public bool ReadLine(string dest, int size) {
      throw new NotImplementedException();
      //int i;

      //for(i = 0; *nextChar && *nextChar != wxPorting.T('\n') && i < size - 1; ) {
      //  if(*nextChar != wxPorting.T('\r'))
      //    dest[i++] = *nextChar;
      //  ++nextChar;
      //}
      //dest[i] = 0;
      //if(*nextChar == wxPorting.T('\n'))
      //  ++nextChar;
      //return i != 0 || *nextChar != 0;
    }

    public void Rewind() {
      nextChar = content;
    }

    public size_t GetPos() {
      throw new NotImplementedException();
      //return nextChar - content;
    }

    public void SetPos(size_t pos) {
      //nextChar = &content[pos];
    }

    public void SetExt(string ext) {
      //if(ext[1])
      //  name.SetExt(&ext[1]);
      //else
      //  name.SetEmptyExt();
    }

    public void GetDirName(string dest, int size) {
      //wxFileName nm = new wxFileName(this.name);
      //nm.Normalize(wxPATH_NORM_LONG | wxPATH_NORM_DOTS | wxPATH_NORM_TILDE | wxPATH_NORM_ABSOLUTE);
      //String dir = nm.GetPath();
      //dest = string.Copy(dir);
      //dest[size - 1] = 0;
    }
  }
}