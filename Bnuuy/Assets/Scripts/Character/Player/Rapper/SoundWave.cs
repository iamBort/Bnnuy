using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    [SerializeField]
    float delay = 10f;
    [SerializeField]
    int BulletSpeed = 1;
    [SerializeField]
    float sizePerFrame = 1;
    [SerializeField]
    float knockback = 1;
    [SerializeField]
    float damage = 1;

    Transform transform;


    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        DestroyWave();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1 * sizePerFrame, 1 * sizePerFrame, 1 * sizePerFrame);
    }

    private void DestroyWave()
    {
        Destroy(gameObject, delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<GenericEnemyHealth>().GetDMG(damage);

            Transform collTransform = collision.GetComponent<Transform>();
            Rigidbody2D collRigidbody = collision.GetComponent<Rigidbody2D>();

            Vector3 dir = (collTransform.position - transform.position).normalized;
            Debug.Log(dir); 
            
            Vector2 vector = dir * knockback * 100;    // vynásobím sílu knockbacku se smìrem
            Debug.Log(vector);

            collRigidbody.AddForce(vector, ForceMode2D.Impulse);
        }
    }
}
