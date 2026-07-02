using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Aiming : StateMachineBehaviour
{
    [SerializeField]
    Transform gunPoint;  //bod, ze kterého se støílí

    [SerializeField]
    GameObject prefab;  //prefab projektilu, který se støílí

    [SerializeField]
    Transform primaryWeapon;

    [SerializeField]
    Transform weaponSpriteObject;  //objekt pro sprite zbranì(bude potøeba ho flipovat podle toho kam míøí)

    [SerializeField]
    float cooldown = 1.5f; //cooldown zbranì
    float currentCoolldown = 0f; //doba od chvíle, co zbraò vystøelila

    Transform transformEnemy; // transform postavy

    float lookAngle;    //ùhel zbranì
    SpriteRenderer weaponSprite; //transform pro sprite zbranì

    Enemy1Chase chase;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        primaryWeapon = animator.transform.Find("PrimaryWeapon");
        weaponSpriteObject = animator.transform.Find("PrimaryWeapon").transform.Find("SpritePistol");
        weaponSprite = weaponSpriteObject.gameObject.GetComponent<SpriteRenderer>();
        gunPoint = weaponSpriteObject.transform.Find("GunPoint");
        transformEnemy = animator.transform;
        chase = animator.GetBehaviour<Enemy1Chase>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetAngle(animator);
        AimWeapon();
        Fire(animator);
    }

    //vypoèíta úhel pro zbraò
    void GetAngle(Animator animator)
    {
        Vector3 playerPosition = chase.closestPlayer.position;

        Vector3 aimDirection = (playerPosition - primaryWeapon.transform.position).normalized;
        lookAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }

    //míøení zbranì na hráèe    
    void AimWeapon()
    {

        primaryWeapon.transform.eulerAngles = new Vector3(0, 0, lookAngle);

        if (lookAngle < 90 && lookAngle > -90)
        {
            weaponSprite.flipY = false;
        }
        else
        {
            weaponSprite.flipY = true;
        }
    }

    //vystøelí projektil
    void Fire(Animator animator)
    {
        //podmínka pro pøebití zbranì
        if (currentCoolldown >= cooldown)
        {
            Instantiate(prefab, gunPoint.position, primaryWeapon.transform.rotation);
            currentCoolldown = 0f;
        }
        else
        {
            currentCoolldown += Time.deltaTime;
        }
    }
}
