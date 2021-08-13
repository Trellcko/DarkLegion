using UnityEngine;
namespace DarkLegion.Units
{
    [CreateAssetMenu(fileName = "New UnitData", menuName = "Units/UnitData", order = 41)]
    public class UnitData : ScriptableObject
    {
        [SerializeField] private int _maxStep;

        public int MaxStep => _maxStep;
    }
}