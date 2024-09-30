using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthDecorator : IHealthSystem
{
    protected IHealthSystem _decoratedHealth;

    public HealthDecorator(IHealthSystem health)
    {
        _decoratedHealth = health;
    }

    public virtual int GetHealth()
    {
        return _decoratedHealth.GetHealth();
    }

    public virtual void GetDamage(int damage)
    {
        _decoratedHealth.GetDamage(damage);
    }

    public virtual void GetHeal(int heal)
    {
        _decoratedHealth.GetHeal(heal);
    }

    public virtual void ResetHealth()
    {
        _decoratedHealth.ResetHealth();
    }
}
