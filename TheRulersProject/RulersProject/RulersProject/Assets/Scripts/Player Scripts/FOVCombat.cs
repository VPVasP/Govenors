using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVCombat : MonoBehaviour
{
    public Transform Player;
    public float maxAngle;
    public float maxRadius;
    public Animator animator;
    private bool isInFov = false;
    public LayerMask layer;
    public Enemystats enemystats;
    public AudioSource DamageSource;


    private void Start()
    {
       animator = GetComponent<Animator>();
    }



    public void inFOV()
    {

        //collider list can be better with array
        Collider[] overlaps = Physics.OverlapSphere(transform.position, maxRadius, layer);
        //count that finds colliders inside the FOV (overlapspherenonalloc for better performance)
        int count = overlaps.Length;
        if (count <= 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            //if overlaps is not 0
            if (overlaps[i] != null)
            {
                Transform target = overlaps[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                //if target is in FOV
                if (overlaps[i].transform.CompareTag("Enemy"))
                {  
                    //angle to check if it's smaller than maxAngle so we can do stuff
                    float angle = Vector3.Angle(transform.forward, directionToTarget);
                    if (angle <= maxAngle)
                    {  
                        //raycast ray for origin out hit for direction maxRadius for max distance
                        if (Physics.Linecast(transform.position, target.position, layer))
                        {
                            //DamageSource.Play();
                            if (target.GetComponent<Enemystats>())
                            {
                                target.GetComponent<Enemystats>().Losehealth(21);
                            }

                        }
                    }
                }
            }
        }
    }
            
        
       
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (Player.position - transform.position).normalized * maxRadius);

        if (!isInFov)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }
}