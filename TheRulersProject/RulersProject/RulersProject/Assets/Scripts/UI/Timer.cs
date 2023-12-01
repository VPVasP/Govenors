using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private IEnumerator coroutine;
    private void Start()
    {
        coroutine = WaitAndPrint(20f);
        StartCoroutine(coroutine);
    }
    
    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Levels");
    }
  
}
