using DarkLegion.Core.Pooling;

using System.Collections.Generic;

using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderPoolHandler _pool;

    private readonly List<SpriteRenderer> _dots = new List<SpriteRenderer>();

    public void Draw(Dictionary<Vector3, Color> dotsData)
    {
        HideDots();
        foreach(var data in dotsData)
        { 
            var dot = _pool.Get();

            dot.transform.position = data.Key;
            dot.color = data.Value;
            
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
