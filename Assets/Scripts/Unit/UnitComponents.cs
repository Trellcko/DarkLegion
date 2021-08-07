using DarkLegion.Utils.Command;
using UnityEngine;

namespace DarkLegion.Unit
{
    public class UnitComponents : MonoBehaviour
    {
        [SerializeField] private CommandHandler _commandHandler;

        public CommandHandler CommandHandler => _commandHandler;
    }
}