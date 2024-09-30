using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthManager : MonoBehaviour, IHealthSystem
{
    //Health
    [SerializeField] private ObjectStats stats;
    private int _health;

    private void OnEnable()
    {
        _health = stats.health;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
    }

    public void GetHeal(int heal)
    {
        _health += heal;
    }

    public void ResetHealth()
    {
        _health = stats.health;
    }
}
