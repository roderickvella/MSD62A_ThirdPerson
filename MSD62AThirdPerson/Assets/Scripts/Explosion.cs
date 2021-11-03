using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public float lifeTime =6f;

    // Start is called before the first frame update
    void Start()
    {
        //An array of nearby colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        //A list to hold the nearby rigidbodies
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach(Collider collider in colliders)
        {
            if(collider.attachedRigidbody != null && !rigidbodies.Contains(collider.attachedRigidbody))
            {
                rigidbodies.Add(collider.attachedRigidbody);
            }
        }

        //apply force (explosion) on the rigidbodies
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
