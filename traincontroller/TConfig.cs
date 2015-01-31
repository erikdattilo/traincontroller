using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class TConfig {
    /// TODO
    object /*wxTextFile*/ m_file;
    int m_start, m_end;

    int m_nSaved;
    int[] m_savedStart = new int[Configuration.MAX_CONFIG_SECT];
    int[] m_savedEnd = new int[Configuration.MAX_CONFIG_SECT];
    public TConfig() {
      m_start = m_end = -1;
      m_nSaved = 0;
    }

    public bool Load(string fname) {
      /// TODO
#if false
	m_start = m_end = -1;
	m_nSaved = 0;

	if(!wxFile::Exists(fname))
	    return false;
	if(!m_file.Open(fname))
	    return false;
#endif
      return true;
    }

    void Close() {
      //m_file.Write(wxTextFileType_Dos);
      //m_file.Close();
    }

    bool Save(string fname) {
      //if(wxFile::Exists(fname) && m_file.Open(fname))
      //    m_file.Clear();
      //else if(!m_file.Create(fname))
      //    return false;
      return true;
    }

    public bool FindSection(string name) {
      return false;

      //string header;
      //int i;

      //header = wxPorting.T("[");
      //header += name;
      //header += wxPorting.T("]");
      //m_start = m_end = -1;
      //for(i = 0; i < m_file.GetLineCount(); ++i) {
      //  if(m_file[i] == header) {
      //    m_start = i + 1;
      //    m_end = m_file.GetLineCount();
      //  } else if(m_start != -1 && m_file[i][0] == '[') {
      //    m_end = i;
      //    return true;
      //  }
      //}
      //return m_start != -1;
    }

    public bool PushSection(string name) {
      //if(m_nSaved >= Configuration.MAX_CONFIG_SECT)
      //  return false;
      //m_savedStart[m_nSaved] = m_start;
      //m_savedEnd[m_nSaved] = m_end;
      //if(!FindSection(name))
      //  return false;
      //++m_nSaved;
      return true;
    }

    public void PopSection() {
      //if(m_nSaved > 0)
      //  --m_nSaved;
      //m_start = m_savedStart[m_nSaved];
      //m_end = m_savedEnd[m_nSaved];
    }

    public bool GetInt(string var, out int result) {
      result = 0; return false;

      //int i;

      //for(i = m_start; i < m_end; ++i) {
      //  string tmp;
      //  if(m_file[i].StartsWith(var, tmp)) {
      //    long r;
      //    bool ret;
      //    tmp = tmp.AfterFirst(wxPorting.T('='));
      //    tmp.Trim(false);
      //    tmp.Trim(true);
      //    ret = tmp.ToLong(r);
      //    result = r;
      //    return ret;
      //  }
      //}

      //return false;

    }

    public bool GetString(string var, out string result) {
      result = ""; return false;
      //int i;

      //for(i = m_start; i < m_end; ++i) {
      //  string tmp;
      //  if(m_file[i].StartsWith(var, tmp)) {
      //    result = tmp.AfterFirst(wxPorting.T('='));
      //    result.Trim(false);
      //    return true;
      //  }
      //}
      return false;
    }

    bool Get(Option option) {
      //string value;

      //if(!GetString(option->_name.c_str(), value))
      //  return false;
      //option->Set(value.c_str());
      return true;
    }

    public void StartSection(string name) {
      //m_file.AddLine(string(wxPorting.T('[')) + name + wxPorting.T(']'));
    }

    public void PutString(string var, string value) {
      //m_file.AddLine(string(var) + wxPorting.T(" = ") + value);
    }

    public void PutInt(string var, int value) {
      //m_file.AddLine(String.Format(wxPorting.T("{0} = {1}"), var, value));
    }

    void Put(Option option) {
      //if(!option->_sValue.empty())
      //  PutString(option->_name, option->_sValue.c_str());
    }
  }
}