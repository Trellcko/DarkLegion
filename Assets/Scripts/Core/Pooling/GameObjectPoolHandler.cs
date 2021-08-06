using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Core.Pooling
{
    public class GameObjectPoolHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private Pool<GameObject> _pool;

        private void Awake()
        {
            _pool = new Pool<GameObject>(() => Instantiate(_prefab));
        }

        private void OnEnable()
        {
            _pool.Added += OnAdd;
            _pool.Geted += OnGet;
        }

        private void OnDisable()
        {
            _pool.Added -= OnAdd;
            _pool.Geted -= OnGet;
        }

        public void Add(GameObject poolObject)
        {
            _pool.Add(poolObject);
        }

        public GameObject Get()
        {
            return _pool.Get();
        }

        private void OnAdd(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }

        private void OnGet(GameObject poolObject)
        {
            poolObject.transform.parent = transform;
            poolObject.SetActive(true);
        }
    }
}