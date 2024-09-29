using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private string targetTag;

    private void OnCollisionStay(Collision other)
    {
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                other.gameObject.GetComponent<HealthManager>().GetDamage(damage);
                StartCoroutine(WaitForCooldown());
            }
        }
    }


    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
    }
}
