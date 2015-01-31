using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  class Translations {

    public static void LocalizeArray(string[] localized, string[] english) {
      int i;

      for(i = 0; i < english.Length && english[i] != null; ++i)
        localized[i] = wxPorting.Strdup(wxPorting.LV(english[i]));
    }
  }
}