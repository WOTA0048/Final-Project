using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;        //オブジェクトの走りスピード
    private Vector2 direction;  

    public GameObject Failure;　//ゲームオバー画面
    public GameObject arrow;    //矢のレファレンス


    public Rigidbody2D rb2d;        //リジッドボディー
    private Animator animator;      //オブジェクトのアニメーター

    AudioSource audioData;      //オブジェクトの音
    SpriteRenderer color;       //色リファレンス

    public int startingHealth = 100;    //プレイヤーのデフォルトHP
    public int currentHealth;           //プレイヤーの現在HP
    //public Slider healthSlider;                                 // Reference to the UI's health bar.
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
   

    string _currentDirection = "right";     //プレイヤーの現在の方向

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void idle()
    {
        if (animator.GetInteger("combo") == 0)
        {
            Debug.Log("idle");
            animator.SetInteger("state", 0);
        }
    }

    void damageoff()    //ヒットボックスをインアクティブする
    {
        animator.ResetTrigger("damage");
        animator.SetInteger("state", 0);
    }

    void arrowon()  //矢をアクティブする
    {
        arrow.SetActive(true);
    }

    void arrowoff() //矢をインアクティブにする
    {
        arrow.SetActive(false);
    }

    

    // Use this for initialization
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();         //リジッドボディーリファレンス
        color = GetComponent<SpriteRenderer>();     //色リファレンス
        animator = this.GetComponent<Animator>();   //アニメたーリファレンス
        currentHealth = startingHealth;             //HPリファレンス
        audioData = GetComponent<AudioSource>();    //音リファレンス


    }

    void Update()
    {
        Move(); //動く
        direction = Vector2.zero;

        if (rb2d.velocity.y < -0.2)
        {
            animator.ResetTrigger("ground");
        }
        

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
        {
            animator.SetInteger("state", 0);
            animator.SetTrigger("ground");
        }

        if (Input.GetKeyDown("up"))
        {
            Debug.Log("jump", gameObject);
            if (animator.GetBool("jump") == false && animator.GetBool("ground") == true && animator.GetInteger("state") != 8)
            {
                animator.ResetTrigger("run");
                animator.SetInteger("state", 2);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 13f), ForceMode2D.Impulse);
                //changeDirection("up");
            }
        }

        else if (animator.GetInteger("state") <= 4 || animator.GetInteger("state") == 9)
        {

            if (Input.GetKey("left"))
            {
                
                direction -= Vector2.left;
                changeDirection("left");
                animator.SetTrigger("run");
            }

            else if (Input.GetKey("right"))
            {
                
                direction += Vector2.right;
                changeDirection("right");
                animator.SetTrigger("run");
            }

            if (animator.GetBool("ground") == true && (Input.GetKey("left") || (Input.GetKey("right"))))
            {
                animator.SetInteger("state", 1);
                audioData.UnPause();
            }

        }


        
        if (Input.GetKeyDown("down") == true && animator.GetBool("ground") == true)
        {
            animator.SetInteger("state", 3);
        }
        

        if (Input.GetKey("up") == false && Input.GetKey("down") == false && Input.GetKey("left") == false && Input.GetKey("right") == false
            && animator.GetBool("jump") == false && Input.GetKey("x") == false && animator.GetInteger("state") <= 4 || animator.GetInteger("state") == 8)
        {
            audioData.Pause();
            animator.SetInteger("state", 0);
            animator.ResetTrigger("run");
            
        }


        if (Input.GetKeyDown("z") && animator.GetInteger("state") != 2 && animator.GetInteger("state") != 10 && animator.GetBool("damage") == false)
        {
            animator.SetInteger("state", 5);
            animator.SetInteger("combo", 1);
        }
        

        if (Input.GetKey("x") && animator.GetInteger("state") != 10 && animator.GetBool("ground") == true)
        {
            animator.SetInteger("state", 8);
        }

        else  if (Input.GetKey("x") && animator.GetInteger("state") != 10 && animator.GetBool("ground") == false)
        {
            animator.SetInteger("state", 9);
        }

        /*
        if (Input.GetKeyUp("x"))
        {
            animator.SetInteger("state", 0);
            animator.SetInteger("combo", 0);
        }*/

        if (Input.GetKeyUp("z"))
        {
            
            animator.SetInteger("combo", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("fast");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.ResetTrigger("fast");
        }
        
        if (animator.GetBool("damage") == true)
        {
            animator.SetInteger("state", 10);
            
        }

        
    }



    //ダメージを受ける
    public void TakeDamage(int amount)
    {
        //現在HP引く受けたダメージ
        currentHealth -= amount;
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        


        //現在HPは0より低ければ
        if (currentHealth <= 0)
        {
            //死ぬ
            Failure.SetActive(true);
        }
    }


 


    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        
    }

    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            animator.ResetTrigger("jump");
            

            if (animator.GetInteger("state") == 2 && animator.GetBool("ground") == true)
            {
                animator.SetInteger("state", 0);
            }

            else if (animator.GetInteger("state") == 1 && animator.GetBool("ground") == true)
            {
                animator.SetInteger("state", 1);
            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            animator.SetTrigger("ground");
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            audioData.Pause();
            animator.SetInteger("state", 2);
            animator.SetTrigger("jump");
            animator.ResetTrigger("ground");
            animator.ResetTrigger("run");
        }
    }

    



    //--------------------------------------
    // プレイヤーのスプライトをフリップする（弾く）
    //--------------------------------------

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