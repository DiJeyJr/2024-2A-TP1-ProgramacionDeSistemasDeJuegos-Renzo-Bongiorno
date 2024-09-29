using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private NavMeshAgent agent;
        public event Action OnSpawn = delegate { };
        public event Action OnDeath = delegate { };
        
        //HealthManger
        private HealthManager _healthManager;

        //Enemy Pool Declaration
        private Pool<Enemy> _pool;

        //Method to initialize pool on enemy class
        public void Initialize(Pool<Enemy> pool)
        {
            _pool = pool;
        }

        private void Start()
        {
            //Get HelthManager from self
            _healthManager = GetComponent<HealthManager>();
        }

        private void Reset() => FetchComponents();

        private void Awake() => FetchComponents();

        private void FetchComponents()
        {
            agent ??= GetComponent<NavMeshAgent>();
        }

        public void SetTarget(Transform target)
        {
            agent.ResetPath();
            var destination = target.position;
            destination.y = transform.position.y;
            agent.SetDestination(destination);
            StartCoroutine(AlertSpawn());
        }

        private IEnumerator AlertSpawn()
        {
            yield return null;
            OnSpawn();
        }

        
        private void Update()
        {
            if (_healthManager.GetHealth() <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDeath();
            
            //Reset HP
            _healthManager.ResetHealth();
            
            //Return Object To Pool and position reset
            transform.position = transform.parent.position;
            _pool.ReturnToPool(this);
        }
    }
}
