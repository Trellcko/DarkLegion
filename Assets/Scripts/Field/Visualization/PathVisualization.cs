using DarkLegion.Field.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathVisualization : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Transform _endPoint;
    
    [SerializeField] private PathDrawer _drawer;

    [SerializeField] private Pathfinder _pathfinder;

    private void Update()
    {
        _drawer.Draw(_pathfinder.FindPath(point.position, _endPoint.position).ToArray());

    }
}
