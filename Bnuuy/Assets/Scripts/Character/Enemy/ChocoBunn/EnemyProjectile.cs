using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public int BulletSpeed = 30;

    [SerializeField]
    float delay = 10f;
    [SerializeField]
    int dmg = 15;

    [SerializeField]
    Rigidbody2D body;

    private void Start()
    {
        body.velocity = transform.right * BulletSpeed;
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject, delay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GenericHealth>().GetDMG(dmg);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GenericHealth>().GetDMG(dmg);
            Destroy(gameObject);
        }
    }
}
