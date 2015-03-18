using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainController.CustomControls {
  public class ToolStripNumericUpDown : ToolStripButton {
    public decimal Value { get; set; }
  }
}
