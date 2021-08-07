using DarkLegion.Core.Command;
using UnityEngine;

namespace DarkLegion.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private CommandHandler _commandHandler;
        [SerializeField] private UnitData _data;

        public CommandHandler CommandHandler => _commandHandler;
        public UnitData UnitData => _data;
    }
}