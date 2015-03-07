using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  public static class z___ExtensionMethods {
    public static bool IsNullOrWhiteSpaces(this String str) {
      return (str == null) || str.Trim().Length == 0;
    }
  }

  public static class String1 {
    public static bool IsNullOrWhiteSpaces(String str) {
      return (str == null) || str.Trim().Length == 0;
    }
  }
}
