using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    GameObject infoPanel;
    [SerializeField]
    GameObject settingsPanel;

    public void StartButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        SceneManager.LoadScene(1);      //scéna se zmìní
    }

    public void SettingsButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        settingsPanel.SetActive(true);
    }

    public void InfoButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        infoPanel.SetActive(true);
    }

    public void QuitButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        Application.Quit();
    }



    ///
    ///Info tab
    ///

    [SerializeField]
    GameObject goal;
    [SerializeField]
    GameObject controls;
    [SerializeField]
    GameObject bunny;

    public void GoalButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        goal.SetActive(true);
        controls.SetActive(false);
        bunny.SetActive(false);
    }

    public void ControlsButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        goal.SetActive(false);
        controls.SetActive(true);
        bunny.SetActive(false);
    }

    public void BunnysButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        goal.SetActive(false);
        controls.SetActive(false);
        bunny.SetActive(true);
    }

    public void BackInfoButton()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        infoPanel.SetActive(false);
    }
}
