using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{


    public GameObject Enemy;
    Animator EnemyAnimator;

    // Use this for initialization
    void Start()
    {

        EnemyAnimator = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Target")
        {
            EnemyAnimator.SetTrigger("attack");
            Debug.Log("enemyattack", gameObject);
        }

        if (coll.gameObject.tag == "Wall Enemy")
        {
            EnemyAnimator.SetTrigger("rotate");
            Debug.Log("enemyrotate", gameObject);
        }

        if (coll.gameObject.tag == "Enemy")
        {
            return; // do nothing
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Target")
        {
            EnemyAnimator.ResetTrigger("attack");
            Debug.Log("enemyattack", gameObject);
        }
    }



}
