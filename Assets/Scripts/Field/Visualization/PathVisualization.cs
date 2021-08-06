using DarkLegion.Field.Pathfinding;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class PathVisualization : MonoBehaviour
    {
        [SerializeField] private Transform point;
        [SerializeField] private Transform _endPoint;

        [SerializeField] private PathDrawer _drawer;

        [SerializeField] private Pathfinder _pathfinder;

        private int maxStep = 5;

        private void Update()
        {
            var path = _pathfinder.FindPath(point.position, _endPoint.position);
            var dotsData = new Dictionary<Vector3, Color>();
            for (int i = 0; i < path.Count; i++)
            {
                var currentColor = i < maxStep ? Color.green : Color.red;
                dotsData.Add(path[i], currentColor);
            }
            _drawer.Draw(dotsData);

        }
    }
}