using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float knockback = 10;
    public float stunTime = .5f;
    public float damage = 5f;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Vector3 direction = collider.transform.position - transform.position;
            direction.z = 0;
            direction.y = .5f;
            collider.GetComponent<PlayerHealth>().getHit(damage, stunTime, collider, direction, knockback);
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Player")
        {
            Vector3 direction = collider.transform.position - transform.position;
            direction.z = 0;
            direction.y = .5f;
            collider.collider.GetComponent<PlayerHealth>().getHit(damage, stunTime, collider.collider, direction, knockback);
        }
    }
    
}
