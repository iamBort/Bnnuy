using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiEffectApplier : MonoBehaviour
{

    [SerializeField]
    Effect[] effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int i = Random.Range(0, effect.Length);
            effect[i].Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
