using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 20;
    
    public float velocity = 1f;
    public float dieTime = 0.3f;

    public bool stomped = false;

    public Animator anim;
    public Rigidbody2D rb2d;
    private gameMaster gm;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

        curHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("Stomped", stomped);


        rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);   
    
       
            

        if(curHealth <= 0)
        {
            stomped = true;
           
            dieTime -= Time.deltaTime;

            
                

            if (dieTime < 0)
            {
                
                Destroy(gameObject);                   
                gm.points += 2;
               
            }
        }
    }

    public void Direction()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        velocity *= -1;
    }

    public void Damage(int damage)
    {
        curHealth -= damage;
        PlaySound();
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    

}
