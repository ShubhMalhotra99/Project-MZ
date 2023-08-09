using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    // This Script Handles Target Health and explosions

    public GameObject ExplosionFX;
    public float TargetHealth = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            TargetHealth--;
        }
    }

    private void Update()
    {
        // If health of target becomes 0 then play explosion effect and disable the target
        if(TargetHealth <= 0)
        {
            GameObject explosionFXgameObject = Instantiate(ExplosionFX, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(explosionFXgameObject, 3f);
        }
    }
    // Script Made Shubh Malhotra
}
