using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject IntroductionText;
    public GameObject StartingGame;
    public void SkipIntroduction()
    {
        IntroductionText.SetActive(false);
        StartingGame.SetActive(true);
        coroutine = WaitAndPrint(1.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Levels");
    }
   
}
