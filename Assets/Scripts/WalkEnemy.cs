using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> path1;
    [SerializeField]
    private List<Vector3> path2;
    private List<Vector3> path;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody rig;
    [SerializeField]
    private Animator anim;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0) path = path1;
        else path = path2;
        transform.position = path[0];
        anim.SetFloat("Speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead || HUDPlayer.GameOver()) { rig.velocity = Vector3.zero; return; }
        if(path.Count > 0 && (path[0] - transform.position).magnitude < 0.1f)
        {
            rig.MovePosition(path[0]);
            path.RemoveAt(0);
        }
        if (path.Count > 0)
        {
            rig.velocity = (path[0] - transform.position).normalized * speed;
            transform.LookAt(path[0]);
        }
        else
        {
            rig.velocity = Vector3.zero;
            Explode();
        }
    }

    private void Explode()
    {
        HUDPlayer.singleton.dealDamage(1);
        Destroy(Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation), 1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Explosion"))
        {
            anim.SetBool("Dead", true);
            dead = true;
            rig.velocity = Vector3.zero;
            HUDPlayer.singleton.AddScore(1);
            Destroy(gameObject, 1);
        }
    }
}
