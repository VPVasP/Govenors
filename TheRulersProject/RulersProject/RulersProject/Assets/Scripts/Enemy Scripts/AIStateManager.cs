using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{
    public FOV fov;
    public Patrolling pat;
    public NavMeshAgent enemyAgent;
    public Transform playerTransform;
    public Transform startPos;
    public Transform secPos;
    public Animator anim;
    [SerializeField] private AudioSource aud;
    private enum State
    {
        Patrolling,
        Chasing,
        Attack
    }
    private State state;
    private void Awake()
    {
        state = State.Patrolling;
    }
    void Start()
    {
        pat = GetComponent<Patrolling>();
        fov = GetComponent<FOV>();
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (state) { 
        default:
        case State.Patrolling:
                FindTarget();
                fov.isAttacking = false;
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsChasing", false);
                enemyAgent.speed = 1;

                anim.SetBool("IsWalking",true);
                break;
           
        case State.Chasing:
                transform.LookAt(playerTransform);
                fov.isAttacking = false;
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsChasing", true);
                enemyAgent.speed = 3;
            enemyAgent.SetDestination(playerTransform.position);
                if(fov.canSeePlayer == false)
                {
                    enemyAgent.SetDestination(startPos.position);
                }
            break;

        case State.Attack:
                transform.LookAt(playerTransform);
                anim.SetBool("IsChasing", false);
                if (fov.isAttacking)
                {
                    anim.SetBool("IsAttacking", true);
                
                }
                else if(!fov.isAttacking)
                {
                    anim.SetBool("IsAttacking", false);
                    state = State.Chasing;
                }
            break;
        }
        FindTarget();
    }

    private void FindTarget()
    {
        fov.FOVCheck();

        if (fov.canSeePlayer == true)
        {
            state = State.Chasing; 
        }
        if (fov.canSeePlayer == true && fov.isAttacking == true)
        {
            state = State.Attack;
        }
        if (fov.canSeePlayer == false)
        {
            if (state != State.Patrolling)
            {
                enemyAgent.SetDestination(startPos.position);
                state = State.Patrolling;
                if (Vector3.Distance(transform.position, startPos.position) <= 1)
                {
                    enemyAgent.SetDestination(secPos.position);
                }
                if (Vector3.Distance(transform.position, secPos.position) <= 1)
                {
                    enemyAgent.SetDestination(startPos.position);
                }
            }

        }

    }
}
