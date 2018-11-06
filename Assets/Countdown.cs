using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public GameObject Success;
    public GameObject Failure;

    // Use this for initialization
    void Start () {
		
	}

    private float timeLeft = 99; // set ur desired game time
    public Text timeremain;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GameOver();
        }

        timeremain.text = "Timer\r\n" + timeLeft.ToString();
    }

    private void GameOver()
    {
        if (Success.activeSelf == false)
        { 
        Failure.SetActive(true);
        }
        //SceneManager.LoadScene(0); // it will reload ur scene, probably this will work as a game restart for your project, you should do some better "game ending thingy" tho
    }
}
