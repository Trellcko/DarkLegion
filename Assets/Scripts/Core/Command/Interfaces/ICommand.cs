using System;

namespace DarkLegion.Core.Command
{
    public interface ICommand
    {
        event Action Completed;

        void Execute();
    }
}