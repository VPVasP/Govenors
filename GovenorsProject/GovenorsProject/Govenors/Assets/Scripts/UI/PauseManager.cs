using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public AudioSource ourMusic;
    public AudioSource pauseMusic;
    public GameObject optionsMenu;
    public GameObject MainMenu;
    public AudioSource myFX;
    public AudioClip hoverOverFX;
    public AudioClip clickFX;
    [SerializeField] Slider volumeSlider;
    public TextMeshProUGUI dropdownText;
    public static PauseManager instance;
    public bool isPaused;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void HoverSound()
    {
        myFX.PlayOneShot(hoverOverFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        ourMusic.Stop();
        pauseMusic.Play();
        Time.timeScale = 0;
        MainMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1;   
    }
    public void Resume()
    {
        ourMusic.Play();
        pauseMusic.Stop();
        MainMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    public void EnterOptions()
    {
        optionsMenu.SetActive(true);
    }
    public void ExitOptions()
    {
        MainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }
    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void HandleInputDataDropDown(int val)
    {
        if (val == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (val == 1)
        {
            Screen.SetResolution(2560, 1440, true);
        }
        if (val == 2)
        {
            Screen.SetResolution(3840,2160, true);
        }
        if (val == 3)
        {
            Screen.SetResolution(7680, 4320, true);
        }
      
    }
    public void WindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    public void FullWindow()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }
}
