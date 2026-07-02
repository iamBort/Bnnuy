using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenuButtons : MonoBehaviour
{
    [SerializeField]
    GameObject settingsMenu;

    public void ContinueButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void RespawnButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //znovu naète momentální scénu
    }

    public void SettingsButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        settingsMenu.SetActive(true);
    }

    public void ExitButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        SceneManager.LoadScene(0);
    }
}
