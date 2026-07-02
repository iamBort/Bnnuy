using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isRoll = false;    //kutálíme se?

    public Vector2 move;

    public abstract void RollTransfer();

    public abstract void jump();
}
