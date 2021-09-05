using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class CommandHandler : MonoBehaviour
    {
        Queue<ICommand> _commands;
        public void Do(Queue<ICommand> commands)
        {
            _commands = commands;
            DoNext();
        }

        private void DoNext()
        {
            if (_commands.Count == 0)
            {
                return;
            }
            var command = _commands.Dequeue();
            command.Completed += DoNext;
            command.Execute();
        }
    }
}