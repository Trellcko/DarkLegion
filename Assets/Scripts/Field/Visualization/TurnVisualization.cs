using DarkLegion.UI;
using DarkLegion.Unit;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class TurnVisualization : MonoBehaviour
    {
        [SerializeField] private Sprite _playerIcon;
        [SerializeField] private Sprite _enemyIcon;

        [SerializeField] private LayerMask _playerMask;


        [SerializeField] private List<TurnIcon> _turnIcons;

        public void Visualize(List<ComponentStorage> activeUnits, List<ComponentStorage> units)
        {
            for (int  i = 0; i < _turnIcons.Count; i++)
            {
                ComponentStorage unit;

                if (activeUnits.Count <= i)
                {
                    unit = units[(i - activeUnits.Count)  % units.Count];
                }
                else
                {
                    unit = activeUnits[i];
                }
                SetIcon(unit, _turnIcons[i]);
            }
        }

        private void SetIcon(ComponentStorage unit, TurnIcon turnIcon)
        {
            Sprite backgroung = LayerExtension.ContainsIn(_playerMask, unit.gameObject.layer) ?
            _playerIcon : _enemyIcon;
            Sprite icon = unit.BaseInfo.TurnIcon;
            turnIcon.Set(backgroung, icon);
        }
    }
}