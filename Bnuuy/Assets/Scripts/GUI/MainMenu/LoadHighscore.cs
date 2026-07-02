using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighscore : MonoBehaviour
{
    [SerializeField]
    GameObject highscoreText;   //text s nadpisem HIGHSCORE
    [SerializeField]
    Text scoreText; 

    private void Awake()
    {
        SaveLoad saveLoad = GameObject.Find("Canvas").GetComponent<SaveLoad>();

        if (!saveLoad.FileExists())
        {
            return;
        }

        float time = saveLoad.GetTimeFromLoad();
        string name = saveLoad.GetNameFromLoad();

        highscoreText.SetActive(true);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        scoreText.text = "by \n" + name + "\n" +timeSpan.ToString(@"mm\:ss\:fff");
    }

}
