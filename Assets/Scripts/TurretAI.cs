using UnityEngine;

public class TurretAI : MonoBehaviour {

    //Integers
    public int curHealth;
    public int maxHealth = 40;

    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100f;
    public float bulletTimer;
    public float dieTime;

    //Booleans
    public bool awake = false;
    public bool lookingRight = true;
    public bool dieTurret = false;

    //References
    public GameObject bullet;
    public Transform target;
    public Transform shootPointLeft, shootPointRight;
    private Animator anim;
    private gameMaster gm;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);
        anim.SetBool("DieTurret", dieTurret);

        RangeCheck();

        if (target.transform.position.x > transform.position.x)
            lookingRight = true;

        if (target.transform.position.x < transform.position.x)
            lookingRight = false;

        if (curHealth <= 0)
        {
            dieTurret = true;
            dieTime -= Time.deltaTime;

            if (dieTime < 0)
            {
                Destroy(this.gameObject);
                gm.points += 5;
            }
        }

    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
            awake = true;
         
        
     
        if (distance > wakeRange)
            awake = false;
    }

    public void Damage(int damage)
    {
        curHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if(!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;                   
            }

            if(attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }


    }
}
