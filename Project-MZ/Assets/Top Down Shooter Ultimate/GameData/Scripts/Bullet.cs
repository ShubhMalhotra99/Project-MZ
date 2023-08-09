using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // this script handles Destroying bullet and Impact effects

    public GameObject ImpactFX;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider != null)
        {
            GameObject ImpactFXgameObject = null;

            // instantiate the effect on collision
            if (ImpactFX != null)
            {
              ImpactFXgameObject = Instantiate(ImpactFX, collision.contacts[0].point, Quaternion.identity);
            }

            // Destroy the bullet
            Destroy(gameObject);
            // Destroy spawned effect after 3 Seconds
            if (ImpactFXgameObject != null)
            {
                Destroy(ImpactFXgameObject, 3f);
            }
        }
    }
}
