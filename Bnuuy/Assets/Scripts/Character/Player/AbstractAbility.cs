using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbility : MonoBehaviour
{
    public float SetCooldown;
    public float currCooldown;
    public bool isCooldown;

    public abstract void CoolingDown(); 

    public abstract void Fire();
}
