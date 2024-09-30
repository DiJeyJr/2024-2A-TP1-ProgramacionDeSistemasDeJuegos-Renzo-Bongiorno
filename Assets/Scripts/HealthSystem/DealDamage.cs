using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private ObjectStats stats;

    private void OnCollisionStay(Collision other)
    {
        {
            if (other.gameObject.CompareTag(stats.targetTag))
            {
                other.gameObject.GetComponent<HealthManager>().GetDamage(stats.damage);
                StartCoroutine(WaitForCooldown());
            }
        }
    }


    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(stats.attackCooldown);
    }
}
