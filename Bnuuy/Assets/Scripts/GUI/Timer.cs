using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text text;

    public bool isStoped = false;

    public float currentTime = 0;
    

    void Start()
    {
        currentTime = PlayerPrefs.GetFloat("time", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStoped)
        {
            return;
        }

        currentTime += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        text.text = timeSpan.ToString(@"mm\:ss\:fff");
    }

    public void SaveTimeToPrefs()
    {
        PlayerPrefs.SetFloat("time", currentTime);
    }
}
