using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int Damage;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
            playSound.Play(11);

            coll.gameObject.GetComponent<GenericHealth>().GetDMG(Damage);
        }
    }
}
