using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDmg : MonoBehaviour
{
    [SerializeField]
    int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GenericHealth>().GetDMG(damage);
        }
    }
}
