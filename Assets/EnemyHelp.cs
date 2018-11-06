using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelp : MonoBehaviour
{
    private bool once;
    public GameObject Enemy;
    private bool hit;
    Animator EnemyAnimator;

    // Use this for initialization
    void Start()
    {
        
        hit = false;
        EnemyAnimator = Enemy.GetComponent<Animator>();
        EnemyAnimator.ResetTrigger("attack");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
    void OnTriggerEnter2D(Collider2D coll)
    {
        
            if (coll.gameObject.tag == "Attack")
            {
                EnemyAnimator.SetTrigger("attack");
                hit = true;
                Debug.Log("help", gameObject);
                once = false;
            }
        
    }
    

    
}