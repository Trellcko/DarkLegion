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
        [SerializeField] private TurnSystem _turnSystem;
        [SerializeField] private TransformSelecting _everythingSelecting;
        [SerializeField] private UnitSelecting _enemyUnitSelectingForAttack;

        private Action _unSelectedHandelr;
        private Action<int> _skillButtonClickedHandler;
        private Action _flipButtonClickedHandler;

        private ComponentStorage _playerActiveUnit;

        private void Awake()
        {
            _unSelectedHandelr += () => { TryMove(_playerActiveUnit); };
            _skillButtonClickedHandler += i => { TryUseSkill(_playerActiveUnit, i); };
            _flipButtonClickedHandler += () => { TryFlip(_playerActiveUnit); };
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

        public void TryMove(ComponentStorage who)
        {
            if (who)
            {
                var path = _pathfinder.FindPath(who.transform.position,
                    InputHandler.Instance.GetMousePosition());

                if (path.Count <= who.Movement.Value && path.Count != 0)
                {
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

                    commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));

                    who.CommandHandler.Do(commands);
                }
            }
        }

        public void TryFlip(ComponentStorage who)
        {
            if (who)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new FlipCommand(who.transform));
                who.CommandHandler.Do(commands);
            }
        }

        public void TryUseSkill(ComponentStorage who, int skillIndex)
        {
            if (who)
            {
                var commands = new Queue<ICommand>();
                commands.Enqueue(new AttackAnimationPlayCommand(who.Animator, skillIndex));
                commands.Enqueue(new IdleAnimationPlayCommand(who.Animator));
                List<ComponentStorage> targets = new List<ComponentStorage>();
                foreach (var point in who.UnitSkillSet.Skills[skillIndex].TargetedCells)
                {
                    _enemyUnitSelectingForAttack.TrySelect(point.position);
                    Debug.Log(point.position);
                    if (_enemyUnitSelectingForAttack.LastSelectedOrNull)
                    {
                        targets.Add(_enemyUnitSelectingForAttack.LastSelectedOrNull);
                    } 
                }
                commands.Enqueue(new AttackCommand(who, skillIndex, targets));

                who.CommandHandler.Do(commands);
            }
        }

        private bool GetFlip(Vector3 lastPoint, Vector3 point)
        {
             return point.x < lastPoint.x;
        }
    }
}
