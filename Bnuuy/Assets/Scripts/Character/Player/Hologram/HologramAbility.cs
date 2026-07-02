using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramAbility : AbstractAbility
{
    Transform teleportPoint;
    CircleCollider2D collider;
    PlaySound playSound;

    // Start is called before the first frame update
    void Start()
    {
        teleportPoint = gameObject.transform.Find("TeleportHolder").Find("TeleportPoint");
        collider = gameObject.GetComponent<CircleCollider2D>();
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
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

        var coll = Physics2D.OverlapCircle(teleportPoint.position, collider.radius, 1<<6); //s tímto pøíkazem se dívám, jestli postava nebude collidovat po teleportu se zdí

        if (coll != null)
        {
            return;
        }

        playSound.Play(5);
        gameObject.transform.position = teleportPoint.position;
        isCooldown = true;
    }
}
