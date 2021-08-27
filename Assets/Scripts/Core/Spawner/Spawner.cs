using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Core.Spawning
{
    public abstract class Spawner<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _original;

        public T Spawn(Vector3 position)
        {
            var spawnedObject = Instantiate(_original, transform);
            spawnedObject.transform.localPosition = position;
            return spawnedObject;
        }

    }
}