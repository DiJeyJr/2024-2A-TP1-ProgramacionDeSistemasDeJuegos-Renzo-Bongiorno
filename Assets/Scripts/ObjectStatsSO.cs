using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectStats", menuName = "MyScriptableObjects/ObjectStats", order = 1)]
public class ObjectStats : ScriptableObject
{
    public int health;
    public int damage;
    public float attackCooldown;
    public string targetTag;
}
