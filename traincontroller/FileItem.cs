using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDirNET {
  public class FileItem {
    public FileItem next = null;
    public string name;
    public int size = 0;
    public char[] content = new char[0];

    public FileItem(string item) {
      name = item;
    }
  }
}
