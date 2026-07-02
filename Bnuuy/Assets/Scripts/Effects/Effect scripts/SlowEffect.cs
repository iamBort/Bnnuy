using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Effects/SlowBuff")]
public class SlowEffect : Effect
{
    [SerializeField]
    float amount;

    [SerializeField]
    float slowDuration;
    
    public override void Apply(GameObject target)
    {
        target.GetComponent<Animator>().GetBehaviour<AbstractChase>().ApplySlow(amount, slowDuration);
        target.GetComponent<Animator>().GetBehaviour<AbstractPatrol>().ApplySlow(amount, slowDuration);
    }
}
