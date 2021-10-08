using DarkLegion.Unit.AttackSystem;
using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class AttackVizualizationHandler : MonoBehaviour
    {
        [SerializeField] private AttackedCellVisualization _attackedCellVisualization;

        [SerializeField] private TurnSystem _turnSystem;

        private bool _isVizualizing = false;

        public void Show(Skill skill)
        {
            if (_turnSystem.ActiveUnit.CommandHandler.HasCommands == false)
            {
                _isVizualizing = true;
                _attackedCellVisualization.Show(skill.StartPoint.position, skill.TargetedCoordiantes);
            }
        }
        public void Hide(Skill skill)
        {
            if (_isVizualizing == true)
            {
                if (_turnSystem.ActiveUnit.CommandHandler.HasCommands)
                {
                    _attackedCellVisualization.Clear();
                }
                else
                {
                    _attackedCellVisualization.ReturnPreviousColors();
                }
                _isVizualizing = false;
            }
        }
    }
}