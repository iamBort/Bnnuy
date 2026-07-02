using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiAbility : AbstractAbility
{
    [SerializeField]
    float slowTime = 1;
    [SerializeField]
    float currSlowTime = 0;

    bool isSlowed = false;

    PlaySound playSound;


    // Start is called before the first frame update
    void Start()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
    }

    // Update is called once per frame
    void Update()
    {
        SlowCountDown();
        
        CoolingDown();
    }

    //poèítá za jak dlouho se  vypne abilita a zaène cooldown
    void SlowCountDown()
    {
        if (!isSlowed)
        {
            return;
        }


        if (currSlowTime >= slowTime)
        {
            Time.timeScale = 1f;
            isCooldown = true;
            currSlowTime = 0;
            isSlowed = false;
        }
        else
        {
            currSlowTime += Time.deltaTime;
        }
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



    //abilita zpomaluje èas
    public override void Fire()
    {
        if (isSlowed || isCooldown)
        {
            return;
        }

        playSound.Play(3);

        Time.timeScale = 0.5f;
        isSlowed = true;
        currCooldown = 0;
        currSlowTime = 0;
    }
}
