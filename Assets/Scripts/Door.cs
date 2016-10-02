using UnityEngine;


public class Door : MonoBehaviour {

    public int levelToLoad;


    

    private gameMaster gm;
  
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
       

    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {

                SavePoints();
                Application.LoadLevel(levelToLoad);        
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {

                SavePoints();
                Application.LoadLevel(levelToLoad);
            } 
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = (" ");

        }
    }

    void SavePoints()
    {
        PlayerPrefs.SetInt("Points", gm.points);
    }
    
}
