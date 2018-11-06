using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    

    void arrowactive()
    {
        gameObject.SetActive(true);
    }

    void arrowinactive()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("arrowoff");
            gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
