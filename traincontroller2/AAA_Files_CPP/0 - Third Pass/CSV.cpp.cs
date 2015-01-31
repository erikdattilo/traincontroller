using System;

namespace Traincontroller2 {

  public class CSVColumn {
    public CSVColumn _next;
    public string _name;
    public int _index;

    public CSVColumn(int index, string name) {
      _index = index;
      _name = string.Copy(name);
      _next = null;
    }


    ~CSVColumn() {
      if(String.IsNullOrEmpty(_name) == false)
        Globals.free(_name);
    }
  }

  public class CSVFile {
    private static int MAX_CSV_COL = 40;
    public string _path;
    public CSVColumn _firstCol, _lastCol;
    public TDFile _file;
    public string _line;
    public string[] _colPtrs = new string[MAX_CSV_COL];
    public int _nCols;


    public CSVFile(string path) {
      _path = String.Copy(path);
      _nCols = 0;
      _firstCol = _lastCol = null;
      _file = new TDFile(path);
    }


    ~CSVFile() {
      Globals.free(_path);
      while(_firstCol != null) {
        CSVColumn next = _firstCol._next;
        Globals.delete(_firstCol);
        _firstCol = next;
      }
      _firstCol = _lastCol = null;
      _nCols = 0;
    }


    public bool Load() {
      return _file.Load();
    }

    public bool ReadLine() {
      throw new NotImplementedException();
      //// Read a line,
      //if(!_file.ReadLine(_line, _line.Length))
      //  return false;

      //// split values into colPtrs[]

      //int i;
      //string p;
      //for(p = _line, i = 0; *p; ) {
      //  _colPtrs[i++] = p;
      //  while(*p && *p != wxPorting.T(','))
      //    p = p.Substring(1);
      //  if(!*p)
      //    break;
      //  *p.incPointer() = 0;
      //}
      //_colPtrs[i] = 0;
      //return true;
    }

    public bool ReadColumns() {
      throw new NotImplementedException();
      //if(!ReadLine())
      //  return false;

      //int i;
      //for(i = 0; i < Configuration.MAX_CSV_COL && _colPtrs[i] != null; ++i) {
      //  CSVColumn col = new CSVColumn(i, _colPtrs[i]);
      //  if(_firstCol == null)
      //    _firstCol = col;
      //  else
      //    _lastCol._next = col;
      //  _lastCol = col;
      //}
      //return true;
    }

    public CSVColumn FindColumn(string name) {
      CSVColumn col;

      for(col = _firstCol; col != null; col = col._next) {
        if(Globals.wxStrcmp(col._name, name) == 0)
          return col;
      }
      return null;
    }

    public void GetColumn(String value, CSVColumn col) {
      if(col != null && _colPtrs[col._index] != null)
        value = _colPtrs[col._index];
    }

    public void GetColumn(int value, CSVColumn col) {
      //if(col != null && _colPtrs[col._index] != null)
      //  value = wxAtoi(_colPtrs[col._index]);
    }

    public void GetColumnHex(int value, CSVColumn col) {
      //if(col != null && _colPtrs[col._index] != null)
      //  wxSscanf(_colPtrs[col._index], wxPorting.T("%x"), &value);
    }

    public void GetColumn(double value, CSVColumn col) {
      //if(col != null && _colPtrs[col._index] != null)
      //  value = wxAtof(_colPtrs[col._index]);
    }
  }
}