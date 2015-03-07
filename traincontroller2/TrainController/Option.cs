using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {

  public enum OptionType {
    OPTION_STRING,
    OPTION_INT,
    OPTION_BOOL,
    OPTION_FILE,
    OPTION_COLOR
  }

  public class Option {
    public Option _next;

    public String _name;
    public String _descr;
    public String _category;
    public String _sValue;       // STRING, FILE
    public int _iValue;       // INT, BOOL, COLOR
    public OptionType _type;

    public Option(OptionType type, String name, String descr, String cat, String defValue) {
      _name = name;
      _descr = descr;
      _category = cat;
      OptionManager.Register(this);

    }

    public void Set(string value) {
      throw new NotImplementedException();
      //_sValue = value;
      //if(value[0] >= wxPorting.T('0') && value[0] <= wxPorting.T('9'))
      //  _iValue = Globals.myAtoi(value);
      //else
      //  _iValue = 0;
    }

    public static bool Match(String name, String value) {
      throw new NotImplementedException();
      //if(_name.CmpNoCase(name))
      //  return false;
      //_sValue = value;
      //if(value[0] >= wxPorting.T('0') && value[0] <= wxPorting.T('9'))
      //  _iValue = Globals.myAtoi(value);
      //else
      //  _iValue = 0;
      //return true;
    }

    // TODO Uncomment this function
    //public bool Save(FILE fp) {
    //  Globals.wxFprintf(fp, wxPorting.T("%s = %s\n"), _name, _sValue);
    //  return false;
    //}

  }

  public class IntOption : Option {

    public IntOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_INT, name, descr, cat, defValue) {
      throw new NotImplementedException();
      //if(String.IsNullOrEmpty(defValue) == false)
      //  _iValue = Globals.myAtoi(defValue);
    }


  }

  public class StringOption : Option {
    public StringOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_STRING, name, descr, cat, defValue) {
    }
  }

  public class BoolOption : Option {

    public BoolOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_BOOL, name, descr, cat, defValue) {
    }

    public void Set(bool value) {
      _sValue = value ? wxPorting.T("1") : wxPorting.T("0");
      _iValue = value ? 1 : 0;
    }

    public bool Match(String name, String value) {
      if(!Option.Match(name, value))
        return false;
      if(_iValue != 0)
        _iValue = 1;
      return true;
    }
  }

  public class FileOption : Option {

    public FileOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_FILE, name, descr, cat, defValue) {
    }

  }

  public class ColorOption : Option {
    public ColorOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_COLOR, name, descr, cat, defValue) {
    }

    public bool Match(String name, String value) {
      throw new NotImplementedException();

      //if(!Option.Match(name, value))
      //  return false;
      //String p;
      //_iValue = (Globals.wxStrtol(value, ref p, 0) & 0xFF) << 16;
      //_iValue |= (Globals.wxStrtol(p, ref p, 0) & 0xFF) << 8;
      //_iValue |= (Globals.wxStrtol(p, ref p, 0) & 0xFF);
      //return true;
    }
  }


  public class OptionManager {
    public static Option _first, _last;
    public static int _nOptions;

    public static void Register(Option opt) {
      if(_first == null)
        _first = opt;
      else
        _last._next = opt;
      _last = opt;
      opt._next = null;
    }
  }
}
