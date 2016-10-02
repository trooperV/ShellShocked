using UnityEngine;


public class GroundCheck : MonoBehaviour {

    private Player player;

    public int dmg = 20;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            player.grounded = true;
        }

        if (col.isTrigger == false && col.CompareTag("Enemy1"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            player.grounded = true;
        }

        if (col.isTrigger == false && col.CompareTag("Enemy1"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            player.grounded = false;
        }
    }


}
