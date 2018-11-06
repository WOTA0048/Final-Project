using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorseScript : MonoBehaviour
{

    [SerializeField]
    private float speed;             //Floating point variable to store the player's movement speed.
    private Vector2 direction;
    public Animator animator;

    public RectTransform HPcur;
    public Text HPtext;
    public const int maxHealth = 300;            // The amount of health the enemy starts the game with.
    public int currentHealth = maxHealth;

    
    public GameObject Success;

    AudioSource audioData;

    public void hitreset()
    {
        animator.ResetTrigger("hit");

    }

    // Use this for initialization
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
       
        //Set the GameObject's Color quickly to a set Color (blue)
       
        animator = this.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        direction = Vector2.zero;

        if (animator.GetBool("attack") == true)
        {
            animator.SetInteger("state", 1);
            audioData.UnPause();
        }

        if (animator.GetInteger("state") == 1)
        {
            if (_currentDirection == "left")
            {
                direction += Vector2.left;
            }
            else if (_currentDirection == "right")
            {
                direction -= Vector2.right;
            }
        }

        

        if (animator.GetBool("attack") == false && animator.GetInteger("state") != 1)
        {
            animator.SetInteger("state", 0);
            audioData.Pause();
        }

        if (animator.GetBool("rotate") == true)
        {
            animator.SetInteger("state", 0);
            animator.ResetTrigger("attack");
            audioData.Pause();

            if (_currentDirection == "left")
            {
                animator.ResetTrigger("rotate");
                changeDirection("right");
            }

            else if (_currentDirection == "right")
            {
                animator.ResetTrigger("rotate");
                changeDirection("left");
            }
        }

        if (animator.GetBool("hit") == false)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }

    void FixedUpdate()
    {

    }

    public void TakeDamage(int amount)
    {
        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        HPtext.text = currentHealth.ToString();
        HPcur.sizeDelta = new Vector2(currentHealth, HPcur.sizeDelta.y);

        if (currentHealth <= 0)
        {
            HPtext.text = "Dead".ToString();
            gameObject.SetActive(false);
            Debug.Log("Dead", gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Attack")
        {
            GetComponent<Renderer>().material.color = Color.red;
            TakeDamage(Random.Range(25, 45));
            animator.SetTrigger("hit");
            Debug.Log("hit", gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            animator.ResetTrigger("attack");
            animator.SetInteger("state", 0);

            /*
            if (_currentDirection == "left")
            {
                animator.SetInteger("state", 0);
                changeDirection("left");
            }

            else if (_currentDirection == "right")
            {
                animator.SetInteger("state", 0);
                changeDirection("left");
            }
        }
        */

        }
    }




        /*
            void OnTriggerStay2D(Collider2D coll)
            {
                if (coll.gameObject.tag == "Target")
            {
                animator.SetTrigger("attack");
                Debug.Log("attack", gameObject);
            }
        }
        */

        string _currentDirection = "right";

        void changeDirection(string direction)
        {

            if (_currentDirection != direction)
            {
                if (direction == "right")
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.Rotate(0, 180, 0);
                    _currentDirection = "right";
                }
                else if (direction == "left")
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    //transform.Rotate(0, 180, 0);
                    _currentDirection = "left";
                }

            }
        }
    }


