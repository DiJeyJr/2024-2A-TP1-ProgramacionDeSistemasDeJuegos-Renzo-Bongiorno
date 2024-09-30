using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    
}

public interface IDamageable
{
    public void Die();
}

public interface IHealthSystem
{
    public int GetHealth();
    public void GetDamage(int damage);
    public void GetHeal(int heal);
    public void ResetHealth();
}