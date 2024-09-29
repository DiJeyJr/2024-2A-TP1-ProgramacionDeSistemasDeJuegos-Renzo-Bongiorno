using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthManager : MonoBehaviour
{
    //Health
    [SerializeField]private int maxHealth = 100;
    [SerializeField]private int _health;

    private void OnEnable()
    {
        _health = maxHealth;
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
        _health = maxHealth;
    }
}
