using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    public bool isWebbed;
    public float knockback = 5;
    public float stunTime = .5f;
    public float damage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isWebbed = true;
            Vector3 direction = other.transform.position - transform.position;
            direction.z = 0;
            direction.y = .5f;
            other.GetComponent<PlayerHealth>().getHit(damage, stunTime, other, -direction, knockback);
            StartCoroutine(Disable());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isWebbed = false;
        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(stunTime);
        isWebbed = false;
    }
}
