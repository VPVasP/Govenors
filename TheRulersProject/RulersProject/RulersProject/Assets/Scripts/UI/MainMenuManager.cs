using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public SaveManager saveManager;

  public void StartNewGame()
    {
        SceneManager.LoadScene("DemoScene", LoadSceneMode.Additive); // We load our Game Scene
        PlayerPrefs.DeleteAll(); // We delete all our Saved Data
    }
    public void LoadSavedGame()
    {
        SceneManager.LoadScene("DemoScene", LoadSceneMode.Additive);// We load our Game Scene
        saveManager.LoadSaveData();//We load our Save Data
    }
    public void QuitGame()
    {
        Application.Quit();//We quit the game
    }
}
