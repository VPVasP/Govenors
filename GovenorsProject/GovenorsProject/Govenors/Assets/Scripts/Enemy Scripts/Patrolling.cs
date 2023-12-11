using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrolling : MonoBehaviour
{   
    public Transform Startposition;
    public Transform Secondposition;
    public NavMeshAgent nav;

    void Start()
    {
        nav.destination = Startposition.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("1"))
        {
            nav.destination = Secondposition.position;
        }
        if(other.CompareTag("2"))
        {
            nav.destination = Startposition.position;
        }
        
    }
}
