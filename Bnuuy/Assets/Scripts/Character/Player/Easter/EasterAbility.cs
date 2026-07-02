using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterAbility : AbstractAbility
{
    Transform charSprite;
    Transform eggRoll;
    Transform rollSprite;
    Transform weapon;

    AbstractControl inputControl;   //abychom mohli znemo�nit spou�t�n� zm�ny roll, kdy� jsme ve vejci
    AbstractMovement movementScript;

    float inRollTime = 10f;
    float currRollTime = 0f;
    bool isInRoll = false;
    Rigidbody2D rigidbody;

    GenericHealth healthScript;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = gameObject.GetComponent(typeof(AbstractMovement)) as AbstractMovement;
        weapon = transform.Find("PrimaryWeapon");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        eggRoll = transform.Find("EggRollSprite"); 
        charSprite = transform.Find("CharSprite");
        rollSprite = transform.Find("RollSprite");
        inputControl = gameObject.GetComponentInParent<AbstractControl>();
        healthScript = gameObject.GetComponent<GenericHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CoolingDown();
        RollCountDown();
    }

    //kr�l�k se postav� z rollu
    void RollBack()
    {
        inputControl.lockRoll = false;
        isInRoll = false;
        isCooldown = true;
        weapon.gameObject.SetActive(true);
        movementScript.isRoll = false;
        rigidbody.freezeRotation = true;
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        eggRoll.gameObject.SetActive(false);
        charSprite.gameObject.SetActive(true);
        healthScript.invincible = false;
    }

    //doba jak dlouho pojede roll
    void RollCountDown()
    {
        if (!isInRoll)
        {
            return;
        }

        if (currRollTime >= inRollTime)
        {
            RollBack();
            currRollTime = 0;
        }
        else
        {
            currRollTime += Time.deltaTime;
        }

    }

    //cooldown ability
    public override void CoolingDown()
    {
        if (!isCooldown)
        {
            return;
        }

        if (currCooldown >= SetCooldown)
        {
            isCooldown = false;
            currCooldown = 0;
        }
        else
        {
            currCooldown += Time.deltaTime;
        }
    }

    public override void Fire()
    {
        if (isCooldown || isInRoll) //pokud je cd tak se abilita nespust� 
        {
            return;
        }

        weapon.gameObject.SetActive(false);
        movementScript.isRoll = true;
        rigidbody.freezeRotation = false;
        isInRoll = true;
        currRollTime = 0;
        eggRoll.gameObject.SetActive(true);
        charSprite.gameObject.SetActive(false);
        eggRoll.gameObject.GetComponent<EggRoll>().willExplode = true;
        rollSprite.gameObject.SetActive(false);
        inputControl.lockRoll = true;
        healthScript.invincible = true;
    }
}
