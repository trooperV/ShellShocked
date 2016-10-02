using UnityEngine;


public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        PlaySound();
        if (col.isTrigger == false && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }

        if(col.isTrigger == false && col.CompareTag("Enemy1"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }

    void PlaySound()
    {
        
        GetComponent<AudioSource>().Play();
    }

}
