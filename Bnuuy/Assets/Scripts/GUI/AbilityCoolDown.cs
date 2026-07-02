using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
    [SerializeField]
    Sprite[] charSprites;
    [SerializeField]
    bool forPlayer1 = true;

    AbstractControl control;
    AbstractAbility ability;

    int index;

    Image charImage;
    Image cdImage;

    // Start is called before the first frame update
    void Start()
    {

        if (forPlayer1)
        {
            index = PlayerPrefs.GetInt("Player1Char", 0);
            control = GameObject.Find("Player1").GetComponent(typeof(AbstractControl)) as AbstractControl;
        }
        else
        {
            index = PlayerPrefs.GetInt("Player2Char", 0);
            control = GameObject.Find("Player2").GetComponent(typeof(AbstractControl)) as AbstractControl;
        }

        ability = control.selectedCharacter.GetComponent(typeof(AbstractAbility)) as AbstractAbility;

        charImage = gameObject.transform.Find("CharImage").GetComponent<Image>();
        cdImage = gameObject.transform.Find("CDImage").GetComponent<Image>();

        charImage.sprite = charSprites[index];

        if (PlayerPrefs.GetInt("GameMode") == 0 && !forPlayer1)   //GameMode 0 znamená, že se hraje single; 1 je pro coop
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ability.isCooldown)
        {
            cdImage.gameObject.SetActive(true);
            cdImage.fillAmount = ((100 * ability.currCooldown) / ability.SetCooldown) / 100;
        }
        else
        {
            cdImage.fillAmount = 0;
            cdImage.gameObject.SetActive(false);
        }
    }
}
