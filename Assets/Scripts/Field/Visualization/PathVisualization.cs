using DarkLegion.Utils.Pathfinding;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Utils.Visuzalization
{
    public class PathVisualization : MonoBehaviour
    {
        [SerializeField] private Selecting _playerUnitSelecting;

        [SerializeField] private PathDrawer _drawer;

        [SerializeField] private Pathfinder _pathfinder;

        
        private void Update()
        {
            var dotsData = new Dictionary<Vector3, Color>();
            for (int i = 0; i < 0; i++)
            {
            
            }
            _drawer.Draw(dotsData);
        }
    }
}