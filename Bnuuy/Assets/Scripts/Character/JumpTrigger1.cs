using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger1 : MonoBehaviour
{

    private BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        collider.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
