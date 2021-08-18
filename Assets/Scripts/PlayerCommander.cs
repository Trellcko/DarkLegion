using DarkLegion.Core.Command;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Input;

using System.Collections.Generic;
using UnityEngine;
using DarkLegion.Utils;

public class PlayerCommander : MonoBehaviour
{
    [SerializeField] private Pathfinder _pathfinder;

    [Header("Selecters")]
    [SerializeField] private UnitSelecting _playerUnitSelecting;
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
        if (_playerUnitSelecting.LastSelectedOrNull)
        {
            var path = _pathfinder.FindPath(_playerUnitSelecting.LastSelectedOrNull.transform.position,
                InputHandler.Instance.GetMousePosition());

            if (path.Count <= _playerUnitSelecting.LastSelectedOrNull.UnitData.MaxStep && path.Count != 0)
            {
                var commands = new Queue<ICommand>();
             
                var lastPoint = _playerUnitSelecting.LastSelectedOrNull.transform.position;
                commands.Enqueue(new MovementAnimationPlayCommand(_playerUnitSelecting.LastSelected.Animator));
                for(int  i = 1; i < path.Count; i++)
                {
                    var targetFlipPoint = Mathf.Abs(path[i].x - lastPoint.x) > 0.01f ? path[i] : path[path.Count - 1];
                    
                    commands.Enqueue(GetFlipCommand(lastPoint, targetFlipPoint, _playerUnitSelecting.LastSelected.SpriteRender));
                    commands.Enqueue(GetMovementCommand(path[i], _playerUnitSelecting.LastSelected.transform));

                    lastPoint = path[i];
                }

                commands.Enqueue(new IdleAnimationPlayCommand(_playerUnitSelecting.LastSelected.Animator));
                _playerUnitSelecting.LastSelectedOrNull.CommandHandler.Do(commands);
            }
        }
    }

    private MovementCommand GetMovementCommand(Vector3 point, Transform self)
    {
        return new MovementCommand(self, point);
    }

    private FlipCommand GetFlipCommand(Vector3 lastPoint, Vector3 point, SpriteRenderer sprite)
    {
        bool isLeft = point.x < lastPoint.x;
        return new FlipCommand(sprite, isLeft);
    }
}