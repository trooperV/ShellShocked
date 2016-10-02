using UnityEngine;


public class Enemy1Direction : MonoBehaviour {

    private Enemy1 enemy1;



    void Start()
    {
        enemy1 = GameObject.FindGameObjectWithTag("Enemy1").gameObject.GetComponent<Enemy1>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Coin"))
        {
            enemy1.Direction();
        }
    }
}
