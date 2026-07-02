using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFind : MonoBehaviour
{
    Animator animator;
    int PlayerNumber = 0;

    private void Start()
    {
        //animator = this.GetComponent<Animator>();
        animator = this.transform.parent.gameObject.GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("FoundPlayer", true);
            PlayerNumber++;
            animator.SetInteger("PlayerNumber", PlayerNumber);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("FoundPlayer", false);
            PlayerNumber--;
            animator.SetInteger("PlayerNumber", PlayerNumber);
        }
    }
}
