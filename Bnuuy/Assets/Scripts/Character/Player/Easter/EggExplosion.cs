using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggExplosion : MonoBehaviour
{
    [SerializeField]
    float flashTime = 0.1f;

    [SerializeField]
    float damage = 20f;

    float currFlashTime = 0f;

    PlaySound playSound;

    private void Start()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
    }

    private void Update()
    {
        if (currFlashTime >= flashTime)
        {
            playSound.Play(7);
            currFlashTime = 0f;
            gameObject.SetActive(false);
        }
        else
        {
            currFlashTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<GenericEnemyHealth>().GetDMG(damage);
        }
    }
}
