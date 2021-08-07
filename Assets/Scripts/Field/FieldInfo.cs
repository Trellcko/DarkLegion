using UnityEngine;

namespace DarkLegion.Core
{
    public class FieldInfo : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;

        [SerializeField] private Vector2Int _size;

        [SerializeField] private LayerMask _fieldsLayers;

        public Transform StartPoint => _startPoint;

        public Vector2Int Size => _size;

        public LayerMask FieldsLayers => _fieldsLayers;

    }
}