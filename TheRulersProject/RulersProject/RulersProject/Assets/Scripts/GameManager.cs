using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator[] platforms;
    public GameObject[] platformsGameObjects;
    public GameObject[] bowls;
    public GameObject[] disabledBowls;
    public GameObject[] shops;
    [SerializeField] private bool levelOneComplete = false, levelTwoComplete = false, levelThreeComplete = false;
    [SerializeField] private float overallCurrency;
[SerializeField] private float CurrentCurrency = 0;
    public TextMeshProUGUI CurrencyText;
    public TextMeshProUGUI enemiesKilledText;
  public AudioSource aud;
    public   AudioClip[] audioClips;
    public GameObject shopPanel;
    public GameObject Sword;
    public GameObject OneHandedSwordOne;
    public GameObject OneHandedSwordTwo;
    public int enemiesKilled;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CurrencyText.text = "Coins " + CurrentCurrency.ToString();
        aud = GetComponent<AudioSource>();
        aud.clip = audioClips[0];
        aud.Play();
        enemiesKilledText.text = "Enemies Killed " + enemiesKilled.ToString();
    }
    private void Update()
    {
        switch (enemiesKilled)
        {
            case 5:
                levelOneComplete = true;
                break;

            case 10:
                levelTwoComplete = true;
                break;

            case 20:
                levelThreeComplete = true;
                break;
        }
      
   
    
        if (levelOneComplete)
        {
            platformsGameObjects[0].SetActive(true);
            platforms[0].SetTrigger("LevelOneComplete");
            bowls[0].SetActive(false);
            bowls[1].SetActive(false);
            shops[0].SetActive(true);

            levelOneComplete = false;
        }
        if (levelTwoComplete)
        {
            platformsGameObjects[1].SetActive(true);
            platforms[1].SetTrigger("LevelTwoComplete");
            disabledBowls[0].SetActive(false);
            bowls[2].SetActive(false);
            shops[1].SetActive(true);

            levelTwoComplete = false;
        }
        if (levelThreeComplete)
        {
            disabledBowls[1].SetActive(false);
            shops[2].SetActive(true);
            levelTwoComplete = false;

            Cursor.lockState = CursorLockMode.None;
            Invoke("LoadOutro", 5f);
        }
    }


    public void BuySword(int swordprice)
    {
        if (Sword.activeInHierarchy)
        {
            return;
        }
        if (CurrentCurrency >= 10)
        {
            swordprice = 10;
            CurrentCurrency -= 10;
            Debug.Log("Bought " + Sword.name);
            CurrencyText.text = "Coins " + CurrentCurrency.ToString();
            OneHandedSwordOne.SetActive(false);
            OneHandedSwordTwo.SetActive(false);
            Sword.SetActive(true);
            shopPanel.SetActive(false);
        }
    }
    public void BuyLightSabersSword(int lightsabePrice)
    {
        if (OneHandedSwordOne.activeInHierarchy)
        {
            return;
        }
        if (CurrentCurrency >= 8)
        {
            lightsabePrice = 8;
            CurrentCurrency -= lightsabePrice;

            CurrencyText.text = "Coins " + CurrentCurrency.ToString();
            Sword.SetActive(false);
            OneHandedSwordOne.SetActive(true);
            OneHandedSwordTwo.SetActive(true);
            shopPanel.SetActive(false);
        }
    }
    public void LoadOutro()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void ExitUpgradeSystem()
    {
        aud.clip = audioClips[0];
        aud.Play();
        shopPanel.SetActive(false);
        PauseManager.instance.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void GainCoins(float gainCoinsCurrency)
    {
        CurrentCurrency += gainCoinsCurrency;
        overallCurrency += gainCoinsCurrency;
        CurrencyText.text = "Coins " + CurrentCurrency.ToString();
    }
    public void UpdateEnemyKillCount()
    {
        enemiesKilled += 1;
        enemiesKilledText.text ="Enemies Killed "+ enemiesKilled.ToString();
    }


}


