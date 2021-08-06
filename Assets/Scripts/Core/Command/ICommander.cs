using System.Collections.Generic;

namespace DarkLegion.Core.Command
{
    public interface ICommander
    {
        Queue<ICommand> CreateCommands();
    }
}