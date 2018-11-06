using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageScript : MonoBehaviour {

    public RectTransform HPcur;
    public Text HPtext;
    public GameObject Player;
    Animator otherAnimator;
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead", gameObject);
            otherAnimator.SetTrigger("dead");
            
        }
        HPcur.sizeDelta = new Vector2(currentHealth, HPcur.sizeDelta.y);
        
        HPtext.text = currentHealth.ToString();
    }

    // Use this for initialization
    void Start()
    {

        otherAnimator = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            otherAnimator.SetTrigger("damage");
            TakeDamage(Random.Range(10, 15));
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(CanMove(0.9f));
            StartCoroutine(EnableBox(2));
        }
    }

    IEnumerator CanMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        otherAnimator.SetInteger("state", 0);
        otherAnimator.ResetTrigger("damage");
        GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        otherAnimator.ResetTrigger("damage"); 
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
