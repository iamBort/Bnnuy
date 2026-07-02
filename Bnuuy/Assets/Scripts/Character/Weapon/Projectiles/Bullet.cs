
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int BulletSpeed = 1;

    [SerializeField]
    float delay = 10f;
    [SerializeField]
    float dmg = 10f;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    bool destroyOnImpact = true;

    [SerializeField]
    bool canBeHalfed = true;

    bool dmgHalfed = false;


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
        if (collision.gameObject.CompareTag("Ground") && !dmgHalfed && canBeHalfed)
        {
            dmgHalfed = true;
            dmg /= 2;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<GenericEnemyHealth>().GetDMG(dmg);

            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !dmgHalfed && canBeHalfed)
        {
            dmgHalfed = true;
            dmg /= 2;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<GenericEnemyHealth>().GetDMG(dmg);

            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}
