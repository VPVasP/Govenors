using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    public Transform Player;
    public float fireRate = 8F;
    private float nextFire = 0.0F;
    public bool isAttacking = false;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    public void FOVCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    if (canSeePlayer)
                    {
                        AttackCheck();
                    }
                }
                else
                {
                    canSeePlayer = false;

                }
            }   
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    public void AttackCheck()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 3  && Time.time > nextFire)
        {
          //  if (Player.GetComponent<PlayerStats>())
            {
                isAttacking = true;
            //    Player.GetComponent<PlayerStats>().TakeDamage();
                nextFire = Time.time + fireRate;
                FOVCheck();            }

        }
        else
        {
            isAttacking = false;
        }
    }
}
