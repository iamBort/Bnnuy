using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    [SerializeField]
    int sceneIndex; //na jaká scéna se má naèíst
    [SerializeField]
    bool checkForEnemy; //podívá se potom jestli jsou naživu enemy
    [SerializeField]
    bool saveTimer; //podívá se potom jestli jsou naživu enemy


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (checkForEnemy)  //má se podívat na enemy?
            {
                if (CheckForEnemy()) return;   // jsou zde enemy, pokud ano tak se nenaète scéna
            }

            if (saveTimer)
            {
                SaveTime();
            }

            SceneManager.LoadScene(sceneIndex);
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

    //najde Timer, který uloží èas do registrù
    void SaveTime()
    {
        GameObject.Find("GameMaster").GetComponent<Timer>().SaveTimeToPrefs();
    }
}
