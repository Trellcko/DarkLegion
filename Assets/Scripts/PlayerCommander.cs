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
                var commands = new Queue<ICommand>();
             
                var lastPoint = _playersUnitSelecting.LastSelectedOrNull.transform.position;
                
                foreach (var point in path)
                {
                    var targetFlipPoint = Mathf.Abs(point.x - lastPoint.x) > 0.01f ? point : path[path.Count - 1];

                    commands.Enqueue(GetFlipCommand(lastPoint, targetFlipPoint));
                    commands.Enqueue(GetMovementCommand(point));

                    lastPoint = point;
                }
                _playersUnitSelecting.LastSelectedOrNull.CommandHandler.Do(commands);
            }
        }
    }

    private MovementCommand GetMovementCommand(Vector3 point)
    {
        return new MovementCommand(_playersUnitSelecting.LastSelectedOrNull.transform, point);
    }

    private FlipCommand GetFlipCommand(Vector3 lastPoint, Vector3 point)
    {
        bool isLeft = point.x < lastPoint.x;
        return new FlipCommand(_playersUnitSelecting.LastSelectedOrNull.SpriteRender, isLeft);
    }
}