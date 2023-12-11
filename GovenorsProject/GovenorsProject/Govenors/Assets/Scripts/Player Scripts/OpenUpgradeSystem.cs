using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeSystem : MonoBehaviour
{
    public GameObject OpenUpgrade;
    public GameObject openOption;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openOption.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openOption.SetActive(false);
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            openOption.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            OpenUpgrade.SetActive(true);
        }
    }
}
