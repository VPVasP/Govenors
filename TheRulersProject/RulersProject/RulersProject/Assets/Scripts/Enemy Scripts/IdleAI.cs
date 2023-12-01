using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAI : MonoBehaviour
{
    public FOV fov;
    public NavMeshAgent enemyAgent;
    public Transform playerTransform;
    public Transform startPos;
    public Animator anim;
    private enum State
    {
        Idle,
        Chasing,
        Attack
    }
    private State state;
    private void Awake()
    {
        state = State.Idle;
    }
    void Start()
    {
        fov = GetComponent<FOV>();
    }

    void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsChasing", false);
                fov.isAttacking = false;
                FindTarget();
                break;

            case State.Chasing:
                transform.LookAt(playerTransform);
                fov.isAttacking = false;
                anim.SetBool("IsChasing", true);
                enemyAgent.SetDestination(playerTransform.position);
                if (fov.canSeePlayer == false)
                {
                    transform.LookAt(startPos);
                    enemyAgent.SetDestination(startPos.position);
                    anim.SetBool("IsAttacking", false);
                    anim.SetBool("IsChasing", false);
                }
                break;

            case State.Attack:
                transform.LookAt(playerTransform);
                anim.SetBool("IsChasing", false);
                if (fov.isAttacking)
                {
                    anim.SetBool("IsAttacking", true);
                }
                else if (!fov.isAttacking)
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
            if (state != State.Idle)
            {
                enemyAgent.SetDestination(startPos.position);
                anim.SetBool("IsWalking", true);
                if (Vector3.Distance(transform.position, startPos.position) <= 2.3)
                {
                    state = State.Idle;
                }
            }

        }

    }
}
