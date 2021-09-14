using DarkLegion.Core.Command;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Field.Visuzalization;
using DarkLegion.Input;
using DarkLegion.UI;
using DarkLegion.Unit;
using DarkLegion.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field
{
    public class PlayerCommander : MonoBehaviour
    {
        [SerializeField] private Pathfinder _pathfinder;
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private List<SkillButton> _skillButtons;
        [SerializeField] private FlipButton _flipButton;

        [SerializeField] private TurnSystem _turnSystem;
        [Header("Visualization")]
        [SerializeField] private MovementCellVisualization _movementCellVisualization;
        [SerializeField] private PathVisualization _pathVisualization;

        [Header("Selecters")]
        [SerializeField] private TransformSelecting _everythingSelecting;
        [SerializeField] private UnitSelecting _enemyUnitSelectingForAttack;

        private Action _unSelectedHandelr;
        private Action<int> _skillButtonClickedHandler;
        private Action _flipButtonClickedHandler;
        private Action _turnChangedHandler;

        private void Awake()
        {
            _turnChangedHandler = () =>
            {
                if (_turnSystem.IsPlayerTurn && _turnSystem.ActiveUnit.ActionPoints.Value == 0)
                {
                    _turnSystem.ChangeTurn();
                }
            };
            _unSelectedHandelr += () =>
            {
                if (_turnSystem.IsPlayerTurn)
                {
                    TryMove(_turnSystem.ActiveUnit);
                }
            };
            _skillButtonClickedHandler += i => { TryUseSkill(_turnSystem.ActiveUnit, i); };
            _flipButtonClickedHandler += () => { TryFlip(_turnSystem.ActiveUnit); };
        }

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += _unSelectedHandelr;
            _turnSystem.TurnChanged += _turnChangedHandler;
            
            foreach(var button in _skillButtons)
            {
                button.SkillButtonClicked += _skillButtonClickedHandler;
            }
            
            _flipButton.Clicked += _flipButtonClickedHandler;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= _unSelectedHandelr;
            _turnSystem.TurnChanged -= _turnChangedHandler;
            
            foreach (var button in _skillButtons)
            {
                button.SkillButtonClicked -= _skillButtonClickedHandler;
            }
            
            _flipButton.Clicked -= _flipButtonClickedHandler;
        }

        public void TryMove(ComponentStorage who)
        {
            if (who && !who.CommandHandler.HasCommands)
            {
                var path = _pathfinder.FindPath(who.transform.position,
                    InputHandler.Instance.GetMousePosition());

                if (path.Count <= who.Movement.Value && path.Count != 0)
                {
                    _movementCellVisualization.ClearLastVisualize();
                    _pathVisualization.StopDraw();
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

                    var idleAnimationPlayCommand = new IdleAnimationPlayCommand(who.Animator);
                    idleAnimationPlayCommand.Completed += () =>
                    {
                        if(!TryChangeTurn(who))
                        {
                            _movementCellVisualization.Show(_turnSystem.ActiveUnit.transform.position, 
                                _turnSystem.ActiveUnit.Movement.Value);

                            _pathVisualization.StartDraw();
                        }
                    };
                
                    commands.Enqueue(idleAnimationPlayCommand);

                    who.ActionPoints.Set(who.ActionPoints.Value - 1);
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

        public void TryUseSkill(ComponentStorage who, int skillIndex)
        {
            if (who && !who.CommandHandler.HasCommands)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new AttackAnimationPlayCommand(who.Animator, skillIndex));
                commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));
                List<ComponentStorage> targets = new List<ComponentStorage>();
                foreach (var point in who.UnitSkillSet[skillIndex].TargetedCoordiantes)
                {
                    _enemyUnitSelectingForAttack.TrySelect(_gridHandler.GetWorldCenterPosition(_gridHandler.GetCell(who.transform.position)) 
                        + new Vector3(point.x * _gridHandler.CellSize.x, point.y * _gridHandler.CellSize.y, 0));

                    if (_enemyUnitSelectingForAttack.LastSelectedOrNull)
                    {
                        targets.Add(_enemyUnitSelectingForAttack.LastSelectedOrNull);
                    } 
                }
                commands.Enqueue(new AttackCommand(who, skillIndex, targets));

                who.CommandHandler.Do(commands);
            }
        }

        private bool TryChangeTurn(ComponentStorage unit)
        {
            if (unit.ActionPoints.Value == 0)
            {
                unit.ActionPoints.Dispose();
                _turnSystem.ChangeTurn();
                return true;
            }
            return false;
        }
        private bool GetFlip(Vector3 lastPoint, Vector3 point)
        {
             return point.x < lastPoint.x;
        }
    }
}
