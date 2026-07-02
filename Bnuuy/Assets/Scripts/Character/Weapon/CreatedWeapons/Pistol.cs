using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MainWeapon
{
    [SerializeField]
    Transform gunPoint;  //bod, ze kterého se střílí

    [SerializeField]
    GameObject prefab;  //prefab projektilu, který se střílí

    [SerializeField]
    GameObject weaponSpriteObject;  //objekt pro sprite zbraně(bude potřeba ho flipovat podle toho kam míří)

    [SerializeField]
    int soundIndex = 0;

    float lookAngle;    //ůhel zbraně
    SpriteRenderer weaponSprite; //transform pro sprite zbraně

    PlaySound playSound;

    private void Awake()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //přehrání zvuku
        weaponSprite = weaponSpriteObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        AimWeapon();
        CoolingDown();
        FireMode();
    }

    //míření a flipování zbraně
    //angle je atribut MainWeapon abstraktní třídy
    void AimWeapon()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, angle);

        if (angle < 90 && angle > -90)
        {
            weaponSprite.flipY = false;
        }
        else
        {
            weaponSprite.flipY = true;
        }
    }

    //přebíjí zbraň
    void CoolingDown()
    {
        if (currCooldown < maxCooldown)
        {
            currCooldown += Time.deltaTime;
        }
    }

    //uvnitř se sleduje jestli se má střílet a nepřebíjí se zbraň
    void FireMode()
    {
        if (isFiring 
            && currCooldown >= maxCooldown)
        {
            Fire();
            currCooldown = 0;            
        }
    }

    public override void Fire()
    {
        playSound.Play(soundIndex);
        Instantiate(prefab, gunPoint.position, gameObject.transform.rotation);
    }
}