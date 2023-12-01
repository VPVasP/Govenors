using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator platform1;
    public Animator platform2;
    public GameObject platformOne;
    public GameObject platformTwo;
    public bool levelOneComplete = false;
    public bool levelTwoComplete = false;
    public bool levelThreeComplete = false;
    public GameObject bowl1;
    public GameObject bowl2;
    public GameObject disabledBowl1;
    public GameObject disabledBowl2;
    public GameObject bowl3;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public int overallCurrency;
    public int CurrentCurrency = 0;
    public int GainCurrency = 5;
    public int BuyCurrency = 10;
    public int BuyCurrencyTwo = 8;
    public TextMeshProUGUI CurrencyText;
    public AudioSource ourMusic;
    public AudioSource UpgradeMusic;
    public GameObject OpenUpgrade;
    public GameObject Sword;
    public GameObject OneHandedSwordOne;
    public GameObject OneHandedSwordTwo;
    public Animator PlayerAnimator;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       CurrencyText.text = "Coins " + CurrentCurrency.ToString();
      
    }

    public void Save()
    {
        PlayerPrefs.SetString("UpgradePoints", CurrencyText.ToString());
     
    }
    public void Load()
    {
        PlayerPrefs.GetString("UpgradePoints", CurrencyText.ToString());
    }
    public void GainCoins()
    {
        CurrentCurrency += GainCurrency;
        overallCurrency += GainCurrency;
        CurrencyText.text = "Coins " + CurrentCurrency.ToString();
        PlayerPrefs.SetString("UpgradePoints", CurrencyText.text);
    }
    public void BuySword()
    {
        if (Sword.activeInHierarchy)
        {
            return;
        }
        if (CurrentCurrency >= 10)
        {
            CurrentCurrency -= BuyCurrency;

            CurrencyText.text = "Coins " + CurrentCurrency.ToString();
            OneHandedSwordOne.SetActive(false);
            OneHandedSwordTwo.SetActive(false);
            Sword.SetActive(true);
        }
    }
    public void BuyLightSabersSword()
    {
        if (OneHandedSwordOne.activeInHierarchy)
        {
            return;
        }
        if (CurrentCurrency >= 8)
        {
            CurrentCurrency -= BuyCurrencyTwo;

            CurrencyText.text = "Coins " + CurrentCurrency.ToString();
            Sword.SetActive(false);
            OneHandedSwordOne.SetActive(true);
            OneHandedSwordTwo.SetActive(true);
        }
    }
    public void LoadOutro()
    {
        SceneManager.LoadScene("Outro");
    }
    public void ExitUpgradeSystem()
    {
        ourMusic.Play();
        UpgradeMusic.Stop();
        OpenUpgrade.SetActive(false);
        PauseManager.instance.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(overallCurrency == 25)
        {
            levelOneComplete = true;
        }
        if (overallCurrency == 50)
        {
            levelTwoComplete = true;
        }
        if (overallCurrency == 100)
        {
            levelThreeComplete = true;
        }
        if (levelOneComplete)
        {
            platformOne.SetActive(true);
            platform1.SetTrigger("LevelOneComplete");
            bowl1.SetActive(false);
            bowl2.SetActive(false);
            box1.SetActive(true);
          
            levelOneComplete = false;
        }
        if (levelTwoComplete)
        {
            platformTwo.SetActive(true);
            platform2.SetTrigger("LevelTwoComplete");
            disabledBowl1.SetActive(false);
            bowl3.SetActive(false);
            box2.SetActive(true);
         
            levelTwoComplete = false;
        }
        if (levelThreeComplete)
        {
            disabledBowl2.SetActive(false);
            box3.SetActive(true);
            levelTwoComplete = false;
           
            Cursor.lockState = CursorLockMode.None;
            Invoke("LoadOutro", 3f);
        }
    }
}
  

    

