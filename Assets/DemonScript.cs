using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonScript : MonoBehaviour
{
    
    [SerializeField]
    public Transform target;
    private Transform myTransform;

    public GameObject Child;
    


    public float speed;
    public float defSpeed; //Floating point variable to store the player's movement speed.
    private Vector2 direction;
    public Animator animator;


    public RectTransform HPcur;
    public Text HPtext;
    public const int maxHealth = 300;            // The amount of health the enemy starts the game with.
    public int currentHealth = maxHealth;


    public GameObject Success;

    AudioSource audioData;
    SpriteRenderer color;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;

   

    // Use this for initialization
    void Start()
    {

        defSpeed = speed;
        //Fetch the SpriteRenderer from the GameObject
        
        //Set the GameObject's Color quickly to a set Color (blue)
        color = GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioData.Play(0);


        if (animator.GetInteger("state") == 2)
        {
            speed = 0;
        }

        else
        {
            speed = defSpeed;
        }

        /*
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y * 0, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        */

        if (target.position.x > transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1.5f, transform.localScale.y, transform.localScale.z);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x + -1.2f, transform.position.y), speed * Time.deltaTime);

        }
        else if (target.position.x < transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1.5f, transform.localScale.y, transform.localScale.z);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x + 1.2f, transform.position.y), speed * Time.deltaTime);
        }
    }

    

    public void TakeDamage(int amount)
    {

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        HPtext.text = currentHealth.ToString();
        HPcur.sizeDelta = new Vector2(currentHealth, HPcur.sizeDelta.y);
        StartCoroutine(HitReset(2));

        if (currentHealth <= 0)
        {
            HPtext.text = "Dead".ToString();
            StartCoroutine(Death(0.95f));
            
            
        }
    }

    IEnumerator HitReset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.ResetTrigger("hit");
        GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator Death(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        Debug.Log("Dead", gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Attack")
        {
            TakeDamage(Random.Range(25, 45));
            animator.SetTrigger("hit");
            Debug.Log("hit", gameObject);
        }
    }

   


}

