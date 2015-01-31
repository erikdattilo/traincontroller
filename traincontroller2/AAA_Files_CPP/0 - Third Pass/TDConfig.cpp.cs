using System;
namespace Traincontroller2 {

  public class TDConfig {
    private const int MAX_CONFIG_SECT = 40;

    public TextFile m_file;
    public int m_start, m_end;

    public int m_nSaved;
    public int[] m_savedStart = new int[MAX_CONFIG_SECT];
    public int[] m_savedEnd = new int[MAX_CONFIG_SECT];

    public TDConfig() {
      m_start = m_end = -1;
      m_nSaved = 0;
    }

    public bool Load(string fname) {
      m_start = m_end = -1;
      m_nSaved = 0;

      if(!m_file.Open(fname))
        return false;
      return true;
    }

    public void Close() {
      m_file.Write(wxPorting.wxTextFileType_Dos);
      m_file.Close();
    }

    public bool Save(string fname) {
      if(m_file.Open(fname))
        m_file.Clear();
      else if(!m_file.Create(fname))
        return false;
      return true;
    }

    public bool FindSection(string name) {
      throw new NotImplementedException();
      //string header;
      //int i;

      //header = "[";
      //header += name;
      //header += "]";
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
      //  string  p = m_file[i];
      //  if(Globals.strncmp(p, var, var.Length) == 0) {
      //    p += var.Length;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if(p[0] == '=') p.incPointer();
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    result = Globals.atoi(p);
      //    return true;
      //  }
      //}
      //return false;
    }

    public bool GetString(string var, out string result) {
      throw new NotImplementedException();

      //int i;

      //for(i = m_start; i < m_end; ++i) {
      //  string  p = m_file[i];
      //  if(Globals.strncmp(p, var, var.Length) == 0) {
      //    p += var.Length;
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    if(p[0] == '=') p.incPointer();
      //    while(p[0] == ' ' || p[0] == 't') p.incPointer();
      //    result = p;
      //    return true;
      //  }
      //}
      //return false;
    }

    public void StartSection(string name) {
      string buff;

      buff = string.Format("[%s]", name);
      m_file.AddLine(buff);
    }

    public void PutString(string var, string value) {
      string buff;

      buff = string.Format("%s = %s", var, value);
      m_file.AddLine(buff);
    }

    public void PutInt(string var, int value) {
      string buff;

      buff = string.Format("%s = %d", var, value);
      m_file.AddLine(buff);
    }
  }
}