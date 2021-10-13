using DarkLegion.Core.Command;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Input;
using DarkLegion.Unit;
using DarkLegion.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DarkLegion.Unit.AttackSystem;

namespace DarkLegion.Field
{
    public class PlayerCommander : MonoBehaviour
    {
        [SerializeField] private Pathfinder _pathfinder;
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private TurnSystem _turnSystem;

        [Header("Selecters")]
        [SerializeField] private TransformSelecting _everythingSelecting;
        [SerializeField] private UnitSelecting _enemyUnitSelectingForAttack;

        public event Action UnitMoving;
        public event Action<bool> UnitMoved;
        public event Action UnitAttacking;
        public event Action<bool> UnitAttacked;

        private Action _unSelectedHandelr;

        private void Awake()
        {
            _unSelectedHandelr += () =>
            {
                if (_turnSystem.IsPlayerTurn)
                {
                    TryMove(_turnSystem.ActiveUnit);
                }
            };
        }

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += _unSelectedHandelr;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= _unSelectedHandelr;
        }

        public void TryMove(ComponentStorage who)
        {
            if (who && !who.CommandHandler.HasCommands)
            {
                var path = _pathfinder.FindPath(who.transform.position,
                    InputHandler.Instance.GetMousePosition());

                if (path.Count <= who.Movement.Value && path.Count != 0)
                {
                    UnitMoving?.Invoke();
                    var commands = new Queue<ICommand>();
                    var lastPoint = who.transform.position;

                    commands.Enqueue(new MovementAnimationPlayCommand(who.Animator));

                    for (int i = 1; i < path.Count; i++)
                    {
                        var targetFlipPoint = Mathf.Abs(path[i].x - lastPoint.x) > 0.01f ? path[i] : path[path.Count - 1];

                        commands.Enqueue(new FlipCommand(who.transform, GetFlip(lastPoint, targetFlipPoint)));

                        commands.Enqueue(new MovementCommand(who.transform, path[i]));

                        lastPoint = path[i];
                    }
                    commands.Last().Completed += () =>
                    {
                        who.ActionPoints.Set(who.ActionPoints.Value - 1);
                        UnitMoved?.Invoke(TurnWasChanged(who) == false);
                    };

                    commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));
                    who.CommandHandler.Do(commands);
                }
            }
        }

        public void TryFlip(ComponentStorage who)
        {
            if (who && !who.CommandHandler.HasCommands)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new FlipCommand(who.transform));
                who.CommandHandler.Do(commands);
            }
        }

        public void TryUseSkill(ComponentStorage who, Skill skill)
        {
            if (who && !who.CommandHandler.HasCommands && who.SkillSet.Has(skill) && 
                who.ActionPoints.Value >= skill.Cost)
            {
                int skillIndex = who.SkillSet.IndexOf(skill);
                UnitAttacking?.Invoke();
                var commands = new Queue<ICommand>();
                commands.Enqueue(new AttackAnimationPlayCommand(who.Animator, skillIndex));
                List<ComponentStorage> targets = new List<ComponentStorage>();
                foreach (var point in who.SkillSet[skillIndex].TargetedCoordiantes)
                {
                    Vector3 enemyCellWorldCoordiantes = _gridHandler.GetWorldCenterPosition(_gridHandler.GetCell(who.transform.position))
                        + new Vector3(point.x * _gridHandler.CellSize.x, point.y * _gridHandler.CellSize.y, 0);
                    _enemyUnitSelectingForAttack.TrySelect(_gridHandler.Centralize(enemyCellWorldCoordiantes));
                    if (_enemyUnitSelectingForAttack.LastSelectedOrNull)
                    {
                        targets.Add(_enemyUnitSelectingForAttack.LastSelectedOrNull);
                    } 
                }
                commands.Enqueue(new AttackCommand(who, skillIndex, targets));
                commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));
                commands.Last().Completed += () =>
                {

                    who.ActionPoints.Set(who.ActionPoints.Value - who.SkillSet[skillIndex].Cost);
                    UnitAttacked?.Invoke(TurnWasChanged(who) == false);
                   
                };
                who.CommandHandler.Do(commands);
            }
        }

        private bool TurnWasChanged(ComponentStorage unit)
        {
            return unit.ActionPoints.Value == 0;
        }

        private bool GetFlip(Vector3 lastPoint, Vector3 point)
        {
             return point.x < lastPoint.x;
        }
    }
}
