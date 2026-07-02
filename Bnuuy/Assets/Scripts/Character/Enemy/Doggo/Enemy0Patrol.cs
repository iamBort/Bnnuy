using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0Patrol : AbstractPatrol
{
    //public new float speed = 6f;       //rychlost pohybu
    public float groundDistance = 2f;     //délka raycastu
    public float wallDistance = 2f;     //délka raycastu
    public float jump = 5f;
    Transform transformEnemy;

    [SerializeField]
    LayerMask layer;

    public Transform wallCheck0;  //pomocný objekt, ze kterého pùjde reycast, který sleduje, jestli je pøed postavou zem (pokud ne, tak se otoèí a jde druhým smìrem)
    public Transform wallCheck1;
    public Transform groundCheck;  //pomocný objekt, ze kterého pùjde reycast, který sleduje, jestli je pøed postavou zem (pokud ne, tak se otoèí a jde druhým smìrem)
    Rigidbody2D rb;
    bool ifJumped;
    float jumpCountDown = 0;
    int timesJumped = 0;

    float currSlowDuration;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        transformEnemy = animator.transform;
        wallCheck0 = animator.transform.Find("wallCheck0").GetComponent<Transform>();
        wallCheck1 = animator.transform.Find("wallCheck1").GetComponent<Transform>();
        groundCheck = animator.transform.Find("groundCheck").GetComponent<Transform>();
        animator.SetBool("isMovingRight", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckForSlow();
        Patrol(animator);
        JumpReset();
        CheckForPlayer(animator);
    }

    void Patrol(Animator animator)
    {

        if (animator.GetBool("isMovingRight"))
        {
            transformEnemy.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else
        {
            transformEnemy.position += new Vector3(1, 0, 0) * Time.deltaTime * speed * -1;
        }


        Vector3 dir;

        if (animator.GetBool("isMovingRight"))
        {
            dir = transformEnemy.right;
        }
        else
        {
            dir = transformEnemy.right * (-1);
        }

        RaycastHit2D raycastGroundHit2D = Physics2D.Raycast(groundCheck.position, Vector3.down, groundDistance, layer);    //pomocí raycastu se budeme dívat, jestli je dále zem
        RaycastHit2D raycastWallHit2D = Physics2D.Raycast(wallCheck0.position, dir, wallDistance, layer);//pomocí raycastu se budeme dívat, jestli je pøed ním zeï 
        RaycastHit2D raycastWallHit12D = Physics2D.Raycast(wallCheck1.position, dir, wallDistance, layer);
        RaycastHit2D raycastEnemy = Physics2D.Raycast(wallCheck1.position, dir, wallDistance, 1);



        if ((raycastWallHit2D.collider
            || raycastWallHit12D.collider)
            && Mathf.Abs(rb.velocity.y) < 0.001f)     //pokud je na zemi
        {
            Vector2 vector = new Vector2(0, jump * 2);    // využití námi nastavené hodnoty(jak moc má skoèit)
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(vector, ForceMode2D.Impulse);  //skok v impulsu

            if (ifJumped)
            {
                if (timesJumped == 1)
                {
                    ifJumped = false;
                    jumpCountDown = 0;
                    timesJumped = 0;
                    Flip(animator);
                }
                else
                {
                    timesJumped += 1;
                }
            }
            else
            {
                timesJumped = 0;
            }

            ifJumped = true;  //jednou skoèil pokud se dostane k této podmínce znova otoèí se 

        }


        //RaycastHit2D raycastEnemy = Physics2D.Raycast(groundCheck.position, dir, wallDistance);
        if (raycastGroundHit2D.collider == null /*|| (raycastEnemy.collider.gameObject.tag == "Enemy" && raycastEnemy.collider.gameObject.transform.root != transformEnemy.root)*/)     //pokud zem není                                                                                                      
        {
            Flip(animator);
        }

        try
        {
            //pokud narazí do dalšího enemy, tak se otoèí
            if (raycastEnemy.collider.gameObject.tag == "Enemy" && raycastEnemy.collider.gameObject.transform.root != transformEnemy.root)
            {
                Flip(animator);
            }
        }
        catch { }
    }

    //tento segment resetuje otáèení po skákání
    void JumpReset()
    {
        if (ifJumped)
        {
            if (jumpCountDown >= 2.5)
            {
                ifJumped = false;
            }
            else
            {
                jumpCountDown += Time.deltaTime;
            }
        }
        else
        {
            jumpCountDown = 0;
            timesJumped = 0;
        }
    }

    //pokud se našel hráè tak se nastaví isChase na true, která automaticky zaène spouštìt místo patrolu chase
    void CheckForPlayer(Animator animator)
    {
        if (animator.GetBool("FoundPlayer"))
        {
            animator.SetBool("isChase", true);
        }
    }


    void Flip(Animator animator)
    {
        if (animator.GetBool("isMovingRight"))    //a my pohybujeme doprava
        {/*
            transformEnemy.eulerAngles = new Vector3(0, -180, 0);       //tak se otoèíme*/

            transformEnemy.localScale = new Vector3(transformEnemy.localScale.x * (-1), transformEnemy.localScale.y, transformEnemy.localScale.z);

            animator.SetBool("isMovingRight", false);                   //a zmìníme hodnotu, se kterou øíkáme, že se hýbeme do prava
        }
        else                                    //jinak se udìlá úplný opak
        {/*
            transformEnemy.eulerAngles = new Vector3(0, 0, 0);*/

            transformEnemy.localScale = new Vector3(transformEnemy.localScale.x * (-1), transformEnemy.localScale.y, transformEnemy.localScale.z);

            animator.SetBool("isMovingRight", true);
        }
    }

    void CheckForSlow()
    {
        if (isSlowed)
        {
            if (currSlowDuration >= slowDuration)
            {
                slowDuration = 0;
                isSlowed = !isSlowed;
                speed += slowAmount;
                slowAmount = 0;
                currSlowDuration = 0;
            }
            else
            {
                currSlowDuration += Time.deltaTime;
            }
        }
    }

    public override void ApplySlow(float _slowAmount, float _slowDuration)
    {
        if (!isSlowed)
        {
            slowAmount = _slowAmount;
            isSlowed = !isSlowed;
            slowDuration = _slowDuration;
            speed -= _slowAmount;
        }
    }
}
