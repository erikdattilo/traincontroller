using System;
using System.Collections.Generic;
using System.Text;
using wx;

namespace TrainDirNET {
  public class Itinerary : ClientData {
    public Itinerary next; // Itinerary* next;
    public int visited;	/* flag to avoid endless loop */
    public string name;		/* name of itinerary */
    public string signame;	/* name of start signal */
    public string endsig;	/* name of end signal */
    public string nextitin;	/* next itinerary automatically activated */
    public int nsects, maxsects;/* sections are signal-to-signal */
    public switin[] sw = new switin[0];

    public string _iconSelected;
    public string _iconDeselected;

    // public void* _interpreterData;
  }
}
