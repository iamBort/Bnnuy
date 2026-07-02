using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAbilityCD : MonoBehaviour
{
    [SerializeField]
    bool forPlayer1;

    AbstractControl controlScript;
    AbstractAbility abilityScript;
    Text textCD;

    void Start()
    {
        if (forPlayer1)
        {
            controlScript = GameObject.Find("Player1").GetComponent(typeof(AbstractControl)) as AbstractControl;
            abilityScript =  controlScript.selectedCharacter.GetComponent(typeof(AbstractAbility)) as AbstractAbility;
        }
        else
        {
            controlScript = GameObject.Find("Player2").GetComponent(typeof(AbstractControl)) as AbstractControl;
            abilityScript = controlScript.selectedCharacter.GetComponent(typeof(AbstractAbility)) as AbstractAbility;
        }

        textCD = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(abilityScript.currCooldown);
        if (abilityScript.currCooldown != 0)
        {
            textCD.text = timeSpan.ToString(@"ss");
        }
        else
        {
            textCD.text = "";
        }
    }
}
