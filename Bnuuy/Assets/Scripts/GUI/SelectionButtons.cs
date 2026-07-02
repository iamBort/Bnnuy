using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionButtons : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteList;

    Transform canvas;       //kanvas
    GameObject player1Selection;    //ui kde se ukáže obraz postavy
    Transform player1Img;      //obrázek, který pokud je viditelný, tak øíká, že je hráè selectnutý a postava se za nìj vybírá (to samé funguje pro 2. hráèe) 
    GameObject player2Selection;
    Transform player2Img;
    Text modeText;  //text ve je napsáno jestli je hra pro jednoho nebo pro dva
    bool playerMode = false; // false = 1hráè | true = 2 hráèi

    int player1Index = -1;  //oba hráèi mají -1 na zaèátku, aby se zajistilo, že si oba vyberou postavu a následnì ve høe se deaktivuje player 2 pokud bude uložen index -1 
    int player2Index = -1;

    int selectedPlayer = 0; //selectnutý hráè

    void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
        modeText = canvas.Find("ModeText").GetComponent<Text>();
        player1Selection = canvas.Find("Player1Select").gameObject;
        player2Selection = canvas.Find("Player2Select").gameObject;
        player1Img = player1Selection.transform.Find("Image");
        player2Img = player2Selection.transform.Find("Image");       
    }

    //vybere 1. hráèe
    public void SelectPlayer1()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        selectedPlayer = 0;
        player1Img.gameObject.SetActive(true);
        player2Img.gameObject.SetActive(false);
    }

    //vybere 2. hráèe
    public void SelectPlayer2()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        selectedPlayer = 1;
        player1Img.gameObject.SetActive(false);
        player2Img.gameObject.SetActive(true);
    }

    //mìní mode mezi 1 a 2 hráèi
    public void ChangeMode()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (playerMode)
        {
            playerMode = !playerMode;
            modeText.text = "1 player";
            player2Selection.SetActive(false);
        }
        else
        {
            playerMode = !playerMode;
            modeText.text = "2 players";
            player2Selection.SetActive(true);
        }
    }

    //zapínání hry
    public void StartGame()
    {

        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if ((player1Index == -1 && player2Index == -1 && playerMode)       //pokud hra se nezapne dokud bud nebudou vybrány 2 postavy v coopu nebo jedna postava v singleplayeru
            ||(player1Index != -1 && player2Index == -1 && playerMode)
            || (player1Index == -1 && player2Index != -1 && playerMode))
        {
            return;
        }
              //pokud hra se nezapne dokud bud nebudou vybrány 2 postavy v coopu nebo jedna postava v singleplayeru
        if(player1Index == -1 && !playerMode)
        {
            return;
        }

        if (!playerMode)       //index 2.hráèe se nastaví na -1 pokud hraje pouze jeden èlovìk a omylem se nastaví 2. index na nìco jiného než je -1 
        {
            player2Index = 0;
            PlayerPrefs.SetInt("GameMode", 0);
        }
        else
        {
            PlayerPrefs.SetInt("GameMode", 1);
        }

        PlayerPrefs.SetInt("Player1Char", player1Index);    //uloží se indexi do registrù, aby se mohli použít v další scénì
        PlayerPrefs.SetInt("Player2Char", player2Index);
        PlayerPrefs.SetFloat("time", 0);

        SceneManager.LoadScene("Level1"); //naètení 1. levelu
    }

    //vrácení do menu
    public void BackToMenu()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);
        SceneManager.LoadScene(0);
    }


    //další metody nastaví postavu pro urèitého hráèe a ukážou ji vybranou na obrazovce
    public void BasicBunny()
    {

        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 0;
            player1Selection.GetComponent<Image>().sprite = spriteList[0];
        }
        else
        {
            player2Index = 0;
            player2Selection.GetComponent<Image>().sprite = spriteList[0];
        }
    }

    public void RapperBunny()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 1;
            player1Selection.GetComponent<Image>().sprite = spriteList[1];
        }
        else
        {
            player2Index = 1;
            player2Selection.GetComponent<Image>().sprite = spriteList[1];
        }
    }

    public void AmourBunny()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 2;
            player1Selection.GetComponent<Image>().sprite = spriteList[2];
        }
        else
        {
            player2Index = 2;
            player2Selection.GetComponent<Image>().sprite = spriteList[2];
        }
    }

    public void EasterBunny()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 3;
            player1Selection.GetComponent<Image>().sprite = spriteList[3];
        }
        else
        {
            player2Index = 3;
            player2Selection.GetComponent<Image>().sprite = spriteList[3];
        }
    }

    public void HologramBunny()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 4;
            player1Selection.GetComponent<Image>().sprite = spriteList[4];
        }
        else
        {
            player2Index = 4;
            player2Selection.GetComponent<Image>().sprite = spriteList[4];
        }
    }

    public void MagistacheBunny()
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(0);

        if (selectedPlayer == 0)
        {
            player1Index = 5;
            player1Selection.GetComponent<Image>().sprite = spriteList[5];
        }
        else
        {
            player2Index = 5;
            player2Selection.GetComponent<Image>().sprite = spriteList[5];
        }
    }
}
