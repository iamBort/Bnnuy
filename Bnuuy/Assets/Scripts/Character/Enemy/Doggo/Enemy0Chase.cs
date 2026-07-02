using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0Chase : AbstractChase
{
    [SerializeField]
    float distance = 1f; // jak dakeko od hráèe, se postava zastaví

    public float wallDistance = 2f;     //délka raycastu
    public float jump = 5f;

    Transform transformEnemy;
    Rigidbody2D rb;

    float countdown = 0;

    GameObject[] playersPos; //pozice hráèù
    Transform closestPlayer; //nejbližší hráè

    float currSlowDuration;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playersPos = GameObject.FindGameObjectsWithTag("Player");
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        transformEnemy = animator.gameObject.GetComponent<Transform>();
        SetClosestPlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //chase

        PlayerCountCheck(animator);

        Move(); 

        ChaseCountdown(animator);

        CheckForFlip(animator);

        CheckForSlow();
    }

    //Sleduje jakým smìrem postava jde, jestli se smìr zmìnil, tak se otoèí
    void CheckForFlip(Animator animator)
    {
        Vector3 dir = GetDirection();

        if (dir.x < 0 && animator.GetBool("isMovingRight"))    //podmínka jestli se hráè dívá do leva a chceme ho otoèit do prava
        {
            Flip(animator);
        }
        else if (dir.x > 0 && !animator.GetBool("isMovingRight")) //podmínka jestli se hráè dívá do prava a chceme ho otoèit do leva
        {
            Flip(animator);
        }
    }

    //poèítá èas, který uprchne od doby, kdy hráè není v okolí
    void ChaseCountdown(Animator animator)
    {
        if (!animator.GetBool("FoundPlayer"))   //pokud hráè není v triggeru
        {
            if (countdown >= 2f)
            {
                animator.SetBool("isChase", false);
            }
            else
            {
                countdown += Time.deltaTime;
            }
        }
        else
        {
            countdown = 0;
        }
    }

    // sleduje jestli je více hráèù v okolí postavy
    void PlayerCountCheck(Animator animator)
    {
        if (animator.GetInteger("PlayerNumber") > 1 )
        {
            SetClosestPlayer();
        }
    }

    //otoèení postavy
    void Flip(Animator animator)
    {
        if (animator.GetBool("isMovingRight"))    //a my pohybujeme doprava
        {
            transformEnemy.eulerAngles = new Vector3(0, -180, 0);       //tak se otoèíme
            animator.SetBool("isMovingRight", false);                 //a zmìníme hodnotu, se kterou øíkáme, že se hýbeme do prava
        }
        else                                    //jinak se udìlá úplný opak
        {
            transformEnemy.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("isMovingRight", true);
        }
    }

    //poèítání smìru postavy
    Vector3 GetDirection()
    {
        Vector3 dir = closestPlayer.position - transformEnemy.position;
        dir.Normalize();
        return dir;
    }

    //metoda získá nejbližšího hráèe
    void SetClosestPlayer()
    {
        //playersPos = GameObject.FindGameObjectsWithTag("Player");
        Transform closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transformEnemy.position;

        foreach (GameObject player in playersPos)
        {
            float dist = Vector3.Distance(player.transform.position, currentPos);
            if (dist < minDist)
            {
                closest = player.transform;
                minDist = dist;
            }
        }

        /*
        if (closest == null)
        {
            closest = transformEnemy;
        }*/

        closestPlayer = closest;
    }

    //nahánìní hráèe
    void Move()
    {
        if (Vector2.Distance(closestPlayer.position, transformEnemy.position) > distance)
        {
            Vector3 dir = GetDirection();

            if (dir.y >= 0.5)
            {
                Jump();
            }
            transformEnemy.position += new Vector3(dir.x, 0, 0) * Time.deltaTime * speed;
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            Vector2 vector = new Vector2(0, jump*2);
            rb.AddForce(vector, ForceMode2D.Impulse);
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
