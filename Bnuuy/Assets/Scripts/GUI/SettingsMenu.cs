
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menuSettings;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Dropdown graphicDropdown;
    [SerializeField]
    Toggle fullToggle;

    PlaySound playSound;

    private void Start()
    {
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();

        volumeSlider.value = playSound.volume;

        graphicDropdown.value = QualitySettings.GetQualityLevel();

        fullToggle.isOn = Screen.fullScreen;
    }

    //nastavuje hlasitost
    public void ChangeVolume(float _volume)
    {
        playSound.volume = _volume;
    }

    //nastaví kvalitu grafiky
    public void SetGraphics(int index)
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        QualitySettings.SetQualityLevel(index);
    }

    //nastaví fullscreen
    public void SetFullscreen(bool isFull)
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        Screen.fullScreen = isFull;
    }

    //Zavírá settings okno
    public void CloseSettingsMenu()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        menuSettings.SetActive(false);
    }
}
