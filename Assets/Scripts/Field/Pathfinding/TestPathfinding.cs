using DarkLegion.Field.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathfinding : MonoBehaviour
{
    [SerializeField] private Pathfinder pathfinder;

    [SerializeField] private Transform from;
    [SerializeField] private Transform to;

    public LineRenderer _linerender;

    public void Start()
    {
        var path = pathfinder.FindPath(from.position, to.position);
        _linerender.positionCount = path.Count;
        _linerender.SetPositions(path.ToArray());
    }
}
