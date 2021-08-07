using System;

namespace DarkLegion.Utils.Command
{
    public interface ICommand
    {
        event Action Completed;
        event Action Canceled;

        void Execute();

        void Undo();
    }
}