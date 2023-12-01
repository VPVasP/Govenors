using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeSystem : MonoBehaviour
{
    public AudioSource ourMusic;
    public AudioSource UpgradeMusic;
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
            ourMusic.Stop();
            UpgradeMusic.Play();
            OpenUpgrade.SetActive(true);
            PauseManager.instance.isPaused = true;
            Time.timeScale = 0;
        }
    }
}
