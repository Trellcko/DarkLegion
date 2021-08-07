using DarkLegion.Utils.Command;
using DarkLegion.Utils;
using DarkLegion.Utils.Pathfinding;
using DarkLegion.Input;

using System.Collections.Generic;
using UnityEngine;

public class PlayerCommander : MonoBehaviour
{
    [SerializeField] private Pathfinder _pathfinder;

    [SerializeField] private UnitSelecting _playersUnitSelecting;
    [SerializeField] private TransformSelecting _everythingSelecting;

    private void OnEnable()
    {
        _everythingSelecting.UnSelected += TryMoveUnit;
    }

    private void OnDisable()
    {
        _everythingSelecting.UnSelected -= TryMoveUnit;
    }

    private void TryMoveUnit()
    {
        if (_playersUnitSelecting.LastSelectedOrNull)
        {
            var path = _pathfinder.FindPath(_playersUnitSelecting.LastSelectedOrNull.transform.position,
                InputHandler.Instance.GetMousePosition());

            if (path.Count <= _playersUnitSelecting.LastSelectedOrNull.UnitData.MaxStep)
            {
                Queue<ICommand> commands = new Queue<ICommand>();

                foreach (var point in path)
                {
                    commands.Enqueue(new UnitMovementCommand(_playersUnitSelecting.LastSelectedOrNull.transform, point));
                }
                _playersUnitSelecting.LastSelectedOrNull.GetComponent<CommandHandler>().Do(commands);
            }
        }
    }
}