using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialForce = 1000f;
    public float lifeTime = 0.5f;
    private float lifeTimer = 0f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Add the initial foce to rigidbody
        GetComponent<Rigidbody>().AddRelativeForce(initialForce, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        lifeTimer += Time.deltaTime;

        if(lifeTimer >= lifeTime)
        {
            Explode();
        }
    }

    private void Explode()
    {
        print("Explode");
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //Destroy this projectile (grenade)
        Destroy(gameObject);
    }
}
