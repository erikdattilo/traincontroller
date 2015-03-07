
using wx;
using System;
namespace TrainDirPorting {

  // typedef std::vector<FontEntry *>    FontPool;

  public class FontEntry {
    public int _id;
    public int _size;
    public FontFamily _family;
    public FontStyle _style;
    public FontWeight _weight;
    public long _color;

    public FontEntry(int size, FontFamily family, FontStyle style, FontWeight weight, long color) {
      _id = 0;
      _size = size;
      _family = family;
      _style = style;
      _weight = weight;
      _color = color;
    }

    internal bool SameAs(FontEntry f) {
      throw new System.NotImplementedException();
    }
  };

  public static partial class Globals {
    public static FontManager fonts;
  }

  public class FontManager {
    public FontPool[] _fonts;

    public int FindFont(int size, FontFamily family, FontStyle style, FontWeight weight, long color) {
      throw new NotImplementedException();
      //int i;
      //FontEntry font;
      //FontEntry f = new FontEntry(size, family, style, weight, color);

      //for(i = 0; i < _fonts.size(); ++i) {
      //  font = _fonts[i];
      //  if(font.SameAs(f))
      //    return i;
      //}
      //return -1;
    }

    public FontEntry FindFont(int index) {
      throw new NotImplementedException();
      //if(index < 0 || index >= _fonts.size())
      //  return 0;
      //return _fonts[index];
    }

    public int AddFont(int size, FontFamily family, FontStyle style, FontWeight weight, long color) {
      throw new NotImplementedException();
      //int i;

      //if((i = FindFont(size, family, style, weight, color)) >= 0)
      //  return i;
      //FontEntry f = new FontEntry(size, family, style, weight, color);
      //_fonts.push_back(f);
      //return _fonts.size() - 1;
    }

    public bool SameAs(FontEntry other) {
      throw new NotImplementedException();
      //if(other._size != _size) return false;
      //if(other._family != _family) return false;
      //if(other._style != _style) return false;
      //if(other._weight != _weight) return false;
      //if(other._color != _color) return false;
      //return true;
    }
  }
}