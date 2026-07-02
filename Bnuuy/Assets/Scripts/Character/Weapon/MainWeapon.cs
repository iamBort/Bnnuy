using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainWeapon : MonoBehaviour
{
    public float angle;

    public bool isFiring;

    public float maxCooldown = 1;
    public float currCooldown;


    public abstract void Fire();
}
