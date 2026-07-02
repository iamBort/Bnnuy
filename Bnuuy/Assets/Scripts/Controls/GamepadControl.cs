using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadControl : AbstractControl
{
    [SerializeField]
    List<GameObject> bunnyList;

    [SerializeField]
    MainWeapon weaponScript;
    [SerializeField]
    AbstractMovement movementScript;
    [SerializeField]
    AbstractAbility abilityScript;

    ControllerActions controls;

    int bunnyIndex; //index králíka za jakého hráè hraje

    Vector2 aim;

    private void Awake()
    {
        bunnyIndex = PlayerPrefs.GetInt("Player2Char", 0);  // získám index za jakou hráè chce hrát

        selectedCharacter = bunnyList[bunnyIndex];


        selectedCharacter.SetActive(true);  //zapne se vybraná postava 

        SetHealthBar();

        Debug.Log("Selected character: " + selectedCharacter);

        //get component na skripty
        weaponScript = selectedCharacter.transform.Find("PrimaryWeapon").GetComponent(typeof(MainWeapon)) as MainWeapon;
        movementScript = selectedCharacter.GetComponent(typeof(AbstractMovement)) as AbstractMovement;
        abilityScript = selectedCharacter.GetComponent(typeof(AbstractAbility)) as AbstractAbility;


        controls = new ControllerActions();


        controls.ControllerGameplay.Fire.started += ctx => weaponScript.isFiring = true;
        controls.ControllerGameplay.Fire.canceled += ctx => weaponScript.isFiring = false;

        controls.ControllerGameplay.BasicAbility.started += ctx => abilityScript.Fire();

        controls.ControllerGameplay.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();

        controls.ControllerGameplay.Roll.started += ctx =>
        {
            if (!lockRoll) movementScript.RollTransfer();   //pokud není locknutý roll tak se spustí pøepnutí do rollu
        };

        controls.ControllerGameplay.Jump.performed += ctx => movementScript.jump();
        
        controls.ControllerGameplay.Move.performed += ctx => movementScript.move = ctx.ReadValue<Vector2>();
        controls.ControllerGameplay.Move.canceled += ctx => movementScript.move = Vector2.zero;



        if (PlayerPrefs.GetInt("GameMode") == 0)   //GameMode 0 znamená, že se hraje single; 1 je pro coop
        {
            selectedCharacter.SetActive(false);
        }
    }

    private void OnEnable()
    {
        controls.ControllerGameplay.Enable();
    }

    private void OnDisable()
    {
        controls.ControllerGameplay.Disable();
    }

    private void FixedUpdate()
    {
        GetGunAngle();
    }

    void GetGunAngle()
    {
        weaponScript.angle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
    }

    void SetHealthBar()
    {
        selectedCharacter.GetComponent<GenericHealth>().healthBar = GameObject.Find("camera").transform.Find("Canvas").Find("HealthBarSlider2").GetComponent<HealthBar>();
    }
}
