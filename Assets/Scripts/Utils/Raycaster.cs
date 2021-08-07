using UnityEngine;

namespace DarkLegion.Physics
{
    public class Raycaster
    {
        public T Hit<T>(Vector2 from, LayerMask layers) where T : Component
        {
            var result = default(T);
            var hit = Physics2D.Raycast(from, Vector2.zero, 0f, layers);

            if (hit)
            {
                hit.transform.TryGetComponent(out result);
            }
            return result;
        }
    }
}