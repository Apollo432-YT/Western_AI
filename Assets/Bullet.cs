using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void OnEnable ()
    {
		
        Invoke("DestroyMe", 3);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // TODO: speed should be Serialized
        transform.Translate(transform.forward * 10 * Time.deltaTime);
    }

    /// <summary>
   /// We deactivate the bullet when OnCollisionEnter
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Health h = collision.gameObject.GetComponent<Health>();

        if (h!=null)
        {
            h.TakeDamage(10, 100); //TODO: estas variables deberían ser Serializadas
        }

        Without Pool
         // The bullet is destroyed by colliding with the
         // Destroy (gameObject);

         // With Pool, we deactivate the object and add it to the pool, to be able to be reused
        DestroyMe();
    }

    // With Pool, we deactivate the object and add it to the pool, to be able to be reused
    void DestroyMe()
    {
        gameObject.SetActive(false);
        Shot.bulletPool.Add(gameObject);
    }
}
