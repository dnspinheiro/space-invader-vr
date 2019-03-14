using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectil : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private Rigidbody rig;
    private float speed = 20;
    private bool exploded = false;
    private float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        lifeTime += Time.deltaTime;
        if (transform.position.y < 0) Explode();
        if (lifeTime > 3) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    public void Go(Vector3 direction)
    {
        rig.velocity = direction * speed;
    }

    private void Explode()
    {
        if (exploded) return;
        exploded = true;
        Destroy(Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation), 1);
        Destroy(gameObject);
    }
}
