using DarkLegion.Core.Command;
using DarkLegion.Field.Pathfinding;
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

        [SerializeField] private List<SkillButton> _skillButtons;
        [SerializeField] private FlipButton _flipButton;

        [Header("Selecters")]
        [SerializeField] private UnitSelecting _playerUnitSelecting;
        [SerializeField] private TransformSelecting _everythingSelecting;

        private Action _unSelectedHandelr;
        private Action<int> _skillButtonClickedHandler;
        private Action _flipButtonClickedHandler;

        private void Awake()
        {
            _unSelectedHandelr += () => { TryMoveUnit(_playerUnitSelecting.LastSelectedOrNull); };
            _skillButtonClickedHandler += i => { TryAttackUnit(_playerUnitSelecting.LastSelected, i); };
            _flipButtonClickedHandler += () => { TryFlipUnit(_playerUnitSelecting.LastSelected); };
        }

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += _unSelectedHandelr;
            
            foreach(var button in _skillButtons)
            {
                button.SkillButtonClicked += _skillButtonClickedHandler;
            }
            
            _flipButton.Clicked += _flipButtonClickedHandler;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= _unSelectedHandelr;
            
            foreach (var button in _skillButtons)
            {
                button.SkillButtonClicked += _skillButtonClickedHandler;
            }
            
            _flipButton.Clicked -= _flipButtonClickedHandler;
        }

        public void TryMoveUnit(ComponentStorage unit)
        {
            if (unit)
            {
                var path = _pathfinder.FindPath(unit.transform.position,
                    InputHandler.Instance.GetMousePosition());

                if (path.Count <= unit.BaseStats.MaxStep && path.Count != 0)
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

        public void TryFlipUnit(ComponentStorage who)
        {
            if (who)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new FlipCommand(who.transform));
                who.CommandHandler.Do(commands);
            }
        }

        public void TryAttackUnit(ComponentStorage who, int attackIndex)
        {
            if (who)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new AttackAnimationPlayCommand(who.Animator, attackIndex));
                commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));

                who.CommandHandler.Do(commands);
            }
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
