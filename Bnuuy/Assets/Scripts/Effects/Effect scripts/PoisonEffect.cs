using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Poison")]
public class PoisonEffect : Effect
{
    [SerializeField]
    float poisonDmg = 1;

    [SerializeField]
    float poisonDuration = 1;

    public override void Apply(GameObject target)
    {
        target.GetComponent<GenericEnemyHealth>().StartPoison(poisonDmg, poisonDuration);
    }
}
