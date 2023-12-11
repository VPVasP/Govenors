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
            GameManager.instance.aud.clip = GameManager.instance.audioClips[0];
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            openOption.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            GameManager.instance.aud.clip = GameManager.instance.audioClips[1];
            OpenUpgrade.SetActive(true);
        }
    }
}
