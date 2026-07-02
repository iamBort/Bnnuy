using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplier : MonoBehaviour
{
    [SerializeField]
    Effect effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            effect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
