using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster
{
    public T Hit<T>(Vector2 from) where T : Component
    {
        var result = default(T);
        var hit = Physics2D.Raycast(from, Vector2.zero, 0f);

        if (hit)
        {
            hit.transform.TryGetComponent(out result);
        }
        return result;
    }
}
