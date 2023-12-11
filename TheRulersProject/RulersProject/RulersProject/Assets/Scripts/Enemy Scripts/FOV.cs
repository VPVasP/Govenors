using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
   public Transform Player;
    public float fireRate = 8F;
    private float nextFire = 0f;
    public bool isAttacking = false;
    private void Start()
    {
        Player = Player = GameObject.FindWithTag("Player").transform;
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
                        radius = 7;
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
            radius = 5;
        }
    }
    public void AttackCheck()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 2 && Time.time > nextFire)
        {
            isAttacking = true;
        }
    }

    void GhoulAttack()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 2 && Time.time > nextFire &&isAttacking)
        {
            if (Player.GetComponent<PlayerStats>())
            {
               
                Player.GetComponent<PlayerStats>().TakeDamage(5);
                ComboSystem.instance.canAttack = false;
                nextFire = Time.time + fireRate;
                FOVCheck();
               
            }
            nextFire = Time.time + fireRate;
        }
        else
        {
            ComboSystem.instance.canAttack = true;
        }
    }

    void CrabAttack()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 2 && Time.time > nextFire)
        {
            if (Player.GetComponent<PlayerStats>())
            {
                Player.GetComponent<PlayerStats>().TakeDamage(5);
                nextFire = Time.time + fireRate;
                FOVCheck();
            }
        }
    }
}
