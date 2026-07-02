using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health;
    public bool isDead = false;
    public HealthBar healthBar;
    public float flashTime;
    public Color originalColor;
    public SpriteRenderer renderer;

    public bool invincible = false;

    public void Start()
    {
        renderer = transform.Find("CharSprite").GetComponent<SpriteRenderer>();
        Health = MaxHealth;
        originalColor = renderer.color;
    }

    //refreshování healthbaru
    void Update()
    {
        healthBar.SetHealth(Health, MaxHealth);
    }

    //Bliknout èervenì
    void FlashRed()
    {
        renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        renderer.color = originalColor;
    }

    public void Respawn()
    {
        Health = MaxHealth;
    }

    public void GetDMG(int dmg)
    {
        if (invincible)
        {
            return;
        }

        FlashRed();
        if ((Health - dmg) <= 0)
        {
            PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
            playSound.Play(11);

            Kill();
        }
        else
        {
            Health -= dmg;
        }
    }

    public void GetHeal(int heal)
    {
        if (Health > MaxHealth && !isDead)
        {
            Health = MaxHealth;
        }
        else if(!isDead)
        {
            Health += heal;
        }
    }

    public void GetOverHeal(int heal)
    {
        if (!isDead)
        {
            Health += heal;
        }
    }

    public void Kill()
    {
        Health = 0;
        isDead = true;
        GameObject.Find("GameMaster").GetComponent<Timer>().SaveTimeToPrefs();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
