using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoBunnSpriteChange : MonoBehaviour
{
    
    public Sprite SpriteDefault;
    public Sprite SpriteDamaged1;
    public Sprite SpriteDamaged2;

    GenericEnemyHealth Health;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        Health = gameObject.GetComponent<GenericEnemyHealth>();
        renderer = gameObject.transform.Find("sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.Health > (Health.MaxHealth/100)*50)
        {
            renderer.sprite = SpriteDefault;
        }
        else if(Health.Health < (Health.MaxHealth / 100) * 50 && Health.Health > (Health.MaxHealth / 100) * 25)
        {
            renderer.sprite = SpriteDamaged1;
        }
        else if (Health.Health < (Health.MaxHealth / 100) * 25)
        {
            renderer.sprite = SpriteDamaged2;
        }
    }
}
