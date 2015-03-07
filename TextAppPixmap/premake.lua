-- Premake script for the wx.NET "ListCtrl" sample.
-- See http://premake.sourceforge.net/ for more info about Premake.

package.name     = "ListCtrl"
package.language = "c#"
package.kind     = "winexe"
package.target   = "listctrl"
project.bindir   = "../Bin"

package.links    = { "System.Drawing", "wx.NET" }

package.files    = { "ListCtrl.cs" }
