using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float Health;
    public bool isDead = false;
    public float flashTime;
    public Color originalColor;
    public SpriteRenderer renderer;

    float poisonDuration = 1;
    float currPoisonDuration = 0;
    float poisonDmg = 1;
    bool isPoisoned = false;

    PlaySound playSound;

    public void Start()
    {
        renderer = gameObject.transform.Find("sprite").GetComponent<SpriteRenderer>();
        Health = MaxHealth;
        originalColor = renderer.color;
        playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
    }

    private void FixedUpdate()
    {
        CheckForPoison();
    }

    void CheckForPoison()
    {
        if (isPoisoned)
        {
            if (currPoisonDuration >= poisonDuration)   //pokud dojde èas
            {
                isPoisoned = false;
                currPoisonDuration = 0;
            }
            else
            {       //dostává dmg
                currPoisonDuration += Time.deltaTime;
                GetDMGNoFlash(poisonDmg);
            }
        }
    }

    //Bliknout zelenì
    void TurnGreen()
    {        
        renderer.color = Color.green;
        Invoke("ResetColor", poisonDuration);
    }

    //Bliknout èervenì
    void FlashRed()
    {
        if (!isPoisoned)
        {
            renderer.color = Color.red;
            Invoke("ResetColor", flashTime);
        }
    }

    void ResetColor()
    {
        renderer.color = originalColor;
    }

    public void Respawn()
    {
        Health = MaxHealth;
    }

    public void GetDMG(float dmg)
    {
        PlaySound playSound = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pøehrání zvuku
        playSound.Play(12);

        FlashRed();
        if ((Health - dmg) <= 0)
        {
            Kill();
        }
        else
        {
            Health -= dmg;
        }
    }

    public void GetDMGNoFlash(float dmg)
    {
        playSound.Play(12);
        if ((Health - dmg) <= 0)
        {
            Kill();
        }
        else
        {
            Health -= dmg;
        }
    }

    public void GetHeal(float heal)
    {
        if (Health > MaxHealth && !isDead)
        {
            Health = MaxHealth;
        }
        else if (!isDead)
        {
            Health += heal;
        }
    }

    public void GetOverHeal(float heal)
    {
        if (!isDead)
        {
            Health += heal;
        }
    }

    public void StartPoison(float _poisonDmg, float _poisonDuration)
    {
        poisonDuration = _poisonDuration;
        poisonDmg = _poisonDmg;
        isPoisoned = true;
        currPoisonDuration = 0;
        TurnGreen();
    }

    public void Kill()
    {
        Health = 0;
        isDead = true;
        Destroy(gameObject);
    }
}
