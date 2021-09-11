using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class CommandHandler : MonoBehaviour
    {
        public bool HasCommands => _commands.Count != 0;

        private Queue<ICommand> _commands = new Queue<ICommand>();

        public void Do(Queue<ICommand> commands)
        {
            if(commands == null)
            {
                return;
            }   
            
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