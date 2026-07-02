using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class KeyboardControl : AbstractControl
{
    [SerializeField]
    List<GameObject> bunnyList;

    [SerializeField]
    MainWeapon weaponScript;
    [SerializeField]
    AbstractMovement movementScript;
    [SerializeField]
    AbstractAbility abilityScript;

    KeyboardActions controls;

    int bunnyIndex; //index králíka za jakého hráè hraje


    private void Awake()
    {
        bunnyIndex = PlayerPrefs.GetInt("Player1Char", 0);  // získám index za jakou hráè chce hrát 

        selectedCharacter = bunnyList[bunnyIndex];
        selectedCharacter.SetActive(true);

        SetHealthBar();

        Debug.Log("Selected character: " + selectedCharacter);

        //get component na skripty
        weaponScript = selectedCharacter.transform.Find("PrimaryWeapon").GetComponent(typeof(MainWeapon)) as MainWeapon;
        movementScript = selectedCharacter.GetComponent(typeof(AbstractMovement)) as AbstractMovement;
        abilityScript = selectedCharacter.GetComponent(typeof(AbstractAbility)) as AbstractAbility;



        controls = new KeyboardActions();

        controls.KeyboardGameplay.Fire.started += ctx => weaponScript.isFiring = true;
        controls.KeyboardGameplay.Fire.canceled += ctx => weaponScript.isFiring = false;

        controls.KeyboardGameplay.BasicAbility.started += ctx => abilityScript.Fire();

        controls.KeyboardGameplay.Roll.started += ctx =>
        {
            if (!lockRoll) movementScript.RollTransfer();   //pokud není locknutý roll tak se spustí pøepnutí do rollu
        };

        controls.KeyboardGameplay.Jump.performed += ctx => movementScript.jump();

        controls.KeyboardGameplay.Move.performed += ctx => movementScript.move = ctx.ReadValue<Vector2>();
        controls.KeyboardGameplay.Move.canceled += ctx => movementScript.move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.KeyboardGameplay.Enable();
    }

    private void OnDisable()
    {
        controls.KeyboardGameplay.Disable();
    }

    private void FixedUpdate()
    {
        GetGunAngle();
    }

    void GetGunAngle()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 aimDirection = (mousePosition - selectedCharacter.transform.position).normalized;
        weaponScript.angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }
    void SetHealthBar()
    {
        selectedCharacter.GetComponent<GenericHealth>().healthBar = GameObject.Find("camera").transform.Find("Canvas").Find("HealthBarSlider1").GetComponent<HealthBar>();
    }
}
