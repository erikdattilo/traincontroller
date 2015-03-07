 /*	Localize.cpp - Created by Giampiero Caprino
 
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

  public class LocalizeInfo {
    public string English;
    public string Other;
  }

  /*	localized strings support (1.19)	*/

  public class lstring {
    public lstring next;
    public int hash;
    public String en_string;
    public String loc_string;
  };

  public partial class Globals {
    public static String locale_name = wxPorting.T(".en");
    public static lstring local_strings;

    static String linebuff;
    static int maxline;

    /*	TODO: need to rewrite getline() to support
     *	unicode localization catalogues. Also would
     *	be nice to support existing non-Unicode catalogues.
     */

    public static String getline(TDFile fp)
 {
      throw new NotImplementedException();
  //int	i;
  //String buffpos;
  //bool	notEOF;
 
  //if(!linebuff) {
  //    maxline = 256;
  //    linebuff = new String[maxline];
  //    if (!linebuff)
  //  return null;
  //}
  //buffpos = linebuff;
  //i = maxline;
  //linebuff[maxline - 2] = 'n';
  //while ((notEOF = fp.ReadLine(buffpos, i))) {
  //    if(linebuff[maxline - 2] != 'n') {
  //        i = maxline - 1;
  //  maxline += 256;
  //  linebuff = (String)realloc(linebuff, maxline); //  Erik: Original code => realloc(linebuff , maxline * sizeof(linebuff[0]));
  //  if (!linebuff)
  //      return null;
  //  buffpos = &linebuff[i];
  //  i = maxline - i;
  //  linebuff[maxline - 2] = 'n';
  //    } else
  //  break;
  //}
  //if(!notEOF)
  //    return 0;
  //return linebuff;
    }

    /*	localized strings support (1.19)    */

    public static void set_full_file_name(String fullpath, String filename) {
//      if(!wxGetEnv(wxPorting.T("TDHOME"), &fullpath))
//        if(!wxGetEnv(wxPorting.T("HOME"), &fullpath)) {
//#if __unix__
//    fullpath = wxPorting.T("/tmp");	// only user-writable directory that's definitely present
//#else
//          fullpath = wxPorting.T("C:");	// only disk that's definitely present
//#endif
//        }
//      fullpath += wxPorting.T('/');
//      fullpath += filename;
    }

    public static int strhash(String s) {
      throw new NotImplementedException();
      //int h;

      //for(h = 0; *s; h += *s++) ;	/* very poor man's hash algorithm */
      //return h;
    }

    /*	convert "n" into newline characters */

    public static void convert_newlines(String buff) {
      //int i, j;

      //for(i = j = 0; buff[i]; ++i, ++j)
      //  if(buff[i] == '\\' && buff[i + 1] == 'n') {
      //    buff[j] = 'n';
      //    ++i;
      //  } else if(buff[i] == '\\' && buff[i + 1] == 't') {
      //    buff[j] = 't';
      //    ++i;
      //  } else
      //    buff[j] = buff[i];
      //buff[j] = 0;
    }

    public static String localize(String s) {
      throw new NotImplementedException();
      //lstring ls;
      //int h;

      //if(!wxStrcmp(locale_name, wxPorting.T("en")) || !wxStrcmp(locale_name, wxPorting.T(".en")))
      //  return s;
      //h = strhash(s);
      //for(ls = local_strings; ls; ls = ls.next) {
      //  if(ls.hash == h && !wxStrcmp(ls.en_string, s))
      //    return ls.loc_string;
      //}
      //return s;
    }

    public static void localizeArray(ref string[] localized, string[] english) {
      //int i;

      //localized = new string[english.Length];
      //for(i = 0; english[i]; ++i)
      //  localized[i] = String.Copy(wxPorting.LV(english[i]));
    }

    public static void freeLocalizedArray(string[] localized) {
      //int i;

      //for(i = 0; localized[i]; ++i) {
      //  Globals.free((object)localized[i]);
      //  localized[i] = 0;
      //}
    }

    public static void load_from_array(LocalizeInfo array) {
      //int i;
      //lstring ls;

      //for(i = 0; array[i].english; ++i) {
      //  ls = new lstring();
      //  ls.en_string = String.Copy(array[i].english);
      //  ls.hash = strhash(ls.en_string);
      //  ls.loc_string = String.Copy(array[i].other);
      //  ls.next = local_strings;
      //  local_strings = ls;
      //}
    }

    /*	Load all localized strings for 'locale'.
     *	Locale values should be in the standard
     *	2-character international country codes.
     *	By default, ".en" is ignored, since
     *	built-in strings are always in English.
     */

    public static void load_localized_strings(String locale) {
//      string buff;
//      String name;
//      lstring ls;
//      String p;
//      String p1;

//      if(!wxStrcmp(locale, wxPorting.T(".en")))
//        return;
//      set_full_file_name(name, String(wxPorting.T("Globals.traindir")) + locale);
//      TDFile fp = new TDFile(name);
//      if(!(fp.Load())) {
//#if __WXMAC__
//#else
//        if(!wxStrcmp(locale, wxPorting.T(".es")))
//          load_from_array(espanol);
//#endif
//        if(!wxStrcmp(locale, wxPorting.T(".it")))
//          load_from_array(italiano);
//        return;
//      }
//      while((p = getline(&fp))) {
//        if(p[0] == '#')	    /* comment */
//          continue;
//        if(!(p1 = (String)wxStrstr(p, wxPorting.T("@@"))))
//          continue;
//        buff = String.Copy( p1);

//        /*	isolate English string	*/

//        while(--p1 > p && (*p1 == ' ' || *p1 == 't')) ;
//        p1[1] = 0;

//        p1 = wxStrstr(buff, wxPorting.T("@@")) + 2;
//        while(*p1 == ' ' || *p1 == 't') ++p1;
//        convert_newlines(p1);

//        ls = new lstring();
//        ls.en_string = String.Copy(p);
//        convert_newlines(ls.en_string);
//        ls.hash = strhash(ls.en_string);
//        ls.loc_string = String.Copy(p1);
//        ls.next = local_strings;
//        local_strings = ls;
//      }
    }

  }
}