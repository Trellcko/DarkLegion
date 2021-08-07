using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Core.Pooling
{
    public abstract class PoolHandler<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _prefab;

        private Pool<T> _pool;

        private void Awake()
        {
            _pool = new Pool<T>(() => Instantiate(_prefab));
        }

        private void OnEnable()
        {
            _pool.Added += OnAdd;
            _pool.Got += OnGet;
        }
        private void OnDisable()
        {
            _pool.Added -= OnAdd;
            _pool.Got -= OnGet;
        }

        public void Add(T poolObject)
        {
            _pool.Add(poolObject);
        }

        public T Get()
        {
            return _pool.Get();
        }

        private void OnGet(T poolObject)
        {
            poolObject.gameObject.SetActive(true);
        }

        private void OnAdd(T poolObject)
        {
            poolObject.gameObject.SetActive(false);
        }
    }
}