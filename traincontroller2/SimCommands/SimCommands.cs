using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainController.SimCommands {
  public enum Command {
    Open,
    Load
  }

  public abstract class SimCommand {
    public Command Command { get; private set; }
    protected SimCommand(Command command) {
      Command = command;
    }

    //public abstract void DoCommand() {
    //}
  }

  public class LoadBaseCommand : SimCommand {
    public String Filename { get; private set; }

    public LoadBaseCommand(Command command, String filename)
      : base(command) {
      Filename = filename;
    }
  }

  public class LoadCommand : LoadBaseCommand {
    public LoadCommand(String filename)
      : base(Command.Open, filename) {
    }
  }

  public class OpenCommand : LoadBaseCommand {
    public OpenCommand(String filename)
      : base(Command.Load, filename) {
    }
  }
}
