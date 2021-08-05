using DarkLegion.Field.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathfinding : MonoBehaviour
{
    public LineRenderer lineRender;

    public Transform from;

    public Transform to;
    public Pathfinder pth;

    private void Start()
    {
        List<Vector3> vector2s = pth.FindPath(from.position, to.position);
        lineRender.positionCount = vector2s.Count;
        lineRender.SetPositions(vector2s.ToArray());
    }

}
