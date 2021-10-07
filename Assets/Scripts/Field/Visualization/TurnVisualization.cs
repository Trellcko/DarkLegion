using DarkLegion.UI;
using DarkLegion.Unit;
using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;
using System;

namespace DarkLegion.Field.Visuzalization
{
    public class TurnVisualization : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Vector3 _step;

        [SerializeField] private Sprite _playerIcon;
        [SerializeField] private Sprite _enemyIcon;

        [SerializeField] private LayerMask _playerMask;


        [SerializeField] private List<TurnIcon> _turnIcons;

        private Dictionary<TurnIcon, ComponentStorage> _unitIconPairs;

        private void Start()
        {
            for (int i = 0; i < _turnIcons.Count; i++)
            {
                _turnIcons[i].transform.position = _startPoint.position + _step * (_turnIcons.Count - i - 1);
            }
        }

        public void Visualize(List<ComponentStorage> units)
        {
            _unitIconPairs = new Dictionary<TurnIcon, ComponentStorage>();

            for (int i = 0; i < _turnIcons.Count; i++)
            {
                ComponentStorage unit = units[i % units.Count];

                _unitIconPairs.Add(_turnIcons[i], unit);
                SetIconData(unit, _turnIcons[i]);
            }
        }

        public void MoveToStart(int iconIndex, List<ComponentStorage> activeUnits, List<ComponentStorage> units, Action completed)
        {
            TurnIcon icon = _turnIcons[iconIndex];
            ChangeOrder(new List<TurnIcon>() { icon }, GetSorterUnits(activeUnits, units), completed);

        }
        public void MoveToStart(ComponentStorage iconUnit, List<ComponentStorage> activeUnits, List<ComponentStorage> units, Action completed)
        {
            List<TurnIcon> turnIcons = new List<TurnIcon>();
            foreach(var unitIconPair in _unitIconPairs)
            {
                if(unitIconPair.Value == iconUnit)
                {
                    turnIcons.Add(unitIconPair.Key);
                }
            }
            ChangeOrder(turnIcons, GetSorterUnits(activeUnits, units), completed);
        }

        private void ChangeOrder(List<TurnIcon> offsetIcons, List<ComponentStorage> sortedUnits, Action completed)
        {
            Sequence sequence = DOTween.Sequence();
            
            int[] offsetIconsIndexes = new int[offsetIcons.Count];
            
            for (int i = 0; i < offsetIcons.Count; i++)
            {
                int temp = i;

                offsetIconsIndexes[i] = _turnIcons.IndexOf(offsetIcons[i]);
                sequence.Insert(0, offsetIcons[i].transform.DOMoveX(offsetIcons[i].transform.position.x - 5f, 1f)
                    .OnComplete(()=> 
                    {
                        SetIconData(sortedUnits[sortedUnits.Count + temp - _turnIcons.Count], offsetIcons[temp]);
                        offsetIcons[temp].transform.position = new Vector3(offsetIcons[temp].transform.position.x,
                            _startPoint.position.y + _step.y * temp, offsetIcons[temp].transform.position.z);
                    }));   
            }


            for (int i = 0; i < _turnIcons.Count; i++)
            {
                int temp = i;
                int moveModificator = 0;
                for (int j = offsetIconsIndexes.Length - 1; j > -1; j--)
                {
                    if (offsetIconsIndexes[j] == i)
                    {
                        continue;
                    }
                    if (offsetIconsIndexes[j] < i)
                    {
                        moveModificator++;
                    }
                   
                }
                if (moveModificator > 0)
                {
                    sequence.Insert(1, _turnIcons[temp].transform.DOMove(_turnIcons[temp].transform.position + _step * moveModificator, 1f));
                }
            }

            for(int  i = 0; i < offsetIcons.Count; i++)
            {
                int temp = i;
                sequence.Insert(2, offsetIcons[i].transform.DOMoveX( _startPoint.position.x, 1f));
            }
            sequence.OnComplete(() =>
            {
                ChangeOrderIcons(offsetIcons, _turnIcons);
                for(int  i = 0; i < _turnIcons.Count; i++)
                {
                    _unitIconPairs[_turnIcons[i]] = sortedUnits[i];
                }
                completed?.Invoke();
            });
            sequence.Play();
        }

        private void ChangeOrderIcons(List<TurnIcon> offsetIcons, List<TurnIcon> turnIcons)
        {
            for(int i = 0; i < offsetIcons.Count; i++)
            {
                turnIcons.Remove(offsetIcons[i]);
                turnIcons.Add(offsetIcons[i]);
            }
        }

        private void SetIconData(ComponentStorage unit, TurnIcon turnIcon)
        {
            Sprite backgroung = LayerExtension.ContainsIn(_playerMask, unit.gameObject.layer) ?
            _playerIcon : _enemyIcon;
            Sprite icon = unit.BaseInfo.TurnIcon;
            turnIcon.Set(backgroung, icon);
        }
        private List<ComponentStorage> GetSorterUnits(List<ComponentStorage> activeUnits, List<ComponentStorage> units)
        {
            var result = new List<ComponentStorage>(8);
            for (int i = 0; i < _turnIcons.Count * 2; i++)
            {
                ComponentStorage unit;

                if (activeUnits.Count <= i)
                {
                    unit = units[(i - activeUnits.Count) % units.Count];
                }
                else
                {
                    unit = activeUnits[i];
                }
                result.Add(unit);
            }
            return result;
        }
    }
}