using DarkLegion.Core.Pooling;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderPoolHandler _pool;

    [SerializeField] private SpriteRenderer _endDot;
 
    private readonly List<SpriteRenderer> _dots = new List<SpriteRenderer>();

    public void Draw(Dictionary<Vector3, Color> dotsData)
    {
        HideDots();
        
        for(int  i = 0; i < dotsData.Count - 1; i++)
        {
            var data = dotsData.ElementAt(i);
            var dot = _pool.Get();
            ConfigureDot(data, dot);
            _dots.Add(dot);
        }
        _endDot.gameObject.SetActive(true);
        ConfigureDot(dotsData.ElementAt(dotsData.Count - 1), _endDot);
    }

    private static void ConfigureDot(KeyValuePair<Vector3, Color> data, SpriteRenderer dot)
    {
        dot.transform.position = data.Key;
        dot.color = data.Value;
    }

    private void HideDots()
    {
        foreach(var dot in _dots)
        {
            _pool.Add(dot);
        }
        _endDot.gameObject.SetActive(false);
        _dots.Clear();
    }
}
