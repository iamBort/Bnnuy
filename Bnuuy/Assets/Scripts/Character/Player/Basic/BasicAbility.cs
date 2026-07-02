using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbility : AbstractAbility
{
    [SerializeField]
    float jump;
    [SerializeField]
    float fireSetCooldown;
    float fireCurrCooldown;

    Rigidbody2D rb;
    MainWeapon weaponScript;

    bool firing = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        weaponScript = gameObject.transform.Find("PrimaryWeapon").GetComponent(typeof(MainWeapon)) as MainWeapon;
    }

    private void FixedUpdate()
    {
        CoolingDown();

        if (firing)
        {
            RapidFire();
        }
    }

    //provedení ability
    //inicializuje ji 
    //provede skok a o druhou èást ability se zajímá RapidFire
    public override void Fire()
    {
        if (!isCooldown)
        {
            Vector2 vector = new Vector2(0, jump);    // využití námi nastavené hodnoty(jak moc má skoèit)
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(vector, ForceMode2D.Impulse);  //skok v impulsu
            isCooldown = !isCooldown;
            firing = !firing;
        }
    }

    //na nìjakou dobu zaène rapidnì støílet
    void RapidFire()
    {
        if (fireCurrCooldown <= fireSetCooldown)
        {
            weaponScript.Fire();
            fireCurrCooldown += Time.deltaTime;
        }
        else
        {
            fireCurrCooldown = 0;
            firing = !firing;
        }
    }

    //pøebíjení ability
    public override void CoolingDown()
    {
        if (isCooldown)
        {
            if (currCooldown >= SetCooldown)
            {
                isCooldown = !isCooldown;
                currCooldown = 0;
            }
            else
            {
                currCooldown += Time.deltaTime;
            }
        }
    }
}
