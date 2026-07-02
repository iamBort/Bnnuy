using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourAbility : AbstractAbility
{
    [SerializeField]
    GameObject prefab;

    Transform gunPoint; //odkud se bude støela støílet
    Transform primaryWeapon; //získávám, abych vìdìl jakým smìrem mám abilitu pustit

    PlaySound playSound;

    void Start()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(1);
        gunPoint = transform.Find("PrimaryWeapon").Find("SpritePistol").Find("GunPoint");
        primaryWeapon = transform.Find("PrimaryWeapon");
    }

    // Update is called once per frame
    void Update()
    {
        CoolingDown();
    }

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
        if (isCooldown)
        {
            return;
        }

        playSound.Play(10);

        Instantiate(prefab, gunPoint.position, primaryWeapon.transform.rotation);
        isCooldown = true;
        currCooldown = 0;
    }
}
