using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{

    public GameObject Demon;
    public GameObject Horse;

    public GameObject Success;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Demon.activeSelf == false && Horse.activeSelf == false)
        {
            Success.SetActive(true);
            AudioListener.pause = true;
        }

        else
        {
            AudioListener.pause = false;
        }
    }
}
