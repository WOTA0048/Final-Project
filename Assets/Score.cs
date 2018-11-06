using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    public GameObject Finish;
    public Text counterText, pauseText, resumeText, msgText;

    private int counterValue, focusCounter, pauseCounter;
    private DateTime lastMinimize;
    private double minimizedSeconds;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("StartCounter");
        Application.runInBackground = true;
    }


    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(1f);
        counterText.text = "ELAPSED TIME\r\n" + counterValue.ToString();
        counterValue++;
        StartCoroutine("StartCounter");
    }

    void Update()
    {
            StopCoroutine("StartCounter"); // stop the coroutine
            
    }

}