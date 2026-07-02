using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Color High;
    public Color Low;
    public Vector3 Offset;

    [SerializeField]
    bool forPlayer1 = true;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        if (PlayerPrefs.GetInt("GameMode") == 0 && !forPlayer1)   //GameMode 0 znamená, že se hraje single; 1 je pro coop
        {
            gameObject.SetActive(false);
        }
    }


    public void SetHealth(int health, int maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }

    void Update()
    {
        //slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
