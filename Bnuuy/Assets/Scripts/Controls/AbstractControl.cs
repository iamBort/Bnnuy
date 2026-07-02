using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractControl : MonoBehaviour
{
    public GameObject selectedCharacter;   //postava za kterou se hraje

    public bool lockRoll = false;   //zamyká se pøepínání rollu?
}
