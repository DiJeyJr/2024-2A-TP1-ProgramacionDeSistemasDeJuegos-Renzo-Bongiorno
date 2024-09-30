using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private float respawnTime = 10f;
    
    private IHealthSystem _healthManager;

    private void Awake()
    {
        HealthManager baseHealth = GetComponent<HealthManager>();
        
        _healthManager = baseHealth;
        _healthManager = new RegenerationDecorator(_healthManager, this, 5, 2f);
    }

    private void Start()
    {
        _healthManager = GetComponent<HealthManager>();
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
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        transform.GetChild(0).gameObject.SetActive(false); //turn off model
        _healthManager.ResetHealth();
        yield return new WaitForSeconds(respawnTime);
        transform.GetChild(0).gameObject.SetActive(true);//turn on model
    }
}
