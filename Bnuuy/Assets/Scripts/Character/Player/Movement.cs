
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : AbstractMovement
{
    public float HopSpeed = 1f;     //můžeme nastavit rychlost pohybu v editoru
    public float RollSpeed = 1f;
    public float Jump = 1f;     //můžeme nastavit výšku skoku v editoru
    public bool boolJump = false;

    private Rigidbody2D rigidbody;   //rigidbody hráče pro skok
    private GameObject charSpriteObject; //získání sprite rendereru postavy 
    private GameObject rollSpriteObject; //získání sprite rendereru rollspritu postavy
    private bool FlipWayRight = true; //jestli se hráč dívá do prava (pro flip postavy)

    public float LadderSpeed = 1; //rychlost lezení po žebříku
    public float distance;
    public LayerMask WhatIsLadder;
    private bool isClimbing;
    public GenericHealth GenericHealth;

    PlaySound playSound;    //pro hraní zvuku

    bool ifGroundHop = false;   //podmínka pro hop v pohybu do leva a do prava, je true pokud se stojí na zemi
    bool ifGroundJump = false;  //podmínka pro jump, je true pokud se stojí na zemi

    [SerializeField]
    float rotationSpeed = 2f;

    string onRope = null;

    bool fellFromRope = false;
    float fellFromRopeCountDown = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();  //najdeme rigidbody hráče
        charSpriteObject = gameObject.transform.Find("CharSprite").gameObject;  //najdeme SpriteRenderer hráče
        rollSpriteObject= gameObject.transform.Find("RollSprite").gameObject;

        playSound  = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
    }

    void FixedUpdate()
    {
        if (fellFromRopeCountDown >= 1)
        {
            fellFromRope = false;
            fellFromRopeCountDown = 0;
        }
        else
        {
            fellFromRopeCountDown += Time.deltaTime;
        }

        movement(); // metoda pro pohyb
    }

    void movement() // metoda pro pohyb
    {

        if (onRope == "HR")
        {
            onHorizontalRope(move.x);
            return;
        }
        else if (onRope == "VR")
        {
            onVerticalRope(move.y);
            return;
        }

        if (isRoll) //pokud jsme v módu rollování
        {
            RollMove(move);
        }
        else
        {
            HopMove(move.x);
        }
    }

    void RollMove(Vector2 movement)
    {
        //podmínka abychom se nedostaly přes rychlostní limit
        if (rigidbody.velocity.x <= 15f && rigidbody.velocity.x >= -15f)
        {
            rigidbody.AddForce(movement * RollSpeed);
        }

        //podmínka pokud se kutálíme jedním směrem a chceme se otočit, tak se otočíme násobkem rotationSpeed rychleji
        if (movement.x < 0 && rigidbody.velocity.x > 0 || movement.x > 0 && rigidbody.velocity.x < 0)
        {
            rigidbody.AddForce(movement * RollSpeed * rotationSpeed);
        }

        if (movement.x * Time.deltaTime > 0 && !FlipWayRight)    //podmínka jestli se hráč dívá do leva a chceme ho otočit do prava
        {
            flip();
        }
        else if (movement.x * Time.deltaTime < 0 && FlipWayRight) //podmínka jestli se hráč dívá do prava a chceme ho otočit do leva
        {
            flip();
        }
    }

    void HopMove(float movement)
    {
        //animator.SetFloat("Speed", Mathf.Abs(movement));

        if (movement != 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * HopSpeed;


            if (ifGroundHop)   // podmínka sleduje jestli postava padá, pokud znamená to, že je na zemi 
            {
                Vector2 vector = new Vector2(0, 5);
                rigidbody.AddForce(vector, ForceMode2D.Impulse);
                ifGroundHop = false;
            }
        }

        if (movement * Time.deltaTime > 0 && !FlipWayRight)    //podmínka jestli se hráč dívá do leva a chceme ho otočit do prava
        {
            flip();
        }
        else if (movement * Time.deltaTime < 0 && FlipWayRight) //podmínka jestli se hráč dívá do prava a chceme ho otočit do leva
        {
            flip();
        }
    }

    public override void jump()  // metoda pro skok
    {

        if (ifGroundJump && !isRoll)     //skok pokud se nekutálím
        {
            if (onRope != null)
            {
                onRope = null;  //pokud skočí, není na provaze
                rigidbody.gravityScale = 5;
                fellFromRope = true;
            }

            Vector2 vector = new Vector2(0, Jump);    // využití námi nastavené hodnoty(jak moc má skočit)
            rigidbody.velocity = new Vector3(0, 0, 0);
            rigidbody.AddForce(vector, ForceMode2D.Impulse);  //skok v impulsu
            ifGroundJump = false;  //nemůže skočit
            ifGroundHop = false;
           
            playSound.Play(13);
        }
        else if (ifGroundJump && isRoll) //skok pokud se kutálím
        {
            Vector2 vector = new Vector2(0, Jump);    // využití námi nastavené hodnoty(jak moc má skočit)
            rigidbody.AddForce(vector / 1.2f, ForceMode2D.Impulse);  //skok v impulsu
            ifGroundJump = false;  //nemůže skočit
            ifGroundHop = false;

            playSound.Play(13);  //přehrání zvuku
        }
    }

    public override void RollTransfer()
    {
        if (onRope != null)  //pokud jsme na provaze spadneme a do kotoulu nejdeme
        {
            onRope = null;
            rigidbody.gravityScale = 5;
            fellFromRope = true;
            return;
        }

        if (isRoll)
        {
            transform.Find("PrimaryWeapon").gameObject.SetActive(true);
            charSpriteObject.SetActive(true);
            rollSpriteObject.SetActive(false);
            rigidbody.freezeRotation = true;

            if (FlipWayRight)//postaví se správným směrem
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        else
        {
            transform.Find("PrimaryWeapon").gameObject.SetActive(false);
            charSpriteObject.SetActive(false);
            rollSpriteObject.SetActive(true);
            rigidbody.freezeRotation = false;
        }

        isRoll = !isRoll;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //hráč se nemůže odrazit od triggeru, který mají enemy, se kterým sledují, kde je hráč 
        //nebo nemůže skákat z projektilů zbraní
        if (collision.gameObject.layer != 7 
            && collision.gameObject.layer != 8)    
        {
            ifGroundJump = true;
        }
        

        if (collision.gameObject.tag == "Ground")
        {
            ifGroundHop = true;
            fellFromRope = false;
            fellFromRopeCountDown = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "HR" && !isRoll && rigidbody.velocity.y < -0.01)
        {
            onRope = "HR";
        }
        else if (collider.gameObject.tag == "VR" && !isRoll && !fellFromRope)
        {
            onRope = "VR";
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("VR") || collider.CompareTag("HR"))
        {
            onRope = null;
            rigidbody.gravityScale = 5;
        }
    }

    void flip()  // metoda pro otočení postavy na druhou stranu
    {
        if (FlipWayRight)    //a my pohybujeme doprava
        {
            transform.eulerAngles = new Vector3(0, -180, 0);       //tak se otočíme
            FlipWayRight = !FlipWayRight;                 //a změníme hodnotu, se kterou říkáme, že se hýbeme do prava
        }
        else                                    //jinak se udělá úplný opak
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            FlipWayRight = !FlipWayRight;
        }
    }
    void onHorizontalRope(float movement)
    {
        ifGroundHop = false;

        rigidbody.velocity = new Vector2(0, 0);

        rigidbody.gravityScale = 0f;


        if (movement != 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * HopSpeed;
        }

        if (movement * Time.deltaTime > 0 && !FlipWayRight)    //podmínka jestli se hráč dívá do leva a chceme ho otočit do prava
        {
            flip();
        }
        else if (movement * Time.deltaTime < 0 && FlipWayRight) //podmínka jestli se hráč dívá do prava a chceme ho otočit do leva
        {
            flip();
        }
    }
    void onVerticalRope(float movement)
    {
        rigidbody.gravityScale = 0f;

        rigidbody.velocity = new Vector2(0, 0);

        ifGroundHop = false;


        if (movement != 0)
        {
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime * HopSpeed;
        }
    }
}
