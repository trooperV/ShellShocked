using UnityEngine;

public class Bullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {

        if (!col.isTrigger)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Player>().Damage(1);
            }

            Destroy(gameObject);

        } 

    }

}
