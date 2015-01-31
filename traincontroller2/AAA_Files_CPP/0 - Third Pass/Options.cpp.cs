/*	Options.cpp - Created by Giampiero Caprino

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

namespace Traincontroller2 {
  public partial class Globals {

    public static int myAtoi(string p) {
      return int.Parse(p);

      //int val = 0;
      //while(p[0] >= '0' && p[0] <= '9')
      //  val = (val * 10) + (*p.incPointer() - '0');
      //return val;
    }
  }


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
      _sValue = value;
      if(value[0] >= wxPorting.T('0') && value[0] <= wxPorting.T('9'))
        _iValue = Globals.myAtoi(value);
      else
        _iValue = 0;
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

    public bool Save(FILE fp) {
      Globals.wxFprintf(fp, wxPorting.T("%s = %s\n"), _name, _sValue);
      return false;
    }

  }

  public class IntOption : Option {

    public IntOption(String name, String descr, String cat, String defValue)
      : base(OptionType.OPTION_INT, name, descr, cat, defValue) {
      if(String.IsNullOrEmpty(defValue) == false)
        _iValue = Globals.myAtoi(defValue);
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