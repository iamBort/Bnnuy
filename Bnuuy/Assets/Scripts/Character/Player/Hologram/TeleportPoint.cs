using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    MainWeapon weaponScript;

    void Start()
    {
        weaponScript = gameObject.transform.parent.transform.Find("PrimaryWeapon").GetComponent<MainWeapon>();
    }

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, weaponScript.angle);
    }
}
