using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {

  public enum OptionType {
    OPTION_STRING,
    OPTION_INT,
    OPTION_BOOL,
    OPTION_FILE,
    OPTION_COLOR
  };

  public class OptionManager {
        public OptionManager() {
        }

        public static void Register(Option opt) {
          if(_first == null)
            _first = opt;
          else
            _last._next = opt;
          _last = opt;
          opt._next = null;
        }

        public static Option _first, _last;
        public static int  _nOptions;
  }

  public class Option {
    public Option(OptionType type, string name, string descr, string cat, string defValue) {
        _name = name;
        _descr = descr;
        _category = cat;
        OptionManager.Register(this);
        Set(defValue);
    }

    private void Set(string value) {
      _sValue = value;
      if(value.Length > 0 && (int)value[0] >= (int)wxPorting.T('0') && (int)value[0] <= (int)wxPorting.T('9'))
        _iValue = GlobalFunctions.myAtoi(value);
      else
        _iValue = 0;
    }


    public Option _next;

    string _name;
    string _descr;
    string _category;
    public string _sValue;       // STRING, FILE
    int      _iValue;       // INT, BOOL, COLOR
    OptionType _type;
  }
}
