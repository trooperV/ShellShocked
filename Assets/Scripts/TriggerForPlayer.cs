using UnityEngine;


public class TriggerForPlayer : MonoBehaviour {

    private Player player;

    void OnTriggerEnter2D(Collider2D col)
    {

            if (col.CompareTag("Player"))
            {
                col.GetComponent<Player>().Damage(2);
            }
           
     }


}



