using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractChase : StateMachineBehaviour
{
    public float speed;

    public float slowAmount;
    public float slowDuration;
    public bool isSlowed = false;

    public abstract void ApplySlow(float amount, float _slowDuration);
}
