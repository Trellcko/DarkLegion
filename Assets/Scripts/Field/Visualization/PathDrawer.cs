using DarkLegion.Core.Pooling;

using System.Collections.Generic;

using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private GameObjectPoolHandler _pool;

    private readonly List<GameObject> _dots = new List<GameObject>();

    public void Draw(Vector3[] positions)
    {
        HideDots();
        for(int  i = 0; i < positions.Length; i++)
        {
            var dot = _pool.Get();
            dot.transform.position = positions[i];
            _dots.Add(dot);
        }
    }

    private void HideDots()
    {
        foreach(var dot in _dots)
        {
            _pool.Add(dot);
        }
        _dots.Clear();
    }
}
