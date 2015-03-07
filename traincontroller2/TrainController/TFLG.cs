using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController {
  [Flags]
  public enum TFLG {
    TFLG_TURNED = 1,			/* train changed direction */
    TFLG_THROWN = 2,			/* switch was thrown */
    TFLG_WAITED = 4,			/* train waited at signal */
    TFLG_MERGING = 8,			/* train is shunting to merge with another train */
    TFLG_STRANDED = 16,		/* material left on track without engine */
    TFLG_WAITINGMERGE = 32,		/* another train is approaching us to be merged */
    TFLG_ENTEREDLATE = 64,		/* don't penalize for late arrivals */
    TFLG_GOTDELAYATSTOP = 128,		/* only select delay (or none) once */
    TFLG_SETLATEARRIVAL = 256,		/* only compute late arrival once */
    TFLG_SWAPHEADTAIL = 512,		/* swap loco and caboose icons */
    TFLG_DONTSTOPSHUNTERS = 1024,      // don't stop here if train is shunting
  }
}
