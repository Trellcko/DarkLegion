using DarkLegion.Core;
using DarkLegion.Core.Spawning;
using DarkLegion.UI;
using DarkLegion.Unit.Stat;
using DarkLegion.Utils;
using System;
using UnityEngine;

namespace DarkLegion.Unit
{
    public class HealtHandler : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private Transform _healthBarPoint;

        private HealtBar _healtBar;

        private void Awake()
        {
            _healtBar = FindObjectOfType<HealtBarSpawner>().Spawn(Vector3.zero);
            _healtBar.GetComponent<AttachingUI>().SetTarget(_healthBarPoint);
        }

        public IValueChanged GetValueChanged()
        {
            return _health;
        }

        private void Start()
        {
            _healtBar.SetMax(_health.Value);
            _healtBar.SetTarget(_health);
        }

        public void TakeDamage(float damage)
        {
            _health.Set(_health.Value - damage);
        }    
    }
}