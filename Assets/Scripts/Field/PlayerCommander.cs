using DarkLegion.Core.Command;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Input;
using DarkLegion.Units;
using DarkLegion.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field
{
    public class PlayerCommander : MonoBehaviour
    {
        [SerializeField] private Pathfinder _pathfinder;

        [Header("Selecters")]
        [SerializeField] private UnitSelecting _playerUnitSelecting;
        [SerializeField] private TransformSelecting _everythingSelecting;

        private Action _unSelectedHandelr;

        private void Awake()
        {
            _unSelectedHandelr += () => { TryMoveUnit(_playerUnitSelecting.LastSelected); };
            
        }

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += _unSelectedHandelr;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= _unSelectedHandelr;
        }

        public void TryMoveUnit(Unit unit)
        {
            if (unit)
            {
                var path = _pathfinder.FindPath(unit.transform.position,
                    InputHandler.Instance.GetMousePosition());

                if (path.Count <= unit.Data.MaxStep && path.Count != 0)
                {
                    var commands = new Queue<ICommand>();
                    var lastPoint = unit.transform.position;
                    
                    commands.Enqueue(new MovementAnimationPlayCommand(unit.Animator));
                    
                    for (int i = 1; i < path.Count; i++)
                    {
                        var targetFlipPoint = Mathf.Abs(path[i].x - lastPoint.x) > 0.01f ? path[i] : path[path.Count - 1];

                        commands.Enqueue(new FlipCommand(unit.transform, GetFlip(lastPoint, targetFlipPoint)));
                        
                        commands.Enqueue(GetMovementCommand(path[i], unit.transform));

                        lastPoint = path[i];
                    }

                    commands.Enqueue(new IdleAnimationPlayCommand(unit.Animator));

                    unit.CommandHandler.Do(commands);
                }
            }
        }

        public void TryAttackUnit(Unit unit, int attackIndex)
        {
            var commands = new Queue<ICommand>();
            commands.Enqueue(new AttackAnimationPlayCommand(unit.Animator, attackIndex));
            commands.Enqueue(new IdleAnimationPlayCommand(unit.Animator));

            unit.CommandHandler.Do(commands);
        }

        private MovementCommand GetMovementCommand(Vector3 point, Transform self)
        {
            return new MovementCommand(self, point);
        }

        private bool GetFlip(Vector3 lastPoint, Vector3 point)
        {
             return point.x < lastPoint.x;
        }
    }
}
