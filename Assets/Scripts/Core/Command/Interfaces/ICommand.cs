using System;

namespace DarkLegion.Core.Command
{
    public interface ICommand
    {
        event Action Completed;
        event Action Canceled;

        void Execute();

        void Undo();
    }
}