using UnityEngine;

namespace DarkLegion
{
    public static class LayerExtension
    {
        public static bool ContainsIn(LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }
    }
}