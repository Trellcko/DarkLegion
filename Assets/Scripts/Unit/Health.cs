using DarkLegion.Core.Spawning;
using DarkLegion.UI;
using DarkLegion.Utils;
using UnityEngine;

namespace DarkLegion.Unit
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private ComponentStorage storage;
        [SerializeField] private Transform _healtBarPoint;

        private HealtBar _healtBar;

        private int _currentHealth;

        private void Awake()
        {
            _healtBar = FindObjectOfType<HealtBarSpawner>().Spawn(Vector3.zero);
            _healtBar.GetComponent<AttachingUI>().SetTarget(transform);
        }

        private void Start()
        {
            _currentHealth = storage.BaseStats.Health;
            _healtBar.SetMax(storage.BaseStats.Health);
            _healtBar.Emptied += () => { Debug.Log("GG"); };
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, storage.BaseStats.Health);
            _healtBar.SetValue(_currentHealth);
        }
    }
}