using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapperAbility : AbstractAbility
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform abilityPoint;

    PlaySound playSound;

    private void Start()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku                                                                                          
    }
    // Update is called once per frame
    void Update()
    {
        CoolingDown();
    }

    //pøebíjení
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

    //používání ability
    public override void Fire()
    {
        if (!isCooldown)
        {
            Instantiate(prefab, abilityPoint.position, gameObject.transform.rotation);
            isCooldown = !isCooldown;

            playSound.Play(1);
        }
    }
}
