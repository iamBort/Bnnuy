using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenButtons : MonoBehaviour
{
    [SerializeField]
    Text textField;
    [SerializeField]
    GameObject victoryMenu;
    [SerializeField]
    GameObject nameAskMenu;
    [SerializeField]
    Text errorText;

    public void SubmitName()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        Regex rx = new Regex(@"[\.,<>/%¡´']",    //[A-Za-z0-9]
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        textField.text.Trim();

        MatchCollection matches = rx.Matches(textField.text);

        if (matches.Count != 0)
        {
            errorText.text = "Name contains banned special characters";
            textField.text = "";
            return;
        }

        errorText.text = "";

        if (textField.text.Length < 3 || textField.text.Length > 10)
        {
            errorText.text = "Name needs to be from 3 to 10 characters long";
            textField.text = "";
            return;
        }

        errorText.text = "";

        SaveLoad saveLoad = GameObject.Find("GameMaster").GetComponent<SaveLoad>();
        saveLoad.Save(textField.text);
        victoryMenu.SetActive(true);
        nameAskMenu.SetActive(false);
    }

    public void ContinueToMenu()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        SceneManager.LoadScene(0);
    }

}
