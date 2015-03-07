// /*	TConfig.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */

using System;
namespace TrainDirPorting {

  public class TConfig {
    // public:
    private static int MAX_CONFIG_SECT = 40;


    wxTextFile m_file;
    public int m_start, m_end;

    public int m_nSaved;
    public int[] m_savedStart = new int[MAX_CONFIG_SECT];
    public int[] m_savedEnd = new int[MAX_CONFIG_SECT];

    public TConfig() {
      m_start = m_end = -1;
      m_nSaved = 0;

    }

    public bool Load(string fname) {
      m_start = m_end = -1;
      m_nSaved = 0;

      if(!wxFile.Exists(fname))
        return false;
      if(!m_file.Open(fname))
        return false;
      return true;
    }

    public void Close() {
      m_file.Write(wxPorting.wxTextFileType_Dos);
      m_file.Close();
    }

    public bool Save(string fname) {
      if(wxFile.Exists(fname) && m_file.Open(fname))
        m_file.Clear();
      else if(!m_file.Create(fname))
        return false;
      return true;
    }

    public bool FindSection(string name)
     {
      throw new NotImplementedException();

      //string header;
      //int i;
     
      //header = wxPorting.T("[");
      //header += name;
      //header += wxPorting.T("]");
      //m_start = m_end = -1;
      //for(i = 0; i < m_file.GetLineCount(); ++i) {
      //    if(m_file[i] == header) {
      //  m_start = i + 1;
      //  m_end = m_file.GetLineCount();
      //    } else if(m_start != -1 && m_file[i][0] == '[') {
      //  m_end = i;
      //  return true;
      //    }
      //}
      //return m_start != -1;
     }

    public bool PushSection(string name) {
      if(m_nSaved >= MAX_CONFIG_SECT)
        return false;
      m_savedStart[m_nSaved] = m_start;
      m_savedEnd[m_nSaved] = m_end;
      if(!FindSection(name))
        return false;
      ++m_nSaved;
      return true;
    }

    public void PopSection() {
      if(m_nSaved > 0)
        --m_nSaved;
      m_start = m_savedStart[m_nSaved];
      m_end = m_savedEnd[m_nSaved];
    }

    public bool GetInt(string var, out int result) {
      throw new NotImplementedException();

      //int i;

      //for(i = m_start; i < m_end; ++i) {
      //  String tmp;
      //  if(m_file[i].StartsWith(var, &tmp)) {
      //    long r;
      //    bool ret;
      //    tmp = tmp.AfterFirst(wxPorting.T('='));
      //    tmp.Trim(false);
      //    tmp.Trim(true);
      //    ret = tmp.ToLong(&r);
      //    result = r;
      //    return ret;
      //  }
      //}
      //return false;
    }

    public bool GetString(string var, out string result) {
      throw new NotImplementedException();

      //int i;

      //for(i = m_start; i < m_end; ++i) {
      //  String tmp;
      //  if(m_file[i].StartsWith(var, &tmp)) {
      //    result = tmp.AfterFirst(wxPorting.T('='));
      //    result.Trim(false);
      //    return true;
      //  }
      //}
      //return false;
    }

    public bool Get(Option option) {
      throw new NotImplementedException();

      //String value;

      //if(!GetString(option._name, value))
      //  return false;
      //option.Set(value);
      //return true;
    }

    public void StartSection(string name) {
      //m_file.AddLine(String(wxPorting.T('[')) + name + wxPorting.T(']'));
    }

    public void PutString(string var, string value) {
      //m_file.AddLine(String(var) + wxPorting.T(" = ") + value);
    }

    public void PutInt(string var, int value) {
      //m_file.AddLine(String.Format(wxPorting.T("%s = %d"), var, value));
    }

    public void Put(Option option) {
      //if(!option._sValue.empty())
      //  PutString(option._name, option._sValue);
    }
  }
}