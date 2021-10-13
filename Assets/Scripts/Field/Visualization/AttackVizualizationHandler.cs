using DarkLegion.Unit.AttackSystem;
using System.Collections;
using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class AttackVizualizationHandler : MonoBehaviour
    {
        [SerializeField] private AttackedCellVisualization _attackedCellVisualization;

        [SerializeField] private TurnSystem _turnSystem;

        private bool _isVizualizing = false;

        private bool CanVisualize => _turnSystem.ActiveUnit && _turnSystem.ActiveUnit.CommandHandler.HasCommands == false;

        private Coroutine _delayShowCorun;

        public void Show(Skill skill)
        {
            if (CanVisualize)
            {
                Visualize(skill);
                return;
            }
            DelayShow(skill);
        }

        public void Hide(Skill skill)
        {
            if (_isVizualizing == true)
            {
                if (_turnSystem.ActiveUnit == null)
                {
                    _attackedCellVisualization.Clear();
                }
                else
                {
                    _attackedCellVisualization.ReturnPreviousColors();
                }
                _isVizualizing = false;
            }
            StopDelayShow();
        }
        
        private void StopDelayShow()
        {
            if (_delayShowCorun != null)
            {
                StopCoroutine(_delayShowCorun);
            }
        }

        private void DelayShow(Skill skill)
        {
           _delayShowCorun = StartCoroutine(DelayShowCorun(skill));
        }
        private IEnumerator DelayShowCorun(Skill skill)
        {
            yield return new WaitUntil(() => CanVisualize);
            Visualize(skill);
        }

        private void Visualize(Skill skill)
        {
            _isVizualizing = true;
            _attackedCellVisualization.Show(skill.StartPoint.position, skill.TargetedCoordiantes);
        }
    }
}