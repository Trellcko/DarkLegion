using DarkLegion.Core.Spawning;
using DarkLegion.UI;
using DarkLegion.Utils;
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

        private void Start()
        {
            _healtBar.SetMax(_health.Value);
        }

        public void TakeDamage(int damage)
        {
            _health.Set(_health.Value - damage);
            _healtBar.SetValue(_health.Value);
        }    
    }
}