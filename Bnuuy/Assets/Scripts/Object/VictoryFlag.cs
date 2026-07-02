using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryFlag : MonoBehaviour
{
    [SerializeField]
    GameObject nameAskMenu;
    [SerializeField]
    GameObject victoryMenu;
    [SerializeField]
    bool checkForEnemy; //podívá se potom jestli jsou naživu enemy

    SaveLoad saveLoad;

    void Start()
    {
        saveLoad = GameObject.Find("GameMaster").GetComponent<SaveLoad>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (checkForEnemy)  //má se podívat na enemy?
        {
            if (CheckForEnemy()) return;   // jsou zde enemy, pokud ano tak se nenaète scéna
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Victory();
        }
    }

    //vrátí true pokud najde aspoò jednoho enemy; jinak vrátí false
    bool CheckForEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length != 0)
        {
            return true;
        }

        return false;
    }

    void Victory()
    {
        Timer time = GameObject.Find("GameMaster").GetComponent<Timer>();
        time.isStoped = true;
        time.SaveTimeToPrefs();
        float savedTime = saveLoad.GetTimeFromLoad();


        if (!saveLoad.FileExists()
            || savedTime > time.currentTime)
        {
            nameAskMenu.SetActive(true);
            return;
        }

        victoryMenu.SetActive(true);
    }
}
