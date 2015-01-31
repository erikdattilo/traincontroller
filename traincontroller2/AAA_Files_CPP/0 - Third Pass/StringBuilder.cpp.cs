using System;
namespace Traincontroller2 {

  public class StringItem {
    private static int STRITEMBUFFSIZE = 16;
    public string GetPtr() { return String.IsNullOrEmpty(_ptr) == false ? _ptr : _buff; }
    public int Length() { return _buffPos; }

    public string _buff;
    public string _ptr = null;
    public int _buffPos;   // next pos in _buff, if not using _ptr
    public StringItem _next;
    public StringItem() {
      Clear();
    }

    public StringItem(string pChar) {
      if(Append(pChar))
        return;
      int l;

      l = pChar.Length;
      _ptr = string.Copy(pChar);

      _buffPos = l;
    }

    ~StringItem() {
      Clear();
    }

    public void Clear() {
      if(_ptr != null)
        Globals.free(_ptr);
      _ptr = null;
      _buffPos = 0;
    }


    public bool Append(string pChar) {
      int l = pChar.Length;
      _buff += pChar;
      _buffPos += l;
      return true;
    }
  }



  //
  //
  //

  public class StringBuilder {
    public StringItem _firstItem, _lastItem;

    public StringBuilder() {
      Clear();
    }

    public StringBuilder(string pChar) {
      StringItem item = new StringItem(pChar);
      _firstItem = item;
      _lastItem = item;
    }


    public StringBuilder Append(string pChar) {
      StringItem item = _lastItem;

      if(item == null) {
        item = new StringItem(pChar);
        _firstItem = _lastItem = item;
        return this;
      }
      if(item.Append(pChar))
        return this;
      item = new StringItem(pChar);
      if(_lastItem == null)
        _firstItem = _lastItem = item;
      else {
        _lastItem._next = item;
        _lastItem = item;
      }
      return this;
    }

    public StringBuilder Append(char c) {
      return Append(c.ToString());
    }


    public void Clear() {
      while(_firstItem != null) {
        _lastItem = _firstItem._next;
        Globals.delete(_firstItem);
        _firstItem = _lastItem;
      }
    }

    public override string ToString() {
      throw new NotImplementedException();

      //StringItem item;
      //int len = 0;
      //string str;

      //for(item = _firstItem; item != null; item = item._next) {
      //  len += item.Length();
      //}
      //len += 1;
      //str = (SBstring)malloc(len * sizeof(SBChar));
      //len = 0;
      //for(item = _firstItem; item != null; item = item._next) {
      //  memcpy(str + len * sizeof(SBChar), item.GetPtr(), item.Length() * sizeof(SBChar));
      //  len += item.Length();
      //}
      //str[len] = 0;
      //return str;
    }
  }
}