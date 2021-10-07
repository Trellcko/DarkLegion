using DarkLegion.Field;
using DarkLegion.Unit.AttackSystem.Visualization;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class BuffStorage : MonoBehaviour
    {
        [SerializeField] private BuffAttachVisualization _buffAttachVisualization;

        private TurnSystem _turnSystem;

        private Action _turnChangedHandler;

        private readonly List<IBuff> _buffs = new List<IBuff>();

        private void Awake()
        {
            _turnSystem = FindObjectOfType<TurnSystem>();
            _turnChangedHandler += () =>
            {
                if (_turnSystem.ActiveUnit.BuffStorage == this)
                {
                    DecreaseDurationAllBuffs();
                }
            };
        }

        private void OnEnable()
        {
            _turnSystem.TurnChanged += _turnChangedHandler;
        }

        private void OnDisable()
        {
            _turnSystem.TurnChanged -= _turnChangedHandler;
        }

        private void DecreaseDurationAllBuffs()
        {
            foreach(var buff in _buffs)
            {
                buff.DecreaseDuration();
                if(buff.IsBuffActionCompleted)
                {
                    buff.Undo();
                    _buffs.Remove(buff);
                }
                
            }
        }

        public void Add(IBuff buff)
        {
            _buffs.Add(buff);
            buff.Do();

            if (buff.IsPositiveBuff)
            {
                _buffAttachVisualization.ShowPositiveEffect();
                return;
            }
            _buffAttachVisualization.ShowNegativeEffect();
        }
    }
}