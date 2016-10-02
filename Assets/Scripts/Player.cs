using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


    public AudioClip[] audioClip;

    //Floats
    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 230f;
    public float fallMax = -1.5f;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool isRight;

    //Stats(Integers)
    public int curHealth;
    public int maxHealth = 5;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
    private gameMaster gm;

	void Start ()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

        //player position check
        isRight = true;
   
    }
	
	
	void Update ()
    {

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //Player direction
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRight = false;
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRight = true;
        }

        if(Input.GetAxis("Horizontal") == 0)
        {   

            if(isRight == true)
            transform.localScale = new Vector3(1, 1, 1);
            else
            transform.localScale = new Vector3(-1, 1, 1);

        }

        //Player jump
        if (Input.GetButtonDown("Jump"))
        {  
           if(grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                PlaySound(1);
                canDoubleJump = true;
            }else
            {

                //Double jump
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.75f);
                    PlaySound(1);
                }
            }
           
        }

        //Player health management
        if (curHealth > maxHealth)
            curHealth = maxHealth;

        //Die
        if (curHealth <= 0)
            Die();

        //Falling out of the world
        if (transform.position.y < fallMax)
            Die();
	}

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f; 

        float h = Input.GetAxis("Horizontal");

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        //Fake friction for the player
        if(grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die()
    {

        //Restarting(For now)
        SceneManager.LoadScene(Application.loadedLevel);
        PlaySound(0);
    }

    //Damaging the player
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
        PlaySound(2);
    }

    public IEnumerator Knockback(float knockDur, float knockbackPow, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer+=Time.deltaTime;

            //Velocity setting to 0, fix;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPow, transform.position.z));   
        }


        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        //Health
        if (col.CompareTag("Hearth"))
        {
            Destroy(col.gameObject);
            curHealth++;
            PlaySound(4);
        }

        //Points
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
            PlaySound(4);
        }
    }

    //Sound :)
    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = audioClip[clip];
        GetComponent<AudioSource>().Play();
    }
}
