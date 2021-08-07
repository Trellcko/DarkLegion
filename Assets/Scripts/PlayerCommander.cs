using DarkLegion.Core.Command;
using DarkLegion.Core.Pathfinding;
using DarkLegion.Input;

using System.Collections.Generic;
using UnityEngine;
using DarkLegion.Utils;

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

            if (path.Count <= _playersUnitSelecting.LastSelectedOrNull.UnitData.MaxStep && path.Count != 0)
            {
                Queue<ICommand> commands = new Queue<ICommand>();
                var lastPoint = path[0];
                foreach (var point in path)
                {
                    commands.Enqueue(new MovementCommand(_playersUnitSelecting.LastSelectedOrNull.transform, point));
                }
                _playersUnitSelecting.LastSelectedOrNull.GetComponent<CommandHandler>().Do(commands);
            }
        }
    }
}