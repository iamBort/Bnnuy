using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggRoll : MonoBehaviour
{
    [SerializeField]
    float damage = 10;

    [SerializeField]
    float explosionCountdown;
    [SerializeField]
    float currExplosionCountdown;

    [SerializeField]
    Transform explosion;

    [HideInInspector]
    public bool willExplode = false;

    private void Start()
    {
        explosion = transform.Find("Explosion");
    }


    // Update is called once per frame
    void Update()
    {
        CountingExplosionDown();
    }

    void CountingExplosionDown()
    {
        if (!willExplode)
        {
            return;
        }

        if (currExplosionCountdown >= explosionCountdown)
        {
            willExplode = false;
            currExplosionCountdown = 0;
            Explosion();
        }
        else
        {
            currExplosionCountdown += Time.deltaTime;
        }
    }

    void Explosion()
    {
        explosion.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<GenericEnemyHealth>().GetDMG(damage);
        }
    }
}
