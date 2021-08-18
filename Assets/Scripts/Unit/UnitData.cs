using UnityEngine;
namespace DarkLegion.Units
{
    [CreateAssetMenu(fileName = "New UnitData", menuName = "Units/UnitData", order = 41)]
    public class UnitData : ScriptableObject
    {
        [SerializeField] private int _maxStep;
        [Range(0f, 100f), SerializeField] private float _physicalDamage;

        public int MaxStep => _maxStep;
        public float PhysicalDamage => _physicalDamage;
    }
}