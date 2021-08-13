using UnityEngine;

namespace DarkLegion.Field
{
    public class FieldInfo : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private Transform _startPoint;

        [SerializeField] private Vector3Int _size;

        [SerializeField] private LayerMask _fieldsLayers;

        public Vector3Int InitCell { get; private set; }

        public Vector3Int EndCell { get; private set; }

        public Transform StartPoint => _startPoint;

        public Vector3Int Size => _size;

        public LayerMask FieldsLayers => _fieldsLayers;

        private void Awake()
        {
            InitCell = _gridHandler.GetCell(_startPoint.position);
            InitCell = new Vector3Int(InitCell.x, InitCell.y, 0);
            EndCell = InitCell + _size;
        }

    }
}