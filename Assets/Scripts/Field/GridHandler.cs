using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private Grid _grid;

    public Vector2 CellSize => _grid.cellSize;

    public bool CheckForFreeSpace(Vector3Int cell, LayerMask layers)
    {
        return Physics2D.OverlapCircleNonAlloc(GetWorldCenterPosition(cell), (CellSize.x / 2) - 0.05f, new Collider2D[1], layers) == 0;
    }

    public Vector3 GetWorldCenterPosition(Vector3Int cell)
    {
        return _grid.GetCellCenterWorld(cell);
    }

    public Vector3 GetWorldPosition(Vector3Int cell)
    {
        return _grid.CellToWorld(cell);
    }

    public Vector3Int GetCell(Vector3 worldPosition)
    {
        return _grid.WorldToCell(worldPosition);
    }

}
