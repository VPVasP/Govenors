using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    public Transform startingPosition;
    public CharacterController PlayerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.enabled = false;
            other.gameObject.transform.position = startingPosition.position;
            PlayerController.enabled = true;
        }
    }
}
