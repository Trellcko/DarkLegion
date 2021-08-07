using UnityEngine;

[CreateAssetMenu(fileName = "New UnitData", menuName = "Units/UnitData", order = 41)]
public class UnitData : ScriptableObject
{
    [SerializeField] private float _maxStep;

    public float MaxStep => _maxStep;
}
